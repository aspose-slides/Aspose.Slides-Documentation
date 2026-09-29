---
title: .NET でのプレゼンテーションにおけるチャート データ シリーズの管理
linktitle: データ シリーズ
type: docs
url: /ja/net/chart-series/
keywords:
- チャートシリーズ
- シリーズ オーバーラップ
- シリーズ カラー
- カテゴリ カラー
- シリーズ名
- データ ポイント
- シリーズ ギャップ
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# を使用して、プレゼンテーションでチャートシリーズ、データポイント、ワークブックセル、書式設定、オーバーラップ、ギャップ幅、負の値の管理方法を学びます。"
---
## **概要**

チャートはプロットされたデータをチャート データ ブックに保存します。[IChartSeries] は関連する値のセットを表し、シリーズ内の各 [IChartDataPoint] は 1 つ以上のブックセルを参照します。[IChartCategory] オブジェクトはシリーズが共有するラベルまたはグループ化値を提供します。そのため、シリーズ名、カテゴリ、およびデータ ポイントの値は、表示テキストだけでなく [IChartDataCell] オブジェクトに接続されています。

典型的なカテゴリ チャートでは、デフォルトのブックは行 0 をシリーズ名に、列 0 をカテゴリ名に使用し、残りのセルにシリーズ値を格納します。[IChartDataWorkbook.GetCell] に渡されるワークシート、行、列のインデックスはゼロベースです。このレイアウトはデフォルト データでチャートを作成する際に便利ですが、すべての既存チャートがこのレイアウトを使用しているとは限りません。読み込まれたプレゼンテーションの場合、ブックの値を変更する前に、シリーズ、カテゴリ、データ ポイントが参照するセルを確認してください。

チャート設定には 3 つの異なるスコープがあります:

- シリーズ レベルの設定（例: [IChartSeries.Format]）は、1 つのシリーズ内のすべてのポイントのデフォルトの外観を提供します。
- データ ポイントの設定（例: [IChartDataPoint.Format]）は、1 つのポイントに対してシリーズの外観を上書きします。
- グループ設定は、同じ [IChartSeriesGroup] に属する互換性のあるシリーズに適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[IChartSeries.ParentSeriesGroup] を介してグループにアクセスします。

明示的なポイントまたはシリーズの塗りつぶしが設定されていない場合、チャート スタイルとテーマが自動外観を決定します。シリーズの書式設定とポイントの書式設定の両方が存在する場合、そのポイントに対してはポイントの書式設定が優先されます。

![チャートシリーズ PowerPoint](chart-series-powerpoint.png)

## **チャートシリーズのオーバーラップを設定**

[IChartSeries.Overlap] は 2D チャートにおける棒や柱の重なり具合（-100% から 100%）を示します。これは親シリーズ グループの設定の読み取り専用の投影です。[IChartSeriesGroup.Overlap] を設定すると、そのグループ内のすべての互換シリーズが更新されます。このオプションは、グループ化された棒または柱を表示するチャート タイプに適用され、組み合わせチャートの無関係なシリーズ グループには影響しません。

次の例は、最初のシリーズを含むグループのオーバーラップを設定します:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// 新しいチャートにはサンプルのシリーズ、カテゴリ、および値が含まれています。
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

結果:

![シリーズのオーバーラップ](series_overlap.png)

## **シリーズの塗りつぶし色を変更**

[IChartSeries.Format] を使用して、シリーズ全体のデフォルトの塗りつぶしを設定します。ポイントに明示的な塗りつぶしがある場合、その [IChartDataPoint.Format] 設定がそのポイントのシリーズ塗りつぶしを上書きします。

次の例は、最初のシリーズに単色の青色塗りつぶしを適用します:

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

## **シリーズ名を変更**

シリーズ名はチャート データ ブックに保存され、通常は凡例に表示されます。デフォルトで作成されたクラスター列チャートのブックでは、セル B1（行 0、列 1）に最初のシリーズ名が入っています。次の例の名前付き定数は、その構造を明示的に示しています:

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

[IChartSeries.Name] がすでに参照しているセルを更新することもできます。このアプローチは、既存のチャートで特定の行・列を前提とすることを回避します:

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

## **自動系列塗りつぶし色を取得**

[IChartSeries.GetAutomaticSeriesColor] は、シリーズインデックスとチャート スタイルから計算された色を返します。これは、シリーズの塗りつぶしが明示的に定義されていない場合に使用される色です。このメソッドを呼び出すと計算された色が取得され、新しい塗りつぶしは設定されません。

次の例は、デフォルトの各シリーズの自動色を出力します:

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

デフォルトのチャートスタイルの例出力:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

正確な色はチャート スタイルとテーマによって異なります。

## **チャートシリーズの反転塗りつぶし色を設定**

棒、列、バブルシリーズの場合、[IChartSeries.InvertIfNegative] を使用して負の値を別の塗りつぶしで表示できます。通常のシリーズ塗りつぶしを単色に設定し、反転を有効にし、負の値の色を [IChartSeries.InvertedSolidFillColor] で指定します。負の数値はブック内では変更されず、表示色のみが変わります。

次の例は、デフォルトのチャート データを 1 つのシリーズに置き換えます。ワークシートの行 0 にシリーズ名が、列 0 にカテゴリ名が、列 1 に値が格納されます:

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

![反転した単色塗りつぶし色](inverted_solid_fill_color.png)

[IChartDataPoint.InvertIfNegative] を使用して、1 つのポイントに対して反転を有効にできます。次の例では、シリーズ全体の反転は無効にし、選択したポイントだけに反転を有効にしています。ポイントには負の値も設定され、効果が確認できます:

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

## **特定のデータ ポイントの値をクリア**

他のポイントを削除せずに 1 つのポイントだけを空にするには、対応するブックセルを `null` に設定します。列チャートの場合、プロットされた値は [IChartDataPoint.YValue] で取得できます。データ ポイントは同じカテゴリ位置に残りますが、チャートはブランク値設定に従ってその値を空として扱います。

次の例は、最初のシリーズの 2 番目のポイントのみをクリアします:

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

散布図は X と Y のセルを別々に使用し、バブルチャートはサイズセルも使用します。削除したい値に対応するセルだけをクリアしてください。他のポイントを残したい場合は、[IChartDataPointCollection.Clear] を呼び出さないでください。このメソッドはコレクション内のすべてのデータ ポイントを削除します。

## **空のセルの表示を制御**

値を含む非表示セルは、空セルとは別のケースです。非表示のワークシート行や列のデータを含めるか除外するには、[非表示の行と列からデータを含める](/slides/ja/net/chart-workbook/#include-data-from-hidden-rows-and-columns) を参照してください。

空のブックセルはデータが欠落していることを示し、`0` を含むセルは既知の数値を示します。[IChartDataCell.Value] を `null` に設定するとセルが空になります。空セル設定に関係なく、数値の 0 は 0 のままです。

[IChart.DisplayBlanksAs] を使用して、チャートが空のセルをどのように表示するかを選択します。この設定はチャート全体に適用され、空白がプロットされる方法を変更しますが、空のブックセルを 0 や補間値で埋めることはありません。

次のスタンドアロンの例は、1 つのシリーズを持つ折れ線グラフを作成し、Day 3 の値をクリアして、各モードで同じチャートを保存します。入力ファイルは不要です。[IChartDataWorkbook] はワークシート 0、列 0 をカテゴリ ラベルに、列 1 を値に使用し、行 0 にシリーズ名を保持します。最終データは `10, 20, empty, 30, 40` です。

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

各出力ファイルは保存前に設定されたモードを保持します：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 つのバージョンだけを保存したい場合は、目的のモードを設定してプレゼンテーションを 1 回保存すれば、モードを繰り返し適用する必要はありません。

以下の比較は、3 つのファイルすべてで同じデータを示しています。どのケースでも Day 3 はブック内で空です：

![同一データの折れ線グラフ: Gap は Day 3 で線を切断、Zero は 0 に降下、Span は Day 2 と Day 4 を接続](display_blanks_as.png)

表示効果はチャートの種類によって異なります。折れ線グラフは 3 つのモードを比較しやすくなります。棒・列チャートは欠損したカテゴリを跨ぐラインがないため、`Span` は上記の接続セグメントを生成できません。欠損した列と高さ 0 の列は見た目が似ていることがあります。同様に、マーカーのみの散布図は接続線がありません。すべてのチャートタイプで 3 つの異なる結果が得られるわけではないので、使用するタイプの出力を確認してください。

## **シリーズのギャップ幅を設定**

ギャップ幅は隣接する棒または列クラスター間のスペースで、棒または列幅のパーセンテージで表されます。オーバーラップと同様に、個々のシリーズではなく親シリーズ グループに属します。[IChartSeriesGroup.GapWidth] をグループに対して一度設定します。値を大きくするとクラスター間のスペースが広がり、値を小さくすると密集します。

次の例はギャップ幅を変更し、最終プレゼンテーションだけを保存します:

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

**どのチャートタイプがデータシリーズをサポートしますか？**

[ChartType] 列挙体が表すすべてのチャート タイプはチャート データを使用しますが、シリーズの値構造や設定はすべて同じではありません。例えば、カテゴリ チャートはカテゴリと値を使用し、散布図は X と Y の値を使用し、バブルチャートはバブルサイズを追加します。シリーズ タイプに合ったデータ ポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のある棒または列グループにのみ適用されます。

**チャートシリーズ グループとは何ですか？**

[IChartSeriesGroup] は、グループレベルのプロット設定を共有する互換シリーズを含みます。組み合わせチャートは複数のグループを含むことができるため、あるシリーズからアクセスしたグループを変更しても、チャート内のすべてのシリーズが必ずしも変更されるわけではありません。

**新規作成したチャートにはデフォルト データが含まれますか？**

はい。デフォルトでは、[IShapeCollection.AddChart] はサンプルのシリーズ、カテゴリ、値を作成します。完全にカスタム データを追加する前に、これらのセルを編集したり、シリーズとカテゴリのコレクションをクリアしたりできます。オーバーロードを使用してデフォルト データなしでチャートを作成することも可能です。

**チャート オブジェクトはブックセルとどのように接続されていますか？**

シリーズ名、カテゴリ ラベル、データ ポイントの値は [IChartDataWorkbook] のセルを参照しています。参照されたセルを変更すると、対応するチャート要素が更新されます。カスタム データを構築する際は、カテゴリ行とシリーズ値行が揃うようにして、各ポイントが意図したカテゴリの下にプロットされるようにしてください。

**シリーズ全体ではなく、1 つのポイントだけをクリアするには？**

対象の値セルを `null` に設定すると、ポイントのカテゴリ位置は空のポイントとして保持されます。[IChartDataPointCollection.Clear] は、そのシリーズのすべてのポイントを削除したい場合にのみ使用してください。カテゴリも削除する場合は、すべてのシリーズの値がカテゴリ コレクションと整合するように更新してください。

**空のポイントはどのように表示されますか？**

結果はチャートの種類と [IChart.DisplayBlanksAs] に依存します。サポートされているチャートは、空白をギャップ、ゼロ値、または隣接ポイントの接続として表示できます。プレゼンテーションでの欠損データの意味に合わせた設定を選択してください。完全な例と視覚的比較については、[Control the Display of Empty Cells](#control-the-display-of-empty-cells) を参照してください。

**負の値はどのように書式設定されますか？**

サポートされている棒、列、バブルシリーズでは、[IChartSeries.InvertIfNegative] を有効にし、[IChartSeries.InvertedSolidFillColor] を設定します。個別のポイントについては [IChartDataPoint.InvertIfNegative] で動作を上書きできます。これらのプロパティは書式設定に影響し、保存された数値自体は変更しません。

**シリーズとポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータポイントの書式設定がそのポイントで優先されます。他のポイントは明示的なシリーズ書式設定を使用し、シリーズ書式設定が未定義の場合は自動的なチャート スタイルとテーマが適用されます。オーバーラップやギャップ幅などのグループ プロパティはレイアウトを制御し、ポイントレベルの書式設定の上書きではありません。

**チャートが含むことのできるシリーズ数に制限はありますか？**

Aspose.Slides には固定されたシリーズ数の上限はありません。実際には、プレゼンテーション ファイルの制限、利用可能なメモリ、レンダリング時間、チャートの可読性が実用的な上限を決定します。

**列が互いに近すぎる、または遠すぎる場合は何を変更すべきですか？**

適切な親シリーズ グループで [IChartSeriesGroup.GapWidth] を設定します。値を増やすとクラスター間のスペースが広がり、減らすとクラスターが近づきます。