---
title: PHP로 프레젠테이션에서 차트 데이터 시리즈 관리
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
- 음수값
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "PHP를 사용하여 프레젠테이션에서 차트 시리즈, 데이터 포인트, 워크북 셀, 서식 지정, 겹침, 간격 폭 및 음수 값을 관리하는 방법을 배웁니다."
---
## **개요**

차트는 플롯된 데이터를 차트 데이터 워크북에 저장합니다. [ChartSeries](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/)은 서로 관련된 값 집합을 나타내며, 시리즈의 각 [ChartDataPoint](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapoint/)은 하나 이상의 워크북 셀을 참조합니다. [ChartCategory](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartcategory/) 객체는 시리즈가 공유하는 레이블 또는 그룹화 값을 제공합니다. 따라서 시리즈 이름, 카테고리 및 포인트 값은 표시 텍스트만으로 저장되는 것이 아니라 [ChartDataCell](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatacell/) 객체와 연결됩니다.

일반적인 범주형 차트의 경우, 기본 워크북은 행 0을 시리즈 이름에, 열 0을 카테고리 이름에, 나머지 셀을 시리즈 값에 사용합니다. [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdataworkbook/#getCell) 에 전달되는 워크시트, 행, 열 인덱스는 0부터 시작합니다. 이 레이아웃은 기본 데이터를 사용하여 차트를 만들 때 유용하지만, 모든 기존 차트가 동일하게 구성된다고 가정해서는 안 됩니다. 로드된 프레젠테이션의 경우, 워크북 값을 변경하기 전에 시리즈, 카테고리 및 데이터 포인트가 참조하는 셀을 확인하세요.

차트 설정은 세 가지 범위로 나뉩니다:

- 시리즈 수준 설정, 예: [ChartSeries.getFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/#getFormat) 은 한 시리즈의 모든 포인트에 대한 기본 모양을 제공합니다.
- 데이터 포인트 설정, 예: [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapoint/#getFormat) 은 한 포인트에 대해 시리즈 모양을 재정의합니다.
- 그룹 설정은 동일한 [ChartSeriesGroup](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseriesgroup/) 에 속하는 호환 시리즈에 적용됩니다. [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/#getParentSeriesGroup) 을 통해 그룹에 접근하고 겹침(overlap)이나 간격(gap width)과 같은 옵션을 설정하세요.

명시적인 포인트 또는 시리즈 채우기가 설정되지 않은 경우, 차트 스타일 및 테마가 자동 외관을 결정합니다. 시리즈와 포인트 포맷이 모두 존재하면, 포인트 포맷이 해당 포인트에 우선 적용됩니다.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **차트 시리즈 겹침 설정**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/#getOverlap) 은 2D 차트에서 막대 또는 열이 겹치는 정도를 -100%에서 100%까지 보고합니다. 이는 상위 시리즈 그룹의 설정을 읽기 전용으로 투영한 값입니다. 해당 그룹의 모든 호환 시리즈를 업데이트하려면 [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseriesgroup/#setOverlap) 을 사용하세요. 이 옵션은 그룹화된 막대 또는 열을 표시하는 차트 유형에만 적용되며, 복합 차트의 무관한 시리즈 그룹에는 영향을 주지 않습니다.

다음 예제는 첫 번째 시리즈가 포함된 그룹의 겹침을 설정합니다:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // 새 차트는 샘플 시리즈, 카테고리 및 값을 포함합니다.
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

## **시리즈 채우기 색상 변경**

전체 시리즈의 기본 채우기를 설정하려면 [ChartSeries.getFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/#getFormat) 를 사용하세요. 포인트에 이미 명시적인 채우기가 있는 경우, 해당 포인트의 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapoint/#getFormat) 설정이 시리즈 채우기를 재정의합니다.

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

## **시리즈 이름 변경**

시리즈 이름은 차트 데이터 워크북에 저장되며 일반적으로 범례에 표시됩니다. 클러스터형 열 차트의 기본 워크북에서 셀 B1은 행 0, 열 1에 위치하며 첫 번째 시리즈의 이름을 포함합니다. 다음 예제의 명명된 변수는 해당 구조를 명시합니다:

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

또한 [ChartSeries.getName](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/#getName) 으로 이미 참조된 셀을 업데이트할 수도 있습니다. 이 접근 방식은 기존 차트에서 특정 행 및 열을 가정하지 않으므로 안전합니다:

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

## **자동 시리즈 채우기 색상 가져오기**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) 은 시리즈 인덱스와 차트 스타일을 기반으로 계산된 색상을 반환합니다. 이는 시리즈 채우기가 명시적으로 정의되지 않았을 때 사용되는 색상입니다. 메서드를 호출하면 계산된 색상을 읽을 뿐, 새로운 채우기를 할당하지는 않습니다.

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

정확한 색상은 차트 스타일 및 테마에 따라 달라집니다.

## **차트 시리즈에 대한 반전 채우기 색상 설정**

막대, 열 및 버블 시리즈의 경우, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/#setInvertIfNegative) 를 사용하여 음수 값을 다른 채우기로 표시할 수 있습니다. 일반 시리즈 채우기를 단색으로 설정하고 반전을 활성화한 뒤, [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 로 음수 값 색상을 지정하세요. 워크북의 음수 값 자체는 변경되지 않으며, 표시 색상만 바뀝니다.

다음 예제는 기본 차트 데이터를 하나의 시리즈로 교체합니다. 워크시트 행 0에 시리즈 이름이, 열 0에 카테고리 이름이, 열 1에 값이 들어갑니다:

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

한 포인트에 대해서만 반전을 활성화하려면 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 를 사용하세요. 아래 예제에서는 시리즈에 대한 반전을 비활성화하고 선택한 포인트에만 활성화합니다. 또한 해당 포인트에 음수 값을 할당하여 효과를 확인할 수 있습니다:

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

## **특정 데이터 포인트 값 삭제**

다른 포인트를 유지하면서 한 포인트를 비워 두려면 해당 워크북 셀을 `null` 로 설정합니다. 열 차트의 경우, 플롯된 값은 [ChartDataPoint.getValue](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapoint/#getValue) 로 확인할 수 있습니다. 데이터 포인트는 동일한 카테고리 위치에 남아 있지만, 차트는 해당 값을 차트의 빈값 설정에 따라 빈칸으로 처리합니다.

다음 예제는 첫 번째 시리즈의 두 번째 포인트만 삭제합니다:

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

산점도 차트는 별도의 X 및 Y 셀을 사용하고, 버블 차트는 크기 셀도 사용합니다. 삭제하려는 값에 해당하는 셀만 비우세요. 다른 포인트를 유지하고 싶다면 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapointcollection/#clear) 를 호출하지 마세요. 이 메서드는 컬렉션의 모든 데이터 포인트를 제거합니다.

## **시리즈 간격 폭 설정**

간격 폭은 인접한 막대 또는 열 클러스터 사이의 공간을 막대 또는 열 너비의 백분율로 나타낸 값입니다. 겹침과 마찬가지로, 이는 개별 시리즈가 아닌 상위 시리즈 그룹에 속합니다. 그룹에 대해 한 번만 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseriesgroup/#setGapWidth) 을 호출하세요. 값이 클수록 클러스터 간 간격이 넓어지고, 값이 작을수록 클러스터가 더 촘촘해집니다.

다음 예제는 간격 폭을 변경하고 최종 프레젠테이션만 저장합니다:

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

**어떤 차트 유형이 데이터 시리즈를 지원합니까?**

[ChartType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/charttype/) 열거형에 정의된 모든 차트 유형은 차트 데이터를 사용하지만, 시리즈마다 값 구조와 설정이 동일하지는 않습니다. 예를 들어, 범주형 차트는 카테고리와 값을 사용하고, 산점도 차트는 X와 Y 값을 사용하며, 버블 차트는 버블 크기도 추가합니다. 시리즈 유형에 맞는 데이터 포인트 생성 메서드를 사용하세요. 겹침(overlap) 및 간격 폭(gap width)과 같은 옵션은 호환되는 막대 또는 열 그룹에만 적용됩니다.

**차트 시리즈 그룹이란 무엇입니까?**

[ChartSeriesGroup](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseriesgroup/) 은 그룹 수준 플롯 설정을 공유하는 호환 시리즈를 포함합니다. 복합 차트는 여러 그룹을 포함할 수 있으므로, 하나의 시리즈를 통해 접근한 그룹을 변경한다고 해서 차트의 모든 시리즈가 바뀌지는 않습니다.

**새로 만든 차트에 기본 데이터가 포함되어 있습니까?**

예. 기본적으로 [ShapeCollection.addChart](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/#addChart) 은 샘플 시리즈, 카테고리 및 값을 생성합니다. 이러한 셀을 편집하거나 완전히 사용자 정의된 데이터 세트를 추가하기 전에 시리즈와 카테고리 컬렉션을 모두 지울 수 있습니다. 오버로드를 사용하면 기본 데이터 없이 차트를 만들 수도 있습니다.

**차트 객체는 워크북 셀과 어떻게 연결됩니까?**

시리즈 이름, 카테고리 레이블 및 데이터 포인트 값은 [ChartDataWorkbook](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdataworkbook/) 의 셀을 참조합니다. 참조된 셀을 변경하면 해당 차트 요소가 업데이트됩니다. 사용자 정의 데이터를 구축할 때는 카테고리 행과 시리즈 값 행이 정렬되어 각 포인트가 의도된 카테고리 아래에 플롯되도록 하세요.

**전체 시리즈가 아니라 하나의 포인트만 삭제하려면 어떻게 합니까?**

관련 값 셀을 `null` 로 설정하면 포인트의 카테고리 위치는 유지된 채 빈 포인트가 됩니다. 모든 포인트를 제거하려는 경우에만 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapointcollection/#clear) 를 사용하세요. 카테고리도 함께 제거한다면, 모든 시리즈가 카테고리 컬렉션과 정렬되도록 업데이트해야 합니다.

**빈 포인트는 어떻게 표시됩니까?**

결과는 차트 유형과 [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chart/#setDisplayBlanksAs) 로 구성된 설정에 따라 달라집니다. 지원되는 차트는 빈값을 간격으로, 0값으로, 또는 인접 포인트를 연결하여 표시할 수 있습니다. 프레젠테이션에서 누락된 데이터의 의미에 맞는 설정을 선택하세요.

**음수 값은 어떻게 포맷됩니까?**

지원되는 막대, 열 및 버블 시리즈의 경우, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/#setInvertIfNegative) 를 호출하고 [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 로 반환된 색상을 설정하세요. 개별 포인트에 대해서는 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 로 동작을 재정의할 수 있습니다. 이러한 메서드는 포맷에만 영향을 미치며, 저장된 숫자 값 자체는 변경하지 않습니다.

**시리즈와 포인트 모두 포맷된 경우 어느 것이 우선합니까?**

명시적인 데이터 포인트 포맷이 해당 포인트에 우선 적용됩니다. 다른 포인트는 명시적인 시리즈 포맷 또는 시리즈 포맷이 정의되지 않은 경우 자동 차트 스타일 및 테마를 사용합니다. 겹침 및 간격 폭과 같은 그룹 설정은 레이아웃을 제어하며, 포인트 수준 포맷을 재정의하지 않습니다.

**차트에 포함할 수 있는 시리즈 수에 제한이 있습니까?**

Aspose.Slides 는 별도의 고정 시리즈 수 제한을 두지 않습니다. 실제 제한은 프레젠테이션 파일 크기, 가용 메모리, 렌더링 시간 및 차트 가독성 등에 따라 결정됩니다.

**열 간격이 너무 좁거나 넓을 때 어떻게 수정합니까?**

적절한 상위 시리즈 그룹에 대해 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseriesgroup/#setGapWidth) 를 호출하세요. 값을 늘리면 클러스터 간 간격이 넓어지고, 값을 줄이면 클러스터가 더 가깝게 배치됩니다.