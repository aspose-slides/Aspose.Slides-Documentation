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
- "PowerPoint"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET を発見し、PowerPoint と OpenDocument 形式のチャート ワークブックを簡単に管理してプレゼンテーション データを効率化しましょう。"
---
## **ワークブックからチャート データを読み書きする**
Aspose.Slides は、[ReadWorkbookStream](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdata/readworkbookstream/) および [WriteWorkbookStream](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdata/writeworkbookstream/) メソッドを提供し、チャート データ ワークブック（Aspose.Cells で編集されたチャート データを含む）を読み書きできます。**注**: チャート データは同じ方法で整理されているか、ソースと同様の構造である必要があります。

この C# コードはサンプル操作を示しています:
```c#
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

## **ワークブック セルをチャート データ ラベルに設定する**
1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. バブルチャートを追加し、データを設定します。
4. チャート シリーズにアクセスします。
5. ワークブック セルをデータ ラベルとして設定します。
6. プレゼンテーションを保存します。

この C# コードは、ワークブック セルをチャート データ ラベルとして設定する方法を示します:
```c#
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
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **データ ソースの種類を指定する**
この C# コードは、データ ソースの型を指定する方法を示します:
```c#
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
Aspose.Slides は、一部のチャートに埋め込むことができる Excel バイナリ ワークブック (.xlsb) 形式をサポートしていません。`IChartData` の `EmbeddedWorkbookType` プロパティと `WorkbookType` 列挙体を組み合わせて、サポートされていない形式を検出し、該当するチャートをスキップできます。
```csharp
using (var presentation = new Presentation("pres.pptx"))
{
    foreach (var shape in presentation.Slides[0].Shapes)
    {
        if (shape is not IChart chart) continue;

        var chartData = chart.ChartData;

        if (chartData.DataSourceType == ChartDataSourceType.InternalWorkbook &&
            chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro)
        {
            // 埋め込みワークブックは .xlsb 形式であり、サポートされていません。
            continue;
        }

        // ここでチャート ワークブック データを読み取るか、変更してください。
    }
}
```

## **External Workbook**
{{% alert color="primary" %}} 
In [Aspose.Slides 19.4](https://docs.aspose.com/slides/ja/net/aspose-slides-for-net-19-4-release-notes/), we implemented support for external workbooks as a data source for charts.
{{% /alert %}} 

### **外部ワークブックの作成**
**`ReadWorkbookStream`** と **`SetExternalWorkbook`** メソッドを使用すると、外部ワークブックをゼロから作成するか、内部ワークブックを外部ワークブックに変換できます。

この C# コードは、外部ワークブックの作成プロセスを示します:
```c#
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
**`SetExternalWorkbook`** メソッドを使用すると、外部ワークブックをチャートのデータ ソースとして割り当てることができます。このメソッドは、外部ワークブックのパスが変更された場合（移動された場合）にパスを更新するためにも使用できます。

リモート ロケーションやリソースに保存されたワークブックのデータを編集することはできませんが、外部データ ソースとして使用することは可能です。外部ワークブックの相対パスが指定された場合、自動的にフル パスに変換されます。

この C# コードは、外部ワークブックを設定する方法を示します:
```c#
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

`SetExternalWorkbook` メソッドの `ChartData` パラメーターは、Excel ワークブックをロードするかどうかを指定するために使用されます。

* `ChartData` の値が `false` に設定されている場合、ワークブック パスのみが更新され、チャート データは対象ワークブックからロードまたは更新されません。対象ワークブックが存在しない、または利用できない状況でこの設定を使用することがあります。
* `ChartData` の値が `true` に設定されている場合、チャート データは対象ワークブックから更新されます。

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **チャートの外部データ ソース ワークブック パスを取得する**
1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. チャート シェイプのオブジェクトを作成します。
4. チャートのデータ ソースを表すソース (`ChartDataSourceType`) 型のオブジェクトを作成します。
5. ソース タイプが外部ワークブック データ ソース タイプと同じであることに基づく条件を指定します。

この C# コードは、操作を示します:
```c#
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
外部ワークブックのデータは、内部ワークブックの内容を変更するのと同じ方法で編集できます。外部ワークブックのロードに失敗した場合、例外がスローされます。

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**
**特定のチャートが外部ワークブックにリンクされているか、埋め込みワークブックかを判断できますか？**

はい。チャートには[data source type](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/chartdata/datasourcetype/) と[path to an external workbook](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/chartdata/externalworkbookpath/) があり、ソースが外部ワークブックの場合はフル パスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされていますか？また、どのように保存されますか？**

はい。相対パスを指定すると自動的に絶対パスに変換されます。これはプロジェクトの移植性に便利ですが、プレゼンテーションは PPTX ファイル内に絶対パスを保存します。

**ネットワーク リソース/共有上のワークブックを使用できますか？**

はい、そのようなワークブックは外部データ ソースとして使用できます。ただし、Aspose.Slides からリモート ワークブックを直接編集することはサポートされていません。ソースとしてのみ使用可能です。

**プレゼンテーションを保存するとき、Aspose.Slides は外部 XLSX を上書きしますか？**

いいえ。プレゼンテーションは[link to the external file](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/chartdata/externalworkbookpath/)へのリンクを保存し、データの読み取りに使用します。保存時に外部ファイル自体は変更されません。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策は、事前に保護を解除するか、復号化されたコピー（例: [Aspose.Cells](/cells/net/) を使用）を用意してそのコピーにリンクすることです。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートは独自のリンクを保持します。すべて同じファイルを指す場合、そのファイルを更新すると次回データがロードされる際に各チャートに反映されます。