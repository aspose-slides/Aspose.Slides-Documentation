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
description: "在 PowerPoint 演示文稿中搜索、突出显示和替换文本，同时使用 Aspose.Slides for .NET 收集每一次匹配。"
---
## **概述**

Aspose.Slides for .NET 可以在单个文本框或整个演示文稿中搜索、突出显示和替换文本。每个操作还可以通过结果回调通知应用程序每一次匹配。这使得在更新演示文稿的同时能够构建包含匹配文本、其上下文、位置、文本框和幻灯片编号的审计轨迹。

这些功能适用于审阅、编辑、术语检查、模板清理和自动化报告工作流。

在下面的第一个示例中，我们使用名为“sample.pptx”的文件，该文件的首张幻灯片上有一个仅包含以下文本的文本框：

![示例文本](sample_text.png)

## **选择搜索范围**

对[ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/)使用方法以将操作限制在单个文本框。对[Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/)使用方法以处理演示文稿中所有适用的文本。

| 操作 | 单个文本框 | 整个演示文稿 |
|---|---|---|
| 突出显示字面文本 | [ITextFrame.HighlightText](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/highlighttext/) |
| 突出显示正则表达式匹配 | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/highlightregex/) |
| 替换字面文本 | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/replacetext/) |
| 替换正则表达式匹配 | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/replaceregex/) |

## **配置文本匹配**

对于字面文本操作，使用[TextSearchOptions](https://reference.aspose.com/slides/zh/net/aspose.slides/textsearchoptions/)来控制匹配方式：

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/zh/net/aspose.slides/textsearchoptions/wholewordsonly/) 将匹配限制为完整单词。
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/zh/net/aspose.slides/textsearchoptions/casesensitive/) 控制是否必须匹配字符大小写。
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/zh/net/aspose.slides/textsearchoptions/includenotes/) 在演示文稿级搜索、替换和突出显示操作中包含幻灯片备注。

正则表达式操作使用 .NET `Regex`，因此大小写敏感性和单词边界等匹配规则由表达式本身及其选项决定。

## **确定文本框的拥有者**

通用文本处理工作流在搜索、替换、验证或导出文本时通常会接收到[ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/)。使用[ITextFrame.ParentShape](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/parentshape/)和[ITextFrame.ParentCell](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/parentcell/)来确定哪个演示对象拥有该文本框。

预期值取决于拥有者：

| 文本框拥有者 | `ParentShape` | `ParentCell` |
|---|---|---|
| AutoShape或其他包含文本的形状 | 拥有该形状的[IShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/) | `null` |
| 表格单元格 | `null` | 拥有该单元格的[ICell](https://reference.aspose.com/slides/zh/net/aspose.slides/icell/) |

这两个属性都是只读导航属性。读取它们不会移动文本框或更改其拥有者。通用代码应检查两个值是否为`null`，并处理两者均不可用的情况。

以下示例使用[SlideUtil.GetAllTextFrames](https://reference.aspose.com/slides/zh/net/aspose.slides.util/slideutil/getalltextframes/)遍历演示文稿中的所有文本框。对于形状，它报告形状名称、形状类型以及所在幻灯片；对于表格单元格，它报告零基列号、行号以及所在幻灯片。

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation("presentation.pptx");

var textFrames = SlideUtil.GetAllTextFrames(presentation, false);

foreach (var textFrame in textFrames)
{
    var ownerShape = textFrame.ParentShape;
    if (ownerShape != null)
    {
        var shapeName = string.IsNullOrEmpty(ownerShape.Name) ? "(unnamed)" : ownerShape.Name;
        var shapeType = GetShapeType(ownerShape);
        var slideLabel = GetSlideLabel(ownerShape.Slide);
        Console.WriteLine($"Shape: {shapeName}; type: {shapeType}; {slideLabel}");

        continue;
    }

    var ownerCell = textFrame.ParentCell;
    if (ownerCell != null)
    {
        var slideLabel = GetSlideLabel(ownerCell.Slide);
        Console.WriteLine($"Table cell: column {ownerCell.FirstColumnIndex}, row {ownerCell.FirstRowIndex}; {slideLabel}");
        continue;
    }

    Console.WriteLine("The text frame owner is not available as a shape or table cell.");
}

static string GetShapeType(IShape shape)
{
    if (shape is IGeometryShape geometryShape)
    {
        return geometryShape.ShapeType.ToString();
    }

    return shape.GetType().Name;
}

static string GetSlideLabel(IBaseSlide baseSlide)
{
    if (baseSlide is ISlide slide)
    {
        return $"slide {slide.SlideNumber}";
    }

    if (baseSlide is INotesSlide notesSlide)
    {
        return $"notes for slide {notesSlide.ParentSlide.SlideNumber}";
    }

    return baseSlide.GetType().Name;
}
```

对于 SmartArt 内容，遍历[ISmartArtNode.Shapes](https://reference.aspose.com/slides/zh/net/aspose.slides.smartart/ismartartnode/shapes/)中的形状并访问每个[ISmartArtShape.TextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides.smartart/ismartartshape/textframe/)。文本框可通过[ITextFrame.ParentShape](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/parentshape/)追溯到其关联形状，而[ITextFrame.ParentCell](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/parentcell/)为`null`。因此，示例中的形状分支同样处理来自 SmartArt 节点的文本。

## **使用回调收集匹配信息**

实现[IFindResultCallback](https://reference.aspose.com/slides/zh/net/aspose.slides/ifindresultcallback/)以接收每一次匹配的通知。其[IFindResultCallback.FoundResult](https://reference.aspose.com/slides/zh/net/aspose.slides/ifindresultcallback/foundresult/)方法提供相关的文本框、源文本、匹配文本以及匹配位置。

回调不会直接收到幻灯片编号。下面的实现从父幻灯片中推导出编号，并且同样处理在幻灯片备注中找到的文本。可空的幻灯片编号使得相同的结果模型能够表示关联到其他类型幻灯片的文本。

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
        var parentSlide = textFrame.ParentShape?.Slide ?? textFrame.ParentCell?.Slide ?? textFrame.Slide;

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

对于替换操作，`FoundText` 包含原始匹配文本，因此回调可以准确记录哪些词被替换。

## **突出显示文本**

使用[ITextFrame.HighlightText](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/highlighttext/)方法在文本框中突出显示字面文本匹配。传入[TextSearchOptions](https://reference.aspose.com/slides/zh/net/aspose.slides/textsearchoptions/)以控制搜索，并提供回调以收集匹配细节。

下面的代码示例先突出显示所有出现的字符**“try”**，然后仅突出显示完整单词**“to”**。两次搜索都将匹配报告给同一个回调。

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// 获取首张幻灯片上的第一个形状。
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// 在文本框中突出显示所有出现的 "try"。
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// 仅突出显示完整单词 "to"。
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

结果：

![突出显示的文本](highlighted_text.png)

## **使用正则表达式突出显示文本**

[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/highlightregex/)方法突出显示文本框中由正则表达式找到的匹配文本。

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

![使用正则表达式的突出显示文本](highlighted_text_using_regex.png)

## **跨演示文稿突出显示文本**

使用[Presentation.HighlightText](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/highlighttext/)和[Presentation.HighlightRegex](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/highlightregex/)在演示文稿中搜索所有适用的文本框。以下示例突出显示一个字面词和所有电子邮件地址，并为两次搜索保持独立的结果集合。

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

使用[ITextFrame.ReplaceText](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/replacetext/)进行字面文本替换，使用[ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/replaceregex/)进行基于模式的替换。这些方法在现有文本框内部更新匹配的文本，保留其周围部分的格式，而不是从纯字符串重新构建文本框。

下面的示例统一 spelling 变体，然后替换版本标签。相同的回调记录两次操作匹配的原始词。

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

如果一次匹配跨越了不同格式的部分，请检查输出以确认应使用哪种格式进行替换。

## **跨演示文稿替换文本**

使用[Presentation.ReplaceText](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/replacetext/)和[Presentation.ReplaceRegex](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/replaceregex/)在整个演示文稿中执行相同操作。这对于模板清理、术语更新和编辑非常有用。

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

## **将匹配分组用于报告**

因为每个结果都存储了幻灯片编号和文本框，应用程序可以对匹配进行分组，以实现审计、报告或审阅工作流。下面的示例先按幻灯片分组，再按文本框分组收集的结果：

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

获取形状的文本框，然后在该文本框上调用[ITextFrame.HighlightText](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/highlighttext/)、[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/highlightregex/)、[ITextFrame.ReplaceText](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/replacetext/)或[ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/replaceregex/)。演示文稿级方法会处理所有适用的文本框。

**如何匹配完整单词并保留正确的大小写？**

将[TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/zh/net/aspose.slides/textsearchoptions/wholewordsonly/)和[TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/zh/net/aspose.slides/textsearchoptions/casesensitive/)设为 `true`，并将选项传递给字面文本的突出显示或替换方法。对于正则表达式，在 .NET `Regex` 本身中定义单词边界和大小写敏感性。

**搜索和替换可以包括幻灯片备注中的文本吗？**

可以。使用演示文稿级字面文本操作时，将[TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/zh/net/aspose.slides/textsearchoptions/includenotes/)设为 `true`。上面示例的回调实现会将备注幻灯片中的匹配映射回其父幻灯片编号。

**如何在不二次扫描演示文稿的情况下创建报告？**

将[IFindResultCallback](https://reference.aspose.com/slides/zh/net/aspose.slides/ifindresultcallback/)实现传递给突出显示或替换操作。回调在操作运行时接收每一次匹配，应用程序即可存储源文本、匹配文本、位置、文本框以及派生的幻灯片编号，以便后续分组或导出。

**替换文本会保留其格式吗？**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/replacetext/)和[ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/replaceregex/)在现有文本框内部修改匹配文本，并保留周围部分的格式。如果匹配跨越了不同格式的区域，请检查结果以确保替换使用所需的样式。