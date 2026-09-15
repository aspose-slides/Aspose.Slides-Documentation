---
title: "Giải pháp hoạt động cho việc thay đổi kích thước bảng tính"
type: docs
weight: 20
url: /vi/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- hình ảnh xem trước
- thay đổi kích thước hình ảnh
- Excel
- bảng tính
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Khắc phục việc thay đổi kích thước OLE của bảng tính Excel trong bản trình chiếu: hai cách để giữ khung đối tượng nhất quán—điều chỉnh tỷ lệ khung hoặc bảng tính—trên các định dạng PPT và PPTX."
---
{{% alert color="info" title="Note" %}}
Đã được ghi nhận rằng các worksheet Excel được nhúng dưới dạng đối tượng OLE trong bản trình chiếu PowerPoint thông qua các thành phần Aspose sẽ được thay đổi kích thước theo một tỷ lệ không xác định sau lần kích hoạt đầu tiên. Hành vi này tạo ra sự khác biệt rõ rệt về hình ảnh trong bản trình chiếu giữa trạng thái trước và sau khi kích hoạt đối tượng OLE. Chúng tôi đã điều tra chi tiết vấn đề này và cung cấp một giải pháp, được trình bày trong bài viết này.
{{% /alert %}}

## **Bối cảnh**

Trong bài viết [Manage OLE](/slides/vi/python-java/manage-ole/), chúng tôi đã giải thích cách thêm một khung OLE vào bản trình chiếu PowerPoint bằng cách sử dụng Aspose.Slides for Python qua Java. Để giải quyết [object preview issue](/slides/vi/python-java/object-preview-issue-when-adding-oleobjectframe/), chúng tôi đã gán một hình ảnh của vùng worksheet đã chọn cho khung đối tượng OLE. Trong bản trình chiếu đầu ra, khi bạn nhấp đúp vào khung OLE hiển thị hình ảnh worksheet, workbook Excel sẽ được kích hoạt. Người dùng cuối có thể thực hiện bất kỳ thay đổi nào mong muốn đối với workbook Excel thực tế và sau đó quay lại slide bằng cách nhấp ra ngoài workbook Excel đã kích hoạt. Kích thước của khung OLE sẽ thay đổi khi người dùng quay lại slide. Hệ số thay đổi kích thước sẽ khác nhau tùy thuộc vào kích thước của khung OLE và workbook Excel nhúng.

## **Nguyên nhân của việc thay đổi kích thước**

Vì workbook Excel có kích thước cửa sổ riêng, nó cố gắng duy trì kích thước gốc khi lần đầu tiên được kích hoạt. Mặt khác, khung đối tượng OLE cũng có kích thước riêng. Theo Microsoft, khi workbook Excel được kích hoạt, Excel và PowerPoint sẽ thương lượng kích thước để đảm bảo duy trì tỷ lệ đúng như một phần của quá trình nhúng. Việc thay đổi kích thước xảy ra dựa trên sự khác biệt giữa kích thước cửa sổ Excel và kích thước cùng vị trí của khung OLE.

## **Giải pháp hoạt động**

Có hai giải pháp khả thi để tránh hiệu ứng thay đổi kích thước.

- Thay đổi kích thước khung OLE trong bản trình chiếu PowerPoint để khớp với chiều cao và chiều rộng của số hàng và cột mong muốn trong khung OLE.
- Giữ kích thước khung OLE không đổi và thay đổi kích thước của các hàng và cột tham gia để vừa với kích thước khung OLE đã chọn.

### **Điều chỉnh kích thước khung OLE**

Trong cách tiếp cận này, chúng ta sẽ tìm hiểu cách đặt kích thước khung OLE của workbook Excel được nhúng sao cho khớp với kích thước tổng cộng của các hàng và cột tham gia trong worksheet Excel.

Giả sử chúng ta có một sheet Excel mẫu và muốn thêm nó vào bản trình chiếu dưới dạng khung OLE. Trong kịch bản này, kích thước của khung đối tượng OLE sẽ được tính toán đầu tiên dựa trên tổng chiều cao các hàng và chiều rộng các cột của các hàng và cột tham gia trong workbook. Sau đó, chúng ta sẽ đặt kích thước của khung OLE thành giá trị đã tính toán này. Để tránh thông báo màu đỏ "EMBEDDED OLE OBJECT" cho khung OLE trong PowerPoint, chúng ta cũng sẽ chụp một hình ảnh của các phần mong muốn của các hàng và cột trong workbook và đặt nó làm hình ảnh khung OLE.

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

    # Đặt kích thước hiển thị khi workbook được sử dụng làm đối tượng OLE trong PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # Lấy chiều rộng và chiều cao của hình ảnh OLE tính bằng điểm.
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # Sử dụng workbook đã được chỉnh sửa.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Thêm hình ảnh OLE vào tài nguyên của bản trình chiếu.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # Tạo khung đối tượng OLE.
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

### **Điều chỉnh kích thước phạm vi ô**

Trong cách tiếp cận này, chúng ta sẽ tìm hiểu cách thay đổi chiều cao của các hàng tham gia và chiều rộng của các cột tham gia sao cho khớp với kích thước khung OLE tùy chỉnh.

Giả sử chúng ta có một sheet Excel mẫu và muốn thêm nó vào bản trình chiếu dưới dạng khung OLE. Trong kịch bản này, chúng ta sẽ đặt kích thước của khung OLE và thay đổi kích thước của các hàng và cột tham gia vào vùng khung OLE. Sau đó, chúng ta sẽ lưu workbook vào một luồng để áp dụng các thay đổi và chuyển đổi nó thành mảng byte để thêm vào khung OLE. Để tránh thông báo màu đỏ "EMBEDDED OLE OBJECT" cho khung OLE trong PowerPoint, chúng ta cũng sẽ chụp một hình ảnh của các phần mong muốn của các hàng và cột trong workbook và đặt nó làm hình ảnh khung OLE.

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
    # Chiều rộng và chiều cao mong muốn của phạm vi ô được tính bằng điểm.
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

    # Đặt kích thước hiển thị khi workbook được sử dụng làm đối tượng OLE trong PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # Điều chỉnh kích thước phạm vi ô để vừa với kích thước khung.
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # Sử dụng workbook đã được chỉnh sửa.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Thêm hình ảnh OLE vào tài nguyên của bản trình chiếu.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # Tạo khung đối tượng OLE.
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

## **Kết luận**

{{% alert color="info" title="Note" %}} 

Có hai cách tiếp cận để khắc phục vấn đề thay đổi kích thước worksheet. Lựa chọn cách tiếp cận phù hợp phụ thuộc vào yêu cầu và trường hợp sử dụng cụ thể. Cả hai cách đều hoạt động tương tự, bất kể bản trình chiếu được tạo từ mẫu hay tạo mới. Ngoài ra, không có giới hạn về kích thước của khung OLE trong giải pháp này.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Tại sao một worksheet Excel được nhúng lại thay đổi kích thước khi lần đầu tiên được kích hoạt trong PowerPoint?**

Điều này xảy ra vì Excel cố gắng duy trì kích thước cửa sổ gốc khi được kích hoạt, trong khi khung OLE trong PowerPoint có kích thước riêng. PowerPoint và Excel sẽ thương lượng kích thước để duy trì tỷ lệ khung hình, dẫn đến việc thay đổi kích thước.

**Liệu có thể ngăn hoàn toàn vấn đề thay đổi kích thước này không?**

Có. Bằng cách điều chỉnh kích thước khung OLE để phù hợp với kích thước phạm vi ô Excel hoặc điều chỉnh phạm vi ô để phù hợp với kích thước khung OLE mong muốn, bạn có thể ngăn chặn việc thay đổi kích thước không mong muốn.

**Nên sử dụng phương pháp điều chỉnh nào, điều chỉnh khung OLE hay điều chỉnh phạm vi ô?**

Chọn **điều chỉnh khung OLE** nếu bạn muốn giữ nguyên kích thước hàng và cột gốc của Excel. Chọn **điều chỉnh phạm vi ô** nếu bạn muốn có kích thước cố định cho khung OLE trong bản trình chiếu của mình.

**Các giải pháp này có hoạt động nếu bản trình chiếu của tôi dựa trên một mẫu không?**

Có. Cả hai giải pháp đều hoạt động cho các bản trình chiếu được tạo từ mẫu và từ đầu.

**Có giới hạn nào về kích thước của khung OLE khi sử dụng các phương pháp này không?**

Không. Bạn có thể đặt khung OLE ở bất kỳ kích thước nào miễn là bạn thiết lập tỷ lệ phù hợp.

**Có cách nào để tránh văn bản placeholder "EMBEDDED OLE OBJECT" trong PowerPoint không?**

Có. Bằng cách chụp ảnh phạm vi ô Excel mục tiêu và đặt nó làm hình ảnh placeholder cho khung OLE, bạn có thể hiển thị một hình ảnh xem trước tùy chỉnh thay cho placeholder mặc định.

## **Bài viết liên quan**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/vi/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)