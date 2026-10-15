---
title: PHP를 사용하여 프레젠테이션에서 차트 축 사용자 지정
linktitle: 차트 축
type: docs
url: /ko/php-java/chart-axis/
keywords:
- 차트 축
- 수직 축
- 수평 축
- 축 사용자 지정
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
description: "보고서 및 시각화를 위한 PowerPoint 프레젠테이션에서 차트 축을 사용자 지정하기 위해 Java를 통해 PHP용 Aspose.Slides를 사용하는 방법을 알아보세요."
---
## **개요**

이 문서에서는 Aspose.Slides for PHP via Java를 사용하여 차트 축을 사용자 지정하는 방법을 설명합니다. 계산된 축 값, 차트 행과 열 전환, 축 표시 여부, 범주 레이블 및 눈금 간격, 날짜 범주 및 형식 지정, 제목 회전, 축 위치 지정, 표시 단위 및 로그 스케일링을 다룹니다.

## **차트의 수직 축에 최대값 가져오기**

[프레젠테이션](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)을 만들고 기본 데이터가 있는 영역 차트를 추가합니다. 차트 레이아웃을 최신 상태로 유지하려면 계산된 축 값을 읽기 전에 [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/)을 호출합니다.

축 한계를 위해 [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/)와 [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/)을 읽고, 눈금 간격을 위해 [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/)와 [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/)을 읽습니다. 날짜 축과 관련된 시간 단위 스케일은 [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/)와 [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/)이 제공합니다. 예제에서는 이러한 값을 로컬 변수에 저장하고 차트를 저장합니다.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();

    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();

    $majorUnit = $chart->getAxes()->getVerticalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getVerticalAxis()->getActualMinorUnit();

    $majorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMajorUnitScale();
    $minorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMinorUnitScale();

    $presentation->save("AxisValues_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **축 간 데이터 교환**

[switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/)을 사용하여 차트 데이터에서 시리즈와 범주의 역할을 교환합니다. 이전의 각 범주는 시리즈가 되고, 이전의 각 시리즈는 범주가 됩니다. 이는 데이터 그룹화 방식을 변경하지만 가로 및 세로 축을 교환하지는 않습니다. 예제에서는 [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/)을 사용하여 기본 데이터를 `Sheet1!A1:D5`에 바인딩하고(헤더 행과 범주 열 포함) 행과 열을 전환합니다. 네 개의 시리즈와 세 개의 범주를 가진 차트를 저장합니다.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $chart->getChartData()->setRange("Sheet1!A1:D5");
    $chart->getChartData()->switchRowColumn();

    $presentation->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **축의 플롯 순서 역전**

[setPlotOrderReversed](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setplotorderreversed/)을 사용하여 범주축 또는 값축의 순서를 역전시킵니다. 예를 들어, 가로 막대 차트는 워크시트와 동일한 순서(계획, 개발, 테스트)로 상단에서 하단으로 프로젝트 단계를 표시할 수 있습니다. 축을 역전하면 플롯 방향이 바뀔 뿐이며, 워크북 데이터가 정렬되거나 재배열되지는 않습니다. 비교를 위해 [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/)은 시리즈와 범주의 역할을 교환합니다.

다음 예제는 세 단계와 하나의 시리즈를 가진 가로 막대 차트를 생성합니다. 정상 순서, 역전된 범주 및 역전된 값의 세 슬라이드를 가진 프레젠테이션을 저장합니다. 각 복사본은 동일한 데이터 세트를 사용하고, 각 복사본에서는 하나의 축만 역전됩니다.

```php
use aspose\slides\ChartType;
use aspose\slides\CrossesType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredBar, 50, 40, 620, 320);
    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredBar);
    $stages = ["Planning", "Development", "Testing"];
    $values = [10, 30, 20];
    for ($i = 0; $i < count($stages); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $stages[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    // 슬라이드 2: 첫 번째 범주를 상단에 표시합니다.
    $categorySlide = $presentation->getSlides()->addClone($slide);
    $categoryChart = $categorySlide->getShapes()->get_Item(0);
    $categoryChart->getAxes()->getVerticalAxis()->setPlotOrderReversed(true);
    // 수평 값 축을 하단에 유지합니다.
    $categoryChart->getAxes()->getVerticalAxis()->setCrossType(CrossesType::Maximum);

    // 슬라이드 3: 수평 숫자 스케일만 역전합니다.
    $valueSlide = $presentation->getSlides()->addClone($slide);
    $valueChart = $valueSlide->getShapes()->get_Item(0);
    $valueChart->getAxes()->getHorizontalAxis()->setPlotOrderReversed(true);

    $presentation->save("ReversedAxes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

축을 역전하면 수직 축을 플롯의 반대쪽으로 이동시킬 수도 있습니다. [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/)은 다른 축이 구성 중인 축과 교차하는 위치를 제어합니다. 슬라이드 2에서는 역전된 범주축에 `CrossesType::Maximum`을 적용하여 가로 값축이 하단에 유지되도록 합니다. 특정 교차점을 지정하려면 [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/)을 사용합니다. 방향을 변경할 때 교차 설정을 확인하십시오(특히 차트에 사용자 지정 교차점이 이미 있는 경우). `false`와 함께 `setPlotOrderReversed`를 호출하면 정상 플롯 방향을 복원합니다; 교차 설정은 별도로 관리됩니다.

| 정상 순서 (슬라이드 1) | 역전된 범주 (슬라이드 2) | 역전된 값 (슬라이드 3) |
| --- | --- | --- |
| ![정상 범주 및 값 축 순서의 가로 막대 차트](axis-order-normal.png) | ![상단부터 하단으로 범주가 표시되는 가로 막대 차트](axis-order-categories-reversed.png) | ![값 축이 역전되고 오른쪽에 0이 표시되는 가로 막대 차트](axis-order-values-reversed.png) |
| 범주는 아래에서 위로 진행되고, 값은 왼쪽에서 오른쪽으로 증가합니다. | 계획, 개발, 테스트가 상단부터 하단으로 진행됩니다. 값과 워크시트 행 순서는 변하지 않습니다. | 범주는 정상 순서를 유지하고, 값은 오른쪽에서 왼쪽으로 증가합니다. 범주 축은 오른쪽 0에서 교차합니다. |

## **선 차트의 수직 축 비활성화**

수직 축에 `false`를 전달하여 [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/)를 호출하면 축이 숨겨집니다. 예제에서는 기본 데이터가 있는 선 차트를 만들고 수직 축이 숨겨진 상태로 저장합니다.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);

    $presentation->save("HiddenVerticalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **선 차트의 가로 축 비활성화**

가로 축에 `false`를 전달하여 [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/)를 호출하면 축이 숨겨집니다. 예제에서는 기본 데이터가 있는 선 차트를 만들고 가로 축이 숨겨진 상태로 저장합니다.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);

    $presentation->save("HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **범주 축 변경**

[setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/)을 사용하여 날짜 또는 텍스트 범주 축을 선택합니다. 이 예제는 첫 번째 슬라이드의 첫 번째 도형으로 차트가 포함된 `ExistingChart.pptx`가 필요하며, 범주 셀에 숫자형 Excel 날짜 값이 들어 있습니다. 가로 축을 날짜 축으로 변경합니다. `false`와 함께 [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/)을 호출하고, `1`과 함께 [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/)을 호출하며, `TimeUnitType::Months`와 함께 [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/)을 호출하여 주요 눈금을 한 달 간격으로 배치합니다.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TimeUnitType;

$presentation = new Presentation("ExistingChart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);

    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **범주 축 레이블 간격 제어**

차트에 많은 범주가 있을 때 범주나 데이터 포인트를 제거하지 않고 표시되는 축 레이블 수를 줄입니다. `false`와 함께 [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/)을 호출한 뒤, 원하는 범주 간격을 [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/)에 전달합니다. 정상 순서의 텍스트 범주에서는 첫 번째 범주부터 카운트가 시작됩니다:

| 간격 | 예제에서 표시된 레이블 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

`3` 간격은 세 번째 레이블마다 표시하고, 표시된 레이블 사이에 두 개의 레이블을 숨깁니다. 해당 열은 제거되지 않습니다. 자동 간격은 사용 가능한 공간을 기준으로 간격을 선택하며, 반드시 모든 레이블을 표시하지는 않습니다.

눈금표에도 별도 제어가 있습니다. `false`와 함께 [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/)을 호출하고, [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/)을 사용해 간격을 설정합니다. 예를 들어, `1`은 모든 범주 간격에 눈금표를 유지하고 레이블은 매 세 번째 범주마다만 표시합니다. 눈에 보이는 스타일을 적용하려면 [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/)을 사용하십시오. 두 자동 간격 설정자 중 하나를 `true`로 다시 호출하면 차트가 해당 간격을 자동으로 선택합니다.

다음 자체 포함 예제는 24개의 범주와 하나의 시리즈를 만든 뒤 `CategoryAxisIntervals.pptx`에 세 슬라이드를 저장합니다: 자동 간격, 레이블 간격을 수동으로 지정하면서 눈금표는 독립적으로 유지, 자동 간격 복원. 두 복사본은 원본 차트 데이터를 유지합니다. 입력 프레젠테이션이 필요하지 않습니다. 가로 레이블 텍스트가 밀도를 쉽게 확인할 수 있게 합니다.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TickMarkType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->setLegend(false);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredColumn);
    for ($i = 0; $i < 24; $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, 10 + $i % 6 * 5);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisType(CategoryAxisType::Text);
    $axis->getTextFormat()->getTextBlockFormat()->setRotationAngle(0);
    $axis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $axis->setMajorTickMark(TickMarkType::Outside);
    $axis->setAutomaticTickLabelSpacing(true);
    $axis->setAutomaticTickMarksSpacing(true);

    // 슬라이드 2: 매 세 번째 레이블을 표시하지만 모든 범주에 눈금표를 유지합니다.
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // 슬라이드 3: 차트가 두 간격을 다시 선택하도록 합니다.
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**자동 간격 (슬라이드 1):** 이 렌더링에서는 두 번째마다 범주 레이블이 표시되고 두 줄로 줄바꿈됩니다. 자동 결과는 차트 크기, 글꼴 및 렌더러에 따라 달라질 수 있습니다.

![모든 24열이 보이는 자동 범주 레이블 간격](category-axis-automatic.png)

**수동 간격 (슬라이드 2):** 세 번째 레이블만 한 줄에 표시되고, 눈금표는 모든 범주 간격에 남아 있습니다. 레이블이 없는 24열 모두가 동일한 값으로 보입니다. 슬라이드 3은 위의 자동 모습을 복원합니다.

![모든 24열이 보이는 수동 범주 레이블 간격(간격 3)](category-axis-manual.png)

### **올바른 축 및 간격 선택**

텍스트 범주 축(예: 열, 선, 영역 또는 막대 차트의 범주 축)에서 이 범주 수 간격을 사용합니다. 열 차트에서는 가로 축이 됩니다. 가로 막대 차트에서는 범주 축이 세로이므로 [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/)가 반환하는 축에 적용합니다. 눈금표 간격은 축이 하나인 차트의 시리즈 축에도 적용됩니다.

값 축의 숫자 스케일을 설정하려면 범주 레이블 간격을 사용하지 마십시오. 값 축에서는 [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/)이 값 차이를 지정합니다(예: 주요 단위가 `10`이면 축이 0에서 시작할 때 0, 10, 20 등으로 눈금이 표시됩니다). `3` 간격의 범주 레이블은 데이터 값과 무관하게 범주 위치를 셉니다. 산점도 및 버블 차트는 텍스트 범주 축이 아니라 값 축을 사용합니다. 날짜 축의 경우 [Change a Category Axis](#change-a-category-axis) 섹션에 설명된 대로 시간 기반 주요 단위와 스케일을 사용하십시오.

## **범주 축 값의 날짜 형식 설정**

예제는 기본 차트 데이터를 4개의 연간 값으로 교체합니다. 날짜는 첫 번째 워크시트(인덱스 `0`)에 OLE Automation 일련 번호로 저장되며, 1899년 12월 30일부터의 일수로 계산됩니다. `CategoryAxisType::Date`와 함께 [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/)을 호출하고, `false`와 함께 [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/)을 호출한 뒤, `yyyy`를 [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/)에 전달하여 셀 서식과 무관하게 범주 레이블이 4자리 연도로 표시되게 합니다.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    for ($i = 0; $i < 4; $i++) {
        $date = gmmktime(0, 0, 0, 1, 1, 2015 + $i);
        $serialDate = ($date - $baseDate) / 86400;
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $serialDate);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $i + 1);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");

    $presentation->save("DateAxisFormat.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **차트 축 제목에 회전 각도 설정**

수직 축에 `true`와 함께 [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/)을 호출하고, 제목 텍스트를 제공한 뒤, [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-)을 사용해 제목을 회전시킵니다. 각도는 도 단위이며, 이 예제는 값 축 제목이 90도 회전된 열 차트를 저장합니다.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("Value");
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);

    $presentation->save("RotatedAxisTitle.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **범주 축 또는 값 축에 축 위치 설정**

[setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/)을 사용해 값 축이 범주 축 사이(범주 눈금 사이)이나 범주 눈금에 교차하도록 제어합니다. 이 설정은 범주 축에 적용됩니다. 예제는 열 차트의 가로 범주 축에 `true`를 설정하고 결과를 저장합니다.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);

    $presentation->save("AxisBetweenCategories.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **차트 값 축에 표시 단위 설정**

[setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/)을 사용해 데이터는 변경하지 않고 값 축 레이블을 스케일링합니다. [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/)을 `Millions`로 설정하면 60,000,000 값이 60으로 표시됩니다. 예제는 열 차트를 만들고 수직 축에 백만 단위를 적용합니다.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **로그 스케일 값 축 구성**

양수 값이 여러 자릿수에 걸쳐 차지할 때 로그 값 축이 유용합니다. 예를 들어, 한 서비스가 다섯 기간에 걸쳐 10, 100, 1,000, 10,000, 100,000 요청을 받는다고 가정합니다. 선형 스케일에서는 작은 값들이 0에 가깝게 모여 보입니다. 로그 스케일은 동일한 거리마다 동일한 비율을 나타내므로 상대 성장률을 비교하기 쉽습니다.

값 축에 `true`와 함께 [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/)을 호출하고, [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/)으로 기반을 선택합니다. 이는 기존 값이 표시되는 방식을 변경하지만 데이터 자체를 바꾸거나 로그 추세선을 추가하지는 않습니다. 추세선은 데이터에 맞춘 별도 기능입니다.

### **값 축 및 기반 선택**

선 차트나 열 차트에서는 값 축이 [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/)가 반환합니다. 가로 막대 차트에서는 [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/)가 반환합니다. 산점도와 버블 차트는 두 개의 값 축을 가지므로 X값은 가로 축, Y값은 세로 축 또는 둘 다 선택합니다. 범주 축에는 로그 스케일을 적용하지 마십시오.

기본 로그 기반은 `10`입니다. PPTX 차트에서는 `2`부터 `1000`까지(포함) 기반을 사용할 수 있으며, `2.5`와 같은 소수 기반도 지원합니다. 기반 `10`에서는 10, 100, 1,000, 10,000과 같은 연속적인 거듭 제곱이 동일한 간격으로 표시됩니다.

### **선형 스케일과 로그 스케일 비교**

다음 자체 포함 예제는 첫 번째 슬라이드에 다섯 요청 수를 가진 선 차트를 만들고, 두 번째 슬라이드에 복제해 기반 10 로그 값 축을 활성화합니다. 두 슬라이드 모두 동일한 데이터를 유지합니다.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 30, 40, 660, 200);

    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $values = [10, 100, 1000, 10000, 100000];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Period " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // 첫 번째 슬라이드는 선형으로 유지하고 복사본의 값 축 스케일만 변경합니다.
    $logarithmicSlide = $presentation->getSlides()->addClone($slide);
    $logarithmicChart = $logarithmicSlide->getShapes()->get_Item(0);
    $valueAxis = $logarithmicChart->getAxes()->getVerticalAxis();
    $valueAxis->setLogarithmic(true);
    $valueAxis->setLogBase(10);

    $presentation->save("LogarithmicAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**선형 스케일 (슬라이드 1):** 동일한 수직 거리가 요청 수의 동일한 차이를 나타냅니다. 가장 큰 값이 차트를 압도해 작은 값이 구분하기 어렵습니다.

![선형 값 축에 다섯 요청 수가 표시된 PowerPoint 선 차트](value-axis-linear.png)

**로그 스케일 (슬라이드 2):** 동일한 수직 거리가 동일한 비율을 나타냅니다. 각 기간의 요청 수가 이전보다 10배씩 증가하므로, 기반 10 로그 축에서는 점이 직선으로 상승합니다. 축 레이블은 여전히 원래 요청 수를 표시합니다.

![PowerPoint에 동일한 다섯 요청 수가 표시된 기반 10 로그 값 축](value-axis-logarithmic.png)

### **0 및 음수 값 처리**

로그 스케일은 양수 값만 표시할 수 있습니다. 활성화하기 전에 데이터를 확인하십시오. 0이나 음수 값이 의미가 있다면 선형 스케일을 유지하거나 별도로 표시하십시오. 해당 값을 분석에서 제외하는 것이 적절하면 그 이유를 설명하십시오. 작은 양수로 대체하는 등 조용히 변경하지 마십시오. 로그 축에 수동으로 설정한 최소값이나 최대값도 양수여야 합니다.

## **FAQ**

**축이 다른 축을 교차하는 값을 어떻게 설정합니까(축 교차점)?**

[setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/)을 사용해 교차 동작을 선택합니다. 숫자 교차값을 지정하려면 [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/)을 사용합니다. 이러한 설정을 통해 축 교차점을 적절한 기준선으로 이동할 수 있습니다.

**눈금 레이블을 축에 대해 어떻게 배치합니까?**

[TickerLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/) 중 `Low`, `High`, `NextTo`, `None`을 사용해 [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/)을 호출합니다. 눈금표 자체를 제어하려면 [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) 또는 [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/)을 사용합니다; 이는 레이블 위치와는 별개입니다.