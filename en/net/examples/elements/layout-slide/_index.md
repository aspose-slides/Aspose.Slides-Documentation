---
title: Layout Slide
type: docs
weight: 20
url: /net/examples/elements/layout-slide/
keywords:
- layout slide
- add layout slide
- access layout slide
- remove layout slide
- unused layout slide
- clone layout slide
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Master layout slides in Aspose.Slides for .NET: choose, apply, and customize slide layouts, placeholders, and masters with C# examples for PPT, PPTX, and ODP presentations."
---

This article demonstrates how to work with **Layout Slides** in Aspose.Slides for .NET. A layout slide defines the design and formatting inherited by normal slides. You can add, access, clone, and remove layout slides, as well as clean up unused ones to reduce presentation size.

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

## **Add a Layout Slide**

You can create a custom layout slide to define reusable formatting. For example, you might add a text box that appears on all slides using this layout.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();

var masterSlide = presentation.Masters[0];

// Create a layout slide with a blank layout type and a custom name.
var layoutSlide = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Blank, "Main layout");

// Add a text box to the layout slide.
var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
layoutTextBox.TextFrame.Text = "Base";

// Add two slides using this layout; both will inherit the text from the layout.
presentation.Slides.AddEmptySlide(layoutSlide);
presentation.Slides.AddEmptySlide(layoutSlide);

presentation.Save("layout-slide-01.pptx", SaveFormat.Pptx);
```

> 💡 **Note 1:** Layout slides act as templates for individual slides. You can define common elements once and reuse them across many slides.

> 💡 **Note 2:** When you add shapes or text to a layout slide, all slides based on that layout will display this shared content automatically.
> The screenshot below shows two slides, each inheriting a text box from the same layout slide.

![Slides Inheriting Layout Content](layout-slide-result.png)

## **Access a Layout Slide**

Layout slides can be accessed by index or by layout type (e.g., `Blank`, `Title`, `SectionHeader`, etc.).

```csharp
using System;
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();

// Access a layout slide by index.
var firstLayoutSlide = presentation.LayoutSlides[0];

// Access a layout slide by type.
var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
Console.WriteLine(blankLayoutSlide.Name);

presentation.Save("layout-slide-02.pptx", SaveFormat.Pptx);
```

## **Remove a Layout Slide**

You can remove a specific layout slide if it's no longer needed.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();

// Get a layout slide by type and remove it.
var blankLayoutSlide = presentation.LayoutSlides.Add(presentation.Masters[0], SlideLayoutType.Blank, "Unused");
presentation.LayoutSlides.Remove(blankLayoutSlide);

presentation.Save("layout-slide-03.pptx", SaveFormat.Pptx);
```

## **Remove Unused Layout Slides**

To reduce the presentation size, you may want to remove layout slides that are not used by any normal slides.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();

// Automatically removes all layout slides not referenced by any slide.
presentation.LayoutSlides.RemoveUnused();

presentation.Save("layout-slide-04.pptx", SaveFormat.Pptx);
```

## **Clone a Layout Slide**

You can duplicate a layout slide using the `AddClone` method.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();

// Get an existing layout slide by type.
var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Clone the layout slide to the end of the layout slide collection.
var clonedLayoutSlide = presentation.LayoutSlides.AddClone(blankLayoutSlide);
clonedLayoutSlide.Name = "Clone";

presentation.Save("layout-slide-05.pptx", SaveFormat.Pptx);
```

> ✅ **Summary:** Layout slides are powerful tools for managing consistent formatting across slides. Aspose.Slides allows full control over creating, managing, and optimizing layout slides.
