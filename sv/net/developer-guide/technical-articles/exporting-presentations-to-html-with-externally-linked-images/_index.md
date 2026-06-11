---
title: Exportera presentationer till HTML med externt länkade bilder
type: docs
weight: 100
url: /sv/net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- exportera PowerPoint
- exportera OpenDocument
- exportera presentation
- exportera bild
- exportera PPT
- exportera PPTX
- exportera ODP
- PowerPoint till HTML
- OpenDocument till HTML
- presentation till HTML
- bild till HTML
- PPT till HTML
- PPTX till HTML
- ODP till HTML
- länkad bild
- extern länkad bild
- länkad resurs
- extern resurs
- .NET
- C#
- Aspose.Slides
description: "Exportera PowerPoint- och OpenDocument-presentationer till HTML i .NET med Aspose.Slides, där bilder och andra resurser sparas som externa länkade filer."
---
## **Översikt**

Som standard exporterar Aspose.Slides en presentation till en fristående HTML‑fil. Bilder och andra resurser skrivs direkt in i HTML, vanligtvis som Base64‑data. Detta är praktiskt när du behöver en enda portabel fil, men det är inte alltid det bästa formatet för en webbplats, ett CMS eller en server‑sidig konverteringspipeline.

Använd externt länkade resurser när du vill:

- minska storleken på HTML‑dokumentet;
- cacha bilder, typsnitt, ljud eller video separat i en webbläsare eller CDN;
- inspektera, ersätta, komprimera eller efterbearbeta genererade resurser efter export;
- behålla output‑strukturen närmare vad en webbapplikation förväntar sig.

För den allmänna HTML‑konverteringsarbetsflödet, se [Konvertera PowerPoint-presentationer till HTML](/slides/sv/net/convert-powerpoint-to-html/). Denna artikel fokuserar på resurstillkopplingsdelen av exporten.

## **Hur export av länkade resurser fungerar**

[ILinkEmbedController](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ilinkembedcontroller/) låter din applikation bestämma, resurs för resurs, om exportören bäddar in data i HTML eller sparar den externt och skriver en länk.

Gränssnittet har tre metoder:

- [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) bestämmer om en resurs ska länkas eller bäddas in.
- [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ilinkembedcontroller/geturl/) returnerar URL‑en som kommer att skrivas till den genererade HTML‑en eller till en annan länkad resurs.
- [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) skriver den länkade resurssdata till disk eller till en annan lagringsdestination.

Filsystemssökvägen och webbläsar‑URL:en är separata frågor. Till exempel skriver exempelprogrammet nedan resursfiler till `html-output/assets` på disken, medan HTML‑en innehåller relativa URL:er såsom `assets/resource-1.svg`. En webbläsare löser dessa URL:er relativt till filen som innehåller länken. Därför använder en länk från `presentation.html` till en SVG‑fil `assets/resource-1.svg`, medan en länk från den SVG‑filen till en bild som sparats i samma `assets`‑mapp använder `resource-4.jpg`.

## **Exportera HTML med länkade resurser**

Följande C#‑exempel skapar en utdatamapp, sparar HTML‑filen där och lagrar länkade resurser i en `assets`‑undermapp. Kontrollen länkar vanliga bild-, typsnitts-, ljud‑, video‑ och CSS‑resurser när Aspose.Slides tillhandahåller eller kan sluta sig till en säker filändelse. Resurser som inte känns igen förblir inbäddade.

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

Efter exporten har utdatamappen följande struktur:

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

De exakta filerna beror på presentationens innehåll och exportalternativ. Till exempel exporteras rasterbilder vanligtvis som JPEG eller PNG. Aspose.Slides kan välja en annan bildcodec än den som används i källpresentationen när det ger en mindre eller mer lämplig fil. Bilder med transparens exporteras som PNG.

## **Välja URL:er för distribution**

Exempelprogrammet använder ett relativt URL‑prefix: `assets/`. Om `presentation.html` öppnas från `html-output/presentation.html` laddar webbläsaren `html-output/assets/resource-1.svg`.

När en länkad resurs refererar till en annan länkad resurs använder exempelprogrammet `referrer`‑parametern i [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ilinkembedcontroller/geturl/) och returnerar endast filnamnet. Till exempel, om `resource-1.svg` och `resource-4.jpg` båda ligger i `assets`‑mappen, bör SVG‑filen referera till `resource-4.jpg`, inte till `assets/resource-4.jpg`.

Använd ett annat URL‑prefix när filerna är distribuerade någon annanstans:

- Använd `assets/` när asset‑katalogen ligger bredvid HTML‑filen.
- Använd `../assets/` när asset‑katalogen är en nivå ovanför HTML‑filen.
- Använd `https://cdn.example.com/presentations/job-123/assets/` när filerna laddas upp till ett CDN eller en statisk filserver.

Den URL som returneras av [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ilinkembedcontroller/geturl/) måste matcha den slutgiltiga distribuerade platsen för filen som skrivs av [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ilinkembedcontroller/saveexternal/). I serverapplikationer, använd en unik utdatamapp eller objektslagrings‑prefix för varje konverteringsjobb för att undvika att skriva över filer från en annan export.

## **När man ska bädda in istället**

Inbäddad Base64‑HTML är fortfarande användbar när utdata måste vara en enda fil, till exempel ett e‑postbilaga, en offline‑förhandsgranskning eller ett dokument som kommer att flyttas utan en stödjande asset‑mapp. Länkade resurser är ett bättre alternativ när HTML kommer att levereras av en webbapplikation, lagras i ett CMS, optimeras av en byggpipeline eller cachas av webbläsare oberoende av HTML.

## **FAQ**

**Kan jag externalisera bara bilder och behålla andra resurser inbäddade?**

Ja. I [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) returnerar du `LinkEmbedDecision.Link` endast för de innehållstyper du vill spara som separata filer, och returnerar `LinkEmbedDecision.Embed` för allt annat.

**Varför skiljer sig den exporterade bildfilens filändelse från källpresentationen?**

Aspose.Slides kan omkoda rasterbilder under HTML‑export för att förbättra storlek eller webbläsarkompatibilitet. Till exempel kan en bild från källfilen skrivas som JPEG eller PNG beroende på det renderade resultatet.

**Fungerar relativa URL:er efter att jag har flyttat HTML‑filen?**

Relativa URL:er fungerar bara när samma relativa mappstruktur bevaras. Om HTML‑filen refererar till `assets/resource-1.png` måste `assets`‑mappen ligga bredvid HTML‑filen såvida du inte genererar ett annat URL‑prefix.

**Ska serverapplikationer återanvända samma utdatamapp?**

Nej. Använd en unik utdatamapp eller lagrings‑prefix för varje konverteringsjobb. Detta undviker filnamnskollisioner och förhindrar att en export skriver över resurser som genererats av en annan export.