---
title: Quản lý các đoạn văn bản PowerPoint trong PHP
linktitle: Quản lý Đoạn Văn
type: docs
weight: 40
url: /vi/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
keywords:
- thêm văn bản
- thêm đoạn
- quản lý văn bản
- quản lý đoạn
- quản lý dấu đầu
- thụt lề đoạn
- thụt lề treo
- đánh dấu đầu đoạn
- danh sách có số
- danh sách dấu đầu
- thuộc tính đoạn
- nhập HTML
- văn bản sang HTML
- đoạn sang HTML
- đoạn sang hình ảnh
- văn bản sang hình ảnh
- xuất đoạn
- PowerPoint
- OpenDocument
- bản trình bày
- PHP
- Aspose.Slides
description: "Làm chủ định dạng đoạn với Aspose.Slides cho PHP qua Java — tối ưu căn chỉnh, khoảng cách và kiểu dáng trong các bản trình bày PPT, PPTX và ODP."
---
## **Giới thiệu**

Aspose.Slides cung cấp tất cả các lớp bạn cần để làm việc với văn bản, đoạn văn và các phần trong PowerPoint.

* Aspose.Slides cung cấp lớp [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) để cho phép bạn thêm các đối tượng đại diện cho một đoạn văn. Một đối tượng `TextFame` có thể chứa một hoặc nhiều đoạn văn (mỗi đoạn được tạo bằng cách xuống dòng).
* Aspose.Slides cung cấp lớp [Paragraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/) để cho phép bạn thêm các đối tượng đại diện cho các phần. Một đối tượng `Paragraph` có thể chứa một hoặc nhiều phần (tập hợp các đối tượng phần).
* Aspose.Slides cung cấp lớp [Portion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/) để cho phép bạn thêm các đối tượng đại diện cho văn bản và các thuộc tính định dạng của chúng.

Một đối tượng `Paragraph` có khả năng xử lý văn bản với các thuộc tính định dạng khác nhau thông qua các đối tượng `Portion` bên dưới.

## **Thêm Nhiều Đoạn Văn Chứa Nhiều Phần**

Các bước sau cho bạn biết cách thêm một khung văn bản chứa 3 đoạn và mỗi đoạn chứa 3 phần:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Truy cập tham chiếu slide tương ứng thông qua chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) hình chữ nhật vào slide.
4. Lấy ITextFrame liên kết với [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/).
5. Tạo hai đối tượng [Paragraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/) và thêm chúng vào bộ sưu tập đoạn của [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/).
6. Tạo ba đối tượng [Portion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/) cho mỗi `Paragraph` mới (hai đối tượng Portion cho đoạn mặc định) và thêm mỗi đối tượng `Portion` vào bộ sưu tập phần của từng `Paragraph`.
7. Đặt một đoạn văn bản cho mỗi phần.
8. Áp dụng các tính năng định dạng ưa thích cho mỗi phần bằng các thuộc tính định dạng mà đối tượng `Portion` cung cấp.
9. Lưu bản trình bày đã chỉnh sửa.

Mã PHP dưới đây là triển khai các bước để thêm các đoạn chứa các phần:

```php
# Tạo một lớp Presentation đại diện cho tệp PPTX
$pres = new Presentation();
try {
    # Truy cập slide đầu tiên
    $slide = $pres->getSlides()->get_Item(0);
    # Thêm một AutoShape loại Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # Truy cập TextFrame của AutoShape
    $tf = $ashp->getTextFrame();
    # Tạo Paragraphs và Portions với các định dạng văn bản khác nhau
    $para0 = $tf->getParagraphs()->get_Item(0);
    $port01 = new Portion();
    $port02 = new Portion();
    $para0->getPortions()->add($port01);
    $para0->getPortions()->add($port02);
    $para1 = new Paragraph();
    $tf->getParagraphs()->add($para1);
    $port10 = new Portion();
    $port11 = new Portion();
    $port12 = new Portion();
    $para1->getPortions()->add($port10);
    $para1->getPortions()->add($port11);
    $para1->getPortions()->add($port12);
    $para2 = new Paragraph();
    $tf->getParagraphs()->add($para2);
    $port20 = new Portion();
    $port21 = new Portion();
    $port22 = new Portion();
    $para2->getPortions()->add($port20);
    $para2->getPortions()->add($port21);
    $para2->getPortions()->add($port22);
    for($i = 0; $i < 3; $i++) {
        for($j = 0; $j < 3; $j++) {
            $portion = $tf->getParagraphs()->get_Item($i)->getPortions()->get_Item($j);
            $portion->setText("Portion0" . $j);
            if ($j == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($j == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }
    # Ghi PPTX ra đĩa
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Quản Lý Đánh Dấu Đầu Đoạn**

Danh sách dấu đầu giúp bạn tổ chức và trình bày thông tin một cách nhanh chóng và hiệu quả. Các đoạn có dấu đầu luôn dễ đọc và hiểu hơn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Truy cập tham chiếu slide tương ứng thông qua chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide đã chọn.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) của auto shape.
5. Xóa đoạn mặc định trong `TextFrame`.
6. Tạo đối tượng đoạn đầu tiên bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/).
7. Đặt `Type` của dấu đầu cho đoạn là `Symbol` và đặt ký tự dấu đầu.
8. Đặt `Text` cho đoạn.
9. Đặt `Indent` cho dấu đầu.
10. Đặt màu cho dấu đầu.
11. Đặt chiều cao cho dấu đầu.
12. Thêm đoạn mới vào bộ sưu tập đoạn của `TextFrame`.
13. Thêm đoạn thứ hai và lặp lại quy trình được mô tả trong các bước 7‑13.
14. Lưu bản trình bày.

Mã PHP dưới đây cho bạn thấy cách thêm dấu đầu đoạn:

```php
# Tạo một lớp Presentation đại diện cho tệp PPTX
$pres = new Presentation();
try {
    # Truy cập slide đầu tiên
    $slide = $pres->getSlides()->get_Item(0);
    # Thêm và truy cập AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Truy cập khung văn bản của AutoShape
    $txtFrm = $aShp->getTextFrame();
    # Xóa đoạn mặc định
    $txtFrm->getParagraphs()->removeAt(0);
    # Tạo một đoạn
    $para = new Paragraph();
    # Đặt kiểu dấu đầu đoạn và ký hiệu
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Đặt văn bản cho đoạn
    $para->setText("Welcome to Aspose.Slides");
    # Đặt thụt lề dấu đầu
    $para->getParagraphFormat()->setIndent(25);
    # Đặt màu dấu đầu
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// đặt IsBulletHardColor thành true để sử dụng màu dấu đầu riêng

    # Đặt chiều cao dấu đầu
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Thêm đoạn vào khung văn bản
    $txtFrm->getParagraphs()->add($para);
    # Tạo đoạn thứ hai
    $para2 = new Paragraph();
    # Đặt loại và kiểu dấu đầu cho đoạn
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # Thêm văn bản cho đoạn
    $para2->setText("This is numbered bullet");
    # Đặt thụt lề dấu đầu
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// đặt IsBulletHardColor thành true để sử dụng màu dấu đầu riêng

    # Đặt chiều cao dấu đầu
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # Thêm đoạn vào khung văn bản
    $txtFrm->getParagraphs()->add($para2);
    # Lưu bản trình bày đã chỉnh sửa
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Quản Lý Dấu Đầu Hình Ảnh**

Danh sách dấu đầu giúp bạn tổ chức và trình bày thông tin một cách nhanh chóng và hiệu quả. Các đoạn hình ảnh dễ đọc và hiểu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Truy cập tham chiếu slide tương ứng thông qua chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) của auto shape.
5. Xóa đoạn mặc định trong `TextFrame`.
6. Tạo đối tượng đoạn đầu tiên bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/).
7. Tải hình ảnh bằng [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/).
8. Đặt loại dấu đầu thành [Picture](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bullettype/#Picture) và đặt hình ảnh.
9. Đặt `Text` cho Paragraph.
10. Đặt `Indent` cho dấu đầu.
11. Đặt màu cho dấu đầu.
12. Đặt chiều cao cho dấu đầu.
13. Thêm đoạn mới vào bộ sưu tập đoạn của `TextFrame`.
14. Thêm đoạn thứ hai và lặp lại quy trình dựa trên các bước trước.
15. Lưu bản trình bày đã chỉnh sửa.

Mã PHP dưới đây cho bạn thấy cách thêm và quản lý dấu đầu hình ảnh:

```php
# Tạo một lớp Presentation đại diện cho tệp PPTX
$presentation = new Presentation();
try {
    # Truy cập slide đầu tiên
    $slide = $presentation->getSlides()->get_Item(0);
    # Tạo đối tượng ảnh cho dấu đầu
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # Thêm và truy cập AutoShape
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Truy cập khung văn bản của AutoShape
    $textFrame = $autoShape->getTextFrame();
    # Xóa đoạn mặc định
    $textFrame->getParagraphs()->removeAt(0);
    # Tạo một đoạn mới
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # Đặt kiểu dấu đầu đoạn và hình ảnh
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Đặt chiều cao dấu đầu
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # Thêm đoạn vào khung văn bản
    $textFrame->getParagraphs()->add($paragraph);
    # Ghi bản trình bày dưới dạng tệp PPTX
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # Ghi bản trình bày dưới dạng tệp PPT
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Quản Lý Dấu Đầu Đa Cấp**

Danh sách dấu đầu giúp bạn tổ chức và trình bày thông tin một cách nhanh chóng và hiệu quả. Dấu đầu đa cấp dễ đọc và hiểu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Truy cập tham chiếu slide tương ứng thông qua chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide mới.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) của auto shape.
5. Xóa đoạn mặc định trong `TextFrame`.
6. Tạo đoạn đầu tiên bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/) và đặt độ sâu (depth) thành 0.
7. Tạo đoạn thứ hai bằng lớp `Paragraph` và đặt độ sâu thành 1.
8. Tạo đoạn thứ ba bằng lớp `Paragraph` và đặt độ sâu thành 2.
9. Tạo đoạn thứ tư bằng lớp `Paragraph` và đặt độ sâu thành 3.
10. Thêm các đoạn mới vào bộ sưu tập đoạn của `TextFrame`.
11. Lưu bản trình bày đã chỉnh sửa.

Mã PHP dưới đây cho bạn thấy cách thêm và quản lý dấu đầu đa cấp:

```php
# Tạo một lớp Presentation đại diện cho tệp PPTX
$pres = new Presentation();
try {
    # Truy cập slide đầu tiên
    $slide = $pres->getSlides()->get_Item(0);
    # Thêm và truy cập AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Truy cập khung văn bản của AutoShape đã tạo
    $text = $aShp->addTextFrame("");
    # Xóa đoạn mặc định
    $text->getParagraphs()->clear();
    # Thêm đoạn đầu tiên
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Đặt mức độ dấu đầu
    $para1->getParagraphFormat()->setDepth(0);
    # Thêm đoạn thứ hai
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Đặt mức độ dấu đầu
    $para2->getParagraphFormat()->setDepth(1);
    # Thêm đoạn thứ ba
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Đặt mức độ dấu đầu
    $para3->getParagraphFormat()->setDepth(2);
    # Thêm đoạn thứ tư
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Đặt mức độ dấu đầu
    $para4->getParagraphFormat()->setDepth(3);
    # Thêm các đoạn vào bộ sưu tập
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # Lưu bản trình bày dưới dạng tệp PPTX
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Quản Lý Đoạn Văn Với Danh Sách Đánh Số Tùy Chỉnh**

Lớp [BulletFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bulletformat/) cung cấp phương thức [setNumberedBulletStartWith](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) và các phương thức khác cho phép bạn quản lý các đoạn có đánh số hoặc định dạng tùy chỉnh.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Truy cập slide chứa đoạn.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) của auto shape.
5. Xóa đoạn mặc định trong `TextFrame`.
6. Tạo đoạn đầu tiên bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/) và đặt [NumberedBulletStartWith](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) thành 2.
7. Tạo đoạn thứ hai bằng lớp `Paragraph` và đặt `NumberedBulletStartWith` thành 3.
8. Tạo đoạn thứ ba bằng lớp `Paragraph` và đặt `NumberedBulletStartWith` thành 7.
9. Thêm các đoạn mới vào bộ sưu tập đoạn của `TextFrame`.
10. Lưu bản trình bày đã chỉnh sửa.

Mã PHP dưới đây cho bạn thấy cách thêm và quản lý các đoạn có đánh số hoặc định dạng tùy chỉnh:

```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Truy cập khung văn bản của AutoShape đã tạo
    $textFrame = $shape->getTextFrame();
    # Xóa đoạn mặc định hiện có
    $textFrame->getParagraphs()->removeAt(0);
    # Danh sách đầu tiên
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 7");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph5);
    $presentation->save("SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Đặt Thụt Lề Dòng Đầu Cho Đoạn Văn**

Sử dụng phương thức [ParagraphFormat::setIndent](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/setindent/) để kiểm soát thụt lề dòng đầu của một đoạn. Phương thức này chỉ di chuyển dòng đầu so với lề trái của đoạn. Giá trị dương đẩy dòng đầu sang phải, trong khi các dòng còn lại vẫn căn chỉnh với thân đoạn.

Sử dụng [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/setmarginleft/) khi bạn cần di chuyển toàn bộ đoạn. Sử dụng [ParagraphFormat::setIndent](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/setindent/) khi bạn chỉ muốn di chuyển dòng đầu.

Ví dụ dưới tạo một số đoạn và áp dụng các giá trị thụt lề khác nhau để minh họa cách thụt lề dòng đầu ảnh hưởng đến bố cục đoạn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Truy cập slide mục tiêu.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) hình chữ nhật vào slide.
4. Thêm một [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) trống vào hình dạng và xóa đoạn mặc định.
5. Tạo một số đoạn và đặt các giá trị [Indent](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/setindent/) khác nhau cho chúng.
6. Thêm các đoạn vào khung văn bản.
7. Lưu bản trình bày đã chỉnh sửa.

Mã này cho bạn thấy cách đặt thụt lề cho đoạn:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $thirdParagraph->getParagraphFormat()->setIndent(40.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("paragraph_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Thụt lề dòng đầu của các đoạn](first_line_indent.png)

## **Đặt Thụt Lề Treo Cho Đoạn Văn**

Thụt lề treo là bố cục đoạn trong đó dòng đầu bắt đầu bên trái các dòng còn lại. Trong Aspose.Slides, bạn tạo hiệu ứng này bằng phương thức [ParagraphFormat::setIndent](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/setindent/). Đặt thụt lề thành giá trị âm để di chuyển dòng đầu sang trái so với thân đoạn.

Trong thực tế, [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/setmarginleft/) xác định vị trí trái của thân đoạn, và [ParagraphFormat::setIndent](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/setindent/) xác định vị trí của dòng đầu so với lề đó. Để tạo thụt lề treo, đặt giá trị `MarginLeft` dương và giá trị `Indent` âm.

Định dạng này hữu ích cho các mục thư mục, tài liệu tham khảo, mục từ điển và các đoạn khác nơi các dòng gói phải căn dưới thân đoạn thay vì dưới ký tự đầu tiên của dòng đầu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Truy cập slide mục tiêu.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) hình chữ nhật vào slide.
4. Thêm một [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) trống vào hình dạng và xóa đoạn mặc định.
5. Tạo các đoạn và đặt giá trị `MarginLeft` dương cho mỗi đoạn.
6. Đặt giá trị `Indent` âm để tạo hiệu ứng thụt lề treo.
7. Thêm các đoạn vào khung văn bản.
8. Lưu bản trình bày đã chỉnh sửa.

Mã này cho bạn thấy cách đặt thụt lề treo cho đoạn:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(60.0);
    $secondParagraph->getParagraphFormat()->setIndent(-30.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("hanging_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Thụt lề treo của các đoạn](hanging_indent.png)

## **Quản Lý Thuộc Tính Kết Thúc Đoạn (End Paragraph Run Properties)**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Lấy tham chiếu cho slide chứa đoạn thông qua vị trí của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) hình chữ nhật vào slide.
1. Thêm một [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) có hai đoạn vào hình chữ nhật.
1. Đặt chiều cao phông chữ và kiểu Font cho các đoạn.
1. Đặt các thuộc tính End cho các đoạn.
1. Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Mã PHP này cho bạn thấy cách đặt thuộc tính End cho các đoạn trong PowerPoint:

```php
$pres = new Presentation();
try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Sample text"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("Sample text 2"));
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(48);
    $portionFormat::setLatinFont(new FontData("Times New Roman"));
    $para2->setEndParagraphPortionFormat($portionFormat);
    $shape->getTextFrame()->getParagraphs()->add($para1);
    $shape->getTextFrame()->getParagraphs()->add($para2);
    $pres->save($resourcesOutputPath . "pres.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Nhập Văn Bản HTML Vào Đoạn Văn**

Aspose.Slides cung cấp hỗ trợ cải tiến cho việc nhập văn bản HTML vào các đoạn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Truy cập tham chiếu slide tương ứng thông qua chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
4. Thêm và truy cập [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) của `AutoShape`.
5. Xóa đoạn mặc định trong `TextFrame`.
6. Đọc tệp HTML nguồn bằng một TextReader.
7. Tạo đoạn đầu tiên bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/).
8. Thêm nội dung tệp HTML đã đọc từ TextReader vào [ParagraphCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphcollection/) của TextFrame.
9. Lưu bản trình bày đã chỉnh sửa.

Mã PHP này là triển khai các bước để nhập văn bản HTML vào các đoạn:

```php
# Tạo một thể hiện trình chiếu trống
$pres = new Presentation();
try {
    # Truy cập slide đầu tiên mặc định của trình chiếu
    $slide = $pres->getSlides()->get_Item(0);
    # Thêm AutoShape để chứa nội dung HTML
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # Thêm khung văn bản vào hình dạng
    $ashape->addTextFrame("");
    # Xóa tất cả các đoạn trong khung văn bản đã thêm
    $ashape->getTextFrame()->getParagraphs()->clear();
    # Tải tệp HTML bằng stream reader
    $tr = new StreamReader("file.html");
    # Thêm văn bản từ stream reader HTML vào khung văn bản
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # Lưu trình chiếu
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Xuất Văn Bản Đoạn Sang HTML**

Aspose.Slides cung cấp hỗ trợ cải tiến cho việc xuất văn bản (có trong các đoạn) sang HTML.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) và tải bản trình bày mong muốn.
2. Truy cập tham chiếu slide tương ứng thông qua chỉ mục của nó.
3. Truy cập hình dạng chứa văn bản sẽ được xuất sang HTML.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) của hình dạng.
5. Tạo một thể hiện của `StreamWriter` và thêm tệp HTML mới.
6. Cung cấp chỉ mục bắt đầu cho StreamWriter và xuất các đoạn mong muốn.

Mã PHP này cho bạn thấy cách xuất văn bản các đoạn PowerPoint sang HTML:

```php
# Tải tệp trình chiếu
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # Truy cập slide đầu tiên mặc định của trình chiếu
    $slide = $pres->getSlides()->get_Item(0);
    # Chỉ mục mong muốn
    $index = 0;
    # Truy cập hình dạng đã thêm
    $ashape = $slide->getShapes()->get_Item($index);
    # Tạo tệp HTML đầu ra
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # Trích xuất đoạn đầu tiên dưới dạng HTML
    # Ghi dữ liệu các đoạn vào HTML bằng cách cung cấp chỉ mục bắt đầu đoạn, tổng số đoạn cần sao chép
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Lưu Đoạn Văn Như Hình Ảnh**

Trong phần này, chúng ta sẽ khám phá hai ví dụ minh họa cách lưu một đoạn văn bản, được đại diện bởi lớp [Paragraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/), dưới dạng hình ảnh. Cả hai ví dụ đều bao gồm việc lấy hình ảnh của một hình dạng chứa đoạn bằng các phương thức `getImage` từ lớp [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/), tính toán phạm vi của đoạn trong hình dạng, và xuất nó dưới dạng ảnh bitmap. Các cách tiếp cận này cho phép bạn trích xuất các phần cụ thể của văn bản từ bản trình bày PowerPoint và lưu chúng dưới dạng hình ảnh riêng biệt, hữu ích cho việc sử dụng trong các kịch bản khác nhau.

Giả sử chúng ta có một tệp trình bày có tên sample.pptx với một slide, trong đó hình dạng đầu tiên là một hộp văn bản chứa ba đoạn.

![Hộp văn bản với ba đoạn](paragraph_to_image_input.png)

**Ví dụ 1**

Trong ví dụ này, chúng ta lấy đoạn thứ hai dưới dạng hình ảnh. Để thực hiện, chúng ta trích xuất hình ảnh của hình dạng từ slide đầu tiên của bản trình bày, sau đó tính toán phạm vi của đoạn thứ hai trong khung văn bản của hình dạng. Đoạn sau đó được vẽ lại lên một bitmap mới, được lưu dưới dạng PNG. Phương pháp này đặc biệt hữu ích khi bạn cần lưu một đoạn cụ thể dưới dạng hình ảnh riêng biệt trong khi vẫn giữ nguyên kích thước và định dạng của văn bản.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Lưu hình dạng vào bộ nhớ dưới dạng bitmap.
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Tạo bitmap cho hình dạng từ bộ nhớ.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Tính toán giới hạn của đoạn thứ hai.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // Tính toán tọa độ và kích thước cho ảnh đầu ra (kích thước tối thiểu - 1x1 pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Cắt bitmap hình dạng để chỉ lấy bitmap của đoạn.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Kết quả:

![Hình ảnh đoạn văn](paragraph_to_image_output.png)

**Ví dụ 2**

Trong ví dụ này, chúng ta mở rộng cách tiếp cận trước bằng cách thêm các yếu tố tỷ lệ cho hình ảnh đoạn. Hình dạng được trích xuất từ bản trình bày và lưu dưới dạng hình ảnh với hệ số tỷ lệ `2`. Điều này cho phép xuất ra hình ảnh có độ phân giải cao hơn. Phạm vi của đoạn sau đó được tính toán có xét tới tỷ lệ. Việc tỷ lệ hoá có thể đặc biệt hữu ích khi cần một hình ảnh chi tiết hơn, ví dụ cho tài liệu in chất lượng cao.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Lưu hình dạng vào bộ nhớ dưới dạng bitmap có tỷ lệ.
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Tạo bitmap cho hình dạng từ bộ nhớ.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Tính toán giới hạn của đoạn thứ hai.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // Tính toán tọa độ và kích thước cho ảnh đầu ra (kích thước tối thiểu - 1x1 pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Cắt bitmap hình dạng để chỉ lấy bitmap của đoạn.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Câu Hỏi Thường Gặp (FAQ)**

**Tôi có thể tắt hoàn toàn việc ngắt dòng trong một khung văn bản không?**

Có. Sử dụng cài đặt ngắt dòng của khung văn bản ([setWrapText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/setwraptext/)) để tắt ngắt dòng, vì vậy các dòng sẽ không bị ngắt ở cạnh khung.

**Làm sao tôi có thể lấy vị trí chính xác của một đoạn cụ thể trên slide?**

Bạn có thể truy xuất hình chữ nhật bao quanh của đoạn (và thậm chí của một phần riêng lẻ) để biết vị trí và kích thước chính xác của nó trên slide.

**Vị trí căn chỉnh đoạn (trái/phải/giữa/đều) được kiểm soát ở đâu?**

[Alignment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/setalignment/) là một cài đặt cấp đoạn trong [ParagraphFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/); nó áp dụng cho toàn bộ đoạn bất kể định dạng của các phần riêng lẻ.

**Tôi có thể đặt ngôn ngữ kiểm tra chính tả cho một phần của đoạn (ví dụ, một từ) không?**

Có. Ngôn ngữ được đặt ở mức độ phần ([PortionFormat::setLanguageId](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#setLanguageId)), vì vậy có thể có nhiều ngôn ngữ tồn tại trong cùng một đoạn.