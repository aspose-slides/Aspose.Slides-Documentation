---
title: 使用 Python 定制演示文稿中的气泡图
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
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 中创建并定制强大的气泡图，轻松提升数据可视化效果。"
---

## **气泡图大小缩放**
Aspose.Slides for Python via .NET 提供了对气泡图大小缩放的支持。在 Aspose.Slides for Python via .NET 中已添加 **ChartSeries.bubble_size_scale** 和 **ChartSeriesGroup.bubble_size_scale** 属性。以下示例演示了如何使用。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```




## **将数据表示为气泡图大小**
已在 ChartSeries、ChartSeriesGroup 类中添加属性 **bubble_size_representation**。**bubble_size_representation** 指定气泡图中气泡大小值的表示方式。可能的取值有：**BubbleSizeRepresentationType.AREA** 和 **BubbleSizeRepresentationType.WIDTH**。因此，还新增了 **BubbleSizeRepresentationType** 枚举以指定将数据表示为气泡图大小的可能方式。以下示例代码展示了用法。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**是否支持“带 3D 效果的气泡图”，它与普通气泡图有何不同？**

是的。存在一个单独的图表类型 “Bubble with 3-D”。它为气泡应用 3D 样式，但不添加额外坐标轴；数据仍保持 X‑Y‑S（大小）形式。此类型可在[chart type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 枚举中找到。

**气泡图中系列和数据点的数量是否有限制？**

在 API 级别没有硬性限制；约束取决于性能和目标 PowerPoint 版本。建议保持数据点数量适中，以保证可读性和渲染速度。

**导出（PDF、图像等）会如何影响气泡图的外观？**

导出到受支持的格式会保留图表外观，渲染由 Aspose.Slides 引擎完成。对于光栅或矢量格式，遵循常规图表渲染规则（分辨率、抗锯齿等），因此请为打印选择足够的 DPI。