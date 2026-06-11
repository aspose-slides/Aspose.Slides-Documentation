---
title: Exportera presentationer till HTML med externt länkade bilder
type: docs
weight: 100
url: /sv/nodejs-java/exporting-presentations-to-html-with-externally-linked-images/
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
- externt länkad bild
- länkad resurs
- extern resurs
- JavaScript
- Node.js
- Aspose.Slides
description: "Exportera PowerPoint- och OpenDocument-presentationer till HTML i JavaScript med Aspose.Slides för Node.js via Java, där bilder och andra resurser sparas som externt länkade filer."
---
## **Översikt**

Som standard exporterar Aspose.Slides en presentation till en fristående HTML‑fil. Bilder och andra resurser skrivs direkt in i HTML, vanligtvis som Base64‑data. Detta är praktiskt när du behöver en enda portabel fil, men det är inte alltid det bästa formatet för en webbplats, ett CMS eller en server‑sidig konverteringspipeline.

- minska storleken på HTML‑dokumentet;
- cacha bilder, teckensnitt, ljud eller video separat i en webbläsare eller CDN;
- inspektera, ersätta, komprimera eller efterbehandla genererade resurser efter export;
- behålla utdata‑strukturen närmare vad en webbapplikation förväntar sig.

För den allmänna HTML‑konverteringsarbetsflödet, se [Konvertera PowerPoint-presentationer till HTML](/slides/sv/nodejs-java/convert-powerpoint-to-html/). Den här artikeln fokuserar på resurs‑länkningdelen av exporten.

## **Hur länkad resurs‑export fungerar**

En Java‑proxy för [ILinkEmbedController](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilinkembedcontroller/) låter din applikation bestämma, resurs för resurs, om exportören bäddar in data i HTML eller sparar den externt och skriver en länk.

Kontrollen har tre metoder:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilinkembedcontroller/) bestämmer om en resurs ska länkas eller bäddas in.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilinkembedcontroller/) returnerar URL:en som kommer att skrivas till den genererade HTML‑filen eller till en annan länkad resurs.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilinkembedcontroller/) skriver de länkade resursdata till disk eller till ett annat lagringsmål.

Filsystemssökvägen och webbläsar‑URL:en är separata frågor. Till exempel skriver exemplaret nedan resursfiler till `html-output/assets` på disken, medan HTML‑filen innehåller relativa URL:er såsom `assets/resource-1.svg`. En webbläsare löser dessa URL:er relativt filen som innehåller länken. Därför använder en länk från `presentation.html` till en SVG‑fil `assets/resource-1.svg`, medan en länk från den SVG‑filen till en bild som sparats i samma `assets`‑mapp använder `resource-4.jpg`.

## **Exportera HTML med länkade resurser**

Följande JavaScript‑exempel skapar en utdata‑katalog, sparar HTML‑filen där och lagrar länkade resurser i en underkatalog `assets`. Kontrollen länkar vanliga bild-, teckensnitt-, ljud-, video- och CSS‑resurser när Aspose.Slides tillhandahåller eller kan härleda en säker filändelse. Resurser som inte känns igen förblir inbäddade.

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

Efter exporten har utdata‑mappen följande struktur:

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

De exakta filerna beror på presentationens innehåll och exportalternativ. Till exempel exporteras rasterbilder vanligtvis som JPEG eller PNG. Aspose.Slides kan välja en annan bildkodare än den som används i källpresentationen när det ger en mindre eller mer lämplig fil. Bilder med transparens exporteras som PNG.

## **Välja URL:er för distribution**

Exemplet använder ett relativt URL‑prefix: `assets/`. Om `presentation.html` öppnas från `html-output/presentation.html` laddar webbläsaren `html-output/assets/resource-1.svg`.

När en länkad resurs refererar till en annan länkad resurs använder exemplaret `referrer`‑parametern i [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilinkembedcontroller/) och returnerar endast filnamnet. Till exempel, om `resource-1.svg` och `resource-4.jpg` båda ligger i `assets`‑mappen, bör SVG‑filen referera till `resource-4.jpg`, inte till `assets/resource-4.jpg`.

Använd ett annat URL‑prefix när filerna distribueras någon annanstans:

- Använd `assets/` när asset‑katalogen ligger bredvid HTML‑filen.
- Använd `../assets/` när asset‑katalogen ligger en nivå ovanför HTML‑filen.
- Använd `https://cdn.example.com/presentations/job-123/assets/` när filerna laddas upp till ett CDN eller en statisk filserver.

URL:en som returneras av [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilinkembedcontroller/) måste matcha den slutgiltiga distribuerade platsen för filen som skrivs av [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilinkembedcontroller/). I serverapplikationer, använd en unik utdata‑katalog eller objekt‑lagrings‑prefix för varje konverteringsjobb för att undvika att överskriva filer från en annan export.

## **När du ska bädda in istället**

Inbäddad Base64‑HTML är fortfarande användbar när utdata måste vara en enda fil, till exempel ett e‑post‑bilaga, en offline‑förhandsgranskning eller ett dokument som kommer att flyttas utan en stödjande asset‑mapp. Länkade resurser är ett bättre val när HTML kommer att serveras av en webbapplikation, lagras i ett CMS, optimeras av en byggpipeline eller cachas av webbläsare oberoende av HTML.

## **FAQ**

**Kan jag externalisera endast bilder och behålla övriga resurser inbäddade?**

Ja. I [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilinkembedcontroller/) returnerar du `LinkEmbedDecision.Link` endast för de innehållstyper du vill spara som separata filer, och returnerar `LinkEmbedDecision.Embed` för allt annat.

**Varför skiljer sig den exporterade bildändelsen från källpresentationen?**

Aspose.Slides kan omkoda rasterbilder under HTML‑export för att förbättra storlek eller webbläsarkompatibilitet. Till exempel kan en bild från källfilen skrivas som JPEG eller PNG beroende på det renderade resultatet.

**Fungerar relativa URL:er efter att jag flyttat HTML‑filen?**

Relativa URL:er fungerar endast när samma relativa mappstruktur bevaras. Om HTML‑filen refererar till `assets/resource-1.png` måste `assets`‑mappen ligga kvar bredvid HTML‑filen om du inte genererar ett annat URL‑prefix.

**Bör serverapplikationer återanvända samma utdata‑mapp?**

Nej. Använd en unik utdata‑katalog eller lagrings‑prefix för varje konverteringsjobb. Detta förhindrar filnamnskonflikter och att en export skriver över resurser som genererats av en annan export.