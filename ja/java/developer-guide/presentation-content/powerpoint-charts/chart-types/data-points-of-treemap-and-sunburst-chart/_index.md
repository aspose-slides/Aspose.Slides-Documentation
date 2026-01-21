---
title: Java を使用した Treemap および Sunburst チャートのデータ ポイントのカスタマイズ
linktitle: Treemap および Sunburst チャートのデータ ポイント
type: docs
url: /ja/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- ツリーマップ チャート
- サンバースト チャート
- データ ポイント
- ラベル色
- ブランチ色
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint 形式に対応した Treemap および Sunburst チャートのデータ ポイントを管理する方法を学びます。"
---

PowerPoint の他のチャート タイプの中で、2 つの「階層」タイプがあります — **Treemap** と **Sunburst** チャート（Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph、Multi Level Pie Chart とも呼ばれます）。これらのチャートは、ツリー構造として整理された階層データを表示します — 葉から枝の先端まで。葉はシリーズのデータ ポイントで定義され、以降の各ネストされたグループ化レベルは対応するカテゴリで定義されます。Aspose.Slides for Java は、Java で Sunburst Chart と Treemap のデータ ポイントの書式設定を可能にします。

以下は Sunburst Chart で、Series1 列のデータが葉ノードを定義し、他の列が階層データ ポイントを定義します:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

プレゼンテーションに新しい Sunburst チャートを追加しましょう:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // 省略
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" title="参考" %}} 
- [**Java で PowerPoint プレゼンテーションのチャートを作成または更新**](/slides/ja/java/create-chart/)
{{% /alert %}}

チャートのデータ ポイントを書式設定する必要がある場合は、次のものを使用します:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager)、 
[IChartDataPointLevel](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) クラス 
および [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPoint#getDataPointLevels--) メソッドは、Treemap と Sunburst チャートのデータ ポイントの書式設定へのアクセスを提供します。 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager) は、マルチレベル カテゴリへのアクセスに使用され、[**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) オブジェクトのコンテナを表します。 
基本的にこれは、データ ポイント固有のプロパティが追加された [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartCategoryLevelsManager) のラッパーです。 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) クラスには、[**getFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getFormat--) と [**getDataLabel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getLabel--) の 2 つのメソッドがあり、対応する設定へのアクセスを提供します。

## **データ ポイントの値を表示**
"Leaf 4" データ ポイントの値を表示します:
```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **データ ポイントのラベルと色を設定**
"Branch 1" のデータ ラベルをカテゴリ名ではなくシリーズ名 ("Series1") を表示するように設定し、テキストの色を黄色に設定します:
```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **データ ポイントのブランチ色を設定**
"Steam 4" ブランチの色を変更します:
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

## **FAQ**

**Sunburst/Treemap のセグメントの順序（ソート）を変更できますか？**

いいえ。PowerPoint はセグメントを自動的に並べ替えます（通常は降順で時計回り）。Aspose.Slides はこの動作を反映します。直接順序を変更することはできず、データを事前に処理することで実現します。

**プレゼンテーションのテーマはセグメントとラベルの色にどのように影響しますか？**

チャートの色は、明示的に塗りつぶしやフォントを設定しない限り、プレゼンテーションの[テーマ/パレット](/slides/ja/java/presentation-theme/)を継承します。一定の結果を得るには、必要なレベルで実体の塗りつぶしとテキスト書式を設定してください。

**PDF/PNG へのエクスポートはカスタムのブランチ色とラベル設定を保持しますか？**

はい。プレゼンテーションをエクスポートすると、チャート設定（塗りつぶし、ラベル）は出力フォーマットに保持されます。Aspose.Slides はチャートの書式設定を適用した状態でレンダリングします。

**チャート上にカスタムオーバーレイを配置するために、ラベル/要素の実際の座標を計算できますか？**

はい。チャートのレイアウトが確定した後、要素（例: [DataLabel](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/)）の実際の *x* と *y* が取得でき、オーバーレイの正確な位置決めに利用できます。