---
title: Series del Gráfico
type: docs
url: /es/python-net/chart-series/
keywords: "Series del gráfico, color de la serie, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Series del gráfico en presentaciones de PowerPoint en Python"
---

Una serie es una fila o columna de números trazados en un gráfico.

![series-del-gráfico-powerpoint](chart-series-powerpoint.png)

## **Establecer la Superposición de la Serie del Gráfico**

Con la propiedad [IChartSeriesOverlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/), puedes especificar cuánto deben superponerse las barras y columnas en un gráfico 2D (rango: -100 a 100). Esta propiedad se aplica a todas las series del grupo de series padre: es una proyección de la propiedad del grupo correspondiente. Por lo tanto, esta propiedad es de solo lectura.

Utiliza la propiedad de lectura/escritura `parent_series_group.overlap` para establecer tu valor preferido para `overlap`.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Añade un gráfico de columnas agrupadas en una diapositiva.
1. Accede a la primera serie del gráfico.
1. Accede al `parent_series_group` de la serie del gráfico y establece tu valor preferido de superposición para la serie.
1. Escribe la presentación modificada en un archivo PPTX.

Este código en Python te muestra cómo establecer la superposición para una serie de gráficos:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Agrega un gráfico
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400, True)
    series = chart.chart_data.series
    if series[0].overlap == 0:
        # Establece la superposición de la serie
        series[0].parent_series_group.overlap = -30

    # Escribe el archivo de presentación en el disco
    presentation.save("SetChartSeriesOverlap_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Cambiar el Color de la Serie**
Aspose.Slides para Python a través de .NET te permite cambiar el color de una serie de esta manera:

1. Crea una instancia de la clase `Presentation`.
1. Añade un gráfico en la diapositiva.
1. Accede a la serie cuyo color quieres cambiar.
1. Establece tu tipo de relleno y color de relleno preferidos.
1. Guarda la presentación modificada.

Este código en Python te muestra cómo cambiar el color de una serie:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 400)
	point = chart.chart_data.series[0].data_points[1]
	
	point.explosion = 30
	point.format.fill.fill_type = slides.FillType.SOLID
	point.format.fill.solid_fill_color.color = draw.Color.blue

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Cambiar el Color de la Categoría de la Serie**
Aspose.Slides para Python a través de .NET te permite cambiar el color de la categoría de una serie de esta manera:

1. Crea una instancia de la clase `Presentation`.
1. Añade un gráfico en la diapositiva.
1. Accede a la categoría de la serie cuyo color quieras cambiar.
1. Establece tu tipo de relleno y color de relleno preferidos.
1. Guarda la presentación modificada.

Este código en Python te muestra cómo cambiar el color de la categoría de una serie:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	point = chart.chart_data.series[0].data_points[0]
	
	point.format.fill.fill_type = slides.FillType.SOLID
	point.format.fill.solid_fill_color.color = draw.Color.blue

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Cambiar el Nombre de la Serie**

Por defecto, los nombres de la leyenda para un gráfico son los contenidos de las celdas sobre cada columna o fila de datos.

En nuestro ejemplo (imagen de muestra):

* las columnas son *Serie 1, Serie 2,* y *Serie 3*;
* las filas son *Categoría 1, Categoría 2, Categoría 3,* y *Categoría 4.* 

Aspose.Slides para Python a través de .NET te permite actualizar o cambiar un nombre de serie en sus datos de gráfico y leyenda.

Este código en Python te muestra cómo cambiar el nombre de una serie en sus datos de gráfico `ChartDataWorkbook`:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    
    seriesCell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    seriesCell.value = "Nuevo nombre"
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

Este código en Python te muestra cómo cambiar el nombre de una serie en su leyenda a través de `Series`:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    
    series.name.as_cells[0].value = "Nuevo nombre"

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX) 
```

## **Establecer el Color de Relleno de la Serie del Gráfico**

Aspose.Slides para Python a través de .NET te permite establecer el color de relleno automático para las series del gráfico dentro de un área de trazado de esta manera:

1. Crea una instancia de la clase `Presentation`.
1. Obtén una referencia de la diapositiva por su índice.
1. Añade un gráfico con datos predeterminados basado en tu tipo preferido (en el ejemplo a continuación, usamos `ChartType.CLUSTERED_COLUMN`).
1. Accede a las series del gráfico y establece el color de relleno en Automático.
1. Guarda la presentación en un archivo PPTX.

Este código en Python te muestra cómo establecer el color de relleno automático para una serie del gráfico:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Crea un gráfico de columnas agrupadas
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 50, 600, 400)

    # Establece el formato de relleno de la serie en automático
    for i in range(len(chart.chart_data.series)):
        chart.chart_data.series[i].get_automatic_series_color()

    # Escribe el archivo de presentación en el disco
    presentation.save("AutoFillSeries_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer los Colores de Relleno Invertidos de la Serie del Gráfico**
Aspose.Slides permite establecer el color de relleno invertido para las series del gráfico dentro de un área de trazado de esta manera:

1. Crea una instancia de la clase `Presentation`.
1. Obtén una referencia de la diapositiva por su índice.
1. Añade un gráfico con datos predeterminados basado en tu tipo preferido (en el ejemplo a continuación, usamos `ChartType.CLUSTERED_COLUMN`).
1. Accede a las series del gráfico y establece el color de relleno en invertir.
1. Guarda la presentación en un archivo PPTX.

Este código en Python demuestra la operación:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Agrega nuevas series y categorías
    chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Serie 1"), chart.type)
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Categoría 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Categoría 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Categoría 3"))

    # Toma la primera serie del gráfico y llena sus datos de serie.
    series = chart.chart_data.series[0]
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))
    seriesColor = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = seriesColor
    series.inverted_solid_fill_color.color = draw.Color.red
    pres.save("SetInvertFillColorChart_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer Inversión de la Serie Cuando el Valor es Negativo**
Aspose.Slides permite establecer inversiones a través de las propiedades `ChartDataPoint.invert_if_negative`. Cuando se establece una inversión utilizando las propiedades, el punto de datos invierte sus colores cuando recibe un valor negativo.

Este código en Python demuestra la operación:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400, True)
	series = chart.chart_data.series
	chart.chart_data.series.clear()

	series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)
	series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
	series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
	series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -2))
	series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

	series[0].invert_if_negative = False

	series[0].data_points[2].invert_if_negative = True

	pres.save("out.pptx", slides.export.SaveFormat.PPTX)
```

## **Limpiar los Datos de Puntos de Datos Específicos**
Aspose.Slides para Python a través de .NET te permite limpiar los datos de `data_points` para una serie de gráficos específica de esta manera:

1. Crea una instancia de la clase `Presentation`.
2. Obtén la referencia de una diapositiva a través de su índice.
3. Obtén la referencia de un gráfico a través de su índice.
4. Itera a través de todos los `data_points` del gráfico y establece `x_value` y `y_value` en nulo.
5. Limpia todos los `data_points` para una serie de gráficos específica.
6. Escribe la presentación modificada en un archivo PPTX.

Este código en Python demuestra la operación:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "TestChart.pptx") as pres:
    sl = pres.slides[0]
    chart = sl.shapes[0]

    for dataPoint in chart.chart_data.series[0].data_points:
        dataPoint.x_value.as_cell.value = None
        dataPoint.y_value.as_cell.value = None

    chart.chart_data.series[0].data_points.clear()

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer el Ancho de Espacio de la Serie**
Aspose.Slides para Python a través de .NET te permite establecer el Ancho de Espacio de una serie a través de la propiedad **`gap_width`** de esta manera:

1. Crea una instancia de la clase `Presentation`.
2. Accede a la primera diapositiva.
3. Añade un gráfico con datos predeterminados.
4. Accede a cualquier serie del gráfico.
5. Establece la propiedad `gap_width`.
6. Escribe la presentación modificada en un archivo PPTX.

Este código en Python te muestra cómo establecer el Ancho de Espacio de una serie:

```py
# Crea una presentación vacía 
with slides.Presentation() as presentation:

    # Accede a la primera diapositiva de la presentación
    slide = presentation.slides[0]

    # Agrega un gráfico con datos predeterminados
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 0, 0, 500, 500)

    # Establece el índice de la hoja de datos del gráfico
    defaultWorksheetIndex = 0

    # Obtiene la hoja de trabajo de datos del gráfico
    fact = chart.chart_data.chart_data_workbook

    # Agrega series
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Serie 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Serie 2"), chart.type)

    # Agrega Categorías
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Categoría 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Categoría 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Categoría 3"))

    # Toma la segunda serie del gráfico
    series = chart.chart_data.series[1]

    # Rellena los datos de la serie
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Establece el valor de GapWidth
    series.parent_series_group.gap_width = 50

    # Guarda la presentación en el disco
    presentation.save("GapWidth_out.pptx", slides.export.SaveFormat.PPTX)
```