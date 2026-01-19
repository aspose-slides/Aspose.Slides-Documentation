---
title: 使用 Python 将 PowerPoint 演示文稿转换为视频
linktitle: PowerPoint 转视频
type: docs
weight: 130
url: /zh/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint 转视频
- 将 PowerPoint 转换为视频
- 演示文稿转视频
- 将演示文稿转换为视频
- PPT 转视频
- 将 PPT 转换为视频
- PPTX 转视频
- 将 PPTX 转换为视频
- ODP 转视频
- 将 ODP 转换为视频
- PowerPoint 转 MP4
- 将 PowerPoint 转换为 MP4
- 演示文稿转 MP4
- 将演示文稿转换为 MP4
- PPT 转 MP4
- 将 PPT 转换为 MP4
- PPTX 转 MP4
- 将 PPTX 转换为 MP4
- PowerPoint 转视频转换
- 演示文稿转视频转换
- PPT 转视频转换
- PPTX 转视频转换
- ODP 转视频转换
- Python 视频转换
- PowerPoint
- Python
- Aspose.Slides
description: "了解如何使用 Python 将 PowerPoint 和 OpenDocument 演示文稿转换为视频。发现示例代码和自动化技术，以简化您的工作流程。"
---

## **概述**

通过将 PowerPoint 或 OpenDocument 演示文稿转换为视频，您可以获得：

**可访问性提升：** 所有设备默认都配有视频播放器，无论平台如何，这使得用户打开或播放视频比使用传统演示应用程序更容易。

**受众范围扩大：** 视频可以让您触达更广泛的受众，并以更具吸引力的形式呈现信息。调查和统计数据显示，人们更倾向于观看和消费视频内容，这使您的信息更具冲击力。

{{% alert color="primary" %}} 
查看我们的[**PowerPoint 转视频在线转换器**](https://products.aspose.app/slides/video)因为它提供了本文所述过程的实时且有效的实现。
{{% /alert %}} 

在[Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/)中，我们实现了将演示文稿转换为视频的支持。

* 使用 Aspose.Slides for Python 按指定帧率（FPS）从演示文稿幻灯片生成帧。  
* 然后，使用第三方实用程序如 ffmpeg 将这些帧编译为视频。

## **将 PowerPoint 演示文稿转换为视频**

1. 使用 pip 安装命令将 Aspose.Slides for Python 添加到项目中：`pip install aspose-slides==24.4.0`  
2. 从[这里](https://ffmpeg.org/download.html)下载 ffmpeg，或通过包管理器安装。  
3. 确保 ffmpeg 位于 `PATH` 中。否则，请使用二进制文件的完整路径启动 ffmpeg（例如 Windows 上的 `C:\ffmpeg\ffmpeg.exe` 或 Linux 上的 `/opt/ffmpeg/ffmpeg`）。  
4. 运行 PowerPoint 到视频的转换代码。

以下 Python 代码示例演示了如何将包含形状和两个动画效果的演示文稿转换为视频：
```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smile_shape = slide.shapes.add_auto_shape(slides.ShapeType.SMILEY_FACE, 110, 20, 500, 500)

    effect_in = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.TOP_LEFT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_out = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.BOTTOM_RIGHT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_in.timing.duration = 2
    effect_out.preset_class_type = slides.animation.EffectPresetClassType.EXIT

    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p",
                "smile.webm"]
    subprocess.call(cmd_line)
```


## **视频效果**

在使用 Aspose.Slides for Python 将 PowerPoint 演示文稿转换为视频时，您可以应用各种视频效果以提升输出的视觉质量。这些效果通过添加平滑的过渡、动画和其他视觉元素，让您能够控制最终视频中幻灯片的呈现方式。本节说明了可用的视频效果选项并展示了如何应用它们。

{{% alert color="primary" %}} 
参见[PowerPoint Animation](https://docs.aspose.com/slides/python-net/powerpoint-animation/)、[Shape Animation](https://docs.aspose.com/slides/python-net/shape-animation/)和[Shape Effect](https://docs.aspose.com/slides/python-net/shape-effect/)。
{{% /alert %}} 

动画和切换使幻灯片放映更具吸引力，视频亦是如此。让我们为前面的演示文稿代码添加另一张幻灯片和切换效果：
```python
import aspose.pydrawing as drawing

# 添加一个笑脸形状并为其添加动画。
# ...

# 添加一个新幻灯片并设置动画切换。
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```


Aspose.Slides for Python 还支持文本动画。在此示例中，我们对对象上的段落进行动画处理，使其依次出现，并在每个段落之间设置一秒的延迟：
```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 添加文本和动画。
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 120, 300, 300)
    para1 = slides.Paragraph()
    para1.portions.add(slides.Portion("Aspose.Slides for Python"))
    para2 = slides.Paragraph()
    para2.portions.add(slides.Portion("Convert a PowerPoint presentation with text to video"))

    para3 = slides.Paragraph()
    para3.portions.add(slides.Portion("paragraph by paragraph"))
    auto_shape.text_frame.paragraphs.add(para1)
    auto_shape.text_frame.paragraphs.add(para2)
    auto_shape.text_frame.paragraphs.add(para3)
    auto_shape.text_frame.paragraphs.add(slides.Paragraph())

    effect = slide.timeline.main_sequence.add_effect(
        para1,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect2 = slide.timeline.main_sequence.add_effect(
        para2,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect3 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect4 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect.timing.trigger_delay_time = 1
    effect2.timing.trigger_delay_time = 1
    effect3.timing.trigger_delay_time = 1
    effect4.timing.trigger_delay_time = 1

    # 将帧转换为视频。
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```


## **视频转换类**

为了实现 PowerPoint 到视频的转换任务，Aspose.Slides for Python 提供了[PresentationEnumerableFramesGenerator](https://reference.aspose.com/slides/python-net/aspose.slides.export/presentationenumerableframesgenerator/)。

`PresentationEnumerableFramesGenerator` 允许您通过构造函数设置视频（稍后将创建）的帧大小和 FPS（每秒帧数）。如果传入演示文稿实例，将使用其 `Presentation.SlideSize`。

要使演示文稿中的所有动画一次性播放，请使用 `PresentationEnumerableFramesGenerator.enumerate_frames` 方法。此方法接受幻灯片集合，并顺序返回[EnumerableFrameArgs](https://reference.aspose.com/slides/python-net/aspose.slides.export/enumerableframeargs/)。随后，使用 `EnumerableFrameArgs.get_frame()` 获取每个视频帧。
```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```


然后可以将生成的帧编译为视频。有关详细信息，请参阅[将 PowerPoint 转换为视频](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video)章节。

## **支持的动画和效果**

在使用 Aspose.Slides for Python 将 PowerPoint 演示文稿转换为视频时，了解输出中支持哪些动画和效果至关重要。Aspose.Slides 支持多种常见的进入、退出和强调效果，如淡入、飞入、缩放和旋转。但某些高级或自定义动画可能无法完整保留或在最终视频中呈现不同。本节概述了受支持的动画和效果。

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

## **支持的幻灯片切换效果**

幻灯片切换效果在视频中实现平滑且视觉上吸引人的画面转换方面起着重要作用。Aspose.Slides for Python 支持多种常用切换效果，以帮助在转换过程中保持原始演示文稿的流畅性和风格。本节突出显示了转换过程中受支持的切换效果。

**细腻**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![不支持](x.png) | ![支持](v.png) |
| **Fade** | ![支持](v.png) | ![支持](v.png) |
| **Push** | ![支持](v.png) | ![支持](v.png) |
| **Pull** | ![支持](v.png) | ![支持](v.png) |
| **Wipe** | ![支持](v.png) | ![支持](v.png) |
| **Split** | ![支持](v.png) | ![支持](v.png) |
| **Reveal** | ![不支持](x.png) | ![支持](v.png) |
| **Random Bars** | ![支持](v.png) | ![支持](v.png) |
| **Shape** | ![不支持](x.png) | ![支持](v.png) |
| **Uncover** | ![不支持](x.png) | ![支持](v.png) |
| **Cover** | ![支持](v.png) | ![支持](v.png) |
| **Flash** | ![支持](v.png) | ![支持](v.png) |
| **Strips** | ![支持](v.png) | ![支持](v.png) |

**激动**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![不支持](x.png) | ![支持](v.png) |
| **Drape** | ![不支持](x.png) | ![支持](v.png) |
| **Curtains** | ![不支持](x.png) | ![支持](v.png) |
| **Wind** | ![不支持](x.png) | ![支持](v.png) |
| **Prestige** | ![不支持](x.png) | ![支持](v.png) |
| **Fracture** | ![不支持](x.png) | ![支持](v.png) |
| **Crush** | ![不支持](x.png) | ![支持](v.png) |
| **Peel Off** | ![不支持](x.png) | ![支持](v.png) |
| **Page Curl** | ![不支持](x.png) | ![支持](v.png) |
| **Airplane** | ![不支持](x.png) | ![支持](v.png) |
| **Origami** | ![不支持](x.png) | ![支持](v.png) |
| **Dissolve** | ![支持](v.png) | ![支持](v.png) |
| **Checkerboard** | ![不支持](x.png) | ![支持](v.png) |
| **Blinds** | ![不支持](x.png) | ![支持](v.png) |
| **Clock** | ![支持](v.png) | ![支持](v.png) |
| **Ripple** | ![不支持](x.png) | ![支持](v.png) |
| **Honeycomb** | ![不支持](x.png) | ![支持](v.png) |
| **Glitter** | ![不支持](x.png) | ![支持](v.png) |
| **Vortex** | ![不支持](x.png) | ![支持](v.png) |
| **Shred** | ![不支持](x.png) | ![支持](v.png) |
| **Switch** | ![不支持](x.png) | ![支持](v.png) |
| **Flip** | ![不支持](x.png) | ![支持](v.png) |
| **Gallery** | ![不支持](x.png) | ![支持](v.png) |
| **Cube** | ![不支持](x.png) | ![支持](v.png) |
| **Doors** | ![不支持](x.png) | ![支持](v.png) |
| **Box** | ![不支持](x.png) | ![支持](v.png) |
| **Comb** | ![不支持](x.png) | ![支持](v.png) |
| **Zoom** | ![支持](v.png) | ![支持](v.png) |
| **Random** | ![不支持](x.png) | ![支持](v.png) |

**动态图像**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![不支持](x.png) | ![支持](v.png) |
| **Ferris Wheel** | ![支持](v.png) | ![支持](v.png) |
| **Conveyor** | ![不支持](x.png) | ![支持](v.png) |
| **Rotate** | ![不支持](x.png) | ![支持](v.png) |
| **Orbit** | ![不支持](x.png) | ![支持](v.png) |
| **Fly Through** | ![支持](v.png) | ![支持](v.png) |

## **常见问题**

**是否可以转换受密码保护的演示文稿？**

是的，Aspose.Slides for Python 支持处理受密码保护的演示文稿。处理此类文件时，您需要提供正确的密码，以便库能够访问演示文稿的内容。

**Aspose.Slides for Python 是否支持在云解决方案中使用？**

是的，Aspose.Slides for Python 可以集成到云应用和服务中。该库专为服务器环境设计，确保在批量文件处理时具备高性能和可扩展性。

**在转换过程中对演示文稿的大小是否有限制？**

Aspose.Slides for Python 能够处理几乎任何大小的演示文稿。不过，在处理特别大的文件时，可能需要更多系统资源，建议对演示文稿进行优化以提升性能。