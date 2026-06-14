---
title: Tùy chỉnh chú giải biểu đồ trong bài thuyết trình bằng Python
linktitle: Chú giải biểu đồ
type: docs
url: /vi/python-net/chart-legend/
keywords:
- chú giải biểu đồ
- vị trí chú giải
- kích thước phông chữ
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tùy chỉnh chú giải biểu đồ với Aspose.Slides cho Python thông qua .NET để tối ưu hoá các bài thuyết trình PowerPoint và OpenDocument với định dạng chú giải được điều chỉnh theo yêu cầu."
---
## **Tổng quan**

Aspose.Slides for Python cung cấp khả năng kiểm soát hoàn toàn chú giải biểu đồ, cho phép bạn làm cho nhãn dữ liệu rõ ràng và sẵn sàng cho bài thuyết trình. Bạn có thể hiển thị hoặc ẩn chú giải, chọn vị trí của nó trên slide, và điều chỉnh bố cục để tránh chồng lấn với vùng vẽ. API cho phép bạn định dạng văn bản và dấu hiệu, tinh chỉnh khoảng đệm và nền, cũng như định dạng viền và màu nền để phù hợp với giao diện của bạn. Các nhà phát triển cũng có thể truy cập các mục chú giải riêng lẻ để đổi tên hoặc lọc chúng, đảm bảo chỉ những series quan trọng nhất được hiển thị. Với những khả năng này, biểu đồ của bạn luôn dễ đọc, nhất quán và phù hợp với tiêu chuẩn thiết kế của bài thuyết trình.

## **Vị trí chú giải**

Sử dụng Aspose.Slides, bạn có thể nhanh chóng kiểm soát nơi chú giải biểu đồ xuất hiện và cách nó khớp với bố cục slide. Tìm hiểu cách đặt chú giải một cách chính xác.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới slide.
1. Thêm một biểu đồ vào slide.
1. Đặt các thuộc tính của chú giải.
1. Lưu bài thuyết trình dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng ta thiết lập vị trí và kích thước của chú giải biểu đồ:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation.
with slides.Presentation() as presentation:

    # Lấy tham chiếu tới slide.
    slide = presentation.slides[0]

    # Thêm một biểu đồ cột nhóm vào slide.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # Đặt các thuộc tính của chú giải.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # Lưu bài thuyết trình vào đĩa.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt kích thước phông chữ cho chú giải**

Chú giải của biểu đồ cần đọc được như dữ liệu mà nó giải thích. Phần này trình bày cách điều chỉnh kích thước phông chữ của chú giải để bạn có thể phù hợp với kiểu chữ của bài thuyết trình và cải thiện khả năng truy cập.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Tạo một biểu đồ.
1. Đặt kích thước phông chữ.
1. Lưu bài thuyết trình vào đĩa.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt kích thước phông chữ cho một mục chú giải**

Aspose.Slides cho phép bạn tinh chỉnh giao diện của chú giải biểu đồ bằng cách định dạng các mục riêng lẻ. Ví dụ dưới đây cho thấy cách chọn một mục chú giải cụ thể và thiết lập các thuộc tính của nó mà không làm thay đổi phần còn lại của chú giải.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Tạo một biểu đồ.
1. Truy cập một mục chú giải.
1. Đặt các thuộc tính cho mục.
1. Lưu bài thuyết trình vào đĩa.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
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

    presentation.save("legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Tôi có thể bật chú giải sao cho biểu đồ tự động dành không gian cho nó thay vì phủ lên không?**

Có. Sử dụng chế độ không phủ (`overlay` = `false`); trong trường hợp này, vùng vẽ sẽ thu nhỏ để chứa chú giải.

**Tôi có thể tạo nhãn chú giải đa dòng không?**

Có. Nhãn dài sẽ tự động xuống dòng khi không đủ không gian; các ngắt dòng bắt buộc được hỗ trợ thông qua ký tự xuống dòng trong tên series.

**Làm sao để chú giải tuân theo bảng màu của chủ đề bài thuyết trình?**

Không đặt màu sắc/bảo nền/phông chữ cụ thể cho chú giải hoặc văn bản của nó. Khi đó chúng sẽ kế thừa từ chủ đề và cập nhật đúng khi thiết kế thay đổi.