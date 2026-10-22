---
title: Gestionar series de datos de gráficos en presentaciones en .NET
linktitle: Series de datos
type: docs
url: /es/net/chart-series/
keywords:
- series de gráfico
- solapamiento de series
- color de series
- color de categoría
- nombre de serie
- punto de datos
- espacio entre series
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprende a gestionar series de gráficos, puntos de datos, celdas del libro de trabajo, formato, solapamiento, ancho del espacio y valores negativos en presentaciones con C#."
---
## **Descripción general**

Un gráfico puede almacenar sus valores trazados en celdas del libro de trabajo o directamente como literales numéricos. Un [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) representa un conjunto de valores relacionados, y cada [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) representa un punto en esa serie. Los objetos [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) proporcionan las etiquetas o valores de agrupación compartidos por las series. En los gráficos creados con datos predeterminados, los nombres de series, categorías y valores de punto utilizan objetos [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) del libro de trabajo del gráfico.

Para un gráfico de categorías típico, el libro de trabajo predeterminado usa la fila 0 para los nombres de series, la columna 0 para los nombres de categorías y el resto de celdas para los valores de series. Los índices de hoja, fila y columna que se pasan a [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) son basados en cero. Esta disposición es útil cuando se crea un gráfico con datos predeterminados, pero no debe asumirse que cada gráfico existente lo usa. Para una presentación cargada, inspeccione las celdas referenciadas por las series, categorías y puntos de datos antes de modificar los valores del libro de trabajo.

Los ajustes del gráfico tienen tres ámbitos diferentes:

- Ajustes a nivel de serie, como [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/), proporcionan la apariencia predeterminada para todos los puntos de una serie.
- Ajustes a nivel de punto de datos, como [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/), anulan la apariencia de la serie para un punto concreto.
- Los ajustes de grupo se aplican a series compatibles que pertenecen al mismo [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/). Acceda al grupo mediante [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) cuando necesite establecer opciones como solapamiento o ancho del espacio.

Cuando no se define un relleno explícito de punto o de serie, el estilo y el tema del gráfico determinan la apariencia automática. Cuando existen tanto el formato de la serie como el del punto, el formato del punto tiene prioridad para ese punto.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Establecer valores de series usando literales numéricos**

Utilice literales numéricos cuando los valores de la serie provengan de datos o cálculos de la aplicación y no necesiten referencias a celdas de la hoja. Establezca [DataSourceTypeForValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforvalues/) en [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) antes de asignar a cada [Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/value/) del punto mediante [AsLiteralDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/idoublechartvalue/asliteraldouble/).

La configuración de la colección controla el tipo de origen de todos los valores de punto en esa serie. El [Value.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ibasechartvalue/datasourcetype/) de cada punto indica el tipo seleccionado; cámbielo mediante la configuración de la colección. Con `Worksheet`, utilice [AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/isinglecellchartvalue/ascell/) para acceder a la celda referenciada. Con `DoubleLiterals`, use `AsLiteralDouble` para leer o escribir el número directamente.

El siguiente ejemplo crea un gráfico de columnas con series y categorías predeterminadas, y luego asigna valores calculados de 10, 20, etc., a los puntos existentes de su primera serie. Guarda la presentación, la vuelve a abrir y muestra los valores almacenados.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

series.DataPoints.DataSourceTypeForValues = DataSourceType.DoubleLiterals;
for (var i = 0; i < series.DataPoints.Count; i++)
{
    series.DataPoints[i].Value.AsLiteralDouble = (i + 1) * 10;
}

presentation.Save("numeric_literals.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("numeric_literals.pptx");
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedChart = (IChart)reopenedSlide.Shapes[0];
var reopenedSeries = reopenedChart.ChartData.Series[0];
foreach (var point in reopenedSeries.DataPoints)
{
    Console.WriteLine(point.Value.AsLiteralDouble);
}
```

El tipo de origen del valor del punto está separado de [IChartData.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/datasourcetype/), que identifica la configuración interna o externa del libro de trabajo del gráfico. Utilizar literales numéricos no elimina, por sí mismo, el libro de trabajo incrustado. En este ejemplo, el libro sigue disponible para las etiquetas de categoría, los nombres de serie y las demás series. Consulte [Chart Workbook](/slides/es/net/chart-workbook/) para la gestión del libro de trabajo.

Para gráficos de dispersión y burbuja, establezca [DataSourceTypeForXValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforxvalues/) y [DataSourceTypeForYValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforyvalues/) para elegir las fuentes de [XValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/xvalue/) y [YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/). Los gráficos de burbuja también utilizan [DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforbubblesizes/) para [BubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/bubblesize/). Establezca cada fuente aplicable en `DoubleLiterals` antes de asignar números mediante la propiedad `AsLiteralDouble` correspondiente.

## **Establecer el solapamiento de series del gráfico**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) indica cuánto se solapan barras o columnas en un gráfico 2D, de -100 a 100 porcentaje. Es una proyección de solo lectura del ajuste en el grupo de series padre. Establezca [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) para actualizar todas las series compatibles en ese grupo. Esta opción se aplica a los tipos de gráfico que muestran barras o columnas agrupadas; no afecta a los grupos de series no relacionados en un gráfico combinado.

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

![The series overlap](series_overlap.png)

## **Cambiar el color de relleno de la serie**

Utilice [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) para definir el relleno predeterminado de una serie completa. Si un punto ya tiene un relleno explícito, su configuración [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) anula el relleno de la serie para ese punto.

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

![The color of the series](series_color.png)

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

También puede actualizar la celda ya referenciada por [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/). Este enfoque evita suponer una fila y columna determinadas en un gráfico existente:

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

![The series name](series_name.png)

### **Crear una serie con un nombre a partir de varias celdas**

Un nombre de serie compuesto es útil cuando el nombre del producto y el período del informe se almacenan en celdas distintas del libro. Por ejemplo, puede combinar `Product A` en B1 y `2026` en C1 en un único nombre de serie manteniendo ambos componentes vinculados a sus celdas origen.

Utilice [IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) para obtener el rango de nombres y, a continuación, pase esa colección a [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/). El argumento `skipHiddenCells` controla si se incluyen celdas ocultas: `true` las excluye, `false` las incluye. Este ejemplo usa `false` para incluir todas las celdas del rango de nombres.

El siguiente ejemplo crea una presentación con una serie y dos puntos de datos. Las celdas B1:C1 suministran solo el nombre de la serie; A2:A3 suministran las etiquetas de categoría, y B2:B3 los valores numéricos.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
chart.HasLegend = true;

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// Estas dos celdas suministran el nombre de la serie.
workbook.GetCell(0, 0, 1, "Product A");
workbook.GetCell(0, 0, 2, "2026");
var nameCells = workbook.GetCellCollection("Sheet1!$B$1:$C$1", skipHiddenCells: false);
var series = chart.ChartData.Series.Add(nameCells, ChartType.ClusteredColumn);

// Celdas separadas suministran las categorías y los puntos de datos numéricos.
var northCategory = workbook.GetCell(0, 1, 0, "North");
var southCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(northCategory);
chart.ChartData.Categories.Add(southCategory);
var northValue = workbook.GetCell(0, 1, 1, 120);
var southValue = workbook.GetCell(0, 2, 1, 150);
series.DataPoints.AddDataPointForBarSeries(northValue);
series.DataPoints.AddDataPointForBarSeries(southValue);

presentation.Save("composite_series_name.pptx", SaveFormat.Pptx);
```

El nombre de serie resultante es `Product A 2026`, con un espacio entre los dos valores de celda. La leyenda lo muestra como una única entrada para ambas columnas. La imagen a continuación se generó a partir de la presentación guardada:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Obtener el color automático de relleno de la serie**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) devuelve el color calculado a partir del índice de la serie y el estilo del gráfico. Este es el color usado cuando el relleno de la serie no se ha definido explícitamente. Llamar al método lee el color calculado; no asigna un nuevo relleno.

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

Los colores exactos dependen del estilo y el tema del gráfico.

## **Establecer el color de relleno invertido para una serie del gráfico**

Para series de barras, columnas y burbujas, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) puede mostrar valores negativos con un relleno diferente. Establezca el relleno regular de la serie a sólido, habilite la inversión y asigne el color del valor negativo mediante [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Los números negativos permanecen sin cambios en el libro; solo cambia su color de visualización.

El siguiente ejemplo sustituye los datos predeterminados del gráfico por una serie. La fila 0 de la hoja contiene el nombre de la serie, la columna 0 los nombres de categoría y la columna 1 los valores:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

Puede habilitar la inversión para un punto mediante [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). En el siguiente ejemplo, la inversión está desactivada para la serie y activada solo para el punto seleccionado. Ese punto también recibe un valor negativo para que el efecto sea visible:

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

Para dejar vacío un punto sin eliminar los demás, establezca su celda de respaldo del libro en `null`. En un gráfico de columnas, el valor trazado está disponible mediante [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/). El punto de datos permanece en la misma posición de categoría, pero el gráfico trata su valor como vacío según la configuración de valores en blanco del gráfico.

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

Los gráficos de dispersión usan celdas X y Y separadas, y los de burbuja también usan una celda de tamaño. Borre solo la celda que representa el valor que desea eliminar. No llame a [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) cuando quiera conservar los demás puntos, ya que ese método elimina todos los puntos de datos de la colección.

## **Controlar la visualización de celdas vacías**

Las celdas ocultas que contienen valores son un caso distinto de las celdas vacías. Para incluir o excluir datos de filas y columnas ocultas de la hoja, consulte [Include Data from Hidden Rows and Columns](/slides/es/net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Una celda de libro vacía representa datos ausentes; una celda que contiene `0` representa un valor numérico conocido. Establezca [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) en `null` para dejarla vacía. Un cero numérico sigue siendo cero sin importar la configuración de celdas vacías.

Utilice [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) para elegir cómo muestra el gráfico las celdas vacías. Este ajuste se aplica a todo el gráfico. Cambia la forma en que se trazan los vacíos, sin rellenar la celda del libro con cero o con un valor interpolado.

El siguiente ejemplo autónomo crea un gráfico de líneas con una serie, elimina el valor del Día 3 y guarda el mismo gráfico con cada modo. No se necesita archivo de entrada. El [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) usa la hoja 0, columna 0 para las etiquetas de categoría y columna 1 para los valores; la fila 0 contiene el nombre de la serie. Los datos finales son `10, 20, empty, 30, 40`.

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

// Dejar el Día 3 realmente vacío, manteniendo su categoría y punto de datos.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

Cada archivo de salida almacena el modo asignado antes de guardar: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` y `empty_cells_Span.pptx`. Para guardar solo una versión, asigne el modo deseado y guarde la presentación una única vez en lugar de iterar sobre los modos.

La comparación a continuación muestra los mismos datos en los tres archivos. El Día 3 está vacío en el libro en todos los casos:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

El efecto visible depende del tipo de gráfico. Un gráfico de líneas permite comparar fácilmente los tres modos. Los gráficos de barras y columnas no tienen línea que conectar una categoría faltante, por lo que `Span` no puede producir el segmento de conexión mostrado arriba; una columna ausente y una columna de altura cero pueden parecer similares. De manera análoga, un gráfico de dispersión solo con marcadores no tiene línea de conexión. No espere tres resultados distintos para cada tipo de gráfico; verifique la salida para el tipo que utilice.

## **Establecer el ancho del espacio entre series**

El ancho del espacio es la distancia entre grupos de barras o columnas adyacentes, expresada como porcentaje del ancho de la barra o columna. Al igual que el solapamiento, pertenece al grupo de series padre y no a una sola serie. Establezca [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) una vez para el grupo. Un valor mayor crea más espacio entre los grupos; un valor menor los vuelve más densos.

El siguiente ejemplo modifica el ancho del espacio y guarda solo la presentación final:

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

![The gap width](gap_width.png)

## **Preguntas frecuentes**

**¿Qué tipos de gráfico admiten series de datos?**

Todos los tipos de gráfico representados por la enumeración [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) utilizan datos del gráfico, pero sus series no comparten la misma estructura de valores ni los mismos ajustes. Por ejemplo, los gráficos de categorías usan categorías y valores, los de dispersión usan valores X y Y, y los de burbuja añaden tamaños de burbuja. Use el método de creación de puntos que corresponda al tipo de serie. Opciones como solapamiento y ancho del espacio solo se aplican a grupos de barras o columnas compatibles.

**¿Qué es un grupo de series de gráfico?**

Un [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) contiene series compatibles que comparten ajustes de trazado a nivel de grupo. Un gráfico combinado puede contener más de un grupo, por lo que cambiar el grupo alcanzado a través de una serie no altera necesariamente todas las series del gráfico.

**¿Un gráfico recién creado contiene datos predeterminados?**

Sí. Por defecto, [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) crea series, categorías y valores de muestra. Puede editar esas celdas o borrar tanto las colecciones de series como de categorías antes de añadir un conjunto de datos completamente personalizado. Una sobrecarga también puede crear un gráfico sin datos predeterminados.

**¿Cómo están conectados los objetos del gráfico a las celdas del libro?**

Los nombres de series, las etiquetas de categoría y los valores de los puntos de datos hacen referencia a celdas en un [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/). Cambiar una celda referenciada actualiza el elemento correspondiente del gráfico. Cuando construya datos personalizados, mantenga alineadas las filas de categorías y las filas de valores de series para que cada punto se trace bajo la categoría prevista.

**¿Cómo borro un punto en lugar de toda la serie?**

Establezca la celda de valor correspondiente en `null` para conservar la posición de categoría del punto como vacío. Use [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) solo cuando pretenda eliminar todos los puntos de esa serie. Si también elimina categorías, actualice cada serie para que sus valores sigan alineados con la colección de categorías.

**¿Cómo se muestran los puntos vacíos?**

El resultado depende del tipo de gráfico y de [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/). Los gráficos compatibles pueden mostrar vacíos como huecos, como valores cero o conectando puntos vecinos. Elija la configuración que coincida con el significado de los datos ausentes en su presentación. Consulte [Controlar la visualización de celdas vacías](#controlar-la-visualización-de-celdas-vacías) para un ejemplo completo y una comparación visual.

**¿Cómo se formatean los valores negativos?**

Para series de barras, columnas y burbujas compatibles, habilite [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) y establezca [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Puede anular el comportamiento para un punto individual con [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Estas propiedades afectan el formato, no los valores numéricos almacenados.

**¿Qué formato prevalece cuando tanto una serie como un punto están formateados?**

El formato explícito del punto de datos tiene prioridad para ese punto. Los demás puntos continúan usando el formato explícito de la serie o, cuando no hay formato de serie definido, el estilo y tema automático del gráfico. Las propiedades de grupo como solapamiento y ancho del espacio controlan la disposición y no sobrescriben el formato a nivel de punto.

**¿Existe un límite en la cantidad de series que puede contener un gráfico?**

Aspose.Slides no impone un límite fijo independiente para la cantidad de series. En la práctica, las restricciones del archivo de presentación, la memoria disponible, el tiempo de renderizado y la legibilidad del gráfico determinan un límite práctico.

**¿Qué debo ajustar cuando las columnas están demasiado próximas o muy separadas?**

Establezca [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) en el grupo de series padre correspondiente. Aumente el valor para ensanchar el espacio entre los grupos, o disminúyalo para acercarlos.