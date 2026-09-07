---
title: Bild
type: docs
weight: 50
url: /de/python-java/examples/elements/picture/
keywords:
- Codebeispiel
- Bild
- Bild hinzufügen
- Bild abrufen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Einfügen und Zugriff auf Bilder, die im Speicher erstellt wurden, mit Aspose.Slides für Python via Java, mit Beispielen für PowerPoint- und OpenDocument-Präsentationen."
---
Dieser Artikel demonstriert, wie man Bilder aus im Speicher befindlichen Bildern einfügt und darauf zugreift, wobei **Aspose.Slides for Python via Java** verwendet wird. Die nachfolgenden Beispiele erzeugen ein Bild im Speicher, platzieren es auf einer Folie und rufen anschließend den Bildrahmen ab.

Installieren Sie das Paket wie in [Installation](/slides/de/python-java/installation/) beschrieben. Jedes Beispiel importiert `asposeslides`, bevor die JVM gestartet wird, und importiert anschließend die API, nachdem die JVM läuft.

## **Bild hinzufügen**

Dieser Code erzeugt ein kleines Bitmap, konvertiert es in einen Stream und fügt es als Bildrahmen auf der ersten Folie ein.

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

    # Erstelle ein einfaches Bild im Speicher.
    bitmap = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = bitmap.createGraphics()
    try:
        color = Color(144, 238, 144)
        graphics.setPaint(color)
        graphics.fillRect(0, 0, 100, 100)
    finally:
        graphics.dispose()

    # Konvertiere das Bitmap in ein Byte-Array.
    bitmap_stream = ByteArrayOutputStream()
    ImageIO.write(bitmap, "png", bitmap_stream)
    png_bytes = bitmap_stream.toByteArray()

    # Füge das Bild zur Präsentation hinzu.
    image_stream = ByteArrayInputStream(png_bytes)
    image = presentation.getImages().addImage(image_stream)

    # Füge einen Bildrahmen ein, der das Bild auf der ersten Folie zeigt.
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image)

    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Auf ein Bild zugreifen**

Dieses Beispiel stellt sicher, dass eine Folie einen Bildrahmen enthält, und greift dann auf den ersten gefundene zu.

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