---
title: Work with the handout master
description: Manage the master used for presentation handouts.
type: docs
url: /features/handout-master/
weight: 490
feature_id: handout-master
feature_group: slides
translationKey: slides-feature-handout-master
feature_catalogue_version: 3
feature_guides:
- /slides/net/convert-powerpoint-in-handout-mode/
---

## **Overview**

Work with the handout master to control shared handout content, including header, footer, date and slide-number placeholders. You can also add shapes to the master. Use this alongside handout export when preparing several slides for printing on one sheet.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

This C# example creates four labeled slides, adds a footer to the handout master and saves that master in PPTX. It also exports a four-slide PDF handout. The master footer and the export arrangement are separate settings; check the PDF result for your chosen export layout.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
for (var i = 0; i < 4; i++)
{
    var slide = i == 0 ? presentation.Slides[0] : presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 60, 60, 300, 100);
    label.TextFrame.Text = "Handout slide " + (i + 1);
}
presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();
var handout = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
handout.HeaderFooterManager.SetFooterVisibility(true);
handout.HeaderFooterManager.SetFooterText("Review copy");
presentation.Save("handout-master.pptx", SaveFormat.Pptx);
var options = new PdfOptions();
options.SlidesLayoutOptions = new HandoutLayoutingOptions { Handout = HandoutType.Handouts4Horizontal, PrintFrameSlide = true };
presentation.Save("handout-master.pdf", SaveFormat.Pdf, options);
```

## **FAQ**

### **Where do I choose the number of slides per sheet?**

Choose it in the handout export settings. The master and the page arrangement are related parts of the handout workflow.

### **How does a handout master differ from a notes master?**

A handout master controls shared elements on pages containing several slide thumbnails. A notes master controls the design of notes pages, which pair a slide with its speaker notes.

### **Where do handout headers and footers appear?**

They occupy the handout page’s header and footer placeholder areas, outside the individual slide thumbnails. Configure their text and visibility on the handout master, then inspect the chosen output.

## **Guides**

- [Convert PowerPoint Presentations in Handout Mode in .NET](/slides/net/convert-powerpoint-in-handout-mode/)

Related feature: [Export presentation handouts](/slides/features/export-handouts/).
