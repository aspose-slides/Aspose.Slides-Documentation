---
title: Administrar etiquetas de datos de gráficos en presentaciones con Python
linktitle: Etiqueta de datos
type: docs
url: /es/python-net/chart-data-label/
keywords:
- gráfico
- etiqueta de datos
- precisión de datos
- porcentaje
- distancia de etiqueta
- ubicación de etiqueta
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda a agregar y dar formato a las etiquetas de datos de gráficos en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para Python a través de .NET para diapositivas más atractivas."
---

## **Resumen**

Las etiquetas de datos en un gráfico muestran detalles sobre la serie de datos del gráfico o puntos de datos individuales. Permiten a los lectores identificar rápidamente las series de datos y también hacen que los gráficos sean más fáciles de entender. En Aspose.Slides para Python, puede habilitar, personalizar y dar formato a las etiquetas de datos para cualquier gráfico—eligiendo qué mostrar (valores, porcentajes, nombres de series o de categorías), dónde posicionar las etiquetas y cómo se ven (fuente, formato numérico, separadores, líneas guía y más). Este artículo describe las API esenciales y ejemplos que necesita para añadir etiquetas claras e informativas a sus gráficos.

## **Establecer precisión de la etiqueta de datos**

Las etiquetas de datos de un gráfico a menudo muestran valores numéricos que requieren una precisión constante. Esta sección muestra cómo controlar el número de decimales para las etiquetas de datos en Aspose.Slides aplicando un formato numérico apropiado.

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

Con Aspose.Slides, puede mostrar porcentajes como etiquetas de datos en los gráficos. El ejemplo a continuación calcula la participación de cada punto dentro de su categoría y formatea la etiqueta para mostrar el porcentaje.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Crear una instancia de la clase Presentation.
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

    # Guardar la presentación que contiene el gráfico.
    presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Mostrar signos de porcentaje con etiquetas de datos del gráfico**

Esta sección muestra cómo mostrar porcentajes en las etiquetas de datos del gráfico e incluir el signo de porcentaje usando Aspose.Slides. Aprenderá a habilitar valores de porcentaje para series completas o puntos específicos (ideal para gráficos de pastel, rosquilla y apilados al 100 %) y a controlar el formato mediante opciones de etiqueta o un formato numérico personalizado.

El siguiente ejemplo en Python muestra cómo añadir un signo de porcentaje a la etiqueta de datos de un gráfico:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# Crear una instancia de la clase Presentation.
with slides.Presentation() as presentation:

    # Obtener una referencia a la diapositiva por índice.
    slide = presentation.slides[0]

    # Crear un gráfico PercentsStackedColumn en la diapositiva.
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # Obtener el libro de datos del gráfico.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    # Añadir una nueva serie.
    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 0.65))

    # Establecer el color de relleno de la serie.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Establecer propiedades de formato de etiqueta.
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # Añadir una nueva serie.
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # Establecer el tipo de relleno y color.
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # Guardar la presentación.
    presentation.save("percentage_sign.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer distancia de etiqueta desde el eje**

Esta sección muestra cómo controlar la distancia entre las etiquetas de datos y el eje del gráfico en Aspose.Slides. Ajustar este desplazamiento ayuda a evitar superposiciones y mejora la legibilidad en visualizaciones densas.

El siguiente código en Python muestra cómo establecer la distancia de la etiqueta desde el eje de categorías al trabajar con un gráfico basado en ejes:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Crear una instancia de la clase Presentation.
with slides.Presentation() as presentation:
    # Obtener una referencia a la diapositiva.
    slide = presentation.slides[0]

    # Crear un gráfico de columnas agrupadas en la diapositiva.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Establecer la distancia de la etiqueta desde el eje de categorías (horizontal).
    chart.axes.horizontal_axis.label_offset = 500

    # Guardar la presentación.
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajustar posición de la etiqueta**

Cuando crea un gráfico que no utiliza ejes, como un gráfico de pastel, las etiquetas de datos pueden estar demasiado cerca del borde. En ese caso, ajuste la posición de la etiqueta para que las líneas guía se muestren claramente.

El siguiente código en Python muestra cómo ajustar la posición de la etiqueta en un gráfico de pastel:

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

**¿Cómo puedo evitar que las etiquetas de datos se solapen en gráficos densos?**

Combine la ubicación automática de etiquetas, líneas guía y reduzca el tamaño de fuente; si es necesario, oculte algunos campos (por ejemplo, la categoría) o muestre etiquetas solo para los puntos extremos/clave.

**¿Cómo puedo desactivar etiquetas solo para valores cero, negativos o vacíos?**

Filtre los puntos de datos antes de habilitar las etiquetas y desactive la visualización para valores de 0, negativos o ausentes según una regla definida.

**¿Cómo puedo asegurar un estilo de etiqueta consistente al exportar a PDF/imágenes?**

Establezca explícitamente las fuentes (familia, tamaño) y verifique que la fuente esté disponible en el entorno de renderizado para evitar sustituciones.