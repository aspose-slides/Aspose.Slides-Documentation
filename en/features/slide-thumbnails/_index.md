---
title: Create slide thumbnails
description: Create small previews of any slide at a chosen size.
type: docs
url: /features/slide-thumbnails/
weight: 210
feature_id: slide-thumbnails
feature_group: operations
translationKey: slides-feature-slide-thumbnails
feature_catalogue_version: 3
feature_guides:
- /slides/net/convert-slide/
---

## **Overview**

Render a selected slide at thumbnail dimensions for a gallery, file browser or navigation panel. You can choose any slide in the presentation and set the output size, so previews do not have to be limited to the first slide.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It creates a 640 × 360 point slide with a red text rectangle and renders it at one-quarter scale. The resulting *thumbnail.png* is 160 × 90 pixels.

For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 240, 100);
rectangle.FillFormat.FillType = FillType.Solid;
rectangle.FillFormat.SolidFillColor.Color = Color.Red;
rectangle.TextFrame.Text = "Hello";
presentation.Save("source.pptx", SaveFormat.Pptx);
using var thumbnail = slide.GetImage(0.25f, 0.25f);
thumbnail.Save("thumbnail.png", ImageFormat.Png);
```

## **FAQ**

### **How is a thumbnail different from a slide image?**

It uses the same slide-rendering workflow at a smaller size. Choose larger dimensions when you need a full-size image.

### **Can I create thumbnails smaller than the original slide?**

Yes. Choose a smaller image size or scale factor. The example uses 0.25 for both axes, preserving the slide’s aspect ratio.

### **Can I render a thumbnail of one shape instead?**

Yes. A shape can be rendered separately from the whole slide. See the [slide image guide](/slides/net/convert-slide/) and choose the rendering bounds required by your gallery.

## **Guides**

- [Convert Presentation Slides to Images in .NET](/slides/net/convert-slide/)

Related feature: [Render slides as images](/slides/features/slide-images/).
