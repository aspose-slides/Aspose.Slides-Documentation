---
title: ส่งออกสมการคณิตศาสตร์จากงานนำเสนอใน C++
linktitle: ส่งออกสมการ
type: docs
weight: 30
url: /th/cpp/exporting-math-equations/
keywords:
- ส่งออกสมการคณิตศาสตร์
- MathML
- LaTeX
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เปิดใช้งานการส่งออกสมการคณิตศาสตร์จาก PowerPoint ไปยัง MathML ด้วย Aspose.Slides สำหรับ C++ — รักษาการจัดรูปแบบและเพิ่มความเข้ากันได้."
---
## **บทนำ**

Aspose.Slides for C++ ให้คุณส่งออกสมการคณิตศาสตร์จากงานนำเสนอ ตัวอย่างเช่น คุณอาจต้องการดึงสมการคณิตศาสตร์บนสไลด์ (จากงานนำเสนอเฉพาะ) และใช้ในโปรแกรมหรือแพลตฟอร์มอื่น  

{{% alert color="primary" %}} 
คุณสามารถส่งออกสมการเป็น MathML ซึ่งเป็นรูปแบบหรือมาตรฐานที่นิยมสำหรับสมการคณิตศาสตร์และเนื้อหาใกล้เคียงที่พบบนเว็บและในแอปพลิเคชันหลายแห่ง. 
{{% /alert %}}

## **บันทึกสมการคณิตศาสตร์เป็น MathML**

แม้ว่ามนุษย์จะเขียนโค้ดสำหรับรูปแบบสมการบางประเภทอย่าง LaTeX ได้ง่าย แต่การเขียนโค้ดสำหรับ MathML นั้นยากเพราะ MathML ถูกออกแบบให้สร้างโดยแอปพลิเคชันโดยอัตโนมัติ โปรแกรมต่าง ๆ สามารถอ่านและแยกวิเคราะห์ MathML ได้ง่าย เนื่องจากโค้ดของมันอยู่ในรูปแบบ XML ทำให้ MathML ถูกใช้เป็นรูปแบบผลลัพธ์และการพิมพ์อย่างกว้างขวางในหลายสาขา  

ตัวอย่างโค้ดนี้แสดงวิธีส่งออกสมการคณิตศาสตร์จากงานนำเสนอเป็น MathML:  

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 500.0f, 50.0f);
auto mathPortion = System::ExplicitCast<IMathPortion>(autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0));
auto mathParagraph = mathPortion->get_MathParagraph();

mathParagraph->Add(System::MakeObject<MathematicalText>(u"a")
        - >SetSuperscript(u"2")
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")
                - >SetSuperscript(u"2"))
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"c")
                - >SetSuperscript(u"2")));

SharedPtr<Stream> stream = System::MakeObject<FileStream>(u"mathml.xml", FileMode::Create);

mathParagraph->WriteAsMathMl(stream);
```

## **FAQ**

**สิ่งที่ส่งออกเป็น MathML คืออะไร—ย่อหน้าหรือบล็อกสูตรแยกส่วน?**  
คุณสามารถส่งออกได้ทั้งย่อหน้าคณิตศาสตร์ทั้งหมด ([MathParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/mathparagraph/)) หรือบล็อกสูตรแยกส่วน ([MathBlock](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/mathblock/)) ไปเป็น MathML ทั้งสองประเภทมีเมธอดสำหรับเขียนเป็น MathML

**ฉันจะรู้ได้อย่างไรวัตถุบนสไลด์เป็นสูตรคณิตศาสตร์ไม่ใช่ข้อความหรือรูปภาพทั่วไป?**  
สูตรจะอยู่ใน [MathPortion](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/mathportion/) และมี [MathParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/mathparagraph/) รูปภาพและข้อความปกติที่ไม่มี [MathParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/mathparagraph/) จะไม่สามารถส่งออกรูปสูตรได้

**MathML ที่ได้จากงานนำเสนอมาจากที่ไหน—เป็นของ PowerPoint เท่านั้นหรือเป็นมาตรฐาน?**  
การส่งออกมุ่งเป้าไปที่ MathML มาตรฐาน (XML) Aspose ใช้ Presentation MathML ซึ่งเป็นส่วนย่อยของมาตรฐานที่ใช้กันอย่างแพร่หลายทั้งในแอปพลิเคชันและบนเว็บ

**การส่งออกรูปสูตรภายในตาราง, SmartArt, กลุ่ม ฯลฯ รองรับหรือไม่?**  
รองรับ หากวัตถุนั้นมีส่วนข้อความที่มี [MathParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/mathparagraph/) (คือสูตร PowerPoint ของแท้) จะถูกส่งออก หากสูตรถูกฝังเป็นรูปภาพจะไม่ได้รับการส่งออก

**การส่งออกเป็น MathML จะทำให้ไฟล์งานนำเสนอเดิมเปลี่ยนแปลงหรือไม่?**  
ไม่ การเขียน MathML เป็นการสืบเนื่องของเนื้อหาสูตรเท่านั้น ไม่ได้แก้ไขไฟล์งานนำเสนอ.