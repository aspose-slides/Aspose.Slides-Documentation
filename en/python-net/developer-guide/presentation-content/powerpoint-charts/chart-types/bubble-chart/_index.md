---
title: Customize Bubble Charts in Presentations with Python
linktitle: Bubble Chart
type: docs
url: /python-net/bubble-chart/
keywords:
- bubble chart
- bubble size
- size scaling
- size representation
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Create and customize powerful bubble charts in PowerPoint and OpenDocument with Aspose.Slides for Python via .NET to enhance your data visualization easily."
---

## **Bubble Chart Size Scaling**
Aspose.Slides for Python via .NET provides support for Bubble chart size scaling. In Aspose.Slides for Python via .NET **ChartSeries.bubble_size_scale** and **ChartSeriesGroup.bubble_size_scale** properties have been added. Below sample example is given. 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```




## **Represent Data as Bubble Chart Sizes**
Property **bubble_size_representation** has been added to ChartSeries, ChartSeriesGroup classes. **bubble_size_representation** specifies how the bubble size values are represented in the bubble chart. Possible values are: **BubbleSizeRepresentationType.AREA** and **BubbleSizeRepresentationType.WIDTH**. Accordingly, **BubbleSizeRepresentationType** enum has been added to specify the possible ways to represent data as bubble chart sizes. Sample code is given below.

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
