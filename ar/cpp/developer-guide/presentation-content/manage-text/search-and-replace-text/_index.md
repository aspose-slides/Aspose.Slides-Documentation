---
title: بحث واستبدال النص في عروض PowerPoint التقديمية باستخدام C++
linktitle: بحث واستبدال النص
type: docs
weight: 55
url: /ar/cpp/search-and-replace-text/
keywords:
- بحث النص
- تظليل النص
- استبدال النص
- تعبير نمطي
- رد نداء للنتيجة
- إطار النص
- تقرير تدقيق
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "بحث وتظليل واستبدال النص في عروض PowerPoint التقديمية مع جمع كل تطابق باستخدام Aspose.Slides for C++."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for C++ البحث عن النص وتظليله واستبداله داخل إطار نصي واحد أو عبر عرض تقديمي كامل. يمكن لكل عملية أيضًا إخطار التطبيق بكل تطابق من خلال رد نداء للنتيجة. هذا يتيح إمكانية تحديث العرض وتسجيل مسار تدقيق يحتوي على النص المتطابق وسياقه وموقعه وإطار النص ورقم الشريحة.

تُستخدم هذه القدرات في مراجعة المحتوى، الحذف، فحص المصطلحات، تنظيف القوالب، وتدفقات العمل الأوتوماتيكية للتقارير.

في الأمثلة الأولى أدناه، نستخدم ملفًا يُدعى "sample.pptx"، يحتوي على صندوق نص واحد في الشريحة الأولى بالنص التالي:

![نص عينة](sample_text.png)

## **اختيار نطاق البحث**

استخدم الأساليب المتوفرة في [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) لتحديد عملية على إطار نص واحد. استخدم الأساليب المتوفرة في [IPresentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/) لمعالجة جميع النصوص القابلة للمعالجة في العرض.

| العملية | إطار نص واحد | العرض بالكامل |
|---|---|---|
| تظليل النص الحرفي | [ITextFrame::HighlightText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/highlighttext/) |
| تظليل تطابقات التعبير النمطي | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/highlightregex/) |
| استبدال النص الحرفي | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/replacetext/) |
| استبدال تطابقات التعبير النمطي | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/replaceregex/) |

## **تكوين مطابقة النص**

لعمليات النص الحرفي، استخدم [ITextSearchOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextsearchoptions/) للتحكم في المطابقة:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) يحدّ المطابقات إلى كلمات كاملة.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) يتحكم فيما إذا كان يجب أن يطابق حجم الحروف.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextsearchoptions/set_includenotes/) يضم ملاحظات الشرائح في عمليات البحث والاستبدال وتظليل النص على مستوى العرض.

تستخدم عمليات التعبير النمطي كائنًا من النوع `System::Text::RegularExpressions::Regex`، لذلك تُحدَّد قواعد المطابقة مثل حساسية الحالة وحدود الكلمات بواسطة التعبير نفسه وخياراته.

## **جمع معلومات التطابق عبر رد نداء**

نفّذ [IFindResultCallback](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifindresultcallback/) لتلقي إشعار لكل تطابق. تُوفّر طريقة [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifindresultcallback/foundresult/) الإطار النصي المتعلق، النص الأصلي، النص المتطابق، وموقع التطابق.

رد النداء لا يتلقى رقم الشريحة مباشرة. يُستمد الرقم في الشيفرة أدناه من [ISlideComponent::get_Slide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecomponent/get_slide/) كما يتعامل مع النص الموجود في ملاحظات الشريحة عبر [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/inotesslide/get_parentslide/). يسمح رقم الشريحة القابل للغِضِّ بطراز نتيجة موحَّد لتمثيل النص المرتبط بأنواع شرائح أخرى.

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

في عمليات الاستبدال، يحتوي `FoundText` على النص الأصلي المتطابق، لذا يمكن لرد النداء تسجيل النصوص التي تم استبدالها بدقة.

## **تظليل النص**

استخدم طريقة [ITextFrame::HighlightText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/highlighttext/) لتظليل مطابقات النص الحرفي في إطار نص. مرّر كائنًا من [ITextSearchOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextsearchoptions/) للتحكم في البحث ومرّر رد نداء لجمع تفاصيل التطابق.

تُظهر الشيفرة أدناه تظليل جميع تواجدات الحرفين **"try"** ثم تظليل الكلمة الكاملة **"to"** فقط. كلتا عمليات البحث تُرسل تطابقاتها لنفس رد النداء.

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

النتيجة:

![النص المظلل](highlighted_text.png)

## **تظليل النص باستخدام التعبيرات النمطية**

تُظلل طريقة [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/highlightregex/) مطابقات النص التي تُعثر عليها تعبيرًا نمطيًا داخل إطار نص.

تُظهر الشيفرة التالية تظليل جميع الكلمات التي تحتوي على سبعة أحرف أو أكثر وتجمع كل تطابق:

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

النتيجة:

![النص المظلل باستخدام التعبير النمطي](highlighted_text_using_regex.png)

## **تظليل النص عبر العرض بالكامل**

استخدم [IPresentation::HighlightText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/highlighttext/) و[IPresentation::HighlightRegex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/highlightregex/) للبحث في جميع أطر النص القابلة للمعالجة داخل العرض. يُظهر المثال التالي تظليل مصطلح حرفي وجميع عناوين البريد الإلكتروني مع الحفاظ على مجموعات نتائج منفصلة لكل عملية بحث.

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

## **استبدال النص في إطار نص**

استخدم [ITextFrame::ReplaceText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/replacetext/) للنص الحرفي و[ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/replaceregex/) للاستبدال القائم على النمط. تقوم هذه الطرق بتحديث النص المتطابق داخل إطار النص الموجود، مما يحتفظ بتنسيق الجزء المحيط بدلاً من إعادة بناء إطار النص من سلسلة عادية.

يوضح المثال التالي توحيد شكل كتابة كلمة ثم استبدال تسميات الإصدارات. يسجل نفس رد النداء المصطلحات الأصلية التي تم مطابقتها في كلتا العمليتين.

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

إذا امتد تطابق إلى أجزاء ذات تنسيقات مختلفة، راجع النتيجة لتأكيد أي تنسيق يجب تطبيقه على النص المستبدل.

## **استبدال النص عبر العرض بالكامل**

استخدم [IPresentation::ReplaceText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/replacetext/) و[IPresentation::ReplaceRegex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/replaceregex/) لتطبيق نفس العمليات على كامل العرض. هذا مفيد لتنظيف القوالب، تحديث المصطلحات، والحذف.

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

## **تجميع التطابقات للتقارير**

نظرًا لأن كل نتيجة تخزن رقم الشريحة وإطار النص، يمكن للتطبيقات تجميع التطابقات للمراجعة أو التقارير أو سير عمل المراجعة. يوضح المثال التالي تجميع النتائج التي تم جمعها أولاً حسب الشريحة ثم حسب إطار النص:

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

## **الأسئلة المتكررة**

**كيف يمكنني البحث في صندوق نص واحد فقط بدلاً من العرض بالكامل؟**

احصل على إطار النص الخاص بالشكل واستدعِ [ITextFrame::HighlightText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/highlighttext/)، [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/highlightregex/)، [ITextFrame::ReplaceText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/replacetext/)، أو [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/replaceregex/) على ذلك الإطار. تعالج الأساليب على مستوى العرض جميع أطر النص القابلة للمعالجة بدلاً من ذلك.

**كيف يمكنني مطابقة الكلمات الكاملة مع الحفاظ على حالة الأحرف الصحيحة؟**

استدعِ [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) و[ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) بالقيمة `true`، ومرّر الخيارات إلى طريقة تظليل أو استبدال النص الحرفي. بالنسبة للتعبيرات النمطية، عرّف حدود الكلمات وحساسية الحالة داخل الـ `System::Text::RegularExpressions::Regex` نفسه.

**هل يمكن أن يشمل البحث والاستبدال النص الموجود في ملاحظات الشرائح؟**

نعم. استدعِ [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextsearchoptions/set_includenotes/) بالقيمة `true` عند استخدام عملية نص حرفي على مستوى العرض. تُعيد تنفيذية رد النداء المعروضة أعلاه ربط التطابق الموجود في شريحة الملاحظات إلى رقم شريحة الأصل.

**كيف يمكنني إنشاء تقرير دون مسح العرض مرة ثانية؟**

مرّر تنفيذية [IFindResultCallback](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifindresultcallback/) إلى عملية التظليل أو الاستبدال. يتلقى رد النداء كل تطابق أثناء تشغيل العملية، وبالتالي يمكن للتطبيق تخزين النص الأصلي، النص المتطابق، الموقع، إطار النص، ورقم الشريحة المستنتج لتجميعه لاحقًا أو تصديره.

**هل يحافظ استبدال النص على تنسيقه؟**

تُعدّل [ITextFrame::ReplaceText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/replacetext/) و[ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/replaceregex/) النص المتطابق داخل إطار النص الموجود وتحتفظ بتنسيق الجزء المحيط. إذا امتد التطابق إلى أجزاء ذات تنسيقات مختلفة، فافحص النتيجة لضمان أن الاستبدال يستخدم النمط المطلوب.