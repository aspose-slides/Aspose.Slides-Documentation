---
title: Quản lý Sổ làm việc Biểu đồ trong Bài thuyết trình với Python
linktitle: Sổ làm việc Biểu đồ
type: docs
weight: 70
url: /vi/python-net/chart-workbook/
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
- phục hồi sổ làm việc
- PowerPoint
- bài thuyết trình
- Python
- Aspose.Slides
description: "Khám phá Aspose.Slides cho Python qua .NET: quản lý sổ làm việc biểu đồ trong các định dạng PowerPoint và OpenDocument một cách dễ dàng để tối ưu hóa dữ liệu bài thuyết trình của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sổ làm việc biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua luồng sổ làm việc, sử dụng các ô sổ làm việc làm nhãn dữ liệu biểu đồ, truy cập các bộ sưu tập bảng tính, và chỉ định kiểu nguồn dữ liệu cho các giá trị biểu đồ.

Cũng bao gồm việc làm việc với sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một sổ làm việc bên ngoài, lấy đường dẫn của sổ làm việc bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi sổ làm việc có sẵn.

Đối với các ô sổ làm việc đại diện cho dữ liệu thiếu, xem [Kiểm soát việc hiển thị các ô trống](/slides/vi/python-net/chart-series/) để biết sự khác nhau giữa ô trống và số 0, và so sánh biểu đồ đường của các chế độ hiển thị có sẵn.

## **Bao gồm dữ liệu từ các hàng và cột ẩn**

Sử dụng [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) để kiểm soát liệu biểu đồ có vẽ dữ liệu từ các hàng và cột bảng tính ẩn hay không. Đặt thành `True` để chỉ vẽ các ô hiển thị, hoặc `False` để bao gồm cả các ô hiển thị và ẩn. Cài đặt này chỉ kiểm soát việc vẽ biểu đồ; nó không ẩn hoặc hiện lại các hàng hoặc cột bảng tính.

Tải xuống [hidden-source-data.pptx](hidden-source-data.pptx) và đặt nó trong thư mục làm việc. Trang đầu tiên của nó chứa một biểu đồ cột là hình dạng đầu tiên. Bảng tính nhúng, `Sheet1`, chứa phạm vi nguồn sau, `A1:C4`. Hàng 3 và cột C bị ẩn, nhưng các ô của chúng vẫn chứa giá trị.

| Hàng bảng tính | A: Tháng | B: Bán lẻ | C: Bán buôn (cột ẩn) |
| --- | --- | --- | --- |
| 2 | Tháng 1 | 10 | 30 |
| 3 (hàng ẩn) | Tháng 2 | 40 | 60 |
| 4 | Tháng 3 | 20 | 50 |

Truy cập các ô nguồn qua [ChartData.chart_data_workbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) và đọc [ChartDataCell.is_hidden](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatacell/is_hidden/) để kiểm tra trạng thái ẩn của chúng. Thuộc tính này chỉ đọc. Trong tệp này, B2 hiển thị, B3 thuộc hàng ẩn, và C2 thuộc cột ẩn; ví dụ in ra `False`, `True`, và `True` tương ứng.

Đối với ví dụ này, làm mới dữ liệu biểu đồ sau khi thay đổi cài đặt vẽ: giữ lại sổ làm việc nhúng bằng [read_workbook_stream](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) và tải lại bằng [write_workbook_stream](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). Khi bao gồm tất cả các ô, cũng sử dụng [set_range](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/set_range/) để khôi phục phạm vi đầy đủ, bao gồm danh mục tháng 2 ẩn. Chỉ thay đổi cờ không đủ để làm mới dữ liệu biểu đồ và nhãn danh mục đã được lưu trong bộ nhớ đệm của mẫu này.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("hidden-source-data.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        workbook = chart.chart_data.chart_data_workbook
        print(f"B2 hidden: {workbook.get_cell(0, 'B2').is_hidden}")
        print(f"B3 hidden: {workbook.get_cell(0, 'B3').is_hidden}")
        print(f"C2 hidden: {workbook.get_cell(0, 'C2').is_hidden}")

        workbook_stream = chart.chart_data.read_workbook_stream()
        for visible_only in [True, False]:
            chart.plot_visible_cells_only = visible_only

            # Làm mới dữ liệu biểu đồ từ sổ làm việc nhúng.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Khôi phục phạm vi nguồn đầy đủ, bao gồm các danh mục ẩn.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

Ví dụ lưu `hidden_cells_True.pptx` chỉ với các giá trị Bán lẻ hiển thị (10 và 20), và `hidden_cells_False.pptx` với tất cả sáu giá trị. Các hình ảnh dưới đây được tạo từ các bản trình chiếu đã lưu sau khi mở lại; cả hai tệp đều giữ cài đặt vẽ đã chỉ định. Hàng 3 và cột C vẫn ẩn trong cả hai sổ làm việc nhúng.

| Chỉ các ô hiển thị (`True`) | Tất cả các ô (`False`) |
| --- | --- |
| ![Chỉ các ô hiển thị: Giá trị Bán lẻ 10 và 20 cho Tháng 1 và Tháng 3.](hidden_cells_True.png) | ![Tất cả các ô: Giá trị Bán lẻ và Bán buôn cho Tháng 1, Tháng 2 và Tháng 3.](hidden_cells_False.png) |

Một ô ẩn chứa giá trị khác với một ô trống. [Chart.display_blanks_as](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/display_blanks_as/) kiểm soát cách hiển thị các giá trị thiếu; nó không bao gồm hay loại trừ dữ liệu nguồn ẩn. Xem [Kiểm soát việc hiển thị các ô trống](/slides/vi/python-net/chart-series/#control-the-display-of-empty-cells) để biết ví dụ.

## **Đọc và Ghi Dữ liệu Biểu đồ từ Sổ làm việc**

Aspose.Slides for Python via .NET cung cấp các phương thức [read_workbook_stream](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) và [write_workbook_stream](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) cho phép bạn đọc và ghi sổ làm việc dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã chỉnh sửa bằng Aspose.Cells). **Lưu ý** rằng dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc phải có cấu trúc tương tự nguồn.

Ví dụ này mở `chart.pptx`, phải chứa một biểu đồ làm hình dạng đầu tiên trên slide đầu tiên. Nó đọc sổ làm việc nhúng vào một luồng, xóa các chuỗi và danh mục hiện có, và ghi lại sổ làm việc cùng đó. Các thay đổi vẫn ở trong bộ nhớ; ví dụ không lưu bản trình chiếu.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
    else:
        print("The first shape is not a chart.")
```

### **Xác thực Bố cục Biểu đồ Sau Khi Sửa Đổi Sổ làm việc**

Khi bạn thay thế sổ làm việc nhúng bằng một phiên bản đã sửa đổi, biểu đồ vẫn giữ các bộ sưu tập chuỗi và danh mục gốc. Sự không khớp này có thể gây lỗi cho [Chart.validate_chart_layout](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/validate_chart_layout/) với lỗi chỉ mục ngoài phạm vi. Hãy xóa các chuỗi và danh mục hiện có trước khi ghi sổ làm việc đã cập nhật trở lại biểu đồ. Ví dụ này yêu cầu `chart.pptx` có một biểu đồ làm hình dạng đầu tiên trên slide đầu tiên. Các chú thích chỉ ra vị trí sửa đổi sổ làm việc; ví dụ có thể chạy sẽ ghi lại sổ làm việc gốc và xác thực bố cục trong bộ nhớ.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Sửa đổi luồng sổ làm việc tại đây, ví dụ, sử dụng Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Xóa các bộ sưu tập sẽ loại bỏ các tham chiếu dữ liệu cũ trước khi sổ làm việc được ghi lại. Hãy xây dựng lại bất kỳ ánh xạ chuỗi và danh mục nào cần thiết cho sổ làm việc đã cập nhật trước khi sử dụng biểu đồ.

## **Đặt một Ô Sổ làm việc làm Nhãn Dữ liệu Biểu đồ**

Bạn có thể sử dụng văn bản từ các ô sổ làm việc làm nhãn dữ liệu cho biểu đồ. Các bước sau cho thấy cách liên kết nhãn trong biểu đồ bong bóng với các ô trong sổ dữ liệu của nó.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
2. Truy cập slide đầu tiên bằng chỉ mục bắt đầu từ 0.
3. Thêm một biểu đồ bong bóng với dữ liệu mặc định.
4. Truy cập chuỗi biểu đồ.
5. Đặt ô sổ làm việc làm nhãn dữ liệu.
6. Lưu bản trình chiếu.

Ví dụ này mở `chart2.pptx`, phải có ít nhất một slide, và thêm một biểu đồ bong bóng với dữ liệu mặc định. Nó sử dụng các ô A10:A12 trên worksheet 0 cho ba nhãn đầu tiên trong chuỗi đầu tiên, bật nhãn từ ô, và lưu kết quả vào `resultchart.pptx`.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart2.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    workbook = chart.chart_data.chart_data_workbook

    series.labels.default_data_label_format.show_label_value_from_cell = True
    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0 cell value")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1 cell value")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2 cell value")

    presentation.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **Quản lý Các Bảng tính**

Thuộc tính [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) cung cấp quyền truy cập vào các bảng tính trong một sổ làm việc biểu đồ. Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và in tên mỗi bảng tính ra console.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
    workbook = chart.chart_data.chart_data_workbook

    for worksheet in workbook.worksheets:
        print(worksheet.name)
```

## **Chỉ định Kiểu Nguồn Dữ liệu**

Ví dụ này tạo một biểu đồ cột 3D với dữ liệu mặc định và đặt hai tên chuỗi bằng cách sử dụng các nguồn dữ liệu khác nhau. Tên đầu tiên sử dụng một chuỗi literal; tên thứ hai sử dụng ô C1 trên worksheet 0. Phân loại [DataSourceType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/datasourcetype/) chọn nguồn cho mỗi tên. Kết quả được lưu vào `pres.pptx`.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    literal_name = chart.chart_data.series[0].name

    literal_name.data_source_type = charts.DataSourceType.STRING_LITERALS
    literal_name.data = "LiteralString"

    cell_name = chart.chart_data.series[1].name
    name_cell = chart.chart_data.chart_data_workbook.get_cell(0, "C1", "NewCell")
    cell_name.data_source_type = charts.DataSourceType.WORKSHEET
    cell_name.data = name_cell

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Phát hiện Định dạng Sổ làm việc Nhúng Không được Hỗ trợ**

Aspose.Slides không hỗ trợ định dạng sổ làm việc Excel nhị phân (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng thuộc tính [embedded_workbook_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) trên [ChartData](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/) cùng với phân loại [WorkbookType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/workbooktype/) để phát hiện các định dạng không hỗ trợ và bỏ qua các biểu đồ đó. Ví dụ này kiểm tra các hình dạng trên slide đầu tiên của `sample.pptx`, bỏ qua các hình không phải biểu đồ, và in thông báo chẩn đoán cho mỗi biểu đồ có sổ làm việc .xlsb nhúng.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart_data = shape.chart_data
        is_internal_workbook = chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK
        is_binary_macro = chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue

        # Đọc hoặc sửa đổi dữ liệu sổ làm việc biểu đồ được hỗ trợ tại đây.
```

## **Sổ làm việc Bên ngoài**

Aspose.Slides hỗ trợ sử dụng sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ.

### **Tạo một Sổ làm việc Bên ngoài**

Sử dụng [read_workbook_stream](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) và [set_external_workbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/set_external_workbook/) để xuất sổ làm việc biểu đồ nhúng ra một tệp và liên kết biểu đồ với sổ làm việc bên ngoài đó.

Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định, ghi sổ làm việc của nó vào `externalWorkbook1.xlsx`, và đóng luồng đầu ra trước khi gán tệp làm nguồn dữ liệu cho biểu đồ. Nó lưu bản trình chiếu đã liên kết vào `externalWorkbook.pptx`.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)
    workbook_path = str(Path("externalWorkbook1.xlsx").resolve())

    workbook_stream = chart.chart_data.read_workbook_stream()
    workbook_data = workbook_stream.read()
    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    chart.chart_data.set_external_workbook(workbook_path)
    presentation.save("externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

### **Đặt một Sổ làm việc Bên ngoài**

Sử dụng phương thức [set_external_workbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/set_external_workbook/), bạn có thể gán một sổ làm việc bên ngoài cho biểu đồ như nguồn dữ liệu của nó. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới sổ làm việc bên ngoài (nếu sổ đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các sổ làm việc lưu trữ ở vị trí hoặc tài nguyên từ xa, bạn vẫn có thể sử dụng các sổ đó làm nguồn dữ liệu bên ngoài. Nếu cung cấp đường dẫn tương đối cho sổ làm việc bên ngoài, nó sẽ tự động được chuyển sang đường dẫn đầy đủ.

Ví dụ này yêu cầu `externalWorkbook.xlsx` trong thư mục làm việc. Bảng tính có tên `Sheet1` phải chứa một tên chuỗi ở B1, các tên danh mục trong A2:A4, và các giá trị số trong B2:B4. Ví dụ tạo một biểu đồ tròn, liên kết sổ làm việc, và sử dụng [set_range](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/set_range/) để ánh xạ A1:B4 thành một chuỗi và ba danh mục. Nó lưu kết quả vào `Presentation_with_externalWorkbook.pptx`.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart_data = chart.chart_data
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())

    chart_data.set_external_workbook(workbook_path)
    chart_data.set_range("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

Tham số `update_chart_data` của [set_external_workbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/set_external_workbook/) kiểm soát việc có tải sổ làm việc hay không.

* Khi `update_chart_data` là `False`, chỉ đường dẫn sổ làm việc được cập nhật. Dữ liệu biểu đồ không được tải hoặc cập nhật từ sổ làm việc đích, vì vậy sổ làm việc có thể không khả dụng.
* Khi `update_chart_data` là `True`, dữ liệu biểu đồ được cập nhật từ sổ làm việc đích.

Ví dụ sau gán một URL placeholder với `update_chart_data` đặt thành `False`. Nó giữ dữ liệu mặc định của biểu đồ tròn và lưu bản trình chiếu mà không tải sổ làm việc không khả dụng.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)

    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Lấy Đường dẫn Sổ làm việc Nguồn Dữ liệu Bên ngoài của một Biểu đồ**

Để xác định sổ làm việc được liên kết với một biểu đồ, trước tiên kiểm tra xem biểu đồ có sử dụng nguồn dữ liệu bên ngoài hay không. Nếu có, bạn có thể lấy đường dẫn sổ làm việc bằng cách làm theo các bước sau.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Truy cập slide đầu tiên bằng chỉ mục bắt đầu từ 0.
3. Kiểm tra hình dạng đầu tiên có phải là biểu đồ không.
4. Đọc loại nguồn dữ liệu của biểu đồ.
5. Nếu nguồn là một sổ làm việc bên ngoài, đọc đường dẫn của nó.

Ví dụ này mở `externalWorkbook.pptx`, được tạo trong ví dụ trước, và kiểm tra hình dạng đầu tiên trên slide đầu tiên. Nếu đó là một biểu đồ được liên kết với sổ làm việc bên ngoài, ví dụ sẽ in [external_workbook_path](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/external_workbook_path/) ra console. Sau đó nó lưu một bản sao của bản trình chiếu vào `Result.pptx`.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("externalWorkbook.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        if chart_data.data_source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
            print(chart_data.external_workbook_path)
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

### **Chỉnh sửa Dữ liệu Biểu đồ**

Bạn có thể chỉnh sửa dữ liệu trong sổ làm việc bên ngoài tương tự như việc thay đổi nội dung của sổ làm việc nội bộ. Khi không tải được sổ làm việc bên ngoại, một ngoại lệ sẽ được ném.

Ví dụ này yêu cầu `presentation.pptx` có một biểu đồ làm hình dạng đầu tiên trên slide đầu tiên và một sổ làm việc bên ngoài có thể truy cập. Nó đặt giá trị dựa trên ô của điểm dữ liệu đầu tiên trong chuỗi đầu tiên thành 100 và lưu bản trình chiếu vào `presentation_out.pptx`. Chỉnh sửa các giá trị ô có thể cập nhật tệp XLSX bên ngoài đã liên kết, vì vậy hãy sử dụng bản sao nếu bạn cần giữ nguyên sổ làm việc gốc.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        series = chart.chart_data.series
        if len(series) > 0 and len(series[0].data_points) > 0:
            value_cell = series[0].data_points[0].value.as_cell
            if value_cell is not None:
                value_cell.value = 100
                presentation.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
```

### **Khôi phục Sổ làm việc từ Bộ nhớ Đệm Biểu đồ**

Nếu một biểu đồ sử dụng sổ làm việc bên ngoài bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo sổ làm việc biểu đồ từ dữ liệu được lưu trong bộ nhớ đệm của bản trình chiếu. Tạo [LoadOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/), cấu hình [spreadsheet_options](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/spreadsheet_options/), và đặt [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/vi/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) thành `True` trước khi mở bản trình chiếu.

Ví dụ Python sau mở `presentation.pptx`, trong đó hình dạng đầu tiên trên slide đầu tiên phải là một biểu đồ tham chiếu tới sổ làm việc bên ngoài không khả dụng, và truy cập dữ liệu đã khôi phục thông qua [Chart.chart_data](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/chart_data/) và [ChartData.chart_data_workbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        recovered_workbook = chart.chart_data.chart_data_workbook

        # Đọc hoặc sửa đổi dữ liệu sổ làm việc đã khôi phục tại đây.
    else:
        print("The first shape is not a chart.")
```

Nếu sổ làm việc bên ngoài không khả dụng và việc khôi phục bị tắt, Aspose.Slides sẽ ném một ngoại lệ. Chỉ bật khôi phục khi việc sử dụng dữ liệu biểu đồ đã lưu trong bộ nhớ đệm là cách dự phòng chấp nhận được, vì bộ nhớ đệm có thể không chứa các thay đổi được thực hiện trên sổ làm việc bên ngoài sau khi bản trình chiếu được cập nhật lần cuối.

## **FAQ**

**Tôi có thể xác định liệu một biểu đồ cụ thể có liên kết tới sổ làm việc bên ngoài hay sổ làm việc nhúng không?**

Có. Một biểu đồ có [kiểu nguồn dữ liệu](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/data_source_type/) và một [đường dẫn tới sổ làm việc bên ngoài](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/external_workbook_path/); nếu nguồn là một sổ làm việc bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn một tệp bên ngoài đang được sử dụng.

**Đường dẫn tương đối tới sổ làm việc bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Bản trình chiếu lưu đường dẫn tuyệt đối trong tệp PPTX, vì vậy việc di chuyển sổ làm việc có thể yêu cầu cập nhật liên kết.

**Tôi có thể sử dụng sổ làm việc nằm trên tài nguyên/mạng chia sẻ không?**

Có, các sổ làm việc như vậy có thể được sử dụng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa trực tiếp các sổ làm việc từ xa bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè tệp XLSX bên ngoài khi lưu bản trình chiếu không?**

Bản trình chiếu lưu một [liên kết tới tệp bên ngoài](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Việc chỉnh sửa dữ liệu biểu đồ dựa trên ô cũng có thể cập nhật tệp XLSX địa phương đã liên kết. Hãy sử dụng một bản sao của sổ làm việc nếu bản gốc phải được giữ nguyên.

**Tôi nên làm gì nếu tệp bên ngoài được bảo mật bằng mật khẩu?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách thường dùng là gỡ bảo mật trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, bằng cách sử dụng [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một sổ làm việc bên ngoài không?**

Có. Mỗi biểu đồ lưu liên kết riêng của mình. Nếu chúng đều trỏ tới cùng một tệp, việc cập nhật tệp đó sẽ được phản ánh trong mỗi biểu đồ lần sau khi dữ liệu được tải.