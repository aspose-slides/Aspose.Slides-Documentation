---
title: Choose PDF compliance settings
description: Choose PDF, PDF/A or PDF/UA export settings.
type: docs
url: /features/pdf-compliance/
weight: 1170
feature_id: pdf-compliance
feature_group: rendering
translationKey: slides-feature-pdf-compliance
feature_catalogue_version: 3
feature_guides:
- /slides/net/convert-powerpoint-to-pdf/
---

## **Overview**

Select a PDF compliance mode when an export needs particular document settings. The library applies the mode during PDF creation, including related font and metadata choices. This is separate from choosing which slides or images the output contains.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Export a generated text slide using PDF/A-1b. The selected mode controls export settings; validate the result with an independent PDF/A validator for your archival workflow.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 140);
shape.AddTextFrame("Sample slide");
shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("Arial");
var options = new PdfOptions { Compliance = PdfCompliance.PdfA1b };
presentation.Save("output.pdf", SaveFormat.Pdf, options);
presentation.Save("source.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Does selecting a mode guarantee every accessibility or archival requirement?**

No. The presentation's content and the exporter’s scope still matter. Treat a selected mode as an export setting rather than independent certification.

### **How do I select a PDF/A compliance level?**

Choose the required PDF/A value in the PDF export compliance options. Match the profile to the receiving system and validate the output.

### **What font restrictions should I consider for PDF/A output?**

The output needs suitable embeddable fonts. Check embedding permissions and confirm that replacement fonts preserve the required glyphs.

## **Guides**

- [Convert PPT and PPTX to PDF in .NET [Advanced Features Included]](/slides/net/convert-powerpoint-to-pdf/)

Related feature: [Create tagged PDF files](/slides/features/tagged-pdf/).
