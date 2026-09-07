---
title: Obraz
type: docs
weight: 50
url: /pl/python-java/examples/elements/picture/
keywords:
- przykład kodu
- obraz
- dodaj obraz
- dostęp do obrazu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Wstawianie i dostęp do obrazów tworzonych w pamięci przy użyciu Aspose.Slides dla Pythona poprzez Java, z przykładami dla prezentacji PowerPoint i OpenDocument."
---
Ten artykuł demonstruje, jak wstawiać i uzyskiwać dostęp do obrazów z obrazów przechowywanych w pamięci przy użyciu **Aspose.Slides for Python via Java**. Poniższe przykłady tworzą obraz w pamięci, umieszczają go na slajdzie, a następnie pobierają ramkę obrazu.

Zainstaluj pakiet zgodnie z opisem w [Installation](/slides/pl/python-java/installation/). Każdy przykład importuje `asposeslides` przed uruchomieniem JVM, a następnie importuje API po uruchomieniu JVM.

## **Add a Picture**

Ten kod generuje mały bitmap, konwertuje go na strumień i wstawia jako ramkę obrazu na pierwszym slajdzie.

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

    # Utwórz prosty obraz w pamięci.
    bitmap = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = bitmap.createGraphics()
    try:
        color = Color(144, 238, 144)
        graphics.setPaint(color)
        graphics.fillRect(0, 0, 100, 100)
    finally:
        graphics.dispose()

    # Konwertuj bitmapę na tablicę bajtów.
    bitmap_stream = ByteArrayOutputStream()
    ImageIO.write(bitmap, "png", bitmap_stream)
    png_bytes = bitmap_stream.toByteArray()

    # Dodaj obraz do prezentacji.
    image_stream = ByteArrayInputStream(png_bytes)
    image = presentation.getImages().addImage(image_stream)

    # Wstaw ramkę obrazu wyświetlającą obraz na pierwszym slajdzie.
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image)

    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Access a Picture**

Ten przykład zapewnia, że slajd zawiera ramkę obrazu, a następnie uzyskuje dostęp do pierwszej znalezionej.

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