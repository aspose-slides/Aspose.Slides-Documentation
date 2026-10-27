---
title: Hide and show slides
description: Mark slides as hidden while keeping them in the presentation.
type: docs
url: /features/hidden-slides/
weight: 520
feature_id: hidden-slides
feature_group: slides
translationKey: slides-feature-hidden-slides
feature_catalogue_version: 3
feature_guides:
- /slides/net/convert-powerpoint-to-pdf/
---

## **Overview**

Set or read the hidden flag on a slide to keep optional material in a deck without including it in the usual presentation flow. The slide and its content remain accessible to your application, so you can show it again when needed.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

This C# example keeps two slides in the PPTX and marks the second as hidden. It exports one PDF with only the visible slide and another with both slides by choosing the hidden-slide option explicitly.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 300, 80).TextFrame.Text = "Visible slide";
var optional = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
optional.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 300, 80).TextFrame.Text = "Optional slide";
optional.Hidden = true;
presentation.Save("hidden-slides.pptx", SaveFormat.Pptx);
presentation.Save("visible-only.pdf", SaveFormat.Pdf, new PdfOptions { ShowHiddenSlides = false });
presentation.Save("including-hidden.pdf", SaveFormat.Pdf, new PdfOptions { ShowHiddenSlides = true });
```

## **FAQ**

### **Can hidden slides be included in PDF output?**

Yes. PDF export has an option to include hidden slides. Choose it when the output should contain the full deck.

### **Does hiding a slide remove it from the presentation?**

No. The slide remains in the slide collection with its content and relationships. Hiding changes its normal slide-show participation, while export behavior depends on the output settings.

### **Can I restore a hidden slide to the slide-show sequence?**

Yes. Clear the slide’s hidden flag. The slide can then appear in the normal slide-show sequence without being recreated.

## **Guides**

- [Convert PPT and PPTX to PDF in .NET [Advanced Features Included]](/slides/net/convert-powerpoint-to-pdf/)

Related feature: [Export presentations to PDF](/slides/features/pdf-export/).
