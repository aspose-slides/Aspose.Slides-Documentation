---
title: 在 Python 中将 PowerPoint 演示文稿转换为视频
linktitle: PowerPoint 转视频
type: docs
weight: 130
url: /zh/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint 转视频
- 将 PowerPoint 转换为视频
- 演示文稿转换为视频
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

将您的 PowerPoint 或 OpenDocument 演示文稿转换为视频，您将获得：

**可访问性提升：** 所有设备，无论平台如何，默认配备视频播放器，使用户相较于传统演示应用程序更容易打开或播放视频。

**覆盖面更广：** 视频让您能够接触更大受众，并以更具吸引力的形式呈现信息。调查和统计数据显示，人们更倾向于观看和消费视频内容，而非其他形式，这使您的信息更具冲击力。

{{% alert color="primary" %}} 

请查看我们的[**PowerPoint 转视频在线转换器**](https://products.aspose.app/slides/video)，因为它提供了本文所述过程的实时有效实现。

{{% /alert %}} 

在[Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/)中，我们实现了将演示文稿转换为视频的支持。

* 使用 Aspose.Slides for Python 按指定帧率 (FPS) 从演示幻灯片生成帧。  
* 然后，使用诸如 ffmpeg 的第三方工具将这些帧编译成视频。

## **将 PowerPoint 演示文稿转换为视频**

1. 使用 pip 安装命令将 Aspose.Slides for Python 添加到项目中：`pip install aspose-slides==24.4.0`  
2. 从[此处](https://ffmpeg.org/download.html)下载 ffmpeg，或通过包管理器安装它。  
3. 确保 ffmpeg 已加入 `PATH`。否则，请使用二进制文件的完整路径启动 ffmpeg（例如 Windows 上的 `C:\ffmpeg\ffmpeg.exe` 或 Linux 上的 `/opt/ffmpeg/ffmpeg`）。  
4. 运行 PowerPoint 转视频的转换代码。

以下 Python 代码演示了如何将包含形状和两个动画效果的演示文稿转换为视频：

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

在使用 Aspose.Slides for Python 将 PowerPoint 演示文稿转换为视频时，您可以应用各种视频效果以提升输出的视觉质量。这些效果通过添加平滑的过渡、动画和其他视觉元素，允许您控制最终视频中幻灯片的呈现方式。本节将说明可用的视频效果选项并展示如何应用它们。

{{% alert color="primary" %}} 

参见[PowerPoint 动画](https://docs.aspose.com/slides/python-net/powerpoint-animation/)、[形状动画](https://docs.aspose.com/slides/python-net/shape-animation/)、以及[形状效果](https://docs.aspose.com/slides/python-net/shape-effect/)。

{{% /alert %}} 

动画和过渡使幻灯片放映更具吸引力和趣味性 —— 对视频也是如此。让我们在前面演示的代码中添加另一张幻灯片和过渡效果：

```python
import aspose.pydrawing as drawing

# 添加一个笑脸形状并为其设置动画。
# ...

# 添加一个新幻灯片并设置动画切换。
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```


Aspose.Slides for Python 也支持文本动画。在此示例中，我们对对象上的段落进行动画处理，使其逐个出现，每个之间间隔一秒：

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

为了实现 PowerPoint 转视频的转换任务，Aspose.Slides for Python 提供了[PresentationEnumerableAnimationsGenerator](https://reference.aspose.com/slides/python-net/aspose.slides.export/presentationenumerableanimationsgenerator/)。

`PresentationEnumerableAnimationsGenerator` 允许您通过构造函数设置视频的帧大小（稍后将创建）以及 FPS（每秒帧数）值。如果传入一个演示实例，则会使用其 `Presentation.SlideSize`。

要让演示文稿中的所有动画一次性播放，请使用 `PresentationEnumerableAnimationsGenerator.enumerate_frames` 方法。该方法接受幻灯片集合并依次返回[EnumerableFrameArgs](https://reference.aspose.com/slides/python-net/aspose.slides.export/enumerableframeargs/)。随后，使用 `EnumerableFrameArgs.get_frame()` 获取每一帧视频。

```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```


然后，可以将生成的帧编译为视频。有关更多详情，请参阅[将 PowerPoint 转换为视频](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video)章节。

## **支持的动画和效果**

在使用 Aspose.Slides for Python 将 PowerPoint 演示文稿转换为视频时，了解输出中支持哪些动画和效果非常重要。Aspose.Slides 支持多种常见的进入、退出和强调效果，如淡入、飞入、缩放和旋转。然而，某些高级或自定义动画可能无法完全保留，或在最终视频中表现不同。本节概述了受支持的动画和效果。

**进入**

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

**强调**

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

**退出**

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

**运动路径**

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **支持的幻灯片切换效果**

幻灯片切换效果在创建视频中平滑且视觉上令人愉悦的幻灯片之间的切换方面起着重要作用。Aspose.Slides for Python 支持多种常用的切换效果，以帮助在转换过程中保留原始演示的流程和风格。本节重点说明在转换过程中支持的切换效果。

**细微**

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Push** | ![supported](v.png) | ![supported](v.png) |
| **Pull** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Reveal** | ![not supported](x.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![not supported](x.png) | ![supported](v.png) |
| **Uncover** | ![not supported](x.png) | ![supported](v.png) |
| **Cover** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Strips** | ![supported](v.png) | ![supported](v.png) |

**激动**

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![not supported](x.png) | ![supported](v.png) |
| **Drape** | ![not supported](x.png) | ![supported](v.png) |
| **Curtains** | ![not supported](x.png) | ![supported](v.png) |
| **Wind** | ![not supported](x.png) | ![supported](v.png) |
| **Prestige** | ![not supported](x.png) | ![supported](v.png) |
| **Fracture** | ![not supported](x.png) | ![supported](v.png) |
| **Crush** | ![not supported](x.png) | ![supported](v.png) |
| **Peel Off** | ![not supported](x.png) | ![supported](v.png) |
| **Page Curl** | ![not supported](x.png) | ![supported](v.png) |
| **Airplane** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolve** | ![supported](v.png) | ![supported](v.png) |
| **Checkerboard** | ![not supported](x.png) | ![supported](v.png) |
| **Blinds** | ![not supported](x.png) | ![supported](v.png) |
| **Clock** | ![supported](v.png) | ![supported](v.png) |
| **Ripple** | ![not supported](x.png) | ![supported](v.png) |
| **Honeycomb** | ![not supported](x.png) | ![supported](v.png) |
| **Glitter** | ![not supported](x.png) | ![supported](v.png) |
| **Vortex** | ![not supported](x.png) | ![supported](v.png) |
| **Shred** | ![not supported](x.png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x.png) | ![supported](v.png) |
| **Gallery** | ![not supported](x.png) | ![supported](v.png) |
| **Cube** | ![not supported](x.png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**动态内容**

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v/png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **常见问题**

**是否可以转换受密码保护的演示文稿？**

是的，Aspose.Slides for Python 允许处理受密码保护的演示文稿。处理此类文件时，需要提供正确的密码，以便库能够访问演示文稿的内容。

**Aspose.Slides for Python 是否支持在云解决方案中使用？**

是的，Aspose.Slides for Python 可集成到云应用和服务中。该库专为服务器环境设计，确保在批量处理文件时具备高性能和可伸缩性。

**在转换过程中对演示文稿的大小是否有限制？**

Aspose.Slides for Python 能处理几乎任何大小的演示文稿。然而，在处理非常大的文件时，可能需要额外的系统资源，并且有时建议优化演示文稿以提升性能。