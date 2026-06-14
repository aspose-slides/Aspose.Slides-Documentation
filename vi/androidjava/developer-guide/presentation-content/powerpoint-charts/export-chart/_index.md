---
title: "Xuất biểu đồ bản trình chiếu trên Android"
linktitle: "Xuất biểu đồ"
type: docs
weight: 90
url: /vi/androidjava/export-chart/
keywords:
- "biểu đồ"
- "biểu đồ thành hình ảnh"
- "biểu đồ dưới dạng hình ảnh"
- "trích xuất hình ảnh biểu đồ"
- "PowerPoint"
- "bản trình chiếu"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Tìm hiểu cách xuất biểu đồ bản trình chiếu với Aspose.Slides cho Android qua Java, hỗ trợ định dạng PPT và PPTX, và tối ưu hoá việc báo cáo vào bất kỳ quy trình làm việc nào."
---
## **Tổng quan**

Aspose.Slides cho phép bạn xuất biểu đồ từ bản trình chiếu dưới dạng hình ảnh. Bài viết này cho biết cách lấy hình ảnh từ biểu đồ và lưu lại, hữu ích khi bạn cần tái sử dụng hình ảnh biểu đồ bên ngoài bản PowerPoint.

Ngoài quy trình xuất ảnh cơ bản, bài viết còn giải đáp các câu hỏi thường gặp liên quan tới việc xuất, bao gồm lưu nội dung biểu đồ dưới dạng SVG, kiểm soát kích thước đầu ra thông qua các tùy chọn render, tải phông chữ để bảo toàn giao diện nhãn và chú giải, và duy trì định dạng gốc của bản trình chiếu như theme, style, fill và hiệu ứng trong quá trình render.

## **Lấy hình ảnh biểu đồ**
Aspose.Slides cho Android qua Java hỗ trợ trích xuất hình ảnh của biểu đồ cụ thể. Dưới đây là ví dụ mẫu.  

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("image.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể xuất biểu đồ dưới dạng vector (SVG) thay vì ảnh raster không?**

Có. Biểu đồ là một shape, và nội dung của nó có thể được lưu dưới dạng SVG bằng cách sử dụng [phương thức lưu dạng shape-to-SVG](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**Làm sao để đặt kích thước chính xác của biểu đồ đã xuất tính bằng pixel?**

Sử dụng các overload render ảnh cho phép bạn chỉ định kích thước hoặc tỷ lệ — thư viện hỗ trợ render các đối tượng với kích thước/tỷ lệ được cung cấp.

**Tôi nên làm gì nếu phông chữ trong nhãn và chú giải bị sai sau khi xuất?**

[Tải các phông chữ cần thiết](/slides/vi/androidjava/custom-font/) qua [FontsLoader](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsloader/) để việc render biểu đồ giữ đúng các chỉ số và giao diện văn bản.

**Quá trình xuất có tôn trọng theme, style và hiệu ứng của PowerPoint không?**

Có. Bộ render của Aspose.Slides tuân theo định dạng của bản trình chiếu (theme, style, fill, hiệu ứng), do đó giao diện của biểu đồ được giữ nguyên.

**Tôi có thể tìm các khả năng render/xuất khác ngoài hình ảnh biểu đồ ở đâu?**

Xem [API](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/)/[tài liệu](/slides/vi/androidjava/convert-powerpoint/) cho các mục tiêu xuất ([PDF](/slides/vi/androidjava/convert-powerpoint-to-pdf/), [SVG](/slides/vi/androidjava/render-a-slide-as-an-svg-image/), [XPS](/slides/vi/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/vi/androidjava/convert-powerpoint-to-html/)) và các tùy chọn render liên quan.