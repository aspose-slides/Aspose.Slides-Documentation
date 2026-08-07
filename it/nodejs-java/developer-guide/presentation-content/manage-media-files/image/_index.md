---
title: Ottimizza la gestione delle immagini nelle presentazioni usando JavaScript
linktitle: Gestisci immagini
type: docs
weight: 10
url: /it/nodejs-java/image/
keywords:
- aggiungi immagine
- aggiungi foto
- aggiungi bitmap
- sostituisci immagine
- sostituisci foto
- da web
- sfondo
- aggiungi PNG
- aggiungi JPG
- aggiungi SVG
- risorse SVG esterne
- risolutore SVG
- immagini SVG collegate
- font SVG
- aggiungi EMF
- aggiungi WMF
- aggiungi TIFF
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Semplifica la gestione delle immagini in PowerPoint e OpenDocument con Aspose.Slides per Node.js via Java, ottimizzando le prestazioni e automatizzando il tuo flusso di lavoro."
---
## **Introduzione**

Le immagini rendono le presentazioni più coinvolgenti e visivamente accattivanti. In Microsoft PowerPoint, è possibile inserire immagini nelle diapositive da file, da Internet o da altre fonti. Allo stesso modo, Aspose.Slides consente di aggiungere immagini alle diapositive di una presentazione in diversi modi.

{{% alert  title="Tip" color="primary" %}} 

Aspose fornisce convertitori gratuiti—[JPEG in PowerPoint](https://products.aspose.app/slides/it/import/jpg-to-ppt) e [PNG in PowerPoint](https://products.aspose.app/slides/it/import/png-to-ppt)—che consentono di creare rapidamente presentazioni a partire da immagini. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Se desideri aggiungere un'immagine come cornice fotografica—soprattutto se intendi ridimensionarla, applicare effetti o utilizzare altre opzioni di formattazione standard—vedi [Cornice fotografica](/slides/it/nodejs-java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

È possibile convertire le immagini da un formato all'altro. Vedi le seguenti pagine: converti [immagine in JPG](https://products.aspose.com/slides/it/nodejs-java/conversion/image-to-jpg/), [JPG in immagine](https://products.aspose.com/slides/it/nodejs-java/conversion/jpg-to-image/), [JPG in PNG](https://products.aspose.com/slides/it/nodejs-java/conversion/jpg-to-png/), [PNG in JPG](https://products.aspose.com/slides/it/nodejs-java/conversion/png-to-jpg/), [PNG in SVG](https://products.aspose.com/slides/it/nodejs-java/conversion/png-to-svg/), e [SVG in PNG](https://products.aspose.com/slides/it/nodejs-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides supporta immagini nei formati più diffusi come JPEG, PNG, BMP, GIF e altri. 

## **Aggiungere immagini archiviate localmente alle diapositive**

È possibile aggiungere una o più immagini archiviate sul computer a una diapositiva della presentazione. Il seguente esempio di codice JavaScript mostra come aggiungere un'immagine a una diapositiva:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    slide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Aggiungere immagini dal Web alle diapositive**

Se l'immagine che desideri aggiungere a una diapositiva non è archiviata sul tuo computer, puoi aggiungerla direttamente dal Web. 

Il seguente esempio di codice JavaScript mostra come aggiungere un'immagine dal Web a una diapositiva:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    const imageUrl = java.newInstanceSync("java.net.URL", "[REPLACE WITH URL]");
    const inputStream = imageUrl.openStream();
    try {
        let picture;
        const image = aspose.slides.Images.fromStream(inputStream);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }

        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    } finally {
        if (inputStream != null) {
            inputStream.close();
        }
    }

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Aggiungere immagini ai master diapositive**

Un master diapositiva memorizza e controlla informazioni come il tema e il layout per le diapositive che lo utilizzano. Quando aggiungi un'immagine a un master diapositiva, l'immagine appare su ogni diapositiva basata su quel master. 

Il seguente esempio di codice JavaScript mostra come aggiungere un'immagine a un master diapositiva:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    const masterSlide = slide.getLayoutSlide().getMasterSlide();

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    masterSlide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Aggiungere immagini come sfondo delle diapositive**

È possibile utilizzare un'immagine come sfondo per una o più diapositive. Per ulteriori dettagli, vedi *[Impostare le immagini come sfondi per le diapositive](/slides/it/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Aggiungere SVG alle presentazioni**

Il contenuto SVG può essere aggiunto a una presentazione utilizzando la classe [SvgImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgimage/). L'oggetto immagine SVG risultante può quindi essere aggiunto alla collezione di immagini della presentazione e utilizzato per creare una cornice fotografica.

Il seguente esempio JavaScript importa una stringa SVG autonoma. Tutte le immagini, gli stili e le altre risorse utilizzate da questo SVG sono incorporati direttamente nel contenuto SVG.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
    "    <rect width='320' height='180' fill='#4F81BD'/>" +
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
    "</svg>";

const presentation = new aspose.slides.Presentation();
try {
    const svgImage = new aspose.slides.SvgImage(svgContent);
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Importare contenuto SVG con risorse esterne**

I file SVG esportati da strumenti di progettazione, editor di diagrammi, sistemi di icone e pipeline web possono fare riferimento a risorse archiviate al di fuori del documento SVG. Ad esempio, un SVG può contenere un collegamento a un'immagine come `images/photo.png`, un valore CSS `url(...)` o un URL di un font.

Per importare tale contenuto SVG, fornisci un risolutore di risorse esterne e passalo, insieme a un URI di base, a un costruttore [SvgImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgimage/) appropriato. L'URI di base identifica la posizione del documento SVG ed è usato per risolvere i collegamenti relativi.

La classe `SvgImage` fornisce accesso a informazioni sul SVG importato:

- `getSvgContent()` restituisce il markup SVG come stringa.  
- `getSvgData()` restituisce il contenuto SVG come array di byte.  
- `getBaseUri()` restituisce l'URI di base usato per i collegamenti relativi.  
- `getExternalResourceResolver()` restituisce il risolutore associato all'immagine SVG.  

### **Implementare un risolutore di risorse esterne**

Il risolutore ha due metodi:

- `resolveUri` combina l'URI di base e un collegamento a risorsa relativo e restituisce un URI assoluto. Restituisce `null` quando il collegamento non può essere risolto o non è consentito.  
- `getEntity` restituisce uno stream Java leggibile per un URI di risorsa assoluto. Restituisce `null` quando la risorsa è mancante, bloccata o non disponibile. È possibile restituire anche uno stream di fallback quando opportuno.  

Il seguente helper crea un risolutore che carica le risorse collegate solo da una directory locale consentita. Le risorse di rete e i percorsi al di fuori della directory consentita sono bloccati. Un'immagine di fallback opzionale viene restituita per i collegamenti a immagini non risolti.

```javascript
const fs = require("fs");
const path = require("path");
const java = require("java");
const { fileURLToPath, pathToFileURL } = require("url");

function isInsideAllowedRoot(resourcePath, allowedRoot) {
    const relativePath = path.relative(allowedRoot, resourcePath);

    return relativePath === "" ||
        (relativePath !== ".." &&
         !relativePath.startsWith(".." + path.sep) &&
         !path.isAbsolute(relativePath));
}

function isImageFile(filePath) {
    const extension = path.extname(filePath).toLowerCase();
    return [".png", ".jpg", ".jpeg", ".gif", ".bmp"].includes(extension);
}

function createLocalSvgResourceResolver(allowedRoot, fallbackImageData) {
    const normalizedRoot = path.resolve(allowedRoot);

    return java.newProxy("com.aspose.slides.IExternalResourceResolver", {
        resolveUri: function(baseUri, relativeUri) {
            if (baseUri == null || baseUri.trim() === "" ||
                    relativeUri == null || relativeUri.trim() === "") {
                return null;
            }

            try {
                const absoluteAddress = new URL(relativeUri, baseUri);

                // Questo risolutore consente intenzionalmente solo file locali.
                if (absoluteAddress.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(absoluteAddress));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                return pathToFileURL(resourcePath).href;
            } catch (e) {
                return null;
            }
        },

        getEntity: function(absoluteUri) {
            try {
                const resourceUrl = new URL(absoluteUri);
                if (resourceUrl.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(resourceUrl));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                if (fs.existsSync(resourcePath)) {
                    return java.newInstanceSync("java.io.FileInputStream", resourcePath);
                }

                // Usa un fallback solo per le risorse immagine. Restituire uno stream di immagine
                // per un font o un foglio di stile mancante non sarebbe valido.
                if (fallbackImageData != null && isImageFile(resourcePath)) {
                    const javaBytes = java.newArray("byte", Array.from(fallbackImageData));
                    return java.newInstanceSync("java.io.ByteArrayInputStream", javaBytes);
                }
            } catch (e) {
                return null;
            }

            return null;
        }
    });
}
```

### **Risolvere risorse collegate durante l'importazione SVG**

Assumi che `assets/diagram.svg` contenga un riferimento relativo come:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Il seguente esempio JavaScript passa l'URI del file SVG come URI di base e fornisce un risolutore personalizzato. Il risolutore converte il collegamento immagine relativo in un URI assoluto e restituisce uno stream contenente la risorsa collegata mentre Aspose.Slides elabora l'SVG.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");
const { pathToFileURL } = require("url");

const svgFilePath = path.resolve("assets", "diagram.svg");
const assetDirectory = path.dirname(svgFilePath);
const svgContent = fs.readFileSync(svgFilePath, "utf8");

// L'URI di base rappresenta la posizione del documento SVG.
const baseUri = pathToFileURL(svgFilePath).href;

let fallbackImageData = null;
const fallbackImagePath = path.join(assetDirectory, "fallback.png");
if (fs.existsSync(fallbackImagePath)) {
    fallbackImageData = fs.readFileSync(fallbackImagePath);
}

const resolver = createLocalSvgResourceResolver(assetDirectory, fallbackImageData);
const svgImage = new aspose.slides.SvgImage(svgContent, resolver, baseUri);

// SvgImage espone il contenuto sorgente, i dati binari, l'URI di base e il risolutore.
const importedContent = svgImage.getSvgContent();
const importedData = svgImage.getSvgData();
const importedBaseUri = svgImage.getBaseUri();
const importedResolver = svgImage.getExternalResourceResolver();

const presentation = new aspose.slides.Presentation();
try {
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La classe `SvgImage` fornisce anche overload che accettano dati SVG come array di byte, nonché metodi di fabbrica basati su stream, insieme a un risolutore di risorse esterne e a un URI di base.

{{% alert title="Important" color="warning" %}}

Il risolutore di risorse rende disponibili le risorse esterne mentre Aspose.Slides elabora e rende l'SVG. Non modifica il markup SVG originale né incorpora automaticamente le risorse risolte al suo interno.

Quando un'immagine SVG viene aggiunta alla collezione di immagini della presentazione, il file PPTX può contenere sia la rappresentazione SVG originale sia un'immagine raster di fallback. Una risorsa collegata può apparire nell'immagine di fallback generata mentre un collegamento relativo come `images/photo.png` rimane invariato nell'SVG memorizzato. Un'applicazione che rende la rappresentazione SVG nativa può quindi omettere il contenuto collegato quando la risorsa esterna originale non è disponibile.

{{% /alert %}}

### **Creare un'immagine SVG portatile**

Per creare un'immagine SVG che non dipenda da file esterni, rendi l'SVG autonomo prima di creare il `SvgImage`. Ad esempio, sostituisci gli URL delle immagini collegate con URI `data:` che contengono i dati dell'immagine:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Dopo che tutte le risorse richieste sono incorporate nel contenuto SVG, crea il `SvgImage`, aggiungilo alla collezione di immagini della presentazione e inseriscilo in una cornice fotografica come mostrato nell'esempio precedente.

### **Gestire risorse mancanti o bloccate**

Restituisci `null` da `resolveUri` quando un URI di risorsa è invalido, proibito o non può essere risolto. Restituisci `null` da `getEntity` quando la risorsa non può essere letta. Aspose.Slides continua a elaborare l'SVG senza quella risorsa quando possibile.

È possibile restituire uno stream di fallback per una risorsa mancante, ma il suo contenuto deve essere compatibile con il tipo di risorsa richiesto. Ad esempio, restituisci uno stream immagine solo per un'immagine mancante, non per un font o un foglio di stile.

{{% alert title="Security" color="warning" %}}

Non risolvere percorsi di file arbitrari o URL di rete non limitati da file SVG non attendibili. Limita gli schemi, le directory e gli host consentiti. Per le risorse di rete, applica inoltre timeout di connessione, limiti di dimensione della risposta e convalida del contenuto.

{{% /alert %}}

## **Convertire SVG in un insieme di forme**

Aspose.Slides può convertire un SVG in un insieme di forme, simile alla funzionalità corrispondente in PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Questa funzionalità è fornita da un overload del metodo [addGroupShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) della classe [ShapeCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection) che accetta un oggetto immagine SVG come primo argomento.

Il seguente esempio di codice JavaScript mostra come utilizzare questo metodo per convertire un file SVG in un insieme di forme:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Nome file SVG di origine.
const svgFileName = "sample.svg";

// Nome file di output della presentazione.
const outPptxPath = "presentation.pptx";

// Crea una nuova presentazione.
const presentation = new aspose.slides.Presentation();
try {
    // Leggi il contenuto del file SVG.
    const svgContent = java.newArray("byte", Array.from(fs.readFileSync(svgFileName)));

    // Crea un oggetto SvgImage.
    const svgImage = new aspose.slides.SvgImage(svgContent);

    // Ottieni le dimensioni della diapositiva.
    const slideSize = presentation.getSlideSize().getSize();

    // Converti l'immagine SVG in un gruppo di forme e ridimensionala alle dimensioni della diapositiva.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
        svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());

    // Salva la presentazione in formato PPTX.
    presentation.save(outPptxPath, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aggiungere immagini come EMF alle diapositive**

Aspose.Slides per Node.js tramite Java consente di generare immagini EMF da fogli di calcolo Excel con Aspose.Cells e aggiungerle alle diapositive della presentazione.

Il seguente esempio di codice JavaScript mostra come fare questo:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
const sheet = book.getWorksheets().get(0);

const options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));

// Salva la cartella di lavoro in uno stream.
const sr = java.newInstanceSync("SheetRender", sheet, options);
const pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);

    for (let j = 0; j < sr.getPageCount(); j++) {
        const emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Aggiungi il file così com'è in modo che l'immagine rimanga un vettoriale EMF invece di essere rasterizzata.
        let picture;
        const imageStream = java.newInstanceSync("java.io.FileInputStream", emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        const slide = pres.getSlides().addEmptySlide(
            pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            0,
            0,
            pres.getSlideSize().getSize().getWidth(),
            pres.getSlideSize().getSize().getHeight(),
            picture);
    }

    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Sostituire immagini nella collezione di immagini**

Aspose.Slides consente di sostituire le immagini archiviate nella collezione di immagini di una presentazione, incluse le immagini utilizzate dalle forme delle diapositive. Questa sezione descrive diversi modi per aggiornare le immagini nella collezione. È possibile sostituire un'immagine utilizzando dati byte grezzi, un'istanza [IImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/) o un'altra immagine già presente nella collezione.

1. Carica il file di presentazione che contiene le immagini usando la classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).  
2. Carica una nuova immagine da un file in un array di byte.  
3. Sostituisci l'immagine target con la nuova immagine usando l'array di byte.  
4. Nel secondo approccio, carica l'immagine in un oggetto [IImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/) e sostituisci l'immagine target con quell'oggetto.  
5. Nel terzo approccio, sostituisci l'immagine target con un'immagine già presente nella collezione di immagini della presentazione.  
6. Scrivi la presentazione modificata come file PPTX.  

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Instanzia la classe Presentation che rappresenta un file di presentazione.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Il primo modo.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // Il secondo modo.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) {
            newImage.dispose();
        }
    }

    // Il terzo modo.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Salva la presentazione su un file.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Con il convertitore gratuito [Text to GIF](https://products.aspose.app/slides/it/text-to-gif) di Aspose, puoi facilmente animare il testo e creare GIF dal testo. 

{{% /alert %}}

## **FAQ**

**La risoluzione originale dell'immagine rimane intatta dopo l'inserimento?**

Sì. I pixel originali sono preservati, ma l'aspetto finale dipende da come l'[immagine](/slides/it/nodejs-java/picture-frame/) è scalata sulla diapositiva e da eventuali compressioni applicate al salvataggio.

**Qual è il modo migliore per sostituire lo stesso logo su decine di diapositive contemporaneamente?**

Posiziona il logo sul master slide o su un layout e sostituiscilo nella collezione di immagini della presentazione—gli aggiornamenti si propagheranno a tutti gli elementi che utilizzano quella risorsa.

**È possibile convertire un SVG inserito in forme modificabili?**

Sì. È possibile convertire un SVG in un gruppo di forme, dopo di che le singole parti diventano modificabili con le proprietà di forma standard.

**Come posso impostare un'immagine come sfondo per più diapositive contemporaneamente?**

[Assegna l'immagine come sfondo](/slides/it/nodejs-java/presentation-background/) sul master slide o sul layout pertinente—tutte le diapositive che usano quel master/layout erediteranno lo sfondo.

**Come fare in modo che una presentazione non diventi troppo grande a causa di molte immagini?**

Riutilizza una singola risorsa immagine invece di duplicati, scegli risoluzioni ragionevoli, applica compressione al salvataggio e conserva le grafiche ripetute sul master dove opportuno.