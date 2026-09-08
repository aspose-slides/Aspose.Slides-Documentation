---
title: Gestire gli effetti di trasformazione immagine nelle presentazioni con Python
linktitle: Effetti di trasformazione immagine
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
- effetto alpha
- catena di effetti
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Applicare, concatenare, ispezionare, rimuovere e verificare gli effetti di trasformazione immagine per i frame immagine con Aspose.Slides per Python via Java."
---
## **Panoramica**

Aspose.Slides rappresenta le regolazioni dell’immagine come una collezione ordinata di operazioni di trasformazione dell’immagine. Per un frame immagine, partite dal [Picture](https://reference.aspose.com/slides/it/python-java/aspose.slides/picture/) del frame e accedete a [Picture.getImageTransform](https://reference.aspose.com/slides/it/python-java/aspose.slides/picture/#getImageTransform). La [ImageTransformOperationCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagetransformoperationcollection/) restituita consente di aggiungere, enumerare, ispezionare, rimuovere e cancellare effetti senza riscrivere i byte originali dell’immagine.

Questo articolo dimostra un flusso di lavoro completo per luminosità e contrasto, trasformazioni di colore, sfocatura, trasparenza, catene di effetti ordinate, valori effettivi, rimozione e verifica di round‑trip PPTX.

## **Comprendere la proprietà degli effetti e il riutilizzo dell’immagine**

Una risorsa immagine e l’immagine che la visualizza sono oggetti diversi:

- [PPImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/) memorizza o fa riferimento ai dati immagine di origine di proprietà della presentazione.
- [Picture](https://reference.aspose.com/slides/it/python-java/aspose.slides/picture/) appartiene a un riempimento immagine e si riferisce a una risorsa immagine memorizzando la collezione di trasformazioni immagine.
- [PictureFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/) è la forma della diapositiva che possiede il riempimento immagine pertinente, la geometria, le impostazioni di ritaglio e altre formattazioni a livello di frame.

Pertanto, le operazioni di trasformazione immagine non modificano i byte in [PPImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/). Quando lo stesso `PPImage` viene passato a [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addPictureFrame) più di una volta, ogni nuovo frame immagine riceve il proprio `Picture` e la propria collezione di trasformazioni. Applicare la scala di grigi a un frame non rende gli altri frame in scala di grigi, anche se tutti riutilizzano la stessa risorsa immagine incorporata.

Lo stesso modello `Picture.getImageTransform` è utilizzato anche da altri riempimenti immagine, come uno shape o lo sfondo della diapositiva. Gli esempi seguenti si concentrano sui frame immagine.

## **Utilizzare intervalli di parametri e unità validi**

I metodi dimostrati usano i seguenti intervalli semantici e unità. Mantenete i valori in questi intervalli anche se una determinata versione della libreria non rifiuta immediatamente ogni valore fuori intervallo; il formato di destinazione della presentazione può normalizzare, omettere o rifiutare dati non validi durante il salvataggio o quando PowerPoint apre il file.

| Operazione | Parametri | Intervallo valido e unità |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | da `-100` a `100`, percentuale; `0` lascia il componente invariato. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | Nessuno | Nessun parametro numerico. Alpha invariato. |
| [addDuotoneEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | Due colori per pixel scuri e chiari. I canali RGB e alpha in `java.awt.Color` usano valori da `0` a `255`. |
| [addTintEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | Hue compreso tra `0` (incluso) e `360` (escluso), in gradi; amount da `-100` a `100`, percentuale. |
| [addHSLEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | Hue da `0` (incluso) a `360` (escluso), in gradi; saturazione e luminanza da `-100` a `100`, percentuale. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | Il colore di sostituzione usa valori di canale da `0` a `255`. I valori alpha esistenti rimangono invariati. |
| [addBlurEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | Radius non negativo, misurato in punti; `grow` è un Boolean che indica se il contenuto sfocato può estendersi al di fuori dei limiti originali. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | Percentuale non negativa. Usate `0`‑`100` per la normale scalatura dell’opacità: `0` è totalmente trasparente e `100` mantiene l’alpha esistente. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | Da `0` a `100`, percentuale di opacità. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | Da `0` a `100`, percentuale di soglia alpha. Valori al di sotto diventano trasparenti; valori pari o superiori diventano opachi. |

Per la modulazione fissa dell’alpha, trasparenza e opacità sono complementari. Per esempio, il 35 % di trasparenza corrisponde a una modulazione alpha del 65 %.

## **Applicare luminosità e contrasto**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) restituisce un’operazione [BrightnessContrast](https://reference.aspose.com/slides/it/python-java/aspose.slides/brightnesscontrast/). Le impostazioni scalari sono fornite al momento della creazione dell’operazione. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/it/python-java/aspose.slides/brightnesscontrast/#getEffective) restituisce valori calcolati di sola lettura che possono essere ispezionati o registrati.

L’esempio seguente aumenta la luminosità del 15 % e il contrasto del 20 %, poi rende un’anteprima senza modificare l’immagine incorporata:

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

[BrightnessContrast](https://reference.aspose.com/slides/it/python-java/aspose.slides/brightnesscontrast/) è un’estensione di effetto immagine Office 2010 e è meno portabile rispetto all’effetto standard DrawingML di luminanza. Quando luce e contrasto devono rimanere modificabili dopo un round‑trip PPTX, usate [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) e verificate il risultato dopo aver riaperto il file. La sezione limitazioni di formato spiega questa distinzione in maggiore dettaglio.

## **Applicare trasformazioni di colore**

Gli effetti colore possono essere applicati indipendentemente a diversi frame immagine che riutilizzano una stessa risorsa immagine. L’esempio seguente crea cinque frame e applica scala di grigi, duotono, tinta, regolazione HSL e sostituzione colore.

[Duotone](https://reference.aspose.com/slides/it/python-java/aspose.slides/duotone/) contiene due parametri colore modificabili indipendentemente: `color1` mappa i pixel scuri, mentre `color2` mappa i pixel chiari. Questo lo rende un esempio utile di effetto le cui impostazioni sono più complesse di un singolo valore scalare.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) sostituisce il colore di ogni pixel con un colore fisso mantenendo l’alpha. È diverso da [addColorChangeEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect), che mappa un colore sorgente in un altro e espone entrambi i formati colore sorgente e destinazione.

## **Aggiungere sfocatura, trasparenza ed effetti alpha**

[addBlurEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) influenza tutti i canali colore, incluso l’alpha. Impostate `grow` a `True` quando il bordo sfocato può estendersi oltre i limiti originali dell’immagine.

Per una trasparenza uniforme, usate [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect). Moltiplica ogni valore alpha esistente, quindi i pixel parzialmente trasparenti rimangono proporzionalmente diversi. [addAlphaReplaceEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) invece assegna lo stesso valore alpha a tutti i pixel. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) converte l’alpha in due livelli basati su una soglia.

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

Altre operazioni alpha senza parametri includono [addAlphaCeilingEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect), che rende ogni alpha non zero completamente opaco; [addAlphaFloorEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect), che rende ogni alpha inferiore al 100 % totalmente trasparente; e [addAlphaInverseEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect), che trasforma l’alpha in `100% - alpha`.

## **Costruire una catena di effetti ordinata**

Ogni metodo `add...Effect` aggiunge una nuova operazione alla fine della collezione. Il renderer utilizza la collezione come una pipeline ordinata: l’output dell’operazione 0 diventa l’input dell’operazione 1, e così via. Di conseguenza, le stesse operazioni in un ordine diverso possono produrre un’immagine diversa.

Ad esempio, scala di grigi seguita da tinta rimuove prima le informazioni cromatiche e poi ricolora il risultato di luminanza. Tinta seguita da scala di grigi rimuove di nuovo la tinta. Analogamente, la sostituzione alpha può sovrascrivere i valori alpha calcolati dalle operazioni precedenti, mentre la modulazione alpha preserva le loro differenze relative.

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

La collezione non impone una matrice di compatibilità che limiti operazioni di colore, alpha e sfocatura a catene separate. Possono essere combinate, ma le combinazioni non sono sempre utili. Una sostituzione colore fissa elimina la variazione RGB prodotta da effetti colore precedenti; la scala di grigi dopo duotono elimina i due colori selezionati; e le operazioni alpha ceiling, floor, replacement o bi‑level possono scartare i dettagli alpha creati in precedenza. Costruite la catena secondo la sequenza di elaborazione dei pixel desiderata, invece di trattare i suoi elementi come flag di formattazione non ordinati.

## **Ispezionare valori modificabili ed effettivi**

Un’operazione modificabile è l’oggetto memorizzato in `Picture.getImageTransform`. A seconda dell’effetto, può esporre membri scrivibili direttamente. Per esempio, [Blur](https://reference.aspose.com/slides/it/python-java/aspose.slides/blur/) espone i valori scrivibili `radius` e `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/it/python-java/aspose.slides/alphamodulatefixed/) espone un `amount` scrivibile, e [AlphaBiLevel](https://reference.aspose.com/slides/it/python-java/aspose.slides/alphabilevel/) espone un `threshold` scrivibile. Gli effetti colore come [Duotone](https://reference.aspose.com/slides/it/python-java/aspose.slides/duotone/) espongono oggetti [ColorFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/colorformat/) mutabili.

Alcune classi operazione, tra cui [BrightnessContrast](https://reference.aspose.com/slides/it/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/it/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/it/python-java/aspose.slides/tint/) e [AlphaReplace](https://reference.aspose.com/slides/it/python-java/aspose.slides/alphareplace/), non espongono i loro scalari di creazione come proprietà scrivibili. Per cambiare tali impostazioni, rimuovete l’operazione e aggiungete una sostituzione nella posizione desiderata.

I dati effettivi restituiti da `getEffective` sono calcolati e di sola lettura. Sono utili per risolvere colori dipendenti dal tema e per leggere i valori normalizzati usati dal renderer, ma non costituiscono un’altra superficie di editing. L’esempio seguente enumera la catena e ispeziona i valori effettivi dove l’API corrispondente li fornisce:

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

Gli effetti senza parametri come scala di grigi, alpha ceiling e alpha inverse hanno comunque un oggetto dati‑effettivi, ma non esistono impostazioni scalari da stampare. La loro presenza e posizione nella collezione sono le informazioni importanti.

## **Rimuovere o cancellare le trasformazioni immagine**

Usate [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) per rimuovere un’operazione per indice. Poiché gli indici si spostano dopo la rimozione, cercate prima l’obiettivo e rimuovetelo dopo l’enumerazione. Usate [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagetransformoperationcollection/#clear) per rimuovere l’intera catena.

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

Rimuovere o cancellare le trasformazioni cambia solo la formattazione dell’immagine. Non elimina, ricomprime o in altro modo altera la risorsa [PPImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/) riutilizzata.

## **Considerare i formati di presentazione e le destinazioni di esportazione**

Le trasformazioni immagine hanno origine in DrawingML, quindi PPTX è il formato editabile preferito per le catene di effetti. Anche con PPTX, non tutte le operazioni hanno la stessa portabilità:

- Le operazioni standard DrawingML come luminanza, scala di grigi, duotono, tinta, HSL, sfocatura e le comuni operazioni alpha hanno la massima probabilità di sopravvivere a un round‑trip PPTX. Riaprite sempre il file generato e ispezionate la collezione quando la conservazione è un requisito.
- [BrightnessContrast](https://reference.aspose.com/slides/it/python-java/aspose.slides/brightnesscontrast/) è un’estensione Office 2010 anziché l’operazione standard di luminanza DrawingML. Può essere usata per il rendering in memoria, ma non è garantito che rimanga un [BrightnessContrast](https://reference.aspose.com/slides/it/python-java/aspose.slides/brightnesscontrast/) modificabile dopo il salvataggio e la riapertura di PPTX. Preferite [addLuminanceEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) per regolazioni di luminosità e contrasto persistenti.
- Il formato binario PPT precede il modello completo di effetti DrawingML. Il salvataggio in PPT può omettere operazioni non supportate, ridurre una catena a un sotto‑insieme supportato o approssimare l’aspetto. Non usate PPT come formato di verifica per una catena editabile complessa.
- Il rendering in PNG, JPEG, TIFF, PDF, SVG, HTML o altri output visivi applica la catena supportata all’aspetto renderizzato. Quei output non contengono una `ImageTransformOperationCollection` editabile; i formati raster appiattiscono il risultato in pixel, e le esportazioni documento/vettoriale memorizzano la loro rappresentazione di rendering.
- Gli effetti non rendono un’immagine collegata autonoma. Il rendering di un’immagine collegata dipende comunque dal fatto che la risorsa collegata sia disponibile al momento del caricamento della presentazione.

Diversi consumatori di presentazioni possono rendere casi limite in modo diverso, soprattutto quando più operazioni alpha o di quantizzazione colore sono combinate. Per output critici, testate sia il round‑trip editabile sia il formato di esportazione finale con la stessa versione di Aspose.Slides usata in produzione.

## **FAQ**

**Le trasformazioni immagine modificano i dati dell’immagine incorporata?**

No. Le operazioni appartengono al `Picture` usato dal riempimento immagine. I byte sottostanti di `PPImage` rimangono invariati.

**Due frame immagine che riutilizzano la stessa immagine condividono i loro effetti?**

No. Riutilizzare un `PPImage` evita dati immagine duplicati, ma ogni frame immagine ha normalmente un `Picture` separato e una collezione di trasformazioni immagine separata.

**È possibile combinare effetti colore, sfocatura e alpha?**

Sì. La collezione li accetta in un’unica catena ordinata. Considerate cosa fa ogni operazione sull’output della precedente, perché le operazioni di sostituzione e soglia possono scartare dettagli colore o alpha precedenti.

**Perché i valori effettivi sono di sola lettura?**

I dati effettivi rappresentano i valori calcolati usati per il rendering, inclusi i colori risolti. Modificate l’operazione memorizzata nella collezione di trasformazioni dove esistono membri scrivibili; altrimenti rimuovetela e aggiungete una sostituzione con nuovi parametri di creazione.

**Quale formato devo usare per conservare una catena di trasformazioni?**

Usate PPTX e verificate il file riaprendolo. Il vecchio PPT non può rappresentare l’intero modello di effetti DrawingML, e i formati di esportazione renderizzati preservano solo l’aspetto, non le operazioni di trasformazione editabili.