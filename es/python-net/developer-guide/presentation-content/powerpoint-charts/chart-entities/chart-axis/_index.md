---
title: Ejes del Gráfico
type: docs
url: /python-net/chart-axis/
keywords: "Ejes del Gráfico de PowerPoint, Gráficos de Presentación, Python, Manipular Ejes del Gráfico, Datos del gráfico"
description: "Editar los ejes del gráfico de PowerPoint en Python"
---


## **Obteniendo los Valores Máximos en el Eje Vertical de los Gráficos**
Aspose.Slides para Python a través de .NET te permite obtener los valores mínimos y máximos en un eje vertical. Sigue estos pasos:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) clase.
1. Accede a la primera diapositiva.
1. Agrega un gráfico con datos predeterminados.
1. Obtén el valor máximo real en el eje.
1. Obtén el valor mínimo real en el eje.
1. Obtén la unidad mayor real del eje.
1. Obtén la unidad menor real del eje.
1. Obtén la escala de unidad mayor real del eje.
1. Obtén la escala de unidad menor real del eje.

Este código de muestra—una implementación de los pasos anteriores—te muestra cómo obtener los valores requeridos en Python:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
	chart.validate_chart_layout()

	maxValue = chart.axes.vertical_axis.actual_max_value
	minValue = chart.axes.vertical_axis.actual_min_value

	majorUnit = chart.axes.horizontal_axis.actual_major_unit
	minorUnit = chart.axes.horizontal_axis.actual_minor_unit
	
	# Guarda la presentación
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Intercambiando los Datos entre los Ejes**
Aspose.Slides te permite intercambiar rápidamente los datos entre los ejes—los datos representados en el eje vertical (eje y) se mueven al eje horizontal (eje x) y viceversa. 

Este código en Python te muestra cómo realizar la tarea de intercambio de datos entre ejes en un gráfico:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Crea una presentación vacía
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    # Intercambia filas y columnas
    chart.chart_data.switch_row_column()
            
    # Guarda la presentación
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Deshabilitando el Eje Vertical para Gráficos de Líneas**

Este código en Python te muestra cómo ocultar el eje vertical para un gráfico de líneas:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **Deshabilitando el Eje Horizontal para Gráficos de Líneas**

Este código te muestra cómo ocultar el eje horizontal para un gráfico de líneas:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **Cambiando el Eje de Categoría**

Usando la propiedad **CategoryAxisType**, puedes especificar tu tipo de eje de categoría preferido (**fecha** o **texto**). Este código en Python demuestra la operación: 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS
    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Estableciendo el Formato de Fecha para el Valor del Eje de Categoría**
Aspose.Slides para Python a través de .NET te permite establecer el formato de fecha para un valor del eje de categoría. La operación se demuestra en este código de Python:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
from datetime import date

def to_oadate(dt):
    delta = dt - date(1899, 12, 30)
    return delta.days + (delta.seconds + delta.microseconds / 1e6) / (24 * 3600)

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 50, 50, 450, 300)

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    chart.chart_data.categories.add(wb.get_cell(0, "A2", to_oadate(date(2015, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", to_oadate(date(2016, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", to_oadate(date(2017, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", to_oadate(date(2018, 1, 1))))

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B2", 1))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B3", 2))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B4", 3))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B5", 4))
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"
    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Estableciendo el Ángulo de Rotación para el Título del Eje del Gráfico**
Aspose.Slides para Python a través de .NET te permite establecer el ángulo de rotación para un título del eje del gráfico. Este código en Python demuestra la operación:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Estableciendo el Eje de Posición en un Eje de Categoría o Valor**
Aspose.Slides para Python a través de .NET te permite establecer el eje de posición en un eje de categoría o valor. Este código en Python muestra cómo realizar la tarea:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Habilitando la Etiqueta de la Unidad de Visualización en el Eje de Valor del Gráfico**
Aspose.Slides para Python a través de .NET te permite configurar un gráfico para mostrar una etiqueta de unidad en su eje de valor del gráfico. Este código en Python demuestra la operación:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```