---
title: Manage Text Boxes in Presentations in .NET
linktitle: Manage Text Box
type: docs
weight: 20
url: /net/manage-textbox/
keywords:
- text box
- text frame
- add text
- update text
- create text box
- check text box
- add text column
- add hyperlink
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Create, identify, format, and update text boxes in PowerPoint and OpenDocument presentations using Aspose.Slides for .NET."
---

## **Introduction**

In Aspose.Slides for .NET, slide text is stored in text frames that belong to shapes. The [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) interface represents the most common text-bearing shape and exposes its text through the [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) property.

{{% alert color="info" title="Note" %}}

Every auto shape implements [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), but not every shape is an auto shape or supports a text frame. When processing an existing presentation, check that a shape implements `IAutoShape` before accessing its text.

{{% /alert %}}

## **Create a Text Box on a Slide**

To create a text box, add an auto shape to a slide, add text to its text frame, and save the presentation. The following example creates a rectangular text box:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

The coordinates and dimensions passed to [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) are measured in points. [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) initializes the text frame with the supplied text.

## **Check for a Text Box Shape**

Use the [AutoShape.IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) property to determine whether an auto shape is treated as a text box. This is useful when a presentation contains both text-bearing and purely graphical auto shapes.

![A text box and a shape](istextbox.png)

The following example inspects every auto shape in a presentation:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
textBox.AddTextFrame("Text box");
slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

foreach (var currentSlide in presentation.Slides)
{
    foreach (var shape in currentSlide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "The shape is a text box." : "The shape is not a text box.");
        }
    }
}
```

A newly added auto shape is not considered a text box until it contains non-empty text. You can supply that text through [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) or [ITextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/itextframe/text/). Adding or assigning an empty string leaves `IsTextBox` set to `false`:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
shape1.AddTextFrame("Shape 1");
Console.WriteLine(shape1.IsTextBox);

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
shape2.TextFrame.Text = "Shape 2";
Console.WriteLine(shape2.IsTextBox);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
shape3.AddTextFrame("");
Console.WriteLine(shape3.IsTextBox);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
shape4.TextFrame.Text = "";
Console.WriteLine(shape4.IsTextBox);
```

The first two calls print `True`; the last two print `False`.

## **Find the Shape That Owns a Text Frame**

Generic text-processing code may receive an [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) without knowing which presentation object contains it. Use the read-only [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) property to navigate back to its owning [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/).

For a text frame owned by an auto shape or another text-bearing shape, `ParentShape` contains the owner and [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) is `null`. Check the returned value before accessing it. To identify both shape and table-cell owners, including shapes associated with SmartArt nodes, see [Search and Replace Text](/slides/net/search-and-replace-text/).

## **Add Columns to a Text Box**

The [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/) property divides the text frame into columns, while [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/) sets the gap between columns in points. Both settings belong to [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/) and can be changed through the text frame of an existing text box. Text reflows between columns inside the same shape; it does not continue into another shape.

The following example creates a three-column text box with 10 points between columns, saves the presentation, and reads the stored settings back from the output file:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
textBox.AddTextFrame("This text is distributed automatically across all columns in the text box.");

var textFrameFormat = textBox.TextFrame.TextFrameFormat;
textFrameFormat.ColumnCount = 3;
textFrameFormat.ColumnSpacing = 10;

presentation.Save("TextBoxColumns.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("TextBoxColumns.pptx");
var savedTextBox = (IAutoShape)savedPresentation.Slides[0].Shapes[0];
var savedFormat = savedTextBox.TextFrame.TextFrameFormat;
Console.WriteLine($"Columns: {savedFormat.ColumnCount}; spacing: {savedFormat.ColumnSpacing} points");
```

## **Extract Text from Individual Columns**

Use [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/net/aspose.slides/textframe/splittextbycolumns/) to retrieve the text assigned to each visual column in an existing text frame. The method returns one string for each column, in column-based reading order. A single-column text frame produces an array with one element, and an empty column is represented by an empty string. The strings contain plain text only; portion-level formatting is not preserved.

This is useful when you need to:

- Extract text while preserving its column-based reading order.
- Index or compare the content of multi-column slides.
- Export each column to a separate file, database field, or other destination.
- Inspect how text is redistributed after changing [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/), the font, or the text-frame size.

The method reports the text distributed within the current [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/); it does not automatically flow text between separate shapes or text boxes. Column distribution can depend on available fonts and other text-layout settings, so make sure that the required fonts are available when consistent results are important.

The following example loads a presentation, finds the first multi-column auto shape with a text frame, reads its configured column count, and writes the text from every column to a separate file. Shapes that do not provide a text frame are skipped.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("MultiColumnText.pptx");

IAutoShape? textBox = null;
foreach (var shape in presentation.Slides[0].Shapes)
{
    if (shape is IAutoShape autoShape && autoShape.TextFrame is not null)
    {
        var columnCount = autoShape.TextFrame.TextFrameFormat.ColumnCount;
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox is null)
{
    Console.WriteLine("No multi-column text frame was found.");
}
else
{
    var textFrame = textBox.TextFrame;
    var configuredColumnCount = textFrame.TextFrameFormat.ColumnCount;
    var columnTexts = textFrame.SplitTextByColumns();

    Console.WriteLine($"Configured columns: {configuredColumnCount}");

    for (var columnIndex = 0; columnIndex < columnTexts.Length; columnIndex++)
    {
        var columnNumber = columnIndex + 1;
        var columnText = columnTexts[columnIndex];
        Console.WriteLine($"Column {columnNumber}: {columnText}");
        File.WriteAllText($"Column-{columnNumber}.txt", columnText);
    }
}
```

## **Update Text**

To update text throughout a presentation, iterate through the slides and shapes, select auto shapes, and then edit their text portions. Working at the portion level lets you change both text and character formatting.

The following example replaces every occurrence of `years` with `months` in auto-shape text and makes each affected portion bold:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Text.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape)
        {
            continue;
        }

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                portion.Text = portion.Text.Replace("years", "months");
                portion.PortionFormat.FontBold = NullableBool.True;
            }
        }
    }
}

presentation.Save("TextChanged.pptx", SaveFormat.Pptx);
```

This traversal updates text only in auto shapes. Text stored in tables, charts, SmartArt, or grouped shapes requires traversal of those objects' own collections.

## **Add a Text Box with a Hyperlink**

A hyperlink can be assigned to a specific text portion, so only that text acts as the clickable link. Use [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) to associate the portion with an external URL.

The following example creates linked text and saves it to a presentation:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
textBox.AddTextFrame("Aspose.Slides");

var textPortion = textBox.TextFrame.Paragraphs[0].Portions[0];
textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com/");

presentation.Save("Hyperlink.pptx", SaveFormat.Pptx);
```

## **FAQ**

**What is the difference between a text box and a text placeholder on a master or layout slide?**

A [placeholder](/slides/net/manage-placeholder/) can inherit its position and formatting from a [master slide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) or [layout slide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/). A regular text box is an independent shape on the slide where it was created and does not acquire placeholder behavior when the layout changes.

**How can I replace text without changing text in charts, tables, or SmartArt?**

Limit the traversal to shapes that implement [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), as shown in the Update Text example. Charts, tables, and SmartArt store text in their own object models, so they are not modified by that loop.
