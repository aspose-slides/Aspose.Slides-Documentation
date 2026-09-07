---
title: กล่องข้อความ
type: docs
weight: 40
url: /th/python-java/examples/elements/text-box/
keywords:
- ตัวอย่างโค้ด
- กล่องข้อความ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ทำงานกับกล่องข้อความใน Aspose.Slides for Python via Java: เพิ่ม, จัดรูปแบบ, ค้นหา, และลบข้อความในงานนำเสนอ PowerPointและ OpenDocument."
---
ใน **Aspose.Slides for Python via Java**, กล่องข้อความเป็นรูปร่างอัตโนมัติที่บรรจุข้อความได้ เกือบทุกรูปร่างสามารถบรรจุข้อความได้ แต่กล่องข้อความทั่วไปจะไม่มีการเติมสีหรือเส้นขอบและจะแสดงเฉพาะข้อความเท่านั้น

คู่มือนี้อธิบายวิธีการเพิ่ม, เข้าถึง, และลบกล่องข้อความโดยโปรแกรม

ติดตั้งแพ็กเกจตามที่อธิบายใน [การติดตั้ง](/slides/th/python-java/installation/). ตัวอย่างแต่ละตัวจะทำการนำเข้า `asposeslides` ก่อนเริ่ม JVM แล้วจึงนำเข้า API หลังจากที่ JVM กำลังทำงาน

## **เพิ่มกล่องข้อความ**

สร้างสี่เหลี่ยมผืนผ้า, ลบการเติมสีและเส้นขอบ, และกำหนดข้อความที่จัดรูปแบบ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # สร้างรูปร่างสี่เหลี่ยมผืนผ้า.
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)

    # ลบการเติมสีและเส้นขอบเพื่อแสดงเฉพาะข้อความ.
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    # กำหนดการจัดรูปแบบข้อความเริ่มต้น.
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    text_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
    text_format.getFillFormat().setFillType(FillType.Solid)
    text_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    text_box.getTextFrame().setText("Some text...")
finally:
    presentation.dispose()
```

## **เข้าถึงกล่องข้อความตามเนื้อหา**

เพิ่มกล่องข้อความตัวอย่าง, จากนั้นค้นหารูปร่างที่ข้อความของมันมีคำสำคัญ "Slide".

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                # ใช้กล่องข้อความที่ตรงกัน.
                print(text_frame.getText())
finally:
    presentation.dispose()
```

## **ลบกล่องข้อความตามเนื้อหา**

ค้นหาและลบกล่องข้อความบนสไลด์แรกที่มีคำสำคัญเฉพาะ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    shapes_to_remove = []
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

{{% alert color="success" title="เคล็ดลับ" %}}
เก็บรวบรวมรูปร่างที่ตรงกันในรายการแยกต่างหากก่อนที่จะลบเพื่อหลีกเลี่ยงการแก้ไขคอลเลกชันของรูปร่างระหว่างการวนซ้ำ.
{{% /alert %}}