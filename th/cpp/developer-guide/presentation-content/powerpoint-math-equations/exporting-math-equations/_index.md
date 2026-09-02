---
title: ส่งออกสมการคณิตศาสตร์จากงานนำเสนอใน C++
linktitle: ส่งออกสมการ
type: docs
weight: 30
url: /th/cpp/exporting-math-equations/
keywords:
- ส่งออกสมการคณิตศาสตร์
- ส่งออกสมการเป็น LaTeX
- PowerPoint ไปยัง LaTeX
- MathML
- LaTeX
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ส่งออกสมการคณิตศาสตร์จากงานนำเสนอ PowerPoint ไปยัง LaTeX หรือ MathML โดยตรงด้วย Aspose.Slides สำหรับ C++."
---
## **คำนำ**

Aspose.Slides สำหรับ C++ ให้คุณส่งออกรูปสมการคณิตศาสตร์จากงานนำเสนอ ตัวอย่างเช่น คุณอาจต้องการดึงสมการคณิตศาสตร์บนสไลด์ (จากงานนำเสนอเฉพาะ) และใช้ในโปรแกรมหรือแพลตฟอร์มอื่น  

{{% alert color="primary" %}} 
คุณสามารถส่งออกสมการโดยตรงเป็น LaTeX หรือ MathML ซึ่งเป็นมาตรฐานที่ได้รับความนิยมสำหรับเนื้อหาคณิตศาสตร์ที่ใช้บนเว็บและในแอปพลิเคชันหลายประเภท
{{% /alert %}}

## **ส่งออกสมการคณิตศาสตร์เป็น LaTeX**

Aspose.Slides สามารถแปลงสมการคณิตศาสตร์ของ PowerPoint เป็น LaTeX ได้โดยตรง ไม่จำเป็นต้องใช้ไฟล์ MathML ระหว่างขั้นตอนหรือโปรแกรมแปลงภายนอก สมการคณิตศาสตร์จะถูกเก็บไว้ในกรอบข้อความเป็น [IMathPortion](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/imathportion/). ใช้ [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) เพื่อรับ [IMathParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/imathparagraph/), แล้วเรียก [IMathParagraph::ToLatex](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/imathparagraph/tolatex/). วิธีนี้จะคืนค่ารูปแบบสตริงที่คุณสามารถบันทึก แสดง ส่งไปยังแอปพลิเคชันอื่น หรือประมวลผลต่อได้  

ตัวอย่างต่อไปนี้จะตรวจสอบทุกกรอบข้อความในทุกสไลด์ ค้นหาส่วนคณิตศาสตร์ทั้งหมด และเขียนสมการแต่ละอันลงในไฟล์ `.tex` แยกส่วน:  

```cpp
auto presentation = MakeObject<Presentation>(u"equations.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    int slideNumber = slideIndex + 1;
    int equationNumber = 1;
    auto textFrames = SlideUtil::GetAllTextBoxes(slide);

    for (const auto&& textFrame : textFrames)
    {
        for (const auto&& paragraph : textFrame->get_Paragraphs())
        {
            for (const auto&& portion : paragraph->get_Portions())
            {
                auto mathPortion = System::AsCast<IMathPortion>(portion);
                if (mathPortion == nullptr)
                    continue;

                auto mathParagraph = mathPortion->get_MathParagraph();
                auto latexPath = String::Format(u"slide_{0}_equation_{1}.tex", slideNumber, equationNumber);

                auto latexText = mathParagraph->ToLatex();
                File::WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}

presentation->Dispose();
```

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/th/cpp/aspose.slides.util/slideutil/getalltextboxes/) คืนค่ากรอบข้อความทั้งหมดที่พบในสไลด์ การตรวจสอบประเภทของ [IMathPortion](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/imathportion/) แยกสมการที่แก้ไขได้จริงออกจากข้อความและรูปภาพทั่วไป  

เครื่องยนต์ LaTeX และเทมเพลตเอกสารไม่ได้สนับสนุนคำสั่ง แพ็กเกจ หรืออักขระ Unicode เดียวกันทั้งหมด ให้ทดสอบสตริงที่ได้กับเครื่องยนต์ LaTeX ที่แอปพลิเคชันของคุณใช้ หากสัญลักษณ์หรือองค์ประกอบ Office Math ไม่มีการแสดงผลที่เหมาะสมในสภาพแวดล้อมนั้น ให้แทนที่ในสตริงที่ได้ด้วยคำสั่งเฉพาะโครงการหรือข้ามสมการและบันทึกประเด็นเพื่อตรวจสอบ  

## **บันทึกสมการคณิตศาสตร์เป็น MathML**

แม้ว่ามนุษย์จะเขียนโค้ดสำหรับรูปแบบสมการบางประเภทอย่าง LaTeX ได้อย่างง่ายดาย แต่การเขียนโค้ดสำหรับ MathML นั้นยากเนื่องจาก MathML ถูกออกแบบให้สร้างโดยแอปพลิเคชันโดยอัตโนมัติ โปรแกรมสามารถอ่านและแยกวิเคราะห์ MathML ได้อย่างง่ายดายเพราะโค้ดของมันอยู่ในรูปแบบ XML ดังนั้น MathML จึงถูกใช้ทั่วไปเป็นรูปแบบผลลัพธ์และการพิมพ์ในหลายสาขา  

โค้ดตัวอย่างนี้แสดงวิธีส่งออกรสมการคณิตศาสตร์จากงานนำเสนอเป็น MathML:  

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

**สิ่งที่ส่งออกเป็น MathML คืออะไร—ย่อหน้าหรือบล็อกสูตรแยกส่วน?**  
คุณสามารถส่งออกได้ทั้งย่อหน้าคณิตศาสตร์ทั้งหมด ([MathParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/mathparagraph/)) หรือบล็อกสูตรแยกส่วน ([MathBlock](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/mathblock/)) เป็น MathML ทั้งสองประเภทมีเมธอดสำหรับเขียนเป็น MathML  

**ฉันจะรู้ได้อย่างไรวัตถุในสไลด์เป็นสูตรคณิตศาสตร์ ไม่ใช่ข้อความทั่วไปหรือรูปภาพ?**  
สูตรคณิตศาสตร์อยู่ใน [MathPortion](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/mathportion/) และมี [MathParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/mathparagraph/) รูปภาพและส่วนข้อความทั่วไปที่ไม่มี [MathParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/mathparagraph/) ไม่สามารถส่งออกเป็นสูตรได้  

**MathML ที่ได้จากงานนำเสนอ มาจากที่ไหน—เป็นเฉพาะของ PowerPoint หรือเป็นมาตรฐาน?**  
การส่งออกมุ่งเป้าไปยัง MathML มาตรฐาน (XML) Aspose ใช้ Presentation MathML ซึ่งเป็นส่วนย่อยของมาตรฐานที่ใช้กันอย่างแพร่หลายในแอปพลิเคชันและเว็บ  

**การส่งออกรูปสูตรภายในตาราง, SmartArt, กลุ่ม ฯลฯ รองรับหรือไม่?**  
ใช่ หากวัตถุนั้นมีส่วนข้อความที่มี [MathParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/mathparagraph/) (เช่นสูตร PowerPoint จริง) จะถูกส่งออก หากสูตรถูกฝังเป็นรูปภาพ จะไม่ถูกส่งออก  

**การส่งออกเป็น MathML ทำให้งานนำเสนอเดิมเปลี่ยนแปลงหรือไม่?**  
ไม่ การเขียน MathML เป็นการทำซีรีไลซ์ของเนื้อหาสูตรเท่านั้น ไม่ทำให้ไฟล์งานนำเสนอเปลี่ยนแปลง