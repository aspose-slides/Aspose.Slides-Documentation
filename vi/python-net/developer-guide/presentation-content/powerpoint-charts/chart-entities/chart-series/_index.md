---
title: Quản lý chuỗi dữ liệu biểu đồ trong bản trình bày bằng Python
linktitle: Chuỗi dữ liệu
type: docs
url: /vi/python-net/chart-series/
keywords:
- chuỗi biểu đồ
- chồng lấn chuỗi
- màu chuỗi
- màu danh mục
- tên chuỗi
- điểm dữ liệu
- khoảng cách chuỗi
- PowerPoint
- bản trình bày
- Python
- Aspose.Slides
description: "Tìm hiểu cách quản lý chuỗi biểu đồ, điểm dữ liệu, các ô workbook, định dạng, chồng lấn, độ rộng khoảng cách và các giá trị âm trong bản trình bày bằng Python."
---
## **Tổng quan**

Một biểu đồ lưu trữ dữ liệu đã vẽ của nó trong một chart data workbook. Một [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) đại diện cho một tập các giá trị liên quan, và mỗi [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) trong chuỗi tham chiếu tới một hoặc nhiều ô trong workbook. Các đối tượng [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) cung cấp các nhãn hoặc giá trị nhóm được chia sẻ bởi các chuỗi. Do đó, tên chuỗi, danh mục và giá trị điểm đều được kết nối tới các đối tượng [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) thay vì chỉ được lưu dưới dạng văn bản hiển thị.

Đối với một biểu đồ phân loại điển hình, workbook mặc định sử dụng hàng 0 cho tên chuỗi, cột 0 cho tên danh mục, và các ô còn lại cho các giá trị chuỗi. Các chỉ mục worksheet, hàng và cột được truyền cho [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) là dạng chỉ số bắt đầu từ 0. Bố cục này hữu ích khi bạn tạo biểu đồ với dữ liệu mặc định, nhưng không nên cho rằng mọi biểu đồ hiện có đều sử dụng nó. Đối với một bản trình bày đã tải, hãy kiểm tra các ô mà các chuỗi, danh mục và điểm dữ liệu tham chiếu trước khi thay đổi giá trị trong workbook.

Cài đặt biểu đồ có ba phạm vi khác nhau:

- Cài đặt ở mức chuỗi, như [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/), cung cấp giao diện mặc định cho tất cả các điểm trong một chuỗi.
- Cài đặt mức điểm dữ liệu, như [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/), ghi đè giao diện của chuỗi cho một điểm.
- Cài đặt nhóm áp dụng cho các chuỗi tương thích thuộc cùng một [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/). Truy cập nhóm thông qua [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) khi bạn cần đặt các tùy chọn như overlap hoặc gap width.

Khi không có màu nền điểm hoặc chuỗi nào được đặt rõ ràng, kiểu biểu đồ và chủ đề sẽ xác định giao diện tự động. Khi cả định dạng chuỗi và điểm đều có, định dạng điểm sẽ có ưu tiên đối với điểm đó.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Đặt Overlap cho Chuỗi Biểu Đồ**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) báo cáo mức độ chồng lấn của các thanh hoặc cột trong một biểu đồ 2D, từ -100 tới 100 phần trăm. Đây là một dự đoán chỉ đọc của cài đặt trên nhóm chuỗi cha. Đặt [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) để cập nhật mọi chuỗi tương thích trong nhóm đó. Tùy chọn này áp dụng cho các loại biểu đồ hiển thị các thanh hoặc cột được nhóm; nó không ảnh hưởng đến các nhóm chuỗi không liên quan trong một biểu đồ kết hợp.

Ví dụ sau đặt overlap cho nhóm chứa chuỗi đầu tiên:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Biểu đồ mới chứa các chuỗi mẫu, danh mục và giá trị.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The series overlap](series_overlap.png)

## **Thay đổi màu nền chuỗi**

Sử dụng [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) để đặt màu nền mặc định cho toàn bộ chuỗi. Nếu một điểm đã có màu nền rõ ràng, cài đặt [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) của nó sẽ ghi đè màu nền chuỗi cho điểm đó.

Ví dụ sau áp dụng màu nền xanh đậm đặc cho chuỗi đầu tiên:

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

## **Thay đổi tên chuỗi**

Tên chuỗi được lưu trong chart data workbook và thường được hiển thị trong chú giải. Trong workbook mặc định được tạo cho một biểu đồ cột nhóm, ô B1 nằm ở hàng 0, cột 1 và chứa tên của chuỗi đầu tiên. Các hằng số được đặt tên trong ví dụ sau làm cho cấu trúc này rõ ràng:

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

Bạn cũng có thể cập nhật ô đã được tham chiếu bởi [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/). Cách này tránh việc giả định một hàng và cột cụ thể trong một biểu đồ đã tồn tại:

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

### **Tạo một chuỗi với tên từ nhiều ô**

Tên chuỗi tổng hợp hữu ích khi tên sản phẩm và kỳ báo cáo được lưu trong các ô workbook riêng biệt. Ví dụ, bạn có thể kết hợp `Product A` ở B1 và `2026` ở C1 thành một tên chuỗi duy nhất trong khi vẫn giữ cả hai phần liên kết tới ô nguồn của chúng.

Sử dụng [ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) để lấy phạm vi tên, sau đó truyền tập hợp đó cho [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/). Tham số `skip_hidden_cells` điều khiển việc có bao gồm các ô ẩn hay không: `True` loại bỏ chúng, trong khi `False` bao gồm chúng. Ví dụ này sử dụng `False` để bao gồm mọi ô trong phạm vi tên.

Ví dụ sau tạo một bản trình bày với một chuỗi và hai điểm dữ liệu. Các ô B1:C1 chỉ cung cấp tên chuỗi; A2:A3 cung cấp nhãn danh mục, và B2:B3 cung cấp các giá trị số.

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

    # Hai ô này cung cấp tên chuỗi.
    workbook.get_cell(0, 0, 1, "Product A")
    workbook.get_cell(0, 0, 2, "2026")
    name_cells = workbook.get_cell_collection("Sheet1!$B$1:$C$1", False)
    series = chart.chart_data.series.add(name_cells, charts.ChartType.CLUSTERED_COLUMN)

    # Các ô riêng biệt cung cấp danh mục và các điểm dữ liệu số.
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

Tên chuỗi tạo ra là `Product A 2026`, với một dấu cách giữa hai giá trị ô. Chú giải hiển thị nó như một mục cho cả hai cột. Hình ảnh dưới đây được tạo ra từ bản trình bày đã lưu:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Lấy màu nền chuỗi tự động**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) trả về màu được tính dựa trên chỉ số chuỗi và kiểu biểu đồ. Đây là màu được sử dụng khi màu nền chuỗi chưa được định nghĩa rõ ràng. Gọi phương thức sẽ đọc màu đã tính; nó không gán màu mới.

Ví dụ sau in màu tự động của mỗi chuỗi mặc định:

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

Đầu ra mẫu cho kiểu biểu đồ mặc định:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Màu sắc chính xác phụ thuộc vào kiểu biểu đồ và chủ đề.

## **Đặt màu nền đảo ngược cho chuỗi biểu đồ**

Đối với các chuỗi thanh, cột và bong bóng, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) có thể hiển thị các giá trị âm bằng một màu nền khác. Đặt màu nền chuỗi thông thường thành đặc, bật tính năng đảo ngược, và gán màu giá trị âm qua [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Các số âm vẫn không thay đổi trong workbook; chỉ màu hiển thị của chúng thay đổi.

Ví dụ sau thay thế dữ liệu biểu đồ mặc định bằng một chuỗi. Hàng worksheet 0 chứa tên chuỗi, cột 0 chứa tên danh mục, và cột 1 chứa các giá trị:

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

Bạn có thể bật đảo ngược cho một điểm thông qua [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Trong ví dụ sau, đảo ngược bị tắt cho chuỗi và chỉ bật cho điểm đã chọn. Điểm này cũng được gán một giá trị âm để hiệu ứng hiển thị:

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

## **Xóa giá trị của một điểm dữ liệu cụ thể**

Để làm cho một điểm trống mà không xóa các điểm khác, đặt ô workbook hỗ trợ của nó thành `None`. Đối với biểu đồ cột, giá trị đã vẽ có thể truy cập qua [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/). Điểm dữ liệu vẫn ở cùng vị trí danh mục, nhưng biểu đồ sẽ coi giá trị của nó là trống theo cài đặt giá trị trống của biểu đồ.

Ví dụ sau chỉ xóa điểm thứ hai trong chuỗi đầu tiên:

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

Biểu đồ phân tán sử dụng các ô X và Y riêng biệt, và biểu đồ bong bóng còn sử dụng một ô kích thước. Chỉ xóa ô đại diện cho giá trị bạn muốn loại bỏ. Không gọi [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) khi bạn muốn giữ các điểm khác, vì phương thức đó sẽ xóa mọi điểm dữ liệu khỏi collection.

## **Kiểm soát việc hiển thị các ô trống**

Các ô ẩn chứa giá trị là một trường hợp riêng biệt so với các ô trống. Để bao gồm hoặc loại bỏ dữ liệu từ các hàng và cột worksheet ẩn, xem [Include Data from Hidden Rows and Columns](/slides/vi/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Một ô workbook trống đại diện cho dữ liệu thiếu; một ô chứa `0` đại diện cho một giá trị số đã biết. Đặt [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) thành `None` để làm ô trống. Số không vẫn là số không bất kể cài đặt ô trống.

Sử dụng [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) để chọn cách biểu đồ hiển thị các ô trống. Cài đặt này áp dụng cho toàn bộ biểu đồ. Nó thay đổi cách vẽ các ô trống, mà không điền ô workbook trống bằng số 0 hay một giá trị nội suy.

Ví dụ tự chứa sau tạo một biểu đồ đường với một chuỗi, xóa giá trị cho Ngày 3, và lưu cùng một biểu đồ với mỗi chế độ. Không cần tệp đầu vào. [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) sử dụng worksheet 0, cột 0 cho nhãn danh mục, và cột 1 cho các giá trị; hàng 0 chứa tên chuỗi. Dữ liệu cuối cùng là `10, 20, empty, 30, 40`.

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

    # Để Ngày 3 thực sự trống, trong khi vẫn giữ lại danh mục và điểm dữ liệu của nó.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Mỗi tệp đầu ra lưu chế độ đã gán trước khi lưu: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, và `empty_cells_Span.pptx`. Để lưu chỉ một phiên bản, gán chế độ mong muốn và lưu bản trình bày một lần thay vì lặp qua các chế độ.

So sánh bên dưới cho thấy cùng một dữ liệu trong cả ba tệp. Ngày 3 là ô trống trong workbook trong mọi trường hợp:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Hiệu ứng hiển thị phụ thuộc vào loại biểu đồ. Một biểu đồ đường làm cho ba chế độ dễ so sánh. Biểu đồ thanh và cột không có đường nối qua danh mục thiếu, vì vậy `SPAN` không thể tạo đoạn nối như trên; một cột thiếu và một cột chiều cao bằng 0 cũng có thể trông giống nhau. Tương tự, một biểu đồ phân tán chỉ có dấu hiệu không có đường nối. Đừng mong ba kết quả riêng biệt cho mọi loại biểu đồ; hãy kiểm tra kết quả đối với loại bạn sử dụng.

## **Đặt độ rộng khoảng cách giữa các chuỗi**

Độ rộng khoảng cách là khoảng cách giữa các cụm thanh hoặc cột liền kề, tính theo phần trăm của chiều rộng thanh hoặc cột. Giống như overlap, nó thuộc về nhóm chuỗi cha chứ không phải một chuỗi đơn lẻ. Đặt [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) một lần cho nhóm. Giá trị lớn hơn tạo nhiều không gian hơn giữa các cụm; giá trị nhỏ hơn làm chúng dày đặc hơn.

Ví dụ sau thay đổi độ rộng khoảng cách và chỉ lưu bản trình bày cuối cùng:

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

## **Câu hỏi thường gặp**

**Các loại biểu đồ nào hỗ trợ dữ liệu chuỗi?**

Tất cả các loại biểu đồ được đại diện bởi enum [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) đều sử dụng dữ liệu biểu đồ, nhưng chuỗi của chúng không phải luôn có cùng cấu trúc giá trị hoặc cài đặt. Ví dụ, biểu đồ danh mục sử dụng danh mục và giá trị, biểu đồ phân tán sử dụng giá trị X và Y, và biểu đồ bong bóng thêm kích thước bong bóng. Sử dụng phương pháp tạo điểm dữ liệu phù hợp với loại chuỗi. Các tùy chọn như overlap và gap width chỉ áp dụng cho các nhóm thanh hoặc cột tương thích.

**Nhóm chuỗi biểu đồ là gì?**

Một [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) chứa các chuỗi tương thích chia sẻ các cài đặt vẽ ở mức nhóm. Một biểu đồ kết hợp có thể chứa hơn một nhóm, vì vậy việc thay đổi nhóm thông qua một chuỗi không nhất thiết thay đổi mọi chuỗi trong biểu đồ.

**Một biểu đồ mới tạo có chứa dữ liệu mặc định không?**

Có. Theo mặc định, [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) tạo các chuỗi, danh mục và giá trị mẫu. Bạn có thể chỉnh sửa các ô đó hoặc xóa cả hai collection chuỗi và danh mục trước khi thêm một bộ dữ liệu tùy chỉnh hoàn toàn. Một overload cũng có thể tạo biểu đồ không có dữ liệu mặc định.

**Các đối tượng biểu đồ được kết nối với các ô workbook như thế nào?**

Tên chuỗi, nhãn danh mục và giá trị điểm dữ liệu tham chiếu đến các ô trong một [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/). Thay đổi một ô được tham chiếu sẽ cập nhật thành phần biểu đồ tương ứng. Khi bạn xây dựng dữ liệu tùy chỉnh, giữ các hàng danh mục và các hàng giá trị chuỗi đồng bộ để mỗi điểm được vẽ dưới danh mục dự định.

**Làm sao để xóa một điểm thay vì toàn bộ chuỗi?**

Đặt ô giá trị liên quan thành `None` để giữ vị trí danh mục của điểm như một điểm trống. Chỉ sử dụng [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) khi bạn muốn xóa tất cả các điểm trong chuỗi đó. Nếu bạn cũng xóa các danh mục, hãy cập nhật mọi chuỗi để giá trị của chúng vẫn đồng bộ với collection danh mục.

**Các điểm trống được hiển thị như thế nào?**

Kết quả phụ thuộc vào loại biểu đồ và [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/). Các biểu đồ được hỗ trợ có thể hiển thị ô trống dưới dạng khoảng trống, giá trị 0, hoặc bằng cách nối các điểm lân cận. Chọn cài đặt phù hợp với ý nghĩa của dữ liệu thiếu trong bản trình bày của bạn. Xem [Kiểm soát việc hiển thị các ô trống](#control-the-display-of-empty-cells) để xem ví dụ đầy đủ và so sánh hình ảnh.

**Các giá trị âm được định dạng như thế nào?**

Đối với các chuỗi thanh, cột và bong bóng được hỗ trợ, bật [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) và đặt [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Bạn có thể ghi đè hành vi cho một điểm riêng lẻ bằng [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Các thuộc tính này ảnh hưởng đến định dạng, không phải giá trị số đã lưu.

**Thuộc tính định dạng nào được ưu tiên khi cả chuỗi và điểm đều được định dạng?**

Định dạng điểm dữ liệu rõ ràng có ưu tiên cho điểm đó. Các điểm khác tiếp tục sử dụng định dạng chuỗi rõ ràng hoặc, khi không có định dạng chuỗi, sử dụng kiểu biểu đồ và chủ đề tự động. Các thuộc tính nhóm như overlap và gap width kiểm soát bố cục và không phải là các ghi đè định dạng mức điểm.

**Có giới hạn số lượng chuỗi mà một biểu đồ có thể chứa không?**

Aspose.Slides không áp đặt một giới hạn cố định riêng cho số chuỗi. Trong thực tế, các ràng buộc của tệp trình bày, bộ nhớ khả dụng, thời gian render và khả năng đọc của biểu đồ quyết định giới hạn thực tế.

**Tôi nên thay đổi gì khi các cột quá gần nhau hoặc quá xa?**

Đặt [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) trên nhóm chuỗi cha thích hợp. Tăng giá trị để mở rộng khoảng cách giữa các cụm, hoặc giảm giá trị để đưa các cụm lại gần nhau hơn.