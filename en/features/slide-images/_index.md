---
title: Render slides as images
description: Save rendered slides as PNG, JPEG and other image formats.
type: docs
url: /features/slide-images/
weight: 90
feature_id: slide-images
feature_group: formats
translationKey: slides-feature-slide-images
feature_catalogue_version: 3
feature_guides:
- /slides/net/convert-powerpoint-to-png/
---

## **Overview**

Render a slide as an image for a website, report or preview. Choose the slide and output size, then save the rendered result in an image format. You can also export a presentation to a multi-page TIFF when a single image document is more convenient.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It creates a 640 × 360 point slide with a red rectangle, saves its editable source, and renders a 640 × 360 pixel PNG at scale 1. Increase the scale factors for a larger raster image.

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
using var image = slide.GetImage(1f, 1f);
image.Save("slide.png", ImageFormat.Png);
```

## **FAQ**

### **Can I create a small preview of a particular slide?**

Yes. Render the selected slide at the dimensions you need. See slide thumbnails for the preview workflow.

### **Can I export every slide to a separate image?**

Yes. Loop through the slide collection and render each slide, using a different output filename for every image.

### **How do I control the dimensions of a PNG export?**

Set the requested image size or use horizontal and vertical scale factors when rendering. Keep their ratio consistent to preserve the slide’s proportions.

## **Guides**

- [Convert PowerPoint Slides to PNG in .NET](/slides/net/convert-powerpoint-to-png/)

Related feature: [Create slide thumbnails](/slides/features/slide-thumbnails/).

## Runnable .NET examples

- [Render Slides as Images](/slides/net/examples/conversion-rendering/images/)
