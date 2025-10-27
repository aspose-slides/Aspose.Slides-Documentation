---
title: Manage Chart Data Labels in Presentations with Python
linktitle: Data Label
type: docs
url: /es/python-net/chart-data-label/
keywords:
- chart
- data label
- data precision
- percentage
- label distance
- label location
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn to add and format chart data labels in PowerPoint and OpenDocument presentations using Aspose.Slides for Python via .NET for more engaging slides."
---

## **Visión general**

Las etiquetas de datos en un gráfico muestran detalles sobre la serie de datos del gráfico o puntos de datos individuales. Permiten a los lectores identificar rápidamente las series de datos y también facilitan la comprensión de los gráficos. En Aspose.Slides for Python, puedes habilitar, personalizar y dar formato a las etiquetas de datos para cualquier gráfico—eligiendo qué mostrar (valores, porcentajes, nombres de series o categorías), dónde colocar las etiquetas y cómo aparecen (fuente, formato numérico, separadores, líneas guía y más). Este artículo describe las API esenciales y ejemplos que necesitas para agregar etiquetas claras e informativas a tus gráficos.

## **Establecer precisión de la etiqueta de datos**

Las etiquetas de datos de los gráficos a menudo muestran valores numéricos que requieren una precisión constante. Esta sección muestra cómo controlar la cantidad de decimales para las etiquetas de datos en Aspose.Slides aplicando un formato numérico apropiado.

El siguiente ejemplo en Python muestra cómo establecer la precisión numérica para las etiquetas de datos del gráfico:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 500, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.number_format_of_values = "#,##0.00"

    presentation.save("data_label_precision.pptx", slides.export.SaveFormat.PPTX)
```

## **Mostrar porcentajes como etiquetas**

Con Aspose.Slides, puedes mostrar porcentajes como etiquetas de datos en los gráficos. El ejemplo a continuación calcula la participación de cada punto dentro de su categoría y da formato a la etiqueta para mostrar el porcentaje.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 600, 400)
    series = chart.chart_data.series[0]

    total_for_categories = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for i in range(len(chart.chart_data.series)):
            total_for_categories[k] += chart.chart_data.series[i].data_points[k].value.data

    for i in range(len(chart.chart_data.series)):
        series = chart.chart_data.series[i]
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            data_point_percent = series.data_points[j].value.data / total_for_categories[j] * 100

            text_portion = slides.Portion()
            text_portion.text = "{0:.2f} %".format(data_point_percent)
            text_portion.portion_format.font_height = 8

            label = series.data_points[j].label
            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(text_portion)

            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    # Save the presentation containing the chart.
    presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Mostrar el símbolo de porcentaje con las etiquetas de datos del gráfico**

Esta sección muestra cómo mostrar porcentajes en las etiquetas de datos del gráfico e incluir el símbolo de porcentaje usando Aspose.Slides. Aprenderás a habilitar valores de porcentaje para series completas o puntos específicos (ideal para gráficos de pastel, rosquilla y apilados al 100 %) y cómo controlar el formato mediante opciones de etiqueta o un formato numérico personalizado.

El siguiente ejemplo en Python muestra cómo añadir el símbolo de porcentaje a una etiqueta de datos del gráfico:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:

    # Get a slide reference by index.
    slide = presentation.slides[0]

    # Create a PercentsStackedColumn chart on the slide.
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # Get the chart data workbook.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    # Add a new series.
    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 0.65))

    # Set the series fill color.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Set label format properties.
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # Add a new series.
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # Set the fill type and color.
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # Save the presentation.
    presentation.save("percentage_sign.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer distancia de la etiqueta desde el eje**

Esta sección muestra cómo controlar la distancia entre las etiquetas de datos y el eje del gráfico en Aspose.Slides. Ajustar este desplazamiento ayuda a evitar traslapes y mejora la legibilidad en visualizaciones densas.

El siguiente código Python muestra cómo establecer la distancia de la etiqueta desde el eje de categorías al trabajar con un gráfico basado en ejes:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    # Get a slide reference.
    slide = presentation.slides[0]

    # Create a clustered column chart on the slide.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Set the label distance from the category (horizontal) axis.
    chart.axes.horizontal_axis.label_offset = 500

    # Save the presentation.
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajustar posición de la etiqueta**

Cuando creas un gráfico que no usa ejes, como un gráfico de pastel, las etiquetas de datos pueden quedar demasiado cerca del borde. En ese caso, ajusta la posición de la etiqueta para que las líneas guía se muestren claramente.

El siguiente código Python muestra cómo ajustar la posición de la etiqueta en un gráfico de pastel:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.show_leader_lines = True

    label = series.labels[0]
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    label.x = 0.05
    label.y = 0.1

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Posición de etiqueta cambiada](changed_label_position.png)

## **Preguntas frecuentes**

**¿Cómo puedo evitar que las etiquetas de datos se superpongan en gráficos densos?**

Combina la colocación automática de etiquetas, líneas guía y reducción del tamaño de fuente; si es necesario, oculta algunos campos (por ejemplo, la categoría) o muestra etiquetas solo para los puntos extremos/clave.

**¿Cómo puedo desactivar etiquetas solo para valores cero, negativos o vacíos?**

Filtra los puntos de datos antes de habilitar las etiquetas y desactiva la visualización para valores de 0, valores negativos o valores ausentes según una regla definida.

**¿Cómo garantizo un estilo de etiqueta consistente al exportar a PDF/imagenes?**

Establece explícitamente fuentes (familia, tamaño) y verifica que la fuente esté disponible en el lado de renderizado para evitar sustituciones.