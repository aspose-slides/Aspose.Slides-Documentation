---
title: "SmartArt"
type: docs
weight: 140
url: /th/python-java/examples/elements/smart-art/
keywords:
- "ตัวอย่างโค้ด"
- "SmartArt"
- "เพิ่ม SmartArt"
- "เข้าถึง SmartArt"
- "ลบ SmartArt"
- "เค้าโครง SmartArt"
- "PowerPoint"
- "OpenDocument"
- "งานนำเสนอ"
- "Python"
- "Java"
- "Aspose.Slides"
description: "ทำงานกับ SmartArt ใน Aspose.Slides สำหรับ Python ผ่าน Java: เพิ่ม, เข้าถึง, ลบ, และเปลี่ยนเค้าโครงแผนภาพในงานนำเสนอ PowerPoint และ OpenDocument"
---
บทความนี้สาธิตวิธีการเพิ่มกราฟิก SmartArt, เข้าถึง, ลบ และเปลี่ยนเค้าโครงโดยใช้ **Aspose.Slides for Python via Java**.

ติดตั้งแพ็กเกจตามที่อธิบายใน [Installation](/slides/th/python-java/installation/). ตัวอย่างแต่ละอันจะ import `asposeslides` ก่อนเริ่ม JVM จากนั้นค่อย import API หลังจาก JVM ทำงานแล้ว.

## **เพิ่ม SmartArt**

แทรกกราฟิก SmartArt โดยใช้หนึ่งในเค้าโครงที่มีมาให้.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)
finally:
    presentation.dispose()
```

## **เข้าถึง SmartArt**

ดึงอ็อบเจ็กต์ SmartArt ตัวแรกบนสไลด์.

```python
import jpife
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    first_smart_art = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, SmartArt):
            first_smart_art = shape
            break
finally:
    presentation.dispose()
```

## **ลบ SmartArt**

ลบรูปแบบ SmartArt ออกจากสไลด์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    slide.getShapes().remove(smart_art)
finally:
    presentation.dispose()
```

## **เปลี่ยนเค้าโครง SmartArt**

อัปเดตประเภทเค้าโครงของกราฟิก SmartArt ที่มีอยู่.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.VerticalPictureList)
finally:
    presentation.dispose()
```