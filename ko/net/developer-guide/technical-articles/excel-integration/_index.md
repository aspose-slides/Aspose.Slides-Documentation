---
title: Excel 데이터를 PowerPoint 프레젠테이션에 통합하기
linktitle: Excel 통합
type: docs
weight: 330
url: /ko/net/excel-integration/
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
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides에서 ExcelDataWorkbook API를 사용하여 Excel 워크북의 데이터를 읽습니다. 시트와 셀을 로드하고 값을 사용하여 데이터 기반 PowerPoint 프레젠테이션을 생성합니다."
---
## **소개**

PowerPoint 프레젠테이션은 정보를 표시하고 전달하는 강력한 방법입니다. 일반적으로 Excel 워크북과 함께 사용되며, Excel은 구조화된 데이터의 훌륭한 소스로, PowerPoint는 청중에게 해당 데이터를 시각화하는 데 뛰어납니다.

Excel과 PowerPoint를 결합해야 하는 실용적인 시나리오는 많이 있습니다: 메일 병합, 데이터 테이블 채우기, 레코드당 하나의 슬라이드 생성(일괄 슬라이드 생성), 교육 자료 만들기, 여러 Excel 보고서를 하나의 프레젠테이션으로 통합하기 등등.

지금까지 이러한 기능을 Aspose.Slides API로 구현하려면 Aspose.Cells와 같은 타사 솔루션에 의존해야 했습니다. 이러한 도구는 강력하지만, 기본적인 데이터 통합 기능만 필요로 하는 사용자에게는 과도하게 복잡하고 비용이 많이 들 수 있습니다.

## **작동 방식**

Excel 데이터 작업을 더 쉽고 간소화하기 위해 Aspose.Slides는 Excel 워크북에서 데이터를 읽고 프레젠테이션에 콘텐츠를 가져오는 새로운 클래스를 도입했습니다. 이 기능은 프레젠테이션 워크플로우 내에서 Excel을 데이터 소스로 활용하려는 API 사용자에게 강력한 새로운 가능성을 열어줍니다.

새 기능은 일반적인 데이터 액세스를 위해 설계되었으며 Presentation Document Object Model(DOM)에 통합되지 않았습니다. 즉, *Excel 파일을 편집하거나 저장할 수 없으며*—그 목적은 워크북을 열고 내용을 탐색하여 셀 데이터를 검색하는 것입니다.

이 기능의 핵심은 새로운 [ExcelDataWorkbook](https://reference.aspose.com/slides/ko/net/aspose.slides.excel/exceldataworkbook/) 클래스입니다. 이 클래스는 로컬 파일 또는 스트림에서 Excel 워크북을 로드할 수 있게 해줍니다. 로드된 후에는 [GetCell](https://reference.aspose.com/slides/ko/net/aspose.slides.excel/exceldataworkbook/getcell/) 메서드의 여러 오버로드를 제공하여 위치(예: 행 및 열 인덱스 또는 명명된 범위) 기반으로 특정 셀을 검색할 수 있습니다.

[GetCell](https://reference.aspose.com/slides/ko/net/aspose.slides.excel/exceldataworkbook/getcell/) 호출마다 [ExcelDataCell](https://reference.aspose.com/slides/ko/net/aspose.slides.excel/exceldatacell/) 클래스의 인스턴스를 반환합니다. 이 객체는 Excel 워크북의 단일 셀을 나타내며 값에 간단하고 직관적인 방식으로 접근할 수 있게 해줍니다.

#### **Excel 차트 가져오기**

기능을 확장하기 위한 다음 단계는 [ExcelWorkbookImporter](https://reference.aspose.com/slides/ko/net/aspose.slides.import/excelworkbookimporter/) 클래스입니다. 이 유틸리티 클래스는 Excel 워크북에서 프레젠테이션으로 콘텐츠를 가져오는 기능을 제공합니다. 여기에는 [AddChartFromWorkbook](https://reference.aspose.com/slides/ko/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) 메서드의 여러 오버로드가 포함되어 있어 지정된 Excel 워크북에서 선택한 차트를 검색하고 지정된 좌표에 있는 대상 shape 컬렉션 끝에 추가할 수 있습니다.

요약하면, 이것은 Excel 데이터를 읽기 위한 가볍고 직관적인 API이며, 전체 스프레드시트 처리 라이브러리의 오버헤드 없이 많은 개발자가 필요로 하는 바로 그 기능입니다.

## **코드 작성**

### **메일 병합 시나리오 예제**

다음 예제에서는 Excel 워크북에 저장된 데이터를 기반으로 여러 프레젠테이션을 생성하여 간단한 메일 병합 시나리오를 구현합니다.

시작하려면 두 가지가 필요합니다:
1. 데이터를 포함한 Excel 워크북

![Excel 데이터 예시](example1_image0.png)

2. PowerPoint 템플릿

![PowerPoint 템플릿 예시](example1_image1.png)

```csharp
// 직원 데이터가 들어 있는 Excel 워크북을 로드합니다.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// 프레젠테이션 템플릿을 로드합니다.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Excel 행을 반복합니다 (행 0의 헤더 제외).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // 각 직원 레코드마다 새 프레젠테이션을 생성합니다.
    using Presentation employeePresentation = new Presentation();

    // 기본 빈 슬라이드를 제거합니다.
    employeePresentation.Slides.RemoveAt(0);

    // 템플릿 슬라이드를 새 프레젠테이션에 복제합니다.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // 대상 도형에서 단락을 가져옵니다 (도형 인덱스 1이 사용된다고 가정).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // 자리표시자를 Excel 데이터로 교체합니다.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // 개인화된 프레젠테이션을 별도 파일로 저장합니다.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![결과](example1_image2.png)

### **Excel 테이블 예제**

두 번째 예제에서는 Excel 테이블의 데이터를 복사하여 PowerPoint 슬라이드에 보다 시각적으로 보기 좋은 형식으로 표시합니다.

이 예제에서는 첫 번째 예제와 동일한 Excel 워크북을 재사용합니다. 해당 워크북에는 간단한 직원 테이블이 포함되어 있습니다.

```csharp
// 직원 데이터를 포함하는 Excel 워크북을 로드합니다.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// 새 PowerPoint 프레젠테이션을 생성합니다.
using Presentation presentation = new Presentation();

// 첫 번째 슬라이드에 표 도형을 추가합니다.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Excel 워크북의 데이터로 PowerPoint 표를 채웁니다.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// 결과 프레젠테이션을 파일에 저장합니다.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![결과](example2_image0.png)

### **Excel 차트 가져오기 예제**

이 예제에서는 이전 예제에서 사용한 Excel 워크북의 첫 번째 워크시트에 있는 차트를 가져옵니다. 차트는 결과 프레젠테이션에서 외부 워크북에 연결됩니다.

먼저 직원 테이블을 기반으로 Excel 워크북에 원형 차트를 추가합니다.

![Excel 차트 예시](example3_image0.png)

```csharp
// 새 PowerPoint 프레젠테이션을 생성합니다.
using Presentation presentation = new Presentation();

// 첫 번째 슬라이드의 도형 컬렉션을 가져옵니다.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// 워크북의 첫 번째 시트에서 "Chart 1"이라는 차트를 가져와 도형 컬렉션에 추가합니다.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// 결과 프레젠테이션을 파일에 저장합니다.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![결과](example3_image1.png)

### **모든 Excel 차트 가져오기 예제**

Excel 워크북에 차트가 많이 들어 있고 이를 모두 프레젠테이션에 가져와야 한다고 가정해 봅시다. 각 차트는 새로운 슬라이드에 배치되어야 합니다.

다음 코드는 소스 Excel 파일의 모든 워크시트를 순회하면서 각 워크시트의 차트를 추출하고, 빈 슬라이드 레이아웃을 사용해 각 차트를 별도의 슬라이드에 추가합니다. 결과 프레젠테이션에는 전체 워크북이 아닌 차트 데이터만 포함됩니다.

```csharp
// 직원 데이터가 포함된 Excel 워크북을 로드합니다.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// 새 PowerPoint 프레젠테이션을 생성합니다.
using Presentation presentation = new Presentation();

// 빈 슬라이드 레이아웃을 가져옵니다.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Excel 워크북에 포함된 모든 워크시트의 이름을 가져옵니다.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // 워크시트에 대해 차트 인덱스를 차트 이름에 매핑하는 사전을 가져옵니다.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // 빈 레이아웃을 사용해 새 슬라이드를 추가합니다.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Excel 워크북에서 지정된 차트를 슬라이드의 도형 컬렉션에 가져옵니다.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// 결과 프레젠테이션을 파일에 저장합니다.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

## **요약**

Aspose.Slides에 직접 포함된 이 메커니즘은 Excel 데이터와 프레젠테이션 작업을 한 곳에서 결합합니다. 별도의 라이브러리나 복잡한 통합 없이 Excel 테이블 형태의 데이터와 시각적 차트가 포함된 슬라이드를 만들 수 있습니다.