---
title: Treemap と Sunburst チャートのデータポイントを .NET でカスタマイズする
linktitle: Treemap と Sunburst チャートのデータポイント
type: docs
url: /ja/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- Treemap チャート
- Sunburst チャート
- データポイント
- ラベル色
- ブランチ色
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint 形式に対応した Treemap と Sunburst チャートのデータポイントの管理方法を学びましょう。"
---

PowerPoint の他のチャートタイプの中で、階層型のチャートが 2 つあります – **Treemap** と **Sunburst** チャート（Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph、Multi Level Pie Chart とも呼ばれます）。これらのチャートは、葉から枝の先端へとツリー構造で階層データを表示します。葉はシリーズのデータポイントで定義され、以降の各ネストされたグループレベルは対応するカテゴリで定義されます。Aspose.Slides for .NET を使用すると、C# で Sunburst Chart と Treemap のデータポイントの書式設定が可能です。

以下は Sunburst Chart で、Series1 列のデータが葉ノードを定義し、他の列が階層データポイントを定義します：

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

プレゼンテーションに新しい Sunburst チャートを追加するところから始めましょう：
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```


{{% alert color="primary" title="See also" %}} 
- [**Sunburst チャートの作成**](/slides/ja/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

チャートのデータポイントの書式設定が必要な場合は、次のものを使用します：

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager)、[IChartDataPointLevel](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel) クラスと[**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) プロパティは、Treemap および Sunburst チャートのデータポイントの書式設定へのアクセスを提供します。  
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager) はマルチレベルカテゴリにアクセスするために使用され、[**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) オブジェクトのコンテナを表します。基本的には、データポイント固有のプロパティが追加された[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartCategoryLevelsManager) のラッパーです。  
[**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) クラスは、[**Format**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/format) と[**DataLabel**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/label) の 2 つのプロパティを持ち、対応する設定へのアクセスを提供します。

## **データポイントの値を表示**
「Leaf 4」データポイントの値を表示します：
```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **データポイントのラベルと色を設定**
「Branch 1」データラベルをカテゴリ名の代わりにシリーズ名（「Series1」）を表示するように設定し、テキスト色を黄色にします：
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

## **FAQ**

**Sunburst/Treemap のセグメントの順序（ソート）を変更できますか？**

いいえ。PowerPoint はセグメントを自動的に（通常は降順で時計回りに）ソートします。Aspose.Slides も同様の動作を再現しており、直接順序を変更することはできません。データを事前に加工して順序を調整してください。

**プレゼンテーションのテーマはセグメントやラベルの色にどのように影響しますか？**

チャートの色は、明示的に塗りやフォントを設定しない限り、プレゼンテーションの[テーマ/パレット](/slides/ja/net/presentation-theme/) を継承します。一定の結果が必要な場合は、必要なレベルで実線の塗りとテキスト書式を固定してください。

**PDF/PNG へエクスポートすると、カスタムブランチ色やラベル設定は保持されますか？**

はい。プレゼンテーションをエクスポートする際、チャートの設定（塗り、ラベル）は出力形式に保持されます。Aspose.Slides はチャートの書式設定を適用した状態でレンダリングします。

**ラベルや要素の実際の座標を取得して、チャート上にカスタムオーバーレイを配置できますか？**

はい。チャートのレイアウトが確定した後、要素（例: [DataLabel](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabel/)）に対して `ActualX` / `ActualY` が利用可能です。これにより、オーバーレイの正確な位置決めが可能になります。