---
title: จัดการส่วนของข้อความในงานนำเสนอด้วย Python
linktitle: ส่วนข้อความ
type: docs
weight: 70
url: /th/python-net/portion/
keywords:
- ส่วนข้อความ
- ส่วนของข้อความ
- พิกัดข้อความ
- ตำแหน่งข้อความ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีจัดการส่วนของข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อเพิ่มประสิทธิภาพและการปรับแต่ง."
---
## **บทนำ**

ส่วนของข้อความเป็นส่วนย่อยเฉพาะของข้อความภายในย่อหน้า ซึ่งช่วยให้คุณทำงานกับส่วนนั้นแยกจากเนื้อหาโดยรอบได้ ใน Aspose.Slides สามารถใช้ส่วนของข้อความเมื่อคุณต้องการดึงตำแหน่งของส่วนข้อความ, ใส่การจัดรูปแบบให้กับส่วนหนึ่งของย่อหน้าเท่านั้น, หรือควบคุมพฤติกรรมของข้อความในระดับที่ละเอียดกว่า

## **รับพิกัดของส่วนข้อความ**

เมธอด [get_coordinates](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/get_coordinates/) ถูกเพิ่มลงในคลาส [Portion](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/) ซึ่งทำให้สามารถดึงพิกัดของส่วนของข้อความได้:

```py
import aspose.slides as slides

with slides.Presentation("HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame = shape.text_frame

    for paragraph in text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Corrdinates X =" + str(point.x) + " Corrdinates Y =" + str(point.y))
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใส่ไฮเปอร์ลิงก์ให้กับส่วนของข้อความเพียงบางส่วนในย่อหน้าเดียวได้หรือไม่?**

ได้, คุณสามารถ [assign a hyperlink](/slides/th/python-net/manage-hyperlinks/) ให้กับส่วนของข้อความแต่ละส่วน; เพียงส่วนนั้นเท่านั้นที่จะคลิกได้ ไม่ใช่ทั้งย่อหน้า

**การสืบทอดสไตล์ทำงานอย่างไร: ส่วนของข้อความ Override อะไรบ้างและอะไรที่มาจาก Paragraph/TextFrame?**

คุณสมบัติระดับ Portion มีระดับความสำคัญสูงสุด หากคุณสมบัติไม่ได้ตั้งค่าใน [Portion](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/) ระบบจะดึงค่าจาก [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/); หากยังไม่ได้ตั้งค่าในนั้นอีก ระบบจะใช้จาก [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) หรือสไตล์ของ [theme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/theme/)

**จะเกิดอะไรขึ้นหากฟอนต์ที่ระบุสำหรับ Portion ไม่พบบนเครื่องหรือเซิร์ฟเวอร์เป้าหมาย?**

[Font substitution rules](/slides/th/python-net/font-selection-sequence/) จะถูกนำมาใช้ ข้อความอาจถูกรีฟโลว์: เมตริก, การเว้นวรรคด้วย hyphenation, และความกว้างอาจเปลี่ยนแปลง ซึ่งส่งผลต่อการจัดตำแหน่งที่แม่นยำ

**ฉันสามารถตั้งค่าความโปร่งใสหรือไล่สีของการเติมข้อความที่ระดับ Portion แยกจากย่อหน้าอื่นได้หรือไม่?**

ได้, สีข้อความ, การเติมสี, และความโปร่งใสที่ระดับ [Portion](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/) สามารถแตกต่างจากส่วนใกล้เคียงได้