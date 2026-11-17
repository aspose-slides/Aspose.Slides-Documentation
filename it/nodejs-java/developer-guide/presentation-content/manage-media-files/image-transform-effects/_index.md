---
title: Gestire gli effetti di trasformazione dell'immagine nelle presentazioni con JavaScript
linktitle: Effetti di trasformazione dell'immagine
type: docs
weight: 11
url: /it/nodejs-java/image-transform-effects/
keywords:
- trasformazione immagine
- effetto immagine
- luminosità
- contrasto
- scala di grigi
- duotono
- tinta
- HSL
- sostituzione colore
- sfocatura
- trasparenza
- effetto alfa
- catena di effetti
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Applica, concatena, ispeziona, rimuovi e verifica gli effetti di trasformazione dell'immagine per i riquadri immagine con Aspose.Slides per Node.js tramite JavaScript."
---
## **Panoramica**

Aspose.Slides rappresenta le regolazioni delle immagini come una raccolta ordinata di operazioni di trasformazione dell'immagine. Per un riquadro immagine, inizia con il [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) e accedi a [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/). La collezione restituita [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) ti consente di aggiungere, enumerare, ispezionare, rimuovere e cancellare gli effetti senza riscrivere i byte dell'immagine originale.

Questo articolo dimostra un flusso di lavoro completo per luminosità e contrasto, trasformazioni di colore, sfocatura, trasparenza, catene di effetti ordinate, valori effettivi, rimozione e verifica del round‑trip PPTX.

## **Comprendere la proprietà degli effetti e il riutilizzo dell'immagine**

Una risorsa immagine e l'immagine che la visualizza sono oggetti diversi:

- [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) memorizza o fa riferimento ai dati immagine sorgente di proprietà della presentazione.
- [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) appartiene a un riempimento immagine e si riferisce a una risorsa immagine mantenendo la collezione di trasformazioni dell’immagine.
- [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) è la forma della diapositiva che possiede il riempimento immagine pertinente, la geometria, le impostazioni di ritaglio e altre formattazioni a livello di riquadro.

Pertanto, le operazioni di trasformazione dell'immagine non modificano i byte in [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/). Quando lo stesso [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) viene passato a [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) più di una volta, ogni nuovo riquadro immagine riceve il proprio [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) e la propria collezione di trasformazioni. Applicare la scala di grigi a un riquadro non rende gli altri riquadri in scala di grigi, sebbene tutti riutilizzino la stessa risorsa immagine incorporata.

Lo stesso modello [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) è usato anche da altri riempimenti immagine, come una forma o lo sfondo della diapositiva. Gli esempi seguenti si concentrano sui riquadri immagine.

## **Utilizzare intervalli e unità di parametro validi**

I metodi dimostrati utilizzano i seguenti intervalli semantici e unità. Mantieni i valori entro questi intervalli anche se una particolare versione della libreria non rifiuta immediatamente ogni valore fuori intervallo; il formato di presentazione target potrebbe normalizzare, omettere o rifiutare dati non validi durante il salvataggio o quando PowerPoint apre il file.

| Operazione | Parametri | Intervallo valido e unità |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` attraverso `100`, percentuale; `0` lascia il componente invariato. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | Nessuno | Nessun parametro numerico. L'alpha rimane invariato. |
| [addDuotoneEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | Due colori per pixel scuri e chiari. I canali RGB e alfa in `java.awt.Color` usano `0` attraverso `255`. |
| [addTintEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | La tonalità è `0` inclusivo fino a `360` esclusivo, in gradi; l'intensità è `-100` attraverso `100`, percentuale. |
| [addHSLEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | La tonalità è `0` inclusivo fino a `360` esclusivo, in gradi; saturazione e luminanza sono `-100` attraverso `100`, percentuale. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | Il colore di sostituzione utilizza valori di canale da `0` a `255`. I valori alfa esistenti rimangono invariati. |
| [addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | Il raggio è non negativo e misurato in punti; `grow` è un Booleano che controlla se il contenuto sfocato può estendersi oltre i limiti originali. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | Percentuale non negativa. Usa `0` attraverso `100` per una normale scala di opacità: `0` è totalmente trasparente e `100` conserva l'alpha esistente. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` attraverso `100`, percentuale di opacità. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` attraverso `100`, soglia alfa percentuale. I valori al di sotto diventano trasparenti; i valori pari o superiori diventano opachi. |

Per la modulazione alfa fissa, trasparenza e opacità sono complementari. Ad esempio, il 35% di trasparenza corrisponde a un valore di modulazione alfa del 65%.

## **Applicare luminosità e contrasto**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) restituisce un'operazione [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/). Le impostazioni scalari sono fornite quando l'operazione è creata. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) restituisce valori calcolati di sola lettura che possono essere ispezionati o registrati.

Il seguente esempio aumenta la luminosità del 15% e il contrasto del 20%, poi rende un'anteprima senza modificare l'immagine incorporata:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    const brightnessContrast = imageTransform.addBrightnessContrastEffect(15, 20);

    const effectiveValues = brightnessContrast.getEffective();
    console.log("Brightness: " + effectiveValues.getBrightness() + "%");
    console.log("Contrast: " + effectiveValues.getContrast() + "%");

    const preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", aspose.slides.ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) è un'estensione di effetto immagine di Office 2010 ed è meno portabile dell'effetto di luminanza standard di DrawingML. Quando luminosità e contrasto devono rimanere modificabili dopo un round‑trip PPTX, usa [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) e verifica il risultato dopo aver riaperto il file. La sezione sulle limitazioni di formato spiega questa distinzione più in dettaglio.

## **Applicare trasformazioni di colore**

Gli effetti di colore possono essere applicati in modo indipendente a diversi riquadri immagine che riutilizzano una stessa risorsa immagine. Il seguente esempio crea cinque riquadri e applica scala di grigi, duotone, tinta, regolazione HSL e sostituzione del colore.

[Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) contiene due parametri di colore modificabili indipendentemente: `color1` mappa i pixel scuri, mentre `color2` mappa i pixel chiari. Questo lo rende un esempio utile di un effetto le cui impostazioni sono più complesse di un singolo valore scalare.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const grayFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    const duotoneFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 180, 120, image);
    const duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 128));
    duotone.getColor2().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));

    const tintFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210, 35);

    const hslFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30, 20, -10);

    const replacementFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 320, 170, 180, 120, image);
    const colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(java.newInstanceSync("java.awt.Color", 100, 149, 237));

    presentation.save("color-transformations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) sostituisce il colore di ogni pixel con un colore fisso mantenendo l'alpha. È diverso da [addColorChangeEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), che mappa un colore sorgente a un altro e espone entrambi i formati colore sorgente e di destinazione.

### **Applicare una soglia di luminanza**

Una soglia di luminanza può rendere più facili da distinguere i segni deboli su una pagina scannerizzata dallo sfondo. [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) conserva le sfumature intermedie di grigio. [addBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) mappa la luminanza a nero o bianco, mentre [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) applica una soglia all'opacità.

La soglia di luminanza varia dallo 0% al 100%, inclusivo. I pixel al di sotto della soglia diventano neri. I pixel pari o sopra di essa diventano bianchi. Aumentare la soglia rende più sfumature nere perché più di esse cadono al di sotto del limite.

Scarica [grayscale-swatches.png](grayscale-swatches.png) nella directory di lavoro. Ogni etichetta indica il livello grigio originale su una scala da 0 a 255. L'esempio posiziona l'originale accanto a due copie e salva la soglia di ciascuna copia nella presentazione.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceImage = slides.Images.fromFile("grayscale-swatches.png");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const captions = ["Original", "Threshold 20%", "Threshold 60%"];
    const frames = [];
    for (let i = 0; i < captions.length; i++) {
        const x = 12 + 240 * i;
        const label = shapes.addAutoShape(slides.ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        const frame = shapes.addPictureFrame(slides.ShapeType.Rectangle, x, 60, 216, 72, image);
        frames.push(frame);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60);
    
    presentation.save("luminance-threshold.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Apri la presentazione di output in PowerPoint per confrontare i tre riquadri. Il campione etichettato 96 ha circa il 38% di luminanza (96 su 255). Diventa bianco alla soglia del 20% e nero alla soglia del 60%.

![Campioni in scala di grigi originali accanto ai risultati in bianco e nero alle soglie di luminanza del 20% e 60%](luminance-threshold.png)

## **Aggiungere sfocatura, trasparenza e effetti alfa**

[addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) interessa tutti i canali colore, incluso l'alpha. Imposta `grow` su `true` quando il bordo sfocato può estendersi oltre i limiti dell'immagine originale.

Per una trasparenza uniforme, usa [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/). Moltiplica ogni valore alpha esistente, così i pixel parzialmente trasparenti rimangono proporzionalmente differenti. [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) assegna invece un valore alpha a tutti i pixel. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) converte l'alpha in due livelli basati su una soglia.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const blurredFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 140, image);
    const blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    const transparentFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 20, 200, 140, image);
    const alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65);
    alphaModulate.setAmount(60);

    const uniformAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55);

    const binaryAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 180, 200, 140, image);
    const alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50);
    alphaBiLevel.setThreshold(45);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Altre operazioni alfa senza parametri includono [addAlphaCeilingEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), che rende ogni alpha non zero completamente opaco; [addAlphaFloorEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), che rende ogni alpha inferiore al 100% completamente trasparente; e [addAlphaInverseEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), che cambia alpha in `100% - alpha`.

## **Costruire una catena di effetti ordinata**

Ogni metodo `add...Effect` aggiunge una nuova operazione alla fine della collezione. Il renderer utilizza la collezione come una pipeline ordinata: l'output dell'operazione 0 diventa l'input dell'operazione 1, e così via. Di conseguenza, le stesse operazioni in un ordine diverso possono produrre un'immagine differente.

Ad esempio, la scala di grigi seguita da tinta rimuove prima le informazioni cromatiche e poi riapplica colore al risultato di luminanza. Tinta seguita da scala di grigi rimuove nuovamente la tinta. Analogamente, la sostituzione alfa può sovrascrivere i valori alfa calcolati dalle operazioni precedenti, mentre la modulazione alfa preserva le differenze relative.

Il seguente esempio costruisce una catena di quattro operazioni, la salva come PPTX, riapre la presentazione, verifica sia i tipi di operazione sia il loro ordine, e rende il risultato riaperto:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220, 25);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80);

    presentation.save("image-transform-chain.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(reopenedShape, "com.aspose.slides.IPictureFrame")) {
        const reopenedTransform = reopenedShape.getPictureFormat().getPicture().getImageTransform();
        const orderIsPreserved = reopenedTransform.size() === 4 &&
            java.instanceOf(reopenedTransform.get_Item(0), "com.aspose.slides.IGrayScale") &&
            java.instanceOf(reopenedTransform.get_Item(1), "com.aspose.slides.ITint") &&
            java.instanceOf(reopenedTransform.get_Item(2), "com.aspose.slides.IBlur") &&
            java.instanceOf(reopenedTransform.get_Item(3), "com.aspose.slides.IAlphaModulateFixed");
        console.log(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        const renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", aspose.slides.ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        console.log("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

La collezione non impone una matrice di compatibilità che limiti le operazioni di colore, alfa e sfocatura a catene separate. Possono essere combinate, ma le combinazioni non sono sempre utili. Una sostituzione di colore fissa rimuove la variazione RGB prodotta da effetti di colore precedenti; la scala di grigi dopo duotone rimuove i due colori selezionati; e le operazioni alfa ceiling, floor, replacement o bi-level possono scartare i dettagli alfa creati in precedenza. Costruisci la catena secondo la sequenza di elaborazione dei pixel desiderata piuttosto che trattare i suoi elementi come flag di formattazione non ordinati.

<!-- visual-explanation:image-transform-effects:start -->
[![La stessa immagine passa prima attraverso la scala di grigi poi la tinta, e poi la tinta prima della scala di grigi. Le due immagini finali in scala di grigi hanno toni diversi.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In questa rappresentazione illustrativa di Aspose.Slides per .NET 26.11, una tinta di 220° al 25% lascia invariata l'immagine in scala di grigi. Applicare la stessa tinta prima della scala di grigi produce toni diversi.*
<!-- visual-explanation:image-transform-effects:end -->

## **Ispezionare valori modificabili ed effettivi**

Un'operazione modificabile è l'oggetto memorizzato in [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/). A seconda dell'effetto, può esporre membri scrivibili direttamente. Ad esempio, [Blur](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/) espone i valori scrivibili `radius` e `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphamodulatefixed/) espone un `amount` scrivibile, e [AlphaBiLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphabilevel/) espone una `threshold` scrivibile. Gli effetti di colore come [Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) espongono oggetti [ColorFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/) mutabili.

Alcune operazioni, incluse [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tint/), e [AlphaReplace](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphareplace/), non espongono i loro scalari di creazione come proprietà scrivibili. Per modificare tali impostazioni, rimuovi l'operazione e aggiungi una sostituzione nella posizione necessaria.

I dati effettivi restituiti da `getEffective()` sono calcolati e di sola lettura. Sono utili per risolvere i colori dipendenti dal tema e leggere i valori normalizzati che il renderer utilizza, ma non rappresentano un'altra superficie di modifica. Il seguente esempio enumera la catena e ispeziona i valori effettivi dove l'API corrispondente li fornisce:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (let index = 0; index < imageTransform.size(); index++) {
            const operation = imageTransform.get_Item(index);
            console.log(index + ": " + operation.getClass().getSimpleName());

            if (java.instanceOf(operation, "com.aspose.slides.IBrightnessContrast")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.ILuminance")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.IDuotone")) {
                const data = operation.getEffective();
                console.log("  Dark color: " + data.getColor1());
                console.log("  Light color: " + data.getColor2());
            } else if (java.instanceOf(operation, "com.aspose.slides.IColorReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement color: " + data.getColor());
            } else if (java.instanceOf(operation, "com.aspose.slides.IHSL")) {
                const data = operation.getEffective();
                console.log("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (java.instanceOf(operation, "com.aspose.slides.ITint")) {
                const data = operation.getEffective();
                console.log("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (java.instanceOf(operation, "com.aspose.slides.IBlur")) {
                const data = operation.getEffective();
                console.log("  Blur radius: " + data.getRadius() + " pt");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaModulateFixed")) {
                const data = operation.getEffective();
                console.log("  Alpha amount: " + data.getAmount() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaBiLevel")) {
                const data = operation.getEffective();
                console.log("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Gli effetti senza parametri come scala di grigi, alpha ceiling e alpha inverse hanno comunque un oggetto dati-effettivi, ma non ci sono impostazioni scalari da stampare. La loro presenza e posizione nella collezione sono le informazioni importanti.

## **Rimuovere o cancellare le trasformazioni immagine**

Usa [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) per rimuovere un'operazione per indice. Poiché gli indici cambiano dopo la rimozione, cerca prima il target e rimuovilo dopo l'enumerazione. Usa [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) per rimuovere l'intera catena.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        let blurIndex = -1;

        for (let index = 0; index < imageTransform.size(); index++) {
            if (java.instanceOf(imageTransform.get_Item(index), "com.aspose.slides.IBlur")) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            console.log("The blur operation was removed.");
        }

        imageTransform.clear();
        console.log("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Rimuovere o cancellare le trasformazioni cambia solo la formattazione dell'immagine. Non elimina, ricomprime o altera in altro modo la risorsa [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) riutilizzata.

## **Considerare i formati di presentazione e i target di esportazione**

Le trasformazioni immagine hanno origine in DrawingML, quindi PPTX è il formato modificabile preferito per le catene di effetti. Anche con PPTX, non tutte le operazioni hanno la stessa portabilità:

- Le operazioni standard di DrawingML come luminanza, scala di grigi, duotone, tinta, HSL, sfocatura e le comuni operazioni alfa hanno la migliore possibilità di sopravvivere a un round‑trip PPTX. Riapri sempre il file generato e ispeziona la collezione quando la conservazione è un requisito.
- [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) è un'estensione di Office 2010 piuttosto che l'operazione di luminanza standard di DrawingML. Può essere usata per il rendering in memoria, ma non è garantito che rimanga un'operazione [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) modificabile dopo il salvataggio e la riapertura del PPTX. Preferisci [addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) per regolazioni persistenti di luminosità e contrasto.
- Il formato PPT binario precede il modello completo di effetti DrawingML. Salvare in PPT può omettere operazioni non supportate, ridurre una catena a un sottoinsieme supportato o approssimare l'aspetto. Non usare PPT come formato di verifica per una catena modificabile complessa.
- Il rendering in PNG, JPEG, TIFF, PDF, SVG, HTML o altri output visivi applica la catena supportata all'aspetto renderizzato. Quegli output non contengono un [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) modificabile; i formati raster appiattiscono il risultato in pixel, e le esportazioni documento/vettoriale memorizzano la loro propria rappresentazione di rendering.
- Gli effetti non rendono un'immagine collegata autonoma. Il rendering di un'immagine collegata dipende ancora dalla disponibilità della risorsa collegata quando la presentazione è caricata.

Diversi visualizzatori di presentazioni possono renderizzare i casi limite in modo diverso, specialmente quando sono combinate diverse operazioni alfa o di quantizzazione colore. Per output critici, testa sia il round‑trip modificabile sia il formato di esportazione finale con la stessa versione di Aspose.Slides usata in produzione.

## **FAQ**

**Le trasformazioni di effetto immagine modificano i dati dell'immagine incorporata?**

No. Le operazioni appartengono al [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) usato dal riempimento immagine. I byte sottostanti di [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) rimangono invariati.

**Due riquadri immagine che riutilizzano la stessa immagine condivideranno i loro effetti?**

No. Riutilizzare un [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) evita dati immagine duplicati, ma ogni riquadro immagine normalmente ha un [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) separato e una collezione di trasformazioni dell'immagine.

**Gli effetti di colore, sfocatura e alfa possono essere combinati?**

Sì. La collezione li accetta in una catena ordinata. Considera cosa fa ogni operazione all'output della precedente, poiché le operazioni di sostituzione e soglia possono scartare dettagli di colore o alfa precedenti.

**Perché i valori effettivi sono di sola lettura?**

I dati effettivi rappresentano valori calcolati usati per il rendering, inclusi i colori risolti. Modifica l'operazione memorizzata nella collezione di trasformazioni dove esistono membri scrivibili; altrimenti rimuovila e aggiungi una sostituzione con nuovi parametri di creazione.

**Quale formato dovrei usare per preservare una catena di trasformazioni?**

Usa PPTX e verifica il file riaprendolo. Il vecchio PPT non può rappresentare il modello completo di effetti DrawingML, e i formati di esportazione renderizzati preservano l'aspetto anziché le operazioni di trasformazione modificabili.