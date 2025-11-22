---
title: 使用 C# 将 PowerPoint 演示文稿转换为视频
linktitle: PowerPoint 转视频
type: docs
weight: 130
url: /zh/net/convert-powerpoint-to-video/
keywords:
- PowerPoint 转视频
- 将 PowerPoint 转换为视频
- 演示文稿转视频
- 将演示文稿转换为视频
- PPT 转视频
- 将 PPT 转换为视频
- PPTX 转视频
- 将 PPTX 转换为视频
- ODP 转视频
- 将 ODP 转换为视频
- PowerPoint 转 MP4
- 将 PowerPoint 转换为 MP4
- 演示文稿转 MP4
- 将演示文稿转换为 MP4
- PPT 转 MP4
- 将 PPT 转换为 MP4
- PPTX 转 MP4
- 将 PPTX 转换为 MP4
- PowerPoint 转视频转换
- 演示文稿转视频转换
- PPT 转视频转换
- PPTX 转视频转换
- ODP 转视频转换
- C# 视频转换
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 C# 将 PowerPoint 和 OpenDocument 演示文稿转换为视频。探索示例代码和自动化技巧，以简化工作流。"
---

## **概述**

通过将 PowerPoint 或 OpenDocument 演示文稿转换为视频，您可以获得：

**提升可访问性：** 所有设备默认都配备视频播放器，无论平台如何，相比传统演示应用，用户打开或播放视频更为便捷。

**更广的受众：** 视频让您能够触及更大观众，并以更具吸引力的形式呈现信息。调查与统计显示，人们更倾向于观看和消费视频内容，使您的信息更具冲击力。

{{% alert color="primary" %}} 

查看我们的[**PowerPoint 转视频在线转换器**](https://products.aspose.app/slides/video)，它提供了本文所述过程的实时有效实现。

{{% /alert %}} 

在 Aspose.Slides for .NET 中，我们实现了将演示文稿转换为视频的支持。

* 使用 Aspose.Slides for .NET 按指定帧率（FPS）从演示幻灯片生成帧。
* 然后，使用第三方实用程序如 ffmpeg 将这些帧合成为视频。

## **将 PowerPoint 演示文稿转换为视频**

1. 使用 `dotnet add package` 命令将 Aspose.Slides 和 FFMpegCore 库添加到项目中：
   * 运行 `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * 运行 `dotnet add package FFMpegCore --version 4.8.0`
2. 从[此处](https://ffmpeg.org/download.html)下载 ffmpeg。
3. FFMpegCore 需要您指定下载的 ffmpeg 的路径（例如，解压到 “C:\tools\ffmpeg”）：  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```

4. 运行 PowerPoint 转视频的转换代码。

下面的 C# 代码演示了如何将包含形状和两个动画效果的演示文稿转换为视频：
```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // 将使用我们之前提取到 C:\tools\ffmpeg 的 FFmpeg 二进制文件。
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 添加一个笑脸形状并对其进行动画。
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

    // 配置 ffmpeg 二进制文件夹。请参阅此页面: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // 将帧转换为 webm 视频。
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```


## **视频效果**

在使用 Aspose.Slides for .NET 将 PowerPoint 演示文稿转换为视频时，您可以应用各种视频效果以提升输出的视觉质量。这些效果通过添加平滑过渡、动画和其他视觉元素，让您能够控制最终视频中幻灯片的呈现方式。本节说明可用的视频效果选项并展示如何使用它们。

{{% alert color="primary" %}} 

请参阅：
- [在 C# 中使用动画增强 PowerPoint 演示文稿](https://docs.aspose.com/slides/net/powerpoint-animation/)
- [形状动画](https://docs.aspose.com/slides/net/shape-animation/)
- [在 PowerPoint 中使用 C# 应用形状效果](https://docs.aspose.com/slides/net/shape-effect/)

{{% /alert %}} 

动画和过渡使幻灯片放映更具吸引力，视频亦是如此。让我们为前面示例的演示文稿添加另一张幻灯片和过渡效果：
```c#
 // 添加一个笑脸形状并对其进行动画。
 // ...

 // 添加一个新幻灯片并设置动画过渡。
 ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
 newSlide.Background.Type = BackgroundType.OwnBackground;
 newSlide.Background.FillFormat.FillType = FillType.Solid;
 newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
 newSlide.SlideShowTransition.Type = TransitionType.Push;
```


Aspose.Slides 还支持文本动画。在本例中，我们对对象上的段落进行动画，使它们依次出现，每个段落之间有一秒的延迟：
```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 添加文本和动画。
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

    // 配置 ffmpeg 二进制文件夹。请参阅此页面: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // 将帧转换为 webm 视频。
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```


## **视频转换类**

为了实现 PowerPoint 到视频的转换任务，Aspose.Slides for .NET 提供了 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) 和 [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) 类。

`PresentationAnimationsGenerator` 通过构造函数允许您设置视频的帧大小（后续将创建）以及 FPS（每秒帧数）值。如果传入演示文稿实例，它会使用其 `Presentation.SlideSize`，并生成供 [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) 使用的动画。

当动画生成时，会为每个后续动画触发 `NewAnimation` 事件，事件包含一个 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/) 参数。该类表示单个动画的播放器。

要使用 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/)，您可以通过其 `Duration` 属性（获取动画的完整持续时间）和 `SetTimePosition` 方法进行操作。每个动画位置的设定范围为 *0 到 Duration*，随后 `GetFrame` 方法返回表示该时间点动画状态的 Bitmap。
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 添加一个笑脸形状并为其设置动画。
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

            animationPlayer.SetTimePosition(0);          // 初始动画状态。
            Bitmap bitmap = animationPlayer.GetFrame();  // 初始动画状态位图。

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // 动画的最终状态。
            Bitmap lastBitmap = animationPlayer.GetFrame();             // 动画的最后一帧。
            lastBitmap.Save("last.png");
        };
    }
}
```


若希望一次播放演示文稿中的所有动画，使用 [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) 类。该类在构造函数中接受一个 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) 实例和一个 FPS 值，然后为所有动画调用 `FrameTick` 事件以播放它们：
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


随后可以将生成的帧编译为视频。请参阅 [将 PowerPoint 演示文稿转换为视频](/slides/zh/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video) 部分。

## **受支持的动画和效果**

在使用 Aspose.Slides for .NET 将 PowerPoint 演示文稿转换为视频时，了解输出中支持哪些动画和效果非常重要。Aspose.Slides 支持多种常见的进入、退出和强调效果，例如淡入、飞入、缩放和旋转。但某些高级或自定义动画可能无法完整保留，或在最终视频中表现不同。本节概述了受支持的动画和效果。

**进入（Entrance）**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![不支持](x.png) | ![支持](v.png) |
| **Fade** | ![支持](v.png) | ![支持](v.png) |
| **Fly In** | ![支持](v.png) | ![支持](v.png) |
| **Float In** | ![支持](v.png) | ![支持](v.png) |
| **Split** | ![支持](v.png) | ![支持](v.png) |
| **Wipe** | ![支持](v.png) | ![支持](v.png) |
| **Shape** | ![支持](v.png) | ![支持](v.png) |
| **Wheel** | ![支持](v.png) | ![支持](v.png) |
| **Random Bars** | ![支持](v.png) | ![支持](v.png) |
| **Grow & Turn** | ![不支持](x.png) | ![支持](v.png) |
| **Zoom** | ![支持](v.png) | ![支持](v.png) |
| **Swivel** | ![支持](v.png) | ![支持](v.png) |
| **Bounce** | ![支持](v.png) | ![支持](v.png) |

**强调（Emphasis）**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![不支持](x.png) | ![支持](v.png) |
| **Color Pulse** | ![不支持](x.png) | ![支持](v.png) |
| **Teeter** | ![支持](v.png) | ![支持](v.png) |
| **Spin** | ![支持](v.png) | ![支持](v.png) |
| **Grow/Shrink** | ![不支持](x.png) | ![支持](v.png) |
| **Desaturate** | ![不支持](x.png) | ![支持](v.png) |
| **Darken** | ![不支持](x.png) | ![支持](v.png) |
| **Lighten** | ![不支持](x.png) | ![支持](v.png) |
| **Transparency** | ![不支持](x.png) | ![支持](v.png) |
| **Object Color** | ![不支持](x.png) | ![支持](v.png) |
| **Complementary Color** | ![不支持](x.png) | ![支持](v.png) |
| **Line Color** | ![不支持](x.png) | ![支持](v.png) |
| **Fill Color** | ![不支持](x.png) | ![支持](v.png) |

**退出（Exit）**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![不支持](x.png) | ![支持](v.png) |
| **Fade** | ![支持](v.png) | ![支持](v.png) |
| **Fly Out** | ![支持](v.png) | ![支持](v.png) |
| **Float Out** | ![支持](v.png) | ![支持](v.png) |
| **Split** | ![支持](v.png) | ![支持](v.png) |
| **Wipe** | ![支持](v.png) | ![支持](v.png) |
| **Shape** | ![支持](v.png) | ![支持](v.png) |
| **Random Bars** | ![支持](v.png) | ![支持](v.png) |
| **Shrink & Turn** | ![不支持](x.png) | ![支持](v.png) |
| **Zoom** | ![支持](v.png) | ![支持](v.png) |
| **Swivel** | ![支持](v.png) | ![支持](v.png) |
| **Bounce** | ![支持](v.png) | ![支持](v.png) |

**运动路径（Motion Paths）**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![支持](v.png) | ![支持](v.png) |
| **Arcs** | ![支持](v.png) | ![支持](v.png) |
| **Turns** | ![支持](v.png) | ![支持](v.png) |
| **Shapes** | ![支持](v.png) | ![支持](v.png) |
| **Loops** | ![支持](v.png) | ![支持](v.png) |
| **Custom Path** | ![支持](v.png) | ![支持](v.png) |

## **受支持的幻灯片过渡效果**

幻灯片过渡效果在视频中创建平滑且视觉上悦目的幻灯片切换中起关键作用。Aspose.Slides for .NET 支持多种常用的过渡效果，以帮助在转换过程中保留原始演示的流畅性和风格。本节重点介绍转换过程中受支持的过渡效果。

**细腻（Subtle）**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![不支持](x.png) | ![支持](v.png) |
| **Fade** | ![支持](v.png) | ![支持](v.png) |
| **Push** | ![支持](v.png) | ![支持](v.png) |
| **Pull** | ![支持](v.png) | ![支持](v.png) |
| **Wipe** | ![支持](v.png) | ![支持](v.png) |
| **Split** | ![支持](v.png) | ![支持](v.png) |
| **Reveal** | ![不支持](x.png) | ![支持](v.png) |
| **Random Bars** | ![支持](v.png) | ![支持](v.png) |
| **Shape** | ![不支持](x.png) | ![支持](v.png) |
| **Uncover** | ![不支持](x.png) | ![支持](v.png) |
| **Cover** | ![支持](v.png) | ![支持](v.png) |
| **Flash** | ![支持](v.png) | ![支持](v.png) |
| **Strips** | ![支持](v.png) | ![支持](v.png) |

**激动（Exciting）**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![不支持](x.png) | ![支持](v.png) |
| **Drape** | ![不支持](x.png) | ![支持](v.png) |
| **Curtains** | ![不支持](x.png) | ![支持](v.png) |
| **Wind** | ![不支持](x.png) | ![支持](v.png) |
| **Prestige** | ![不支持](x.png) | ![支持](v.png) |
| **Fracture** | ![不支持](x.png) | ![支持](v.png) |
| **Crush** | ![不支持](x.png) | ![支持](v.png) |
| **Peel Off** | ![不支持](x.png) | ![支持](v.png) |
| **Page Curl** | ![不支持](x.png) | ![支持](v.png) |
| **Airplane** | ![不支持](x.png) | ![支持](v.png) |
| **Origami** | ![不支持](x.png) | ![支持](v.png) |
| **Dissolve** | ![支持](v.png) | ![支持](v.png) |
| **Checkerboard** | ![不支持](x.png) | ![支持](v.png) |
| **Blinds** | ![不支持](x.png) | ![支持](v.png) |
| **Clock** | ![支持](v.png) | ![支持](v.png) |
| **Ripple** | ![不支持](x.png) | ![支持](v.png) |
| **Honeycomb** | ![不支持](x.png) | ![支持](v.png) |
| **Glitter** | ![不支持](x.png) | ![支持](v.png) |
| **Vortex** | ![不支持](x.png) | ![支持](v.png) |
| **Shred** | ![不支持](x.png) | ![支持](v.png) |
| **Switch** | ![不支持](x.png) | ![支持](v.png) |
| **Flip** | ![不支持](x.png) | ![支持](v/png) |
| **Gallery** | ![不支持](x.png) | ![支持](v.png) |
| **Cube** | ![不支持](x.png) | ![支持](v.png) |
| **Doors** | ![不支持](x.png) | ![支持](v.png) |
| **Box** | ![不支持](x.png) | ![支持](v.png) |
| **Comb** | ![不支持](x.png) | ![支持](v.png) |
| **Zoom** | ![支持](v.png) | ![支持](v.png) |
| **Random** | ![不支持](x.png) | ![支持](v.png) |

**动态内容（Dynamic Content）**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![不支持](x.png) | ![支持](v.png) |
| **Ferris Wheel** | ![支持](v.png) | ![支持](v.png) |
| **Conveyor** | ![不支持](x.png) | ![支持](v.png) |
| **Rotate** | ![不支持](x.png) | ![支持](v.png) |
| **Orbit** | ![不支持](x.png) | ![支持](v.png) |
| **Fly Through** | ![支持](v.png) | ![支持](v.png) |

## **常见问题解答（FAQ）**

**是否可以转换受密码保护的演示文稿？**

是的，Aspose.Slides for .NET 支持处理受密码保护的演示文稿。处理此类文件时，需要提供正确的密码，以便库能够访问演示文稿的内容。

**Aspose.Slides for .NET 是否支持在云解决方案中使用？**

是的，Aspose.Slides for .NET 可以集成到云应用和服务中。该库专为服务器环境设计，确保在批量文件处理时具备高性能和可扩展性。

**转换过程中对演示文稿的大小是否有限制？**

Aspose.Slides for .NET 能够处理几乎任意大小的演示文稿。然而，在处理特别大的文件时，可能需要额外的系统资源，通常建议对演示文稿进行优化以提升性能。