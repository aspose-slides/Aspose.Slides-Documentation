---
title: Tùy chỉnh biểu đồ bánh donut trong bản trình chiếu trên Android
linktitle: Biểu đồ bánh donut
type: docs
weight: 30
url: /vi/androidjava/doughnut-chart/
keywords:
- biểu đồ bánh donut
- khoảng trống trung tâm
- kích thước lỗ
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Khám phá cách tạo và tùy chỉnh biểu đồ bánh donut trong Aspose.Slides cho Android qua Java, hỗ trợ định dạng PowerPoint cho các bản trình chiếu động."
---
## **Tổng quan**

Bài viết này hướng dẫn cách làm việc với biểu đồ bánh donut trong Aspose.Slides bằng cách thêm biểu đồ vào một slide, thiết lập kích thước lỗ ở trung tâm và lưu bản trình chiếu. Nội dung tập trung vào phương thức `setDoughnutHoleSize` và trình bày các bước cơ bản cần thiết để tùy chỉnh loại biểu đồ này bằng mã.

Nó cũng bao gồm một phần Hỏi‑đáp ngắn liên quan đến các kịch bản biểu đồ bánh donut, chẳng hạn như sử dụng nhiều series để tạo nhiều vòng, làm việc với biểu đồ bánh donut nổ (exploded) và xuất biểu đồ dưới dạng ảnh raster hoặc SVG.

## **Xác định khoảng trống trung tâm trong biểu đồ bánh donut**
{{% alert color="info" %}} 

Aspose.Slides for Android via Java hiện hỗ trợ việc chỉ định kích thước lỗ trong biểu đồ bánh donut. Trong phần này, chúng ta sẽ xem ví dụ cách chỉ định kích thước lỗ trong biểu đồ bánh donut.

{{% /alert %}} 

Để chỉ định kích thước lỗ trong biểu đồ bánh donut, vui lòng thực hiện các bước sau:

1. Khởi tạo đối tượng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
1. Thêm biểu đồ bánh donut vào slide.
1. Xác định kích thước lỗ trong biểu đồ bánh donut.
1. Ghi bản trình chiếu ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã thiết lập kích thước lỗ trong biểu đồ bánh donut.

```java
import com.aspose.slides.*;

// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Ghi bản trình chiếu ra đĩa
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hỏi‑đáp**

### Tôi có thể tạo bánh donut đa cấp với nhiều vòng không?

Có. Thêm nhiều series vào một biểu đồ bánh donut—mỗi series sẽ thành một vòng riêng. Thứ tự các vòng được xác định bởi thứ tự của các series trong collection.

### Có hỗ trợ bánh donut “nổ” (các lát tách rời) không?

Có. Có loại biểu đồ [Exploded Doughnut](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/charttype/) và thuộc tính explosion trên các data point; bạn có thể tách các lát riêng lẻ.

### Làm sao để lấy ảnh của biểu đồ bánh donut (PNG/SVG) cho báo cáo?

Biểu đồ là một shape; bạn có thể render nó thành một [raster image](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) hoặc xuất biểu đồ ra một [SVG image](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).