---
title: 在 .NET 中格式化演示文稿文本
linktitle: 文本格式化
type: docs
weight: 50
url: /zh/net/text-formatting/
keywords:
- 对齐段落
- 文本样式
- 文本背景
- 文本透明度
- 字符间距
- 字体属性
- 字体族
- 文本旋转
- 旋转角度
- 文本框
- 行间距
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
description: "使用 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 演示文稿中格式化和设置文本样式。自定义字体、颜色、对齐方式等。"
---
## **概述**

本文介绍如何使用 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 演示文稿中格式化文本。内容涵盖背景颜色、透明度、字符间距、字体属性、旋转、段落间距、自动适应行为、文本锚定、制表位和语言设置。

除非另有说明，示例均使用 [sample.pptx](sample.pptx)。第一张幻灯片的第一个形状是一个文本框，其第一段包含下文所示的文本。幻灯片和形状索引均从零开始。选择粗体部分的示例使用有效格式，包括继承的粗体格式：

![Sample text](sample_text.png)

要查找并突出显示文字字面量或正则表达式匹配，请参阅 [Search and Replace Text](/slides/zh/net/search-and-replace-text/)。

## **设置文本背景颜色**

使用 [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) 为段落设置默认高亮颜色，或使用 [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) 为单独的文本片段设置高亮颜色。

以下示例将浅灰色高亮设置为第一段的默认颜色。对单独片段的显式高亮颜色会优先于此默认设置：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 为整个段落设置高亮颜色。
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

结果：

![The gray paragraph](gray_paragraph.png)

下面的代码示例演示如何为 **粗体字体的文本片段** 设置背景颜色：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
            // 为文本片段设置高亮颜色。
            portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

结果：

![The gray text portions](gray_text_portions.png)

## **对齐文本段落**

使用 [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) 在文本框内设置段落对齐方式。可选值包括居中、左对齐、右对齐、两端对齐等。

以下代码示例演示如何将段落对齐至 **居中**：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 将段落的对齐方式设置为居中。
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

结果：

![The aligned paragraph](aligned_paragraph.png)

## **在行内对齐字体**

使用 [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) 将不同字体尺寸的文本片段在同一行内垂直对齐。此设置适用于整个段落，并控制每行内部的对齐方式。

以下独立示例在同一张幻灯片上创建四个带标签的文本框。每个段落在 18、36、54 磅时使用相同的文本，但字体对齐方式不同。示例使用 Arial，禁用自动适应和换行，并保持文本框足够宽以容纳单行。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var alignments = new[] { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
var fontSizes = new[] { 18f, 36f, 54f };

for (var i = 0; i < alignments.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;

    var label = textFrame.Paragraphs[0];
    label.Text = alignments[i].ToString();
    label.ParagraphFormat.Alignment = TextAlignment.Left;
    label.ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
    label.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.FontAlignment = alignments[i];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

    foreach (var fontSize in fontSizes)
    {
        var portion = new Portion("Ag ");
        portion.PortionFormat.FontHeight = fontSize;
        paragraph.Portions.Add(portion);
    }

    textFrame.Paragraphs.Add(paragraph);
}

presentation.Save("font_alignment.pptx", SaveFormat.Pptx);
```

结果：

![Comparison of Baseline, Top, Center, and Bottom font alignment with mixed font sizes](font_alignment.png)

字体对齐基于字体度量，因此各个字母的可见边缘不一定完全对齐。示例中同时包含大写字母和下行字，以帮助展示基线与底部对齐的区别。字体可用性与替代、所用字符以及字体尺寸差异都会影响结果。框的尺寸、边距、行距、换行和自动适应也会影响布局；比较模式时请使用相同的字体和布局设置。

此设置不同于 [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/)，后者控制水平段落对齐；也不同于 [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/)，后者在形状内部垂直定位文本块。通过 [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) 实现的上标和下标格式会相对于基线移动单个片段，而不是为段落行设置字体对齐。

## **设置文本透明度**

文本透明度通过分配给 [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) 的颜色的 alpha 分量来控制。下例中，`alpha = 50` 是 0–255 范围内的 ARGB alpha 通道值，而非透明度百分比。

下面的代码示例展示如何对 **整个段落** 应用透明度：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 为文本设置半透明的黑色填充。
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

结果：

![The transparent paragraph](transparent_paragraph.png)

以下代码示例展示如何对 **粗体字体的文本片段** 应用透明度：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
            // 为文本片段设置透明度。
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

结果：

![The transparent text portions](transparent_text_portions.png)

## **设置文本字符间距**

使用 [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) 可以在文本框中的字符之间增加或压缩间距。示例中添加了 3 磅的间距；负值则会压缩文本。

以下 C# 代码展示如何在 **整个段落** 中扩大字符间距：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 注意：使用负值来压缩字符间距。
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // 扩展字符间距。

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

结果：

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

下面的代码示例展示如何在 **粗体字体的文本片段** 中扩大字符间距：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // 注意：使用负值来压缩字符间距。
        portion.PortionFormat.Spacing = 3;  // 扩展字符间距。
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

结果：

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **为特定字体禁用字距调整（Kerning）**

在某些情况下，Aspose.Slides 渲染的文本看起来比 PowerPoint 中的同一文本稍紧。这可能是因为 PowerPoint 会忽略某些字体的字距调整数据，即使该字体包含有效的字距信息且在 PowerPoint 设置中已启用字距调整。

为使渲染输出更接近 PowerPoint，可为使用受影响字体的文本片段禁用字距调整。将 [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) 设置为大于实际字体大小的值。本示例需要 “presentation.pptx”，其第一个形状的第一个幻灯片上有一个文本框。示例检查有效字体名称（包括继承的字体），并为使用 Roboto 的片段设置 100 磅的阈值：低于 100 磅的片段将禁用字距调整：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var targetFont = "Roboto";

foreach (var paragraph in autoShape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var textFormat = portion.PortionFormat.GetEffective();
        
        var usesTargetFont = textFormat.LatinFont?.FontName == targetFont || 
            textFormat.EastAsianFont?.FontName == targetFont || 
            textFormat.ComplexScriptFont?.FontName == targetFont;

        if (usesTargetFont)
        {
            portion.PortionFormat.KerningMinimalSize = 100;
        }
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

对于低于阈值的匹配文本，此设置可阻止字距调整，并有助于使 Aspose.Slides 的渲染效果与受 PowerPoint 特定行为影响的字体的可视输出更为一致。

## **管理文本字体属性**

可以通过 [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) 在段落级别设置字体属性，或通过 [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/) 在单个片段上设置。

以下示例将第一段的默认字体设置为 12 磅 Times New Roman，并启用粗体、斜体和点划下划线。对单个片段的显式格式会覆盖这些默认值：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 为段落设置字体属性。
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

结果：

![The font properties for the paragraph](font_properties_for_paragraph.png)

以下示例对格式有效且为粗体的片段应用 13 磅 Times New Roman、斜体和点划下划线：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // 为文本片段设置字体属性。
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

结果：

![The font properties for text portions](font_properties_for_text_portions.png)

## **设置文本旋转**

使用 [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) 在形状内部设置预定义的文本方向。

以下代码示例将形状中的文本方向设置为 [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/)，即 **逆时针旋转 90 度**：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
```

结果：

![The text rotation](text_rotation.png)

## **为文本框设置自定义旋转**

使用 [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) 为 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 设置自定义旋转角度。

下面的代码示例在形状内将文本框顺时针旋转 3 度：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
```

结果：

![The custom text rotation](custom_text_rotation.png)

## **设置段落行间距**

Aspose.Slides 提供 [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/)、[IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/)、[IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) 以控制段落间距。使用方式如下：

* 正值表示按行高的百分比指定行间距。
* 负值表示以磅数指定行间距。

以下示例将第一段的内部间距设置为行高的 200%（双倍行距）：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.SpaceWithin = 200;

presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
```

结果：

![The line spacing within the paragraph](line_spacing.png)

## **控制换行行为**

段落换行规则在窄文本块以及混合拉丁文和东亚文字的演示文稿中尤为有用。以下属性属于 [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/)，因此适用于整个段落：

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) 控制拉丁文换行规则。在混合文本中，更改该属性也可能影响相邻东亚文字和标点的换行位置。
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) 控制东亚文字换行规则，包括行首和行尾字符的限制。

这些规则并不取代 [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/)，后者启用文本框内的自动换行。它们在换行发生时影响布局；并不会插入换行字符。显式换行会独立于可用宽度在段落内强制换行。

以下独立示例创建一个包含中文和拉丁文的窄文本块，显式设置两个换行属性并保存为 “line_breaking.pptx”。要实验任一规则，只需在保持另一个设置不变的情况下修改对应属性的值。示例使用 24 磅 Arial 和 SimSun，框宽 160 磅，水平文本框边距为 0。将 [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) 设置为 [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/)，使文字大小和框尺寸保持固定。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "中文排版测试，PowerPoint 中文演示。";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.EastAsianFont = new FontData("SimSun");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.LatinLineBreak = NullableBool.False;
format.EastAsianLineBreak = NullableBool.True;

presentation.Save("line_breaking.pptx", SaveFormat.Pptx);
```

## **控制悬挂标点**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) 允许符合条件的标点超出文本行的右边缘，而不是占据下一行。它适用于整个段落，并不同于悬挂缩进。

以下独立示例在宽度为 100 磅的文本框中启用悬挂标点，并保存为 “hanging_punctuation.pptx”。使用 24 磅 Arial、水平文本框边距为 0 时，句尾的句点仍位于 “sentence” 之后并超出右侧文本边缘。将属性设为 [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) 进行对比：在这些设置下，句点会占据独立的一行。已启用换行且禁用自动适应，以保持可用宽度固定。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "Simple text, next sentence.";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.HangingPunctuation = NullableBool.True;

presentation.Save("hanging_punctuation.pptx", SaveFormat.Pptx);
```

并非所有标点都可以悬挂。上述 [字体和布局条件](#control-line-breaking) 也同样适用于此对比：更改字体、可用宽度、边距或自动适应设置都可能消除可见差异。

## **设置文本框的自动适应类型**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) 决定文本超出容器边界时的行为。使用它可以控制文本是缩小、溢出还是自动调整形状大小。以下示例将形状设置为随文本大小自动调整，并将结果保存为 “autofit_type.pptx”。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

若要在自动换行后计数行数并查看文本或形状宽度变化对结果的影响，请参阅 [Count Rendered Lines](/slides/zh/net/manage-paragraph/)。仅凭行数无法判断文本是否溢出容器。

## **设置文本框的锚定位置**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) 定义文本在形状内部的垂直位置，例如顶部、居中或底部。以下示例将文本锚定到第一个形状的底部，并将结果保存为 “text_anchor.pptx”。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **设置文本制表位**

使用 [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) 与 [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) 配置段落中的制表位。以下示例将默认制表间距设为 100 磅，并在 30 磅处添加左对齐的制表位。这些设置会影响包含制表符的文本。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultTabSize = 100;
paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
```

结果：

![The paragraph tabs](paragraph_tabs.png)

## **设置校对语言**

Aspose.Slides 提供 [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/)，用于为文本片段设置校对语言。校对语言决定 PowerPoint 中拼写和语法检查使用的语言。

以下示例需要 “presentation.pptx”，其第一张幻灯片的第一个形状为文本框且至少包含一个段落。示例将第一段的内容替换为 “1。”，将字体设为 SimSun，并将校对语言设为简体中文 (`zh-CN`)。结果保存为 “proofing_language.pptx”：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var font = new FontData("SimSun");

var textPortion = new Portion();
textPortion.PortionFormat.ComplexScriptFont = font;
textPortion.PortionFormat.EastAsianFont = font;
textPortion.PortionFormat.LatinFont = font;

// 将校对语言设置为简体中文。
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **设置默认语言**

使用 [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) 为加载或创建演示文稿时生成的文本定义默认语言。以下示例创建一个默认文本语言为美式英语的演示文稿，添加一个文本框，并打印其第一个文本片段的语言代码 `en-US`。

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// 添加一个带文本的新矩形形状。
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// 检查第一个片段的语言。
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **设置默认文本样式**

要在演示文稿级别应用默认文本格式，请使用 [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/)。

以下示例将新演示文稿中顶层段落的默认字体设置为 14 磅粗体，并将结果保存为 “default_text_style.pptx”。文本可以继承这些默认值，除非更具体的格式覆盖了它们。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// 获取顶级段落格式。
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **提取带全大写效果的文本**

在 PowerPoint 中，应用 **All Caps** 字体效果会使幻灯片上的文本呈现为大写，即使原始输入为小写。当使用 Aspose.Slides 获取此类文本片段时，库会返回其原始输入。若要匹配显示的文本，请检查 [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) 并在其值为 `All` 时将返回的字符串转换为大写。

此示例需要 “sample2.pptx”，其第一张幻灯片的第一个形状为文本框。其第一段的第一个片段包含 “Hello, Aspose!” 并已应用 All Caps 效果，如下图所示。

![The All Caps effect](all_caps_effect.png)

下面的代码示例演示如何提取带 **All Caps** 效果的文本：

```cs
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample2.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

Console.WriteLine($"Original text: {textPortion.Text}");

var textFormat = textPortion.PortionFormat.GetEffective();
if (textFormat.TextCapType == TextCapType.All)
{
    var text = textPortion.Text.ToUpper();
    Console.WriteLine($"All-Caps effect: {text}");
}
```

输出：

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **常见问题解答**

**如何修改幻灯片中表格的文本？**

要修改幻灯片中表格的文本，请使用 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)。遍历单元格，并通过 [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) 更新每个单元格的文本，通过 [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) 更新段落格式。

**如何为 PowerPoint 幻灯片上的文本应用渐变颜色？**

要为文本应用渐变颜色，请使用 [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/)。将 [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) 设置为 [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/)，并配置渐变停止点、方向和透明度。