---
title: รับขอบเขตส่วนข้อความจากงานนำเสนอใน Python ผ่าน Java
linktitle: ขอบเขตส่วนข้อความ
type: docs
weight: 47
url: /th/python-java/portion-bounds/
keywords:
- ขอบเขตส่วนข้อความ
- ส่วนข้อความ
- ส่วนของข้อความ
- พิกัดข้อความ
- ตำแหน่งข้อความ
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีดึงขอบเขตส่วนข้อความในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

ส่วนข้อความ (text portion) แทนส่วนย่อยของข้อความเฉพาะภายในย่อหน้าและทำให้คุณสามารถทำงานกับส่วนนั้นแยกจากเนื้อหารอบข้างได้ ใน Aspose.Slides portion สามารถใช้เมื่อคุณต้องการดึงขอบเขตของส่วนข้อความ, ใช้การจัดรูปแบบกับบางส่วนของย่อหน้าเท่านั้น, หรือควบคุมพฤติกรรมข้อความในระดับที่ละเอียดกว่า

บทความนี้แสดงวิธีดึงสี่เหลี่ยมขอบเขตของ portion โดยใช้ [Portion.getRect](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/#getRect) นอกจากนี้ยังแสดงวิธีดึงพิกัดของจุดเริ่มต้นของ portion โดยใช้ [Portion.getCoordinates](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/#getCoordinates) อีกทั้งยังเน้นสถานการณ์ทั่วไปที่เกี่ยวกับ portion เช่น การใส่ไฮเปอร์ลิงก์ให้กับส่วนข้อความเดียว, การทำความเข้าใจว่า การจัดรูปแบบถูกสืบทอดผ่าน portion, paragraph, text frame และ theme อย่างไร, และการจัดการกรณีที่ฟอนต์ที่ระบุไม่มีอยู่

## **รับขอบเขตของส่วนข้อความ**

ใช้ [Portion.getRect](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/#getRect) เพื่อดึงสี่เหลี่ยมขอบเขตของส่วนข้อความ:

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

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            rectangle = portion.getRect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
finally:
    presentation.dispose()
```

## **รับพิกัดของส่วนข้อความ**

ใช้ [Portion.getCoordinates](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/#getCoordinates) เพื่อดึงพิกัดของจุดเริ่มต้นของส่วนข้อความ:

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

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            point = portion.getCoordinates()
            print(f"X = {point.x}; Y = {point.y}")
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใส่ไฮเปอร์ลิงก์ให้กับส่วนหนึ่งของข้อความภายในย่อหน้าเดียวได้หรือไม่?**

ได้ คุณสามารถ [assign a hyperlink](/slides/th/python-java/manage-hyperlinks/) ให้กับ portion เฉพาะ; เฉพาะส่วนนั้นเท่านั้นที่จะคลิกได้ ไม่ใช่ทั้งย่อหน้า

**การสืบทอดสไตล์ทำงานอย่างไร: portion จะครอบคลุมอะไรบ้างและอะไรที่มาจากย่อหน้าหรือเฟรมข้อความ?**

คุณสมบัติระดับ Portion มีลำดับความสำคัญสูงที่สุด หากคุณสมบัติไม่ได้ตั้งค่าใน [Portion](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/) Aspose.Slides จะใช้ค่าจาก [Paragraph](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/) หากไม่ได้ตั้งค่าไว้ที่นั่นเช่นกัน Aspose.Slides จะใช้สไตล์จาก [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) หรือ [theme](https://reference.aspose.com/slides/th/python-java/aspose.slides/theme/)

**ถ้าฟอนต์ที่ระบุสำหรับ portion ไม่มีในเครื่องหรือเซิร์ฟเวอร์เป้าหมายจะเกิดอะไรขึ้น?**

[Font substitution rules](/slides/th/python-java/font-selection-sequence/) จะถูกนำมาใช้ ข้อความอาจทำการไหลใหม่: เมตริกซ์, การแยกคำและความกว้างอาจเปลี่ยนแปลง ซึ่งมีผลต่อการวางตำแหน่งที่แม่นยำ

**ฉันสามารถตั้งค่าความโปร่งใสหรือไล่สีของการเติมข้อความในระดับ portion โดยแยกจากย่อหน้าทั้งหมดได้หรือไม่?**

ได้ สีข้อความ, การเติมและความโปร่งใสในระดับ [Portion](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/) สามารถแตกต่างจากส่วนใกล้เคียงได้