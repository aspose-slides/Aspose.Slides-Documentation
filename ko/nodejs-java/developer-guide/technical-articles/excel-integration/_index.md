---
title: Excel 데이터를 PowerPoint 프레젠테이션에 통합하기
linktitle: Excel 통합
type: docs
weight: 330
url: /ko/nodejs-java/excel-integration/
keywords:
- 엑셀
- 워크북
- 엑셀 읽기
- 엑셀 통합
- 데이터 원본
- 메일 머지
- 테이블 가져오기
- Excel을 PowerPoint에
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides를 사용하여 JavaScript에서 Excel 워크북의 데이터를 읽습니다. 시트와 셀을 로드하고 값을 사용하여 데이터 기반 PowerPoint 프레젠테이션을 생성합니다."
---
## **소개**

PowerPoint 프레젠테이션은 정보를 표시하고 전달하는 강력한 방법입니다. Excel 워크북과 함께 사용되는 경우가 많으며, Excel은 구조화된 데이터의 훌륭한 소스 역할을 하고 PowerPoint는 청중을 위해 해당 데이터를 시각화하는 데 뛰어납니다.

Excel과 PowerPoint를 결합하는 것이 필수적인 실용적인 시나리오가 많이 있습니다: 메일 머지, 데이터 테이블 채우기, 데이터 레코드당 하나의 슬라이드 생성(배치 슬라이드 생성), 교육 자료 만들기, 여러 Excel 보고서를 단일 프레젠테이션으로 통합하기 등.

지금까지 Aspose.Slides API로 이러한 기능을 구현하려면 Aspose.Cells와 같은 써드파티 솔루션에 의존해야 했습니다. 이러한 도구는 견고하지만 기본적인 데이터 통합 기능만 필요한 사용자에게는 과도하게 복잡하고 비용이 많이 들 수 있습니다.

## **작동 방식**

Excel 데이터 작업을 더 쉽고 효율적으로 만들기 위해 Aspose.Slides는 Excel 워크북에서 데이터를 읽고 프레젠테이션에 콘텐츠를 가져오는 새로운 클래스를 도입했습니다. 이 기능은 프레젠테이션 워크플로우 내에서 Excel을 데이터 소스로 활용하려는 API 사용자에게 강력한 새로운 가능성을 열어줍니다.

새 기능은 일반 목적 데이터 액세스를 위해 설계되었으며 Presentation Document Object Model(DOM)에 통합되지 않았습니다. 즉, *Excel 파일을 편집하거나 저장할 수 없습니다* — 그 유일한 목적은 워크북을 열고 내용을 탐색하여 셀 데이터를 검색하는 것입니다.

이 기능의 핵심은 새로운 [ExcelDataWorkbook](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/exceldataworkbook/) 클래스입니다. 이 클래스는 로컬 파일이나 스트림에서 Excel 워크북을 로드할 수 있게 해줍니다. 로드된 후에는 [getCell](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/exceldataworkbook/#getCell) 메서드의 여러 오버로드를 제공하며, 이를 사용해 위치(예: 행 및 열 인덱스 또는 이름이 지정된 범위)로 특정 셀을 가져올 수 있습니다.

[getCell](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/exceldataworkbook/#getCell) 호출마다 [ExcelDataCell](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/exceldatacell/) 클래스의 인스턴스를 반환합니다. 이 객체는 Excel 워크북의 단일 셀을 나타내며 해당 값을 간단하고 직관적인 방식으로 액세스할 수 있게 해줍니다.

#### **Excel 차트 가져오기**

기능을 확장하기 위한 다음 단계는 [ExcelWorkbookImporter](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/excelworkbookimporter/) 클래스입니다. 이 유틸리티 클래스는 Excel 워크북에서 프레젠테이션으로 콘텐츠를 가져오는 기능을 제공합니다. 여기에는 [addChartFromWorkbook](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook) 메서드의 여러 오버로드가 포함되어 있으며, 지정된 Excel 워크북에서 선택한 차트를 가져와 지정된 좌표에 있는 해당 모양 컬렉션의 끝에 추가하는 데 도움을 줍니다.

요약하면, 이는 Excel 데이터를 읽기 위한 가볍고 직관적인 API이며, 전체 스프레드시트 처리 라이브러리의 오버헤드 없이 많은 개발자가 필요로 하는 바로 그 기능입니다.

## **코드 작성**

### **메일 머지 시나리오 예시**

다음 예제에서는 Excel 워크북에 저장된 데이터를 기반으로 여러 프레젠테이션을 생성하여 간단한 메일 머지 시나리오를 구현합니다.

시작하려면 두 가지가 필요합니다:
1. 데이터를 포함한 Excel 워크북

![Excel 데이터 예시](example1_image0.png)

2. PowerPoint 프레젠테이션 템플릿

![PowerPoint 템플릿 예시](example1_image1.png)

```js
// 직원 데이터가 포함된 Excel 워크북을 로드합니다.
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// 프레젠테이션 템플릿을 로드합니다.
let templatePresentation = new aspose.slides.Presentation("PresentationTemplate.pptx");

try {
    // Excel 행을 순회합니다 (행 0의 헤더 제외).
    for (let rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // 각 직원 레코드마다 새로운 프레젠테이션을 생성합니다.
        let employeePresentation = new aspose.slides.Presentation();

        try {
            // 기본 빈 슬라이드를 제거합니다.
            employeePresentation.getSlides().removeAt(0);

            // 템플릿 슬라이드를 새 프레젠테이션에 복제합니다.
            let slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // 대상 도형에서 단락을 가져옵니다 (도형 인덱스 1이 사용된다고 가정).
            let paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs();

            // Excel 데이터로 자리표시자를 교체합니다.
            let employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            let namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            let department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            let departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            let yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            let yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // 개인화된 프레젠테이션을 별도 파일로 저장합니다.
            employeePresentation.save(`${employeeName} Report.pptx`, aspose.slides.SaveFormat.Pptx);
        } finally {
            employeePresentation.dispose();
        }
    }
} finally {
    templatePresentation.dispose();
}
```

![결과](example1_image2.png)

### **Excel 테이블 예시**

두 번째 예제에서는 Excel 테이블의 데이터를 복사하여 PowerPoint 슬라이드에 더 시각적으로 보기 좋게 표시합니다.

이 예제에서는 첫 번째 예제와 동일한 Excel 워크북을 재사용하며, 여기에는 간단한 직원 테이블이 포함되어 있습니다.

```js
// 직원 데이터가 포함된 Excel 워크북을 로드합니다.
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// 새 PowerPoint 프레젠테이션을 생성합니다.
let presentation = new aspose.slides.Presentation();

try {
    // 첫 번째 슬라이드에 테이블 도형을 추가합니다.
    let table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            java.newArray("double", [200, 200, 200]),
            java.newArray("double", [30, 30, 30, 30, 30])
    );

    // Excel 워크북의 데이터로 PowerPoint 테이블을 채웁니다.
    for (let rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (let columnIndex = 0; columnIndex < 3; columnIndex++) {
            let cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // 결과 프레젠테이션을 파일로 저장합니다.
    presentation.save("Table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![결과](example2_image0.png)

### **Excel 차트 가져오기 예시**

이 예제에서는 이전 예제에서 사용된 Excel 워크북의 첫 번째 워크시트에서 차트를 가져옵니다. 해당 차트는 결과 프레젠테이션에서 외부 워크북에 연결됩니다.

먼저, 직원 테이블을 기반으로 Excel 워크북에 원형 차트를 추가합니다.

![Excel 차트 예시](example3_image0.png)

```js
// 새 PowerPoint 프레젠테이션을 생성합니다.
let presentation = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드의 도형 컬렉션을 가져옵니다.
    let shapes = presentation.getSlides().get_Item(0).getShapes();

    // 워크북의 첫 번째 시트에서 "Chart 1" 차트를 가져와 도형 컬렉션에 추가합니다.
    aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // 결과 프레젠테이션을 파일로 저장합니다.
    presentation.save("Chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![결과](example3_image1.png)

### **모든 Excel 차트 가져오기 예시**

Excel 워크북에 차트가 가득하고 이를 모두 프레젠테이션으로 가져와야 한다고 가정해 보겠습니다. 각 차트는 새로운 슬라이드에 배치되어야 합니다.

다음 코드는 소스 Excel 파일의 모든 워크시트를 순회하면서 각 워크시트에서 차트를 추출하고, 빈 슬라이드 레이아웃을 사용해 각 차트를 별도의 슬라이드에 추가합니다. 결과 프레젠테이션에는 차트 데이터만 포함되고 전체 워크북은 포함되지 않습니다.

```js
// 직원 데이터가 포함된 Excel 워크북을 로드합니다.
let workbook = new aspose.slides.ExcelDataWorkbook("ExcelWithCharts.xlsx");

// 새 PowerPoint 프레젠테이션을 생성합니다.
let presentation = new aspose.slides.Presentation();
try {
    // 빈 슬라이드 레이아웃을 가져옵니다.
    let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

    // Excel 워크북에 포함된 모든 워크시트 이름을 가져옵니다.
    let worksheetNames = workbook.getWorksheetNames().iterator();

    while (worksheetNames.hasNext()) {
        let name = worksheetNames.next();
        // 워크시트의 차트 인덱스를 차트 이름에 매핑하는 맵을 가져옵니다.
        let worksheetCharts = workbook.getChartsFromWorksheet(name).iterator();

        while (worksheetCharts.hasNext()) {
            let chart = worksheetCharts.next();
            // 빈 레이아웃을 사용해 새 슬라이드를 추가합니다.
            let slide = presentation.getSlides().addEmptySlide(layoutSlide);

            // 지정된 차트를 Excel 워크북에서 슬라이드의 도형 컬렉션으로 가져옵니다.
            aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // 결과 프레젠테이션을 파일로 저장합니다.
    presentation.save("Charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **요약**

Aspose.Slides에서 직접 사용할 수 있는 이 메커니즘은 Excel 데이터와 프레젠테이션 작업을 한 곳에서 결합합니다. 별도의 라이브러리나 복잡한 통합 없이 시각적 차트와 Excel 테이블 형태의 데이터가 포함된 슬라이드를 만들 수 있습니다.