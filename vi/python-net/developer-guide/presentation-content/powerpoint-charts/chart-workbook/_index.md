---
title: Quản lý Sách làm việc Biểu đồ trong Bản trình bày bằng Python
linktitle: Sách làm việc Biểu đồ
type: docs
weight: 70
url: /vi/python-net/chart-workbook/
keywords:
- sách làm việc biểu đồ
- dữ liệu biểu đồ
- ô sách làm việc
- nhãn dữ liệu
- bảng tính
- nguồn dữ liệu
- sách làm việc bên ngoài
- dữ liệu bên ngoài
- bộ nhớ đệm biểu đồ
- khôi phục sách làm việc
- PowerPoint
- bản trình bày
- Python
- Aspose.Slides
description: "Khám phá Aspose.Slides cho Python qua .NET: quản lý sách làm việc biểu đồ trong các định dạng PowerPoint và OpenDocument một cách dễ dàng để tối ưu hóa dữ liệu trình chiếu của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sách làm việc biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ qua các luồng sách làm việc, sử dụng các ô sách làm việc làm nhãn dữ liệu biểu đồ, truy cập các bộ sưu tập bảng tính, và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng bao phủ việc làm việc với sách làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một sách làm việc bên ngoài, lấy đường dẫn của sách làm việc bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi sách làm việc có sẵn.

Đối với các ô sách làm việc đại diện cho dữ liệu thiếu, hãy xem [Kiểm soát Hiển thị Các Ô Trống](/slides/vi/python-net/chart-series/) để biết sự khác biệt giữa một ô trống và số zero, và một so sánh biểu đồ đường của các chế độ hiển thị có sẵn.

## **Bao gồm Dữ liệu từ Các Hàng và Cột Ẩn**

Sử dụng [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) để kiểm soát xem biểu đồ có vẽ dữ liệu từ các hàng và cột bảng tính ẩn hay không. Đặt nó thành `True` để chỉ vẽ các ô hiển thị, hoặc `False` để bao gồm cả ô hiển thị và ẩn. Cài đặt này kiểm soát việc vẽ biểu đồ; nó không ẩn hoặc hiện các hàng hoặc cột bảng tính.

Bản trình bày mẫu([sample presentation](hidden-source-data.pptx)) chứa một biểu đồ cột là hình dạng đầu tiên trên slide đầu tiên. Bảng tính nhúng, `Sheet1`, chứa phạm vi nguồn sau, `A1:C4`. Hàng 3 và cột C bị ẩn, nhưng các ô của chúng vẫn chứa giá trị.

| Hàng bảng tính | A: Tháng | B: Bán lẻ | C: Bán buôn (cột ẩn) |
| --- | --- | --- | --- |
| 2 | Tháng 1 | 10 | 30 |
| 3 (hàng ẩn) | Tháng 2 | 40 | 60 |
| 4 | Tháng 3 | 20 | 50 |

Truy cập các ô nguồn thông qua [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) và đọc [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) để kiểm tra trạng thái ẩn của chúng. Thuộc tính này chỉ đọc. Trong tệp này, B2 hiển thị, B3 thuộc hàng ẩn và C2 thuộc cột ẩn; ví dụ in ra `False`, `True`, và `True` tương ứng.

Đối với ví dụ này, làm mới dữ liệu biểu đồ sau khi thay đổi cài đặt vẽ: giữ lại sách làm việc nhúng bằng [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) và tải lại bằng [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). Khi bao gồm tất cả các ô, cũng sử dụng [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) để khôi phục phạm vi đầy đủ, bao gồm danh mục tháng 2 ẩn. Chỉ thay đổi cờ không đủ để làm mới dữ liệu biểu đồ và nhãn danh mục được lưu trong bộ nhớ đệm của mẫu này.

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

            # Làm mới dữ liệu biểu đồ từ sách làm việc được nhúng.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Khôi phục toàn bộ phạm vi nguồn, bao gồm cả các danh mục ẩn.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

Ví dụ lưu hai phiên bản của bản trình bày: một chỉ có các giá trị Bán lẻ hiển thị (10 và 20), và một có tất cả sáu giá trị. Các hình ảnh dưới đây được tạo từ các bản trình bày đã lưu sau khi mở lại; cả hai tệp đều giữ cài đặt vẽ đã chỉ định. Hàng 3 và cột C vẫn ẩn trong cả hai sách làm việc nhúng.

| Chỉ các ô hiển thị (`True`) | Tất cả các ô (`False`) |
| --- | --- |
| ![Chỉ các ô hiển thị: Giá trị Bán lẻ 10 và 20 cho Tháng 1 và Tháng 3.](hidden_cells_True.png) | ![Tất cả các ô: Giá trị Bán lẻ và Bán buôn cho Tháng 1, Tháng 2 và Tháng 3.](hidden_cells_False.png) |

Một ô ẩn chứa giá trị khác với một ô trống. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) điều khiển cách hiển thị các giá trị thiếu; nó không bao gồm hoặc loại trừ dữ liệu nguồn ẩn. Xem [Kiểm soát Hiển thị Các Ô Trống](/slides/vi/python-net/chart-series/#control-the-display-of-empty-cells) để xem ví dụ.

## **Truy xuất Phạm vi Dữ liệu của Biểu đồ**

Trước khi cập nhật dữ liệu sách làm việc trong một bản trình bày hiện có, hãy kiểm tra các phạm vi nguồn để xác định ô bảng tính nào mỗi biểu đồ sử dụng. Phương thức [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) trả về phạm vi dữ liệu hiện tại dưới dạng công thức có chỉ định bảng tính, chẳng hạn `Sheet1!$A$1:$D$5`. Ở đây, `Sheet1` là tên bảng tính, `!` tách nó khỏi phạm vi ô, và `$A$1:$D$5` chỉ các ô A1 đến D5, bao gồm. Dấu đô la chỉ tham chiếu tuyệt đối cho hàng và cột.

Phương thức này đọc phạm vi hiện tại mà không thay đổi biểu đồ hoặc sách làm việc của nó. Nếu biểu đồ không sử dụng sách làm việc làm nguồn dữ liệu, nó sẽ ném một ngoại lệ. Để biết thêm thông tin, xem [ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/).

Ví dụ này mở một bản trình bày và kiểm tra các hình dạng trực tiếp trên mỗi slide để tìm biểu đồ. Nó in ra tên mỗi biểu đồ và phạm vi nguồn. Nếu không thể lấy phạm vi, nó in một thông báo chẩn đoán và tiếp tục với biểu đồ tiếp theo.

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

## **Đọc và Ghi Dữ liệu Biểu đồ từ Sách làm việc**

Aspose.Slides for Python via .NET cung cấp các phương thức [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) và [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) cho phép bạn đọc và ghi sách làm việc dữ liệu biểu đồ (chứa dữ liệu biểu đồ được chỉnh sửa bằng Aspose.Cells). **Lưu ý** rằng dữ liệu biểu đồ phải được tổ chức theo cùng một cách hoặc phải có cấu trúc tương tự nguồn.

Ví dụ này sử dụng một bản trình bày có biểu đồ là hình dạng đầu tiên trên slide đầu tiên. Nó đọc sách làm việc nhúng vào một luồng, xóa các series và category hiện có, và ghi lại cùng một sách làm việc. Các thay đổi vẫn giữ trong bộ nhớ; ví dụ không lưu bản trình bày.

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

### **Xác thực Bố cục Biểu đồ Sau Khi Sửa Đổi Sách làm việc**

Khi bạn thay thế một sách làm việc nhúng bằng một sách đã sửa đổi, biểu đồ vẫn giữ các bộ sưu tập series và category gốc. Sự không khớp này có thể khiến [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) thất bại với lỗi chỉ mục ngoài phạm vi. Xóa các series và category hiện có trước khi ghi lại sách làm việc đã cập nhật vào biểu đồ. Ví dụ này sử dụng một biểu đồ là hình dạng đầu tiên trên slide đầu tiên. Nhận xét đánh dấu nơi việc chỉnh sửa sách sẽ diễn ra; ví dụ có thể chạy sẽ ghi lại sách làm việc gốc và xác thực bố cục trong bộ nhớ.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Chỉnh sửa luồng sách làm việc ở đây, ví dụ, sử dụng Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Xóa các bộ sưu tập loại bỏ các tham chiếu dữ liệu lỗi thời trước khi sách làm việc được ghi lại. Xây dựng lại bất kỳ series và ánh xạ category cần thiết cho sách làm việc đã cập nhật trước khi sử dụng biểu đồ.

## **Đặt Định dạng Số Tùy chỉnh cho Các Ô Sách làm việc**

Sử dụng [ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) để kiểm soát cách các giá trị số hiển thị trong sách làm việc nhúng của biểu đồ. Ví dụ, một báo cáo có thể cần tỷ lệ chuyển đổi được hiển thị dưới dạng phần trăm với bốn chữ số thập phân và một hệ số được hiển thị với năm chữ số thập phân. Giữ cả hai giá trị ở dạng số để chúng vẫn có thể dùng cho tính toán và vẽ biểu đồ.

Một định dạng số chỉ thay đổi cách hiển thị, không thay đổi giá trị lưu trữ. Định dạng `0.0000%` hiển thị `0.125` dưới dạng `12.5000%`; nó không thay thế số lưu trữ bằng `12.5`. Tương tự, `0.00000` hiển thị `0.1234567` dưới dạng `0.12346` mà không làm tròn giá trị lưu trữ. Nếu định dạng tùy chỉnh là chuỗi rỗng (`""`), [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) sẽ được dùng thay thế.

Ví dụ sau tạo một biểu đồ cột và truy cập các ô của nó qua [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/). Trên bảng tính 0, B2 chứa tỷ lệ chuyển đổi và C2 chứa hệ số. Cả hai ô đều cung cấp giá trị cho biểu đồ. Ví dụ cũng bật nhãn giá trị được liên kết với định dạng nguồn.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 270, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 20, 620, 210)
    chart.has_title = False

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00"
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A2", "Sample")
    chart.chart_data.categories.add(category_cell)

    percentage_cell = workbook.get_cell(0, "B2", 0.125)
    percentage_cell.custom_number_format = "0.0000%"
    percentage_name = workbook.get_cell(0, "B1", "Conversion rate")
    percentage_series = chart.chart_data.series.add(percentage_name, chart.type)
    percentage_series.data_points.add_data_point_for_bar_series(percentage_cell)

    precision_cell = workbook.get_cell(0, "C2", 0.1234567)
    precision_cell.custom_number_format = "0.00000"
    precision_name = workbook.get_cell(0, "C1", "Coefficient")
    precision_series = chart.chart_data.series.add(precision_name, chart.type)
    precision_series.data_points.add_data_point_for_bar_series(precision_cell)

    for series in chart.chart_data.series:
        label_format = series.data_points[0].label.data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = True

    presentation.save("CustomCellFormats.pptx", slides.export.SaveFormat.PPTX)
```

Định dạng ô sách làm việc tách biệt với các định dạng được đặt trực tiếp trên trục biểu đồ hoặc nhãn dữ liệu. Trong ví dụ này, mỗi nhãn hiển thị giá trị ô nguồn vì [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) được bật, và tuân theo định dạng số nguồn vì [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) là `True`. Sau khi lưu và mở lại bản trình bày, các nhãn hiển thị `12.5000%` và `0.12346`, như dưới đây. Trục đứng sử dụng [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) của riêng nó là `0.00`, với [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) đặt thành `False`.

Để định dạng một nhãn dữ liệu một cách độc lập, đặt cờ liên kết nguồn của nó thành `False` và gán [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/). Điều này không thay đổi định dạng ô sách làm việc. Ví dụ, một định dạng nhãn độc lập `0.00` hiển thị giá trị đầu tiên là `0.13`, trong khi B2 vẫn hiển thị `12.5000%`. Xem [Nhãn Dữ liệu Biểu đồ](/slides/vi/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels) để định dạng nhãn trực tiếp.

![Biểu đồ cột với các nhãn liên kết nguồn hiển thị 12.5000% và 0.12346 và trục số định dạng độc lập.](custom-cell-formats.png)

## **Đặt Ô Sách làm việc làm Nhãn Dữ liệu Biểu đồ**

Bạn có thể sử dụng văn bản từ các ô sách làm việc làm nhãn dữ liệu biểu đồ.

Ví dụ này thêm một biểu đồ bong bóng với dữ liệu mặc định vào slide đầu tiên của một bản trình bày hiện có. Nó sử dụng các ô A10:A12 trên bảng tính 0 cho ba nhãn đầu tiên trong series đầu tiên, bật nhãn từ các ô, và lưu bản trình bày đã cập nhật.

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

## **Quản lý Bảng tính**

Thuộc tính [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) cung cấp quyền truy cập vào các bảng tính trong một sách làm việc biểu đồ. Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và in tên mỗi bảng tính ra console.

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

## **Chỉ định Loại Nguồn Dữ liệu**

Các giá trị điểm series cũng có thể được lưu trực tiếp dưới dạng literal số. Xem [Đặt Giá trị Dòng Series bằng Các Literal Số](/slides/vi/python-net/chart-series/#set-series-values-using-numeric-literals) để có ví dụ đầy đủ về cách lưu và đọc chúng. Loại nguồn của các giá trị điểm tách biệt với cấu hình sách làm việc nội bộ hoặc bên ngoài của biểu đồ; việc sử dụng literal số không tự động loại bỏ sách làm việc nhúng.

Ví dụ này tạo một biểu đồ cột 3D với dữ liệu mặc định và đặt hai tên series bằng các nguồn dữ liệu khác nhau. Tên đầu tiên sử dụng literal chuỗi; tên thứ hai sử dụng ô C1 trên bảng tính 0. Phân loại [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) chọn nguồn cho mỗi tên. Ví dụ lưu bản trình bày với các tên series đã cập nhật.

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

## **Phát hiện Định dạng Sách làm việc Được Nhúng Không Hỗ trợ**

Aspose.Slides không hỗ trợ định dạng sách làm việc nhị phân Excel (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng thuộc tính [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) trên [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) kết hợp với phân loại [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) để phát hiện các định dạng không hỗ trợ và bỏ qua các biểu đồ đó. Ví dụ này kiểm tra các hình dạng trên slide đầu tiên của một bản trình bày hiện có, bỏ qua các hình không phải biểu đồ, và in thông báo chẩn đoán cho mỗi biểu đồ có sách làm việc .xlsb được nhúng.

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

        # Đọc hoặc chỉnh sửa dữ liệu sách làm việc biểu đồ được hỗ trợ tại đây.
```

## **Sách làm việc Bên ngoài**

Aspose.Slides hỗ trợ sử dụng sách làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ.

### **Tạo Sách làm việc Bên ngoài**

Sử dụng [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) và [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) để xuất một sách làm việc biểu đồ nhúng ra tệp và liên kết biểu đồ với sách làm việc bên ngoài đó.

Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và xuất sách làm việc của nó. Nó đóng luồng đầu ra trước khi gán sách làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ, sau đó lưu bản trình bày đã liên kết.

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

### **Đặt Sách làm việc Bên ngoài**

Bằng cách sử dụng phương thức [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/), bạn có thể gán một sách làm việc bên ngoài cho biểu đồ làm nguồn dữ liệu. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới sách làm việc bên ngoài (nếu sách đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các sách làm việc được lưu ở vị trí từ xa hoặc tài nguyên, bạn vẫn có thể dùng các sách đó làm nguồn dữ liệu bên ngoài. Nếu cung cấp đường dẫn tương đối cho một sách làm việc bên ngoài, nó sẽ tự động được chuyển thành đường dẫn đầy đủ.

Ví dụ này sử dụng một sách làm việc bên ngoài có bảng tính tên `Sheet1` chứa tên series ở B1, tên danh mục ở A2:A4, và các giá trị số ở B2:B4. Ví dụ tạo một biểu đồ tròn, liên kết sách làm việc, và sử dụng [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) để ánh xạ A1:B4 thành một series và ba danh mục. Nó lưu bản trình bày với biểu đồ đã liên kết.

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

Tham số `update_chart_data` của [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) kiểm soát việc có tải sách làm việc hay không.

* Khi `update_chart_data` là `False`, chỉ cập nhật đường dẫn sách làm việc. Dữ liệu biểu đồ không được tải hoặc cập nhật từ sách làm việc mục tiêu, vì vậy sách làm việc có thể không khả dụng.
* Khi `update_chart_data` là `True`, dữ liệu biểu đồ được cập nhật từ sách làm việc mục tiêu.

Ví dụ sau gán một URL placeholder với `update_chart_data` đặt thành `False`. Nó giữ dữ liệu mặc định của biểu đồ tròn và lưu bản trình bày mà không tải sách làm việc không khả dụng.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Lấy Đường dẫn Sách làm việc Nguồn Dữ liệu Bên ngoài của Biểu đồ**

Để xác định sách làm việc được liên kết với một biểu đồ, kiểm tra liệu biểu đồ có sử dụng nguồn dữ liệu bên ngoài và lấy đường dẫn sách làm việc của nó.

Ví dụ này kiểm tra hình dạng đầu tiên trên slide đầu tiên của một bản trình bày có sách làm việc bên ngoài được liên kết. Nếu đó là một biểu đồ được liên kết với sách làm việc bên ngoài, ví dụ sẽ in [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) ra console. Sau đó nó lưu một bản sao của bản trình bày.

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

Bạn có thể chỉnh sửa dữ liệu trong sách làm việc bên ngoài tương tự như thay đổi nội dung của sách làm việc nội bộ. Khi một sách làm việc bên ngoài không thể tải, một ngoại lệ sẽ được ném.

Ví dụ này sử dụng một biểu đồ là hình dạng đầu tiên trên slide đầu tiên và được liên kết với một sách làm việc bên ngoài có thể truy cập được. Nó đặt giá trị dựa trên ô cho điểm dữ liệu đầu tiên trong series đầu tiên thành 100 và lưu bản trình bày đã cập nhật. Việc chỉnh sửa giá trị ô có thể cập nhật tệp XLSX bên ngoài được liên kết, vì vậy hãy dùng bản sao nếu bạn cần giữ nguyên sách làm việc gốc.

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

### **Khôi phục Sách làm việc từ Bộ nhớ Cache của Biểu đồ**

Nếu một biểu đồ sử dụng một sách làm việc bên ngoài bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo sách làm việc biểu đồ từ dữ liệu được lưu trong bộ nhớ cache của bản trình bày. Tạo [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/), cấu hình [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/), và đặt [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) thành `True` trước khi mở bản trình bày.

Ví dụ Python sau khôi phục dữ liệu sách làm việc cho một biểu đồ là hình dạng đầu tiên trên slide đầu tiên và tham chiếu một sách làm việc bên ngoài không khả dụng. Nó truy cập dữ liệu đã khôi phục qua [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) và [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

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

        # Đọc hoặc chỉnh sửa dữ liệu sách làm việc đã khôi phục ở đây.
    else:
        print("The first shape is not a chart.")
```

Nếu sách làm việc bên ngoài không khả dụng và việc khôi phục bị tắt, Aspose.Slides sẽ ném một ngoại lệ. Chỉ bật khôi phục khi việc sử dụng dữ liệu biểu đồ được lưu trong cache là một phương án chấp nhận được, vì cache có thể không chứa các thay đổi đã thực hiện trên sách làm việc bên ngoài sau lần cập nhật cuối cùng của bản trình bày.

## **Câu hỏi thường gặp**

**Tôi có thể xác định liệu một biểu đồ cụ thể có liên kết đến một sách làm việc bên ngoài hay nhúng không?**

Có. Một biểu đồ có một [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) và một [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); nếu nguồn là một sách làm việc bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn một tệp bên ngoài đang được sử dụng.

**Các đường dẫn tương đối tới sách làm việc bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Bản trình bày lưu đường dẫn tuyệt đối trong tệp PPTX, vì vậy việc di chuyển sách làm việc có thể yêu cầu cập nhật liên kết.

**Tôi có thể sử dụng sách làm việc nằm trên tài nguyên/mạng chia sẻ không?**

Có, các sách làm việc như vậy có thể được dùng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa sách làm việc từ xa trực tiếp bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè lên tệp XLSX bên ngoài khi lưu bản trình bày không?**

Bản trình bày lưu một [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Việc chỉnh sửa dữ liệu biểu đồ dựa trên ô cũng có thể cập nhật tệp XLSX cục bộ được liên kết. Hãy sử dụng bản sao của sách làm việc nếu bản gốc phải được giữ nguyên.

**Tôi nên làm gì nếu tệp bên ngoài được bảo mật bằng mật khẩu?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách thường dùng là bỏ bảo mật trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, bằng [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một sách làm việc bên ngoài không?**

Có. Mỗi biểu đồ lưu liên kết riêng của mình. Nếu tất cả chúng trỏ tới cùng một tệp, việc cập nhật tệp đó sẽ được phản ánh trong mỗi biểu đồ lần tiếp theo dữ liệu được tải.