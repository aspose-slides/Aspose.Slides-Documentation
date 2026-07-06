---
title: รับขอบเขตของส่วนข้อความจากงานนำเสนอใน Python
linktitle: ขอบเขตของส่วนข้อความ
type: docs
weight: 47
url: /th/python-net/portion-bounds/
keywords:
- ขอบเขตของส่วนข้อความ
- ส่วนข้อความ
- ส่วนของข้อความ
- พิกัดข้อความ
- ตำแหน่งข้อความ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีดึงขอบเขตของส่วนข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **ภาพรวม**

ส่วนข้อความเป็นส่วนย่อยของข้อความที่กำหนดภายในย่อหน้า ซึ่งให้คุณทำงานกับส่วนนั้นได้อย่างอิสระจากเนื้อหาโดยรอบ ใน Aspose.Slides, Portion สามารถใช้เมื่อต้องการดึงขอบเขตของส่วนข้อความ, ใช้การจัดรูปแบบกับเพียงบางส่วนของย่อหน้า, หรือควบคุมพฤติกรรมของข้อความในระดับที่ละเอียดกว่า  

บทความนี้แสดงวิธีการรับสี่เหลี่ยมขอบเขตของ Portion โดยใช้ [Portion.get_rect](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/get_rect/). นอกจากนี้ยังแสดงวิธีการรับพิกัดของจุดเริ่มต้นของ Portion โดยใช้ [Portion.get_coordinates](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/get_coordinates/). นอกจากนี้ยังเน้นสถานการณ์ทั่วไปที่เกี่ยวกับ Portion เช่น การกำหนดไฮเปอร์ลิงก์ให้กับส่วนข้อความเดียว, การเข้าใจว่าการจัดรูปแบบได้รับการแก้ไขผ่าน Portion, Paragraph, TextFrame และการสืบทอดธีมอย่างไร, และการจัดการกรณีที่แบบอักษรที่ระบุไม่มีอยู่

## **รับขอบเขตของส่วนข้อความ**

ใช้ [Portion.get_rect](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/get_rect/) เพื่อรับสี่เหลี่ยมขอบเขตของส่วนข้อความ:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            rectangle = portion.get_rect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
```

## **รับพิกัดของส่วนข้อความ**

ใช้ [Portion.get_coordinates](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/get_coordinates/) เพื่อรับพิกัดของจุดเริ่มต้นของส่วนข้อความ:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print(f"X = {point.x}; Y = {point.y}")
```

## **คำถามที่พบบ่อย**

**ฉันสามารถกำหนดไฮเปอร์ลิงก์ให้กับส่วนหนึ่งของข้อความภายในย่อหน้าเดียวได้หรือไม่?**

ใช่, คุณสามารถ [กำหนดไฮเปอร์ลิงก์](/slides/th/python-net/manage-hyperlinks/) ให้กับ Portion แยกส่วน; เพียงส่วนนั้นเท่านั้นจะเป็นลิงก์คลิกได้, ไม่ใช่ย่อหน้าทั้งหมด.

**การสืบทอดสไตล์ทำงานอย่างไร: Portion จะทำการแทนที่อะไรบ้าง, และอะไรที่ถูกนำมาจาก Paragraph หรือ TextFrame?**

คุณสมบัติระดับ Portion มีลำดับความสำคัญสูงที่สุด หากคุณสมบัติไม่ได้ตั้งค่าใน [Portion](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/), Aspose.Slides จะนำจาก [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/). หากไม่ตั้งค่าในนั้นอีก Aspose.Slides จะใช้สไตล์จาก [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) หรือ [theme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/theme/).

**จะเกิดอะไรขึ้นหากแบบอักษรที่ระบุสำหรับ Portion ไม่พบในเครื่องหรือเซิร์ฟเวอร์เป้าหมาย?**

ใช้ [กฎการแทนที่แบบอักษร](/slides/th/python-net/font-selection-sequence/). ข้อความอาจเปลี่ยนรูปแบบใหม่: เมตริกซ์, การใส่ยัติภังค์, และความกว้างอาจเปลี่ยนแปลง, ซึ่งสำคัญสำหรับการวางตำแหน่งที่แม่นยำ.

**ฉันสามารถตั้งค่าความโปร่งใสหรือไล่สีของการเติมข้อความในระดับ Portion เฉพาะได้โดยอิสระจากส่วนที่เหลือของ Paragraph หรือไม่?**

ได้, สีข้อความ, การเติม, และความโปร่งใสที่ระดับ [Portion](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/) สามารถแตกต่างจากส่วนใกล้เคียงได้.