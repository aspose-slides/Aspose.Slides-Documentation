---
title: 在 Android 上将 PowerPoint 演示文稿转换为视频
linktitle: PowerPoint 转视频
type: docs
weight: 130
url: /zh/androidjava/convert-powerpoint-to-video/
keywords:
- 转换 PowerPoint
- 转换演示文稿
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
- Android
- Java
- Aspose.Slides
description: "了解如何在 Java 中将 PowerPoint 演示文稿转换为视频。发现示例代码和自动化技术，以简化工作流程。"
---

通过将 PowerPoint 演示文稿转换为视频，您可以获得 

* **可访问性提升：** 所有设备（无论平台）默认配备视频播放器，而不是演示文稿打开应用程序，因此用户更容易打开或播放视频。  
* **更广的覆盖面：** 通过视频，您可以触达庞大的受众，并向他们传递在演示文稿中可能显得枯燥的信息。大多数调查和统计显示，人们观看和消费视频的比例高于其他内容形式，而且通常更偏好此类内容。  

{{% alert color="primary" %}} 

您可能想查看我们的 [**PowerPoint 转视频在线转换器**](https://products.aspose.app/slides/conversion/ppt-to-word)，因为它是本文所述过程的实时且有效的实现。  

{{% /alert %}} 

## **Aspose.Slides 中的 PowerPoint 转视频转换**

在 [Aspose.Slides 22.11](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-22-11-release-notes/) 中，我们实现了对演示文稿转视频的支持。

* 使用 **Aspose.Slides** 生成一组帧（来自演示文稿幻灯片），其对应特定的 FPS（每秒帧数）  
* 使用第三方工具，例如 **ffmpeg**（[for java](https://github.com/bramp/ffmpeg-cli-wrapper)），基于这些帧创建视频。  

### **将 PowerPoint 转换为视频**

1. 将以下内容添加到您的 POM 文件中：  
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```


2. 在[此处](https://ffmpeg.org/download.html)下载 ffmpeg。  

4. 运行 PowerPoint 转视频的 Java 代码。  

下面的 Java 代码演示了如何将包含图形和两个动画效果的演示文稿转换为视频：  
```java
Presentation presentation = new Presentation();
try {
    // 添加一个笑脸形状并对其进行动画处理
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

    // 配置 ffmpeg 二进制文件夹。参见此页面: https://github.com/rosenbjerg/FFMpegCore#installation
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

您可以对幻灯片上的对象应用动画并使用幻灯片之间的切换效果。  

{{% alert color="primary" %}} 

您可能想查看以下文章：[PowerPoint 动画](https://docs.aspose.com/slides/androidjava/powerpoint-animation/)、[形状动画](https://docs.aspose.com/slides/androidjava/shape-animation/)、以及[形状效果](https://docs.aspose.com/slides/androidjava/shape-effect/)。  

{{% /alert %}} 

动画和切换让幻灯片放映更具吸引力和趣味性——它们对视频也有同样的作用。让我们为前面的演示文稿的代码添加另一张幻灯片和切换效果：  
```java
// 添加一个笑脸形状并为其添加动画

// ...

// 添加一个新幻灯片并添加动画过渡

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```


Aspose.Slides 也支持文本动画。因此我们对对象上的段落进行动画，使其一个接一个出现（延迟设置为一秒）：  
```java
Presentation presentation = new Presentation();
try {
    // 添加文本和动画
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides for Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("convert PowerPoint Presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Portion("paragraph by paragraph"));
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

    // 配置 ffmpeg 二进制文件夹。参见此页面: https://github.com/rosenbjerg/FFMpegCore#installation
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

为了让您执行 PowerPoint 转视频的任务，Aspose.Slides 提供了 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/) 和 [PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/) 类。

[PresentationAnimationsGenerator] 允许您通过其构造函数设置视频的帧大小（稍后将创建的视频）。如果传入演示文稿实例，将使用 `Presentation.SlideSize`，并生成供 [PresentationPlayer] 使用的动画。

当生成动画时，会为每个后续动画产生一个 `NewAnimation` 事件，该事件具有 [IPresentationAnimationPlayer] 参数。后者是表示单独动画播放器的类。

要使用 [IPresentationAnimationPlayer]，需要使用其 [Duration]（动画的完整时长）属性和 [SetTimePosition] 方法。每个动画位置设置在 *0 到 duration* 范围内，然后 `GetFrame` 方法将返回对应于该时刻动画状态的 BufferedImage：  
```java
Presentation presentation = new Presentation();
try {
    // 添加一个笑脸形状并对其进行动画处理
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
            System.out.println(String.format("Animation total duration: %f", animationPlayer.getDuration()));
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


要让演示文稿中的所有动画一次性播放，使用 [PresentationPlayer] 类。该类在构造函数中接受一个 [PresentationAnimationsGenerator] 实例和效果的 FPS，然后调用 `FrameTick` 事件以播放所有动画：  
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


随后，这些生成的帧可以编译成视频。请参阅 [Convert PowerPoint to Video] 部分。  

## **支持的动画和效果**

**入口**  

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **出现** | ![not supported](x.png) | ![supported](v.png) |
| **淡入** | ![supported](v.png) | ![supported](v.png) |
| **飞入** | ![supported](v.png) | ![supported](v.png) |
| **浮现** | ![supported](v.png) | ![supported](v.png) |
| **分割** | ![supported](v.png) | ![supported](v.png) |
| **擦除** | ![supported](v.png) | ![supported](v.png) |
| **形状** | ![supported](v.png) | ![supported](v.png) |
| **轮形** | ![supported](v.png) | ![supported](v.png) |
| **随机条** | ![supported](v.png) | ![supported](v.png) |
| **成长并旋转** | ![not supported](x.png) | ![supported](v.png) |
| **缩放** | ![supported](v.png) | ![supported](v.png) |
| **旋转** | ![supported](v.png) | ![supported](v.png) |
| **弹跳** | ![supported](v.png) | ![supported](v.png) |

**强调**  

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **脉冲** | ![not supported](x.png) | ![supported](v.png) |
| **颜色脉冲** | ![not supported](x.png) | ![supported](v.png) |
| **摇摆** | ![supported](v.png) | ![supported](v.png) |
| **旋转** | ![supported](v.png) | ![supported](v.png) |
| **成长/缩小** | ![not supported](x.png) | ![supported](v.png) |
| **去饱和** | ![not supported](x.png) | ![supported](v.png) |
| **变暗** | ![not supported](x.png) | ![supported](v.png) |
| **变亮** | ![not supported](x.png) | ![supported](v.png) |
| **透明度** | ![not supported](x.png) | ![supported](v.png) |
| **对象颜色** | ![not supported](x.png) | ![supported](v.png) |
| **互补颜色** | ![not supported](x.png) | ![supported](v.png) |
| **线条颜色** | ![not supported](x.png) | ![supported](v.png) |
| **填充颜色** | ![not supported](x.png) | ![supported](v.png) |

**退出**  

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **消失** | ![not supported](x.png) | ![supported](v.png) |
| **淡入** | ![supported](v.png) | ![supported](v.png) |
| **飞出** | ![supported](v.png) | ![supported](v.png) |
| **浮出** | ![supported](v.png) | ![supported](v.png) |
| **分割** | ![supported](v.png) | ![supported](v.png) |
| **擦除** | ![supported](v.png) | ![supported](v.png) |
| **形状** | ![supported](v.png) | ![supported](v.png) |
| **随机条** | ![supported](v.png) | ![supported](v.png) |
| **缩小并旋转** | ![not supported](x.png) | ![supported](v.png) |
| **缩放** | ![supported](v.png) | ![supported](v.png) |
| **旋转** | ![supported](v.png) | ![supported](v.png) |
| **弹跳** | ![supported](v.png) | ![supported](v.png) |

**运动路径**  

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **直线** | ![supported](v.png) | ![supported](v.png) |
| **弧线** | ![supported](v.png) | ![supported](v.png) |
| **转弯** | ![supported](v.png) | ![supported](v.png) |
| **形状** | ![supported](v.png) | ![supported](v.png) |
| **循环** | ![supported](v.png) | ![supported](v.png) |
| **自定义路径** | ![supported](v.png) | ![supported](v.png) |

## **常见问题**

**是否可以转换受密码保护的演示文稿？**  

是的，Aspose.Slides 支持处理[受密码保护的演示文稿](/slides/zh/androidjava/password-protected-presentation/)。在处理此类文件时，您需要提供正确的密码，以便库能够访问演示文稿的内容。

**Aspose.Slides 是否支持在云解决方案中使用？**  

是的，Aspose.Slides 可以集成到云应用和服务中。该库专为服务器环境设计，能够确保高性能和可伸缩性，以便批量处理文件。

**在转换过程中，对演示文稿的大小是否有限制？**  

Aspose.Slides 能够处理几乎任何大小的演示文稿。不过，在处理超大文件时，可能需要额外的系统资源，通常建议对演示文稿进行优化以提升性能。