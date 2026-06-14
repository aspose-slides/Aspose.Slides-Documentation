---
title: Xuất biểu đồ bản thuyết trình trong JavaScript
linktitle: Xuất biểu đồ
type: docs
weight: 90
url: /vi/nodejs-java/export-chart/
keywords:
- biểu đồ
- biểu đồ sang hình ảnh
- biểu đồ dưới dạng hình ảnh
- trích xuất hình ảnh biểu đồ
- PowerPoint
- bản thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách xuất biểu đồ bản thuyết trình với Aspose.Slides cho Node.js qua Java, hỗ trợ các định dạng PPT và PPTX, và tối ưu hoá việc báo cáo trong bất kỳ quy trình làm việc nào."
---
## **Tổng quan**

Aspose.Slides cho phép bạn xuất biểu đồ từ một bản thuyết trình dưới dạng hình ảnh. Bài viết này chỉ cách lấy hình ảnh từ biểu đồ và lưu lại, hữu ích khi bạn cần tái sử dụng hình ảnh biểu đồ ngoài PowerPoint.

## **Lấy hình ảnh biểu đồ**
Aspose.Slides for Node.js via Java hỗ trợ trích xuất hình ảnh của biểu đồ cụ thể. Ví dụ mẫu dưới đây được cung cấp.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var slideImage = chart.getImage();
    try {
        slideImage.save("image.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Tôi có thể xuất biểu đồ dưới dạng vector (SVG) thay vì hình raster không?**

Có. Biểu đồ là một hình dạng, và nội dung của nó có thể được lưu dưới dạng SVG bằng phương thức [shape-to-SVG saving method](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/writeassvg/).

**Làm sao để đặt kích thước chính xác của biểu đồ đã xuất tính bằng pixel?**

Sử dụng các overload của image-rendering cho phép bạn chỉ định kích thước hoặc tỉ lệ — thư viện hỗ trợ render đối tượng với kích thước/tỉ lệ đã cho.

**Nếu phông chữ trong nhãn và chú giải bị hiển thị sai sau khi xuất thì tôi phải làm gì?**

[Load the required fonts](/slides/vi/nodejs-java/custom-font/) qua [FontsLoader](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsloader/) để quá trình render biểu đồ giữ nguyên các chỉ số metric và giao diện văn bản.

**Việc xuất có tôn trọng chủ đề, kiểu dáng và hiệu ứng của PowerPoint không?**

Có. Bộ render của Aspose.Slides tuân theo định dạng của bản trình chiếu (chủ đề, kiểu dáng, màu nền, hiệu ứng), vì vậy giao diện của biểu đồ được bảo lưu.

**Tôi có thể tìm thấy khả năng render/ xuất nào khác ngoài hình ảnh biểu đồ ở đâu?**

Xem [API](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/)/[documentation](/slides/vi/nodejs-java/convert-powerpoint/) cho các mục tiêu xuất ra ([PDF](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/), [SVG](/slides/vi/nodejs-java/render-a-slide-as-an-svg-image/), [XPS](/slides/vi/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/vi/nodejs-java/convert-powerpoint-to-html/), v.v.) và các tùy chọn render liên quan.