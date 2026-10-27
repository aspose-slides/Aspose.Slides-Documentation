---
title: Change shape stacking order
description: Control which shapes appear in front of or behind others.
type: docs
url: /features/shape-order/
weight: 680
feature_id: shape-order
feature_group: shapes
translationKey: slides-feature-shape-order
feature_catalogue_version: 3
feature_guides:
- /slides/net/shape-manipulations/
---

## **Overview**

Reorder shapes to change how they overlap on a slide. Move a background element behind content or bring an annotation in front of a picture. You can also change the order of shapes within a group while preserving the group's structure.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

This C# example creates overlapping red and blue rectangles, then brings the red rectangle to the front. Reordering changes their overlap while leaving their bounds unchanged.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;
var red = shapes.AddAutoShape(ShapeType.Rectangle, 60, 60, 220, 150);
red.Name = "Red";
red.FillFormat.FillType = FillType.Solid;
red.FillFormat.SolidFillColor.Color = Color.Red;
var blue = shapes.AddAutoShape(ShapeType.Rectangle, 140, 110, 220, 150);
blue.Name = "Blue";
blue.FillFormat.FillType = FillType.Solid;
blue.FillFormat.SolidFillColor.Color = Color.Blue;
shapes.Reorder(shapes.Count - 1, red);
presentation.Save("shape-order.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Does changing stacking order move the shape?**

It changes the drawing order. The shape's position and size can stay the same.

### **How can I bring a shape to the front?**

Move it to the end of its containing shape collection. Shapes later in the collection are drawn in front of earlier shapes in that same collection.

### **How does stacking order work for shapes inside a group?**

Reorder a child within the group’s shape collection to change its overlap with siblings. Move the group itself in the slide collection to change its position relative to shapes outside the group.

## **Guides**

- [Manage Presentation Shapes in .NET](/slides/net/shape-manipulations/)

Related feature: [Group shapes](/slides/features/shape-groups/).
