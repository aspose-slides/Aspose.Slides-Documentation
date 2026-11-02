---
title: Quản lý Liên kết Siêu Văn Bản Bản Trình Bày trong PHP
linktitle: Quản lý Liên kết
type: docs
weight: 20
url: /vi/php-java/manage-hyperlinks/
keywords:
- thêm URL
- thêm liên kết siêu văn bản
- tạo liên kết siêu văn bản
- định dạng liên kết siêu văn bản
- xóa liên kết siêu văn bản
- cập nhật liên kết siêu văn bản
- liên kết siêu văn bản văn bản
- liên kết siêu văn bản slide
- liên kết siêu văn bản hình dạng
- liên kết siêu văn bản hình ảnh
- liên kết siêu văn bản video
- liên kết siêu văn bản có thể thay đổi
- PowerPoint
- OpenDocument
- bản trình bày
- PHP
- Aspose.Slides
description: "Thêm, định dạng, cập nhật và xóa liên kết siêu văn bản trong các bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho PHP qua Java, sử dụng các ví dụ PHP."
---
## **Giới thiệu**

Liên kết siêu văn bản kết nối nội dung bản trình bày với một trang web hoặc một vị trí trong bản trình bày. Trong PowerPoint, liên kết siêu văn bản thường phục vụ hai mục đích:

* Mở một trang web từ văn bản, hình dạng hoặc khung phương tiện.
* Điều hướng đến một slide khác, ví dụ, từ mục lục.

Aspose.Slides for PHP via Java cho phép bạn thêm các liên kết này, kiểm soát giao diện và âm thanh của chúng, cập nhật các thuộc tính và xóa chúng. Các ví dụ dưới đây cho thấy cách làm việc với liên kết siêu văn bản trên các yếu tố riêng lẻ và cách truy cập liên kết siêu văn bản ở mức bản trình bày, slide hoặc khung văn bản. Chúng giả định rằng PHP/Java Bridge và wrapper Aspose.Slides cho PHP đã được khởi tạo. Các thành viên API không có trang tham chiếu PHP sẽ liên kết đến API Java nền.

{{% alert color="info" title="Note" %}}
Bạn cũng có thể chỉnh sửa bản trình bày với [trình chỉnh sửa PowerPoint trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **Thêm Liên Kết URL**

Bạn có thể gán một URL website cho văn bản, hình dạng hoặc khung phương tiện. Phần tử mà bạn gán liên kết siêu văn bản quyết định khu vực có thể nhấp: một phần văn bản sẽ liên kết văn bản đã chọn, trong khi một hình dạng hoặc khung sẽ liên kết đối tượng slide.

Đối với các bản trình bày chứa liên kết siêu văn bản tương đối, xem [Quản lý Cơ Sở Liên Kết Siêu Văn Bản](/slides/vi/php-java/presentation-properties/#manage-the-hyperlink-base) để đọc, thay đổi hoặc xóa cơ sở cấp tài liệu.

### **Thêm Liên Kết URL vào Văn Bản**

Để liên kết văn bản với một trang web, truyền một [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) vào phương thức [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/sethyperlinkclick/) của phần văn bản, như được minh họa bên dưới. Chỉ phần văn bản đó sẽ trở nên có thể nhấp.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $textShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $textShape->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");
    $portionFormat->setFontHeight(32);

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Thêm Liên Kết URL vào Hình Dạng và Khung Phương Tiện**

Để làm cho một hình dạng hoặc khung có thể nhấp, gọi phương thức [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/shape/sethyperlinkclick/) của nó. Liên kết siêu văn bản thuộc về đối tượng đó chứ không phải một phần văn bản bên trong.

Cùng một cách tiếp cận áp dụng cho khung ảnh, âm thanh và video: gán liên kết siêu văn bản vào khung và gọi [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) nếu cần.

Ví dụ sau làm cho một hình chữ nhật có thể nhấp:

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Sử Dụng Liên Kết Siêu Văn Bản Để Tạo Mục Lục**

Liên kết nội bộ cho phép độc giả nhảy từ mục lục đến một slide cụ thể. Ví dụ sau sử dụng [setInternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) để liên kết văn bản “Page 2” trên slide đầu tiên tới slide thứ hai.

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $tableOfContents = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $tableOfContents->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getTextFrame()->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");

    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);

    $paragraph->getPortions()->add($linkPortion);
    $tableOfContents->getTextFrame()->getParagraphs()->add($paragraph);

    $presentation->save("link_to_slide.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Định Dạng Liên Kết Siêu Văn Bản**

### **Màu**

Phương thức [setColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setcolorsource/) của [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) xác định liệu liên kết siêu văn bản có sử dụng màu liên kết của bản trình bày hay định dạng của phần văn bản. Để áp dụng màu văn bản tùy chỉnh, chọn [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkcolorsource/) và đặt màu nền cho phần. Tính năng này được giới thiệu trong PowerPoint 2019; các phiên bản cũ hơn không áp dụng cài đặt này.

Ví dụ sau thêm hai liên kết siêu văn bản vào cùng một slide. Liên kết đầu tiên sử dụng màu nền văn bản đỏ, trong khi liên kết thứ hai giữ màu liên kết mặc định.

```php
use aspose\slides\FillType;
use aspose\slides\Hyperlink;
use aspose\slides\HyperlinkColorSource;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $coloredShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $coloredShape->addTextFrame("This hyperlink uses a custom color.");
    $coloredPortionFormat = $coloredShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $coloredPortionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $coloredPortionFormat->getHyperlinkClick()->setColorSource(HyperlinkColorSource::PortionFormat);
    $coloredPortionFormat->getFillFormat()->setFillType(FillType::Solid);
    $coloredPortionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $defaultShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $defaultShape->addTextFrame("This hyperlink uses the default color.");
    $defaultShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    $presentation->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
### **Âm Thanh**

Một liên kết siêu văn bản có thể phát âm thanh khi được kích hoạt hoặc dừng âm thanh đang phát. Sử dụng các phương thức sau để cấu hình các hành vi này:

- [Hyperlink::setSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setsound/) chỉ định âm thanh liên quan đến liên kết siêu văn bản.
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setstopsoundonclick/) kiểm soát việc kích hoạt liên kết siêu văn bản có dừng âm thanh trước đó hay không.

#### **Thêm Âm Thanh cho Liên Kết Siêu Văn Bản**

Ví dụ sau tải `sampleaudio.wav` và gán nó với một nút trên slide đầu tiên. Nhấp vào nút sẽ phát âm thanh và chuyển sang slide tiếp theo. Một hình dạng thứ hai trên slide đó sẽ dừng âm thanh trước khi nhấp, mà không thực hiện hành động điều hướng.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $audioFile = new Java("java.io.File", "sampleaudio.wav");
    $audioPath = $audioFile->toPath();
    $audioData = java("java.nio.file.Files")->readAllBytes($audioPath);
    $hyperlinkSound = $presentation->getAudios()->addAudio($audioData);

    $firstSlide = $presentation->getSlides()->get_Item(0);

    $playButton = $firstSlide->getShapes()->addAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
    $playButton->setHyperlinkClick(Hyperlink::getNextSlide());

    if (!java_values($playButton->getHyperlinkClick()->getStopSoundOnClick()) && java_is_null($playButton->getHyperlinkClick()->getSound()))
    {
        $playButton->getHyperlinkClick()->setSound($hyperlinkSound);
    }

    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $stopButton = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
    $stopButton->setHyperlinkClick(Hyperlink::getNoAction());

    $stopButton->getHyperlinkClick()->setStopSoundOnClick(true);

    $presentation->save("hyperlink-sound.pptx", SaveFormat::Pptx);
} catch (JavaException $exception) {
    echo "Unable to read the audio file: " . $exception->getMessage() . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

#### **Trích Xuất Âm Thanh từ Liên Kết Siêu Văn Bản**

Ví dụ sau mở bản trình bày đã tạo ở trên và đọc âm thanh liên kết siêu văn bản của hình dạng đầu tiên vào bộ nhớ thông qua [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getsound/) và [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/).

```php
use aspose\slides\Presentation;

$presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0 && java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) > 0) {
        $hyperlink = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getHyperlinkClick();
        $sound = java_is_null($hyperlink) ? null : $hyperlink->getSound();
        if (!java_is_null($sound)) {
            $audioData = $sound->getBinaryData();
            echo "Extracted " . strlen(java_values($audioData)) . " bytes of hyperlink audio." . PHP_EOL;
        } else {
            echo "The first shape has no hyperlink sound." . PHP_EOL;
        }
    } else {
        echo "The presentation has no first slide or shape to inspect." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Cài Đặt Tooltip và Tương Tác**

Bạn có thể gọi các phương thức [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) sau khi đã gán một liên kết siêu văn bản cho văn bản hoặc hình dạng:

- [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) thiết lập văn bản mà người xem có thể hiển thị như một gợi ý cho liên kết.
- [setTargetFrame](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settargetframe/) chỉ định khung đích trong một frameset HTML cha, nếu áp dụng.
- [setHistory](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethistory/) kiểm soát việc kích hoạt liên kết có thêm đích đến của nó vào danh sách các liên kết đã xem hay không.
- [setHighlightClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethighlightclick/) kiểm soát việc liên kết có được làm nổi bật khi nhấp hay không.

## **Xóa Liên Kết Siêu Văn Bản khỏi Bản Trình Bày**

Sử dụng [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) để thu thập các container liên kết siêu văn bản, bao gồm các liên kết phần văn bản, trước khi thay đổi chúng. Ví dụ sau xóa cả hai loại kích hoạt khỏi slide đầu tiên. Để xóa chỉ một loại, gọi chỉ [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) hoặc [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/); việc xóa hành động nhấp không xóa phần đối ứng khi di chuột qua.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0) {
        $containers = [];
        foreach ($presentation->getSlides()->get_Item(0)->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $containers[] = $container;
        }
        foreach ($containers as $container) {
            $container->getHyperlinkManager()->removeHyperlinkClick();
            $container->getHyperlinkManager()->removeHyperlinkMouseOver();
        }
        $presentation->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
    } else {
        echo "The presentation has no slides to process." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Đối với việc xóa vô điều kiện, [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) sẽ xóa cả hai loại kích hoạt trong phạm vi đã chọn chỉ bằng một lần gọi. Đối với việc dọn dẹp có chọn lọc và bao phủ các master, layout và ghi chú, xem [Báo Cáo, Làm Sạch và Xác Minh Liên Kết Siêu Văn Bản](#report-sanitize-and-verify-hyperlinks).

## **Xây Dựng Danh Mục Liên Kết Siêu Văn Bản Đầy Đủ**

Trước khi phân phối một bản trình bày, hãy kiểm kê các hành động tương tác cũng như các liên kết web của nó. [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) trả về các đối tượng [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/), không phải một danh sách phẳng các chuỗi URL. Kiểm tra cả [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) và [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) trên mỗi container. Chúng độc lập: cùng một container có thể bật cả hai hành động, vì vậy một báo cáo đầy đủ có thể cần tới hai hàng cho mỗi container.

Việc quét chỉ các liên kết siêu văn bản ở mức hình dạng có thể bỏ sót các liên kết gắn vào phần văn bản. Thay vào đó, truy vấn phạm vi thích hợp và giữ lại các container trả về để bạn có thể cập nhật hoặc xóa các hành động của chúng sau này.

### **Truy Vấn Các Phạm Vi Bản Trình Bày, Slide và Khung Văn Bản**

Lớp [HyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/) có sẵn thông qua [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) và [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/gethyperlinkqueries/). Mỗi phạm vi hỗ trợ cùng các truy vấn:

- [getHyperlinkClicks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) trả về các container có hành động nhấp.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) trả về các container có hành động di chuột qua.
- [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) trả về các container có một hoặc cả hai hành động.

Ví dụ sau tạo tệp `hyperlink-audit-input.pptx` với một liên kết nhấp ngoài, một liên kết di chuột qua tệp, điều hướng slide nội bộ, một liên kết di chuột qua văn bản và một hành động macro. Nó không thực hiện bất kỳ hành động nào trong số này. Cùng ba truy vấn hoạt động ở mọi phạm vi; số lượng mô tả các container, không phải tổng hành động. Phạm vi khung văn bản loại trừ các liên kết của hình dạng bao quanh.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function printQueryCounts($scope, $queries) {
    $clickCount = java_values($queries->getHyperlinkClicks()->size());
    $mouseOverCount = java_values($queries->getHyperlinkMouseOvers()->size());
    $anyCount = java_values($queries->getAnyHyperlinks()->size());
    echo "$scope: click=$clickCount, mouse-over=$mouseOverCount, any=$anyCount" . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addEmptySlide($slide->getLayoutSlide());
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Click the text to go to slide 2");
    $shape->getHyperlinkManager()->setExternalHyperlinkClick("https://example.com/");
    $shape->getHyperlinkClick()->setTooltip("Public website");
    $shape->getHyperlinkManager()->setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    $portionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->getHyperlinkManager()->setInternalHyperlinkClick($destination);
    $portionFormat->getHyperlinkManager()->setExternalHyperlinkMouseOver("https://example.com/help");
    $macroButton = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
    $macroButton->getHyperlinkManager()->setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", $presentation->getHyperlinkQueries());
    printQueryCounts("Slide 1", $slide->getHyperlinkQueries());
    printQueryCounts("Text frame", $shape->getTextFrame()->getHyperlinkQueries());
    $presentation->save("hyperlink-audit-input.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Đối với ví dụ này, các truy vấn bản trình bày và slide mỗi báo cáo ba container nhấp, hai container di chuột qua và ba container có một trong các hành động. Truy vấn khung văn bản báo cáo một container trong mỗi danh mục.

### **Phân Loại Hành Động và Đích Đến**

Sử dụng [Hyperlink::getActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getactiontype/) để giải thích một hành động trước khi giải thích đích đến của nó. Các giá trị [HyperlinkActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkactiontype/) bao gồm hơn chỉ điều hướng web:

| Giá trị | Ý nghĩa cho kiểm toán |
| --- | --- |
| `Hyperlink` | Liên kết siêu văn bản bên ngoài; kiểm tra URL và sơ đồ của nó. |
| `JumpSpecificSlide` | Điều hướng nội bộ tới một slide cụ thể. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Điều hướng trình chiếu tích hợp sẵn, được giải quyết trong ngữ cảnh trình chiếu. |
| `JumpEndShow`, `StartCustomSlideShow` | Kết thúc buổi trình chiếu hiện tại hoặc bắt đầu một buổi trình chiếu tùy chỉnh. |
| `StartMacro` | Thực thi macro. |
| `StartProgram` | Khởi chạy một chương trình. |
| `OpenFile`, `OpenPresentation` | Mở một tệp hoặc một bản trình bày khác; xem xét riêng biệt so với URL web. |
| `StartStopMedia` | Bắt đầu hoặc dừng phát phương tiện. |
| `NoAction`, `Unknown` | Không có hành động điều hướng, hoặc một hành động không xác định cần được xem xét. |

Đọc các đích đến bên ngoài từ [getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) và các đích đến nội bộ cụ thể từ [getTargetSlide](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettargetslide/). Các hành động nội bộ và lệnh tích hợp sẵn có thể không có URL bên ngoài; một URL trống không có nghĩa là container không có hành động. Giữ lại giá trị trả về bởi [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) khi nó khác với URL đã chuẩn hoá, và bao gồm tooltip trả về bởi [getTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettooltip/) nếu có.

### **Báo Cáo, Làm Sạch và Xác Minh Liên Kết Siêu Văn Bản**

Ví dụ PHP sau đọc một bản trình bày hiện có (sử dụng tệp đã tạo ở trên), ghi `hyperlink-audit.json`, áp dụng một chính sách, lưu `hyperlink-sanitized.pptx`, và mở lại nó để kiểm tra lại cả hai loại kích hoạt. Nó thu thập các container trước khi thay đổi chúng và sử dụng so sánh tham chiếu để tránh xử lý cùng một container hai lần. Các truy vấn bản trình bày bao phủ các slide thông thường; để có một kiểm kê toàn bộ gói, nó cũng truy vấn rõ ràng các master, layout, ghi chú và các master ghi chú và handout khi có.

Báo cáo ghi lại chỉ mục slide bắt đầu từ 1 và [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--) nếu có. [ISlideComponent::getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) cung cấp slide sở hữu cho các container được hỗ trợ. Các master, layout và ghi chú không có chỉ mục slide thông thường và được xác định bằng phạm vi của chúng. Các container hình dạng và các container định dạng phần văn bản được gắn nhãn riêng; các loại container khác giữ tên kiểu thời gian chạy của chúng. Mỗi container nhận một ID cục bộ trong báo cáo để hai hành động của nó có thể được liên kết. Báo cáo lưu trữ các loại hành động dưới dạng các hằng số nguyên được định nghĩa bởi enum PHP.

Chính sách ứng dụng có mục đích hạn chế này chỉ cho phép các URL HTTPS tuyệt đối và các đích slide nội bộ hợp lệ. Nó từ chối macro, chương trình, hành động tệp, các hành động trình chiếu khác, hành động không xác định và các scheme URL khác. Những từ chối này là quyết định chính sách, không phải một phán quyết an toàn của Aspose.Slides. Chỉ có HTTPS không đủ để thiết lập niềm tin: hãy thêm danh sách cho phép máy chủ và các kiểm tra khác cho ứng dụng của bạn. Cả URL bên ngoài gốc và đã chuẩn hoá đều được kiểm tra. Ví dụ này kiểm toán siêu dữ liệu mà không theo dõi các liên kết hay thực thi hành động.

Để khắc phục, [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) của container hỗ trợ [setExternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) và [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/). Ở đây, các liên kết nhấp ngoài bị cấm được thay thế bằng một trang đích HTTPS cố định; các nhấp bị cấm khác và các hành động di chuột qua bị cấm được xóa độc lập. Đặt `$replaceExternalClicks` thành `false` để xóa tất cả các vi phạm chính sách. Chọn một trang thay thế do ứng dụng sở hữu trước khi triển khai.

Cờ xuất khẩu của báo cáo sử dụng một chính sách kiểm tra PDF thận trọng: đánh dấu các hành động di chuột qua và bất kỳ thứ gì khác ngoài một liên kết ngoài hoặc chuyển slide cụ thể là có khả năng không được hỗ trợ. Đây là một gợi ý kiểm tra, không phải một thử nghiệm khả năng hay bảo đảm rằng các liên kết không được đánh dấu sẽ tồn tại sau khi xuất. Các xuất khẩu PDF [PDF](/slides/vi/php-java/convert-powerpoint-to-pdf/) và HTML [HTML](/slides/vi/php-java/convert-powerpoint-to-html/) được hỗ trợ có thể giữ lại các liên kết siêu văn bản, tùy thuộc vào hành động, tùy chọn xuất và trình xem. Các [hình ảnh](/slides/vi/php-java/convert-powerpoint-to-png/) và [video](/slides/vi/php-java/convert-powerpoint-to-video/) dạng raster không thể giữ lại các liên kết siêu văn bản tương tác; hãy đánh dấu mọi hành động khi kiểm toán cho các đầu ra đó.

```php
use aspose\slides\HyperlinkActionType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class HyperlinkAudit {
    public function slideIndex($presentation, $slide) {
        if (java_is_null($slide)) return null;
        for ($index = 0; $index < java_values($presentation->getSlides()->size()); $index++) {
            if (java_values($presentation->getSlides()->get_Item($index)->equals($slide))) return $index + 1;
        }
        return null;
    }

    public function isHttps($value) {
        if ($value === null || $value === '') return false;
        $parts = parse_url($value);
        return $parts !== false && isset($parts['scheme'], $parts['host']) && strcasecmp($parts['scheme'], 'https') === 0 && $parts['host'] !== '';
    }

    public function policyViolation($link) {
        if (java_is_null($link)) return null;
        $action = java_values($link->getActionType());
        if ($action === HyperlinkActionType::JumpSpecificSlide) {
            return java_is_null($link->getTargetSlide()) ? 'Missing target slide' : null;
        }
        if ($action !== HyperlinkActionType::Hyperlink) return 'Action is not allowed';
        if (!$this->isHttps(java_values($link->getExternalUrl()))) return 'Normalized URL is not absolute HTTPS';
        $original = java_values($link->getExternalUrlOriginal());
        if ($original !== null && $original !== '' && !$this->isHttps($original)) return 'Original URL is not absolute HTTPS';
        return null;
    }

    public function addScope(&$found, $slide) {
        if (!java_is_null($slide)) {
            foreach ($slide->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
                $found[] = $container;
            }
        }
    }

    public function collectContainers($presentation) {
        $found = [];
        foreach ($presentation->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $found[] = $container;
        }
        $masters = $presentation->getMasters();
        for ($index = 0; $index < java_values($masters->size()); $index++) {
            $this->addScope($found, $masters->get_Item($index));
        }
        $layouts = $presentation->getLayoutSlides();
        for ($index = 0; $index < java_values($layouts->size()); $index++) {
            $this->addScope($found, $layouts->get_Item($index));
        }
        $slides = $presentation->getSlides();
        for ($index = 0; $index < java_values($slides->size()); $index++) {
            $this->addScope($found, $slides->get_Item($index)->getNotesSlideManager()->getNotesSlide());
        }
        $this->addScope($found, $presentation->getMasterNotesSlideManager()->getMasterNotesSlide());
        $this->addScope($found, $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide());
        $seen = new Java('java.util.IdentityHashMap');
        $unique = [];
        foreach ($found as $container) {
            if (!java_values($seen->containsKey($container))) {
                $seen->put($container, true);
                $unique[] = $container;
            }
        }
        return $unique;
    }

    public function addRow(&$rows, $presentation, $link, $activation, $container, $containerId) {
        if (java_is_null($link)) return;
        $ownerSlide = java_instanceof($container, java('com.aspose.slides.ISlideComponent')) ? $container->getSlide() : null;
        $targetSlide = $link->getTargetSlide();
        $violation = $this->policyViolation($link);
        $ownerType = java_instanceof($container, java('com.aspose.slides.IShape')) ? 'Shape' : (java_instanceof($container, java('com.aspose.slides.IPortionFormat')) ? 'Text portion' : java_values($container->getClass()->getSimpleName()));
        $action = java_values($link->getActionType());
        $ordinaryAction = $action === HyperlinkActionType::Hyperlink || $action === HyperlinkActionType::JumpSpecificSlide;
        $externalUrl = java_values($link->getExternalUrl());
        $originalUrl = java_values($link->getExternalUrlOriginal());
        $rows[] = [
            'ContainerId' => $containerId,
            'SlideIndex' => $this->slideIndex($presentation, $ownerSlide),
            'SlideId' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getSlideId()),
            'Scope' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getClass()->getSimpleName()),
            'OwnerType' => $ownerType,
            'Activation' => $activation,
            'ActionType' => $action,
            'ExternalUrl' => $externalUrl,
            'TargetSlideIndex' => $this->slideIndex($presentation, $targetSlide),
            'TargetSlideId' => java_is_null($targetSlide) ? null : java_values($targetSlide->getSlideId()),
            'Tooltip' => java_values($link->getTooltip()),
            'OriginalExternalUrl' => $originalUrl === $externalUrl ? null : $originalUrl,
            'PotentiallyUnsafe' => $violation !== null,
            'PolicyViolation' => $violation,
            'TargetExport' => 'PDF',
            'PotentiallyUnsupportedByExport' => $activation === 'mouse-over' || !$ordinaryAction
        ];
    }
}

$replaceExternalClicks = true;
$replacementUrl = 'https://example.com/blocked-link';
$audit = new HyperlinkAudit();
$presentation = new Presentation('hyperlink-audit-input.pptx');
try {
    $containers = $audit->collectContainers($presentation);
    $rows = [];
    foreach ($containers as $index => $container) {
        $audit->addRow($rows, $presentation, $container->getHyperlinkClick(), 'click', $container, $index + 1);
        $audit->addRow($rows, $presentation, $container->getHyperlinkMouseOver(), 'mouse-over', $container, $index + 1);
    }
    $json = json_encode($rows, JSON_PRETTY_PRINT | JSON_UNESCAPED_SLASHES);
    if ($json === false) {
        echo 'Unable to encode the audit report: ' . json_last_error_msg() . PHP_EOL;
    } elseif (file_put_contents('hyperlink-audit.json', $json . PHP_EOL) === false) {
        echo 'Unable to write the audit report.' . PHP_EOL;
    } else {
        foreach ($containers as $container) {
            $click = $container->getHyperlinkClick();
            if ($audit->policyViolation($click) !== null) {
                if ($replaceExternalClicks && java_values($click->getActionType()) === HyperlinkActionType::Hyperlink) {
                    $container->getHyperlinkManager()->setExternalHyperlinkClick($replacementUrl);
                } else {
                    $container->getHyperlinkManager()->removeHyperlinkClick();
                }
            }
            if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) {
                $container->getHyperlinkManager()->removeHyperlinkMouseOver();
            }
        }
        $presentation->save('hyperlink-sanitized.pptx', SaveFormat::Pptx);

        $reopened = new Presentation('hyperlink-sanitized.pptx');
        try {
            $remainingContainers = $audit->collectContainers($reopened);
            $violations = 0;
            foreach ($remainingContainers as $container) {
                if ($audit->policyViolation($container->getHyperlinkClick()) !== null) $violations++;
                if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) $violations++;
            }
            echo 'Audit rows: ' . count($rows) . '; prohibited actions after reopening: ' . $violations . PHP_EOL;
            if ($violations !== 0) {
                echo 'Verification failed: do not distribute the saved presentation.' . PHP_EOL;
            }
        } finally {
            $reopened->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

Với đầu vào được tạo ở trên, báo cáo chứa năm hàng hành động. Liên kết di chuột qua tệp và nhấp macro bị xóa, trong khi các liên kết HTTPS và điều hướng slide nội bộ vẫn còn. Việc xác minh in ra không có hành động bị cấm. Một đầu vào chứa URL nhấp ngoài bị cấm cũng sẽ thực thi nhánh thay thế. Một container có nhấp cho phép và di chuột qua bị cấm sẽ giữ lại hành động nhấp.

Việc dọn dẹp có chọn lọc này khác với [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/), vốn xóa cả hai loại kích hoạt trong toàn bộ phạm vi đã chọn bất kể chính sách. Việc xác minh ở đây chỉ kiểm tra các hành động liên kết siêu văn bản; nó không xóa các dự án VBA nhúng, đối tượng OLE hoặc nội dung hoạt động khác, và không xác thực tệp PDF hoặc HTML đã xuất.

## **Câu Hỏi Thường Gặp**

**Làm thế nào tôi có thể liên kết tới một phần hoặc slide đầu tiên của nó?**

Các phần trong PowerPoint nhóm các slide, nhưng một liên kết nội bộ nhắm tới một slide riêng lẻ. Để tạo điều hướng tới một phần, hãy liên kết tới slide đầu tiên trong phần đó.

**Tôi có thể gắn liên kết siêu văn bản vào các yếu tố của slide master để nó hoạt động trên tất cả các slide không?**

Có. Các yếu tố slide master và layout hỗ trợ liên kết siêu văn bản. Các liên kết trên những yếu tố này khả dụng trong chế độ trình chiếu trên các slide sử dụng master hoặc layout tương ứng.

**Liên kết siêu văn bản có được giữ lại khi xuất ra PDF, HTML, hình ảnh hoặc video không?**

Các xuất khẩu PDF và HTML được hỗ trợ có thể giữ lại các liên kết siêu văn bản; hình ảnh raster và video không thể. Xem các lưu ý xuất khẩu trong [Báo Cáo, Làm Sạch và Xác Minh Liên Kết Siêu Văn Bản](#report-sanitize-and-verify-hyperlinks).