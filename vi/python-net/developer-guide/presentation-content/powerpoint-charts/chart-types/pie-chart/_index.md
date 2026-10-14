---
title: Tùy chỉnh biểu đồ tròn trong bản trình bày bằng Python
linktitle: Biểu đồ tròn
type: docs
url: /vi/python-net/pie-chart/
keywords:
- biểu đồ tròn
- quản lý biểu đồ
- tùy chỉnh biểu đồ
- tùy chọn biểu đồ
- cài đặt biểu đồ
- tùy chọn vẽ
- màu lát cắt
- PowerPoint
- bản trình bày
- Python
- Aspose.Slides
description: "Tạo và tùy chỉnh biểu đồ tròn trong Python với Aspose.Slides. Cấu hình biểu đồ phụ, hiển thị nhãn dữ liệu và áp dụng màu lát cắt tự động trong PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với biểu đồ tròn trong Aspose.Slides. Nó cho thấy cách cấu hình các tùy chọn biểu đồ phụ cho biểu đồ Pie of Pie và Bar of Pie, và cách bật tính năng tô màu tự động cho một biểu đồ tròn chuẩn.

Các ví dụ tập trung vào các nhiệm vụ tùy chỉnh biểu đồ như thêm biểu đồ vào một slide, điều chỉnh cài đặt series và nhãn, thay thế dữ liệu biểu đồ mặc định bằng các danh mục và giá trị tùy chỉnh, và lưu bản trình bày đã cập nhật.

## **Các tùy chọn biểu đồ phụ cho biểu đồ Pie of Pie và Bar of Pie**

Aspose.Slides for Python via .NET hỗ trợ các tùy chọn biểu đồ phụ cho biểu đồ Pie of Pie và Bar of Pie. Những tùy chọn này điều khiển kích thước của biểu đồ phụ và cách các điểm dữ liệu được chia giữa hai biểu đồ.

Ví dụ sau tạo một biểu đồ Pie of Pie trong một bản trình bày mới và hiển thị giá trị điểm dữ liệu dưới dạng nhãn. Thuộc tính [second_pie_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/second_pie_size/) thiết lập kích thước biểu đồ phụ thành 149% của biểu đồ chính. [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) chọn cách chia dựa trên phần trăm, và [pie_split_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_position/) đặt ngưỡng ở 53%.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
    series = chart.chart_data.series[0]

    # Hiển thị giá trị và cấu hình biểu đồ phụ.
    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.second_pie_size = 149
    series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    series_group.pie_split_position = 53

    presentation.save("pie_of_pie.pptx", slides.export.SaveFormat.PPTX)
```

### **Chọn danh mục cho biểu đồ phụ**

Sử dụng chia tùy chỉnh khi bạn muốn nhóm các danh mục cụ thể trong biểu đồ phụ bất kể giá trị phần trăm của chúng. Ví dụ, một báo cáo doanh số có thể hiển thị Online và Events cùng nhau để người đọc có thể so sánh hai kênh này, ngay cả khi chúng chiếm 35% và 10% tổng doanh số.

Đặt [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) thành [PieSplitType.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplittype/) và chọn các điểm qua [pie_split_custom_points](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_custom_points/). Phương thức [add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/add/) của bộ sưu tập chấp nhận hoặc một chỉ số bắt đầu từ 0 trong series hoặc một đối tượng điểm dữ liệu. Trong ví dụ này, chỉ số 1 chọn Online, và điểm ở chỉ số 3 chọn Events. Partners cũng được thêm tạm thời, sau đó bị loại bỏ bằng cách sử dụng [remove](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 200)

    # Thay thế dữ liệu mặc định bằng doanh số theo kênh.
    workbook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.pie_split_by = charts.PieSplitType.CUSTOM
    series_group.is_color_varied = True

    # Chọn Online bằng chỉ số bắt đầu từ 0 và Events bằng đối tượng điểm dữ liệu.
    series_group.pie_split_custom_points.add(1)
    series_group.pie_split_custom_points.add(series.data_points[3])

    # Loại bỏ Partners khỏi lựa chọn mà không xóa dữ liệu nguồn của nó.
    series_group.pie_split_custom_points.add(2)
    series_group.pie_split_custom_points.remove(series.data_points[2])

    presentation.save("pie_of_pie_custom.pptx", slides.export.SaveFormat.PPTX)
```

Online (35) và Events (10) xuất hiện như các lát cắt riêng trong biểu đồ phụ. Trong biểu đồ chính, chúng được đại diện bằng một lát cắt kết hợp có giá trị 45, cùng với Retail (40) và Partners (15). Việc loại bỏ Partners khỏi lựa chọn tùy chỉnh giữ nó trong biểu đồ chính; nó không xóa danh mục hoặc giá trị của nó khỏi dữ liệu nguồn của biểu đồ.

Hình ảnh sau hiển thị bản trình bày đã lưu trong PowerPoint:

![Pie of Pie chart with Online and Events in the secondary plot and their combined value of 45 in the primary plot](pie_of_pie_custom.png)

## **Đặt màu tự động cho các lát cắt biểu đồ tròn**

Aspose.Slides for Python via .NET có thể tự động gán các màu khác nhau cho các lát cắt của biểu đồ tròn. Ví dụ sau tạo một biểu đồ tròn với tiêu đề ở giữa và thay thế dữ liệu mặc định bằng ba danh mục quý và giá trị của chúng. Thuộc tính [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) hiển thị các giá trị 20, 50 và 30 dưới dạng nhãn, trong khi [is_color_varied](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/is_color_varied/) bật màu sắc phân biệt cho mỗi lát cắt.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # Thêm tiêu đề biểu đồ ở giữa.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Thay thế dữ liệu mặc định bằng cách sử dụng bảng tính đầu tiên.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    # Hiển thị giá trị và gán màu khác nhau cho các lát cắt.
    series.labels.default_data_label_format.show_value = True
    series.parent_series_group.is_color_varied = True

    presentation.save("pie.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Các biến thể Pie of Pie và Bar of Pie có được hỗ trợ không?**

Vâng, thư viện [hỗ trợ](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) một biểu đồ phụ cho biểu đồ tròn, bao gồm các loại Pie of Pie và Bar of Pie.

**Tôi có thể xuất riêng biểu đồ dưới dạng hình ảnh (ví dụ, PNG) không?**

Vâng, bạn có thể [xuất biểu đồ dưới dạng hình ảnh](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (như PNG) mà không xuất toàn bộ bản trình bày.