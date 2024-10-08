---
title: 将 PowerPoint 转换为视频
type: docs
weight: 130
url: /java/convert-powerpoint-to-video/
keywords: "转换 PowerPoint, PPT, PPTX, 演示文稿, 视频, MP4, PPT 转视频, PPT 转 MP4, Java, Aspose.Slides"
description: "在 Java 中将 PowerPoint 转换为视频"
---

通过将您的 PowerPoint 演示文稿转换为视频，您可以获得

* **提高可访问性：** 所有设备（无论平台如何）默认配备视频播放器，而不是打开演示文稿的应用程序，因此用户更容易打开或播放视频。
* **更大的受众：** 通过视频，您可以接触到大量观众，并通过信息来吸引他们，这些信息在演示文稿中可能显得乏味。大多数调查和统计数据显示，人们观看和消费视频的频率超过其他内容形式，而且他们通常更喜欢这种内容。

{{% alert color="primary" %}} 

您可能想查看我们的 [**在线 PowerPoint 转视频转换器**](https://products.aspose.app/slides/conversion/ppt-to-word)，因为它是此处描述的过程的实时有效实现。

{{% /alert %}} 

## **Aspose.Slides 中的 PowerPoint 转视频**

在 [Aspose.Slides 22.11](https://docs.aspose.com/slides/java/aspose-slides-for-java-22-11-release-notes/) 中，我们实现了演示文稿转视频的支持。

* 使用 **Aspose.Slides** 生成一组帧（来自演示文稿幻灯片），这些帧对应于一定的帧率（FPS）
* 使用第三方工具，如 **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper))，根据帧创建视频。

### **将 PowerPoint 转换为视频**

1. 将此内容添加到您的 POM 文件中：
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. 在 [这里](https://ffmpeg.org/download.html) 下载 ffmpeg。

4. 运行 PowerPoint 转视频的 Java 代码。

此 Java 代码演示了如何将一个包含图形和两个动画效果的演示文稿转换为视频：

```java
Presentation presentation = new Presentation();
try {
    // 添加一个微笑形状，然后进行动画
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

    // 配置 ffmpeg 二进制文件文件夹。请参见此页面： https://github.com/rosenbjerg/FFMpegCore#installation
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

您可以对幻灯片上的对象应用动画，并在幻灯片之间使用转换。

{{% alert color="primary" %}} 

您可能想查看这些文章：[PowerPoint 动画](https://docs.aspose.com/slides/java/powerpoint-animation/)、[形状动画](https://docs.aspose.com/slides/java/shape-animation/) 和 [形状效果](https://docs.aspose.com/slides/java/shape-effect/)。

{{% /alert %}} 

动画和转换让幻灯片展示变得更具吸引力和趣味性——对视频也有同样的效果。让我们向之前的演示文稿的代码中添加另一张幻灯片和转换：

```java
// 添加一个微笑形状并进行动画

// ...

// 添加一张新幻灯片和动画过渡

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides 还支持文本动画。我们可以对对象上的段落进行动画，它们将依次出现（延迟设定为一秒）：

```java
Presentation presentation = new Presentation();
try {
    // 添加文本和动画
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides for Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("将带文本的 PowerPoint 演示文稿转换为视频"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Portion("逐段落"));
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

    // 配置 ffmpeg 二进制文件文件夹。请参见此页面： https://github.com/rosenbjerg/FFMpegCore#installation
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

为了允许您执行 PowerPoint 到视频转换任务，Aspose.Slides 提供了 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/java/com.aspose.slides/presentationanimationsgenerator/) 和 [PresentationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/presentationplayer/) 类。

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/java/com.aspose.slides/presentationanimationsgenerator/) 允许您通过其构造函数设置视频的帧大小（稍后将创建的）。如果传递演示文稿的实例，则将使用 `Presentation.SlideSize`，并生成 [PresentationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/presentationplayer/) 使用的动画。

生成动画时，将为每个后续动画生成一个 `NewAnimation` 事件，带有 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/) 参数。后者是一个表示单个动画播放器的类。

要使用 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/)，使用 [Duration](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--)（动画的总持续时间）属性和 [SetTimePosition](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) 方法。在 *0 到 duration* 范围内设置每个动画位置，然后 `GetFrame` 方法将返回与该时刻的动画状态相对应的 BufferedImage：

```java
Presentation presentation = new Presentation();
try {
    // 添加一个微笑形状并进行动画
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
            System.out.println(String.format("动画总持续时间: %f", animationPlayer.getDuration()));
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

要使演示文稿中的所有动画同时播放，需要使用 [PresentationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/presentationplayer/) 类。该类接受一个 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/java/com.aspose.slides/presentationanimationsgenerator/) 实例和 FPS 作为构造参数，然后调用 `FrameTick` 事件以播放所有动画：

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

然后生成的帧可以被编译以生成视频。请参见 [将 PowerPoint 转换为视频](https://docs.aspose.com/slides/java/convert-powerpoint-to-video/#convert-powerpoint-to-video) 部分。

## **支持的动画和效果**

**进入**：

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
| **增长与转动** | ![不支持](x.png) | ![支持](v.png) |
| **缩放** | ![支持](v.png) | ![支持](v.png) |
| **旋转** | ![支持](v.png) | ![支持](v.png) |
| **弹跳** | ![支持](v.png) | ![支持](v.png) |

**强调**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **脉冲** | ![不支持](x.png) | ![支持](v.png) |
| **颜色脉冲** | ![不支持](x.png) | ![支持](v.png) |
| **翘曲** | ![支持](v.png) | ![支持](v.png) |
| **旋转** | ![支持](v.png) | ![支持](v.png) |
| **增长/缩小** | ![不支持](x.png) | ![支持](v.png) |
| **去饱和** | ![不支持](x.png) | ![支持](v.png) |
| **加深** | ![不支持](x.png) | ![支持](v.png) |
| **变亮** | ![不支持](x.png) | ![支持](v.png) |
| **透明度** | ![不支持](x.png) | ![支持](v.png) |
| **对象颜色** | ![不支持](x.png) | ![支持](v.png) |
| **互补色** | ![不支持](x.png) | ![支持](v.png) |
| **线条颜色** | ![不支持](x.png) | ![支持](v.png) |
| **填充颜色** | ![不支持](x.png) | ![支持](v.png) |

**退出**：

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
| **缩小与转动** | ![不支持](x.png) | ![支持](v.png) |
| **缩放** | ![支持](v.png) | ![支持](v.png) |
| **旋转** | ![支持](v.png) | ![支持](v.png) |
| **弹跳** | ![支持](v.png) | ![支持](v.png) |

**运动路径：**

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **线条** | ![支持](v.png) | ![支持](v.png) |
| **弧形** | ![支持](v.png) | ![支持](v.png) |
| **转弯** | ![支持](v.png) | ![支持](v.png) |
| **形状** | ![支持](v.png) | ![支持](v.png) |
| **循环** | ![支持](v.png) | ![支持](v.png) |
| **自定义路径** | ![支持](v.png) | ![支持](v.png) |