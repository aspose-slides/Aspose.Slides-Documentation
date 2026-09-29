---
title: Quản lý Series Dữ liệu Biểu đồ trong Bài thuyết trình bằng Python
linktitle: Series Dữ liệu
type: docs
url: /vi/python-net/chart-series/
keywords:
- series biểu đồ
- độ chồng series
- màu series
- màu danh mục
- tên series
- điểm dữ liệu
- khoảng cách series
- PowerPoint
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tìm hiểu cách quản lý series biểu đồ, các điểm dữ liệu, ô workbook, định dạng, độ chồng, độ rộng khoảng cách và giá trị âm trong các bài thuyết trình bằng Python."
---
## **Tổng quan**

Biểu đồ lưu trữ dữ liệu đã vẽ trong một workbook dữ liệu biểu đồ. Một **ChartSeries** đại diện cho một tập hợp các giá trị có liên quan, và mỗi **ChartDataPoint** trong series tham chiếu tới một hoặc nhiều ô trong workbook. Các đối tượng **ChartCategory** cung cấp các nhãn hoặc giá trị nhóm được chia sẻ bởi các series. Vì vậy, tên series, các danh mục và giá trị điểm được kết nối tới các đối tượng **ChartDataCell** thay vì chỉ được lưu dưới dạng văn bản hiển thị.

Đối với một biểu đồ danh mục điển hình, workbook mặc định sử dụng hàng 0 cho tên series, cột 0 cho tên danh mục, và các ô còn lại cho các giá trị series. Các chỉ mục worksheet, hàng và cột được truyền tới **[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdataworkbook/get_cell/)** là dạng chỉ số bắt đầu từ 0. Bố cục này hữu ích khi bạn tạo biểu đồ với dữ liệu mặc định, nhưng không nên giả định rằng mọi biểu đồ hiện có đều sử dụng nó. Đối với một bản trình bày đã tải, hãy kiểm tra các ô được series, danh mục và điểm dữ liệu tham chiếu trước khi thay đổi giá trị trong workbook.

Cài đặt biểu đồ có ba phạm vi khác nhau:

- Cài đặt cấp **Series**, như **[ChartSeries.format](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/format/)**, cung cấp diện mạo mặc định cho tất cả các điểm trong một series.
- Cài đặt cấp **Data‑point**, như **[ChartDataPoint.format](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapoint/format/)**, ghi đè lên diện mạo của series cho một điểm.
- Cài đặt **Group** áp dụng cho các series tương thích thuộc cùng một **[ChartSeriesGroup](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseriesgroup/)**. Truy cập nhóm qua **[ChartSeries.parent_series_group](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/parent_series_group/)** khi cần đặt các tùy chọn như độ chồng lên hay độ rộng khoảng cách.

Khi không có màu nền điểm hoặc series nào được đặt rõ ràng, kiểu biểu đồ và chủ đề sẽ xác định diện mạo tự động. Khi cả hai đều có định dạng, định dạng điểm sẽ được ưu tiên cho điểm đó.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Đặt Độ chồng Lên của Series Biểu Đồ**

**[ChartSeries.overlap](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/overlap/)** báo cáo mức độ chồng lên của các thanh hoặc cột trong biểu đồ 2D, từ -100 tới 100 phần trăm. Đây là một phép chiếu chỉ đọc của cài đặt trên nhóm series cha. Đặt **[ChartSeriesGroup.overlap](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseriesgroup/overlap/)** để cập nhật mọi series tương thích trong nhóm đó. Tùy chọn này áp dụng cho các loại biểu đồ hiển thị các thanh hoặc cột được nhóm lại; nó không ảnh hưởng đến các nhóm series không liên quan trong biểu đồ kết hợp.

Ví dụ sau đặt độ chồng lên cho nhóm chứa series đầu tiên:

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

Sử dụng **[ChartSeries.format](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/format/)** để đặt màu nền mặc định cho toàn bộ series. Nếu một điểm đã có màu nền rõ ràng, cài đặt **[ChartDataPoint.format](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapoint/format/)** của nó sẽ ghi đè lên màu nền của series cho điểm đó.

Ví dụ sau áp dụng màu nền xanh đậm đặc cho series đầu tiên:

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

Tên series được lưu trong workbook dữ liệu biểu đồ và thường được hiển thị trong chú giải. Trong workbook mặc định được tạo cho biểu đồ cột cụm, ô B1 nằm ở hàng 0, cột 1 và chứa tên của series đầu tiên. Các hằng số được đặt tên trong ví dụ dưới đây làm cho cấu trúc này trở nên rõ ràng:

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

Bạn cũng có thể cập nhật ô đã được **[ChartSeries.name](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/name/)** tham chiếu. Cách này tránh việc giả định một hàng và cột cụ thể trong biểu đồ hiện có:

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

## **Lấy Màu Nền Series Tự Động**

**[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/)** trả về màu được tính dựa trên chỉ mục series và kiểu biểu đồ. Đây là màu được sử dụng khi màu nền của series chưa được định nghĩa rõ ràng. Gọi phương thức này chỉ đọc màu đã tính; nó không gán màu nền mới.

Ví dụ sau in ra màu tự động của mỗi series mặc định:

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

## **Đặt Màu Nền Đảo Ngược cho Series Biểu Đồ**

Đối với series thanh, cột và bong bóng, **[ChartSeries.invert_if_negative](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/invert_if_negative/)** có thể hiển thị các giá trị âm với màu nền khác. Đặt màu nền series thông thường thành đặc, bật tính năng đảo ngược, và chỉ định màu cho giá trị âm qua **[ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/)**. Các số âm không thay đổi trong workbook; chỉ màu hiển thị của chúng thay đổi.

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

![The inverted solid fill color](inverted_solid_fill_color.png)

Bạn có thể bật đảo ngược cho một điểm thông qua **[ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/)**. Trong ví dụ dưới đây, tính năng đảo ngược bị tắt cho series và chỉ bật cho điểm đã chọn. Điểm này cũng được gán giá trị âm để hiệu ứng hiển thị:

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

Để làm cho một điểm trống mà không xóa các điểm khác, đặt ô workbook hỗ trợ nó thành `None`. Đối với biểu đồ cột, giá trị đã vẽ có thể truy cập qua **[ChartDataPoint.value](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapoint/value/)**. Điểm dữ liệu vẫn giữ nguyên vị trí danh mục, nhưng biểu đồ sẽ coi giá trị của nó là trống theo cài đặt giá trị trống của biểu đồ.

Ví dụ sau xóa chỉ điểm thứ hai trong series đầu tiên:

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

Biểu đồ phân tán sử dụng các ô X và Y riêng biệt, và biểu đồ bong bóng còn sử dụng một ô kích thước. Chỉ xóa ô đại diện cho giá trị bạn muốn loại bỏ. Không gọi **[ChartDataPointCollection.clear](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapointcollection/clear/)** khi bạn muốn giữ lại các điểm khác, vì phương thức này sẽ xóa mọi điểm dữ liệu khỏi collection.

## **Kiểm Soát Hiển Thị Ô Trống**

Các ô ẩn chứa giá trị là một trường hợp riêng so với các ô trống. Để bao gồm hoặc loại trừ dữ liệu từ các hàng và cột worksheet ẩn, xem mục **[Include Data from Hidden Rows and Columns](/slides/vi/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns)**.

Một ô workbook trống đại diện cho dữ liệu thiếu; một ô chứa `0` đại diện cho một giá trị số đã biết. Đặt **[ChartDataCell.value](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatacell/value/)** thành `None` để làm ô trở nên trống. Số không vẫn giữ là số không bất kể cài đặt ô trống như thế nào.

Sử dụng **[Chart.display_blanks_as](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/display_blanks_as/)** để chọn cách biểu đồ hiển thị các ô trống. Cài đặt này áp dụng cho toàn bộ biểu đồ. Nó thay đổi cách các ô trống được vẽ, mà không điền ô workbook trống bằng số 0 hay một giá trị nội suy.

Ví dụ tự chứa sau tạo một biểu đồ đường với một series, xóa giá trị cho Ngày 3, và lưu cùng một biểu đồ với mỗi chế độ. Không cần tệp đầu vào. **[ChartDataWorkbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdataworkbook/)** sử dụng worksheet 0, cột 0 cho nhãn danh mục, và cột 1 cho giá trị; hàng 0 chứa tên series. Dữ liệu cuối cùng là `10, 20, empty, 30, 40`.

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

Mỗi tệp đầu ra lưu chế độ đã được gán trước khi lưu: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, và `empty_cells_Span.pptx`. Để lưu chỉ một phiên bản, gán chế độ mong muốn và lưu bản trình bày một lần thay vì lặp qua các chế độ.

Bảng so sánh dưới đây cho thấy cùng một dữ liệu trong cả ba tệp. Ngày 3 là trống trong workbook trong mọi trường hợp:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Hiệu ứng hiển thị phụ thuộc vào loại biểu đồ. Biểu đồ đường làm cho ba chế độ dễ so sánh. Biểu đồ thanh và cột không có đường nối qua danh mục thiếu, vì vậy `SPAN` không thể tạo đoạn nối như trên; một cột thiếu và một cột có chiều cao 0 cũng có thể trông giống nhau. Tương tự, biểu đồ phân tán chỉ có đánh dấu mà không có đường nối. Không nên mong đợi ba kết quả riêng biệt cho mọi loại biểu đồ; hãy kiểm tra đầu ra cho loại bạn đang dùng.

## **Đặt Độ Rộng Khoảng Cách Giữa Series**

Độ rộng khoảng cách là khoảng cách giữa các cụm thanh hoặc cột kề nhau, được biểu thị bằng phần trăm của độ rộng thanh hoặc cột. Giống như độ chồng, nó thuộc nhóm series cha chứ không phải một series đơn lẻ. Đặt **[ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseriesgroup/gap_width/)** một lần cho toàn nhóm. Giá trị lớn hơn tạo ra nhiều không gian hơn giữa các cụm; giá trị nhỏ hơn làm chúng dày đặc hơn.

Ví dụ sau thay đổi độ rộng khoảng cách và lưu chỉ bản trình bày cuối cùng:

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

## **FAQ**

**Các loại biểu đồ nào hỗ trợ series dữ liệu?**

Tất cả các loại biểu đồ được đại diện bởi liệt kê **[ChartType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/charttype/)** sử dụng dữ liệu biểu đồ, nhưng các series của chúng không phải tất cả đều có cùng cấu trúc giá trị hay cài đặt. Ví dụ, biểu đồ danh mục sử dụng danh mục và giá trị, biểu đồ phân tán sử dụng giá trị X và Y, và biểu đồ bong bóng thêm kích thước bong bóng. Hãy sử dụng phương pháp tạo điểm dữ liệu phù hợp với loại series. Các tùy chọn như độ chồng và độ rộng khoảng cách chỉ áp dụng cho các nhóm thanh hoặc cột tương thích.

**Series Group là gì?**

Một **[ChartSeriesGroup](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseriesgroup/)** chứa các series tương thích chia sẻ các cài đặt vẽ ở mức nhóm. Một biểu đồ kết hợp có thể chứa hơn một nhóm, vì vậy việc thay đổi nhóm được truy cập qua một series không nhất thiết thay đổi mọi series trong biểu đồ.

**Biểu đồ mới tạo có chứa dữ liệu mặc định không?**

Có. Theo mặc định, **[ShapeCollection.add_chart](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/add_chart/)** tạo các series, danh mục và giá trị mẫu. Bạn có thể chỉnh sửa các ô đó hoặc xóa cả hai collection series và category trước khi thêm một bộ dữ liệu tùy chỉnh hoàn toàn. Một overload cũng có thể tạo biểu đồ không có dữ liệu mặc định.

**Các đối tượng biểu đồ được kết nối với các ô workbook như thế nào?**

Tên series, nhãn danh mục và giá trị điểm dữ liệu tham chiếu đến các ô trong **[ChartDataWorkbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdataworkbook/)**. Thay đổi một ô được tham chiếu sẽ cập nhật phần tử biểu đồ tương ứng. Khi bạn xây dựng dữ liệu tùy chỉnh, hãy giữ các hàng danh mục và các hàng giá trị series đồng bộ để mỗi điểm được vẽ dưới danh mục mong muốn.

**Làm sao để xóa một điểm mà không xóa toàn bộ series?**

Đặt ô giá trị liên quan thành `None` để giữ vị trí danh mục của điểm như một điểm trống. Chỉ sử dụng **[ChartDataPointCollection.clear](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapointcollection/clear/)** khi bạn muốn xóa tất cả các điểm khỏi series đó. Nếu bạn cũng xóa các danh mục, hãy cập nhật mọi series để giá trị của chúng vẫn đồng bộ với collection danh mục.

**Các điểm trống được hiển thị như thế nào?**

Kết quả phụ thuộc vào loại biểu đồ và **[Chart.display_blanks_as](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/display_blanks_as/)**. Các biểu đồ được hỗ trợ có thể hiển thị ô trống dưới dạng khoảng trống, giá trị 0, hoặc nối các điểm lân cận. Chọn cài đặt phù hợp với ý nghĩa của dữ liệu thiếu trong bản trình bày của bạn. Xem mục **[Control the Display of Empty Cells](#control-the-display-of-empty-cells)** để xem ví dụ đầy đủ và so sánh trực quan.

**Giá trị âm được định dạng như thế nào?**

Đối với các series thanh, cột và bong bóng được hỗ trợ, bật **[ChartSeries.invert_if_negative](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/invert_if_negative/)** và đặt **[ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/)**. Bạn có thể ghi đè hành vi cho một điểm riêng lẻ bằng **[ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/)**. Các thuộc tính này ảnh hưởng đến định dạng, không phải các giá trị số được lưu.

**Thuộc tính nào thắng khi cả series và điểm đều được định dạng?**

Định dạng điểm dữ liệu rõ ràng sẽ ưu tiên cho điểm đó. Các điểm khác sẽ tiếp tục sử dụng định dạng series rõ ràng hoặc, khi series không có định dạng, sẽ dùng kiểu và chủ đề biểu đồ tự động. Các thuộc tính nhóm như độ chồng và độ rộng khoảng cách điều khiển bố cục và không phải là các ghi đè định dạng cấp điểm.

**Có giới hạn số lượng series mà một biểu đồ có thể chứa không?**

**Aspose.Slides** không đặt một giới hạn cố định cho số series. Thực tế, các ràng buộc của tệp trình bày, bộ nhớ khả dụng, thời gian render và khả năng đọc của biểu đồ sẽ quyết định một giới hạn thực tế.

**Nên thay đổi gì khi các cột quá gần nhau hoặc quá xa?**

Đặt **[ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseriesgroup/gap_width/)** trên nhóm series cha thích hợp. Tăng giá trị để mở rộng khoảng cách giữa các cụm, hoặc giảm giá trị để đưa các cụm lại gần nhau hơn.