---
title: Format shape outlines
description: Set shape outlines, line styles and arrowheads.
type: docs
url: /features/shape-outlines/
weight: 720
feature_id: shape-outlines
feature_group: shapes
translationKey: slides-feature-shape-outlines
feature_catalogue_version: 3
feature_guides:
- /slides/net/shape-formatting/
---

## **Overview**

Control the color and width of a shape's outline and choose line details such as dashes, caps and joins. Lines and connectors can also have start and end arrowheads. These settings help make relationships and boundaries readable in diagrams.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

This C# example creates an unfilled rectangle with a four-point dark blue dashed outline. The PPTX keeps the line settings separately from the shape’s fill.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 60, 60, 300, 160);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.Width = 4;
shape.LineFormat.DashStyle = LineDashStyle.Dash;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
presentation.Save("shape-outlines.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Can the two ends use different arrowheads?**

Yes. Configure the beginning and ending arrowheads independently, including the available size settings.

### **How do line width units relate to slide coordinates?**

Line width and slide coordinates are measured in points. A wider line is centered on the contour and can extend beyond the shape’s nominal bounds, which matters near slide edges.

### **Can I hide an outline while keeping the shape fill?**

Yes. Set the line’s fill to no fill while retaining the shape’s own fill. Fill and line visibility are independent settings.

## **Guides**

- [Format PowerPoint Shapes in .NET](/slides/net/shape-formatting/)

Related feature: [Connect shapes](/slides/features/connectors/).
