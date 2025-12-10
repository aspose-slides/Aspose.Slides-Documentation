---
title: 在演示文稿中使用 С++ 定制气泡图
linktitle: 气泡图
type: docs
url: /zh/cpp/bubble-chart/
keywords:
- 气泡图
- 气泡大小
- 大小比例
- 大小表示
- PowerPoint
- 演示文稿
- С++
- Aspose.Slides
description: "使用 Aspose.Slides for С++ 在 PowerPoint 中创建和定制强大的气泡图，轻松提升数据可视化效果。"
---

## **气泡图大小比例**
Aspose.Slides for C++ 提供了气泡图大小比例的支持。在 Aspose.Slides for **C++ IChartSeries.BubbleSizeScale** 和 **IChartSeriesGroup.BubbleSizeScale** 属性已被添加。以下示例代码给出。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **将数据表示为气泡图大小**
已在 **IChartSeries** 和 **ChartSeries** 类中添加了新的 **get_BubbleSizeRepresentation()** 方法。**BubbleSizeRepresentation** 指定气泡图中气泡大小值的表示方式。可能的值有：**BubbleSizeRepresentationType.Area** 和 **BubbleSizeRepresentationType.Width**。相应地，已添加 **BubbleSizeRepresentationType** 枚举以指定将数据表示为气泡图大小的可能方式。以下给出示例代码。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **常见问题**

**是否支持“具有 3-D 效果的气泡图”，它与普通气泡图有什么区别？**

是的。存在一种单独的图表类型，“Bubble with 3-D”。它对气泡应用 3-D 样式，但不添加额外的坐标轴；数据仍为 X‑Y‑S（大小）。该类型在[chart type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 枚举中可用。

**气泡图的系列和数据点数量是否有限制？**

在 API 层面没有硬性限制；约束取决于性能和目标 PowerPoint 版本。建议保持数据点数量合理，以确保可读性和渲染速度。

**导出（PDF、图像）会如何影响气泡图的外观？**

导出为受支持的格式时会保留图表的外观；渲染由 Aspose.Slides 引擎完成。对于栅格/矢量格式，遵循通用的图表渲染规则（分辨率、抗锯齿），因此请为打印选择足够的 DPI。