---
title: Thêm Hình Chữ Nhât vào Bản Trình Bày bằng PHP
linktitle: Hình chữ nhật
type: docs
weight: 80
url: /vi/php-java/rectangle/
keywords:
- thêm hình chữ nhật
- tạo hình chữ nhật
- hình dạng chữ nhật
- hình chữ nhật đơn giản
- hình chữ nhật đã định dạng
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Nâng cao các bản trình bày PowerPoint của bạn bằng cách thêm các hình chữ nhật với Aspose.Slides cho PHP thông qua Java — dễ dàng thiết kế và sửa đổi các hình dạng một cách lập trình."
---
## **Tổng quan**

Bài viết này hướng dẫn cách thêm các hình chữ nhật vào các slide PowerPoint bằng Aspose.Slides. Nó bao gồm việc tạo một hình chữ nhật đơn giản, tạo một hình chữ nhật đã được định dạng, và lưu bản trình bày đã cập nhật dưới dạng tập tin PPTX.

Bạn cũng sẽ thấy cách áp dụng các định dạng cơ bản cho hình chữ nhật, chẳng hạn như màu nền đặc, màu đường viền và độ rộng đường viền. Ngoài ra, phần FAQ của bài viết chỉ tới các nhiệm vụ liên quan đến hình chữ nhật, bao gồm các góc bo tròn, nền ảnh, hiệu ứng hình ảnh, siêu liên kết, khóa hình, tùy chọn xuất và các thuộc tính hiệu quả.

## **Thêm hình chữ nhật vào slide**
Để thêm một hình chữ nhật đơn giản vào slide đã chọn của bản trình bày, vui lòng làm theo các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation).
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
- Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) loại Rectangle bằng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/#addAutoShape) được cung cấp bởi đối tượng [ShapeCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/).
- Ghi bản trình bày đã sửa đổi thành tập tin PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một hình chữ nhật đơn giản vào slide đầu tiên của bản trình bày.

```php
  # Khởi tạo lớp Prseetation đại diện cho PPTX
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Thêm AutoShape loại hình elip
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Lưu tệp PPTX vào đĩa
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Thêm hình chữ nhật đã định dạng vào slide**
Để thêm một hình chữ nhật đã định dạng vào slide, vui lòng làm theo các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation).
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
- Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) loại Rectangle bằng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/#addAutoShape) được cung cấp bởi đối tượng [ShapeCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/).
- Đặt [Fill Type](https://reference.aspose.com/slides/vi/php-java/aspose.slides/FillType) của Rectangle thành Solid.
- Đặt màu của Rectangle bằng phương thức [ColorFormat::setColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/colorformat/#setColor) được cung cấp bởi đối tượng [FillFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fillformat/) liên kết với đối tượng [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/).
- Đặt màu của các đường viền của Rectangle.
- Đặt độ rộng của các đường viền của Rectangle.
- Ghi bản trình bày đã sửa đổi thành tập tin PPTX.

Các bước trên được thực hiện trong ví dụ dưới đây.

```php
  # Khởi tạo lớp Prseetation đại diện cho PPTX
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Thêm AutoShape loại ellipse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Áp dụng một số định dạng cho hình ellipse
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # Áp dụng một số định dạng cho đường viền của Ellipse
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Lưu tệp PPTX vào đĩa
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Làm sao tôi có thể thêm một hình chữ nhật có các góc bo tròn?**

Sử dụng loại hình dạng [shape type](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapetype/) có góc bo tròn và điều chỉnh bán kính góc trong thuộc tính của hình; việc bo tròn cũng có thể áp dụng riêng cho từng góc bằng các điều chỉnh hình học.

**Làm sao tôi có thể lấp đầy một hình chữ nhật bằng hình ảnh (kết cấu)?**

Chọn loại [fill type](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filltype/) là picture, cung cấp nguồn ảnh và cấu hình các chế độ [stretching/tiling modes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillmode/).

**Hình chữ nhật có thể có bóng và phát sáng không?**

Có. [Outer/inner shadow, glow, and soft edges](/slides/vi/php-java/shape-effect/) đều có sẵn với các tham số có thể điều chỉnh.

**Tôi có thể biến một hình chữ nhật thành nút bấm có siêu liên kết không?**

Có. [Assign a hyperlink](/slides/vi/php-java/manage-hyperlinks/) cho hành động click vào hình dạng (nhảy tới slide, tập tin, địa chỉ web hoặc email).

**Làm sao tôi có thể bảo vệ một hình chữ nhật khỏi việc di chuyển và thay đổi?**

Sử dụng khóa hình dạng: bạn có thể ngăn việc di chuyển, thay đổi kích thước, chọn hoặc chỉnh sửa văn bản để duy trì bố cục.

**Tôi có thể chuyển đổi một hình chữ nhật thành ảnh raster hoặc SVG không?**

Có. Bạn có thể [render the shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getImage) thành ảnh với kích thước/tỷ lệ xác định hoặc [export it as SVG](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/writeassvg/) để sử dụng dưới dạng vector.

**Làm sao tôi nhanh chóng lấy các thuộc tính thực tế (effective) của một hình chữ nhật xét đến theme và kế thừa?**

[Use the shape’s effective properties](/slides/vi/php-java/shape-effective-properties/): API trả về các giá trị đã được tính toán, bao gồm các kiểu theme, bố cục và cài đặt cục bộ, giúp đơn giản hoá việc phân tích định dạng.