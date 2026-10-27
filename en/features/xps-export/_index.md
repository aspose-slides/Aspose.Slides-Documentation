---
title: Export presentations to XPS
description: Save presentations as XPS documents.
type: docs
url: /features/xps-export/
weight: 150
feature_id: xps-export
feature_group: formats
translationKey: slides-feature-xps-export
feature_catalogue_version: 3
feature_guides:
- /slides/net/convert-powerpoint-to-xps/
---

## **Overview**

Export slides to XPS for a fixed-page document workflow. The result can retain vector text and embedded font subsets, so the pages do not need to be stored as slide-sized bitmaps. Select XPS when the receiving application or print process uses that format.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It creates slides labeled *Alpha* and *Bravo*, saves their editable source, and exports *slides.xps*. The XPS contains two fixed pages for an XPS viewer or print workflow.

For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
for (var i = 0; i < 2; i++)
{
    var slide = i == 0 ? presentation.Slides[0] : presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
    var title = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 80);
    title.TextFrame.Text = i == 0 ? "Alpha" : "Bravo";
}
presentation.Save("source.pptx", SaveFormat.Pptx);
presentation.Save("slides.xps", SaveFormat.Xps);
```

## **FAQ**

### **Is the whole presentation saved in one document?**

Yes. The XPS package contains a fixed document with pages corresponding to the exported slides.

### **Can I create XPS without installing a printer driver?**

Yes. Export writes XPS directly from the presentation; it does not need a virtual printer driver.

### **How should I handle missing fonts during XPS export?**

Make required fonts available or choose appropriate substitution rules before exporting. Review the XPS in its target viewer because substituted fonts can change layout.

## **Guides**

- [Convert PowerPoint Presentations to XPS in .NET](/slides/net/convert-powerpoint-to-xps/)

Related feature: [Export presentations to PDF](/slides/features/pdf-export/).
