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
## **บทนำ**

Aspose.Slides for C++ ช่วยให้คุณส่งออกสมการคณิตศาสตร์จากงานนำเสนอได้ ตัวอย่างเช่น คุณอาจต้องการดึงสมการคณิตศาสตร์บนสไลด์ (จากงานนำเสนอเฉพาะ) และใช้ในโปรแกรมหรือแพลตฟอร์มอื่น

{{% alert color="info" %}}You can export equations directly to LaTeX or to MathML, a popular standard for mathematical content used on the web and in many applications.{{% /alert %}}

## **ส่งออกสมการคณิตศาสตร์เป็น LaTeX**

Aspose.Slides สามารถแปลงสมการคณิตศาสตร์ใน PowerPoint เป็น LaTeX ได้โดยตรง ไม่จำเป็นต้องใช้ไฟล์ MathML กึ่งกลางหรือเครื่องแปลงภายนอก สมการคณิตศาสตร์จะถูกเก็บในกรอบข้อความเป็น [IMathPortion](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/imathportion/). ใช้ [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) เพื่อรับ [IMathParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/imathparagraph/), แล้วเรียก [IMathParagraph::ToLatex](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/imathparagraph/tolatex/). วิธีนี้จะคืนสตริงที่คุณสามารถบันทึก, แสดง, ส่งให้แอปพลิเคชันอื่น, หรือประมวลผลต่อได้

ตัวอย่างต่อไปนี้ตรวจสอบกรอบข้อความทุกกรอบบนแต่ละสไลด์, ค้นหาส่วนคณิตศาสตร์ทั้งหมด, และเขียนสมการแต่ละอันลงในไฟล์ `.tex` แยกไฟล์:

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

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/th/cpp/aspose.slides.util/slideutil/getalltextboxes/) คืนค่ากรอบข้อความทั้งหมดที่พบบนสไลด์ การตรวจสอบประเภท [IMathPortion](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/imathportion/) แยกสมการที่แก้ไขได้จริงออกจากข้อความและรูปภาพทั่วไป

เครื่องยนต์ LaTeX และเทมเพลตเอกสารไม่ได้รองรับคำสั่ง, แพ็คเกจ หรืออักขระ Unicode เดียวกันทั้งหมด ให้ทดสอบสตริงที่คืนค่าด้วยเครื่องยนต์ LaTeX ที่แอปของคุณใช้ หากสัญลักษณ์หรือองค์ประกอบ Office Math ไม่มีการแทนที่ที่เหมาะสมในสภาพแวดล้อมนั้น ให้แทนที่ในสตริงที่คืนค่าด้วยคำสั่งเฉพาะโครงการหรือข้ามสมการนั้นและบันทึกปัญหาสำหรับการตรวจสอบภายหลัง

## **บันทึกสมการคณิตศาสตร์เป็น MathML**

แม้ว่ามนุษย์จะเขียนโค้ดสำหรับรูปแบบสมการบางอย่างอย่าง LaTeX ได้ง่าย แต่การเขียนโค้ดสำหรับ MathML นั้นยากเพราะ MathML ถูกออกแบบให้สร้างโดยแอปพลิเคชันโดยอัตโนมัติ โปรแกรมสามารถอ่านและแยกวิเคราะห์ MathML ได้ง่าย เนื่องจากโค้ดของมันอยู่ในรูป XML ดังนั้น MathML จึงเป็นรูปแบบการส่งออกและพิมพ์ที่นิยมใช้ในหลายสาขา

ตัวอย่างโค้ดนี้แสดงวิธีส่งออกสมการคณิตศาสตร์จากงานนำเสนอเป็น MathML:

``` cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathBlock.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/IMathPortion.h>
#include <DOM/MathText/IMathSuperscriptElement.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::MathText;
using namespace System;
using namespace System::IO;

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

**จริง ๆ แล้วอะไรถูกส่งออกเป็น MathML — ย่อหน้าทั้งหมดหรือบล็อกสูตรแยกส่วน?**

คุณสามารถส่งออกทั้งย่อหน้าคณิตศาสตร์ทั้งหมด ([MathParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/mathparagraph/)) หรือบล็อกสูตรแยกส่วน ([MathBlock](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/mathblock/)) ไปยัง MathML ได้ ทั้งสองประเภทมีวิธีเขียนเป็น MathML

**ฉันจะบอกได้อย่างไรว่าวัตถุบนสไลด์เป็นสูตรคณิตศาสตร์ ไม่ใช่ข้อความหรือรูปภาพทั่วไป?**

สูตรจะอยู่ใน [MathPortion](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/mathportion/) และมี [MathParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/mathparagraph/). รูปภาพและข้อความปกติที่ไม่มี [MathParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/mathparagraph/) จะไม่สามารถส่งออกเป็นสูตรได้

**MathML ในงานนำเสนอมาจากไหน — เป็นของ PowerPoint เองหรือเป็นมาตรฐาน?**

การส่งออกมุ่งเป้าไปที่ MathML มาตรฐาน (XML) Aspose ใช้ Presentation MathML — ส่วนย่อยของมาตรฐานที่ใช้สำหรับการนำเสนอ ซึ่งเป็นที่ยอมรับอย่างกว้างขวางในแอปพลิเคชันและบนเว็บ

**การส่งออกสูตรที่อยู่ในตาราง, SmartArt, กลุ่ม ฯลฯ รองรับหรือไม่?**

รองรับ หากวัตถุนั้นมีส่วนข้อความที่มี [MathParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides.mathtext/mathparagraph/) (คือสูตร PowerPoint จริง) จะถูกส่งออก หากสูตรฝังเป็นรูปภาพ จะไม่ถูกส่งออก

**การส่งออกเป็น MathML ทำให้ไฟล์งานนำเสนอเดิมเปลี่ยนแปลงหรือไม่?**

ไม่ การเขียน MathML เป็นการทำซีเรียลไลซ์ของเนื้อหาสูตรเท่านั้น ไม่ได้แก้ไขไฟล์งานนำเสนอเดิม