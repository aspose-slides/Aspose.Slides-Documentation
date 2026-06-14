---
title: Xuất biểu đồ bài thuyết trình trong PHP
linktitle: Xuất biểu đồ
type: docs
weight: 90
url: /vi/php-java/export-chart/
keywords:
- biểu đồ
- biểu đồ sang hình ảnh
- biểu đồ dưới dạng hình ảnh
- trích xuất hình ảnh biểu đồ
- PowerPoint
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Tìm hiểu cách xuất biểu đồ bài thuyết trình bằng Aspose.Slides cho PHP qua Java, hỗ trợ định dạng PPT và PPTX, và tối ưu hoá báo cáo trong bất kỳ quy trình làm việc nào."
---
## **Tổng quan**

Aspose.Slides cho phép bạn xuất biểu đồ từ bài thuyết trình dưới dạng hình ảnh. Bài viết này hướng dẫn cách lấy hình ảnh từ biểu đồ và lưu lại, hữu ích khi bạn cần tái sử dụng hình ảnh biểu đồ bên ngoài bản trình bày PowerPoint.

## **Lấy hình ảnh biểu đồ**
Aspose.Slides cho PHP qua Java cung cấp hỗ trợ để trích xuất hình ảnh của biểu đồ cụ thể. Dưới đây là ví dụ mẫu.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $slideImage = $chart->getImage();
    try {
      $slideImage->save("image.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Tôi có thể xuất biểu đồ dưới dạng vector (SVG) thay vì hình raster không?**

Có. Biểu đồ là một hình dạng, và nội dung của nó có thể được lưu dưới dạng SVG bằng cách sử dụng [phương pháp lưu shape-to-SVG](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/writeassvg/).

**Làm sao để đặt kích thước chính xác của biểu đồ đã xuất tính bằng pixel?**

Sử dụng các phương thức quá tải render hình ảnh cho phép bạn chỉ định kích thước hoặc tỉ lệ — thư viện hỗ trợ render các đối tượng với kích thước/tỉ lệ đã cho.

**Tôi nên làm gì nếu phông chữ trong nhãn và chú giải hiển thị sai sau khi xuất?**

[Tải các phông chữ cần thiết](/slides/vi/php-java/custom-font/) qua [FontsLoader](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsloader/) để việc render biểu đồ giữ nguyên các chỉ số và hiển thị văn bản.

**Việc xuất có tôn trọng chủ đề, kiểu dáng và hiệu ứng của PowerPoint không?**

Có. Bộ render của Aspose.Slides tuân theo định dạng của bài thuyết trình (chủ đề, kiểu dáng, màu nền, hiệu ứng), do đó giao diện của biểu đồ được giữ nguyên.

**Tôi có thể tìm các khả năng render/xuất khác ngoài hình ảnh biểu đồ ở đâu?**

Xem [API](https://reference.aspose.com/slides/vi/php-java/aspose.slides/)/[tài liệu](/slides/vi/php-java/convert-powerpoint/) để biết các mục tiêu đầu ra ([PDF](/slides/vi/php-java/convert-powerpoint-to-pdf/), [SVG](/slides/vi/php-java/render-a-slide-as-an-svg-image/), [XPS](/slides/vi/php-java/convert-powerpoint-to-xps/), [HTML](/slides/vi/php-java/convert-powerpoint-to-html/), v.v.) và các tùy chọn render liên quan.