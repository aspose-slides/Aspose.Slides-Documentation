---
title: PHP プレゼンテーション向けのチャート計算を最適化する
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
- チャートの値
- 実際の値
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java における PPT および PPTX のチャート計算、データ更新、精度制御を実用的なコード例と共に理解する"
---

## **チャート要素の実際の値を計算する**
Aspose.Slides for PHP via Java は、これらのプロパティを取得するためのシンプルな API を提供します。[IAxis] インターフェイスのプロパティは、軸チャート要素の実際の位置に関する情報を提供します（[IAxis.getActualMaxValue]、[IAxis.getActualMinValue]、[IAxis.getActualMajorUnit]、[IAxis.getActualMinorUnit]、[IAxis.getActualMajorUnitScale]、[IAxis.getActualMinorUnitScale]）。実際の値でプロパティを埋めるには、事前に[IChart.validateChartLayout()] メソッドを呼び出す必要があります。
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
Aspose.Slides for PHP via Java は、これらのプロパティを取得するためのシンプルな API を提供します。[IActualLayout] インターフェイスのプロパティは、親チャート要素の実際の位置に関する情報を提供します（[IActualLayout.getActualX]、[IActualLayout.getActualY]、[IActualLayout.getActualWidth]、[IActualLayout.getActualHeight]）。実際の値でプロパティを埋めるには、事前に[IChart.validateChartLayout()] メソッドを呼び出す必要があります。
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
このトピックでは、チャートから情報を非表示にする方法を説明します。Aspose.Slides for PHP via Java を使用すると、チャートから **タイトル、垂直軸、水平軸** および **グリッド線** を非表示にできます。以下のコード例は、これらのプロパティの使用方法を示しています。
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # チャートのタイトルを非表示にする
    $chart->setTitle(false);
    # /Values 軸を非表示にする
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # カテゴリ軸の表示
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # 凡例を非表示にする
    $chart->setLegend(false);
    # 主要グリッドラインを非表示にする
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # 系列の線の色を設定する
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


## **よくある質問**

**外部の Excel ワークブックはデータ ソースとして機能しますか？また、再計算にはどのように影響しますか？**

はい。チャートは外部のワークブックを参照できます。外部ソースに接続またはリフレッシュすると、数式や値はそのワークブックから取得され、チャートは開く/編集する際に更新を反映します。API を使用すると、外部ワークブックのパスを[specify the external workbook]で指定し、リンクされたデータを管理できます。

**回帰を自分で実装せずにトレンドラインを計算および表示できますか？**

はい。[Trendlines]（線形、指数、その他）は Aspose.Slides によって追加および更新され、パラメータはシリーズデータから自動的に再計算されますので、独自の計算を実装する必要はありません。

**プレゼンテーションに外部リンクを持つ複数のチャートがある場合、各チャートが計算値に使用するワークブックを制御できますか？**

はい。各チャートはそれぞれの[external workbook]を指すことができ、または他のチャートとは独立してチャートごとに外部ワークブックを作成/置換できます。