---
title: 将 PowerPoint 转换为视频
type: docs
weight: 130
url: /zh/androidjava/convert-powerpoint-to-video/
keywords: "将 PowerPoint 转换为视频, PPT, PPTX, 演示文稿, 视频, MP4, PPT 转视频, PPT 转 MP4, Java, Aspose.Slides"
description: "在 Java 中将 PowerPoint 转换为视频"
---

通过将您的 PowerPoint 演示文稿转换为视频，您可以获得

* **可访问性增强：** 所有设备（无论平台）默认都配备视频播放器，相比之下，演示文稿打开应用程序更加方便，因此用户更容易打开或播放视频。
* **更广泛的覆盖面：** 通过视频，您可以接触到广大受众，并向他们传递在演示文稿中可能显得乏味的信息。大多数调查和统计数据显示，人们观看和消费视频的频率高于其他形式的内容，他们通常更喜欢这种内容。

{{% alert color="primary" %}} 

您可能想查看我们的 [**在线 PowerPoint 转视频转换器**](https://products.aspose.app/slides/conversion/ppt-to-word)，因为它是一个实时有效的实现，演示了此处描述的过程。

{{% /alert %}} 

## **Aspose.Slides 中的 PowerPoint 转视频转换**

在 [Aspose.Slides 22.11](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-22-11-release-notes/) 版本中，我们实现了演示文稿到视频转换的支持。

* 使用 **Aspose.Slides** 生成一组帧（来自演示文稿幻灯片），它们对应于特定的 FPS（每秒帧数）
* 使用第三方工具，例如 **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper))，根据帧创建视频。

### **将 PowerPoint 转换为视频**

1. 将此添加到您的 POM 文件中：
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. 在 [这里](https://ffmpeg.org/download.html) 下载 ffmpeg。

4. 运行 PowerPoint 转视频的 Java 代码。

以下 Java 代码演示了如何将包含一个图形和两个动画效果的演示文稿转换为视频：

```java
Presentation presentation = new Presentation();
try {
    // 添加一个笑脸形状并动画
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // 配置 ffmpeg 二进制文件夹。请参见此页面： https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **视频效果**

您可以为幻灯片上的对象应用动画，并在幻灯片之间使用过渡效果。

{{% alert color="primary" %}} 

您可能想查看以下文章：[PowerPoint 动画](https://docs.aspose.com/slides/androidjava/powerpoint-animation/)、[形状动画](https://docs.aspose.com/slides/androidjava/shape-animation/) 和 [形状效果](https://docs.aspose.com/slides/androidjava/shape-effect/)。

{{% /alert %}} 

动画和过渡使幻灯片放映变得更加引人入胜，同样适用于视频。让我们为之前的演示文稿添加另一张幻灯片和过渡：

```java
// 添加一个笑脸形状并动画

// ...

// 添加一张新幻灯片和动画过渡

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides 还支持文本的动画。因此，我们可以将段落动画化，使其依次出现（延迟设置为一秒）：

```java
Presentation presentation = new Presentation();
try {
    // 添加文本和动画
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides for Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("将 PowerPoint 演示文稿中的文本转换为视频"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Portion("逐段落出现"));
    IParagraphCollection paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new Paragraph());

    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effect1 = mainSequence.addEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect2 = mainSequence.addEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect3 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect4 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);
    effect4.getTiming().setTriggerDelayTime(1f);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // 配置 ffmpeg 二进制文件夹。请参见此页面： https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **视频转换类**

为了让您能够执行 PowerPoint 到视频转换任务，Aspose.Slides 提供了 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/) 和 [PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/) 类。

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/) 允许您通过其构造函数设置视频的帧大小（稍后将创建的）。如果您传递演示文稿的实例，则会使用 `Presentation.SlideSize`，并生成 [PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/) 使用的动画。

当动画生成时，每个后续动画都会生成一个 `NewAnimation` 事件，该事件有 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/) 参数。后者是一个表示单个动画播放器的类。

要与 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/) 一起使用，使用 [Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--)（动画的总持续时间）属性和 [SetTimePosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) 方法。每个动画位置在 *0 到持续时间* 范围内设置，然后 `GetFrame` 方法将返回一个 BufferedImage，该图像对应于该时刻的动画状态：

```java
Presentation presentation = new Presentation();
try {
    // 添加一个笑脸形状并动画
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer ->
        {
            System.out.println(String.format("动画的总持续时间：%f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0); // 初始动画状态
            try {
                // 初始动画状态位图
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // 动画的最终状态
            try {
                // 动画的最后一帧
                animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        });
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

要使演示文稿中的所有动画同时播放，使用 [PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/) 类。该类在其构造函数中接受 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/) 实例和效果的 FPS，然后调用 `FrameTick` 事件以播放所有动画：

```java
Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

然后可以将生成的帧汇编成视频。请参见 [将 PowerPoint 转换为视频](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video) 部分。

## **支持的动画和效果**

**进入效果**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **出现** | ![不支持](x.png) | ![支持](v.png) |
| **淡入** | ![支持](v.png) | ![支持](v.png) |
| **飞入** | ![支持](v.png) | ![支持](v.png) |
| **浮入** | ![支持](v.png) | ![支持](v.png) |
| **分裂** | ![支持](v.png) | ![支持](v.png) |
| **擦除** | ![支持](v.png) | ![支持](v.png) |
| **形状** | ![支持](v.png) | ![支持](v.png) |
| **轮子** | ![支持](v.png) | ![支持](v.png) |
| **随机条** | ![支持](v.png) | ![支持](v.png) |
| **增长和翻转** | ![不支持](x.png) | ![支持](v.png) |
| **缩放** | ![支持](v.png) | ![支持](v.png) |
| **旋转** | ![支持](v.png) | ![支持](v.png) |
| **反弹** | ![支持](v.png) | ![支持](v.png) |

**强调效果**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **脉动** | ![不支持](x.png) | ![支持](v.png) |
| **颜色脉动** | ![不支持](x.png) | ![支持](v.png) |
| **摇晃** | ![支持](v.png) | ![支持](v.png) |
| **旋转** | ![支持](v.png) | ![支持](v.png) |
| **增长/缩小** | ![不支持](x.png) | ![支持](v.png) |
| **脱色** | ![不支持](x.png) | ![支持](v.png) |
| **变暗** | ![不支持](x.png) | ![支持](v.png) |
| **变亮** | ![不支持](x.png) | ![支持](v.png) |
| **透明度** | ![不支持](x.png) | ![支持](v.png) |
| **物体颜色** | ![不支持](x.png) | ![支持](v.png) |
| **互补色** | ![不支持](x.png) | ![支持](v.png) |
| **线条颜色** | ![不支持](x.png) | ![支持](v.png) |
| **填充颜色** | ![不支持](x.png) | ![支持](v.png) |

**退出效果**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **消失** | ![不支持](x.png) | ![支持](v.png) |
| **淡出** | ![支持](v.png) | ![支持](v.png) |
| **飞出** | ![支持](v.png) | ![支持](v.png) |
| **浮出** | ![支持](v.png) | ![支持](v.png) |
| **分裂** | ![支持](v.png) | ![支持](v.png) |
| **擦除** | ![支持](v.png) | ![支持](v.png) |
| **形状** | ![支持](v.png) | ![支持](v.png) |
| **随机条** | ![支持](v.png) | ![支持](v.png) |
| **缩小和翻转** | ![不支持](x.png) | ![支持](v.png) |
| **缩放** | ![支持](v.png) | ![支持](v.png) |
| **旋转** | ![支持](v.png) | ![支持](v.png) |
| **反弹** | ![支持](v.png) | ![支持](v.png) |

**运动路径**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **直线** | ![支持](v.png) | ![支持](v.png) |
| **弧线** | ![支持](v.png) | ![支持](v.png) |
| **转弯** | ![支持](v.png) | ![支持](v.png) |
| **形状** | ![支持](v.png) | ![支持](v.png) |
| **循环** | ![支持](v.png) | ![支持](v.png) |
| **自定义路径** | ![支持](v.png) | ![支持](v.png) |