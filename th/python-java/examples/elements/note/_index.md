---
title: บันทึกย่อ
type: docs
weight: 240
url: /th/python-java/examples/elements/note/
keywords:
- ตัวอย่างโค้ด
- บันทึกย่อ
- บันทึกของผู้พูด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ทำงานกับบันทึกสไลด์ใน Aspose.Slides สำหรับ Python ผ่าน Java: เพิ่ม, อ่าน, ลบ และอัปเดตบันทึกของผู้พูดในงานนำเสนอ PowerPoint และ OpenDocument."
---
บทความนี้แสดงวิธีการเพิ่ม, อ่าน, ลบ และอัปเดตสไลด์บันทึกย่อโดยใช้ **Aspose.Slides for Python via Java**.

ติดตั้งแพคเกจตามที่อธิบายใน [Installation](/slides/th/python-java/installation/). ตัวอย่างแต่ละตัวจะนำเข้า `asposeslides` ก่อนเริ่ม JVM, แล้วจึงนำเข้า API หลังจาก JVM ทำงานแล้ว.

## **เพิ่มสไลด์บันทึกย่อ**

สร้างสไลด์บันทึกย่อและกำหนดข้อความให้กับมัน.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")
finally:
    presentation.dispose()
```

## **เข้าถึงสไลด์บันทึกย่อ**

อ่านข้อความจากสไลด์บันทึกย่อที่มีอยู่.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")

    notes = notes_slide.getNotesTextFrame().getText()
    print(notes)
finally:
    presentation.dispose()
```

## **ลบสไลด์บันทึกย่อ**

ลบสไลด์บันทึกย่อที่เชื่อมโยงกับสไลด์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getNotesSlideManager().addNotesSlide()
    slide.getNotesSlideManager().removeNotesSlide()
finally:
    presentation.dispose()
```

## **อัปเดตข้อความบันทึกย่อ**

เปลี่ยนข้อความของสไลด์บันทึกย่อ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("Old")
    notes_slide.getNotesTextFrame().setText("Updated")
finally:
    presentation.dispose()
```