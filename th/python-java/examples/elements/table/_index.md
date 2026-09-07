---
title: ตาราง
type: docs
weight: 120
url: /th/python-java/examples/elements/table/
keywords:
- ตัวอย่างโค้ด
- ตาราง
- เพิ่มตาราง
- เข้าถึงตาราง
- ลบตาราง
- รวมเซลล์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ทำงานกับตารางใน Aspose.Slides สำหรับ Python ผ่าน Java: เพิ่ม, เข้าถึง, ลบ, และรวมเซลล์ในงานนำเสนอ PowerPoint และ OpenDocument"
---
ตัวอย่างการเพิ่มตาราง, การเข้าถึงตาราง, การลบตาราง และการรวมเซลล์โดยใช้ **Aspose.Slides for Python via Java**.

ติดตั้งแพ็กเกจตามที่อธิบายใน [Installation](/slides/th/python-java/installation/). ตัวอย่างแต่ละอันจะนำเข้า `asposeslides` ก่อนเริ่ม JVM, จากนั้นนำเข้า API หลังจาก JVM ทำงานแล้ว.

## **เพิ่มตาราง**

สร้างตารางง่าย ๆ ที่มีสองแถวและสองคอลัมน์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)
finally:
    presentation.dispose()
```

## **เข้าถึงตาราง**

ดึงรูปร่างตารางแรกบนสไลด์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    # เข้าถึงตารางแรกบนสไลด์.
    first_table = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Table):
            first_table = shape
            break
finally:
    presentation.dispose()
```

## **ลบตาราง**

ลบตารางออกจากสไลด์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    slide.getShapes().remove(table)
finally:
    presentation.dispose()
```

## **รวมเซลล์ตาราง**

รวมเซลล์ที่อยู่ติดกันของตารางให้เป็นเซลล์เดียว.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    # รวมเซลล์.
    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), False)
finally:
    presentation.dispose()
```