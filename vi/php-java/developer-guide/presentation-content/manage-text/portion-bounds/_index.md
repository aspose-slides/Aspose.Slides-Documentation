---
title: Lấy giới hạn phần văn bản từ bản trình chiếu trong PHP
linktitle: Giới hạn phần văn bản
type: docs
weight: 47
url: /vi/php-java/portion-bounds/
keywords:
- giới hạn phần văn bản
- phần văn bản
- phần văn bản
- tọa độ văn bản
- vị trí văn bản
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tìm hiểu cách lấy giới hạn phần văn bản trong bản trình chiếu PowerPoint bằng Aspose.Slides cho PHP thông qua Java."
---
## **Tổng quan**

Một đoạn văn bản (text portion) đại diện cho một mảnh văn bản cụ thể bên trong một đoạn và cho phép bạn làm việc với mảnh đó một cách độc lập so với nội dung xung quanh. Trong Aspose.Slides, các đoạn văn bản có thể được sử dụng khi bạn cần lấy giới hạn của một mảnh văn bản, áp dụng định dạng chỉ cho một phần của đoạn, hoặc kiểm soát hành vi văn bản ở mức chi tiết hơn.

Bài viết này cho thấy cách lấy hình chữ nhật bao quanh một đoạn bằng cách sử dụng [Portion::getRect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/getrect/). Nó cũng trình bày cách lấy tọa độ bắt đầu của một đoạn bằng cách sử dụng [Portion::getCoordinates](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/getcoordinates/). Ngoài ra, bài viết còn nêu các kịch bản thường gặp liên quan đến đoạn, chẳng hạn như áp dụng siêu liên kết cho một mảnh văn bản duy nhất, hiểu cách định dạng được kế thừa qua đoạn, khung văn bản và chủ đề, cũng như xử lý các trường hợp phông chữ được chỉ định không khả dụng.

## **Lấy giới hạn của một đoạn văn bản**

Sử dụng [Portion::getRect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/getrect/) để lấy hình chữ nhật bao quanh một đoạn văn bản:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $rectangle = $portion->getRect();
            $rectangleX = java_values($rectangle->getX());
            $rectangleY = java_values($rectangle->getY());
            $rectangleWidth = java_values($rectangle->getWidth());
            $rectangleHeight = java_values($rectangle->getHeight());

            echo("X = " . $rectangleX . "; Y = " . $rectangleY . "; Width = " . $rectangleWidth . "; Height = " . $rectangleHeight);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Lấy tọa độ của một đoạn văn bản**

Sử dụng [Portion::getCoordinates](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/getcoordinates/) để lấy tọa độ bắt đầu của một đoạn văn bản:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $point = $portion->getCoordinates();
            $pointX = java_values($point->getX());
            $pointY = java_values($point->getY());

            echo("X = " . $pointX . "; Y = " . $pointY);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng siêu liên kết chỉ cho một phần của văn bản trong một đoạn duy nhất không?**

Có, bạn có thể [assign a hyperlink](/slides/vi/php-java/manage-hyperlinks/) cho một đoạn riêng lẻ; chỉ mảnh đó sẽ có thể nhấp, không phải toàn bộ đoạn.

**Cách kế thừa kiểu dáng hoạt động như thế nào: đoạn ghi đè gì và gì được lấy từ đoạn hoặc khung văn bản?**

Các thuộc tính ở mức Portion có độ ưu tiên cao nhất. Nếu một thuộc tính không được đặt trên [Portion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/), Aspose.Slides sẽ lấy nó từ [Paragraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/). Nếu cũng không được đặt ở đó, Aspose.Slides sẽ sử dụng kiểu dáng của [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) hoặc [theme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/theme/).

**Nếu phông chữ được chỉ định cho một đoạn không có trên máy hoặc máy chủ mục tiêu thì sẽ xảy ra gì?**

[Font substitution rules](/slides/vi/php-java/font-selection-sequence/) sẽ được áp dụng. Văn bản có thể được sắp xếp lại: các chỉ số, cách tách từ và chiều rộng có thể thay đổi, điều này quan trọng đối với việc định vị chính xác.

**Tôi có thể thiết lập độ trong suốt hoặc gradient cho phần điền màu văn bản ở mức Portion một cách độc lập so với phần còn lại của đoạn không?**

Có, màu văn bản, màu nền và độ trong suốt ở mức [Portion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/) có thể khác nhau so với các mảnh lân cận.