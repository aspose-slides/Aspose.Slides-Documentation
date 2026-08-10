---
title: Genera Diapositive di Presentazione come Immagini SVG in JavaScript
linktitle: Diapositiva in SVG
type: docs
weight: 50
url: /it/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint in SVG
- presentazione in SVG
- diapositiva in SVG
- PPT in SVG
- PPTX in SVG
- opzioni di esportazione SVG
- SVG interattivo
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Esporta le diapositive PowerPoint come immagini SVG in JavaScript e controlla caratteri, testo, immagini, ID ed eventi con Aspose.Slides."
---
## **Panoramica**

SVG è un formato immagine basato su XML scalabile che funziona bene per la pubblicazione web, visualizzatori di diapositive, flussi di lavoro di accessibilità e post‑elaborazione automatizzata. Aspose.Slides per Node.js via Java esporta ogni diapositiva in un file SVG separato e consente di controllare come testo, caratteri, immagini e elementi SVG vengono scritti.

Utilizzare [SVGOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgoptions/) quando l'SVG esportato deve essere compatto, prevedibile su tutti i browser o pronto per l'uso interattivo.

## **Esporta una diapositiva come SVG**

Creare una [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/), selezionare una diapositiva e scriverla su uno stream con [Slide.writeAsSvg](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/writeassvg/). L'esempio seguente esporta ogni diapositiva di una presentazione in un file SVG separato.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const outputFileName = `slide-${slide.getSlideNumber()}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            slide.writeAsSvg(svgStream);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

Il nome file utilizza [Slide.getSlideNumber](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/getslidenumber/) anziché l'indice del ciclo. È inoltre possibile esportare una forma individuale con [Shape.writeAsSvg](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/writeassvg/) quando un visualizzatore di diapositive o una pagina web necessita solo di quella forma.

## **Configura l'output SVG**

[SVGOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgoptions/) controlla il rendering SVG. Per i riquadri di testo, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgoptions/setuseframesize/) include il riquadro di testo nell'area di rendering, e [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) determina se la rotazione del riquadro viene applicata. Impostare [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) su `true` quando il testo deve essere renderizzato senza legature.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-custom-options.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Controlla testo e caratteri**

### **Vettorizza tutto il testo**

Impostare [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) su `true` per scrivere tutto il testo della diapositiva come grafica vettoriale. Ciò elimina le dipendenze dai caratteri e rende il risultato visivo più coerente tra i browser, ma il testo non è più selezionabile o ricercabile come testo SVG.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setVectorizeText(true);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-text.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

### **Scegli come gestire i caratteri esterni**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) utilizza un valore [SvgExternalFontsHandling](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgexternalfontshandling/) per i caratteri caricati esternamente. Scegliere `AddLinksToFontFiles` per fare riferimento a file di carattere separati, `Embed` per includere i dati del carattere nell'SVG, oppure `Vectorize` per renderizzare come grafica solo il testo che utilizza caratteri esterni. Verificare la licenza dei caratteri prima di incorporarli.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const linkedFontsOptions = new slides.SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.AddLinksToFontFiles
    );
    const linkedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-font-links.svg"
    );
    try {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    } finally {
        linkedFontsStream.close();
    }

    const embeddedFontsOptions = new slides.SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Embed
    );
    const embeddedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-embedded-fonts.svg"
    );
    try {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    } finally {
        embeddedFontsStream.close();
    }

    const vectorizedExternalFontsOptions = new slides.SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Vectorize
    );
    const vectorizedExternalFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-external-fonts.svg"
    );
    try {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    } finally {
        vectorizedExternalFontsStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Riduci la dimensione delle immagini incorporate**

Utilizzare [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) per ridurre la risoluzione delle immagini incorporate, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) per omettere le aree di origine ritagliate, e [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgoptions/setjpegquality/) per controllare la qualità della codifica JPEG. Queste impostazioni riducono la dimensione del file a scapito della fedeltà dell’immagine o dei dati dell’immagine conservati.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "compressed-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Assegna ID stabili a forme e testo**

Passare un controller di formattazione a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) per impostare [SvgShape.setId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgshape/setid/) per ogni forma SVG. Un controller che gestisce anche gli intervalli di testo può impostare i valori [SvgTSpan.setId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgtspan/setid/) sugli elementi `tspan` di testo.

Il controller seguente utilizza [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/), che è stabile per la durata della forma, e un contatore ripetibile per i suoi intervalli di testo. Questo rende gli ID generati idonei per il post‑processing di una presentazione non modificata.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class StableSvgIdController {
    constructor() {
        this.currentShapeId = "";
        this.textSpanIndex = 0;
    }

    formatShape(svgShape, shape) {
        this.currentShapeId = `shape-${shape.getOfficeInteropShapeId()}`;
        this.textSpanIndex = 0;
        svgShape.setId(this.currentShapeId);
    }

    formatText(svgTSpan, portion, textFrame) {
        const textSpanId = `${this.currentShapeId}-text-${this.textSpanIndex++}`;
        svgTSpan.setId(textSpanId);
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeAndTextFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            },
            formatText(svgTSpan, portion, textFrame) {
                controller.formatText(svgTSpan, portion, textFrame);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const stableSvgIdController = new StableSvgIdController();
    const controllerProxy = stableSvgIdController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-stable-ids.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Aggiungi gestori di eventi SVG**

In un controller di formattazione, chiamare [SvgShape.setEventHandler](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgshape/seteventhandler/) con un valore [SvgEvent](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgevent/) per aggiungere un gestore di eventi JavaScript a una forma esportata. Assegnare il controller con [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) e definire la funzione JavaScript nella pagina o nel documento SVG che ospita il risultato.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class SvgEventController {
    formatShape(svgShape, shape) {
        if (shape.getName() === "ActionButton") {
            svgShape.setId("action-button");
            svgShape.setEventHandler(
                slides.SvgEvent.OnClick,
                "handleShapeClick(event)"
            );
        }
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const svgEventController = new SvgEventController();
    const controllerProxy = svgEventController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "interactive-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

La pagina host può definire la funzione JavaScript a cui fa riferimento il gestore. L'assegnazione di ID e gestori di eventi consente visualizzatori di diapositive, miglioramenti di accessibilità e altri flussi di lavoro SVG interattivi.

## **FAQ**

**Quando dovrei utilizzare [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) invece di [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgexternalfontshandling/)?**

Utilizzare [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) quando tutto il testo deve essere indipendente dai caratteri. Utilizzare [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgexternalfontshandling/) quando solo il testo che utilizza caratteri esterni deve essere convertito in grafica.

**Qual è il modo migliore per ridurre le dimensioni di un SVG?**

Iniziare comprimendo le immagini incorporate, eliminando le aree di immagine ritagliate e scegliendo file di caratteri collegati quando l'ambiente di destinazione può servirli. Testare il risultato perché risoluzione immagine inferiore, qualità JPEG più bassa e testo vettorizzato hanno diversi compromessi tra qualità e dimensione.

**Posso modificare gli elementi SVG esportati dopo l'esportazione?**

Sì. Assegnare ID attraverso un controller di formattazione, quindi selezionare gli elementi SVG corrispondenti nel proprio strumento di post‑processing o nello script del browser.