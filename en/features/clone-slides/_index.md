---
title: Clone slides between presentations
description: Copy slides between presentations with their content and design.
type: docs
url: /features/clone-slides/
weight: 430
feature_id: clone-slides
feature_group: slides
translationKey: slides-feature-clone-slides
feature_catalogue_version: 3
feature_guides:
- /slides/net/clone-slides/
---

## **Overview**

Clone slides to reuse content from another presentation. A copied slide can bring its source master, theme and notes into the destination deck. You can also choose a destination layout when the slide should use the target presentation's design.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

This C# example builds a source slide with a branded master and a named content shape, then clones it into an empty destination. The destination keeps the source design; choosing a destination layout instead is a separate cloning choice.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation();
var sourceSlide = source.Slides[0];
var brand = sourceSlide.LayoutSlide.MasterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20, 240, 40);
brand.TextFrame.Text = "Source brand";
brand.Name = "Brand";
brand.FillFormat.FillType = FillType.Solid;
brand.FillFormat.SolidFillColor.Color = Color.LightBlue;
var panel = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 60, 120, 300, 100);
panel.Name = "Source panel";
panel.TextFrame.Text = "Reusable content";
using var destination = new Presentation();
destination.Slides.RemoveAt(0);
destination.Slides.AddClone(sourceSlide);
destination.Save("clone-slides.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Should I check the destination slide size?**

Choose the target size deliberately. Cloning carries slide content, but different source and destination dimensions can require layout adjustments.

### **Can I clone within the same presentation?**

Yes. Add or insert a clone into the same slide collection when you need a separate copy of a slide. Later edits to the copy do not edit the original slide.

### **How do I control the master used by a cloned slide?**

Choose the cloning overload deliberately: retain the source design, supply a destination master, or supply a destination layout as appropriate. Check layout placeholders and slide dimensions when adapting content to a different design.

## **Guides**

- [Clone Presentation Slides in .NET](/slides/net/clone-slides/)

Related feature: [Merge presentations](/slides/features/merge-presentations/).
