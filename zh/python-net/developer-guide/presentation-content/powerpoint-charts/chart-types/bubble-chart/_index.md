---
title: 使用 Python 在演示文稿中自定义气泡图
linktitle: 气泡图
type: docs
url: /zh/python-net/bubble-chart/
keywords:
- 气泡图
- 气泡大小
- 大小缩放
- 大小表示
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 中创建并自定义强大的气泡图，轻松提升数据可视化效果。"
---

## **气泡图大小缩放**
Aspose.Slides for Python via .NET 提供了气泡图大小缩放的支持。在 Aspose.Slides for Python via .NET 中已添加 **ChartSeries.bubble_size_scale** 和 **ChartSeriesGroup.bubble_size_scale** 属性。下面给出示例代码。  

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```



## **将数据表示为气泡图大小**
已在 ChartSeries、ChartSeriesGroup 类中添加属性 **bubble_size_representation**。**bubble_size_representation** 指定气泡图中气泡大小值的表示方式。可能的取值有：**BubbleSizeRepresentationType.AREA** 和 **BubbleSizeRepresentationType.WIDTH**。因此，已添加 **BubbleSizeRepresentationType** 枚举以指定将数据表示为气泡图大小的可能方式。下面给出示例代码。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**是否支持带 3D 效果的“气泡图”，以及它与普通气泡图有何不同？**

是的。存在一种单独的图表类型“Bubble with 3-D”。它对气泡应用 3D 样式，但不增加额外的坐标轴；数据仍然是 X‑Y‑S（大小）。该类型可在[图表类型](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 枚举中找到。

**气泡图的系列和数据点数量是否有限制？**

在 API 级别没有硬性限制；约束由性能以及目标 PowerPoint 版本决定。建议保持数据点数量适当，以保证可读性和渲染速度。

**导出（PDF、图像）会如何影响气泡图的外观？**

导出为支持的格式时会保持图表外观；渲染由 Aspose.Slides 引擎完成。对于光栅/矢量格式，遵循一般的图表渲染规则（分辨率、抗锯齿），因此请为打印选择足够的 DPI。