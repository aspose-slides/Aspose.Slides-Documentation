---
title: 在 Java 中通过动画增强 PowerPoint 演示文稿
linktitle: PowerPoint 动画
type: docs
weight: 150
url: /zh/java/powerpoint-animation/
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
- 动画文字
- 动画形状
- 动画 OLE 对象
- 动画图像
- 动画表格
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Java 在处理 PowerPoint 动画方面的功能。此概览突显关键特性并提供提升演示文稿的见解。"
---
## **简介**

由于演示文稿旨在展示内容，在创建时始终会考虑其视觉外观和交互行为。

**PowerPoint 动画** 在使演示文稿吸引人并让观众产生兴趣方面发挥重要作用。Aspose.Slides 提供了多种向 PowerPoint 演示文稿添加动画的选项：

- 对形状、图表、表格、OLE 对象及其他演示文稿元素应用各种 PowerPoint 动画效果。
- 在单个形状上使用多个 PowerPoint 动画效果。
- 利用动画时间轴来控制动画效果。
- 创建自定义动画。

## **动画效果**
Aspose.Slides 支持 **150+ 动画效果**，包括 Bounce、PathFootball、Zoom 等基本动画效果以及 OLEObjectShow、OLEObjectOpen 等特定动画效果。您可以在 [**EffectType**](https://reference.aspose.com/slides/zh/java/com.aspose.slides/effecttype/) 枚举中找到动画效果的完整列表。

此外，这些动画效果可以与以下效果组合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/zh/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/zh/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/zh/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/zh/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/zh/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/zh/java/com.aspose.slides/SetEffect)

## **自定义动画**
可以在 Aspose.Slides 中创建自己的 **自定义动画**。如果将多个行为组合成新的自定义动画，即可实现此目的。

[**Behavior**](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Behavior) 是任何 PowerPoint 动画效果的构建单元。所有动画效果实际上是一组行为组合而成的策略。您可以将行为一次性组合成自定义动画，然后在其他演示文稿中重复使用。如果向标准 PowerPoint 动画效果中添加新行为，它将成为另一个自定义动画。例如，您可以向动画添加重复行为，使其重复若干次。

[**Animation Point**](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Point) 是应当应用行为的点。

## **动画时间线**
[**Sequence**](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Sequence) 是应用于具体形状的动画效果集合。

[**Timeline**](https://reference.aspose.com/slides/zh/java/com.aspose.slides/AnimationTimeLine) 是在具体幻灯片中使用的一组 Sequence。自 PowerPoint 2002 起，它成为动画引擎。以前的 PowerPoint 版本中，向演示文稿添加动画效果较为困难，只能通过各种变通方法实现。Timeline 用于取代旧的 AnimationSettings 类，并为 PowerPoint 动画提供更清晰的对象模型。每张幻灯片只能拥有一个动画时间线。

## **交互式动画**
[**Trigger**](https://reference.aspose.com/slides/zh/java/com.aspose.slides/EffectTriggerType) 允许定义用户操作（例如按钮点击），以启动特定动画。触发器仅在最新的 PowerPoint 版本中添加。

## **形状动画**
Aspose.Slides 允许对形状应用动画，形状实际上可以是文本、矩形、线条、框架、OLE 对象等。

{{% alert color="info" %}} 
了解更多 [**关于形状动画**](/slides/zh/java/shape-animation/).
{{% /alert %}}

## **动画图表**
要创建动画图表，您应使用与形状相同的所有类。然而，PowerPoint 动画只能应用于图表类别或图表系列。您也可以对类别元素或系列元素应用动画效果。

{{% alert color="info" %}} 
了解更多 [**关于动画图表**](/slides/zh/java/animated-charts/).
{{% /alert %}}

## **动画文字**
除动画文字外，还可以对段落应用动画。

{{% alert color="info" %}} 
了解更多 [**关于动画文字**](/slides/zh/java/animated-text/).
{{% /alert %}}

## **常见问题**

### 导出为 PDF 时动画是否会被保留？

不会。PDF 是一种静态格式，因此动画和 [幻灯片切换](/slides/zh/java/slide-transition/) 不会播放。如果需要动态效果，请导出为 [HTML5](/slides/zh/java/export-to-html5/)、[动画 GIF](/slides/zh/java/convert-powerpoint-to-animated-gif/) 或 [视频](/slides/zh/java/convert-powerpoint-to-video/)。

### 我可以将动画演示文稿转换为视频并控制帧率和帧大小吗？

可以。您可以 [将演示文稿渲染为帧](/slides/zh/java/convert-powerpoint-to-video/) 并将其编码为视频（例如使用 ffmpeg），选择帧率和分辨率。渲染期间会播放动画和幻灯片切换。

### 在使用 ODP（不仅限于 PPTX）时动画是否保持完整？

PPT、PPTX 和 ODP 均支持[读取](/slides/zh/java/open-presentation/)和[写入](/slides/zh/java/save-presentation/)，但由于格式差异，某些效果可能略有不同。请使用真实样本验证关键情况。