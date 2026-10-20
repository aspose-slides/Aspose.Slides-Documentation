---
title: Giải pháp hoạt động cho việc thay đổi kích thước bảng tính
type: docs
weight: 40
url: /vi/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- hình ảnh xem trước
- điều chỉnh kích thước hình ảnh
- Excel
- bảng tính
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Khắc phục việc thay đổi kích thước OLE của bảng tính Excel trong bản trình chiếu: hai cách để giữ khung đối tượng nhất quán—điều chỉnh khung hoặc bảng tính—trên các định dạng PPT và PPTX."
---
{{% alert color="info" title="Note" %}}
Các bảng tính Excel được nhúng dưới dạng đối tượng OLE trong bản trình chiếu PowerPoint sử dụng thành phần Aspose có thể thay đổi kích thước một cách không mong muốn sau lần kích hoạt đầu tiên. Hành vi này tạo ra sự khác biệt rõ ràng về hình ảnh giữa đối tượng OLE trước và sau khi kích hoạt. Bài viết này giải thích vấn đề và mô tả hai cách khắc phục.
{{% /alert %}} 

## **Bối cảnh**

Trong bài viết [Quản lý OLE](/slides/vi/python-net/manage-ole/), chúng tôi đã giải thích cách thêm khung OLE vào bản trình chiếu PowerPoint bằng Aspose.Slides for Python via .NET. Để giải quyết [vấn đề xem trước đối tượng](/slides/vi/python-net/object-preview-issue-when-adding-oleobjectframe/), chúng tôi gán một hình ảnh của vùng bảng tính đã chọn cho khung đối tượng OLE. Trong bản trình chiếu đầu ra, khi bạn nhấp đúp vào khung đối tượng OLE hiển thị hình ảnh bảng tính, sổ làm việc Excel sẽ được kích hoạt. Người dùng cuối có thể thực hiện bất kỳ thay đổi nào cho sổ Excel thực tế và sau đó quay lại slide bằng cách nhấp ra ngoài sổ Excel đã kích hoạt. Kích thước của khung đối tượng OLE sẽ thay đổi khi người dùng quay lại slide. Hệ số thay đổi kích thước sẽ khác nhau tùy thuộc vào kích thước của khung OLE và sổ Excel được nhúng. 

## **Nguyên nhân gây thay đổi kích thước**

Vì sổ làm việc Excel có kích thước cửa sổ riêng, nó cố gắng giữ nguyên kích thước gốc khi được kích hoạt lần đầu. Ngược lại, khung đối tượng OLE có kích thước của riêng nó. Theo Microsoft, khi sổ Excel được kích hoạt, Excel và PowerPoint sẽ thương lượng kích thước để đảm bảo duy trì tỉ lệ đúng trong quá trình nhúng. Việc thay đổi kích thước xảy ra dựa trên sự khác biệt giữa kích thước cửa sổ Excel và kích thước, vị trí của khung OLE. 

## **Giải pháp hoạt động**

Có hai giải pháp có thể để tránh hiệu ứng thay đổi kích thước.

- Điều chỉnh tỷ lệ khung OLE trong bản trình chiếu PowerPoint để khớp với tổng chiều cao và chiều rộng của các hàng và cột đã chọn.  
- Giữ kích thước khung OLE cố định và thay đổi tỷ lệ các hàng và cột đã chọn để vừa vào trong nó.  

### **Điều chỉnh kích thước khung OLE**

Cách tiếp cận này đặt kích thước khung OLE sao cho phù hợp với tổng chiều cao và chiều rộng của các hàng và cột đã chọn trong bảng tính Excel được nhúng.

Ví dụ tải một sổ Excel hiện có và chọn 10 hàng đầu tiên và 13 cột đầu tiên của worksheet đầu tiên bằng chỉ mục bắt đầu từ 0. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) xác định phạm vi hiển thị. Bản xem trước được render ở 96 DPI và kích thước pixel của nó được chuyển đổi sang point bằng 72 point mỗi inch. [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) nhúng sổ đã chỉnh sửa vào một khung với các kích thước đó. Bản xem trước được gán qua [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) để thay thế placeholder "EMBEDDED OLE OBJECT" trong bản trình chiếu đã lưu.

Trợ giúp xem trước đặt [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) thành phạm vi đã chọn và loại bỏ lề, header và footer. Khi bật [ImageOrPrintOptions.only_area](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/imageorprintoptions/only_area/), [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) render phạm vi dưới dạng ảnh PNG. Trợ giúp này đưa con trỏ stream ảnh về đầu trước khi trả về để sử dụng trong bản trình chiếu.
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

Ví dụ đầy đủ bên dưới kết hợp các trợ giúp với việc nhúng sổ và lưu bản trình chiếu dưới dạng `output.pptx`.
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

    # Đặt kích thước hiển thị khi tệp sổ làm việc được sử dụng làm đối tượng OLE trong PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # Lấy chiều rộng và chiều cao của hình ảnh OLE tính bằng point.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # Chúng ta cần sử dụng sổ làm việc đã được chỉnh sửa.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Thêm hình ảnh OLE vào các tài nguyên của bản trình chiếu.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # Tạo khung đối tượng OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Điều chỉnh kích thước phạm vi ô**

Cách tiếp cận này thay đổi chiều cao của các hàng đã chọn và chiều rộng của các cột đã chọn để khớp với một khung OLE tùy chỉnh.

Ví dụ tải một sổ Excel hiện có và chọn 10 hàng đầu tiên và 13 cột đầu tiên của worksheet đầu tiên bằng chỉ mục bắt đầu từ 0. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) xác định phạm vi hiển thị, và trợ giúp bên dưới thay đổi tỷ lệ phạm vi đó để vừa vào một khung rộng 400 point và cao 100 point. Sau khi lưu sổ đã chỉnh sửa vào một stream, [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) nhúng nó với kích thước đã chỉ định. Một bản xem trước được render ở 96 DPI và được gán qua [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/), vì vậy bản trình chiếu đã lưu sẽ hiển thị các ô đã chọn thay vì placeholder mặc định.

Trợ giúp thay đổi tỷ lệ tính toán các tỉ lệ chiều rộng và chiều cao riêng biệt cho phạm vi đã chọn, bảo toàn độ rộng tương đối của các cột và độ cao tương đối của các hàng. Nó chuyển đổi các kích thước tính được từ point sang inch trước khi áp dụng chúng bằng [Cells.set_column_width_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_column_width_inch/) và [Cells.set_row_height_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_row_height_inch/). Phạm vi đã chọn phải có chiều rộng và chiều cao khác 0.
```py
import aspose.cells as cells

# <param name="width">Chiều rộng mong đợi của phạm vi ô tính bằng point.</param>
# <param name="height">Chiều cao mong đợi của phạm vi ô tính bằng point.</param>
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

Trợ giúp xem trước này render phạm vi đã thay đổi kích thước bằng [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/). Nó giới hạn [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) trong phạm vi đó, loại bỏ lề, header và footer, và trả về một stream PNG đặt ở vị trí đầu.
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

Ví dụ đầy đủ bên dưới kết hợp các trợ giúp với việc nhúng sổ và lưu bản trình chiếu dưới dạng `output.pptx`.
```py
import io
import aspose.slides as slides
import aspose.cells as cells

# <param name="width">Chiều rộng mong đợi của phạm vi ô tính bằng point.</param>
# <param name="height">Chiều cao mong đợi của phạm vi ô tính bằng point.</param>
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

    # Đặt kích thước hiển thị khi tệp sổ làm việc được sử dụng làm đối tượng OLE trong PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Điều chỉnh kích thước phạm vi ô để vừa với kích thước khung.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # Chúng ta cần sử dụng sổ làm việc đã được chỉnh sửa.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Thêm hình ảnh OLE vào các tài nguyên của bản trình chiếu.
            ole_image = presentation.images.add_image(image_stream)

            # Tạo khung đối tượng OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Kết luận**

{{% alert color="info" title="Note" %}}
Có hai cách tiếp cận để khắc phục vấn đề thay đổi kích thước bảng tính. Hãy chọn cách tiếp cận phù hợp nhất với yêu cầu và trường hợp sử dụng của bạn. Cả hai cách đều hoạt động theo cùng một cách, bất kể bản trình chiếu được tạo từ mẫu hay từ đầu. Ngoài ra, không có giới hạn nào về kích thước của khung OLE trong giải pháp này.
{{% /alert %}}

## **FAQ**

**Tại sao một bảng tính Excel được nhúng lại thay đổi kích thước khi lần đầu tiên kích hoạt trong PowerPoint?**

Điều này xảy ra vì Excel cố gắng duy trì kích thước cửa sổ gốc khi được kích hoạt, trong khi khung OLE trong PowerPoint có kích thước riêng. PowerPoint và Excel sẽ thương lượng kích thước để duy trì tỉ lệ, điều này có thể gây ra việc thay đổi kích thước.

**Liệu có thể ngăn hoàn toàn vấn đề thay đổi kích thước này không?**

Có. Bằng cách điều chỉnh khung OLE để vừa với kích thước phạm vi ô Excel hoặc điều chỉnh phạm vi ô để vừa với khung OLE mong muốn, bạn có thể ngăn việc thay đổi kích thước không mong muốn.

**Nên sử dụng phương pháp điều chỉnh nào, điều chỉnh khung OLE hay điều chỉnh phạm vi ô?**

Chọn **điều chỉnh khung OLE** nếu bạn muốn giữ nguyên kích thước hàng và cột gốc của Excel. Chọn **điều chỉnh phạm vi ô** nếu bạn muốn khung OLE trong bản trình chiếu có kích thước cố định.

**Các giải pháp này có hoạt động nếu bản trình chiếu của tôi dựa trên mẫu không?**

Có. Cả hai giải pháp đều hoạt động cho bản trình chiếu được tạo từ mẫu và từ đầu.

**Có giới hạn nào về kích thước của khung OLE khi sử dụng các phương pháp này không?**

Không. Bạn có thể đặt khung OLE ở bất kỳ kích thước nào miễn là bạn thiết lập tỉ lệ phù hợp.

**Có cách nào để tránh văn bản placeholder "EMBEDDED OLE OBJECT" trong PowerPoint không?**

Có. Bằng cách chụp ảnh phạm vi ô Excel mục tiêu và đặt nó làm hình ảnh placeholder của khung OLE, bạn có thể hiển thị một hình ảnh xem trước tùy chỉnh thay vì placeholder mặc định.