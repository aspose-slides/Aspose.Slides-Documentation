---
title: 在 .NET 中格式化演示文稿文本
linktitle: 文本格式化
type: docs
weight: 50
url: /zh/net/text-formatting/
keywords:
- 突出显示文本
- 正则表达式
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

本文介绍了如何使用 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 演示文稿中格式化文本。内容涵盖突出显示、背景颜色、透明度、字符间距、字体属性、旋转、段落间距、自动适应行为、文本锚定、制表位和语言设置。

下面的示例中，我们使用名为“sample.pptx”的文件，该文件在第一张幻灯片上包含一个文本框，文本内容如下：

![示例文本](sample_text.png)

## **突出显示文本**

当需要在文本框中突出显示匹配特定样本的文本时，请使用[ITextFrame.HighlightText](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/highlighttext/) 方法。该方法对匹配的文本片段应用突出显示颜色，并可与[TextSearchOptions](https://reference.aspose.com/slides/zh/net/aspose.slides/textsearchoptions/) 一起使用，以控制搜索方式，例如仅匹配完整单词。

下面的代码示例先突出显示所有出现的字符 **"try"**，然后仅突出显示完整单词 **"to"**。

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // 获取第一张幻灯片上的第一个形状。
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

结果如下：

![突出显示的文本](highlighted_text.png)

## **使用正则表达式突出显示文本**

[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/highlightregex/) 方法突出显示通过正则表达式找到的文本匹配项。在 .NET 中，此 API 在[ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/) 上公开。

下面的代码示例突出显示所有包含 **七个或更多字符** 的单词：

```cs
using (var presentation = new Presentation(folderPath + "sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var regex = new Regex(@"\b[^\s]{7,}\b");

    // 高亮显示所有七个或更多字符的单词。
    shape.TextFrame.HighlightRegex(regex, Color.Yellow, null);

    presentation.Save(folderPath + "highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```

结果如下：

![使用正则表达式突出显示的文本](highlighted_text_using_regex.png)

## **设置文本背景颜色**

使用[IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/defaultportionformat/) 可设置段落的默认突出显示颜色，或使用[IPortionFormat.HighlightColor](https://reference.aspose.com/slides/zh/net/aspose.slides/iportionformat/highlightcolor/) 为单个文本片段设置颜色。

以下代码示例演示如何为 **整个段落** 设置背景颜色：

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

结果如下：

![灰色段落](gray_paragraph.png)

下面的代码示例对 **加粗字体的文本片段** 设置背景颜色：

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

结果如下：

![灰色文本片段](gray_text_portions.png)

## **对齐文本段落**

使用[IParagraphFormat.Alignment](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/alignment/) 可设置文本框内段落的对齐方式。可选值包括居中、左对齐、右对齐、两端对齐等。

以下代码示例演示如何将段落对齐到 **居中**：

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 将段落对齐方式设置为居中。
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

结果如下：

![已对齐的段落](aligned_paragraph.png)

## **设置文本透明度**

文本透明度通过分配给[IPortionFormat.FillFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/iportionformat/fillformat/) 的颜色的 alpha 分量来控制。在下面的示例中，`alpha = 50` 是 0–255 范围内的 ARGB alpha 通道值，而非透明度百分比。

下面的代码示例演示如何对 **整个段落** 应用透明度：

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

结果如下：

![透明段落](transparent_paragraph.png)

以下代码示例演示如何对 **加粗字体的文本片段** 应用透明度：

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

结果如下：

![透明文本片段](transparent_text_portions.png)

## **设置文本字符间距**

使用[IBasePortionFormat.Spacing](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseportionformat/spacing/) 可在文本框中扩大或缩小字符之间的间距。

以下 C# 代码演示如何在 **整个段落** 中扩大字符间距：

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

结果如下：

![段落中的字符间距](character_spacing_in_paragraph.png)

下面的代码示例演示如何在 **加粗字体的文本片段** 中扩大字符间距：

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

结果如下：

![文本片段中的字符间距](character_spacing_in_text_portions.png)

### **为特定字体禁用字距调整**

在某些情况下，Aspose.Slides 渲染的文本可能比 PowerPoint 中显示的相同文本略显紧凑。这可能是因为 PowerPoint 会忽略某些字体的字距调整数据，即使该字体包含有效的字距信息且在 PowerPoint 设置中已启用字距调整。

为了使渲染输出更接近 PowerPoint，您可以为使用受影响字体的文本片段禁用字距调整。将[IPortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseportionformat/kerningminimalsize/) 设置为明显大于实际字体大小的数值：

```cs
using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var targetFont = "Roboto";

    foreach (var paragraph in autoShape.TextFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            if ((portion.PortionFormat.LatinFont != null &&
                 portion.PortionFormat.LatinFont.FontName == targetFont) ||
                (portion.PortionFormat.EastAsianFont != null &&
                 portion.PortionFormat.EastAsianFont.FontName == targetFont) ||
                (portion.PortionFormat.ComplexScriptFont != null &&
                 portion.PortionFormat.ComplexScriptFont.FontName == targetFont))
            {
                portion.PortionFormat.KerningMinimalSize = 100;
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

此设置可防止对匹配的文本片段应用字距调整，并有助于使 Aspose.Slides 的渲染与 PowerPoint 对受此 PowerPoint 特定行为影响的字体的视觉输出保持一致。

## **管理文本字体属性**

可以通过[IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/defaultportionformat/) 在段落级别设置字体属性，或通过[IPortionFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/iportionformat/) 在单个文本片段上设置。

以下代码为整个段落设置字体和文本样式：它对段落中的所有片段应用字体大小、粗体、斜体、点划线下划线以及 Times New Roman 字体。

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

结果如下：

![段落的字体属性](font_properties_for_paragraph.png)

下面的代码示例对 **加粗字体的文本片段** 应用类似属性：

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

结果如下：

![文本片段的字体属性](font_properties_for_text_portions.png)

## **设置文本旋转**

使用[ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat/textverticaltype/) 可在形状内设置预定义的文本方向。

以下代码示例将形状中文本方向设置为 `Vertical270`，这会将文本 **逆时针旋转 90 度**：

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

结果如下：

![文本旋转](text_rotation.png)

## **为文本框设置自定义旋转**

使用[ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat/rotationangle/) 可为[ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/) 设置自定义旋转角度。

下面的代码示例在形状内将文本框顺时针旋转 3 度：

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

结果如下：

![自定义文本旋转](custom_text_rotation.png)

## **设置段落行距**

Aspose.Slides 提供[IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/spaceafter/)、[IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/spacebefore/) 和[IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/spacewithin/) 来控制段落间距。使用方式如下：

· 使用正值将行距指定为行高的百分比。  
· 使用负值以磅为单位指定行距。

以下代码示例演示如何在段落内部指定行距：

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

结果如下：

![段落中的行距](line_spacing.png)

## **设置文本框自动适应类型**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat/autofittype/) 确定当文本超出容器边界时的行为。可用于控制文本是缩小、溢出还是自动调整形状大小。

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **设置文本框锚点**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat/anchoringtype/) 定义文本在形状内部的垂直定位方式，例如位于顶部、居中或底部。

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **设置文本制表位**

使用[IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/defaulttabsize/) 和[IParagraphFormat.Tabs](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/tabs/) 可在段落中配置制表位。

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

结果如下：

![段落制表位](paragraph_tabs.png)

## **设置校对语言**

Aspose.Slides 提供[IPortionFormat.LanguageId](https://reference.aspose.com/slides/zh/net/aspose.slides/iportionformat/languageid/)，可为文本片段设置校对语言。校对语言决定 PowerPoint 中拼写和语法检查所使用的语言。

以下代码示例演示如何为文本片段设置校对语言：

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

使用[LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/defaulttextlanguage/) 可定义在加载或创建演示文稿时创建的文本的默认语言。

```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // 添加一个带文本的新矩形形状。
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // 检查第一段文本的语言。
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **设置默认文本样式**

要在演示文稿级别应用默认文本格式，请使用[IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentation/defaulttextstyle/)。

以下代码示例展示如何在新演示文稿中为所有幻灯片的文本设置默认的粗体、14 磅字号的字体。

```cs
using (var presentation = new Presentation())
{
    // 获取顶级段落格式。
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **提取全部大写效果的文本**

在 PowerPoint 中，应用 **All Caps** 字体效果会使文本在幻灯片上显示为大写，即使原始输入为小写。当使用 Aspose.Slides 检索此类文本片段时，库会返回原始输入的文本。为匹配显示的文本，需要检查[TextCapType](https://reference.aspose.com/slides/zh/net/aspose.slides/textcaptype/) ，当值为 `All` 时将返回的字符串转换为大写。

假设我们在 sample2.pptx 文件的第一张幻灯片上有如下文本框。

![全部大写效果](all_caps_effect.png)

下面的代码示例演示如何提取已应用 **All Caps** 效果的文本：

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

要修改幻灯片中表格的文本，请使用[ITable](https://reference.aspose.com/slides/zh/net/aspose.slides/itable/)。遍历单元格，并通过[ICell.TextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/icell/textframe/) 更新每个单元格的文本，以及通过[IParagraph.ParagraphFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraph/paragraphformat/) 设置段落格式。

**如何在 PowerPoint 幻灯片中的文本上应用渐变颜色？**

要对文本应用渐变颜色，请使用[IPortionFormat.FillFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/iportionformat/fillformat/)。将[IFillFormat.FillType](https://reference.aspose.com/slides/zh/net/aspose.slides/ifillformat/filltype/) 设置为[FillType.Gradient](https://reference.aspose.com/slides/zh/net/aspose.slides/filltype/)，并配置渐变停止点、方向和透明度。