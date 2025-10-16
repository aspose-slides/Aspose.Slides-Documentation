---
title: Layout Slide
type: docs
weight: 20
url: /net/examples/elements/layoutslide/
keywords:
- code example
- layout slide
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Master layout slides in Aspose.Slides for .NET: choose, apply, and customize slide layouts, placeholders, and masters with C# examples for PPT, PPTX, and ODP presentations."
---

This article demonstrates how to work with **Layout Slides** in Aspose.Slides for .NET. A layout slide defines the design and formatting inherited by normal slides. You can add, access, clone, and remove layout slides, as well as clean up unused ones to reduce presentation size.

## **Add a Layout Slide**

You can create a custom layout slide to define reusable formatting. For example, you might add a text box that appears on all slides using this layout.

```csharp
static void AddLayoutSlide()
{
    using var presentation = new Presentation();
    
    var masterSlide = presentation.Masters[0];

    // Create a layout slide with a blank layout type and a custom name.
    var layoutSlide = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Blank, "Main layout");

    // Add a text box to the layout slide.
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // Add two slides using this layout; both will inherit the text from the layout.
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
}
```

> 💡 **Note 1:** Layout slides act as templates for individual slides. You can define common elements once and reuse them across many slides.

> 💡 **Note 2:** When you add shapes or text to a layout slide, all slides based on that layout will display this shared content automatically.
> The screenshot below shows two slides, each inheriting a text box from the same layout slide.

![Slides Inheriting Layout Content](layout-slide-result.png)

## **Access a Layout Slide**

Layout slides can be accessed by index or by layout type (e.g., `Blank`, `Title`, `SectionHeader`, etc.).

```csharp
static void AccessLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Access a layout slide by index.
    var firstLayoutSlide = presentation.LayoutSlides[0];
    
    // Access a layout slide by type.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **Remove a Layout Slide**

You can remove a specific layout slide if it's no longer needed.

```csharp
static void RemoveLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Get a layout slide by type and remove it.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Custom);
    presentation.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **Remove Unused Layout Slides**

To reduce the presentation size, you may want to remove layout slides that are not used by any normal slides.

```csharp
static void RemoveUnusedLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Automatically removes all layout slides not referenced by any slide.
    presentation.LayoutSlides.RemoveUnused();
}
```

## **Clone a Layout Slide**

You can duplicate a layout slide using the `AddClone` method.

```csharp
static void CloneLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Get an existing layout slide by type.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // Clone the layout slide to the end of the layout slide collection.
    var clonedLayoutSlide = presentation.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **Summary:** Layout slides are powerful tools for managing consistent formatting across slides. Aspose.Slides allows full control over creating, managing, and optimizing layout slides.
