---
title: 在 Python 中使用动画增强 PowerPoint 演示文稿
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
- 动态图表
- 动画文本
- 动画形状
- 动画 OLE 对象
- 动画图像
- 动画表格
- PowerPoint 演示文稿
- Python
- Aspose.Slides
description: "探索 Aspose.Slides for Python via .NET 在处理 PowerPoint 动画方面的功能。本概述重点介绍关键特性，并提供提升演示文稿的见解。"
---
## **介绍**

演示文稿旨在传递信息，因此其视觉外观和交互行为是创建过程中关键的考虑因素。

**PowerPoint 动画** 在使演示文稿引人注目并吸引观众方面发挥重要作用。Aspose.Slides for Python via .NET 提供了多种向 PowerPoint 演示文稿添加动画的选项。您可以：

- 将各种动画效果应用于形状、图表、表格、OLE 对象和其他元素。
- 对单个形状使用多个动画效果。
- 通过动画时间线控制效果。
- 创建自定义动画。

在 Aspose.Slides for Python via .NET 中，动画效果可以应用于形状。因为幻灯片上的每个元素——包括文本、图片、OLE 对象和表格——都被视为形状，所以您可以对幻灯片上的任何元素应用动画效果。

[aspose.slides.animation](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/) 命名空间提供了用于处理 PowerPoint 动画的类。

## **安装**

```bash
pip install aspose.slides
```

## **在 Python 中向形状添加动画效果**

动画效果位于幻灯片的主序列上。添加一个形状，然后在 `slide.timeline.main_sequence` 上调用 `add_effect`，传入效果类型、子类型以及触发它的触发器。

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

保存的文件在第一张幻灯片上包含一个效果：矩形从左侧飞入，持续两秒，在演示者点击时触发。重新打开并读取 `slide.timeline.main_sequence` 会返回该效果，因此动画在往返过程中得以保留，而不仅仅存在于内存中。

## **动画效果**

Aspose.Slides 支持 **150+ 动画效果**，包括 Bounce、PathFootball、Zoom 等基本效果，以及 OLEObjectShow、OLEObjectOpen 等专用效果。完整列表可在 [EffectType](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/effecttype/) 枚举中找到。

此外，这些动画效果还可以与以下效果组合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/seteffect/)

## **自定义动画**

您可以通过将多个行为组合成单个效果，在 Aspose.Slides 中创建自己的 **自定义动画**。

[Behavior](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/behavior/) 是任何 PowerPoint 动画效果的基本构建块。每个动画效果本质上是一组行为，排列成一个策略或时间线。您可以将行为组合成一次性自定义动画，并在其他演示文稿中复用。如果向标准 PowerPoint 动画效果添加新行为，它就会变成自定义动画——例如，添加重复行为使动画播放多次。

[Animation Point](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/point/) 标记行为应用的时刻或位置（关键帧）。

## **动画时间线**

[Sequence](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/sequence/) 是对特定形状应用的动画效果的集合。

[Timeline](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/animationtimeline/) 是在特定幻灯片上使用的序列集合。它于 PowerPoint 2002 引入。在早期的 PowerPoint 版本中，添加动画效果非常困难，常常需要变通方法。Timeline 替代了旧的 `AnimationSettings` 类，提供了更清晰的 PowerPoint 动画对象模型。每张幻灯片只能拥有一个动画时间线。

## **交互式动画**

[Trigger](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/effecttriggertype/) 允许您定义用户操作（例如按钮点击），以启动特定动画。触发器仅在最新版本的 PowerPoint 中添加。

## **形状动画**

Aspose.Slides 使您能够对形状——如文本、矩形、线条、框架、OLE 对象等——应用动画。

{{% alert color="primary" %}}
了解更多 [**About Shape Animation**](/slides/zh/python-net/shape-animation/).
{{% /alert %}}

## **动态图表**

要创建动态图表，请使用与形状相同的类。不过，PowerPoint 动画只能应用于图表类别或图表系列。您也可以对单个类别元素或系列元素应用动画效果。

{{% alert color="primary" %}}
了解更多 [**About Animated Charts**](/slides/zh/python-net/animated-charts/).
{{% /alert %}}

## **动画文本**

除了对文本进行动画处理外，您还可以对段落应用动画。

{{% alert color="primary" %}}
了解更多 [**About Animated Text**](/slides/zh/python-net/animated-text/).
{{% /alert %}}

## **常见问题**

### 导出为 PDF 时动画会被保留吗？

否。PDF 是一种静态格式，动画和 [slide transitions](/slides/zh/python-net/slide-transition/) 不会播放。如果需要 motion，请改为导出为 [HTML5](/slides/zh/python-net/export-to-html5/)、[animated GIF](/slides/zh/python-net/convert-powerpoint-to-animated-gif/) 或 [video](/slides/zh/python-net/convert-powerpoint-to-video/)。

### 我可以将动画演示文稿转换为视频并控制帧速率和帧大小吗？

是。您可以 [render the presentation as frames](/slides/zh/python-net/convert-powerpoint-to-video/) 并使用 ffmpeg 等工具将其编码为视频，选择 FPS 和分辨率。渲染过程中会播放动画和幻灯片切换。

### 在处理 ODP（不仅仅是 PPTX）时动画会保持完整吗？

PPT、PPTX 和 ODP 均受支持，可用于 [reading](/slides/zh/python-net/open-presentation/) 和 [writing](/slides/zh/python-net/save-presentation/)。但格式差异可能导致某些效果的外观或行为略有不同。请使用真实样本验证关键场景。