---
title: Export presentations as animated GIFs
description: Create an animated GIF from a presentation.
type: docs
url: /features/animated-gif/
weight: 120
feature_id: animated-gif
feature_group: formats
translationKey: slides-feature-animated-gif
feature_catalogue_version: 3
feature_guides:
- /slides/net/convert-powerpoint-to-animated-gif/
---

## **Overview**

Export slides as an animated GIF for a preview or a short visual walkthrough. The library creates the GIF directly. For a video workflow, it can also render animation frames that your application passes to a separate video encoder.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It creates red and blue slides and exports a 320 × 180 pixel animated GIF. The configured slide delay is 1,200 milliseconds. The exporter may emit additional frames, so a GIF need not have exactly one frame per slide. This example animates the change between the two backgrounds.

For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
for (var i = 0; i < 2; i++)
{
    var slide = i == 0 ? presentation.Slides[0] : presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = i == 0 ? Color.Red : Color.Blue;
}
var options = new GifOptions
{
    FrameSize = new Size(320, 180),
    DefaultDelay = 1200,
    TransitionFps = 10
};
presentation.Save("source.pptx", SaveFormat.Pptx);
presentation.Save("slides.gif", SaveFormat.Gif, options);
```

## **FAQ**

### **Can the library save an MP4 directly?**

No. Video encoding is a separate step. Use the animation-frame workflow with an encoder when you need MP4 or another video format.

### **How do I control the time spent on each GIF slide?**

Set the default slide delay in the GIF export options. The example uses 1,200 milliseconds per slide; transitions can add intermediate frames when present.

### **Can I change the dimensions of the animated GIF?**

Yes. Set the frame size to the required width and height in pixels. Keep the original aspect ratio unless you intend to change the presentation’s proportions.

## **Guides**

- [Convert PowerPoint Presentations to Animated GIFs in .NET](/slides/net/convert-powerpoint-to-animated-gif/)

Related feature: [Render animation frames](/slides/features/animation-frames/).

## Runnable .NET examples

- [Export an Animated GIF](/slides/net/examples/conversion-rendering/animated-gif/)
