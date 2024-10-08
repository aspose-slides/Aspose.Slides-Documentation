---
title: PowerPoint 动画
type: docs
weight: 150
url: /python-net/powerpoint-animation/
keywords: "动画, 动画效果, PowerPoint 动画, 动画时间轴, 互动动画, 形状动画, 动态图表, 动态文本, PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "Python 中的 PowerPoint 演示文稿动画和效果"
---

由于演示文稿旨在展示某些内容，因此在创建时始终会考虑它们的视觉外观和互动行为。

**PowerPoint 动画** 在使演示文稿引人注目并吸引观众方面起着重要作用。Aspose.Slides for Python via .NET 提供了多种选项，以向 PowerPoint 演示文稿添加动画：

- 在形状、图表、表格、OLE 对象和其他演示元素上应用各种类型的 PowerPoint 动画效果。
- 在一个形状上使用多个 PowerPoint 动画效果。
- 使用动画时间轴控制动画效果。
- 创建自定义动画。

在 Aspose.Slides for Python via .NET 中，动画效果可以应用于形状。由于幻灯片上的每个元素（包括文本、图片、OLE 对象、表格等）都被视为一个形状，这意味着我们可以在幻灯片的每个元素上应用动画效果。

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) **命名空间** 提供了用于处理 PowerPoint 动画的类。
## **动画效果**
Aspose.Slides 支持 **150+ 动画效果**，包括像 Bounce、PathFootball、Zoom 效果这样的基本动画效果以及 OLEObjectShow、OLEObjectOpen 等特定动画效果。您可以在 [**EffectType**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/) 枚举中找到动画效果的完整列表。

此外，这些动画效果可以与以下效果组合使用：

- [ColorEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/seteffect/)
## **自定义动画**
在 Aspose.Slides 中，可以创建您自己的 **自定义动画**。这可以通过将几个行为组合在一起形成一个新的自定义动画来实现。

[**行为**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behavior/) 是任何 PowerPoint 动画效果的构建单元。所有动画效果实际上是一组组合成一个策略的行为。您可以将行为组合成一个自定义动画一次，并在其他演示文稿中重用。如果您将新行为添加到标准 PowerPoint 动画效果中，它将成为另一个自定义动画。例如，您可以为动画添加重复行为，使其重复几次。

[**动画点**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/point/) 是应用行为的点。
## **动画时间线**
[**序列**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) 是应用于具体形状的动画效果集合。

[**时间线**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animationtimeline/) 是应用于具体幻灯片的一组序列。它是自 PowerPoint 2002 以来表示的动画引擎。在早期的 PowerPoint 版本中，添加动画效果到演示文稿是具有挑战性的，只能通过不同的变通方法来实现。时间线取代了旧的 AnimationSettings 类，并提供了更清晰的 PowerPoint 动画对象模型。一个幻灯片只能有一个动画时间线。
## **互动动画**
[**触发器**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/) 允许定义用户动作（例如，按钮点击），这些动作将使某一特定动画开始。触发器仅在最新的 PowerPoint 版本中添加。
## **形状动画**
Aspose.Slides 允许对形状应用动画，这些形状实际上可以是文本、矩形、线条、框架、OLE 对象等。

{{% alert color="primary" %}} 
阅读更多 [**关于形状动画**](/slides/python-net/shape-animation/)。
{{% /alert %}}

## **动态图表**
要创建动态图表，您应该使用与形状相同的类。然而，只能在图表类别或图表系列上使用 PowerPoint 动画。您还可以对类别元素或系列元素应用动画效果。

{{% alert color="primary" %}} 
阅读更多 [**关于动态图表**](/slides/python-net/animated-charts/)。
{{% /alert %}}

## **动态文本**
除了动态文本之外，还可以对段落应用动画。

{{% alert color="primary" %}} 
阅读更多 [**关于动态文本**](/slides/python-net/animated-text/)。
{{% /alert %}}