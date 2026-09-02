---
title: Java를 사용하여 프레젠테이션에서 차트 워크북 관리
linktitle: 차트 워크북
type: docs
weight: 70
url: /ko/java/chart-workbook/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 발견하세요: PowerPoint 및 OpenDocument 형식에서 차트 워크북을 손쉽게 관리하여 프레젠테이션 데이터를 효율화합니다."
---
## **개요**

이 문서는 Aspose.Slides에서 차트 통합문서(workbook)를 사용하는 방법을 설명합니다. 통합문서 스트림을 통해 차트 데이터를 읽고 쓰는 방법, 통합문서 셀을 차트 데이터 레이블로 사용하는 방법, 워크시트 컬렉션에 액세스하는 방법, 차트 값에 대한 데이터 소스 유형을 지정하는 방법을 보여줍니다.

또한 외부 통합문서를 차트 데이터 소스로 사용하는 방법도 다룹니다. 예제에서는 외부 통합문서를 만들고 할당하는 방법, 차트에 연결된 외부 통합문서의 경로를 가져오는 방법, 통합문서가 사용할 수 있을 때 차트 데이터를 편집하는 방법을 시연합니다.

## **통합문서에서 차트 데이터 읽기 및 쓰기**
Aspose.Slides는 차트 데이터 통합문서( Aspose.Cells로 편집된 차트 데이터를 포함)를 읽고 쓸 수 있는 [ReadWorkbookStream](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IChartData#readWorkbookStream--) 및 [WriteWorkbookStream](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) 메서드를 제공합니다. **Note** 차트 데이터는 동일한 방식으로 구성되었거나 원본과 유사한 구조를 가져야 합니다.

다음 Java 코드는 샘플 작업을 보여줍니다:
```java
Presentation pres = new Presentation("chart.pptx");
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartData data = chart.getChartData();

    byte[] stream = data.readWorkbookStream();

    data.getSeries().clear();
    data.getCategories().clear();

    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) pres.dispose();
}
```

## **워크북 셀을 차트 데이터 레이블로 설정하기**
1. [Presentation](https://apireference.aspose.com/slides/ko/java/com.aspose.slides/presentation) 클래스를 인스턴스화합니다.
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.
3. 일부 데이터가 포함된 버블 차트를 추가합니다.
4. 차트 시리즈에 액세스합니다.
5. 워크북 셀을 데이터 레이블로 설정합니다.
6. 프레젠테이션을 저장합니다.

다음 Java 코드는 워크북 셀을 차트 데이터 레이블로 설정하는 방법을 보여줍니다:
```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
Presentation pres = new Presentation("chart2.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    IDataLabelCollection dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));

    pres.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **워크시트 관리**
다음 Java 코드는 [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) 메서드를 사용하여 워크시트 컬렉션에 액세스하는 작업을 보여줍니다:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook wb =  chart.getChartData().getChartDataWorkbook();
    for (int i = 0; i < wb.getWorksheets().size(); i++)
        System.out.println(wb.getWorksheets().get_Item(i).getName());
} finally {
    if (pres != null) pres.dispose();
}
```

## **데이터 소스 유형 지정**
다음 Java 코드는 데이터 소스 유형을 지정하는 방법을 보여줍니다:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.getChartData().getSeries().get_Item(0).getName();

    val.setDataSourceType(DataSourceType.StringLiterals);
    val.setData("LiteralString");

    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **지원되지 않는 삽입된 통합문서 형식 감지**
Aspose.Slides는 일부 차트에 삽입될 수 있는 Excel 이진 통합문서(.xlsb) 형식을 지원하지 않습니다. 지원되지 않는 형식을 감지하고 해당 차트를 건너뛰려면 [IChartData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IChartData)의 `getEmbeddedWorkbookType` 메서드와 [WorkbookType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/WorkbookType) 열거형을 함께 사용할 수 있습니다.
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // 삽입된 워크북이 .xlsb 형식이며, 지원되지 않습니다.
            continue;
        }

        // 여기에서 차트 워크북 데이터를 읽거나 수정합니다.
    }
} finally {
    presentation.dispose();
}
```

## **외부 통합문서**
{{% alert color="primary" %}} 
[Aspose.Slides 19.4](https://docs.aspose.com/slides/ko/java/aspose-slides-for-java-19-4-release-notes/)에서 차트의 데이터 소스로 외부 통합문서 지원을 구현했습니다.
{{% /alert %}} 

### **외부 통합문서 만들기**
**`readWorkbookStream`** 및 **`setExternalWorkbook`** 메서드를 사용하면 외부 통합문서를 처음부터 만들거나 내부 통합문서를 외부로 전환할 수 있습니다.

다음 Java 코드는 외부 통합문서 생성 과정을 보여줍니다:
```java
Presentation pres = new Presentation();
try {
    final String workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    FileOutputStream fileStream = new FileOutputStream(workbookPath);
    try {
        byte[] workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) fileStream.close();
    }

    chart.getChartData().setExternalWorkbook(workbookPath);

    pres.save("externalWorkbook.pptx", SaveFormat.Pptx);
} catch (IOException e) {    
} finally {
    if (pres != null) pres.dispose();
}
```

### **외부 통합문서 설정하기**
**`setExternalWorkbook`** 메서드를 사용하면 차트에 외부 통합문서를 데이터 소스로 지정할 수 있습니다. 이 메서드는 외부 통합문서가 이동된 경우 경로를 업데이트하는 데에도 사용할 수 있습니다.

원격 위치나 리소스에 저장된 통합문서의 데이터를 편집할 수는 없지만, 이러한 통합문서를 외부 데이터 소스로 사용할 수 있습니다. 외부 통합문서에 대한 상대 경로가 제공되면 자동으로 절대 경로로 변환됩니다.

다음 Java 코드는 외부 통합문서를 설정하는 방법을 보여줍니다:
```java
// Presentation 클래스의 인스턴스를 생성합니다
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.getChartData();

    chartData.setExternalWorkbook("externalWorkbook.xlsx");

    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));

    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    
    pres.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

`setExternalWorkbook` 메서드의 `ChartData` 매개변수는 엑셀 통합문서를 로드할지 여부를 지정하는 데 사용됩니다.

* `ChartData` 값이 `false` 로 설정되면 워크북 경로만 업데이트됩니다—차트 데이터는 대상 워크북에서 로드되거나 업데이트되지 않습니다. 대상 워크북이 존재하지 않거나 사용할 수 없는 경우에 이 설정을 사용할 수 있습니다. 
* `ChartData` 값이 `true` 로 설정되면 차트 데이터가 대상 워크북에서 업데이트됩니다.

```java
// Presentation 클래스의 인스턴스를 생성합니다
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();

    ((ChartData)chartData).setExternalWorkbook("http://path/doesnt/exists", false);

    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **차트의 외부 데이터 소스 워크북 경로 가져오기**
1. [Presentation](https://apireference.aspose.com/slides/ko/java/com.aspose.slides/presentation) 클래스를 인스턴스화합니다.
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.
3. 차트 셰이프에 대한 객체를 생성합니다.
4. 차트 데이터 소스를 나타내는 소스(`ChartDataSourceType`) 유형에 대한 객체를 생성합니다.
5. 소스 유형이 외부 워크북 데이터 소스 유형과 동일한지 여부에 따라 관련 조건을 지정합니다.

다음 Java 코드는 해당 작업을 보여줍니다:
```java
// Presentation 클래스의 인스턴스를 생성합니다
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
	
	// 프레젠테이션을 저장합니다
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **차트 데이터 편집**
외부 통합문서의 데이터를 내부 통합문서의 내용을 변경하는 방식과 동일하게 편집할 수 있습니다. 외부 통합문서를 로드할 수 없으면 예외가 발생합니다.

다음 Java 코드는 설명된 프로세스의 구현 예시입니다:
```java
// Presentation 클래스의 인스턴스를 생성합니다
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = (IChart)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ChartData chartData = (ChartData)chart.getChartData();
    
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    
    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **차트 캐시에서 통합문서 복구**
차트가 누락되었거나 사용 불가능한 외부 통합문서를 사용하는 경우, Aspose.Slides는 프레젠테이션에 캐시된 데이터를 사용하여 차트 통합문서를 재구성할 수 있습니다. [LoadOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/)를 생성하고 [SpreadsheetOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/spreadsheetoptions/)로 구성한 뒤 프레젠테이션을 열기 전에 `true` 로 [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-)를 호출합니다.

다음 Java 예제는 차트가 사용 불가능한 외부 통합문서를 참조하는 프레젠테이션을 열고 [IChart.getChartData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichart/#getChartData--) 및 [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--)를 통해 복구된 데이터에 접근합니다:
```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // 복구된 워크북 데이터를 여기서 읽거나 수정합니다.
} finally {
    presentation.dispose();
}
```

외부 통합문서를 사용할 수 없고 복구가 비활성화된 경우, Aspose.Slides는 예외를 발생시킵니다. 캐시된 차트 데이터를 사용하는 것이 허용 가능한 대안인 경우에만 복구를 활성화하십시오. 캐시에는 프레젠테이션이 마지막으로 업데이트된 이후 외부 통합문서에 적용된 변경 사항이 포함되지 않을 수 있습니다.

## **FAQ**

**특정 차트가 외부 통합문서에 연결되어 있는지 혹은 삽입된 통합문서에 연결되어 있는지 판단할 수 있나요?**  
예. 차트는 [데이터 소스 유형](https://reference.aspose.com/slides/ko/java/com.aspose.slides/chartdata/#getDataSourceType--) 및 [외부 통합문서 경로](https://reference.aspose.com/slides/ko/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--)를 가지고 있습니다; 소스가 외부 통합문서인 경우 전체 경로를 읽어 외부 파일이 사용되고 있는지 확인할 수 있습니다.

**외부 통합문서에 대한 상대 경로가 지원되나요? 또한 어떻게 저장되나요?**  
예. 상대 경로를 지정하면 자동으로 절대 경로로 변환됩니다. 이는 프로젝트 이식성을 높여 주지만, 프레젠테이션이 PPTX 파일에 절대 경로를 저장한다는 점을 유념하십시오.

**네트워크 리소스/공유에 있는 통합문서를 사용할 수 있나요?**  
예, 이러한 통합문서는 외부 데이터 소스로 사용할 수 있습니다. 다만 Aspose.Slides에서 원격 통합문서를 직접 편집하는 것은 지원되지 않으며, 소스로만 사용할 수 있습니다.

**Aspose.Slides가 프레젠테이션을 저장할 때 외부 XLSX 파일을 덮어쓰나요?**  
아니요. 프레젠테이션은 외부 파일에 대한 [링크](https://reference.aspose.com/slides/ko/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--)를 저장하고 데이터를 읽을 때 이를 사용합니다. 프레젠테이션을 저장해도 외부 파일 자체는 변경되지 않습니다.

**외부 파일이 비밀번호로 보호되어 있다면 어떻게 해야 하나요?**  
Aspose.Slides는 연결 시 비밀번호를 받지 않습니다. 일반적인 방법은 미리 보호를 해제하거나 (예: [Aspose.Cells](/cells/java/) 사용) 복호화된 복사본을 준비하고 해당 복사본에 연결하는 것입니다.

**여러 차트가 동일한 외부 통합문서를 참조할 수 있나요?**  
예. 각 차트는 자체 링크를 저장합니다. 모두 동일 파일을 가리키면 해당 파일을 업데이트했을 때 다음에 데이터를 로드할 때 모든 차트에 반영됩니다.