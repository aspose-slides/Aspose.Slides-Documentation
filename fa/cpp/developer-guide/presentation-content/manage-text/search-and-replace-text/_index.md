---
title: جستجو و جایگزینی متن در ارائه‌های PowerPoint در C++
linktitle: جستجو و جایگزینی متن
type: docs
weight: 55
url: /fa/cpp/search-and-replace-text/
keywords:
- جستجوی متن
- برجسته‌سازی متن
- جایگزینی متن
- عبارت منظم
- فراخوانی بازگشت نتیجه
- فریم متن
- گزارش حسابرسی
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "جستجو، برجسته‌سازی و جایگزینی متن در ارائه‌های PowerPoint همراه با جمع‌آوری هر تطابق با Aspose.Slides برای C++."
---
## **Overview**

Aspose.Slides برای C++ می‌تواند متن را در یک فریم متن منفرد یا در تمام ارائه جستجو، برجسته و جایگزین کند. هر عملیات می‌تواند از طریق یک بازتاب نتیجه، برنامه را از هر تطابق مطلع سازد. این امکان را فراهم می‌کند تا یک ارائه را به‌روز کنید و به‌طور همزمان یک مسیر حسابرسی شامل متن مطابقت یافته، زمینه آن، موقعیت، فریم متن و شماره اسلاید ایجاد کنید.

این قابلیت‌ها برای بازبینی، محرمانه‌سازی، بررسی اصطلاحات، پاک‌سازی قالب و جریان‌های کاری گزارش‌گیری خودکار مفید هستند.

در مثال‌های اولیه زیر، از فایلی به نام «sample.pptx» استفاده می‌کنیم که شامل یک جعبه متن در اسلاید اول با متن زیر است:

![متن نمونه](sample_text.png)

## **Choose the Search Scope**

از متدهای [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) برای محدود کردن یک عملیات به یک فریم متن استفاده کنید. از متدهای [IPresentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/) برای پردازش تمام متن‌های قابل کاربرد در ارائه استفاده کنید.

| عملیات | یک فریم متن | کل ارائه |
|---|---|---|
| برجسته‌سازی متن عینی | [ITextFrame::HighlightText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/highlighttext/) |
| برجسته‌سازی مطابقت‌های عبارت منظم | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/highlightregex/) |
| جایگزینی متن عینی | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/replacetext/) |
| جایگزینی مطابقت‌های عبارت منظم | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Configure Text Matching**

برای عملیات متن عینی، از [ITextSearchOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextsearchoptions/) برای کنترل مطابقت استفاده کنید:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) تطابق‌ها را به کلمات کامل محدود می‌کند.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) کنترل می‌کند که آیا حروف با یکدیگر مطابقت داشته باشند.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextsearchoptions/set_includenotes/) یادداشت‌های اسلاید را در عملیات جستجو، جایگزینی و برجسته‌سازی در سطح ارائه شامل می‌شود.

عملیات‌های عبارت منظم از `System::Text::RegularExpressions::Regex` استفاده می‌کنند، بنابراین قوانین مطابقت مانند حساسیت به حروف و مرزهای کلمه توسط خود عبارت و گزینه‌های آن تعریف می‌شود.

## **Collect Match Information with a Callback**

برای دریافت اعلان برای هر تطابق، [IFindResultCallback](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifindresultcallback/) را پیاده‌سازی کنید. متد [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifindresultcallback/foundresult/) فریم متن مرتبط، متن منبع، متن مطابقت یافته و موقعیت تطابق را فراهم می‌کند.

این بازگشت‌دعویی مستقیماً شماره اسلاید را دریافت نمی‌کند. پیاده‌سازی زیر آن را از [ISlideComponent::get_Slide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecomponent/get_slide/) استخراج می‌کند و همچنین متن پیدا شده در یادداشت‌های اسلاید را از طریق [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/inotesslide/get_parentslide/) مدیریت می‌نماید. یک شماره اسلاید قابل تهی اجازه می‌دهد همان مدل نتیجه متن مرتبط با انواع دیگر اسلایدها را نشان دهد.

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

برای عملیات جایگزینی، `FoundText` شامل متن اصلی تطابق یافته است، بنابراین بازگشت‌دعویی می‌تواند دقیقاً ثبت کند که کدام اصطلاحات جایگزین شده‌اند.

## **Highlight Text**

از متد [ITextFrame::HighlightText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/highlighttext/) برای برجسته‌سازی مطابقت‌های متن عینی در یک فریم متن استفاده کنید. برای کنترل جستجو یک شیء [ITextSearchOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextsearchoptions/) پاس بدهید و برای جمع‌آوری جزئیات تطابق یک بازگشت‌دعویی فراهم کنید.

کد نمونه زیر تمام رخدادهای کاراکترهای **"try"** را برجسته می‌کند و سپس تنها کلمه کامل **"to"** را برجسته می‌سازد. هر دو جستجو تطابق‌های خود را به همان بازگشت‌دعویی گزارش می‌دهند.

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

نتیجه:

![متن برجسته شده](highlighted_text.png)

## **Highlight Text Using Regular Expressions**

متد [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/highlightregex/) متن‌هایی را که توسط یک عبارت منظم پیدا می‌شوند، در یک فریم متن برجسته می‌کند.

کد زیر تمام کلماتی که شامل هفت کاراکتر یا بیشتر هستند را برجسته می‌کند و هر تطابق را جمع‌آوری می‌نماید:

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

![متن برجسته شده با استفاده از عبارت منظم](highlighted_text_using_regex.png)

## **Highlight Text Across a Presentation**

از [IPresentation::HighlightText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/highlighttext/) و [IPresentation::HighlightRegex](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/highlightregex/) برای جستجوی تمام فریم‌های متنی قابل کاربرد در یک ارائه استفاده کنید. مثال زیر یک اصطلاح عینی و تمام آدرس‌های ایمیل را برجسته می‌کند و مجموعه نتایج جداگانه‌ای برای دو جستجو نگه می‌دارد.

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

از [ITextFrame::ReplaceText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/replacetext/) برای متن عینی و [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/replaceregex/) برای جایگزینی مبتنی بر الگو استفاده کنید. این متدها متن مطابقت یافته را داخل فریم متن موجود به‌روزرسانی می‌کنند، به‌طوری‌که قالب‌بندی بخش‌های اطراف حفظ می‌شود و نیازی به بازسازی فریم متن از یک رشته ساده نیست.

مثال زیر یک گونه املایی را استاندارد می‌کند و سپس برچسب‌های نسخه را جایگزین می‌سازد. همان بازگشت‌دعویی اصطلاحات اصلی مطابقت یافته توسط هر دو عملیات را ثبت می‌کند.

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

اگر یک تطابق بخش‌هایی با قالب‌بندی متفاوت را در بر گیرد، خروجی را بررسی کنید تا تأیید کنید که کدام قالب‌بندی باید بر متن جایگزین اعمال شود.

## **Replace Text Across a Presentation**

از [IPresentation::ReplaceText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/replacetext/) و [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/replaceregex/) برای اعمال همان عملیات‌ها در سرتاسر ارائه استفاده کنید. این امر برای پاک‌سازی قالب، به‌روزرسانی اصطلاحات و محرمانه‌سازی مفید است.

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

از آنجا که هر نتیجه شماره اسلاید و فریم متن خود را ذخیره می‌کند، برنامه‌ها می‌توانند تطابق‌ها را برای حسابرسی، گزارش‌دهی یا جریان‌های کاری بازبینی گروه‌بندی کنند. مثال زیر نتایج جمع‌آوری شده را ابتدا بر اساس اسلاید و سپس بر اساس فریم متن گروه‌بندی می‌کند:

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

**چگونه می‌توانم فقط یک جعبه متن را به‌جای کل ارائه جستجو کنم؟**

فریم متن شکل را دریافت کنید و یکی از متدهای [ITextFrame::HighlightText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/highlighttext/)، [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/highlightregex/)، [ITextFrame::ReplaceText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/replacetext/) یا [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/replaceregex/) را روی آن فریم متن صدا بزنید. متدهای سطح ارائه تمام فریم‌های متنی قابل کاربرد را پردازش می‌کنند.

**چگونه می‌توانم کلمات کامل را با حروف بزرگ/کوچک صحیح مطابقت دهم؟**

متدهای [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) و [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) را با مقدار `true` فراخوانی کنید و گزینه‌ها را به متد برجسته‌سازی یا جایگزینی متن عینی پاس بدهید. برای عبارات منظم، مرزهای کلمه و حساسیت به حروف را خود در `System::Text::RegularExpressions::Regex` تعریف کنید.

**آیا جستجو و جایگزینی می‌توانند متن موجود در یادداشت‌های اسلاید را شامل شوند؟**

بله. هنگام استفاده از یک عملیات متن عینی در سطح ارائه، [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextsearchoptions/set_includenotes/) را با مقدار `true` فراخوانی کنید. پیاده‌سازی بازگشت‌دعویی نشان‌داده‌شده، یک تطابق در اسلاید یادداشت‌ها را به شماره اسلاید والد آن بازمی‌گرداند.

**چگونه می‌توانم گزارشی ایجاد کنم بدون اینکه ارائه را بار دوم اسکن کنم؟**

یک پیاده‌سازی از [IFindResultCallback](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifindresultcallback/) را به عملیات برجسته‌سازی یا جایگزینی پاس بدهید. بازگشت‌دعویی در حین اجرای عملیات هر تطابق را دریافت می‌کند، بنابراین برنامه می‌تواند متن منبع، متن مطابقت یافته، موقعیت، فریم متن و شماره اسلاید استخراج‌شده را برای گروه‌بندی یا استخراج بعدی ذخیره کند.

**آیا جایگزینی متن قالب‌بندی آن را حفظ می‌کند؟**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/replacetext/) و [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/replaceregex/) متن مطابقت یافته را داخل فریم متن موجود تغییر می‌دهند و قالب‌بندی بخش‌های اطراف را حفظ می‌کنند. اگر یک تطابق بخش‌هایی با قالب‌بندی متفاوت را در بر گیرد، نتیجه را بررسی کنید تا اطمینان حاصل کنید جایگزینی از استایل دلخواه استفاده می‌کند.