---
title: Etiqueta de Datos de Gráfico
type: docs
url: /es/python-net/chart-data-label/
keywords: "Etiqueta de datos de gráfico, distancia de etiqueta, Python, Aspose.Slides para Python a través de .NET"
description: "Establecer la etiqueta de datos de gráfico de PowerPoint y la distancia en Python"
---

Las etiquetas de datos en un gráfico muestran detalles sobre la serie de datos del gráfico o puntos de datos individuales. Permiten a los lectores identificar rápidamente las series de datos y también facilitan la comprensión de los gráficos.

## **Establecer Precisión de Datos en Etiquetas de Datos de Gráfico**

Este código Python te muestra cómo establecer la precisión de los datos en una etiqueta de datos de gráfico:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
    chart.has_data_table = True
    chart.chart_data.series[0].number_format_of_values = "#,##0.00"

    pres.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Mostrar Porcentaje como Etiquetas**
Aspose.Slides para Python a través de .NET te permite establecer etiquetas de porcentaje en gráficos mostrados. Este código Python demuestra la operación:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Crea una instancia de la clase Presentation
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)
    series = chart.chart_data.series[0]
    total_for_Cat = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        cat = chart.chart_data.categories[k]
        for i in range(len(chart.chart_data.series)):
            total_for_Cat[k] += chart.chart_data.series[i].data_points[k].value.data

dataPontPercent = 0

for x in range(len(chart.chart_data.series)):
    series = chart.chart_data.series[x]
    series.labels.default_data_label_format.show_legend_key = False

    for j in range(len(series.data_points)):
        lbl = series.data_points[j].label
        dataPontPercent = series.data_points[j].value.data / total_for_Cat[j] * 100

        port = slides.Portion()
        port.text = "{0:.2f} %".format(dataPontPercent)
        port.portion_format.font_height = 8
        lbl.text_frame_for_overriding.text = ""
        para = lbl.text_frame_for_overriding.paragraphs[0]
        para.portions.add(port)

        lbl.data_label_format.show_series_name = False
        lbl.data_label_format.show_percentage = False
        lbl.data_label_format.show_legend_key = False
        lbl.data_label_format.show_category_name = False
        lbl.data_label_format.show_bubble_size = False

# Guarda la presentación que contiene el gráfico
presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer Signo de Porcentaje con Etiquetas de Datos de Gráfico**
Este código Python te muestra cómo establecer el signo de porcentaje para una etiqueta de datos de gráfico:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Crea una instancia de la clase Presentation
with slides.Presentation() as presentation:

    # Obtiene la referencia de una diapositiva a través de su índice
    slide = presentation.slides[0]

    # Crea el gráfico de Columna Apilada de Porcentajes en una diapositiva
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    # Establece el NumberFormatLinkedToSource en falso
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    defaultWorksheetIndex = 0

    # Obtiene la hoja de trabajo de datos del gráfico
    workbook = chart.chart_data.chart_data_workbook

    # Agrega nuevas series
    series = chart.chart_data.series.add(workbook.get_cell(defaultWorksheetIndex, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 4, 1, 0.65))

    # Establece el color de relleno de la serie
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Establece las propiedades de LabelFormat
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # Agrega nuevas series
    series2 = chart.chart_data.series.add(workbook.get_cell(defaultWorksheetIndex, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 4, 2, 0.35))

    # Establece el tipo de relleno y color
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # Escribe la presentación en disco
    presentation.save("SetDatalabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer Distancia de Etiqueta Desde el Eje**
Este código Python te muestra cómo establecer la distancia de la etiqueta desde un eje de categoría cuando estás trabajando con un gráfico trazado desde ejes:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

    # Crea una instancia de la clase Presentation
with slides.Presentation() as presentation:
    # Obtiene la referencia de una diapositiva
    sld = presentation.slides[0]
    
    # Crea un gráfico en la diapositiva
    ch = sld.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Establece la distancia de etiqueta desde un eje
    ch.axes.horizontal_axis.label_offset = 500

    # Escribe la presentación en disco
    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajustar Ubicación de Etiquetas**

Cuando creas un gráfico que no depende de ningún eje, como un gráfico de pastel, las etiquetas de datos del gráfico pueden terminar demasiado cerca de su borde. En tal caso, debes ajustar la ubicación de la etiqueta de datos para que las líneas de liderazgo se muestren claramente.

Este código Python te muestra cómo ajustar la ubicación de la etiqueta en un gráfico de pastel:

```python
import aspose.slides as slides


with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.PIE, 50, 50, 200, 200)

    series = chart.chart_data.series
    label = series[0].labels[0]

    label.data_label_format.show_value = True
    label.data_label_format.position = slides.charts.LegendDataLabelPosition.OUTSIDE_END
    label.x = 0.71
    label.y = 0.04

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)