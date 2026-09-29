---
title: Gestionar series de datos de gráficos en presentaciones en Python
linktitle: Series de datos
type: docs
url: /es/python-java/chart-series/
keywords:
- series de gráficos
- solapamiento de series
- color de series
- nombre de serie
- punto de datos
- celda de libro
- hueco de series
- valor negativo
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Aprenda a gestionar series de gráficos, puntos de datos, celdas de libro, formato, solapamiento, ancho de hueco y valores negativos en presentaciones con Aspose.Slides para Python vía Java."
---
## **Visión general**

Un gráfico almacena sus datos trazados en un libro de datos del gráfico. Un [ChartSeries](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/) representa un conjunto de valores relacionados, y cada [ChartDataPoint](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatapoint/) de la serie hace referencia a una o más celdas del libro. Los objetos [ChartCategory](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartcategory/) proporcionan las etiquetas o valores de agrupación compartidos por las series. Por lo tanto, el nombre de la serie, las categorías y los valores de los puntos están conectados a objetos [ChartDataCell](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatacell/) en lugar de almacenarse solo como texto visible.

Para un gráfico de categoría típico, el libro predeterminado utiliza la fila 0 para los nombres de serie, la columna 0 para los nombres de categoría y el resto de celdas para los valores de serie. Los índices de hoja, fila y columna que se pasan a [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdataworkbook/#getCell) son base cero. Este diseño es útil cuando crea un gráfico con datos predeterminados, pero no asuma que todo gráfico existente lo utiliza. Para una presentación cargada, inspeccione las celdas referenciadas por las series, categorías y puntos de datos antes de modificar los valores del libro.

Los ajustes del gráfico tienen tres ámbitos diferentes:

- Ajustes a nivel de serie, como [ChartSeries.getFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/#getFormat), proporcionan la apariencia predeterminada para todos los puntos de una serie.
- Ajustes a nivel de punto de datos, como [ChartDataPoint.getFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatapoint/#getFormat), sobrescriben la apariencia de la serie para un punto.
- Los ajustes de grupo se aplican a series compatibles que pertenecen al mismo [ChartSeriesGroup](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseriesgroup/). Acceda al grupo mediante [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/#getParentSeriesGroup) cuando necesite establecer opciones como solapamiento o ancho de hueco.

Cuando no se establece un relleno explícito para el punto o la serie, el estilo y el tema del gráfico determinan la apariencia automática. Cuando existen tanto formato de serie como de punto, el formato del punto tiene prioridad para ese punto.

![serie-de-gráfico-en-powerpoint](chart-series-powerpoint.png)

## **Establecer el solapamiento de la serie del gráfico**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/#getOverlap) indica cuánto se solapan las barras o columnas en un gráfico 2D, de -100 a 100 por ciento. Es una proyección de solo lectura del ajuste del grupo de series padre. Utilice [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseriesgroup/#setOverlap) para actualizar todas las series compatibles en ese grupo. Esta opción se aplica a tipos de gráfico que muestran barras o columnas agrupadas; no afecta a grupos de series no relacionados en un gráfico combinado.

El siguiente ejemplo establece el solapamiento para el grupo que contiene la primera serie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    # El nuevo gráfico contiene series, categorías y valores de ejemplo.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Solapamiento de la serie](series_overlap.png)

## **Cambiar el color de relleno de la serie**

Utilice [ChartSeries.getFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/#getFormat) para definir el relleno predeterminado de una serie completa. Si un punto ya tiene un relleno explícito, su ajuste [ChartDataPoint.getFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatapoint/#getFormat) sobrescribe el relleno de la serie para ese punto.

El siguiente ejemplo aplica un relleno sólido azul a la primera serie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("series_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Color de la serie](series_color.png)

## **Cambiar el nombre de la serie**

El nombre de una serie se almacena en el libro de datos del gráfico y normalmente se muestra en la leyenda. En el libro predeterminado creado para un gráfico de columnas agrupadas, la celda B1 está en la fila 0, columna 1 y contiene el nombre de la primera serie. Las variables nombradas en el siguiente ejemplo hacen explícita esa estructura:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    workbook = chart.getChartData().getChartDataWorkbook()
    series_name_cell = workbook.getCell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

También puede actualizar la celda ya referenciada por [ChartSeries.getName](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/#getName). Este enfoque evita asumir una fila y columna concretas en un gráfico existente:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series_name_cell = series.getName().getAsCells().get_Item(first_name_cell_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Nombre de la serie](series_name.png)

## **Obtener el color de relleno automático de la serie**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) devuelve el color calculado a partir del índice de la serie y el estilo del gráfico. Este es el color que se usa cuando el relleno de la serie no ha sido definido explícitamente. Llamar al método lee el color calculado; no asigna un nuevo relleno.

El siguiente ejemplo imprime el color automático de cada serie predeterminada:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

first_slide_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series_count = chart.getChartData().getSeries().size()
    for series_index in range(series_count):
        series = chart.getChartData().getSeries().get_Item(series_index)
        automatic_color = series.getAutomaticSeriesColor()
        print(f"Series {series_index}: {automatic_color}")
finally:
    presentation.dispose()
```

Salida de ejemplo para el estilo de gráfico predeterminado:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Los colores exactos dependen del estilo y tema del gráfico.

## **Establecer color de relleno invertido para una serie del gráfico**

Para series de barras, columnas y burbujas, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/#setInvertIfNegative) puede mostrar los valores negativos con un relleno diferente. Establezca el relleno regular de la serie como sólido, habilite la inversión y asigne el color de valor negativo mediante [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Los números negativos permanecen sin cambios en el libro; solo cambia su color de visualización.

El siguiente ejemplo sustituye los datos del gráfico predeterminados por una serie. La fila 0 de la hoja contiene el nombre de la serie, la columna 0 los nombres de categoría y la columna 1 los valores:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    chart_type = chart.getType()
    series = chart_data.getSeries().add(series_name_cell, chart_type)

    for category_index in range(len(category_names)):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.getCell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.setInvertIfNegative(True)
    series.getInvertedSolidFillColor().setColor(Color.RED)

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Color sólido invertido](inverted_solid_fill_color.png)

Puede habilitar la inversión para un punto mediante [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). En el siguiente ejemplo, la inversión está desactivada para la serie y activada solo para el punto seleccionado. Al punto también se le asigna un valor negativo para que el efecto sea visible:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.getInvertedSolidFillColor().setColor(Color.RED)
    series.setInvertIfNegative(False)

    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(negative_value)
    data_point.setInvertIfNegative(True)

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Borrar el valor de un punto de datos específico**

Para dejar un punto vacío sin eliminar los demás, establezca su celda de respaldo en `None`. En un gráfico de columnas, el valor trazado está disponible mediante [ChartDataPoint.getValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatapoint/#getValue). El punto de datos permanece en la misma posición de categoría, pero el gráfico trata su valor como vacío según la configuración de valores en blanco del gráfico.

El siguiente ejemplo borra solo el segundo punto de la primera serie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(None)

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Los gráficos de dispersión usan celdas X e Y separadas, y los gráficos de burbujas también emplean una celda de tamaño. Borre solo la celda que representa el valor que desea eliminar. No llame a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatapointcollection/#clear) cuando quiera conservar los demás puntos, porque ese método elimina todos los puntos de datos de la colección.

## **Controlar la visualización de celdas vacías**

Las celdas ocultas que contienen valores son un caso distinto de las celdas vacías. Para incluir o excluir datos de filas y columnas ocultas de la hoja, consulte [Incluir datos de filas y columnas ocultas](/slides/es/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Una celda de libro vacía representa datos ausentes; una celda que contiene `0` representa un valor numérico conocido. Llame a [ChartDataCell.setValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatacell/#setValue) con `None` para dejar la celda vacía. Un cero numérico sigue siendo cero sin importar la configuración de celdas en blanco.

Utilice [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/#setDisplayBlanksAs) para elegir cómo el gráfico muestra las celdas vacías. Esta configuración se aplica a todo el gráfico. Cambia cómo se trazan los vacíos, sin rellenar la celda del libro con cero o con un valor interpolado.

El siguiente ejemplo autocontenido crea un gráfico de líneas con una serie, borra el valor del Día 3 y guarda el mismo gráfico con cada modo. No se necesita archivo de entrada. El [ChartDataWorkbook](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdataworkbook/) usa la hoja 0, la columna 0 para etiquetas de categoría y la columna 1 para valores; la fila 0 contiene el nombre de la serie. Los datos finales son `10, 20, vacío, 30, 40`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayBlanksAsType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(0, 0, 1, "Measurements")
    series = chart_data.getSeries().add(series_name_cell, chart.getType())
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # Dejar el Día 3 realmente vacío, manteniendo su categoría y punto de datos.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Cada archivo de salida almacena el modo asignado antes de guardar: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` y `empty_cells_Span.pptx`. Para guardar solo una versión, asigne el modo deseado y guarde la presentación una única vez en lugar de iterar sobre los modos.

La comparación a continuación muestra los mismos datos en los tres archivos. El Día 3 está vacío en el libro en todos los casos:

![Gráficos de líneas con datos idénticos: Gap corta la línea en el Día 3, Zero lleva la línea a cero y Span conecta el Día 2 con el Día 4.](display_blanks_as.png)

El efecto visible depende del tipo de gráfico. Un gráfico de líneas facilita la comparación de los tres modos. Los gráficos de barras y columnas no tienen línea que conectar a través de una categoría ausente, de modo que `Span` no puede producir el segmento de conexión mostrado arriba; una columna ausente y una columna de altura cero también pueden parecer iguales. De forma similar, un gráfico de dispersión solo con marcadores no tiene línea de conexión. No espere tres resultados distintos para cada tipo de gráfico; compruebe la salida del tipo que utilice.

## **Establecer el ancho de hueco de la serie**

El ancho de hueco es el espacio entre grupos adyacentes de barras o columnas, expresado como porcentaje del ancho de la barra o columna. Al igual que el solapamiento, pertenece al grupo de series padre más que a una sola serie. Llame a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseriesgroup/#setGapWidth) una vez para el grupo. Un valor mayor crea más espacio entre los grupos; un valor menor los hace más densos.

El siguiente ejemplo cambia el ancho de hueco y guarda solo la presentación final:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setGapWidth(gap_width_percent)

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Ancho de hueco](gap_width.png)

## **FAQ**

**¿Qué tipos de gráfico admiten series de datos?**

Todos los tipos de gráfico representados por la enumeración [ChartType](https://reference.aspose.com/slides/es/python-java/aspose.slides/charttype/) utilizan datos del gráfico, pero sus series no comparten la misma estructura de valores ni los mismos ajustes. Por ejemplo, los gráficos de categoría usan categorías y valores, los gráficos de dispersión usan valores X e Y, y los gráficos de burbujas añaden tamaños de burbuja. Utilice el método de creación de punto de datos que coincida con el tipo de serie. Opciones como solapamiento y ancho de hueco solo se aplican a grupos de barras o columnas compatibles.

**¿Qué es un grupo de series de gráfico?**

Un [ChartSeriesGroup](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseriesgroup/) contiene series compatibles que comparten ajustes de trazado a nivel de grupo. Un gráfico combinado puede contener más de un grupo, de modo que cambiar el grupo alcanzado a través de una serie no necesariamente modifica todas las series del gráfico.

**¿Un gráfico recién creado contiene datos predeterminados?**

Sí. Por defecto, [ShapeCollection.addChart](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addChart) crea series, categorías y valores de ejemplo. Puede editar esas celdas o borrar tanto las colecciones de series como de categorías antes de añadir un conjunto de datos totalmente personalizado. También existe una sobrecarga que crea un gráfico sin datos predeterminados.

**¿Cómo se conectan los objetos del gráfico a las celdas del libro?**

Los nombres de serie, etiquetas de categoría y valores de punto de datos hacen referencia a celdas en un [ChartDataWorkbook](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdataworkbook/). Cambiar una celda referenciada actualiza el elemento del gráfico correspondiente. Cuando crea datos personalizados, mantenga alineadas las filas de categorías y las filas de valores de serie para que cada punto se trace bajo la categoría prevista.

**¿Cómo limpio un único punto sin eliminar toda la serie?**

Establezca la celda de valor correspondiente a `None` para conservar la posición de categoría del punto como punto vacío. Utilice [ChartDataPointCollection.clear](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatapointcollection/#clear) solo cuando pretenda eliminar todos los puntos de esa serie. Si también elimina categorías, actualice cada serie para que sus valores permanezcan alineados con la colección de categorías.

**¿Cómo se muestran los puntos vacíos?**

El resultado depende del tipo de gráfico y del valor configurado mediante [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/#setDisplayBlanksAs). Los gráficos admitidos pueden mostrar los vacíos como huecos, como valores cero o conectando los puntos vecinos. Elija la configuración que coincida con el significado de los datos ausentes en su presentación. Consulte [Controlar la visualización de celdas vacías](#controlar-la-visualización-de-celdas-vacías) para un ejemplo completo y una comparación visual.

**¿Cómo se formatean los valores negativos?**

Para series de barras, columnas y burbujas compatibles, llame a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/#setInvertIfNegative) y establezca el color devuelto por [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Puede sobrescribir el comportamiento para un punto individual con [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Estos métodos afectan al formato, no a los valores numéricos almacenados.

**¿Qué formato prevalece cuando tanto una serie como un punto están formateados?**

El formato explícito del punto de datos tiene precedencia para ese punto. Los demás puntos continúan utilizando el formato explícito de la serie o, cuando no está definido, el estilo y tema automáticos del gráfico. Los ajustes de grupo, como solapamiento y ancho de hueco, controlan la disposición y no son sobrescrituras de formato a nivel de punto.

**¿Existe un límite en la cantidad de series que puede contener un gráfico?**

Aspose.Slides no impone un límite fijo de series. En la práctica, las limitaciones del archivo de presentación, la memoria disponible, el tiempo de renderizado y la legibilidad del gráfico determinan un límite razonable.

**¿Qué debo modificar cuando las columnas están demasiado juntas o demasiado separadas?**

Llame a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseriesgroup/#setGapWidth) en el grupo de series padre correspondiente. Aumente el valor para ensanchar el espacio entre los grupos, o disminúyalo para acercarlos.