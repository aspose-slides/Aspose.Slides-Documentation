---
title: Manage PowerPoint Text Paragraphs in .NET
linktitle: Manage Paragraph
type: docs
weight: 40
url: /net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- add text
- add paragraph
- manage text
- manage paragraph
- manage bullet
- paragraph indent
- hanging indent
- paragraph bullet
- numbered list
- bulleted list
- paragraph properties
- import HTML
- text to HTML
- paragraph to HTML
- paragraph to image
- text to image
- export paragraph
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Learn how to create and format paragraphs, portions, bullets, numbered lists, indents, HTML content, and paragraph images with Aspose.Slides for .NET."
---

## **Overview**

Aspose.Slides for .NET represents text as a hierarchy of text frames, paragraphs, and portions:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) represents the text container in a shape and provides access to its paragraph collection.
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) represents one paragraph in a text frame and provides access to its portions and paragraph-level formatting.
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) represents a text run within a paragraph. Each portion can have its own text and character-level formatting.

A paragraph can therefore contain text with different fonts, colors, sizes, and other formatting by using multiple portions.

## **Create and Format Paragraphs**

Create paragraphs in a shape's text frame and use portions to format individual text runs. This section shows how to combine multiple portions within each paragraph and apply different colors, font sizes, and styles.

### **Create Paragraphs with Multiple Portions**

The following C# example creates three paragraphs, each containing three text runs in its [IParagraph.Portions](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/portions/) collection. It reuses the default paragraph and its empty portion, then adds the remaining paragraphs and portions. Formatting is applied through [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/): the first portion in each paragraph is red, bold, and 15 points; the second is blue, italic, and 18 points. The third portion retains its default formatting:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
var textFrame = shape.TextFrame;

var firstParagraph = textFrame.Paragraphs[0];
firstParagraph.Portions.Add(new Portion());
firstParagraph.Portions.Add(new Portion());

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph();
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(thirdParagraph);

var paragraphCount = textFrame.Paragraphs.Count;
for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    var paragragaph = textFrame.Paragraphs[paragraphIndex];
    var portionCount = paragragaph.Portions.Count;
    for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        var portion = paragragaph.Portions[portionIndex];
        portion.Text = $"Portion {paragraphIndex + 1}.{portionIndex + 1}";

        if (portionIndex == 0)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
            portion.PortionFormat.FontBold = NullableBool.True;
            portion.PortionFormat.FontHeight = 15;
        }
        else if (portionIndex == 1)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontHeight = 18;
        }
    }
}

presentation.Save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
```

## **Create Bulleted and Numbered Lists**

Organize paragraph text into lists with symbols, numbers, or custom images. The examples in this section cover bullet formatting, multilevel lists, and custom starting numbers.

### **Create a Bulleted or Numbered List**

Bullets and numbering make related items easier to scan. In Aspose.Slides, list settings are defined through [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/).

This C# example adds a symbol bullet and a numbered item to the same text frame. [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) selects the bullet type, while [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) supplies the symbol and [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) selects the numbering style. Both items use black bullets with a height of 100 percent and a paragraph indent of 25 points:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var symbolParagraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
symbolParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
symbolParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
symbolParagraph.ParagraphFormat.Indent = 25;
symbolParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
symbolParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
symbolParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
symbolParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(symbolParagraph);

var numberedParagraph = new Paragraph { Text = "This is a numbered item" };
numberedParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
numberedParagraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
numberedParagraph.ParagraphFormat.Indent = 25;
numberedParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
numberedParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
numberedParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
numberedParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(numberedParagraph);

presentation.Save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
```

### **Use Picture Bullets**

Picture bullets let you use a custom image instead of a symbol or number.

This C# example adds an image to the presentation's image collection as an [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) and uses it as a paragraph bullet. It sets [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) to use a picture bullet and assigns the image through [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/). [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) is set to 100 percent to size the bullet relative to the paragraph text:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var bulletImage = Images.FromFile("bullets.png");
var presentationImage = presentation.Images.AddImage(bulletImage);

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = presentationImage;
paragraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(paragraph);

presentation.Save("picture_bullet.pptx", SaveFormat.Pptx);
presentation.Save("picture_bullet.ppt", SaveFormat.Ppt);
```

### **Create a Multilevel List**

Set [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) to place paragraphs at different levels of a list. The top level has a depth of `0`.

This C# example assigns [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) values from 0 to 3 to four paragraphs, creating a hierarchy within one text frame. Each paragraph uses a symbol bullet, with [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) alternating between a round bullet and a hyphen to distinguish adjacent levels:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Content" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
firstParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.Depth = 0;

var secondParagraph = new Paragraph { Text = "Second level" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
secondParagraph.ParagraphFormat.Bullet.Char = '-';
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.Depth = 1;

var thirdParagraph = new Paragraph { Text = "Third level" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
thirdParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.Depth = 2;

var fourthParagraph = new Paragraph { Text = "Fourth level" };
fourthParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
fourthParagraph.ParagraphFormat.Bullet.Char = '-';
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
fourthParagraph.ParagraphFormat.Depth = 3;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);
textFrame.Paragraphs.Add(fourthParagraph);

presentation.Save("multilevel_list.pptx", SaveFormat.Pptx);
```

### **Start Numbered List Items at Custom Values**

Use [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) to set the initial number displayed for a numbered paragraph.

This C# example sets [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) to use numbering for three paragraphs and assigns [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) values of 2, 3, and 7. The starting value is configured separately for each paragraph, allowing the displayed numbers to skip values:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Start at 2" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
firstParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
textFrame.Paragraphs.Add(firstParagraph);

var secondParagraph = new Paragraph { Text = "Start at 3" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
secondParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 3;
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph { Text = "Start at 7" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
thirdParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("custom_numbered_list.pptx", SaveFormat.Pptx);
```

## **Control Paragraph Layout and End Properties**

Adjust paragraph margins and indents to control the position of the first line and wrapped lines. You can also format the paragraph end mark separately from the visible text portions.

### **Set a First-Line Indent**

Use the [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) property to control the first-line indent of a paragraph. This property moves only the first line relative to the paragraph's left margin. A positive value shifts the first line to the right, while the remaining lines stay aligned to the paragraph body.

Use [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) when you need to move the whole paragraph. Use [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) when you need to move only the first line.

The following example gives three paragraphs the same [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) of 20 points and [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) values of 0, 20, and 40 points. The first lines start at progressively larger offsets, while wrapped lines retain the same left margin:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "No first-line indent. Wrapped lines start at the same position as the first line." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 20;
firstParagraph.ParagraphFormat.Indent = 0;

var secondParagraph = new Paragraph { Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 20;
secondParagraph.ParagraphFormat.Indent = 20;

var thirdParagraph = new Paragraph { Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see." };
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.MarginLeft = 20;
thirdParagraph.ParagraphFormat.Indent = 40;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
```

The result:

![The first-line indent of the paragraphs](first_line_indent.png)

### **Set a Hanging Indent**

A hanging indent is a paragraph layout in which the first line starts to the left of the remaining lines. In Aspose.Slides, you create this effect with the [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) property. Set `Indent` to a negative value to move the first line to the left relative to the paragraph body.

In practice, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) defines the left position of the paragraph body, and [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) defines the position of the first line relative to that margin. To create a hanging indent, set a positive `MarginLeft` value and a negative `Indent` value.

This formatting is useful for bibliographies, references, glossary entries, and other paragraphs where wrapped lines must align under the paragraph body rather than under the first character of the first line.

The following C# example pairs [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) values of 40 and 60 points with [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) values of -20 and -30 points. In each paragraph, the first line starts to the left of the wrapped lines; the second paragraph has a deeper hanging indent:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 40;
firstParagraph.ParagraphFormat.Indent = -20;

var secondParagraph = new Paragraph { Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 60;
secondParagraph.ParagraphFormat.Indent = -30;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
```

The result:

![The hanging indent of the paragraphs](hanging_indent.png)

### **Set End Paragraph Run Properties**

The [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) property controls the formatting of the paragraph end mark. The following example creates a [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) with [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) set to 48 points and [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) set to Times New Roman. It assigns this format to the second paragraph's end mark, leaving the visible text portions unchanged:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph();
firstParagraph.Portions.Add(new Portion("Sample text"));

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion("Sample text 2"));

var endParagraphFormat = new PortionFormat();
endParagraphFormat.FontHeight = 48;
endParagraphFormat.LatinFont = new FontData("Times New Roman");
secondParagraph.EndParagraphPortionFormat = endParagraphFormat;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("end_paragraph_format.pptx", SaveFormat.Pptx);
```

## **Count Rendered Lines**

For paragraph rules that affect automatic wrapping and punctuation at line endings, see [Control Line Breaking](/slides/net/text-formatting/#control-line-breaking) and [Control Hanging Punctuation](/slides/net/text-formatting/#control-hanging-punctuation).

Use [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) to count the lines occupied by a paragraph after text layout, including automatic wrapping. This is useful when checking text length and layout in presentation templates.

A paragraph is one item in [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/), and it can occupy several rendered lines. An explicit line break within a paragraph forces a new line without creating another paragraph. Automatic wrapping creates lines based on the available width without inserting explicit line breaks into the text. Counting paragraphs or line-break characters therefore does not give the rendered line count.

The following example creates a text shape, counts its lines, narrows the shape, and then replaces the text with a shorter string. The example enables [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) and disables [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) so that the shape width controls wrapping without automatically shrinking the text or resizing the shape. Each measurement uses [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/). Shape dimensions are in points. Finally, the example adds another paragraph and sums the line counts across the text frame.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;

var paragraph = textFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
paragraph.Text = "This text demonstrates how automatic wrapping changes the number of rendered lines.";
Console.WriteLine($"Original width: {paragraph.GetLinesCount()}");

shape.Width = 150;
Console.WriteLine($"Narrower shape: {paragraph.GetLinesCount()}");

paragraph.Text = "Short text.";
Console.WriteLine($"Shorter text: {paragraph.GetLinesCount()}");

var secondParagraph = new Paragraph { Text = "Another paragraph." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
textFrame.Paragraphs.Add(secondParagraph);

var totalLineCount = 0;
foreach (var currentParagraph in textFrame.Paragraphs)
{
    totalLineCount += currentParagraph.GetLinesCount();
}
Console.WriteLine($"Total lines in the text frame: {totalLineCount}");
```

With this text and these dimensions, narrowing the shape increases the line count, while replacing the text with the short string reduces it. Exact counts can vary with font availability and substitution, font size, margins, indentation, wrapping, and autofit settings. Use the fonts and layout settings intended for the target environment when checking a template.

The line count alone does not determine whether text overflows its container. The available height, line heights, paragraph and line spacing, and autofit behavior also matter; even a single line can exceed the available width when wrapping is disabled.

## **Import and Export Paragraph Content**

Use HTML to bring text into a presentation or export existing paragraphs for use outside it. This section also shows how to render individual paragraphs as images, including paragraphs in table cells.

### **Import HTML Text into Paragraphs**

Use [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) to convert HTML markup into paragraphs and portions in a text frame.

This C# example reads HTML from a file and passes the markup to [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/). It clears the text frame's default paragraph so that the frame contains only the imported content. The rectangular shape leaves a 10-point margin on each side of the slide:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shapeWidth = presentation.SlideSize.Size.Width - 20;
var shapeHeight = presentation.SlideSize.Size.Height - 20;
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
shape.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

using var reader = new StreamReader("file.html");
var html = reader.ReadToEnd();
shape.TextFrame.Paragraphs.AddFromHtml(html);

presentation.Save("html_text.pptx", SaveFormat.Pptx);
```

### **Export Paragraph Text to HTML**

Use [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) to export a selected range of paragraphs as HTML. When reusing presentation text on a website, you may want to preserve local emphasis without carrying over the presentation's font, size, or text box styles. Set [TextToHtmlConversionOptions.TextInheritanceLimit](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/textinheritancelimit/) to control how far the exporter follows formatting inheritance.

Download [the sample presentation](text-inheritance.pptx) and place it in the application's working directory. Its first slide contains one text shape with the text "Inherited text; explicit red 18pt". The input deliberately uses several formatting levels:

- The presentation's default text style supplies Calibri and a size of 28 pt.
- The text frame's first-level text style supplies blue text and italics.
- The paragraph explicitly sets bold text.
- The second portion, "explicit red 18pt", explicitly sets red text and a size of 18 pt.

The following complete example exports the same paragraphs three times. It passes [TextToHtmlConversionOptions](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/) to the export method and writes each result as a separate UTF-8 HTML file:

```csharp
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("text-inheritance.pptx");
var textShape = (IAutoShape)presentation.Slides[0].Shapes[0];

var paragraphs = textShape.TextFrame.Paragraphs;
var modes = new[] { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };

foreach (var mode in modes)
{
    var options = new TextToHtmlConversionOptions { TextInheritanceLimit = mode };

    var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);
    File.WriteAllText($"{mode}.html", html, Encoding.UTF8);
}
```

The generated HTML contains the following CSS for the first portion, "Inherited text; ". The table lists the relevant declarations; other generated properties are omitted for clarity.

| Output | Relevant CSS for the first portion | Appearance |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Blue, bold, italic text at 28 pt in Calibri, if that font is available. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Blue, bold, italic text; the surrounding page or browser supplies the font family and size. |
| `ParagraphOnly.html` | `font-weight:bold` | Bold text; the surrounding page or browser supplies the font family, size, color, and italic style. |

The second portion retains `color:#ff0000`, `font-size:18pt`, and `font-weight:bold` in all three outputs. It also retains italics with `All` and `TextBox`, but not with `ParagraphOnly`. Restricting inheritance therefore does not remove formatting explicitly assigned to a paragraph or portion.

Open the files in the same browser to compare them. In the two restricted modes, omitted CSS properties are resolved by the destination page's styles or browser defaults, so the resulting appearance depends on where the HTML is used.

### **Render a Paragraph as an Image**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) renders an individual paragraph directly and returns an [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). Save the result to a file or stream with [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). You do not need to render the containing shape or crop a bitmap manually.

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) can return `null` if the paragraph cannot be found in its parent collection, has no valid rendering bounds, or cannot be rendered. Check the result before saving it and dispose of the returned image after use.

#### **Render a Paragraph at the Default Scale**

The example uses a presentation with one slide whose first shape is a text box containing three paragraphs.

![The text box with three paragraphs](paragraph_to_image_input.png)

The following example selects the second paragraph at index 1 and calls [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) without scale parameters. It checks that the shape contains the required paragraph and that rendering returns an image before calling [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) to save it in PNG format. The `using` declaration disposes of the image after use.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && 
    textShape.TextFrame != null && 
    textShape.TextFrame.Paragraphs.Count > 1)
{
    var paragraph = textShape.TextFrame.Paragraphs[1];
    using var paragraphImage = paragraph.GetImage();

    if (paragraphImage != null)
    {
        paragraphImage.Save("paragraph.png", ImageFormat.Png);
    }
    else
    {
        Console.WriteLine("The paragraph could not be rendered.");
    }
}
else
{
    Console.WriteLine("The expected text shape or paragraph was not found.");
}
```

The result:

![The paragraph image](paragraph_to_image_output.png)

#### **Render a Paragraph in a Table Cell with Scaling**

Use the [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) overload that accepts `float scaleX` and `float scaleY` parameters to set the horizontal and vertical scale factors. The following example creates a table, renders the paragraph in its first cell at twice its default width and height, and saves the result as a PNG image.

```csharp
using System;
using Aspose.Slides;

var scaleX = 2f;
var scaleY = 2f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var table = slide.Shapes.AddTable(50, 50, new[] { 300d }, new[] { 80d });
var paragraph = table[0, 0].TextFrame.Paragraphs[0];
paragraph.Text = "Text in a table cell";

using var paragraphImage = paragraph.GetImage(scaleX, scaleY);
if (paragraphImage != null)
{
    paragraphImage.Save("table_paragraph.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The paragraph could not be rendered.");
}
```

A scale factor of `1` keeps that axis at its default pixel size. For example, `2` for both factors produces an image whose width and height are approximately twice the default dimensions, resulting in four times as many pixels. Larger factors generally produce sharper text for zooming or high-resolution output, but they also increase memory use and file size. Factors below `1` produce smaller images with less detail. Use equal factors to preserve the paragraph's aspect ratio; different horizontal and vertical factors stretch the output independently.

Rendering a whole shape with [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) remains useful when the output must include the shape's fill, border, or other visual context. For a paragraph-only image, use [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/).

## **FAQ**

**Can I completely disable line wrapping inside a text frame?**

Yes. Set [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) to disable wrapping so lines do not break at the text frame's edges.

**How can I get the exact on-slide bounds of a specific paragraph?**

Use [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) to retrieve the paragraph's bounding rectangle. [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) provides the bounds of an individual portion.

**Where is paragraph alignment (left, right, center, or justify) controlled?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) is a paragraph-level setting and applies to the whole paragraph regardless of individual portion formatting.

To vertically align portions of different font sizes within each line, see [Align Fonts Within a Line](/slides/net/text-formatting/#align-fonts-within-a-line).

**Can I set the proofing language for part of a paragraph?**

Yes. Set [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) for individual portions, so one paragraph can contain text in multiple languages.
