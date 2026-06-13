---
title: ทำอัตโนมัติการแปลภาษาในการนำเสนอด้วย Python
linktitle: การแปลภาษาการนำเสนอ
type: docs
weight: 100
url: /th/python-net/presentation-localization/
keywords:
- เปลี่ยนภาษา
- ตรวจสอบการสะกด
- รหัสภาษา
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "ทำอัตโนมัติการแปลสไลด์ PowerPoint และ OpenDocument ด้วย Python และ Aspose.Slides ด้วยตัวอย่างโค้ดที่เป็นประโยชน์และเคล็ดลับเพื่อการเปิดตัวทั่วโลกที่เร็วขึ้น"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีตั้งค่า `language_id` สำหรับข้อความในงานนำเสนอโดยใช้ Aspose.Slides โดยแสดงวิธีเปิดงานนำเสนอ, เพิ่มรูปร่างที่มีข้อความ, กำหนดตัวระบุภาษาสำหรับส่วนของข้อความ, และบันทึกผลลัพธ์เป็นไฟล์ PPTX

## **เปลี่ยนภาษาสำหรับงานนำเสนอและข้อความของรูปร่าง**
- สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) 
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม AutoShape ประเภท Rectangle ลงในสไลด์
- เพิ่มข้อความบางส่วนลงใน TextFrame
- ตั้งค่า Language Id ให้กับข้อความ
- บันทึกงานนำเสนอเป็นไฟล์ PPTX

การทำงานของขั้นตอนข้างต้นแสดงในตัวอย่างด้านล่าง

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**ID ภาษา ทำให้เกิดการแปลข้อความอัตโนมัติหรือไม่?**

ไม่. [language_id](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/language_id/) ใน Aspose.Slides จะเก็บข้อมูลภาษาสำหรับการตรวจสอบการสะกดและไวยากรณ์, แต่ไม่ได้แปลหรือเปลี่ยนเนื้อหาข้อความ. เป็นเมทาดาทาที่ PowerPoint เข้าใจเพื่อการตรวจสอบ

**ID ภาษา มีผลต่อการทำ hyphenation และการตัดบรรทัดขณะเรนเดอร์หรือไม่?**

ใน Aspose.Slides, [language_id](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/language_id/) ใช้สำหรับการพิสูจน์อักษร. คุณภาพของ hyphenation และการตัดบรรทัดส่วนใหญ่ขึ้นอยู่กับการมีอยู่ของ [proper fonts](/slides/th/python-net/powerpoint-fonts/) และการตั้งค่า layout/line-break สำหรับระบบเขียน. เพื่อให้การแสดงผลถูกต้อง, ให้แน่ใจว่ามีฟอนต์ที่ต้องการ, กำหนด [font substitution rules](/slides/th/python-net/font-substitution/), และ/หรือ [embed fonts](/slides/th/python-net/embedded-font/) เข้าไปในงานนำเสนอ

**ฉันสามารถตั้งค่าภาษาต่าง ๆ ภายในย่อหน้าหนึ่งเดียวได้หรือไม่?**

ได้. [language_id](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/language_id/) จะถูกนำไปใช้ระดับส่วนของข้อความ, ดังนั้นย่อหน้าเดียวจึงสามารถผสมหลายภาษาโดยมีการตั้งค่าการพิสูจน์อักษรที่แตกต่างกันได้