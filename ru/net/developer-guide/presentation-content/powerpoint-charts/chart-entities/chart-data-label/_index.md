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
description: "Узнайте, как добавлять и форматировать подписи данных в диаграммах PowerPoint‑презентаций с помощью Aspose.Slides для .NET, чтобы сделать слайды более увлекательными."
---
## **Введение**

Подписи данных отображают информацию о сериях диаграммы и отдельных точках данных, помогая читателям определять значения и понимать диаграмму. В этой статье объясняется, как форматировать значения, отображать проценты, читать текст подписи, управлять подписями за пределами максимума оси, регулировать интервал подписей оси категорий и позиционировать подписи в круговой диаграмме.

## **Подсчёт видимых подписей данных**

Используйте [CountOfVisibleDataLabels](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/countofvisibledatalabels/) чтобы проверить, сколько подписей данных включено для отображения перед публикацией презентации. В отличие от [Count](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/count/), который возвращает общее количество подписей в коллекции, этот метод учитывает значения по умолчанию для серий и индивидуальные настройки подписи.

В этом примере создаётся столбчатая диаграмма с одной серией и тремя точками данных. Он получает доступ к коллекции [Labels](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/labels/) серии и выводит количество видимых подписей при изменении настроек: **0, 3, 2, 3**. Общее количество остаётся **3**.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesCell = workbook.GetCell(0, 0, 1, "Values");
var series = chart.ChartData.Series.Add(seriesCell, chart.Type);

for (int i = 0; i < 3; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, (i + 1) * 10);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var labels = series.Labels;
Console.WriteLine($"Total: {labels.Count}; visible: {labels.CountOfVisibleDataLabels}"); // Всего: 3; видимых: 0

labels.DefaultDataLabelFormat.ShowValue = true;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // Видимо: 3

labels[1].DataLabelFormat.ShowValue = false;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // Видимо: 2

labels[1].DataLabelFormat.ShowLegendKey = true;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // Видимо: 3
```

Коллекция [DefaultDataLabelFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/defaultdatalabelformat/) серии задаёт настройки по умолчанию. Включение [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) отображает значения для всех трёх подписей. Установка её в `false` через [DataLabelFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/datalabelformat/) отдельной подписи переопределяет эту настройку для выбранной подписи. Включение [ShowLegendKey](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showlegendkey/) вновь делает эту подпись видимой, хотя её значение остаётся скрытым.

Количество видимых подписей отражает настройки видимости. Оно не измеряет, накладываются ли подписи друг на друга, обрезаны ли они или читаемы в отрисованной диаграмме.

## **Установить точность данных в подписях диаграмм**

Используйте [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) для форматирования значений серии. В этом примере создаётся линейная диаграмма с данными по умолчанию, отображается её таблица данных и включаются подписи значений для первой серии. Формат `#,##0.00` отображает разделитель тысяч и два знака после запятой без изменения исходных значений.

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

Чтобы отформатировать числовые ячейки во встроенной книге диаграммы, см. [Set Custom Number Formats for Workbook Cells](/slides/ru/net/chart-workbook/#set-custom-number-formats-for-workbook-cells). В том примере также показаны подписи значений, следующие форматам исходных ячеек, при сохранении сохранённых числовых значений.

## **Отображать процент в подписьах**

Для сложенной столбчатой диаграммы вычислите каждое значение как процент от общей суммы категории и присвойте текст свойству [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). Этот пример использует данные диаграммы по умолчанию и отображает проценты с двумя знаками после запятой шрифтом размером 8 пунктов. Категории с общей суммой, равной нулю, пропускаются, чтобы избежать деления на ноль. При изменении данных диаграммы пересчитайте пользовательский текст подписи.

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

## **Установить знак процента в подписях диаграммы**

Когда значения хранятся в виде дробей, используйте [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) для отображения процентов. Установите [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) в `false`, чтобы применять формат подписи независимо от исходных ячеек.

В этом примере создаётся 100% сложенная столбчатая диаграмма с красной и синей сериями, охватывающими четыре категории. Каждая пара значений в сумме дает 1. Формат подписи `0.0%` отображает 0.30 как 30.0%, в то время как вертикальная ось использует два знака после запятой. Обе серии используют белый текст подписи размером 10 пунктов.

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

## **Получить фактический текст подписей данных**

Используйте [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) чтобы получить текст, сформированный настройками подписи данных. Это полезно при извлечении подписей для отчетов, поиске содержимого презентации или проверке сгенерированных диаграмм. В примере ниже формат подписи по умолчанию [data label format](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) комбинирует имя категории, имя серии и значение. Одна точка форматирует своё значение как процент, а другая использует пользовательский текст из [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).

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

Число, хранящееся в точке данных, остаётся `0.75`, даже если её подпись отображает `75%` вместе с именем категории и серии. Пользовательский текст заменяет сгенерированный текст подписи. [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) возвращает полученную строку подписи в любом случае. Проверяйте [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) отдельно, как показано выше, когда нужно извлечь только видимые подписи.

## **Управление подписями данных за пределами максимума оси**

Когда вы ограничиваете диапазон оси вручную, некоторые точки данных могут превышать её максимум. Используйте [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) для управления тем, отображаются ли их подписи данных. Эта настройка меняет видимость подписи; она не меняет диапазон оси или исходные значения данных.

В приведённом примере создаётся 2D сгруппированная столбчатая диаграмма со значениями 60 и 120. На вертикальной оси устанавливаются [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) в `false` и [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) в 100. На первом слайде подписи допускаются за пределами максимума; копия этого слайда отключает их. Оба слайда сохраняются в `DataLabelsOverMaximum.pptx`.

Включите подписи значений с помощью [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). Настройка уровня диаграммы сама по себе не включает отображение значений и не переопределяет отключённое отображение значения отдельной подписи. В этом примере включаются значения для всей серии и используется [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) для размещения подписей в наружном конце каждого столбца.

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

Ниже показаны сохранённые слайды, отрисованные в Microsoft PowerPoint. При `true` подпись **120** видна у верхней границы; при `false` она скрыта. Подпись **60** остаётся видимой, максимум оси остаётся **100**, а вторая точка данных остаётся **120** в обоих случаях.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Этот пример использует 2D столбчатую диаграмму с осью значений. Диаграммы без оси значений, такие как круговые и кольцевые диаграммы, не имеют максимума оси, ограничиваемого таким способом.
{{% /alert %}}

## **Установить расстояние подписи от оси**

Используйте [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) для управления расстоянием между подписями оси категорий и самой осью. Значение задаётся в процентах от максимального размера шрифта подписей оси. В этом примере создаётся сгруппированная столбчатая диаграмма и устанавливается смещение подписи горизонтальной оси в 500. Эта настройка влияет на подписи оси категорий, а не на подписи, привязанные к отдельным точкам данных.

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

## **Регулировать расположение подписи**

На круговой диаграмме скорректируйте позиции подписей данных, чтобы улучшить интервалы и освободить место для выноски.

В этом примере отображается значение первой точки данных, её подпись размещается за пределами сектора и корректируются смещения [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) и [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/). Эти смещения относятся соответственно к ширине и высоте диаграммы.

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

## **Форматировать выноски**

Когда подписи круговой диаграммы находятся за пределами секторов, выноски помогают читателям сопоставить каждое значение с соответствующим сектором. Контрастный цвет и немного более толстая линия могут облегчить восприятие этих соединений, а прозрачность и пунктирный стиль делают линии визуально ненавязчивыми.

Используйте [LeaderLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabelcollection/leaderlinesformat/) для форматирования выносок на уровне коллекции подписей данных серии. Настройки в `series.Labels.LeaderLinesFormat.Line` применяются к коллекции, а не к отдельной подписи.

В этом примере создаётся круговая диаграмма с данными по умолчанию, отображаются значения за пределами секторов и включаются [ShowLeaderLines](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showleaderlines/). Выноски перемещают две подписи дальше от их секторов с помощью смещений [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) и [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/), выраженных в долях ширины и высоты диаграммы. Входная презентация не требуется.

Для линии [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) задаётся сплошной синий цвет с альфа‑значением 191 из 255, что примерно 25% прозрачности. [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) устанавливает толщину в 2 пункта, а [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) делает линию пунктирной.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 80, 50, 560, 400);
chart.HasLegend = false;

var series = chart.ChartData.Series[0];

var labelFormat = series.Labels.DefaultDataLabelFormat;
labelFormat.ShowValue = true;
labelFormat.Position = LegendDataLabelPosition.OutsideEnd;
labelFormat.ShowLeaderLines = true;

// Переместить две подписи дальше от их секторов.
series.Labels[0].X = 0.10f;
series.Labels[0].Y = -0.05f;
series.Labels[1].X = -0.10f;
series.Labels[1].Y = 0.05f;

var line = series.Labels.LeaderLinesFormat.Line;
line.FillFormat.FillType = FillType.Solid;
line.FillFormat.SolidFillColor.Color = Color.FromArgb(191, 30, 90, 160);
line.Width = 2;
line.DashStyle = LineDashStyle.Dash;

presentation.Save("FormattedLeaderLines.pptx", SaveFormat.Pptx);
```

Включение выносок не гарантирует, что линия появится для каждой подписи. Видимость зависит от расположения подписи и поведения компоновки диаграммы. В этом примере две смещённые подписи имеют видимые выноски; подписи, оставшиеся близко к своим секторам, их не требуют.

На следующем изображении показан сохранённый `FormattedLeaderLines.pptx`, отрисованный с помощью Aspose.Slides:

![Pie chart with blue, semitransparent dashed leader lines connecting two outside labels to their slices](formatted-leader-lines.png)

## **Добавить несколько строк подписей данных над столбчатой диаграммой**

В этом примере создаётся столбчатая диаграмма с двумя строками подписей данных над областью построения. Серия A отображает видимые столбцы, а серии B и C предоставляют дополнительные подписи. Их столбцы скрыты удалением заливки и контура. Свойство [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) выравнивает все три серии по одинаковым центрам категорий.

Настройки [PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) резервируют пространство для строк подписей. После того как [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) рассчитывает позиции по умолчанию, [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) и [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) сохраняют горизонтальное выравнивание и применяют вертикальные смещения, чтобы расположить подписи в две строки. Числа остаются подписями данных, связанными со значениями серии; только заголовки строк являются отдельными текстовыми фигурами.

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
        // Скрыть столбцы B и C, но оставить их подписи данных.
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

// Выровнять все три серии по тем же центрам категорий.
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// Использовать меньше сеточных линий в этом компактном примере.
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// Зарезервировать место над областью построения для двух строк подписей данных.
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
            // Сохранить позицию по умолчанию по горизонтали. Y — смещение от
            // позиции подписи по умолчанию, выраженное как доля высоты диаграммы.
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // Только заголовок строки является отдельной текстовой фигурой.
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

## **Изменить форму подписи данных**

Aspose.Slides for .NET 26.11 добавляет [IDataLabel.LabelShapeType](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/labelshapetype/) для одной подписи и [IDataLabelCollection.DefaultLabelShapeType](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/defaultlabelshapetype/) для всех текущих подписей в серии. Они изменяют форму подписи, а не её маркер точки. Для отдельной настройки выноски см. [Data Label Callouts](/slides/ru/net/callout/).

Назначение коллекции обновляет существующие подписи, поэтому применяйте индивидуальные переопределения **после** настройки коллекции. Этот полный пример требует [Aspose.Slides for .NET](/slides/ru/net/installation/) версии 26.11 или новее. Он создаёт видимые подписи значений, выбирает эллипсы для первой серии, а затем делает первую подпись прямоугольной.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var labels = chart.ChartData.Series[0].Labels;
labels.DefaultDataLabelFormat.ShowValue = true;
labels.DefaultLabelShapeType = ShapeType.Ellipse;
labels[0].LabelShapeType = ShapeType.Rectangle;

foreach (var label in labels)
{
    var format = label.DataLabelFormat.Format;
    format.Fill.FillType = FillType.Solid;
    format.Fill.SolidFillColor.Color = Color.LightYellow;
    format.Line.FillFormat.FillType = FillType.Solid;
    format.Line.FillFormat.SolidFillColor.Color = Color.DarkBlue;
}

presentation.Save("label-shapes.pptx", SaveFormat.Pptx);

// Сбросить явный выбор формы для всех текущих подписей.
labels.DefaultLabelShapeType = ShapeType.NotDefined;
presentation.Save("label-shapes-reset.pptx", SaveFormat.Pptx);
```

Повторное назначение формы коллекции также заменяет ранее выбранные индивидуальные формы. [NotDefined](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) сбрасывает явный выбор формы; это не скрывает подписи и не очищает их другое форматирование. Устанавливайте нужные формы после заполнения серии, а не предполагая, что точки, добавленные позже, унаследуют предыдущее назначение. Здесь используются Rectangle и Ellipse; просмотрите результат отрисовки при выборе других типов форм.

## **FAQ**

**Как можно предотвратить наложение подписей данных на плотных диаграммах?**

Сочетайте автоматическое размещение подписей, выноски и уменьшенный размер шрифта; при необходимости скрывайте некоторые поля (например, категорию) или показывайте подписи только для экстремальных значений или ключевых точек.

**Как можно отключить подписи только для нулевых, отрицательных или пустых значений?**

Отфильтруйте точки данных перед включением подписей и отключите отображение для значений 0, отрицательных или отсутствующих значений в соответствии с заданным правилом.

**Как гарантировать единый стиль подписи при экспорте в PDF/изображения?**

Явно задайте семейство шрифта и его размер и убедитесь, что шрифт доступен в среде отрисовки, чтобы избежать подстановки.