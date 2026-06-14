---
title: Quản lý các Phần Văn bản trong Bản trình chiếu bằng PHP
linktitle: Phần Văn bản
type: docs
weight: 70
url: /vi/php-java/portion/
keywords:
- phần văn bản
- đoạn văn bản
- tọa độ văn bản
- vị trí văn bản
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tìm hiểu cách quản lý các phần văn bản trong bản trình chiếu PowerPoint bằng Aspose.Slides cho PHP qua Java, nâng cao hiệu năng và khả năng tùy chỉnh."
---
## **Giới thiệu**

A text portion đại diện cho một đoạn văn bản cụ thể bên trong một đoạn và cho phép bạn làm việc với đoạn đó một cách độc lập so với nội dung xung quanh. Trong Aspose.Slides, phần có thể được sử dụng khi bạn cần lấy vị trí của một đoạn văn bản, áp dụng định dạng chỉ cho một phần của đoạn, hoặc kiểm soát hành vi văn bản ở mức chi tiết hơn.

## **Lấy tọa độ của một Text Portion**
[**getCoordinates()**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/getcoordinates/) method đã được thêm vào lớp [Portion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/) cho phép lấy tọa độ của đầu phần.

```php
  # Khởi tạo lớp Presentation đại diện cho PPTX
  $pres = new Presentation();
  try {
    # Định hình lại ngữ cảnh của bản trình chiếu
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    foreach($textFrame->getParagraphs() as $paragraph) {
      foreach($paragraph->getPortions() as $portion) {
        $point = $portion->getCoordinates();
        echo("X: " . $point->$x . " Y: " . $point->$y);
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Tôi có thể áp dụng siêu liên kết chỉ cho một phần của văn bản trong một đoạn duy nhất không?**

Có, bạn có thể [gán một siêu liên kết](/slides/vi/php-java/manage-hyperlinks/) cho một phần riêng lẻ; chỉ đoạn đó sẽ có thể nhấp, không phải toàn bộ đoạn.

**Cơ chế kế thừa kiểu dáng hoạt động như thế nào: phần Portion ghi đè gì, và gì được lấy từ Paragraph/TextFrame?**

Các thuộc tính ở mức Portion có độ ưu tiên cao nhất. Nếu một thuộc tính không được thiết lập trên [Portion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/), engine sẽ lấy từ [Paragraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/); nếu cũng không có ở đó, thì sẽ lấy từ [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) hoặc kiểu dáng của [theme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/theme/).

**Điều gì xảy ra nếu phông chữ được chỉ định cho một Portion không có trên máy/đối tượng đích?**

[Quy tắc thay thế phông chữ](/slides/vi/php-java/font-selection-sequence/) sẽ được áp dụng. Văn bản có thể tái bố trí: các chỉ số, dấu gạch nối, và độ rộng có thể thay đổi, điều này quan trọng đối với việc định vị chính xác.

**Tôi có thể đặt độ trong suốt hoặc gradient cho phần văn bản của Portion một cách độc lập so với phần còn lại của đoạn không?**

Có, màu văn bản, màu nền và độ trong suốt ở mức [Portion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/) có thể khác nhau so với các phần lân cận.