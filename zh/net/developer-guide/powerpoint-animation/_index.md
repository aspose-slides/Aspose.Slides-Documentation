---
title: 使用 .NET 对 PowerPoint 演示文稿进行动画增强
linktitle: PowerPoint 动画
type: docs
weight: 150
url: /zh/net/powerpoint-animation/
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
- PowerPoint 演示文稿
- .NET
- C#
- Aspose.Slides
description: "探索 Aspose.Slides for .NET 在处理 PowerPoint 动画方面的功能。本概览突出关键特性并提供提升演示文稿的洞见。"
---
## **介绍**

由于演示文稿旨在展示内容，在创建过程中始终会考虑其视觉外观和交互行为。

**PowerPoint 动画** 在使演示文稿引人注目并吸引观众方面发挥重要作用。Aspose.Slides for .NET 提供了广泛的选项来向 PowerPoint 演示文稿添加动画：

- 对形状、图表、表格、OLE 对象和其他演示元素应用各种类型的 PowerPoint 动画效果。
- 在单个形状上使用多个 PowerPoint 动画效果。
- 使用动画时间线来控制动画效果。
- 创建自定义动画。

在 Aspose.Slides for .NET 中，可以对形状应用各种动画效果。由于幻灯片上的每个元素，包括文本、图片、OLE 对象和表格，都被视为形状，因此可以对幻灯片上的任何元素应用动画效果。

[Aspose.Slides.Animation](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/) 命名空间提供用于处理 PowerPoint 动画的类。

## **动画效果**

Aspose.Slides 支持 **150+ 动画效果**，包括 Bounce、PathFootball、Zoom 等基本效果，以及 OLEObjectShow、OLEObjectOpen 等特定效果。您可以在 [EffectType](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/effecttype) 枚举中找到完整的动画效果列表。

此外，这些动画效果还可以与以下内容组合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/seteffect)

## **自定义动画**

有关创建、检查和修改行为以及可编辑运动路径的完整 C# 示例，请参阅 [Custom Animation](/slides/zh/net/custom-animation/)。

可以在 Aspose.Slides 中创建自己的 **自定义动画**。通过将多个行为组合在一起即可实现新的自定义动画。

[Behavior](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/behavior) 是 PowerPoint 动画效果的构建块。组合行为以自定义效果，或添加行为以扩展预定义效果。重复是通过时间设置配置的，而不是使用单独的重复行为。

[Animation Point](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/point) 是应应用行为的点。

## **动画时间线**

[Sequence](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/sequence) 是可针对不同形状的动画效果集合。

[Timeline](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/animationtimeline) 是在特定幻灯片中使用的一组序列。它是 PowerPoint 2002 引入的动画引擎。在早期版本的 PowerPoint 中，向演示文稿添加动画效果十分困难，只能通过各种变通方法实现。时间线取代了旧的 AnimationSettings 类，提供了更清晰的 PowerPoint 动画对象模型。每张幻灯片只能拥有一个动画时间线。

## **交互式动画**

[Trigger](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/effecttriggertype) 允许您定义用户操作（例如按钮点击），以启动特定动画。触发器在最新版本的 PowerPoint 中引入。

## **形状动画**

Aspose.Slides 允许您对形状应用动画，形状可包括文本、矩形、线条、框架、OLE 对象等。

{{% alert color="info" title="Note" %}}
阅读更多 [**关于形状动画**](/slides/zh/net/shape-animation/).
{{% /alert %}}

## **动画图表**

要创建动画图表，您应该使用与形状相同的类。但 PowerPoint 动画只能应用于图表类别或图表系列。您也可以对类别元素或系列元素应用动画效果。

{{% alert color="info" title="Note" %}}
阅读更多 [**关于动画图表**](/slides/zh/net/animated-charts/).
{{% /alert %}}

## **动画文本**

除了对文本进行动画处理外，您还可以对段落应用动画。

{{% alert color="info" title="Note" %}}
阅读更多 [**关于动画文本**](/slides/zh/net/animated-text/).
{{% /alert %}}

## **常见问题**

**导出为 PDF 时动画会被保留吗？**

不会。PDF 是静态格式，因此动画和 [slide transitions](/slides/zh/net/slide-transition/) 不会播放。如果需要动态效果，请导出为 [HTML5](/slides/zh/net/export-to-html5/)、[animated GIF](/slides/zh/net/convert-powerpoint-to-animated-gif/) 或 [video](/slides/zh/net/convert-powerpoint-to-video/)。

**我可以将动画演示文稿转换为视频，并控制帧率和帧尺寸吗？**

可以。您可以 [render the presentation as frames](/slides/zh/net/convert-powerpoint-to-video/) 并将其编码为视频（例如通过 ffmpeg），选择 FPS 和分辨率。渲染时会播放动画和幻灯片切换。

**在使用 ODP（而不仅是 PPTX）时动画会保持完整吗？**

PPT、PPTX 和 ODP 均支持 [reading](/slides/zh/net/open-presentation/) 和 [writing](/slides/zh/net/save-presentation/)，但这并不能保证动画的保留。转换为 ODP 时可能会丢失自定义动画数据。请参阅 [Custom Animation](/slides/zh/net/custom-animation/) 获取经过测试的示例和格式限制。