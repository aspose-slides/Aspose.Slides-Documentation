---
title: Lấy giới hạn đoạn văn từ bài trình chiếu trong PHP
linktitle: Đoạn văn
type: docs
weight: 60
url: /vi/php-java/paragraph/
keywords:
- giới hạn đoạn văn
- giới hạn phần văn bản
- tọa độ đoạn văn
- tọa độ phần
- kích thước đoạn văn
- kích thước phần văn bản
- khung văn bản
- PowerPoint
- bài trình chiếu
- PHP
- Aspose.Slides
description: "Tìm hiểu cách lấy giới hạn đoạn và phần văn bản trong Aspose.Slides cho PHP qua Java để tối ưu hóa vị trí văn bản trong các bài trình chiếu PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách lấy giới hạn, kích thước và tọa độ của các đoạn văn và các phần văn bản trong Aspose.Slides. Nó cho thấy cách lấy hình chữ nhật của một đoạn trong `TextFrame` bằng cách sử dụng `getRect()`, cách lấy tọa độ của đoạn và phần bên trong khung văn bản của ô bảng, và nêu bật các chi tiết quan trọng như đơn vị đo, ảnh hưởng của việc gói văn bản đến giới hạn, chuyển đổi sang pixel, và các giá trị định dạng đoạn “hiệu quả”.

## **Lấy tọa độ đoạn và phần trong TextFrame**
Sử dụng Aspose.Slides cho PHP qua Java, các nhà phát triển hiện có thể lấy tọa độ hình chữ nhật cho Paragraph trong bộ sưu tập đoạn của TextFrame. Nó cũng cho phép bạn lấy [các tọa độ của phần](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/#getCoordinates) trong bộ sưu tập phần của một đoạn. Trong chủ đề này, chúng tôi sẽ trình bày bằng một ví dụ cách lấy tọa độ hình chữ nhật cho đoạn cùng với vị trí của phần bên trong đoạn.

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```

## **Lấy tọa độ hình chữ nhật của một đoạn**
Sử dụng phương thức [**getRect()**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/#getRect) các nhà phát triển có thể lấy hình chữ nhật giới hạn của đoạn.

```php
  $pres = new Presentation("HelloWorld.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    $rect = $textFrame->getParagraphs()->get_Item(0)->getRect();
    echo("X: " . $rect->$x . " Y: " . $rect->$y . " Width: " . $rect->$width . " Height: " . $rect->$height);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Lấy kích thước của một đoạn và phần trong TextFrame của ô bảng**
Để lấy kích thước và tọa độ của [Portion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Portion) hoặc [Paragraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Paragraph) trong khung văn bản của ô bảng, bạn có thể sử dụng các phương thức [Portion::getRect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/#getRect) và [Paragraph::getRect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/#getRect).

Đoạn mã mẫu sau minh họa thao tác đã mô tả:

```php
  $pres = new Presentation("source.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $cell = $tbl->getRows()->get_Item(1)->get_Item(1);
    $x = $tbl->getX() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetX();
    $y = $tbl->getY() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetY();
    foreach($cell->getTextFrame()->getParagraphs() as $para) {
      if ($para->getText()->equals("")) {
        continue;
      }
      $rect = $para->getRect();
      $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
      $shape->getFillFormat()->setFillType(FillType::NoFill);
      $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
      $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
      foreach($para->getPortions() as $portion) {
        if ($portion->getText()->contains("0")) {
          $rect = $portion->getRect();
          $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
          $shape->getFillFormat()->setFillType(FillType::NoFill);
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Đơn vị nào được sử dụng để đo tọa độ trả về cho một đoạn và các phần văn bản?**  
Trong điểm (points), trong đó 1 inch = 72 điểm. Điều này áp dụng cho tất cả các tọa độ và kích thước trên slide.

**Việc gói từ có ảnh hưởng đến giới hạn của đoạn không?**  
Có. Nếu [wrapping](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/setwraptext/) được bật trong [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/), văn bản sẽ được ngắt để vừa với chiều rộng khu vực, điều này làm thay đổi giới hạn thực tế của đoạn.

**Có thể ánh xạ tọa độ đoạn sang pixel trong hình ảnh xuất ra một cách đáng tin cậy không?**  
Có. Chuyển đổi điểm sang pixel bằng công thức: pixels = points × (DPI / 72). Kết quả phụ thuộc vào DPI được chọn cho quá trình render/xuất.

**Làm thế nào để tôi lấy các tham số định dạng đoạn “hiệu quả”, có tính đến kế thừa kiểu?**  
Sử dụng [cấu trúc dữ liệu định dạng đoạn hiệu quả](/slides/vi/php-java/shape-effective-properties/); nó trả về các giá trị hợp nhất cuối cùng cho thụt lề, khoảng cách, gói văn bản, RTL và các thiết lập khác.