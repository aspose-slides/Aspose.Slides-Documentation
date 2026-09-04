---
title: หมึก
type: docs
weight: 180
url: /th/python-java/examples/elements/ink/
keywords:
- ตัวอย่างโค้ด
- หมึก
- เข้าถึงหมึก
- ลบหมึก
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เข้าถึงและลบรูปร่างหมึกใน Aspose.Slides for Python via Java สำหรับการนำเสนอ, รวมถึงไฟล์ PPT, PPTX และ ODP."
---
บทความนี้ให้ตัวอย่างของการเข้าถึงรูปร่างหมึกที่มีอยู่แล้วและการลบมันโดยใช้ **Aspose.Slides for Python via Java**.

ติดตั้งแพคเกจตามที่อธิบายใน [Installation](/slides/th/python-java/installation/). ตัวอย่างแต่ละตัวจะนำเข้า `asposeslides` ก่อนเริ่ม JVM แล้วจึงนำเข้า API หลังจาก JVM ทำงานแล้ว.

{{% alert color="info" title="Note" %}}
รูปร่างหมึกเป็นการป้อนข้อมูลโดยผู้ใช้จากอุปกรณ์พิเศษ. Aspose.Slides ไม่สามารถสร้างเส้นหมึกใหม่โดยโปรแกรมได้ แต่คุณสามารถอ่านและแก้ไขหมึกที่มีอยู่ได้.
{{% /alert %}}

## **เข้าถึงหมึก**

อ่านแท็กจากรูปร่างหมึกแรกบนสไลด์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().get_Item(0)
    if isinstance(shape, Ink):
        tags = shape.getCustomData().getTags()
        if tags.size() > 0:
            tag_name = tags.getNameByIndex(0)
            # ใช้ tag_name ตามที่ต้องการ.
finally:
    presentation.dispose()
```

## **ลบหมึก**

ลบรูปร่างหมึกออกจากสไลด์หากมีอยู่.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    ink = None
    for shape in slide.getShapes():
        if isinstance(shape, Ink):
            ink = shape
            break

    if ink is not None:
        slide.getShapes().remove(ink)
finally:
    presentation.dispose()
```