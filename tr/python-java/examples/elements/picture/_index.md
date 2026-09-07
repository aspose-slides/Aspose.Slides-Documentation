---
title: Resim
type: docs
weight: 50
url: /tr/python-java/examples/elements/picture/
keywords:
- kod örneği
- resim
- resim ekle
- resme eriş
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak bellekte oluşturulan resimleri ekleme ve erişme, PowerPoint ve OpenDocument sunumları için örneklerle."
---
Bu makale, **Aspose.Slides for Python via Java** kullanarak bellek içi görüntülerden resim ekleme ve erişme işlemlerini göstermektedir. Aşağıdaki örnekler bir resmi bellekte oluşturur, bir slayta yerleştirir ve ardından resim çerçevesini alır.

Paketi, [Installation](/slides/tr/python-java/installation/) bölümünde açıklandığı gibi kurun. Her örnek, JVM'yi başlatmadan önce `asposeslides` paketini içe aktarır, ardından JVM çalıştıktan sonra API'yi içe aktarır.

## **Add a Picture**

Bu kod, küçük bir bitmap oluşturur, onu bir akıma dönüştürür ve ilk slayta bir resim çerçevesi olarak ekler.

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

    # Basit bir bellek içi görüntü oluştur.
    bitmap = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = bitmap.createGraphics()
    try:
        color = Color(144, 238, 144)
        graphics.setPaint(color)
        graphics.fillRect(0, 0, 100, 100)
    finally:
        graphics.dispose()

    # Bitmap'i bayt dizisine dönüştür.
    bitmap_stream = ByteArrayOutputStream()
    ImageIO.write(bitmap, "png", bitmap_stream)
    png_bytes = bitmap_stream.toByteArray()

    # Görüntüyü sunuma ekle.
    image_stream = ByteArrayInputStream(png_bytes)
    image = presentation.getImages().addImage(image_stream)

    # İlk slaytta görüntüyü gösteren bir resim çerçevesi ekle.
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image)

    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Access a Picture**

Bu örnek, bir slaytta resim çerçevesi bulunduğunu doğrular ve ardından bulduğu ilk çerçeveye erişir.

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