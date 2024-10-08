---
title: PowerPoint 动画
type: docs
weight: 150
url: /net/powerpoint-animation/
keywords: "动画, 动画效果, PowerPoint 动画, 动画时间线, 互动动画, 形状动画, 动画图表, 动画文本, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "PowerPoint 演示文稿中的动画和效果，使用 C# 或 .NET"
---

由于演示文稿旨在呈现某些内容，因此在创建时始终考虑其视觉外观和互动行为。

**PowerPoint 动画** 在使演示文稿对观众引人注目和有吸引力方面起着重要作用。Aspose.Slides for .NET 提供了广泛的选项来为 PowerPoint 演示文稿添加动画：

- 对形状、图表、表格、OLE 对象和其他演示文稿元素应用各种类型的 PowerPoint 动画效果。
- 对一个形状使用多种 PowerPoint 动画效果。
- 使用动画时间线控制动画效果。
- 创建自定义动画。

在 Aspose.Slides for .NET 中，各种动画效果可以应用于形状。由于幻灯片上的每个元素（包括文本、图片、OLE 对象、表格等）都被视为形状，这意味着我们可以对幻灯片上的每个元素应用动画效果。

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/net/aspose.slides.animation/) **命名空间** 提供了与 PowerPoint 动画一起使用的类。
## **动画效果**
Aspose.Slides 支持 **150+ 动画效果**，包括基本的动画效果，如 Bounce、PathFootball、Zoom 效果，以及特定的动画效果，如 OLEObjectShow、OLEObjectOpen。您可以在 [**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype) 枚举中找到动画效果的完整列表。

此外，这些动画效果可以与以下效果结合使用：

- [ColorEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/seteffect)
## **自定义动画**
在 Aspose.Slides 中，可以创建您自己的 **自定义动画**。这可以通过将多个行为组合在一起形成新的自定义动画来实现。

[**行为**](https://reference.aspose.com/slides/net/aspose.slides.animation/behavior) 是任何 PowerPoint 动画效果的构建单元。所有动画效果实际上是一组组合成一种策略的行为。您可以将行为组合成自定义动画一次，并在其他演示文稿中重用它。如果您向标准 PowerPoint 动画效果添加一个新行为，它将成为另一个自定义动画。例如，您可以向动画添加重复行为，以使其重复几次。

[**动画点**](https://reference.aspose.com/slides/net/aspose.slides.animation/point) 是行为应应用的点。
## **动画时间线**
[**序列**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) 是应用于具体形状的动画效果集合。

[**时间线**](https://reference.aspose.com/slides/net/aspose.slides.animation/animationtimeline) 是在具体幻灯片中使用的一组序列。它是自 PowerPoint 2002 以来表示的动画引擎。在以前的 PowerPoint 版本中，将动画效果添加到演示文稿是具有挑战性的，这只能通过不同的变通方法实现。时间线取代了旧的 AnimationSettings 类，并提供了更清晰的 PowerPoint 动画对象模型。一个幻灯片只能有一个动画时间线。
## **互动动画**
[**触发器**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttriggertype) 允许定义用户操作（例如按钮点击），使某个动画开始。触发器仅在最新的 PowerPoint 版本中添加。
## **形状动画**
Aspose.Slides 允许将动画应用于形状，这实际上可以是文本、矩形、线条、框架、OLE 对象等。

{{% alert color="primary" %}} 
阅读更多 [**关于形状动画**](/slides/net/shape-animation/)。
{{% /alert %}}

## **动画图表**
要创建动画图表，您应使用与形状相同的所有类。然而，PowerPoint 动画只能应用于图表类别或图表系列。您还可以对分类元素或系列元素应用动画效果。

{{% alert color="primary" %}} 
阅读更多 [**关于动画图表**](/slides/net/animated-charts/)。
{{% /alert %}}

## **动画文本**
除了动画文本外，还可以对段落应用动画。

{{% alert color="primary" %}} 
阅读更多 [**关于动画文本**](/slides/net/animated-text/)。
{{% /alert %}}