---
title: .NET でプレゼンテーションのチャート データ系列を管理する
linktitle: データ系列
type: docs
url: /ja/net/chart-series/
keywords:
- チャート系列
- 系列重なり
- 系列の色
- カテゴリの色
- 系列名
- データポイント
- 系列ギャップ
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# を使用して、プレゼンテーション内でチャート系列、データポイント、ワークブックセル、書式設定、重なり、ギャップ幅、負の値を管理する方法を学びます。"
---
## **概要**

チャートはプロットされたデータをチャート データ ワークブックに保存します。[IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) は関連する値のセットを表し、系列内の各 [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) は 1 つまたは複数のワークブック セルを参照します。[IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) オブジェクトは系列が共有するラベルまたはグループ化値を提供します。そのため、系列名、カテゴリ、ポイント値は [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) オブジェクトに接続され、表示テキストとしてだけ保存されません。

典型的なカテゴリ チャートでは、デフォルトのワークブックは行 0 を系列名に、列 0 をカテゴリ名に、残りのセルを系列値に使用します。[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) に渡されるワークシート、行、列のインデックスはゼロベースです。このレイアウトはデフォルト データでチャートを作成する際に便利ですが、すべての既存チャートがこれを使用しているとは限りません。ロードされたプレゼンテーションの場合、ワークブックの値を変更する前に、系列、カテゴリ、データ ポイントが参照しているセルを確認してください。

チャート設定には 3 つの異なるスコープがあります：

- 系列レベルの設定（例: [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/)）は、1 系列内のすべてのポイントの既定の外観を提供します。
- データ ポイント レベルの設定（例: [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/)）は、1 ポイントの系列外観を上書きします。
- グループ設定は、同じ [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) に属する互換性のある系列に適用されます。必要に応じて [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) を介してグループにアクセスし、重なりやギャップ幅などのオプションを設定します。

明示的なポイントまたは系列の塗りつぶしが設定されていない場合、チャートのスタイルとテーマが自動的な外観を決定します。系列とポイントの書式設定の両方が存在する場合、ポイントの書式設定がそのポイントに対して優先されます。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **チャート系列の重なりを設定する**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) は 2D チャートで棒や列がどれだけ重なるか（-100% から 100%）を示します。これは親系列グループの設定の読み取り専用の投影です。[IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) を設定すると、そのグループ内のすべての互換系列が更新されます。このオプションはグループ化された棒や列を表示するチャート タイプに適用され、組み合わせチャートの無関係な系列グループには影響しません。

次の例は、最初の系列を含むグループの重なりを設定します：

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// 新しいチャートにはサンプル系列、カテゴリ、および値が含まれています。
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

結果：

![The series overlap](series_overlap.png)

## **系列の塗りつぶしカラーを変更する**

[IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) を使用して、系列全体の既定の塗りつぶしを設定します。ポイントにすでに明示的な塗りつぶしがある場合、その [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) 設定がそのポイントの系列塗りつぶしを上書きします。

次の例は、最初の系列に単色の青色塗りつぶしを適用します：

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

結果：

![The color of the series](series_color.png)

## **系列の名前を変更する**

系列名はチャート データ ワークブックに保存され、通常は凡例に表示されます。クラスター化された列チャート用に作成されたデフォルト ワークブックでは、セル B1 が行 0、列 1 に位置し、最初の系列の名前が格納されています。以下の例で使用されている名前定数は、その構造を明示的に示しています：

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

また、[IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/) が参照しているセルを直接更新することもできます。この方法は既存のチャートで特定の行や列を前提としないため安全です：

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

結果：

![The series name](series_name.png)

### **複数セルから名前を持つ系列を作成する**

製品名と報告期間が別々のワークブック セルに格納されている場合、複合的な系列名が便利です。たとえば、B1 の `Product A` と C1 の `2026` を結合して、両方のセルがソースにリンクされたまま単一の系列名にできます。

[IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) を使用して名前範囲を取得し、そのコレクションを [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/) に渡します。`skipHiddenCells` 引数は非表示セルを含めるかどうかを制御します：`true` は除外し、`false` は含めます。この例では `false` を使用して名前範囲のすべてのセルを含めています。

次の例は、1 系列と 2 データ ポイントを持つプレゼンテーションを作成します。セル B1:C1 が系列名のみを提供し、A2:A3 がカテゴリラベル、B2:B3 が数値を提供します。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
chart.HasLegend = true;

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// この 2 つのセルは系列名を提供します。
workbook.GetCell(0, 0, 1, "Product A");
workbook.GetCell(0, 0, 2, "2026");
var nameCells = workbook.GetCellCollection("Sheet1!$B$1:$C$1", skipHiddenCells: false);
var series = chart.ChartData.Series.Add(nameCells, ChartType.ClusteredColumn);

// 別々のセルがカテゴリと数値データポイントを提供します。
var northCategory = workbook.GetCell(0, 1, 0, "North");
var southCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(northCategory);
chart.ChartData.Categories.Add(southCategory);
var northValue = workbook.GetCell(0, 1, 1, 120);
var southValue = workbook.GetCell(0, 2, 1, 150);
series.DataPoints.AddDataPointForBarSeries(northValue);
series.DataPoints.AddDataPointForBarSeries(southValue);

presentation.Save("composite_series_name.pptx", SaveFormat.Pptx);
```

生成された系列名は `Product A 2026` で、2 つのセル値の間にスペースが入ります。凡例はこの 2 列を 1 つのエントリとして表示します。以下の画像は保存されたプレゼンテーションからレンダリングされたものです：

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **自動系列塗りつぶしカラーを取得する**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) は、系列インデックスとチャート スタイルから計算されたカラーを返します。これは、系列の塗りつぶしが明示的に定義されていない場合に使用されるカラーです。メソッドを呼び出すと計算されたカラーが取得されますが、新しい塗りつぶしは割り当てられません。

次の例は、各デフォルト系列の自動カラーを出力します：

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

デフォルトのチャート スタイルに対する例出力：

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

正確なカラーはチャート スタイルとテーマによって異なります。

## **系列の反転塗りつぶしカラーを設定する**

棒、列、バブル系列の場合、[IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) を使用して負の値を別の塗りつぶしで表示できます。通常の系列塗りつぶしを単色に設定し、反転を有効にし、負の値のカラーを [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) で割り当てます。負の数値はワークブック内で変更されず、表示カラーのみが変わります。

次の例は、デフォルトのチャート データを 1 系列に置き換えます。ワークシートの行 0 が系列名、列 0 がカテゴリ名、列 1 が値を格納しています：

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

結果：

![The inverted solid fill color](inverted_solid_fill_color.png)

1 ポイントだけに反転を有効にするには [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) を使用します。以下の例では系列全体の反転を無効にし、選択したポイントだけに有効にしています。そのポイントには負の値も割り当てられているため、効果が確認できます：

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

1 ポイントだけを空にしたい場合は、対応するバックアップ ワークブック セルを `null` に設定します。列チャートの場合、プロットされた値は [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/) で取得できます。データ ポイントは同じカテゴリ位置に残りますが、チャートはブランク設定に従ってその値を空白として扱います。

次の例は、最初の系列の 2 番目のポイントだけをクリアします：

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

散布図は X と Y のセルが別々に使用され、バブル図はサイズセルも使用します。削除したい値を表すセルだけをクリアしてください。系列全体を削除したい場合以外は [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) を呼び出さないでください。このメソッドはコレクション内のすべてのデータ ポイントを削除します。

## **空セルの表示を制御する**

値を含む非表示セルは空セルとは別のケースです。非表示のワークシート行や列からデータを含めるか除外するには、[Include Data from Hidden Rows and Columns](/slides/ja/net/chart-workbook/#include-data-from-hidden-rows-and-columns) を参照してください。

空のワークブック セルはデータ欠損を表し、`0` を含むセルは既知の数値を表します。[IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) を `null` に設定するとセルが空になります。数値のゼロはブランク設定に関係なくゼロのままです。

[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) を使用して、チャートが空セルをどのように表示するかを選択します。この設定はチャート全体に適用され、空白のプロット方法を変更しますが、空セルをゼロや補間値で埋めることはありません。

次のセルフコンテインド例は、1 系列の折れ線チャートを作成し、Day 3 の値をクリアし、各モードで同じチャートを保存します。入力ファイルは不要です。[IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) はワークシート 0、列 0 をカテゴリラベル、列 1 を値に使用し、行 0 に系列名を保持します。最終データは `10, 20, empty, 30, 40` です：

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

// Day 3 を本当に空にしたまま、カテゴリとデータ ポイントは保持します。
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

各出力ファイルは保存前に設定したモードを保持します：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 つのバージョンだけを保存したい場合は、目的のモードを設定してプレゼンテーションを 1 回保存すればよく、モードを繰り返し適用する必要はありません。

以下の比較は 3 つのファイルすべてで同じデータを示しています。Day 3 はすべてのケースでワークブック上で空です：

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可視効果はチャート タイプに依存します。折れ線チャートは 3 つのモードを簡単に比較できますが、棒や列チャートは欠損カテゴリをつなぐ線がないため、`Span` は上記のような接続セグメントを生成できません。欠損列とゼロ高さの列は見た目が似ることがあります。同様に、マーカーのみの散布図も接続線がありません。すべてのチャート タイプで 3 つの異なる結果が得られるわけではありませんので、使用するタイプの出力を確認してください。

## **系列のギャップ幅を設定する**

ギャップ幅は隣接する棒または列クラスター間のスペースを、棒または列幅のパーセンテージで表したものです。重なりと同様に、これは個々の系列ではなく親系列グループに属します。[IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) をグループに対して一度設定します。値を大きくするとクラスター間のスペースが広がり、値を小さくすると密度が高くなります。

次の例はギャップ幅を変更し、最終プレゼンテーションだけを保存します：

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

結果：

![The gap width](gap_width.png)

## **FAQ**

**どのチャート タイプがデータ系列をサポートしていますか？**

[ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 列挙体で表されるすべてのチャート タイプはデータを使用しますが、系列の値構造や設定はすべて同じではありません。たとえば、カテゴリ チャートはカテゴリと値を使用し、散布図は X と Y の値を使用し、バブル チャートはバブルサイズを追加します。系列タイプに合ったデータ ポイント作成メソッドを使用してください。重なりやギャップ幅などのオプションは互換性のある棒または列グループにのみ適用されます。

**チャート系列グループとは何ですか？**

[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) は、グループレベルのプロット設定を共有する互換系列を含みます。組み合わせチャートは複数のグループを含めることができるため、ある系列を通じて取得したグループを変更しても、必ずしもチャート内のすべての系列が変更されるわけではありません。

**新しく作成したチャートはデフォルト データを含みますか？**

はい。デフォルトでは、[IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) はサンプル系列、カテゴリ、値を作成します。これらのセルを編集するか、完全にカスタム データ セットを追加する前に系列とカテゴリのコレクションをクリアできます。オーバーロードを使用すれば、デフォルト データなしでチャートを作成することも可能です。

**チャート オブジェクトはワークブック セルとどのように接続されていますか？**

系列名、カテゴリ ラベル、データ ポイントの値は [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) のセルを参照しています。参照されたセルを変更すると、対応するチャート要素が更新されます。カスタム データを構築する際は、カテゴリ行と系列値行が整合するように配置し、各ポイントが意図したカテゴリの下にプロットされるようにしてください。

**系列全体ではなく 1 ポイントだけをクリアするにはどうすればよいですか？**

該当する値セルを `null` に設定して、ポイントのカテゴリ位置は保持したまま空のポイントにします。[IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) はその系列のすべてのポイントを削除するため、ポイントだけを残したい場合は使用しないでください。カテゴリも削除する場合は、すべての系列がカテゴリ コレクションと整合するように更新してください。

**空のポイントはどのように表示されますか？**

表示はチャート タイプと [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) に依存します。サポートされているチャートは、空白をギャップ、ゼロ値、または隣接ポイントの接続として表示できます。プレゼンテーションの欠損データの意味に合った設定を選択してください。完全な例とビジュアル比較については、[空セルの表示を制御する](#control-the-display-of-empty-cells) を参照してください。

**負の値はどのように書式設定されますか？**

サポートされている棒、列、バブル系列では、[IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) を有効にし、[IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) で負の値のカラーを設定します。個々のポイントに対しては [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) で動作を上書きできます。これらのプロパティは書式設定に影響し、保存されている数値自体は変更しません。

**系列とポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータ ポイントの書式設定がそのポイントに対して優先されます。他のポイントは明示的な系列書式設定、または系列書式設定が未定義の場合は自動的なチャート スタイルとテーマを使用します。重なりやギャップ幅などのグループプロパティはレイアウトに影響し、ポイントレベルの書式設定の上書きにはなりません。

**チャートに含められる系列の数に上限はありますか？**

Aspose.Slides には別途固定された系列数の上限はありません。実際には、プレゼンテーション ファイルの制約、使用可能なメモリ、レンダリング時間、チャートの可読性が実用的な上限を決定します。

**列が互いに近すぎる、または離れすぎる場合はどうすればよいですか？**

適切な親系列グループの [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) を設定します。値を増やすとクラスター間のスペースが広がり、減らすとクラスターが近づきます。