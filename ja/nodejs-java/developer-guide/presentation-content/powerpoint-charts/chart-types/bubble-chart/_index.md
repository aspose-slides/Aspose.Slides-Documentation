---
title: バブルチャート
type: docs
url: /ja/nodejs-java/bubble-chart/
---

## **バブルチャートのサイズスケーリング**
Aspose.Slides for Node.js via Java はバブルチャートのサイズスケーリングをサポートします。Aspose.Slides for Node.js via Java では [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeries#getBubbleSizeScale--)、[**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeScale--)、および [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeScale-int-) メソッドが追加されました。以下にサンプル例を示します。
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 100, 100, 400, 300);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);
    pres.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **データをバブルチャートのサイズとして表す**
メソッド [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeRepresentation-int-) と [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeRepresentation--) が [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeries)、[ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup) クラス、および関連クラスに追加されました。**BubbleSizeRepresentation** はバブルチャートでバブルサイズの値がどのように表されるかを指定します。可能な値は [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Area) と [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Width) です。したがって、[**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BubbleSizeRepresentationType) 列挙型が追加され、バブルチャートのサイズとしてデータを表す方法を指定できます。サンプルコードは以下です。
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(aspose.slides.BubbleSizeRepresentationType.Width);
    pres.save("Presentation_BubbleSizeRepresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**「3-D エフェクト付きバブルチャート」はサポートされていますか、また通常のものと何が異なりますか？**

はい。別個のチャートタイプ「Bubble with 3-D」が用意されています。バブルに 3-D スタイルが適用されますが、追加の軸は追加されません。データは X-Y-S（サイズ）のままです。このタイプは [chart type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 列挙体で利用可能です。

**バブルチャートのシリーズ数やポイント数に制限はありますか？**

API レベルでの明確な上限はありません。制約はパフォーマンスや対象となる PowerPoint のバージョンによって決まります。可読性と描画速度を考慮し、ポイント数は適切な範囲に抑えることを推奨します。

**エクスポートはバブルチャートの外観にどのように影響しますか（PDF、画像）？**

サポートされている形式へのエクスポートはチャートの外観を保持します。描画は Aspose.Slides エンジンが実行します。ラスタ・ベクタ形式の場合、一般的なチャート描画ルール（解像度、アンチエイリアシング）が適用されるため、印刷時には十分な DPI を選択してください。