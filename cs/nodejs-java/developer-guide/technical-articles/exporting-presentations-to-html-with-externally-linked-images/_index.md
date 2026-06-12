---
title: Export prezentací do HTML s externě propojenými obrázky
type: docs
weight: 100
url: /cs/nodejs-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- export PowerPoint
- export OpenDocument
- export prezentace
- export snímku
- export PPT
- export PPTX
- export ODP
- PowerPoint do HTML
- OpenDocument do HTML
- prezentace do HTML
- snímek do HTML
- PPT do HTML
- PPTX do HTML
- ODP do HTML
- propojený obrázek
- externě propojený obrázek
- propojený zdroj
- externí zdroj
- JavaScript
- Node.js
- Aspose.Slides
description: "Exportujte prezentace PowerPoint a OpenDocument do HTML v JavaScriptu pomocí Aspose.Slides pro Node.js přes Javu, přičemž obrázky a další zdroje jsou uloženy jako externě propojené soubory."
---
## **Přehled**

Ve výchozím nastavení Aspose.Slides exportuje prezentaci do samostatného HTML souboru. Obrázky a další zdroje jsou zapisovány přímo do HTML, obvykle jako data Base64. To je pohodlné, když potřebujete jeden přenosný soubor, ale ne vždy je to nejlepší formát pro webové stránky, CMS nebo serverový konverzní pipeline.

Externě propojené zdroje použijte, když chcete:

- zmenšit velikost HTML dokumentu;
- cachovat obrázky, fonty, audio nebo video odděleně v prohlížeči nebo CDN;
- zkontrolovat, nahradit, komprimovat nebo postprocesovat vygenerované zdroje po exportu;
- udržet strukturu výstupu blíže tomu, co očekává webová aplikace.

Pro obecný workflow konverze HTML viz [Convert PowerPoint Presentations to HTML](/slides/cs/nodejs-java/convert-powerpoint-to-html/). Tento článek se zaměřuje na část exportu související s propojováním zdrojů.

## **Jak funguje export propojených zdrojů**

Java proxy pro [ILinkEmbedController](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilinkembedcontroller/) umožňuje vaší aplikaci rozhodovat, zdroj po zdroji, zda exportér vloží data do HTML nebo je uloží externě a zapíše odkaz.

Řadič má tři metody:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilinkembedcontroller/) rozhoduje, zda má být zdroj propojen nebo vložen.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilinkembedcontroller/) vrací URL, které bude zapsáno do vygenerovaného HTML nebo do jiného propojeného zdroje.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilinkembedcontroller/) zapíše data propojeného zdroje na disk nebo na jiný úložný cíl.

Cesta v souborovém systému a URL v prohlížeči jsou oddělené záležitosti. Například níže uvedený příklad zapisuje soubory zdrojů do `html-output/assets` na disku, zatímco HTML obsahuje relativní URL jako `assets/resource-1.svg`. Prohlížeč tyto URL řeší relativně k souboru, který odkaz obsahuje. Proto odkaz z `presentation.html` na SVG soubor používá `assets/resource-1.svg`, zatímco odkaz z tohoto SVG souboru na obrázek uložený ve stejném adresáři `assets` používá `resource-4.jpg`.

## **Export HTML s propojenými zdroji**

Následující JavaScriptový příklad vytvoří výstupní adresář, uloží tam HTML soubor a uloží propojené zdroje do podadresáře `assets`. Řadič propojí obecné obrázky, fonty, audio, video a CSS zdroje, pokud Aspose.Slides poskytne nebo může odhadnout bezpečnou příponu souboru. Rozpoznané zdroje, které nejsou rozpoznány, zůstávají vložené.

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

Po exportu má výstupní složka tuto strukturu:

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

Přesné soubory závisí na obsahu prezentace a možnostech exportu. Například rastrové obrázky jsou běžně exportovány jako JPEG nebo PNG. Aspose.Slides může zvolit jiný image codec než ten použitý ve zdrojové prezentaci, pokud to vede k menšímu nebo vhodnějšímu souboru. Obrázky s průhledností jsou exportovány jako PNG.

## **Volba URL pro nasazení**

Příklad používá relativní předponu URL: `assets/`. Pokud je `presentation.html` otevřen z `html-output/presentation.html`, prohlížeč načte `html-output/assets/resource-1.svg`.

Když jeden propojený zdroj odkazuje na jiný propojený zdroj, příklad používá parametr `referrer` v [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilinkembedcontroller/) a vrací pouze název souboru. Například pokud jsou `resource-1.svg` a `resource-4.jpg` oba v adresáři `assets`, SVG soubor by měl odkazovat na `resource-4.jpg`, nikoli na `assets/resource-4.jpg`.

Použijte jinou předponu URL, když jsou soubory nasazeny jinde:

- Použijte `assets/`, pokud je adresář s aktivy vedle HTML souboru.
- Použijte `../assets/`, pokud je adresář s aktivy o jednu úroveň výše než HTML soubor.
- Použijte `https://cdn.example.com/presentations/job-123/assets/`, pokud jsou soubory nahrány na CDN nebo statický souborový server.

URL vrácená metodou [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilinkembedcontroller/) musí odpovídat konečnému nasazenému umístění souboru zapsaného metodou [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilinkembedcontroller/). V serverových aplikacích použijte unikátní výstupní adresář nebo předponu objektového úložiště pro každý konverzní úkol, aby nedošlo k přepsání souborů z jiného exportu.

## **Kdy místo toho vložit**

Vložené Base64 HTML je stále užitečné, když výstup musí být jediný soubor, například e‑mailová příloha, offline náhled nebo dokument, který bude přesunut bez podpůrné složky s aktivy. Propojené zdroje jsou vhodnější, když bude HTML obsluhováno webovou aplikací, uloženo v CMS, optimalizováno build pipeline nebo cachováno prohlížeči nezávisle na HTML.

## **FAQ**

**Mohu externalizovat jen obrázky a nechat ostatní zdroje vložené?**

Ano. V [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilinkembedcontroller/) vraťte `LinkEmbedDecision.Link` pouze pro typy obsahu, které chcete uložit jako samostatné soubory, a vraťte `LinkEmbedDecision.Embed` pro vše ostatní.

**Proč se přípona exportovaného obrázku liší od původní prezentace?**

Aspose.Slides může během exportu HTML překódovat rastrové obrázky, aby se zlepšila velikost nebo kompatibilita s prohlížečem. Například obrázek ze zdrojového souboru může být zapsán jako JPEG nebo PNG v závislosti na výsledku renderování.

**Fungují relativní URL po přesunutí HTML souboru?**

Relativní URL fungují pouze tehdy, když je zachována stejná relativní struktura složek. Pokud HTML odkazuje na `assets/resource-1.png`, složka `assets` musí zůstat vedle HTML souboru, pokud nevytvoříte jinou předponu URL.

**Mají serverové aplikace znovu používat stejnou výstupní složku?**

Ne. Použijte unikátní výstupní adresář nebo předponu úložiště pro každý konverzní úkol. Tím se zabrání kolizím názvů souborů a přepsání zdrojů jedním exportem jiným exportem.