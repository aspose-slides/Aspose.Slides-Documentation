---
title: 使用 JavaScript 为 PowerPoint 演示文稿添加动画
linktitle: PowerPoint 动画
type: docs
weight: 150
url: /zh/nodejs-java/powerpoint-animation/
keywords:
- 添加动画
- 更新动画
- 更改动画
- 移除动画
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
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 处理 PowerPoint 动画。本概述突出关键特性并提供洞见，以提升您的演示文稿。"
---
## **介绍**

由于演示文稿旨在展示内容，在创建过程中始终会考虑其视觉外观和交互行为。

在使演示文稿引人注目并吸引观众方面，**PowerPoint animation** 起着重要作用。Aspose.Slides for Node.js via Java 提供了广泛的选项来向 PowerPoint 演示文稿添加动画：

- 将各种 PowerPoint 动画效果应用于形状、图表、表格、OLE 对象和其他演示文稿元素。
- 在单个形状上使用多个 PowerPoint 动画效果。
- 利用动画时间线控制动画效果。
- 创建自定义动画。

## **动画效果**
Aspose.Slides 支持 **150+ 动画效果**，包括基本效果如 Bounce、PathFootball 和 Zoom，以及特定效果如 OLEObjectShow 和 OLEObjectOpen。您可以在 [EffectType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/effecttype/) 枚举中找到完整列表。

此外，这些动画效果可以与以下行为组合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/SetEffect)

## **自定义动画**

有关创建、检查和修改行为以及可编辑运动路径的完整 JavaScript 示例，请参阅 [Custom Animation](/slides/zh/nodejs-java/custom-animation/)。

可以在 Aspose.Slides 中创建自己的 **custom animations**。通过将多个行为组合成新的自定义动画即可实现。

[Behavior](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/behavior/) 是 PowerPoint 动画效果的构建块。组合行为以自定义效果，或添加行为以扩展预定义效果。重复通过时间设置配置，而不是单独的重复行为。

[Animation Point](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/point/) 是应应用行为的点。

## **动画时间线**
[Sequence](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sequence/) 是可针对不同形状的动画效果集合。

[Timeline](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/animationtimeline/) 是在特定幻灯片中使用的一组序列。它是 PowerPoint 2002 引入的动画引擎。在早期版本的 PowerPoint 中，为演示文稿添加动画效果十分困难，只能通过各种变通方法实现。时间线为 PowerPoint 动画提供了更清晰的对象模型。每张幻灯片只能有一个动画时间线。

## **交互式动画**
[Trigger](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/effecttriggertype/) 允许您定义用户操作（例如按钮点击），以启动特定动画。

## **形状动画**
Aspose.Slides 允许您对形状应用动画，形状可以包括文本、矩形、线条、框架、OLE 对象等。

{{% alert color="info" title="Note" %}}
了解更多 [**关于形状动画**](/slides/zh/nodejs-java/shape-animation/)。
{{% /alert %}}

## **动画图表**
要创建动画图表，您应使用与形状相同的类。然而，PowerPoint 动画只能应用于图表类别或图表系列。您也可以对类别元素或系列元素应用动画效果。

{{% alert color="info" title="Note" %}}
了解更多 [**关于动画图表**](/slides/zh/nodejs-java/animated-charts/)。
{{% /alert %}}

## **动画文本**
除了对文本进行动画处理外，您还可以对段落应用动画。

{{% alert color="info" title="Note" %}}
了解更多 [**关于动画文本**](/slides/zh/nodejs-java/animated-text/)。
{{% /alert %}}

## **常见问题**

**导出为 PDF 时动画会被保留吗？**

No. PDF 是静态格式，因此动画和 [slide transitions](/slides/zh/nodejs-java/slide-transition/) 不会播放。如果需要运动效果，请改为导出为 [HTML5](/slides/zh/nodejs-java/export-to-html5/)、[animated GIF](/slides/zh/nodejs-java/convert-powerpoint-to-animated-gif/) 或 [video](/slides/zh/nodejs-java/convert-powerpoint-to-video/)。

**我可以将动画演示文稿转换为视频并控制帧率和帧大小吗？**

Yes. 您可以 [render the presentation as frames](/slides/zh/nodejs-java/convert-powerpoint-to-video/) 并将其编码为视频（例如通过 ffmpeg），选择 FPS 和分辨率。渲染过程中会播放动画和幻灯片切换效果。

**在使用 ODP（而不仅仅是 PPTX）时动画会保持完整吗？**

PPT、PPTX 和 ODP 均支持 [reading](/slides/zh/nodejs-java/open-presentation/) 和 [writing](/slides/zh/nodejs-java/save-presentation/)，但这并不保证动画能够保留。将文件转换为 ODP 时可能会丢失自定义动画数据。请参阅 [Custom Animation](/slides/zh/nodejs-java/custom-animation/) 获取示例和检查格式兼容性的指南。