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
- 축 선
- 날짜 형식
- 축 제목
- 축 위치
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "보고서와 시각화를 위해 PowerPoint 프레젠테이션에서 차트 축을 사용자 지정하는 방법을 Java를 통해 PHP용 Aspose.Slides를 사용하여 알아보세요."
---
## **개요**

이 문서에서는 Aspose.Slides for PHP via Java를 사용하여 차트 축을 사용자 지정하는 방법을 설명합니다. 계산된 축 값, 차트 행과 열 전환, 축 표시 여부, 범주 레이블 및 눈금 간격, 날짜 범주 및 서식 지정, 제목 회전, 축 위치 지정, 표시 단위 및 로그 스케일링 등을 다룹니다.

## **차트의 수직 축에서 최대값 가져오기**

[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)을 생성하고 기본 데이터를 사용하여 영역 차트를 추가합니다. 계산된 축 값을 읽기 전에 차트 레이아웃을 최신 상태로 만들기 위해 [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/)을 호출합니다.

축 한계값을 얻으려면 [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/)와 [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/)를 읽고, 눈금 간격을 얻으려면 [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/)와 [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/)을 사용합니다. 날짜 축과 관련된 시간 단위 스케일은 [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/)와 [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/)이 제공합니다. 예제에서는 이러한 값을 로컬 변수에 저장하고 차트를 저장합니다.

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

[switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/)을 사용하여 차트 데이터에서 시리즈와 범주의 역할을 교환합니다. 이전의 각 범주는 시리즈가 되고, 이전의 각 시리즈는 범주가 됩니다. 이는 데이터 그룹화 방식을 변경하지만 수평 및 수직 축을 교환하는 것은 아닙니다. 예제에서는 [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/)을 사용하여 기본 데이터를 `Sheet1!A1:D5`(헤더 행 및 범주 열 포함)에 바인딩한 다음 행과 열을 전환합니다. 네 개의 시리즈와 세 개의 범주가 있는 차트를 저장합니다.

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

## **축의 플롯 순서 반전**

[setPlotOrderReversed](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setplotorderreversed/)을 사용하여 범주 축 또는 값 축의 순서를 반전합니다. 예를 들어 수평 막대 차트에서 프로젝트 단계가 워크시트와 같은 순서(계획, 개발, 테스트)로 위에서 아래로 표시될 수 있습니다. 축을 반전하면 플롯 방향이 바뀌지만 워크북 데이터가 정렬되거나 재배열되지는 않습니다. 반면에 [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/)은 시리즈와 범주의 역할을 교환합니다.

다음 예제는 세 단계와 하나의 시리즈가 있는 수평 막대 차트를 만들고, 일반 순서, 범주 반전, 값 반전의 세 슬라이드를 저장합니다. 각 복사본은 동일한 데이터 세트를 사용하며, 복사본마다 하나의 축만 반전됩니다.

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

    // 슬라이드 2: 첫 번째 범주를 위에 표시합니다.
    $categorySlide = $presentation->getSlides()->addClone($slide);
    $categoryChart = $categorySlide->getShapes()->get_Item(0);
    $categoryChart->getAxes()->getVerticalAxis()->setPlotOrderReversed(true);
    // 수평 값 축을 아래에 유지합니다.
    $categoryChart->getAxes()->getVerticalAxis()->setCrossType(CrossesType::Maximum);

    // 슬라이드 3: 수평 숫자 스케일만 반전합니다.
    $valueSlide = $presentation->getSlides()->addClone($slide);
    $valueChart = $valueSlide->getShapes()->get_Item(0);
    $valueChart->getAxes()->getHorizontalAxis()->setPlotOrderReversed(true);

    $presentation->save("ReversedAxes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

축을 반전하면 수직 축을 플롯의 반대쪽으로 이동시킬 수도 있습니다. [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/)은 다른 축이 현재 구성 중인 축과 교차하는 위치를 제어합니다. 슬라이드 2에서는 반전된 범주 축에 `CrossesType::Maximum`을 지정하면 수평 값 축이 아래쪽에 유지됩니다. 특정 교차점을 지정하려면 [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/)을 사용합니다. 방향을 변경할 때는 특히 차트에 사용자 정의 교차점이 이미 설정되어 있는 경우 교차 설정을 확인하십시오. `setPlotOrderReversed`를 `false`로 호출하면 정상 플롯 방향으로 복원할 수 있으며, 교차 설정은 별도로 유지됩니다.

| 일반 순서 (슬라이드 1) | 범주 반전 (슬라이드 2) | 값 반전 (슬라이드 3) |
| --- | --- | --- |
| ![일반 범주 및 값 축 순서가 적용된 수평 막대 차트](axis-order-normal.png) | ![범주가 위에서 아래로 표시되는 수평 막대 차트](axis-order-categories-reversed.png) | ![값 축이 반전되고 0이 오른쪽에 있는 수평 막대 차트](axis-order-values-reversed.png) |
| 범주는 아래에서 위로 진행하고, 값은 왼쪽에서 오른쪽으로 증가합니다. | 계획, 개발, 테스트가 위에서 아래로 진행합니다. 값과 워크북 행 순서는 변경되지 않습니다. | 범주는 정상 순서를 유지하고, 값은 오른쪽에서 왼쪽으로 증가합니다. 범주 축은 오른쪽 0에서 교차합니다. |

## **선 차트에서 수직 축 비활성화**

수직 축에 `false`를 전달하여 [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/)를 호출하면 축이 숨겨집니다. 예제에서는 기본 데이터가 있는 선 차트를 만들고 수직 축을 숨긴 채 저장합니다.

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

## **선 차트에서 수평 축 비활성화**

수평 축에 `false`를 전달하여 [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/)를 호출하면 축이 숨겨집니다. 예제에서는 기본 데이터가 있는 선 차트를 만들고 수평 축을 숨긴 채 저장합니다.

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

## **차트 격자선 표시 및 숨기기**

축이 표시하는 격자선을 확인하려면 [getShowMajorGridLines](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getshowmajorgridlines/)와 [getShowMinorGridLines](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getshowminorgridlines/)을 호출합니다. 소형 격자선을 표시하려면 [getMinorGridLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getminorgridlinesformat/)을 사용하고 선 채우기를 실선의 눈에 보이는 색으로 설정합니다. 숨기려면 채우기를 [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/)으로 지정합니다. 주요 격자선의 채우기 색을 변경하려면 [getMajorGridLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getmajorgridlinesformat/)을 같은 방법으로 사용하십시오. 채우기를 변경해도 축 표시와 눈금은 유지됩니다.

이 클러스터형 세로 막대 차트의 수직 축은 처음에 주요 격자선만 표시합니다. 예제에서는 소형 격자선을 진한 주황색으로 표시한 후 다시 숨기고 프레젠테이션을 저장합니다. 각 단계에서 격자선 표시 상태를 출력합니다.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 30, 660, 230);
    $axis = $chart->getAxes()->getVerticalAxis();
    printf("Initial: major=%s, minor=%s\n", java_values($axis->getShowMajorGridLines()) ? "true" : "false", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $minorFill = $axis->getMinorGridLinesFormat()->getLine()->getFillFormat();
    $minorFill->setFillType(FillType::Solid);
    $darkOrange = new Java("java.awt.Color", 255, 140, 0);
    $minorFill->getSolidFillColor()->setColor($darkOrange);
    printf("Enabled: minor=%s\n", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $minorFill->setFillType(FillType::NoFill);
    printf("Hidden: major=%s, minor=%s\n", java_values($axis->getShowMajorGridLines()) ? "true" : "false", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $presentation->save("ChartGridlines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| 소형 격자선 표시 | 소형 격자선 숨김 |
| --- | --- |
| ![수직 축의 주요 격자선 사이에 주황색 소형 격자선이 표시된 모습](minor-gridlines-enabled.png) | ![주요 격자선만 보이는 동일한 세로 막대 차트](minor-gridlines-hidden.png) |

## **범주 축 변경**

[setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/)을 사용하여 날짜 축이나 텍스트 축을 선택합니다. 이 예제에서는 첫 번째 슬라이드의 첫 번째 도형으로 차트가 포함된 `ExistingChart.pptx`가 필요하며, 범주 셀에 숫자형 Excel 날짜 값이 들어 있습니다. 수평 축을 날짜 축으로 변경합니다. [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/)를 `false`, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/)를 `1`, [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/)를 `TimeUnitType::Months`로 설정하면 주요 눈금이 한 달 간격으로 배치됩니다.

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

### **데이터에서 범주 축 유형 자동 결정**

범주를 채운 후 [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistypeautomatically/)를 호출하고, [getCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getcategoryaxistype/)을 읽어 선택된 유형을 확인합니다. 동일한 차트에 텍스트 라벨이나 숫자형 날짜 값이 들어올 수 있는 경우 유용합니다. 메서드는 호출 시 유형을 결정하며, 이후 데이터 변경에 대해 지속적인 재평가 모드를 활성화하지 않습니다. 범주를 교체한 뒤 다시 호출하십시오.

다음 예제는 텍스트 범주 차트를 만들고 선택된 유형이 `CategoryAxisType::Text`일 때 `true`를 출력합니다. 그런 다음 범주 셀 값을 날짜로 교체하고 메서드를 다시 호출하여 선택된 유형이 `CategoryAxisType::Date`일 때 `true`를 출력합니다. 날짜는 숫자형 OLE Automation 값으로 저장되며, 1899년 12월 30일부터 경과된 일수로 계산됩니다. [setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/)은 이러한 값이 표시되는 방식을 제어하지만 텍스트를 숫자형 날짜로 변환하지는 않습니다. 범주 셀에 대한 자세한 내용은 [Chart Workbook](/slides/ko/php-java/chart-workbook/)를 참조하십시오.

입력이 텍스트 범주 또는 숫자형 날짜인 것이 확실할 경우 자동 결정을 사용하십시오. 일반적인 숫자 라벨, 혼합 범주 또는 빈 데이터인 경우 의도한 의미에 맞게 [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/)을 명시적으로 호출하십시오. 숫자 값만으로는 해당 범주가 날짜를 나타낸다고 판단할 수 없습니다.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $seriesName = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesName, $chart->getType());
    $labels = ["First", "Second", "Third"];

    for ($i = 0; $i < count($labels); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $labels[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, ($i + 1) * 10);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisTypeAutomatically();
    echo (java_values($axis->getCategoryAxisType()) == CategoryAxisType::Text ? "true" : "false") . PHP_EOL;

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);
    $dates = [gmmktime(0, 0, 0, 1, 1, 2026), gmmktime(0, 0, 0, 1, 2, 2026), gmmktime(0, 0, 0, 2, 1, 2026)];

    for ($i = 0; $i < count($dates); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0);
        $categoryCell->setValue((float)(($dates[$i] - $baseDate) / 86400));
        $categoryCell->setCustomNumberFormat("yyyy-mm-dd");
    }

    $axis->setCategoryAxisTypeAutomatically();
    echo (java_values($axis->getCategoryAxisType()) == CategoryAxisType::Date ? "true" : "false") . PHP_EOL;

    $presentation->save("AutomaticCategoryAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **범주 축 레이블 간격 제어**

차트에 범주가 많을 때 범주를 제거하거나 데이터 포인트를 삭제하지 않고 표시되는 축 레이블 수를 줄일 수 있습니다. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/)을 `false`로 설정한 다음 원하는 범주 간격을 [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/)에 전달합니다. 정상 순서의 텍스트 범주에서는 첫 번째 범주부터 카운트됩니다.

| 간격 | 예제에 표시된 레이블 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

`3` 간격은 세 번째 레이블마다 하나씩 표시하고, 표시된 레이블 사이에 두 개의 레이블을 숨깁니다. 해당 열이 제거되는 것은 아닙니다. 자동 간격은 사용 가능한 공간을 기준으로 간격을 선택하며, 반드시 모든 레이블을 표시하지는 않습니다.

눈금 표시에도 별도의 제어가 있습니다. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/)을 `false`로 하고 [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/)으로 간격을 설정하십시오. 예를 들어 `1`은 레이블이 매 세 번째 범주에만 표시되더라도 모든 범주 간격에 눈금 표시를 유지합니다. [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/)를 사용하여 눈금 스타일을 눈에 보이게 지정할 수 있습니다. 자동 간격 설정자를 `true`로 다시 호출하면 차트가 자동 간격을 다시 선택합니다.

다음 자체 포함 예제는 24개의 범주와 하나의 시리즈를 만든 뒤 `CategoryAxisIntervals.pptx`에 세 슬라이드를 저장합니다: 자동 간격, 레이블 간격을 수동으로 지정하고 눈금은 독립적으로 유지, 자동 간격 복원. 두 복사본은 원본 차트 데이터를 그대로 유지합니다. 입력 프레젠테이션이 필요하지 않습니다. 수평 레이블 텍스트가 밀도를 쉽게 확인할 수 있게 합니다.

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

    // 슬라이드 2: 모든 세 번째 레이블을 표시하되, 각 범주마다 눈금 표시를 유지합니다.
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

**자동 간격 (슬라이드 1):** 이 렌더링에서는 두 번째마다 레이블이 표시되고 두 줄로 감싸집니다. 자동 결과는 차트 크기, 글꼴 및 렌더러에 따라 달라질 수 있습니다.

![모든 24열이 보이는 자동 범주 레이블 간격](category-axis-automatic.png)

**수동 간격 (슬라이드 2):** 세 번째 레이블마다 한 줄에 표시되고, 눈금은 모든 범주 간격에 유지됩니다. 레이블이 없는 24열 전체가 동일한 값으로 보입니다. 슬라이드 3은 위의 자동 모양을 복원합니다.

![모든 24열이 보이는 수동 범주 레이블 간격 (3 간격)](category-axis-manual.png)

### **올바른 축 및 간격 선택**

텍스트 범주 축(예: 열, 선, 영역 또는 막대 차트의 범주 축)에서 이 범주 수 간격을 사용하십시오. 열 차트에서는 수평 축이며, 수평 막대 차트에서는 범주 축이 수직이므로 [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/)가 반환하는 축에 적용합니다. 눈금 간격은 시리즈 축이 있는 차트에도 적용됩니다.

값 축의 숫자 스케일을 설정하려면 범주 레이블 간격을 사용하지 마십시오. 값 축에서 [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/)은 값 차이를 지정합니다(예: `10`은 0, 10, 20 …). `3` 간격의 범주 레이블은 데이터 값과 무관하게 범주 위치를 셉니다. 산점도와 버블 차트는 텍스트 범주 축이 아니라 값 축을 사용합니다. 날짜 축의 경우 [Change a Category Axis](#change-a-category-axis) 섹션에 설명된 대로 시간 기반 주요 단위와 스케일을 사용하십시오.

## **범주 축 값에 대한 날짜 형식 설정**

예제에서는 기본 차트 데이터를 연간 값 네 개로 교체합니다. 날짜는 첫 번째 워크시트(인덱스 `0`)에 OLE Automation 일련 번호로 저장되며, 1899년 12월 30일부터 경과된 일수로 계산됩니다. [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/)을 `CategoryAxisType::Date`와 함께 호출하고, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/)를 `false`로 설정한 뒤 `yyyy`를 [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/)에 전달하면 셀 서식과 무관하게 범주 레이블에 4자리 연도가 표시됩니다.

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

## **차트 축 제목 회전 각도 설정**

수직 축에 `true`를 전달하여 [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/)를 호출하고 제목 텍스트를 제공한 뒤, [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-)를 사용해 제목을 회전합니다. 각도는 도 단위이며, 이 예제는 값 축 제목을 90도 회전한 열 차트를 저장합니다.

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

## **범주 축 또는 값 축에 대한 축 위치 설정**

[setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/)을 사용하여 값 축이 범주 축 사이의 틈에 교차할지, 범주 눈금에 교차할지를 제어합니다. 이 설정은 범주 축에 적용됩니다. 예제에서는 열 차트의 수평 범주 축에 `true`를 설정하고 결과를 저장합니다.

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

## **값 축에 표시 단위 설정**

[setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/)을 사용하면 데이터 자체를 변경하지 않고 값 축 레이블을 스케일링할 수 있습니다. [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/)을 `Millions`로 설정하면 60,000,000이 60으로 표시됩니다. 예제에서는 열 차트를 만든 뒤 수직 축에 백만 단위를 적용합니다.

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

## **로그형 값 축 구성**

양수 값이 여러 차수에 걸쳐 있는 경우 로그형 값 축이 유용합니다. 예를 들어 서비스가 5기간 동안 각각 10, 100, 1 000, 10 000, 100 000 요청을 받는다고 가정합니다. 선형 스케일에서는 작은 값이 0 근처에 몰려 보입니다. 로그형 스케일은 같은 거리마다 같은 비율을 나타내므로 상대 성장률을 비교하기 쉬워집니다.

값 축에 `true`를 전달하여 [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/)을 호출하고, [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/)로 기준을 선택합니다. 이는 기존 값 표시 방식을 변경하지만 데이터 자체를 바꾸거나 로그형 추세선을 추가하지는 않습니다. 추세선은 별도의 기능입니다.

### **값 축 및 기준 선택**

선 차트나 열 차트에서는 값 축을 [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/)로 얻습니다. 수평 막대 차트에서는 [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/)를 사용합니다. 산점도와 버블 차트는 두 개의 값 축을 가지므로 X 값에는 수평 축, Y 값에는 수직 축, 또는 두 축 모두를 선택합니다. 범주 축에는 로그형 스케일을 적용하지 마십시오.

기본 로그 기준은 `10`입니다. PPTX 차트에서는 `2`부터 `1000`까지의 정수를 사용할 수 있으며, `2.5`와 같은 소수점 기준도 지원됩니다. 기준이 `10`이면 10, 100, 1 000, 10 000 등 연속적인 거듭 제곱이 동일한 간격으로 배치됩니다.

### **선형 스케일과 로그형 스케일 비교**

다음 자체 포함 예제는 첫 번째 슬라이드에 5개의 요청 수를 가진 선 차트를 만든 뒤, 해당 슬라이드를 복제하고 두 번째 슬라이드에서 기준 10 로그형 값 축을 활성화합니다. 두 슬라이드 모두 동일한 데이터를 유지합니다.

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

**선형 스케일 (슬라이드 1):** 동일한 수직 거리는 요청 수 차이를 나타냅니다. 가장 큰 값이 차트를 지배해 작은 값이 구별하기 어렵습니다.

![선형 값 축에 표시된 5개의 요청 수가 있는 PowerPoint 선 차트](value-axis-linear.png)

**로그형 스케일 (슬라이드 2):** 동일한 수직 거리는 같은 비율을 나타냅니다. 각 기간의 요청 수가 이전 기간의 10배이므로, 기준 10 스케일에서 점들이 직선으로 상승합니다. 축 레이블은 여전히 원래 요청 수를 표시합니다.

![기준 10 로그형 값 축에 표시된 동일한 5개의 요청 수가 있는 PowerPoint 차트](value-axis-logarithmic.png)

### **0 및 음수 값 처리**

로그형 스케일은 양수 값만 표시할 수 있습니다. 사용 전에 데이터를 확인하십시오. 0이나 음수 값이 의미가 있다면 선형 스케일을 유지하거나 별도로 표시하십시오. 분석에 필요하지 않다면 해당 값을 제외하고 이유를 설명해야 합니다. 작은 양수로 조용히 대체하면 데이터 의미가 바뀝니다. 로그형 축에 수동으로 설정한 최소값이나 최대값도 양수여야 합니다.

## **FAQ**

**한 축이 다른 축을 교차하는 값을 어떻게 설정합니까(축 교차점)?**

[setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/)을 사용해 교차 동작을 선택합니다. 숫자 교차 값을 지정하려면 [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/)을 사용합니다. 이러한 설정을 통해 축 교차점을 적절한 기준선으로 이동할 수 있습니다.

**눈금 레이블을 축에 상대적으로 어떻게 배치합니까?**

[setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/)을 사용하고, [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/) 중 `Low`, `High`, `NextTo` 또는 `None`을 지정합니다. 눈금 자체를 제어하려면 [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/)이나 [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/)을 사용하십시오; 이들은 레이블 위치와 별개입니다.