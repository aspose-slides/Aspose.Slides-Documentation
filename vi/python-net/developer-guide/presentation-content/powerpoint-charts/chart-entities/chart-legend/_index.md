---
title: Tùy chỉnh chú giải biểu đồ trong bản trình bày bằng Python
linktitle: Chú giải biểu đồ
type: docs
url: /vi/python-net/chart-legend/
keywords:
- chú giải biểu đồ
- vị trí chú giải
- kích thước phông chữ
- PowerPoint
- bản trình bày
- Python
- Aspose.Slides
description: "Tùy chỉnh chú giải biểu đồ với Aspose.Slides cho Python qua .NET để tối ưu hóa các bản trình bày PowerPoint bằng định dạng chú giải được thiết kế riêng."
---
## **Tổng quan**

Aspose.Slides for Python via .NET cung cấp các tùy chọn để tùy chỉnh chú giải biểu đồ trong các bản trình bày PowerPoint. Bài viết này trình bày cách đặt vị trí và kích thước của chú giải, thiết lập kích thước phông chữ cho toàn bộ chú giải, định dạng một mục chú giải riêng lẻ, và ẩn hoặc khôi phục các mục đã chọn.

FAQ bao gồm các hành vi liên quan, bao gồm việc dành không gian cho chú giải, hiển thị nhãn đa dòng, và kế thừa định dạng từ chủ đề bản trình bày.

## **Định vị Chú giải**

Sử dụng các thuộc tính [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/x/), [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/y/), [width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/width/) và [height](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/height/) của chú giải để chỉ định vị trí và kích thước của nó dưới dạng phần thập phân của kích thước biểu đồ.

Ví dụ này tạo một bản trình bày và thêm một biểu đồ cột nhóm với dữ liệu mặc định vào slide đầu tiên. Việc chia các khoảng cách và kích thước chú giải mong muốn cho chiều rộng và chiều cao của biểu đồ sẽ chuyển chúng thành các giá trị tương đối: chú giải được dịch chuyển 50 điểm so với góc trên‑trái của biểu đồ và có kích thước 100 × 100 điểm.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # Diễn đạt vị trí và kích thước của chú giải so với biểu đồ.
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    presentation.save("legend_position.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt Kích thước Phông chữ cho Chú giải**

Sử dụng thuộc tính [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) của chú giải để truy cập định dạng văn bản và đặt [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) tính bằng điểm.

Ví dụ này tạo một biểu đồ với dữ liệu mặc định và đặt văn bản chú giải thành 20 điểm. Nó cũng tắt việc tự động đặt giới hạn cho trục dọc và đặt phạm vi của trục từ -5 tới 10.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.legend.text_format.portion_format.font_height = 20
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = -5
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 10

    presentation.save("legend_font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt Kích thước Phông chữ cho Mục Chú giải Cá Nhân**

Sử dụng bộ sưu tập [entries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/entries/) của chú giải để truy cập định dạng cho một mục cụ thể. Các chỉ mục mục bắt đầu từ 0, vì vậy chỉ mục `1` đề cập tới mục thứ hai.

Ví dụ này tạo một biểu đồ cột nhóm mà dữ liệu mặc định bao gồm ít nhất hai chuỗi. Nó định dạng mục chú giải thứ hai với chữ in đậm, in nghiêng và màu xanh 20‑point.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    text_format = chart.legend.entries[1].text_format
    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Ẩn Các Mục Chú giải Cá Nhân**

Để loại bỏ một chuỗi phụ trợ khỏi chú giải trong khi vẫn hiển thị dữ liệu của nó, đặt [ILegendEntryProperties.hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) thành `True` thông qua [IChartSeries.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/related_legend_entry/). Điều này chỉ ẩn mục chú giải đã chọn; nó không xóa chuỗi hay các điểm dữ liệu. Ngược lại, đặt [IChart.has_legend](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichart/has_legend/) thành `False` sẽ ẩn toàn bộ chú giải.

Ví dụ dưới tạo một biểu đồ cột nhóm với nhiều chuỗi sử dụng dữ liệu mặc định. Nó ẩn mục chú giải của chuỗi thứ hai (chỉ mục `1`) và lưu bản trình bày. Sau đó khôi phục mục bằng cách đặt [hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) thành `False` và lưu một bản sao thứ hai. Các cột vẫn hiển thị trong cả hai tệp.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = True

    legend_entry = chart.chart_data.series[1].related_legend_entry
    legend_entry.hide = True

    presentation.save("hidden_legend_entry.pptx", slides.export.SaveFormat.PPTX)

    # Khôi phục mục giống nhau mà không thay đổi dữ liệu biểu đồ.
    legend_entry.hide = False

    presentation.save("restored_legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

So sánh dưới đây cho thấy cùng một biểu đồ với tất cả các mục chú giải hiển thị và với mục thứ hai bị ẩn. Các cột của chuỗi thứ hai vẫn không thay đổi.

![So sánh biểu đồ với tất cả các mục chú giải hiển thị và với Series 2 bị ẩn khỏi chú giải; tất cả các cột vẫn hiển thị.](hide-legend-entry.png)

Trong các biểu đồ cột, thanh và đường, các mục chú giải xác định chuỗi. Đối với biểu đồ tròn, chúng xác định các điểm dữ liệu riêng lẻ (miếng bánh), vì vậy hãy sử dụng [IChartDataPoint.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/related_legend_entry/) trên miếng bánh đã chọn. API tài liệu thuộc tính này cho các loại biểu đồ `PIE`, `PIE3D`, `EXPLODED_PIE`, `EXPLODED_PIE3D`, `PIE_OF_PIE` và `BAR_OF_PIE`. Đừng cho rằng nó áp dụng cho biểu đồ vòng (doughnut), vì chúng không nằm trong danh sách đó.

## **FAQ**

**Tôi có thể yêu cầu biểu đồ dành không gian cho chú giải thay vì chồng lên nhau không?**

Có. Đặt [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) thành `False` để dành không gian cho chú giải thay vì cho phép nó chồng lên vùng vẽ.

**Tôi có thể tạo nhãn chú giải đa dòng không?**

Có. Các nhãn dài có thể tự động ngắt dòng khi chiều rộng khả dụng không đủ. Bạn cũng có thể chèn ký tự xuống dòng trong tên chuỗi để yêu cầu ngắt dòng.

**Làm sao để chú giải tuân theo bảng màu của chủ đề bản trình bày?**

Không đặt màu, màu nền và phông chữ của chú giải; để chúng kế thừa định dạng từ chủ đề. Định dạng rõ ràng sẽ ghi đè lên cài đặt của chủ đề.