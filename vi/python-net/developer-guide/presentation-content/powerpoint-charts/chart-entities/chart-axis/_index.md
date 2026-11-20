---
title: Tùy chỉnh trục biểu đồ trong bản trình bày bằng Python
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
- bản trình bày
- Python
- Aspose.Slides
description: "Khám phá cách sử dụng Aspose.Slides cho Python qua .NET để tùy chỉnh trục biểu đồ trong các bản trình bày PowerPoint và OpenDocument cho báo cáo và trực quan hoá."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh trục biểu đồ với Aspose.Slides cho Python thông qua .NET. Nó bao gồm các giá trị trục đã tính toán, chuyển đổi hàng và cột biểu đồ, hiển thị trục, khoảng cách nhãn danh mục và đánh dấu tick, danh mục ngày và định dạng, xoay tiêu đề, vị trí trục, đơn vị hiển thị và tỷ lệ logarit.

## **Lấy Giá Trị Tối Đa Trên Trục Dọc Trong Biểu Đồ**

Tạo một [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) và thêm một biểu đồ khu vực với dữ liệu mặc định. Gọi [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) trước khi đọc các giá trị trục đã tính toán để bố cục biểu đồ được cập nhật.

Đọc [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) và [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) để lấy giới hạn trục, và [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) và [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) để lấy khoảng đánh dấu tick. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) và [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) cung cấp các thang thời gian, có liên quan đến trục ngày. Ví dụ lưu các giá trị này vào các biến cục bộ và lưu biểu đồ.

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

Sử dụng [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) để đổi vai trò của series và categories trong dữ liệu biểu đồ. Mỗi category cũ trở thành một series, và mỗi series cũ trở thành một category. Điều này thay đổi cách nhóm dữ liệu; nó không đổi vị trí các trục ngang và dọc. Ví dụ sử dụng [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) để gán dữ liệu mặc định vào `Sheet1!A1:D5`, bao gồm hàng tiêu đề và cột category, trước khi đổi hàng và cột. Nó lưu một biểu đồ với bốn series và ba category.

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

Sử dụng [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) để đảo ngược một trục category hoặc value. Ví dụ, một biểu đồ thanh ngang có thể hiển thị các giai đoạn dự án từ trên xuống dưới theo cùng thứ tự như trong bảng tính: Planning, Development, Testing. Đảo ngược trục thay đổi hướng vẽ; nó không sắp xếp hay thay đổi dữ liệu trong workbook. Để so sánh, [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) đổi vai trò của series và category.

Ví dụ sau tạo một biểu đồ thanh ngang với ba giai đoạn và một series. Nó lưu một bản trình bày với ba slide: thứ tự bình thường, category đảo ngược và value đảo ngược. Mỗi bản sao dùng cùng một bộ dữ liệu, và chỉ một trục được đảo ngược trên mỗi bản sao.

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

Đảo ngược một trục cũng có thể di chuyển trục vuông góc sang phía đối diện của plot. [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) kiểm soát nơi trục còn lại cắt trục đang cấu hình. Trong slide 2, đặt nó thành `MAXIMUM` trên trục category đã đảo ngược giữ trục value ngang ở phía dưới. Để chỉ định một điểm giao cắt cụ thể, sử dụng [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Kiểm tra các cài đặt giao cắt khi thay đổi hướng, đặc biệt nếu biểu đồ đã có một điểm giao cắt tùy chỉnh. Đặt `is_plot_order_reversed` lại `False` để khôi phục hướng vẽ bình thường; các cài đặt giao cắt là riêng biệt.

| Thứ tự bình thường (slide 1) | Danh mục đảo ngược (slide 2) | Giá trị đảo ngược (slide 3) |
| --- | --- | --- |
| ![Biểu đồ thanh ngang với thứ tự trục danh mục và giá trị bình thường](axis-order-normal.png) | ![Biểu đồ thanh ngang với danh mục hiển thị từ trên xuống dưới](axis-order-categories-reversed.png) | ![Biểu đồ thanh ngang với trục giá trị đảo ngược và giá trị 0 ở bên phải](axis-order-values-reversed.png) |
| Danh mục chạy từ dưới lên trên; giá trị tăng từ trái sang phải. | Planning, Development, và Testing chạy từ trên xuống dưới. Giá trị và thứ tự hàng workbook không thay đổi. | Danh mục giữ nguyên thứ tự bình thường; giá trị tăng từ phải sang trái. Trục category cắt tại zero ở bên phải. |

## **Vô Hiệu Hóa Trục Dọc cho Biểu Đồ Đường**

Đặt [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) thành `False` trên trục dọc để ẩn nó. Ví dụ tạo một biểu đồ đường với dữ liệu mặc định và lưu với trục dọc bị ẩn.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Vô Hiệu Hóa Trục Ngang cho Biểu Đồ Đường**

Đặt [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) thành `False` trên trục ngang để ẩn nó. Ví dụ tạo một biểu đồ đường với dữ liệu mặc định và lưu với trục ngang bị ẩn.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Hiển Thị hoặc Ẩn Lưới Biểu Đồ**

Đọc [show_major_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_major_grid_lines/) và [show_minor_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_minor_grid_lines/) để kiểm tra lưới nào một trục hiển thị. Cả hai thuộc tính này chỉ đọc. Để hiển thị lưới phụ, đặt fill cho [minor_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_grid_lines_format/) thành một màu đặc và chọn màu hiển thị. Để ẩn chúng, đặt loại fill thành `FillType.NO_FILL`. Đối với lưới chính, sử dụng [major_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_grid_lines_format/)`.line.fill_format`. Thay đổi fill vẫn giữ nguyên khả năng hiển thị trục và các đánh dấu tick.

Trục dọc của biểu đồ cột nhóm này bắt đầu với lưới chính hiển thị và lưới phụ ẩn. Ví dụ hiển thị lưới phụ màu cam, sau đó lại ẩn chúng trước khi lưu bản trình bày.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 30, 660, 230)
    axis = chart.axes.vertical_axis
    print(f"Initial: major={axis.show_major_grid_lines}, minor={axis.show_minor_grid_lines}")

    minor_fill = axis.minor_grid_lines_format.line.fill_format
    minor_fill.fill_type = slides.FillType.SOLID
    minor_fill.solid_fill_color.color = slides.Color.dark_orange
    print(f"Enabled: minor={axis.show_minor_grid_lines}")

    minor_fill.fill_type = slides.FillType.NO_FILL
    print(f"Hidden: major={axis.show_major_grid_lines}, minor={axis.show_minor_grid_lines}")

    presentation.save("ChartGridlines.pptx", slides.export.SaveFormat.PPTX)
```

| Lưới phụ được bật | Lưới phụ ẩn |
| --- | --- |
| ![Lưới phụ màu cam giữa các lưới chính trên trục dọc](minor-gridlines-enabled.png) | ![Cùng biểu đồ cột nhưng chỉ có lưới chính hiển thị](minor-gridlines-hidden.png) |

## **Thay Đổi Trục Danh Mục**

Đặt [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) để chọn trục danh mục ngày hoặc văn bản. Ví dụ này yêu cầu `ExistingChart.pptx`, với một biểu đồ là hình dạng đầu tiên trên slide đầu và các ô danh mục chứa giá trị ngày Excel dạng số. Nó thay đổi trục ngang thành trục ngày. Đặt [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) thành `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) thành `1`, và [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) thành months để đặt các tick chính cách nhau một tháng.

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

### **Xác Định Kiểu Trục Danh Mục từ Dữ Liệu**

Gọi [set_category_axis_type_automatically](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/set_category_axis_type_automatically/) sau khi điền các danh mục, sau đó đọc [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) để kiểm tra lựa chọn. Điều này hữu ích khi cùng một biểu đồ nhận hoặc nhãn văn bản hoặc giá trị ngày dạng số. Phương thức xác định kiểu khi được gọi; nó không bật chế độ cố định để đánh giá lại các thay đổi dữ liệu sau này. Gọi lại sau khi thay thế các danh mục.

Ví dụ sau tạo một biểu đồ với danh mục dạng văn bản và in ra `TEXT`. Sau đó thay thế các giá trị ô danh mục bằng ngày và gọi lại phương thức, kết quả in ra `DATE`. Ngày được lưu dưới dạng giá trị số OLE Automation, được tính ở đây là số ngày kể từ ngày 30 tháng 12 năm 1899, không phải chuỗi ngày. [custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) kiểm soát cách hiển thị các giá trị đó; nó không chuyển đổi văn bản thành ngày số. Để biết thêm về các ô danh mục, xem [Chart Workbook](/slides/vi/python-net/chart-workbook/).

Sử dụng xác định tự động khi đầu vào biết chứa danh mục văn bản hoặc ngày dạng số, như trong ví dụ này. Đối với nhãn số thường, danh mục hỗn hợp, hoặc dữ liệu rỗng, hãy đặt rõ ràng [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) để phù hợp với ý nghĩa mong muốn. Chỉ có giá trị số không tự động xác định rằng danh mục đại diện cho ngày.

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series_name = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name, chart.type)
    labels = ["First", "Second", "Third"]

    for i, label in enumerate(labels):
        category_cell = workbook.get_cell(0, i + 1, 0, label)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, (i + 1) * 10)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.set_category_axis_type_automatically()
    print(axis.category_axis_type.name)  # VĂN BẢN

    dates = [date(2026, 1, 1), date(2026, 1, 2), date(2026, 2, 1)]

    for i, category_date in enumerate(dates):
        category_cell = workbook.get_cell(0, i + 1, 0)
        category_cell.value = float((category_date - date(1899, 12, 30)).days)
        category_cell.custom_number_format = "yyyy-mm-dd"

    axis.set_category_axis_type_automatically()
    print(axis.category_axis_type.name)  # NGÀY

    presentation.save("AutomaticCategoryAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Kiểm Soát Khoảng Cách Nhãn Trục Danh Mục**

Khi một biểu đồ có nhiều danh mục, giảm số lượng nhãn trục hiển thị mà không loại bỏ danh mục hoặc điểm dữ liệu. Đặt [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) thành `False`, rồi đặt [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) thành khoảng cách danh mục mong muốn. Đối với danh mục văn bản theo thứ tự bình thường, việc đếm bắt đầu từ danh mục đầu tiên:

| Khoảng | Nhãn hiển thị trong ví dụ |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

Khoảng `3` hiển thị mỗi nhãn thứ ba, để lại hai nhãn ẩn giữa các nhãn được hiển thị. Nó không loại bỏ các cột tương ứng. Khoảng cách tự động chọn khoảng dựa trên không gian có sẵn; nó không nhất thiết hiển thị mọi nhãn.

Các đánh dấu tick có các điều khiển riêng. Đặt [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) thành `False` và dùng [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) để đặt khoảng cách của chúng. Ví dụ, `1` giữ một tick ở mỗi khoảng danh mục trong khi nhãn chỉ xuất hiện mỗi danh mục thứ ba. Đặt [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) thành kiểu hiển thị để bạn có thể thấy kết quả. Đặt lại thuộc tính tự động‑spacing nào đó về `True` cho phép biểu đồ chọn lại khoảng đó.

Ví dụ tự chứa sau tạo 24 danh mục và một series, rồi lưu ba slide trong `CategoryAxisIntervals.pptx`: khoảng cách tự động, khoảng cách nhãn thủ công với các tick độc lập, và khôi phục khoảng cách tự động. Hai bản sao giữ dữ liệu biểu đồ gốc. Không cần bản trình bày đầu vào. Văn bản nhãn ngang làm cho mật độ dễ nhận thấy hơn.

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

    # Slide 2: hiển thị mỗi nhãn thứ ba, nhưng giữ một dấu tick cho mỗi danh mục.
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

**Automatic spacing (slide 1):** Trong bản render này, mỗi nhãn danh mục thứ hai được hiển thị và ngắt dòng thành hai dòng. Kết quả tự động có thể thay đổi tùy kích thước biểu đồ, phông chữ và bộ render.

![Khoảng cách nhãn danh mục tự động với tất cả 24 cột hiển thị](category-axis-automatic.png)

**Manual spacing (slide 2):** Mỗi nhãn thứ ba được hiển thị trên một dòng, trong khi các tick vẫn ở mỗi khoảng danh mục. Tất cả 24 cột, bao gồm cả những cột không có nhãn, vẫn hiển thị với cùng các giá trị. Slide 3 khôi phục lại giao diện tự động như trên.

![Khoảng cách nhãn danh mục thủ công ba với tất cả 24 cột hiển thị](category-axis-manual.png)

### **Chọn Trục và Khoảng Đúng**

Sử dụng khoảng đếm danh mục này cho trục danh mục dạng văn bản, chẳng hạn trục danh mục của biểu đồ cột, đường, khu vực hoặc thanh. Trong biểu đồ cột, nó là trục ngang. Trong biểu đồ thanh ngang, trục danh mục là trục dọc, vì vậy áp dụng các cài đặt này cho [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Khoảng cách đánh dấu tick cũng áp dụng cho trục series trong các biểu đồ có trục series.

Không dùng khoảng cách nhãn danh mục để đặt thang số cho trục giá trị. Trên trục giá trị, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) chỉ ra sự chênh lệch giá trị: ví dụ, một major unit là `10` tạo các tick tại 0, 10, 20, … khi trục bắt đầu từ zero. Một khoảng nhãn danh mục `3` đếm vị trí danh mục, bất kể giá trị dữ liệu của chúng. Các biểu đồ scatter và bubble dùng trục giá trị thay vì trục danh mục văn bản. Đối với trục ngày, dùng các unit và thang thời gian như mô tả trong [Change a Category Axis](#change-a-category-axis).

## **Đặt Định Dạng Ngày cho Giá Trị Trục Danh Mục**

Ví dụ thay thế dữ liệu biểu đồ mặc định bằng bốn giá trị hàng năm. Ngày được lưu dưới dạng số serial OLE Automation trong bảng tính đầu tiên (chỉ mục `0`). Đặt [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) thành trục ngày, tắt [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/), và gán `yyyy` cho [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) để nhãn danh mục hiển thị năm bốn chữ số độc lập với định dạng ô.

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

Bật [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) trên trục dọc, cung cấp văn bản tiêu đề, và đặt [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) để xoay tiêu đề. Góc được đo bằng độ; ví dụ này lưu một biểu đồ cột với tiêu đề trục giá trị đã xoay 90 độ.

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

Sử dụng [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) để kiểm soát việc trục giá trị cắt trục danh mục giữa các danh mục hoặc tại các tick danh mục. Thuộc tính này áp dụng cho trục danh mục. Ví dụ đặt nó thành `True` trên trục danh mục ngang của biểu đồ cột và lưu kết quả.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt Đơn Vị Hiển Thị trên Trục Giá Trị của Biểu Đồ**

Đặt [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) để thu nhỏ các nhãn trên trục giá trị mà không thay đổi dữ liệu nền. Với [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) được đặt thành `MILLIONS`, giá trị 60,000,000 sẽ hiển thị là 60. Ví dụ tạo một biểu đồ cột và áp dụng đơn vị hiển thị triệu cho trục dọc.

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

Trục giá trị logarit hữu ích khi các giá trị dương trải rộng qua nhiều bậc. Ví dụ, một dịch vụ có thể nhận 10, 100, 1,000, 10,000 và 100,000 yêu cầu trong năm giai đoạn. Trên thang tuyến tính, các giá trị nhỏ hơn xuất hiện gần nhau ở gần zero. Thang logarit làm cho sự tăng trưởng tương đối dễ so sánh hơn: khoảng cách bằng nhau đại diện cho tỉ lệ bằng nhau thay vì chênh lệch bằng nhau.

Đặt [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) thành `True` trên trục giá trị và dùng [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) để chọn cơ sở. Điều này thay đổi cách hiển thị các giá trị hiện có; nó không thay đổi dữ liệu hay thêm đường xu hướng logarit. Đường xu hướng là một tính năng riêng biệt biểu diễn mối quan hệ phù hợp trong dữ liệu.

### **Chọn Trục Giá Trị và Cơ Sở**

Đối với biểu đồ đường hoặc cột, trục giá trị là [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Đối với biểu đồ thanh ngang, nó là [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Các biểu đồ scatter và bubble có hai trục giá trị, vì vậy chọn trục ngang cho giá trị X, trục dọc cho giá trị Y, hoặc cả hai. Không áp dụng tỷ lệ logarit cho trục danh mục.

Cơ sở logarit mặc định là `10`. Đối với biểu đồ PPTX, sử dụng cơ sở từ `2` đến `1000`, bao gồm; các cơ sở phân số như `2.5` cũng được hỗ trợ. Với cơ sở `10`, các lũy thừa liên tiếp như 10, 100, 1,000 và 10,000 có khoảng cách đều nhau.

### **So Sánh Độ Phóng Đường Thẳng và Logarit**

Ví dụ tự chứa sau tạo một biểu đồ đường với năm lượt yêu cầu trên slide đầu, sau đó sao chép slide đó và bật trục giá trị logarit cơ sở 10 trên slide thứ hai. Cả hai slide giữ cùng một dữ liệu.

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

    # Giữ slide đầu tiên ở dạng tuyến tính và chỉ thay đổi thang trục giá trị của bản sao.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Linear scale (slide 1):** Khoảng cách dọc bằng nhau đại diện cho sự chênh lệch yêu cầu bằng nhau. Giá trị lớn nhất chi phối biểu đồ, khiến các giá trị nhỏ khó phân biệt.

![Biểu đồ đường trong PowerPoint hiển thị năm lượng yêu cầu trên trục giá trị tuyến tính](value-axis-linear.png)

**Logarithmic scale (slide 2):** Khoảng cách dọc bằng nhau đại diện cho tỉ lệ bằng nhau. Mỗi giai đoạn có số yêu cầu gấp mười lần so với giai đoạn trước, vì vậy các điểm tạo thành một đường thẳng tăng trên thang logarit cơ sở 10. Nhãn trục vẫn hiển thị số lượng yêu cầu gốc.

![Cùng năm lượng yêu cầu trong PowerPoint trên trục giá trị logarit cơ sở 10](value-axis-logarithmic.png)

### **Xử Lý Giá Trị Zero và Âm**

Thang logarit chỉ hiển thị các giá trị dương tuyệt đối. Kiểm tra dữ liệu trước khi bật. Nếu zero hoặc giá trị âm có ý nghĩa, giữ thang tuyến tính hoặc hiển thị chúng riêng. Nếu việc loại bỏ các giá trị này phù hợp với phân tích, giải thích lý do. Không nên thay thế im lặng bằng các số dương nhỏ, vì điều này thay đổi ý nghĩa dữ liệu. Bất kỳ giá trị tối thiểu hoặc tối đa nào được cấu hình thủ công cho trục logarit cũng phải là dương.

## **Câu Hỏi Thường Gặp**

**Làm thế nào để đặt giá trị mà một trục cắt qua trục kia (giao điểm trục)?**

Sử dụng [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) để chọn hành vi giao cắt. Để chỉ định một giá trị giao cắt số, đặt [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Các cài đặt này cho phép bạn di chuyển giao điểm trục tới mức baseline phù hợp.

**Làm thế nào để định vị nhãn tick tương đối với trục?**

Đặt [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) bằng cách sử dụng [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/): `LOW`, `HIGH`, `NEXT_TO`, hoặc `NONE`. Để kiểm soát các đánh dấu tick, sử dụng [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) hoặc [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/); chúng tách biệt với vị trí nhãn.