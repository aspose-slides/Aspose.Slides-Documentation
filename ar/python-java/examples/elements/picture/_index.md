---
title: صورة
type: docs
weight: 50
url: /ar/python-java/examples/elements/picture/
keywords:
- مثال على الكود
- صورة
- إضافة صورة
- الوصول إلى الصورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إدراج والوصول إلى الصور التي تم إنشاؤها في الذاكرة باستخدام Aspose.Slides for Python via Java، مع أمثلة لعروض PowerPoint و OpenDocument."
---
توضح هذه المقالة كيفية إدراج الصور والوصول إليها من صور مخزنة في الذاكرة باستخدام **Aspose.Slides for Python via Java**. الأمثلة أدناه تُنشئ صورة في الذاكرة، وتضعها على شريحة، ثم تسترجع إطار الصورة.

قم بتثبيت الحزمة كما هو موضح في [التثبيت](/slides/ar/python-java/installation/). كل مثال يستورد `asposeslides` قبل بدء JVM، ثم يستورد API بعد تشغيل JVM.

## **إضافة صورة**

يقوم هذا الكود بإنشاء صورة نقطية صغيرة، ويحولها إلى تدفق، ويُدرجها كإطار صورة على الشريحة الأولى.

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

    # إنشاء صورة بسيطة في الذاكرة.
    bitmap = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = bitmap.createGraphics()
    try:
        color = Color(144, 238, 144)
        graphics.setPaint(color)
        graphics.fillRect(0, 0, 100, 100)
    finally:
        graphics.dispose()

    # تحويل الـ bitmap إلى مصفوفة بايت.
    bitmap_stream = ByteArrayOutputStream()
    ImageIO.write(bitmap, "png", bitmap_stream)
    png_bytes = bitmap_stream.toByteArray()

    # إضافة الصورة إلى العرض التقديمي.
    image_stream = ByteArrayInputStream(png_bytes)
    image = presentation.getImages().addImage(image_stream)

    # إدراج إطار صورة يعرض الصورة على الشريحة الأولى.
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image)

    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الوصول إلى صورة**

يتأكد هذا المثال من أن الشريحة تحتوي على إطار صورة ثم يصل إلى أول إطار يجدونه.

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