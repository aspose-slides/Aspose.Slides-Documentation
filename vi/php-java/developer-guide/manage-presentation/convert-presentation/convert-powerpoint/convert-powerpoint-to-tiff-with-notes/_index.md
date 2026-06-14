---
title: Chuyển đổi bản trình bày PowerPoint sang TIFF có ghi chú trong PHP
linktitle: PowerPoint sang TIFF có ghi chú
type: docs
weight: 100
url: /vi/php-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình bày
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang TIFF
- bản trình bày sang TIFF
- slide sang TIFF
- PPT sang TIFF
- PPTX sang TIFF
- lưu PPT dưới dạng TIFF
- lưu PPTX dưới dạng TIFF
- xuất PPT sang TIFF
- xuất PPTX sang TIFF
- PowerPoint có ghi chú
- bản trình bày có ghi chú
- slide có ghi chú
- PPT có ghi chú
- PPTX có ghi chú
- TIFF có ghi chú
- PHP
- Aspose.Slides
description: "Chuyển đổi bản trình bày PowerPoint sang TIFF có ghi chú bằng Aspose.Slides cho PHP qua Java. Tìm hiểu cách xuất slide có ghi chú người thuyết trình một cách hiệu quả."
---
## **Giới thiệu**

Aspose.Slides for PHP via Java cung cấp một giải pháp đơn giản để chuyển đổi các bản trình bày PowerPoint và OpenDocument (PPT, PPTX và ODP) có ghi chú sang định dạng TIFF. Định dạng này được sử dụng rộng rãi cho việc lưu trữ ảnh chất lượng cao, in ấn và lưu trữ tài liệu. Với Aspose.Slides, bạn không chỉ có thể xuất toàn bộ bản trình bày kèm ghi chú người thuyết trình mà còn tạo các hình thu nhỏ của slide trong chế độ Notes Slide. Quy trình chuyển đổi đơn giản và hiệu quả, sử dụng phương thức `save` của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) để biến toàn bộ bản trình bày thành một loạt các ảnh TIFF đồng thời giữ nguyên ghi chú và bố cục.

## **Chuyển đổi bản trình bày sang TIFF với ghi chú**

Lưu một bản trình bày PowerPoint hoặc OpenDocument sang TIFF có ghi chú bằng Aspose.Slides for PHP via Java bao gồm các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/): Tải tệp PowerPoint hoặc OpenDocument.  
2. Cấu hình các tùy chọn bố cục đầu ra: Sử dụng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/notescommentslayoutingoptions/) để chỉ định cách hiển thị ghi chú và bình luận.  
3. Lưu bản trình bày dưới dạng TIFF: Truyền các tùy chọn đã cấu hình vào phương thức [save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#save).

Giả sử chúng ta có tệp "speaker_notes.pptx" với slide sau:

![The presentation slide with speaker notes](slide_with_notes.png)

Đoạn mã dưới đây minh họa cách chuyển đổi bản trình bày sang ảnh TIFF trong chế độ Notes Slide bằng phương thức [setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions).

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
$presentation = new Presentation("speaker_notes.pptx");
try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull); // Hiển thị ghi chú bên dưới slide.

    // Cấu hình các tùy chọn TIFF với bố cục ghi chú.
    $tiffOptions = new TiffOptions();
    $tiffOptions->setDpiX(300);
    $tiffOptions->setDpiY(300);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // Lưu bản trình bày thành TIFF có ghi chú người thuyết trình.
    $presentation->save("TIFF_with_notes.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Hãy khám phá Aspose [Trình chuyển đổi PowerPoint sang Poster miễn phí](https://products.aspose.app/slides/vi/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Tôi có thể kiểm soát vị trí khu vực ghi chú trong TIFF kết quả không?**

Có. Sử dụng [cài đặt bố cục ghi chú](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) để lựa chọn giữa các tùy chọn như `None`, `BottomTruncated` hoặc `BottomFull`, tương ứng ẩn ghi chú, vừa chúng vào một trang duy nhất, hoặc cho phép chúng chảy sang các trang bổ sung.

**Làm sao tôi có thể giảm kích thước tệp TIFF có ghi chú mà không gây mất chất lượng đáng thấy?**

Chọn một [phương pháp nén hiệu quả](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/setcompressiontype/) (ví dụ `LZW` hoặc `RLE`), đặt DPI hợp lý, và nếu chấp nhận được, sử dụng một [định dạng pixel](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/setpixelformat/) thấp hơn (như 8 bpp hoặc 1 bpp cho ảnh đơn sắc). Giảm nhẹ [kích thước ảnh](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/setimagesize/) cũng có thể giúp mà không làm giảm đáng kể độ đọc được.

**Phông chữ trong ghi chú có ảnh hưởng đến kết quả nếu các phông chữ gốc không có trên hệ thống không?**

Có. Các phông chữ thiếu sẽ kích hoạt [sự thay thế](/slides/vi/php-java/font-selection-sequence/), có thể thay đổi kích thước và giao diện văn bản. Để tránh điều này, [cung cấp các phông chữ cần thiết](/slides/vi/php-java/custom-font/) hoặc đặt một [phông chữ dự phòng mặc định](/slides/vi/php-java/fallback-font/) để các kiểu chữ mong muốn được sử dụng.