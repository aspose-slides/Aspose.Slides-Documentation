---
title: วัตถุ OLE
type: docs
weight: 210
url: /th/python-java/examples/elements/ole-object/
keywords:
- ตัวอย่างโค้ด
- วัตถุ OLE
- เพิ่มวัตถุ OLE
- เข้าถึงวัตถุ OLE
- ลบวัตถุ OLE
- อัปเดตวัตถุ OLE
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ใช้ Aspose.Slides for Python via Java เพื่อเพิ่ม, เข้าถึง, ลบ และอัปเดตวัตถุ OLE ในงานนำเสนอ PowerPoint และ OpenDocument"
---
บทความนี้แสดงวิธีการฝังไฟล์เป็นวัตถุ OLE และอัปเดตข้อมูลของมันโดยใช้ **Aspose.Slides for Python via Java**.

ติดตั้งแพคเกจตามที่อธิบายใน [การติดตั้ง](/slides/th/python-java/installation/). ตัวอย่างแต่ละอันนำเข้า `asposeslides` ก่อนเริ่ม JVM, จากนั้นจึงนำเข้า API หลังจาก JVM ทำงานแล้ว.

## **เพิ่มวัตถุ OLE**

ฝังไฟล์ PDF เข้าไปในงานนำเสนอ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.nio.file import Files, Paths
from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Files.readAllBytes(Paths.get("doc.pdf"))
    data_info = OleEmbeddedDataInfo(pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)
finally:
    presentation.dispose()
```

## **เข้าถึงวัตถุ OLE**

ดึงเฟรมวัตถุ OLE แรกบนสไลด์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.nio.file import Files, Paths
from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Files.readAllBytes(Paths.get("doc.pdf"))
    data_info = OleEmbeddedDataInfo(pdf_data, "pdf")
    slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)

    first_ole_frame = None
    for shape in slide.getShapes():
        if isinstance(shape, OleObjectFrame):
            first_ole_frame = shape
            break

    if first_ole_frame is None:
        print("The slide contains no OLE object frames.")
finally:
    presentation.dispose()
```

## **ลบวัตถุ OLE**

ลบวัตถุ OLE ที่ฝังอยู่จากสไลด์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.nio.file import Files, Paths
from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Files.readAllBytes(Paths.get("doc.pdf"))
    data_info = OleEmbeddedDataInfo(pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)

    slide.getShapes().remove(ole_frame)
finally:
    presentation.dispose()
```

## **อัปเดตข้อมูลวัตถุ OLE**

แทนที่ข้อมูลที่ฝังอยู่ในวัตถุ OLE ที่มีอยู่.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.nio.file import Files, Paths
from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Files.readAllBytes(Paths.get("doc.pdf"))
    data_info = OleEmbeddedDataInfo(pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)

    new_data = Files.readAllBytes(Paths.get("Picture.png"))
    new_data_info = OleEmbeddedDataInfo(new_data, "png")
    ole_frame.setEmbeddedData(new_data_info)
finally:
    presentation.dispose()
```