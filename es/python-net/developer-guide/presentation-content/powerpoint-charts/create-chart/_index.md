---
title: Crear o actualizar gráficos de presentación PowerPoint en Python
linktitle: Crear o actualizar gráficos
type: docs
weight: 10
url: /es/python-net/create-chart/
keywords:
- añadir gráfico
- crear gráfico
- editar gráfico
- cambiar gráfico
- actualizar gráfico
- gráfico disperso
- gráfico circular
- gráfico de líneas
- gráfico de mapa de árbol
- gráfico de cotización
- gráfico de caja y bigotes
- gráfico de embudo
- gráfico de rayos
- gráfico de histograma
- gráfico de radar
- gráfico multicategórico
- presentación PowerPoint
- Python
- Aspose.Slides
description: "Aprenda a crear y personalizar gráficos en presentaciones de PowerPoint y OpenDocument utilizando Aspose.Slides para Python a través de .NET. Se cubren la inserción, el formato y la edición de gráficos en presentaciones con ejemplos de código prácticos en Python."
---
## **Descripción general**

Este artículo explica cómo crear y personalizar gráficos utilizando Aspose.Slides para Python a través de .NET. Aprenderá cómo añadir un gráfico a una diapositiva, rellenarlo con datos y formatearlo para que coincida con sus requisitos de diseño. Los ejemplos de código cubren la creación de presentaciones y gráficos, la configuración de series, ejes y leyendas, y la integración de la generación de gráficos en sus aplicaciones.

## **Crear un gráfico**

Los gráficos ayudan a las personas a visualizar datos rápidamente y a obtener información que puede no ser evidente a primera vista en una tabla o hoja de cálculo.

**¿Por qué crear gráficos?**

Con los gráficos, puede:

* agregar, condensar o resumir grandes cantidades de datos en una sola diapositiva de una presentación;
* mostrar patrones y tendencias en los datos;
* deducir la dirección y el impulso de los datos a lo largo del tiempo o respecto a una unidad de medida específica;
* identificar valores atípicos, aberraciones, desviaciones, errores y datos sin sentido;
* comunicar o presentar datos complejos.

En PowerPoint, puede crear gráficos mediante la función *Insertar*, que proporciona plantillas para diseñar muchos tipos de gráficos. Con Aspose.Slides, puede crear tanto gráficos habituales (basados en tipos de gráficos populares) como gráficos personalizados.

{{% alert color="info" title="Nota" %}}
Utilice la enumeración [ChartType](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/charttype/) del espacio de nombres [Aspose.Slides.Charts](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/). Los valores de esta enumeración corresponden a diferentes tipos de gráficos.
{{% /alert %}}

### **Crear gráficos de columnas agrupadas**

Esta sección explica cómo crear gráficos de columnas agrupadas usando Aspose.Slides para Python a través de .NET. Aprenderá a iniciar una presentación, añadir un gráfico y personalizar sus elementos, como el título, los datos, las series, las categorías y el estilo. Siga los pasos a continuación para ver cómo se genera un gráfico de columnas agrupadas estándar:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Obtenga una referencia a una diapositiva mediante su índice.
1. Añada un gráfico con algunos datos y especifique el tipo `ChartType.CLUSTERED_COLUMN`.
1. Añada un título al gráfico.
1. Acceda a la hoja de datos del gráfico.
1. Elimine todas las series y categorías predeterminadas.
1. Añada series y categorías nuevas.
1. Añada nuevos datos de gráfico para las series.
1. Aplique un color de relleno a las series del gráfico.
1. Añada etiquetas a las series del gráfico.
1. Guarde la presentación modificada como un archivo PPTX.

Este código Python muestra cómo crear un gráfico de columnas agrupadas:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar la clase Presentation que representa un archivo PPTX.
with slides.Presentation() as presentation:

    # Acceder a la primera diapositiva.
    slide = presentation.slides[0]

    # Añadir un gráfico de columnas agrupadas con sus datos predeterminados.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Establecer el título del gráfico.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Establecer el índice de la hoja de datos del gráfico.
    worksheet_index = 0

    # Obtener el libro de datos del gráfico.
    workbook = chart.chart_data.chart_data_workbook

    # Eliminar las series y categorías generadas por defecto.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Añadir series nuevas.
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

    # Añadir categorías nuevas.
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

    # Obtener la primera serie del gráfico.
    series = chart.chart_data.series[0]

    # Rellenar los datos de la serie.
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # Establecer el color de relleno para la serie.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Obtener la segunda serie del gráfico.
    series = chart.chart_data.series[1]

    # Rellenar los datos de la serie.
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    # Establecer el color de relleno para la serie.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    # Establecer la primera etiqueta para mostrar el nombre de la categoría.
    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    # Establecer la serie para mostrar el valor en la tercera etiqueta.
    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"
                
    # Guardar la presentación en disco como archivo PPTX.
    presentation.save("ClusteredColumnChart.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![The clustered column chart](clustered_column_chart.png)

### **Crear gráficos de dispersión**

Los gráficos de dispersión (también conocidos como diagramas de dispersión o gráficos xy) se utilizan a menudo para comprobar patrones o demostrar correlaciones entre dos variables.

Utilice un gráfico de dispersión cuando:

* Tiene datos numéricos emparejados.
* Tiene dos variables que se asocian bien entre sí.
* Desea determinar si las dos variables están relacionadas.
* Posee una variable independiente que tiene múltiples valores para una variable dependiente.

Este código Python muestra cómo crear un gráfico de dispersión con marcadores diferentes para cada serie:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar la clase Presentation.
with slides.Presentation() as presentation:

    # Acceder a la primera diapositiva.
    slide = presentation.slides[0]

    # Crear el gráfico de dispersión predeterminado.
    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 20, 20, 500, 300)

    # Establecer el índice de la hoja de datos del gráfico.
    worksheet_index = 0

    # Obtener el libro de datos del gráfico.
    workbook = chart.chart_data.chart_data_workbook

    # Eliminar la serie predeterminada.
    chart.chart_data.series.clear()

    # Añadir series nuevas.
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 3, "Series 2"), chart.type)

    # Obtener la primera serie del gráfico.
    series = chart.chart_data.series[0]

    # Añadir un nuevo punto (1:3) a la serie.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 1, 1), workbook.get_cell(worksheet_index, 2, 2, 3))

    # Añadir un nuevo punto (2:10).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 1, 2), workbook.get_cell(worksheet_index, 3, 2, 10))

    # Cambiar el tipo de serie.
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # Cambiar el marcador de la serie del gráfico.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # Obtener la segunda serie del gráfico.
    series = chart.chart_data.series[1]

    # Añadir un nuevo punto (5:2) a la serie del gráfico.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 5), workbook.get_cell(worksheet_index, 2, 4, 2))

    # Añadir un nuevo punto (3:1).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 3, 3), workbook.get_cell(worksheet_index, 3, 4, 1))

    # Añadir un nuevo punto (2:2).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 4, 3, 2), workbook.get_cell(worksheet_index, 4, 4, 2))

    # Añadir un nuevo punto (5:1).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 5, 3, 5), workbook.get_cell(worksheet_index, 5, 4, 1))

    # Cambiar el marcador de la serie del gráfico.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("ScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![The scatter chart](scatter_chart.png)

### **Crear gráficos circulares**

Los gráficos circulares son más adecuados para mostrar la relación parte‑todo en los datos, sobre todo cuando los datos contienen etiquetas categóricas con valores numéricos. Sin embargo, si sus datos contienen muchas partes o etiquetas, podría considerar usar un gráfico de barras en su lugar.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Obtenga una referencia a una diapositiva mediante su índice.
1. Añada un gráfico con datos predeterminados y especifique el tipo `ChartType.PIE`.
1. Acceda al libro de datos del gráfico ([ChartDataWorkbook](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Elimine las series y categorías predeterminadas.
1. Añada series y categorías nuevas.
1. Añada nuevos datos de gráfico para las series.
1. Añada nuevos puntos al gráfico y aplique colores personalizados a los sectores del gráfico circular.
1. Defina etiquetas para las series.
1. Active las líneas guía para las etiquetas de las series.
1. Defina el ángulo de rotación del gráfico circular.
1. Guarde la presentación modificada como un archivo PPTX.

Este código Python muestra cómo crear un gráfico circular:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar la clase Presentation que representa un archivo PPTX.
with slides.Presentation() as presentation:

    # Acceder a la primera diapositiva.
    slide = presentation.slides[0]

    # Añadir un gráfico con sus datos predeterminados.
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    # Establecer el título del gráfico.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Establecer el índice de la hoja de datos del gráfico.
    worksheet_index = 0

    # Obtener el libro de datos del gráfico.
    workbook = chart.chart_data.chart_data_workbook

    # Eliminar las series y categorías generadas por defecto.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Añadir categorías nuevas.
    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "First Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "2nd Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "3rd Qtr"))

    # Añadir series nuevas.
    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # Rellenar los datos de la serie.
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # Establecer el color del sector.
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan

    # Establecer el borde del sector.
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # Establecer el borde del sector.
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # Establecer el borde del sector.
    point2.format.line.fill_format.fill_type = slides.FillType.SOLID
    point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
    point2.format.line.width = 2.0
    point2.format.line.style = slides.LineStyle.THIN_THIN
    point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    # Crear etiquetas personalizadas para cada categoría en la nueva serie.
    label1 = series.data_points[0].label

    label1.data_label_format.show_value = True

    label2 = series.data_points[1].label
    label2.data_label_format.show_value = True
    label2.data_label_format.show_legend_key = True
    label2.data_label_format.show_percentage = True

    label3 = series.data_points[2].label
    label3.data_label_format.show_series_name = True
    label3.data_label_format.show_percentage = True

    # Establecer la serie para mostrar líneas guía en el gráfico.
    series.labels.default_data_label_format.show_leader_lines = True

    # Establecer el ángulo de rotación para los sectores del gráfico circular.
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # Guardar la presentación en disco como archivo PPTX.
    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![The pie chart](pie_chart.png)

### **Crear gráficos de líneas**

Los gráficos de líneas (también conocidos como diagramas de línea) son más adecuados cuando desea demostrar cambios de valor a lo largo del tiempo. Con un gráfico de líneas, puede comparar una gran cantidad de datos a la vez, seguir cambios y tendencias en el tiempo, resaltar anomalías en series de datos, y más.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Obtenga una referencia a una diapositiva mediante su índice.
1. Añada un gráfico con datos predeterminados y especifique el tipo `ChartType.LINE`.
1. Guarde la presentación modificada como un archivo PPTX.

Este código Python muestra cómo crear un gráfico de líneas:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 20, 20, 500, 300)
    
    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```

Por defecto, los puntos en un gráfico de líneas están unidos por líneas rectas continuas. Si desea que los puntos se unan mediante guiones, puede especificar el tipo de guión deseado de la siguiente forma:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

    for series in line_chart.chart_data.series:
        series.format.line.dash_style = slides.LineDashStyle.DASH

    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![The line chart](line_chart.png)

### **Crear gráficos de mapa de árbol**

Los gráficos de mapa de árbol son más adecuados para datos de ventas cuando desea mostrar el tamaño relativo de las categorías de datos y llamar rápidamente la atención sobre los elementos que son grandes contribuyentes dentro de cada categoría.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Obtenga una referencia a una diapositiva mediante su índice.
1. Añada un gráfico con datos predeterminados y especifique el tipo `ChartType.TREEMAP`.
1. Acceda al libro de datos del gráfico ([ChartDataWorkbook](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Elimine las series y categorías predeterminadas.
1. Añada series y categorías nuevas.
1. Añada nuevos datos de gráfico para las series.
1. Guarde la presentación modificada como un archivo PPTX.

Este código Python muestra cómo crear un gráfico de mapa de árbol:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.TREEMAP, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Rama 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # Rama 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D8", 3))

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    presentation.save("TreeMap.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![The treemap chart](treemap_chart.png)

### **Crear gráficos de cotización**

Los gráficos de cotización se utilizan para mostrar datos financieros como precios de apertura, máximo, mínimo y cierre, ayudando a analizar tendencias del mercado y volatilidad. Ofrecen información esencial sobre el rendimiento de acciones, asistiendo a inversores y analistas en la toma de decisiones informadas.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Obtenga una referencia a una diapositiva mediante su índice.
1. Añada un gráfico con datos predeterminados y especifique el tipo `ChartType.OPEN_HIGH_LOW_CLOSE`.
1. Acceda al libro de datos del gráfico ([ChartDataWorkbook](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Elimine las series y categorías predeterminadas.
1. Añada series y categorías nuevas.
1. Añada nuevos datos de gráfico para las series.
1. Especifique el formato de las líneas alto‑bajo.
1. Guarde la presentación modificada como un archivo PPTX.

Este código Python muestra cómo crear un gráfico de cotización:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 20, 20, 500, 300, False)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "A"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "B"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C"))

    chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Open"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "High"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 3, "Low"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 4, "Close"), chart.type)

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 1, 72))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 1, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 1, 38))

    series = chart.chart_data.series[1]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 2, 172))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 2, 57))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 2, 57))

    series = chart.chart_data.series[2]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 3, 13))

    series = chart.chart_data.series[3]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 4, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 4, 38))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 4, 50))

    chart.chart_data.series_groups[0].up_down_bars.has_up_down_bars = True
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for ser in chart.chart_data.series:
        ser.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("StockChart.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![The stock chart](stock_chart.png)

### **Crear gráficos de caja y bigotes**

Los gráficos de caja y bigotes se utilizan para mostrar la distribución de los datos resumendo medidas estadísticas clave, como la mediana, cuartiles y posibles valores atípicos. Son particularmente útiles en análisis exploratorios de datos y estudios estadísticos para comprender rápidamente la variabilidad y detectar anomalías.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Obtenga una referencia a una diapositiva mediante su índice.
1. Añada un gráfico con datos predeterminados y especifique el tipo `ChartType.BOX_AND_WHISKER`.
1. Acceda al libro de datos del gráfico ([ChartDataWorkbook](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Elimine las series y categorías predeterminadas.
1. Añada series y categorías nuevas.
1. Añada nuevos datos de gráfico para las series.
1. Guarde la presentación modificada como un archivo PPTX.

Este código Python muestra cómo crear un gráfico de caja y bigotes:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 1"))

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B1", 15))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B2", 41))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B3", 16))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B4", 10))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B5", 23))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B6", 16))

    presentation.save("BoxAndWhiskerChart.pptx", slides.export.SaveFormat.PPTX)
```

### **Crear gráficos de embudo**

Los gráficos de embudo se utilizan para visualizar procesos que implican etapas secuenciales, donde el volumen de datos disminuye a medida que avanza de un paso al siguiente. Son especialmente útiles para analizar tasas de conversión, identificar cuellos de botella y seguir la eficiencia de procesos de ventas o marketing.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Obtenga una referencia a una diapositiva mediante su índice.
1. Añada un gráfico con datos predeterminados y especifique el tipo `ChartType.FUNNEL`.
1. Guarde la presentación modificada como un archivo PPTX.

Este código Python muestra cómo crear un gráfico de embudo:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 4"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 5"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 6"))

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B1", 50))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B2", 100))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B3", 200))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B4", 300))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B5", 400))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B6", 500))

    presentation.save("FunnelChart.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![The funnel chart](funnel_chart.png)

### **Crear gráficos de rayos**

Los gráficos de rayos se utilizan para visualizar datos jerárquicos, mostrando los niveles como anillos concéntricos. Ayudan a ilustrar relaciones parte‑todo y son ideales para representar categorías y subcategorías anidadas de forma clara y compacta.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Obtenga una referencia a una diapositiva mediante su índice.
1. Añada un gráfico con datos predeterminados y especifique el tipo `ChartType.SUNBURST`.
1. Guarde la presentación modificada como un archivo PPTX.

Este código Python muestra cómo crear un gráfico de rayos:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Rama 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # Rama 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D8", 3))

    presentation.save("SunburstChart.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![The sunburst chart](sunburst_chart.png)

### **Crear histogramas**

Los histogramas se utilizan para representar la distribución de datos numéricos agrupando valores en intervalos o cubetas. Son particularmente útiles para identificar patrones de frecuencia, sesgo y dispersión, y para detectar valores atípicos en un conjunto de datos.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Obtenga una referencia a una diapositiva mediante su índice.
1. Añada un gráfico con algunos datos y especifique el tipo `ChartType.HISTOGRAM`.
1. Acceda al libro de datos del gráfico ([ChartDataWorkbook](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Elimine las series y categorías predeterminadas.
1. Añada una nueva serie y pobléla con puntos de datos. Un histograma no tiene categorías; las cubetas se calculan a partir de los valores.
1. Guarde la presentación modificada como un archivo PPTX.

Este código Python muestra cómo crear un histograma:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A1", 15))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A2", -41))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A3", 16))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A4", 10))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A5", -23))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A6", 16))

    chart.axes.horizontal_axis.aggregation_type = charts.AxisAggregationType.AUTOMATIC

    presentation.save("HistogramChart.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![The histogram chart](histogram_chart.png)

### **Crear gráficos de radar**

Los gráficos de radar se utilizan para mostrar datos multivariantes en un formato bidimensional, permitiendo comparar fácilmente varias variables simultáneamente. Son particularmente útiles para identificar patrones, fortalezas y debilidades en múltiples métricas o atributos de rendimiento.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Obtenga una referencia a una diapositiva mediante su índice.
1. Añada un gráfico con algunos datos y especifique el tipo `ChartType.RADAR`.
1. Guarde la presentación modificada como un archivo PPTX.

Este código Python muestra cómo crear un gráfico de radar:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 500, 300)
    presentation.save("RadarChart.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![The radar chart](radar_chart.png)

### **Crear gráficos multicatálogo**

Los gráficos multicatálogo se utilizan para mostrar datos que involucran más de un agrupamiento categórico, permitiendo comparar valores a través de múltiples dimensiones simultáneamente. Son particularmente útiles cuando necesita analizar tendencias y relaciones dentro de conjuntos de datos complejos y multilayer.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Obtenga una referencia a una diapositiva mediante su índice.
1. Añada un gráfico con datos predeterminados y especifique el tipo `ChartType.CLUSTERED_COLUMN`.
1. Acceda al libro de datos del gráfico ([ChartDataWorkbook](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Elimine las series y categorías predeterminadas.
1. Añada series y categorías nuevas.
1. Añada nuevos datos de gráfico para las series.
1. Guarde la presentación modificada como un archivo PPTX.

Este código Python muestra cómo crear un gráfico multicatálogo:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    worksheet_index = 0

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c2", "A"))
    category.grouping_levels.set_grouping_item(1, "Group1")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c3", "B"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c4", "C"))
    category.grouping_levels.set_grouping_item(1, "Group2")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c5", "D"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c6", "E"))
    category.grouping_levels.set_grouping_item(1, "Group3")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c7", "F"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c8", "G"))
    category.grouping_levels.set_grouping_item(1, "Group4")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c9", "H"))

    # Añadir una serie.
    series = chart.chart_data.series.add(workbook.get_cell(0, "D1", "Series 1"), charts.ChartType.CLUSTERED_COLUMN)

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D2", 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D3", 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D4", 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D5", 40))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D6", 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D7", 60))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D8", 70))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D9", 80))

    # Guardar la presentación con el gráfico.
    presentation.save("MultiCategoryChart.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![The multi-category chart](multi_category_chart.png)

### **Crear gráficos de mapa**

Los gráficos de mapa se utilizan para visualizar datos geográficos asignando información a ubicaciones específicas como países, estados o ciudades. Son especialmente útiles para analizar tendencias regionales, datos demográficos y distribuciones espaciales de manera clara y visualmente atractiva.

Este código Python muestra cómo crear un gráfico de mapa:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 20, 20, 500, 300)
    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![The map chart](map_chart.png)

### **Crear gráficos combinados**

Un gráfico combinado (o gráfico combo) combina dos o más tipos de gráficos en un solo diagrama. Este gráfico le permite resaltar, comparar o examinar diferencias entre dos o más conjuntos de datos, ayudándole a identificar relaciones entre ellos.

![The combination chart](combination_chart.png)

El siguiente código Python muestra cómo crear el gráfico combinado mostrado arriba en una presentación de PowerPoint:

```python
import aspose.slides.charts as charts
import aspose.pydrawing as draw
import aspose.slides as slides

def create_combo_chart():
    with slides.Presentation() as presentation:
        chart = create_chart_with_first_series(presentation.slides[0])

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", slides.export.SaveFormat.PPTX)


def create_chart_with_first_series(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    # Establecer el título del gráfico.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Chart Title")
    chart.chart_title.overlay = False
    title_paragraph = chart.chart_title.text_frame_for_overriding.paragraphs[0]
    title_format = title_paragraph.paragraph_format.default_portion_format

    title_format.font_bold = slides.NullableBool.FALSE
    title_format.font_height = 18

    # Establecer la leyenda del gráfico.
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.portion_format.font_height = 12

    # Eliminar las series y categorías generadas por defecto.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    worksheet_index = 0
    workbook = chart.chart_data.chart_data_workbook

    # Añadir categorías nuevas.
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 4, 0, "Category 4"))

    # Añadir la primera serie.
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 4.3))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 2.5))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 3.5))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 4.5))

    return chart


def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 2.4))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 4.4))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 1.8))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 2.8))


def add_third_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.LINE)

    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 1, 3, 2.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 2, 3, 2.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 3, 3, 3.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 4, 3, 5.0))

    series.plot_on_second_axis = True


def set_primary_axes_format(chart):
    # Establecer el eje horizontal.
    horizontal_axis = chart.axes.horizontal_axis
    horizontal_axis.text_format.portion_format.font_height = 12.0
    horizontal_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(horizontal_axis, "X Axis")

    # Establecer el eje vertical.
    vertical_axis = chart.axes.vertical_axis
    vertical_axis.text_format.portion_format.font_height = 12.0
    vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(vertical_axis, "Y Axis 1")

    # Establecer el color de las líneas de cuadrícula mayor verticales.
    major_grid_lines_format = vertical_axis.major_grid_lines_format.line.fill_format
    major_grid_lines_format.fill_type = slides.FillType.SOLID
    major_grid_lines_format.solid_fill_color.color = draw.Color.from_argb(217, 217, 217)


def set_secondary_axes_format(chart):
    # Establecer el eje horizontal secundario.
    secondary_horizontal_axis = chart.axes.secondary_horizontal_axis
    secondary_horizontal_axis.position = charts.AxisPositionType.BOTTOM
    secondary_horizontal_axis.cross_type = charts.CrossesType.MAXIMUM
    secondary_horizontal_axis.is_visible = False
    secondary_horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    # Establecer el eje vertical secundario.
    secondary_vertical_axis = chart.axes.secondary_vertical_axis
    secondary_vertical_axis.position = charts.AxisPositionType.RIGHT
    secondary_vertical_axis.text_format.portion_format.font_height = 12.0
    secondary_vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(secondary_vertical_axis, "Y Axis 2")


def set_axis_title(axis, axis_title):
    axis.has_title = True
    axis.title.overlay = False
    title_portion_format = axis.title.add_text_frame_for_overriding(axis_title).paragraphs[0].paragraph_format.default_portion_format
    title_portion_format.font_bold = slides.NullableBool.FALSE
    title_portion_format.font_height = 12.0
```

## **Actualizar gráficos**

Aspose.Slides para Python a través de .NET le permite actualizar datos, formato y estilo de los gráficos para mantener sus presentaciones de PowerPoint al día.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) para abrir la presentación que contiene el gráfico.
1. Obtenga una referencia a una diapositiva mediante su índice.
1. Recorra todas las formas para encontrar el gráfico.
1. Acceda a la hoja de datos del gráfico.
1. Modifique las series de datos del gráfico cambiando los valores de las series.
1. Añada una nueva serie y rellene sus datos.
1. Guarde la presentación modificada como un archivo PPTX.

Este código Python muestra cómo actualizar un gráfico:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# Instanciar la clase Presentation que representa un archivo PPTX.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # Acceder a la primera diapositiva.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape

            # Establecer el índice de la hoja de datos del gráfico.
            worksheet_index = 0

            # Obtener el libro de datos del gráfico.
            workbook = chart.chart_data.chart_data_workbook

            # Cambiar los nombres de las categorías del gráfico.
            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            # Obtener la primera serie del gráfico.
            series = chart.chart_data.series[0]

            # Actualizar los datos de la serie.
            workbook.get_cell(worksheet_index, 0, 1, "New_Series1")  # Modificando el nombre de la serie.
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            # Obtener la segunda serie del gráfico.
            series = chart.chart_data.series[1]

            # Actualizar los datos de la serie.
            workbook.get_cell(worksheet_index, 0, 2, "New_Series2")  # Modificando el nombre de la serie.
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            # Añadir una serie nueva.
            series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), chart.type)

            # Rellenar los datos de la serie.
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 3, 20))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 3, 50))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 3, 30))

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

            # Guardar la presentación con el gráfico.
            presentation.save("ModifiedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir rango de datos para un gráfico**

Aspose.Slides para Python a través de .NET le permite usar un rango de hoja de cálculo específico como origen de datos para un gráfico. Esto controla qué celdas suministran las series y categorías del gráfico y le permite actualizar el gráfico para reflejar los cambios en la hoja.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) para abrir la presentación que contiene el gráfico.
1. Obtenga una referencia a una diapositiva mediante su índice.
1. Recorra todas las formas para encontrar el gráfico.
1. Acceda a los datos del gráfico y establezca el rango.
1. Guarde la presentación modificada como un archivo PPTX.

Este código Python muestra cómo definir el rango de datos para un gráfico:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# Instanciar la clase Presentation que representa un archivo PPTX.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # Acceder a la primera diapositiva.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            chart.chart_data.set_range("Sheet1!A1:B4")

    presentation.save("DataRange.pptx", slides.export.SaveFormat.PPTX)
```

## **Usar marcadores predeterminados en gráficos**

Cuando utiliza marcadores predeterminados en los gráficos, cada serie del gráfico recibe automáticamente un símbolo de marcador diferente.

Este código Python muestra cómo establecer automáticamente un marcador para una serie de gráfico:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "C1"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 1, 24))

    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "C2"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 1, 23))

    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C3"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 1, -10))

    chart.chart_data.categories.add(workbook.get_cell(0, 4, 0, "C4"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 1, None))

    series2 = chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "Series 2"), chart.type)

    # Rellenar los datos de la serie.
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 2, 30))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 2, 10))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 2, 60))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 2, 40))

    chart.has_legend = True
    chart.legend.overlay = False

    presentation.save("DefaultMarkersInChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Qué tipos de gráficos son compatibles con Aspose.Slides para Python a través de .NET?**

Aspose.Slides para Python a través de .NET admite una amplia variedad de tipos de gráficos, incluidos barra, línea, circular, área, dispersión, histograma, radar y muchos más. Esta flexibilidad le permite elegir el tipo de gráfico más adecuado para sus necesidades de visualización de datos.

**¿Cómo añado un nuevo gráfico a una diapositiva?**

Para añadir un gráfico, primero cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/), recupere la diapositiva deseada mediante su índice y luego invoque el método para añadir un gráfico, especificando el tipo de gráfico y los datos iniciales. Este proceso integra el gráfico directamente en su presentación.

**¿Cómo puedo actualizar los datos mostrados en un gráfico?**

Puede actualizar los datos de un gráfico accediendo a su libro de datos ([ChartDataWorkbook](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdataworkbook/)), eliminando cualquier serie y categoría predeterminada, y luego añadiendo sus datos personalizados. Esto le permite refrescar programáticamente el gráfico para reflejar los últimos datos.

**¿Es posible personalizar la apariencia del gráfico?**

Sí, Aspose.Slides para Python a través de .NET ofrece amplias opciones de personalización. Puede modificar colores, fuentes, etiquetas, leyendas y otros elementos de formato para adaptar la apariencia del gráfico a sus requisitos de diseño específicos.