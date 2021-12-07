---
title: Bubble Chart
type: docs
url: /pythonnet/bubble-chart/
keywords: "Bubble chart, chart size, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Bubble chart size in PowerPoint presentations in Python"
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

