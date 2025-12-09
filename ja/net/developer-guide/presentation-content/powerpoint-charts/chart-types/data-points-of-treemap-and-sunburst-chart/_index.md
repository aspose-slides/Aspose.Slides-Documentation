---
title: Treemap と Sunburst チャートにおけるデータポイントのカスタマイズ (.NET)
linktitle: Treemap と Sunburst チャートのデータポイント
type: docs
url: /ja/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- ツリーマップチャート
- サンバーストチャート
- データポイント
- ラベルの色
- 枝の色
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint フォーマットに対応した Treemap と Sunburst チャートのデータポイントの管理方法を学びます。"
---

PowerPoint の他の種類のチャートに加えて、階層型の 2 つのタイプがあります - **Treemap** と **Sunburst** チャート（Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph、または Multi Level Pie Chart とも呼ばれます）。これらのチャートは、葉から枝の先端までツリーとして階層データを表示します。葉は系列のデータポイントで定義され、各次の入れ子になったグループレベルは対応するカテゴリで定義されます。Aspose.Slides for .NET を使用すると、C# で Sunburst Chart と Treemap のデータポイントをフォーマットできます。

以下は Sunburst Chart の例です。Series1 列のデータが葉ノードを定義し、他の列が階層データポイントを定義します：
![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

プレゼンテーションに新しい Sunburst チャートを追加することから始めましょう：
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```


{{% alert color="primary" title="参照" %}} 
- [**Sunburstチャートの作成**](/slides/ja/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

チャートのデータポイントをフォーマットする必要がある場合は、以下を使用します：
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager)、[**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel) クラス、そして [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) プロパティは、Treemap と Sunburst チャートのデータポイントをフォーマットするためのアクセスを提供します。  
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager) は、マルチレベルカテゴリへのアクセスに使用され、[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartCategoryLevelsManager) オブジェクトのコンテナを表します。データポイント固有のプロパティが追加されています。  
[**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) クラスは、[**Format**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/format) と [**DataLabel**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/label) の 2 つのプロパティを持ち、対応する設定へのアクセスを提供します。

## **データポイントの値を表示**
「Leaf 4」データポイントの値を表示します：
```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **データポイントのラベルと色を設定**
「Branch 1」データラベルをカテゴリ名ではなく系列名（「Series1」）が表示されるように設定します。その後、テキストの色を黄色に設定します：
```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **データポイントのブランチ色を設定**
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

## **よくある質問**

**Sunburst/Treemap のセグメントの順序（ソート）を変更できますか？**  
いいえ。PowerPoint はセグメントを自動的に並べ替えます（通常は降順で時計回り）。Aspose.Slides はこの動作をそのまま再現します：直接順序を変更することはできず、データを事前に処理することで実現します。

**プレゼンテーションのテーマはセグメントやラベルの色にどのように影響しますか？**  
チャートの色は、明示的に塗りつぶしやフォントを設定しない限り、プレゼンテーションの[テーマ/パレット](/slides/ja/net/presentation-theme/)を継承します。一貫した結果を得るには、必要なレベルで実体塗りつぶしとテキスト書式設定を固定してください。

**PDF/PNG へのエクスポートはカスタムブランチの色やラベル設定を保持しますか？**  
はい。プレゼンテーションをエクスポートする際、チャートの設定（塗りつぶし、ラベル）は出力形式で保持されます。これは Aspose.Slides がチャートの書式設定を適用した状態でレンダリングするためです。

**ラベルや要素の実際の座標を計算して、チャート上にカスタムオーバーレイを配置できますか？**  
はい。チャートのレイアウトが検証された後、要素（例: [DataLabel](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabel/)）に対して `ActualX`/`ActualY` が利用可能となり、オーバーレイの正確な位置決めに役立ちます。