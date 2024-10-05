---
title: ツリーマップとサンバーストチャートのデータポイント
type: docs
url: /net/data-points-of-treemap-and-sunburst-chart/
keywords: "サンバーストチャート, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#や.NETでPowerPointプレゼンテーションにサンバーストチャートを追加する"
---

他のタイプのPowerPointチャートの中に、2つの「階層型」タイプ - **ツリーマップ**と**サンバースト**チャート（サンバーストグラフ、サンバーストダイアグラム、放射グラフ、放射チャートまたは多層円グラフとも呼ばれます）があります。これらのチャートは、葉から枝の頂点までのツリーとして組織された階層データを表示します。葉はシリーズデータポイントによって定義され、各次の入れ子のグループ化レベルは対応するカテゴリによって定義されます。Aspose.Slides for .NETを使用すると、C#でサンバーストチャートとツリーマップのデータポイントをフォーマットできます。

こちらがサンバーストチャートで、Series1列のデータが葉ノードを定義し、他の列が階層データポイントを定義しています：

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

新しいサンバーストチャートをプレゼンテーションに追加するところから始めましょう：

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```

{{% alert color="primary" title="関連情報" %}} 
- [**サンバーストチャートの作成**](/slides/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

チャートのデータポイントをフォーマットする必要がある場合は、次のものを使用すべきです：

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager)、 
[IChartDataPointLevel](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel)クラス 
および [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels)プロパティ 
は、ツリーマップとサンバーストチャートのデータポイントをフォーマットするためのアクセスを提供します。 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager) 
は、マルチレベルカテゴリにアクセスするために使用されます - それは 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel)オブジェクトのコンテナを表します。 
基本的に、データポイントのために特別に追加されたプロパティを持つ 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartCategoryLevelsManager)のラッパーです。 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel)クラスは 
2つのプロパティを持っています：[**Format**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/format)と 
[**DataLabel** ](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/label)は 
対応する設定にアクセスするためのものです。
## **データポイントの値を表示**
「Leaf 4」データポイントの値を表示します：

```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **データポイントのラベルと色を設定**
「Branch 1」データラベルをカテゴリ名の代わりにシリーズ名（「Series1」）を表示するように設定します。その後、テキストの色を黄色に設定します：

```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **データポイントのブランチの色を設定**

「Stem 4」ブランチの色を変更します：

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
