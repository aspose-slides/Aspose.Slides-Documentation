---
title: Create tagged PDF files
description: Write PDF structure for supported tagged export modes.
type: docs
url: /features/tagged-pdf/
weight: 1180
feature_id: tagged-pdf
feature_group: rendering
translationKey: slides-feature-tagged-pdf
feature_catalogue_version: 3
feature_guides:
- /slides/net/presentation-accessibility/
---

## **Overview**

Use an appropriate tagged PDF mode to carry document structure into the export. The PDF can contain a hierarchy for slides, text and lists, along with alternative text supplied for pictures. Prepare the presentation's content so that meaningful descriptions are available to the exporter.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Export a generated slide in a tagged PDF mode. The rectangle has a supplied alternative description; inspect structure and reading order with an accessibility checker before distribution.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 140);
shape.AddTextFrame("Sample slide");
shape.AlternativeText = "Demonstration rectangle containing sample slide text";
var options = new PdfOptions { Compliance = PdfCompliance.PdfUa };
presentation.Save("output.pdf", SaveFormat.Pdf, options);
presentation.Save("source.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Does a picture automatically receive a useful text description?**

No. Supply alternative text in the presentation. Tagging alone does not provide the description a reader needs for an image.

### **Does enabling tags alone guarantee full accessibility compliance?**

No. Tags provide document structure, but meaningful descriptions, reading order and the exporter scope still need review.

### **Why should I inspect reading order as well as the exported visual appearance?**

The visual arrangement does not establish the order used by assistive technology. Check both the structure and the rendered page.

## **Guides**

- [Manage Presentation Accessibility in .NET](/slides/net/presentation-accessibility/)

Related feature: [Choose PDF compliance settings](/slides/features/pdf-compliance/).
