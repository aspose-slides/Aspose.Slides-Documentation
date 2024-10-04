---
title: Cálculos de Gráficos
type: docs
weight: 50
url: /python-net/chart-calculations/
keywords: "Cálculos de gráficos, elementos del gráfico, posición del elemento, valores del gráfico Python, Aspose.Slides para Python a través de .NET"
description: "Cálculos y valores de gráficos de PowerPoint en Python"
---

## **Calcular Valores Actuales de los Elementos del Gráfico**
Aspose.Slides para Python a través de .NET proporciona una API simple para obtener estas propiedades. Esto te ayudará a calcular los valores actuales de los elementos del gráfico. Los valores actuales incluyen la posición de los elementos que implementan la interfaz IActualLayout (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) y los valores reales de los ejes (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    maxValue = chart.axes.vertical_axis.actual_max_value
    minValue = chart.axes.vertical_axis.actual_min_value
    majorUnit = chart.axes.horizontal_axis.actual_major_unit
    minorUnit = chart.axes.horizontal_axis.actual_minor_unit
```



## **Calcular Posición Actual de los Elementos del Gráfico Padre**
Aspose.Slides para Python a través de .NET proporciona una API simple para obtener estas propiedades. Las propiedades de IActualLayout proporcionan información sobre la posición actual del elemento gráfico padre. Es necesario llamar al método IChart.ValidateChartLayout() previamente para llenar las propiedades con valores actuales.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
```



## **Ocultar Información del Gráfico**
Este tema te ayuda a entender cómo ocultar información del gráfico. Usando Aspose.Slides para Python a través de .NET puedes ocultar **Título, Eje Vertical, Eje Horizontal** y **Líneas de Cuadrícula** del gráfico. A continuación, el ejemplo de código muestra cómo usar estas propiedades.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # Ocultar el título del gráfico
    chart.has_title = False

    # Ocultar el eje de valores
    chart.axes.vertical_axis.is_visible = False

    # Visibilidad del eje de categoría
    chart.axes.horizontal_axis.is_visible = False

    # Ocultar la leyenda
    chart.has_legend = False

    # Ocultar Líneas de Cuadrícula Mayores
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # Establecer el color de la línea de la serie
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```