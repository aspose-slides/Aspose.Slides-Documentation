---
title: Set slide transitions and timing
description: Choose slide transitions and set how slides advance.
type: docs
url: /features/slide-transitions/
weight: 1150
feature_id: slide-transitions
feature_group: transitions
translationKey: slides-feature-slide-transitions
feature_catalogue_version: 3
feature_guides:
- /slides/net/slide-transition/
---

## **Overview**

Set the transition used when moving to a slide and control advancement by click or elapsed time. Adjust timing and transition-specific settings to suit the presentation. These instructions are saved in the deck for its slideshow workflow.

## **Usage example**

This C# example uses Aspose.Slides for .NET. Create two related slides and apply a 1,200-millisecond fade to the second. Its rectangle is light blue to distinguish the slide states. The presentation stores the transition; the PNG is a static slide view. No input file is needed. It saves *slide-transitions.pptx* and *slide-transitions.png*. Install the library using the [installation guide](/slides/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;
using System.Drawing;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var target = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
target.Name = "Reveal target";
target.TextFrame.Text = "Quarterly results";
var secondSlide = presentation.Slides.AddClone(slide);
secondSlide.Shapes[0].FillFormat.FillType = FillType.Solid;
secondSlide.Shapes[0].FillFormat.SolidFillColor.Color = Color.LightBlue;
secondSlide.SlideShowTransition.Type = TransitionType.Fade;
secondSlide.SlideShowTransition.Duration = 1200;
presentation.Save("slide-transitions.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("slide-transitions.png", ImageFormat.Png);
```

## **FAQ**

### **Can a slide advance automatically?**

Yes. Set the time-based advancement settings, and choose whether click advancement should also be allowed.

### **Can each slide use a different transition?**

Yes. Configure the transition separately on each slide. Set it on the destination slide for the movement into that slide.

### **Does a transition change the actual slide content?**

A transition controls how a slideshow moves between slide views. It does not replace the underlying shapes or text, and a static export shows a slide state.

## **Guides**

- [Manage Slide Transitions in Presentations in .NET](/slides/net/slide-transition/)

Related feature: [Set transition effects, direction and sound](/slides/features/transition-options/).
