---
title: Set shape fills
description: Fill shapes with colors, gradients, patterns or pictures.
type: docs
url: /features/shape-fills/
weight: 710
feature_id: shape-fills
feature_group: shapes
translationKey: slides-feature-shape-fills
feature_catalogue_version: 3
feature_guides:
- /slides/net/shape-formatting/
---

## **Overview**

Choose the fill that suits a shape's role on the slide. Use a solid color, a multi-stop gradient, a pattern or an image, and adjust the relevant settings. Theme-linked colors can help the shape follow the presentation's overall design.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

This C# example fills a rectangle with a linear red-to-blue gradient. Stop positions run from 0 to 1, so the two endpoints define the full color transition.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 60, 60, 360, 180);
shape.FillFormat.FillType = FillType.Gradient;
var gradient = shape.FillFormat.GradientFormat;
gradient.GradientShape = GradientShape.Linear;
gradient.LinearGradientAngle = 0;
gradient.GradientStops.Clear();
gradient.GradientStops.Add(0, Color.Red);
gradient.GradientStops.Add(1, Color.Blue);
presentation.Save("shape-fills.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Can a shape follow a theme color instead of a fixed color?**

Yes. Use a theme color reference when you want the fill to respond to theme changes.

### **How do I make a shape fill transparent?**

Use a color with an alpha component for partial transparency, or choose no fill for a fully unfilled shape. Fill transparency is separate from whether the outline is visible.

### **How do gradient stops control the transition between fill colors?**

Each stop associates a color with a position along the gradient. Additional stops introduce intermediate colors or tighter transitions; the gradient direction and shape determine how those positions map onto the object.

## **Guides**

- [Format PowerPoint Shapes in .NET](/slides/net/shape-formatting/)

Related feature: [Change themes and color schemes](/slides/features/presentation-themes/).
