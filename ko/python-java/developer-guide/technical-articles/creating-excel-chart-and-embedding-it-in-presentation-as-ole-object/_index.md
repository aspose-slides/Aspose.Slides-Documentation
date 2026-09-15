---
title: Excel 차트를 만들고 프레젠테이션에 OLE 객체로 삽입하기
type: docs
weight: 30
url: /ko/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 차트
- 차트 삽입
- OLE 객체
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Python을 사용하여 Excel 차트를 만들고 PowerPoint 및 OpenDocument 프레젠테이션에 OLE 객체로 삽입합니다. 단계별 가이드와 코드 샘플을 제공합니다."
---
## **배경**

PowerPoint에서는 데이터를 그래픽으로 표시하기 위해 편집 가능한 차트를 사용하는 것이 일반적인 방법입니다. Aspose는 Python via Java용 Aspose.Cells를 사용하여 Excel 차트를 생성할 수 있으며, 이러한 차트를 Aspose.Slides for Python via Java를 통해 OLE 객체로 PowerPoint 슬라이드에 삽입할 수 있습니다. 이 문서에서는 필요한 단계를 설명하고 Aspose.Cells와 Aspose.Slides를 사용하여 Excel 차트를 만들고 이를 PowerPoint 프레젠테이션에 OLE 객체로 삽입하는 Python 코드 샘플을 제공합니다.

## **필요한 단계**

PowerPoint 슬라이드에 OLE 객체로 Excel 차트를 만들고 삽입하기 위해 다음과 같은 순서대로 단계가 필요합니다:

1. Aspose.Cells를 사용하여 Excel 차트를 생성합니다.
1. Aspose.Cells를 사용하여 Excel 차트의 OLE 크기를 설정합니다.
1. Aspose.Cells로 Excel 차트의 이미지를 가져옵니다.
1. Aspose.Slides를 사용하여 PPTX 프레젠테이션에 Excel 차트를 OLE 객체로 삽입합니다.
1. 단계 3에서 얻은 이미지로 "EMBEDDED OLE OBJECT" 이미지를 교체하여 [객체 미리보기 문제](/slides/ko/python-java/object-preview-issue-when-adding-oleobjectframe/)를 해결합니다.
1. 프레젠테이션을 PPTX 형식으로 디스크에 저장합니다.

## **필요한 단계 구현**

위 단계들의 Python 구현은 다음과 같습니다:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def add_excel_chart_in_workbook(workbook, chart_rows, chart_columns):
    # 셀 이름 배열.
    cell_names = [
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4",
    ]

    # 셀 데이터 배열.
    cell_values = [
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25,
    ]

    # 데이터로 셀을 채우기 위해 새 워크시트를 추가합니다.
    data_sheet_index = workbook.getWorksheets().add()
    data_sheet = workbook.getWorksheets().get(data_sheet_index)
    sheet_name = "DataSheet"
    data_sheet.setName(sheet_name)

    # 데이터 시트를 데이터로 채웁니다.
    for cell_name, cell_value in zip(cell_names, cell_values):
        data_sheet.getCells().get(cell_name).setValue(jpype.JInt(cell_value))

    # 차트 시트를 추가합니다.
    worksheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(worksheet_index)
    chart_sheet.setName("ChartSheet")
    chart_sheet_index = chart_sheet.getIndex()

    # 데이터 시트의 데이터 시리즈를 사용하여 차트 시트에 차트를 추가합니다.
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, chart_rows, 0, chart_columns)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add(sheet_name + "!A1:E1", False)
    chart.getNSeries().add(sheet_name + "!A2:E2", False)
    chart.getNSeries().add(sheet_name + "!A3:E3", False)
    chart.getNSeries().add(sheet_name + "!A4:E4", False)

    # 차트 시트를 활성 시트로 설정합니다.
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    return chart_sheet_index


def add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image):
    ole_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    ole_width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())

    # 워크북을 포함된 OLE 데이터로 설명합니다.
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(0.0, 0.0, ole_width, ole_height, data_info)
    image = presentation.getImages().addImage(chart_image)
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(image)


# 워크북을 생성합니다.
workbook = Workbook()

# Excel 차트를 추가합니다.
chart_rows = 55
chart_columns = 25
chart_sheet_index = add_excel_chart_in_workbook(workbook, chart_rows, chart_columns)

# 차트의 OLE 크기를 설정합니다.
workbook.getWorksheets().setOleSize(0, chart_rows, 0, chart_columns)

# 차트 이미지를 가져와 스트림에 저장합니다.
print_options = ImageOrPrintOptions()
print_options.setImageType(ImageType.PNG)
image_stream = ByteArrayOutputStream()
workbook.getWorksheets().get(chart_sheet_index).getCharts().get(0).toImage(image_stream, print_options)
chart_image = image_stream.toByteArray()

# 워크북을 스트림에 저장합니다.
workbook_stream = ByteArrayOutputStream()
workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)
workbook_data = workbook_stream.toByteArray()

# 프레젠테이션을 생성합니다.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 워크북을 슬라이드에 추가합니다.
    add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image)

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("OutputChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

위 방법으로 만든 프레젠테이션에는 OLE 객체 프레임을 더블 클릭하면 활성화되는 OLE 객체 형태의 Excel 차트가 포함됩니다.

## **결론**

Python via Java용 Aspose.Cells와 Aspose.Slides를 함께 사용하면 Aspose.Cells에서 지원하는 모든 Excel 차트를 생성하고 이를 PowerPoint 슬라이드에 OLE 객체로 삽입할 수 있습니다. Excel 차트의 OLE 크기도 정의할 수 있습니다. 최종 사용자는 다른 OLE 객체와 마찬가지로 Excel 차트를 편집할 수 있습니다.

## **관련 섹션**

- [PPTX에서 차트 크기 조정에 대한 작업 솔루션](/slides/ko/python-java/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame 추가 시 객체 미리보기 문제](/slides/ko/python-java/object-preview-issue-when-adding-oleobjectframe/)

## **FAQ**

**Excel 차트를 생성하고 삽입하는 데 사용되는 라이브러리는 무엇인가요?**

Python via Java용 Aspose.Cells가 Excel 차트를 생성하고, Python via Java용 Aspose.Slides가 PowerPoint 슬라이드에 OLE 객체로 삽입합니다.

**사용자는 삽입된 Excel 차트를 어떻게 편집할 수 있나요?**

사용자는 OLE 객체 프레임을 더블 클릭하여 차트를 활성화하고 다른 OLE 객체와 마찬가지로 편집할 수 있습니다.

**기본 OLE 객체 미리보기는 어떻게 교체되나요?**

예제에서는 Aspose.Cells로 Excel 차트의 이미지를 얻은 다음 이를 사용하여 "EMBEDDED OLE OBJECT" 이미지를 교체합니다.