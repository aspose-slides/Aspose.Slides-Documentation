---
title: "JavaScript를 사용하여 프레젠테이션에서 차트 워크북 관리"
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
description: "Java를 통해 Node.js용 Aspose.Slides를 발견하고, PowerPoint 및 OpenDocument 형식에서 차트 워크북을 손쉽게 관리하여 프레젠테이션 데이터를 효율화하세요."
---
## **개요**

이 문서는 Aspose.Slides에서 차트 워크북을 사용하는 방법을 설명합니다. 워크북 스트림을 통해 차트 데이터를 읽고 쓰는 방법, 워크북 셀을 차트 데이터 레이블로 사용하는 방법, 워크시트 컬렉션에 접근하는 방법, 차트 값에 대한 데이터 소스 유형을 지정하는 방법을 보여줍니다.

또한 외부 워크북을 차트 데이터 소스로 사용하는 방법도 다룹니다. 예제에서는 외부 워크북을 생성하고 할당하는 방법, 차트에 연결된 외부 워크북의 경로를 가져오는 방법, 워크북이 사용 가능한 경우 차트 데이터를 편집하는 방법을 보여줍니다.

누락된 데이터를 나타내는 워크북 셀에 대해서는 빈 셀과 0의 차이 및 사용 가능한 표시 모드의 라인 차트 비교를 위해 [빈 셀 표시 제어](/slides/ko/nodejs-java/chart-series/) 를 참조하십시오.

## **워크북에서 차트 데이터 읽고 쓰기**

Aspose.Slides는 [readWorkbookStream](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) 및 [writeWorkbookStream](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) 메서드를 제공하며, 이를 통해 차트 데이터 워크북(Aspose.Cells 로 편집된 차트 데이터를 포함)을 읽고 쓸 수 있습니다. **Note** 차트 데이터는 동일한 방식으로 조직되었거나 원본과 유사한 구조여야 합니다.

다음 JavaScript 코드는 샘플 작업을 보여줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var data = chart.getChartData();
    var stream = data.readWorkbookStream();
    data.getSeries().clear();
    data.getCategories().clear();
    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **워크북 수정 후 차트 레이아웃 검증**

임베드된 워크북을 수정된 워크북으로 교체하면 차트는 원래의 시리즈 및 범주 컬렉션을 유지합니다. 이 불일치로 인해 [Chart.validateChartLayout](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Chart#validateChartLayout--) 가 인덱스 범위 초과 오류와 함께 실패할 수 있습니다. 업데이트된 워크북을 차트에 다시 쓰기 전에 기존 시리즈와 범주를 삭제하십시오.

```javascript
// 워크북 스트림을 수정한 후 (예: Aspose.Cells 사용)
var updatedWorkbook = chartData.readWorkbookStream();

// 기존 데이터 참조를 지웁니다.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

컬렉션을 삭제하면 차트 데이터 구조가 새로운 워크북과 일치하게 되어 `validateChartLayout` 이 오류 없이 완료됩니다.

## **워크북 셀을 차트 데이터 레이블로 설정**

1. 새로운 [Presentation](https://apireference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 클래스 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 일부 데이터가 포함된 버블 차트를 추가합니다.  
4. 차트 시리즈에 접근합니다.  
5. 워크북 셀을 데이터 레이블로 설정합니다.  
6. 프레젠테이션을 저장합니다.

다음 JavaScript 코드는 워크북 셀을 차트 데이터 레이블로 설정하는 방법을 보여줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation("chart2.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    var dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    var wb = chart.getChartData().getChartDataWorkbook();
    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));
    pres.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **워크시트 관리**

다음 JavaScript 코드는 [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) 메서드를 사용하여 워크시트 컬렉션에 접근하는 작업을 보여줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    var wb = chart.getChartData().getChartDataWorkbook();
    for (var i = 0; i < wb.getWorksheets().size(); i++) {
        console.log(wb.getWorksheets().get_Item(i).getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **데이터 소스 유형 지정**

다음 JavaScript 코드는 데이터 소스의 유형을 지정하는 방법을 보여줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var val = chart.getChartData().getSeries().get_Item(0).getName();
    val.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    val.setData("LiteralString");
    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **지원되지 않는 임베드 워크북 형식 감지**

Aspose.Slides는 일부 차트에 임베드될 수 있는 Excel 바이너리 워크북(.xlsb) 형식을 지원하지 않습니다. [ChartData](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/) 의 `getEmbeddedWorkbookType` 메서드와 [WorkbookType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/workbooktype/) 열거형을 함께 사용하여 지원되지 않는 형식을 감지하고 해당 차트를 건너뛸 수 있습니다.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapes = slide.getShapes();

    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        let shape = shapes.get_Item(shapeIndex);

        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) continue;

        let chart = shape;
        let chartData = chart.getChartData();

        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro) {
                // .xlsb 형식의 임베드 워크북은 지원되지 않습니다.
                continue;
        }

        // 여기서 차트 워크북 데이터를 읽거나 수정합니다.
    }
} finally {
    presentation.dispose();
}
```

## **외부 워크북**

Aspose.Slides는 차트의 데이터 소스로 외부 워크북을 지원합니다.

### **외부 워크북 생성**

**`readWorkbookStream`** 및 **`setExternalWorkbook`** 메서드를 사용하여 새 외부 워크북을 처음부터 만들거나 내부 워크북을 외부 워크북으로 전환할 수 있습니다.

다음 JavaScript 코드는 외부 워크북 생성 과정을 보여줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fileSystem = require("fs");

var pres = new aspose.slides.Presentation();
try {
    var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    // readWorkbookStream 은 워크북 바이트를 Node Buffer 로 반환합니다.
    var workbookData = chart.getChartData().readWorkbookStream();
    fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **외부 워크북 설정**

**`setExternalWorkbook`** 메서드를 사용하여 외부 워크북을 차트의 데이터 소스로 할당할 수 있습니다. 이 메서드는 외부 워크북의 경로가 변경된 경우 경로를 업데이트하는 데에도 사용할 수 있습니다.

원격 위치나 리소스에 저장된 워크북의 데이터를 편집할 수는 없지만, 이러한 워크북을 외부 데이터 소스로 사용할 수 있습니다. 외부 워크북에 대한 상대 경로가 제공되면 자동으로 전체 경로로 변환됩니다.

다음 JavaScript 코드는 외부 워크북을 설정하는 방법을 보여줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Presentation 클래스의 인스턴스를 생성합니다
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, false);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("externalWorkbook.xlsx");
    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), aspose.slides.ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    pres.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

`setExternalWorkbook` 메서드의 두 번째 매개변수 `updateChartData` 은 Excel 워크북을 로드할지 여부를 지정합니다.

* `updateChartData` 가 `false` 로 설정되면 워크북 경로만 업데이트됩니다—차트 데이터는 대상 워크북에서 로드되거나 업데이트되지 않습니다. 대상 워크북이 존재하지 않거나 사용할 수 없는 상황에서 이 설정을 사용할 수 있습니다.  
* `updateChartData` 가 `true` 로 설정되면 차트 데이터가 대상 워크북에서 업데이트됩니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Presentation 클래스의 인스턴스를 생성합니다
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("http://path/doesnt/exists", false);
    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **차트 외부 데이터 소스 워크북 경로 가져오기**

1. 새로운 [Presentation](https://apireference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 클래스 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 차트 도형에 대한 객체를 생성합니다.  
4. 차트의 데이터 소스를 나타내는 `ChartDataSourceType` 유형에 대한 객체를 생성합니다.  
5. 소스 유형이 외부 워크북 데이터 소스 유형과 동일한지 확인하기 위해 관련 조건을 지정합니다.

다음 JavaScript 코드는 해당 작업을 보여줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Presentation 클래스의 인스턴스를 생성합니다
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var slide = pres.getSlides().get_Item(1);
    var chart = slide.getShapes().get_Item(0);
    var sourceType = chart.getChartData().getDataSourceType();
    if (sourceType == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
        var path = chart.getChartData().getExternalWorkbookPath();
    }
    // 프레젠테이션을 저장합니다
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **차트 데이터 편집**

외부 워크북의 데이터를 내부 워크북의 내용을 변경하는 것과 동일한 방식으로 편집할 수 있습니다. 외부 워크북을 로드할 수 없을 경우 예외가 발생합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Presentation 클래스의 인스턴스를 생성합니다
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var chartData = chart.getChartData();
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    pres.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **차트 캐시에서 워크북 복구**

차트가 존재하지 않거나 사용할 수 없는 외부 워크북을 사용하고 있는 경우, Aspose.Slides는 프레젠테이션에 캐시된 데이터를 기반으로 차트 워크북을 재구성할 수 있습니다. [LoadOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/) 를 생성하고, 이를 [SpreadsheetOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/spreadsheetoptions/) 로 구성한 뒤 프레젠테이션을 열기 전에 `true` 로 설정한 [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) 를 호출합니다.

다음 JavaScript 예제는 사용 불가능한 외부 워크북을 참조하는 프레젠테이션을 열고 [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) 를 통해 복구된 데이터에 접근합니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // 복구된 워크북 데이터를 여기서 읽거나 수정합니다.
} finally {
    presentation.dispose();
}
```

외부 워크북이 사용 불가능하고 복구가 비활성화된 경우 Aspose.Slides는 예외를 발생시킵니다. 캐시된 차트 데이터를 사용 가능한 대체 수단으로 허용할 때만 복구를 활성화하십시오. 캐시에는 프레젠테이션이 마지막으로 업데이트된 이후 외부 워크북에 적용된 변경 사항이 포함되지 않을 수 있습니다.

## **FAQ**

**특정 차트가 외부 워크북에 연결되었는지 임베드된 워크북에 연결되었는지 확인할 수 있나요?**  
네. 차트에는 [데이터 소스 유형](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) 및 [외부 워크북 경로](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) 가 있습니다; 소스가 외부 워크북인 경우 전체 경로를 읽어 외부 파일이 사용되는지 확인할 수 있습니다.

**외부 워크북에 대한 상대 경로가 지원되며, 어떻게 저장되나요?**  
네. 상대 경로를 지정하면 자동으로 절대 경로로 변환됩니다. 이는 프로젝트 이식성을 위해 편리하지만, 프레젠테이션은 절대 경로를 PPTX 파일에 저장한다는 점에 유의하십시오.

**네트워크 리소스/공유에 위치한 워크북을 사용할 수 있나요?**  
네, 이러한 워크북을 외부 데이터 소스로 사용할 수 있습니다. 그러나 Aspose.Slides에서 원격 워크북을 직접 편집하는 것은 지원되지 않으며, 소스로만 사용할 수 있습니다.

**프레젠테이션을 저장할 때 Aspose.Slides가 외부 XLSX를 덮어쓰나요?**  
아니요. 프레젠테이션은 [외부 파일에 대한 링크](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/)를 저장하고 데이터를 읽는 데 사용합니다. 저장 시 외부 파일 자체는 수정되지 않습니다.

**외부 파일이 비밀번호로 보호되어 있으면 어떻게 해야 하나요?**  
Aspose.Slides는 연결 시 비밀번호를 받지 않습니다. 일반적인 방법은 사전에 보호를 해제하거나 복호화된 복사본(예: [Aspose.Cells](/cells/nodejs-java/))을 준비하고 해당 복사본에 연결하는 것입니다.

**여러 차트가 동일한 외부 워크북을 참조할 수 있나요?**  
네. 각 차트는 자체 링크를 저장합니다. 모두 동일한 파일을 가리키면 해당 파일을 업데이트할 때 차트마다 다음 데이터 로드 시 반영됩니다.