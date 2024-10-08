---
title: PowerPoint 动画
type: docs
weight: 150
url: /androidjava/powerpoint-animation/
keywords: "PowerPoint 动画"
description: "PowerPoint 动画，使用 Aspose.Slides 的 PowerPoint 幻灯片动画。"
---

由于演示文稿旨在展示某些内容，因此在创建时始终考虑其视觉外观和交互行为。

**PowerPoint 动画** 在使演示引人注目并吸引观众方面发挥着重要作用。Aspose.Slides for Android 通过 Java 提供了一系列选项，可以向 PowerPoint 演示文稿添加动画：

- 对形状、图表、表格、OLE 对象和其他演示元素应用各种类型的 PowerPoint 动画效果。
- 对一个形状使用多个 PowerPoint 动画效果。
- 使用动画时间轴控制动画效果。
- 创建自定义动画。

在 Aspose.Slides for Android 通过 Java 中，可以对形状应用各种动画效果。由于幻灯片上的每个元素（包括文本、图片、OLE 对象、表格等）都被视为形状，这意味着我们可以对幻灯片的每个元素应用动画效果。


## **动画效果**
Aspose.Slides 支持 **150+ 种动画效果**，包括基本动画效果，如 Bounce、PathFootball、Zoom 效果和特定动画效果，如 OLEObjectShow、OLEObjectOpen。您可以在 [**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype) 枚举中找到动画效果的完整列表。

此外，这些动画效果可以与它们结合使用：

- [ColorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SetEffect)

## **自定义动画**
可以在 Aspose.Slides 中创建您自己的 **自定义动画**。如果将几种行为组合在一起，可以实现此目标，从而形成新的自定义动画。

[**行为**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Behavior) 是任何 PowerPoint 动画效果的构建单元。所有动画效果实际上都是由行为组成的一种策略。您可以将行为组合成自定义动画一次并在其他演示文稿中重用。如果您将新的行为添加到标准 PowerPoint 动画效果中 - 它将成为另一个自定义动画。例如，您可以向动画添加重复行为使其重复几次。

[**动画点**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Point) 是行为应应用的点。

## **动画时间线**
[**序列**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) 是应用于具体形状的一组动画效果。

[**时间线**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AnimationTimeLine) 是在具体幻灯片中使用的一组序列。它是自 PowerPoint 2002 以来的动画引擎。在之前的 PowerPoint 版本中，添加动画效果到演示文稿是具有挑战性的，只能通过不同的变通方法来实现。时间线取代了旧的 AnimationSettings 类，并为 PowerPoint 动画提供了更清晰的对象模型。一个幻灯片只能有一个动画时间线。

## **交互式动画**
[**触发器**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectTriggerType) 允许定义用户操作（例如按钮点击），这将使某些动画开始。触发器仅在最新的 PowerPoint 版本中添加。

## **形状动画**
Aspose.Slides 允许将动画应用于形状，这实际上可以是文本、矩形、线条、框架、OLE 对象等。

{{% alert color="primary" %}} 
阅读更多 [**关于形状动画**](/slides/androidjava/shape-animation/)。
{{% /alert %}}

## **动画图表**
要创建动画图表，您应该使用与形状相同的所有类。然而，PowerPoint 动画仅可用于图表类别或图表系列。您还可以对类别元素或系列元素应用动画效果。

{{% alert color="primary" %}} 
阅读更多 [**关于动画图表**](/slides/androidjava/animated-charts/)。
{{% /alert %}}

## **动画文本**
除了动画文本，还可以对段落应用动画。

{{% alert color="primary" %}} 
阅读更多 [**关于动画文本**](/slides/androidjava/animated-text/)。
{{% /alert %}}