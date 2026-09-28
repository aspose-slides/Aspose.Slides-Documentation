---
title: Distribuera teckensnitt för Aspose.Slides på Linux och i Docker
linktitle: Distribuera teckensnitt
type: docs
weight: 145
url: /sv/net/deploy-fonts/
keywords:
- distribuera teckensnitt
- installera teckensnitt
- teckensnitt i Docker
- teckensnitt på Linux
- saknade teckensnitt
- teckensnittsersättning
- Microsoft kärnteckensnitt
- ttf-mscorefonts-installer
- anpassade teckensnitt
- standardteckensnitt
- server
- container
- PDF-konvertering
- presentation
- .NET
- C#
- Aspose.Slides
description: "Distribuera teckensnitt för Aspose.Slides för .NET på Linux-servrar och i Docker-containrar: kontrollera vilka teckensnitt som ersätts, installera teckensnittspaket på Debian, Ubuntu och Alpine, lägg till egna teckensnittsfiler och ange ett standardteckensnitt."
---
## **Översikt**

Aspose.Slides ritar text med de teckensnitt som är tillgängliga när den renderar en presentation, till exempel när den konverterar bilder till PDF eller till bilder. En Windows‑dator har vanligtvis de teckensnitt som presentationer använder. Linux‑servrar och containrar har vanligtvis få eller inga teckensnitt, så Aspose.Slides ritar texten med ett ersättningsteckensnitt. Ett ersättningsteckensnitt har andra bokstavsformer och bredd, så rader kan radbrytas annorlunda och text kan flöda över sin form, och tecken som ersättningen saknar ritas inte korrekt. Om inget teckensnitt är installerat alls stoppas konverteringen med ett fel.

Den här artikeln visar hur du kontrollerar vilka teckensnitt Aspose.Slides ersätter, hur du installerar teckensnitt på Debian, Ubuntu och Alpine Linux, hur du lägger till dina egna teckensnittsfiler och hur du ställer in det teckensnitt som används när ett teckensnitt saknas. Exemplen körs i Docker på de officiella .NET‑bilderna, som i [Run Aspose.Slides for .NET in Docker](/slides/sv/net/how-to-run-aspose-slides-in-docker/). Paketkommandona är Dockerfile‑instruktioner; på en Linux‑server kör du samma kommandon som root.

För själva teckensnitt‑API:n, såsom inbäddning av teckensnitt i en presentation samt reserv‑ och ersättningsregler, se [PowerPoint Fonts](/slides/sv/net/powerpoint-fonts/).

## **Kontrollera vilka teckensnitt som ersätts**

Följande konsolprogram rapporterar vilka teckensnitt Aspose.Slides ersätter i den aktuella miljön. Skapa en mapp med namnet *FontCheck* och lägg till filerna nedan i den.

*FontCheck.csproj* refererar till [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/), paketet för Debian och Ubuntu. Det kopierar också filerna i en valfri *fonts*-mapp till applikationens utdata; avsnittet [Load Fonts from the Application Folder](#load-fonts-from-the-application-folder) använder den.

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
    <None Update="fonts/**" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>

</Project>
```

*Program.cs* lägger till en textruta per teckensnittsnamn på en bild och tilldelar teckensnittet via egenskapen [LatinFont](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/latinfont/). Teckensnittsnamnen kommer från kommandoraden; utan argument kontrollerar programmet Calibri, Arial och Times New Roman. Det skriver ut mapparna där Aspose.Slides letar efter teckensnitt ([FontsLoader.GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/)), renderar bilden till *output/fonts.pdf* och skriver ut ersättningarna som rapporteras av [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/). De två valfria stegen i början, laddning av en *fonts*-mapp och läsning av variabeln `DEFAULT_FONT`, förklaras senare i den här artikeln.

```c#
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

// Teckensnitten att kontrollera: kommandoradsargumenten, eller tre vanliga Office‑teckensnitt.
var fontNames = args.Length > 0 ? args : new[] { "Calibri", "Arial", "Times New Roman" };

// Läs in teckensnittsfilerna från fonts‑mappen intill applikationen, om den finns.
var appFontFolder = Path.Combine(AppContext.BaseDirectory, "fonts");
if (Directory.Exists(appFontFolder))
{
    FontsLoader.LoadExternalFonts(new[] { appFontFolder });
}

// Använd teckensnittet som anges i miljövariabeln DEFAULT_FONT, om den är satt, för text vars teckensnitt saknas.
var loadOptions = new LoadOptions();
var defaultFont = Environment.GetEnvironmentVariable("DEFAULT_FONT");
if (!string.IsNullOrEmpty(defaultFont))
{
    loadOptions.DefaultRegularFont = defaultFont;
}

var fontFolders = FontsLoader.GetFontFolders().Distinct();
Console.WriteLine($"Font folders: {string.Join(", ", fontFolders)}");

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
for (var i = 0; i < fontNames.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
    shape.TextFrame.Text = $"This text is set in {fontNames[i]}.";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData(fontNames[i]);
}

Directory.CreateDirectory("output");
presentation.Save(Path.Combine("output", "fonts.pdf"), SaveFormat.Pdf);

var substitutions = presentation.FontsManager.GetSubstitutions().ToList();
if (substitutions.Count == 0)
{
    Console.WriteLine("No font substitutions.");
}
else
{
    Console.WriteLine("Font substitutions:");
    foreach (var substitution in substitutions)
    {
        Console.WriteLine($"  {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
    }
}
```

*.dockerignore* håller lokala byggresultat ute från byggkontexten:

```text
bin/
obj/
output/
```

*Dockerfile* bygger applikationen med .NET SDK‑bilden och kör den på .NET‑runtime‑bilden. Runtime‑steget installerar `libfontconfig1`, som Aspose.Slides.NET6.CrossPlatform kräver, samt DejaVu‑teckensnitten. [Run Aspose.Slides for .NET in Docker](/slides/sv/net/how-to-run-aspose-slides-in-docker/) förklarar varje instruktion.

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY FontCheck.csproj .
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
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

Bygg bilden och kör kontrollen:

```bash
docker build -t font-check .
docker run --rm font-check
```

Bilden har endast DejaVu‑teckensnitten, så alla tre teckensnitten ersätts med DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

För att kontrollera teckensnitten i dina egna presentationer, skicka deras namn som argument, till exempel `docker run --rm font-check "Segoe UI" Consolas`. För att kopiera *output/fonts.pdf* ur containern, använd kommandona i [Copy the Output to Your Machine](/slides/sv/net/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Installera teckensnitt på Debian och Ubuntu**

### **Microsoft Core Fonts**

Paketet `ttf-mscorefonts-installer` hämtar och installerar Microsofts kärnteckensnitt för webben, bland dem Arial, Times New Roman, Courier New, Verdana, Georgia och Trebuchet MS. Teckensnitten är licensierade under Microsofts slutbrukarlicensavtal (EULA), och paketet installerar dem först efter att EULA har accepterats. En Docker‑byggnad kan inte svara på prompten, så installationsprogrammet avböjer EULA och installerar inga teckensnitt, medan `apt-get install` ändå rapporterar framgång. Acceptera EULA med `debconf-set-selections` **innan** paketet installeras.

I *Dockerfile*, ersätt `RUN`‑instruktionen som installerar paketen i runtime‑steget med:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Bygg bilden och kör kontrollen igen med samma två kommandon. Arial och Times New Roman är nu installerade:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, standardteckensnittet för en presentation som Aspose.Slides skapar, är inte ett av kärnteckensnitten, så det ersätts fortfarande. Se [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts).

På Debian finns paketet i `contrib`‑arkivet, som Debian‑bilderna inte aktiverar; de standard .NET 8‑ och .NET 9‑bilderna bygger på Debian 12. Aktivera `contrib` i samma instruktion:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

De Ubuntu‑baserade .NET 10‑bilderna har redan `multiverse` aktiverat, Ubuntu‑komponenten som innehåller paketet.

### **Andra teckensnittspaket**

Debian och Ubuntu paketerar även fritt licensierade teckensnitt, till exempel:

| Paket | Teckensnitt |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif och Mono, med samma mått som Arial, Times New Roman och Courier New |
| `fonts-crosextra-carlito` | Carlito, med samma mått som Calibri |
| `fonts-crosextra-caladea` | Caladea, med samma mått som Cambria |

Installera dem med `apt-get install` i samma `RUN`‑instruktion. Aspose.Slides.NET6.CrossPlatform använder inte de teckensnittsalias som Linux‑teckensnitts­konfigurationen definierar: med `fonts-liberation` installerat ritas text i Arial fortfarande med det generella ersättningsteckensnittet, inte med Liberation Sans. För att använda ett metrisk‑kompatibelt teckensnitt i stället för ett saknat, ställ in det som [default font](#set-a-default-font-for-missing-fonts) eller lägg till en [font substitution rule](/slides/sv/net/font-substitution/).

## **Lägg till dina egna teckensnittsfiler**

Teckensnitt som distributionerna inte paketerar, såsom ditt organisations‑teckensnitt eller andra teckensnitt du har licens att använda på servern, kan läggas till som teckensnittsfiler. Placera teckensnittsfilerna, till exempel *.ttf*-filer, i en mapp med namn *fonts* inuti *FontCheck*-mappen. Exemplen nedan använder filerna för Carlito, ett teckensnitt med samma mått som Calibri, som du kan hämta från [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **Installera teckensnitten i en system‑teckensnittsmapp**

Aspose.Slides läser teckensnitten i mapparna som skrivs ut på raden `Font folders`. För att installera dina teckensnitt för varje applikation i bilden, kopiera dem till */usr/local/share/fonts*, mappen för lokalt installerade teckensnitt. Lägg till denna instruktion i runtime‑steget i *Dockerfile*, efter `RUN`‑instruktionen som installerar paketen:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

### **Ladda teckensnitt från applikationsmappen**

Istället för att installera teckensnitten i bilden kan du paketera dem med applikationen och ladda dem med [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/). Teckensnitten blir då bara tillgängliga för Aspose.Slides och distribueras tillsammans med applikationen. *FontCheck* gör så här: *FontCheck.csproj* kopierar *fonts*-mappen till applikationens utdata, och *Program.cs* passerar den mappen till `LoadExternalFonts` innan presentationen skapas. [Custom Font](/slides/sv/net/custom-font/) beskriver andra sätt att tillhandahålla teckensnitt, såsom att ladda dem från minnet.

Bygg om bilden, kör sedan kontrollen för Calibri och Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Applikationsmappen visas nu bland teckensnittsm mapparna, och Carlito ersätts inte längre:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

## **Ställ in ett standardteckensnitt för saknade teckensnitt**

När ett teckensnitt saknas använder Aspose.Slides ett ersättningsteckensnitt som den väljer själv. För att välja själv, ställ in egenskapen [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaultregularfont/) på [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) och skicka alternativen till [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)-konstruktorn. *FontCheck* läser teckensnittsnamnet från miljövariabeln `DEFAULT_FONT`. Med Carlito laddat, används det för saknade teckensnitt:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri ritas nu med Carlito, vars tecken har samma bredd som Calibri, så texten behåller sina radbrytningar:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Carlito
```

Standardteckensnittet ersätter varje saknat teckensnitt. För att mappa enskilda teckensnitt, till exempel Arial till Liberation Sans och Calibri till Carlito, använd [font substitution rules](/slides/sv/net/font-substitution/). Regler förändrar det renderade resultatet, men `GetSubstitutions` visar dem inte, så kontrollera teckensnitten i utdatafilen istället. För asiatisk text, ställ även in [DefaultAsianFont](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaultasianfont/); se [Default Font](/slides/sv/net/default-font/).

## **Installera teckensnitt på Alpine Linux**

På Alpine Linux använder du Aspose.Slides.NET‑paketet; [Run on Alpine Linux](/slides/sv/net/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) listar ändringarna i projektet. Gör samma ändringar i *FontCheck*: ersätt paketreferensen, lägg till `SetSwitch`‑satsen i *Program.cs* och använd detta runtime‑steg, som också installerar Microsoft‑kärnteckensnitten:

```dockerfile
FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk add --no-cache icu-libs libgdiplus font-dejavu msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

`update-ms-fonts` hämtar och installerar samma Microsoft‑kärnteckensnitt som Debian‑ och Ubuntu‑paketet, och deras EULA gäller på samma sätt. `fc-cache` uppdaterar teckensnittscachen.

Med Aspose.Slides.NET på Linux väljer fontconfig‑biblioteket ersättningen för ett saknat teckensnitt, och `GetSubstitutions` rapporterar det inte, så *FontCheck* skriver `No font substitutions.` För att se vilket teckensnitt som används för ett teckensnittsnamn, fråga fontconfig i containern:

```bash
docker run --rm --entrypoint fc-match font-check Arial
```

Med de Microsoft‑kärnteckensnitten installerade används Arial för Arial:

```text
Arial.ttf: "Arial" "Regular"
```

Utan dem, när `RUN`‑instruktionen bara installerar `icu-libs libgdiplus font-dejavu`, skriver samma kommando:

```text
DejaVuSans.ttf: "DejaVu Sans" "Book"
```

## **FAQ**

**Varför ser en presentation annorlunda ut när den konverteras på en server?**

Servern har inte de teckensnitt som presentationen använder, så Aspose.Slides ritar texten med ett ersättningsteckensnitt vars bokstäver har andra bredd. Kör *FontCheck* med presentationens teckensnittsnamn för att se vilka teckensnitt som ersätts, installera sedan dessa teckensnitt eller ladda dem från applikationsmappen.

**Byggprocessen installerade ttf‑mscorefonts‑installer, men Arial ersätts fortfarande. Varför?**

EULA accepterades inte innan paketet installerades, så installationsprogrammet hoppade över teckensnitten. Lägg till `debconf-set-selections`‑kommandot före `apt-get install`, som visas i [Microsoft Core Fonts](#microsoft-core-fonts), och bygg om bilden.

**Behöver datorn som öppnar PDF‑filen teckensnitten?**

Nej. I dessa exempel innehåller PDF‑filen de teckensnitt som användes för att rita texten, så den ser likadan ut på alla datorer. Teckensnitten behövs endast där Aspose.Slides renderar presentationen.