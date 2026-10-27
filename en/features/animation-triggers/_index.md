---
title: Start animations on a click
description: Start an animation when a chosen shape is clicked.
type: docs
url: /features/animation-triggers/
weight: 1130
feature_id: animation-triggers
feature_group: animation
translationKey: slides-feature-animation-triggers
feature_catalogue_version: 3
feature_guides:
- /slides/net/powerpoint-animation/
---

## **Overview**

Create an interactive animation sequence tied to a trigger shape. Clicking that shape in a compatible slideshow can start effects on other slide objects. This is useful for reveal buttons, interactive diagrams or slides where the reader chooses the next detail.

## **Usage example**

This C# example uses Aspose.Slides for .NET. Create a Reveal button and a separate target rectangle. A click on the button starts the target's fade in a compatible slideshow. The saved sequence records both shape associations; a static PNG does not execute the click. No input file is needed. It saves *animation-triggers.pptx* and *animation-triggers.png*. Install the library using the [installation guide](/slides/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var target = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
target.Name = "Reveal target";
target.TextFrame.Text = "Quarterly results";
var button = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
button.Name = "Reveal button";
button.TextFrame.Text = "Reveal";
var interactive = slide.Timeline.InteractiveSequences.Add(button);
interactive.AddEffect(target, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
presentation.Save("animation-triggers.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("animation-triggers.png", ImageFormat.Png);
```

## **FAQ**

### **Is a trigger tied to the whole slide?**

It can be tied to a specific shape. The sequence records which object triggers the animation.

### **How do interactive sequences differ from the main timeline?**

The main sequence follows the slide's ordinary animation order. An interactive sequence has its own trigger shape and effects, allowing the viewer to choose when to reveal content.

### **Can a slide contain more than one interactive animation sequence?**

Yes. Add separate interactive sequences and assign their trigger shapes and effects. Keep the intended associations clear when editing the slide's shapes.

## **Guides**

- [Enhance PowerPoint Presentations with Animations in .NET](/slides/net/powerpoint-animation/)

Related feature: [Set animation order and timing](/slides/features/animation-timing/).
