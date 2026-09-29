---
title: Управление метками данных диаграмм в презентациях на .NET
linktitle: Метка данных
type: docs
url: /ru/net/chart-data-label/
keywords:
- диаграмма
- метка данных
- точность данных
- процент
- расстояние метки
- расположение метки
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как добавить и форматировать метки данных диаграмм в презентациях PowerPoint с помощью Aspose.Slides для .NET, чтобы сделать слайды более привлекательными."
---
## **Введение**

Метк​ы данных отображают информацию о рядах диаграммы и отдельных точках данных, помогая читателям определить значения и понять диаграмму. В этой статье объясняется, как форматировать значения, отображать проценты, считывать текст меток, управлять метками за пределами максимального значения оси, настраивать интервал меток категориальной оси и позиционировать метки круговой диаграммы.

## **Установка точности данных в метках диаграммы**

Используйте [NumberFormatOfValues](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseries/numberformatofvalues/) для форматирования значений рядов. Этот пример создает линейную диаграмму с данными по умолчанию, отображает её таблицу данных и включает метки значений для первого ряда. Формат `#,##0.00` выводит разделитель тысяч и два знака после запятой без изменения исходных значений.

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

## **Отображение процентов в виде меток**

Для сложенной столбчатой диаграммы вычислите каждое значение как процент от общей суммы категории и присвойте текст [TextFrameForOverriding](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). Этот пример использует данные диаграммы по умолчанию и отображает проценты с двумя знаками после запятой шрифтом 8 пунктов. Категории с нулевой суммой пропускаются, чтобы избежать деления на ноль. При изменении данных диаграммы пересчитайте пользовательский текст метки.

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

## **Установка знака процента в метках диаграммы**

Когда значения хранятся в виде дробей, используйте [NumberFormat](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/idatalabelformat/numberformat/) для отображения процентов. Установите [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) в `false`, чтобы применить формат метки независимо от исходных ячеек.

Этот пример создает 100% сложенную столбчатую диаграмму с красными и синими рядами в четырёх категориях. Каждая пара значений в сумме дает 1. Формат метки `0.0%` отображает 0.30 как 30.0%, тогда как вертикальная ось использует два знака после запятой. Оба ряда используют белый текст меток размером 10 пунктов.

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

## **Чтение фактического текста меток данных**

Используйте [GetActualLabelText](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/idatalabel/getactuallabeltext/) для получения текста, сформированного настройками метки данных. Это полезно при извлечении меток для отчетов, поиске содержимого презентаций или проверке сгенерированных диаграмм. В примере ниже формат метки данных по умолчанию [data label format](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/idatalabelformat/) объединяет название категории, название ряда и значение. Одна точка форматирует своё значение как процент, а другая использует пользовательский текст из [TextFrameForOverriding](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).

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

Число, хранящееся в точке данных, остаётся `0.75`, даже если её метка отображает `75%` вместе с названиями категории и ряда. Пользовательский текст заменяет сгенерированный текст метки. [GetActualLabelText](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/idatalabel/getactuallabeltext/) возвращает полученную строку метки в обоих случаях. Проверяйте [IsVisible](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/idatalabel/isvisible/) отдельно, как показано выше, когда нужно извлечь только видимые метки.

## **Управление метками данных за пределами максимального значения оси**

Когда диапазон оси задаётся вручную, некоторые точки данных могут превышать её максимум. Используйте [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) для управления отображением их меток данных. Эта настройка меняет видимость меток; она не меняет диапазон оси или исходные значения данных.

В примере ниже создаётся 2D сгруппированная столбчатая диаграмма со значениями 60 и 120. Для вертикальной оси устанавливается [IsAutomaticMaxValue](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) в `false` и [MaxValue](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/iaxis/maxvalue/) в 100. На первом слайде разрешены метки за пределами максимума; копия этого слайда отключает их. Оба слайда сохраняются в `DataLabelsOverMaximum.pptx`.

Включите метки значений с помощью [ShowValue](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/idatalabelformat/showvalue/). Настройка уровня диаграммы не включает отображение значений сама по себе и не переопределяет отключённое отображение значений отдельной метки. В этом примере включаются значения для всего ряда и используется [Position](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/idatalabelformat/position/) для размещения меток на внешнем конце каждого столбца.

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

Ниже показаны сохранённые слайды, отрисованные в Microsoft PowerPoint. При `true` метка **120** видна у верхней границы; при `false` она скрыта. Метка **60** остаётся видимой, максимум оси остаётся **100**, а вторая точка данных остаётся **120** в обоих случаях.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
В этом примере используется 2D столбчатая диаграмма со значительной осью. Диаграммы без оси значений, такие как круговые и кольцевые диаграммы, не имеют максимального значения оси, которое можно ограничить этим способом.
{{% /alert %}}

## **Установка расстояния метки от оси**

Используйте [LabelOffset](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/iaxis/labeloffset/) для управления расстоянием между метками категориальной оси и осью. Значение представляет собой процент от максимального размера шрифта меток оси. Этот пример создаёт сгруппированную столбчатую диаграмму и устанавливает смещение меток горизонтальной оси на 500. Эта настройка влияет на метки категориальной оси, а не на метки, прикреплённые к отдельным точкам данных.

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

## **Регулирование положения метки**

На круговой диаграмме отрегулируйте положения меток данных, чтобы улучшить распределение и освободить место для линий‑выноски.

В этом примере отображается значение первой точки данных, её метка размещается за пределом сектора, а смещения [X](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ilayoutable/x/) и [Y](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ilayoutable/y/) настраиваются. Эти смещения задаются относительно ширины и высоты диаграммы соответственно.

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

![Круговая диаграмма с отрегулированным положением метки данных](pie-chart-adjusted-label.png)

## **Вопросы и ответы**

**Как предотвратить наложение меток данных на плотных диаграммах?**  
Сочетайте автоматическое размещение меток, линии‑выноски и уменьшенный размер шрифта; при необходимости скрывайте некоторые поля (например, категорию) или отображайте метки только для экстремальных значений или ключевых точек.

**Как отключить метки только для нулевых, отрицательных или пустых значений?**  
Отфильтруйте точки данных перед включением меток и отключите отображение для значений 0, отрицательных значений или отсутствующих значений согласно заданному правилу.

**Как обеспечить согласованный стиль меток при экспорте в PDF/изображения?**  
Явно задайте семейство шрифта и размер, а также убедитесь, что шрифт доступен в среде рендеринга, чтобы избежать подстановки.