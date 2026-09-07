---
title: การเปลี่ยนสไลด์
type: docs
weight: 110
url: /th/python-java/examples/elements/slide-transition/
keywords:
- ตัวอย่างโค้ด
- การเปลี่ยนสไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ใช้และลบการเปลี่ยนสไลด์ และตั้งค่าการกำหนดเวลาอัตโนมัติของการเลื่อนสไลด์ด้วยตัวอย่างโค้ด Aspose.Slides for Python via Java สำหรับการนำเสนอรูปแบบ PPT, PPTX, และ ODP."
---
บทความนี้แสดงวิธีการใช้เอฟเฟกต์การเปลี่ยนสไลด์และการตั้งเวลาโดยใช้ **Aspose.Slides for Python via Java**.

ติดตั้งแพ็กเกจตามที่อธิบายใน [Installation](/slides/th/python-java/installation/). ตัวอย่างแต่ละตัวจะนำเข้า `asposeslides` ก่อนเริ่ม JVM จากนั้นจึงนำเข้า API หลังจาก JVM ทำงานแล้ว.

## **เพิ่มการเปลี่ยนสไลด์**

ใช้เอฟเฟกต์การเปลี่ยนแบบจางลงกับสไลด์แรก.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # ใช้การเปลี่ยนแบบจางลง.
finally:
    presentation.dispose()
```

## **เข้าถึงการเปลี่ยนสไลด์**

อ่านประเภทการเปลี่ยนที่กำหนดให้กับสไลด์ในปัจจุบัน.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Push)

    # เข้าถึงประเภทการเปลี่ยน.
    transition_type = slide.getSlideShowTransition().getType()
finally:
    presentation.dispose()
```

## **ลบการเปลี่ยนสไลด์**

ลบเอฟเฟกต์การเปลี่ยนใด ๆ ทั้งหมด. JPype แสดงค่าคงที่ของ Java ชื่อ `None` เป็น `None_` เนื่องจาก `None` เป็นคำสำรองใน Python.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Fade)

    # ลบเอฟเฟกต์การเปลี่ยน.
    slide.getSlideShowTransition().setType(TransitionType.None_)
finally:
    presentation.dispose()
```

## **ตั้งค่าระยะเวลาการเปลี่ยน**

ระบุระยะเวลาที่สไลด์จะแสดงก่อนที่จะเปลี่ยนโดยอัตโนมัติ ตัวอย่างนี้จะเปลี่ยนหลังจากสองวินาทีและยังอนุญาตให้เปลี่ยนด้วยการคลิกเมาส์ การตั้งเวลานี้ควบคุมการเปลี่ยนสไลด์ ไม่ใช่ความเร็วของเอฟเฟกต์การเปลี่ยน.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setAdvanceOnClick(True)
    slide.getSlideShowTransition().setAdvanceAfter(True)
    slide.getSlideShowTransition().setAdvanceAfterTime(2000)  # หน่วยเป็นมิลลิวินาที.
finally:
    presentation.dispose()
```