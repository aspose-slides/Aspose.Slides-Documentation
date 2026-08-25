---
title: Gestire gli effetti di trasformazione immagine nelle presentazioni con JavaScript
linktitle: Effetti di trasformazione immagine
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
- effetto alpha
- catena di effetti
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Applicare, concatenare, ispezionare, rimuovere e verificare gli effetti di trasformazione immagine per i fotogrammi con Aspose.Slides per Node.js tramite Java."
---
## **Panoramica**

Aspose.Slides rappresenta le regolazioni delle immagini come una raccolta ordinata di operazioni di trasformazione dell’immagine. Per un fotogramma immagine, inizia con il [Picture](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picture/) del fotogramma e accedi a [Picture.getImageTransform](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picture/). La [ImageTransformOperationCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagetransformoperationcollection/) restituita permette di aggiungere, enumerare, ispezionare, rimuovere e cancellare effetti senza riscrivere i byte originali dell’immagine.

Questo articolo dimostra un flusso di lavoro completo per luminosità e contrasto, trasformazioni di colore, sfocatura, trasparenza, catene di effetti ordinate, valori effettivi, rimozione e verifica round‑trip PPTX.

## **Comprendere la proprietà degli effetti e il riutilizzo dell’immagine**

Una risorsa immagine e l’immagine che la visualizza sono oggetti diversi:

- [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) memorizza o fa riferimento ai dati immagine di origine posseduti dalla presentazione.
- [Picture](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picture/) appartiene a un riempimento immagine e fa riferimento a una risorsa immagine conservando la raccolta di trasformazioni dell’immagine.
- [PictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframe/) è la forma della diapositiva che possiede il relativo riempimento immagine, la geometria, le impostazioni di ritaglio e altra formattazione a livello di fotogramma.

Pertanto, le operazioni di trasformazione dell’immagine non modificano i byte in [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/). Quando la stessa [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) viene passata a [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/) più di una volta, ogni nuovo fotogramma immagine riceve il proprio [Picture](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picture/) e la propria raccolta di trasformazioni. Applicare la scala di grigi a un fotogramma non rende gli altri fotogrammi in scala di grigi, anche se tutti riutilizzano la stessa risorsa immagine incorporata.

Lo stesso modello [Picture.getImageTransform](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picture/) è utilizzato anche da altri riempimenti immagine, come una forma o lo sfondo della diapositiva. Gli esempi seguenti si concentrano sui fotogrammi immagine.

## **Utilizzare intervalli di parametri e unità validi**

I metodi dimostrati utilizzano i seguenti intervalli semantici e unità. Mantieni i valori entro questi intervalli anche se una versione particolare della libreria non rifiuta immediatamente ogni valore fuori range; il formato di destinazione della presentazione può normalizzare, omettere o rifiutare dati non validi durante il salvataggio o quando PowerPoint apre il file.

| Operazione | Parametri | Intervallo e unità validi |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | da `-100` a `100`, percento; `0` mantiene il componente invariato. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagetransformoperationcollection/) | Nessuno | Nessun parametro numerico. Alpha rimane invariato. |
| [addDuotoneEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | Due colori per pixel scuri e chiari. I canali RGB e alpha in `java.awt.Color` usano valori da `0` a `255`. |
| [addTintEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | Hue è compreso tra `0` (inclusivo) e `360` (esclusivo), in gradi; amount è da `-100` a `100`, percento. |
| [addHSLEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | Hue è da `0` (inclusivo) a `360` (esclusivo), in gradi; saturation e luminance sono da `-100` a `100`, percento. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | Il colore di sostituzione usa valori di canale da `0` a `255`. I valori alpha esistenti rimangono invariati. |
| [addBlurEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | Radius è non negativo e misurato in punti; `grow` è un Boolean che controlla se il contenuto sfocato può estendersi oltre i limiti originali. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | Percento non negativo. Usa `0` a `100` per la scala di opacità ordinaria: `0` è completamente trasparente e `100` preserva l’alpha esistente. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | Da `0` a `100`, percento di opacità. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | Da `0` a `100`, percento di soglia alpha. I valori inferiori diventano trasparenti; i valori pari o superiori diventano opachi. |

Per la modulazione alpha fissa, trasparenza e opacità sono complementari. Ad esempio, il 35 % di trasparenza corrisponde a una modulazione alpha del 65 %.

## **Applicare luminosità e contrasto**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagetransformoperationcollection/) restituisce un’operazione [BrightnessContrast](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/brightnesscontrast/). Le impostazioni scalari sono fornite al momento della creazione dell’operazione. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/brightnesscontrast/) restituisce valori calcolati read‑only che possono essere ispezionati o registrati.

L’esempio seguente aumenta la luminosità del 15 % e il contrasto del 20 %, poi genera un’anteprima senza modificare l’immagine incorporata:

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

[BrightnessContrast](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/brightnesscontrast/) è un’estensione degli effetti immagine di Office 2010 e è meno portabile dell’effetto luminanza standard di DrawingML. Quando luminosità e contrasto devono rimanere modificabili dopo un round‑trip PPTX, usa [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagetransformoperationcollection/) e verifica il risultato dopo aver riaperto il file. La sezione limitazioni di formato spiega questa distinzione in maggior dettaglio.

## **Applicare trasformazioni di colore**

Gli effetti colore possono essere applicati indipendentemente a diversi fotogrammi immagine che riutilizzano una stessa risorsa immagine. L’esempio seguente crea cinque fotogrammi e applica scala di grigi, duotono, tinta, regolazione HSL e sostituzione colore.

[Duotone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/duotone/) contiene due parametri colore modificabili in modo indipendente: `color1` mappa i pixel scuri, mentre `color2` mappa i pixel chiari. Questo lo rende un esempio utile di effetto le cui impostazioni sono più complesse di un singolo valore scalare.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagetransformoperationcollection/) sostituisce il colore di ogni pixel con un colore fisso, mantenendo l’alpha. È diverso da [addColorChangeEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagetransformoperationcollection/), che mappa un colore sorgente a un altro e espone entrambi i formati di colore sorgente e destinazione.

## **Aggiungere sfocatura, trasparenza e effetti alpha**

[addBlurEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagetransformoperationcollection/) influisce su tutti i canali colore, incluso alpha. Imposta `grow` a `true` quando il bordo sfocato può estendersi oltre i limiti originali dell’immagine.

Per una trasparenza uniforme, usa [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagetransformoperationcollection/). Moltiplica ogni valore alpha esistente, così i pixel parzialmente trasparenti rimangono proporzionalmente diversi. [addAlphaReplaceEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagetransformoperationcollection/) invece assegna un unico valore alpha a tutti i pixel. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagetransformoperationcollection/) converte l’alpha in due livelli basati su una soglia.

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

Altre operazioni alpha senza parametri includono [addAlphaCeilingEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagetransformoperationcollection/), che rende ogni alpha diverso da zero completamente opaco; [addAlphaFloorEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagetransformoperationcollection/), che rende ogni alpha inferiore al 100 % completamente trasparente; e [addAlphaInverseEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagetransformoperationcollection/), che trasforma l’alpha in `100% - alpha`.

## **Costruire una catena di effetti ordinata**

Ogni metodo `add...Effect` aggiunge una nuova operazione alla fine della raccolta. Il renderer utilizza la raccolta come pipeline ordinata: l’output dell’operazione 0 diventa l’input dell’operazione 1 e così via. Di conseguenza, le stesse operazioni in ordine diverso possono produrre un’immagine diversa.

Ad esempio, scala di grigi seguito da tinta rimuove prima le informazioni cromatiche e poi ricolora il risultato di luminanza. Tinta seguita da scala di grigi rimuove nuovamente la tinta. Allo stesso modo, la sostituzione alpha può sovrascrivere i valori alpha calcolati da operazioni precedenti, mentre la modulazione alpha preserva le differenze relative.

L’esempio seguente costruisce una catena di quattro operazioni, la salva come PPTX, riapre la presentazione, verifica sia i tipi di operazione sia il loro ordine, e rende il risultato riaperto:

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

La raccolta non impone una matrice di compatibilità che limiti le operazioni di colore, alpha e sfocatura a catene separate. Possono essere combinate, ma le combinazioni non sono sempre utili. Una sostituzione colore fissa elimina la variazione RGB prodotta da effetti di colore precedenti; la scala di grigi dopo duotono elimina i due colori selezionati; e le operazioni alpha ceiling, floor, replacement o bi‑level possono scartare i dettagli alpha creati in precedenza. Costruisci la catena secondo la sequenza di elaborazione dei pixel desiderata anziché trattare i suoi elementi come flag di formattazione non ordinati.

## **Ispezionare valori modificabili ed effettivi**

Un’operazione modificabile è l’oggetto memorizzato in [Picture.getImageTransform](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picture/). A seconda dell’effetto, può esporre membri scrivibili direttamente. Per esempio, [Blur](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/blur/) espone i valori scrivibili `radius` e `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/alphamodulatefixed/) espone un `amount` scrivibile, e [AlphaBiLevel](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/alphabilevel/) espone un `threshold` scrivibile. Gli effetti colore come [Duotone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/duotone/) espongono oggetti [ColorFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/colorformat/) mutabili.

Alcune operazioni, inclusi [BrightnessContrast](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tint/), e [AlphaReplace](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/alphareplace/), non espongono i loro scalari di creazione come proprietà scrivibili. Per modificare tali impostazioni, rimuovi l’operazione e aggiungi una sostituzione nella posizione richiesta.

I dati effettivi restituiti da `getEffective()` sono calcolati e read‑only. Sono utili per risolvere i colori dipendenti dal tema e per leggere i valori normalizzati usati dal renderer, ma non costituiscono un’altra superficie di editing. L’esempio seguente enumera la catena e ispeziona i valori effettivi dove l’API corrispondente li fornisce:

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

Gli effetti senza parametri, come scala di grigi, alpha ceiling e alpha inverse, hanno comunque un oggetto di dati effettivi, ma non ci sono impostazioni scalari da stampare. La loro presenza e posizione nella raccolta sono le informazioni importanti.

## **Rimuovere o cancellare le trasformazioni immagine**

Usa [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagetransformoperationcollection/) per rimuovere un’operazione per indice. Poiché gli indici cambiano dopo la rimozione, cerca prima il target e rimuovilo dopo l’enumerazione. Usa [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagetransformoperationcollection/) per rimuovere l’intera catena.

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

Rimuovere o cancellare le trasformazioni modifica solo la formattazione dell’immagine. Non elimina, ricomprime o altera in altro modo la risorsa [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) riutilizzata.

## **Considerare i formati di presentazione e i target di esportazione**

Le trasformazioni immagine originano in DrawingML, quindi PPTX è il formato modificabile preferito per le catene di effetti. Anche con PPTX, non tutte le operazioni hanno la stessa portabilità:

- Le operazioni standard di DrawingML come luminanza, scala di grigi, duotono, tinta, HSL, sfocatura e le comuni operazioni alpha hanno la migliore probabilità di sopravvivere a un round‑trip PPTX. Riapri sempre il file generato e ispeziona la raccolta quando la preservazione è un requisito.
- [BrightnessContrast](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/brightnesscontrast/) è un’estensione di Office 2010 piuttosto che l’operazione luminanza standard di DrawingML. Può essere usato per il rendering in memoria, ma non è garantito che rimanga un’operazione [BrightnessContrast](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/brightnesscontrast/) modificabile dopo il salvataggio e la riapertura di PPTX. Preferisci [addLuminanceEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagetransformoperationcollection/) per regolazioni persistenti di luminosità e contrasto.
- Il formato binario PPT precede il modello completo di effetti DrawingML. Il salvataggio in PPT può omettere operazioni non supportate, ridurre una catena a un sottoinsieme supportato o approssimare l’aspetto. Non usare PPT come formato di verifica per una catena modificabile complessa.
- Il rendering in PNG, JPEG, TIFF, PDF, SVG, HTML o altri output visivi applica la catena supportata all’aspetto renderizzato. Questi output non contengono una [ImageTransformOperationCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagetransformoperationcollection/) modificabile; i formati raster appiattiscono il risultato in pixel, e le esportazioni documento/vettoriale memorizzano la propria rappresentazione di rendering.
- Gli effetti non rendono un’immagine collegata autonoma. Il rendering di un’immagine collegata dipende comunque dalla disponibilità della risorsa collegata quando la presentazione viene caricata.

Diversi consumatori di presentazioni possono renderizzare i casi limite in modo diverso, specialmente quando più operazioni alpha o di quantizzazione colore sono combinate. Per output critici, testa sia il round‑trip modificabile sia il formato di esportazione finale con la stessa versione di Aspose.Slides usata in produzione.

## **FAQ**

**Le trasformazioni immagine modificano i dati dell’immagine incorporata?**

No. Le operazioni appartengono al [Picture](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picture/) utilizzato dal riempimento immagine. I byte sottostanti di [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) rimangono invariati.

**Due fotogrammi immagine che riutilizzano la stessa immagine condivideranno i loro effetti?**

No. Riutilizzare una [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) evita dati immagine duplicati, ma ogni fotogramma immagine ha normalmente un proprio [Picture](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picture/) e una propria raccolta di trasformazioni immagine.

**È possibile combinare effetti colore, sfocatura e alpha?**

Sì. La raccolta li accetta in una singola catena ordinata. Considera cosa fa ogni operazione sull’output della precedente, poiché le operazioni di sostituzione e soglia possono scartare dettagli colore o alpha precedenti.

**Perché i valori effettivi sono read‑only?**

I dati effettivi rappresentano valori calcolati usati per il rendering, inclusi i colori risolti. Modifica l’operazione memorizzata nella raccolta di trasformazioni dove esistono membri scrivibili; altrimenti rimuovila e aggiungi una sostituzione con nuovi parametri di creazione.

**Quale formato devo usare per preservare una catena di trasformazioni?**

Usa PPTX e verifica il file riaprendolo. PPT legacy non può rappresentare l’intero modello di effetti DrawingML, e i formati di esportazione renderizzati preservano solo l’aspetto anziché le operazioni di trasformazione modificabili.