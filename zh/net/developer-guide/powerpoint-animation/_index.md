---
title: 使用 .NET 为 PowerPoint 演示文稿添加动画
linktitle: PowerPoint 动画
type: docs
weight: 150
url: /zh/net/powerpoint-animation/
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
- PowerPoint 演示文稿
- .NET
- C#
- Aspose.Slides
description: "探索 Aspose.Slides for .NET 在处理 PowerPoint 动画方面的功能。此概览突出关键特性并提供提升演示文稿的洞见。"
---

## **概述**

由于演示文稿的目的是展示内容，在创建时始终会考虑其视觉外观和交互行为。

**PowerPoint 动画** 在使演示文稿更具吸引力和感染力方面发挥着重要作用。Aspose.Slides for .NET 提供了多种向 PowerPoint 演示文稿添加动画的选项：

- 对形状、图表、表格、OLE 对象以及其他演示元素应用各种类型的 PowerPoint 动画效果。
- 在单个形状上使用多个 PowerPoint 动画效果。
- 利用动画时间线来控制动画效果。
- 创建自定义动画。

在 Aspose.Slides for .NET 中，可以对形状应用各种动画效果。由于幻灯片上的每个元素（包括文本、图片、OLE 对象和表格）都被视为形状，动画效果可以应用于幻灯片上的任意元素。

[Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/) namespace 提供用于处理 PowerPoint 动画的类。

## **动画效果**

Aspose.Slides 支持 **150 多种动画效果**，包括 Bounce、PathFootball、Zoom 等基础效果，以及 OLEObjectShow、OLEObjectOpen 等特定效果。您可以在 [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype) 枚举中找到完整的动画效果列表。

此外，这些动画效果还可以与以下内容结合使用：

- [ColorEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/seteffect)

## **自定义动画**

在 Aspose.Slides 中可以创建自己的 **自定义动画**。通过将多个行为组合成一个新的自定义动画即可实现。

[Behaviour](https://reference.aspose.com/slides/net/aspose.slides.animation/behavior) 是任何 PowerPoint 动画效果的构建块。所有动画效果本质上是一组行为组合而成的策略。您可以将行为组合成自定义动画，并在其他演示文稿中重复使用。如果向标准 PowerPoint 动画效果添加新的行为，它将成为另一个自定义动画。例如，您可以向动画添加重复行为，使其重复若干次。

[Animation Point](https://reference.aspose.com/slides/net/aspose.slides.animation/point) 是应当应用行为的点。

## **动画时间线**

[Sequence](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) 是应用于特定形状的一组动画效果的集合。

[Timeline](https://reference.aspose.com/slides/net/aspose.slides.animation/animationtimeline) 是在特定幻灯片中使用的一组序列。它是 PowerPoint 2002 引入的动画引擎。早期版本的 PowerPoint 中，向演示文稿添加动画效果十分困难，只能通过各种变通方法实现。时间线取代了旧的 AnimationSettings 类，为 PowerPoint 动画提供了更清晰的对象模型。每张幻灯片只能拥有一个动画时间线。

## **交互式动画**

[Trigger](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttriggertype) 允许您定义用户操作（例如按钮点击），以启动特定动画。Trigger 在最新版本的 PowerPoint 中引入。

## **形状动画**

Aspose.Slides 允许您对形状应用动画，形状可以包括文本、矩形、线条、框架、OLE 对象等。

{{% alert color="primary" %}} 
阅读更多 [**关于形状动画**](/slides/zh/net/shape-animation/)。
{{% /alert %}}

## **动态图表**

要创建动态图表，您应使用与形状相同的类。不过，PowerPoint 动画只能应用于图表类别或图表系列。您也可以将动画效果应用于类别元素或系列元素。

{{% alert color="primary" %}} 
阅读更多 [**关于动态图表**](/slides/zh/net/animated-charts/)。
{{% /alert %}}

## **动画文本**

除了动画文本之外，还可以对段落应用动画。

{{% alert color="primary" %}} 
阅读更多 [**关于动画文本**](/slides/zh/net/animated-text/)。
{{% /alert %}}

## **常见问题**

**导出为 PDF 时动画会被保留吗？**

不会。PDF 是静态格式，动画和 [幻灯片切换](/slides/zh/net/slide-transition/) 不会播放。如果需要动态效果，请导出为 [HTML5](/slides/zh/net/export-to-html5/)、[动画 GIF](/slides/zh/net/convert-powerpoint-to-animated-gif/) 或 [视频](/slides/zh/net/convert-powerpoint-to-video/)。

**我可以将动画演示文稿转换为视频并控制帧率和帧大小吗？**

可以。您可以 [将演示文稿渲染为帧](/slides/zh/net/convert-powerpoint-to-video/)，然后使用 ffmpeg 等工具编码为视频，选择所需的 FPS 和分辨率。渲染过程中会播放动画和幻灯片切换。

**在处理 ODP（而不仅仅是 PPTX）时动画会保持完整吗？**

PPT、PPTX 和 ODP 都支持 [读取](/slides/zh/net/open-presentation/) 和 [写入](/slides/zh/net/save-presentation/)，但由于格式差异，某些效果可能会略有不同。请使用真实示例验证关键情况。