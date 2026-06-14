---
title: Tùy chỉnh biểu đồ tròn trong bản trình bày bằng PHP
linktitle: Biểu đồ tròn
type: docs
url: /vi/php-java/pie-chart/
keywords:
- biểu đồ tròn
- quản lý biểu đồ
- tùy chỉnh biểu đồ
- tùy chọn biểu đồ
- cài đặt biểu đồ
- tùy chọn vẽ
- màu lát
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Tìm hiểu cách tạo và tùy chỉnh biểu đồ tròn với Aspose.Slides cho PHP qua Java, có thể xuất sang PowerPoint, nâng cao khả năng kể chuyện dữ liệu của bạn trong vài giây."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với biểu đồ tròn trong Aspose.Slides. Nó chỉ ra cách cấu hình tùy chọn vẽ phụ cho biểu đồ Pie of Pie và Bar of Pie, và cách bật tự động tô màu các lát cho biểu đồ tròn tiêu chuẩn.

Các ví dụ tập trung vào các bước tùy chỉnh biểu đồ thực tế như thêm biểu đồ vào một slide, điều chỉnh cài đặt series và nhãn, thay thế dữ liệu biểu đồ mặc định bằng các danh mục và giá trị tùy chỉnh, và lưu bản trình bày đã cập nhật.

## **Tùy chọn vẽ phụ cho biểu đồ Pie of Pie và Bar of Pie**

Aspose.Slides for PHP qua Java hiện đã hỗ trợ tùy chọn vẽ phụ cho biểu đồ Pie of Pie hoặc Bar of Pie. Trong chủ đề này, chúng tôi sẽ chỉ cho bạn cách chỉ định các tùy chọn đó bằng Aspose.Slides. Để chỉ định các thuộc tính, thực hiện các bước sau:

1. Tạo một đối tượng lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
2. Thêm biểu đồ vào slide.
3. Xác định tùy chọn vẽ phụ của biểu đồ.
4. Ghi bản trình bày ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã thiết lập các thuộc tính khác nhau cho biểu đồ Pie of Pie.

```php
  # Tạo một đối tượng của lớp Presentation
  $pres = new Presentation();
  try {
    # Thêm biểu đồ vào slide
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # Đặt các thuộc tính khác nhau
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # Ghi bản trình bày ra đĩa
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Đặt màu tự động cho các lát của biểu đồ tròn**

Aspose.Slides for PHP qua Java cung cấp API đơn giản để thiết lập màu tự động cho các lát của biểu đồ tròn. Đoạn mã mẫu áp dụng việc thiết lập các thuộc tính trên.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
2. Truy cập slide đầu tiên.
3. Thêm biểu đồ với dữ liệu mặc định.
4. Đặt tiêu đề biểu đồ.
5. Đặt series đầu tiên hiển thị giá trị.
6. Đặt chỉ mục của bảng dữ liệu biểu đồ.
7. Lấy bảng tính dữ liệu của biểu đồ.
8. Xóa series và danh mục được tạo mặc định.
9. Thêm danh mục mới.
10. Thêm series mới.

Ghi bản trình bày đã chỉnh sửa ra tệp PPTX.

```php
  # Tạo một đối tượng của lớp Presentation
  $pres = new Presentation();
  try {
    # Thêm biểu đồ với dữ liệu mặc định
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Đặt tiêu đề biểu đồ
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Đặt series đầu tiên hiển thị giá trị
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Đặt chỉ mục của bảng dữ liệu biểu đồ
    $defaultWorksheetIndex = 0;
    # Lấy worksheet dữ liệu biểu đồ
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Xóa series và danh mục được tạo mặc định
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Thêm danh mục mới
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Thêm series mới
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Bây giờ điền dữ liệu cho series
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getParentSeriesGroup()->setColorVaried(true);
    $pres->save("Pie.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Các biến thể 'Pie of Pie' và 'Bar of Pie' có được hỗ trợ không?**

Có, thư viện [hỗ trợ](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/) một vẽ phụ cho các biểu đồ tròn, bao gồm các loại 'Pie of Pie' và 'Bar of Pie'.

**Tôi có thể xuất chỉ biểu đồ dưới dạng hình ảnh (ví dụ: PNG) không?**

Có, bạn có thể [xuất biểu đồ dưới dạng hình ảnh](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getImage) (ví dụ PNG) mà không cần toàn bộ bản trình bày.