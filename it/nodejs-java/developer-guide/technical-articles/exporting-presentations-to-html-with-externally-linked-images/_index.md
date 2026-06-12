---
title: Esportare presentazioni in HTML con immagini collegate esternamente
type: docs
weight: 100
url: /it/nodejs-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- esportare PowerPoint
- esportare OpenDocument
- esportare presentazione
- esportare diapositiva
- esportare PPT
- esportare PPTX
- esportare ODP
- PowerPoint in HTML
- OpenDocument in HTML
- presentazione in HTML
- diapositiva in HTML
- PPT in HTML
- PPTX in HTML
- ODP in HTML
- immagine collegata
- immagine collegata esternamente
- risorsa collegata
- risorsa esterna
- JavaScript
- Node.js
- Aspose.Slides
description: "Esporta presentazioni PowerPoint e OpenDocument in HTML in JavaScript usando Aspose.Slides per Node.js tramite Java con immagini e altre risorse salvate come file collegati esternamente."
---
## **Panoramica**

Per impostazione predefinita, Aspose.Slides esporta una presentazione in un file HTML autonomo. Immagini e altre risorse vengono scritte direttamente nell'HTML, di solito come dati Base64. Questo è comodo quando si ha bisogno di un unico file portabile, ma non è sempre il formato migliore per un sito web, un CMS o una pipeline di conversione lato server.

Utilizzare risorse collegate esternamente quando si desidera:

- ridurre le dimensioni del documento HTML;
- memorizzare nella cache immagini, font, audio o video separatamente in un browser o CDN;
- ispezionare, sostituire, comprimere o post‑elaborare le risorse generate dopo l'esportazione;
- mantenere la struttura di output più vicina a quella che si aspetta un'applicazione web.

Per il flusso di lavoro generale di conversione HTML, vedere [Convertire le presentazioni PowerPoint in HTML](/slides/it/nodejs-java/convert-powerpoint-to-html/). Questo articolo si concentra sulla parte di collegamento delle risorse dell'esportazione.

## **Come funziona l'esportazione con risorse collegate**

Un proxy Java per [ILinkEmbedController](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilinkembedcontroller/) consente all'applicazione di decidere, risorsa per risorsa, se l'esportatore incorpora i dati nell'HTML o li salva esternamente scrivendo un collegamento.

Il controller dispone di tre metodi:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilinkembedcontroller/) decide se una risorsa deve essere collegata o incorporata.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilinkembedcontroller/) restituisce l'URL che verrà scritto nell'HTML generato o in un'altra risorsa collegata.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilinkembedcontroller/) scrive i dati della risorsa collegata su disco o su un altro obiettivo di archiviazione.

Il percorso del file system e l'URL del browser sono preoccupazioni separate. Per esempio, il campione sotto scrive i file di risorse in `html-output/assets` su disco, mentre l'HTML contiene URL relativi come `assets/resource-1.svg`. Un browser risolve quegli URL rispetto al file che contiene il collegamento. Pertanto, un collegamento da `presentation.html` a un file SVG usa `assets/resource-1.svg`, mentre un collegamento da quel file SVG a un'immagine salvata nella stessa cartella `assets` usa `resource-4.jpg`.

## **Esportare HTML con risorse collegate**

L'esempio JavaScript seguente crea una directory di output, salva il file HTML lì e memorizza le risorse collegate in una sottodirectory `assets`. Il controller collega le risorse comuni di immagini, font, audio, video e CSS quando Aspose.Slides fornisce o può inferire un'estensione di file sicura. Le risorse non riconosciute rimangono incorporate.

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

After the export, the output folder has this structure:

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

I file esatti dipendono dal contenuto della presentazione e dalle opzioni di esportazione. Per esempio, le immagini raster sono comunemente esportate come JPEG o PNG. Aspose.Slides può scegliere un codec immagine diverso da quello usato nella presentazione originale quando ciò produce un file più piccolo o più adatto. Le immagini con trasparenza vengono esportate come PNG.

## **Scelta degli URL per il deployment**

Il campione utilizza un prefisso URL relativo: `assets/`. Se `presentation.html` viene aperto da `html-output/presentation.html`, il browser carica `html-output/assets/resource-1.svg`.

Quando una risorsa collegata fa riferimento a un'altra risorsa collegata, il campione utilizza il parametro `referrer` in [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilinkembedcontroller/) e restituisce solo il nome del file. Per esempio, se `resource-1.svg` e `resource-4.jpg` sono entrambi nella cartella `assets`, il file SVG dovrebbe riferirsi a `resource-4.jpg`, non a `assets/resource-4.jpg`.

Usare un prefisso URL diverso quando i file sono distribuiti altrove:

- Usare `assets/` quando la directory degli asset si trova accanto al file HTML.
- Usare `../assets/` quando la directory degli asset è un livello sopra il file HTML.
- Usare `https://cdn.example.com/presentations/job-123/assets/` quando i file sono caricati su un CDN o su un server di file statici.

L'URL restituito da [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilinkembedcontroller/) deve corrispondere alla posizione finale di distribuzione del file scritto da [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilinkembedcontroller/). Nelle applicazioni server, utilizzare una directory di output unica o un prefisso di storage per oggetti per ogni lavoro di conversione per evitare la sovrascrittura di file da un'altra esportazione.

## **Quando incorporare invece**

L'HTML incorporato in Base64 è ancora utile quando l'output deve essere un singolo file, ad esempio un allegato email, un'anteprima offline o un documento che verrà spostato senza una cartella di asset di supporto. Le risorse collegate sono più adatte quando l'HTML sarà servito da un'applicazione web, archiviato in un CMS, ottimizzato da una pipeline di build o memorizzato nella cache dei browser in modo indipendente dall'HTML.

## **FAQ**

**Posso esternalizzare solo le immagini e mantenere le altre risorse incorporate?**

Sì. In [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilinkembedcontroller/), restituire `LinkEmbedDecision.Link` solo per i tipi di contenuto che si desidera salvare come file separati, e restituire `LinkEmbedDecision.Embed` per tutto il resto.

**Perché l'estensione dell'immagine esportata differisce da quella della presentazione originale?**

Aspose.Slides può ricodificare le immagini raster durante l'esportazione HTML per migliorare dimensione o compatibilità con i browser. Per esempio, un'immagine del file di origine può essere scritta come JPEG o PNG a seconda del risultato renderizzato.

**Gli URL relativi funzionano dopo aver spostato il file HTML?**

Gli URL relativi funzionano solo quando viene preservata la stessa struttura di cartelle relativa. Se l'HTML fa riferimento a `assets/resource-1.png`, la cartella `assets` deve rimanere accanto al file HTML a meno che non si generi un prefisso URL diverso.

**Le applicazioni server dovrebbero riutilizzare la stessa cartella di output?**

No. Utilizzare una directory di output unica o un prefisso di storage per ogni lavoro di conversione. Questo evita collisioni di nomi file e impedisce a un'esportazione di sovrascrivere le risorse generate da un'altra esportazione.