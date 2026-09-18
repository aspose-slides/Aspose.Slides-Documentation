---
title: 使用 Python 为 PowerPoint 演示文稿添加动画
linktitle: PowerPoint 动画
type: docs
weight: 150
url: /zh/python-net/powerpoint-animation/
keywords:
- 添加动画
- 更新动画
- 更改动画
- 删除动画
- 管理动画
- 控制动画
- 动画效果
- PowerPoint 动画
- 动画时间线
- 交互式动画
- 自定义动画
- 形状动画
- 动画图表
- 动画文本
- 动画形状
- 动画 OLE 对象
- 动画图像
- 动画表格
- PowerPoint 演示文稿
- Python
- Aspose.Slides
description: "探索 Aspose.Slides for Python via .NET 处理 PowerPoint 动画的功能。此总体概述突出关键特性并提供提升演示文稿的见解。"
---
## **简介**

演示文稿的设计旨在传达信息，因此在创建过程中，视觉外观和交互行为是关键考虑因素。

**PowerPoint animation** 在使演示文稿吸引人并令人投入方面发挥重要作用。Aspose.Slides for Python via .NET 提供了丰富的选项来为 PowerPoint 演示文稿添加动画。您可以：

- 对形状、图表、表格、OLE 对象和其他元素应用各种动画效果。
- 在单个形状上使用多个动画效果。
- 通过动画时间线控制效果。
- 创建自定义动画。

在 Aspose.Slides for Python via .NET 中，动画效果可以应用于形状。因为幻灯片上的每个元素——包括文本、图片、OLE 对象和表格——都被视为形状，您可以对幻灯片上的任何元素应用动画效果。

The [aspose.slides.animation](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/) namespace provides the classes for working with PowerPoint animations.

## **安装**

```bash
pip install aspose.slides
```

## **在 Python 中向形状添加动画效果**

Animation effects live on a slide's main sequence. Add a shape, then call `add_effect` on `slide.timeline.main_sequence`, passing the effect type, its subtype, and the trigger that starts it.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 100)
    shape.text_frame.text = "Animated shape"

    sequence = slide.timeline.main_sequence
    effect = sequence.add_effect(
        shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.LEFT,
        slides.animation.EffectTriggerType.ON_CLICK,
    )
    effect.timing.duration = 2.0

    presentation.save("animated.pptx", slides.export.SaveFormat.PPTX)
```

保存的文件在第一张幻灯片上包含一个效果：矩形从左侧飞入，历时两秒，当演示者点击时触发。重新打开并读取 `slide.timeline.main_sequence` 将返回该效果，因此动画在往返过程中能够保留下来，而不是仅存在于内存中。

## **动画效果**

Aspose.Slides supports **150+ animation effects**, including basic effects such as Bounce, PathFootball, and Zoom, as well as specialized effects like OLEObjectShow and OLEObjectOpen. You can find the full list in the [EffectType](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/effecttype/) enumeration.

此外，这些动画效果可以与以下效果组合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/seteffect/)

## **自定义动画**

For complete Python examples that create, inspect, and modify behaviors and editable motion paths, see [Custom Animation](/slides/zh/python-net/custom-animation/).

您可以通过将多个行为组合成单个效果，在 Aspose.Slides 中创建自己的**custom animations**。

[Behavior](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/behavior/) 是 PowerPoint 动画效果的构建块。将行为组合以自定义效果，或添加行为以扩展预定义效果。重复通过时间设置配置，而不是使用单独的 repeat 行为。

[Animation Point](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/point/) 标记行为应用的时刻或位置（关键帧）。

## **动画时间线**

[Sequence](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/sequence/) 是一组可以针对不同形状的动画效果的集合。

[Timeline](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/animationtimeline/) 是在特定幻灯片上使用的序列集合。它在 PowerPoint 2002 中引入。在早期版本的 PowerPoint 中，添加动画效果比较困难，通常需要变通方法。Timeline 取代了旧的 `AnimationSettings` 类，提供了更清晰的 PowerPoint 动画对象模型。每张幻灯片只能有一个动画时间线。

## **交互式动画**

[Trigger](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/effecttriggertype/) 允许您定义用户操作（例如按钮点击），以启动特定动画。Trigger 仅在最新版本的 PowerPoint 中加入。

## **形状动画**

Aspose.Slides 让您可以对形状——如文本、矩形、线条、框架、OLE 对象等——应用动画。

{{% alert color="info" title="Note" %}}
了解更多 [**关于形状动画**](/slides/zh/python-net/shape-animation/)。
{{% /alert %}}

## **动画图表**

要创建动画图表，请使用与形状相同的类。但 PowerPoint 动画只能应用于图表类别或图表系列。您也可以对单个类别元素或系列元素应用动画效果。

{{% alert color="info" title="Note" %}}
了解更多 [**关于动画图表**](/slides/zh/python-net/animated-charts/)。
{{% /alert %}}

## **动画文本**

除了对文本进行动画处理外，您还可以对段落应用动画。

{{% alert color="info" title="Note" %}}
了解更多 [**关于动画文本**](/slides/zh/python-net/animated-text/)。
{{% /alert %}}

## **常见问题**

**导出为 PDF 时，动画会被保留吗？**

不。PDF 是一种静态格式，因此动画和[slide transitions](/slides/zh/python-net/slide-transition/)不会播放。如果需要动态效果，请改为导出为[HTML5](/slides/zh/python-net/export-to-html5/)、[animated GIF](/slides/zh/python-net/convert-powerpoint-to-animated-gif/)或[video](/slides/zh/python-net/convert-powerpoint-to-video/)。

**我可以将动画演示文稿转换为视频，并控制帧率和帧尺寸吗？**

可以。您可以[将演示文稿渲染为帧](/slides/zh/python-net/convert-powerpoint-to-video/)，然后使用 ffmpeg 等工具将这些帧编码为视频，选择所需的 FPS 和分辨率。渲染过程中会播放动画和幻灯片切换效果。

**在使用 ODP（而非 PPTX）时，动画会保持完整吗？**

PPT、PPTX 和 ODP 都支持[读取](/slides/zh/python-net/open-presentation/)和[写入](/slides/zh/python-net/save-presentation/)，但这并不保证动画会被保留。转换为 ODP 时，custom animation 数据可能会丢失。请参阅[Custom Animation](/slides/zh/python-net/custom-animation/)获取示例和检查格式兼容性的指南。