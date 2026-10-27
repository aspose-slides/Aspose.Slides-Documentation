---
title: Add, remove and reorder slides
description: Add slides, remove them and change their order.
type: docs
url: /features/manage-slides/
weight: 420
feature_id: manage-slides
feature_group: slides
translationKey: slides-feature-manage-slides
feature_catalogue_version: 3
feature_guides:
- /slides/net/add-slide-to-presentation/
- /slides/net/remove-slide-from-presentation/
---

## **Overview**

Manage the slide collection when building or editing a presentation. Insert slides where they belong, remove pages that are no longer needed, and reorder the remaining slides. Your application can use this to assemble a report or tailor a deck to its audience.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

This C# example creates three named slides, moves the last slide to the beginning and removes the temporary slide. The saved deck contains Summary followed by Details. Collection positions are zero-based.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var summary = presentation.Slides[0];
summary.Name = "Summary";
var temporary = presentation.Slides.AddEmptySlide(summary.LayoutSlide);
temporary.Name = "Temporary";
var details = presentation.Slides.AddEmptySlide(summary.LayoutSlide);
details.Name = "Details";
presentation.Slides.Reorder(0, details);
presentation.Slides.Remove(temporary);
presentation.Slides.Reorder(0, summary);
presentation.Save("manage-slides.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Can I move a slide without recreating its content?**

Yes. Reordering changes its position in the presentation while keeping the slide and its objects.

### **How do slide indexes change after removal?**

Later slides shift down by one collection index. Re-read the collection after a removal, or keep a reference to the slide object when subsequent operations target that slide.

### **Can I insert a slide at a chosen position?**

Yes. Insert an empty slide using a selected layout at the required collection index, or insert a clone when you need existing content. Index zero is the beginning of the collection.

## **Guides**

- [Add Slides to Presentations in .NET](/slides/net/add-slide-to-presentation/)
- [Remove Slides from Presentations in .NET](/slides/net/remove-slide-from-presentation/)

Related feature: [Organize slides into sections](/slides/features/slide-sections/).
