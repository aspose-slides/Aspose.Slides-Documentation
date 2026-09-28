---
title: "Kör Aspose.Slides för .NET i Docker"
linktitle: Docker
type: docs
weight: 140
url: /sv/net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfil
- Dockerbehållare
- flerstegsbyggnad
- behållarbild
- Linux
- Ubuntu
- Alpine
- libfontconfig
- libgdiplus
- teckensnitt
- PDF-konvertering
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Bygg och kör ett Aspose.Slides för .NET konsolprogram i Docker: en flerstegs Dockerfile på de officiella .NET‑bilderna, de Linux‑bibliotek och teckensnitt som behövs, och hur du kopierar de genererade filerna till din maskin."
---
## **Översikt**

Den här artikeln visar hur man kör Aspose.Slides för .NET i en Docker‑behållare. Du bygger ett litet konsolprogram som skapar en presentation med en textruta och konverterar den till PDF, paketerar den med en flerstadig Dockerfile på Microsofts officiella .NET‑bilder, kör den och kopierar de genererade filerna till din dator. Artikeln listar också de Linux‑bibliotek och teckensnitt som Aspose.Slides behöver i behållaren och avslutar med en variant för Alpine Linux.

Du behöver bara Docker på din maskin. .NET SDK är en del av bygg‑imagen, så du behöver inte installera den. För att installera Docker, se [Get Docker](https://docs.docker.com/get-started/get-docker/).

## **Välj paketet och basavbilden**

Standard .NET 10‑behållarbilderna är baserade på Ubuntu 24.04. På dessa bilder använder du paketet [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Det kräver `fontconfig`‑biblioteket, och .NET‑runtime‑imagen innehåller varken det biblioteket eller några teckensnitt, så Dockerfilen i den här artikeln installerar båda.

Aspose.Slides.NET6.CrossPlatform kör inte på Alpine Linux. För Alpine‑baserade bilder, använd paketet [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) med `libgdiplus`, som beskrivs i [Run on Alpine Linux](#run-on-alpine-linux). [Installation](/slides/sv/net/installation/) jämför de två paketen.

## **Skapa projektet**

Skapa en mapp med namnet *HelloSlidesDocker* och lägg till följande tre filer i den.

*HelloSlidesDocker.csproj* beskriver ett konsolprogram för .NET 10, versionen av de behållarbilder som används nedan, och refererar till Aspose.Slides.NET6.CrossPlatform. Ange paketversionen till den senaste som listas på [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/).

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Aspose.Slides.NET6.CrossPlatform" Version="26.9.0" />
  </ItemGroup>

</Project>
```

*Program.cs* skapar en [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), lägger till en rektangel med text på sin första bild och sparar presentationen två gånger med [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)-metoden: som PPTX och som PDF. Båda filerna placeras i *output*-mappen under arbetskatalogen. Applikationen listar sedan de teckensnitt som ersattes när PDF:en renderades, med hjälp av [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/), så att du kan se om behållaren har de teckensnitt som presentationen använder.

```c#
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var outputFolder = "output";
Directory.CreateDirectory(outputFolder);

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello from a Docker container!";

var pptxPath = Path.Combine(outputFolder, "hello.pptx");
var pdfPath = Path.Combine(outputFolder, "hello.pdf");
presentation.Save(pptxPath, SaveFormat.Pptx);
presentation.Save(pdfPath, SaveFormat.Pdf);

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"Font substitution: {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

Console.WriteLine($"Saved {pptxPath} and {pdfPath}");
```

*.dockerignore* håller *bin*- och *obj*-mapparna från en lokal byggnad samt utdata från tidigare körningar utanför Docker‑byggkontexten, så att imagen byggs endast från källfilerna.

```text
bin/
obj/
output/
```

## **Skriv Dockerfilen**

Lägg till en fil med namnet *Dockerfile* i samma mapp:

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY HelloSlidesDocker.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish --no-restore -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:10.0
RUN apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
```

Filen har två steg:

- **The build stage** startar från .NET SDK‑imagen. Den kopierar projektfilen och återställer NuGet‑paketen först, så Docker återanvänder det lagret så länge projektfilen inte förändras. Därefter kopierar den källkoden och publicerar applikationen till */app*.
- **The runtime stage** startar från den mindre .NET‑runtime‑imagen, som saknar SDK, och kopierar bara in den publicerade applikationen. Den installerar två paket:
  - `libfontconfig1`: Aspose.Slides.NET6.CrossPlatform laddar detta bibliotek när det startar. Utan det avbryts applikationen med ett `DllNotFoundException` som nämner `libfontconfig.so.1`.
  - `fonts-dejavu-core`: runtime‑imagen innehåller inga teckensnitt, och Aspose.Slides behöver minst ett installerat teckensnitt för att rita text; utan något stoppas konverteringen med `InvalidOperationException: Cannot find any fonts installed on the system.` Text i teckensnitt som inte är installerade ritas med ett ersättningsteckensnitt. DejaVu‑teckensnitten är en liten uppsättning som gör att text renderas; för att rendera presentationer med de teckensnitt de är designade för, se [Deploy Fonts](/slides/sv/net/deploy-fonts/).

`--no-install-recommends` och borttagandet av paketlistorna håller imagen liten. De sista raderna skapar *output*-mappen, ger den till den icke‑root‑`app`‑användaren som de officiella .NET‑bilderna definierar (dess användar‑ID finns i variabeln `APP_UID`), och kör applikationen som den användaren.

För en ASP.NET Core‑applikation, starta runtime‑steget från `mcr.microsoft.com/dotnet/aspnet:10.0` istället. Den är baserad på samma Ubuntu‑image, så samma paket behövs.

## **Bygg och kör behållaren**

Öppna en terminal i *HelloSlidesDocker*-mappen. Bygg imagen, och kör sedan en behållare från den:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

Den första byggnaden hämtar grund‑imagena och NuGet‑paketen, så den tar längre tid än senare byggningar. Behållaren kör applikationen och stoppar. Den skriver ut:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

Den första raden visar att texten använder Calibri, standardteckensnittet för en ny presentation, och att Calibri inte är installerat i imagen, så Aspose.Slides ritade texten med DejaVu Sans. Texten i PDF‑filen är riktig, markerbar text i det teckensnittet. Utan licens lägger Aspose.Slides också till ett utvärderingsvattenstämpel på varje bild den sparar; se [Licensing](/slides/sv/net/licensing/).

## **Kopiera utdata till din maskin**

Filerna finns i */app/output*-mappen i den stoppade behållaren. Kopiera dem till en *output*-mapp på din maskin, och ta sedan bort behållaren:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Dessa två kommandon fungerar på samma sätt i Bash, PowerShell och Windows Command Prompt.

På Linux kan du istället montera en mapp från din maskin i behållaren, så att applikationen skriver sina filer där direkt:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

`--user`‑alternativet kör applikationen med dina användar- och grupp‑ID:n, så den kan skriva till mappen du skapade och filerna tillhör dig. `--rm` tar bort behållaren när den stoppar.

## **Kör på Alpine Linux**

För att köra applikationen i en Alpine‑baserad image, byt till Aspose.Slides.NET‑paketet och ändra runtime‑steget. Build‑steget förblir detsamma.

1. I *HelloSlidesDocker.csproj*, ersätt paketreferensen:

   ```xml
   <PackageReference Include="Aspose.Slides.NET" Version="26.9.0" />
   ```

1. I *Program.cs*, lägg till detta uttalande efter `using`‑direktiven, före det första Aspose.Slides‑anropet. Det möjliggör System.Drawing‑stöd för Linux som Aspose.Slides.NET använder:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

1. I *Dockerfile*, ersätt runtime‑steget (allt från den andra `FROM`‑raden) med:

   ```dockerfile
   FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
   ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
   RUN apk add --no-cache icu-libs libgdiplus font-dejavu
   WORKDIR /app
   COPY --from=build /app .
   RUN mkdir output && chown $APP_UID output
   USER $APP_UID
   ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
   ```

Alpine‑steget installerar tre paket och ändrar en inställning:

- `libgdiplus` är grafikbiblioteket som Aspose.Slides.NET använder på Linux.
- `font-dejavu` tillhandahåller teckensnitt. Utan något teckensnitt stoppar konverteringen med `System.ArgumentException: Font '?' cannot be found`.
- `icu-libs` och `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false` tillhandahåller kulturdata. Alpine‑.NET‑imagene kör i globalisering‑invariant läge som standard, så i det läget stoppar Aspose.Slides med ett `CultureNotFoundException` för `en-US`.

Bygg, kör och kopiera utdata med samma kommandon som ovan. På den här imagen skriver applikationen bara ut `Saved`‑raden: med Aspose.Slides.NET på Linux väljer fontconfig ersättningen för ett saknat teckensnitt, och [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) listar det inte. [Deploy Fonts](/slides/sv/net/deploy-fonts/) visar hur du kontrollerar vilket teckensnitt som används.

## **FAQ**

**Applikationen stoppar med "Unable to load shared library 'libaspose.slides.drawing.capi…'". Vad saknas?**

På Ubuntu‑ och Debian‑bilderna är paketet `libfontconfig1` behövt; meddelandet visar `libfontconfig.so.1` som filen som inte kunde öppnas. På Alpine Linux betyder meddelandet att Aspose.Slides.NET6.CrossPlatform är i bruk; byt till Aspose.Slides.NET som beskrivs i [Run on Alpine Linux](#run-on-alpine-linux).

**Varför är texten i PDF‑filen i ett annat teckensnitt än i PowerPoint?**

De teckensnitt som presentationen använder är inte installerade i imagen, så Aspose.Slides ritar texten med ett ersättningsteckensnitt. Applikationens utdata namnger varje ersatt teckensnitt. [Deploy Fonts](/slides/sv/net/deploy-fonts/) förklarar hur man installerar teckensnitt i imagen eller laddar dem från applikationsmappen.

**Behöver jag .NET SDK på min maskin?**

Nej. Build‑steget kompilerar applikationen i SDK‑imagen. Du behöver SDK bara om du också vill bygga och köra applikationen utanför Docker; se [Installation](/slides/sv/net/installation/).