---
title: جستجو و جایگزینی متن در ارائه‌های پاورپوینت با C++
linktitle: جستجو و جایگزینی متن
type: docs
weight: 55
url: /fa/cpp/search-and-replace-text/
keywords:
- جستجوی متن
- برجسته‌سازی متن
- جایگزینی متن
- عبارت منظم
- callback نتیجه
- قاب متن
- گزارش حسابرسی
- پاورپوینت
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "جستجو، برجسته‌سازی و جایگزینی متن در ارائه‌های پاورپوینت، همزمان با جمع‌آوری هر تطابق با Aspose.Slides برای C++."
---
## **مرور کلی**

Aspose.Slides برای C++ می‌تواند متن را در یک قاب متن منفرد یا در تمام ارائه جستجو، برجسته‌سازی و جایگزینی کند. هر عملیات می‌تواند با استفاده از یک callback نتیجه، هر تطابق را به برنامه اطلاع دهد. این امکان را فراهم می‌آورد تا یک ارائه به‌روزرسانی شود و همزمان یک ردپای حسابرسی شامل متن تطبیق‌داده‌شده، زمینه آن، موقعیت، قاب متن و شماره اسلاید ساخته شود.

این قابلیت‌ها برای بازبینی، حذف اطلاعات حساس، بررسی واژگان، پاک‌سازی قالب و گردش‌کارهای گزارش‌گیری خودکار مفید هستند.

در مثال‌های اولیه زیر، از فایلی به نام «sample.pptx» استفاده می‌کنیم که یک جعبه متن واحد در اسلاید اول دارد و متن زیر را شامل می‌شود:

![Sample text](sample_text.png)

## **Choose the Search Scope**

از متدهای موجود در [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) برای محدود کردن یک عملیات به یک قاب متن استفاده کنید. از متدهای موجود در [IPresentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/) برای پردازش تمام متن‌های قابل اعمال در ارائه استفاده کنید.

| عملیات | یک قاب متن | کل ارائه |
|---|---|---|
| برجسته‌سازی متن لغوی | [ITextFrame::HighlightText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/highlighttext/) |
| برجسته‌سازی تطابق‌های عبارت منظم | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/highlightregex/) |
| جایگزینی متن لغوی | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/replacetext/) |
| جایگزینی تطابق‌های عبارت منظم | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Configure Text Matching**

برای عملیات متن لغوی، از [ITextSearchOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextsearchoptions/) برای کنترل مطابقت استفاده کنید:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) مطابقت‌ها را به کلمات کامل محدود می‌کند.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) تعیین می‌کند که حروف بزرگ و کوچک باید مطابقت داشته باشند.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextsearchoptions/set_includenotes/) یادداشت‌های اسلاید را در جستجو، جایگزینی و برجسته‌سازی سطح ارائه شامل می‌شود.

عملیات‌های عبارت منظم از یک `System::Text::RegularExpressions::Regex` استفاده می‌کنند، بنابراین قواعدی نظیر حساسیت به حروف و مرزهای کلام توسط عبارت و گزینه‌های آن تعیین می‌شود.

## **Identify the Owner of a Text Frame**

گردش‌کارهای عمومی پردازش متن اغلب یک [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) را هنگام جستجو، جایگزینی، اعتبارسنجی یا خروجی‌گیری دریافت می‌کنند. با استفاده از [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/get_parentshape/) و [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/get_parentcell/) می‌توانید تعیین کنید که کدام شیء ارائه صاحب این قاب متن است.

مقادیر مورد انتظار بسته به مالک متفاوت است:

| مالک قاب متن | `get_ParentShape` | `get_ParentCell` |
|---|---|---|
| یک AutoShape یا شکل دیگر حاوی متن | مالک [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) | `nullptr` |
| یک سلول جدول | `nullptr` | مالک [ICell](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icell/) |

هر دو متد فقط برای مرور فقط‑خواندنی هستند. فراخوانی آن‌ها قاب متن را جابه‌جا یا مالک آن را تغییری نمی‌دهد. کدهای عمومی باید هر دو مقدار را برای `nullptr` بررسی کرده و امکان عدم وجود هر دو مالک را مدیریت کنند.

مثال زیر از [SlideUtil::GetAllTextFrames](https://reference.aspose.com/slides/fa/cpp/aspose.slides.util/slideutil/getalltextframes/) برای پیمایش قاب‌های متن در یک ارائه استفاده می‌کند. برای شکل‌ها، نام شکل، نوع زمان اجرای C++ و اسلاید حامل را گزارش می‌کند. برای سلول‌های جدول، مختصات ستون و ردیف صفر‑مبتنی و اسلاید حامل را گزارش می‌کند.

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

برای محتوای SmartArt، در شکل‌های موجود در [ISmartArtNode::get_Shapes](https://reference.aspose.com/slides/fa/cpp/aspose.slides.smartart/ismartartnode/get_shapes/) پیمایش کنید و به هر [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides.smartart/ismartartshape/get_textframe/) دسترسی پیدا کنید. قاب متن می‌تواند از طریق [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/get_parentshape/) به شکل مرتبط خود ردیابی شود، در حالی که [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/get_parentcell/) `nullptr` برمی‌گرداند. بنابراین، شاخه شکل در مثال نیز متن از گره‌های SmartArt را مدیریت می‌کند.

## **Collect Match Information with a Callback**

یک پیاده‌سازی از [IFindResultCallback](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifindresultcallback/) برای دریافت اعلان برای هر تطابق ایجاد کنید. متد [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifindresultcallback/foundresult/) آن، قاب متن مرتبط، متن منبع، متن تطبیق‑داده‌شده و موقعیت تطابق را فراهم می‌کند.

callback شماره اسلاید را مستقیماً دریافت نمی‌کند. پیاده‌سازی زیر آن را از [ISlideComponent::get_Slide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecomponent/get_slide/) استخراج می‌کند و همچنین متنی که در یادداشت‌های اسلاید یافت شده است، از طریق [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/inotesslide/get_parentslide/) مدیریت می‌کند. یک عدد اسلاید nullable امکان نمایاندن همان مدل نتیجه برای متن مرتبط با انواع دیگر اسلایدها را می‌دهد.

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

برای عملیات جایگزینی، `FoundText` شامل متن اصلی تطبیق‌داده‌شده است، بنابراین callback می‌تواند دقیقاً ثبت کند کدام عبارات جایگزین شده‌اند.

## **Highlight Text**

از متد [ITextFrame::HighlightText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/highlighttext/) برای برجسته‌سازی تطابق‌های متن لغوی در یک قاب متن استفاده کنید. برای کنترل جستجو یک [ITextSearchOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextsearchoptions/) را پاس بدهید و یک callback برای جمع‌آوری جزئیات تطابق‌ها فراهم کنید.

کد نمونه زیر تمام رخدادهای حروف **"try"** را برجسته می‌کند و سپس فقط کلمه کامل **"to"** را برجسته می‌سازد. هر دو جستجو تطابق‌های خود را به همان callback گزارش می‌دهند.

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

// دریافت اولین شکل از اولین اسلاید.
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// برجسته‌سازی تمام رخدادهای "try" در قاب متن.
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// برجسته‌سازی فقط کلمه کامل "to".
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

نتیجه:

![The highlighted text](highlighted_text.png)

## **Highlight Text Using Regular Expressions**

متد [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/highlightregex/) متن‌های مطابق با یک عبارت منظم را در یک قاب متن برجسته می‌کند.

کد زیر تمام کلماتی که دارای هفت یا بیشتر حرف هستند برجسته می‌کند و هر تطابق را جمع‌آوری می‌نماید:

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

نتیجه:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Highlight Text Across a Presentation**

از [IPresentation::HighlightText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/highlighttext/) و [IPresentation::HighlightRegex](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/highlightregex/) برای جستجوی تمام قاب‌های متن قابل اعمال در یک ارائه استفاده کنید. مثال زیر یک اصطلاح لغوی و تمام آدرس‌های ایمیل را برجسته می‌کند و برای هر دو جستجو مجموعه نتایج جداگانه‌ای حفظ می‌کند.

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

## **Replace Text in a Text Frame**

از [ITextFrame::ReplaceText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/replacetext/) برای متن لغوی و از [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/replaceregex/) برای جایگزینی مبتنی بر الگو استفاده کنید. این متدها متن تطبیق‑داده‌شده را درون قاب متن موجود به‌روز می‌کنند، به‌طوری که قالب‌بندی بخش‌های اطراف حفظ می‌شود و نیازی به بازسازی کامل قاب متن از یک رشته ساده نیست.

مثال زیر یک نوع نوشتاری متفاوت را استانداردسازی می‌کند و سپس برچسب‌های نسخه را جایگزین می‌نماید. همان callback اصطلاحات اصلی مطابقت‌داده شده توسط هر دو عملیات را ثبت می‌کند.

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

اگر یک تطابق شامل بخش‌هایی با قالب‌بندی متفاوت باشد، خروجی را بررسی کنید تا اطمینان حاصل کنید قالب‌بندی مناسب برای متن جایگزین اعمال شده است.

## **Replace Text Across a Presentation**

از [IPresentation::ReplaceText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/replacetext/) و [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/replaceregex/) برای اعمال همان عملیات‌ها در سراسر ارائه استفاده کنید. این کار برای پاک‌سازی قالب، به‌روزرسانی واژگان و حذف اطلاعات حساس مفید است.

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

## **Group Matches for Reporting**

از آنجا که هر نتیجه شماره اسلاید و قاب متن خود را ذخیره می‌کند، برنامه‌ها می‌توانند تطابق‌ها را برای حسابرسی، گزارش‌گیری یا گردش‌کارهای بازبینی گروه‌بندی کنند. مثال زیر نتایج جمع‌آوری‌شده را ابتدا بر اساس اسلاید و سپس بر اساس قاب متن گروه‌بندی می‌کند:

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

**How can I search only one text box instead of the entire presentation?**  
چگونه می‌توانم فقط یک جعبه متن را به جای کل ارائه جستجو کنم؟

قاب متن شکل را دریافت کنید و بر روی آن [ITextFrame::HighlightText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/highlighttext/)، [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/highlightregex/)، [ITextFrame::ReplaceText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/replacetext/) یا [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/replaceregex/) را فراخوانی کنید. متدهای سطح ارائه تمام قاب‌های متن قابل اعمال را پردازش می‌کنند.

**How can I match complete words with the correct capitalization?**  
چگونه می‌توانم فقط کلمات کامل را با حروف بزرگ و کوچک صحیح مطابقت دهم؟

متدهای [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) و [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) را با مقدار `true` تنظیم کنید و گزینه‌ها را به متد برجسته‌سازی یا جایگزینی متن لغوی پاس بدهید. برای عبارات منظم، مرزهای کلمه و حساسیت به حروف را در خود `System::Text::RegularExpressions::Regex` تعریف کنید.

**Can search and replacement include text in slide notes?**  
آیا جستجو و جایگزینی می‌تواند متن موجود در یادداشت‌های اسلاید را نیز شامل شود؟

بله. هنگام استفاده از یک عملیات متن لغوی در سطح ارائه، [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextsearchoptions/set_includenotes/) را با مقدار `true` تنظیم کنید. پیاده‌سازی callback نشان داده شده در بالا، یک تطابق در اسلاید یادداشت را به شماره اسلاید والد خود بازمی‌گرداند.

**How can I create a report without scanning the presentation a second time?**  
چگونه می‌توانم بدون اسکن دوباره ارائه، گزارشی ایجاد کنم؟

یک پیاده‌سازی از [IFindResultCallback](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifindresultcallback/) را به عملیات برجسته‌سازی یا جایگزینی پاس بدهید. callback در حین اجرای عملیات هر تطابق را دریافت می‌کند، بنابراین برنامه می‌تواند متن منبع، متن تطبیق‑داده‌شده، موقعیت، قاب متن و شماره اسلاید استخراج‌شده را برای گروه‌بندی یا خروجی‌گیری بعدی ذخیره کند.

**Does replacing text preserve its formatting?**  
آیا جایگزینی متن قالب‌بندی آن را حفظ می‌کند؟

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/replacetext/) و [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/replaceregex/) متن تطبیق‑داده‌شده را درون قاب متن موجود تغییر می‌دهند و قالب‌بندی بخش‌های اطراف را نگه می‌دارند. اگر یک تطابق شامل بخش‌هایی با قالب‌بندی متفاوت باشد، خروجی را بررسی کنید تا اطمینان حاصل شود که متن جایگزین از سبک موردنظر استفاده می‌کند.