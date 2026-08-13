---
title: ส่งออกสมการคณิตศาสตร์จากงานพรีเซนเทชันใน .NET
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
- งานพรีเซนเทชัน
- .NET
- C#
- Aspose.Slides
description: "ส่งออกสมการคณิตศาสตร์จากงานพรีเซนเทชัน PowerPoint ไปยัง LaTeX หรือ MathML โดยตรงด้วย Aspose.Slides สำหรับ .NET."
---
## **บทนำ**

Aspose.Slides for .NET ช่วยให้คุณสามารถส่งออกสมการคณิตศาสตร์จากงานพรีเซนเทชันได้ ตัวอย่างเช่น คุณอาจต้องการแยกสมการคณิตศาสตร์บนสไลด์ (จากงานพรีเซนเทชันที่ระบุ) และใช้ในโปรแกรมหรือแพลตฟอร์มอื่น 

{{% alert color="info" %}} 
คุณสามารถส่งออกสมการโดยตรงเป็น LaTeX หรือ MathML ซึ่งเป็นมาตรฐานที่นิยมสำหรับเนื้อหาคณิตศาสตร์ที่ใช้บนเว็บและในหลายแอปพลิเคชัน
{{% /alert %}}

## **ส่งออกสมการคณิตศาสตร์เป็น LaTeX**

Aspose.Slides สามารถแปลงสมการคณิตศาสตร์ใน PowerPoint โดยตรงเป็น LaTeX ได้; ไม่จำเป็นต้องใช้ไฟล์ MathML ระหว่างขั้นตอนหรือโปรแกรมแปลงภายนอก สมการคณิตศาสตร์ถูกจัดเก็บในกรอบข้อความเป็น [MathPortion](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/mathportion/). ใช้ [MathPortion.MathParagraph](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/mathportion/mathparagraph/) เพื่อรับ [IMathParagraph](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/imathparagraph/), จากนั้นเรียก [IMathParagraph.ToLatex](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/imathparagraph/tolatex/). วิธีนี้จะคืนสตริงที่คุณสามารถบันทึก, แสดง, ส่งไปยังแอปพลิเคชันอื่น, หรือทำการประมวลผลต่อได้.

ตัวอย่างต่อไปนี้ตรวจสอบทุกกรอบข้อความในทุกสไลด์, ค้นหาส่วนของสมการทั้งหมด, และเขียนแต่ละสมการลงในไฟล์ `.tex` แยกกัน:

```csharp
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Util;

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

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/th/net/aspose.slides.util/slideutil/getalltextboxes/) คืนค่ากรอบข้อความทั้งหมดที่พบในสไลด์. การตรวจสอบประเภท [MathPortion](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/mathportion/) แยกสมการที่สามารถแก้ไขได้จริงออกจากข้อความและรูปภาพทั่วไป.

เครื่องยนต์ LaTeX และเทมเพลตเอกสารไม่ได้สนับสนุนคำสั่ง, แพคเกจ, หรืออักขระ Unicode ทั้งหมดเดียวกัน ทดสอบสตริงที่คืนค่าด้วยเครื่องยนต์ LaTeX ที่แอปพลิเคชันของคุณใช้ หากสัญลักษณ์หรือองค์ประกอบ Office Math ไม่มีการแทนที่ที่เหมาะสมในสภาพแวดล้อมนั้น ให้แทนที่ในสตริงที่คืนค่าด้วยคำสั่งเฉพาะโครงการหรือข้ามสมการนั้นและบันทึกประเด็นเพื่อการตรวจสอบต่อไป

## **บันทึกสมการคณิตศาสตร์เป็น MathML**

แม้ว่ามนุษย์จะเขียนโค้ดสำหรับรูปแบบสมการบางอย่างเช่น LaTeX ได้ง่าย แต่การเขียนโค้ดสำหรับ MathML ยาก เพราะ MathML ถูกออกแบบให้สร้างโดยอัตโนมัติจากแอปพลิเคชัน โปรแกรมสามารถอ่านและแยกวิเคราะห์ MathML ได้ง่ายเนื่องจากโค้ดของมันอยู่ในรูป XML ดังนั้น MathML จึงเป็นรูปแบบการส่งออกและการพิมพ์ที่ใช้กันทั่วไปในหลายสาขา

ตัวอย่างโค้ดนี้แสดงวิธีการส่งออกสมการคณิตศาสตร์จากพรีเซนเทชันเป็น MathML:

```c#
using Aspose.Slides;
using Aspose.Slides.MathText;

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

**สิ่งที่ส่งออกเป็น MathML จริง ๆ คืออะไร — ย่อหน้าหรือบล็อกสูตรแยกแต่ละอัน?**  
คุณสามารถส่งออกได้ทั้งย่อหน้าคณิตศาสตร์ทั้งหมด ([MathParagraph](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/mathparagraph/)) หรือบล็อกสูตรแยกเดี่ยว ([MathBlock](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/mathblock/)) ไปเป็น MathML ทั้งสองประเภทมีเมธอดสำหรับเขียนเป็น MathML

**ฉันจะรู้ได้อย่างไรว่าวัตถุบนสไลด์เป็นสูตรคณิตศาสตร์หรือเป็นข้อความธรรมดาหรือรูปภาพ?**  
สูตรจะอยู่ใน [MathPortion](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/mathportion/) และมี [MathParagraph](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/mathparagraph/). รูปภาพและส่วนข้อความทั่วไปที่ไม่มี [MathParagraph](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/mathparagraph/) ไม่สามารถส่งออกเป็นสูตรได้

**MathML ในพรีเซนเทชันมาจากที่ไหน — เป็นแบบเฉพาะของ PowerPoint หรือเป็นมาตรฐาน?**  
การส่งออกมุ่งเป้าไปที่ MathML มาตรฐาน (XML) Aspose ใช้ Presentation MathML — ส่วนย่อยของมาตรฐานที่ใช้สำหรับการแสดงผล ซึ่งเป็นที่นิยมใช้กันในหลายแอปพลิเคชันและบนเว็บ

**การส่งออกสูตรที่อยู่ในตาราง, SmartArt, กลุ่ม, ฯลฯ รองรับหรือไม่?**  
ใช่ หากวัตถุเหล่านั้นมีส่วนข้อความที่มี [MathParagraph](https://reference.aspose.com/slides/th/net/aspose.slides.mathtext/mathparagraph/) (เช่นสูตร PowerPoint ของจริง) จะถูกส่งออก หากสูตรถูกฝังเป็นรูปภาพ จะไม่ได้รับการส่งออก

**การส่งออกเป็น MathML มีผลต่อการแก้ไขพรีเซนเทชันต้นฉบับหรือไม่?**  
ไม่ การเขียน MathML เป็นการทำให้ข้อมูลสูตรเป็นรูปแบบการจัดเก็บ; ไม่ได้แก้ไขไฟล์พรีเซนเทชัน