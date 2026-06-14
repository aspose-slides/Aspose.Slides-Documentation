---
title: Tùy chỉnh thanh lỗi trong biểu đồ trình chiếu bằng PHP
linktitle: Thanh lỗi
type: docs
url: /vi/php-java/error-bar/
keywords:
- thanh lỗi
- giá trị tùy chỉnh
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tìm hiểu cách thêm và tùy chỉnh thanh lỗi trong biểu đồ với Aspose.Slides cho PHP thông qua Java — tối ưu hóa hình ảnh dữ liệu trong các bản trình chiếu PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với các thanh lỗi trong biểu đồ trình chiếu bằng cách sử dụng Aspose.Slides. Nó cho thấy cách thêm thanh lỗi vào một chuỗi biểu đồ, cấu hình cài đặt thanh lỗi X và Y, và áp dụng các kiểu giá trị khác nhau như cố định, phần trăm và giá trị tùy chỉnh.

Nó cũng trình diễn cách gán giá trị thanh lỗi tùy chỉnh cho các điểm dữ liệu riêng lẻ trong một chuỗi bằng cách sử dụng bộ sưu tập điểm dữ liệu tương ứng. Thêm vào đó, bài viết bao gồm các ghi chú ngắn gọn về cách các thanh lỗi hoạt động khi xuất, khả năng tương thích của chúng với các dấu đánh dấu và nhãn dữ liệu, và nơi tìm các lớp và enum tham chiếu API liên quan.

## **Thêm Thanh Lỗi**
Aspose.Slides for PHP via Java cung cấp một API đơn giản để quản lý các giá trị thanh lỗi. Mã mẫu áp dụng khi sử dụng kiểu giá trị tùy chỉnh. Để chỉ định một giá trị, sử dụng thuộc tính **ErrorBarCustomValues** của một điểm dữ liệu cụ thể trong bộ sưu tập [**data points**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseriescollection/) của chuỗi:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
1. Thêm một biểu đồ bong bóng vào slide mong muốn.
1. Truy cập vào chuỗi biểu đồ đầu tiên và đặt định dạng thanh lỗi X.
1. Truy cập vào chuỗi biểu đồ đầu tiên và đặt định dạng thanh lỗi Y.
1. Đặt giá trị và định dạng cho các thanh.
1. Ghi bản trình chiếu đã chỉnh sửa ra file PPTX.

```php
  # Tạo một thể hiện của lớp Presentation
  $pres = new Presentation();
  try {
    # Tạo một biểu đồ bong bóng
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Thêm thanh lỗi và thiết lập định dạng của chúng
    $errBarX = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsXFormat();
    $errBarY = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Fixed);
    $errBarX->setValue(0.1);
    $errBarY->setValueType(ErrorBarValueType::Percentage);
    $errBarY->setValue(5);
    $errBarX->setType(ErrorBarType::Plus);
    $errBarY->getFormat()->getLine()->setWidth(2.0);
    $errBarX->hasEndCap();
    # Lưu bản trình chiếu
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Thêm Giá Trị Thanh Lỗi Tùy Chỉnh**
Aspose.Slides for PHP via Java cung cấp một API đơn giản để quản lý các giá trị thanh lỗi tùy chỉnh. Mã mẫu áp dụng khi phương thức [**ErrorBarsFormat::getValueType**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/errorbarsformat/#getValueType) trả về **Custom**. Để chỉ định một giá trị, sử dụng thuộc tính **ErrorBarCustomValues** của một điểm dữ liệu cụ thể trong bộ sưu tập [**data points**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseriescollection/) của chuỗi:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
1. Thêm một biểu đồ bong bóng vào slide mong muốn.
1. Truy cập vào chuỗi biểu đồ đầu tiên và đặt định dạng thanh lỗi X.
1. Truy cập vào chuỗi biểu đồ đầu tiên và đặt định dạng thanh lỗi Y.
1. Truy cập các điểm dữ liệu riêng lẻ của chuỗi biểu đồ và đặt giá trị Thanh Lỗi cho từng điểm dữ liệu trong chuỗi.
1. Đặt giá trị và định dạng cho các thanh.
1. Ghi bản trình chiếu đã chỉnh sửa ra file PPTX.

```php
  # Tạo một thể hiện của lớp Presentation
  $pres = new Presentation();
  try {
    # Tạo một biểu đồ bong bóng
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Thêm thanh lỗi tùy chỉnh và thiết lập định dạng của chúng
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # Truy cập điểm dữ liệu của chuỗi biểu đồ và thiết lập giá trị thanh lỗi cho
    # điểm riêng lẻ
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # Thiết lập thanh lỗi cho các điểm của chuỗi biểu đồ
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # Lưu bản trình chiếu
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Đi gì xảy ra với thanh lỗi khi xuất bản trình chiếu sang PDF hoặc hình ảnh?**

Chúng được hiển thị như một phần của biểu đồ và được giữ lại trong quá trình chuyển đổi cùng với phần định dạng còn lại của biểu đồ, với giả định rằng phiên bản hoặc bộ render tương thích.

**Thanh lỗi có thể kết hợp với dấu đánh dấu và nhãn dữ liệu không?**

Có. Thanh lỗi là một yếu tố riêng biệt và tương thích với dấu đánh dấu và nhãn dữ liệu; nếu các yếu tố chồng lấn, bạn có thể cần điều chỉnh định dạng.

**Tôi có thể tìm danh sách các thuộc tính và lớp để làm việc với thanh lỗi trong API ở đâu?**

Trong tài liệu tham khảo API: lớp [ErrorBarsFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/errorbarsformat/) và các lớp liên quan [ErrorBarType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/errorbartype/) và [ErrorBarValueType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/errorbarvaluetype/).