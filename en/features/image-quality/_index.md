---
title: Adjust image quality and compression
description: Balance image quality and output size during export.
type: docs
url: /features/image-quality/
weight: 1230
feature_id: image-quality
feature_group: rendering
translationKey: slides-feature-image-quality
feature_catalogue_version: 3
feature_guides:
- /slides/net/convert-powerpoint-to-pdf/
---

## **Overview**

Adjust image compression and quality settings for the output format you are producing. JPEG quality, PDF image resolution and TIFF compression are examples of choices that affect file size and appearance. Select settings for the intended screen, print or storage workflow.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Generate a colorful raster image and export it twice at the same resolution with different JPEG quality settings. Compare the two PDFs at the intended viewing size; quality can affect encoded size and visible artifacts.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.IO;
using System.Drawing;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 140);
shape.AddTextFrame("Sample slide");
using var bitmap = new Bitmap(640, 360);
for (var y = 0; y < bitmap.Height; y++)
    for (var x = 0; x < bitmap.Width; x++)
        bitmap.SetPixel(x, y, Color.FromArgb((x * 17 + y * 3) % 256, (x * 7 + y * 11) % 256, (x * 13 + y * 19) % 256));
using var stream = new MemoryStream();
bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
var picture = presentation.Images.AddImage(stream.ToArray());
presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 40, 220, 480, 270, picture);
var low = new PdfOptions { JpegQuality = 20, SufficientResolution = 96 };
var high = new PdfOptions { JpegQuality = 90, SufficientResolution = 96 };
presentation.Save("quality-low.pdf", SaveFormat.Pdf, low);
presentation.Save("quality-high.pdf", SaveFormat.Pdf, high);
presentation.Save("source.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Does JPEG quality change every image in a PDF?**

No. Image handling depends on its format and the export settings; a lossless image can remain lossless instead of being recompressed as JPEG.

### **How can I compare JPEG quality settings at a fixed export resolution?**

Export the same deck at the same resolution with two quality values. Compare the resulting images and file sizes rather than changing several settings at once.

### **How does image quality differ from rasterization resolution?**

JPEG quality controls lossy encoding. Resolution controls the number of pixels retained or generated; increasing quality cannot restore missing pixels.

## **Guides**

- [Convert PPT and PPTX to PDF in .NET [Advanced Features Included]](/slides/net/convert-powerpoint-to-pdf/)

Related feature: [Compress presentations](/slides/features/compress-presentations/).
