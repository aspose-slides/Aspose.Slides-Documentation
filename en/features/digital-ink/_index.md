---
title: Work with digital ink
description: Read, restyle and remove existing digital ink annotations.
type: docs
url: /features/digital-ink/
weight: 630
feature_id: digital-ink
feature_group: shapes
translationKey: slides-feature-digital-ink
feature_catalogue_version: 3
feature_guides:
- /slides/net/manage-ink/
---

## **Overview**

Work with ink strokes stored in a presentation. Inspect their traces and brush settings, change properties such as color and size, or remove ink that is no longer needed. Existing ink can also be rendered as part of the slide.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

Download the public [ink sample presentation](https://raw.githubusercontent.com/aspose-slides/Aspose.Slides-for-.NET/master/Examples/Data/Shapes/SimpleInk.pptx) as SimpleInk.pptx. This C# example changes all existing traces on the first slide to red and renders that slide. It edits existing handwriting rather than creating new ink strokes.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

using var presentation = new Presentation("SimpleInk.pptx");
foreach (var shape in presentation.Slides[0].Shapes)
{
    if (shape is IInk ink)
    {
        foreach (var trace in ink.Traces)
        {
            trace.Brush.Color = Color.Red;
        }
    }
}
presentation.Save("digital-ink.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1, 1);
image.Save("digital-ink.png", ImageFormat.Png);
```

## **FAQ**

### **Can I draw new ink strokes from scratch?**

This feature covers working with existing ink. Use ordinary shapes or geometry paths when your application needs to create new drawn content.

### **How are ink traces different from ordinary freeform shapes?**

Ink traces store pen trajectories and brush properties. A freeform shape stores geometry paths and ordinary shape formatting; they are different object models even when both look like drawn lines.

### **Can I hide ink when rendering a slide?**

Yes. Use the ink-hiding option on the chosen export or rendering settings. This affects the output without requiring you to delete the stored annotations.

## **Guides**

- [Manage Presentation Ink Objects in .NET](/slides/net/manage-ink/)

Related feature: [Edit shape geometry](/slides/features/shape-geometry/).
