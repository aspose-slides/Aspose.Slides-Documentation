---
title: Read OpenDocument presentations
description: Read ODP presentations and work with their slide content.
type: docs
url: /features/read-odp/
weight: 30
feature_id: read-odp
feature_group: formats
translationKey: slides-feature-read-odp
feature_catalogue_version: 3
feature_guides:
- /slides/net/convert-odp-to-pptx/
---

## **Overview**

Open an OpenDocument presentation to read or edit its slides, text, tables and notes. The presentation model gives you the same kind of access used for PowerPoint files, so an application can handle both formats within its document-processing workflow.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It generates a two-slide *input.odp*, opens it directly, and prints the text of the shape named *Title* on each slide. The two source labels are *Alpha* and *Bravo*.

For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var source = new Presentation())
{
    for (var i = 0; i < 2; i++)
    {
        var slide = i == 0 ? source.Slides[0] : source.Slides.AddEmptySlide(source.Slides[0].LayoutSlide);
        var title = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 80);
        title.Name = "Title";
        title.TextFrame.Text = i == 0 ? "Alpha" : "Bravo";
    }
    source.Save("input.odp", SaveFormat.Odp);
}
using var presentation = new Presentation("input.odp");
foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape.Name == "Title" && shape is IAutoShape title)
            Console.WriteLine(title.TextFrame.Text);
    }
}
```

## **FAQ**

### **Can I turn an ODP presentation into PPTX?**

Yes. Open the ODP file, then save it in PPTX format. The conversion guide explains the available options.

### **Can I edit an ODP before converting it?**

Yes. Load the ODP, edit the required slide objects, then save a PPTX copy. Keep the ODP source when you need to compare the conversion result.

### **What should I check when an ODP uses unavailable fonts?**

Make the required fonts available or configure substitution, then review wrapping, alignment and rendered slides. A successful load does not guarantee identical appearance when fonts differ.

## **Guides**

- [Convert ODP to PPTX in .NET](/slides/net/convert-odp-to-pptx/)

Related feature: [Save presentations as ODP](/slides/features/write-odp/).
