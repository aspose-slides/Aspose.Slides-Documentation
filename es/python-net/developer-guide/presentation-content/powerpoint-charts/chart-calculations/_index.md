---
title: Optimizar los cálculos de gráficos para presentaciones en Python
linktitle: Cálculos de gráficos
type: docs
weight: 50
url: /es/python-net/chart-calculations/
keywords:
- cálculos de gráficos
- elementos del gráfico
- posición del elemento
- posición real
- elemento hijo
- elemento padre
- valores del gráfico
- valor real
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Comprenda los cálculos de gráficos, la actualización de datos y el control de precisión en Aspose.Slides para Python vía .NET para PPT, PPTX y ODP, con ejemplos de código prácticos."
---

## **Calcular valores reales de los elementos del gráfico**
Aspose.Slides for Python via .NET proporciona una API simple para obtener estas propiedades. Esto le ayudará a calcular los valores reales de los elementos del gráfico. Los valores reales incluyen la posición de los elementos que implementan la interfaz IActualLayout (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) y los valores reales de los ejes (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).
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


## **Calcular la posición real de los elementos de gráfico padre**
Aspose.Slides for Python via .NET proporciona una API simple para obtener estas propiedades. Las propiedades de IActualLayout proporcionan información sobre la posición real del elemento de gráfico padre. Es necesario llamar previamente al método IChart.ValidateChartLayout() para rellenar las propiedades con los valores reales.
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


## **Ocultar información del gráfico**
Este tema le ayuda a entender cómo ocultar información del gráfico. Con Aspose.Slides for Python via .NET puede ocultar **Título, Eje vertical, Eje horizontal** y **Líneas de la cuadrícula** del gráfico. El siguiente ejemplo de código muestra cómo usar estas propiedades.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # Ocultar el título del gráfico
    chart.has_title = False

    # Ocultar eje de valores
    chart.axes.vertical_axis.is_visible = False

    # Visibilidad del eje de categorías
    chart.axes.horizontal_axis.is_visible = False

    # Ocultar la leyenda
    chart.has_legend = False

    # Ocultar líneas de cuadrícula principales
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # Establecer color de línea de la serie
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**¿Los libros de Excel externos funcionan como fuente de datos y cómo afecta eso a la recalculación?**

Sí. Un gráfico puede hacer referencia a un libro externo: cuando se conecta o actualiza la fuente externa, las fórmulas y valores se toman de ese libro, y el gráfico refleja las actualizaciones durante las operaciones de apertura/edición. La API le permite [especificar la ruta del libro externo](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) y gestionar los datos vinculados.

**¿Puedo calcular y mostrar líneas de tendencia sin implementar la regresión yo mismo?**

Sí. Las [líneas de tendencia](/slides/es/python-net/trend-line/) (lineales, exponenciales y otras) son añadidas y actualizadas por Aspose.Slides; sus parámetros se recalculan automáticamente a partir de los datos de la serie, por lo que no es necesario que implemente sus propios cálculos.

**¿Si una presentación tiene varios gráficos con enlaces externos, puedo controlar qué libro usa cada gráfico para los valores calculados?**

Sí. Cada gráfico puede apuntar a su propio [libro externo](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/), o puede crear/reemplazar un libro externo por gráfico de forma independiente de los demás.