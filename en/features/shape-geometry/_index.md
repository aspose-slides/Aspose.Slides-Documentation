---
title: Edit shape geometry
description: Build and edit custom shape paths.
type: docs
url: /features/shape-geometry/
weight: 690
feature_id: shape-geometry
feature_group: shapes
translationKey: slides-feature-shape-geometry
feature_catalogue_version: 3
feature_guides:
- /slides/net/custom-shape/
---

## **Overview**

Define a shape using lines, curves and closed paths when a preset does not match the graphic you need. You can read the resulting geometry later and edit it again. Some preset shapes also expose adjustment values for changing their proportions.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

This C# example replaces a rectangle’s geometry with a closed triangle in a 240 by 160 point local coordinate space. Its fill follows the new contour, and the PPTX keeps an editable shape.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 60, 60, 240, 160);
var path = new GeometryPath();
path.MoveTo(120, 0);
path.LineTo(240, 160);
path.LineTo(0, 160);
path.CloseFigure();
shape.SetGeometryPath(path);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
presentation.Save("shape-geometry.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Will the result remain an editable shape?**

Yes. Custom geometry is stored as shape content in the presentation, rather than only as a rendered image.

### **How do custom path coordinates map to shape bounds?**

Path points use the shape’s local geometry space. The shape’s position, dimensions and rotation place and transform that contour on the slide; they are separate from absolute slide coordinates.

### **Can a custom shape contain more than one geometry path?**

Yes. Supply multiple geometry paths for a compound shape. Choose appropriate closed contours and fill modes, then inspect how overlapping paths are filled and outlined.

## **Guides**

- [Customize Presentation Shapes in .NET](/slides/net/custom-shape/)

Related feature: [Add preset shapes](/slides/features/autoshapes/).
