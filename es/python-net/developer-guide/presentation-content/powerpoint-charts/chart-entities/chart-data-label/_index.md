---
title: Gestionar etiquetas de datos de gráficos en presentaciones con Python
linktitle: Etiqueta de datos
type: docs
url: /es/python-net/chart-data-label/
keywords:
- gráfico
- etiqueta de datos
- precisión de datos
- porcentaje
- distancia de la etiqueta
- ubicación de la etiqueta
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprenda a añadir y dar formato a las etiquetas de datos de gráficos en presentaciones de PowerPoint usando Aspose.Slides para Python a través de .NET para diapositivas más atractivas."
---
## **Introducción**

Las etiquetas de datos muestran información sobre las series del gráfico y los puntos de datos individuales, ayudando a los lectores a identificar valores y comprender el gráfico. Este artículo explica cómo dar formato a los valores, mostrar porcentajes, leer el texto de la etiqueta, ajustar el espacio entre las etiquetas del eje de categorías y posicionar las etiquetas de los gráficos circulares.

## **Establecer la precisión de los datos en las etiquetas de datos del gráfico**

Utilice [number_format_of_values](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartseries/number_format_of_values/) para dar formato a los valores de la serie. Este ejemplo crea un gráfico de líneas con datos predeterminados, muestra su tabla de datos y habilita las etiquetas de valores para la primera serie. El formato `#,##0.00` muestra un separador de miles y dos decimales sin cambiar los valores subyacentes.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
    chart.has_data_table = True

    series = chart.chart_data.series[0]
    series.number_format_of_values = "#,##0.00"
    series.labels.default_data_label_format.show_value = True

    presentation.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Mostrar el porcentaje como etiquetas**

Para un gráfico de columnas apiladas, calcule cada valor como un porcentaje del total de su categoría y asigne el texto a [text_frame_for_overriding](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). Este ejemplo utiliza los datos predeterminados del gráfico y muestra los porcentajes con dos decimales en una fuente de 8 puntos. Las categorías con un total cero se omiten para evitar una división por cero. Recalcule el texto de la etiqueta personalizada si los datos del gráfico cambian.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)

    category_totals = [0.0] * len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for series in chart.chart_data.series:
            point_value = float(series.data_points[k].value.data)
            category_totals[k] += point_value

    for series in chart.chart_data.series:
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            label = series.data_points[j].label
            if category_totals[j] == 0:
                continue

            point_value = float(series.data_points[j].value.data)
            data_point_percent = point_value / category_totals[j] * 100

            portion = slides.Portion()
            portion.text = f"{data_point_percent:.2f} %"
            portion.portion_format.font_height = 8

            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(portion)

            label.data_label_format.show_value = True
            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer el signo de porcentaje en las etiquetas de datos del gráfico**

Cuando los valores se almacenan como fracciones, utilice [number_format](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/datalabelformat/number_format/) para mostrar porcentajes. Establezca [is_number_format_linked_to_source](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) a `False` para aplicar el formato de la etiqueta independientemente de las celdas de origen.

Este ejemplo crea un gráfico de columnas apiladas al 100% con series roja y azul en cuatro categorías. Cada par de valores suma 1. El formato de etiqueta `0.0%` muestra 0.30 como 30.0%, mientras que el eje vertical utiliza dos decimales. Ambas series usan texto de etiqueta blanco de 10 puntos.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [drawing.Color.red, drawing.Color.blue]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i in range(len(series_names)):
        series_cell = workbook.get_cell(worksheet_index, 0, i + 1, series_names[i])
        series = chart.chart_data.series.add(series_cell, chart.type)
        for j in range(4):
            value_cell = workbook.get_cell(worksheet_index, j + 1, i + 1, values[i][j])
            series.data_points.add_data_point_for_bar_series(value_cell)

        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = series_colors[i]

        label_format = series.labels.default_data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = False
        label_format.number_format = "0.0%"
        label_format.text_format.portion_format.font_height = 10
        label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.text_format.portion_format.fill_format.solid_fill_color.color = drawing.Color.white

    presentation.save("SetDataLabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Leer el texto real de las etiquetas de datos**

Utilice [get_actual_label_text](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) para obtener el texto generado por la configuración de una etiqueta de datos. Esto es útil al extraer etiquetas para informes, buscar contenido en la presentación o validar gráficos generados. En el ejemplo siguiente, el [formato de etiqueta de datos](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/datalabelformat/) predeterminado combina el nombre de cada categoría, el nombre de la serie y el valor. Un punto formatea su valor como porcentaje y otro usa texto personalizado de [text_frame_for_overriding](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    for i, category_name in enumerate(["Q1", "Q2"]):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    north_cell = workbook.get_cell(0, 0, 1, "North")
    north = chart.chart_data.series.add(north_cell, chart.type)
    for i, value in enumerate([0.25, 0.75]):
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        north.data_points.add_data_point_for_bar_series(value_cell)

    south_cell = workbook.get_cell(0, 0, 2, "South")
    south = chart.chart_data.series.add(south_cell, chart.type)
    for i, value in enumerate([0.40, 0.60]):
        value_cell = workbook.get_cell(0, i + 1, 2, value)
        south.data_points.add_data_point_for_bar_series(value_cell)

    for series in chart.chart_data.series:
        label_format = series.labels.default_data_label_format
        label_format.show_category_name = True
        label_format.show_series_name = True
        label_format.show_value = True

    north.labels[1].data_label_format.is_number_format_linked_to_source = False
    north.labels[1].data_label_format.number_format = "0%"
    south.labels[0].text_frame_for_overriding.text = "Reviewed"

    for series in chart.chart_data.series:
        for point in series.data_points:
            label = point.label
            if not label.is_visible:
                continue

            label_text = label.get_actual_label_text()
            print(f"Value: {point.value.data}; label: {label_text}")
```

El número almacenado en un punto de datos sigue siendo `0.75`, incluso cuando su etiqueta muestra `75%` junto con los nombres de la categoría y la serie. El texto personalizado reemplaza el texto de etiqueta generado. [get_actual_label_text](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) devuelve la cadena de etiqueta resultante en ambos casos. Compruebe [is_visible](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/datalabel/is_visible/) por separado, como se muestra arriba, cuando desee extraer solo las etiquetas visibles.

## **Establecer la distancia de la etiqueta respecto a un eje**

Utilice [label_offset](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/axis/label_offset/) para controlar la distancia entre las etiquetas del eje de categorías y el eje. El valor es un porcentaje del tamaño máximo de fuente de las etiquetas del eje. Este ejemplo crea un gráfico de columnas agrupadas y establece el desplazamiento de la etiqueta del eje horizontal a 500. Esta configuración afecta a las etiquetas del eje de categorías y no a las etiquetas vinculadas a puntos de datos individuales.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajustar la ubicación de la etiqueta**

En un gráfico circular, ajuste las posiciones de las etiquetas de datos para mejorar el espaciado y dejar espacio a las líneas guía.

Este ejemplo muestra el valor del primer punto de datos, coloca su etiqueta fuera de la porción y ajusta sus desplazamientos [x](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/datalabel/x/) y [y](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/datalabel/y/). Estos desplazamientos son relativos al ancho y alto del gráfico, respectivamente.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 200, 200)
    series = chart.chart_data.series

    label = series[0].labels[0]
    label.data_label_format.show_value = True
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label.x = 0.71
    label.y = 0.04

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Gráfico circular con la posición de la etiqueta de datos ajustada](pie-chart-adjusted-label.png)

## **Preguntas frecuentes**

**¿Cómo puedo evitar que las etiquetas de datos se superpongan en gráficos densos?**

Combine la colocación automática de etiquetas, líneas guía y reduzca el tamaño de la fuente; si es necesario, oculte algunos campos (por ejemplo, la categoría) o muestre etiquetas solo para valores extremos o puntos clave.

**¿Cómo puedo desactivar las etiquetas solo para valores cero, negativos o vacíos?**

Filtre los puntos de datos antes de habilitar las etiquetas y desactive la visualización para valores de 0, valores negativos o valores ausentes según una regla definida.

**¿Cómo puedo garantizar un estilo de etiqueta consistente al exportar a PDF/imágenes?**

Establezca explícitamente la familia y el tamaño de la fuente y verifique que la fuente esté disponible en el entorno de renderizado para evitar sustituciones.