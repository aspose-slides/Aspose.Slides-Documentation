---
title: .NET におけるプレゼンテーションのチャート データ ラベルの管理
linktitle: データラベル
type: docs
url: /ja/net/chart-data-label/
keywords:
- チャート
- データラベル
- データ精度
- パーセンテージ
- ラベル距離
- ラベル位置
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint プレゼンテーションにチャート データ ラベルを追加および書式設定し、より魅力的なスライドを作成する方法を学びます。"
---
## **はじめに**

データ ラベルはチャートの系列や個々のデータ ポイントに関する情報を表示し、読者が値を特定しチャートを理解するのに役立ちます。本記事では、値の書式設定、パーセンテージの表示、ラベルテキストの取得、軸の最大値を超えたラベルの制御、カテゴリ軸ラベルの間隔調整、円グラフラベルの位置設定について説明します。

## **チャート データ ラベルの数値精度を設定する**

Use [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) to format series values. This example creates a line chart with default data, displays its data table, and enables value labels for the first series. The format `#,##0.00` displays a thousands separator and two decimal places without changing the underlying values.

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

To format the numeric cells in a chart's embedded workbook, see [ワークブック セルのカスタム数値形式を設定](/slides/ja/net/chart-workbook/#set-custom-number-formats-for-workbook-cells). That example also shows value labels following their source cell formats while preserving the stored numeric values.

## **ラベルとしてパーセンテージを表示する**

For a stacked column chart, calculate each value as a percentage of its category total and assign the text to [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). This example uses the default chart data and displays percentages with two decimal places in an 8-point font. Categories with a total of zero are skipped to avoid division by zero. Recalculate the custom label text if the chart data changes.

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

## **チャート データ ラベルでパーセンテージ記号を設定する**

When values are stored as fractions, use [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) to display percentages. Set [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) to `false` to apply the label format independently of the source cells.

This example creates a 100% stacked column chart with red and blue series across four categories. Each pair of values adds up to 1. The label format `0.0%` displays 0.30 as 30.0%, while the vertical axis uses two decimal places. Both series use white, 10-point label text.

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

## **データ ラベルの実際のテキストを取得する**

Use [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) to retrieve the text produced by a data label's settings. This is useful when extracting labels for reports, searching presentation content, or validating generated charts. In the example below, the default [データ ラベル形式](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) combines each category name, series name, and value. One point formats its value as a percentage, and another uses custom text from [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).

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

The number stored in a data point remains `0.75`, even when its label shows `75%` along with the category and series names. Custom text replaces the generated label text. [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) returns the resulting label string in either case. Check [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) separately, as shown above, when you want to extract only visible labels.

## **軸の最大値を超えたデータ ラベルを制御する**

When you limit an axis range manually, some data points may exceed its maximum. Use [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) to control whether their data labels are shown. This setting changes label visibility; it does not change the axis range or the underlying data values.

The example below creates a 2D clustered column chart with values of 60 and 120. It sets [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) to `false` and [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) to 100 on the vertical axis. The first slide allows labels beyond the maximum; a copy of that slide disables them. Both slides are saved in `DataLabelsOverMaximum.pptx`.

Enable value labels with [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). The chart-level setting does not enable value display by itself or override an individual label's disabled value display. This example enables values for the entire series and uses [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) to place labels at the outside end of each column.

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

The following images show the saved slides rendered by Microsoft PowerPoint. With `true`, the label **120** is visible at the upper boundary; with `false`, it is hidden. The label **60** remains visible, the axis maximum stays at **100**, and the second data point remains **120** in both cases.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![軸の最大値が100の状態で、値ラベル120を表示するPowerPointチャート](data-labels-over-maximum-true.png) | ![軸の最大値が100の状態で、値ラベル120を非表示にするPowerPointチャート](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
This example uses a 2D column chart with a value axis. Charts without a value axis, such as pie and doughnut charts, do not have an axis maximum to limit in this way.
{{% /alert %}}

## **軸からのラベル距離を設定する**

Use [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) to control the distance between category axis labels and the axis. The value is a percentage of the maximum font size of the axis labels. This example creates a clustered column chart and sets the horizontal axis label offset to 500. This setting affects category axis labels rather than labels attached to individual data points.

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

## **ラベル位置を調整する**

On a pie chart, adjust data label positions to improve spacing and make room for leader lines.

This example displays the value of the first data point, places its label outside the slice, and adjusts its [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) and [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) offsets. These offsets are relative to the chart width and height, respectively.

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

![調整されたデータ ラベル位置を持つ円グラフ](pie-chart-adjusted-label.png)

## **リーダーラインの書式設定**

When pie chart labels sit outside their slices, leader lines help readers match each value to the correct slice. A contrasting color and a slightly thicker line can make these connections easier to follow, while transparency and a dashed style keep the lines visually unobtrusive.

Use [LeaderLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabelcollection/leaderlinesformat/) to format leader lines at the series' data label collection level. The settings in `series.Labels.LeaderLinesFormat.Line` apply to the collection, rather than to an individual label.

This example creates a pie chart with default data, displays values outside the slices, and enables [ShowLeaderLines](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showleaderlines/). It moves two labels farther from their slices using [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) and [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) offsets, expressed as fractions of the chart width and height. No input presentation is required.

The line's [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) sets a solid blue color with an alpha value of 191 out of 255, giving approximately 25% transparency. [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) sets the thickness to 2 points, and [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) makes the line dashed.

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

// 2つのラベルをスライスからさらに離します。
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

Enabling leader lines does not guarantee that a line will appear for every label. Visibility depends on label placement and the chart's layout behavior. In this example, the two displaced labels have visible leader lines; the labels that remain close to their slices do not need them.

The following image shows the saved `FormattedLeaderLines.pptx` rendered with Aspose.Slides:

![円グラフの外側ラベルを2つ接続する、青く半透明で破線のリーダーライン付きイメージ](formatted-leader-lines.png)

## **列チャートの上に複数行のデータ ラベルを追加する**

This example creates a column chart with two rows of data labels above the plot area. Series A displays the visible columns, while Series B and Series C provide the additional labels. Their columns are hidden by removing the fill and outline. The [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) property aligns all three series with the same category centers.

The [PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) settings reserve space for the label rows. After [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) calculates the default positions, [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) and [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) preserve the horizontal alignment and apply vertical offsets to arrange the labels in two rows. The numbers remain data labels linked to the series values; only the row headings are separate text shapes.

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
        // B と C の列を非表示にしますが、データ ラベルは残します。
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

// 3 つの系列すべてを同じカテゴリ中心に揃えます。
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// このコンパクトな例のために目盛線を減らします。
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// プロット上部にデータ ラベル用の 2 行分のスペースを確保します。
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
        // デフォルトの水平位置を保持します。Y は以下からのオフセットです。
        // デフォルト ラベル位置で、チャート高さの割合で表されます。
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // 行見出しだけが別個のテキスト シェイプです。
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

![プロット領域の上に2行のデータ ラベルがある列チャート](multiple-rows-of-labels.png)

## **よくある質問**

**密集したチャートでデータラベルが重なるのを防ぐには？**

自動ラベル配置、リーダーライン、フォントサイズの縮小を組み合わせ、必要に応じて一部の項目（例: カテゴリ）を非表示にするか、極端な値や重要ポイントのみにラベルを表示します。

**0、負、または空の値に対してのみラベルを無効にするには？**

ラベルを有効化する前にデータポイントをフィルタリングし、0、負の値、または欠損値に対して表示をオフにするルールを適用します。

**PDF/画像へエクスポートする際にラベルスタイルを一貫させるには？**

フォントファミリとサイズを明示的に設定し、レンダリング環境にフォントが存在することを確認してフォールバックを防止します。