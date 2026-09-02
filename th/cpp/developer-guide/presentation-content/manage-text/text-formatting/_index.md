---
title: "จัดรูปแบบข้อความการนำเสนอใน C++"
linktitle: "การจัดรูปแบบข้อความ"
type: docs
weight: 50
url: /th/cpp/text-formatting/
keywords:
- "จัดตำแหน่งย่อหน้า"
- "สไตล์ข้อความ"
- "พื้นหลังข้อความ"
- "ความโปร่งใสของข้อความ"
- "ช่องว่างระหว่างอักขระ"
- "คุณสมบัติกระพริบของฟอนต์"
- "ตระกูลฟอนต์"
- "การหมุนของข้อความ"
- "มุมการหมุน"
- "กรอบข้อความ"
- "ระยะห่างบรรทัด"
- "คุณสมบัติการพอดีอัตโนมัติ"
- "จุดยึดกรอบข้อความ"
- "การจัดแท็บของข้อความ"
- "ภาษาเริ่มต้น"
- "PowerPoint"
- "OpenDocument"
- "การนำเสนอ"
- "C++"
- "Aspose.Slides"
description: "จัดรูปแบบและสไตล์ข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ C++. ปรับแต่งฟอนต์, สี, การจัดแนว, และอื่น ๆ"
---
## **ภาพรวม**

บทความนี้แสดงวิธีจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides for C++ ครอบคลุมสีพื้นหลัง, ความโปร่งใส, ระยะห่างระหว่างตัวอักษร, คุณสมบัติกระพริบ, การหมุน, ระยะห่างย่อหน้า, พฤติกรรม autofit, การล็อคข้อความ, จุดหยุดแท็บ, และการตั้งค่าภาษา

ในตัวอย่างด้านล่าง เราจะใช้ไฟล์ชื่อ “sample.pptx” ซึ่งมีกล่องข้อความเดียวบนสไลด์แรกด้วยข้อความต่อไปนี้:

![ข้อความตัวอย่าง](sample_text.png)

หากต้องการค้นหาและไฮไลท์ข้อความแบบตัวอักษรหรือตรงกับ regular‑expression ให้ดูที่ [ค้นหาและแทนที่ข้อความ](/slides/th/cpp/search-and-replace-text/)

## **ตั้งค่าสีพื้นหลังของข้อความ**

ใช้ [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) เพื่อกำหนดสีไฮไลท์เริ่มต้นสำหรับย่อหน้า หรือใช้ [IBasePortionFormat::get_HighlightColor](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseportionformat/get_highlightcolor/) สำหรับส่วนของข้อความแต่ละส่วน

โค้ดตัวอย่างต่อไปนี้แสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ย่อหน้าเต็ม**:

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

// ตั้งค่าสีไฮไลท์สำหรับย่อหน้าเต็ม
defaultPortionFormat->get_HighlightColor()->set_Color(highlightColor);

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![ย่อหน้าสีเทา](gray_paragraph.png)

โค้ดตัวอย่างด้านล่างแสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ส่วนของข้อความที่มีแบบอักษรหนา**:

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
        // ตั้งค่าสีไฮไลท์สำหรับส่วนของข้อความ.
        portionFormat->get_HighlightColor()->set_Color(highlightColor);
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![ส่วนข้อความสีเทา](gray_text_portions.png)

## **จัดตำแหน่งย่อหน้าข้อความ**

ใช้ [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_alignment/) เพื่อกำหนดการจัดตำแหน่งย่อหน้าในกรอบข้อความ ค่าที่กำหนดได้อาจเป็นกึ่งกลาง, ชิดซ้าย, ชิดขวา, จัดแนวเต็ม, ฯลฯ

โค้ดตัวอย่างต่อไปนี้แสดงวิธีจัดตำแหน่งย่อหน้าให้ **กึ่งกลาง**:

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

// ตั้งค่าการจัดตำแหน่งของย่อหน้าเป็นกึ่งกลาง.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![ย่อหน้าที่จัดตำแหน่งแล้ว](aligned_paragraph.png)

## **ตั้งค่าความโปร่งใสของข้อความ**

ความโปร่งใสของข้อความควบคุมผ่านส่วน alpha ของสีที่กำหนดโดย [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseportionformat/get_fillformat/) ในตัวอย่างต่อไป `alpha = 50` เป็นค่าช่อง alpha ของ ARGB ในช่วง 0‑255 ไม่ใช่เปอร์เซ็นต์ความโปร่งใส

โค้ดตัวอย่างด้านล่างแสดงวิธีใช้ความโปร่งใสกับ **ย่อหน้าเต็ม**:

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

// ตั้งค่าสีเติมของข้อความเป็นสีโปร่งใส.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto baseColor = System::Drawing::Color::get_Black();
auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![ย่อหน้าที่โปร่งใส](transparent_paragraph.png)

โค้ดตัวอย่างต่อไปนี้แสดงวิธีใช้ความโปร่งใสกับ **ส่วนของข้อความที่มีแบบอักษรหนา**:

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
        // ตั้งค่าความโปร่งใสของส่วนข้อความ.
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

![ส่วนข้อความที่โปร่งใส](transparent_text_portions.png)

## **ตั้งค่าระยะห่างระหว่างตัวอักษรของข้อความ**

ใช้ [IBasePortionFormat::set_Spacing](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseportionformat/set_spacing/) เพื่อขยายหรือยืดระยะห่างระหว่างอักขระในกล่องข้อความ

โค้ด C++ ต่อไปนี้แสดงวิธีขยายระยะห่างระหว่างอักขระใน **ย่อหน้าเต็ม**:

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

// หมายเหตุ: ใช้ค่าลบเพื่อบีบอัดช่องว่างระหว่างอักขระ.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f); // ขยายช่องว่างระหว่างอักขระ.

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![ระยะห่างระหว่างอักขระในย่อหน้า](character_spacing_in_paragraph.png)

โค้ดตัวอย่างด้านล่างแสดงวิธีขยายระยะห่างระหว่างอักขระใน **ส่วนของข้อความที่มีแบบอักษรหนา**:

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
        // หมายเหตุ: ใช้ค่าติดลบเพื่อบีบอัดช่องว่างระหว่างอักขระ.
        portionFormat->set_Spacing(3.0f); // ขยายช่องว่างระหว่างอักขระ.
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![ระยะห่างระหว่างอักขระในส่วนข้อความ](character_spacing_in_text_portions.png)

### **ปิดการใช้งาน Kerning สำหรับแบบอักษรเฉพาะ**

ในบางกรณี ข้อความที่แสดงโดย Aspose.Slides อาจดูแน่นกว่าข้อความเดียวกันใน PowerPoint เพราะ PowerPoint อาจละเลยข้อมูล kerning สำหรับแบบอักษรบางตัวแม้แบบอักษรนั้นจะมีข้อมูล kerning ที่ถูกต้องและเปิดใช้งานอยู่ในการตั้งค่า PowerPoint

เพื่อให้ผลลัพธ์ที่แสดงใกล้เคียงกับ PowerPoint มากขึ้น คุณสามารถปิด kerning สำหรับส่วนข้อความที่ใช้แบบอักษรที่ได้รับผลกระทบได้ ใช้ [IBasePortionFormat::set_KerningMinimalSize](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseportionformat/set_kerningminimalsize/) เพื่อตั้งค่าที่ใหญ่กว่าขนาดแบบอักษรจริงอย่างมีนัยสำคัญ:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IFontData.h>
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
        auto latinFont = portionFormat->get_LatinFont();
        auto eastAsianFont = portionFormat->get_EastAsianFont();
        auto complexScriptFont = portionFormat->get_ComplexScriptFont();

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

การตั้งค่านี้ทำให้ kerning ไม่ถูกนำไปใช้กับส่วนข้อความที่ตรงกันและช่วยให้การเรนเดอร์ของ Aspose.Slides สอดคล้องกับการแสดงผลของ PowerPoint สำหรับแบบอักษรที่ได้รับผลจากพฤติกรรมเฉพาะของ PowerPoint นี้

## **จัดการคุณสมบัติกระพริบของข้อความ**

คุณสมบัติกระพริบของแบบอักษรสามารถตั้งค่าที่ระดับย่อหน้าผ่าน [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) หรือที่ระดับส่วนข้อความแต่ละส่วนผ่าน [IPortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportionformat/)

โค้ดต่อไปนี้ตั้งค่ากระพริบและสไตล์ข้อความสำหรับ **ย่อหน้าเต็ม**: กำหนดขนาดแบบอักษร, ตัวหนา, ตัวเอียง, การขีดเส้นใต้แบบจุด, และแบบอักษร Times New Roman ให้กับทุกส่วนในย่อหน้า

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

// ตั้งค่าคุณสมบัติของแบบอักษรสำหรับย่อหน้า.
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

![คุณสมบัติกระพริบของย่อหน้า](font_properties_for_paragraph.png)

โค้ดตัวอย่างด้านล่างใช้คุณสมบัติเดียวกันกับ **ส่วนของข้อความที่มีแบบอักษรหนา**:

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
        // ตั้งค่าคุณสมบัติของแบบอักษรสำหรับส่วนของข้อความ.
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

![คุณสมบัติกระพริบของส่วนข้อความ](font_properties_for_text_portions.png)

## **ตั้งค่าการหมุนของข้อความ**

ใช้ [ITextFrameFormat::set_TextVerticalType](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformat/set_textverticaltype/) เพื่อกำหนดทิศทางข้อความที่กำหนดล่วงหน้าในรูปร่าง

โค้ดต่อไปนี้ตั้งค่าทิศทางข้อความในรูปร่างเป็น [TextVerticalType::Vertical270](https://reference.aspose.com/slides/th/cpp/aspose.slides/textverticaltype/) ซึ่งทำให้ข้อความ **หมุน 90 องศา ไปทางทวนเข็มนาฬิกา**:

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

![การหมุนของข้อความ](text_rotation.png)

## **ตั้งค่าการหมุนแบบกำหนดเองสำหรับกรอบข้อความ**

ใช้ [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformat/set_rotationangle/) เพื่อกำหนดมุมการหมุนแบบกำหนดเองสำหรับ [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/)

โค้ดตัวอย่างด้านล่างหมุนกรอบข้อความ 3 องศา ตามเข็มนาฬิกาในรูปร่าง:

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

![การหมุนข้อความแบบกำหนดเอง](custom_text_rotation.png)

## **ตั้งค่าระยะห่างบรรทัดของย่อหน้า**

Aspose.Slides มี [IParagraphFormat::set_SpaceAfter](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_spaceafter/), [IParagraphFormat::set_SpaceBefore](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_spacebefore/) และ [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_spacewithin/) เพื่อควบคุมระยะห่างย่อหน้า วิธีใช้ดังนี้:

* ใช้ค่าเป็นจำนวนบวกเพื่อระบุระยะห่างบรรทัดเป็นเปอร์เซ็นต์ของความสูงบรรทัด
* ใช้ค่าเป็นจำนวนลบเพื่อระบุระยะห่างบรรทัดเป็นพอยต์

โค้ดตัวอย่างต่อไปนี้แสดงวิธีกำหนดระยะห่างบรรทัดภายในย่อหน้า:

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

![ระยะห่างบรรทัดในย่อหน้า](line_spacing.png)

## **ตั้งค่าประเภท Autofit สำหรับกรอบข้อความ**

[ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformat/set_autofittype/) กำหนดวิธีที่ข้อความทำงานเมื่อเกินขอบเขตของคอนเทนเนอร์ ใช้เพื่อควบคุมว่าข้อความจะหด, ล้น, หรือปรับขนาดรูปร่างโดยอัตโนมัติ

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

## **ตั้งค่าตำแหน่งยึดของกรอบข้อความ**

[ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformat/set_anchoringtype/) กำหนดว่าข้อความถูกวางตำแหน่งแนวตั้งภายในรูปร่างอย่างไร เช่น ด้านบน, กลาง, หรือด้านล่าง

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

## **ตั้งค่าการจัดแท็บของข้อความ**

ใช้ [IParagraphFormat::set_DefaultTabSize](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_defaulttabsize/) และ [IParagraphFormat::get_Tabs](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/get_tabs/) เพื่อกำหนดจุดหยุดแท็บในย่อหน้า

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

![แท็บของย่อหน้า](paragraph_tabs.png)

## **ตั้งค่าภาษา Proofing**

Aspose.Slides มี [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseportionformat/set_languageid/) ซึ่งให้คุณตั้งค่าภาษา proofing สำหรับส่วนข้อความ ภาษานี้กำหนดภาษาที่ใช้ตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

โค้ดตัวอย่างต่อไปนี้แสดงวิธีตั้งค่าภาษา proofing สำหรับส่วนข้อความ:

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

// ตั้งค่า Id ของภาษาการตรวจสอบการสะกด.
portionFormat->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ตั้งค่าภาษาปริยาย**

ใช้ [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) เพื่อกำหนดภาษาปริยายสำหรับข้อความที่สร้างขณะโหลดหรือสร้างพรีเซนเทชัน

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

// เพิ่มรูปสี่เหลี่ยมผืนผ้าใหม่พร้อมข้อความ.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// ตรวจสอบภาษาของส่วนข้อความแรก.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto languageId = portion->get_PortionFormat()->get_LanguageId();
System::Console::WriteLine(languageId);

presentation->Dispose();
```

## **ตั้งค่าสไตล์ข้อความปริยาย**

เพื่อใช้การจัดรูปแบบข้อความปริยายระดับพรีเซนเทชัน ให้ใช้ [IPresentation::get_DefaultTextStyle](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/get_defaulttextstyle/)

โค้ดต่อไปนี้แสดงวิธีตั้งค่าฟอนต์หนาขนาด 14 pt เป็นค่าเริ่มต้นสำหรับข้อความทั้งหมดในสไลด์ของพรีเซนเทชันใหม่

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

// รับรูปแบบย่อหน้าในระดับบนสุด.
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

ใน PowerPoint การใช้เอฟเฟกต์ **All Caps** ทำให้ข้อความปรากฏเป็นตัวพิมพ์ใหญ่ทั้งหมดบนสไลด์ แม้ว่าต้นฉบับจะพิมพ์เป็นตัวพิมพ์เล็กก็ตาม เมื่อคุณดึงส่วนข้อความดังกล่าวด้วย Aspose.Slides ไลบรารีจะคืนค่าข้อความตามที่พิมพ์ไว้เดิม เพื่อให้ตรงกับที่แสดงบนสไลด์ ให้ตรวจสอบ [TextCapType](https://reference.aspose.com/slides/th/cpp/aspose.slides/textcaptype/) และแปลงสตริงที่คืนค่ามาเป็นตัวพิมพ์ใหญ่เมื่อค่าเป็น [TextCapType::All](https://reference.aspose.com/slides/th/cpp/aspose.slides/textcaptype/)

สมมติว่าเรามีกล่องข้อความต่อไปนี้บนสไลด์แรกของไฟล์ sample2.pptx

![เอฟเฟกต์ All Caps](all_caps_effect.png)

โค้ดตัวอย่างด้านล่างแสดงวิธีสกัดข้อความที่มีเอฟเฟกต์ **All Caps** ถูกนำไปใช้:

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

## **คำถามที่พบบ่อย**

**จะแก้ไขข้อความในตารางบนสไลด์อย่างไร?**

เพื่อแก้ไขข้อความในตารางบนสไลด์ ให้ใช้ [ITable](https://reference.aspose.com/slides/th/cpp/aspose.slides/itable/) ทำการวนลูปผ่านเซลล์และอัปเดตแต่ละเซลล์ผ่าน [ICell::get_TextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/icell/get_textframe/) และจัดรูปแบบย่อหน้าผ่าน [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/get_paragraphformat/)

**จะทำอย่างไรให้ข้อความในสไลด์ PowerPoint มีสีไล่ระดับ?**

ให้ใช้ [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseportionformat/get_fillformat/) ตั้งค่า [IFillFormat::set_FillType](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifillformat/set_filltype/) เป็น [FillType::Gradient](https://reference.aspose.com/slides/th/cpp/aspose.slides/filltype/) แล้วกำหนดจุดหยุดไล่ระดับ, ทิศทาง, และความโปร่งใส