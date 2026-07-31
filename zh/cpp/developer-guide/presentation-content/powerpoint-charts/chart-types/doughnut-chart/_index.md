---
title: 使用 C++ 在演示文稿中自定义甜甜圈图表
linktitle: 甜甜圈图表
type: docs
weight: 30
url: /zh/cpp/doughnut-chart/
keywords:
- 甜甜圈图表
- 中心间隙
- 孔大小
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中创建和自定义甜甜圈图表，支持 PowerPoint 格式的动态演示文稿。"
---
## **概述**

本文介绍如何在 Aspose.Slides 中使用甜甜圈图表，包括将图表添加到幻灯片、设置其中心孔的大小以及保存演示文稿。重点讲解 `set_DoughnutHoleSize` 方法，并演示在代码中自定义此图表类型的基本步骤。

## **在甜甜圈图表中指定中心间隙**
为了指定甜甜圈图表中孔的大小，请按照以下步骤操作：

- 实例化 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类。
- 在幻灯片上添加甜甜圈图表。
- 指定甜甜圈图表中孔的大小。
- 将演示文稿写入磁盘。

在下面的示例中，我们已设置甜甜圈图表中孔的大小。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **常见问题**

**我可以创建具有多层环的多级甜甜圈吗？**

可以。向单个甜甜圈图表添加多个系列——每个系列会成为一个独立的环。环的顺序由系列在集合中的顺序决定。

**是否支持“爆炸式”甜甜圈（切片分离）？**

支持。Aspose.Slides 提供了 Exploded Doughnut [chart type](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/charttype/) 并在数据点上有 explosion 属性；您可以分离单个切片。

**如何获取甜甜圈图表的图像（PNG/SVG）用于报告？**

图表本质上是一个形状；您可以将其渲染为 [raster image](https://reference.aspose.com/slides/zh/cpp/aspose.slides/shape/getimage/) 或导出为 [SVG image](https://reference.aspose.com/slides/zh/cpp/aspose.slides/shape/writeassvg/)。