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
description: "使用 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 演示文稿中格式化和设置文本样式。自定义字体、颜色、对齐方式等。"
---
## **概述**

本文介绍如何使用 Aspose.Slides for .NET 对 PowerPoint 和 OpenDocument 演示文稿中的文本进行格式化。内容涵盖背景颜色、透明度、字符间距、字体属性、旋转、段落间距、自动调整行为、文本锚定、制表位和语言设置。

除非另有说明，示例均使用 [sample.pptx](sample.pptx)。其第一张幻灯片的第一个形状是一个文本框，第一段落包含如下所示的文本。幻灯片和形状的索引均为从零开始。选择粗体部分的示例使用有效格式，包括继承的粗体格式：

![示例文本](sample_text.png)

如需查找并突出显示文字字面量或正则表达式匹配，请参阅 [搜索和替换文本](/slides/zh/net/search-and-replace-text/)。

## **设置文本背景颜色**

使用 [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) 为段落设置默认突出显示颜色，或使用 [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) 为单独文本片段设置颜色。

下面的示例将第一段落的默认突出显示设置为浅灰色。对单独片段的显式突出显示颜色将优先于此默认值：

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

以下代码示例演示如何为 **粗体字体的文本片段** 设置背景颜色：

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

使用 [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) 设置文本框内段落的对齐方式。取值可以是居中、左对齐、右对齐、两端对齐等。

下面的代码示例演示如何将段落对齐至 **居中**：

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

![对齐的段落](aligned_paragraph.png)

## **在行内对齐字体**

使用 [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) 在同一行内对不同字号的文本片段进行垂直对齐。此设置适用于整个段落，并控制每行内部的对齐方式。

下面的独立示例在一张幻灯片上创建四个带标签的文本框。每个段落包含相同的文字，字号分别为 18、36、54 点，并使用不同的字体对齐方式。示例使用 Arial，禁用自动调节和换行，并保持文本框足够大以容纳单行。

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

![基线、顶部、居中和底部字体对齐的比较（混合字号）](font_alignment.png)

字体对齐使用字体度量，因此各个字母的可见边缘不一定完全对齐。示例中包含大写字母和降部字符，以帮助显示基线与底部对齐的差异。字体可用性及替换、所用字符以及字号差异都会影响结果。框架尺寸、边距、行距、换行和自动调节也会影响布局；比较模式时请使用相同的字体和布局设置。

此设置不同于 [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/)，后者控制水平段落对齐；以及 [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/)，后者在形状内垂直定位文本块。通过 [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) 实现的上标和下标格式会相对于基线移动单个片段，而不是为段落行设置字体对齐。

## **为文本设置透明度**

文本透明度通过分配给 [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) 的颜色的 alpha 分量来控制。下列示例中，`alpha = 50` 是 0–255 范围内的 ARGB alpha 通道值，而非透明度百分比。

以下代码示例演示如何为 **整个段落** 应用透明度：

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

下面的代码示例演示如何为 **粗体字体的文本片段** 应用透明度：

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

![透明文本片段](transparent_text_portions.png)

## **为文本设置字符间距**

使用 [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) 可在文本框中的字符之间增加或减少间距。示例中添加了 3 点的间距；负值则会压缩文本。

下面的 C# 代码演示如何在 **整个段落** 中扩大字符间距：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 注意：使用负值来压缩字符间距。
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // 增加字符间距。

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

结果：

![段落中的字符间距](character_spacing_in_paragraph.png)

下面的代码示例演示如何在 **粗体字体的文本片段** 中扩大字符间距：

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
        portion.PortionFormat.Spacing = 3;  // 增加字符间距。
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

结果：

![文本片段中的字符间距](character_spacing_in_text_portions.png)

### **为特定字体禁用字距调整**

在某些情况下，Aspose.Slides 渲染的文本可能比 PowerPoint 中的同样文本稍微紧凑。这可能是因为 PowerPoint 对某些字体会忽略字距信息，即使该字体包含有效的字距数据且在 PowerPoint 设置中已启用字距。

为使渲染结果更接近 PowerPoint，可为使用受影响字体的文本片段禁用字距。将 [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) 设置为大于实际字体大小的值。此示例需要“presentation.pptx”，其第一张幻灯片的第一形状为文本框。它检查有效字体名称（包括继承的字体），并为使用 Roboto 的片段设置 100 点的阈值。这样会为字体大小低于 100 点的匹配片段禁用字距：

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

对于低于阈值的匹配文本，此设置会阻止字距，并有助于使 Aspose.Slides 的渲染与 PowerPoint 对受此 PowerPoint 特定行为影响的字体的视觉输出保持一致。

## **管理文本字体属性**

可以通过 [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) 在段落级别设置字体属性，亦可通过 [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/) 在单个片段上设置。

下面的示例将第一段落的默认字体设置为 12 点 Times New Roman，粗体、斜体和点状下划线。对单独片段的显式格式将优先于这些默认值：

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

下面的示例对有效格式为粗体的片段应用 13 点 Times New Roman、斜体以及点状下划线：

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

## **控制文本高度归一化**

在复制模板排版或研究字符高度差异时使用 [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/)。在 PowerPoint 中，启用归一化会在垂直方向拉伸或压缩单个字符，使其在文本片段内具有统一的可见高度。但它并不保证不同字体之间的文本高度相等。

将属性设置为 [NullableBool.True 或 False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) 可显式启用或禁用归一化。`NullableBool.NotDefined` 表示本地设置未定义，片段将继承其值，例如来自段落的 [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/)。这并不等同于 `False`。使用 [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) 并读取 [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) 可获得解析后的布尔值。

下面的独立示例需要安装 **Arial**。它创建两个文本块，包含相同的大写字母、小写字母、降部字符和重音字符，字号为 54 点。两个段落默认启用归一化。顶部片段显式禁用；底部片段继承设置。框架尺寸、边距和段落间距相同，且禁用换行和自动调节以保持比较一致。示例会输出 `False: False` 和 `NotDefined: True`，随后保存为 “text_height_normalization.pptx”。

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var settings = new[] { NullableBool.False, NullableBool.NotDefined };

for (var i = 0; i < settings.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Text = "Hxgjpq ÅÉ 0123";
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.MarginTop = 0;
    textFrame.TextFrameFormat.MarginLeft = 0;

    var paragraph = textFrame.Paragraphs[0];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceBefore = 0;
    paragraph.ParagraphFormat.SpaceAfter = 0;
    paragraph.ParagraphFormat.SpaceWithin = 100;
    paragraph.ParagraphFormat.DefaultPortionFormat.NormaliseHeight = NullableBool.True;

    var portion = paragraph.Portions[0];
    portion.PortionFormat.LatinFont = new FontData("Arial");
    portion.PortionFormat.FontHeight = 54;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.NormaliseHeight = settings[i];

    Console.WriteLine($"{settings[i]}: {portion.PortionFormat.GetEffective().NormaliseHeight}");
}

presentation.Save("text_height_normalization.pptx", SaveFormat.Pptx);
```

以下比较图来自已保存的演示文稿。上排为禁用归一化 (`False`)；下排继承启用设置 (`NotDefined` → `True`)。请保持 Arial 已安装以复现此外观。

![Arial 54 点文本，上方禁用归一化，下方继承启用归一化](text_height_normalization.png)

归一化会在不更改分配给 [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/)（指定字号）的情况下改变字符高度。段落的 [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) 控制行距，而文本框的 [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) 控制文本或其容器的自适应方式。这些设置各自独立，可能会影响整体布局。有关段落格式化和继承的更多信息，请参阅 [管理段落](/slides/zh/net/manage-paragraph/)。

## **应用和移除删除线**

在文本片段上使用 [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) 可显示更正、已取消的词语或旧价而不删除原始文本。将其设置为 [TextStrikethroughType.Single 或 Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) 可在文本上绘制一条或两条线。

要移除删除线，将其设为 `TextStrikethroughType.None`。这会显式禁用效果，即使周围的格式指定了删除线。相对地，`TextStrikethroughType.NotDefined` 将保持本地设置未定义，允许片段继承格式，例如来自段落的设置，但不能保证删除线被移除。使用 [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) 可读取最终的格式，包括继承的值。

下面的独立示例创建了三个价格比较。每个段落都有标签、旧价和现价的单独片段，只有旧价受到影响。第一行先应用后移除删除线；其余行保留单线和双线删除线。更改此属性可在保留文本及其他格式（如粗体旧价）的同时实现效果。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

var labels = new[] { "None: ", "Single: ", "Double: " };

foreach (var label in labels)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceAfter = 20;

    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    format.FontHeight = 28;
    format.LatinFont = new FontData("Arial");
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    paragraph.Portions.Add(new Portion(label));

    var previousPrice = new Portion("$100");
    previousPrice.PortionFormat.FontBold = NullableBool.True;
    paragraph.Portions.Add(previousPrice);
    paragraph.Portions.Add(new Portion(" → $80"));
    
    shape.TextFrame.Paragraphs.Add(paragraph);
}

var paragraphs = shape.TextFrame.Paragraphs;

// 应用删除线，然后显式地从第一个原价中移除它。
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

结果（从上到下）：无删除线、单线删除线、双线删除线。

![没有删除线、单线删除线和双线删除线的旧价格对比](strikethrough.png)

## **设置文本旋转**

使用 [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) 可在形状内设置预定义的文本方向。

下面的代码示例将形状内的文本方向设置为 [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/)，即文本 **逆时针旋转 90 度**：

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

## **在垂直文本中并排显示数字**

为在垂直日文标签中将两位数字放在一起，需将两位数字放入同一文本片段并在该片段上设置 [IBasePortionFormat.Kumimoji](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kumimoji/)。示例使用 [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) 和 40 点 MS Gothic 作为两标签的字体。仅对数字片段的 [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) 赋值不同。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

AddLabel(slide, 120, NullableBool.True);
AddLabel(slide, 360, NullableBool.False);

presentation.Save("vertical_date.pptx", SaveFormat.Pptx);

static void AddLabel(ISlide slide, float x, NullableBool kumimoji)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;

    var frame = label.AddTextFrame("");
    frame.TextFrameFormat.TextVerticalType = TextVerticalType.EastAsianVertical;

    var paragraph = frame.Paragraphs[0];
    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    var font = new FontData("MS Gothic");
    format.LatinFont = font;
    format.EastAsianFont = font;
    format.FontHeight = 40;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var digits = new Portion("12");
    digits.PortionFormat.Kumimoji = kumimoji;
    
    paragraph.Portions.Clear();
    paragraph.Portions.Add(new Portion("令和"));
    paragraph.Portions.Add(digits);
    paragraph.Portions.Add(new Portion("年"));
}
```

在 PowerPoint 中，左侧标签（`True`）在 和 与 年 之间保持数字直立并并排显示。右侧标签（`False`）则将数字对旋转 90 度顺时针。两标签周围的日文字符均保持直立。

![PowerPoint 中垂直日期标签的比较：左侧数字直立并排，右侧数字旋转](vertical_date.png)

## **为文本框设置自定义旋转角度**

使用 [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) 可为 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 设置自定义旋转角度。

下面的代码示例将文本框在形状内顺时针旋转 3 度：

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

Aspose.Slides 提供 [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/)、[IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) 和 [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) 来控制段落间距。其用法如下：

* 使用正值以行高的百分比指定行距。
* 使用负值以点数指定行距。

下面的示例将第一段落的内部间距设置为行高的 200%（双倍行距）：

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

![段落内部的行距](line_spacing.png)

## **控制换行行为**

段落换行规则在狭窄文本块以及混合拉丁文和东亚文字的演示文稿中非常有用。以下属性属于 [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/)，因此适用于整个段落：

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) 控制拉丁文字的换行规则。在混合文本中，更改它也可能影响相邻东亚文字和标点的换行位置。
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) 控制东亚文字的换行规则，包括行首和行尾字符的限制。

这些规则并不取代 [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/)，后者启用文本框内的自动换行。规则会影响换行时的布局，但不会插入换行符。显式换行符会强制在段落内部另起新行，独立于可用宽度。

下面的独立示例创建一个包含中文和拉丁文字的窄文本块。它显式设置两种换行属性并保存为 “line_breaking.pptx”。要实验任一规则，只需更改对应属性的值，同时保持其他设置不变。示例使用 24 点 Arial 和 SimSun，框宽 160 点，水平文本框边距为零。将 [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) 设置为 [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) 以固定文本大小和框架尺寸。

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

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) 允许符合条件的标点超出文本行右边缘，而不是占据下一行。它适用于整个段落，且不同于挂起缩进。

下面的独立示例在宽度为 100 点的文本框中启用悬挂标点并保存为 “hanging_punctuation.pptx”。使用 24 点 Arial 且水平文本框边距为零时，句末的句点仍位于 “sentence” 之后并延伸至右侧文本边缘。将属性设为 [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) 可进行对比：此时句点会占据单独一行。启用换行并禁用自动调节以保持可用宽度固定。

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

并非所有标点都能悬挂。上述 [字体和布局条件](#control-line-breaking) 也适用于此比较：更改字体、可用宽度、边距或自动调节设置都可能消除可见差异。

## **为文本框设置自动调节类型**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) 决定当文本超过容器边界时的行为。可用来控制文本是缩小、溢出还是自动调整形状大小。下面的示例将形状配置为自动调整以适应文本，并将结果保存为 “autofit_type.pptx”。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

若想在自动换行后统计行数并查看文本或形状宽度的变化，请参阅 [统计渲染行数](/slides/zh/net/manage-paragraph/)。仅行数本身并不能指示文本是否溢出容器。

## **设置文本框锚点**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) 定义文本在形状内部的垂直位置，例如顶部、居中或底部。下面的示例将文本锚定到第一形状的底部，并将结果保存为 “text_anchor.pptx”。

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

使用 [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) 和 [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) 可在段落中配置制表位。下面的示例将默认制表间距设为 100 点，并在 30 点处添加左对齐制表位。这些设置会影响包含制表符的文本。

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

![段落制表位](paragraph_tabs.png)

## **设置校对语言**

Aspose.Slides 提供 [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/)，可为文本片段设置校对语言。校对语言决定 PowerPoint 中拼写和语法检查使用的语言。

下面的示例需要 “presentation.pptx”，其第一张幻灯片的第一形状为文本框，且至少包含一个段落。它将第一段落的内容替换为 “1。”，将字体设为 SimSun，并分配简体中文校对语言 (`zh-CN`)。随后将结果保存为 “proofing_language.pptx”：

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

### **复制语言元数据**

在从模板复制多语言文本时，请同时保留 [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) 和 [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/)。下面的独立示例创建一个源片段，其语言为美式英语，备选语言为法语，并将文本及标识符复制到新演示文稿中的片段。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new Portion("Hello! Bonjour!");
source.PortionFormat.LanguageId = "en-US";
source.PortionFormat.AlternativeLanguageId = "fr-FR";

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var destination = new Portion();
destination.Text = source.Text;
destination.PortionFormat.LanguageId = source.PortionFormat.LanguageId;
// 如果源没有备用语言，null 将清除目标的该值。
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

若要尝试没有备选语言的源，请省略对 `"fr-FR"` 的赋值。此时备选标识符为 `null`，相同的复制语句会保留其缺失而不引入默认值，即使目标先前已分配备选语言。

这些标识符存储语言元数据。保留它们并不决定 PowerPoint 为拼写或语法检查选择哪个词典。

## **设置默认语言**

使用 [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) 可定义在加载或创建演示文稿时创建的文本的默认语言。下面的示例创建一个默认文本语言为美式英语的演示文稿，添加一个文本框，并打印其第一个文本片段的语言为 `en-US`。

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

下面的示例将新演示文稿中顶层段落的默认字体设为 14 点粗体，并将其保存为 “default_text_style.pptx”。除非更具体的格式覆盖，否则文本会继承这些默认值。

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

在 PowerPoint 中，应用 **全大写** 字体效果会使幻灯片上的文本显示为大写，即使原始输入为小写。当使用 Aspose.Slides 检索此类文本片段时，库会返回原始输入的文本。若要匹配显示效果，需要检查 [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) 并在其值为 `All` 时将返回的字符串转换为大写。

此示例需要 “sample2.pptx”，其第一张幻灯片的第一形状为文本框。其第一段落的第一个片段包含 “Hello, Aspose!” 并应用了全大写效果，如下所示。

![全大写效果](all_caps_effect.png)

下面的代码示例展示如何提取带 **全大写** 效果的文本：

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

**如何修改幻灯片上表格中的文本？**

要修改幻灯片上表格中的文本，请使用 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)。遍历单元格，并通过 [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) 更新每个单元格的文本，以及通过 [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) 更新段落格式。

**如何在 PowerPoint 幻灯片上的文本应用渐变颜色？**

要对文本应用渐变颜色，请使用 [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/)。将 [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) 设置为 [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/)，并配置渐变停点、方向和透明度。

相关功能：[在幻灯片中格式化文本](/slides/zh/features/text-formatting/)。