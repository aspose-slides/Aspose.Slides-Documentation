---
title: PHP에서 프레젠테이션의 차트 데이터 시리즈 관리
linktitle: 데이터 시리즈
type: docs
url: /ko/php-java/chart-series/
keywords:
- 차트 시리즈
- 시리즈 겹침
- 시리즈 색상
- 시리즈 이름
- 데이터 포인트
- 워크북 셀
- 시리즈 간격
- 음수 값
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "PHP를 사용하여 프레젠테이션에서 차트 시리즈, 데이터 포인트, 워크북 셀, 서식 지정, 겹침, 간격 너비 및 음수 값을 관리하는 방법을 학습합니다."
---
## **Overview**

차트는 플롯된 데이터를 차트 데이터 워크북에 저장합니다. [ChartSeries](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/)는 관련 값 집합 하나를 나타내며, 시리즈의 각 [ChartDataPoint](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapoint/)은 하나 이상의 워크북 셀을 참조합니다. [ChartCategory](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartcategory/) 객체는 시리즈가 공유하는 레이블 또는 그룹화 값을 제공합니다. 따라서 시리즈 이름, 카테고리 및 포인트 값은 표시 텍스트로만 저장되는 것이 아니라 [ChartDataCell](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatacell/) 객체와 연결됩니다.

일반적인 카테고리 차트의 경우, 기본 워크북은 행 0을 시리즈 이름에, 열 0을 카테고리 이름에 사용하고, 나머지 셀은 시리즈 값에 사용합니다. [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdataworkbook/#getCell)에 전달되는 워크시트, 행 및 열 인덱스는 0부터 시작합니다. 이 레이아웃은 기본 데이터를 사용해 차트를 만들 때 유용하지만, 모든 기존 차트가 이를 사용한다고 가정하지 마십시오. 로드된 프레젠테이션에서는 워크북 값을 변경하기 전에 시리즈, 카테고리 및 데이터 포인트가 참조하는 셀을 확인하십시오.

차트 설정은 세 가지 범위로 나뉩니다:

- 시리즈 수준 설정은 [ChartSeries.getFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/#getFormat)와 같이 하나의 시리즈에 속한 모든 포인트에 대한 기본 모양을 제공합니다.
- 데이터 포인트 설정은 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapoint/#getFormat)와 같이 한 포인트에 대해 시리즈 모양을 재정의합니다.
- 그룹 설정은 동일한 [ChartSeriesGroup](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseriesgroup/)에 속하는 호환 시리즈에 적용됩니다. 겹침(overlap)이나 간격(gap width)과 같은 옵션을 설정해야 할 경우 [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/#getParentSeriesGroup)를 통해 그룹에 접근하십시오.

명시적인 포인트 또는 시리즈 채우기가 설정되지 않은 경우, 차트 스타일과 테마가 자동 모양을 결정합니다. 시리즈와 포인트 서식이 모두 존재하면 해당 포인트에 대해서는 포인트 서식이 우선합니다.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Set the Chart Series Overlap**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/#getOverlap)는 2D 차트에서 막대 또는 열이 -100%에서 100%까지 겹치는 정도를 보고합니다. 이는 상위 시리즈 그룹에 대한 설정을 읽기 전용으로 투영한 값입니다. 해당 그룹에 포함된 모든 호환 시리즈를 업데이트하려면 [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseriesgroup/#setOverlap)를 사용하십시오. 이 옵션은 그룹화된 막대 또는 열을 표시하는 차트 유형에만 적용되며, 복합 차트에서 관련 없는 시리즈 그룹에는 영향을 주지 않습니다.

다음 예제는 첫 번째 시리즈가 포함된 그룹의 겹침을 설정합니다:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // 새 차트에는 샘플 시리즈, 카테고리 및 값이 포함됩니다.
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setOverlap($overlapPercent);

    $presentation->save("series_overlap.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

결과:

![The series overlap](series_overlap.png)

## **Change the Series Fill Color**

전체 시리즈에 대한 기본 채우기를 설정하려면 [ChartSeries.getFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/#getFormat)를 사용하십시오. 포인트에 명시적인 채우기가 이미 있는 경우, 해당 포인트의 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapoint/#getFormat) 설정이 시리즈 채우기를 재정의합니다.

다음 예제는 첫 번째 시리즈에 단색 파란색 채우기를 적용합니다:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$blueColor = java("java.awt.Color")->BLUE;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($blueColor);

    $presentation->save("series_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

결과:

![The color of the series](series_color.png)

## **Change the Series Name**

시리즈 이름은 차트 데이터 워크북에 저장되며 일반적으로 범례에 표시됩니다. 클러스터드 컬럼 차트에 대한 기본 워크북에서는 셀 B1이 행 0, 열 1에 해당하며 첫 번째 시리즈의 이름을 포함합니다. 아래 예제의 명명된 변수들은 해당 구조를 명시적으로 보여줍니다:

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$seriesNameRowIndex = 0;
$firstSeriesColumnIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $seriesNameCell = $workbook->getCell($worksheetIndex, $seriesNameRowIndex, $firstSeriesColumnIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

또한 [ChartSeries.getName](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/#getName)으로 이미 참조된 셀을 업데이트할 수도 있습니다. 이 방법은 기존 차트에서 특정 행과 열을 가정하지 않으므로 안전합니다:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$firstNameCellIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $seriesNameCell = $series->getName()->getAsCells()->get_Item($firstNameCellIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

결과:

![The series name](series_name.png)

## **Get the Automatic Series Fill Color**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor)는 시리즈 인덱스와 차트 스타일을 기반으로 계산된 색상을 반환합니다. 이는 시리즈 채우기가 명시적으로 정의되지 않았을 때 사용되는 색상입니다. 이 메서드를 호출하면 계산된 색상을 읽어올 뿐, 새로운 채우기를 할당하지는 않습니다.

다음 예제는 각 기본 시리즈의 자동 색상을 출력합니다:

```php
$firstSlideIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $seriesCount = java_values($chart->getChartData()->getSeries()->size());
    for ($seriesIndex = 0; $seriesIndex < $seriesCount; $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $automaticColor = $series->getAutomaticSeriesColor();
        $red = java_values($automaticColor->getRed());
        $green = java_values($automaticColor->getGreen());
        $blue = java_values($automaticColor->getBlue());
        echo "Series " . $seriesIndex . ": java.awt.Color[r=" . $red . ",g=" . $green . ",b=" . $blue . "]" . PHP_EOL;
    }
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

기본 차트 스타일에 대한 예시 출력:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

정확한 색상은 차트 스타일과 테마에 따라 달라집니다.

## **Set Invert Fill Color for a Chart Series**

막대, 열 및 버블 시리즈의 경우, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/#setInvertIfNegative)를 사용하면 음수 값을 다른 채우기로 표시할 수 있습니다. 일반 시리즈 채우기를 단색으로 설정하고, 반전 옵션을 활성화한 뒤, [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor)으로 음수 값을 위한 색상을 지정하십시오. 워크북의 음수 값 자체는 변경되지 않으며, 표시 색상만 변경됩니다.

다음 예제는 기본 차트 데이터를 하나의 시리즈로 교체합니다. 워크시트 행 0은 시리즈 이름을, 열 0은 카테고리 이름을, 열 1은 값을 포함합니다:

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$headerRowIndex = 0;
$categoryColumnIndex = 0;
$firstSeriesColumnIndex = 1;
$firstDataRowIndex = 1;

$categoryNames = ["Category 1", "Category 2", "Category 3"];
$seriesValues = [-20, 50, -30];
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, $headerRowIndex, $firstSeriesColumnIndex, "Series 1");
    $chartType = $chart->getType();
    $series = $chartData->getSeries()->add($seriesNameCell, $chartType);

    $categoryCount = count($categoryNames);
    for ($categoryIndex = 0; $categoryIndex < $categoryCount; $categoryIndex++) {
        $dataRowIndex = $firstDataRowIndex + $categoryIndex;
        $categoryName = $categoryNames[$categoryIndex];
        $seriesValue = $seriesValues[$categoryIndex];

        $categoryCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $categoryColumnIndex, $categoryName);
        $chartData->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $firstSeriesColumnIndex, $seriesValue);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->setInvertIfNegative(true);
    $series->getInvertedSolidFillColor()->setColor($redColor);

    $presentation->save("inverted_solid_fill_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

결과:

![The inverted solid fill color](inverted_solid_fill_color.png)

한 포인트에 대해서만 반전을 활성화하려면 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative)를 사용하십시오. 다음 예제에서는 시리즈에 대한 반전을 비활성화하고 선택된 포인트에만 활성화합니다. 포인트에는 효과가 보이도록 음수 값도 할당됩니다:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 2;
$negativeValue = -30;
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->getInvertedSolidFillColor()->setColor($redColor);
    $series->setInvertIfNegative(false);

    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue($negativeValue);
    $dataPoint->setInvertIfNegative(true);

    $presentation->save("data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Clear a Specific Data Point Value**

다른 포인트를 제거하지 않고 하나의 포인트를 비우려면 해당 셀을 `null`로 설정하십시오. 컬럼 차트의 경우, 플롯된 값은 [ChartDataPoint.getValue](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapoint/#getValue)로 확인할 수 있습니다. 데이터 포인트는 동일한 카테고리 위치에 남아 있지만, 차트는 해당 값을 차트의 빈 값 설정에 따라 빈 값으로 처리합니다.

다음 예제는 첫 번째 시리즈의 두 번째 포인트만 비웁니다:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue(null);

    $presentation->save("clear_data_point_value.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

산점도 차트는 X와 Y 셀을 별도로 사용하고, 버블 차트는 크기 셀도 사용합니다. 삭제하려는 값에 해당하는 셀만 비우십시오. 다른 포인트를 유지하고 싶을 때는 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapointcollection/#clear)를 호출하지 마십시오. 해당 메서드는 컬렉션의 모든 데이터 포인트를 제거합니다.

## **Control the Display of Empty Cells**

값이 들어있는 숨겨진 셀은 빈 셀과 별개의 경우입니다. 숨겨진 워크시트 행 및 열의 데이터를 포함하거나 제외하려면 [Include Data from Hidden Rows and Columns](/slides/ko/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns)를 참고하십시오.

빈 워크북 셀은 데이터 누락을 나타내고, `0`이 들어있는 셀은 알려진 숫자 값을 나타냅니다. 셀을 비우려면 [ChartDataCell::setValue](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatacell/#setValue)에 `null`을 전달하십시오. 숫자 0은 빈 셀 설정에 관계없이 0으로 유지됩니다.

차트가 빈 셀을 표시하는 방식을 선택하려면 [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chart/#setDisplayBlanksAs)를 사용하십시오. 이 설정은 차트 전체에 적용되며, 빈 셀을 0이나 보간값으로 채우지 않고 플롯 방식을 변경합니다.

다음 자체 포함 예제는 하나의 시리즈가 있는 선 차트를 만들고, Day 3의 값을 비운 뒤 각 모드별로 차트를 저장합니다. 입력 파일이 필요하지 않습니다. [ChartDataWorkbook](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdataworkbook/)은 워크시트 0, 열 0을 카테고리 레이블에, 열 1을 값에 사용하고, 행 0은 시리즈 이름을 보관합니다. 최종 데이터는 `10, 20, empty, 30, 40`입니다:

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayBlanksAsType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 40, 40, 640, 400);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Measurements");
    $series = $chartData->getSeries()->add($seriesNameCell, $chart->getType());
    $values = [10, 20, 25, 30, 40];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Day " . ($i + 1));
        $chartData->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // Day 3을 실제로 비워두면서 카테고리와 데이터 포인트는 유지합니다.
    $workbook->getCell(0, 3, 1)->setValue(null);

    $modes = [DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span];
    $modeNames = ["Gap", "Zero", "Span"];
    for ($i = 0; $i < count($modes); $i++) {
        $chart->setDisplayBlanksAs($modes[$i]);
        $presentation->save("empty_cells_" . $modeNames[$i] . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

각 출력 파일은 저장 전에 지정된 모드를 이름에 포함합니다: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, `empty_cells_Span.pptx`. 하나의 버전만 저장하려면 원하는 모드를 지정하고 프레젠테이션을 한 번만 저장하십시오.

아래 비교는 세 파일 모두 동일한 데이터를 보여줍니다. Day 3은 모든 경우 워크북에서 비어 있습니다:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

보이는 효과는 차트 유형에 따라 다릅니다. 선 차트는 세 모드를 쉽게 비교할 수 있지만, 막대 및 컬럼 차트는 누락된 카테고리를 연결할 선이 없어 `Span`이 위와 같은 연결 구간을 만들 수 없습니다. 또한 마커만 있는 산점도 차트에도 연결 선이 없습니다. 모든 차트 유형에서 세 가지 뚜렷한 결과가 나타난다고 기대하지 말고, 사용 중인 차트 유형의 출력 결과를 확인하십시오.

## **Set the Series Gap Width**

간격(gap width)은 인접한 막대 또는 컬럼 클러스터 사이의 공간을 막대 또는 컬럼 너비의 백분율로 나타냅니다. 겹침과 마찬가지로 이는 개별 시리즈가 아니라 상위 시리즈 그룹에 속합니다. 그룹에 대해 한 번만 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseriesgroup/#setGapWidth)를 호출하십시오. 값이 클수록 클러스터 사이의 공간이 넓어지고, 값이 작을수록 밀집됩니다.

다음 예제는 간격을 변경하고 최종 프레젠테이션만 저장합니다:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$gapWidthPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setGapWidth($gapWidthPercent);

    $presentation->save("gap_width_30.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

결과:

![The gap width](gap_width.png)

## **FAQ**

**Which chart types support data series?**

[ChartType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/charttype/) 열거형으로 표현되는 모든 차트 유형이 차트 데이터를 사용하지만, 시리즈마다 값 구조나 설정이 동일하지는 않습니다. 예를 들어 카테고리 차트는 카테고리와 값을 사용하고, 산점도 차트는 X와 Y 값을 사용하며, 버블 차트는 버블 크기를 추가합니다. 시리즈 유형에 맞는 데이터 포인트 생성 메서드를 사용하십시오. 겹침(overlap)과 간격(gap width)과 같은 옵션은 호환되는 막대 또는 컬럼 그룹에만 적용됩니다.

**What is a chart series group?**

[ChartSeriesGroup](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseriesgroup/)은 그룹 수준 플롯 설정을 공유하는 호환 시리즈를 포함합니다. 복합 차트는 둘 이상의 그룹을 가질 수 있으므로, 하나의 시리즈를 통해 접근한 그룹을 변경한다고 해서 차트의 모든 시리즈가 변경되는 것은 아닙니다.

**Does a newly created chart contain default data?**

예. 기본적으로 [ShapeCollection.addChart](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/#addChart)는 샘플 시리즈, 카테고리 및 값을 생성합니다. 이러한 셀을 편집하거나 완전 사용자 정의 데이터 세트를 추가하기 전에 시리즈와 카테고리 컬렉션을 모두 지울 수 있습니다. 오버로드를 사용하면 기본 데이터 없이 차트를 만들 수도 있습니다.

**How are chart objects connected to workbook cells?**

시리즈 이름, 카테고리 레이블 및 데이터 포인트 값은 [ChartDataWorkbook](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdataworkbook/)의 셀을 참조합니다. 참조된 셀을 변경하면 해당 차트 요소가 업데이트됩니다. 사용자 정의 데이터를 구축할 때는 각 포인트가 의도한 카테고리 아래에 플롯되도록 카테고리 행과 시리즈 값 행을 정렬하십시오.

**How do I clear one point instead of the whole series?**

해당 값 셀을 `null`로 설정하면 포인트의 카테고리 위치는 유지된 채 빈 포인트가 됩니다. 전체 시리즈의 포인트를 모두 제거하려는 경우에만 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapointcollection/#clear)를 사용하십시오. 카테고리 자체를 제거하는 경우, 모든 시리즈가 카테고리 컬렉션과 정렬된 상태를 유지하도록 업데이트하십시오.

**How are empty points displayed?**

결과는 차트 유형과 [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chart/#setDisplayBlanksAs)를 통해 구성된 값에 따라 달라집니다. 지원되는 차트는 빈 값을 간격, 0값, 혹은 인접 포인트 연결 방식으로 표시할 수 있습니다. 프레젠테이션에서 누락된 데이터의 의미에 맞는 설정을 선택하십시오. 전체 예제와 시각적 비교는 [Control the Display of Empty Cells](#control-the-display-of-empty-cells)를 참고하십시오.

**How are negative values formatted?**

지원되는 막대, 컬럼 및 버블 시리즈의 경우, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/#setInvertIfNegative)를 호출하고 [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor)에서 반환된 색상을 설정하십시오. 개별 포인트에 대해서는 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative)로 동작을 재정의할 수 있습니다. 이러한 메서드는 서식에 영향을 주며, 저장된 숫자 값 자체는 변경되지 않습니다.

**Which formatting wins when both a series and a point are formatted?**

명시적인 데이터 포인트 서식이 해당 포인트에 대해 우선합니다. 다른 포인트는 명시적인 시리즈 서식이나, 시리즈 서식이 정의되지 않은 경우 자동 차트 스타일 및 테마를 사용합니다. 겹침이나 간격과 같은 그룹 설정은 레이아웃을 제어하며 포인트 수준 서식 우선순위에 영향을 주지 않습니다.

**Is there a limit to how many series a chart can contain?**

Aspose.Slides는 별도의 고정된 시리즈 수 제한을 두고 있지 않습니다. 실제 한계는 프레젠테이션 파일 제한, 사용 가능한 메모리, 렌더링 시간 및 차트 가독성 등에 따라 결정됩니다.

**What should I change when columns are too close together or too far apart?**

적절한 상위 시리즈 그룹에 대해 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseriesgroup/#setGapWidth)를 호출하십시오. 값을 늘리면 클러스터 사이의 간격이 넓어지고, 값을 줄이면 클러스터가 더 가깝게 배치됩니다.