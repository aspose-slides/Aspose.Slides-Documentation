---
title: Tùy chỉnh biểu đồ bánh tròn trong bản trình chiếu bằng Java
linktitle: Biểu đồ bánh tròn
type: docs
weight: 30
url: /vi/java/doughnut-chart/
keywords:
- biểu đồ bánh tròn
- khoảng trống trung tâm
- kích thước lỗ
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Khám phá cách tạo và tùy chỉnh biểu đồ bánh tròn trong Aspose.Slides cho Java, hỗ trợ định dạng PowerPoint cho các bản trình chiếu động."
---
## **Tổng quan**

Bài viết này trình bày cách làm việc với biểu đồ bánh tròn (doughnut) trong Aspose.Slides bằng cách thêm biểu đồ vào slide, đặt kích thước lỗ ở trung tâm và lưu bản trình chiếu. Nội dung tập trung vào phương thức `setDoughnutHoleSize` và minh họa các bước cơ bản cần thiết để tùy chỉnh loại biểu đồ này bằng mã.

Bài viết cũng bao gồm một phần FAQ ngắn về các kịch bản liên quan đến biểu đồ bánh tròn, chẳng hạn như sử dụng nhiều series để tạo nhiều vòng, làm việc với biểu đồ bánh tròn “exploded”, và xuất biểu đồ dưới dạng ảnh raster hoặc SVG.

## **Xác định khoảng trống trung tâm trong biểu đồ bánh tròn**
{{% alert color="primary" %}} 

Aspose.Slides for Java hiện hỗ trợ việc chỉ định kích thước lỗ trong biểu đồ bánh tròn. Trong chủ đề này, chúng ta sẽ xem ví dụ cách chỉ định kích thước lỗ trong biểu đồ bánh tròn.

{{% /alert %}} 

Để chỉ định kích thước lỗ trong biểu đồ bánh tròn, vui lòng thực hiện các bước sau:

1. Khởi tạo đối tượng [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation).
1. Thêm biểu đồ bánh tròn vào slide.
1. Xác định kích thước lỗ trong biểu đồ bánh tròn.
1. Ghi bản trình chiếu ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã đặt kích thước lỗ trong biểu đồ bánh tròn.

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

## **FAQ**

**Tôi có thể tạo bánh tròn đa cấp với nhiều vòng không?**

Có. Thêm nhiều series vào một biểu đồ bánh tròn — mỗi series sẽ trở thành một vòng riêng. Thứ tự các vòng được xác định bởi thứ tự của các series trong bộ sưu tập.

**Biểu đồ bánh tròn “exploded” (các lát riêng biệt) có được hỗ trợ không?**

Có. Có loại biểu đồ Exploded Doughnut [chart type](https://reference.aspose.com/slides/vi/java/com.aspose.slides/charttype/) và thuộc tính explosion trên các điểm dữ liệu; bạn có thể tách các lát riêng lẻ.

**Làm sao để lấy ảnh của biểu đồ bánh tròn (PNG/SVG) cho báo cáo?**

Biểu đồ là một shape; bạn có thể render nó thành một [raster image](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#getImage-int-float-float-) hoặc xuất biểu đồ ra một [SVG image](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).