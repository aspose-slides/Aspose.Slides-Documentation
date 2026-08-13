---
title: .NET でプレゼンテーションのチャート データ シリーズを管理する
linktitle: データ シリーズ
type: docs
url: /ja/net/chart-series/
keywords:
- チャート シリーズ
- シリーズ 重なり
- シリーズ 色
- カテゴリ 色
- シリーズ 名称
- データ ポイント
- シリーズ 間隔
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# を使用して、プレゼンテーション内のチャート シリーズ、データ ポイント、ワークブック セル、書式設定、重なり、隙間幅、負の値の管理方法を学びます。"
---
## **概要**

チャートはプロットされたデータをチャート データ ワークブックに保存します。  
[IChartSeries](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseries/) は関連する値のセットを表し、シリーズ内の各[IChartDataPoint](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatapoint/) は 1 つまたは複数のワークブック セルを参照します。  
[IChartCategory](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartcategory/) オブジェクトはシリーズが共有するラベルまたはグループ化された値を提供します。シリーズ名、カテゴリ、ポイント値は [IChartDataCell](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatacell/) オブジェクトに接続されており、表示テキストとしてだけに保存されません。

典型的なカテゴリ チャートでは、デフォルトのワークブックは行 0 をシリーズ名に、列 0 をカテゴリ名に使用し、残りのセルをシリーズ値に使用します。  
[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdataworkbook/getcell/) に渡されるワークシート、行、列のインデックスはゼロベースです。このレイアウトはデフォルト データでチャートを作成するときに便利ですが、すべての既存チャートがこれを使用しているとは限りません。読み込んだプレゼンテーションの場合、ワークブックの値を変更する前に、シリーズ、カテゴリ、データ ポイントが参照しているセルを確認してください。

チャート設定には 3 つの異なるスコープがあります。

- シリーズ レベルの設定 (例: [IChartSeries.Format](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseries/format/)) は、1 つのシリーズ内のすべてのポイントに対するデフォルトの外観を提供します。
- データ ポイント設定 (例: [IChartDataPoint.Format](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatapoint/format/)) は、1 つのポイントに対してシリーズの外観を上書きします。
- グループ設定は、同じ[IChartSeriesGroup](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseriesgroup/) に属する互換性のあるシリーズに適用されます。オーバーラップや隙間幅などのオプションを設定する必要がある場合は、[IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseries/parentseriesgroup/) を通じてグループにアクセスしてください。

明示的なポイントまたはシリーズの塗りつぶしが設定されていない場合、チャートスタイルとテーマが自動的な外観を決定します。シリーズとポイントの両方の書式設定が存在する場合、ポイントの書式設定がそのポイントに対して優先されます。

![チャートシリーズPowerPoint](chart-series-powerpoint.png)

## **チャートシリーズの重なりを設定**

[IChartSeries.Overlap](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseries/overlap/) は、2D チャートにおける棒や列のオーバーラップ率を -100% から 100% の範囲で報告します。これは親シリーズ グループの設定の読み取り専用投影です。グループ内のすべての互換シリーズを更新するには、[IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseriesgroup/overlap/) を設定します。このオプションは、グループ化された棒または列を表示するチャートタイプに適用され、組み合わせチャートの無関係なシリーズ グループには影響しません。

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

// 新しいチャートにはサンプルのシリーズ、カテゴリ、および値が含まれています。
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

結果:

![シリーズの重なり](series_overlap.png)

## **シリーズの塗りつぶし色を変更**

[IChartSeries.Format](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseries/format/) を使用して、シリーズ全体のデフォルト塗りつぶしを設定します。ポイントに明示的な塗りつぶしが既にある場合、その [IChartDataPoint.Format](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatapoint/format/) 設定がそのポイントのシリーズ塗りつぶしを上書きします。

以下の例は、最初のシリーズにソリッド ブルーの塗りを適用します。

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

## **シリーズ名の変更**

シリーズ名はチャート データ ワークブックに格納され、通常は凡例に表示されます。クラスター化された縦棒チャート用に作成されたデフォルトのワークブックでは、セル B1 は行 0、列 1 にあり、最初のシリーズの名前が含まれます。以下の例の名前付き定数は、その構造を明示的に示しています。

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

また、[IChartSeries.Name](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseries/name/) が既に参照しているセルを更新することもできます。この方法は、既存チャートで特定の行や列を前提としないようにするためのものです。

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

## **自動シリーズ塗りつぶし色の取得**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) は、シリーズインデックスとチャートスタイルから計算された色を返します。これは、シリーズ塗りつぶしが明示的に定義されていない場合に使用される色です。メソッドを呼び出すと計算された色が取得されますが、新しい塗りつぶしは割り当てられません。

以下の例は、各デフォルトシリーズの自動色を出力します。

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

正確な色はチャートスタイルとテーマによって異なります。

## **チャートシリーズの反転塗りつぶし色を設定**

棒、縦棒、バブルシリーズでは、[IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseries/invertifnegative/) を使用して負の値を別の塗りつぶしで表示できます。通常のシリーズ塗りつぶしをソリッドに設定し、反転を有効にし、負の値の色を [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) で割り当てます。負の数はワークブック内で変更されず、表示色だけが変わります。

以下の例は、デフォルトのチャート データを 1 系列に置き換えます。ワークシートの行 0 に系列名、列 0 にカテゴリ名、列 1 に値が含まれます。

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

[IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) を使用して、1 ポイントだけの反転も有効にできます。以下の例では、シリーズ全体の反転は無効にし、選択したポイントだけに有効にしています。そのポイントには負の値も割り当てられ、効果が確認できます。

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

## **特定のデータポイントの値をクリア**

他のポイントを削除せずに 1 ポイントだけを空にするには、そのバックアップ ワークブック セルを `null` に設定します。縦棒チャートの場合、プロットされた値は [IChartDataPoint.YValue](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatapoint/yvalue/) で取得できます。データポイントは同じカテゴリ位置に残りますが、チャートは空白値設定に従ってその値を空白として扱います。

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

散布図は X と Y のセルを別々に使用し、バブルチャートはサイズセルも使用します。削除したい値に対応するセルだけをクリアしてください。他のポイントを保持したい場合は、[IChartDataPointCollection.Clear](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatapointcollection/clear/) を呼び出さないでください。これはコレクション内のすべてのデータポイントを削除します。

## **シリーズの隙間幅を設定**

隙間幅は隣接する棒または列クラスター間のスペースで、棒や列の幅のパーセンテージで表されます。オーバーラップと同様に、これは個々のシリーズではなく親シリーズ グループに属します。グループ全体に対して一度だけ [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) を設定します。値を大きくするとクラスター間のスペースが広がり、値を小さくすると密になります。

以下の例は隙間幅を変更し、最終プレゼンテーションだけを保存します。

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

![隙間幅](gap_width.png)

## **よくある質問**

**どのチャートタイプがデータ系列をサポートしていますか？**  
[ChartType](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/charttype/) 列挙体で表されるすべてのチャートタイプはチャート データを使用しますが、シリーズごとに同じ値構造や設定があるわけではありません。たとえば、カテゴリ チャートはカテゴリと値を使用し、散布図は X と Y の値を使用し、バブル チャートはバブル サイズを追加します。シリーズのタイプに合ったデータポイント作成メソッドを使用してください。オーバーラップや隙間幅などのオプションは、互換性のある棒や列のグループにのみ適用されます。

**チャートシリーズ グループとは何ですか？**  
[IChartSeriesGroup](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseriesgroup/) は、グループレベルの描画設定を共有する互換性のあるシリーズを含みます。組み合わせチャートは複数のグループを含むことができるため、あるシリーズを通じて取得したグループを変更しても、必ずしもチャート内のすべてのシリーズが変更されるわけではありません。

**新しく作成したチャートにはデフォルト データが含まれますか？**  
はい。デフォルトでは、[IShapeCollection.AddChart](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/addchart/) はサンプルのシリーズ、カテゴリ、値を作成します。これらのセルを編集するか、完全にカスタム データセットを追加する前にシリーズとカテゴリのコレクションの両方をクリアできます。オーバーロードを使用してデフォルト データなしでチャートを作成することも可能です。

**チャート オブジェクトはワークブック セルとどのように接続されていますか？**  
シリーズ名、カテゴリ ラベル、データポイント値は [IChartDataWorkbook](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdataworkbook/) のセルを参照しています。参照されたセルを変更すると、対応するチャート要素が更新されます。カスタム データを構築する際は、カテゴリ行とシリーズ値行が揃っていることを確認し、各ポイントが意図したカテゴリの下にプロットされるようにしてください。

**シリーズ全体ではなく、1つのポイントだけをクリアするにはどうすればよいですか？**  
該当する値セルを `null` に設定すると、ポイントのカテゴリ位置は保持されたまま空のポイントとして残ります。[IChartDataPointCollection.Clear](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatapointcollection/clear/) は、そのシリーズのすべてのポイントを削除したいときにのみ使用してください。カテゴリも削除する場合は、すべてのシリーズの値がカテゴリ コレクションと整合するように更新してください。

**空のポイントはどのように表示されますか？**  
結果はチャート タイプと [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichart/displayblanksas/) の設定に依存します。サポートされているチャートは、空白をギャップ、ゼロ値、または隣接ポイントを結んで表示することができます。プレゼンテーションでの欠損データの意味に合わせて設定を選択してください。

**負の値はどのようにフォーマットされますか？**  
サポートされている棒、縦棒、バブル 系列では、[IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseries/invertifnegative/) を有効にし、[IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) で負の値の色を設定します。個々のポイントについては、[IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) で動作を上書きできます。これらのプロパティは書式設定に影響し、格納された数値そのものは変更しません。

**シリーズとポイントの両方がフォーマットされた場合、どちらのフォーマットが優先されますか？**  
明示的なデータポイントの書式設定がそのポイントに対して優先されます。他のポイントは明示的なシリーズ書式設定、またはシリーズ書式設定が未定義の場合は自動的なチャートスタイルとテーマを使用し続けます。オーバーラップや隙間幅などのグループ プロパティはレイアウトを制御し、ポイントレベルの書式設定の上書きとはなりません。

**チャートに含められるシリーズ数に制限がありますか？**  
Aspose.Slides には固定されたシリーズ数の上限は設定されていません。実際には、プレゼンテーション ファイルの制約、利用可能なメモリ、レンダリング時間、およびチャートの可読性が実用的な上限を決定します。

**列が近すぎる、または離れすぎる場合は何を変更すべきですか？**  
適切な親シリーズ グループの [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) を設定してください。値を大きくするとクラスター間のスペースが広がり、値を小さくするとクラスターが近づきます。