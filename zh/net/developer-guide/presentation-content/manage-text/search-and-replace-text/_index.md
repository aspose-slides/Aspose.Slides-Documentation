---
title: 在 .NET 中搜索和替换 PowerPoint 演示文稿中的文本
linktitle: 搜索和替换文本
type: docs
weight: 55
url: /zh/net/search-and-replace-text/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 演示文稿中搜索、突出显示和替换文本，同时收集每一次匹配。"
---
## **概览**

Aspose.Slides for .NET 可以在单个文本框或整个演示文稿中搜索、突出显示和替换文本。每项操作都可以通过结果回调向应用程序通知每一次匹配。这使得在更新演示文稿的同时能够构建包含匹配文本、其上下文、位置、文本框和幻灯片编号的审计轨迹。

这些功能在审阅、编辑、术语检查、模板清理和自动化报告工作流中非常有用。

在下面的第一个示例中，我们使用名为 **sample.pptx** 的文件，该文件在第一页的单个文本框中包含以下文本：

![Sample text](sample_text.png)

## **选择搜索范围**

使用 [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/) 上的方法将操作限制在一个文本框内。使用 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 上的方法处理演示文稿中所有适用的文本。

| 操作 | 单个文本框 | 整个演示文稿 |
|---|---|---|
| 突出显示字面文本 | [ITextFrame.HighlightText](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/highlighttext/) |
| 突出显示正则表达式匹配 | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/highlightregex/) |
| 替换字面文本 | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/replacetext/) |
| 替换正则表达式匹配 | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/replaceregex/) |

## **配置文本匹配**

对于字面文本操作，使用 [TextSearchOptions](https://reference.aspose.com/slides/zh/net/aspose.slides/textsearchoptions/) 控制匹配方式：

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/zh/net/aspose.slides/textsearchoptions/wholewordsonly/) 将匹配限制为完整单词。
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/zh/net/aspose.slides/textsearchoptions/casesensitive/) 控制是否必须区分字符大小写。
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/zh/net/aspose.slides/textsearchoptions/includenotes/) 在演示文稿级别的搜索、替换和突出显示操作中包含幻灯片备注。

正则表达式操作使用 .NET `Regex`，因此诸如区分大小写和单词边界等匹配规则由表达式本身及其选项决定。

## **使用回调收集匹配信息**

实现 [IFindResultCallback](https://reference.aspose.com/slides/zh/net/aspose.slides/ifindresultcallback/) 以在每次匹配时收到通知。其 [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/zh/net/aspose.slides/ifindresultcallback/foundresult/) 方法提供相关的文本框、源文本、匹配文本以及匹配位置。

回调本身不直接接收幻灯片编号。下面的实现从父幻灯片中推导该编号，并且还能处理幻灯片备注中的文本。可为空的幻灯片编号允许同一结果模型表示与其他幻灯片类型关联的文本。

```cs
using System.Collections.Generic;
using Aspose.Slides;

public sealed class TextMatch
{
    public TextMatch(ITextFrame textFrame, string sourceText, string foundText, int textPosition, int? slideNumber)
    {
        TextFrame = textFrame;
        SourceText = sourceText;
        FoundText = foundText;
        TextPosition = textPosition;
        SlideNumber = slideNumber;
    }

    public ITextFrame TextFrame { get; }
    public string SourceText { get; }
    public string FoundText { get; }
    public int TextPosition { get; }
    public int? SlideNumber { get; }
}

public sealed class TextSearchCallback : IFindResultCallback
{
    public List<TextMatch> Results { get; } = new();

    public void FoundResult(ITextFrame textFrame, string sourceText, string foundText, int textPosition)
    {
        var slideNumber = GetSlideNumber(textFrame);
        var result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);

        Results.Add(result);
    }

    private static int? GetSlideNumber(ITextFrame textFrame)
    {
        if (textFrame is not TextFrame concreteTextFrame)
        {
            return null;
        }

        var parentSlide = concreteTextFrame.Slide;

        if (parentSlide is ISlide slide)
        {
            return slide.SlideNumber;
        }

        if (parentSlide is INotesSlide notesSlide)
        {
            return notesSlide.ParentSlide.SlideNumber;
        }

        return null;
    }
}
```

对于替换操作，`FoundText` 包含原始匹配文本，从而回调可以准确记录被替换的术语。

## **突出显示文本**

使用 [ITextFrame.HighlightText](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/highlighttext/) 方法在文本框中突出显示字面文本匹配。传入 [TextSearchOptions] 以控制搜索，并提供回调以收集匹配细节。

下面的代码示例先突出显示所有 **"try"** 出现位置，然后仅突出显示完整单词 **"to"**。两个搜索均将匹配报告给同一个回调。

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Get the first shape from the first slide.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Highlight every occurrence of "try" in the text frame.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Highlight only the complete word "to".
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

结果：

![The highlighted text](highlighted_text.png)

## **使用正则表达式突出显示文本**

[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/highlightregex/) 方法在文本框中突出显示由正则表达式找到的文本匹配。

下面的代码突出显示所有包含七个或更多字符的单词，并收集每一次匹配：

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var regex = new Regex(@"\b[^\s]{7,}\b");

shape.TextFrame.HighlightRegex(regex, Color.Yellow, callback);

presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
```

结果：

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **在整个演示文稿中突出显示文本**

使用 [Presentation.HighlightText](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/highlighttext/) 和 [Presentation.HighlightRegex](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/highlightregex/) 在演示文稿的所有适用文本框中搜索。下面的示例突出显示一个字面术语以及所有电子邮件地址，并为两次搜索分别保留结果集合。

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var termCallback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

presentation.HighlightText("confidential", Color.Orange, searchOptions, termCallback);

var emailCallback = new TextSearchCallback();
var emailRegex = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b", RegexOptions.IgnoreCase);

presentation.HighlightRegex(emailRegex, Color.Yellow, emailCallback);

presentation.Save("highlighted_presentation.pptx", SaveFormat.Pptx);
```

## **在文本框中替换文本**

使用 [ITextFrame.ReplaceText](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/replacetext/) 进行字面文本替换，使用 [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/replaceregex/) 进行基于模式的替换。这些方法在现有文本框内部更新匹配文本，保留周围部分的格式，而不是从普通字符串重新构建文本框。

下面的示例标准化一种拼写变体，然后替换版本标签。相同的回调记录两项操作匹配的原始术语。

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

shape.TextFrame.ReplaceText("colour", "color", searchOptions, callback);

var versionRegex = new Regex(@"\bv\d+(?:\.\d+)*\b", RegexOptions.IgnoreCase);
shape.TextFrame.ReplaceRegex(versionRegex, "current version", callback);

presentation.Save("updated_text_frame.pptx", SaveFormat.Pptx);
```

如果一次匹配跨越了具有不同格式的片段，请检查输出以确认替换文本应采用哪种格式。

## **在整个演示文稿中替换文本**

使用 [Presentation.ReplaceText](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/replacetext/) 和 [Presentation.ReplaceRegex](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/replaceregex/) 在演示文稿范围内执行相同的操作。此功能适用于模板清理、术语更新和编辑脱敏。

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};

presentation.ReplaceText("Contoso", "Example Corp", searchOptions, callback);

var accountNumberRegex = new Regex(@"\bACCT-\d{6}\b");
presentation.ReplaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

presentation.Save("updated_presentation.pptx", SaveFormat.Pptx);
```

## **对匹配进行分组以生成报告**

因为每个结果都存储了其幻灯片编号和文本框，应用程序可以按审计、报告或审阅工作流对匹配进行分组。下面的示例先按幻灯片，再按文本框对收集的结果进行分组：

```cs
using System;
using System.Linq;

var matchesBySlide = callback.Results.GroupBy(result => result.SlideNumber);

foreach (var slideGroup in matchesBySlide)
{
    var slideLabel = slideGroup.Key.HasValue ? slideGroup.Key.Value.ToString() : "Other";
    Console.WriteLine($"Slide: {slideLabel}");

    var matchesByTextFrame = slideGroup.GroupBy(result => result.TextFrame);
    foreach (var textFrameGroup in matchesByTextFrame)
    {
        Console.WriteLine($"  Text frame: {textFrameGroup.Key.Text}");

        foreach (var result in textFrameGroup)
        {
            Console.WriteLine($"    '{result.FoundText}' at position {result.TextPosition}; context: '{result.SourceText}'");
        }
    }
}
```

## **常见问题**

**如何只搜索单个文本框而不是整个演示文稿？**

获取形状的文本框并在该文本框上调用 [ITextFrame.HighlightText](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/highlighttext/)、[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/highlightregex/)、[ITextFrame.ReplaceText](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/replacetext/) 或 [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/replaceregex/)。演示文稿级别的方法会处理所有适用的文本框。

**如何匹配完整单词并保持正确的大小写？**

将 [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/zh/net/aspose.slides/textsearchoptions/wholewordsonly/) 和 [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/zh/net/aspose.slides/textsearchoptions/casesensitive/) 均设置为 `true`，并将这些选项传递给字面文本的突出显示或替换方法。对于正则表达式，在 .NET `Regex` 本身中定义单词边界和大小写敏感性。

**搜索和替换是否可以包括幻灯片备注中的文本？**

可以。对演示文稿级别的字面文本操作使用时，将 [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/zh/net/aspose.slides/textsearchoptions/includenotes/) 设置为 `true`。上面的回调实现会将备注页中的匹配映射回其父幻灯片编号。

**如何在不再次扫描演示文稿的情况下生成报告？**

向突出显示或替换操作传入 [IFindResultCallback](https://reference.aspose.com/slides/zh/net/aspose.slides/ifindresultcallback/) 实现。回调在操作执行期间接收每一次匹配，应用程序即可存储源文本、匹配文本、位置、文本框以及派生的幻灯片编号，以便后续分组或导出。

**替换文本时会保留其格式吗？**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/replacetext/) 与 [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/replaceregex/) 会在现有文本框内部修改匹配文本并保留周围部分的格式。如果一次匹配跨越了不同格式的片段，请检查结果以确保替换使用所需的样式。