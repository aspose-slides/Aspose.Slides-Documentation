---
title: 将 PowerPoint 演示文稿转换为 Android 视频
linktitle: PowerPoint 转视频
type: docs
weight: 130
url: /zh/androidjava/convert-powerpoint-to-video/
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
- Android
- Java
- Aspose.Slides
description: "了解如何在 Java 中将 PowerPoint 演示文稿转换为视频。探索示例代码和自动化技术，以简化工作流程。"
---
## **简介**

通过将 PowerPoint 演示文稿转换为视频，您可以获得 

* **提升可访问性：** 所有设备（无论平台）默认都配备视频播放器，而不是演示文稿打开应用程序，因此用户更容易打开或播放视频。
* **更广的受众：** 通过视频，您可以覆盖更大的受众，并向他们传递在演示文稿中可能显得枯燥的信息。大多数调查和统计数据显示，人们观看和消费视频的比例高于其他内容形式，而且他们普遍更喜欢此类内容。

## **Aspose.Slides 中的 PowerPoint 转视频转换**

Aspose.Slides 支持演示文稿转视频的转换。

* 使用 **Aspose.Slides** 生成一组帧（来自演示文稿的幻灯片），这些帧对应特定的 FPS（每秒帧数）
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

3. 运行 PowerPoint 转视频的 Java 代码。

此 Java 代码演示如何将包含图形和两个动画效果的演示文稿转换为视频：

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // 添加一个笑脸形状，然后对其进行动画处理
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

    // 配置 ffmpeg 二进制文件夹。参见此页面：https://github.com/bramp/ffmpeg-cli-wrapper
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

您可以对幻灯片上的对象应用动画，并使用幻灯片之间的切换效果。

{{% alert color="info" %}} 

您可能想查看以下文章：[PowerPoint Animation](https://docs.aspose.com/slides/zh/androidjava/powerpoint-animation/)、[Shape Animation](https://docs.aspose.com/slides/zh/androidjava/shape-animation/) 和 [Shape Effect](https://docs.aspose.com/slides/zh/androidjava/shape-effect/)。

{{% /alert %}} 

动画和切换使幻灯片放映更具吸引力和趣味性——它们对视频也有同样的作用。让我们为之前的演示文稿的代码添加另一张幻灯片和切换效果：

```java
import com.aspose.slides.*;
import java.awt.Color;

// 具有上述动画笑脸形状的演示文稿。
Presentation presentation = new Presentation();
try {
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

Aspose.Slides 也支持文本动画。因此我们对对象上的段落进行动画处理，它们将一个接一个出现（延迟设置为一秒）：

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

    // 配置 ffmpeg 二进制文件夹。参见此页面：https://github.com/bramp/ffmpeg-cli-wrapper
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

为了让您执行 PowerPoint 转视频的任务，Aspose.Slides 提供了 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentationanimationsgenerator/) 和 [PresentationPlayer](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentationplayer/) 类。

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentationanimationsgenerator/) 允许您通过其构造函数设置视频（稍后将创建）的帧大小。如果传入演示文稿的实例，将使用 `Presentation.SlideSize`，并生成供 [PresentationPlayer](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentationplayer/) 使用的动画。

当生成动画时，每个后续动画都会触发一个 `NewAnimation` 事件，该事件带有 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentationanimationplayer/) 参数。后者是表示单独动画播放器的类。

要使用 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentationanimationplayer/)，需要使用 [Duration](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--)（动画的完整持续时间）属性和 [SetTimePosition](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) 方法。每个动画位置都设置在 *0 到 duration* 范围内，然后 `getFrame` 方法将返回对应于该时刻动画状态的 [IImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimage/)。

```java
import com.aspose.slides.*;

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
            // 初始动画状态位图
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // 动画的最终状态
            // 动画的最后一帧
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // 生成动画。上面的回调会为每个动画运行一次。
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

要让演示文稿中的所有动画一次性播放，使用 [PresentationPlayer](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentationplayer/) 类。该类在构造函数中接受一个 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentationanimationsgenerator/) 实例和用于效果的 FPS，然后调用 `FrameTick` 事件以播放所有动画：

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

然后将生成的帧编译即可生成视频。参见 [Convert PowerPoint to Video](https://docs.aspose.com/slides/zh/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video) 部分。

## **支持的动画和效果**

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

## **常见问题**

### 是否可以转换受密码保护的演示文稿？

是的，Aspose.Slides 支持处理[受密码保护的演示文稿](/slides/zh/androidjava/password-protected-presentation/)。在处理此类文件时，需要提供正确的密码，以便库能够访问演示文稿的内容。

### Aspose.Slides 是否支持在云解决方案中使用？

是的，Aspose.Slides 可以集成到云应用程序和服务中。该库专为服务器环境设计，确保在批量处理文件时具备高性能和可扩展性。

### 转换期间对演示文稿的大小是否有限制？

Aspose.Slides 能够处理几乎任何大小的演示文稿。然而，在处理特别大的文件时，可能需要额外的系统资源，通常建议对演示文稿进行优化以提升性能。