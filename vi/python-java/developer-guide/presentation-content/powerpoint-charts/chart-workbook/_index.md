---
title: Quản lý Workbook Biểu đồ trong Bài thuyết trình bằng Python qua Java
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
- workbook ngoại
- dữ liệu ngoại
- bộ nhớ đệm biểu đồ
- khôi phục workbook
- PowerPoint
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Khám phá Aspose.Slides cho Python qua Java: dễ dàng quản lý workbook biểu đồ trong các định dạng PowerPoint và OpenDocument để tối ưu hóa dữ liệu bài thuyết trình của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sách dữ liệu biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua các luồng workbook, sử dụng các ô workbook làm nhãn dữ liệu biểu đồ, truy cập bộ sưu tập worksheet, và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng bao quát việc làm việc với các workbook bên ngoài làm nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một workbook bên ngoài, lấy đường dẫn của workbook bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi workbook có sẵn.

Đối với các ô workbook đại diện cho dữ liệu thiếu, hãy xem [Kiểm soát cách hiển thị các ô trống](/slides/vi/python-java/chart-series/) để biết sự khác nhau giữa một ô trống và số 0, và so sánh biểu đồ đường của các chế độ hiển thị khả dụng.

## **Bao gồm dữ liệu từ các hàng và cột ẩn**

Sử dụng [Chart.setPlotVisibleCellsOnly] để kiểm soát việc biểu đồ chỉ vẽ dữ liệu từ các hàng và cột worksheet ẩn hay không. Đặt thành `True` để chỉ vẽ các ô hiển thị, hoặc `False` để bao gồm cả các ô hiển thị và ẩn. Cài đặt này điều khiển việc vẽ biểu đồ; nó không ẩn hoặc hiện các hàng hoặc cột worksheet.

Tải xuống [hidden-source-data.pptx](hidden-source-data.pptx) và đặt nó vào thư mục làm việc. Trang chiếu đầu tiên của nó chứa một biểu đồ cột làm hình dạng đầu tiên. Worksheet nhúng, `Sheet1`, chứa phạm vi nguồn sau, `A1:C4`. Hàng 3 và cột C bị ẩn, nhưng các ô của chúng vẫn chứa giá trị.

| Hàng worksheet | A: Tháng | B: Bán lẻ | C: Bán buôn (cột ẩn) |
| --- | --- | --- | --- |
| 2 | Tháng 1 | 10 | 30 |
| 3 (hàng ẩn) | Tháng 2 | 40 | 60 |
| 4 | Tháng 3 | 20 | 50 |

Truy cập các ô nguồn thông qua [ChartData.getChartDataWorkbook] và đọc [ChartDataCell.isHidden] để kiểm tra trạng thái ẩn của chúng. Phương pháp này báo cáo trạng thái ẩn mà không thay đổi nó. Trong tệp này, B2 hiển thị, B3 thuộc hàng ẩn, và C2 thuộc cột ẩn; ví dụ in ra `False`, `True`, và `True`, tương ứng.

Đối với ví dụ này, làm mới dữ liệu biểu đồ sau khi thay đổi cài đặt vẽ: giữ lại workbook nhúng bằng [readWorkbookStream] và tải lại bằng [writeWorkbookStream]. Khi bao gồm tất cả các ô, cũng sử dụng [setRange] để khôi phục phạm vi đầy đủ, bao gồm danh mục tháng 2 bị ẩn. Chỉ thay đổi cờ không đủ để làm mới dữ liệu biểu đồ và nhãn danh mục đã được lưu trong bộ nhớ đệm của mẫu này.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("hidden-source-data.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        workbook = chart.getChartData().getChartDataWorkbook()
        print("B2 hidden:", workbook.getCell(0, "B2").isHidden())
        print("B3 hidden:", workbook.getCell(0, "B3").isHidden())
        print("C2 hidden:", workbook.getCell(0, "C2").isHidden())

        workbook_data = chart.getChartData().readWorkbookStream()
        for visible_only in (True, False):
            chart.setPlotVisibleCellsOnly(visible_only)

            # Làm mới dữ liệu biểu đồ từ workbook nhúng.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # Khôi phục phạm vi nguồn đầy đủ, bao gồm các danh mục ẩn.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Ví dụ lưu `hidden_cells_True.pptx` chỉ với các giá trị Bán lẻ hiển thị (10 và 20), và `hidden_cells_False.pptx` với tất cả sáu giá trị. Các hình ảnh dưới đây minh họa hai chế độ vẽ. Hàng 3 và cột C vẫn ẩn trong cả hai workbook nhúng.

| Chỉ các ô hiển thị (`True`) | Tất cả các ô (`False`) |
| --- | --- |
| ![Chỉ các ô hiển thị: Giá trị Bán lẻ 10 và 20 cho Tháng 1 và Tháng 3.](hidden_cells_True.png) | ![Tất cả các ô: Giá trị Bán lẻ và Bán buôn cho Tháng 1, Tháng 2 và Tháng 3.](hidden_cells_False.png) |

Một ô ẩn chứa giá trị khác với một ô trống. [Chart.setDisplayBlanksAs] điều khiển cách hiển thị các giá trị thiếu; nó không bao gồm hoặc loại trừ dữ liệu nguồn ẩn. Xem [Control the Display of Empty Cells](/slides/vi/python-java/chart-series/#control-the-display-of-empty-cells) để xem ví dụ.

## **Đọc và Ghi Dữ liệu Biểu đồ từ Workbook**

Aspose.Slides for Python via Java cung cấp các phương thức [readWorkbookStream] và [writeWorkbookStream] cho phép bạn đọc và ghi các workbook dữ liệu biểu đồ (chứa dữ liệu biểu đồ được chỉnh sửa bằng Aspose.Cells). **Lưu ý** rằng dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc phải có cấu trúc tương tự như nguồn.

Ví dụ này mở `chart.pptx`, cần có một biểu đồ làm hình dạng đầu tiên trên slide đầu tiên. Nó đọc workbook nhúng vào một mảng byte, xóa các series và category hiện có, và ghi lại cùng một workbook. Các thay đổi vẫn ở trong bộ nhớ; ví dụ không lưu bài thuyết trình.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **Xác thực bố cục biểu đồ sau khi chỉnh sửa Workbook**

Khi bạn thay thế một workbook nhúng bằng một workbook đã chỉnh sửa, biểu đồ vẫn giữ các bộ sưu tập series và category gốc. Sự không khớp này có thể làm cho [Chart.validateChartLayout] thất bại với lỗi index-out-of-range. Hãy xóa các series và category hiện có trước khi ghi lại workbook đã cập nhật vào biểu đồ. Ví dụ này yêu cầu `chart.pptx` có một biểu đồ làm hình dạng đầu tiên trên slide đầu tiên. Nhận xét đánh dấu nơi việc chỉnh sửa workbook sẽ diễn ra; ví dụ có thể chạy sẽ ghi lại workbook gốc và xác thực bố cục trong bộ nhớ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        # Chỉnh sửa các byte workbook ở đây, ví dụ, bằng cách sử dụng Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Xóa các bộ sưu tập loại bỏ các tham chiếu dữ liệu cũ trước khi workbook được ghi lại. Xây dựng lại bất kỳ ánh xạ series và category cần thiết nào cho workbook đã cập nhật trước khi sử dụng biểu đồ.

## **Đặt một ô Workbook làm Nhãn Dữ liệu Biểu đồ**

Bạn có thể sử dụng văn bản từ các ô workbook làm nhãn dữ liệu biểu đồ. Các bước sau cho thấy cách liên kết nhãn trong biểu đồ bubble tới các ô trong workbook dữ liệu của nó.

1. Tạo một thể hiện của lớp [Presentation].
2. Truy cập slide đầu tiên bằng chỉ số bắt đầu từ 0.
3. Thêm một biểu đồ bubble với dữ liệu mặc định.
4. Truy cập series của biểu đồ.
5. Đặt ô workbook làm nhãn dữ liệu.
6. Lưu bài thuyết trình.

Ví dụ này mở `chart2.pptx`, cần có ít nhất một slide, và thêm một biểu đồ bubble với dữ liệu mặc định. Nó sử dụng các ô A10:A12 trên worksheet 0 cho ba nhãn đầu tiên trong series đầu tiên, bật nhãn từ ô, và lưu kết quả vào `resultchart.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    
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

[ChartDataWorkbook.getWorksheets] cung cấp quyền truy cập vào các worksheet trong một chart workbook. Ví dụ này tạo một biểu đồ pie với dữ liệu mặc định và in tên mỗi worksheet ra console.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Chỉ định Loại Nguồn Dữ liệu**

Ví dụ này tạo một biểu đồ cột 3D với dữ liệu mặc định và đặt hai tên series bằng các nguồn dữ liệu khác nhau. Tên đầu tiên sử dụng chuỗi literal; tên thứ hai sử dụng ô C1 trên worksheet 0. Phân loại [DataSourceType] chọn nguồn cho mỗi tên. Kết quả được lưu vào `pres.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    literal_name = chart.getChartData().getSeries().get_Item(0).getName()
    literal_name.setDataSourceType(DataSourceType.StringLiterals)
    literal_name.setData("LiteralString")
    cell_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell")
    cell_name.setDataSourceType(DataSourceType.Worksheet)
    cell_name.setData(name_cell)
    
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Phát hiện Định dạng Workbook Nhúng Không được Hỗ trợ**

Aspose.Slides không hỗ trợ định dạng workbook Excel nhị phân (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng phương thức [getEmbeddedWorkbookType] trên [ChartData] cùng với enum [WorkbookType] để phát hiện các định dạng không được hỗ trợ và bỏ qua các biểu đồ đó. Ví dụ này kiểm tra các shape trên slide đầu tiên của `sample.pptx`, bỏ qua các shape không phải biểu đồ, và in thông điệp chẩn đoán cho mỗi biểu đồ có workbook .xlsb nhúng.

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

        is_internal_workbook = chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook
        is_binary_macro = chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue
        # Đọc hoặc chỉnh sửa dữ liệu workbook biểu đồ được hỗ trợ tại đây.
finally:
    presentation.dispose()
```

## **Workbook Ngoài**

Aspose.Slides hỗ trợ sử dụng workbook ngoài làm nguồn dữ liệu cho biểu đồ.

### **Tạo một Workbook Ngoài**

Sử dụng [readWorkbookStream] và [setExternalWorkbook] để xuất workbook biểu đồ nhúng ra một tệp và liên kết biểu đồ với workbook ngoài đó.

Ví dụ này tạo một biểu đồ pie với dữ liệu mặc định, ghi workbook của nó vào `externalWorkbook1.xlsx`, và hoàn thành việc ghi tệp trước khi gán tệp làm nguồn dữ liệu biểu đồ. Nó lưu bài thuyết trình liên kết vào `externalWorkbook.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_path = Path("externalWorkbook1.xlsx").resolve()
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(str(workbook_path))

    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Đặt một Workbook Ngoài**

Sử dụng phương thức [setExternalWorkbook], bạn có thể gán một workbook ngoài cho biểu đồ làm nguồn dữ liệu. Phương thức này cũng có thể được dùng để cập nhật đường dẫn đến workbook ngoài (nếu workbook đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các workbook được lưu ở vị trí từ xa hoặc tài nguyên, bạn vẫn có thể sử dụng các workbook đó như một nguồn dữ liệu ngoài. Nếu cung cấp đường dẫn tương đối cho workbook ngoài, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối.

Ví dụ này yêu cầu `externalWorkbook.xlsx` trong thư mục làm việc. Worksheet có tên `Sheet1` phải chứa một tên series ở B1, các tên danh mục ở A2:A4, và các giá trị số ở B2:B4. Ví dụ tạo một biểu đồ pie, liên kết workbook, và sử dụng [setRange] để ánh xạ A1:B4 thành một series và ba danh mục. Nó lưu kết quả vào `Presentation_with_externalWorkbook.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())
    chart_data.setExternalWorkbook(workbook_path)
    chart_data.setRange("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Tham số `updateChartData` của [setExternalWorkbook] kiểm soát việc có nạp workbook hay không.

* Khi `updateChartData` là `False`, chỉ đường dẫn workbook được cập nhật. Dữ liệu biểu đồ không được nạp hoặc cập nhật từ workbook mục tiêu, vì vậy workbook có thể không khả dụng.
* Khi `updateChartData` là `True`, dữ liệu biểu đồ được cập nhật từ workbook mục tiêu.

Ví dụ sau gán một URL placeholder với `updateChartData` đặt thành `False`. Nó giữ dữ liệu mặc định của biểu đồ pie và lưu bài thuyết trình mà không nạp workbook không khả dụng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", False)

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Lấy Đường Dẫn Workbook Nguồn Dữ liệu Ngoài của Biểu đồ**

Để xác định workbook được liên kết với một biểu đồ, đầu tiên kiểm tra xem biểu đồ có sử dụng nguồn dữ liệu ngoài không. Nếu có, bạn có thể lấy đường dẫn workbook theo các bước sau.

1. Tạo một thể hiện của lớp [Presentation].
2. Truy cập slide đầu tiên bằng chỉ số bắt đầu từ 0.
3. Kiểm tra xem hình dạng đầu tiên có phải là biểu đồ không.
4. Đọc loại nguồn dữ liệu biểu đồ.
5. Nếu nguồn là một workbook ngoài, đọc đường dẫn của nó.

Ví dụ này mở `externalWorkbook.pptx`, được tạo trong ví dụ trước, và kiểm tra hình dạng đầu tiên trên slide đầu tiên. Nếu nó là một biểu đồ liên kết với workbook ngoài, ví dụ in [getExternalWorkbookPath] ra console. Sau đó lưu một bản sao của bài thuyết trình vào `Result.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("externalWorkbook.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.ExternalWorkbook:
            print(chart_data.getExternalWorkbookPath())
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Chỉnh sửa Dữ liệu Biểu đồ**

Bạn có thể chỉnh sửa dữ liệu trong workbook ngoài tương tự như chỉnh sửa nội dung của workbook nội bộ. Khi một workbook ngoài không thể nạp, một ngoại lệ sẽ được ném.

Ví dụ này yêu cầu `presentation.pptx` có một biểu đồ làm hình dạng đầu tiên trên slide đầu tiên và một workbook ngoài có thể truy cập. Nó đặt giá trị dựa trên ô của điểm dữ liệu đầu tiên trong series đầu tiên thành 100 và lưu bài thuyết trình vào `presentation_out.pptx`. Việc chỉnh sửa giá trị ô có thể cập nhật file XLSX ngoài đã liên kết, vì vậy hãy sử dụng bản sao nếu bạn cần giữ nguyên workbook gốc.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        series = chart.getChartData().getSeries()
        if series.size() > 0 and series.get_Item(0).getDataPoints().size() > 0:
            value_cell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell()
            if value_cell is not None:
                value_cell.setValue(jpype.JInt(100))
                presentation.save("presentation_out.pptx", SaveFormat.Pptx)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **Khôi phục Workbook từ Bộ nhớ Đệm Biểu đồ**

Nếu một biểu đồ sử dụng workbook ngoài bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo workbook biểu đồ từ dữ liệu được lưu trong bộ nhớ đệm của bài thuyết trình. Tạo [LoadOptions], gọi [LoadOptions.setSpreadsheetOptions], và đặt [SpreadsheetOptions.setRecoverWorkbookFromChartCache] thành `True` trước khi mở bài thuyết trình.

Ví dụ Python sau mở `presentation.pptx`, trong đó hình dạng đầu tiên trên slide đầu tiên phải là một biểu đồ tham chiếu tới workbook ngoài không khả dụng, và truy cập dữ liệu đã khôi phục thông qua [Chart.getChartData] và [ChartData.getChartDataWorkbook]:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        recovered_workbook = chart.getChartData().getChartDataWorkbook()

        # Đọc hoặc chỉnh sửa dữ liệu workbook đã khôi phục tại đây.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Nếu workbook ngoài không khả dụng và việc khôi phục bị tắt, Aspose.Slides sẽ ném ngoại lệ. Chỉ bật khôi phục khi việc sử dụng dữ liệu biểu đồ đã lưu trong bộ nhớ đệm là cách dự phòng chấp nhận được, vì bộ nhớ đệm có thể không chứa các thay đổi được thực hiện trên workbook ngoài sau khi bài thuyết trình được cập nhật lần cuối.

## **Câu hỏi thường gặp**

**Can I determine whether a specific chart is linked to an external or an embedded workbook?**

Có. Một biểu đồ có một [data source type] và một [path to an external workbook]; nếu nguồn là một workbook ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp bên ngoài đang được sử dụng.

**Are relative paths to external workbooks supported, and how are they stored?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Bài thuyết trình lưu đường dẫn tuyệt đối trong tệp PPTX, vì vậy việc di chuyển workbook có thể yêu cầu cập nhật liên kết.

**Can I use workbooks located on network resources/shares?**

Có, các workbook như vậy có thể được sử dụng làm nguồn dữ liệu ngoài. Tuy nhiên, việc chỉnh sửa trực tiếp các workbook từ xa bằng Aspose.Slides không được hỗ trợ—chúng chỉ có thể được dùng làm nguồn.

**Does Aspose.Slides overwrite the external XLSX when saving the presentation?**

Bài thuyết trình lưu một [link to the external file]; việc chỉnh sửa dữ liệu biểu đồ dựa trên ô cũng có thể cập nhật file XLSX địa phương đã liên kết. Hãy dùng một bản sao của workbook nếu cần giữ nguyên bản gốc.

**What should I do if the external file is password-protected?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách thường dùng là gỡ bảo mật trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, bằng [Aspose.Cells]) và liên kết tới bản sao đó.

**Can multiple charts reference the same external workbook?**

Có. Mỗi biểu đồ lưu liên kết riêng của mình. Nếu tất cả chúng trỏ tới cùng một tệp, việc cập nhật tệp sẽ được phản ánh trong mỗi biểu đồ khi dữ liệu được tải lại.