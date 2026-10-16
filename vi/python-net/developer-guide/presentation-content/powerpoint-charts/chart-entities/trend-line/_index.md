---
title: Thêm Đường Xu Hướng vào Biểu Đồ Trình Chiếu trong Python
linktitle: Đường xu hướng
type: docs
url: /vi/python-net/trend-line/
keywords:
- biểu đồ
- đường xu hướng
- đường xu hướng hàm mũ
- đường xu hướng tuyến tính
- đường xu hướng logarit
- đường xu hướng trung bình động
- đường xu hướng đa thức
- đường xu hướng lũy thừa
- đường xu hướng tùy chỉnh
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Nhanh chóng thêm và tùy chỉnh các đường xu hướng trong biểu đồ PowerPoint với Aspose.Slides cho Python qua .NET — một hướng dẫn thực tế để thu hút khán giả của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách thêm các đường xu hướng vào biểu đồ trong bài thuyết trình bằng cách sử dụng Aspose.Slides. Nó cho thấy cách tạo biểu đồ, thêm đường xu hướng vào các chuỗi biểu đồ, và làm việc với một số loại đường xu hướng, bao gồm hàm mũ, tuyến tính, logarit, trung bình động, đa thức và lũy thừa.

Nó cũng mô tả cách thêm một đường tùy chỉnh vào biểu đồ bằng cách chèn một hình dạng đường thẳng, và bao gồm một phần Câu hỏi thường gặp ngắn về các giá trị chiếu xu hướng ‘forward’ và ‘backward’ cũng như việc các đường xu hướng có được giữ lại khi xuất sang PDF hoặc SVG và khi render biểu đồ dưới dạng hình ảnh hay không.

## **Thêm Đường Xu hướng**

Sử dụng [TrendlineCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinecollection/add/) để thêm một đường xu hướng vào một chuỗi biểu đồ, chọn kiểu của nó bằng [TrendlineType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinetype/). Ví dụ tạo một biểu đồ cột nhóm với dữ liệu mặc định và thêm hai đường xu hướng cho mỗi trong ba chuỗi của nó.

Đường xu hướng hàm mũ ẩn phương trình và giá trị R‑bình phương thông qua [display_equation](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_equation/) và [display_r_squared_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_r_squared_value/), trong khi đường xu hướng tuyến tính có màu đỏ. Đường xu hướng logarit sử dụng [add_text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/add_text_frame_for_overriding/) để đặt nhãn tùy chỉnh. Đường trung bình động sử dụng một [period](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/period/) là ba điểm dữ liệu và một [trendline_name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/trendline_name/) tùy chỉnh.

Đường xu hướng đa thức có một [order](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/order/) là ba và mở rộng một danh mục về phía trước thông qua [forward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/forward/). Đường xu hướng lũy thừa mở rộng một danh mục về phía sau thông qua [backward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/backward/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    first_series = chart.chart_data.series[0]

    exponential_trendline = first_series.trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    exponential_trendline.display_equation = False
    exponential_trendline.display_r_squared_value = False

    linear_trendline = first_series.trend_lines.add(charts.TrendlineType.LINEAR)
    linear_trendline.format.line.fill_format.fill_type = slides.FillType.SOLID
    linear_trendline.format.line.fill_format.solid_fill_color.r = 255
    linear_trendline.format.line.fill_format.solid_fill_color.g = 0
    linear_trendline.format.line.fill_format.solid_fill_color.b = 0

    second_series = chart.chart_data.series[1]

    logarithmic_trendline = second_series.trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    logarithmic_trendline.add_text_frame_for_overriding("New log trend line")

    moving_average_trendline = second_series.trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    moving_average_trendline.period = 3
    moving_average_trendline.trendline_name = "New TrendLine Name"

    third_series = chart.chart_data.series[2]

    polynomial_trendline = third_series.trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    polynomial_trendline.forward = 1
    polynomial_trendline.order = 3

    power_trendline = third_series.trend_lines.add(charts.TrendlineType.POWER)
    power_trendline.backward = 1

    presentation.save("ChartTrendLines.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt Điểm Giao Đường Xu Hướng**

Sử dụng [intercept](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/intercept/) để cố định giá trị Y của đường xu hướng tại X = 0. Cài đặt này được hỗ trợ cho các đường xu hướng tuyến tính, hàm mũ và đa thức.

Ví dụ, một mô hình chi phí sản xuất có thể cần bắt đầu từ chi phí cố định đã biết là 100, ngay cả khi các đo lường ở khối lượng sản xuất khác 0 gợi ý một nền tảng khác. Đối với một đường xu hướng tuyến tính, việc cố định điểm giao sẽ ràng buộc phương trình `y = ax + b` thành `b = 100`; độ dốc được điều chỉnh để phù hợp với dữ liệu dưới ràng buộc đó. Nó không chỉ di chuyển một đường đã được điều chỉnh. Cài đặt giao điểm trục kiểm soát nơi các trục của biểu đồ gặp nhau, không phải các hệ số của đường xu hướng đã điều chỉnh.

Ví dụ sau tạo một biểu đồ phân tán (XY) với khối lượng sản xuất từ 1 đến 4 và chi phí 170, 200, 230 và 260. Nó lưu biểu đồ với điểm giao tự động mặc định, đặt điểm giao thành 100, và lưu một PPTX thứ hai. Hai tệp chỉ khác nhau ở cài đặt điểm giao. Đường xu hướng hiển thị phương trình và mở rộng lại tới X = 0.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_MARKERS, 20, 20, 480, 210)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    name_cell = workbook.get_cell(0, 0, 1, "Production cost")
    series = chart.chart_data.series.add(name_cell, charts.ChartType.SCATTER_WITH_MARKERS)
    costs = [170, 200, 230, 260]

    for i, cost in enumerate(costs):
        x_cell = workbook.get_cell(0, i + 1, 0, i + 1)
        y_cell = workbook.get_cell(0, i + 1, 1, cost)
        series.data_points.add_data_point_for_scatter_series(x_cell, y_cell)

    trendline = series.trend_lines.add(charts.TrendlineType.LINEAR)
    trendline.display_equation = True
    trendline.backward = 1

    presentation.save("AutomaticIntercept.pptx", slides.export.SaveFormat.PPTX)

    trendline.intercept = 100
    presentation.save("FixedIntercept.pptx", slides.export.SaveFormat.PPTX)
```

Với tính toán tự động, các dữ liệu này tạo ra `y = 30x + 140`. Đặt điểm giao thành 100 thay vào đó cho ra khoảng `y = 43.33x + 100`: giá trị khớp tại zero khớp với nền tảng đã biết, trong khi đường không còn đi qua mọi điểm dữ liệu.

| Điểm giao tự động | Điểm giao cố định 100 |
| --- | --- |
| ![Đường xu hướng tuyến tính với điểm giao được tính tự động là 140](intercept-automatic.png) | ![Đường xu hướng tuyến tính với điểm giao cố định là 100](intercept-fixed.png) |

Cả hai hình ảnh đều sử dụng cùng dữ liệu và thang trục. Các đường xu hướng được mở rộng lại tới X = 0 để hiển thị điểm giao của chúng.

Mặc định, thuộc tính chứa `float("nan")`, biểu thị một điểm giao chưa xác định thay vì zero. Khi đó điểm giao được tính tự động từ dữ liệu.

## **Thêm Đường Tùy Chỉnh**

Một đường tùy chỉnh là một hình dạng vẽ lên trên biểu đồ thay vì một đường xu hướng được tính từ dữ liệu chuỗi. Ví dụ này sử dụng [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) để thêm một đường ngang vào slide trên biểu đồ. Vị trí của đường được chỉ định bằng tọa độ slide, đo bằng điểm, vì vậy nó bắt đầu tại cạnh trái của biểu đồ và nằm ở giữa chiều cao của biểu đồ. Độ rộng của nó khớp với độ rộng của biểu đồ. [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) cung cấp cho đường màu đỏ đặc.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)

    line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, chart.x, chart.y + chart.height / 2, chart.width, 0)
    line.line_format.fill_format.fill_type = slides.FillType.SOLID
    line.line_format.fill_format.solid_fill_color.r = 255
    line.line_format.fill_format.solid_fill_color.g = 0
    line.line_format.fill_format.solid_fill_color.b = 0

    presentation.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**'forward' và 'backward' có ý nghĩa gì đối với một đường xu hướng?**

Chúng là độ dài của đường xu hướng được chiếu về phía trước/phía sau: đối với biểu đồ phân tán (XY) — tính bằng đơn vị trục; đối với các biểu đồ không phải phân tán — tính bằng số danh mục. Chỉ cho phép các giá trị không âm.

**Đường xu hướng có được giữ lại khi xuất bản trình chiếu sang PDF hoặc SVG, hoặc khi render slide thành hình ảnh không?**

Yes. Aspose.Slides converts presentations to [PDF](/slides/vi/python-net/convert-powerpoint-to-pdf/) or [SVG](/slides/vi/python-net/render-a-slide-as-an-svg-image/) and renders charts to images; trend lines, as part of the chart, are preserved during these operations. A method is also available to [export an image of the chart](/slides/vi/python-net/create-shape-thumbnails/) itself.