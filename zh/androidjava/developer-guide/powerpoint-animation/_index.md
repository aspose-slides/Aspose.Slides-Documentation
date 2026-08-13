---
title: 在 Android 上使用动画增强 PowerPoint 演示文稿
linktitle: PowerPoint 动画
type: docs
weight: 150
url: /zh/androidjava/powerpoint-animation/
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
- 动画图表
- 动画文本
- 动画形状
- 动画 OLE 对象
- 动画图像
- 动画表格
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Android via Java 在处理 PowerPoint 动画方面的功能。此概览概述了关键特性。"
---
## **简介**

由于演示文稿的目的是展示内容，在创建时始终会考虑其视觉外观和交互行为。

**PowerPoint 动画** 在使演示文稿吸引观众、引人注目方面起着重要作用。Aspose.Slides for Android via Java 提供了广泛的选项来为 PowerPoint 演示文稿添加动画：

- 对形状、图表、表格、OLE 对象及其他演示文稿元素应用各种 PowerPoint 动画效果。
- 在单个形状上使用多个 PowerPoint 动画效果。
- 使用动画时间轴来控制动画效果。
- 创建自定义动画。

在 Aspose.Slides for Android via Java 中，可以在形状上应用各种动画效果。由于幻灯片上的每个元素（包括文本、图片、OLE 对象、表格等）都视为形状，这意味着我们可以对幻灯片的每个元素应用动画效果。

## **动画效果**
Aspose.Slides 支持 **150+ 动画效果**，包括基本的动画效果，如 Bounce、PathFootball、Zoom 效果，以及特定的动画效果，如 OLEObjectShow、OLEObjectOpen。您可以在[**EffectType**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/effecttype/)枚举中找到完整的动画效果列表。

此外，这些动画效果可以与以下内容组合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SetEffect)

## **自定义动画**
可以在 Aspose.Slides 中创建您自己的 **自定义动画**。如果将多个行为组合成新的自定义动画，即可实现此目的。

[**Behavior**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Behavior) 是任何 PowerPoint 动画效果的构建单元。所有动画效果实际上是一组行为组合成的策略。您可以一次将行为组合成自定义动画，然后在其他演示文稿中重复使用。如果向标准 PowerPoint 动画效果添加新行为——它将成为另一个自定义动画。例如，您可以向动画添加重复行为，使其重复若干次。

[**Animation Point**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Point) 是应应用行为的点。

## **动画时间线**
[**Sequence**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Sequence) 是一组应用于特定形状的动画效果的集合。

[**Timeline**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/AnimationTimeLine) 是在特定幻灯片中使用的一组 Sequence。它是自 PowerPoint 2002 起引入的动画引擎。在以前的 PowerPoint 版本中，向演示文稿添加动画效果较为困难，只能通过各种变通方法实现。Timeline 用于取代旧的 AnimationSettings 类，并为 PowerPoint 动画提供更清晰的对象模型。每张幻灯片只能拥有一个动画时间线。

## **交互式动画**
[**Trigger**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/EffectTriggerType) 允许定义用户操作（例如按钮点击），以启动特定动画。Trigger 仅在最新的 PowerPoint 版本中添加。

## **形状动画**
Aspose.Slides 允许对形状应用动画，形状实际上可以是文本、矩形、线条、框架、OLE 对象等。

{{% alert color="info" %}} 
阅读更多 [**关于形状动画**](/slides/zh/androidjava/shape-animation/).
{{% /alert %}}

## **动画图表**
要创建动画图表，您应使用与形状相同的所有类。但只能对图表类别或系列应用 PowerPoint 动画。您也可以对类别元素或系列元素应用动画效果。

{{% alert color="info" %}} 
阅读更多 [**关于动画图表**](/slides/zh/androidjava/animated-charts/).
{{% /alert %}}

## **动画文本**
除了动画文本之外，还可以对段落应用动画。

{{% alert color="info" %}} 
阅读更多 [**关于动画文本**](/slides/zh/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

### 将动画导出为 PDF 时会被保留吗？

不会。PDF 是静态格式，因此动画和[幻灯片切换](/slides/zh/androidjava/slide-transition/) 不会播放。如果需要动画，请改为导出为[HTML5](/slides/zh/androidjava/export-to-html5/)、[animated GIF](/slides/zh/androidjava/convert-powerpoint-to-animated-gif/)或[video](/slides/zh/androidjava/convert-powerpoint-to-video/)。

### 我可以将动画演示文稿转换为视频，并控制帧速率和帧大小吗？

是的。您可以[将演示文稿渲染为帧](/slides/zh/androidjava/convert-powerpoint-to-video/) 并将其编码为视频（例如使用 ffmpeg），选择 FPS 和分辨率。渲染期间会播放动画和幻灯片切换。

### 在使用 ODP（不仅限于 PPTX）时动画会保持完整吗？

PPT、PPTX 和 ODP 均受支持用于[读取](/slides/zh/androidjava/open-presentation/)和[写入](/slides/zh/androidjava/save-presentation/)，但格式差异意味着某些效果可能看起来或表现稍有不同。请使用真实样本验证关键情况。