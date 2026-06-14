---
title: "Tùy chỉnh biểu đồ Doughnut trong bản trình bày bằng Python"
linktitle: "Biểu đồ Doughnut"
type: docs
weight: 30
url: /vi/python-net/doughnut-chart/
keywords:
- biểu đồ doughnut
- khoảng trống trung tâm
- kích thước lỗ
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Khám phá cách tạo và tùy chỉnh biểu đồ doughnut trong Aspose.Slides cho Python qua .NET, hỗ trợ các định dạng PowerPoint và OpenDocument cho các bản trình bày động."
---
## **Tổng quan**

Bài viết này trình bày cách làm việc với biểu đồ doughnut trong Aspose.Slides bằng cách thêm biểu đồ vào slide, thiết lập kích thước lỗ trung tâm và lưu bản trình bày. Nó tập trung vào cài đặt `doughnut_hole_size` và minh họa các bước cơ bản cần thiết để tùy chỉnh loại biểu đồ này trong mã.

Nó cũng bao gồm một phần Câu hỏi thường gặp ngắn gọn về các kịch bản liên quan đến biểu đồ doughnut, chẳng hạn như sử dụng nhiều series để tạo nhiều vòng, làm việc với biểu đồ doughnut bị nổ (exploded), và xuất biểu đồ dưới dạng ảnh raster hoặc SVG.

## **Xác định khoảng trống trung tâm trong biểu đồ Doughnut**
Để chỉ định kích thước lỗ trong biểu đồ doughnut, hãy làm theo các bước dưới đây:

- Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
- Thêm biểu đồ doughnut vào slide.
- Chỉ định kích thước lỗ trong biểu đồ doughnut.
- Ghi bản trình bày ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã thiết lập kích thước lỗ trong biểu đồ doughnut.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # Ghi bản trình bày ra đĩa
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Tôi có thể tạo một doughnut đa cấp với nhiều vòng không?**

Có. Thêm nhiều series vào một biểu đồ doughnut duy nhất — mỗi series sẽ trở thành một vòng riêng. Thứ tự các vòng được xác định bởi thứ tự của các series trong bộ sưu tập.

**Biểu đồ doughnut "exploded" (các phần cắt tách rời) có được hỗ trợ không?**

Có. Có loại biểu đồ Exploded Doughnut [chart type](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/charttype/) và thuộc tính explosion trên các điểm dữ liệu; bạn có thể tách các phần riêng lẻ.

**Làm thế nào để lấy hình ảnh của biểu đồ doughnut (PNG/SVG) cho báo cáo?**

Biểu đồ là một hình dạng; bạn có thể render nó thành [raster image](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/get_image/) hoặc xuất biểu đồ sang [SVG image](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/write_as_svg/).