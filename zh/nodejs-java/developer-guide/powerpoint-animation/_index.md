---
title: PowerPoint 动画
type: docs
weight: 150
url: /zh/nodejs-java/powerpoint-animation/
keywords: "PowerPoint 动画"
description: "PowerPoint 动画，使用 Aspose.Slides 的 PowerPoint 幻灯片动画。"
---

由于演示文稿旨在展示内容，在创建它们时始终会考虑其视觉外观和交互行为。

**PowerPoint animation** 在使演示文稿引人注目、吸引观众方面发挥着重要作用。Aspose.Slides for Node.js via Java 提供了广泛的选项来为 PowerPoint 演示文稿添加动画：

- 对形状、图表、表格、OLE 对象及其他演示文稿元素应用各种类型的 PowerPoint 动画效果。
- 在单个形状上使用多个 PowerPoint 动画效果。
- 使用动画时间线来控制动画效果。
- 创建自定义动画。

在 Aspose.Slides for Node.js via Java 中，可以在形状上应用各种动画效果。由于幻灯片上的每个元素（包括文本、图片、OLE 对象、表格等）都被视为形状，这意味着我们可以对幻灯片的每个元素应用动画效果。

## **动画效果**
Aspose.Slides 支持 **150+ 动画效果**，包括诸如 Bounce、PathFootball、Zoom 效果等基础动画效果，以及 OLEObjectShow、OLEObjectOpen 等特定动画效果。您可以在 [**EffectType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effecttype/) 枚举中找到动画效果的完整列表。

此外，这些动画效果还可以与以下效果组合使用：

- [ColorEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SetEffect)

## **自定义动画**
在 Aspose.Slides 中可以创建自己的 **自定义动画**。通过将多个行为组合成新的自定义动画即可实现此目的。

[**Behavior**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Behavior) 是任何 PowerPoint 动画效果的构建单元。所有动画效果实际上是一组行为组合成的策略。您可以将行为组合成一次自定义动画，并在其他演示文稿中重复使用。如果向标准 PowerPoint 动画效果中添加新的行为——它将成为另一个自定义动画。例如，您可以向动画添加重复行为，使其重复若干次。

[**Animation Point**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Point) 是应应用行为的点。

## **动画时间线**
[**Sequence**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence) 是一组应用于特定形状的动画效果的集合。

[**Timeline**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AnimationTimeLine) 是在特定幻灯片中使用的 Sequence 集合。它是自 PowerPoint 2002 起引入的动画引擎。在早期 PowerPoint 版本中，向演示文稿添加动画效果非常困难，只能通过各种变通方法实现。Timeline 用于取代旧的 AnimationSettings 类，并为 PowerPoint 动画提供更清晰的对象模型。每个幻灯片只能拥有一个动画时间线。

## **交互式动画**
[**Trigger**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EffectTriggerType) 允许定义用户操作（例如按钮点击），从而启动特定动画。Trigger 仅在最新的 PowerPoint 版本中加入。

## **形状动画**
Aspose.Slides 允许对形状应用动画，形状可以是文本、矩形、线条、框架、OLE 对象等。

{{% alert color="primary" %}} 
了解更多 [**About Shape Animation**](/slides/zh/nodejs-java/shape-animation/).
{{% /alert %}}

## **动画图表**
要创建动画图表，您应使用与形状相同的所有类。不过，PowerPoint 动画只能作用于图表分类或图表系列。您也可以对分类元素或系列元素应用动画效果。

{{% alert color="primary" %}} 
了解更多 [**About Animated Charts**](/slides/zh/nodejs-java/animated-charts/).
{{% /alert %}}

## **动画文本**
除了动画文本之外，还可以对段落应用动画。

{{% alert color="primary" %}} 
了解更多 [**About Animated Text**](/slides/zh/nodejs-java/animated-text/).
{{% /alert %}}

## **常见问题**
**导出为 PDF 时动画会被保留吗？**

不。PDF 是静态格式，动画和 [slide transitions](/slides/zh/nodejs-java/slide-transition/) 不会播放。如果需要动态效果，请导出为 [HTML5](/slides/zh/nodejs-java/export-to-html5/)、[animated GIF](/slides/zh/nodejs-java/convert-powerpoint-to-animated-gif/) 或 [video](/slides/zh/nodejs-java/convert-powerpoint-to-video/) 等格式。

**我可以将动画演示文稿转换为视频并控制帧率和帧大小吗？**

可以。您可以 [render the presentation as frames](/slides/zh/nodejs-java/convert-powerpoint-to-video/) 并将其编码为视频（例如通过 ffmpeg），从而选择 FPS 和分辨率。渲染期间会播放动画和幻灯片切换效果。

**在使用 ODP（而不仅是 PPTX）时动画是否保持完整？**

PPT、PPTX 和 ODP 均受支持，可用于 [reading](/slides/zh/nodejs-java/open-presentation/) 和 [writing](/slides/zh/nodejs-java/save-presentation/)，但格式差异可能导致某些效果在外观或行为上略有不同。请使用真实样本验证关键情况。