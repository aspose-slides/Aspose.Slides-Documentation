---
title: 使用 C++ 在演示文稿中自定义气泡图
linktitle: 气泡图
type: docs
url: /zh/cpp/bubble-chart/
keywords:
- 气泡图
- 气泡大小
- 大小缩放
- 大小表示
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 中创建并自定义强大的气泡图，轻松提升数据可视化效果。"
---
## **概述**

本文展示了如何在 Aspose.Slides 中使用气泡图。它涵盖了两个特定的自定义选项：通过 `set_BubbleSizeScale` 方法缩放气泡大小，以及通过 `set_BubbleSizeRepresentation` 方法控制气泡大小值的表示方式。

示例演示了如何创建气泡图、调整其大小缩放，并将气泡大小表示方式切换为使用宽度。文章还包括简短的 FAQ 部分，阐明了对 “Bubble with 3-D” 图表类型的支持，指出实际图表限制取决于性能和目标 PowerPoint 版本，并解释导出时如何通过 Aspose.Slides 渲染引擎保留图表外观。

## **气泡图大小缩放**
Aspose.Slides for C++ 提供了对气泡图大小缩放的支持。在 Aspose.Slides for **C++ IChartSeries.BubbleSizeScale** 和 **IChartSeriesGroup.BubbleSizeScale** 属性已添加。下面给出示例代码。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **将数据表示为气泡图大小**
已在 **IChartSeries** 和 **ChartSeries** 类中添加了新的 **get_BubbleSizeRepresentation()** 方法。**BubbleSizeRepresentation** 指定了气泡图中气泡大小值的表示方式。可能的取值有：**BubbleSizeRepresentationType.Area** 和 **BubbleSizeRepresentationType.Width**。相应地，已添加 **BubbleSizeRepresentationType** 枚举以指定将数据表示为气泡图大小的可能方式。以下给出示例代码。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **FAQ**

**“带 3-D 效果的气泡图” 是否受支持，它与普通气泡图有何区别？**

是的。存在一个单独的图表类型 “Bubble with 3-D”。它对气泡应用 3-D 样式，但不会添加额外的坐标轴；数据仍为 X‑Y‑S（大小）。该类型在[图表类型](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/charttype/)枚举中可用。

**气泡图中系列和数据点的数量是否有限制？**

在 API 层面没有硬性限制；约束取决于性能和目标 PowerPoint 版本。建议保持数据点数量在可读性和渲染速度范围内。

**导出（PDF、图片）会如何影响气泡图的外观？**

导出到受支持的格式会保留图表外观；渲染由 Aspose.Slides 引擎完成。对于栅格/矢量格式，遵循一般的图表渲染规则（分辨率、抗锯齿），因此请为打印选择足够的 DPI。