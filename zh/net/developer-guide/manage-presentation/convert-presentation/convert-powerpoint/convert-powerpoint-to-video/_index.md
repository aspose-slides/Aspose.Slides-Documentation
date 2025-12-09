---
title: 在 .NET 中将 PowerPoint 演示文稿转换为视频
linktitle: PowerPoint 转视频
type: docs
weight: 130
url: /zh/net/convert-powerpoint-to-video/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 PPT
- 转换 PPTX
- PowerPoint 转视频
- 演示文稿 转视频
- PPT 转视频
- PPTX 转视频
- PowerPoint 转 MP4
- 演示文稿 转 MP4
- PPT 转 MP4
- PPTX 转 MP4
- 将 PPT 保存为 MP4
- 将 PPTX 保存为 MP4
- 导出 PPT 为 MP4
- 导出 PPTX 为 MP4
- 视频转换
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "了解如何在 .NET 中将 PowerPoint 演示文稿转换为视频。探索示例 C# 代码和自动化技术，以简化您的工作流程。"
---

## **概述**

通过将 PowerPoint 或 OpenDocument 演示文稿转换为视频，您可以获得：

**提升可访问性：** 所有设备，无论平台如何，默认都配备视频播放器，相比传统演示应用，用户打开或播放视频更为便捷。

**更广的受众覆盖：** 视频让您能够接触更大的观众群，并以更具吸引力的形式呈现信息。调查和统计显示，人们更倾向于观看和消费视频内容，而非其他形式，这使您的信息更具冲击力。

{{% alert color="primary" %}} 

查看我们的[**PowerPoint 转视频在线转换器**](https://products.aspose.app/slides/video)，因为它提供了本文所述过程的实时且有效的实现。

{{% /alert %}} 

在 Aspose.Slides for .NET 中，我们实现了将演示文稿转换为视频的支持。

* 使用 Aspose.Slides for .NET 按指定帧率 (FPS) 从演示文稿幻灯片生成帧。
* 然后，使用诸如 ffmpeg 的第三方工具将这些帧编译成视频。

## **将 PowerPoint 演示文稿转换为视频**

1. 使用 `dotnet add package` 命令将 Aspose.Slides 和 FFMpegCore 库添加到您的项目中：
   * 运行 `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * 运行 `dotnet add package FFMpegCore --version 4.8.0`
2. 从[此处](https://ffmpeg.org/download.html) 下载 ffmpeg。
3. FFMpegCore 需要您指定已下载 ffmpeg 的路径（例如，解压到 "C:\tools\ffmpeg"）：  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```

4. 运行 PowerPoint 转视频的转换代码。

以下 C# 代码演示了如何将包含形状和两个动画效果的演示文稿转换为视频：  
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

    // 配置 ffmpeg 二进制文件夹。请参阅此页面：https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // 将帧转换为 webm 视频。
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```


## **视频效果**

使用 Aspose.Slides for .NET 将 PowerPoint 演示文稿转换为视频时，您可以应用各种视频效果以提升输出的视觉质量。这些效果通过添加平滑的转场、动画及其他视觉元素，帮助您控制最终视频中幻灯片的呈现方式。本节介绍可用的视频效果选项并展示如何应用它们。

{{% alert color="primary" %}} 

参见：
- [在 C# 中使用动画增强 PowerPoint 演示文稿](https://docs.aspose.com/slides/net/powerpoint-animation/)
- [形状动画](https://docs.aspose.com/slides/net/shape-animation/)
- [在 PowerPoint 中使用 C# 应用形状效果](https://docs.aspose.com/slides/net/shape-effect/)

{{% /alert %}} 

动画和转场使幻灯片放映更具吸引力和趣味性——对视频同样适用。让我们为前面的演示文稿代码添加另一张幻灯片和转场：  
```c#
// 添加一个笑脸形状并为其添加动画.
// ...

// 添加一个新幻灯片并使用动画过渡.
ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
newSlide.Background.Type = BackgroundType.OwnBackground;
newSlide.Background.FillFormat.FillType = FillType.Solid;
newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
newSlide.SlideShowTransition.Type = TransitionType.Push;
```


Aspose.Slides 也支持文本动画。在本示例中，我们为对象上的段落添加动画，使其依次出现，每个段落之间有一秒的延迟：  
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

    // 配置 ffmpeg 二进制文件夹。请参阅此页面：https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // 将帧转换为 webm 视频。
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```


## **视频转换类**

为了实现 PowerPoint 转视频的任务，Aspose.Slides for .NET 提供了 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) 和 [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) 类。

`PresentationAnimationsGenerator` 允许您通过构造函数设置视频的帧尺寸（稍后创建）以及 FPS（每秒帧数）值。如果传入演示文稿实例，将使用其 `Presentation.SlideSize`，并生成供 [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) 使用的动画。

当生成动画时，会为每个后续动画触发 `NewAnimation` 事件，并包含一个 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/) 参数。该类表示单个动画的播放器。

要使用 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/)，您需要使用 [Duration](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/duration/) 属性（提供动画的完整时长）以及 [SetTimePosition](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/) 方法。每个动画位置在 *0 到 duration* 范围内设置，随后 `GetFrame` 方法返回表示该时间点动画状态的 Bitmap。  
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 添加一个笑脸形状并为其添加动画。
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

            animationPlayer.SetTimePosition(0);          // 动画的初始状态。
            Bitmap bitmap = animationPlayer.GetFrame();  // 动画初始状态的位图。

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // 动画的最终状态。
            Bitmap lastBitmap = animationPlayer.GetFrame();             // 动画的最后一帧。
            lastBitmap.Save("last.png");
        };
    }
}
```


要让演示文稿中的所有动画同时播放，使用 [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) 类。该类在构造函数中接受一个 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) 实例和用于效果的 FPS 值，然后调用 `FrameTick` 事件以播放所有动画：  
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


然后可以将生成的帧编译成视频。请参阅 [Convert a PowerPoint Presentation to Video](/slides/zh/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video) 部分。

## **受支持的动画和效果**

使用 Aspose.Slides for .NET 将 PowerPoint 演示文稿转换为视频时，了解输出中支持哪些动画和效果非常重要。Aspose.Slides 支持广泛的常见进入、退出和强调效果，如淡入、飞入、缩放和旋转。然而，某些高级或自定义动画可能无法完整保留，或在最终视频中呈现方式不同。本节概述了受支持的动画和效果。

**进入**：

| 动画类型 | Aspose.Slides | PowerPoint |
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

**强调**：

| 动画类型 | Aspose.Slides | PowerPoint |
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

**退出**：

| 动画类型 | Aspose.Slides | PowerPoint |
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

**运动路径**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **受支持的幻灯片转场效果**

幻灯片转场效果在视频中实现平滑且视觉上吸引人的幻灯片切换方面起着重要作用。Aspose.Slides for .NET 支持多种常用转场效果，以帮助保留原始演示的流程和风格。本节重点介绍转换过程中受支持的转场效果。

**细腻**：

| 动画类型 | Aspose.Slides | PowerPoint |
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

**激动人心**：

| 动画类型 | Aspose.Slides | PowerPoint |
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

**动态内容**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **常见问题**

**是否可以转换受密码保护的演示文稿？**

是的，Aspose.Slides for .NET 支持处理受密码保护的演示文稿。在处理此类文件时，您需要提供正确的密码，以便库能够访问演示文稿的内容。

**Aspose.Slides for .NET 是否支持在云解决方案中使用？**

是的，Aspose.Slides for .NET 可以集成到云应用和服务中。该库专为服务器环境设计，能够确保高性能和可扩展性，以批量处理文件。

**在转换过程中，对演示文稿的大小是否有限制？**

Aspose.Slides for .NET 能够处理几乎任意大小的演示文稿。然而，在处理非常大的文件时，可能需要额外的系统资源，建议对演示文稿进行优化以提升性能。