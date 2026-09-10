---
title: Tạo hoặc Cập nhật Biểu đồ Bài thuyết trình PowerPoint trong Python
linktitle: Tạo hoặc Cập nhật Biểu đồ
type: docs
weight: 10
url: /vi/python-net/create-chart/
keywords:
- thêm biểu đồ
- tạo biểu đồ
- chỉnh sửa biểu đồ
- thay đổi biểu đồ
- cập nhật biểu đồ
- biểu đồ phân tán
- biểu đồ tròn
- biểu đồ đường
- biểu đồ cây
- biểu đồ cổ phiếu
- biểu đồ hộp và râu
- biểu đồ phễu
- biểu đồ mặt trời
- biểu đồ histogram
- biểu đồ radar
- biểu đồ đa danh mục
- bản thuyết trình PowerPoint
- Python
- Aspose.Slides
description: "Tìm hiểu cách tạo và tùy chỉnh biểu đồ trong các bản thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides cho Python thông qua .NET. Nội dung bao gồm việc thêm, định dạng và chỉnh sửa biểu đồ trong bản thuyết trình với các ví dụ mã thực tế bằng Python."
---
## **Tổng quan**

Bài viết này giải thích cách tạo và tùy chỉnh biểu đồ bằng Aspose.Slides cho Python thông qua .NET. Bạn sẽ học cách thêm biểu đồ vào một slide, điền dữ liệu vào và định dạng nó để phù hợp với yêu cầu thiết kế của bạn. Các ví dụ mã bao gồm tạo bài thuyết trình và biểu đồ, cấu hình series, trục và chú giải, và tích hợp việc tạo biểu đồ vào các ứng dụng của bạn.

## **Tạo biểu đồ**

Biểu đồ giúp mọi người nhanh chóng hình dung dữ liệu và rút ra những hiểu biết mà có thể không ngay lập tức rõ ràng từ bảng hoặc bảng tính.

**Tại sao nên tạo biểu đồ?**

Sử dụng biểu đồ, bạn có thể:

* tổng hợp, rút gọn hoặc tóm tắt một lượng lớn dữ liệu trên một slide trong bản trình chiếu;
* phát hiện các mẫu và xu hướng trong dữ liệu;
* suy diễn hướng và động lực của dữ liệu theo thời gian hoặc dựa trên một đơn vị đo lường cụ thể;
* phát hiện các ngoại lệ, sai lệch, lỗi và dữ liệu vô nghĩa;
* truyền đạt hoặc trình bày dữ liệu phức tạp.

Trong PowerPoint, bạn có thể tạo biểu đồ qua chức năng *Insert*, cung cấp các mẫu để thiết kế nhiều loại biểu đồ. Sử dụng Aspose.Slides, bạn có thể tạo cả biểu đồ thông thường (dựa trên các loại biểu đồ phổ biến) và biểu đồ tùy chỉnh.

{{% alert color="info" title="Note" %}}

Sử dụng enumeration [ChartType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/charttype/) trong không gian tên [Aspose.Slides.Charts](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/). Các giá trị trong enumeration này tương ứng với các loại biểu đồ khác nhau.

{{% /alert %}}

### **Tạo biểu đồ Cột Nhóm (Clustered Column)**

Phần này giải thích cách tạo biểu đồ cột nhóm bằng Aspose.Slides cho Python thông qua .NET. Bạn sẽ học cách khởi tạo một bài thuyết trình, thêm một biểu đồ và tùy chỉnh các thành phần như tiêu đề, dữ liệu, series, danh mục và kiểu dáng. Thực hiện các bước dưới đây để xem cách một biểu đồ cột nhóm tiêu chuẩn được tạo ra:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.
1. Thêm một biểu đồ với một số dữ liệu và chỉ định loại `ChartType.CLUSTERED_COLUMN`.
1. Thêm tiêu đề cho biểu đồ.
1. Truy cập worksheet dữ liệu của biểu đồ.
1. Xóa tất cả series và danh mục mặc định.
1. Thêm series và danh mục mới.
1. Thêm dữ liệu biểu đồ mới cho series.
1. Áp dụng màu nền cho series.
1. Thêm nhãn cho series.
1. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã Python này minh họa cách tạo biểu đồ cột nhóm:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Khởi tạo lớp Presentation đại diện cho tệp PPTX.
with slides.Presentation() as presentation:

    # Truy cập slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm biểu đồ cột nhóm với dữ liệu mặc định.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Đặt tiêu đề biểu đồ.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Đặt chỉ mục của bảng dữ liệu biểu đồ.
    worksheet_index = 0

    # Lấy workbook dữ liệu biểu đồ.
    workbook = chart.chart_data.chart_data_workbook

    # Xóa series và danh mục được tạo mặc định.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Thêm series mới.
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

    # Thêm danh mục mới.
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

    # Lấy series biểu đồ đầu tiên.
    series = chart.chart_data.series[0]

    # Điền dữ liệu cho series.
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # Đặt màu nền cho series.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Lấy series biểu đồ thứ hai.
    series = chart.chart_data.series[1]

    # Điền dữ liệu cho series.
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    # Đặt màu nền cho series.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    # Đặt nhãn đầu tiên để hiển thị tên danh mục.
    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    # Đặt series để hiển thị giá trị cho nhãn thứ ba.
    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"
                
    # Lưu bản thuyết trình ra đĩa dưới dạng tệp PPTX.
    presentation.save("ClusteredColumnChart.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The clustered column chart](clustered_column_chart.png)

### **Tạo biểu đồ Phân tán (Scatter)**

Biểu đồ phân tán (còn gọi là scatter plot hoặc đồ thị x‑y) thường được dùng để kiểm tra các mẫu hoặc minh họa tương quan giữa hai biến.

Sử dụng biểu đồ phân tán khi:

* Bạn có dữ liệu số cặp.
* Bạn có hai biến tương thích với nhau.
* Bạn muốn xác định liệu hai biến có liên quan hay không.
* Bạn có một biến độc lập có nhiều giá trị cho một biến phụ thuộc.

Mã Python này cho thấy cách tạo biểu đồ phân tán với các ký hiệu khác nhau cho mỗi series:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Khởi tạo lớp Presentation.
with slides.Presentation() as presentation:

    # Truy cập slide đầu tiên.
    slide = presentation.slides[0]

    # Tạo biểu đồ phân tán mặc định.
    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 20, 20, 500, 300)

    # Đặt chỉ mục của bảng dữ liệu biểu đồ.
    worksheet_index = 0

    # Lấy workbook dữ liệu biểu đồ.
    workbook = chart.chart_data.chart_data_workbook

    # Xóa series mặc định.
    chart.chart_data.series.clear()

    # Thêm series mới.
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 3, "Series 2"), chart.type)

    # Lấy series biểu đồ đầu tiên.
    series = chart.chart_data.series[0]

    # Thêm một điểm mới (1:3) vào series.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 1, 1), workbook.get_cell(worksheet_index, 2, 2, 3))

    # Thêm một điểm mới (2:10).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 1, 2), workbook.get_cell(worksheet_index, 3, 2, 10))

    # Thay đổi loại series.
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # Thay đổi ký hiệu series biểu đồ.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # Lấy series biểu đồ thứ hai.
    series = chart.chart_data.series[1]

    # Thêm một điểm mới (5:2) vào series biểu đồ.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 5), workbook.get_cell(worksheet_index, 2, 4, 2))

    # Thêm một điểm mới (3:1).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 3, 3), workbook.get_cell(worksheet_index, 3, 4, 1))

    # Thêm một điểm mới (2:2).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 4, 3, 2), workbook.get_cell(worksheet_index, 4, 4, 2))

    # Thêm một điểm mới (5:1).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 5, 3, 5), workbook.get_cell(worksheet_index, 5, 4, 1))

    # Thay đổi ký hiệu series biểu đồ.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("ScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The scatter chart](scatter_chart.png)

### **Tạo biểu đồ Tròn (Pie)**

Biểu đồ tròn thích hợp nhất để hiển thị mối quan hệ phần‑trên‑toàn trong dữ liệu, đặc biệt khi dữ liệu có các nhãn phân loại với giá trị số. Tuy nhiên, nếu dữ liệu của bạn chứa nhiều phần hoặc nhãn, bạn có thể cân nhắc sử dụng biểu đồ cột thay thế.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.
1. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại `ChartType.PIE`.
1. Truy cập workbook dữ liệu của biểu đồ ([ChartDataWorkbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Xóa series và danh mục mặc định.
1. Thêm series và danh mục mới.
1. Thêm dữ liệu biểu đồ mới cho series.
1. Thêm các điểm mới cho biểu đồ và áp dụng màu tùy chỉnh cho các phần của biểu đồ tròn.
1. Đặt nhãn cho các series.
1. Bật đường dẫn (leader lines) cho nhãn series.
1. Đặt góc quay cho biểu đồ tròn.
1. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã Python này cho thấy cách tạo biểu đồ tròn:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Khởi tạo lớp Presentation đại diện cho tệp PPTX.
with slides.Presentation() as presentation:

    # Truy cập slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm biểu đồ với dữ liệu mặc định.
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    # Đặt tiêu đề biểu đồ.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Đặt chỉ mục của bảng dữ liệu biểu đồ.
    worksheet_index = 0

    # Lấy workbook dữ liệu biểu đồ.
    workbook = chart.chart_data.chart_data_workbook

    # Xóa series và danh mục được tạo mặc định.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Thêm danh mục mới.
    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "First Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "2nd Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "3rd Qtr"))

    # Thêm series mới.
    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # Điền dữ liệu cho series.
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # Đặt màu cho phần của biểu đồ.
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan

    # Đặt viền cho phần của biểu đồ.
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # Đặt viền cho phần của biểu đồ.
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # Đặt viền cho phần của biểu đồ.
    point2.format.line.fill_format.fill_type = slides.FillType.SOLID
    point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
    point2.format.line.width = 2.0
    point2.format.line.style = slides.LineStyle.THIN_THIN
    point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    # Tạo nhãn tùy chỉnh cho mỗi danh mục trong series mới.
    label1 = series.data_points[0].label

    label1.data_label_format.show_value = True

    label2 = series.data_points[1].label
    label2.data_label_format.show_value = True
    label2.data_label_format.show_legend_key = True
    label2.data_label_format.show_percentage = True

    label3 = series.data_points[2].label
    label3.data_label_format.show_series_name = True
    label3.data_label_format.show_percentage = True

    # Đặt series hiển thị đường dẫn cho biểu đồ.
    series.labels.default_data_label_format.show_leader_lines = True

    # Đặt góc quay cho các phần của biểu đồ tròn.
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # Lưu bản thuyết trình ra đĩa dưới dạng tệp PPTX.
    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The pie chart](pie_chart.png)

### **Tạo biểu đồ Đường (Line)**

Biểu đồ đường (còn gọi là line graph) thích hợp trong các tình huống bạn muốn minh họa sự thay đổi giá trị theo thời gian. Bằng một biểu đồ đường, bạn có thể so sánh một lượng lớn dữ liệu cùng lúc, theo dõi các thay đổi và xu hướng theo thời gian, làm nổi bật các bất thường trong series dữ liệu, và hơn nữa.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.
1. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại `ChartType.LINE`.
1. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã Python này cho thấy cách tạo biểu đồ đường:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 20, 20, 500, 300)
    
    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```

Mặc định, các điểm trên biểu đồ đường được nối bằng các đường thẳng liên tục. Nếu bạn muốn các điểm được nối bằng dấu gạch nối, bạn có thể chỉ định kiểu dash mong muốn như sau:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

    for series in line_chart.chart_data.series:
        series.format.line.dash_style = slides.LineDashStyle.DASH

    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The line chart](line_chart.png)

### **Tạo biểu đồ Cây (Tree Map)**

Biểu đồ cây thích hợp cho dữ liệu bán hàng khi bạn muốn hiển thị kích thước tương đối của các danh mục dữ liệu và nhanh chóng thu hút sự chú ý tới các mục đóng góp lớn trong mỗi danh mục.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.
1. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại `ChartType.TREEMAP`.
1. Truy cập workbook dữ liệu của biểu đồ ([ChartDataWorkbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Xóa series và danh mục mặc định.
1. Thêm series và danh mục mới.
1. Thêm dữ liệu biểu đồ mới cho series.
1. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã Python này cho thấy cách tạo biểu đồ cây:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.TREEMAP, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Nhánh 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # Nhánh 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D8", 3))

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    presentation.save("TreeMap.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The treemap chart](treemap_chart.png)

### **Tạo biểu đồ Cổ phiếu (Stock)**

Biểu đồ cổ phiếu được dùng để hiển thị dữ liệu tài chính như giá mở cửa, cao nhất, thấp nhất và đóng cửa, hỗ trợ phân tích xu hướng thị trường và biến động. Chúng cung cấp những hiểu biết quan trọng về hiệu suất cổ phiếu, giúp nhà đầu tư và nhà phân tích đưa ra quyết định có cơ sở.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.
1. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại `ChartType.OPEN_HIGH_LOW_CLOSE`.
1. Truy cập workbook dữ liệu của biểu đồ ([ChartDataWorkbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Xóa series và danh mục mặc định.
1. Thêm series và danh mục mới.
1. Thêm dữ liệu biểu đồ mới cho series.
1. Chỉ định định dạng đường cao-thấp.
1. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã Python này cho thấy cách tạo biểu đồ cổ phiếu:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 20, 20, 500, 300, False)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "A"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "B"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C"))

    chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Open"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "High"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 3, "Low"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 4, "Close"), chart.type)

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 1, 72))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 1, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 1, 38))

    series = chart.chart_data.series[1]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 2, 172))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 2, 57))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 2, 57))

    series = chart.chart_data.series[2]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 3, 13))

    series = chart.chart_data.series[3]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 4, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 4, 38))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 4, 50))

    chart.chart_data.series_groups[0].up_down_bars.has_up_down_bars = True
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for ser in chart.chart_data.series:
        ser.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("StockChart.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The stock chart](stock_chart.png)

### **Tạo biểu đồ Hộp và Râu (Box and Whisker)**

Biểu đồ hộp và râu được dùng để hiển thị phân phối dữ liệu bằng cách tóm tắt các chỉ số thống kê chính như trung vị, tứ phân vị và các ngoại lệ tiềm năng. Chúng đặc biệt hữu ích trong phân tích khám phá dữ liệu và các nghiên cứu thống kê để nhanh chóng hiểu biến thiên dữ liệu và xác định bất thường.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.
1. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại `ChartType.BOX_AND_WHISKER`.
1. Truy cập workbook dữ liệu của biểu đồ ([ChartDataWorkbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Xóa series và danh mục mặc định.
1. Thêm series và danh mục mới.
1. Thêm dữ liệu biểu đồ mới cho series.
1. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã Python này cho thấy cách tạo biểu đồ hộp và râu:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 1"))

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B1", 15))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B2", 41))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B3", 16))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B4", 10))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B5", 23))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B6", 16))

    presentation.save("BoxAndWhiskerChart.pptx", slides.export.SaveFormat.PPTX)
```

### **Tạo biểu đồ Phễu (Funnel)**

Biểu đồ phễu được dùng để hình dung quy trình có các giai đoạn tuần tự, trong đó khối lượng dữ liệu giảm dần khi tiến từ bước này sang bước tiếp theo. Chúng đặc biệt hữu ích để phân tích tỷ lệ chuyển đổi, xác định nút thắt và theo dõi hiệu quả của các quy trình bán hàng hoặc tiếp thị.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.
1. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại `ChartType.FUNNEL`.
1. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã Python này cho thấy cách tạo biểu đồ phễu:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 4"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 5"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 6"))

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B1", 50))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B2", 100))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B3", 200))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B4", 300))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B5", 400))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B6", 500))

    presentation.save("FunnelChart.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The funnel chart](funnel_chart.png)

### **Tạo biểu đồ Mặt trời (Sunburst)**

Biểu đồ mặt trời được dùng để hình dung dữ liệu phân cấp, hiển thị các cấp độ dưới dạng các vòng đồng tâm. Chúng giúp minh họa mối quan hệ phần‑trên‑toàn và lý tưởng cho việc biểu diễn các danh mục lồng nhau và các phân mục trong một định dạng gọn gàng, rõ ràng.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.
1. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại `ChartType.SUNBURST`.
1. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã Python này cho thấy cách tạo biểu đồ mặt trời:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Nhánh 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # Nhánh 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D8", 3))

    presentation.save("SunburstChart.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The sunburst chart](sunburst_chart.png)

### **Tạo biểu đồ Histogram**

Biểu đồ histogram được dùng để biểu diễn phân phối dữ liệu số bằng cách nhóm các giá trị thành các khoảng (bins). Chúng đặc biệt hữu ích để xác định các mẫu dữ liệu như tần suất, độ lệch và độ phân tán, đồng thời phát hiện ngoại lệ trong một tập dữ liệu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.
1. Thêm một biểu đồ với một số dữ liệu và chỉ định loại `ChartType.HISTOGRAM`.
1. Truy cập workbook dữ liệu của biểu đồ ([ChartDataWorkbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Xóa series và danh mục mặc định.
1. Thêm một series mới và đưa dữ liệu điểm vào. Histogram không có danh mục; các bins được tính từ các giá trị.
1. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã Python này cho thấy cách tạo biểu đồ histogram:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A1", 15))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A2", -41))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A3", 16))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A4", 10))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A5", -23))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A6", 16))

    chart.axes.horizontal_axis.aggregation_type = charts.AxisAggregationType.AUTOMATIC

    presentation.save("HistogramChart.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The histogram chart](histogram_chart.png)

### **Tạo biểu đồ Radar**

Biểu đồ radar được dùng để hiển thị dữ liệu đa biến trong một định dạng hai chiều, cho phép so sánh nhiều biến cùng lúc một cách dễ dàng. Chúng đặc biệt hữu ích để xác định các mẫu, điểm mạnh và điểm yếu trên nhiều chỉ số hoặc thuộc tính hiệu suất.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.
1. Thêm một biểu đồ với một số dữ liệu và chỉ định loại `ChartType.RADAR`.
1. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã Python này cho thấy cách tạo biểu đồ radar:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 500, 300)
    presentation.save("RadarChart.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The radar chart](radar_chart.png)

### **Tạo biểu đồ Đa danh mục (Multi-Category)**

Biểu đồ đa danh mục được dùng để hiển thị dữ liệu có hơn một nhóm danh mục, cho phép bạn so sánh các giá trị qua nhiều chiều đồng thời. Chúng đặc biệt hữu ích khi cần phân tích xu hướng và mối quan hệ trong các tập dữ liệu phức tạp, đa lớp.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.
1. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại `ChartType.CLUSTERED_COLUMN`.
1. Truy cập workbook dữ liệu của biểu đồ ([ChartDataWorkbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Xóa series và danh mục mặc định.
1. Thêm series và danh mục mới.
1. Thêm dữ liệu biểu đồ mới cho series.
1. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã Python này cho thấy cách tạo biểu đồ đa danh mục:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    worksheet_index = 0

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c2", "A"))
    category.grouping_levels.set_grouping_item(1, "Group1")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c3", "B"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c4", "C"))
    category.grouping_levels.set_grouping_item(1, "Group2")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c5", "D"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c6", "E"))
    category.grouping_levels.set_grouping_item(1, "Group3")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c7", "F"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c8", "G"))
    category.grouping_levels.set_grouping_item(1, "Group4")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c9", "H"))

    # Thêm một series.
    series = chart.chart_data.series.add(workbook.get_cell(0, "D1", "Series 1"), charts.ChartType.CLUSTERED_COLUMN)

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D2", 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D3", 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D4", 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D5", 40))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D6", 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D7", 60))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D8", 70))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D9", 80))

    # Lưu bản thuyết trình kèm biểu đồ.
    presentation.save("MultiCategoryChart.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The multi-category chart](multi_category_chart.png)

### **Tạo biểu đồ Bản đồ (Map)**

Biểu đồ bản đồ được dùng để hình dung dữ liệu địa lý bằng cách gắn thông tin vào các vị trí cụ thể như quốc gia, bang hoặc thành phố. Chúng đặc biệt hữu ích để phân tích xu hướng vùng, dữ liệu nhân khẩu và phân bố không gian một cách rõ ràng và hấp dẫn.

Mã Python này cho thấy cách tạo biểu đồ bản đồ:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 20, 20, 500, 300)
    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The map chart](map_chart.png)

### **Tạo biểu đồ Kết hợp (Combination)**

Biểu đồ kết hợp (hoặc combo chart) gộp hai hoặc nhiều loại biểu đồ trong một đồ thị. Biểu đồ này cho phép bạn làm nổi bật, so sánh hoặc kiểm tra sự khác nhau giữa hai hoặc hơn các bộ dữ liệu, giúp xác định mối quan hệ giữa chúng.

![The combination chart](combination_chart.png)

Mã Python sau đây cho thấy cách tạo biểu đồ kết hợp được hiển thị ở trên trong một bản PowerPoint:

```python
import aspose.slides.charts as charts
import aspose.pydrawing as draw
import aspose.slides as slides

def create_combo_chart():
    with slides.Presentation() as presentation:
        chart = create_chart_with_first_series(presentation.slides[0])

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", slides.export.SaveFormat.PPTX)


def create_chart_with_first_series(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    # Đặt tiêu đề biểu đồ.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Chart Title")
    chart.chart_title.overlay = False
    title_paragraph = chart.chart_title.text_frame_for_overriding.paragraphs[0]
    title_format = title_paragraph.paragraph_format.default_portion_format

    title_format.font_bold = slides.NullableBool.FALSE
    title_format.font_height = 18

    # Đặt chú giải biểu đồ.
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.portion_format.font_height = 12

    # Xóa series và danh mục được tạo mặc định.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    worksheet_index = 0
    workbook = chart.chart_data.chart_data_workbook

    # Thêm danh mục mới.
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 4, 0, "Category 4"))

    # Thêm series đầu tiên.
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 4.3))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 2.5))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 3.5))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 4.5))

    return chart


def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 2.4))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 4.4))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 1.8))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 2.8))


def add_third_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.LINE)

    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 1, 3, 2.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 2, 3, 2.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 3, 3, 3.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 4, 3, 5.0))

    series.plot_on_second_axis = True


def set_primary_axes_format(chart):
    # Đặt trục ngang.
    horizontal_axis = chart.axes.horizontal_axis
    horizontal_axis.text_format.portion_format.font_height = 12.0
    horizontal_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(horizontal_axis, "X Axis")

    # Đặt trục dọc.
    vertical_axis = chart.axes.vertical_axis
    vertical_axis.text_format.portion_format.font_height = 12.0
    vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(vertical_axis, "Y Axis 1")

    # Đặt màu cho các đường lưới chính đứng.
    major_grid_lines_format = vertical_axis.major_grid_lines_format.line.fill_format
    major_grid_lines_format.fill_type = slides.FillType.SOLID
    major_grid_lines_format.solid_fill_color.color = draw.Color.from_argb(217, 217, 217)


def set_secondary_axes_format(chart):
    # Đặt trục ngang phụ.
    secondary_horizontal_axis = chart.axes.secondary_horizontal_axis
    secondary_horizontal_axis.position = charts.AxisPositionType.BOTTOM
    secondary_horizontal_axis.cross_type = charts.CrossesType.MAXIMUM
    secondary_horizontal_axis.is_visible = False
    secondary_horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    # Đặt trục dọc phụ.
    secondary_vertical_axis = chart.axes.secondary_vertical_axis
    secondary_vertical_axis.position = charts.AxisPositionType.RIGHT
    secondary_vertical_axis.text_format.portion_format.font_height = 12.0
    secondary_vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(secondary_vertical_axis, "Y Axis 2")


def set_axis_title(axis, axis_title):
    axis.has_title = True
    axis.title.overlay = False
    title_portion_format = axis.title.add_text_frame_for_overriding(axis_title).paragraphs[0].paragraph_format.default_portion_format
    title_portion_format.font_bold = slides.NullableBool.FALSE
    title_portion_format.font_height = 12.0
```

## **Cập nhật biểu đồ**

Aspose.Slides cho Python thông qua .NET cho phép bạn cập nhật dữ liệu, định dạng và kiểu dáng của biểu đồ để giữ cho các bản PowerPoint luôn cập nhật.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) để mở bản thuyết trình chứa biểu đồ.
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.
1. Duyệt qua tất cả các shape để tìm biểu đồ.
1. Truy cập worksheet dữ liệu của biểu đồ.
1. Sửa đổi series dữ liệu của biểu đồ bằng cách thay đổi giá trị series.
1. Thêm một series mới và điền dữ liệu cho nó.
1. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã Python này cho thấy cách cập nhật một biểu đồ:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# Khởi tạo lớp Presentation đại diện cho tệp PPTX.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # Truy cập slide đầu tiên.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape

            # Đặt chỉ mục của bảng dữ liệu biểu đồ.
            worksheet_index = 0

            # Lấy workbook dữ liệu biểu đồ.
            workbook = chart.chart_data.chart_data_workbook

            # Thay đổi tên danh mục của biểu đồ.
            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            # Lấy series đầu tiên của biểu đồ.
            series = chart.chart_data.series[0]

            # Cập nhật dữ liệu series.
            workbook.get_cell(worksheet_index, 0, 1, "New_Series1")  # Sửa đổi tên series.
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            # Lấy series thứ hai của biểu đồ.
            series = chart.chart_data.series[1]

            # Cập nhật dữ liệu series.
            workbook.get_cell(worksheet_index, 0, 2, "New_Series2")  # Sửa đổi tên series.
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            # Thêm một series mới.
            series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), chart.type)

            # Điền dữ liệu cho series.
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 3, 20))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 3, 50))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 3, 30))

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

            # Lưu bản thuyết trình kèm biểu đồ.
            presentation.save("ModifiedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt phạm vi dữ liệu cho biểu đồ**

Aspose.Slides cho Python thông qua .NET cho phép bạn sử dụng một phạm vi worksheet cụ thể làm nguồn dữ liệu cho biểu đồ. Điều này kiểm soát các ô cung cấp series và danh mục cho biểu đồ và cho phép bạn cập nhật biểu đồ để phản ánh các thay đổi trong worksheet.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) để mở bản thuyết trình chứa biểu đồ.
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.
1. Duyệt qua tất cả các shape để tìm biểu đồ.
1. Truy cập dữ liệu biểu đồ và đặt phạm vi.
1. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã Python này cho thấy cách đặt phạm vi dữ liệu cho một biểu đồ:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# Khởi tạo lớp Presentation đại diện cho tệp PPTX.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # Truy cập slide đầu tiên.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            chart.chart_data.set_range("Sheet1!A1:B4")

    presentation.save("DataRange.pptx", slides.export.SaveFormat.PPTX)
```

## **Sử dụng các ký hiệu mặc định trong biểu đồ**

Khi bạn sử dụng các ký hiệu mặc định trong biểu đồ, mỗi series sẽ tự động nhận một ký hiệu khác nhau.

Mã Python này cho thấy cách thiết lập ký hiệu series biểu đồ tự động:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "C1"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 1, 24))

    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "C2"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 1, 23))

    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C3"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 1, -10))

    chart.chart_data.categories.add(workbook.get_cell(0, 4, 0, "C4"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 1, None))

    series2 = chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "Series 2"), chart.type)

    # Điền dữ liệu cho series.
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 2, 30))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 2, 10))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 2, 60))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 2, 40))

    chart.has_legend = True
    chart.legend.overlay = False

    presentation.save("DefaultMarkersInChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Các loại biểu đồ nào được Aspose.Slides cho Python thông qua .NET hỗ trợ?**

Aspose.Slides cho Python thông qua .NET hỗ trợ đa dạng các loại biểu đồ, bao gồm bar, line, pie, area, scatter, histogram, radar và nhiều loại khác. Sự linh hoạt này cho phép bạn chọn loại biểu đồ phù hợp nhất cho nhu cầu trực quan hóa dữ liệu.

**Làm thế nào để thêm một biểu đồ mới vào slide?**

Để thêm biểu đồ, trước tiên bạn tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/), lấy slide mong muốn bằng chỉ số, sau đó gọi phương thức thêm biểu đồ, chỉ định loại biểu đồ và dữ liệu ban đầu. Quy trình này tích hợp biểu đồ trực tiếp vào bản thuyết trình của bạn.

**Làm sao tôi có thể cập nhật dữ liệu hiển thị trong biểu đồ?**

Bạn có thể cập nhật dữ liệu của biểu đồ bằng cách truy cập workbook dữ liệu của nó ([ChartDataWorkbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdataworkbook/)), xóa bất kỳ series và danh mục mặc định nào, sau đó thêm dữ liệu tùy chỉnh của bạn. Điều này cho phép bạn làm mới biểu đồ một cách lập trình để phản ánh dữ liệu mới nhất.

**Có thể tùy chỉnh giao diện của biểu đồ không?**

Có, Aspose.Slides cho Python thông qua .NET cung cấp các tùy chọn tùy chỉnh phong phú. Bạn có thể thay đổi màu sắc, phông chữ, nhãn, chú giải và các yếu tố định dạng khác để điều chỉnh giao diện biểu đồ phù hợp với yêu cầu thiết kế cụ thể của bạn.