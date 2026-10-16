---
title: Quản lý Nhãn Dữ Liệu Biểu Đồ trong Bản Trình Chiếu bằng Python
linktitle: Nhãn Dữ Liệu
type: docs
url: /vi/python-net/chart-data-label/
keywords:
- biểu đồ
- nhãn dữ liệu
- độ chính xác dữ liệu
- phần trăm
- khoảng cách nhãn
- vị trí nhãn
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tìm hiểu cách thêm và định dạng nhãn dữ liệu biểu đồ trong các bản trình chiếu PowerPoint bằng Aspose.Slides cho Python thông qua .NET để tạo các slide hấp dẫn hơn."
---
## **Giới thiệu**

Nhãn dữ liệu hiển thị thông tin về chuỗi biểu đồ và các điểm dữ liệu riêng lẻ, giúp người đọc xác định giá trị và hiểu biểu đồ. Bài viết này giải thích cách định dạng giá trị, hiển thị phần trăm, đọc văn bản nhãn, điều khiển nhãn vượt quá giá trị tối đa của trục, điều chỉnh khoảng cách nhãn trục danh mục và định vị nhãn biểu đồ tròn.

## **Đặt Độ Chính Xác Dữ Liệu trong Nhãn Dữ Liệu Biểu Đồ**

Sử dụng [number_format_of_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/number_format_of_values/) để định dạng giá trị của chuỗi. Ví dụ này tạo một biểu đồ đường với dữ liệu mặc định, hiển thị bảng dữ liệu và bật nhãn giá trị cho chuỗi đầu tiên. Định dạng `#,##0.00` hiển thị dấu phân cách hàng nghìn và hai chữ số thập phân mà không thay đổi giá trị gốc.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
    chart.has_data_table = True

    series = chart.chart_data.series[0]
    series.number_format_of_values = "#,##0.00"
    series.labels.default_data_label_format.show_value = True

    presentation.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hiển Thị Phần Trăm dưới Dạng Nhãn**

Đối với biểu đồ cột chồng, tính mỗi giá trị dưới dạng phần trăm của tổng danh mục và gán văn bản cho [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). Ví dụ này sử dụng dữ liệu biểu đồ mặc định và hiển thị phần trăm với hai chữ số thập phân trong phông chữ 8 điểm. Các danh mục có tổng bằng không sẽ bị bỏ qua để tránh chia cho zero. Tính lại văn bản nhãn tùy chỉnh nếu dữ liệu biểu đồ thay đổi.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)

    category_totals = [0.0] * len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for series in chart.chart_data.series:
            point_value = float(series.data_points[k].value.data)
            category_totals[k] += point_value

    for series in chart.chart_data.series:
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            label = series.data_points[j].label
            if category_totals[j] == 0:
                continue

            point_value = float(series.data_points[j].value.data)
            data_point_percent = point_value / category_totals[j] * 100

            portion = slides.Portion()
            portion.text = f"{data_point_percent:.2f} %"
            portion.portion_format.font_height = 8

            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(portion)

            label.data_label_format.show_value = True
            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt Dấu Phần Trăm trong Nhãn Dữ Liệu Biểu Đồ**

Khi giá trị được lưu dưới dạng phân số, sử dụng [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) để hiển thị phần trăm. Đặt [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) thành `False` để áp dụng định dạng nhãn một cách độc lập với các ô nguồn.

Ví dụ này tạo một biểu đồ cột chồng 100% với các chuỗi màu đỏ và xanh lam trên bốn danh mục. Mỗi cặp giá trị cộng lại bằng 1. Định dạng nhãn `0.0%` hiển thị 0.30 thành 30.0%, trong khi trục tung sử dụng hai chữ số thập phân. Cả hai chuỗi đều sử dụng văn bản nhãn màu trắng, kích thước 10 điểm.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [drawing.Color.red, drawing.Color.blue]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i in range(len(series_names)):
        series_cell = workbook.get_cell(worksheet_index, 0, i + 1, series_names[i])
        series = chart.chart_data.series.add(series_cell, chart.type)
        for j in range(4):
            value_cell = workbook.get_cell(worksheet_index, j + 1, i + 1, values[i][j])
            series.data_points.add_data_point_for_bar_series(value_cell)

        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = series_colors[i]

        label_format = series.labels.default_data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = False
        label_format.number_format = "0.0%"
        label_format.text_format.portion_format.font_height = 10
        label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.text_format.portion_format.fill_format.solid_fill_color.color = drawing.Color.white

    presentation.save("SetDataLabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Đọc Văn Bản Thực Tế của Nhãn Dữ Liệu**

Sử dụng [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) để lấy văn bản được tạo ra bởi cài đặt của nhãn dữ liệu. Điều này hữu ích khi trích xuất nhãn cho báo cáo, tìm kiếm nội dung trong bản trình chiếu hoặc xác thực các biểu đồ đã tạo. Trong ví dụ dưới đây, [định dạng nhãn dữ liệu](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/) mặc định kết hợp mỗi tên danh mục, tên chuỗi và giá trị. Một điểm định dạng giá trị của nó dưới dạng phần trăm, và một điểm khác sử dụng văn bản tùy chỉnh từ [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    for i, category_name in enumerate(["Q1", "Q2"]):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    north_cell = workbook.get_cell(0, 0, 1, "North")
    north = chart.chart_data.series.add(north_cell, chart.type)
    for i, value in enumerate([0.25, 0.75]):
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        north.data_points.add_data_point_for_bar_series(value_cell)

    south_cell = workbook.get_cell(0, 0, 2, "South")
    south = chart.chart_data.series.add(south_cell, chart.type)
    for i, value in enumerate([0.40, 0.60]):
        value_cell = workbook.get_cell(0, i + 1, 2, value)
        south.data_points.add_data_point_for_bar_series(value_cell)

    for series in chart.chart_data.series:
        label_format = series.labels.default_data_label_format
        label_format.show_category_name = True
        label_format.show_series_name = True
        label_format.show_value = True

    north.labels[1].data_label_format.is_number_format_linked_to_source = False
    north.labels[1].data_label_format.number_format = "0%"
    south.labels[0].text_frame_for_overriding.text = "Reviewed"

    for series in chart.chart_data.series:
        for point in series.data_points:
            label = point.label
            if not label.is_visible:
                continue

            label_text = label.get_actual_label_text()
            print(f"Value: {point.value.data}; label: {label_text}")
```

Số lưu trong một điểm dữ liệu vẫn là `0.75`, ngay cả khi nhãn của nó hiển thị `75%` cùng với tên danh mục và chuỗi. Văn bản tùy chỉnh thay thế nhãn được tạo ra. [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) trả về chuỗi nhãn kết quả trong cả hai trường hợp. Kiểm tra [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/) riêng biệt, như đã mô tả ở trên, khi bạn muốn trích xuất chỉ các nhãn hiển thị.

## **Kiểm Soát Nhãn Dữ Liệu Vượt Qua Giá Trị Tối Đa của Trục**

Khi bạn giới hạn phạm vi trục theo cách thủ công, một số điểm dữ liệu có thể vượt quá giá trị tối đa của nó. Sử dụng [show_data_labels_over_maximum](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) để kiểm soát việc hiển thị nhãn dữ liệu của chúng. Cài đặt này thay đổi khả năng hiển thị nhãn; nó không thay đổi phạm vi trục hay giá trị dữ liệu gốc.

Ví dụ dưới đây tạo một biểu đồ cột cụm 2D với các giá trị 60 và 120. Nó đặt [is_automatic_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/) thành `False` và [max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/) thành 100 trên trục tung. Bản slide đầu tiên cho phép nhãn vượt quá giá trị tối đa; một bản sao của slide đó tắt tính năng này. Cả hai slide đều được lưu trong `DataLabelsOverMaximum.pptx`.

Bật nhãn giá trị với [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). Cài đặt mức biểu đồ không tự động bật hiển thị giá trị, cũng không ghi đè lên việc tắt hiển thị của một nhãn riêng lẻ. Ví dụ này bật giá trị cho toàn bộ chuỗi và sử dụng [position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/) để đặt nhãn ở đầu ngoài mỗi cột.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    first_category = workbook.get_cell(0, 1, 0, "Within range")
    second_category = workbook.get_cell(0, 2, 0, "Above maximum")

    chart.chart_data.categories.add(first_category)
    chart.chart_data.categories.add(second_category)

    series_name = workbook.get_cell(0, 0, 1, "Values")
    series = chart.chart_data.series.add(series_name, chart.type)

    first_value = workbook.get_cell(0, 1, 1, 60)
    second_value = workbook.get_cell(0, 2, 1, 120)

    series.data_points.add_data_point_for_bar_series(first_value)
    series.data_points.add_data_point_for_bar_series(second_value)

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 100
    chart.show_data_labels_over_maximum = True

    second_slide = presentation.slides.add_clone(slide)
    second_chart = second_slide.shapes[0]
    second_chart.show_data_labels_over_maximum = False

    presentation.save("DataLabelsOverMaximum.pptx", slides.export.SaveFormat.PPTX)
```

Các hình ảnh sau hiển thị các slide đã lưu được Microsoft PowerPoint render. Khi `True`, nhãn **120** hiển thị ở rìa trên; khi `False`, nhãn này ẩn. Nhãn **60** vẫn hiển thị, giá trị tối đa của trục vẫn là **100**, và điểm dữ liệu thứ hai vẫn là **120** trong cả hai trường hợp.

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![Biểu đồ PowerPoint hiển thị nhãn giá trị 120 với giá trị tối đa trục là 100](data-labels-over-maximum-true.png) | ![Biểu đồ PowerPoint ẩn nhãn giá trị 120 với giá trị tối đa trục là 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Ví dụ này sử dụng biểu đồ cột 2D có trục giá trị. Các biểu đồ không có trục giá trị, chẳng hạn như biểu đồ tròn và bánh donut, không có giá trị tối đa của trục để giới hạn theo cách này.
{{% /alert %}}

## **Đặt Khoảng Cách Nhãn Từ Trục**

Sử dụng [label_offset](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/) để kiểm soát khoảng cách giữa nhãn trục danh mục và trục. Giá trị là phần trăm của kích thước phông chữ tối đa của các nhãn trục. Ví dụ này tạo một biểu đồ cột cụm và đặt độ lệch nhãn trục ngang thành 500. Cài đặt này ảnh hưởng đến nhãn trục danh mục hơn là nhãn gắn vào các điểm dữ liệu riêng lẻ.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Điều Chỉnh Vị Trí Nhãn**

Trên biểu đồ tròn, điều chỉnh vị trí nhãn dữ liệu để cải thiện khoảng cách và tạo không gian cho các đường dẫn.

Ví dụ này hiển thị giá trị của điểm dữ liệu đầu tiên, đặt nhãn của nó bên ngoài phần trăm, và điều chỉnh các độ lệch [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) và [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/). Các độ lệch này tính tương đối so với chiều rộng và chiều cao của biểu đồ.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 200, 200)
    series = chart.chart_data.series

    label = series[0].labels[0]
    label.data_label_format.show_value = True
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label.x = 0.71
    label.y = 0.04

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Biểu đồ tròn với vị trí nhãn dữ liệu đã điều chỉnh](pie-chart-adjusted-label.png)

## **Định Dạng Đường Dẫn (Leader Lines)**

Khi nhãn biểu đồ tròn nằm ngoài các phần, đường dẫn giúp người đọc ghép mỗi giá trị với phần tương ứng. Một màu đối lập và đường hơi dày hơn có thể làm cho các kết nối này dễ theo dõi hơn, trong khi độ trong suốt và kiểu gạch chéo giữ cho đường không gây mất thẩm mỹ.

Sử dụng [leader_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/leader_lines_format/) để định dạng đường dẫn ở mức bộ sưu tập nhãn dữ liệu của chuỗi. Các cài đặt trong `series.labels.leader_lines_format.line` áp dụng cho toàn bộ bộ sưu tập, không phải cho từng nhãn riêng lẻ.

Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định, hiển thị giá trị bên ngoài các phần và bật [show_leader_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_leader_lines/). Nó di chuyển hai nhãn xa hơn so với phần của chúng bằng cách sử dụng các độ lệch [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) và [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/), biểu thị dưới dạng phần của chiều rộng và chiều cao biểu đồ. Không cần bản trình bày đầu vào.

Định dạng [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) của đường đặt màu xanh đậm đặc với giá trị alpha 191 trong tổng số 255, cho độ trong suốt khoảng 25%. [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) đặt độ dày thành 2 điểm, và [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) làm cho đường thành gạch chéo.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 80, 50, 560, 400)
    chart.has_legend = False

    series = chart.chart_data.series[0]

    label_format = series.labels.default_data_label_format
    label_format.show_value = True
    label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label_format.show_leader_lines = True

    # Di chuyển hai nhãn xa hơn so với các phần của chúng.
    series.labels[0].x = 0.10
    series.labels[0].y = -0.05
    series.labels[1].x = -0.10
    series.labels[1].y = 0.05

    line = series.labels.leader_lines_format.line
    line.fill_format.fill_type = slides.FillType.SOLID
    line.fill_format.solid_fill_color.color = drawing.Color.from_argb(191, 30, 90, 160)
    line.width = 2
    line.dash_style = slides.LineDashStyle.DASH

    presentation.save("FormattedLeaderLines.pptx", slides.export.SaveFormat.PPTX)
```

Bật đường dẫn không chắc chắn rằng mỗi nhãn sẽ có một đường. Khả năng hiển thị phụ thuộc vào vị trí nhãn và hành vi bố trí của biểu đồ. Trong ví dụ này, hai nhãn bị dịch ra có đường dẫn hiển thị; các nhãn còn gần phần của chúng không cần đường dẫn.

Hình ảnh sau hiển thị file `FormattedLeaderLines.pptx` đã được Aspose.Slides render:

![Biểu đồ tròn với các đường dẫn màu xanh, bán trong suốt, gạch chéo nối hai nhãn ngoài vào phần của chúng](formatted-leader-lines.png)

## **Thêm Nhiều Hàng Nhãn Dữ Liệu phía Trên Biểu Đồ Cột**

Ví dụ này tạo một biểu đồ cột với hai hàng nhãn dữ liệu phía trên vùng vẽ. Chuỗi A hiển thị các cột có thể nhìn thấy, trong khi Chuỗi B và Chuỗi C cung cấp các nhãn bổ sung. Các cột của chúng được ẩn bằng cách loại bỏ màu nền và viền. Thuộc tính [overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) căn chỉnh ba chuỗi với cùng trung tâm danh mục.

Cài đặt [plot_area](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/) dành không gian cho các hàng nhãn. Sau khi [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) tính toán vị trí mặc định, các độ lệch [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) và [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) duy trì căn chỉnh ngang và áp dụng độ lệch dọc để sắp xếp nhãn thành hai hàng. Các số vẫn là nhãn dữ liệu liên kết với giá trị của chuỗi; chỉ tiêu đề hàng là các hình dạng văn bản riêng biệt.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 40, 640, 200)
    chart.has_title = False
    chart.has_legend = False
    chart.text_format.portion_format.font_height = 12

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [
        [35, 42, 28, 47],
        [22, 31, 19, 26],
        [12, 16, 14, 18]
    ]

    for category_index, category_name in enumerate(categories):
        category_cell = workbook.get_cell(0, category_index + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.get_cell(0, 0, series_index + 1, series_name)
        series = chart.chart_data.series.add(series_cell, charts.ChartType.CLUSTERED_COLUMN)

        for category_index in range(len(categories)):
            value_cell = workbook.get_cell(0, category_index + 1, series_index + 1, series_values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

        if series_index > 0:
            # Ẩn các cột B và C, nhưng giữ lại nhãn dữ liệu của chúng.
            series.format.fill.fill_type = slides.FillType.NO_FILL
            series.format.line.fill_format.fill_type = slides.FillType.NO_FILL
            label_format = series.labels.default_data_label_format
            label_format.show_value = True
            label_format.text_format.portion_format.font_height = 12
            label_fill = label_format.text_format.portion_format.fill_format
            label_fill.fill_type = slides.FillType.SOLID
            label_fill.solid_fill_color.color = drawing.Color.black
            label_format.position = charts.LegendDataLabelPosition.INSIDE_BASE

    # Căn chỉnh cả ba chuỗi sao cho trung tâm danh mục giống nhau.
    chart.chart_data.series[0].parent_series_group.overlap = 100

    # Sử dụng ít đường lưới hơn cho ví dụ gọn này.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.major_unit = 10

    # Dành không gian phía trên vùng vẽ cho hai hàng nhãn dữ liệu.
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER
    chart.plot_area.x = 0.15
    chart.plot_area.y = 0.32
    chart.plot_area.width = 0.80
    chart.plot_area.height = 0.48
    chart.validate_chart_layout()

    for series_index in range(1, len(series_names)):
        series = chart.chart_data.series[series_index]
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.data_points[category_index].label
            # Giữ vị trí ngang mặc định. Y là độ lệch từ
            # vị trí nhãn mặc định, biểu thị dưới dạng tỉ lệ chiều cao biểu đồ.
            data_label.x = 0
            data_label.y = row_top - data_label.actual_y / chart.height

        # Chỉ tiêu đề hàng là một hình dạng văn bản riêng biệt.
        row_heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, chart.x, chart.y + row_top * chart.height, 85, 18)
        row_heading.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.add_text_frame(series_names[series_index])
        row_heading.text_frame.text_frame_format.margin_top = 0
        row_heading.text_frame.text_frame_format.margin_bottom = 0
        heading_format = row_heading.text_frame.paragraphs[0].portions[0].portion_format
        heading_format.font_height = 12
        heading_format.fill_format.fill_type = slides.FillType.SOLID
        heading_format.fill_format.solid_fill_color.color = drawing.Color.black

    presentation.save("multiple-rows-of-labels.pptx", slides.export.SaveFormat.PPTX)
```

![Biểu đồ cột với hai hàng nhãn dữ liệu phía trên vùng vẽ](multiple-rows-of-labels.png)

## **Câu hỏi thường gặp**

**Làm thế nào để ngăn nhãn dữ liệu chồng lấp trên các biểu đồ dày đặc?**

Kết hợp việc đặt nhãn tự động, đường dẫn và giảm kích thước phông chữ; nếu cần, ẩn một số trường (ví dụ, danh mục) hoặc chỉ hiển thị nhãn cho các giá trị cực đoan hoặc các điểm quan trọng.

**Làm thế nào để tắt nhãn chỉ cho các giá trị bằng không, âm hoặc trống?**

Lọc các điểm dữ liệu trước khi bật nhãn và tắt hiển thị cho các giá trị bằng 0, giá trị âm hoặc giá trị bị thiếu theo quy tắc đã định nghĩa.

**Làm thế nào để đảm bảo phong cách nhãn nhất quán khi xuất ra PDF/hình ảnh?**

Thiết lập rõ ràng họ phông chữ và kích thước, đồng thời xác nhận phông chữ có sẵn trong môi trường render để tránh việc sử dụng phông dự phòng.