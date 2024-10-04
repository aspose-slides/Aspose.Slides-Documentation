---
title: Gráfico de Burbuja
type: docs
url: /python-net/bubble-chart/
keywords: "Gráfico de burbuja, tamaño del gráfico, presentación de PowerPoint, Python, Aspose.Slides for Python via .NET"
description: "Tamaño del gráfico de burbuja en presentaciones de PowerPoint en Python"
---

## **Escalado del Tamaño del Gráfico de Burbuja**
Aspose.Slides for Python via .NET proporciona soporte para el escalado del tamaño del gráfico de burbuja. En Aspose.Slides for Python via .NET se han añadido las propiedades **ChartSeries.bubble_size_scale** y **ChartSeriesGroup.bubble_size_scale**. A continuación se presenta un ejemplo de código.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
    chart.chart_data.series_groups[0].bubble_size_scale = 150
    pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```


## **Representar Datos como Tamaños de Gráfico de Burbuja**
Se ha añadido la propiedad **bubble_size_representation** a las clases ChartSeries y ChartSeriesGroup. **bubble_size_representation** especifica cómo se representan los valores de tamaño de burbuja en el gráfico de burbuja. Los valores posibles son: **BubbleSizeRepresentationType.AREA** y **BubbleSizeRepresentationType.WIDTH**. En consecuencia, se ha añadido el enumerado **BubbleSizeRepresentationType** para especificar las posibles formas de representar datos como tamaños de gráfico de burbuja. A continuación se proporciona un código de muestra.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```