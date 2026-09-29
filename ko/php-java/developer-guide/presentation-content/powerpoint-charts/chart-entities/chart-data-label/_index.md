---
title: PHP를 사용하여 프레젠테이션에서 차트 데이터 레이블 관리
linktitle: 데이터 레이블
type: docs
url: /ko/php-java/chart-data-label/
keywords:
- 차트
- 데이터 레이블
- 데이터 정밀도
- 백분율
- 레이블 거리
- 레이블 위치
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 프레젠테이션에 차트 데이터 레이블을 추가하고 서식 지정하는 방법을 배워 보다 매력적인 슬라이드를 만들 수 있습니다."
---
## **소개**

데이터 레이블은 차트 시리즈와 개별 데이터 포인트에 대한 정보를 표시하여 읽는 사람이 값을 식별하고 차트를 이해하도록 돕습니다. 이 문서에서는 값 서식 지정, 백분율 표시, 레이블 텍스트 읽기, 축 최대값을 초과하는 레이블 제어, 범주 축 레이블 간격 조정 및 파이 차트 레이블 위치 지정 방법을 설명합니다.

## **차트 데이터 레이블에서 데이터 정밀도 설정**

시리즈 값을 서식 지정하려면 [setNumberFormatOfValues](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/#setNumberFormatOfValues)를 사용합니다. 이 예제는 기본 데이터로 라인 차트를 만들고, 데이터 테이블을 표시하며, 첫 번째 시리즈에 값 레이블을 활성화합니다. `#,##0.00` 형식은 천 단위 구분 기호와 두 자리 소수점을 표시하지만 기본값은 변경하지 않습니다.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);
    $chart->setDataTable(true);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->setNumberFormatOfValues("#,##0.00");
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("PrecisionOfDatalabels_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **레이블에 백분율 표시**

스택형 컬럼 차트의 경우 각 값을 해당 범주의 합계에 대한 백분율로 계산하고, 해당 텍스트를 [getTextFrameForOverriding](https://reference.aspose.com/slides/ko/php-java/aspose.slides/datalabel/#getTextFrameForOverriding)가 반환하는 텍스트 프레임에 할당합니다. 이 예제는 기본 차트 데이터를 사용하며, 8포인트 글꼴로 소수점 두 자리까지 백분율을 표시합니다. 합계가 0인 범주는 나눗셈 오류를 방지하기 위해 건너뛰며, 차트 데이터가 변경되면 사용자 정의 레이블 텍스트를 다시 계산합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\Portion;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 400, 400);

    $categoryCount = java_values($chart->getChartData()->getCategories()->size());
    $categoryTotals = array_fill(0, $categoryCount, 0.0);
    for ($k = 0; $k < $categoryCount; $k++) {
        for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
            $series = $chart->getChartData()->getSeries()->get_Item($i);
            $pointValue = java_values($series->getDataPoints()->get_Item($k)->getValue()->getData());
            $categoryTotals[$k] += $pointValue;
        }
    }

    for ($x = 0; $x < java_values($chart->getChartData()->getSeries()->size()); $x++) {
        $series = $chart->getChartData()->getSeries()->get_Item($x);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowLegendKey(false);

        for ($j = 0; $j < java_values($series->getDataPoints()->size()); $j++) {
            $label = $series->getDataPoints()->get_Item($j)->getLabel();
            if ($categoryTotals[$j] == 0) {
                continue;
            }

            $pointValue = java_values($series->getDataPoints()->get_Item($j)->getValue()->getData());
            $dataPointPercent = ($pointValue / $categoryTotals[$j]) * 100;

            $portion = new Portion();
            $portion->setText(sprintf("%.2F %%", $dataPointPercent));
            $portion->getPortionFormat()->setFontHeight(8);

            $label->getTextFrameForOverriding()->setText("");
            $paragraph = $label->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
            $paragraph->getPortions()->add($portion);

            $label->getDataLabelFormat()->setShowValue(true);
            $label->getDataLabelFormat()->setShowSeriesName(false);
            $label->getDataLabelFormat()->setShowPercentage(false);
            $label->getDataLabelFormat()->setShowLegendKey(false);
            $label->getDataLabelFormat()->setShowCategoryName(false);
            $label->getDataLabelFormat()->setShowBubbleSize(false);
        }
    }

    $presentation->save("DisplayPercentageAsLabels_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **차트 데이터 레이블에 백분율 기호 설정**

값이 분수로 저장된 경우, 백분율을 표시하려면 [setNumberFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/datalabelformat/#setNumberFormat)를 사용합니다. 레이블 형식을 원본 셀과 독립적으로 적용하려면 [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/ko/php-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource)에 `false`를 전달합니다.

이 예제는 네 개 범주에 대해 빨강 및 파랑 시리즈가 있는 100% 스택형 컬럼 차트를 생성합니다. 각 값 쌍은 합계가 1이 됩니다. 레이블 형식 `0.0%`는 0.30을 30.0%로 표시하고, 수직 축은 두 자리 소수점을 사용합니다. 두 시리즈 모두 흰색 10포인트 레이블 텍스트를 사용합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00%");

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    for ($i = 0; $i < 4; $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    $colors = java("java.awt.Color");
    $seriesNames = [ "Reds", "Blues" ];
    $seriesColors = [ $colors->RED, $colors->BLUE ];
    $values = [ [ 0.30, 0.50, 0.80, 0.65 ], [ 0.70, 0.50, 0.20, 0.35 ] ];

    for ($i = 0; $i < count($seriesNames); $i++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $i + 1, $seriesNames[$i]);
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());
        for ($j = 0; $j < 4; $j++) {
            $valueCell = $workbook->getCell($worksheetIndex, $j + 1, $i + 1, $values[$i][$j]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }

        $series->getFormat()->getFill()->setFillType(FillType::Solid);
        $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColors[$i]);

        $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(false);
        $labelFormat->setNumberFormat("0.0%");
        $labelFormat->getTextFormat()->getPortionFormat()->setFontHeight(10);
        $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($colors->WHITE);
    }

    $presentation->save("SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **데이터 레이블의 실제 텍스트 읽기**

[getActualLabelText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/datalabel/#getActualLabelText)를 사용하여 데이터 레이블 설정에 의해 생성된 텍스트를 가져올 수 있습니다. 이는 레이블을 보고서에 추출하거나 프레젠테이션 내용을 검색하거나 생성된 차트를 검증할 때 유용합니다. 아래 예제에서는 기본 [data label format](https://reference.aspose.com/slides/ko/php-java/aspose.slides/datalabelformat/)이 각 범주 이름, 시리즈 이름 및 값을 결합합니다. 한 포인트는 값을 백분율로 서식 지정하고, 다른 포인트는 [getTextFrameForOverriding](https://reference.aspose.com/slides/ko/php-java/aspose.slides/datalabel/#getTextFrameForOverriding)에서 사용자 정의 텍스트를 사용합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $firstCategoryCell = $workbook->getCell(0, 1, 0, "Q1");
    $chart->getChartData()->getCategories()->add($firstCategoryCell);
    $secondCategoryCell = $workbook->getCell(0, 2, 0, "Q2");
    $chart->getChartData()->getCategories()->add($secondCategoryCell);

    $northSeriesCell = $workbook->getCell(0, 0, 1, "North");
    $north = $chart->getChartData()->getSeries()->add($northSeriesCell, $chart->getType());
    $northFirstValueCell = $workbook->getCell(0, 1, 1, 0.25);
    $north->getDataPoints()->addDataPointForBarSeries($northFirstValueCell);
    $northSecondValueCell = $workbook->getCell(0, 2, 1, 0.75);
    $north->getDataPoints()->addDataPointForBarSeries($northSecondValueCell);

    $southSeriesCell = $workbook->getCell(0, 0, 2, "South");
    $south = $chart->getChartData()->getSeries()->add($southSeriesCell, $chart->getType());
    $southFirstValueCell = $workbook->getCell(0, 1, 2, 0.40);
    $south->getDataPoints()->addDataPointForBarSeries($southFirstValueCell);
    $southSecondValueCell = $workbook->getCell(0, 2, 2, 0.60);
    $south->getDataPoints()->addDataPointForBarSeries($southSecondValueCell);

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
        $series = $chart->getChartData()->getSeries()->get_Item($i);
        $format = $series->getLabels()->getDefaultDataLabelFormat();
        $format->setShowCategoryName(true);
        $format->setShowSeriesName(true);
        $format->setShowValue(true);
    }

    $north->getLabels()->get_Item(1)->getDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $north->getLabels()->get_Item(1)->getDataLabelFormat()->setNumberFormat("0%");
    $south->getLabels()->get_Item(0)->getTextFrameForOverriding()->setText("Reviewed");

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
        $series = $chart->getChartData()->getSeries()->get_Item($i);
        for ($j = 0; $j < java_values($series->getDataPoints()->size()); $j++) {
            $point = $series->getDataPoints()->get_Item($j);
            $label = $point->getLabel();
            if (!java_values($label->isVisible())) {
                continue;
            }

            echo "Value: " . java_values($point->getValue()->getData()) . "; label: " . java_values($label->getActualLabelText()) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

데이터 포인트에 저장된 숫자는 `0.75`이며, 레이블에 `75%`와 함께 범주 및 시리즈 이름이 표시되더라도 변하지 않습니다. 사용자 정의 텍스트는 생성된 레이블 텍스트를 대체합니다. [getActualLabelText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/datalabel/#getActualLabelText)은 두 경우 모두 결과 레이블 문자열을 반환합니다. 표시된 레이블만 추출하려면 위와 같이 [isVisible](https://reference.aspose.com/slides/ko/php-java/aspose.slides/datalabel/#isVisible)를 별도로 확인하십시오.

## **축 최대값을 초과하는 데이터 레이블 제어**

축 범위를 수동으로 제한하면 일부 데이터 포인트가 최대값을 초과할 수 있습니다. [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chart/#setShowDataLabelsOverMaximum)을 사용하여 해당 데이터 레이블을 표시할지 여부를 제어합니다. 이 설정은 레이블 가시성을 변경하지만 축 범위나 기본 데이터 값은 변경하지 않습니다.

아래 예제는 값이 60과 120인 2D 클러스터형 컬럼 차트를 생성합니다. 수직 축에서 [setAutomaticMaxValue](https://reference.aspose.com/slides/ko/php-java/aspose.slides/axis/#setAutomaticMaxValue)에 `false`를 전달하고 [setMaxValue](https://reference.aspose.com/slides/ko/php-java/aspose.slides/axis/#setMaxValue)으로 최대값을 100으로 설정합니다. 첫 번째 슬라이드는 최대값을 초과하는 레이블을 허용하고, 해당 슬라이드 복사본은 이를 비활성화합니다. 두 슬라이드 모두 `DataLabelsOverMaximum.pptx`에 저장됩니다.

[setShowValue](https://reference.aspose.com/slides/ko/php-java/aspose.slides/datalabelformat/#setShowValue)를 사용하여 값 레이블을 활성화합니다. 차트 수준 설정만으로는 값 표시를 활성화하지 않으며 개별 레이블의 비활성화된 값 표시를 무시하지도 않습니다. 이 예제는 전체 시리즈에 값을 활성화하고 [setPosition](https://reference.aspose.com/slides/ko/php-java/aspose.slides/datalabelformat/#setPosition)를 사용하여 각 열의 외부 끝에 레이블을 배치합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $firstCategory = $workbook->getCell(0, 1, 0, "Within range");
    $secondCategory = $workbook->getCell(0, 2, 0, "Above maximum");

    $chart->getChartData()->getCategories()->add($firstCategory);
    $chart->getChartData()->getCategories()->add($secondCategory);

    $seriesName = $workbook->getCell(0, 0, 1, "Values");
    $series = $chart->getChartData()->getSeries()->add($seriesName, $chart->getType());

    $firstValue = $workbook->getCell(0, 1, 1, 60);
    $secondValue = $workbook->getCell(0, 2, 1, 120);

    $series->getDataPoints()->addDataPointForBarSeries($firstValue);
    $series->getDataPoints()->addDataPointForBarSeries($secondValue);

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition::OutsideEnd);

    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(100);
    $chart->setShowDataLabelsOverMaximum(true);

    $secondSlide = $presentation->getSlides()->addClone($slide);
    $secondChart = $secondSlide->getShapes()->get_Item(0);
    $secondChart->setShowDataLabelsOverMaximum(false);

    $presentation->save("DataLabelsOverMaximum.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

다음 이미지는 Microsoft PowerPoint에서 렌더링된 저장된 슬라이드를 보여줍니다. `true`인 경우 레이블 **120**이 상단 경계에 표시되고, `false`인 경우 숨겨집니다. 레이블 **60**은 계속 표시되며, 축 최대값은 **100**으로 유지되고, 두 번째 데이터 포인트는 두 경우 모두 **120**으로 유지됩니다.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
이 예제는 값 축이 있는 2D 컬럼 차트를 사용합니다. 파이 차트 및 도넛 차트와 같이 값 축이 없는 차트는 이와 같이 축 최대값을 제한할 수 없습니다.
{{% /alert %}}

## **축으로부터 레이블 거리 설정**

[setLabelOffset](https://reference.aspose.com/slides/ko/php-java/aspose.slides/axis/#setLabelOffset)를 사용하여 범주 축 레이블과 축 사이의 거리를 제어합니다. 값은 축 레이블 최대 글꼴 크기의 백분율입니다. 이 예제는 클러스터형 컬럼 차트를 만들고 수평 축 레이블 오프셋을 500으로 설정합니다. 이 설정은 개별 데이터 포인트에 연결된 레이블이 아닌 범주 축 레이블에 영향을 줍니다.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $chart->getAxes()->getHorizontalAxis()->setLabelOffset(500);

    $presentation->save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **레이블 위치 조정**

파이 차트에서 데이터 레이블 위치를 조정하여 간격을 개선하고 리더 라인을 위한 공간을 확보합니다.

이 예제는 첫 번째 데이터 포인트의 값을 표시하고, 레이블을 슬라이스 외부에 배치하며, [setX](https://reference.aspose.com/slides/ko/php-java/aspose.slides/datalabel/#setX)와 [setY](https://reference.aspose.com/slides/ko/php-java/aspose.slides/datalabel/#setY)를 사용하여 수평 및 수직 오프셋을 조정합니다. 이러한 오프셋은 차트 너비와 높이에 각각 비례합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 200, 200);
    $series = $chart->getChartData()->getSeries();

    $label = $series->get_Item(0)->getLabels()->get_Item(0);
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setPosition(LegendDataLabelPosition::OutsideEnd);
    $label->setX(0.71);
    $label->setY(0.04);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![조정된 데이터 레이블 위치가 있는 파이 차트](pie-chart-adjusted-label.png)

## **FAQ**

**밀집된 차트에서 데이터 레이블이 겹치는 것을 어떻게 방지할 수 있나요?**

자동 레이블 배치, 리더 라인, 그리고 폰트 크기 축소를 조합합니다; 필요하면 일부 필드(예: 범주)를 숨기거나 극값 또는 핵심 포인트에만 레이블을 표시하십시오.

**값이 0, 음수 또는 비어있는 경우만 레이블을 비활성화하려면 어떻게 해야 하나요?**

레이블을 활성화하기 전에 데이터 포인트를 필터링하고, 정의된 규칙에 따라 0값, 음수값 또는 누락된 값에 대해 표시를 끕니다.

**PDF/이미지로 내보낼 때 일관된 레이블 스타일을 보장하려면 어떻게 해야 하나요?**

폰트 패밀리와 크기를 명시적으로 설정하고, 렌더링 환경에 해당 폰트가 존재하는지 확인하여 대체 폰트 사용을 방지합니다.