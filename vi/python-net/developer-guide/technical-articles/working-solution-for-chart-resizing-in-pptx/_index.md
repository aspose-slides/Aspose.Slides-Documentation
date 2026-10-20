---
title: Giải pháp hoạt động cho việc thay đổi kích thước biểu đồ trong PPTX
type: docs
weight: 60
url: /vi/python-net/working-solution-for-chart-resizing-in-pptx/
keywords:
- thay đổi kích thước biểu đồ
- biểu đồ Excel
- đối tượng OLE
- nhúng biểu đồ
- PowerPoint
- bản trình chiếu
- Python qua .NET
- Python
- Aspose.Slides
description: "Khắc phục việc thay đổi kích thước biểu đồ không mong muốn trong PPTX khi sử dụng các đối tượng OLE Excel nhúng với Aspose.Slides cho Python qua .NET. Đặt kích thước biểu đồ cố định để duy trì kích thước nhất quán giữa biểu đồ và khung OLE."
---
## **Tổng quan**

Biểu đồ Excel được nhúng dưới dạng đối tượng OLE trong bản trình chiếu PowerPoint bằng các thành phần Aspose có thể thay đổi kích thước sau lần kích hoạt đầu tiên. Điều này có thể gây ra sự khác biệt đáng chú ý trong cách hiển thị của biểu đồ trước và sau khi kích hoạt. Bài viết này giải thích nguyên nhân gây ra việc thay đổi kích thước và chỉ ra cách ngăn chặn bằng cách khớp kích thước biểu đồ cố định với khung OLE.

Trong [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/vi/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), chúng tôi đã giải thích cách tạo biểu đồ Excel bằng Aspose.Cells cho Python thông qua .NET và nhúng nó vào bản trình chiếu PowerPoint bằng Aspose.Slides cho Python thông qua .NET. Để giải quyết [object preview issue](/slides/vi/python-net/object-preview-issue-when-adding-oleobjectframe/), chúng tôi đã gán ảnh biểu đồ cho khung đối tượng OLE của biểu đồ. Trong bản trình chiếu đầu ra, khi bạn nhấp đúp vào khung đối tượng OLE hiển thị ảnh biểu đồ, biểu đồ Excel sẽ được kích hoạt. Người dùng có thể chỉnh sửa sách tính Excel đã nhúng và sau đó quay lại slide bằng cách nhấp ra ngoài sách tính đã kích hoạt. Kích thước của khung đối tượng OLE thay đổi khi người dùng quay lại slide, và hệ số thay đổi kích thước phụ thuộc vào kích thước gốc của cả khung OLE và sách tính Excel đã nhúng.

## **Nguyên nhân gây ra việc thay đổi kích thước**

Sổ làm việc Excel được nhúng có kích thước cửa sổ riêng, mà Excel cố gắng giữ lại khi đối tượng được kích hoạt lần đầu. Khung OLE trên slide có kích thước được định nghĩa độc lập. Khi sổ làm việc Excel được kích hoạt, Excel và PowerPoint sẽ thương lượng kích thước của đối tượng để duy trì tỉ lệ như một phần của quá trình nhúng. Sự khác biệt giữa cửa sổ sổ làm việc và khung OLE do đó có thể gây ra việc thay đổi kích thước của đối tượng.

## **Giải pháp hoạt động**

Khớp kích thước biểu đồ với khung OLE trên slide và giữ các kích thước biểu đồ độc lập với cửa sổ sổ làm việc. Giải pháp này hoạt động với bản trình chiếu mới hoặc với mẫu hiện có.

Ví dụ yêu cầu Aspose.Cells cho Python thông qua .NET và Aspose.Slides cho Python thông qua .NET. Nó tạo một biểu đồ cột đơn giản trên một sheet biểu đồ hoạt động và nhúng sổ làm việc ở định dạng XLS. Không gán ảnh xem trước cho biểu đồ; biểu đồ sẽ hiển thị khi đối tượng OLE được kích hoạt trong PowerPoint.

Ví dụ tạo một bản trình chiếu mới với khung OLE kích thước 9.5 × 4‑inch được đặt cách mép trái 0.5 inch và cách mép trên 1 inch. Tọa độ và kích thước slide được tính bằng điểm (72 điểm mỗi inch). Đối với bản trình chiếu hiện có, xem [Use a Template](#use-a-template).

## **Đặt kích thước biểu đồ cố định**

Đặt [size_with_window](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/size_with_window/) thành false để kích thước biểu đồ không phụ thuộc vào cửa sổ sổ làm việc. Đặt kích thước của [chart_object](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/chart_object/) thông qua [width](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/width/) và [height](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/height/), chuyển đổi điểm sang pixel bằng cách sử dụng 96 pixel mỗi inch: khung có kích thước 684 × 288 điểm tương ứng với biểu đồ có kích thước 912 × 384 pixel. Đặt [print_size](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/print_size/) thành giá trị CUSTOM của [PrintSizeType](https://reference.aspose.com/cells/python-net/aspose.cells/printsizetype/). Ví dụ nhúng sổ làm việc bằng [add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/add_ole_object_frame/) và lưu bản trình chiếu với khung OLE 9.5 × 4‑inch.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "Data"
data_sheet.cells.get("A1").put_value(10)
data_sheet.cells.get("A2").put_value(20)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, 20, 10)
chart = chart_sheet.charts[chart_index]
chart.n_series.add("Data!A1:A2", True)
workbook.worksheets.active_sheet_index = chart_sheet_index

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Tọa độ và kích thước slide được tính bằng điểm (72 điểm mỗi inch).
    width = 684.0  # 9,5 inch.
    height = 288.0  # 4 inch.

    chart.size_with_window = False
    # Chuyển đổi điểm sang pixel biểu đồ bằng cách sử dụng 96 pixel mỗi inch.
    chart.chart_object.width = int(width / 72 * 96)
    chart.chart_object.height = int(height / 72 * 96)
    chart.print_size = cells.PrintSizeType.CUSTOM

    with io.BytesIO() as workbook_stream:
        workbook.save(workbook_stream, cells.SaveFormat.EXCEL_97_TO_2003)
        data_info = slides.dom.ole.OleEmbeddedDataInfo(workbook_stream.getvalue(), "xls")
        slide.shapes.add_ole_object_frame(36, 72, width, height, data_info)

    presentation.save("chart-fixed-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Sử dụng mẫu**

Logic tính kích thước giống nhau cho bản trình chiếu hiện có. Để điều chỉnh ví dụ:

1. Tải bản trình chiếu mẫu thay vì tạo một bản trống.
2. Kiểm tra slide đầu tiên có ít nhất ba shape, sau đó dùng shape tại chỉ mục 2 làm placeholder.
3. Lấy chiều rộng và chiều cao khung từ shape đó thay vì dùng các giá trị cố định 684 và 288. Giữ nguyên các phép tính kích thước.
4. Thêm khung OLE tại vị trí của placeholder thay vì các tọa độ cố định 36 và 72.
5. Xóa placeholder trước khi lưu bản trình chiếu.

## **Câu hỏi thường gặp**

**Tại sao biểu đồ Excel được nhúng của tôi lại thay đổi kích thước sau khi kích hoạt trong PowerPoint?**

Điều này xảy ra vì Excel cố gắng khôi phục kích thước cửa sổ gốc khi lần đầu tiên được kích hoạt, trong khi khung đối tượng OLE trong PowerPoint có kích thước riêng. PowerPoint và Excel thương lượng kích thước để duy trì tỉ lệ, dẫn đến việc thay đổi kích thước.

**Làm sao tôi có thể giữ kích thước biểu đồ và khung OLE nhất quán?**

Đặt kích thước biểu đồ cố định khớp với khung OLE và sử dụng kích thước in biểu đồ tùy chỉnh trước khi nhúng sổ làm việc. Ví dụ trên cho thấy các thiết lập cần thiết và cách chuyển đổi đơn vị.

**Việc khớp kích thước cửa sổ sổ làm việc có đủ không?**

Chỉ khớp kích thước cửa sổ sổ làm việc không đảm bảo ngăn khung OLE thay đổi kích thước sau khi kích hoạt. Cần sử dụng kích thước biểu đồ cố định như trong ví dụ.

**Giải pháp này có hoạt động với cả bản trình chiếu dựa trên mẫu và bản trình chiếu mới không?**

Có. Đối với mẫu, sử dụng kích thước và vị trí của placeholder. Đối với bản trình chiếu mới, chỉ định trực tiếp kích thước và vị trí khung.

**Tôi có thể sử dụng ví dụ này với các biểu đồ được tạo bằng các chương trình bảng tính khác không?**

Ví dụ sử dụng sổ làm việc Excel được tạo bằng Aspose.Cells. Nó không minh họa hành vi kích hoạt cho các chương trình bảng tính khác.

## **Các mục liên quan**

- [Tạo biểu đồ Excel và nhúng chúng dưới dạng đối tượng OLE trong bản trình chiếu](/slides/vi/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Cập nhật các đối tượng OLE tự động bằng Add-In PowerPoint](/slides/vi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)