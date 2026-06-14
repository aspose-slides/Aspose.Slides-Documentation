---
title: Tạo Trình xem Trình chiếu trong PHP
linktitle: Trình xem Trình chiếu
type: docs
weight: 50
url: /vi/php-java/presentation-viewer/
keywords:
- xem trình chiếu
- trình xem trình chiếu
- tạo trình xem trình chiếu
- xem PPT
- xem PPTX
- xem ODP
- PowerPoint
- OpenDocument
- trình chiếu
- PHP
- Aspose.Slides
description: "Tạo một trình xem trình chiếu tùy chỉnh bằng Aspose.Slides cho PHP qua Java. Dễ dàng hiển thị các tệp PowerPoint và OpenDocument mà không cần Microsoft PowerPoint."
---
## **Giới thiệu**

Aspose.Slides cho PHP qua Java được sử dụng để tạo tệp trình chiếu với các slide. Các slide này có thể được xem bằng cách mở trình chiếu trong Microsoft PowerPoint, ví dụ. Tuy nhiên, đôi khi các nhà phát triển cần xem các slide dưới dạng hình ảnh trong trình xem ảnh ưa thích của mình hoặc tạo trình xem trình chiếu riêng. Trong những trường hợp như vậy, Aspose.Slides cho phép bạn xuất một slide cá nhân dưới dạng hình ảnh. Bài viết này mô tả cách thực hiện.

## **Tạo ảnh SVG từ một Slide**

Để tạo ảnh SVG từ một slide trong bản trình chiếu bằng Aspose.Slides, vui lòng làm theo các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Lấy tham chiếu slide theo chỉ mục của nó.
1. Mở một luồng tệp.
1. Lưu slide dưới dạng ảnh SVG vào luồng tệp.

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream);
$svgStream->close();

$presentation->dispose();
```

## **Tạo SVG với ID Hình dạng Tùy chỉnh**

Aspose.Slides có thể được sử dụng để tạo một [SVG](https://docs.fileformat.com/page-description-language/svg/) từ một slide với ID hình dạng tùy chỉnh. Để thực hiện, sử dụng phương thức `setId` từ [SvgShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` có thể được dùng để đặt ID hình dạng.

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(0), null, java("com.aspose.slides.ISvgShapeFormattingController"));

$svgOptions = new SVGOptions();
$svgOptions->setShapeFormattingController($shapeFormattingController);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream, $svgOptions);
$svgStream->close();

$presentation->dispose();
```
```php
class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    public function __construct($shapeStartIndex) {
        $this->m_shapeIndex = $shapeStartIndex;
    }

    public function formatShape($svgShape, $shape) {
        $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
}
```

## **Tạo ảnh Thu nhỏ Slide**

Aspose.Slides giúp bạn tạo ảnh thu nhỏ của các slide. Để tạo ảnh thu nhỏ của một slide bằng Aspose.Slides, vui lòng làm theo các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Lấy tham chiếu slide theo chỉ mục của nó.
1. Lấy ảnh thu nhỏ của slide đã tham chiếu ở tỷ lệ đã định nghĩa.
1. Lưu ảnh thu nhỏ ở bất kỳ định dạng ảnh nào mong muốn.

```php
$slideIndex = 0;
$scaleX = 1.0;
$scaleY = $scaleX;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($scaleX, $scaleY);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **Tạo Thu nhỏ Slide với Kích thước Do Người dùng Định nghĩa**

Để tạo ảnh thu nhỏ slide với kích thước do người dùng định nghĩa, vui lòng làm theo các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Lấy tham chiếu slide theo chỉ mục của nó.
1. Lấy ảnh thu nhỏ của slide đã tham chiếu với các kích thước đã định nghĩa.
1. Lưu ảnh thu nhỏ ở bất kỳ định dạng ảnh nào mong muốn.

```php
$slideIndex = 0;
$slideSize = new Java("java.awt.Dimension", 1200, 800);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($slideSize);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **Tạo Thu nhỏ Slide với Ghi chú Diễn giả**

Để tạo ảnh thu nhỏ của một slide với ghi chú diễn giả bằng Aspose.Slides, vui lòng làm theo các bước sau:

1. Tạo một thể hiện của lớp [RenderingOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/renderingoptions/).
1. Sử dụng phương thức `RenderingOptions.setSlidesLayoutOptions` để đặt vị trí của ghi chú diễn giả.
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Lấy tham chiếu slide theo chỉ mục của nó.
1. Lấy ảnh thu nhỏ của slide đã tham chiếu với các tùy chọn render.
1. Lưu ảnh thu nhỏ ở bất kỳ định dạng ảnh nào mong muốn.

```php
$slideIndex = 0;

$layoutingOptions = new NotesCommentsLayoutingOptions();
$layoutingOptions->setNotesPosition(NotesPositions::BottomTruncated);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutingOptions);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($renderingOptions);
$image->save("output.png", ImageFormat::Png);
$image->dispose();

$presentation->dispose();
```

## **Ví dụ Trực tiếp**

Bạn có thể thử ứng dụng miễn phí [**Aspose.Slides Viewer**](https://products.aspose.app/slides/vi/viewer/) để xem những gì bạn có thể triển khai với API Aspose.Slides:

![Trình xem PowerPoint trực tuyến](online-PowerPoint-viewer.png)

## **Câu hỏi Thường gặp**

**Tôi có thể nhúng trình xem trình chiếu vào một ứng dụng web không?**

Có. Bạn có thể sử dụng Aspose.Slides phía máy chủ để render các slide dưới dạng hình ảnh hoặc HTML và hiển thị chúng trong trình duyệt. Các tính năng điều hướng và phóng to/thu nhỏ có thể được triển khai bằng JavaScript để tạo trải nghiệm tương tác.

**Cách tốt nhất để hiển thị các slide trong trình xem tùy chỉnh là gì?**

Cách tiếp cận được đề xuất là render mỗi slide dưới dạng hình ảnh (ví dụ: PNG hoặc SVG) hoặc chuyển đổi nó sang HTML bằng Aspose.Slides, sau đó hiển thị kết quả trong một picture box (đối với desktop) hoặc trong một container HTML (đối với web).

**Làm thế nào để tôi xử lý các trình chiếu lớn với nhiều slide?**

Đối với các bộ sưu tập lớn, hãy xem xét việc tải lười (lazy-loading) hoặc render slide khi có yêu cầu. Điều này có nghĩa là chỉ tạo nội dung của một slide khi người dùng chuyển đến nó, giảm bộ nhớ và thời gian tải.