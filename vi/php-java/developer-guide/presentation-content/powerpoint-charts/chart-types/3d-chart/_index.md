---
title: Tùy chỉnh biểu đồ 3D trong bản trình bày bằng PHP
linktitle: Biểu đồ 3D
type: docs
url: /vi/php-java/3d-chart/
keywords:
- biểu đồ 3D
- xoay
- độ sâu
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Tìm hiểu cách tạo và tùy chỉnh biểu đồ 3D trong Aspose.Slides cho PHP qua Java, hỗ trợ các tệp PPT và PPTX — nâng cao bản trình bày của bạn ngay hôm nay."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh biểu đồ 3D trong Aspose.Slides bằng cách cấu hình các thiết lập `Rotation3D` như `RotationX`, `RotationY`, `DepthPercents` và `RightAngleAxes`. Nó hướng dẫn tạo một bản trình bày, thêm biểu đồ 3D với dữ liệu mặc định, áp dụng các thiết lập góc nhìn 3D cần thiết, và lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

## **Đặt các thuộc tính RotationX, RotationY và DepthPercents của biểu đồ 3D**

Aspose.Slides for PHP via Java cung cấp một API đơn giản để thiết lập các thuộc tính này. Bài viết tiếp theo sẽ giúp bạn cách đặt các thuộc tính khác nhau như **X,Y Rotation, DepthPercents** v.v. Mã mẫu áp dụng việc thiết lập các thuộc tính đã nêu ở trên.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Truy cập slide đầu tiên.
1. Thêm biểu đồ với dữ liệu mặc định.
1. Đặt các thuộc tính Rotation3D.
1. Ghi bản trình bày đã chỉnh sửa vào tệp PPTX.

```php
  $pres = new Presentation();
  try {
    # Truy cập slide đầu tiên
    $slide = $pres->getSlides()->get_Item(0);
    # Thêm biểu đồ với dữ liệu mặc định
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);
    # Đặt chỉ mục của sheet dữ liệu biểu đồ
    $defaultWorksheetIndex = 0;
    # Lấy worksheet dữ liệu biểu đồ
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Thêm series
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Thêm danh mục
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Đặt các thuộc tính Rotation3D
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);
    # Lấy series biểu đồ thứ hai
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Bây giờ đang điền dữ liệu cho series
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Đặt giá trị Overlap
    $series->getParentSeriesGroup()->setOverlap(100);
    # Ghi bản trình bày ra đĩa
    $pres->save("Rotation3D_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Các loại biểu đồ nào hỗ trợ chế độ 3D trong Aspose.Slides?**

Aspose.Slides hỗ trợ các biến thể 3D của biểu đồ cột, bao gồm Column 3D, Clustered Column 3D, Stacked Column 3D và 100% Stacked Column 3D, cùng với các loại 3D liên quan được hiển thị thông qua lớp [ChartType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/). Để có danh sách chính xác và cập nhật, hãy kiểm tra các thành viên của [ChartType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/) trong tài liệu API của phiên bản đã cài đặt.

**Tôi có thể lấy hình ảnh raster của biểu đồ 3D cho báo cáo hoặc web không?**

Có. Bạn có thể xuất biểu đồ thành hình ảnh thông qua [chart API](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getImage) hoặc [render toàn bộ slide](/slides/vi/php-java/convert-powerpoint-to-png/) sang các định dạng như PNG hoặc JPEG. Điều này hữu ích khi bạn cần xem trước pixel-perfect hoặc muốn nhúng biểu đồ vào tài liệu, bảng điều khiển hoặc trang web mà không cần PowerPoint.

**Hiệu năng của việc xây dựng và render các biểu đồ 3D lớn ra sao?**

Hiệu suất phụ thuộc vào khối lượng dữ liệu và độ phức tạp hình ảnh. Để đạt kết quả tốt nhất, hãy giảm thiểu hiệu ứng 3D, tránh sử dụng texture nặng trên các bề mặt và vùng vẽ, hạn chế số điểm dữ liệu mỗi series khi có thể, và render ra đầu ra có kích thước phù hợp (độ phân giải và kích thước) để đáp ứng nhu cầu hiển thị hoặc in ấn mục tiêu.