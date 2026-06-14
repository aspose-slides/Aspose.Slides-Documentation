---
title: Định dạng biểu đồ trong bản thuyết trình bằng Python
linktitle: Định dạng biểu đồ
type: docs
weight: 60
url: /vi/python-net/chart-formatting/
keywords:
- định dạng biểu đồ
- định dạng biểu đồ
- thực thể biểu đồ
- thuộc tính biểu đồ
- cài đặt biểu đồ
- tùy chọn biểu đồ
- thuộc tính phông chữ
- viền bo tròn
- PowerPoint
- OpenDocument
- bản thuyết trình
- Python
- Aspose.Slides
description: "Tìm hiểu cách định dạng biểu đồ trong Aspose.Slides cho Python qua .NET và nâng cấp bản thuyết trình PowerPoint hoặc OpenDocument của bạn với phong cách chuyên nghiệp, bắt mắt."
---
## **Tổng quan**

Bài viết này giải thích cách định dạng biểu đồ trong bản thuyết trình PowerPoint bằng cách sử dụng Aspose.Slides. Nó cho thấy cách tùy chỉnh các yếu tố chính của biểu đồ như trục, đường lưới, tiêu đề, chú giải, khu vực vẽ và màu nền tường để cải thiện giao diện và khả năng đọc dữ liệu biểu đồ.

Nó cũng trình bày cách thiết lập thuộc tính phông chữ cho văn bản biểu đồ, áp dụng các định dạng số có sẵn và tùy chỉnh cho dữ liệu biểu đồ, và bật các góc bo tròn cho khu vực biểu đồ. Cùng nhau, những ví dụ này cho thấy cách kiểm soát cả kiểu dáng trực quan và cách trình bày dữ liệu của biểu đồ trong bản thuyết trình.

## **Định dạng các thành phần biểu đồ**

Aspose.Slides cho Python cho phép các nhà phát triển thêm biểu đồ tùy chỉnh vào các slide từ đầu. Phần này giải thích cách định dạng các thành phần biểu đồ khác nhau, bao gồm trục danh mục và trục giá trị.

Aspose.Slides cung cấp một API đơn giản để quản lý các thành phần biểu đồ và áp dụng định dạng tùy chỉnh:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới slide theo chỉ mục của nó.
1. Thêm một biểu đồ với dữ liệu mặc định của loại mong muốn (trong ví dụ này, `ChartType.LINE_WITH_MARKERS`).
1. Truy cập trục giá trị của biểu đồ và thiết lập các mục sau:
   1. Đặt **định dạng đường** cho các đường lưới chính của trục giá trị.
   1. Đặt **định dạng đường** cho các đường lưới phụ của trục giá trị.
   1. Đặt **định dạng số** cho trục giá trị.
   1. Đặt **đơn vị min, max, chính và phụ** cho trục giá trị.
   1. Đặt **thuộc tính văn bản** cho nhãn trục giá trị.
   1. Đặt **tiêu đề** cho trục giá trị.
   1. Đặt **định dạng đường** cho trục giá trị.
1. Truy cập trục danh mục của biểu đồ và thiết lập các mục sau:
   1. Đặt **định dạng đường** cho các đường lưới chính của trục danh mục.
   1. Đặt **định dạng đường** cho các đường lưới phụ của trục danh mục.
   1. Đặt **thuộc tính văn bản** cho nhãn trục danh mục.
   1. Đặt **tiêu đề** cho trục danh mục.
   1. Đặt **vị trí nhãn** cho trục danh mục.
   1. Đặt **góc quay** cho nhãn trục danh mục.
1. Truy cập chú giải biểu đồ và đặt **thuộc tính văn bản** cho nó.
1. Hiển thị chú giải biểu đồ mà không giao nhau với biểu đồ.
1. Truy cập **trục giá trị phụ** của biểu đồ và thiết lập các mục sau:
   1. Bật **trục giá trị phụ**.
   1. Đặt **định dạng đường** cho trục giá trị phụ.
   1. Đặt **định dạng số** cho trục giá trị phụ.
   1. Đặt **đơn vị min, max, chính và phụ** cho trục giá trị phụ.
1. Vẽ chuỗi biểu đồ đầu tiên trên trục giá trị phụ.
1. Đặt màu nền tường phía sau của biểu đồ.
1. Đặt màu nền khu vực vẽ của biểu đồ.
1. Ghi bản thuyết trình đã chỉnh sửa thành tệp PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Tạo một thể hiện của lớp Presentation.
with slides.Presentation() as presentation:

    # Truy cập slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm một biểu đồ mẫu.
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # Đặt tiêu đề biểu đồ.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # Đặt định dạng đường lưới chính cho trục giá trị.
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # Đặt định dạng đường lưới phụ cho trục giá trị.
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # Đặt định dạng số cho trục giá trị.
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # Đặt giá trị tối đa, tối thiểu, đơn vị chính và đơn vị phụ cho trục giá trị.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # Đặt thuộc tính văn bản cho trục giá trị.
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # Đặt tiêu đề cho trục giá trị.
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # Đặt định dạng đường lưới chính cho trục danh mục.
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # Đặt định dạng đường lưới phụ cho trục danh mục.
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # Đặt thuộc tính văn bản cho trục danh mục.
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # Đặt tiêu đề cho trục danh mục.
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # Đặt vị trí nhãn cho trục danh mục.
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # Đặt góc quay của nhãn trục danh mục.
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # Đặt thuộc tính văn bản cho chú giải.
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # Hiển thị chú giải biểu đồ chồng lên biểu đồ.
    chart.legend.overlay = True
                
    # Đặt màu tường phía sau của biểu đồ.
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # Đặt màu khu vực vẽ.
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # Lưu bản thuyết trình.
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt thuộc tính phông chữ cho biểu đồ**

Aspose.Slides cho Python hỗ trợ thiết lập các thuộc tính liên quan đến phông chữ cho biểu đồ. Thực hiện các bước dưới đây để cấu hình thuộc tính phông chữ cho biểu đồ:

1. Khởi tạo một đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Thêm một biểu đồ vào slide.
1. Đặt chiều cao phông chữ.
1. Lưu bản thuyết trình đã chỉnh sửa.

Mã mẫu được cung cấp dưới đây.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt định dạng số**

Aspose.Slides cho Python cung cấp một API đơn giản để quản lý các định dạng dữ liệu biểu đồ:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới slide theo chỉ mục của nó.
1. Thêm một biểu đồ với dữ liệu mặc định của bất kỳ loại nào mong muốn.
1. Đặt một định dạng số có sẵn từ các giá trị định dạng trước có sẵn.
1. Duyệt các ô dữ liệu biểu đồ trong mỗi chuỗi và đặt định dạng số.
1. Lưu bản thuyết trình.
1. Đặt một định dạng số tùy chỉnh.
1. Duyệt các ô dữ liệu biểu đồ trong mỗi chuỗi và đặt một định dạng số khác.
1. Lưu bản thuyết trình.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation.
with slides.Presentation() as presentation:
    # Truy cập slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm một biểu đồ cột cụm mặc định.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Đặt định dạng số có sẵn.
    # Duyệt qua mỗi chuỗi biểu đồ.
    for series in chart.chart_data.series:
        # Duyệt qua mỗi điểm dữ liệu trong chuỗi.
        for cell in series.data_points:
            # Đặt định dạng số.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # Lưu bản thuyết trình.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

Các định dạng số có sẵn và chỉ mục tương ứng của chúng được liệt kê dưới đây.

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Đặt viền bo tròn cho khu vực biểu đồ**

Aspose.Slides cho Python hỗ trợ cấu hình khu vực biểu đồ bằng thuộc tính `Chart.has_rounded_corners`.

1. Khởi tạo một đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Thêm một biểu đồ vào slide.
3. Đặt loại tô và màu tô cho biểu đồ.
4. Đặt thuộc tính bo tròn thành `True`.
5. Lưu bản thuyết trình đã chỉnh sửa.

Mẫu được cung cấp dưới đây.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt màu nền bán trong suốt cho cột/khu vực trong khi giữ viền không trong suốt không?**

Có. Độ trong suốt của màu nền và đường viền được cấu hình riêng biệt. Điều này hữu ích để cải thiện khả năng đọc của lưới và dữ liệu trong các biểu đồ dày đặc.

**Làm thế nào tôi có thể xử lý các nhãn dữ liệu khi chúng chồng lên nhau?**

Giảm kích thước phông chữ, tắt các thành phần nhãn không cần thiết (ví dụ, danh mục), đặt độ dịch/ vị trí nhãn, chỉ hiển thị nhãn cho các điểm đã chọn nếu cần, hoặc chuyển định dạng sang "giá trị + chú giải".

**Tôi có thể áp dụng màu nền gradient hoặc họa tiết cho chuỗi không?**

Có. Cả màu nền đặc và gradient/họa tiết thường đều có sẵn. Trong thực tế, nên sử dụng gradient một cách có chọn lọc và tránh các kết hợp làm giảm độ tương phản với lưới và văn bản.