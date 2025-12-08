---
title: 将 PowerPoint 转换为视频
type: docs
weight: 130
url: /zh/nodejs-java/convert-powerpoint-to-video/
keywords: "转换 PowerPoint, PPT, PPTX, 演示文稿, 视频, MP4, PPT 转视频, PPT 转 MP4, Java, Aspose.Slides"
description: "在 JavaScript 中将 PowerPoint 转换为视频"
---

通过将 PowerPoint 演示文稿转换为视频，您可以获得 

* **可访问性提升:** 与演示文稿打开应用程序相比，所有设备（无论平台）默认都配备视频播放器，因此用户打开或播放视频更容易。
* **覆盖范围更广:** 通过视频，您可以触及更大的受众，并向他们提供在演示文稿中可能显得枯燥的信息。大多数调查和统计数据显示，人们观看和消费视频的频率高于其他形式的内容，并且他们通常更喜欢此类内容。

{{% alert color="primary" %}} 
您可能想要查看我们的[**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word)，因为它是本文所述过程的实时且有效的实现。
{{% /alert %}} 

## **Aspose.Slides 中的 PowerPoint 到视频转换**

在[Aspose.Slides 22.11](https://docs.aspose.com/slides/nodejs-java/aspose-slides-for-java-22-11-release-notes/)中，我们实现了对演示文稿到视频转换的支持。

* 使用**Aspose.Slides**生成一组帧（来自演示文稿的幻灯片），这些帧对应于特定的 FPS（每秒帧数）。
* 使用诸如**ffmpeg**（[for java](https://github.com/bramp/ffmpeg-cli-wrapper)）的第三方工具根据这些帧创建视频。

### **将 PowerPoint 转换为视频**

1. 在[此处](https://ffmpeg.org/download.html)下载 ffmpeg。
2. 运行 PowerPoint 到视频的 JavaScript 代码。

此 JavaScript 代码展示了如何将包含图形和两个动画效果的演示文稿转换为视频：
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // 添加一个笑脸形状并对其进行动画
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // 配置 ffmpeg 二进制文件夹。参见此页面: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```


## **视频效果**

您可以对幻灯片上的对象应用动画并使用幻灯片之间的切换。

{{% alert color="primary" %}} 
您可能想要查看以下文章：[PowerPoint Animation](https://docs.aspose.com/slides/nodejs-java/powerpoint-animation/)、[Shape Animation](https://docs.aspose.com/slides/nodejs-java/shape-animation/)和[Shape Effect](https://docs.aspose.com/slides/nodejs-java/shape-effect/)。
{{% /alert %}} 

动画和切换使幻灯片放映更具吸引力和趣味性——它们对视频也有相同的作用。让我们为前面的演示文稿的代码添加另一张幻灯片和切换：
```javascript
// 添加一个笑脸形状并对其进行动画
// ...
// 添加新幻灯片并添加动画切换
var newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());
newSlide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
newSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
newSlide.getSlideShowTransition().setType(aspose.slides.TransitionType.Push);
```


Aspose.Slides 还支持文本动画。因此我们对对象上的段落进行动画处理，它们将一个接一个出现（延迟设置为一秒）：
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // 添加文本和动画
    var autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 120, 300, 300);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Aspose Slides for Node.js via Java"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("convert PowerPoint Presentation with text to video"));
    var para3 = new aspose.slides.Paragraph();
    para3.getPortions().add(new aspose.slides.Portion("paragraph by paragraph"));
    var paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new aspose.slides.Paragraph());
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effect1 = mainSequence.addEffect(para1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect2 = mainSequence.addEffect(para2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect3 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect4 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    effect1.getTiming().setTriggerDelayTime(1.0);
    effect2.getTiming().setTriggerDelayTime(1.0);
    effect3.getTiming().setTriggerDelayTime(1.0);
    effect4.getTiming().setTriggerDelayTime(1.0);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // 配置 ffmpeg 二进制文件夹。参见此页面: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```


## **视频转换类**

为了让您能够执行 PowerPoint 到视频的转换任务，Aspose.Slides 提供了[PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/)和[PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/)类。

PresentationAnimationsGenerator 允许您通过其构造函数设置视频（以后将创建）的帧大小。如果传入演示文稿实例，将使用 `Presentation.getSlideSize`，并生成供 PresentationPlayer 使用的动画。

生成动画时，会为每个后续动画生成一个 `NewAnimation` 事件，其中包含[PresentationAnimationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationplayer/) 参数。后者是表示单独动画播放器的类。

要使用 PresentationAnimationPlayer，需要使用 [getDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationplayer/#getDuration--)（动画的完整持续时间）方法和 [setTimePosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationplayer/#setTimePosition-double-) 方法。每个动画位置在 *0 到 duration* 范围内设置，然后 `getFrame` 方法将返回对应于该时刻动画状态的 BufferedImage：
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // 添加一个笑脸形状并对其进行动画
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer -> {
            console.log(java.callStaticMethodSync("java.lang.String", "format", "Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0);// 初始动画状态
            try {
                // 初始动画状态位图
                animationPlayer.getFrame().save("firstFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration());// 最终动画状态
            try {
                // 动画的最后一帧
                animationPlayer.getFrame().save("lastFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
        });
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


为了让演示文稿中的所有动画一次性播放，使用 [PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/) 类。该类在构造函数中接受一个 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) 实例和 FPS，然后调用所有动画的 `FrameTick` 事件以实现播放：
```javascript
var presentation = new aspose.slides.Presentation("animated.pptx");
try {
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    arguments.getFrame().save(("frame_" + sender.getFrameIndex()) + ".png", aspose.slides.ImageFormat.Png);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


随后可以将生成的帧编译为视频。请参阅 [Convert PowerPoint to Video](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-video/#convert-powerpoint-to-video) 部分。

## **支持的动画和效果**

**Entrance**:

| **Animation Type** | **Aspose.Slides** | **PowerPoint** |
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

**Emphasis**:

| **Animation Type** | **Aspose.Slides** | **PowerPoint** |
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

**Exit**:

| **Animation Type** | **Aspose.Slides** | **PowerPoint** |
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

**Motion Paths**:

| **Animation Type** | **Aspose.Slides** | **PowerPoint** |
|---|---|---|
| **Lines** | ![支持](v.png) | ![支持](v.png) |
| **Arcs** | ![支持](v.png) | ![支持](v.png) |
| **Turns** | ![支持](v.png) | ![支持](v.png) |
| **Shapes** | ![支持](v.png) | ![支持](v.png) |
| **Loops** | ![支持](v.png) | ![支持](v.png) |
| **Custom Path** | ![支持](v.png) | ![支持](v.png) |

## **常见问题**

**是否可以转换受密码保护的演示文稿？**

是的，Aspose.Slides 允许处理受密码保护的演示文稿。处理此类文件时，您需要提供正确的密码，以便库能够访问演示文稿的内容。

**Aspose.Slides 是否支持在云解决方案中使用？**

是的，Aspose.Slides 可以集成到云应用程序和服务中。该库专为服务器环境设计，能够在批量处理文件时提供高性能和可伸缩性。

**在转换过程中对演示文稿的大小是否有限制？**

Aspose.Slides 能够处理几乎任何大小的演示文稿。然而，在处理非常大的文件时，可能需要额外的系统资源，通常建议对演示文稿进行优化以提升性能。