---
title: Chuyển đổi Bản trình chiếu PowerPoint sang TIFF bằng PHP
titlelink: PowerPoint sang TIFF
type: docs
weight: 90
url: /vi/php-java/convert-powerpoint-to-tiff/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi OpenDocument
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang TIFF
- bản trình chiếu sang TIFF
- slide sang TIFF
- PPT sang TIFF
- PPTX sang TIFF
- lưu PPT dưới dạng TIFF
- lưu PPTX dưới dạng TIFF
- xuất PPT sang TIFF
- xuất PPTX sang TIFF
- PHP
- Aspose.Slides
description: "Tìm hiểu cách chuyển đổi dễ dàng các bản trình chiếu PowerPoint (PPT, PPTX) sang hình ảnh TIFF chất lượng cao bằng Aspose.Slides cho PHP thông qua Java, kèm theo các ví dụ mã."
---
## **Giới thiệu**

TIFF (**Tagged Image File Format**) là một định dạng ảnh raster không mất dữ liệu, được sử dụng rộng rãi, nổi tiếng với chất lượng xuất sắc và khả năng bảo tồn chi tiết đồ họa. Các nhà thiết kế, nhiếp ảnh gia và nhà xuất bản máy tính để bàn thường chọn TIFF để giữ nguyên các lớp, độ chính xác màu sắc và cài đặt gốc trong ảnh của họ.

Sử dụng Aspose.Slides, bạn có thể dễ dàng chuyển đổi các slide PowerPoint (PPT, PPTX) và slide OpenDocument (ODP) trực tiếp thành các hình ảnh TIFF chất lượng cao, đảm bảo bản trình chiếu của bạn giữ được độ trung thực hình ảnh tối đa. 

## **Chuyển đổi bản trình chiếu sang TIFF**

Sử dụng phương thức [save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#save) được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/), bạn có thể nhanh chóng chuyển đổi toàn bộ bản trình chiếu PowerPoint sang TIFF. Các hình ảnh TIFF kết quả tương ứng với kích thước slide mặc định.

Đoạn mã dưới đây minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang TIFF:

```php
// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu (PPT, PPTX, ODP, v.v.).
$presentation = new Presentation("presentation.pptx");
try {
    // Lưu trình chiếu dưới dạng TIFF.
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```

## **Chuyển đổi bản trình chiếu sang TIFF đen trắng**

Phương thức [setBwConversionMode](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/#setBwConversionMode) trong lớp [TiffOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/) cho phép bạn chỉ định thuật toán được sử dụng khi chuyển đổi một slide hoặc hình ảnh màu sang TIFF đen trắng. Lưu ý rằng cài đặt này chỉ áp dụng khi phương thức [setCompressionType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/#getCompressionType) được đặt thành `CCITT4` hoặc `CCITT3`.

Giả sử chúng ta có một tệp "sample.pptx" với slide sau:

![Slide trình chiếu](slide_black_and_white.png)

Đoạn mã dưới đây minh họa cách chuyển đổi slide màu sang TIFF đen trắng:

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

![TIFF đen trắng](TIFF_black_and_white.png)

## **Chuyển đổi bản trình chiếu sang TIFF với kích thước tùy chỉnh**

Nếu bạn cần một hình ảnh TIFF với kích thước cụ thể, bạn có thể đặt các giá trị mong muốn bằng các phương thức có sẵn trong [TiffOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/). Ví dụ, phương thức [setImageSize](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/#getImageSize) cho phép bạn xác định kích thước của hình ảnh kết quả.

Đoạn mã dưới đây minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang các hình ảnh TIFF với kích thước tùy chỉnh:

```php
// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu (PPT, PPTX, ODP, v.v.).
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // Đặt kiểu nén.
    $tiffOptions->setCompressionType(TiffCompressionTypes::Default);
    /*
    Các kiểu nén:
        Default - Chỉ ra sơ đồ nén mặc định (LZW).
        None - Chỉ ra không nén.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Độ sâu phụ thuộc vào kiểu nén và không thể đặt thủ công.

    // Đặt DPI cho hình ảnh.
    $tiffOptions->setDpiX(200);
    $tiffOptions->setDpiY(200);

    // Đặt kích thước hình ảnh.
    $tiffOptions->setImageSize(new Java("java.awt.Dimension", 1728, 1078));

    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // Lưu trình chiếu dưới dạng TIFF với kích thước đã chỉ định.
    $presentation->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

## **Chuyển đổi bản trình chiếu sang TIFF với Định dạng Pixel Hình ảnh Tùy chỉnh**

Sử dụng phương thức [setPixelFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/#getPixelFormat) từ lớp [TiffOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/), bạn có thể chỉ định định dạng pixel mong muốn cho hình ảnh TIFF kết quả.

Đoạn mã dưới đây minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang hình ảnh TIFF với định dạng pixel tùy chỉnh:

```php
// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu (PPT, PPTX, ODP, v.v.).
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat chứa các giá trị sau (theo tài liệu):
        Format1bppIndexed - 1 bit mỗi pixel, dạng chỉ mục.
        Format4bppIndexed - 4 bit mỗi pixel, dạng chỉ mục.
        Format8bppIndexed - 8 bit mỗi pixel, dạng chỉ mục.
        Format24bppRgb    - 24 bit mỗi pixel, RGB.
        Format32bppArgb   - 32 bit mỗi pixel, ARGB.
    */

    // Lưu trình chiếu dưới dạng TIFF với kích thước hình ảnh đã chỉ định.
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Hãy xem công cụ chuyển đổi PowerPoint sang Poster MIỄN PHÍ của Aspose tại [Công cụ chuyển đổi PowerPoint sang Poster MIỄN PHÍ](https://products.aspose.app/slides/vi/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi một slide riêng lẻ thay vì toàn bộ bản trình chiếu PowerPoint sang TIFF không?**

Đúng. Aspose.Slides cho phép bạn chuyển đổi từng slide riêng lẻ từ các bản trình chiếu PowerPoint và OpenDocument thành các hình ảnh TIFF một cách độc lập.

**Có giới hạn nào về số lượng slide khi chuyển đổi bản trình chiếu sang TIFF không?**

Không, Aspose.Slides không áp đặt bất kỳ hạn chế nào về số lượng slide. Bạn có thể chuyển đổi bản trình chiếu có kích thước bất kỳ sang định dạng TIFF.

**Các hiệu ứng hoạt ảnh và chuyển đổi của PowerPoint có được giữ lại khi chuyển đổi slide sang TIFF không?**

Không, TIFF là định dạng hình ảnh tĩnh. Do đó, các hoạt ảnh và hiệu ứng chuyển đổi không được giữ lại; chỉ có bản chụp tĩnh của các slide được xuất ra.