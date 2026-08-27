---
title: البحث واستبدال النص في عروض PowerPoint التقديمية باستخدام C++
linktitle: البحث واستبدال النص
type: docs
weight: 55
url: /ar/cpp/search-and-replace-text/
keywords:
- بحث نص
- تظليل نص
- استبدال نص
- تعبير نمطي
- استدعاء نتيجة
- إطار نص
- تقرير تدقيق
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "ابحث، و ظلل، واستبدل النص في عروض PowerPoint التقديمية مع جمع كل تطابق باستخدام Aspose.Slides for C++."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for C++ البحث، وتظليل، واستبدال النص في إطار نصي واحد أو في عرض تقديمي كامل. كل عملية يمكنها أيضًا إبلاغ التطبيق عن كل تطابق عبر استدعاء نتيجة. هذا يجعل من الممكن تحديث العرض التقديمي وفي الوقت نفسه بناء سجل تدقيق يحتوي على النص المتطابق، وسياقه، وموقعه، وإطار النص، ورقم الشريحة.

تُعد هذه الإمكانيات مفيدة للمراجعة، والحجب، وفحص المصطلحات، وتنظيف القوالب، وتدفقات العمل الآلية للتقارير.

في الأمثلة الأولى أدناه، نستخدم ملفًا باسم "sample.pptx"، يحتوي على مربع نص واحد في الشريحة الأولى بالنص التالي:

![Sample text](sample_text.png)

## **اختر نطاق البحث**

استخدم الأساليب على [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) لتحديد عملية لإطار نص واحد. استخدم الأساليب على [IPresentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/) لمعالجة كل النص القابل للتطبيق في العرض التقديمي.

| العملية | إطار نص واحد | العرض التقديمي بالكامل |
|---|---|---|
| تظليل النص الحرفي | [ITextFrame::HighlightText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/highlighttext/) |
| تظليل تطابقات التعبير النمطي | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/highlightregex/) |
| استبدال النص الحرفي | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/replacetext/) |
| استبدال تطابقات التعبير النمطي | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/replaceregex/) |

## **تكوين مطابقة النص**

للعمليات الحرفية، استخدم [ITextSearchOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextsearchoptions/) للتحكم في المطابقة:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) يقتصر على التطابقات التي تكون كلمات كاملة.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) يتحكم فيما إذا كان يجب أن يتطابق حالة الأحرف.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextsearchoptions/set_includenotes/) يشمل ملاحظات الشرائح في عمليات البحث والاستبدال والتظليل على مستوى العرض التقديمي.

تستخدم عمليات التعبير النمطي كائنًا من النوع `System::Text::RegularExpressions::Regex`، لذا تُحدَّد قواعد المطابقة مثل حساسية الحالة وحدود الكلمات بواسطة التعبير وخياراته.

## **تحديد مالك إطار النص**

غالبًا ما تتلقى سير عمل معالجة النص العامة كائنًا من نوع [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) أثناء البحث أو الاستبدال أو التحقق أو التصدير. استخدم [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/get_parentshape/) و[ITextFrame::get_ParentCell](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/get_parentcell/) لتحديد أي كائن عرض تقديمي يمتلك إطار النص.

القيم المتوقعة تعتمد على المالك:

| مالك إطار النص | `get_ParentShape` | `get_ParentCell` |
|---|---|---|
| شكل AutoShape أو شكل آخر يحتوي نصًا | الـ[IShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/) المالك | `nullptr` |
| خلية جدول | `nullptr` | الـ[ICell](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icell/) المالك |

كلا الطريقتين توفران تنقلاً للقراءة فقط. لا تقوم استدعاؤهما بنقل إطار النص أو تغيير مالكه. يجب على الكود العام فحص كلا القيمتين بالنسبة إلى `nullptr` ومعالجة الاحتمال أن لا يكون أي من المالكين متاحًا.

المثال التالي يستخدم [SlideUtil::GetAllTextFrames](https://reference.aspose.com/slides/ar/cpp/aspose.slides.util/slideutil/getalltextframes/) للتنقل عبر إطارات النص في عرض تقديمي. بالنسبة للأشكال، يقوم بالإبلاغ عن اسم الشكل، ونوع وقت التشغيل في C++، والشريحة الحاوية. بالنسبة لخلايا الجدول، يُبلغ عن إحداثيات العمود والصف (صفرية) والشريحة الحاوية.

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

لمحتوى SmartArt، تنقل عبر الأشكال في [ISmartArtNode::get_Shapes](https://reference.aspose.com/slides/ar/cpp/aspose.slides.smartart/ismartartnode/get_shapes/) وابدأ كل [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides.smartart/ismartartshape/get_textframe/). يمكن تتبع إطار النص إلى الشكل المرتبط عبر [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/get_parentshape/)، بينما يعيد [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/get_parentcell/) `nullptr`. لذلك يتعامل فرع الشكل في المثال أيضًا مع النص من عقد SmartArt.

## **جمع معلومات التطابق عبر استدعاء رد فعل**

نفّذ [IFindResultCallback](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifindresultcallback/) لتلقي إشعار عن كل تطابق. تُوفر الطريقة [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifindresultcallback/foundresult/) إطار النص المتعلق، والنص الأصلي، والنص المتطابق، وموقع التطابق.

لا تتلقى الاستدعائية رقم الشريحة مباشرة. تستخلص التنفيذ أدناه ذلك من [ISlideComponent::get_Slide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecomponent/get_slide/) وتتعامل أيضًا مع النص الموجود في ملاحظات الشرائح عبر [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/inotesslide/get_parentslide/). يسمح رقم شريحة قابل للغياب بنموذج نتيجة موحد يمكنه تمثيل النص المرتبط بأنواع شرائح أخرى.

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

في عمليات الاستبدال، يحتوي `FoundText` على النص الأصلي المتطابق، بحيث يمكن للاستدعائية تسجيل المصطلحات التي تم استبدالها بدقة.

## **تظليل النص**

استخدم الطريقة [ITextFrame::HighlightText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/highlighttext/) لتظليل تطابقات النص الحرفية في إطار نص. مرّر [ITextSearchOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextsearchoptions/) للتحكم في البحث واستدعائية لتجميع تفاصيل التطابق.

المثال البرمجي أدناه يظلل جميع تكرارات الأحرف **"try"** ثم يظلل كلمة **"to"** الكاملة فقط. كل من البحثين يرسلان تطابقاتهما إلى نفس الاستدعائية.

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

// احصل على الشكل الأول من الشريحة الأولى.
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// ظلل كل ظهور لكلمة "try" في إطار النص.
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// ظلل كلمة "to" الكاملة فقط.
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

الناتج:

![The highlighted text](highlighted_text.png)

## **تظليل النص باستخدام تعبيرات نمطية**

تُظلل الطريقة [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/highlightregex/) مطابقات النص التي يجدها تعبير نمطي في إطار نص.

الكود التالي يظلل جميع الكلمات التي تحتوي على سبعة أحرف أو أكثر ويجمع كل تطابق:

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

الناتج:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **تظليل النص عبر عرض تقديمي**

استخدم [IPresentation::HighlightText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/highlighttext/) و[IPresentation::HighlightRegex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/highlightregex/) للبحث عبر جميع إطارات النص القابلة للتطبيق في عرض تقديمي. المثال التالي يظلل مصطلحًا حرفيًا وجميع عناوين البريد الإلكتروني مع الحفاظ على مجموعات نتائج منفصلة للبحثين.

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

استخدم [ITextFrame::ReplaceText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/replacetext/) للنص الحرفي و[ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/replaceregex/) للاستبدال القائم على نمط. تُحدِّث هذه الأساليب النص المتطابق داخل إطار النص الحالي، مما يحتفظ بتنسيق الجزء المحيط بدلاً من إعادة بناء إطار النص من سلسلة عادية.

المثال التالي يوضح توحيد صيغة كتابة كلمة ثم استبدال تسميات الإصدارات. تُسجَّل نفس الاستدعائية المصطلحات الأصلية التي تم مطابقتها في العمليتين.

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

إذا امتد تطابق على أجزاء ذات تنسيقات مختلفة، راجع الناتج لتحديد أي تنسيق ينبغي تطبيقه على النص المستبدل.

## **استبدال النص عبر عرض تقديمي**

استخدم [IPresentation::ReplaceText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/replacetext/) و[IPresentation::ReplaceRegex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/replaceregex/) لتطبيق نفس العمليات عبر العرض التقديمي. هذا مفيد لتنظيف القوالب، وتحديث المصطلحات، والحجب.

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

نظرًا لأن كل نتيجة تخزن رقم الشريحة وإطار النص، يمكن للتطبيقات تجميع التطابقات للتدقيق أو التقارير أو سير عمل المراجعة. المثال التالي يجمع النتائج المجمعة أولاً حسب الشريحة ثم حسب إطار النص:

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

## **الأسئلة المتداولة**

**كيف يمكنني البحث في مربع نص واحد فقط بدلاً من العرض التقديمي بأكمله؟**

احصل على إطار النص الخاص بالشكل واستدعِ [ITextFrame::HighlightText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/highlighttext/)، [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/highlightregex/)، [ITextFrame::ReplaceText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/replacetext/)، أو [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/replaceregex/) على ذلك الإطار. تُعالج طرق مستوى العرض التقديمي جميع إطارات النص القابلة للتطبيق بدلاً منها.

**كيف يمكنني مطابقة الكلمات الكاملة مع الأحرف الكبيرة الصحيحة؟**

استدعِ [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) و[ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) مع القيمة `true`، ومرّر الخيارات إلى طريقة تظليل أو استبدال النص الحرفي. بالنسبة للتعبيرات النمطية، عرّف حدود الكلمات وحساسية الحالة داخل `System::Text::RegularExpressions::Regex` نفسه.

**هل يمكن أن تشمل عمليات البحث والاستبدال النص الموجود في ملاحظات الشرائح؟**

نعم. استدعِ [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextsearchoptions/set_includenotes/) مع القيمة `true` عند استخدام عملية حرفية على مستوى العرض التقديمي. تقوم تنفيذية الاستدعائية الموضحة أعلاه بربط التطابق في شريحة الملاحظات برقم الشريحة الأصلية.

**كيف يمكنني إنشاء تقرير دون مسح العرض التقديمي مرة ثانية؟**

مرّر تنفيذًا لـ [IFindResultCallback](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifindresultcallback/) إلى عملية التظليل أو الاستبدال. تستقبل الاستدعائية كل تطابق أثناء تنفيذ العملية، بحيث يمكن للتطبيق تخزين النص الأصلي، والنص المتطابق، والموقع، وإطار النص، ورقم الشريحة المستخلص لاحقًا للتجميع أو التصدير.

**هل يحافظ استبدال النص على تنسيقه؟**

تُعدّ كل من [ITextFrame::ReplaceText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/replacetext/) و[ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/replaceregex/) النص المتطابق داخل إطار النص الحالي وتحتفظ بتنسيق الجزء المحيط. إذا امتد التطابق على أجزاء ذات تنسيقات مختلفة، تحقق من النتيجة لضمان أن الاستبدال يستخدم النمط المطلوب.