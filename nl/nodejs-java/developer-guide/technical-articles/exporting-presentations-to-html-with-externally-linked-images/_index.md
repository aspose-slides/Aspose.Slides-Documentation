---
title: "Presentaties exporteren naar HTML met extern gekoppelde afbeeldingen"
type: docs
weight: 100
url: /nl/nodejs-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- "PowerPoint exporteren"
- "OpenDocument exporteren"
- "presentatie exporteren"
- "dia exporteren"
- "PPT exporteren"
- "PPTX exporteren"
- "ODP exporteren"
- "PowerPoint naar HTML"
- "OpenDocument naar HTML"
- "presentatie naar HTML"
- "dia naar HTML"
- "PPT naar HTML"
- "PPTX naar HTML"
- "ODP naar HTML"
- "gekoppelde afbeelding"
- "extern gekoppelde afbeelding"
- "gekoppelde bron"
- "externe bron"
- "JavaScript"
- "Node.js"
- "Aspose.Slides"
description: "PowerPoint- en OpenDocument‑presentaties exporteren naar HTML in JavaScript met Aspose.Slides voor Node.js via Java, waarbij afbeeldingen en andere bronnen worden opgeslagen als extern gekoppelde bestanden."
---
## **Overzicht**

Standaard exporteert Aspose.Slides een presentatie naar een zelfstandig HTML‑bestand. Afbeeldingen en andere bronnen worden rechtstreeks in de HTML geschreven, meestal als Base64‑gegevens. Dit is handig wanneer u één draagbaar bestand nodig hebt, maar het is niet altijd het beste formaat voor een website, een CMS of een server‑side conversiepijplijn.

Gebruik extern gekoppelde bronnen wanneer u wilt:

- de grootte van het HTML‑document te verkleinen;
- afbeeldingen, lettertypen, audio of video afzonderlijk te cachen in een browser of CDN;
- gegenereerde bronnen na export te inspecteren, te vervangen, te comprimeren of post‑te verwerken;
- de output‑structuur dichter bij wat een webapplicatie verwacht te houden.

Voor de algemene HTML‑conversieworkflow, zie [PowerPoint‑presentaties converteren naar HTML](/slides/nl/nodejs-java/convert-powerpoint-to-html/). Dit artikel richt zich op het onderdeel van bronkoppeling van de export.

## **Hoe export met gekoppelde bronnen werkt**

Een Java‑proxy voor [ILinkEmbedController](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilinkembedcontroller/) laat uw applicatie per bron bepalen of de exporteur de gegevens in de HTML inbed of extern opslaat en een koppeling schrijft.

De controller heeft drie methoden:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilinkembedcontroller/) bepaalt of een bron gelinkt of ingebed moet worden.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilinkembedcontroller/) retourneert de URL die naar de gegenereerde HTML of een andere gekoppelde bron geschreven wordt.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilinkembedcontroller/) schrijft de gekoppelde brongegevens naar de schijf of naar een ander opslagdoel.

Het bestandssysteempad en de browser‑URL zijn afzonderlijke zaken. Bijvoorbeeld, het voorbeeld hieronder schrijft bronbestanden naar `html-output/assets` op schijf, terwijl de HTML relatieve URL's bevat zoals `assets/resource-1.svg`. Een browser lost die URL's op ten opzichte van het bestand dat de koppeling bevat. Daarom gebruikt een koppeling van `presentation.html` naar een SVG‑bestand `assets/resource-1.svg`, terwijl een koppeling vanuit dat SVG‑bestand naar een afbeelding die in dezelfde `assets`‑map is opgeslagen `resource-4.jpg` gebruikt.

## **HTML exporteren met gekoppelde bronnen**

Het volgende JavaScript‑voorbeeld maakt een uitvoermap aan, slaat het HTML‑bestand daar op en slaat gekoppelde bronnen op in een submap `assets`. De controller koppelt algemene afbeelding‑, lettertype‑, audio‑, video‑ en CSS‑bronnen wanneer Aspose.Slides een veilig bestandsextensie biedt of kan afleiden. Niet‑herkende bronnen blijven ingebed.

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

De exacte bestanden zijn afhankelijk van de inhoud van de presentatie en de exportopties. Raster‑afbeeldingen worden bijvoorbeeld vaak geëxporteerd als JPEG of PNG. Aspose.Slides kan een andere afbeeldingscodec kiezen dan die in de bronpresentatie wordt gebruikt wanneer dat een kleiner of geschikter bestand oplevert. Afbeeldingen met transparantie worden geëxporteerd als PNG.

## **URL's kiezen voor implementatie**

Het voorbeeld gebruikt een relatieve URL‑prefix: `assets/`. Als `presentation.html` wordt geopend vanuit `html-output/presentation.html`, laadt de browser `html-output/assets/resource-1.svg`.

Wanneer een gekoppelde bron naar een andere gekoppelde bron verwijst, gebruikt het voorbeeld de `referrer`‑parameter in [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilinkembedcontroller/) en retourneert alleen de bestandsnaam. Bijvoorbeeld, als `resource-1.svg` en `resource-4.jpg` beide in de `assets`‑map staan, moet het SVG‑bestand verwijzen naar `resource-4.jpg`, niet naar `assets/resource-4.jpg`.

Gebruik een andere URL‑prefix wanneer de bestanden elders worden geïmplementeerd:

- Gebruik `assets/` wanneer de asset‑map naast het HTML‑bestand staat.
- Gebruik `../assets/` wanneer de asset‑map één niveau boven het HTML‑bestand staat.
- Gebruik `https://cdn.example.com/presentations/job-123/assets/` wanneer de bestanden geüpload zijn naar een CDN of statische bestandsserver.

De URL die wordt geretourneerd door [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilinkembedcontroller/) moet overeenkomen met de definitieve geïmplementeerde locatie van het bestand dat wordt geschreven door [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilinkembedcontroller/). Gebruik in server‑applicaties een unieke uitvoermap of object‑opslag‑prefix voor elke conversietaak om overschrijving van bestanden van een andere export te voorkomen.

## **Wanneer in plaats daarvan inbedden**

Ingebedde Base64‑HTML blijft nuttig wanneer de output één enkel bestand moet zijn, bijvoorbeeld een e‑mailbijlage, een offline preview, of een document dat wordt verplaatst zonder een ondersteunende asset‑map. Gekoppelde bronnen zijn beter wanneer de HTML wordt bediend door een webapplicatie, opgeslagen in een CMS, geoptimaliseerd door een build‑pijplijn, of door browsers onafhankelijk van de HTML wordt gecached.

## **Veelgestelde vragen**

**Kan ik alleen afbeeldingen extern opslaan en andere bronnen ingebed houden?**

Ja. In [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilinkembedcontroller/) retourneert u `LinkEmbedDecision.Link` alleen voor de inhoudstypen die u als aparte bestanden wilt opslaan, en retourneert u `LinkEmbedDecision.Embed` voor alles andere.

**Waarom wijkt de geëxporteerde afbeeldingsextensie af van de bronpresentatie?**

Aspose.Slides kan raster‑afbeeldingen opnieuw coderen tijdens het HTML‑exporteren om de grootte of browser‑compatibiliteit te verbeteren. Bijvoorbeeld, een afbeelding uit het bronbestand kan worden weggeschreven als JPEG of PNG, afhankelijk van het gerenderde resultaat.

**Werken relatieve URL's nog nadat ik het HTML‑bestand verplaats?**

Relatieve URL's werken alleen wanneer dezelfde relatieve mapstructuur behouden blijft. Als de HTML `assets/resource-1.png` verwijst, moet de `assets`‑map naast het HTML‑bestand blijven, tenzij u een andere URL‑prefix genereert.

**Moeten server‑applicaties dezelfde uitvoermap hergebruiken?**

Nee. Gebruik voor elke conversietaak een unieke uitvoermap of opslag‑prefix. Dit voorkomt bestandsnaamconflicten en voorkomt dat één export de door een andere export gegenereerde bronnen overschrijft.