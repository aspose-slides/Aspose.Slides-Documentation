---
title: 气泡图
type: docs
url: /zh/python-net/bubble-chart/
keywords: "气泡图, 图表大小, PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "Python 中 PowerPoint 演示文稿的气泡图大小"
---

## **气泡图大小缩放**
Aspose.Slides for Python via .NET 提供了对气泡图大小缩放的支持。在 Aspose.Slides for Python via .NET 中，添加了 **ChartSeries.bubble_size_scale** 和 **ChartSeriesGroup.bubble_size_scale** 属性。以下示例给出。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```




## **将数据表示为气泡图大小**
已向 ChartSeries 和 ChartSeriesGroup 类添加了 **bubble_size_representation** 属性。**bubble_size_representation** 指定气泡图中气泡大小值的表示方式。可能的值为：**BubbleSizeRepresentationType.AREA** 和 **BubbleSizeRepresentationType.WIDTH**。因此，添加了 **BubbleSizeRepresentationType** 枚举，以指定将数据表示为气泡图大小的可能方式。示例代码如下。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```