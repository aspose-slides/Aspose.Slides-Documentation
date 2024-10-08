---
title: 将 PowerPoint 转换为视频
type: docs
weight: 130
url: /python-net/convert-powerpoint-to-video/
keywords: "将 PowerPoint 转换为视频, PPT, PPTX, 演示文稿, 视频, MP4, PPT 转视频, PPT 转 MP4, Python, Aspose.Slides"
description: "在 Python 中将 PowerPoint 转换为视频"
---

通过将 PowerPoint 演示文稿转换为视频，您可以获得

* **更高的可访问性：** 所有设备（无论平台如何）默认都配备视频播放器，相比于打开演示文稿应用，用户发现打开或播放视频更容易。
* **更广泛的覆盖面：** 通过视频，您可以覆盖大量受众，并向他们传达可能在演示文稿中显得乏味的信息。大多数调查和统计数据显示，人们观看和消费视频的频率高于其他形式的内容，并且通常更喜欢这样的内容。

{{% alert color="primary" %}} 

您可能想查看我们的 [**PowerPoint 转视频在线转换器**](https://products.aspose.app/slides/conversion/ppt-to-word)，因为它是此处描述过程的实时有效实现。

{{% /alert %}} 

## **Aspose.Slides 中的 PowerPoint 转视频转换**

在 [Aspose.Slides 24.4](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/) 中，我们实现了演示文稿到视频转换的支持。

* 使用 Aspose.Slides 生成对应于特定 FPS（每秒帧数）的帧集（来自演示文稿幻灯片）
* 使用第三方工具，如 ffmpeg，根据帧创建视频。

### **将 PowerPoint 转换为视频**

1. 使用 pip install 命令将 Aspose.Slides 添加到您的项目中：
   * 运行 `pip install Aspose.Slides==24.4.0`
2. [在此处](https://ffmpeg.org/download.html) 下载 ffmpeg 或通过包管理器安装。
3. 确保 ffmpeg 在 `PATH` 中，否则使用二进制文件的完整路径启动 ffmpeg（例如在 Windows 上为 `C:\ffmpeg\ffmpeg.exe` 或在 Linux 上为 `/opt/ffmpeg/ffmpeg`）
4. 运行 PowerPoint 转视频代码。

该 Python 代码演示了如何将包含一个图形和两个动画效果的演示文稿转换为视频：

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    smile = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.SMILEY_FACE, 110, 20, 500, 500)
    effect_in = presentation.slides[0].timeline.main_sequence.add_effect(smile, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.TOP_LEFT, slides.animation.EffectTriggerType.AFTER_PREVIOUS)
    effect_out = presentation.slides[0].timeline.main_sequence.add_effect(smile, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.BOTTOM_RIGHT, slides.animation.EffectTriggerType.AFTER_PREVIOUS)
    effect_in.timing.duration = 2
    effect_out.preset_class_type = slides.animation.EffectPresetClassType.EXIT

    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "smile.webm"]
    subprocess.call(cmd_line)
```

## **视频效果**

您可以对幻灯片上的对象应用动画，并使用幻灯片之间的过渡。

{{% alert color="primary" %}} 

您可能想查看这些文章：[PowerPoint 动画](https://docs.aspose.com/slides/python-net/powerpoint-animation/)、[形状动画](https://docs.aspose.com/slides/python-net/shape-animation/) 和 [形状效果](https://docs.aspose.com/slides/python-net/shape-effect/)。

{{% /alert %}} 

动画和过渡使幻灯片放映更加生动有趣——它们对视频也有同样的效果。让我们向之前的演示程序添加另一个幻灯片和过渡：

```python
import aspose.pydrawing as drawing
# 添加一个笑脸形状并进行动画
# ...
# 添加一个新幻灯片和动画过渡

new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```

Aspose.Slides 还支持文本的动画。因此，我们可以使段落对象一个接一个地出现（延迟设置为一秒）：

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    # 添加文本和动画
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 120, 300, 300)
    para1 = slides.Paragraph()
    para1.portions.add(slides.Portion("Aspose Slides for .NET"))
    para2 = slides.Paragraph()
    para2.portions.add(slides.Portion("将 PowerPoint 演示文稿转换为视频"))

    para3 = slides.Paragraph()
    para3.portions.add(slides.Portion("逐段出现"))
    auto_shape.text_frame.paragraphs.add(para1)
    auto_shape.text_frame.paragraphs.add(para2)
    auto_shape.text_frame.paragraphs.add(para3)
    auto_shape.text_frame.paragraphs.add(slides.Paragraph())

    effect = presentation.slides[0].timeline.main_sequence.add_effect(para1, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect2 = presentation.slides[0].timeline.main_sequence.add_effect(para2, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect3 = presentation.slides[0].timeline.main_sequence.add_effect(para3, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect4 = presentation.slides[0].timeline.main_sequence.add_effect(para3, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect.timing.trigger_delay_time = 1
    effect2.timing.trigger_delay_time = 1
    effect3.timing.trigger_delay_time = 1
    effect4.timing.trigger_delay_time = 1

    # 将帧转换为视频
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```

## **视频转换类**

为使您能够执行 PowerPoint 转视频转换任务，Aspose.Slides 提供了 [PresentationEnumerableAnimationsGenerator](https://reference.aspose.com/slides/python-net/aspose.slides.export/presentationenumerableanimationsgenerator/)。

PresentationEnumerableAnimationsGenerator 允许您通过其构造函数设置视频的帧大小（稍后将创建）和 FPS 值（每秒帧数）。如果您传递一个演示文稿的实例，将使用 `Presentation.SlideSize`。

要使演示文稿中的所有动画同时播放，可以使用 PresentationEnumerableAnimationsGenerator.enumerate_frames 方法。该方法接受幻灯片集合，并允许按顺序获取 [EnumerableFrameArgs](https://reference.aspose.com/slides/python-net/aspose.slides.export/enumerableframeargs/)。然后，EnumerableFrameArgs.get_frame() 允许您获取视频帧：

```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```

然后，生成的帧可以编译生成一个视频。请参阅 [将 PowerPoint 转换为视频](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video) 部分。

## **支持的动画和效果**


**进入**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **出现** | ![不支持](x.png) | ![支持](v.png) |
| **渐变** | ![支持](v.png) | ![支持](v.png) |
| **飞入** | ![支持](v.png) | ![支持](v.png) |
| **漂浮入** | ![支持](v.png) | ![支持](v.png) |
| **分裂** | ![支持](v.png) | ![支持](v.png) |
| **擦拭** | ![支持](v.png) | ![支持](v.png) |
| **形状** | ![支持](v.png) | ![支持](v.png) |
| **轮子** | ![支持](v.png) | ![支持](v.png) |
| **随机条** | ![支持](v.png) | ![支持](v.png) |
| **增长与旋转** | ![不支持](x.png) | ![支持](v.png) |
| **缩放** | ![支持](v.png) | ![支持](v.png) |
| **旋转** | ![支持](v.png) | ![支持](v.png) |
| **弹跳** | ![支持](v.png) | ![支持](v.png) |


**强调**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **脉冲** | ![不支持](x.png) | ![支持](v.png) |
| **颜色脉冲** | ![不支持](x.png) | ![支持](v.png) |
| **摇摆** | ![支持](v.png) | ![支持](v.png) |
| **旋转** | ![支持](v.png) | ![支持](v.png) |
| **增长/缩小** | ![不支持](x.png) | ![支持](v.png) |
| **去饱和** | ![不支持](x.png) | ![支持](v.png) |
| **变暗** | ![不支持](x.png) | ![支持](v.png) |
| **变亮** | ![不支持](x.png) | ![支持](v.png) |
| **透明度** | ![不支持](x.png) | ![支持](v.png) |
| **对象颜色** | ![不支持](x.png) | ![支持](v.png) |
| **互补颜色** | ![不支持](x.png) | ![支持](v.png) |
| **线条颜色** | ![不支持](x.png) | ![支持](v.png) |
| **填充颜色** | ![不支持](x.png) | ![支持](v.png) |

**退出**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **消失** | ![不支持](x.png) | ![支持](v.png) |
| **渐变** | ![支持](v.png) | ![支持](v.png) |
| **飞出** | ![支持](v.png) | ![支持](v.png) |
| **漂浮出** | ![支持](v.png) | ![支持](v.png) |
| **分裂** | ![支持](v.png) | ![支持](v.png) |
| **擦拭** | ![支持](v.png) | ![支持](v.png) |
| **形状** | ![支持](v.png) | ![支持](v.png) |
| **随机条** | ![支持](v.png) | ![支持](v.png) |
| **缩小与旋转** | ![不支持](x.png) | ![支持](v.png) |
| **缩放** | ![支持](v.png) | ![支持](v.png) |
| **旋转** | ![支持](v.png) | ![支持](v.png) |
| **弹跳** | ![支持](v.png) | ![支持](v.png) |

**运动路径：**

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **直线** | ![支持](v.png) | ![支持](v.png) |
| **弧线** | ![支持](v.png) | ![支持](v.png) |
| **转弯** | ![支持](v.png) | ![支持](v.png) |
| **形状** | ![支持](v.png) | ![支持](v.png) |
| **循环** | ![支持](v.png) | ![支持](v.png) |
| **自定义路径** | ![支持](v.png) | ![支持](v.png) |

## **支持的幻灯片过渡效果**

**细微**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **变形** | ![不支持](x.png) | ![支持](v.png) |
| **渐变** | ![支持](v.png) | ![支持](v.png) |
| **推入** | ![支持](v.png) | ![支持](v.png) |
| **拉入** | ![支持](v.png) | ![支持](v.png) |
| **擦拭** | ![支持](v.png) | ![支持](v.png) |
| **分裂** | ![支持](v.png) | ![支持](v.png) |
| **揭示** | ![不支持](x.png) | ![支持](v.png) |
| **随机条** | ![支持](v.png) | ![支持](v.png) |
| **形状** | ![不支持](x.png) | ![支持](v.png) |
| **揭开** | ![不支持](x.png) | ![支持](v.png) |
| **覆盖** | ![支持](v.png) | ![支持](v.png) |
| **闪光** | ![支持](v.png) | ![支持](v.png) |
| **条带** | ![支持](v.png) | ![支持](v.png) |

**激动人心**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **倒下** | ![不支持](x.png) | ![支持](v.png) |
| **悬挂** | ![不支持](x.png) | ![支持](v.png) |
| **窗帘** | ![不支持](x.png) | ![支持](v.png) |
| **风** | ![不支持](x.png) | ![支持](v.png) |
| **威望** | ![不支持](x.png) | ![支持](v.png) |
| **破裂** | ![不支持](x.png) | ![支持](v.png) |
| **压碎** | ![不支持](x.png) | ![支持](v.png) |
| **揭掉** | ![不支持](x.png) | ![支持](v.png) |
| **翻页** | ![不支持](x.png) | ![支持](v.png) |
| **飞机** | ![不支持](x.png) | ![支持](v.png) |
| **折纸** | ![不支持](x.png) | ![支持](v.png) |
| **溶解** | ![支持](v.png) | ![支持](v.png) |
| **棋盘格** | ![不支持](x.png) | ![支持](v.png) |
| **百叶窗** | ![不支持](x.png) | ![支持](v.png) |
| **时钟** | ![支持](v.png) | ![支持](v.png) |
| **涟漪** | ![不支持](x.png) | ![支持](v.png) |
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

**动态内容**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **摆动** | ![不支持](x.png) | ![支持](v.png) |
| **摩天轮** | ![支持](v.png) | ![支持](v.png) |
| **传送带** | ![不支持](x.png) | ![支持](v.png) |
| **旋转** | ![不支持](x.png) | ![支持](v.png) |
| **轨道** | ![不支持](x.png) | ![支持](v.png) |
| **飞行通过** | ![支持](v.png) | ![支持](v.png) |
