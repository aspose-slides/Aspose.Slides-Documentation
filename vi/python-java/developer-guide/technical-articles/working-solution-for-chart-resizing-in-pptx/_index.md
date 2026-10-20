---
title: Giải pháp hoạt động cho việc thay đổi kích thước biểu đồ trong PPTX
type: docs
weight: 40
url: /vi/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- thay đổi kích thước biểu đồ
- biểu đồ Excel
- đối tượng OLE
- nhúng biểu đồ
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Sửa lỗi thay đổi kích thước biểu đồ không mong muốn trong PPTX khi sử dụng các đối tượng Excel OLE được nhúng với Aspose.Slides cho Python qua Java. Đặt kích thước biểu đồ cố định để duy trì kích thước nhất quán cho biểu đồ và khung OLE."
---
## **Bối cảnh**

Biểu đồ Excel được nhúng dưới dạng đối tượng OLE trong bản trình chiếu PowerPoint bằng các thành phần Aspose có thể thay đổi kích thước sau lần kích hoạt đầu tiên. Điều này có thể gây ra sự khác biệt đáng chú ý về giao diện của biểu đồ trước và sau khi kích hoạt. Bài viết này giải thích lý do xảy ra việc thay đổi kích thước và chỉ ra cách ngăn ngừa bằng cách điều chỉnh kích thước biểu đồ cố định cho khung OLE.

Trong [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/vi/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), chúng tôi đã giải thích cách tạo biểu đồ Excel với Aspose.Cells for Python via Java và nhúng nó vào bản trình chiếu PowerPoint bằng Aspose.Slides for Python via Java. Để giải quyết [object preview issue](/slides/vi/python-java/object-preview-issue-when-adding-oleobjectframe/), chúng tôi đã gán hình ảnh biểu đồ cho khung đối tượng OLE của biểu đồ. Trong bản trình chiếu đầu ra, khi bạn nhấp đúp vào khung đối tượng OLE hiển thị hình ảnh biểu đồ, biểu đồ Excel sẽ được kích hoạt. Người dùng có thể chỉnh sửa sổ Excel được nhúng và sau đó quay lại slide bằng cách nhấp ra ngoài sổ đã kích hoạt. Kích thước của khung đối tượng OLE thay đổi khi người dùng quay lại slide, và hệ số thay đổi kích thước khác nhau tùy thuộc vào kích thước gốc của cả khung OLE và sổ Excel được nhúng.

## **Nguyên nhân của việc thay đổi kích thước**

Workbook được nhúng có kích thước cửa sổ riêng, mà Excel cố gắng giữ lại khi đối tượng được kích hoạt lần đầu. Khung OLE trên slide có kích thước được xác định độc lập. Khi sổ Excel được kích hoạt, Excel và PowerPoint sẽ thương lượng kích thước của đối tượng để duy trì tỉ lệ như một phần của quá trình nhúng. Sự chênh lệch giữa cửa sổ sổ làm việc và khung OLE do đó có thể gây ra việc thay đổi kích thước của đối tượng.

## **Giải pháp hoạt động**

Điều chỉnh kích thước biểu đồ cho phù hợp với khung OLE trên slide và giữ cho kích thước biểu đồ độc lập với cửa sổ sổ làm việc. Giải pháp này hoạt động với bản trình chiếu mới hoặc mẫu hiện có.

Ví dụ yêu cầu Aspose.Cells for Python via Java và Aspose.Slides for Python via Java. Nó tạo một biểu đồ cột đơn giản trên một sheet biểu đồ đang hoạt động và nhúng sổ làm việc dưới dạng XLS. Không có hình ảnh xem trước cho biểu đồ được gán; biểu đồ sẽ hiển thị khi đối tượng OLE được kích hoạt trong PowerPoint.

Ví dụ tạo một bản trình chiếu mới với khung OLE kích thước 9.5 × 4 inch, được đặt cách mép trái 0.5 inch và cách mép trên 1 inch. Các tọa độ và kích thước slide được tính bằng điểm (72 điểm mỗi inch). Đối với bản trình chiếu hiện có, xem [Use a Template](#use-a-template).

## **Đặt kích thước biểu đồ cố định**

Đặt [setSizeWithWindow](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#sizewithwindow) thành false để kích thước biểu đồ độc lập với cửa sổ sổ làm việc.  
Đặt kích thước của [getChartObject](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#chartobject) thông qua [setWidth](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#width) và [setHeight](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#height), chuyển đổi điểm sang pixel bằng 96 pixel mỗi inch: một khung có kích thước 684 × 288 điểm tương ứng với biểu đồ có kích thước 912 × 384 pixel.  
Đặt [setPrintSize](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#printsize) thành giá trị CUSTOM của [PrintSizeType](https://reference.aspose.com/cells/python-java/asposecells.api/printsizetype/).  
Ví dụ nhúng sổ làm việc bằng [addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) và lưu bản trình chiếu với khung OLE kích thước 9.5 × 4 inch.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import ChartType, FileFormatType, PrintSizeType, SheetType, Workbook
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("Data")
    data_sheet.getCells().get("A1").putValue(10)
    data_sheet.getCells().get("A2").putValue(20)

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add("Data!A1:A2", True)
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)

        # Các tọa độ và kích thước slide được tính bằng điểm (72 điểm mỗi inch).
        width = 684.0  # 9,5 inch.
        height = 288.0  # 4 inch.

        chart.setSizeWithWindow(False)
        # Chuyển đổi điểm sang pixel cho biểu đồ bằng 96 pixel mỗi inch.
        chart.getChartObject().setWidth(int(width / 72.0 * 96.0))
        chart.getChartObject().setHeight(int(height / 72.0 * 96.0))
        chart.setPrintSize(PrintSizeType.CUSTOM)

        workbook_stream = ByteArrayOutputStream()
        workbook.save(workbook_stream, FileFormatType.EXCEL_97_TO_2003)
        workbook_data = workbook_stream.toByteArray()
        data_info = OleEmbeddedDataInfo(workbook_data, "xls")
        slide.getShapes().addOleObjectFrame(36.0, 72.0, width, height, data_info)

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    workbook.dispose()
```

## **Sử dụng mẫu**

Logic tính kích thước tương tự cho bản trình chiếu hiện có. Để điều chỉnh ví dụ:

1. Tải bản trình chiếu mẫu thay vì tạo một bản trình chiếu trống.  
2. Kiểm tra slide đầu tiên có ít nhất ba shape, sau đó sử dụng shape ở chỉ số 2 làm chỗ giữ chỗ.  
3. Lấy chiều rộng và chiều cao khung từ shape đó thay vì sử dụng các giá trị cố định 684 và 288. Giữ nguyên các phép tính kích thước.  
4. Thêm khung OLE tại vị trí của chỗ giữ chỗ thay vì các tọa độ cố định 36 và 72.  
5. Xóa chỗ giữ chỗ trước khi lưu bản trình chiếu.

## **FAQ**

**Tại sao biểu đồ Excel được nhúng của tôi lại thay đổi kích thước sau khi kích hoạt trong PowerPoint?**  
Sự việc này xảy ra vì Excel cố gắng khôi phục kích thước cửa sổ gốc khi được kích hoạt lần đầu, trong khi khung đối tượng OLE trong PowerPoint có kích thước riêng. PowerPoint và Excel sẽ thương lượng kích thước để duy trì tỷ lệ, điều này có thể gây ra việc thay đổi kích thước.

**Làm sao tôi có thể giữ cho kích thước biểu đồ và khung OLE nhất quán?**  
Đặt kích thước biểu đồ cố định phù hợp với khung OLE và sử dụng kích thước in biểu đồ tùy chỉnh trước khi nhúng sổ làm việc. Ví dụ trên cho thấy các thiết lập cần thiết và cách chuyển đổi đơn vị.

**Việc khớp kích thước cửa sổ sổ làm việc có đủ không?**  
Chỉ khớp kích thước cửa sổ sổ làm việc không đảm bảo ngăn khung OLE thay đổi kích thước sau khi kích hoạt. Hãy sử dụng kích thước biểu đồ cố định như trong ví dụ.

**Giải pháp này có hoạt động với cả bản trình chiếu dựa trên mẫu và bản trình chiếu mới không?**  
Có. Đối với mẫu, sử dụng kích thước và vị trí của chỗ giữ chỗ. Đối với bản trình chiếu mới, xác định trực tiếp kích thước và vị trí của khung.

**Tôi có thể sử dụng ví dụ này với các biểu đồ được tạo trong các chương trình bảng tính khác không?**  
Ví dụ sử dụng sổ Excel được tạo bằng Aspose.Cells. Nó không minh họa hành vi kích hoạt cho các chương trình bảng tính khác.

## **Các phần liên quan**

- [Tạo biểu đồ Excel và nhúng chúng dưới dạng đối tượng OLE trong bản trình chiếu](/slides/vi/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)