---
title: ค้นหาและแทนที่ข้อความในงานนำเสนอ PowerPoint ด้วย C++
linktitle: ค้นหาและแทนที่ข้อความ
type: docs
weight: 55
url: /th/cpp/search-and-replace-text/
keywords:
- ค้นหาข้อความ
- ไฮไลต์ข้อความ
- แทนที่ข้อความ
- นิพจน์ปกติ
- callback ผลลัพธ์
- กรอบข้อความ
- รายงานการตรวจสอบ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ค้นหา, ไฮไลต์, และแทนที่ข้อความในงานนำเสนอ PowerPoint พร้อมเก็บบันทึกการจับคู่ทุกรายการด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

Aspose.Slides for C++ สามารถค้นหา, ไฮไลต์และแทนที่ข้อความในกรอบข้อความเดี่ยวหรือทั่วทั้งงานนำเสนอได้ แต่ละการดำเนินการยังสามารถแจ้งแอปพลิเคชันเกี่ยวกับการจับคู่แต่ละรายการผ่านผล callback ทำให้สามารถอัปเดตงานนำเสนอพร้อมกับสร้างบันทึกการตรวจสอบที่ประกอบด้วยข้อความที่ตรงกัน, บริบท, ตำแหน่ง, กรอบข้อความและหมายเลขสไลด์ได้

ความสามารถเหล่านี้เป็นประโยชน์สำหรับการตรวจทาน, การลบข้อมูล, การตรวจสอบศัพท์, การทำความสะอาดเทมเพลตและกระบวนการทำรายงานอัตโนมัติ

ในตัวอย่างแรกด้านล่าง เราใช้ไฟล์ชื่อ “sample.pptx” ซึ่งมีกล่องข้อความเดียวบนสไลด์แรกด้วยข้อความต่อไปนี้:

![Sample text](sample_text.png)

## **เลือกขอบเขตการค้นหา**

ใช้เมธอดบน [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) เพื่อจำกัดการดำเนินการให้กับกรอบข้อความเดียว ใช้เมธอดบน [IPresentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/) เพื่อดำเนินการกับข้อความทั้งหมดที่ใช้ได้ในงานนำเสนอ

| การดำเนินการ | หนึ่งกรอบข้อความ | ทั้งงานนำเสนอ |
|---|---|---|
| ไฮไลต์ข้อความตามตัวอักษร | [ITextFrame::HighlightText](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/highlighttext/) |
| ไฮไลต์การจับคู่ตาม regular‑expression | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/highlightregex/) |
| แทนที่ข้อความตามตัวอักษร | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/replacetext/) |
| แทนที่การจับคู่ตาม regular‑expression | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/replaceregex/) |

## **กำหนดค่าการจับคู่ข้อความ**

สำหรับการดำเนินการที่ใช้ข้อความตามตัวอักษร ให้ใช้ [ITextSearchOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextsearchoptions/) เพื่อควบคุมการจับคู่:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) จำกัดการจับคู่ให้เป็นคำเต็มเท่านั้น
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) กำหนดว่าต้องตรงกับการพิมพ์ตัวอักษรหรือไม่
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextsearchoptions/set_includenotes/) รวมบันทึกสไลด์ในการค้นหา, แทนที่และไฮไลต์ระดับงานนำเสนอ

การดำเนินการที่ใช้ regular‑expression จะใช้ `System::Text::RegularExpressions::Regex` ดังนั้นกฎการจับคู่เช่นความไวต่อกรณีและขอบเขตคำจะกำหนดโดยนิพจน์และตัวเลือกของมัน

## **ระบุตัวเจ้าของของกรอบข้อความ**

กระบวนการประมวลผลข้อความทั่วไปมักได้รับ [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) ขณะค้นหา, แทนที่, ตรวจสอบหรือส่งออกข้อความ ใช้ [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/get_parentshape/) และ [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/get_parentcell/) เพื่อระบุว่าออบเจ็กต์งานนำเสนอใดเป็นเจ้าของกรอบข้อความนั้น

ค่าที่คาดหวังขึ้นอยู่กับเจ้าของ:

| เจ้าของกรอบข้อความ | `get_ParentShape` | `get_ParentCell` |
|---|---|---|
| AutoShape หรือรูปร่างที่บรรจุข้อความอื่น | [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) ที่เป็นเจ้าของ | `nullptr` |
| เซลล์ตาราง | `nullptr` | [ICell](https://reference.aspose.com/slides/th/cpp/aspose.slides/icell/) ที่เป็นเจ้าของ |

เมธอดทั้งสองให้การนำทางแบบอ่านอย่างเดียว การเรียกใช้ไม่ได้เลื่อนกรอบข้อความหรือเปลี่ยนเจ้าของ โค้ดทั่วไปควรตรวจสอบค่าทั้งสองสำหรับ `nullptr` และจัดการกรณีที่ไม่มีเจ้าของใด ๆ อยู่

ตัวอย่างต่อไปนี้ใช้ [SlideUtil::GetAllTextFrames](https://reference.aspose.com/slides/th/cpp/aspose.slides.util/slideutil/getalltextframes/) เพื่อวนลูปกรอบข้อความในงานนำเสนอ สำหรับรูปร่าง จะรายงานชื่อรูปร่าง, ชนิดรันไทม์ C++ และสไลด์ที่บรรจุ สำหรับเซลล์ตาราง จะรายงานพิกัดคอลัมน์และแถวที่เริ่มจากศูนย์และสไลด์ที่บรรจุ

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::IShape;
using Aspose::Slides::ISlide;
using Aspose::Slides::ITextFrame;
using Aspose::Slides::Presentation;
using Aspose::Slides::Util::SlideUtil;
using System::AsCast;
using System::Console;
using System::MakeObject;
using System::String;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto textFrames = SlideUtil::GetAllTextFrames(presentation, false);

for (const auto& textFrame : textFrames)
{
    auto ownerShape = textFrame->get_ParentShape();
    if (ownerShape != nullptr)
    {
        auto shapeName = String::IsNullOrEmpty(ownerShape->get_Name()) ? u"(unnamed)" : ownerShape->get_Name();
        auto shapeType = ownerShape->GetType().get_Name();
        auto baseSlide = ownerShape->get_Slide();
        String slideLabel;
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            slideLabel = String::Format(u"slide {0}", slide->get_SlideNumber());
        }
        else
        {
            auto notesSlide = AsCast<INotesSlide>(baseSlide);
            if (notesSlide != nullptr)
            {
                slideLabel = String::Format(u"notes for slide {0}", notesSlide->get_ParentSlide()->get_SlideNumber());
            }
            else
            {
                slideLabel = baseSlide->GetType().get_Name();
            }
        }

        Console::WriteLine(u"Shape: {0}; type: {1}; {2}", shapeName, shapeType, slideLabel);
        continue;
    }

    auto ownerCell = textFrame->get_ParentCell();
    if (ownerCell != nullptr)
    {
        auto baseSlide = ownerCell->get_Slide();
        String slideLabel;
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            slideLabel = String::Format(u"slide {0}", slide->get_SlideNumber());
        }
        else
        {
            auto notesSlide = AsCast<INotesSlide>(baseSlide);
            if (notesSlide != nullptr)
            {
                slideLabel = String::Format(u"notes for slide {0}", notesSlide->get_ParentSlide()->get_SlideNumber());
            }
            else
            {
                slideLabel = baseSlide->GetType().get_Name();
            }
        }

        Console::WriteLine(u"Table cell: column {0}, row {1}; {2}", ownerCell->get_FirstColumnIndex(), ownerCell->get_FirstRowIndex(), slideLabel);
        continue;
    }

    Console::WriteLine(u"The text frame owner is not available as a shape or table cell.");
}
```

สำหรับเนื้อหา SmartArt ให้วนลูปรูปร่างใน [ISmartArtNode::get_Shapes](https://reference.aspose.com/slides/th/cpp/aspose.slides.smartart/ismartartnode/get_shapes/) แล้วเข้าถึงแต่ละ [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides.smartart/ismartartshape/get_textframe/) กรอบข้อความสามารถตามรอยไปยังรูปร่างที่เกี่ยวข้องผ่าน [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/get_parentshape/) ส่วน [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/get_parentcell/) จะคืนค่า `nullptr` ดังนั้นโค้ดสาขารูปร่างในตัวอย่างจึงจัดการข้อความจากโหนด SmartArt ด้วย

## **รวบรวมข้อมูลการจับคู่ด้วย Callback**

สร้างการใช้งาน [IFindResultCallback](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifindresultcallback/) เพื่อรับการแจ้งเตือนสำหรับการจับคู่แต่ละครั้ง เมธอด [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifindresultcallback/foundresult/) จะให้กรอบข้อความที่เกี่ยวข้อง, ข้อความต้นฉบับ, ข้อความที่ตรงกันและตำแหน่งการจับคู่

Callback ไม่ได้รับหมายเลขสไลด์โดยตรง การดำเนินการด้านล่างจะดึงมาจาก [ISlideComponent::get_Slide](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecomponent/get_slide/) และยังจัดการข้อความที่พบในบันทึกสไลด์ผ่าน [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/inotesslide/get_parentslide/) ด้วย ตัวเลขสไลด์ที่เป็น nullable ทำให้โมเดลผลลัพธ์เดียวกันสามารถแทนข้อความที่เชื่อมโยงกับประเภทสไลด์อื่นได้

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <IFindResultCallback.h>
#include <system/collections/list.h>
#include <system/nullable.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::IFindResultCallback;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::IShape;
using Aspose::Slides::ISlide;
using Aspose::Slides::ITextFrame;
using System::AsCast;
using System::MakeObject;
using System::Nullable;
using System::SharedPtr;
using System::String;
using System::Collections::Generic::List;

class TextMatch : public System::Object
{
public:
    TextMatch(SharedPtr<ITextFrame> textFrame, String sourceText, String foundText,
        int32_t textPosition, Nullable<int32_t> slideNumber)
        : TextFrame(textFrame), SourceText(sourceText), FoundText(foundText),
          TextPosition(textPosition), SlideNumber(slideNumber)
    {
    }

    SharedPtr<ITextFrame> TextFrame;
    String SourceText;
    String FoundText;
    int32_t TextPosition;
    Nullable<int32_t> SlideNumber;
};

class TextSearchCallback : public IFindResultCallback
{
public:
    TextSearchCallback()
        : Results(MakeObject<List<SharedPtr<TextMatch>>>())
    {
    }

    void FoundResult(SharedPtr<ITextFrame> textFrame, String sourceText,
        String foundText, int32_t textPosition) override
    {
        auto slideNumber = GetSlideNumber(textFrame);
        auto result = MakeObject<TextMatch>(textFrame, sourceText, foundText,
            textPosition, slideNumber);

        Results->Add(result);
    }

    SharedPtr<List<SharedPtr<TextMatch>>> Results;

private:
    static Nullable<int32_t> GetSlideNumber(SharedPtr<ITextFrame> textFrame)
    {
        auto parentShape = textFrame->get_ParentShape();
        auto parentCell = textFrame->get_ParentCell();
        SharedPtr<IBaseSlide> baseSlide;

        if (parentShape != nullptr)
        {
            baseSlide = parentShape->get_Slide();
        }
        else if (parentCell != nullptr)
        {
            baseSlide = parentCell->get_Slide();
        }
        else
        {
            baseSlide = textFrame->get_Slide();
        }

        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            return slide->get_SlideNumber();
        }

        auto notesSlide = AsCast<INotesSlide>(baseSlide);
        if (notesSlide != nullptr)
        {
            auto parentSlide = notesSlide->get_ParentSlide();
            return parentSlide->get_SlideNumber();
        }

        return nullptr;
    }
};
```

สำหรับการดำเนินการแทนที่ `FoundText` จะมีข้อความที่ตรงกันต้นฉบับ ดังนั้น callback สามารถบันทึกคำที่ถูกแทนที่ได้อย่างแม่นยำ

## **ไฮไลต์ข้อความ**

ใช้เมธอด [ITextFrame::HighlightText](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/highlighttext/) เพื่อไฮไลต์การจับคู่ข้อความตามตัวอักษรในกรอบข้อความ ส่งผ่าน [ITextSearchOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextsearchoptions/) เพื่อควบคุมการค้นหาและ callback เพื่อรวบรวมรายละเอียดการจับคู่

โค้ดตัวอย่างด้านล่างไฮไลต์ทุกการพบของอักขระ **"try"** แล้วตามด้วยการไฮไลต์เฉพาะคำเต็ม **"to"** ทั้งสองการค้นหาจะรายงานการจับคู่ให้ callback เดียวกัน

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// รับรูปร่างแรกจากสไลด์แรก.
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// ไฮไลต์ทุกการพบของ "try" ในกรอบข้อความ.
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// ไฮไลต์เฉพาะคำเต็ม "to".
shape->get_TextFrame()->HighlightText(
    u"to", System::Drawing::Color::get_Violet(), wholeWordSearchOptions, callback);

for (auto&& result : callback->Results)
{
    auto slideLabel = result->SlideNumber.get_HasValue()
        ? System::String::Format(u"{0}", result->SlideNumber.get_Value())
        : u"Other";

    System::Console::WriteLine(u"Found '{0}' at position {1} on slide {2}.",
        result->FoundText, result->TextPosition, slideLabel);
}

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![The highlighted text](highlighted_text.png)

## **ไฮไลต์ข้อความโดยใช้ Regular Expressions**

เมธอด [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/highlightregex/) จะไฮไลต์ข้อความที่ตรงกับ regular expression ในกรอบข้อความ

โค้ดต่อไปนี้ไฮไลต์ทุกคำที่มีอักขระเจ็ดตัวหรือมากกว่าและรวบรวมแต่ละการจับคู่:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();
auto regex = MakeObject<Regex>(u"\\b[^\\s]{7,}\\b");

shape->get_TextFrame()->HighlightRegex(
    regex, System::Drawing::Color::get_Yellow(), callback);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **ไฮไลต์ข้อความทั่วงานนำเสนอ**

ใช้ [IPresentation::HighlightText](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/highlighttext/) และ [IPresentation::HighlightRegex](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/highlightregex/) เพื่อค้นหากรอบข้อความที่ใช้ได้ทั้งหมดในงานนำเสนอ ตัวอย่างต่อไปนี้ไฮไลต์คำตามตัวอักษรและที่อยู่อีเมลทั้งหมดพร้อมแยกคอลเลกชันผลลัพธ์สำหรับการค้นหาแต่ละแบบ

```cpp
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>
#include <system/text/regularexpressions/regex_options.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;
using System::Text::RegularExpressions::RegexOptions;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto termCallback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(false);

presentation->HighlightText(
    u"confidential", System::Drawing::Color::get_Orange(), searchOptions, termCallback);

auto emailCallback = MakeObject<TextSearchCallback>();
auto emailRegex = MakeObject<Regex>(
    u"\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b", RegexOptions::IgnoreCase);

presentation->HighlightRegex(
    emailRegex, System::Drawing::Color::get_Yellow(), emailCallback);

presentation->Save(u"highlighted_presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **แทนที่ข้อความในกรอบข้อความ**

ใช้ [ITextFrame::ReplaceText](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/replacetext/) สำหรับข้อความตามตัวอักษรและ [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/replaceregex/) สำหรับการแทนที่ตามแบบแผน เมธอดเหล่านี้อัปเดตข้อความที่ตรงกันภายในกรอบข้อความเดิม ซึ่งรักษาการฟอร์แมตส่วนที่อยู่รอบ ๆ แทนการสร้างกรอบข้อความใหม่จากสตริงธรรมดา

ตัวอย่างต่อไปนี้ทำให้ตัวสะกดแบบต่าง ๆ เป็นมาตรฐานแล้วแทนที่ป้ายรุ่น ผล callback เดียวกันบันทึกคำต้นฉบับที่ตรงกันจากทั้งสองการดำเนินการ

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>
#include <system/text/regularexpressions/regex_options.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;
using System::Text::RegularExpressions::RegexOptions;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(false);

shape->get_TextFrame()->ReplaceText(u"colour", u"color", searchOptions, callback);

auto versionRegex = MakeObject<Regex>(
    u"\\bv\\d+(?:\\.\\d+)*\\b", RegexOptions::IgnoreCase);
shape->get_TextFrame()->ReplaceRegex(versionRegex, u"current version", callback);

presentation->Save(u"updated_text_frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

หากการจับคู่หนึ่งครอบคลุมส่วนที่มีฟอร์แมตต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อยืนยันว่าฟอร์แมตที่ใช้สำหรับข้อความแทนที่เป็นอย่างไร

## **แทนที่ข้อความทั่วงานนำเสนอ**

ใช้ [IPresentation::ReplaceText](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/replacetext/) และ [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/replaceregex/) เพื่อทำการเดียวกันทั่วทั้งงานนำเสนอ สิ่งนี้เป็นประโยชน์สำหรับการทำความสะอาดเทมเพลต, การอัปเดตศัพท์และการลบข้อมูล

```cpp
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto callback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);

presentation->ReplaceText(u"Contoso", u"Example Corp", searchOptions, callback);

auto accountNumberRegex = MakeObject<Regex>(u"\\bACCT-\\d{6}\\b");
presentation->ReplaceRegex(accountNumberRegex, u"ACCT-REDACTED", callback);

presentation->Save(u"updated_presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **จัดกลุ่มการจับคู่เพื่อการรายงาน**

เพราะผลลัพธ์แต่ละรายการเก็บหมายเลขสไลด์และกรอบข้อความไว้ แอปพลิเคชันจึงสามารถจัดกลุ่มการจับคู่สำหรับการตรวจสอบ, การรายงานหรือกระบวนการรีวิว ตัวอย่างต่อไปนี้จัดกลุ่มผลลัพธ์ที่รวบรวมได้ก่อนตามสไลด์แล้วตามกรอบข้อความ

```cpp
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <system/string.h>
#include <map>
#include <vector>

std::map<int32_t, std::map<Aspose::Slides::ITextFrame*,
    std::vector<System::SharedPtr<TextMatch>>>> matchesBySlide;

for (auto&& result : callback->Results)
{
    int32_t slideKey = result->SlideNumber.get_HasValue()
        ? result->SlideNumber.get_Value()
        : 0;
    auto textFrameKey = result->TextFrame.get();

    matchesBySlide[slideKey][textFrameKey].push_back(result);
}

for (const auto& slideGroup : matchesBySlide)
{
    auto slideLabel = slideGroup.first == 0
        ? System::String(u"Other")
        : System::String::Format(u"{0}", slideGroup.first);
    System::Console::WriteLine(u"Slide: {0}", slideLabel);

    for (const auto& textFrameGroup : slideGroup.second)
    {
        auto textFrameText = textFrameGroup.first->get_Text();
        System::Console::WriteLine(u"  Text frame: {0}", textFrameText);

        for (const auto& result : textFrameGroup.second)
        {
            System::Console::WriteLine(
                u"    '{0}' at position {1}; context: '{2}'",
                result->FoundText, result->TextPosition, result->SourceText);
        }
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันจะค้นหาเฉพาะกล่องข้อความหนึ่งแทนที่จะค้นทั่วทั้งงานนำเสนอได้อย่างไร?**

รับกรอบข้อความของรูปทรงและเรียกใช้ [ITextFrame::HighlightText](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/replacetext/) หรือ [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/replaceregex/) บนกรอบข้อความนั้น เมธอดระดับงานนำเสนอจะดำเนินการกับกรอบข้อความทั้งหมดที่ใช้ได้แทน

**ฉันจะจับคู่คำเต็มพร้อมการใช้ตัวพิมพ์ใหญ่‑เล็กที่ถูกต้องได้อย่างไร?**

เรียก [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) และ [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) พร้อมค่า `true` แล้วส่งตัวเลือกไปยังเมธอดไฮไลต์หรือแทนที่ข้อความตามตัวอักษร สำหรับ regular expression ให้กำหนดขอบเขตคำและความไวต่อกรณีใน `System::Text::RegularExpressions::Regex` เอง

**การค้นหาและการแทนที่สามารถรวมข้อความในบันทึกสไลด์ได้หรือไม่?**

ได้ เรียก [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextsearchoptions/set_includenotes/) พร้อมค่า `true` เมื่อใช้การดำเนินการข้อความตามตัวอักษรระดับงานนำเสนอ Callback implementation ที่แสดงข้างต้นจะจับคู่บันทึกสไลด์กลับไปยังหมายเลขสไลด์แม่

**ฉันจะสร้างรายงานโดยไม่ต้องสแกนงานนำเสนอครั้งที่สองได้อย่างไร?**

ส่งการใช้งาน [IFindResultCallback](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifindresultcallback/) ไปยังการไฮไลต์หรือการแทนที่ Callback จะรับการจับคู่ทุกครั้งขณะดำเนินการ ทำให้แอปพลิเคชันสามารถจัดเก็บข้อความต้นฉบับ, ข้อความที่ตรงกัน, ตำแหน่ง, กรอบข้อความและหมายเลขสไลด์ที่ได้มาสำหรับการจัดกลุ่มหรือการส่งออกในภายหลัง

**การแทนที่ข้อความจะรักษาการฟอร์แมตไว้หรือไม่?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/replacetext/) และ [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/replaceregex/) จะแก้ไขข้อความที่ตรงกันภายในกรอบข้อความที่มีอยู่และรักษาการฟอร์แมตของส่วนที่อยู่รอบ ๆ หากการจับคู่ครอบคลุมส่วนที่มีฟอร์แมตต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อให้แน่ใจว่าการแทนที่ใช้สไตล์ที่ต้องการ