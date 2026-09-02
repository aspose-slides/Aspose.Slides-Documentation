---
title: .NET でプレゼンテーションのチャート ブックブックを管理する
linktitle: チャート ブックブック
type: docs
weight: 70
url: /ja/net/chart-workbook/
keywords:
- チャート ブックブック
- チャート データ
- ブックブック セル
- データ ラベル
- ワークシート
- データ ソース
- 外部ブックブック
- 外部データ
- チャート キャッシュ
- ブックブック 復元
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を発見: PowerPoint および OpenDocument 形式でチャート ブックブックを簡単に管理し、プレゼンテーション データを効率化します。"
---
## **概要**

この記事では、Aspose.Slides でチャート ブックブックを操作する方法を説明します。ブックブック ストリームを通じてチャート データを読み書きする方法、ブックブック セルをチャート データ ラベルとして使用する方法、ワークシート コレクションにアクセスする方法、チャート 値のデータ ソース タイプを指定する方法を示します。

また、外部ブックブックをチャート データ ソースとして使用する方法も取り上げます。例では、外部ブックブックを作成して割り当てる方法、チャートにリンクされた外部ブックブックのパスを取得する方法、ブックブックが利用可能な場合にチャート データを編集する方法を示しています。

## **ブックブックからチャート データを読み書きする**
Aspose.Slides は、[ReadWorkbookStream](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdata/readworkbookstream/) と [WriteWorkbookStream](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdata/writeworkbookstream/) メソッドを提供し、ブックブック（Aspose.Cells で編集されたチャート データを含む）を読み書きできます。**注**: チャート データは同じ形式で構成されているか、元の構造に類似している必要があります。

この C# コードはサンプル操作を示しています：

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

### **ブックブック変更後のチャート レイアウトの検証**
埋め込みブックブックを変更済みのものに置き換えると、チャートは元のシリーズおよびカテゴリ コレクションを保持したままになります。この不一致により、[IChart.ValidateChartLayout](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichart/validatechartlayout/) がインデックス範囲外エラーで失敗する可能性があります。更新されたブックブックを書き戻す前に、既存のシリーズとカテゴリをクリアしてください。

```csharp
// ワークブック ストリームを変更した後 (例: Aspose.Cells を使用)
using var updatedWorkbook = chartData.ReadWorkbookStream();

// 既存のデータ参照をクリアします。
chartData.Series.Clear();
chartData.Categories.Clear();

updatedWorkbook.Position = 0;
chartData.WriteWorkbookStream(updatedWorkbook);

chart.ValidateChartLayout();
```

コレクションをクリアすることで、チャート データ構造が新しいブックブックと一致し、`ValidateChartLayout` がエラーなく完了します。

## **ブックブック セルをチャート データ ラベルとして設定**
1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドの参照を取得します。  
1. データ付きのバブル チャートを追加します。  
1. チャート シリーズにアクセスします。  
1. ブックブック セルをデータ ラベルとして設定します。  
1. プレゼンテーションを保存します。  

この C# コードはブックブック セルをチャート データ ラベルとして設定する方法を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成

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
この C# コードは、[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) プロパティを使用してワークシート コレクションにアクセスする操作を示しています：

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

## **データ ソースの種類を指定**
この C# コードはデータ ソースのタイプを指定する方法を示しています：

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

## **サポートされていない埋め込みブックブック形式の検出**
Aspose.Slides は、いくつかのチャートに埋め込むことができる Excel バイナリ ブックブック（.xlsb）形式をサポートしていません。[IChartData](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdata/) の `EmbeddedWorkbookType` プロパティと [WorkbookType](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/workbooktype/) 列挙体を組み合わせて、サポート外の形式を検出し、該当チャートをスキップできます。

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
            // 埋め込みブックブックは .xlsb 形式で、サポートされていません。
            continue;
        }

        // ここでチャート ブックブック データを読み取るか変更します。
    }
}
```

## **外部ブックブック**

{{% alert color="info" %}} 
[Aspose.Slides 19.4](https://docs.aspose.com/slides/ja/net/aspose-slides-for-net-19-4-release-notes/) では、チャートのデータ ソースとして外部ブックブックをサポートしました。
{{% /alert %}} 

### **外部ブックブックを作成**
**`ReadWorkbookStream`** と **`SetExternalWorkbook`** メソッドを使用して、外部ブックブックをゼロから作成するか、内部ブックブックを外部化できます。

この C# コードは外部ブックブックの作成プロセスを示しています：

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

### **外部ブックブックを設定**
**`SetExternalWorkbook`** メソッドを使用して、外部ブックブックをチャートのデータ ソースとして割り当てます。このメソッドは、外部ブックブックのパスが変更された場合（移動された場合）にも更新に使用できます。

リモート場所やリソースに保存されているブックブックのデータを編集することはできませんが、外部データ ソースとして使用することは可能です。外部ブックブックの相対パスが指定されると、自動的にフルパスに変換されます。

この C# コードは外部ブックブックの設定方法を示しています：

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

`SetExternalWorkbook` メソッドの `ChartData` パラメータは、Excel ブックブックをロードするかどうかを指定します。

* `ChartData` が `false` に設定されている場合、パスだけが更新され、チャート データは対象ブックブックからロードまたは更新されません。対象ブックブックが存在しない、または利用できない状況でこの設定を使用できます。  
* `ChartData` が `true` に設定されている場合、チャート データが対象ブックブックから更新されます。

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

### **チャートの外部データ ソース ブックブック パスを取得**

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドの参照を取得します。  
1. チャート シェイプのオブジェクトを作成します。  
1. チャートのデータ ソースを表す `ChartDataSourceType` オブジェクトを作成します。  
1. ソース タイプが外部ブックブック データ ソース タイプと同じであることに基づき、該当条件を指定します。  

この C# コードは操作を示しています：

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

### **チャート データを編集**
外部ブックブックのデータは、内部ブックブックの内容を変更するのと同様に編集できます。外部ブックブックがロードできない場合は例外がスローされます。

この C# コードは上記プロセスの実装例です：

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

### **チャート キャッシュからブックブックを復元**
チャートが存在しない、または利用できない外部ブックブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされたデータからブックブックを再構築できます。[LoadOptions](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/) を作成し、その [SpreadsheetOptions](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/spreadsheetoptions/) を構成し、`ISpreadsheetOptions.RecoverWorkbookFromChartCache` を `true` に設定してからプレゼンテーションを開きます。

以下の C# 例は、利用できない外部ブックブックを参照するチャートを含むプレゼンテーションを開き、[IChart.ChartData](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichart/chartdata/) と [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdata/chartdataworkbook/) を通じて復元されたデータにアクセスします：

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

// Read or modify the recovered workbook data here.
```

外部ブックブックが利用できず回復が無効になっている場合、Aspose.Slides は `InvalidOperationException` をスローします。キャッシュされたチャート データの使用が許容できるフォールバックである場合のみ回復を有効にしてください。キャッシュには、プレゼンテーションが最後に更新された後に外部ブックブックで行われた変更が含まれていない可能性があります。

## **FAQ**

**特定のチャートが外部ブックブックにリンクされているか、埋め込みブックブックにリンクされているかを判断できますか？**

はい。チャートには [data source type](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/chartdata/datasourcetype/) と [path to an external workbook](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/chartdata/externalworkbookpath/) があり、外部ブックブックであればフルパスを読み取って外部ファイルが使用されていることを確認できます。

**外部ブックブックへの相対パスはサポートされており、どのように保存されますか？**

はい。相対パスを指定すると自動的に絶対パスに変換されます。これはプロジェクトの移植性に便利ですが、PPTX ファイルには絶対パスが保存される点に注意してください。

**ネットワーク共有上のブックブックを使用できますか？**

はい、そのようなブックブックは外部データ ソースとして使用できます。ただし、Aspose.Slides からリモートブックブックを直接編集することはサポートされていません。ソースとしてのみ使用可能です。

**プレゼンテーション保存時に外部 XLSX が上書きされますか？**

いいえ。プレゼンテーションは [外部ファイルへのリンク](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/chartdata/externalworkbookpath/) を保存し、データ読み取りに使用します。保存時に外部ファイル自体は変更されません。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策は、事前に保護を解除するか、復号化コピー（例: [Aspose.Cells](/cells/net/) を使用）を作成してそれにリンクすることです。

**複数のチャートが同じ外部ブックブックを参照できますか？**

はい。各チャートは独自のリンクを保持します。すべてが同じファイルを指していれば、そのファイルを更新するだけで次回データがロードされる際にすべてのチャートに反映されます。