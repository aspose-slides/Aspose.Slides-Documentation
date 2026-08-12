---
title: 在 PowerPoint 演示文稿中使用 C++ 搜索和替换文本
linktitle: 搜索和替换文本
type: docs
weight: 55
url: /zh/cpp/search-and-replace-text/
keywords:
- 搜索文本
- 突出显示文本
- 替换文本
- 正则表达式
- 结果回调
- 文本框
- 审计报告
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "在 PowerPoint 演示文稿中搜索、突出显示和替换文本，同时使用 Aspose.Slides for C++ 收集每一次匹配。"
---
## **概述**

Aspose.Slides for C++ 可以在单个文本框或整个演示文稿中搜索、突出显示和替换文本。每个操作还可以通过结果回调通知应用程序每一次匹配。这使得在更新演示文稿的同时构建包含匹配文本、其上下文、位置、文本框和幻灯片编号的审计跟踪成为可能。

这些功能在审阅、编辑、术语检查、模板清理和自动化报告工作流中非常有用。

在下面的第一个示例中，我们使用名为 **"sample.pptx"** 的文件，该文件在第一张幻灯片上包含一个带有以下文本的单个文本框：

![示例文本](sample_text.png)

## **选择搜索范围**

使用 [ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/) 上的方法将操作限制在一个文本框内。使用 [IPresentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/) 上的方法处理演示文稿中所有适用的文本。

| 操作 | 单个文本框 | 整个演示文稿 |
|---|---|---|
| 突出显示文字字面值 | [ITextFrame::HighlightText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/highlighttext/) |
| 突出显示正则表达式匹配 | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/highlightregex/) |
| 替换文字字面值 | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/replacetext/) |
| 替换正则表达式匹配 | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/replaceregex/) |

## **配置文本匹配**

对于文字字面值操作，使用 [ITextSearchOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextsearchoptions/) 控制匹配方式：

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) 将匹配限制为完整单词。  
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) 控制是否必须匹配字符大小写。  
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextsearchoptions/set_includenotes/) 在演示文稿级别的搜索、替换和突出显示操作中包含幻灯片备注。

正则表达式操作使用 `System::Text::RegularExpressions::Regex`，因此大小写敏感性、单词边界等匹配规则由表达式及其选项定义。

## **通过回调收集匹配信息**

实现 [IFindResultCallback](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifindresultcallback/) 以接收每一次匹配的通知。其 [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifindresultcallback/foundresult/) 方法提供相关的文本框、源文本、匹配文本以及匹配位置。

回调并不会直接收到幻灯片编号。下面的实现通过 [ISlideComponent::get_Slide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecomponent/get_slide/) 推导出编号，并通过 [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/inotesslide/get_parentslide/) 处理备注幻灯片中的文本。可空的幻灯片编号允许相同的结果模型表示与其他幻灯片类型关联的文本。

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

对于替换操作，`FoundText` 包含原始匹配文本，因此回调可以准确记录被替换的词条。

## **突出显示文本**

使用 [ITextFrame::HighlightText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/highlighttext/) 方法在文本框中突出显示文字字面值匹配。传入 [ITextSearchOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextsearchoptions/) 以控制搜索，并提供回调收集匹配细节。

下面的代码示例先突出显示所有 **"try"** 字符出现，然后仅突出显示完整单词 **"to"**。两次搜索均将匹配结果报告给同一个回调。

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

结果：

![突出显示的文本](highlighted_text.png)

## **使用正则表达式突出显示文本**

[ITextFrame::HighlightRegex](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/highlightregex/) 方法在文本框中突出显示正则表达式找到的文本匹配。

下面的代码突出显示所有包含七个或更多字符的单词，并收集每一次匹配：

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

结果：

![使用正则表达式突出显示的文本](highlighted_text_using_regex.png)

## **跨演示文稿突出显示文本**

使用 [IPresentation::HighlightText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/highlighttext/) 和 [IPresentation::HighlightRegex](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/highlightregex/) 在演示文稿的所有适用文本框中搜索。以下示例突出显示一个文字字面值词以及所有电子邮件地址，并为两次搜索分别保留结果集合。

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

## **在文本框中替换文本**

对文字字面值使用 [ITextFrame::ReplaceText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/replacetext/)，对基于模式的替换使用 [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/replaceregex/)。这些方法在现有文本框内更新匹配文本，保留周围部分的格式，而不是通过纯字符串重新构建文本框。

下面的示例统一拼写变体，然后替换版本标签。相同的回调记录两次操作匹配的原始词条。

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

如果一次匹配跨越了不同格式的片段，请检查输出以确认替换文本应使用哪种格式。

## **跨演示文稿替换文本**

使用 [IPresentation::ReplaceText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/replacetext/) 和 [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/replaceregex/) 在整个演示文稿中执行相同的操作。这在模板清理、术语更新和编辑脱敏时非常有用。

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

## **将匹配分组以供报告**

由于每个结果都存储了幻灯片编号和文本框，应用程序可以根据审计、报告或审阅工作流对匹配进行分组。下面的示例先按幻灯片再按文本框对收集的结果进行分组：

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

## **常见问题解答**

**如何仅在一个文本框中搜索，而不是在整个演示文稿中搜索？**

获取形状的文本框，并对该文本框调用 [ITextFrame::HighlightText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/highlighttext/)、[ITextFrame::HighlightRegex](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/highlightregex/)、[ITextFrame::ReplaceText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/replacetext/) 或 [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/replaceregex/)。演示文稿级别的方法则会处理所有适用的文本框。

**如何匹配完整单词并确保大小写正确？**

对字面值搜索调用 [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) 和 [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) 并传入 `true`，然后将这些选项传递给文字字面值的突出显示或替换方法。对于正则表达式，请在 `System::Text::RegularExpressions::Regex` 本身中定义单词边界和大小写敏感性。

**搜索和替换可以包括幻灯片备注中的文本吗？**

可以。对演示文稿级别的文字字面值操作使用时，将 [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextsearchoptions/set_includenotes/) 设为 `true`。上面示例中的回调实现会将备注幻灯片中的匹配映射回其父幻灯片编号。

**如何在不二次扫描演示文稿的情况下生成报告？**

向突出显示或替换操作传入 [IFindResultCallback](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifindresultcallback/) 实现。回调在操作执行期间接收每一次匹配，从而可以在后续分组或导出时使用已经收集的源文本、匹配文本、位置、文本框以及推导出的幻灯片编号。

**替换文本会保留其格式吗？**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/replacetext/) 和 [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/replaceregex/) 在现有文本框内修改匹配文本并保留周围部分的格式。如果一次匹配跨越了不同格式的片段，请检查结果以确保替换使用期望的样式。