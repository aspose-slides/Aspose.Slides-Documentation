---
title: Java のプレゼンテーション向けチャート計算の最適化
linktitle: チャート計算
type: docs
weight: 50
url: /ja/java/chart-calculations/
keywords:
- チャート計算
- チャート要素
- 要素の位置
- 実際の位置
- 子要素
- 親要素
- チャート値
- 実際の値
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java の PPT および PPTX におけるチャート計算、データ更新、精度制御を理解し、実用的な Java コード例で学びます。"
---

## **チャート要素の実際の値を計算する**
Aspose.Slides for Java は、これらのプロパティを取得するためのシンプルな API を提供します。Properties of [IAxis](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis) interface provide information about actual position of axis chart element ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMinorUnitScale--))。プロパティに実際の値を設定するには、事前に [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) メソッドを呼び出す必要があります。
```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    
    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    
    double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) pres.dispose();
}
```


## **親チャート要素の実際の位置を計算する**
Aspose.Slides for Java は、これらのプロパティを取得するためのシンプルな API を提供します。Properties of [IActualLayout](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout) interface provide information about actual position of parent chart element ([IActualLayout.getActualX](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualHeight--))。プロパティに実際の値を設定するには、事前に [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) メソッドを呼び出す必要があります。
```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```


## **チャートから情報を非表示にする**
このトピックでは、チャートから情報を非表示にする方法を理解できるように説明します。Aspose.Slides for Java を使用すると、チャートから **タイトル、垂直軸、水平軸** および **グリッド線** を非表示にできます。以下のコード例は、これらのプロパティの使用方法を示しています。
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //チャートのタイトルを非表示にする
    chart.setTitle(false);

    ///値軸を非表示にする
    chart.getAxes().getVerticalAxis().setVisible(false);

    //カテゴリ軸の表示
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //凡例を非表示にする
    chart.setLegend(false);

    //主要グリッドラインを非表示にする
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().removeAt(i);
    }

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getMarker().setSymbol(MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);

    //系列の線の色を設定
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **よくある質問**

**外部の Excel ワークブックはデータ ソースとして機能しますか、また再計算にどのように影響しますか？**

はい。チャートは外部のワークブックを参照できます。外部ソースに接続またはリフレッシュすると、数式と値はそのワークブックから取得され、チャートは開く/編集する操作中に更新を反映します。API を使用して、[specify the external workbook](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) パスを指定し、リンクされたデータを管理できます。

**自分で回帰を実装せずにトレンドラインを計算・表示できますか？**

はい。[Trendlines](/slides/ja/java/trend-line/)（線形、指数、その他）は Aspose.Slides によって追加および更新され、パラメータはシリーズ データから自動的に再計算されるため、独自の計算を実装する必要はありません。

**プレゼンテーションに外部リンクを持つ複数のチャートがある場合、各チャートが計算値に使用するワークブックを制御できますか？**

はい。各チャートはそれぞれの [external workbook](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) を指定できます。または、他のチャートとは独立して、チャートごとに外部ワークブックを作成または置き換えることもできます。