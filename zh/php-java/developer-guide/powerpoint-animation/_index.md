---
title: 在 PHP 中使用动画增强 PowerPoint 演示文稿
linktitle: PowerPoint 动画
type: docs
weight: 150
url: /zh/php-java/powerpoint-animation/
keywords:
- 添加动画
- 更新动画
- 更改动画
- 移除动画
- 管理动画
- 控制动画
- 动画效果
- PowerPoint 动画
- 动画时间轴
- 交互动画
- 自定义动画
- 形状动画
- 动彩图表
- 动画文字
- 动画形状
- 动画 OLE 对象
- 动画图像
- 动画表格
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "探索 Aspose.Slides for PHP via Java 处理 PowerPoint 动画的功能。关键特性和深入洞见帮助您提升演示文稿。"
---

由于演示文稿旨在展示内容，在创建时始终会考虑其视觉外观和交互行为。

**PowerPoint 动画** 在使演示文稿更具吸引力和视觉冲击力方面发挥重要作用。Aspose.Slides for PHP via Java 提供了多种向 PowerPoint 演示文稿添加动画的选项：

- 对形状、图表、表格、OLE 对象和其他演示元素应用各种 PowerPoint 动画效果。
- 对同一形状使用多个 PowerPoint 动画效果。
- 使用动画时间轴来控制动画效果。
- 创建自定义动画。

在 Aspose.Slides for PHP via Java 中，可以在形状上应用各种动画效果。由于幻灯片上的每个元素（包括文本、图片、OLE 对象、表格等）都被视为形状，这意味着我们可以对幻灯片的每个元素应用动画效果。

## **动画效果**
Aspose.Slides 支持 **150+ 动画效果**，包括 Bounce、PathFootball、Zoom 等基本动画效果以及 OLEObjectShow、OLEObjectOpen 等特定动画效果。您可以在 [**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype) 枚举中找到完整的动画效果列表。

此外，这些动画效果还可以与以下效果组合使用：

- [ColorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/php-java/aspose.slides/SetEffect)

## **自定义动画**
可以在 Aspose.Slides 中创建自己的 **自定义动画**。通过将多个行为组合成新的自定义动画即可实现。

[**Behavior**](https://reference.aspose.com/slides/php-java/aspose.slides/Behavior) 是任何 PowerPoint 动画效果的构建单元。所有动画效果本质上是一组行为的集合，组合成一种策略。您可以一次性将行为组合成自定义动画，并在其他演示文稿中复用。如果向标准 PowerPoint 动画效果中添加新行为，它就会成为另一个自定义动画。例如，您可以向动画添加重复行为，使其重复几次。

[**Animation Point**](https://reference.aspose.com/slides/php-java/aspose.slides/Point) 是应应用行为的具体点。

## **动画时间线**
[**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) 是应用于具体形状的一组动画效果。

[**Timeline**](https://reference.aspose.com/slides/php-java/aspose.slides/AnimationTimeLine) 是在具体幻灯片中使用的 Sequence 集合。它是自 PowerPoint 2002 起引入的动画引擎。在之前的 PowerPoint 版本中，向演示文稿添加动画效果相当困难，只能通过各种变通办法实现。Timeline 用于取代旧的 AnimationSettings 类，并提供更清晰的 PowerPoint 动画对象模型。每个幻灯片只能拥有 **一个** 动画时间线。

## **交互动画**
[**Trigger**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectTriggerType) 允许定义用户操作（例如按钮点击），从而触发特定动画。触发器仅在最新的 PowerPoint 版本中加入。

## **形状动画**
Aspose.Slides 允许对形状（如文本、矩形、线条、框架、OLE 对象等）应用动画。

{{% alert color="primary" %}} 
阅读更多 [**关于形状动画**](/slides/zh/php-java/shape-animation/)。
{{% /alert %}}

## **动态图表**
创建动态图表时，使用的类与形状相同。不过，PowerPoint 动画只能应用于图表类别或系列。您也可以对类别元素或系列元素应用动画效果。

{{% alert color="primary" %}} 
阅读更多 [**关于动态图表**](/slides/zh/php-java/animated-charts/)。
{{% /alert %}}

## **动画文字**
除了动画文字外，还可以对段落应用动画。

{{% alert color="primary" %}} 
阅读更多 [**关于动画文字**](/slides/zh/php-java/animated-text/)。
{{% /alert %}}

## **常见问题**

**导出为 PDF 时动画会保留吗？**

不会。PDF 是静态格式，动画和[幻灯片切换](/slides/zh/php-java/slide-transition/)不会播放。如果需要动画效果，请导出为 [HTML5](/slides/zh/php-java/export-to-html5/)、[动画 GIF](/slides/zh/php-java/convert-powerpoint-to-animated-gif/) 或 [视频](/slides/zh/php-java/convert-powerpoint-to-video/)。

**我可以将动画演示文稿转换为视频，并控制帧率和帧大小吗？**

可以。您可以[将演示文稿渲染为帧](/slides/zh/php-java/convert-powerpoint-to-video/)，然后使用 ffmpeg 等工具将其编码为视频，选择 FPS 和分辨率。在渲染过程中会播放动画和幻灯片切换。

**在处理 ODP（而不仅仅是 PPTX）时动画会保持完整吗？**

PPT、PPTX 和 ODP 均支持[读取](/slides/zh/php-java/open-presentation/)和[写入](/slides/zh/php-java/save-presentation/)，但由于格式差异，某些效果可能在外观或行为上略有不同。请使用真实样本验证关键场景。