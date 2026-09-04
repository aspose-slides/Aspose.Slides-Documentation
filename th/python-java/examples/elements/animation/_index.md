---
title: การเคลื่อนไหว
type: docs
weight: 100
url: /th/python-java/examples/elements/animation/
keywords:
- ตัวอย่างโค้ด
- การเคลื่อนไหว
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "สำรวจตัวอย่างการเคลื่อนไหวของ Aspose.Slides สำหรับ Python ผ่าน Java: เพิ่ม, เข้าถึง, ลบ และจัดลำดับเอฟเฟ็กต์ในงานนำเสนอรูปแบบ PPT, PPTX, และ ODP"
---
บทความนี้แสดงวิธีการสร้างภาพเคลื่อนไหวอย่างง่ายและจัดการลำดับของพวกมันโดยใช้ **Aspose.Slides for Python via Java**.

ติดตั้งแพคเกจตามที่อธิบายไว้ใน [Installation](/slides/th/python-java/installation/). ตัวอย่างแต่ละตัวจะนำเข้า `asposeslides` ก่อนเริ่ม JVM แล้วจึงนำเข้า API หลังจาก JVM ทำงานแล้ว.

## **เพิ่มการเคลื่อนไหว**

สร้างรูปสี่เหลี่ยมและใช้เอฟเฟ็กต์ค่อยหายที่ทำงานเมื่อคลิก.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100)

    # ใช้เอฟเฟ็กต์ค่อยหาย.
    slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
finally:
    presentation.dispose()
```

## **เข้าถึงการเคลื่อนไหว**

ดึงเอฟเฟ็กต์การเคลื่อนไหวแรกจากไทม์ไลน์ของสไลด์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100)
    slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    # เข้าถึงเอฟเฟ็กต์การเคลื่อนไหวแรก.
    effect = slide.getTimeline().getMainSequence().get_Item(0)
    print("Effect type:", effect.getType())
finally:
    presentation.dispose()
```

## **ลบการเคลื่อนไหว**

ลบเอฟเฟ็กต์การเคลื่อนไหวออกจากลำดับ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100)
    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    # ลบเอฟเฟ็กต์.
    slide.getTimeline().getMainSequence().remove(effect)
finally:
    presentation.dispose()
```

## **ลำดับการเคลื่อนไหว**

เพิ่มเอฟเฟ็กต์หลายอันและควบคุมลำดับที่การเคลื่อนไหวเกิดขึ้น.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100)
    shape2 = slide.getShapes().addAutoShape(ShapeType.Ellipse, 200, 50, 100, 100)

    sequence = slide.getTimeline().getMainSequence()
    sequence.addEffect(shape1, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
    sequence.addEffect(shape2, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
finally:
    presentation.dispose()
```