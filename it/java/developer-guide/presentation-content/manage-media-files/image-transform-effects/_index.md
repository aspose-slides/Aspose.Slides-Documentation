---
title: Gestire gli effetti di trasformazione immagine nelle presentazioni con Java
linktitle: Effetti di trasformazione immagine
type: docs
weight: 11
url: /it/java/image-transform-effects/
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
- Java
- Aspose.Slides
description: "Applica, concatena, ispeziona, rimuovi e verifica gli effetti di trasformazione immagine per i riquadri immagine con Aspose.Slides per Java."
---
## **Panoramica**

Aspose.Slides rappresenta le regolazioni dell’immagine come una raccolta ordinata di operazioni di trasformazione dell’immagine. Per un riquadro immagine, inizia con il [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) del riquadro e accedi a [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#getImageTransform--). La [IImageTransformOperationCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/) restituita consente di aggiungere, enumerare, ispezionare, rimuovere e cancellare effetti senza riscrivere i byte originali dell’immagine.

Questo articolo dimostra un flusso di lavoro completo per luminosità e contrasto, trasformazioni di colore, sfocatura, trasparenza, catene di effetti ordinate, valori effettivi, rimozione e verifica round‑trip PPTX.

## **Comprendere la Proprietà degli Effetti e il Riutilizzo dell’Immagine**

Una risorsa immagine e l’immagine che la visualizza sono oggetti diversi:

- [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) memorizza o fa riferimento ai dati immagine di origine posseduti dalla presentazione.
- [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) appartiene a un riempimento immagine e si riferisce a una risorsa immagine memorizzando la collezione di trasformazioni dell’immagine.
- [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) è la forma della diapositiva che possiede il riempimento immagine pertinente, la geometria, le impostazioni di ritaglio e altre formattazioni a livello di riquadro.

Pertanto, le operazioni di trasformazione dell’immagine non modificano i byte in [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/). Quando lo stesso `IPPImage` viene passato a [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) più di una volta, ogni nuovo riquadro immagine riceve il proprio `ISlidesPicture` e la propria collezione di trasformazioni. Applicare la scala di grigi a un riquadro non rende in scala di grigi gli altri riquadri, anche se tutti riutilizzano la stessa risorsa immagine incorporata.

Lo stesso modello `ISlidesPicture.getImageTransform` è utilizzato anche da altri riempimenti immagine, come una forma o lo sfondo della diapositiva. Gli esempi seguenti si concentrano sui riquadri immagine.

## **Usare Intervalli e Unità di Parametro Valide**

I metodi mostrati usano i seguenti intervalli semantici e unità. Mantieni i valori in questi intervalli anche se una versione specifica della libreria non rifiuta immediatamente ogni valore fuori intervallo; il formato di destinazione della presentazione può normalizzare, omettere o rifiutare dati non validi durante il salvataggio o quando PowerPoint apre il file.

| Operazione | Parametri | Intervallo valido e unità |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` fino a `100`, percentuale; `0` lascia la componente invariata. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Nessuno | Nessun parametro numerico. Alpha rimane invariato. |
| [addDuotoneEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Due colori per pixel scuri e chiari. I canali RGB e alpha in `java.awt.Color` usano valori da `0` a `255`. |
| [addTintEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Hue è da `0` (incluso) a `360` (escluso), in gradi; amount è da `-100` a `100`, percentuale. |
| [addHSLEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Hue è da `0` (incluso) a `360` (escluso), in gradi; saturation e luminance sono da `-100` a `100`, percentuale. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Il colore di sostituzione utilizza valori di canale da `0` a `255`. I valori alpha esistenti rimangono invariati. |
| [addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Radius è non negativo e misurato in punti; `grow` è un Boolean che controlla se il contenuto sfocato può estendersi oltre i limiti originali. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Percentuale non negativa. Usa `0`‑`100` per la normale scala di opacità: `0` è completamente trasparente e `100` preserva l’alpha esistente. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0`‑`100`, percentuale di opacità. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0`‑`100`, percentuale di soglia alpha. Valori inferiori diventano trasparenti; valori pari o superiori diventano opachi. |

Per la modulazione alpha fissa, trasparenza e opacità sono complementari. Ad esempio, il 35 % di trasparenza corrisponde a un valore di modulazione alpha del 65 %.

## **Applicare Luminosità e Contrasto**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) restituisce un’operazione [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/). Le impostazioni scalari vengono fornite al momento della creazione dell’operazione. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/#getEffective--) restituisce valori calcolati in sola lettura che possono essere ispezionati o registrati.

L’esempio seguente aumenta la luminosità del 15 % e il contrasto del 20 %, quindi rende un’anteprima senza modificare l’immagine incorporata:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    IBrightnessContrast brightnessContrast = imageTransform.addBrightnessContrastEffect(15f, 20f);

    IBrightnessContrastEffectiveData effectiveValues = brightnessContrast.getEffective();
    System.out.println("Brightness: " + effectiveValues.getBrightness() + "%");
    System.out.println("Contrast: " + effectiveValues.getContrast() + "%");

    IImage preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) è un’estensione di effetti immagine Office 2010 ed è meno portabile dell’effetto di luminanza standard DrawingML. Quando luminosità e contrasto devono rimanere modificabili dopo un round‑trip PPTX, usa [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) e verifica il risultato dopo aver riaperto il file. La sezione sulle limitazioni di formato spiega questa distinzione in dettaglio.

## **Applicare Trasformazioni di Colore**

Gli effetti di colore possono essere applicati in modo indipendente a diversi riquadri immagine che riutilizzano una stessa risorsa. L’esempio seguente crea cinque riquadri e applica scala di grigi, duotono, tinta, regolazione HSL e sostituzione colore.

[IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) contiene due parametri colore modificabili indipendentemente: `color1` mappa i pixel scuri, mentre `color2` mappa i pixel chiari. Questo lo rende un esempio utile di effetto le cui impostazioni sono più complesse di un singolo valore scalare.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(new Color(0, 0, 128));
    duotone.getColor2().setColor(new Color(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(new Color(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) sostituisce il colore di ogni pixel con un colore fisso preservando l’alpha. È diverso da [addColorChangeEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), che mappa un colore sorgente in un altro e espone entrambi i formati colore sorgente e destinazione.

### **Applicare una Soglia di Luminanza**

Una soglia di luminanza può rendere più distinguibili i segni deboli su una pagina scansionata rispetto allo sfondo. [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) preserva le sfumature intermedie di grigio. [addBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) mappa la luminanza a nero o bianco, mentre [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) applica una soglia all’opacità.

La soglia di luminanza varia dallo 0 % al 100 %, inclusi. I pixel sotto la soglia diventano neri. I pixel al di sopra o uguali diventano bianchi. Aumentare la soglia rende più tonalità nere perché più pixel cadono sotto il limite.

Scarica [grayscale‑swatches.png](grayscale-swatches.png) nella directory di lavoro. Ogni etichetta indica il livello di grigio originale su una scala da 0 a 255. L’esempio posiziona l’originale accanto a due copie e salva la soglia di ciascuna copia nella presentazione.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] imageData = Files.readAllBytes(Paths.get("grayscale-swatches.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    String[] captions = { "Original", "Threshold 20%", "Threshold 60%" };
    IPictureFrame[] frames = new IPictureFrame[captions.length];
    for (int i = 0; i < captions.length; i++) {
        float x = 12 + 240 * i;
        IAutoShape label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        frames[i] = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20f);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60f);
    
    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Apri la presentazione di output in PowerPoint per confrontare i tre riquadri. Il campione etichettato 96 ha circa il 38 % di luminanza (96 su 255). Diventa bianco alla soglia del 20 % e nero alla soglia del 60 %.

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **Aggiungere Sfocatura, Trasparenza e Effetti Alpha**

[addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) influisce su tutti i canali colore, incluso l’alpha. Imposta `grow` su `true` quando il bordo sfocato può estendersi oltre i limiti originali dell’immagine.

Per una trasparenza uniforme, usa [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Moltiplica ogni valore alpha esistente, così i pixel parzialmente trasparenti rimangono proporzionalmente diversi. [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) invece assegna un unico valore alpha a tutti i pixel. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) converte l’alpha in due livelli basati su una soglia.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    IPictureFrame blurredFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
    IBlur blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    IPictureFrame transparentFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
    IAlphaModulateFixed alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65f);
    alphaModulate.setAmount(60f);

    IPictureFrame uniformAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55f);

    IPictureFrame binaryAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
    IAlphaBiLevel alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50f);
    alphaBiLevel.setThreshold(45f);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Altre operazioni alpha senza parametri includono [addAlphaCeilingEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--), che rende ogni alpha diverso da zero completamente opaco; [addAlphaFloorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--), che rende ogni alpha inferiore al 100 % completamente trasparente; e [addAlphaInverseEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--), che inverte l’alpha con `100% - alpha`.

## **Costruire una Catena di Effetti Ordinata**

Ogni metodo `add...Effect` aggiunge una nuova operazione alla fine della collezione. Il renderer utilizza la collezione come pipeline ordinata: l’output dell’operazione 0 diventa l’input dell’operazione 1, e così via. Di conseguenza, le stesse operazioni in un ordine diverso possono produrre un’immagine differente.

Ad esempio, scala di grigi seguita da tinta rimuove prima le informazioni cromatiche e poi ricolorizza il risultato di luminanza. Tinta seguita da scala di grigi rimuove nuovamente la tinta. Allo stesso modo, la sostituzione alpha può sovrascrivere i valori alpha calcolati dalle operazioni precedenti, mentre la modulazione alpha preserva le loro differenze relative.

L’esempio seguente costruisce una catena di quattro operazioni, la salva come PPTX, riapre la presentazione, verifica sia i tipi di operazione sia il loro ordine e rende il risultato riaperto:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220f, 25f);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80f);

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    IShape reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (reopenedShape instanceof IPictureFrame) {
        IPictureFrame reopenedFrame = (IPictureFrame) reopenedShape;
        IImageTransformOperationCollection reopenedTransform = reopenedFrame.getPictureFormat().getPicture().getImageTransform();
        boolean orderIsPreserved = reopenedTransform.size() == 4 && 
                reopenedTransform.get_Item(0) instanceof IGrayScale && 
                reopenedTransform.get_Item(1) instanceof ITint && 
                reopenedTransform.get_Item(2) instanceof IBlur && 
                reopenedTransform.get_Item(3) instanceof IAlphaModulateFixed;
        System.out.println(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        IImage renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        System.out.println("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

La collezione non impone una matrice di compatibilità che limita colori, alpha e operazioni di sfocatura a catene separate. Possono essere combinati, ma le combinazioni non sono sempre utili. Una sostituzione colore fissa rimuove la variazione RGB prodotta da effetti colore precedenti; la scala di grigi dopo duotono rimuove i due colori selezionati; e le operazioni alpha ceiling, floor, replacement o bi‑level possono scartare i dettagli alpha creati in precedenza. Costruisci la catena secondo la sequenza di elaborazione pixel desiderata piuttosto che trattare gli elementi come flag di formattazione non ordinati.

<!-- visual-explanation:image-transform-effects:start -->
[![La stessa immagine passa prima attraverso la scala di grigi poi la tinta, e viceversa. Le due immagini finali in scala di grigi hanno tonalità diverse.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In questa illustrazione di Aspose.Slides per .NET 26.11, una tinta di 220° al 25 % lascia invariata l’immagine in scala di grigi. Applicare la stessa tinta prima della scala di grigi produce tonalità diverse.*
<!-- visual-explanation:image-transform-effects:end -->

## **Ispezionare Valori Modificabili ed Effettivi**

Un’operazione modificabile è l’oggetto memorizzato in `ISlidesPicture.getImageTransform`. A seconda dell’effetto, può esporre membri scrivibili direttamente. Ad esempio, [IBlur](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/) espone i valori scrivibili `radius` e `grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/java/com.aspose.slides/ialphamodulatefixed/) espone un valore scrivibile `amount`, e [IAlphaBiLevel](https://reference.aspose.com/slides/java/com.aspose.slides/ialphabilevel/) espone una soglia scrivibile `threshold`. Gli effetti colore come [IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) espongono oggetti [IColorFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/) modificabili.

Alcune interfacce di operazione, tra cui [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/java/com.aspose.slides/itint/), e [IAlphaReplace](https://reference.aspose.com/slides/java/com.aspose.slides/ialphareplace/), non espongono gli scalari di creazione come proprietà scrivibili. Per modificare tali impostazioni, rimuovi l’operazione e aggiungi una sostituzione nella posizione desiderata.

I dati effettivi restituiti da `getEffective()` sono calcolati e in sola lettura. Sono utili per risolvere i colori dipendenti dal tema e per leggere i valori normalizzati utilizzati dal renderer, ma non costituiscono un ulteriore livello di modifica. L’esempio seguente enumera la catena e ispeziona i valori effettivi dove l’API corrispondente li fornisce:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (int index = 0; index < imageTransform.size(); index++) {
            IImageTransformOperation operation = imageTransform.get_Item(index);
            System.out.println(index + ": " + operation.getClass().getSimpleName());

            if (operation instanceof IBrightnessContrast) {
                IBrightnessContrastEffectiveData data = ((IBrightnessContrast) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof ILuminance) {
                ILuminanceEffectiveData data = ((ILuminance) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof IDuotone) {
                IDuotoneEffectiveData data = ((IDuotone) operation).getEffective();
                System.out.println("  Dark color: " + data.getColor1());
                System.out.println("  Light color: " + data.getColor2());
            } else if (operation instanceof IColorReplace) {
                IColorReplaceEffectiveData data = ((IColorReplace) operation).getEffective();
                System.out.println("  Replacement color: " + data.getColor());
            } else if (operation instanceof IHSL) {
                IHSLEffectiveData data = ((IHSL) operation).getEffective();
                System.out.println("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (operation instanceof ITint) {
                ITintEffectiveData data = ((ITint) operation).getEffective();
                System.out.println("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (operation instanceof IBlur) {
                IBlurEffectiveData data = ((IBlur) operation).getEffective();
                System.out.println("  Blur radius: " + data.getRadius() + " pt");
            } else if (operation instanceof IAlphaModulateFixed) {
                IAlphaModulateFixedEffectiveData data = ((IAlphaModulateFixed) operation).getEffective();
                System.out.println("  Alpha amount: " + data.getAmount() + "%");
            } else if (operation instanceof IAlphaReplace) {
                IAlphaReplaceEffectiveData data = ((IAlphaReplace) operation).getEffective();
                System.out.println("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (operation instanceof IAlphaBiLevel) {
                IAlphaBiLevelEffectiveData data = ((IAlphaBiLevel) operation).getEffective();
                System.out.println("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Gli effetti senza parametri, come scala di grigi, alpha ceiling e alpha inverse, possiedono comunque un oggetto di dati effettivi, ma non hanno impostazioni scalari da stampare. La loro presenza e posizione nella collezione sono le informazioni importanti.

## **Rimuovere o Cancellare le Trasformazioni dell’Immagine**

Usa [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) per rimuovere un’operazione per indice. Poiché gli indici cambiano dopo la rimozione, cerca prima il bersaglio e rimuovilo dopo l’enumerazione. Usa [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/imagetransformoperationcollection/#clear--) per eliminare l’intera catena.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        int blurIndex = -1;

        for (int index = 0; index < imageTransform.size(); index++) {
            if (imageTransform.get_Item(index) instanceof IBlur) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            System.out.println("The blur operation was removed.");
        }

        imageTransform.clear();
        System.out.println("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Rimuovere o cancellare le trasformazioni modifica solo la formattazione dell’immagine. Non elimina, ricomprime o altera in altro modo la risorsa [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) riutilizzata.

## **Considerare i Formati di Presentazione e le Destinazioni di Esportazione**

Le trasformazioni immagine originano in DrawingML, perciò PPTX è il formato modificabile preferito per le catene di effetti. Anche con PPTX, non tutte le operazioni hanno la stessa portabilità:

- Le operazioni DrawingML standard come luminanza, scala di grigi, duotono, tinta, HSL, sfocatura e le operazioni alpha comuni hanno la migliore possibilità di sopravvivere a un round‑trip PPTX. Riapri sempre il file generato e ispeziona la collezione quando la preservazione è un requisito.
- [BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) è un’estensione Office 2010 piuttosto che l’operazione di luminanza DrawingML standard. Può essere usata per il rendering in memoria, ma non è garantito che rimanga un [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/) modificabile dopo il salvataggio e la riapertura di PPTX. Preferisci [addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) per aggiustamenti di luminosità e contrasto persistenti.
- Il formato binario PPT precede il modello completo di effetti DrawingML. Il salvataggio in PPT può omettere operazioni non supportate, ridurre una catena a un sottoinsieme supportato o approssimare l’aspetto. Non usare PPT come formato di verifica per una catena complessa modificabile.
- Il rendering in PNG, JPEG, TIFF, PDF, SVG, HTML o altri output visivi applica la catena supportata all’aspetto renderizzato. Questi output non contengono una [IImageTransformOperationCollection] modificabile; i formati raster appiattiscono il risultato in pixel, e le esportazioni documento/vettoriali memorizzano la propria rappresentazione di rendering.
- Gli effetti non rendono un’immagine collegata autonoma. Il rendering di un’immagine collegata dipende ancora dal fatto che la risorsa collegata sia disponibile al caricamento della presentazione.

Diversi consumer di presentazioni potrebbero rendere casi limite in modo differente, specialmente quando più operazioni alpha o di quantizzazione colore sono combinate. Per output critici, testa sia il round‑trip modificabile sia il formato di esportazione finale con la stessa versione di Aspose.Slides usata in produzione.

## **FAQ**

**Le trasformazioni di immagine modificano i dati dell’immagine incorporata?**

No. Le operazioni appartengono al `ISlidesPicture` utilizzato dal riempimento immagine. I byte sottostanti di `IPPImage` rimangono invariati.

**Due riquadri immagine che riutilizzano la stessa immagine condividono i loro effetti?**

No. Riutilizzare un `IPPImage` evita dati immagine duplicati, ma ogni riquadro immagine ha normalmente un `ISlidesPicture` separato e una collezione di trasformazioni immagine separata.

**È possibile combinare effetti di colore, sfocatura e alpha?**

Sì. La collezione li accetta in una singola catena ordinata. Considera cosa fa ogni operazione sull’output della precedente, poiché le operazioni di sostituzione e soglia possono scartare dettagli colore o alpha precedenti.

**Perché i valori effettivi sono di sola lettura?**

I dati effettivi rappresentano valori calcolati usati per il rendering, inclusi i colori risolti. Modifica l’operazione memorizzata nella collezione di trasformazioni dove esistono membri scrivibili; altrimenti rimuovila e aggiungi una sostituzione con nuovi parametri di creazione.

**Quale formato devo usare per preservare una catena di trasformazioni?**

Usa PPTX e verifica il file riaprendolo. Il legacy PPT non può rappresentare l’intero modello di effetti DrawingML, e i formati di esportazione renderizzati preservano solo l’aspetto, non le operazioni di trasformazione modificabili.