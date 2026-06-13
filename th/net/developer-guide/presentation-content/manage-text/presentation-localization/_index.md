---
title: ทำให้การแปลงานนำเสนอใน .NET เป็นอัตโนมัติ
linktitle: การแปลงานนำเสนอ
type: docs
weight: 100
url: /th/net/presentation-localization/
keywords:
- เปลี่ยนภาษา
- ตรวจสอบการสะกด
- รหัสภาษา
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ทำให้การแปลสไลด์ PowerPoint และ OpenDocument ใน .NET เป็นอัตโนมัติด้วย Aspose.Slides โดยใช้ตัวอย่างโค้ด C# ที่เป็นประโยชน์และเคล็ดลับสำหรับการเปิดตัวสู่ระดับโลกที่เร็วขึ้น."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีตั้งค่า `LanguageId` สำหรับข้อความในงานนำเสนอโดยใช้ Aspose.Slides โดยจะแสดงวิธีเปิดงานนำเสนอ, เพิ่มรูปทรงพร้อมข้อความ, กำหนดตัวระบุภาษาให้กับส่วนข้อความ, และบันทึกผลลัพธ์เป็นไฟล์ PPTX

## **เปลี่ยนภาษาสำหรับข้อความในงานนำเสนอและรูปร่าง**
- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม AutoShape ประเภท Rectangle ลงในสไลด์
- เพิ่มข้อความบางส่วนลงใน TextFrame
- ตั้งค่า Language Id ให้กับข้อความ
- บันทึกงานนำเสนอเป็นไฟล์ PPTX

การดำเนินการของขั้นตอนข้างต้นได้แสดงไว้ด้านล่างในตัวอย่าง.

```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

**ตัวระบุภาษา (Language ID) ทำให้เกิดการแปลข้อความอัตโนมัติหรือไม่?**

ไม่. [LanguageId](https://reference.aspose.com/slides/th/net/aspose.slides/baseportionformat/languageid/) ใน Aspose.Slides จะเก็บภาษาสำหรับการตรวจสอบการสะกดและไวยากรณ์, แต่ไม่ได้แปลหรือเปลี่ยนแปลงเนื้อหาของข้อความ. มันเป็นเมตาดาต้าที่ PowerPoint เข้าใจสำหรับการตรวจสอบ.

**ตัวระบุภาษา (Language ID) มีผลต่อการแยกคำด้วย hyphenation และการตัดบรรทัดระหว่างการเรนเดอร์หรือไม่?**

ใน Aspose.Slides, [LanguageId](https://reference.aspose.com/slides/th/net/aspose.slides/baseportionformat/languageid/) ใช้สำหรับการตรวจสอบ. คุณภาพของ hyphenation และการตัดบรรทัดขึ้นอยู่กับการมีอยู่ของ [proper fonts](/slides/th/net/powerpoint-fonts/) และการตั้งค่า layout/line‑break สำหรับระบบการเขียน. เพื่อให้การเรนเดอร์ถูกต้อง, ควรทำให้ฟอนท์ที่ต้องการพร้อมใช้งาน, ตั้งค่า [font substitution rules](/slides/th/net/font-substitution/), และ/หรือ [embed fonts](/slides/th/net/embedded-font/) ลงในงานนำเสนอ.

**ฉันสามารถตั้งค่าภาษาที่ต่างกันภายในย่อหน้าเดียวได้หรือไม่?**

ได้. [LanguageId](https://reference.aspose.com/slides/th/net/aspose.slides/baseportionformat/languageid/) ถูกนำไปใช้ในระดับส่วนของข้อความ, ดังนั้นย่อหน้าเดียวจึงสามารถผสมหลายภาษาโดยมีการตั้งค่าการตรวจสอบที่แตกต่างกัน.