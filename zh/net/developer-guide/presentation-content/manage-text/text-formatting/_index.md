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
description: "使用 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 演示文稿中格式化和美化文本。自定义字体、颜色、对齐方式等。"
---
## **概述**

本文展示了如何使用 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 演示文稿中格式化文本。内容包括背景颜色、透明度、字符间距、字体属性、旋转、段落间距、自动适应行为、文本锚点、制表位和语言设置。

除非另有说明，例子使用 [sample.pptx](sample.pptx)。它的第一张幻灯片上的第一个形状是一个文本框，其第一个段落包含以下文本。幻灯片和形状索引均为零基。选择粗体部分的示例使用有效格式，包括继承的粗体格式：

![示例文本](sample_text.png)

要查找并突出显示文字字面值或正则表达式匹配，请参见 [搜索和替换文本](/slides/zh/net/search-and-replace-text/)。

## **设置文本背景颜色**

使用 [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/defaultportionformat/) 设置段落的默认突出显示颜色，或使用 [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseportionformat/highlightcolor/) 为单个文本片段设置突出显示颜色。

以下示例将浅灰色突出显示设为首个段落的默认颜色。对单个片段的显式突出显示颜色优先于此默认值：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 为整个段落设置突出显示颜色。
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

结果：

![灰色段落](gray_paragraph.png)

下面的代码示例演示如何为 **带粗体字体的文本片段** 设置背景颜色：

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
        // 为文本片段设置突出显示颜色。
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

结果：

![灰色文本片段](gray_text_portions.png)

## **对齐文本段落**

使用 [IParagraphFormat.Alignment](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/alignment/) 设置文本框内段落的对齐方式。可选值包括居中、左对齐、右对齐、两端对齐等。

以下代码示例展示如何将段落居中对齐：

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

![已对齐的段落](aligned_paragraph.png)

## **设置文本透明度**

文本透明度通过分配给 [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseportionformat/fillformat/) 的颜色的 alpha 分量来控制。下面示例中，`alpha = 50` 是 0–255 规模的 ARGB alpha 通道值，而不是透明度百分比。

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

![透明段落](transparent_paragraph.png)

以下代码示例展示如何对 **带粗体字体的文本片段** 应用透明度：

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
        // 设置文本片段的透明度。
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

结果：

![透明文本片段](transparent_text_portions.png)

## **设置文本字符间距**

使用 [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseportionformat/spacing/) 可在文本框中扩展或压缩字符之间的间距。示例中添加 3 点间距；负值会压缩文本。

以下 C# 代码展示如何在 **整个段落** 中扩展字符间距：

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

![段落中的字符间距](character_spacing_in_paragraph.png)

下面的代码示例展示如何在 **带粗体字体的文本片段** 中扩展字符间距：

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

![文本片段中的字符间距](character_spacing_in_text_portions.png)

### **禁用特定字体的字距调整**

在某些情况下，Aspose.Slides 渲染的文本可能比 PowerPoint 中显示的相同文本略显紧凑。这可能是因为 PowerPoint 在某些字体上会忽略字距调整数据，即使该字体包含有效的字距信息且在 PowerPoint 设置中已启用字距调整。

为使渲染输出更接近 PowerPoint，您可以对使用受影响字体的文本片段禁用字距调整。将 [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseportionformat/kerningminimalsize/) 设置为大于实际字体大小的值。本例需要 “presentation.pptx”，其第一张幻灯片的第一个形状是一个文本框。示例检查有效字体名称（包括继承的字体），并为使用 Roboto 的片段设置 100 点阈值。这样会对字体大小低于 100 点的匹配片段禁用字距调整：

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

对于低于阈值的匹配文本，此设置可防止字距调整，并帮助在受 PowerPoint 特定行为影响的字体上，使 Aspose.Slides 的渲染更加接近 PowerPoint 的视觉输出。

## **管理文本字体属性**

可以通过 [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/defaultportionformat/) 在段落级别设置字体属性，或通过 [IPortionFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/iportionformat/) 在单个片段上设置。

以下示例将首段的默认字体设为 12 磅 Times New Roman，并使用粗体、斜体和点状下划线。对单个片段的显式格式会覆盖这些默认设置：

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

![段落的字体属性](font_properties_for_paragraph.png)

以下示例对有效格式为粗体的片段应用 13 磅 Times New Roman、斜体以及点状下划线：

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

![文本片段的字体属性](font_properties_for_text_portions.png)

## **设置文本旋转**

使用 [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat/textverticaltype/) 可以在形状内部设置预定义的文本方向。

以下代码示例将形状内的文本方向设置为 [TextVerticalType.Vertical270](https://reference.aspose.com/slides/zh/net/aspose.slides/textverticaltype/)，即文本 **逆时针旋转 90 度**：

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

![文本旋转](text_rotation.png)

## **为文本框设置自定义旋转**

使用 [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat/rotationangle/) 可以为 [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/) 设置自定义旋转角度。

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

![自定义文本旋转](custom_text_rotation.png)

## **设置段落行距**

Aspose.Slides 提供 [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/spaceafter/)、[IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/spacebefore/) 和 [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/spacewithin/) 来控制段落间距。使用方式如下：

* 使用正值将行距指定为行高的百分比。
* 使用负值将行距指定为磅值。

以下示例将首段内部的间距设置为行高的 200%（双倍行距）：

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

![段落内的行距](line_spacing.png)

## **控制换行**

段落换行规则在窄文本块以及混合 Latin 与东亚文字的演示文稿中非常有用。以下属性属于 [IParagraphFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/)，因此适用于整个段落：

- [LatinLineBreak](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/latinlinebreak/) 控制 Latin 换行规则。在混合文本中，修改它也会影响相邻东亚文字和标点的换行位置。
- [EastAsianLineBreak](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/eastasianlinebreak/) 控制东亚换行规则，包括行首和行尾字符的限制。

这些规则并不取代 [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat/wraptext/)，后者启用文本框内部的自动换行。规则仅在换行发生时影响布局；它们不会插入换行字符。显式换行会在不考虑可用宽度的情况下强制段落内换行。

下面的独立示例创建一个包含中文和 Latin 文本的窄文本块。示例显式设置两项换行属性并保存为 “line_breaking.pptx”。如需实验任一规则，只需更改该属性值而保持另一属性不变。示例使用 24 磅 Arial 与 SimSun，框宽 160 磅，水平文本框边距为 0。将 [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat/autofittype/) 设置为 [TextAutofitType.None](https://reference.aspose.com/slides/zh/net/aspose.slides/textautofittype/)，使文字大小和框尺寸保持固定：

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

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/hangingpunctuation/) 允许符合条件的标点超出文本行的右边缘，而不是占据下一行。该属性适用于整个段落，与悬挂缩进不同。

下面的独立示例在宽度为 100 磅的文本框中启用悬挂标点并保存为 “hanging_punctuation.pptx”。使用 24 磅 Arial 且水平文本框边距为 0 时，句末句点保持在 “sentence” 后并超出文本右边缘。将属性设为 [NullableBool.False](https://reference.aspose.com/slides/zh/net/aspose.slides/nullablebool/) 可作对比：此设置下句点会占据单独一行。示例开启自动换行并关闭自动适应，以保持可用宽度固定：

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

并非所有标点都能悬挂。上述 [字体和布局条件](#conditions-and-limitations) 同样适用于此对比：更改字体、可用宽度、边距或自动适应设置可能会消除可见差异。

## **设置文本框的自动适应类型**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat/autofittype/) 决定文本超出容器边界时的行为。可用它控制文本是缩小、溢出还是自动调整形状大小。下面的示例将形状设置为随文本自动调整大小，并将结果保存为 “autofit_type.pptx”：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

若要在自动换行后统计行数并查看文本或形状宽度变化对结果的影响，请参见 [计数渲染行数](/slides/zh/net/manage-paragraph/)。仅行数并不能说明文本是否溢出容器。

## **设置文本框的锚点**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat/anchoringtype/) 定义文本在形状内部的垂直定位方式，例如顶部、居中或底部。以下示例将文本锚定到第一个形状的底部并保存为 “text_anchor.pptx”：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **设置文本制表**

使用 [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/defaulttabsize/) 和 [IParagraphFormat.Tabs](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/tabs/) 可以在段落中配置制表位。以下示例将默认制表间隔设为 100 磅，并在 30 磅处添加左对齐制表位。这些设置会影响包含制表符的文本：

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

![段落制表](paragraph_tabs.png)

## **设置校对语言**

Aspose.Slides 提供 [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseportionformat/languageid/)，可为文本片段设置校对语言。校对语言决定 PowerPoint 中的拼写和语法检查使用的语言。

下面的示例需要 “presentation.pptx”，其第一张幻灯片的第一个形状是一个文本框，并且至少包含一个段落。示例将首段内容替换为 “1。”，将字体设为 SimSun，并分配简体中文校对语言 (`zh-CN`)。最后保存为 “proofing_language.pptx”：

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

使用 [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/defaulttextlanguage/) 可定义在加载或创建演示文稿时创建的文本的默认语言。以下示例创建一个默认文本语言为美式英语的演示文稿，添加一个文本框，并输出其首个文本片段的语言代码 `en-US`：

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// 添加一个带文本的矩形形状。
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// 检查首个文本片段的语言。
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **设置默认文本样式**

要在演示文稿级别应用默认文本格式，请使用 [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentation/defaulttextstyle/)。

以下示例为新演示文稿的顶层段落设置 14 磅粗体作为默认字体，并保存为 “default_text_style.pptx”。文本可以继承这些默认设置，除非更具体的格式覆盖它们：

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

## **提取全部大写效果的文本**

在 PowerPoint 中，应用 **All Caps** 字体效果会使幻灯片上的文本显示为全大写，即使原始输入为小写。使用 Aspose.Slides 检索此类文本片段时，库会返回原始输入的文本。要匹配显示的文本，需要检查 [TextCapType](https://reference.aspose.com/slides/zh/net/aspose.slides/textcaptype/) 并在值为 `All` 时将返回的字符串转换为大写。

此示例需要 “sample2.pptx”，其第一张幻灯片的第一个形状是一个文本框。首段的首个片段包含 “Hello, Aspose!” 并已应用 All Caps 效果，如下所示：

![全部大写效果](all_caps_effect.png)

下面的代码示例展示如何提取已应用 **All Caps** 效果的文本：

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

## **常见问题**

**如何修改幻灯片表格中的文本？**

要修改幻灯片表格中的文本，请使用 [ITable](https://reference.aspose.com/slides/zh/net/aspose.slides/itable/)。遍历单元格，并通过 [ICell.TextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/icell/textframe/) 更新每个单元格的文本框，再通过 [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraph/paragraphformat/) 设置段落格式。

**如何在 PowerPoint 幻灯片上对文本应用渐变颜色？**

要对文本应用渐变颜色，请使用 [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseportionformat/fillformat/)。将 [IFillFormat.FillType](https://reference.aspose.com/slides/zh/net/aspose.slides/ifillformat/filltype/) 设置为 [FillType.Gradient](https://reference.aspose.com/slides/zh/net/aspose.slides/filltype/)，并配置渐变停止点、方向和透明度。