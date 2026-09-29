---
title: JavaScript를 사용한 프레젠테이션 차트 워크북 관리
linktitle: 차트 워크북
type: docs
weight: 70
url: /ko/nodejs-java/chart-workbook/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 발견하세요: PowerPoint 및 OpenDocument 형식에서 차트 워크북을 손쉽게 관리하여 프레젠테이션 데이터를 간소화합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 차트 통합 문서(workbook)를 사용하는 방법을 설명합니다. 워크북 스트림을 통해 차트 데이터를 읽고 쓰는 방법, 워크북 셀을 차트 데이터 레이블로 사용하는 방법, 워크시트 컬렉션에 접근하는 방법, 차트 값에 대한 데이터 소스 유형을 지정하는 방법을 보여줍니다.

또한 외부 워크북을 차트 데이터 소스로 사용하는 방법도 다룹니다. 예제에서는 외부 워크북을 생성하고 할당하는 방법, 차트에 연결된 외부 워크북의 경로를 가져오는 방법, 워크북을 사용할 수 있을 때 차트 데이터를 편집하는 방법을 보여줍니다.

누락된 데이터를 나타내는 워크북 셀에 대해서는 [Control the Display of Empty Cells](/slides/ko/nodejs-java/chart-series/)를 참조하여 빈 셀과 0의 차이 및 사용 가능한 표시 모드의 선 차트 비교를 확인하십시오.

## **숨겨진 행 및 열의 데이터 포함**

[Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/#setPlotVisibleCellsOnly)를 사용하여 차트가 숨겨진 워크시트 행 및 열의 데이터를 플롯할지 여부를 제어합니다. `true`로 설정하면 표시된 셀만 플롯하고, `false`로 설정하면 표시된 셀과 숨겨진 셀 모두를 포함합니다. 이 설정은 차트 플롯을 제어할 뿐이며 워크시트 행이나 열을 숨기거나 표시하도록 하지 않습니다.

[hidden-source-data.pptx](hidden-source-data.pptx)를 다운로드하여 작업 디렉터리에 놓으십시오. 첫 슬라이드에는 첫 번째 도형으로 열 차트가 포함되어 있습니다. 포함된 워크시트 `Sheet1`에는 `A1:C4` 범위가 있습니다. 3번째 행과 C 열은 숨겨져 있지만 해당 셀에는 여전히 값이 들어 있습니다.

| 워크시트 행 | A: 월 | B: 소매 | C: 도매 (숨겨진 열) |
| --- | --- | --- | --- |
| 2 | 1월 | 10 | 30 |
| 3 (숨겨진 행) | 2월 | 40 | 60 |
| 4 | 3월 | 20 | 50 |

[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook)으로 소스 셀에 접근하고 [ChartDataCell.isHidden](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdatacell/#isHidden)을 읽어 숨김 상태를 확인합니다. 이 메서드는 숨김 상태를 변경하지 않고 보고합니다. 이 파일에서 B2는 표시되고, B3은 숨겨진 행에 속하며, C2는 숨겨진 열에 속합니다; 예제는 각각 `false`, `true`, `true`를 출력합니다.

이 예제에서는 플롯 설정을 변경한 후 차트 데이터를 새로 고칩니다: 포함된 워크북을 [readWorkbookStream](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/#readWorkbookStream)으로 유지하고 [writeWorkbookStream](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream)으로 다시 로드합니다. 모든 셀을 포함할 때는 숨겨진 2월 범주를 포함한 전체 범위를 복원하기 위해 [setRange](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/#setRange)도 사용합니다. 플래그만 변경하는 것으로는 이 샘플의 캐시된 차트 데이터와 범주 레이블을 새로 고치기에 충분하지 않습니다. 예제는 반환된 Node.js 버퍼를 Java 바이트 배열로 변환한 후 쓰기 메서드에 전달합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("hidden-source-data.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const workbook = chart.getChartData().getChartDataWorkbook();
        console.log("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        console.log("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        console.log("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        const workbookBuffer = chart.getChartData().readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);
        for (const visibleOnly of [true, false]) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // 내장 워크북에서 차트 데이터를 새로 고칩니다.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // 숨겨진 범주를 포함한 전체 소스 범위를 복원합니다.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", aspose.slides.SaveFormat.Pptx);
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

예제는 표시된 소매 값(10 및 20)만 포함한 `hidden_cells_true.pptx`와 모든 6개 값을 포함한 `hidden_cells_false.pptx`를 저장합니다. 아래 이미지들은 두 플롯 모드를 보여줍니다. 행 3과 열 C는 두 포함된 워크북 모두에서 숨겨진 상태로 유지됩니다.

| 표시된 셀만 (`true`) | 전체 셀 (`false`) |
| --- | --- |
| ![표시된 셀만: 1월 및 3월의 소매 값 10 및 20.](hidden_cells_True.png) | ![전체 셀: 1월, 2월, 3월의 소매 및 도매 값.](hidden_cells_False.png) |

값이 들어 있는 숨겨진 셀은 빈 셀과 다릅니다. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs)는 누락된 값이 표시되는 방식을 제어하며, 숨겨진 소스 데이터를 포함하거나 제외하지 않습니다. 예제는 [Control the Display of Empty Cells](/slides/ko/nodejs-java/chart-series/#control-the-display-of-empty-cells)를 참고하십시오.

## **워크북에서 차트 데이터 읽기 및 쓰기**

Aspose.Slides for Node.js via Java는 차트 데이터 워크북( Aspose.Cells로 편집된 차트 데이터 포함)을 읽고 쓸 수 있는 [readWorkbookStream](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/#readWorkbookStream)와 [writeWorkbookStream](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) 메서드를 제공합니다. **Note** 차트 데이터는 동일한 방식으로 정리되거나 원본과 유사한 구조를 가져야 합니다.

이 예제는 첫 슬라이드 첫 번째 도형으로 차트를 포함해야 하는 `chart.pptx`를 엽니다. 포함된 워크북을 바이트 배열로 읽고, 기존 시리즈와 범주를 지운 뒤 동일한 워크북을 다시 씁니다. 변경 사항은 메모리에 남으며, 예제는 프레젠테이션을 저장하지 않습니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **워크북 수정 후 차트 레이아웃 검증**

포함된 워크북을 수정된 워크북으로 교체하면 차트는 원래의 시리즈 및 범주 컬렉션을 유지합니다. 이 불일치로 인해 [Chart.validateChartLayout](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/#validateChartLayout)이 인덱스 범위 초과 오류를 일으킬 수 있습니다. 업데이트된 워크북을 차트에 다시 쓰기 전에 기존 시리즈와 범주를 지우십시오. 이 예제는 첫 슬라이드 첫 번째 도형으로 차트를 포함하는 `chart.pptx`가 필요합니다. 주석은 워크북 편집이 발생할 위치를 표시합니다; 실행 가능한 예제는 원본 워크북을 다시 쓰고 메모리 내에서 레이아웃을 검증합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        // 여기에서 워크북 바이트를 수정합니다. 예를 들어 Aspose.Cells를 사용할 수 있습니다.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

컬렉션을 지우면 워크북을 다시 쓰기 전에 오래된 데이터 참조가 제거됩니다. 차트를 사용하기 전에 업데이트된 워크북에 필요한 시리즈 및 범주 매핑을 재구성하십시오.

## **워크북 셀을 차트 데이터 레이블로 설정**

워크북 셀의 텍스트를 차트 데이터 레이블로 사용할 수 있습니다. 다음 단계에서는 버블 차트의 레이블을 해당 데이터 워크북의 셀에 연결하는 방법을 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 0 기반 인덱스로 첫 번째 슬라이드에 접근합니다.
1. 기본 데이터로 버블 차트를 추가합니다.
1. 차트 시리즈에 접근합니다.
1. 워크북 셀을 데이터 레이블로 설정합니다.
1. 프레젠테이션을 저장합니다.

이 예제는 최소 하나의 슬라이드가 포함된 `chart2.pptx`를 열고 기본 데이터로 버블 차트를 추가합니다. 워크시트 0의 셀 A10:A12를 첫 번째 시리즈의 처음 세 레이블로 사용하고, 셀에서 레이블을 활성화한 뒤 결과를 `resultchart.pptx`에 저장합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("chart2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    const series = chart.getChartData().getSeries().get_Item(0);
    const workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **워크시트 관리**

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdataworkbook/#getWorksheets) 메서드는 차트 워크북의 워크시트에 접근할 수 있게 합니다. 이 예제는 기본 데이터로 파이 차트를 만들고 각 워크시트 이름을 콘솔에 출력합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    const workbook = chart.getChartData().getChartDataWorkbook();

    for (let i = 0; i < workbook.getWorksheets().size(); i++) {
        console.log(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **데이터 소스 유형 지정**

이 예제는 기본 데이터로 3D 컬럼 차트를 만들고 서로 다른 데이터 소스를 사용하여 두 개의 시리즈 이름을 설정합니다. 첫 번째 이름은 문자열 리터럴을 사용하고, 두 번째 이름은 워크시트 0의 셀 C1을 사용합니다. [DataSourceType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/datasourcetype/) 열거형은 각 이름의 소스를 선택합니다. 결과는 `pres.pptx`에 저장됩니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    const literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    const cellName = chart.getChartData().getSeries().get_Item(1).getName();
    const nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(aspose.slides.DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **지원되지 않는 포함 워크북 형식 감지**

Aspose.Slides는 일부 차트에 포함될 수 있는 Excel 이진 워크북(.xlsb) 형식을 지원하지 않습니다. [ChartData](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/)에서 [getEmbeddedWorkbookType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) 메서드와 [WorkbookType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/workbooktype/) 열거형을 사용하여 지원되지 않는 형식을 감지하고 해당 차트를 건너뛸 수 있습니다. 이 예제는 `sample.pptx`의 첫 슬라이드에 있는 도형을 검사하고 차트가 아닌 도형을 건너뛰며, 포함된 .xlsb 워크북이 있는 각 차트에 대해 진단 메시지를 출력합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (!(java.instanceOf(shape, "com.aspose.slides.IChart"))) {
            continue;
        }

        const chart = shape;
        const chartData = chart.getChartData();
        const isInternalWorkbook = chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook;
        const isBinaryMacro = chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            console.log("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // 지원되는 차트 워크북 데이터를 여기서 읽거나 수정합니다.
    }
} finally {
    presentation.dispose();
}
```

## **외부 워크북**

Aspose.Slides는 차트의 데이터 소스로 외부 워크북을 사용하는 것을 지원합니다.

### **외부 워크북 만들기**

[readWorkbookStream](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/#readWorkbookStream)와 [setExternalWorkbook](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook)를 사용하여 포함된 차트 워크북을 파일로 내보내고 차트를 해당 외부 워크북에 연결합니다.

이 예제는 기본 데이터로 파이 차트를 만들고 워크북을 `externalWorkbook1.xlsx`에 기록한 뒤 파일 쓰기를 완료하고 차트 데이터 소스로 파일을 할당합니다. 연결된 프레젠테이션은 `externalWorkbook.pptx`에 저장됩니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");
const fileSystem = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    const workbookPath = path.resolve("externalWorkbook1.xlsx");
    const workbookData = chart.getChartData().readWorkbookStream();
    try {
        fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
        chart.getChartData().setExternalWorkbook(workbookPath);
        presentation.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (exception) {
        console.log("Could not write the external workbook: " + exception.message);
    }
} finally {
    presentation.dispose();
}
```

### **외부 워크북 설정**

[setExternalWorkbook](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) 메서드를 사용하면 외부 워크북을 차트의 데이터 소스로 할당할 수 있습니다. 이 메서드는 외부 워크북이 이동된 경우 경로를 업데이트하는 데에도 사용할 수 있습니다.

원격 위치나 리소스에 저장된 워크북의 데이터를 편집할 수는 없지만, 이러한 워크북을 외부 데이터 소스로 사용할 수 있습니다. 외부 워크북에 대한 상대 경로가 제공되면 자동으로 전체 경로로 변환됩니다.

이 예제는 작업 디렉터리에 `externalWorkbook.xlsx`가 있어야 합니다. 워크시트 `Sheet1`에는 B1에 시리즈 이름, A2:A4에 범주 이름, B2:B4에 숫자 값이 포함되어야 합니다. 예제는 파이 차트를 만들고 워크북을 연결한 뒤 [setRange](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/#setRange)를 사용하여 A1:B4를 하나의 시리즈와 세 개의 범주에 매핑합니다. 결과는 `Presentation_with_externalWorkbook.pptx`에 저장됩니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    const chartData = chart.getChartData();
    const workbookPath = path.resolve("externalWorkbook.xlsx");

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setExternalWorkbook](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook)의 `updateChartData` 매개변수는 워크북을 로드할지 여부를 제어합니다.

* `updateChartData`가 `false`인 경우 워크북 경로만 업데이트됩니다. 차트 데이터는 대상 워크북에서 로드되거나 업데이트되지 않으므로 워크북이 없어도 됩니다.
* `updateChartData`가 `true`인 경우 차트 데이터가 대상 워크북에서 업데이트됩니다.

다음 예제는 `updateChartData`를 `false`로 설정한 채 placeholder URL을 할당합니다. 파이 차트의 기본 데이터를 유지하고, 사용할 수 없는 워크북을 로드하지 않은 채 프레젠테이션을 저장합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **차트의 외부 데이터 소스 워크북 경로 가져오기**

차트에 연결된 워크북을 식별하려면 먼저 차트가 외부 데이터 소스를 사용하는지 확인합니다. 사용하는 경우 다음 단계에 따라 워크북 경로를 가져올 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 0 기반 인덱스로 첫 번째 슬라이드에 접근합니다.
1. 첫 번째 도형이 차트인지 확인합니다.
1. 차트 데이터 소스 유형을 읽습니다.
1. 소스가 외부 워크북인 경우 해당 경로를 읽습니다.

이 예제는 앞의 예제에서 만든 `externalWorkbook.pptx`를 열고 첫 슬라이드의 첫 번째 도형을 검사합니다. 외부 워크북에 연결된 차트인 경우 예제는 [getExternalWorkbookPath](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath)를 콘솔에 출력합니다. 그런 다음 프레젠테이션 복사본을 `Result.pptx`에 저장합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("externalWorkbook.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
            console.log(chartData.getExternalWorkbookPath());
        } else {
            console.log("The chart does not use an external workbook.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **차트 데이터 편집**

외부 워크북의 데이터를 내부 워크북의 내용과 동일한 방식으로 편집할 수 있습니다. 외부 워크북을 로드할 수 없으면 예외가 발생합니다.

이 예제는 첫 슬라이드 첫 번째 도형에 차트가 포함된 `presentation.pptx`와 접근 가능한 외부 워크북이 필요합니다. 첫 번째 시리즈의 첫 번째 데이터 포인트에 대한 셀 기반 값을 100으로 설정하고 프레젠테이션을 `presentation_out.pptx`에 저장합니다. 셀 값을 편집하면 연결된 외부 XLSX 파일이 업데이트될 수 있으므로 원본 워크북을 보존하려면 복사본을 사용하십시오.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            const valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
            } else {
                console.log("The first data point is not linked to a workbook cell.");
            }
        } else {
            console.log("The chart has no data points to edit.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **차트 캐시에서 워크북 복구**

차트가 누락되었거나 사용할 수 없는 외부 워크북을 사용하는 경우, Aspose.Slides는 프레젠테이션에 캐시된 데이터를 사용해 차트 워크북을 재구성할 수 있습니다. [LoadOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/)을 생성하고, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions)를 호출한 뒤, 프레젠테이션을 열기 전에 [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache)를 `true`로 설정합니다.

다음 JavaScript 예제는 첫 슬라이드 첫 번째 도형이 사용할 수 없는 외부 워크북을 참조하는 차트여야 하는 `presentation.pptx`를 열고, [Chart.getChartData](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/#getChartData)와 [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook)를 통해 복구된 데이터에 접근합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // 여기에서 복구된 워크북 데이터를 읽거나 수정합니다.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

외부 워크북을 사용할 수 없고 복구가 비활성화된 경우 Aspose.Slides는 예외를 발생시킵니다. 캐시된 차트 데이터를 사용하는 것이 허용되는 대체 방안일 때만 복구를 활성화하세요. 캐시에는 프레젠테이션이 마지막으로 업데이트된 이후 외부 워크북에 적용된 변경 사항이 포함되지 않을 수 있습니다.

## **FAQ**

**특정 차트가 외부 워크북에 연결되어 있는지, 아니면 포함된 워크북에 연결되어 있는지 확인할 수 있나요?**

예. 차트에는 [data source type](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/#getDataSourceType)과 [외부 워크북 경로](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath)가 있습니다; 소스가 외부 워크북인 경우 전체 경로를 읽어 외부 파일이 사용되고 있는지 확인할 수 있습니다.

**외부 워크북에 대한 상대 경로가 지원되며, 어떻게 저장되나요?**

예. 상대 경로를 지정하면 자동으로 절대 경로로 변환됩니다. 프레젠테이션은 PPTX 파일에 절대 경로를 저장하므로 워크북을 이동하면 링크를 업데이트해야 할 수 있습니다.

**네트워크 리소스/공유에 위치한 워크북을 사용할 수 있나요?**

예, 이러한 워크북은 외부 데이터 소스로 사용할 수 있습니다. 다만 Aspose.Slides에서 원격 워크북을 직접 편집하는 것은 지원되지 않으며, 소스로만 사용할 수 있습니다.

**프레젠테이션을 저장할 때 Aspose.Slides가 외부 XLSX를 덮어쓰나요?**

프레젠테이션은 [외부 파일에 대한 링크](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath)를 저장합니다. 셀 기반 차트 데이터를 편집하면 연결된 로컬 XLSX 파일도 업데이트될 수 있습니다. 원본 워크북을 그대로 두어야 한다면 복사본을 사용하십시오.

**외부 파일이 비밀번호로 보호된 경우 어떻게 해야 하나요?**

Aspose.Slides는 연결 시 비밀번호를 받지 않습니다. 일반적인 방법은 사전에 보호를 해제하거나 복호화된 복사본(예: [Aspose.Cells](https://reference.aspose.com/cells/java/) 사용)을 만든 뒤 해당 복사본에 연결하는 것입니다.

**여러 차트가 동일한 외부 워크북을 참조할 수 있나요?**

예. 각 차트는 자체 링크를 저장합니다. 모두 같은 파일을 가리키면 해당 파일을 업데이트할 때마다 다음에 데이터가 로드될 때 각 차트에 반영됩니다.