---
title: 在 .NET 中管理演示文稿的项目符号和编号列表
linktitle: 管理列表
type: docs
weight: 70
url: /zh/net/manage-lists/
aliases:
  - /net/manage-bullet-and-numbered-lists/
keywords:
  - 项目符号
  - 项目符号列表
  - 编号列表
  - 符号项目符号
  - 图片项目符号
  - 自定义项目符号
  - 多层列表
  - 创建项目符号
  - 添加项目符号
  - 添加列表
  - PowerPoint
  - OpenDocument
  - 演示文稿
  - .NET
  - C#
  - Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 演示文稿中创建和格式化项目符号、图片、多层和编号列表。"
---
## **概述**

Aspose.Slides for .NET 让您能够在 PowerPoint 和 OpenDocument 演示文稿中创建和格式化项目符号和编号列表。列表项是段落，其项目符号设置通过段落格式进行控制。

使用[IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/)属性访问段落级别的列表设置。主要入口是[IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/)，它返回一个[IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/)对象。通过该对象，您可以设置项目符号类型、符号、图片、颜色、大小、编号样式和起始编号。

本文展示了如何：

- 使用自定义符号创建项目符号列表
- 创建图片项目符号
- 通过设置段落深度创建多级列表
- 创建编号列表
- 检查并更改现有演示文稿中的列表格式
- 在段落文本旁读取实际的列表标记和编号

## **创建项目符号列表**

要创建项目符号列表，向[ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)添加[IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/)对象，并将[IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/)设置为[BulletType.Symbol](https://reference.aspose.com/slides/net/aspose.slides/bullettype/)。随后您可以设置[IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/)、[IBulletFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/color/)和[IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/)来控制项目符号的外观。

以下 C# 代码演示了如何在幻灯片中创建项目符号列表：

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

static Paragraph CreateParagraph(string text)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.IndianRed;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = CreateParagraph("The first paragraph");
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph");
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("symbol_bullets.pptx", SaveFormat.Pptx);
```

效果：

![The symbol bullets](symbol_bullets.png)

## **创建编号列表**

当项的顺序很重要时使用编号列表。将[IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/)设置为[BulletType.Numbered](https://reference.aspose.com/slides/net/aspose.slides/bullettype/)。您还可以使用[IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/)选择编号格式，或在列表应从除 1 之外的其他值开始时设置[IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/)。

以下 C# 代码展示了如何在幻灯片中创建编号列表：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph1.Text = "Apple";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph2.Text = "Orange";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph3.Text = "Banana";
textFrame.Paragraphs.Add(paragraph3);

presentation.Save("numbered_bullets.pptx", SaveFormat.Pptx);
```

效果：

![The numbered bullets](numbered_bullets.png)

## **创建图片项目符号**

Aspose.Slides 允许您用图像替换普通的项目符号符号。图片项目符号最适合使用在小尺寸下仍保持可读性的简单图像，如图标或小型透明 PNG 文件。

{{% alert color="info" title="Note" %}}
理想情况下，如果您计划用图像替换普通项目符号，最好选择具有透明背景的简洁图形。这类图像非常适合作为自定义项目符号。
{{% /alert %}}

请注意，图像会缩小到非常小的尺寸。因此，我们强烈建议选择在列表中用作项目符号时仍然清晰且视觉有效的图片。

要创建图片项目符号，向[Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/images/)添加图像，并将返回的图像对象分配给[IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/)。在分配图像之前，将[IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/)设置为[BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/)。

假设我们有一张 “image.png”：

![A picture for the bullets](picture_for_bullets.png)

以下 C# 代码展示了如何在幻灯片中创建图片项目符号：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

static Paragraph CreateParagraph(string text, IPPImage image)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var imageBytes = File.ReadAllBytes("image.png");
var bulletImage = presentation.Images.AddImage(imageBytes);

var paragraph1 = CreateParagraph("The first paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("picture_bullets.pptx", SaveFormat.Pptx);
```

效果：

![The picture bullets](picture_bullets.png)

## **创建多级列表**

使用[IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/)可以将列表项放置在不同层级。层级 0 为顶层，层级 1 位于其下，以此类推。

以下 C# 代码展示了如何创建多级项目符号列表：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Depth = 0;
paragraph1.Text = "My text - Depth 0";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Depth = 1;
paragraph2.Text = "My text - Depth 1";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Depth = 2;
paragraph3.Text = "My text - Depth 2";
textFrame.Paragraphs.Add(paragraph3);

var paragraph4 = new Paragraph();
paragraph4.ParagraphFormat.Depth = 3;
paragraph4.Text = "My text - Depth 3";
textFrame.Paragraphs.Add(paragraph4);

presentation.Save("multilevel_bullets.pptx", SaveFormat.Pptx);
```

效果：

![The multilevel list](multilevel_list.png)

## **更改现有列表**

要更改现有演示文稿中的列表格式，访问目标段落并更新其[IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/)设置。创建列表时使用的相同属性也可用于检查或修改从 PPT、PPTX 或 ODP 文件加载的列表。

以下 C# 代码将文本框中的第一段落更改为使用编号列表样式：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var autoShape = (IAutoShape)slide.Shapes[0];

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletRomanUCPeriod;
paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 1;
paragraph.ParagraphFormat.MarginLeft = 30;
paragraph.ParagraphFormat.Indent = -20;

presentation.Save("updated_list.pptx", SaveFormat.Pptx);
```

## **读取实际项目符号值**

在提取演示文稿内容时，请将列表标记与段落文本一起保留。调用[IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/)并访问[IParagraphFormatEffectiveData.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformateffectivedata/bullet/)即可获取有效的项目符号格式。在读取[ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/)之前，先检查其[Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/type/)。

对于编号列表，以下三个值需加以区分：

- [NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstyle/)决定格式，例如带句点的阿拉伯数字或带句点的小写字母。
- [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstartwith/)指定一组编号段落的起始数字。
- [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/)返回特定段落的格式化标记。例如，从 5 开始的列表中第二项返回 `6.`。

请在每个段落中保留[Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/)，以维持其嵌套层级。实际标记并不编码完整层级：嵌套项可能只返回 `c.`，而不是类似 `6.c.` 的组合标签。

以下完整示例创建列表、将其保存到演示文稿，并重新加载演示文稿以报告每个段落的文本、深度、项目符号类型和实际值。小蓝色图片标记来自内联 SVG。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    presentation.SlideSize.SetSize(720, 440, SlideSizeScaleType.DoNotScale);
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20, 660, 400);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Paragraphs.Clear();

    // 创建一个没有外部图像文件的图片标记。
    var svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    var bulletImage = presentation.Images.AddImage(svg);

    void AddParagraph(string text, short depth, BulletType type, short start = 1, NumberedBulletStyle style = NumberedBulletStyle.BulletArabicPeriod)
    {
        var paragraph = new Paragraph { Text = text };

        var format = paragraph.ParagraphFormat;
        format.Depth = depth;
        format.MarginLeft = 30 + depth * 40;
        format.Indent = -28;
        format.SpaceAfter = 8;
        format.DefaultPortionFormat.FontHeight = 22;
        format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
        format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
        format.Bullet.Type = type;
        format.Bullet.IsBulletHardColor = NullableBool.True;
        format.Bullet.Color.Color = Color.Black;
        if (type == BulletType.Numbered)
        {
            format.Bullet.NumberedBulletStyle = style;
            format.Bullet.NumberedBulletStartWith = start;
        }
        else if (type == BulletType.Symbol)
        {
            format.Bullet.Char = '\u2022';
        }
        else if (type == BulletType.Picture)
        {
            format.Bullet.Picture.Image = bulletImage;
        }

        textFrame.Paragraphs.Add(paragraph);
    }

    AddParagraph("First item", 0, BulletType.Numbered, 5);
    AddParagraph("Second item", 0, BulletType.Numbered, 5);
    AddParagraph("Nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    AddParagraph("Next nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    AddParagraph("Deep item", 2, BulletType.Numbered, 4, NumberedBulletStyle.BulletRomanLCPeriod);
    AddParagraph("Back to top level", 0, BulletType.Numbered, 5);
    AddParagraph("Symbol marker", 0, BulletType.Symbol);
    AddParagraph("No bullet", 0, BulletType.None);
    AddParagraph("Picture marker", 0, BulletType.Picture);
    presentation.Save("actual_bullet_values.pptx", SaveFormat.Pptx);
}

using var loadedPresentation = new Presentation("actual_bullet_values.pptx");
var loadedShape = (IAutoShape)loadedPresentation.Slides[0].Shapes[0];
Console.WriteLine("Text | Depth | Type | Actual value");
foreach (var paragraph in loadedShape.TextFrame.Paragraphs)
{
    var bullet = paragraph.ParagraphFormat.GetEffective().Bullet;
    string marker;
    switch (bullet.Type)
    {
        case BulletType.Numbered:
        case BulletType.Symbol:
            marker = bullet.ActualBulletValue;
            break;
        case BulletType.None:
            marker = $"{bullet.ActualBulletValue ?? "null"} (no bullet)";
            break;
        case BulletType.Picture:
            marker = $"{bullet.ActualBulletValue ?? "null"} (image required)";
            break;
        default:
            marker = "unsupported bullet type";
            break;
    }
    Console.WriteLine($"{paragraph.Text} | {paragraph.ParagraphFormat.Depth} | {bullet.Type} | {marker}");
}
```

下面显示了源列表。

![Lists starting at 5, nested letter and Roman-number items, a symbol marker, a paragraph without a bullet, and a blue picture marker](actual_bullet_values.png)

报告与 PowerPoint 中显示的标记相匹配：

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

对于[BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/)，[ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/)返回 `null`，而不是空字符串。请分别处理这些类型：前者没有标记，后者需要单独提取项目符号图像。图片项目符号无法仅通过提取文本标记来再现。

## **常见问题**

**项目符号和编号列表可以导出为 PDF 或图像吗？**

可以。Aspose.Slides 在目标格式支持相应文本布局和项目符号特性的情况下，会保留列表格式。

**我可以编辑现有演示文稿中的列表吗？**

可以。加载演示文稿，访问目标段落，检查或更新其[IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/)设置，然后保存演示文稿。

**列表可以包含非拉丁文字吗？**

可以。列表项文本支持 Unicode 字符，您可以在多语言演示文稿中创建列表。请确保演示文稿使用的字体支持所需的字符。