---
title: 使用 C++ 在演示文稿中自定义环形图
linktitle: 环形图
type: docs
weight: 30
url: /zh/cpp/doughnut-chart/
keywords:
- 环形图
- 中心间隙
- 孔大小
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中创建和自定义环形图，以支持 PowerPoint 格式的动态演示文稿。"
---

## **指定环形图的中心间隙**
为了指定环形图中孔的大小，请按照以下步骤操作：

- 实例化[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)类。
- 在幻灯片上添加环形图。
- 指定环形图中孔的大小。
- 将演示文稿写入磁盘。

下面的示例中，我们已设置环形图中孔的大小。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **FAQ**

**可以创建带有多个环的多层环形图吗？**

可以。向单个环形图添加多个系列——每个系列都会成为一个独立的环。环的顺序由系列在集合中的顺序决定。

**支持“炸开”的环形图（分离切片）吗？**

支持。存在 Exploded Doughnut[chart type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 并且数据点具有爆炸属性，您可以分离单个切片。

**如何获取环形图的图像（PNG/SVG）用于报告？**

图表本身是一个形状；您可以将其渲染为[raster image](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/)或导出为[SVG image](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/)。