---
title: Java を使用したプレゼンテーションでのバブルチャートのカスタマイズ
linktitle: バブルチャート
type: docs
url: /ja/java/bubble-chart/
keywords:
- バブルチャート
- バブルサイズ
- サイズスケーリング
- サイズ表現
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Java 用 Aspose.Slides で PowerPoint の強力なバブルチャートを作成・カスタマイズし、データ可視化を簡単に向上させましょう。"
---

## **バブルチャートのサイズスケーリング**
Aspose.Slides for Java はバブルチャートのサイズスケーリングをサポートします。Aspose.Slides for Java では、[**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeries#getBubbleSizeScale--)、[**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) および [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) メソッドが追加されました。以下にサンプル例を示します。  
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


## **バブルチャートのサイズとしてデータを表す**
[**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) と [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) メソッドが [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeries)、[IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup) インターフェイスおよび関連クラスに追加されました。**BubbleSizeRepresentation** はバブルチャートでバブルサイズの値がどのように表現されるかを指定します。可能な値は [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/java/com.aspose.slides/BubbleSizeRepresentationType#Area) と [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/java/com.aspose.slides/BubbleSizeRepresentationType#Width) です。これに伴い、データをバブルチャートのサイズとして表す方法を示すための enum **BubbleSizeRepresentationType** が追加されました。サンプルコードを以下に示します。  
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

**「3-D 効果付きバブルチャート」はサポートされていますか？通常のものとどう違うのですか？**  
はい。別のチャートタイプ「Bubble with 3-D」があります。このタイプはバブルに 3‑D スタイルを適用しますが、追加の軸はありません。データは X‑Y‑S（サイズ）のままです。このタイプは[chart type](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) クラスで利用可能です。

**バブルチャートの系列数やデータポイント数に制限はありますか？**  
API レベルでのハードな上限はありません。制約はパフォーマンスや対象となる PowerPoint のバージョンによって決まります。可読性と描画速度を考慮し、ポイント数は適切な範囲に抑えることを推奨します。

**エクスポートはバブルチャートの外観（PDF、画像）にどう影響しますか？**  
サポートされている形式へのエクスポートはチャートの外観を保持します。描画は Aspose.Slides エンジンが実行し、ラスタ形式・ベクター形式ともに一般的なチャート描画ルール（解像度、アンチエイリアスなど）が適用されます。印刷用途の場合は十分な DPI を選択してください。