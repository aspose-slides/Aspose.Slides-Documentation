---
title: Chuyển đổi các slide trình chiếu sang ảnh trong PHP
linktitle: Slide sang ảnh
type: docs
weight: 35
url: /vi/php-java/convert-slide/
keywords: 
- chuyển đổi slide
- xuất slide
- slide sang ảnh
- lưu slide dưới dạng ảnh
- slide sang PNG
- slide sang JPEG
- slide sang bitmap
- slide sang TIFF
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Chuyển đổi các slide từ PPT, PPTX và ODP sang ảnh bằng Aspose.Slides for PHP via Java — nhanh, render chất lượng cao với các ví dụ mã rõ ràng."
---
## **Giới thiệu**

Aspose.Slides for PHP via Java cho phép bạn dễ dàng chuyển đổi các slide PowerPoint và OpenDocument sang nhiều định dạng ảnh khác nhau, bao gồm BMP, PNG, JPG (JPEG), GIF và các định dạng khác.

Để chuyển đổi một slide thành ảnh, thực hiện các bước sau:

1. Xác định cài đặt chuyển đổi mong muốn và chọn các slide bạn muốn xuất bằng cách sử dụng:
   - Lớp [TiffOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/), hoặc
   - Lớp [RenderingOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/renderingoptions/).
2. Tạo ảnh slide bằng cách gọi phương thức [getImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#getImage).

Trong Aspose.Slides for PHP via Java, một [IImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/) là lớp cho phép bạn làm việc với các ảnh được định nghĩa bằng dữ liệu pixel. Bạn có thể dùng lớp này để lưu ảnh ở nhiều định dạng (BMP, JPG, PNG, v.v.).

## **Chuyển đổi Slide thành Bitmap và Lưu ảnh dưới dạng PNG**

Bạn có thể chuyển đổi một slide thành đối tượng bitmap và sử dụng trực tiếp trong ứng dụng của mình. Ngoài ra, bạn cũng có thể chuyển đổi slide thành bitmap rồi lưu ảnh dưới định dạng JPEG hoặc bất kỳ định dạng nào khác mà bạn ưa thích.

Đoạn mã dưới đây minh họa cách chuyển slide đầu tiên của bản trình chiếu thành đối tượng bitmap và sau đó lưu ảnh dưới dạng PNG:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    // Chuyển đổi slide đầu tiên trong bản trình chiếu sang bitmap.
    $image = $presentation->getSlides()->get_Item(0)->getImage();
    try {
        // Lưu ảnh dưới định dạng PNG.
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Chuyển đổi Slide thành Ảnh với Kích thước Tùy chỉnh**

Bạn có thể cần lấy một ảnh với kích thước nhất định. Bằng cách sử dụng overload của phương thức [getImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#getImage), bạn có thể chuyển đổi một slide thành ảnh với chiều rộng và chiều cao cụ thể.

Đoạn mã mẫu dưới đây minh họa cách thực hiện:

```php
$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    // Chuyển đổi slide đầu tiên trong bản trình chiếu sang bitmap với kích thước đã chỉ định.
    $image = $presentation->getSlides()->get_Item(0)->getImage($imageSize);
    try {
        // Lưu ảnh dưới định dạng JPEG.
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Chuyển đổi Slide có Ghi chú và Bình luận thành Ảnh**

Một số slide có thể chứa ghi chú và bình luận.

Aspose.Slides cung cấp hai lớp [TiffOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/) và [RenderingOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/renderingoptions/) — cho phép bạn kiểm soát việc render các slide trình chiếu thành ảnh. Cả hai lớp đều bao gồm phương thức `setSlidesLayoutOptions`, cho phép bạn cấu hình cách render ghi chú và bình luận trên slide khi chuyển đổi sang ảnh.

Với lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/notescommentslayoutingoptions/), bạn có thể chỉ định vị trí mong muốn cho ghi chú và bình luận trong ảnh kết quả.

Đoạn mã dưới đây minh họa cách chuyển đổi một slide có ghi chú và bình luận:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $notesCommentsOptions = new NotesCommentsLayoutingOptions();
    $notesCommentsOptions->setNotesPosition(NotesPositions::BottomTruncated);         // Đặt vị trí của ghi chú.
    $notesCommentsOptions->setCommentsPosition(CommentsPositions::Right);             // Đặt vị trí của bình luận.
    $notesCommentsOptions->setCommentsAreaWidth(500);                                 // Đặt chiều rộng của khu vực bình luận.
    $notesCommentsOptions->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);  // Đặt màu cho khu vực bình luận.

    // Tạo các tùy chọn render.
    $options = new RenderingOptions();
    $options->setSlidesLayoutOptions($notesCommentsOptions);

    // Chuyển đổi slide đầu tiên của bản trình chiếu thành ảnh.
    $image = $presentation->getSlides()->get_Item(0)->getImage($options, $scaleX, $scaleY);
    try {
        // Lưu ảnh dưới định dạng GIF.
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Lưu ý" color="warning" %}} 
Trong bất kỳ quy trình chuyển đổi slide‑to‑image nào, phương thức [setNotesPosition](https://reference.aspose.com/slides/vi/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) không thể áp dụng `BottomFull` (để chỉ định vị trí cho ghi chú) vì nội dung ghi chú có thể quá lớn, khiến nó không thể vừa trong kích thước ảnh đã chỉ định.
{{% /alert %}} 

## **Chuyển đổi Slide thành Ảnh bằng Tùy chọn TIFF**

Lớp [TiffOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/) cung cấp quyền kiểm soát tốt hơn đối với ảnh TIFF kết quả bằng cách cho phép bạn xác định các tham số như kích thước, độ phân giải, bảng màu và hơn thế nữa.

Đoạn mã dưới đây minh họa quy trình chuyển đổi sử dụng các tùy chọn TIFF để xuất một ảnh đen‑trắng với độ phân giải 300 DPI và kích thước 2160 × 2800:

```php
// Tải tệp bản trình chiếu.
$presentation = new Presentation("sample.pptx");
try {
    // Lấy slide đầu tiên từ bản trình chiếu.
    $slide = $presentation->getSlides()->get_Item(0);

    // Cấu hình các thiết lập cho ảnh TIFF đầu ra.
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));  // Đặt kích thước ảnh.
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);       // Đặt định dạng pixel (đen trắng).
    $options->setDpiX(300);                                              // Đặt độ phân giải chiều ngang.
    $options->setDpiY(300);                                              // Đặt độ phân giải chiều dọc.
    
    // Chuyển đổi slide thành ảnh với các tùy chọn đã chỉ định.
    $image = $slide->getImage($options);
    try {
        // Lưu ảnh dưới định dạng TIFF.
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

## **Chuyển đổi Tất cả Slide thành Ảnh**

Aspose.Slides cho phép bạn chuyển đổi tất cả các slide trong một bản trình chiếu thành ảnh, thực chất chuyển toàn bộ bản trình chiếu thành một loạt các ảnh.

Đoạn mã mẫu dưới đây minh họa cách chuyển đổi tất cả slide trong một bản trình chiếu thành ảnh bằng PHP:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    // Render bản trình chiếu thành các ảnh từng slide.
    for($i = 0; $i < java_values($presentation->getSlides()->size()) ; $i++) {
        // Kiểm soát các slide ẩn (không render các slide ẩn).
        if (java_values($presentation->getSlides()->get_Item($i)->getHidden())) {
            continue;
        }

        // Chuyển đổi slide thành ảnh.
        $image = $presentation->getSlides()->get_Item($i)->getImage($scaleX, $scaleY);
        try {
            // Lưu ảnh dưới định dạng JPEG.
            $image->save("Slide_" . $i . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ render slide có hoạt ảnh không?**

Không, phương thức `getImage` chỉ lưu một ảnh tĩnh của slide, không có hoạt ảnh.

**Có thể xuất các slide ẩn thành ảnh không?**

Có, các slide ẩn có thể được xử lý giống như các slide thường. Chỉ cần đảm bảo chúng được đưa vào vòng lặp xử lý.

**Có thể lưu ảnh với bóng đổ và hiệu ứng không?**

Có, Aspose.Slides hỗ trợ render bóng đổ, độ trong suốt và các hiệu ứng đồ họa khác khi lưu slide dưới dạng ảnh.