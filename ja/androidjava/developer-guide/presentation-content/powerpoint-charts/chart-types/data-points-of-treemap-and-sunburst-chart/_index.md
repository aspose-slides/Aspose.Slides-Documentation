---
title: Android で Treemap と Sunburst チャートのデータポイントをカスタマイズ
linktitle: Treemap と Sunburst チャートのデータポイント
type: docs
url: /ja/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- Treemap チャート
- Sunburst チャート
- データポイント
- ラベルカラー
- ブランチカラー
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint 形式に対応した Treemap および Sunburst チャートのデータポイントの管理方法を学びます。"
---

PowerPoint の他の種類のチャートの中で、階層型の 2 つのタイプがあります - **Treemap** と **Sunburst** チャート（Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph、または Multi Level Pie Chart とも呼ばれます）。これらのチャートは、葉から枝の先端までツリー構造として整理された階層データを表示します。葉はシリーズのデータポイントで定義され、各後続の入れ子になったグループ化レベルは対応するカテゴリで定義されます。Aspose.Slides for Android via Java は、Java で Sunburst Chart と Treemap のデータポイントをフォーマットすることを可能にします。

以下は Sunburst Chart です。Series1 列のデータが葉ノードを定義し、他の列が階層データポイントを定義します：

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

プレゼンテーションに新しい Sunburst チャートを追加することから始めましょう：
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // 省略
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" title="参照" %}} 
- [**Sunburst チャートの作成**](/slides/ja/androidjava/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

チャートのデータポイントをフォーマットする必要がある場合は、次のものを使用します：

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevelsManager),
[IChartDataPointLevel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel) クラス
および [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPoint#getDataPointLevels--) メソッドは、Treemap と Sunburst チャートのデータポイントをフォーマットするためのアクセス手段を提供します。
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevelsManager) は、マルチレベルカテゴリへアクセスするために使用され、[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartCategoryLevelsManager) オブジェクトのコンテナを表します。基本的にこれはデータポイント固有のプロパティが追加された [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartCategoryLevelsManager) のラッパーです。
[**IChartDataPointLevel**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel) クラスには、対応する設定にアクセスできる 2 つのメソッド、[**getFormat**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel#getFormat--) と [**getDataLabel**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel#getLabel--) があります。

## **データポイントの値を表示**

「Leaf 4」データポイントの値を表示します：
```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **データポイントのラベルと色を設定**

「Branch 1」データラベルをカテゴリ名の代わりにシリーズ名（「Series1」）を表示するように設定し、テキスト色を黄色に変更します：
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

## **よくある質問**

**Sunburst/Treemap のセグメントの順序（ソート）を変更できますか？**

できません。PowerPoint はセグメントを自動的に（通常は値の降順、時計回り）ソートします。Aspose.Slides も同様の動作を反映するため、直接順序を変更することはできません。データを前処理して順序を調整してください。

**プレゼンテーションのテーマはセグメントやラベルの色にどのように影響しますか？**

チャートの色はプレゼンテーションの [theme/palette](/slides/ja/androidjava/presentation-theme/) を継承します。明示的に塗りつぶしやフォントを設定しない限り、テーマの影響を受けます。一定の結果を得るには、必要なレベルで実線塗りつぶしとテキスト書式を固定してください。

**PDF/PNG へのエクスポート時にカスタムブランチ色やラベル設定は保持されますか？**

保持されます。プレゼンテーションをエクスポートするとき、チャートの設定（塗りつぶし、ラベル etc.）は出力形式にそのまま適用されます。

**ラベルや要素の実際の座標を取得して、チャート上にカスタムオーバーレイを配置できますか？**

できます。チャートのレイアウトが確定した後、要素（例: [DataLabel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datalabel/)）の実際の *x* と *y* が利用可能になるため、正確な位置合わせが可能です。