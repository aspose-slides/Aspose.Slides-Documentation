---
title: .NET のプレゼンテーションでチャート ワークブックを管理
linktitle: チャート ワークブック
type: docs
weight: 70
url: /ja/net/chart-workbook/
keywords:
- チャート ワークブック
- チャート データ
- ワークブック セル
- データ ラベル
- ワークシート
- データ ソース
- 外部 ワークブック
- 外部 データ
- チャート キャッシュ
- ワークブック 復元
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を発見: PowerPoint および OpenDocument 形式でチャート ワークブックを簡単に管理し、プレゼンテーション データを効率化します。"
---
## **概要**

この記事では、Aspose.Slides でチャート ワークブックを操作する方法を説明します。ワークブック ストリームを介してチャート データの読み取りと書き込みを行う方法、ワークブック セルをチャート データ ラベルとして使用する方法、ワークシート コレクションへのアクセス方法、チャート 値のデータ ソース タイプの指定方法を示します。

また、外部ワークブックをチャートのデータ ソースとして使用する方法も扱います。例では、外部ワークブックの作成と割り当て、チャートにリンクされた外部ワークブックのパスの取得、ワークブックが利用可能なときのチャート データの編集方法を示します。

欠損データを表すワークブック セルについては、[空白セルの表示制御](/slides/ja/net/chart-series/) を参照し、空白セルと 0 の違い、および利用可能な表示モードの折れ線グラフ比較をご確認ください。

## **非表示行と列からのデータを含める**

[IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) を使用して、チャートが非表示のワークシート 行および列からデータをプロットするかどうかを制御します。`true` に設定すると表示されているセルのみをプロットし、`false` に設定すると表示セルと非表示セルの両方を含めます。この設定はチャートのプロットにのみ影響し、ワークシートの行や列を非表示にしたり表示にしたりはしません。

[sample presentation](hidden-source-data.pptx) には、最初のスライドの最初のシェイプとして列グラフが含まれています。埋め込みワークシート `Sheet1` のソース範囲は `A1:C4` です。行 3 と列 C は非表示ですが、セルには値が残っています。

| ワークシート行 | A: 月 | B: 小売 | C: 卸売（非表示列） |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (非表示行) | February | 40 | 60 |
| 4 | March | 20 | 50 |

[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) でソースセルにアクセスし、[IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) で非表示ステータスを確認します。このプロパティは読み取り専用です。このファイルでは B2 が表示され、B3 が非表示行に属し、C2 が非表示列に属します。例はそれぞれ `False`、`True`、`True` を出力します。

この例では、プロット設定を変更した後にチャート データを更新します: [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) で埋め込みワークブックを取得し、[WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) で再ロードします。すべてのセルを含める場合は、[SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) も使用して非表示の February カテゴリを含む完全な範囲を復元します。フラグを変更するだけでは、このサンプルのキャッシュされたチャート データとカテゴリ ラベルは更新されません。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("hidden-source-data.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes[0] is IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    Console.WriteLine($"B2 hidden: {workbook.GetCell(0, "B2").IsHidden}");
    Console.WriteLine($"B3 hidden: {workbook.GetCell(0, "B3").IsHidden}");
    Console.WriteLine($"C2 hidden: {workbook.GetCell(0, "C2").IsHidden}");

    using var workbookStream = chart.ChartData.ReadWorkbookStream();
    foreach (var visibleOnly in new[] { true, false })
    {
        chart.PlotVisibleCellsOnly = visibleOnly;

        // 埋め込みワークブックからチャート データを更新します。
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // 非表示カテゴリを含む完全なソース範囲を復元します。
            chart.ChartData.SetRange("Sheet1!$A$1:$C$4");
        }

        presentation.Save($"hidden_cells_{visibleOnly}.pptx", SaveFormat.Pptx);
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

例はプレゼンテーションを 2 つのバージョンで保存します: 表示されている小売値 (10 と 20) のみを含むものと、すべての 6 値を含むものです。下の画像は再度開いた後に保存されたプレゼンテーションからレンダリングしたもので、両方のファイルが割り当てられたプロット設定を保持しています。行 3 と列 C は両方の埋め込みワークブックで非表示のままです。

| 表示セルのみ (`true`) | すべてのセル (`false`) |
| --- | --- |
| ![表示セルのみ: 1月と3月の小売値 10 と 20.](hidden_cells_True.png) | ![すべてのセル: 1月、2月、3月の小売および卸売値.](hidden_cells_False.png) |

値を含む非表示セルは空白セルとは異なります。[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) は欠損値の表示方法を制御しますが、非表示のソース データを含めるか除外するかは制御しません。[空白セルの表示制御](/slides/ja/net/chart-series/#control-the-display-of-empty-cells) を参照してください。

## **チャートのデータ範囲の取得**

既存のプレゼンテーションでワークブック データを更新する前に、各チャートが使用しているワークシート セルを特定するためにソース範囲を確認します。[IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) メソッドは、現在のデータ範囲を `Sheet1!$A$1:$D$5` のようなワークシート限定の数式として返します。ここで `Sheet1` がシート名、`!` がセル範囲との区切り、`$A$1:$D$5` が絶対参照のセル範囲を表します。

このメソッドはチャートやそのワークブックを変更せずに現在の範囲を読み取ります。チャートがワークブックをデータ ソースとして使用していない場合、[InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) がスローされます。詳しくは [ChartData API リファレンス](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/) を参照してください。

この例はプレゼンテーションを開き、各スライド上のシェイプを直接走査してチャートを検出します。各チャートの名前とソース範囲を出力し、ワークブックを使用していないチャートはメッセージを出力して次のチャートへ進みます。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            try
            {
                var range = chart.ChartData.GetRange();
                Console.WriteLine($"{chart.Name}: {range}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"{chart.Name}: The chart does not use a workbook as its data source.");
            }
        }
    }
}
```

## **ワークブックからのチャートデータの読み書き**

Aspose.Slides for .NET は、[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) と [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) メソッドを提供し、チャート データ ワークブック（Aspose.Cells で編集されたもの）を読み書きできます。**注意**: チャート データは同じ構造であるか、ソースに類似した構造である必要があります。

この例は最初のスライドの最初のシェイプとしてチャートを持つプレゼンテーションを使用します。埋め込みワークブックをストリームに読み取り、既存の系列とカテゴリをクリアし、同じワークブックを再度書き戻します。変更はメモリ内に残り、プレゼンテーションは保存されません。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **ワークブック変更後のチャートレイアウトの検証**

埋め込みワークブックを変更済みのものに置き換えると、チャートは元の系列とカテゴリ コレクションを保持します。この不整合により [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) がインデックス範囲外エラーで失敗することがあります。更新されたワークブックを書き戻す前に既存の系列とカテゴリをクリアしてください。この例は最初のスライドの最初のシェイプのチャートを使用します。コメントはワークブック編集が行われる場所を示しており、実行可能な例は元のワークブックを書き戻し、メモリ内でレイアウトを検証します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    // ここでワークブック ストリームを変更します。たとえば、Aspose.Cells を使用します。

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
    chart.ValidateChartLayout();
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

コレクションをクリアすることで、ワークブックを書き戻す前に古いデータ参照が除去されます。更新されたワークブックに合わせて必要な系列とカテゴリのマッピングを再構築してください。

## **ワークブックセルのカスタム数値形式の設定**

[ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) を使用して、チャートの埋め込みワークブック内の数値の表示形式を制御します。たとえば、レポートでコンバージョン率を小数点以下 4 桁のパーセンテージで、係数を小数点以下 5 桁の数値で表示したい場合があります。両方の値は数値として保持し、計算やチャート描画に利用できるようにします。

数値形式は表示を変更するだけで、保存される値は変わりません。形式 `0.0000%` は `0.125` を `12.5000%` と表示しますが、保存される数値は `0.125` のままです。同様に `0.00000` は `0.1234567` を `0.12346` と表示しますが、保存値は四捨五入されません。カスタム形式が空文字列 (`""`) の場合は、[PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/) が使用されます。

以下の例は列グラフを作成し、[ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) を介してセルにアクセスします。ワークシート 0 の B2 にコンバージョン率、C2 に係数が格納され、両方のセルがチャート値として使用されます。例では、ソース形式にリンクされた値ラベルも有効にしています。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 270, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
chart.HasTitle = false;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00";
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A2", "Sample");
chart.ChartData.Categories.Add(categoryCell);

var percentageCell = workbook.GetCell(0, "B2", 0.125);
percentageCell.CustomNumberFormat = "0.0000%";
var percentageName = workbook.GetCell(0, "B1", "Conversion rate");
var percentageSeries = chart.ChartData.Series.Add(percentageName, chart.Type);
percentageSeries.DataPoints.AddDataPointForBarSeries(percentageCell);

var precisionCell = workbook.GetCell(0, "C2", 0.1234567);
precisionCell.CustomNumberFormat = "0.00000";
var precisionName = workbook.GetCell(0, "C1", "Coefficient");
var precisionSeries = chart.ChartData.Series.Add(precisionName, chart.Type);
precisionSeries.DataPoints.AddDataPointForBarSeries(precisionCell);

foreach (var series in chart.ChartData.Series)
{
    var labelFormat = series.DataPoints[0].Label.DataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = true;
}

presentation.Save("CustomCellFormats.pptx", SaveFormat.Pptx);
```

ワークブックセルの形式は、チャート軸やデータ ラベルに直接設定された形式とは別です。この例では、各ラベルは [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) が有効で、[IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) が `true` のためソースセルの数値形式に従います。プレゼンテーションを保存して再度開くと、ラベルは `12.5000%` と `0.12346` を表示します。縦軸は独自の [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) `0.00` を使用し、[IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) は `false` に設定されています。

データ ラベルを独立して書式設定するには、ソースリンク フラグを `false` にし、[NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) を指定します。これによりワークブックセルの形式は変更されません。たとえば、独立したラベル形式 `0.00` は最初の値を `0.13` と表示し、B2 は依然として `12.5000%` を表示します。直接ラベル書式設定の例は [Chart Data Labels](/slides/ja/net/chart-data-label/#set-percentage-sign-with-chart-data-labels) を参照してください。

下の画像は保存されたプレゼンテーションを再度開いた後にレンダリングしたものです：

![ソースリンクされたラベルが 12.5000% と 0.12346 を表示し、独立して書式設定された数値軸を持つ列グラフ。](custom-cell-formats.png)

## **ワークブックセルをチャートデータ ラベルとして設定**

ワークブック セルのテキストをチャート データ ラベルとして使用できます。

この例は既存のプレゼンテーションの最初のスライドにバブル チャートを追加し、ワークシート 0 のセル A10:A12 を最初の系列の最初の 3 ラベルとして使用し、セルからのラベルを有効にして、更新されたプレゼンテーションを保存します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart2.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
var series = chart.ChartData.Series[0];
var workbook = chart.ChartData.ChartDataWorkbook;

series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;
series.Labels[0].ValueFromCell = workbook.GetCell(0, "A10", "Label 0 cell value");
series.Labels[1].ValueFromCell = workbook.GetCell(0, "A11", "Label 1 cell value");
series.Labels[2].ValueFromCell = workbook.GetCell(0, "A12", "Label 2 cell value");

presentation.Save("resultchart.pptx", SaveFormat.Pptx);
```

## **ワークシートの管理**

[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) プロパティは、チャート ワークブック内のワークシートへのアクセスを提供します。この例はデフォルト データの円グラフを作成し、各ワークシート名をコンソールに出力します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
var workbook = chart.ChartData.ChartDataWorkbook;

for (var i = 0; i < workbook.Worksheets.Count; i++)
{
    Console.WriteLine(workbook.Worksheets[i].Name);
}
```

## **データ ソース タイプの指定**

系列のポイント値は数値リテラルとして直接格納することもできます。[Set Series Values Using Numeric Literals](/slides/ja/net/chart-series/#set-series-values-using-numeric-literals) に完全な例があります。ポイント値のソース タイプはチャートの内部または外部ワークブック構成とは別で、数値リテラルを使用しただけで埋め込みワークブックが削除されるわけではありません。

この例はデフォルト データの 3D 列グラフを作成し、異なるデータ ソースを使用して 2 つの系列名を設定します。最初の名前は文字列リテラル、2 番目はワークシート 0 のセル C1 を使用します。[DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) 列挙体で各名前のソースを選択します。例は更新された系列名でプレゼンテーションを保存します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
var literalName = chart.ChartData.Series[0].Name;

literalName.DataSourceType = DataSourceType.StringLiterals;
literalName.Data = "LiteralString";

var cellName = chart.ChartData.Series[1].Name;
var nameCell = chart.ChartData.ChartDataWorkbook.GetCell(0, "C1", "NewCell");
cellName.DataSourceType = DataSourceType.Worksheet;
cellName.Data = nameCell;

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **サポートされていない埋め込みワークブック形式の検出**

Aspose.Slides は、いくつかのチャートに埋め込むことができる Excel バイナリ ワークブック (.xlsb) 形式をサポートしていません。[IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) の [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) プロパティと [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) 列挙体を組み合わせて、サポートされていない形式を検出し、該当チャートをスキップできます。この例は既存のプレゼンテーションの最初のスライド上のシェイプを調査し、チャートでないシェイプをスキップし、埋め込み .xlsb ワークブックを持つ各チャートに診断メッセージを出力します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
    {
        continue;
    }

    var chartData = chart.ChartData;
    var isInternalWorkbook = chartData.DataSourceType == ChartDataSourceType.InternalWorkbook;
    var isBinaryMacro = chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console.WriteLine("Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // ここでサポートされているチャート ワークブック データを読み取るまたは変更します。
}
```

## **外部ワークブック**

Aspose.Slides は、外部ワークブックをチャートのデータ ソースとして使用することをサポートしています。

### **外部ワークブックの作成**

[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) と [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) を使用して、埋め込みチャート ワークブックをファイルにエクスポートし、チャートをその外部ワークブックにリンクします。

この例はデフォルト データの円グラフを作成し、ワークブックをエクスポートします。外部ワークブックをチャート データ ソースとして割り当てる前に出力ストリームを閉じ、リンクされたプレゼンテーションを保存します。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
var workbookPath = Path.GetFullPath("externalWorkbook1.xlsx");

using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var fileStream = File.Create(workbookPath))
{
    workbookStream.CopyTo(fileStream);
}

chart.ChartData.SetExternalWorkbook(workbookPath);
presentation.Save("externalWorkbook.pptx", SaveFormat.Pptx);
```

### **外部ワークブックの設定**

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) メソッドを使用すると、外部ワークブックをチャートのデータ ソースとして割り当てることができます。このメソッドは、外部ワークブックへのパスが変更された場合（移動された場合）にも更新に使用できます。

リモート場所やリソースに保存されたワークブックのデータは編集できませんが、外部データ ソースとしては使用できます。外部ワークブックの相対パスが指定されている場合、自動的にフル パスに変換されます。

この例は、`Sheet1` という名前のワークシートに B1 に系列名、A2:A4 にカテゴリ名、B2:B4 に数値を持つ外部ワークブックを使用します。円グラフを作成し、ワークブックをリンクし、[SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) で A1:B4 を 1 系列と 3 カテゴリにマップします。リンクされたチャートとともにプレゼンテーションを保存します。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
var chartData = chart.ChartData;
var workbookPath = Path.GetFullPath("externalWorkbook.xlsx");

chartData.SetExternalWorkbook(workbookPath);
chartData.SetRange("Sheet1!$A$1:$B$4");

presentation.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
```

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) の `updateChartData` パラメータはワークブックがロードされるかどうかを制御します。

* `updateChartData` が `false` の場合、ワークブック パスのみが更新されます。チャート データはターゲット ワークブックからロードまたは更新されないため、ワークブックが利用できなくても構いません。
* `updateChartData` が `true` の場合、チャート データはターゲット ワークブックから更新されます。

以下の例は `updateChartData` を `false` に設定し、プレースホルダー URL を割り当てます。円グラフのデフォルト データは保持され、利用できないワークブックをロードせずにプレゼンテーションが保存されます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);

chart.ChartData.SetExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);
presentation.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
```

### **チャートの外部データ ソース ワークブック パスの取得**

チャートにリンクされたワークブックを特定するには、チャートが外部データ ソースを使用しているか確認し、ワークブック パスを取得します。

この例は、外部ワークブックにリンクされたプレゼンテーションの最初のスライドの最初のシェイプを調べます。外部ワークブックにリンクされたチャートであれば、[ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) をコンソールに出力し、プレゼンテーションのコピーを保存します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("externalWorkbook.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    if (chartData.DataSourceType == ChartDataSourceType.ExternalWorkbook)
    {
        Console.WriteLine(chartData.ExternalWorkbookPath);
    }
    else
    {
        Console.WriteLine("The chart does not use an external workbook.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

### **チャートデータの編集**

外部ワークブックのデータは、内部ワークブックと同様に編集できます。外部ワークブックがロードできない場合は例外がスローされます。

この例は最初のスライドの最初のシェイプとしてチャートがあり、アクセス可能な外部ワークブックにリンクされているケースです。最初の系列の最初のデータ ポイントのセル参照値を 100 に設定し、更新されたプレゼンテーションを保存します。セル値の編集はリンクされた外部 XLSX ファイルを更新できるため、元のワークブックを保持したい場合はコピーを使用してください。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var series = chart.ChartData.Series;
    if (series.Count > 0 && series[0].DataPoints.Count > 0)
    {
        var valueCell = series[0].DataPoints[0].Value.AsCell;
        if (valueCell != null)
        {
            valueCell.Value = 100;
            presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
        }
        else
        {
            Console.WriteLine("The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console.WriteLine("The chart has no data points to edit.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **チャートキャッシュからワークブックを復元**

チャートが欠落または利用できない外部ワークブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされたデータからチャート ワークブックを再構築できます。[LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) を作成し、[SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/) を構成し、[ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) を `true` に設定してプレゼンテーションを開く前に設定します。

以下の C# 例は、利用できない外部ワークブックを参照している最初のスライドの最初のシェイプのチャートのワークブック データを復元します。復元されたデータは [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) と [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) を介してアクセスされます：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

var spreadsheetOptions = new SpreadsheetOptions
{
    RecoverWorkbookFromChartCache = true
};
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = spreadsheetOptions
};

using var presentation = new Presentation("presentation.pptx", loadOptions);
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

    // ここで復元されたワークブック データを読み取るまたは変更します。
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

外部ワークブックが利用できず、復元が無効になっている場合、Aspose.Slides は [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) をスローします。キャッシュされたチャート データの使用が許容できるフォールバックである場合にのみ復元を有効にしてください。キャッシュには外部ワークブックが最後に更新された後の変更が含まれていない可能性があります。

## **FAQ**

**特定のチャートが外部ワークブックにリンクされているか、埋め込みワークブックにリンクされているかを判断できますか？**

はい。チャートは [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) と [path to an external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) を持ちます。ソースが外部ワークブックである場合、フル パスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされていますか？ それらはどのように保存されますか？**

はい。相対パスを指定すると自動的に絶対パスに変換されます。プレゼンテーションは PPTX ファイル内に絶対パスを保存するため、ワークブックを移動した場合はリンクの更新が必要になることがあります。

**ネットワーク リソース/共有上のワークブックを使用できますか？**

はい、そのようなワークブックは外部データ ソースとして使用できます。ただし、Aspose.Slides からリモートワークブックを直接編集することはサポートされていません。ソースとしてのみ使用できます。

**プレゼンテーションを保存すると、外部 XLSX が上書きされますか？**

プレゼンテーションは [link to the external file](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) を保存します。セル参照のチャート データを編集すると、リンクされたローカル XLSX ファイルも更新される可能性があります。元のワークブックを変更したくない場合は、コピーを使用してください。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的なアプローチは、事前に保護を解除するか、[Aspose.Cells](https://reference.aspose.com/cells/net/) などで復号化したコピーを作成してそのコピーにリンクすることです。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートは独自のリンクを保持します。すべてが同じファイルを指している場合、そのファイルを更新すれば次回データがロードされるときに各チャートに反映されます。