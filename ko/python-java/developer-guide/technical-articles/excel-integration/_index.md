---
title: Excel 데이터를 PowerPoint 프레젠테이션에 통합
linktitle: Excel 통합
type: docs
weight: 330
url: /ko/python-java/excel-integration/
keywords:
- Excel
- 워크북
- Excel 읽기
- Excel 통합
- 데이터 소스
- 메일 머지
- 테이블 가져오기
- Excel을 PowerPoint에 삽입
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "ExcelDataWorkbook API를 사용하여 Java 기반 Python용 Aspose.Slides에서 Excel 워크북의 데이터를 읽습니다. 시트와 셀을 로드하고 값을 사용하여 데이터 기반 PowerPoint 프레젠테이션을 생성합니다."
---
## **소개**

PowerPoint 프레젠테이션은 정보를 표시하고 전달하는 강력한 방법입니다. Excel 워크북과 함께 사용되는 경우가 많으며, Excel은 구조화된 데이터의 훌륭한 소스 역할을 하고 PowerPoint는 해당 데이터를 청중에게 시각화하는 데 뛰어납니다.

Excel과 PowerPoint를 결합해야 하는 실용적인 시나리오가 많이 있습니다. 메일 머지, 데이터 테이블 채우기, 레코드당 하나의 슬라이드 생성(배치 슬라이드 생성), 교육 자료 만들기, 여러 Excel 보고서를 하나의 프레젠테이션으로 통합하기 등입니다.

지금까지 Aspose.Slides API로 이러한 기능을 구현하려면 Aspose.Cells와 같은 타사 솔루션에 의존해야 했습니다. 이러한 도구는 견고하지만 기본적인 데이터 통합 기능만 필요한 사용자에게는 지나치게 복잡하고 비용이 많이 들 수 있습니다.

## **작동 방식**

Excel 데이터를 보다 쉽고 간소화된 방식으로 다루기 위해 Aspose.Slides는 Excel 워크북에서 데이터를 읽고 프레젠테이션에 내용을 가져오는 새로운 클래스를 도입했습니다. 이 기능은 프레젠테이션 워크플로우 내에서 Excel을 데이터 소스로 활용하려는 API 사용자에게 강력한 새로운 가능성을 열어줍니다.

새 기능은 일반 목적 데이터 액세스를 위해 설계되었으며 Presentation Document Object Model(DOM)에 통합되지 않았습니다. 즉, *Excel 파일을 편집하거나 저장할 수 없습니다*—오직 워크북을 열어 내용에 접근하여 셀 데이터를 가져오는 것이 전부입니다.

이 기능의 핵심은 새로운 [ExcelDataWorkbook](https://reference.aspose.com/slides/ko/python-java/aspose.slides/exceldataworkbook/) 클래스입니다. 이 클래스는 로컬 파일이나 스트림에서 Excel 워크북을 로드할 수 있게 해줍니다. 로드 후에는 [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/ko/python-java/aspose.slides/exceldataworkbook/#getCell) 메서드의 여러 오버로드를 제공하여 위치(예: 행·열 인덱스 또는 명명된 범위) 기반으로 특정 셀을 가져올 수 있습니다.

[ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/ko/python-java/aspose.slides/exceldataworkbook/#getCell)를 호출하면 [ExcelDataCell](https://reference.aspose.com/slides/ko/python-java/aspose.slides/exceldatacell/) 객체가 반환됩니다. 이 객체는 Excel 워크북의 단일 셀을 나타내며, 값을 간단하고 직관적으로 접근할 수 있게 해줍니다.

#### **Excel 차트 가져오기**

기능을 확장하는 다음 단계는 [ExcelWorkbookImporter](https://reference.aspose.com/slides/ko/python-java/aspose.slides/excelworkbookimporter/) 클래스입니다. 이 유틸리티 클래스는 Excel 워크북의 내용을 프레젠테이션으로 가져오는 기능을 제공합니다. 지정된 Excel 워크북에서 선택된 차트를 가져와 지정된 좌표에 있는 해당 쉐이프 컬렉션 끝에 추가하는 [ExcelWorkbookImporter.addChartFromWorkbook](https://reference.aspose.com/slides/ko/python-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook) 메서드의 여러 오버로드가 포함되어 있습니다.

#### **Excel 테이블 가져오기**

[ExcelWorkbookImporter](https://reference.aspose.com/slides/ko/python-java/aspose.slides/excelworkbookimporter/) 클래스는 또한 [ExcelWorkbookImporter.addTableFromWorkbook](https://reference.aspose.com/slides/ko/python-java/aspose.slides/excelworkbookimporter/#addTableFromWorkbook) 메서드의 여러 오버로드를 포함합니다. 이러한 메서드를 사용하면 지정된 워크시트의 셀 범위를 가져와 지정된 좌표에 있는 쉐이프 컬렉션 끝에 테이블로 추가할 수 있습니다.

요약하면, 이는 Excel 데이터를 읽기 위한 가볍고 간단한 API이며, 전체 스프레드시트 처리 라이브러리의 오버헤드 없이 많은 개발자가 필요로 하는 바로 그 기능입니다.

## **코드 작성**

### **메일 머지 시나리오 예제**

다음 예제에서는 Excel 워크북에 저장된 데이터를 기반으로 여러 프레젠테이션을 생성하여 간단한 메일 머지 시나리오를 구현합니다.

시작하려면 두 가지가 필요합니다.

1. 데이터를 포함한 Excel 워크북

![Excel data example](example1_image0.png)

2. PowerPoint 프레젠테이션 템플릿

![PowerPoint template example](example1_image1.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# 직원 데이터를 포함한 Excel 워크북을 로드합니다.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# 프레젠테이션 템플릿을 로드합니다.
template_presentation = Presentation("PresentationTemplate.pptx")

try:
    # Excel 행을 반복합니다 (0 행 헤더 제외).
    for row_index in range(1, 5):

        # 각 직원 레코드에 대한 프레젠테이션을 생성합니다.
        employee_presentation = Presentation()

        try:
            # 기본 빈 슬라이드를 제거합니다.
            employee_presentation.getSlides().removeAt(0)

            # 템플릿 슬라이드를 프레젠테이션에 복제합니다.
            slide = employee_presentation.getSlides().addClone(template_presentation.getSlides().get_Item(0))

            # 대상 쉐이프에서 단락을 가져옵니다 (쉐이프 인덱스 1 사용을 가정).
            paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs()

            # 플레이스홀더를 Excel 데이터로 교체합니다.
            employee_name = str(workbook.getCell(worksheet_index, row_index, 0).getValue())
            name_portion = paragraphs.get_Item(0).getPortions().get_Item(0)
            name_portion.setText(str(name_portion.getText()).replace("{{EmployeeName}}", employee_name))

            department = str(workbook.getCell(worksheet_index, row_index, 1).getValue())
            department_portion = paragraphs.get_Item(1).getPortions().get_Item(0)
            department_portion.setText(str(department_portion.getText()).replace("{{Department}}", department))

            years_of_service = str(workbook.getCell(worksheet_index, row_index, 2).getValue())
            years_portion = paragraphs.get_Item(2).getPortions().get_Item(0)
            years_portion.setText(str(years_portion.getText()).replace("{{YearsOfService}}", years_of_service))

            # 개인화된 프레젠테이션을 별도 파일로 저장합니다.
            employee_presentation.save(f"{employee_name} Report.pptx", SaveFormat.Pptx)
        finally:
            employee_presentation.dispose()
finally:
    template_presentation.dispose()
```

![Result](example1_image2.png)

### **Excel 테이블 예제**

두 번째 예제에서는 Excel 테이블의 데이터를 복사하여 PowerPoint 슬라이드에 보다 시각적으로 보기 좋게 표시합니다.

이 예제에서는 첫 번째 예제와 동일한 Excel 워크북을 재사용합니다. 워크북에는 간단한 직원 테이블이 포함되어 있습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# 직원 데이터가 포함된 Excel 워크북을 로드합니다.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# PowerPoint 프레젠테이션을 생성합니다.
presentation = Presentation()

try:
    # 첫 번째 슬라이드에 테이블 쉐이프를 추가합니다.
    column_widths = jpype.JArray(jpype.JDouble)([200, 200, 200])
    row_heights = jpype.JArray(jpype.JDouble)([30, 30, 30, 30, 30])
    table = presentation.getSlides().get_Item(0).getShapes().addTable(50, 200, column_widths, row_heights)

    # Excel 워크북의 데이터를 사용하여 PowerPoint 테이블을 채웁니다.
    for row_index in range(5):
        for column_index in range(3):
            cell_value = str(workbook.getCell(worksheet_index, row_index, column_index).getValue())
            table.getColumns().get_Item(column_index).get_Item(row_index).getTextFrame().setText(cell_value)

    # 결과 프레젠테이션을 파일에 저장합니다.
    presentation.save("Table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Result](example2_image0.png)

### **Excel 차트 가져오기 예제**

이 예제에서는 앞선 예제에서 사용한 Excel 워크북의 첫 번째 워크시트에서 차트를 가져옵니다. 차트는 결과 프레젠테이션에서 외부 워크북에 연결됩니다.

먼저 직원 테이블을 기반으로 Excel 워크북에 파이 차트를 추가합니다.

![Excel Chart example](example3_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# PowerPoint 프레젠테이션을 생성합니다.
presentation = Presentation()
try:
    # 첫 번째 슬라이드의 쉐이프 컬렉션을 가져옵니다.
    shapes = presentation.getSlides().get_Item(0).getShapes()

    # 워크북의 첫 번째 시트에서 "Chart 1"이라는 차트를 가져와 쉐이프 컬렉션에 추가합니다.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # 결과 프레젠테이션을 파일에 저장합니다.
    presentation.save("Chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Result](example3_image1.png)

### **모든 Excel 차트 가져오기 예제**

Excel 워크북에 차트가 가득 있고 이를 모두 프레젠테이션으로 가져와야 한다고 가정해 보겠습니다. 각 차트는 새 슬라이드에 배치됩니다.

다음 코드는 소스 Excel 파일의 모든 워크시트를 순회하면서 각 워크시트의 차트를 추출하고, 빈 슬라이드 레이아웃을 사용하여 각 차트를 별도의 슬라이드에 추가합니다. 결과 프레젠테이션에는 차트 데이터만 포함되며 전체 워크북은 포함되지 않습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, ExcelWorkbookImporter, Presentation, SaveFormat, SlideLayoutType

# 직원 데이터가 포함된 Excel 워크북을 로드합니다.
workbook = ExcelDataWorkbook("ExcelWithCharts.xlsx")

# PowerPoint 프레젠테이션을 생성합니다.
presentation = Presentation()
try:
    # 빈 슬라이드 레이아웃을 가져옵니다.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    # 기본 슬라이드를 제거하여 결과에 차트당 하나의 슬라이드가 포함되도록 합니다.
    presentation.getSlides().removeAt(0)

    # Excel 워크북에 포함된 모든 워크시트 이름을 가져옵니다.
    worksheet_names = workbook.getWorksheetNames()

    for name in worksheet_names:
        # 워크시트에 대한 차트 인덱스를 차트 이름에 매핑하는 맵을 가져옵니다.
        worksheet_charts = workbook.getChartsFromWorksheet(name)

        for chart in worksheet_charts:
            # 빈 레이아웃을 사용하여 슬라이드를 추가합니다.
            slide = presentation.getSlides().addEmptySlide(blank_layout)

            # Excel 워크북에서 지정된 차트를 슬라이드의 쉐이프 컬렉션에 가져옵니다.
            ExcelWorkbookImporter.addChartFromWorkbook(slide.getShapes(), 10, 10, workbook, name, chart.getKey(), False)

    # 결과 프레젠테이션을 파일에 저장합니다.
    presentation.save("Charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Excel 테이블 가져오기 예제**

이 예제에서는 Excel 워크시트에 있는 서식이 지정된 테이블을 바로 PowerPoint 프레젠테이션으로 가져옵니다.

소스 Excel 워크시트에는 직원 데이터가 포함된 서식이 지정된 테이블이 있습니다:

![Excel Table example](example4_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# PowerPoint 프레젠테이션을 생성합니다.
presentation = Presentation()
try:
    # 첫 번째 슬라이드와 해당 쉐이프 컬렉션을 가져옵니다.
    slide = presentation.getSlides().get_Item(0)
    shapes = slide.getShapes()

    # 워크북의 첫 번째 시트에서 테이블을 가져와 쉐이프 컬렉션에 추가합니다.
    ExcelWorkbookImporter.addTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5")

    # 결과 프레젠테이션을 파일에 저장합니다.
    presentation.save("FormattedTable.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Result](example4_image1.png)

## **요약**

Aspose.Slides에 직접 내장된 이 메커니즘은 Excel 데이터와 프레젠테이션 작업을 한 곳에서 결합합니다. 별도의 라이브러리나 복잡한 통합 없이도 Excel 테이블 형태의 데이터와 시각적 차트를 포함한 슬라이드를 만들 수 있습니다.