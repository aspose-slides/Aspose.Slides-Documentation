---
title: 在 .NET 中格式化演示文稿文本
linktitle: 文本格式化
type: docs
weight: 50
url: /zh/net/text-formatting/
keywords:
- 突出显示文本
- 正则表达式
- 段落对齐
- 文本样式
- 文本背景
- 文本透明度
- 字符间距
- 字体属性
- 字体系列
- 文本旋转
- 旋转角度
- 文本框
- 行距
- 自动适应属性
- 文本框锚点
- 文本制表
- 默认语言
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 演示文稿中格式化和样式化文本。自定义字体、颜色、对齐方式等。"
---

## **概述**

本文介绍如何使用 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 演示文稿中管理和格式化文本。您将学习如何应用字体选择、大小、颜色、突出显示、背景颜色、间距和对齐等文本格式化功能。此外，还涵盖了文本框、段落、格式化以及自定义旋转和自动适应行为等高级布局选项。

无论是编程生成演示文稿还是自定义现有内容，这些示例都可以帮助您创建清晰、专业的文本布局，提升幻灯片的视觉效果并提高可读性。

在下面的示例中，我们将使用名为 **sample.pptx** 的文件，该文件在第一张幻灯片上包含一个带有以下文本的单个文本框：

![示例文本](sample_text.png)

## **突出显示文本**

[ITextFrame.HighlightText](https://reference.aspose.com/slides/net/aspose.slides/itextframe/highlighttext/) 方法允许根据匹配的文本样本使用背景颜色突出显示文本的一部分。

使用此方法，请按以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类并提供输入文件（PPT、PPTX、ODP 等）。
1. 使用 [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) 集合访问所需的幻灯片。
1. 从 [Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) 集合获取目标形状并将其转换为 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)。
1. 使用 [ITextFrame.HighlightText](https://reference.aspose.com/slides/net/aspose.slides/itextframe/highlighttext/) 方法并提供示例文本和颜色来突出显示所需的文本。
1. 将演示文稿保存为所需的输出格式（例如 PPT、PPTX、ODP）。

下面的代码示例突出显示字符 **"try"** 的所有出现以及完整单词 **"to"**。
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // 获取第一张幻灯片中的第一个形状。
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // 在形状中突出显示单词 "try"。
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // 在形状中突出显示单词 "to"。
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```


结果：

![突出显示的文本](highlighted_text.png)

{{% alert color="primary" %}} 

Aspose 提供了一个简洁的，[免费在线 PowerPoint 编辑器](https://products.aspose.app/slides/editor)。

{{% /alert %}} 

## **使用正则表达式突出显示文本**

Aspose.Slides for .NET 允许使用正则表达式搜索并突出显示 PowerPoint 幻灯片中的特定文本部分。该功能在需要动态强调关键字、模式或数据驱动内容时非常有用。[ITextFrame.HighlightRegex](https://docs.aspose.com/slides/net/text-formatting/) 方法允许使用正则表达式通过背景颜色突出显示文本的部分。

下面的代码示例突出显示所有包含 **七个或更多字符** 的单词：
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // 突出显示所有包含七个或更多字符的单词。
    shape.TextFrame.HighlightRegex(@"\b[^\s]{7,}\b", Color.Yellow, null);

    presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```


结果：

![使用正则表达式突出显示的文本](highlighted_text_using_regex.png)

## **设置文本背景颜色**

Aspose.Slides for .NET 使您能够为 PowerPoint 幻灯片中的整个段落或单个文本片段应用背景颜色。当您想突出显示特定词语或短语、吸引关键消息的注意或提升演示文稿的视觉吸引力时，此功能非常实用。

以下代码示例展示如何为 **整个段落** 设置背景颜色： 
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 为整个段落设置突出显示颜色。
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```


结果：

![灰色段落](gray_paragraph.png)

下面的代码示例演示如何为 **带粗体的文本片段** 设置背景颜色：
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // 为文本片段设置突出显示颜色。
            portion.PortionFormat.HighlightColor.Color = Color.LightGray;
        }
    }

    presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
}
```


结果：

![灰色文本段](gray_text_portions.png)

## **对齐文本段落**

文本对齐是幻灯片格式化的关键方面，影响可读性和视觉吸引力。在 Aspose.Slides for .NET 中，您可以精确控制文本框内段落的对齐方式，确保内容始终如一地呈现——无论是居中、左对齐、右对齐还是两端对齐。本节说明如何在 PowerPoint 演示文稿中应用和自定义文本对齐。

以下代码示例展示如何将段落对齐到 **居中**：
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 将段落的对齐方式设置为居中。
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```


结果：

![已对齐的段落](aligned_paragraph.png)

## **设置文本透明度**

调整文本透明度可以创建细腻的视觉效果并提升幻灯片美感。Aspose.Slides for .NET 提供了为段落和文本片段设置透明度级别的功能，使您能够轻松将文本与背景融合或强调特定元素。本节展示如何在演示文稿中为文本应用透明度设置。

下面的代码示例展示如何为 **整个段落** 应用透明度：
```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 将文本的填充颜色设置为透明颜色。
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```


结果：

![透明段落](transparent_paragraph.png)

以下代码示例展示如何为 **带粗体的文本片段** 应用透明度：
```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // 设置文本片段的透明度。
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
        }
    }

    presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
}
```


结果：

![透明文本段](transparent_text_portions.png)

## **设置文本字符间距**

Aspose.Slides 允许您设置文本框中字符之间的间距。这样，您可以通过扩展或压缩字符之间的空间来调整行或块的视觉密度。

以下 C# 代码展示如何在 **整个段落** 中扩展字符间距：
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 注意：使用负值来压缩字符间距。
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // 扩大字符间距。

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```


结果：

![段落中的字符间距](character_spacing_in_paragraph.png)

下面的代码示例展示如何在 **带粗体的文本片段** 中扩展字符间距：
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // 注意：使用负值来压缩字符间距。
            portion.PortionFormat.Spacing = 3;  // 扩大字符间距。
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```


结果：

![文本段中的字符间距](character_spacing_in_text_portions.png)

## **管理文本字体属性**

Aspose.Slides for .NET 允许您在段落层面和单个文本片段层面微调字体设置，确保视觉一致性并满足演示文稿的设计需求。您可以为整个段落定义字体样式、大小和其他格式选项，从而更好地控制文本外观。本节演示如何在幻灯片中管理文本段落的字体属性。

以下代码为整个段落设置字体和文本样式：它对段落中的所有片段应用字体大小、粗体、斜体、点状下划线以及 Times New Roman 字体。
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 设置段落的字体属性。
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 12;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontItalic = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontUnderline = TextUnderlineType.Dotted;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Times New Roman");

    presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
}
```


结果：

![段落的字体属性](font_properties_for_paragraph.png)

下面的代码示例对 **带粗体的文本片段** 应用类似属性：
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // 设置文本片段的字体属性。
            portion.PortionFormat.FontHeight = 13;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
            portion.PortionFormat.LatinFont = new FontData("Times New Roman");
        }
    }

    presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
}
```


结果：

![文本段的字体属性](font_properties_for_text_portions.png)

## **设置文本旋转**

文本旋转可以改善幻灯片布局并帮助突出特定内容。使用 Aspose.Slides for .NET，您可以轻松在形状内为文本应用旋转，调整角度以匹配设计需求。本节演示如何设置和控制文本旋转以实现所需的视觉效果。

以下代码示例将形状中的文本方向设置为 `Vertical270`，这会使文本 **逆时针旋转 90 度**：
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```


结果：

![文本旋转](text_rotation.png)

## **为文本框设置自定义旋转**

为 `TextFrame` 设置自定义旋转角度可让您将文本定位在精确的角度，从而实现更具创意和灵活性的幻灯片设计。Aspose.Slides for .NET 提供对文本框旋转的完整控制，便于将文本与其他幻灯片元素对齐。本节指导您为 `TextFrame` 应用特定的旋转角度。

下面的代码示例在形状内将文本框顺时针旋转 3 度： 
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```


结果：

![自定义文本旋转](custom_text_rotation.png)

## **设置段落行距**

Aspose.Slides 在 [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/) 类下提供 `SpaceAfter`、`SpaceBefore` 和 `SpaceWithin` 属性，允许您管理段落的行距。这些属性的使用方式如下：

* 使用正值指定行距为行高的百分比。
* 使用负值指定行距（单位：磅）。

以下代码示例展示如何在段落内部指定行距：
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```


结果：

![段落中的行距](line_spacing.png)

## **设置文本框的自动适应类型**

AutoFitType 属性决定当文本超出容器边界时的行为方式。Aspose.Slides for .NET 允许您控制文本是缩小以适应、溢出还是自动调整形状大小。本节演示如何为 `TextFrame` 设置 `AutofitType` 以在形状内有效管理文本布局。
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```


## **设置文本框的锚点**

锚点定义文本在形状内部的垂直定位方式。使用 Aspose.Slides for .NET，您可以设置 `TextFrame` 的锚点类型，将文本对齐到形状的顶部、中部或底部。本节展示如何调整锚点设置，以实现所需的文本垂直对齐。
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```


## **设置文本制表位**

制表位通过在内容元素之间添加一致的间距，帮助组织文本形成结构良好的布局。Aspose.Slides for .NET 支持在文本段落中设置自定义制表位，允许对文本定位进行精确控制。本节演示如何配置文本制表位，以改进对齐和格式化。
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.DefaultTabSize = 100;
    paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

    presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
}
```


结果：

![段落制表位](paragraph_tabs.png)

## **设置校对语言**

Aspose.Slides 提供了 [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) 类的 `LanguageId` 属性，可为 PowerPoint 文档设置校对语言。校对语言决定 PowerPoint 中的拼写和语法检查使用的语言。

以下代码示例展示如何为文本片段设置校对语言：
```cs
using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    var font = new FontData("SimSun");

    var textPortion = new Portion();
    textPortion.PortionFormat.ComplexScriptFont = font;
    textPortion.PortionFormat.EastAsianFont = font;
    textPortion.PortionFormat.LatinFont = font;

    // 设置校对语言的 Id。
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```


## **设置默认语言**

为文本指定默认语言可确保 PowerPoint 中的拼写检查、断字以及文本转语音功能的正确性。Aspose.Slides for .NET 允许您在文本片段或段落层面设置语言。本节展示如何为演示文稿文本定义默认语言。
```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // 添加一个带文本的矩形形状。
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // 检查第一个文本片段的语言。
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```


## **设置默认文本样式**

如果需要一次性为演示文稿中的所有文本元素应用相同的默认文本格式，可使用 [IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/) 接口的 `DefaultTextStyle` 属性并定义首选的格式。

以下代码示例展示如何在新演示文稿中为所有幻灯片的文本设置 14 磅、粗体的默认字体。
```cs
using (var presentation = new Presentation())
{
    // 获取顶层段落格式。
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```


## **提取带全大写效果的文本**

在 PowerPoint 中，应用 **All Caps** 字体效果会使文本在幻灯片上显示为大写，即使原始输入为小写。当使用 Aspose.Slides 检索此类文本片段时，库会返回实际输入的文本。为处理此情况，请检查 [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/)——如果其指示为 `All`，则只需将返回的字符串转换为大写，以确保输出与用户在幻灯片上看到的内容一致。

假设我们在 sample2.pptx 文件的第一张幻灯片上有如下文本框。

![全大写效果](all_caps_effect.png)

下面的代码示例展示如何提取带 **All Caps** 效果的文本：
```cs
using (var presentation = new Presentation("sample2.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

    Console.WriteLine($"Original text: {textPortion.Text}");

    var textFormat = textPortion.PortionFormat.GetEffective();
    if (textFormat.TextCapType == TextCapType.All)
    {
        var text = textPortion.Text.ToUpper();
        Console.WriteLine($"All-Caps effect: {text}");
    }
}
```


输出：
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **常见问题**

**如何修改幻灯片中表格的文本？**

要修改幻灯片中表格的文本，需要使用 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 对象。您可以遍历表格中的所有单元格，通过访问每个单元格的 `TextFrame` 和 `ParagraphFormat` 属性来更改其中的文本。

**如何在 PowerPoint 幻灯片的文本上应用渐变颜色？**

要为文本应用渐变颜色，请使用 [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) 中的 `FillFormat` 属性。将 `FillFormat` 设置为 `Gradient`，并定义渐变的起止颜色以及方向、透明度等其他属性，以在文本上创建渐变效果。