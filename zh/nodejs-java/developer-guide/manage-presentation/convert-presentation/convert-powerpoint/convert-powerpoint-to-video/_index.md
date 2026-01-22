---
title: 在 JavaScript 中将 PowerPoint 演示文稿转换为视频
linktitle: PowerPoint 转视频
type: docs
weight: 130
url: /zh/nodejs-java/convert-powerpoint-to-video/
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
- 将 PPT 导出为 MP4
- 将 PPTX 导出为 MP4
- 视频 转换
- PowerPoint
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何在 JavaScript 中将 PowerPoint 演示文稿转换为视频。探索示例代码和自动化技术，以简化您的工作流程。"
---

通过将 PowerPoint 演示文稿转换为视频，您可以获得

* **可访问性提升：** 与演示文稿打开应用程序相比，所有设备（无论平台）默认都配备视频播放器，用户更容易打开或播放视频。
* **覆盖范围更广：** 通过视频，您可以触达更大的受众，并向他们传递在演示文稿中可能显得枯燥的信息。大多数调查和统计数据显示，人们观看和消费视频的频率高于其他形式的内容，而且他们更倾向于此类内容。

{{% alert color="primary" %}} 
您可能想查看我们的[**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word)，因为它是本文所述过程的实时有效实现。
{{% /alert %}} 

## **Aspose.Slides 中的 PowerPoint 到视频转换**

Aspose.Slides 支持演示文稿到视频的转换。

* 使用 **Aspose.Slides** 生成一组帧（来自演示文稿幻灯片），这些帧对应特定的 FPS（每秒帧数）
* 使用第三方工具如 **ffmpeg**([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) 根据这些帧创建视频。

### **将 PowerPoint 转换为视频**

1. 在[这里](https://ffmpeg.org/download.html)下载 ffmpeg。
2. 运行 PowerPoint 到视频的 JavaScript 代码。

下面的 JavaScript 代码演示了如何将包含图形和两个动画效果的演示文稿转换为视频：
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // 添加一个笑脸形状并对其进行动画处理
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

您可以对幻灯片中的对象应用动画，并在幻灯片之间使用转场。

{{% alert color="primary" %}} 
您可能想阅读以下文章：[PowerPoint Animation](https://docs.aspose.com/slides/nodejs-java/powerpoint-animation/)、[Shape Animation](https://docs.aspose.com/slides/nodejs-java/shape-animation/)、以及[Shape Effect](https://docs.aspose.com/slides/nodejs-java/shape-effect/)。
{{% /alert %}} 

动画和转场使幻灯片放映更具吸引力和趣味性——它们对视频同样适用。让我们为前面的演示文稿的代码添加另一张幻灯片和转场：
```javascript
// 添加一个笑脸形状并对其进行动画处理
// ...
// 添加一个新幻灯片并设置动画过渡
var newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());
newSlide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
newSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
newSlide.getSlideShowTransition().setType(aspose.slides.TransitionType.Push);
```


Aspose.Slides 还支持文本动画。因此我们对对象上的段落进行动画处理，使它们依次出现（延迟设为一秒）：
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

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) 允许您通过构造函数为稍后创建的视频设置帧大小。如果您传入演示文稿实例，`Presentation.getSlideSize` 将被使用，并生成供 [PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/) 使用的动画。

在生成动画时，会为每个后续动画生成 `NewAnimation` 事件，该事件包含演示文稿动画播放器参数。后者是一个表示独立动画播放器的类。

要与演示文稿动画播放器交互，使用 `getDuration`（动画的完整时长）方法和 `setTimePosition` 方法。每个动画位置设置在 *0 到 duration* 范围内，然后 `getFrame` 方法将返回对应于该时刻动画状态的 BufferedImage：
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // 添加一个笑脸形状并对其进行动画处理
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
            animationPlayer.setTimePosition(animationPlayer.getDuration());// 动画的最后一帧
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


要使演示文稿中的所有动画一次性播放，使用 [PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/) 类。该类在构造函数中接受一个 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) 实例和 FPS，然后为所有动画调用 `FrameTick` 事件以进行播放：
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


随后可以将生成的帧编译为视频。请参阅[Convert PowerPoint to Video](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-video/#convert-powerpoint-to-video)章节。

## **受支持的动画和效果**

**入口：**

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

**强调：**

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

**退出：**

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

**运动路径：**

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![支持](v.png) | ![支持](v.png) |
| **Arcs** | ![支持](v.png) | ![支持](v.png) |
| **Turns** | ![支持](v.png) | ![支持](v.png) |
| **Shapes** | ![支持](v.png) | ![支持](v.png) |
| **Loops** | ![支持](v.png) | ![支持](v.png) |
| **Custom Path** | ![支持](v.png) | ![支持](v.png) |

## **常见问题**

**是否可以转换受密码保护的演示文稿？**

是的，Aspose.Slides 支持处理受密码保护的演示文稿。处理此类文件时，需要提供正确的密码，以便库能够访问演示文稿的内容。

**Aspose.Slides 是否支持在云解决方案中使用？**

是的，Aspose.Slides 可集成到云应用和服务中。该库专为服务器环境设计，确保在批量处理文件时具备高性能和可伸缩性。

**在转换过程中对演示文稿的大小有限制吗？**

Aspose.Slides 能够处理几乎任何大小的演示文稿。但在处理非常大的文件时，可能需要额外的系统资源，建议对演示文稿进行优化以提升性能。