---
title: Render animation frames
description: Render intermediate frames for supported presentation animations.
type: docs
url: /features/animation-frames/
weight: 1290
feature_id: animation-frames
feature_group: rendering
translationKey: slides-feature-animation-frames
feature_catalogue_version: 3
feature_guides:
- /slides/net/convert-powerpoint-to-video/
---

## **Overview**

Use the animation rendering workflow to produce frames at a chosen frame rate. Those frames can show motion between slide states for supported effects. Your application can collect them for a preview or pass them to a separate encoder for a video workflow.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Render intermediate PNG frames for a one-second fade at 10 frames per second. This produces image frames for a supported effect, not an encoded video. Frame count also depends on the timeline and default slide duration.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.IO;
using Aspose.Slides.Animation;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 140);
shape.AddTextFrame("Sample slide");
var effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
effect.Timing.Duration = 1;
Directory.CreateDirectory("frames");
using var generator = new PresentationAnimationsGenerator(presentation);
using var player = new PresentationPlayer(generator, 10);
player.FrameTick += (sender, frame) =>
{
    using var image = frame.GetFrame();
    image.Save("frames/frame-" + sender.FrameIndex.ToString("D4") + ".png");
};
generator.Run(presentation.Slides);
presentation.Save("source.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Does every presentation effect produce full intermediate motion?**

Effect coverage varies. Some effects may show only start and end states or remain static; ordinary PDF and image exports are also static views.

### **How does frame rate affect the number of generated images?**

At a fixed timeline duration, a higher frame rate produces more images and finer time steps. Duration and effect timing also affect the count.

### **What additional component is needed to encode frames as MP4?**

Use a separate video encoder to combine the frames and any audio into MP4. The frame-generation API is not a native video encoder.

## **Guides**

- [Convert PowerPoint Presentations to Video in .NET](/slides/net/convert-powerpoint-to-video/)

Related feature: [Export presentations as animated GIFs](/slides/features/animated-gif/).
