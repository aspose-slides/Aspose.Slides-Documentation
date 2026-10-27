---
title: Set rendering resolution
description: Choose output image dimensions and resolution settings.
type: docs
url: /features/rendering-resolution/
weight: 1220
feature_id: rendering-resolution
feature_group: rendering
translationKey: slides-feature-rendering-resolution
feature_catalogue_version: 3
feature_guides:
- /slides/net/convert-slide/
- /slides/net/convert-powerpoint-to-tiff/
---

## **Overview**

Set rendered slide dimensions directly or use scale factors for image output. TIFF export also provides explicit horizontal and vertical DPI settings, while PDF settings can control image downsampling. Choose the option that matches how the result will be displayed or printed.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Create a 720 by 540 point slide and render at twice its horizontal and vertical scale. The PNG is 1440 by 1080 pixels; the scale changes pixels, not a PNG DPI tag.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 140);
shape.AddTextFrame("Sample slide");
presentation.SlideSize.SetSize(720, 540, SlideSizeScaleType.DoNotScale);
using var image = presentation.Slides[0].GetImage(2f, 2f);
image.Save("slide.png", Aspose.Slides.ImageFormat.Png);
presentation.Save("source.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Does a larger PNG automatically carry a higher DPI tag?**

Pixel dimensions and DPI metadata are separate. Use the requested pixel size for PNG/JPEG output and the explicit DPI options for TIFF.

### **How do slide points translate to image pixels?**

For scale-based slide rendering, multiply slide dimensions in points by the requested scale to obtain the image dimensions in pixels.

### **Can I choose horizontal and vertical scale independently?**

Yes. Horizontal and vertical scale are separate inputs. Different values can stretch the output, so use equal values to preserve proportions.

## **Guides**

- [Convert Presentation Slides to Images in .NET](/slides/net/convert-slide/)
- [Convert PowerPoint Presentations to TIFF in .NET](/slides/net/convert-powerpoint-to-tiff/)

Related feature: [Render slides as images](/slides/features/slide-images/).
