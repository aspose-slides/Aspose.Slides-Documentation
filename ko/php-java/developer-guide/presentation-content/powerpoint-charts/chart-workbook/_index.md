---
title: 프레젠테이션에서 PHP를 사용하여 차트 워크북 관리
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
- 파워포인트
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 발견하세요: PowerPoint 및 OpenDocument 형식에서 차트 워크북을 손쉽게 관리하여 프레젠테이션 데이터를 효율화합니다."
---
## **개요**

이 문서는 Aspose.Slides에서 차트 워크북을 사용하는 방법을 설명합니다. 워크북 스트림을 통해 차트 데이터를 읽고 쓰는 방법, 워크북 셀을 차트 데이터 레이블로 사용하는 방법, 워크시트 컬렉션에 액세스하는 방법 및 차트 값에 대한 데이터 소스 유형을 지정하는 방법을 보여줍니다.

또한 외부 워크북을 차트 데이터 소스로 사용하는 방법도 다룹니다. 예제에서는 외부 워크북을 생성하고 할당하는 방법, 차트에 연결된 외부 워크북의 경로를 검색하는 방법, 워크북을 사용할 수 있을 때 차트 데이터를 편집하는 방법을 보여 줍니다.

누락된 데이터를 나타내는 워크북 셀에 대해서는 빈 셀과 0의 차이 및 사용 가능한 표시 모드의 라인 차트 비교를 보려면 [빈 셀 표시 제어](/slides/ko/php-java/chart-series/)를 참조하세요.

## **숨겨진 행 및 열의 데이터 포함**

[Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/)를 사용하여 차트가 숨겨진 워크시트 행 및 열의 데이터를 플롯할지 여부를 제어합니다. `true`로 설정하면 보이는 셀만 플롯하고, `false`로 설정하면 보이는 셀과 숨긴 셀 모두 포함합니다. 이 설정은 차트 플로팅을 제어하며 워크시트 행이나 열을 숨기거나 표시하지는 않습니다.

[sample presentation](hidden-source-data.pptx)에는 첫 번째 슬라이드의 첫 번째 도형으로 컬럼 차트가 포함되어 있습니다. 삽입된 워크시트 `Sheet1`에는 `A1:C4` 범위가 포함되어 있습니다. 3행과 C열은 숨겨져 있지만 해당 셀에는 여전히 값이 들어 있습니다.

| 워크시트 행 | A: 월 | B: 소매 | C: 도매 (숨겨진 열) |
| --- | --- | --- | --- |
| 2 | 1월 | 10 | 30 |
| 3 (hidden row) | 2월 | 40 | 60 |
| 4 | 3월 | 20 | 50 |

[ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/)을 통해 소스 셀에 액세스하고 [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/)을 읽어 숨김 상태를 검사합니다. 이 메서드는 상태를 변경하지 않고 숨김 상태를 보고합니다. 이 파일에서는 B2가 보이고, B3은 숨겨진 행에 속하며, C2는 숨겨진 열에 속합니다; 예제는 각각 `false`, `true`, `true`를 출력합니다.

이 예제에서는 플롯 설정을 변경한 후 차트 데이터를 새로 고칩니다: [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/)으로 삽입된 워크북을 유지하고 [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/)으로 다시 로드합니다. 모든 셀을 포함할 때는 숨겨진 2월 카테고리를 포함한 전체 범위를 복원하기 위해 [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/)도 사용합니다. 단순히 플래그를 변경하는 것만으로는 이 샘플의 캐시된 차트 데이터와 카테고리 레이블을 새로 고치기에 충분하지 않습니다.

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

            // 삽입된 워크북에서 차트 데이터를 새로 고칩니다.
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
예제는 프레젠테이션을 두 버전으로 저장합니다: 보이는 소매 값(10 및 20)만 포함한 버전과 모든 여섯 값을 포함한 버전입니다. 아래 이미지들은 두 플롯 모드를 보여줍니다. 행 3과 열 C는 두 삽입 워크북 모두에서 숨겨진 상태로 유지됩니다.

| 보이는 셀만 (`true`) | 전체 셀 (`false`) |
| --- | --- |
| ![보이는 셀만: 1월 및 3월의 소매 값 10 및 20.](hidden_cells_True.png) | ![전체 셀: 1월, 2월, 3월의 소매 및 도매 값.](hidden_cells_False.png) |

값을 포함하고 있는 숨겨진 셀은 빈 셀과 다릅니다. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/)은 누락된 값이 표시되는 방식을 제어하지만 숨겨진 소스 데이터를 포함하거나 제외하지는 않습니다. 예제는 [빈 셀 표시 제어](/slides/ko/php-java/chart-series/#control-the-display-of-empty-cells)를 참조하세요.

## **차트의 데이터 범위 검색**

기존 프레젠테이션에서 워크북 데이터를 업데이트하기 전에, 각 차트가 사용하는 워크시트 셀을 식별하기 위해 소스 범위를 검사합니다. [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) 메서드는 현재 데이터 범위를 워크시트 자격이 있는 수식 형태로 반환합니다(예: `Sheet1!$A$1:$D$5`). 여기서 `Sheet1`은 워크시트 이름이고, `!`는 셀 범위와 구분하며, `$A$1:$D$5`는 A1부터 D5까지의 셀을 포함합니다. 달러 기호는 절대 행 및 열 참조를 나타냅니다.

이 메서드는 차트나 워크북을 변경하지 않고 현재 범위를 읽습니다. 차트가 워크북을 데이터 소스로 사용하지 않으면 예외가 발생합니다. 자세한 내용은 [ChartData API 참조](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/)를 참조하세요.

이 예제는 프레젠테이션을 열고 각 슬라이드의 도형을 직접 확인하여 차트가 있는지 검사합니다. 각 차트의 이름과 소스 범위를 출력합니다. 차트가 워크북을 사용하지 않으면 메시지를 출력하고 다음 차트로 진행합니다.

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

Aspose.Slides for PHP via Java은 [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) 및 [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) 메서드를 제공하여 차트 데이터 워크북( Aspose.Cells로 편집된 차트 데이터 포함)을 읽고 쓸 수 있게 합니다. **Note** 차트 데이터는 동일한 방식으로 구성되거나 원본과 유사한 구조를 가져야 합니다.

이 예제는 첫 번째 슬라이드의 첫 번째 도형으로 차트가 있는 프레젠테이션을 사용합니다. 삽입된 워크북을 바이트 배열로 읽고 기존 시리즈와 카테고리를 지운 다음 동일한 워크북을 다시 씁니다. 변경 사항은 메모리에 유지되며, 예제는 프레젠테이션을 저장하지 않습니다.

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

삽입 워크북을 수정된 워크북으로 교체하면 차트는 원래 시리즈와 카테고리 컬렉션을 유지합니다. 이 불일치는 [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/)이 인덱스 범위 초과 오류로 실패하게 할 수 있습니다. 업데이트된 워크북을 차트에 다시 쓰기 전에 기존 시리즈와 카테고리를 지우세요. 이 예제는 첫 번째 슬라이드의 첫 번째 도형인 차트를 사용합니다. 주석은 워크북 편집이 발생할 위치를 표시하며, 실행 가능한 예제는 원본 워크북을 다시 쓰고 메모리에서 레이아웃을 검증합니다.

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

        // 여기서 워크북 바이트를 수정하고, 예를 들어 Aspose.Cells를 사용합니다.

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

컬렉션을 지우면 워크북을 다시 쓰기 전에 오래된 데이터 참조가 제거됩니다. 차트를 사용하기 전에 업데이트된 워크북에 필요한 시리즈 및 카테고리 매핑을 다시 구성하세요.

## **카테고리 레이블 저장 방법 선택**

레이블을 추가하기 전에 빈 카테고리 컬렉션에 [ChartCategoryCollection::setUseCells](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorycollection/setusecells/)을 호출합니다. 레이블이 워크북 데이터에 참조하거나 연도별 분기와 같이 계층을 형성할 경우 워크시트 셀을 사용합니다. 셀 참조가 필요 없는 단일 레벨 레이블에는 문자열 리터럴을 사용합니다. 이 설정은 카테고리에만 적용됩니다. 예제의 두 차트 모두 숫자 시리즈 값을 위해 워크시트 셀을 사용합니다.

예제는 두 개의 컬럼 차트를 생성하고 각 차트에 대해 저장 모드를 출력한 뒤 `Q1 Q2 Q3 Q4`를 표시합니다. 워크시트 기반 레이블의 경우, [ChartCategory::getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/getascell/)은 기본 셀을 반환하고 [ChartDataCell::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getvalue/)은 해당 레이블을 반환합니다. 리터럴 레이블의 경우, [ChartCategory::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/getvalue/)을 사용하여 문자열을 직접 읽습니다.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    foreach ([true, false] as $useCells) {
        $x = $useCells ? 20 : 360;
        $chart = $shapes->addChart(ChartType::ClusteredColumn, $x, 20, 320, 250);
        $data = $chart->getChartData();
        $data->getSeries()->clear();
        $categories = $data->getCategories();
        $categories->clear();
        $categories->setUseCells($useCells);

        $workbook = $data->getChartDataWorkbook();
        $seriesName = $workbook->getCell(0, 0, 1, "Sales");
        $series = $data->getSeries()->add($seriesName, $chart->getType());
        for ($row = 1; $row <= 4; $row++) {
            $label = "Q" . $row;
            if ($useCells) {
                $labelCell = $workbook->getCell(0, $row, 0, $label);
                $categories->add($labelCell);
            } else {
                $categories->add($label);
            }

            $valueCell = $workbook->getCell(0, $row, 1, $row * 10);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }

        $storedInCells = java_values($categories->getUseCells());
        echo "UseCells = ", ($storedInCells ? "true" : "false"), ":";
        $categoryCount = java_values($categories->size());
        for ($i = 0; $i < $categoryCount; $i++) {
            $category = $categories->get_Item($i);
            $label = $storedInCells ? $category->getAsCell()->getValue() : $category->getValue();
            echo " ", java_values($label);
        }
        echo PHP_EOL;
    }

    $presentation->save("category-labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **워크북 셀에 사용자 지정 숫자 형식 설정**

[ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/)을 사용하여 차트 삽입 워크북에서 숫자 값이 표시되는 방식을 제어합니다. 예를 들어, 보고서에서 변환율을 소수점 네 자리 퍼센트로, 계수를 소수점 다섯 자리로 표시해야 할 수 있습니다. 두 값 모두 숫자로 유지하여 계산 및 차트 플로팅에 사용할 수 있게 합니다.

숫자 형식은 표시만 변경하고 저장된 값은 변경하지 않습니다. 형식 `0.0000%`는 `0.125`를 `12.5000%`로 표시하지만 저장된 숫자를 `12.5`로 바꾸지는 않습니다. 마찬가지로 `0.00000`은 `0.1234567`을 `0.12346`으로 표시하지만 저장된 값을 반올림하지는 않습니다. 사용자 지정 형식이 빈 문자열(`""`)이면 [getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/)에서 반환된 형식이 대신 사용됩니다.

다음 예제는 컬럼 차트를 만들고 [getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/)을 통해 셀에 접근합니다. 워크시트 0의 B2에는 변환율이, C2에는 계수가 들어 있습니다. 두 셀 모두 차트 값을 제공합니다. 예제는 또한 소스 형식에 연결된 값 레이블을 활성화합니다.

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

워크북 셀 형식은 차트 축이나 데이터 레이블에 직접 설정된 형식과 별개입니다. 이 예제에서는 [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/)를 `true`로 설정하고, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/)를 `true`로 설정했기 때문에 각 레이블은 해당 소스 셀의 값을 표시합니다. 프레젠테이션을 저장하고 다시 열면 레이블은 아래와 같이 `12.5000%`와 `0.12346`을 표시합니다. 세로 축은 [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/)로 `0.00`을 지정하고, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/)를 `false`로 설정하여 자체 형식을 사용합니다.

데이터 레이블을 독립적으로 서식 지정하려면 해당 소스 연결 플래그를 `false`로 설정하고 [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/)으로 형식을 지정합니다. 이렇게 해도 워크북 셀의 형식은 변경되지 않습니다. 예를 들어, 독립 레이블 형식 `0.00`은 첫 번째 값을 `0.13`으로 표시하지만 B2는 여전히 `12.5000%`를 표시합니다. 직접 레이블 서식 지정에 대해서는 [Chart Data Labels](/slides/ko/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels)를 참조하세요.

![소스 연결 레이블이 12.5000%와 0.12346을 표시하고 독립적으로 서식 지정된 숫자 축이 있는 컬럼 차트.](custom-cell-formats.png)

## **워크북 셀을 차트 데이터 레이블로 설정**

워크북 셀의 텍스트를 차트 데이터 레이블로 사용할 수 있습니다.

이 예제는 기존 프레젠테이션의 첫 번째 슬라이드에 기본 데이터가 있는 버블 차트를 추가합니다. 워크시트 0의 셀 A10:A12를 첫 번째 시리즈의 첫 세 레이블에 사용하고, 셀에서 레이블을 활성화한 뒤 업데이트된 프레젠테이션을 저장합니다.

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

[ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) 메서드는 차트 워크북의 워크시트에 대한 액세스를 제공합니다. 이 예제는 기본 데이터가 있는 파이 차트를 만들고 각 워크시트 이름을 콘솔에 출력합니다.

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

시리즈 포인트 값은 숫자 리터럴로 직접 저장할 수도 있습니다. 저장 및 읽기를 포함한 전체 예제는 [Set Series Values Using Numeric Literals](/slides/ko/php-java/chart-series/#set-series-values-using-numeric-literals)를 참고하세요. 포인트 값의 소스 유형은 차트의 내부 또는 외부 워크북 구성과 별개이며, 숫자 리터럴을 사용한다고 해서 삽입 워크북이 자동으로 제거되지는 않습니다.

이 예제는 기본 데이터가 있는 3D 컬럼 차트를 만들고 두 개의 시리즈 이름을 서로 다른 데이터 소스로 설정합니다. 첫 번째 이름은 문자열 리터럴을 사용하고, 두 번째는 워크시트 0의 셀 C1을 사용합니다. [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) 열거형은 각 이름의 소스를 선택합니다. 예제는 업데이트된 시리즈 이름으로 프레젠테이션을 저장합니다.

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

## **지원되지 않는 삽입 워크북 형식 감지**

Aspose.Slides는 일부 차트에 삽입될 수 있는 Excel 이진 워크북(.xlsb) 형식을 지원하지 않습니다. [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/)의 `getEmbeddedWorkbookType` 메서드와 [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) 열거형을 함께 사용하여 지원되지 않는 형식을 감지하고 해당 차트를 건너뛸 수 있습니다. 이 예제는 기존 프레젠테이션의 첫 슬라이드에 있는 도형을 검사하고 차트가 아닌 도형은 건너뛰며, 삽입된 .xlsb 워크북을 가진 각 차트에 대해 진단 메시지를 출력합니다.

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

Aspose.Slides는 차트의 데이터 소스로 외부 워크북을 사용하는 것을 지원합니다.

### **외부 워크북 만들기**

[readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/)와 [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/)을 사용하여 삽입 차트 워크북을 파일로 내보내고 차트를 해당 외부 워크북에 연결합니다.

이 예제는 기본 데이터가 있는 파이 차트를 만들고 워크북을 내보냅니다. 외부 워크북을 차트 데이터 소스로 할당하기 전에 파일 쓰기를 완료하고, 연결된 프레젠테이션을 저장합니다.

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

원격 위치나 리소스에 저장된 워크북의 데이터를 편집할 수는 없지만, 이러한 워크북을 외부 데이터 소스로 사용할 수 있습니다. 외부 워크북에 대한 상대 경로가 제공되면 자동으로 전체 경로로 변환됩니다.

이 예제는 `Sheet1`이라는 워크시트에 B1에 시리즈 이름, A2:A4에 카테고리 이름, B2:B4에 숫자 값을 가진 외부 워크북을 사용합니다. 예제는 파이 차트를 만들고 워크북을 연결한 뒤 [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/)을 사용하여 A1:B4를 하나의 시리즈와 세 개의 카테고리에 매핑합니다. 연결된 차트와 함께 프레젠테이션을 저장합니다.

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

* `updateChartData`가 `false`이면 워크북 경로만 업데이트됩니다. 차트 데이터는 대상 워크북에서 로드되거나 업데이트되지 않으므로 워크북이 없어도 됩니다.
* `updateChartData`가 `true`이면 차트 데이터가 대상 워크북에서 업데이트됩니다.

다음 예제는 `updateChartData`를 `false`로 설정하고 자리 표시자 URL을 할당합니다. 파이 차트의 기본 데이터를 유지하고 사용 불가능한 워크북을 로드하지 않은 채 프레젠테이션을 저장합니다.

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

차트에 연결된 워크북을 식별하려면 차트가 외부 데이터 소스를 사용하는지 확인하고 워크북 경로를 가져옵니다.

이 예제는 외부 워크북이 연결된 프레젠테이션의 첫 번째 슬라이드 첫 번째 도형을 검사합니다. 외부 워크북에 연결된 차트인 경우, 예제는 [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/)을 콘솔에 출력합니다. 그런 다음 프레젠테이션 사본을 저장합니다.

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

외부 워크북의 데이터를 내부 워크북 내용 변경과 같은 방식으로 편집할 수 있습니다. 외부 워크북을 로드할 수 없으면 예외가 발생합니다.

이 예제는 첫 번째 슬라이드 첫 번째 도형이며 접근 가능한 외부 워크북에 연결된 차트를 사용합니다. 첫 번째 시리즈의 첫 번째 데이터 포인트 셀 기반 값을 100으로 설정하고 업데이트된 프레젠테이션을 저장합니다. 셀 값을 편집하면 연결된 외부 XLSX 파일이 업데이트될 수 있으므로 원본을 그대로 두어야 하면 복사본을 사용하세요.

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

차트가 누락되었거나 사용할 수 없는 외부 워크북을 사용하는 경우, Aspose.Slides는 프레젠테이션에 캐시된 데이터에서 차트 워크북을 재구성할 수 있습니다. [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/)를 생성하고, [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/)을 호출한 뒤, 프레젠테이션을 열기 전에 [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/)를 `true`로 설정합니다.

다음 PHP 예제는 첫 번째 슬라이드 첫 번째 도형이며 사용 불가능한 외부 워크북을 참조하는 차트에 대한 워크북 데이터를 복구합니다. 복구된 데이터는 [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/)와 [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/)를 통해 액세스합니다:

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

외부 워크북을 사용할 수 없고 복구가 비활성화된 경우, Aspose.Slides는 예외를 발생시킵니다. 캐시된 차트 데이터를 사용하는 것이 허용 가능한 대체 방안인 경우에만 복구를 활성화하세요. 캐시에는 프레젠테이션이 마지막으로 업데이트된 이후 외부 워크북에 대한 변경 사항이 포함되지 않을 수 있습니다.

## **FAQ**

**특정 차트가 외부 워크북에 연결되어 있는지 삽입 워크북인지 확인할 수 있나요?**

네. 차트에는 [data source type](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/)과 [external workbook 경로](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/)가 있습니다; 소스가 외부 워크북인 경우 전체 경로를 읽어 외부 파일이 사용되는지 확인할 수 있습니다.

**외부 워크북에 대한 상대 경로가 지원되며, 어떻게 저장되나요?**

네. 상대 경로를 지정하면 자동으로 절대 경로로 변환됩니다. 프레젠테이션은 PPTX 파일에 절대 경로를 저장하므로 워크북을 이동하면 링크를 업데이트해야 할 수 있습니다.

**네트워크 리소스/공유에 있는 워크북을 사용할 수 있나요?**

네, 이러한 워크북을 외부 데이터 소스로 사용할 수 있습니다. 그러나 Aspose.Slides에서 원격 워크북을 직접 편집하는 것은 지원되지 않으며, 소스로만 사용할 수 있습니다.

**Aspose.Slides가 프레젠테이션 저장 시 외부 XLSX 파일을 덮어쓰나요?**

프레젠테이션은 [외부 파일에 대한 링크](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/)를 저장합니다. 셀 기반 차트 데이터를 편집하면 연결된 로컬 XLSX 파일도 업데이트될 수 있습니다. 원본을 그대로 두어야 하면 워크북 복사본을 사용하세요.

**외부 파일에 비밀번호가 걸려 있다면 어떻게 해야 하나요?**

Aspose.Slides는 연결 시 비밀번호를 받지 않습니다. 일반적인 방법은 미리 보호를 제거하거나 복호화된 복사본(예: [Aspose.Cells](https://reference.aspose.com/cells/java/) 사용)을 준비하고 해당 복사본에 연결하는 것입니다.

**여러 차트가 동일한 외부 워크북을 참조할 수 있나요?**

네. 각 차트는 자체 링크를 저장합니다. 모두 동일한 파일을 가리키는 경우, 해당 파일을 업데이트하면 다음에 데이터가 로드될 때 각 차트에 반영됩니다.