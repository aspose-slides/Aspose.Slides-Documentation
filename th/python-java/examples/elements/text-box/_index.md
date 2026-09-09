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
description: "ทำงานกับกล่องข้อความใน Aspose.Slides for Python via Java: เพิ่ม, จัดรูปแบบ, ค้นหาและลบข้อความในงานนำเสนอ PowerPoint และ OpenDocument."
---
ใน **Aspose.Slides for Python via Java**, กล่องข้อความคือรูปทรงอัตโนมัติที่บรรจุข้อความได้ รูปทรงเกือบทั้งหมดสามารถบรรจุข้อความได้ แต่กล่องข้อความทั่วไปไม่มีสีพื้นหรือเส้นขอบและจะแสดงเฉพาะข้อความเท่านั้น

คู่มือนี้อธิบายวิธีการเพิ่ม, เข้าถึงและลบกล่องข้อความโดยใช้โปรแกรม

Install the package as described in [Installation](/slides/th/python-java/installation/). Each example imports `asposeslides` before starting the JVM, then imports the API after the JVM is running.

## **Add a Text Box**

สร้างสี่เหลี่ยมผืนผ้า, ลบสีพื้นและเส้นขอบของมัน, และกำหนดข้อความที่จัดรูปแบบ

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

    # สร้างรูปทรงสี่เหลี่ยม.
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)

    # ลบสีเติมและเส้นขอบเพื่อแสดงเฉพาะข้อความ.
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    # ตั้งค่าการจัดรูปแบบข้อความเริ่มต้น.
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    text_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
    text_format.getFillFormat().setFillType(FillType.Solid)
    text_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    text_box.getTextFrame().setText("Some text...")
finally:
    presentation.dispose()
```

## **Access Text Boxes by Content**

เพิ่มกล่องข้อความตัวอย่าง, จากนั้นค้นหารูปทรงที่มีข้อความประกอบด้วยคีย์เวิร์ด "Slide"

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

## **Remove Text Boxes by Content**

ค้นหาและลบกล่องข้อความบนสไลด์แรกที่มีคีย์เวิร์ดเฉพาะ

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

{{% alert color="success" title="Tip" %}}
รวบรวมรูปทรงที่ตรงกันไว้ในรายการแยกต่างหากก่อนทำการลบ เพื่อหลีกเลี่ยงการแก้ไขคอลเลกชันของรูปทรงในระหว่างการวนลูป.
{{% /alert %}}