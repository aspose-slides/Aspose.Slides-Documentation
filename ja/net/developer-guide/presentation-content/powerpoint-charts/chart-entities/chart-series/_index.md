---
title: ".NET でのプレゼンテーションにおけるチャート データ シリーズの管理"
linktitle: "データ シリーズ"
type: docs
url: /ja/net/chart-series/
keywords:
- "チャート シリーズ"
- "シリーズ オーバーラップ"
- "シリーズ カラー"
- "カテゴリ カラー"
- "シリーズ 名"
- "データ ポイント"
- "シリーズ ギャップ"
- "PowerPoint"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "C# を使用して、プレゼンテーション内でチャート シリーズ、データ ポイント、ワークブック セル、書式設定、オーバーラップ、ギャップ幅、負の値を管理する方法を学びます。"
---
## **概要**

チャートはプロットされたデータをチャート データ ワークブックに保存します。[IChartSeries](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseries/) は関連する値のセットを表し、シリーズ内の各 [IChartDataPoint](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatapoint/) は 1 つ以上のワークブック セルを参照します。[IChartCategory](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartcategory/) オブジェクトはシリーズが共有するラベルまたはグループ化値を提供します。そのため、シリーズ名、カテゴリ、ポイント値は [IChartDataCell](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatacell/) オブジェクトに接続されており、表示テキストだけに保存されるわけではありません。

典型的なカテゴリ チャートの場合、デフォルトのワークブックは行 0 にシリーズ名、列 0 にカテゴリ名、残りのセルにシリーズ値を使用します。[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdataworkbook/getcell/) に渡すワークシート、行、列のインデックスはゼロベースです。このレイアウトはデフォルト データでチャートを作成するときに便利ですが、既存のすべてのチャートがこの構成を使用しているとは限りません。プレゼンテーションを読み込む場合は、ワークブックの値を変更する前に、シリーズ、カテゴリ、データ ポイントが参照しているセルを確認してください。

チャート設定には 3 つの異なるスコープがあります。

- シリーズ レベルの設定（例: [IChartSeries.Format](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseries/format/)）は、1 つのシリーズ内のすべてのポイントの既定の外観を提供します。
- データ ポイント設定（例: [IChartDataPoint.Format](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatapoint/format/)）は、1 つのポイントに対してシリーズの外観を上書きします。
- グループ設定は、同じ [IChartSeriesGroup](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseriesgroup/) に属する互換性のあるシリーズに適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseries/parentseriesgroup/) を使用してグループにアクセスしてください。

明示的なポイントまたはシリーズの塗りつぶしが設定されていない場合、チャート スタイルとテーマが自動外観を決定します。シリーズの書式設定とポイントの書式設定の両方が存在する場合、ポイントの書式設定がそのポイントに対して優先されます。

![チャートシリーズ PowerPoint](chart-series-powerpoint.png)

## **チャート シリーズのオーバーラップを設定する**

[IChartSeries.Overlap](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseries/overlap/) は 2D チャートでバーまたは列がどれだけオーバーラップするかを -100〜100 パーセントで報告します。これは親シリーズ グループの設定の読み取り専用投影です。グループ内のすべての互換シリーズを更新するには、[IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseriesgroup/overlap/) を設定します。このオプションはグループ化されたバーまたは列を表示するチャート タイプに適用され、組み合わせチャートの無関係なシリーズ グループには影響しません。

以下の例は、最初のシリーズが含まれるグループのオーバーラップを設定します。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// 新しいチャートにはサンプルのシリーズ、カテゴリ、および値が含まれます。
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

結果:

![シリーズのオーバーラップ](series_overlap.png)

## **シリーズの塗りつぶし色を変更する**

[IChartSeries.Format](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseries/format/) を使用して、シリーズ全体の既定の塗りつぶしを設定します。ポイントに既に明示的な塗りつぶしがある場合、その [IChartDataPoint.Format](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatapoint/format/) 設定がそのポイントのシリーズ塗りつぶしを上書きします。

以下の例は、最初のシリーズに単色の青色塗りつぶしを適用します。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Blue;

presentation.Save("series_color.pptx", SaveFormat.Pptx);
```

結果:

![シリーズの色](series_color.png)

## **シリーズ名を変更する**

シリーズ名はチャート データ ワークブックに格納され、通常は凡例に表示されます。クラスター化された列チャート用にデフォルトで作成されたワークブックでは、セル B1 は行 0、列 1 にあり、最初のシリーズ名が格納されています。以下の例の名前付き定数はその構造を明示的に示しています。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesNameCell = workbook.GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

また、[IChartSeries.Name](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseries/name/) が参照しているセルを直接更新することもできます。この方法は、既存のチャートで特定の行や列を前提としないため安全です。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var seriesNameCell = series.Name.AsCells[firstNameCellIndex];
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

結果:

![シリーズ名](series_name.png)

## **自動シリーズ塗りつぶし色を取得する**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) は、シリーズインデックスとチャート スタイルから計算された色を返します。これは、シリーズの塗りつぶしが明示的に定義されていない場合に使用される色です。このメソッドは計算された色を取得するだけで、塗りつぶしを新たに設定するわけではありません。

以下の例は、デフォルトシリーズそれぞれの自動色を出力します。

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

const int firstSlideIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var seriesCount = chart.ChartData.Series.Count;
for (var seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    var automaticColor = series.GetAutomaticSeriesColor();
    Console.WriteLine($"Series {seriesIndex}: {automaticColor.Name}");
}
```

デフォルトのチャート スタイルに対するサンプル出力:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

正確な色はチャート スタイルとテーマに依存します。

## **シリーズの反転塗りつぶし色を設定する**

バー、列、バブルシリーズの場合、[IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseries/invertifnegative/) を使用すると、負の値を別の塗りつぶしで表示できます。通常のシリーズ塗りつぶしを単色に設定し、反転を有効にし、負の値の色を [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) で指定します。ワークブック内の負の数値は変更されず、表示色だけが変わります。

以下の例は、デフォルトのチャート データを 1 系列に置き換えます。ワークシートの行 0 にシリーズ名、列 0 にカテゴリ名、列 1 に値が格納されます。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;

var categoryNames = new[] { "Category 1", "Category 2", "Category 3" };
var seriesValues = new[] { -20, 50, -30 };

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
var series = chartData.Series.Add(seriesNameCell, chart.Type);

for (var categoryIndex = 0; categoryIndex < categoryNames.Length; categoryIndex++)
{
    var dataRowIndex = firstDataRowIndex + categoryIndex;
    var categoryName = categoryNames[categoryIndex];
    var seriesValue = seriesValues[categoryIndex];

    var categoryCell = workbook.GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
    chartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertIfNegative = true;
series.InvertedSolidFillColor.Color = Color.Red;

presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
```

結果:

![反転単色塗りつぶし色](inverted_solid_fill_color.png)

1 つのポイントだけ反転させるには、[IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) を使用します。以下の例では、シリーズ全体の反転は無効にし、選択したポイントだけ反転を有効にしています。ポイントには負の値も割り当てているため、効果が確認できます。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertedSolidFillColor.Color = Color.Red;
series.InvertIfNegative = false;

var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = negativeValue;
dataPoint.InvertIfNegative = true;

presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
```

## **特定のデータ ポイントの値をクリアする**

ポイントを削除せずに空にしたい場合は、バックアップしているワークブック セルを `null` に設定します。列チャートの場合、プロットされた値は [IChartDataPoint.YValue](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatapoint/yvalue/) で取得できます。データ ポイントは同じカテゴリ位置に残りますが、チャートはブランク値設定に従ってその値を空として扱います。

以下の例は、最初のシリーズの 2 番目のポイントだけをクリアします。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = null;

presentation.Save("clear_data_point_value.pptx", SaveFormat.Pptx);
```

散布図は X と Y のセルが別々に、バブル チャートはサイズセルも使用します。削除したい値に対応するセルだけをクリアしてください。ポイントのコレクション全体を削除したいとき以外は、[IChartDataPointCollection.Clear](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatapointcollection/clear/) を呼び出さないでください。これはすべてのデータ ポイントを削除します。

## **空セルの表示方法を制御する**

空のワークブック セルはデータ欠損を表し、`0` が入ったセルは既知の数値を表します。セルを空にしたい場合は、[IChartDataCell.Value](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatacell/value/) を `null` に設定します。数値のゼロはブランク設定に関係なくゼロのままです。

[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichart/displayblanksas/) を使用して、チャートが空セルをどのように表示するかを選択できます。この設定はチャート全体に適用され、ブランクをゼロや補間値で埋めることなく描画方法を変更します。

以下の単体例は、1 系列の折れ線グラフを作成し、Day 3 の値をクリアし、各モードで同じチャートを保存します。入力ファイルは不要です。[IChartDataWorkbook](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdataworkbook/) はシート 0、列 0 にカテゴリ ラベル、列 1 に値を使用し、行 0 にシリーズ名を格納します。最終データは `10, 20, empty, 30, 40` です。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(0, 0, 1, "Measurements");
var series = chartData.Series.Add(seriesNameCell, chart.Type);
var values = new[] { 10, 20, 25, 30, 40 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Day {i + 1}");
    chartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Leave Day 3 genuinely empty, while retaining its category and data point.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

各出力ファイルは保存前に設定したモードを名前に持ちます: `empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 つのバージョンだけを保存したい場合は、目的のモードを設定してプレゼンテーションを 1 回保存すれば済みます。

以下の比較は 3 つのファイルすべてで同じデータがどのように表示されるかを示しています。Day 3 はすべてのワークブックで空です。

![同一データの折れ線チャート: Gap は Day 3 で線を切り、Zero は線を 0 に落とし、Span は Day 2 と Day 4 を接続します。](display_blanks_as.png)

可視効果はチャート タイプに依存します。折れ線チャートは 3 つのモードを比較しやすいですが、バーや列のチャートは欠損カテゴリをつなげる線がないため、`Span` は上記のような接続セグメントを生成できません。欠損列とゼロ高さの列は見た目が似ることがあります。同様に、マーカーのみの散布図も接続線がありません。すべてのチャート タイプで 3 つの明確な結果が得られるとは限らないので、使用するタイプで出力を確認してください。

## **シリーズのギャップ幅を設定する**

ギャップ幅は隣接するバーまたは列クラスター間のスペースで、バーまたは列幅のパーセンテージで表されます。オーバーラップと同様に、ギャップ幅は個々のシリーズではなく親シリーズ グループに属します。グループ全体に対して一度だけ [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) を設定してください。値を大きくするとクラスター間の間隔が広がり、値を小さくすると密集します。

以下の例はギャップ幅を変更し、最終プレゼンテーションだけを保存します。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int gapWidthPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.GapWidth = gapWidthPercent;

presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
```

結果:

![ギャップ幅](gap_width.png)

## **FAQ**

**どのチャート タイプがデータ シリーズをサポートしていますか？**

[ChartType](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/charttype/) 列挙体で表されるすべてのチャート タイプはチャート データを使用しますが、シリーズの値構造や設定はすべて同じではありません。たとえば、カテゴリ チャートはカテゴリと値を使用し、散布チャートは X と Y の値を使用し、バブル チャートはバブル サイズを追加します。シリーズ タイプに合わせたデータ ポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のあるバーまたは列グループにのみ適用されます。

**チャート シリーズ グループとは何ですか？**

[IChartSeriesGroup](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseriesgroup/) は、グループレベルのプロット設定を共有する互換性のあるシリーズを含みます。組み合わせチャートは複数のグループを保持できるため、あるシリーズを通じて変更したグループが必ずしもチャート内のすべてのシリーズに影響するわけではありません。

**新しく作成したチャートにはデフォルト データが含まれますか？**

はい。デフォルトでは、[IShapeCollection.AddChart](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/addchart/) はサンプルのシリーズ、カテゴリ、値を作成します。これらのセルを編集するか、完全にカスタム データを追加する前にシリーズとカテゴリのコレクションをクリアできます。オーバーロードによってはデフォルト データなしでチャートを作成することも可能です。

**チャート オブジェクトはワークブック セルとどう接続されていますか？**

シリーズ名、カテゴリ ラベル、データ ポイント値はすべて [IChartDataWorkbook](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdataworkbook/) のセルを参照します。参照セルを変更すると、対応するチャート要素が更新されます。カスタム データを構築する際は、カテゴリ行とシリーズ値行を揃えて、各ポイントが意図したカテゴリの下にプロットされるようにしてください。

**シリーズ全体ではなく 1 つのポイントだけをクリアするには？**

対象の値セルを `null` に設定して、ポイントのカテゴリ位置は保持したまま空のポイントにします。[IChartDataPointCollection.Clear](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatapointcollection/clear/) はそのシリーズのすべてのポイントを削除するため、ポイントだけを残したい場合は使用しないでください。カテゴリも削除する場合は、すべてのシリーズの値がカテゴリコレクションと整合するように更新してください。

**空のポイントはどのように表示されますか？**

表示はチャート タイプと [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichart/displayblanksas/) の設定に依存します。サポートされているチャートは、ギャップ、ゼロ 値、または隣接ポイントの接続のいずれかで空白を表示できます。プレゼンテーションのデータ欠損の意味に合わせて設定を選択してください。完全な例と視覚的比較は「空セルの表示方法を制御する」を参照してください。

**負の値はどのように書式設定されますか？**

サポートされているバー、列、バブル シリーズの場合、[IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseries/invertifnegative/) を有効にし、[IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) で負の値用の色を設定します。個々のポイントで動作を上書きしたい場合は、[IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) を使用してください。これらのプロパティは書式設定に影響し、保存されている数値そのものは変更しません。

**シリーズとポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータ ポイントの書式設定がそのポイントに対して優先されます。他のポイントは明示的なシリーズ書式設定、またはシリーズ書式が未定義の場合は自動的なチャート スタイルとテーマを使用します。オーバーラップやギャップ幅などのグループ プロパティはレイアウトに影響し、ポイントレベルの書式設定の上書きにはなりません。

**チャートに含められるシリーズの数に上限はありますか？**

Aspose.Slides には別途固定されたシリーズ数の上限はありません。実際には、プレゼンテーション ファイルの制約、利用可能なメモリ、レンダリング時間、そしてチャートの可読性が実用的な上限を決定します。

**列が互いに近すぎる、または遠すぎる場合はどうすればよいですか？**

適切な親シリーズ グループで [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) を設定してください。値を大きくするとクラスター間のスペースが広がり、値を小さくするとクラスターが近づきます。