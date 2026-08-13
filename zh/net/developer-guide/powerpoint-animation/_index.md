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
- 动画时间轴
- 交互式动画
- 自定义动画
- 形状动画
- 动态图表
- 动画文本
- 动态图形
- 动画 OLE 对象
- 动画图像
- 动画表格
- PowerPoint 演示文稿
- .NET
- C#
- Aspose.Slides
description: "探索 Aspose.Slides for .NET 处理 PowerPoint 动画的能力。本概述突出了关键特性，并提供提升演示文稿的见解。"
---
## **简介**

由于演示文稿的目的是展示内容，在创建时始终需要考虑其视觉外观和交互行为。

**PowerPoint 动画** 在使演示文稿引人注目、吸引观众方面起着重要作用。Aspose.Slides for .NET 提供了丰富的选项，可为 PowerPoint 演示文稿添加动画：

- 对形状、图表、表格、OLE 对象以及其他演示元素应用各种 PowerPoint 动画效果。
- 在单个形状上使用多个 PowerPoint 动画效果。
- 利用动画时间轴控制动画效果。
- 创建自定义动画。

在 Aspose.Slides for .NET 中，可以对形状应用各种动画效果。由于幻灯片上的每个元素，包括文本、图片、OLE 对象和表格，都被视为形状，动画效果可以应用于幻灯片上的任意元素。

[Aspose.Slides.Animation](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/) namespace 提供了用于操作 PowerPoint 动画的类。

## **动画效果**

Aspose.Slides 支持 **150 多种动画效果**，包括 Bounce、PathFootball、Zoom 等基础效果，以及 OLEObjectShow、OLEObjectOpen 等特定效果。完整的动画效果列表可在 [EffectType](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/effecttype) 枚举中找到。

此外，这些动画效果还能与以下内容组合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/seteffect)

## **自定义动画**

在 Aspose.Slides 中可以创建自己的 **自定义动画**。这可以通过将多个行为组合成新的自定义动画来实现。

[Behaviour](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/behavior) 是任何 PowerPoint 动画效果的构建块。所有动画效果本质上是一组行为组合而成的策略。您可以将行为组合成一次性自定义动画，并在其他演示文稿中重复使用。如果向标准 PowerPoint 动画效果添加新行为，它将成为另一个自定义动画。例如，您可以向动画添加重复行为，使其重复若干次。

[Animation Point](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/point) 是应应用行为的点。

## **动画时间轴**

[Sequence](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/sequence) 是应用于特定形状的动画效果集合。

[Timeline](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/animationtimeline) 是在特定幻灯片中使用的序列集合。它是 PowerPoint 2002 引入的动画引擎。在早期版本的 PowerPoint 中，向演示文稿添加动画效果非常困难，只能通过各种变通方法实现。时间轴取代了旧的 AnimationSettings 类，并为 PowerPoint 动画提供了更清晰的对象模型。每张幻灯片只能拥有一个动画时间轴。

## **交互式动画**

[Trigger](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/effecttriggertype) 允许您定义用户操作（例如按钮点击），以启动特定动画。触发器在最新版本的 PowerPoint 中引入。

## **形状动画**

Aspose.Slides 允许您对形状应用动画，形状可以包括文本、矩形、线条、框架、OLE 对象等。

{{% alert color="info" %}} 
阅读更多 [**关于形状动画**](/slides/zh/net/shape-animation/)。
{{% /alert %}}

## **动态图表**

要创建动态图表，您应使用与形状相同的类。不过，PowerPoint 动画只能应用于图表类别或图表系列。您也可以对类别元素或系列元素应用动画效果。

{{% alert color="info" %}} 
阅读更多 [**关于动态图表**](/slides/zh/net/animated-charts/)。
{{% /alert %}}

## **动态图文**

除了动态图文之外，还可以对段落应用动画。

{{% alert color="info" %}} 
阅读更多 [**关于动态图文**](/slides/zh/net/animated-text/)。
{{% /alert %}}

## **常见问题**

### 将演示文稿导出为 PDF 时动画会被保留吗？

不会。PDF 是静态格式，动画和 [幻灯片切换](/slides/zh/net/slide-transition/) 不会播放。如果需要动画效果，请导出为 [HTML5](/slides/zh/net/export-to-html5/)、[动画 GIF](/slides/zh/net/convert-powerpoint-to-animated-gif/) 或 [视频](/slides/zh/net/convert-powerpoint-to-video/)。

### 能否将带动画的演示文稿转换为视频，并控制帧率和分辨率？

可以。您可以 [将演示文稿渲染为帧](/slides/zh/net/convert-powerpoint-to-video/)，然后使用 ffmpeg 等工具编码为视频，选择 FPS 和分辨率。渲染过程中会播放动画和幻灯片切换。

### 在处理 ODP（不仅限于 PPTX）时动画会保持完整吗？

PPT、PPTX 和 ODP 都支持 [读取](/slides/zh/net/open-presentation/) 和 [写入](/slides/zh/net/save-presentation/)，但由于格式差异，某些效果可能会出现轻微的外观或行为差异。请使用真实样本验证关键场景。