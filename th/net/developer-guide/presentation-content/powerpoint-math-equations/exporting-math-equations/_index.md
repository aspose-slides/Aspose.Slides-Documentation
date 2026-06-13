---
title: ส่งออกสมการคณิตศาสตร์จากการนำเสนอใน .NET
linktitle: ส่งออกสูตรคณิตศาสตร์
type: docs
weight: 30
url: /th/net/exporting-math-equations/
keywords:
- ส่งออกสมการคณิตศาสตร์
- MathML
- LaTeX
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เปิดใช้งานการส่งออกสมการคณิตศาสตร์จาก PowerPoint ไปยัง MathML อย่างราบรื่นด้วย Aspose.Slides สำหรับ .NET—รักษาการจัดรูปแบบและเพิ่มความเข้ากันได้"
---
## **บทนำ**

Aspose.Slides for .NET ช่วยให้คุณสามารถส่งออกสมการคณิตศาสตร์จากการนำเสนอได้ ตัวอย่างเช่น คุณอาจต้องการสกัดสมการคณิตศาสตร์บนสไลด์ (จากการนำเสนอเฉพาะ) และใช้ในโปรแกรมหรือแพลตฟอร์มอื่น

{{% alert color="primary" %}} 
คุณสามารถส่งออกสมการเป็น MathML ซึ่งเป็นรูปแบบหรือมาตรฐานที่นิยมสำหรับสมการคณิตศาสตร์และเนื้อหาแบบเดียวกันที่พบบนเว็บและในหลายแอปพลิเคชัน
{{% /alert %}}

## **บันทึกสมการคณิตศาสตร์เป็น MathML**

แม้ว่ามนุษย์จะเขียนโค้ดสำหรับรูปแบบสมการบางอย่างอย่าง LaTeX ได้ง่าย แต่ก็พบว่าการเขียนโค้ดสำหรับ MathML ยากเนื่องจาก MathML ถูกออกแบบให้สร้างโดยแอปพลิเคชันโดยอัตโนมัติ โปรแกรมสามารถอ่านและแยกวิเคราะห์ MathML ได้ง่ายเนื่องจากโค้ดของมันเป็น XML ดังนั้น MathML จึงถูกใช้เป็นรูปแบบการส่งออกและการพิมพ์ในหลายสาขา

โค้ดตัวอย่างนี้แสดงวิธีส่งออกสมการคณิตศาสตร์จากการนำเสนอเป็น MathML:

```c#
using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```

## **คำถามที่พบบ่อย**

**จริง ๆ แล้วอะไรถูกส่งออกเป็น MathML—ย่อหน้าหรือบล็อกสูตรแยกส่วน?**

คุณสามารถส่งออกได้ทั้งย่อหน้าคณิตศาสตร์ทั้งหมด ([MathParagraph](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/mathparagraph/)) หรือบล็อกสูตรแยกส่วน ([MathBlock](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/mathblock/)) ไปเป็น MathML ทั้งสองประเภทมีเมธอดสำหรับเขียนเป็น MathML

**ฉันจะทราบได้อย่างไรว่าวัตถุบนสไลด์เป็นสูตรคณิตศาสตร์หรือเป็นข้อความหรือรูปภาพทั่วไป?**

สูตรอยู่ใน [MathPortion](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/mathportion/) และมี [MathParagraph](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/mathparagraph/) รูปภาพและข้อความทั่วไปที่ไม่มี [MathParagraph](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/mathparagraph/) ไม่สามารถส่งออกเป็นสูตรได้

**MathML มาจากไหนในการนำเสนอ—เป็นของ PowerPoint เท่านั้นหรือเป็นมาตรฐาน?**

การส่งออกมุ่งเป้าไปที่ MathML มาตรฐาน (XML) Aspose ใช้ Presentation MathML — ส่วนย่อยของมาตรฐานสำหรับการนำเสนอ — ซึ่งได้รับการใช้กันอย่างกว้างข้างในแอปพลิเคชันและบนเว็บ

**การส่งออกสูตรที่อยู่ในตาราง, SmartArt, กลุ่ม ฯลฯ รองรับหรือไม่?**

ใช่ หากวัตถุนั้นมีส่วนข้อความที่มี [MathParagraph](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/mathparagraph/) (เช่นสูตร PowerPoint ของจริง) จะถูกส่งออก หากสูตรฝังเป็นรูปภาพ จะไม่ถูกส่งออก

**การส่งออกเป็น MathML มีผลต่อการนำเสนอเดิมหรือไม่?**

ไม่ การเขียน MathML เป็นการทำซีเรียลไลเซชันของเนื้อหาสูตรเท่านั้น ไม่ได้แก้ไขไฟล์การนำเสนอ