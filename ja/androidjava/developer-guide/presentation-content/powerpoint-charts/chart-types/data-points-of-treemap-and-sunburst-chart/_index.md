---
title: ツリーマップとサンバーストチャートのデータポイント
type: docs
url: /ja/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords: "Aspose.Slides for Android via Javaのサンバーストグラフ"
description: "Aspose.Slides for Android via Javaを使用したサンバーストグラフ、サンバーストダイアグラム、サンバーストチャート、放射状チャート、放射状グラフ、またはマルチレベル円グラフ。"
---

PowerPointチャートの他のタイプの中で、**ツリーマップ**および**サンバースト**チャート（サンバーストグラフ、サンバーストダイアグラム、放射状チャート、放射状グラフまたはマルチレベル円グラフとしても知られています）の2つの「階層型」タイプがあります。これらのチャートは、葉から枝の頂点までのツリーとして構成された階層データを表示します。葉はシリーズデータポイントによって定義され、次のネストされたグループレベルは対応するカテゴリによって定義されます。Aspose.Slides for Android via Javaでは、Javaでサンバーストチャートとツリーマップのデータポイントをフォーマットできます。

以下はサンバーストチャートで、Series1列のデータが葉ノードを定義し、他の列が階層データポイントを定義しています：

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

プレゼンテーションに新しいサンバーストチャートを追加することから始めましょう：

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="こちらもご覧ください" %}} 
- [**サンバーストチャートの作成**](/slides/ja/androidjava/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

チャートのデータポイントをフォーマットする必要がある場合、次のものを使用します：

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevelsManager)、 
[IChartDataPointLevel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel)クラス 
および [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPoint#getDataPointLevels--)メソッド 
は、ツリーマップとサンバーストチャートのデータポイントをフォーマットするためのアクセスを提供します。 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevelsManager)
はマルチレベルのカテゴリにアクセスするために使用され、 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel)オブジェクトのコンテナを表します。
基本的には、データポイント専用に追加されたプロパティを持つ 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartCategoryLevelsManager)のラッパーです。 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel)クラスには
2つのメソッドがあります：[**getFormat**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel#getFormat--)と 
[**getDataLabel**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel#getLabel--)で、これらは
対応する設定にアクセスするためのものです。
## **データポイントの値を表示**
「Leaf 4」データポイントの値を表示します：

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **データポイントのラベルと色を設定**
「Branch 1」データラベルをカテゴリ名の代わりにシリーズ名（「Series1」）を表示するように設定します。その後、テキストの色を黄色に設定します：

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **データポイントのブランチ色を設定**
「Steam 4」ブランチの色を変更します：

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();

    IChartDataPointLevel stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);

    stem4branch.getFormat().getFill().setFillType(FillType.Solid);
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)