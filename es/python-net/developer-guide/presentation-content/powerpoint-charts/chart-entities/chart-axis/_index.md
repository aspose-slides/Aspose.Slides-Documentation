---
title: Personalizar ejes de gráfico en presentaciones con Python
linktitle: Eje de gráfico
type: docs
url: /es/python-net/developer-guide/presentation-content/powerpoint-charts/chart-entities/chart-axis/
keywords:
- eje de gráfico
- eje vertical
- eje horizontal
- personalizar eje
- manipular eje
- administrar eje
- propiedades del eje
- valor máximo
- valor mínimo
- línea del eje
- formato de fecha
- título del eje
- posición del eje
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Descubra cómo usar Aspose.Slides for Python vía .NET para personalizar los ejes de los gráficos en presentaciones de PowerPoint y OpenDocument para informes y visualizaciones."
---

## **Obtener los valores máximos en el eje vertical de los gráficos**
Aspose.Slides for Python vía .NET le permite obtener los valores mínimo y máximo en un eje vertical. Siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Acceda a la primera diapositiva.
3. Añada un gráfico con datos predeterminados.
4. Obtenga el valor máximo real del eje.
5. Obtenga el valor mínimo real del eje.
6. Obtenga la unidad mayor real del eje.
7. Obtenga la unidad menor real del eje.
8. Obtenga la escala de unidad mayor real del eje.
9. Obtenga la escala de unidad menor real del eje.

Este fragmento de código—una implementación de los pasos anteriores—le muestra cómo obtener los valores requeridos en Python:

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
	
	# Saves the presentation
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Intercambiar los datos entre ejes**
Aspose.Slides le permite intercambiar rápidamente los datos entre ejes: los datos representados en el eje vertical (eje Y) se trasladan al eje horizontal (eje X) y viceversa.

Este código Python le muestra cómo realizar la tarea de intercambio de datos entre ejes en un gráfico:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Creates empty presentation
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    #Switches rows and columns
    chart.chart_data.switch_row_column()
            
    # Saves presentation
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Desactivar el eje vertical para gráficos de líneas**

Este código Python le muestra cómo ocultar el eje vertical en un gráfico de líneas:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **Desactivar el eje horizontal para gráficos de líneas**

Este código le muestra cómo ocultar el eje horizontal en un gráfico de líneas:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **Cambiar el eje de categorías**

Usando la propiedad **CategoryAxisType**, puede especificar el tipo de eje de categorías que prefiera (**date** o **text**). Este código en Python demuestra la operación:

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

## **Establecer el formato de fecha para el valor del eje de categorías**
Aspose.Slides for Python vía .NET le permite establecer el formato de fecha para un valor del eje de categorías. La operación se muestra en este código Python:

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

## **Establecer el ángulo de rotación para el título del eje del gráfico**
Aspose.Slides for Python vía .NET le permite establecer el ángulo de rotación para el título de un eje del gráfico. Este código Python demuestra la operación:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer la posición del eje en un eje de categoría o de valores**
Aspose.Slides for Python vía .NET le permite definir la posición del eje en un eje de categoría o de valores. Este código Python muestra cómo realizar la tarea:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Habilitar la etiqueta de unidad de visualización en el eje de valores del gráfico**
Aspose.Slides for Python vía .NET le permite configurar un gráfico para que muestre una etiqueta de unidad en su eje de valores. Este código Python demuestra la operación:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Cómo establezco el valor en el que un eje cruza al otro (cruce de ejes)?**

Los ejes proporcionan una [configuración de cruce](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/): puede elegir cruzar en cero, en la categoría/valor máximo, o en un valor numérico específico. Esto es útil para desplazar el eje X hacia arriba o abajo o para resaltar una línea base.

**¿Cómo puedo posicionar las etiquetas de graduación en relación con el eje (a un lado, fuera, dentro)?**

Establezca la [posición de la etiqueta](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) a "cross", "outside" o "inside". Esto afecta la legibilidad y ayuda a conservar espacio, especialmente en gráficos pequeños.