---
title: Tùy chỉnh biểu đồ bánh vòng trong bản trình bày bằng PHP
linktitle: Biểu đồ bánh vòng
type: docs
weight: 30
url: /vi/php-java/doughnut-chart/
keywords:
- biểu đồ bánh vòng
- khoảng trống trung tâm
- kích thước lỗ
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Khám phá cách tạo và tùy chỉnh biểu đồ bánh vòng trong Aspose.Slides cho PHP thông qua Java, hỗ trợ các định dạng PowerPoint cho các bản trình bày động."
---
## **Tổng quan**

Bài viết này hướng dẫn cách làm việc với biểu đồ bánh vòng trong Aspose.Slides bằng cách thêm biểu đồ vào một slide, đặt kích thước lỗ trung tâm và lưu bản trình bày. Nội dung tập trung vào phương thức `setDoughnutHoleSize` và trình bày các bước cơ bản cần thiết để tùy chỉnh loại biểu đồ này bằng mã.

Nó cũng bao gồm một phần FAQ ngắn về các kịch bản liên quan tới biểu đồ bánh vòng, chẳng hạn như sử dụng nhiều series để tạo nhiều vòng, làm việc với biểu đồ bánh vòng bị nổ, và xuất biểu đồ dưới dạng hình ảnh raster hoặc SVG.

## **Chỉ định khoảng trống trung tâm trong biểu đồ bánh vòng**

Để chỉ định kích thước lỗ trong biểu đồ bánh vòng, vui lòng làm theo các bước sau:

1. Tạo đối tượng [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation).
1. Thêm biểu đồ bánh vòng vào slide.
1. Xác định kích thước lỗ trong biểu đồ bánh vòng.
1. Ghi bản trình bày ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã đặt kích thước lỗ trong biểu đồ bánh vòng.

```php
  # Tạo một thể hiện của lớp Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
    # Ghi bản trình bày ra đĩa
    $pres->save("DoughnutHoleSize_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Tôi có thể tạo bánh vòng đa cấp với nhiều vòng không?**

Có. Thêm nhiều series vào một biểu đồ bánh vòng — mỗi series sẽ trở thành một vòng riêng. Thứ tự các vòng được xác định bởi thứ tự của các series trong bộ sưu tập.

**Biểu đồ bánh vòng "bị nổ" (các lát tách rời) có được hỗ trợ không?**

Có. Có loại biểu đồ Exploded Doughnut và thuộc tính explosion trên các điểm dữ liệu; bạn có thể tách các lát riêng lẻ.

**Làm thế nào để lấy hình ảnh của biểu đồ bánh vòng (PNG/SVG) cho báo cáo?**

Biểu đồ là một hình dạng; bạn có thể render nó thành một [raster image](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getImage) hoặc xuất biểu đồ ra một [SVG image](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#writeAsSvg).