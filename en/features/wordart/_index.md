---
title: Create WordArt
description: Style editable text with warps, fills, outlines and effects.
type: docs
url: /features/wordart/
weight: 670
feature_id: wordart
feature_group: shapes
translationKey: slides-feature-wordart
feature_catalogue_version: 3
feature_guides:
- /slides/net/wordart/
---

## **Overview**

Create WordArt-style text by combining text transforms with fill, outline and effect settings. Use curved or wave-like transforms when a title needs a decorative treatment. The text remains part of the presentation's text model rather than becoming a static picture.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

This C# example applies an upward arch to editable text in a text box. It uses Arial at 36 points; install an appropriate font in your rendering environment if you adapt the sample.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 60, 60, 500, 180);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Text = "Creative title";
shape.TextFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LatinFont = new FontData("Arial");
portion.PortionFormat.FontHeight = 36;
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
presentation.Save("wordart.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Can the words still be edited after applying the effect?**

Yes. The styling applies to editable text, so you can update the words without rebuilding the artwork as an image.

### **How does WordArt transformation differ from rotating a text box?**

Rotation turns the text box as a whole. A WordArt transform changes the text’s outline or baseline into a decorative form such as an arch or wave.

### **Can I combine WordArt with ordinary font formatting?**

Yes. Set font, size, fill and other supported text formatting alongside the transform. Check readability and text fit after changing the words or the shape’s dimensions.

## **Guides**

- [Create and Apply WordArt Effects in .NET](/slides/net/wordart/)

Related feature: [Format text within slides](/slides/features/text-formatting/).
