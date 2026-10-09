---
title: .NET のプレゼンテーションでチャート ワークブックを管理する
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
description: "Aspose.Slides for .NET を発見：PowerPoint と OpenDocument 形式でチャートワークブックを簡単に管理し、プレゼンテーション データを合理化します。"
---
## **概要**

この記事では、Aspose.Slides のチャートワークブックの操作方法を説明します。ワークブックストリームを介してチャートデータを読み書きする方法、ワークブックのセルをチャートデータラベルとして使用する方法、ワークシートコレクションへのアクセス方法、およびチャート値のデータソースタイプを指定する方法を示します。

また、外部ワークブックをチャートのデータソースとして使用する方法もカバーします。例では、外部ワークブックの作成と割り当て、チャートにリンクされた外部ワークブックのパス取得、ワークブックが利用可能な場合のチャートデータの編集方法を示します。

欠損データを表すワークブックセルについては、[空白セルの表示制御](/slides/ja/net/chart-series/) を参照し、空白セルとゼロの違い、利用可能な表示モードの折れ線グラフ比較をご確認ください。

## **非表示行と列からデータを含める**

[IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) を使用して、チャートが非表示のワークシート行や列からデータをプロットするかどうかを制御できます。`true` に設定すると表示セルのみをプロットし、`false` に設定すると表示セルと非表示セルの両方を含めます。この設定はチャートのプロットにのみ影響し、ワークシートの行や列の非表示/表示状態を変更するものではありません。

[sample presentation](hidden-source-data.pptx) には、最初のスライドの最初のシェイプとして列グラフが含まれています。埋め込みワークシート `Sheet1` には `A1:C4` のソース範囲があります。3 行目と C 列は非表示ですが、セルには値が入っています。

| ワークシート 行 | 月 | 小売 | 卸売 (非表示列) |
| --- | --- | --- | --- |
| 2 | 1月 | 10 | 30 |
| 3 (非表示行) | 2月 | 40 | 60 |
| 4 | 3月 | 20 | 50 |

[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) でソースセルにアクセスし、[IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) を読み取って非表示ステータスを調べます。このプロパティは読み取り専用です。このファイルでは B2 は表示、B3 は非表示行に属し、C2 は非表示列に属します。例ではそれぞれ `False`、`True`、`True` が出力されます。

この例では、プロット設定を変更した後にチャートデータを更新します。埋め込みワークブックは [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) で保持し、[WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) で再ロードします。すべてのセルを含める場合は、[SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) を使用して、非表示の 2 月カテゴリを含む完全な範囲を復元します。フラグを変更するだけでは、このサンプルのキャッシュされたチャートデータとカテゴリラベルは更新されません。

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

        // 埋め込みワークブックからチャートデータを更新します。
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

例は、表示セルのみ（小売値 10 と 20）だけを含むプレゼンテーションと、すべての 6 つの値を含むプレゼンテーションの 2 つのバージョンを保存します。下の画像は、保存後に再度開いたプレゼンテーションからレンダリングしたものです。両方のファイルは割り当てられたプロット設定を保持しています。3 行目と C 列は両方の埋め込みワークブックで非表示のままです。

| 表示セルのみ (`true`) | すべてのセル (`false`) |
| --- | --- |
| ![表示セルのみ: 1月と3月の小売値 10 と 20.](hidden_cells_True.png) | ![すべてのセル: 1月、2月、3月の小売と卸売の値.](hidden_cells_False.png) |

値を含む非表示セルは、空白セルとは異なります。[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) は欠損値の表示方法を制御しますが、非表示ソースデータの含有・除外は行いません。例については、[空白セルの表示制御](/slides/ja/net/chart-series/#control-the-display-of-empty-cells) を参照してください。

## **チャートのデータ範囲の取得**

既存のプレゼンテーションでワークブックデータを更新する前に、ソース範囲を調べて各チャートが使用しているワークシートセルを特定します。[IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) メソッドは、現在のデータ範囲をワークシート限定の数式として返します。例: `Sheet1!$A$1:$D$5`。ここで `Sheet1` がシート名、`!` がセル範囲との区切り、`$A$1:$D$5` が絶対参照のセル範囲です。

このメソッドはチャートやそのワークブックを変更せずに現在の範囲を取得します。チャートがワークブックをデータソースとして使用していない場合は、[InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) がスローされます。詳細は [ChartData API Reference](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/) を参照してください。

この例はプレゼンテーションを開き、各スライドのシェイプを直接調べてチャートを検出します。各チャートの名前とソース範囲を出力し、ワークブックを使用しないチャートはメッセージを出力して次のチャートへ進みます。

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

## **ワークブックからチャートデータを読み書きする**

Aspose.Slides for .NET は、[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) および [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) メソッドを提供し、チャートデータワークブック（Aspose.Cells で編集されたチャートデータを含む）を読み書きできます。**注:** チャートデータは同じ構造で整理されているか、元データに類似した構造である必要があります。

この例は、最初のスライドの最初のシェイプとしてチャートを含むプレゼンテーションを使用します。埋め込みワークブックをストリームに読み込み、既存の系列とカテゴリをクリアし、同じワークブックを再度書き戻します。変更はメモリ上に残り、プレゼンテーションは保存されません。

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

埋め込みワークブックを変更済みのものに置き換えると、チャートは元の系列とカテゴリコレクションを保持します。この不整合により [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) がインデックス範囲外エラーで失敗することがあります。更新されたワークブックを書き戻す前に、既存の系列とカテゴリをクリアしてください。この例は最初のスライドの最初のシェイプとしてのチャートを使用します。コメント位置にワークブック編集が入ることを示しており、実行可能な例は元のワークブックを書き戻し、メモリ内でレイアウトを検証します。

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

    // ワークブックストリームをここで変更します。たとえば、Aspose.Cells を使用します。

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

コレクションをクリアすることで、ワークブックを書き戻す前に古いデータ参照が削除されます。更新されたワークブックに対して必要な系列やカテゴリのマッピングを再構築してからチャートを使用してください。

## **ワークブックセルをチャートデータラベルとして設定する**

ワークブックセルのテキストをチャートデータラベルとして使用できます。

この例は、既存のプレゼンテーションの最初のスライドにデフォルトデータのバブルチャートを追加し、ワークシート 0 のセル A10:A12 を最初の系列の最初の 3 つのラベルとして使用し、セルからのラベルを有効にして更新されたプレゼンテーションを保存します。

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

[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) プロパティは、チャートワークブック内のワークシートへのアクセスを提供します。この例はデフォルトデータの円グラフを作成し、各ワークシート名をコンソールに出力します。

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

## **データソースタイプを指定する**

この例はデフォルトデータの 3D 列グラフを作成し、異なるデータソースを使用して 2 つの系列名を設定します。最初の名前は文字列リテラル、2 番目の名前はワークシート 0 のセル C1 を使用します。[DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) 列挙体で各名前のソースを選択します。例は更新された系列名でプレゼンテーションを保存します。

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

Aspose.Slides は、一部のチャートに埋め込むことができる Excel バイナリワークブック（.xlsb）形式をサポートしていません。[EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) プロパティを [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) と共に、[WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) 列挙体で使用して、サポートされていない形式を検出し、該当チャートをスキップできます。この例は既存のプレゼンテーションの最初のスライドのシェイプを調べ、非チャートシェイプをスキップし、埋め込み .xlsb ワークブックを持つ各チャートに診断メッセージを出力します。

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

    // ここでサポートされているチャートワークブックデータを読み取るか変更します。
}
```

## **外部ワークブック**

Aspose.Slides は、外部ワークブックをチャートのデータソースとして使用することをサポートします。

### **外部ワークブックの作成**

[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) と [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) を使用して、埋め込みチャートワークブックをファイルにエクスポートし、チャートをその外部ワークブックにリンクします。

この例はデフォルトデータの円グラフを作成し、ワークブックをエクスポートします。外部ワークブックをチャートデータソースとして割り当てる前に出力ストリームを閉じ、リンクされたプレゼンテーションを保存します。

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

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) メソッドを使用すると、外部ワークブックをチャートのデータソースとして割り当てることができます。このメソッドは、外部ワークブックのパスを更新する際（ワークブックが移動された場合）にも使用できます。

リモートロケーションやリソースに保存されたワークブックのデータを編集することはできませんが、外部データソースとして使用することは可能です。相対パスが指定された場合、フルパスに自動変換されます。

この例は、`Sheet1` という名前のワークシートに B1 に系列名、A2:A4 にカテゴリ名、B2:B4 に数値を持つ外部ワークブックを使用します。例は円グラフを作成し、ワークブックをリンクし、[SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) を使用して A1:B4 を 1 系列と 3 カテゴリにマッピングします。リンクされたチャートでプレゼンテーションを保存します。

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

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) の `updateChartData` パラメータは、ワークブックをロードするかどうかを制御します。

* `updateChartData` が `false` の場合、ワークブックパスのみが更新されます。チャートデータは対象ワークブックからロードまたは更新されないため、ワークブックが利用できない状態でも構いません。
* `updateChartData` が `true` の場合、対象ワークブックからチャートデータが更新されます。

以下の例は `updateChartData` を `false` に設定したプレースホルダー URL を割り当てます。円グラフのデフォルトデータは保持され、利用できないワークブックをロードせずにプレゼンテーションを保存します。

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

### **チャートの外部データソースワークブックパスを取得する**

チャートにリンクされたワークブックを特定するには、チャートが外部データソースを使用しているか確認し、ワークブックパスを取得します。

この例は、外部ワークブックがリンクされたプレゼンテーションの最初のスライドの最初のシェイプを調べます。外部ワークブックにリンクされたチャートであれば、[ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) をコンソールに出力し、プレゼンテーションのコピーを保存します。

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

外部ワークブックのデータは、内部ワークブックと同様に編集できます。外部ワークブックをロードできない場合は例外がスローされます。

この例は、最初のスライドの最初のシェイプとしてのチャートを使用し、アクセス可能な外部ワークブックにリンクしています。最初の系列の最初のデータポイントのセルバック値を 100 に設定し、更新されたプレゼンテーションを保存します。セル値の編集はリンクされた外部 XLSX ファイルを更新できるため、元のワークブックを残したい場合はコピーを使用してください。

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

### **チャートキャッシュからワークブックを復元する**

チャートが欠損または利用不可の外部ワークブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされているデータからチャートワークブックを再構築できます。[LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) を作成し、[SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/) を構成し、[ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) を `true` に設定してからプレゼンテーションを開きます。

以下の C# 例は、最初のスライドの最初のシェイプとしてのチャートが利用不可の外部ワークブックを参照している場合に、ワークブックデータを復元します。復元されたデータは [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) と [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) を介してアクセスします。

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

    // ここで復元されたワークブックデータを読み取るか変更します。
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

外部ワークブックが利用不可で復元が無効な場合、Aspose.Slides は [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) をスローします。キャッシュされたチャートデータを使用することが許容できる場合にのみ復元を有効にしてください。キャッシュには外部ワークブックが最後に更新された後の変更が含まれていない可能性があります。

## **よくある質問**

**特定のチャートが外部ワークブックにリンクされているか、埋め込みワークブックかを判別できますか？**

はい。チャートには [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) と [path to an external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) があり、外部ワークブックが使用されている場合はフルパスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされていますか？ それらはどのように保存されますか？**

はい。相対パスを指定すると、自動的に絶対パスに変換されます。プレゼンテーションは PPTX ファイル内に絶対パスを保存するため、ワークブックを移動した場合はリンクの更新が必要になることがあります。

**ネットワークリソース/共有上のワークブックを使用できますか？**

はい、そのようなワークブックは外部データソースとして使用できます。ただし、Aspose.Slides からリモートワークブックを直接編集することはサポートされていません。ソースとしてのみ使用可能です。

**プレゼンテーションを保存するときに Aspose.Slides は外部 XLSX を上書きしますか？**

プレゼンテーションは外部ファイルへの [link to the external file](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) を保持します。セルバックチャートデータの編集はリンクされたローカル XLSX ファイルも更新する可能性があります。元のワークブックを変更したくない場合は、コピーを使用してください。

**外部ファイルがパスワードで保護されている場合はどうすべきですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策は、事前に保護を解除するか、[Aspose.Cells](https://reference.aspose.com/cells/net/) などで復号化したコピーを作成し、そのコピーにリンクすることです。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートは独自のリンクを保持します。すべてが同じファイルを指していれば、そのファイルを更新することで次回データが読み込まれる際にすべてのチャートに反映されます。