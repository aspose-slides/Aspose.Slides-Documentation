---
title: Work with slide layouts
description: Create slides from layouts and change the layout assigned to a slide.
type: docs
url: /features/slide-layouts/
weight: 450
feature_id: slide-layouts
feature_group: slides
translationKey: slides-feature-slide-layouts
feature_catalogue_version: 3
feature_guides:
- /slides/net/slide-layout/
---

## **Overview**

Work with the layouts attached to a presentation's masters. Layouts provide placeholder positions and shared structure for titles, text and pictures. Select a layout for a new slide, copy layouts when needed, or assign a different layout to an existing slide.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

This C# example selects the title layout from the first master and creates a slide from it. The resulting slide inherits the layout’s title placeholders and remains associated with that layout in the saved PPTX.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var layout = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Title);
if (layout != null)
{
    presentation.Slides.RemoveAt(0);
    var slide = presentation.Slides.AddEmptySlide(layout);
    slide.Name = "Title layout example";
    presentation.Save("slide-layouts.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The presentation has no title layout.");
}
```

## **FAQ**

### **Why use a layout instead of placing every object manually?**

A layout gives related slides a common structure and provides placeholders your application can fill with content.

### **How do layouts relate to slide masters?**

Each layout belongs to a master. The master supplies shared design and theme information, while layouts define the placeholder arrangement used by individual slides.

### **Can I switch an existing slide to another layout?**

Yes. Assign a different layout to the slide. Inspect the resulting placeholders and content afterward, especially if the old and new layouts have different structures.

## **Guides**

- [Apply or Change Slide Layouts in .NET](/slides/net/slide-layout/)

Related feature: [Work with placeholders](/slides/features/placeholders/).
