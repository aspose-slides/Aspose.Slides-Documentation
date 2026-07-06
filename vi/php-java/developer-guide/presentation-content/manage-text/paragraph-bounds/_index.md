---
title: Lấy giới hạn đoạn văn từ bài thuyết trình trong PHP
linktitle: Giới hạn đoạn văn
type: docs
weight: 43
url: /vi/php-java/paragraph-bounds/
keywords:
- giới hạn đoạn văn
- tọa độ đoạn văn
- kích thước đoạn văn
- khung văn bản
- PowerPoint
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Tìm hiểu cách truy xuất giới hạn đoạn văn trong Aspose.Slides cho PHP thông qua Java để tối ưu vị trí văn bản trong các bài thuyết trình PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách lấy giới hạn, kích thước và tọa độ của các đoạn văn trong Aspose.Slides. Nó cho thấy cách truy xuất hình chữ nhật của một đoạn văn từ một [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) bằng cách sử dụng [Paragraph::getRect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/getrect/), cách lấy tọa độ đoạn văn bên trong khung văn bản của ô bảng, và nêu bật các chi tiết quan trọng như đơn vị đo, ảnh hưởng của việc gói văn bản đối với giới hạn, chuyển đổi sang pixel, và các giá trị định dạng đoạn văn “effective”.

## **Lấy tọa độ hình chữ nhật của một đoạn văn**

Sử dụng [Paragraph::getRect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/getrect/) để lấy hình chữ nhật bao quanh một đoạn văn.

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $rectangle = $paragraph->getRect();
} finally {
    $presentation->dispose();
}
```

## **Lấy kích thước của một đoạn văn bên trong khung văn bản ô bảng**

Để lấy kích thước và tọa độ của một [Paragraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/) trong khung văn bản ô bảng, sử dụng [Paragraph::getRect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/getrect/). Hình chữ nhật trả về là tương đối so với khung văn bản ô bảng, vì vậy hãy cộng vị trí bảng và độ dịch ô khi bạn cần tọa độ ở mức slide.

Ví dụ sau lấy giới hạn của đoạn văn bên trong một ô bảng và vẽ các hình chữ nhật trên slide để hiển thị các giới hạn đó:

```php
$presentation = new Presentation("source.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);
    $cell = $table->getRows()->get_Item(1)->get_Item(1);

    $cellX = java_values($table->getX()) + java_values($cell->getOffsetX());
    $cellY = java_values($table->getY()) + java_values($cell->getOffsetY());

    foreach ($cell->getTextFrame()->getParagraphs() as $paragraph) {
        if ($paragraph->getText() == "") {
            continue;
        }

        $paragraphRectangle = $paragraph->getRect();
        $paragraphRectangleX = java_values($paragraphRectangle->getX()) + $cellX;
        $paragraphRectangleY = java_values($paragraphRectangle->getY()) + $cellY;
        $paragraphRectangleWidth = java_values($paragraphRectangle->getWidth());
        $paragraphRectangleHeight = java_values($paragraphRectangle->getHeight());

        $paragraphBoundsShape = $slide->getShapes()->addAutoShape(
            ShapeType::Rectangle,
            $paragraphRectangleX,
            $paragraphRectangleY,
            $paragraphRectangleWidth,
            $paragraphRectangleHeight
        );

        $paragraphBoundsShape->getFillFormat()->setFillType(FillType::NoFill);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Câu hỏi thường gặp**

**Các tọa độ đoạn văn được đo bằng đơn vị nào?**

Chúng được đo bằng điểm, trong đó 1 inch bằng 72 điểm. Điều này áp dụng cho tất cả các tọa độ và kích thước trên slide.

**Việc gói văn bản có ảnh hưởng đến giới hạn của đoạn văn không?**

Có. Nếu [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/setwraptext/) được bật cho [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/), văn bản sẽ bị ngắt để vừa với chiều rộng khu vực, gây thay đổi giới hạn thực tế của đoạn văn.

**Có thể ánh xạ tọa độ đoạn văn sang pixel trong hình ảnh xuất ra một cách đáng tin cậy không?**

Có. Chuyển đổi điểm sang pixel bằng công thức: pixel = điểm × (DPI / 72). Kết quả phụ thuộc vào DPI được chọn cho quá trình render hoặc xuất.

**Làm thế nào để lấy các tham số định dạng đoạn văn “effective”, tính đến việc kế thừa kiểu?**

Sử dụng [cấu trúc dữ liệu định dạng đoạn văn effective](/slides/vi/php-java/shape-effective-properties/); nó trả về các giá trị cuối cùng đã hợp nhất cho thụt lề, khoảng cách, gói văn bản, RTL và các thuộc tính khác.