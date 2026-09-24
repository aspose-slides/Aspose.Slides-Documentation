---
title: Quản lý Series dữ liệu biểu đồ trong các bản trình bày bằng Python
linktitle: Series dữ liệu
type: docs
url: /vi/python-net/chart-series/
keywords:
- series biểu đồ
- chồng lấn series
- màu series
- màu danh mục
- tên series
- điểm dữ liệu
- khoảng cách series
- PowerPoint
- bản trình bày
- Python
- Aspose.Slides
description: "Tìm hiểu cách quản lý series biểu đồ, điểm dữ liệu, ô workbook, định dạng, chồng lấn, khoảng cách gap, và giá trị âm trong các bản trình bày bằng Python."
---
## **Tổng quan**

Biểu đồ lưu trữ dữ liệu đã vẽ trong một workbook dữ liệu biểu đồ. Một [ChartSeries](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/) đại diện cho một tập các giá trị liên quan, và mỗi [ChartDataPoint](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapoint/) trong series tham chiếu đến một hoặc nhiều ô trong workbook. Các đối tượng [ChartCategory](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartcategory/) cung cấp các nhãn hoặc giá trị nhóm được chia sẻ bởi các series. Vì vậy, tên series, danh mục và giá trị điểm được liên kết với các đối tượng [ChartDataCell](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatacell/) thay vì chỉ được lưu dưới dạng văn bản hiển thị.

Đối với một biểu đồ danh mục tiêu biểu, workbook mặc định sử dụng hàng 0 cho tên series, cột 0 cho tên danh mục và các ô còn lại cho giá trị series. Các chỉ mục worksheet, hàng và cột truyền vào [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) đều bắt đầu từ 0. Bố cục này hữu ích khi bạn tạo biểu đồ với dữ liệu mặc định, nhưng không nên cho rằng mọi biểu đồ hiện có đều sử dụng nó. Đối với một bản trình bày đã tải, hãy kiểm tra các ô mà series, categories và data points tham chiếu trước khi thay đổi giá trị workbook.

Cài đặt biểu đồ có ba phạm vi khác nhau:

- Cài đặt ở mức series, chẳng hạn như [ChartSeries.format](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/format/), cung cấp giao diện mặc định cho tất cả các điểm trong một series.
- Cài đặt ở mức data-point, chẳng hạn như [ChartDataPoint.format](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapoint/format/), ghi đè giao diện series cho một điểm.
- Cài đặt nhóm áp dụng cho các series tương thích thuộc cùng một [ChartSeriesGroup](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseriesgroup/). Truy cập nhóm qua [ChartSeries.parent_series_group](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/parent_series_group/) khi bạn cần đặt các tùy chọn như overlap hoặc gap width.

Khi không có màu nền điểm hoặc series nào được chỉ định rõ ràng, kiểu biểu đồ và theme sẽ xác định giao diện tự động. Khi cả định dạng series và point đều tồn tại, định dạng point sẽ được ưu tiên cho điểm đó.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Đặt Overlap cho Series của Biểu đồ**

[ChartSeries.overlap](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/overlap/) báo cáo mức độ chồng lấn của các thanh hoặc cột trong biểu đồ 2D, từ -100 đến 100 phần trăm. Đây là một phép chiếu chỉ đọc của cài đặt trên nhóm series cha. Đặt [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseriesgroup/overlap/) để cập nhật mọi series tương thích trong nhóm đó. Tùy chọn này áp dụng cho các loại biểu đồ hiển thị các thanh hoặc cột được nhóm lại; nó không ảnh hưởng đến các nhóm series không liên quan trong biểu đồ kết hợp.

Ví dụ sau đặt overlap cho nhóm chứa series đầu tiên:

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

![Sự chồng lấn của series](series_overlap.png)

## **Thay đổi Màu nền Series**

Sử dụng [ChartSeries.format](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/format/) để đặt màu nền mặc định cho toàn bộ series. Nếu một điểm đã có màu nền rõ ràng, cài đặt [ChartDataPoint.format](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapoint/format/) của nó sẽ ghi đè màu nền series cho điểm đó.

Ví dụ sau áp dụng màu xanh đậm đặc cho series đầu tiên:

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

![Màu của series](series_color.png)

## **Thay đổi Tên Series**

Tên series được lưu trong workbook dữ liệu biểu đồ và thường được hiển thị trong legend. Trong workbook mặc định được tạo cho biểu đồ cột nhóm, ô B1 nằm ở hàng 0, cột 1 và chứa tên của series đầu tiên. Các hằng số được đặt tên trong ví dụ sau làm rõ cấu trúc này:

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

Bạn cũng có thể cập nhật ô đã được [ChartSeries.name](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/name/) tham chiếu. Cách này tránh việc giả định một hàng và cột cụ thể trong biểu đồ hiện có:

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

![Tên series](series_name.png)

## **Lấy Màu nền Series Tự động**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) trả về màu được tính dựa trên chỉ số series và kiểu biểu đồ. Đây là màu được sử dụng khi màu nền series không được định nghĩa rõ ràng. Gọi phương thức chỉ đọc màu đã tính; nó không gán màu mới.

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

Đầu ra mẫu cho kiểu biểu đồ mặc định:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Màu cụ thể phụ thuộc vào kiểu biểu đồ và theme.

## **Đặt Màu nền Đảo ngược cho Series**

Đối với series thanh, cột và bubble, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/invert_if_negative/) có thể hiển thị giá trị âm bằng một màu nền khác. Đặt màu nền series thường thành đặc, bật tính năng đảo ngược, và chỉ định màu cho giá trị âm qua [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Các số âm vẫn không thay đổi trong workbook; chỉ màu hiển thị của chúng thay đổi.

Ví dụ sau thay thế dữ liệu biểu đồ mặc định bằng một series. Hàng 0 của worksheet chứa tên series, cột 0 chứa tên danh mục, và cột 1 chứa các giá trị:

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

![Màu nền đặc đảo ngược](inverted_solid_fill_color.png)

Bạn có thể bật đảo ngược cho một điểm thông qua [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Trong ví dụ sau, đảo ngược được tắt cho series và chỉ bật cho điểm được chọn. Điểm này cũng được gán giá trị âm để hiệu ứng hiển thị:

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

## **Xóa Giá trị Data Point Cụ thể**

Để để một điểm trở nên trống mà không xóa các điểm khác, đặt ô workbook hỗ trợ nó thành `None`. Đối với biểu đồ cột, giá trị được vẽ có thể lấy qua [ChartDataPoint.value](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapoint/value/). Data point vẫn giữ vị trí danh mục, nhưng biểu đồ sẽ coi giá trị của nó là trống theo cài đặt giá trị trống của biểu đồ.

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

Biểu đồ scatter sử dụng các ô X và Y riêng biệt, và biểu đồ bubble còn sử dụng một ô kích thước. Chỉ xóa ô đại diện cho giá trị bạn muốn loại bỏ. Đừng gọi [ChartDataPointCollection.clear](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapointcollection/clear/) khi bạn muốn giữ các điểm còn lại, vì phương thức này sẽ xóa mọi data point trong collection.

## **Kiểm soát Hiển thị Các Ô Trống**

Một ô workbook trống đại diện cho dữ liệu thiếu; một ô chứa `0` đại diện cho một giá trị số đã biết. Đặt [ChartDataCell.value](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatacell/value/) thành `None` để làm ô trống. Số không vẫn là số không bất kể cài đặt ô trống.

Sử dụng [Chart.display_blanks_as](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/display_blanks_as/) để chọn cách biểu đồ hiển thị các ô trống. Cài đặt này áp dụng cho toàn bộ biểu đồ. Nó thay đổi cách các khoảng trống được vẽ, mà không điền ô workbook trống bằng số 0 hoặc giá trị nội suy.

Ví dụ tự chứa sau tạo một biểu đồ đường với một series, xóa giá trị cho Ngày 3, và lưu cùng một biểu đồ với mỗi chế độ. Không cần file đầu vào. [ChartDataWorkbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdataworkbook/) sử dụng worksheet 0, cột 0 cho nhãn danh mục, và cột 1 cho giá trị; hàng 0 giữ tên series. Dữ liệu cuối cùng là `10, 20, empty, 30, 40`.

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

    # Để ngày 3 thực sự trống, trong khi vẫn giữ lại danh mục và điểm dữ liệu của nó.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Mỗi file đầu ra lưu chế độ được chỉ định trước khi lưu: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, và `empty_cells_Span.pptx`. Để lưu chỉ một phiên bản, đặt chế độ mong muốn và lưu bản trình bày một lần thay vì lặp qua các chế độ.

So sánh dưới đây cho thấy cùng một dữ liệu trong ba file. Ngày 3 là trống trong workbook trong mọi trường hợp:

![Biểu đồ đường với dữ liệu giống nhau: Gap ngắt đường tại Ngày 3, Zero hạ đường xuống 0, và Span nối Ngày 2 tới Ngày 4.](display_blanks_as.png)

Hiệu ứng hiển thị phụ thuộc vào loại biểu đồ. Biểu đồ đường làm cho ba chế độ dễ so sánh. Biểu đồ thanh và cột không có đường nối qua danh mục thiếu, vì vậy `SPAN` không thể tạo đoạn nối như trên; một cột thiếu và một cột chiều cao 0 cũng có thể trông giống nhau. Tương tự, biểu đồ scatter chỉ có marker cũng không có đường nối. Đừng kỳ vọng ba kết quả khác nhau cho mọi loại biểu đồ; hãy kiểm tra đầu ra cho loại bạn đang dùng.

## **Đặt Khoảng Cách Gap Width cho Series**

Gap width là khoảng cách giữa các cụm thanh hoặc cột kề nhau, tính bằng phần trăm độ rộng của thanh hoặc cột. Giống như overlap, nó thuộc về nhóm series cha chứ không phải một series riêng. Đặt [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) một lần cho nhóm. Giá trị lớn hơn tạo nhiều khoảng hơn giữa các cụm; giá trị nhỏ hơn làm chúng dày đặc hơn.

Ví dụ sau thay đổi gap width và chỉ lưu bản trình bày cuối cùng:

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

![Khoảng cách gap width](gap_width.png)

## **Câu hỏi thường gặp**

**Các loại biểu đồ nào hỗ trợ series dữ liệu?**

Tất cả các loại biểu đồ được đại diện bởi enum [ChartType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/charttype/) đều sử dụng dữ liệu biểu đồ, nhưng series của chúng không có cùng cấu trúc giá trị hoặc cài đặt. Ví dụ, biểu đồ danh mục sử dụng categories và values, biểu đồ scatter sử dụng giá trị X và Y, và biểu đồ bubble còn thêm kích thước bubble. Hãy sử dụng phương pháp tạo data-point phù hợp với loại series. Các tùy chọn như overlap và gap width chỉ áp dụng cho các nhóm thanh hoặc cột tương thích.

**Series group là gì?**

Một [ChartSeriesGroup](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseriesgroup/) chứa các series tương thích chia sẻ các cài đặt vẽ mức nhóm. Một biểu đồ kết hợp có thể chứa hơn một nhóm, vì vậy việc thay đổi nhóm thông qua một series không nhất thiết thay đổi mọi series trong biểu đồ.

**Biểu đồ mới tạo có dữ liệu mặc định không?**

Có. Theo mặc định, [ShapeCollection.add_chart](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/add_chart/) tạo các series, categories và values mẫu. Bạn có thể chỉnh sửa các ô này hoặc xóa cả collection series và category trước khi thêm một bộ dữ liệu tùy chỉnh hoàn toàn. Một overload cũng có thể tạo biểu đồ mà không có dữ liệu mặc định.

**Các đối tượng biểu đồ được kết nối với các ô workbook như thế nào?**

Tên series, nhãn danh mục và giá trị data-point tham chiếu tới các ô trong một [ChartDataWorkbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdataworkbook/). Thay đổi một ô được tham chiếu sẽ cập nhật phần tử biểu đồ tương ứng. Khi bạn xây dựng dữ liệu tùy chỉnh, hãy giữ các hàng danh mục và hàng giá trị series căn chỉnh để mỗi point được vẽ dưới danh mục mong muốn.

**Làm sao để xóa một point mà không xóa toàn bộ series?**

Đặt ô giá trị liên quan thành `None` để giữ vị trí danh mục của point như một điểm trống. Chỉ sử dụng [ChartDataPointCollection.clear](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapointcollection/clear/) khi bạn muốn xóa tất cả các point trong series đó. Nếu bạn cũng xóa các category, hãy cập nhật mọi series sao cho giá trị của chúng vẫn căn chỉnh với collection category.

**Các điểm trống được hiển thị như thế nào?**

Kết quả phụ thuộc vào loại biểu đồ và [Chart.display_blanks_as](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/display_blanks_as/). Các biểu đồ được hỗ trợ có thể hiển thị khoảng trống dưới dạng gap, giá trị zero, hoặc bằng cách nối các điểm lân cận. Chọn cài đặt phù hợp với ý nghĩa của dữ liệu thiếu trong bản trình bày của bạn. Xem mục **Kiểm soát Hiển thị Các Ô Trống** để biết ví dụ đầy đủ và so sánh hình ảnh.

**Giá trị âm được định dạng như thế nào?**

Đối với các series thanh, cột và bubble được hỗ trợ, bật [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/invert_if_negative/) và đặt [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Bạn có thể ghi đè hành vi cho một point riêng lẻ bằng [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Các thuộc tính này ảnh hưởng đến định dạng, không phải giá trị số được lưu.

**Khi cả series và point đều được định dạng, thuộc tính nào thắng?**

Định dạng explicit của data-point có ưu tiên cho point đó. Các point khác vẫn sử dụng định dạng series explicit hoặc, nếu series không có định dạng, sẽ dùng kiểu và theme tự động của biểu đồ. Các thuộc tính nhóm như overlap và gap width kiểm soát bố cục và không phải là ghi đè định dạng mức point.

**Có giới hạn số series mà một biểu đồ có thể chứa không?**

Aspose.Slides không áp đặt một giới hạn cố định riêng cho số series. Trong thực tế, các ràng buộc của file trình bày, bộ nhớ khả dụng, thời gian render và khả năng đọc của biểu đồ quyết định giới hạn thực tế.

**Nên thay đổi gì khi các cột quá gần nhau hoặc quá xa?**

Đặt [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) trên nhóm series cha phù hợp. Tăng giá trị để làm rộng khoảng cách giữa các cụm, hoặc giảm giá trị để đưa các cụm lại gần nhau hơn.