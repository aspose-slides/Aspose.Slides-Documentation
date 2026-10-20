---
title: Giải pháp thực tế cho việc thay đổi kích thước bảng tính
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
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Khắc phục việc thay đổi kích thước OLE của bảng tính Excel trong bản trình bày: hai cách để giữ khung đối tượng ổn định—phóng to khung hoặc bảng tính—trên các định dạng PPT và PPTX."
---
{{% alert color="info" title="Note" %}}
Trang tính Excel được nhúng dưới dạng đối tượng OLE trong bản trình bày PowerPoint sử dụng các thành phần Aspose có thể thay đổi kích thước một cách không mong muốn sau lần kích hoạt đầu tiên. Hành vi này tạo ra sự khác biệt về hình ảnh đáng chú ý giữa đối tượng OLE trước và sau khi kích hoạt. Bài viết này giải thích vấn đề và mô tả hai cách để khắc phục.
{{% /alert %}}

## **Bối cảnh**

Trong bài viết [Quản lý OLE](/slides/vi/python-java/manage-ole/), chúng tôi giải thích cách thêm khung OLE vào bản trình bày PowerPoint sử dụng Aspose.Slides cho Python qua Java. Để giải quyết [vấn đề xem trước đối tượng](/slides/vi/python-java/object-preview-issue-when-adding-oleobjectframe/), chúng tôi gán một hình ảnh của khu vực bảng tính được chọn cho khung đối tượng OLE. Trong bản trình bày đầu ra, khi bạn nhấp đúp vào khung đối tượng OLE hiển thị hình ảnh bảng tính, sổ làm việc Excel sẽ được kích hoạt. Người dùng cuối có thể thực hiện bất kỳ thay đổi nào mong muốn đối với sổ làm việc Excel thực tế và sau đó quay lại slide bằng cách nhấp ra ngoài sổ Excel đã kích hoạt. Kích thước của khung đối tượng OLE sẽ thay đổi khi người dùng quay lại slide. Hệ số thay đổi kích thước sẽ khác nhau tùy thuộc vào kích thước của khung OLE và sổ Excel được nhúng.

## **Nguyên nhân của việc thay đổi kích thước**

Vì sổ làm việc Excel có kích thước cửa sổ riêng, nó cố gắng giữ nguyên kích thước ban đầu khi được kích hoạt lần đầu. Ngược lại, khung đối tượng OLE cũng có kích thước riêng của nó. Theo Microsoft, khi sổ Excel được kích hoạt, Excel và PowerPoint sẽ thương lượng kích thước để đảm bảo duy trì tỉ lệ chính xác như một phần của quá trình nhúng. Việc thay đổi kích thước xảy ra dựa trên sự khác biệt giữa kích thước cửa sổ Excel và kích thước và vị trí của khung đối tượng OLE.

## **Giải pháp thực hiện**

Có hai giải pháp khả thi để tránh hiệu ứng thay đổi kích thước.

- Điều chỉnh kích thước khung OLE trong bản trình bày PowerPoint sao cho khớp với tổng chiều cao và chiều rộng của các hàng và cột đã chọn.
- Giữ cố định kích thước khung OLE và thay đổi kích thước các hàng và cột đã chọn để vừa khớp bên trong.

### **Điều chỉnh kích thước khung OLE**

Cách tiếp cận này thiết lập kích thước khung OLE sao cho khớp với tổng chiều cao và chiều rộng của các hàng và cột đã chọn trong bảng tính Excel được nhúng.

Ví dụ tải một sổ Excel hiện có và chọn 10 hàng đầu tiên và 13 cột đầu tiên của trang tính đầu tiên bằng chỉ số bắt đầu từ 0. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) xác định phạm vi hiển thị. Bản xem trước được tạo ở độ phân giải 96 DPI, và kích thước pixel của nó được chuyển đổi sang điểm bằng cách sử dụng 72 điểm mỗi inch. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) nhúng sổ đã chỉnh sửa vào một khung với các kích thước đó. Bản xem trước được gán thông qua [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) để thay thế ký placeholder "EMBEDDED OLE OBJECT" trong bản trình bày đã lưu.

Bộ trợ giúp xem trước đặt [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) thành phạm vi đã chọn và loại bỏ lề, tiêu đề và chân trang. Khi [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/python-java/asposecells.api/imageorprintoptions/#onlyarea) được bật, [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) tạo hình ảnh PNG cho phạm vi. Bộ trợ giúp trả về một luồng đầu vào mới chứa hình ảnh PNG, được đặt ở vị trí bắt đầu để sử dụng trong bản trình bày.

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

    # Đặt kích thước hiển thị khi sổ làm việc được sử dụng làm đối tượng OLE trong PowerPoint.
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

        # Sử dụng sổ làm việc đã được chỉnh sửa.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Thêm hình ảnh OLE vào tài nguyên của bản trình bày.
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

Cách tiếp cận này điều chỉnh chiều cao của các hàng đã chọn và chiều rộng của các cột đã chọn để khớp với kích thước khung OLE tùy chỉnh.

Ví dụ tải một sổ Excel hiện có và chọn 10 hàng đầu tiên và 13 cột đầu tiên của trang tính đầu tiên bằng chỉ số bắt đầu từ 0. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) xác định phạm vi hiển thị, và bộ trợ giúp scale_cell_range điều chỉnh phạm vi đó để phù hợp với khung có chiều rộng 400 điểm và chiều cao 100 điểm. Sau khi lưu sổ đã chỉnh sửa vào một luồng, [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) nhúng nó với kích thước đã chỉ định. Một bản xem trước được tạo ở độ phân giải 96 DPI được gán thông qua [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), vì vậy bản trình bày đã lưu hiển thị các ô đã chọn thay vì placeholder mặc định.

Bộ trợ giúp điều chỉnh tính toán các tỉ lệ chiều rộng và chiều cao riêng biệt cho phạm vi đã chọn, bảo lưu độ rộng tương đối của các cột và độ cao tương đối của các hàng. Nó chuyển đổi các kích thước tính toán từ điểm sang inch trước khi áp dụng chúng bằng [Cells.setColumnWidthInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setcolumnwidthinch) và [Cells.setRowHeightInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setrowheightinch). Phạm vi đã chọn phải có chiều rộng và chiều cao khác không.

Bộ trợ giúp xem trước này tạo ra phạm vi đã thay đổi kích thước bằng cách sử dụng [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage). Nó giới hạn [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) cho phạm vi đó, loại bỏ lề, tiêu đề và chân trang, và trả về một luồng PNG được đặt ở vị trí bắt đầu.

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
    # Chiều rộng và chiều cao dự kiến của phạm vi ô được tính bằng điểm.
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

    # Đặt kích thước hiển thị khi sổ làm việc được sử dụng làm đối tượng OLE trong PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # Điều chỉnh kích thước phạm vi ô để vừa với kích thước khung.
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # Sử dụng sổ làm việc đã được chỉnh sửa.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Thêm hình ảnh OLE vào tài nguyên của bản trình bày.
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
Có hai cách tiếp cận để khắc phục vấn đề thay đổi kích thước của bảng tính. Hãy chọn cách tiếp cận phù hợp nhất với yêu cầu và trường hợp sử dụng của bạn. Cả hai cách đều hoạt động tương tự, bất kể bản trình bày được tạo từ mẫu hay từ đầu. Ngoài ra, không có giới hạn nào về kích thước khung đối tượng OLE trong giải pháp này.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Tại sao một bảng tính Excel được nhúng lại thay đổi kích thước khi lần đầu được kích hoạt trong PowerPoint?**  
Điều này xảy ra vì Excel cố gắng giữ nguyên kích thước cửa sổ ban đầu khi được kích hoạt, trong khi khung OLE trong PowerPoint có kích thước riêng. PowerPoint và Excel thương lượng kích thước để duy trì tỷ lệ khung hình, điều này có thể gây ra việc thay đổi kích thước.

**Có thể ngăn ngừa hoàn toàn vấn đề thay đổi kích thước này không?**  
Có. Bằng cách điều chỉnh kích thước khung OLE để phù hợp với kích thước phạm vi ô Excel hoặc điều chỉnh phạm vi ô để phù hợp với kích thước khung OLE mong muốn, bạn có thể ngăn ngừa việc thay đổi kích thước không mong muốn.

**Tôi nên sử dụng phương pháp điều chỉnh nào, điều chỉnh khung OLE hay điều chỉnh phạm vi ô?**  
Chọn **điều chỉnh khung OLE** nếu bạn muốn duy trì kích thước hàng và cột gốc của Excel. Chọn **điều chỉnh phạm vi ô** nếu bạn muốn có kích thước cố định cho khung OLE trong bản trình bày.

**Các giải pháp này có hoạt động nếu bản trình bày của tôi dựa trên mẫu không?**  
Có. Cả hai giải pháp đều hoạt động cho các bản trình bày được tạo từ mẫu và từ đầu.

**Có giới hạn nào về kích thước khung OLE khi sử dụng các phương pháp này không?**  
Không. Bạn có thể đặt khung đối tượng OLE với bất kỳ kích thước nào miễn là bạn điều chỉnh tỉ lệ một cách thích hợp.

**Có cách nào để tránh văn bản placeholder "EMBEDDED OLE OBJECT" trong PowerPoint không?**  
Có. Bằng cách chụp ảnh nhanh phạm vi ô Excel mục tiêu và đặt nó làm hình ảnh placeholder cho khung OLE, bạn có thể hiển thị một hình ảnh xem trước tùy chỉnh thay cho placeholder mặc định.

## **Bài viết liên quan**

[Tạo biểu đồ Excel và nhúng nó vào bản trình bày dưới dạng đối tượng OLE](/slides/vi/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Cập nhật tự động các đối tượng OLE bằng Add-In MS PowerPoint](/slides/vi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)