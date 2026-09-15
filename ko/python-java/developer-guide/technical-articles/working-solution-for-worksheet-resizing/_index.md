---
title: 워크시트 크기 조정에 대한 작업 솔루션
type: docs
weight: 20
url: /ko/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 미리 보기 이미지
- 이미지 크기 조정
- Excel
- 워크시트
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "프레젠테이션에서 Excel 워크시트 OLE 크기 조정을 해결합니다: 객체 프레임을 일관되게 유지하는 두 가지 방법—프레임을 스케일링하거나 시트를 스케일링—PPT 및 PPTX 형식 전반에 적용됩니다."
---
{{% alert color="info" title="Note" %}}

Excel 워크시트를 Aspose 구성 요소를 사용해 PowerPoint 프레젠테이션에 OLE 객체로 삽입하면 첫 번째 활성화 이후 크기가 지정되지 않은 비율로 조정되는 현상이 관찰되었습니다. 이 동작으로 인해 OLE 객체의 활성화 전후 시각적 차이가 크게 나타납니다. 이 문제를 상세히 조사하고 해결 방법을 제시했으며, 해당 내용은 이 문서에 수록되어 있습니다.

{{% /alert %}}

## **배경**

[OLE 관리](/slides/ko/python-java/manage-ole/) 문서에서 Aspose.Slides for Python via Java를 사용해 PowerPoint 프레젠테이션에 OLE 프레임을 추가하는 방법을 설명했습니다. [객체 미리 보기 문제](/slides/ko/python-java/object-preview-issue-when-adding-oleobjectframe/)를 해결하기 위해 선택한 워크시트 영역의 이미지를 OLE 객체 프레임에 할당했습니다. 출력 프레젠테이션에서 워크시트 이미지를 표시하는 OLE 객체 프레임을 더블 클릭하면 Excel 통합 문서가 활성화됩니다. 최종 사용자는 실제 Excel 통합 문서에서 원하는 대로 수정한 뒤, 활성화된 Excel 통합 문서 외부를 클릭해 슬라이드로 돌아갈 수 있습니다. 사용자가 슬라이드로 돌아올 때 OLE 객체 프레임의 크기가 변경됩니다. 크기 조정 비율은 OLE 객체 프레임과 삽입된 Excel 통합 문서의 크기에 따라 달라집니다.

## **크기 조정 원인**

Excel 통합 문서는 자체 창 크기를 가지고 있어 첫 번째 활성화 시 원래 크기를 유지하려 합니다. 반면 OLE 객체 프레임은 자체 크기를 갖고 있습니다. Microsoft에 따르면 Excel 통합 문서가 활성화될 때 Excel과 PowerPoint가 크기를 협상해 임베딩 프로세스의 비율을 올바르게 유지합니다. 크기 조정은 Excel 창 크기와 OLE 객체 프레임의 크기·위치 차이에 기반해 발생합니다.

## **작동 솔루션**

크기 조정 효과를 피할 수 있는 두 가지 해결책이 있습니다.

- OLE 프레임의 크기를 PowerPoint 프레젠테이션에서 원하는 행·열 수에 맞는 높이와 너비로 조정합니다.
- OLE 프레임 크기를 고정하고, 포함된 행·열의 크기를 조정해 선택한 OLE 프레임 크기에 맞춥니다.

### **OLE 프레임 크기 조정**

이 방법에서는 삽입된 Excel 통합 문서의 OLE 프레임 크기를 Excel 워크시트의 포함 행·열 총합 크기에 맞게 설정하는 방법을 배웁니다.

템플릿 Excel 시트가 있고 이를 OLE 프레임으로 프레젠테이션에 추가한다고 가정합니다. 이 경우 OLE 객체 프레임의 크기는 워크북에 포함된 행 높이와 열 너비의 총합을 기준으로 먼저 계산됩니다. 그런 다음 계산된 값으로 OLE 프레임 크기를 설정합니다. PowerPoint에서 OLE 프레임에 표시되는 빨간색 “EMBEDDED OLE OBJECT” 메시지를 방지하기 위해 워크북에서 원하는 행·열 영역을 캡처하고 이를 OLE 프레임 이미지로 설정합니다.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96

workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # 워크북을 PowerPoint에서 OLE 객체로 사용할 때 표시되는 크기를 설정합니다.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # OLE 이미지의 너비와 높이를 포인트 단위로 가져옵니다.
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # 수정된 워크북을 사용합니다.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # OLE 이미지를 프레젠테이션 리소스에 추가합니다.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # OLE 객체 프레임을 생성합니다.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

### **셀 범위 크기 조정**

이 방법에서는 원하는 OLE 프레임 크기에 맞게 포함 행의 높이와 포함 열의 너비를 조정하는 방법을 배웁니다.

템플릿 Excel 시트가 있고 이를 OLE 프레임으로 프레젠테이션에 추가한다고 가정합니다. 이 경우 OLE 프레임 크기를 설정하고 OLE 프레임 영역에 포함되는 행·열의 크기를 조정합니다. 그런 다음 워크북을 스트림에 저장해 변경 사항을 적용하고, 이를 바이트 배열로 변환해 OLE 프레임에 추가합니다. PowerPoint에서 OLE 프레임에 표시되는 빨간색 “EMBEDDED OLE OBJECT” 메시지를 방지하기 위해 워크북에서 원하는 행·열 영역을 캡처하고 이를 OLE 프레임 이미지로 설정합니다.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpuse.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


def scale_cell_range(cell_range, width, height):
    # 셀 범위의 예상 너비와 높이는 포인트 단위입니다.
    range_width = cell_range.getWidth()
    range_height = cell_range.getHeight()
    cells = cell_range.getWorksheet().getCells()

    for i in range(cell_range.getColumnCount()):
        column_index = cell_range.getFirstColumn() + i
        column_width = cells.getColumnWidth(column_index, False, CellsUnitType.POINT)
        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72.0
        cells.setColumnWidthInch(column_index, width_in_inches)

    for i in range(cell_range.getRowCount()):
        row_index = cell_range.getFirstRow() + i
        row_height = cells.getRowHeight(row_index, False, CellsUnitType.POINT)
        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72.0
        cells.setRowHeightInch(row_index, height_in_inches)


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96
frame_width, frame_height = 400.0, 100.0
workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # 워크북을 PowerPoint에서 OLE 객체로 사용할 때 표시되는 크기를 설정합니다.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # 프레임 크기에 맞게 셀 범위를 스케일링합니다.
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # 수정된 워크북을 사용합니다.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # OLE 이미지를 프레젠테이션 리소스에 추가합니다.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # OLE 객체 프레임을 생성합니다.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

## **결론**

{{% alert color="info" title="Note" %}} 

워크시트 크기 조정 문제를 해결하는 두 가지 접근 방식이 있습니다. 적절한 접근 방식 선택은 구체적인 요구 사항 및 사용 사례에 따라 달라집니다. 두 방식 모두 템플릿 기반이든 처음부터 만든 프레젠테이션이든 동일하게 작동합니다. 또한 이 솔루션에서는 OLE 객체 프레임 크기에 제한이 없습니다.

{{% /alert %}}

## **FAQ**

**첫 번째 활성화 시 삽입된 Excel 워크시트가 PowerPoint에서 크기가 변경되는 이유는 무엇인가요?**

Excel이 활성화될 때 원래 창 크기를 유지하려 하고, PowerPoint의 OLE 객체 프레임은 자체 차원을 갖기 때문입니다. PowerPoint와 Excel이 비율을 유지하도록 크기를 협상하면서 크기 조정이 발생합니다.

**이 크기 조정 문제를 완전히 방지할 수 있나요?**

예. OLE 프레임을 Excel 셀 범위 크기에 맞게 조정하거나, 셀 범위를 원하는 OLE 프레임 크기에 맞게 조정하면 원하지 않는 크기 변화를 방지할 수 있습니다.

**어떤 스케일링 방법을 사용해야 하나요? OLE 프레임 스케일링 vs 셀 범위 스케일링?**

원본 Excel 행·열 크기를 유지하고 싶다면 **OLE 프레임 스케일링**을 선택하십시오. 프레젠테이션에서 OLE 프레임 크기를 고정하고 싶다면 **셀 범위 스케일링**을 선택하십시오.

**템플릿 기반 프레젠테이션에도 이 솔루션이 적용되나요?**

예. 두 솔루션 모두 템플릿에서 만든 프레젠테이션과 처음부터 만든 프레젠테이션 모두에서 작동합니다.

**이 방법을 사용할 때 OLE 프레임 크기에 제한이 있나요?**

아니요. 적절히 스케일을 지정하기만 하면 OLE 객체 프레임을 원하는 어떤 크기로도 만들 수 있습니다.

**PowerPoint에서 “EMBEDDED OLE OBJECT” 플레이스홀더 텍스트를 없앨 수 있나요?**

예. 대상 Excel 셀 범위의 스냅샷을 찍어 OLE 프레임의 플레이스홀더 이미지로 설정하면 기본 플레이스홀더 대신 사용자 지정 미리 보기 이미지를 표시할 수 있습니다.

## **관련 문서**

[Excel 차트를 생성하고 OLE 객체로 프레젠테이션에 삽입](/slides/ko/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)