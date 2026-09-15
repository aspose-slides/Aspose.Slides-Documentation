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
- OpenDocument
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Khắc phục việc thay đổi kích thước biểu đồ không mong muốn trong PPTX khi sử dụng các đối tượng OLE Excel được nhúng với Aspose.Slides cho Python qua Java. Tìm hiểu hai phương pháp kèm mã để duy trì kích thước nhất quán."
---
## **Bối cảnh**

Đã quan sát thấy rằng các biểu đồ Excel được nhúng dưới dạng đối tượng OLE trong bản trình bày PowerPoint thông qua các thành phần Aspose bị thay đổi kích thước theo một tỷ lệ không xác định sau lần kích hoạt đầu tiên. Hành vi này gây ra sự khác biệt đáng chú ý về mặt hình ảnh trong bản trình bày giữa trạng thái trước và sau khi kích hoạt biểu đồ. Đội ngũ Aspose đã nghiên cứu chi tiết vấn đề và tìm ra giải pháp. Bài viết này mô tả nguyên nhân của vấn đề và cách khắc phục tương ứng.

Trong [bài viết trước](/slides/vi/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), chúng tôi đã giải thích cách tạo biểu đồ Excel bằng Aspose.Cells cho Python qua Java và nhúng nó vào bản trình bày PowerPoint bằng Aspose.Slides cho Python qua Java. Để giải quyết [vấn đề xem trước đối tượng](/slides/vi/python-java/object-preview-issue-when-adding-oleobjectframe/), chúng tôi đã gán hình ảnh biểu đồ cho khung đối tượng OLE của biểu đồ. Trong bản trình bày đầu ra, khi bạn nhấp đúp vào khung đối tượng OLE hiển thị hình ảnh biểu đồ, biểu đồ Excel sẽ được kích hoạt. Người dùng cuối có thể thực hiện bất kỳ thay đổi nào mong muốn trong sổ làm việc Excel cơ bản và sau đó trở lại slide tương ứng bằng cách nhấp ra ngoài sổ làm việc đã kích hoạt. Kích thước của khung đối tượng OLE thay đổi khi người dùng quay lại slide, và hệ số thay đổi kích thước khác nhau tùy thuộc vào kích thước gốc của cả khung đối tượng OLE và sổ làm việc Excel được nhúng.

## **Nguyên nhân của việc thay đổi kích thước**

Vì sổ làm việc Excel có kích thước cửa sổ riêng, nó cố gắng giữ nguyên kích thước ban đầu khi được kích hoạt lần đầu. Tuy nhiên, khung đối tượng OLE cũng có kích thước của riêng nó. Theo Microsoft, khi sổ làm việc Excel được kích hoạt, Excel và PowerPoint sẽ thương lượng kích thước và duy trì tỷ lệ đúng như một phần của quá trình nhúng. Tùy thuộc vào sự khác biệt giữa kích thước cửa sổ Excel và kích thước hoặc vị trí của khung đối tượng OLE, việc thay đổi kích thước sẽ xảy ra.

## **Giải pháp thực hiện**

Có hai kịch bản khả thi để tạo bản trình bày PowerPoint bằng Aspose.Slides cho Python qua Java.

**Kịch bản 1:** Tạo bản trình bày dựa trên mẫu hiện có.

**Kịch bản 2:** Tạo bản trình bày từ đầu.

Giải pháp chúng tôi đưa ra ở đây áp dụng cho cả hai kịch bản. Cơ sở của mọi cách tiếp cận giải pháp là như nhau: **kích thước cửa sổ của đối tượng OLE được nhúng phải khớp với khung đối tượng OLE trong slide PowerPoint**. Bây giờ chúng ta sẽ thảo luận hai cách tiếp cận cho giải pháp này.

## **Cách tiếp cận đầu tiên**

Trong cách tiếp cận này, chúng ta sẽ học cách đặt kích thước cửa sổ của sổ làm việc Excel được nhúng sao cho nó khớp với kích thước của khung đối tượng OLE trong slide PowerPoint.

**Kịch bản 1**

Giả sử chúng ta đã xác định một mẫu và muốn tạo bản trình bày dựa trên nó. Giả sử có một shape ở chỉ mục 2 trong mẫu, nơi chúng ta muốn đặt một khung OLE chứa sổ làm việc Excel được nhúng. Trong kịch bản này, kích thước của khung đối tượng OLE được định trước — nó khớp với kích thước của shape ở chỉ mục 2 trong mẫu. Tất cả chúng ta cần làm là đặt kích thước cửa sổ của sổ làm việc bằng kích thước của shape đó. Đoạn mã sau thực hiện mục đích này:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Tải sổ làm việc Excel chứa biểu đồ.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Đặt kích thước cửa sổ sổ làm việc tính bằng inch (PowerPoint sử dụng 72 điểm mỗi inch).
    workbook.getSettings().setWindowWidthInch(shape.getWidth() / 72.0)
    workbook.getSettings().setWindowHeightInch(shape.getHeight() / 72.0)

    # Lưu sổ làm việc vào một luồng bộ nhớ.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Tạo khung đối tượng OLE với dữ liệu Excel được nhúng.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Kịch bản 2**

Giả sử chúng ta muốn tạo một bản trình bày từ đầu và bao gồm một khung đối tượng OLE có kích thước bất kỳ với sổ làm việc Excel được nhúng. Trong đoạn mã sau, chúng ta tạo một khung đối tượng OLE cao 4 inch và rộng 9,5 inch tại x = 0,5 inch và y = 1 inch trên slide. Sau đó chúng ta đặt cửa sổ sổ làm việc Excel cùng kích thước — cao 4 inch và rộng 9,5 inch.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Tải sổ làm việc Excel chứa biểu đồ.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 inch (4 * 72).
    desired_width = 684  # 9.5 inch (9.5 * 72).

    # Xác định kích thước biểu đồ với cửa sổ.
    chart.setSizeWithWindow(True)

    # Đặt kích thước cửa sổ sổ làm việc tính bằng inch (PowerPoint sử dụng 72 điểm mỗi inch).
    workbook.getSettings().setWindowWidthInch(desired_width / 72.0)
    workbook.getSettings().setWindowHeightInch(desired_height / 72.0)

    # Lưu sổ làm việc vào một luồng bộ nhớ.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Tạo khung đối tượng OLE với dữ liệu Excel được nhúng.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Cách tiếp cận thứ hai**

Trong cách tiếp cận này, chúng ta sẽ học cách đặt kích thước biểu đồ trong sổ làm việc Excel được nhúng sao cho nó khớp với kích thước của khung đối tượng OLE trong slide PowerPoint. Cách tiếp cận này hữu ích khi kích thước biểu đồ đã biết trước và sẽ không bao giờ thay đổi.

**Kịch bản 1**

Giả sử chúng ta đã xác định một mẫu và muốn tạo bản trình bày dựa trên nó. Giả sử có một shape ở chỉ mục 2 trong mẫu, nơi chúng ta dự định đặt một khung OLE chứa sổ làm việc Excel được nhúng. Trong kịch bản này, kích thước khung OLE được định trước — khớp với kích thước của shape ở chỉ mục 2 trong mẫu. Tất cả chúng ta cần làm là đặt kích thước biểu đồ trong sổ làm việc bằng kích thước của shape đó. Đoạn mã sau thực hiện mục đích này:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Tải sổ làm việc Excel chứa biểu đồ.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Xác định kích thước biểu đồ mà không có cửa sổ.
    chart.setSizeWithWindow(False)

    # Đặt kích thước biểu đồ bằng pixel (Excel sử dụng 96 pixel mỗi inch).
    chart.getChartObject().setWidth(int((shape.getWidth() / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((shape.getHeight() / 72.0) * 96.0))

    # Xác định kích thước in của biểu đồ.
    chart.setPrintSize(PrintSizeType.CUSTOM)

    # Lưu sổ làm việc vào một luồng bộ nhớ.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Tạo khung đối tượng OLE với dữ liệu Excel được nhúng.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Kịch bản 2**:

Giả sử chúng ta muốn tạo một bản trình bày từ đầu và bao gồm một khung đối tượng OLE có kích thước bất kỳ với sổ làm việc Excel được nhúng. Trong đoạn mã sau, chúng ta tạo một khung đối tượng OLE cao 4 inch và rộng 9,5 inch trên slide tại x = 0,5 inch và y = 1 inch. Chúng ta cũng đặt kích thước biểu đồ tương ứng cùng kích thước: cao 4 inch và rộng 9,5 inch.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Tải sổ làm việc Excel chứa biểu đồ.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 inch (4 * 72).
    desired_width = 684  # 9.5 inch (9.5 * 72).

    # Xác định kích thước biểu đồ mà không có cửa sổ.
    chart.setSizeWithWindow(False)

    # Đặt kích thước biểu đồ bằng pixel (Excel sử dụng 96 pixel mỗi inch).
    chart.getChartObject().setWidth(int((desired_width / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((desired_height / 72.0) * 96.0))

    # Lưu sổ làm việc vào một luồng bộ nhớ.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Tạo khung đối tượng OLE với dữ liệu Excel được nhúng.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Kết luận**

Có hai cách tiếp cận để khắc phục vấn đề thay đổi kích thước biểu đồ. Lựa chọn cách tiếp cận phụ thuộc vào yêu cầu và trường hợp sử dụng. Cả hai cách đều hoạt động tương tự cho dù bản trình bày được tạo từ mẫu hay tạo từ đầu. Ngoài ra, không có giới hạn nào đối với kích thước của khung đối tượng OLE trong giải pháp này.

## **Câu hỏi thường gặp**

**Tại sao biểu đồ Excel được nhúng của tôi lại thay đổi kích thước sau khi kích hoạt trong PowerPoint?**

Điều này xảy ra vì Excel cố gắng khôi phục kích thước cửa sổ ban đầu khi được kích hoạt lần đầu, trong khi khung đối tượng OLE trong PowerPoint có kích thước riêng. PowerPoint và Excel thương lượng kích thước để duy trì tỷ lệ khung hình, điều này có thể gây ra việc thay đổi kích thước.

**Có thể ngăn chặn hoàn toàn vấn đề thay đổi kích thước này không?**

Có. Bằng cách khớp kích thước cửa sổ sổ làm việc Excel hoặc kích thước biểu đồ với kích thước khung đối tượng OLE trước khi nhúng, bạn có thể giữ cho kích thước biểu đồ nhất quán.

**Tôi nên chọn cách tiếp cận nào, thiết lập kích thước cửa sổ workbook hay thiết lập kích thước biểu đồ?**

Sử dụng **Cách tiếp cận 1 (kích thước cửa sổ)** nếu bạn muốn duy trì tỷ lệ khung hình của sổ làm việc và có thể cho phép thay đổi kích thước sau này.  
Sử dụng **Cách tiếp cận 2 (kích thước biểu đồ)** nếu kích thước biểu đồ đã cố định và sẽ không thay đổi sau khi nhúng.

**Các phương pháp này có hoạt động với cả bản trình bày dựa trên mẫu và bản trình bày mới không?**

Có. Cả hai cách tiếp cận hoạt động giống nhau cho các bản trình bày được tạo từ mẫu và từ đầu.

**Có giới hạn nào đối với kích thước của khung đối tượng OLE không?**

Không. Bạn có thể đặt khung OLE ở bất kỳ kích thước nào miễn là nó được tỷ lệ phù hợp với kích thước sổ làm việc hoặc biểu đồ.

**Tôi có thể sử dụng các phương pháp này với biểu đồ được tạo trong các chương trình bảng tính khác không?**

Các ví dụ được thiết kế cho biểu đồ Excel tạo bằng Aspose.Cells, nhưng các nguyên tắc cũng áp dụng cho các chương trình bảng tính tương thích OLE khác miễn là chúng hỗ trợ các tùy chọn kích thước tương tự.

## **Các phần liên quan**

- [Tạo biểu đồ Excel và nhúng chúng như đối tượng OLE trong bản trình bày](/slides/vi/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)