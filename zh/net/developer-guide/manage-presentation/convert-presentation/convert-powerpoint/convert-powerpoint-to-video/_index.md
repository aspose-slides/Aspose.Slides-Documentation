---
title: 将 PowerPoint 转换为视频
type: docs
weight: 130
url: /zh/net/convert-powerpoint-to-video/
keywords: "将 PowerPoint 转换为视频, PPT, PPTX, 演示文稿, 视频, MP4, PPT 转换为视频, PPT 转换为 MP4, C#, Csharp, .NET, Aspose.Slides"
description: "在 C# 或 .NET 中将 PowerPoint 转换为视频"
---

通过将您的 PowerPoint 演示文稿转换为视频，您可以获得

* **提高可及性:** 所有设备（无论平台如何）默认都配备视频播放器，而不是演示文稿打开应用程序，因此用户更容易打开或播放视频。
* **更广泛的覆盖:** 通过视频，您可以接触到大型观众，并针对他们提供可能在演示中显得乏味的信息。大多数调查和统计数据表明，人们观看和消费视频的频率高于其他内容形式，并且通常更喜欢此类内容。

{{% alert color="primary" %}} 

您可能希望查看我们的 [**在线 PowerPoint 转视频转换器**](https://products.aspose.app/slides/conversion/ppt-to-word)，因为它是对这里描述的过程的有效实时实现。

{{% /alert %}} 

## **在 Aspose.Slides 中将 PowerPoint 转换为视频**

在 [Aspose.Slides 22.11](https://docs.aspose.com/slides/net/aspose-slides-for-net-22-11-release-notes/) 中，我们实现了支持演示文稿转视频的功能。

* 使用 Aspose.Slides 生成一组帧（来自演示文稿幻灯片），以对应特定的 FPS（每秒帧数）
* 使用第三方工具，如 FFMpegCore (ffmpeg)，根据帧创建视频。

### **将 PowerPoint 转换为视频**

1. 使用 dotnet 添加包命令将 Aspose.Slides 和 FFMpegCore 库添加到您的项目中：
   * 运行 `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * 运行 `dotnet add package FFMpegCore --version 4.8.0`
2. 在 [这里](https://ffmpeg.org/download.html) 下载 ffmpeg。
3. FFMpegCore 需要您指定下载的 ffmpeg 的路径（例如，解压到 "C:\tools\ffmpeg"）：`GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin",} );`
4. 运行将 PowerPoint 转换为视频的代码。

这个 C# 代码片段展示了如何将包含图像和两个动画效果的演示文稿转换为视频：

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // 将使用我们之前提取到 "c:\tools\ffmpeg" 的 FFmpeg 二进制文件
using Aspose.Slides.Animation;
using (Presentation presentation = new Presentation())

{
    // 添加一个笑脸形状并给它添加动画效果
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

    // 配置 ffmpeg 二进制文件夹。请参阅此页面: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin", });
    // 将帧转换为 webm 视频
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());

}
```

## **视频效果**

您可以对幻灯片上的对象应用动画并在幻灯片之间使用过渡。

{{% alert color="primary" %}} 

您可能想查看这些文章：[PowerPoint 动画](https://docs.aspose.com/slides/net/powerpoint-animation/)、[形状动画](https://docs.aspose.com/slides/net/shape-animation/) 和 [形状效果](https://docs.aspose.com/slides/net/shape-effect/)。

{{% /alert %}} 

动画和过渡使幻灯片放映更加引人入胜和有趣——它们对视频也有同样的效果。让我们为先前的演示文稿添加另一张幻灯片和过渡代码：

```c#
// 添加一个笑脸形状并给它添加动画效果

// ...

// 添加一张新的幻灯片并做动画过渡

ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

newSlide.Background.Type = BackgroundType.OwnBackground;

newSlide.Background.FillFormat.FillType = FillType.Solid;

newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;

newSlide.SlideShowTransition.Type = TransitionType.Push;
```

Aspose.Slides 还支持文本的动画。因此，我们对对象上的段落进行动画处理，使其逐个出现（延迟设置为一秒）：

```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    // 添加文本和动画
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.Portions.Add(new Portion("Aspose Slides for .NET"));
    Paragraph para2 = new Paragraph();
    para2.Portions.Add(new Portion("将 PowerPoint 演示文稿中的文本转换为视频"));

    Paragraph para3 = new Paragraph();
    para3.Portions.Add(new Portion("逐段出现"));
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

    // 将帧转换为视频
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

    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin", });
    // 将帧转换为 webm 视频
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());

}
```

## **视频转换类**

为了使您能够执行 PowerPoint 转视频的转换任务，Aspose.Slides 提供了 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) 和 [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) 类。

PresentationAnimationsGenerator 允许您通过其构造函数设置后续生成的视频的帧大小。如果您传递演示文稿的实例，将使用 `Presentation.SlideSize`，并生成 [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) 使用的动画。

当动画生成时，将为每个随后的动画生成一个 `NewAnimation` 事件，其中包含 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/) 参数。后者是表示单个动画播放器的类。

要与 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/) 交互，将使用 [Duration](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/duration/)（动画的完整持续时间）属性和 [SetTimePosition](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/) 方法。每个动画位置在 *0 到持续时间* 范围内设置，然后 `GetFrame` 方法将返回该时刻的动画状态对应的 Bitmap。

```c#
using (Presentation presentation = new Presentation())
{
    // 添加一个笑脸形状并添加动画
    IAutoShape smile = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    IEffect effectIn = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    {
        animationsGenerator.NewAnimation += animationPlayer =>
        {
            Console.WriteLine($"动画总持续时间: {animationPlayer.Duration}");
            
            animationPlayer.SetTimePosition(0); // 初始动画状态
            Bitmap bitmap = animationPlayer.GetFrame(); // 初始动画状态位图

            animationPlayer.SetTimePosition(animationPlayer.Duration); // 动画的最终状态
            Bitmap lastBitmap = animationPlayer.GetFrame(); // 动画的最后一帧
            lastBitmap.Save("last.png");
        };
    }
}
```

要使演示文稿中的所有动画同时播放，将使用 [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) 类。该类在其构造函数中接受一个 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) 实例和用于效果的 FPS，然后调用 `FrameTick` 事件以播放所有动画：

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

然后可以将生成的帧编译成视频。请参阅 [将 PowerPoint 转换为视频](https://docs.aspose.com/slides/net/convert-powerpoint-to-video/#convert-powerpoint-to-video) 部分。

## **支持的动画和效果**


**进入**:

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **出现** | ![不支持](x.png) | ![支持](v.png) |
| **渐变** | ![支持](v.png) | ![支持](v.png) |
| **飞入** | ![支持](v.png) | ![支持](v.png) |
| **浮入** | ![支持](v.png) | ![支持](v.png) |
| **分裂** | ![支持](v.png) | ![支持](v.png) |
| **擦除** | ![支持](v.png) | ![支持](v.png) |
| **形状** | ![支持](v.png) | ![支持](v.png) |
| **轮子** | ![支持](v.png) | ![支持](v.png) |
| **随机条** | ![支持](v.png) | ![支持](v.png) |
| **放大并旋转** | ![不支持](x.png) | ![支持](v.png) |
| **缩放** | ![支持](v.png) | ![支持](v.png) |
| **旋转** | ![支持](v.png) | ![支持](v.png) |
| **弹跳** | ![支持](v.png) | ![支持](v.png) |


**强调**:

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **脉动** | ![不支持](x.png) | ![支持](v.png) |
| **颜色脉动** | ![不支持](x.png) | ![支持](v.png) |
| **摇摆** | ![支持](v.png) | ![支持](v.png) |
| **旋转** | ![支持](v.png) | ![支持](v.png) |
| **放大/缩小** | ![不支持](x.png) | ![支持](v.png) |
| **去饱和** | ![不支持](x.png) | ![支持](v.png) |
| **变暗** | ![不支持](x.png) | ![支持](v.png) |
| **变亮** | ![不支持](x.png) | ![支持](v.png) |
| **透明度** | ![不支持](x.png) | ![支持](v.png) |
| **对象颜色** | ![不支持](x.png) | ![支持](v.png) |
| **互补色** | ![不支持](x.png) | ![支持](v.png) |
| **线条颜色** | ![不支持](x.png) | ![支持](v.png) |
| **填充颜色** | ![不支持](x.png) | ![支持](v.png) |

**退出**:

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **消失** | ![不支持](x.png) | ![支持](v.png) |
| **渐变** | ![支持](v.png) | ![支持](v.png) |
| **飞出** | ![支持](v.png) | ![支持](v.png) |
| **浮出** | ![支持](v.png) | ![支持](v.png) |
| **分裂** | ![支持](v.png) | ![支持](v.png) |
| **擦除** | ![支持](v.png) | ![支持](v.png) |
| **形状** | ![支持](v.png) | ![支持](v.png) |
| **随机条** | ![支持](v.png) | ![支持](v.png) |
| **缩小并旋转** | ![不支持](x.png) | ![支持](v.png) |
| **缩放** | ![支持](v.png) | ![支持](v.png) |
| **旋转** | ![支持](v.png) | ![支持](v.png) |
| **弹跳** | ![支持](v.png) | ![支持](v.png) |

**运动路径:**

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **线条** | ![支持](v.png) | ![支持](v.png) |
| **弧** | ![支持](v.png) | ![支持](v.png) |
| **转弯** | ![支持](v.png) | ![支持](v.png) |
| **形状** | ![支持](v.png) | ![支持](v.png) |
| **循环** | ![支持](v.png) | ![支持](v.png) |
| **自定义路径** | ![支持](v.png) | ![支持](v.png) |

## **支持的幻灯片过渡效果**

**微妙**:

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **变形** | ![不支持](x.png) | ![支持](v.png) |
| **渐变** | ![支持](v.png) | ![支持](v.png) |
| **推送** | ![支持](v.png) | ![支持](v.png) |
| **拉动** | ![支持](v.png) | ![支持](v.png) |
| **擦除** | ![支持](v.png) | ![支持](v.png) |
| **分裂** | ![支持](v.png) | ![支持](v.png) |
| **揭示** | ![不支持](x.png) | ![支持](v.png) |
| **随机条** | ![支持](v.png) | ![支持](v.png) |
| **形状** | ![不支持](x.png) | ![支持](v.png) |
| **揭开** | ![不支持](x.png) | ![支持](v.png) |
| **覆盖** | ![支持](v.png) | ![支持](v.png) |
| **闪烁** | ![支持](v.png) | ![支持](v.png) |
| **条纹** | ![支持](v.png) | ![支持](v.png) |

**兴奋**:

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **翻倒** | ![不支持](x.png) | ![支持](v.png) |
| **披风** | ![不支持](x.png) | ![支持](v.png) |
| **帘幕** | ![不支持](x.png) | ![支持](v.png) |
| **风** | ![不支持](x.png) | ![支持](v.png) |
| **声望** | ![不支持](x.png) | ![支持](v.png) |
| **破裂** | ![不支持](x.png) | ![支持](v.png) |
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
| **撕裂** | ![不支持](x.png) | ![支持](v.png) |
| **切换** | ![不支持](x.png) | ![支持](v.png) |
| **翻转** | ![不支持](x.png) | ![支持](v.png) |
| **画廊** | ![不支持](x.png) | ![支持](v.png) |
| **立方体** | ![不支持](x.png) | ![支持](v.png) |
| **门** | ![不支持](x.png) | ![支持](v.png) |
| **盒子** | ![不支持](x.png) | ![支持](v.png) |
| **梳子** | ![不支持](x.png) | ![支持](v.png) |
| **缩放** | ![支持](v.png) | ![支持](v.png) |
| **随机** | ![不支持](x.png) | ![支持](v.png) |

**动态内容**:

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **平移** | ![不支持](x.png) | ![支持](v.png) |
| **摩天轮** | ![支持](v.png) | ![支持](v.png) |
| **传送带** | ![不支持](x.png) | ![支持](v.png) |
| **旋转** | ![不支持](x.png) | ![支持](v.png) |
| **轨道** | ![不支持](x.png) | ![支持](v.png) |
| **穿越** | ![支持](v.png) | ![支持](v.png) |