---
title: Hyperlink
type: docs
weight: 130
url: /net/examples/elements/hyperlink/
keywords:
- hyperlink
- add hyperlink
- access hyperlink
- remove hyperlink
- update hyperlink
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Add and manage hyperlinks in Aspose.Slides for .NET: link text, shapes, and images, set targets and actions for PPT, PPTX, and ODP with C# examples."
---

This article demonstrates adding, accessing, removing, and updating hyperlinks on shapes using **Aspose.Slides for .NET**.

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

## **Add a Hyperlink**

Create a rectangle shape with a hyperlink pointing to an external website.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
shape.TextFrame.Text = "Aspose";

var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

presentation.Save("hyperlink-01.pptx", SaveFormat.Pptx);
```

## **Access a Hyperlink**

Read hyperlink information from a shape's text portion.

```csharp
using System;
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
shape.TextFrame.Text = "Aspose";

var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
Console.WriteLine(hyperlink.ExternalUrl);

presentation.Save("hyperlink-02.pptx", SaveFormat.Pptx);
```

## **Remove a Hyperlink**

Clear the hyperlink from a shape's text.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
shape.TextFrame.Text = "Aspose";

var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

textPortion.PortionFormat.HyperlinkClick = null;

presentation.Save("hyperlink-03.pptx", SaveFormat.Pptx);
```

## **Update a Hyperlink**

Change the target of an existing hyperlink. Use `HyperlinkManager` to modify text that already contains a hyperlink, which mimics how PowerPoint updates hyperlinks safely.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
shape.TextFrame.Text = "Aspose";

var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

// Changing a hyperlink inside existing text should be done via
// HyperlinkManager rather than setting the property directly.
// This mimics how PowerPoint safely updates hyperlinks.
textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");

presentation.Save("hyperlink-04.pptx", SaveFormat.Pptx);
```
