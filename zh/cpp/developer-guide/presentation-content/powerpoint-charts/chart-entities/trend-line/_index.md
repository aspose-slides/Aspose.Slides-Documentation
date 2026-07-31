---
title: 在 C++ 中为演示文稿图表添加趋势线
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
description: "使用 Aspose.Slides for C++ 快速在 PowerPoint 图表中添加和自定义趋势线——帮助您吸引受众的实用指南。"
---
## **概述**

本文介绍如何使用 Aspose.Slides 为演示文稿中的图表添加趋势线。它展示了如何创建图表、向图表系列添加趋势线，以及如何使用多种趋势线类型，包括指数、线性、对数、移动平均、多项式和幂趋势线。

除此之外，还说明了如何通过插入线形 AutoShape 向图表添加自定义线，并提供了一个简短的 FAQ，解释了趋势线的前向和后向投射值的含义，以及在导出为 PDF 或 SVG，或将图表渲染为图像时趋势线是否会被保留。

## **添加趋势线**
Aspose.Slides for C++ 提供了管理不同图表趋势线的简洁 API：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加带有默认数据的图表，并指定所需类型（本例使用 ChartType.ClusteredColumn）。  
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
Aspose.Slides for C++ 提供了在图表中添加自定义线的简洁 API。要在演示文稿的选定幻灯片上添加一条普通直线，请按照以下步骤操作：

- 创建 Presentation 类的实例  
- 通过其 Index 获取幻灯片的引用  
- 使用 Shapes 对象公开的 AddChart 方法创建新图表  
- 使用 Shapes 对象公开的 AddAutoShape 方法添加线形 AutoShape  
- 设置形状线的颜色  
- 将修改后的演示文稿写入 PPTX 文件  

以下代码用于创建带有自定义线的图表。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **常见问题**

**趋势线的“前向”和“后向”是什么意思？**

它们是趋势线向前/向后投射的长度：对于散点 (XY) 图表——以轴单位计；对于非散点图表——以分类数量计。仅允许非负值。

**在将演示文稿导出为 PDF 或 SVG，或将幻灯片渲染为图像时，趋势线会被保留吗？**

会。Aspose.Slides 将演示文稿转换为 [PDF](/slides/zh/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/zh/cpp/render-a-slide-as-an-svg-image/) 并将图表渲染为图像；趋势线作为图表的一部分，在这些操作中会被保留。还提供了一个方法来 [导出图表本身的图像](/slides/zh/cpp/create-shape-thumbnails/)。