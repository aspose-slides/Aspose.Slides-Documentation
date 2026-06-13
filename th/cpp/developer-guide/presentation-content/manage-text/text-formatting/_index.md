---
title: จัดรูปแบบข้อความการนำเสนอใน C++
linktitle: การจัดรูปแบบข้อความ
type: docs
weight: 50
url: /th/cpp/text-formatting/
keywords:
- เน้นข้อความ
- นิพจน์ปกติ
- จัดย่อหน้า
- สไตล์ข้อความ
- พื้นหลังข้อความ
- ความโปร่งใสของข้อความ
- ระยะห่างอักขระ
- คุณสมบัติแบบอักษร
- ตระกูลแบบอักษร
- การหมุนข้อความ
- มุมการหมุน
- กรอบข้อความ
- ระยะห่างบรรทัด
- คุณสมบัติการปรับอัตโนมัติ
- การยึดกรอบข้อความ
- การทำแท็บของข้อความ
- ภาษาเริ่มต้น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "จัดรูปแบบและสไตล์ข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ C++. ปรับแต่งแบบอักษร, สี, การจัดแนว และอื่น ๆ อีกมากมาย."
---
## **ภาพรวม**

บทความนี้แสดงวิธีจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ C++. ครอบคลุมการเน้นสี, สีพื้นหลัง, ความโปร่งใส, ระยะห่างระหว่างอักขระ, คุณสมบัติของแบบอักษร, การหมุน, ระยะห่างของย่อหน้า, การทำอัตโนมัติให้พอดี, การยึดตำแหน่งข้อความ, ตำแหน่งแท็บ, และการตั้งค่าภาษา  

ในตัวอย่างต่อไปนี้ เราจะใช้ไฟล์ชื่อ “sample.pptx” ซึ่งมีกล่องข้อความเดียวบนสไลด์แรกพร้อมข้อความต่อไปนี้:

![ข้อความตัวอย่าง](sample_text.png)

## **เน้นข้อความ**

ใช้เมธอด [ITextFrame.HighlightText](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/highlighttext/) เมื่อคุณต้องการเน้นข้อความที่ตรงกับตัวอย่างเฉพาะภายใน Text Frame เมธอดนี้จะใส่สีเน้นให้กับส่วนข้อความที่ตรงกันและสามารถใช้ร่วมกับ [ITextSearchOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextsearchoptions/) เพื่อควบคุมวิธีการค้นหา เช่น ให้จับคู่อย่คำเต็มเท่านั้น  

ตัวอย่างโค้ดด้านล่างจะแสดงการเน้นทุกการปรากฏของอักขระ **"try"** และจากนั้นจะเน้นเฉพาะคำเต็ม **"to"**.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

// รับรูปร่างแรกจากสไลด์แรก.
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// เน้นคำ "try" ในรูปร่าง.
shape->get_TextFrame()->HighlightText(u"try", System::Drawing::Color::get_LightBlue());

auto searchOptions = System::MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);

// เน้นคำ "to" ในรูปร่าง.
shape->get_TextFrame()->HighlightText(u"to", System::Drawing::Color::get_Violet(), searchOptions, nullptr);

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![ข้อความที่เน้น](highlighted_text.png)

## **เน้นข้อความด้วยนิพจน์ปกติ**

เมธอด [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/highlightregex/) จะเน้นผลการจับคู่ข้อความที่พบโดยใช้นิพจน์ปกติ ใน C++ API นี้เปิดให้ใช้งานผ่าน [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/)  

ตัวอย่างโค้ดด้านล่างจะแสดงการเน้นทุกคำที่มี **เจ็ดอักขระหรือมากกว่า**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto regex = System::MakeObject<System::Text::RegularExpressions::Regex>(u"\\b[^\\s]{7,}\\b");

// Highlight all words with seven or more characters.
shape->get_TextFrame()->HighlightRegex(regex, System::Drawing::Color::get_Yellow(), nullptr);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![ข้อความที่เน้นด้วยนิพจน์ปกติ](highlighted_text_using_regex.png)

## **ตั้งค่าสีพื้นหลังของข้อความ**

ใช้ [IParagraphFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` เพื่อตั้งค่าสีเน้นเริ่มต้นสำหรับย่อหน้า หรือใช้ [IPortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportionformat/)`.HighlightColor` สำหรับส่วนข้อความแยกทีละส่วน  

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ย่อหน้าทั้งหมด**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// ตั้งค่าสีเน้นสำหรับย่อหน้าทั้งหมด.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![ย่อหน้าสีเทา](gray_paragraph.png)

ตัวอย่างโค้ดด้านล่างสาธิตวิธีตั้งค่าสีพื้นหลังสำหรับ **ส่วนข้อความที่ใช้แบบอักษรหนา**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // ตั้งค่าสีเน้นสำหรับส่วนข้อความ.
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![ส่วนข้อความสีเทา](gray_text_portions.png)

## **จัดตำแหน่งย่อหน้าข้อความ**

ใช้ [IParagraphFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/)`.Alignment` เพื่อกำหนดการจัดแนวของย่อหน้าใน Text Frame ค่าอาจเป็นกึ่งกลาง, ชิดซ้าย, ชิดขวา, จัดชิดทั้งสองข้าง ฯลฯ  

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีจัดแนวย่อหน้าให้อยู่ที่ **กึ่งกลาง**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// ตั้งค่าการจัดแนวของย่อหน้าให้เป็นกึ่งกลาง.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![ย่อหน้าที่จัดแนวกึ่งกลาง](aligned_paragraph.png)

## **ตั้งค่าความโปร่งใสของข้อความ**

ความโปร่งใสของข้อความถูกควบคุมผ่านส่วนประกอบอัลฟาของสีที่กำหนดให้กับ [IPortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportionformat/)`.FillFormat`. ในตัวอย่างต่อไปนี้ `alpha = 50` คือค่าช่องอัลฟา ARGB บนสเกล 0‑255 ไม่ใช่เปอร์เซ็นต์ความโปร่งใส  

ตัวอย่างโค้ดด้านล่างแสดงวิธีใช้ความโปร่งใสกับ **ย่อหน้าทั้งหมด**:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Set the fill color of the text to transparent color.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![ย่อหน้าที่โปร่งใส](transparent_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้ความโปร่งใสกับ **ส่วนข้อความที่ใช้แบบอักษรหนา**:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // ตั้งค่าความโปร่งใสของส่วนข้อความ.
        portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
        portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![ส่วนข้อความที่โปร่งใส](transparent_text_portions.png)

## **ตั้งค่าระยะห่างอักขระสำหรับข้อความ**

ใช้ [IBasePortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseportionformat/)`.Spacing` เพื่อขยายหรือบีบระยะห่างระหว่างอักขระในกล่องข้อความ  

โค้ด C++ ต่อไปนี้แสดงวิธีเพิ่มระยะห่างอักขระใน **ย่อหน้าทั้งหมด**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// หมายเหตุ: ใช้ค่าติดลบเพื่อบีบอัดระยะห่างระหว่างอักขระ.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f);

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![ระยะห่างอักขระในย่อหน้า](character_spacing_in_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีเพิ่มระยะห่างอักขระใน **ส่วนข้อความที่ใช้แบบอักษรหนา**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // หมายเหตุ: ใช้ค่าติดลบเพื่อบีบอัดระยะห่างระหว่างอักขระ.
        portion->get_PortionFormat()->set_Spacing(3.0f);
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![ระยะห่างอักขระในส่วนข้อความ](character_spacing_in_text_portions.png)

### **ปิดการทำเคอร์นนิงสำหรับแบบอักษรเฉพาะ**

ในบางกรณี ข้อความที่เรนเดอร์โดย Aspose.Slides อาจดูแคบกว่าข้อความเดียวกันที่แสดงใน PowerPoint นั่นอาจเกิดจาก PowerPoint เพิกเฉยข้อมูลเคอร์นนิงของแบบอักษรบางประเภท แม้ว่าแบบอักษรจะมีข้อมูลเคอร์นนิงที่ถูกต้องและเคอร์นนิงถูกเปิดใช้งานในการตั้งค่า PowerPoint  

เพื่อให้ผลลัพธ์ที่เรนเดอร์ใกล้เคียงกับ PowerPoint มากขึ้น คุณสามารถปิดการทำเคอร์นนิงสำหรับส่วนข้อความที่ใช้แบบอักษรที่ได้รับผลกระทบได้โดยกำหนดค่า [IPortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportionformat/)`.KerningMinimalSize` เป็นค่าที่ใหญ่กว่าขนาดแบบอักษรจริงอย่างมีนัยสำคัญ:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
System::String targetFont = u"Roboto";
auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
int paragraphCount = paragraphs->get_Count();

for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = paragraphs->idx_get(paragraphIndex);
    auto portions = paragraph->get_Portions();
    int portionCount = portions->get_Count();

    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = portions->idx_get(portionIndex);
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

การตั้งค่านี้จะป้องกันการทำเคอร์นนิงกับส่วนข้อความที่ตรงกันและช่วยให้การเรนเดอร์ของ Aspose.Slides สอดคล้องกับการแสดงผลของ PowerPoint สำหรับแบบอักษรที่ได้รับผลกระทบจากพฤติกรรมเฉพาะของ PowerPoint นี้

## **จัดการคุณสมบัติแบบอักษรของข้อความ**

คุณสมบัติของแบบอักษรสามารถตั้งค่าได้ระดับย่อหน้าผ่าน [IParagraphFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` หรือบนแต่ละส่วนผ่าน [IPortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportionformat/)  

โค้ดต่อไปนี้ตั้งค่าแบบอักษรและสไตล์ข้อความสำหรับ **ย่อหน้าทั้งหมด**: จะกำหนดขนาดฟอนต์, ตัวหนา, ตัวเอียง, การขีดเส้นใต้เป็นจุด และฟอนต์ Times New Roman ให้กับทุกส่วนในย่อหน้า

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// ตั้งค่าคุณสมบัติแบบอักษรสำหรับย่อหน้า.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
defaultPortionFormat->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![คุณสมบัติแบบอักษรของย่อหน้า](font_properties_for_paragraph.png)

ตัวอย่างโค้ดด้านล่างใช้คุณสมบัติเช่นเดียวกันกับ **ส่วนข้อความที่ใช้แบบอักษรหนา**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // ตั้งค่าคุณสมบัติแบบอักษรสำหรับส่วนข้อความ.
        portion->get_PortionFormat()->set_FontHeight(13.0f);
        portion->get_PortionFormat()->set_FontItalic(NullableBool::True);
        portion->get_PortionFormat()->set_FontUnderline(TextUnderlineType::Dotted);
        portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![คุณสมบัติแบบอักษรของส่วนข้อความ](font_properties_for_text_portions.png)

## **ตั้งค่าการหมุนข้อความ**

ใช้ [ITextFrameFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformat/)`.TextVerticalType` เพื่อกำหนดการวางแนวข้อความล่วงหน้าภายในรูปร่าง  

ตัวอย่างโค้ดต่อไปนี้ตั้งค่าการวางแนวข้อความในรูปร่างเป็น `Vertical270` ซึ่งจะหมุนข้อความ **90 องศาตรงทวนเข็มนาฬิกา**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![การหมุนข้อความ](text_rotation.png)

## **ตั้งค่าการหมุนแบบกำหนดเองสำหรับ Text Frame**

ใช้ [ITextFrameFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformat/)`.RotationAngle` เพื่อกำหนดมุมหมุนที่กำหนดเองสำหรับ [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/)  

ตัวอย่างโค้ดด้านล่างหมุน Text Frame ไป 3 องศาตามเข็มนาฬิกาในรูปร่าง:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![การหมุนข้อความแบบกำหนดเอง](custom_text_rotation.png)

## **ตั้งค่าระยะห่างบรรทัดของย่อหน้า**

Aspose.Slides มี [IParagraphFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/)`.SpaceAfter`, `IParagraphFormat.SpaceBefore`, และ `IParagraphFormat.SpaceWithin` เพื่อควบคุมระยะห่างของย่อหน้า คุณสมบัติเหล่านี้ใช้ดังนี้  

* ใช้ค่าบวกเพื่อระบุระยะห่างบรรทัดเป็นเปอร์เซ็นต์ของความสูงบรรทัด  
* ใช้ค่าลบเพื่อระบุระยะห่างบรรทัดเป็นจุด  

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีระบุระยะห่างบรรทัดภายในย่อหน้า:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![ระยะห่างบรรทัดในย่อหน้า](line_spacing.png)

## **ตั้งค่าชนิด Autofit สำหรับ Text Frame**

[ITextFrameFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformat/)`.AutofitType` กำหนดวิธีที่ข้อความทำงานเมื่อเกินขอบเขตของคอนเทนเนอร์ ใช้เพื่อควบคุมว่าข้อความจะหด, ล้น, หรือปรับขนาดรูปร่างโดยอัตโนมัติ

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ตั้งค่าการยึดตำแหน่งของ Text Frame**

[ITextFrameFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformat/)`.AnchoringType` กำหนดว่าข้อความจะถูกวางในแนวตั้งอย่างไรภายในรูปร่าง เช่น ที่ด้านบน, กลาง, หรือด้านล่าง

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ตั้งค่าการทำแท็บของข้อความ**

ใช้ [IParagraphFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/)`.DefaultTabSize` และ `IParagraphFormat.Tabs` เพื่อกำหนดตำแหน่งแท็บในย่อหน้า  

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![แท็บของย่อหน้า](paragraph_tabs.png)

## **ตั้งค่าภาษาการตรวจสอบ**

Aspose.Slides มี [IPortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportionformat/)`.LanguageId` ให้คุณตั้งค่าภาษาการตรวจสอบสำหรับส่วนข้อความ ภาษาการตรวจสอบกำหนดภาษาที่ใช้สำหรับการตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint  

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่าภาษาการตรวจสอบสำหรับส่วนข้อความ:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto font = System::MakeObject<FontData>(u"SimSun");

auto textPortion = System::MakeObject<Portion>();
textPortion->get_PortionFormat()->set_ComplexScriptFont(font);
textPortion->get_PortionFormat()->set_EastAsianFont(font);
textPortion->get_PortionFormat()->set_LatinFont(font);

// ตั้งค่า Id ของภาษาการตรวจสอบ.
textPortion->get_PortionFormat()->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ตั้งค่าภาษาเริ่มต้น**

ใช้ [ILoadOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/iloadoptions/)`.DefaultTextLanguage` เพื่อกำหนดภาษาปริยายสำหรับข้อความที่สร้างขณะโหลดหรือสร้างงานนำเสนอ

```cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// เพิ่มรูปสี่เหลี่ยมใหม่พร้อมข้อความ.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// ตรวจสอบภาษาของส่วนข้อความแรก.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
System::Console::WriteLine(portion->get_PortionFormat()->get_LanguageId());

presentation->Dispose();
```

## **ตั้งค่าสไตล์ข้อความเริ่มต้น**

เพื่อใช้การฟอร์แมตข้อความเริ่มต้นระดับงานนำเสนอ ให้ใช้ [IPresentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/)`.DefaultTextStyle`  

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่าแบบอักษรหน้าปริยายขนาด 14 pt สำหรับข้อความทั้งหมดในสไลด์ของงานนำเสนอใหม่

```cpp
auto presentation = System::MakeObject<Presentation>();

// รับรูปแบบย่อหน้าระดับบนสุด.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14.0f);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **สกัดข้อความด้วยเอฟเฟกต์ All-Caps**

ใน PowerPoint การใช้เอฟเฟกต์ **All Caps** ทำให้ข้อความแสดงเป็นตัวพิมพ์ใหญ่บนสไลด์ แม้ว่าจะพิมพ์เป็นตัวเล็กก่อนหน้า เมื่อคุณดึงส่วนข้อความเช่นนั้นด้วย Aspose.Slides ไลบรารีจะคืนค่าข้อความตามที่พิมพ์ไว้เพื่อให้ตรงกับข้อความที่แสดง ให้ตรวจสอบ [TextCapType](https://reference.aspose.com/slides/th/cpp/aspose.slides/textcaptype/) และแปลงสตริงที่คืนค่าเป็นตัวพิมพ์ใหญ่เมื่อค่าเป็น `All`  

สมมติว่าเรามีกล่องข้อความต่อไปนี้บนสไลด์แรกของไฟล์ sample2.pptx

![เอฟเฟกต์ All Caps](all_caps_effect.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีสกัดข้อความที่มีเอฟเฟกต์ **All Caps** ถูกนำไปใช้:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample2.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

System::Console::WriteLine(u"Original text: " + textPortion->get_Text());

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto text = textPortion->get_Text().ToUpper();
    System::Console::WriteLine(u"All-Caps effect: " + text);
}

presentation->Dispose();
```

ผลลัพธ์:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **คำถามที่พบบ่อย**

**วิธีแก้ไขข้อความในตารางบนสไลด์?**

เพื่อแก้ไขข้อความในตารางบนสไลด์ ให้ใช้ [ITable](https://reference.aspose.com/slides/th/cpp/aspose.slides/itable/). วนลูปผ่านเซลล์และอัปเดตแต่ละเซลล์ผ่าน [ICell](https://reference.aspose.com/slides/th/cpp/aspose.slides/icell/)`.TextFrame` พร้อมการจัดรูปแบบย่อหน้าผ่าน [IParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/)`.ParagraphFormat`  

**วิธีใช้สีไล่ระดับบนข้อความในสไลด์ PowerPoint?**

เพื่อใช้สีไล่ระดับบนข้อความ ให้ใช้ [IPortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportionformat/)`.FillFormat`. ตั้งค่า [IFillFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifillformat/)`.FillType` เป็น [FillType](https://reference.aspose.com/slides/th/cpp/aspose.slides/filltype/)`.Gradient` แล้วกำหนดจุดไล่ระดับ, ทิศทาง, และความโปร่งใส.