---
title: Compress presentations
description: Reduce presentation size with image compression and save settings.
type: docs
url: /features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/image/
---

## **Overview**

Compress pictures, remove cropped image areas when they are no longer needed, and choose presentation compression settings before saving. This is useful for decks with large photographs or repeated media. The amount saved depends on the content and settings you choose.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It visibly generates a 1600 × 900 pixel gradient PNG, inserts it into a small picture frame, and saves *before.pptx*. It then compresses that picture to a target resolution of 96 DPI and saves *compressed.pptx*. Compare both file sizes and previews: savings depend on the input picture and displayed size.

For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var bitmap = new Bitmap(1600, 900))
{
    for (var y = 0; y < bitmap.Height; y++)
        for (var x = 0; x < bitmap.Width; x++)
            bitmap.SetPixel(x, y, Color.FromArgb(x % 256, y % 256, (x + y) % 256));
    bitmap.Save("large.png", System.Drawing.Imaging.ImageFormat.Png);
}
using var presentation = new Presentation();
var title = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 500, 60);
title.TextFrame.Text = "Photo";
var bytes = File.ReadAllBytes("large.png");
var image = presentation.Images.AddImage(bytes);
var picture = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 40, 120, 240, 135, image);
presentation.Save("before.pptx", SaveFormat.Pptx);
var compressed = picture.PictureFormat.CompressImage(true, 96f);
Console.WriteLine($"Picture compressed: {compressed}");
presentation.Save("compressed.pptx", SaveFormat.Pptx);
using var preview = presentation.Slides[0].GetImage(1f, 1f);
preview.Save("compressed.png", ImageFormat.Png);
```

## **FAQ**

### **Is this a single whole-file optimization switch?**

Image compression is applied to the relevant pictures. Combine it with save settings and unused-content cleanup for the workflow your presentation needs.

### **Does image compression change editable text or charts?**

Picture compression targets picture data, not editable text or chart data. Review the images because resizing or recompression can reduce their detail.

### **How should I choose a resolution for presentation images?**

Choose a target based on the displayed picture size and intended screen or print use. Keep more resolution for large displays, printing and detailed diagrams, and compare the rendered output before discarding the original.

## **Guides**

- [Optimize Image Management in Presentations in .NET](/slides/net/image/)

Related feature: [Remove unused masters, layouts and media](/slides/features/remove-unused-content/).

## Runnable .NET examples

- [Reduce Presentation Size](/slides/net/examples/optimization-batch/compression/)
