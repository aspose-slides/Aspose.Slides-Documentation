---
title: สร้างภาพย่อนของรูปร่างในการนำเสนอใน Python ผ่าน Java
linktitle: ภาพย่อของรูปร่าง
type: docs
weight: 70
url: /th/python-java/create-shape-thumbnails/
keywords:
- ภาพย่อของรูปร่าง
- รูปภาพของรูปร่าง
- เรนเดอร์รูปร่าง
- การเรนเดอร์รูปร่าง
- ขอบเขตภาพจริง
- ขอบเขตของรูปร่าง
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "สร้างภาพย่อยของรูปร่างคุณภาพสูงจากสไลด์ PowerPoint ด้วย Aspose.Slides for Python via Java – สร้างและส่งออกรูปย่อนของการนำเสนอได้อย่างง่ายดาย."
---
## **บทนำ**

Aspose.Slides for Python via Java สามารถใช้เพื่อสร้างไฟล์การนำเสนอที่แต่ละหน้าตรงกับสไลด์ได้ สไลด์สามารถดูได้โดยเปิดไฟล์การนำเสนอด้วย Microsoft PowerPoint อย่างไรก็ตาม นักพัฒนาบางครั้งต้องการดูภาพของรูปร่างแยกต่างหากในโปรแกรมดูภาพ ในกรณีเช่นนี้ Aspose.Slides for Python via Java จะช่วยสร้างภาพย่อของรูปร่างในสไลด์

บทความนี้อธิบายวิธีสร้างภาพย่อของรูปร่างในหลายรูปแบบ:

- สร้างภาพย่อของรูปร่างภายในสไลด์
- สร้างภาพย่อของรูปร่างบนสไลด์ด้วยขนาดที่กำหนดโดยผู้ใช้
- สร้างภาพย่อของรูปร่างโดยอิงตามขอบเขตของการแสดงผลของรูปร่าง

## **สร้างภาพย่อของรูปร่างจากสไลด์**
เพื่อสร้างภาพย่อของรูปร่างจากสไลด์ใด ๆ ด้วย Aspose.Slides for Python via Java ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) 
1. รับอ้างอิงถึงสไลด์โดยใช้ ID หรือดัชนีของสไลด์
1. [รับภาพย่อของรูปร่าง](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getImage) บนสไลด์ที่อ้างถึงโดยใช้สเกลเริ่มต้น
1. บันทึกภาพย่อในรูปแบบภาพที่คุณต้องการ

โค้ดตัวอย่างต่อไปนี้แสดงวิธีสร้างภาพย่อของรูปร่างจากสไลด์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์การนำเสนอ.
presentation = Presentation("Thumbnail.pptx")
try:
    # สร้างภาพเต็มขนาด.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage()
    try:
        # บันทึกภาพลงดิสก์ในรูปแบบ PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **สร้างภาพย่อด้วยปัจจัยการสเกลที่กำหนดโดยผู้ใช้**
เพื่อสร้างภาพย่อของรูปร่างบนสไลด์ด้วย Aspose.Slides for Python via Java ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) 
1. รับอ้างอิงถึงสไลด์โดยใช้ ID หรือดัชนีของสไลด์
1. [รับภาพย่อของรูปร่าง](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getImage) บนสไลด์ที่อ้างถึงโดยใช้ขนาดที่กำหนดโดยผู้ใช้
1. บันทึกภาพย่อในรูปแบบภาพที่คุณต้องการ

โค้ดตัวอย่างต่อไปนี้แสดงวิธีสร้างภาพย่อของรูปร่างตามปัจจัยการสเกลที่กำหนด:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์การนำเสนอ.
presentation = Presentation("Thumbnail.pptx")
try:
    # สร้างภาพที่ถูกสเกลโดยอัตราส่วน 2 ในทั้งสองทิศทาง.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 2, 2)
    try:
        # บันทึกภาพลงดิสก์ในรูปแบบ PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **สร้างภาพย่อของรูปร่างโดยอิงตามขอบเขตของลักษณะที่ปรากฏ**
วิธีนี้ช่วยให้นักพัฒนาสามารถสร้างภาพย่อในขอบเขตของการแสดงผลของรูปร่างได้ โดยจะคำนึงถึงเอฟเฟกต์ทั้งหมดของรูปร่าง ภาพย่อที่สร้างจะถูกจำกัดโดยขอบเขตของสไลด์ เพื่อสร้างภาพย่อของรูปร่างบนสไลด์ภายในขอบเขตการแสดงผล ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) 
1. รับอ้างอิงถึงสไลด์โดยใช้ ID หรือดัชนีของสไลด์
1. รับภาพย่อของรูปร่างบนสไลด์โดยใช้ขอบเขตการแสดงผลของรูปร่าง
1. บันทึกภาพย่อในรูปแบบภาพที่คุณต้องการ

โค้ดตัวอย่างต่อไปนี้อิงตามขั้นตอนข้างต้น:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์การนำเสนอ.
presentation = Presentation("Thumbnail.pptx")
try:
    # สร้างภาพเต็มขนาด.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1)
    try:
        # บันทึกภาพลงดิสก์ในรูปแบบ PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **รับขอบเขตภาพจริงของรูปร่าง**

คุณสมบัติเฟรมของ [Shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/)—เมธอด [getX](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getX), [getY](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getY), [getWidth](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getWidth) และ [getHeight](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getHeight)—อธิบายสี่เหลี่ยมที่เก็บในโมเดลการนำเสนอ เนื้อหาที่จริง ๆ แล้วแสดงผลอาจขยายออกนอกเฟรมหรือครอบคลุมสี่เหลี่ยมที่จัดเรียงตามแกนที่ต่างออกไป การหมุน, โครงร่าง, ลูกศร, การจัดวางและการล้นของข้อความ, รูปทรง SmartArt ที่สร้างขึ้น, และเอฟเฟกต์การเรนเดอร์อื่น ๆ สามารถเปลี่ยนพื้นที่ที่ใช้ได้ทั้งหมด

ใช้ [Shape.getVisualBounds](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getVisualBounds) เพื่อคำนวณพื้นที่ที่ใช้โดยไม่ต้องสร้างภาพ เมธอดจะคืนค่า [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) ในพิกัดสไลด์ ค่าที่คืนจะไม่ถูกคลิปให้เข้ากับสไลด์ ดังนั้นพิกัดอาจเป็นค่าลบเมื่อเนื้อหาขยายเกินต้นทางของสไลด์

ตัวอย่างต่อไปนี้รับและเปรียบเทียบเฟรมกับขอบเขตภาพจริง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.awt.geom import Rectangle2D

presentation = Presentation("example.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    visual_bounds = shape.getVisualBounds()
    frame_bounds = Rectangle2D.Float(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight())

    print("Frame bounds:", frame_bounds)
    print("Visual bounds:", visual_bounds)
finally:
    presentation.dispose()
```

[Rectangle2D.Float] เดียวกันสามารถใช้จัดแนวรูปร่างที่อยู่ใกล้เคียงให้ชิดด้านซ้าย, ขวา, ด้านบนหรือด้านล่าง; จองพื้นที่เพียงพอในเลเอาต์ที่สร้าง; หรือค้นหาเนื้อหาที่อยู่นอกบริเวณที่อนุญาต ขอบเขตภาพจริงมีประโยชน์เป็นพิเศษสำหรับ SmartArt, กล่องข้อความ, ลูกศร, รูปภาพ, รูปร่างที่หมุน, และกลุ่มรูปร่าง ซึ่งเฟรมที่เก็บอาจไม่แสดงผลลัพธ์ที่เรนเดอร์เต็มรูปแบบ

ใช้ [Shape.getVisualBounds](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getVisualBounds) เมื่อคุณต้องการพิกัดสำหรับการจัดวางหรือการตรวจสอบและไม่ต้องการบิตแมพ ใช้ [Shape.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getImage) เมื่อต้องการเรนเดอร์รูปร่าง ด้วย [ShapeThumbnailBounds](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapethumbnailbounds/) , [ShapeThumbnailBounds.Shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapethumbnailbounds/#Shape) กำหนดขนาดภาพจากขอบเขตของรูปร่างรวมการตั้งค่าโครงร่าง, ส่วน [ShapeThumbnailBounds.Appearance](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapethumbnailbounds/#Appearance) กำหนดขนาดจากการแสดงผลของรูปร่างและจำกัดผลลัพธ์ให้เข้ากับขอบเขตสไลด์ ในขณะที่ [Shape.getVisualBounds](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getVisualBounds) จะคืนเฉพาะสี่เหลี่ยมที่คำนวณและไม่คลิปให้เข้ากับสไลด์

## **FAQ**

**รูปแบบภาพใดบ้างที่สามารถใช้เมื่อบันทึกภาพย่อของรูปร่าง?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/th/python-java/aspose.slides/imageformat/), และอื่น ๆ รูปร่างยังสามารถ [ส่งออกเป็นเวกเตอร์ SVG](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#writeAsSvgToBytes) โดยบันทึกเนื้อหารูปร่างเป็น SVG

**ความแตกต่างระหว่างขอบเขต Shape กับ Appearance เมื่อเรนเดอร์ภาพย่อคืออะไร?**

`Shape` ใช้เรขาคณิตของรูปร่าง; `Appearance` พิจารณา [visual effects](/slides/th/python-java/shape-effect/) (เงา, แสงเรืองแสง ฯลฯ)

**จะเกิดอะไรขึ้นหากรูปร่างถูกตั้งค่าเป็นซ่อนไว้? จะยังคงเรนเดอร์เป็นภาพย่อหรือไม่?**

รูปร่างที่ซ่อนอยู่ยังคงเป็นส่วนหนึ่งของโมเดลและสามารถเรนเดอร์ได้; ธงซ่อนส่งผลต่อการแสดงสไลด์โชว์แต่ไม่ป้องกันการสร้างภาพของรูปร่าง

**รองรับการทำงานกับกลุ่มรูปร่าง, แผนภูมิ, SmartArt และวัตถุซับซ้อนอื่น ๆ หรือไม่?**

ใช่. ใด ๆ ที่เป็นวัตถุที่แสดงเป็น [Shape] (รวมถึง [GroupShape], [Chart] และ [SmartArt]) สามารถบันทึกเป็นภาพย่อหรือเป็น SVG ได้

**ฟอนต์ที่ติดตั้งในระบบส่งผลต่อคุณภาพของภาพย่อสำหรับรูปร่างข้อความหรือไม่?**

ใช่. คุณควร [provide the required fonts](/slides/th/python-java/custom-font/) (หรือ [configure font substitutions](/slides/th/python-java/font-substitution/)) เพื่อหลีกเลี่ยงการใช้ฟอนต์สำรองที่ไม่ต้องการและการจัดเรียงข้อความใหม่