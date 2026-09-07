---
title: รูปภาพ
type: docs
weight: 50
url: /th/python-java/examples/elements/picture/
keywords:
- ตัวอย่างโค้ด
- รูปภาพ
- เพิ่มรูปภาพ
- เข้าถึงรูปภาพ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "แทรกและเข้าถึงรูปภาพที่สร้างในหน่วยความจำโดยใช้ Aspose.Slides for Python via Java พร้อมตัวอย่างสำหรับการนำเสนอ PowerPoint และ OpenDocument"
---
บทความนี้แสดงวิธีการแทรกและเข้าถึงรูปภาพจากภาพที่อยู่ในหน่วยความจำโดยใช้ **Aspose.Slides for Python via Java**. ตัวอย่างด้านล่างจะสร้างภาพในหน่วยความจำ วางลงบนสไลด์ แล้วดึงเฟรมรูปภาพออกมา

ติดตั้งแพคเกจตามที่อธิบายใน [การติดตั้ง](/slides/th/python-java/installation/). แต่ละตัวอย่างจะทำการ import `asposeslides` ก่อนเริ่ม JVM แล้วจึง import API หลังจาก JVM ทำงานแล้ว

## **เพิ่มรูปภาพ**

โค้ดนี้สร้างบิตแมพขนาดเล็ก แปลงเป็นสตรีม และแทรกเป็นเฟรมรูปภาพบนสไลด์แรก.

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

    # สร้างภาพง่ายในหน่วยความจำ.
    bitmap = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = bitmap.createGraphics()
    try:
        color = Color(144, 238, 144)
        graphics.setPaint(color)
        graphics.fillRect(0, 0, 100, 100)
    finally:
        graphics.dispose()

    # แปลงบิตแมพเป็นอาเรย์ของไบต์.
    bitmap_stream = ByteArrayOutputStream()
    ImageIO.write(bitmap, "png", bitmap_stream)
    png_bytes = bitmap_stream.toByteArray()

    # เพิ่มรูปภาพไปยังงานนำเสนอ.
    image_stream = ByteArrayInputStream(png_bytes)
    image = presentation.getImages().addImage(image_stream)

    # แทรกเฟรมรูปภาพที่แสดงรูปบนสไลด์แรก.
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image)

    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เข้าถึงรูปภาพ**

ตัวอย่างนี้ตรวจสอบให้แน่ใจว่าสไลด์มีเฟรมรูปภาพและจากนั้นเข้าถึงเฟรมแรกที่พบ.

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