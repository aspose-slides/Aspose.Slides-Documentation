---
title: Export presentation handouts
description: Arrange several slides on each exported handout page.
type: docs
url: /features/export-handouts/
weight: 1200
feature_id: export-handouts
feature_group: rendering
translationKey: slides-feature-export-handouts
feature_catalogue_version: 3
feature_guides:
- /slides/net/convert-powerpoint-in-handout-mode/
---

## **Overview**

Create handout output with multiple slides on a sheet. Choose a grid arrangement and decide whether to show slide numbers or frames. This gives readers a compact document for printing or review without changing the original slides in the presentation.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Create six numbered slides and export a horizontal six-slide handout. All six thumbnails should appear on a single PDF page in slide order.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 140);
shape.AddTextFrame("Sample slide");
shape.TextFrame.Text = "Slide 1";
for (var number = 2; number <= 6; number++)
{
    var slide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 140);
    label.AddTextFrame("Slide " + number);
}
var layout = new HandoutLayoutingOptions { Handout = HandoutType.Handouts6Horizontal };
var options = new PdfOptions { SlidesLayoutOptions = layout, ShowHiddenSlides = true };
presentation.Save("output.pdf", SaveFormat.Pdf, options);
presentation.Save("source.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Does handout export rearrange the source slides?**

No. It changes the output page layout. The presentation keeps its original slides and their order.

### **Which handout layouts are available?**

The handout layout enumeration provides arrangements with different slide counts and horizontal or vertical sequencing. Choose the one suitable for the paper layout.

### **Can I include hidden slides in handout output?**

Yes. Enable hidden-slide output in the export options when those slides should appear in the handout.

## **Guides**

- [Convert PowerPoint Presentations in Handout Mode in .NET](/slides/net/convert-powerpoint-in-handout-mode/)

Related feature: [Work with the handout master](/slides/features/handout-master/).
