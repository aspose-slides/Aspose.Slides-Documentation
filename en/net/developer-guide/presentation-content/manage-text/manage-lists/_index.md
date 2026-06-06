---
title: Manage Bulleted and Numbered Lists in Presentations in .NET
linktitle: Manage Lists
type: docs
weight: 70
url: /net/manage-lists/
keywords:
- bullet
- bulleted list
- numbered list
- symbol bullet
- picture bullet
- custom bullet
- multilevel list
- create bullet
- add bullet
- add list
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Learn how to create and format bulleted, picture, multilevel, and numbered lists in PowerPoint and OpenDocument presentations using Aspose.Slides for .NET."
---

## **Overview**

Aspose.Slides for .NET lets you create and format bulleted and numbered lists in PowerPoint and OpenDocument presentations. A list item is a paragraph whose bullet settings are controlled through its paragraph format.

Use the [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) property to access paragraph-level list settings. The main entry point is [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/), which returns an [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) object. With this object, you can set the bullet type, symbol, picture, color, size, numbering style, and starting number.

This article shows how to:

- create a bulleted list with a custom symbol
- create a picture bullet
- create a multilevel list by setting paragraph depth
- create a numbered list
- inspect and change list formatting in an existing presentation

## **Create a Bulleted List**

To create a bulleted list, add [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) objects to an [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) and set [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) to [BulletType.Symbol](https://reference.aspose.com/slides/net/aspose.slides/bullettype/). You can then set [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/color/), and [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) to control the bullet appearance.

The following C# code demonstrates how to create a bulleted list in a slide:

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

The result:

![The symbol bullets](symbol_bullets.png)

## **Create a Numbered List**

Use numbered lists when the order of items matters. Set [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) to [BulletType.Numbered](https://reference.aspose.com/slides/net/aspose.slides/bullettype/). You can also choose a numbering format with [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) or set [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) when the list should start from a value other than 1.

The following C# code shows how to create a numbered list in a slide:

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

The result:

![The numbered bullets](numbered_bullets.png)

## **Create a Picture Bullet**

Aspose.Slides allows you to replace a regular bullet symbol with an image. Picture bullets work best with simple images that remain readable at a small size, such as icons or small transparent PNG files.

 {{% alert color="primary" %}}

Ideally, if you plan to replace the regular bullet symbol with an image, it's best to choose a simple graphic with a transparent background. Such images work well as custom bullet symbols.

Keep in mind that the image will be scaled down to a very small size. For that reason, we strongly recommend selecting an image that remains clear and visually effective when used as a bullet in a list.

{{% /alert %}}

To create a picture bullet, add an image to [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/images/) and assign the returned image object to [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/). Set [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) to [BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) before assigning the image.

Let's say we have an "image.png":

![A picture for the bullets](picture_for_bullets.png)

The following C# code shows how to create picture bullets in a slide:

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

The result:

![The picture bullets](picture_bullets.png)

## **Create a Multilevel List**

Use [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) to place list items on different levels. Level 0 is the top level, level 1 is nested below it, and so on.

The following C# code shows how to create a multilevel bulleted list:

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

The result:

![The multilevel list](multilevel_list.png)

## **Change an Existing List**

To change list formatting in an existing presentation, access the target paragraph and update its [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/) settings. The same properties used to create lists can be used to inspect or modify lists loaded from a PPT, PPTX, or ODP file.

The following C# code changes the first paragraph in a text frame to use a numbered list style:

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

## **FAQ**

**Can bulleted and numbered lists be exported to PDF or images?**

Yes. Aspose.Slides preserves list formatting when the target format supports the corresponding text layout and bullet features.

**Can I edit lists in existing presentations?**

Yes. Load the presentation, access the target paragraph, inspect or update its [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/) settings, and save the presentation.

**Can lists contain non-Latin text?**

Yes. List item text can contain Unicode characters, so you can create lists in multilingual presentations. Make sure the fonts used in the presentation support the characters you need.
