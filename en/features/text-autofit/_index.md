---
title: Fit text in a shape
description: Shrink text to fit a shape or let the shape grow with the text.
type: docs
url: /features/text-autofit/
weight: 810
feature_id: text-autofit
feature_group: text
translationKey: slides-feature-text-autofit
feature_catalogue_version: 3
feature_guides:
- /slides/net/manage-autofit-settings/
---

## **Overview**

Choose how a text frame handles content that exceeds its size. You can shrink the rendered text to fit, grow the shape to accommodate the text, or leave fitting disabled. The choice helps generated slides handle content of varying length.

## **Usage example**

This C# example keeps a 260-by-90-point shape fixed and enables shrinking text on overflow. The stored font size remains 28 points; fitting is resolved during layout. Compare the PNG preview with your intended slide design before distributing `text-autofit.pptx`.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 260, 90);
shape.AddTextFrame("A longer report summary that needs to fit within a fixed-size text box without enlarging the shape.");
shape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Normal;
shape.TextFrame.TextFrameFormat.WrapText = NullableBool.True;
shape.TextFrame.TextFrameFormat.MarginLeft = 8;
shape.TextFrame.TextFrameFormat.MarginRight = 8;
shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 28;
presentation.Save("text-autofit.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("text-autofit.png", Aspose.Slides.ImageFormat.Png);
```

## **FAQ**

### **Does shrinking text change its stored font size?**

The fitting calculation can affect the effective rendered size while the original portion formatting remains unchanged.

### **How does shrinking text differ from resizing the shape?**

Shrinking retains the shape’s size and reduces rendered text or spacing as needed. Shape autofit instead allows the text container to grow with its content.

### **How do internal text-frame margins affect the available fitting area?**

Margins reduce the usable area inside the shape. Larger margins leave less room for text and can cause additional shrinking or wrapping.

## **Guides**

- [Enhance Your Presentations with AutoFit in .NET](/slides/net/manage-autofit-settings/)

Related feature: [Work with text frames](/slides/features/text-frames/).
