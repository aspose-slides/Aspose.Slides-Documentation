---
title: チャート ワークブック
type: docs
weight: 70
url: /net/chart-workbook/
keywords: "チャート ワークブック, チャート データ, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET における PowerPoint プレゼンテーションのチャート ワークブック"
---

## **ワークブックからチャート データを設定する**
Aspose.Slides は、チャート データ ワークブック (Aspose.Cells で編集されたチャート データを含む) を読み書きするための [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) と [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) メソッドを提供します。 **注意**: チャート データは、同じ方法で整理される必要があるか、またはソースと類似の構造を持っている必要があります。

この C# コードは、サンプル操作を示しています：

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


## **ワークブックのセルをチャート データラベルとして設定する**
1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. スライドのインデックスを通じてスライドの参照を取得します。
1. データを使用してバブルチャートを追加します。
1. チャート シリーズにアクセスします。
1. ワークブックのセルをデータ ラベルとして設定します。
1. プレゼンテーションを保存します。

この C# コードは、ワークブックのセルをチャート データ ラベルとして設定する方法を示します：

```c#
string lbl0 = "ラベル 0 セルの値";
string lbl1 = "ラベル 1 セルの値";
string lbl2 = "ラベル 2 セルの値";

// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成 

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

## **ワークシートを管理する**

この C# コードは、[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) プロパティを使用してワークシートコレクションにアクセスする操作を示しています：

``` csharp
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **データソースの種類を指定する**

この C# コードは、データソースの種類を指定する方法を示しています：

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
[Aspose.Slides 19.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-19-4-release-notes/) では、チャートのデータソースとして外部ワークブックのサポートを実装しました。
{{% /alert %}} 

### **外部ワークブックを作成する**
**`ReadWorkbookStream`** および **`SetExternalWorkbook`** メソッドを使用すると、新しい外部ワークブックを作成することも、内部ワークブックを外部にすることもできます。

この C# コードは、外部ワークブックの作成プロセスを示しています：

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


### **外部ワークブックを設定する**
**`SetExternalWorkbook`** メソッドを使用して、チャートに外部ワークブックをそのデータソースとして割り当てることができます。このメソッドは、外部ワークブックのパスを更新するためにも使用できます (外部ワークブックが移動した場合など)。

リモートの場所やリソースに保存されているワークブックのデータを編集することはできませんが、そのようなワークブックを外部データソースとして使用することはできます。外部ワークブックの相対パスが提供されると、自動的にフルパスに変換されます。

この C# コードは、外部ワークブックを設定する方法を示します：

```c#
// ドキュメントディレクトリへのパス
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

`SetExternalWorkbook` メソッドの `ChartData` パラメータは、Excel ワークブックが読み込まれるかどうかを指定するために使用されます。

* `ChartData` の値が `false` に設定されている場合、ワークブックのパスのみが更新され、チャート データはターゲット ワークブックから読み込まれたり更新されたりしません。この設定は、ターゲット ワークブックが存在しないか、利用できない状況で使用することをお勧めします。 
* `ChartData` の値が `true` に設定されている場合、チャート データはターゲット ワークブックから更新されます。

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **チャートの外部データソース ワークブックのパスを取得する**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. スライドのインデックスを通じてスライドの参照を取得します。
1. チャート形状のオブジェクトを作成します。
1. チャートのデータソースを表すタイプ（`ChartDataSourceType`）のオブジェクトを作成します。
1. ソースの種類が外部ワークブックのデータソースの種類と同じである場合に関連する条件を指定します。

この C# コードは、操作を示しています：

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
    
    // プレゼンテーションを保存
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **チャートデータを編集する**

外部ワークブックのデータは、内部ワークブックの内容を変更するのと同じ方法で編集できます。外部ワークブックが読み込めない場合、例外がスローされます。

この C# コードは、説明したプロセスの実装です：

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```