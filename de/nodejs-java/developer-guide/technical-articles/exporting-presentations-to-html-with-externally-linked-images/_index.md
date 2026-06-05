---
title: Präsentationen mit extern verlinkten Bildern nach HTML exportieren
type: docs
weight: 100
url: /de/nodejs-java/exporting-presentations-to-html-with-externally-linked-images/
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
- JavaScript
- Node.js
- Aspose.Slides
description: "Exportieren Sie PowerPoint- und OpenDocument-Präsentationen nach HTML in JavaScript mit Aspose.Slides für Node.js via Java, wobei Bilder und andere Ressourcen als extern verknüpfte Dateien gespeichert werden."
---
## **Übersicht**

Standardmäßig exportiert Aspose.Slides eine Präsentation in eine eigenständige HTML‑Datei. Bilder und andere Ressourcen werden direkt in das HTML geschrieben, in der Regel als Base64‑Daten. Das ist praktisch, wenn Sie eine einzige portable Datei benötigen, ist jedoch nicht immer das beste Format für eine Website, ein CMS oder eine serverseitige Konvertierungspipeline.

Verwenden Sie extern verknüpfte Ressourcen, wenn Sie:
- die Größe des HTML‑Dokuments reduzieren;
- Bilder, Schriften, Audio‑ oder Videodateien getrennt in einem Browser oder CDN zwischenspeichern;
- generierte Ressourcen nach dem Export überprüfen, ersetzen, komprimieren oder nachbearbeiten;
- die Ausgabestruktur näher an das halten, was eine Webanwendung erwartet.

Für den allgemeinen HTML‑Konvertierungs‑Workflow siehe [PowerPoint-Präsentationen in HTML konvertieren](/slides/de/nodejs-java/convert-powerpoint-to-html/). Dieser Artikel konzentriert sich auf den Teil des Exports, bei dem Ressourcen verlinkt werden.

## **Wie der Export verknüpfter Ressourcen funktioniert**

Ein Java‑Proxy für [ILinkEmbedController](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilinkembedcontroller/) ermöglicht Ihrer Anwendung, ressourcenweise zu entscheiden, ob der Exporteur die Daten in das HTML einbettet oder sie extern speichert und einen Link schreibt.

Der Controller verfügt über drei Methoden:
- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilinkembedcontroller/) entscheidet, ob eine Ressource verlinkt oder eingebettet werden soll.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilinkembedcontroller/) gibt die URL zurück, die in das erzeugte HTML oder in eine andere verknüpfte Ressource geschrieben wird.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilinkembedcontroller/) schreibt die verknüpften Ressourcendaten auf die Festplatte oder in ein anderes Speicherziel.

Der Dateisystempfad und die Browser‑URL sind separate Aspekte. Zum Beispiel schreibt das nachfolgende Beispiel Ressourcendateien nach `html-output/assets` auf die Festplatte, während das HTML relative URLs wie `assets/resource-1.svg` enthält. Ein Browser löst diese URLs relativ zu der Datei auf, die den Link enthält. Daher verwendet ein Link von `presentation.html` zu einer SVG‑Datei `assets/resource-1.svg`, während ein Link von dieser SVG‑Datei zu einem Bild, das im selben `assets`‑Ordner gespeichert ist, `resource-4.jpg` verwendet.

## **HTML mit verknüpften Ressourcen exportieren**

Das folgende JavaScript‑Beispiel erstellt ein Ausgabeverzeichnis, speichert die HTML‑Datei dort und legt verknüpfte Ressourcen in einem Unterverzeichnis `assets` ab. Der Controller verlinkt gängige Bild‑, Schrift‑, Audio‑, Video‑ und CSS‑Ressourcen, wenn Aspose.Slides eine sichere Dateierweiterung bereitstellt oder ableiten kann. Nicht erkannte Ressourcen bleiben eingebettet.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

class ExternalResourceController {
    constructor(assetDirectory, assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().length === 0) {
            throw new Error("The asset output directory must not be empty.");
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
        this.fileNamesByResourceId = new Map();
    }

    createProxy() {
        const linkEmbedControllerInterfaceName = "com.aspose.slides.ILinkEmbedController";
        let controller = this;
        return java.newProxy(linkEmbedControllerInterfaceName, {
            getObjectStoringLocation: function(resourceId, entityData, semanticName, contentType, recommendedExtension) {
                return controller.getObjectStoringLocation(
                    resourceId,
                    entityData,
                    semanticName,
                    contentType,
                    recommendedExtension);
            },
            getUrl: function(resourceId, referrer) {
                return controller.getUrl(resourceId, referrer);
            },
            saveExternal: function(resourceId, entityData) {
                controller.saveExternal(resourceId, entityData);
            }
        });
    }

    getObjectStoringLocation(resourceId, entityData, semanticName, contentType, recommendedExtension) {
        let extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return aspose.slides.LinkEmbedDecision.Embed;
        }

        this.fileNamesByResourceId.set(resourceId, "resource-" + resourceId + extension);
        return aspose.slides.LinkEmbedDecision.Link;
    }

    getUrl(resourceId, referrer) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (this.fileNamesByResourceId.has(referrer)) {
            return fileName;
        }

        return this.assetUrlPrefix + fileName;
    }

    saveExternal(resourceId, entityData) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new Error("Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length === 0) {
            throw new Error("Resource " + resourceId + " contains no data and cannot be saved.");
        }

        fs.mkdirSync(this.assetDirectory, { recursive: true });

        let filePath = path.join(this.assetDirectory, fileName);
        let fileData = Buffer.from(entityData);
        fs.writeFileSync(filePath, fileData);
    }
}

function createExtensionsByContentType() {
    let extensionsByContentType = new Map();
    extensionsByContentType.set("image/jpeg", ".jpg");
    extensionsByContentType.set("image/png", ".png");
    extensionsByContentType.set("image/gif", ".gif");
    extensionsByContentType.set("image/bmp", ".bmp");
    extensionsByContentType.set("image/svg+xml", ".svg");
    extensionsByContentType.set("image/tiff", ".tiff");
    extensionsByContentType.set("image/x-emf", ".emf");
    extensionsByContentType.set("image/x-wmf", ".wmf");
    extensionsByContentType.set("font/woff", ".woff");
    extensionsByContentType.set("font/woff2", ".woff2");
    extensionsByContentType.set("font/ttf", ".ttf");
    extensionsByContentType.set("application/font-woff", ".woff");
    extensionsByContentType.set("application/vnd.ms-fontobject", ".eot");
    extensionsByContentType.set("application/x-font-ttf", ".ttf");
    extensionsByContentType.set("text/css", ".css");
    extensionsByContentType.set("audio/mpeg", ".mp3");
    extensionsByContentType.set("audio/mp4", ".m4a");
    extensionsByContentType.set("audio/wav", ".wav");
    extensionsByContentType.set("video/mp4", ".mp4");
    extensionsByContentType.set("video/webm", ".webm");
    return extensionsByContentType;
}

let extensionsByContentType = createExtensionsByContentType();

function resolveExtension(contentType, recommendedExtension) {
    if (contentType != null && contentType.trim().length > 0) {
        let mappedExtension = extensionsByContentType.get(contentType);
        if (mappedExtension != null) {
            return mappedExtension;
        }
    }

    if (!isSupportedContentType(contentType)) {
        return null;
    }

    return normalizeExtension(recommendedExtension);
}

function isSupportedContentType(contentType) {
    if (contentType == null) {
        return false;
    }

    let normalizedContentType = contentType.toLowerCase();
    return normalizedContentType.startsWith("image/") ||
        normalizedContentType.startsWith("font/") ||
        normalizedContentType.startsWith("audio/") ||
        normalizedContentType.startsWith("video/");
}

function normalizeExtension(extension) {
    if (extension == null || extension.trim().length === 0) {
        return null;
    }

    let extensionCharacters = extension.trim();
    while (extensionCharacters.startsWith(".")) {
        extensionCharacters = extensionCharacters.substring(1);
    }

    if (extensionCharacters.length === 0) {
        return null;
    }

    for (let index = 0; index < extensionCharacters.length; index++) {
        let character = extensionCharacters[index];
        if (!/[A-Za-z0-9]/.test(character)) {
            return null;
        }
    }

    return "." + extensionCharacters.toLowerCase();
}

function normalizeUrlPrefix(urlPrefix) {
    if (urlPrefix == null || urlPrefix.length === 0) {
        return "";
    }

    let normalizedUrlPrefix = urlPrefix.replace(/\\/g, "/");
    return normalizedUrlPrefix.endsWith("/")
        ? normalizedUrlPrefix
        : normalizedUrlPrefix + "/";
}

let inputFilePath = "presentation.pptx";
let outputDirectory = "html-output";
let assetDirectoryName = "assets";
let assetDirectory = path.join(outputDirectory, assetDirectoryName);

fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(assetDirectory, { recursive: true });

let assetUrlPrefix = assetDirectoryName + "/";
let controllerWrapper = new ExternalResourceController(assetDirectory, assetUrlPrefix);
let controller = controllerWrapper.createProxy();
let svgOptions = new aspose.slides.SVGOptions(controller);
let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

let htmlOptions = new aspose.slides.HtmlOptions(controller);
htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
htmlOptions.setSlideImageFormat(slideImageFormat);

let presentation = new aspose.slides.Presentation(inputFilePath);
try {
    let htmlFilePath = path.join(outputDirectory, "presentation.html");
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Nach dem Export hat der Ausgabesordner diese Struktur:

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

Die genauen Dateien hängen vom Inhalt der Präsentation und den Exportoptionen ab. Rasterbilder werden beispielsweise häufig als JPEG oder PNG exportiert. Aspose.Slides kann einen anderen Bild‑Codec wählen als in der Ausgangspräsentation verwendet, wenn dies zu einer kleineren oder besser geeigneten Datei führt. Bilder mit Transparenz werden als PNG exportiert.

## **Auswahl von URLs für die Bereitstellung**

Das Beispiel verwendet einen relativen URL‑Präfix: `assets/`. Wenn `presentation.html` aus `html-output/presentation.html` geöffnet wird, lädt der Browser `html-output/assets/resource-1.svg`.

Wenn eine verknüpfte Ressource auf eine andere verknüpfte Ressource verweist, verwendet das Beispiel den Parameter `referrer` in [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilinkembedcontroller/) und gibt nur den Dateinamen zurück. Beispielsweise sollte die SVG‑Datei, wenn `resource-1.svg` und `resource-4.jpg` beide im Ordner `assets` liegen, auf `resource-4.jpg` verweisen und nicht auf `assets/resource-4.jpg`.

Verwenden Sie einen anderen URL‑Präfix, wenn die Dateien an anderer Stelle bereitgestellt werden:
- Verwenden Sie `assets/`, wenn das Asset‑Verzeichnis neben der HTML‑Datei liegt.
- Verwenden Sie `../assets/`, wenn das Asset‑Verzeichnis eine Ebene über der HTML‑Datei liegt.
- Verwenden Sie `https://cdn.example.com/presentations/job-123/assets/`, wenn die Dateien in ein CDN oder einen statischen Dateiserver hochgeladen werden.

Die von [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilinkembedcontroller/) zurückgegebene URL muss dem endgültigen Bereitstellungsort der von [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilinkembedcontroller/) geschriebenen Datei entsprechen. In Server‑Anwendungen sollten Sie für jeden Konvertierungsauftrag ein eindeutiges Ausgabeverzeichnis oder einen Präfix für die Objektspeicherung verwenden, um das Überschreiben von Dateien aus einem anderen Export zu vermeiden.

## **Wann stattdessen einbetten**

Eingebettetes Base64‑HTML ist weiterhin nützlich, wenn die Ausgabe eine einzelne Datei sein muss, z. B. als E‑Mail‑Anhang, Offline‑Vorschau oder Dokument, das ohne unterstützenden Asset‑Ordner verschoben wird. Verknüpfte Ressourcen eignen sich besser, wenn das HTML von einer Web‑Anwendung bereitgestellt, in einem CMS gespeichert, durch eine Build‑Pipeline optimiert oder von Browsern unabhängig vom HTML zwischengespeichert wird.

## **FAQ**

**Kann ich nur Bilder externalisieren und andere Ressourcen eingebettet lassen?**

Ja. In [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilinkembedcontroller/) geben Sie `LinkEmbedDecision.Link` nur für die Inhalts‑Typen zurück, die Sie als separate Dateien speichern möchten, und `LinkEmbedDecision.Embed` für alles andere.

**Warum weicht die exportierte Bild‑Erweiterung von der der Quellpräsentation ab?**

Aspose.Slides kann Rasterbilder beim HTML‑Export neu kodieren, um Größe oder Browser‑Kompatibilität zu verbessern. Beispielsweise kann ein Bild aus der Quelldatei je nach Ergebnis als JPEG oder PNG geschrieben werden.

**Funktionieren relative URLs, nachdem ich die HTML‑Datei verschoben habe?**

Relative URLs funktionieren nur, wenn die gleiche relative Ordnerstruktur beibehalten wird. Wenn das HTML auf `assets/resource-1.png` verweist, muss der `assets`‑Ordner neben der HTML‑Datei bleiben, es sei denn, Sie erzeugen einen anderen URL‑Präfix.

**Sollten Server‑Anwendungen denselben Ausgabesordner wiederverwenden?**

Nein. Verwenden Sie für jeden Konvertierungsauftrag ein eindeutiges Ausgabeverzeichnis oder einen Speicher‑Präfix. Dadurch werden Dateinamenkollisionen vermieden und ein Export überschreibt nicht die von einem anderen Export erzeugten Ressourcen.