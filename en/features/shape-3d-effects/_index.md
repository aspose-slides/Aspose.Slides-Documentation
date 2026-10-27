---
title: Apply 3D effects to shapes
description: Give shapes depth, bevels, lighting and camera settings.
type: docs
url: /features/shape-3d-effects/
weight: 640
feature_id: shape-3d-effects
feature_group: shapes
translationKey: slides-feature-shape-3d-effects
feature_catalogue_version: 3
feature_guides:
- /slides/net/3d-presentation/
---

## **Overview**

Apply 3D formatting to shapes and text for effects such as extrusion and bevels. Camera, lighting and material settings control how that formatting appears. The settings stay with the presentation and can also affect rendered slide output.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

This C# example applies a bevel, extrusion, camera rotation and lighting to a blue rectangle. The PPTX keeps editable 3D formatting; a rendered slide shows its two-dimensional appearance.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 240, 120);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.RoyalBlue;
shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
shape.ThreeDFormat.BevelTop.Width = 6;
shape.ThreeDFormat.BevelTop.Height = 6;
shape.ThreeDFormat.ExtrusionHeight = 30;
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 0);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
presentation.Save("shape-3d-effects.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Is a 3D effect the same as embedding a 3D model?**

No. These settings style slide shapes and text. They do not describe a separate imported 3D model workflow.

### **What is the difference between extrusion and bevel settings?**

Extrusion adds depth behind the shape’s face. Bevel settings shape its edges and highlights. Their visual effect also depends on the camera, lighting and material.

### **How can camera and lighting presets change the appearance of a 3D effect?**

The camera changes the viewing angle, while the light rig changes highlights and shadows. A flat-looking result may need a different viewing angle or lighting even when extrusion is already set.

## **Guides**

- [Create 3D Effects in Presentations Using .NET](/slides/net/3d-presentation/)

Related feature: [Add shadows, glow and reflections](/slides/features/shape-effects/).
