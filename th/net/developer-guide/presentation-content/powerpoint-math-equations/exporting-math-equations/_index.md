---
title: ส่งออกสมการคณิตศาสตร์จากงานนำเสนอใน .NET
linktitle: ส่งออกสมการ
type: docs
weight: 30
url: /th/net/exporting-math-equations/
keywords:
- ส่งออกสมการคณิตศาสตร์
- ส่งออกสมการเป็น LaTeX
- PowerPoint เป็น LaTeX
- MathML
- LaTeX
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ส่งออกสมการคณิตศาสตร์จากงานนำเสนอ PowerPoint ไปเป็น LaTeX หรือ MathML โดยตรงด้วย Aspose.Slides สำหรับ .NET."
---
## **เบื้องต้น**

Aspose.Slides for .NET ให้คุณส่งออกสมการคณิตศาสตร์จากงานนำเสนอ ตัวอย่างเช่น คุณอาจต้องการดึงสมการคณิตศาสตร์บนสไลด์ (จากงานนำเสนอเฉพาะ) และใช้ในโปรแกรมหรือแพลตฟอร์มอื่น  

{{% alert color="primary" %}} 
คุณสามารถส่งออกสมการโดยตรงเป็น LaTeX หรือ MathML ซึ่งเป็นมาตรฐานยอดนิยมสำหรับเนื้อหาคณิตศาสตร์ที่ใช้บนเว็บและในหลายแอปพลิเคชัน
{{% /alert %}}

## **ส่งออกสมการคณิตศาสตร์เป็น LaTeX**

Aspose.Slides สามารถแปลงสมการคณิตศาสตร์ใน PowerPoint ไปเป็น LaTeX ได้โดยตรง; ไม่จำเป็นต้องใช้ไฟล์ MathML ชั้นกลางหรือเครื่องแปลงภายนอก สมการคณิตศาสตร์ถูกจัดเก็บในกรอบข้อความเป็น [MathPortion](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/mathportion/). ใช้ [MathPortion.MathParagraph](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/mathportion/mathparagraph/) เพื่อรับ [IMathParagraph](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/imathparagraph/), แล้วเรียก [IMathParagraph.ToLatex](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/imathparagraph/tolatex/). วิธีนี้จะคืนค่ารูปแบบ string ที่คุณสามารถบันทึก, แสดง, ส่งไปยังแอปพลิเคชันอื่น หรือประมวลผลต่อได้  

ตัวอย่างต่อไปนี้จะตรวจสอบทุกกรอบข้อความบนแต่ละสไลด์, ค้นหาส่วนคณิตศาสตร์ทั้งหมด, และเขียนแต่ละสมการลงในไฟล์ `.tex` แยกไฟล์:

```csharp
using var presentation = new Presentation("equations.pptx");

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    var slideNumber = slideIndex + 1;
    var equationNumber = 1;
    var textFrames = SlideUtil.GetAllTextBoxes(slide);

    foreach (var textFrame in textFrames)
    {
        foreach (var paragraph in textFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is not MathPortion mathPortion)
                    continue;

                IMathParagraph mathParagraph = mathPortion.MathParagraph;
                var latexPath = $"slide_{slideNumber}_equation_{equationNumber}.tex";

                var latexText = mathParagraph.ToLatex();
                File.WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}
```

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/th/net/aspose.slides.util/slideutil/getalltextboxes/) คืนค่ากรอบข้อความทั้งหมดที่พบบนสไลด์ การตรวจสอบชนิด [MathPortion](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/mathportion/) แยกสมการที่สามารถแก้ไขได้จริงออกจากข้อความและรูปภาพทั่วไป  

เครื่องยนต์ LaTeX และเทมเพลตเอกสารไม่ได้รองรับคำสั่ง, แพคเกจ หรืออักขระ Unicode ทั้งหมดเดียวกัน ทดสอบสตริงที่คืนค่าด้วยเครื่องยนต์ LaTeX ที่แอปพลิเคชันของคุณใช้ หากสัญลักษณ์หรือองค์ประกอบ Office Math ไม่มีการแสดงผลที่เหมาะสมในสภาพแวดล้อมนั้น ให้แทนที่ในสตริงที่คืนค่าด้วยคำสั่งเฉพาะโครงการหรือข้ามสมการและบันทึกปัญหาเพื่อการตรวจสอบต่อไป

## **บันทึกสมการคณิตศาสตร์เป็น MathML**

แม้ว่ามนุษย์จะเขียนโค้ดสำหรับบางรูปแบบสมการอย่าง LaTeX ได้ง่าย แต่การเขียนโค้ดสำหรับ MathML กลับทำได้ยาก เนื่องจาก MathML ถูกออกแบบให้สร้างโดยอัตโนมัติโดยแอปพลิเคชัน โปรแกรมสามารถอ่านและแยกวิเคราะห์ MathML ได้ง่ายเนื่องจากโค้ดอยู่ในรูป XML ดังนั้น MathML จึงถูกใช้เป็นรูปแบบการส่งออกและการพิมพ์อย่างทั่วไปในหลายสาขา  

ตัวอย่างโค้ดนี้แสดงวิธีส่งออกสมการคณิตศาสตร์จากงานนำเสนอเป็น MathML:

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

**อะไรที่ถูกส่งออกเป็น MathML—ย่อหน้าหรือบล็อกสูตรแยกส่วน?**  
คุณสามารถส่งออกทั้งย่อหน้าคณิตศาสตร์ทั้งหมด ([MathParagraph](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/mathparagraph/)) หรือบล็อกสูตรแยกส่วน ([MathBlock](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/mathblock/)) ไปเป็น MathML ทั้งสองประเภทมีเมธอดสำหรับเขียนเป็น MathML  

**ฉันจะบ่งบอกได้อย่างไรวัตถุบนสไลด์เป็นสูตรคณิตศาสตร์ไม่ใช่ข้อความหรือรูปภาพปกติ?**  
สูตรจะอยู่ใน [MathPortion](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/mathportion/) และมี [MathParagraph](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/mathparagraph/). รูปภาพและข้อความทั่วไปที่ไม่มี [MathParagraph](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/mathparagraph/) จะไม่สามารถส่งออกเป็นสูตรได้  

**MathML มาจากไหนในงานนำเสนอ—เป็นของ PowerPoint อย่างเฉพาะหรือเป็นมาตรฐาน?**  
การส่งออกมุ่งเป้าไปยัง MathML มาตรฐาน (XML) Aspose ใช้ Presentation MathML—ส่วนการนำเสนอของมาตรฐาน—ซึ่งได้รับการใช้อย่างกว้างขวางในแอปพลิเคชันและบนเว็บ  

**การส่งออกสูตรภายในตาราง, SmartArt, กลุ่ม ฯลฯ รองรับหรือไม่?**  
ใช่ หากวัตถุเหล่านั้นมีส่วนข้อความที่มี [MathParagraph](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/mathparagraph/) (คือสูตร PowerPoint ของจริง) จะถูกส่งออก หากสูตรฝังเป็นรูปภาพจะไม่ถูกส่งออก  

**การส่งออกเป็น MathML ทำให้ไฟล์งานนำเสนอเดิมเปลี่ยนแปลงหรือไม่?**  
ไม่ การเขียน MathML เป็นการจัดลำดับข้อมูลของสูตรเท่านั้น ไม่ได้แก้ไขไฟล์งานนำเสนอ.