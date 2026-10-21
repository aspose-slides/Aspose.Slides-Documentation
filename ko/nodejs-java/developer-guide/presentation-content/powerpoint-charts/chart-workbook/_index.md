---
title: JavaScript를 사용하여 프레젠테이션에서 차트 워크북 관리
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
description: "Java를 통해 Node.js용 Aspose.Slides를 발견하고, PowerPoint 및 OpenDocument 형식에서 차트 워크북을 손쉽게 관리하여 프레젠테이션 데이터를 효율화하십시오."
---
## **개요**

이 문서는 Aspose.Slides에서 차트 워크북을 사용하는 방법을 설명합니다. 워크북 스트림을 통해 차트 데이터를 읽고 쓰는 방법, 워크북 셀을 차트 데이터 레이블로 사용하는 방법, 워크시트 컬렉션에 접근하는 방법, 그리고 차트 값에 대한 데이터 소스 유형을 지정하는 방법을 보여줍니다.

또한 외부 워크북을 차트 데이터 소스로 사용하는 방법도 다룹니다. 예제에서는 외부 워크북을 생성하고 할당하는 방법, 차트에 연결된 외부 워크북의 경로를 가져오는 방법, 워크북이 사용 가능한 경우 차트 데이터를 편집하는 방법을 시연합니다.

워크북 셀에 누락된 데이터가 있는 경우, 빈 셀과 0의 차이 및 사용 가능한 표시 모드의 라인 차트 비교를 위해 [빈 셀 표시 제어](/slides/ko/nodejs-java/chart-series/) 를 참조하십시오.

## **숨겨진 행 및 열의 데이터 포함**

[Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setplotvisiblecellsonly/) 를 사용하여 차트가 숨겨진 워크시트 행 및 열의 데이터를 플롯할지 여부를 제어합니다. `true` 로 설정하면 보이는 셀만 플롯하고, `false` 로 설정하면 보이는 셀과 숨겨진 셀 모두 포함합니다. 이 설정은 차트 플롯팅에만 영향을 주며, 워크시트 행이나 열을 숨기거나 표시하지는 않습니다.

[샘플 프레젠테이션](hidden-source-data.pptx)에는 첫 번째 슬라이드의 첫 번째 도형으로 열 차트가 포함되어 있습니다. 내장 워크시트 `Sheet1`에는 `A1:C4` 범위가 정의되어 있습니다. 3행과 C열은 숨겨져 있지만 셀 값은 그대로 존재합니다.

| 워크시트 행 | A: 월 | B: 소매 | C: 도매 (숨김 열) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (숨김 행) | February | 40 | 60 |
| 4 | March | 20 | 50 |

[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) 으로 소스 셀에 접근하고 [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/ishidden/) 으로 숨김 상태를 확인합니다. 이 메서드는 숨김 상태를 변경하지 않고 보고합니다. 이 파일에서 B2는 보이고, B3은 숨김 행에 속하며, C2는 숨김 열에 속합니다; 예제는 각각 `false`, `true`, `true` 를 출력합니다.

이 예제에서는 플롯 설정을 변경한 후 차트 데이터를 새로 고칩니다: [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) 로 내장 워크북을 유지하고, [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) 로 다시 로드합니다. 모든 셀을 포함할 때는 [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) 를 사용하여 숨겨진 February 범주를 포함한 전체 범위를 복원합니다. 플래그만 변경하는 것으로는 이 샘플의 캐시된 차트 데이터와 범주 레이블을 새로 고칠 수 없습니다. 예제는 반환된 Node.js 버퍼를 Java 바이트 배열로 변환한 뒤 쓰기 메서드에 전달합니다.

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
                // 숨긴 범주를 포함한 전체 소스 범위를 복원합니다.
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

예제는 두 개의 프레젠테이션 버전을 저장합니다: 보이는 소매 값(10 및 20)만 포함한 버전과 모든 6개 값을 포함한 버전입니다. 아래 이미지는 두 플롯 모드를 보여줍니다. 3행과 C열은 두 내장 워크북 모두에서 숨겨진 상태로 유지됩니다.

| 보이는 셀만 (`true`) | 모든 셀 (`false`) |
| --- | --- |
| ![보이는 셀만: 1월과 3월의 소매 값 10 및 20.](hidden_cells_True.png) | ![모든 셀: 1월, 2월, 3월의 소매 및 도매 값.](hidden_cells_False.png) |

값을 포함한 숨김 셀은 빈 셀과 다릅니다. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) 은 누락된 값을 표시하는 방식을 제어하지만 숨겨진 소스 데이터를 포함하거나 제외하지는 않습니다. 예시는 [빈 셀 표시 제어](/slides/ko/nodejs-java/chart-series/#control-the-display-of-empty-cells) 를 참고하십시오.

## **차트 데이터 범위 가져오기**

기존 프레젠테이션에서 워크북 데이터를 업데이트하기 전에, 각 차트가 사용하는 워크시트 셀을 확인하기 위해 소스 범위를 검사합니다. [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getrange/) 메서드는 현재 데이터 범위를 `Sheet1!$A$1:$D$5` 와 같은 워크시트 지정 수식으로 반환합니다. 여기서 `Sheet1` 은 워크시트 이름이며, `!` 로 셀 범위와 구분하고, `$A$1:$D$5` 는 절대 행·열을 나타냅니다.

이 메서드는 차트나 워크북을 변경하지 않고 현재 범위를 읽습니다. 차트가 워크북을 데이터 소스로 사용하지 않는 경우 `InvalidOperationException` 을 Throw 합니다. 자세한 내용은 [ChartData API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) 를 참조하십시오.

이 예제는 프레젠테이션을 열고 각 슬라이드의 도형을 직접 검사하여 차트를 찾습니다. 각 차트의 이름과 소스 범위를 출력합니다. 차트가 워크북을 사용하지 않으면 메시지를 출력하고 다음 차트로 진행합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                const chart = shape;
                try {
                    const range = chart.getChartData().getRange();
                    console.log(chart.getName() + ": " + range);
                } catch (exception) {
                    if (exception.cause && java.instanceOf(exception.cause, "com.aspose.slides.exceptions.InvalidOperationException")) {
                        console.log(chart.getName() + ": The chart does not use a workbook as its data source.");
                    } else {
                        console.log(chart.getName() + ": Could not retrieve the data range: " + exception.message);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **워크북에서 차트 데이터 읽기 및 쓰기**

Aspose.Slides for Node.js via Java 은 [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) 및 [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) 메서드를 제공하여 차트 데이터 워크북( Aspose.Cells 로 편집된 차트 데이터를 포함) 을 읽고 쓸 수 있게 합니다. **Note** 차트 데이터는 동일한 방식으로 구성되어 있거나 원본과 유사한 구조를 가져야 합니다.

이 예제는 첫 번째 슬라이드의 첫 번째 도형으로 차트를 포함한 프레젠테이션을 사용합니다. 내장 워크북을 바이트 배열로 읽고, 기존 시리즈와 범주를 모두 지운 뒤 동일한 워크북을 다시 씁니다. 변경 내용은 메모리에 남으며, 프레젠테이션은 저장되지 않습니다.

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

내장 워크북을 수정된 워크북으로 교체하면 차트는 원래의 시리즈와 범주 컬렉션을 유지합니다. 이 불일치는 [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) 가 인덱스 범위 오류로 실패하게 만들 수 있습니다. 업데이트된 워크북을 차트에 다시 쓰기 전에 기존 시리즈와 범주를 삭제하십시오. 이 예제는 첫 번째 슬라이드의 첫 번째 도형인 차트를 사용합니다. 주석은 워크북 편집이 진행될 위치를 표시합니다; 실행 가능한 예제는 원본 워크북을 다시 쓰고 메모리에서 레이아웃을 검증합니다.

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

        // 여기에서 워크북 바이트를 수정하십시오. 예를 들어, Aspose.Cells를 사용합니다.

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

컬렉션을 비우면 워크북이 다시 쓰이기 전에 오래된 데이터 참조가 제거됩니다. 업데이트된 워크북에 필요한 시리즈와 범주 매핑을 재구성한 뒤 차트를 사용하십시오.

## **워크북 셀에 사용자 정의 숫자 형식 지정**

[ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) 을 사용하여 차트 내장 워크북에서 숫자 값이 표시되는 방식을 제어합니다. 예를 들어, 보고서에서 변환율을 소수점 네 자리 퍼센트로, 계수를 소수점 다섯 자리로 표시해야 할 수 있습니다. 두 값 모두 계산 및 차트 플롯팅을 위해 숫자 형태로 유지합니다.

숫자 형식은 표시 방식만 바꾸며 저장된 값은 변경하지 않습니다. 형식 `0.0000%` 은 `0.125` 를 `12.5000%` 로 표시하지만 저장된 숫자는 `0.125` 로 남습니다. 마찬가지로 `0.00000` 은 `0.1234567` 을 `0.12346` 으로 표시하지만 저장된 값은 라운드되지 않습니다. 사용자 정의 형식이 빈 문자열(`""`)이면 [getPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getpresetnumberformat/) 이 반환하는 형식이 사용됩니다.

다음 예제는 열 차트를 만들고 [getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) 을 통해 셀에 접근합니다. 워크시트 0의 B2 에는 변환율이, C2 에는 계수가 들어 있습니다. 두 셀 모두 차트 값을 제공합니다. 예제는 또한 소스 형식에 연결된 값 레이블을 활성화합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, aspose.slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    const percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    const percentageName = workbook.getCell(0, "B1", "Conversion rate");
    const percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    const precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    const precisionName = workbook.getCell(0, "C1", "Coefficient");
    const precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (let seriesIndex = 0; seriesIndex < chart.getChartData().getSeries().size(); seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

워크북 셀 형식은 차트 축이나 데이터 레이블에 직접 설정된 형식과 별개입니다. 이 예제에서는 각 레이블이 [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) 가 `true` 로 설정되어 소스 셀 값을 표시하고, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) 가 `true` 로 설정되어 소스 숫자 형식을 따릅니다. 프레젠테이션을 저장하고 다시 열면 레이블은 `12.5000%` 와 `0.12346` 을 표시합니다. 수직 축은 [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) 로 `0.00` 를 지정하고, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) 를 `false` 로 설정합니다.

데이터 레이블을 독립적으로 형식 지정하려면 소스 연결 플래그를 `false` 로 설정하고 [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) 로 형식을 지정합니다. 이는 워크북 셀 형식을 변경하지 않습니다. 예를 들어, 독립 레이블 형식 `0.00` 은 첫 번째 값을 `0.13` 으로 표시하지만 B2 는 여전히 `12.5000%` 를 표시합니다. 직접 레이블 형식 지정에 관한 내용은 [차트 데이터 레이블](/slides/ko/nodejs-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) 를 참조하십시오.

아래 이미지는 프레젠테이션을 저장하고 다시 연 후 렌더링된 결과입니다:

![소스 연결 레이블이 12.5000% 와 0.12346 을 표시하고, 독립 형식이 적용된 숫자 축을 가진 열 차트.](custom-cell-formats.png)

## **워크북 셀을 차트 데이터 레이블로 사용**

워크북 셀의 텍스트를 차트 데이터 레이블로 사용할 수 있습니다.

이 예제는 기존 프레젠테이션의 첫 번째 슬라이드에 기본 데이터가 있는 버블 차트를 추가하고, 워크시트 0의 A10:A12 셀을 첫 번째 시리즈의 첫 세 레이블로 사용하며, 셀에서 레이블을 활성화하고 업데이트된 프레젠테이션을 저장합니다.

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

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getworksheets/) 메서드는 차트 워크북에 포함된 워크시트에 접근할 수 있게 합니다. 이 예제는 기본 데이터가 있는 원형 차트를 만들고 각 워크시트 이름을 콘솔에 출력합니다.

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

이 예제는 기본 데이터가 있는 3D 열 차트를 만들고 두 개의 시리즈 이름을 서로 다른 데이터 소스로 설정합니다. 첫 번째 이름은 문자열 리터럴을 사용하고, 두 번째 이름은 워크시트 0의 C1 셀을 사용합니다. [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) 열거형은 각 이름의 소스를 선택합니다. 예제는 업데이트된 시리즈 이름을 포함해 프레젠테이션을 저장합니다.

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

## **지원되지 않는 내장 워크북 형식 감지**

Aspose.Slides는 일부 차트에 포함될 수 있는 Excel 바이너리 워크북(.xlsb) 형식을 지원하지 않습니다. [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) 의 `getEmbeddedWorkbookType` 메서드와 [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) 열거형을 함께 사용하여 지원되지 않는 형식을 감지하고 해당 차트를 건너뛸 수 있습니다. 이 예제는 기존 프레젠테이션의 첫 번째 슬라이드에 있는 도형을 검사하고, 차트가 아닌 도형은 건너뛰며, .xlsb 워크북이 포함된 차트에 대해 진단 메시지를 출력합니다.

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

        // 지원되는 차트 워크북 데이터를 여기에서 읽거나 수정합니다.
    }
} finally {
    presentation.dispose();
}
```

## **외부 워크북**

Aspose.Slides는 외부 워크북을 차트의 데이터 소스로 사용하는 것을 지원합니다.

### **외부 워크북 만들기**

[readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) 와 [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) 을 사용하여 내장 차트 워크북을 파일로 내보내고 차트를 해당 외부 워크북에 연결합니다.

이 예제는 기본 데이터가 있는 원형 차트를 만들고 워크북을 내보냅니다. 파일 쓰기가 완료된 뒤 외부 워크북을 차트 데이터 소스로 할당하고, 연결된 프레젠테이션을 저장합니다.

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

[setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) 메서드를 사용하여 차트에 외부 워크북을 데이터 소스로 지정할 수 있습니다. 이 메서드는 외부 워크북이 이동된 경우 경로를 업데이트하는 데에도 사용할 수 있습니다.

원격 위치나 리소스에 저장된 워크북의 데이터를 직접 편집할 수는 없지만, 외부 데이터 소스로는 사용할 수 있습니다. 외부 워크북에 대한 상대 경로가 제공되면 자동으로 전체 경로로 변환됩니다.

이 예제는 `Sheet1` 워크시트에 B1 에 시리즈 이름, A2:A4 에 범주 이름, B2:B4 에 숫자 값을 가진 외부 워크북을 사용합니다. 원형 차트를 만들고 워크북을 연결한 뒤, [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) 로 A1:B4 를 하나의 시리즈와 세 개의 범주에 매핑합니다. 연결된 차트와 함께 프레젠테이션을 저장합니다.

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

[setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) 의 `updateChartData` 매개변수는 워크북이 로드되는지를 제어합니다.

* `updateChartData` 가 `false` 인 경우, 워크북 경로만 업데이트됩니다. 차트 데이터는 대상 워크북에서 로드되거나 업데이트되지 않으므로 워크북이 없어도 됩니다.
* `updateChartData` 가 `true` 인 경우, 차트 데이터가 대상 워크북에서 업데이트됩니다.

다음 예제는 `updateChartData` 를 `false` 로 설정하고 자리 표시자 URL 을 할당합니다. 기본 데이터가 유지된 원형 차트를 저장하고, 사용 불가능한 워크북은 로드하지 않습니다.

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

차트에 연결된 워크북을 확인하려면 차트가 외부 데이터 소스를 사용하는지 여부를 검사하고 워크북 경로를 가져옵니다.

이 예제는 외부 워크북이 연결된 프레젠테이션의 첫 번째 슬라이드 첫 번째 도형을 검사합니다. 차트가 외부 워크북에 연결된 경우, 콘솔에 [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) 를 출력하고 프레젠테이션 복사본을 저장합니다.

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

외부 워크북의 데이터를 내부 워크북과 동일한 방식으로 편집할 수 있습니다. 외부 워크북을 로드할 수 없으면 예외가 발생합니다.

이 예제는 첫 번째 슬라이드 첫 번째 도형이며 접근 가능한 외부 워크북에 연결된 차트를 사용합니다. 첫 번째 시리즈 첫 번째 데이터 포인트의 셀 기반 값을 100 으로 설정하고 업데이트된 프레젠테이션을 저장합니다. 셀 값을 편집하면 연결된 외부 XLSX 파일도 업데이트되므로, 원본 워크북을 보존해야 할 경우 복사본을 사용하십시오.

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

차트가 누락되었거나 사용 불가능한 외부 워크북을 사용하는 경우, Aspose.Slides 는 프레젠테이션에 캐시된 데이터에서 차트 워크북을 재구성할 수 있습니다. [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) 를 생성하고, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setspreadsheetoptions/) 를 호출한 뒤, [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) 를 `true` 로 설정하고 프레젠테이션을 엽니다.

다음 JavaScript 예제는 첫 번째 슬라이드 첫 번째 도형이며 사용 불가능한 외부 워크북을 참조하는 차트의 워크북 데이터를 복구합니다. 복구된 데이터는 [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getchartdata/) 와 [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) 를 통해 접근합니다:

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

외부 워크북이 사용 불가능하고 복구가 비활성화된 경우, Aspose.Slides 는 예외를 발생시킵니다. 캐시된 차트 데이터를 사용하는 것이 허용 가능한 대체 방안일 때만 복구를 활성화하십시오. 캐시에는 프레젠테이션이 마지막으로 업데이트된 이후 외부 워크북에 적용된 변경 사항이 포함되지 않을 수 있습니다.

## **FAQ**

**특정 차트가 외부 워크북에 연결되어 있는지, 내장 워크북에 연결되어 있는지 확인할 수 있나요?**

네. 차트는 [데이터 소스 유형](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) 과 [외부 워크북 경로](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) 를 가지고 있습니다; 소스가 외부 워크북인 경우 전체 경로를 읽어 외부 파일이 사용되고 있는지 확인할 수 있습니다.

**외부 워크북에 대한 상대 경로가 지원되며, 어떻게 저장되나요?**

네. 상대 경로를 지정하면 자동으로 절대 경로로 변환됩니다. 프레젠테이션은 절대 경로를 PPTX 파일에 저장하므로, 워크북을 이동하면 링크를 업데이트해야 할 수 있습니다.

**네트워크 리소스/공유에 있는 워크북을 사용할 수 있나요?**

네, 이러한 워크북을 외부 데이터 소스로 사용할 수 있습니다. 그러나 Aspose.Slides에서는 원격 워크북을 직접 편집하는 것은 지원되지 않으며, 소스 용도로만 사용할 수 있습니다.

**프레젠테이션 저장 시 Aspose.Slides가 외부 XLSX 파일을 덮어쓰나요?**

프레젠테이션은 [외부 파일에 대한 링크](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) 를 저장합니다. 셀 기반 차트 데이터를 편집하면 연결된 로컬 XLSX 파일도 업데이트될 수 있습니다. 원본 파일을 그대로 두어야 하면 워크북 사본을 사용하십시오.

**외부 파일이 비밀번호로 보호되어 있으면 어떻게 해야 하나요?**

Aspose.Slides는 연결 시 비밀번호를 받지 않습니다. 일반적인 방법은 미리 보호를 해제하거나, 예를 들어 [Aspose.Cells](https://reference.aspose.com/cells/java/) 를 사용해 복호화된 사본을 만든 뒤 해당 사본에 연결하는 것입니다.

**여러 차트가 동일한 외부 워크북을 참조할 수 있나요?**

네. 각 차트는 자체 링크를 저장합니다. 모두 같은 파일을 가리키면 해당 파일을 업데이트했을 때 다음 데이터 로드 시 모든 차트에 반영됩니다.