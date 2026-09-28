---
title: Lettertypen implementeren voor Aspose.Slides op Linux en in Docker
linktitle: Lettertypen implementeren
type: docs
weight: 145
url: /nl/net/deploy-fonts/
keywords:
- lettertypen implementeren
- lettertypen installeren
- lettertypen in Docker
- lettertypen op Linux
- ontbrekende lettertypen
- lettertype‑vervanging
- Microsoft kernlettertypen
- ttf-mscorefonts-installer
- aangepaste lettertypen
- standaardlettertype
- server
- container
- PDF-conversie
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Lettertypen implementeren voor Aspose.Slides voor .NET op Linux‑servers en in Docker‑containers: controleer welke lettertypen worden vervangen, installeer lettertype‑pakketten op Debian, Ubuntu en Alpine, voeg uw eigen lettertype‑bestanden toe, en stel een standaardlettertype in."
---
## **Overzicht**

Aspose.Slides tekent tekst met de lettertypen die beschikbaar zijn wanneer het een presentatie rendert, bijvoorbeeld bij het converteren van dia’s naar PDF of naar afbeeldingen. Een Windows‑desktop heeft meestal de lettertypen die presentaties gebruiken. Linux‑servers en containers hebben doorgaans weinig of geen lettertypen, waardoor Aspose.Slides de tekst tekent met een vervangend lettertype. Een vervanger heeft andere lettervormen en -breedtes, waardoor regels anders kunnen worden afgebroken en tekst buiten de vorm kan overlopen, en tekens die de vervanger mist, worden niet correct getekend. Als er helemaal geen lettertype is geïnstalleerd, stopt de conversie met een fout.

Dit artikel laat zien hoe je kunt controleren welke lettertypen Aspose.Slides vervangt, hoe je lettertypen installeert op Debian, Ubuntu en Alpine Linux, hoe je je eigen lettertype‑bestanden toevoegt, en hoe je het lettertype instelt dat wordt gebruikt wanneer een lettertype ontbreekt. De voorbeelden draaien in Docker op de officiële .NET‑images, zoals in [Run Aspose.Slides for .NET in Docker](/slides/nl/net/how-to-run-aspose-slides-in-docker/). De pakket‑commando’s zijn Dockerfile‑instructies; op een Linux‑server voer je dezelfde commando’s als root uit.

Voor de lettertype‑API zelf, zoals het insluiten van lettertypen in een presentatie en fallback‑ en vervangingsregels, zie [PowerPoint Fonts](/slides/nl/net/powerpoint-fonts/).

## **Controleren welke lettertypen worden vervangen**

De volgende console‑applicatie meldt de lettertypen die Aspose.Slides in de huidige omgeving vervangt. Maak een map genaamd *FontCheck* en voeg de onderstaande bestanden toe.

*FontCheck.csproj* verwijst naar [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/), het pakket voor Debian en Ubuntu. Het kopieert ook de bestanden van een optionele *fonts*‑map naar de toepassingsoutput; de sectie [Load Fonts from the Application Folder](#load-fonts-from-the-application-folder) maakt hier gebruik van.

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

*Program.cs* voegt één tekstvak per lettertype‑naam toe aan een dia en wijst het lettertype toe via de [LatinFont](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/latinfont/)‑eigenschap. De lettertype‑namen komen van de opdrachtregel; zonder argumenten controleert de applicatie Calibri, Arial en Times New Roman. Het print de mappen waarin Aspose.Slides naar lettertypen zoekt ([FontsLoader.GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/)), rendert de dia naar *output/fonts.pdf*, en drukt de vervangingen af die gerapporteerd worden door [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/). De twee optionele stappen aan het begin, het laden van een *fonts*‑map en het lezen van een `DEFAULT_FONT`‑variabele, worden later in dit artikel uitgelegd.

```c#
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

// De te controleren lettertypen: de opdrachtregel‑argumenten, of drie veelgebruikte Office‑lettertypen.
var fontNames = args.Length > 0 ? args : new[] { "Calibri", "Arial", "Times New Roman" };

// Laad de lettertype‑bestanden uit de fonts‑map naast de applicatie, indien die er is.
var appFontFolder = Path.Combine(AppContext.BaseDirectory, "fonts");
if (Directory.Exists(appFontFolder))
{
    FontsLoader.LoadExternalFonts(new[] { appFontFolder });
}

// Gebruik het lettertype dat is opgegeven in de omgevingsvariabele DEFAULT_FONT, indien deze is ingesteld, voor tekst waarvan het lettertype ontbreekt.
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

*.dockerignore* houdt lokale bouwresultaten uit de build‑context:

```text
bin/
obj/
output/
```

*Dockerfile* bouwt de applicatie met de .NET SDK‑image en draait deze op de .NET runtime‑image. De runtime‑stage installeert `libfontconfig1`, wat Aspose.Slides.NET6.CrossPlatform vereist, en de DejaVu‑lettertypen. [Run Aspose.Slides for .NET in Docker](/slides/nl/net/how-to-run-aspose-slides-in-docker/) legt elke instructie uit.

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

Bouw de image en voer de controle uit:

```bash
docker build -t font-check .
docker run --rm font-check
```

De image bevat alleen de DejaVu‑lettertypen, dus alle drie de lettertypen worden vervangen door DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Om de lettertypen van je eigen presentaties te controleren, geef hun namen als argumenten mee, bijvoorbeeld `docker run --rm font-check "Segoe UI" Consolas`. Om *output/fonts.pdf* uit de container te kopiëren, gebruik je de commando’s in [Copy the Output to Your Machine](/slides/nl/net/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Lettertypen installeren op Debian en Ubuntu**

### **Microsoft Core Fonts**

Het pakket `ttf-mscorefonts-installer` downloadt en installeert Microsoft’s kernlettertypen voor het web, waaronder Arial, Times New Roman, Courier New, Verdana, Georgia en Trebuchet MS. De lettertypen zijn gelicentieerd onder Microsoft’s eind‑gebruikerslicentieovereenkomst (EULA), en het pakket installeert ze pas nadat de EULA is geaccepteerd. Een Docker‑build kan de prompt niet beantwoorden, dus wijst de installer de EULA af en installeert geen lettertypen, terwijl `apt-get install` toch succes rapporteert. Accepteer de EULA met `debconf-set-selections` **vóór** dat het pakket wordt geïnstalleerd.

In de *Dockerfile*, vervang de `RUN`‑instructie die de pakketten installeert in de runtime‑stage door:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Bouw de image en voer de controle opnieuw uit met dezelfde twee commando’s. Arial en Times New Roman zijn nu geïnstalleerd:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, het standaardlettertype van een presentatie die Aspose.Slides maakt, behoort niet tot de kernlettertypen, dus blijft het vervangen. Zie [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts).

Op Debian bevindt het pakket zich in de `contrib`‑repository‑component, die de Debian‑images niet activeren; de standaard .NET 8‑ en .NET 9‑images zijn gebaseerd op Debian 12. Schakel `contrib` in dezelfde instructie in:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

De op Ubuntu gebaseerde .NET 10‑images activeren reeds `multiverse`, de Ubuntu‑component die het pakket bevat.

### **Andere lettertype‑pakketten**

Debian en Ubuntu bieden ook vrij gelicentieerde lettertypen, bijvoorbeeld:

| Pakket | Lettertypen |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif en Mono, met dezelfde metriek als Arial, Times New Roman en Courier New |
| `fonts-crosextra-carlito` | Carlito, met dezelfde metriek als Calibri |
| `fonts-crosextra-caladea` | Caladea, met dezelfde metriek als Cambria |

Installeer ze met `apt-get install` in dezelfde `RUN`‑instructie. Aspose.Slides.NET6.CrossPlatform past de lettertype‑aliassen van de Linux‑lettertypeconfiguratie niet toe: zelfs met `fonts-liberation` geïnstalleerd, wordt tekst in Arial nog steeds getekend met het algemene vervangende lettertype, niet met Liberation Sans. Om een metriek‑compatibel lettertype te gebruiken in plaats van een ontbrekend lettertype, stel je het in als het [default font](#set-a-default-font-for-missing-fonts) of voeg je een [font substitution rule](/slides/nl/net/font-substitution/) toe.

## **Je eigen lettertype‑bestanden toevoegen**

Lettertypen die de distributies niet bundelen, zoals de lettertypen van je organisatie of andere lettertypen waarvoor je een licentie hebt op de server, kunnen als lettertype‑bestanden worden toegevoegd. Plaats de lettertype‑bestanden, bijvoorbeeld *.ttf*‑bestanden, in een map genaamd *fonts* binnen de *FontCheck*‑map. De voorbeelden hieronder gebruiken de bestanden van Carlito, een lettertype met dezelfde metriek als Calibri, dat je kunt downloaden van [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **Lettertypen installeren in een systeem‑lettertype‑map**

Aspose.Slides leest de lettertypen in de mappen die op de regel `Font folders` worden afgedrukt. Om je lettertypen voor elke applicatie in de image te installeren, kopieer je ze naar */usr/local/share/fonts*, de map voor lokaal geïnstalleerde lettertypen. Voeg deze instructie toe aan de runtime‑stage van de *Dockerfile*, na de `RUN`‑instructie die de pakketten installeert:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

### **Lettertypen laden vanuit de applicatie‑map**

In plaats van de lettertypen in de image te installeren, kun je ze met de applicatie meeleveren en laden met [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/). De lettertypen zijn dan alleen beschikbaar voor Aspose.Slides, en ze worden samen met de applicatie verspreid. *FontCheck* doet dit: *FontCheck.csproj* kopieert de *fonts*‑map naar de applicatie‑output, en *Program.cs* geeft die map door aan `LoadExternalFonts` voordat de presentatie wordt aangemaakt. [Custom Font](/slides/nl/net/custom-font/) beschrijft de andere manieren om lettertypen aan te leveren, zoals laden vanuit geheugen.

Herbouw de image, en controleer dan Calibri en Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

De applicatie‑map verschijnt nu tussen de lettertype‑mappen, en Carlito wordt niet meer vervangen:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

## **Standaardlettertype instellen voor ontbrekende lettertypen**

Wanneer een lettertype ontbreekt, gebruikt Aspose.Slides een vervanger die het zelf kiest. Om zelf een keuze te maken, stel je de eigenschap [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaultregularfont/) van [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) in en geef je de opties door aan de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑constructor. *FontCheck* leest de lettertype‑naam uit de omgeving‑variabele `DEFAULT_FONT`. Met Carlito geladen, gebruik je het voor ontbrekende lettertypen:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri wordt nu getekend met Carlito, waarvan de tekens dezelfde breedtes hebben als die van Calibri, zodat de tekst zijn regeleinden behoudt:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Carlito
```

Het standaardlettertype vervangt elk ontbrekend lettertype. Om individuele lettertypen in kaart te brengen, bijvoorbeeld Arial naar Liberation Sans en Calibri naar Carlito, gebruik je [font substitution rules](/slides/nl/net/font-substitution/). Regels wijzigen de gerenderde output, maar `GetSubstitutions` weerspiegelt ze niet, dus controleer de lettertypen in het uitvoerbestand. Voor Aziatische tekst stel je ook [DefaultAsianFont](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaultasianfont/) in; zie [Default Font](/slides/nl/net/default-font/).

## **Lettertypen installeren op Alpine Linux**

Op Alpine Linux gebruik je het Aspose.Slides.NET‑pakket; [Run on Alpine Linux](/slides/nl/net/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) beschrijft de wijzigingen voor het project. Breng dezelfde wijzigingen aan in *FontCheck*: vervang de pakket‑verwijzing, voeg de `SetSwitch`‑statement toe aan *Program.cs*, en gebruik deze runtime‑stage, die ook de Microsoft‑core‑lettertypen installeert:

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

`update-ms-fonts` downloadt en installeert dezelfde Microsoft‑core‑lettertypen als het Debian‑ en Ubuntu‑pakket, en hun EULA geldt op dezelfde manier. `fc-cache` werkt de lettertype‑cache bij.

Met Aspose.Slides.NET op Linux kiest de lettertype‑configuratie‑bibliotheek (fontconfig) de vervanger voor een ontbrekend lettertype, en `GetSubstitutions` rapporteert dit niet, dus *FontCheck* drukt `No font substitutions.` af. Om te zien welk lettertype wordt gebruikt voor een lettertype‑naam, vraag je fontconfig in de container:

```bash
docker run --rm --entrypoint fc-match font-check Arial
```

Met de Microsoft‑core‑lettertypen geïnstalleerd, wordt Arial gebruikt voor Arial:

```text
Arial.ttf: "Arial" "Regular"
```

Zonder deze lettertypen, wanneer de `RUN`‑instructie alleen `icu-libs libgdiplus font-dejavu` installeert, drukt hetzelfde commando het volgende af:

```text
DejaVuSans.ttf: "DejaVu Sans" "Book"
```

## **FAQ**

**Waarom ziet een presentatie er anders uit wanneer deze op een server wordt geconverteerd?**

De server beschikt niet over de lettertypen die de presentatie gebruikt, waardoor Aspose.Slides de tekst tekent met een vervangend lettertype waarvan de letters andere breedtes hebben. Voer *FontCheck* uit met de lettertype‑namen van de presentatie om te zien welke lettertypen worden vervangen, en installeer die lettertypen of laad ze vanuit de applicatie‑map.

**De build heeft ttf‑mscorefonts‑installer geïnstalleerd, maar Arial wordt nog steeds vervangen. Waarom?**

De EULA was niet geaccepteerd vóórdat het pakket werd geïnstalleerd, waardoor de installer de lettertypen oversloeg. Voeg het `debconf-set-selections`‑commando toe vóór `apt-get install`, zoals weergegeven in [Microsoft Core Fonts](#microsoft-core-fonts), en bouw de image opnieuw.

**Moet de computer die de PDF opent de lettertypen hebben?**

Nee. In deze voorbeelden bevat de PDF de lettertypen die gebruikt zijn om de tekst te tekenen, dus ziet hij er op elke computer hetzelfde uit. De lettertypen zijn alleen nodig op de plek waar Aspose.Slides de presentatie rendert.