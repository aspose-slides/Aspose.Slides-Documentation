---
title: Set animation order and timing
description: Set animation sequence, delay, duration and repetition.
type: docs
url: /features/animation-timing/
weight: 1120
feature_id: animation-timing
feature_group: animation
translationKey: slides-feature-animation-timing
feature_catalogue_version: 3
feature_guides:
- /slides/net/powerpoint-animation/
---

## **Overview**

Control when animation effects start and how long they run. Effects can start on a click, with the previous effect or after it, with additional delay and repetition settings. Arrange the sequence to match how the slide should be presented.

## **Usage example**

This C# example uses Aspose.Slides for .NET. Set a fade to start after the previous effect with a 0.5-second delay, a two-second duration and two repetitions. These settings are stored in the presentation. The PNG is a static preview and does not show elapsed animation time. No input file is needed. It saves *animation-timing.pptx* and *animation-timing.png*. Install the library using the [installation guide](/slides/net/installation/).

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
var effect = slide.Timeline.MainSequence.AddEffect(target, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
effect.Timing.TriggerDelayTime = 0.5f;
effect.Timing.Duration = 2f;
effect.Timing.RepeatCount = 2f;
presentation.Save("animation-timing.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("animation-timing.png", ImageFormat.Png);
```

## **FAQ**

### **Can I change the order of existing effects?**

Manage the sequence by removing and adding effects in the required order. The sequence preserves its timing settings in the presentation.

### **How do delay and duration differ?**

Delay is the wait before an effect starts after its trigger. Duration is the time the effect takes to run; both are expressed in seconds for animation timing.

### **Can an effect repeat or start after the previous effect?**

Yes. Configure repetition and select the trigger behavior independently. The example starts after the previous effect and sets a repeat count of two.

## **Guides**

- [Enhance PowerPoint Presentations with Animations in .NET](/slides/net/powerpoint-animation/)

Related feature: [Start animations on a click](/slides/features/animation-triggers/).
