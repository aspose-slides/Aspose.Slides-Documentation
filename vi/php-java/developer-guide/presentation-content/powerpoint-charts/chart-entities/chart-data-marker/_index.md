---
title: Quản lý các Dấu Dữ liệu Biểu đồ trong Bản trình chiếu dùng PHP
linktitle: Dấu Dữ liệu
type: docs
url: /vi/php-java/chart-data-marker/
keywords:
- biểu đồ
- điểm dữ liệu
- dấu
- các tùy chọn dấu
- kích thước dấu
- kiểu tô
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tìm hiểu cách tùy chỉnh các dấu dữ liệu biểu đồ trong Aspose.Slides cho PHP, nâng cao hiệu quả bản trình chiếu trên các định dạng PPT và PPTX với các ví dụ mã rõ ràng."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với các dấu dữ liệu biểu đồ trong Aspose.Slides. Nó cho thấy cách tạo biểu đồ, truy cập một chuỗi và các điểm dữ liệu của nó, áp dụng tô hình ảnh vào các dấu ở mức điểm dữ liệu, điều chỉnh kích thước dấu, và lưu bản trình chiếu đã cập nhật. Nó cũng lưu ý rằng các hình dạng dấu tiêu chuẩn có sẵn qua enumeration `MarkerStyleType` và giao diện của dấu được bảo lưu khi xuất biểu đồ sang định dạng raster hoặc SVG.

## **Cài đặt tùy chọn dấu biểu đồ**
Các dấu có thể được đặt trên các điểm dữ liệu của biểu đồ trong các series cụ thể. Để đặt tùy chọn dấu biểu đồ, vui lòng làm theo các bước dưới đây:

- Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
- Tạo biểu đồ mặc định.
- Đặt ảnh.
- Lấy series biểu đồ đầu tiên.
- Thêm điểm dữ liệu mới.
- Ghi bản trình chiếu ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã đặt tùy chọn dấu biểu đồ ở mức điểm dữ liệu.

```php
  # Tạo bản trình chiếu trống
  $pres = new Presentation();
  try {
    # Truy cập slide đầu tiên
    $slide = $pres->getSlides()->get_Item(0);
    # Tạo biểu đồ mặc định
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    # Lấy chỉ mục WorkSheet dữ liệu biểu đồ mặc định
    $defaultWorksheetIndex = 0;
    # Lấy WorkSheet dữ liệu biểu đồ
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Xóa series demo
    $chart->getChartData()->getSeries()->clear();
    # Thêm series mới
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    # Tải ảnh 1
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    # Tải ảnh 2
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    # Lấy series biểu đồ đầu tiên
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Thêm điểm mới (1:3) ở đó.
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 2.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 3.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 4, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    # Thay đổi dấu series biểu đồ
    $series->getMarker()->setSize(15);
    # Lưu bản trình chiếu kèm biểu đồ
    $pres->save("ScatterChart.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Những hình dạng dấu nào có sẵn ngay lập tức?**

Các hình dạng tiêu chuẩn có sẵn (vòng tròn, hình vuông, hình thoi, hình tam giác, v.v.); danh sách được định nghĩa bởi lớp [MarkerStyleType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/markerstyletype/). Nếu bạn cần một hình dạng không tiêu chuẩn, hãy sử dụng dấu với tô hình ảnh để mô phỏng hình ảnh tùy chỉnh.

**Các dấu có được bảo lưu khi xuất biểu đồ sang ảnh hoặc SVG không?**

Có. Khi render biểu đồ sang [raster formats](/slides/vi/php-java/convert-powerpoint-to-png/) hoặc lưu [shapes as SVG](/slides/vi/php-java/render-a-slide-as-an-svg-image/), các dấu giữ nguyên giao diện và cài đặt của chúng, bao gồm kích thước, màu nền và đường viền.