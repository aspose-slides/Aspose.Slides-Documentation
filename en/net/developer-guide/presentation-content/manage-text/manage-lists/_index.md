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
- create a numbered list
- create a picture bullet
- create a multilevel list by setting paragraph depth
- inspect and change list formatting in an existing presentation

## **Create a Bulleted List**

To create a bulleted list, add paragraphs to an [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) and set [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) to [BulletType.Symbol](https://reference.aspose.com/slides/net/aspose.slides/bullettype/). You can then set [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/color/), and [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) to control the bullet appearance.

The following C# example creates a simple bulleted list:

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 520, 180);
var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Review quarterly revenue" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
firstParagraph.ParagraphFormat.Bullet.Char = '*';
firstParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
firstParagraph.ParagraphFormat.Bullet.Color.Color = Color.DarkRed;
firstParagraph.ParagraphFormat.Bullet.Height = 100;
firstParagraph.ParagraphFormat.MarginLeft = 30;
firstParagraph.ParagraphFormat.Indent = -20;
textFrame.Paragraphs.Add(firstParagraph);

var secondParagraph = new Paragraph { Text = "Prepare product roadmap" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
secondParagraph.ParagraphFormat.Bullet.Char = '*';
secondParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
secondParagraph.ParagraphFormat.Bullet.Color.Color = Color.DarkRed;
secondParagraph.ParagraphFormat.Bullet.Height = 100;
secondParagraph.ParagraphFormat.MarginLeft = 30;
secondParagraph.ParagraphFormat.Indent = -20;
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph { Text = "Confirm launch milestones" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
thirdParagraph.ParagraphFormat.Bullet.Char = '*';
thirdParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
thirdParagraph.ParagraphFormat.Bullet.Color.Color = Color.DarkRed;
thirdParagraph.ParagraphFormat.Bullet.Height = 100;
thirdParagraph.ParagraphFormat.MarginLeft = 30;
thirdParagraph.ParagraphFormat.Indent = -20;
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("bulleted-list.pptx", SaveFormat.Pptx);
```

## **Create a Numbered List**

Use numbered lists when the order of items matters. Set [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) to [BulletType.Numbered](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) and choose a numbering format with [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/). You can also set [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) when the list should start from a value other than 1.

The following C# example creates a numbered list:

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 520, 180);
var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Open the source presentation" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
firstParagraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletArabicPeriod;
firstParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 1;
firstParagraph.ParagraphFormat.MarginLeft = 30;
firstParagraph.ParagraphFormat.Indent = -20;
textFrame.Paragraphs.Add(firstParagraph);

var secondParagraph = new Paragraph { Text = "Update the slide content" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
secondParagraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletArabicPeriod;
secondParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
secondParagraph.ParagraphFormat.MarginLeft = 30;
secondParagraph.ParagraphFormat.Indent = -20;
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph { Text = "Save the modified presentation" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
thirdParagraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletArabicPeriod;
thirdParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 3;
thirdParagraph.ParagraphFormat.MarginLeft = 30;
thirdParagraph.ParagraphFormat.Indent = -20;
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("numbered-list.pptx", SaveFormat.Pptx);
```

## **Create a Picture Bullet**

Aspose.Slides allows you to replace a regular bullet symbol with an image. Picture bullets work best with simple images that remain readable at a small size, such as icons or small transparent PNG files.

To create a picture bullet, add an image to [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/images/) and assign the returned [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) object to [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/).

The following C# example creates a list that uses an image as the bullet:

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 520, 180);
var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var imageBytes = File.ReadAllBytes("bullet.png");
var bulletImage = presentation.Images.AddImage(imageBytes);

var firstParagraph = new Paragraph { Text = "Analyze customer feedback" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
firstParagraph.ParagraphFormat.Bullet.Picture.Image = bulletImage;
firstParagraph.ParagraphFormat.Bullet.Height = 100;
firstParagraph.ParagraphFormat.MarginLeft = 30;
firstParagraph.ParagraphFormat.Indent = -20;
textFrame.Paragraphs.Add(firstParagraph);

var secondParagraph = new Paragraph { Text = "Prioritize product improvements" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
secondParagraph.ParagraphFormat.Bullet.Picture.Image = bulletImage;
secondParagraph.ParagraphFormat.Bullet.Height = 100;
secondParagraph.ParagraphFormat.MarginLeft = 30;
secondParagraph.ParagraphFormat.Indent = -20;
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("picture-bullets.pptx", SaveFormat.Pptx);
```

## **Create a Multilevel List**

Use [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) to place list items on different levels. Level 0 is the top level, level 1 is nested below it, and so on.

The following C# example creates a multilevel bulleted list:

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 520, 240);
var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Product launch" };
firstParagraph.ParagraphFormat.Depth = 0;
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
firstParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
firstParagraph.ParagraphFormat.MarginLeft = 30;
firstParagraph.ParagraphFormat.Indent = -20;
textFrame.Paragraphs.Add(firstParagraph);

var secondParagraph = new Paragraph { Text = "Finalize positioning" };
secondParagraph.ParagraphFormat.Depth = 1;
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
secondParagraph.ParagraphFormat.Bullet.Char = '-';
secondParagraph.ParagraphFormat.MarginLeft = 60;
secondParagraph.ParagraphFormat.Indent = -20;
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph { Text = "Publish release materials" };
thirdParagraph.ParagraphFormat.Depth = 1;
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
thirdParagraph.ParagraphFormat.Bullet.Char = '-';
thirdParagraph.ParagraphFormat.MarginLeft = 60;
thirdParagraph.ParagraphFormat.Indent = -20;
textFrame.Paragraphs.Add(thirdParagraph);

var fourthParagraph = new Paragraph { Text = "Measure launch results" };
fourthParagraph.ParagraphFormat.Depth = 0;
fourthParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
fourthParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
fourthParagraph.ParagraphFormat.MarginLeft = 30;
fourthParagraph.ParagraphFormat.Indent = -20;
textFrame.Paragraphs.Add(fourthParagraph);

presentation.Save("multilevel-list.pptx", SaveFormat.Pptx);
```

## **Change an Existing List**

To change list formatting in an existing presentation, access the target paragraph and update its [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/) settings. The same properties used to create lists can be used to inspect or modify lists loaded from a PPT, PPTX, or ODP file.

The following C# example changes the first paragraph in a text frame to use a numbered list style:

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

presentation.Save("updated-list.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Can bulleted and numbered lists be exported to PDF or images?**

Yes. Aspose.Slides preserves list formatting when the target format supports the corresponding text layout and bullet features.

**Can I edit lists in existing presentations?**

Yes. Load the presentation, access the target paragraph, inspect or update its [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/) settings, and save the presentation.

**Can lists contain non-Latin text?**

Yes. List item text can contain Unicode characters, so you can create lists in multilingual presentations. Make sure the fonts used in the presentation support the characters you need.
