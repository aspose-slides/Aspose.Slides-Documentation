---
title: Tùy chỉnh bảng dữ liệu biểu đồ trong bản trình chiếu bằng Python
linktitle: Bảng dữ liệu
type: docs
url: /vi/python-net/chart-data-table/
keywords:
- dữ liệu biểu đồ
- bảng dữ liệu
- thuộc tính phông chữ
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tùy chỉnh phông chữ, viền và các mục chú giải của bảng dữ liệu biểu đồ trong bản trình chiếu PowerPoint bằng Aspose.Slides cho Python qua .NET."
---
## **Tổng quan**

Aspose.Slides for Python via .NET cho phép bạn hiển thị bảng dữ liệu của biểu đồ và tùy chỉnh định dạng văn bản, viền và các mục chú giải. Bài viết này giải thích cách bật bảng, định dạng văn bản, kiểm soát từng loại viền và hiển thị hoặc ẩn các mục chú giải. Các ví dụ lưu các biểu đồ đã cấu hình vào tệp PPTX.

## **Đặt Thuộc tính Phông chữ**

Để hiển thị bảng dữ liệu của biểu đồ, đặt [has_data_table](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/has_data_table/) thành `True`. Sử dụng [chart_data_table](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/chart_data_table/) để truy cập bảng và cấu hình định dạng văn bản của nó.

1. Tải bài thuyết trình bằng lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Thêm một biểu đồ cột nhóm vào slide đầu tiên.
1. Bật bảng dữ liệu của biểu đồ.
1. Bật chữ đậm với [font_bold](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseportionformat/font_bold/) và đặt [font_height](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseportionformat/font_height/) thành `20` để có văn bản 20 điểm.
1. Lưu bài thuyết trình đã chỉnh sửa.

Ví dụ sau yêu cầu tệp `test.pptx` trong thư mục làm việc với ít nhất một slide. Nó thêm một biểu đồ với dữ liệu mặc định tại vị trí (50, 50), với chiều rộng 600 điểm và chiều cao 400 điểm. Tệp `output.pptx` đã lưu chứa biểu đồ với bảng dữ liệu được bật và các cài đặt phông chữ đã áp dụng.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    portion_format = chart.chart_data_table.text_format.portion_format
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Tùy chỉnh Viền Bảng Dữ liệu**

Bật bảng bằng [Chart.has_data_table](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/has_data_table/) và truy cập nó qua [Chart.chart_data_table](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/chart_data_table/). Bạn có thể kiểm soát ba loại viền độc lập:

- [has_border_horizontal](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/datatable/has_border_horizontal/) kiểm soát viền ô ngang.
- [has_border_vertical](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/datatable/has_border_vertical/) kiểm soát viền ô dọc.
- [has_border_outline](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/datatable/has_border_outline/) kiểm soát viền bao ngoài của bảng.

Đặt mỗi thuộc tính thành `True` để hiển thị viền hoặc `False` để ẩn chúng. Ví dụ dưới tạo một biểu đồ cột nhóm với dữ liệu mặc định, hiển thị viền ngang và viền bao ngoài, và ẩn viền dọc. Nó không yêu cầu tệp đầu vào. Vị trí và kích thước của biểu đồ được chỉ định bằng điểm.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = False
    data_table.has_border_outline = True

    presentation.save("data-table-borders.pptx", slides.export.SaveFormat.PPTX)
```

So sánh dưới đây sử dụng cùng dữ liệu biểu đồ và cài đặt mục chú giải trong bốn trường hợp. Bắt đầu với tất cả viền được bật, mỗi biến thể còn lại chỉ tắt một thuộc tính viền. Biến thể góc dưới trái khớp với cài đặt viền trong ví dụ.

![Bảng dữ liệu biểu đồ với tất cả viền bật, không có viền ngang, không có viền dọc và không có viền bao ngoài](data-table-borders.png)

## **Hiển thị hoặc Ẩn Các mục Chú giải**

Các mục chú giải là các dấu màu nhỏ bên cạnh tên chuỗi trong bảng dữ liệu. Chúng giúp người đọc khớp mỗi hàng bảng với một chuỗi biểu đồ. Đặt [show_legend_key](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/datatable/show_legend_key/) thành `True` để hiển thị các dấu này hoặc `False` để ẩn chúng.

Chú giải riêng của biểu đồ được điều khiển bởi [Chart.has_legend](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/has_legend/). Các cài đặt này độc lập: ẩn chú giải riêng không ẩn các mục trong bảng dữ liệu, và ẩn các mục trong bảng không ẩn chú giải riêng.

Ví dụ sau tạo một biểu đồ với dữ liệu mặc định, bật bảng dữ liệu, và hiển thị các mục chú giải bên trong trong khi ẩn chú giải riêng. Tất cả các viền bảng được bật rõ ràng. Không cần tệp bài thuyết trình đầu vào. Để chỉ ẩn các mục trong bảng, đổi `data_table.show_legend_key` thành `False`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True
    chart.has_legend = False

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = True
    data_table.has_border_outline = True
    data_table.show_legend_key = True

    presentation.save("data-table-legend-keys.pptx", slides.export.SaveFormat.PPTX)
```

So sánh dưới đây hiển thị cùng một bảng với các mục chú giải được bật và tắt. Tất cả viền vẫn được bật, và chú giải riêng của biểu đồ được ẩn trong cả hai trường hợp.

![Bảng dữ liệu biểu đồ với các mục chú giải hiển thị ở bên trái và ẩn ở bên phải](data-table-legend-keys.png)

## **Câu hỏi thường gặp**

**Tôi có thể hiển thị các mục chú giải trong bảng dữ liệu của biểu đồ không?**

Có. Đặt [show_legend_key](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/datatable/show_legend_key/) thành `True` để hiển thị các mục chú giải hoặc thành `False` để ẩn chúng.

**Bảng dữ liệu có được giữ lại khi xuất bài thuyết trình sang PDF, HTML hoặc hình ảnh không?**

Có. Aspose.Slides sẽ render biểu đồ và bảng dữ liệu đã hiển thị như một phần của slide khi xuất sang [PDF](/slides/vi/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/vi/python-net/convert-powerpoint-to-html/), hoặc [images](/slides/vi/python-net/convert-powerpoint-to-png/).

**Tôi có thể làm việc với bảng dữ liệu trong các biểu đồ được tải từ mẫu không?**

Có. Đối với biểu đồ được tải từ một bài thuyết trình hoặc mẫu hiện có, sử dụng [has_data_table](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/has_data_table/) để kiểm tra hoặc thay đổi việc hiển thị bảng dữ liệu.

**Làm thế nào tôi có thể tìm các biểu đồ có bật bảng dữ liệu?**

Duyệt qua các shape trên mỗi slide, xác định các biểu đồ và kiểm tra thuộc tính [has_data_table](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/has_data_table/) của chúng. Giá trị `True` cho biết bảng dữ liệu đã được bật.