---
title: チャート計算
type: docs
weight: 50
url: /ja/nodejs-java/chart-calculations/
---

## **チャート要素の実際の値を計算する**

Aspose.Slides for Node.js via Java はこれらのプロパティを取得するためのシンプルな API を提供します。クラス [Axis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis) のプロパティは軸チャート要素の実際の位置に関する情報を提供します（[Axis.getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMaxValue--)、[Axis.getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinValue--)、[Axis.getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMajorUnit--)、[Axis.getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinorUnit--)、[Axis.getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMajorUnitScale--)、[Axis.getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinorUnitScale--)）。実際の値でプロパティを埋めるには、事前にメソッド [Chart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#validateChartLayout--) を呼び出す必要があります。
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

Aspose.Slides for Node.js via Java はこれらのプロパティを取得するためのシンプルな API を提供します。クラス [ActualLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout) のプロパティは親チャート要素の実際の位置に関する情報を提供します（[ActualLayout.getActualX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout#getActualX--)、[ActualLayout.getActualY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout#getActualY--)、[ActualLayout.getActualWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout#getActualWidth--)、[ActualLayout.getActualHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout#getActualHeight--)）。実際の値でプロパティを埋めるには、事前にメソッド [Chart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#validateChartLayout--) を呼び出す必要があります。
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

このトピックはチャートから情報を非表示にする方法を理解するのに役立ちます。Aspose.Slides for Node.js via Java を使用すると、チャートから **タイトル、垂直軸、水平軸** および **グリッド線** を非表示にできます。以下のコード例はこれらのプロパティの使用方法を示しています。
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 140, 118, 320, 370);
    // チャートタイトルを非表示にする
    chart.setTitle(false);
    // /値軸を非表示にする
    chart.getAxes().getVerticalAxis().setVisible(false);
    // カテゴリ軸の表示
    chart.getAxes().getHorizontalAxis().setVisible(false);
    // 凡例を非表示にする
    chart.setLegend(false);
    // 主目盛り線を非表示にする
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().removeAt(i);
    }
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);
    // 系列の線の色を設定
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

**外部の Excel ワークブックをデータ ソースとして使用できますか？また、再計算にどのような影響がありますか？**

はい。チャートは外部ワークブックを参照できます。外部ソースに接続または更新すると、数式と値がそのワークブックから取得され、開く/編集操作中にチャートが更新されます。API では [外部ワークブック](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) のパスを指定してリンクされたデータを管理できます。

**回帰分析を自分で実装せずにトレンドラインを計算・表示できますか？**

はい。 [トレンドライン](/slides/ja/nodejs-java/trend-line/)（線形、指数など）は Aspose.Slides によって追加・更新され、パラメータはシリーズ データから自動的に再計算されるため、独自の計算を実装する必要はありません。

**プレゼンテーションに複数のチャートがあり、外部リンクがある場合、各チャートが使用するワークブックを個別に制御できますか？**

はい。各チャートはそれぞれの [外部ワークブック](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) を指すことができ、またチャートごとに外部ワークブックを作成または置き換えることが他のチャートに影響しないように可能です。