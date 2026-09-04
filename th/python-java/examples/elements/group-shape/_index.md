---
title: กลุ่มรูปทรง
type: docs
weight: 170
url: /th/python-java/examples/elements/group-shape/
keywords:
- ตัวอย่างโค้ด
- กลุ่มรูปทรง
- เพิ่มกลุ่มรูปทรง
- เข้าถึงกลุ่มรูปทรง
- ลบกลุ่มรูปทรง
- แยกกลุ่มรูปทรง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "จัดการกลุ่มรูปทรงในการนำเสนอด้วย Aspose.Slides for Python via Java: เพิ่ม, เข้าถึง, ลบและแยกกลุ่มรูปทรงในไฟล์ PowerPoint และ OpenDocument."
---
บทความนี้แสดงวิธีการสร้างกลุ่มของรูปทรง, เข้าถึง, ลบ, และแยกกลุ่มเนื้อหาของพวกมันโดยใช้ **Aspose.Slides for Python via Java**.

ติดตั้งแพคเกจตามที่อธิบายไว้ใน [Installation](/slides/th/python-java/installation/). ตัวอย่างแต่ละอันจะนำเข้า `asposeslides` ก่อนเริ่ม JVM แล้วจึงนำเข้า API หลังจาก JVM ทำงานแล้ว.

## **เพิ่มกลุ่มรูปทรง**

สร้างกลุ่มที่ประกอบด้วยรูปทรงพื้นฐานสองรูป.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)
    group.getShapes().addAutoShape(ShapeType.Ellipse, 60, 0, 50, 50)
finally:
    presentation.dispose()
```

## **เข้าถึงกลุ่มรูปทรง**

ดึงกลุ่มรูปทรงแรกจากสไลด์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)

    first_group = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, GroupShape):
            first_group = shape
            break
finally:
    presentation.dispose()
```

## **ลบกลุ่มรูปทรง**

ลบกลุ่มรูปทรงออกจากสไลด์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()

    slide.getShapes().remove(group)
finally:
    presentation.dispose()
```

## **ยกเลิกการจัดกลุ่มรูปทรง**

ย้ายรูปทรงออกจากคอนเทนเนอร์ของกลุ่ม.

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    rectangle = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)

    # ย้ายรูปทรงออกจากกลุ่ม.
    slide.getShapes().addClone(rectangle)
    group.getShapes().remove(rectangle)
finally:
    presentation.dispose()
```