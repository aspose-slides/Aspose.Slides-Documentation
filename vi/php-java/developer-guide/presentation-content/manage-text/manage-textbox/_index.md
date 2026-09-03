---
title: Quản lý Hộp Văn Bản trong Bản Trình Chiếu bằng PHP
linktitle: Quản lý Hộp Văn Bản
type: docs
weight: 20
url: /vi/php-java/manage-textbox/
keywords:
- hộp văn bản
- khung văn bản
- thêm văn bản
- cập nhật văn bản
- tạo hộp văn bản
- kiểm tra hộp văn bản
- thêm cột văn bản
- thêm siêu liên kết
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tạo, xác định, định dạng và cập nhật các hộp văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng cách sử dụng Aspose.Slides cho PHP thông qua Java."
---
## **Giới thiệu**

Trong Aspose.Slides cho PHP qua Java, văn bản trên slide được lưu trong các khung văn bản (text frame) thuộc về các hình dạng. Lớp [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) đại diện cho hình dạng mang văn bản phổ biến nhất và cung cấp văn bản của nó thông qua phương thức [AutoShape::getTextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}
Mỗi auto shape kế thừa từ [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/), nhưng không phải mọi shape đều là auto shape hoặc hỗ trợ khung văn bản. Khi xử lý một bản trình chiếu hiện có, hãy sử dụng `java_instanceof` để kiểm tra xem một shape có phải là [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) trước khi truy cập văn bản của nó.
{{% /alert %}}

## **Tạo Hộp Văn Bản trên Slide**

Để tạo một hộp văn bản, thêm một auto shape vào slide, thêm văn bản vào khung văn bản của nó và lưu bản trình chiếu. Ví dụ sau tạo một hộp văn bản hình chữ nhật:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
    $textBox->addTextFrame("Aspose TextBox");

    $presentation->save("TextBox.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Các tọa độ và kích thước truyền vào [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/#addAutoShape) được đo bằng điểm. [AutoShape::addTextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/#addTextFrame) khởi tạo khung văn bản với văn bản được cung cấp.

## **Kiểm Tra Hình Dạng Hộp Văn Bản**

Sử dụng phương thức [AutoShape::isTextBox](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/#isTextBox) để xác định liệu một auto shape có được coi là hộp văn bản hay không. Điều này hữu ích khi một bản trình chiếu chứa cả các auto shape mang văn bản và các auto shape chỉ là đồ họa.

![Một hộp văn bản và một hình dạng](istextbox.png)

Ví dụ sau kiểm tra mọi auto shape trong một bản trình chiếu:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
    $textBox->addTextFrame("Text box");
    $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $currentSlide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($currentSlide->getShapes()->size()); $shapeIndex++) {
            $shape = $currentSlide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $autoShapeClass)) {
                echo (java_is_true($shape->isTextBox()) ? "The shape is a text box." : "The shape is not a text box.") . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Một auto shape mới được thêm vào không được coi là hộp văn bản cho đến khi nó chứa văn bản không rỗng. Bạn có thể cung cấp văn bản đó thông qua [AutoShape::addTextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/#addTextFrame) hoặc [TextFrame::setText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#setText). Thêm hoặc gán một chuỗi rỗng sẽ khiến [AutoShape::isTextBox](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/#isTextBox) trả về `false`:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
    $shape1->addTextFrame("Shape 1");
    echo (java_is_true($shape1->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
    $shape2->getTextFrame()->setText("Shape 2");
    echo (java_is_true($shape2->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
    $shape3->addTextFrame("");
    echo (java_is_true($shape3->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
    $shape4->getTextFrame()->setText("");
    echo (java_is_true($shape4->isTextBox()) ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Hai lời gọi đầu tiên in ra `true`; hai lời gọi cuối in ra `false`.

## **Tìm Kiếm Hình Dạng Sở Hữu Khung Văn Bản**

Mã xử lý văn bản chung có thể nhận một [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) mà không biết đối tượng trình chiếu nào chứa nó. Sử dụng phương thức chỉ đọc [TextFrame::getParentShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#getParentShape) để điều hướng trở lại [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/) sở hữu nó.

Đối với một khung văn bản được sở hữu bởi một auto shape hoặc một hình dạng mang văn bản khác, [TextFrame::getParentShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#getParentShape) trả về chủ sở hữu và [TextFrame::getParentCell](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#getParentCell) trả về `null`. Kiểm tra giá trị trả về bằng `java_is_null` trước khi truy cập. Để xác định cả chủ sở hữu hình dạng và ô bảng, bao gồm các hình dạng liên kết với nút SmartArt, xem [Search and Replace Text](/slides/vi/php-java/search-and-replace-text/).

## **Thêm Cột vào Hộp Văn Bản**

Phương thức [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/#setColumnCount) chia khung văn bản thành các cột, trong khi [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/#setColumnSpacing) đặt khoảng cách giữa các cột tính bằng điểm. Cả hai cài đặt này thuộc về [TextFrameFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/) và có thể thay đổi thông qua khung văn bản của một hộp văn bản hiện có. Văn bản được luồng lại giữa các cột trong cùng một hình dạng; nó sẽ không tiếp tục sang hình dạng khác.

Ví dụ sau tạo một hộp văn bản ba cột với 10 điểm giữa các cột, lưu bản trình chiếu và đọc lại các cài đặt đã lưu từ tệp đầu ra:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
    $textBox->addTextFrame("This text is distributed automatically across all columns in the text box.");

    $textFrameFormat = $textBox->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setColumnCount(3);
    $textFrameFormat->setColumnSpacing(10);

    $presentation->save("TextBoxColumns.pptx", SaveFormat::Pptx);

    $savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        $savedTextBox = $savedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedFormat = $savedTextBox->getTextFrame()->getTextFrameFormat();
        echo "Columns: " . java_values($savedFormat->getColumnCount()) . "; spacing: " . java_values($savedFormat->getColumnSpacing()) . " points" . PHP_EOL;
    } finally {
        $savedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Trích Xuất Văn Bản từ Các Cột Riêng Lẻ**

Sử dụng [TextFrame::splitTextByColumns](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#splitTextByColumns) để lấy văn bản được gán cho mỗi cột hiển thị trong một khung văn bản hiện có. Phương thức trả về một chuỗi cho mỗi cột, theo thứ tự đọc dựa trên cột. Một khung văn bản một cột tạo ra một mảng có một phần tử, và một cột trống được biểu diễn bằng một chuỗi rỗng. Các chuỗi chỉ chứa văn bản thuần; định dạng ở mức phần không được giữ lại.

Điều này hữu ích khi bạn cần:
- Trích xuất văn bản đồng thời giữ nguyên thứ tự đọc dựa trên cột.
- Lập chỉ mục hoặc so sánh nội dung của các slide đa cột.
- Xuất mỗi cột ra một tệp riêng, trường cơ sở dữ liệu, hoặc đích khác.
- Kiểm tra cách văn bản được phân phối lại sau khi thay đổi số cột bằng [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/#setColumnCount), khoảng cách bằng [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/#setColumnSpacing), phông chữ hoặc kích thước khung văn bản.

Phương thức báo cáo văn bản được phân phối trong [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) hiện tại; nó không tự động luồng văn bản giữa các hình dạng hoặc hộp văn bản riêng biệt. Việc phân phối cột có thể phụ thuộc vào các phông chữ khả dụng và các cài đặt bố cục văn bản khác, vì vậy hãy chắc chắn rằng các phông chữ cần thiết có sẵn khi kết quả nhất quán là quan trọng.

Ví dụ sau tải một bản trình chiếu, tìm auto shape đa cột đầu tiên có khung văn bản, đọc số cột đã cấu hình và ghi văn bản từ mỗi cột ra một tệp riêng. Các hình dạng không cung cấp khung văn bản sẽ bị bỏ qua.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("MultiColumnText.pptx");
try {
    $textBox = null;
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (java_instanceof($shape, $autoShapeClass)) {
            $textFrame = $shape->getTextFrame();
            if (!java_is_null($textFrame)) {
                $columnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
                if ($columnCount > 1) {
                    $textBox = $shape;
                    break;
                }
            }
        }
    }

    if ($textBox === null) {
        echo "No multi-column text frame was found." . PHP_EOL;
    } else {
        $textFrame = $textBox->getTextFrame();
        $configuredColumnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
        $columnTexts = java_values($textFrame->splitTextByColumns());

        echo "Configured columns: " . $configuredColumnCount . PHP_EOL;

        foreach ($columnTexts as $columnIndex => $columnText) {
            $columnNumber = $columnIndex + 1;
            echo "Column " . $columnNumber . ": " . $columnText . PHP_EOL;
            $outputPath = "Column-" . $columnNumber . ".txt";
            $bytesWritten = file_put_contents($outputPath, $columnText);
            if ($bytesWritten === false) {
                echo "Could not write column " . $columnNumber . " to " . $outputPath . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Cập Nhật Văn Bản**

Để cập nhật văn bản trên toàn bộ bản trình chiếu, lặp qua các slide và hình dạng, chọn các auto shape, sau đó chỉnh sửa các phần văn bản của chúng. Làm việc ở mức phần cho phép bạn thay đổi cả văn bản và định dạng ký tự.

Ví dụ sau thay thế mọi lần xuất hiện của `years` bằng `months` trong văn bản auto-shape và làm cho mỗi phần bị ảnh hưởng trở nên in đậm:

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Text.pptx");
try {
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $text = java_values($portion->getText());
                    if ($text !== null && strpos($text, "years") !== false) {
                        $updatedText = str_replace("years", "months", $text);
                        $portion->setText($updatedText);
                        $portion->getPortionFormat()->setFontBold(NullableBool::True);
                    }
                }
            }
        }
    }

    $presentation->save("TextChanged.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Việc duyệt này chỉ cập nhật văn bản trong các auto shape. Văn bản được lưu trong bảng, biểu đồ, SmartArt hoặc các hình dạng được nhóm yêu cầu duyệt các bộ sưu tập riêng của các đối tượng đó.

## **Thêm Hộp Văn Bản với Siêu Liên Kết**

Một siêu liên kết có thể được gán cho một phần văn bản cụ thể, vì vậy chỉ phần văn bản đó hoạt động như liên kết có thể nhấp. Sử dụng [HyperlinkManager::setExternalHyperlinkClick](https://reference.aspose.com/slides/vi/php-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) để liên kết phần đó với một URL bên ngoài.

Ví dụ sau tạo văn bản có liên kết và lưu nó vào một bản trình chiếu:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
    $textBox->addTextFrame("Aspose.Slides");

    $textPortion = $textBox->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $textPortion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://www.aspose.com/");

    $presentation->save("Hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Câu Hỏi Thường Gặp**

**Sự khác biệt giữa hộp văn bản và trình giữ chỗ văn bản trên slide master hoặc layout là gì?**

Một [trình giữ chỗ](/slides/vi/php-java/manage-placeholder/) có thể kế thừa vị trí và định dạng từ một [slide master](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslide/) hoặc [slide layout](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/). Một hộp văn bản thông thường là một hình dạng độc lập trên slide nơi nó được tạo và sẽ không nhận hành vi của trình giữ chỗ khi bố cục thay đổi.

**Làm sao tôi có thể thay thế văn bản mà không thay đổi văn bản trong biểu đồ, bảng hoặc SmartArt?**

Hạn chế việc duyệt chỉ tới các đối tượng [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) , như trong ví dụ Cập Nhật Văn Bản. Biểu đồ, bảng và SmartArt lưu văn bản trong mô hình đối tượng riêng của chúng, vì vậy chúng không bị thay đổi bởi vòng lặp đó.