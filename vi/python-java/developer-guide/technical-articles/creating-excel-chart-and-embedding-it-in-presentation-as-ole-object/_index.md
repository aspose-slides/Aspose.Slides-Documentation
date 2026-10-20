---
title: Tạo biểu đồ Excel và nhúng chúng vào bản trình chiếu dưới dạng đối tượng OLE
type: docs
weight: 30
url: /vi/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Biểu đồ Excel
- Nhúng biểu đồ
- Đối tượng OLE
- PowerPoint
- Bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tạo một biểu đồ Excel bằng Aspose.Cells cho Python qua Java và nhúng sổ làm việc vào bản trình chiếu PowerPoint với Aspose.Slides, bao gồm một bản xem trước biểu đồ."
---
## **Tổng quan**

Bài viết này hướng dẫn cách tạo biểu đồ cột Excel bằng Aspose.Cells cho Python qua Java và nhúng sổ làm việc của nó vào bản trình chiếu PowerPoint bằng Aspose.Slides cho Python qua Java. Sổ làm việc đã nhúng chứa cả dữ liệu nguồn và biểu đồ. Một bản xem trước PNG riêng biệt hiển thị biểu đồ trên slide trước khi đối tượng OLE được kích hoạt.

Kết quả là một đối tượng Excel được nhúng, không phải biểu đồ PowerPoint gốc. Việc chỉnh sửa sổ làm việc qua OLE yêu cầu một ứng dụng máy tính để bàn hỗ trợ kích hoạt OLE và cài đặt Excel tương thích.

## **Yêu cầu**

Cài đặt các gói Python `aspose-cells` và `aspose-slides-java` cùng môi trường chạy Java tương thích. Nhập cả hai gói trước khi khởi động JVM để các thư viện Java của chúng có sẵn cho JPype. Microsoft Office không bắt buộc để tạo bản trình chiếu với các thư viện này.

Không cần tệp đầu vào: ví dụ tạo dữ liệu và biểu đồ trong bộ nhớ, sau đó ghi `OutputChart.pptx` vào thư mục làm việc hiện tại. Áp dụng giấy phép cho cả hai sản phẩm khi chạy ngoài chế độ đánh giá.

## **Cách hoạt động của việc nhúng**

1. Tạo một sổ làm việc với một bảng dữ liệu và một bảng biểu đồ.  
2. Đặt bảng biểu đồ làm bảng hoạt động để sổ làm việc mở ở biểu đồ.  
3. Đặt phạm vi hiển thị OLE của sổ làm việc và chuyển đổi biểu đồ sang PNG.  
4. Lưu sổ làm việc dưới dạng XLSX trong bộ nhớ và nhúng các byte đó vào một slide.  
5. Gán PNG làm bản xem trước của đối tượng OLE và lưu bản trình chiếu dưới dạng PPTX.

Phạm vi hiển thị của sổ làm việc và khung trên slide có các vai trò khác nhau. [setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) nhận các chỉ số hàng và cột bắt đầu/kết thúc dựa trên chỉ số zero-based. [ChartCollection.add](https://reference.aspose.com/cells/python-java/asposecells.api/chartcollection/#add) thay vào đó nhận hàng trên cùng, cột trái, hàng dưới cùng và cột phải. Ví dụ sử dụng chỉ số hàng 55 và chỉ số cột 25 làm giới hạn góc dưới bên phải; các giá trị này là lựa chọn bố cục, không phải số lượng hàng hoặc cột dữ liệu.

Khung slide sử dụng đơn vị điểm. Ví dụ điều chỉnh nó vào trong slide và căn giữa trong khi giữ tỷ lệ khung hình của PNG, thay vì kéo dài bản xem trước để lấp đầy slide.

## **Tạo và Nhúng Biểu Đồ**

Ví dụ hoàn chỉnh dưới đây điền `DataSheet` với bốn hàng và năm cột giá trị. Mỗi hàng trở thành một chuỗi biểu đồ. `ChartSheet` được chọn làm bảng hoạt động trước khi sổ làm việc được lưu.

Sổ làm việc được lưu một cách rõ ràng dưới dạng XLSX, phù hợp với phần mở rộng `xlsx` được truyền cho [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/). Các luồng mảng byte Java giữ sổ làm việc và hình ảnh trong bộ nhớ và cung cấp các mảng byte cần thiết cho các API Java. PNG được tải trực tiếp từ các byte mà không qua chuyển đổi bitmap trung gian. Gán nó thông qua [getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) thay thế placeholder OLE mặc định.

```python
import jpate
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Images, OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("DataSheet")

    values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25],
    ]
    for row, row_values in enumerate(values):
        for column, value in enumerate(row_values):
            data_sheet.getCells().get(row, column).putValue(jpype.JInt(value))

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_sheet.setName("ChartSheet")

    last_chart_row = 55
    last_chart_column = 25
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
    chart = chart_sheet.getCharts().get(chart_index)
    for row in range(1, len(values) + 1):
        chart.getNSeries().add(f"DataSheet!A{row}:E{row}", False)

    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    workbook.getWorksheets().setOleSize(0, last_chart_row, 0, last_chart_column)

    # Kết xuất bản xem trước biểu đồ và tuần tự hóa sổ làm việc có thể chỉnh sửa riêng biệt.
    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    chart_image_stream = ByteArrayOutputStream()
    chart.toImage(chart_image_stream, image_options)
    chart_image_bytes = chart_image_stream.toByteArray()

    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.XLSX)
    workbook_bytes = workbook_stream.toByteArray()

    chart_image = Images.fromData(chart_image_bytes)
    try:
        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)
            slide_width = presentation.getSlideSize().getSize().getWidth()
            slide_height = presentation.getSlideSize().getSize().getHeight()

            # Đưa bản xem trước vào trong slide mà không thay đổi tỷ lệ khung hình.
            scale = min(slide_width / chart_image.getWidth(), slide_height / chart_image.getHeight())
            frame_width = chart_image.getWidth() * scale
            frame_height = chart_image.getHeight() * scale
            frame_x = (slide_width - frame_width) / 2
            frame_y = (slide_height - frame_height) / 2

            embedded_data = OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.getImages().addImage(chart_image)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(preview_image)

            presentation.save("OutputChart.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        chart_image.dispose()
finally:
    workbook.dispose()
```

## **Kết Quả Mong Đợi**

`OutputChart.pptx` chứa một slide với một sổ làm việc Excel được nhúng và một bản xem trước biểu đồ. Sổ làm việc chứa dữ liệu gốc và một biểu đồ cột với bốn chuỗi. Bản xem trước được căn giữa trên slide và giữ tỷ lệ của nó.

![Biểu đồ cột Excel hiển thị như bản xem trước của sổ làm việc đã nhúng](excel-chart-ole-preview.png)

Trong môi trường PowerPoint máy tính để bàn tương thích có Excel sẵn có, nhấp đúp vào đối tượng để kích hoạt và chỉnh sửa sổ làm việc đã nhúng. Việc kích hoạt và chỉnh sửa phụ thuộc vào hỗ trợ OLE và cài đặt bảo mật của ứng dụng chủ.

## **FAQ**

**Tại sao cần hình ảnh xem trước?**

Sổ làm việc đã nhúng và bản xem trước slide của nó là nội dung riêng biệt. Cung cấp một hình ảnh biểu đồ để slide hiển thị biểu đồ thay vì placeholder mặc định "EMBEDDED OLE OBJECT". Xem [Vấn đề Xem trước Đối tượng khi Thêm OleObjectFrame](/slides/vi/python-java/object-preview-issue-when-adding-oleobjectframe/).

**Bản xem trước có được cập nhật tự động khi tôi thay đổi sổ làm việc trong mã không?**

Xem bản xem trước như một ảnh chụp. Khi cập nhật dữ liệu sổ làm việc bằng chương trình, hãy tạo lại hình ảnh biểu đồ và thay thế bản xem trước cũng như dữ liệu sổ làm việc đã nhúng.

**Tôi có thể dùng XLS thay vì XLSX không?**

Có. Lưu sổ làm việc ở định dạng XLS và sử dụng `xls` làm phần mở rộng dữ liệu nhúng. Phần mở rộng phải khớp với định dạng thực tế của sổ làm việc; chỉ thay đổi phần mở rộng không chuyển đổi dữ liệu.

**Tại sao đối tượng có thể thay đổi kích thước sau khi kích hoạt?**

Ứng dụng chủ có thể cập nhật cách trình bày của đối tượng OLE khi nó kích hoạt sổ làm việc. Cả phạm vi hiển thị OLE của sổ làm việc và kích thước khung slide đều quan trọng. Xem [Giải pháp hoạt động cho việc thay đổi kích thước biểu đồ trong PPTX](/slides/vi/python-java/working-solution-for-chart-resizing-in-pptx/).

## **Các Phần Liên Quan**

- [Giải pháp hoạt động cho việc thay đổi kích thước biểu đồ trong PPTX](/slides/vi/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Vấn đề Xem trước Đối tượng khi Thêm OleObjectFrame](/slides/vi/python-java/object-preview-issue-when-adding-oleobjectframe/)