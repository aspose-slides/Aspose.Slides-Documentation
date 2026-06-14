---
title: Thêm Các Hình Dạng Đường Vào Bản Trình Chiếu trong PHP
linktitle: Đường
type: docs
weight: 50
url: /vi/php-java/Line/
keywords:
- đường
- tạo đường
- thêm đường
- đường thẳng
- cấu hình đường
- tùy chỉnh đường
- kiểu gạch
- đầu mũi tên
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tìm hiểu cách thao tác định dạng đường trong bản trình chiếu PowerPoint với Aspose.Slides cho PHP qua Java. Khám phá các thuộc tính, phương thức và ví dụ."
---
## **Tổng quan**

Aspose.Slides cho phép bạn thêm các hình dạng đường vào các slide PowerPoint một cách lập trình. Bài viết này cho thấy cách tạo một đường đơn giản và cách tùy chỉnh một đường sao cho nó hiển thị như một mũi tên.

Bạn sẽ học cách thêm một hình dạng đường vào slide, điều chỉnh giao diện hiển thị của nó và lưu bản trình chiếu đã cập nhật. Các ví dụ tập trung vào các cài đặt định dạng đường thực tiễn như kiểu, độ rộng, mẫu gạch, tùy chọn đầu mũi tên và màu nền.

## **Tạo một Đường Thẳng Thuần**

Để thêm một đường thẳng đơn giản vào slide đã chọn của bản trình chiếu, vui lòng làm theo các bước dưới đây:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) .
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ số Index của nó.
- Thêm một AutoShape loại Line bằng phương pháp [addAutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/#addAutoShape) được cung cấp bởi đối tượng [ShapeCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/) .
- Ghi bản trình chiếu đã sửa đổi thành tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một đường vào slide đầu tiên của bản trình chiếu.

```php
  # Tạo thể hiện lớp PresentationEx đại diện cho tệp PPTX
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Thêm AutoShape kiểu line
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Ghi tệp PPTX ra đĩa
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tạo một Đường Dạng Mũi Tên**

Aspose.Slides for PHP via Java cũng cho phép các nhà phát triển cấu hình một số thuộc tính của đường để làm cho nó trông hấp dẫn hơn. Hãy thử cấu hình một vài thuộc tính của đường để nó trông như một mũi tên. Vui lòng làm theo các bước dưới đây để thực hiện:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) .
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ số Index của nó.
- Thêm một AutoShape loại Line bằng phương pháp [addAutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/#addAutoShape) được cung cấp bởi đối tượng [ShapeCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/) .
- Đặt [Line Style](https://reference.aspose.com/slides/vi/php-java/aspose.slides/LineStyle) thành một trong các kiểu được Aspose.Slides for PHP via Java cung cấp.
- Đặt độ rộng (Width) của đường.
- Đặt [Dash Style](https://reference.aspose.com/slides/vi/php-java/aspose.slides/LineDashStyle) của đường thành một trong các kiểu được Aspose.Slides for PHP via Java cung cấp.
- Đặt [Arrow Head Style](https://reference.aspose.com/slides/vi/php-java/aspose.slides/LineArrowheadStyle) và [Length](https://reference.aspose.com/slides/vi/php-java/aspose.slides/LineArrowheadLength) của điểm bắt đầu của đường.
- Đặt [Arrow Head Style](https://reference.aspose.com/slides/vi/php-java/aspose.slides/LineArrowheadStyle) và [Length](https://reference.aspose.com/slides/vi/php-java/aspose.slides/LineArrowheadLength) của điểm kết thúc của đường.
- Ghi bản trình chiếu đã sửa đổi thành tệp PPTX.

```php
  # Tạo thể hiện lớp PresentationEx đại diện cho tệp PPTX
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Thêm AutoShape kiểu line
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Áp dụng một số định dạng cho đường
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # Ghi tệp PPTX ra đĩa
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Tôi có thể chuyển một đường thường thành connector để nó “bắt” vào các hình dạng không?**

Không. Một đường thường (một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) loại [Line](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapetype/)) không tự động trở thành connector. Để làm cho nó bắt vào các hình dạng, hãy sử dụng loại [Connector](https://reference.aspose.com/slides/vi/php-java/aspose.slides/connector/) chuyên biệt và các [corresponding APIs](/slides/vi/php-java/connector/) cho việc kết nối.

**Nếu các thuộc tính của một đường được kế thừa từ chủ đề và khó xác định giá trị cuối cùng, tôi nên làm gì?**

[Đọc các thuộc tính hiệu quả](/slides/vi/php-java/shape-effective-properties/) qua `LineFormatEffectiveData`/`LineFillFormatEffectiveData` — các giá trị này đã tính đến việc kế thừa và kiểu chủ đề.

**Tôi có thể khóa một đường để ngăn chỉnh sửa (di chuyển, thay đổi kích thước) không?**

Có. Các shape cung cấp [lock objects](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/getautoshapelock/) cho phép bạn ngăn các thao tác chỉnh sửa.