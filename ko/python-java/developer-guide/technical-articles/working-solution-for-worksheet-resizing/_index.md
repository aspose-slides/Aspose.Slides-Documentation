---
title: 워크시트 크기 조정에 대한 실용적인 해결책
type: docs
weight: 20
url: /ko/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 미리보기 이미지
- 이미지 크기 조정
- Excel
- 워크시트
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "프레젠테이션에서 Excel 워크시트 OLE 크기 조정을 수정합니다: 개체 프레임을 일관되게 유지하는 두 가지 방법—프레임을 스케일링하거나 시트를 스케일링—PPT 및 PPTX 형식 전반에 걸쳐."
---
{{% alert color="info" title="Note" %}}

Aspose 구성 요소를 사용하여 PowerPoint 프레젠테이션에 OLE 개체로 삽입된 Excel 워크시트는 첫 번째 활성화 후 예상치 않게 크기가 변경될 수 있습니다. 이 동작으로 인해 OLE 개체가 활성화 전후에 눈에 띄는 시각적 차이가 발생합니다. 이 문서에서는 문제를 설명하고 해결 방법 두 가지를 소개합니다.

{{% /alert %}}

## **배경**

이 문서 [OLE 관리](/slides/ko/python-java/manage-ole/)에서는 Aspose.Slides for Python via Java를 사용하여 PowerPoint 프레젠테이션에 OLE 프레임을 추가하는 방법을 설명했습니다. [개체 미리보기 문제](/slides/ko/python-java/object-preview-issue-when-adding-oleobjectframe/)를 해결하기 위해 선택된 워크시트 영역의 이미지를 OLE 개체 프레임에 할당했습니다. 출력 프레젠테이션에서 워크시트 이미지를 표시하는 OLE 개체 프레임을 더블 클릭하면 Excel 통합 문서가 활성화됩니다. 최종 사용자는 실제 Excel 통합 문서를 원하는대로 변경한 후 활성화된 Excel 통합 문서 밖을 클릭하여 슬라이드로 돌아갈 수 있습니다. 사용자가 슬라이드로 돌아오면 OLE 개체 프레임의 크기가 변경됩니다. 크기 조정 비율은 OLE 개체 프레임과 삽입된 Excel 통합 문서의 크기에 따라 달라집니다.

## **크기 조정 원인**

Excel 통합 문서는 자체 창 크기를 가지고 있기 때문에 첫 번째 활성화 시 원래 크기를 유지하려고 합니다. 반면 OLE 개체 프레임은 자체 크기를 갖습니다. Microsoft에 따르면 Excel 통합 문서가 활성화될 때 Excel과 PowerPoint가 삽입 과정의 일환으로 올바른 비율을 유지하도록 크기를 협상합니다. 크기 조정은 Excel 창 크기와 OLE 개체 프레임의 크기 및 위치 차이에 따라 발생합니다.

## **해결 방법**

크기 조정 효과를 방지하기 위한 두 가지 가능한 해결책이 있습니다.

- PowerPoint 프레젠테이션에서 OLE 프레임을 선택된 행과 열의 전체 높이와 너비에 맞게 스케일링합니다.
- OLE 프레임 크기를 고정하고 선택된 행과 열을 프레임에 맞게 스케일링합니다.

### **OLE 프레임 크기 조정**

이 방법은 삽입된 Excel 워크시트에서 선택된 행과 열의 전체 높이와 너비에 맞게 OLE 프레임 크기를 설정합니다.

예제는 기존 Excel 통합 문서를 로드하고, 0부터 시작하는 인덱스를 사용하여 첫 번째 워크시트의 처음 10행과 13열을 선택합니다. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) 은 표시 범위를 정의합니다. 미리보기는 96 DPI로 렌더링되며, 픽셀 크기는 인치당 72 포인트를 사용하여 포인트로 변환됩니다. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) 은 수정된 통합 문서를 해당 차원의 프레임에 삽입합니다. 미리보기는 [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) 을 통해 할당되어 저장된 프레젠테이션의 "EMBEDDED OLE OBJECT" 자리표시자를 교체합니다.

미리보기 도우미는 [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) 를 선택된 범위로 설정하고 여백, 머리글 및 바닥글을 제거합니다. [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/python-java/asposecells.api/imageorprintoptions/#onlyarea) 가 활성화된 상태에서 [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) 은 범위를 PNG 이미지로 렌더링합니다. 도우미는 프레젠테이션에서 사용하기 위해 PNG 이미지를 포함하는 새로운 입력 스트림을 반환하며, 스트림은 시작 위치에 배치됩니다.

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

    # 워크북이 PowerPoint에서 OLE 개체로 사용될 때 표시되는 크기를 설정합니다.
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

            # OLE 개체 프레임을 생성합니다.
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

이 방법은 선택된 행의 높이와 선택된 열의 너비를 사용자 정의 OLE 프레임 크기에 맞게 스케일링합니다.

예제는 기존 Excel 통합 문서를 로드하고, 0부터 시작하는 인덱스를 사용하여 첫 번째 워크시트의 처음 10행과 13열을 선택합니다. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) 은 표시 범위를 정의하고, scale_cell_range 도우미는 해당 범위를 너비 400 포인트, 높이 100 포인트인 프레임에 맞게 스케일링합니다. 수정된 통합 문서를 스트림에 저장한 후, [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) 은 지정된 크기로 삽입합니다. 96 DPI로 렌더링된 미리보기는 [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) 을 통해 할당되어, 저장된 프레젠테이션이 기본 자리표시자 대신 선택된 셀을 표시하도록 합니다.

스케일링 도우미는 선택된 범위에 대해 별도의 너비와 높이 비율을 계산하여 열의 상대 너비와 행의 상대 높이를 유지합니다. 계산된 치수를 포인트에서 인치로 변환한 후 [Cells.setColumnWidthInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setcolumnwidthinch) 와 [Cells.setRowHeightInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setrowheightinch) 로 적용합니다. 선택된 범위는 너비와 높이가 0이 아니어야 합니다.

이 미리보기 도우미는 [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) 를 사용하여 크기가 조정된 범위를 렌더링합니다. [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) 를 해당 범위로 제한하고, 여백, 머리글 및 바닥글을 제거한 뒤, 시작 위치에 배치된 PNG 스트림을 반환합니다.

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

    # 워크북이 PowerPoint에서 OLE 개체로 사용될 때 표시되는 크기를 설정합니다.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # 셀 범위를 프레임 크기에 맞게 스케일링합니다.
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

            # OLE 개체 프레임을 생성합니다.
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

워크시트 크기 조정 문제를 해결하기 위한 두 가지 접근 방식이 있습니다. 요구 사항 및 사용 사례에 가장 적합한 접근 방식을 선택하십시오. 두 접근 방식 모두 템플릿에서 생성했든 처음부터 만들었든 동일하게 작동합니다. 또한 이 솔루션에서는 OLE 개체 프레임 크기에 제한이 없습니다.

{{% /alert %}}

## **자주 묻는 질문**

**PowerPoint에서 삽입된 Excel 워크시트가 처음 활성화될 때 크기가 변경되는 이유는 무엇인가요?**

이는 Excel이 활성화될 때 원래 창 크기를 유지하려고 시도하고, PowerPoint의 OLE 개체 프레임은 자체적인 차원을 가지고 있기 때문입니다. PowerPoint와 Excel은 비율을 유지하도록 크기를 협상하며, 이 과정에서 크기 조정이 발생할 수 있습니다.

**이 크기 조정 문제를 완전히 방지할 수 있나요?**

예. OLE 프레임을 Excel 셀 범위 크기에 맞게 스케일링하거나 셀 범위를 원하는 OLE 프레임 크기에 맞게 스케일링하면 원하지 않는 크기 조정을 방지할 수 있습니다.

**어떤 스케일링 방법을 사용해야 하나요, OLE 프레임 스케일링인가요 셀 범위 스케일링인가요?**

원본 Excel 행 및 열 크기를 유지하려면 **OLE 프레임 스케일링** 을 선택하십시오. 프레젠테이션에서 OLE 프레임을 고정된 크기로 사용하려면 **셀 범위 스케일링** 을 선택하십시오.

**프레젠테이션이 템플릿 기반인 경우에도 이 솔루션이 작동하나요?**

예. 두 솔루션 모두 템플릿에서 만든 프레젠테이션과 처음부터 만든 프레젠테이션 모두에 적용됩니다.

**이 방법들을 사용할 때 OLE 프레임 크기에 제한이 있나요?**

아니요. 적절히 스케일을 설정하면 OLE 개체 프레임을 원하는 아무 크기로도 만들 수 있습니다.

**"EMBEDDED OLE OBJECT" 자리표시자 텍스트를 PowerPoint에서 피할 수 있는 방법이 있나요?**

예. 대상 Excel 셀 범위의 스냅샷을 촬영하여 OLE 프레임의 자리표시자 이미지로 설정하면 기본 자리표시자 대신 사용자 지정 미리보기 이미지를 표시할 수 있습니다.

## **관련 기사**

[Excel 차트 만들기 및 OLE 개체로 프레젠테이션에 삽입하기](/slides/ko/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint 추가 기능을 사용하여 OLE 개체 자동 업데이트](/slides/ko/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)