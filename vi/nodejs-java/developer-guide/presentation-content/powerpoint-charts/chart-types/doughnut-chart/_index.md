---
title: Tùy chỉnh biểu đồ Donut trong bài thuyết trình bằng JavaScript
linktitle: Biểu đồ Donut
type: docs
weight: 30
url: /vi/nodejs-java/doughnut-chart/
keywords:
- biểu đồ donut
- khoảng trống ở trung tâm
- kích thước lỗ
- PowerPoint
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Khám phá cách tạo và tùy chỉnh biểu đồ donut bằng JavaScript và Aspose.Slides cho Node.js, hỗ trợ định dạng PowerPoint cho các bài thuyết trình động."
---
## **Overview**

Bài viết này giới thiệu cách làm việc với biểu đồ donut trong Aspose.Slides bằng cách thêm biểu đồ vào một slide, đặt kích thước lỗ ở trung tâm và lưu bản trình bày. Nó tập trung vào phương thức `setDoughnutHoleSize` và trình bày các bước cơ bản cần thực hiện để tùy chỉnh loại biểu đồ này trong mã.

Nó cũng bao gồm một phần FAQ ngắn về các kịch bản liên quan đến biểu đồ donut, chẳng hạn như sử dụng nhiều series để tạo nhiều vòng, làm việc với biểu đồ donut nổ (exploded), và xuất biểu đồ dưới dạng ảnh raster hoặc SVG.

## **Change Center Gap in Doughnut Chart**

Để chỉ định kích thước lỗ trong biểu đồ donut, vui lòng thực hiện các bước sau:

1. Khởi tạo đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
1. Thêm biểu đồ donut vào slide.
1. Chỉ định kích thước lỗ trong biểu đồ donut.
1. Ghi bản trình bày ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã đặt kích thước lỗ trong biểu đồ donut.

```javascript
// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Doughnut, 50, 50, 400, 400);
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(90);
    // Ghi bài thuyết trình ra đĩa
    pres.save("DoughnutHoleSize_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Can I create a multi-level doughnut with multiple rings?**

Có. Thêm nhiều series vào một biểu đồ donut duy nhất — mỗi series sẽ trở thành một vòng riêng. Thứ tự các vòng được xác định bởi thứ tự của các series trong bộ sưu tập.

**Is an "exploded" doughnut (separated slices) supported?**

Có. Có loại biểu đồ Exploded Doughnut và thuộc tính explosion trên các điểm dữ liệu; bạn có thể tách các lát riêng lẻ.

**How can I get an image of a doughnut chart (PNG/SVG) for a report?**

Biểu đồ là một hình dạng; bạn có thể render nó thành một [raster image](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#getImage) hoặc xuất biểu đồ ra một [SVG image](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/writeassvg/).