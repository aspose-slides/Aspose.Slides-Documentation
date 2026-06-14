---
title: Tối ưu tính toán biểu đồ cho bản trình chiếu trong Python
linktitle: Tính toán biểu đồ
type: docs
weight: 50
url: /vi/python-net/chart-calculations/
keywords:
- tính toán biểu đồ
- phần tử biểu đồ
- vị trí phần tử
- vị trí thực
- phần tử con
- phần tử cha
- giá trị biểu đồ
- giá trị thực
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Hiểu về tính toán biểu đồ, cập nhật dữ liệu và kiểm soát độ chính xác trong Aspose.Slides cho Python qua .NET cho PPT, PPTX và ODP, kèm ví dụ mã thực tế."
---
## **Tổng quan**

Aspose.Slides cung cấp các API để làm việc với tính toán biểu đồ và dữ liệu bố cục trong bản trình chiếu. Bài viết này mô tả cách lấy các giá trị thực của các phần tử biểu đồ, bao gồm vị trí và kích thước thực của các phần tử thực thi `ActualLayout` và các giá trị thực của các trục biểu đồ. Nó cũng giải thích rằng các giá trị này được điền sau khi xác thực bố cục biểu đồ.

Trong phần bổ sung, bài viết trình bày cách lấy vị trí thực của các phần tử biểu đồ cha và cách ẩn các thành phần biểu đồ như tiêu đề, trục, chú giải và các đường lưới. Những ví dụ này giúp bạn kiểm tra thông tin bố cục biểu đồ và kiểm soát khả năng hiển thị của các phần tử biểu đồ trong PowerPoint một cách lập trình.

## **Tính các giá trị thực của các phần tử biểu đồ**
Aspose.Slides cho Python qua .NET cung cấp một API đơn giản để lấy các thuộc tính này. Điều này sẽ giúp bạn tính các giá trị thực của các phần tử biểu đồ. Các giá trị thực bao gồm vị trí của các phần tử kế thừa lớp [IActualLayout](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/iactuallayout/) (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) và các giá trị thực của các trục (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    maxValue = chart.axes.vertical_axis.actual_max_value
    minValue = chart.axes.vertical_axis.actual_min_value
    majorUnit = chart.axes.horizontal_axis.actual_major_unit
    minorUnit = chart.axes.horizontal_axis.actual_minor_unit
```

## **Tính vị trí thực của các phần tử biểu đồ cha**
Aspose.Slides cho Python qua .NET cung cấp một API đơn giản để lấy các thuộc tính này. Các thuộc tính của IActualLayout cung cấp thông tin về vị trí thực của phần tử biểu đồ cha. Cần phải gọi phương thức IChart.ValidateChartLayout() trước tiên để điền các thuộc tính bằng các giá trị thực.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
```

## **Ẩn thông tin khỏi biểu đồ**
Chủ đề này giúp bạn hiểu cách ẩn thông tin khỏi biểu đồ. Sử dụng Aspose.Slides cho Python qua .NET, bạn có thể ẩn **Tiêu đề, Trục dọc, Trục ngang** và **Đường lưới** khỏi biểu đồ. Ví dụ mã dưới đây cho thấy cách sử dụng các thuộc tính này.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # Ẩn tiêu đề biểu đồ
    chart.has_title = False

    # Ẩn trục Giá trị
    chart.axes.vertical_axis.is_visible = False

    # Hiển thị trục danh mục
    chart.axes.horizontal_axis.is_visible = False

    # Ẩn chú giải
    chart.has_legend = False

    # Ẩn các đường lưới chính
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # Đặt màu đường series
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Sổ làm việc Excel bên ngoài có hoạt động như nguồn dữ liệu không, và điều đó ảnh hưởng đến việc tính lại như thế nào?**

Đúng. Một biểu đồ có thể tham chiếu tới một sổ làm việc bên ngoài: khi bạn kết nối hoặc làm mới nguồn bên ngoài, các công thức và giá trị được lấy từ sổ làm việc đó, và biểu đồ sẽ phản ánh các cập nhật trong quá trình mở/chỉnh sửa. API cho phép bạn [định rõ đường dẫn tới sổ làm việc bên ngoài](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/set_external_workbook/) và quản lý dữ liệu được liên kết.

**Tôi có thể tính và hiển thị đường xu hướng mà không tự triển khai hồi quy không?**

Đúng. [Đường xu hướng](/slides/vi/python-net/trend-line/) (tuyến tính, hàm mũ và các loại khác) được Aspose.Slides thêm vào và cập nhật; các tham số của chúng được tính lại tự động từ dữ liệu chuỗi, vì vậy bạn không cần phải tự triển khai các phép tính.

**Nếu một bản trình chiếu có nhiều biểu đồ với liên kết bên ngoài, tôi có thể kiểm soát sổ làm việc nào mỗi biểu đồ sử dụng cho các giá trị tính toán không?**

Đúng. Mỗi biểu đồ có thể trỏ tới [sổ làm việc bên ngoài](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/set_external_workbook/) riêng của mình, hoặc bạn có thể tạo/thay thế một sổ làm việc bên ngoài cho từng biểu đồ một cách độc lập với các biểu đồ khác.