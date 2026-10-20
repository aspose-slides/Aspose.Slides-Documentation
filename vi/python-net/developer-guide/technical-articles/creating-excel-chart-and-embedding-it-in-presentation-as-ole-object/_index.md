---
title: Tạo biểu đồ Excel và nhúng chúng vào bản trình bày dưới dạng đối tượng OLE
type: docs
weight: 50
url: /vi/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- biểu đồ Excel
- nhúng biểu đồ
- đối tượng OLE
- PowerPoint
- bản trình bày
- Python
- Python qua .NET
- Aspose.Slides
description: "Tạo một biểu đồ Excel với Aspose.Cells cho Python qua .NET và nhúng sổ làm việc vào bản trình bày PowerPoint bằng Aspose.Slides, bao gồm cả bản xem trước biểu đồ."
---
## **Tổng quan**

Bài viết này trình bày cách tạo biểu đồ cột Excel bằng Aspose.Cells cho Python qua .NET và nhúng sổ làm việc của nó vào một bài thuyết trình PowerPoint bằng Aspose.Slides cho Python qua .NET. Sổ làm việc được nhúng chứa cả dữ liệu nguồn và biểu đồ. Một bản xem trước PNG riêng biệt hiển thị biểu đồ trên slide trước khi đối tượng OLE được kích hoạt.

Kết quả là một đối tượng Excel được nhúng, không phải biểu đồ PowerPoint gốc. Chỉnh sửa sổ làm việc thông qua OLE yêu cầu một ứng dụng desktop hỗ trợ kích hoạt OLE và một cài đặt Excel tương thích.

## **Yêu cầu trước**

Cài đặt các gói `aspose-cells-python` và `aspose-slides` trong môi trường Python của bạn. Microsoft Office không bắt buộc để tạo bài thuyết trình bằng các thư viện này.

Không cần tệp đầu vào: ví dụ tạo dữ liệu và biểu đồ trong bộ nhớ, sau đó ghi `OutputChart.pptx` vào thư mục làm việc hiện tại. Áp dụng giấy phép cho cả hai sản phẩm khi chạy ngoài chế độ đánh giá.

## **Cách hoạt động của việc nhúng**

1. Tạo một sổ làm việc với một worksheet dữ liệu và một sheet biểu đồ.
1. Đặt sheet biểu đồ làm active để sổ làm việc mở trên biểu đồ.
1. Đặt phạm vi hiển thị OLE của sổ làm việc và render biểu đồ thành PNG.
1. Lưu sổ làm việc dưới dạng XLSX trong bộ nhớ và nhúng các byte đó vào một slide.
1. Gán PNG làm bản xem trước của đối tượng OLE và lưu bài thuyết trình dưới dạng PPTX.

Phạm vi hiển thị của sổ làm việc và khung trên slide có các vai trò khác nhau. [set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) lấy các chỉ số dòng và cột bắt đầu/kết thúc bắt đầu từ 0. [ChartCollection.add](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chartcollection/add/) thay vào đó lấy dòng trên, cột trái, dòng dưới và cột phải. Ví dụ sử dụng chỉ số dòng 55 và chỉ số cột 25 làm ranh giới dưới‑phải; các giá trị này là lựa chọn bố cục, không phải số lượng dòng hoặc cột dữ liệu.

Khung slide sử dụng đơn vị điểm. Ví dụ vừa khít nó trong slide và căn giữa trong khi giữ tỷ lệ khung hình của PNG, thay vì kéo dài bản xem trước để lấp đầy slide.

## **Tạo và Nhúng Biểu đồ**

Ví dụ hoàn chỉnh dưới đây điền `DataSheet` với bốn dòng và năm cột giá trị. Mỗi dòng trở thành một series biểu đồ. `ChartSheet` được chọn làm sheet hoạt động trước khi sổ làm việc được lưu.

Sổ làm việc được lưu một cách rõ ràng dưới dạng XLSX, khớp với phần mở rộng `xlsx` được truyền cho [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/). PNG được tải trực tiếp từ luồng của nó mà không qua chuyển đổi bitmap trung gian. Gán nó thông qua [substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/ioleobjectframe/substitute_picture_format/) thay thế cho placeholder OLE mặc định.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.cells.drawing as drawing
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "DataSheet"

values = [
    [67, 44, 46, 43, 24],
    [86, 64, 97, 29, 40],
    [68, 89, 78, 69, 38],
    [91, 48, 60, 26, 25],
]

for row, row_values in enumerate(values):
    for column, value in enumerate(row_values):
        data_sheet.cells.get(row, column).put_value(value)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_sheet.name = "ChartSheet"

last_chart_row = 55
last_chart_column = 25
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
chart = chart_sheet.charts[chart_index]
for row in range(1, len(values) + 1):
    chart.n_series.add(f"DataSheet!A{row}:E{row}", False)

workbook.worksheets.active_sheet_index = chart_sheet_index
workbook.worksheets.set_ole_size(0, last_chart_row, 0, last_chart_column)

    # Render bản xem trước biểu đồ và tuần tự hoá sổ làm việc có thể chỉnh sửa riêng biệt.
    with io.BytesIO() as chart_image_stream, io.BytesIO() as workbook_stream:
        chart.to_image(chart_image_stream, drawing.ImageType.PNG)
        chart_image_stream.seek(0)
        workbook.save(workbook_stream, cells.SaveFormat.XLSX)
        workbook_bytes = workbook_stream.getvalue()

        with slides.Images.from_stream(chart_image_stream) as chart_image:
            with slides.Presentation() as presentation:
                slide = presentation.slides[0]
                slide_size = presentation.slide_size.size

                # Điều chỉnh bản xem trước cho vừa trong slide mà không thay đổi tỷ lệ khung hình.
                scale = min(slide_size.width / chart_image.width, slide_size.height / chart_image.height)
                frame_width = chart_image.width * scale
                frame_height = chart_image.height * scale
                frame_x = (slide_size.width - frame_width) / 2
                frame_y = (slide_size.height - frame_height) / 2

                embedded_data = slides.dom.ole.OleEmbeddedDataInfo(workbook_bytes, "xlsx")
                ole_frame = slide.shapes.add_ole_object_frame(frame_x, frame_y, frame_width, frame_height, embedded_data)
                preview_image = presentation.images.add_image(chart_image)
                ole_frame.substitute_picture_format.picture.image = preview_image

                presentation.save("OutputChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Kết quả mong đợi**

`OutputChart.pptx` chứa một slide với một sổ làm việc Excel được nhúng và một bản xem trước biểu đồ. Sổ làm việc chứa dữ liệu gốc và một biểu đồ cột với bốn series. Bản xem trước được căn giữa trên slide và giữ nguyên tỉ lệ của nó.

![Biểu đồ cột Excel hiển thị dưới dạng bản xem trước của sổ làm việc được nhúng](excel-chart-ole-preview.png)

Trong môi trường PowerPoint desktop tương thích có Excel sẵn có, nhấp đúp vào đối tượng để kích hoạt và chỉnh sửa sổ làm việc được nhúng. Việc kích hoạt và chỉnh sửa phụ thuộc vào hỗ trợ OLE và cài đặt bảo mật của ứng dụng host.

## **Câu hỏi thường gặp**

**Tại sao cần có hình ảnh xem trước?**

Sổ làm việc được nhúng và bản xem trước trên slide là nội dung riêng biệt. Cung cấp một hình ảnh biểu đồ để slide hiển thị biểu đồ thay vì placeholder mặc định "EMBEDDED OLE OBJECT". Xem [Vấn đề Xem trước Đối tượng khi Thêm OleObjectFrame](/slides/vi/python-net/object-preview-issue-when-adding-oleobjectframe/).

**Bản xem trước có cập nhật tự động khi tôi thay đổi sổ làm việc trong mã không?**

Xem bản xem trước như một ảnh chụp nhanh. Khi cập nhật dữ liệu sổ làm việc bằng mã, tạo lại hình ảnh biểu đồ và thay thế bản xem trước cũng như dữ liệu sổ làm việc được nhúng.

**Tôi có thể sử dụng XLS thay cho XLSX không?**

Có. Lưu sổ làm việc ở định dạng XLS và sử dụng `xls` làm phần mở rộng dữ liệu được nhúng. Phần mở rộng phải khớp với định dạng sổ làm việc thực tế; chỉ thay đổi phần mở rộng mà không chuyển đổi dữ liệu sẽ không hiệu quả.

**Tại sao đối tượng có thể thay đổi kích thước sau khi kích hoạt?**

Ứng dụng host có thể cập nhật cách trình bày của đối tượng OLE khi nó kích hoạt sổ làm việc. Cả phạm vi hiển thị OLE của sổ làm việc và kích thước khung slide đều quan trọng. Xem [Tự động thay đổi kích thước đối tượng OLE trong bài thuyết trình PowerPoint](/slides/vi/python-net/working-solution-for-worksheet-resizing/).

## **Các phần liên quan**

- [Tự động thay đổi kích thước đối tượng OLE trong bài thuyết trình PowerPoint](/slides/vi/python-net/working-solution-for-worksheet-resizing/)
- [Vấn đề Xem trước Đối tượng khi Thêm OleObjectFrame](/slides/vi/python-net/object-preview-issue-when-adding-oleobjectframe/)
- [Quản lý Đối tượng OLE](/slides/vi/python-net/manage-ole/)