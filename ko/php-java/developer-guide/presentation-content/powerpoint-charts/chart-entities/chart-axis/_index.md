---
title: PHP를 사용하여 프레젠테이션에서 차트 축 맞춤 설정
linktitle: 차트 축
type: docs
url: /ko/php-java/chart-axis/
keywords:
- 차트 축
- 수직 축
- 수평 축
- 축 맞춤 설정
- 축 조작
- 축 관리
- 축 속성
- 최대값
- 최소값
- 축 라인
- 날짜 형식
- 축 제목
- 축 위치
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "보고서 및 시각화를 위한 PowerPoint 프레젠테이션에서 차트 축을 맞춤 설정하기 위해 Java를 통한 PHP용 Aspose.Slides 사용 방법을 알아보세요."
---
## **개요**

이 문서에서는 Aspose.Slides에서 차트 축을 사용자 정의하는 방법을 설명합니다. 실제 축값을 가져오고, 축 간 데이터를 교환하고, 선형 차트에서 수직 또는 수평 축을 숨기고, 카테고리 축 유형을 변경하고, 카테고리 축 값의 날짜 형식을 설정하고, 축 제목을 회전하고, 축 위치를 지정하며, 값 축에 단위 레이블을 표시하는 방법을 보여줍니다.

## **차트에서 수직 축의 최대값 가져오기**
Aspose.Slides for PHP via Java을 사용하면 수직 축의 최소값과 최대값을 가져올 수 있습니다. 다음 단계에 따라 진행하세요:

1. 다음 클래스인 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation)의 인스턴스를 생성합니다.
2. 첫 번째 슬라이드에 액세스합니다.
3. 기본 데이터를 사용하여 차트를 추가합니다.
4. 축에서 실제 최대값을 가져옵니다.
5. 축에서 실제 최소값을 가져옵니다.
6. 축의 실제 주요 단위를 가져옵니다.
7. 축의 실제 보조 단위를 가져옵니다.
8. 축의 실제 주요 단위 스케일을 가져옵니다.
9. 축의 실제 보조 단위 스케일을 가져옵니다.

이 샘플 코드(위 단계의 구현)는 필요한 값을 가져오는 방법을 보여줍니다 :

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
    # 프레젠테이션을 저장합니다
    $pres->save("MaxValuesVerticalAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **축 사이의 데이터 교환**
Aspose.Slides를 사용하면 축 간 데이터를 빠르게 교환할 수 있습니다—수직 축(y축)의 데이터가 수평 축(x축)으로 이동하고 그 반대도 마찬가지입니다.

이 PHP 코드는 차트에서 축 간 데이터 교환 작업을 수행하는 방법을 보여줍니다:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    # 행과 열을 전환합니다
    $chart->getChartData()->switchRowColumn();
    # 프레젠테이션을 저장합니다
    $pres->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **라인 차트의 수직 축 비활성화**
이 PHP 코드는 라인 차트의 수직 축을 숨기는 방법을 보여줍니다:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **라인 차트의 수평 축 비활성화**
이 코드는 라인 차트의 수평 축을 숨기는 방법을 보여줍니다:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **카테고리 축 변경**
**CategoryAxisType** 속성을 사용하면 선호하는 카테고리 축 유형(**date** 또는 **text**)을 지정할 수 있습니다. 이 코드는 해당 작업을 보여줍니다:

```php
  $presentation = new Presentation("ExistingChart.pptx");
  try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);
    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **카테고리 축 값의 날짜 형식 설정**
Aspose.Slides for PHP via Java를 사용하면 카테고리 축 값의 날짜 형식을 설정할 수 있습니다. 이 PHP 코드에서 작업을 시연합니다:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 50, 50, 450, 300);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B2", 1));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B3", 2));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B4", 3));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B5", 4));
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **차트 축 제목의 회전 각도 설정**
Aspose.Slides for PHP via Java를 사용하면 차트 축 제목의 회전 각도를 설정할 수 있습니다. 이 PHP 코드가 작업을 시연합니다:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **카테고리 또는 값 축에서 축 위치 설정**
Aspose.Slides for PHP via Java를 사용하면 카테고리 축 또는 값 축에서 축 위치를 설정할 수 있습니다. 이 PHP 코드가 작업 수행 방법을 보여줍니다:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **차트 값 축에 표시 단위 레이블 활성화**
Aspose.Slides for PHP via Java를 사용하면 차트 값 축에 단위 레이블을 표시하도록 구성할 수 있습니다. 이 PHP 코드가 작업을 시연합니다:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**축이 교차하는 값(축 교차점)을 어떻게 설정합니까?**

축은 [교차 설정](https://reference.aspose.com/slides/ko/php-java/aspose.slides/axis/setcrosstype/)을 제공합니다: 0, 최대 카테고리/값 또는 특정 숫자 값에서 교차하도록 선택할 수 있습니다. 이는 X축을 위아래로 이동하거나 기준선을 강조할 때 유용합니다.

**틱 레이블을 축에 상대적으로 어떻게 배치합니까(옆, 외부, 내부)?**

[레이블 위치](https://reference.aspose.com/slides/ko/php-java/aspose.slides/axis/setmajortickmark/)를 "cross", "outside" 또는 "inside"로 설정합니다. 이는 가독성에 영향을 주며 특히 작은 차트에서 공간을 절약하는 데 도움이 됩니다.