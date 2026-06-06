---
title: 在 .NET 中管理演示文稿的项目符号和编号列表
linktitle: 管理列表
type: docs
weight: 70
url: /zh/net/manage-lists/
keywords:
- 项目符号
- 项目符号列表
- 编号列表
- 符号项目符号
- 图片项目符号
- 自定义项目符号
- 多级列表
- 创建项目符号
- 添加项目符号
- 添加列表
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 演示文稿中创建和格式化项目符号、图片、多级和编号列表。"
---
## **概述**

Aspose.Slides for .NET 允许您在 PowerPoint 和 OpenDocument 演示文稿中创建和格式化项目符号列表和编号列表。列表项是一个段落，其项目符号设置通过段落格式进行控制。

使用[IParagraph.ParagraphFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraph/paragraphformat/)属性访问段落级别的列表设置。主要入口是[IParagraphFormat.Bullet](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/bullet/)，它返回一个[IBulletFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ibulletformat/)对象。通过该对象，您可以设置项目符号类型、符号、图片、颜色、大小、编号样式以及起始编号。

本文展示如何：

- 创建带自定义符号的项目符号列表
- 创建图片项目符号
- 通过设置段落深度创建多级列表
- 创建编号列表
- 检查并更改现有演示文稿中的列表格式

## **创建项目符号列表**

要创建项目符号列表，向[ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/)添加[IParagraph](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraph/)对象，并将[IBulletFormat.Type](https://reference.aspose.com/slides/zh/net/aspose.slides/ibulletformat/type/)设置为[BulletType.Symbol](https://reference.aspose.com/slides/zh/net/aspose.slides/bullettype/)。随后可以设置[IBulletFormat.Char](https://reference.aspose.com/slides/zh/net/aspose.slides/ibulletformat/char/)、[IBulletFormat.Color](https://reference.aspose.com/slides/zh/net/aspose.slides/ibulletformat/color/)和[IBulletFormat.Height](https://reference.aspose.com/slides/zh/net/aspose.slides/ibulletformat/height/)来控制项目符号的外观。

以下 C# 代码演示如何在幻灯片中创建项目符号列表：

```csharp
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

结果：

![符号项目符号](symbol_bullets.png)

## **创建编号列表**

当项目顺序重要时使用编号列表。将[IBulletFormat.Type](https://reference.aspose.com/slides/zh/net/aspose.slides/ibulletformat/type/)设置为[BulletType.Numbered](https://reference.aspose.com/slides/zh/net/aspose.slides/bullettype/)。还可以通过[IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/zh/net/aspose.slides/ibulletformat/numberedbulletstyle/)选择编号格式，或在列表应从除 1 之外的值开始时设置[IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/zh/net/aspose.slides/ibulletformat/numberedbulletstartwith/)。

以下 C# 代码展示如何在幻灯片中创建编号列表：

```csharp
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

结果：

![编号项目符号](numbered_bullets.png)

## **创建图片项目符号**

Aspose.Slides 允许您使用图像替换常规项目符号。图片项目符号最适合使用在小尺寸下仍然可读的简单图像，例如图标或小的透明 PNG 文件。

{{% alert color="primary" %}}
理想情况下，如果您计划用图像替换常规项目符号，最好选择具有透明背景的简单图形。这类图像可作为自定义项目符号使用。
{{% /alert %}}

要创建图片项目符号，向[Presentation.Images](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/images/)添加图像，并将返回的图像对象分配给[IBulletFormat.Picture](https://reference.aspose.com/slides/zh/net/aspose.slides/ibulletformat/picture/)。在分配图像之前，将[IBulletFormat.Type](https://reference.aspose.com/slides/zh/net/aspose.slides/ibulletformat/type/)设置为[BulletType.Picture](https://reference.aspose.com/slides/zh/net/aspose.slides/bullettype/)。

假设我们有一个 "image.png"：

![用于项目符号的图片](picture_for_bullets.png)

以下 C# 代码展示如何在幻灯片中创建图片项目符号：

```csharp
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

结果：

![图片项目符号](picture_bullets.png)

## **创建多级列表**

使用[IParagraphFormat.Depth](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/depth/)将列表项放置在不同层级。层级 0 为顶层，层级 1 为其下的嵌套层，以此类推。

以下 C# 代码展示如何创建多级项目符号列表：

```csharp
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

结果：

![多级列表](multilevel_list.png)

## **更改现有列表**

要更改现有演示文稿中的列表格式，访问目标段落并更新其[IParagraphFormat.Bullet](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/bullet/)设置。创建列表时使用的相同属性也可用于检查或修改从 PPT、PPTX 或 ODP 文件加载的列表。

以下 C# 代码将文本框中的第一个段落更改为使用编号列表样式：

```csharp
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

## **常见问题**

**是否可以将项目符号列表和编号列表导出为 PDF 或图像？**

可以。Aspose.Slides 在目标格式支持相应的文字布局和项目符号特性时，会保留列表格式。

**我可以编辑现有演示文稿中的列表吗？**

可以。加载演示文稿，访问目标段落，检查或更新其[IParagraphFormat.Bullet](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/bullet/)设置，然后保存演示文稿。

**列表可以包含非拉丁文字吗？**

可以。列表项文本可以包含 Unicode 字符，您可以在多语言演示文稿中创建列表。请确保演示文稿中使用的字体支持所需字符。