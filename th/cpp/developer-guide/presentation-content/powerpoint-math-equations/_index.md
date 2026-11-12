---
title: เพิ่มสมการคณิตศาสตร์ไปยังการนำเสนอ PowerPoint ด้วย C++
linktitle: สมการคณิตศาสตร์ PowerPoint
type: docs
weight: 80
url: /th/cpp/powerpoint-math-equations/
keywords:
- สมการคณิตศาสตร์
- สัญลักษณ์คณิตศาสตร์
- สูตรคณิตศาสตร์
- ข้อความคณิตศาสตร์
- เพิ่มสมการคณิตศาสตร์
- เพิ่มสัญลักษณ์คณิตศาสตร์
- เพิ่มสูตรคณิตศาสตร์
- เพิ่มข้อความคณิตศาสตร์
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "แทรกและแก้ไขสมการคณิตศาสตร์ใน PowerPoint PPT และ PPTX ด้วย Aspose.Slides สำหรับ C++ รองรับ OMML, การควบคุมการจัดรูปแบบ, และตัวอย่างโค้ด C++ ที่ชัดเจน."
---
## **ภาพรวม**

PowerPoint จัดเก็บสมการเป็น Office Math Markup Language (OMML). ด้วย Aspose.Slides for C++ คุณสามารถสร้างเนื้อหาคณิตศาสตร์ประเภทเดียวกันได้ด้วยโปรแกรม: เศษส่วน, ราก, ฟังก์ชัน, ขอบเขต, ตัวดำเนินการ N-ary, เมทริกซ์, อาเรย์, และบล็อกคณิตศาสตร์ที่จัดรูปแบบ

ใน PowerPoint ผู้ใช้มักเพิ่มสมการจาก **Insert > Equation**:

![แท็บ Insert ของ PowerPoint ที่เลือกคำสั่ง Equation](powerpoint-math-equations_1.png)

ผลลัพธ์คือข้อความคณิตศาสตร์ที่แก้ไขได้บนสไลด์:

![สไลด์ PowerPoint ที่มีสมการคณิตศาสตร์แก้ไขได้](powerpoint-math-equations_2.png)

Aspose.Slides สร้างข้อความคณิตศาสตร์นั้นผ่านวัตถุหลักสามชนิด:

- รูปร่างคณิตศาสตร์ที่สร้างด้วย [AddMathShape](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/), เป็นรูปร่างที่บรรจุสมการ
- [MathPortion](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) เก็บเนื้อหาคณิตศาสตร์ไว้ในกรอบข้อความของรูปร่าง
- [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) มีหนึ่งหรือหลายวัตถุ [MathBlock](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/)

ตัวอย่างส่วนใหญ่ด้านล่างใช้ [MathematicalText](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/) และเมธอดสไตล์ fluent จาก [IMathElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/) เพื่อทำให้โค้ดสั้นและอ่านง่าย

สำหรับสถานการณ์การส่งออก MathML ดู [ส่งออกสมการคณิตศาสตร์จากการนำเสนอใน C++](/slides/th/cpp/exporting-math-equations/)

## **สร้างสมการ**

ตัวอย่างนี้ใช้ [AddMathShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addmathshape/) เพื่อสร้างรูปร่างคณิตศาสตร์และเพิ่มทฤษฎีพีทากอรัส:

![สมการ c ยกกำลังสองเท่ากับ a ยกกำลังสองบวก b ยกกำลังสอง](powerpoint-math-equations_3.png)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathBlock.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/IMathSuperscriptElement.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto equation = System::MakeObject<MathematicalText>(u"c")
        - >SetSuperscript(u"2")
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));

mathParagraph->Add(equation);

presentation->Save(u"pythagorean-theorem.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
[AddMathShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addmathshape/) สร้างรูปร่างที่มี MathParagraph อยู่แล้ว เข้าถึง [MathPortion](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) ตัวแรก, เรียก [get_MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/get_mathparagraph/), และเพิ่ม MathBlock หรือ MathElement ไปยังมัน
{{% /alert %}}

## **เพิ่มเศษส่วน**

ใช้ [Divide](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/) เพื่อสร้างเศษส่วน คุณสามารถเลือกสไตล์ของเศษส่วนด้วย [MathFractionTypes](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfractiontypes/) 

![เศษส่วนคณิตศาสตร์เอียงที่แสดงหนึ่งหารด้วย x](powerpoint-math-equations_4.png)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathFractionTypes.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto fraction = System::MakeObject<MathematicalText>(u"1")
        - >Divide(u"x", MathFractionTypes::Skewed);

mathParagraph->Add(System::MakeObject<MathBlock>(fraction));

presentation->Save(u"fraction.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

สำหรับเศษส่วนแบบซ้อนกัน ใช้ [MathFractionTypes::Bar](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfractiontypes/):

```cpp
#include <DOM/MathText/MathFractionTypes.h>
#include <DOM/MathText/MathematicalText.h>
using namespace Aspose::Slides::MathText;

auto stackedFraction = System::MakeObject<MathematicalText>(u"x + 1")->Divide(u"y - 1", MathFractionTypes::Bar);
```

## **เพิ่มราก**

ใช้ [Radical](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/radical/) เพื่อสร้างรากที่สอง, รากที่สาม หรือรากอื่น ๆ ส่วนประกอบปัจจุบันจะกลายเป็นฐานและอาร์กิวเมนต์จะเป็นดีกรี

![นิพจน์รากที่ n ที่มี x อยู่ใต้สัญลักษณ์ราก](powerpoint-math-equations_5.png)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto radical = System::MakeObject<MathematicalText>(u"x")
        - >Radical(u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(radical));

presentation->Save(u"radical.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **เพิ่มฟังก์ชันและขีดจำกัด**

ใช้ [AsArgumentOfFunction](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/) หรือ [Function](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/function/) สำหรับฟังก์ชันเช่น `sin(x)`, `log(x)`, หรือชื่อฟังก์ชันที่กำหนดเอง สำหรับขีดจำกัดให้ใส่ `lim` ใน [MathLimit](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathlimit/) หรือใช้ [SetLowerLimit](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/)

![ขีดจำกัดของ x เมื่อ x ใกล้ค่าอนันต์](powerpoint-math-equations_8.png)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathLimit.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto limit = System::MakeObject<MathematicalText>(u"lim")
        - >SetLowerLimit(u"x→∞")
        - >Function(u"x");

mathParagraph->Add(System::MakeObject<MathBlock>(limit));

presentation->Save(u"functions-and-limits.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

สำหรับชื่อฟังก์ชันที่กำหนดเอง ให้ตั้งชื่อฟังก์ชันเป็นส่วนประกอบปัจจุบันและเรียก [Function](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/function/) พร้อมอาร์กิวเมนต์ของมัน:

```cpp
#include <DOM/MathText/MathematicalText.h>
using namespace Aspose::Slides::MathText;

auto customFunction = System::MakeObject<MathematicalText>(u"f")->Function(u"x + 1");
```

## **เพิ่มตัวดำเนินการ N-ary และอินทิกรัล**

ใช้ [Nary](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/nary/) สำหรับผลบวก, ยูเนียน, อินเตอร์เซคชันและตัวดำเนินการขนาดใหญ่อื่น ๆ ใช้ [Integral](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/) สำหรับอินทิกรัล ทั้งสองเมธอดให้คุณกำหนดขีดจำกัดล่างและบน

![ผลบวกที่มีขีดจำกัดล่างและบน](powerpoint-math-equations_7.png)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/IMathSuperscriptElement.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathNaryOperatorTypes.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto summationBase = System::MakeObject<MathematicalText>(u"x")
        - >SetSuperscript(u"k")
        - >Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"n-k"));

auto summation = summationBase->Nary(MathNaryOperatorTypes::Summation, u"k=0", u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(summation));

presentation->Save(u"nary-operators.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ตัวดำเนินการ N-ary ใช้สำหรับตัวดำเนินการขนาดใหญ่ที่มีขีดจำกัดเป็นตัวเลือก ตัวดำเนินการง่ายเช่น `+`, `-`, และ `=` มักเพิ่มเป็น [MathematicalText](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/) แล้วรวมเข้าไปในนิพจน์

สำหรับอินทิกรัล ให้ใช้ [Integral](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/):

```cpp
#include <DOM/MathText/IMathBlock.h>
#include <DOM/MathText/IMathBox.h>
#include <DOM/MathText/IMathElement.h>
#include <DOM/MathText/MathIntegralTypes.h>
#include <DOM/MathText/MathematicalText.h>

using namespace Aspose::Slides::MathText;

auto integralBase = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = integralBase->Integral(MathIntegralTypes::Simple, u"0", u"1");
```

## **เพิ่มเมทริกซ์**

ใช้ [MathMatrix](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathmatrix/) สำหรับแถวและคอลัมน์ เมทริกซ์โดยปกติไม่มีวงเล็บ จึงต้องล้อมรอบเมทริกซ์เมื่อต้องการวงเล็บ, โค้งเหลี่ยม หรือวงเกลียว

![เมทริกซ์คณิตศาสตร์สองแถวที่มีเซลล์ว่างหนึ่งเซลล์](powerpoint-math-equations_10.png)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathBlock.h>
#include <DOM/MathText/IMathElement.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathMatrix.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto matrix = System::MakeObject<MathMatrix>(2, 3);
matrix->idx_set(0, 0, System::MakeObject<MathematicalText>(u"1"));
matrix->idx_set(0, 1, System::MakeObject<MathematicalText>(u"x"));
matrix->idx_set(1, 0, System::MakeObject<MathematicalText>(u"x"));
matrix->idx_set(1, 1, System::MakeObject<MathematicalText>(u"2"));
matrix->idx_set(1, 2, System::MakeObject<MathematicalText>(u"y"));

mathParagraph->Add(System::MakeObject<MathBlock>(matrix));

presentation->Save(u"matrix.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **เพิ่มอาเรย์สมการ**

ใช้ [ToMathArray](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/tomatharray/) เมื่อคุณต้องการสมการที่จัดแนวหรืออาเรย์แนวตั้งของนิพจน์

![อาเรย์คณิตศาสตร์แนวตั้งที่มี x เหนือ y](powerpoint-math-equations_11.png)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 140.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto equationArray = System::MakeObject<MathematicalText>(u"x")
        - >Join(u"y")
        - >ToMathArray();

mathParagraph->Add(System::MakeObject<MathBlock>(equationArray));

presentation->Save(u"equation-array.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **จัดแนวอาเรย์กับองค์ประกอบโดยรอบ**

[IMathArray::set_BaseJustification](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imatharray/set_basejustification/) ควบคุมการจัดแนวแนวตั้งของอาเรย์เทียบกับองค์ประกอบคณิตศาสตร์ด้านข้าง ตัวอย่างด้านล่างเปรียบเทียบการจัดแนวกับแถวแรก, ศูนย์กลางของอาเรย์, และแถวสุดท้าย

ตัวอย่างต่อไปนี้สร้างอาเรย์ที่เหมือนกันสามชุด แต่ละชุดมีสามแถวและองค์ประกอบเพื่อนบ้าน `A=` และ `=B` ข้อความคณิตศาสตร์ทั้งหมดใช้ Cambria Math ขนาด 24 จุด มีเพียงการจัดแนวอาเรย์ที่เปลี่ยน

```cpp
#include <system/array.h>
#include <system/console.h>
#include <drawing/color.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathArray.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathJustification.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathVerticalAlignment.h>
#include <DOM/MathText/MathRowSpacingRule.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/ISlideSize.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/TextAnchorType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

auto createText = [](System::String value)
{
    auto text = System::MakeObject<MathematicalText>(value);
    text->get_Format()->set_FontHeight(24);
    auto font = System::MakeObject<FontData>(u"Cambria Math");
    text->get_Format()->set_LatinFont(font);
    return text;
};

auto presentation = System::MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(780, 200, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

MathVerticalAlignment alignments[] = {MathVerticalAlignment::Top, MathVerticalAlignment::Center, MathVerticalAlignment::Bottom};
System::String labels[] = {u"Top", u"Center", u"Bottom"};

for (auto i = 0; i < 3; i++)
{
    auto label = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20 + i * 260, 10, 240, 30);
    label->get_FillFormat()->set_FillType(FillType::NoFill);
    label->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
    label->get_TextFrame()->set_Text(labels[i]);
    auto labelFormat = label->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
    labelFormat->set_FontHeight(16);
    labelFormat->get_FillFormat()->set_FillType(FillType::Solid);
    labelFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    auto mathShape = slide->get_Shapes()->AddMathShape(20 + i * 260, 60, 240, 130);
    mathShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Top);
    auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
    auto mathParagraph = mathPortion->get_MathParagraph();
    mathParagraph->set_Justification(MathJustification::LeftJustified);

    auto rows = System::MakeArray<System::SharedPtr<IMathElement>>({createText(u"x+y=3"), createText(u"x-y=1"), createText(u"x=2")});
    auto equationArray = System::MakeObject<MathArray>(rows);
    equationArray->set_BaseJustification(alignments[i]);
    auto leftText = createText(u"A=");
    auto rightText = createText(u"=B");
    auto equation = System::MakeObject<MathBlock>(leftText)->Join(equationArray)->Join(rightText);
    mathParagraph->Add(equation);
}

presentation->Save(u"equation-array-alignment.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

การเปรียบเทียบต่อไปนี้แสดงการนำเสนอที่บันทึกใน PowerPoint ให้สังเกตตำแหน่งของ `A=` และ `=B` ข้างแต่ละอาเรย์

![อาเรย์สมการใน PowerPoint ที่มีการจัดตำแหน่งบน, กลาง, และล่าง พร้อมองค์ประกอบข้างเคียงที่เหมือนกัน](equation-array-alignment.png)

### **กำหนดค่าการเว้นระยะแถว**

[set_RowSpacingRule](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imatharray/set_rowspacingrule/) เลือกกฎการเว้นระยะสำหรับแถวภายในอาเรย์ [set_RowSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imatharray/set_rowspacing/) ให้ค่าตัวเลขสำหรับกฎการเว้นระยะที่กำหนดโดยตรงและจะถูกละเลยเมื่อใช้กฎค่าตั้งต้น

ค่าที่ให้สำหรับการเว้นระยะที่แน่นอนจะวัดเป็นพ้อยท์ สำหรับการเว้นระยะแบบสัดส่วนจะวัดเป็นครึ่งบรรทัด: ค่า `3` ในตัวอย่างหมายถึง 1.5 บรรทัด ให้เรียกเซตเตอร์ทั้งสองเมื่อกำหนดค่าตัวเลขอย่างชัดเจน; การเปลี่ยนค่าตัวเลขเพียงอย่างเดียวจะไม่เลือกกฎการเว้นระยะ

ตัวอย่างด้านล่างบันทึกการนำเสนอห้าชุดที่มีสมการ, การจัดแนว, และการตั้งค่าฟอนต์เดียวกัน ชุดแรกสามชุดใช้ค่าตั้งต้น; สองชุดสุดท้ายแสดงค่าที่ระบุอย่างชัดเจน

```cpp
#include <system/array.h>
#include <system/console.h>
#include <drawing/color.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathArray.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathJustification.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathVerticalAlignment.h>
#include <DOM/MathText/MathRowSpacingRule.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

auto createText = [](System::String value)
{
    auto text = System::MakeObject<MathematicalText>(value);
    text->get_Format()->set_FontHeight(24);
    auto font = System::MakeObject<FontData>(u"Cambria Math");
    text->get_Format()->set_LatinFont(font);
    return text;
};

struct ArraySettings
{
    MathRowSpacingRule rule;
    uint32_t spacing;
    System::String name;
};

ArraySettings settings[] =
{
    {MathRowSpacingRule::SingleLineGap, 0, u"SingleLineGap"},
    {MathRowSpacingRule::OneAndAHalfLineGap, 0, u"OneAndAHalfLineGap"},
    {MathRowSpacingRule::TwoLineGap, 0, u"TwoLineGap"},
    {MathRowSpacingRule::Exactly, 20, u"Exactly"},
    {MathRowSpacingRule::Multiple, 3, u"Multiple"}
};

for (const auto& setting : settings)
{
    auto fileName = u"equation-array-" + setting.name + u".pptx";
    auto presentation = System::MakeObject<Presentation>();
    auto mathShape = presentation->get_Slide(0)->get_Shapes()->AddMathShape(20, 20, 600, 300);
    auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
    paragraph->get_ParagraphFormat()->set_SpaceBefore(0);
    paragraph->get_ParagraphFormat()->set_SpaceAfter(0);
    auto mathPortion = System::ExplicitCast<MathPortion>(paragraph->get_Portion(0));
    auto mathParagraph = mathPortion->get_MathParagraph();
    mathParagraph->set_Justification(MathJustification::LeftJustified);

    auto rows = System::MakeArray<System::SharedPtr<IMathElement>>({createText(u"x+y=3"), createText(u"x-y=1"), createText(u"x=2")});
    auto equationArray = System::MakeObject<MathArray>(rows);
    equationArray->set_BaseJustification(MathVerticalAlignment::Center);
    equationArray->set_RowSpacingRule(setting.rule);
    equationArray->set_RowSpacing(setting.spacing);
    auto leftText = createText(u"A=");
    auto rightText = createText(u"=B");
    auto equation = System::MakeObject<MathBlock>(leftText)->Join(equationArray)->Join(rightText);
    mathParagraph->Add(equation);

    presentation->Save(fileName, SaveFormat::Pptx);
    presentation->Dispose();
}
```

การเว้นระยะแถวของอาเรย์แยกจากการเว้นระยะของย่อหน้า [set_SpaceBefore](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacebefore/) และ [set_SpaceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spaceafter/) เพิ่มระยะเว้นรอบย่อหน้าที่บรรจุอาเรย์ ไม่ได้อยู่ระหว่างแถวของอาเรย์ เช่นเดียวกัน [IMathParagraph::set_Justification](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathparagraph/set_justification/) จัดตำแหน่งแนวนอนของ MathParagraph ทั้งหมด; ไม่ได้แทนที่การตั้งค่าการจัดแนวแนวตั้งของอาเรย์

## **เพิ่มฟังก์ชันตรีโกณมิติ**

ใช้ [AsArgumentOfFunction](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/) เมื่ออาร์กิวเมนต์เป็นส่วนประกอบปัจจุบันและชื่อฟังก์ชันเป็นที่ทราบ

![ฟังก์ชันตรีโกณมิติ cos ที่ใช้กับ 2x](powerpoint-math-equations_6.png)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathFunctionsOfOneArgument.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto cosine = System::MakeObject<MathematicalText>(u"2x")
        - >AsArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

mathParagraph->Add(System::MakeObject<MathBlock>(cosine));

presentation->Save(u"trigonometric-function.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **เพิ่มตัวล่างและตัวบน**

ใช้ตัวช่วยสำหรับส่วนล่างและส่วนบนสำหรับดัชนีและกำลัง เมื่อดัชนีต้องแสดงด้านซ้ายของฐาน ให้ใช้ [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/)

![ตัว Y พิมพ์ใหญ่อยู่ด้านซ้ายของตัวอักษรย่อย 1 และตัวอักษรเหนือ n](powerpoint-math-equations_9.png)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto scripts = System::MakeObject<MathematicalText>(u"Y")
        - >SetSubSuperscriptOnTheLeft(u"1", u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(scripts));

presentation->Save(u"subscript-superscript.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **เพิ่มตัวคั่น**

ใช้ [Enclose](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/enclose/) เพื่อใส่นิพจน์ไว้ในตัวคั่น คุณยังสามารถกำหนดอักขระคั่นสำหรับนิพจน์ตัวคั่นที่มีหลายส่วนประกอบได้

![นิพจน์ตัวคั่นที่มี x, y, และ z แยกด้วยเส้นตั้ง](powerpoint-math-equations_13.png)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto delimiter = System::MakeObject<MathematicalText>(u"x")
        - >Join(u"y")
        - >Join(u"z")
        - >Enclose(u'<', u'>', u'|');

mathParagraph->Add(System::MakeObject<MathBlock>(delimiter));

presentation->Save(u"delimiters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **ขนาดและการจัดแนวตัวคั่น**

ส่ง `true` ไปที่ [set_GrowToMatchOperandHeight](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathdelimiter/set_growtomatchoperandheight/) เพื่อให้วงเล็บขยายตามตัวดำเนินการที่สูง หรือ `false` เพื่อให้คงขนาดปกติ [set_DelimiterShape](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathdelimiter/set_delimitershape/) รับค่าเป็นหนึ่งในสองค่า [MathDelimiterShape](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathdelimitershape/) `Centered` จะจัดตำแหน่งวงเล็บให้ศูนย์กลางบนแกนนิพจน์ที่ผ่านสัญลักษณ์เท่ากัน `Match` จะจัดให้ตรงกับเนื้อหาที่ล้อมรอบ ทั้งสองการตั้งค่าใช้กับตัวคั่นเท่านั้น นิพจน์ภายในคงเดิม

ตัวอย่างใส่เศษส่วนในรูปลำดับของ `x` ทำให้นิพจน์ขยายสูงกว่าบรรทัดฐานด้านบนมากกว่าด้านล่าง ทั้งสี่สมการใช้วงเล็บและการตั้งค่าฟอนต์เดียวกัน

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/IPortionFormat.h>
#include <DOM/MathText/IMathBlock.h>
#include <DOM/MathText/IMathDelimiter.h>
#include <DOM/MathText/IMathFraction.h>
#include <DOM/MathText/IMathSuperscriptElement.h>
#include <DOM/MathText/MathDelimiterShape.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto addExpression = [slide](float left, float top, bool grow, MathDelimiterShape shape)
{
    auto fraction = System::MakeObject<MathematicalText>(u"a + b")->Divide(u"c + d");
    auto power = System::MakeObject<MathematicalText>(u"x")->SetSuperscript(fraction);
    auto delimiter = power->Enclose(u'(', u')');
    delimiter->set_GrowToMatchOperandHeight(grow);
    delimiter->set_DelimiterShape(shape);

    auto mathShape = slide->get_Shapes()->AddMathShape(left, top, 300, 100);
    auto portion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
    portion->get_PortionFormat()->set_FontHeight(32);
    auto equation = System::MakeObject<MathematicalText>(u"y = ")->Join(delimiter);
    portion->get_MathParagraph()->Add(equation);
};

addExpression(20, 20, true, MathDelimiterShape::Centered);
addExpression(350, 20, true, MathDelimiterShape::Match);
addExpression(20, 140, false, MathDelimiterShape::Centered);
addExpression(350, 140, false, MathDelimiterShape::Match);

presentation->Save(u"delimiter-sizing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ใน PowerPoint ให้เปรียบเทียบแถวเพื่อดูผลของการขยาย ในแถวบน วงเล็บจะขยายเพื่อครอบลำดับและดูเหมือนกันสำหรับทั้งสองรูปแบบ ในแถวล่าง การขยายถูกปิด วงเล็บเล็กด้านซ้าย (`Centered`) จะจัดแนวกับเครื่องหมายเท่ากับ ขณะที่ด้านขวา (`Match`) จะอยู่สูงขึ้นรอบนิพจน์

![สี่สมการใน PowerPoint ที่มีการขยายตัวคั่นเปิดอยู่ด้านบนและปิดอยู่ด้านล่าง, และ `Centered` ด้านซ้าย, `Match` ด้านขวา](delimiter-sizing.png)

## **เพิ่มกล่องขอบ**

เรียก [ToBorderBox](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/toborderbox/) บนเศษส่วนเพื่อกรอบนิพจน์ทั้งหมด ผลลัพธ์ที่ได้คือ [IMathBorderBox](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathborderbox/) ที่แสดงสี่ด้านตามค่าเริ่มต้น ใช้ [set_HideTop](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathborderbox/set_hidetop/), [set_HideBottom](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathborderbox/set_hidebottom/), [set_HideLeft](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathborderbox/set_hideleft/), และ [set_HideRight](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathborderbox/set_hideright/) เพื่อลบด้านแต่ละด้าน

ตัวอย่างวางเศษส่วนเดียวกันหกชุดบนสไลด์เดียว เพื่อแสดงการยกเลิกให้ซ่อนไว้สี่ด้านทั้งหมดและตั้งค่า [set_StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathborderbox/set_strikethroughbottomlefttotopright/) เพื่อเส้นทแยงขึ้น (↗) หรือ [set_StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathborderbox/set_strikethroughtoplefttobottomright/) เพื่อเส้นทแยงลง (↘) คุณยังสามารถใช้ [set_StrikethroughHorizontal](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathborderbox/set_strikethroughhorizontal/) หรือ [set_StrikethroughVertical](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathborderbox/set_strikethroughvertical/) พร้อมการผสมผสานของด้านที่มองเห็นได้

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathBorderBox.h>
#include <DOM/MathText/IMathFraction.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

auto presentation = System::MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(540, 220, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

auto addFraction = [slide](float x, float y, bool hideBorder = false)
{
    auto fraction = System::MakeObject<MathematicalText>(u"x+1")->Divide(u"y+2");
    auto box = fraction->ToBorderBox();
    box->set_HideTop(hideBorder);
    box->set_HideBottom(hideBorder);
    box->set_HideLeft(hideBorder);
    box->set_HideRight(hideBorder);

    auto shape = slide->get_Shapes()->AddMathShape(x, y, 160, 90);
    auto portion = System::ExplicitCast<MathPortion>(shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
    portion->get_PortionFormat()->set_FontHeight(28);
    auto mathBlock = System::MakeObject<MathBlock>(box);
    portion->get_MathParagraph()->Add(mathBlock);
    return box;
};

addFraction(10, 10);

auto partial = addFraction(190, 10);
partial->set_HideTop(true);
partial->set_HideRight(true);

addFraction(370, 10, true)->set_StrikethroughBottomLeftToTopRight(true);
addFraction(10, 120, true)->set_StrikethroughTopLeftToBottomRight(true);
addFraction(190, 120, true)->set_StrikethroughHorizontal(true);
addFraction(370, 120)->set_StrikethroughVertical(true);

presentation->Save(u"border-box.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![หกเศษส่วนที่แก้ไขได้ใน PowerPoint. แถวบน: กรอบเต็ม, ด้านล่างและซ้าย, เส้นทแยงขึ้น. แถวล่าง: เส้นทแยงลง, เส้นแนวนอน, เส้นแนวตั้งกับกรอบเต็ม](border-box-fractions.png)

บนเศษส่วนนี้ เส้นแนวนอนจะทับบาร์ของเศษส่วน ส่วนเส้นแนวตั้งจะตัดผ่านเศษส่วนบนและล่างขณะที่กรอบรอบๆ ยังคงปรากฏ เส้นเหล่านี้ทำ装饰ให้กับนิพจน์ทั้งหมด ตัวขีดกลางในข้อความธรรมดาจะใช้กับอักขระในรันข้อความ หลังจากเปิดการนำเสนอใหม่ใน PowerPoint คุณยังคงแก้ไขเศษส่วนบนและล่างได้อิสระ

## **จัดกลุ่มเทอม**

ใช้ [Group](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/group/) เพื่อตั้งตัวอักษรจัดกลุ่มเหนือหรือใต้นิพจน์ เพิ่มขีดจำกัดเพื่อทำป้ายกำกับเทอมที่จัดกลุ่ม

![นิพจน์ x บวก y ที่จัดกลุ่มพร้อมป้ายกำกับ any text ใต้มัน](powerpoint-math-equations_15.png)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathGroupingCharacter.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathTopBotPositions.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto grouped = System::MakeObject<MathematicalText>(u"x + y")
        - >Group(u'\u23DF', MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        - >SetLowerLimit(u"any text");

mathParagraph->Add(System::MakeObject<MathBlock>(grouped));

presentation->Save(u"grouped-terms.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **จัดรูปแบบส่วนประกอบคณิตศาสตร์**

ใช้ตัวช่วยการจัดรูปแบบเฉพาะที่ช่วยทำให้สูตรชัดเจน ตัวอย่างเช่น [Overbar](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/overbar/) จะวางบาร์เหนือส่วนประกอบคณิตศาสตร์

![นิพจน์คณิตศาสตร์ ABC ที่มีบาร์เหนือ](powerpoint-math-equations_14.png)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto overbar = System::MakeObject<MathematicalText>(u"ABC")->Overbar();

mathParagraph->Add(System::MakeObject<MathBlock>(overbar));

presentation->Save(u"overbar.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **จัดรูปแบบข้อความในสมการที่มีอยู่**

เพื่อจัดรูปแบบข้อความทั้งหมดในสมการที่มีอยู่ ให้วนผ่านโครงสร้างต้นไม้ของแต่ละ MathBlock [IMathElement::GetChildren](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/getchildren/) คืนค่าเฉพาะเด็กโดยตรง ดังนั้นต้องเรียกแบบ рекурсивно เพื่อเข้าถึงข้อความในเศษส่วน, ตัวล่างบน, ราก, และโครงสร้างซ้อนอื่น ๆ ตรวจสอบส่วนประกอบปัจจุบันรวมถึงลูกของมันเพื่อให้รวมส่วนเริ่มต้นเมื่อเป็น [MathematicalText](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/)

ตัวอย่างนี้สันนิษฐานว่าการนำเสนอมีสมการเช่น `z = xᵢ / ∛y` ที่มีเศษส่วนที่มีดัชนีล่างในตัวเศษและรากในตัวส่วน การประมวลผลเฉพาะส่วนประกอบระดับบนของบล็อกจะพลาดข้อความในเศษส่วน ตัวอย่างค้นหาส่วนคณิตศาสตร์ในกรอบข้อความสไลด์ เข้าถึงบล็อกผ่าน [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) และตั้งความสูงฟอนต์เป็น 28 พ้อยท์ด้วย [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) โดยเข้าถึงการจัดรูปแบบผ่านเมธอด [get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/get_format/) ของแต่ละองค์ประกอบข้อความ

```cpp
#include <functional>
#include <system/array.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathBlock.h>
#include <DOM/MathText/IMathElement.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/IMathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

std::function<void(System::SharedPtr<IMathElement>)> formatMathText;
formatMathText = [&formatMathText](System::SharedPtr<IMathElement> element)
{
    auto text = System::DynamicCast<MathematicalText>(element);
    if (text != nullptr)
        text->get_Format()->set_FontHeight(28.0f);

    for (auto child : element->GetChildren())
        formatMathText(child);
};

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        auto autoShape = System::DynamicCast<IAutoShape>(shape);
        if (autoShape == nullptr || autoShape->get_TextFrame() == nullptr)
            continue;

        for (auto paragraph : autoShape->get_TextFrame()->get_Paragraphs())
        {
            for (auto portion : paragraph->get_Portions())
            {
                auto mathPortion = System::DynamicCast<IMathPortion>(portion);
                if (mathPortion != nullptr)
                {
                    for (auto block : mathPortion->get_MathParagraph())
                        formatMathText(block);
                }
            }
        }
    }
}

presentation->Save(u"formatted-equations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

การบันทึกการนำเสนอจะมีการอัปเดตการจัดรูปแบบข้อความในทุกระดับของแต่ละสมการที่ประมวลผล ในขณะเดียวกันยังคงรักษาเนื้อหาและโครงสร้างคณิตศาสตร์เดิมไว้

## **อ้างอิงด่วน**

| Task | Main API |
| --- | --- |
| สร้างข้อความคณิตศาสตร์ | [MathematicalText](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/) |
| รวมองค์ประกอบ | [IMathElement.Join](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/join/) |
| สร้างส่วนเศษ | [IMathElement.Divide](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/) |
| เพิ่มตัวบ่งชี้เหนือหรือใต้ | [SetSuperscript](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubscript/) |
| เพิ่มฟังก์ชัน | [Function](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| เพิ่มราก | [IMathElement.Radical](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/radical/) |
| เพิ่มขีดจำกัด | [SetLowerLimit](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setupperlimit/) |
| เพิ่มสคริปต์ด้านซ้าย | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| เพิ่มผลรวมและอินทิกรัล | [Nary](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/) |
| เพิ่มเมทริกซ์ | [MathMatrix](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathmatrix/) |
| เพิ่มอาเรย์สมการ | [ToMathArray](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/tomatharray/) |
| เพิ่มตัวคั่น | [Enclose](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/enclose/) |
| เพิ่มบาร์และเส้นขอบ | [Overbar](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/toborderbox/) |
| จัดกลุ่มเทอม | [Group](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/group/) |

## **คำถามที่พบบ่อย**

**ฉันสามารถแก้ไขสมการ PowerPoint ที่มีอยู่ได้หรือไม่?**

ใช่ เปิดการนำเสนอ, ค้นหารูปร่างที่มี [MathPortion](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/), เรียก [get_MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/get_mathparagraph/), แล้วอัปเดต MathBlock ในย่อหนนนั้น

**สมการถูกบันทึกเป็นคณิตศาสตร์ PowerPoint ที่แก้ไขได้หรือไม่?**

ใช่ เมื่อบันทึกเป็น PPTX, Aspose.Slides จะเขียนสมการเป็นเนื้อหา Office Math ที่แก้ไขได้

**ฉันสามารถส่งออกสมการเป็น LaTeX ได้หรือไม่?**

ใช่ ดึง [IMathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathparagraph/) จาก [IMathPortion](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathportion/), แล้วเรียก [IMathParagraph::ToLatex](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathparagraph/tolatex/) เพื่อส่งออกโดยตรง ตัวอย่างเต็มดูที่ [Export Math Equations from Presentations in C++](/slides/th/cpp/exporting-math-equations/#export-math-equations-to-latex)