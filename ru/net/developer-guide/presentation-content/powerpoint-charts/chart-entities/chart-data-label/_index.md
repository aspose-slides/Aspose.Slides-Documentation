---
title: Управление подписями данных диаграмм в презентациях на .NET
linktitle: Подпись данных
type: docs
url: /ru/net/chart-data-label/
keywords:
- диаграмма
- подпись данных
- точность данных
- процент
- расстояние подписи
- расположение подписи
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как добавлять и форматировать подписи данных диаграмм в презентациях PowerPoint с помощью Aspose.Slides для .NET, чтобы сделать слайды более увлекательными."
---
## **Введение**

Подписи данных отображают информацию о сериях диаграммы и отдельных точках данных, помогая читателям определять значения и понимать диаграмму. В этой статье объясняется, как форматировать значения, отображать проценты, считывать текст подписи, регулировать интервал подписей оси категорий и позиционировать подписи на круговой диаграмме.

## **Установка точности данных в подписи диаграммы**

Используйте [NumberFormatOfValues](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseries/numberformatofvalues/) для форматирования значений серии. Этот пример создаёт линейную диаграмму с данными по умолчанию, отображает её таблицу данных и включает подписи значений для первой серии. Формат `#,##0.00` показывает разделитель тысяч и две десятичные дроби без изменения базовых значений.

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

## **Отображение процента в виде подписей**

Для сложенной столбчатой диаграммы вычислите каждое значение как процент от общей суммы категории и присвойте текст [TextFrameForOverriding](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). Этот пример использует данные диаграммы по умолчанию и отображает проценты с двумя десятичными знаками шрифтом 8 пунктов. Категории с нулевой суммой пропускаются, чтобы избежать деления на ноль. При изменении данных диаграммы пересчитайте пользовательский текст подписи.

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

## **Установка знака процента в подписях данных диаграммы**

Когда значения хранятся в виде дробей, используйте [NumberFormat](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/idatalabelformat/numberformat/) для отображения процентов. Установите [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) в `false`, чтобы формат подписи применялся независимо от исходных ячеек.

Этот пример создаёт 100 % сложенную столбчатую диаграмму с красными и синими сериями в четырёх категориях. Каждая пара значений в сумме даёт 1. Формат подписи `0.0%` выводит 0.30 как 30.0 %, а вертикальная ось использует два десятичных знака. Обе серии используют белый текст подписи размером 10 пунктов.

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

## **Чтение фактического текста подписи данных**

Используйте [GetActualLabelText](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/idatalabel/getactuallabeltext/) для получения текста, сформированного настройками подписи данных. Это полезно при извлечении подписей для отчётов, поиске содержимого презентации или проверке сгенерированных диаграмм. В примере ниже формат подписи данных по умолчанию [data label format](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/idatalabelformat/) объединяет название каждой категории, название серии и значение. Одна точка форматирует своё значение как процент, другая использует пользовательский текст из [TextFrameForOverriding](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).

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

Число, хранящееся в точке данных, остаётся `0.75`, даже если её подпись отображает `75%` вместе с названиями категории и серии. Пользовательский текст заменяет сгенерированный текст подписи. [GetActualLabelText](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/idatalabel/getactuallabeltext/) возвращает полученную строку подписи в любом случае. Проверяйте [IsVisible](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/idatalabel/isvisible/) отдельно, как показано выше, когда нужно извлекать только видимые подписи.

## **Установка расстояния подписи от оси**

Используйте [LabelOffset](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/iaxis/labeloffset/) для управления расстоянием между подписями оси категорий и самой осью. Значение представляет собой процент от максимального размера шрифта подписей оси. Этот пример создаёт сгруппированную столбчатую диаграмму и задаёт смещение подписей горизонтальной оси равным 500. Эта настройка влияет на подписи оси категорий, а не на подписи, привязанные к отдельным точкам данных.

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

## **Регулировка положения подписи**

На круговой диаграмме скорректируйте позиции подписей данных, чтобы улучшить интервалы и освободить место для выносных линий.

Этот пример отображает значение первой точки данных, размещает её подпись за пределами сектора и корректирует смещения [X](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ilayoutable/x/) и [Y](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ilayoutable/y/). Эти смещения указаны относительно ширины и высоты диаграммы соответственно.

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

![Круговая диаграмма с отрегулированным положением подписи данных](pie-chart-adjusted-label.png)

## **Часто задаваемые вопросы**

**Как предотвратить наложение подписей данных на перегруженных диаграммах?**

Комбинируйте автоматическое размещение подписей, выносные линии и уменьшенный размер шрифта; при необходимости скрывайте некоторые поля (например, категорию) или показывайте подписи лишь для экстремальных значений или ключевых точек.

**Как отключить подписи только для нулевых, отрицательных или пустых значений?**

Отфильтруйте точки данных перед включением подписей и отключите отображение для значений, равных 0, отрицательных значений или отсутствующих значений согласно заданному правилу.

**Как обеспечить единообразный стиль подписи при экспорте в PDF/изображения?**

Явно задайте семейство шрифта и размер и проверьте, что шрифт доступен в среде рендеринга, чтобы избежать автоматического подбора альтернатив.