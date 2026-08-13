---
title: Tùy chỉnh biểu đồ vòng bánh trong bài thuyết trình bằng Java
linktitle: Biểu đồ vòng bánh
type: docs
weight: 30
url: /vi/java/doughnut-chart/
keywords:
- doughnut chart
- center gap
- hole size
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Khám phá cách tạo và tùy chỉnh biểu đồ vòng bánh trong Aspose.Slides cho Java, hỗ trợ định dạng PowerPoint cho các bài thuyết trình động."
---
## **Tổng quan**

Bài viết này trình bày cách làm việc với biểu đồ vòng bánh trong Aspose.Slides bằng cách thêm biểu đồ vào một slide, thiết lập kích thước lỗ ở trung tâm, và lưu bài thuyết trình. Nó tập trung vào phương thức `setDoughnutHoleSize` và minh họa các bước cơ bản cần thiết để tùy chỉnh loại biểu đồ này trong mã.

Nó cũng bao gồm một phần Câu hỏi thường gặp ngắn gọn về các trường hợp liên quan đến biểu đồ vòng bánh, chẳng hạn như sử dụng nhiều series để tạo nhiều vòng, làm việc với biểu đồ vòng bánh nổ, và xuất biểu đồ dưới dạng ảnh raster hoặc SVG.

## **Xác định khoảng trống trung tâm trong biểu đồ vòng bánh**
{{% alert color="info" %}} 
Aspose.Slides for Java hiện hỗ trợ việc chỉ định kích thước lỗ trong biểu đồ vòng bánh. Trong chủ đề này, chúng ta sẽ xem qua ví dụ cách chỉ định kích thước lỗ trong biểu đồ vòng bánh.
{{% /alert %}} 

Để chỉ định kích thước lỗ trong biểu đồ vòng bánh, vui lòng làm theo các bước dưới đây:

1. Khởi tạo đối tượng [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation).
1. Thêm biểu đồ vòng bánh vào slide.
1. Chỉ định kích thước lỗ trong biểu đồ vòng bánh.
1. Ghi bài thuyết trình ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã thiết lập kích thước lỗ trong biểu đồ vòng bánh.

```java
import com.aspose.slides.*;

// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Ghi bài thuyết trình ra đĩa
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **CÂU HỎI THƯỜNG GẶP**

### Tôi có thể tạo một vòng bánh đa cấp với nhiều vòng không?

Có. Thêm nhiều series vào một biểu đồ vòng bánh—mỗi series sẽ trở thành một vòng riêng biệt. Thứ tự các vòng được xác định bởi thứ tự của các series trong collection.

### Biểu đồ vòng bánh "nổ" (các mảnh tách ra) có được hỗ trợ không?

Có. Có loại biểu đồ Exploded Doughnut [chart type](https://reference.aspose.com/slides/vi/java/com.aspose.slides/charttype/) và thuộc tính explosion trên các điểm dữ liệu; bạn có thể tách các mảnh riêng lẻ.

### Làm thế nào để lấy hình ảnh của biểu đồ vòng bánh (PNG/SVG) cho báo cáo?

Biểu đồ là một shape; bạn có thể render nó thành một [raster image](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#getImage-int-float-float-) hoặc xuất biểu đồ ra một [SVG image](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).