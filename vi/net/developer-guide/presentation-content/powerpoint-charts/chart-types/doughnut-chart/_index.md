---
title: Tùy chỉnh biểu đồ bánh rán trong bản trình chiếu bằng .NET
linktitle: Biểu đồ bánh rán
type: docs
weight: 30
url: /vi/net/doughnut-chart/
keywords:
- biểu đồ bánh rán
- khoảng trống trung tâm
- kích thước lỗ
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Khám phá cách tạo và tùy chỉnh biểu đồ bánh rán trong Aspose.Slides cho .NET, hỗ trợ định dạng PowerPoint cho các bản trình chiếu động."
---
## **Tổng quan**

Bài viết này trình bày cách làm việc với biểu đồ bánh rán trong Aspose.Slides bằng cách thêm biểu đồ vào slide, thiết lập kích thước lỗ ở trung tâm và lưu bản trình chiếu. Nội dung tập trung vào thiết lập `DoughnutHoleSize` và minh họa các bước cơ bản cần thiết để tùy chỉnh loại biểu đồ này bằng code.

Nó cũng bao gồm một phần FAQ ngắn về các kịch bản liên quan đến biểu đồ bánh rán, chẳng hạn như sử dụng nhiều series để tạo nhiều vòng, làm việc với biểu đồ bánh rán “exploded”, và xuất biểu đồ dưới dạng ảnh raster hoặc SVG.

## **Xác định khoảng trống trung tâm trong biểu đồ bánh rán**
Để chỉ định kích thước lỗ trong biểu đồ bánh rán, hãy làm theo các bước sau:

- Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
- Thêm biểu đồ bánh rán vào slide.
- Xác định kích thước lỗ trong biểu đồ bánh rán.
- Ghi bản trình chiếu ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã đặt kích thước lỗ trong biểu đồ bánh rán.

```c#
// Tạo một thể hiện của lớp Presentation
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// Ghi bản trình chiếu ra đĩa
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Tôi có thể tạo một bánh rán đa cấp với nhiều vòng không?**

Có. Thêm nhiều series vào một biểu đồ bánh rán duy nhất — mỗi series sẽ trở thành một vòng riêng. Thứ tự các vòng được quyết định bởi thứ tự của các series trong collection.

**Có hỗ trợ bánh rán “exploded” (các lát tách ra) không?**

Có. Có loại biểu đồ Exploded Doughnut [chart type](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/charttype/) và thuộc tính explosion trên các điểm dữ liệu; bạn có thể tách các lát riêng lẻ.

**Làm sao tôi có thể lấy hình ảnh của biểu đồ bánh rán (PNG/SVG) cho báo cáo?**

Biểu đồ là một shape; bạn có thể render nó thành một [raster image](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/getimage/) hoặc xuất biểu đồ ra một [SVG image](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/writeassvg/).