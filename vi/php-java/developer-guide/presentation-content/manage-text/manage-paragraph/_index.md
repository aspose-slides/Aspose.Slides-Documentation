---
title: Quản lý các đoạn văn bản PowerPoint trong PHP
linktitle: Quản lý Đoạn văn
type: docs
weight: 40
url: /vi/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
  - /php-java/portion/
keywords:
- thêm văn bản
- thêm đoạn
- quản lý văn bản
- quản lý đoạn
- quản lý dấu đầu dòng
- thụt lề đoạn
- thụt lề treo
- dấu đầu đoạn
- danh sách đánh số
- danh sách dấu đầu dòng
- thuộc tính đoạn
- nhập HTML
- văn bản sang HTML
- đoạn sang HTML
- đoạn sang hình ảnh
- văn bản sang hình ảnh
- xuất đoạn
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tìm hiểu cách tạo và định dạng các đoạn, phần, dấu đầu dòng, danh sách đánh số, thụt lề, nội dung HTML và hình ảnh đoạn với Aspose.Slides cho PHP thông qua Java."
---
## **Tổng quan**

Aspose.Slides for PHP via Java biểu diễn văn bản dưới dạng một hệ thống phân cấp của các khung văn bản, đoạn văn và phần văn bản:

* [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) đại diện cho vùng chứa văn bản trong một hình dạng và cung cấp quyền truy cập vào bộ sưu tập đoạn văn của nó.
* [Paragraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/) đại diện cho một đoạn văn trong một khung văn bản và cung cấp quyền truy cập vào các phần và định dạng cấp độ đoạn.
* [Portion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/) đại diện cho một chuỗi văn bản trong một đoạn văn. Mỗi phần có thể có văn bản và định dạng cấp ký tự riêng.

Do đó, một đoạn văn có thể chứa văn bản với các phông chữ, màu sắc, kích thước và định dạng khác nhau bằng cách sử dụng nhiều phần.

## **Tạo và Định dạng Đoạn văn**

### **Tạo Đoạn văn với Nhiều Phần**

Các bước sau tạo một khung văn bản với ba đoạn văn, mỗi đoạn chứa ba phần:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Truy cập slide tương ứng bằng chỉ số của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) hình chữ nhật vào slide.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) của hình dạng.
5. Sử dụng đoạn văn mặc định và thêm hai đối tượng [Paragraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/) nữa vào khung văn bản.
6. Thêm đủ đối tượng [Portion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/) cho mỗi đoạn để chứa ba phần. Đoạn mặc định đã chứa một phần trống.
7. Đặt văn bản cho mỗi phần.
8. Áp dụng định dạng cấp ký tự qua [Portion::getPortionFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/#getPortionFormat--).
9. Lưu bản trình chiếu đã sửa đổi.

Ví dụ PHP này thực hiện các bước trên:

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    $textFrame = $shape->getTextFrame();

    $firstParagraph = $textFrame->getParagraphs()->get_Item(0);
    $firstParagraph->getPortions()->add(new Portion());
    $firstParagraph->getPortions()->add(new Portion());

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($thirdParagraph);

    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portion->setText("Portion " . ($paragraphIndex + 1) . "." . ($portionIndex + 1));

            if ($portionIndex == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($portionIndex == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }

    $presentation->save("paragraphs_with_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tạo Danh sách Dấu đầu dòng và Đánh số**

### **Tạo Danh sách Dấu đầu dòng hoặc Đánh số**

Dấu đầu dòng và đánh số giúp người đọc nhanh chóng quét các mục liên quan. Trong Aspose.Slides, cài đặt danh sách được xác định qua [BulletFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bulletformat/).

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Truy cập slide tương ứng bằng chỉ số của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide đã chọn.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) của hình dạng.
5. Xóa đoạn văn mặc định khỏi khung văn bản.
6. Tạo một [Paragraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/) cho dấu đầu dòng ký hiệu.
7. Đặt [BulletFormat::setType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bulletformat/#setType-int-) thành [BulletType::Symbol](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bullettype/) và chỉ định ký tự dấu đầu dòng.
8. Đặt văn bản đoạn, thụt lề, màu sắc dấu đầu và chiều cao dấu đầu.
9. Thêm đoạn vào khung văn bản.
10. Tạo đoạn thứ hai và đặt [BulletFormat::setType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bulletformat/#setType-int-) thành [BulletType::Numbered](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bullettype/).
11. Cấu hình kiểu dấu đầu dòng đánh số và thêm đoạn vào khung văn bản.
12. Lưu bản trình chiếu.

Ví dụ PHP này tạo một dấu đầu dòng ký hiệu và một dấu đầu dòng đánh số:

```php
use aspose\slides\BulletType;
use aspose\slides\ColorType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $symbolParagraph = new Paragraph();
    $symbolParagraph->setText("Welcome to Aspose.Slides");
    $symbolParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $symbolParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $symbolParagraph->getParagraphFormat()->setIndent(25);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $symbolParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $symbolParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($symbolParagraph);

    $numberedParagraph = new Paragraph();
    $numberedParagraph->setText("This is a numbered item");
    $numberedParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $numberedParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
    $numberedParagraph->getParagraphFormat()->setIndent(25);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $numberedParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $numberedParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($numberedParagraph);

    $presentation->save("bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Sử dụng Dấu đầu Dòng Hình ảnh**

Dấu đầu dòng hình ảnh cho phép bạn dùng một hình ảnh tùy chỉnh thay cho ký hiệu hoặc số.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Truy cập slide tương ứng bằng chỉ số của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) và truy cập [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) của nó.
4. Xóa đoạn văn mặc định khỏi khung văn bản.
5. Tải hình ảnh dấu đầu và thêm nó vào bộ sưu tập hình ảnh của bản trình chiếu dưới dạng [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/).
6. Tạo một [Paragraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/) và đặt văn bản cho nó.
7. Đặt [BulletFormat::setType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bulletformat/#setType-int-) thành [BulletType::Picture](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bullettype/).
8. Gán hình ảnh qua [BulletFormat::getPicture](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bulletformat/#getPicture--) và đặt chiều cao dấu đầu.
9. Thêm đoạn vào khung văn bản.
10. Lưu bản trình chiếu đã sửa đổi.

Ví dụ PHP này tạo một dấu đầu dòng hình ảnh:

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $bulletImage = Images::fromFile("bullets.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($bulletImage);
    } finally {
        $bulletImage->dispose();
    }

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($presentationImage);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($paragraph);

    $presentation->save("picture_bullet.pptx", SaveFormat::Pptx);
    $presentation->save("picture_bullet.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

### **Tạo Danh sách Đa cấp**

Đặt [ParagraphFormat::setDepth](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#setDepth-short-) để đặt các đoạn ở các mức độ khác nhau của một danh sách. Mức cấp cao nhất có độ sâu `0`.

1. Tạo một [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) và truy cập một slide.
2. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) và xóa đoạn mặc định khỏi khung văn bản của nó.
3. Tạo bốn đoạn và cấu hình các ký hiệu dấu đầu cho chúng.
4. Đặt giá trị [ParagraphFormat::setDepth](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#setDepth-short-) thành `0`, `1`, `2` và `3`.
5. Thêm các đoạn vào khung văn bản và lưu bản trình chiếu.

Ví dụ PHP này tạo một danh sách dấu đầu dòng bốn cấp:

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Content");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $firstParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setDepth(0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Second level");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $secondParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setDepth(1);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Third level");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $thirdParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setDepth(2);

    $fourthParagraph = new Paragraph();
    $fourthParagraph->setText("Fourth level");
    $fourthParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $fourthParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $fourthParagraph->getParagraphFormat()->setDepth(3);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);
    $textFrame->getParagraphs()->add($fourthParagraph);

    $presentation->save("multilevel_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Bắt đầu Các Mục Đánh số tại Giá trị Tùy chỉnh**

Sử dụng [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) để đặt số ban đầu hiển thị cho một đoạn đánh số.

1. Tạo một [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) và thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào một slide.
2. Xóa đoạn mặc định khỏi khung văn bản của hình dạng.
3. Tạo ba đoạn đánh số.
4. Đặt [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/vi/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) thành `2`, `3` và `7` cho các đoạn tương ứng.
5. Thêm các đoạn vào khung văn bản và lưu bản trình chiếu.

Ví dụ PHP này gán một số bắt đầu tùy chỉnh cho mỗi đoạn:

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Start at 2");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $firstParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $textFrame->getParagraphs()->add($firstParagraph);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Start at 3");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $secondParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Start at 7");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $thirdParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("custom_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kiểm soát Bố cục Đoạn và Thuộc tính Kết thúc**

### **Đặt Thụt Lề Dòng Đầu**

Sử dụng [ParagraphFormat::setIndent](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#setIndent-float-) để kiểm soát thụt lề dòng đầu của một đoạn. Phương thức này chỉ di chuyển dòng đầu tiên so với lề trái của đoạn. Giá trị dương đẩy dòng đầu sang phải, trong khi các dòng còn lại vẫn giữ căn lề của phần thân đoạn.

Sử dụng [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) khi bạn cần di chuyển toàn bộ đoạn. Sử dụng [ParagraphFormat::setIndent](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#setIndent-float-) khi bạn chỉ muốn di chuyển dòng đầu.

Ví dụ dưới đây tạo một số đoạn và áp dụng các giá trị khác nhau của [ParagraphFormat::setIndent](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#setIndent-float-) để minh họa cách thụt lề dòng đầu ảnh hưởng đến bố cục đoạn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Truy cập slide mục tiêu.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) hình chữ nhật vào slide.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) của hình dạng và xóa đoạn mặc định.
5. Tạo một số đoạn và đặt các giá trị khác nhau của [ParagraphFormat::setIndent](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#setIndent-float-) cho chúng.
6. Thêm các đoạn vào khung văn bản.
7. Lưu bản trình chiếu đã sửa đổi.

Đoạn PHP này cho bạn thấy cách đặt thụt lề đoạn:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
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

![Thụt dòng đầu tiên của các đoạn văn](first_line_indent.png)

### **Đặt Thụt Lề Treo**

Thụt lề treo là bố cục đoạn trong đó dòng đầu bắt đầu bên trái các dòng còn lại. Trong Aspose.Slides, bạn tạo hiệu ứng này bằng [ParagraphFormat::setIndent](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#setIndent-float-). Cung cấp một giá trị âm để di chuyển dòng đầu sang trái so với thân đoạn.

Thực tế, [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) xác định vị trí trái của thân đoạn, và [ParagraphFormat::setIndent](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#setIndent-float-) xác định vị trí của dòng đầu so với lề đó. Để tạo thụt lề treo, đặt giá trị dương cho `setMarginLeft` và giá trị âm cho `setIndent`.

Định dạng này hữu ích cho thư mục tài liệu, tham khảo, mục từ điển và các đoạn khác nơi các dòng gói phải căn dưới thân đoạn chứ không phải dưới ký tự đầu tiên của dòng đầu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Truy cập slide mục tiêu.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) hình chữ nhật vào slide.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) của hình dạng và xóa đoạn mặc định.
5. Tạo các đoạn và cung cấp một giá trị dương cho [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) cho mỗi đoạn.
6. Cung cấp một giá trị âm cho [ParagraphFormat::setIndent](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#setIndent-float-) để tạo hiệu ứng thụt lề treo.
7. Thêm các đoạn vào khung văn bản.
8. Lưu bản trình chiếu đã sửa đổi.

Đoạn PHP này cho bạn thấy cách đặt thụt lề treo cho một đoạn:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
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

![Thụt lề treo của các đoạn văn](hanging_indent.png)

### **Đặt Thuộc tính Kết thúc Đoạn**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) kiểm soát định dạng của ký tự kết thúc đoạn. Ví dụ PHP dưới đây gán kích thước phông chữ và phông Latin cho ký tự kết thúc của đoạn thứ hai:

1. Tải một [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) và truy cập một slide.
2. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) và xóa đoạn mặc định.
3. Tạo hai đoạn và thêm các phần văn bản vào chúng.
4. Tạo một [PortionFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portionformat/) cho ký tự kết thúc của đoạn thứ hai.
5. Đặt [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) và [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Gán định dạng bằng [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) và lưu bản trình chiếu.

```php
use aspose\slides\FontData;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->getPortions()->add(new Portion("Sample text"));

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion("Sample text 2"));

    $endParagraphFormat = new PortionFormat();
    $endParagraphFormat->setFontHeight(48);
    $endParagraphFormat->setLatinFont(new FontData("Times New Roman"));
    $secondParagraph->setEndParagraphPortionFormat($endParagraphFormat);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("end_paragraph_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Đếm Số Dòng Được Render**

Sử dụng [Paragraph::getLinesCount](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/#getLinesCount--) để đếm số dòng mà một đoạn chiếm sau khi bố trí văn bản, bao gồm việc gói tự động. Điều này hữu ích khi kiểm tra độ dài văn bản và bố cục trong các mẫu bản trình chiếu.

Một đoạn là một mục trong [TextFrame::getParagraphs](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#getParagraphs--), và nó có thể chiếm nhiều dòng đã render. Một ngắt dòng rõ ràng trong đoạn buộc tạo một dòng mới mà không tạo đoạn mới. Gói tự động tạo các dòng dựa trên độ rộng có sẵn mà không chèn ký tự ngắt dòng vào văn bản. Vì vậy, chỉ đếm số đoạn hoặc ký tự ngắt dòng không cho ra số dòng đã render.

Ví dụ sau tạo một hình dạng văn bản, đếm các dòng, thu hẹp hình dạng, rồi thay thế văn bản bằng chuỗi ngắn hơn. Gói được bật và autofit bị tắt để độ rộng hình dạng điều khiển việc gói mà không tự động thu nhỏ văn bản hay thay đổi kích thước hình dạng. Kích thước hình dạng tính bằng point. Cuối cùng, ví dụ thêm một đoạn nữa và tổng hợp số dòng trên khung văn bản.

```php
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    echo "Original width: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $shape->setWidth(150);
    echo "Narrower shape: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $paragraph->setText("Short text.");
    echo "Shorter text: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Another paragraph.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $textFrame->getParagraphs()->add($secondParagraph);

    $totalLineCount = 0;
    for ($i = 0; $i < java_values($textFrame->getParagraphs()->getCount()); $i++) {
        $currentParagraph = $textFrame->getParagraphs()->get_Item($i);
        $totalLineCount += java_values($currentParagraph->getLinesCount());
    }
    echo "Total lines in the text frame: " . $totalLineCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Với văn bản và các kích thước này, thu hẹp hình dạng sẽ làm tăng số dòng, trong khi thay thế bằng chuỗi ngắn sẽ giảm chúng. Các số đếm chính xác có thể thay đổi tùy thuộc vào tính sẵn có và thay thế phông chữ, kích thước phông, lề, thụt lề, gói và cài đặt autofit. Hãy sử dụng phông và cài đặt bố cục dự kiến cho môi trường đích khi kiểm tra mẫu.

Số dòng một mình không quyết định liệu văn bản có tràn khỏi vùng chứa hay không. Chiều cao khả dụng, chiều cao dòng, khoảng cách đoạn và dòng, và hành vi autofit cũng quan trọng; ngay cả một dòng duy nhất cũng có thể vượt quá chiều rộng khi tắt gói.

## **Nhập và Xuất Nội dung Đoạn**

### **Nhập Văn bản HTML vào Đoạn**

Sử dụng [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) để chuyển đổi markup HTML thành các đoạn và phần trong một khung văn bản.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Truy cập một slide và thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/).
3. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) của hình dạng và xóa đoạn mặc định.
4. Đọc tệp HTML nguồn.
5. Truyền chuỗi HTML cho [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Lưu bản trình chiếu đã sửa đổi.

Ví dụ PHP này nhập HTML vào một khung văn bản:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeWidth = java_values($presentation->getSlideSize()->getSize()->getWidth()) - 20;
    $shapeHeight = java_values($presentation->getSlideSize()->getSize()->getHeight()) - 20;
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $shapeWidth, $shapeHeight);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $html = file_get_contents("file.html");
    if ($html !== false) {
        $shape->getTextFrame()->getParagraphs()->addFromHtml($html);
        $presentation->save("html_text.pptx", SaveFormat::Pptx);
    } else {
        echo "The HTML file could not be read.";
    }
} finally {
    $presentation->dispose();
}
```

### **Xuất Văn bản Đoạn ra HTML**

Sử dụng [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) để xuất một phạm vi đã chọn của các đoạn dưới dạng HTML.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) và tải bản trình chiếu mong muốn.
2. Truy cập slide và tìm [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) chứa văn bản.
3. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) của hình dạng.
4. Gọi [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) với chỉ số đoạn bắt đầu và số đoạn cần xuất.
5. Ghi chuỗi HTML trả về vào tệp.

Ví dụ PHP này xuất tất cả các đoạn từ hình dạng văn bản đầu tiên:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ExportingHTMLText.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();
            $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), null);
            if (file_put_contents("paragraphs.html", $html) === false) {
                echo "The HTML file could not be written.";
            }
        } else {
            echo "The first shape does not contain a text frame.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

### **Render Đoạn dưới dạng Hình ảnh**

[Paragraph::getImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/#getImage--) render một đoạn riêng lẻ và trả về một [IImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/). Lưu kết quả vào tệp hoặc stream bằng [IImage::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/#save-java.lang.String-int-). Bạn không cần render toàn bộ hình dạng chứa hoặc cắt bitmap thủ công.

[Paragraph::getImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/#getImage--) có thể trả về `null` nếu đoạn không tồn tại trong bộ sưu tập cha, không có giới hạn render hợp lệ, hoặc không thể render. Kiểm tra kết quả trước khi lưu và giải phóng hình ảnh đã trả về sau khi sử dụng.

#### **Render Đoạn ở Tỷ lệ Mặc định**

Giả sử chúng ta có một tệp bản trình chiếu tên sample.pptx với một slide, trong đó hình dạng đầu tiên là một hộp văn bản chứa ba đoạn.

![Hộp văn bản với ba đoạn](paragraph_to_image_input.png)

Ví dụ PHP sau render đoạn thứ hai trong một hình dạng văn bản thường tại tỷ lệ mặc định và lưu hình ảnh trả về dưới dạng PNG. Khối `finally` đảm bảo giải phóng hình ảnh đúng cách.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame) && java_values($textFrame->getParagraphs()->getCount()) > 1) {
            $paragraph = $textFrame->getParagraphs()->get_Item(1);
            $paragraphImage = $paragraph->getImage();

            if (!java_is_null($paragraphImage)) {
                try {
                    $paragraphImage->save("paragraph.png", ImageFormat::Png);
                } finally {
                    $paragraphImage->dispose();
                }
            } else {
                echo "The paragraph could not be rendered.";
            }
        } else {
            echo "The expected paragraph was not found.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Hình ảnh đoạn](paragraph_to_image_output.png)

#### **Render Đoạn trong Ô Bảng với Tỷ lệ Phóng to**

Sử dụng overload của [Paragraph::getImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/#getImage-float-float-) chấp nhận các tham số `$scaleX` và `$scaleY` để đặt hệ số phóng to ngang và dọc. Ví dụ PHP sau tạo một bảng, render đoạn trong ô đầu tiên với độ rộng và chiều cao gấp đôi mặc định, và lưu kết quả dưới dạng PNG.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->addTable(50, 50, array(300), array(80));
    $paragraph = $table->get_Item(0, 0)->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->setText("Text in a table cell");

    $paragraphImage = $paragraph->getImage($scaleX, $scaleY);
    if (!java_is_null($paragraphImage)) {
        try {
            $paragraphImage->save("table_paragraph.png", ImageFormat::Png);
        } finally {
            $paragraphImage->dispose();
        }
    } else {
        echo "The paragraph could not be rendered.";
    }
} finally {
    $presentation->dispose();
}
```

Hệ số `1` giữ trục ở kích thước pixel mặc định. Ví dụ, `2` cho cả hai hệ số tạo ra hình ảnh có chiều rộng và chiều cao gần gấp đôi kích thước mặc định, tương đương với bốn lần số pixel. Các hệ số lớn hơn thường tạo ra văn bản sắc nét hơn cho phóng to hoặc xuất ở độ phân giải cao, nhưng cũng tăng mức sử dụng bộ nhớ và kích thước tệp. Hệ số dưới `1` tạo ra hình ảnh nhỏ hơn với ít chi tiết hơn. Sử dụng các hệ số bằng nhau để giữ tỷ lệ khung hình của đoạn; các hệ số ngang và dọc khác nhau sẽ kéo dài đầu ra một cách độc lập.

Render toàn bộ hình dạng bằng [Shape::getImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getImage--) vẫn hữu ích khi đầu ra cần bao gồm nền, viền hoặc ngữ cảnh trực quan khác của hình dạng. Đối với ảnh chỉ chứa đoạn, hãy dùng [Paragraph::getImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/#getImage--).

## **Câu hỏi thường gặp**

**Tôi có thể vô hiệu hóa hoàn toàn việc gói dòng trong một khung văn bản không?**

Có. Đặt [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/#setWrapText-byte-) để tắt gói, vì vậy các dòng sẽ không ngắt tại cạnh khung văn bản.

**Làm sao tôi có thể lấy giới hạn trên slide chính xác của một đoạn cụ thể?**

Sử dụng [Paragraph::getRect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/#getRect--) để lấy hình chữ nhật bao quanh đoạn. [Portion::getRect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/#getRect--) cung cấp giới hạn của một phần riêng lẻ.

**Nơi nào điều khiển căn chỉnh đoạn (trái, phải, giữa hoặc trải đều)?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#setAlignment-int-) là cài đặt cấp đoạn và áp dụng cho toàn bộ đoạn bất kể định dạng từng phần.

**Tôi có thể đặt ngôn ngữ kiểm tra chính tả cho một phần của đoạn không?**

Có. Đặt [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) cho các phần riêng lẻ, để một đoạn có thể chứa văn bản bằng nhiều ngôn ngữ.