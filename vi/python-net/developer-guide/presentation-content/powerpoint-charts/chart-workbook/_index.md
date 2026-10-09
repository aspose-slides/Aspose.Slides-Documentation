---
title: Quản lý Workbook Biểu đồ trong Bản trình chiếu với Python
linktitle: Workbook Biểu đồ
type: docs
weight: 70
url: /vi/python-net/chart-workbook/
keywords:
- sổ làm việc biểu đồ
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
- Aspose.Slides
description: "Khám phá Aspose.Slides cho Python qua .NET: dễ dàng quản lý sổ làm việc biểu đồ trong các định dạng PowerPoint và OpenDocument để tối ưu hóa dữ liệu bản trình chiếu của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sổ làm việc biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua luồng sổ làm việc, sử dụng các ô sổ làm việc làm nhãn dữ liệu cho biểu đồ, truy cập bộ sưu tập worksheet và chỉ định kiểu nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng đề cập đến việc làm việc với sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một sổ làm việc bên ngoài, lấy đường dẫn của sổ làm việc bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi sổ làm việc khả dụng.

Đối với các ô sổ làm việc đại diện cho dữ liệu thiếu, xem [Kiểm soát việc hiển thị các ô trống](/slides/vi/python-net/chart-series/) để biết sự khác nhau giữa ô trống và giá trị zero, và so sánh biểu đồ đường của các chế độ hiển thị có sẵn.

## **Bao gồm dữ liệu từ các hàng và cột ẩn**

Sử dụng [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) để kiểm soát liệu biểu đồ có vẽ dữ liệu từ các hàng và cột worksheet ẩn hay không. Đặt nó thành `True` để chỉ vẽ các ô hiển thị, hoặc `False` để bao gồm cả các ô hiển thị và ẩn. Cài đặt này kiểm soát việc vẽ biểu đồ; nó không ẩn hoặc hiện các hàng hoặc cột worksheet.

[bản trình chiếu mẫu](hidden-source-data.pptx) chứa một biểu đồ cột là hình dạng đầu tiên trên slide đầu tiên của nó. Worksheet được nhúng, `Sheet1`, chứa phạm vi nguồn sau, `A1:C4`. Hàng 3 và cột C bị ẩn, nhưng các ô của chúng vẫn chứa giá trị.

| Hàng worksheet | A: Tháng | B: Bán lẻ | C: Bán sỉ (cột ẩn) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

Truy cập các ô nguồn qua [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) và đọc [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) để kiểm tra trạng thái ẩn của chúng. Thuộc tính này chỉ đọc. Trong tệp này, B2 hiển thị, B3 thuộc hàng ẩn, và C2 thuộc cột ẩn; ví dụ in ra `False`, `True` và `True` tương ứng.

Đối với ví dụ này, làm mới dữ liệu biểu đồ sau khi thay đổi cài đặt vẽ: giữ lại workbook được nhúng bằng [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) và tải lại bằng [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). Khi bao gồm tất cả các ô, cũng sử dụng [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) để khôi phục phạm vi đầy đủ, bao gồm danh mục February bị ẩn. Chỉ đổi cờ không đủ để làm mới dữ liệu biểu đồ và nhãn danh mục được lưu trong mẫu này.

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

            # Làm mới dữ liệu biểu đồ từ workbook được nhúng.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Khôi phục phạm vi nguồn đầy đủ, bao gồm các danh mục ẩn.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

Ví dụ lưu hai phiên bản của bản trình chiếu: một chỉ có các giá trị Retail hiển thị (10 và 20), và một khác với tất cả sáu giá trị. Các hình ảnh dưới đây được tạo từ các bản trình chiếu đã lưu sau khi mở lại; cả hai tệp đều giữ cài đặt vẽ đã chỉ định. Hàng 3 và cột C vẫn ẩn trong cả hai workbook được nhúng.

| Chỉ các ô hiển thị (`True`) | Tất cả các ô (`False`) |
| --- | --- |
| ![Chỉ các ô hiển thị: Giá trị bán lẻ 10 và 20 cho tháng January và March.](hidden_cells_True.png) | ![Tất cả các ô: Giá trị bán lẻ và bán sỉ cho tháng January, February và March.](hidden_cells_False.png) |

Một ô ẩn chứa giá trị khác với ô trống. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) điều khiển cách hiển thị các giá trị thiếu; nó không bao gồm hay loại bỏ dữ liệu nguồn ẩn. Xem [Kiểm soát việc hiển thị các ô trống](/slides/vi/python-net/chart-series/#control-the-display-of-empty-cells) để biết ví dụ.

## **Lấy phạm vi dữ liệu của biểu đồ**

Trước khi cập nhật dữ liệu workbook trong một bản trình chiếu hiện có, kiểm tra các phạm vi nguồn để xác định ô worksheet nào mỗi biểu đồ sử dụng. Phương thức [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) trả về phạm vi dữ liệu hiện tại dưới dạng công thức có chỉ định worksheet, chẳng hạn `Sheet1!$A$1:$D$5`. Ở đây, `Sheet1` là tên worksheet, `!` ngăn cách nó với phạm vi ô, và `$A$1:$D$5` xác định các ô từ A1 đến D5, bao gồm cả hai. Dấu `$` chỉ các tham chiếu tuyệt đối cho hàng và cột.

Phương thức đọc phạm vi hiện tại mà không thay đổi biểu đồ hoặc workbook của nó. Nếu biểu đồ không sử dụng workbook làm nguồn dữ liệu, nó sẽ ném ngoại lệ. Để biết thêm chi tiết, xem [Tham chiếu API ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/).

Ví dụ này mở một bản trình chiếu và kiểm tra các shape trực tiếp trên mỗi slide để tìm biểu đồ. Nó in tên và phạm vi nguồn của mỗi biểu đồ. Nếu không thể lấy phạm vi, nó in thông báo chẩn đoán và tiếp tục với biểu đồ tiếp theo.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                try:
                    data_range = shape.chart_data.get_range()
                    print(f"{shape.name}: {data_range}")
                except RuntimeError as error:
                    print(f"{shape.name}: Unable to retrieve the chart data range. {error}")
```

## **Đọc và ghi dữ liệu biểu đồ từ sổ làm việc**

Aspose.Slides for Python via .NET cung cấp các phương thức [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) và [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) cho phép bạn đọc và ghi workbook dữ liệu biểu đồ (chứa dữ liệu biểu đồ được chỉnh sửa bằng Aspose.Cells). **Note** rằng dữ liệu biểu đồ phải được tổ chức theo cùng một cách hoặc phải có cấu trúc tương tự như nguồn.

Ví dụ này sử dụng một bản trình chiếu có biểu đồ là shape đầu tiên trên slide đầu tiên. Nó đọc workbook được nhúng vào một luồng, xóa các series và categories hiện có, và ghi lại cùng một workbook. Các thay đổi vẫn tồn tại trong bộ nhớ; ví dụ không lưu bản trình chiếu.

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

### **Xác thực bố cục biểu đồ sau khi sửa đổi sổ làm việc**

Khi bạn thay thế một workbook được nhúng bằng một workbook đã sửa đổi, biểu đồ vẫn giữ các collection series và category ban đầu. Sự không khớp này có thể khiến [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) thất bại với lỗi chỉ mục vượt quá phạm vi. Hãy xóa các series và categories hiện có trước khi ghi workbook cập nhật trở lại biểu đồ. Ví dụ này sử dụng một biểu đồ là shape đầu tiên trên slide đầu tiên. Nhận xét đánh dấu vị trí sẽ chỉnh sửa workbook; ví dụ có thể chạy sẽ ghi lại workbook gốc và xác thực bố cục trong bộ nhớ.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Chỉnh sửa luồng workbook tại đây, ví dụ, sử dụng Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Việc xóa các collection loại bỏ các tham chiếu dữ liệu cũ trước khi workbook được ghi lại. Hãy xây dựng lại bất kỳ series và mapping category cần thiết cho workbook đã cập nhật trước khi sử dụng biểu đồ.

## **Đặt ô sổ làm việc làm nhãn dữ liệu cho biểu đồ**

Bạn có thể sử dụng văn bản từ các ô workbook làm nhãn dữ liệu cho biểu đồ.

Ví dụ này thêm một biểu đồ bubble với dữ liệu mặc định vào slide đầu tiên của một bản trình chiếu hiện có. Nó sử dụng các ô A10:A12 trên worksheet 0 cho ba nhãn đầu tiên trong series đầu tiên, bật nhãn từ ô, và lưu bản trình chiếu đã cập nhật.

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

## **Quản lý Worksheets**

Thuộc tính [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) cung cấp quyền truy cập tới các worksheet trong một workbook biểu đồ. Ví dụ này tạo một biểu đồ pie với dữ liệu mặc định và in tên mỗi worksheet ra console.

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

## **Chỉ định kiểu nguồn dữ liệu**

Ví dụ này tạo một biểu đồ cột 3D với dữ liệu mặc định và đặt hai tên series bằng các nguồn dữ liệu khác nhau. Tên đầu tiên sử dụng một literal chuỗi; tên thứ hai sử dụng ô C1 trên worksheet 0. Phân loại [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) chọn nguồn cho mỗi tên. Ví dụ lưu bản trình chiếu với các tên series đã cập nhật.

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

## **Phát hiện các định dạng sổ làm việc nhúng không được hỗ trợ**

Aspose.Slides không hỗ trợ định dạng workbook Excel nhị phân (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng thuộc tính [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) trên [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) cùng với liệt kê [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua các biểu đồ đó. Ví dụ này kiểm tra các shape trên slide đầu tiên của một bản trình chiếu hiện có, bỏ qua các shape không phải biểu đồ, và in thông báo chẩn đoán cho mỗi biểu đồ có workbook .xlsb được nhúng.

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

        # Đọc hoặc chỉnh sửa dữ liệu workbook biểu đồ được hỗ trợ tại đây.
```

## **Sổ làm việc bên ngoài**

Aspose.Slides hỗ trợ sử dụng sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ.

### **Tạo một sổ làm việc bên ngoài**

Sử dụng [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) và [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) để xuất workbook biểu đồ được nhúng ra file và liên kết biểu đồ tới workbook bên ngoài đó.

Ví dụ này tạo một biểu đồ pie với dữ liệu mặc định và xuất workbook của nó. Nó đóng luồng đầu ra trước khi gán workbook bên ngoài làm nguồn dữ liệu biểu đồ, sau đó lưu bản trình chiếu đã liên kết.

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

### **Đặt một sổ làm việc bên ngoài**

Bằng cách sử dụng phương thức [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/), bạn có thể gán một workbook bên ngoài cho biểu đồ làm nguồn dữ liệu. Phương thức này cũng có thể dùng để cập nhật đường dẫn tới workbook bên ngoài (nếu workbook đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các workbook được lưu ở vị trí từ xa hoặc tài nguyên, bạn vẫn có thể sử dụng các workbook đó làm nguồn dữ liệu bên ngoài. Nếu cung cấp đường dẫn tương đối cho một workbook bên ngoài, nó sẽ tự động được chuyển thành đường dẫn đầy đủ.

Ví dụ này sử dụng một workbook bên ngoài có worksheet tên `Sheet1` chứa tên series ở B1, tên danh mục ở A2:A4, và các giá trị số ở B2:B4. Ví dụ tạo một biểu đồ pie, liên kết workbook, và dùng [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) để ánh xạ A1:B4 thành một series và ba danh mục. Nó lưu bản trình chiếu với biểu đồ đã liên kết.

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

Tham số `update_chart_data` của [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) điều khiển việc tải workbook hay không.

* Khi `update_chart_data` là `False`, chỉ đường dẫn workbook được cập nhật. Dữ liệu biểu đồ không được tải hoặc cập nhật từ workbook mục tiêu, vì vậy workbook có thể không khả dụng.
* Khi `update_chart_data` là `True`, dữ liệu biểu đồ được cập nhật từ workbook mục tiêu.

Ví dụ sau gán một URL placeholder với `update_chart_data` đặt thành `False`. Nó giữ dữ liệu mặc định của biểu đồ pie và lưu bản trình chiếu mà không tải workbook không khả dụng.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Lấy đường dẫn sổ làm việc nguồn dữ liệu bên ngoài của biểu đồ**

Để xác định workbook được liên kết với một biểu đồ, kiểm tra xem biểu đồ có sử dụng nguồn dữ liệu bên ngoài không và lấy đường dẫn workbook của nó.

Ví dụ này kiểm tra shape đầu tiên trên slide đầu tiên của một bản trình chiếu có workbook bên ngoài được liên kết. Nếu đó là một biểu đồ được liên kết tới workbook bên ngoài, ví dụ in [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) ra console. Sau đó nó lưu một bản sao của bản trình chiếu.

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

### **Chỉnh sửa dữ liệu biểu đồ**

Bạn có thể chỉnh sửa dữ liệu trong các workbook bên ngoài theo cách bạn thay đổi nội dung của các workbook nội bộ. Khi một workbook bên ngoài không thể tải, một ngoại lệ sẽ được ném ra.

Ví dụ này sử dụng một biểu đồ là shape đầu tiên trên slide đầu tiên và được liên kết tới một workbook bên ngoài có thể truy cập. Nó đặt giá trị được hỗ trợ bởi ô của điểm dữ liệu đầu tiên trong series đầu tiên thành 100 và lưu bản trình chiếu đã cập nhật. Việc chỉnh sửa giá trị ô có thể cập nhật file XLSX bên ngoài được liên kết, vì vậy hãy sử dụng một bản sao nếu bạn cần bảo toàn workbook gốc.

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

### **Khôi phục sổ làm việc từ bộ nhớ đệm biểu đồ**

Nếu một biểu đồ sử dụng workbook bên ngoài bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo workbook biểu đồ từ dữ liệu được lưu trong bộ nhớ đệm của bản trình chiếu. Tạo [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/), cấu hình [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/), và đặt [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) thành `True` trước khi mở bản trình chiếu.

Ví dụ Python dưới đây khôi phục dữ liệu workbook cho một biểu đồ là shape đầu tiên trên slide đầu tiên và tham chiếu tới một workbook bên ngoài không khả dụng. Nó truy cập dữ liệu đã khôi phục qua [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) và [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

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

        # Đọc hoặc chỉnh sửa dữ liệu workbook đã khôi phục ở đây.
    else:
        print("The first shape is not a chart.")
```

Nếu workbook bên ngoài không khả dụng và khôi phục bị tắt, Aspose.Slides sẽ ném ngoại lệ. Chỉ bật khôi phục khi việc sử dụng dữ liệu biểu đồ được lưu trong bộ nhớ đệm là chấp nhận được, vì bộ nhớ đệm có thể không chứa các thay đổi đã thực hiện trên workbook bên ngoài sau khi bản trình chiếu lần cuối được cập nhật.

## **Câu hỏi thường gặp**

**Tôi có thể xác định liệu một biểu đồ cụ thể có liên kết tới sổ làm việc bên ngoài hay nhúng không?**

Có. Một biểu đồ có một [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) và một [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); nếu nguồn là một workbook bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp bên ngoài đang được sử dụng.

**Các đường dẫn tương đối tới workbook bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Bản trình chiếu lưu đường dẫn tuyệt đối trong file PPTX, vì vậy việc di chuyển workbook có thể yêu cầu cập nhật liên kết.

**Tôi có thể sử dụng các workbook nằm trên tài nguyên/mạng chia sẻ không?**

Có, các workbook như vậy có thể được sử dụng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa trực tiếp các workbook từ xa thông qua Aspose.Slides không được hỗ trợ — chúng chỉ có thể được sử dụng làm nguồn.

**Aspose.Slides có ghi đè lên file XLSX bên ngoài khi lưu bản trình chiếu không?**

Bản trình chiếu lưu một [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Việc chỉnh sửa dữ liệu biểu đồ được hỗ trợ bởi ô cũng có thể cập nhật file XLSX địa phương đã liên kết. Hãy sử dụng một bản sao của workbook nếu bản gốc phải được giữ nguyên.

**Nếu file bên ngoài được bảo vệ bằng mật khẩu, tôi nên làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách thường dùng là gỡ bảo vệ trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, bằng [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một workbook bên ngoài không?**

Có. Mỗi biểu đồ lưu trữ liên kết riêng của mình. Nếu tất cả chúng trỏ tới cùng một file, việc cập nhật file sẽ được phản ánh trong mỗi biểu đồ lần tiếp theo dữ liệu được tải.