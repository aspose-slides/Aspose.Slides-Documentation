---
title: Quản lý Workbook Biểu đồ trong Bản trình chiếu bằng Python qua Java
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
- bộ nhớ đệm biểu đồ
- khôi phục workbook
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Khám phá Aspose.Slides cho Python qua Java: dễ dàng quản lý workbook biểu đồ trong định dạng PowerPoint và OpenDocument để tối ưu hóa dữ liệu bản trình chiếu của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sổ làm việc (workbook) biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua luồng sổ làm việc, sử dụng các ô sổ làm việc làm nhãn dữ liệu biểu đồ, truy cập bộ sưu tập worksheet và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng đề cập đến việc làm việc với sổ làm việc bên ngoài như nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một sổ làm việc bên ngoài, lấy đường dẫn của sổ làm việc bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi sổ làm việc khả dụng.

Đối với các ô sổ làm việc đại diện cho dữ liệu thiếu, xem [Kiểm soát hiển thị các ô trống](/slides/vi/python-java/chart-series/) để biết sự khác nhau giữa ô trống và giá trị zero, và so sánh biểu đồ đường của các chế độ hiển thị có sẵn.

## **Bao gồm dữ liệu từ các hàng và cột ẩn**

Sử dụng [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) để kiểm soát việc biểu đồ vẽ dữ liệu từ các hàng và cột worksheet ẩn. Đặt giá trị `True` để vẽ chỉ các ô hiển thị, hoặc `False` để bao gồm cả ô hiển thị và ẩn. Cài đặt này chỉ điều khiển việc vẽ biểu đồ; nó không ẩn hoặc hiện các hàng hoặc cột worksheet.

[Bản trình diễn mẫu](hidden-source-data.pptx) chứa một biểu đồ cột là hình dạng đầu tiên trên slide đầu tiên. Worksheet nhúng, `Sheet1`, chứa phạm vi nguồn sau, `A1:C4`. Hàng 3 và cột C bị ẩn, nhưng các ô của chúng vẫn chứa giá trị.

| Hàng bảng tính | A: Tháng | B: Bán lẻ | C: Bán buôn (cột ẩn) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hàng ẩn) | February | 40 | 60 |
| 4 | March | 20 | 50 |

Truy cập các ô nguồn thông qua [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) và đọc [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) để kiểm tra trạng thái ẩn của chúng. Phương thức này báo cáo trạng thái ẩn mà không thay đổi nó. Trong tệp này, B2 hiển thị, B3 thuộc hàng ẩn, và C2 thuộc cột ẩn; ví dụ in ra `False`, `True`, và `True` tương ứng.

Đối với ví dụ này, làm mới dữ liệu biểu đồ sau khi thay đổi cài đặt vẽ: giữ nguyên workbook nhúng với [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) và tải lại nó với [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream). Khi bao gồm tất cả các ô, cũng sử dụng [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) để khôi phục lại phạm vi đầy đủ, bao gồm danh mục February ẩn. Chỉ thay đổi cờ không đủ để làm mới dữ liệu biểu đồ và nhãn danh mục được lưu trong bộ nhớ đệm của mẫu này.

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

            # Làm mới dữ liệu biểu đồ từ workbook được nhúng.
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

Ví dụ này lưu hai phiên bản của bản trình diễn: một chỉ có các giá trị Bán lẻ hiển thị (`10` và `20`), và một khác với tất cả sáu giá trị. Các hình dưới minh họa hai chế độ vẽ. Hàng 3 và cột C vẫn ẩn trong cả hai workbook nhúng.

| Chỉ ô hiển thị (`True`) | Tất cả ô (`False`) |
| --- | --- |
| ![Chỉ ô hiển thị: Giá trị Bán lẻ 10 và 20 cho January và March.](hidden_cells_True.png) | ![Tất cả ô: Giá trị Bán lẻ và Bán buôn cho January, February và March.](hidden_cells_False.png) |

Một ô ẩn chứa giá trị khác với một ô trống. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) kiểm soát cách hiển thị các giá trị thiếu; nó không bao gồm hoặc loại trừ dữ liệu nguồn ẩn. Xem [Kiểm soát hiển thị các ô trống](/slides/vi/python-java/chart-series/#control-the-display-of-empty-cells) để biết ví dụ.

## **Lấy phạm vi dữ liệu của biểu đồ**

Trước khi cập nhật dữ liệu workbook trong một bản trình diễn hiện có, kiểm tra các phạm vi nguồn để xác định worksheet nào mỗi biểu đồ sử dụng. Phương thức [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) trả về phạm vi dữ liệu hiện tại dưới dạng công thức có qualifier worksheet, chẳng hạn `Sheet1!$A$1:$D$5`. Ở đây, `Sheet1` là tên worksheet, `!` ngăn cách nó với phạm vi ô, và `$A$1:$D$5` chỉ các ô từ A1 đến D5, bao gồm cả. Dấu `$` chỉ tham chiếu tuyệt đối cho hàng và cột.

Phương thức này đọc phạm vi hiện tại mà không thay đổi biểu đồ hoặc workbook của nó. Nếu biểu đồ không sử dụng workbook làm nguồn dữ liệu, nó sẽ ném `InvalidOperationException`. Để biết thêm thông tin, xem [Tham chiếu API ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/).

Ví dụ này mở một bản trình diễn và kiểm tra các hình dạng trực tiếp trên mỗi slide để tìm biểu đồ. Nó in ra tên và phạm vi nguồn của từng biểu đồ. Nếu một biểu đồ không sử dụng workbook, nó in ra thông báo và tiếp tục với biểu đồ tiếp theo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

InvalidOperationException = jpype.JClass("com.aspose.slides.exceptions.InvalidOperationException")

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                try:
                    data_range = shape.getChartData().getRange()
                    print(f"{shape.getName()}: {data_range}")
                except InvalidOperationException:
                    print(f"{shape.getName()}: The chart does not use a workbook as its data source.")
finally:
    presentation.dispose()
```

## **Đọc và ghi dữ liệu biểu đồ từ workbook**

Aspose.Slides for Python via Java cung cấp các phương thức [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) và [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) cho phép bạn đọc và ghi workbook dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã chỉnh sửa bằng Aspose.Cells). **Lưu ý** rằng dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc có cấu trúc tương tự như nguồn.

Ví dụ này sử dụng một bản trình diễn có biểu đồ là hình dạng đầu tiên trên slide đầu tiên. Nó đọc workbook nhúng vào một mảng byte, xóa các series và category hiện có, và ghi lại cùng một workbook. Các thay đổi vẫn tồn tại trong bộ nhớ; ví dụ không lưu bản trình diễn.

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

### **Xác thực bố cục biểu đồ sau khi chỉnh sửa workbook**

Khi bạn thay thế một workbook nhúng bằng một workbook đã sửa, biểu đồ giữ lại các collection series và category ban đầu. Sự không khớp này có thể khiến [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) thất bại với lỗi chỉ mục vượt ngoài phạm vi. Xóa các series và category hiện có trước khi ghi workbook đã cập nhật trở lại biểu đồ. Ví dụ này sử dụng một biểu đồ là hình dạng đầu tiên trên slide đầu tiên. Ghi chú đánh dấu nơi chỉnh sửa workbook sẽ diễn ra; ví dụ có thể chạy sẽ ghi lại workbook gốc và xác thực bố cục trong bộ nhớ.

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

        # Sửa đổi các byte workbook tại đây, ví dụ, sử dụng Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Xóa các collection loại bỏ các tham chiếu dữ liệu cũ trước khi workbook được ghi lại. Xây dựng lại bất kỳ series và ánh xạ category nào cần thiết cho workbook đã cập nhật trước khi sử dụng biểu đồ.

## **Đặt ô workbook làm nhãn dữ liệu biểu đồ**

Bạn có thể sử dụng văn bản từ các ô workbook làm nhãn dữ liệu biểu đồ.

Ví dụ này thêm một biểu đồ bubble với dữ liệu mặc định vào slide đầu tiên của một bản trình diễn hiện có. Nó sử dụng các ô A10:A12 trên worksheet 0 cho ba nhãn đầu tiên trong series đầu tiên, bật nhãn từ ô, và lưu bản trình diễn đã cập nhật.

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

## **Quản lý worksheets**

Phương thức [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) cung cấp quyền truy cập vào các worksheet trong một workbook biểu đồ. Ví dụ này tạo một biểu đồ pie với dữ liệu mặc định và in ra tên mỗi worksheet ra console.

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

## **Chỉ định loại nguồn dữ liệu**

Ví dụ này tạo một biểu đồ cột 3D với dữ liệu mặc định và đặt hai tên series bằng các nguồn dữ liệu khác nhau. Tên đầu tiên dùng một chuỗi literal; tên thứ hai dùng ô C1 trên worksheet 0. Phân loại [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) chọn nguồn cho mỗi tên. Ví dụ lưu bản trình diễn với các tên series đã cập nhật.

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

## **Phát hiện định dạng workbook nhúng không được hỗ trợ**

Aspose.Slides không hỗ trợ định dạng workbook Excel nhị phân (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng phương thức [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) trên [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) cùng với phân loại [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua những biểu đồ đó. Ví dụ này kiểm tra các hình dạng trên slide đầu tiên của một bản trình diễn hiện có, bỏ qua các hình dạng không phải biểu đồ, và in ra thông điệp chẩn đoán cho mỗi biểu đồ có workbook .xlsb nhúng.

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
        # Đọc hoặc sửa đổi dữ liệu workbook biểu đồ được hỗ trợ tại đây.
finally:
    presentation.dispose()
```

## **Workbook bên ngoài**

Aspose.Slides hỗ trợ sử dụng workbook bên ngoài làm nguồn dữ liệu cho biểu đồ.

### **Tạo một workbook bên ngoài**

Sử dụng [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) và [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) để xuất một workbook biểu đồ nhúng ra file và liên kết biểu đồ với workbook bên ngoài đó.

Ví dụ này tạo một biểu đồ pie với dữ liệu mặc định và xuất workbook của nó. Nó hoàn tất việc ghi file trước khi gán workbook bên ngoài làm nguồn dữ liệu biểu đồ, sau đó lưu bản trình diễn đã liên kết.

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

### **Đặt một workbook bên ngoài**

Sử dụng phương thức [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook), bạn có thể gán một workbook bên ngoài cho biểu đồ làm nguồn dữ liệu. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới workbook bên ngoài (nếu workbook đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các workbook được lưu trữ ở vị trí từ xa hoặc tài nguyên, bạn vẫn có thể sử dụng các workbook đó như một nguồn dữ liệu bên ngoài. Nếu đường dẫn tương đối cho workbook bên ngoài được cung cấp, nó sẽ tự động được chuyển thành đường dẫn đầy đủ.

Ví dụ này sử dụng một workbook bên ngoài có worksheet tên `Sheet1` chứa một tên series ở B1, các tên danh mục ở A2:A4, và các giá trị số ở B2:B4. Ví dụ tạo một biểu đồ pie, liên kết workbook, và sử dụng [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) để ánh xạ A1:B4 thành một series và ba danh mục. Nó lưu bản trình diễn với biểu đồ đã liên kết.

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

Tham số `updateChartData` của [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) điều khiển việc có tải workbook hay không.

* Khi `updateChartData` là `False`, chỉ đường dẫn workbook được cập nhật. Dữ liệu biểu đồ không được tải hoặc cập nhật từ workbook đích, do đó workbook có thể không khả dụng.
* Khi `updateChartData` là `True`, dữ liệu biểu đồ được cập nhật từ workbook đích.

Ví dụ sau gán một URL placeholder với `updateChartData` đặt thành `False`. Nó giữ lại dữ liệu mặc định của biểu đồ pie và lưu bản trình diễn mà không tải workbook không khả dụng.

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

### **Lấy đường dẫn workbook nguồn dữ liệu bên ngoài của một biểu đồ**

Để xác định workbook được liên kết với một biểu đồ, kiểm tra xem biểu đồ có sử dụng nguồn dữ liệu bên ngoài không và lấy đường dẫn workbook của nó.

Ví dụ này kiểm tra hình dạng đầu tiên trên slide đầu tiên của một bản trình diễn có workbook bên ngoài đã liên kết. Nếu đó là một biểu đồ được liên kết với workbook bên ngoài, ví dụ in ra [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) trên console. Sau đó nó lưu một bản sao của bản trình diễn.

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

### **Chỉnh sửa dữ liệu biểu đồ**

Bạn có thể chỉnh sửa dữ liệu trong các workbook bên ngoài cùng cách bạn thay đổi nội dung các workbook nội bộ. Khi một workbook bên ngoài không thể tải, một ngoại lệ sẽ được ném.

Ví dụ này sử dụng một biểu đồ là hình dạng đầu tiên trên slide đầu tiên và được liên kết với một workbook bên ngoài có thể truy cập. Nó đặt giá trị dựa trên ô của điểm dữ liệu đầu tiên trong series đầu tiên thành 100 và lưu bản trình diễn đã cập nhật. Việc chỉnh sửa giá trị ô có thể cập nhật file XLSX bên ngoài đã liên kết, vì vậy hãy sử dụng một bản sao nếu bạn cần bảo toàn workbook gốc.

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

### **Khôi phục workbook từ bộ nhớ đệm biểu đồ**

Nếu một biểu đồ sử dụng một workbook bên ngoài bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo workbook biểu đồ từ dữ liệu đã được lưu trong bộ nhớ đệm của bản trình diễn. Tạo [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/), gọi [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions), và đặt [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) thành `True` trước khi mở bản trình diễn.

Ví dụ Python sau khôi phục dữ liệu workbook cho một biểu đồ là hình dạng đầu tiên trên slide đầu tiên và tham chiếu đến một workbook bên ngoài không khả dụng. Nó truy cập dữ liệu đã khôi phục qua [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) và [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

        # Đọc hoặc chỉnh sửa dữ liệu workbook đã khôi phục ở đây.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Nếu workbook bên ngoài không khả dụng và chế độ khôi phục bị tắt, Aspose.Slides sẽ ném một ngoại lệ. Chỉ bật chế độ khôi phục khi việc sử dụng dữ liệu biểu đồ đã lưu trong bộ nhớ đệm là một phương án chấp nhận được, vì bộ nhớ đệm có thể không chứa các thay đổi đã được thực hiện trên workbook bên ngoài sau khi bản trình diễn được cập nhật lần cuối.

## **FAQ**

**Tôi có thể xác định được một biểu đồ cụ thể có liên kết tới workbook bên ngoài hay nhúng không?**

Có. Một biểu đồ có [loại nguồn dữ liệu](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) và một [đường dẫn tới workbook bên ngoài](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); nếu nguồn là workbook bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn một tệp bên ngoài đang được sử dụng.

**Đường dẫn tương đối tới workbook bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Bản trình diễn lưu đường dẫn tuyệt đối trong tệp PPTX, vì vậy việc di chuyển workbook có thể yêu cầu cập nhật liên kết.

**Tôi có thể sử dụng các workbook nằm trên các tài nguyên/mạng chia sẻ không?**

Có, các workbook như vậy có thể được sử dụng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa trực tiếp các workbook từ xa bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè file XLSX bên ngoài khi lưu bản trình diễn không?**

Bản trình diễn lưu một [liên kết tới file bên ngoài](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Việc chỉnh sửa dữ liệu biểu đồ dựa trên ô cũng có thể cập nhật file XLSX địa phương đã liên kết. Hãy sử dụng một bản sao của workbook nếu bản gốc phải được giữ nguyên.

**Nếu tệp bên ngoài được bảo vệ bằng mật khẩu, tôi nên làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách tiếp cận chung là loại bỏ bảo vệ trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, bằng cách sử dụng [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu tới cùng một workbook bên ngoài không?**

Có. Mỗi biểu đồ lưu liên kết riêng của mình. Nếu tất cả chúng trỏ tới cùng một tệp, việc cập nhật tệp đó sẽ được phản ánh trong mỗi biểu đồ khi dữ liệu được tải lại.