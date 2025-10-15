---
title: Text Box
type: docs
weight: 40
url: /net/examples/elements/textbox/
keywords:
- code example
- textbox
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Work with text boxes in Aspose.Slides for .NET: add, format, align, wrap, autofit, and style text using C# for PPT, PPTX, and ODP presentations."
---

In Aspose.Slides, a **text box** is represented by an `AutoShape`. Nearly any shape can contain text, but a typical text box has no fill or border and displays only text.

This guide explains how to add, access, and remove text boxes programmatically.

## **Add a Text Box**

A text box is simply an `AutoShape` with no fill or border and some formatted text. Here's how to create one:

```csharp
public static void AddTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Create a rectangle shape (defaults to filled with border and no text).
    var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // Remove fill and border to make it look like a typical text box.
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // Set text formatting.
    var paragraph = textBox.TextFrame.Paragraphs[0];
    var textFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
    textFormat.FillFormat.FillType = FillType.Solid;
    textFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // Assign the actual text content.
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **Note:** Any `AutoShape` that contains a non-empty `TextFrame` can function as a text box.

## **Access Text Boxes by Content**

To find all text boxes containing a specific keyword (e.g. "Slide"), iterate through the shapes and check their text:

```csharp
public static void AccessTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        // Only AutoShapes can contain editable text.
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // Do something with the matching text box.
            }
        }
    }
}
```

## **Remove Text Boxes by Content**

This example finds and deletes all text boxes on the first slide that contain a specific keyword:

```csharp
public static void RemoveTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shapesToRemove = slide.Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => slide.Shapes.Remove(shape));
}
```

> 💡 **Tip:** Always create a copy of the shape collection before modifying it during iteration to avoid collection modification errors.
