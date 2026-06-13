---
title: 워크시트 크기 조정을 위한 실용적인 해결책
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
description: "프레젠테이션에서 Excel 워크시트 OLE 크기 조정을 해결합니다: 개체 프레임을 일관되게 유지하기 위한 두 가지 방법—프레임을 확대하거나 시트를 확대—PPT 및 PPTX 형식 전반에 걸쳐."
---
{{% alert color="primary" %}} 

Aspose 구성 요소를 통해 PowerPoint 프레젠테이션에 OLE 개체로 삽입된 Excel 워크시트가 첫 번째 활성화 후 알 수 없는 비율로 크기가 조정되는 현상이 관찰되었습니다. 이 동작으로 인해 OLE 개체의 활성화 전후 상태 사이에 프레젠테이션에서 눈에 띄는 시각적 차이가 발생합니다. 우리는 이 문제를 상세히 조사하고 해결책을 제공했으며, 이 기사에서 다루고 있습니다.

{{% /alert %}} 

## **배경**

문서 [Manage OLE](/slides/ko/python-net/manage-ole/)에서는 Aspose.Slides for Python via .NET를 사용하여 PowerPoint 프레젠테이션에 OLE 프레임을 추가하는 방법을 설명했습니다. [object preview issue](/slides/ko/python-net/object-preview-issue-when-adding-oleobjectframe/)를 해결하기 위해 선택한 워크시트 영역의 이미지를 OLE 개체 프레임에 할당했습니다. 출력 프레젠테이션에서 워크시트 이미지를 표시하는 OLE 개체 프레임을 두 번 클릭하면 Excel 워크북이 활성화됩니다. 최종 사용자는 실제 Excel 워크북을 원하는 대로 수정한 후 활성화된 Excel 워크북 외부를 클릭하여 슬라이드로 돌아갈 수 있습니다. 사용자가 슬라이드로 돌아가면 OLE 개체 프레임의 크기가 변경됩니다. 크기 변경 비율은 OLE 개체 프레임과 삽입된 Excel 워크북의 크기에 따라 달라집니다.

## **크기 변경 원인**

Excel 워크북은 자체 창 크기를 가지고 있어 첫 번째 활성화 시 원래 크기를 유지하려고 합니다. 반면 OLE 개체 프레임은 자체 크기를 가지고 있습니다. Microsoft에 따르면 Excel 워크북이 활성화될 때 Excel과 PowerPoint가 크기를 협상하여 임베딩 과정의 일환으로 올바른 비율을 유지하도록 합니다. 크기 변경은 Excel 창 크기와 OLE 개체 프레임의 크기 및 위치 차이에 따라 발생합니다.

## **작동 가능한 솔루션**

크기 조정 효과를 방지하기 위해 두 가지 가능한 솔루션이 있습니다.

- PowerPoint 프레젠테이션에서 OLE 프레임의 크기를 OLE 프레임에 원하는 행 및 열 수의 높이와 너비에 맞게 조정합니다.
- OLE 프레임 크기를 일정하게 유지하고 참여하는 행과 열의 크기를 선택한 OLE 프레임 크기에 맞게 조정합니다.

### **OLE 프레임 크기 조정**

이 방법에서는 삽입된 Excel 워크북의 OLE 프레임 크기를 Excel 워크시트에서 참여하는 행과 열의 누적 크기에 맞게 설정하는 방법을 배웁니다.

템플릿 Excel 시트가 있고 이를 OLE 프레임으로 프레젠테이션에 추가한다고 가정해 보겠습니다. 이 경우 OLE 개체 프레임의 크기는 먼저 워크북에서 참여하는 행과 열의 누적 행 높이와 열 너비를 기준으로 계산됩니다. 그런 다음 계산된 값으로 OLE 프레임의 크기를 설정합니다. PowerPoint에서 OLE 프레임에 대한 빨간색 "EMBEDDED OLE OBJECT" 메시지를 피하기 위해 워크북의 원하는 행 및 열 부분의 이미지를 캡처하여 OLE 프레임 이미지로 설정합니다.

```py
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

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # PowerPoint에서 워크북 파일을 OLE 개체로 사용할 때 표시 크기를 설정합니다.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # OLE 이미지의 너비와 높이를 포인트 단위로 가져옵니다.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # 수정된 워크북을 사용해야 합니다.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # OLE 이미지를 프레젠테이션 리소스에 추가합니다.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # OLE 개체 프레임을 생성합니다.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **셀 범위 크기 조정**

이 방법에서는 사용자 정의 OLE 프레임 크기에 맞게 참여하는 행의 높이와 열의 너비를 조정하는 방법을 배웁니다.

템플릿 Excel 시트가 있고 이를 OLE 프레임으로 프레젠테이션에 추가한다고 가정해 보겠습니다. 이 경우 OLE 프레임의 크기를 설정하고 OLE 프레임 영역에 포함되는 행과 열의 크기를 조정합니다. 그런 다음 변경 사항을 적용하기 위해 워크북을 스트림에 저장하고 OLE 프레임에 추가하기 위해 바이트 배열로 변환합니다. PowerPoint에서 OLE 프레임에 대한 빨간색 "EMBEDDED OLE OBJECT" 메시지를 피하기 위해 워크북의 원하는 행 및 열 부분의 이미지를 캡처하여 OLE 프레임 이미지로 설정합니다.

```py
# <param name="width">셀 범위의 예상 너비(포인트 단위)입니다.</param>
# <param name="height">셀 범위의 예상 높이(포인트 단위)입니다.</param>
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

```py
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

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # PowerPoint에서 워크북 파일을 OLE 개체로 사용할 때 표시 크기를 설정합니다.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # 셀 범위를 프레임 크기에 맞게 확대/축소합니다.
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

            # OLE 개체 프레임을 생성합니다.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **결론**

{{% alert color="primary" %}}

워크시트 크기 변경 문제를 해결하는 데는 두 가지 접근 방식이 있습니다. 적절한 접근 방식을 선택하는 것은 특정 요구 사항 및 사용 사례에 따라 달라집니다. 두 접근 방식 모두 템플릿에서 프레젠테이션을 만들든 처음부터 만들든 동일하게 작동합니다. 또한 이 솔루션에서는 OLE 개체 프레임 크기에 제한이 없습니다.

{{% /alert %}}