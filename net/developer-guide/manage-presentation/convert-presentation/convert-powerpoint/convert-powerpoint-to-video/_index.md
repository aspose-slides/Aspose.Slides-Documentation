---
title: Convert PowerPoint to Video
type: docs
weight: 130
url: /net/convert-powerpoint-to-video/
keywords: "Convert PowerPoint, PPT, PPTX, Presentation, Video, MP4, PPT to video, PPT to MP4, C#, Csharp, .NET, Aspose.Slides"
description: "Convert PowerPoint to Video in C# or .NET "
---

By converting your PowerPoint presentation to video, you get 

* **Increase in accessibility:** All devices (regardless of platform) are equipped with video players by default compared to presentation-opening applications, so users find it easier to open or play videos.
* **More reach:** Through videos, you can reach a large audience and target them with information that might otherwise seem tedious in a presentation. Most surveys and statistics suggest that people watch and consume videos more than other forms of content and they generally prefer such content.

{{% alert color="primary" %}} 

You may want to check our [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word) because it is a live and effective implementation of the process described here.

{{% /alert %}} 

## **PowerPoint to Video Conversion in Aspose.Slides**

In [Aspose.Slides 22.11](https://docs.aspose.com/slides/net/aspose-slides-for-net-22-11-release-notes/), we implemented support for presentation to video conversion. 

* Use Aspose.Slides to generate a set of frames (from the presentation slides) that correspond to a certain FPS (frames per second)
* Use a third-party utility like FFMpegCore (ffmpeg) to create a video based on the frames. 

### **Convert PowerPoint to Video**

1. Use the dotnet add package command to add Aspose.Slides and the FFMpegCore library to your project:
   * run `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * run `dotnet add package FFMpegCore --version 4.8.0`
2. Dowload ffmpeg [here](https://ffmpeg.org/download.html).
3. FFMpegCore requires you to specify the path to the downloaded ffmpeg (e.g. extracted into "C:\tools\ffmpeg"):  `GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin",} );`
4. Run the PowerPoint to video code.

This C# code shows you how to convert a presentation (containing a figure and two animation effects) to a video:

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;
using (Presentation presentation = new Presentation())

{
    // add smile shape and animate it
    IAutoShape smile = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    IEffect effectIn = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

   const int Fps = 33;
   List<string> frames = new List<string>();

   using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };
        animationsGenerator.Run(presentation.Slides);
    }

    // Configure ffmpeg binaries folder, see: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin", });

    // convert frames to webm video
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());

}
```

## **Video Effects**

You can apply animations to objects on slides and use transitions between slides. 

{{% alert color="primary" %}} 

You may want to see these articles: [PowerPoint Animation](https://docs.aspose.com/slides/net/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/net/shape-animation/), [Shape Effect](https://docs.aspose.com/slides/net/shape-effect/).

{{% /alert %}} 

Animations and transitions make slideshows more engaging and interesting—and they do the same thing for videos. Let's add another slide and transition to the code for the previous presentation:

```c#
// add smile shape and animate it

// ...

// add a new slide and animated transition

ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

newSlide.Background.Type = BackgroundType.OwnBackground;

newSlide.Background.FillFormat.FillType = FillType.Solid;

newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;

newSlide.SlideShowTransition.Type = TransitionType.Push;
```

Aspose.Slides also supports animation for texts. So we animate paragraphs on objects, which will appear one after the other (with delay set to a second):

```c#
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    // add text and animations
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.Portions.Add(new Portion("Aspose Slides for .NET"));
    Paragraph para2 = new Paragraph();
    para2.Portions.Add(new Portion("convert PowerPoint Presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.Portions.Add(new Portion("paragraph by paragraph"));
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    autoShape.TextFrame.Paragraphs.Add(new Paragraph());

    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect2 = presentation.Slides[0].Timeline.MainSequence.AddEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect3 = presentation.Slides[0].Timeline.MainSequence.AddEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect4 = presentation.Slides[0].Timeline.MainSequence.AddEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect.Timing.TriggerDelayTime = 1f;
    effect2.Timing.TriggerDelayTime = 1f;
    effect3.Timing.TriggerDelayTime = 1f;
    effect4.Timing.TriggerDelayTime = 1f;

    // convert to video
    const int Fps = 33;
    List<string> frames = new List<string>();
    
    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))

    using (var player = new PresentationPlayer(animationsGenerator, Fps))

    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };
        animationsGenerator.Run(presentation.Slides);
    }
    // Configure ffmpeg binaries folder, see: https://github.com/rosenbjerg/FFMpegCore#installation

    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin", });
    // convert frames to webm video
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());

}
```

## **Video Conversion Classes**

To allow you to perform PowerPoint to video conversion tasks, Aspose.Slides provides the [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) and [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) classes.

PresentationAnimationsGenerator allows you to set the frame size for the video (that will be created later) through its constructor. If you pass an instance of the presentation, `Presentation.SlideSize` will be used) and it generates animations that [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) uses. 

When animations are generated, a `NewAnimation` event is generated for each subsequent animation, which has the [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/) parameter. The latter is a class that represents a player for a separate animation.

To work with [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/), the [Duration](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/duration/) (the full duration of the animation) property and [SetTimePosition](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/) method are used. Each animation position is set within the *0 to duration* range and then the `GetFrame` method will return a Bitmap that corresponds to the animation state at that moment.

```c#
using (Presentation presentation = new Presentation())

{
    // add smile shape and animate it
    IAutoShape smile = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    IEffect effectIn = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    {
        animationsGenerator.NewAnimation += animationPlayer =>
        {
            Console.WriteLine($"Total animation duration: {animationPlayer.Duration}");
            
            animationPlayer.SetTimePosition(0); // initial animation state
            Bitmap bitmap = animationPlayer.GetFrame(); // initial animation state bitmap

            animationPlayer.SetTimePosition(animationPlayer.Duration); // final state of the animation
            Bitmap lastBitmap = animationPlayer.GetFrame(); // last frame of the animation
            lastBitmap.Save("last.png");
        };
    }
}
```

To make all animations in a presentation play at once, the [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) class is used. This class  takes a [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) instance and FPS for effects in its constructor and then call the `FrameTick` event for all the animations to get them played:

```c#
using (Presentation presentation = new Presentation("animated.pptx"))
{
    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, 33))
    {
        player.FrameTick += (sender, args) =>
        {
            args.GetFrame().Save($"frame_{sender.FrameIndex}.png");
        };
        animationsGenerator.Run(presentation.Slides);
    }
}
```

Then the generated frames can be compiled to produce a video. See the [Convert PowerPoint to Video](https://docs.aspose.com/slides/net/convert-powerpoint-to-video/#convert-powerpoint-to-video) section.



