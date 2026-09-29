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
description: "Java를 통해 PHP용 Aspose.Slides를 발견하고, PowerPoint 및 OpenDocument 형식에서 차트 워크북을 손쉽게 관리하여 프레젠테이션 데이터를 효율화하십시오."
---
## **개요**

이 문서는 Aspose.Slides에서 차트 워크북을 사용하는 방법을 설명합니다. 워크북 스트림을 통해 차트 데이터를 읽고 쓰는 방법, 워크북 셀을 차트 데이터 레이블로 사용하는 방법, 워크시트 컬렉션에 접근하는 방법, 차트 값에 대한 데이터 소스 유형을 지정하는 방법을 보여줍니다.

또한 외부 워크북을 차트 데이터 소스로 사용하는 방법을 다룹니다. 예제에서는 외부 워크북을 생성하고 할당하는 방법, 차트에 연결된 외부 워크북의 경로를 가져오는 방법, 워크북을 사용할 수 있을 때 차트 데이터를 편집하는 방법을 보여줍니다.

누락된 데이터를 나타내는 워크북 셀에 대해서는 [빈 셀 표시 제어](/slides/ko/php-java/chart-series/)를 참조하여 빈 셀과 0의 차이점 및 사용 가능한 표시 모드의 라인 차트 비교를 확인하십시오.

## **숨겨진 행 및 열에서 데이터 포함**

차트가 숨겨진 워크시트 행 및 열의 데이터를 플롯할지 여부를 제어하려면 Chart::setPlotVisibleCellsOnly를 사용합니다. `true`로 설정하면 보이는 셀만 플롯하고, `false`로 설정하면 보이는 셀과 숨겨진 셀 모두 포함합니다. 이 설정은 차트 플롯에만 영향을 주며, 워크시트 행이나 열을 숨기거나 보이게 하지 않습니다.

hidden-source-data.pptx 파일을 다운로드하여 작업 디렉터리에 배치하십시오. 첫 번째 슬라이드에는 첫 번째 도형으로 열 차트가 포함되어 있습니다. 포함된 워크시트 `Sheet1`은 `A1:C4` 범위를 가지고 있습니다. 3행과 C열은 숨겨져 있지만 셀에는 여전히 값이 들어 있습니다.

| 워크시트 행 | A: 월 | B: 소매 | C: 도매 (숨겨진 열) |
| --- | --- | --- | --- |
| 2 | 1월 | 10 | 30 |
| 3 (숨겨진 행) | 2월 | 40 | 60 |
| 4 | 3월 | 20 | 50 |

[ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/getchartdataworkbook/)을 통해 원본 셀에 접근하고 [ChartDataCell::isHidden](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatacell/ishidden/)을 읽어 숨김 상태를 검사합니다. 이 메서드는 상태를 변경하지 않고 숨김 여부만 보고합니다. 이 파일에서는 B2가 보이고, B3은 숨겨진 행에 속하며, C2는 숨겨진 열에 속합니다; 예제는 각각 `false`, `true`, `true`를 출력합니다.

이 예제에서는 플롯 설정을 변경한 후 차트 데이터를 새로 고칩니다: [readWorkbookStream](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/readworkbookstream/)으로 포함된 워크북을 유지하고, [writeWorkbookStream](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/writeworkbookstream/)으로 다시 로드합니다. 모든 셀을 포함할 때는 숨겨진 2월 범주를 복원하기 위해 [setRange](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/setrange/)도 사용합니다. 플래그만 변경하는 것으로는 이 샘플의 캐시된 차트 데이터와 범주 레이블을 새로 고칠 수 없습니다.

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

            // 임베디드 워크북에서 차트 데이터를 새로 고칩니다.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // 숨겨진 카테고리를 포함한 전체 원본 범위를 복원합니다.
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

예제는 보이는 소매 값(10과 20)만 포함한 `hidden_cells_true.pptx`와 모든 6값을 포함한 `hidden_cells_false.pptx`를 저장합니다. 아래 이미지가 두 플롯 모드를 보여줍니다. 3행과 C열은 두 포함된 워크북 모두에서 숨겨진 상태로 유지됩니다.

| 보이는 셀만 (`true`) | 전체 셀 (`false`) |
| --- | --- |
| ![보이는 셀만: 1월과 3월의 소매 값 10 및 20.](hidden_cells_True.png) | ![전체 셀: 1월, 2월, 3월의 소매 및 도매 값.](hidden_cells_False.png) |

값이 있는 숨겨진 셀은 빈 셀과 다릅니다. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chart/setdisplayblanksas/)는 누락된 값을 어떻게 표시할지 제어하지만, 숨겨진 원본 데이터를 포함하거나 제외하지는 않습니다. 예시는 [빈 셀 표시 제어](/slides/ko/php-java/chart-series/#control-the-display-of-empty-cells)에서 확인하십시오.

## **워크북에서 차트 데이터 읽기 및 쓰기**

Aspose.Slides for PHP via Java는 [readWorkbookStream](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/readworkbookstream/) 및 [writeWorkbookStream](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/writeworkbookstream/) 메서드를 제공하여 차트 데이터 워크북( Aspose.Cells로 편집된 차트 데이터 포함)을 읽고 쓸 수 있게 합니다. **Note** 차트 데이터는 동일한 방식으로 구성되어 있거나 원본과 유사한 구조를 가져야 합니다.

이 예제는 첫 번째 슬라이드의 첫 번째 도형에 차트가 포함된 `chart.pptx`를 엽니다. 포함된 워크북을 바이트 배열로 읽고, 기존 시리즈와 카테고리를 지운 다음 동일한 워크북을 다시 씁니다. 변경 사항은 메모리 내에 유지되며, 예제는 프레젠테이션을 저장하지 않습니다.

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

임베디드 워크북을 수정된 워크북으로 교체하면 차트는 원래의 시리즈와 카테고리 컬렉션을 유지합니다. 이 불일치로 인해 [Chart::validateChartLayout](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chart/validatechartlayout/)이 인덱스 초과 오류로 실패할 수 있습니다. 업데이트된 워크북을 차트에 쓰기 전에 기존 시리즈와 카테고리를 지우십시오. 이 예제는 첫 번째 슬라이드의 첫 번째 도형에 차트가 포함된 `chart.pptx`가 필요합니다. 주석은 워크북 편집이 이루어질 위치를 표시하며, 실행 가능한 예제는 원본 워크북을 다시 쓰고 메모리 내 레이아웃을 검증합니다.

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

        // 여기서 워크북 바이트를 수정합니다. 예: Aspose.Cells 사용.

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

컬렉션을 지우면 워크북이 다시 쓰여질 때 오래된 데이터 참조가 제거됩니다. 업데이트된 워크북에 대해 필요한 시리즈와 카테고리 매핑을 다시 구축한 후 차트를 사용하십시오.

## **워크북 셀을 차트 데이터 레이블로 설정**

워크북 셀의 텍스트를 차트 데이터 레이블로 사용할 수 있습니다. 다음 단계는 버블 차트의 레이블을 해당 데이터 워크북의 셀에 연결하는 방법을 보여줍니다.

1. Presentation 클래스의 인스턴스를 생성합니다.
2. 0 기반 인덱스로 첫 번째 슬라이드에 접근합니다.
3. 기본 데이터로 버블 차트를 추가합니다.
4. 차트 시리즈에 접근합니다.
5. 워크북 셀을 데이터 레이블로 설정합니다.
6. 프레젠테이션을 저장합니다.

이 예제는 최소 하나의 슬라이드가 포함된 `chart2.pptx`를 열고 기본 데이터가 있는 버블 차트를 추가합니다. 워크시트 0의 셀 A10:A12를 첫 번째 시리즈의 처음 세 레이블에 사용하고, 셀에서 레이블을 활성화한 뒤 결과를 `resultchart.pptx`에 저장합니다.

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

[ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdataworkbook/getworksheets/) 메서드는 차트 워크북의 워크시트에 대한 접근을 제공합니다. 이 예제는 기본 데이터가 있는 원형 차트를 만들고 각 워크시트 이름을 콘솔에 출력합니다.

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

이 예제는 기본 데이터가 있는 3D 열 차트를 만들고 서로 다른 데이터 소스를 사용하여 두 시리즈 이름을 설정합니다. 첫 번째 이름은 문자열 리터럴을 사용하고, 두 번째 이름은 워크시트 0의 셀 C1을 사용합니다. [DataSourceType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/datasourcetype/) 열거형은 각 이름에 대한 소스를 선택합니다. 결과는 `pres.pptx`에 저장됩니다.

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

## **지원되지 않는 임베디드 워크북 형식 감지**

Aspose.Slides는 일부 차트에 임베디드될 수 있는 Excel 바이너리 워크북(.xlsb) 형식을 지원하지 않습니다. [ChartData](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/)의 `getEmbeddedWorkbookType` 메서드와 [WorkbookType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/workbooktype/) 열거형을 함께 사용하여 지원되지 않는 형식을 감지하고 해당 차트를 건너뛸 수 있습니다. 이 예제는 `sample.pptx`의 첫 번째 슬라이드에 있는 도형을 검사하고, 차트가 아닌 도형은 건너뛰며, 임베디드 .xlsb 워크북이 있는 차트마다 진단 메시지를 출력합니다.

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

        // 여기에서 지원되는 차트 워크북 데이터를 읽거나 수정합니다.
    }
} finally {
    $presentation->dispose();
}
```

## **외부 워크북**

Aspose.Slides는 외부 워크북을 차트의 데이터 소스로 사용하는 것을 지원합니다.

### **외부 워크북 생성**

[readWorkbookStream](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/readworkbookstream/)와 [setExternalWorkbook](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/setexternalworkbook/)를 사용하여 임베디드 차트 워크북을 파일로 내보내고 차트를 해당 외부 워크북에 연결합니다.

이 예제는 기본 데이터가 있는 원형 차트를 만들고 워크북을 `externalWorkbook1.xlsx`에 기록한 뒤 파일 쓰기가 완료되면 차트 데이터 소스로 파일을 할당합니다. 연결된 프레젠테이션은 `externalWorkbook.pptx`에 저장됩니다.

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

[setExternalWorkbook](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/setexternalworkbook/) 메서드를 사용하여 외부 워크북을 차트의 데이터 소스로 할당할 수 있습니다. 이 메서드는 외부 워크북이 이동된 경우 경로를 업데이트하는 데에도 사용할 수 있습니다.

원격 위치나 리소스에 저장된 워크북의 데이터를 직접 편집할 수는 없지만, 이러한 워크북을 외부 데이터 소스로 사용할 수 있습니다. 외부 워크북에 대한 상대 경로가 제공되면 자동으로 절대 경로로 변환됩니다.

이 예제는 작업 디렉터리에 `externalWorkbook.xlsx`가 있어야 합니다. 워크시트 `Sheet1`에는 B1에 시리즈 이름, A2:A4에 카테고리 이름, B2:B4에 숫자 값이 들어 있어야 합니다. 예제는 원형 차트를 만들고 워크북을 연결한 뒤 [setRange](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/setrange/)를 사용해 A1:B4 범위를 하나의 시리즈와 세 개의 카테고리에 매핑합니다. 결과는 `Presentation_with_externalWorkbook.pptx`에 저장됩니다.

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

[setExternalWorkbook](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/setexternalworkbook/)의 `updateChartData` 매개변수는 워크북이 로드되는지를 제어합니다.

- `updateChartData`가 `false`이면 워크북 경로만 업데이트됩니다. 차트 데이터는 대상 워크북에서 로드되거나 업데이트되지 않으므로 워크북이 없을 수도 있습니다.
- `updateChartData`가 `true`이면 차트 데이터가 대상 워크북에서 업데이트됩니다.

다음 예제는 `updateChartData`를 `false`로 설정하고 자리표시자 URL을 할당합니다. 원본 데이터 없이도 차트의 기본 데이터를 유지하고 프레젠테이션을 저장합니다.

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

차트에 연결된 워크북을 식별하려면 먼저 차트가 외부 데이터 소스를 사용하는지 확인합니다. 사용한다면 다음 단계에 따라 워크북 경로를 가져올 수 있습니다.

1. Presentation 클래스의 인스턴스를 생성합니다.
2. 0 기반 인덱스로 첫 번째 슬라이드에 접근합니다.
3. 첫 번째 도형이 차트인지 확인합니다.
4. 차트 데이터 소스 유형을 읽습니다.
5. 소스가 외부 워크북인 경우 경로를 읽습니다.

이 예제는 앞서 만든 `externalWorkbook.pptx`를 열고 첫 번째 슬라이드의 첫 번째 도형을 검사합니다. 차트가 외부 워크북에 연결되어 있으면 콘솔에 [getExternalWorkbookPath](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/getexternalworkbookpath/)를 출력하고, 프레젠테이션 사본을 `Result.pptx`에 저장합니다.

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

외부 워크북의 데이터를 내부 워크북과 같은 방식으로 편집할 수 있습니다. 외부 워크북을 로드할 수 없을 경우 예외가 발생합니다.

이 예제는 첫 번째 슬라이드의 첫 번째 도형에 차트가 포함된 `presentation.pptx`와 접근 가능한 외부 워크북이 필요합니다. 첫 번째 시리즈의 첫 번째 데이터 포인트 값을 100으로 설정하고 결과를 `presentation_out.pptx`에 저장합니다. 셀 값을 편집하면 연결된 외부 XLSX 파일이 업데이트되므로 원본 워크북을 보존하려면 사본을 사용하십시오.

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

차트가 존재하지 않거나 사용할 수 없는 외부 워크북을 사용 중인 경우, Aspose.Slides는 프레젠테이션에 캐시된 데이터를 기반으로 차트 워크북을 재구성할 수 있습니다. [LoadOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/)를 생성하고, [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/setspreadsheetoptions/)를 호출한 뒤, [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ko/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/)를 `true`로 설정한 다음 프레젠테이션을 엽니다.

다음 PHP 예제는 첫 번째 슬라이드의 첫 번째 도형이 사용할 수 없는 외부 워크북을 참조하는 차트인 `presentation.pptx`를 열고, [Chart::getChartData](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chart/getchartdata/)와 [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/getchartdataworkbook/)를 통해 복구된 데이터를 접근합니다:

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

외부 워크북이 사용할 수 없고 복구가 비활성화된 경우 Aspose.Slides는 예외를 발생시킵니다. 캐시된 차트 데이터를 사용하는 것이 허용 가능한 대안인 경우에만 복구를 활성화하십시오. 캐시에는 외부 워크북이 프레젠테이션 마지막 업데이트 이후에 변경된 내용이 포함되지 않을 수 있습니다.

## **FAQ**

**특정 차트가 외부 워크북에 연결되어 있는지, 임베디드 워크북에 연결되어 있는지 확인할 수 있나요?**

예. 차트에는 [data source type](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/getdatasourcetype/)과 [external workbook 경로](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/getexternalworkbookpath/)가 있습니다. 소스가 외부 워크북이면 전체 경로를 읽어 외부 파일이 사용 중인지 확인할 수 있습니다.

**외부 워크북에 대한 상대 경로가 지원되나요? 저장 방식은 어떻습니까?**

예. 상대 경로를 지정하면 자동으로 절대 경로로 변환됩니다. 프레젠테이션은 절대 경로를 PPTX 파일에 저장하므로 워크북을 이동하면 링크를 업데이트해야 할 수 있습니다.

**네트워크 리소스/공유에 있는 워크북을 사용할 수 있나요?**

예, 이러한 워크북을 외부 데이터 소스로 사용할 수 있습니다. 그러나 Aspose.Slides에서 원격 워크북을 직접 편집하는 것은 지원되지 않으며, 소스로만 사용할 수 있습니다.

**프레젠테이션을 저장할 때 Aspose.Slides가 외부 XLSX 파일을 덮어쓰나요?**

프레젠테이션은 [외부 파일에 대한 링크](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/getexternalworkbookpath/)를 저장합니다. 셀 기반 차트 데이터를 편집하면 연결된 로컬 XLSX 파일도 업데이트될 수 있습니다. 원본을 변경하지 않아야 한다면 워크북 사본을 사용하십시오.

**외부 파일이 비밀번호로 보호되어 있으면 어떻게 해야 하나요?**

Aspose.Slides는 연결 시 비밀번호를 받지 못합니다. 일반적인 방법은 미리 보호를 해제하거나 [Aspose.Cells](https://reference.aspose.com/cells/java/)와 같은 도구로 복호화된 사본을 준비한 뒤 해당 사본에 연결하는 것입니다.

**여러 차트가 동일한 외부 워크북을 참조할 수 있나요?**

예. 각 차트는 자체 링크를 저장합니다. 모두 같은 파일을 가리키면 해당 파일을 업데이트할 때마다 다음 데이터 로드 시 모든 차트에 반영됩니다.