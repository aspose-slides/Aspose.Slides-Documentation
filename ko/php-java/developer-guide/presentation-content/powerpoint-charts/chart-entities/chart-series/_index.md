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
description: "PHP를 사용하여 프레젠테이션에서 차트 시리즈, 데이터 포인트, 워크북 셀, 서식, 겹침, 간격 너비 및 음수 값을 관리하는 방법을 알아보세요."
---
## **개요**

차트는 플롯된 값을 워크북 셀에 저장하거나 숫자 리터럴로 직접 저장할 수 있습니다. A [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/)는 관련 값 한 세트를 나타내고, 각 [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/)은 해당 시리즈의 한 점을 나타냅니다. [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) 객체는 시리즈가 공유하는 레이블 혹은 그룹화 값을 제공합니다. 기본 데이터로 만든 차트에서는 시리즈 이름, 카테고리 및 점 값이 차트 워크북의 [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) 객체를 사용합니다.

일반적인 범주형 차트의 경우, 기본 워크북은 행 0을 시리즈 이름에, 열 0을 카테고리 이름에, 나머지 셀을 시리즈 값에 사용합니다. [ChartDataWorkbook::getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/)에 전달되는 워크시트, 행, 열 인덱스는 0부터 시작합니다. 이 레이아웃은 기본 데이터를 사용해 차트를 만들 때 유용하지만, 모든 기존 차트가 이를 사용한다고 가정하지 마세요. 로드된 프레젠테이션의 경우, 워크북 값을 변경하기 전에 시리즈, 카테고리 및 데이터 포인트가 참조하는 셀을 확인하세요.

차트 설정에는 세 가지 범위가 있습니다:

- 시리즈 수준 설정은 [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/)과 같이 한 시리즈의 모든 점에 대한 기본 모양을 제공합니다.
- 데이터 포인트 설정은 [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/)과 같이 한 점에 대한 시리즈 모양을 재정의합니다.
- 그룹 설정은 동일한 [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/)에 속하는 호환 시리즈에 적용됩니다. 겹침이나 간격 너비와 같은 옵션을 설정해야 할 경우 [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/)을 통해 그룹에 접근하세요.

명시적인 점 또는 시리즈 채우기가 설정되지 않은 경우 차트 스타일과 테마가 자동 모양을 결정합니다. 시리즈와 점 서식이 모두 존재하면 점 서식이 해당 점에 대해 우선합니다.

![차트-시리즈-파워포인트](chart-series-powerpoint.png)

클러스터드 실린더 차트의 경우, [3D 시리즈 유형 또는 바 모양 변경](/slides/ko/php-java/3d-chart/#change-the-3d-series-type-and-bar-shape)이 첫 번째 시리즈에 어떤 영향을 미치는지 확인하세요.

## **숫자 리터럴을 사용하여 시리즈 값 설정**

시리즈 값이 애플리케이션 데이터나 계산 결과에서 나오고 워크시트 셀 참조가 필요하지 않을 때 숫자 리터럴을 사용합니다. 각 점의 [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) 결과를 [setAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/setasliteraldouble/)을 통해 할당하기 전에 [setDataSourceTypeForValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/)에 [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/)을 지정합니다.

컬렉션 설정은 해당 시리즈의 모든 점 값의 소스 유형을 제어합니다. 각 점 값의 [getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/basechartvalue/) 메서드는 선택된 유형을 보고하며, 컬렉션 설정을 통해 변경할 수 있습니다. `Worksheet`인 경우 [getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getascell/)을 사용해 참조 셀에 접근합니다. `DoubleLiterals`인 경우 [getAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getasliteraldouble/) 또는 `setAsLiteralDouble`을 사용해 숫자를 직접 읽거나 씁니다.

다음 예제는 기본 시리즈와 카테고리를 가진 열 차트를 생성한 후 첫 번째 시리즈의 기존 점에 10, 20 등 계산된 값을 할당합니다. 프레젠테이션을 저장하고 다시 열어 저장된 값을 출력합니다.

```php
use aspose\slides\ChartType;
use aspose\slides\DataSourceType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $series->getDataPoints()->setDataSourceTypeForValues(DataSourceType::DoubleLiterals);
    $pointCount = java_values($series->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $series->getDataPoints()->get_Item($i)->getValue()->setAsLiteralDouble(($i + 1) * 10);
    }

    $presentation->save("numeric_literals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedChart = $reopenedSlide->getShapes()->get_Item(0);
    $reopenedSeries = $reopenedChart->getChartData()->getSeries()->get_Item(0);
    $pointCount = java_values($reopenedSeries->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $point = $reopenedSeries->getDataPoints()->get_Item($i);
        echo java_values($point->getValue()->getAsLiteralDouble()), PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

점 값 소스 유형은 차트의 내부 또는 외부 워크북 구성을 식별하는 [ChartData::getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/)와 별개입니다. 숫자 리터럴을 사용한다고 해서 워크북 자체가 제거되는 것은 아닙니다. 이 예제에서는 카테고리 레이블, 시리즈 이름 및 다른 시리즈를 위해 워크북이 계속 사용됩니다. 워크북 관리에 대해서는 [Chart Workbook](/slides/ko/php-java/chart-workbook/)를 참고하세요.

산점도 및 버블 차트의 경우, [setDataSourceTypeForXValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/)와 [setDataSourceTypeForYValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/)를 사용해 각각 [getXValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getxvalue/)와 [getYValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getyvalue/)의 소스를 선택합니다. 버블 차트는 [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/)를 사용해 [getBubbleSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getbubblesize/)의 소스를 지정합니다. 해당 값의 `setAsLiteralDouble` 메서드를 사용해 숫자를 할당하기 전에 각 적용 가능한 소스를 `DoubleLiterals`로 설정하세요.

## **차트 시리즈 겹침 설정**

[ChartSeries::getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getoverlap/)은 2D 차트에서 막대나 열이 겹치는 정도를 -100%에서 100%까지 보고합니다. 이는 상위 시리즈 그룹에 있는 설정의 읽기 전용 투영입니다. 해당 그룹에 있는 모든 호환 시리즈를 업데이트하려면 [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/)를 사용하세요. 이 옵션은 그룹화된 막대나 열을 표시하는 차트 유형에만 적용되며, 복합 차트에서 무관한 시리즈 그룹에는 영향을 주지 않습니다.

다음 예제는 첫 번째 시리즈가 포함된 그룹의 겹침을 설정합니다.

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

![시리즈 겹침](series_overlap.png)

## **시리즈 채우기 색상 변경**

전체 시리즈의 기본 채우기를 설정하려면 [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/)를 사용합니다. 점에 명시적인 채우기가 이미 있으면 해당 점의 [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) 설정이 시리즈 채우기를 재정의합니다.

다음 예제는 첫 번째 시리즈에 단색 파란색 채우기를 적용합니다.

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

![시리즈 색상](series_color.png)

## **시리즈 이름 변경**

시리즈 이름은 차트 데이터 워크북에 저장되며 일반적으로 범례에 표시됩니다. 클러스터드 열 차트를 위한 기본 워크북에서는 셀 B1이 행 0, 열 1에 위치하며 첫 번째 시리즈 이름을 포함합니다. 아래 예제의 명명된 변수들은 이 구조를 명시적으로 보여 줍니다.

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

또는 [ChartSeries::getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getname/)이 이미 참조하고 있는 셀을 업데이트할 수도 있습니다. 이 접근법은 기존 차트에서 특정 행과 열을 가정하지 않으므로 안전합니다.

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

![시리즈 이름](series_name.png)

### **여러 셀에서 이름을 구성하여 시리즈 생성**

제품 이름과 보고 기간이 다른 워크북 셀에 저장된 경우, 복합 시리즈 이름이 유용합니다. 예를 들어 B1에 `Product A`가, C1에 `2026`이 있을 때 두 값을 하나의 시리즈 이름으로 결합하면서 두 부분이 각각의 원본 셀에 연결된 상태를 유지할 수 있습니다.

[ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcellcollection/)을 사용해 이름 범위를 가져온 뒤, 해당 컬렉션을 [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/add/)에 전달합니다. `skipHiddenCells` 인자는 숨겨진 셀을 포함할지 여부를 제어합니다: `true`이면 제외하고, `false`이면 포함합니다. 이 예제에서는 `false`를 사용해 이름 범위의 모든 셀을 포함합니다.

다음 예제는 하나의 시리즈와 두 개의 데이터 포인트를 가진 프레젠테이션을 생성합니다. 셀 B1:C1은 시리즈 이름만 제공하고, A2:A3은 카테고리 레이블, B2:B3은 숫자 값을 제공합니다.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 620, 180);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $chart->setLegend(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // 이 두 셀은 시리즈 이름을 제공합니다.
    $workbook->getCell(0, 0, 1, "Product A");
    $workbook->getCell(0, 0, 2, "2026");
    $nameCells = $workbook->getCellCollection('Sheet1!$B$1:$C$1', false);
    $series = $chart->getChartData()->getSeries()->add($nameCells, ChartType::ClusteredColumn);

    // 별도의 셀들이 카테고리와 숫자 데이터 포인트를 제공합니다.
    $northCategory = $workbook->getCell(0, 1, 0, "North");
    $southCategory = $workbook->getCell(0, 2, 0, "South");
    $chart->getChartData()->getCategories()->add($northCategory);
    $chart->getChartData()->getCategories()->add($southCategory);
    $northValue = $workbook->getCell(0, 1, 1, 120);
    $southValue = $workbook->getCell(0, 2, 1, 150);
    $series->getDataPoints()->addDataPointForBarSeries($northValue);
    $series->getDataPoints()->addDataPointForBarSeries($southValue);

    $presentation->save("composite_series_name.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과 시리즈 이름은 `Product A 2026`이며, 두 셀 값 사이에 공백이 들어갑니다. 범례에는 두 열이 하나의 항목으로 표시됩니다. 아래 이미지가 결과를 보여 줍니다.

![North와 South 값 및 복합 시리즈 이름 Product A 2026이 범례에 표시된 열 차트](composite_series_name.png)

## **자동 시리즈 채우기 색상 가져오기**

[ChartSeries::getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getautomaticseriescolor/)은 시리즈 인덱스와 차트 스타일을 기반으로 계산된 색상을 반환합니다. 이는 시리즈 채우기가 명시적으로 정의되지 않았을 때 사용되는 색상입니다. 메서드를 호출하면 계산된 색상을 읽을 수 있으며, 새로운 채우기를 할당하지는 않습니다.

다음 예제는 기본 시리즈 각각의 자동 색상을 출력합니다.

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

## **시리즈에 대한 역채우기 색상 설정**

막대, 열 및 버블 시리즈의 경우, [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/)를 사용해 음수 값을 다른 채우기로 표시할 수 있습니다. 일반 시리즈 채우기를 실색으로 설정하고 역전환을 활성화한 다음, [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/)를 통해 음수 색상을 지정합니다. 음수 값은 워크북에서 그대로 유지되며, 표시 색상만 변경됩니다.

다음 예제는 하나의 시리즈만 포함하도록 기본 차트 데이터를 교체합니다. 워크시트 행 0은 시리즈 이름을, 열 0은 카테고리 이름을, 열 1은 값을 포함합니다.

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

![역전된 실색 채우기 색상](inverted_solid_fill_color.png)

점 하나에 대해서만 역전환을 활성화하려면 [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/)를 사용합니다. 아래 예제에서는 시리즈에 대한 역전환을 비활성화하고 선택된 점에만 활성화합니다. 해당 점은 음수 값을 할당해 효과를 확인할 수 있도록 했습니다.

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

## **특정 데이터 포인트 값 지우기**

다른 점은 유지하면서 하나의 점만 비우려면 해당 백업 워크북 셀을 `null`로 설정합니다. 열 차트의 경우 플롯된 값은 [ChartDataPoint::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/)를 통해 얻을 수 있습니다. 데이터 포인트는 동일한 카테고리 위치에 남아 있지만, 차트는 해당 값을 차트의 빈값 설정에 따라 빈 값으로 처리합니다.

다음 예제는 첫 번째 시리즈의 두 번째 점만 지웁니다.

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

산점도 차트는 X와 Y 셀을 별도로 사용하고, 버블 차트는 크기 셀도 사용합니다. 제거하려는 값이 들어 있는 셀만 비우세요. 다른 점을 유지하고 싶다면 [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/)를 호출하지 마세요. 이 메서드는 컬렉션의 모든 데이터 포인트를 삭제합니다.

## **빈 셀 표시 제어**

값이 있는 숨김 셀은 빈 셀과는 별개의 경우입니다. 숨겨진 워크시트 행·열의 데이터를 포함하거나 제외하려면 [숨겨진 행·열의 데이터 포함](/slides/ko/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns)을 참고하세요.

빈 워크북 셀은 누락된 데이터를 의미하고, `0`이 들어 있는 셀은 알려진 숫자 값을 의미합니다. 셀을 비우려면 [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setvalue/)에 `null`을 전달합니다. 숫자 0은 빈 셀 설정과 관계없이 여전히 0으로 남습니다.

[Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/)를 사용해 차트가 빈 셀을 어떻게 표시할지 선택합니다. 이 설정은 차트 전체에 적용되며, 빈 셀을 0이나 보간값으로 채우지 않고 그래프에서 빈칸을 어떻게 그릴지 결정합니다.

다음 자체 포함 예제는 하나의 시리즈를 가진 선 차트를 만들고, 3일 차의 값을 지운 뒤 각 모드별로 차트를 저장합니다. 입력 파일이 필요하지 않습니다. [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/)은 워크시트 0, 열 0을 카테고리 레이블에, 열 1을 값에 사용하며, 행 0에 시리즈 이름을 둡니다. 최종 데이터는 `10, 20, empty, 30, 40`입니다.

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

    // Day 3을 실제로 비워두되, 해당 카테고리와 데이터 포인트는 유지합니다.
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

각 출력 파일은 저장 전에 지정된 모드를 이름에 포함합니다: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, `empty_cells_Span.pptx`. 하나의 버전만 저장하려면 원하는 모드만 지정하고 프레젠테이션을 한 번 저장하면 됩니다.

아래 비교는 세 파일 모두에서 동일한 데이터를 보여 줍니다. 3일 차는 워크북에서 모두 빈 셀입니다:

![선 차트에서 동일한 데이터: Gap은 3일 차에서 선을 끊고, Zero는 선을 0으로 낮추며, Span은 2일 차와 4일 차를 연결합니다.](display_blanks_as.png)

보이는 효과는 차트 유형에 따라 다릅니다. 선 차트는 세 모드를 모두 쉽게 비교할 수 있지만, 막대·열 차트는 누락된 카테고리 위에 연결 선이 없어 `Span`이 위와 같은 연결 구간을 만들 수 없습니다. 누락된 열과 0 높이 열도 비슷하게 보일 수 있습니다. 마커만 있는 산점도 차트 역시 연결 선이 없으니 모든 차트 유형에서 세 가지 뚜렷한 결과를 기대하지 말고 사용 중인 차트 유형에서 출력 결과를 확인하세요.

## **시리즈 간격 너비 설정**

간격 너비는 인접한 막대·열 클러스터 사이의 공간을 막대·열 너비의 백분율로 나타낸 값입니다. 겹침과 마찬가지로 이는 개별 시리즈가 아닌 상위 시리즈 그룹에 속합니다. 그룹에 대해 한 번만 [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/)를 호출하세요. 값이 클수록 클러스터 사이가 넓어지고, 값이 작을수록 밀집됩니다.

다음 예제는 간격 너비를 변경하고 최종 프레젠테이션만 저장합니다.

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

![간격 너비](gap_width.png)

## **시리즈 선 표시·숨기기**

시리즈 선은 차트의 관련 부분을 시각적으로 연결합니다. 지원되는 스택형 막대·파이 차트에서 [ChartSeriesGroup::setSeriesLines](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setserieslines/)를 사용해 표시하거나 숨길 수 있습니다. 2D 스택형 막대·열 차트에서는 카테고리 간에 스택 경계선을 연결하고, 파이 오브 파이·바 오브 파이 차트에서는 메인 플롯을 보조 플롯에 연결합니다. 이 설정은 다른 차트 유형에 대한 일반 연결 기능이 아닙니다.

그룹에 접근하려면 [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/)를 사용합니다. 설정은 해당 그룹의 모든 시리즈에 적용됩니다. [ChartSeries::hasSeriesLines](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/hasserieslines/)은 읽기 전용이며 상위 그룹의 설정을 반영합니다; 그룹의 세터를 호출해 업데이트하세요.

다음 예제는 기본 데이터를 가진 [ChartType::PieOfPie](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 차트를 하나 만들고, 시리즈 선을 활성화한 차트와 비활성화한 차트를 각각 저장해 두 프레젠테이션을 비교합니다.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 400);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $seriesGroup = $series->getParentSeriesGroup();

    $seriesGroup->setSeriesLines(true);
    $presentation->save("series_lines_enabled.pptx", SaveFormat::Pptx);

    $seriesGroup->setSeriesLines(false);
    $presentation->save("series_lines_disabled.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| 시리즈 선 활성화 | 시리즈 선 비활성화 |
| --- | --- |
| ![시리즈 선이 활성화된 파이 오브 파이 차트](series_lines_enabled.png) | ![시리즈 선이 비활성화된 파이 오브 파이 차트](series_lines_disabled.png) |
| 두 선이 메인 파이를 보조 파이에 연결합니다. | 두 파이는 그대로 보이지만 연결 선이 숨겨집니다. |

시리즈 선은 레이블을 데이터 포인트에 연결하는 리더 라인, 축 눈금을 표시하는 그리드 라인, 데이터 값을 나타내는 선 차트의 라인과는 다릅니다. 이 설정은 해당 요소들을 제어하지 않습니다.

## **FAQ**

**어떤 차트 유형이 데이터 시리즈를 지원하나요?**

[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 열거형에 포함된 모든 차트 유형이 차트 데이터를 사용하지만, 시리즈마다 값 구조와 설정이 동일하지는 않습니다. 예를 들어 범주형 차트는 카테고리와 값을 사용하고, 산점도 차트는 X·Y 값을 사용하며, 버블 차트는 버블 크기를 추가합니다. 시리즈 유형에 맞는 데이터 포인트 생성 메서드를 사용하세요. 겹침·간격 너비와 같은 옵션은 호환되는 막대·열 그룹에만 적용됩니다.

**차트 시리즈 그룹이란 무엇인가요?**

[ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/)은 그룹 수준 플로팅 설정을 공유하는 호환 시리즈를 포함합니다. 복합 차트는 여러 그룹을 포함할 수 있으므로, 하나의 시리즈를 통해 접근한 그룹을 변경한다고 해서 차트의 모든 시리즈가 변경되는 것은 아닙니다.

**새로 만든 차트에 기본 데이터가 포함되나요?**

예. 기본적으로 [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/)는 샘플 시리즈, 카테고리 및 값을 생성합니다. 이러한 셀을 편집하거나 완전히 사용자 정의된 데이터 세트를 추가하기 전에 시리즈·카테고리 컬렉션을 모두 지울 수 있습니다. 오버로드를 사용하면 기본 데이터 없이 차트를 만들 수도 있습니다.

**차트 객체는 워크북 셀과 어떻게 연결되나요?**

시리즈 이름, 카테고리 레이블 및 데이터 포인트 값은 [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/)의 셀을 참조합니다. 참조된 셀을 변경하면 해당 차트 요소가 업데이트됩니다. 사용자 정의 데이터를 구축할 때는 각 카테고리 행과 시리즈 값 행이 정렬되어 각 포인트가 의도한 카테고리 아래에 플롯되도록 해야 합니다.

**전체 시리즈가 아니라 한 점만 지우려면 어떻게 하나요?**

해당 값 셀을 `null`로 설정하면 점의 카테고리 위치는 유지하면서 빈 점으로 남깁니다. 모든 점을 삭제하려는 경우에만 [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/)을 사용하세요. 이 메서드는 해당 시리즈의 모든 데이터 포인트를 제거합니다.

**빈 점은 어떻게 표시되나요?**

표시 방식은 차트 유형과 [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/)에 설정된 값에 따라 다릅니다. 지원되는 차트는 빈 값을 간격, 0값 또는 인접 점 연결 중 하나로 표시할 수 있습니다. 프레젠테이션의 누락 데이터 의미에 맞는 설정을 선택하세요. 전체 예제와 시각적 비교는 [빈 셀 표시 제어](#control-the-display-of-empty-cells)를 참고하세요.

**음수 값은 어떻게 서식이 지정되나요?**

지원되는 막대·열·버블 시리즈의 경우 [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/)를 호출하고, [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/)가 반환하는 색상을 설정합니다. 개별 점에 대해서는 [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/)로 동작을 재정의할 수 있습니다. 이러한 메서드는 서식을 변경할 뿐 저장된 숫자 값에는 영향을 주지 않습니다.

**시리즈와 점이 모두 서식이 지정된 경우 어떤 서식이 우선하나요?**

명시적인 데이터 포인트 서식이 해당 점에 대해 우선합니다. 다른 점은 명시적인 시리즈 서식을 사용하거나, 시리즈 서식이 정의되지 않은 경우 자동 차트 스타일·테마를 사용합니다. 겹침·간격 너비와 같은 그룹 설정은 레이아웃을 제어하며, 점 수준 서식 오버라이드가 아닙니다.

**차트에 포함할 수 있는 시리즈 수에 제한이 있나요?**

Aspose.Slides 자체에 별도의 고정 시리즈 수 제한은 없습니다. 실제 제한은 프레젠테이션 파일 제약, 사용 가능한 메모리, 렌더링 시간 및 차트 가독성 등에 따라 달라집니다.

**열이 너무 가깝거나 너무 멀리 떨어져 있을 때 어떻게 해야 하나요?**

적절한 상위 시리즈 그룹에 대해 [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/)를 호출하세요. 값을 늘리면 클러스터 사이 공간이 넓어지고, 값을 줄이면 클러스터가 더 가까워집니다.