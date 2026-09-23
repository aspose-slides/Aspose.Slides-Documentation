---
title: .NET でプレゼンテーションのチャート データラベルを管理する
linktitle: データラベル
type: docs
url: /ja/net/chart-data-label/
keywords:
- チャート
- データラベル
- データ精度
- パーセンテージ
- ラベル間距離
- ラベル位置
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint プレゼンテーションにチャート データラベルを追加および書式設定し、より魅力的なスライドを作成する方法を学びます。"
---
## **はじめに**

データラベルはチャートの系列や個々のデータポイントに関する情報を表示し、読者が値を特定しチャートを理解するのに役立ちます。本記事では、値の書式設定、パーセンテージの表示、ラベルテキストの取得、カテゴリ軸ラベルの間隔調整、円グラフラベルの位置設定方法について解説します。

## **チャート データラベルの数値精度を設定する**

[NumberFormatOfValues](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseries/numberformatofvalues/) を使用して系列の値の書式を設定します。この例はデフォルト データで折れ線グラフを作成し、データ テーブルを表示し、最初の系列の値ラベルを有効にします。書式 `#,##0.00` は千区切りと小数点以下 2 桁を表示しますが、元の数値は変更されません。

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

## **ラベルにパーセンテージを表示する**

積み上げ縦棒グラフの場合、各値をカテゴリ合計に対するパーセンテージに換算し、そのテキストを [TextFrameForOverriding](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) に割り当てます。この例はデフォルトのチャート データを使用し、2 桁の小数でパーセンテージを表示し、フォントサイズを 8 ポイントに設定します。合計がゼロのカテゴリは除外して除算エラーを防ぎます。チャート データが変更された場合は、カスタム ラベル テキストを再計算してください。

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

## **チャート データラベルにパーセンテージ記号を設定する**

値が分数で格納されている場合は、[NumberFormat](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/idatalabelformat/numberformat/) を使用してパーセンテージとして表示します。[IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) を `false` に設定すると、元セルに依存せずラベル書式を適用できます。

この例は 4 つのカテゴリに対して赤と青の系列を持つ 100% 積み上げ縦棒グラフを作成します。各ペアの値の合計は 1 です。ラベル書式 `0.0%` は 0.30 を 30.0% と表示し、縦軸は小数点以下 2 桁を使用します。両系列とも白色で 10 ポイントのラベル テキストを使用します。

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

## **データラベルの実際のテキストを取得する**

[GetActualLabelText](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/idatalabel/getactuallabeltext/) を使用すると、データラベルの設定から生成されたテキストを取得できます。レポート用にラベルを抽出したり、プレゼンテーション コンテンツを検索したり、生成されたチャートの検証を行う際に便利です。以下の例では、デフォルトの [data label format](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/idatalabelformat/) が各カテゴリ名、系列名、値を結合します。あるポイントは値をパーセンテージで書式設定し、別のポイントは [TextFrameForOverriding](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) からのカスタム テキストを使用します。

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

データポイントに格納されている数値は `0.75` のままで、ラベルが `75%` とカテゴリ名や系列名と共に表示されても変わりません。カスタム テキストは生成されたラベル テキストを置き換えます。[GetActualLabelText](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/idatalabel/getactuallabeltext/) はどちらの場合でも結果のラベル文字列を返します。表示されているラベルだけを抽出したい場合は、上記のように [IsVisible](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/idatalabel/isvisible/) を別途確認してください。

## **軸からのラベル間隔を設定する**

[LabelOffset](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/iaxis/labeloffset/) を使用して、カテゴリ軸ラベルと軸との距離を制御します。値は軸ラベルの最大フォントサイズに対するパーセンテージです。この例は集合縦棒グラフを作成し、水平軸ラベルオフセットを 500 に設定します。この設定は個々のデータポイントに付随するラベルではなく、カテゴリ軸ラベルに適用されます。

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

円グラフでは、データラベルの位置を調整して間隔を確保し、リーダー ラインのための余白を作ります。

この例は最初のデータポイントの値を表示し、ラベルをスライスの外側に配置し、[X](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ilayoutable/x/) と [Y](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ilayoutable/y/) オフセットを調整します。これらのオフセットはそれぞれチャートの幅と高さに対する相対値です。

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

![調整されたデータラベル位置の円グラフ](pie-chart-adjusted-label.png)

## **FAQ**

**密集したチャートでラベルが重なるのを防ぐにはどうすればよいですか？**

自動ラベル配置、リーダー ライン、フォントサイズの縮小を組み合わせ、必要に応じて一部の項目（例: カテゴリ）を非表示にするか、極端な値や重要なポイントだけにラベルを表示します。

**ゼロ、負、または空の値に対してのみラベルを無効にするにはどうすればよいですか？**

ラベルを有効にする前にデータポイントをフィルタリングし、0、負の値、または欠損値に対して表示をオフにするルールを設定します。

**PDF/画像にエクスポートする際にラベルスタイルを一貫させるにはどうすればよいですか？**

フォントファミリとサイズを明示的に設定し、レンダリング環境にフォントが存在することを確認してフォールバックを防止します。