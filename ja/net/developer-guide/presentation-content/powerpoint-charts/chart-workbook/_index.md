---
title: .NETでプレゼンテーションのチャートワークブックを管理
linktitle: チャートワークブック
type: docs
weight: 70
url: /ja/net/chart-workbook/
keywords:
- チャートワークブック
- チャートデータ
- ワークブックセル
- データラベル
- ワークシート
- データソース
- 外部ワークブック
- 外部データ
- チャートキャッシュ
- ワークブック復元
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を発見：PowerPoint と OpenDocument 形式でチャートワークブックを簡単に管理し、プレゼンテーションデータを効率化します。"
---
## **概要**

この記事では、Aspose.Slides のチャート ワークブックの操作方法について説明します。ワークブック ストリームを使用してチャート データを読み書きする方法、ワークブック セルをチャート データ ラベルとして使用する方法、ワークシート コレクションにアクセスする方法、およびチャート値のデータ ソース タイプを指定する方法を示します。

また、外部ワークブックをチャート データ ソースとして使用する方法も取り上げます。例では、外部ワークブックを作成して割り当てる方法、チャートにリンクされた外部ワークブックのパスを取得する方法、ワークブックが利用可能な場合にチャート データを編集する方法を示します。

欠損データを表すワークブック セルについては、空セルとゼロの違い、および利用可能な表示モードの折れ線グラフ比較について、[Control the Display of Empty Cells](/slides/ja/net/chart-series/) を参照してください。

## **非表示行と列からデータを含める**

非表示のワークシート 行や列からデータをプロットするかどうかは、[IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) を使用して制御します。`true` に設定すると表示セルのみがプロットされ、`false` に設定すると表示セルと非表示セルの両方が含まれます。この設定はチャートのプロットを制御しますが、ワークシートの行や列を非表示または表示にするものではありません。

作業ディレクトリに [hidden-source-data.pptx](hidden-source-data.pptx) をダウンロードして配置してください。最初のスライドには最初のシェイプとして縦棒グラフが含まれています。埋め込みワークシート `Sheet1` には `A1:C4` のソース範囲が含まれています。行 3 と列 C は非表示ですが、セルには値が残っています。

| ワークシート行 | A: 月 | B: 小売 | C: 卸売（非表示列） |
| --- | --- | --- | --- |
| 2 | 1月 | 10 | 30 |
| 3（非表示行） | 2月 | 40 | 60 |
| 4 | 3月 | 20 | 50 |

[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdata/chartdataworkbook/) を通じてソースセルにアクセスし、[IChartDataCell.IsHidden](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatacell/ishidden/) を読み取って非表示状態を確認します。このプロパティは読み取り専用です。このファイルでは、B2 は表示され、B3 は非表示行に属し、C2 は非表示列に属します。例ではそれぞれ `False`、`True`、`True` が出力されます。

この例では、プロット設定を変更した後にチャート データをリフレッシュします: 埋め込みワークブックを [ReadWorkbookStream](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdata/readworkbookstream/) で保持し、[WriteWorkbookStream](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdata/writeworkbookstream/) で再ロードします。すべてのセルを含める場合は、[SetRange](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdata/setrange/) を使用して、非表示の 2 月カテゴリを含む完全な範囲を復元します。フラグを変更するだけでは、このサンプルのキャッシュされたチャート データやカテゴリ ラベルを更新するのに不十分です。

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

        // 埋め込みワークブックからチャート データをリフレッシュします。
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // 非表示のカテゴリを含む完全なソース範囲を復元します。
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

この例では、表示されている小売値 (10 と 20) のみを含む `hidden_cells_True.pptx` と、すべての 6 つの値を含む `hidden_cells_False.pptx` を保存します。下の画像は、保存したプレゼンテーションを再度開いた後にレンダリングしたものです。両ファイルとも割り当てられたプロット設定を保持しています。行 3 と列 C は両方の埋め込みワークブックで非表示のままです。

| 表示セルのみ (`true`) | すべてのセル (`false`) |
| --- | --- |
| ![表示セルのみ: 1月と3月の小売値 10 と 20](hidden_cells_True.png) | ![すべてのセル: 1月、2月、3月の小売および卸売値](hidden_cells_False.png) |

値を含む非表示セルは空セルとは異なります。[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichart/displayblanksas/) は欠損値の表示方法を制御しますが、非表示のソース データを含めたり除外したりはしません。例については、[Control the Display of Empty Cells](/slides/ja/net/chart-series/#control-the-display-of-empty-cells) を参照してください。

## **ワークブックからチャート データを読み書きする**

Aspose.Slides for .NET は、[ReadWorkbookStream](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdata/readworkbookstream/) および [WriteWorkbookStream](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdata/writeworkbookstream/) メソッドを提供し、チャート データワークブック（Aspose.Cells で編集されたチャート データを含む）を読み書きできます。**注**: チャート データは同じ方式で整理されているか、ソースと類似した構造である必要があります。

この例では、最初のスライドの最初のシェイプとしてチャートが含まれている必要がある `chart.pptx` を開きます。埋め込みワークブックをストリームに読み取り、既存の系列とカテゴリをクリアし、同じワークブックを書き戻します。変更はメモリ内に残り、例ではプレゼンテーションを保存しません。

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

### **ワークブック変更後のチャート レイアウトの検証**

埋め込みワークブックを修正版に置き換えると、チャートは元の系列とカテゴリ コレクションを保持したままになります。この不整合により、[IChart.ValidateChartLayout](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichart/validatechartlayout/) がインデックス範囲外エラーで失敗することがあります。更新されたワークブックを書き戻す前に、既存の系列とカテゴリをクリアしてください。この例では、最初のスライドの最初のシェイプとしてチャートがある `chart.pptx` が必要です。コメントはワークブック編集が行われる場所を示しています。実行可能な例は元のワークブックを書き戻し、メモリ内でレイアウトを検証します。

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

コレクションをクリアすると、ワークブックを書き戻す前に古いデータ参照が削除されます。チャートを使用する前に、更新されたワークブック用に必要な系列とカテゴリのマッピングを再構築してください。

## **ワークブック セルをチャート データ ラベルとして設定する**

ワークブック セルのテキストをチャート データ ラベルとして使用できます。以下の手順は、バブル チャートのラベルをデータ ワークブックのセルにリンクする方法を示します。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. ゼロベースのインデックスで最初のスライドにアクセスします。
3. デフォルト データでバブル チャートを追加します。
4. チャートの系列にアクセスします。
5. ワークブック セルをデータ ラベルとして設定します。
6. プレゼンテーションを保存します。

この例では、少なくとも 1 つのスライドが含まれている必要がある `chart2.pptx` を開き、デフォルト データのバブル チャートを追加します。ワークシート 0 のセル A10:A12 を最初の系列の最初の 3 つのラベルとして使用し、セルからのラベルを有効にして、結果を `resultchart.pptx` に保存します。

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

[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdataworkbook/worksheets/) プロパティは、チャート ワークブック内のワークシートへのアクセスを提供します。この例では、デフォルト データの円グラフを作成し、各ワークシート名をコンソールに出力します。

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

この例では、デフォルト データの 3D 縦棒グラフを作成し、異なるデータ ソースを使用して 2 つの系列名を設定します。最初の名前は文字列リテラルを使用し、2 番目の名前はワークシート 0 のセル C1 を使用します。[DataSourceType](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/datasourcetype/) 列挙体で各名前のソースを選択します。結果は `pres.pptx` に保存されます。

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

Aspose.Slides は、いくつかのチャートに埋め込むことができる Excel バイナリ ワークブック (.xlsb) 形式をサポートしていません。[IChartData](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdata/) の [EmbeddedWorkbookType](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) プロパティと [WorkbookType](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/workbooktype/) 列挙体を組み合わせて、サポートされていない形式を検出し、該当チャートをスキップできます。この例では、`sample.pptx` の最初のスライドのシェイプを調べ、チャート以外のシェイプをスキップし、埋め込み .xlsb ワークブックを持つ各チャートに診断メッセージを出力します。

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

    // ここでサポートされているチャート ワークブック データを読み取るか、変更します。
}
```

## **外部ワークブック**

Aspose.Slides は、外部ワークブックをチャートのデータ ソースとして使用することをサポートしています。

### **外部ワークブックの作成**

[ReadWorkbookStream](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdata/readworkbookstream/) と [SetExternalWorkbook](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdata/setexternalworkbook/) を使用して、埋め込みチャート ワークブックをファイルにエクスポートし、チャートをその外部ワークブックにリンクします。

この例では、デフォルト データの円グラフを作成し、ワークブックを `externalWorkbook1.xlsx` に書き込み、出力ストリームを閉じてからファイルをチャート データ ソースとして割り当てます。リンクされたプレゼンテーションは `externalWorkbook.pptx` に保存されます。

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

[SetExternalWorkbook](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdata/setexternalworkbook/) メソッドを使用すると、外部ワークブックをチャートのデータ ソースとして割り当てることができます。このメソッドは、外部ワークブックのパスを更新する（後者が移動された場合）際にも使用できます。

リモートの場所やリソースに保存されたワークブックのデータは編集できませんが、外部データ ソースとしては使用可能です。外部ワークブックの相対パスが指定された場合、自動的にフルパスに変換されます。

この例では、作業ディレクトリに `externalWorkbook.xlsx` が必要です。ワークシート `Sheet1` には、B1 に系列名、A2:A4 にカテゴリ名、B2:B4 に数値が入っている必要があります。例では円グラフを作成し、ワークブックをリンクし、[SetRange](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdata/setrange/) を使用して A1:B4 を 1 系列と 3 カテゴリにマッピングします。結果は `Presentation_with_externalWorkbook.pptx` に保存されます。

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

[SetExternalWorkbook](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdata/setexternalworkbook/) の `updateChartData` パラメーターは、ワークブックをロードするかどうかを制御します。

* `updateChartData` が `false` の場合、ワークブック パスのみが更新されます。チャート データはターゲット ワークブックからロードまたは更新されないため、ワークブックが利用できなくても構いません。
* `updateChartData` が `true` の場合、チャート データはターゲット ワークブックから更新されます。

以下の例では、`updateChartData` を `false` に設定したプレースホルダー URL を割り当てます。円グラフのデフォルト データを保持したまま、利用できないワークブックをロードせずにプレゼンテーションを保存します。

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

チャートにリンクされたワークブックを特定するには、まずチャートが外部データ ソースを使用しているか確認します。使用している場合、以下の手順でワークブック パスを取得できます。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. ゼロベースのインデックスで最初のスライドにアクセスします。
3. 最初のシェイプがチャートであることを確認します。
4. チャートのデータ ソース タイプを読み取ります。
5. ソースが外部ワークブックの場合、そのパスを読み取ります。

この例では、前述の例で作成した `externalWorkbook.pptx` を開き、最初のスライドの最初のシェイプを調べます。もしそれが外部ワークブックにリンクされたチャートであれば、例はコンソールに [ExternalWorkbookPath](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdata/externalworkbookpath/) を出力します。その後、プレゼンテーションのコピーを `Result.pptx` に保存します。

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

### **チャート データの編集**

外部ワークブックのデータは、内部ワークブックの内容を変更するのと同じ方法で編集できます。外部ワークブックをロードできない場合は例外がスローされます。

この例では、最初のスライドの最初のシェイプとしてチャートがある `presentation.pptx` と、アクセス可能な外部ワークブックが必要です。最初の系列の最初のデータポイントのセル参照値を 100 に設定し、プレゼンテーションを `presentation_out.pptx` に保存します。セル値の編集はリンクされた外部 XLSX ファイルを更新できるため、元のワークブックを保持したい場合はコピーを使用してください。

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

### **チャート キャッシュからワークブックを復元する**

チャートが欠損または利用不可の外部ワークブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされたデータからチャート ワークブックを再構築できます。プレゼンテーションを開く前に、[LoadOptions](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/) を作成し、その [SpreadsheetOptions](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/spreadsheetoptions/) を構成し、[ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ja/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) を `true` に設定します。

以下の C# 例は、最初のスライドの最初のシェイプが利用できない外部ワークブックを参照するチャートである必要がある `presentation.pptx` を開き、[IChart.ChartData](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichart/chartdata/) と [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdata/chartdataworkbook/) を介して復元されたデータにアクセスします。

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

    // ここで復元されたワークブック データを読み取るか、変更します。
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

外部ワークブックが利用できず、復元が無効になっている場合、Aspose.Slides は [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) をスローします。キャッシュされたチャート データの使用が許容できるフォールバックである場合にのみ復元を有効にしてください。キャッシュには、プレゼンテーションが最終更新された後に外部ワークブックで行われた変更が含まれていない可能性があります。

## **FAQ**

**特定のチャートが外部ワークブックまたは埋め込みワークブックにリンクされているか判別できますか？**

はい。チャートには [data source type](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/chartdata/datasourcetype/) と [path to an external workbook](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/chartdata/externalworkbookpath/) があり、ソースが外部ワークブックである場合は、完全なパスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされていますか？また、どのように保存されますか？**

はい。相対パスを指定すると、自動的に絶対パスに変換されます。プレゼンテーションは PPTX ファイルに絶対パスを保存するため、ワークブックを移動した場合はリンクの更新が必要になることがあります。

**ネットワーク リソース/共有上にあるワークブックを使用できますか？**

はい、そのようなワークブックは外部データ ソースとして使用できます。ただし、Aspose.Slides からリモートのワークブックを直接編集することはサポートされていません。ソースとしてのみ利用可能です。

**プレゼンテーションを保存すると、Aspose.Slides は外部 XLSX を上書きしますか？**

プレゼンテーションは [link to the external file](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/chartdata/externalworkbookpath/) を保存します。セル参照のチャート データを編集すると、リンクされたローカル XLSX ファイルも更新されることがあります。元のワークブックを変更せずに残す必要がある場合は、コピーを使用してください。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策として、事前に保護を解除するか、復号化したコピー（例: [Aspose.Cells](https://reference.aspose.com/cells/net/) を使用）を作成し、そのコピーにリンクします。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートは独自のリンクを保存します。すべてが同じファイルを指す場合、そのファイルを更新すると、次回データがロードされる際に各チャートに反映されます。