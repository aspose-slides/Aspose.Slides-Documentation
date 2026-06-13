---
title: Excel 데이터를 PowerPoint 프리젠테이션에 통합
linktitle: Excel 통합
type: docs
weight: 330
url: /ko/java/excel-integration/
keywords:
- Excel
- 워크북
- Excel 읽기
- Excel 통합
- 데이터 소스
- 메일 병합
- 테이블 가져오기
- Excel을 PowerPoint에
- PowerPoint
- 프리젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides에서 ExcelDataWorkbook API를 사용하여 Excel 워크북의 데이터를 읽습니다. 시트와 셀을 로드하고 값을 사용하여 데이터 기반 PowerPoint 프리젠테이션을 생성합니다."
---
## **Introduction**

PowerPoint 프리젠테이션은 정보를 표시하고 전달하는 강력한 방법입니다. 이 프리젠테이션은 종종 Excel 워크북과 함께 사용되며, Excel은 구조화된 데이터의 훌륭한 공급원 역할을 하고 PowerPoint는 청중을 위한 데이터 시각화에 뛰어납니다.

Excel과 PowerPoint를 결합해야 하는 실용적인 시나리오가 많이 있습니다: 메일 병합, 데이터 테이블 채우기, 데이터 레코드당 하나의 슬라이드 생성(배치 슬라이드 생성), 교육 자료 만들기, 여러 Excel 보고서를 하나의 프리젠테이션으로 통합하기 등.

지금까지 Aspose.Slides API로 이러한 기능을 구현하려면 Aspose.Cells와 같은 서드파티 솔루션에 의존해야 했습니다. 이러한 도구는 강력하지만 기본적인 데이터 통합 기능만 필요한 사용자에게는 과도하게 복잡하고 비용이 많이 들 수 있습니다.

## **How It Works**

Excel 데이터를 보다 쉽고 효율적으로 작업할 수 있도록 Aspose.Slides는 Excel 워크북에서 데이터를 읽고 프리젠테이션에 내용을 가져오는 새로운 클래스를 도입했습니다. 이 기능은 프리젠테이션 워크플로우에서 Excel을 데이터 소스로 활용하려는 API 사용자에게 강력한 새로운 가능성을 열어줍니다.

새 기능은 일반적인 데이터 접근을 위해 설계되었으며 Presentation Document Object Model(DOM)에 통합되지 않았습니다. 즉, *Excel 파일을 편집하거나 저장할 수 없습니다* — 이 기능의 유일한 목적은 워크북을 열고 내용을 탐색하여 셀 데이터를 가져오는 것입니다.

이 기능의 핵심은 새로운 [ExcelDataWorkbook](https://reference.aspose.com/slides/ko/java/com.aspose.slides/exceldataworkbook/) 클래스입니다. 이 클래스는 로컬 파일이나 스트림에서 Excel 워크북을 로드할 수 있게 해줍니다. 로드된 후에는 [getCell](https://reference.aspose.com/slides/ko/java/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) 메서드의 여러 오버로드를 제공하여 위치(예: 행 및 열 인덱스 또는 이름 범위)로 특정 셀을 가져올 수 있습니다.

[getCell](https://reference.aspose.com/slides/ko/java/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) 호출마다 [ExcelDataCell](https://reference.aspose.com/slides/ko/java/com.aspose.slides/exceldatacell/) 클래스의 인스턴스를 반환합니다. 이 객체는 Excel 워크북의 단일 셀을 나타내며 그 값을 간단하고 직관적인 방식으로 접근할 수 있게 해줍니다.

#### **Import an Excel Chart**

기능을 확장하는 다음 단계는 [ExcelWorkbookImporter](https://reference.aspose.com/slides/ko/java/com.aspose.slides/excelworkbookimporter/) 클래스입니다. 이 유틸리티 클래스는 Excel 워크북에서 프리젠테이션으로 내용을 가져오는 기능을 제공합니다. 여기에는 [addChartFromWorkbook](https://reference.aspose.com/slides/ko/java/com.aspose.slides/excelworkbookimporter/#addChartFromWorkbook-com.aspose.slides.IShapeCollection-float-float-com.aspose.slides.IExcelDataWorkbook-java.lang.String-int-boolean-) 메서드의 여러 오버로드가 포함되어 있어 지정된 Excel 워크북에서 선택한 차트를 가져와 지정된 좌표에 주어진 Shape 컬렉션의 끝에 추가할 수 있습니다.

요약하면, 이것은 Excel 데이터를 읽기 위한 가벼우면서 직관적인 API이며, 전체 스프레드시트 처리 라이브러리의 부담 없이 많은 개발자가 필요로 하는 바로 그 기능입니다.

## **Let's Code**

### **Mail Merge Scenario Example**

다음 예제에서는 Excel 워크북에 저장된 데이터를 기반으로 여러 프리젠테이션을 생성하여 간단한 메일 병합 시나리오를 구현합니다.

시작하려면 두 가지가 필요합니다:
1. 데이터를 포함한 Excel 워크북

![Excel 데이터 예시](example1_image0.png)

2. PowerPoint 프리젠테이션 템플릿

![PowerPoint 템플릿 예시](example1_image1.png)

```java
// 직원 데이터가 포함된 Excel 워크북을 로드합니다.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// 프리젠테이션 템플릿을 로드합니다.
Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Excel 행을 반복합니다 (행 0의 헤더 제외).
    for (int rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // 각 직원 레코드마다 새 프리젠테이션을 생성합니다.
        Presentation employeePresentation = new Presentation();

        try {
            // 기본 빈 슬라이드를 제거합니다.
            employeePresentation.getSlides().removeAt(0);

            // 템플릿 슬라이드를 새 프리젠테이션에 복제합니다.
            ISlide slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // 대상 모양에서 단락을 가져옵니다 (모양 인덱스 1이 사용된다고 가정).
            IParagraphCollection paragraphs = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame().getParagraphs();

            // 플레이스홀더를 Excel 데이터로 교체합니다.
            String employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            IPortion namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            String department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            IPortion departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            String yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            IPortion yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // 개인화된 프리젠테이션을 별도 파일로 저장합니다.
            employeePresentation.save(String.format("%s Report.pptx", employeeName), SaveFormat.Pptx);
        } finally {
            employeePresentation.dispose();
        }
    }
} finally {
    templatePresentation.dispose();
}
```

![결과](example1_image2.png)

### **Excel Table Example**

두 번째 예제에서는 Excel 테이블의 데이터를 복사하여 PowerPoint 슬라이드에 보다 시각적으로 보기 좋은 형식으로 표시합니다.

이 예제에서는 첫 번째 예제와 동일한 Excel 워크북을 재사용하며, 이 워크북에는 간단한 직원 테이블이 포함되어 있습니다.

```java
// 직원 데이터를 포함한 Excel 워크북을 로드합니다.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// 새 PowerPoint 프리젠테이션을 생성합니다.
Presentation presentation = new Presentation();

try {
    // 첫 번째 슬라이드에 테이블 도형을 추가합니다.
    ITable table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            new double[]{200, 200, 200},
            new double[]{30, 30, 30, 30, 30}
    );

    // Excel 워크북의 데이터로 PowerPoint 테이블을 채웁니다.
    for (int rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
            String cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // 결과 프리젠테이션을 파일에 저장합니다.
    presentation.save("Table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![결과](example2_image0.png)

### **Import an Excel Chart Example**

이 예제에서는 이전 예제에 사용된 Excel 워크북의 첫 번째 워크시트에서 차트를 가져옵니다. 차트는 결과 프리젠테이션에서 외부 워크북에 연결됩니다.

먼저, 직원 테이블을 기반으로 Excel 워크북에 원형 차트를 추가합니다.

![Excel 차트 예시](example3_image0.png)

```java
// 새 PowerPoint 프리젠테이션을 생성합니다.
Presentation presentation = new Presentation();
try {
    // 첫 번째 슬라이드의 도형 컬렉션을 가져옵니다.
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    // 워크북의 첫 번째 시트에서 "Chart 1"이라는 차트를 가져와 도형 컬렉션에 추가합니다.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // 결과 프리젠테이션을 파일에 저장합니다.
    presentation.save("Chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![결과](example3_image1.png)

### **Import All Excel Charts Example**

차트가 가득한 Excel 워크북이 있고 이를 모두 프리젠테이션에 가져와야 한다고 가정해 보겠습니다. 각 차트는 새로운 슬라이드에 배치되어야 합니다.

다음 코드는 원본 Excel 파일의 모든 워크시트를 순회하면서 각 워크시트에서 차트를 추출하고 빈 슬라이드 레이아웃을 사용하여 각 차트를 별도의 슬라이드에 추가합니다. 결과 프리젠테이션에는 전체 워크북이 아니라 차트 데이터만 삽입됩니다.

```java
// 직원 데이터가 포함된 Excel 워크북을 로드합니다.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// 새 PowerPoint 프리젠테이션을 생성합니다.
Presentation presentation = new Presentation();
try {
    // 빈 슬라이드 레이아웃을 가져옵니다.
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Excel 워크북에 포함된 모든 워크시트 이름을 가져옵니다.
    List<String> worksheetNames = workbook.getWorksheetNames();

    for (String name : worksheetNames) {
        // 워크시트에 대한 차트 인덱스를 차트 이름에 매핑하는 맵을 가져옵니다.
        Dictionary<Integer, String> worksheetCharts = workbook.getChartsFromWorksheet(name);

        for (KeyValuePair<Integer, String> chart : worksheetCharts) {
            // 빈 레이아웃을 사용하여 새 슬라이드를 추가합니다.
            ISlide slide = presentation.getSlides().addEmptySlide(blankLayout);

            // 지정된 차트를 Excel 워크북에서 슬라이드의 도형 컬렉션으로 가져옵니다.
            ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // 결과 프리젠테이션을 파일에 저장합니다.
    presentation.save("Charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Summary**

Aspose.Slides에서 직접 사용할 수 있는 이 메커니즘은 Excel 데이터와 프리젠테이션 작업을 하나의 장소에서 결합합니다. 추가 라이브러리나 복잡한 통합 없이 시각적 차트와 Excel 테이블 형태의 데이터가 포함된 슬라이드를 만들 수 있습니다.