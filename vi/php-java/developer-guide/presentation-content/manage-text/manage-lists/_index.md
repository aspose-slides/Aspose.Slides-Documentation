---
title: Quản lý danh sách có dấu đầu dòng và đánh số trong bản trình chiếu bằng PHP
linktitle: Quản lý danh sách
type: docs
weight: 60
url: /vi/php-java/manage-lists/
keywords:
- dấu đầu dòng
- danh sách có dấu đầu dòng
- danh sách có đánh số
- dấu đầu dòng ký hiệu
- dấu đầu dòng hình ảnh
- dấu đầu dòng tùy chỉnh
- danh sách đa cấp
- tạo dấu đầu dòng
- thêm dấu đầu dòng
- thêm danh sách
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tìm hiểu cách tạo và định dạng danh sách có dấu đầu dòng, danh sách hình ảnh, danh sách đa cấp và danh sách có đánh số trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho PHP qua Java."
---
## **Tổng quan**

Aspose.Slides for PHP via Java cho phép bạn tạo và định dạng danh sách có dấu đầu dòng và danh sách có đánh số trong các bản trình bày PowerPoint và OpenDocument. Một mục danh sách là một đoạn văn mà các cài đặt dấu đầu dòng được kiểm soát thông qua định dạng đoạn văn của nó.

Sử dụng phương thức [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/#getParagraphFormat--) để truy cập các cài đặt danh sách ở mức đoạn văn. Điểm vào chính là [ParagraphFormat.getBullet](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#getBullet--) trả về một đối tượng [BulletFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bulletformat/). Với đối tượng này, bạn có thể đặt loại dấu đầu dòng, ký hiệu, hình ảnh, màu sắc, kích thước, kiểu đánh số và số bắt đầu.

Bài viết này hướng dẫn cách:

- tạo danh sách có dấu đầu dòng với ký hiệu tùy chỉnh
- tạo dấu đầu dòng bằng hình ảnh
- tạo danh sách đa cấp bằng cách đặt độ sâu đoạn văn
- tạo danh sách có đánh số
- kiểm tra và thay đổi định dạng danh sách trong một bản trình bày hiện có

## **Tạo danh sách có dấu đầu dòng**

Để tạo danh sách có dấu đầu dòng, thêm các đối tượng [Paragraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/) vào một [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) và đặt [BulletFormat.setType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bulletformat/#setType-int-) thành [BulletType.Symbol](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bullettype/#Symbol). Sau đó bạn có thể đặt [BulletFormat.setChar](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bulletformat/#setChar-char-), [BulletFormat.getColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bulletformat/#getColor--) và [BulletFormat.setHeight](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bulletformat/#setHeight-float-) để kiểm soát giao diện dấu đầu dòng.

Mã PHP sau minh họa cách tạo danh sách có dấu đầu dòng trong một slide:

```php
function createParagraph($paragraphText)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $paragraph->getParagraphFormat()->getBullet()->setChar("*");
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $bulletColor = new Java("java.awt.Color", 205, 92, 92);
    $paragraph->getParagraphFormat()->getBullet()->getColor()->setColor($bulletColor);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = createParagraph("The first paragraph");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph");
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("symbol_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Kết quả:

![Các dấu đầu dòng ký hiệu](symbol_bullets.png)

## **Tạo danh sách có đánh số**

Sử dụng danh sách có đánh số khi thứ tự các mục quan trọng. Đặt [BulletFormat.setType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bulletformat/#setType-int-) thành [BulletType.Numbered](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bullettype/#Numbered). Bạn cũng có thể chọn định dạng đánh số bằng [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle-int-) hoặc đặt [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) khi danh sách nên bắt đầu từ một giá trị khác 1.

Mã PHP sau cho thấy cách tạo danh sách có đánh số trong một slide:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph1->setText("Apple");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph2->setText("Orange");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph3->setText("Banana");
    $textFrame->getParagraphs()->add($paragraph3);

    $presentation->save("numbered_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Kết quả:

![Các dấu đầu dòng có đánh số](numbered_bullets.png)

## **Tạo dấu đầu dòng bằng hình ảnh**

Aspose.Slides cho phép bạn thay thế ký hiệu dấu đầu dòng thông thường bằng một hình ảnh. Dấu đầu dòng bằng hình ảnh hoạt động tốt nhất với các hình ảnh đơn giản vẫn giữ được khả năng đọc ở kích thước nhỏ, chẳng hạn như biểu tượng hoặc tệp PNG trong suốt nhỏ.

{{% alert color="primary" %}}
Lý tưởng nhất, nếu bạn định thay thế ký hiệu dấu đầu dòng bằng hình ảnh, nên lựa chọn đồ họa đơn giản với nền trong suốt. Những hình ảnh như vậy hoạt động tốt làm ký hiệu dấu đầu dòng tùy chỉnh.
{{% /alert %}}

Để tạo dấu đầu dòng bằng hình ảnh, thêm một hình ảnh vào [Presentation.getImages](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getImages--) và gán đối tượng [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) trả về cho [BulletFormat.getPicture](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bulletformat/#getPicture--). Đặt [BulletFormat.setType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bulletformat/#setType-int-) thành [BulletType.Picture](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bullettype/#Picture) trước khi gán hình ảnh.

Giả sử chúng ta có một tệp "image.png":

![Hình ảnh cho các dấu đầu dòng](picture_for_bullets.png)

Mã PHP sau cho thấy cách tạo dấu đầu dòng bằng hình ảnh trong một slide:

```php
function createParagraph($paragraphText, $bulletImage)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($bulletImage);
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $image = Images::fromFile("image.png");
    $bulletImage = $presentation->getImages()->addImage($image);

    $paragraph1 = createParagraph("The first paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("picture_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Kết quả:

![Các dấu đầu dòng bằng hình ảnh](picture_bullets.png)

## **Tạo danh sách đa cấp**

Sử dụng [ParagraphFormat.setDepth](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#setDepth-short-) để đặt các mục danh sách ở các cấp độ khác nhau. Cấp độ 0 là cấp cao nhất, cấp độ 1 là cấp con của nó, và cứ như vậy.

Mã PHP sau cho thấy cách tạo danh sách có dấu đầu dòng đa cấp:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->setDepth(0);
    $paragraph1->setText("My text - Depth 0");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->setDepth(1);
    $paragraph2->setText("My text - Depth 1");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->setDepth(2);
    $paragraph3->setText("My text - Depth 2");
    $textFrame->getParagraphs()->add($paragraph3);

    $paragraph4 = new Paragraph();
    $paragraph4->getParagraphFormat()->setDepth(3);
    $paragraph4->setText("My text - Depth 3");
    $textFrame->getParagraphs()->add($paragraph4);

    $presentation->save("multilevel_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Kết quả:

![Danh sách đa cấp](multilevel_list.png)

## **Thay đổi danh sách hiện có**

Để thay đổi định dạng danh sách trong một bản trình bày hiện có, truy cập đoạn văn mục tiêu và cập nhật các cài đặt [ParagraphFormat.getBullet](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#getBullet--) của nó. Các thuộc tính được sử dụng để tạo danh sách cũng có thể được dùng để kiểm tra hoặc sửa đổi danh sách được tải từ tệp PPT, PPTX hoặc ODP.

Mã PHP sau thay đổi đoạn văn đầu tiên trong một khung văn bản để sử dụng kiểu danh sách có đánh số:

```php
$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(1);
    $paragraph->getParagraphFormat()->setMarginLeft(30);
    $paragraph->getParagraphFormat()->setIndent(-20);

    $presentation->save("updated_list.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Danh sách có dấu đầu dòng và có đánh số có thể xuất ra PDF hoặc hình ảnh không?**

Có. Aspose.Slides giữ nguyên định dạng danh sách khi định dạng đích hỗ trợ bố cục văn bản và các tính năng dấu đầu dòng tương ứng.

**Tôi có thể chỉnh sửa danh sách trong các bản trình bày hiện có không?**

Có. Tải bản trình bày, truy cập đoạn văn mục tiêu, kiểm tra hoặc cập nhật các cài đặt [ParagraphFormat.getBullet](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#getBullet--) của nó, và lưu bản trình bày.

**Danh sách có thể chứa văn bản không phải Latin không?**

Có. Văn bản của mục danh sách có thể chứa ký tự Unicode, vì vậy bạn có thể tạo danh sách trong các bản trình bày đa ngôn ngữ. Đảm bảo các phông chữ được sử dụng trong bản trình bày hỗ trợ các ký tự bạn cần.