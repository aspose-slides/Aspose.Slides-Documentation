---
title: Compare slides
description: Compare the structure of two slides.
type: docs
url: /features/compare-slides/
weight: 230
feature_id: compare-slides
feature_group: operations
translationKey: slides-feature-compare-slides
feature_catalogue_version: 3
feature_guides:
- /slides/net/compare-slides/
---

## **Overview**

Use slide comparison to determine whether two slides have equal structures. This is useful when your application already knows which slides should be compared, such as matching positions in two versions of a deck. The result is an equality decision for each pair.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It creates three copies of one source slide, then compares the unchanged pair and a copy whose rectangle has moved. The printed structural comparisons are *True* and *False*. Pair selection belongs to the caller; this does not produce a whole-deck change list.

For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation();
var sourceSlide = source.Slides[0];
var title = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 80);
title.TextFrame.Text = "Hello";
using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);
var original = presentation.Slides.AddClone(sourceSlide);
var equalClone = presentation.Slides.AddClone(sourceSlide);
var editedClone = presentation.Slides.AddClone(sourceSlide);
editedClone.Shapes[0].X = 100;
Console.WriteLine($"Unchanged clone: {original.Equals(equalClone)}");
Console.WriteLine($"Edited clone: {original.Equals(editedClone)}");
presentation.Save("compared.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Will it produce a list of changes across two decks?**

No. Your application chooses slide pairs and handles inserted or removed slides. This operation does not provide a presentation-wide change list or slide alignment.

### **Does equality compare structure or rendered pixels?**

It compares slide structure. It does not render the slides and compare their pixels; use a separate rendering comparison when visual differences are the question.

### **How should my application choose corresponding slide pairs?**

Use the identifiers or ordering rules that make sense for your application. Handle inserted, removed and reordered slides before choosing pairs; structural equality does not align two decks for you.

## **Guides**

- [Compare Presentation Slides in .NET](/slides/net/compare-slides/)

Related feature: [Add, remove and reorder slides](/slides/features/manage-slides/).
