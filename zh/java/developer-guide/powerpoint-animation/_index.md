---
title: PowerPoint 动画
type: docs
weight: 150
url: /zh/java/powerpoint-animation/
keywords: "PowerPoint 动画"
description: "使用 Aspose.Slides 的 PowerPoint 动画，PowerPoint 幻灯片动画。"
---

由于演示文稿是用来展示某些内容的，因此在创建时总是会考虑其视觉外观和交互行为。

**PowerPoint 动画** 在使演示文稿引人注目和吸引观众方面起着重要作用。Aspose.Slides for Java 提供了广泛的选项来为 PowerPoint 演示文稿添加动画：

- 在形状、图表、表格、OLE 对象和其他演示元素上应用各种类型的 PowerPoint 动画效果。
- 在一个形状上使用多个 PowerPoint 动画效果。
- 使用动画时间线来控制动画效果。
- 创建自定义动画。

在 Aspose.Slides for Java 中，可以在形状上应用各种动画效果。由于幻灯片上的每个元素（包括文本、图片、OLE 对象、表格等）都被视为形状，这意味着我们可以在幻灯片的每个元素上应用动画效果。

## **动画效果**
Aspose.Slides 支持 **150+ 种动画效果**，包括基本动画效果如 Bounce、PathFootball、Zoom 效果和特定动画效果如 OLEObjectShow、OLEObjectOpen。您可以在 [**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype) 枚举中找到动画效果的完整列表。

此外，这些动画效果可以与以下内容组合使用：

- [ColorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/java/com.aspose.slides/SetEffect)

## **自定义动画**
在 Aspose.Slides 中可以创建您自己的 **自定义动画**。 
这可以通过将几个行为组合在一起形成新的自定义动画来实现。

[**Behavior**](https://reference.aspose.com/slides/java/com.aspose.slides/Behavior) 是任何 PowerPoint 动画效果的构建单元。所有动画效果实际上是一组组合成一个策略的行为。您可以在创建自定义动画时将行为组合一次，并在其他演示文稿中重用它。如果您将新行为添加到标准 PowerPoint 动画效果中，它将成为另一个自定义动画。例如，您可以在动画中添加重复行为，使其重复几次。

[**Animation Point**](https://reference.aspose.com/slides/java/com.aspose.slides/Point) 是应用行为的点。

## **动画时间线**
[**Sequence**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence) 是应用于特定形状的一组动画效果。

[**Timeline**](https://reference.aspose.com/slides/java/com.aspose.slides/AnimationTimeLine) 是在特定幻灯片中使用的一组序列。它是自 PowerPoint 2002 以来的动画引擎。在之前的 PowerPoint 版本中，很难为演示文稿添加动画效果，这只能通过不同的变通方法来实现。时间线取代了旧的 AnimationSettings 类，并为 PowerPoint 动画提供了更清晰的对象模型。一个幻灯片只能有一个动画时间线。

## **互动动画**
[**Trigger**](https://reference.aspose.com/slides/java/com.aspose.slides/EffectTriggerType) 允许定义用户操作（例如按钮点击），以启动某个动画。触发器仅在最新的 PowerPoint 版本中添加。

## **形状动画**
Aspose.Slides 允许将动画应用于形状，这实际上可以是文本、矩形、线条、框架、OLE 对象等。

{{% alert color="primary" %}} 
阅读更多 [**关于形状动画**](/slides/zh/java/shape-animation/)。
{{% /alert %}}

## **动画图表**
要创建动画图表，您应使用与形状相同的类。然而，PowerPoint 动画只能用于图表类别或图表系列。您还可以将动画效果应用于类别元素或系列元素。

{{% alert color="primary" %}} 
阅读更多 [**关于动画图表**](/slides/zh/java/animated-charts/)。
{{% /alert %}}

## **动画文本**
除了动画文本，还可以将动画应用于段落。

{{% alert color="primary" %}} 
阅读更多 [**关于动画文本**](/slides/zh/java/animated-text/)。
{{% /alert %}}