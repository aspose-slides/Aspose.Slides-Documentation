---
title: Java を使用した Treemap と Sunburst チャートのデータ ポイントのカスタマイズ
linktitle: Treemap と Sunburst チャートのデータ ポイント
type: docs
url: /ja/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- ツリーマップ チャート
- サンバースト チャート
- データ ポイント
- ラベル色
- 枝の色
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint 形式に対応した Treemap と Sunburst のチャートのデータ ポイントを管理する方法を学びます。"
---

PowerPoint の他の種類のチャートの中で、**Treemap** と **Sunburst**（Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph、Multi Level Pie Chart とも呼ばれます）の 2 つの「階層」タイプがあります。これらのチャートは、葉から枝のトップまでツリー構造で階層データを表示します。葉は系列のデータ ポイントで定義され、各次のネストされたグループ化レベルは対応するカテゴリで定義されます。Aspose.Slides for Java を使用すると、Java で Sunburst Chart と Treemap のデータ ポイントをフォーマットできます。

以下は Sunburst Chart の例です。Series1 列のデータが葉ノードを定義し、他の列が階層データ ポイントを定義します：

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

プレゼンテーションに新しい Sunburst チャートを追加しましょう：
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // （省略）
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" title="参照" %}} 
- [**Sunburst チャートの作成**](/slides/ja/java/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

チャートのデータ ポイントをフォーマットする必要がある場合は、以下を使用します：

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager)、[IChartDataPointLevel](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) クラス と [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPoint#getDataPointLevels--) メソッドが Treemap と Sunburst チャートのデータ ポイントのフォーマットへのアクセスを提供します。  
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager) はマルチレベルカテゴリへのアクセスに使用され、[**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) オブジェクトのコンテナを表します。基本的にはデータ ポイント固有のプロパティが追加された [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartCategoryLevelsManager) のラッパーです。  
[**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) クラスは、[**getFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getFormat--) と [**getDataLabel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getLabel--) の 2 つのメソッドを持ち、対応する設定へのアクセスを提供します。

## **データポイントの値を表示**
"Leaf 4" データ ポイントの値を表示します：
```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **データポイントのラベルと色を設定**
"Branch 1" データ ラベルをカテゴリ名ではなくシリーズ名 ("Series1") を表示するように設定し、テキストの色を黄色に変更します：
```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **データポイントの枝の色を設定**
"Steam 4" 枝の色を変更します：
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

**Sunburst/Treemap のセグメントの順序（並び替え）を変更できますか？**

いいえ。PowerPoint はセグメントを自動的に（通常は降順で時計回りに）並び替えます。Aspose.Slides はこの動作をそのまま再現します。直接順序を変更することはできません。データを事前に加工して順序を調整してください。

**プレゼンテーションのテーマはセグメントやラベルの色にどのように影響しますか？**

チャートの色はプレゼンテーションの [theme/palette](/slides/ja/java/presentation-theme/) を継承します。明示的に塗りつぶしやフォントを設定しない限り、テーマの配色が適用されます。一定の結果を得るには、必要なレベルで塗りつぶしやテキスト書式を固定してください。

**PDF/PNG へのエクスポート時にカスタム枝の色やラベル設定は保持されますか？**

保持されます。プレゼンテーションをエクスポートするとき、チャートの設定（塗りつぶし、ラベル）は出力形式にそのまま保存されます。Aspose.Slides はチャートの書式設定を適用した状態でレンダリングします。

**チャート上にカスタムオーバーレイを配置するために、ラベルや要素の実際の座標を計算できますか？**

できます。チャートのレイアウトが確定した後、要素（例: [DataLabel](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/)）の実際の *x* と *y* が取得可能です。これにより、オーバーレイの正確な位置決めが可能になります。