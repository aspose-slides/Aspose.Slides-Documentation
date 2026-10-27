---
title: Add preset shapes
description: Add built-in shape types such as arrows, callouts and flowchart symbols.
type: docs
url: /features/autoshapes/
weight: 550
feature_id: autoshapes
feature_group: shapes
translationKey: slides-feature-autoshapes
feature_catalogue_version: 3
feature_guides:
- /slides/net/shape-types/
---

## **Overview**

Create preset shapes and choose their position, size, fill and outline. Presets cover many common diagram elements, so you can build slides without drawing every geometry yourself. The resulting shapes stay editable in the saved presentation.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

This C# example creates an editable rectangle at 60,60 points and adds a short label. Its 240 by 100 point dimensions control the shape’s bounding box independently of its text.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var rectangle = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 60, 60, 240, 100);
rectangle.Name = "Report label";
rectangle.TextFrame.Text = "Quarterly report";
presentation.Save("autoshapes.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Can I change the appearance after adding a shape?**

Yes. Apply fill, line and effect settings separately from the shape type, and adjust its geometry where the preset supports it.

### **Which units are used for shape coordinates?**

Positions and dimensions use points, with 72 points per inch. The origin is the slide’s top-left corner; increasing horizontal or vertical coordinates moves right or down.

### **Can I change an AutoShape type after creating it?**

Yes. Change the preset shape type on an AutoShape and review the geometry and text fit afterward. Some presets have additional adjustment values that change their proportions.

## **Guides**

- [Shape Types in Aspose.Slides for .NET](/slides/net/shape-types/)

Related feature: [Set shape fills](/slides/features/shape-fills/).
