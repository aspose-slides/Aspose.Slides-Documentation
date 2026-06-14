---
title: Giải pháp thực tế cho việc thay đổi kích thước bảng tính
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
description: "Khắc phục việc thay đổi kích thước OLE của bảng tính Excel trong bản trình chiếu: hai cách để giữ khung đối tượng nhất quán—điều chỉnh kích thước khung hoặc bảng tính—trên các định dạng PPT và PPTX."
---
{{% alert color="primary" %}} 
Đã được ghi nhận rằng các bảng tính Excel được nhúng dưới dạng đối tượng OLE trong một bản trình chiếu PowerPoint thông qua các thành phần Aspose bị thay đổi kích thước theo một tỷ lệ không xác định sau lần kích hoạt đầu tiên. Hành vi này tạo ra sự khác biệt về hình ảnh đáng chú ý trong bản trình chiếu giữa trạng thái trước và sau khi kích hoạt đối tượng OLE. Chúng tôi đã nghiên cứu chi tiết vấn đề này và đưa ra giải pháp, được trình bày trong bài viết này.
{{% /alert %}} 

## **Nền tảng**

Trong bài viết [Manage OLE](/slides/vi/python-net/manage-ole/), chúng tôi đã giải thích cách thêm một khung OLE vào bản trình chiếu PowerPoint bằng cách sử dụng Aspose.Slides cho Python thông qua .NET. Để giải quyết [object preview issue](/slides/vi/python-net/object-preview-issue-when-adding-oleobjectframe/), chúng tôi đã gán một hình ảnh của vùng bảng tính được chọn cho khung đối tượng OLE. Trong bản trình chiếu đầu ra, khi bạn nhấp đúp vào khung đối tượng OLE hiển thị hình ảnh bảng tính, sổ làm việc Excel sẽ được kích hoạt. Người dùng cuối có thể thực hiện bất kỳ thay đổi nào mong muốn đối với sổ làm việc Excel thực tế và sau đó quay lại slide bằng cách nhấp ra ngoài sổ làm việc Excel đã kích hoạt. Kích thước của khung đối tượng OLE sẽ thay đổi khi người dùng quay lại slide. Hệ số thay đổi kích thước sẽ khác nhau tùy thuộc vào kích thước của khung đối tượng OLE và sổ làm việc Excel được nhúng. 

## **Nguyên nhân gây ra việc thay đổi kích thước**

Vì sổ làm việc Excel có kích thước cửa sổ riêng, nó cố gắng giữ nguyên kích thước gốc khi được kích hoạt lần đầu. Mặt khác, khung đối tượng OLE có kích thước riêng của nó. Theo Microsoft, khi sổ làm việc Excel được kích hoạt, Excel và PowerPoint sẽ thương lượng kích thước để đảm bảo duy trì tỉ lệ chính xác như một phần của quá trình nhúng. Việc thay đổi kích thước xảy ra dựa trên sự chênh lệch giữa kích thước cửa sổ Excel và kích thước cũng như vị trí của khung đối tượng OLE. 

## **Giải pháp**

- Điều chỉnh kích thước khung OLE trong bản trình chiếu PowerPoint để khớp với chiều cao và chiều rộng của số lượng hàng và cột mong muốn trong khung OLE.  
- Giữ kích thước khung OLE cố định và điều chỉnh kích thước của các hàng và cột tham gia để vừa với kích thước khung OLE đã chọn.  

### **Điều chỉnh kích thước khung OLE**

Trong cách tiếp cận này, chúng ta sẽ học cách đặt kích thước khung OLE của sổ làm việc Excel được nhúng để khớp với kích thước tổng hợp của các hàng và cột tham gia trong bảng tính Excel.  

Giả sử chúng ta có một bảng tính Excel mẫu và muốn thêm nó vào bản trình chiếu dưới dạng khung OLE. Trong trường hợp này, kích thước của khung đối tượng OLE sẽ được tính toán đầu tiên dựa trên tổng chiều cao các hàng và chiều rộng các cột của các hàng và cột tham gia trong sổ làm việc. Sau đó, chúng ta sẽ đặt kích thước của khung OLE thành giá trị đã tính. Để tránh thông báo màu đỏ "EMBEDDED OLE OBJECT" cho khung OLE trong PowerPoint, chúng ta cũng sẽ chụp một hình ảnh của các phần mong muốn của các hàng và cột trong sổ làm việc và đặt nó làm hình ảnh cho khung OLE.  

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

    # Đặt kích thước hiển thị khi tệp sổ làm việc được sử dụng làm đối tượng OLE trong PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # Lấy chiều rộng và chiều cao của hình ảnh OLE tính bằng điểm.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # Chúng ta cần sử dụng sổ làm việc đã được sửa đổi.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Thêm hình ảnh OLE vào tài nguyên bản trình chiếu.
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

Trong cách tiếp cận này, chúng ta sẽ học cách điều chỉnh chiều cao của các hàng tham gia và chiều rộng của các cột tham gia để khớp với kích thước khung OLE tùy chỉnh.  

Giả sử chúng ta có một bảng tính Excel mẫu và muốn thêm nó vào bản trình chiếu dưới dạng khung OLE. Trong trường hợp này, chúng ta sẽ đặt kích thước của khung OLE và điều chỉnh kích thước của các hàng và cột tham gia vào khu vực khung OLE. Sau đó, chúng ta sẽ lưu sổ làm việc vào một luồng để áp dụng các thay đổi và chuyển đổi nó thành mảng byte để thêm vào khung OLE. Để tránh thông báo màu đỏ "EMBEDDED OLE OBJECT" cho khung OLE trong PowerPoint, chúng ta cũng sẽ chụp một hình ảnh của các phần mong muốn của các hàng và cột trong sổ làm việc và đặt nó làm hình ảnh cho khung OLE.  

```py
# <param name="width">Chiều rộng mong muốn của vùng ô tính bằng điểm.</param>
# <param name="height">Chiều cao mong muốn của vùng ô tính bằng điểm.</param>
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

    # Đặt kích thước hiển thị khi tệp sổ làm việc được sử dụng làm đối tượng OLE trong PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Điều chỉnh tỷ lệ phạm vi ô để vừa với kích thước khung.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # Chúng ta cần sử dụng sổ làm việc đã được sửa đổi.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Thêm hình ảnh OLE vào tài nguyên bản trình chiếu.
            ole_image = presentation.images.add_image(image_stream)

            # Tạo khung đối tượng OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Kết luận**

{{% alert color="primary" %}}
Có hai cách tiếp cận để khắc phục vấn đề thay đổi kích thước bảng tính. Việc chọn cách tiếp cận phù hợp phụ thuộc vào yêu cầu và trường hợp sử dụng cụ thể. Cả hai cách đều hoạt động tương tự, bất kể bản trình chiếu được tạo từ mẫu hay từ đầu. Ngoài ra, không có giới hạn nào về kích thước của khung đối tượng OLE trong giải pháp này.
{{% /alert %}}