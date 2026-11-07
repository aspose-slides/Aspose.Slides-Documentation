---
title: .NET のプレゼンテーションでチャート データ ラベルを管理
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
description: "PowerPoint プレゼンテーションで Aspose.Slides for .NET を使用してチャート データ ラベルを追加および書式設定し、より魅力的なスライドを作成する方法を学びます。"
---
## **はじめに**

データ ラベルはチャート シリーズや個々のデータ ポイントに関する情報を表示し、読者が値を特定しチャートを理解するのに役立ちます。本記事では、値の書式設定、パーセンテージの表示、ラベル テキストの読み取り、軸の最大値を超えるラベルの制御、カテゴリ軸ラベル間隔の調整、円グラフ ラベルの位置決め方法について説明します。

## **表示されているデータ ラベルの数をカウント**

プレゼンテーションを公開する前に、表示が有効になっているデータ ラベルの数を確認するには[CountOfVisibleDataLabels](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/countofvisibledatalabels/)を使用します。[Count](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/count/) がコレクション内のラベル総数を返すのとは異なり、こちらはシリーズのデフォルト設定と個々のラベル設定を考慮します。

この例は、1 つのシリーズと 3 つのデータ ポイントを持つ縦棒グラフを作成します。シリーズの[Labels](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/labels/)コレクションにアクセスし、設定が変化するたびに表示されている数を出力します: **0, 3, 2, 3**。総数は **3** のままです。

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
Console.WriteLine($"Total: {labels.Count}; visible: {labels.CountOfVisibleDataLabels}"); // 合計: 3; 表示: 0

labels.DefaultDataLabelFormat.ShowValue = true;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // 表示: 3

labels[1].DataLabelFormat.ShowValue = false;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // 表示: 2

labels[1].DataLabelFormat.ShowLegendKey = true;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // 表示: 3
```

シリーズの[DefaultDataLabelFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/defaultdatalabelformat/) はデフォルト設定を提供します。そこで[ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) を有効にすると、3 つすべてのラベルに値が表示されます。1 つのラベルの[DataLabelFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/datalabelformat/) で `false` に設定すると、そのラベルだけ設定が上書きされます。[ShowLegendKey](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showlegendkey/) を有効にすると、そのラベルは再び表示対象となります（値は非表示のまま）。

表示カウントは可視性設定を反映します。ラベルが重なっているか、切り取られているか、描画されたチャートで読み取れるかどうかは測定しません。

## **チャート データ ラベルの数値精度を設定**

シリーズの値をフォーマットするには[NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) を使用します。この例はデフォルト データで折れ線グラフを作成し、データ テーブルを表示し、最初のシリーズに値ラベルを有効にします。フォーマット `#,##0.00` は千区切りと小数点以下 2 桁を表示し、基になる値は変更しません。

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

チャートに埋め込まれたワークブックの数値セルをフォーマットする方法は[Set Custom Number Formats for Workbook Cells](/slides/ja/net/chart-workbook/#set-custom-number-formats-for-workbook-cells) を参照してください。その例では、ソース セルのフォーマットに従いながら、格納されている数値はそのまま保持した状態で値ラベルが表示されます。

## **パーセンテージをラベルとして表示**

積み上げ縦棒グラフの場合、各値をカテゴリ合計に対するパーセンテージとして計算し、テキストを[TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) に割り当てます。この例はデフォルトのチャート データを使用し、8 ポイント フォントで小数点以下 2 桁のパーセンテージを表示します。合計が 0 のカテゴリは除外して除算エラーを回避します。チャート データが変更された場合はカスタム ラベル テキストを再計算してください。

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

## **チャート データ ラベルにパーセンテージ記号を付ける**

値が分数として格納されている場合、[NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) を使用してパーセンテージを表示します。[IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) を `false` に設定すると、ラベルの書式がソースセルとは独立して適用されます。

この例は、4 つのカテゴリにわたる赤と青のシリーズを持つ 100% 積み上げ縦棒グラフを作成します。各ペアの値は合計で 1 になります。ラベル書式 `0.0%` は 0.30 を 30.0% と表示し、垂直軸は小数点以下 2 桁を使用します。両シリーズとも白色の 10 ポイント ラベル テキストを使用します。

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

## **データ ラベルの実際のテキストを取得**

[GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) を使用すると、データ ラベルの設定によって生成されたテキストを取得できます。これは、レポート用にラベルを抽出したり、プレゼンテーション コンテンツを検索したり、生成されたチャートを検証したりする際に便利です。以下の例では、デフォルトの[data label format](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) が各カテゴリ名、シリーズ名、値を組み合わせます。1 点は値をパーセンテージとしてフォーマットし、別の点は[TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) からのカスタム テキストを使用します。

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

データ ポイントに格納されている数値は `0.75` のままで、ラベルが `75%` とカテゴリ名・シリーズ名を併せて表示しても同様です。カスタム テキストは生成されたラベル テキストを置き換えます。[GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) はどちらの場合でも結果のラベル文字列を返します。ラベルが表示されているかだけを抽出したい場合は、上記と同様に[IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) を個別に確認してください。

## **軸の最大値を超えるデータ ラベルを制御**

軸範囲を手動で制限すると、一部のデータ ポイントが最大値を超えることがあります。[ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) を使用して、これらのデータ ラベルを表示するかどうかを制御します。この設定はラベルの可視性を変更しますが、軸範囲や基になるデータ値は変更しません。

以下の例は、値が 60 と 120 の 2D クラスタ化縦棒グラフを作成します。縦軸の[IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) を `false`、[MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) を 100 に設定します。最初のスライドは最大値を超えるラベルを許可し、コピーしたスライドはそれを無効にします。両スライドは `DataLabelsOverMaximum.pptx` として保存されます。

[ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) で値ラベルを有効にします。チャートレベルの設定だけでは値の表示は自動的に有効にならず、個々のラベルで無効化された表示を上書きもしません。この例では、シリーズ全体に値を有効にし、[Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) を使用して各列の外側端にラベルを配置します。

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

以下の画像は、Microsoft PowerPoint でレンダリングされた保存スライドを示します。`true` の場合、ラベル **120** が上端に表示され、`false` の場合は非表示になります。ラベル **60** は表示されたままで、軸の最大値は **100** のまま、2 番目のデータ ポイントはどちらの場合も **120** です。

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
この例は、値軸を持つ 2D 縦棒グラフを使用しています。円グラフやドーナツ グラフなど値軸のないチャートは、この方法で軸の最大値を制限できません。
{{% /alert %}}

## **軸からラベルまでの距離を設定**

[LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) を使用してカテゴリ軸ラベルと軸間の距離を制御します。値は軸ラベルの最大フォント サイズのパーセンテージです。この例はクラスタ化縦棒グラフを作成し、水平軸ラベルのオフセットを 500 に設定します。この設定は個々のデータ ポイントに付随するラベルではなく、カテゴリ軸ラベルに影響します。

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

## **ラベルの位置を調整**

円グラフでは、データ ラベルの位置を調整して間隔を広げ、リーダー線の余地を作ります。

この例は最初のデータ ポイントの値を表示し、ラベルをスライスの外側に配置し、[X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) と [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) のオフセットを調整します。これらのオフセットはそれぞれチャートの幅と高さの比率です。

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

## **リーダー線の書式設定**

円グラフのラベルがスライスの外側にある場合、リーダー線は各値を正しいスライスに結び付けるのに役立ちます。コントラストのある色とやや太い線は接続を見やすくし、透明度と破線スタイルは視覚的な邪魔になりません。

[LeaderLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabelcollection/leaderlinesformat/) を使用して、シリーズのデータ ラベル コレクションレベルでリーダー線をフォーマットします。`series.Labels.LeaderLinesFormat.Line` の設定は個々のラベルではなくコレクション全体に適用されます。

この例はデフォルト データの円グラフを作成し、スライスの外側に値を表示し、[ShowLeaderLines](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showleaderlines/) を有効にします。[X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) と [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) のオフセットで2つのラベルをスライスから遠ざけ、オフセットはチャート幅と高さの割合で指定します。入力プレゼンテーションは不要です。

線の[FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) は、アルファ値 191（255 中の約 25% の透明度）で青の単色を設定します。[Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) は太さを 2 ポイントにし、[DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) で破線にします。

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

// 2 つのラベルをスライスからより遠くに移動します。
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

リーダー線を有効にしても、すべてのラベルに線が表示されるわけではありません。可視性はラベルの配置とチャートのレイアウト動作に依存します。この例では、離れた 2 つのラベルにリーダー線が表示され、スライスに近いラベルは必要ありません。

以下の画像は、Aspose.Slides でレンダリングされた保存ファイル `FormattedLeaderLines.pptx` を示します。

![Pie chart with blue, semitransparent dashed leader lines connecting two outside labels to their slices](formatted-leader-lines.png)

## **縦棒グラフの上部に複数行のデータ ラベルを追加**

この例は、プロット領域の上部に 2 行のデータ ラベルを持つ縦棒グラフを作成します。Series A は表示される列を担当し、Series B と Series C が追加ラベルを提供します。列は塗りつぶしと枠線を削除して非表示にします。[Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) プロパティにより、3 つのシリーズすべてが同じカテゴリ中心に揃えられます。

[PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) の設定でラベル行のスペースを確保します。[ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) がデフォルト位置を計算した後、[X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) と [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) が水平揃えを保持し、垂直オフセットでラベルを 2 行に配置します。数値はシリーズの値にリンクされたデータ ラベルのままで、行見出しだけが別個のテキスト シェイプです。

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
        // B と C の列を非表示にしますが、データ ラベルは保持します。
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

// 3 つのシリーズすべてを同じカテゴリ中心に揃えます。
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// このコンパクトな例ではグリッド線を少なくします。
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
        // デフォルトの水平位置を保持します。Y は
        // デフォルトのラベル位置からのオフセットで、チャートの高さの割合として表されます。
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

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **データ ラベルの形状を変更**

Aspose.Slides for .NET 26.11 では、シリーズ内の現在のラベルすべてに対して[IDataLabel.LabelShapeType](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/labelshapetype/) と[IDataLabelCollection.DefaultLabelShapeType](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/defaultlabelshapetype/) が追加されました。これらはラベルの形状を変更し、ポイント マーカーは変更しません。個別の吹き出し設定については[Data Label Callouts](/slides/ja/net/callout/) を参照してください。

コレクションへの割り当ては既存ラベルを更新するため、個別の上書きはコレクション設定の**後**に適用します。この完全な例は[Aspose.Slides for .NET](/slides/ja/net/installation/) 26.11 以降が必要です。可視値ラベルを作成し、最初のシリーズに楕円形を選択し、続いて最初のラベルを矩形に変更します。

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

// すべての現在のラベルの明示的な形状選択をリセットします。
labels.DefaultLabelShapeType = ShapeType.NotDefined;
presentation.Save("label-shapes-reset.pptx", SaveFormat.Pptx);
```

コレクション形状を再度割り当てると、以前の個別形状選択も置き換わります。[NotDefined](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) は明示的な形状選択をクリアしますが、ラベルを非表示にしたり他の書式設定を消去したりはしません。形状はシリーズのポピュレート後に設定し、後で追加されたポイントが以前の割り当てを継承すると想定しないでください。ここでは矩形と楕円を使用しています。別の形状タイプを選択する場合は、レンダリング結果を確認してください。

## **FAQ**

**密なチャートでラベルの重なりを防止するにはどうすればよいですか？**

自動ラベル配置、リーダー線、フォント サイズの縮小を組み合わせ、必要に応じていくつかの項目（例: カテゴリ）を非表示にするか、極端な値や重要ポイントのみにラベルを表示します。

**ゼロ、負の値、または空の値に対してのみラベルを無効にするにはどうすればよいですか？**

ラベルを有効化する前にデータ ポイントをフィルタリングし、0、負の値、または欠損値に対して表示をオフにするルールを適用します。

**PDF/画像へエクスポートする際にラベルのスタイルを一貫させるにはどうすればよいですか？**

フォント ファミリとサイズを明示的に設定し、レンダリング環境にフォントが利用可能であることを確認してフォールバックを防止します。