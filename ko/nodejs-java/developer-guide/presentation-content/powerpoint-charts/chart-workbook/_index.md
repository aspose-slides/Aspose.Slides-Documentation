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
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Java를 통해 Node.js용 Aspose.Slides를 발견하고, PowerPoint 및 OpenDocument 형식의 차트 워크북을 손쉽게 관리하여 프레젠테이션 데이터를 간소화하세요."
---
## **개요**

이 문서는 Aspose.Slides에서 차트 워크북을 사용하는 방법을 설명합니다. 워크북 스트림을 통해 차트 데이터를 읽고 쓰는 방법, 워크북 셀을 차트 데이터 레이블로 사용하는 방법, 워크시트 컬렉션에 액세스하는 방법, 차트 값에 대한 데이터 원본 유형을 지정하는 방법을 보여줍니다.

또한 외부 워크북을 차트 데이터 원본으로 사용하는 방법도 다룹니다. 예제에서는 외부 워크북을 생성하고 할당하는 방법, 차트에 연결된 외부 워크북의 경로를 검색하는 방법, 워크북이 있을 때 차트 데이터를 편집하는 방법을 보여줍니다.

## **워크북에서 차트 데이터 읽고 쓰기**

Aspose.Slides는 [readWorkbookStream](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) 및 [writeWorkbookStream](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) 메서드를 제공하여 차트 데이터 워크북( Aspose.Cells로 편집된 차트 데이터를 포함)을 읽고 쓸 수 있습니다. **Note** 차트 데이터는 동일한 방식으로 정리되어 있거나 원본과 유사한 구조를 가져야 합니다.

이 JavaScript 코드는 샘플 작업을 보여줍니다:
```javascript
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

## **워크북 셀을 차트 데이터 레이블로 설정**

1. [Presentation](https://apireference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 통해 슬라이드 참조를 얻습니다.
1. 데이터를 포함한 버블 차트를 추가합니다.
1. 차트 시리즈에 액세스합니다.
1. 워크북 셀을 데이터 레이블로 설정합니다.
1. 프레젠테이션을 저장합니다.

이 JavaScript 코드는 워크북 셀을 차트 데이터 레이블로 설정하는 방법을 보여줍니다:
```javascript
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

이 JavaScript 코드는 [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) 메서드를 사용하여 워크시트 컬렉션에 액세스하는 작업을 보여줍니다:
```javascript
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

## **데이터 원본 유형 지정**

이 JavaScript 코드는 데이터 원본에 대한 유형을 지정하는 방법을 보여줍니다:
```javascript
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

## **지원되지 않는 내장 워크북 형식 감지**

Aspose.Slides는 일부 차트에 포함될 수 있는 Excel 바이너리 워크북(.xlsb) 형식을 지원하지 않습니다. 지원되지 않는 형식을 감지하고 해당 차트를 건너뛰려면 [ChartData](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/)에서 `getEmbeddedWorkbookType` 메서드와 [WorkbookType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/workbooktype/) 열거형을 함께 사용할 수 있습니다.
```js
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
            // 내장 워크북이 .xlsb 형식이며, 지원되지 않습니다.
            continue;
        }

        // 여기서 차트 워크북 데이터를 읽거나 수정합니다.
    }
} finally {
    presentation.dispose();
}
```

## **외부 워크북**

Aspose.Slides는 차트의 데이터 원본으로 외부 워크북을 지원합니다.

### **외부 워크북 만들기**

**`readWorkbookStream`** 및 **`setExternalWorkbook`** 메서드를 사용하면 외부 워크북을 처음부터 만들거나 내부 워크북을 외부 워크북으로 전환할 수 있습니다.

이 JavaScript 코드는 외부 워크북 생성 과정을 보여줍니다:
```javascript
var pres = new aspose.slides.Presentation();
try {
    final var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    var fileStream = java.newInstanceSync("java.io.FileOutputStream", workbookPath);
    try {
        var workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
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

**`setExternalWorkbook`** 메서드를 사용하면 외부 워크북을 차트의 데이터 원본으로 할당할 수 있습니다. 이 메서드는 외부 워크북의 경로가 이동된 경우 경로를 업데이트하는 데에도 사용할 수 있습니다.

원격 위치나 리소스에 저장된 워크북의 데이터를 편집할 수는 없지만, 이러한 워크북을 외부 데이터 원본으로 사용할 수 있습니다. 외부 워크북에 대한 상대 경로가 제공되면 자동으로 전체 경로로 변환됩니다.

이 JavaScript 코드는 외부 워크북을 설정하는 방법을 보여줍니다:
```javascript
// Presentation 클래스 인스턴스를 생성합니다
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

`setExternalWorkbook` 메서드 아래의 `ChartData` 매개변수는 Excel 워크북을 로드할지 여부를 지정하는 데 사용됩니다.

* `ChartData` 값이 `false` 로 설정되면 워크북 경로만 업데이트됩니다—차트 데이터는 대상 워크북에서 로드되거나 업데이트되지 않습니다. 대상 워크북이 없거나 사용할 수 없는 경우 이 설정을 사용할 수 있습니다.
* `ChartData` 값이 `true` 로 설정되면 차트 데이터가 대상 워크북에서 업데이트됩니다.
```javascript
// Presentation 클래스 인스턴스를 생성합니다
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

### **차트 외부 데이터 원본 워크북 경로 가져오기**

1. [Presentation](https://apireference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 통해 슬라이드 참조를 얻습니다.
1. 차트 모양에 대한 객체를 생성합니다.
1. `ChartDataSourceType` 유형의 객체를 생성하여 차트의 데이터 원본을 나타냅니다.
1. 소스 유형이 외부 워크북 데이터 원본 유형과 동일한지에 따라 관련 조건을 지정합니다.

이 JavaScript 코드는 작업을 보여줍니다:
```javascript
// Presentation 클래스 인스턴스를 생성합니다
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

외부 워크북의 데이터를 내부 워크북의 내용을 변경하는 것과 동일한 방식으로 편집할 수 있습니다. 외부 워크북을 로드할 수 없을 때 예외가 발생합니다.

이 JavaScript 코드는 설명된 프로세스의 구현입니다:
```javascript
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

## **FAQ**

**특정 차트가 외부 워크북에 연결되어 있는지 내장 워크북에 연결되어 있는지 확인할 수 있나요?**

예. 차트에는 [데이터 원본 유형](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) 및 [외부 워크북 경로](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/)가 있습니다; 원본이 외부 워크북인 경우 전체 경로를 읽어 외부 파일이 사용되고 있는지 확인할 수 있습니다.

**외부 워크북에 대한 상대 경로가 지원되며, 어떻게 저장되나요?**

예. 상대 경로를 지정하면 자동으로 절대 경로로 변환됩니다. 이는 프로젝트 이식성을 위해 편리하지만, 프레젠테이션이 PPTX 파일에 절대 경로를 저장한다는 점을 유의하세요.

**네트워크 리소스/공유에 위치한 워크북을 사용할 수 있나요?**

예, 이러한 워크북을 외부 데이터 원본으로 사용할 수 있습니다. 다만 Aspose.Slides에서 원격 워크북을 직접 편집하는 것은 지원되지 않으며, 소스용으로만 사용할 수 있습니다.

**프레젠테이션을 저장할 때 Aspose.Slides가 외부 XLSX를 덮어쓰나요?**

아니요. 프레젠테이션은 [외부 파일에 대한 링크](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/)를 저장하고 이를 데이터 읽기에 사용합니다. 프레젠테이션을 저장해도 외부 파일 자체는 수정되지 않습니다.

**외부 파일에 비밀번호가 걸려 있는 경우 어떻게 해야 하나요?**

Aspose.Slides는 연결 시 비밀번호를 받지 않습니다. 일반적인 방법은 미리 보호를 해제하거나 복호화된 복사본(예: [Aspose.Cells](/cells/nodejs-java/) 사용)을 준비하고 해당 복사본에 연결하는 것입니다.

**여러 차트가 동일한 외부 워크북을 참조할 수 있나요?**

예. 각 차트는 자체 링크를 저장합니다. 모두 동일한 파일을 가리키면 해당 파일을 업데이트할 때 다음에 데이터가 로드될 때 각 차트에 반영됩니다.