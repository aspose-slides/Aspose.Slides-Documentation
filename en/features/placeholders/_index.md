---
title: Work with placeholders
description: Find, fill and adjust placeholders on slides and layouts.
type: docs
url: /features/placeholders/
weight: 500
feature_id: placeholders
feature_group: slides
translationKey: slides-feature-placeholders
feature_catalogue_version: 3
feature_guides:
- /slides/net/manage-placeholder/
---

## **Overview**

Use placeholders to put content into the spaces defined by a slide layout. Fill titles and content areas, adjust their positions, or add suitable placeholders to layouts. This helps generated slides follow a template instead of relying on unrelated shapes at fixed coordinates.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

This C# example creates a slide from a title layout, finds its title placeholder and fills it. The saved title keeps its placeholder role, so it can continue to inherit appropriate template formatting.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var layout = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Title);
presentation.Slides.RemoveAt(0);
var slide = presentation.Slides.AddEmptySlide(layout);
foreach (var shape in slide.Shapes)
{
    if (shape is IAutoShape textShape && textShape.Placeholder != null && textShape.Placeholder.Type == PlaceholderType.CenteredTitle)
    {
        textShape.TextFrame.Text = "Project update";
        Console.WriteLine("Filled the title placeholder.");
    }
}
presentation.Save("placeholders.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Can I use a placeholder for a picture?**

Yes. Picture placeholders can be part of a layout and provide a defined place for image content.

### **How do I distinguish placeholders from ordinary text shapes?**

Inspect the shape’s placeholder metadata. Ordinary text shapes have no placeholder role even if they are positioned where a title would normally appear.

### **Where does inherited placeholder formatting come from?**

A placeholder can inherit formatting from its matching layout placeholder and master styles. Direct formatting on the slide can override that inherited appearance.

## **Guides**

- [Manage Presentation Placeholders in .NET](/slides/net/manage-placeholder/)

Related feature: [Work with slide layouts](/slides/features/slide-layouts/).
