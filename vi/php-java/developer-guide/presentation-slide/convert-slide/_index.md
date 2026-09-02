---
title: Chuyển đổi các slide trình chiếu sang hình ảnh trong PHP
linktitle: Slide sang hình ảnh
type: docs
weight: 35
url: /vi/php-java/convert-slide/
keywords:
- chuyển đổi slide
- xuất slide
- slide sang hình ảnh
- lưu slide dưới dạng hình ảnh
- slide sang PNG
- slide sang JPEG
- slide sang bitmap
- slide sang TIFF
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Chuyển đổi các slide từ PPT, PPTX và ODP sang hình ảnh bằng Aspose.Slides for PHP via Java — tốc độ nhanh, render chất lượng cao với các ví dụ mã rõ ràng."
---
## **Giới thiệu**

Aspose.Slides for PHP via Java cho phép bạn dễ dàng chuyển đổi các slide trình chiếu PowerPoint và OpenDocument sang nhiều định dạng hình ảnh khác nhau, bao gồm BMP, PNG, JPG (JPEG), GIF và các định dạng khác.

Để chuyển đổi một slide thành hình ảnh, thực hiện các bước sau:

1. Xác định các cài đặt chuyển đổi mong muốn và chọn các slide bạn muốn xuất bằng cách sử dụng:
    - Lớp [TiffOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/) hoặc
    - Lớp [RenderingOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/renderingoptions/) .
2. Tạo hình ảnh slide bằng cách gọi phương thức [getImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#getImage).

Trong Aspose.Slides for PHP via Java, một [IImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/) là lớp cho phép bạn làm việc với các hình ảnh được định nghĩa bằng dữ liệu pixel. Bạn có thể sử dụng lớp này để lưu hình ảnh ở một loạt các định dạng (BMP, JPG, PNG, v.v.).

## **Chuyển đổi Slide sang Bitmap và Lưu Hình ảnh ở định dạng PNG**

Bạn có thể chuyển đổi một slide thành đối tượng bitmap và sử dụng trực tiếp trong ứng dụng của mình. Ngoài ra, bạn cũng có thể chuyển đổi slide thành bitmap rồi lưu hình ảnh dưới dạng JPEG hoặc bất kỳ định dạng nào bạn muốn.

Mã sau minh họa cách chuyển đổi slide đầu tiên của một bài thuyết trình thành đối tượng bitmap và sau đó lưu hình ảnh ở định dạng PNG:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    // Chuyển đổi slide đầu tiên trong bài thuyết trình thành bitmap.
    $image = $presentation->getSlides()->get_Item(0)->getImage();
    try {
        // Lưu hình ảnh ở định dạng PNG.
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Chuyển đổi Slide sang Hình ảnh với Kích thước Tùy chỉnh**

Bạn có thể cần có một hình ảnh có kích thước nhất định. Sử dụng một overload của [getImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#getImage), bạn có thể chuyển đổi slide thành hình ảnh với độ rộng và chiều cao cụ thể.

Mã mẫu dưới đây minh họa cách thực hiện:

```php
$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    // Chuyển đổi slide đầu tiên trong bài thuyết trình thành bitmap với kích thước được chỉ định.
    $image = $presentation->getSlides()->get_Item(0)->getImage($imageSize);
    try {
        // Lưu hình ảnh ở định dạng JPEG.
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Chuyển đổi Slide có Ghi chú và Bình luận sang Hình ảnh**

Một số slide có thể chứa ghi chú và bình luận.

Aspose.Slides cung cấp hai lớp [TiffOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/) và [RenderingOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/renderingoptions/) — cho phép bạn kiểm soát việc render các slide trình chiếu thành hình ảnh. Cả hai lớp đều bao gồm phương thức `setSlidesLayoutOptions`, cho phép bạn cấu hình việc render ghi chú và bình luận trên slide khi chuyển đổi sang hình ảnh.

Với lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/notescommentslayoutingoptions/), bạn có thể chỉ định vị trí mong muốn cho ghi chú và bình luận trong hình ảnh kết quả.

Mã dưới đây minh họa cách chuyển đổi một slide có ghi chú và bình luận:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $notesCommentsOptions = new NotesCommentsLayoutingOptions();
    $notesCommentsOptions->setNotesPosition(NotesPositions::BottomTruncated);         // Đặt vị trí của ghi chú.
    $notesCommentsOptions->setCommentsPosition(CommentsPositions::Right);             // Đặt vị trí của bình luận.
    $notesCommentsOptions->setCommentsAreaWidth(500);                                 // Đặt độ rộng của khu vực bình luận.
    $notesCommentsOptions->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);  // Đặt màu cho khu vực bình luận.

    // Tạo các tùy chọn render.
    $options = new RenderingOptions();
    $options->setSlidesLayoutOptions($notesCommentsOptions);

    // Chuyển đổi slide đầu tiên của bài thuyết trình thành hình ảnh.
    $image = $presentation->getSlides()->get_Item(0)->getImage($options, $scaleX, $scaleY);
    try {
        // Lưu hình ảnh ở định dạng GIF.
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Lưu ý" color="warning" %}} 

Trong bất kỳ quy trình chuyển đổi slide sang hình ảnh nào, phương thức [setNotesPosition](https://reference.aspose.com/slides/vi/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) không thể áp dụng `BottomFull` (để chỉ định vị trí cho ghi chú) vì văn bản ghi chú có thể quá lớn, không thể vừa trong kích thước hình ảnh đã chỉ định.

{{% /alert %}} 

## **Chuyển đổi Slide sang Hình ảnh bằng Tùy chọn TIFF**

Lớp [TiffOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/) cung cấp kiểm soát chi tiết hơn đối với hình ảnh TIFF kết quả bằng cách cho phép bạn chỉ định các tham số như kích thước, độ phân giải, bảng màu, và nhiều hơn nữa.

Mã dưới đây minh họa quy trình chuyển đổi trong đó các tùy chọn TIFF được sử dụng để xuất một hình ảnh đen‑trắng với độ phân giải 300 DPI và kích thước 2160 × 2800:

```php
// Tải tệp bài thuyết trình.
$presentation = new Presentation("sample.pptx");
try {
    // Lấy slide đầu tiên từ bài thuyết trình.
    $slide = $presentation->getSlides()->get_Item(0);

    // Cấu hình các thiết lập cho hình ảnh TIFF đầu ra.
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));  // Đặt kích thước hình ảnh.
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);       // Đặt định dạng pixel (đen và trắng).
    $options->setDpiX(300);                                              // Đặt độ phân giải theo chiều ngang.
    $options->setDpiY(300);                                              // Đặt độ phân giải theo chiều dọc.
    
    // Chuyển đổi slide thành hình ảnh với các tùy chọn đã chỉ định.
    $image = $slide->getImage($options);
    try {
        // Lưu hình ảnh ở định dạng TIFF.
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Lưu ý" color="warning" %}} 

Hỗ trợ TIFF không được đảm bảo trong các phiên bản trước JDK 9.

{{% /alert %}} 

## **Chuyển đổi Tất cả các Slide sang Hình ảnh**

Aspose.Slides cho phép bạn chuyển đổi tất cả các slide trong một bài thuyết trình thành hình ảnh, thực chất chuyển toàn bộ bài thuyết trình thành một loạt các hình ảnh.

Mã mẫu dưới đây minh họa cách chuyển đổi tất cả các slide trong một bài thuyết trình thành hình ảnh trong PHP:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    // Render bài thuyết trình thành hình ảnh theo từng slide.
    for($i = 0; $i < java_values($presentation->getSlides()->size()) ; $i++) {
        // Kiểm soát các slide ẩn (không render các slide ẩn).
        if (java_values($presentation->getSlides()->get_Item($i)->getHidden())) {
            continue;
        }

        // Chuyển đổi slide thành hình ảnh.
        $image = $presentation->getSlides()->get_Item($i)->getImage($scaleX, $scaleY);
        try {
            // Lưu hình ảnh ở định dạng JPEG.
            $image->save("Slide_" . $i . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Render Emoji Màu**

{{% alert title="Lưu ý" color="warning" %}} 
Để render emoji màu đúng cách khi chuyển đổi slide trình chiếu sang hình ảnh, các phông chữ emoji được sử dụng trong bài thuyết trình phải được cài đặt và có sẵn trên hệ thống thực hiện chuyển đổi. Ví dụ, nếu bài thuyết trình sử dụng **Segoe UI Emoji** và phông chữ này thiếu, các emoji có thể xuất hiện dưới dạng đen‑trắng trong hình ảnh đầu ra.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ render slide với hoạt ảnh không?**

Không, phương thức `getImage` chỉ lưu một hình ảnh tĩnh của slide, không có hoạt ảnh.

**Có thể xuất các slide ẩn thành hình ảnh không?**

Có, các slide ẩn có thể được xử lý giống như các slide thông thường. Chỉ cần chắc chắn chúng được đưa vào vòng lặp xử lý.

**Có thể lưu hình ảnh với bóng đèn và hiệu ứng không?**

Có, Aspose.Slides hỗ trợ render bóng đèn, độ trong suốt và các hiệu ứng đồ họa khác khi lưu slide dưới dạng hình ảnh.