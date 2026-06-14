---
title: Tùy chỉnh biểu đồ vòng bánh trong bản trình chiếu trên Android
linktitle: Biểu đồ vòng bánh
type: docs
weight: 30
url: /vi/androidjava/doughnut-chart/
keywords:
- biểu đồ vòng bánh
- khoảng trống trung tâm
- kích thước lỗ
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Khám phá cách tạo và tùy chỉnh biểu đồ vòng bánh trong Aspose.Slides cho Android qua Java, hỗ trợ định dạng PowerPoint cho các bản trình chiếu động."
---
## **Tổng quan**

Bài viết này cho thấy cách làm việc với biểu đồ vòng bánh trong Aspose.Slides bằng cách thêm biểu đồ vào một slide, đặt kích thước lỗ ở giữa và lưu bài thuyết trình. Nó tập trung vào phương thức `setDoughnutHoleSize` và trình bày các bước cơ bản cần thiết để tùy chỉnh loại biểu đồ này trong mã.

Nó cũng bao gồm một phần Hỏi đáp ngắn về các kịch bản liên quan đến biểu đồ vòng bánh, chẳng hạn như sử dụng nhiều series để tạo nhiều vòng, làm việc với biểu đồ vòng bánh “nổ” và xuất biểu đồ dưới dạng hình ảnh raster hoặc SVG.

## **Xác định khoảng trống trung tâm trong biểu đồ vòng bánh**
{{% alert color="primary" %}} 
Aspose.Slides for Android qua Java hiện đã hỗ trợ việc chỉ định kích thước lỗ trong biểu đồ vòng bánh. Trong chủ đề này, chúng ta sẽ xem qua ví dụ cách chỉ định kích thước lỗ trong biểu đồ vòng bánh.
{{% /alert %}} 

Để chỉ định kích thước lỗ trong biểu đồ vòng bánh, vui lòng thực hiện các bước sau:

1. Khởi tạo đối tượng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation) .
1. Thêm biểu đồ vòng bánh vào slide.
1. Xác định kích thước lỗ trong biểu đồ vòng bánh.
1. Ghi bài thuyết trình ra đĩa.

Trong ví dụ bên dưới, chúng tôi đã đặt kích thước lỗ trong biểu đồ vòng bánh.

```java
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

## **Câu hỏi thường gặp**

**Tôi có thể tạo vòng bánh đa cấp với nhiều vòng không?**

Có. Thêm nhiều series vào một biểu đồ vòng bánh—mỗi series sẽ trở thành một vòng riêng. Thứ tự các vòng được xác định bởi thứ tự của các series trong bộ sưu tập.

**Có hỗ trợ vòng bánh "nổ" (các phần tách rời) không?**

Có. Có loại biểu đồ Exploded Doughnut [chart type](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/charttype/) và thuộc tính explosion trên các điểm dữ liệu; bạn có thể tách các phần riêng lẻ.

**Làm sao tôi có thể lấy hình ảnh của biểu đồ vòng bánh (PNG/SVG) cho báo cáo?**

Biểu đồ là một hình dạng; bạn có thể render nó thành một [raster image](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) hoặc xuất biểu đồ thành một [SVG image](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).