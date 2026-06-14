---
title: Trích xuất văn bản nâng cao từ bản trình chiếu trong PHP
linktitle: Trích xuất văn bản
type: docs
weight: 90
url: /vi/php-java/extract-text-from-presentation/
keywords:
- trích xuất văn bản
- trích xuất văn bản từ slide
- trích xuất văn bản từ bản trình chiếu
- trích xuất văn bản từ PowerPoint
- trích xuất văn bản từ OpenDocument
- trích xuất văn bản từ PPT
- trích xuất văn bản từ PPTX
- trích xuất văn bản từ ODP
- lấy văn bản
- lấy văn bản từ slide
- lấy văn bản từ bản trình chiếu
- lấy văn bản từ PowerPoint
- lấy văn bản từ OpenDocument
- lấy văn bản từ PPT
- lấy văn bản từ PPTX
- lấy văn bản từ ODP
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Nhanh chóng trích xuất văn bản từ các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho PHP qua Java. Thực hiện theo hướng dẫn đơn giản, từng bước của chúng tôi để tiết kiệm thời gian."
---
## **Tổng quan**

Việc trích xuất văn bản từ các bản trình chiếu là một nhiệm vụ phổ biến nhưng quan trọng đối với các nhà phát triển làm việc với nội dung slide. Dù bạn đang xử lý các tệp Microsoft PowerPoint ở định dạng PPT hoặc PPTX, hay các bản trình chiếu OpenDocument (ODP), việc truy cập và lấy dữ liệu văn bản có thể là chìa khóa cho việc phân tích, tự động hoá, lập chỉ mục hoặc di chuyển nội dung.

Bài viết này cung cấp hướng dẫn toàn diện về cách hiệu quả để trích xuất văn bản từ các định dạng bản trình chiếu khác nhau, bao gồm PPT, PPTX và ODP, bằng Aspose.Slides for PHP via Java. Bạn sẽ học cách duyệt qua các phần tử của bản trình chiếu một cách có hệ thống để lấy đúng nội dung văn bản mà bạn cần.

## **Trích xuất văn bản từ một slide**

Aspose.Slides for PHP via Java cung cấp lớp [SlideUtil](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideutil/) . Lớp này cung cấp một số phương thức tĩnh được overload để trích xuất toàn bộ văn bản từ một bản trình chiếu hoặc một slide. Để trích xuất văn bản từ một slide trong bản trình chiếu, sử dụng phương thức [getAllTextBoxes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideutil/#getAllTextBoxes). Phương thức này nhận một đối tượng kiểu [BaseSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseslide/) làm tham số. Khi được thực thi, phương thức sẽ quét toàn bộ slide để tìm văn bản và trả về một mảng các đối tượng kiểu [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/), giữ nguyên bất kỳ định dạng văn bản nào.

Đoạn mã sau trích xuất toàn bộ văn bản từ slide đầu tiên của bản trình chiếu:

```php
$slideIndex = 0;

$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $slide = $presentation->getSlides()->get_Item($slideIndex);

    $textFrames = SlideUtil::getAllTextBoxes($slide);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Trích xuất văn bản từ một bản trình chiếu**

Để quét văn bản từ toàn bộ bản trình chiếu, sử dụng phương thức tĩnh [getAllTextFrames](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideutil/#getAllTextFrames) được cung cấp bởi lớp [SlideUtil](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideutil/). Phương thức này nhận hai tham số:

1. Đầu tiên, một đối tượng [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) đại diện cho một bản trình chiếu PowerPoint hoặc OpenDocument mà từ đó văn bản sẽ được trích xuất.
1. Thứ hai, một giá trị `boolean` chỉ ra liệu các slide mẫu có nên được bao gồm khi quét văn bản từ bản trình chiếu hay không.

Phương thức trả về một mảng các đối tượng kiểu [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/), bao gồm thông tin định dạng văn bản. Đoạn mã dưới đây quét văn bản và các chi tiết định dạng từ một bản trình chiếu, bao gồm cả các slide mẫu.

```php
$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $includeMasterSlides = true;
    $textFrames = SlideUtil::getAllTextFrames($presentation, $includeMasterSlides);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Trích xuất văn bản có phân loại và nhanh chóng**

Lớp [PresentationFactory](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationfactory/) cũng cung cấp các phương thức để trích xuất toàn bộ văn bản từ các bản trình chiếu:

```php
PresentationText getPresentationText(String, int);
PresentationText getPresentationText(InputStream, int);
PresentationText getPresentationText(InputStream, int, LoadOptions);
```

Đối số enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textextractionarrangingmode/) chỉ ra chế độ sắp xếp kết quả trích xuất văn bản và có thể được đặt thành các giá trị sau:
- `Unarranged` - Văn bản thô mà không xét tới vị trí của nó trên slide.
- `Arranged` - Văn bản được sắp xếp theo cùng thứ tự như trên slide.

Chế độ không sắp xếp có thể được sử dụng khi tốc độ là yếu tố quan trọng; nó nhanh hơn chế độ sắp xếp.

[PresentationText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationtext/) đại diện cho văn bản thô được trích xuất từ bản trình chiếu. Phương thức `getSlidesText` của nó trả về một mảng các đối tượng, trong đó mỗi đối tượng đại diện cho văn bản trên slide tương ứng. Mỗi đối tượng trả về có các phương thức sau:

- `getText` - Văn bản trong các hình dạng của slide.
- `getMasterText` - Văn bản trong các hình dạng của slide mẫu liên quan tới slide này.
- `getLayoutText` - Văn bản trong các hình dạng của slide bố cục liên quan tới slide này.
- `getNotesText` - Văn bản trong các hình dạng của slide ghi chú liên quan tới slide này.
- `getCommentsText` - Văn bản trong các bình luận liên quan tới slide này.

```php
$presentationPath = "presentation.ppt";
$arrangingMode = TextExtractionArrangingMode::Unarranged;
$presentationText = PresentationFactory::getInstance()->getPresentationText($presentationPath, $arrangingMode);
$slidesText = $presentationText->getSlidesText();
$firstSlideText = $slidesText[0];

echo($firstSlideText->getText());
echo($firstSlideText->getLayoutText());
echo($firstSlideText->getMasterText());
echo($firstSlideText->getNotesText());
echo($firstSlideText->getCommentsText());
```

## **Câu hỏi thường gặp**

**Aspose.Slides xử lý các bản trình chiếu lớn nhanh như thế nào khi trích xuất văn bản?**

Aspose.Slides được tối ưu hoá cho hiệu năng cao và có thể xử lý ngay cả [large presentations](/slides/vi/php-java/open-presentation/), làm cho nó phù hợp với các kịch bản xử lý thời gian thực hoặc xử lý hàng loạt.

**Aspose.Slides có thể trích xuất văn bản từ bảng và biểu đồ trong bản trình chiếu không?**

Có. Aspose.Slides có thể trích xuất văn bản từ nhiều phần tử slide, bao gồm cả bảng và các đối tượng liên quan đến biểu đồ, cho phép bạn truy cập và phân tích nội dung văn bản trong các cấu trúc trình chiếu thông thường.

**Tôi có cần giấy phép Aspose.Slides đặc biệt để trích xuất văn bản từ bản trình chiếu không?**

Bạn có thể trích xuất văn bản bằng phiên bản dùng thử miễn phí của Aspose.Slides, mặc dù nó sẽ có [certain limitations](/slides/vi/php-java/licensing/), chẳng hạn chỉ xử lý được một số lượng slide giới hạn. Để sử dụng không hạn chế và xử lý các bản trình chiếu lớn hơn, việc mua giấy phép đầy đủ được khuyến nghị.