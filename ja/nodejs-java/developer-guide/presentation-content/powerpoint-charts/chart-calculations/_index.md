---
title: プレゼンテーションにおける JavaScript のチャート計算を最適化
linktitle: チャート計算
type: docs
weight: 50
url: /ja/nodejs-java/chart-calculations/
keywords:
- チャート計算
- チャート要素
- 要素位置
- 実際の位置
- 子要素
- 親要素
- チャート値
- 実際の値
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js の PPT および PPTX におけるチャート計算、データ更新、精度制御を理解し、実用的な JavaScript コード例を通じて学びます。"
---

## **チャート要素の実際の値を計算する**

Aspose.Slides for Node.js via Java は、これらのプロパティを取得するためのシンプルな API を提供します。[Axis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis) クラスのプロパティは、軸チャート要素の実際の位置に関する情報を提供します（[Axis.getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMaxValue--)、[Axis.getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinValue--)、[Axis.getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMajorUnit--)、[Axis.getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinorUnit--)、[Axis.getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMajorUnitScale--)、[Axis.getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinorUnitScale--)。プロパティに実際の値を設定するには、事前に[Chart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#validateChartLayout--) メソッドを呼び出す必要があります。
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **親チャート要素の実際の位置を計算する**

Aspose.Slides for Node.js via Java は、これらのプロパティを取得するためのシンプルな API を提供します。`ActualLayout` クラスのプロパティは、親チャート要素の実際の位置に関する情報を提供します（`ActualLayout.getActualX`、`ActualLayout.getActualY`、`ActualLayout.getActualWidth`、`ActualLayout.getActualHeight`）。プロパティに実際の値を設定するには、事前に[Chart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#validateChartLayout--) メソッドを呼び出す必要があります。
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **チャートから情報を非表示にする**

このトピックでは、チャートから情報を非表示にする方法を説明します。Aspose.Slides for Node.js via Java を使用すると、チャートから **タイトル、垂直軸、水平軸** および **グリッド線** を非表示にできます。以下のコード例は、これらのプロパティの使用方法を示しています。
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 140, 118, 320, 370);
    // チャートタイトルを非表示にする
    chart.setTitle(false);
    // /値軸を非表示にする
    chart.getAxes().getVerticalAxis().setVisible(false);
    // カテゴリ軸の可視性
    chart.getAxes().getHorizontalAxis().setVisible(false);
    // 凡例を非表示にする
    chart.setLegend(false);
    // 主要グリッドラインを非表示にする
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().removeAt(i);
    }
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);
    // 系列線の色を設定する
    series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
    pres.save("HideInformationFromChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**外部の Excel ワークブックをデータ ソースとして使用できますか？また、再計算にどのように影響しますか？**

はい。チャートは外部ワークブックを参照できます。外部ソースに接続またはリフレッシュすると、数式と値はそのワークブックから取得され、チャートは開く／編集する操作中に更新を反映します。API を使用すると、[外部ワークブックを指定](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) のパスを指定し、リンクされたデータを管理できます。

**回帰分析を自分で実装せずにトレンドラインを計算・表示できますか？**

はい。[Trendlines](/slides/ja/nodejs-java/trend-line/)（線形、指数、その他）は Aspose.Slides によって追加および更新されます。パラメータは系列データから自動的に再計算されるため、独自の計算を実装する必要はありません。

**プレゼンテーションに外部リンクを持つ複数のチャートがある場合、各チャートが計算値に使用するワークブックを制御できますか？**

はい。各チャートはそれぞれの[外部ワークブック](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) を指定できます。または、チャートごとに外部ワークブックを作成または置き換えることができ、他のチャートとは独立しています。