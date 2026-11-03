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

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks. The copied code runs in evaluation mode. For licensed output, apply your license before creating a presentation, as described in the [licensing guide](/slides/net/licensing/).

## **Download and run**

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

## **Add a Text Box**

A text box is simply an `AutoShape` with no fill or border and some formatted text. Here's how to create one:

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;
using System.Drawing;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Create a rectangle shape (defaults to filled with border and no text).
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

// Remove fill and border to make it look like a typical text box.
textBox.FillFormat.FillType = FillType.NoFill;
textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

// Set text formatting.
var paragraph = textBox.TextFrame.Paragraphs[0];
var textFill = paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat;
textFill.FillType = FillType.Solid;
textFill.SolidFillColor.Color = Color.Black;

// Assign the actual text content.
textBox.TextFrame.Text = "Text";

presentation.Save("text-box-01.pptx", SaveFormat.Pptx);
```

> 💡 **Note:** Any `AutoShape` that contains a non-empty `TextFrame` can function as a text box.

## **Access Text Boxes by Content**

Find text-bearing auto shapes whose text contains Slide, using a case-sensitive ordinal comparison. The fixture includes matching text, unrelated text, and a connector.

```csharp
using System.Linq;
using System;
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
// Seed matching and unrelated text, plus a shape with no text frame.
var matchingText = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
matchingText.Name = "DemoText";
matchingText.TextFrame.Text = "Slide";
var unrelatedText = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 120, 150, 50);
unrelatedText.TextFrame.Text = "Other";
slide.Shapes.AddConnector(ShapeType.Line, 50, 190, 150, 0);

const string keyword = "Slide";
foreach (var textShape in slide.Shapes.OfType<IAutoShape>())
{
    if (textShape.TextFrame?.Text.Contains(keyword, StringComparison.Ordinal) == true)
    {
        Console.WriteLine(textShape.TextFrame.Text);
    }
}

presentation.Save("text-box-02.pptx", SaveFormat.Pptx);
```

## **Remove Text Boxes by Content**

Delete all text-bearing auto shapes on the first slide whose text contains Slide, using a case-sensitive ordinal comparison. Unrelated text and the connector remain.

```csharp
using System;
using Aspose.Slides.Export;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
// Seed matching and unrelated text, plus a shape with no text frame.
var matchingText = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
matchingText.Name = "DemoText";
matchingText.TextFrame.Text = "Slide";
var unrelatedText = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 120, 150, 50);
unrelatedText.TextFrame.Text = "Other";
slide.Shapes.AddConnector(ShapeType.Line, 50, 190, 150, 0);

const string keyword = "Slide";
var matchingShapes = slide.Shapes.OfType<IAutoShape>()
    .Where(textShape => textShape.TextFrame?.Text.Contains(keyword, StringComparison.Ordinal) == true)
    .ToList();

// Snapshot the matches before changing the slide's shape collection.
foreach (var textShape in matchingShapes)
{
    slide.Shapes.Remove(textShape);
}

presentation.Save("text-box-03.pptx", SaveFormat.Pptx);
```

> 💡 **Tip:** Snapshot the matching shapes before removing them, so iteration does not modify the collection being enumerated.
