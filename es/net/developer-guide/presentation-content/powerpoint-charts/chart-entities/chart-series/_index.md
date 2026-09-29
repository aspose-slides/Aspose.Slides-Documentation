---
title: Gestionar series de datos de gráficos en presentaciones en .NET
linktitle: Series de datos
type: docs
url: /es/net/chart-series/
keywords:
- series de gráficos
- solapamiento de series
- color de serie
- color de categoría
- nombre de serie
- punto de datos
- espacio entre series
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a gestionar series de gráficos, puntos de datos, celdas del libro de trabajo, formato, solapamiento, ancho del espacio y valores negativos en presentaciones con C#."
---
## **Visión general**

Un gráfico almacena sus datos trazados en un libro de datos del gráfico. Un [IChartSeries](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartseries/) representa un conjunto de valores relacionados, y cada [IChartDataPoint](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdatapoint/) de la serie se refiere a una o más celdas del libro. Los objetos [IChartCategory](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartcategory/) proporcionan las etiquetas o valores de agrupación compartidos por las series. Por lo tanto, el nombre de la serie, las categorías y los valores de los puntos están conectados a objetos [IChartDataCell](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdatacell/) en lugar de almacenarse solo como texto de visualización.

Para un gráfico de categorías típico, el libro de datos predeterminado usa la fila 0 para los nombres de las series, la columna 0 para los nombres de las categorías y el resto de las celdas para los valores de las series. Los índices de hoja, fila y columna que se pasan a [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdataworkbook/getcell/) son basados en cero. Este diseño es útil cuando crea un gráfico con datos predeterminados, pero no asuma que todos los gráficos existentes lo usan. Para una presentación cargada, inspeccione las celdas a las que hacen referencia las series, categorías y puntos de datos antes de cambiar los valores del libro.

Los ajustes del gráfico tienen tres ámbitos diferentes:

- Ajustes a nivel de serie, como [IChartSeries.Format](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartseries/format/), que proporcionan la apariencia predeterminada para todos los puntos de una serie.
- Ajustes de punto de datos, como [IChartDataPoint.Format](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdatapoint/format/), que sobrescriben la apariencia de la serie para un punto.
- Los ajustes de grupo se aplican a series compatibles que pertenecen al mismo [IChartSeriesGroup](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartseriesgroup/). Acceda al grupo mediante [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartseries/parentseriesgroup/) cuando necesite establecer opciones como solapamiento o ancho del espacio.

Cuando no se establece un relleno explícito de punto o serie, el estilo y el tema del gráfico determinan la apariencia automática. Cuando existen tanto el formato de la serie como el del punto, el formato del punto tiene prioridad para ese punto.

![serie del gráfico en PowerPoint](chart-series-powerpoint.png)

## **Establecer el solapamiento de series del gráfico**

[IChartSeries.Overlap](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartseries/overlap/) indica cuánto se solapan las barras o columnas en un gráfico 2D, de -100 a 100 por ciento. Es una proyección de solo lectura del ajuste en el grupo de series padre. Establezca [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartseriesgroup/overlap/) para actualizar todas las series compatibles en ese grupo. Esta opción se aplica a los tipos de gráfico que muestran barras o columnas agrupadas; no afecta a los grupos de series no relacionados en un gráfico combinado.

El siguiente ejemplo establece el solapamiento para el grupo que contiene la primera serie:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// El nuevo gráfico contiene series, categorías y valores de muestra.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

El resultado:

![Solapamiento de la serie](series_overlap.png)

## **Cambiar el color de relleno de la serie**

Utilice [IChartSeries.Format](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartseries/format/) para establecer el relleno predeterminado de una serie completa. Si un punto ya tiene un relleno explícito, su ajuste [IChartDataPoint.Format](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdatapoint/format/) sobrescribe el relleno de la serie para ese punto.

El siguiente ejemplo aplica un relleno sólido azul a la primera serie:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Blue;

presentation.Save("series_color.pptx", SaveFormat.Pptx);
```

El resultado:

![Color de la serie](series_color.png)

## **Cambiar el nombre de la serie**

El nombre de una serie se almacena en el libro de datos del gráfico y normalmente se muestra en la leyenda. En el libro predeterminado creado para un gráfico de columnas agrupadas, la celda B1 está en la fila 0, columna 1 y contiene el nombre de la primera serie. Las constantes nombradas en el siguiente ejemplo hacen explícita esa estructura:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesNameCell = workbook.GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

También puede actualizar la celda ya referenciada por [IChartSeries.Name](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartseries/name/). Este enfoque evita asumir una fila y columna específicas en un gráfico existente:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var seriesNameCell = series.Name.AsCells[firstNameCellIndex];
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

El resultado:

![Nombre de la serie](series_name.png)

## **Obtener el color automático de relleno de la serie**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) devuelve el color calculado a partir del índice de la serie y del estilo del gráfico. Este es el color que se usa cuando el relleno de la serie no ha sido definido explícitamente. Llamar al método lee el color calculado; no asigna un nuevo relleno.

El siguiente ejemplo muestra el color automático de cada serie predeterminada:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

const int firstSlideIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var seriesCount = chart.ChartData.Series.Count;
for (var seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    var automaticColor = series.GetAutomaticSeriesColor();
    Console.WriteLine($"Series {seriesIndex}: {automaticColor.Name}");
}
```

Salida de ejemplo para el estilo de gráfico predeterminado:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Los colores exactos dependen del estilo y del tema del gráfico.

## **Establecer el color de relleno invertido para una serie del gráfico**

Para series de barras, columnas y burbujas, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartseries/invertifnegative/) puede mostrar valores negativos con un relleno diferente. Establezca el relleno regular de la serie a sólido, habilite la inversión y asigne el color de valor negativo mediante [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Los números negativos permanecen sin cambios en el libro; solo su color de visualización cambia.

El siguiente ejemplo sustituye los datos predeterminados del gráfico por una serie. La fila 0 de la hoja contiene el nombre de la serie, la columna 0 contiene los nombres de las categorías y la columna 1 contiene los valores:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;

var categoryNames = new[] { "Category 1", "Category 2", "Category 3" };
var seriesValues = new[] { -20, 50, -30 };

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
var series = chartData.Series.Add(seriesNameCell, chart.Type);

for (var categoryIndex = 0; categoryIndex < categoryNames.Length; categoryIndex++)
{
    var dataRowIndex = firstDataRowIndex + categoryIndex;
    var categoryName = categoryNames[categoryIndex];
    var seriesValue = seriesValues[categoryIndex];

    var categoryCell = workbook.GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
    chartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertIfNegative = true;
series.InvertedSolidFillColor.Color = Color.Red;

presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
```

El resultado:

![Color de relleno sólido invertido](inverted_solid_fill_color.png)

Puede habilitar la inversión para un punto mediante [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). En el siguiente ejemplo, la inversión está desactivada para la serie y activada solo para el punto seleccionado. Además, al punto se le asigna un valor negativo para que el efecto sea visible:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertedSolidFillColor.Color = Color.Red;
series.InvertIfNegative = false;

var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = negativeValue;
dataPoint.InvertIfNegative = true;

presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
```

## **Borrar el valor de un punto de datos específico**

Para dejar un punto vacío sin eliminar los demás puntos, establezca su celda de respaldo en el libro a `null`. En un gráfico de columnas, el valor trazado está disponible mediante [IChartDataPoint.YValue](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdatapoint/yvalue/). El punto de datos permanece en la misma posición de categoría, pero el gráfico trata su valor como en blanco según la configuración de valores en blanco del gráfico.

El siguiente ejemplo borra solo el segundo punto de la primera serie:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = null;

presentation.Save("clear_data_point_value.pptx", SaveFormat.Pptx);
```

Los gráficos de dispersión usan celdas X e Y separadas, y los gráficos de burbujas también usan una celda de tamaño. Borre solo la celda que representa el valor que desea eliminar. No llame a [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdatapointcollection/clear/) cuando quiera conservar los demás puntos, porque ese método elimina todos los puntos de datos de la colección.

## **Controlar la visualización de celdas vacías**

Las celdas ocultas que contienen valores son un caso distinto de las celdas vacías. Para incluir o excluir datos de filas y columnas ocultas de la hoja, consulte [Include Data from Hidden Rows and Columns](/slides/es/net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Una celda de libro vacía representa datos faltantes; una celda que contiene `0` representa un valor numérico conocido. Establezca [IChartDataCell.Value](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdatacell/value/) a `null` para dejar una celda vacía. Un cero numérico sigue siendo cero independientemente de la configuración de celdas en blanco.

Utilice [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichart/displayblanksas/) para elegir cómo el gráfico muestra las celdas vacías. Esta configuración se aplica a todo el gráfico. Cambia la forma en que se trazan los vacíos, sin rellenar la celda del libro vacía con cero o un valor interpolado.

El siguiente ejemplo autónomo crea un gráfico de líneas con una serie, borra el valor del Día 3 y guarda el mismo gráfico con cada modo. No se requiere archivo de entrada. El [IChartDataWorkbook](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdataworkbook/) usa la hoja 0, la columna 0 para las etiquetas de categoría y la columna 1 para los valores; la fila 0 contiene el nombre de la serie. Los datos finales son `10, 20, empty, 30, 40`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(0, 0, 1, "Measurements");
var series = chartData.Series.Add(seriesNameCell, chart.Type);
var values = new[] { 10, 20, 25, 30, 40 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Day {i + 1}");
    chartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Leave Day 3 genuinely empty, while retaining its category and data point.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

Cada archivo de salida almacena el modo asignado antes de guardar: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` y `empty_cells_Span.pptx`. Para guardar solo una versión, asigne el modo deseado y guarde la presentación una vez en lugar de iterar sobre los modos.

La comparación siguiente muestra los mismos datos en los tres archivos. El Día 3 está vacío en el libro en todos los casos:

![Gráficos de líneas con datos idénticos: Gap interrumpe la línea en el Día 3, Zero lleva la línea a cero y Span conecta el Día 2 con el Día 4.](display_blanks_as.png)

El efecto visible depende del tipo de gráfico. Un gráfico de líneas permite comparar fácilmente los tres modos. Los gráficos de barras y columnas no tienen línea que conectar a través de una categoría faltante, por lo que `Span` no puede producir el segmento de conexión mostrado arriba; una columna faltante y una columna de altura cero también pueden parecer iguales. De manera similar, un gráfico de dispersión solo con marcadores no tiene línea de conexión. No espere tres resultados distintos para cada tipo de gráfico; compruebe la salida para el tipo que utilice.

## **Establecer el ancho del espacio entre series**

El ancho del espacio es la distancia entre grupos adyacentes de barras o columnas, expresada como porcentaje del ancho de la barra o columna. Al igual que el solapamiento, pertenece al grupo de series padre y no a una serie individual. Establezca [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) una vez para el grupo. Un valor mayor crea más espacio entre los grupos; un valor menor los hace más densos.

El siguiente ejemplo cambia el ancho del espacio y guarda solo la presentación final:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int gapWidthPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.GapWidth = gapWidthPercent;

presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
```

El resultado:

![Ancho del espacio](gap_width.png)

## **FAQ**

**¿Qué tipos de gráficos admiten series de datos?**

Todos los tipos de gráfico representados por la enumeración [ChartType](https://reference.aspose.com/slides/es/net/aspose.slides.charts/charttype/) utilizan datos de gráfico, pero sus series no tienen todas la misma estructura de valores o configuraciones. Por ejemplo, los gráficos de categorías usan categorías y valores, los gráficos de dispersión usan valores X e Y, y los gráficos de burbujas añaden tamaños de burbuja. Utilice el método de creación de puntos de datos que coincida con el tipo de serie. Opciones como solapamiento y ancho del espacio solo se aplican a grupos de barras o columnas compatibles.

**¿Qué es un grupo de series de gráfico?**

Un [IChartSeriesGroup](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartseriesgroup/) contiene series compatibles que comparten ajustes de trazado a nivel de grupo. Un gráfico combinado puede contener más de un grupo, por lo que cambiar el grupo al que se accede a través de una serie no cambia necesariamente todas las series del gráfico.

**¿Un gráfico recién creado contiene datos predeterminados?**

Sí. Por defecto, [IShapeCollection.AddChart](https://reference.aspose.com/slides/es/net/aspose.slides/ishapecollection/addchart/) crea series, categorías y valores de muestra. Puede editar esas celdas o borrar tanto las colecciones de series como de categorías antes de añadir un conjunto de datos completamente personalizado. Una sobrecarga también puede crear un gráfico sin datos predeterminados.

**¿Cómo están conectados los objetos del gráfico a las celdas del libro?**

Los nombres de series, etiquetas de categoría y valores de puntos de datos hacen referencia a celdas en un [IChartDataWorkbook](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdataworkbook/). Cambiar una celda referenciada actualiza el elemento del gráfico correspondiente. Cuando construye datos personalizados, mantenga las filas de categorías y las filas de valores de series alineadas para que cada punto se trace bajo la categoría prevista.

**¿Cómo puedo borrar un punto en lugar de toda la serie?**

Establezca la celda de valor correspondiente a `null` para mantener la posición de categoría del punto como un punto vacío. Utilice [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdatapointcollection/clear/) solo cuando pretenda eliminar todos los puntos de esa serie. Si también elimina categorías, actualice cada serie para que sus valores permanezcan alineados con la colección de categorías.

**¿Cómo se muestran los puntos vacíos?**

El resultado depende del tipo de gráfico y de [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichart/displayblanksas/). Los gráficos compatibles pueden mostrar los vacíos como huecos, como valores cero o conectando los puntos vecinos. Elija la configuración que coincida con el significado de los datos faltantes en su presentación. Consulte [Controlar la visualización de celdas vacías](#controlar-la-visualización-de-celdas-vacías) para un ejemplo completo y una comparación visual.

**¿Cómo se formatean los valores negativos?**

Para series de barras, columnas y burbujas admitidas, habilite [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartseries/invertifnegative/) y establezca [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Puede sobrescribir el comportamiento para un punto individual con [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Estas propiedades afectan al formato, no a los valores numéricos almacenados.

**¿Qué formato prevalece cuando tanto una serie como un punto están formateados?**

El formato explícito del punto de datos tiene prioridad para ese punto. Los demás puntos siguen usando el formato explícito de la serie o, cuando el formato de la serie no está definido, el estilo y tema automáticos del gráfico. Las propiedades de grupo como solapamiento y ancho del espacio controlan el diseño y no son sobrescrituras de formato a nivel de punto.

**¿Existe un límite en la cantidad de series que puede contener un gráfico?**

Aspose.Slides no impone un límite fijo separado para la cantidad de series. En la práctica, las limitaciones del archivo de presentación, la memoria disponible, el tiempo de renderizado y la legibilidad del gráfico determinan un límite útil.

**¿Qué debo cambiar cuando las columnas están demasiado próximas o demasiado separadas?**

Establezca [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) en el grupo de series padre correspondiente. Aumente el valor para ensanchar el espacio entre los grupos, o disminúyalo para acercar los grupos.