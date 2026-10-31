---
title: Text Box
type: docs
weight: 40
url: /net/examples/elements/text-box/
keywords:
- text box
- add text box
- access text box
- remove text box
- code example
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

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

Each printed `CaseNN.cs` file is compiled verbatim with the included `Program.cs` and bootstrap. Checks run before saving and after reopening the result.

## **Add a Text Box**

A text box is simply an `AutoShape` with no fill or border and some formatted text. Here's how to create one:

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

internal static partial class Program
{
    static void Case01()
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
        textBox.TextFrame.Text = "Text";

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IAutoShape>().Any(s => s.TextFrame.Text == "Text" && s.FillFormat.FillType == FillType.NoFill), "AddTextBox: semantic check 1 failed.");
        });
        Context.Pass("elements/text-box/block-001", "AddTextBox", "save-reopen-structure");
    }
}
```

> 💡 **Note:** Any `AutoShape` that contains a non-empty `TextFrame` can function as a text box.

## **Access Text Boxes by Content**

To find all text boxes containing a specific keyword (e.g. "Slide"), iterate through the shapes and check their text:

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];
        var marker = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        marker.Name = "DemoText";
        marker.TextFrame.Text = "Slide";

        foreach (var shape in slide.Shapes)
        {
            // Only AutoShapes can contain editable text.
            if (shape is AutoShape autoShape && autoShape.Name == "DemoText")
            {
                if (autoShape.TextFrame.Text.Contains("Slide"))
                {
                    Context.Require(autoShape.TextFrame.Text == "Slide", "Accessed the known text box.");
                }
            }
        }

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IAutoShape>().Count(s => s.Name == "DemoText" && s.TextFrame.Text == "Slide") == 1, "AccessTextBox: semantic check 1 failed.");
        });
        Context.Pass("elements/text-box/block-002", "AccessTextBox", "save-reopen-structure");
    }
}
```

## **Remove Text Boxes by Content**

This example finds and deletes all text boxes on the first slide that contain a specific keyword:

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];
        var marker = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        marker.Name = "DemoText";
        marker.TextFrame.Text = "Slide";

        var shapesToRemove = slide.Shapes
            .Where(s => s is AutoShape autoShape && autoShape.Name == "DemoText" && autoShape.TextFrame.Text.Contains("Slide"))
            .ToList();

        shapesToRemove.ForEach(shape => slide.Shapes.Remove(shape));

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.Slides[0].Shapes.Any(s => s.Name == "DemoText"), "RemoveTextBox: semantic check 1 failed.");
        });
        Context.Pass("elements/text-box/block-003", "RemoveTextBox", "save-reopen-structure");
    }
}
```

> 💡 **Tip:** Always create a copy of the shape collection before modifying it during iteration to avoid collection modification errors.
