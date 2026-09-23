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
- distancia de etiqueta
- ubicación de etiqueta
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a añadir y dar formato a las etiquetas de datos de gráficos en presentaciones de PowerPoint usando Aspose.Slides para .NET para diapositivas más atractivas."
---
## **Introducción**

Las etiquetas de datos muestran información sobre las series del gráfico y los puntos de datos individuales, ayudando a los lectores a identificar valores y comprender el gráfico. Este artículo explica cómo dar formato a los valores, mostrar porcentajes, leer el texto de las etiquetas, ajustar el espaciado de las etiquetas del eje de categorías y posicionar las etiquetas de los gráficos circulares.

## **Establecer la precisión de los datos en las etiquetas de datos del gráfico**

Utilice [NumberFormatOfValues](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartseries/numberformatofvalues/) para dar formato a los valores de la serie. Este ejemplo crea un gráfico de líneas con datos predeterminados, muestra su tabla de datos y habilita las etiquetas de valores para la primera serie. El formato `#,##0.00` muestra un separador de miles y dos decimales sin modificar los valores subyacentes.

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

## **Mostrar porcentaje como etiquetas**

Para un gráfico de columnas apiladas, calcule cada valor como porcentaje del total de su categoría y asigne el texto a [TextFrameForOverriding](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). Este ejemplo utiliza los datos de gráfico predeterminados y muestra los porcentajes con dos decimales en una fuente de 8 puntos. Las categorías con un total de cero se omiten para evitar la división por cero. Recalcule el texto de la etiqueta personalizada si los datos del gráfico cambian.

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

## **Establecer el signo de porcentaje con etiquetas de datos del gráfico**

Cuando los valores se almacenan como fracciones, use [NumberFormat](https://reference.aspose.com/slides/es/net/aspose.slides.charts/idatalabelformat/numberformat/) para mostrar porcentajes. Establezca [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/es/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) a `false` para aplicar el formato de la etiqueta independientemente de las celdas fuente.

Este ejemplo crea un gráfico de columnas apiladas al 100 % con series roja y azul en cuatro categorías. Cada pareja de valores suma 1. El formato de etiqueta `0.0%` muestra 0.30 como 30.0 %, mientras que el eje vertical utiliza dos decimales. Ambas series usan texto de etiqueta blanco de 10 puntos.

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

Utilice [GetActualLabelText](https://reference.aspose.com/slides/es/net/aspose.slides.charts/idatalabel/getactuallabeltext/) para obtener el texto generado por la configuración de una etiqueta de datos. Esto es útil al extraer etiquetas para informes, buscar contenido en la presentación o validar gráficos generados. En el ejemplo a continuación, el [formato de etiqueta de datos](https://reference.aspose.com/slides/es/net/aspose.slides.charts/idatalabelformat/) predeterminado combina el nombre de cada categoría, el nombre de la serie y el valor. Un punto formatea su valor como porcentaje y otro utiliza texto personalizado de [TextFrameForOverriding](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).

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

El número almacenado en un punto de datos sigue siendo `0.75`, aun cuando su etiqueta muestra `75%` junto con los nombres de la categoría y la serie. El texto personalizado reemplaza el texto de etiqueta generado. [GetActualLabelText](https://reference.aspose.com/slides/es/net/aspose.slides.charts/idatalabel/getactuallabeltext/) devuelve la cadena de etiqueta resultante en ambos casos. Consulte [IsVisible](https://reference.aspose.com/slides/es/net/aspose.slides.charts/idatalabel/isvisible/) por separado, como se muestra arriba, cuando desee extraer solo las etiquetas visibles.

## **Establecer la distancia de la etiqueta desde un eje**

Utilice [LabelOffset](https://reference.aspose.com/slides/es/net/aspose.slides.charts/iaxis/labeloffset/) para controlar la distancia entre las etiquetas del eje de categorías y el eje. El valor es un porcentaje del tamaño máximo de fuente de las etiquetas del eje. Este ejemplo crea un gráfico de columnas agrupadas y establece el desplazamiento de la etiqueta del eje horizontal a 500. Esta configuración afecta a las etiquetas del eje de categorías más que a las etiquetas adjuntas a puntos de datos individuales.

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

## **Ajustar la posición de la etiqueta**

En un gráfico circular, ajuste las posiciones de las etiquetas de datos para mejorar el espaciado y dejar espacio a las líneas guía.

Este ejemplo muestra el valor del primer punto de datos, coloca su etiqueta fuera de la porción y ajusta sus desplazamientos [X](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ilayoutable/x/) y [Y](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ilayoutable/y/). Estos desplazamientos son relativos al ancho y la altura del gráfico, respectivamente.

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

![Gráfico circular con la posición de la etiqueta de datos ajustada](pie-chart-adjusted-label.png)

## **Preguntas frecuentes**

**¿Cómo puedo evitar que las etiquetas de datos se solapen en gráficos densos?**

Combine la colocación automática de etiquetas, líneas de guía y una reducción del tamaño de fuente; si es necesario, oculte algunos campos (por ejemplo, la categoría) o muestre etiquetas solo para los valores extremos o puntos clave.

**¿Cómo puedo desactivar las etiquetas solo para valores cero, negativos o vacíos?**

Filtre los puntos de datos antes de habilitar las etiquetas y desactive la visualización para valores 0, valores negativos o valores faltantes según una regla definida.

**¿Cómo puedo garantizar un estilo de etiqueta consistente al exportar a PDF/imagenes?**

Establezca explícitamente la familia y el tamaño de la fuente y verifique que la fuente esté disponible en el entorno de renderizado para evitar sustituciones.