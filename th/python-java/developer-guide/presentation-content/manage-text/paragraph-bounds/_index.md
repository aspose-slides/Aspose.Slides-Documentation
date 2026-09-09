---
title: รับขอบเขตของย่อหน้าจากงานนำเสนอใน Python ผ่าน Java
linktitle: ขอบเขตย่อหน้า
type: docs
weight: 43
url: /th/python-java/paragraph-bounds/
keywords:
- ขอบเขตย่อหน้า
- พิกัดย่อหน้า
- ขนาดย่อหน้า
- กรอบข้อความ
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีดึงขอบเขตย่อหน้าใน Aspose.Slides สำหรับ Python ผ่าน Java เพื่อเพิ่มประสิทธิภาพการจัดตำแหน่งข้อความในงานนำเสนอ PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการรับขอบเขต ขนาด และพิกัดของย่อหน้าใน Aspose.Slides โดยแสดงวิธีดึงสี่เหลี่ยมของย่อหน้าจาก [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) ด้วยการใช้ [Paragraph.getRect](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/#getRect) วิธีการรับพิกัดของย่อหน้าใน Text Frame ของเซลล์ตาราง และเน้นรายละเอียดสำคัญเช่น หน่วยการวัด ผลของการตัดบรรทัดต่อขอบเขต การแปลงเป็นพิกเซล และค่าการจัดรูปแบบย่อหน้าที่มีประสิทธิภาพ

## **รับพิกัดสี่เหลี่ยมของย่อหน้า**

ใช้ [Paragraph.getRect](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/#getRect) เพื่อรับสี่เหลี่ยมที่ล้อมรอบย่อหน้า

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    rectangle = paragraph.getRect()
finally:
    presentation.dispose()
```

## **รับขนาดของย่อหน้าภายใน Text Frame ของเซลล์ตาราง**

เพื่อรับขนาดและพิกัดของ [Paragraph](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/) ใน Text Frame ของเซลล์ตาราง ให้ใช้ [Paragraph.getRect](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/#getRect) สี่เหลี่ยมที่คืนค่ามาจะสัมพันธ์กับ Text Frame ของเซลล์ตาราง ดังนั้นให้เพิ่มตำแหน่งของตารางและการเลื่อนของเซลล์เมื่อคุณต้องการพิกัดระดับสไลด์

ตัวอย่างต่อไปนี้รับขอบเขตของย่อหน้าภายในเซลล์ตารางและวาดสี่เหลี่ยมบนสไลด์เพื่อแสดงขอบเขตเหล่านั้น:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation("source.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)
    cell = table.getRows().get_Item(1).get_Item(1)

    cell_x = table.getX() + cell.getOffsetX()
    cell_y = table.getY() + cell.getOffsetY()

    for paragraph in cell.getTextFrame().getParagraphs():
        if not paragraph.getText():
            continue

        paragraph_rectangle = paragraph.getRect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, paragraph_rectangle_x, paragraph_rectangle_y, paragraph_rectangle.width, paragraph_rectangle.height)

        paragraph_bounds_shape.getFillFormat().setFillType(FillType.NoFill)
        paragraph_bounds_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
        paragraph_bounds_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**หน่วยที่ใช้วัดพิกัดของย่อหน้าคืออะไร?**

พิกัดวัดเป็นจุด (points) โดยที่ 1 นิ้วเท่ากับ 72 จุด ค่าดังกล่าวใช้กับพิกัดและขนาดทั้งหมดบนสไลด์

**การตัดบรรทัดอัตโนมัติมีผลต่อขอบเขตของย่อหน้าหรือไม่?**

มีผล หากเปิดใช้งาน [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#setWrapText) สำหรับ [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) ข้อความจะตัดเพื่อให้พอดีกับความกว้างของพื้นที่ ซึ่งจะเปลี่ยนขอบเขตจริงของย่อหน้า

**พิกัดของย่อหน้าสามารถแปลงเป็นพิกเซลในภาพที่ส่งออกได้อย่างแม่นยำหรือไม่?**

ได้ สามารถแปลงจุดเป็นพิกเซลได้โดยใช้สูตร: pixels = points × (DPI / 72) ผลลัพธ์ขึ้นอยู่กับ DPI ที่เลือกสำหรับการเรนเดอร์หรือการส่งออก

**ฉันจะดึงพารามิเตอร์การจัดรูปแบบย่อหน้า “effective” โดยคำนึงถึงการสืบทอดสไตล์ได้อย่างไร?**

ใช้ [effective paragraph formatting data structure](/slides/th/python-java/shape-effective-properties/) เพื่อรับค่าที่สรุปขั้นสุดท้ายสำหรับการเยื้อง ช่องว่าง การตัดบรรทัด RTL และอื่น ๆ