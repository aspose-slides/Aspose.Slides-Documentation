---
title: สไลด์เค้าโครง
type: docs
weight: 20
url: /th/python-java/examples/elements/layout-slide/
keywords:
- ตัวอย่างโค้ด
- สไลด์เค้าโครง
- เพิ่มสไลด์เค้าโครง
- เข้าถึงสไลด์เค้าโครง
- ลบสไลด์เค้าโครง
- สไลด์เค้าโครงที่ไม่ได้ใช้
- คัดลอกสไลด์เค้าโครง
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "จัดการสไลด์เค้าโครงด้วย Aspose.Slides for Python via Java: เพิ่ม, เข้าถึง, ลบ, ทำความสะอาดและคัดลอกเค้าโครงในงานนำเสนอ PowerPoint และ OpenDocument."
---
บทความนี้แสดงวิธีการทำงานกับ **layout slides** ด้วย Aspose.Slides for Python via Java. layout slide จะกำหนดการออกแบบและการจัดรูปแบบที่สไลด์ปกติสืบทอดมา คุณสามารถเพิ่ม, เข้าถึง, ทำสำเนา, และลบ layout slides รวมถึงทำความสะอาด layout ที่ไม่ได้ใช้เพื่อลดขนาดของการนำเสนอได้

ติดตั้งแพ็กเกจตามที่อธิบายไว้ใน [Installation](/slides/th/python-java/installation/). ตัวอย่างแต่ละตัวจะนำเข้า `asposeslides` ก่อนเริ่ม JVM จากนั้นนำเข้า API หลังจาก JVM ทำงานแล้ว

## **เพิ่ม Layout Slide**

สร้าง layout slide แบบกำหนดเองเพื่อกำหนดการจัดรูปแบบที่นำกลับมาใช้ใหม่ ตัวอย่างต่อไปนี้จะเพิ่มกล่องข้อความลงใน layout ใหม่แล้วสร้างสไลด์สองสไลด์ที่ใช้ layout นี้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # สร้างสไลด์เค้าโครงโดยใช้ประเภทเค้าโครงเปล่าและชื่อที่กำหนดเอง.
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Main layout")

    # เพิ่มกล่องข้อความลงในสไลด์เค้าโครง.
    layout_text_box = layout_slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150)
    layout_text_box.getTextFrame().setText("Layout Slide Text")

    # เพิ่มสองสไลด์ที่สืบทอดข้อความจากเค้าโครง.
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
finally:
    presentation.dispose()
```

> 💡 **หมายเหตุ 1:** Layout slides ทำหน้าที่เป็นเทมเพลตสำหรับสไลด์แต่ละอัน คุณสามารถกำหนดองค์ประกอบทั่วไปเพียงครั้งเดียวและนำกลับใช้ได้ในหลายสไลด์

> 💡 **หมายเหตุ 2:** เมื่อคุณเพิ่มรูปทรงหรือข้อความลงใน layout slide สไลด์ทั้งหมดที่อ้างอิง layout นี้จะโชว์เนื้อหาที่แชร์โดยอัตโนมัติ  
> ภาพหน้าจอด้านล่างแสดงสไลด์สองสไลด์ที่สืบทอดกล่องข้อความจาก layout slide เดียวกัน

![Slides Inheriting Layout Content](layout-slide-result.png)

## **เข้าถึง Layout Slide**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # เข้าถึงสไลด์เค้าโครงตามดัชนี.
    first_layout_slide = presentation.getLayoutSlides().get_Item(0)

    # เข้าถึงสไลด์เค้าโครงตามประเภท.
    blank_layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
finally:
    presentation.dispose()
```

## **ลบ Layout Slide**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Temporary layout")

    presentation.getLayoutSlides().remove(layout_slide)
finally:
    presentation.dispose()
```

## **ลบ Layout Slides ที่ไม่ได้ใช้**

```python
import jpile
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    presentation.getLayoutSlides().removeUnused()
finally:
    presentation.dispose()
```

## **คัดลอก Layout Slide**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    source_layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Source layout")

    cloned_layout_slide = presentation.getLayoutSlides().addClone(source_layout_slide)
finally:
    presentation.dispose()
```

> ✅ **สรุป:** Layout slides ช่วยรักษาการจัดรูปแบบที่สอดคล้องกันทั่วทั้งการนำเสนอ Aspose.Slides ให้คุณสร้าง, จัดการ, ใช้งานซ้ำ, และทำความสะอาด layout ตามความต้องการ