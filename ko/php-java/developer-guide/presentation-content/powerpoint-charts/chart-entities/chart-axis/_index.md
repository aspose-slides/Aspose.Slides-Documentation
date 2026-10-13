---
title: PHP를 사용한 프레젠테이션에서 차트 축 맞춤 설정
linktitle: 차트 축
type: docs
url: /ko/php-java/chart-axis/
keywords:
- 차트 축
- 세로 축
- 가로 축
- 축 맞춤 설정
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
description: "보고서와 시각화를 위한 PowerPoint 프레젠테이션에서 차트 축을 맞춤 설정하기 위해 Java를 통해 PHP용 Aspose.Slides를 사용하는 방법을 알아보세요."
---
## **개요**

이 문서는 Aspose.Slides for PHP via Java를 사용하여 차트 축을 사용자 지정하는 방법을 설명합니다. 계산된 축 값, 차트 행과 열 전환, 축 표시 여부, 카테고리 레이블 및 눈금 간격, 날짜 카테고리 및 서식, 제목 회전, 축 위치 지정, 표시 단위 및 로그 스케일링을 다룹니다.

## **차트에서 세로 축의 최대값 가져오기**

[프레젠테이션](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)을 만들고 기본 데이터가 있는 영역 차트를 추가합니다. 차트 레이아웃이 최신 상태가 되도록 계산된 축 값을 읽기 전에 [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/)을 호출합니다.

축 한계를 얻으려면 [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/)와 [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/)을 읽고, 눈금 간격을 위해 [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/)와 [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/)을 읽습니다. 날짜 축과 관련된 시간 단위 스케일은 [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/)와 [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/)이 제공합니다. 예제는 이러한 값을 로컬 변수에 저장하고 차트를 저장합니다.

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

차트 데이터에서 시리즈와 카테고리의 역할을 교환하려면 [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/)을 사용합니다. 이전 카테고리는 시리즈가 되고, 이전 시리즈는 카테고리가 됩니다. 이는 데이터 그룹화 방식을 변경하지만 가로 및 세로 축을 교환하지는 않습니다. 예제는 [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/)을 사용해 기본 데이터를 `Sheet1!A1:D5`(헤더 행 및 카테고리 열 포함)에 바인딩한 다음 행과 열을 전환합니다. 4개의 시리즈와 3개의 카테고리가 있는 차트를 저장합니다.

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

## **선 차트에서 세로 축 비활성화**

세로 축에 대해 `false`와 함께 [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/)를 호출해 숨깁니다. 예제는 기본 데이터가 있는 선 차트를 만들고 세로 축이 숨겨진 상태로 저장합니다.

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

## **선 차트에서 가로 축 비활성화**

가로 축에 대해 `false`와 함께 [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/)를 호출해 숨깁니다. 예제는 기본 데이터가 있는 선 차트를 만들고 가로 축이 숨겨진 상태로 저장합니다.

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

## **카테고리 축 변경**

[setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/)을 사용해 날짜 축 또는 텍스트 카테고리 축을 선택합니다. 이 예제는 첫 번째 슬라이드의 첫 번째 도형으로 차트가 있고, 카테고리 셀이 숫자형 Excel 날짜 값인 `ExistingChart.pptx`를 필요로 합니다. 가로 축을 날짜 축으로 변경합니다. `false`와 함께 [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/)을 호출하고, `1`과 함께 [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/)을 호출하고, `TimeUnitType::Months`와 함께 [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/)을 호출하면 주요 눈금이 한 달 간격으로 배치됩니다.

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

## **카테고리 축 레이블 간격 제어**

차트에 카테고리가 많을 경우 카테고리나 데이터 포인트를 제거하지 않고 표시되는 축 레이블 수를 줄일 수 있습니다. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/)에 `false`를 전달한 뒤, 원하는 카테고리 간격을 [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/)에 전달합니다. 텍스트 카테고리가 정상 순서에 있을 때는 첫 번째 카테고리부터 카운트가 시작됩니다.

| 간격 | 예제에 표시된 레이블 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

`3` 간격은 매 세 번째 레이블만 표시하고, 표시된 레이블 사이에 두 개의 레이블을 숨깁니다. 이는 해당 열을 제거하지 않습니다. 자동 간격은 사용 가능한 공간을 기반으로 간격을 선택하므로 반드시 모든 레이블을 표시하지는 않을 수 있습니다.

눈금선은 별도로 제어합니다. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/)에 `false`를 전달하고, [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/)을 사용해 간격을 설정합니다. 예를 들어 `1`은 각 카테고리 간격마다 눈금선을 유지하고 레이블은 매 세 번째 카테고리마다만 표시합니다. 눈에 보이는 스타일을 지정하려면 [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/)를 사용합니다. 자동 간격 설정자를 다시 `true`로 호출하면 차트가 해당 간격을 다시 선택합니다.

다음 자체 포함 예제는 24개의 카테고리와 하나의 시리즈를 만든 뒤 `CategoryAxisIntervals.pptx`에 세 슬라이드를 저장합니다: 자동 간격, 독립 눈금이 있는 수동 레이블 간격, 자동 간격 복원. 두 복사본은 원본 차트 데이터를 유지합니다. 입력 프레젠테이션은 필요하지 않습니다. 가로 레이블 텍스트가 밀도를 쉽게 확인할 수 있게 합니다.

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

    // 슬라이드 2: 매 세 번째 레이블을 표시하지만 각 카테고리마다 눈금선을 유지합니다.
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

**자동 간격 (슬라이드 1):** 이 렌더링에서는 두 번째 카테고리 레이블마다 표시되며 두 줄로 줄 바꿈됩니다. 자동 결과는 차트 크기, 글꼴 및 렌더러에 따라 달라질 수 있습니다.

![모든 24열이 표시된 자동 카테고리 레이블 간격](category-axis-automatic.png)

**수동 간격 (슬라이드 2):** 세 번째 레이블만 한 줄에 표시되고, 눈금선은 각 카테고리 간격마다 유지됩니다. 레이블이 없는 열을 포함한 모든 24열이 동일한 값으로 표시됩니다. 슬라이드 3은 위에 표시된 자동 모양을 복원합니다.

![모든 24열이 표시된 세 번째 간격 수동 카테고리 레이블](category-axis-manual.png)

### **올바른 축 및 간격 선택**

텍스트 카테고리 축(예: 열, 선, 영역 또는 막대 차트의 카테고리 축)에서 이 카테고리 수 간격을 사용합니다. 열 차트에서는 가로 축이 됩니다. 가로 막대 차트에서는 카테고리 축이 세로이므로 [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/)가 반환하는 축에 적용합니다. 눈금선 간격은 하나의 축을 가진 차트의 시리즈 축에도 적용됩니다.

카테고리 레이블 간격을 값 축의 숫자 스케일로 사용하지 마세요. 값 축에서는 [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/)이 값 차이를 지정합니다. 예를 들어 주요 단위가 `10`이면 축이 0에서 시작할 때 0, 10, 20 등으로 눈금이 생성됩니다. `3` 간격의 카테고리 레이블은 데이터 값에 관계없이 카테고리 위치를 셉니다. 산점도 및 버블 차트는 텍스트 카테고리 축이 아닌 값 축을 사용합니다. 날짜 축의 경우 [Change a Category Axis](#change-a-category-axis)에서 설명한 시간 기반 주요 단위와 스케일을 사용하세요.

## **카테고리 축 값에 대한 날짜 형식 설정**

예제는 기본 차트 데이터를 네 개의 연간 값으로 교체합니다. 날짜는 첫 번째 워크시트(인덱스 `0`)에 OLE Automation 일련 번호로 저장되며, 1899년 12월 30일부터 일수로 계산됩니다. [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/)에 `CategoryAxisType::Date`를 사용하고, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/)에 `false`를 전달한 뒤, `yyyy`를 [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/)에 전달하면 셀 서식과 무관하게 카테고리 레이블이 4자리 연도로 표시됩니다.

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

세로 축에 대해 `true`와 함께 [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/)를 호출하고 제목 텍스트를 제공한 뒤, [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-)를 사용해 제목을 회전합니다. 각도는 도 단위이며, 이 예제는 값 축 제목이 90도 회전된 열 차트를 저장합니다.

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

## **카테고리 또는 값 축의 축 위치 설정**

[setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/)를 사용해 값 축이 카테고리 축을 카테고리 사이에 교차시킬지, 카테고리 눈금에 교차시킬지를 제어합니다. 이 설정은 카테고리 축에 적용됩니다. 예제는 열 차트의 가로 카테고리 축에 `true`를 설정하고 결과를 저장합니다.

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

[setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/)을 사용해 기본 데이터를 변경하지 않고 값 축 레이블을 스케일링합니다. [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/)을 `Millions`로 설정하면 60,000,000값이 60으로 표시됩니다. 예제는 열 차트를 만들고 세로 축에 백만 표시 단위를 적용합니다.

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

## **로그값 축 구성**

양의 값이 여러 자주에 걸쳐 크게 차이날 때 로그값 축이 유용합니다. 예를 들어, 서비스가 5기간에 걸쳐 10, 100, 1,000, 10,000, 100,000 요청을 받는다고 가정합니다. 선형 스케일에서는 작은 값이 0에 가깝게 모여 보입니다. 로그 스케일은 동일한 거리로 같은 비율을 나타내어 상대적 성장을 비교하기 쉽게 합니다.

값 축에 `true`와 함께 [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/)를 호출하고, [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/)를 사용해 기준을 선택합니다. 이는 기존 값을 표시 방식만 변경하며 데이터나 로그 추세선을 추가하지 않습니다. 추세선은 데이터에 맞춘 별도 기능입니다.

### **값 축 및 기준 선택**

선 또는 열 차트에서는 값 축이 [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/)가 반환합니다. 가로 막대 차트에서는 [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/)가 반환합니다. 산점도 및 버블 차트는 두 개의 값 축을 가지므로 X값에 가로 축, Y값에 세로 축을 선택하거나 둘 모두 사용할 수 있습니다. 카테고리 축에 로그 스케일을 적용하지 마세요.

기본 로그 기준은 `10`입니다. PPTX 차트에서는 `2`에서 `1000` 사이의 기준을 사용할 수 있으며, `2.5`와 같은 소수 기준도 지원됩니다. 기준이 `10`이면 10, 100, 1,000, 10,000 등의 연속적인 거듭제곱이 동일한 간격으로 배치됩니다.

### **선형 스케일과 로그 스케일 비교**

다음 자체 포함 예제는 첫 번째 슬라이드에 다섯 개 요청 수를 가진 선 차트를 만든 뒤 해당 슬라이드를 복제하고 두 번째 슬라이드에서 기준 10 로그값 축을 활성화합니다. 두 슬라이드 모두 동일한 데이터를 유지합니다.

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

**선형 스케일 (슬라이드 1):** 동일한 수직 거리가 요청 수의 동일한 차이를 나타냅니다. 가장 큰 값이 차트를 지배하여 작은 값을 구별하기 어렵습니다.

![선형 값 축에 다섯 개 요청 수가 표시된 파워포인트 선 차트](value-axis-linear.png)

**로그 스케일 (슬라이드 2):** 동일한 수직 거리가 동일한 비율을 나타냅니다. 각 기간의 요청 수가 이전보다 10배씩 증가하므로 점이 기준 10 스케일에서 직선 상승 형태로 나타납니다. 축 레이블은 여전히 원래 요청 수를 표시합니다.

![기준 10 로그값 축에 다섯 개 요청 수가 표시된 파워포인트 차트](value-axis-logarithmic.png)

### **0 및 음수 값 처리**

로그 스케일은 엄격히 양수 값만 표시할 수 있습니다. 사용 전에 데이터를 확인하세요. 0 또는 음수 값이 의미가 있다면 선형 스케일을 유지하거나 별도로 표시합니다. 해당 값을 제외하는 것이 분석에 적합하다면 그 이유를 설명하십시오. 작은 양수로 교체하면 데이터 의미가 바뀌므로 조용히 변경하지 마세요. 로그 축에 수동으로 지정하는 최소값이나 최대값도 양수이어야 합니다.

## **FAQ**

**축이 서로 교차하는 위치(축 교차점)를 어떻게 설정합니까?**

[setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/)을 사용해 교차 동작을 선택합니다. 숫자 교차 값을 지정하려면 [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/)을 사용합니다. 이러한 설정을 통해 축 교차점을 적절한 기준선으로 이동할 수 있습니다.

**눈금 레이블을 축에 상대적으로 어떻게 배치합니까?**

[TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/) 중 `Low`, `High`, `NextTo`, `None`을 사용해 [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/)을 호출합니다. 눈금선 자체를 제어하려면 [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) 또는 [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/)을 사용합니다; 이는 레이블 위치와 별개입니다.