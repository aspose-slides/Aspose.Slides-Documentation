---
title: Android の Treemap および Sunburst チャートでデータポイントをカスタマイズ
linktitle: Treemap と Sunburst チャートのデータポイント
type: docs
url: /ja/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- Treemap チャート
- Sunburst チャート
- データポイント
- ラベル色
- ブランチ色
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint 形式に対応した Treemap および Sunburst チャートのデータポイントの管理方法を学びます。"
---

PowerPoint の他のチャートタイプの中で、階層型のタイプが2つあります – **Treemap** と **Sunburst** チャート（Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph、Multi Level Pie Chart とも呼ばれます）。これらのチャートは、葉から枝の先までツリー構造で整理された階層データを表示します。葉は系列のデータポイントで定義され、各次のネストされたグループレベルは対応するカテゴリで定義されます。Aspose.Slides for Android via Java は、Java で Sunburst Chart と Treemap のデータポイントの書式設定を可能にします。

以下は Sunburst Chart の例です。Series1 列のデータが葉ノードを定義し、他の列が階層データポイントを定義します：

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

プレゼンテーションに新しい Sunburst チャートを追加することから始めましょう：
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" title="関連項目" %}} 
- [**Android 用 PowerPoint プレゼンテーション チャートの作成または更新**](/slides/ja/androidjava/create-chart/)
{{% /alert %}}

チャートのデータポイントをフォーマットする必要がある場合は、以下を使用する必要があります：

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevelsManager)、[IChartDataPointLevel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel) クラス、および [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPoint#getDataPointLevels--) メソッドは、Treemap と Sunburst チャートのデータポイントの書式設定へのアクセスを提供します。

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevelsManager) はマルチレベルカテゴリへのアクセスに使用され、[**IChartDataPointLevel**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel) オブジェクトのコンテナを表します。基本的にこれは、データポイント固有のプロパティが追加された [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartCategoryLevelsManager) のラッパーです。[**IChartDataPointLevel**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel) クラスには、[**getFormat**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel#getFormat--) と [**getDataLabel**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel#getLabel--) の2つのメソッドがあり、対応する設定へのアクセスを提供します。

## **データポイントの値を表示**

「Leaf 4」データポイントの値を表示します：
```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **データポイントのラベルとカラーを設定**

「Branch 1」データラベルをカテゴリ名ではなく系列名（「Series1」）に設定します。その後、テキストカラーを黄色に設定します：
```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **データポイントのブランチカラーを設定**

「Steam 4」ブランチのカラーを変更します：
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

いいえ。PowerPoint はセグメントを自動的にソートします（通常は降順で時計回り）。Aspose.Slides もこの動作をそのまま反映します。順序を直接変更することはできず、データを事前処理することで実現します。

**プレゼンテーションのテーマはセグメントやラベルの色にどのように影響しますか？**

チャートの色は、明示的に塗りつぶしやフォントを設定しない限り、プレゼンテーションの[テーマ/パレット](/slides/ja/androidjava/presentation-theme/)を継承します。一貫した結果を得るためには、必要なレベルで実線の塗りつぶしとテキスト書式を固定してください。

**PDF/PNG へのエクスポートはカスタムブランチカラーやラベル設定を保持しますか？**

はい。プレゼンテーションをエクスポートする際、チャートの設定（塗りつぶし、ラベル）は出力形式で保持されます。これは Aspose.Slides がチャートの書式設定を適用した状態でレンダリングするためです。

**チャート上にカスタムオーバーレイを配置するために、ラベルや要素の実際の座標を計算できますか？**

はい。チャートのレイアウトが検証された後、要素（例: [DataLabel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datalabel/)）に対して実際の *x* と実際の *y* が取得可能です。これにより、オーバーレイの正確な位置決めが容易になります。