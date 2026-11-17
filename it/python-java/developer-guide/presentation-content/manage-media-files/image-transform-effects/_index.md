---
title: Gestire gli effetti di trasformazione dell'immagine nelle presentazioni con Python
linktitle: Effetti di trasformazione dell'immagine
type: docs
weight: 11
url: /it/python-java/image-transform-effects/
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
- Python
- Java
- Aspose.Slides
description: "Applica, concatena, ispeziona, rimuovi e verifica gli effetti di trasformazione dell'immagine per le cornici immagine con Aspose.Slides per Python via Java."
---
## **Panoramica**

Aspose.Slides rappresenta le regolazioni delle immagini come una raccolta ordinata di operazioni di trasformazione dell'immagine. Per una cornice immagine, si parte dal [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) della cornice e si accede a [Picture.getImageTransform](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#getImageTransform). La [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/) restituita consente di aggiungere, enumerare, ispezionare, rimuovere e cancellare gli effetti senza riscrivere i byte originali dell’immagine.

Questo articolo dimostra un flusso di lavoro completo per luminosità e contrasto, trasformazioni di colore, sfocatura, trasparenza, catene di effetti ordinate, valori effettivi, rimozione e verifica round‑trip PPTX.

## **Comprendere la proprietà degli effetti e il riutilizzo delle immagini**

Una risorsa immagine e l’immagine che la visualizza sono oggetti diversi:

- [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) memorizza o fa riferimento ai dati immagine sorgente posseduti dalla presentazione.
- [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) appartiene a un riempimento immagine e si riferisce a una risorsa immagine memorizzando al contempo la collezione di trasformazioni dell’immagine.
- [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) è la forma della diapositiva che possiede il relativo riempimento immagine, la geometria, le impostazioni di ritaglio e altri formati a livello di cornice.

Pertanto, le operazioni di trasformazione dell’immagine non modificano i byte in [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/). Quando lo stesso `PPImage` viene passato a [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) più di una volta, ogni nuova cornice immagine riceve il proprio `Picture` e la propria collezione di trasformazioni. Applicare la scala di grigi a una cornice non rende le altre cornici in scala di grigi, anche se tutte riutilizzano la stessa risorsa immagine incorporata.

Lo stesso modello `Picture.getImageTransform` è usato anche da altri riempimenti immagine, come una forma o lo sfondo della diapositiva. Gli esempi seguenti si concentrano sulle cornici immagine.

## **Usare intervalli di parametri validi e unità**

I metodi mostrati usano i seguenti intervalli semantici e unità. Mantieni i valori in questi intervalli anche se una specifica versione della libreria non rifiuta immediatamente ogni valore fuori intervallo; il formato di destinazione della presentazione può normalizzare, omettere o rifiutare dati non validi durante il salvataggio o quando PowerPoint apre il file.

| Operazione | Parametri | Intervallo valido e unità |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | da `-100` a `100`, percento; `0` lascia il componente invariato. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | Nessuno | Nessun parametro numerico. Alpha rimane invariato. |
| [addDuotoneEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | Due colori per pixel scuri e chiari. I canali RGB e alfa in `java.awt.Color` usano valori da `0` a `255`. |
| [addTintEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | Hue è da `0` (incluso) a `360` (escluso), in gradi; amount è da `-100` a `100`, percento. |
| [addHSLEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | Hue è da `0` (incluso) a `360` (escluso), in gradi; saturazione e luminanza sono da `-100` a `100`, percento. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | Il colore di sostituzione usa valori di canale da `0` a `255`. I valori alfa esistenti rimangono invariati. |
| [addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | Il raggio è non negativo e misurato in punti; `grow` è un Boolean che controlla se il contenuto sfocato può estendersi oltre i limiti originali. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | Percento non negativo. Usa `0`‑`100` per una normale scala di opacità: `0` è completamente trasparente e `100` preserva l’alfa esistente. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | Da `0` a `100`, percento di opacità. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | Da `0` a `100`, percento di soglia alfa. I valori al di sotto diventano trasparenti; i valori pari o superiori diventano opachi. |

Per la modulazione alfa fissa, trasparenza e opacità sono complementari. Per esempio, il 35 % di trasparenza corrisponde a una modulazione alfa del 65 %.

## **Applicare luminosità e contrasto**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) restituisce un’operazione [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/). Le impostazioni scalari sono fornite quando l’operazione è creata. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/#getEffective) restituisce valori calcolati di sola lettura che possono essere ispezionati o registrati.

L’esempio seguente aumenta la luminosità del 15 % e il contrasto del 20 %, quindi genera un’anteprima senza modificare l’immagine incorporata:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    brightness_contrast = image_transform.addBrightnessContrastEffect(15.0, 20.0)

    effective_values = brightness_contrast.getEffective()
    print("Brightness: ", effective_values.getBrightness(), "%", sep="")
    print("Contrast: ", effective_values.getContrast(), "%", sep="")

    preview = slide.getImage()
    try:
        preview.save("brightness-contrast-preview.png", ImageFormat.Png)
    finally:
        preview.dispose()
finally:
    presentation.dispose()
```

[BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) è un’estensione di effetto immagine Office 2010 e è meno portabile dell’effetto di luminanza standard DrawingML. Quando luminosità e contrasto devono rimanere modificabili dopo un round‑trip PPTX, usa [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) e verifica il risultato dopo aver riaperto il file. La sezione limitazioni del formato spiega questa distinzione in maggiore dettaglio.

## **Applicare trasformazioni di colore**

Gli effetti colore possono essere applicati indipendentemente a diverse cornici immagine che riutilizzano la stessa risorsa immagine. L’esempio seguente crea cinque cornici e applica scala di grigi, duotone, tinta, regolazione HSL e sostituzione colore.

[Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) contiene due parametri colore modificabili indipendentemente: `color1` mappa i pixel scuri, mentre `color2` mappa i pixel chiari. Questo lo rende un esempio utile di effetto le cui impostazioni sono più complesse di un singolo valore scalare.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    gray_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image)
    gray_frame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect()

    duotone_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image)
    duotone = duotone_frame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect()
    duotone.getColor1().setColor(Color(0, 0, 128))
    duotone.getColor2().setColor(Color(255, 215, 0))

    tint_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image)
    tint_frame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210.0, 35.0)

    hsl_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image)
    hsl_frame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30.0, 20.0, -10.0)

    replacement_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect()
    color_replacement.getColor().setColor(Color(100, 149, 237))

    presentation.save("color-transformations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) sostituisce il colore di ogni pixel con un colore fisso mantenendo l’alpha. È diverso da [addColorChangeEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect), che mappa un colore sorgente su un altro e espone entrambi i formati colore sorgente e destinazione.

### **Applicare una soglia di luminanza**

Una soglia di luminanza può rendere più distinti i segni deboli su una pagina scannerizzata rispetto allo sfondo. [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) conserva le sfumature intermedie di grigio. [addBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBiLevelEffect) mappa la luminanza su nero o bianco, mentre [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) applica una soglia all’opacità.

La soglia di luminanza varia dallo 0 % al 100 %, inclusi. I pixel sotto la soglia diventano neri. I pixel pari o superiori diventano bianchi. Aumentare la soglia trasforma più sfumature in nero perché più di esse scendono al di sotto del limite.

Scarica [grayscale-swatches.png](grayscale-swatches.png) nella directory di lavoro. Ogni etichetta indica il livello di grigio originale su una scala da 0 a 255. L’esempio pone l’originale accanto a due copie e salva la soglia di ciascuna copia nella presentazione.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720.0, 150.0, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    image_data = Path("grayscale-swatches.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    frames = []
    for index, caption in enumerate(("Original", "Threshold 20%", "Threshold 60%")):
        x = 12 + 240 * index
        label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36)
        label.getTextFrame().setText(caption)
        frame = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image)
        frames.append(frame)

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20.0)
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60.0)

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Apri la presentazione di output in PowerPoint per confrontare le tre cornici. La campionatura etichettata 96 ha circa il 38 % di luminanza (96 su 255). Diventa bianca alla soglia del 20 % e nera alla soglia del 60 %.

![Campioni di scala di grigi originali accanto ai risultati in bianco e nero alle soglie di luminanza del 20% e 60%](luminance-threshold.png)

## **Aggiungere sfocatura, trasparenza e effetti alfa**

[addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) influisce su tutti i canali colore, incluso alfa. Imposta `grow` su `True` quando il bordo sfocato può estendersi oltre i limiti originali dell’immagine.

Per una trasparenza uniforme, usa [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect). Moltiplica ogni valore alfa esistente, quindi i pixel parzialmente trasparenti rimangono proporzionalmente diversi. [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) assegna invece un unico valore alfa a tutti i pixel. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) converte l’alfa in due livelli basati su una soglia.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    blurred_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image)
    blur = blurred_frame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, True)
    blur.setRadius(5)

    transparent_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65.0)
    alpha_modulate.setAmount(60.0)

    uniform_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image)
    uniform_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55.0)

    binary_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50.0)
    alpha_bi_level.setThreshold(45.0)
    binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect()

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Altre operazioni alfa senza parametri includono [addAlphaCeilingEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect), che rende ogni alfa diverso da zero completamente opaco; [addAlphaFloorEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect), che rende ogni alfa inferiore al 100 % completamente trasparente; e [addAlphaInverseEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect), che cambia l’alfa in `100% - alpha`.

## **Costruire una catena di effetti ordinata**

Ogni metodo `add...Effect` aggiunge una nuova operazione alla fine della collezione. Il renderer utilizza la collezione come una pipeline ordinata: l’output dell’operazione 0 diventa l’input dell’operazione 1, e così via. Di conseguenza, le stesse operazioni in un ordine diverso possono produrre un’immagine diversa.

Ad esempio, scala di grigi seguita da tinta rimuove prima le informazioni cromatiche e poi ricolora il risultato di luminanza. Tinta seguita da scala di grigi rimuove nuovamente la tinta. Analogamente, la sostituzione alfa può sovrascrivere i valori alfa calcolati dalle operazioni precedenti, mentre la modulazione alfa ne preserva le differenze relative.

L’esempio seguente costruisce una catena di quattro operazioni, la salva come PPTX, riapre la presentazione, verifica sia i tipi di operazione sia il loro ordine, e rende il risultato riaperto:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Blur, GrayScale, ImageFormat, PictureFrame, Presentation, SaveFormat, ShapeType, Tint

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    image_transform.addGrayScaleEffect()
    image_transform.addTintEffect(220.0, 25.0)
    image_transform.addBlurEffect(2.5, False)
    image_transform.addAlphaModulateFixedEffect(80.0)

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("image-transform-chain.pptx")
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(reopened_shape, PictureFrame):
        reopened_transform = reopened_shape.getPictureFormat().getPicture().getImageTransform()
        expected_types = (GrayScale, Tint, Blur, AlphaModulateFixed)
        order_is_preserved = reopened_transform.size() == len(expected_types)
        for index, expected_type in enumerate(expected_types):
            order_is_preserved = order_is_preserved and isinstance(reopened_transform.get_Item(index), expected_type)
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        rendered_slide = reopened_presentation.getSlides().get_Item(0).getImage()
        try:
            rendered_slide.save("reopened-effect-chain.png", ImageFormat.Png)
        finally:
            rendered_slide.dispose()
    else:
        print("The reopened shape is not a picture frame.")
finally:
    reopened_presentation.dispose()
```

La collezione non impone una matrice di compatibilità che limiti le operazioni di colore, alfa e sfocatura a catene separate. Possono essere combinate, ma le combinazioni non sono sempre utili. Una sostituzione colore fissa rimuove la variazione RGB prodotta dagli effetti colore precedenti; la scala di grigi dopo duotone rimuove i due colori selezionati; e le operazioni di alfa ceiling, floor, replace o bi‑level possono scartare i dettagli alfa creati in precedenza. Costruisci la catena secondo la sequenza di elaborazione pixel desiderata piuttosto che trattare gli elementi come flag di formattazione non ordinati.


<!-- visual-explanation:image-transform-effects:start -->
[![La stessa immagine passa prima per la scala di grigi poi per la tinta, e la tinta poi per la scala di grigi. Le due immagini finali in scala di grigi hanno tonalità diverse.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In questa illustrazione di Aspose.Slides per .NET 26.11, una tinta di 220° al 25% lascia invariata l’immagine in scala di grigi. Applicare la stessa tinta prima della scala di grigi produce tonalità diverse.*
<!-- visual-explanation:image-transform-effects:end -->

## **Ispezionare valori modificabili ed effettivi**

Un’operazione modificabile è l’oggetto memorizzato in `Picture.getImageTransform`. A seconda dell’effetto, può esporre membri scrivibili direttamente. Per esempio, [Blur](https://reference.aspose.com/slides/python-java/aspose.slides/blur/) espone i valori scrivibili `radius` e `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/python-java/aspose.slides/alphamodulatefixed/) espone un `amount` scrivibile, e [AlphaBiLevel](https://reference.aspose.com/slides/python-java/aspose.slides/alphabilevel/) espone un `threshold` scrivibile. Gli effetti colore come [Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) espongono oggetti [ColorFormat](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/) mutabili.

Alcune classi di operazione, tra cui [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/python-java/aspose.slides/tint/), e [AlphaReplace](https://reference.aspose.com/slides/python-java/aspose.slides/alphareplace/), non espongono i loro scalari di creazione come proprietà scrivibili. Per modificare tali impostazioni, rimuovi l’operazione e aggiungi una sostituzione nella posizione richiesta.

I dati effettivi restituiti da `getEffective` sono calcolati e di sola lettura. Sono utili per risolvere i colori dipendenti dal tema e leggere i valori normalizzati usati dal renderer, ma non costituiscono un’altra superficie di modifica. L’esempio seguente enumera la catena e ispeziona i valori effettivi dove l’API corrispondente li fornisce:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaBiLevel, AlphaModulateFixed, AlphaReplace, Blur, BrightnessContrast, ColorReplace, Duotone, HSL, Luminance, PictureFrame, Presentation, Tint

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()

        for index in range(image_transform.size()):
            operation = image_transform.get_Item(index)
            print(index, ": ", operation.getClass().getSimpleName(), sep="")

            if isinstance(operation, BrightnessContrast):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Luminance):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Duotone):
                data = operation.getEffective()
                print("  Dark color: ", data.getColor1(), sep="")
                print("  Light color: ", data.getColor2(), sep="")
            elif isinstance(operation, ColorReplace):
                data = operation.getEffective()
                print("  Replacement color: ", data.getColor(), sep="")
            elif isinstance(operation, HSL):
                data = operation.getEffective()
                print("  HSL: ", data.getHue(), ", ", data.getSaturation(), ", ", data.getLuminance(), sep="")
            elif isinstance(operation, Tint):
                data = operation.getEffective()
                print("  Tint: ", data.getHue(), ", ", data.getAmount(), sep="")
            elif isinstance(operation, Blur):
                data = operation.getEffective()
                print("  Blur radius: ", data.getRadius(), " pt", sep="")
            elif isinstance(operation, AlphaModulateFixed):
                data = operation.getEffective()
                print("  Alpha amount: ", data.getAmount(), "%", sep="")
            elif isinstance(operation, AlphaReplace):
                data = operation.getEffective()
                print("  Replacement alpha: ", data.getAlpha(), "%", sep="")
            elif isinstance(operation, AlphaBiLevel):
                data = operation.getEffective()
                print("  Alpha threshold: ", data.getThreshold(), "%", sep="")
finally:
    presentation.dispose()
```

Gli effetti senza parametri come scala di grigi, alpha ceiling e alpha inverse hanno comunque un oggetto di dati effettivi, ma non vi sono impostazioni scalari da stampare. La loro presenza e posizione nella collezione sono le informazioni importanti.

## **Rimuovere o cancellare le trasformazioni immagine**

Usa [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) per rimuovere un’operazione per indice. Poiché gli indici si spostano dopo la rimozione, cerca prima il target e rimuovilo dopo l’enumerazione. Usa [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#clear) per rimuovere l’intera catena.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Blur, PictureFrame, Presentation, SaveFormat

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
        blur_index = -1

        for index in range(image_transform.size()):
            if isinstance(image_transform.get_Item(index), Blur):
                blur_index = index
                break

        if blur_index >= 0:
            image_transform.removeAt(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: ", image_transform.size(), sep="")
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Rimuovere o cancellare le trasformazioni altera solo la formattazione dell’immagine. Non elimina, ricomprime o altera in altro modo la risorsa [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) riutilizzata.

## **Considerare i formati di presentazione e i target di esportazione**

Le trasformazioni immagine hanno origine in DrawingML, quindi PPTX è il formato modificabile preferito per le catene di effetti. Anche con PPTX, non ogni operazione ha la stessa portabilità:

- Le operazioni DrawingML standard come luminanza, scala di grigi, duotone, tinta, HSL, sfocatura e le comuni operazioni alfa hanno la migliore possibilità di sopravvivere a un round‑trip PPTX. Riapri sempre il file generato e ispeziona la collezione quando la conservazione è un requisito.
- [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) è un’estensione Office 2010 piuttosto che l’operazione di luminanza DrawingML standard. Può essere usato per il rendering in memoria, ma non è garantito che rimanga un [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) modificabile dopo il salvataggio e la riapertura del PPTX. Preferisci [addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) per regolazioni di luminosità e contrasto persistenti.
- Il formato binario PPT precede il modello completo degli effetti DrawingML. Salvare in PPT può omettere operazioni non supportate, ridurre una catena a un sotto‑insieme supportato o approssimare l’aspetto. Non usare PPT come formato di verifica per una catena complessa modificabile.
- Il rendering in PNG, JPEG, TIFF, PDF, SVG, HTML o altri output visivi applica la catena supportata all’aspetto reso. Quei output non contengono una `ImageTransformOperationCollection` modificabile; i formati raster appiattiscono il risultato in pixel, e le esportazioni documento/vettoriale memorizzano la propria rappresentazione di rendering.
- Gli effetti non rendono un’immagine collegata autonoma. Il rendering di un’immagine collegata dipende ancora dalla disponibilità della risorsa collegata quando la presentazione viene caricata.

Diversi consumatori di presentazioni possono rendere i casi limite in modo differente, specialmente quando diverse operazioni alfa o di quantizzazione colore sono combinate. Per output critico, testa sia il round‑trip modificabile sia il formato di esportazione finale con la stessa versione di Aspose.Slides usata in produzione.

## **FAQ**

**Le trasformazioni immagine modificano i dati dell’immagine incorporata?**

No. Le operazioni appartengono al `Picture` usato dal riempimento immagine. I byte sottostanti di `PPImage` rimangono invariati.

**Due cornici immagine che riutilizzano la stessa immagine condividono i loro effetti?**

No. Riutilizzare un `PPImage` evita dati immagine duplicati, ma ogni cornice immagine ha normalmente un `Picture` separato e una collezione di trasformazioni immagine distinta.

**È possibile combinare effetti colore, sfocatura e alfa?**

Sì. La collezione li accetta in una catena ordinata. Considera cosa fa ogni operazione all’output della precedente perché le operazioni di sostituzione e soglia possono scartare dettagli colore o alfa precedenti.

**Perché i valori effettivi sono di sola lettura?**

I dati effettivi rappresentano valori calcolati usati per il rendering, inclusi i colori risolti. Modifica l’operazione memorizzata nella collezione di trasformazioni dove esistono membri scrivibili; altrimenti rimuovila e aggiungi una sostituzione con nuovi parametri di creazione.

**Quale formato devo usare per preservare una catena di trasformazioni?**

Usa PPTX e verifica il file riaprendo lo stesso. PPT legacy non può rappresentare l’intero modello di effetti DrawingML, e i formati di esportazione renderizzati preservano l’aspetto anziché le operazioni di trasformazione modificabili.