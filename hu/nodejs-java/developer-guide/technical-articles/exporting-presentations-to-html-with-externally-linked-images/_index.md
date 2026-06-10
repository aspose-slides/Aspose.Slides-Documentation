---
title: Prezentációk exportálása HTML-be külsőleg linkelt képekkel
type: docs
weight: 100
url: /hu/nodejs-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint exportálás
- OpenDocument exportálás
- prezentáció exportálása
- dia exportálása
- PPT exportálás
- PPTX exportálása
- ODP exportálása
- PowerPoint HTML-re
- OpenDocument HTML-re
- prezentáció HTML-re
- dia HTML-re
- PPT HTML-re
- PPTX HTML-re
- ODP HTML-re
- linkelt kép
- külsőleg linkelt kép
- linkelt erőforrás
- külső erőforrás
- JavaScript
- Node.js
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk exportálása HTML-be JavaScript-ben az Aspose.Slides for Node.js segítségével, Java-n keresztül, a képek és egyéb erőforrások külső linkelt fájlokként mentésével."
---
## **Áttekintés**

Alapértelmezés szerint az Aspose.Slides egy prezentációt önálló HTML fájlba exportál. A képek és egyéb erőforrások közvetlenül az HTML-be íródnak, általában Base64 adatként. Ez akkor kényelmes, ha egy hordozható fájlra van szükség, de nem mindig a legjobb formátum egy weboldal, egy CMS vagy egy szerveroldali konverziós folyamat számára.

Használjon külsőleg hivatkozott erőforrásokat, ha:

- csökkentse a HTML dokumentum méretét;
- gyorsítótárazza a képeket, betűtípusokat, hangot vagy videót külön a böngészőben vagy CDN-ben;
- ellenőrizze, cserélje, tömörítse vagy utófeldolgozza a generált erőforrásokat exportálás után;
- tartsa a kimeneti struktúrát közelebb ahhoz, amit egy webalkalmazás elvár.

Az általános HTML konverziós munkafolyamatnál lásd a [PowerPoint prezentációk konvertálása HTML-re](/slides/hu/nodejs-java/convert-powerpoint-to-html/). Ez a cikk az export erőforrás‑linkelés részére koncentrál.

## **A linkelt erőforrás exportálás működése**

A [ILinkEmbedController](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilinkembedcontroller/) Java proxyja lehetővé teszi, hogy az alkalmazása erőforrásonként eldöntse, hogy az exportáló beágyazza-e az adatot a HTML-be vagy külsőleg menti és linket ír.

A vezérlőnek három metódusa van:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilinkembedcontroller/) eldönti, hogy egy erőforrást linkelni vagy beágyazni kell-e.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilinkembedcontroller/) visszaadja a URL-t, amely a generált HTML-be vagy egy másik linkelt erőforrásba kerül.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilinkembedcontroller/) írja a linkelt erőforrás adatokat lemezre vagy egy másik tárolási célpontra.

A fájlrendszer útvonala és a böngésző URL-je külön kérdés. Például az alábbi minta az erőforrás‑fájlokat a `html-output/assets` könyvtárba írja lemezre, míg a HTML relatív URL‑eket tartalmaz, mint `assets/resource-1.svg`. A böngésző ezeket a URL‑eket a linket tartalmazó fájlhoz viszonyítva oldja fel. Így egy link a `presentation.html`‑ből egy SVG fájlra a `assets/resource-1.svg`‑t használja, míg az SVG‑fájl egy ugyanabban a `assets` könyvtárban lévő képre a `resource-4.jpg`‑t hivatkozza.

## **HTML exportálása linkelt erőforrásokkal**

Az alábbi JavaScript‑példa létrehoz egy kimeneti könyvtárat, oda menti a HTML‑fájlt, és a linkelt erőforrásokat egy `assets` alkönyvtárban tárolja. A vezérlő a gyakori kép‑, betűtípus‑, hang‑, videó‑ és CSS‑erőforrásokat linkeli, ha az Aspose.Slides biztosít vagy meg tud határozni biztonságos fájlkiterjesztést. A nem felismert erőforrások beágyazva maradnak.

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

Az export után a kimeneti mappának ez a struktúrája van:

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

A pontos fájlok a prezentáció tartalmától és az exportálási beállításoktól függnek. Például a raszteres képek általában JPEG‑ként vagy PNG‑ként kerülnek exportálásra. Az Aspose.Slides másik képkódolót is választhat, mint a forrásprezentációban, ha ez kisebb vagy megfelelőbb fájlt eredményez. Az átlátszóságot tartalmazó képek PNG‑ként kerülnek exportálásra.

## **URL-ek kiválasztása a telepítéshez**

A minta egy relatív URL‑előtagot használ: `assets/`. Ha a `presentation.html` a `html-output/presentation.html`‑ból nyílik, a böngésző a `html-output/assets/resource-1.svg`‑t tölti be.

Amikor egy linkelt erőforrás egy másik linkelt erőforrásra hivatkozik, a minta a `referrer` paramétert használja az [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilinkembedcontroller/)‑ban, és csak a fájlnevet adja vissza. Például ha a `resource-1.svg` és a `resource-4.jpg` is a `assets` mappában van, az SVG‑fájlnak a `resource-4.jpg`‑re kell hivatkoznia, nem a `assets/resource-4.jpg`‑re.

Használjon más URL‑előtagot, ha a fájlok máshol vannak telepítve:

- Használja a `assets/`‑t, ha az eszközkönyvtár a HTML‑fájl mellett helyezkedik el.
- Használja a `../assets/`‑t, ha az eszközkönyvtár a HTML‑fájl egy szinttel feljebb van.
- Használja a `https://cdn.example.com/presentations/job-123/assets/`‑t, ha a fájlok egy CDN‑re vagy statikus fájlszerverre vannak feltöltve.

Az [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilinkembedcontroller/) által visszaadott URL‑nek meg kell egyeznie a [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilinkembedcontroller/) által írt fájl végső telepítési helyével. Szerveralkalmazásoknál használjon egyedi kimeneti könyvtárat vagy objektumtároló előtagot minden konverziós feladathoz, hogy elkerülje a fájlok felülírását másik exportból.

## **Mikor érdemes beágyazni**

A beágyazott Base64 HTML továbbra is hasznos, ha a kimenetnek egyetlen fájlnak kell lennie, például e‑mail‑mellékletként, offline előnézetként vagy egy olyan dokumentumként, amelyet támogatás nélküli eszközkönyvtár nélkül mozgatnak. A linkelt erőforrások jobb megoldást nyújtanak, ha a HTML‑t egy webalkalmazás szolgálja ki, egy CMS‑ben tárolják, egy build‑csővezeték optimalizálja, vagy a böngészők a HTML‑től függetlenül gyorsítótárazzák.

## **GYIK**

**Kiexportálhatok csak képeket, és a többi erőforrást beágyazottan hagyhatom?**

Igen. Az [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilinkembedcontroller/) csak a külön fájlokként menteni kívánt tartalomtípusok esetén adja vissza a `LinkEmbedDecision.Link` értéket, egyébként a `LinkEmbedDecision.Embed` értéket.

**Miért tér el az exportált kép kiterjesztése a forrásprezentációétól?**

Az Aspose.Slides a HTML exportálás során újrakódolhatja a raszteres képeket a méret vagy a böngésző kompatibilitás javítása érdekében. Például a forrásfájlból származó kép JPEG‑ként vagy PNG‑ként íródhat, a megjelenített eredménytől függően.

**Működnek a relatív URL‑ek, ha áthelyezem a HTML‑fájlt?**

A relatív URL‑ek csak akkor működnek, ha a relatív mappaszerkezet változatlanul megmarad. Ha a HTML a `assets/resource-1.png`‑re hivatkozik, az `assets` mappának a HTML‑fájl mellett kell maradnia, hacsak nem generál egy másik URL‑előtagot.

**A szerveralkalmazások újra felhasználhatják ugyanazt a kimeneti mappát?**

Nem. Használjon egyedi kimeneti könyvtárat vagy tárolási előtagot minden konverziós feladathoz. Így elkerülhető a fájlnév-ütközés, és egy export nem ír felül egy másik export által generált erőforrásokat.