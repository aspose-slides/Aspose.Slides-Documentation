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
description: "ปลดล็อกการส่งออกสมการคณิตศาสตร์จาก PowerPoint ไปยัง MathML อย่างราบรื่นด้วย Aspose.Slides for C++ — รักษาการจัดรูปแบบและเพิ่มความเข้ากันได้."
---
## **บทนำ**

Aspose.Slides for C++ ช่วยให้คุณสามารถส่งออกสมการคณิตศาสตร์จากงานนำเสนอได้ ตัวอย่างเช่น คุณอาจต้องการดึงสมการคณิตศาสตร์บนสไลด์ (จากงานนำเสนอเฉพาะ) แล้วนำไปใช้ในโปรแกรมหรือแพลตฟอร์มอื่น

{{% alert color="primary" %}} 

คุณสามารถส่งออกสมการเป็น MathML ซึ่งเป็นรูปแบบหรือมาตรฐานที่นิยมสำหรับสมการคณิตศาสตร์และเนื้อหาแบบเดียวกันที่พบบนเว็บและในหลายแอปพลิเคชัน

{{% /alert %}}

## **บันทึกสมการคณิตศาสตร์เป็น MathML**

แม้ว่ามนุษย์จะเขียนโค้ดสำหรับรูปแบบสมการบางอย่างอย่าง LaTeX ได้อย่างง่ายดาย แต่การเขียนโค้ดสำหรับ MathML ยากเพราะมันถูกออกแบบให้สร้างโดยแอปพลิเคชันโดยอัตโนมัติ โปรแกรมต่าง ๆ สามารถอ่านและแยกวิเคราะห์ MathML ได้ง่าย เพราะโค้ดของมันอยู่ในรูปแบบ XML ดังนั้น MathML จึงเป็นรูปแบบการส่งออกและการพิมพ์ที่ใช้กันอย่างแพร่หลายในหลายสาขา

ตัวอย่างโค้ดนี้แสดงวิธีการส่งออกสมการคณิตศาสตร์จากงานนำเสนอเป็น MathML:

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

## **คำถามที่พบบ่อย**

**สิ่งที่ส่งออกเป็น MathML คืออะไร — ย่อหน้าเต็มหรือบล็อกสูตรแยกส่วน?**

คุณสามารถส่งออกทั้งย่อหน้าคณิตศาสตร์ทั้งหมด ([MathParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/mathparagraph/)) หรือบล็อกสูตรแยกส่วน ([MathBlock](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/mathblock/)) ไปเป็น MathML ทั้งสองประเภทมีเมธอดสำหรับเขียนเป็น MathML

**ฉันจะรู้ได้อย่างไรวัตถุในสไลด์เป็นสูตรคณิตศาสตร์ไม่ใช่ข้อความทั่วไปหรือรูปภาพ?**

สูตรอยู่ใน [MathPortion](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/mathportion/) และมี [MathParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/mathparagraph/) ส่วนรูปภาพและข้อความทั่วไปที่ไม่มี [MathParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/mathparagraph/) ไม่สามารถส่งออกเป็นสูตรได้

**MathML ในงานนำเสนอมาจากไหน — เป็นรูปแบบเฉพาะของ PowerPoint หรือเป็นมาตรฐาน?**

การส่งออกใช้มาตรฐาน MathML (XML) Aspose ใช้ Presentation MathML — ส่วนย่อยของมาตรฐานที่ใช้กันอย่างกว้างขวางในแอปพลิเคชันและเว็บ

**การส่งออกสูตรภายในตาราง, SmartArt, กลุ่ม เป็นต้น สนับสนุนหรือไม่?**

สนับสนุน หากวัตถุนั้นมีส่วนข้อความที่มี [MathParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/mathparagraph/) (คือสูตร PowerPoint ของแท้) จะถูกส่งออก หากสูตรฝังเป็นรูปภาพจะไม่ถูกส่งออก

**การส่งออกเป็น MathML ทำให้ไฟล์งานนำเสนอเดิมเปลี่ยนแปลงหรือไม่?**

ไม่ การเขียน MathML เป็นการซีเรียลไลซ์เนื้อหาของสูตรเท่านั้น ไม่ได้แก้ไขไฟล์งานนำเสนอต้นฉบับ