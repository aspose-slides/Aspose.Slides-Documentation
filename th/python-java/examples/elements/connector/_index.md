---
title: คอนเน็กเตอร์
type: docs
weight: 190
url: /th/python-java/examples/elements/connector/
keywords:
- ตัวอย่างโค้ด
- คอนเน็กเตอร์
- เพิ่มคอนเน็กเตอร์
- เข้าถึงคอนเน็กเตอร์
- ลบคอนเน็กเตอร์
- เชื่อมต่อรูปทรงใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่ม, เข้าถึง, ลบ และเชื่อมต่อรูปทรงด้วยคอนเน็กเตอร์โดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java ในการนำเสนอรูปแบบ PPT, PPTX และ ODP."
---
บทความนี้แสดงวิธีการเชื่อมต่อรูปทรงด้วยคอนเน็กเตอร์และเปลี่ยนเป้าหมายของพวกมันโดยใช้ **Aspose.Slides for Python via Java**.

ติดตั้งแพ็กเกจตามที่อธิบายใน [Installation](/slides/th/python-java/installation/). ตัวอย่างแต่ละตัวจะนำเข้า `asposeslides` ก่อนเริ่ม JVM แล้วจึงนำเข้า API หลังจาก JVM ทำงานแล้ว.

## **เพิ่มคอนเน็กเตอร์**

แทรกรูปคอนเน็กเตอร์ระหว่างสองจุดบนสไลด์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)
finally:
    presentation.dispose()
```

## **เข้าถึงคอนเน็กเตอร์**

ดึงรูปคอนเน็กเตอร์ตัวแรกที่เพิ่มลงในสไลด์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Connector, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    # เข้าถึงคอนเน็กเตอร์ตัวแรกบนสไลด์
    connector = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Connector):
            connector = shape
            break
finally:
    presentation.dispose()
```

## **ลบคอนเน็กเตอร์**

ลบคอนเน็กเตอร์จากสไลด์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    slide.getShapes().remove(connector)
finally:
    presentation.dispose()
```

## **เชื่อมต่อรูปทรงใหม่**

แนบคอนเน็กเตอร์กับรูปสองรูปโดยกำหนดเป้าหมายเริ่มต้นและสิ้นสุด.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)
    shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 50, 50)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    connector.setStartShapeConnectedTo(shape1)
    connector.setEndShapeConnectedTo(shape2)
finally:
    presentation.dispose()
```