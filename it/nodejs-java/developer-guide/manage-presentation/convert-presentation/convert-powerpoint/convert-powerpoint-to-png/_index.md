---
title: Converti le diapositive PowerPoint in PNG in JavaScript
linktitle: PowerPoint in PNG
type: docs
weight: 30
url: /it/nodejs-java/convert-powerpoint-to-png/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in PNG
- presentazione in PNG
- diapositiva in PNG
- PPT in PNG
- PPTX in PNG
- salva PPT come PNG
- salva PPTX come PNG
- esporta PPT in PNG
- esporta PPTX in PNG
- Node.js
- JavaScript
- Aspose.Slides
description: "Converti le presentazioni PowerPoint in immagini PNG di alta qualità con JavaScript rapidamente usando Aspose.Slides per Node.js, garantendo risultati precisi e automatizzati."
---
## **Panoramica**

Questo articolo spiega come convertire le diapositive di una presentazione in immagini PNG utilizzando Aspose.Slides per Node.js tramite Java. È possibile caricare presentazioni in formati come PPT, PPTX e ODP, renderizzare ogni diapositiva e salvarla come immagine PNG separata.

Gli esempi seguenti dimostrano il rendering alla scala predefinita, l'aumento della scala, la specifica delle dimensioni di output in pixel e la scelta di uno stile di rendering a gradiente.

## **Converti PowerPoint in PNG**

Carica una presentazione con la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) e accedi alle sue diapositive tramite la collezione [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides). L'esempio renderizza ogni diapositiva con [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) senza parametri per creare una miniatura. Quindi chiama [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) con [ImageFormat.Png](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/#Png) per salvare ogni diapositiva renderizzata come immagine PNG.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
L'overload di [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) senza parametri esegue il rendering a una scala di 0.2. Per esempio, una diapositiva di 720 × 540 punti produce una miniatura di 144 × 108 pixel. Per controllare le dimensioni di output, usa gli overload con fattori di scala o una dimensione dell'immagine esplicita mostrata di seguito.
{{% /alert %}}

## **Converti PowerPoint in PNG con Dimensioni Personalizzate**

Passa i fattori di scala orizzontali e verticali a [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) per controllare le dimensioni del rendering. In questo esempio, entrambi i fattori sono 2, quindi una diapositiva di 720 × 540 punti produce un'immagine di 1440 × 1080 pixel. Fattori di scala uguali preservano le proporzioni della diapositiva. Ogni immagine viene salvata in formato PNG con [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let scaleX = 2.0;
    let scaleY = scaleX;

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Converti PowerPoint in PNG con Dimensione Personalizzata**

Per specificare le dimensioni di output in pixel, passa una dimensione a [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) invece dei fattori di scala. Questo esempio renderizza ogni diapositiva a 960 × 720 pixel e salva il risultato con [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save). Scegli dimensioni che corrispondono al rapporto d'aspetto della diapositiva per evitare lo stiramento dell'immagine.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let imageSize = java.newInstanceSync("java.awt.Dimension", 960, 720);

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Scegli uno stile di rendering a gradiente**

Supponiamo che una diapositiva contenga riempimenti a gradiente, ma le transizioni nel PNG esportato appaiano più chiare o comunque diverse da quelle visualizzate in PowerPoint. È possibile utilizzare il metodo [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setGradientStyle) ereditato da [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/) per scegliere come vengono renderizzati i gradienti.

Scarica [gradient-styles.pptx](gradient-styles.pptx) e posizionalo nella directory di lavoro dell'applicazione. La sua prima diapositiva contiene due gradienti lineari: dal ciano all'arancione in alto e dal blu al giallo in basso. Ogni gradiente ha due fermate, allo 0% e al 100%.

L'esempio seguente carica questa presentazione e renderizza la stessa prima diapositiva in entrambi i modi con [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("gradient-styles.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let gradientStyles = [aspose.slides.GradientStyle.Default, aspose.slides.GradientStyle.PowerPointUI];
    for (let style of gradientStyles) {
        let options = new aspose.slides.RenderingOptions();
        options.setGradientStyle(style);

        let styleName = style == aspose.slides.GradientStyle.Default ? "Default" : "PowerPointUI";
        let image = slide.getImage(options, 1.0, 1.0);
        try {
            image.save("gradient-" + styleName + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

Le immagini seguenti mostrano l'output della stessa diapositiva, con entrambi i gradienti in ogni immagine:

| Default | PowerPointUI |
| --- | --- |
| ![Gradienti ciano-arancione e blu-giallo renderizzati con Default](gradient-Default.png) | ![Gli stessi gradienti renderizzati con PowerPointUI](gradient-PowerPointUI.png) |

In questo esempio, `Default` produce colori intermedi più chiari, mentre `PowerPointUI` produce colori intermedi più scuri. La differenza dipende dai colori e dalle fermate del gradiente.

Scegli `Default` quando l'output standard di Aspose.Slides soddisfa le tue esigenze. Prova `PowerPointUI` quando la tua priorità è riprodurre fedelmente l'aspetto in PowerPoint. Confronta entrambi gli output con il risultato desiderato; nessuna modalità è universalmente preferibile.

## **FAQ**

**Come posso esportare una forma specifica, come un grafico o un'immagine, invece dell'intera diapositiva?**

Aspose.Slides supporta la [generazione di miniature per forme individuali](/slides/it/nodejs-java/create-shape-thumbnails/), consentendo di renderizzare una forma come immagine PNG.

**La conversione parallela è supportata su un server?**

Sì. Utilizza un'istanza di presentazione separata per ogni thread o processo; [non condividere un'unica istanza tra i thread](/slides/it/nodejs-java/multithreading/).

**Quali sono le limitazioni della modalità di valutazione quando si esporta in PNG?**

La modalità di valutazione aggiunge una filigrana alle immagini di output e applica [altre restrizioni](/slides/it/nodejs-java/licensing/) finché non viene applicata una licenza.