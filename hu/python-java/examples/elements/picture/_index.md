---
title: Kép
type: docs
weight: 50
url: /hu/python-java/examples/elements/picture/
keywords:
- kód példa
- kép
- kép hozzáadása
- kép elérése
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Memóriában létrehozott képek beillesztése és elérése az Aspose.Slides for Python via Java használatával, PowerPoint és OpenDocument prezentációk példáival."
---
Ez a cikk bemutatja, hogyan lehet beilleszteni és elérni a képeket a memóriában lévő képekből a **Aspose.Slides for Python via Java** használatával. Az alábbi példák memóriában hoznak létre egy képet, elhelyezik egy dián, majd lekérik a képkeretet.

Telepítse a csomagot az [Installation](/slides/hu/python-java/installation/) útmutató szerint. Minden példa a `asposeslides`‑t importálja a JVM indítása előtt, majd a JVM futása közben importálja az API‑t.

## **Kép hozzáadása**

Ez a kód egy kis bitmapet generál, átalakítja egy adatfolyammá, és képkockaként illeszti be az első diára.

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

    # Egyszerű memóriabeli képet hoz létre.
    bitmap = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = bitmap.createGraphics()
    try:
        color = Color(144, 238, 144)
        graphics.setPaint(color)
        graphics.fillRect(0, 0, 100, 100)
    finally:
        graphics.dispose()

    # A bitmapet bájt tömbbé konvertálja.
    bitmap_stream = ByteArrayOutputStream()
    ImageIO.write(bitmap, "png", bitmap_stream)
    png_bytes = bitmap_stream.toByteArray()

    # A képet hozzáadja a prezentációhoz.
    image_stream = ByteArrayInputStream(png_bytes)
    image = presentation.getImages().addImage(image_stream)

    # Képkeretet szúr be, amely megjeleníti a képet az első dián.
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image)

    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kép elérése**

Ez a példa biztosítja, hogy egy dián legyen képkeret, majd eléri az elsőként megtaláltat.

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