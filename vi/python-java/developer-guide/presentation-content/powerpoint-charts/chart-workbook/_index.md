---
title: Quản lý Workbook Biểu đồ trong Bản trình bày bằng Python qua Java
linktitle: Workbook Biểu đồ
type: docs
weight: 70
url: /vi/python-java/chart-workbook/
keywords:
- workbook biểu đồ
- dữ liệu biểu đồ
- ô workbook
- nhãn dữ liệu
- bảng tính
- nguồn dữ liệu
- workbook bên ngoài
- dữ liệu bên ngoài
- bộ nhớ cache biểu đồ
- khôi phục workbook
- PowerPoint
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Khám phá Aspose.Slides cho Python qua Java: dễ dàng quản lý workbook biểu đồ trong các định dạng PowerPoint và OpenDocument để tối ưu hóa dữ liệu bản trình bày của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với workbook biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua luồng workbook, sử dụng các ô workbook làm nhãn dữ liệu biểu đồ, truy cập bộ sưu tập worksheet, và chỉ định kiểu nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng đề cập đến việc làm việc với workbook bên ngoài làm nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một workbook bên ngoài, lấy đường dẫn của workbook bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi workbook có sẵn.

Đối với các ô workbook đại diện cho dữ liệu thiếu, hãy xem [Kiểm soát hiển thị ô trống](/slides/vi/python-java/chart-series/) để hiểu sự khác nhau giữa ô trống và số zero, và so sánh biểu đồ đường của các chế độ hiển thị có sẵn.

## **Đọc và ghi dữ liệu biểu đồ từ Workbook**
Aspose.Slides cung cấp các phương thức [readWorkbookStream](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/#readWorkbookStream) và [writeWorkbookStream](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/#writeWorkbookStream) cho phép bạn đọc và ghi các workbook dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã chỉnh sửa bằng Aspose.Cells). **Lưu ý** rằng dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc phải có cấu trúc tương tự nguồn.

Đoạn mã Python này minh họa một thao tác mẫu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    workbook_data = chart_data.readWorkbookStream()
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(workbook_data)
finally:
    presentation.dispose()
```

### **Xác thực bố cục biểu đồ sau khi chỉnh sửa Workbook**

Khi bạn thay thế một workbook được nhúng bằng một workbook đã được chỉnh sửa, biểu đồ vẫn giữ lại các bộ sưu tập series và category gốc. Sự không nhất quán này có thể gây ra lỗi cho [Chart.validateChartLayout](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/#validateChartLayout) với `ArgumentOutOfRangeException` (tham số: index). Để tránh lỗi, hãy xóa các series và category hiện có **trước** khi ghi workbook đã cập nhật trở lại biểu đồ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# Đọc workbook sau khi đã chỉnh sửa (ví dụ, sử dụng Aspose.Cells).
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # Xóa các tham chiếu dữ liệu hiện có.
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

Việc xóa các bộ sưu tập đảm bảo cấu trúc dữ liệu biểu đồ phù hợp với workbook mới, cho phép [validateChartLayout](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/#validateChartLayout) hoàn thành mà không có lỗi.

## **Đặt ô Workbook làm nhãn dữ liệu biểu đồ**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
1. Lấy tham chiếu của slide thông qua chỉ số của nó.
1. Thêm biểu đồ Bubble với một số dữ liệu.
1. Truy cập series của biểu đồ.
1. Đặt ô workbook làm nhãn dữ liệu.
1. Lưu bản trình bày.

Đoạn mã Python này cho bạn thấy cách đặt ô workbook làm nhãn dữ liệu biểu đồ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)
    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Quản lý Worksheets**

Đoạn mã Python này minh họa một thao tác trong đó phương thức [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdataworkbook/#getWorksheets) được sử dụng để truy cập bộ sưu tập worksheet:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Chỉ định kiểu nguồn dữ liệu**

Đoạn mã Python này cho bạn thấy cách chỉ định một kiểu cho nguồn dữ liệu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    series_name = chart.getChartData().getSeries().get_Item(0).getName()
    series_name.setDataSourceType(DataSourceType.StringLiterals)
    series_name.setData("LiteralString")
    series_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell")
    series_name.setData(name_cell)
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Phát hiện định dạng Workbook nhúng không được hỗ trợ**

Aspose.Slides không hỗ trợ định dạng workbook nhị phân Excel (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng phương thức [getEmbeddedWorkbookType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) trên [ChartData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/) cùng với enum [WorkbookType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua các biểu đồ đó.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue
        chart_data = shape.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook and chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro:
            # Workbook nhúng ở định dạng .xlsb, không được hỗ trợ.
            continue
        # Đọc hoặc chỉnh sửa dữ liệu workbook của biểu đồ tại đây.
finally:
    presentation.dispose()
```

## **Workbook bên ngoài**

Aspose.Slides hỗ trợ việc sử dụng workbook bên ngoài làm nguồn dữ liệu cho biểu đồ.

### **Tạo một Workbook bên ngoài**

Sử dụng các phương thức [readWorkbookStream](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/#readWorkbookStream) và [setExternalWorkbook](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/#setExternalWorkbook), bạn có thể tạo một workbook bên ngoài từ đầu hoặc biến một workbook nội bộ thành bên ngoài.

Đoạn mã Python này minh họa quá trình tạo workbook bên ngoài:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    workbook_path = "externalWorkbook1.xlsx"
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(workbook_path)
    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Gán một Workbook bên ngoài**

Sử dụng phương thức [setExternalWorkbook](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/#setExternalWorkbook), bạn có thể gán một workbook bên ngoài cho biểu đồ làm nguồn dữ liệu. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới workbook bên ngoài (nếu workbook đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các workbook lưu trữ tại các vị trí hoặc tài nguyên từ xa, bạn vẫn có thể sử dụng chúng làm nguồn dữ liệu bên ngoài. Nếu cung cấp đường dẫn tương đối cho một workbook bên ngoài, nó sẽ tự động được chuyển thành đường dẫn đầy đủ.

Đoạn mã Python này cho bạn thấy cách gán một workbook bên ngoài:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, False)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("externalWorkbook.xlsx")
    workbook = chart_data.getChartDataWorkbook()
    series_name_cell = workbook.getCell(0, "B1")
    series = chart_data.getSeries().add(series_name_cell, ChartType.Pie)
    for row in range(2, 5):
        value_cell = workbook.getCell(0, f"B{row}")
        series.getDataPoints().addDataPointForPieSeries(value_cell)
    for row in range(2, 5):
        category_cell = workbook.getCell(0, f"A{row}")
        chart_data.getCategories().add(category_cell)
    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Tham số thứ hai (`bool`) của phương thức [setExternalWorkbook](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/#setExternalWorkbook) được dùng để chỉ định liệu workbook Excel có được tải hay không.

* Khi giá trị được đặt là `False`, chỉ đường dẫn workbook được cập nhật — dữ liệu biểu đồ sẽ không được tải hoặc cập nhật từ workbook đích. Bạn có thể muốn dùng cài đặt này khi workbook đích không tồn tại hoặc không khả dụng.  
* Khi giá trị được đặt là `True`, dữ liệu biểu đồ sẽ được cập nhật từ workbook đích.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("http://path/doesnt/exists", False)
    presentation.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Lấy đường dẫn Workbook nguồn dữ liệu bên ngoài của một biểu đồ**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
1. Lấy tham chiếu của slide thông qua chỉ số của nó.
1. Tạo một đối tượng cho shape biểu đồ.
1. Tạo một đối tượng cho kiểu nguồn ([ChartDataSourceType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdatasourcetype/)) đại diện cho nguồn dữ liệu của biểu đồ.
1. Xác định điều kiện phù hợp dựa trên việc kiểu nguồn giống với kiểu nguồn dữ liệu workbook bên ngoài.

Đoạn mã Python này minh họa thao tác:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(1)
    chart = slide.getShapes().get_Item(0)
    source_type = chart.getChartData().getDataSourceType()
    if source_type == ChartDataSourceType.ExternalWorkbook:
        path = chart.getChartData().getExternalWorkbookPath()
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Chỉnh sửa dữ liệu biểu đồ**

Bạn có thể chỉnh sửa dữ liệu trong workbook bên ngoài theo cách tương tự như khi thay đổi nội dung của workbook nội bộ. Khi không thể tải workbook bên ngoài, một ngoại lệ sẽ được ném ra.

Đoạn mã Python này là triển khai của quy trình trên:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    chart_data.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(jpype.JInt(100))
    presentation.save("presentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Khôi phục một Workbook từ bộ nhớ cache của biểu đồ**

Nếu một biểu đồ sử dụng workbook bên ngoài mà thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo workbook của biểu đồ từ dữ liệu đã được lưu trong cache của bản trình bày. Tạo [LoadOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/), cấu hình nó với [SpreadsheetOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/spreadsheetoptions/), và gọi [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/vi/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) với `True` trước khi mở bản trình bày.

Ví dụ Python sau mở một bản trình bày mà biểu đồ tham chiếu tới một workbook bên ngoài không khả dụng và truy cập dữ liệu đã khôi phục thông qua [Chart.getChartData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/#getChartData) và [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)
load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    recovered_workbook = chart.getChartData().getChartDataWorkbook()

    # Đọc hoặc chỉnh sửa dữ liệu workbook đã khôi phục tại đây.
finally:
    presentation.dispose()
```

Nếu workbook bên ngoài không khả dụng và tính năng khôi phục bị tắt, Aspose.Slides sẽ ném ra một ngoại lệ. Chỉ bật tính năng khôi phục khi việc sử dụng dữ liệu biểu đồ đã được cache là chấp nhận được, vì cache có thể không chứa các thay đổi đã thực hiện trên workbook bên ngoài sau lần cập nhật cuối cùng của bản trình bày.

## **Câu hỏi thường gặp**

**Tôi có thể xác định một biểu đồ cụ thể có liên kết tới workbook bên ngoài hay workbook được nhúng không?**

Có. Một biểu đồ có [kiểu nguồn dữ liệu](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/#getDataSourceType) và một [đường dẫn tới workbook bên ngoài](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); nếu nguồn là một workbook bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp bên ngoài đang được sử dụng.

**Các đường dẫn tương đối tới workbook bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Điều này tiện lợi cho việc di động dự án; tuy nhiên, hãy lưu ý rằng bản trình bày sẽ lưu đường dẫn tuyệt đối trong file PPTX.

**Tôi có thể sử dụng các workbook nằm trên tài nguyên/mạng chia sẻ không?**

Có, các workbook như vậy có thể được sử dụng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa trực tiếp các workbook từ xa bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè lên file XLSX bên ngoài khi lưu bản trình bày không?**

Không. Bản trình bày lưu một [liên kết tới tệp bên ngoài](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) và sử dụng nó để đọc dữ liệu. Tệp bên ngoài sẽ không bị thay đổi khi bản trình bày được lưu.

**Nếu tệp bên ngoài được bảo vệ bằng mật khẩu, tôi nên làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách thường dùng là gỡ bỏ bảo vệ trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, bằng cách sử dụng [Aspose.Cells](/cells/python-java/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một workbook bên ngoài không?**

Có. Mỗi biểu đồ lưu trữ liên kết riêng của mình. Nếu chúng đều trỏ tới cùng một tệp, việc cập nhật tệp sẽ được phản ánh trong mỗi biểu đồ lần tiếp theo dữ liệu được tải.