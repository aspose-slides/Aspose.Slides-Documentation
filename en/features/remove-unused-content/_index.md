---
title: Remove unused masters, layouts and media
description: Remove unused slide layouts and masters before saving.
type: docs
url: /features/remove-unused-content/
weight: 260
feature_id: remove-unused-content
feature_group: operations
translationKey: slides-feature-remove-unused-content
feature_catalogue_version: 3
feature_guides:
- /slides/net/slide-master/
---

## **Overview**

Clean up design content left after deleting or extracting slides. Remove unused layouts and masters, then save the presentation; media that is no longer referenced can be dropped during saving. This can help keep generated or split decks smaller.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It creates a *Hello* slide and an extra unused blank layout named *UnusedLayout*. Cleanup removes unreferenced layouts before unreferenced masters, then saves *cleaned.pptx*. Used slide content remains available.

For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var title = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 80);
title.TextFrame.Text = "Hello";
var unusedLayout = presentation.Masters[0].LayoutSlides.Add(SlideLayoutType.Blank, "UnusedLayout");
var beforeCount = presentation.LayoutSlides.Count;
presentation.LayoutSlides.RemoveUnused();
presentation.Masters.RemoveUnused(true);
Console.WriteLine($"Layouts: {beforeCount} -> {presentation.LayoutSlides.Count}");
presentation.Save("cleaned.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Does this also remove every unused embedded font?**

No. Embedded-font cleanup is a separate task. Inspect the fonts your presentation uses and remove unwanted embedded fonts explicitly.

### **When should I remove unused layouts before masters?**

Remove unused layouts first, then unused masters. Layouts reference masters, so retaining unused layouts can keep otherwise unused design content reachable.

### **What happens to unreferenced media when I save?**

Media no longer referenced by saved presentation content can be dropped during saving. Verify the package and required slides rather than assuming every cleanup workflow removes every unused resource.

## **Guides**

- [Manage Presentation Slide Masters in .NET](/slides/net/slide-master/)

Related feature: [List embedded fonts](/slides/features/list-embedded-fonts/).

## Runnable .NET examples

- [Remove Unused Presentation Resources](/slides/net/examples/optimization-batch/cleanup/)
