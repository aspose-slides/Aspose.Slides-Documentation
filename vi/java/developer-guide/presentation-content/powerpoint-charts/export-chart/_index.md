---
title: Xuất biểu đồ trình chiếu trong Java
linktitle: Xuất biểu đồ
type: docs
weight: 90
url: /vi/java/export-chart/
keywords:
- biểu đồ
- biểu đồ thành hình ảnh
- biểu đồ dưới dạng hình ảnh
- trích xuất hình ảnh biểu đồ
- PowerPoint
- trình chiếu
- Java
- Aspose.Slides
description: "Tìm hiểu cách xuất biểu đồ trình chiếu bằng Aspose.Slides cho Java, hỗ trợ định dạng PPT và PPTX, và tối ưu hoá báo cáo vào bất kỳ quy trình làm việc nào."
---
## **Tổng quan**

Aspose.Slides cho phép bạn xuất biểu đồ từ một bài thuyết trình dưới dạng hình ảnh. Bài viết này mô tả cách lấy hình ảnh từ biểu đồ và lưu lại, hữu ích khi bạn cần tái sử dụng hình ảnh biểu đồ ngoài PowerPoint.

Ngoài quy trình xuất hình ảnh cơ bản, bài viết còn trả lời các câu hỏi thường gặp về xuất, bao gồm lưu nội dung biểu đồ thành SVG, điều chỉnh kích thước đầu ra qua các tùy chọn render, tải phông chữ để bảo lưu nhãn và chú giải, và giữ định dạng gốc của bản trình bày như giao diện, kiểu dáng, màu nền và hiệu ứng trong quá trình render.

## **Lấy hình ảnh biểu đồ**
Aspose.Slides for Java hỗ trợ trích xuất hình ảnh của biểu đồ cụ thể. Ví dụ mẫu dưới đây được cung cấp. 

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

## **FAQ**

**Tôi có thể xuất biểu đồ dưới dạng vector (SVG) thay vì ảnh raster không?**

Có. Biểu đồ là một shape, và nội dung của nó có thể được lưu thành SVG bằng [phương pháp lưu dưới dạng SVG](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**Làm sao để đặt kích thước chính xác cho biểu đồ đã xuất tính bằng pixel?**

Sử dụng các overload render hình ảnh cho phép chỉ định kích thước hoặc tỷ lệ—thư viện hỗ trợ render đối tượng với kích thước/tỷ lệ được cung cấp.

**Tôi nên làm gì nếu phông chữ trong nhãn và chú giải bị hiển thị sai sau khi xuất?**

[Tải các phông chữ cần thiết](/slides/vi/java/custom-font/) qua [FontsLoader](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsloader/) để quá trình render biểu đồ bảo lưu các chỉ số và hình thức văn bản.

**Quá trình xuất có tôn trọng giao diện, kiểu dáng và hiệu ứng của PowerPoint không?**

Có. Bộ render của Aspose.Slides tuân theo định dạng của bản trình bày (giao diện, kiểu dáng, màu nền, hiệu ứng), do đó hình thức của biểu đồ được giữ nguyên.

**Tôi có thể tìm thấy các khả năng render/​xuất nào khác ngoài hình ảnh biểu đồ ở đâu?**

Xem [API](https://reference.aspose.com/slides/vi/java/com.aspose.slides/)/[tài liệu](/slides/vi/java/convert-powerpoint/) cho các mục tiêu đầu ra ([PDF](/slides/vi/java/convert-powerpoint-to-pdf/), [SVG](/slides/vi/java/render-a-slide-as-an-svg-image/), [XPS](/slides/vi/java/convert-powerpoint-to-xps/), [HTML](/slides/vi/java/convert-powerpoint-to-html/), v.v.) và các tùy chọn render liên quan.