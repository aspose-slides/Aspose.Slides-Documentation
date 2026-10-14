---
title: Personalizar gráficos de pastel en presentaciones en .NET
linktitle: Gráfico de pastel
type: docs
url: /es/net/pie-chart/
keywords:
- gráfico de pastel
- gestionar gráfico
- personalizar gráfico
- opciones de gráfico
- configuración de gráfico
- opciones de trama
- color de porción
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Cree y personalice gráficos de pastel en .NET con Aspose.Slides. Configure tramas secundarias, muestre etiquetas de datos y aplique colores automáticos a las porciones en PowerPoint."
---
## **Descripción general**

Este artículo explica cómo trabajar con gráficos de pastel en Aspose.Slides. Muestra cómo configurar opciones de tramas secundarias para los gráficos Pie of Pie y Bar of Pie, y cómo habilitar el coloreado automático de porciones para un gráfico de pastel estándar.

Los ejemplos se centran en tareas de personalización de gráficos como añadir un gráfico a una diapositiva, ajustar la configuración de series y etiquetas, reemplazar los datos predeterminados del gráfico con categorías y valores personalizados, y guardar la presentación actualizada.

## **Opciones de segundo gráfico para diagramas Pie of Pie y Bar of Pie**

Aspose.Slides para .NET admite opciones de trama secundaria para los gráficos Pie of Pie y Bar of Pie. Estas opciones controlan el tamaño de la trama secundaria y cómo se dividen los puntos de datos entre las dos tramas.

El siguiente ejemplo crea un gráfico Pie of Pie en una nueva presentación y muestra los valores de los puntos de datos como etiquetas. La propiedad [SecondPieSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/secondpiesize/) establece el tamaño de la trama secundaria en un 149 % de la trama principal. [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitby/) selecciona la división basada en porcentaje, y [PieSplitPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitposition/) fija el umbral en un 53 %.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
var series = chart.ChartData.Series[0];

// Display values and configure the secondary plot.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.SecondPieSize = 149;
seriesGroup.PieSplitBy = PieSplitType.ByPercentage;
seriesGroup.PieSplitPosition = 53;

presentation.Save("pie_of_pie.pptx", SaveFormat.Pptx);
```

### **Seleccionar categorías para el gráfico secundario**

Utilice la división personalizada cuando desee agrupar categorías específicas en la trama secundaria sin importar sus valores porcentuales. Por ejemplo, un informe de ventas podría mostrar Online y Events juntos para que los lectores comparen estos dos canales, aunque representen el 35 % y el 10 % del total de ventas.

Establezca [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitby/) a [PieSplitType.Custom](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplittype/) y seleccione los puntos mediante [PieSplitCustomPoints](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitcustompoints/). El método [Add](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/add/) de la colección acepta tanto un índice basado en cero en la serie como un objeto de punto de datos. En este ejemplo, el índice 1 selecciona Online, y el punto en el índice 3 selecciona Events. Partners también se añade temporalmente, luego se excluye usando [Remove](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/remove/).

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 200);

// Reemplazar los datos predeterminados con las ventas por canal.
var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "Retail", "Online", "Partners", "Events" };
var values = new[] { 40, 35, 15, 10 };
var seriesNameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.PieSplitBy = PieSplitType.Custom;
seriesGroup.IsColorVaried = true;

// Seleccionar Online por su índice basado en cero y Events por su objeto de punto de datos.
seriesGroup.PieSplitCustomPoints.Add(1);
seriesGroup.PieSplitCustomPoints.Add(series.DataPoints[3]);

// Excluir Partners de la selección sin eliminar sus datos fuente.
seriesGroup.PieSplitCustomPoints.Add(2);
seriesGroup.PieSplitCustomPoints.Remove(series.DataPoints[2]);

presentation.Save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
```

Online (35) y Events (10) aparecen como porciones separadas en la trama secundaria. En la trama principal, están representados por una porción combinada con un valor de 45, junto a Retail (40) y Partners (15). Eliminar Partners de la selección personalizada lo mantiene en la trama principal; no elimina la categoría ni su valor de los datos fuente del gráfico.

La siguiente imagen muestra la presentación guardada en PowerPoint:

![Gráfico Pie of Pie con Online y Eventos en el gráfico secundario y su valor combinado de 45 en el gráfico principal](pie_of_pie_custom.png)

## **Establecer colores automáticos para las porciones del gráfico de pastel**

Aspose.Slides para .NET puede asignar automáticamente colores diferentes a las porciones de un gráfico de pastel. El siguiente ejemplo crea un gráfico de pastel con un título centrado y reemplaza los datos predeterminados con tres categorías trimestrales y sus valores. La propiedad [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) muestra los valores 20, 50 y 30 como etiquetas, mientras que [IsColorVaried](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/iscolorvaried/) habilita un color distinto para cada porción.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// Añadir un título centrado al gráfico.
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// Reemplazar los datos predeterminados usando la primera hoja de cálculo.
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "First Qtr", "2nd Qtr", "3rd Qtr" };
var values = new[] { 20, 50, 30 };
var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

// Mostrar valores y asignar colores diferentes a las porciones.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.ParentSeriesGroup.IsColorVaried = true;

presentation.Save("pie.pptx", SaveFormat.Pptx);
```

## **FAQ**

**¿Se admiten las variaciones de Pie of Pie y Bar of Pie?**

Sí, la biblioteca [admite](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) una trama secundaria para gráficos de pastel, incluidos los tipos Pie of Pie y Bar of Pie.

**¿Puedo exportar solo el gráfico como imagen (por ejemplo, PNG)?**

Sí, puedes [exportar el propio gráfico como una imagen](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (por ejemplo, PNG) sin exportar toda la presentación.