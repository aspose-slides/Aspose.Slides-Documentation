---
title: Aspose.Slides voor .NET uitvoeren in Docker
linktitle: Docker
type: docs
weight: 140
url: /nl/net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Docker container
- multi-stage build
- container image
- Linux
- Ubuntu
- Alpine
- libfontconfig
- libgdiplus
- lettertypen
- PDF conversie
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bouw en voer een Aspose.Slides voor .NET console‑applicatie uit in Docker: een multi‑stage Dockerfile op de officiële .NET‑images, de Linux‑bibliotheken en lettertypen die het nodig heeft, en hoe je de gegenereerde bestanden naar je machine kopieert."
---
## **Overzicht**

Dit artikel laat zien hoe je Aspose.Slides voor .NET in een Docker‑container kunt uitvoeren. Je bouwt een kleine console‑applicatie die een presentatie maakt met een tekstvak en deze naar PDF converteert, verpakt deze met een multistage Dockerfile op de officiële .NET‑images van Microsoft, draait hem, en kopieert de gegenereerde bestanden naar je machine. Het artikel somt ook de Linux‑bibliotheken en lettertypen op die Aspose.Slides in de container nodig heeft en eindigt met een variant voor Alpine Linux.

Je hebt alleen Docker op je machine nodig. De .NET‑SDK maakt deel uit van de build‑image, dus je hoeft die niet te installeren. Om Docker te installeren, zie [Docker installeren](https://docs.docker.com/get-started/get-docker/).

## **Kies het pakket en de basis‑image**

De standaard .NET 10‑container‑images zijn gebaseerd op Ubuntu 24.04. Op deze images gebruik je het [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)‑pakket. Het vereist de `fontconfig`‑bibliotheek, en de .NET‑runtime‑image bevat geen enkele van die bibliotheek of lettertypen, dus de Dockerfile in dit artikel installeert beide.

Aspose.Slides.NET6.CrossPlatform werkt niet op Alpine Linux. Voor op Alpine gebaseerde images gebruik je het [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/)‑pakket met `libgdiplus`, zoals beschreven in [Uitvoeren op Alpine Linux](#run-on-alpine-linux). [Installatie](/slides/nl/net/installation/) vergelijkt de twee pakketten.

## **Maak het project**

Maak een map met de naam *HelloSlidesDocker* en voeg de onderstaande drie bestanden toe.

*HelloSlidesDocker.csproj* beschrijft een console‑applicatie voor .NET 10, de versie van de container‑images die hieronder wordt gebruikt, en verwijst naar Aspose.Slides.NET6.CrossPlatform. Stel de pakketversie in op de nieuwste versie die op [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) staat.

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

*Program.cs* maakt een [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/), voegt een rechthoek met tekst toe aan de eerste dia, en slaat de presentatie twee keer op met de [Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/)‑methode: als PPTX en als PDF. Beide bestanden worden naar de *output*‑map onder de werkmap geschreven. De applicatie lijst vervolgens de lettertypen op die werden vervangen tijdens het renderen van de PDF, via [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/nl/net/aspose.slides/ifontsmanager/getsubstitutions/), zodat je kunt zien of de container de lettertypen heeft die de presentatie gebruikt.

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

*.dockerignore* houdt de *bin*‑ en *obj*‑mappen van een lokale build, en de output van eerdere runs, buiten de Docker‑build‑context, zodat de image alleen van de bronbestanden wordt opgebouwd.

```text
bin/
obj/
output/
```

## **Schrijf de Dockerfile**

Voeg een bestand met de naam *Dockerfile* toe aan dezelfde map:

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

Het bestand heeft twee fasen:

- **De build‑fase** start vanaf de .NET SDK‑image. Het kopieert eerst het project‑bestand en herstelt de NuGet‑pakketten, zodat Docker die laag hergebruikt zolang het project‑bestand niet verandert. Daarna kopieert het de broncode en publiceert de applicatie naar */app*.
- **De runtime‑fase** start vanaf de kleinere .NET runtime‑image, die geen SDK bevat, en kopieert alleen de gepubliceerde applicatie. Het installeert twee pakketten:
  - `libfontconfig1`: Aspose.Slides.NET6.CrossPlatform laadt deze bibliotheek bij opstarten. Zonder deze bibliotheek stopt de applicatie met een `DllNotFoundException` die `libfontconfig.so.1` aangeeft.
  - `fonts-dejavu-core`: de runtime‑image bevat geen lettertypen, en Aspose.Slides heeft minstens één geïnstalleerd lettertype nodig om tekst te tekenen; zonder enige stopt de conversie met `InvalidOperationException: Cannot find any fonts installed on the system.` Tekst in niet‑geïnstalleerde lettertypen wordt getekend met een vervangend lettertype. De DejaVu‑lettertypen vormen een kleine set die tekst kan renderen; om presentaties met de oorspronkelijke lettertypen weer te geven, zie [Lettertypen implementeren](/slides/nl/net/deploy-fonts/).

  `--no-install-recommends` en het verwijderen van de pakketlijsten houden de image klein. De laatste regels maken de *output*‑map aan, geven deze aan de niet‑root `app`‑gebruiker (gedefinieerd door de officiële .NET‑images; zijn gebruikers‑ID staat in de variabele `APP_UID`), en voeren de applicatie uit als die gebruiker.

Voor een ASP.NET Core‑applicatie start je de runtime‑fase vanaf `mcr.microsoft.com/dotnet/aspnet:10.0`. Deze is gebaseerd op dezelfde Ubuntu‑image, dus dezelfde pakketten zijn nodig.

## **Bouw en start de container**

Open een terminal in de map *HelloSlidesDocker*. Bouw de image en start vervolgens een container ervan:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

De eerste build downloadt de basis‑images en de NuGet‑pakketten, dus die duurt langer dan latere builds. De container voert de applicatie uit en stopt. Het geeft het volgende weer:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

De eerste regel toont aan dat de tekst Calibri gebruikt, het standaardlettertype van een nieuwe presentatie, en dat Calibri niet geïnstalleerd is in de image, zodat Aspose.Slides de tekst tekende met DejaVu Sans. De tekst in de PDF is echte, selecteerbare tekst in dat lettertype. Zonder licentie voegt Aspose.Slides ook een evaluatiewatermerk toe aan elke dia die wordt opgeslagen; zie [Licenties](/slides/nl/net/licensing/).

## **Kopieer de output naar je machine**

De bestanden staan in de map */app/output* van de gestopte container. Kopieer ze naar een *output*‑map op je machine en verwijder daarna de container:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Deze twee commando's werken op dezelfde manier in Bash, PowerShell en de Windows Command Prompt.

Op Linux kun je in plaats daarvan een map van je machine in de container mounten, zodat de applicatie de bestanden direct daarheen schrijft:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

De optie `--user` voert de applicatie uit met jouw gebruikers‑ en groeps‑ID’s, zodat hij kan schrijven naar de map die je hebt aangemaakt en de bestanden aan jou toebehoort. `--rm` verwijdert de container zodra deze stopt.

## **Uitvoeren op Alpine Linux**

Om de applicatie in een op Alpine gebaseerde image uit te voeren, schakel je over naar het Aspose.Slides.NET‑pakket en wijzig je de runtime‑fase. De build‑fase blijft hetzelfde.

1. In *HelloSlidesDocker.csproj* vervang je de pakket‑referentie:

   ```xml
   <PackageReference Include="Aspose.Slides.NET" Version="26.9.0" />
   ```

2. In *Program.cs* voeg je deze regel toe na de `using`‑directieven, vóór de eerste Aspose.Slides‑aanroep. Het schakelt de System.Drawing‑ondersteuning voor Linux in die Aspose.Slides.NET gebruikt:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

3. In *Dockerfile* vervang je de runtime‑fase (alles vanaf de tweede `FROM`‑regel) door:

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

De Alpine‑fase installeert drie pakketten en wijzigt één instelling:

- `libgdiplus` is de grafische bibliotheek die Aspose.Slides.NET op Linux gebruikt.
- `font-dejavu` levert lettertypen. Zonder enige lettertype stopt de conversie met `System.ArgumentException: Font '?' cannot be found`.
- `icu-libs` en `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false` leveren cultuurspecificaties. De Alpine‑.NET‑images draaien standaard in globalisatie‑invariante modus, en in die modus stopt Aspose.Slides met een `CultureNotFoundException` voor `en-US`.

Bouw, start en kopieer de output met dezelfde commando’s als hierboven. Op deze image geeft de applicatie alleen de `Saved`‑regel weer: met Aspose.Slides.NET op Linux kiest fontconfig een vervanging voor een missend lettertype, en [GetSubstitutions](https://reference.aspose.com/slides/nl/net/aspose.slides/ifontsmanager/getsubstitutions/) vermeldt deze niet. [Lettertypen implementeren](/slides/nl/net/deploy-fonts/) laat zien hoe je kunt controleren welk lettertype gebruikt wordt.

## **FAQ**

**De applicatie stopt met “Unable to load shared library 'libaspose.slides.drawing.capi…'”. Wat ontbreekt er?**

Op Ubuntu‑ en Debian‑images het `libfontconfig1`‑pakket; de melding noemt `libfontconfig.so.1` als het bestand dat niet geopend kon worden. Op Alpine Linux betekent de melding dat Aspose.Slides.NET6.CrossPlatform in gebruik is; schakel over naar Aspose.Slides.NET zoals beschreven in [Uitvoeren op Alpine Linux](#run-on-alpine-linux).

**Waarom is de tekst in de PDF in een ander lettertype dan in PowerPoint?**

De lettertypen die de presentatie gebruikt, zijn niet geïnstalleerd in de image, dus Aspose.Slides tekent de tekst met een vervangend lettertype. De output van de applicatie benoemt elk vervangen lettertype. [Lettertypen implementeren](/slides/nl/net/deploy-fonts/) legt uit hoe je lettertypen in de image kunt installeren of vanuit de applicatiemap kunt laden.

**Heb ik de .NET SDK op mijn machine nodig?**

Nee. De build‑fase compileert de applicatie binnen de SDK‑image. Je hebt de SDK alleen nodig als je de applicatie buiten Docker wilt bouwen en uitvoeren; zie [Installatie](/slides/nl/net/installation/).