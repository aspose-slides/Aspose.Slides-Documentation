---
title: .NET でプレゼンテーションのチャート ワークブックを管理する
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
- 外部ワークブック
- 外部データ
- チャート キャッシュ
- ワークブック 復元
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を発見し、PowerPoint と OpenDocument 形式でチャート ワークブックを簡単に管理して、プレゼンテーション データを効率化しましょう。"
---
## **概要**

この記事では、Aspose.Slides でチャート ワークブックを操作する方法を説明します。ワークブック ストリームを介してチャート データを読み書きする方法、ワークブックのセルをチャート データ ラベルとして使用する方法、ワークシート コレクションにアクセスする方法、チャート値のデータ ソース タイプを指定する方法を示します。

また、外部ワークブックをチャート データ ソースとして使用する方法も取り上げます。例では、外部ワークブックの作成と割り当て、チャートにリンクされた外部ワークブックのパス取得、ワークブックが利用可能なときのチャート データの編集方法を示します。

## **ワークブックからチャートデータの読み取りと書き込み**
Aspose.Slides は、[ReadWorkbookStream](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdata/readworkbookstream/) と [WriteWorkbookStream](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdata/writeworkbookstream/) メソッドを提供し、チャート データ ワークブック (Aspose.Cells で編集されたチャート データを含む) の読み取りと書き込みが可能です。**注**: チャート データは同じ形式で構成されているか、元データに似た構造である必要があります。

この C# コードはサンプル操作を示します:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation pres = new Presentation("chart.pptx"))
{
    Chart chart = (Chart) pres.Slides[0].Shapes[0];
    IChartData data = chart.ChartData;

    MemoryStream stream = data.ReadWorkbookStream();

    data.Series.Clear();
    data.Categories.Clear();

    stream.Position = 0;
    data.WriteWorkbookStream(stream);
}
```

## **ワークブックのセルをチャート データ ラベルとして設定**
1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. データを含むバブル チャートを追加します。  
1. チャート シリーズにアクセスします。  
1. ワークブック セルをデータ ラベルとして設定します。  
1. プレゼンテーションを保存します。

この C# コードはワークブック セルをチャート データ ラベルとして設定する方法を示します:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します

using (Presentation pres = new Presentation("chart2.pptx"))
{
    ISlide slide = pres.Slides[0];


    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);

    IChartSeriesCollection series = chart.ChartData.Series;

    series[0].Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

    IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

    series[0].Labels[0].ValueFromCell = wb.GetCell(0, "A10", lbl0);
    series[0].Labels[1].ValueFromCell = wb.GetCell(0, "A11", lbl1);
    series[0].Labels[2].ValueFromCell = wb.GetCell(0, "A12", lbl2);

    pres.Save("resultchart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **ワークシートの管理**

この C# コードは、[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) プロパティを使用してワークシート コレクションにアクセスする操作を示します:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **データ ソース タイプの指定**

この C# コードはデータ ソースのタイプを指定する方法を示します:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.ChartData.Series[0].Name;
    
    val.DataSourceType = DataSourceType.StringLiterals;
    val.Data = "LiteralString";

    val = chart.ChartData.Series[1].Name;
    val.Data = chart.ChartData.ChartDataWorkbook.GetCell(0, "B1", "NewCell");

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **サポートされていない埋め込みワークブック形式の検出**

Aspose.Slides は、一部のチャートに埋め込むことができる Excel バイナリ ワークブック (*.xlsb*) 形式をサポートしていません。`EmbeddedWorkbookType` プロパティを [IChartData](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdata/) と共に使用し、[WorkbookType](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/workbooktype/) 列挙体でサポートされていない形式を検出して該当チャートをスキップできます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        if (shape is not IChart chart) continue;

        var chartData = chart.ChartData;

        if (chartData.DataSourceType == ChartDataSourceType.InternalWorkbook &&
            chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro)
        {
            // 埋め込みワークブックは .xlsb 形式で、サポートされていません。
            continue;
        }

        // ここでチャート ワークブック データを読み取るか、変更します。
    }
}
```

## **外部ワークブック**

{{% alert color="info" %}} 
[Aspose.Slides 19.4](https://docs.aspose.com/slides/ja/net/aspose-slides-for-net-19-4-release-notes/) では、チャートのデータ ソースとして外部ワークブックを使用する機能を実装しました。 
{{% /alert %}} 

### **外部ワークブックの作成**
**`ReadWorkbookStream`** と **`SetExternalWorkbook`** メソッドを使用すると、外部ワークブックを新規作成するか、内部ワークブックを外部化できます。

この C# コードは外部ワークブックの作成プロセスを示します:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    const string workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
    using (FileStream fileStream = new FileStream(workbookPath, FileMode.Create))
    {
        byte[] workbookData = chart.ChartData.ReadWorkbookStream().ToArray();
        fileStream.Write(workbookData, 0, workbookData.Length);
    }
    
    chart.ChartData.SetExternalWorkbook(Path.GetFullPath(workbookPath));

    pres.Save("externalWorkbook.pptx", SaveFormat.Pptx);
}
```

### **外部ワークブックの設定**
**`SetExternalWorkbook`** メソッドを使用して、外部ワークブックをチャートのデータ ソースとして割り当てられます。このメソッドは、外部ワークブックのパスが変更された場合にも更新に利用できます。

リモート場所やリソースに保存されたワークブックのデータを直接編集することはできませんが、外部データ ソースとして使用できます。相対パスが指定された場合は、自動的にフル パスに変換されます。

この C# コードは外部ワークブックの設定方法を示します:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// ドキュメント ディレクトリへのパス。
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.ChartData;
                    
    chartData.SetExternalWorkbook(Path.GetFullPath("externalWorkbook.xlsx"));
                  

    chartData.Series.Add(chartData.ChartDataWorkbook.GetCell(0, "B1"), ChartType.Pie);
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B2"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B3"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B4"));

    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A2"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A3"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A4"));
    pres.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
}
```

`SetExternalWorkbook` メソッドの `ChartData` パラメーターは、Excel ワークブックをロードするかどうかを指定します。

* `ChartData` が `false` に設定されている場合、ワークブック パスのみが更新され、チャート データは対象ワークブックからロードまたは更新されません。対象ワークブックが存在しない、または利用できない状況でこの設定を使用できます。  
* `ChartData` が `true` に設定されている場合、対象ワークブックからチャート データが更新されます。

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **チャートの外部データ ソース ワークブック パスの取得**

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. チャート シェイプのオブジェクトを作成します。  
1. チャートのデータ ソースを表す `ChartDataSourceType` オブジェクトを作成します。  
1. ソース タイプが外部ワークブック データ ソース タイプと同じであることを条件として指定します。

この C# コードは操作を示します:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[1];
    IChart chart = (IChart)slide.Shapes[0];
    ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        string path = chart.ChartData.ExternalWorkbookPath;
    }
    
    // プレゼンテーションを保存します
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **チャート データの編集**

外部ワークブックのデータは、内部ワークブックの内容を変更するのと同じ方法で編集できます。外部ワークブックをロードできない場合は例外がスローされます。

この C# コードは上記プロセスの実装例です:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **チャート キャッシュからワークブックを復元**

チャートが存在しない、または利用できない外部ワークブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされているデータからチャート ワークブックを再構築できます。`LoadOptions` を作成し、`SpreadsheetOptions` を構成し、`ISpreadsheetOptions.RecoverWorkbookFromChartCache` を `true` に設定してからプレゼンテーションを開きます。

以下の C# 例は、利用できない外部ワークブックを参照するチャートを含むプレゼンテーションを開き、[IChart.ChartData](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichart/chartdata/) と [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdata/chartdataworkbook/) を通じて復元されたデータにアクセスする方法を示します:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        RecoverWorkbookFromChartCache = true
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

var chart = (IChart)presentation.Slides[0].Shapes[0];
var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

// ここで復元されたワークブック データを読み取るか、変更します。
```

外部ワークブックが利用できず、復元が無効になっている場合、Aspose.Slides は `InvalidOperationException` をスローします。キャッシュされたチャート データの使用が許容できるフォールバックである場合にのみ復元を有効にしてください。キャッシュには外部ワークブックが最後に更新された後の変更が含まれていない可能性があります。

## **FAQ**

**特定のチャートが外部ワークブックにリンクされているか、埋め込みワークブックにリンクされているかを判断できますか？**

はい。チャートには [データ ソース タイプ](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/chartdata/datasourcetype/) と [外部ワークブックへのパス](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/chartdata/externalworkbookpath/) があり、外部ワークブックの場合はフル パスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされますか？また、どのように保存されますか？**

はい。相対パスを指定すると自動的に絶対パスに変換されます。これはプロジェクトのポータビリティに便利ですが、プレゼンテーションは PPTX ファイル内に絶対パスを保存する点に注意してください。

**ネットワーク リソースや共有フォルダー上のワークブックを使用できますか？**

はい、これらのワークブックは外部データ ソースとして使用できます。ただし、Aspose.Slides からリモートワークブックを直接編集することはサポートされていません。ソースとしてのみ使用可能です。

**プレゼンテーション保存時に外部 XLSX が上書きされますか？**

いいえ。プレゼンテーションは [外部ファイルへのリンク](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/chartdata/externalworkbookpath/) を保存し、データの読み取りに使用します。保存時に外部ファイル自体は変更されません。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策は、事前に保護を解除するか、[Aspose.Cells](/cells/net/) などで復号化したコピーを用意してそのコピーにリンクすることです。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートは独自のリンクを保持します。同じファイルを参照していれば、ファイルを更新するだけで次回データをロードしたときにすべてのチャートに反映されます。