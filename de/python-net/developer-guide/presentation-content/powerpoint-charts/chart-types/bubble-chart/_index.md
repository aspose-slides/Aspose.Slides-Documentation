---
title: Blasendiagramm
type: docs
url: /python-net/bubble-chart/
keywords: "Blasendiagramm, Diagrammgröße, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Blasendiagrammgröße in PowerPoint-Präsentationen in Python"
---

## **Scaling der Blasendiagrammgröße**
Aspose.Slides für Python über .NET unterstützt das Scaling der Blasendiagrammgröße. In Aspose.Slides für Python über .NET wurden die Eigenschaften **ChartSeries.bubble_size_scale** und **ChartSeriesGroup.bubble_size_scale** hinzugefügt. Ein Beispiel ist unten angegeben.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```




## **Daten als Blasendiagrammgrößen darstellen**
Die Eigenschaft **bubble_size_representation** wurde zu den Klassen ChartSeries und ChartSeriesGroup hinzugefügt. **bubble_size_representation** gibt an, wie die Blasengrößenwerte im Blasendiagramm dargestellt werden. Mögliche Werte sind: **BubbleSizeRepresentationType.AREA** und **BubbleSizeRepresentationType.WIDTH**. Entsprechend wurde das **BubbleSizeRepresentationType**-Enum hinzugefügt, um die möglichen Arten zur Darstellung von Daten als Blasendiagrammgrößen anzugeben. Beispielcode ist unten angegeben.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```