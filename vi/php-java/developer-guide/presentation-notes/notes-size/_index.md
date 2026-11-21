---
title: Thay đổi kích thước và hướng trang ghi chú trong PHP
linktitle: Kích thước Trang Ghi chú
type: docs
weight: 10
url: /vi/php-java/notes-size/
keywords:
- kích thước trang ghi chú
- hướng ghi chú
- ghi chú nằm ngang
- ghi chú dọc
- kích thước handout
- PowerPoint
- bản trình chiếu
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Đọc và thay đổi kích thước trang ghi chú trong Aspose.Slides cho PHP qua Java, chuyển hướng, xác minh kích thước đã lưu, và xuất ghi chú hoặc handout sang PDF và hình ảnh."
---
## **Tổng quan**

Sử dụng [Presentation::getNotesSize](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/getnotessize/) để truy cập cài đặt trang ghi chú của bản trình chiếu. Nó trả về một đối tượng [NotesSize](https://reference.aspose.com/slides/vi/php-java/aspose.slides/notessize/) mà phương thức [setSize](https://reference.aspose.com/slides/vi/php-java/aspose.slides/notessize/setsize/) thiết lập kích thước trang. Mặc dù không thể thay thế đối tượng cài đặt, bạn có thể gán kích thước mới thông qua phương thức này.

Chiều rộng và chiều cao được chỉ định bằng **points**, với 72 points mỗi inch. Ví dụ, 900 × 600 points tương đương 12.5 × 8⅓ inch. Các cài đặt này áp dụng cho toàn bộ bản trình chiếu, không phải cho ghi chú của một slide riêng lẻ.

| Cài đặt | Mục đích |
| --- | --- |
| [Presentation::getNotesSize](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/getnotessize/) | Điều khiển kích thước trang ghi chú và kích thước trang được sử dụng cho xuất bản handout. |
| [Presentation::getSlideSize](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/getslidesize/) | Điều khiển kích thước slide bản trình chiếu thông thường thông qua [SlideSize](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidesize/). |

Thay đổi một trong hai cài đặt không tự động làm thay đổi cài đặt còn lại. Thay đổi hướng trang ghi chú cũng không xoay các slide thông thường. Xem [Slide Size](/slides/vi/php-java/slide-size/) để thay đổi kích thước slide thông thường.

Các ví dụ dưới đây sử dụng một tệp `sample.pptx` hiện có. Đối với các ví dụ xuất, hãy sử dụng một bản trình chiếu có ít nhất một slide chứa ghi chú người thuyết trình. Mỗi ví dụ có thể được chạy độc lập sau khi tải PHP/Java Bridge và wrapper Aspose.Slides cho PHP. Các giá trị số trả về từ Java được chuyển đổi sang giá trị PHP bằng `java_values` trước khi so sánh hoặc tính toán.

## **Đọc Kích Thước và Hướng Trang Ghi Chú**

Đọc chiều rộng và chiều cao và so sánh chúng để xác định hướng: trang rộng hơn là nằm ngang, trang cao hơn là dọc, và kích thước bằng nhau mô tả một trang vuông. Ví dụ này in ra kích thước thực tế bằng points, mà không giả định kích thước giấy tiêu chuẩn.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();
    $orientation = "Square";

    if (java_values($size->getWidth()) > java_values($size->getHeight())) {
        $orientation = "Landscape";
    } else if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $orientation = "Portrait";
    }

    echo "Notes page: " . java_values($size->getWidth()) . " x " . java_values($size->getHeight()) . " points" . PHP_EOL;
    echo "Orientation: " . $orientation . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Chuyển sang Nằm Ngang mà Không Thay Đổi Kích Thước Giấy**

Để chỉ thay đổi hướng, hoán đổi chiều rộng và chiều cao hiện có. Điều này giữ nguyên độ dài của cả hai mặt, kể cả khi sử dụng kích thước giấy tùy chỉnh. Điều kiện dưới đây ngăn một trang đã ở chế độ ngang bị chuyển lại thành dọc và để trang vuông không thay đổi.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();

    if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $width = java_values($size->getWidth());
        $size->setSize(java_values($size->getHeight()), $width);
        $presentation->getNotesSize()->setSize($size);
    }

    $presentation->save("landscape-notes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Đối với hướng dọc, sử dụng cùng một phép gán khi `java_values($size->getWidth()) > java_values($size->getHeight())`. Không thay thế kích thước A4 hoặc Letter trừ khi bạn cũng muốn thay đổi kích thước giấy.

## **Đặt và Xác Minh Kích Thước Trang Ghi Chú Tùy Chỉnh**

Gán cả hai kích thước cùng lúc, sau đó sử dụng [Presentation::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/save/) để ghi bản trình chiếu. Ví dụ này đặt một trang nằm ngang 900 × 600 points, lưu nó dưới dạng PPTX, và mở lại tệp đã lưu để kiểm tra các giá trị được lưu giữ. So sánh cho phép sai số 0.01 point cho các giá trị số thực; đây không phải là đảm bảo độ chính xác cho mọi định dạng tệp.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $expectedSize = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($expectedSize);

    $presentation->save("custom-notes.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom-notes.pptx");
    try {
        $actualSize = $reopened->getNotesSize()->getSize();
        $widthMatches = abs(java_values($actualSize->getWidth()) - java_values($expectedSize->getWidth())) < 0.01;
        $heightMatches = abs(java_values($actualSize->getHeight()) - java_values($expectedSize->getHeight())) < 0.01;
        $preserved = $widthMatches && $heightMatches;

        echo "Stored notes page: " . java_values($actualSize->getWidth()) . " x " . java_values($actualSize->getHeight()) . " points" . PHP_EOL;
        echo "Size preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Kết quả mong đợi là `900 x 600 points` và `Size preserved: true`. Kiểm tra một bản trình chiếu mới mở sẽ xác minh tệp đã lưu, không chỉ các cài đặt trong bộ nhớ.

## **Xuất Ghi Chú và Handout**

Kích thước trang xác định vùng có sẵn cho bố cục ghi chú hoặc handout. Chúng không tự động kích hoạt các bố cục này: cần cấu hình các tùy chọn xuất. Xuất các slide thông thường vẫn sử dụng kích thước slide.

### **Xuất Ghi Chú sang PDF và PNG**

Gán [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/notescommentslayoutingoptions/) cho [PdfOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) để bao gồm ghi chú trong PDF. Ví dụ này cũng render slide đầu tiên có ghi chú sang PNG bằng [Slide::getImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#getImage) và [RenderingOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/renderingoptions/).

Chế độ [BottomTruncated](https://reference.aspose.com/slides/vi/php-java/aspose.slides/notespositions/) giữ ghi chú trên một trang; các ghi chú không vừa có thể bị cắt ngắn. PDF sử dụng các trang 900 × 600 points. Với tỷ lệ ảnh 1 × 1 được dùng dưới đây, PNG có kích thước 900 × 600 pixel. Points mô tả hình học trang; pixel mô tả đầu ra raster, kích thước cũng phụ thuộc vào tỷ lệ render.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\RenderingOptions;
use aspose\slides\ImageFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new NotesCommentsLayoutingOptions();
    $layout->setNotesPosition(NotesPositions::BottomTruncated);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("notes.pdf", SaveFormat::Pdf, $pdfOptions);

    $renderingOptions = new RenderingOptions();
    $renderingOptions->setSlidesLayoutOptions($layout);

    $image = $presentation->getSlides()->get_Item(0)->getImage($renderingOptions, 1, 1);
    try {
        $image->save("first-slide-notes.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Đối với xuất PDF với ghi chú dài, [BottomFull](https://reference.aspose.com/slides/vi/php-java/aspose.slides/notespositions/) cho phép tạo thêm trang khi cần. Không sử dụng chế độ này với lời gọi hình ảnh một slide duy nhất ở trên, vì không hỗ trợ. Sau khi thay đổi kích thước, kiểm tra đầu ra để xem ghi chú bị cắt và vị trí của các đối tượng notes‑master hiện có; chỉ thay đổi kích thước trang không nên được coi là bảo đảm mọi nội dung sẽ vừa. Xem [Convert PowerPoint to PDF with Notes](/slides/vi/php-java/convert-powerpoint-to-pdf-with-notes/) để biết thêm về xuất ghi chú.

### **Xuất Handout sang PDF**

Sử dụng [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/handoutlayoutingoptions/) để có nhiều hình thu nhỏ slide trên một trang. Ví dụ sau đặt một trang 900 × 600 points và sử dụng [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/vi/php-java/aspose.slides/handouttype/) để sắp xếp tối đa bốn slide mỗi trang. Cài đặt ngang kiểm soát thứ tự slide; hướng trang được lấy từ chiều rộng và chiều cao.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PdfOptions;
use aspose\slides\HandoutLayoutingOptions;
use aspose\slides\HandoutType;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new HandoutLayoutingOptions();
    $layout->setHandout(HandoutType::Handouts4Horizontal);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("handouts.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Thay đổi kích thước trang thay đổi vùng có sẵn cho lưới handout mà không thay đổi kích thước các slide nguồn. Đối với ảnh handout, sử dụng [Presentation::getImages](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/getimages/) với bố cục handout, thay vì phương thức ảnh của slide riêng lẻ. Trong Aspose.Slides, việc render handout ở mức bản trình chiếu sử dụng kích thước trang ghi chú, trong khi lời gọi ảnh slide riêng lẻ không tạo trang handout. Xem [Handout Mode](/slides/vi/php-java/convert-powerpoint-in-handout-mode/) để biết các tùy chọn bố cục.

## **Kích Thước Trang trong Trình Xem, Xuất và In**

- **Trình xem bản trình chiếu:** Trình xem có thể hiển thị hoặc in ghi chú theo quy tắc bố cục riêng của nó. Nếu một ứng dụng khác lưu tệp, hãy mở lại và kiểm tra kích thước lại; quá trình chuyển đổi định dạng của ứng dụng đó có thể chuẩn hoá chúng.
- **Định dạng xuất:** Các ví dụ PDF ghi chú và handout ở trên sử dụng kích thước trang đã cấu hình. Ảnh raster sử dụng kích thước pixel nguyên và tỷ lệ render, vì vậy các giá trị points thập phân có thể được làm tròn trong đầu ra ảnh. Xuất các slide thông thường không áp dụng kích thước trang ghi chú.
- **Trình điều khiển máy in:** Lựa chọn giấy, xoay tự động và cài đặt vừa trang có thể thay đổi kết quả in thực tế mà không thay đổi kích thước lưu trong bản trình chiếu hoặc PDF. Đối với một kích thước giấy cụ thể, hãy điều chỉnh cài đặt máy in và kiểm tra bản xem trước khi in.

## **Câu Hỏi Thường Gặp**

**Tôi có thể đặt kích thước ghi chú cho chỉ một slide không?**

Kích thước trang ghi chú là cài đặt ở mức bản trình chiếu. Các slide riêng lẻ có thể có nội dung ghi chú khác nhau, nhưng thuộc tính này không cung cấp kích thước trang riêng cho từng slide.

**Tại sao việc thay đổi hướng ghi chú không làm thay đổi các slide của tôi?**

Các trang ghi chú và các slide thông thường có kích thước độc lập. Sử dụng cài đặt kích thước slide thông thường khi bạn muốn thay đổi kích thước của các slide.

**Tại sao kết quả đã lưu hoặc in của tôi có kích thước khác?**

Đầu tiên, mở lại bản trình chiếu đã lưu và so sánh kích thước ghi chú. Nếu chúng đã thay đổi, kiểm tra xem việc lưu hoặc chuyển đổi tệp trong một ứng dụng khác có thay đổi cài đặt trang hay không. Nếu không, kiểm tra bố cục xuất, tỷ lệ ảnh, cài đặt trình xem và lựa chọn giấy máy in.