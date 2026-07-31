---
title: Thêm Hình Dạng Đường vào Bản Trình Chiếu trong PHP
linktitle: Đường
type: docs
weight: 50
url: /vi/php-java/line/
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
description: "Tìm hiểu cách thao tác định dạng đường trong các bản trình chiếu PowerPoint với Aspose.Slides for PHP via Java. Khám phá các thuộc tính, phương thức và ví dụ."
---
## **Overview**

Aspose.Slides cho phép bạn thêm các hình dạng đường vào các slide PowerPoint một cách lập trình. Bài viết này chỉ cách tạo một đường đơn giản và cách tùy chỉnh đường sao cho nó hiển thị như một mũi tên.

Bạn sẽ học cách thêm một hình dạng đường vào slide, điều chỉnh diện mạo trực quan của nó, và lưu bản trình chiếu đã cập nhật. Các ví dụ tập trung vào các thiết lập định dạng đường thực tế như kiểu, độ rộng, mẫu gạch, tùy chọn đầu mũi tên và màu nền.

## **Create a Plain Line**

Để thêm một đường đơn giản vào slide đã chọn của bản trình chiếu, vui lòng làm theo các bước dưới đây:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
- Lấy tham chiếu của một slide bằng cách sử dụng Index của nó.
- Thêm một AutoShape loại Line bằng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/#addAutoShape) được cung cấp bởi đối tượng [ShapeCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/).
- Ghi bản trình chiếu đã sửa đổi dưới dạng file PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một đường vào slide đầu tiên của bản trình chiếu.

```php
  # Tạo một thể hiện của lớp PresentationEx đại diện cho tệp PPTX
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Thêm một AutoShape loại đường
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Ghi tệp PPTX ra đĩa
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Create an Arrow-Shaped Line**

Aspose.Slides for PHP via Java cũng cho phép các nhà phát triển cấu hình một số thuộc tính của đường để làm cho nó trông hấp dẫn hơn. Hãy thử cấu hình một vài thuộc tính của đường để nó trông giống như một mũi tên. Vui lòng làm theo các bước dưới đây:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
- Lấy tham chiếu của một slide bằng cách sử dụng Index của nó.
- Thêm một AutoShape loại Line bằng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/#addAutoShape) được cung cấp bởi đối tượng [ShapeCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/).
- Đặt [Line Style](https://reference.aspose.com/slides/vi/php-java/aspose.slides/LineStyle) thành một trong các kiểu do Aspose.Slides for PHP via Java cung cấp.
- Đặt độ rộng (Width) của đường.
- Đặt [Dash Style](https://reference.aspose.com/slides/vi/php-java/aspose.slides/LineDashStyle) của đường thành một trong các kiểu do Aspose.Slides for PHP via Java cung cấp.
- Đặt [Arrow Head Style](https://reference.aspose.com/slides/vi/php-java/aspose.slides/LineArrowheadStyle) và [Length](https://reference.aspose.com/slides/vi/php-java/aspose.slides/LineArrowheadLength) của điểm bắt đầu của đường.
- Đặt [Arrow Head Style](https://reference.aspose.com/slides/vi/php-java/aspose.slides/LineArrowheadStyle) và [Length](https://reference.aspose.com/slides/vi/php-java/aspose.slides/LineArrowheadLength) của điểm kết thúc của đường.
- Ghi bản trình chiếu đã sửa đổi dưới dạng file PPTX.

```php
  # Tạo một thể hiện của lớp PresentationEx đại diện cho tệp PPTX
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Thêm một AutoShape loại đường
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

## **FAQ**

**Can I convert a regular line into a connector so it "snaps" to shapes?**

Không. Một đường thường (một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) loại [Line](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapetype/)) sẽ không tự động trở thành connector. Để làm cho nó bắt dính vào các hình dạng, hãy sử dụng loại [Connector](https://reference.aspose.com/slides/vi/php-java/aspose.slides/connector/) chuyên dụng và các [API tương ứng](/slides/vi/php-java/connector/) để kết nối.

**What should I do if a line’s properties are inherited from the theme and it’s hard to determine the final values?**

[Đọc các thuộc tính thực tế](/slides/vi/php-java/shape-effective-properties/) thông qua `LineFormatEffectiveData`/`LineFillFormatEffectiveData`—chúng đã bao gồm việc kế thừa và các kiểu theme.

**Can I lock a line against editing (moving, resizing)?**

Có. Các hình dạng cung cấp [đối tượng khóa](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/getautoshapelock/) cho phép bạn ngăn chặn các thao tác chỉnh sửa.