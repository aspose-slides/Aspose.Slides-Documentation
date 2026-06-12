---
title: Presentaties exporteren naar HTML met extern gelinkte afbeeldingen
type: docs
weight: 100
url: /nl/net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint export
- OpenDocument export
- presentatie export
- dia export
- PPT export
- PPTX export
- ODP export
- PowerPoint naar HTML
- OpenDocument naar HTML
- presentatie naar HTML
- dia naar HTML
- PPT naar HTML
- PPTX naar HTML
- ODP naar HTML
- gelinkte afbeelding
- extern gelinkte afbeelding
- gelinkte resource
- externe resource
- .NET
- C#
- Aspose.Slides
description: Exporteer PowerPoint- en OpenDocument-presentaties naar HTML in .NET met Aspose.Slides, waarbij afbeeldingen en andere resources worden opgeslagen als extern gelinkte bestanden.
---
## **Overzicht**

Standaard exporteert Aspose.Slides een presentatie naar een zelfstandige HTML‑bestand. Afbeeldingen en andere resources worden direct in de HTML geschreven, meestal als Base64‑gegevens. Dit is handig wanneer u één draagbaar bestand nodig hebt, maar het is niet altijd het beste formaat voor een website, een CMS of een server‑side conversiepijplijn.

- de grootte van het HTML‑document verkleinen;
- afbeeldingen, lettertypen, audio of video apart cachen in een browser of CDN;
- gegenereerde resources na de export inspecteren, vervangen, comprimeren of post‑processen;
- de outputstructuur dichter bij wat een webapplicatie verwacht houden.

Voor de algemene HTML‑conversieworkflow, zie [Convert PowerPoint Presentations to HTML](/slides/nl/net/convert-powerpoint-to-html/). Dit artikel richt zich op het resource‑linkgedeelte van de export.

## **Hoe gelinkte resource‑export werkt**

[ILinkEmbedController](https://reference.aspose.com/slides/nl/net/aspose.slides.export/ilinkembedcontroller/) laat uw applicatie per resource bepalen of de exporter de gegevens in de HTML insluit of extern opslaat en een link schrijft.

De interface heeft drie methoden:

- [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/nl/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) bepaalt of een resource gelinkt of ingebed moet worden.
- [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/nl/net/aspose.slides.export/ilinkembedcontroller/geturl/) geeft de URL terug die in de gegenereerde HTML of in een andere gelinkte resource wordt geschreven.
- [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/nl/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) schrijft de gelinkte resource‑gegevens naar de schijf of naar een ander opslagdoel.

Het bestandssysteempad en de browser‑URL zijn afzonderlijke zaken. Bijvoorbeeld, het voorbeeld hieronder schrijft resource‑bestanden naar `html-output/assets` op de schijf, terwijl de HTML relatieve URL’s bevat zoals `assets/resource-1.svg`. Een browser lost die URL’s op relatief ten opzichte van het bestand dat de link bevat. Daarom gebruikt een link van `presentation.html` naar een SVG‑bestand `assets/resource-1.svg`, terwijl een link vanuit dat SVG‑bestand naar een afbeelding die in dezelfde `assets`‑map staat `resource-4.jpg` gebruikt.

## **HTML exporteren met gelinkte resources**

Het volgende C#‑voorbeeld maakt een uitvoermap aan, slaat het HTML‑bestand daar op en bewaart gelinkte resources in een `assets`‑submap. De controller linkt veelvoorkomende afbeelding-, lettertype-, audio-, video- en CSS‑resources wanneer Aspose.Slides een veilig bestandsextensie levert of kan afleiden. Resources die niet herkend worden, blijven ingebed.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using System;
using System.Collections.Generic;
using System.IO;

var inputFilePath = "presentation.pptx";
var outputDirectory = "html-output";
var assetDirectoryName = "assets";
var assetDirectory = Path.Combine(outputDirectory, assetDirectoryName);

Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(assetDirectory);

var assetUrlPrefix = assetDirectoryName + "/";
var controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(string.Empty, false),
    SlideImageFormat = slideImageFormat
};

using var presentation = new Presentation(inputFilePath);

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);

public sealed class ExternalResourceController : ILinkEmbedController
{
    private static readonly Dictionary<string, string> ExtensionsByContentType = new(StringComparer.OrdinalIgnoreCase)
    {
        ["image/jpeg"] = ".jpg",
        ["image/png"] = ".png",
        ["image/gif"] = ".gif",
        ["image/bmp"] = ".bmp",
        ["image/svg+xml"] = ".svg",
        ["image/tiff"] = ".tiff",
        ["image/x-emf"] = ".emf",
        ["image/x-wmf"] = ".wmf",
        ["font/woff"] = ".woff",
        ["font/woff2"] = ".woff2",
        ["font/ttf"] = ".ttf",
        ["application/font-woff"] = ".woff",
        ["application/vnd.ms-fontobject"] = ".eot",
        ["application/x-font-ttf"] = ".ttf",
        ["text/css"] = ".css",
        ["audio/mpeg"] = ".mp3",
        ["audio/mp4"] = ".m4a",
        ["audio/wav"] = ".wav",
        ["video/mp4"] = ".mp4",
        ["video/webm"] = ".webm"
    };

    private readonly string assetDirectory;
    private readonly string assetUrlPrefix;
    private readonly Dictionary<int, string> fileNamesByResourceId = new();

    public ExternalResourceController(string assetDirectory, string assetUrlPrefix)
    {
        if (string.IsNullOrWhiteSpace(assetDirectory))
        {
            throw new ArgumentException("The asset output directory must not be empty.", nameof(assetDirectory));
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = NormalizeUrlPrefix(assetUrlPrefix);
    }

    public LinkEmbedDecision GetObjectStoringLocation(
        int resourceId,
        byte[] entityData,
        string semanticName,
        string contentType,
        string recommendedExtension)
    {
        var extension = ResolveExtension(contentType, recommendedExtension);
        if (extension == null)
        {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId[resourceId] = $"resource-{resourceId}{extension}";
        return LinkEmbedDecision.Link;
    }

    public string GetUrl(int resourceId, int referrer)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            return null;
        }

        if (fileNamesByResourceId.ContainsKey(referrer))
        {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    public void SaveExternal(int resourceId, byte[] entityData)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} was not registered for external storage.");
        }

        if (entityData == null || entityData.Length == 0)
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} contains no data and cannot be saved.");
        }

        Directory.CreateDirectory(assetDirectory);

        var filePath = Path.Combine(assetDirectory, fileName);
        File.WriteAllBytes(filePath, entityData);
    }

    private static string ResolveExtension(string contentType, string recommendedExtension)
    {
        if (!string.IsNullOrWhiteSpace(contentType) &&
            ExtensionsByContentType.TryGetValue(contentType, out var mappedExtension))
        {
            return mappedExtension;
        }

        if (!IsSupportedContentType(contentType))
        {
            return null;
        }

        return NormalizeExtension(recommendedExtension);
    }

    private static bool IsSupportedContentType(string contentType)
    {
        return contentType != null &&
            (contentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("font/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("audio/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("video/", StringComparison.OrdinalIgnoreCase));
    }

    private static string NormalizeExtension(string extension)
    {
        if (string.IsNullOrWhiteSpace(extension))
        {
            return null;
        }

        var extensionCharacters = extension.Trim().TrimStart('.');
        foreach (var character in extensionCharacters)
        {
            if (!char.IsLetterOrDigit(character))
            {
                return null;
            }
        }

        return "." + extensionCharacters.ToLowerInvariant();
    }

    private static string NormalizeUrlPrefix(string urlPrefix)
    {
        if (string.IsNullOrEmpty(urlPrefix))
        {
            return string.Empty;
        }

        var normalizedUrlPrefix = urlPrefix.Replace('\\', '/');
        return normalizedUrlPrefix.EndsWith("/")
            ? normalizedUrlPrefix
            : normalizedUrlPrefix + "/";
    }
}
```

Na de export heeft de uitvoermap deze structuur:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

De exacte bestanden hangen af van de inhoud van de presentatie en de exportopties. Rasterafbeeldingen worden bijvoorbeeld vaak geëxporteerd als JPEG of PNG. Aspose.Slides kan een andere afbeeldingscodec kiezen dan die in de bronpresentatie wordt gebruikt wanneer dat een kleiner of geschikter bestand oplevert. Afbeeldingen met transparantie worden geëxporteerd als PNG.

## **URL‑s kiezen voor implementatie**

Het voorbeeld gebruikt een relatieve URL‑prefix: `assets/`. Als `presentation.html` wordt geopend vanuit `html-output/presentation.html`, laadt de browser `html-output/assets/resource-1.svg`.

Wanneer een gelinkte resource naar een andere gelinkte resource verwijst, gebruikt het voorbeeld de `referrer`‑parameter in [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/nl/net/aspose.slides.export/ilinkembedcontroller/geturl/) en geeft alleen de bestandsnaam terug. Bijvoorbeeld, als `resource-1.svg` en `resource-4.jpg` beide in de `assets`‑map staan, moet het SVG‑bestand verwijzen naar `resource-4.jpg` en niet naar `assets/resource-4.jpg`.

Gebruik een andere URL‑prefix wanneer de bestanden elders worden geïmplementeerd:

- Gebruik `assets/` wanneer de asset‑map naast het HTML‑bestand staat.
- Gebruik `../assets/` wanneer de asset‑map één niveau boven het HTML‑bestand staat.
- Gebruik `https://cdn.example.com/presentations/job-123/assets/` wanneer de bestanden geüpload worden naar een CDN of statische bestandsserver.

De URL die wordt geretourneerd door [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/nl/net/aspose.slides.export/ilinkembedcontroller/geturl/) moet overeenkomen met de uiteindelijke implementatielocatie van het bestand dat geschreven wordt door [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/nl/net/aspose.slides.export/ilinkembedcontroller/saveexternal/). In server‑applicaties moet u voor elke conversietaak een unieke uitvoermap of object‑storage‑prefix gebruiken om overschrijven van bestanden van een andere export te voorkomen.

## **Wanneer in plaats daarvan embedden**

Ingebedde Base64‑HTML blijft nuttig wanneer de output één enkel bestand moet zijn, bijvoorbeeld als e‑mailbijlage, offline preview of een document dat wordt verplaatst zonder een bijbehorende asset‑map. Gelinkte resources passen beter wanneer de HTML wordt bediend door een webapplicatie, opgeslagen in een CMS, geoptimaliseerd door een build‑pipeline, of door browsers onafhankelijk van de HTML wordt gecached.

## **FAQ**

**Kan ik alleen afbeeldingen externaliseren en andere resources ingebed houden?**

Ja. In [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/nl/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) retourneert u `LinkEmbedDecision.Link` alleen voor de content‑types die u als afzonderlijke bestanden wilt opslaan, en retourneert u `LinkEmbedDecision.Embed` voor alles andere.

**Waarom verschilt de geëxporteerde afbeeldingsextensie van die in de bronpresentatie?**

Aspose.Slides kan rasterafbeeldingen tijdens de HTML‑export opnieuw encoderen om de grootte te verkleinen of de browsercompatibiliteit te verbeteren. Bijvoorbeeld, een afbeelding uit het bronbestand kan worden weggeschreven als JPEG of PNG, afhankelijk van het gerenderde resultaat.

**Werken relatieve URL’s nadat ik het HTML‑bestand verplaats?**

Relatieve URL’s werken alleen wanneer dezelfde relatieve mapstructuur behouden blijft. Als de HTML verwijst naar `assets/resource-1.png`, moet de `assets`‑map naast het HTML‑bestand blijven, tenzij u een andere URL‑prefix genereert.

**Moeten servertoepassingen dezelfde uitvoermap hergebruiken?**

Nee. Gebruik voor elke conversietaak een unieke uitvoermap of opslag‑prefix. Dit voorkomt bestandsnaamconflicten en voorkomt dat één export de door een andere export gegenereerde resources overschrijft.