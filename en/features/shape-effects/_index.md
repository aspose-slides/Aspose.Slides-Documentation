---
title: Add shadows, glow and reflections
description: Apply shadows, glow, reflections and soft edges to shapes.
type: docs
url: /features/shape-effects/
weight: 700
feature_id: shape-effects
feature_group: shapes
translationKey: slides-feature-shape-effects
feature_catalogue_version: 3
feature_guides:
- /slides/net/shape-effect/
---

## **Overview**

Add visual effects to slide shapes and set their properties to suit the design. Effects can help separate an object from its background or give a diagram a particular appearance. Keep the effect settings with the shape when saving the presentation.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

This C# example puts a gray shadow behind a light blue rectangle. The 14-point distance and 45-degree direction offset the shadow down and right; the saved shape retains its fill and effect settings.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 240, 140);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.LightBlue;
shape.EffectFormat.EnableOuterShadowEffect();
var shadow = shape.EffectFormat.OuterShadowEffect;
shadow.ShadowColor.Color = Color.DimGray;
shadow.Distance = 14;
shadow.Direction = 45;
shadow.BlurRadius = 3;
presentation.Save("shape-effects.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Can I combine an effect with a shape fill and outline?**

Yes. Effects, fills and line formatting are separate parts of the shape's appearance and can be used together.

### **Can I apply several supported effects to one shape?**

Yes. Supported effects such as shadows, glow and soft edges have separate settings. Review combinations visually because effects can overlap and change the apparent edges or contrast.

### **How can I remove a shadow while preserving the shape?**

Disable the relevant shadow effect on the shape. This removes that effect while preserving the shape’s geometry, fill, outline and other supported formatting.

## **Guides**

- [Apply Shape Effects in Presentations in .NET](/slides/net/shape-effect/)

Related feature: [Set shape fills](/slides/features/shape-fills/).
