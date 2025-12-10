---
title: 在 C++ 中向演示文稿图表添加趋势线
linktitle: 趋势线
type: docs
url: /zh/cpp/trend-line/
keywords:
- 图表
- 趋势线
- 指数趋势线
- 线性趋势线
- 对数趋势线
- 移动平均趋势线
- 多项式趋势线
- 幂趋势线
- 自定义趋势线
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 快速在 PowerPoint 图表中添加和自定义趋势线 — 实用指南，帮助您吸引观众。"
---

## **添加趋势线**
Aspose.Slides for C++ 提供了一个简单的 API，用于管理不同图表的趋势线：

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加一个带有默认数据的图表，并选择所需的任意类型（本例使用 ChartType.ClusteredColumn）。
4. 为图表系列 1 添加指数趋势线。
5. 为图表系列 1 添加线性趋势线。
6. 为图表系列 2 添加对数趋势线。
7. 为图表系列 2 添加移动平均趋势线。
8. 为图表系列 3 添加多项式趋势线。
9. 为图表系列 3 添加幂趋势线。
10. 将修改后的演示文稿写入 PPTX 文件。

以下代码用于创建带有趋势线的图表。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **添加自定义线**
Aspose.Slides for C++ 提供了一个简单的 API，用于在图表中添加自定义线。要在演示文稿的选定幻灯片上添加一条简单的普通线，请按照以下步骤操作：

- 创建 Presentation 类的实例
- 使用索引获取幻灯片的引用
- 使用 Shapes 对象公开的 AddChart 方法创建新图表
- 使用 Shapes 对象公开的 AddAutoShape 方法添加线型 AutoShape
- 设置形状线条的颜色。
- 将修改后的演示文稿写入 PPTX 文件

以下代码用于创建带有自定义线的图表。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **FAQ**

**趋势线的 “forward” 和 “backward” 是什么意思？**

它们是趋势线向前/向后延伸的长度：对于散点 (XY) 图表，以坐标轴单位表示；对于非散点图表，以类别数量表示。只允许非负值。

**将演示文稿导出为 PDF 或 SVG，或将幻灯片渲染为图像时，趋势线会被保留吗？**

会。Aspose.Slides 可以将演示文稿转换为 [PDF](/slides/zh/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/zh/cpp/render-a-slide-as-an-svg-image/)，并将图表渲染为图像；趋势线作为图表的一部分，在这些操作中会被保留。还提供了一种方法，可直接 [导出图表的图像](/slides/zh/cpp/create-shape-thumbnails/)。