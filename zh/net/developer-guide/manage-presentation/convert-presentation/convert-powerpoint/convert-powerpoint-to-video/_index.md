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
- 演示文稿转视频
- PPT 转视频
- PPTX 转视频
- PowerPoint 转 MP4
- 演示文稿转 MP4
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
description: "了解如何在 .NET 中将 PowerPoint 演示文稿转换为视频。发现示例 C# 代码和自动化技术，以简化您的工作流。"
---

## **概述**

将 PowerPoint 或 OpenDocument 演示文稿转换为视频，您将获得：

**提升可访问性：** 所有设备，无论平台如何，默认都配备视频播放器，相较于传统演示文稿应用，用户打开或播放视频更为方便。

**更广的受众：** 视频让您能够接触更大的受众，并以更具吸引力的形式呈现信息。调查和统计显示，人们更倾向于观看和消费视频内容，而非其他形式，这使您的信息更具冲击力。

{{% alert color="primary" %}} 
查看我们的 [**PowerPoint 转视频在线转换器**](https://products.aspose.app/slides/video) ，因为它提供了本文所述过程的实时有效实现。
{{% /alert %}} 

在 Aspose.Slides for .NET 中，我们实现了将演示文稿转换为视频的支持。

* 使用 Aspose.Slides for .NET 按指定帧率 (FPS) 从演示文稿幻灯片生成帧。
* 然后，使用诸如 ffmpeg 的第三方工具将这些帧合成为视频。

## **将 PowerPoint 演示文稿转换为视频**

1. 使用 `dotnet add package` 命令将 Aspose.Slides 和 FFMpegCore 库添加到项目中：
   * 运行 `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * 运行 `dotnet add package FFMpegCore --version 4.8.0`
2. 从 [此处](https://ffmpeg.org/download.html) 下载 ffmpeg。
3. FFMpegCore 需要您指定已下载 ffmpeg 的路径（例如，解压到 “C:\tools\ffmpeg”）：  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```

4. 运行 PowerPoint 转视频的转换代码。

此 C# 代码演示如何将包含形状和两个动画效果的演示文稿转换为视频：
```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // 将使用我们之前提取到 C:\tools\ffmpeg 的 FFmpeg 二进制文件。
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 添加一个笑脸形状，然后对其进行动画。
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

    // 配置 ffmpeg 二进制文件夹。参见此页面：https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // 将帧转换为 webm 视频。
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```


## **视频效果**

当使用 Aspose.Slides for .NET 将 PowerPoint 演示文稿转换为视频时，您可以应用各种视频效果来提升输出的视觉质量。这些效果通过添加平滑过渡、动画及其他视觉元素，允许您控制最终视频中幻灯片的外观。本节说明可用的视频效果选项并展示如何应用它们。

{{% alert color="primary" %}} 
请参阅：
- [使用 C# 对 PowerPoint 演示文稿进行动画增强](https://docs.aspose.com/slides/net/powerpoint-animation/)
- [形状动画](https://docs.aspose.com/slides/net/shape-animation/)
- [在 PowerPoint 中使用 C# 应用形状效果](https://docs.aspose.com/slides/net/shape-effect/)
{{% /alert %}} 

动画和过渡使幻灯片放映更具吸引力和趣味性——视频亦是如此。让我们为前面的演示文稿代码添加另一张幻灯片和过渡效果：
```c#
// 添加一个笑脸形状并为其添加动画。
// ...

// 添加一个新幻灯片以及动画切换。
ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
newSlide.Background.Type = BackgroundType.OwnBackground;
newSlide.Background.FillFormat.FillType = FillType.Solid;
newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
newSlide.SlideShowTransition.Type = TransitionType.Push;
```


Aspose.Slides 还支持文本动画。在本例中，我们对对象上的段落进行动画处理，使其依次出现，每个段落之间有一秒的延迟：
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

    // 配置 ffmpeg 二进制文件夹。参见此页面：https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // 将帧转换为 webm 视频。
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```



## **视频转换类**

为实现 PowerPoint 转视频的任务，Aspose.Slides for .NET 提供了 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) 和 [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) 类。

`PresentationAnimationsGenerator` 允许您通过构造函数设置视频的帧大小（稍后将创建）和 FPS（每秒帧数）值。如果传入演示文稿实例，它的 `Presentation.SlideSize` 将被使用，并生成供 [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) 使用的动画。

当生成动画时，会为每个后续动画触发 `NewAnimation` 事件，事件包含一个 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/) 参数。该类表示单个动画的播放器。

要使用 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/)，您可以通过 `Duration` 属性（返回动画的完整时长）和 `SetTimePosition` 方法来操作。每个动画位置在 *0 到 duration* 范围内设置，随后 `GetFrame` 方法返回表示该时间点动画状态的 Bitmap。
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

            animationPlayer.SetTimePosition(0);          // 初始动画状态。
            Bitmap bitmap = animationPlayer.GetFrame();  // 初始动画状态的位图。

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // 动画的最终状态。
            Bitmap lastBitmap = animationPlayer.GetFrame();             // 动画的最后一帧。
            lastBitmap.Save("last.png");
        };
    }
}
```


为使演示文稿中的所有动画同时播放，使用 [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) 类。该类在构造函数中接受一个 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) 实例和一个 FPS 值用于效果，然后为所有动画调用 `FrameTick` 事件以播放它们：
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


然后可以将生成的帧编译为视频。参见 [Convert a PowerPoint Presentation to Video](/slides/zh/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video) 部分。

## **支持的动画和效果**

当使用 Aspose.Slides for .NET 将 PowerPoint 演示文稿转换为视频时，了解输出中支持的动画和效果非常重要。Aspose.Slides 支持广泛的常用进入、退出和强调效果，如淡入、飞入、缩放和旋转。但某些高级或自定义动画可能无法完全保留或在最终视频中表现不同。本节概述了支持的动画和效果。

**进入**

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **出现** | ![不支持](x.png) | ![支持](v.png) |
| **淡入** | ![支持](v.png) | ![支持](v.png) |
| **飞入** | ![支持](v.png) | ![支持](v.png) |
| **浮入** | ![支持](v.png) | ![支持](v.png) |
| **分割** | ![支持](v.png) | ![支持](v.png) |
| **擦除** | ![支持](v.png) | ![支持](v.png) |
| **形状** | ![支持](v.png) | ![支持](v.png) |
| **轮形** | ![支持](v.png) | ![支持](v.png) |
| **随机条** | ![支持](v.png) | ![支持](v.png) |
| **生长并旋转** | ![不支持](x.png) | ![支持](v.png) |
| **缩放** | ![支持](v.png) | ![支持](v.png) |
| **摇摆** | ![支持](v.png) | ![支持](v.png) |
| **弹跳** | ![支持](v.png) | ![支持](v.png) |

**强调**

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **脉冲** | ![不支持](x.png) | ![支持](v.png) |
| **颜色脉冲** | ![不支持](x.png) | ![支持](v.png) |
| **摇摆** | ![支持](v.png) | ![支持](v.png) |
| **旋转** | ![支持](v.png) | ![支持](v.png) |
| **放大/缩小** | ![不支持](x.png) | ![支持](v.png) |
| **去饱和** | ![不支持](x.png) | ![支持](v.png) |
| **加暗** | ![不支持](x.png) | ![支持](v.png) |
| **加亮** | ![不支持](x.png) | ![支持](v.png) |
| **透明度** | ![不支持](x.png) | ![支持](v.png) |
| **对象颜色** | ![不支持](x.png) | ![支持](v.png) |
| **补色** | ![不支持](x.png) | ![支持](v.png) |
| **线条颜色** | ![不支持](x.png) | ![支持](v.png) |
| **填充颜色** | ![不支持](x.png) | ![支持](v.png) |

**退出**

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **消失** | ![不支持](x.png) | ![支持](v.png) |
| **淡出** | ![支持](v.png) | ![支持](v.png) |
| **飞出** | ![支持](v.png) | ![支持](v.png) |
| **浮出** | ![支持](v.png) | ![支持](v.png) |
| **分割** | ![支持](v.png) | ![支持](v.png) |
| **擦除** | ![支持](v.png) | ![支持](v.png) |
| **形状** | ![支持](v.png) | ![支持](v.png) |
| **随机条** | ![支持](v.png) | ![支持](v.png) |
| **缩小并旋转** | ![不支持](x.png) | ![支持](v.png) |
| **缩放** | ![支持](v.png) | ![支持](v.png) |
| **摇摆** | ![支持](v.png) | ![支持](v.png) |
| **弹跳** | ![支持](v.png) | ![支持](v.png) |

**运动路径**

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **直线** | ![支持](v.png) | ![支持](v.png) |
| **弧线** | ![支持](v.png) | ![支持](v.png) |
| **转弯** | ![支持](v.png) | ![支持](v.png) |
| **形状** | ![支持](v.png) | ![支持](v.png) |
| **循环** | ![支持](v.png) | ![支持](v.png) |
| **自定义路径** | ![支持](v.png) | ![支持](v.png) |

## **支持的幻灯片切换效果**

幻灯片切换效果在视频中实现平滑且视觉上吸引人的画面切换方面起着重要作用。Aspose.Slides for .NET 支持多种常用切换效果，以帮助在转换过程中保留原始演示文稿的流畅性和风格。

**细微**

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **变形** | ![不支持](x.png) | ![支持](v.png) |
| **淡入** | ![支持](v.png) | ![支持](v.png) |
| **推入** | ![支持](v.png) | ![支持](v.png) |
| **拉出** | ![支持](v.png) | ![支持](v.png) |
| **擦除** | ![支持](v.png) | ![支持](v.png) |
| **分割** | ![支持](v.png) | ![支持](v.png) |
| **揭示** | ![不支持](x.png) | ![支持](v.png) |
| **随机条** | ![支持](v.png) | ![支持](v.png) |
| **形状** | ![不支持](x.png) | ![支持](v.png) |
| **揭开** | ![不支持](x.png) | ![支持](v.png) |
| **覆盖** | ![支持](v.png) | ![支持](v.png) |
| **闪光** | ![支持](v.png) | ![支持](v.png) |
| **条纹** | ![支持](v.png) | ![支持](v.png) |

**激动人心**

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **倾倒** | ![不支持](x.png) | ![支持](v.png) |
| **披覆** | ![不支持](x.png) | ![支持](v.png) |
| **幕帘** | ![不支持](x.png) | ![支持](v.png) |
| **风** | ![不支持](x.png) | ![支持](v.png) |
| **威望** | ![不支持](x.png) | ![支持](v.png) |
| **断裂** | ![不支持](x.png) | ![支持](v.png) |
| **压碎** | ![不支持](x.png) | ![支持](v.png) |
| **剥离** | ![不支持](x.png) | ![支持](v.png) |
| **翻页** | ![不支持](x.png) | ![支持](v.png) |
| **飞机** | ![不支持](x.png) | ![支持](v.png) |
| **折纸** | ![不支持](x.png) | ![支持](v.png) |
| **溶解** | ![支持](v.png) | ![支持](v.png) |
| **棋盘** | ![不支持](x.png) | ![支持](v.png) |
| **百叶窗** | ![不支持](x.png) | ![支持](v.png) |
| **时钟** | ![支持](v.png) | ![支持](v.png) |
| **波纹** | ![不支持](x.png) | ![支持](v.png) |
| **蜂窝** | ![不支持](x.png) | ![支持](v.png) |
| **闪光** | ![不支持](x.png) | ![支持](v.png) |
| **漩涡** | ![不支持](x.png) | ![支持](v.png) |
| **撕碎** | ![不支持](x.png) | ![支持](v.png) |
| **切换** | ![不支持](x.png) | ![支持](v.png) |
| **翻转** | ![不支持](x.png) | ![支持](v.png) |
| **画廊** | ![不支持](x.png) | ![支持](v.png) |
| **立方体** | ![不支持](x.png) | ![支持](v.png) |
| **门** | ![不支持](x.png) | ![支持](v.png) |
| **盒子** | ![不支持](x.png) | ![支持](v.png) |
| **梳子** | ![不支持](x.png) | ![支持](v.png) |
| **缩放** | ![支持](v.png) | ![支持](v.png) |
| **随机** | ![不支持](x.png) | ![支持](v.png) |

**动态内容**

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **平移** | ![不支持](x.png) | ![支持](v.png) |
| **摩天轮** | ![支持](v.png) | ![支持](v.png) |
| **输送带** | ![不支持](x.png) | ![支持](v.png) |
| **旋转** | ![不支持](x.png) | ![支持](v.png) |
| **轨道** | ![不支持](x.png) | ![支持](v.png) |
| **穿越** | ![支持](v.png) | ![支持](v.png) |

## **常见问题**

**是否可以转换受密码保护的演示文稿？**

是的，Aspose.Slides for .NET 支持处理受密码保护的演示文稿。在处理此类文件时，您需要提供正确的密码，以便库能够访问演示文稿的内容。

**Aspose.Slides for .NET 是否支持在云解决方案中使用？**

是的，Aspose.Slides for .NET 可集成到云应用和服务中。该库专为服务器环境设计，能够在批量文件处理时提供高性能和可伸缩性。

**在转换过程中对演示文稿的大小是否有限制？**

Aspose.Slides for .NET 能够处理几乎任意大小的演示文稿。不过，在处理非常大的文件时，可能需要额外的系统资源，通常建议对演示文稿进行优化以提升性能。