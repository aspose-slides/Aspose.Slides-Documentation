---
title: Afbeelding
type: docs
weight: 50
url: /nl/python-java/examples/elements/picture/
keywords:
- codevoorbeeld
- afbeelding
- afbeelding toevoegen
- afbeelding benaderen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Afbeeldingen invoegen en benaderen die in het geheugen zijn gemaakt met Aspose.Slides for Python via Java, met voorbeelden voor PowerPoint- en OpenDocument-presentaties."
---
Dit artikel laat zien hoe u afbeeldingen vanuit in‑memory‑afbeeldingen kunt invoegen en benaderen met **Aspose.Slides for Python via Java**. De onderstaande voorbeelden maken een afbeelding in het geheugen, plaatsen deze op een dia en halen vervolgens het afbeeldingsframe op.

Installeer het pakket zoals beschreven in [Installation](/slides/nl/python-java/installation/). Elk voorbeeld importeert `asposeslides` voordat de JVM wordt gestart en importeert daarna de API zodra de JVM draait.

## **Afbeelding toevoegen**

Deze code genereert een kleine bitmap, zet deze om naar een stream en voegt hem in als een afbeeldingsframe op de eerste dia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from java.awt.image import BufferedImage
from java.io import ByteArrayInputStream, ByteArrayOutputStream
from javax.imageio import ImageIO
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Maak een eenvoudige in-memory afbeelding.
    bitmap = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = bitmap.createGraphics()
    try:
        color = Color(144, 238, 144)
        graphics.setPaint(color)
        graphics.fillRect(0, 0, 100, 100)
    finally:
        graphics.dispose()

    # Converteer de bitmap naar een byte array.
    bitmap_stream = ByteArrayOutputStream()
    ImageIO.write(bitmap, "png", bitmap_stream)
    png_bytes = bitmap_stream.toByteArray()

    # Voeg de afbeelding toe aan de presentatie.
    image_stream = ByteArrayInputStream(png_bytes)
    image = presentation.getImages().addImage(image_stream)

    # Voeg een picture frame toe dat de afbeelding op de eerste dia toont.
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image)

    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Afbeelding benaderen**

Dit voorbeeld zorgt ervoor dat een dia een afbeeldingsframe bevat en benadert vervolgens het eerste dat wordt gevonden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt.image import BufferedImage
from java.io import ByteArrayInputStream, ByteArrayOutputStream
from javax.imageio import ImageIO
from asposeslides.api import PictureFrame, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    bitmap = BufferedImage(40, 40, BufferedImage.TYPE_INT_ARGB)
    bitmap_stream = ByteArrayOutputStream()
    ImageIO.write(bitmap, "png", bitmap_stream)
    png_bytes = bitmap_stream.toByteArray()

    image_stream = ByteArrayInputStream(png_bytes)
    image = presentation.getImages().addImage(image_stream)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image)

    picture_frame = None
    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is None:
        print("The slide contains no picture frames.")
finally:
    presentation.dispose()
```