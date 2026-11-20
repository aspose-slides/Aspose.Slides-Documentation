---
title: จัดรูปแบบข้อความการนำเสนอใน C++
linktitle: การจัดรูปแบบข้อความ
type: docs
weight: 50
url: /th/cpp/text-formatting/
keywords:
- จัดแนวย่อหน้า
- สไตล์ข้อความ
- พื้นหลังข้อความ
- ความโปร่งแสงของข้อความ
- ระยะห่างอักขระ
- คุณสมบัติแบบอักษร
- ตระกูลแบบอักษร
- การหมุนข้อความ
- มุมการหมุน
- กรอบข้อความ
- ระยะห่างบรรทัด
- คุณสมบัติ autofit
- จุดยึดกรอบข้อความ
- การทำแท็บข้อความ
- ภาษาเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "จัดรูปแบบและสไตล์ข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ C++. ปรับแต่งแบบอักษร, สี, การจัดแนวและอื่น ๆ อีกมาก"
---
## **ภาพรวม**

บทความนี้แสดงวิธีจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ C++ ซึ่งครอบคลุมสีพื้นหลัง, ความโปร่งแสง, ระยะห่างระหว่างอักขระ, คุณสมบัติของแบบอักษร, การหมุน, ระยะห่างระหว่างย่อหน้า, พฤติกรรมการปรับอัตโนมัติ, การยึดตำแหน่งข้อความ, จุดหยุดแท็บ, และการตั้งค่าภาษา

ยกเว้นที่ระบุไว้เป็นอย่างอื่น ตัวอย่างจะใช้ [sample.pptx](sample.pptx) การจัดรูปแบบแรกบนสไลด์แรกเป็นกล่องข้อความและย่อหน้าแรกของมันมีข้อความแสดงด้านล่าง ทั้งดัชนีสไลด์และรูปทรงเริ่มจากศูนย์ ตัวอย่างที่เลือกส่วนที่เป็นตัวหนาจะใช้การจัดรูปแบบที่มีผลจริงรวมถึงการจัดรูปแบบตัวหนาที่สืบทอดมา:

![Sample text](sample_text.png)

เพื่อค้นหาและไฮไลท์ข้อความตรงหรือการจับคู่ด้วย regular‑expression ดูที่ [ค้นหาและแทนที่ข้อความ](/slides/th/cpp/search-and-replace-text/).

## **ตั้งค่าสีพื้นหลังของข้อความ**

ใช้ [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) เพื่อกำหนดสีไฮไลท์เริ่มต้นสำหรับย่อหน้า หรือใช้ [IBasePortionFormat::get_HighlightColor](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_highlightcolor/) สำหรับส่วนข้อความแต่ละส่วน

ตัวอย่างต่อไปนี้ตั้งค่าการไฮไลท์สีเทาอ่อนเป็นค่าเริ่มต้นสำหรับย่อหน้าแรก สีไฮไลท์ที่กำหนดโดยตรงบนส่วนข้อความแต่ละส่วนจะมีลำดับความสำคัญเหนือค่านี้:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
auto highlightColor = System::Drawing::Color::get_LightGray();

// Set the highlight color for the entire paragraph.
defaultPortionFormat->get_HighlightColor()->set_Color(highlightColor);

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![The gray paragraph](gray_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ส่วนข้อความที่มีแบบอักษรหนา**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();
auto highlightColor = System::Drawing::Color::get_LightGray();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // ตั้งค่าสีไฮไลท์ให้กับส่วนข้อความ.
        portionFormat->get_HighlightColor()->set_Color(highlightColor);
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![The gray text portions](gray_text_portions.png)

## **จัดแนวย่อหน้าข้อความ**

ใช้ [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) เพื่อกำหนดการจัดแนวย่อหน้าภายในกรอบข้อความ ค่าอาจเป็นการจัดกึ่งกลาง, ชิดซ้าย, ชิดขวา, จัดแนวเต็มบรรทัด ฯลฯ

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีจัดย่อหน้าให้อยู่ที่ **ศูนย์กลาง**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextAlignment.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
// ตั้งค่าการจัดแนวของย่อหน้าให้เป็นกึ่งกลาง.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![The aligned paragraph](aligned_paragraph.png)

## **จัดแนวแบบอักษรภายในบรรทัด**

ใช้ [IParagraphFormat::set_FontAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_fontalignment/) เพื่อจัดแนวแนวตั้งของส่วนข้อความที่มีขนาดแบบอักษรต่างกันภายในบรรทัด การตั้งค่านี้ใช้กับย่อหน้าทั้งหมดและควบคุมการจัดแนวภายในแต่ละบรรทัดของย่อหน้า

ตัวอย่างอิสระต่อไปนี้สร้างกล่องข้อความที่มีป้ายกำกับสี่กล่องบนสไลด์เดียว แต่ละย่อหน้ามีข้อความเดียวกันที่ขนาด 18, 36 และ 54 จุด พร้อมการจัดแนวแบบอักษรที่แตกต่างกัน ใช้ Arial ปิดการทำ autofit และการห่อข้อความ และทำให้กรอบข้อความใหญ่พอสำหรับบรรทัดเดียว

```cpp
#include <DOM/FontAlignment.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

FontAlignment alignments[] = { FontAlignment::Baseline, FontAlignment::Top, FontAlignment::Center, FontAlignment::Bottom };
String labels[] = { u"Baseline", u"Top", u"Center", u"Bottom" };
float fontSizes[] = { 18.0f, 36.0f, 54.0f };
auto font = MakeObject<FontData>(u"Arial");

for (auto i = 0; i < 4; i++)
{
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 20 + i * 130, 660, 120);
    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    auto textFrame = shape->get_TextFrame();
    textFrame->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Top);
    textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
    textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::False);

    auto label = textFrame->get_Paragraph(0);
    label->set_Text(labels[i]);
    label->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    auto labelFormat = label->get_ParagraphFormat()->get_DefaultPortionFormat();
    labelFormat->set_FontHeight(14);
    labelFormat->set_LatinFont(font);
    labelFormat->get_FillFormat()->set_FillType(FillType::Solid);
    labelFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

    auto paragraph = MakeObject<Paragraph>();
    paragraph->get_ParagraphFormat()->set_FontAlignment(alignments[i]);
    paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    auto portionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    portionFormat->set_LatinFont(font);
    portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
    portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    for (auto fontSize : fontSizes)
    {
        auto portion = MakeObject<Portion>(u"Ag ");
        portion->get_PortionFormat()->set_FontHeight(fontSize);
        paragraph->get_Portions()->Add(portion);
    }

    textFrame->get_Paragraphs()->Add(paragraph);
}

presentation->Save(u"font_alignment.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![เปรียบเทียบการจัดแนวแบบอักษร Baseline, Top, Center, และ Bottom กับขนาดแบบอักษรผสม](font_alignment.png)

การจัดแนวแบบอักษรใช้เมตริกของแบบอักษร ดังนั้นขอบที่มองเห็นของอักษรแต่ละตัวอาจไม่ตรงกันอย่างสมบูรณ์ ตัวอย่างรวมทั้งอักษรตัวพิมพ์ใหญ่และอักขระที่มีส่วนล่างเพื่อแสดงความแตกต่างระหว่างการจัดแนว baseline และ bottom การใช้งานแบบอักษรและการทดแทน, อักษรที่ใช้, และความแตกต่างของขนาดแบบอักษรส่งผลต่อผลลัพธ์ ขนาดของเฟรม, ระยะขอบ, ระยะห่างบรรทัด, การห่อข้อความ, และการทำ autofit ก็มีผลต่อการจัดวาง; ใช้แบบอักษรและการตั้งค่าเลย์เอาต์เดียวกันเมื่อเปรียบเทียบโหมด

การตั้งค่านี้แตกต่างจาก [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) ซึ่งควบคุมการจัดแนวแนวนอนของย่อหน้า, และ [ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_anchoringtype/) ที่กำหนดตำแหน่งบล็อกข้อความแนวตั้งภายในรูปทรง การจัดรูปแบบซับสคริปต์และซูเปอร์สคริปต์ผ่าน [IBasePortionFormat::set_Escapement](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_escapement/) จะเปลี่ยนตำแหน่งส่วนแต่ละส่วนสัมพันธ์กับ baseline แทนการตั้งค่าการจัดแนวแบบอักษรสำหรับบรรทัดของย่อหน้า

## **ตั้งค่าความโปร่งแสงสำหรับข้อความ**

ความโปร่งแสงของข้อความควบคุมโดยส่วนประกอบ alpha ของสีที่กำหนดผ่าน [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fillformat/) ในตัวอย่างต่อไปนี้ `alpha = 50` คือค่าช่อง alpha ของ ARGB ในช่วง 0–255 ไม่ใช่เปอร์เซ็นต์ความโปร่งแสง

ตัวอย่างโค้ดด้านล่างแสดงวิธีนำความโปร่งแสงไปใช้กับ **ย่อหน้าทั้งหมด**:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// ตั้งค่าสีเติมของข้อความเป็นสีโปร่งแสง.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto baseColor = System::Drawing::Color::get_Black();
auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![The transparent paragraph](transparent_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีนำความโปร่งแสงไปใช้กับ **ส่วนข้อความที่มีแบบอักษรหนา**:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // ตั้งค่าความโปร่งแสงของส่วนข้อความ.
        portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
        auto baseColor = System::Drawing::Color::get_Black();
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
        portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![The transparent text portions](transparent_text_portions.png)

## **ตั้งค่าระยะห่างระหว่างอักขระสำหรับข้อความ**

ใช้ [IBasePortionFormat::set_Spacing](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_spacing/) เพื่อขยายหรือย่อต่างห่างระหว่างอักขระในกล่องข้อความ ตัวอย่างเพิ่มระยะห่าง 3 จุด; ค่าติดลบจะทำให้ข้อความกระชับลง

ตัวอย่างโค้ด C++ ต่อไปนี้แสดงวิธีขยายระยะห่างอักขระใน **ย่อหน้าทั้งหมด**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// หมายเหตุ: ใช้ค่าติดลบเพื่อบีบระยะห่างระหว่างอักขระ.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f); // ขยายระยะห่างระหว่างอักขระ.

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีขยายระยะห่างอักขระใน **ส่วนข้อความที่มีแบบอักษรหนา**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // หมายเหตุ: ใช้ค่าติดลบเพื่อบีบระยะห่างระหว่างอักขระ.
        portionFormat->set_Spacing(3.0f); // ขยายระยะห่างระหว่างอักขระ.
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **ปิดการใช้ Kerning สำหรับแบบอักษรเฉพาะ**

ในบางกรณี ข้อความที่เรนเดอร์ด้วย Aspose.Slides อาจดูแคบกว่าข้อความเดียวกันใน PowerPoint ซึ่งอาจเกิดจาก PowerPoint เพิกเฉยข้อมูล kerning ของแบบอักษรบางตัว แม้ว่าแบบอักษรจะมีข้อมูล kerning ที่ถูกต้องและเปิดใช้งาน kerning ในการตั้งค่า PowerPoint

เพื่อให้ผลลัพธ์ที่เรนเดิร์มิเกิดใกล้เคียงกับ PowerPoint มากขึ้น คุณสามารถปิดการใช้ kerning สำหรับส่วนข้อความที่ใช้แบบอักษรที่ได้รับผลกระทบได้ ใช้ [IBasePortionFormat::set_KerningMinimalSize](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_kerningminimalsize/) เพื่อตั้งค่าที่ใหญ่กว่าขนาดแบบอักษรจริง ตัวอย่างนี้ต้องการไฟล์ “presentation.pptx” ที่มีกล่องข้อความเป็นรูปทรงแรกบนสไลด์แรก ตรวจสอบชื่อแบบอักษรที่มีผลโดยรวมรวมถึงแบบอักษรที่สืบทอด และตั้งค่าเกณฑ์ 100 จุดสำหรับส่วนที่ใช้ Roboto ซึ่งจะปิด kerning สำหรับส่วนที่มีขนาดแบบอักษรต่ำกว่า 100 จุด:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IFontData.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
System::String targetFont = u"Roboto";
auto textFrame = autoShape->get_TextFrame();
auto paragraphs = textFrame->get_Paragraphs();
int paragraphCount = paragraphs->get_Count();

for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portions = paragraph->get_Portions();
    int portionCount = portions->get_Count();

    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = paragraph->get_Portion(portionIndex);
        auto portionFormat = portion->get_PortionFormat();
        auto textFormat = portionFormat->GetEffective();
        auto latinFont = textFormat->get_LatinFont();
        auto eastAsianFont = textFormat->get_EastAsianFont();
        auto complexScriptFont = textFormat->get_ComplexScriptFont();

        bool isLatinFont = latinFont != nullptr && latinFont->get_FontName() == targetFont;
        bool isEastAsianFont = eastAsianFont != nullptr && eastAsianFont->get_FontName() == targetFont;
        bool isComplexScriptFont = complexScriptFont != nullptr && complexScriptFont->get_FontName() == targetFont;

        if (isLatinFont || isEastAsianFont || isComplexScriptFont)
        {
            portionFormat->set_KerningMinimalSize(100.0f);
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

สำหรับข้อความที่ตรงกับเกณฑ์และอยู่ต่ำกว่าเกณฑ์ การตั้งค่านี้จะป้องกัน kerning และช่วยให้การเรนเดอร์ของ Aspose.Slides สอดคล้องกับผลลัพธ์ที่มองเห็นของ PowerPoint สำหรับแบบอักษรที่ได้รับผลจากพฤติกรรมเฉพาะของ PowerPoint นี้

## **จัดการคุณสมบัติแบบอักษรของข้อความ**

คุณสมบัติแบบอักษรสามารถตั้งค่าที่ระดับย่อหน้าได้ผ่าน [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) หรือที่ระดับส่วนข้อความแต่ละส่วนผ่าน [IPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/)

ตัวอย่างต่อไปนี้ตั้งค่าแบบอักษรเริ่มต้นของย่อหน้าแรกเป็น Times New Roman ขนาด 12 จุด พร้อมการจัดรูปแบบตัวหนา, ตัวเอียง, และขีดเส้นใต้แบบจุดสี จุดจัดรูปแบบที่กำหนดโดยตรงบนส่วนข้อความแต่ละส่วนจะมีลำดับความสำคัญเหนือค่านี้:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/TextUnderlineType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// ตั้งค่าคุณสมบัติแบบอักษรสำหรับย่อหน้า.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
auto font = System::MakeObject<FontData>(u"Times New Roman");
defaultPortionFormat->set_LatinFont(font);

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![The font properties for the paragraph](font_properties_for_paragraph.png)

ตัวอย่างต่อไปนี้ใช้ Times New Roman ขนาด 13 จุด, การจัดรูปแบบเอียง, และขีดเส้นใต้แบบจุดสำหรับส่วนข้อความที่มีการจัดรูปแบบผลลัพธ์เป็นตัวหนา:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/TextUnderlineType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();
auto font = System::MakeObject<FontData>(u"Times New Roman");

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // ตั้งค่าคุณสมบัติแบบอักษรสำหรับส่วนข้อความ.
        portionFormat->set_FontHeight(13.0f);
        portionFormat->set_FontItalic(NullableBool::True);
        portionFormat->set_FontUnderline(TextUnderlineType::Dotted);
        portionFormat->set_LatinFont(font);
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![The font properties for text portions](font_properties_for_text_portions.png)

## **ควบคุมการทำ Normalization ความสูงของข้อความ**

ใช้ [IBasePortionFormat::set_NormaliseHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_normaliseheight/) เมื่อทำสำเนาเทมเพลตการพิมพ์หรือวิเคราะห์ความแตกต่างของความสูงอักขระ ใน PowerPoint การเปิดใช้งาน normalization จะยืดหรือบีบอักขระแต่ละตัวในแนวตั้งให้มีความสูงที่มองเห็นได้สม่ำเสมอภายในส่วนข้อความ ไม่รับประกันความสูงเท่ากันระหว่างแบบอักษรต่าง ๆ

ตั้งค่าคุณสมบัตินี้เป็น [NullableBool::True หรือ False](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) เพื่อเปิดหรือปิดการทำ normalization อย่างชัดเจน `NullableBool::NotDefined` จะปล่อยให้การตั้งค่าท้องถิ่นว่างไว้เพื่อให้ส่วนข้อความสืบทอดค่า ตัวอย่างเช่น จาก [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) ซึ่งไม่เท่ากับ `False` ใช้ [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/) และอ่าน [IBasePortionFormatEffectiveData::get_NormaliseHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformateffectivedata/get_normaliseheight/) เพื่อรับค่าบูลีนที่สรุปแล้ว

ตัวอย่างอิสระต่อไปนี้ต้องการ **Arial** ติดตั้งไว้ สร้างบล็อกข้อความสองบล็อกที่มีอักษรพิมพ์ใหญ่, ตัวพิมพ์เล็ก, ตัวที่ยาวลงและอักขระมีสำเนียงที่ขนาด 54 จุด ย่อหน้าทั้งสองเปิดใช้งาน normalization โดยค่าเริ่มต้น ส่วนบนปิดการทำ normalization โดยชัดเจน; ส่วนล่างสืบทอดค่า การตั้งค่าขนาดเฟรม, ระยะขอบ, และระยะห่างย่อหน้าตรงกัน, ปิดการห่อและ autofit เพื่อให้การเปรียบเทียบสม่ำเสมอ ตัวอย่างพิมพ์ `False: False` และ `NotDefined: True` แล้วบันทึกเป็น “text_height_normalization.pptx”

```cpp
#include <DOM/FillType.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

NullableBool settings[] = { NullableBool::False, NullableBool::NotDefined };

for (auto i = 0; i < 2; i++)
{
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 60 + i * 200, 660, 150);
    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    auto textFrame = shape->get_TextFrame();
    textFrame->set_Text(u"Hxgjpq ÅÉ 0123");
    textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
    textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::False);
    textFrame->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Top);
    textFrame->get_TextFrameFormat()->set_MarginTop(0);
    textFrame->get_TextFrameFormat()->set_MarginLeft(0);

    auto paragraph = textFrame->get_Paragraph(0);
    paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    paragraph->get_ParagraphFormat()->set_SpaceBefore(0);
    paragraph->get_ParagraphFormat()->set_SpaceAfter(0);
    paragraph->get_ParagraphFormat()->set_SpaceWithin(100);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_NormaliseHeight(NullableBool::True);

    auto portion = paragraph->get_Portion(0);
    auto font = MakeObject<FontData>(u"Arial");
    portion->get_PortionFormat()->set_LatinFont(font);
    portion->get_PortionFormat()->set_FontHeight(54);
    portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    portion->get_PortionFormat()->set_NormaliseHeight(settings[i]);

    Console::WriteLine(u"{0}: {1}", settings[i], portion->get_PortionFormat()->GetEffective()->get_NormaliseHeight());
}

presentation->Save(u"text_height_normalization.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

การเปรียบเทียบด้านล่างส่งออกจากงานนำเสนอที่บันทึกไว้ แถวบนปิด normalization (`False`) แถวล่างสืบทอดการเปิด (`NotDefined` → `True`) ควรติดตั้ง Arial เพื่อให้ได้ลักษณะนี้

![Arial 54-point text with normalization disabled above and inherited normalization enabled below](text_height_normalization.png)

Normalization เปลี่ยนความสูงอักขระโดยไม่เปลี่ยนค่า [IBasePortionFormat::get_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fontheight/) ที่ระบุขนาดแบบอักษรในหน่วยจุด ย่อหน้า [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacewithin/) ควบคุมระยะห่างบรรทัด ในขณะที่ [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) ควบคุมวิธีที่ข้อความหรือคอนเทนเนอร์ปรับขนาดเพื่อให้พอดี การตั้งค่าเหล่านี้มีจุดประสงค์ต่างกันและอาจส่งผลต่อการจัดวางโดยรวมอย่างอิสระ สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการจัดรูปแบบย่อหน้าและการสืบทอด ให้ดูที่ [จัดการย่อหน้า](/slides/th/cpp/manage-paragraph/)

## **ประยุกต์และลบการขีดเส้นผ่าน**

ใช้ [IBasePortionFormat::set_StrikethroughType](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_strikethroughtype/) บนส่วนข้อความเพื่อแสดงการแก้ไข, คำที่ถูกยกเลิก, หรือราคาก่อนหน้าโดยไม่ต้องลบข้อความต้นฉบับ ตั้งค่าเป็น [TextStrikethroughType::Single หรือ Double](https://reference.aspose.com/slides/cpp/aspose.slides/textstrikethroughtype/) เพื่อทำเส้นผ่านหนึ่งหรือสองเส้น

เพื่อลบการขีดเส้นผ่าน ให้กำหนดเป็น `TextStrikethroughType::None` ซึ่งจะปิดเอฟเฟกต์โดยชัดเจน แม้ว่าการจัดรูปแบบโดยรอบจะระบุการขีดเส้นผ่านก็ตาม ในทางตรงกันข้าม `TextStrikethroughType::NotDefined` จะปล่อยให้การตั้งค่าท้องถิ่นเป็นค่าว่างเพื่อให้ส่วนข้อความสืบทอดการจัดรูปแบบ เช่น จากย่อหน้า ซึ่งไม่รับประกันว่าการขีดเส้นผ่านจะถูกลบ ใช้ [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/) เพื่ออ่านผลการจัดรูปแบบที่ได้รวมถึงค่าที่สืบทอด

ตัวอย่างอิสระต่อไปนี้สร้างการเปรียบเทียบราคาสามรายการ แต่ละย่อหน้ามีส่วนแยกสำหรับป้าย, ราคาก่อนหน้า, และราคาปัจจุบัน ดังนั้นเฉพาะราคาก่อนหน้าจะได้รับผลกระทบ แถวแรกประยุกต์แล้วลบการขีดเส้นผ่าน; แถวอื่น ๆ คงการขีดเส้นผ่านแบบหนึ่งและแบบสอง การเปลี่ยนคุณสมบัตินี้ทำให้ข้อความและการจัดรูปแบบอื่น ๆ รวมถึงตัวหนาของราคาก่อนหน้าถูกเก็บไว้

```cpp
#include <DOM/FillType.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextStrikethroughType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 620, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

String labels[] = { u"None: ", u"Single: ", u"Double: " };

for (auto label : labels)
{
    auto paragraph = MakeObject<Paragraph>();
    paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    paragraph->get_ParagraphFormat()->set_SpaceAfter(20);

    auto format = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    format->set_FontHeight(28);
    auto font = MakeObject<FontData>(u"Arial");
    format->set_LatinFont(font);
    format->get_FillFormat()->set_FillType(FillType::Solid);
    format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    auto labelPortion = MakeObject<Portion>(label);
    paragraph->get_Portions()->Add(labelPortion);

    auto previousPrice = MakeObject<Portion>(u"$100");
    previousPrice->get_PortionFormat()->set_FontBold(NullableBool::True);
    paragraph->get_Portions()->Add(previousPrice);
    auto currentPrice = MakeObject<Portion>(u" → $80");
    paragraph->get_Portions()->Add(currentPrice);

    textFrame->get_Paragraphs()->Add(paragraph);
}

// ใช้การขีดเส้นผ่าน, จากนั้นลบออกโดยเจาะจงจากราคาก่อนหน้าตัวแรก.
auto firstPriceFormat = textFrame->get_Paragraph(0)->get_Portion(1)->get_PortionFormat();
firstPriceFormat->set_StrikethroughType(TextStrikethroughType::Single);
firstPriceFormat->set_StrikethroughType(TextStrikethroughType::None);

textFrame->get_Paragraph(1)->get_Portion(1)->get_PortionFormat()->set_StrikethroughType(TextStrikethroughType::Single);
textFrame->get_Paragraph(2)->get_Portion(1)->get_PortionFormat()->set_StrikethroughType(TextStrikethroughType::Double);

presentation->Save(u"strikethrough.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์จากบนลงล่าง: ไม่มีการขีดเส้นผ่าน, การขีดเส้นผ่านแบบหนึ่ง, และการขีดเส้นผ่านแบบสอง

![Previous prices without strikethrough, with single strikethrough, and with double strikethrough](strikethrough.png)


## **ตั้งค่าการหมุนของข้อความ**

ใช้ [ITextFrameFormat::set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_textverticaltype/) เพื่อตั้งค่าทิศทางข้อความที่กำหนดไว้ล่วงหน้าภายในรูปทรง

ตัวอย่างโค้ดต่อไปนี้ตั้งค่าทิศทางข้อความในรูปทรงเป็น [TextVerticalType::Vertical270](https://reference.aspose.com/slides/cpp/aspose.slides/textverticaltype/) ซึ่งทำให้ข้อความหมุน **90 องศาตรงข้ามเข็มนาฬิกา**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![The text rotation](text_rotation.png)

## **ตั้งค่าการหมุนแบบกำหนดเองสำหรับกรอบข้อความ**

ใช้ [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_rotationangle/) เพื่อกำหนดมุมการหมุนแบบกำหนดเองสำหรับ [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)

ตัวอย่างโค้ดด้านล่างหมุนกรอบข้อความ 3 องศาตามเข็มนาฬิกาภายในรูปทรง:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![The custom text rotation](custom_text_rotation.png)

## **ตั้งค่าระยะห่างบรรทัดของย่อหน้า**

Aspose.Slides มี [IParagraphFormat::set_SpaceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spaceafter/), [IParagraphFormat::set_SpaceBefore](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacebefore/), และ [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacewithin/) เพื่อควบคุมระยะห่างของย่อหน้า วิธีการเหล่านี้ใช้ดังต่อไปนี้

* ใช้ค่าบวกเพื่อระบุระยะห่างบรรทัดเป็นเปอร์เซ็นต์ของความสูงบรรทัด
* ใช้ค่าลบเพื่อระบุระยะห่างบรรทัดเป็นหน่วยจุด

ตัวอย่างต่อไปนี้ตั้งค่าระยะห่างภายในย่อหน้าแรกเป็น 200% ของความสูงบรรทัด (ช่องว่างสองเท่า):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![The line spacing within the paragraph](line_spacing.png)

## **ควบคุมการตัดบรรทัด**

กฎการตัดบรรทัดของย่อหน้ามีประโยชน์ในบล็อกข้อความแคบและงานนำเสนอที่ผสมข้อความละตินและเอเชียตะวันออก วิธีการต่อไปนี้เป็นของ [IParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/) ดังนั้นจึงใช้กับย่อหนัทั้งหมด

* [IParagraphFormat::set_LatinLineBreak](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_latinlinebreak/) ควบคุมกฎการตัดบรรทัดสำหรับละติน ในข้อความผสม การเปลี่ยนค่านี้อาจเปลี่ยนตำแหน่งการตัดบรรทัดของข้อความเอเชียตะวันออกและเครื่องหมายวรรคตอนที่อยู่ติดกัน
* [IParagraphFormat::set_EastAsianLineBreak](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_eastasianlinebreak/) ควบคุมกฎการตัดบรรทัดสำหรับเอเชียตะวันออก รวมถึงข้อจำกัดของอักขระที่อยู่ต้นหรือปลายบรรทัด

กฎเหล่านี้ไม่แทนที่ [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/) ซึ่งเปิดการห่ออัตโนมัติภายในกรอบข้อความ พวกมันมีผลต่อการจัดวางเมื่อเกิดการห่อข้อความ; พวกมันไม่ได้แทรกอักขระตัดบรรทัด การตัดบรรทัดโดยตรงจะบังคับให้บรรทัดใหม่ภายในย่อหน้าโดยอิสระจากความกว้างที่มี

ตัวอย่างอิสระต่อไปนี้สร้างบล็อกข้อความแคบที่ประกอบด้วยภาษาจีนและละติน ตั้งค่ากฎการตัดบรรทัดทั้งสองอย่างชัดเจนและบันทึกเป็น “line_breaking.pptx” เพื่อทดลองเปลี่ยนค่าใดค่าหนึ่งขณะคงค่าที่เหลือคงที่ ตัวอย่างใช้ Arial 24 จุดและ SimSun กับความกว้างเฟรม 160 จุดและระยะขอบแนวนอนของกรอบข้อความเป็นศูนย์ [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) ถูกเรียกด้วย [TextAutofitType::None](https://reference.aspose.com/slides/cpp/aspose.slides/textautofittype/) เพื่อให้ขนาดข้อความและขนาดเฟรมคงที่

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 160.0f, 300.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
textFrame->get_TextFrameFormat()->set_MarginLeft(0);
textFrame->get_TextFrameFormat()->set_MarginRight(0);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->set_Text(u"中文排版测试，PowerPoint 中文演示。");

auto format = paragraph->get_ParagraphFormat();
format->set_Alignment(TextAlignment::Left);
auto portionFormat = format->get_DefaultPortionFormat();
portionFormat->set_FontHeight(24.0f);
auto latinFont = System::MakeObject<FontData>(u"Arial");
portionFormat->set_LatinFont(latinFont);
auto eastAsianFont = System::MakeObject<FontData>(u"SimSun");
portionFormat->set_EastAsianFont(eastAsianFont);
portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
format->set_LatinLineBreak(NullableBool::False);
format->set_EastAsianLineBreak(NullableBool::True);

presentation->Save(u"line_breaking.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ควบคุมการทำ Hanging Punctuation**

[IParagraphFormat::set_HangingPunctuation](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_hangingpunctuation/) อนุญาตให้เครื่องหมายวรรคตอนที่เหมาะสมขยายออกนอกขอบด้านขวาของบรรทัดข้อความแทนที่จะย้ายไปบรรทัดถัดไป ใช้กับย่อหน้าทั้งหมดและแตกต่างจากการเยื้องแบบ hanging

ตัวอย่างอิสระต่อไปนี้เปิดใช้งาน hanging punctuation ในกรอบข้อความกว้าง 100 จุดและบันทึกเป็น “hanging_punctuation.pptx” ด้วย Arial 24 จุดและระยะขอบแนวนอนเป็นศูนย์ จุดสุดท้ายของประโยคจะอยู่หลังคำ “sentence” และขยายออกนอกขอบข้อความขวามือ ส่งค่า [NullableBool::False](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) ไปยังตัวตั้งค่าเพื่อเปรียบเทียบ: ด้วยการตั้งค่านี้ จุดสุดท้ายจะอยู่ในบรรทัดแยก การห่อเปิดใช้งานและ autofit ปิดเพื่อให้ความกว้างคงที่

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 200.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
textFrame->get_TextFrameFormat()->set_MarginLeft(0);
textFrame->get_TextFrameFormat()->set_MarginRight(0);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->set_Text(u"Simple text, next sentence.");

auto format = paragraph->get_ParagraphFormat();
format->set_Alignment(TextAlignment::Left);
auto portionFormat = format->get_DefaultPortionFormat();
portionFormat->set_FontHeight(24.0f);
auto latinFont = System::MakeObject<FontData>(u"Arial");
portionFormat->set_LatinFont(latinFont);
portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
format->set_HangingPunctuation(NullableBool::True);

presentation->Save(u"hanging_punctuation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ไม่ใช่ทุกเครื่องหมายวรรคตอนจะสามารถ hanging ได้ เงื่อนไขของแบบอักษรและการจัดวางที่อธิบายไว้ข้างต้น ([ควบคุมการตัดบรรทัด](#control-line-breaking)) ก็ใช้กับการเปรียบเทียบนี้ด้วย: การเปลี่ยนแบบอักษร, ความกว้างที่ใช้ได้, ระยะขอบ, หรือการตั้งค่า autofit อาจทำให้ความแตกต่างที่มองเห็นหายไป

## **ตั้งค่าประเภท Autofit สำหรับกรอบข้อความ**

[ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) กำหนดวิธีที่ข้อความทำงานเมื่อเกินขอบเขตของคอนเทนเนอร์ ใช้เพื่อควบคุมว่าข้อความจะย่อตัว, ล้นออก, หรือปรับขนาดรูปทรงอัตโนมัติ ตัวอย่างต่อไปนี้ตั้งค่ารูปทรงให้ปรับขนาดเพื่อให้พอดีกับข้อความและบันทึกผลเป็น “autofit_type.pptx”

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

เพื่อให้นับบรรทัดหลังจากการห่ออัตโนมัติและดูว่าขนาดข้อความหรือรูปทรงเปลี่ยนผลอย่างไร ให้ดูที่ [นับบรรทัดที่แสดง](/slides/th/cpp/manage-paragraph/) การนับบรรทัดเพียงอย่างเดียวไม่ได้บ่งชี้ว่าข้อความล้นออกจากคอนเทนเนอร์หรือไม่

## **ตั้งค่าจุดยึดของกรอบข้อความ**

[ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_anchoringtype/) กำหนดวิธีที่ข้อความวางแนวตั้งภายในรูปทรง เช่น อยู่ด้านบน, กลาง, หรือด้านล่าง ตัวอย่างต่อไปนี้ยึดข้อความไว้ที่ด้านล่างของรูปทรงแรกและบันทึกผลเป็น “text_anchor.pptx”

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextAnchorType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ตั้งค่าการทำ Tabulation ของข้อความ**

ใช้ [IParagraphFormat::set_DefaultTabSize](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_defaulttabsize/) และ [IParagraphFormat::get_Tabs](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_tabs/) เพื่อตั้งค่าตำแหน่งหยุดแท็บในย่อหน้า ตัวอย่างต่อไปนี้ตั้งค่าช่วงแท็บเริ่มต้นเป็น 100 จุดและเพิ่มตำแหน่งแท็บซ้ายที่ 30 จุด การตั้งค่าเหล่านี้ส่งผลต่อข้อความที่มีอักขระแท็บ

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITabCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TabAlignment.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![The paragraph tabs](paragraph_tabs.png)

## **ตั้งค่าภาษา Proofing**

Aspose.Slides มี [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/) ซึ่งให้คุณตั้งค่าภาษา proofing สำหรับส่วนข้อความ ภาษา proofing กำหนดภาษาที่ใช้สำหรับการตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

ตัวอย่างต่อไปนี้ต้องการ “presentation.pptx” ที่มีกล่องข้อความเป็นรูปทรงแรกบนสไลด์แรกและมีอย่างน้อยหนึ่งย่อหน้า แทนที่เนื้อหาของย่อหน้าแรกด้วย “1。” ตั้งค่าแบบอักษรเป็น SimSun และกำหนดภาษา proofing จีนตัวย่อ (`zh-CN`) บันทึกผลเป็น “proofing_language.pptx”

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto font = System::MakeObject<FontData>(u"SimSun");

auto textPortion = System::MakeObject<Portion>();
auto portionFormat = textPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

// ตั้งค่าภาษา proofing เป็นภาษาจีนตัวย่อ.
portionFormat->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1。");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **คัดลอกเมตาดาต้าภาษา**

เมื่อคัดลอกข้อความหลายภาษาจากเทมเพลต ให้เก็บรหัสภาษาไว้ทั้งสองโดยใช้ [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/) และ [IBasePortionFormat::set_AlternativeLanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_alternativelanguageid/) ตัวอย่างอิสระต่อไปนี้สร้างส่วนต้นแบบที่มีภาษาอังกฤษอเมริกันเป็นภาษาและภาษาฝรั่งเศสเป็นภาษาทางเลือก แล้วคัดลอกข้อความและรหัสเหล่านั้นไปยังส่วนในงานนำเสนอใหม่

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto source = System::MakeObject<Portion>(u"Hello! Bonjour!");
source->get_PortionFormat()->set_LanguageId(u"en-US");
source->get_PortionFormat()->set_AlternativeLanguageId(u"fr-FR");

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 80.0f);
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto destination = System::MakeObject<Portion>();
destination->set_Text(source->get_Text());
destination->get_PortionFormat()->set_LanguageId(source->get_PortionFormat()->get_LanguageId());
// ถ้าต้นทางไม่มีภาษาทางเลือก สตริง null จะลบค่าที่อยู่ในปลายทาง.
destination->get_PortionFormat()->set_AlternativeLanguageId(source->get_PortionFormat()->get_AlternativeLanguageId());
paragraph->get_Portions()->Add(destination);

presentation->Save(u"copied_language_metadata.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

หากต้องการลองแหล่งที่ไม่มีภาษาทางเลือก ให้ละเว้นการกำหนดค่า `u"fr-FR"` ตัวระบุทางเลือกจะเป็นสตริงว่างเปล่าและคำสั่งคัดลอกเดียวกันจะคงการไม่มีค่าไว้โดยไม่ได้เพิ่มค่าเริ่มต้น แม้ว่าปลายทางก่อนหน้านี้จะมีภาษาทางเลือกกำหนดไว้

รหัสเหล่านี้เป็นเมตาดาต้าภาษา การเก็บรักษาเหล่านี้ไม่ได้กำหนดว่า PowerPoint จะเลือกพจนานุกรมใดสำหรับการตรวจสอบการสะกดหรือไวยากรณ์

## **ตั้งค่าภาษาเริ่มต้น**

ใช้ [LoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_defaulttextlanguage/) เพื่อกำหนดภาษาที่ใช้เป็นค่าเริ่มต้นสำหรับข้อความที่สร้างขณะโหลดหรือสร้างงานนำเสนอ ตัวอย่างต่อไปนี้สร้างงานนำเสนอที่มีภาษาอังกฤษอเมริกันเป็นภาษาเริ่มต้นของข้อความ เพิ่มกล่องข้อความและพิมพ์ `en-US` สำหรับส่วนข้อความแรก

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// เพิ่มรูปร่างสี่เหลี่ยมผืนผ้าใหม่พร้อมข้อความ.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// ตรวจสอบภาษาของส่วนข้อความแรก.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto languageId = portion->get_PortionFormat()->get_LanguageId();
System::Console::WriteLine(languageId);

presentation->Dispose();
```

## **ตั้งค่า Style ข้อความเริ่มต้น**

เพื่อประยุกต์การจัดรูปแบบข้อความเริ่มต้นในระดับงานนำเสนอ ใช้ [IPresentation::get_DefaultTextStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_defaulttextstyle/)

ตัวอย่างต่อไปนี้ตั้งค่าแบบอักษรขนาด 14 จุดเป็นตัวหนาเป็นค่าเริ่มต้นสำหรับย่อหน้าระดับบนในงานนำเสนอใหม่และบันทึกเป็น “default_text_style.pptx” ข้อความสามารถสืบทอดค่าเริ่มต้นเหล่านี้ได้ เว้นแต่การจัดรูปแบบที่ระบุเฉพาะจะทับค่าเริ่มต้น

```cpp
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

// ดึงรูปแบบย่อหน้าระดับบนสุด.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    auto defaultPortionFormat = paragraphFormat->get_DefaultPortionFormat();
    defaultPortionFormat->set_FontHeight(14.0f);
    defaultPortionFormat->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **สกัดข้อความพร้อมเอฟเฟกต์ All‑Caps**

ใน PowerPoint การประยุกต์เอฟเฟกต์ **All Caps** ทำให้ข้อความปรากฏเป็นตัวพิมพ์ใหญ่บนสไลด์แม้จะพิมพ์เป็นตัวพิมพ์เล็กอยู่ก็ตาม เมื่อคุณดึงส่วนข้อความดังกล่าวด้วย Aspose.Slides ไลบรารีจะคืนข้อความตามที่พิมพ์ไว้จริง เพื่อให้ตรงกับข้อความที่แสดง ตรวจสอบ [TextCapType](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/) และแปลงสตริงที่คืนค่ามาเป็นตัวพิมพ์ใหญ่เมื่อค่าเป็น [TextCapType::All](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/)

ตัวอย่างนี้ต้องการ “sample2.pptx” ที่มีกล่องข้อความเป็นรูปทรงแรกบนสไลด์แรก ย่อหน้าแรกของมันมีส่วนแรกเป็น “Hello, Aspose!” พร้อมเอฟเฟกต์ All Caps ตามแสดงด้านล่าง

![The All Caps effect](all_caps_effect.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีสกัดข้อความพร้อมเอฟเฟกต์ **All Caps** ที่ประยุกต์ไว้:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextCapType.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample2.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

auto originalText = textPortion->get_Text();
System::Console::WriteLine(u"Original text: " + originalText);

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto uppercaseText = originalText.ToUpper();
    System::Console::WriteLine(u"All-Caps effect: " + uppercaseText);
}

presentation->Dispose();
```

ผลลัพธ์:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**ฉันจะแก้ไขข้อความในตารางบนสไลด์ได้อย่างไร?**

เพื่อแก้ไขข้อความในตารางบนสไลด์ ให้ใช้ [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) วนผ่านเซลล์แต่ละเซลล์และอัปเดตเซลล์ผ่าน [ICell::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) และจัดรูปแบบย่อหน้าผ่าน [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/get_paragraphformat/)

**ฉันจะประยุกต์สีไล่ระดับให้กับข้อความบนสไลด์ PowerPoint ได้อย่างไร?**

เพื่อประยุกต์สีไล่ระดับให้กับข้อความ ให้ใช้ [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fillformat/) ตั้งค่า [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) เป็น [FillType::Gradient](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) และกำหนดจุดไล่สี, ทิศทาง, และความโปร่งแสง

คุณลักษณะที่เกี่ยวข้อง: [จัดรูปแบบข้อความในสไลด์](/slides/th/features/text-formatting/)