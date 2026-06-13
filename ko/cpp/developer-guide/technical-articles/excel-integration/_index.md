---
title: Excel 데이터를 PowerPoint 프레젠테이션에 통합하기
linktitle: Excel 통합
type: docs
weight: 330
url: /ko/cpp/excel-integration/
keywords:
- Excel
- 통합 문서
- Excel 읽기
- Excel 통합
- 데이터 원본
- 메일 머지
- 표 가져오기
- Excel을 PowerPoint에
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides에서 ExcelDataWorkbook API를 사용하여 Excel 통합 문서의 데이터를 읽습니다. 시트와 셀을 로드하고 값을 사용하여 데이터 기반 PowerPoint 프레젠테이션을 생성합니다."
---
## **소개**

PowerPoint 프레젠테이션은 정보를 표시하고 전달하는 강력한 방법입니다. 보통 Excel 통합 문서와 함께 사용되며, Excel은 구조화된 데이터를 제공하는 훌륭한 소스이고 PowerPoint는 그 데이터를 청중에게 시각화하는 데 뛰어납니다.

Excel과 PowerPoint를 결합해야 하는 실용적인 시나리오는 많습니다: 메일 머지, 데이터 테이블 채우기, 레코드당 하나의 슬라이드 생성(배치 슬라이드 생성), 교육 자료 만들기, 여러 Excel 보고서를 단일 프레젠테이션으로 통합하기 등입니다.

지금까지 이러한 기능을 Aspose.Slides API로 구현하려면 Aspose.Cells와 같은 써드파티 솔루션에 의존해야 했습니다. 이러한 도구는 강력하지만 기본적인 데이터 통합 기능만 필요한 사용자에게는 과도하게 복잡하고 비용이 많이 들 수 있습니다.

## **작동 방식**

Excel 데이터를 더 쉽고 간소화된 방식으로 작업할 수 있도록 Aspose.Slides는 Excel 통합 문서에서 데이터를 읽고 프레젠테이션에 내용을 가져오는 새로운 클래스를 도입했습니다. 이 기능은 프레젠테이션 워크플로우 내에서 Excel을 데이터 소스로 활용하려는 API 사용자에게 강력한 새로운 가능성을 엽니다.

새 기능은 일반 목적의 데이터 액세스를 위해 설계되었으며 Presentation Document Object Model(DOM)에 통합되지 않았습니다. 즉, *Excel 파일을 편집하거나 저장할 수 없습니다* — 이 기능의 유일한 목적은 통합 문서를 열고 내용을 탐색하여 셀 데이터를 가져오는 것입니다.

이 기능의 핵심은 새로운 [ExcelDataWorkbook](https://reference.aspose.com/slides/ko/cpp/aspose.slides.excel/exceldataworkbook/) 클래스입니다. 이 클래스는 로컬 파일이나 스트림에서 Excel 통합 문서를 로드할 수 있게 해 줍니다. 로드된 후에는 [GetCell](https://reference.aspose.com/slides/ko/cpp/aspose.slides.excel/exceldataworkbook/getcell/) 메서드의 여러 오버로드를 사용해 위치(예: 행 및 열 인덱스 또는 이름이 지정된 범위)로 특정 셀을 검색할 수 있습니다.

[GetCell](https://reference.aspose.com/slides/ko/cpp/aspose.slides.excel/exceldataworkbook/getcell/)을 호출하면 [ExcelDataCell](https://reference.aspose.com/slides/ko/cpp/aspose.slides.excel/exceldatacell/) 클래스의 인스턴스가 반환됩니다. 이 객체는 Excel 통합 문서의 단일 셀을 나타내며 값에 간단하고 직관적인 방식으로 접근할 수 있게 해 줍니다.

#### **Excel 차트 가져오기**

기능을 확장하는 다음 단계는 [ExcelWorkbookImporter](https://reference.aspose.com/slides/ko/cpp/aspose.slides.import/excelworkbookimporter/) 클래스입니다. 이 유틸리티 클래스는 Excel 통합 문서에서 프레젠테이션으로 내용을 가져오는 기능을 제공하며, [AddChartFromWorkbook](https://reference.aspose.com/slides/ko/cpp/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) 메서드의 여러 오버로드를 포함하고 있어 지정된 Excel 통합 문서에서 선택한 차트를 검색하고 지정된 좌표에 있는 해당 쉐이프 컬렉션 끝에 추가할 수 있습니다.

요약하면, 이는 전체 스프레드시트 처리 라이브러리의 오버헤드 없이 많은 개발자가 필요로 하는 바로 그 Excel 데이터 읽기용 경량 API입니다.

## **코드 작성**

### **메일 머지 시나리오 예시**

다음 예시에서는 Excel 통합 문서에 저장된 데이터를 기반으로 여러 프레젠테이션을 생성하여 간단한 메일 머지 시나리오를 구현합니다.

시작하려면 두 가지가 필요합니다:
1. 데이터를 포함한 Excel 통합 문서

![Excel 데이터 예시](example1_image0.png)

2. PowerPoint 프레젠테이션 템플릿

![PowerPoint 템플릿 예시](example1_image1.png)

```cpp
// 직원 데이터가 포함된 Excel 통합 문서를 로드합니다.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// 프레젠테이션 템플릿을 로드합니다.
auto templatePresentation = MakeObject<Presentation>(u"PresentationTemplate.pptx");

    // Excel 행을 순회합니다 (행 0의 헤더 제외).
for (auto rowIndex = 1; rowIndex <= 4; rowIndex++) {

    // 각 직원 레코드마다 새로운 프레젠테이션을 생성합니다.
    auto employeePresentation = MakeObject<Presentation>();

    // 기본 빈 슬라이드를 제거합니다.
    employeePresentation->get_Slides()->RemoveAt(0);

    // 템플릿 슬라이드를 새 프레젠테이션에 복제합니다.
    auto slide = employeePresentation->get_Slides()->AddClone(templatePresentation->get_Slide(0));

    // 대상 도형에서 단락을 가져옵니다 (도형 인덱스 1 사용을 가정).
    auto paragraphs = ExplicitCast<IAutoShape>(slide->get_Shape(1))->get_TextFrame()->get_Paragraphs();

    // 플레이스홀더를 Excel 데이터로 교체합니다.
    auto employeeName = workbook->GetCell(worksheetIndex, rowIndex, 0)->get_Value()->ToString();
    auto namePortion = paragraphs->idx_get(0)->get_Portion(0);
    namePortion->set_Text(namePortion->get_Text().Replace(u"{{EmployeeName}}", employeeName));

    auto department = workbook->GetCell(worksheetIndex, rowIndex, 1)->get_Value()->ToString();
    auto departmentPortion = paragraphs->idx_get(1)->get_Portion(0);
    departmentPortion->set_Text(departmentPortion->get_Text().Replace(u"{{Department}}", department));

    auto yearsOfService = workbook->GetCell(worksheetIndex, rowIndex, 2)->get_Value()->ToString();
    auto yearsPortion = paragraphs->idx_get(2)->get_Portion(0);
    yearsPortion->set_Text(yearsPortion->get_Text().Replace(u"{{YearsOfService}}", yearsOfService));

    // 개인화된 프레젠테이션을 별도 파일에 저장합니다.
    employeePresentation->Save(String::Format(u"{0} Report.pptx", employeeName), SaveFormat::Pptx);
    employeePresentation->Dispose();
}

templatePresentation->Dispose();
```

![결과](example1_image2.png)

### **Excel 테이블 예시**

두 번째 예시에서는 Excel 테이블의 데이터를 복사해 보다 시각적으로 보기 좋은 형식으로 PowerPoint 슬라이드에 표시합니다.

이 예시에서는 첫 번째 예시와 동일한 Excel 통합 문서를 재사용하며, 여기에는 간단한 직원 테이블이 들어 있습니다.

```cpp
// 직원 데이터가 포함된 Excel 통합 문서를 로드합니다.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// 새 PowerPoint 프레젠테이션을 생성합니다.
auto presentation = MakeObject<Presentation>();

// 첫 번째 슬라이드에 표 도형을 추가합니다.
auto table = presentation->get_Slide(0)->get_Shapes()->AddTable(
    50, 200,
    MakeArray<double>({200, 200, 200}),
    MakeArray<double>({30, 30, 30, 30, 30})
);

// Excel 통합 문서의 데이터로 PowerPoint 표를 채웁니다.
for (auto rowIndex = 0; rowIndex < 5; rowIndex++) {
    for (auto columnIndex = 0; columnIndex < 3; columnIndex++) {
        auto cellValue = workbook->GetCell(worksheetIndex, rowIndex, columnIndex)->get_Value()->ToString();
        table->get_Column(columnIndex)->idx_get(rowIndex)->get_TextFrame()->set_Text(cellValue);
    }
}

// 생성된 프레젠테이션을 파일로 저장합니다.
presentation->Save(u"Table.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![결과](example2_image0.png)

### **Excel 차트 가져오기 예시**

이 예시에서는 이전 예시에서 사용한 Excel 통합 문서의 첫 번째 워크시트에 있는 차트를 가져옵니다. 차트는 결과 프레젠테이션에서 외부 통합 문서에 연결됩니다.

먼저 직원 테이블을 기반으로 Excel 통합 문서에 파이 차트를 추가합니다.

![Excel 차트 예시](example3_image0.png)

```cpp
// 새 PowerPoint 프레젠테이션을 생성합니다.
auto presentation = MakeObject<Presentation>();

// 첫 번째 슬라이드의 도형 컬렉션을 가져옵니다.
auto shapes = presentation->get_Slide(0)->get_Shapes();

// 워크북의 첫 번째 시트에서 "Chart 1" 차트를 가져와 도형 컬렉션에 추가합니다.
ExcelWorkbookImporter::AddChartFromWorkbook(shapes, 10.0, 10.0, u"TemplateData.xlsx", u"Sheet1", u"Chart 1", false);

// 생성된 프레젠테이션을 파일에 저장합니다.
presentation->Save(u"Chart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![결과](example3_image1.png)

### **모든 Excel 차트 가져오기 예시**

Excel 통합 문서에 차트가 많이 들어 있고 이를 모두 프레젠테이션에 가져와야 한다고 가정해 보십시오. 각 차트는 새로운 슬라이드에 배치됩니다.

다음 코드는 원본 Excel 파일의 모든 워크시트를 순회하며 각 워크시트에서 차트를 추출하고 빈 슬라이드 레이아웃을 사용해 각 차트를 별도의 슬라이드에 추가합니다. 결과 프레젠테이션에는 차트 데이터만 포함되고 전체 통합 문서는 포함되지 않습니다.

```cpp
// 직원 데이터가 포함된 Excel 통합 문서를 로드합니다.
auto workbook = MakeObject<ExcelDataWorkbook>(u"ExcelWithCharts.xlsx");

// 새 PowerPoint 프레젠테이션을 생성합니다.
auto presentation = MakeObject<Presentation>();

// 빈 슬라이드 레이아웃을 가져옵니다.
auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Excel 통합 문서에 포함된 모든 워크시트 이름을 가져옵니다.
auto worksheetNames = workbook->GetWorksheetNames();

for (auto&& name : worksheetNames)
{
    // 워크시트에 대해 차트 인덱스를 차트 이름에 매핑하는 사전을 가져옵니다.
    auto worksheetCharts = workbook->GetChartsFromWorksheet(name);

    for (auto&& chart : worksheetCharts)
    {
        // 빈 레이아웃을 사용해 새 슬라이드를 추가합니다.
        auto slide = presentation->get_Slides()->AddEmptySlide(blankLayout);

        // Excel 통합 문서에서 지정된 차트를 슬라이드의 도형 컬렉션에 가져옵니다.
        ExcelWorkbookImporter::AddChartFromWorkbook(slide->get_Shapes(), 10.0, 10.0, workbook, name, chart.get_Key(), false);
    }
}

// 생성된 프레젠테이션을 파일에 저장합니다.
presentation->Save(u"Charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **요약**

Aspose.Slides에 직접 포함된 이 메커니즘은 Excel 데이터와 프레젠테이션 작업을 한 곳에서 결합합니다. 추가 라이브러리나 복잡한 통합 없이 Excel 테이블 형태의 데이터와 시각적 차트가 포함된 슬라이드를 생성할 수 있습니다.