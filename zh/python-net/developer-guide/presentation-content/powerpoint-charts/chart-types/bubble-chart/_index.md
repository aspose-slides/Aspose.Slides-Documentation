---
title: 用Python在演示文稿中自定义气泡图
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
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 中创建并自定义强大的气泡图，轻松提升数据可视化。"
---

## **Bubble Chart Size Scaling**
Aspose.Slides for Python via .NET 提供对气泡图大小缩放的支持。在 Aspose.Slides for Python via .NET 中已添加 **ChartSeries.bubble_size_scale** 和 **ChartSeriesGroup.bubble_size_scale** 属性。下面给出示例。
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```





## **Represent Data as Bubble Chart Sizes**
已在 ChartSeries、ChartSeriesGroup 类中添加属性 **bubble_size_representation**。**bubble_size_representation** 指定气泡图中气泡大小值的表示方式。可能的取值为 **BubbleSizeRepresentationType.AREA** 和 **BubbleSizeRepresentationType.WIDTH**。因此，已添加 **BubbleSizeRepresentationType** 枚举，以指定将数据表示为气泡图大小的可能方式。下面给出示例代码。
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Is a "bubble chart with 3-D effect" supported, and how does it differ from a regular one?**

Yes. There is a separate chart type, "Bubble with 3-D." It applies 3-D styling to the bubbles but does not add an additional axis; the data remain X-Y-S (size). The type is available in the [chart type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) enumeration.

**Is there a limit on the number of series and points in a bubble chart?**

There is no hard limit at the API level; constraints are determined by performance and the target PowerPoint version. It is recommended to keep the number of points reasonable for readability and rendering speed.

**How will export affect the appearance of a bubble chart (PDF, images)?**

Export to supported formats preserves the chart’s appearance; rendering is performed by the Aspose.Slides engine. For raster/vector formats, general chart-graphics rendering rules apply (resolution, anti-aliasing), so choose sufficient DPI for printing.