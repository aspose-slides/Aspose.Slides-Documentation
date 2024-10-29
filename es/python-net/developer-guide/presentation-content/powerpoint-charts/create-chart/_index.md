---
title: Crear Gráficos de Presentación de PowerPoint en Python
linktitle: Crear Gráfico
type: docs
weight: 10
url: /es/python-net/create-chart/
keywords: "Crear gráfico, gráfico disperso, gráfico circular, gráfico de mapa de árbol, gráfico de acciones, gráfico de caja y bigote, gráfico de histograma, gráfico de embudo, gráfico de sol, gráfico multicategórico, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Crear gráfico en presentación de PowerPoint en Python"
---

## **Crear Gráfico**

Los gráficos ayudan a las personas a visualizar datos de manera rápida y obtener percepciones que pueden no ser inmediatamente obvias de una tabla o hoja de cálculo.

**¿Por qué crear gráficos?**

Usando gráficos, puedes

* agregar, condensar o resumir grandes cantidades de datos en una sola diapositiva de una presentación
* exponer patrones y tendencias en los datos
* deducir la dirección y el impulso de los datos a lo largo del tiempo o con respecto a una unidad de medida específica
* detectar valores atípicos, aberraciones, desviaciones, errores, datos sin sentido, etc.
* comunicar o presentar datos complejos

En PowerPoint, puedes crear gráficos a través de la función de inserción, que proporciona plantillas utilizadas para diseñar muchos tipos de gráficos. Usando Aspose.Slides, puedes crear gráficos regulares (basados en tipos de gráficos populares) y gráficos personalizados.

{{% alert color="primary" %}} 

Para permitirte crear gráficos, Aspose.Slides proporciona la enumeración [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) en el espacio de nombres [Aspose.Slides.Charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/). Los miembros de esta enumeración corresponden a diferentes tipos de gráficos.

{{% /alert %}} 

### **Creando Gráficos Normales**
1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtener la referencia de una diapositiva a través de su índice.
1. Agregar un gráfico con algunos datos y especificar tu tipo de gráfico preferido.
1. Agregar un título para el gráfico.
1. Acceder a la hoja de datos del gráfico.
1. Limpiar todas las series y categorías predeterminadas.
1. Agregar nuevas series y categorías.
1. Agregar algunos nuevos datos del gráfico para las series del gráfico.
1. Agregar un color de relleno para las series del gráfico.
1. Agregar etiquetas para las series del gráfico.
1. Escribir la presentación modificada como un archivo PPTX.

Este código Python te muestra cómo crear un gráfico normal:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar clase Presentation que representa el archivo PPTX
with slides.Presentation() as pres:

    # Acceder a la primera diapositiva
    sld = pres.slides[0]

    # Agregar gráfico con datos predeterminados
    chart = sld.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 0, 0, 500, 500)

    # Establecer título del gráfico
    chart.chart_title.add_text_frame_for_overriding("Título de Ejemplo")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
    chart.chart_title.height = 20
    chart.has_title = True

    # Establecer la primera serie para mostrar valores
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # Establecer el índice de la hoja de datos del gráfico
    defaultWorksheetIndex = 0

    # Obtener la hoja de datos del gráfico
    fact = chart.chart_data.chart_data_workbook

    # Eliminar series y categorías generadas predeterminadamente
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    s = len(chart.chart_data.series)
    s = len(chart.chart_data.categories)

    # Agregar nuevas series
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Serie 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Serie 2"), chart.type)

    # Agregar nuevas categorías
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Categoría 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Categoría 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Categoría 3"))

    # Tomar la primera serie del gráfico
    series = chart.chart_data.series[0]

    # Población de datos de la serie ahora

    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

    # Establecer color de relleno para la serie
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red


    # Tomar la segunda serie del gráfico
    series = chart.chart_data.series[1]

    # Población de datos de la serie ahora
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Establecer color de relleno para la serie
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    # La primera etiqueta mostrará el nombre de la categoría
    lbl = series.data_points[0].label
    lbl.data_label_format.show_category_name = True

    lbl = series.data_points[1].label
    lbl.data_label_format.show_series_name = True

    # Mostrar valor para la tercera etiqueta
    lbl = series.data_points[2].label
    lbl.data_label_format.show_value = True
    lbl.data_label_format.show_series_name = True
    lbl.data_label_format.separator = "/"
                
    # Guardar presentación con gráfico
    pres.save("AsposeChart_out-1.pptx", slides.export.SaveFormat.PPTX)
```


### **Creando Gráficos Dispersos**
Los gráficos dispersos (también conocidos como gráficos de dispersión o gráficos x-y) se utilizan a menudo para buscar patrones o demostrar correlaciones entre dos variables.

Tal vez quieras usar un gráfico disperso cuando

* tengas datos numéricos emparejados
* tengas 2 variables que se relacionan bien entre sí
* quieras determinar si 2 variables están relacionadas
* tengas una variable independiente que tiene múltiples valores para una variable dependiente

Este código Python te muestra cómo crear gráficos dispersos con una serie diferente de marcadores:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    slide = pres.slides[0]

    # Crear el gráfico predeterminado
    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 0, 0, 400, 400)

    # Obtener el índice de la hoja de datos del gráfico predeterminado
    defaultWorksheetIndex = 0

    # Obtener la hoja de datos del gráfico
    fact = chart.chart_data.chart_data_workbook

    # Eliminar serie de demostración
    chart.chart_data.series.clear()

    # Agregar nuevas series
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Serie 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 3, "Serie 2"), chart.type)

    # Tomar la primera serie del gráfico
    series = chart.chart_data.series[0]

    # Agregar nuevo punto (1:3) allí.
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 1), fact.get_cell(defaultWorksheetIndex, 2, 2, 3))

    # Agregar nuevo punto (2:10)
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 2), fact.get_cell(defaultWorksheetIndex, 3, 2, 10))

    # Editar el tipo de serie
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # Cambiar el marcador de la serie del gráfico
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # Tomar la segunda serie del gráfico
    series = chart.chart_data.series[1]

    # Agregar nuevo punto (5:2) allí.
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 2, 3, 5), fact.get_cell(defaultWorksheetIndex, 2, 4, 2))

    # Agregar nuevo punto (3:1)
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 3, 3, 3), fact.get_cell(defaultWorksheetIndex, 3, 4, 1))

    # Agregar nuevo punto (2:2)
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 4, 3, 2), fact.get_cell(defaultWorksheetIndex, 4, 4, 2))

    # Agregar nuevo punto (5:1)
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 5, 3, 5), fact.get_cell(defaultWorksheetIndex, 5, 4, 1))

    # Cambiar el marcador de la serie del gráfico
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    pres.save("AsposeChart_out-2.pptx", slides.export.SaveFormat.PPTX)
```

### **Creando Gráficos Circulares**

Los gráficos circulares se utilizan mejor para mostrar la relación parte-todo en los datos, especialmente cuando los datos contienen etiquetas categóricas con valores numéricos. Sin embargo, si tus datos contienen muchas partes o etiquetas, es posible que desees considerar usar un gráfico de barras en su lugar.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtener la referencia de una diapositiva a través de su índice.
1. Agregar un gráfico con datos predeterminados junto con el tipo deseado (en este caso, `ChartType.PIE`).
1. Acceder a la IChartDataWorkbook del gráfico.
1. Limpiar las series y categorías predeterminadas.
1. Agregar nuevas series y categorías.
1. Agregar nuevos datos del gráfico para las series del gráfico.
1. Agregar nuevos puntos para los gráficos y agregar colores personalizados para los sectores del gráfico circular.
1. Establecer etiquetas para las series.
1. Establecer líneas de liderazgo para las etiquetas de las series.
1. Establecer el ángulo de rotación para las diapositivas del gráfico circular.
1. Escribir la presentación modificada en un archivo PPTX.

Este código Python te muestra cómo crear un gráfico circular:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar clase Presentation que representa el archivo PPTX
with slides.Presentation() as presentation:

    # Acceder a la primera diapositiva
    slide = presentation.slides[0]

    # Agregar gráfico con datos predeterminados
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # Establecer título del gráfico
    chart.chart_title.add_text_frame_for_overriding("Título de Ejemplo")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
    chart.chart_title.height = 20
    chart.has_title = True

    # Establecer la primera serie para mostrar valores
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # Establecer el índice de la hoja de datos del gráfico
    defaultWorksheetIndex = 0

    # Obtener la hoja de datos del gráfico
    fact = chart.chart_data.chart_data_workbook

    # Eliminar series y categorías generadas predeterminadamente
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Agregar nuevas categorías
    chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "Primer Trimestre"))
    chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "Segundo Trimestre"))
    chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "Tercer Trimestre"))

    # Agregar nueva serie
    series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Serie 1"), chart.type)

    # Ahora poblamos los datos de la serie
    series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

    # No funciona en la nueva versión
    # Agregar nuevos puntos y establecer color del sector
    # series.IsColorVaried = True
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan
    # Establecer borde del sector
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # Establecer borde del sector
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # Establecer borde del sector
    point2.format.line.fill_format.fill_type = slides.FillType.SOLID
    point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
    point2.format.line.width = 2.0
    point2.format.line.style = slides.LineStyle.THIN_THIN
    point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    # Crear etiquetas personalizadas para cada una de las categorías para la nueva serie
    lbl1 = series.data_points[0].label

    # lbl.show_category_name = True
    lbl1.data_label_format.show_value = True

    lbl2 = series.data_points[1].label
    lbl2.data_label_format.show_value = True
    lbl2.data_label_format.show_legend_key = True
    lbl2.data_label_format.show_percentage = True

    lbl3 = series.data_points[2].label
    lbl3.data_label_format.show_series_name = True
    lbl3.data_label_format.show_percentage = True

    # Mostrar líneas de liderazgo para el gráfico
    series.labels.default_data_label_format.show_leader_lines = True

    # Establecer ángulo de rotación para los sectores del gráfico circular
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # Guardar presentación con gráfico
    presentation.save("PieChart_out-3.pptx", slides.export.SaveFormat.PPTX)
```

### **Creando Gráficos de Líneas**

Los gráficos de líneas (también conocidos como gráficos de línea) son mejores para situaciones en las que deseas demostrar cambios en los valores a lo largo del tiempo. Utilizando un gráfico de líneas, puedes comparar muchos datos a la vez, rastrear cambios y tendencias a lo largo del tiempo, resaltar anomalías en series de datos, etc.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtener la referencia de una diapositiva a través de su índice.
1. Agregar un gráfico con datos predeterminados junto con el tipo deseado (en este caso, `ChartType.Line`).
1. Acceder a la IChartDataWorkbook del gráfico.
1. Limpiar las series y categorías predeterminadas.
1. Agregar nuevas series y categorías.
1. Agregar nuevos datos del gráfico para las series del gráfico.
1. Escribir la presentación modificada en un archivo PPTX.

Este código Python te muestra cómo crear un gráfico de líneas:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    lineChart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)
    
    pres.save("lineChart.pptx", slides.export.SaveFormat.PPTX)
```

Por defecto, los puntos en un gráfico de líneas se unen con líneas continuas rectas. Si deseas que los puntos se unan con guiones en su lugar, puedes especificar tu tipo de guión preferido de esta manera:

```python
lineChart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

for series in lineChart.chart_data.series:
    series.format.line.dash_style = slides.charts.LineDashStyle.DASH
```

### **Creando Gráficos de Mapa de Árbol**

Los gráficos de mapa de árbol son mejores para datos de ventas cuando deseas mostrar el tamaño relativo de categorías de datos y, al mismo tiempo, llamar rápidamente la atención sobre los elementos que son grandes contribuyentes a cada categoría.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Obtener la referencia de una diapositiva a través de su índice.
1. Agregar un gráfico con datos predeterminados junto al tipo deseado (en este caso, `ChartType.TREEMAP`).
1. Acceder a la IChartDataWorkbook del gráfico.
1. Limpiar las series y categorías predeterminadas.
1. Agregar nuevas series y categorías.
1. Agregar nuevos datos del gráfico para las series del gráfico.
1. Escribir la presentación modificada en un archivo PPTX.

Este código Python te muestra cómo crear un gráfico de mapa de árbol:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.TREEMAP, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    #rama 1
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C1", "Hoja1"))
    leaf.grouping_levels.set_grouping_item(1, "Tallo1")
    leaf.grouping_levels.set_grouping_item(2, "Rama1")

    chart.chart_data.categories.add(wb.get_cell(0, "C2", "Hoja2"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C3", "Hoja3"))
    leaf.grouping_levels.set_grouping_item(1, "Tallo2")

    chart.chart_data.categories.add(wb.get_cell(0, "C4", "Hoja4"))


    #rama 2
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C5", "Hoja5"))
    leaf.grouping_levels.set_grouping_item(1, "Tallo3")
    leaf.grouping_levels.set_grouping_item(2, "Rama2")

    chart.chart_data.categories.add(wb.get_cell(0, "C6", "Hoja6"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C7", "Hoja7"))
    leaf.grouping_levels.set_grouping_item(1, "Tallo4")

    chart.chart_data.categories.add(wb.get_cell(0, "C8", "Hoja8"))

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D8", 3))

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    pres.save("Treemap-4.pptx", slides.export.SaveFormat.PPTX)
```


### **Creando Gráficos de Acciones**
1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Obtener la referencia de una diapositiva a través de su índice.
1. Agregar un gráfico con datos predeterminados junto al tipo deseado (ChartType.OPEN_HIGH_LOW_CLOSE).
1. Acceder a la IChartDataWorkbook del gráfico.
1. Limpiar las series y categorías predeterminadas.
1. Agregar nuevas series y categorías.
1. Agregar nuevos datos del gráfico para las series del gráfico.
1. Especificar el formato de HiLowLines.
1. Escribir la presentación modificada en un archivo PPTX.

Código de muestra en Python utilizado para crear un gráfico de acciones:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 50, 50, 600, 400, False)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    wb = chart.chart_data.chart_data_workbook

    chart.chart_data.categories.add(wb.get_cell(0, 1, 0, "A"))
    chart.chart_data.categories.add(wb.get_cell(0, 2, 0, "B"))
    chart.chart_data.categories.add(wb.get_cell(0, 3, 0, "C"))

    chart.chart_data.series.add(wb.get_cell(0, 0, 1, "Abrir"), chart.type)
    chart.chart_data.series.add(wb.get_cell(0, 0, 2, "Alto"), chart.type)
    chart.chart_data.series.add(wb.get_cell(0, 0, 3, "Bajo"), chart.type)
    chart.chart_data.series.add(wb.get_cell(0, 0, 4, "Cerrar"), chart.type)

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 1, 72))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 1, 25))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 1, 38))

    series = chart.chart_data.series[1]
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 2, 172))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 2, 57))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 2, 57))

    series = chart.chart_data.series[2]
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 3, 12))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 3, 12))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 3, 13))

    series = chart.chart_data.series[3]
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 4, 25))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 4, 38))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 4, 50))

    chart.chart_data.series_groups[0].up_down_bars.has_up_down_bars = True
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for ser in chart.chart_data.series:
        ser.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    pres.save("output-5.pptx", slides.export.SaveFormat.PPTX)
```


### **Creando Gráficos de Caja y Bigote**
1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Obtener la referencia de una diapositiva a través de su índice.
1. Agregar un gráfico con datos predeterminados junto al tipo deseado (ChartType.BOX_AND_WHISKER).
1. Acceder a la IChartDataWorkbook del gráfico.
1. Limpiar las series y categorías predeterminadas.
1. Agregar nuevas series y categorías.
1. Agregar nuevos datos del gráfico para las series del gráfico.
1. Escribir la presentación modificada en un archivo PPTX.

Este código Python te muestra cómo crear un gráfico de caja y bigote:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.add(wb.get_cell(0, "A1", "Categoría 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A2", "Categoría 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", "Categoría 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", "Categoría 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", "Categoría 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A6", "Categoría 1"))

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B1", 15))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B2", 41))
    series.data_points.add_data_point_for_box_andwhisker_series(wb.get_cell(0, "B3", 16))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B4", 10))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B5", 23))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B6", 16))


    pres.save("BoxAndWhisker-6.pptx", slides.export.SaveFormat.PPTX)
```


### **Creando Gráficos de Embudo**
1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Obtener la referencia de una diapositiva a través de su índice.
1. Agregar un gráfico con datos predeterminados junto al tipo deseado (ChartType.Funnel).
1. Escribir la presentación modificada en un archivo PPTX.

Este código Python te muestra cómo crear un gráfico de embudo:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.add(wb.get_cell(0, "A1", "Categoría 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A2", "Categoría 2"))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", "Categoría 3"))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", "Categoría 4"))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", "Categoría 5"))
    chart.chart_data.categories.add(wb.get_cell(0, "A6", "Categoría 6"))

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B1", 50))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B2", 100))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B3", 200))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B4", 300))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B5", 400))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B6", 500))

    pres.save("Funnel-7.pptx", slides.export.SaveFormat.PPTX)
```

### **Creando Gráficos de Sol**
1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Obtener la referencia de una diapositiva a través de su índice.
1. Agregar un gráfico con datos predeterminados junto al tipo deseado (en este caso, `ChartType.SUNBURST`).
1. Escribir la presentación modificada en un archivo PPTX.

Este código Python te muestra cómo crear un gráfico de sol:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    #rama 1
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C1", "Hoja1"))
    leaf.grouping_levels.set_grouping_item(1, "Tallo1")
    leaf.grouping_levels.set_grouping_item(2, "Rama1")

    chart.chart_data.categories.add(wb.get_cell(0, "C2", "Hoja2"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C3", "Hoja3"))
    leaf.grouping_levels.set_grouping_item(1, "Tallo2")

    chart.chart_data.categories.add(wb.get_cell(0, "C4", "Hoja4"))

    #rama 2
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C5", "Hoja5"))
    leaf.grouping_levels.set_grouping_item(1, "Tallo3")
    leaf.grouping_levels.set_grouping_item(2, "Rama2")

    chart.chart_data.categories.add(wb.get_cell(0, "C6", "Hoja6"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C7", "Hoja7"))
    leaf.grouping_levels.set_grouping_item(1, "Tallo4")

    chart.chart_data.categories.add(wb.get_cell(0, "C8", "Hoja8"))

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D8", 3))

    pres.save("Sunburst-8.pptx", slides.export.SaveFormat.PPTX)
```


### **Creando Gráficos de Histograma**
1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Obtener la referencia de una diapositiva a través de su índice. 
1. Agregar algunos gráficos con algunos datos y especificar tu tipo de gráfico preferido (`ChartType.HISTOGRAM` en este caso).
1. Acceder a la IChartDataWorkbook del gráfico.
1. Limpiar las series y categorías predeterminadas.
1. Agregar nuevas series y categorías.
1. Escribir la presentación modificada en un archivo PPTX.

Este código Python te muestra cómo crear un gráfico de histograma:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.HISTOGRAM, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A1", 15))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A2", -41))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A3", 16))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A4", 10))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A5", -23))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A6", 16))

    chart.axes.horizontal_axis.aggregation_type = charts.AxisAggregationType.AUTOMATIC

    pres.save("Histogram-9.pptx", slides.export.SaveFormat.PPTX)
```

### **Creando Gráficos de Radar**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Obtener la referencia de una diapositiva a través de su índice. 
1. Agregar un gráfico con algunos datos y especificar tu tipo de gráfico preferido (`ChartType.RADAR` en este caso).
1. Escribir la presentación modificada en un archivo PPTX.

Este código Python te muestra cómo crear un gráfico de radar:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 400, 300)
    pres.save("Radar-chart.pptx", slides.export.SaveFormat.PPTX)
```

### **Creando Gráficos Multicategóricos**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Obtener la referencia de una diapositiva a través de su índice.
1. Agregar un gráfico con datos predeterminados junto al tipo deseado (ChartType.ClusteredColumn).
1. Acceder a la IChartDataWorkbook del gráfico.
1. Limpiar las series y categorías predeterminadas.
1. Agregar nuevas series y categorías.
1. Agregar nuevos datos del gráfico para las series del gráfico.
1. Escribir la presentación modificada en un archivo PPTX.

Este código Python te muestra cómo crear un gráfico multicategórico:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]

    ch = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 600, 450)
    ch.chart_data.series.clear()
    ch.chart_data.categories.clear()


    fact = ch.chart_data.chart_data_workbook
    fact.clear(0)
    defaultWorksheetIndex = 0

    category = ch.chart_data.categories.add(fact.get_cell(0, "c2", "A"))
    category.grouping_levels.set_grouping_item(1, "Grupo1")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c3", "B"))

    category = ch.chart_data.categories.add(fact.get_cell(0, "c4", "C"))
    category.grouping_levels.set_grouping_item(1, "Grupo2")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c5", "D"))

    category = ch.chart_data.categories.add(fact.get_cell(0, "c6", "E"))
    category.grouping_levels.set_grouping_item(1, "Grupo3")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c7", "F"))

    category = ch.chart_data.categories.add(fact.get_cell(0, "c8", "G"))
    category.grouping_levels.set_grouping_item(1, "Grupo4")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c9", "H"))

    # Agregar Series
    series = ch.chart_data.series.add(fact.get_cell(0, "D1", "Serie 1"), charts.ChartType.CLUSTERED_COLUMN)

    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D2", 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D3", 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D4", 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D5", 40))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D6", 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D7", 60))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D8", 70))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D9", 80))
    # Guardar presentación con gráfico
    pres.save("AsposeChart_out-10.pptx", slides.export.SaveFormat.PPTX)
```

### **Creando Gráficos de Mapa**

Un gráfico de mapa es una visualización de un área que contiene datos. Los gráficos de mapa son mejores para comparar datos o valores entre regiones geográficas.

Este código Python te muestra cómo crear un gráfico de mapa:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 50, 50, 500, 400, False)
    pres.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

### **Creando Gráficos de Combinación**

Un gráfico de combinación (o gráfico combinado) es un gráfico que combina dos o más gráficos en un solo gráfico. Dicho gráfico te permite resaltar, comparar o revisar las diferencias entre dos (o más) conjuntos de datos. De esta manera, ves la relación (si la hay) entre los conjuntos de datos. 

![combination-chart-ppt](combination-chart-ppt.png)

Este código Python te muestra cómo crear un gráfico de combinación en PowerPoint:

```python
import aspose.slides as slides
import aspose.slides.charts as charts


def create_combo_chart():
    pres = slides.Presentation()
    chart = create_chart(pres.slides[0])
    add_first_series_to_chart(chart)
    add_second_series_to_chart(chart)
    pres.save("combo-chart.pptx", slides.export.SaveFormat.PPTX)


def create_chart(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Serie 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Serie 2"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Categoría 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Categoría 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Categoría 3"))

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    series = chart.chart_data.series[1]

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    return chart


def add_first_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Serie 3"), charts.ChartType.SCATTER_WITH_SMOOTH_LINES)

    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 0, 1, 3), workbook.get_cell(worksheet_index, 0, 2, 5))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 3, 10), workbook.get_cell(worksheet_index, 1, 4, 13))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 20), workbook.get_cell(worksheet_index, 2, 4, 15))

    series.plot_on_second_axis = True

def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 5, "Serie 4"), charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS)

    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 3, 5), workbook.get_cell(worksheet_index, 1, 4, 2))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 5, 10), workbook.get_cell(worksheet_index, 1, 6, 7))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 5, 15), workbook.get_cell(worksheet_index, 2, 6, 12))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 5, 12), workbook.get_cell(worksheet_index, 3, 6, 9))

    series.plot_on_second_axis = True
```

## **Actualizando Gráficos**

1. Instanciar una clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) que represente la presentación que contiene el gráfico.
2. Obtener la referencia de una diapositiva a través de su índice.
3. Recorrer todas las formas para encontrar el gráfico deseado.
4. Acceder a la hoja de datos del gráfico.
5. Modificar los datos de la serie del gráfico cambiando los valores de la serie.
6. Agregar una nueva serie y poblar los datos en ella.
7. Escribir la presentación modificada como un archivo PPTX.

Este código Python te muestra cómo actualizar un gráfico:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar clase Presentation que representa el archivo PPTX
with slides.Presentation(path + "ExistingChart.pptx") as pres:

    # Acceder a la primera diapositiva
    sld = pres.slides[0]

    # Agregar gráfico con datos predeterminados
    chart = sld.shapes[0]

    # Estableciendo el índice de la hoja de datos del gráfico
    defaultWorksheetIndex = 0

    # Obtener la hoja de datos del gráfico
    fact = chart.chart_data.chart_data_workbook


    # Cambiando el nombre de la categoría del gráfico
    fact.get_cell(defaultWorksheetIndex, 1, 0, "Categoría Modificada 1")
    fact.get_cell(defaultWorksheetIndex, 2, 0, "Categoría Modificada 2")


    # Tomar la primera serie del gráfico
    series = chart.chart_data.series[0]

    # Actualizando los datos de la serie ahora
    fact.get_cell(defaultWorksheetIndex, 0, 1, "Nueva_Serie1")# Modificando el nombre de la serie
    series.data_points[0].value.data = 90
    series.data_points[1].value.data = 123
    series.data_points[2].value.data = 44

    # Tomar la segunda serie del gráfico
    series = chart.chart_data.series[1]

    # Actualizando los datos de la serie ahora
    fact.get_cell(defaultWorksheetIndex, 0, 2, "Nueva_Serie2")# Modificando el nombre de la serie
    series.data_points[0].value.data = 23
    series.data_points[1].value.data = 67
    series.data_points[2].value.data = 99


    # Ahora, Agregar una nueva serie
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 3, "Serie 3"), chart.type)

    # Tomar la tercera serie del gráfico
    series = chart.chart_data.series[2]

    # Población de datos de la serie ahora
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 3, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 3, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 3, 30))

    chart.type = charts.ChartType.CLUSTERED_CYLINDER

    # Guardar presentación con gráfico
    pres.save("AsposeChartModified_out-11.pptx", slides.export.SaveFormat.PPTX)
```

## **Estableciendo Rango de Datos para Gráficos**

1. Instanciar una clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) que represente la presentación que contiene el gráfico.
2. Obtener la referencia de una diapositiva a través de su índice.
3. Recorrer todas las formas para encontrar el gráfico deseado.
4. Acceder a los datos del gráfico y establecer el rango.
5. Guardar la presentación modificada como un archivo PPTX.

Este código Python te muestra cómo establecer el rango de datos para un gráfico:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar clase Presentation que representa el archivo PPTX
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Acceder a la primera diapositiva y agregar gráfico con datos predeterminados
    slide = presentation.slides[0]
    chart = slide.shapes[0]
    chart.chart_data.set_range("Hoja1!A1:B4")
    presentation.save("SetDataRange_out-12.pptx", slides.export.SaveFormat.PPTX)
```


## **Usando Marcadores Predeterminados en Gráficos**
Cuando usas un marcador predeterminado en gráficos, cada serie de gráficos obtiene diferentes símbolos de marcadores predeterminados automáticamente.

Este código Python te muestra cómo establecer un marcador de serie de gráfico automáticamente:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    fact = chart.chart_data.chart_data_workbook
    chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Serie 1"), chart.type)
    series = chart.chart_data.series[0]

    chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "C1"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 1, 1, 24))
    chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "C2"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 2, 1, 23))
    chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "C3"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 3, 1, -10))
    chart.chart_data.categories.add(fact.get_cell(0, 4, 0, "C4"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 4, 1, None))

    chart.chart_data.series.add(fact.get_cell(0, 0, 2, "Serie 2"), chart.type)
    #Tomar la segunda serie del gráfico
    series2 = chart.chart_data.series[1]

    #Ahora poblamos los datos de la serie
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 1, 2, 30))
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 2, 2, 10))
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 3, 2, 60))
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 4, 2, 40))

    chart.has_legend = True
    chart.legend.overlay = False

    pres.save("DefaultMarkersInChart-13.pptx", slides.export.SaveFormat.PPTX)
```