---
title: .NET のプレゼンテーションでチャート データ ラベルを管理する
linktitle: データ ラベル
type: docs
url: /ja/net/chart-data-label/
keywords:
- チャート
- データ ラベル
- データ 精度
- パーセンテージ
- ラベル 距離
- ラベル 位置
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint プレゼンテーションにチャート データ ラベルを追加および書式設定し、より魅力的なスライドを作成する方法を学びます。"
---
## **概要**

データ ラベルはチャートの系列や個々のデータ ポイントに関する情報を表示し、読者が値を特定しチャートを理解できるようにします。本記事では、値の書式設定、パーセンテージの表示、ラベル テキストの取得、軸の最大値を超えるラベルの制御、カテゴリ軸ラベルの間隔調整、円グラフラベルの位置指定方法について説明します。

## **チャート データ ラベルの数値精度を設定する**

[NumberFormatOfValues](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseries/numberformatofvalues/) を使用して系列の値を書式設定します。この例は既定のデータで折れ線グラフを作成し、データテーブルを表示し、最初の系列に値ラベルを有効にします。書式 `#,##0.00` は千区切りと小数点以下 2 桁を表示しますが、基になる値は変更しません。

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

## **パーセンテージをラベルとして表示する**

積み上げ縦棒グラフの場合、各値をカテゴリ合計に対するパーセンテージに換算し、[TextFrameForOverriding](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) にテキストとして割り当てます。この例は既定のチャート データを使用し、8 ポイント フォントで小数点以下 2 桁のパーセンテージを表示します。合計が 0 のカテゴリは除外され、ゼロ除算を回避します。チャート データが変更された場合はカスタム ラベル テキストを再計算してください。

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

## **チャート データ ラベルにパーセンテージ記号を設定する**

値が分数で保存されている場合、[NumberFormat](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/idatalabelformat/numberformat/) を使用してパーセンテージを表示します。[IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) を `false` に設定すると、ラベルの書式が元セルとは独立して適用されます。

この例は 4 つのカテゴリに対し、赤と青の系列を持つ 100% 積み上げ縦棒グラフを作成します。各ペアの値の合計は 1 です。ラベル書式 `0.0%` は 0.30 を 30.0% と表示し、縦軸は小数点以下 2 桁を使用します。両系列とも白色の 10 ポイント ラベル テキストを使用します。

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

[GetActualLabelText](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/idatalabel/getactuallabeltext/) を使用して、データ ラベルの設定から生成されたテキストを取得できます。レポート用ラベル抽出、プレゼンテーション コンテンツ検索、生成されたチャートの検証などに便利です。下の例では、既定の[data label format](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/idatalabelformat/) がカテゴリ名、系列名、値を組み合わせます。あるポイントは値をパーセンテージで書式設定し、別のポイントは[TextFrameForOverriding](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) から取得したカスタム テキストを使用します。

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

データ ポイントに格納された数値は `0.75` のままですが、ラベルはカテゴリ名と系列名とともに `75%` と表示されます。カスタム テキストは生成されたラベル テキストを置き換えます。[GetActualLabelText](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/idatalabel/getactuallabeltext/) はどちらの場合でも最終的なラベル文字列を返します。表示ラベルのみを抽出したい場合は、上記のように [IsVisible](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/idatalabel/isvisible/) を別途チェックしてください。

## **軸の最大値を超えるデータ ラベルを制御する**

軸範囲を手動で限定すると、一部のデータ ポイントが最大値を超えることがあります。[ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) を使用して、超過したラベルを表示するかどうかを制御します。この設定はラベルの可視性のみを変更し、軸範囲や基になるデータ値は変更しません。

以下の例は、値が 60 と 120 の 2D クラスタ化縦棒グラフを作成し、縦軸の [IsAutomaticMaxValue](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) を `false`、[MaxValue](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/iaxis/maxvalue/) を 100 に設定します。最初のスライドは最大値を超えるラベルを許可し、コピーしたスライドでは無効にしています。両スライドは `DataLabelsOverMaximum.pptx` に保存されます。

[ShowValue](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/idatalabelformat/showvalue/) で値ラベルを有効にします。チャート レベルの設定だけでは個別ラベルの表示が有効になるわけではなく、個別ラベルが無効化されている場合は上書きされません。この例では系列全体に値を有効にし、[Position](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/idatalabelformat/position/) を使用して各柱の外側端にラベルを配置します。

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

以下の画像は Microsoft PowerPoint でレンダリングされた保存スライドを示します。`true` の場合、ラベル **120** が上端の境界で表示され、`false` の場合は非表示になります。ラベル **60** は常に表示され、軸最大値は **100** のままで、2 番目のデータ ポイントはどちらの場合も **120** のままです。

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
この例は値軸を持つ 2D 縦棒グラフを使用しています。円グラフやドーナツ グラフなど値軸を持たないチャートには、ここで説明したような軸最大値の制限はありません。
{{% /alert %}}

## **ラベルと軸の距離を設定する**

[LabelOffset](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/iaxis/labeloffset/) を使用して、カテゴリ軸ラベルと軸との距離を制御します。値は軸ラベルの最大フォントサイズのパーセンテージで指定します。この例はクラスタ化縦棒グラフを作成し、横軸ラベルのオフセットを 500 に設定します。この設定は個々のデータ ポイントに付随するラベルではなく、カテゴリ軸ラベルに影響します。

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

円グラフでは、データ ラベルの位置を調整して間隔を広げ、リーダー ラインの余裕を確保します。

この例は最初のデータ ポイントの値を表示し、ラベルをスライスの外側に配置し、[X](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ilayoutable/x/) と [Y](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ilayoutable/y/) のオフセットを調整します。これらのオフセットはそれぞれチャートの幅と高さに対する相対値です。

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

## **FAQ**

**密集したチャートでデータ ラベルの重なりを防ぐにはどうすればよいですか？**

自動ラベル配置、リーダー ライン、フォントサイズ縮小を組み合わせ、必要に応じてカテゴリなどのフィールドを非表示にするか、極端な値や重要ポイントのみラベルを表示します。

**値が 0、負、または空の場合にのみラベルを無効にするにはどうすればよいですか？**

ラベルを有効にする前にデータ ポイントをフィルタリングし、0、負の値、欠損値に対して表示をオフにするルールを適用します。

**PDF/画像にエクスポートした際にラベルスタイルを一貫させるにはどうすればよいですか？**

フォントファミリとサイズを明示的に設定し、レンダリング環境にフォントが存在することを確認してフォールバックを防止します。