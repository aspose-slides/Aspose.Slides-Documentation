---
title: PowerPoint 动画
type: docs
weight: 150
url: /cpp/powerpoint-animation/
keywords: "PowerPoint 动画"
description: "使用 Aspose.Slides 进行 PowerPoint 动画，PowerPoint 幻灯片动画。"
---

因为演示文稿的目的是展示某些内容，所以在创建它们时始终会考虑其视觉外观和交互行为。

**PowerPoint 动画** 在使演示文稿对观众引人注目和具有吸引力方面发挥着重要作用。Aspose.Slides for C++ 提供了多种选项来为 PowerPoint 演示文稿添加动画：

- 在形状、图表、表格、OLE 对象和其他演示元素上应用各种类型的 PowerPoint 动画效果。
- 在一个形状上使用多个 PowerPoint 动画效果。
- 使用动画时间轴来控制动画效果。
- 创建自定义动画。

在 Aspose.Slides for C++ 中，可以在形状上应用各种动画效果。由于幻灯片上的每个元素（包括文本、图片、OLE 对象、表格等）都被视为一个形状，这意味着我们可以在幻灯片的每个元素上应用动画效果。

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation) **命名空间** 提供用于处理 PowerPoint 动画的类。
## **动画效果**
Aspose.Slides 支持 **150+ 种动画效果**，包括基本动画效果，如 Bounce、PathFootball、Zoom 效果及特定动画效果，如 OLEObjectShow、OLEObjectOpen。您可以在 [**EffectType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) 枚举中找到动画效果的完整列表。

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
可以在 Aspose.Slides 中创建您自己的 **自定义动画**。
这可以通过将多个行为组合成新的自定义动画来实现。

[**Behavior**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.behavior) 是任何 PowerPoint 动画效果的构建单元。所有动画效果实际上都是组合成一种策略的行为集合。您可以将行为组合成自定义动画一次，并在其他演示文稿中重复使用它。如果您将新行为添加到标准 PowerPoint 动画效果中，它将成为另一个自定义动画。例如，您可以向动画添加重复行为，使其重复几次。

[**Animation Point**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.point) 是应该应用行为的点。

## **动画时间线**
[**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) 是应用于具体形状的动画效果集合。

[**AnimationTimeLine**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.animation_time_line) 是用于具体幻灯片的一组序列。它是自 PowerPoint 2002 开始引入的动画引擎。在早期的 PowerPoint 版本中，添加动画效果到演示文稿是具有挑战性的，只能通过不同的变通方法来实现。时间线取代了旧的 AnimationSettings 类，并提供了更加清晰的 PowerPoint 动画对象模型。一张幻灯片只能有一个动画时间线。
## **交互式动画**
[**EffectTriggerType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) 允许定义用户操作（例如按钮点击），将使某个特定的动画开始。触发器仅在最新的 PowerPoint 版本中添加。

## **形状动画**
Aspose.Slides 允许对形状应用动画，这些形状实际上可以是文本、矩形、线条、框架、OLE 对象等。

{{% alert color="primary" %}} 
阅读更多 [**关于形状动画**](/slides/cpp/shape-animation/)。
{{% /alert %}}

## **动画图表**
要创建动画图表，您应使用与形状相同的所有类。然而，PowerPoint 动画只能在图表类别或图表系列上使用。您还可以对类别元素或系列元素应用动画效果。

{{% alert color="primary" %}} 
阅读更多 [**关于动画图表**](/slides/cpp/animated-charts/)。
{{% /alert %}}

## **动画文本**
除了动画文本外，还可以对段落应用动画。

{{% alert color="primary" %}} 
阅读更多 [**关于动画文本**](/slides/cpp/animated-text/)。
{{% /alert %}}