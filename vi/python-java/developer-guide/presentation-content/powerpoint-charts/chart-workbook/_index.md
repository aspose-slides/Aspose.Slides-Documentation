---
title: Quản lý Sổ công việc Biểu đồ trong Bản trình chiếu bằng Python qua Java
linktitle: Sổ công việc Biểu đồ
type: docs
weight: 70
url: /vi/python-java/chart-workbook/
keywords:
- sổ công việc biểu đồ
- dữ liệu biểu đồ
- ô sổ công việc
- nhãn dữ liệu
- bảng tính
- nguồn dữ liệu
- sổ công việc bên ngoài
- dữ liệu bên ngoài
- bộ nhớ đệm biểu đồ
- khôi phục sổ công việc
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Khám phá Aspose.Slides cho Python qua Java: dễ dàng quản lý sổ công việc biểu đồ trong các định dạng PowerPoint và OpenDocument để tối ưu hóa dữ liệu trình chiếu của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sổ công việc biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua luồng sổ công việc, sử dụng các ô sổ công việc làm nhãn dữ liệu biểu đồ, truy cập các bộ sưu tập bảng tính, và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng bao gồm việc làm việc với sổ công việc bên ngoài làm nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một sổ công việc bên ngoài, lấy đường dẫn của sổ công việc bên ngoài được liên kết với một biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi sổ công việc có sẵn.

## **Đọc và Ghi Dữ liệu Biểu đồ từ Sổ công việc**

Aspose.Slides cung cấp các phương thức [readWorkbookStream](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/#readWorkbookStream) và [writeWorkbookStream](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/#writeWorkbookStream) cho phép bạn đọc và ghi sổ công việc dữ liệu biểu đồ (chứa dữ liệu biểu đồ được chỉnh sửa bằng Aspose.Cells). **Lưu ý** dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc phải có cấu trúc tương tự nguồn.

Mã Python này minh họa một thao tác mẫu:
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

### **Xác thực Bố cục Biểu đồ Sau Khi Sửa đổi Sổ công việc**

Khi bạn thay thế một sổ công việc nhúng bằng một phiên bản đã được sửa đổi, biểu đồ vẫn giữ lại các bộ sưu tập chuỗi và danh mục gốc. Sự không đồng nhất này có thể khiến [Chart.validateChartLayout](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/#validateChartLayout) ném ra một `ArgumentOutOfRangeException` (tham số: index). Để tránh ngoại lệ, hãy xóa các chuỗi và danh mục hiện có **trước khi** ghi sổ công việc đã cập nhật trở lại biểu đồ.
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# Đọc sổ công việc sau khi đã chỉnh sửa (ví dụ, sử dụng Aspose.Cells).
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

Việc xóa các bộ sưu tập đảm bảo cấu trúc dữ liệu biểu đồ phù hợp với sổ công việc mới, cho phép [validateChartLayout](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/#validateChartLayout) hoàn thành mà không gặp lỗi.

## **Đặt Ô Sổ công việc làm Nhãn Dữ liệu Biểu đồ**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Thêm một biểu đồ Bubble với một số dữ liệu.
4. Truy cập các chuỗi của biểu đồ.
5. Đặt ô sổ công việc làm nhãn dữ liệu.
6. Lưu bản trình chiếu.

Mã Python này cho bạn thấy cách đặt ô sổ công việc làm nhãn dữ liệu biểu đồ:
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

## **Quản lý Bảng tính**

Mã Python này minh họa một thao tác trong đó phương thức [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdataworkbook/#getWorksheets) được sử dụng để truy cập một bộ sưu tập bảng tính:
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

## **Chỉ định Loại Nguồn Dữ liệu**

Mã Python này cho bạn thấy cách chỉ định một loại cho nguồn dữ liệu:
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

## **Phát hiện Định dạng Sổ công việc Nhúng Không được Hỗ trợ**

Aspose.Slides không hỗ trợ định dạng sổ công việc nhị phân Excel (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng phương thức [getEmbeddedWorkbookType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) trên [ChartData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/) kết hợp với liệt kê [WorkbookType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua những biểu đồ đó.
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
            # Sổ công việc nhúng ở định dạng .xlsb, không được hỗ trợ.
            continue
        # Đọc hoặc sửa đổi dữ liệu sổ công việc biểu đồ tại đây.
finally:
    presentation.dispose()
```

### **Tạo một Sổ công việc Bên ngoài**

Sử dụng các phương thức [readWorkbookStream](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/#readWorkbookStream) và [setExternalWorkbook](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/#setExternalWorkbook), bạn có thể tạo một sổ công việc bên ngoài từ đầu hoặc chuyển một sổ công việc nội bộ thành bên ngoài.

Mã Python này minh họa quy trình tạo sổ công việc bên ngoài:
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

### **Gán một Sổ công việc Bên ngoài**

Sử dụng phương thức [setExternalWorkbook](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/#setExternalWorkbook), bạn có thể gán một sổ công việc bên ngoài cho biểu đồ làm nguồn dữ liệu của nó. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới sổ công việc bên ngoài (nếu sổ công việc đó đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các sổ công việc được lưu ở vị trí hoặc tài nguyên từ xa, bạn vẫn có thể sử dụng các sổ công việc đó làm nguồn dữ liệu bên ngoài. Nếu cung cấp đường dẫn tương đối cho một sổ công việc bên ngoài, nó sẽ tự động được chuyển thành đường dẫn đầy đủ.

Mã Python này cho bạn thấy cách gán một sổ công việc bên ngoài:
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

Tham số thứ hai (`bool`) của phương thức [setExternalWorkbook](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/#setExternalWorkbook) được dùng để chỉ định liệu một sổ công việc Excel có được tải hay không.

* Khi giá trị của nó được đặt thành `False`, chỉ đường dẫn sổ công việc được cập nhật — dữ liệu biểu đồ sẽ không được tải hoặc cập nhật từ sổ công việc đích. Bạn có thể muốn sử dụng cài đặt này khi sổ công việc đích không tồn tại hoặc không khả dụng.  
* Khi giá trị của nó được đặt thành `True`, dữ liệu biểu đồ sẽ được cập nhật từ sổ công việc đích.  
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

### **Lấy Đường dẫn Sổ công việc Nguồn Dữ liệu Bên ngoài của Một Biểu đồ**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Tạo một đối tượng cho hình dạng biểu đồ.
4. Tạo một đối tượng cho loại nguồn ([ChartDataSourceType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdatasourcetype/)) đại diện cho nguồn dữ liệu của biểu đồ.
5. Xác định điều kiện phù hợp dựa trên việc loại nguồn giống với loại nguồn dữ liệu sổ công việc bên ngoài.

Mã Python này minh họa thao tác:
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

### **Chỉnh sửa Dữ liệu Biểu đồ**

Bạn có thể chỉnh sửa dữ liệu trong sổ công việc bên ngoài tương tự như cách bạn thay đổi nội dung của sổ công việc nội bộ. Khi không thể tải một sổ công việc bên ngoài, một ngoại lệ sẽ được ném ra.

Mã Python này là một triển khai của quy trình đã mô tả:
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

### **Khôi phục Sổ công việc từ Bộ nhớ Đệm Biểu đồ**

Nếu một biểu đồ sử dụng sổ công việc bên ngoài bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo sổ công việc biểu đồ từ dữ liệu được lưu trong bộ nhớ đệm của bản trình chiếu. Tạo [LoadOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/), cấu hình nó với [SpreadsheetOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/spreadsheetoptions/), và gọi [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/vi/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) với `True` trước khi mở bản trình chiếu.

Ví dụ Python sau mở một bản trình chiếu mà trong đó biểu đồ tham chiếu một sổ công việc bên ngoài không khả dụng và truy cập dữ liệu đã khôi phục thông qua [Chart.getChartData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/#getChartData) và [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/#getChartDataWorkbook):
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

    # Đọc hoặc sửa đổi dữ liệu sổ công việc được khôi phục tại đây.
finally:
    presentation.dispose()
```

Nếu sổ công việc bên ngoài không khả dụng và việc khôi phục bị tắt, Aspose.Slides sẽ ném ra một ngoại lệ. Chỉ bật khôi phục khi việc sử dụng dữ liệu biểu đồ đã lưu trong bộ nhớ đệm là một giải pháp dự phòng chấp nhận được, vì bộ nhớ đệm có thể không chứa các thay đổi được thực hiện trên sổ công việc bên ngoài sau khi bản trình chiếu được cập nhật lần cuối.

## **Câu hỏi thường gặp**

**Tôi có thể xác định xem một biểu đồ cụ thể có được liên kết tới sổ công việc bên ngoài hay sổ công việc nhúng không?**

Có. Một biểu đồ có một [loại nguồn dữ liệu](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/#getDataSourceType) và một [đường dẫn tới sổ công việc bên ngoài](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); nếu nguồn là một sổ công việc bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp bên ngoài đang được sử dụng.

**Các đường dẫn tương đối tới sổ công việc bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Điều này thuận tiện cho việc di động của dự án; tuy nhiên, hãy lưu ý rằng bản trình chiếu sẽ lưu đường dẫn tuyệt đối trong tệp PPTX.

**Tôi có thể sử dụng các sổ công việc nằm trên tài nguyên/mạng chia sẻ không?**

Có, những sổ công việc như vậy có thể được dùng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa các sổ công việc từ xa trực tiếp từ Aspose.Slides không được hỗ trợ — chúng chỉ có thể được sử dụng làm nguồn.

**Aspose.Slides có ghi đè lên tệp XLSX bên ngoài khi lưu bản trình chiếu không?**

Không. Bản trình chiếu lưu một [liên kết tới tệp bên ngoài](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) và sử dụng nó để đọc dữ liệu. Tệp bên ngoài không bị thay đổi khi bản trình chiếu được lưu.

**Tôi nên làm gì nếu tệp bên ngoài được bảo vệ bằng mật khẩu?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách thường được dùng là gỡ bảo vệ trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, sử dụng [Aspose.Cells](/cells/python-java/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu tới cùng một sổ công việc bên ngoài không?**

Có. Mỗi biểu đồ lưu trữ liên kết riêng của mình. Nếu tất cả chúng đều trỏ tới cùng một tệp, việc cập nhật tệp đó sẽ được phản ánh trong mỗi biểu đồ lần tiếp theo dữ liệu được tải.