---
title: Change themes and color schemes
description: Change presentation colors and fonts through themes.
type: docs
url: /features/presentation-themes/
weight: 470
feature_id: presentation-themes
feature_group: slides
translationKey: slides-feature-presentation-themes
feature_catalogue_version: 3
feature_guides:
- /slides/net/presentation-theme/
---

## **Overview**

Use themes to manage colors and font choices shared across a presentation. Shapes and text that refer to theme settings can follow those changes, which is useful for applying a consistent design to generated reports or adapting an existing deck.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

This C# example assigns a theme color to a rectangle and changes that color in the theme. The saved rectangle resolves to orange because its fill follows the theme rather than a fixed RGB value.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 240, 140);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
presentation.MasterTheme.ColorScheme.Accent4.Color = Color.Orange;
presentation.Save("presentation-themes.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Will a theme change recolor every shape?**

Theme-linked colors follow the theme. Explicitly assigned colors remain separate choices, so distinguish theme references from fixed formatting.

### **What is the difference between a scheme color and a fixed RGB color?**

A scheme color refers to a logical theme entry and can change when that entry changes. A fixed RGB color records a concrete color independently of the theme.

### **Can I inspect the theme inherited by a slide layout?**

Yes. Inspect the theme associated with the layout and its master, and read effective values when overrides may apply. A presentation with several masters can contain several theme contexts.

## **Guides**

- [Manage Presentation Themes in .NET](/slides/net/presentation-theme/)

Related feature: [Set shape fills](/slides/features/shape-fills/).
