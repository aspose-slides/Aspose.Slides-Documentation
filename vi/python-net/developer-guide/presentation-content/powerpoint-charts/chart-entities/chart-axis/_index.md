---
title: Tùy chỉnh trục biểu đồ trong bài thuyết trình bằng Python
linktitle: Trục biểu đồ
type: docs
url: /vi/python-net/chart-axis/
keywords:
- trục biểu đồ
- trục dọc
- trục ngang
- tùy chỉnh trục
- điều chỉnh trục
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
- bài thuyết trình
- Python
- Aspose.Slides
description: "Khám phá cách sử dụng Aspose.Slides cho Python qua .NET để tùy chỉnh trục biểu đồ trong các bài thuyết trình PowerPoint và OpenDocument cho báo cáo và trực quan hoá."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh trục biểu đồ với Aspose.Slides cho Python qua .NET. Nó bao gồm các giá trị trục đã tính toán, chuyển đổi hàng và cột biểu đồ, hiển thị trục, khoảng cách nhãn danh mục và dấu tick, danh mục ngày và định dạng, xoay tiêu đề, vị trí trục, đơn vị hiển thị và tỷ lệ logarit.

## **Lấy Giá Trị Tối Đa Trên Trục Dọc Trong Biểu Đồ**

Create a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) and add an area chart with default data. Call [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) before reading calculated axis values so that the chart layout is up to date.

Read [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) and [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) for the axis limits, and [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) and [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) for the tick intervals. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) and [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) provide time-unit scales, which are relevant to date axes. The example stores these values in local variables and saves the chart.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
    chart.validate_chart_layout()

    max_value = chart.axes.vertical_axis.actual_max_value
    min_value = chart.axes.vertical_axis.actual_min_value

    major_unit = chart.axes.vertical_axis.actual_major_unit
    minor_unit = chart.axes.vertical_axis.actual_minor_unit

    major_unit_scale = chart.axes.vertical_axis.actual_major_unit_scale
    minor_unit_scale = chart.axes.vertical_axis.actual_minor_unit_scale

    presentation.save("AxisValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hoán Đổi Dữ Liệu Giữa Các Trục**

Use [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) to exchange the roles of series and categories in chart data. Each former category becomes a series, and each former series becomes a category. This changes how the data is grouped; it does not exchange the horizontal and vertical axes. The example uses [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) to bind the default data to `Sheet1!A1:D5`, including the header row and category column, before switching rows and columns. It saves a chart with four series and three categories.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    chart.chart_data.set_range("Sheet1!A1:D5")
    chart.chart_data.switch_row_column()

    presentation.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Đảo Ngược Thứ Tự Vẽ Của Một Trục**

Use [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) to reverse a category or value axis. For example, a horizontal bar chart can show project stages from top to bottom in the same order as the worksheet: Planning, Development, Testing. Reversing an axis changes the plotting direction; it does not sort or rearrange the workbook data. By comparison, [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) exchanges the roles of series and categories.

The following example creates a horizontal bar chart with three stages and one series. It saves a presentation with three slides: normal order, reversed categories, and reversed values. Each copy uses the same dataset, and only one axis is reversed on each copy.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_BAR, 50, 40, 620, 320)
    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_BAR)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.get_cell(0, i + 1, 0, stage)
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_bar_series(value_cell)

    # Slide 2: hiển thị danh mục đầu tiên ở trên cùng.
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # Giữ trục giá trị ngang ở phía dưới.
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # Slide 3: đảo ngược chỉ thang số ngang.
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

Reversing an axis can also move the perpendicular axis to the opposite side of the plot. [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) controls where the other axis crosses the axis being configured. In slide 2, setting it to `MAXIMUM` on the reversed category axis keeps the horizontal value axis at the bottom. For a specific crossing point, use [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Check the crossing settings when changing direction, especially if the chart already has a custom crossing point. Set `is_plot_order_reversed` back to `False` to restore the normal plotting direction; crossing settings are separate.

| Trật tự bình thường (slide 1) | Danh mục đảo ngược (slide 2) | Giá trị đảo ngược (slide 3) |
| --- | --- | --- |
| ![Biểu đồ thanh ngang với trật tự trục danh mục và trục giá trị bình thường](axis-order-normal.png) | ![Biểu đồ thanh ngang với các danh mục hiển thị từ trên xuống dưới](axis-order-categories-reversed.png) | ![Biểu đồ thanh ngang với trục giá trị đảo ngược và giá trị zero ở bên phải](axis-order-values-reversed.png) |
| Các danh mục chạy từ dưới lên trên; giá trị tăng từ trái sang phải. | Planning, Development và Testing chạy từ trên xuống dưới. Giá trị và thứ tự hàng trong workbook không thay đổi. | Các danh mục giữ thứ tự bình thường; giá trị tăng từ phải sang trái. Trục danh mục cắt tại giá trị zero ở bên phải. |

## **Tắt Trục Dọc cho Biểu Đồ Đường**

Set [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) to `False` on the vertical axis to hide it. The example creates a line chart with default data and saves it with the vertical axis hidden.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Tắt Trục Ngang cho Biểu Đồ Đường**

Set [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) to `False` on the horizontal axis to hide it. The example creates a line chart with default data and saves it with the horizontal axis hidden.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Thay Đổi Trục Danh Mục**

Set [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) to choose a date or text category axis. This example requires `ExistingChart.pptx`, with a chart as the first shape on the first slide and category cells containing numeric Excel date values. It changes the horizontal axis to a date axis. Setting [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) to `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) to `1`, and [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) to months places major ticks at one-month intervals.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS

    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kiểm Soát Khoảng Cách Nhãn Trục Danh Mục**

When a chart has many categories, reduce the number of visible axis labels without removing categories or data points. Set [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) to `False`, then set [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) to the desired category interval. For text categories in their normal order, counting starts at the first category:

| Khoảng | Nhãn hiển thị trong ví dụ |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

An interval of `3` displays every third label, leaving two labels hidden between displayed labels. It does not remove the corresponding columns. Automatic spacing chooses an interval based on the available space; it does not necessarily display every label.

Tick marks have separate controls. Set [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) to `False` and use [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) to set their interval. For example, `1` keeps a tick mark at every category interval while labels appear only every third category. Set [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) to a visible style so you can see the result. Setting either automatic-spacing property back to `True` lets the chart choose that interval again.

The following self-contained example creates 24 categories and one series, then saves three slides in `CategoryAxisIntervals.pptx`: automatic spacing, manual label spacing with independent tick marks, and restored automatic spacing. The two copies retain the original chart data. No input presentation is required. Horizontal label text makes the difference in density easy to see.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_COLUMN)
    for i in range(24):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, 10 + i % 6 * 5)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.category_axis_type = charts.CategoryAxisType.TEXT
    axis.text_format.text_block_format.rotation_angle = 0
    axis.text_format.portion_format.font_height = 12
    axis.major_tick_mark = charts.TickMarkType.OUTSIDE
    axis.is_automatic_tick_label_spacing = True
    axis.is_automatic_tick_marks_spacing = True

    # Slide 2: hiển thị mỗi nhãn thứ ba, nhưng giữ dấu tick cho mỗi danh mục.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # Slide 3: cho phép biểu đồ chọn lại cả hai khoảng cách.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Định khoảng tự động (slide 1):** In this rendering, every second category label is displayed and wraps onto two lines. The automatic result can vary with chart size, fonts, and the renderer.

![Khoảng cách nhãn danh mục tự động với tất cả 24 cột hiển thị](category-axis-automatic.png)

**Định khoảng thủ công (slide 2):** Every third label is displayed on one line, while tick marks remain at every category interval. All 24 columns, including those without labels, remain visible with the same values. Slide 3 restores the automatic appearance shown above.

![Khoảng cách nhãn danh mục thủ công ba với tất cả 24 cột hiển thị](category-axis-manual.png)

### **Chọn Trục và Khoảng Cách Phù Hợp**

Use this category-count interval for a text category axis, such as the category axis of a column, line, area, or bar chart. In a column chart, it is the horizontal axis. In a horizontal bar chart, the category axis is vertical, so apply these settings to [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Tick-mark spacing also applies to a series axis in charts that have one.

Do not use category label spacing to set the numeric scale of a value axis. On a value axis, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) specifies a difference in values: for example, a major unit of `10` produces ticks at 0, 10, 20, and so on when the axis starts at zero. A category label interval of `3` instead counts category positions, regardless of their data values. Scatter and bubble charts use value axes rather than a text category axis. For a date axis, use time-based major units and scales as described in [Change a Category Axis](#change-a-category-axis).

## **Đặt Định Dạng Ngày cho Các Giá Trị Trục Danh Mục**

The example replaces the default chart data with four annual values. Dates are stored as OLE Automation serial numbers in the first worksheet (index `0`). Set [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) to a date axis, disable [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/), and assign `yyyy` to [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) so the category labels display four-digit years independently of the cell formatting.

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        serial_date = (category_date - date(1899, 12, 30)).days
        category_cell = workbook.get_cell(0, i + 1, 0, serial_date)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, i + 1)
        series.data_points.add_data_point_for_line_series(value_cell)

    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"

    presentation.save("DateAxisFormat.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt Góc Xoay cho Tiêu Đề Trục Biểu Đồ**

Enable [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) on the vertical axis, provide title text, and set [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) to rotate the title. The angle is measured in degrees; this example saves a column chart with its value-axis title rotated by 90 degrees.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("Value")
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    presentation.save("RotatedAxisTitle.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt Vị Trí Trục trên Trục Danh Mục hoặc Trục Giá Trị**

Use [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) to control whether the value axis crosses the category axis between categories or at category tick marks. This property applies to category axes. The example sets it to `True` on the horizontal category axis of a column chart and saves the result.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt Đơn Vị Hiển Thị trên Trục Giá Trị Biểu Đồ**

Set [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) to scale the labels on a value axis without changing the underlying data. With [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) set to `MILLIONS`, a value of 60,000,000 is displayed as 60. The example creates a column chart and applies the millions display unit to its vertical axis.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Cấu Hình Trục Giá Trị Logarit**

A logarithmic value axis is useful when positive values span several orders of magnitude. For example, a service might receive 10, 100, 1,000, 10,000, and 100,000 requests over five periods. On a linear scale, the smaller values appear close together near zero. A logarithmic scale makes their relative growth easier to compare: equal distances represent equal ratios rather than equal differences.

Set [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) to `True` on the value axis and use [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) to choose the base. This changes how the existing values are displayed; it does not change the data or add a logarithmic trend line. A trend line represents a fitted relationship in the data and is a separate feature.

### **Chọn Trục Giá Trị và Cơ Sở**

For a line or column chart, the value axis is [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). For a horizontal bar chart, it is [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Scatter and bubble charts have two value axes, so choose the horizontal axis for X values, the vertical axis for Y values, or both. Do not apply logarithmic scaling to a category axis.

The default logarithmic base is `10`. For PPTX charts, use a base from `2` through `1000`, inclusive; fractional bases such as `2.5` are also supported. With base `10`, successive powers such as 10, 100, 1,000, and 10,000 are equally spaced.

### **So Sánh Thang Đường Thẳng và Logarit**

The following self-contained example creates a line chart with the five request counts on the first slide, then clones that slide and enables a base-10 logarithmic value axis on the second. Both slides retain the same data.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 30, 40, 660, 200)

    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Period {i + 1}")
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Giữ slide đầu tiên ở chế độ tuyến tính và chỉ thay đổi tỷ lệ trục giá trị của bản sao.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Linear scale (slide 1):** Equal vertical distances represent equal differences in request counts. The largest value dominates the chart, making the smaller values difficult to distinguish.

![Biểu đồ đường trong PowerPoint hiển thị năm lượng yêu cầu trên trục giá trị tuyến tính](value-axis-linear.png)

**Logarithmic scale (slide 2):** Equal vertical distances represent equal ratios. Each period has ten times as many requests as the previous one, so the points form a straight rising line on the base-10 scale. The axis labels still show the original request counts.

![Năm lượng yêu cầu tương tự trong PowerPoint trên trục giá trị logarit cơ số 10](value-axis-logarithmic.png)

### **Xử Lý Giá Trị Zero và Âm**

A logarithmic scale can display only strictly positive values. Check the data before enabling it. If zero or negative values are meaningful, keep a linear scale or show them separately. If excluding those values is appropriate for the analysis, explain the omission. Do not silently replace them with small positive numbers, as this changes the meaning of the data. Any manually configured minimum or maximum for a logarithmic axis must also be positive.

## **Câu Hỏi Thường Gặp**

**Làm thế nào để đặt giá trị mà một trục cắt qua trục kia (giao điểm trục)?**

Use [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) to select the crossing behavior. To specify a numeric crossing value, set [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). These settings let you move the axis crossing to a suitable baseline.

**Làm thế nào để đặt vị trí nhãn tick so với trục?**

Set [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) using [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/): `LOW`, `HIGH`, `NEXT_TO`, or `NONE`. To control the tick marks themselves, use [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) or [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/); these are separate from label positioning.