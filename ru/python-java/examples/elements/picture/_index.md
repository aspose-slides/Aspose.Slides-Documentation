---
title: Изображение
type: docs
weight: 50
url: /ru/python-java/examples/elements/picture/
keywords:
- пример кода
- изображение
- добавить изображение
- получить изображение
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Вставка и получение изображений, созданных в памяти с использованием Aspose.Slides for Python via Java, с примерами для презентаций PowerPoint и OpenDocument."
---
В этой статье демонстрируется, как вставлять и получать изображения из изображений в памяти с использованием **Aspose.Slides for Python via Java**. Приведённые ниже примеры создают изображение в памяти, размещают его на слайде и затем извлекают рамку изображения.

Установите пакет, как описано в разделе [Installation](/slides/ru/python-java/installation/). Каждый пример импортирует `asposeslides` перед запуском JVM, а затем импортирует API после запуска JVM.

## **Добавить изображение**

Этот код генерирует небольшой битмап, преобразует его в поток и вставляет его как рамку изображения на первый слайд.

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

    # Создать простое изображение в памяти.
    bitmap = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = bitmap.createGraphics()
    try:
        color = Color(144, 238, 144)
        graphics.setPaint(color)
        graphics.fillRect(0, 0, 100, 100)
    finally:
        graphics.dispose()

    # Преобразовать битмап в массив байтов.
    bitmap_stream = ByteArrayOutputStream()
    ImageIO.write(bitmap, "png", bitmap_stream)
    png_bytes = bitmap_stream.toByteArray()

    # Добавить изображение в презентацию.
    image_stream = ByteArrayInputStream(png_bytes)
    image = presentation.getImages().addImage(image_stream)

    # Вставить рамку изображения, отображающую картинку на первом слайде.
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image)

    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Получить изображение**

Этот пример проверяет, что слайд содержит рамку изображения, а затем получает первую найденную.

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