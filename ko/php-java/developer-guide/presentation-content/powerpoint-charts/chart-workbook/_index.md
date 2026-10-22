---
title: PHP를 사용하여 프레젠테이션에서 차트 워크북 관리
linktitle: 차트 워크북
type: docs
weight: 70
url: /ko/php-java/chart-workbook/
keywords:
- 차트 워크북
- 차트 데이터
- 워크북 셀
- 데이터 레이블
- 워크시트
- 데이터 소스
- 외부 워크북
- 외부 데이터
- 차트 캐시
- 워크북 복구
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 발견하고: PowerPoint 및 OpenDocument 형식에서 차트 워크북을 손쉽게 관리하여 프레젠테이션 데이터를 간소화하세요."
---
## **개요**

이 문서에서는 Aspose.Slides에서 차트 워크북을 사용하는 방법을 설명합니다. 워크북 스트림을 통해 차트 데이터를 읽고 쓰는 방법, 워크북 셀을 차트 데이터 레이블로 사용하는 방법, 워크시트 컬렉션에 접근하는 방법 및 차트 값에 대한 데이터 소스 유형을 지정하는 방법을 보여 줍니다.

또한 외부 워크북을 차트 데이터 소스로 사용하는 방법을 다룹니다. 예제에서는 외부 워크북을 생성하고 할당하는 방법, 차트에 연결된 외부 워크북의 경로를 가져오는 방법, 워크북이 사용 가능할 때 차트 데이터를 편집하는 방법을 시연합니다.

누락된 데이터를 나타내는 워크북 셀에 대해서는 [Control the Display of Empty Cells](/slides/ko/php-java/chart-series/)를 참조하여 빈 셀과 0인 셀의 차이점 및 사용 가능한 표시 모드의 라인 차트 비교를 확인하십시오.

## **숨겨진 행 및 열의 데이터 포함**

[Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/)를 사용하여 차트가 숨겨진 워크시트 행 및 열의 데이터를 플롯할지 여부를 제어합니다. `true`로 설정하면 보이는 셀만 플롯되고, `false`로 설정하면 보이는 셀과 숨겨진 셀 모두 포함됩니다. 이 설정은 차트 플로팅에만 영향을 주며 워크시트 행이나 열을 숨기거나 표시하지는 않습니다.

[샘플 프레젠테이션](hidden-source-data.pptx)에는 첫 번째 슬라이드의 첫 번째 도형으로 열 차트가 포함되어 있습니다. 포함된 워크시트 `Sheet1`은 `A1:C4` 범위를 소스로 가지고 있습니다. 행 3과 열 C는 숨겨져 있지만 해당 셀에는 여전히 값이 들어 있습니다.

| 워크시트 행 | A: Month | B: Retail | C: Wholesale (숨긴 열) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (숨긴 행) | February | 40 | 60 |
| 4 | March | 20 | 50 |

[ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/)을 통해 소스 셀에 접근하고 [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/)을 호출하여 숨김 상태를 확인합니다. 이 메서드는 숨김 상태를 반환하지만 상태를 변경하지는 않습니다. 이 예제에서 B2는 보이는 셀, B3은 숨긴 행에 속하고, C2는 숨긴 열에 속하므로 각각 `false`, `true`, `true`를 출력합니다.

이 예제에서는 플로팅 설정을 변경한 후 차트 데이터를 새로 고칩니다: [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/)으로 포함된 워크북을 유지하고, [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/)으로 다시 로드합니다. 모든 셀을 포함할 경우 [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/)를 사용하여 숨긴 February 카테고리를 포함한 전체 범위를 복원해야 합니다. 플래그만 변경하는 것으로는 이 샘플의 캐시된 차트 데이터와 카테고리 레이블을 새로 고칠 수 없습니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hidden-source-data.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $workbook = $chart->getChartData()->getChartDataWorkbook();
        echo "B2 hidden: " . (java_values($workbook->getCell(0, "B2")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "B3 hidden: " . (java_values($workbook->getCell(0, "B3")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "C2 hidden: " . (java_values($workbook->getCell(0, "C2")->isHidden()) ? "true" : "false"), PHP_EOL;

        $workbookData = $chart->getChartData()->readWorkbookStream();
        foreach ([true, false] as $visibleOnly) {
            $chart->setPlotVisibleCellsOnly($visibleOnly);

            // 포함된 워크북에서 차트 데이터를 새로 고칩니다.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // 숨겨진 카테고리를 포함한 전체 소스 범위를 복원합니다.
                $chart->getChartData()->setRange('Sheet1!$A$1:$C$4');
            }

            $presentation->save("hidden_cells_" . ($visibleOnly ? "true" : "false") . ".pptx", SaveFormat::Pptx);
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

예제는 두 가지 버전의 프레젠테이션을 저장합니다: 보이는 Retail 값(10 및 20)만 포함한 버전과 모든 값(총 6개)을 포함한 버전입니다. 아래 이미지는 두 플로팅 모드를 나타냅니다. 행 3과 열 C는 두 포함된 워크북 모두에서 숨겨진 상태로 유지됩니다.

| 보이는 셀만 (`true`) | 모든 셀 (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

값이 있는 숨겨진 셀은 빈 셀과 다릅니다. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/)는 누락된 값이 표시되는 방식을 제어하지만 숨겨진 소스 데이터를 포함하거나 제외하지는 않습니다. 예제는 [Control the Display of Empty Cells](/slides/ko/php-java/chart-series/#control-the-display-of-empty-cells)를 참고하십시오.

## **차트 데이터 범위 검색**

기존 프레젠테이션에서 워크북 데이터를 업데이트하기 전에 소스 범위를 확인하여 각 차트가 사용하는 워크시트 셀을 파악합니다. [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) 메서드는 현재 데이터 범위를 워크시트 한정 수식(`Sheet1!$A$1:$D$5` 등)으로 반환합니다. 여기서 `Sheet1`은 워크시트 이름, `!`는 셀 범위와 구분하고, `$A$1:$D$5`는 절대 행·열 참조를 나타냅니다.

이 메서드는 차트나 워크북을 변경하지 않고 현재 범위를 읽습니다. 차트가 워크북을 데이터 소스로 사용하지 않으면 예외가 발생합니다. 자세한 내용은 [ChartData API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/)를 참조하십시오.

예제는 프레젠테이션을 열고 각 슬라이드의 도형을 직접 검사하여 차트를 찾습니다. 차트 이름과 소스 범위를 출력하고, 워크북을 사용하지 않는 차트는 메시지를 출력한 뒤 다음 차트로 진행합니다.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
                $chart = $shape;
                try {
                    $range = $chart->getChartData()->getRange();
                    echo $chart->getName() . ": " . $range, PHP_EOL;
                } catch (JavaException $exception) {
                    if (java_instanceof($exception, new JavaClass("com.aspose.slides.exceptions.InvalidOperationException"))) {
                        echo $chart->getName() . ": The chart does not use a workbook as its data source.", PHP_EOL;
                    } else {
                        echo $chart->getName() . ": " . $exception->getMessage(), PHP_EOL;
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **워크북에서 차트 데이터 읽기 및 쓰기**

Aspose.Slides for PHP via Java는 [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/)와 [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) 메서드를 제공하여 차트 데이터 워크북( Aspose.Cells로 편집한 차트 데이터를 포함) 을 읽고 쓸 수 있습니다. **Note** 차트 데이터는 동일한 구조이거나 소스와 유사한 구조여야 합니다.

예제는 첫 번째 슬라이드 첫 번째 도형에 차트가 있는 프레젠테이션을 사용합니다. 포함된 워크북을 바이트 배열로 읽고, 기존 시리즈와 카테고리를 모두 지운 뒤, 동일한 워크북을 다시 씁니다. 변경 사항은 메모리 상에 유지되며, 프레젠테이션은 저장되지 않습니다.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **워크북 수정 후 차트 레이아웃 검증**

임베디드 워크북을 수정된 워크북으로 교체하면 차트는 기존 시리즈 및 카테고리 컬렉션을 그대로 유지합니다. 이 불일치로 인해 [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/)이 인덱스 범위 초과 오류를 발생시킬 수 있습니다. 업데이트된 워크북을 차트에 다시 쓰기 전에 기존 시리즈와 카테고리를 먼저 삭제하십시오. 예제는 첫 번째 슬라이드 첫 번째 도형에 있는 차트를 사용합니다. 주석은 워크북 편집이 일어나는 위치를 표시하며, 실행 가능한 예제는 원본 워크북을 다시 쓰고 메모리 상에서 레이아웃을 검증합니다.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        // 여기에서 워크북 바이트를 수정합니다. 예를 들어 Aspose.Cells를 사용합니다.

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
        $chart->validateChartLayout();
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

컬렉션을 비우면 워크북이 다시 쓰일 때 오래된 데이터 참조가 제거됩니다. 업데이트된 워크북에 필요한 시리즈 및 카테고리 매핑을 재구성한 뒤 차트를 사용하십시오.

## **워크북 셀에 사용자 정의 숫자 형식 지정**

[ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/)을 사용하여 차트의 포함된 워크북에서 숫자 값이 표시되는 방식을 제어합니다. 예를 들어, 변환율은 소수점 네 자리 퍼센트 형식으로, 계수는 소수점 다섯 자리 형식으로 표시해야 할 수 있습니다. 두 값 모두 숫자 형태로 유지하여 계산 및 차트 플로팅에 사용할 수 있도록 합니다.

숫자 형식은 표시 형태만 바꾸며 저장된 값은 변경하지 않습니다. 형식 `0.0000%`는 `0.125`를 `12.5000%`로 표시하지만 저장된 값은 `0.125` 그대로 유지합니다. 마찬가지로 `0.00000`은 `0.1234567`을 `0.12346`으로 표시하지만 원본 값은 반올림되지 않습니다. 사용자 정의 형식이 빈 문자열(`""`)인 경우 [getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/)이 반환하는 형식이 사용됩니다.

다음 예제는 열 차트를 생성하고 [getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/)을 통해 셀에 접근합니다. 워크시트 0의 B2에는 변환율이, C2에는 계수가 들어 있습니다. 두 셀 모두 차트 값을 제공합니다. 예제는 또한 소스 형식에 연결된 값 레이블을 활성화합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 270, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
    $chart->setTitle(false);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00");
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(0);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A2", "Sample");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $percentageCell = $workbook->getCell(0, "B2", 0.125);
    $percentageCell->setCustomNumberFormat("0.0000%");
    $percentageName = $workbook->getCell(0, "B1", "Conversion rate");
    $percentageSeries = $chart->getChartData()->getSeries()->add($percentageName, $chart->getType());
    $percentageSeries->getDataPoints()->addDataPointForBarSeries($percentageCell);

    $precisionCell = $workbook->getCell(0, "C2", 0.1234567);
    $precisionCell->setCustomNumberFormat("0.00000");
    $precisionName = $workbook->getCell(0, "C1", "Coefficient");
    $precisionSeries = $chart->getChartData()->getSeries()->add($precisionName, $chart->getType());
    $precisionSeries->getDataPoints()->addDataPointForBarSeries($precisionCell);

    for ($seriesIndex = 0; $seriesIndex < java_values($chart->getChartData()->getSeries()->size()); $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $labelFormat = $series->getDataPoints()->get_Item(0)->getLabel()->getDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(true);
    }

    $presentation->save("CustomCellFormats.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

워크북 셀 형식은 차트 축이나 데이터 레이블에 직접 설정된 형식과 별개입니다. 이 예제에서는 [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/)를 `true`로 설정하고, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/)를 `true`로 설정했기 때문에 각 레이블이 소스 셀의 값과 동일한 형식으로 표시됩니다. 프레젠테이션을 저장하고 다시 연 후 레이블은 `12.5000%`와 `0.12346`을 표시합니다. 수직 축은 자체 형식 `0.00`을 [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/)으로 지정하고, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/)를 `false`로 설정했습니다.

데이터 레이블을 독립적으로 서식 지정하려면 소스 연결 플래그를 `false`로 설정하고 [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/)으로 형식을 지정합니다. 이렇게 해도 워크북 셀의 형식은 변하지 않습니다. 예를 들어 독립 레이블 형식 `0.00`을 지정하면 첫 번째 값은 `0.13`으로 표시되지만 B2는 여전히 `12.5000%`를 표시합니다. 직접 레이블 서식 지정에 대한 내용은 [Chart Data Labels](/slides/ko/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels)를 참고하십시오.

아래 이미지는 프레젠테이션을 다시 연 후 저장된 상태에서 렌더링한 결과입니다.

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **워크북 셀을 차트 데이터 레이블로 사용**

워크북 셀의 텍스트를 차트 데이터 레이블로 사용할 수 있습니다.

예제는 기존 프레젠테이션의 첫 번째 슬라이드에 기본 데이터가 있는 버블 차트를 추가합니다. 워크시트 0의 셀 A10:A12를 첫 번째 시리즈의 첫 번째 세 레이블에 사용하고, 셀 기반 레이블을 활성화한 뒤 업데이트된 프레젠테이션을 저장합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $series->getLabels()->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $series->getLabels()->get_Item(0)->setValueFromCell($workbook->getCell(0, "A10", "Label 0 cell value"));
    $series->getLabels()->get_Item(1)->setValueFromCell($workbook->getCell(0, "A11", "Label 1 cell value"));
    $series->getLabels()->get_Item(2)->setValueFromCell($workbook->getCell(0, "A12", "Label 2 cell value"));

    $presentation->save("resultchart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **워크시트 관리**

[ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) 메서드는 차트 워크북에 포함된 워크시트에 접근할 수 있게 합니다. 예제는 기본 데이터가 있는 파이 차트를 만들고 각 워크시트 이름을 콘솔에 출력합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    for ($i = 0; $i < java_values($workbook->getWorksheets()->size()); $i++) {
        echo $workbook->getWorksheets()->get_Item($i)->getName(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **데이터 소스 유형 지정**

시리즈 포인트 값은 숫자 리터럴로 직접 저장할 수도 있습니다. 전체 예제는 [Set Series Values Using Numeric Literals](/slides/ko/php-java/chart-series/#set-series-values-using-numeric-literals)를 참고하십시오. 포인트 값의 소스 유형은 차트 내부 또는 외부 워크북 구성과 별개이며, 숫자 리터럴을 사용한다고 해서 자동으로 포함된 워크북이 제거되지는 않습니다.

예제는 기본 데이터가 있는 3D 열 차트를 만들고 두 개의 시리즈 이름을 서로 다른 데이터 소스로 설정합니다. 첫 번째 이름은 문자열 리터럴을 사용하고, 두 번째 이름은 워크시트 0의 셀 C1을 사용합니다. [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) 열거형을 통해 각 이름의 소스를 선택합니다. 예제는 업데이트된 시리즈 이름을 포함한 프레젠테이션을 저장합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;
use aspose\slides\DataSourceType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $literalName = $chart->getChartData()->getSeries()->get_Item(0)->getName();

    $literalName->setDataSourceType(DataSourceType::StringLiterals);
    $literalName->setData("LiteralString");

    $cellName = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $nameCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, "C1", "NewCell");
    $cellName->setDataSourceType(DataSourceType::Worksheet);
    $cellName->setData($nameCell);

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **지원되지 않는 포함 워크북 형식 감지**

Aspose.Slides는 일부 차트에 포함될 수 있는 Excel 이진 워크북(.xlsb) 형식을 지원하지 않습니다. [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/)의 `getEmbeddedWorkbookType` 메서드와 [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) 열거형을 사용하여 지원되지 않는 형식을 감지하고 해당 차트를 건너뛸 수 있습니다. 예제는 기존 프레젠테이션의 첫 번째 슬라이드에 있는 도형을 검사하여 차트가 아닌 도형은 건너뛰고, .xlsb 워크북이 포함된 차트에 대해 진단 메시지를 출력합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartDataSourceType;
use aspose\slides\WorkbookType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
            continue;
        }

        $chart = $shape;
        $chartData = $chart->getChartData();
        $isInternalWorkbook = java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook;
        $isBinaryMacro = java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro;

        if ($isInternalWorkbook && $isBinaryMacro) {
            echo "Skipping a chart with an unsupported .xlsb workbook.", PHP_EOL;
            continue;
        }

        // 지원되는 차트 워크북 데이터를 여기서 읽거나 수정합니다.
    }
} finally {
    $presentation->dispose();
}
```

## **외부 워크북**

Aspose.Slides는 외부 워크북을 차트 데이터 소스로 사용하는 것을 지원합니다.

### **외부 워크북 만들기**

[readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/)과 [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/)을 사용하여 포함된 차트 워크북을 파일로 내보내고 차트를 해당 외부 워크북에 연결합니다.

예제는 기본 데이터가 있는 파이 차트를 만들고 워크북을 내보냅니다. 파일 쓰기가 완료된 후 외부 워크북을 차트 데이터 소스로 지정하고, 연결된 프레젠테이션을 저장합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $workbookPath = new Java("java.io.File", "externalWorkbook1.xlsx");
    $workbookData = $chart->getChartData()->readWorkbookStream();
    try {
        $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
        try {
            $fileStream->write($workbookData);
        } finally {
            $fileStream->close();
        }
        $chart->getChartData()->setExternalWorkbook($workbookPath->getAbsolutePath());
        
        $presentation->save("externalWorkbook.pptx", SaveFormat::Pptx);
    } catch (JavaException $exception) {
        echo "Could not write the external workbook: " . $exception->getMessage(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **외부 워크북 설정**

[setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) 메서드를 사용하면 외부 워크북을 차트의 데이터 소스로 할당할 수 있습니다. 이 메서드는 외부 워크북이 이동된 경우 경로를 업데이트하는 데에도 사용할 수 있습니다.

원격 위치나 리소스에 저장된 워크북의 데이터를 직접 편집할 수는 없지만, 외부 데이터 소스로는 사용할 수 있습니다. 외부 워크북에 대한 상대 경로가 제공되면 자동으로 절대 경로로 변환됩니다.

예제는 `Sheet1` 워크시트에 B1에 시리즈 이름, A2:A4에 카테고리 이름, B2:B4에 숫자 값을 가진 외부 워크북을 사용합니다. 파이 차트를 만든 뒤 워크북을 연결하고, [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/)을 사용해 A1:B4를 하나의 시리즈와 세 개의 카테고리로 매핑합니다. 연결된 차트와 함께 프레젠테이션을 저장합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $workbookFile = new Java("java.io.File", "externalWorkbook.xlsx");
    $workbookPath = $workbookFile->getAbsolutePath();

    $chartData->setExternalWorkbook($workbookPath);
    $chartData->setRange('Sheet1!$A$1:$B$4');

    $presentation->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/)의 `updateChartData` 매개변수는 워크북이 로드되는지를 제어합니다.

* `updateChartData`가 `false`이면 워크북 경로만 업데이트되고 차트 데이터는 로드되지 않으므로 워크북이 없어도 됩니다.
* `updateChartData`가 `true`이면 대상 워크북에서 차트 데이터가 업데이트됩니다.

다음 예제는 `updateChartData`를 `false`로 설정하고 플레이스홀더 URL을 지정합니다. 파이 차트의 기본 데이터를 유지하면서 사용할 수 없는 워크북을 로드하지 않은 채 프레젠테이션을 저장합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chart->getChartData()->setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    $presentation->save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **차트의 외부 데이터 소스 워크북 경로 가져오기**

차트에 연결된 워크북을 확인하려면 차트가 외부 데이터 소스를 사용하고 있는지 검사한 뒤 워크북 경로를 가져옵니다.

예제는 외부 워크북이 연결된 프레젠테이션의 첫 번째 슬라이드 첫 번째 도형을 검사합니다. 차트가 외부 워크북에 연결되어 있으면 [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/)을 콘솔에 출력하고 프레젠테이션 사본을 저장합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ChartDataSourceType;

$presentation = new Presentation("externalWorkbook.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::ExternalWorkbook) {
            echo $chartData->getExternalWorkbookPath(), PHP_EOL;
        } else {
            echo "The chart does not use an external workbook.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **차트 데이터 편집**

외부 워크북의 데이터를 내부 워크북과 동일한 방식으로 편집할 수 있습니다. 외부 워크북을 로드할 수 없을 경우 예외가 발생합니다.

예제는 첫 번째 슬라이드 첫 번째 도형에 있는 차트가 접근 가능한 외부 워크북에 연결되어 있다고 가정합니다. 첫 번째 시리즈 첫 번째 데이터 포인트의 셀 기반 값을 100으로 설정하고 업데이트된 프레젠테이션을 저장합니다. 셀 값을 편집하면 연결된 외부 XLSX 파일이 업데이트되므로 원본 워크북을 보존하려면 복사본을 사용하십시오.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $series = $chart->getChartData()->getSeries();
        if (java_values($series->size()) > 0 && java_values($series->get_Item(0)->getDataPoints()->size()) > 0) {
            $valueCell = $series->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell();
            if (!java_is_null($valueCell)) {
                $valueCell->setValue(100);
                $presentation->save("presentation_out.pptx", SaveFormat::Pptx);
            } else {
                echo "The first data point is not linked to a workbook cell.", PHP_EOL;
            }
        } else {
            echo "The chart has no data points to edit.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **차트 캐시에서 워크북 복구**

차트가 존재하지 않거나 사용할 수 없는 외부 워크북을 참조하는 경우 Aspose.Slides는 프레젠테이션에 캐시된 데이터로부터 차트 워크북을 재구성할 수 있습니다. [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/)를 만든 뒤 [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/)와 [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/)를 `true`로 설정하고 프레젠테이션을 엽니다.

다음 PHP 예제는 첫 번째 슬라이드 첫 번째 도형에 있는 차트가 사용할 수 없는 외부 워크북을 참조하고 있을 때 워크북 데이터를 복구합니다. 복구된 데이터는 [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/)와 [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/)를 통해 접근합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;
use aspose\slides\LoadOptions;

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

        // 여기에서 복구된 워크북 데이터를 읽거나 수정합니다.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

외부 워크북이 사용 불가능하고 복구 옵션을 비활성화하면 Aspose.Slides는 예외를 발생시킵니다. 캐시된 차트 데이터를 사용하는 것이 허용 가능한 경우에만 복구를 활성화하십시오. 캐시에는 프레젠테이션이 마지막으로 업데이트된 이후 외부 워크북에 가해진 변경 사항이 포함되지 않을 수 있습니다.

## **FAQ**

**특정 차트가 외부 워크북에 연결되어 있는지, 포함된 워크북에 연결되어 있는지 확인할 수 있나요?**

예. 차트는 [data source type](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/)과 [external workbook path](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/)를 가지고 있습니다. 소스가 외부 워크북이면 전체 경로를 읽어 외부 파일이 사용되고 있는지 확인할 수 있습니다.

**외부 워크북에 대한 상대 경로가 지원되며, 어떻게 저장되나요?**

예. 상대 경로를 지정하면 자동으로 절대 경로로 변환됩니다. 프레젠테이션은 절대 경로를 PPTX 파일에 저장하므로 워크북을 이동하면 링크를 업데이트해야 할 수 있습니다.

**네트워크 리소스/공유에 있는 워크북을 사용할 수 있나요?**

예. 이러한 워크북을 외부 데이터 소스로 사용할 수 있습니다. 그러나 Aspose.Slides에서 원격 워크북을 직접 편집하는 것은 지원되지 않으며, 소스로만 사용할 수 있습니다.

**프레젠테이션을 저장할 때 Aspose.Slides가 외부 XLSX 파일을 덮어쓰나요?**

프레젠테이션은 [external file link](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/)를 저장합니다. 셀 기반 차트 데이터를 편집하면 연결된 로컬 XLSX 파일도 업데이트될 수 있습니다. 원본 파일을 변경하지 않으려면 워크북 복사본을 사용하십시오.

**외부 파일에 비밀번호가 설정된 경우 어떻게 해야 하나요?**

Aspose.Slides는 링크 시 비밀번호를 받지 않습니다. 일반적인 방법은 미리 보호를 해제하거나 [Aspose.Cells](https://reference.aspose.com/cells/java/)와 같은 도구로 복호화된 복사본을 만든 뒤 연결하는 것입니다.

**여러 차트가 동일한 외부 워크북을 참조할 수 있나요?**

예. 각 차트는 자체 링크를 저장합니다. 모두 동일한 파일을 가리키면 해당 파일을 업데이트할 때 다음에 데이터가 로드될 때 각 차트에 반영됩니다.