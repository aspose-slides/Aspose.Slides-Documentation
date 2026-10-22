---
title: .NET のプレゼンテーションでチャート データ シリーズを管理する
linktitle: データシリーズ
type: docs
url: /ja/net/chart-series/
keywords:
- チャートシリーズ
- シリーズオーバーラップ
- シリーズカラー
- カテゴリカラー
- シリーズ名
- データポイント
- シリーズギャップ
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# を使用して、プレゼンテーション内のチャートシリーズ、データポイント、ワークブックセル、書式設定、オーバーラップ、ギャップ幅、負の値を管理する方法を学びます。"
---
## **概要**

チャートは、プロットされた値をワークブックのセルに保存したり、数値リテラルとして直接保存したりできます。[IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) は関連する値のセットを表し、各 [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) はそのシリーズ内のポイントを表します。[IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) オブジェクトは、シリーズ間で共有されるラベルまたはグループ化値を提供します。デフォルトデータで作成されたチャートでは、シリーズ名、カテゴリ、およびポイント値はチャートワークブックの [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) オブジェクトを使用します。

典型的なカテゴリチャートでは、デフォルトワークブックは行 0 をシリーズ名に、列 0 をカテゴリ名に、残りのセルをシリーズ値に使用します。[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) に渡されるワークシート、行、列のインデックスはゼロベースです。このレイアウトはデフォルトデータでチャートを作成する際に便利ですが、すべての既存チャートがこれを使用しているとは限りません。ロードされたプレゼンテーションでは、ワークブックの値を変更する前に、シリーズ、カテゴリ、データポイントが参照しているセルを確認してください。

チャート設定には次の 3 つのスコープがあります。

- シリーズレベルの設定 (例: [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/)) は、1 系列内のすべてのポイントの既定の外観を提供します。
- データポイント設定 (例: [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/)) は、1 ポイントのシリーズ外観を上書きします。
- グループ設定は、同じ [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) に属する互換シリーズに適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) からグループへアクセスします。

明示的なポイントまたはシリーズの塗りつぶしが設定されていない場合、チャートのスタイルとテーマが自動外観を決定します。シリーズとポイントの両方に書式設定が存在する場合、ポイントの書式設定がそのポイントに対して優先されます。

![チャートシリーズ PowerPoint](chart-series-powerpoint.png)

## **数値リテラルを使用してシリーズ値を設定する**

シリーズ値がアプリケーションデータや計算結果から取得され、ワークシートセル参照が不要な場合は数値リテラルを使用します。[DataSourceTypeForValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforvalues/) を [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) に設定し、各ポイントの [Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/value/) を [AsLiteralDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/idoublechartvalue/asliteraldouble/) で割り当てます。

このコレクション設定は、シリーズ内のすべてのポイント値のソースタイプを制御します。各ポイントの [Value.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ibasechartvalue/datasourcetype/) は選択されたタイプを報告します。コレクション設定で変更してください。`Worksheet` を使用する場合は [AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/isinglecellchartvalue/ascell/) で参照セルにアクセスします。`DoubleLiterals` を使用する場合は `AsLiteralDouble` で数値を直接読み書きします。

以下の例は、デフォルトのシリーズとカテゴリを持つ縦棒グラフを作成し、最初のシリーズの既存ポイントに 10、20… と計算された値を割り当てます。プレゼンテーションを保存し、再度開いて格納された値を出力します。

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

series.DataPoints.DataSourceTypeForValues = DataSourceType.DoubleLiterals;
for (var i = 0; i < series.DataPoints.Count; i++)
{
    series.DataPoints[i].Value.AsLiteralDouble = (i + 1) * 10;
}

presentation.Save("numeric_literals.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("numeric_literals.pptx");
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedChart = (IChart)reopenedSlide.Shapes[0];
var reopenedSeries = reopenedChart.ChartData.Series[0];
foreach (var point in reopenedSeries.DataPoints)
{
    Console.WriteLine(point.Value.AsLiteralDouble);
}
```

ポイント値のソースタイプは、[IChartData.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/datasourcetype/) とは別物です。これはチャートの内部または外部ワークブック構成を示します。数値リテラルを使用しても、埋め込みワークブックは自動的に削除されません。この例では、ワークブックはカテゴリラベル、シリーズ名、その他のシリーズのために引き続き利用可能です。ワークブックの管理については [Chart Workbook](/slides/ja/net/chart-workbook/) を参照してください。

散布図およびバブルチャートの場合は、[DataSourceTypeForXValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforxvalues/) と [DataSourceTypeForYValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforyvalues/) を設定して、[XValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/xvalue/) と [YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/) のソースを選択します。バブルチャートはさらに [DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforbubblesizes/) を使用して [BubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/bubblesize/) のソースを指定します。各該当ソースを `DoubleLiterals` に設定し、その値の `AsLiteralDouble` プロパティで数値を割り当てます。

## **チャートシリーズのオーバーラップを設定する**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) は、2D チャートにおける棒または縦棒のオーバーラップ率を -100% から 100% の範囲で報告します。これは親シリーズグループの設定の読み取り専用投影です。すべての互換シリーズを更新するには、[IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) を設定します。このオプションは、グループ化された棒や縦棒を表示するチャートタイプに適用され、組み合わせチャートの無関係なシリーズグループには影響しません。

以下の例は、最初のシリーズを含むグループのオーバーラップを設定します。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// 新しいチャートにはサンプルシリーズ、カテゴリ、値が含まれています。
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

結果:

![シリーズのオーバーラップ](series_overlap.png)

## **シリーズの塗りつぶしカラーを変更する**

[IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) を使用して、シリーズ全体の既定の塗りつぶしを設定します。ポイントに明示的な塗りつぶしが既にある場合、その [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) 設定がポイントの塗りつぶしを上書きします。

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

シリーズ名はチャートデータワークブックに保存され、通常は凡例に表示されます。クラスター化縦棒チャート用に作成されたデフォルトワークブックでは、セル B1 が行 0、列 1 にあり、最初のシリーズ名が格納されています。以下の例の名前定数はその構造を明示的に示しています。

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

また、[IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/) が既に参照しているセルを更新することもできます。このアプローチは、既存チャートで特定の行や列を前提としないため安全です。

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

### **複数セルからなるシリーズ名を作成する**

製品名と報告期間が別々のワークブックセルに格納されている場合、合成シリーズ名が便利です。たとえば、B1 の `Product A` と C1 の `2026` を結合し、両方のソースセルへのリンクを保持したまま単一のシリーズ名にできます。

[IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) で名前範囲を取得し、そのコレクションを [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/) に渡します。`skipHiddenCells` 引数は非表示セルを含めるかどうかを制御します: `true` は除外し、`false` は含めます。この例では `false` を使用して名前範囲のすべてのセルを含めています。

以下の例は、1 系列と 2 データポイントを持つプレゼンテーションを作成します。セル B1:C1 がシリーズ名のみを供給し、A2:A3 がカテゴリラベル、B2:B3 が数値を供給します。

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

// この 2 つのセルがシリーズ名を提供します。
workbook.GetCell(0, 0, 1, "Product A");
workbook.GetCell(0, 0, 2, "2026");
var nameCells = workbook.GetCellCollection("Sheet1!$B$1:$C$1", skipHiddenCells: false);
var series = chart.ChartData.Series.Add(nameCells, ChartType.ClusteredColumn);

// この別々のセルがカテゴリと数値データポイントを提供します。
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

結果のシリーズ名は `Product A 2026` で、2 つのセル値の間にスペースが入ります。凡例は両方の列を 1 つのエントリとして表示します。以下の画像は保存されたプレゼンテーションからレンダリングされたものです。

![North と South の値と合成シリーズ名 Product A 2026 を凡例に持つ縦棒チャート](composite_series_name.png)

## **自動シリーズ塗りつぶしカラーを取得する**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) は、シリーズインデックスとチャートスタイルから計算されたカラーを返します。これは、シリーズの塗りつぶしが明示的に定義されていない場合に使用されるカラーです。メソッドを呼び出すと計算されたカラーが取得されますが、新しい塗りつぶしは割り当てられません。

以下の例は、各デフォルトシリーズの自動カラーを出力します。

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

デフォルトチャートスタイルのサンプル出力:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

正確なカラーはチャートスタイルとテーマによって異なります。

## **チャートシリーズの負の値用塗りつぶしカラーを反転する**

棒、縦棒、バブルシリーズでは、[IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) を使用して負の値を別の塗りつぶしで表示できます。通常のシリーズ塗りつぶしを単色に設定し、反転を有効にし、負の値用カラーを [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) で割り当てます。負の数値自体はワークブック内で変更されず、表示色だけが変わります。

以下の例は、デフォルトのチャートデータを 1 系列に置き換えます。ワークシートの行 0 にシリーズ名、列 0 にカテゴリ名、列 1 に値が格納されています。

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

![反転した単色塗りつぶしカラー](inverted_solid_fill_color.png)

ポイント単位で反転を有効にするには、[IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) を使用します。以下の例では、シリーズ全体の反転は無効にし、選択したポイントのみ反転を有効にしています。そのポイントには負の値も割り当てて効果を確認しています。

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

## **特定のデータポイント値をクリアする**

他のポイントを削除せずに 1 ポイントだけを空にするには、そのバックエンドワークブックセルを `null` に設定します。縦棒チャートの場合、プロットされた値は [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/) で取得できます。データポイントは同じカテゴリ位置に残りますが、チャートは空白として扱います。

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

散布チャートは X と Y のセルが別々で、バブルチャートはサイズセルも使用します。削除したい値を表すセルだけをクリアしてください。ポイントコレクション全体を削除したいとき以外は、[IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) を呼び出さないでください。

## **空セルの表示を制御する**

値を含む非表示セルは空セルとは別のケースです。非表示の行や列からデータを含めるか除外するには、[Include Data from Hidden Rows and Columns](/slides/ja/net/chart-workbook/#include-data-from-hidden-rows-and-columns) を参照してください。

空のワークブックセルは欠損データを表し、`0` を含むセルは既知の数値を表します。セルを空にしたい場合は、[IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) を `null` に設定します。数値ゼロは空セル設定に関係なくゼロのままです。

[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) を使用して、チャートが空セルをどのように表示するかを選択します。この設定はチャート全体に適用され、空白のプロット方法を変更しますが、空のワークブックセルにゼロや補間値を自動で埋めることはありません。

以下の自己完結型例は、1 系列の折れ線グラフを作成し、Day 3 の値をクリアし、各モードで同じチャートを保存します。入力ファイルは不要です。[IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) はワークシート 0、列 0 をカテゴリラベル、列 1 を値に使用し、行 0 にシリーズ名を保持します。最終データは `10, 20, empty, 30, 40` です。

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

各出力ファイルは保存前に割り当てたモードを保持します: `empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 つだけ保存したい場合は、目的のモードを設定してプレゼンテーションを 1 回だけ保存してください。

以下の比較は 3 つのファイルの同一データを示しています。Day 3 はすべてのワークブックで空です。

![空セルの表示比較: Gap は Day 3 でラインを切れ、Zero はラインをゼロに落とし、Span は Day 2 から Day 4 を接続します。](display_blanks_as.png)

可視効果はチャートタイプによって異なります。折れ線グラフは 3 つのモードを比較しやすいですが、棒や縦棒チャートは欠損カテゴリを跨ぐラインがないため `Span` が示すような接続セグメントは生成されません。欠損列とゼロ高さの列は見た目が似ることがあります。同様に、マーカーのみの散布図は接続ラインがないため、すべてのチャートタイプで 3 つの明確な結果が得られるとは限りません。使用するタイプで出力を確認してください。

## **シリーズのギャップ幅を設定する**

ギャップ幅は隣接する棒または縦棒クラスター間のスペースで、棒または縦棒幅のパーセンテージで表されます。オーバーラップと同様に、個別のシリーズではなく親シリーズグループに属します。グループ全体に対して [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) を一度設定してください。値を大きくするとクラスター間の間隔が広がり、値を小さくすると密集します。

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

**どのチャートタイプがデータシリーズをサポートしていますか？**

[ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 列挙体で表されるすべてのチャートタイプはデータを使用しますが、シリーズの価値構造や設定はタイプごとに異なります。たとえば、カテゴリチャートはカテゴリと値を使用し、散布図は X と Y 値を使用し、バブルチャートはバブルサイズを追加します。シリーズタイプに合ったデータポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のある棒または縦棒グループにのみ適用されます。

**チャートシリーズグループとは何ですか？**

[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) は、グループレベルのプロット設定を共有する互換シリーズを含みます。組み合わせチャートは複数のグループを含むことができるため、あるシリーズから取得したグループを変更しても、チャート内のすべてのシリーズが必ずしも変更されるわけではありません。

**新規作成されたチャートにはデフォルトデータが含まれますか？**

はい。デフォルトでは、[IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) がサンプルシリーズ、カテゴリ、値を作成します。これらのセルを編集するか、完全にカスタムデータセットを追加する前にシリーズとカテゴリコレクションの両方をクリアできます。オーバーロードを使用してデフォルトデータなしでチャートを作成することも可能です。

**チャートオブジェクトはワークブックセルとどのように接続されていますか？**

シリーズ名、カテゴリラベル、データポイント値はすべて [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) のセルを参照しています。参照セルを変更すると、対応するチャート要素が更新されます。カスタムデータを構築する際は、カテゴリ行とシリーズ値行が整合するように配置し、各ポイントが意図したカテゴリの下にプロットされるようにしてください。

**シリーズ全体ではなく 1 ポイントだけをクリアするには？**

対象の値セルを `null` に設定して、ポイントのカテゴリ位置は保持したまま空のポイントとして残します。[IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) はそのシリーズのすべてのポイントを削除するため、ポイントだけを残したい場合は使用しないでください。カテゴリも削除する場合は、すべてのシリーズがカテゴリコレクションと整合するように更新してください。

**空白ポイントはどのように表示されますか？**

表示結果はチャートタイプと [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) に依存します。サポートされているチャートは、空白をギャップ、ゼロ値、または隣接ポイントを接続する形で表示できます。プレゼンテーションの欠損データの意味に合った設定を選択してください。完全な例とビジュアル比較については [空セルの表示を制御する](#control-the-display-of-empty-cells) を参照してください。

**負の値はどのように書式設定されますか？**

サポートされている棒、縦棒、バブルシリーズでは、[IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) を有効にし、[IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) で負の値用カラーを設定します。個別ポイントの書式設定は [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) で上書きできます。これらのプロパティは書式設定に影響し、保存されている数値には影響しません。

**シリーズとポイントの両方が書式設定された場合、どちらが優先されますか？**

明示的なデータポイント書式設定がそのポイントに対して優先されます。他のポイントは明示的なシリーズ書式設定を使用し、シリーズ書式が未定義の場合は自動的にチャートスタイルとテーマが適用されます。オーバーラップやギャップ幅などのグループプロパティはレイアウトを制御し、ポイントレベルの書式設定上書きにはなりません。

**チャートに含められるシリーズ数に上限はありますか？**

Aspose.Slides には固定されたシリーズ数上限はありません。実際には、プレゼンテーションファイルの制約、利用可能なメモリ、レンダリング時間、チャートの可読性が実用的な上限を決定します。

**列が互いに近すぎる、または離れすぎる場合はどうすればよいですか？**

適切な親シリーズグループの [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) を設定します。値を大きくするとクラスター間のスペースが広がり、値を小さくするとクラスターが近づきます。