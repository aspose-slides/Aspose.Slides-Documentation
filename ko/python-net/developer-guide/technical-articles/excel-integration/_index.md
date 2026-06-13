---
title: Excel 데이터를 PowerPoint 프레젠테이션에 통합하기
linktitle: Excel 통합
type: docs
weight: 330
url: /ko/python-net/excel-integration/
keywords:
- 엑셀
- 워크북
- 엑셀 읽기
- 엑셀 통합
- 데이터 원본
- 메일 병합
- 표 가져오기
- 엑셀을 PowerPoint에
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides의 ExcelDataWorkbook API를 사용하여 Excel 워크북에서 데이터를 읽습니다. 시트와 셀을 로드하고 값을 사용하여 데이터 기반 PowerPoint 프레젠테이션을 생성합니다."
---
## **소개**

PowerPoint 프레젠테이션은 정보를 표시하고 전달하는 강력한 방법입니다. Excel 워크북과 함께 사용되는 경우가 많으며, Excel은 구조화된 데이터의 훌륭한 소스 역할을 하고 PowerPoint는 해당 데이터를 청중에게 시각화하는 데 뛰어납니다.

Excel과 PowerPoint를 결합하는 것이 필수적인 실용적인 시나리오가 많이 있습니다: 메일 병합, 데이터 테이블 채우기, 레코드당 하나의 슬라이드 생성(배치 슬라이드 생성), 교육 자료 작성, 여러 Excel 보고서를 하나의 프레젠테이션으로 통합 등등.

지금까지 Aspose.Slides API로 이러한 기능을 구현하려면 Aspose.Cells와 같은 타사 솔루션에 의존해야 했습니다. 이러한 도구는 강력하지만 기본적인 데이터 통합 기능만 필요한 사용자에게는 과도하게 복잡하고 비용이 많이 들 수 있습니다.

## **작동 방식**

Excel 데이터를 보다 쉽고 간소화된 방식으로 작업할 수 있도록 Aspose.Slides는 Excel 워크북에서 데이터를 읽고 프레젠테이션에 내용을 가져오는 새로운 클래스를 도입했습니다. 이 기능은 프레젠테이션 워크플로우 내에서 Excel을 데이터 소스로 활용하려는 API 사용자를 위한 강력한 새로운 가능성을 열어줍니다.

새 기능은 일반 목적 데이터 액세스를 위해 설계되었으며 Presentation Document Object Model(DOM)에 통합되지 않았습니다. 즉 *Excel 파일을 편집하거나 저장할 수 없으며* 워크북을 열고 내용을 탐색하여 셀 데이터를 가져오는 것이 유일한 목적입니다.

이 기능의 핵심은 새로운 [ExcelDataWorkbook](https://reference.aspose.com/slides/ko/python-net/aspose.slides.excel/exceldataworkbook/) 클래스입니다. 이 클래스는 로컬 파일이나 스트림에서 Excel 워크북을 로드할 수 있게 해줍니다. 로드된 후에는 [get_cell](https://reference.aspose.com/slides/ko/python-net/aspose.slides.excel/exceldataworkbook/get_cell/) 메서드의 여러 오버로드를 제공하여 위치(예: 행 및 열 인덱스 또는 명명된 범위)로 특정 셀을 가져올 수 있습니다.

각 [get_cell](https://reference.aspose.com/slides/ko/python-net/aspose.slides.excel/exceldataworkbook/get_cell/) 호출은 [ExcelDataCell](https://reference.aspose.com/slides/ko/python-net/aspose.slides.excel/exceldatacell/) 클래스의 인스턴스를 반환합니다. 이 객체는 Excel 워크북의 단일 셀을 나타내며 값을 간단하고 직관적인 방식으로 액세스할 수 있게 해줍니다.

#### **Excel 차트 가져오기**

다음 단계는 [ExcelWorkbookImporter](https://reference.aspose.com/slides/ko/python-net/aspose.slides.importing/excelworkbookimporter/) 클래스입니다. 이 유틸리티 클래스는 Excel 워크북에서 프레젠테이션으로 내용을 가져오는 기능을 제공합니다. 지정된 Excel 워크북에서 선택한 차트를 가져와 지정된 좌표에 있는 해당 Shape 컬렉션의 끝에 추가하는 [add_chart_from_workbook](https://reference.aspose.com/slides/ko/python-net/aspose.slides.importing/excelworkbookimporter/add_chart_from_workbook/) 메서드의 여러 오버로드가 포함되어 있습니다.

요컨대, 이것은 Excel 데이터를 읽기 위한 경량하고 직관적인 API이며, 전체 스프레드시트 처리 라이브러리의 오버헤드 없이 많은 개발자가 필요로 하는 바로 그 기능입니다.

## **코드 작성**

### **메일 병합 시나리오 예제**

다음 예제에서는 Excel 워크북에 저장된 데이터를 기반으로 여러 프레젠테이션을 생성하여 간단한 메일 병합 시나리오를 구현합니다.

시작하려면 두 가지가 필요합니다:
1. 데이터를 포함한 Excel 워크북

![Excel 데이터 예시](example1_image0.png)

2. PowerPoint 프레젠테이션 템플릿

![PowerPoint 템플릿 예시](example1_image1.png)

```py
import aspose.slides as slides

# 직원 데이터가 포함된 Excel 워크북을 로드합니다.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# 프레젠테이션 템플릿을 로드합니다.
with slides.Presentation("PresentationTemplate.pptx") as template_presentation:

    # Excel 행을 순회합니다 (행 0의 헤더 제외).
    for row_index in range(1, 5):

        # 각 직원 레코드에 대해 새 프레젠테이션을 생성합니다.
        with slides.Presentation() as employee_presentation:

            # 기본 빈 슬라이드를 제거합니다.
            employee_presentation.slides.remove_at(0)

            # 템플릿 슬라이드를 새 프레젠테이션에 복제합니다.
            slide = employee_presentation.slides.add_clone(template_presentation.slides[0])

            # 대상 Shape에서 단락을 가져옵니다 (shape 인덱스 1이 사용된다고 가정).
            paragraphs = slide.shapes[1].text_frame.paragraphs

            # 자리표시자를 Excel 데이터로 교체합니다.
            employee_name = workbook.get_cell(worksheet_index, row_index, 0).value
            name_portion = paragraphs[0].portions[0]
            name_portion.text = name_portion.text.replace("{{EmployeeName}}", employee_name)

            department = workbook.get_cell(worksheet_index, row_index, 1).value
            department_portion = paragraphs[1].portions[0]
            department_portion.text = department_portion.text.replace("{{Department}}", department)

            years_of_service = str(workbook.get_cell(worksheet_index, row_index, 2).value)
            years_portion = paragraphs[2].portions[0]
            years_portion.text = years_portion.text.replace("{{YearsOfService}}", years_of_service)

            # 개인화된 프레젠테이션을 별도 파일로 저장합니다.
            employee_presentation.save(f"{employee_name} Report.pptx", slides.export.SaveFormat.PPTX)
```

![결과](example1_image2.png)

### **Excel 표 예제**

두 번째 예제에서는 Excel 표의 데이터를 복사하여 PowerPoint 슬라이드에 보다 시각적으로 매력적인 형식으로 표시합니다.

이 예제에서는 첫 번째 예제와 동일한 Excel 워크북을 재사용합니다. 해당 워크북에는 간단한 직원 테이블이 들어 있습니다.

```py
# 직원 데이터가 포함된 Excel 워크북을 로드합니다.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# 새 PowerPoint 프레젠테이션을 생성합니다.
with slides.Presentation() as presentation:

    # 첫 번째 슬라이드에 표 모양을 추가합니다.
    table = presentation.slides[0].shapes.add_table(
        50, 200,
        [200, 200, 200],
        [30, 30, 30, 30, 30]
    )

    # Excel 워크북의 데이터로 PowerPoint 표를 채웁니다.
    for row_index in range(0, 5):
        for column_index in range(0, 3):
            cell_value = str(workbook.get_cell(worksheet_index, row_index, column_index).value)
            table.columns[column_index][row_index].text_frame.text = cell_value

    # 결과 프레젠테이션을 파일에 저장합니다.
    presentation.save("Table.pptx", slides.export.SaveFormat.PPTX)
```

![결과](example2_image0.png)

### **Excel 차트 가져오기 예제**

이 예제에서는 이전 예제에서 사용한 Excel 워크북의 첫 번째 워크시트에서 차트를 가져옵니다. 차트는 결과 프레젠테이션에서 외부 워크북에 연결됩니다.

먼저 직원 테이블을 기반으로 Excel 워크북에 원형 차트를 추가합니다.

![Excel 차트 예시](example3_image0.png)

```py
# 새 PowerPoint 프레젠테이션을 생성합니다.
with slides.Presentation() as presentation:
    # 첫 번째 슬라이드의 shapes 컬렉션을 가져옵니다.
    shapes = presentation.slides[0].shapes

    # 워크북의 첫 번째 시트에서 "Chart 1"이라는 차트를 가져와 shapes 컬렉션에 추가합니다.
    slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
        shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # 결과 프레젠테이션을 파일에 저장합니다.
    presentation.save("Chart.pptx", slides.export.SaveFormat.PPTX)
```

![결과](example3_image1.png)

### **모든 Excel 차트 가져오기 예제**

Excel 워크북에 차트가 가득 있고 이를 모두 프레젠테이션으로 가져와야 한다고 가정해 보겠습니다. 각 차트는 새 슬라이드에 배치되어야 합니다.

다음 코드는 소스 Excel 파일의 모든 워크시트를 순회하면서 각 워크시트에서 차트를 추출하고, 빈 슬라이드 레이아웃을 사용해 각 차트를 별도의 슬라이드에 추가합니다. 결과 프레젠테이션에는 차트 데이터만 포함되며 전체 워크북은 포함되지 않습니다.

```py
# 직원 데이터를 포함하는 Excel 워크북을 로드합니다.
workbook = slides.excel.ExcelDataWorkbook("ExcelWithCharts.xlsx")

# 새 PowerPoint 프레젠테이션을 생성합니다.
with slides.Presentation() as presentation:
    # 빈 슬라이드 레이아웃을 가져옵니다.
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Excel 워크북에 포함된 모든 워크시트 이름을 가져옵니다.
    worksheet_names = workbook.get_worksheet_names()

    for name in worksheet_names:
        # 워크시트에 대한 차트 인덱스를 차트 이름에 매핑하는 사전을 가져옵니다.
        worksheet_charts = workbook.get_charts_from_worksheet(name)
        
        for chart in worksheet_charts:
            # 빈 레이아웃을 사용해 새 슬라이드를 추가합니다.
            slide = presentation.slides.add_empty_slide(blank_layout)

            # 지정된 차트를 Excel 워크북에서 슬라이드의 shapes 컬렉션에 가져옵니다.
            slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
                slide.shapes, 10, 10, workbook, name, chart.key, False)

    # 결과 프레젠테이션을 파일에 저장합니다.
    presentation.save("Charts.pptx", slides.export.SaveFormat.PPTX)
```

## **요약**

Aspose.Slides에 직접 제공되는 이 메커니즘은 Excel 데이터와 프레젠테이션 작업을 한 곳에서 결합합니다. 추가 라이브러리나 복잡한 통합 없이도 Excel 표 형태의 데이터와 시각적 차트가 포함된 슬라이드를 만들 수 있습니다.