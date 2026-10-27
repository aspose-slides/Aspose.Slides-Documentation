---
title: Track export progress
description: Receive progress updates during PDF and GIF export.
type: docs
url: /features/export-progress/
weight: 300
feature_id: export-progress
feature_group: operations
translationKey: slides-feature-export-progress
feature_catalogue_version: 3
feature_guides:
- /slides/net/convert-powerpoint-to-pdf/
---

## **Overview**

Attach a progress callback when exporting a presentation so your application can report activity to the user. PDF and GIF export provide progress updates through the save options. Use the output format's progress scale when displaying a percentage or progress bar.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It creates three labeled slides, attaches a PDF progress reporter, and saves *progress.pdf*. The callback prints the values supplied by PDF export on its 0–100 scale. Keep callback work short so it does not slow the export.

For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
for (var i = 0; i < 3; i++)
{
    var slide = i == 0 ? presentation.Slides[0] : presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
    var title = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 80);
    title.TextFrame.Text = $"Page {i + 1}";
}
presentation.Save("source.pptx", SaveFormat.Pptx);
var reporter = new PdfProgress();
var options = new PdfOptions { ProgressCallback = reporter };
presentation.Save("progress.pdf", SaveFormat.Pdf, options);

class PdfProgress : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        Console.WriteLine($"PDF progress: {progressValue:F1}");
    }
}
```

## **FAQ**

### **Is the progress scale identical for PDF and GIF?**

No. PDF reports on a 0–100 scale, while GIF uses a fractional scale. Do not assume every save format invokes the callback.

### **Do all output formats report progress?**

No. Progress callbacks are format-specific. PDF and GIF support them, with different scales; do not assume the same callback behavior for every save format.

### **How can a progress callback update the UI without blocking export?**

Forward or post lightweight progress updates to the UI’s synchronization context. Avoid lengthy work in the callback and let the UI display the latest value without blocking the export worker.

## **Guides**

- [Convert PPT and PPTX to PDF in .NET [Advanced Features Included]](/slides/net/convert-powerpoint-to-pdf/)

Related feature: [Interrupt presentation processing](/slides/features/cancel-processing/).
