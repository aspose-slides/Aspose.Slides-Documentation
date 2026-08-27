---
title: PowerPoint-presentaties converteren naar Markdown in .NET
linktitle: PowerPoint naar Markdown
type: docs
weight: 140
url: /nl/net/convert-powerpoint-to-markdown/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar MD
- presentatie naar MD
- dia naar MD
- PPT naar MD
- PPTX naar MD
- PowerPoint opslaan als Markdown
- presentatie opslaan als Markdown
- dia opslaan als Markdown
- PPT opslaan als MD
- PPTX opslaan als MD
- PPT exporteren naar MD
- PPTX exporteren naar MD
- Markdown afbeeldingsexport
- CDN-afbeeldingskoppelingen
- PowerPoint
- presentatie
- Markdown
- .NET
- C#
- Aspose.Slides
description: PPT- en PPTX-presentaties converteren naar Markdown in .NET en bepalen waar geëxporteerde bitmap-, metafile- en SVG-afbeeldingen worden opgeslagen en gerefereerd.
---
## **Overzicht**

Aspose.Slides for .NET kan PPT- en PPTX-presentaties converteren naar Markdown voor documentatie, statische sites, contentmigratie en versiebeheersprocessen. U kunt een Markdown-variant kiezen, bepalen hoe de inhoud van dia's wordt weergegeven, en beslissen waar geëxporteerde afbeeldingen worden opgeslagen en hoe de gegenereerde Markdown ernaar verwijst.

Standaard gebruikt de Markdown-export alleen tekstoutput. Om visuele inhoud te exporteren, stelt u de eigenschap [MarkdownSaveOptions.ExportType](https://reference.aspose.com/slides/nl/net/aspose.slides.export/markdownsaveoptions/exporttype/) in op de waarde `Sequential` of `Visual` uit de enumeratie [MarkdownExportType](https://reference.aspose.com/slides/nl/net/aspose.slides.export/markdownexporttype/). `Sequential` rendert dia‑onderdelen afzonderlijk en in volgorde, terwijl `Visual` gegroepeerde items samen houdt om hun visuele relatie te behouden. De waarde `TextOnly` genereert geen afbeeldingsbronnen, waardoor de image‑saving‑events niet worden aangeroepen in die modus.

## **Converteer een presentatie naar Markdown**

Laad het bronbestand met de klasse [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) en roep vervolgens de methode [Presentation.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/) aan met de `Md`‑waarde uit de enumeratie [SaveFormat](https://reference.aspose.com/slides/nl/net/aspose.slides.export/saveformat/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.md", SaveFormat.Md);
```

## **Selecteer een Markdown‑variant**

De eigenschap [MarkdownSaveOptions.Flavor](https://reference.aspose.com/slides/nl/net/aspose.slides.export/markdownsaveoptions/flavor/) bepaalt de Markdown‑specificatie die voor de uitvoer wordt gebruikt. De enumeratie [Flavor](https://reference.aspose.com/slides/nl/net/aspose.slides.export/flavor/) bevat CommonMark, GitHub Flavored Markdown en andere ondersteunde varianten.

Het volgende voorbeeld exporteert een presentatie als CommonMark:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    Flavor = Flavor.CommonMark
};

presentation.Save("presentation.md", SaveFormat.Md, options);
```

## **Exporteer afbeeldingen met het standaard lokaal‑opslaan‑gedrag**

De klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/markdownsaveoptions/) biedt twee eigenschappen voor lokaal opgeslagen afbeeldingen:

- [BasePath](https://reference.aspose.com/slides/nl/net/aspose.slides.export/markdownsaveoptions/basepath/) specificeert de basisdirectory voor het Markdown‑document en de eraan gekoppelde resources.
- [ImagesSaveFolderName](https://reference.aspose.com/slides/nl/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) specificeert de subdirectory voor afbeeldingen. De standaardwaarde is `Images`.

Het volgende voorbeeld rendert visuele inhoud, schrijft afbeeldingen naar `output/assets` en maakt relatieve afbeeldingsreferenties aan in het Markdown‑document:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "assets"
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

Dit gedrag dient ook als fallback wanneer een aangepaste image‑saving‑handler `false` retourneert.

## **Pas het opslaan van afbeeldingen en Markdown‑links aan**

Gebruik het event [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/nl/net/aspose.slides.export/markdownsaveoptions/imagesaving/) voor niet‑SVG bitmap‑ en metafile‑resources die tijdens de Markdown‑export worden gegenereerd. De delegate [MarkdownImageSavingHandler](https://reference.aspose.com/slides/nl/net/aspose.slides.export/markdownsaveoptions.markdownimagesavinghandler/) ontvangt het [IImage](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/)‑object, de bijbehorende [ImageFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/imageformat/) en de gegenereerde Markdown‑link als een `ref string`‑parameter. Sla de afbeelding op of upload deze met het opgegeven formaat, en vervang `link` door de referentie die in de Markdown‑output moet verschijnen.

Resources die in SVG‑formaat worden gegenereerd, worden apart behandeld. Abonneer u op het event [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/nl/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) waarvan de delegate [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/nl/net/aspose.slides.export/markdownsaveoptions.markdownsvgimagesavinghandler/) een [ISvgImage](https://reference.aspose.com/slides/nl/net/aspose.slides/isvgimage/)‑object en de `ref string link`‑parameter ontvangt. Een SVG heeft geen `ImageFormat`‑argument; schrijf of upload in plaats daarvan de XML‑gegevens vanuit de eigenschap [ISvgImage.SvgData](https://reference.aspose.com/slides/nl/net/aspose.slides/isvgimage/svgdata/). Afhankelijk van de exportmodus en visuele groepering kan een SVG in de bronpresentatie worden gerasterd of gecombineerd met andere inhoud; de resulterende niet‑SVG‑resource wordt vervolgens doorgegeven aan `ImageSaving`. Abonneer u op beide events wanneer elke geëxporteerde visuele resource aangepaste verwerking vereist.

De retourwaarde van de handler bepaalt wie de afbeelding verwerkt:

- Retourneer `true` nadat de handler de afbeelding heeft opgeslagen, geüpload, getransformeerd of anderszins verwerkt en een geldige waarde aan `link` heeft toegekend. Aspose.Slides schrijft die waarde naar het Markdown‑document en voert de standaard lokale opslag niet uit.
- Retourneer `false` om Aspose.Slides de afbeelding lokaal te laten opslaan en de link te genereren op basis van [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/nl/net/aspose.slides.export/markdownsaveoptions/basepath/) en [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/nl/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

{{% alert color="warning" title="Important" %}}
Een handler die `true` retourneert neemt de verantwoordelijkheid voor de afbeelding op zich. Als deze `true` retourneert zonder een geldige, niet‑lege link toe te kennen, mislukt de export met een `InvalidOperationException`.
{{% /alert %}}

### **Afbeeldingen opslaan in een CDN‑origin‑directory en externe URL’s gebruiken**

Het volgende voorbeeld behandelt `cdn-origin/presentations/quarterly-report` als een aangekoppelde of gesynchroniseerde CDN‑origin‑directory. Elke handler haalt de gegenereerde bestandsnaam op, slaat de afbeelding op in die aangepaste directory, en vervangt de gegenereerde lokale referentie door een openbare CDN‑URL. Het voorbeeld zelf voert geen netwerk‑upload uit: de URL wordt pas geldig nadat de directory is aangekoppeld als CDN‑origin of de bestanden zijn gepubliceerd naar het CDN. Voor objectopslag vervangt u het schrijven naar het bestandssysteem door de upload‑operatie van de storage‑SDK en kent u `link` pas toe nadat de upload geslaagd is.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
const string publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
var storageDirectory = Path.Combine("cdn-origin", "presentations", "quarterly-report");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(storageDirectory);

static string GetFileNameFromLink(string generatedLink)
{
    var urlCompatibleLink = generatedLink.Replace('\\', '/');
    return urlCompatibleLink[(urlCompatibleLink.LastIndexOf('/') + 1)..];
}

static string BuildPublicUrl(string baseUrl, string fileName)
{
    return $"{baseUrl}/{Uri.EscapeDataString(fileName)}";
}

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "fallback-images"
};

options.ImageSaving += (IImage image, ImageFormat format, ref string link) =>
{
    if (image.Width < 128 || image.Height < 128)
    {
        return false;
    }

    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    image.Save(storagePath, format);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

options.SvgImageSaving += (ISvgImage svgImage, ref string link) =>
{
    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    File.WriteAllBytes(storagePath, svgImage.SvgData);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

De bitmap‑handler retourneert opzettelijk `false` voor afbeeldingen kleiner dan 128 × 128 pixel, zodat Aspose.Slides die afbeeldingen opslaat in `output/fallback-images` met het standaardgedrag. Grotere bitmap‑ en metafile‑resources, evenals SVG‑resources, worden afgehandeld door de aangepaste code. Een gegenereerde lokale referentie zoals `fallback-images/image1.png` wordt bijvoorbeeld `https://cdn.example.com/presentations/quarterly-report/image1.png`. De handlers gebruiken alleen besturingssysteem‑paden bij het schrijven van bestanden; links die naar Markdown worden geschreven gebruiken schuine strepen en URL‑gecodeerde bestandsnamen. Pas dezelfde regel toe bij het opbouwen van relatieve links: gebruik `/`, niet de platform‑specifieke directory‑scheidingsteken.

## **FAQ**

**Kan één handler zowel raster‑afbeeldingen als SVG‑afbeeldingen verwerken?**

Nee. Gebruik [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/nl/net/aspose.slides.export/markdownsaveoptions/imagesaving/) voor gegenereerde bitmap‑ en metafile‑resources en [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/nl/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) voor resources die als SVG worden gegenereerd. Het eerste levert een [IImage](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/)‑object en een [ImageFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/imageformat/); het tweede levert een [ISvgImage](https://reference.aspose.com/slides/nl/net/aspose.slides/isvgimage/)‑object waarvan de SVG‑gegevens kunnen worden gelezen via [ISvgImage.SvgData](https://reference.aspose.com/slides/nl/net/aspose.slides/isvgimage/svgdata/). Een bron‑SVG die tijdens de export wordt gerasterd, wordt door `ImageSaving` verwerkt.

**Wat gebeurt er wanneer een image‑saving‑handler `false` retourneert?**

Aspose.Slides gebruikt zijn standaard lokaal‑opslaan‑gedrag. De locatie van de afbeelding en de gegenereerde referentie worden gecontroleerd door [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/nl/net/aspose.slides.export/markdownsaveoptions/basepath/) en [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/nl/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

**Kan een handler een URL leveren zonder de afbeelding lokaal op te slaan?**

Ja. De handler kan de afbeelding uploaden naar objectopslag of doorgeven aan een andere service, de resulterende URL toewijzen aan `link`, en `true` retourneren. De handler moet de verwerking zelf voltooien; retourneren van `true` verhindert de standaard lokale opslag.

**Waarom gooit de Markdown‑export een `InvalidOperationException` vanuit een handler?**

Deze uitzondering treedt op wanneer de handler `true` retourneert maar geen geldige link opgeeft. Ken het relatieve pad of de externe URL toe die in Markdown moet worden geschreven voordat u `true` retourneert.

**Welke pad‑scheidingsteken moeten afbeeldingslinks gebruiken?**

Gebruik schuine strepen (`/`) in Markdown‑links en URL’s. Gebruik `Path.Combine` alleen voor besturingssysteem‑paden, en bouw of normaliseer de Markdown‑referentie apart.

**Worden hyperlinks behouden tijdens de Markdown‑export?**

Ja. Tekst-[hyperlinks](/slides/nl/net/manage-hyperlinks/) blijven behouden als standaard Markdown‑links. Dia-[overgangen](/slides/nl/net/slide-transition/) en -[animaties](/slides/nl/net/powerpoint-animation/) worden niet geconverteerd.

**Kunnen presentaties parallel naar Markdown worden geconverteerd?**

U kunt verschillende presentatiebestanden parallel verwerken, maar deel dezelfde [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑instantie niet tussen threads. Volg de [multithreading‑richtlijnen](/slides/nl/net/multithreading/) en gebruik een aparte instantie voor elk bestand.