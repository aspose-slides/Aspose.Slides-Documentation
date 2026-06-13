---
title: PHP를 사용한 프레젠테이션 차트의 콜아웃 관리
linktitle: 콜아웃
type: docs
url: /ko/php-java/callout/
keywords:
- 차트 콜아웃
- 콜아웃 사용
- 데이터 레이블
- 레이블 형식
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java에서 콜아웃을 만들고 스타일링하며, PPT 및 PPTX와 호환되는 간결한 코드 예제로 프레젠테이션 워크플로를 자동화합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 차트 데이터 레이블에 대한 콜아웃을 사용하는 방법을 설명합니다. `setShowLabelAsDataCallout` 메서드를 사용하여 레이블을 콜아웃으로 표시하는 방법, 도넛 차트에 대한 콜아웃 관련 레이블 설정을 구성하는 방법, 그리고 프레젠테이션을 PDF, HTML5, SVG 및 래스터 이미지 형식으로 내보낼 때 콜아웃과 그 모양이 보존된다는 점을 알립니다.

## **콜아웃 사용**
새 메서드 [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/datalabelformat/getshowlabelasdatacallout/) 및 [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/datalabelformat/setshowlabelasdatacallout/)가 [DataLabelFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/datalabelformat) 클래스에 추가되었습니다. 이 메서드는 지정된 차트의 데이터 레이블을 데이터 콜아웃으로 표시할지 아니면 일반 데이터 레이블로 표시할지를 결정합니다.

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

## **도넛 차트에 콜아웃 설정**
Aspose.Slides for PHP via Java는 도넛 차트에 대한 시리즈 데이터 레이블 콜아웃 모양 설정을 지원합니다. 아래 샘플 예제가 제공됩니다.

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

## **자주 묻는 질문**

**프레젠테이션을 PDF, HTML5, SVG 또는 이미지로 변환할 때 콜아웃이 보존되나요?**

예. 콜아웃은 차트 렌더링의 일부이므로 [PDF](/slides/ko/php-java/convert-powerpoint-to-pdf/), [HTML5](/slides/ko/php-java/export-to-html5/), [SVG](/slides/ko/php-java/render-a-slide-as-an-svg-image/), 또는 [raster images](/slides/ko/php-java/convert-powerpoint-to-png/)로 내보낼 때 슬라이드 형식과 함께 보존됩니다.

**사용자 정의 글꼴이 콜아웃에서 작동하고, 내보내기 시 모양이 보존될 수 있나요?**

예. Aspose.Slides는 프레젠테이션에 [글꼴 포함](/slides/ko/php-java/embedded-font/)을 지원하며, [PDF](/slides/ko/php-java/convert-powerpoint-to-pdf/)와 같은 내보내기 시 글꼴 삽입을 제어하여 콜아웃이 다양한 시스템에서 동일하게 표시되도록 합니다.