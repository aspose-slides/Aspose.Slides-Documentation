---
title: Gestionar series de datos de gráficos en presentaciones con Python
linktitle: Series de datos
type: docs
url: /es/python-net/chart-series/
keywords:
- series de gráficos
- superposición de series
- color de series
- color de categoría
- nombre de serie
- punto de datos
- espacio entre series
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprenda a gestionar series de gráficos, puntos de datos, celdas de libros de trabajo, formato, superposición, ancho del espacio y valores negativos en presentaciones con Python."
---
## **Descripción general**

Un gráfico almacena sus datos trazados en un libro de datos de gráfico. Un [ChartSeries](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartseries/) representa un conjunto de valores relacionados, y cada [ChartDataPoint](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdatapoint/) de la serie hace referencia a una o más celdas del libro. Los objetos [ChartCategory](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartcategory/) proporcionan las etiquetas o valores de agrupación compartidos por las series. Por lo tanto, el nombre de la serie, las categorías y los valores de los puntos están conectados a objetos [ChartDataCell](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdatacell/) en lugar de almacenarse solo como texto de pantalla.

Para un gráfico de categorías típico, el libro predeterminado usa la fila 0 para los nombres de series, la columna 0 para los nombres de categorías y el resto de celdas para los valores de las series. Los índices de hoja, fila y columna que se pasan a [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) son base cero. Este diseño es útil cuando se crea un gráfico con datos predeterminados, pero no se debe suponer que todos los gráficos existentes lo utilizan. Para una presentación cargada, examine las celdas referenciadas por las series, categorías y puntos de datos antes de cambiar los valores del libro.

Los ajustes del gráfico tienen tres ámbitos diferentes:

- Configuraciones a nivel de serie, como [ChartSeries.format](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartseries/format/), proporcionan la apariencia predeterminada para todos los puntos de una serie.
- Configuraciones de punto de datos, como [ChartDataPoint.format](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdatapoint/format/), sobrescriben la apariencia de la serie para un punto.
- Las configuraciones de grupo se aplican a series compatibles que pertenecen al mismo [ChartSeriesGroup](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartseriesgroup/). Acceda al grupo mediante [ChartSeries.parent_series_group](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartseries/parent_series_group/) cuando necesite establecer opciones como la superposición o el ancho del espacio.

Cuando no se establece un relleno explícito de punto o de serie, el estilo y el tema del gráfico determinan la apariencia automática. Cuando existen tanto formatos de serie como de punto, el formato del punto tiene prioridad para ese punto.

![serie de gráfico en PowerPoint](chart-series-powerpoint.png)

## **Establecer la superposición de la serie del gráfico**

[ChartSeries.overlap](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartseries/overlap/) indica cuánto se superponen las barras o columnas en un gráfico 2D, desde -100 hasta 100 por ciento. Es una proyección de solo lectura del ajuste en el grupo de series principal. Establezca [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartseriesgroup/overlap/) para actualizar todas las series compatibles en ese grupo. Esta opción se aplica a los tipos de gráfico que muestran barras o columnas agrupadas; no afecta a los grupos de series no relacionados en un gráfico combinado.

El siguiente ejemplo define la superposición para el grupo que contiene la primera serie:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # El nuevo gráfico contiene series, categorías y valores de ejemplo.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![Superposición de la serie](series_overlap.png)

## **Cambiar el color de relleno de la serie**

Utilice [ChartSeries.format](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartseries/format/) para establecer el relleno predeterminado de una serie completa. Si un punto ya tiene un relleno explícito, su ajuste [ChartDataPoint.format](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdatapoint/format/) sobrescribe el relleno de la serie para ese punto.

El siguiente ejemplo aplica un relleno sólido azul a la primera serie:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = drawing.Color.blue

    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![Color de la serie](series_color.png)

## **Cambiar el nombre de la serie**

El nombre de una serie se almacena en el libro de datos del gráfico y normalmente se muestra en la leyenda. En el libro predeterminado creado para un gráfico de columnas agrupadas, la celda B1 está en la fila 0, columna 1 y contiene el nombre de la primera serie. Las constantes nombradas en el siguiente ejemplo hacen explícita esa estructura:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    workbook = chart.chart_data.chart_data_workbook
    series_name_cell = workbook.get_cell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

También puede actualizar la celda ya referenciada por [ChartSeries.name](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartseries/name/). Este enfoque evita suponer una fila y columna concretas en un gráfico existente:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series_name_cell = series.name.as_cells[first_name_cell_index]
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![Nombre de la serie](series_name.png)

## **Obtener el color de relleno automático de la serie**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) devuelve el color calculado a partir del índice de la serie y del estilo del gráfico. Este es el color utilizado cuando el relleno de la serie no ha sido definido explícitamente. Llamar al método lee el color calculado; no asigna un nuevo relleno.

El siguiente ejemplo muestra el color automático de cada serie predeterminada:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series_count = len(chart.chart_data.series)
    for series_index in range(series_count):
        series = chart.chart_data.series[series_index]
        automatic_color = series.get_automatic_series_color()
        print(f"Series {series_index}: {automatic_color.name}")
```

Salida de ejemplo para el estilo de gráfico predeterminado:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Los colores exactos dependen del estilo y del tema del gráfico.

## **Establecer el color de relleno invertido para una serie del gráfico**

Para series de barras, columnas y burbujas, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartseries/invert_if_negative/) puede mostrar valores negativos con un relleno diferente. Establezca el relleno normal de la serie como sólido, habilite la inversión y asigne el color de valor negativo mediante [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Los números negativos permanecen sin cambios en el libro; solo varía su color de visualización.

El siguiente ejemplo sustituye los datos predeterminados del gráfico por una sola serie. La fila 0 de la hoja contiene el nombre de la serie, la columna 0 contiene los nombres de las categorías y la columna 1 contiene los valores:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    series = chart_data.series.add(series_name_cell, chart.type)

    category_count = len(category_names)
    for category_index in range(category_count):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.get_cell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.data_points.add_data_point_for_bar_series(value_cell)

    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.invert_if_negative = True
    series.inverted_solid_fill_color.color = drawing.Color.red

    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![Color de relleno sólido invertido](inverted_solid_fill_color.png)

Puede habilitar la inversión para un punto mediante [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). En el siguiente ejemplo, la inversión está desactivada para la serie y activada solo para el punto seleccionado. Al punto también se le asigna un valor negativo para que el efecto sea visible:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.inverted_solid_fill_color.color = drawing.Color.red
    series.invert_if_negative = False

    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = negative_value
    data_point.invert_if_negative = True

    presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **Borrar el valor de un punto de datos específico**

Para dejar un punto vacío sin eliminar los demás, establezca su celda de respaldo en el libro en `None`. Para un gráfico de columnas, el valor trazado está disponible a través de [ChartDataPoint.value](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdatapoint/value/). El punto de datos permanece en la misma posición de categoría, pero el gráfico trata su valor como vacío según la configuración de valores en blanco del gráfico.

El siguiente ejemplo borra solo el segundo punto de la primera serie:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = None

    presentation.save("clear_data_point_value.pptx", slides.export.SaveFormat.PPTX)
```

Los gráficos de dispersión usan celdas X y Y separadas, y los gráficos de burbujas también utilizan una celda de tamaño. Borra solo la celda que representa el valor que desea eliminar. No llame a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdatapointcollection/clear/) cuando quiera conservar los demás puntos, ya que ese método elimina todos los puntos de datos de la colección.

## **Controlar la visualización de celdas vacías**

Las celdas ocultas que contienen valores son un caso distinto de las celdas vacías. Para incluir o excluir datos de filas y columnas ocultas de la hoja, vea [Include Data from Hidden Rows and Columns](/slides/es/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Una celda de libro vacía representa datos faltantes; una celda que contiene `0` representa un valor numérico conocido. Establezca [ChartDataCell.value](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdatacell/value/) en `None` para dejar la celda vacía. Un cero numérico sigue siendo cero independientemente de la configuración de celdas en blanco.

Utilice [Chart.display_blanks_as](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chart/display_blanks_as/) para elegir cómo el gráfico muestra las celdas vacías. Esta configuración se aplica a todo el gráfico. Cambia la forma en que se trazan los vacíos, sin rellenar la celda del libro vacía con cero o con un valor interpolado.

El siguiente ejemplo autónomo crea un gráfico de líneas con una serie, borra el valor del día 3 y guarda el mismo gráfico con cada modo. No se necesita archivo de entrada. El [ChartDataWorkbook](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdataworkbook/) usa la hoja 0, la columna 0 para etiquetas de categoría y la columna 1 para valores; la fila 0 contiene el nombre de la serie. Los datos finales son `10, 20, empty, 30, 40`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 40, 40, 640, 400)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(0, 0, 1, "Measurements")
    series = chart_data.series.add(series_name_cell, chart.type)
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Dejar el día 3 realmente vacío, manteniendo su categoría y punto de datos.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Cada archivo de salida almacena el modo asignado antes de guardar: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` y `empty_cells_Span.pptx`. Para guardar solo una versión, asigne el modo deseado y guarde la presentación una sola vez en lugar de iterar sobre los modos.

La comparación a continuación muestra los mismos datos en los tres archivos. El día 3 está vacío en el libro en todos los casos:

![Gráficos de líneas con datos idénticos: Gap interrumpe la línea en el día 3, Zero baja la línea a cero y Span conecta el día 2 con el día 4.](display_blanks_as.png)

El efecto visible depende del tipo de gráfico. Un gráfico de líneas facilita la comparación de los tres modos. Los gráficos de barras y columnas no tienen línea que conectar a través de una categoría ausente, por lo que `SPAN` no puede producir el segmento de conexión que se muestra arriba; una columna ausente y una columna de altura cero también pueden parecer iguales. Del mismo modo, un gráfico de dispersión solo con marcadores no tiene línea de conexión. No espere tres resultados distintos para cada tipo de gráfico; compruebe la salida para el tipo que utilice.

## **Establecer el ancho del espacio entre series**

El ancho del espacio es el espacio entre grupos adyacentes de barras o columnas, expresado como porcentaje del ancho de la barra o columna. Al igual que la superposición, pertenece al grupo de series principal y no a una serie individual. Establezca [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) una vez para el grupo. Un valor mayor crea más espacio entre los grupos; un valor menor los hace más densos.

El siguiente ejemplo modifica el ancho del espacio y guarda solo la presentación final:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.gap_width = gap_width_percent

    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![Ancho del espacio](gap_width.png)

## **Preguntas frecuentes**

**¿Qué tipos de gráfico admiten series de datos?**

Todos los tipos de gráfico representados por la enumeración [ChartType](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/charttype/) utilizan datos de gráfico, pero sus series no siempre tienen la misma estructura de valores ni la misma configuración. Por ejemplo, los gráficos de categorías usan categorías y valores, los de dispersión usan valores X y Y, y los de burbujas añaden tamaños de burbuja. Utilice el método de creación de puntos de datos que coincida con el tipo de serie. Opciones como superposición y ancho del espacio solo se aplican a grupos de barras o columnas compatibles.

**¿Qué es un grupo de series de gráfico?**

Un [ChartSeriesGroup](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartseriesgroup/) contiene series compatibles que comparten ajustes de trazado a nivel de grupo. Un gráfico combinado puede contener más de un grupo, por lo que cambiar el grupo al que se accede a través de una serie no necesariamente modifica todas las series del gráfico.

**¿Un gráfico recién creado contiene datos predeterminados?**

Sí. De forma predeterminada, [ShapeCollection.add_chart](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/add_chart/) crea series, categorías y valores de muestra. Puede editar esas celdas o borrar tanto las colecciones de series como de categorías antes de añadir un conjunto de datos totalmente personalizado. También existe una sobrecarga que crea un gráfico sin datos predeterminados.

**¿Cómo están conectados los objetos del gráfico a las celdas del libro?**

Los nombres de series, las etiquetas de categoría y los valores de los puntos de datos hacen referencia a celdas en un [ChartDataWorkbook](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdataworkbook/). Cambiar una celda referenciada actualiza el elemento correspondiente del gráfico. Cuando construye datos personalizados, mantenga alineadas las filas de categorías y las filas de valores de series para que cada punto se trace bajo la categoría prevista.

**¿Cómo borro un punto en lugar de toda la serie?**

Establezca la celda de valor correspondiente en `None` para conservar la posición de categoría del punto como un punto vacío. Utilice [ChartDataPointCollection.clear](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdatapointcollection/clear/) solo cuando desee eliminar todos los puntos de esa serie. Si también elimina categorías, actualice todas las series para que sus valores permanezcan alineados con la colección de categorías.

**¿Cómo se muestran los puntos vacíos?**

El resultado depende del tipo de gráfico y de [Chart.display_blanks_as](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chart/display_blanks_as/). Los gráficos compatibles pueden mostrar los vacíos como espacios, como valores cero o conectando los puntos vecinos. Elija la configuración que coincida con el significado de los datos faltantes en su presentación. Consulte **Controlar la visualización de celdas vacías** para un ejemplo completo y una comparación visual.

**¿Cómo se formatean los valores negativos?**

Para series de barras, columnas y burbujas admitidas, habilite [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartseries/invert_if_negative/) y establezca [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Puede sobrescribir el comportamiento en un punto individual con [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Estas propiedades afectan al formato, no a los valores numéricos almacenados.

**¿Qué formato prevalece cuando se formatea tanto la serie como el punto?**

El formato explícito del punto de datos tiene prioridad para ese punto. Los demás puntos continúan usando el formato explícito de la serie o, cuando no está definido, el estilo y tema automáticos del gráfico. Las propiedades de grupo, como superposición y ancho del espacio, controlan la disposición y no sobrescriben el formato a nivel de punto.

**¿Existe un límite de cuántas series puede contener un gráfico?**

Aspose.Slides no impone un límite fijo separado para el número de series. En la práctica, las limitaciones del archivo de presentación, la memoria disponible, el tiempo de renderizado y la legibilidad del gráfico determinan un límite útil.

**¿Qué debo ajustar cuando las columnas están demasiado juntas o demasiado separadas?**

Establezca [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) en el grupo de series principal correspondiente. Incrementar el valor ampliará el espacio entre los grupos, y disminuirlo los acercará.