---
title: Export slides to SVG
description: Export individual slides as scalable SVG graphics.
type: docs
url: /features/svg-export/
weight: 100
feature_id: svg-export
feature_group: formats
translationKey: slides-feature-svg-export
feature_catalogue_version: 3
feature_guides:
- /slides/net/render-a-slide-as-an-svg-image/
---

## **Overview**

Write a slide as SVG when you need a graphic that can scale without turning all of its content into a bitmap. Text can remain SVG text, making the result useful for browser display and other workflows that accept vector graphics.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It creates a slide containing a text rectangle and writes that slide to *slide.svg*. It also keeps *source.pptx* for editing; the SVG is a scalable viewing output.

For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var title = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 80);
title.Name = "Title";
title.TextFrame.Text = "Hello";
presentation.Save("source.pptx", SaveFormat.Pptx);
using var stream = File.Create("slide.svg");
presentation.Slides[0].WriteAsSvg(stream);
```

## **FAQ**

### **Are the fonts embedded in the SVG?**

The SVG names the fonts it uses. Make those fonts available where the SVG is displayed so its text keeps the intended appearance.

### **Will an SVG contain embedded raster images?**

It can. Raster pictures in the source may remain embedded raster content inside the SVG. Vector export does not turn photographs into vector shapes.

### **Can I save one SVG for each slide?**

Yes. Iterate through the slide collection and write each slide to its own SVG file. Give each output a unique filename.

## **Guides**

- [Render Presentation Slides as SVG Images in .NET](/slides/net/render-a-slide-as-an-svg-image/)

Related feature: [Load fonts from a folder](/slides/features/custom-fonts/).

## Runnable .NET examples

- [Export Slides to SVG](/slides/net/examples/conversion-rendering/svg/)
