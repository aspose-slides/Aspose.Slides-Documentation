---
title: Treemap と Sunburst チャートのデータポイント
type: docs
url: /ja/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords: "Aspose.Slides for Node.js via Java の Sunburst グラフ"
description: "Aspose.Slides for Node.js via Java を使用した Sunburst グラフ、Sunburst ダイアグラム、Sunburst チャート、Radial チャート、Radial グラフ、または Multi Level Pie Chart"
---

PowerPoint のさまざまなチャートタイプの中で、階層構造を持つ 2 つのタイプ **Treemap** と **Sunburst**（Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph、Multi Level Pie Chart とも呼ばれます）があります。これらのチャートは、葉から枝の先までツリー構造で整理された階層データを表示します。葉はシリーズのデータポイントで定義され、各ネストされたグループレベルは対応するカテゴリで定義されます。Aspose.Slides for Node.js via Java は、JavaScript で Sunburst Chart と Treemap のデータポイントの書式設定を可能にします。

以下は Sunburst Chart の例で、Series1 列のデータが葉ノードを定義し、他の列が階層データポイントを定義しています:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

プレゼンテーションに新しい Sunburst チャートを追加しましょう:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" title="See also" %}} 
- [**Creating Sunburst Chart**](/slides/ja/nodejs-java/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

チャートのデータポイントを書式設定する必要がある場合は、次のクラスとメソッドを使用します:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevelsManager), 
[ChartDataPointLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel) クラス
および [**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) メソッドは、Treemap と Sunburst チャートのデータポイントの書式設定にアクセスできます。
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevelsManager) は、マルチレベルカテゴリにアクセスするために使用され、[**ChartDataPointLevel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel) オブジェクトのコンテナを表します。基本的には、データポイント固有のプロパティが追加された [**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartCategoryLevelsManager) のラッパーです。
[**ChartDataPointLevel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel) クラスには、[**getFormat**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel#getFormat--) と [**getDataLabel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel#getLabel--) の 2 つのメソッドがあり、対応する設定にアクセスできます。

## **Show Data Point Value**
"Leaf 4" データポイントの値を表示します:
```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Set Data Point Label and Color**
"Branch 1" データラベルをカテゴリ名ではなくシリーズ名 ("Series1") に変更し、テキスト色を黄色に設定します:
```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Set Data Point Branch Color**
"Steam 4" ブランチの色を変更します:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
    var stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);
    stem4branch.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Can I change the order (sorting) of segments in Sunburst/Treemap?**

いいえ。PowerPoint はセグメントを自動的に（通常は降順・時計回り）ソートします。Aspose.Slides も同様の動作を行うため、直接順序を変更することはできません。データを事前に加工することで実現します。

**How does the presentation theme affect the colors of segments and labels?**

チャートの色はプレゼンテーションの [theme/palette](/slides/ja/nodejs-java/presentation-theme/) を継承します（明示的に塗りやフォントを設定しない限り）。一貫した結果を得るには、必要なレベルで実線塗りおよびテキスト書式を固定してください。

**Will export to PDF/PNG preserve custom branch colors and label settings?**

はい。プレゼンテーションをエクスポートするとき、チャートの設定（塗り、ラベル）は出力形式に保持されます。Aspose.Slides はチャートの書式設定を適用した状態でレンダリングします。

**Can I compute the actual coordinates of a label/element for custom overlay placement on top of the chart?**

はい。チャートのレイアウトが確定した後、要素（例: [DataLabel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/)）の actual X と actual Y が取得できるため、オーバーレイの正確な位置決めに利用できます。