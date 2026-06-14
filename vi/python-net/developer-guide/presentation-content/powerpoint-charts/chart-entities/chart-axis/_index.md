---
title: Tùy chỉnh trục biểu đồ trong bản trình chiếu bằng Python
linktitle: Trục biểu đồ
type: docs
url: /vi/python-net/chart-axis/
keywords:
- trục biểu đồ
- trục dọc
- trục ngang
- tùy chỉnh trục
- thao tác trục
- quản lý trục
- thuộc tính trục
- giá trị tối đa
- giá trị tối thiểu
- đường trục
- định dạng ngày
- tiêu đề trục
- vị trí trục
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Khám phá cách sử dụng Aspose.Slides cho Python thông qua .NET để tùy chỉnh trục biểu đồ trong các bản trình chiếu PowerPoint và OpenDocument cho báo cáo và trực quan hoá."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh trục biểu đồ trong Aspose.Slides. Nó cho thấy cách lấy giá trị thực của trục, hoán đổi dữ liệu giữa các trục, ẩn trục dọc hoặc trục ngang cho biểu đồ đường, thay đổi loại trục danh mục, thiết lập định dạng ngày cho giá trị trục danh mục, xoay tiêu đề trục, đặt vị trí trục và hiển thị nhãn đơn vị trên trục giá trị.

## **Lấy giá trị tối đa trên trục dọc trong biểu đồ**

Aspose.Slides cho Python thông qua .NET cho phép bạn lấy giá trị tối thiểu và tối đa trên trục dọc. Thực hiện các bước sau:

1. Tạo một thể hiện của lớp[Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Truy cập slide đầu tiên.
3. Thêm một biểu đồ với dữ liệu mặc định.
4. Lấy giá trị tối đa thực tế trên trục.
5. Lấy giá trị tối thiểu thực tế trên trục.
6. Lấy đơn vị chính thực tế của trục.
7. Lấy đơn vị phụ thực tế của trục.
8. Lấy tỷ lệ đơn vị chính thực tế của trục.
9. Lấy tỷ lệ đơn vị phụ thực tế của trục.

Mã mẫu này — một triển khai các bước trên — cho bạn thấy cách lấy các giá trị cần thiết trong Python:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
	chart.validate_chart_layout()

	maxValue = chart.axes.vertical_axis.actual_max_value
	minValue = chart.axes.vertical_axis.actual_min_value

	majorUnit = chart.axes.horizontal_axis.actual_major_unit
	minorUnit = chart.axes.horizontal_axis.actual_minor_unit
	
	# Lưu bản trình chiếu
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hoán đổi dữ liệu giữa các trục**

Aspose.Slides cho phép bạn nhanh chóng hoán đổi dữ liệu giữa các trục — dữ liệu hiển thị trên trục dọc (trục y) di chuyển sang trục ngang (trục x) và ngược lại.

Mã Python này cho bạn thấy cách thực hiện việc hoán đổi dữ liệu giữa các trục trên một biểu đồ:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Tạo bản trình chiếu trống
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    #Đảo đổi hàng và cột
    chart.chart_data.switch_row_column()
            
    # Lưu bản trình chiếu
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Vô hiệu hoá trục dọc cho biểu đồ đường**

Mã Python này cho bạn thấy cách ẩn trục dọc cho một biểu đồ đường:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **Vô hiệu hoá trục ngang cho biểu đồ đường**

Mã này cho bạn thấy cách ẩn trục ngang cho một biểu đồ đường:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **Thay đổi trục danh mục**

Sử dụng thuộc tính **CategoryAxisType**, bạn có thể chỉ định loại trục danh mục ưa thích của mình (**date** hoặc **text**). Mã Python này minh họa thao tác:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS
    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt định dạng ngày cho giá trị trục danh mục**

Aspose.Slides cho Python thông qua .NET cho phép bạn đặt định dạng ngày cho giá trị trục danh mục. Thao tác này được minh họa trong mã Python sau:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
from datetime import date

def to_oadate(dt):
    delta = dt - date(1899, 12, 30)
    return delta.days + (delta.seconds + delta.microseconds / 1e6) / (24 * 3600)

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 50, 50, 450, 300)

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    chart.chart_data.categories.add(wb.get_cell(0, "A2", to_oadate(date(2015, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", to_oadate(date(2016, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", to_oadate(date(2017, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", to_oadate(date(2018, 1, 1))))

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B2", 1))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B3", 2))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B4", 3))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B5", 4))
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"
    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt góc xoay cho tiêu đề trục biểu đồ**

Aspose.Slides cho Python thông qua .NET cho phép bạn đặt góc xoay cho tiêu đề trục biểu đồ. Mã Python này minh họa thao tác:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt vị trí trục trong trục danh mục hoặc trục giá trị**

Aspose.Slides cho Python thông qua .NET cho phép bạn đặt vị trí trục trong trục danh mục hoặc trục giá trị. Mã Python này cho thấy cách thực hiện nhiệm vụ:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Kích hoạt hiển thị nhãn đơn vị trên trục giá trị của biểu đồ**

Aspose.Slides cho Python thông qua .NET cho phép bạn cấu hình một biểu đồ để hiển thị nhãn đơn vị trên trục giá trị của nó. Mã Python này minh họa thao tác:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Làm thế nào để tôi đặt giá trị mà tại đó một trục cắt qua trục kia (giao điểm trục)?**

Các trục cung cấp một [cài đặt giao điểm](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/axis/cross_type/): bạn có thể chọn giao điểm tại không, tại giá trị danh mục/giá trị tối đa, hoặc tại một giá trị số cụ thể. Điều này hữu ích để di chuyển trục X lên hoặc xuống hoặc để nhấn mạnh một đường cơ sở.

**Làm thế nào để tôi đặt vị trí nhãn đánh dấu so với trục (bên cạnh, ngoài, trong)?**

Đặt [vị trí nhãn](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/axis/major_tick_mark/) thành "cross", "outside" hoặc "inside". Điều này ảnh hưởng đến khả năng đọc và giúp tiết kiệm không gian, đặc biệt trên các biểu đồ nhỏ.