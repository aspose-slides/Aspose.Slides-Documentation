---
title: 使用 PHP 管理簡報圖表中的標註
linktitle: 標註
type: docs
url: /zh-hant/php-java/callout/
keywords:
- 圖表標註
- 使用標註
- 資料標籤
- 標籤格式
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，透過簡潔的程式碼範例建立與樣式化標註，支援 PPT 與 PPTX，以自動化簡報工作流程。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用圖表資料標籤的標註（callout）。它展示了如何使用 `setShowLabelAsDataCallout` 方法將標籤顯示為標註、如何為環狀圖設定與標註相關的標籤設定，並說明在將簡報匯出為 PDF、HTML5、SVG 以及點陣圖像格式時，標註及其外觀會被保留。

## **使用標註**
已在 [DataLabelFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/datalabelformat) 類別中加入新方法 [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/datalabelformat/getshowlabelasdatacallout/) 與 [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/datalabelformat/setshowlabelasdatacallout/)。這些方法決定指定圖表的資料標籤是以資料標註方式顯示，還是以資料標籤方式顯示。

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 500, 400);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowLabelAsDataCallout(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->get_Item(2)->getDataLabelFormat()->setShowLabelAsDataCallout(false);
    $pres->save("DisplayCharts.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **為環狀圖設定標註**
Aspose.Slides for PHP via Java 提供了為環狀圖設定系列資料標籤標註形狀的支援。以下給出示範範例。

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::Doughnut, 10, 10, 500, 500, false);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $chart->setLegend(false);
    $seriesIndex = 0;
    while ($seriesIndex < 15) {
      $series = $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, $seriesIndex + 1, "SERIES " . $seriesIndex), $chart->getType());
      $series->setExplosion(0);
      $series->getParentSeriesGroup()->setDoughnutHoleSize(20);
      $series->getParentSeriesGroup()->setFirstSliceAngle(351);
      $seriesIndex++;
    } 
    $categoryIndex = 0;
    while ($categoryIndex < 15) {
      $chart->getChartData()->getCategories()->add($workBook->getCell(0, $categoryIndex + 1, 0, "CATEGORY " . $categoryIndex));
      $i = 0;
      while ($i < java_values($chart->getChartData()->getSeries()->size())) {
        $iCS = $chart->getChartData()->getSeries()->get_Item($i);
        $dataPoint = $iCS->getDataPoints()->addDataPointForDoughnutSeries($workBook->getCell(0, $categoryIndex + 1, $i + 1, 1));
        $dataPoint->getFormat()->getFill()->setFillType(FillType::Solid);
        $dataPoint->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
        $dataPoint->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
        $dataPoint->getFormat()->getLine()->setWidth(1);
        $dataPoint->getFormat()->getLine()->setStyle(LineStyle->Single);
        $dataPoint->getFormat()->getLine()->setDashStyle(LineDashStyle->Solid);
        if ($i == java_values($chart->getChartData()->getSeries()->size()) - 1) {
          $lbl = $dataPoint->getLabel();
          $lbl->getTextFormat()->getTextBlockFormat()->setAutofitType(TextAutofitType::Shape);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->setLatinFont(new FontData("DINPro-Bold"));
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(12);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
          $lbl->getDataLabelFormat()->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
          $lbl->getDataLabelFormat()->setShowValue(false);
          $lbl->getDataLabelFormat()->setShowCategoryName(true);
          $lbl->getDataLabelFormat()->setShowSeriesName(false);
          $lbl->getDataLabelFormat()->setShowLeaderLines(true);
          $lbl->getDataLabelFormat()->setShowLabelAsDataCallout(false);
          $chart->validateChartLayout();
          $lbl->setX($lbl->getX() + 0.5);
          $lbl->setY($lbl->getY() + 0.5);
        }
        $i++;
      } 
      $categoryIndex++;
    } 
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**將簡報轉換為 PDF、HTML5、SVG 或圖像時，標註是否會被保留？**

是。標註是圖表渲染的一部分，因此在匯出至 [PDF](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/)、[HTML5](/slides/zh-hant/php-java/export-to-html5/)、[SVG](/slides/zh-hant/php-java/render-a-slide-as-an-svg-image/) 或 [raster images](/slides/zh-hant/php-java/convert-powerpoint-to-png/) 時，會與投影片的格式一併保留。

**自訂字型在標註中是否可用，且在匯出時其外觀能否被保留？**

是。Aspose.Slides 支援將 [嵌入字型](/slides/zh-hant/php-java/embedded-font/) 嵌入至簡報，並在匯出為 [PDF](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/) 等格式時控制字型嵌入，確保標註在不同系統上看起來相同。