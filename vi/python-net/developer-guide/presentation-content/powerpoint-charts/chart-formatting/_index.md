---
title: Định dạng biểu đồ trong bản trình chiếu bằng Python
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
- viền tròn
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tìm hiểu cách định dạng biểu đồ trong Aspose.Slides cho Python thông qua .NET và nâng cao bản trình chiếu PowerPoint của bạn với các trục, phông chữ, định dạng số và viền biểu đồ tròn tùy chỉnh."
---
## **Tổng quan**

Bài viết này giải thích cách định dạng biểu đồ trong bản trình bày PowerPoint bằng cách sử dụng Aspose.Slides. Nó cho thấy cách tùy chỉnh các thành phần chính của biểu đồ như trục, đường lưới, tiêu đề, chú giải, khu vực vẽ và màu nền tường để cải thiện diện mạo và khả năng đọc dữ liệu biểu đồ.

Nó cũng trình bày cách đặt thuộc tính phông chữ cho văn bản biểu đồ, áp dụng định dạng số được đặt sẵn cho dữ liệu biểu đồ và bật các góc tròn cho khu vực biểu đồ. Cùng nhau, những ví dụ này cho thấy cách kiểm soát cả kiểu dáng trực quan và cách trình bày dữ liệu của biểu đồ trong bản trình bày.

Đối với việc tô màu và viền riêng biệt trên các khoảng tăng và giảm, xem [ví dụ biểu đồ chứng khoán](/slides/vi/python-net/create-chart/#create-stock-charts).

## **Định dạng các thực thể biểu đồ**

Sử dụng [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) để định dạng tiêu đề biểu đồ, trục, đường lưới, chú giải và khu vực vẽ. Ví dụ này tạo một biểu đồ đường có các điểm đánh dấu và dữ liệu mặc định, sau đó áp dụng các kiểu văn bản và đường riêng biệt cho trục giá trị và trục danh mục của nó. Kích thước phông chữ và độ rộng đường được chỉ định bằng điểm; nhãn danh mục được quay 45 độ.

Trục giá trị sử dụng [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) độc lập với các ô nguồn. Thang của nó chạy từ -2 đến 15, với khoảng chính là 2 và khoảng phụ là 0.5. Ví dụ cũng kết hợp định dạng phần trăm với [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) được đặt thành nghìn, vì vậy hãy điều chỉnh các cài đặt này phù hợp với ý nghĩa và độ lớn của dữ liệu của bạn. Chú giải vẫn nằm ngoài khu vực vẽ vì [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) bị tắt. Các màu nền tường sau và sàn được cấu hình thông qua [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) và [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/), nhưng các bề mặt này chỉ hiển thị trong biểu đồ 3D.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = slides.NullableBool.TRUE
    chart_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = slides.NullableBool.TRUE
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = slides.NullableBool.TRUE
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = slides.NullableBool.TRUE
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = slides.NullableBool.TRUE
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID
    legend_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_red

    chart.legend.overlay = False

    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = slides.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = slides.Color.red

    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = slides.Color.light_cyan

    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt thuộc tính phông chữ cho biểu đồ**

Đặt kích thước phông chữ mặc định cho văn bản biểu đồ thông qua [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/). Ví dụ tạo một biểu đồ cột nhóm với phông chữ 20 điểm và bật nhãn giá trị cho chuỗi đầu tiên thông qua [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). Các phần tử văn bản có cài đặt phông chữ riêng có thể ghi đè lên mặc định của biểu đồ.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **Tái sử dụng định dạng khung văn bản cho chú giải biểu đồ**

Để khớp chú giải với tiêu đề slide, đặt phông chữ thông qua [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) trên đoạn văn đầu tiên của tiêu đề. Gọi [copy_from](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_from/) trên [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) của chú giải. Nó sao chép các cài đặt khung văn bản, định dạng của đoạn văn đầu tiên và các thuộc tính phông chữ mặc định của đoạn văn đó. Định dạng được áp dụng trực tiếp cho các phần riêng lẻ hoặc cho các đoạn văn sau sẽ giữ lại cục bộ trong nguồn.

Ví dụ sử dụng một tiêu đề in đậm, màu xanh hải quân, phông chữ Calibri 26 điểm làm mẫu. Sau khi định dạng chú giải, nó sử dụng [copy_to](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_to/) để áp dụng cùng một định dạng cho một chú thích riêng.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    heading = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 640, 40, False)
    source_text_frame = heading.add_text_frame("Quarterly sales")
    font = source_text_frame.paragraphs[0].paragraph_format.default_portion_format
    font.latin_font = slides.FontData("Calibri")
    font.font_height = 26
    font.font_bold = slides.NullableBool.TRUE
    font.fill_format.fill_type = slides.FillType.SOLID
    font.fill_format.solid_fill_color.color = slides.Color.from_argb(32, 64, 96)

    chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 75, 640, 360)
    chart.style = charts.StyleType.STYLE3
    workbook = chart.chart_data.chart_data_workbook
    for column, name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.get_cell(0, 0, column).value = name
    for quarter in range(1, 5):
        workbook.get_cell(0, quarter, 0).value = f"Q{quarter}"

    chart.has_legend = True
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.copy_from(source_text_frame)

    caption = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 460, 640, 40, False)
    caption_text_frame = caption.add_text_frame("Sales in millions of dollars")
    chart.legend.text_format.copy_to(caption_text_frame)

    presentation.save("legend-formatting.pptx", slides.export.SaveFormat.PPTX)
```

Trong bản trình bày đã lưu, chú giải và chú thích khớp với tiêu đề về kích thước, độ đậm và màu sắc. Chú giải vẫn hiển thị tên chuỗi, và chú thích giữ lại văn bản riêng của nó. Nếu một phần trong chú thích đã có kích thước phông chữ rõ ràng, kích thước đó sẽ được ưu tiên hơn mặc định của đoạn đã sao chép.

| Trước khi sao chép | Sau khi sao chép |
| --- | --- |
| ![Biểu đồ doanh thu quý với nhãn chú giải đen thông thường và chú thích đen](legend-formatting-before.png) | ![Biểu đồ tương tự với nhãn chú giải màu xanh hải quân, lớn hơn, in đậm và chú thích phù hợp](legend-formatting.png) |

## **Đặt định dạng số**

Sử dụng [ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) để áp dụng định dạng số tích hợp sẵn cho các ô trong bảng tính biểu đồ. Ví dụ này tạo một biểu đồ cột nhóm với dữ liệu mặc định dựa trên ô và áp dụng chỉ số định dạng 10 (`0.00%`) cho mỗi ô giá trị chuỗi. Điều này thay đổi cách hiển thị các giá trị trong bảng tính mà không thay đổi số thực tế; ví dụ, 0.25 được hiển thị là 25.00%. Các định dạng trục và nhãn dữ liệu có thể được cấu hình riêng biệt.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    for series in chart.chart_data.series:
        for data_point in series.data_points:
            data_point.value.as_cell.preset_number_format = 10  # 0.00%

    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

Bảng sau liệt kê các chỉ số định dạng số tích hợp sẵn cùng với các định dạng Excel tiêu biểu cho bản địa Anh (Hoa Kỳ). Các chuỗi định dạng chính xác và cách hiển thị chúng có thể khác nhau tùy ứng dụng và bản địa, đặc biệt đối với tiền tệ và ngày tháng. Một số định dạng Excel cũng khác với mặc định trong tiêu chuẩn OOXML, như mô tả trong [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Chỉ số | Định dạng |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Đặt viền tròn cho khu vực biểu đồ**

Bật [Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) để làm tròn các góc của khu vực biểu đồ. Ví dụ tạo một biểu đồ cột nhóm và sử dụng [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) để đặt viền ngoài của nó thành màu xám đặc và kiểu một đường trước khi lưu bản trình bày.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.line_format.fill_format.fill_type = slides.FillType.SOLID
    chart.line_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart.line_format.style = slides.LineStyle.SINGLE
    chart.has_rounded_corners = True

    presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **Chỉnh sửa chú thích biểu đồ hiện có**

Một biểu đồ có thể chứa các hình dạng tùy chỉnh, chẳng hạn như chú thích văn bản giải thích trạng thái của báo cáo. Truy cập các hình dạng này qua [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/). Bộ sưu tập [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) của nó chứa các hình dạng thuộc về biểu đồ.

Một hộp văn bản thông thường đặt lên trên biểu đồ thuộc về slide, ngay cả khi trông giống như một phần của biểu đồ. Duyệt qua [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) sẽ tìm thấy biểu đồ và các hình dạng slide thông thường, nhưng không liệt kê các hình dạng riêng lẻ bên trong biểu đồ. Tiêu đề biểu đồ và nhãn dữ liệu là các thành phần biểu đồ riêng biệt, không phải là chú thích tùy chỉnh trong bộ sưu tập này.

Tải xuống [chart-annotations.pptx](chart-annotations.pptx) và đặt nó trong thư mục làm việc của ứng dụng. Slide đầu tiên chứa một biểu đồ với một chú thích không nhóm ghi "Preliminary results", một đường thuộc biểu đồ và một hộp văn bản slide thông thường ghi "Slide overlay". Ví dụ tìm biểu đồ đầu tiên trên slide đó và thay đổi chú thích thành "Final results" khi báo cáo đã sẵn sàng công bố. Nó kiểm tra bộ sưu tập rỗng và chỉ chỉnh sửa một [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) có [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) không phải `None` và chứa văn bản mong đợi.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-annotations.pptx") as presentation:
    slide = presentation.slides[0]
    chart = next((shape for shape in slide.shapes if isinstance(shape, charts.Chart)), None)

    if chart is None or len(chart.user_shapes.shapes) == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.user_shapes.shapes:
            if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
                if shape.text_frame.text == "Preliminary results":
                    shape.text_frame.text = "Final results"
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("No matching text annotation found.")
```

Đường và hộp văn bản slide vẫn không thay đổi. Các hình ảnh sau hiển thị đầu vào và kết quả đã lưu, mở lại:

| Trước khi chỉnh sửa | Sau khi chỉnh sửa |
| --- | --- |
| ![Chú thích biểu đồ ghi "Preliminary results"](chart-annotations-before.png) | ![Chú thích biểu đồ ghi "Final results"](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Ví dụ chỉ kiểm tra các hình dạng cấp cao nhất thuộc biểu đồ. Nếu một chú thích nằm bên trong [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), hãy kiểm tra bộ sưu tập [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) của nhóm đó nữa. Lặp lại quá trình này một cách đệ quy cho các nhóm lồng nhau, áp dụng các kiểm tra văn bản giống nhau cho các hình dạng con của chúng. Một nhóm tự nó là một container; không nên xem nó như một hộp văn bản.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Có thể đặt màu nền bán trong suốt cho cột/khu vực trong khi giữ viền không trong suốt không?**

Có. Độ trong suốt của màu nền và viền được cấu hình riêng biệt. Điều này hữu ích để cải thiện khả năng đọc của lưới và dữ liệu trong các biểu đồ dày đặc.

**Làm sao để xử lý nhãn dữ liệu khi chúng chồng lên nhau?**

Giảm kích thước phông chữ, tắt các thành phần nhãn không cần thiết (ví dụ, danh mục), điều chỉnh vị trí nhãn, chỉ hiển thị nhãn cho các điểm đã chọn nếu cần, hoặc chuyển định dạng thành "giá trị + chú giải".

**Có thể áp dụng màu nền gradient hoặc họa tiết cho các chuỗi không?**

Có. Các chuỗi hỗ trợ màu nền đặc, gradient và họa tiết. Trong thực tế, sử dụng gradient một cách hạn chế và tránh các kết hợp làm giảm độ tương phản với lưới và văn bản.