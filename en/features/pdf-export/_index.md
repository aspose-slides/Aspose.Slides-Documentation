---
title: Export presentations to PDF
description: Save presentations as PDF files for sharing or printing.
type: docs
url: /features/pdf-export/
weight: 80
feature_id: pdf-export
feature_group: formats
translationKey: slides-feature-pdf-export
feature_catalogue_version: 3
feature_guides:
- /slides/net/convert-powerpoint-to-pdf/
---

## **Overview**

Export a presentation to PDF when readers need a page-based copy of the slides. The export options let you choose slides, include notes, set image quality and select PDF compliance settings. Keep the presentation file alongside the PDF for later editing.

## **Usage example**

This C# example uses Aspose.Slides for .NET and needs no input file. It creates two labeled slides, saves the editable source as *quarters.pptx*, and exports both slides to *quarters.pdf*. The PDF contains two pages; the presentation remains available for later edits.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
var firstText = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 80);
firstText.TextFrame.Text = "Quarter one";
var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);
var secondText = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 80);
secondText.TextFrame.Text = "Quarter two";
presentation.Save("quarters.pptx", SaveFormat.Pptx);
presentation.Save("quarters.pdf", SaveFormat.Pdf);
```

## **FAQ**

### **Does PDF export turn every slide into one bitmap?**

No. Text and vector content can remain text and vectors in the PDF. Images are handled through the PDF export settings.

### **Can I export only selected slides to PDF?**

Yes. Supply the one-based slide numbers to the selected-slides export overload described in the [PDF guide](/slides/net/convert-powerpoint-to-pdf/). The example above exports all visible slides.

### **How do missing fonts affect the exported PDF?**

The renderer substitutes an available font when a required font is missing, which can change text metrics, wrapping, and appearance. Make the intended fonts available or [configure substitution rules](/slides/net/font-substitution/) and review the resulting PDF.

## **Guides**

- [Convert PPT and PPTX to PDF in .NET [Advanced Features Included]](/slides/net/convert-powerpoint-to-pdf/)

Related feature: [Choose PDF compliance settings](/slides/features/pdf-compliance/).
