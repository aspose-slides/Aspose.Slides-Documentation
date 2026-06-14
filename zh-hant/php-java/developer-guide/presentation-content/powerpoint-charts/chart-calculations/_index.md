---
title: 在 PHP 中優化簡報的圖表計算
linktitle: 圖表計算
type: docs
weight: 50
url: /zh-hant/php-java/chart-calculations/
keywords:
- 圖表計算
- 圖表元素
- 元素位置
- 實際位置
- 子元素
- 父元素
- 圖表數值
- 實際值
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解在 Aspose.Slides for PHP via Java 中的圖表計算、資料更新與精度控制，適用於 PPT 與 PPTX，並提供實用範例程式碼。"
---
## **概述**

Aspose.Slides 提供用於在簡報中處理圖表計算和佈局資料的 API。本文說明如何取得圖表元素的實際值，包括元素的真實位置與大小以及圖表座標軸的實際值，並解釋這些值是在圖表佈局驗證之後填充的。

此外，本文示範如何取得父圖表元素的實際位置，以及如何隱藏圖表組件（例如標題、座標軸、圖例和格線）。這些範例可協助您以程式方式檢查圖表佈局資訊並控制 PowerPoint 簡報中圖表元素的可見性。

## **計算圖表元素的實際值**
Aspose.Slides for PHP via Java 提供簡易的 API 取得這些屬性。 [Axis](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/axis/) 類別的方法可提供圖表座標軸元素的實際位置資訊（[getActualMaxValue](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/axis/getactualmaxvalue/)、[getActualMinValue](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/axis/getactualminvalue/)、[getActualMajorUnit](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/axis/getactualmajorunit/)、[getActualMinorUnit](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/axis/getactualminorunit/)、[getActualMajorUnitScale](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/axis/getactualmajorunitscale/)、[getActualMinorUnitScale](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/axis/getactualminorunitscale/))。必須先呼叫 [Chart.validateChartLayout](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/validatechartlayout/) 方法，才能將屬性以實際值填充。

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

## **計算父圖表元素的實際位置**
Aspose.Slides for PHP via Java 提供簡易的 API 取得這些屬性。 `ActualLayout` 類別的方法可提供父圖表元素的實際位置資訊（`getActualX`、`getActualY`、`getActualWidth`、`getActualHeight`）。必須先呼叫 [Chart.validateChartLayout](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/validatechartlayout/) 方法，才能將屬性以實際值填充。

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

## **隱藏圖表元素**
本主題說明如何隱藏圖表中的資訊。使用 Aspose.Slides for PHP via Java，您可以隱藏圖表的 **標題、垂直座標軸、水平座標軸** 以及 **格線**。以下程式碼範例示範如何使用這些屬性。

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # 隱藏圖表標題
    $chart->setTitle(false);
    # /隱藏數值軸
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # 類別軸可見性
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # 隱藏圖例
    $chart->setLegend(false);
    # 隱藏主要格線
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # 設定系列線條顏色
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

## **常見問題**

**外部 Excel 活頁簿是否可作為資料來源，且會如何影響重新計算？**

是。圖表可以參考外部活頁簿：當您連接或重新整理外部來源時，公式與值會從該活頁簿取得，圖表會在開啟/編輯操作期間反映更新。API 允許您[指定外部活頁簿](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/setexternalworkbook/)路徑並管理已連結的資料。

**我可以在不自行實作回歸分析的情況下計算並顯示趨勢線嗎？**

是。[趨勢線](/slides/zh-hant/php-java/trend-line/)（線性、指數等）由 Aspose.Slides 自動加入並更新；其參數會根據系列資料自動重新計算，您無需自行實作計算。

**如果簡報中有多個含外部連結的圖表，我能控制每個圖表使用哪個活頁簿來計算值嗎？**

是。每個圖表可指向各自的[外部活頁簿](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/setexternalworkbook/)，或您也可以為每個圖表獨立建立/取代外部活頁簿，而不受其他圖表影響。