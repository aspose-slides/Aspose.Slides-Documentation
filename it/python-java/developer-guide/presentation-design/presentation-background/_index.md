---
title: Gestisci gli sfondi della presentazione in Python tramite Java
linktitle: Sfondo diapositiva
type: docs
weight: 20
url: /it/python-java/presentation-background/
keywords:
- sfondo della presentazione
- sfondo diapositiva
- colore solido
- colore gradiente
- sfondo immagine
- trasparenza sfondo
- proprietà dello sfondo
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come impostare sfondi dinamici nei file PowerPoint e OpenDocument utilizzando Aspose.Slides per Python tramite Java, con suggerimenti di codice per potenziare le tue presentazioni."
---
## **Introduzione**

I colori solidi, i gradienti e le immagini sono comunemente usati come sfondi delle diapositive. È possibile impostare lo sfondo per una **diapositiva normale** (una singola diapositiva) o una **diapositiva master** (vale per più diapositive contemporaneamente).

![Sfondo PowerPoint](powerpoint-background.png)

## **Imposta uno sfondo a colore solido per una diapositiva normale**

Aspose.Slides consente di impostare un colore solido come sfondo per una diapositiva specifica in una presentazione, anche se la presentazione utilizza una diapositiva master. La modifica si applica solo alla diapositiva selezionata.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/python-java/aspose.slides/backgroundtype/) della diapositiva su `OwnBackground`.
3. Imposta il [FillType](https://reference.aspose.com/slides/it/python-java/aspose.slides/filltype/) dello sfondo della diapositiva su `Solid`.
4. Utilizza il metodo [getSolidFillColor](https://reference.aspose.com/slides/it/python-java/aspose.slides/fillformat/#getsolidfillcolor) su [FillFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/fillformat/) per specificare il colore solido dello sfondo.
5. Salva la presentazione modificata.

Il seguente esempio Python mostra come impostare un colore solido blu come sfondo per una diapositiva normale:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Crea un'istanza della classe Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Imposta il colore di sfondo della diapositiva su blu.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Salva la presentazione su disco.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Imposta uno sfondo a colore solido per una diapositiva master**

Aspose.Slides consente di impostare un colore solido come sfondo per la diapositiva master in una presentazione. La diapositiva master agisce come modello che controlla la formattazione di tutte le diapositive, quindi quando si sceglie un colore solido per lo sfondo della diapositiva master, questo viene applicato a ogni diapositiva.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/python-java/aspose.slides/backgroundtype/) della diapositiva master (tramite [getMasters](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getmasters)) su `OwnBackground`.
3. Imposta il [FillType](https://reference.aspose.com/slides/it/python-java/aspose.slides/filltype/) dello sfondo della diapositiva master su `Solid`.
4. Utilizza il metodo [getSolidFillColor](https://reference.aspose.com/slides/it/python-java/aspose.slides/fillformat/#getsolidfillcolor) per specificare il colore solido dello sfondo.
5. Salva la presentazione modificata.

Il seguente esempio Python mostra come impostare un colore solido (verde) come sfondo per una diapositiva master:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Crea un'istanza della classe Presentation.
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Imposta il colore di sfondo della diapositiva master su verde.
    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Salva la presentazione su disco.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Imposta uno sfondo sfumato per una diapositiva**

Un gradiente è un effetto grafico creato da una variazione graduale del colore. Quando viene usato come sfondo di una diapositiva, i gradienti possono rendere le presentazioni più artistiche e professionali. Aspose.Slides consente di impostare un colore sfumato come sfondo per le diapositive.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/python-java/aspose.slides/backgroundtype/) della diapositiva su `OwnBackground`.
3. Imposta il [FillType](https://reference.aspose.com/slides/it/python-java/aspose.slides/filltype/) dello sfondo della diapositiva su `Gradient`.
4. Utilizza il metodo [getGradientFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/fillformat/#getgradientformat) su [FillFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/fillformat/) per configurare le impostazioni del gradiente desiderate.
5. Salva la presentazione modificata.

Il seguente esempio Python mostra come impostare un colore sfumato come sfondo per una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, TileFlip
from java.awt import Color

# Crea un'istanza della classe Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Applica un effetto gradiente allo sfondo.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient)

    gradient_format = slide.getBackground().getFillFormat().getGradientFormat()
    gradient_format.setTileFlip(TileFlip.FlipBoth)

    # Aggiungi i colori del gradiente. Senza fermate del gradiente, lo sfondo tornerà a una rampa predefinita dal nero al bianco.
    gradient_format.getGradientStops().add(0.0, Color.CYAN)
    gradient_format.getGradientStops().add(1.0, Color.BLUE)

    # Salva la presentazione su disco.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Imposta un'immagine come sfondo della diapositiva**

Oltre a riempimenti solidi e sfumati, Aspose.Slides consente di utilizzare immagini come sfondi delle diapositive.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/python-java/aspose.slides/backgroundtype/) della diapositiva su `OwnBackground`.
3. Imposta il [FillType](https://reference.aspose.com/slides/it/python-java/aspose.slides/filltype/) dello sfondo della diapositiva su `Picture`.
4. Carica l'immagine che desideri utilizzare come sfondo della diapositiva.
5. Aggiungi l'immagine alla collezione di immagini della presentazione.
6. Utilizza il metodo [getPictureFillFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/fillformat/#getpicturefillformat) su [FillFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/fillformat/) per assegnare l'immagine come sfondo.
7. Salva la presentazione modificata.

Il seguente esempio Python mostra come impostare un'immagine come sfondo per una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

# Crea un'istanza della classe Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Imposta le proprietà dell'immagine di sfondo.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    # Carica l'immagine.
    image = Images.fromFile("Tulips.jpg")
    # Aggiungi l'immagine alla collezione di immagini della presentazione.
    presentation_image = presentation.getImages().addImage(image)
    image.dispose()

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    # Salva la presentazione su disco.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il seguente codice di esempio mostra come impostare il tipo di riempimento di sfondo su un'immagine a piastrelle e modificare le proprietà di piastrellamento:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    background = first_slide.getBackground()

    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Picture)

    new_image = Images.fromFile("image.png")
    presentation_image = presentation.getImages().addImage(new_image)
    new_image.dispose()

    # Imposta l'immagine usata per il riempimento di sfondo.
    background_picture_fill_format = background.getFillFormat().getPictureFillFormat()
    background_picture_fill_format.getPicture().setImage(presentation_image)

    # Imposta la modalità di riempimento dell'immagine su Tile e regola le proprietà del tile.
    background_picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    background_picture_fill_format.setTileOffsetX(15.0)
    background_picture_fill_format.setTileOffsetY(15.0)
    background_picture_fill_format.setTileScaleX(46.0)
    background_picture_fill_format.setTileScaleY(87.0)
    background_picture_fill_format.setTileAlignment(RectangleAlignment.Center)
    background_picture_fill_format.setTileFlip(TileFlip.FlipY)

    presentation.save("TileBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Leggi di più: [Tile Picture as Texture](/slides/it/python-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Modifica la trasparenza dell'immagine di sfondo**

Potresti desiderare di regolare la trasparenza dell'immagine di sfondo di una diapositiva per far risaltare il contenuto della diapositiva. Il seguente codice Python mostra come modificare la trasparenza per l'immagine di sfondo di una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Presentation, SaveFormat

transparency_value = 30  # Per esempio.

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Ottieni la collezione delle operazioni di trasformazione dell'immagine.
    image_transform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform()

    # Trova un effetto di trasparenza a percentuale fissa esistente.
    transparency_operation = None
    for operation in image_transform:
        if isinstance(operation, AlphaModulateFixed):
            transparency_operation = operation
            break

    # Imposta il nuovo valore di trasparenza.
    if transparency_operation is None:
        image_transform.addAlphaModulateFixedEffect(100 - transparency_value)
    else:
        transparency_operation.setAmount(100 - transparency_value)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Recupera il valore di sfondo della diapositiva**

Aspose.Slides consente di recuperare i valori effettivi dello sfondo di una diapositiva utilizzando il metodo [getEffective](https://reference.aspose.com/slides/it/python-java/aspose.slides/background/#geteffective) su [Background](https://reference.aspose.com/slides/it/python-java/aspose.slides/background/). I dati restituiti espongono i formati di riempimento ed effetto effettivi.

Utilizzando il metodo [getBackground](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/#getbackground) della classe [BaseSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/), è possibile ottenere lo sfondo di una diapositiva.

Il seguente esempio Python mostra come ottenere il valore di sfondo effettivo di una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

# Crea un'istanza della classe Presentation.
presentation = Presentation("Sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Recupera lo sfondo effettivo, tenendo conto di master, layout e tema.
    effective_background = slide.getBackground().getEffective()

    if effective_background.getFillFormat().getFillType() == FillType.Solid:
        print("Fill color:", effective_background.getFillFormat().getSolidFillColor())
    else:
        print("Fill type:", effective_background.getFillFormat().getFillType())
finally:
    presentation.dispose()
```

## **FAQ**

**Posso ripristinare lo sfondo personalizzato e riportare lo sfondo del tema/layout?**

Sì. Rimuovi il riempimento personalizzato della diapositiva e lo sfondo verrà nuovamente ereditato dalla diapositiva [layout](/slides/it/python-java/slide-layout/)/[master](/slides/it/python-java/slide-master/) corrispondente (cioè lo [sfondo del tema](/slides/it/python-java/presentation-theme/)).

**Cosa succede allo sfondo se cambio in seguito il tema della presentazione?**

Se una diapositiva ha il proprio riempimento, rimarrà invariato. Se lo sfondo è ereditato dal [layout](/slides/it/python-java/slide-layout/)/[master](/slides/it/python-java/slide-master/), verrà aggiornato per corrispondere al [nuovo tema](/slides/it/python-java/presentation-theme/).