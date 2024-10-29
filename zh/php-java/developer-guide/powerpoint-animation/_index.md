---
title: PowerPoint 动画
type: docs
weight: 150
url: /zh/php-java/powerpoint-animation/
keywords: "PowerPoint 动画"
description: "PowerPoint 动画，使用 Aspose.Slides 进行 PowerPoint 幻灯片动画。"
---

由于演示文稿旨在展示某些内容，因此在创建时总是考虑其视觉外观和互动行为。

**PowerPoint 动画** 在使演示吸引眼球和对观众具有吸引力方面起着重要作用。Aspose.Slides for PHP via Java 提供了丰富的选项来为 PowerPoint 演示文稿添加动画：

- 在形状、图表、表格、OLE 对象和其他演示元素上应用各种类型的 PowerPoint 动画效果。
- 在一个形状上使用多个 PowerPoint 动画效果。
- 使用动画时间线控制动画效果。
- 创建自定义动画。

在 Aspose.Slides for PHP via Java 中，可以在形状上应用各种动画效果。由于幻灯片上的每个元素（包括文本、图片、OLE 对象、表格等）都被视为一个形状，这意味着我们可以在幻灯片的每个元素上应用动画效果。

## **动画效果**
Aspose.Slides 支持 **150+ 种动画效果**，包括基本动画效果如 Bounce、PathFootball、缩放效果，以及特定动画效果如 OLEObjectShow、OLEObjectOpen。您可以在 [**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype) 枚举中找到动画效果的完整列表。

此外，这些动画效果可以与以下效果组合使用：

- [ColorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/php-java/aspose.slides/SetEffect)

## **自定义动画**
在 Aspose.Slides 中有可能创建您自己的 **自定义动画**。 
这可以通过将多个行为结合在一起形成新的自定义动画来实现。

[**Behavior**](https://reference.aspose.com/slides/php-java/aspose.slides/Behavior) 是任何 PowerPoint 动画效果的构建单元。所有动画效果实际上是一组组合成一个策略的行为。您可以将行为组合成一个自定义动画，并在其他演示文稿中重复使用。如果您将新行为添加到标准 PowerPoint 动画效果中，它将成为另一个自定义动画。例如，您可以向动画添加重复行为，使其重复几次。

[**Animation Point**](https://reference.aspose.com/slides/php-java/aspose.slides/Point) 是应应用行为的点。

## **动画时间线**
[**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) 是应用于具体形状的动画效果集合。

[**Timeline**](https://reference.aspose.com/slides/php-java/aspose.slides/AnimationTimeLine) 是在具体幻灯片中使用的一组序列。它是自 PowerPoint 2002 以来的动画引擎。在早期的 PowerPoint 版本中，向演示文稿添加动画效果是具有挑战性的，这只能通过不同的解决方法来实现。时间线取代了旧的 AnimationSettings 类，并为 PowerPoint 动画提供了更清晰的对象模型。一个幻灯片只能有一个动画时间线。

## **交互式动画**
[**Trigger**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectTriggerType) 允许定义用户动作（例如按钮点击），将使某个动画开始。触发器仅在最新的 PowerPoint 版本中添加。

## **形状动画**
Aspose.Slides 允许在形状上应用动画，这些形状实际上可以是文本、矩形、线条、框架、OLE 对象等。

{{% alert color="primary" %}} 
阅读更多 [**关于形状动画**](/slides/zh/php-java/shape-animation/)。
{{% /alert %}}

## **动画图表**
要创建动画图表，您应使用与形状相同的类。然而，仅对图表类别或图表系列可以使用 PowerPoint 动画。您还可以将动画效果应用于类别元素或系列元素。

{{% alert color="primary" %}} 
阅读更多 [**关于动画图表**](/slides/zh/php-java/animated-charts/)。
{{% /alert %}}

## **动画文本**
除了动画文本，还可以对段落应用动画。

{{% alert color="primary" %}} 
阅读更多 [**关于动画文本**](/slides/zh/php-java/animated-text/)。
{{% /alert %}}