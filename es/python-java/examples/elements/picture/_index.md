---
title: Imagen
type: docs
weight: 50
url: /es/python-java/examples/elements/picture/
keywords:
- ejemplo de código
- imagen
- agregar imagen
- acceder a la imagen
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Insertar y acceder a imágenes creadas en memoria utilizando Aspose.Slides para Python a través de Java, con ejemplos para presentaciones de PowerPoint y OpenDocument."
---
Este artículo muestra cómo insertar y acceder a imágenes desde imágenes en memoria utilizando **Aspose.Slides for Python via Java**. Los ejemplos siguientes crean una imagen en memoria, la colocan en una diapositiva y luego recuperan el marco de imagen.

Instala el paquete como se describe en [Instalación](/slides/es/python-java/installation/). Cada ejemplo importa `asposeslides` antes de iniciar la JVM, y luego importa la API una vez que la JVM está en ejecución.

## **Agregar una imagen**

Este código genera un bitmap pequeño, lo convierte en un flujo y lo inserta como un marco de imagen en la primera diapositiva.

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

    # Crear una imagen simple en memoria.
    bitmap = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = bitmap.createGraphics()
    try:
        color = Color(144, 238, 144)
        graphics.setPaint(color)
        graphics.fillRect(0, 0, 100, 100)
    finally:
        graphics.dispose()

    # Convertir el bitmap a un array de bytes.
    bitmap_stream = ByteArrayOutputStream()
    ImageIO.write(bitmap, "png", bitmap_stream)
    png_bytes = bitmap_stream.toByteArray()

    # Añadir la imagen a la presentación.
    image_stream = ByteArrayInputStream(png_bytes)
    image = presentation.getImages().addImage(image_stream)

    # Insertar un marco de imagen que muestra la imagen en la primera diapositiva.
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image)

    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Acceder a una imagen**

Este ejemplo verifica que una diapositiva contenga un marco de imagen y luego accede al primero que encuentra.

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