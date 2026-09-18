---
title: 使用 PHP 为 PowerPoint 演示文稿添加动画
linktitle: PowerPoint 动画
type: docs
weight: 150
url: /zh/php-java/powerpoint-animation/
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
- 交互动画
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
- PHP
- Aspose.Slides
description: "探索 Aspose.Slides for PHP via Java 在处理 PowerPoint 动画方面的功能。关键特性和洞见，帮助提升您的演示文稿。"
---
## **简介**

由于演示文稿的目的在于展示内容，在创建过程中始终会考虑其视觉外观和交互行为。

**PowerPoint 动画** 在使演示文稿引人注目并吸引观众方面发挥重要作用。Aspose.Slides for PHP via Java 提供了广泛的选项来为 PowerPoint 演示文稿添加动画：

- 将各种 PowerPoint 动画效果应用于形状、图表、表格、OLE 对象以及其他演示文稿元素。
- 在单个形状上使用多个 PowerPoint 动画效果。
- 利用动画时间线来控制动画效果。
- 创建自定义动画。

在 Aspose.Slides for PHP via Java 中，可以对形状应用各种动画效果。由于幻灯片上的每个元素，包括文本、图片、OLE 对象和表格，都被视为形状，因此动画效果可以应用于幻灯片上的任意元素。

## **动画效果**
Aspose.Slides 支持 **150+ 动画效果**，包括诸如 Bounce、PathFootball、Zoom 等基础效果，以及 OLEObjectShow、OLEObjectOpen 等特定效果。完整列表可在 [EffectType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/effecttype/) 类中找到。

此外，这些动画效果还可以与以下行为组合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SetEffect)

## **自定义动画**

有关创建、检查和修改行为及可编辑运动路径的完整 PHP 示例，请参阅 [自定义动画](/slides/zh/php-java/custom-animation/)。

可以在 Aspose.Slides 中创建自己的 **自定义动画**。通过将多个行为组合成新的自定义动画即可实现此目的。

[Behavior](https://reference.aspose.com/slides/zh/php-java/aspose.slides/behavior/) 是 PowerPoint 动画效果的构建块。组合行为以自定义效果，或添加行为以扩展预定义效果。重复通过时间设置配置，而不是使用单独的重复行为。

[Animation Point](https://reference.aspose.com/slides/zh/php-java/aspose.slides/point/) 是应应用行为的点。

## **动画时间线**
[Sequence](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sequence/) 是一组可针对不同形状的动画效果的集合。

[Timeline](https://reference.aspose.com/slides/zh/php-java/aspose.slides/animationtimeline/) 是在特定幻灯片中使用的一组序列。它是 PowerPoint 2002 引入的动画引擎。在早期版本的 PowerPoint 中，向演示文稿添加动画效果非常困难，只能通过各种变通方法实现。时间线为 PowerPoint 动画提供了更清晰的对象模型。每张幻灯片只能拥有一个动画时间线。

## **交互动画**
[Trigger](https://reference.aspose.com/slides/zh/php-java/aspose.slides/effecttriggertype/) 允许您定义用户操作（例如按钮点击），以启动特定动画。

## **形状动画**
Aspose.Slides 允许您对形状应用动画，形状可以包括文本、矩形、线条、框架、OLE 对象等。

{{% alert color="info" title="Note" %}}
了解更多 [**关于形状动画**](/slides/zh/php-java/shape-animation/).
{{% /alert %}}

## **动画图表**
要创建动画图表，您应使用与形状相同的类。不过，PowerPoint 动画只能应用于图表类别或图表系列。您也可以将动画效果应用于类别元素或系列元素。

{{% alert color="info" title="Note" %}}
了解更多 [**关于动画图表**](/slides/zh/php-java/animated-charts/).
{{% /alert %}}

## **动画文本**
除了对文本进行动画处理外，您还可以对段落应用动画。

{{% alert color="info" title="Note" %}}
了解更多 [**关于动画文本**](/slides/zh/php-java/animated-text/).
{{% /alert %}}

## **常见问题**

**导出为 PDF 时动画会被保留吗？**

不会。PDF 是静态格式，因此动画和 [幻灯片切换](/slides/zh/php-java/slide-transition/) 不会播放。如果需要运动效果，请改为导出为 [HTML5](/slides/zh/php-java/export-to-html5/)、[动画 GIF](/slides/zh/php-java/convert-powerpoint-to-animated-gif/) 或 [视频](/slides/zh/php-java/convert-powerpoint-to-video/)。

**我可以将带动画的演示文稿转换为视频并控制帧率和帧大小吗？**

可以。您可以 [将演示文稿渲染为帧](/slides/zh/php-java/convert-powerpoint-to-video/) 并将其编码为视频（例如使用 ffmpeg），选择帧率和分辨率。渲染过程中会播放动画和幻灯片切换。

**在处理 ODP（而不仅是 PPTX）时动画会保持完整吗？**

PPT、PPTX 和 ODP 均支持[读取](/slides/zh/php-java/open-presentation/)和[写入](/slides/zh/php-java/save-presentation/)，但这并不保证动画能够保留。转换为 ODP 时可能会丢失自定义动画数据。请参阅 [自定义动画](/slides/zh/php-java/custom-animation/) 获取示例和检查格式兼容性的指南。