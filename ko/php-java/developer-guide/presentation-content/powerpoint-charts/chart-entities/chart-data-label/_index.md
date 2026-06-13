---
title: PHP를 사용하여 프레젠테이션에서 차트 데이터 라벨 관리
linktitle: 데이터 라벨
type: docs
url: /ko/php-java/chart-data-label/
keywords:
- 차트
- 데이터 라벨
- 데이터 정밀도
- 백분율
- 라벨 거리
- 라벨 위치
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 프레젠테이션에 차트 데이터 라벨을 추가하고 형식화하는 방법을 배워 보다 매력적인 슬라이드를 만들 수 있습니다."
---
## **소개**

차트의 데이터 레이블은 차트 데이터 시리즈 또는 개별 데이터 포인트에 대한 세부 정보를 표시합니다. 이를 통해 독자는 데이터 시리즈를 빠르게 식별할 수 있으며 차트를 이해하기 쉽게 만들 수 있습니다.

## **차트 데이터 레이블의 데이터 정밀도 설정**

이 PHP 코드에서는 차트 데이터 레이블의 데이터 정밀도를 설정하는 방법을 보여줍니다:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);
    $chart->setDataTable(true);
    $chart->getChartData()->getSeries()->get_Item(0)->setNumberFormatOfValues("#,##0.00");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **라벨에 백분율 표시**

Aspose.Slides for PHP via Java를 사용하면 표시된 차트에 백분율 라벨을 설정할 수 있습니다. 이 PHP 코드는 해당 작업을 시연합니다:

```php
  # Presentation 클래스의 인스턴스를 생성합니다.
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드를 가져옵니다.
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 400, 400);
    $series;
    $total_for_Cat = new double[$chart->getChartData()->getCategories()->size()];
    for($k = 0; $k < java_values($chart->getChartData()->getCategories()->size()) ; $k++) {
      $cat = $chart->getChartData()->getCategories()->get_Item($k);
      for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
        $total_for_Cat[$k] = $total_for_Cat[$k] + $chart->getChartData()->getSeries()->get_Item($i)->getDataPoints()->get_Item($k)->getValue()->getData();
      }
    }
    $dataPontPercent = 0.0;
    for($x = 0; $x < java_values($chart->getChartData()->getSeries()->size()) ; $x++) {
      $series = $chart->getChartData()->getSeries()->get_Item($x);
      $series->getLabels()->getDefaultDataLabelFormat()->setShowLegendKey(false);
      for($j = 0; $j < java_values($series->getDataPoints()->size()) ; $j++) {
        $lbl = $series->getDataPoints()->get_Item($j)->getLabel();
        $dataPontPercent = $series->getDataPoints()->get_Item($j)->getValue()->getData() / $total_for_Cat[$j] * 100;
        $port = new Portion();
        $port->setText(sprintf("{0:F2} %.2f", $dataPontPercent));
        $port->getPortionFormat()->setFontHeight(8.0);
        $lbl->getTextFrameForOverriding()->setText("");
        $para = $lbl->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
        $para->getPortions()->add($port);
        $lbl->getDataLabelFormat()->setShowSeriesName(false);
        $lbl->getDataLabelFormat()->setShowPercentage(false);
        $lbl->getDataLabelFormat()->setShowLegendKey(false);
        $lbl->getDataLabelFormat()->setShowCategoryName(false);
        $lbl->getDataLabelFormat()->setShowBubbleSize(false);
      }
    }
    # 차트를 포함한 프레젠테이션을 저장합니다.
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **차트 데이터 레이블에 백분율 기호 설정**

이 PHP 코드는 차트 데이터 레이블에 백분율 기호를 설정하는 방법을 보여줍니다:

```php
  # Presentation 클래스의 인스턴스를 생성합니다.
  $pres = new Presentation();
  try {
    # 인덱스를 통해 슬라이드의 참조를 가져옵니다.
    $slide = $pres->getSlides()->get_Item(0);
    # 슬라이드에 PercentsStackedColumn 차트를 생성합니다.
    $chart = $slide->getShapes()->addChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);
    # NumberFormatLinkedToSource를 false로 설정합니다.
    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00%");
    $chart->getChartData()->getSeries()->clear();
    $defaultWorksheetIndex = 0;
    # 차트 데이터 워크시트를 가져옵니다.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # 새 시리즈를 추가합니다.
    $series = $chart->getChartData()->getSeries()->add($workbook->getCell($defaultWorksheetIndex, 0, 1, "Reds"), $chart->getType());
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 1, 1, 0.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 2, 1, 0.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 3, 1, 0.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 4, 1, 0.65));
    # 시리즈의 채우기 색을 설정합니다.
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # LabelFormat 속성을 설정합니다.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $series->getLabels()->getDefaultDataLabelFormat()->setNumberFormat("0.0%");
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(10);
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # 새 시리즈를 추가합니다.
    $series2 = $chart->getChartData()->getSeries()->add($workbook->getCell($defaultWorksheetIndex, 0, 2, "Blues"), $chart->getType());
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 1, 2, 0.7));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 2, 2, 0.5));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 3, 2, 0.2));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 4, 2, 0.35));
    # 채우기 유형과 색을 설정합니다.
    $series2->getFormat()->getFill()->setFillType(FillType::Solid);
    $series2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $series2->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series2->getLabels()->getDefaultDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $series2->getLabels()->getDefaultDataLabelFormat()->setNumberFormat("0.0%");
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(10);
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    # 프레젠테이션을 디스크에 저장합니다.
    $pres->save("SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **축에서 라벨 거리 설정**

이 PHP 코드는 축을 기준으로 플롯된 차트에서 범주 축으로부터 라벨 거리를 설정하는 방법을 보여줍니다:

```php
  # Presentation 클래스의 인스턴스를 생성합니다.
  $pres = new Presentation();
  try {
    # 슬라이드의 참조를 가져옵니다.
    $sld = $pres->getSlides()->get_Item(0);
    # 슬라이드에 차트를 생성합니다.
    $ch = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    # 축으로부터 라벨 거리를 설정합니다.
    $ch->getAxes()->getHorizontalAxis()->setLabelOffset(500);
    # 프레젠테이션을 디스크에 저장합니다.
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **라벨 위치 조정**

파이 차트와 같이 축에 의존하지 않는 차트를 만들 경우, 차트의 데이터 레이블이 가장자리와 너무 가깝게 배치될 수 있습니다. 이 경우, 리더 라인이 명확히 표시되도록 데이터 레이블의 위치를 조정해야 합니다.

이 PHP 코드는 파이 차트에서 라벨 위치를 조정하는 방법을 보여줍니다:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 200, 200);
    $series = $chart->getChartData()->getSeries();
    $label = $series->get_Item(0)->getLabels()->get_Item(0);
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setPosition(LegendDataLabelPosition->OutsideEnd);
    $label->setX(0.71);
    $label->setY(0.04);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **FAQ**

**밀집된 차트에서 데이터 라벨이 겹치는 것을 어떻게 방지할 수 있나요?**

자동 라벨 배치, 리더 라인 및 글꼴 크기 축소를 결합합니다; 필요한 경우 일부 필드(예: 카테고리)를 숨기거나 극단/핵심 포인트에만 라벨을 표시합니다.

**값이 0, 음수 또는 비어 있는 경우에만 라벨을 비활성화하려면 어떻게 해야 하나요?**

라벨을 활성화하기 전에 데이터 포인트를 필터링하고, 정의된 규칙에 따라 0값, 음수값 또는 누락된 값에 대해 표시를 끕니다.

**PDF/이미지로 내보낼 때 일관된 라벨 스타일을 보장하려면 어떻게 해야 하나요?**

글꼴(패밀리, 크기)을 명시적으로 설정하고, 렌더링 측에서 해당 글꼴이 사용 가능한지 확인하여 대체 글꼴이 적용되지 않도록 합니다.