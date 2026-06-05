---
title: Präsentationen mit extern verknüpften Bildern nach HTML exportieren
type: docs
weight: 100
url: /de/net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint exportieren
- OpenDocument exportieren
- Präsentation exportieren
- Folie exportieren
- PPT exportieren
- PPTX exportieren
- ODP exportieren
- PowerPoint nach HTML
- OpenDocument nach HTML
- Präsentation nach HTML
- Folie nach HTML
- PPT nach HTML
- PPTX nach HTML
- ODP nach HTML
- verknüpftes Bild
- extern verknüpftes Bild
- verknüpfte Ressource
- externe Ressource
- .NET
- C#
- Aspose.Slides
description: "Exportieren Sie PowerPoint- und OpenDocument-Präsentationen nach HTML in .NET mit Aspose.Slides, wobei Bilder und andere Ressourcen als extern verknüpfte Dateien gespeichert werden."
---
## **Übersicht**

Standardmäßig exportiert Aspose.Slides eine Präsentation in eine eigenständige HTML‑Datei. Bilder und andere Ressourcen werden direkt in das HTML geschrieben, meist als Base64‑Daten. Das ist praktisch, wenn Sie eine portable Datei benötigen, ist aber nicht immer das beste Format für eine Website, ein CMS oder eine serverseitige Konvertierungspipeline.

Verwenden Sie extern verknüpfte Ressourcen, wenn Sie:

- die Größe des HTML‑Dokuments reduzieren möchten;
- Bilder, Schriftarten, Audio oder Video separat in einem Browser oder CDN cachen möchten;
- generierte Ressourcen nach dem Export inspizieren, ersetzen, komprimieren oder nachbearbeiten wollen;
- die Ausgabestruktur näher an das halten möchten, was eine Webanwendung erwartet.

Für den allgemeinen HTML‑Konvertierungs‑Workflow siehe [PowerPoint-Präsentationen in HTML konvertieren](/slides/de/net/convert-powerpoint-to-html/). Dieser Artikel konzentriert sich auf den Teil des Exports, der das Verknüpfen von Ressourcen behandelt.

## **Wie der Export verknüpfter Ressourcen funktioniert**

[ILinkEmbedController](https://reference.aspose.com/slides/de/net/aspose.slides.export/ilinkembedcontroller/) lässt Ihre Anwendung für jede Ressource entscheiden, ob der Exporteur die Daten in das HTML einbettet oder sie extern speichert und einen Link schreibt.

Die Schnittstelle hat drei Methoden:

- [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/de/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) entscheidet, ob eine Ressource verknüpft oder eingebettet werden soll.
- [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/de/net/aspose.slides.export/ilinkembedcontroller/geturl/) liefert die URL, die in das erzeugte HTML oder zu einer anderen verknüpften Ressource geschrieben wird.
- [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/de/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) schreibt die verknüpften Ressourcendaten auf die Festplatte oder ein anderes Ziel.

Dateisystempfad und Browser‑URL sind separate Anliegen. Beispiel: Das folgende Beispiel schreibt Ressourcendateien auf die Festplatte nach `html-output/assets`, während das HTML relative URLs wie `assets/resource-1.svg` enthält. Ein Browser löst diese URLs relativ zur Datei auf, die den Link enthält. Daher verwendet ein Link von `presentation.html` zu einer SVG‑Datei `assets/resource-1.svg`, während ein Link von dieser SVG‑Datei zu einem Bild im selben `assets`‑Ordner `resource-4.jpg` lautet.

## **HTML mit verknüpften Ressourcen exportieren**

Das folgende C#‑Beispiel erzeugt ein Ausgabeverzeichnis, speichert die HTML‑Datei dort und legt verknüpfte Ressourcen in einem Unterordner `assets` ab. Der Controller verknüpft gängige Bild‑, Schrift‑, Audio‑, Video‑ und CSS‑Ressourcen, wenn Aspose.Slides eine sichere Dateierweiterung bereitstellt oder ableiten kann. Nicht erkannte Ressourcen bleiben eingebettet.

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

Nach dem Export hat der Ausgabordner folgende Struktur:

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

Die genauen Dateien hängen vom Inhalt der Präsentation und den Exportoptionen ab. Rasterbilder werden beispielsweise häufig als JPEG oder PNG exportiert. Aspose.Slides kann einen anderen Bild‑Codec wählen als im Quell‑Presentation verwendet, wenn das zu einer kleineren oder besser geeigneten Datei führt. Bilder mit Transparenz werden als PNG exportiert.

## **Auswahl von URLs für die Bereitstellung**

Das Beispiel verwendet ein relatives URL‑Präfix: `assets/`. Wenn `presentation.html` aus `html-output/presentation.html` geöffnet wird, lädt der Browser `html-output/assets/resource-1.svg`.

Wenn eine verknüpfte Ressource auf eine andere verknüpfte Ressource verweist, nutzt das Beispiel den Parameter `referrer` in [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/de/net/aspose.slides.export/ilinkembedcontroller/geturl/) und gibt nur den Dateinamen zurück. Beispielsweise sollte die SVG‑Datei `resource-1.svg`, die sich im Ordner `assets` befindet, auf `resource-4.jpg` verweisen und nicht auf `assets/resource-4.jpg`.

Verwenden Sie ein anderes URL‑Präfix, wenn die Dateien woanders bereitgestellt werden:

- `assets/` verwenden, wenn das Asset‑Verzeichnis neben der HTML‑Datei liegt.
- `../assets/` verwenden, wenn das Asset‑Verzeichnis eine Ebene über der HTML‑Datei liegt.
- `https://cdn.example.com/presentations/job-123/assets/` verwenden, wenn die Dateien in ein CDN oder einen statischen Dateiserver hochgeladen werden.

Die von [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/de/net/aspose.slides.export/ilinkembedcontroller/geturl/) zurückgegebene URL muss mit dem finalen Bereitstellungsort der von [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/de/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) geschriebenen Datei übereinstimmen. In Server‑Anwendungen sollten Sie für jeden Konvertierungsauftrag ein eindeutiges Ausgabeverzeichnis oder ein eindeutiges Objekt‑Speicher‑Präfix verwenden, um ein Überschreiben von Dateien aus anderen Exporten zu vermeiden.

## **Wann stattdessen einbetten**

Eingebettetes Base64‑HTML ist weiterhin nützlich, wenn die Ausgabe eine einzelne Datei sein muss, etwa als E‑Mail‑Anhang, Offline‑Vorschau oder Dokument, das ohne zugehörigen Asset‑Ordner verschoben wird. Verknüpfte Ressourcen eignen sich besser, wenn das HTML von einer Webanwendung bereitgestellt, in einem CMS gespeichert, durch eine Build‑Pipeline optimiert oder von Browsern unabhängig vom HTML gecached wird.

## **FAQ**

**Kann ich nur Bilder auslagern und andere Ressourcen eingebettet lassen?**

Ja. In [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/de/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) geben Sie `LinkEmbedDecision.Link` nur für die Inhaltstypen zurück, die Sie als separate Dateien speichern möchten, und `LinkEmbedDecision.Embed` für alles andere.

**Warum unterscheidet sich die exportierte Bild‑Erweiterung von der im Quell‑Presentation?**

Aspose.Slides kann Rasterbilder beim HTML‑Export neu enkodieren, um Größe oder Browser‑Kompatibilität zu verbessern. Ein Bild aus der Quelldatei kann je nach Ergebnis als JPEG oder PNG geschrieben werden.

**Funktionieren relative URLs, wenn ich die HTML‑Datei verschiebe?**

Relative URLs funktionieren nur, wenn die gleiche relative Ordnerstruktur erhalten bleibt. Wenn das HTML `assets/resource-1.png` referenziert, muss der Ordner `assets` neben der HTML‑Datei bleiben, es sei denn, Sie erzeugen ein anderes URL‑Präfix.

**Sollten Server‑Anwendungen denselben Ausgabordner wiederverwenden?**

Nein. Verwenden Sie für jeden Konvertierungsauftrag ein eindeutiges Ausgabeverzeichnis oder Speicher‑Präfix. So vermeiden Sie Namenskonflikte und ein Überschreiben von Ressourcen, die von einem anderen Export erzeugt wurden.