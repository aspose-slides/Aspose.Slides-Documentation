---
title: График пузырьков
type: docs
url: /ru/python-net/bubble-chart/
keywords: "График пузырьков, размер графика, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Размер графика пузырьков в презентациях PowerPoint на Python"
---

## **Масштабирование размера графика пузырьков**
Aspose.Slides для Python через .NET поддерживает масштабирование размера графика пузырьков. В Aspose.Slides для Python через .NET были добавлены свойства **ChartSeries.bubble_size_scale** и **ChartSeriesGroup.bubble_size_scale**. Приведен пример ниже.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Представление данных в виде размеров графиков пузырьков**
Свойство **bubble_size_representation** было добавлено в классы ChartSeries, ChartSeriesGroup. **bubble_size_representation** определяет, как значения размера пузырьков представлены в графике пузырьков. Возможные значения: **BubbleSizeRepresentationType.AREA** и **BubbleSizeRepresentationType.WIDTH**. Соответственно, был добавлен перечисляемый тип **BubbleSizeRepresentationType** для указания возможных способов представления данных в виде размеров графиков пузырьков. Пример кода приведен ниже.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```