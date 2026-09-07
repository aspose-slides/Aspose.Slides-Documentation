---
title: تصویر
type: docs
weight: 50
url: /fa/python-java/examples/elements/picture/
keywords:
- مثال کد
- تصویر
- افزودن تصویر
- دسترسی به تصویر
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "درج و دسترسی به تصاویری که در حافظه ایجاد شده‌اند با استفاده از Aspose.Slides برای Python از طریق Java، با مثال‌هایی برای ارائه‌های PowerPoint و OpenDocument."
---
این مقاله نشان می‌دهد چگونه می‌توان تصاویر را از تصاویر درون حافظه درج و دسترسی یافت با استفاده از **Aspose.Slides for Python via Java**. مثال‌های زیر یک تصویر را در حافظه ایجاد می‌کنند، آن را بر روی یک اسلاید قرار می‌دهند و سپس فریم تصویر را بازیابی می‌کنند.

پکیج را همان‌طور که در [Installation](/slides/fa/python-java/installation/) توضیح داده شده است نصب کنید. هر مثال قبل از راه‌اندازی JVM، `asposeslides` را ایمپورت می‌کند و سپس پس از راه‌اندازی JVM، API را ایمپورت می‌نماید.

## **افزودن تصویر**

این کد یک بیت‌مپ کوچک تولید می‌کند، آن را به یک جریان تبدیل می‌کند و به‌عنوان فریم تصویر در اسلاید اول وارد می‌نماید.

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

    # ایجاد یک تصویر ساده در حافظه.
    bitmap = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = bitmap.createGraphics()
    try:
        color = Color(144, 238, 144)
        graphics.setPaint(color)
        graphics.fillRect(0, 0, 100, 100)
    finally:
        graphics.dispose()

    # تبدیل بیت‌مپ به آرایه بایت.
    bitmap_stream = ByteArrayOutputStream()
    ImageIO.write(bitmap, "png", bitmap_stream)
    png_bytes = bitmap_stream.toByteArray()

    # افزودن تصویر به ارائه.
    image_stream = ByteArrayInputStream(png_bytes)
    image = presentation.getImages().addImage(image_stream)

    # درج فریم تصویری که تصویر را در اسلاید اول نمایش می‌دهد.
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image)

    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **دسترسی به تصویر**

این مثال اطمینان می‌یابد که یک اسلاید شامل فریم تصویر است و سپس اولین موردی که پیدا می‌کند را دسترسی می‌یابد.

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