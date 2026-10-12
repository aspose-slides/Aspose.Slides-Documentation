---
title: Gestionar etiquetas de datos de gráficos en presentaciones en .NET
linktitle: Etiqueta de datos
type: docs
url: /es/net/chart-data-label/
keywords:
- gráfico
- etiqueta de datos
- precisión de datos
- porcentaje
- distancia de la etiqueta
- ubicación de la etiqueta
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a añadir y dar formato a las etiquetas de datos de los gráficos en presentaciones de PowerPoint usando Aspose.Slides para .NET para diapositivas más atractivas."
---
## **Introducción**

Las etiquetas de datos muestran información sobre series del gráfico y puntos de datos individuales, ayudando a los lectores a identificar valores y comprender el gráfico. Este artículo explica cómo dar formato a los valores, mostrar porcentajes, leer el texto de la etiqueta, controlar etiquetas más allá del máximo del eje, ajustar el espaciado de las etiquetas del eje de categorías y posicionar las etiquetas de los gráficos circulares.

## **Establecer la precisión de los datos en las etiquetas de datos del gráfico**

Utilice [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) para dar formato a los valores de la serie. Este ejemplo crea un gráfico de líneas con datos predeterminados, muestra su tabla de datos y habilita las etiquetas de valor para la primera serie. El formato `#,##0.00` muestra un separador de miles y dos decimales sin cambiar los valores subyacentes.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
chart.HasDataTable = true;

var series = chart.ChartData.Series[0];
series.NumberFormatOfValues = "#,##0.00";
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
```

## **Mostrar el porcentaje como etiquetas**

Para un gráfico de columnas apiladas, calcule cada valor como porcentaje del total de su categoría y asigne el texto a [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). Este ejemplo utiliza los datos predeterminados del gráfico y muestra los porcentajes con dos decimales en una fuente de 8 puntos. Las categorías con un total de cero se omiten para evitar la división por cero. Recalcule el texto personalizado de la etiqueta si los datos del gráfico cambian.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);

var categoryTotals = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        var series = chart.ChartData.Series[i];
        var pointValue = Convert.ToDouble(series.DataPoints[k].Value.Data);
        categoryTotals[k] += pointValue;
    }
}

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    var series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        var label = series.DataPoints[j].Label;
        if (categoryTotals[j] == 0)
        {
            continue;
        }

        var pointValue = Convert.ToDouble(series.DataPoints[j].Value.Data);
        var dataPointPercent = (pointValue / categoryTotals[j]) * 100;

        var portion = new Portion();
        portion.Text = string.Format("{0:F2} %", dataPointPercent);
        portion.PortionFormat.FontHeight = 8f;

        label.TextFrameForOverriding.Text = "";

        var paragraph = label.TextFrameForOverriding.Paragraphs[0];
        paragraph.Portions.Add(portion);

        label.DataLabelFormat.ShowValue = true;
        label.DataLabelFormat.ShowSeriesName = false;
        label.DataLabelFormat.ShowPercentage = false;
        label.DataLabelFormat.ShowLegendKey = false;
        label.DataLabelFormat.ShowCategoryName = false;
        label.DataLabelFormat.ShowBubbleSize = false;
    }
}

presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **Establecer el signo de porcentaje en las etiquetas de datos del gráfico**

Cuando los valores se almacenan como fracciones, utilice [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) para mostrarlos como porcentajes. Establezca [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) a `false` para aplicar el formato de la etiqueta independientemente de las celdas de origen.

Este ejemplo crea un gráfico de columnas apiladas al 100 % con series rojas y azules en cuatro categorías. Cada par de valores suma 1. El formato de etiqueta `0.0%` muestra 0.30 como 30.0 %, mientras que el eje vertical usa dos decimales. Ambas series utilizan texto de etiqueta blanco de 10 puntos.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
int worksheetIndex = 0;
for (int i = 0; i < 4; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

string[] seriesNames = { "Reds", "Blues" };
Color[] seriesColors = { Color.Red, Color.Blue };
double[,] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

for (int i = 0; i < seriesNames.Length; i++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, i + 1, seriesNames[i]);
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);
    for (int j = 0; j < 4; j++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, j + 1, i + 1, values[i, j]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColors[i];

    var labelFormat = series.Labels.DefaultDataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = false;
    labelFormat.NumberFormat = "0.0%";
    labelFormat.TextFormat.PortionFormat.FontHeight = 10;
    labelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
}

presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **Leer el texto real de las etiquetas de datos**

Utilice [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) para obtener el texto generado por la configuración de una etiqueta de datos. Esto es útil al extraer etiquetas para informes, buscar contenido en la presentación o validar gráficos generados. En el ejemplo siguiente, el [formato de etiqueta de datos](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) predeterminado combina el nombre de cada categoría, el nombre de la serie y el valor. Un punto formatea su valor como porcentaje y otro utiliza texto personalizado de [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Q1"));
chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Q2"));

var north = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "North"), chart.Type);
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 0.25));
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 0.75));

var south = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "South"), chart.Type);
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 0.40));
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 0.60));

foreach (var series in chart.ChartData.Series)
{
    var format = series.Labels.DefaultDataLabelFormat;
    format.ShowCategoryName = true;
    format.ShowSeriesName = true;
    format.ShowValue = true;
}

north.Labels[1].DataLabelFormat.IsNumberFormatLinkedToSource = false;
north.Labels[1].DataLabelFormat.NumberFormat = "0%";
south.Labels[0].TextFrameForOverriding.Text = "Reviewed";

foreach (var series in chart.ChartData.Series)
{
    foreach (var point in series.DataPoints)
    {
        var label = point.Label;
        if (!label.IsVisible)
        {
            continue;
        }

        Console.WriteLine($"Value: {point.Value.Data}; label: {label.GetActualLabelText()}");
    }
}
```

El número almacenado en un punto de datos sigue siendo `0.75`, incluso cuando su etiqueta muestra `75%` junto con los nombres de categoría y serie. El texto personalizado sustituye al texto de etiqueta generado. [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) devuelve la cadena de etiqueta resultante en ambos casos. Compruebe [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) por separado, como se muestra arriba, cuando solo quiera extraer etiquetas visibles.

## **Controlar las etiquetas de datos más allá del máximo del eje**

Cuando limita manualmente el rango de un eje, algunos puntos de datos pueden superar su máximo. Utilice [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) para decidir si se muestran sus etiquetas de datos. Esta configuración cambia la visibilidad de la etiqueta; no modifica el rango del eje ni los valores subyacentes.

El ejemplo siguiente crea un gráfico de columnas agrupadas 2D con valores de 60 y 120. Establece [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) a `false` y [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) a 100 en el eje vertical. La primera diapositiva permite etiquetas más allá del máximo; una copia de esa diapositiva las desactiva. Ambas diapositivas se guardan en `DataLabelsOverMaximum.pptx`.

Habilite las etiquetas de valor con [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). La configuración a nivel de gráfico no habilita la visualización de valores por sí sola ni anula la desactivación de la visualización de valores de una etiqueta individual. Este ejemplo habilita los valores para toda la serie y utiliza [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) para colocar las etiquetas en el extremo exterior de cada columna.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;

var firstCategory = workbook.GetCell(0, 1, 0, "Within range");
var secondCategory = workbook.GetCell(0, 2, 0, "Above maximum");

chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);

var seriesName = workbook.GetCell(0, 0, 1, "Values");
var series = chart.ChartData.Series.Add(seriesName, chart.Type);

var firstValue = workbook.GetCell(0, 1, 1, 60);
var secondValue = workbook.GetCell(0, 2, 1, 120);

series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);

series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;

chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 100;
chart.ShowDataLabelsOverMaximum = true;

var secondSlide = presentation.Slides.AddClone(slide);
var secondChart = (IChart)secondSlide.Shapes[0];
secondChart.ShowDataLabelsOverMaximum = false;

presentation.Save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
```

Las imágenes siguientes muestran las diapositivas guardadas renderizadas por Microsoft PowerPoint. Con `true`, la etiqueta **120** es visible en el límite superior; con `false`, está oculta. La etiqueta **60** permanece visible, el máximo del eje se mantiene en **100** y el segundo punto de datos sigue siendo **120** en ambos casos.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Este ejemplo utiliza un gráfico de columnas 2D con un eje de valores. Los gráficos sin eje de valores, como los circulares y de anillos, no tienen un máximo de eje que limitar de esta forma.
{{% /alert %}}

## **Establecer la distancia de la etiqueta respecto a un eje**

Utilice [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) para controlar la distancia entre las etiquetas del eje de categorías y el eje. El valor es un porcentaje del tamaño máximo de fuente de las etiquetas del eje. Este ejemplo crea un gráfico de columnas agrupadas y establece el desplazamiento de la etiqueta del eje horizontal a 500. Esta configuración afecta a las etiquetas del eje de categorías más que a las etiquetas asociadas a puntos de datos individuales.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
chart.Axes.HorizontalAxis.LabelOffset = 500;

presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **Ajustar la ubicación de la etiqueta**

En un gráfico circular, ajuste las posiciones de las etiquetas de datos para mejorar el espaciado y dejar espacio a las líneas guía.

Este ejemplo muestra el valor del primer punto de datos, coloca su etiqueta fuera de la porción y ajusta sus desplazamientos [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) y [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/). Estos desplazamientos son relativos al ancho y a la altura del gráfico, respectivamente.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);
var series = chart.ChartData.Series;

var label = series[0].Labels[0];
label.DataLabelFormat.ShowValue = true;
label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
label.X = 0.71f;
label.Y = 0.04f;

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **Añadir varias filas de etiquetas de datos sobre un gráfico de columnas**

Este ejemplo crea un gráfico de columnas con dos filas de etiquetas de datos sobre el área de trazado. La Serie A muestra las columnas visibles, mientras que las Series B y C proporcionan las etiquetas adicionales. Sus columnas se ocultan eliminando el relleno y el contorno. La propiedad [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) alinea las tres series con los mismos centros de categoría.

Los ajustes del [PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) reservan espacio para las filas de etiquetas. Después de que [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) calcule las posiciones predeterminadas, [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) y [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) conservan la alineación horizontal y aplican desplazamientos verticales para disponer las etiquetas en dos filas. Los números siguen siendo etiquetas de datos vinculadas a los valores de la serie; solo los encabezados de fila son formas de texto independientes.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 640, 200);
chart.HasTitle = false;
chart.HasLegend = false;
chart.TextFormat.PortionFormat.FontHeight = 12;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

string[] categories = { "North", "South", "East", "West" };
string[] seriesNames = { "Series A", "Series B", "Series C" };
double[,] seriesValues = {
    { 35, 42, 28, 47 },
    { 22, 31, 19, 26 },
    { 12, 16, 14, 18 }
};

for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
{
    var categoryCell = workbook.GetCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
    chart.ChartData.Categories.Add(categoryCell);
}

for (int seriesIndex = 0; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var seriesCell = workbook.GetCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
    var series = chart.ChartData.Series.Add(seriesCell, ChartType.ClusteredColumn);

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var valueCell = workbook.GetCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    if (seriesIndex > 0)
    {
        // Ocultar las columnas de B y C, pero mantener sus etiquetas de datos.
        series.Format.Fill.FillType = FillType.NoFill;
        series.Format.Line.FillFormat.FillType = FillType.NoFill;
        var labelFormat = series.Labels.DefaultDataLabelFormat;
        labelFormat.ShowValue = true;
        labelFormat.TextFormat.PortionFormat.FontHeight = 12;
        var labelFill = labelFormat.TextFormat.PortionFormat.FillFormat;
        labelFill.FillType = FillType.Solid;
        labelFill.SolidFillColor.Color = Color.Black;
        labelFormat.Position = LegendDataLabelPosition.InsideBase;
    }
}

// Alinear las tres series con los mismos centros de categoría.
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// Usar menos líneas de cuadrícula para este ejemplo compacto.
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// Reservar espacio sobre el área de trazado para dos filas de etiquetas de datos.
chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;
chart.PlotArea.X = 0.15f;
chart.PlotArea.Y = 0.32f;
chart.PlotArea.Width = 0.80f;
chart.PlotArea.Height = 0.48f;
chart.ValidateChartLayout();

for (int seriesIndex = 1; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    float rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var dataLabel = series.DataPoints[categoryIndex].Label;
        // Mantener la posición horizontal predeterminada. Y es un desplazamiento desde
        // la posición predeterminada de la etiqueta, expresado como una fracción de la altura del gráfico.
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // Solo el encabezado de fila es una forma de texto separada.
    var rowHeading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, chart.X, chart.Y + rowTop * chart.Height, 85, 18);
    rowHeading.FillFormat.FillType = FillType.NoFill;
    rowHeading.LineFormat.FillFormat.FillType = FillType.NoFill;
    rowHeading.AddTextFrame(seriesNames[seriesIndex]);
    rowHeading.TextFrame.TextFrameFormat.MarginTop = 0;
    rowHeading.TextFrame.TextFrameFormat.MarginBottom = 0;
    var headingFormat = rowHeading.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    headingFormat.FontHeight = 12;
    headingFormat.FillFormat.FillType = FillType.Solid;
    headingFormat.FillFormat.SolidFillColor.Color = Color.Black;
}

presentation.Save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
```

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **FAQ**

**¿Cómo puedo evitar que las etiquetas de datos se solapen en gráficos densos?**

Combine la colocación automática de etiquetas, líneas guía y reducción del tamaño de la fuente; si es necesario, oculte algunos campos (por ejemplo, la categoría) o muestre etiquetas solo para valores extremos o puntos clave.

**¿Cómo puedo desactivar las etiquetas solo para valores cero, negativos o vacíos?**

Filtre los puntos de datos antes de habilitar las etiquetas y desactive la visualización para valores de 0, valores negativos o valores ausentes según una regla definida.

**¿Cómo puedo garantizar un estilo de etiqueta coherente al exportar a PDF/imagenes?**

Establezca explícitamente la familia y el tamaño de fuente y verifique que la fuente esté disponible en el entorno de renderizado para evitar sustituciones.