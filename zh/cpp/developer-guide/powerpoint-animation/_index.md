---
title: 使用 C++ 为 PowerPoint 演示文稿添加动画
linktitle: PowerPoint 动画
type: docs
weight: 150
url: /zh/cpp/powerpoint-animation/
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
- 动态文本
- 动态形状
- 动态 OLE 对象
- 动态图像
- 动态表格
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中添加和控制高级动画效果，以构建动态的 PowerPoint 和 OpenDocument 演示文稿。"
---

由于演示文稿旨在展示内容，在创建时始终会考虑其视觉外观和交互行为。

**PowerPoint animation** 在使演示文稿引人注目并吸引观众方面发挥着重要作用。Aspose.Slides for C++ 提供了广泛的选项来为 PowerPoint 演示文稿添加动画：

- 在形状、图表、表格、OLE 对象和其他演示元素上应用各种类型的 PowerPoint 动画效果。
- 在形状上使用多个 PowerPoint 动画效果。
- 使用动画时间线来控制动画效果。
- 创建自定义动画。

在 Aspose.Slides for C++ 中，可以在形状上应用各种动画效果。由于幻灯片上的每个元素（包括文本、图片、OLE 对象、表格等）都被视为形状，这意味着我们可以对幻灯片的每个元素应用动画效果。

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation) **命名空间** 提供用于处理 PowerPoint 动画的类。

## **动画效果**
Aspose.Slides 支持 **150+ 动画效果**，包括基本动画效果，如 Bounce、PathFootball、Zoom 效果，以及特定的动画效果，如 OLEObjectShow、OLEObjectOpen。您可以在 [**EffectType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) 枚举中找到完整的动画效果列表。

此外，这些动画效果可以与它们组合使用：
- [ColorEffect](https://reference.aspose.com/slides/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.set_effect)

## **自定义动画**
在 Aspose.Slides 中可以创建您自己的 **自定义动画**。如果将多个行为组合成新的自定义动画，即可实现此目的。

[**Behavior**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.behavior) 是任何 PowerPoint 动画效果的构建单元。所有动画效果实际上是一组行为组合成的策略。您可以一次将行为组合成自定义动画，并在其他演示文稿中复用它。如果向标准 PowerPoint 动画效果中添加新的行为——它将成为另一个自定义动画。例如，您可以向动画添加重复行为，使其重复几次。

[**Animation Point**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.point) 是应当应用行为的点。

## **动画时间线**
[**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) 是一组应用于特定形状的动画效果的集合。

[**AnimationTimeLine**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.animation_time_line) 是在特定幻灯片中使用的一组 Sequence。自 PowerPoint 2002 起，它作为动画引擎出现。在以前的 PowerPoint 版本中，向演示文稿添加动画效果较为困难，只能通过各种变通方法实现。时间线用于取代旧的 AnimationSettings 类，并为 PowerPoint 动画提供更清晰的对象模型。每张幻灯片只能拥有一个动画时间线。

## **交互式动画**
[**EffectTriggerType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) 允许定义用户操作（例如按钮点击），从而启动特定动画。触发器仅在最新的 PowerPoint 版本中添加。

## **形状动画**
Aspose.Slides 允许对形状应用动画，形状实际上可以是文本、矩形、线条、框架、OLE 对象等。

{{% alert color="primary" %}} 
阅读更多 [**关于形状动画**](/slides/zh/cpp/shape-animation/).
{{% /alert %}}

## **动态图表**
要创建动态图表，您应使用与形状相同的所有类。不过，PowerPoint 动画只能应用于图表的类别或系列。您也可以对类别元素或系列元素应用动画效果。

{{% alert color="primary" %}} 
阅读更多 [**关于动态图表**](/slides/zh/cpp/animated-charts/).
{{% /alert %}}

## **动态文本**
除了动态文本外，还可以对段落应用动画。

{{% alert color="primary" %}} 
阅读更多 [**关于动态文本**](/slides/zh/cpp/animated-text/).
{{% /alert %}}

## **常见问题**

**将动画在导出为 PDF 时会保留吗？**
不。PDF 是静态格式，因此动画和 [幻灯片切换](/slides/zh/cpp/slide-transition/) 不会播放。如果需要动态效果，请改为导出为 [HTML5](/slides/zh/cpp/export-to-html5/)、[animated GIF](/slides/zh/cpp/convert-powerpoint-to-animated-gif/) 或 [video](/slides/zh/cpp/convert-powerpoint-to-video/)。

**我可以将动画演示文稿转换为视频，并控制帧率和帧大小吗？**
是的。您可以 [将演示文稿渲染为帧](/slides/zh/cpp/convert-powerpoint-to-video/) 并将其编码为视频（例如使用 ffmpeg），从而选择 FPS 和分辨率。在渲染过程中，动画和幻灯片切换会被播放。

**在使用 ODP（而非仅 PPTX）时，动画会保持完整吗？**
PPT、PPTX 和 ODP 均受支持，可用于 [读取](/slides/zh/cpp/open-presentation/) 和 [写入](/slides/zh/cpp/save-presentation/)，但格式差异可能导致某些效果在外观或行为上略有不同。请使用真实样本验证关键情况。