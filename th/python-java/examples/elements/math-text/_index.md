---
title: ข้อความคณิตศาสตร์
type: docs
weight: 160
url: /th/python-java/examples/elements/math-text/
keywords:
- ตัวอย่างโค้ด
- ข้อความคณิตศาสตร์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "สำรวจตัวอย่างข้อความคณิตศาสตร์ของ Aspose.Slides for Python via Java: สร้างและจัดรูปสมการ, เศษส่วน, เมทริกซ์, และสัญลักษณ์ในงานนำเสนอรูปแบบ PPT, PPTX, และ ODP"
---
บทความนี้แสดงวิธีทำงานกับรูปร่างข้อความคณิตศาสตร์และการจัดรูปสมการโดยใช้ **Aspose.Slides for Python via Java**.

ติดตั้งแพคเกจตามที่อธิบายไว้ใน [Installation](/slides/th/python-java/installation/). ตัวอย่างแต่ละตัวจะนำเข้า `asposeslides` ก่อนเริ่ม JVM แล้วจึงนำเข้า API หลังจาก JVM ทำงานแล้ว.

## **เพิ่มข้อความคณิตศาสตร์**

สร้างรูปร่างคณิตศาสตร์ที่มีส่วนของเศษส่วนและสูตรพีทากอรัส.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มรูปร่างคณิตศาสตร์ลงในสไลด์.
    math_shape = slide.getShapes().addMathShape(0, 0, 720, 150)

    # เข้าถึงย่อหน้าคณิตศาสตร์.
    paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    math_paragraph = text_portion.getMathParagraph()

    # เพิ่มเศษส่วนง่าย: x / y.
    fraction = MathematicalText("x").divide("y")
    math_paragraph.add(MathBlock(fraction))

    # เพิ่มสมการ: c² = a² + b².
    math_block = MathematicalText("c").setSuperscript("2").join("=").join(MathematicalText("a").setSuperscript("2")).join("+").join(MathematicalText("b").setSuperscript("2"))
    math_paragraph.add(math_block)
finally:
    presentation.dispose()
```

## **เข้าถึงข้อความคณิตศาสตร์**

ค้นหารูปร่างที่มีย่อหน้าคณิตศาสตร์บนสไลด์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, MathBlock, MathematicalText, MathPortion, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มรูปร่างคณิตศาสตร์ที่สามารถพบได้ด้านล่าง.
    created_math_shape = slide.getShapes().addMathShape(50, 50, 100, 50)
    created_paragraph = created_math_shape.getTextFrame().getParagraphs().get_Item(0)
    created_portion = created_paragraph.getPortions().get_Item(0)
    created_math_paragraph = created_portion.getMathParagraph()
    created_fraction = MathematicalText("x").divide("y")
    created_math_paragraph.add(MathBlock(created_fraction))

    # ค้นหารูปร่างแรกที่มีย่อหน้าคณิตศาสตร์.
    math_shape = None
    for shape in slide.getShapes():
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None:
                has_math = False
                for paragraph in text_frame.getParagraphs():
                    for portion in paragraph.getPortions():
                        if isinstance(portion, MathPortion):
                            has_math = True
                            break
                    if has_math:
                        break
                if has_math:
                    math_shape = shape
                    break

    if math_shape is not None:
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        text_portion = paragraph.getPortions().get_Item(0)
        math_paragraph = text_portion.getMathParagraph()

        # ตัวอย่าง: สร้างเศษส่วน (ไม่ได้เพิ่มที่นี่).
        fraction = MathematicalText("x").divide("y")

        # ใช้ math_paragraph หรือ fraction ตามที่ต้องการ.
finally:
    presentation.dispose()
```

## **ลบข้อความคณิตศาสตร์**

ลบรูปร่างคณิตศาสตร์ออกจากสไลด์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpide.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(50, 50, 100, 50)

    paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    math_paragraph = text_portion.getMathParagraph()
    fraction = MathematicalText("x").divide("y")
    math_paragraph.add(MathBlock(fraction))

    # ลบรูปร่างคณิตศาสตร์.
    slide.getShapes().remove(math_shape)
finally:
    presentation.dispose()
```

## **จัดรูปแบบข้อความคณิตศาสตร์**

กำหนดคุณสมบัติของแบบอักษรสำหรับส่วนของคณิตศาสตร์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(50, 50, 100, 50)
    paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    math_paragraph = text_portion.getMathParagraph()
    fraction = MathematicalText("x").divide("y")
    math_paragraph.add(MathBlock(fraction))

    text_portion.getPortionFormat().setFontHeight(20)
finally:
    presentation.dispose()
```