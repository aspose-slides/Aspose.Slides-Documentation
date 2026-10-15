---
title: Personalizar ejes de gráficos en presentaciones en .NET
linktitle: Eje de gráfico
type: docs
url: /es/net/chart-axis/
keywords:
- eje de gráfico
- eje vertical
- eje horizontal
- personalizar eje
- manipular eje
- gestionar eje
- propiedades del eje
- valor máximo
- valor mínimo
- línea del eje
- formato de fecha
- título del eje
- posición del eje
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Descubra cómo usar Aspose.Slides para .NET para personalizar los ejes de los gráficos en presentaciones de PowerPoint para informes y visualizaciones."
---
## **Visión general**

Este artículo explica cómo personalizar los ejes de los gráficos con Aspose.Slides para .NET. Cubre valores calculados de los ejes, cambiar filas y columnas del gráfico, visibilidad del eje, intervalos de etiquetas de categoría y marcas de graduación, categorías de fechas y formateo, rotación del título, posicionamiento del eje, unidades de visualización y escalado logarítmico.

## **Obtener los valores máximos en el eje vertical de los gráficos**

Cree una [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) y añada un gráfico de áreas con datos predeterminados. Llame a [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) antes de leer los valores calculados del eje para que el diseño del gráfico esté actualizado.

Lea [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) y [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) para los límites del eje, y [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) y [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) para los intervalos de marcas. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) y [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) proporcionan escalas de unidades de tiempo, relevantes para ejes de fechas. El ejemplo almacena estos valores en variables locales y guarda el gráfico.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
chart.ValidateChartLayout();

var maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
var minValue = chart.Axes.VerticalAxis.ActualMinValue;

var majorUnit = chart.Axes.VerticalAxis.ActualMajorUnit;
var minorUnit = chart.Axes.VerticalAxis.ActualMinorUnit;

var majorUnitScale = chart.Axes.VerticalAxis.ActualMajorUnitScale;
var minorUnitScale = chart.Axes.VerticalAxis.ActualMinorUnitScale;

presentation.Save("AxisValues_out.pptx", SaveFormat.Pptx);
```

## **Intercambiar los datos entre los ejes**

Use [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) para intercambiar los roles de series y categorías en los datos del gráfico. Cada categoría anterior se convierte en una serie, y cada serie anterior se convierte en una categoría. Esto cambia la forma en que se agrupan los datos; no intercambia los ejes horizontal y vertical. El ejemplo utiliza [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) para vincular los datos predeterminados a `Sheet1!A1:D5`, incluida la fila de encabezado y la columna de categoría, antes de cambiar filas y columnas. Guarda un gráfico con cuatro series y tres categorías.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

chart.ChartData.SetRange("Sheet1!A1:D5");
chart.ChartData.SwitchRowColumn();

presentation.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
```

## **Invertir el orden de trazado de un eje**

Use [IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) para invertir un eje de categoría o de valores. Por ejemplo, un gráfico de barras horizontal puede mostrar las fases del proyecto de arriba a abajo en el mismo orden que la hoja de cálculo: Planificación, Desarrollo, Pruebas. Invertir un eje cambia la dirección del trazado; no ordena ni reorganiza los datos del libro. En comparación, [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) intercambia los roles de series y categorías.

El siguiente ejemplo crea un gráfico de barras horizontal con tres fases y una serie. Guarda una presentación con tres diapositivas: orden normal, categorías invertidas y valores invertidos. Cada copia utiliza el mismo conjunto de datos, y solo un eje se invierte en cada copia.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredBar, 50, 40, 620, 320);
chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredBar);
var stages = new[] { "Planning", "Development", "Testing" };
var values = new[] { 10, 30, 20 };
for (var i = 0; i < stages.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, stages[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

// Diapositiva 2: mostrar la primera categoría en la parte superior.
var categorySlide = presentation.Slides.AddClone(slide);
var categoryChart = (IChart)categorySlide.Shapes[0];
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// Mantener el eje de valores horizontal en la parte inferior.
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// Diapositiva 3: invertir solo la escala numérica horizontal.
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

Invertir un eje también puede mover el eje perpendicular al lado opuesto del trazado. [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) controla dónde el otro eje cruza el eje que se está configurando. En la diapositiva 2, establecerlo en `Maximum` en el eje de categoría invertido mantiene el eje de valores horizontal en la parte inferior. Para un punto de cruce específico, use [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Verifique la configuración de cruce al cambiar la dirección, sobre todo si el gráfico ya tiene un punto de cruce personalizado. Restablezca `IsPlotOrderReversed` a `false` para volver a la dirección de trazado normal; la configuración de cruce es independiente.

| Orden normal (diapositiva 1) | Categorías invertidas (diapositiva 2) | Valores invertidos (diapositiva 3) |
| --- | --- | --- |
| ![Gráfico de barras horizontal con orden normal de eje de categoría y valor](axis-order-normal.png) | ![Gráfico de barras horizontal con categorías mostradas de arriba a abajo](axis-order-categories-reversed.png) | ![Gráfico de barras horizontal con eje de valor invertido y cero a la derecha](axis-order-values-reversed.png) |
| Las categorías van de abajo a arriba; los valores aumentan de izquierda a derecha. | Planificación, Desarrollo y Pruebas van de arriba a abajo. Los valores y el orden de filas del libro de trabajo no cambian. | Las categorías conservan su orden normal; los valores aumentan de derecha a izquierda. El eje de categoría cruza en cero a la derecha. |

## **Desactivar el eje vertical para gráficos de líneas**

Establezca [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) a `false` en el eje vertical para ocultarlo. El ejemplo crea un gráfico de líneas con datos predeterminados y lo guarda con el eje vertical oculto.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.VerticalAxis.IsVisible = false;

presentation.Save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
```

## **Desactivar el eje horizontal para gráficos de líneas**

Establezca [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) a `false` en el eje horizontal para ocultarlo. El ejemplo crea un gráfico de líneas con datos predeterminados y lo guarda con el eje horizontal oculto.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.HorizontalAxis.IsVisible = false;

presentation.Save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
```

## **Cambiar un eje de categoría**

Establezca [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) para elegir un eje de categoría de fecha o de texto. Este ejemplo requiere `ExistingChart.pptx`, con un gráfico como la primera forma en la primera diapositiva y celdas de categoría que contienen valores numéricos de fecha de Excel. Cambia el eje horizontal a un eje de fecha. Establecer [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) a `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) a `1` y [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) a months coloca marcas mayores a intervalos de un mes.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

var chart = (IChart) slide.Shapes[0];
chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
chart.Axes.HorizontalAxis.MajorUnit = 1;
chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
```

## **Controlar intervalos de etiquetas del eje de categoría**

Cuando un gráfico tiene muchas categorías, reduzca el número de etiquetas de eje visibles sin eliminar categorías ni puntos de datos. Establezca [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) a `false`, luego establezca [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) al intervalo de categoría deseado. Para categorías de texto en su orden normal, el recuento comienza en la primera categoría:

| Intervalo | Etiquetas mostradas en el ejemplo |
| --- | --- |
| `1` | Categoría 1, Categoría 2, Categoría 3, ... Categoría 24 |
| `2` | Categoría 1, Categoría 3, Categoría 5, ... Categoría 23 |
| `3` | Categoría 1, Categoría 4, Categoría 7, ... Categoría 22 |

Un intervalo de `3` muestra cada tercera etiqueta, dejando dos etiquetas ocultas entre las mostradas. No elimina las columnas correspondientes. El espaciado automático elige un intervalo basándose en el espacio disponible; no muestra necesariamente todas las etiquetas.

Las marcas de graduación tienen controles independientes. Establezca [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) a `false` y use [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) para fijar su intervalo. Por ejemplo, `1` mantiene una marca de graduación en cada intervalo de categoría mientras las etiquetas aparecen solo cada tercera categoría. Establezca [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) en un estilo visible para ver el resultado. Volver a establecer cualquiera de las propiedades de espaciado automático a `true` permite que el gráfico elija ese intervalo nuevamente.

El siguiente ejemplo autocontenido crea 24 categorías y una serie, luego guarda tres diapositivas en `CategoryAxisIntervals.pptx`: espaciado automático, espaciado manual de etiquetas con marcas de graduación independientes y espaciado automático restaurado. Las dos copias conservan los datos originales del gráfico. No se requiere una presentación de entrada. El texto de la etiqueta horizontal facilita la visualización de la densidad.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.HasLegend = false;
chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredColumn);
for (var i = 0; i < 24; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, 10 + i % 6 * 5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.CategoryAxisType = CategoryAxisType.Text;
axis.TextFormat.TextBlockFormat.RotationAngle = 0;
axis.TextFormat.PortionFormat.FontHeight = 12;
axis.MajorTickMark = TickMarkType.Outside;
axis.IsAutomaticTickLabelSpacing = true;
axis.IsAutomaticTickMarksSpacing = true;

// Diapositiva 2: mostrar cada tercera etiqueta, pero mantener una marca de graduación para cada categoría.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// Diapositiva 3: permitir que el gráfico elija ambos intervalos de nuevo.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**Espaciado automático (diapositiva 1):** En esta representación, se muestra cada segunda etiqueta de categoría y se ajusta a dos líneas. El resultado automático puede variar según el tamaño del gráfico, las fuentes y el renderizador.

![Espaciado automático de etiquetas de categoría con las 24 columnas visibles](category-axis-automatic.png)

**Espaciado manual (diapositiva 2):** Cada tercera etiqueta se muestra en una línea, mientras las marcas de graduación permanecen en cada intervalo de categoría. Las 24 columnas, incluidas las que no tienen etiquetas, siguen visibles con los mismos valores. La diapositiva 3 restaura la apariencia automática mostrada arriba.

![Intervalo manual de etiquetas de categoría de tres con las 24 columnas visibles](category-axis-manual.png)

### **Elegir el eje y el intervalo correctos**

Utilice este intervalo de recuento de categorías para un eje de categoría de texto, como el eje de categoría de un gráfico de columnas, líneas, áreas o barras. En un gráfico de columnas, es el eje horizontal. En un gráfico de barras horizontal, el eje de categoría es vertical, por lo que aplique estos ajustes a [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). El espaciado de marcas de graduación también se aplica a un eje de serie en los gráficos que lo tienen.

No utilice el espaciado de etiquetas de categoría para establecer la escala numérica de un eje de valores. En un eje de valores, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) especifica una diferencia en los valores: por ejemplo, una unidad mayor de `10` produce marcas en 0, 10, 20, etc., cuando el eje comienza en cero. Un intervalo de etiqueta de categoría de `3` cuenta posiciones de categoría, sin importar sus valores de datos. Los gráficos de dispersión y burbuja utilizan ejes de valores en lugar de un eje de categoría de texto. Para un eje de fecha, use unidades mayores basadas en el tiempo y escalas como se describe en [Change a Category Axis](#change-a-category-axis).

## **Establecer el formato de fecha para los valores del eje de categoría**

El ejemplo sustituye los datos predeterminados del gráfico por cuatro valores anuales. Las fechas se almacenan como números de serie de OLE Automation en la primera hoja de cálculo (índice `0`). Establezca [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) a un eje de fecha, desactive [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) y asigne `yyyy` a [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) para que las etiquetas de categoría muestren años de cuatro dígitos independientemente del formato de la celda.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
for (var i = 0; i < 4; i++)
{
    var date = new DateTime(2015 + i, 1, 1);
    var categoryCell = workbook.GetCell(0, i + 1, 0, date.ToOADate());
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, i + 1);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.HorizontalAxis.NumberFormat = "yyyy";

presentation.Save("DateAxisFormat.pptx", SaveFormat.Pptx);
```

## **Establecer un ángulo de rotación para el título del eje del gráfico**

Active [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) en el eje vertical, proporcione el texto del título y establezca [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) para rotar el título. El ángulo se mide en grados; este ejemplo guarda un gráfico de columnas con su título del eje de valores rotado 90 grados.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("Value");
chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

presentation.Save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
```

## **Establecer la posición del eje en un eje de categoría o de valor**

Utilice [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) para controlar si el eje de valores cruza el eje de categoría entre categorías o en las marcas de categoría. Esta propiedad se aplica a los ejes de categoría. El ejemplo lo establece en `true` en el eje de categoría horizontal de un gráfico de columnas y guarda el resultado.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

presentation.Save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
```

## **Establecer la unidad de visualización en un eje de valor del gráfico**

Establezca [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) para escalar las etiquetas de un eje de valores sin cambiar los datos subyacentes. Con [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) configurado a `Millions`, un valor de 60 000 000 se muestra como 60. El ejemplo crea un gráfico de columnas y aplica la unidad de visualización de millones a su eje vertical.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

## **Configurar un eje de valor logarítmico**

Un eje de valor logarítmico resulta útil cuando los valores positivos abarcan varios órdenes de magnitud. Por ejemplo, un servicio podría recibir 10, 100, 1 000, 10 000 y 100 000 solicitudes en cinco periodos. En una escala lineal, los valores menores aparecen muy juntos cerca de cero. Una escala logarítmica facilita la comparación de su crecimiento relativo: las mismas distancias representan las mismas relaciones en vez de las mismas diferencias.

Establezca [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) a `true` en el eje de valores y use [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) para elegir la base. Esto cambia la forma en que se muestran los valores existentes; no modifica los datos ni añade una línea de tendencia logarítmica. Una línea de tendencia representa una relación ajustada en los datos y es una característica separada.

### **Elegir el eje de valor y la base**

Para un gráfico de líneas o de columnas, el eje de valor es [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Para un gráfico de barras horizontal, es [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). Los gráficos de dispersión y burbuja tienen dos ejes de valores, por lo que elija el eje horizontal para los valores X, el eje vertical para los valores Y, o ambos. No aplique escalado logarítmico a un eje de categoría.

La base logarítmica predeterminada es `10`. Para gráficos PPTX, use una base entre `2` y `1000`, inclusive; también se admiten bases fraccionarias como `2.5`. Con la base `10`, las potencias sucesivas como 10, 100, 1 000 y 10 000 están igualmente espaciadas.

### **Comparar el escalado lineal y logarítmico**

El siguiente ejemplo autocontenido crea un gráfico de líneas con los cinco recuentos de solicitudes en la primera diapositiva, luego clona esa diapositiva y habilita un eje de valor logarítmico base 10 en la segunda. Ambas diapositivas conservan los mismos datos.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 30, 40, 660, 200);

chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
var values = new double[] { 10, 100, 1000, 10000, 100000 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Period {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Mantener la primera diapositiva lineal y cambiar solo la escala del eje de valores de la copia.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Escala lineal (diapositiva 1):** Las distancias verticales iguales representan diferencias iguales en los recuentos de solicitudes. El valor más grande domina el gráfico, dificultando la distinción de los valores menores.

![Gráfico de líneas en PowerPoint que muestra cinco recuentos de solicitudes en un eje de valor lineal](value-axis-linear.png)

**Escala logarítmica (diapositiva 2):** Las distancias verticales iguales representan relaciones iguales. Cada periodo tiene diez veces más solicitudes que el anterior, por lo que los puntos forman una línea recta ascendente en la escala base 10. Las etiquetas del eje siguen mostrando los recuentos originales de solicitudes.

![Los mismos cinco recuentos de solicitudes en PowerPoint en un eje de valor logarítmico base 10](value-axis-logarithmic.png)

### **Gestionar valores cero y negativos**

Una escala logarítmica solo puede mostrar valores estrictamente positivos. Verifique los datos antes de activarla. Si los valores cero o negativos son significativos, mantenga una escala lineal o muéstrelos por separado. Si excluir esos valores es apropiado para el análisis, explique la omisión. No los reemplace silenciosamente por números positivos pequeños, ya que eso alteraría el significado de los datos. Cualquier mínimo o máximo configurado manualmente para un eje logarítmico también debe ser positivo.

## **Preguntas frecuentes**

**¿Cómo puedo establecer el valor en el que un eje cruza al otro (cruce del eje)?**

Utilice [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) para seleccionar el comportamiento del cruce. Para especificar un valor de cruce numérico, establezca [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Estos ajustes le permiten mover el cruce del eje a una línea base adecuada.

**¿Cómo puedo posicionar las etiquetas de marcas respecto al eje?**

Establezca [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) usando [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo` o `None`. Para controlar las propias marcas de graduación, use [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) o [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/); estos son independientes de la posición de las etiquetas.