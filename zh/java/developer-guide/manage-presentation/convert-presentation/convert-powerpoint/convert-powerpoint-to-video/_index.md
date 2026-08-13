---
title: 在 Java 中将 PowerPoint 演示文稿转换为视频
linktitle: PowerPoint 转视频
type: docs
weight: 130
url: /zh/java/convert-powerpoint-to-video/
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
- Java
- Aspose.Slides
description: "了解如何在 Java 中将 PowerPoint 演示文稿转换为视频。发现示例代码和自动化技术，以简化您的工作流程。"
---
## **简介**

通过将 PowerPoint 或 OpenDocument 演示文稿转换为视频，您可以获得：

**可访问性提升：** 所有设备，无论平台，都默认配备视频播放器，相比传统演示文稿应用，用户打开或播放视频更为便捷。

**覆盖面更广：** 视频可以帮助您触达更大的受众，并以更具吸引力的形式呈现信息。调查与统计显示，人们更倾向于观看和消费视频内容，这会使您的信息更具冲击力。

{{% alert color="info" %}} 
您可能想查看我们的[**PowerPoint 转视频在线转换器**](https://products.aspose.app/slides/zh/video)，因为它是本文所述过程的实时且有效实现。
{{% /alert %}} 

## **PowerPoint 转视频转换在 Aspose.Slides 中**

在[Aspose.Slides 22.11](https://docs.aspose.com/slides/zh/java/aspose-slides-for-java-22-11-release-notes/)中，我们实现了对演示文稿转视频的支持。 

* 使用**Aspose.Slides**生成一组帧（来自演示文稿的幻灯片），这些帧对应特定的 FPS（每秒帧数）
* 使用第三方工具如**ffmpeg**（[for java](https://github.com/bramp/ffmpeg-cli-wrapper)）基于这些帧创建视频。 

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
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // 添加一个笑脸形状并对其进行动画
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

您可以对幻灯片上的对象应用动画，并在幻灯片之间使用切换效果。 

{{% alert color="info" %}} 
您可能想阅读以下文章：[PowerPoint Animation](https://docs.aspose.com/slides/zh/java/powerpoint-animation/)、[Shape Animation](https://docs.aspose.com/slides/zh/java/shape-animation/)和[Shape Effect](https://docs.aspose.com/slides/zh/java/shape-effect/)。
{{% /alert %}} 

动画和切换让幻灯片演示更具吸引力和趣味性——对视频同样适用。让我们为前面示例的代码添加另一张幻灯片和切换效果：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    // 添加一个笑脸形状并对其进行动画

    // ...

    // 添加一个新幻灯片并设置动画切换

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides 还支持文本动画。因此我们对对象上的段落进行动画处理，使其依次出现（延迟设为一秒）：

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

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

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);

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

为让您能够执行 PowerPoint 转视频的任务，Aspose.Slides 提供了[PresentationAnimationsGenerator](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentationanimationsgenerator/)和[PresentationPlayer](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentationplayer/)类。

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentationanimationsgenerator/) 允许您通过构造函数设置稍后将创建的视频的帧大小。如果传入演示文稿实例，将使用 `Presentation.SlideSize`，并生成供 [PresentationPlayer](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentationplayer/) 使用的动画。

当生成动画时，会为每个后续动画触发 `NewAnimation` 事件，该事件带有 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentationanimationplayer/) 参数。后者是表示单独动画播放器的类。

要使用 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentationanimationplayer/)，会使用其 `Duration`（动画的完整时长）属性和 `SetTimePosition` 方法。每个动画位置设置在 *0 到 duration* 范围内，然后 `getFrame` 方法将返回对应该时刻动画状态的 [IImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iimage/)：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // 添加一个笑脸形状并对其进行动画
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
            // 初始动画状态位图
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // 动画的最终状态
            // 动画的最后一帧
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // 生成动画 —— 这会触发上面处理的事件
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

若希望演示文稿中的所有动画一次性播放，使用 [PresentationPlayer](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentationplayer/) 类。该类在构造函数中接受一个 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentationanimationsgenerator/) 实例和用于效果的 FPS，然后对所有动画触发 `FrameTick` 事件以实现播放：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
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

随后可以将生成的帧编译成视频。请参阅 [Convert PowerPoint to Video](https://docs.aspose.com/slides/zh/java/convert-powerpoint-to-video/#convert-powerpoint-to-video) 部分。

## **支持的动画和效果**

**入口**：

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

**强调**：

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

**退出**：

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

**运动路径**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![支持](v.png) | ![支持](v.png) |
| **Arcs** | ![支持](v.png) | ![支持](v.png) |
| **Turns** | ![支持](v.png) | ![支持](v.png) |
| **Shapes** | ![支持](v.png) | ![支持](v.png) |
| **Loops** | ![支持](v.png) | ![支持](v.png) |
| **Custom Path** | ![支持](v.png) | ![支持](v.png) |

## **常见问题**

### 是否可以转换受密码保护的演示文稿？

是的，Aspose.Slides 支持处理[受密码保护的演示文稿](/slides/zh/java/password-protected-presentation/)。处理此类文件时，需要提供正确的密码，以便库能够访问演示文稿的内容。

### Aspose.Slides 是否支持在云解决方案中使用？

是的，Aspose.Slides 可以集成到云应用和服务中。该库专为服务器环境设计，确保高性能和可扩展性，以实现批量文件处理。

### 在转换过程中对演示文稿的大小有任何限制吗？

Aspose.Slides 能够处理几乎任意大小的演示文稿。但在处理特别大的文件时，可能需要额外的系统资源，通常建议对演示文稿进行优化以提升性能。