---
title: PHP を使用したプレゼンテーション チャートのコールアウト管理
linktitle: コールアウト
type: docs
url: /ja/php-java/callout/
keywords:
- チャート コールアウト
- コールアウト の使用
- データ ラベル
- ラベル フォーマット
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "簡潔なコード例で Aspose.Slides for PHP via Java のコールアウトを作成・スタイル設定し、PPT および PPTX に対応してプレゼンテーション ワークフローを自動化します。"
---

## **コールアウトの使用**
新しいメソッド [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/php-java/aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) と [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/php-java/aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) が [DataLabelFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat) クラスと [IDataLabelFormat](https://reference.aspose.com/slides/php-java/aspose.slides/idatalabelformat) インターフェイスに追加されました。これらのメソッドは、指定されたチャートのデータ ラベルをデータ コールアウトとして表示するか、データ ラベルとして表示するかを決定します。
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


## **ドーナツ チャートのコールアウトを設定する**
Aspose.Slides for PHP via Java は、ドーナツ チャートの系列データ ラベル コールアウト形状の設定をサポートします。以下にサンプル例を示します。
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


## **FAQ**

**プレゼンテーションを PDF、HTML5、SVG、または画像に変換する際に、コールアウトは保持されますか？**

はい。コールアウトはチャートの描画の一部であるため、[PDF](/slides/ja/php-java/convert-powerpoint-to-pdf/)、[HTML5](/slides/ja/php-java/export-to-html5/)、[SVG](/slides/ja/php-java/render-a-slide-as-an-svg-image/)、または [raster images](/slides/ja/php-java/convert-powerpoint-to-png/) にエクスポートする際に、スライドの書式設定とともに保持されます。

**カスタム フォントはコールアウトで機能し、エクスポート時に外観が保持されますか？**

はい。Aspose.Slides はプレゼンテーションへの[フォント埋め込み](/slides/ja/php-java/embedded-font/) をサポートしており、[PDF](/slides/ja/php-java/convert-powerpoint-to-pdf/) などのエクスポート時にフォント埋め込みを制御します。これにより、異なるシステム間でもコールアウトの外観が同じまま保持されます。