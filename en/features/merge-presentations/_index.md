---
title: Merge presentations
description: Combine slides from several presentations into one deck.
type: docs
url: /features/merge-presentations/
weight: 190
feature_id: merge-presentations
feature_group: operations
translationKey: slides-feature-merge-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/merge-presentation/
---

## **Overview**

Merge presentations or append selected slides to an existing deck. Cloned slides can carry their masters and layouts with them, allowing different source designs to remain in the combined presentation. Choose the target deck and the order of its slides before saving.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It generates two one-slide decks, then appends their slides in file-list order. Removing the destination’s default slide produces *merged.pptx* with *Alpha* followed by *Bravo*.

For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var files = new[] { "alpha.pptx", "bravo.pptx" };
for (var i = 0; i < files.Length; i++)
{
    using var source = new Presentation();
    var title = source.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 80);
    title.TextFrame.Text = i == 0 ? "Alpha" : "Bravo";
    source.Save(files[i], SaveFormat.Pptx);
}
using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);
foreach (var path in files)
{
    using var source = new Presentation(path);
    foreach (var slide in source.Slides)
        presentation.Slides.AddClone(slide);
}
presentation.Save("merged.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **What happens if the source presentations have different slide sizes?**

The destination presentation's size applies. Adjust incoming slide content when the source and destination dimensions differ.

### **Can I retain source slide designs when merging?**

Yes. Cloning can bring the source master and layout into the destination. Review the resulting designs and handle differences in slide size deliberately.

### **How do I avoid retaining the destination blank slide?**

Remove the initial slide from a new destination before cloning the source slides, as the example does. Keep it only when it is intended to appear in the result.

## **Guides**

- [Efficiently Merge Presentations in .NET](/slides/net/merge-presentation/)

Related feature: [Clone slides between presentations](/slides/features/clone-slides/).
