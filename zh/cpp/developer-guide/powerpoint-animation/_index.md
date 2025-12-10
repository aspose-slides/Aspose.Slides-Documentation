---
title: 在 C++ 中使用动画增强 PowerPoint 演示文稿
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
- 动画时间轴
- 交互式动画
- 自定义动画
- 形状动画
- 动画图表
- 动画文本
- 动画形状
- 动画 OLE 对象
- 动画图像
- 动画表格
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中添加和控制高级动画效果，以创建动态的 PowerPoint 和 OpenDocument 演示文稿。"
---

由于演示文稿的目的是展示内容，在创建演示文稿时始终会考虑其视觉外观和交互行为。

**PowerPoint 动画** 在使演示文稿引人注目、吸引观众方面起着重要作用。Aspose.Slides for C++ 提供了丰富的选项来向 PowerPoint 演示文稿添加动画：

- 对形状、图表、表格、OLE 对象和其他演示元素应用各种类型的 PowerPoint 动画效果。
- 在形状上使用多个 PowerPoint 动画效果。
- 使用动画时间轴控制动画效果。
- 创建自定义动画。

In Aspose.Slides for C++ 中，可以对形状应用各种动画效果。由于幻灯片上的每个元素（包括文本、图片、OLE 对象、表格等）都视为形状，这意味着我们可以对幻灯片的每个元素应用动画效果。

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation) **命名空间** 提供用于处理 PowerPoint 动画的类。

## **动画效果**
Aspose.Slides 支持 **150+ 动画效果**，包括诸如 Bounce、PathFootball、Zoom 效果等基本动画效果，以及 OLEObjectShow、OLEObjectOpen 等特定动画效果。您可以在 [**EffectType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) 枚举中找到完整的动画效果列表。

此外，这些动画效果可以与以下效果组合使用：

- [ColorEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.color_effect/t)
- [CommandEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.set_effect)

## **自定义动画**
在 Aspose.Slides 中可以创建自己的 **自定义动画**。  
如果将多个行为组合成一个新的自定义动画即可实现此目的。

[**Behavior**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.behavior) 是任何 PowerPoint 动画效果的构建单元。所有动画效果实际上都是一组行为组合而成的策略。您可以将行为组合成一次性自定义动画，并在其他演示文稿中复用。如果向标准 PowerPoint 动画效果中添加新行为——它将成为另一个自定义动画。例如，您可以向动画添加重复行为，使其重复若干次。

[**Animation Point**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.point) 是应当应用行为的点。

## **动画时间线**
[**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) 是在具体形状上应用的动画效果集合。

[**AnimationTimeLine**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.animation_time_line) 是在具体幻灯片中使用的 Sequence 集合。它是自 PowerPoint 2002 起引入的动画引擎。在早期 PowerPoint 版本中，向演示文稿添加动画效果相当困难，只能通过各种变通方法实现。时间线取代了旧的 AnimationSettings 类，并为 PowerPoint 动画提供了更清晰的对象模型。一个幻灯片只能拥有 **唯一** 的动画时间线。

## **交互式动画**
[**EffectTriggerType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) 允许定义用户操作（例如按钮点击），从而触发特定动画。此触发功能仅在最新的 PowerPoint 版本中加入。

## **形状动画**
Aspose.Slides 允许对形状应用动画，形状实际上可以是文本、矩形、线条、框架、OLE 对象等。

{{% alert color="primary" %}} 
了解更多 [**关于形状动画**](/slides/zh/cpp/shape-animation/)。
{{% /alert %}}

## **动画图表**
创建动画图表时，应使用与形状相同的所有类。不过，PowerPoint 动画仅能作用于图表的分类或系列。您也可以对分类元素或系列元素应用动画效果。

{{% alert color="primary" %}} 
了解更多 [**关于动画图表**](/slides/zh/cpp/animated-charts/)。
{{% /alert %}}

## **动画文字**
除了动画文字外，还可以对段落应用动画。

{{% alert color="primary" %}} 
了解更多 [**关于动画文字**](/slides/zh/cpp/animated-text/)。
{{% /alert %}}

## **常见问题**

**导出为 PDF 时动画会保留吗？**

不会。PDF 是静态格式，动画和 [幻灯片切换](/slides/zh/cpp/slide-transition/) 不会播放。如果需要动态效果，请导出为 [HTML5](/slides/zh/cpp/export-to-html5/)、[动画 GIF](/slides/zh/cpp/convert-powerpoint-to-animated-gif/) 或 [视频](/slides/zh/cpp/convert-powerpoint-to-video/)。

**我可以将动画演示文稿转换为视频，并控制帧率和帧大小吗？**

可以。您可以 [将演示文稿渲染为帧](/slides/zh/cpp/convert-powerpoint-to-video/)，然后使用 ffmpeg 等工具将其编码为视频，选择所需的 FPS 和分辨率。渲染过程中会播放动画和幻灯片切换。

**在处理 ODP（不仅限于 PPTX）时动画会保持完整吗？**

PPT、PPTX 和 ODP 均支持 [读取](/slides/zh/cpp/open-presentation/) 和 [写入](/slides/zh/cpp/save-presentation/)，但由于格式差异，某些效果可能在外观或行为上略有不同。请使用真实样本验证关键场景。