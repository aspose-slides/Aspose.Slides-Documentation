---
title: ".NET のプレゼンテーションでチャート ワークブックを管理する"
linktitle: "チャート ワークブック"
type: docs
weight: 70
url: /ja/net/chart-workbook/
keywords:
- "チャート ワークブック"
- "チャート データ"
- "ワークブック セル"
- "データ ラベル"
- "ワークシート"
- "データ ソース"
- "外部ワークブック"
- "外部データ"
- "チャート キャッシュ"
- "ワークブック 復元"
- "PowerPoint"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET を発見し、PowerPoint および OpenDocument 形式でチャート ワークブックを簡単に管理して、プレゼンテーション データを効率化しましょう。"
---
## **概要**

この記事では、Aspose.Slides でチャート ワークブックを操作する方法を説明します。ワークブック ストリームを介してチャート データの読み取りと書き込みを行い、ワークブック セルをチャート データ ラベルとして使用し、ワークシートコレクションにアクセスし、チャート値のデータ ソース タイプを指定する方法を示します。

また、外部ワークブックをチャート データ ソースとして使用する方法についても説明します。例では、外部ワークブックを作成して割り当てる方法、チャートにリンクされた外部ワークブックのパスを取得する方法、およびワークブックが利用可能なときにチャート データを編集する方法を示します。

欠損データを表すワークブック セルについては、[空白セルの表示制御](/slides/ja/net/chart-series/) を参照してください。空白セルとゼロの違いや、利用可能な表示モードの折れ線グラフ比較が示されています。

## **非表示の行と列からデータを含める**

[IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) を使用して、チャートが非表示のワークシート行や列のデータをプロットするかどうかを制御します。`true` に設定すると表示セルのみがプロットされ、`false` に設定すると表示セルと非表示セルの両方が含まれます。この設定はチャートのプロット方法を制御しますが、ワークシートの行や列を非表示または表示にするものではありません。

この[サンプル プレゼンテーション](hidden-source-data.pptx)には、最初のスライドの最初のシェイプとして縦棒グラフが含まれています。埋め込みワークシート `Sheet1` には、ソース範囲 `A1:C4` が含まれています。行 3 と列 C は非表示ですが、セルにはまだ値が含まれています。

| ワークシート行 | A: 月 | B: 小売 | C: 卸売（非表示列） |
| --- | --- | --- | --- |
| 2 | 1月 | 10 | 30 |
| 3 (非表示行) | 2月 | 40 | 60 |
| 4 | 3月 | 20 | 50 |

[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) を使用してソース セルにアクセスし、[IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) を読み取って非表示ステータスを調べます。このプロパティは読み取り専用です。このファイルでは、B2 は表示され、B3 は非表示行に属し、C2 は非表示列に属します。例ではそれぞれ `False`、`True`、`True` が出力されます。

この例では、プロット設定を変更した後にチャート データを更新します。[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/)で埋め込みワークブックを保持し、[WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/)で再ロードします。すべてのセルを含める場合は、[SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) を使用して、非表示の 2 月カテゴリを含む完全な範囲を復元します。フラグを変更するだけでは、このサンプルのキャッシュされたチャート データとカテゴリ ラベルを更新するには不十分です。

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

この例では、プレゼンテーションを 2 つのバージョンで保存します。1 つは表示されている小売値 (10 と 20) のみ、もう 1 つはすべての 6 つの値です。以下の画像は、保存したプレゼンテーションを再度開いた後にレンダリングしたものです。両方のファイルは割り当てられたプロット設定を保持しています。行 3 と列 C は両方の埋め込みワークブックで引き続き非表示です。

| 表示セルのみ (`true`) | すべてのセル (`false`) |
| --- | --- |
| ![表示セルのみ: 1月と3月の小売値 10 と 20](hidden_cells_True.png) | ![すべてのセル: 1月、2月、3月の小売および卸売値](hidden_cells_False.png) |

値を含む非表示セルは空白セルとは異なります。[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) は欠落値の表示方法を制御しますが、非表示のソース データを含めたり除外したりはしません。例については、[空白セルの表示制御](/slides/ja/net/chart-series/#control-the-display-of-empty-cells) を参照してください。

## **チャートのデータ範囲を取得する**

既存のプレゼンテーションでワークブック データを更新する前に、ソース範囲を検査して各チャートが使用しているワークシートセルを特定します。[IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) メソッドは、現在のデータ範囲をワークシート限定の数式として返します。たとえば `Sheet1!$A$1:$D$5` のようになります。ここで `Sheet1` はワークシート名、`!` がセル範囲と区切り、`$A$1:$D$5` は A1 から D5（含む）までのセルを示します。ドル記号は絶対行・列参照を示します。

このメソッドは、チャートやワークブックを変更することなく現在の範囲を読み取ります。チャートがデータ ソースとしてワークブックを使用していない場合、[InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) がスローされます。詳細は[ChartData API リファレンス](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/)をご覧ください。

この例では、プレゼンテーションを開き、各スライド上のシェイプを直接チェックしてチャートを探します。各チャートの名前とソース範囲を出力します。チャートがワークブックを使用していない場合、メッセージを出力して次のチャートへ進みます。

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

## **ワークブックからチャート データを読み書きする**

Aspose.Slides for .NET は、[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) と [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) メソッドを提供し、チャート データワークブック（Aspose.Cells で編集されたチャート データを含む）を読み書きできます。**注意**: チャート データは同じ形式で構成するか、ソースに類似した構造である必要があります。

この例では、最初のスライドの最初のシェイプとしてチャートが含まれるプレゼンテーションを使用します。埋め込みワークブックをストリームに読み取り、既存の系列とカテゴリをクリアし、同じワークブックを再度書き戻します。変更はメモリ内に残り、例ではプレゼンテーションは保存されません。

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

埋め込みワークブックを変更されたものに置き換えると、チャートは元の系列とカテゴリ コレクションを保持します。この不一致により、[IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) がインデックス範囲外エラーで失敗することがあります。更新されたワークブックを書き戻す前に、既存の系列とカテゴリをクリアします。この例では、最初のスライドの最初のシェイプとしてチャートを使用します。コメントはワークブック編集が行われる場所を示しています。実行可能な例は元のワークブックを書き戻し、メモリ内でレイアウトを検証します。

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

コレクションをクリアすると、ワークブックを書き戻す前に古いデータ参照が削除されます。チャートを使用する前に、更新されたワークブック用に必要な系列およびカテゴリのマッピングを再構築してください。

## **ワークブックセルのカスタム数値書式を設定する**

[ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) を使用して、チャートの埋め込みワークブック内の数値の表示方法を制御します。たとえば、レポートで変換率を小数点以下4桁のパーセンテージで、係数を小数点以下5桁で表示する必要がある場合があります。両方の値は数値のまま保持し、計算やチャートのプロットで使用できるようにします。

数値書式は表示を変更するだけで、保存された値は変わりません。書式 `0.0000%` は `0.125` を `12.5000%` と表示しますが、保存された数値を `12.5` に置き換えるわけではありません。同様に、`0.00000` は `0.1234567` を `0.12346` と表示し、保存値は丸められません。カスタム書式が空文字列 (`""`) の場合は、[PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/) が使用されます。

以下の例では、縦棒グラフを作成し、[ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) を通じてセルにアクセスします。ワークシート 0 の B2 には変換率が、C2 には係数が格納されています。両方のセルがチャート値として使用されます。例では、ソース書式にリンクされた値ラベルも有効にしています。

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

ワークブックセルの書式は、チャートの軸やデータ ラベルに直接設定された書式とは別です。この例では、[ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) が有効になっているため各ラベルはソースセルの値を表示し、[IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) が `true` のためソースの数値書式に従います。プレゼンテーションを保存して再度開くと、ラベルは下図のように `12.5000%` と `0.12346` を表示します。縦軸は独自の [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) `0.00` を使用し、[IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) は `false` に設定されています。

データ ラベルを個別に書式設定するには、ソースリンク フラグを `false` に設定し、[NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) を割り当てます。これによりワークブックセルの書式は変更されません。たとえば、独立したラベル書式を `0.00` に設定すると、最初の値は `0.13` と表示されますが、B2 は依然として `12.5000%` を表示します。直接的なラベル書式設定については、[チャート データ ラベル](/slides/ja/net/chart-data-label/#set-percentage-sign-with-chart-data-labels) を参照してください。

以下の画像は、保存したプレゼンテーションを再度開いた後にレンダリングしたものです。

![ソースリンクされたラベルが 12.5000% と 0.12346 を表示し、独立して書式設定された数値軸](custom-cell-formats.png)

## **ワークブックセルをチャート データ ラベルとして設定する**

ワークブックセルのテキストをチャート データ ラベルとして使用できます。

この例では、既存のプレゼンテーションの最初のスライドにデフォルト データのバブル チャートを追加します。ワークシート 0 のセル A10:A12 を最初の系列の最初の 3 つのラベルとして使用し、セルからのラベルを有効にして、更新されたプレゼンテーションを保存します。

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

[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) プロパティは、チャート ワークブック内のワークシートへのアクセスを提供します。この例では、デフォルト データの円グラフを作成し、各ワークシート名をコンソールに出力します。

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

## **データ ソース タイプを指定する**

この例では、デフォルト データの 3D 縦棒グラフを作成し、異なるデータ ソースを使用して 2 つの系列名を設定します。最初の名前は文字列リテラルを使用し、2 番目の名前はワークシート 0 のセル C1 を使用します。[DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) 列挙体で各名前のソースを選択します。例では、更新された系列名でプレゼンテーションを保存します。

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

Aspose.Slides は、一部のチャートに埋め込むことができる Excel バイナリ ワークブック（.xlsb）形式をサポートしていません。[IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) の [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) プロパティと [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) 列挙体を組み合わせて、サポートされていない形式を検出し、該当チャートをスキップできます。この例では、既存のプレゼンテーションの最初のスライド上のシェイプを調査し、チャートでないシェイプをスキップし、埋め込み .xlsb ワークブックを持つ各チャートに診断メッセージを出力します。

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

    // ここでサポートされているチャート ワークブック データを読み取りまたは変更します。
}
```

## **外部ワークブック**

Aspose.Slides は、外部ワークブックをチャートのデータ ソースとして使用することをサポートします。

### **外部ワークブックの作成**

[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) と [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) を使用して、埋め込みチャート ワークブックをファイルにエクスポートし、チャートをその外部ワークブックにリンクします。

この例では、デフォルト データの円グラフを作成し、ワークブックをエクスポートします。外部ワークブックをチャート データ ソースとして割り当てる前に出力ストリームを閉じ、リンクされたプレゼンテーションを保存します。

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

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) メソッドを使用すると、外部ワークブックをチャートのデータ ソースとして割り当てることができます。このメソッドは、外部ワークブックのパスが変更された場合（移動された場合）にパスを更新するためにも使用できます。

リモート場所やリソースに保存されたワークブックのデータは編集できませんが、外部データ ソースとして使用することは可能です。外部ワークブックの相対パスが指定された場合、自動的に絶対パスに変換されます。

この例では、`Sheet1` という名前のワークシートに B1 に系列名、A2:A4 にカテゴリ名、B2:B4 に数値が格納された外部ワークブックを使用します。例では円グラフを作成し、ワークブックをリンクし、[SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) を使用して A1:B4 を 1 つの系列と 3 つのカテゴリにマッピングします。リンクされたチャートを含むプレゼンテーションを保存します。

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

* `updateChartData` が `false` の場合、ワークブック パスのみが更新されます。チャート データは対象ワークブックからロードまたは更新されないため、ワークブックが利用できなくても構いません。
* `updateChartData` が `true` の場合、チャート データは対象ワークブックから更新されます。

以下の例では、`updateChartData` を `false` に設定したプレースホルダー URL を割り当てます。円グラフのデフォルト データを保持し、利用できないワークブックをロードせずにプレゼンテーションを保存します。

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

この例では、外部ワークブックがリンクされたプレゼンテーションの最初のスライドの最初のシェイプを調査します。外部ワークブックにリンクされたチャートであれば、[ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) をコンソールに出力します。その後、プレゼンテーションのコピーを保存します。

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

外部ワークブックのデータは、内部ワークブックの内容を変更するのと同様に編集できます。外部ワークブックがロードできない場合は例外がスローされます。

この例では、最初のスライドの最初のシェイプとしてのチャートを使用し、アクセス可能な外部ワークブックにリンクしています。最初の系列の最初のデータ ポイントのセル裏付け値を 100 に設定し、更新されたプレゼンテーションを保存します。セルの値を編集すると、リンクされた外部 XLSX ファイルが更新される可能性があるため、元のワークブックを保持したい場合はコピーを使用してください。

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

チャートが欠落または利用できない外部ワークブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされたデータからチャート ワークブックを再構築できます。プレゼンテーションを開く前に、[LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) を作成し、その [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/) を構成し、[ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) を `true` に設定します。

以下の C# の例は、最初のスライドの最初のシェイプとしてのチャートで、利用できない外部ワークブックを参照している場合にワークブック データを復元します。復元されたデータは [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) と [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) を介してアクセスします。

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

    // ここで復元されたワークブック データを読み取りまたは変更します。
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

外部ワークブックが利用できず、復元が無効になっている場合、Aspose.Slides は [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) をスローします。キャッシュされたチャート データの使用が許容できるフォールバックである場合にのみ復元を有効にしてください。キャッシュには、プレゼンテーションが最後に更新された後に外部ワークブックで行われた変更が含まれていない可能性があります。

## **よくある質問**

**特定のチャートが外部ワークブックまたは埋め込みワークブックにリンクされているかどうかを判別できますか？**

はい。チャートは[data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) と[外部ワークブックへのパス](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) を持っています。ソースが外部ワークブックである場合、完全なパスを読み取ることで外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされていますか？また、どのように保存されますか？**

はい。相対パスを指定すると、自動的に絶対パスに変換されます。プレゼンテーションは PPTX ファイル内に絶対パスを保存するため、ワークブックを移動した場合はリンクの更新が必要になることがあります。

**ネットワーク リソース/共有上にあるワークブックを使用できますか？**

はい、そのようなワークブックは外部データ ソースとして使用できます。ただし、Aspose.Slides からリモートワークブックを直接編集することはサポートされていません。ソースとしてのみ使用可能です。

**プレゼンテーションを保存すると、Aspose.Slides は外部 XLSX を上書きしますか？**

プレゼンテーションは[外部ファイルへのリンク](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) を保存します。セル裏付けのチャート データを編集すると、リンクされたローカル XLSX ファイルも更新される可能性があります。元のファイルを変更せずに残す必要がある場合は、ワークブックのコピーを使用してください。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策として、事前に保護を解除するか、復号化したコピー（たとえば [Aspose.Cells](https://reference.aspose.com/cells/net/) を使用）を作成し、そのコピーにリンクします。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートはそれぞれリンクを保持します。すべてが同じファイルを指している場合、そのファイルを更新すると、次回データがロードされる際に各チャートに反映されます。