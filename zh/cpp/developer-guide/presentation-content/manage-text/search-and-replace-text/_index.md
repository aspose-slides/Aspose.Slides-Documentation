---
title: 在 C++ 中搜索和替换 PowerPoint 演示文稿中的文本
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
description: "在使用 Aspose.Slides for C++ 的同时，搜索、突出显示并替换 PowerPoint 演示文稿中的文本，同时收集每个匹配项。"
---
## **概述**

Aspose.Slides for C++ 可以在单个文本框或整个演示文稿中搜索、突出显示和替换文本。每个操作还可以通过结果回调通知应用程序每个匹配项。这使得在更新演示文稿的同时能够构建包含匹配文本、其上下文、位置、文本框和幻灯片编号的审计跟踪。

这些功能对审阅、编辑、术语检查、模板清理以及自动化报告工作流非常有用。

在下面的第一个示例中，我们使用名为 “sample.pptx” 的文件，该文件在第一页上包含一个带有以下文本的单个文本框：

![示例文本](sample_text.png)

## **选择搜索范围**

在[ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/) 上使用方法将操作限制在单个文本框。 在[IPresentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/) 上使用方法处理演示文稿中所有适用的文本。

| 操作 | 单个文本框 | 整个演示文稿 |
|---|---|---|
| 突出显示字面文本 | [ITextFrame::HighlightText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/highlighttext/) |
| 突出显示正则表达式匹配 | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/highlightregex/) |
| 替换字面文本 | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/replacetext/) |
| 替换正则表达式匹配 | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/replaceregex/) |

## **配置文本匹配**

对于字面文本操作，使用[ITextSearchOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextsearchoptions/) 来控制匹配：

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) 仅限完整单词匹配。
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) 控制字符大小写是否必须匹配。
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextsearchoptions/set_includenotes/) 在演示文稿级别的搜索、替换和突出显示操作中包含幻灯片备注。

正则表达式操作使用 `System::Text::RegularExpressions::Regex`，因此诸如大小写敏感性和单词边界等匹配规则由表达式及其选项定义。

## **识别文本框的所有者**

通用文本处理工作流在搜索、替换、验证或导出文本时，通常会收到一个[ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/)。使用[ITextFrame::get_ParentShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/get_parentshape/)和[ITextFrame::get_ParentCell](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/get_parentcell/)可确定哪个演示对象拥有该文本框。

| 文本框所有者 | get_ParentShape | get_ParentCell |
|---|---|---|
| AutoShape 或其他包含文本的形状 | 拥有的[IShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/) | `nullptr` |
| 表格单元格 | `nullptr` | 拥有的[ICell](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icell/) |

两种方法均提供只读导航。调用它们不会移动文本框或更改其所有者。通用代码应检查两者是否为 `nullptr`，并处理两者均不可用的情况。

以下示例使用[SlideUtil::GetAllTextFrames](https://reference.aspose.com/slides/zh/cpp/aspose.slides.util/slideutil/getalltextframes/)遍历演示文稿中的文本框。对于形状，报告形状名称、C++ 运行时类型以及所在幻灯片；对于表格单元格，报告零基列行坐标以及所在幻灯片。

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

对于 SmartArt 内容，遍历[ISmartArtNode::get_Shapes](https://reference.aspose.com/slides/zh/cpp/aspose.slides.smartart/ismartartnode/get_shapes/)中的形状并访问每个[ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides.smartart/ismartartshape/get_textframe/)。文本框可通过[ITextFrame::get_ParentShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/get_parentshape/)追溯到其关联形状，而[ITextFrame::get_ParentCell](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/get_parentcell/)返回 `nullptr`。因此，示例中的形状分支也会处理来自 SmartArt 节点的文本。

## **使用回调收集匹配信息**

实现[IFindResultCallback](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifindresultcallback/)以接收每个匹配的通知。其[IFindResultCallback::FoundResult](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifindresultcallback/foundresult/)方法提供相关的文本框、源文本、匹配文本以及匹配位置。

回调不会直接接收幻灯片编号。下面的实现从[ISlideComponent::get_Slide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecomponent/get_slide/)中推导出编号，并通过[INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/inotesslide/get_parentslide/)处理在幻灯片备注中找到的文本。可为空的幻灯片编号允许相同的结果模型表示与其他幻灯片类型关联的文本。

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

对于替换操作，`FoundText` 包含原始匹配文本，回调因此能够准确记录哪些词被替换。

## **突出显示文本**

使用[ITextFrame::HighlightText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/highlighttext/)方法在文本框中突出显示字面文本匹配。传入[ITextSearchOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextsearchoptions/)以控制搜索，并提供回调收集匹配细节。

下面的代码示例先突出显示所有 **"try"** 字符出现的位置，然后仅突出显示完整单词 **"to"**。两次搜索均将匹配结果报告给同一回调。

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

[ITextFrame::HighlightRegex](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/highlightregex/)方法突出显示正则表达式在文本框中找到的匹配文本。

以下代码突出显示所有包含七个或更多字符的单词，并收集每个匹配：

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

使用[IPresentation::HighlightText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/highlighttext/)和[IPresentation::HighlightRegex](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/highlightregex/)在演示文稿中搜索所有适用的文本框。下面的示例同时突出显示一个字面词和所有电子邮件地址，并为两次搜索保持独立的结果集合。

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

使用[ITextFrame::ReplaceText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/replacetext/)进行字面文本替换，使用[ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/replaceregex/)进行基于模式的替换。这些方法在现有文本框内更新匹配文本，保留周围部分的格式，而不是通过纯字符串重新构建文本框。

以下示例统一拼写变体后再替换版本标签。相同的回调记录两次操作匹配的原始词汇。

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

如果一次匹配跨越格式不同的片段，请检查输出以确认替换文本应采用哪种格式。

## **跨演示文稿替换文本**

使用[IPresentation::ReplaceText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/replacetext/)和[IPresentation::ReplaceRegex](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/replaceregex/)在整个演示文稿中执行相同操作。这对模板清理、术语更新和编辑遮蔽非常有用。

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

## **对匹配进行分组以生成报告**

由于每个结果都存储了幻灯片编号和文本框，应用程序可以按审计、报告或审阅工作流对匹配进行分组。下面的示例先按幻灯片再按文本框对收集的结果进行分组：

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

## **常见问题**

**我如何仅搜索一个文本框而不是整个演示文稿？**

获取形状的文本框并在该文本框上调用[ITextFrame::HighlightText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/highlighttext/)、[ITextFrame::HighlightRegex](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/highlightregex/)、[ITextFrame::ReplaceText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/replacetext/)或[ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/replaceregex/)。演示文稿级别的方法会处理所有适用的文本框。

**我如何匹配完整单词且保持正确的大小写？**

对字面文本调用[ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/)和[ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextsearchoptions/set_casesensitive/)并设为 `true`，然后将这些选项传递给字面文本的突出显示或替换方法。对于正则表达式，在 `System::Text::RegularExpressions::Regex` 本身中定义单词边界和大小写敏感性。

**搜索和替换可以包含幻灯片备注中的文本吗？**

可以。对演示文稿级别的字面文本操作使用[ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextsearchoptions/set_includenotes/)并设为 `true`。上述回调实现会将备注幻灯片中的匹配映射回其父幻灯片编号。

**我如何在不二次扫描演示文稿的情况下创建报告？**

将[IFindResultCallback](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifindresultcallback/)实现传递给突出显示或替换操作。回调在操作进行时接收每个匹配，应用程序即可存储源文本、匹配文本、位置、文本框和派生的幻灯片编号，以便后续分组或导出。

**替换文本会保留其格式吗？**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/replacetext/)和[ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/replaceregex/)在现有文本框内修改匹配文本并保留周围部分的格式。如果一次匹配跨越格式不同的片段，请检查结果以确保替换使用所需的样式。