---
title: Search and Replace Text in PowerPoint Presentations in C++
linktitle: Search and Replace Text
type: docs
weight: 55
url: /cpp/search-and-replace-text/
keywords:
- search text
- highlight text
- replace text
- regular expression
- result callback
- text frame
- audit report
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Search, highlight, and replace text in PowerPoint presentations while collecting every match with Aspose.Slides for C++."
---

## **Overview**

Aspose.Slides for C++ can search, highlight, and replace text in an individual text frame or across an entire presentation. Each operation can also notify an application about every match through a result callback. This makes it possible to update a presentation and simultaneously build an audit trail containing the matched text, its context, position, text frame, and slide number.

These capabilities are useful for review, redaction, terminology checks, template cleanup, and automated reporting workflows.

In the first examples below, we use a file named "sample.pptx", which contains a single text box on the first slide with the following text:

![Sample text](sample_text.png)

## **Choose the Search Scope**

Use methods on [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) to limit an operation to one text frame. Use methods on [IPresentation](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/) to process all applicable text in the presentation.

| Operation | One text frame | Entire presentation |
|---|---|---|
| Highlight literal text | [ITextFrame::HighlightText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/highlighttext/) |
| Highlight regular-expression matches | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/highlightregex/) |
| Replace literal text | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/replacetext/) |
| Replace regular-expression matches | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Configure Text Matching**

For literal-text operations, use [ITextSearchOptions](https://reference.aspose.com/slides/cpp/aspose.slides/itextsearchoptions/) to control matching:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) limits matches to complete words.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) controls whether character case must match.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/cpp/aspose.slides/itextsearchoptions/set_includenotes/) includes slide notes in presentation-level search, replacement, and highlighting operations.

Regular-expression operations use a `System::Text::RegularExpressions::Regex`, so matching rules such as case sensitivity and word boundaries are defined by the expression and its options.

## **Identify the Owner of a Text Frame**

Generic text-processing workflows often receive an [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) while searching, replacing, validating, or exporting text. Use [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentshape/) and [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) to determine which presentation object owns the text frame.

The expected values depend on the owner:

| Text frame owner | `get_ParentShape` | `get_ParentCell` |
|---|---|---|
| An AutoShape or another text-containing shape | The owning [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) | `nullptr` |
| A table cell | `nullptr` | The owning [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) |

Both methods provide read-only navigation. Calling them does not move the text frame or change its owner. Generic code should check both values for `nullptr` and handle the possibility that neither owner is available.

The following example uses [SlideUtil::GetAllTextFrames](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/getalltextframes/) to iterate through the text frames in a presentation. For shapes, it reports the shape name, C++ runtime type, and containing slide. For table cells, it reports the zero-based column and row coordinates and the containing slide.

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

For SmartArt content, iterate through the shapes in [ISmartArtNode::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_shapes/) and access each [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartshape/get_textframe/). The text frame can be traced to its associated shape through [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentshape/), while [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) returns `nullptr`. Therefore, the shape branch in the example also handles text from SmartArt nodes.

## **Collect Match Information with a Callback**

Implement [IFindResultCallback](https://reference.aspose.com/slides/cpp/aspose.slides/ifindresultcallback/) to receive a notification for every match. Its [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/cpp/aspose.slides/ifindresultcallback/foundresult/) method provides the related text frame, the source text, the matched text, and the match position.

The callback does not receive a slide number directly. The implementation below derives it from [ISlideComponent::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/islidecomponent/get_slide/) and also handles text found in slide notes through [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/cpp/aspose.slides/inotesslide/get_parentslide/). A nullable slide number allows the same result model to represent text associated with other slide types.

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

For replacement operations, `FoundText` contains the original matched text, so the callback can record exactly which terms were replaced.

## **Highlight Text**

Use the [ITextFrame::HighlightText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/highlighttext/) method to highlight literal-text matches in a text frame. Pass [ITextSearchOptions](https://reference.aspose.com/slides/cpp/aspose.slides/itextsearchoptions/) to control the search and a callback to collect match details.

The code example below highlights all occurrences of the characters **"try"** and then highlights only the complete word **"to"**. Both searches report their matches to the same callback.

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

The result:

![The highlighted text](highlighted_text.png)

## **Highlight Text Using Regular Expressions**

The [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/highlightregex/) method highlights text matches found by a regular expression in a text frame.

The following code highlights all words containing seven or more characters and collects each match:

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

The result:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Highlight Text Across a Presentation**

Use [IPresentation::HighlightText](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/highlighttext/) and [IPresentation::HighlightRegex](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/highlightregex/) to search all applicable text frames in a presentation. The following example highlights a literal term and all email addresses while keeping separate result collections for the two searches.

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

Use [ITextFrame::ReplaceText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/replacetext/) for literal text and [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/replaceregex/) for pattern-based replacement. These methods update matched text within the existing text frame, which retains the surrounding portion formatting instead of rebuilding the text frame from a plain string.

The following example standardizes a spelling variant and then replaces version labels. The same callback records the original terms matched by both operations.

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

If one match spans portions with different formatting, review the output to confirm which formatting should apply to the replacement text.

## **Replace Text Across a Presentation**

Use [IPresentation::ReplaceText](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/replacetext/) and [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/replaceregex/) to apply the same operations across the presentation. This is useful for template cleanup, terminology updates, and redaction.

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

Because every result stores its slide number and text frame, applications can group matches for audit, reporting, or review workflows. The following example groups the collected results first by slide and then by text frame:

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

Get the shape's text frame and call [ITextFrame::HighlightText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/replacetext/), or [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/replaceregex/) on that text frame. Presentation-level methods process all applicable text frames instead.

**How can I match complete words with the correct capitalization?**

Call [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) and [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) with `true`, and pass the options to a literal-text highlighting or replacement method. For regular expressions, define word boundaries and case sensitivity in the `System::Text::RegularExpressions::Regex` itself.

**Can search and replacement include text in slide notes?**

Yes. Call [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/cpp/aspose.slides/itextsearchoptions/set_includenotes/) with `true` when using a presentation-level literal-text operation. The callback implementation shown above maps a match in a notes slide back to its parent slide number.

**How can I create a report without scanning the presentation a second time?**

Pass an [IFindResultCallback](https://reference.aspose.com/slides/cpp/aspose.slides/ifindresultcallback/) implementation to the highlighting or replacement operation. The callback receives every match while the operation runs, so the application can store the source text, matched text, position, text frame, and derived slide number for later grouping or export.

**Does replacing text preserve its formatting?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/replacetext/) and [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/replaceregex/) modify matched text within the existing text frame and retain the surrounding portion formatting. If a match spans portions with different formatting, inspect the result to ensure the replacement uses the desired style.
