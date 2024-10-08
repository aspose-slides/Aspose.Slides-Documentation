---
title: 文本格式化
linktitle: 文本格式化
type: docs
weight: 50
url: /net/text-formatting/
keywords:
- 高亮文本
- 正则表达式
- 对齐文本段落
- 文本透明度
- 段落字体属性
- 字体家族
- 文本旋转
- 自定义角度旋转
- 文本框
- 行间距
- 自适应属性
- 文本框锚点
- 文本制表符
- 默认文本样式
- C#
- Aspose.Slides for .NET
description: "在 C# 中管理和操作文本及文本框属性"
---

## 概述

本文描述了如何 **使用 C# 处理 PowerPoint 演示文稿的文本格式化**，例如高亮文本、应用正则表达式、对齐文本段落、设置文本透明度、改变段落字体属性、使用字体家族、设置文本旋转、自定义角度旋转、管理文本框、设置行间距、使用自适应属性、设置文本框锚点、改变文本制表符。文章涵盖了这些主题。

## **高亮文本**
新的 HighlightText 方法已添加到 ITextFrame 接口和 TextFrame 类。

它允许使用文本样本以背景颜色高亮文本部分，类似于 PowerPoint 2019 中的文本高亮颜色工具。

1. 实例化 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类并传入输入文件。
   - 输入文件可以是 PPT、PPTX、ODP 等。
3. 使用 [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) 集合访问其幻灯片。
4. 使用 [Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) 集合访问形状，并将其转换为 [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)。
5. 使用 [TextFrame.Highlight()](https://reference.aspose.com/slides/net/aspose.slides/textframe/highlighttext/#highlighttext) 方法高亮文本。
6. 以所需的输出格式保存演示文稿，即 PPT、PPTX 或 ODP 等。

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightText("title", Color.LightBlue); // 高亮所有词语 'important'
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightText("to", Color.Violet, new TextHighlightingOptions()
{
    WholeWordsOnly = true
}); // 高亮所有单独的 'the' 出现
presentation.Save("SomePresentation-out2.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}} 

Aspose 提供了一个简单的 [免费在线 PowerPoint 编辑服务](https://products.aspose.app/slides/editor)

{{% /alert %}} 


## **使用正则表达式高亮文本**
新的 HighlightRegex 方法已添加到 ITextFrame 接口和 TextFrame 类。

它允许使用正则表达式以背景颜色高亮文本部分，类似于 PowerPoint 2019 中的文本高亮颜色工具。

以下代码片段显示如何使用此功能：

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
TextHighlightingOptions options = new TextHighlightingOptions();
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightRegex(@"\b[^\s]{5,}\b", Color.Blue, options); // 高亮所有 10 个符号或更长的词语
presentation.Save("SomePresentation-out.pptx", SaveFormat.Pptx);
```

## **设置文本背景颜色**

Aspose.Slides 允许您为文本设置偏好的背景颜色。

以下 C# 代码显示您如何为整个文本设置背景颜色： 

```c#
using (Presentation pres = new Presentation())
{
    IAutoShape autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.TextFrame.Paragraphs.Clear();

    Paragraph para = new Paragraph();

    var portion1 = new Portion("Black");
    portion1.PortionFormat.FontBold = NullableBool.True;
    
    var portion2 = new Portion(" Red ");
    
    var portion3 = new Portion("Black");
    portion3.PortionFormat.FontBold = NullableBool.True;
    
    para.Portions.Add(portion1);
    para.Portions.Add(portion2);
    para.Portions.Add(portion3);
    autoShape.TextFrame.Paragraphs.Add(para);
    
    pres.Save("text.pptx", SaveFormat.Pptx);
}

using (Presentation pres = new Presentation("text.pptx"))
{
    var autoShape = (IAutoShape)pres.Slides[0].Shapes[0];

    foreach (IPortion portion in autoShape.TextFrame.Paragraphs[0].Portions)
    {
        portion.PortionFormat.HighlightColor.Color = Color.Blue;
    }

    pres.Save("text-red.pptx", SaveFormat.Pptx);
}
```

此 C# 代码显示您如何仅为部分文本设置背景颜色：

```c#
using (Presentation pres = new Presentation())
{
    IAutoShape autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.TextFrame.Paragraphs.Clear();

    Paragraph para = new Paragraph();

    var portion1 = new Portion("Black");
    portion1.PortionFormat.FontBold = NullableBool.True;
    
    var portion2 = new Portion(" Red ");
    
    var portion3 = new Portion("Black");
    portion3.PortionFormat.FontBold = NullableBool.True;
    
    para.Portions.Add(portion1);
    para.Portions.Add(portion2);
    para.Portions.Add(portion3);
    autoShape.TextFrame.Paragraphs.Add(para);
    
    pres.Save("text.pptx", SaveFormat.Pptx);
}

using (Presentation pres = new Presentation("text.pptx"))
{
    var autoShape = (IAutoShape)pres.Slides[0].Shapes[0];

    IPortion redPortion = autoShape.TextFrame.Paragraphs[0].Portions
        .First(p => p.Text.Contains("Red"));

    redPortion.PortionFormat.HighlightColor.Color = Color.Red;
    
    pres.Save("text-red.pptx", SaveFormat.Pptx);
}
```

## **对齐文本段落**

文本格式化是创建任何类型文档或演示文稿的关键元素之一。我们知道 Aspose.Slides for .NET 支持向幻灯片中添加文本，但在本主题中，我们将看到如何控制幻灯片中文本段落的对齐。请按照以下步骤使用 Aspose.Slides for .NET 对齐文本段落：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 使用其索引获取幻灯片的引用。
3. 访问幻灯片中存在的占位符形状，并将其类型转换为 AutoShape。
4. 从 AutoShape 暴露的 TextFrame 中获取（需要对齐的）段落。
5. 对齐段落。段落可以对齐到右边、左边、居中和两端对齐。
6. 将修改后的演示文稿写入 PPTX 文件。

以上步骤的实现如下。

```c#
// 实例化表示 PPTX 文件的 Presentation 对象
using (Presentation pres = new Presentation("ParagraphsAlignment.pptx"))
{

    // 访问第一张幻灯片
    ISlide slide = pres.Slides[0];

    // 访问幻灯片中的第一个和第二个占位符并将其类型转换为 AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.Shapes[0]).TextFrame;
    ITextFrame tf2 = ((IAutoShape)slide.Shapes[1]).TextFrame;

    // 更改两个占位符中的文本
    tf1.Text = "根据 Aspose 居中对齐";
    tf2.Text = "根据 Aspose 居中对齐";

    // 获取占位符的第一个段落
    IParagraph para1 = tf1.Paragraphs[0];
    IParagraph para2 = tf2.Paragraphs[0];

    // 将文本段落对齐到中心
    para1.ParagraphFormat.Alignment = TextAlignment.Center;
    para2.ParagraphFormat.Alignment = TextAlignment.Center;

    // 将演示文稿写入 PPTX 文件
    pres.Save("Centeralign_out.pptx", SaveFormat.Pptx);
}
```


## **设置文本透明度**
本文演示如何使用 Aspose.Slides for .NET 为任何文本形状设置透明度属性。为文本设置透明度，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 获取幻灯片的引用。
3. 设置阴影颜色。
4. 将演示文稿写入 PPTX 文件。

以上步骤的实现如下。

```c#
using (Presentation pres = new Presentation("transparency.pptx"))
{
    IAutoShape shape = (IAutoShape)pres.Slides[0].Shapes[0];
    IEffectFormat effects = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.EffectFormat;

    IOuterShadow outerShadowEffect = effects.OuterShadowEffect;

    Color shadowColor = outerShadowEffect.ShadowColor.Color;
    Console.WriteLine($"{shadowColor} - 透明度为: {((float)shadowColor.A / byte.MaxValue) * 100}");

    // 将透明度设置为零百分比
    outerShadowEffect.ShadowColor.Color = Color.FromArgb(255, shadowColor);

    pres.Save("transparency-2.pptx", SaveFormat.Pptx);
}
```

## **设置文本的字符间距**

Aspose.Slides 允许您设置文本框中字母之间的间距。通过这种方式，您可以通过扩展或压缩字符之间的间距来调整文本行或块的视觉密度。

以下 C# 代码展示了如何扩展一行文本的间距并收缩另一行文本的间距：

```c#
var presentation = new Presentation("in.pptx");

var textBox1 = (IAutoShape) presentation.Slides[0].Shapes[0];
var textBox2 = (IAutoShape) presentation.Slides[0].Shapes[1];

textBox1.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.Spacing = 20; // 扩展
textBox2.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.Spacing = -2; // 收缩

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **管理段落的字体属性**

演示文稿通常包含文本和图像。文本可以以多种方式格式化，无论是为了突出特定部分和单词，还是符合企业风格。文本格式化有助于用户改变演示文稿内容的外观和感觉。本文展示了如何使用 Aspose.Slides for .NET 配置幻灯片上文本段落的字体属性。要使用 Aspose.Slides for .NET 管理段落的字体属性：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 使用其索引获取幻灯片的引用。
3. 访问幻灯片中的占位符形状并将其类型转换为 AutoShape。
4. 从 AutoShape 暴露的 TextFrame 中获取段落。
5. 对段落进行对齐。
6. 访问段落的文本部分。
7. 使用 FontData 定义字体，并相应地设置文本部分的字体。
   1. 将字体设置为粗体。
   1. 将字体设置为斜体。
8. 使用部分对象暴露的 FillFormat 设置字体颜色。
9. 将修改后的演示文稿写入 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

以上步骤的实现如下。它使用一个未装饰的演示文稿并对其中一张幻灯片的字体进行格式化。

```c#
// 实例化表示 PPTX 文件的 Presentation 对象
using (Presentation pres = new Presentation("FontProperties.pptx"))
{

    // 通过其幻灯片位置访问幻灯片
    ISlide slide = pres.Slides[0];

    // 访问幻灯片中的第一个和第二个占位符并将其类型转换为 AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.Shapes[0]).TextFrame;
    ITextFrame tf2 = ((IAutoShape)slide.Shapes[1]).TextFrame;

    // 访问第一个段落
    IParagraph para1 = tf1.Paragraphs[0];
    IParagraph para2 = tf2.Paragraphs[0];

    // 访问第一个部分
    IPortion port1 = para1.Portions[0];
    IPortion port2 = para2.Portions[0];

    // 定义新字体
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // 将新字体分配给部分
    port1.PortionFormat.LatinFont = fd1;
    port2.PortionFormat.LatinFont = fd2;

    // 设置字体为粗体
    port1.PortionFormat.FontBold = NullableBool.True;
    port2.PortionFormat.FontBold = NullableBool.True;

    // 设置字体为斜体
    port1.PortionFormat.FontItalic = NullableBool.True;
    port2.PortionFormat.FontItalic = NullableBool.True;

    // 设置字体颜色
    port1.PortionFormat.FillFormat.FillType = FillType.Solid;
    port1.PortionFormat.FillFormat.SolidFillColor.Color = Color.Purple;
    port2.PortionFormat.FillFormat.FillType = FillType.Solid;
    port2.PortionFormat.FillFormat.SolidFillColor.Color = Color.Peru;

    //将 PPTX 保存到磁盘
    pres.Save("WelcomeFont_out.pptx", SaveFormat.Pptx);
}
```


## **管理文本的字体家族**
部分用于在段落中保存具有相似格式样式的文本。本文展示了如何使用 Aspose.Slides for .NET 创建一个包含一些文本的文本框，然后定义特定的字体和字体家族类别的各种其他属性。要创建文本框并设置其中文本的字体属性：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 使用其索引获取幻灯片的引用。
3. 向幻灯片添加类型为矩形的 AutoShape。
4. 移除与 AutoShape 关联的填充样式。
5. 访问 AutoShape 的 TextFrame。
6. 向 TextFrame 添加一些文本。
7. 访问与 TextFrame 关联的 Portion 对象。
8. 定义用于 Portion 的字体。
9. 使用 Portion 对象暴露的相关属性设置其他字体属性，例如粗体、斜体、下划线、颜色和高度。
10. 将修改后的演示文稿写入 PPTX 文件。

以下是上述步骤的实现。

```c#
// 实例化 Presentation
using (Presentation presentation = new Presentation())
{
   
    // 获取第一张幻灯片
    ISlide sld = presentation.Slides[0];

    // 添加类型为矩形的 AutoShape
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // 移除与 AutoShape 关联的任何填充样式
    ashp.FillFormat.FillType = FillType.NoFill;

    // 访问与 AutoShape 关联的 TextFrame
    ITextFrame tf = ashp.TextFrame;
    tf.Text = "Aspose 文本框";

    // 访问与 TextFrame 关联的 Portion
    IPortion port = tf.Paragraphs[0].Portions[0];

    // 设置 Portion 的字体
    port.PortionFormat.LatinFont = new FontData("Times New Roman");

    // 设置字体的粗体属性
    port.PortionFormat.FontBold = NullableBool.True;

    // 设置字体的斜体属性
    port.PortionFormat.FontItalic = NullableBool.True;

    // 设置字体的下划线属性
    port.PortionFormat.FontUnderline = TextUnderlineType.Single;

    // 设置字体的高度
    port.PortionFormat.FontHeight = 25;

    // 设置字体的颜色
    port.PortionFormat.FillFormat.FillType = FillType.Solid;
    port.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // 保存 PPTX 到磁盘 
    presentation.Save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
}
```

## **设置文本的字体大小**

Aspose.Slides 允许您为段落中的现有文本及将来可能添加的其他文本选择自己偏好的字体大小。

以下 C# 代码展示了如何为包含在段落中的文本设置字体大小：

```c#
var presentation = new Presentation("example.pptx");

// 获取第一个形状，例如。
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape autoShape)
{
    // 获取第一个段落，例如。
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 将所有文本部分的默认字体大小设置为 20 磅。 
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;

    // 将当前段落中的文本部分的字体大小设置为 20 磅。
    foreach (var portion in paragraph.Portions)
    {
        portion.PortionFormat.FontHeight = 20;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **设置文本旋转**

Aspose.Slides for .NET 允许开发人员旋转文本。文本可以设置为水平、垂直、垂直270、WordArt垂直、东亚垂直、蒙古垂直或从左到右的WordArt 垂直。要旋转任何 TextFrame 的文本，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 访问第一张幻灯片。
3. 向幻灯片添加任意形状。
4. 访问 TextFrame。
5. 旋转文本。
6. 将文件保存到磁盘。

```c#
// 创建 Presentation 类的实例
Presentation presentation = new Presentation();

// 获取第一张幻灯片 
ISlide slide = presentation.Slides[0];

// 添加类型为矩形的 AutoShape
IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

// 向矩形添加 TextFrame
ashp.AddTextFrame(" ");
ashp.FillFormat.FillType = FillType.NoFill;

// 访问文本框
ITextFrame txtFrame = ashp.TextFrame;
txtFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

// 为文本框创建段落对象
IParagraph para = txtFrame.Paragraphs[0];

// 为段落创建部分对象
IPortion portion = para.Portions[0];
portion.Text = "一只快速的棕色狐狸跳过懒狗。一只快速的棕色狐狸跳过懒狗。";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// 保存演示文稿
presentation.Save("RotateText_out.pptx", SaveFormat.Pptx);
```


## **设置文本框的自定义旋转角度**
Aspose.Slides for .NET 现在支持设置文本框的自定义旋转角度。在本主题中，我们将看到如何在 Aspose.Slides 中设置 RotationAngle 属性。新的 RotationAngle 属性已添加到 IChartTextBlockFormat 和 ITextFrameFormat 接口中，允许设置文本框的自定义旋转角度。要设置 RotationAngle 属性，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 在幻灯片上添加一个图表。
3. 设置 RotationAngle 属性。
4. 将演示文稿写入 PPTX 文件。

在以下示例中，我们设置 RotationAngle 属性。

```c#
// 创建 Presentation 类的实例
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("自定义标题").TextFrameFormat.RotationAngle = -30;

// 保存演示文稿
presentation.Save("textframe-rotation_out.pptx", SaveFormat.Pptx);
```


## **段落的行间距**
Aspose.Slides 提供了属性 ([SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/spaceafter), [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/spacebefore) 和 [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/spacewithin)) 在 [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/) 类下，允许您管理段落的行间距。这三个属性的用法如下：

* 要以百分比指定段落的行间距，请使用正值。 
* 要以点数指定段落的行间距，请使用负值。

例如，您可以通过将 `SpaceBefore` 属性设置为 -16 来为段落应用 16 磅的行间距。

以下是如何为特定段落指定行间距：

1. 加载一个包含某些文本的 AutoShape 的演示文稿。
2. 通过其索引获取幻灯片的引用。
3. 访问 TextFrame。
4. 访问段落。
5. 设置段落属性。
6. 保存演示文稿。

以下 C# 代码展示了如何为段落指定行间距：

```c#
// 创建 Presentation 类的实例
Presentation presentation = new Presentation("Fonts.pptx");

// 通过其索引获取幻灯片的引用
ISlide sld = presentation.Slides[0];

// 访问 TextFrame
ITextFrame tf1 = ((IAutoShape)sld.Shapes[0]).TextFrame;

// 访问段落
IParagraph para1 = tf1.Paragraphs[0];

// 设置段落的属性
para1.ParagraphFormat.SpaceWithin = 80;
para1.ParagraphFormat.SpaceBefore = 40;
para1.ParagraphFormat.SpaceAfter = 40;
// 保存演示文稿
presentation.Save("LineSpacing_out.pptx", SaveFormat.Pptx);
```


## **设置文本框的 AutofitType 属性**
在本主题中，我们将探索文本框的不同格式属性。本文涵盖如何设置文本框的 AutofitType 属性、文本的锚点以及在演示文稿中旋转文本。Aspose.Slides for .NET 允许开发人员为任何文本框设置 AutofitType 属性。AutofitType 可以设置为 Normal 或 Shape。如果设置为 Normal，则形状将保持不变，而文本将进行调整而不导致形状发生变化；如果 AutofitType 设置为 Shape，则形状将被修改，以便仅包含所需的文本。要设置文本框的 AutofitType 属性，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 访问第一张幻灯片。
3. 向幻灯片添加任意形状。
4. 访问 TextFrame。
5. 设置 TextFrame 的 AutofitType。
6. 将文件保存到磁盘。

```c#
// 创建 Presentation 类的实例
Presentation presentation = new Presentation();

// 访问第一张幻灯片 
ISlide slide = presentation.Slides[0];

// 添加类型为矩形的 AutoShape
IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

// 向矩形添加 TextFrame
ashp.AddTextFrame(" ");
ashp.FillFormat.FillType = FillType.NoFill;

// 访问文本框
ITextFrame txtFrame = ashp.TextFrame;
txtFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

// 为文本框创建段落对象
IParagraph para = txtFrame.Paragraphs[0];

// 为段落创建部分对象
IPortion portion = para.Portions[0];
portion.Text = "一只快速的棕色狐狸跳过懒狗。一只快速的棕色狐狸跳过懒狗。";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// 保存演示文稿
presentation.Save("formatText_out.pptx", SaveFormat.Pptx); 
```


## **设置文本框的锚点**
Aspose.Slides for .NET 允许开发人员设置任何 TextFrame 的锚点。TextAnchorType 指定文本在形状中的位置。TextAnchorType 可以设置为顶部、中间、底部、两端对齐或均匀分布。要设置任何 TextFrame 的锚点，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 访问第一张幻灯片。
3. 向幻灯片添加任意形状。
4. 访问 TextFrame。
5. 设置 TextAnchorType 的 TextFrame。
6. 将文件保存到磁盘。

```c#
// 创建 Presentation 类的实例
Presentation presentation = new Presentation();

// 获取第一张幻灯片 
ISlide slide = presentation.Slides[0];

// 添加类型为矩形的 AutoShape
IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

// 向矩形添加 TextFrame
ashp.AddTextFrame(" ");
ashp.FillFormat.FillType = FillType.NoFill;

// 访问文本框
ITextFrame txtFrame = ashp.TextFrame;
txtFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

// 为文本框创建段落对象
IParagraph para = txtFrame.Paragraphs[0];

// 为段落创建部分对象
IPortion portion = para.Portions[0];
portion.Text = "一只快速的棕色狐狸跳过懒狗。一只快速的棕色狐狸跳过懒狗。";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// 保存演示文稿
presentation.Save("AnchorText_out.pptx", SaveFormat.Pptx);
```

## **设置文本制表符**
- EffectiveTabs.ExplicitTabCount (在本例中为 2) 属性等于 Tabs.Count。
- EffectiveTabs 集合包括所有制表符（来自 Tabs 集合和默认制表符）。
- EffectiveTabs.ExplicitTabCount (在本例中为 2) 属性等于 Tabs.Count。
- EffectiveTabs.DefaultTabSize (294) 属性显示了默认制表符之间的距离（在我们的示例中为 3 和 4）。
- 使用 EffectiveTabs.GetTabByIndex(index) 和 index = 0 将返回第一个显式制表符（Position = 731），index = 1 - 第二个制表符（Position = 1241）。如果尝试使用 index = 2 获取下一个制表符，则它将返回第一个默认制表符（Position = 1470）等等。
- 使用 EffectiveTabs.GetTabAfterPosition(pos) 用于在某些文本后获取下一个制表符。例如您有文本：“Helloworld！”。为了渲染这样的文本，您需要知道在哪里开始绘制“world！”。首先，您应该计算“Hello”的像素长度，随后调用 GetTabAfterPosition，传入这个值。您将获得下一个制表符的位置来绘制“world！”。

## **设置校对语言**

Aspose.Slides 提供了 [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) 属性（由 [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) 类暴露），允许您为 PowerPoint 文档设置校对语言。校对语言是检查 PowerPoint 中拼写和语法的语言。

以下 C# 代码展示了如何设置 PowerPoint 的校对语言：

```c#
using (Presentation pres = new Presentation(pptxFileName))
{
    AutoShape autoShape = (AutoShape)pres.Slides[0].Shapes[0];

    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.PortionFormat;
    portionFormat.ComplexScriptFont = font;
    portionFormat.EastAsianFont = font;
    portionFormat.LatinFont = font;

    portionFormat.LanguageId = "zh-CN"; // 设置校对语言的 Id
    
    newPortion.Text = "1。";
    paragraph.Portions.Add(newPortion);
}
```

## **设置默认语言**

以下 C# 代码展示了如何为整个 PowerPoint 演示文稿设置默认语言：

```c#
LoadOptions loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";
using (Presentation pres = new Presentation(loadOptions))
{
    // 添加一个带文本的新矩形形状
    IAutoShape shp = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.TextFrame.Text = "新文本";
    
    // 检查第一个部分的语言
    Console.WriteLine(shp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId);
}
```

## **设置默认文本样式**

如果您需要将相同的默认文本格式应用于演示文稿中的所有文本元素，可以使用 [IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/) 接口中的 `DefaultTextStyle` 属性并设置首选格式。以下代码示例显示如何在新的演示文稿中为所有幻灯片上的文本设置默认粗体字体（14 磅）。

```c#
using (Presentation presentation = new Presentation())
{
    // 获取顶级段落格式。
    IParagraphFormat paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("DefaultTextStyle.pptx", SaveFormat.Pptx);
}
```