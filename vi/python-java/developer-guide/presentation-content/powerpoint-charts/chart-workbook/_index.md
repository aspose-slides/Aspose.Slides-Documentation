---
title: Quản lý sổ làm việc biểu đồ trong bản trình bày bằng Python qua Java
linktitle: Sổ làm việc biểu đồ
type: docs
weight: 70
url: /vi/python-java/chart-workbook/
keywords:
- sổ làm việc biểu đồ
- dữ liệu biểu đồ
- ô sổ làm việc
- nhãn dữ liệu
- bảng tính
- nguồn dữ liệu
- sổ làm việc bên ngoài
- dữ liệu bên ngoài
- bộ nhớ đệm biểu đồ
- khôi phục sổ làm việc
- PowerPoint
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Khám phá Aspose.Slides cho Python qua Java: quản lý sổ làm việc biểu đồ trong định dạng PowerPoint và OpenDocument một cách dễ dàng để tối ưu hóa dữ liệu bản trình bày của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sổ làm việc biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua luồng sổ làm việc, sử dụng các ô sổ làm việc làm nhãn dữ liệu biểu đồ, truy cập bộ sưu tập worksheet và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng bao gồm việc làm việc với sổ làm việc bên ngoài làm nguồn dữ liệu biểu đồ. Các ví dụ minh họa cách tạo và gán một sổ làm việc bên ngoài, lấy đường dẫn của sổ làm việc bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi sổ làm việc có sẵn.

Đối với các ô sổ làm việc đại diện cho dữ liệu thiếu, xem [Control the Display of Empty Cells](/slides/vi/python-java/chart-series/) để biết sự khác biệt giữa ô trống và số 0, cũng như so sánh biểu đồ đường của các chế độ hiển thị khả dụng.

## **Bao gồm dữ liệu từ các hàng và cột ẩn**

Sử dụng [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) để kiểm soát việc biểu đồ chỉ vẽ dữ liệu từ các hàng và cột worksheet ẩn hay không. Đặt giá trị `True` để chỉ vẽ các ô hiển thị, hoặc `False` để bao gồm cả ô hiển thị và ô ẩn. Cài đặt này chỉ điều khiển việc vẽ biểu đồ; nó không ẩn hoặc hiện các hàng hoặc cột worksheet.

[Sample presentation](hidden-source-data.pptx) chứa một biểu đồ cột làm hình dạng đầu tiên trên slide đầu tiên. Worksheet nhúng, `Sheet1`, có phạm vi nguồn sau: `A1:C4`. Hàng 3 và cột C bị ẩn, nhưng các ô của chúng vẫn chứa giá trị.

| Hàng worksheet | A: Tháng | B: Bán lẻ | C: Bán buôn (cột ẩn) |
| --- | --- | --- | --- |
| 2 | Tháng 1 | 10 | 30 |
| 3 (hàng ẩn) | Tháng 2 | 40 | 60 |
| 4 | Tháng 3 | 20 | 50 |

Truy cập các ô nguồn qua [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) và đọc [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) để kiểm tra trạng thái ẩn của chúng. Phương thức này trả về trạng thái ẩn mà không thay đổi nó. Trong tệp này, B2 hiển thị, B3 thuộc hàng ẩn, và C2 thuộc cột ẩn; ví dụ in ra `False`, `True`, và `True` tương ứng.

Đối với ví dụ này, làm mới dữ liệu biểu đồ sau khi thay đổi cài đặt vẽ: giữ sổ làm việc nhúng bằng [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) và tải lại bằng [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream). Khi bao gồm tất cả các ô, cũng sử dụng [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) để khôi phục phạm vi đầy đủ, bao gồm danh mục tháng 2 ẩn. Chỉ thay đổi cờ không đủ để làm mới dữ liệu biểu đồ và nhãn danh mục đã được lưu trong bộ nhớ đệm của mẫu này.

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

            # Làm mới dữ liệu biểu đồ từ sổ làm việc nhúng.
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

Ví dụ lưu hai phiên bản của bản trình bày: một chỉ có các giá trị Bán lẻ hiển thị (10 và 20), và một có tất cả sáu giá trị. Các hình ảnh bên dưới minh họa hai chế độ vẽ. Hàng 3 và cột C vẫn ẩn trong cả hai sổ làm việc nhúng.

| Chỉ các ô hiển thị (`True`) | Tất cả các ô (`False`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

Một ô ẩn chứa giá trị khác với một ô trống. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) kiểm soát cách hiển thị các giá trị thiếu; nó không bao gồm hoặc loại trừ dữ liệu nguồn ẩn. Xem [Control the Display of Empty Cells](/slides/vi/python-java/chart-series/#control-the-display-of-empty-cells) để biết ví dụ.

## **Lấy phạm vi dữ liệu của biểu đồ**

Trước khi cập nhật dữ liệu sổ làm việc trong một bản trình bày hiện có, kiểm tra các phạm vi nguồn để xác định ô worksheet nào mỗi biểu đồ sử dụng. Phương thức [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) trả về phạm vi dữ liệu hiện tại dưới dạng công thức có chỉ định worksheet, ví dụ `Sheet1!$A$1:$D$5`. Ở đây, `Sheet1` là tên worksheet, `!` ngăn cách nó với phạm vi ô, và `$A$1:$D$5` xác định các ô A1 tới D5, bao gồm cả giá trị tuyệt đối.

Phương thức này đọc phạm vi hiện tại mà không thay đổi biểu đồ hoặc sổ làm việc của nó. Nếu biểu đồ không sử dụng sổ làm việc làm nguồn dữ liệu, nó sẽ ném `InvalidOperationException`. Để biết thêm thông tin, xem [ChartData API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/).

Ví dụ này mở một bản trình bày và kiểm tra các hình dạng trực tiếp trên mỗi slide để tìm biểu đồ. Nó in ra tên và phạm vi nguồn của mỗi biểu đồ. Nếu một biểu đồ không sử dụng sổ làm việc, nó in thông báo và tiếp tục với biểu đồ tiếp theo.

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

## **Đọc và ghi dữ liệu biểu đồ từ sổ làm việc**

Aspose.Slides for Python via Java cung cấp các phương thức [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) và [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) cho phép bạn đọc và ghi sổ làm việc dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã chỉnh sửa bằng Aspose.Cells). **Lưu ý** rằng dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc phải có cấu trúc tương tự như nguồn.

Ví dụ này sử dụng một bản trình bày có biểu đồ làm hình dạng đầu tiên trên slide đầu tiên. Nó đọc sổ làm việc nhúng vào một mảng byte, xóa các series và categories hiện có, và ghi lại cùng một sổ làm việc. Các thay đổi chỉ tồn tại trong bộ nhớ; ví dụ không lưu bản trình bày.

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

### **Xác thực bố cục biểu đồ sau khi chỉnh sửa sổ làm việc**

Khi bạn thay thế sổ làm việc nhúng bằng một sổ đã chỉnh sửa, biểu đồ vẫn giữ các bộ sưu tập series và category gốc. Sự không khớp này có thể gây lỗi [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) do lỗi chỉ mục ngoài phạm vi. Xóa các series và categories hiện có trước khi ghi sổ làm việc đã cập nhật trở lại biểu đồ. Ví dụ này sử dụng một biểu đồ là hình dạng đầu tiên trên slide đầu tiên. Chú thích đánh dấu nơi sẽ chỉnh sửa sổ làm việc; ví dụ chạy được ghi lại sổ làm việc gốc và xác thực bố cục trong bộ nhớ.

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

        # Sửa đổi byte của sổ làm việc ở đây, ví dụ, sử dụng Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Xóa các bộ sưu tập sẽ loại bỏ các tham chiếu dữ liệu cũ trước khi sổ làm việc được ghi lại. Tái tạo bất kỳ series và ánh xạ category cần thiết cho sổ làm việc đã cập nhật trước khi sử dụng biểu đồ.

## **Đặt định dạng số tùy chỉnh cho các ô trong sổ làm việc**

Sử dụng [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) để kiểm soát cách các giá trị số hiển thị trong sổ làm việc nhúng của biểu đồ. Ví dụ, một báo cáo có thể cần hiển thị tỷ lệ chuyển đổi dưới dạng phần trăm với bốn chữ số thập phân và hệ số với năm chữ số thập phân. Giữ cả hai giá trị ở dạng số để chúng vẫn có thể được sử dụng trong tính toán và vẽ biểu đồ.

Định dạng số chỉ thay đổi cách hiển thị, không thay đổi giá trị lưu trữ. Định dạng `0.0000%` hiển thị `0.125` thành `12.5000%`; nó không thay thế số lưu trữ bằng `12.5`. Tương tự, `0.00000` hiển thị `0.1234567` thành `0.12346` mà không làm tròn giá trị lưu trữ. Nếu định dạng tùy chỉnh là chuỗi rỗng (`""`), định dạng trả về bởi [getPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getPresetNumberFormat) sẽ được sử dụng thay thế.

Ví dụ sau tạo một biểu đồ cột và truy cập các ô của nó qua [getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook). Trên worksheet 0, B2 chứa tỷ lệ chuyển đổi và C2 chứa hệ số. Cả hai ô cung cấp giá trị cho biểu đồ. Ví dụ cũng bật nhãn giá trị được liên kết với định dạng nguồn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210)
    chart.setTitle(False)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00")
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(0)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A2", "Sample")
    chart.getChartData().getCategories().add(category_cell)

    percentage_cell = workbook.getCell(0, "B2", jpype.JDouble(0.125))
    percentage_cell.setCustomNumberFormat("0.0000%")
    percentage_name = workbook.getCell(0, "B1", "Conversion rate")
    percentage_series = chart.getChartData().getSeries().add(percentage_name, chart.getType())
    percentage_series.getDataPoints().addDataPointForBarSeries(percentage_cell)

    precision_cell = workbook.getCell(0, "C2", jpype.JDouble(0.1234567))
    precision_cell.setCustomNumberFormat("0.00000")
    precision_name = workbook.getCell(0, "C1", "Coefficient")
    precision_series = chart.getChartData().getSeries().add(precision_name, chart.getType())
    precision_series.getDataPoints().addDataPointForBarSeries(precision_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(True)

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Định dạng ô sổ làm việc tách biệt khỏi các định dạng được đặt trực tiếp trên trục biểu đồ hoặc nhãn dữ liệu. Trong ví dụ này, mỗi nhãn hiển thị giá trị ô nguồn vì [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) được đặt thành `True`, và tuân theo định dạng số nguồn vì [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) được đặt thành `True`. Sau khi lưu và mở lại bản trình bày, các nhãn hiển thị `12.5000%` và `0.12346`, như hình dưới. Trục tung sử dụng định dạng số riêng, được gán bằng [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) là `0.00`, với [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) đặt là `False`.

Để định dạng một nhãn dữ liệu một cách độc lập, đặt cờ liên kết nguồn của nó thành `False` và gán định dạng bằng [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat). Điều này không thay đổi định dạng của ô sổ làm việc. Ví dụ, định dạng nhãn độc lập `0.00` hiển thị giá trị đầu tiên là `0.13`, trong khi B2 vẫn hiển thị `12.5000%`. Xem [Chart Data Labels](/slides/vi/python-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) để biết cách định dạng nhãn trực tiếp.

Hình ảnh dưới được tạo từ bản trình bày đã lưu sau khi mở lại:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **Đặt một ô sổ làm việc làm nhãn dữ liệu biểu đồ**

Bạn có thể sử dụng văn bản từ các ô sổ làm việc làm nhãn dữ liệu biểu đồ.

Ví dụ này thêm một biểu đồ bong bóng với dữ liệu mặc định vào slide đầu tiên của một bản trình bày hiện có. Nó sử dụng các ô A10:A12 trên worksheet 0 cho ba nhãn đầu tiên trong series đầu tiên, bật nhãn từ ô và lưu bản trình bày đã cập nhật.

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

## **Quản lý các worksheet**

Phương thức [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) cung cấp quyền truy cập vào các worksheet trong một sổ làm việc biểu đồ. Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và in tên mỗi worksheet ra console.

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

## **Xác định loại nguồn dữ liệu**

Ví dụ này tạo một biểu đồ cột 3D với dữ liệu mặc định và đặt hai tên series bằng các nguồn dữ liệu khác nhau. Tên đầu tiên dùng literal chuỗi; tên thứ hai dùng ô C1 trên worksheet 0. Phân loại [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) chọn nguồn cho mỗi tên. Ví dụ lưu bản trình bày với các tên series đã cập nhật.

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

## **Phát hiện các định dạng sổ làm việc nhúng không được hỗ trợ**

Aspose.Slides không hỗ trợ định dạng sổ làm việc Excel nhị phân (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng phương thức [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) trên [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) kết hợp với enumeration [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua các biểu đồ đó. Ví dụ này kiểm tra các hình dạng trên slide đầu tiên của một bản trình bày hiện có, bỏ qua các hình không phải biểu đồ, và in thông điệp chuẩn đoán cho mỗi biểu đồ có sổ làm việc .xlsb nhúng.

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
        # Đọc hoặc chỉnh sửa dữ liệu sổ làm việc biểu đồ được hỗ trợ ở đây.
finally:
    presentation.dispose()
```

## **Sổ làm việc bên ngoài**

Aspose.Slides hỗ trợ sử dụng sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ.

### **Tạo sổ làm việc bên ngoài**

Sử dụng [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) và [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) để xuất sổ làm việc biểu đồ nhúng ra file và liên kết biểu đồ tới sổ làm việc bên ngoài đó.

Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và xuất sổ làm việc của nó. Nó hoàn thành việc ghi file trước khi gán sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ, sau đó lưu bản trình bày đã liên kết.

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

### **Đặt sổ làm việc bên ngoài**

Bằng cách sử dụng phương thức [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook), bạn có thể gán một sổ làm việc bên ngoài cho biểu đồ làm nguồn dữ liệu. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới sổ làm việc bên ngoài (nếu tệp đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các sổ làm việc được lưu ở vị trí từ xa hoặc tài nguyên, bạn vẫn có thể sử dụng các sổ này làm nguồn dữ liệu bên ngoài. Nếu đường dẫn tương đối cho sổ làm việc bên ngoài được cung cấp, nó sẽ tự động chuyển thành đường dẫn đầy đủ.

Ví dụ này sử dụng một sổ làm việc bên ngoài có worksheet tên `Sheet1` chứa tên series ở B1, tên danh mục ở A2:A4, và các giá trị số ở B2:B4. Ví dụ tạo một biểu đồ tròn, liên kết sổ làm việc, và sử dụng [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) để ánh xạ A1:B4 thành một series và ba danh mục. Nó lưu bản trình bày với biểu đồ đã liên kết.

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

Tham số `updateChartData` của [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) kiểm soát việc có tải sổ làm việc hay không.

* Khi `updateChartData` là `False`, chỉ đường dẫn sổ làm việc được cập nhật. Dữ liệu biểu đồ không được tải hoặc cập nhật từ sổ làm việc mục tiêu, vì vậy sổ làm việc có thể không khả dụng.
* Khi `updateChartData` là `True`, dữ liệu biểu đồ được cập nhật từ sổ làm việc mục tiêu.

Ví dụ sau gán một URL placeholder với `updateChartData` đặt thành `False`. Nó giữ dữ liệu mặc định của biểu đồ tròn và lưu bản trình bày mà không tải sổ làm việc không khả dụng.

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

### **Lấy đường dẫn sổ làm việc nguồn dữ liệu bên ngoài của một biểu đồ**

Để xác định sổ làm việc được liên kết với một biểu đồ, kiểm tra xem biểu đồ có sử dụng nguồn dữ liệu bên ngoài không và lấy đường dẫn sổ làm việc của nó.

Ví dụ này kiểm tra hình dạng đầu tiên trên slide đầu tiên của một bản trình bày có sổ làm việc bên ngoài đã liên kết. Nếu đó là một biểu đồ được liên kết với sổ làm việc bên ngoài, ví dụ in [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) ra console. Sau đó nó lưu một bản sao của bản trình bày.

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

Bạn có thể chỉnh sửa dữ liệu trong các sổ làm việc bên ngoài tương tự như cách bạn thay đổi nội dung của sổ làm việc nội bộ. Khi một sổ làm việc bên ngoài không thể tải, một ngoại lệ sẽ được ném.

Ví dụ này sử dụng một biểu đồ là hình dạng đầu tiên trên slide đầu tiên và được liên kết với một sổ làm việc bên ngoài có thể truy cập. Nó đặt giá trị dựa trên ô của điểm dữ liệu đầu tiên trong series đầu tiên thành 100 và lưu bản trình bày đã cập nhật. Việc chỉnh sửa giá trị ô có thể cập nhật tệp XLSX bên ngoài được liên kết, vì vậy hãy sử dụng bản sao nếu bạn cần bảo toàn sổ làm việc gốc.

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

### **Khôi phục sổ làm việc từ bộ nhớ đệm của biểu đồ**

Nếu một biểu đồ sử dụng sổ làm việc bên ngoài bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo sổ làm việc biểu đồ từ dữ liệu đã lưu trong bộ nhớ đệm của bản trình bày. Tạo [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/), gọi [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions), và đặt [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) thành `True` trước khi mở bản trình bày.

Ví dụ Python sau khôi phục dữ liệu sổ làm việc cho một biểu đồ là hình dạng đầu tiên trên slide đầu tiên và tham chiếu tới một sổ làm việc bên ngoài không khả dụng. Nó truy cập dữ liệu đã khôi phục qua [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) và [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

        # Đọc hoặc chỉnh sửa dữ liệu sổ làm việc đã khôi phục ở đây.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Nếu sổ làm việc bên ngoài không khả dụng và việc khôi phục bị tắt, Aspose.Slides sẽ ném ngoại lệ. Chỉ bật khôi phục khi việc sử dụng dữ liệu biểu đồ đã lưu trong bộ nhớ đệm là một giải pháp chấp nhận được, vì bộ nhớ đệm có thể không chứa các thay đổi đã thực hiện đối với sổ làm việc bên ngoài sau khi bản trình bày được cập nhật lần cuối.

## **Câu hỏi thường gặp**

**Tôi có thể xác định liệu một biểu đồ cụ thể có được liên kết tới sổ làm việc bên ngoài hay sổ làm việc nhúng không?**

Có. Một biểu đồ có [data source type](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) và một [path to an external workbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); nếu nguồn là sổ làm việc bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp bên ngoài đang được sử dụng.

**Các đường dẫn tương đối tới sổ làm việc bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động chuyển thành đường dẫn tuyệt đối. Bản trình bày lưu đường dẫn tuyệt đối trong tệp PPTX, vì vậy việc di chuyển sổ làm việc có thể yêu cầu cập nhật liên kết.

**Tôi có thể sử dụng sổ làm việc nằm trên tài nguyên/chia sẻ mạng không?**

Có, các sổ làm việc như vậy có thể được sử dụng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa trực tiếp các sổ làm việc từ xa bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè lên file XLSX bên ngoài khi lưu bản trình bày không?**

Bản trình bày lưu một [link to the external file](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Việc chỉnh sửa dữ liệu biểu đồ dựa trên ô cũng có thể cập nhật tệp XLSX địa phương được liên kết. Hãy sử dụng bản sao của sổ làm việc nếu bạn muốn giữ nguyên tập tin gốc.

**Nếu file bên ngoài được bảo vệ bằng mật khẩu, tôi nên làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách phổ biến là loại bỏ bảo vệ trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, bằng cách sử dụng [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một sổ làm việc bên ngoài không?**

Có. Mỗi biểu đồ lưu liên kết riêng của mình. Nếu chúng đều trỏ tới cùng một tệp, việc cập nhật tệp đó sẽ được phản ánh trong mỗi biểu đồ lần tiếp theo dữ liệu được tải.