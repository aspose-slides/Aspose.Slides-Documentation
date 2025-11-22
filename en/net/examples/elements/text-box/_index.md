---
title: Text Box
type: docs
weight: 40
url: /net/examples/elements/text-box/
keywords:
- text box example
- add text box
- access text box
- remove text box
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Create and format text boxes in C# with Aspose.Slides: set fonts, alignment, wrapping, autofit, and links to polish slides for PowerPoint and OpenDocument."
---

In Aspose.Slides, a **text box** is represented by an `AutoShape`. Nearly any shape can contain text, but a typical text box has no fill or border and displays only text.

This guide explains how to add, access, and remove text boxes programmatically.

## Add a Text Box

A text box is simply an `AutoShape` with no fill or border and some formatted text. Here's how to create one:

```csharp
public static void Add_TextBox()
{
    using var pres = new Presentation();

    // Create a rectangle shape (defaults to filled with border and no text)
    var textBox = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // Remove fill and border to make it look like a typical text box
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // Set text formatting
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // Assign the actual text content
    textBox.TextFrame.Text = "Some text...";
}
````

> 💡 **Note:** Any `AutoShape` that contains a non-empty `TextFrame` can function as a text box.

## Access Text Boxes by Content

To find all text boxes containing a specific keyword (e.g. "Slide"), iterate through the shapes and check their text:

```csharp
public static void Access_TextBox()
{
    using var pres = new Presentation();

    foreach (var shape in pres.Slides[0].Shapes)
    {
        // Only AutoShapes can contain editable text
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // Do something with the matching text box
            }
        }
    }
}
```

## Remove Text Boxes by Content

This example finds and deletes all text boxes on the first slide that contain a specific keyword:

```csharp
public static void Remove_TextBox()
{
    using var pres = new Presentation();

    var shapesToRemove = pres.Slides[0].Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => pres.Slides[0].Shapes.Remove(shape));
}
```

> 💡 **Tip:** Always create a copy of the shape collection before modifying it during iteration to avoid collection modification errors.