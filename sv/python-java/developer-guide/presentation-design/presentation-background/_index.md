---
title: Hantera presentationsbakgrunder i Python via Java
linktitle: Bildbakgrund
type: docs
weight: 20
url: /sv/python-java/presentation-background/
keywords:
- presentationsbakgrund
- bildbakgrund
- solid färg
- gradientfärg
- bildbakgrund
- bakgrundstransparens
- bakgrundsegenskaper
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du ställer in dynamiska bakgrunder i PowerPoint- och OpenDocument-filer med Aspose.Slides för Python via Java, med kodtips för att förbättra dina presentationer."
---
## **Introduktion**

Solida färger, gradienter och bilder används ofta som bildbakgrunder för bilder. Du kan ange bakgrunden för en **normal bild** (en enskild bild) eller en **masterbild** (gäller flera bilder samtidigt).

![PowerPoint background](powerpoint-background.png)

## **Ange en solid färgbakgrund för en normal bild**

Aspose.Slides låter dig ange en solid färg som bakgrund för en specifik bild i en presentation—även om presentationen använder en masterbild. Ändringen gäller endast den valda bilden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Ange bildens [BackgroundType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/backgroundtype/) till `OwnBackground`.
3. Ange bildbakgrundens [FillType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/filltype/) till `Solid`.
4. Använd metoden [getSolidFillColor](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fillformat/#getsolidfillcolor) på [FillFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fillformat/) för att ange den solida bakgrundsfärgen.
5. Spara den modifierade presentationen.

Följande Python‑exempel visar hur du anger en blå solid färg som bakgrund för en normal bild:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Skapa en instans av Presentation-klassen.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Ställ in bakgrundsfärgen för bilden till blå.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Spara presentationen till disk.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ange en solid färgbakgrund för en masterbild**

Aspose.Slides låter dig ange en solid färg som bakgrund för masterbilden i en presentation. Masterbilden fungerar som en mall som styr formatering för alla bilder, så när du väljer en solid färg för masterbildens bakgrund gäller den för varje bild.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Ange masterbildens [BackgroundType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/backgroundtype/) (via [getMasters](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getmasters)) till `OwnBackground`.
3. Ange masterbildens bakgrund [FillType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/filltype/) till `Solid`.
4. Använd metoden [getSolidFillColor](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fillformat/#getsolidfillcolor) för att ange den solida bakgrundsfärgen.
5. Spara den modifierade presentationen.

Följande Python‑exempel visar hur du anger en solid färg (grön) som bakgrund för en masterbild:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Skapa en instans av Presentation-klassen.
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Ställ in bakgrundsfärgen för masterbilden till grön.
    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Spara presentationen till disk.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ange en gradientbakgrund för en bild**

En gradient är en grafisk effekt som skapas genom en gradvis färgförändring. När den används som bildbakgrund kan gradienter göra presentationer mer konstnärliga och professionella. Aspose.Slides låter dig ange en gradientfärg som bakgrund för bilder.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Ange bildens [BackgroundType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/backgroundtype/) till `OwnBackground`.
3. Ange bildbakgrundens [FillType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/filltype/) till `Gradient`.
4. Använd metoden [getGradientFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fillformat/#getgradientformat) på [FillFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fillformat/) för att konfigurera dina föredragna gradientinställningar.
5. Spara den modifierade presentationen.

Följande Python‑exempel visar hur du anger en gradientfärg som bakgrund för en bild:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, TileFlip
from java.awt import Color

# Skapa en instans av Presentation-klassen.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Applicera en gradienteffekt på bakgrunden.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient)

    gradient_format = slide.getBackground().getFillFormat().getGradientFormat()
    gradient_format.setTileFlip(TileFlip.FlipBoth)

    # Lägg till gradientfärgerna. Utan gradientstopp återgår bakgrunden till en standard svart-till-vit ramp.
    gradient_format.getGradientStops().add(0.0, Color.CYAN)
    gradient_format.getGradientStops().add(1.0, Color.BLUE)

    # Spara presentationen till disk.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ange en bild som bildbakgrund**

Förutom solida och gradientfyllningar låter Aspose.Slides dig använda bilder som bildbakgrund.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Ange bildens [BackgroundType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/backgroundtype/) till `OwnBackground`.
3. Ange bildbakgrundens [FillType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/filltype/) till `Picture`.
4. Ladda den bild du vill använda som bildbakgrund.
5. Lägg till bilden i presentationens bildsamling.
6. Använd metoden [getPictureFillFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fillformat/#getpicturefillformat) på [FillFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fillformat/) för att tilldela bilden som bakgrund.
7. Spara den modifierade presentationen.

Följande Python‑exempel visar hur du anger en bild som bakgrund för en bild:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

# Skapa en instans av Presentation-klassen.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Ställ in bakgrundsbildens egenskaper.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    # Ladda bilden.
    image = Images.fromFile("Tulips.jpg")
    # Lägg till bilden i presentationens bildsamling.
    presentation_image = presentation.getImages().addImage(image)
    image.dispose()

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    # Spara presentationen till disk.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

```python
import jpide
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

    # Ställ in bilden som används för bakgrundsfyllning.
    background_picture_fill_format = background.getFillFormat().getPictureFillFormat()
    background_picture_fill_format.getPicture().setImage(presentation_image)

    # Ställ in bildfyllningsläget till Tile och justera tile egenskaperna.
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

{{% alert color="info" title="Obs" %}}
Läs mer: [Tile Picture as Texture](/slides/sv/python-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Ändra bakgrundsbildens transparens**

Du kanske vill justera transparensen för en bilds bakgrund för att låta bildens innehåll framträda tydligare. Följande Python‑kod visar hur du ändrar transparensen för en bildbakgrund:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Presentation, SaveFormat

transparency_value = 30  # Till exempel.

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Hämta samlingen av bildtransformeringsoperationer.
    image_transform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform()

    # Hitta en befintlig fast-procent transparenseffekt.
    transparency_operation = None
    for operation in image_transform:
        if isinstance(operation, AlphaModulateFixed):
            transparency_operation = operation
            break

    # Ställ in det nya transparensvärdet.
    if transparency_operation is None:
        image_transform.addAlphaModulateFixedEffect(100 - transparency_value)
    else:
        transparency_operation.setAmount(100 - transparency_value)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hämta bildens bakgrundsvärde**

Aspose.Slides låter dig hämta en bilds effektiva bakgrundsvärden med hjälp av metoden [getEffective](https://reference.aspose.com/slides/sv/python-java/aspose.slides/background/#geteffective) på [Background](https://reference.aspose.com/slides/sv/python-java/aspose.slides/background/). De returnerade data visar de effektiva fyll- och effektformaten.

Genom att använda [BaseSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslide/) klassens [getBackground](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslide/#getbackground) metod kan du hämta bakgrunden för en bild.

Följande Python‑exempel visar hur du hämtar en bilds effektiva bakgrundsvärde:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

# Skapa en instans av Presentation-klassen.
presentation = Presentation("Sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Hämta den effektiva bakgrunden, med hänsyn till master, layout och tema.
    effective_background = slide.getBackground().getEffective()

    if effective_background.getFillFormat().getFillType() == FillType.Solid:
        print("Fill color:", effective_background.getFillFormat().getSolidFillColor())
    else:
        print("Fill type:", effective_background.getFillFormat().getFillType())
finally:
    presentation.dispose()
```

## **FAQ**

**Kan jag återställa en anpassad bakgrund och återgå till temats/layoute­ns bakgrund?**

Ja. Ta bort bildens anpassade fyllning, så ärver bakgrunden igen från motsvarande [layout](/slides/sv/python-java/slide-layout/)/[master](/slides/sv/python-java/slide-master/) bild (dvs. [theme background](/slides/sv/python-java/presentation-theme/)).

**Vad händer med bakgrunden om jag ändrar presentationens tema senare?**

Om en bild har sin egen fyllning förblir den oförändrad. Om bakgrunden ärvs från [layout](/slides/sv/python-java/slide-layout/)/[master](/slides/sv/python-java/slide-master/) uppdateras den för att matcha det [new theme](/slides/sv/python-java/presentation-theme/).