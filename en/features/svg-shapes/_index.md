---
title: Add SVG graphics
description: Insert SVG artwork as vector content or editable shapes.
type: docs
url: /features/svg-shapes/
weight: 600
feature_id: svg-shapes
feature_group: shapes
translationKey: slides-feature-svg-shapes
feature_catalogue_version: 3
feature_guides:
- /slides/net/image/
---

## **Overview**

Bring SVG graphics into a presentation through an image or shape workflow. Converting SVG artwork to a group of shapes makes its paths and text available for editing. Keeping it as an SVG picture is useful when you want to retain the source artwork in the file.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

This C# example embeds a self-contained SVG circle as a picture. The PPTX retains the SVG artwork; the image route does not turn the circle into an individually editable PowerPoint geometry path.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var svg = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\"><circle cx=\"50\" cy=\"50\" r=\"45\" fill=\"#008000\"/></svg>";
var image = presentation.Images.AddImage(new SvgImage(svg));
presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 60, 60, 180, 180, image);
presentation.Save("svg-shapes.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Which route should I choose for editing individual paths?**

Convert the SVG into a shape group. The picture route has different rendering behavior and does not expose the artwork as individual editable shapes.

### **Can I keep an SVG as vector content in a PPTX?**

Yes. Insert it as an SVG picture to keep the source vector content. Use conversion to a shape group when you need to edit supported individual paths instead.

### **What should I check when an SVG references external fonts or images?**

Make those resources available to the rendering environment or embed them where supported. A self-contained SVG is easier to reproduce than artwork that depends on external network resources or missing fonts.

## **Guides**

- [Optimize Image Management in Presentations in .NET](/slides/net/image/)

Related feature: [Edit shape geometry](/slides/features/shape-geometry/).
