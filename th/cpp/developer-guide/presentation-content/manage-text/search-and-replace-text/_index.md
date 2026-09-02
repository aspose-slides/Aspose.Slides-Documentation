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
- นิพจน์ทั่วไป
- result callback
- กรอบข้อความ
- รายงานการตรวจสอบ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ค้นหา, ไฮไลต์, และแทนที่ข้อความในงานนำเสนอ PowerPoint พร้อมเก็บบันทึกทุกผลลัพธ์ด้วย Aspose.Slides for C++."
---
## **ภาพรวม**

Aspose.Slides for C++ สามารถค้นหา ไฮไลต์ และแทนที่ข้อความในกรอบข้อความเดี่ยวหรือทั่วทั้งงานนำเสนอได้ แต่ละการดำเนินการยังสามารถแจ้งให้แอปพลิเคชันทราบเกี่ยวกับแต่ละผลลัพธ์ผ่าน result callback ซึ่งทำให้สามารถอัปเดตงานนำเสนอและสร้างบันทึกการตรวจสอบที่บรรจุข้อความที่ตรงกัน, บริบท, ตำแหน่ง, กรอบข้อความ และหมายเลขสไลด์ได้พร้อมกัน

ความสามารถเหล่านี้มีประโยชน์สำหรับการตรวจทาน, การลบข้อมูล, การตรวจสอบคำศัพท์, การทำความสะอาดเทมพลต, และเวิร์กโฟลว์การรายงานอัตโนมัติ

ในตัวอย่างแรกด้านล่าง เราใช้ไฟล์ชื่อ “sample.pptx” ซึ่งมีกล่องข้อความเดียวบนสไลด์แรกพร้อมข้อความต่อไปนี้:

![ข้อความตัวอย่าง](sample_text.png)

## **เลือกขอบเขตการค้นหา**

ใช้เมธอดบน[ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/)เพื่อจำกัดการดำเนินการให้กับกรอบข้อความหนึ่งกรอบ ใช้เมธอดบน[IPresentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/)เพื่อประมวลผลข้อความทั้งหมดที่เกี่ยวข้องในงานนำเสนอ

| การดำเนินการ | กรอบข้อความเดียว | งานนำเสนอทั้งหมด |
|---|---|---|
| ไฮไลต์ข้อความตามตัวอักษร | [ITextFrame::HighlightText](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/highlighttext/) |
| ไฮไลต์ผลการจับคู่แบบ regular‑expression | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/highlightregex/) |
| แทนที่ข้อความตามตัวอักษร | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/replacetext/) |
| แทนที่ผลการจับคู่แบบ regular‑expression | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/replaceregex/) |

## **กำหนดค่าการจับคู่ข้อความ**

สำหรับการดำเนินการข้อความตามตัวอักษร ให้ใช้[ITextSearchOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextsearchoptions/)เพื่อควบคุมการจับคู่:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) จำกัดผลลัพธ์ให้ตรงกับคำเต็มเท่านั้น
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) กำหนดว่าต้องตรงกับตัวอักษรพิมพ์ใหญ่‑พิมพ์เล็กหรือไม่
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextsearchoptions/set_includenotes/) รวมสไลด์โน้ตในการค้นหา, แทนที่, และไฮไลต์ระดับงานนำเสนอ

การดำเนินการแบบ regular‑expression ใช้ `System::Text::RegularExpressions::Regex` ดังนั้นกฎการจับคู่เช่นความไวต่อกรณีและขอบเขตคำจะกำหนดโดยนิพจน์และตัวเลือกของมัน

## **รวบรวมข้อมูลการจับคู่ด้วย Callback**

ใช้งาน[IFFindResultCallback](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifindresultcallback/)เพื่อรับการแจ้งเตือนเมื่อพบผลลัพธ์แต่ละรายการ เมธอด[IFindResultCallback::FoundResult](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifindresultcallback/foundresult/) จะให้กรอบข้อความที่เกี่ยวข้อง, ข้อความต้นทาง, ข้อความที่ตรงกัน, และตำแหน่งของการจับคู่

Callback ไม่ได้รับหมายเลขสไลด์โดยตรง การดำเนินการด้านล่างได้สกัดหมายเลขสไลด์จาก[ISlideComponent::get_Slide](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecomponent/get_slide/) และยังจัดการข้อความที่พบในสไลด์โน้ตผ่าน[INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/inotesslide/get_parentslide/) หมายเลขสไลด์ที่เป็นค่า null ทำให้โมเดลผลลัพธ์เดียวกันสามารถแทนข้อความที่เชื่อมโยงกับสไลด์ประเภทอื่นได้

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <IFindResultCallback.h>
#include <system/collections/list.h>
#include <system/nullable.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::IFindResultCallback;
using Aspose::Slides::INotesSlide;
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
        SharedPtr<IBaseSlide> baseSlide = textFrame->get_Slide();
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

สำหรับการดำเนินการแทนที่ `FoundText` จะมีข้อความต้นฉบับที่ตรงกัน จึงทำให้ callback สามารถบันทึกได้ว่าคำใดบ้างที่ถูกแทนที่

## **ไฮไลต์ข้อความ**

ใช้เมธอด[ITextFrame::HighlightText](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/highlighttext/)เพื่อไฮไลต์ผลการจับคู่ข้อความตามตัวอักษรในกรอบข้อความ ส่ง[ITextSearchOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextsearchoptions/)เพื่อควบคุมการค้นหาและส่ง callback เพื่อรวบรวมรายละเอียดผลลัพธ์

โค้ดตัวอย่างด้านล่างไฮไลต์ทุกการปรากฏของอักษร **"try"** แล้วจึงไฮไลต์เฉพาะคำเต็ม **"to"** ทั้งสองการค้นหาจะส่งผลลัพธ์ไปยัง callback เดียวกัน

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

// Get the first shape from the first slide.
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// Highlight every occurrence of "try" in the text frame.
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// Highlight only the complete word "to".
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

![ข้อความที่ไฮไลต์](highlighted_text.png)

## **ไฮไลต์ข้อความโดยใช้ Regular Expressions**

เมธอด[ITextFrame::HighlightRegex](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/highlightregex/)จะไฮไลต์ผลการจับคู่ข้อความที่พบโดย regular expression ในกรอบข้อความ

โค้ดต่อไปนี้ไฮไลต์ทุกคำที่มีความยาวเจ็ดอักขระหรือมากกว่าและรวบรวมผลลัพธ์แต่ละรายการ

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

![ข้อความที่ไฮไลต์โดยใช้ regular expression](highlighted_text_using_regex.png)

## **ไฮไลต์ข้อความทั่วงานนำเสนอ**

ใช้[IPresentation::HighlightText](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/highlighttext/)และ[IPresentation::HighlightRegex](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/highlightregex/)เพื่อค้นหากรอบข้อความทั้งหมดที่เกี่ยวข้องในงานนำเสนอ ตัวอย่างต่อไปนี้ไฮไลต์คำตามตัวอักษรและที่อยู่อีเมลทั้งหมด พร้อมแยกเก็บผลลัพธ์ของการค้นหาแต่ละรายการ

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

ใช้[ITextFrame::ReplaceText](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/replacetext/)สำหรับข้อความตามตัวอักษรและ[ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/replaceregex/)สำหรับการแทนที่ตามรูปแบบ เมธอดเหล่านี้อัปเดตข้อความที่ตรงกันภายในกรอบข้อความที่มีอยู่ ซึ่งจะคงการจัดรูปแบบส่วนที่อยู่รอบ ๆ แทนการสร้างกรอบข้อความใหม่จากสตริงธรรมดา

ตัวอย่างต่อไปนี้ทำให้รูปแบบการสะกดสอดคล้องแล้วแทนที่ป้ายเวอร์ชัน โดยใช้ callback เดียวกันเพื่อบันทึกคำต้นฉบับที่ตรงกับทั้งสองการดำเนินการ

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

หากผลการจับคู่หนึ่งครอบคลุมส่วนที่มีการจัดรูปแบบต่างกัน โปรดตรวจสอบผลลัพธ์เพื่อยืนยันว่าการจัดรูปแบบใดควรใช้กับข้อความที่แทนที่

## **แทนที่ข้อความทั่วงานนำเสนอ**

ใช้[IPresentation::ReplaceText](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/replacetext/)และ[IPresentation::ReplaceRegex](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/replaceregex/)เพื่อดำเนินการเดียวกันทั่วงานนำเสนอ สิ่งนี้มีประโยชน์สำหรับการทำความสะอาดเทมพลต, การอัปเดตคำศัพท์, และการลบข้อมูล

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

## **จัดกลุ่มผลลัพธ์สำหรับการรายงาน**

เนื่องจากผลลัพธ์ทุกรายการเก็บหมายเลขสไลด์และกรอบข้อความไว้ แอปพลิเคชันจึงสามารถจัดกลุ่มผลลัพธ์เพื่อการตรวจสอบ, รายงาน, หรือเวิร์กโฟลว์การรีวิว ตัวอย่างต่อไปนี้จัดกลุ่มผลลัพธ์ที่รวบรวมไว้ตามสไลด์แล้วตามกรอบข้อความ

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

## **FAQ**

**ฉันจะค้นหาในกล่องข้อความเดียวแทนการค้นหาทั้งหมดในงานนำเสนอได้อย่างไร?**

ดึงกรอบข้อความของรูปร่างและเรียก[ITextFrame::HighlightText](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/replacetext/), หรือ[ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/replaceregex/)บนกรอบข้อความนั้น เมธอดระดับงานนำเสนอจะดำเนินการกับกรอบข้อความทั้งหมดที่เกี่ยวข้องแทน

**ฉันจะจับคู่คำเต็มพร้อมการจัดการตัวอักษรให้ตรงตามแบบอย่างได้อย่างไร?**

เรียก[ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/)และ[ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextsearchoptions/set_casesensitive/)พร้อมค่า `true` และส่งตัวเลือกเหล่านั้นไปยังเมธอดไฮไลต์หรือแทนที่ข้อความตามตัวอักษร สำหรับ regular expression ให้กำหนดขอบเขตคำและความไวต่อกรณีใน `System::Text::RegularExpressions::Regex` เอง

**การค้นหาและแทนที่สามารถรวมข้อความในสไลด์โน้ตได้หรือไม่?**

ทำได้ ให้เรียก[ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextsearchoptions/set_includenotes/)พร้อมค่า `true` เมื่อใช้การดำเนินการข้อความตามตัวอักษรระดับงานนำเสนอ Callback ที่แสดงในตัวอย่างข้างต้นจะแมปผลลัพธ์ในสไลด์โน้ตกลับไปยังหมายเลขสไลด์หลัก

**ฉันจะสร้างรายงานโดยไม่ต้องสแกนงานนำเสนออีกครั้งได้อย่างไร?**

ส่งการทำงานของ[IFindResultCallback](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifindresultcallback/)ไปยังการไฮไลต์หรือแทนที่ Callback จะรับผลลัพธ์ทุกรายการในขณะดำเนินการ ทำให้แอปพลิเคชันสามารถบันทึกข้อความต้นทาง, ข้อความที่ตรงกัน, ตำแหน่ง, กรอบข้อความ, และหมายเลขสไลด์ที่สรุปได้สำหรับการจัดกลุ่มหรือส่งออกในภายหลัง

**การแทนที่ข้อความทำให้การจัดรูปแบบของข้อความคงอยู่หรือไม่?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/replacetext/)และ[ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/replaceregex/)แก้ไขข้อความที่ตรงกันภายในกรอบข้อความที่มีอยู่และคงการจัดรูปแบบส่วนโดยรอบ หากผลการจับคู่ครอบคลุมส่วนที่มีการจัดรูปแบบต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อให้แน่ใจว่าการแทนที่ใช้สไตล์ที่ต้องการ