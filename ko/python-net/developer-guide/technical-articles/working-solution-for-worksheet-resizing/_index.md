---
title: 워크시트 크기 조정에 대한 작업 솔루션
type: docs
weight: 40
url: /ko/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 미리보기 이미지
- 이미지 크기 조정
- Excel
- 워크시트
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "프레젠테이션에서 Excel 워크시트 OLE 크기 조정을 해결합니다: 객체 프레임을 일관되게 유지하는 두 가지 방법—프레임을 스케일링하거나 시트를 스케일링—PPT 및 PPTX 형식 전체에 적용됩니다."
---
{{% alert color="info" title="Note" %}}

Aspose 구성 요소를 사용하여 PowerPoint 프레젠테이션에 OLE 객체로 삽입된 Excel 워크시트는 처음 활성화된 후 예상치 않게 크기가 조정될 수 있습니다. 이 동작은 OLE 객체가 활성화되기 전후에 눈에 띄는 시각적 차이를 만들게 됩니다. 이 문서에서는 해당 문제를 설명하고 해결 방법 두 가지를 소개합니다.

{{% /alert %}} 

## **배경**

이 문서 [OLE 관리](/slides/ko/python-net/manage-ole/)에서는 Aspose.Slides for Python via .NET을 사용하여 PowerPoint 프레젠테이션에 OLE 프레임을 추가하는 방법을 설명했습니다. [객체 미리보기 문제](/slides/ko/python-net/object-preview-issue-when-adding-oleobjectframe/)를 해결하기 위해 선택한 워크시트 영역의 이미지를 OLE 객체 프레임에 할당했습니다. 출력 프레젠테이션에서 워크시트 이미지를 표시하는 OLE 객체 프레임을 두 번 클릭하면 Excel 통합 문서가 활성화됩니다. 최종 사용자는 실제 Excel 통합 문서에서 원하는 변경을 수행한 다음 활성화된 Excel 통합 문서 외부를 클릭하여 슬라이드로 돌아갈 수 있습니다. 사용자가 슬라이드로 돌아가면 OLE 객체 프레임의 크기가 변경됩니다. 크기 조정 비율은 OLE 객체 프레임의 크기와 삽입된 Excel 통합 문서의 크기에 따라 달라집니다.

## **크기 조정 원인**

Excel 통합 문서는 자체 창 크기를 가지고 있기 때문에 처음 활성화될 때 원래 크기를 유지하려고 합니다. 반면 OLE 객체 프레임은 자체 크기를 가지고 있습니다. Microsoft에 따르면 Excel 통합 문서가 활성화될 때 Excel과 PowerPoint가 크기를 협상하여 삽입 과정에서 올바른 비율을 유지하도록 합니다. 크기 조정은 Excel 창 크기와 OLE 객체 프레임의 크기 및 위치 차이에 따라 발생합니다.

## **해결 방법**

크기 조정 효과를 방지하기 위한 두 가지 가능한 해결책이 있습니다.

- PowerPoint 프레젠테이션에서 OLE 프레임을 선택한 행과 열의 전체 높이와 너비에 맞게 스케일링합니다.
- OLE 프레임 크기를 고정하고 선택한 행과 열을 프레임 내부에 맞게 스케일링합니다.

### **OLE 프레임 크기 조정**

이 방법은 삽입된 Excel 워크시트에서 선택한 행과 열의 전체 높이와 너비에 맞게 OLE 프레임 크기를 설정합니다.

예제는 기존 Excel 통합 문서를 로드하고 0부터 시작하는 인덱스를 사용하여 첫 번째 워크시트의 처음 10행과 13열을 선택합니다. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/)는 표시 범위를 정의합니다. 미리보기는 96 DPI로 렌더링되며 픽셀 차원은 인치당 72포인트를 사용하여 포인트로 변환됩니다. [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/)은 수정된 통합 문서를 해당 차원의 프레임에 삽입합니다. 미리보기는 [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/)을 통해 저장된 프레젠테이션의 "EMBEDDED OLE OBJECT" 자리 표시자를 교체하도록 할당됩니다.

미리보기 도우미는 [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/)를 선택된 범위로 설정하고 여백, 헤더 및 푸터를 제거합니다. [ImageOrPrintOptions.only_area](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/imageorprintoptions/only_area/)를 활성화하면 [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/)가 범위를 PNG 이미지로 렌더링합니다. 도우미는 프레젠테이션에서 사용하기 전에 이미지 스트림을 다시 시작합니다.

```py
import io
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

아래 전체 예제는 도우미와 통합 문서 삽입을 결합하고 프레젠테이션을 `output.pptx`로 저장합니다.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # PowerPoint에서 통합 문서 파일을 OLE 객체로 사용할 때 표시 크기를 설정합니다.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # OLE 이미지의 너비와 높이를 포인트 단위로 가져옵니다.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # 수정된 통합 문서를 사용해야 합니다.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # OLE 이미지를 프레젠테이션 리소스에 추가합니다.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # OLE 객체 프레임을 생성합니다.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **셀 범위 크기 조정**

이 방법은 선택한 행의 높이와 선택한 열의 너비를 맞춤형 OLE 프레임 크기에 맞게 스케일링합니다.

예제는 기존 Excel 통합 문서를 로드하고 0부터 시작하는 인덱스를 사용하여 첫 번째 워크시트의 처음 10행과 13열을 선택합니다. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/)는 표시 범위를 정의하고, 아래 도우미는 해당 범위를 폭 400포인트, 높이 100포인트인 프레임에 맞게 스케일링합니다. 수정된 통합 문서를 스트림에 저장한 후, [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/)를 사용해 지정된 크기로 삽입합니다. 96 DPI로 렌더링된 미리보기는 [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/)을 통해 할당되어, 저장된 프레젠테이션이 기본 자리 표시자 대신 선택한 셀을 표시하도록 합니다.

스케일링 도우미는 선택된 범위에 대해 열의 상대적인 너비와 행의 상대적인 높이를 유지하면서 별도의 너비 및 높이 비율을 계산합니다. 계산된 치수를 포인트에서 인치로 변환한 후 [Cells.set_column_width_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_column_width_inch/) 및 [Cells.set_row_height_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_row_height_inch/)을 사용하여 적용합니다. 선택된 범위는 너비와 높이가 0이 아니어야 합니다.

```py
import aspose.cells as cells

# <param name="width">셀 범위의 예상 너비(포인트 단위).</param>
# <param name="height">셀 범위의 예상 높이(포인트 단위).</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)
```

이 미리보기 도우미는 [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/)을 사용해 크기가 조정된 범위를 렌더링합니다. [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/)를 해당 범위로 제한하고, 여백, 헤더 및 푸터를 제거한 뒤 시작 위치에 있는 PNG 스트림을 반환합니다.

```py
import io
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

아래 전체 예제는 도우미와 통합 문서 삽입을 결합하고 프레젠테이션을 `output.pptx`로 저장합니다.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

# <param name="width">셀 범위의 예상 너비(포인트 단위).</param>
# <param name="height">셀 범위의 예상 높이(포인트 단위).</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # 워크북 파일을 PowerPoint에서 OLE 객체로 사용할 때 표시 크기를 설정합니다.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # 프레임 크기에 맞게 셀 범위를 스케일링합니다.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # 수정된 워크북을 사용해야 합니다.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # OLE 이미지를 프레젠테이션 리소스에 추가합니다.
            ole_image = presentation.images.add_image(image_stream)

            # OLE 객체 프레임을 생성합니다.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **결론**

{{% alert color="info" title="Note" %}}

워크시트 크기 조정 문제를 해결하는 두 가지 접근 방식이 있습니다. 요구 사항과 사용 사례에 가장 적합한 접근 방식을 선택하십시오. 두 접근 방식 모두 템플릿에서 만들든 처음부터 만들든 동일하게 작동합니다. 또한 이 솔루션에서는 OLE 객체 프레임 크기에 제한이 없습니다.

{{% /alert %}}

## **FAQ**

**왜 삽입된 Excel 워크시트가 PowerPoint에서 처음 활성화될 때 크기가 변경되나요?**

이는 Excel이 활성화될 때 원래 창 크기를 유지하려고 하고, PowerPoint의 OLE 객체 프레임은 자체 차원을 가지고 있기 때문에 발생합니다. PowerPoint와 Excel가 비율을 유지하도록 크기를 협상하며, 이 과정에서 크기 조정이 일어날 수 있습니다.

**이 크기 조정 문제를 완전히 방지할 수 있나요?**

예. OLE 프레임을 Excel 셀 범위 크기에 맞게 스케일링하거나 셀 범위를 원하는 OLE 프레임 크기에 맞게 스케일링하면 원치 않는 크기 조정을 방지할 수 있습니다.

**어떤 스케일링 방식을 사용해야 하나요, OLE 프레임 스케일링인가 셀 범위 스케일링인가?**

원본 Excel 행 및 열 크기를 유지하려면 **OLE 프레임 스케일링**을 선택하십시오. 프레젠테이션에서 OLE 프레임을 고정된 크기로 만들고 싶다면 **셀 범위 스케일링**을 선택하십시오.

**프레젠테이션이 템플릿 기반이면 이 솔루션이 작동하나요?**

예. 두 솔루션 모두 템플릿에서 만든 프레젠테이션과 처음부터 만든 프레젠테이션 모두에 적용됩니다.

**이 방법을 사용할 때 OLE 프레임 크기에 제한이 있나요?**

아니오. 적절히 스케일을 설정하기만 하면 OLE 객체 프레임을 원하는 어느 크기로든 만들 수 있습니다.

**PowerPoint에서 "EMBEDDED OLE OBJECT" 자리 표시자 텍스트를 피할 방법이 있나요?**

예. 대상 Excel 셀 범위의 스냅샷을 찍어 이를 OLE 프레임의 자리 표시자 이미지로 설정하면 기본 자리 표시자 대신 사용자 정의 미리보기 이미지를 표시할 수 있습니다.