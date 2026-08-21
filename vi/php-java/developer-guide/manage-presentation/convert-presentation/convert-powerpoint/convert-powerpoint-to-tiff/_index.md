---
title: Chuyển đổi Bài thuyết trình PowerPoint sang TIFF trong PHP
titlelink: PowerPoint sang TIFF
type: docs
weight: 90
url: /vi/php-java/convert-powerpoint-to-tiff/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi OpenDocument
- chuyển đổi bài thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang TIFF
- bài thuyết trình sang TIFF
- slide sang TIFF
- PPT sang TIFF
- PPTX sang TIFF
- lưu PPT dưới dạng TIFF
- lưu PPTX dưới dạng TIFF
- xuất PPT sang TIFF
- xuất PPTX sang TIFF
- PHP
- Aspose.Slides
description: "Tìm hiểu cách dễ dàng chuyển đổi các bài thuyết trình PowerPoint (PPT, PPTX) sang hình ảnh TIFF chất lượng cao bằng Aspose.Slides cho PHP thông qua Java, kèm theo các ví dụ mã."
---
## **Giới thiệu**

TIFF (**Tagged Image File Format**) là một định dạng ảnh raster không mất dữ liệu, được sử dụng rộng rãi và nổi tiếng với chất lượng tuyệt vời cùng khả năng bảo tồn chi tiết đồ họa. Các nhà thiết kế, nhiếp ảnh gia và nhà xuất bản desktop thường chọn TIFF để duy trì các lớp, độ chính xác màu và các cài đặt gốc trong hình ảnh của họ.

Sử dụng Aspose.Slides, bạn có thể dễ dàng chuyển đổi các slide PowerPoint (PPT, PPTX) và slide OpenDocument (ODP) trực tiếp thành các hình ảnh TIFF chất lượng cao, đảm bảo bản trình bày của bạn giữ được độ trung thực hình ảnh tối đa. 

## **Chuyển đổi Bài thuyết trình sang TIFF**

Bằng cách sử dụng phương thức [save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#save) được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/), bạn có thể nhanh chóng chuyển đổi toàn bộ bài thuyết trình PowerPoint sang TIFF. Các hình ảnh TIFF được tạo ra tương ứng với kích thước slide mặc định.

Đoạn mã sau minh họa cách chuyển đổi một bài thuyết trình PowerPoint sang TIFF:

```php
// Tạo một đối tượng lớp Presentation đại diện cho tệp bài thuyết trình (PPT, PPTX, ODP, v.v.).
$presentation = new Presentation("presentation.pptx");
try {
    // Lưu bài thuyết trình dưới dạng TIFF.
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```

## **Chuyển đổi Bài thuyết trình sang TIFF Đen và Trắng**

Phương thức [setBwConversionMode](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/#setBwConversionMode) trong lớp [TiffOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/) cho phép bạn chỉ định thuật toán được sử dụng khi chuyển đổi một slide hoặc hình ảnh màu sang TIFF đen và trắng. Lưu ý rằng cài đặt này chỉ áp dụng khi phương thức [setCompressionType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/#getCompressionType) được đặt thành `CCITT4` hoặc `CCITT3`.

{{% alert color="info" title="Lưu ý" %}}
[TiffOptions::setBwConversionMode](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/#setBwConversionMode) là một cài đặt cấp xuất khẩu cho phép lựa chọn thuật toán chuyển đổi pixel cho toàn bộ hình ảnh TIFF. Để xác định cách một hình dạng riêng lẻ hiển thị khi chế độ hiển thị đen và trắng được bật, hãy sử dụng [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#setBlackWhiteMode). Xem [Control Black-and-White Rendering for Shapes](/php-java/shape-formatting/#control-black-and-white-rendering-for-shapes) để biết các ví dụ.
{{% /alert %}}

Giả sử chúng ta có một tệp "sample.pptx" với slide sau:

![Slide bài thuyết trình](slide_black_and_white.png)

Đoạn mã sau minh họa cách chuyển đổi slide màu sang TIFF đen và trắng:

```php
$tiffOptions = new TiffOptions();
$tiffOptions->setCompressionType(TiffCompressionTypes::CCITT4);
$tiffOptions->setBwConversionMode(BlackWhiteConversionMode::Dithering);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![TIFF Đen và Trắng](TIFF_black_and_white.png)

## **Chuyển đổi Bài thuyết trình sang TIFF với Kích thước Tùy chỉnh**

Nếu bạn cần một hình ảnh TIFF với kích thước cụ thể, bạn có thể đặt các giá trị mong muốn bằng các phương thức có sẵn trong [TiffOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/). Ví dụ, phương thức [setImageSize](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/#getImageSize) cho phép bạn xác định kích thước của hình ảnh kết quả.

Đoạn mã sau minh họa cách chuyển đổi một bài thuyết trình PowerPoint sang các hình ảnh TIFF với kích thước tùy chỉnh:

```php
// Tạo một đối tượng lớp Presentation đại diện cho tệp bài thuyết trình (PPT, PPTX, ODP, v.v.).
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // Đặt loại nén.
    $tiffOptions->setCompressionType(TiffCompressionTypes::Default);
    /*
    Các loại nén:
        Default - Chỉ ra sơ đồ nén mặc định (LZW).
        None - Chỉ ra không nén.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Độ sâu phụ thuộc vào loại nén và không thể đặt thủ công.

    // Đặt DPI cho hình ảnh.
    $tiffOptions->setDpiX(200);
    $tiffOptions->setDpiY(200);

    // Đặt kích thước hình ảnh.
    $tiffOptions->setImageSize(new Java("java.awt.Dimension", 1728, 1078));

    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // Lưu bài thuyết trình dưới dạng TIFF với kích thước đã chỉ định.
    $presentation->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

## **Chuyển đổi Bài thuyết trình sang TIFF với Định dạng Pixel Hình ảnh Tùy chỉnh**

Bằng cách sử dụng phương thức [setPixelFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/#getPixelFormat) từ lớp [TiffOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/), bạn có thể chỉ định định dạng pixel ưa thích cho hình ảnh TIFF kết quả.

Đoạn mã sau minh họa cách chuyển đổi một bài thuyết trình PowerPoint sang một hình ảnh TIFF với định dạng pixel tùy chỉnh:

```php
// Tạo một đối tượng lớp Presentation đại diện cho tệp bài thuyết trình (PPT, PPTX, ODP, v.v.).
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat chứa các giá trị sau (như đã nêu trong tài liệu):
        Format1bppIndexed - 1 bit mỗi pixel, dạng chỉ mục.
        Format4bppIndexed - 4 bit mỗi pixel, dạng chỉ mục.
        Format8bppIndexed - 8 bit mỗi pixel, dạng chỉ mục.
        Format24bppRgb    - 24 bit mỗi pixel, RGB.
        Format32bppArgb   - 32 bit mỗi pixel, ARGB.
    */

    // Lưu bài thuyết trình dưới dạng TIFF với kích thước ảnh đã chỉ định.
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Mẹo" color="info" %}}
Xem công cụ [Công cụ chuyển đổi PowerPoint sang Poster MIỄN PHÍ](https://products.aspose.app/slides/vi/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi một slide riêng lẻ thay vì toàn bộ bài thuyết trình PowerPoint sang TIFF không?**

Đúng. Aspose.Slides cho phép bạn chuyển đổi các slide riêng lẻ từ bài thuyết trình PowerPoint và OpenDocument thành các hình ảnh TIFF một cách riêng biệt.

**Có giới hạn nào về số lượng slide khi chuyển đổi một bài thuyết trình sang TIFF không?**

Không, Aspose.Slides không áp đặt bất kỳ hạn chế nào về số lượng slide. Bạn có thể chuyển đổi các bài thuyết trình có kích thước bất kỳ sang định dạng TIFF.

**Các hiệu ứng hoạt ảnh và chuyển đổi của PowerPoint có được giữ lại khi chuyển đổi các slide sang TIFF không?**

Không, TIFF là một định dạng hình ảnh tĩnh. Do đó, các hoạt ảnh và hiệu ứng chuyển đổi không được giữ lại; chỉ có các ảnh chụp tĩnh của slide được xuất ra.