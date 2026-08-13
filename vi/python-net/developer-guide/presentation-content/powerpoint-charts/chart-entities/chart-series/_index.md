---
title: Quản lý chuỗi dữ liệu biểu đồ trong bản trình chiếu bằng Python
linktitle: Chuỗi dữ liệu
type: docs
url: /vi/python-net/chart-series/
keywords:
- chuỗi biểu đồ
- chồng lớp chuỗi
- màu chuỗi
- màu danh mục
- tên chuỗi
- điểm dữ liệu
- khoảng cách chuỗi
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tìm hiểu cách quản lý chuỗi biểu đồ, điểm dữ liệu, ô workbook, định dạng, chồng lớp, độ rộng khoảng cách và giá trị âm trong bản trình chiếu bằng Python."
---
## **Tổng quan**

Một biểu đồ lưu trữ dữ liệu đã vẽ trong một workbook dữ liệu biểu đồ. Một [ChartSeries](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/) đại diện cho một tập hợp các giá trị liên quan, và mỗi [ChartDataPoint](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapoint/) trong chuỗi tham chiếu tới một hoặc nhiều ô workbook. Các đối tượng [ChartCategory](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartcategory/) cung cấp các nhãn hoặc giá trị nhóm được chia sẻ bởi các chuỗi. Vì vậy, tên chuỗi, các danh mục và giá trị điểm được kết nối với các đối tượng [ChartDataCell](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatacell/) thay vì chỉ được lưu dưới dạng văn bản hiển thị.

Đối với một biểu đồ danh mục điển hình, workbook mặc định sử dụng hàng 0 cho tên chuỗi, cột 0 cho tên danh mục và các ô còn lại cho giá trị chuỗi. Các chỉ mục worksheet, hàng và cột được truyền cho [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) là dựa trên số 0. Bố cục này hữu ích khi bạn tạo biểu đồ với dữ liệu mặc định, nhưng không nên cho rằng mọi biểu đồ hiện có đều sử dụng nó. Đối với một bản trình chiếu đã tải, hãy kiểm tra các ô mà các chuỗi, danh mục và điểm dữ liệu tham chiếu trước khi thay đổi giá trị workbook.

Cài đặt biểu đồ có ba phạm vi khác nhau:

- Cài đặt cấp chuỗi, chẳng hạn như [ChartSeries.format](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/format/), cung cấp giao diện mặc định cho tất cả các điểm trong một chuỗi.
- Cài đặt cấp điểm dữ liệu, chẳng hạn như [ChartDataPoint.format](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapoint/format/), ghi đè giao diện chuỗi cho một điểm.
- Cài đặt nhóm áp dụng cho các chuỗi tương thích thuộc cùng một [ChartSeriesGroup](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseriesgroup/). Truy cập nhóm qua [ChartSeries.parent_series_group](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/parent_series_group/) khi bạn cần đặt các tùy chọn như độ chồng nhau hoặc độ rộng khoảng trống.

Khi không có màu nền điểm hoặc chuỗi nào được đặt rõ ràng, kiểu biểu đồ và chủ đề sẽ quyết định giao diện tự động. Khi cả định dạng chuỗi và điểm đều có, định dạng điểm sẽ được ưu tiên cho điểm đó.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Đặt Độ Chồng Lên Của Chuỗi Biểu Đồ**

[ChartSeries.overlap](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/overlap/) cho biết các thanh hoặc cột chồng lên nhau bao nhiêu trong biểu đồ 2D, từ -100 đến 100 phần trăm. Đây là một phép chiếu chỉ đọc của cài đặt trên nhóm chuỗi cha. Đặt [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseriesgroup/overlap/) để cập nhật mọi chuỗi tương thích trong nhóm đó. Tùy chọn này áp dụng cho các loại biểu đồ hiển thị các thanh hoặc cột được nhóm; nó không ảnh hưởng đến các nhóm chuỗi không liên quan trong biểu đồ kết hợp.

Ví dụ sau đặt độ chồng cho nhóm chứa chuỗi đầu tiên:

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

## **Thay Đổi Màu Nền Của Chuỗi**

Sử dụng [ChartSeries.format](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/format/) để đặt màu nền mặc định cho toàn bộ một chuỗi. Nếu một điểm đã có màu nền rõ ràng, cài đặt [ChartDataPoint.format](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapoint/format/) của nó sẽ ghi đè màu nền chuỗi cho điểm đó.

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

## **Thay Đổi Tên Chuỗi**

Tên chuỗi được lưu trong workbook dữ liệu biểu đồ và thường hiển thị trong chú giải. Trong workbook mặc định được tạo cho biểu đồ cột nhóm, ô B1 nằm ở hàng 0, cột 1 và chứa tên của chuỗi đầu tiên. Các hằng số được đặt tên trong ví dụ sau làm cho cấu trúc này trở nên rõ ràng:

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

![The series name](series_name.png)

## **Lấy Màu Nền Tự Động Của Chuỗi**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) trả về màu được tính dựa trên chỉ mục chuỗi và kiểu biểu đồ. Đây là màu được sử dụng khi màu nền chuỗi không được định nghĩa rõ ràng. Gọi phương thức chỉ đọc màu đã tính; nó không gán màu nền mới.

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

Kết quả mẫu cho kiểu biểu đồ mặc định:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Màu sắc chính xác phụ thuộc vào kiểu biểu đồ và chủ đề.

## **Đặt Màu Nền Đảo Ngược Cho Chuỗi Biểu Đồ**

Đối với các chuỗi thanh, cột và bong bóng, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/invert_if_negative/) có thể hiển thị các giá trị âm bằng màu nền khác. Đặt màu nền chuỗi thường thành đặc, bật tính năng đảo ngược và chỉ định màu cho giá trị âm qua [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Các số âm không thay đổi trong workbook; chỉ màu hiển thị của chúng thay đổi.

Ví dụ sau thay thế dữ liệu biểu đồ mặc định bằng một chuỗi. Hàng 0 của worksheet chứa tên chuỗi, cột 0 chứa tên danh mục, và cột 1 chứa các giá trị:

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

Bạn có thể bật đảo ngược cho một điểm thông qua [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Trong ví dụ sau, đảo ngược được tắt cho chuỗi và chỉ bật cho điểm đã chọn. Điểm này cũng được gán giá trị âm để hiệu ứng hiển thị:

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

## **Xóa Giá Trị Của Một Điểm Dữ Liệu Cụ Thể**

Để làm cho một điểm trống mà không xóa các điểm khác, đặt ô workbook hỗ trợ của nó thành `None`. Đối với biểu đồ cột, giá trị đã vẽ có thể truy cập qua [ChartDataPoint.value](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapoint/value/). Điểm dữ liệu vẫn ở cùng vị trí danh mục, nhưng biểu đồ sẽ xem giá trị của nó là trống theo cài đặt giá trị trống của biểu đồ.

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

Biểu đồ phân tán sử dụng các ô X và Y riêng biệt, và biểu đồ bong bóng còn sử dụng một ô kích thước. Chỉ xóa ô đại diện cho giá trị bạn muốn loại bỏ. Không gọi [ChartDataPointCollection.clear](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapointcollection/clear/) khi bạn muốn giữ lại các điểm khác, vì phương thức này sẽ xóa mọi điểm dữ liệu trong tập hợp.

## **Đặt Độ Rộng Khoảng Cách Giữa Các Chuỗi**

Độ rộng khoảng cách là khoảng cách giữa các cụm thanh hoặc cột liền kề, biểu thị dưới dạng phần trăm so với chiều rộng thanh hoặc cột. Giống như độ chồng, nó thuộc về nhóm chuỗi cha chứ không phải một chuỗi riêng lẻ. Đặt [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) một lần cho nhóm. Giá trị lớn hơn tạo ra nhiều không gian hơn giữa các cụm; giá trị nhỏ hơn làm chúng dày đặc hơn.

Ví dụ sau thay đổi độ rộng khoảng cách và chỉ lưu bản trình chiếu cuối cùng:

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

**Những loại biểu đồ nào hỗ trợ chuỗi dữ liệu?**

Tất cả các loại biểu đồ được biểu diễn bằng liệt kê [ChartType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/charttype/) đều sử dụng dữ liệu biểu đồ, nhưng chuỗi của chúng không phải lúc nào cũng có cùng cấu trúc giá trị hoặc cài đặt. Ví dụ, biểu đồ danh mục sử dụng danh mục và giá trị, biểu đồ phân tán sử dụng giá trị X và Y, và biểu đồ bong bóng thêm kích thước bong bóng. Hãy sử dụng phương thức tạo điểm dữ liệu phù hợp với loại chuỗi. Các tùy chọn như độ chồng và độ rộng khoảng cách chỉ áp dụng cho các nhóm thanh hoặc cột tương thích.

**Nhóm chuỗi biểu đồ là gì?**

Một [ChartSeriesGroup](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseriesgroup/) chứa các chuỗi tương thích chia sẻ các cài đặt vẽ mức nhóm. Một biểu đồ kết hợp có thể chứa nhiều hơn một nhóm, vì vậy việc thay đổi nhóm thông qua một chuỗi không nhất thiết thay đổi mọi chuỗi trong biểu đồ.

**Biểu đồ mới tạo có chứa dữ liệu mặc định không?**

Có. Mặc định, [ShapeCollection.add_chart](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/add_chart/) tạo các chuỗi, danh mục và giá trị mẫu. Bạn có thể chỉnh sửa các ô đó hoặc xóa cả hai tập hợp chuỗi và danh mục trước khi thêm một bộ dữ liệu tùy chỉnh hoàn toàn. Một overload cũng có thể tạo biểu đồ mà không có dữ liệu mặc định.

**Các đối tượng biểu đồ được kết nối với các ô workbook như thế nào?**

Tên chuỗi, nhãn danh mục và giá trị điểm dữ liệu tham chiếu tới các ô trong một [ChartDataWorkbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdataworkbook/). Thay đổi một ô được tham chiếu sẽ cập nhật phần tử biểu đồ tương ứng. Khi bạn xây dựng dữ liệu tùy chỉnh, hãy giữ các hàng danh mục và các hàng giá trị chuỗi đồng bộ để mỗi điểm được vẽ dưới danh mục mong muốn.

**Làm sao để xóa một điểm thay vì toàn bộ chuỗi?**

Đặt ô giá trị liên quan thành `None` để giữ vị trí danh mục của điểm đó dưới dạng điểm trống. Chỉ sử dụng [ChartDataPointCollection.clear](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapointcollection/clear/) khi bạn muốn xóa mọi điểm trong chuỗi đó. Nếu bạn cũng xóa các danh mục, hãy cập nhật mọi chuỗi để các giá trị của chúng vẫn đồng bộ với tập hợp danh mục.

**Các điểm trống được hiển thị như thế nào?**

Kết quả phụ thuộc vào loại biểu đồ và [Chart.display_blanks_as](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/display_blanks_as/). Các biểu đồ được hỗ trợ có thể hiển thị các khoảng trống dưới dạng khoảng cách, giá trị 0, hoặc bằng cách nối các điểm lân cận. Chọn cài đặt phù hợp với ý nghĩa của dữ liệu thiếu trong bản trình chiếu của bạn.

**Các giá trị âm được định dạng như thế nào?**

Đối với các chuỗi thanh, cột và bong bóng được hỗ trợ, bật [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/invert_if_negative/) và đặt [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Bạn có thể ghi đè hành vi cho một điểm cá nhân bằng [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Các thuộc tính này ảnh hưởng tới định dạng, không phải giá trị số được lưu.

**Định dạng nào ưu tiên khi cả chuỗi và điểm đều được định dạng?**

Định dạng điểm dữ liệu rõ ràng sẽ được ưu tiên cho điểm đó. Các điểm khác sẽ tiếp tục sử dụng định dạng chuỗi rõ ràng hoặc, khi không có định dạng chuỗi, sẽ dùng kiểu biểu đồ và chủ đề tự động. Các thuộc tính nhóm như độ chồng và độ rộng khoảng cách kiểm soát bố cục và không phải là ghi đè định dạng cấp điểm.

**Có giới hạn số lượng chuỗi mà một biểu đồ có thể chứa không?**

Aspose.Slides không áp đặt một giới hạn cố định cho số chuỗi. Trong thực tế, các hạn chế của tệp bản trình chiếu, bộ nhớ khả dụng, thời gian render và khả năng đọc hiểu biểu đồ sẽ quyết định một giới hạn thực tế.

**Tôi nên thay đổi gì khi các cột quá gần nhau hoặc quá xa?**

Đặt [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) trên nhóm chuỗi cha thích hợp. Tăng giá trị để mở rộng không gian giữa các cụm, hoặc giảm nó để các cụm lại gần nhau hơn.