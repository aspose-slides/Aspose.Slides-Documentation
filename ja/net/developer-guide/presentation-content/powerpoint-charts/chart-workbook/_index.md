---
title: チャート ワークブック
type: docs
weight: 70
url: /ja/net/chart-workbook/
keywords: "チャート ワークブック, チャート データ, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET の PowerPoint プレゼンテーションにおけるチャート ワークブック"
---

## **ワークブックからチャート データを設定**
Aspose.Slides は、[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) と [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) メソッドを提供し、チャート データ ワークブック (Aspose.Cells で編集されたチャート データを含む) の読み取りと書き込みが可能です。**注**：チャート データは同じ方法で構成されているか、ソースと同様の構造である必要があります。

この C# コードはサンプル操作を示します:
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


## **ワークブック セルをチャート データ ラベルとして設定**
1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. バブル チャートをいくつかのデータと共に追加します。
4. チャート シリーズにアクセスします。
5. ワークブック セルをデータ ラベルとして設定します。
6. プレゼンテーションを保存します。

この C# コードはワークブック セルをチャート データ ラベルとして設定する方法を示します:
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
この C# コードは、[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) プロパティを使用してワークシート コレクションにアクセスする操作を示します:
``` csharp
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


## **外部ワークブック**
{{% alert color="primary" %}} 
Aspose.Slides 19.4 で、チャートのデータ ソースとして外部ワークブックのサポートを実装しました。
{{% /alert %}} 

### **外部ワークブックの作成**
**`ReadWorkbookStream`** と **`SetExternalWorkbook`** メソッドを使用すると、外部ワークブックをゼロから作成するか、内部ワークブックを外部化できます。

この C# コードは外部ワークブックの作成プロセスを示します:
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
**`SetExternalWorkbook`** メソッドを使用すると、外部ワークブックをチャートのデータ ソースとして割り当てられます。このメソッドは、外部ワークブックのパスが変更された場合にパスを更新するためにも使用できます。

リモート場所やリソースに保存されたワークブックのデータを編集することはできませんが、外部データ ソースとして使用できます。外部ワークブックの相対パスが指定されると、自動的にフルパスに変換されます。

この C# コードは外部ワークブックの設定方法を示します:
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


`SetExternalWorkbook` メソッドの下にある `ChartData` パラメータは、Excel ワークブックを読み込むかどうかを指定するために使用されます。

* `ChartData` の値が `false` に設定されている場合、ワークブック パスのみが更新され、チャート データは対象ワークブックから読み込まれず、更新もされません。対象ワークブックが存在しないか利用できない場合にこの設定を使用することがあります。
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


### **チャートの外部データ ソース ワークブック パスの取得**
1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. チャート シェイプのオブジェクトを作成します。
4. チャートのデータ ソースを表す `ChartDataSourceType` 型のオブジェクトを作成します。
5. ソース タイプが外部ワークブック データ ソース タイプと同じであることに基づき、関連条件を指定します。

この C# コードは操作を示します:
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
外部ワークブックのデータは、内部ワークブックの内容を変更するのと同じ方法で編集できます。外部ワークブックを読み込めない場合は例外がスローされます。

この C# コードは記述されたプロセスの実装例です:
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

**特定のチャートが外部ワークブックにリンクされているか、埋め込みワークブックにリンクされているかを判断できますか？**

はい。チャートには[data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) と [path to an external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) があり、ソースが外部ワークブックの場合はフルパスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされており、どのように保存されますか？**

はい。相対パスを指定すると自動的に絶対パスに変換されます。プロジェクトのポータビリティに便利ですが、プレゼンテーションは PPTX ファイルに絶対パスを保存する点に留意してください。

**ネットワーク リソース/共有上のワークブックを使用できますか？**

はい、そのようなワークブックは外部データ ソースとして使用できます。ただし、Aspose.Slides からリモートワークブックを直接編集することはサポートされていません。データ ソースとしてのみ使用可能です。

**プレゼンテーションを保存するときに Aspose.Slides は外部 XLSX を上書きしますか？**

いいえ。プレゼンテーションは[外部ファイルへのリンク](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) を保存し、データの読み取りに使用します。保存時に外部ファイル自体は変更されません。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策として、事前に保護を解除するか、[Aspose.Cells](/cells/net/) などで復号化されたコピーを用意してそのコピーにリンクします。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートは独自のリンクを保持します。すべてが同じファイルを指している場合、そのファイルを更新すると次回データがロードされるときに各チャートに反映されます。