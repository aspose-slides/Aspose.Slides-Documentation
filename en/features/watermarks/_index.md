---
title: Add watermarks with text and images
description: Place text or image watermarks on slides or masters.
type: docs
url: /features/watermarks/
weight: 240
feature_id: watermarks
feature_group: operations
translationKey: slides-feature-watermarks
feature_catalogue_version: 3
feature_guides:
- /slides/net/watermark/
---

## **Overview**

Build a watermark from ordinary text or picture shapes. Put it on individual slides or a master, then set its position, rotation and transparency. You can use shape locks to discourage editing of the watermark in the saved presentation.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It adds a named *DRAFT* text shape with a 315-degree rotation and a half-transparent red text fill. The caller owns the shape and can later locate it by name. The result is *watermarked.pptx* and a PNG preview.

For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var title = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 80);
title.TextFrame.Text = "Hello";
var watermark = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 160, 180, 400, 100);
watermark.Name = "AppWatermark";
watermark.Rotation = 315;
watermark.FillFormat.FillType = FillType.NoFill;
watermark.LineFormat.FillFormat.FillType = FillType.NoFill;
watermark.TextFrame.Text = "DRAFT";
var format = watermark.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
format.FontHeight = 54;
format.FillFormat.FillType = FillType.Solid;
format.FillFormat.SolidFillColor.Color = Color.FromArgb(128, 255, 0, 0);
presentation.Save("watermarked.pptx", SaveFormat.Pptx);
using var image = slide.GetImage(1f, 1f);
image.Save("watermarked.png", ImageFormat.Png);
```

## **FAQ**

### **Is there a separate watermark object?**

No. A watermark is slide or master content that your application adds and manages with the shape APIs.

### **Should I put a repeated watermark on a master?**

A master is useful when the same watermark should appear on slides using that master. Check slide background and master-shape visibility settings, and use individual slide shapes when only selected slides need it.

### **How can I find and remove a watermark my application added?**

Assign an application-specific shape name when adding it. Find that shape on the slide or master and remove it from its shape collection; avoid deleting unrelated text or pictures.

## **Guides**

- [Add Watermarks to Presentations in .NET](/slides/net/watermark/)

Related feature: [Lock shapes against editing](/slides/features/shape-locks/).
