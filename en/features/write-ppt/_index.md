---
title: Save presentations as legacy PPT
description: Write presentations in the legacy PowerPoint PPT format.
type: docs
url: /features/write-ppt/
weight: 60
feature_id: write-ppt
feature_group: formats
translationKey: slides-feature-write-ppt
feature_catalogue_version: 3
feature_guides:
- /slides/net/convert-pptx-to-ppt/
---

## **Overview**

Save a presentation as a binary PPT file for applications and workflows that still use the older PowerPoint format. You can start with a new presentation or load an existing one, make changes, and choose PPT as the output format.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It creates *source.pptx* with a simple text rectangle, opens it, and saves a separate binary *legacy.ppt*. The original PPTX remains available for comparison.

For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (var source = new Presentation())
{
    var title = source.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 80);
    title.TextFrame.Text = "Hello";
    source.Save("source.pptx", SaveFormat.Pptx);
}
using var presentation = new Presentation("source.pptx");
presentation.Save("legacy.ppt", SaveFormat.Ppt);
```

## **FAQ**

### **Is changing the filename extension enough?**

No. Choose the PPT save format so the library writes the correct file structure, rather than only renaming a PPTX file.

### **What should I review when saving modern content to PPT?**

Review features that differ between the modern and legacy formats, especially complex graphics, effects and media. Open and render the saved PPT to check the content your workflow depends on.

### **Can I keep the original PPTX while producing a PPT copy?**

Yes. Save the PPT output to a different path, as above. Keep the PPTX as the editable source for workflows that need its newer format capabilities.

## **Guides**

- [Convert PPTX to PPT in .NET](/slides/net/convert-pptx-to-ppt/)

Related feature: [Read legacy PowerPoint presentations](/slides/features/read-ppt/).
