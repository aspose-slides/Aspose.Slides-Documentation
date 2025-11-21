---
title: Treemap とサンバーストチャートのデータポイント
type: docs
url: /ja/net/data-points-of-treemap-and-sunburst-chart/
keywords: "サンバーストチャート, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーションにサンバーストチャートを追加する"
---

他の種類の PowerPoint グラフのうち、階層構造を持つものが 2 種類あります―― **Treemap** と **Sunburst** グラフ（Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph、Multi Level Pie Chart とも呼ばれます）。これらのグラフは、葉から枝の上部へとツリー構造で編成された階層データを表示します。葉は系列のデータ ポイントで定義され、各ネストされたグループ化レベルは対応するカテゴリで定義されます。Aspose.Slides for .NET を使用すると、C# で Sunburst グラフと Treemap のデータ ポイントをフォーマットできます。

以下は Sunburst グラフの例です。Series1 列のデータが葉ノードを定義し、他の列が階層データ ポイントを定義します。

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

プレゼンテーションに新しい Sunburst グラフを追加しましょう:
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```


{{% alert color="primary" title="See also" %}} 
- [**Creating Sunburst Chart**](/slides/ja/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

グラフのデータ ポイントをフォーマットする必要がある場合は、以下を使用します。

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager)、[IChartDataPointLevel](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel) クラスと [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) プロパティは、Treemap と Sunburst グラフのデータ ポイントのフォーマットへのアクセスを提供します。  
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager) は、マルチレベルカテゴリへのアクセスに使用され、[**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) オブジェクトのコンテナを表します。基本的には、データ ポイント用に特化したプロパティが追加された [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartCategoryLevelsManager) のラッパーです。  
[**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) クラスには、[**Format**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/format) と [**DataLabel**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/label) の 2 つのプロパティがあり、対応する設定にアクセスできます。

## **Show Data Point Value**
"Leaf 4" データ ポイントの値を表示します:
```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Set Data Point Label and Color**
"Branch 1" のデータ ラベルをカテゴリ名ではなく系列名 ("Series1") に変更し、テキストの色を黄色に設定します:
```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Set Data Point Branch Color**
"Stem 4" ブランチの色を変更します:
```csharp
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    
    IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

    IChartDataPointLevel stem4branch = dataPoints[9].DataPointLevels[1];
    
    stem4branch.Format.Fill.FillType = FillType.Solid;
    stem4branch.Format.Fill.SolidFillColor.Color = Color.Red;
      
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Can I change the order (sorting) of segments in Sunburst/Treemap?**  
いいえ。PowerPoint はセグメントを自動的に（通常は値の降順、時計回り）ソートします。Aspose.Slides も同様の動作を再現しており、直接順序を変更することはできません。データを事前に加工して実現してください。

**How does the presentation theme affect the colors of segments and labels?**  
グラフの色はプレゼンテーションの [theme/palette](/slides/ja/net/presentation-theme/) を継承します。明示的に塗りつぶしやフォントを設定しない限り、テーマの影響を受けます。確実な結果を得るには、必要なレベルで実線の塗りつぶしとテキスト書式をロックしてください。

**Will export to PDF/PNG preserve custom branch colors and label settings?**  
はい。プレゼンテーションをエクスポートすると、グラフ設定（塗りつぶし、ラベルなど）は出力形式に保持されます。Aspose.Slides はフォーマットが適用された状態でレンダリングします。

**Can I compute the actual coordinates of a label/element for custom overlay placement on top of the chart?**  
はい。グラフのレイアウトが確定した後、要素には `ActualX`/`ActualY` が利用可能です（例: [DataLabel](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabel/)）。これにより、オーバーレイの正確な位置決めが可能になります。