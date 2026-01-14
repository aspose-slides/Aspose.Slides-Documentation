---
title: PHPでのプレゼンテーション向けチャート計算の最適化
linktitle: チャート計算
type: docs
weight: 50
url: /ja/php-java/chart-calculations/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用した PPT および PPTX のチャート計算、データ更新、精度制御を理解し、実用的なコード例で学びます。"
---

## **チャート要素の実際の値を計算する**
Aspose.Slides for PHP via Java は、これらのプロパティを取得するためのシンプルな API を提供します。[Axis](https://reference.aspose.com/slides/php-java/aspose.slides/axis/) クラスのメソッドは、軸チャート要素の実際の位置に関する情報を提供します（[getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/)、[getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/)、[getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/)、[getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/)、[getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/)、[getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/))。実際の値でプロパティを埋めるには、事前に[Chart.validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/)メソッドを呼び出す必要があります。
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **親チャート要素の実際の位置を計算する**
Aspose.Slides for PHP via Java は、これらのプロパティを取得するためのシンプルな API を提供します。`ActualLayout` クラスのメソッドは、親チャート要素の実際の位置に関する情報を提供します（`getActualX`、`getActualY`、`getActualWidth`、`getActualHeight`）。実際の値でプロパティを埋めるには、事前に[Chart.validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/)メソッドを呼び出す必要があります。
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **チャート要素を非表示にする**
このトピックでは、チャートから情報を非表示にする方法について説明します。Aspose.Slides for PHP via Java を使用すると、**タイトル、垂直軸、水平軸** および **グリッド線** をチャートから非表示にできます。以下のコード例では、これらのプロパティの使用方法を示します。
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # チャートのタイトルを非表示にする
    $chart->setTitle(false);
    # 軸の値を非表示にする
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # カテゴリ軸の表示
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # 凡例を非表示にする
    $chart->setLegend(false);
    # 主要グリッド線を非表示にする
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # 系列の線色を設定する
    $series->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $series->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Solid);
    $pres->save("HideInformationFromChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**外部の Excel ワークブックをデータ ソースとして使用できますか？また、再計算にどのような影響がありますか？**

はい。チャートは外部のワークブックを参照できます。外部ソースに接続または更新すると、数式と値がそのワークブックから取得され、チャートは開く/編集する操作中に更新を反映します。API を使用して、外部ワークブックのパスを[外部ワークブックを指定する](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/)で指定し、リンクされたデータを管理できます。

**自分で回帰分析を実装せずにトレンドラインを計算・表示できますか？**

はい。[トレンドライン](/slides/ja/php-java/trend-line/)（線形、指数、その他）は Aspose.Slides によって追加および更新され、パラメータはシリーズ データから自動的に再計算されるため、独自の計算を実装する必要はありません。

**プレゼンテーションに外部リンク付きの複数のチャートがある場合、各チャートが使用するワークブックを個別に制御できますか？**

はい。各チャートはそれぞれの[外部ワークブック](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/)を指すことができ、または他のチャートとは独立して外部ワークブックを作成/置換することも可能です。