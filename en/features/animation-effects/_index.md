---
title: Animate shapes and text
description: Add animation effects to shapes and paragraphs.
type: docs
url: /features/animation-effects/
weight: 1110
feature_id: animation-effects
feature_group: animation
translationKey: slides-feature-animation-effects
feature_catalogue_version: 3
feature_guides:
- /slides/net/shape-animation/
---

## **Overview**

Apply presentation animation effects to slide shapes or text paragraphs. Choose an effect and its subtype, then place it in the slide's animation sequence. This lets generated presentations introduce content or emphasize an object during a slideshow.

## **Usage example**

This C# example uses Aspose.Slides for .NET. Add a click-triggered fade to a named rectangle containing Quarterly results. The saved presentation contains the shape and its animation instructions. The PNG is a static preview, not an animation-frame export. No input file is needed. It saves *animation-effects.pptx* and *animation-effects.png*. Install the library using the [installation guide](/slides/net/installation/).

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
slide.Timeline.MainSequence.AddEffect(target, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
presentation.Save("animation-effects.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("animation-effects.png", ImageFormat.Png);
```

## **FAQ**

### **Will a PDF show the animated sequence?**

A static export shows a slide view. Use animation-frame rendering when you need intermediate motion from supported effects.

### **Can I apply more than one effect to a shape?**

Yes. Add multiple effects targeting the same shape, then choose their order and timing in the sequence.

### **How can I remove an animation effect while keeping its target shape?**

Remove the effect from its animation sequence, or remove effects associated with that shape. Removing an effect does not require deleting the shape itself.

## **Guides**

- [Apply Shape Animations in Presentations in .NET](/slides/net/shape-animation/)

Related feature: [Render animation frames](/slides/features/animation-frames/).
