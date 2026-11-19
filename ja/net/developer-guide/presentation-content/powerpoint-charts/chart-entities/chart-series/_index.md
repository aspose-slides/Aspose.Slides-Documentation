---
title: .NET のプレゼンテーションでチャート データ シリーズを管理する
linktitle: データ シリーズ
type: docs
url: /ja/net/chart-series/
keywords:
- チャート シリーズ
- シリーズのオーバーラップ
- シリーズの色
- カテゴリの色
- シリーズ名
- データ ポイント
- シリーズ間ギャップ
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# を使用してプレゼンテーション内のチャートシリーズ、データポイント、ワークブックセル、書式設定、オーバーラップ、ギャップ幅、および負の値の管理方法を学びます。"
---
## **概要**

チャートは、プロットされた値をワークブックのセルに格納することも、数値リテラルとして直接格納することもできます。[IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) は関連する値のセットを表し、各[IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) はそのシリーズ内のポイントを表します。[IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) オブジェクトは、シリーズ間で共有されるラベルまたはグルーピング値を提供します。デフォルトデータで作成されたチャートでは、シリーズ名、カテゴリ、ポイント値はチャートワークブックの[IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) オブジェクトを使用します。

典型的なカテゴリチャートでは、デフォルトのワークブックは行 0 をシリーズ名に、列 0 をカテゴリ名に、残りのセルをシリーズ値に使用します。[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) に渡されるワークシート、行、列のインデックスはゼロベースです。このレイアウトはデフォルトデータでチャートを作成する際に便利ですが、すべての既存チャートがこのレイアウトを使用しているとは限りません。読み込んだプレゼンテーションの場合、ワークブックの値を変更する前に、シリーズ、カテゴリ、データポイントが参照しているセルを確認してください。

チャート設定には次の 3 つのスコープがあります。

- シリーズレベルの設定は、たとえば[IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) のように、1 つのシリーズ内のすべてのポイントのデフォルト外観を提供します。
- データポイントの設定は、たとえば[IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) のように、1 つのポイントに対してシリーズの外観を上書きします。
- グループ設定は、同じ[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) に属する互換性のあるシリーズに適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) を介してグループにアクセスしてください。

明示的なポイントまたはシリーズの塗りつぶしが設定されていない場合、チャートのスタイルとテーマが自動的な外観を決定します。シリーズとポイントの両方に書式設定がある場合、ポイントの書式設定がそのポイントに対して優先されます。

![chart-series-powerpoint](chart-series-powerpoint.png)

クラスター化シリンダチャートの場合、[changing the 3D series type or bar shape](/slides/ja/net/3d-chart/#change-the-3d-series-type-and-bar-shape) が最初のシリーズに与える影響をご確認ください。

## **数値リテラルを使用してシリーズの値を設定する**

シリーズの値がアプリケーションデータや計算結果から来ており、ワークシートセル参照が不要な場合は数値リテラルを使用します。[DataSourceTypeForValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforvalues/) を [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) に設定し、各ポイントの[Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/value/) を [AsLiteralDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/idoublechartvalue/asliteraldouble/) で割り当てます。

このコレクション設定は、シリーズ内のすべてのポイント値のソースタイプを制御します。各ポイントの[Value.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ibasechartvalue/datasourcetype/) は選択されたタイプを示し、コレクション設定で変更できます。`Worksheet` を使用する場合は [AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/isinglecellchartvalue/ascell/) で参照セルにアクセスします。`DoubleLiterals` を使用する場合は `AsLiteralDouble` で数値を直接読み書きします。

以下の例は、デフォルトのシリーズとカテゴリを持つ縦棒チャートを作成し、最初のシリーズの既存ポイントに 10、20、… と計算された値を割り当てます。プレゼンテーションを保存し、再度開いて格納された値を出力します。

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

ポイント値のソースタイプは、[IChartData.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/datasourcetype/) とは別で、チャートの内部または外部ワークブック構成を示します。数値リテラルを使用しても、埋め込みワークブック自体が自動的に削除されるわけではありません。この例では、ワークブックはカテゴリラベル、シリーズ名、他のシリーズのために引き続き利用可能です。ワークブックの管理については[Chart Workbook](/slides/ja/net/chart-workbook/) を参照してください。

散布図およびバブルチャートの場合、[DataSourceTypeForXValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforxvalues/) と [DataSourceTypeForYValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforyvalues/) を設定して、[XValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/xvalue/) と [YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/) のソースを選択します。バブルチャートはさらに[DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforbubblesizes/) を使用して[BubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/bubblesize/) を指定します。各該当ソースを `DoubleLiterals` に設定し、その値の `AsLiteralDouble` プロパティを通じて数値を割り当てます。

## **チャートシリーズのオーバーラップを設定する**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) は、2D チャートにおける棒や縦棒のオーバーラップ率を -100 から 100 パーセントで示します。これは親シリーズグループの設定の読み取り専用投影です。すべての互換シリーズに対してオーバーラップを更新するには、[IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) を設定してください。このオプションは、グループ化された棒や縦棒を表示するチャートタイプに適用され、組み合わせチャートの無関係なシリーズグループには影響しません。

次の例は、最初のシリーズを含むグループのオーバーラップを設定します。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// 新しいチャートにはサンプルのシリーズ、カテゴリ、値が含まれています。
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

結果:

![The series overlap](series_overlap.png)

## **シリーズの塗りつぶし色を変更する**

[IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) を使用して、シリーズ全体のデフォルト塗りつぶしを設定します。ポイントに明示的な塗りつぶしがすでにある場合、その[IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) 設定がそのポイントのシリーズ塗りつぶしを上書きします。

次の例は、最初のシリーズに単色の青い塗りつぶしを適用します。

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

![The color of the series](series_color.png)

## **シリーズ名を変更する**

シリーズ名はチャートデータワークブックに格納され、通常は凡例に表示されます。クラスター化縦棒チャート用にデフォルトで作成されたワークブックでは、セル B1 は行 0、列 1 に位置し、最初のシリーズ名が格納されています。以下の例の名前付き定数は、その構造を明示的に示しています。

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

また、[IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/) がすでに参照しているセルを更新することもできます。この方法は、既存のチャートで特定の行や列を前提としないため安全です。

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

![The series name](series_name.png)

### **複数セルから名前を作成する**

製品名と報告期間が別々のワークブックセルに格納されている場合、複合的なシリーズ名が便利です。たとえば、セル B1 の `Product A` とセル C1 の `2026` を結合して、両方のソースセルへのリンクを保ったまま単一のシリーズ名にできます。

[IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) を使用して名前範囲を取得し、そのコレクションを [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/) に渡します。`skipHiddenCells` 引数は非表示セルを含めるかどうかを制御します: `true` は除外し、`false` は含めます。この例では `false` を使用して名前範囲内のすべてのセルを含めています。

次の例は、1 つのシリーズと 2 つのデータポイントを持つプレゼンテーションを作成します。セル B1:C1 がシリーズ名だけを供給し、A2:A3 がカテゴリラベル、B2:B3 が数値を供給します。

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

// これらの 2 つのセルがシリーズ名を提供します。
workbook.GetCell(0, 0, 1, "Product A");
workbook.GetCell(0, 0, 2, "2026");
var nameCells = workbook.GetCellCollection("Sheet1!$B$1:$C$1", skipHiddenCells: false);
var series = chart.ChartData.Series.Add(nameCells, ChartType.ClusteredColumn);

// 個別のセルがカテゴリと数値データポイントを提供します。
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

結果として得られるシリーズ名は `Product A 2026` で、2 つのセル値の間にスペースが入ります。凡例ではこの 2 列が 1 つのエントリとして表示されます。以下の画像は保存されたプレゼンテーションからレンダリングしたものです。

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **自動シリーズ塗りつぶし色を取得する**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) は、シリーズインデックスとチャートスタイルから計算された色を返します。これは、シリーズの塗りつぶしが明示的に定義されていない場合に使用される色です。メソッドを呼び出すだけで色が取得され、新しい塗りつぶしは割り当てられません。

次の例は、デフォルトシリーズそれぞれの自動色を出力します。

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

デフォルトチャートスタイルの例出力:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

正確な色はチャートスタイルとテーマに依存します。

## **シリーズの負の値用に塗りつぶし色を反転する**

棒、縦棒、バブルシリーズの場合、[IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) を使用して負の値を別の塗りつぶしで表示できます。通常のシリーズ塗りつぶしを単色に設定し、反転を有効にし、負の値の色を [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) で割り当てます。負の数値はワークブック内でそのまま残り、表示色だけが変わります。

次の例は、デフォルトのチャートデータを 1 つのシリーズに置き換えます。ワークシートの行 0 にシリーズ名、列 0 にカテゴリ名、列 1 に値が格納されています。

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

![The inverted solid fill color](inverted_solid_fill_color.png)

ポイント単位で反転を有効にするには、[IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) を使用します。以下の例では、シリーズ全体の反転は無効にし、選択したポイントだけに有効にしています。そのポイントには負の値も割り当て、効果が見えるようにしています。

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

## **特定のデータポイントの値をクリアする**

他のポイントを削除せずに 1 つのポイントだけを空にするには、その基になるワークブックセルを `null` に設定します。縦棒チャートの場合、プロットされた値は[IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/) から取得できます。データポイントは同じカテゴリ位置に残りますが、チャートはブランク設定に従ってその値を空として扱います。

次の例は、最初のシリーズの 2 番目のポイントだけをクリアします。

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

散布図は X と Y のセルが別々に、バブルチャートはサイズセルも使用します。削除したい値に対応するセルだけをクリアしてください。ポイントコレクション全体を削除したいとき以外は [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) を呼び出さないでください。これはそのシリーズのすべてのデータポイントを削除します。

## **空セルの表示方法を制御する**

値を含む非表示セルは、空セルとは別のケースです。非表示のワークシート行や列からデータを含めるか除外する方法については、[Include Data from Hidden Rows and Columns](/slides/ja/net/chart-workbook/#include-data-from-hidden-rows-and-columns) を参照してください。

空のワークブックセルはデータが欠落していることを表し、`0` が入っているセルは既知の数値を表します。セルを空にしたい場合は[IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) を `null` に設定します。数値のゼロはブランク設定に関係なくゼロのままです。

[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) を使用して、チャートが空セルをどのように表示するかを選択します。この設定はチャート全体に適用され、空白のプロット方法を変更しますが、空のワークブックセルにゼロや補間値を自動で埋め込むことはありません。

次の自己完結型例は、1 系列の折れ線チャートを作成し、Day 3 の値をクリアし、各モードで同じチャートを保存します。入力ファイルは不要です。[IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) はワークシート 0、列 0 をカテゴリラベル、列 1 を値に使用し、行 0 にシリーズ名を格納します。最終データは `10, 20, empty, 30, 40` です。

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

各出力ファイルは保存前に設定されたモードを保持します: `empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 つだけ保存したい場合は、目的のモードを設定してプレゼンテーションを 1 回だけ保存すれば済みます。

以下の比較は、3 つのファイルすべてで同じデータがどのように表示されるかを示しています。Day 3 はすべてのワークブックで空です。

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可視効果はチャートタイプに依存します。折れ線チャートは 3 つのモードを比較しやすいですが、棒や縦棒チャートは欠落したカテゴリをつなぐラインがないため、`Span` が上図のような接続セグメントを生成できません。欠落した列とゼロ高さの列は見た目が似ることがあります。同様に、マーカーのみの散布図も接続ラインがありません。すべてのチャートタイプで 3 つの明確な結果が得られるとは限らないので、使用するタイプで出力を確認してください。

## **シリーズのギャップ幅を設定する**

ギャップ幅は、隣接する棒または縦棒クラスター間のスペースを棒または縦棒幅のパーセンテージで表したものです。オーバーラップと同様に、ギャップ幅は個々のシリーズではなく、親シリーズグループに属します。グループ全体に対して一度だけ[IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) を設定してください。値を大きくするとクラスター間のスペースが広がり、値を小さくすると密集します。

次の例はギャップ幅を変更し、最終プレゼンテーションだけを保存します。

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

![The gap width](gap_width.png)

## **シリーズラインの表示/非表示を切り替える**

シリーズラインは、チャートの関連部分を視覚的に接続します。[IChartSeriesGroup.HasSeriesLines](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/hasserieslines/) を使用して、サポートされている積み上げ棒および OfPie チャートで表示または非表示にできます。2 次元の積み上げ棒と縦棒チャートでは、カテゴリ間のスタック境界を接続します。Pie of Pie および Bar of Pie チャートでは、メインプロットとサブプロットを接続します。この設定は他のチャートタイプ向けの汎用コネクタではありません。

グループは[IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) を介してアクセスします。この設定はグループ内のすべてのシリーズに適用されます。[IChartSeries.HasSeriesLines](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/hasserieslines/) は読み取り専用で、親グループの設定を反映します。グループプロパティを変更して更新してください。

次の例は、デフォルトデータの[PieOfPie](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) チャートを 1 つ作成し、シリーズラインを有効にした状態と無効にした状態で同じチャートを保存し、比較用に 2 つのプレゼンテーションを生成します。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 400);
var series = chart.ChartData.Series[0];
var seriesGroup = series.ParentSeriesGroup;

seriesGroup.HasSeriesLines = true;
presentation.Save("series_lines_enabled.pptx", SaveFormat.Pptx);

seriesGroup.HasSeriesLines = false;
presentation.Save("series_lines_disabled.pptx", SaveFormat.Pptx);
```

| **シリーズライン有効** | **シリーズライン無効** |
| --- | --- |
| ![Pie of Pie chart with series lines enabled](series_lines_enabled.png) | ![Pie of Pie chart with series lines disabled](series_lines_disabled.png) |
| 2 本のラインがメインの円をサブの円に接続します。 | 両方の円は表示されますが、接続ラインは非表示になります。 |

シリーズラインは、データラベルのリーダーライン（ラベルとデータポイントを結ぶ線）や、軸目盛りを示すグリッドライン、データ値を表す折れ線チャートのラインとは異なります。この設定はそれらの要素を制御しません。

## **FAQ**

**どのチャートタイプがデータシリーズをサポートしていますか？**

[ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 列挙体で表されるすべてのチャートタイプはチャートデータを使用しますが、シリーズの値構造や設定はタイプごとに異なります。たとえば、カテゴリチャートはカテゴリと値を使用し、散布図は X と Y の値、バブルチャートはバブルサイズを追加します。シリーズタイプに合ったデータポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のある棒または縦棒グループにのみ適用されます。

**チャートシリーズグループとは何ですか？**

[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) は、グループレベルのプロット設定を共有する互換性のあるシリーズを格納します。組み合わせチャートは複数のグループを含むことができるため、あるシリーズを介してアクセスしたグループを変更しても、チャート内のすべてのシリーズが必ずしも変更されるわけではありません。

**新しく作成したチャートにはデフォルトデータが含まれますか？**

はい。デフォルトでは、[IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) はサンプルのシリーズ、カテゴリ、および値を作成します。これらのセルを編集するか、完全にカスタムのデータセットを追加する前にシリーズとカテゴリのコレクションをクリアできます。オーバーロードを使用すれば、デフォルトデータなしでチャートを作成することも可能です。

**チャートオブジェクトはワークブックセルとどのように接続されていますか？**

シリーズ名、カテゴリラベル、データポイントの値はすべて[IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) のセルを参照しています。参照セルを変更すると、対応するチャート要素が更新されます。カスタムデータを構築する際は、各ポイントが意図したカテゴリの下にプロットされるよう、カテゴリ行とシリーズ値行を揃えてください。

**シリーズ全体ではなく 1 つのポイントだけをクリアするにはどうすればよいですか？**

ポイントのバックエンドセルを `null` に設定して、ポイントのカテゴリ位置は保持したまま空のポイントにします。すべてのポイントを削除したい場合のみ、[IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) を使用してください。これはそのシリーズのすべてのデータポイントを削除します。

**空のポイントはどのように表示されますか？**

結果はチャートタイプと[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) の設定に依存します。サポートされるチャートは、空白をギャップ、ゼロ値、または隣接ポイントの接続として表示できます。プレゼンテーションのデータ欠損の意味に合った設定を選択してください。完全な例と視覚的比較については、[Control the Display of Empty Cells](#control-the-display-of-empty-cells) を参照してください。

**負の値はどのように書式設定されますか？**

サポートされる棒、縦棒、バブルシリーズについては、[IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) を有効にし、[IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) で負の値の色を設定します。個々のポイントについては、[IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) で動作を上書きできます。これらのプロパティは書式設定に影響し、格納された数値自体は変更しません。

**シリーズとポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータポイントの書式設定が、そのポイントに対して優先されます。他のポイントは明示的なシリーズ書式設定、またはシリーズ書式が未定義の場合は自動的なチャートスタイルとテーマが使用されます。オーバーラップやギャップ幅といったグループプロパティはレイアウトを制御し、ポイントレベルの書式上書きにはなりません。

**チャートに含められるシリーズの数に上限はありますか？**

Aspose.Slides には固定されたシリーズ数の上限はありません。実際には、プレゼンテーションファイルの容量、利用可能なメモリ、描画時間、チャートの可読性などが実用的な上限を決定します。

**列が近すぎる、または離れすぎる場合は何を変更すべきですか？**

適切な親シリーズグループの[IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) を設定してください。値を大きくするとクラスター間のスペースが広がり、小さくするとクラスターが近づきます。