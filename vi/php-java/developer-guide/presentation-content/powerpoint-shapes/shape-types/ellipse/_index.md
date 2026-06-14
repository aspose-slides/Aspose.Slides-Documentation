---
title: Thêm các Ellipse vào Bản trình bày trong PHP
linktitle: Ellipse
type: docs
weight: 30
url: /vi/php-java/ellipse/
keywords:
- ellipse
- hình dạng
- thêm ellipse
- tạo ellipse
- vẽ ellipse
- ellipse đã định dạng
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Tìm hiểu cách tạo, định dạng và thao tác các hình ellipse trong Aspose.Slides cho PHP thông qua Java trên các bản trình bày PPT và PPTX — có kèm ví dụ mã."
---
## **Tổng quan**

Bài viết này chỉ ra cách thêm các hình ellipse vào các slide PowerPoint bằng cách sử dụng Aspose.Slides. Nó bao gồm việc tạo một ellipse đơn giản, tạo một ellipse đã định dạng, và lưu bản trình bày đã cập nhật dưới dạng tệp PPTX. Ngoài ra còn đề cập đến các câu hỏi liên quan như làm việc với vị trí và kích thước của ellipse, kiểm soát thứ tự chồng lên nhau, và áp dụng hiệu ứng hoạt hình.

## **Tạo một Ellipse**
Để thêm một ellipse đơn giản vào slide đã chọn của bản trình bày, vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation).
- Lấy tham chiếu của một slide bằng cách sử dụng Index của nó.
- Thêm một AutoShape loại Ellipse bằng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/#addAutoShape) được cung cấp bởi đối tượng [ShapeCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/).
- Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ được đưa ra dưới đây, chúng tôi đã thêm một ellipse vào slide đầu tiên

```php
  # Khởi tạo lớp Presentation đại diện cho file PPTX
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Thêm AutoShape loại ellipse
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Ghi file PPTX ra đĩa
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tạo một Ellipse đã Định dạng**
Để thêm một ellipse được định dạng tốt hơn vào slide, vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation).
- Lấy tham chiếu của một slide bằng cách sử dụng Index của nó.
- Thêm một AutoShape loại Ellipse bằng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/#addAutoShape) được cung cấp bởi đối tượng [ShapeCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/).
- Đặt Fill Type của Ellipse thành Solid.
- Đặt màu của Ellipse bằng phương thức `SolidFillColor::setColor` được cung cấp bởi đối tượng [FillFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fillformat/) liên kết với đối tượng [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/).
- Đặt màu của các đường viền của Ellipse.
- Đặt độ rộng của các đường viền của Ellipse.
- Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ được đưa ra dưới đây, chúng tôi đã thêm một ellipse đã định dạng vào slide đầu tiên của bản trình bày.

```php
  # Khởi tạo lớp Presentation đại diện cho file PPTX
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Thêm AutoShape loại ellipse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Áp dụng một số định dạng cho hình ellipse
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # Áp dụng một số định dạng cho đường viền của Ellipse
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Ghi file PPTX ra đĩa
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Làm thế nào để đặt vị trí và kích thước chính xác của một ellipse so với đơn vị của slide?**

Các tọa độ và kích thước thường được chỉ định **theo điểm**. Để có kết quả dự đoán được, hãy tính toán dựa trên kích thước slide và chuyển đổi milimet hoặc inch cần thiết sang điểm trước khi gán giá trị.

**Làm sao để đặt một ellipse phía trên hoặc phía dưới các đối tượng khác (kiểm soát thứ tự chồng lên)?**

Điều chỉnh thứ tự vẽ của đối tượng bằng cách đưa nó lên phía trước hoặc gửi nó về phía sau. Điều này cho phép ellipse chồng lên các đối tượng khác hoặc hiển thị những đối tượng nằm dưới nó.

**Làm thế nào để tạo hoạt hình cho việc xuất hiện hoặc nhấn mạnh một ellipse?**

[Apply](/slides/vi/php-java/shape-animation/) hiệu ứng entrance, emphasis hoặc exit cho hình, và cấu hình trigger và thời gian để điều khiển khi nào và cách hoạt hình được phát.