---
title: Quản lý nhãn dữ liệu biểu đồ trong bản trình bày bằng Python
linktitle: Nhãn dữ liệu
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
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Tìm hiểu cách thêm và định dạng nhãn dữ liệu biểu đồ trong các bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho Python thông qua .NET để tạo các slide hấp dẫn hơn."
---
## **Tổng quan**

Nhãn dữ liệu trên biểu đồ hiển thị chi tiết về các chuỗi dữ liệu của biểu đồ hoặc các điểm dữ liệu riêng lẻ. Chúng cho phép người đọc nhanh chóng xác định các chuỗi dữ liệu và cũng làm cho biểu đồ dễ hiểu hơn. Trong Aspose.Slides cho Python, bạn có thể bật, tùy chỉnh và định dạng nhãn dữ liệu cho bất kỳ biểu đồ nào — chọn những gì hiển thị (giá trị, phần trăm, tên chuỗi hoặc danh mục), vị trí đặt nhãn, và cách chúng trông như thế nào (phông chữ, định dạng số, dấu phân cách, đường dẫn dẫn, và hơn thế nữa). Bài viết này phác thảo các API thiết yếu và ví dụ bạn cần để thêm các nhãn rõ ràng, thông tin vào biểu đồ của mình.

## **Đặt độ chính xác cho nhãn dữ liệu**

Nhãn dữ liệu của biểu đồ thường hiển thị các giá trị số cần độ chính xác đồng nhất. Phần này chỉ cách kiểm soát số chữ số thập phân cho nhãn dữ liệu trong Aspose.Slides bằng cách áp dụng định dạng số phù hợp.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 500, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.number_format_of_values = "#,##0.00"

    presentation.save("data_label_precision.pptx", slides.export.SaveFormat.PPTX)
```

## **Hiển thị phần trăm dưới dạng nhãn**

Với Aspose.Slides, bạn có thể hiển thị phần trăm dưới dạng nhãn dữ liệu trên biểu đồ. Ví dụ dưới đây tính tỷ lệ phần trăm của mỗi điểm trong danh mục của nó và định dạng nhãn để hiển thị phần trăm.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Tạo một thể hiện của lớp Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 600, 400)
    series = chart.chart_data.series[0]

    total_for_categories = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for i in range(len(chart.chart_data.series)):
            total_for_categories[k] += chart.chart_data.series[i].data_points[k].value.data

    for i in range(len(chart.chart_data.series)):
        series = chart.chart_data.series[i]
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            data_point_percent = series.data_points[j].value.data / total_for_categories[j] * 100

            text_portion = slides.Portion()
            text_portion.text = "{0:.2f} %".format(data_point_percent)
            text_portion.portion_format.font_height = 8

            label = series.data_points[j].label
            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(text_portion)

            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

# Lưu bản trình bày chứa biểu đồ.
presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Hiển thị ký hiệu phần trăm cùng với nhãn dữ liệu biểu đồ**

Phần này chỉ cách hiển thị phần trăm trong nhãn dữ liệu biểu đồ và bao gồm ký hiệu phần trăm bằng Aspose.Slides. Bạn sẽ học cách bật giá trị phần trăm cho toàn bộ chuỗi hoặc các điểm cụ thể (thích hợp cho biểu đồ tròn, bánh răng và biểu đồ chồng 100%) và cách kiểm soát định dạng thông qua tùy chọn nhãn hoặc định dạng số tùy chỉnh.

Ví dụ Python sau đây cho thấy cách thêm ký hiệu phần trăm vào nhãn dữ liệu của biểu đồ:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# Tạo một thể hiện của lớp Presentation.
with slides.Presentation() as presentation:

    # Lấy tham chiếu slide theo chỉ mục.
    slide = presentation.slides[0]

    # Tạo một biểu đồ PercentsStackedColumn trên slide.
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # Lấy sổ làm việc dữ liệu biểu đồ.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    # Thêm một chuỗi mới.
    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 0.65))

    # Đặt màu nền cho chuỗi.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Đặt các thuộc tính định dạng nhãn.
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # Thêm một chuỗi mới.
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # Đặt loại nền và màu.
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # Lưu bản trình bày.
    presentation.save("percentage_sign.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt khoảng cách nhãn so với trục**

Phần này chỉ cách kiểm soát khoảng cách giữa nhãn dữ liệu và trục biểu đồ trong Aspose.Slides. Điều chỉnh khoảng cách này giúp tránh chồng lấn và cải thiện khả năng đọc trong các biểu đồ dày đặc.

Mã Python sau đây cho thấy cách đặt khoảng cách nhãn so với trục danh mục khi làm việc với biểu đồ có trục:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Tạo một thể hiện của lớp Presentation.
with slides.Presentation() as presentation:
    # Lấy tham chiếu slide.
    slide = presentation.slides[0]

    # Tạo một biểu đồ cột nhóm trên slide.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Đặt khoảng cách nhãn so với trục danh mục (ngang).
    chart.axes.horizontal_axis.label_offset = 500

    # Lưu bản trình bày.
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```

## **Điều chỉnh vị trí nhãn**

Khi bạn tạo biểu đồ không sử dụng trục, như biểu đồ tròn, nhãn dữ liệu có thể quá gần mép. Trong trường hợp đó, hãy điều chỉnh vị trí nhãn để các đường dẫn hiển thị rõ ràng.

Mã Python dưới đây cho thấy cách điều chỉnh vị trí nhãn trên biểu đồ tròn:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.show_leader_lines = True

    label = series.labels[0]
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    label.x = 0.05
    label.y = 0.1

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Changed label position](changed_label_position.png)

## **Câu hỏi thường gặp**

**Làm sao tôi có thể ngăn nhãn dữ liệu chồng lên nhau trên các biểu đồ dày đặc?**

Kết hợp việc đặt nhãn tự động, các đường dẫn và giảm kích thước phông chữ; nếu cần, ẩn một số trường (ví dụ, danh mục) hoặc chỉ hiển thị nhãn cho các điểm cực đoan/quan trọng.

**Làm sao tôi có thể vô hiệu hoá nhãn chỉ cho các giá trị bằng không, âm hoặc trống?**

Lọc các điểm dữ liệu trước khi bật nhãn và tắt hiển thị cho các giá trị bằng 0, giá trị âm hoặc giá trị thiếu theo một quy tắc đã định.

**Làm sao tôi có thể đảm bảo phong cách nhãn nhất quán khi xuất ra PDF/hình ảnh?**

Cài đặt rõ ràng phông chữ (họ, kích thước) và xác minh rằng phông chữ có sẵn ở phía máy render để tránh việc thay thế.