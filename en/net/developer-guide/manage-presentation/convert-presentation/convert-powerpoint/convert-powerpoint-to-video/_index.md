---
title: Convert PowerPoint Presentations to Video in C#
linktitle: PowerPoint to Video
type: docs
weight: 130
url: /net/convert-powerpoint-to-video/
keywords:
- PowerPoint to video
- convert PowerPoint to video
- presentation to video
- convert presentation to video
- PPT to video
- convert PPT to video
- PPTX to video
- convert PPTX to video
- ODP to video
- convert ODP to video
- PowerPoint to MP4
- convert PowerPoint to MP4
- presentation to MP4
- convert presentation to MP4
- PPT to MP4
- convert PPT to MP4
- PPTX to MP4
- convert PPTX to MP4
- PowerPoint to video conversion
- presentation to video conversion
- PPT to video conversion
- PPTX to video conversion
- ODP to video conversion
- C# video conversion
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Learn how to convert PowerPoint and OpenDocument presentations to video using C#. Discover sample code and automation techniques to streamline your workflow."
---

## **Overview**

By converting your PowerPoint or OpenDocument presentation to video, you gain:

**Increased accessibility:** All devices, regardless of platform, are equipped with video players by default, making it easier for users to open or play videos compared to traditional presentation applications.

**Wider reach:** Videos enable you to reach a larger audience and present information in a more engaging format. Surveys and statistics indicate that people prefer to watch and consume video content over other forms, making your message more impactful.

{{% alert color="primary" %}} 

Check out our [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/video) because it offers a live and effective implementation of the process described here.

{{% /alert %}} 

In Aspose.Slides for .NET, we implemented support for converting presentations to video.

* Use Aspose.Slides for .NET to generate frames from the presentation slides at a specified frame rate (FPS).
* Then, use a third-party utility like ffmpeg to compile these frames into a video.

## **Convert a PowerPoint Presentation to Video**

1. Use the `dotnet add package` command to add Aspose.Slides and the FFMpegCore library to your project:
   * run `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * run `dotnet add package FFMpegCore --version 4.8.0`
2. Dowload ffmpeg from [here](https://ffmpeg.org/download.html).
3. FFMpegCore requires you to specify the path to the downloaded ffmpeg (e.g., extracted to "C:\tools\ffmpeg"):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. Run the PowerPoint-to-video conversion code.

This C# code demonstrates how to convert a presentation (containing a shape and two animation effects) into a video:

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // will use the FFmpeg binaries we extracted to C:\tools\ffmpeg earlier.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Add a smile shape and then animate it.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

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

    // Configure the ffmpeg binaries folder. See this page: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Convert the frames to a webm video.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Video Effects**

When converting a PowerPoint presentation to video using Aspose.Slides for .NET, you can apply various video effects to enhance the visual quality of the output. These effects allow you to control the appearance of slides in the final video by adding smooth transitions, animations, and other visual elements. This section explains the available video effect options and shows how to apply them.

{{% alert color="primary" %}} 

See:
- [Enhancing PowerPoint Presentations with Animations in C#](https://docs.aspose.com/slides/net/powerpoint-animation/)
- [Shape Animation](https://docs.aspose.com/slides/net/shape-animation/)
- [Apply Shape Effects in PowerPoint Using C#](https://docs.aspose.com/slides/net/shape-effect/)

{{% /alert %}} 

Animations and transitions make slideshows more engaging and interesting — and they do the same for videos. Let's add another slide and transition to the code for the previous presentation:

```c#
// Add a smile shape and animate it.
// ...

// Add a new slide and an animated transition.
ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
newSlide.Background.Type = BackgroundType.OwnBackground;
newSlide.Background.FillFormat.FillType = FillType.Solid;
newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
newSlide.SlideShowTransition.Type = TransitionType.Push;
```

Aspose.Slides also supports text animations. In this example, we animate paragraphs on objects so that they appear one after the other, with a one-second delay between them:

```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Add text and animations.
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.Portions.Add(new Portion("Aspose Slides for .NET"));
    Paragraph para2 = new Paragraph();
    para2.Portions.Add(new Portion("Convert a PowerPoint presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.Portions.Add(new Portion("paragraph by paragraph"));
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    autoShape.TextFrame.Paragraphs.Add(new Paragraph());

    IEffect effect1 = slide.Timeline.MainSequence.AddEffect(
        para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect2 = slide.Timeline.MainSequence.AddEffect(
        para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect3 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect4 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.Timing.TriggerDelayTime = 1f;
    effect2.Timing.TriggerDelayTime = 1f;
    effect3.Timing.TriggerDelayTime = 1f;
    effect4.Timing.TriggerDelayTime = 1f;

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

    // Configure the ffmpeg binaries folder. See this page: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Convert the frames to a webm video.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Video Conversion Classes**

To enable PowerPoint to video conversion tasks, Aspose.Slides for .NET provides the [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) and [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) classes.

`PresentationAnimationsGenerator` allows you to set the frame size for the video (which will be created later) and the FPS (frames per second) value through its constructor. If you pass an instance of a presentation, its `Presentation.SlideSize` will be used and it generates animations that [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) uses.

When animations are generated, a `NewAnimation` event is triggered for each subsequent animation, which includes an [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/) parameter. This class represents a player for an individual animation.

To work with [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/), you use the [Duration](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/duration/) property (which gives the full duration of the animation) and the [SetTimePosition](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/) method. Each animation position is set within the *0 to duration* range, and the `GetFrame` method then returns a Bitmap representing the animation state at that point in time.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Add a smile shape and animate it.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    {
        animationsGenerator.NewAnimation += animationPlayer =>
        {
            Console.WriteLine($"Total animation duration: {animationPlayer.Duration}");

            animationPlayer.SetTimePosition(0);          // The initial animation state.
            Bitmap bitmap = animationPlayer.GetFrame();  // The initial animation state bitmap.

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // The final state of the animation.
            Bitmap lastBitmap = animationPlayer.GetFrame();             // The last frame of the animation.
            lastBitmap.Save("last.png");
        };
    }
}
```

To make all animations in a presentation play at once, the [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) class is used. This class takes a [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) instance and an FPS value for effects in its constructor, and then calls the `FrameTick` event for all animations to play them:

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

Then the generated frames can be compiled to produce a video. See the [Convert a PowerPoint Presentation to Video](/slides/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video) section.

## **Supported Animations and Effects**

When converting a PowerPoint presentation to video using Aspose.Slides for .NET, it's important to understand which animations and effects are supported in the output. Aspose.Slides supports a wide range of common entrance, exit, and emphasis effects such as fade, fly in, zoom, and spin. However, some advanced or custom animations may not be fully preserved or may appear differently in the final video. This section outlines the supported animations and effects.

**Entrance**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |


**Emphasis**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**Exit**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Motion Paths:**

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Supported Slide Transition Effects**

Slide transition effects play an important role in creating smooth and visually appealing changes between slides in a video. Aspose.Slides for .NET supports a variety of commonly used transition effects to help preserve the flow and style of your original presentation. This section highlights which transition effects are supported during the conversion process.

**Subtle**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Push** | ![supported](v.png) | ![supported](v.png) |
| **Pull** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Reveal** | ![not supported](x.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![not supported](x.png) | ![supported](v.png) |
| **Uncover** | ![not supported](x.png) | ![supported](v.png) |
| **Cover** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Strips** | ![supported](v.png) | ![supported](v.png) |

**Exciting**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![not supported](x.png) | ![supported](v.png) |
| **Drape** | ![not supported](x.png) | ![supported](v.png) |
| **Curtains** | ![not supported](x.png) | ![supported](v.png) |
| **Wind** | ![not supported](x.png) | ![supported](v.png) |
| **Prestige** | ![not supported](x.png) | ![supported](v.png) |
| **Fracture** | ![not supported](x.png) | ![supported](v.png) |
| **Crush** | ![not supported](x.png) | ![supported](v.png) |
| **Peel Off** | ![not supported](x.png) | ![supported](v.png) |
| **Page Curl** | ![not supported](x.png) | ![supported](v.png) |
| **Airplane** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolve** | ![supported](v.png) | ![supported](v.png) |
| **Checkerboard** | ![not supported](x.png) | ![supported](v.png) |
| **Blinds** | ![not supported](x.png) | ![supported](v.png) |
| **Clock** | ![supported](v.png) | ![supported](v.png) |
| **Ripple** | ![not supported](x.png) | ![supported](v.png) |
| **Honeycomb** | ![not supported](x.png) | ![supported](v.png) |
| **Glitter** | ![not supported](x.png) | ![supported](v.png) |
| **Vortex** | ![not supported](x.png) | ![supported](v.png) |
| **Shred** | ![not supported](x.png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x.png) | ![supported](v.png) |
| **Gallery** | ![not supported](x.png) | ![supported](v.png) |
| **Cube** | ![not supported](x.png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**Dynamic Content**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **FAQs**

**Is it possible to convert presentations that are password protected?**

Yes, Aspose.Slides for .NET allows working with password-protected presentations. When processing such files, you need to provide the correct password so that the library can access the content of the presentation.

**Does Aspose.Slides for .NET support usage in cloud solutions?**

Yes, Aspose.Slides for .NET can be integrated into cloud applications and services. The library is designed to work in server environments, ensuring high performance and scalability for batch processing of files.

**Are there any size limitations for presentations during conversion?**

Aspose.Slides for .NET is capable of handling presentations of virtually any size. However, when working with very large files, additional system resources may be required, and it is sometimes recommended to optimize the presentation to improve performance.
