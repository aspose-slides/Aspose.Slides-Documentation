---
title: PHP에서 프레젠테이션을 위한 차트 계산 최적화
linktitle: 차트 계산
type: docs
weight: 50
url: /ko/php-java/chart-calculations/
keywords:
- 차트 계산
- 차트 요소
- 요소 위치
- 실제 위치
- 자식 요소
- 부모 요소
- 차트 값
- 실제 값
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java에서 PPT 및 PPTX를 위한 차트 계산, 데이터 업데이트 및 정밀도 제어를 이해하고 실용적인 코드 예제를 통해 배우세요."
---
## **개요**

Aspose.Slides는 프레젠테이션에서 차트 계산 및 레이아웃 데이터를 처리하기 위한 API를 제공합니다. 이 문서에서는 차트 요소의 실제 값, 즉 요소의 실제 위치와 크기 및 차트 축의 실제 값을 가져오는 방법을 보여줍니다. 또한 이러한 값들은 차트 레이아웃 유효성 검사가 수행된 후 채워진다는 것을 설명합니다.

또한 이 문서에서는 부모 차트 요소의 실제 위치를 가져오는 방법과 제목, 축, 범례, 격자선과 같은 차트 구성 요소를 숨기는 방법을 시연합니다. 이러한 예제를 통해 차트 레이아웃 정보를 검사하고 PowerPoint 프레젠테이션에서 차트 요소의 표시 여부를 프로그래밍 방식으로 제어할 수 있습니다.

## **차트 요소의 실제 값 계산**
Aspose.Slides for PHP via Java는 이러한 속성을 가져오기 위한 간단한 API를 제공합니다. [축](https://reference.aspose.com/slides/ko/php-java/aspose.slides/axis/) 클래스의 메서드는 차트 축 요소의 실제 위치에 대한 정보를 제공합니다([getActualMaxValue](https://reference.aspose.com/slides/ko/php-java/aspose.slides/axis/getactualmaxvalue/), [getActualMinValue](https://reference.aspose.com/slides/ko/php-java/aspose.slides/axis/getactualminvalue/), [getActualMajorUnit](https://reference.aspose.com/slides/ko/php-java/aspose.slides/axis/getactualmajorunit/), [getActualMinorUnit](https://reference.aspose.com/slides/ko/php-java/aspose.slides/axis/getactualminorunit/), [getActualMajorUnitScale](https://reference.aspose.com/slides/ko/php-java/aspose.slides/axis/getactualmajorunitscale/), [getActualMinorUnitScale](https://reference.aspose.com/slides/ko/php-java/aspose.slides/axis/getactualminorunitscale/)). 실제 값으로 속성을 채우려면 먼저 [Chart.validateChartLayout](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chart/validatechartlayout/) 메서드를 호출해야 합니다.

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

## **부모 차트 요소의 실제 위치 계산**
Aspose.Slides for PHP via Java는 이러한 속성을 가져오기 위한 간단한 API를 제공합니다. `ActualLayout` 클래스의 메서드는 부모 차트 요소의 실제 위치에 대한 정보를 제공합니다(`getActualX`, `getActualY`, `getActualWidth`, `getActualHeight`). 실제 값으로 속성을 채우려면 먼저 [Chart.validateChartLayout](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chart/validatechartlayout/) 메서드를 호출해야 합니다.

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

## **차트 요소 숨기기**
이 항목에서는 차트에서 정보를 숨기는 방법을 이해하도록 도와줍니다. Aspose.Slides for PHP via Java를 사용하면 차트에서 **제목**, **수직 축**, **수평 축**, **격자선**을 숨길 수 있습니다. 아래 코드 예제는 이러한 속성을 사용하는 방법을 보여줍니다.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # 차트 제목 숨기기
    $chart->setTitle(false);
    # /값 축 숨기기
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # 범주 축 표시 여부
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # 범례 숨기기
    $chart->setLegend(false);
    # 주 격자선 숨기기
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # 시리즈 선 색상 설정
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

**외부 Excel 통합 문서를 데이터 소스로 사용할 수 있나요? 그리고 재계산에 어떤 영향을 미치나요?**

예. 차트는 외부 통합 문서를 참조할 수 있습니다. 외부 소스를 연결하거나 새로 고치면 해당 통합 문서에서 수식과 값이 가져와지고, 차트는 열기/편집 작업 중에 업데이트를 반영합니다. API를 통해 외부 통합 문서의 경로를 [외부 통합 문서 지정](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/setexternalworkbook/)하고 연결된 데이터를 관리할 수 있습니다.

**내가 직접 회귀 분석을 구현하지 않고 추세선을 계산하고 표시할 수 있나요?**

예. [추세선](/slides/ko/php-java/trend-line/) (선형, 지수 등)은 Aspose.Slides에 의해 자동으로 추가 및 업데이트되며, 매개변수는 시리즈 데이터에서 자동으로 재계산되므로 별도의 계산을 구현할 필요가 없습니다.

**프레젠테이션에 외부 링크가 포함된 차트가 여러 개 있는 경우, 각 차트가 사용하는 통합 문서를 개별적으로 제어할 수 있나요?**

예. 각 차트는 자체 [외부 통합 문서](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/setexternalworkbook/)를 지정하거나, 다른 차트와 독립적으로 차트별 외부 통합 문서를 생성/교체할 수 있습니다.