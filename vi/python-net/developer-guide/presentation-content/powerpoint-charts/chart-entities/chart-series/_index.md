---
title: Quản lý Series Dữ liệu Biểu đồ trong Bản trình chiếu bằng Python
linktitle: Series Dữ liệu
type: docs
url: /vi/python-net/chart-series/
keywords:
- series biểu đồ
- giao nhau của series
- màu series
- màu danh mục
- tên series
- điểm dữ liệu
- khoảng cách series
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tìm hiểu cách quản lý series biểu đồ, điểm dữ liệu, các ô workbook, định dạng, giao nhau, độ rộng khe và các giá trị âm trong bản trình chiếu bằng Python."
---
## **Tổng quan**

Biểu đồ có thể lưu các giá trị được vẽ trong các ô của workbook hoặc trực tiếp dưới dạng nguyên liệu số. Một [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) đại diện cho một tập hợp các giá trị liên quan, và mỗi [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) đại diện cho một điểm trong tập hợp đó. Các đối tượng [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) cung cấp các nhãn hoặc giá trị nhóm được chia sẻ bởi các series. Trong các biểu đồ được tạo với dữ liệu mặc định, tên series, danh mục và giá trị điểm sử dụng các đối tượng [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) từ workbook của biểu đồ.

Đối với một biểu đồ danh mục điển hình, workbook mặc định sử dụng hàng 0 cho tên series, cột 0 cho tên danh mục và các ô còn lại cho các giá trị series. Các chỉ mục worksheet, row và column được truyền vào [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) là dạng chỉ số bắt đầu từ 0. Bố cục này hữu ích khi bạn tạo biểu đồ với dữ liệu mặc định, nhưng không nên cho rằng mọi biểu đồ hiện có đều sử dụng nó. Đối với một bản thuyết trình đã tải, hãy kiểm tra các ô được series, categories và data points tham chiếu trước khi thay đổi giá trị trong workbook.

Cài đặt biểu đồ có ba phạm vi khác nhau:

- Cài đặt mức series, chẳng hạn như [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/), cung cấp giao diện mặc định cho tất cả các điểm trong một series.
- Cài đặt mức điểm dữ liệu, chẳng hạn như [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/), ghi đè giao diện của series cho một điểm.
- Cài đặt nhóm áp dụng cho các series tương thích thuộc cùng một [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/). Truy cập nhóm thông qua [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) khi bạn cần đặt các tùy chọn như độ giao nhau hoặc độ rộng khe.

Khi không có màu nền điểm hoặc series nào được đặt một cách rõ ràng, kiểu biểu đồ và theme sẽ xác định giao diện tự động. Khi cả định dạng series và điểm đều có, định dạng điểm sẽ được ưu tiên cho điểm đó.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Đặt Giá Trị Series Bằng Nguyên Lượng Số**

Sử dụng nguyên liệu số khi giá trị series đến từ dữ liệu hoặc tính toán trong ứng dụng và không cần tham chiếu đến ô worksheet. Đặt [data_source_type_for_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_values/) thành [DataSourceType.DOUBLE_LITERALS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) trước khi gán [value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) của mỗi điểm qua [as_literal_double](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_literal_double/).

Cài đặt bộ sưu tập điều khiển loại nguồn của tất cả các giá trị điểm trong series đó. [value.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/basechartvalue/data_source_type/) của mỗi điểm báo cáo loại đã chọn; thay đổi nó thông qua cài đặt bộ sưu tập. Với `WORKSHEET`, sử dụng [as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_cell/) để truy cập ô được tham chiếu. Với `DOUBLE_LITERALS`, sử dụng `as_literal_double` để đọc hoặc ghi số trực tiếp.

Ví dụ sau tạo một biểu đồ cột với series và categories mặc định, sau đó gán các giá trị tính toán 10, 20, … cho các điểm hiện có của series thứ nhất. Nó lưu bản thuyết trình, mở lại và in các giá trị đã lưu.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    series = chart.chart_data.series[0]

    series.data_points.data_source_type_for_values = charts.DataSourceType.DOUBLE_LITERALS
    for i in range(len(series.data_points)):
        series.data_points[i].value.as_literal_double = (i + 1) * 10

    presentation.save("numeric_literals.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("numeric_literals.pptx") as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_chart = reopened_slide.shapes[0]
    reopened_series = reopened_chart.chart_data.series[0]
    for point in reopened_series.data_points:
        print(point.value.as_literal_double)
```

Kiểu nguồn giá trị điểm tách biệt khỏi [ChartData.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/), yếu tố xác định cấu hình workbook nội bộ hoặc bên ngoài của biểu đồ. Việc sử dụng nguyên liệu số không tự động loại bỏ workbook nhúng. Trong ví dụ này, workbook vẫn còn sẵn cho các nhãn danh mục, tên series và các series khác. Xem [Sổ làm việc biểu đồ](/slides/vi/python-net/chart-workbook/) để quản lý workbook.

Đối với biểu đồ scatter và bubble, đặt [data_source_type_for_x_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_x_values/) và [data_source_type_for_y_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_y_values/) để chọn nguồn cho [x_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/x_value/) và [y_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/y_value/). Biểu đồ bubble cũng sử dụng [data_source_type_for_bubble_sizes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_bubble_sizes/) cho [bubble_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/bubble_size/). Đặt mỗi nguồn áp dụng thành `DOUBLE_LITERALS` trước khi gán số qua thuộc tính `as_literal_double` của giá trị đó.

## **Đặt Độ Giao Nhau Của Series Biểu Đồ**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) báo cáo mức độ các thanh hoặc cột giao nhau trong biểu đồ 2D, từ -100 đến 100 phần trăm. Đây là một phép chiếu chỉ đọc của cài đặt trên nhóm series cha. Đặt [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) để cập nhật mọi series tương thích trong nhóm đó. Tùy chọn này áp dụng cho các loại biểu đồ hiển thị các thanh hoặc cột được nhóm lại; nó không ảnh hưởng đến các nhóm series không liên quan trong biểu đồ kết hợp.

Ví dụ sau đặt độ giao nhau cho nhóm chứa series đầu tiên:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Biểu đồ mới chứa các series mẫu, danh mục và giá trị.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The series overlap](series_overlap.png)

## **Thay Đổi Màu Nền Series**

Sử dụng [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) để đặt màu nền mặc định cho toàn bộ một series. Nếu một điểm đã có màu nền rõ ràng, cài đặt [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) của nó sẽ ghi đè màu nền series cho điểm đó.

Ví dụ sau áp dụng màu nền xanh dương đặc cho series đầu tiên:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = drawing.Color.blue

    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The color of the series](series_color.png)

## **Thay Đổi Tên Series**

Tên series được lưu trong workbook dữ liệu biểu đồ và thường hiển thị trong legend. Trong workbook mặc định được tạo cho biểu đồ cột cụm, ô B1 ở hàng 0, cột 1 chứa tên của series đầu tiên. Các hằng số được đặt trong ví dụ dưới đây làm rõ cấu trúc này:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    workbook = chart.chart_data.chart_data_workbook
    series_name_cell = workbook.get_cell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Bạn cũng có thể cập nhật ô mà [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/) đã tham chiếu. Cách này tránh việc giả định một hàng và cột cụ thể trong biểu đồ hiện có:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series_name_cell = series.name.as_cells[first_name_cell_index]
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The series name](series_name.png)

### **Tạo Series Với Tên Từ Nhiều Ô**

Một tên series tổng hợp hữu ích khi tên sản phẩm và kỳ báo cáo được lưu trong các ô workbook riêng biệt. Ví dụ, bạn có thể kết hợp `Product A` trong B1 và `2026` trong C1 thành một tên series duy nhất trong khi vẫn giữ liên kết với các ô nguồn.

Sử dụng [ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) để lấy phạm vi tên, sau đó truyền bộ sưu tập đó vào [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/). Tham số `skip_hidden_cells` kiểm soát việc có bao gồm các ô ẩn hay không: `True` loại bỏ, `False` bao gồm. Ví dụ này dùng `False` để bao gồm mọi ô trong phạm vi tên.

Ví dụ sau tạo một bản thuyết trình với một series và hai điểm dữ liệu. Các ô B1:C1 chỉ cung cấp tên series; A2:A3 cung cấp nhãn danh mục, và B2:B3 cung cấp các giá trị số.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 620, 180)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = True

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Hai ô này cung cấp tên series.
    workbook.get_cell(0, 0, 1, "Product A")
    workbook.get_cell(0, 0, 2, "2026")
    name_cells = workbook.get_cell_collection("Sheet1!$B$1:$C$1", False)
    series = chart.chart_data.series.add(name_cells, charts.ChartType.CLUSTERED_COLUMN)

    # Các ô riêng biệt cung cấp các danh mục và các điểm dữ liệu số.
    north_category = workbook.get_cell(0, 1, 0, "North")
    south_category = workbook.get_cell(0, 2, 0, "South")
    chart.chart_data.categories.add(north_category)
    chart.chart_data.categories.add(south_category)
    north_value = workbook.get_cell(0, 1, 1, 120)
    south_value = workbook.get_cell(0, 2, 1, 150)
    series.data_points.add_data_point_for_bar_series(north_value)
    series.data_points.add_data_point_for_bar_series(south_value)

    presentation.save("composite_series_name.pptx", slides.export.SaveFormat.PPTX)
```

Tên series tạo ra là `Product A 2026`, có một dấu cách giữa hai giá trị ô. Legend hiển thị điều này như một mục cho cả hai cột. Hình ảnh dưới đây được render từ bản thuyết trình đã lưu:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Lấy Màu Nền Series Tự Động**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) trả về màu được tính dựa trên chỉ số series và kiểu biểu đồ. Đây là màu được dùng khi màu nền series chưa được định nghĩa rõ ràng. Gọi phương thức này chỉ đọc màu đã tính; nó không gán màu nền mới.

Ví dụ sau in màu tự động của mỗi series mặc định:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series_count = len(chart.chart_data.series)
    for series_index in range(series_count):
        series = chart.chart_data.series[series_index]
        automatic_color = series.get_automatic_series_color()
        print(f"Series {series_index}: {automatic_color.name}")
```

Kết quả mẫu cho kiểu biểu đồ mặc định:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Màu sắc chính xác phụ thuộc vào kiểu biểu đồ và theme.

## **Đặt Màu Nền Đảo Ngược Cho Series Biểu Đồ**

Đối với series thanh, cột và bubble, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) có thể hiển thị các giá trị âm bằng màu nền khác. Đặt màu nền series thông thường thành màu đặc, bật tính năng đảo ngược, và gán màu âm qua [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Các số âm không thay đổi trong workbook; chỉ màu hiển thị thay đổi.

Ví dụ sau thay thế dữ liệu biểu đồ mặc định bằng một series. Hàng 0 của worksheet chứa tên series, cột 0 chứa tên danh mục, và cột 1 chứa giá trị:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    series = chart_data.series.add(series_name_cell, chart.type)

    category_count = len(category_names)
    for category_index in range(category_count):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.get_cell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.data_points.add_data_point_for_bar_series(value_cell)

    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.invert_if_negative = True
    series.inverted_solid_fill_color.color = drawing.Color.red

    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The inverted solid fill color](inverted_solid_fill_color.png)

Bạn có thể bật đảo ngược cho một điểm thông qua [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Trong ví dụ sau, đảo ngược bị tắt cho series và chỉ bật cho điểm đã chọn. Điểm này cũng được gán giá trị âm để hiệu ứng hiển thị:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.inverted_solid_fill_color.color = drawing.Color.red
    series.invert_if_negative = False

    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = negative_value
    data_point.invert_if_negative = True

    presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **Xóa Giá Trị Điểm Dữ Liệu Cụ Thể**

Để làm cho một điểm trống mà không xóa các điểm khác, đặt ô workbook hỗ trợ nó thành `None`. Đối với biểu đồ cột, giá trị được vẽ có sẵn qua [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/). Điểm dữ liệu vẫn giữ vị trí danh mục, nhưng biểu đồ sẽ xử lý giá trị này như một ô trống tùy theo cài đặt ô trống của biểu đồ.

Ví dụ sau chỉ xóa điểm thứ hai trong series đầu tiên:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = None

    presentation.save("clear_data_point_value.pptx", slides.export.SaveFormat.PPTX)
```

Biểu đồ scatter sử dụng các ô X và Y riêng biệt, và biểu đồ bubble cũng sử dụng ô kích thước. Hãy xóa chỉ ô đại diện cho giá trị bạn muốn loại bỏ. Không gọi [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) khi bạn muốn giữ các điểm khác, vì phương pháp đó sẽ xóa mọi điểm dữ liệu trong bộ sưu tập.

## **Kiểm Soát Hiển Thị Ô Trống**

Các ô ẩn chứa giá trị là một trường hợp riêng biệt so với các ô trống. Để bao gồm hoặc loại bỏ dữ liệu từ các hàng và cột worksheet ẩn, xem [Include Data from Hidden Rows and Columns](/slides/vi/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Một ô workbook trống đại diện cho dữ liệu thiếu; một ô chứa `0` đại diện cho một giá trị số đã biết. Đặt [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) thành `None` để làm ô trống. Số 0 vẫn là 0 bất kể cài đặt ô trống.

Sử dụng [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) để chọn cách biểu đồ hiển thị các ô trống. Cài đặt này áp dụng cho toàn bộ biểu đồ. Nó thay đổi cách các ô trống được vẽ, mà không điền vào ô workbook trống bằng 0 hay một giá trị nội suy.

Ví dụ tự chứa sau tạo một biểu đồ đường với một series, xóa giá trị cho Ngày 3, và lưu cùng một biểu đồ với mỗi chế độ. Không cần tệp đầu vào. [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) sử dụng worksheet 0, cột 0 cho nhãn danh mục, và cột 1 cho các giá trị; hàng 0 chứa tên series. Dữ liệu cuối cùng là `10, 20, empty, 30, 40`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 40, 40, 640, 400)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(0, 0, 1, "Measurements")
    series = chart_data.series.add(series_name_cell, chart.type)
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Để lại Ngày 3 thực sự trống, đồng thời giữ lại danh mục và điểm dữ liệu của nó.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Mỗi tệp xuất lưu chế độ đã được gán trước khi lưu: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, và `empty_cells_Span.pptx`. Để lưu chỉ một phiên bản, gán chế độ mong muốn và lưu bản thuyết trình một lần thay vì lặp lại các chế độ.

So sánh dưới đây cho thấy cùng một dữ liệu trong cả ba tệp. Ngày 3 là ô trống trong workbook trong mọi trường hợp:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Hiệu ứng hiển thị phụ thuộc vào loại biểu đồ. Biểu đồ đường dễ so sánh ba chế độ. Biểu đồ thanh và cột không có đường nối qua danh mục bị thiếu, vì vậy `SPAN` không thể tạo đoạn nối như trên; một cột thiếu và một cột chiều cao 0 cũng có thể trông giống nhau. Tương tự, biểu đồ scatter chỉ có marker cũng không có đường nối. Đừng mong ba kết quả khác nhau cho mọi loại biểu đồ; kiểm tra đầu ra cho loại bạn đang dùng.

## **Đặt Độ Rộng Khe Giữa Series**

Độ rộng khe là khoảng cách giữa các cụm thanh hoặc cột liền kề, tính bằng phần trăm độ rộng của thanh hoặc cột. Giống như độ giao nhau, nó thuộc về nhóm series cha chứ không phải một series riêng. Đặt [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) một lần cho nhóm. Giá trị lớn tạo khoảng cách rộng hơn giữa các cụm; giá trị nhỏ làm chúng dày đặc hơn.

Ví dụ sau thay đổi độ rộng khe và chỉ lưu bản thuyết trình cuối cùng:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.gap_width = gap_width_percent

    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The gap width](gap_width.png)

## **Câu Hỏi Thường Gặp**

**Các loại biểu đồ nào hỗ trợ series dữ liệu?**

Tất cả các loại biểu đồ được liệt kê trong enumeration [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) đều sử dụng dữ liệu biểu đồ, nhưng series của chúng không phải lúc nào cũng có cùng cấu trúc giá trị hoặc cài đặt. Ví dụ, biểu đồ danh mục dùng categories và values, biểu đồ scatter dùng giá trị X và Y, và biểu đồ bubble thêm kích thước bubble. Hãy sử dụng phương pháp tạo điểm dữ liệu phù hợp với loại series. Các tùy chọn như độ giao nhau và độ rộng khe chỉ áp dụng cho các nhóm thanh hoặc cột tương thích.

**Series group là gì?**

Một [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) chứa các series tương thích chia sẻ các cài đặt vẽ ở mức nhóm. Một biểu đồ kết hợp có thể chứa nhiều hơn một nhóm, vì vậy việc thay đổi nhóm thông qua một series không nhất thiết thay đổi mọi series trong biểu đồ.

**Biểu đồ mới tạo có dữ liệu mặc định không?**

Có. Mặc định, [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) tạo các series, categories và values mẫu. Bạn có thể chỉnh sửa các ô đó hoặc xóa cả bộ series và categories trước khi thêm một bộ dữ liệu tùy chỉnh hoàn toàn. Một overload cũng có thể tạo biểu đồ không có dữ liệu mặc định.

**Các đối tượng biểu đồ được liên kết với các ô workbook như thế nào?**

Tên series, nhãn danh mục và giá trị điểm dữ liệu tham chiếu tới các ô trong một [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/). Thay đổi một ô được tham chiếu sẽ cập nhật phần tử biểu đồ tương ứng. Khi bạn xây dựng dữ liệu tùy chỉnh, hãy giữ các hàng danh mục và hàng giá trị series đồng bộ để mỗi điểm được vẽ dưới danh mục mong muốn.

**Làm sao để xóa một điểm mà không xóa toàn bộ series?**

Đặt ô giá trị liên quan thành `None` để giữ vị trí danh mục của điểm như một điểm trống. Chỉ sử dụng [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) khi bạn muốn loại bỏ tất cả các điểm trong series đó. Nếu bạn cũng loại bỏ các danh mục, hãy cập nhật mọi series để giá trị của chúng vẫn đồng nhất với bộ categories.

**Các điểm trống được hiển thị như thế nào?**

Kết quả phụ thuộc vào loại biểu đồ và [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/). Các biểu đồ hỗ trợ có thể hiển thị ô trống dưới dạng khoảng trống, giá trị 0, hoặc bằng cách nối các điểm lân cận. Chọn cài đặt phù hợp với ý nghĩa của dữ liệu thiếu trong bản thuyết trình của bạn. Xem [Kiểm Soát Hiển Thị Ô Trống](#control-the-display-of-empty-cells) để xem ví dụ đầy đủ và so sánh trực quan.

**Giá trị âm được định dạng như thế nào?**

Đối với các series thanh, cột và bubble được hỗ trợ, bật [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) và đặt [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Bạn có thể ghi đè hành vi cho một điểm riêng lẻ bằng [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Các thuộc tính này ảnh hưởng đến định dạng, không phải giá trị số được lưu.

**Định dạng nào thắng khi cả series và điểm đều được định dạng?**

Định dạng điểm dữ liệu rõ ràng sẽ được ưu tiên cho điểm đó. Các điểm khác tiếp tục sử dụng định dạng series rõ ràng hoặc, nếu series không có định dạng, sử dụng kiểu và theme tự động của biểu đồ. Các thuộc tính nhóm như độ giao nhau và độ rộng khe kiểm soát bố cục và không phải là sự ghi đè định dạng mức điểm.

**Có giới hạn số lượng series trong một biểu đồ không?**

Aspose.Slides không đặt giới hạn cố định riêng cho số series. Trong thực tế, các ràng buộc của tệp thuyết trình, bộ nhớ khả dụng, thời gian render và khả năng đọc biểu đồ quyết định giới hạn thực tế.

**Nên thay đổi gì khi các cột quá gần nhau hoặc quá xa?**

Đặt [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) trên nhóm series cha thích hợp. Tăng giá trị để mở rộng khoảng cách giữa các cụm, hoặc giảm để đưa các cụm lại gần nhau hơn.