---
title: Gestionar series de datos de gráficos en presentaciones en Python
linktitle: Series de datos
type: docs
url: /es/python-java/chart-series/
keywords:
- series de gráfico
- solapamiento de series
- color de series
- nombre de serie
- punto de datos
- celda de libro
- brecha de serie
- valor negativo
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Aprenda a gestionar series de gráficos, puntos de datos, celdas de libro, formato, solapamiento, ancho de la brecha y valores negativos en presentaciones con Aspose.Slides para Python a través de Java."
---
## **Visión general**

Un gráfico almacena sus datos trazados en un libro de datos de gráfico. Un [ChartSeries](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/) representa un conjunto de valores relacionados, y cada [ChartDataPoint](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatapoint/) de la serie se refiere a una o más celdas del libro. Los objetos [ChartCategory](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartcategory/) proporcionan las etiquetas o valores de agrupación compartidos por las series. Por lo tanto, el nombre de la serie, las categorías y los valores de los puntos están conectados a objetos [ChartDataCell](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatacell/) en lugar de almacenarse solo como texto visible.

Para un gráfico de categorías típico, el libro predeterminado usa la fila 0 para los nombres de las series, la columna 0 para los nombres de las categorías y el resto de las celdas para los valores de las series. Los índices de hoja, fila y columna que se pasan a [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdataworkbook/#getCell) son base cero. Este diseño es útil cuando se crea un gráfico con datos predeterminados, pero no se debe suponer que todo gráfico existente lo utilice. Para una presentación cargada, examine las celdas a las que hacen referencia las series, las categorías y los puntos de datos antes de modificar los valores del libro.

Los ajustes del gráfico tienen tres ámbitos diferentes:

- Ajustes a nivel de serie, como [ChartSeries.getFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/#getFormat), que proporcionan la apariencia predeterminada para todos los puntos de una serie.
- Ajustes de punto de datos, como [ChartDataPoint.getFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatapoint/#getFormat), que sustituyen la apariencia de la serie para un punto concreto.
- Los ajustes de grupo se aplican a series compatibles que pertenecen al mismo [ChartSeriesGroup](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseriesgroup/). Acceda al grupo mediante [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/#getParentSeriesGroup) cuando necesite establecer opciones como solapamiento o ancho de la brecha.

Cuando no se establece un relleno explícito para el punto o la serie, el estilo y el tema del gráfico determinan la apariencia automática. Cuando existen formatos tanto para la serie como para el punto, el formato del punto tiene prioridad para ese punto.

![serie de gráfico PowerPoint](chart-series-powerpoint.png)

## **Establecer el solapamiento de la serie del gráfico**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/#getOverlap) indica cuánto se solapan las barras o columnas en un gráfico 2D, de -100 a 100 por ciento. Es una proyección de solo lectura del ajuste en el grupo de series padre. Use [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseriesgroup/#setOverlap) para actualizar todas las series compatibles en ese grupo. Esta opción se aplica a los tipos de gráfico que muestran barras o columnas agrupadas; no afecta a los grupos de series no relacionados en un gráfico combinado.

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

    # El nuevo gráfico contiene series, categorías y valores de muestra.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![El solapamiento de la serie](series_overlap.png)

## **Cambiar el color de relleno de la serie**

Utilice [ChartSeries.getFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/#getFormat) para establecer el relleno predeterminado de una serie completa. Si un punto ya tiene un relleno explícito, su ajuste [ChartDataPoint.getFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatapoint/#getFormat) sustituye el relleno de la serie para ese punto.

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

![El color de la serie](series_color.png)

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

También puede actualizar la celda ya referenciada por [ChartSeries.getName](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/#getName). Este enfoque evita suponer una fila y columna concretas en un gráfico existente:

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

![El nombre de la serie](series_name.png)

## **Obtener el color de relleno automático de la serie**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) devuelve el color calculado a partir del índice de la serie y del estilo del gráfico. Este es el color que se usa cuando el relleno de la serie no ha sido definido explícitamente. Llamar al método lee el color calculado; no asigna un nuevo relleno.

El siguiente ejemplo muestra el color automático de cada serie predeterminada:

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

Los colores exactos dependen del estilo y del tema del gráfico.

## **Establecer el color de relleno invertido para una serie del gráfico**

Para series de barras, columnas y burbujas, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/#setInvertIfNegative) puede mostrar los valores negativos con un relleno diferente. Establezca el relleno regular de la serie como sólido, habilite la inversión y asigne el color de valor negativo mediante [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Los números negativos permanecen sin cambios en el libro; solo cambia su color de visualización.

El siguiente ejemplo reemplaza los datos de gráfico predeterminados con una serie. La fila 0 de la hoja contiene el nombre de la serie, la columna 0 contiene los nombres de las categorías y la columna 1 contiene los valores:

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

![El color de relleno sólido invertido](inverted_solid_fill_color.png)

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

Para dejar un punto vacío sin eliminar los demás, establezca su celda de respaldo del libro en `None`. En un gráfico de columnas, el valor trazado está disponible mediante [ChartDataPoint.getValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatapoint/#getValue). El punto de datos permanece en la misma posición de categoría, pero el gráfico trata su valor como vacío según la configuración de valores en blanco del gráfico.

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

Los gráficos de dispersión usan celdas X e Y separadas, y los gráficos de burbujas también usan una celda de tamaño. Borre solo la celda que representa el valor que desea eliminar. No llame a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatapointcollection/#clear) cuando quiera conservar los demás puntos, porque ese método elimina todos los puntos de datos de la colección.

## **Establecer el ancho de la brecha de la serie**

El ancho de la brecha es el espacio entre clústeres de barras o columnas adyacentes, expresado como porcentaje del ancho de la barra o columna. Al igual que el solapamiento, pertenece al grupo de series padre y no a una sola serie. Llame a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseriesgroup/#setGapWidth) una vez para el grupo. Un valor mayor crea más espacio entre los clústeres; un valor menor los hace más densos.

El siguiente ejemplo cambia el ancho de la brecha y guarda solo la presentación final:

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

![El ancho de la brecha](gap_width.png)

## **FAQ**

**¿Qué tipos de gráfico admiten series de datos?**

Todos los tipos de gráfico representados por la enumeración [ChartType](https://reference.aspose.com/slides/es/python-java/aspose.slides/charttype/) utilizan datos de gráfico, pero sus series no comparten siempre la misma estructura de valores ni los mismos ajustes. Por ejemplo, los gráficos de categorías usan categorías y valores, los de dispersión usan valores X e Y, y los de burbujas añaden tamaños de burbuja. Use el método de creación de puntos de datos que corresponda al tipo de serie. Opciones como solapamiento y ancho de la brecha solo se aplican a grupos de barras o columnas compatibles.

**¿Qué es un grupo de series de gráfico?**

Un [ChartSeriesGroup](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseriesgroup/) contiene series compatibles que comparten ajustes de trazado a nivel de grupo. Un gráfico combinado puede contener más de un grupo, de modo que cambiar el grupo alcanzado a través de una serie no necesariamente modifica todas las series del gráfico.

**¿Un gráfico recién creado contiene datos predeterminados?**

Sí. De forma predeterminada, [ShapeCollection.addChart](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addChart) crea series, categorías y valores de ejemplo. Puede editar esas celdas o borrar tanto las colecciones de series como de categorías antes de añadir un conjunto de datos completamente personalizado. También existe una sobrecarga que crea un gráfico sin datos predeterminados.

**¿Cómo están conectados los objetos del gráfico a las celdas del libro?**

Los nombres de series, etiquetas de categoría y valores de puntos de datos hacen referencia a celdas en un [ChartDataWorkbook](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdataworkbook/). Cambiar una celda referenciada actualiza el elemento correspondiente del gráfico. Cuando construye datos personalizados, mantenga alineadas las filas de categorías y las filas de valores de series para que cada punto se trace bajo la categoría prevista.

**¿Cómo borro un punto en lugar de toda la serie?**

Establezca la celda de valor correspondiente a `None` para conservar la posición de categoría del punto como un punto vacío. Use [ChartDataPointCollection.clear](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatapointcollection/#clear) solo cuando pretenda eliminar todos los puntos de esa serie. Si también elimina categorías, actualice cada serie para que sus valores sigan alineados con la colección de categorías.

**¿Cómo se muestran los puntos vacíos?**

El resultado depende del tipo de gráfico y del valor configurado mediante [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/#setDisplayBlanksAs). Los gráficos compatibles pueden mostrar los vacíos como huecos, como valores cero o conectando los puntos vecinos. Elija la configuración que coincida con el significado de los datos ausentes en su presentación.

**¿Cómo se formatean los valores negativos?**

Para series de barras, columnas y burbujas admitidas, llame a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/#setInvertIfNegative) y establezca el color devuelto por [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Puede anular el comportamiento para un punto individual con [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Estos métodos afectan al formato, no a los valores numéricos almacenados.

**¿Qué formato prevalece cuando tanto una serie como un punto están formateados?**

El formato explícito del punto de datos tiene prioridad para ese punto. Los demás puntos continúan usando el formato explícito de la serie o, cuando no hay un formato de serie definido, el estilo y tema automáticos del gráfico. Los ajustes de grupo como solapamiento y ancho de la brecha controlan la disposición y no sustituyen el formato a nivel de punto.

**¿Existe un límite en la cantidad de series que puede contener un gráfico?**

Aspose.Slides no impone un límite fijo separado de series. En la práctica, las limitaciones del archivo de presentación, la memoria disponible, el tiempo de renderizado y la legibilidad del gráfico determinan un límite útil.

**¿Qué debo modificar cuando las columnas están demasiado juntas o demasiado separadas?**

Llame a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseriesgroup/#setGapWidth) sobre el grupo de series padre correspondiente. Aumente el valor para ampliar el espacio entre los clústeres o disminúyalo para acercarlos.