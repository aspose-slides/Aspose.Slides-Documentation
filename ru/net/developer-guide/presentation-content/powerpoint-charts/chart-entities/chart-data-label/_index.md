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

Подписи данных отображают информацию о сериях диаграммы и отдельных точках данных, помогая читателям идентифицировать значения и понимать диаграмму. В этой статье объясняется, как форматировать значения, отображать проценты, считывать текст подписи, управлять подписями за пределами максимума оси, регулировать расстояние между подписями оси категорий и позиционировать подписи круговой диаграммы.

## **Установка точности данных в подписьах диаграмм**

Используйте [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) для форматирования значений серии. Этот пример создает линейную диаграмму с данными по умолчанию, отображает её таблицу данных и включает подписи значений для первой серии. Формат `#,##0.00` отображает разделитель тысяч и два знака после запятой, не изменяя исходные значения.

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

## **Отображение процента в подписях**

Для сложенной столбчатой диаграммы вычислите каждое значение как процент от общей суммы категории и присвойте текст свойству [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). Этот пример использует данные диаграммы по умолчанию и отображает проценты с двумя знаками после запятой шрифтом размером 8 пунктов. Категории с нулевой суммой пропускаются, чтобы избежать деления на ноль. Пересчитайте пользовательский текст подписи, если данные диаграммы изменятся.

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

## **Установка знака процента в подписи данных диаграммы**

Когда значения хранятся в виде дробей, используйте [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) для отображения процентов. Установите [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) в `false`, чтобы применить формат подписи независимо от исходных ячеек. В этом примере создаётся сложенная столбчатая диаграмма 100% с красной и синей сериями для четырёх категорий. Каждая пара значений в сумме даёт 1. Формат подписи `0.0%` отображает 0,30 как 30,0%, в то время как вертикальная ось использует два знака после запятой. Обе серии используют белый текст подписи размером 10 пунктов.

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

## **Получить фактический текст подписи данных**

Используйте [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) для получения текста, сформированного настройками подписи данных. Это полезно при извлечении подписей для отчётов, поиске содержимого презентаций или проверке сгенерированных диаграмм. В примере ниже формат подписи данных по умолчанию [формат подписи данных](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) объединяет название каждой категории, имя серии и значение. Одна точка форматирует своё значение как процент, а другая использует пользовательский текст из [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).

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

Число, хранящееся в точке данных, остаётся `0.75`, даже если её подпись отображает `75%` вместе с названиями категории и серии. Пользовательский текст заменяет сгенерированный текст подписи. [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) возвращает полученную строку подписи в любом случае. Проверяйте [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) отдельно, как показано выше, когда нужно извлекать только видимые подписи.

## **Управление подписями данных за пределами максимума оси**

Когда диапазон оси ограничивается вручную, некоторые точки данных могут превышать её максимум. Используйте [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) для управления тем, отображаются ли их подписи данных. Эта настройка меняет видимость подписи; она не меняет диапазон оси или исходные значения данных. В примере ниже создаётся 2D сгруппированная столбчатая диа

грамма со значениями 60 и 120. На вертикальной оси устанавливается [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) в `false` и [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) в 100. На первом слайде подписи допускаются за пределами максимума; копия этого слайда отключает их. Оба слайда сохраняются в `DataLabelsOverMaximum.pptx`. Включите подписи значений с помощью [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). Настройка на уровне диаграммы не включает отображение значений сама по себе и не переопределяет отключённое отображение значения отдельной подписи. Этот пример включает значения для всей серии и использует [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) для размещения подписей с внешней стороны каждого столбца.

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

Следующие изображения показывают сохранённые слайды, отрендеренные в Microsoft PowerPoint. При `true` подпись **120** видна у верхней границы; при `false` она скрыта. Подпись **60** остаётся видимой, максимум оси остаётся **100**, а вторая точка данных остаётся **120** в обоих случаях.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
В этом примере используется 2D столбчатая диаграмма с осью значений. Диаграммы без оси значений, такие как круговые и кольцевые диаграммы, не имеют максимума оси, который можно ограничить таким образом.
{{% /alert %}}

## **Установить расстояние подписи от оси**

Используйте [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) для управления расстоянием между подписями оси категорий и самой осью. Значение представляет процент от максимального размера шрифта подписей оси. В этом примере создаётся сгруппированная столбчатая диаграмма и задаётся смещение подписи горизонтальной оси в 500. Эта настройка влияет на подписи оси категорий, а не на подписи, прикреплённые к отдельным точкам данных.

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

## **Регулировать положение подписи**

На круговой диаграмме регулируйте позиции подписей данных, чтобы улучшить интервалы и освободить место для выноски. В этом примере отображается значение первой точки данных, её подпись размещается за пределами сектора, и регулируются смещения по [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) и [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/). Эти смещения относятся соответственно к ширине и высоте диаграммы.

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

## **Добавить несколько строк подписей данных над столбчатой диаграммой**

В этом примере создаётся столбчатая диаграмма с двумя строками подписей данных над областью построения. Серия A отображает видимые столбцы, в то время как серии B и C предоставляют дополнительные подписи. Их столбцы скрыты удалением заливки и контура. Свойство [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) выравнивает все три серии по одинаковым центрам категорий. Настройки [PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) резервируют пространство для строк подписей. После того как [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) вычислит позиции по умолчанию, [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) и [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) сохраняют горизонтальное выравнивание и применяют вертикальные смещения для размещения подписей в двух строках. Числа остаются подписями данных, связанными со значениями серий; только заголовки строк являются отдельными текстовыми фигурами.

```csharp
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

// Выровнять все три серии по одинаковым центрам категорий.
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// Использовать меньше линий сетки в этом компактном примере.
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// Зарезервировать пространство над областью построения для двух строк подписей данных.
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
        // Сохранить дефолтное горизонтальное положение. Y — смещение от
        // дефолтного положения подписи, выраженное в долях высоты диаграммы.
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

![Столбчатая диаграмма с двумя строками подписей данных над областью построения](multiple-rows-of-labels.png)

## **Часто задаваемые вопросы**

**Как предотвратить наложение подписей данных на плотно заполненных диаграммах?**  
Сочетайте автоматическое размещение подписей, выноски и уменьшенный размер шрифта; при необходимости скрывайте некоторые поля (например, категорию) или показывайте подписи только для экстремальных значений или ключевых точек.

**Как отключить подписи только для нулевых, отрицательных или пустых значений?**  
Отфильтруйте точки данных перед включением подписей и отключите отображение для значений 0, отрицательных значений или отсутствующих данных согласно заданному правилу.

**Как обеспечить единый стиль подписи при экспорте в PDF/изображения?**  
Явно задайте семейство шрифтов и размер, а также убедитесь, что шрифт доступен в среде рендеринга, чтобы избежать подстановки.