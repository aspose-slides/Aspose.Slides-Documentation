---
title: Open and edit presentations
description: Open a presentation, change its content and save the result.
type: docs
url: /features/edit-presentations/
weight: 170
feature_id: edit-presentations
feature_group: operations
translationKey: slides-feature-edit-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/open-presentation/
---

## **Overview**

Edit an existing presentation through its document model. Change text, remove pictures, update charts or rearrange slides without rebuilding the entire file. This is useful for reports that reuse a presentation and replace only the content that changes.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It generates *input.pptx* with a shape named *ReportTitle*, finds that shape by name, changes *Draft* to *Final*, and saves *edited.pptx*. The input file is retained.

For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (var source = new Presentation())
{
    var title = source.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 80);
    title.Name = "ReportTitle";
    title.TextFrame.Text = "Draft";
    source.Save("input.pptx", SaveFormat.Pptx);
}
using var presentation = new Presentation("input.pptx");
foreach (var shape in presentation.Slides[0].Shapes)
{
    if (shape.Name == "ReportTitle" && shape is IAutoShape title)
        title.TextFrame.Text = "Final";
}
presentation.Save("edited.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Can I keep the original file?**

Yes. Save the edited presentation to another path or output stream instead of replacing the source.

### **How can I identify the shape I want to edit?**

Use an application-assigned shape name or another stable identifier, then check its type before editing. Avoid relying only on its position in the shape collection when templates may change.

### **How do I update text inside a table cell?**

Locate the table, choose its column and row, and edit that cell’s text frame. Cell access is separate from editing a standalone text shape.

## **Guides**

- [Open Presentations in .NET](/slides/net/open-presentation/)

Related feature: [Save presentations as PPTX](/slides/features/write-pptx/).
