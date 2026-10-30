---
title: Split presentations by cloning slides
description: Create smaller presentations by copying selected slides into new files.
type: docs
url: /features/split-presentations/
weight: 200
feature_id: split-presentations
feature_group: operations
translationKey: slides-feature-split-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/clone-slides/
---

## **Overview**

Split a deck by creating a new presentation for each selected slide, range or section and cloning the required slides into it. Your application chooses how to group and name the output files. This uses the slide-cloning API rather than a separate splitter service.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It creates *Alpha*, *Bravo* and *Charlie* slides. The caller chooses the zero-based start index 1 and count 2, clones that range, and names the result *part-2-3.pptx*. The source keeps all three slides.

For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation();
var labels = new[] { "Alpha", "Bravo", "Charlie" };
for (var i = 0; i < labels.Length; i++)
{
    var slide = i == 0 ? source.Slides[0] : source.Slides.AddEmptySlide(source.Slides[0].LayoutSlide);
    var title = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 80);
    title.TextFrame.Text = labels[i];
}
source.Save("source.pptx", SaveFormat.Pptx);
var startIndex = 1;
var slideCount = 2;
using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);
for (var i = startIndex; i < startIndex + slideCount; i++)
    presentation.Slides.AddClone(source.Slides[i]);
presentation.Save("part-2-3.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Can I remove unused design content from each part?**

Yes. After copying the slides, remove unused layouts and masters where appropriate before saving the smaller presentation.

### **How do I split a deck by a caller-selected range?**

Choose the range in your application, create a destination, and clone the selected source slides in order. Validate the bounds against the source slide count before accepting a user-supplied range.

### **How can I name the output files for each section?**

Your application supplies the output names. Use a section identifier or a slide range in each filename and handle collisions before saving.

## **Guides**

- [Clone Presentation Slides in .NET](/slides/net/clone-slides/)

Related feature: [Remove unused masters, layouts and media](/slides/features/remove-unused-content/).

## Runnable .NET examples

- [Split Presentations](/slides/net/examples/presentations/split/)
