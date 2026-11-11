---
title: Renderizza diapositive della presentazione come immagini SVG in JavaScript
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

SVG è un formato immagine basato su XML e scalabile che funziona bene per la pubblicazione web, i visualizzatori di diapositive, i flussi di lavoro di accessibilità e l'elaborazione automatizzata. Aspose.Slides per Node.js tramite Java esporta ogni diapositiva in un file SVG separato e consente di controllare come vengono scritti testo, caratteri, immagini ed elementi SVG.

Utilizza [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) quando l'SVG esportato deve essere compatto, prevedibile tra i browser o pronto per l'uso interattivo.

## **Esporta una diapositiva come SVG**

Crea una [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), seleziona una diapositiva e scrivila su uno stream con [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). L'esempio seguente esporta ogni diapositiva di una presentazione in un file SVG separato.

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

Il nome file utilizza [Slide.getSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidenumber/) anziché l'indice del ciclo. È inoltre possibile esportare una forma individuale con [Shape.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) quando un visualizzatore di diapositive o una pagina web ha bisogno solo di quella forma.

## **Configura l'output SVG**

[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) controlla il rendering SVG. Per i riquadri di testo, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/) include il riquadro di testo nell'area di rendering, e [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) determina se viene applicata la rotazione del riquadro. Imposta [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) su `true` quando il testo deve essere renderizzato senza legature.

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

Durante l'esportazione delle diapositive in SVG, è possibile controllare se il testo rimane come testo o viene convertito in grafica vettoriale, e come i caratteri esterni sono inclusi o referenziati. Le seguenti opzioni aiutano a bilanciare la coerenza visiva, la selezione del testo e le dipendenze dei caratteri nello SVG esportato.

### **Vettorizza tutto il testo**

Imposta [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) su `true` per scrivere tutto il testo della diapositiva come grafica vettoriale. Questo elimina le dipendenze dai caratteri e rende il risultato visivo più coerente tra i browser, ma il testo non è più selezionabile né ricercabile come testo SVG.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) utilizza un valore [SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) per i caratteri caricati esternamente. Scegli `AddLinksToFontFiles` per referenziare file di caratteri separati, `Embed` per includere i dati dei caratteri nell'SVG, o `Vectorize` per renderizzare solo il testo che utilizza caratteri esterni come grafica. Verifica le licenze dei caratteri prima di incorporarli.

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

Utilizza [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) per ridurre la risoluzione delle immagini incorporate, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) per omettere le aree di origine ritagliate e [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) per controllare la qualità della compressione JPEG. Queste impostazioni riducono le dimensioni del file a scapito della fedeltà dell'immagine o dei dati immagine conservati.

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

## **Controlla la risoluzione di rasterizzazione del metafile**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) imposta il limite inferiore di risoluzione per la rasterizzazione dei metafile durante l'esportazione SVG. Usalo per bilanciare il dettaglio e le dimensioni del file quando un'immagine EMF o WMF viene rasterizzata. Non definisce un DPI globale per l'SVG né costringe ogni oggetto della diapositiva a diventare un'immagine raster.

Scarica [metafile-rasterization.pptx](metafile-rasterization.pptx), che contiene un'immagine EMF con linee diagonali ravvicinate. L'esempio seguente esporta la sua prima diapositiva a tre risoluzioni di rasterizzazione tramite [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). Tutte le altre impostazioni di esportazione rimangono identiche in modo da poter confrontare i risultati.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("metafile-rasterization.pptx");
try {
    for (const dpi of [72, 150, 300]) {
        const svgOptions = new slides.SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        const outputFileName = `slide-${dpi}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

Nell'output, l'EMF è diventato un PNG incorporato in ciascun SVG. Le seguenti misurazioni si riferiscono alla presentazione fornita; non costituiscono una formula generale per convertire DPI in dimensioni pixel.

| Risoluzione rasterizzazione metafile DPI | Dimensioni PNG incorporato | Dimensione file SVG (byte) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Il confronto seguente mostra la stessa area del raster incorporato alla stessa dimensione di visualizzazione ingrandita. Le linee diagonali mostrano una pixelatura visibile a 72 DPI e bordi più morbidi a risoluzioni più alte, mentre il file SVG si ingrandisce. Aumentare il valore non migliora necessariamente ogni dettaglio né modifica ogni immagine esportata.

![Dettaglio ingrandito delle linee diagonali a 72, 150 e 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) controlla la riduzione della risoluzione delle immagini e può mascherare l'effetto della modifica della risoluzione di rasterizzazione del metafile. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) controlla la qualità della compressione JPEG, non la risoluzione di rasterizzazione del metafile.

## **Assegna ID stabili a forme e testo**

Passa un controller di formattazione a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) per impostare [SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/) per ciascuna forma SVG. Un controller che gestisce anche gli intervalli di testo può impostare i valori [SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/) sugli elementi di testo `tspan`.

Il controller seguente utilizza [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/), che è stabile per la durata della forma, e un contatore ripetibile per i suoi intervalli di testo. Questo rende gli ID generati adatti per l'elaborazione successiva di una presentazione non modificata.

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

In un controller di formattazione, chiama [SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/) con un valore [SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/) per aggiungere un gestore di eventi JavaScript a una forma esportata. Assegna il controller con [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) e definisci la funzione JavaScript nella pagina o nel documento SVG che ospita il risultato.

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

La pagina host può definire la funzione JavaScript a cui fa riferimento il gestore. L'assegnazione di ID e di gestori di eventi consente visualizzatori di diapositive, miglioramenti di accessibilità e altri flussi di lavoro SVG interattivi.

## **FAQ**

**Quando dovrei usare [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) invece di [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/)?**

Utilizza [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) quando tutto il testo deve essere indipendente dai caratteri. Utilizza [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) quando solo il testo che utilizza caratteri esterni deve essere convertito in grafica.

**Qual è il modo migliore per ridurre le dimensioni di un SVG?**

Inizia comprimendo le immagini incorporate, eliminando le aree di immagine ritagliate e scegliendo file di caratteri collegati quando l'ambiente di destinazione può servirli. Verifica il risultato perché una risoluzione immagine più bassa, una qualità JPEG più bassa e il testo vettorizzato hanno ciascuno compromessi diversi tra qualità e dimensione.

**Posso modificare gli elementi SVG esportati dopo l'esportazione?**

Sì. Assegna gli ID tramite un controller di formattazione, quindi seleziona gli elementi SVG corrispondenti nel tuo strumento di post‑elaborazione o nello script del browser.