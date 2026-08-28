---
title: "Chuyển đổi các slide trình chiếu sang ảnh trong PHP"
linktitle: "Slide sang ảnh"
type: docs
weight: 35
url: /vi/php-java/convert-slide/
keywords:
- "chuyển đổi slide"
- "xuất slide"
- "slide sang ảnh"
- "lưu slide dưới dạng ảnh"
- "slide sang EMF"
- "slide sang PNG"
- "slide sang JPEG"
- "slide sang bitmap"
- "slide sang TIFF"
- "PowerPoint"
- "OpenDocument"
- "bản trình bày"
- "PHP"
- "Aspose.Slides"
description: "Chuyển đổi các slide từ bản trình bày PPT, PPTX và ODP sang PNG, JPEG, GIF, TIFF, EMF và các định dạng ảnh khác trong PHP với Aspose.Slides."
---
## **Giới thiệu**

Aspose.Slides for PHP via Java có thể render các slide riêng lẻ từ các bản trình bày PowerPoint và OpenDocument dưới dạng PNG, JPEG, GIF, TIFF và các định dạng ảnh khác.

Để chuyển đổi một slide thành hình ảnh, thực hiện các bước sau:

1. Tải bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Chọn slide bạn muốn render.
3. Nếu cần, cấu hình render bằng lớp [RenderingOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/renderingoptions/) hoặc [TiffOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/).
4. Gọi phương thức [Slide::getImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#getImage). Nó trả về một đối tượng [IImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/).
5. Gọi phương thức [IImage::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/#save) và chỉ định định dạng đầu ra bằng một giá trị [ImageFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imageformat/).

## **Chuyển đổi một Slide thành ảnh PNG**

Cách chuyển đổi đơn giản nhất sử dụng cài đặt render mặc định. Đối tượng [IImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/) tạo ra có thể được xử lý trong bộ nhớ hoặc lưu vào tệp.

Ví dụ PHP sau render slide đầu tiên và lưu nó dưới dạng ảnh PNG:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage();
    try {
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Chuyển đổi các Slide thành ảnh với kích thước tùy chỉnh**

Sử dụng phương thức overload của [Slide::getImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#getImage) chấp nhận một giá trị [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) để render slide với kích thước pixel chính xác.

Ví dụ sau tạo ảnh JPEG kích thước 1820 × 1040:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($imageSize);
    try {
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Chuyển đổi các Slide có Ghi chú và Bình luận thành ảnh**

Mặc định, ảnh slide không bao gồm ghi chú hoặc bình luận. Gửi một đối tượng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/notescommentslayoutingoptions/) tới phương thức [RenderingOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) để kiểm soát vị trí hiển thị ghi chú và bình luận.

Ví dụ sau đặt ghi chú bị cắt ngắn phía dưới slide và bình luận ở bên phải:

```php
use aspose\slides\CommentsPositions;
use aspose\slides\ImageFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$scaleX = 2;
$scaleY = $scaleX;

$commentsAreaColor = new Java("java.awt.Color", 250, 235, 215);

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setNotesPosition(NotesPositions::BottomTruncated);
$layoutOptions->setCommentsPosition(CommentsPositions::Right);
$layoutOptions->setCommentsAreaWidth(500);
$layoutOptions->setCommentsAreaColor($commentsAreaColor);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($renderingOptions, $scaleX, $scaleY);
    try {
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Cảnh báo" color="warning" %}}

Đối với việc chuyển đổi slide sang ảnh, không truyền [BottomFull](https://reference.aspose.com/slides/vi/php-java/aspose.slides/notespositions/) tới phương thức [NotesCommentsLayoutingOptions::setNotesPosition](https://reference.aspose.com/slides/vi/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Ghi chú có thể chứa nhiều văn bản hơn kích thước ảnh cố định có thể chứa. Hãy sử dụng [BottomTruncated](https://reference.aspose.com/slides/vi/php-java/aspose.slides/notespositions/) thay thế.

{{% /alert %}}

## **Chuyển đổi các Slide thành ảnh sử dụng tùy chọn TIFF**

Lớp [TiffOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/) cho phép bạn kiểm soát kích thước, độ phân giải và các thuộc tính khác của ảnh TIFF đã render.

Ví dụ sau render slide đầu tiên dưới dạng ảnh TIFF kích thước 2160 × 2880 với độ phân giải 300 DPI:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\TiffOptions;

$imageSize = new Java("java.awt.Dimension", 2160, 2880);

$tiffOptions = new TiffOptions();
$tiffOptions->setImageSize($imageSize);
$tiffOptions->setDpiX(300);
$tiffOptions->setDpiY(300);

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($tiffOptions);
    try {
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Cảnh báo" color="warning" %}}

Hỗ trợ TIFF không được đảm bảo trong các phiên bản Java trước JDK 9.

{{% /alert %}}

## **Chuyển đổi tất cả các Slide thành ảnh**

Duyệt qua bộ sưu tập slide để chuyển đổi toàn bộ bản trình bày thành một loạt ảnh. Các slide ẩn sẽ được bao gồm trừ khi bạn bỏ qua chúng một cách có chủ ý.

Ví dụ sau render mọi slide dưới dạng ảnh JPEG với hệ số tỷ lệ ngang và dọc là 2:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("Slide_" . $index . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Tạo đầu ra Enhanced Metafile**

Enhanced Metafile (EMF) hữu ích khi đồ họa dựa trên vector cần được trao đổi với Microsoft Office hoặc các ứng dụng Windows khác hỗ trợ metafile Windows. Khác với ảnh dựa trên pixel, EMF có thể giữ lại các thao tác vẽ vector mà không mất độ sắc nét khi phóng to. Tuy nhiên, EMF chủ yếu là định dạng tương thích cho các ứng dụng hỗ trợ metafile Windows, không phải là định dạng trao đổi chung. Ngoài ra, nội dung slide phức tạp, như ảnh bitmap và một số hiệu ứng, có thể được lưu dưới dạng các thành phần raster trong container metafile vector.

### **Xuất một Slide sang EMF**

Phương thức [Slide::writeAsEmf](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#writeAsEmf) ghi một slide vào luồng đích ở định dạng EMF. Ví dụ sau tải một bản trình bày, chọn slide đầu tiên và ghi nó vào luồng tệp EMF:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.FileOutputStream", "Slide_0.emf");
    try {
        $slide->writeAsEmf($emfStream);
    } finally {
        $emfStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Người gọi chịu trách nhiệm sở hữu luồng được truyền tới [Slide::writeAsEmf](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#writeAsEmf) và phải đóng luồng đó, như minh họa ở trên.

### **Chuyển đổi ảnh SVG sang EMF và thêm vào bản trình bày**

Sử dụng [SvgImage::writeAsEmf](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgimage/#writeAsEmf) để chuyển đổi nội dung SVG sang EMF. Các byte kết quả có thể được thêm vào bản trình bày thông qua [ImageCollection::addImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagecollection/#addImage) và đặt lên slide bằng [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/#addPictureFrame).

Ví dụ sau tạo một [SvgImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgimage/) từ mã SVG, chuyển đổi nó thành EMF trong bộ nhớ, chèn metafile vào slide đầu tiên và lưu bản trình bày:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$svgContent = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>';
$svgImage = new SvgImage($svgContent);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $svgImage->writeAsEmf($emfStream);

        $emfData = $emfStream->toByteArray();
        $image = $presentation->getImages()->addImage($emfData);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, $image);
    } finally {
        $emfStream->close();
    }

    $presentation->save("Presentation_with_emf.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[SvgImage::writeAsEmf](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgimage/#writeAsEmf) không nhận quyền sở hữu luồng đích. Một [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) lưu tất cả dữ liệu tạo ra trong bộ nhớ, vì vậy không cần reset vị trí trước khi gọi `toByteArray`. Mảng byte trả về vẫn hợp lệ sau khi luồng được đóng.

Việc tạo EMF khả dụng trên các hệ điều hành được hỗ trợ bởi Aspose.Slides for PHP via Java và cấu hình JDK đã chọn, nhưng quá trình render có thể khác nhau giữa các nền tảng khi phông chữ hoặc các phụ thuộc đồ họa không có sẵn. Cài đặt các phông chữ được sử dụng trong nội dung nguồn hoặc cấu hình các sự thay thế phù hợp, tuân thủ [yêu cầu nền tảng](/slides/vi/php-java/system-requirements/) cho Aspose.Slides for PHP via Java, và kiểm tra kết quả trong ứng dụng tiêu thụ EMF mục tiêu. Các ứng dụng trên Linux và macOS thường có hỗ trợ hạn chế hoặc không nhất quán trong việc hiển thị và chỉnh sửa metafile Windows.

## **Render Emoji màu**

{{% alert title="Ghi chú" color="info" %}}
Để render emoji màu đúng cách khi chuyển đổi slide trình bày sang ảnh, các phông chữ emoji được sử dụng trong bản trình bày phải được cài đặt và có sẵn trên hệ thống thực hiện chuyển đổi. Ví dụ, nếu bản trình bày sử dụng **Segoe UI Emoji** mà phông này thiếu, emoji có thể xuất hiện dưới dạng màu đen trắng trong ảnh đầu ra.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ render slide có hoạt ảnh không?**

Không. Phương thức [Slide::getImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#getImage) render một ảnh tĩnh của slide và không xuất hoạt ảnh.

**Có thể xuất các slide ẩn thành ảnh không?**

Có. Các slide ẩn có thể được render giống như các slide thông thường. Bao gồm chúng trong vòng lặp xử lý, như ví dụ ở trên.

**Bóng đổ và các hiệu ứng khác có được giữ lại trong ảnh slide không?**

Có. Aspose.Slides render bóng đổ, độ trong suốt và các hiệu ứng đồ họa được hỗ trợ khác trong ảnh slide.