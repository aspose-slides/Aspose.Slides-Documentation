---
title: Android でのプレゼンテーションにおけるバブルチャートのカスタマイズ
linktitle: バブルチャート
type: docs
url: /ja/androidjava/bubble-chart/
keywords:
- バブルチャート
- バブルサイズ
- サイズスケーリング
- サイズ表現
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint で強力なバブルチャートを作成・カスタマイズし、データ可視化を簡単に向上させましょう。"
---

## **バブルチャートのサイズスケーリング**
Aspose.Slides for Android via Java はバブルチャートのサイズスケーリングをサポートします。Aspose.Slides for Android via Java の [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeries#getBubbleSizeScale--)、[**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--)、[**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) メソッドが追加されました。以下にサンプル例を示します。
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);

    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **データをバブルチャートのサイズとして表す**
メソッド [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) と [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) が [**IChartSeries**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeries)、[**IChartSeriesGroup**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup) インターフェイスおよび関連クラスに追加されました。**BubbleSizeRepresentation** はバブルチャートでバブルサイズの値がどのように表現されるかを指定します。可能な値は [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Area) と [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Width) です。これに伴い、[**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType) 列挙型が追加され、データをバブルチャートのサイズとして表す方法を指定できるようになりました。以下にサンプルコードを示します。
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width);

    pres.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**「3-D エフェクト付きバブルチャート」はサポートされていますか？通常のものとどのように異なりますか？**

はい。別個のチャートタイプ「Bubble with 3-D」が用意されています。バブルに 3-D スタイルが適用されますが、追加の軸はなく、データは X‑Y‑S（サイズ）のままです。このタイプは [chart type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) クラスで利用可能です。

**バブルチャートのシリーズ数やポイント数に制限はありますか？**

API レベルでの明確な上限はありません。制約はパフォーマンスや対象となる PowerPoint のバージョンによって決まります。可読性と描画速度を考慮し、ポイント数は適切な範囲に抑えることを推奨します。

**バブルチャートをエクスポート（PDF、画像など）すると外観はどう変わりますか？**

サポートされている形式へのエクスポートはチャートの外観を保持します。レンダリングは Aspose.Slides エンジンが行います。ラスタ形式・ベクタ形式ともに、一般的なチャート描画の規則（解像度、アンチエイリアスなど）が適用されるため、印刷時は十分な DPI を選択してください。