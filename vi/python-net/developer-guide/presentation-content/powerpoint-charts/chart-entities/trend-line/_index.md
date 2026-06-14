---
title: Thêm Đường Xu Hướng vào Biểu Đồ Trình Chiếu trong Python
linktitle: Đường Xu Hướng
type: docs
url: /vi/python-net/trend-line/
keywords:
- biểu đồ
- đường xu hướng
- đường xu hướng exponential
- đường xu hướng tuyến tính
- đường xu hướng logarit
- đường xu hướng trung bình động
- đường xu hướng đa thức
- đường xu hướng lũy thừa
- đường xu hướng tùy chỉnh
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Nhanh chóng thêm và tùy chỉnh các đường xu hướng trong biểu đồ PowerPoint và OpenDocument bằng Aspose.Slides cho Python qua .NET — hướng dẫn thực tế và các ví dụ mã giúp cải thiện độ chính xác dự báo và thu hút khán giả của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách thêm các đường xu hướng vào biểu đồ trong bài thuyết trình bằng cách sử dụng Aspose.Slides. Nó cho thấy cách tạo một biểu đồ, thêm đường xu hướng cho các series của biểu đồ, và làm việc với nhiều loại đường xu hướng, bao gồm exponential, linear, logarithmic, moving average, polynomial và power.

Nó cũng mô tả cách thêm một đường tùy chỉnh vào biểu đồ bằng cách chèn một hình dạng đường thẳng, và bao gồm một phần FAQ ngắn về giá trị chiếu tiến và lùi của đường xu hướng cũng như việc các đường xu hướng có được giữ lại khi xuất ra PDF hoặc SVG và khi render biểu đồ dưới dạng hình ảnh hay không.

## **Thêm Đường Xu Hướng**
Aspose.Slides for Python via .NET cung cấp một API đơn giản để quản lý các Đường Xu Hướng khác nhau của biểu đồ:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Lấy tham chiếu của một slide bằng chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định cùng với bất kỳ loại nào mong muốn (ví dụ này sử dụng ChartType.CLUSTERED_COLUMN).
4. Thêm đường xu hướng exponential cho series 1 của biểu đồ.
5. Thêm đường xu hướng linear cho series 1 của biểu đồ.
6. Thêm đường xu hướng logarithmic cho series 2 của biểu đồ.
7. Thêm đường xu hướng moving average cho series 2 của biểu đồ.
8. Thêm đường xu hướng polynomial cho series 3 của biểu đồ.
9. Thêm đường xu hướng power cho series 3 của biểu đồ.
10. Ghi bản trình bày đã sửa đổi ra tệp PPTX.

Mã sau được sử dụng để tạo biểu đồ với các Đường xu hướng.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Tạo trình chiếu trống
with slides.Presentation() as pres:

    # Tạo biểu đồ cột nhóm
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # Thêm đường xu hướng exponential cho series 1 của biểu đồ
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # Thêm đường xu hướng tuyến tính cho series 1 của biểu đồ
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # Thêm đường xu hướng logarit cho series 2 của biểu đồ
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("New log trend line")

    # Thêm đường xu hướng trung bình động cho series 2 của biểu đồ
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "New TrendLine Name"

    # Thêm đường xu hướng đa thức cho series 3 của biểu đồ
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # Thêm đường xu hướng lũy thừa cho series 3 của biểu đồ
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # Lưu trình chiếu
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Thêm Đường Tùy Chỉnh**
Aspose.Slides for Python via .NET cung cấp một API đơn giản để thêm các đường tùy chỉnh vào biểu đồ. Để thêm một đường thẳng đơn giản vào một slide được chọn trong bản trình bày, vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp Presentation
- Lấy tham chiếu của một slide bằng cách sử dụng Index của nó
- Tạo một biểu đồ mới bằng phương thức AddChart được cung cấp bởi đối tượng Shapes
- Thêm một AutoShape loại Line bằng phương thức AddAutoShape được cung cấp bởi đối tượng Shapes
- Đặt Color cho các đường của shape.
- Ghi bản trình bày đã sửa đổi ra tệp PPTX

Mã sau được sử dụng để tạo biểu đồ với Đường Tùy chỉnh.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    shape = chart.user_shapes.shapes.add_auto_shape(slides.ShapeType.LINE, 0, chart.height / 2, chart.width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
    pres.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**'forward' và 'backward' có nghĩa là gì đối với một đường xu hướng?**

Chúng là độ dài của đường xu hướng được chiếu về phía trước/lùi lại: đối với biểu đồ scatter (XY) — tính bằng đơn vị trục; đối với các biểu đồ không phải scatter — tính bằng số lượng danh mục. Chỉ cho phép các giá trị không âm.

**Đường xu hướng có được giữ lại khi xuất bản trình bày sang PDF hoặc SVG, hoặc khi render một slide thành hình ảnh không?**

Có. Aspose.Slides chuyển đổi bản trình bày sang [PDF](/slides/vi/python-net/convert-powerpoint-to-pdf/)/[SVG](/slides/vi/python-net/render-a-slide-as-an-svg-image/) và render các biểu đồ thành hình ảnh; các đường xu hướng, như một phần của biểu đồ, được giữ lại trong các thao tác này. Một phương pháp cũng có sẵn để [export an image of the chart](/slides/vi/python-net/create-shape-thumbnails/) riêng.