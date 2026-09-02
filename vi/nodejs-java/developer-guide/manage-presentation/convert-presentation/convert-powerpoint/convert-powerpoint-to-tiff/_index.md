---
title: Chuyển đổi bản trình bày PowerPoint sang TIFF bằng JavaScript
titlelink: PowerPoint sang TIFF
type: docs
weight: 90
url: /vi/nodejs-java/convert-powerpoint-to-tiff/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi OpenDocument
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách dễ dàng chuyển đổi các bản trình bày PowerPoint (PPT, PPTX) sang hình ảnh TIFF chất lượng cao bằng Aspose.Slides cho Node.js, kèm theo các ví dụ mã JavaScript."
---
## **Giới thiệu**

TIFF (**Tagged Image File Format**) là một định dạng ảnh raster không mất dữ liệu, được sử dụng rộng rãi và nổi tiếng với chất lượng xuất sắc cũng như khả năng bảo tồn chi tiết đồ họa. Các nhà thiết kế, nhiếp ảnh gia và nhà xuất bản desktop thường chọn TIFF để giữ nguyên các lớp, độ chính xác màu và các cài đặt gốc trong ảnh.

Với Aspose.Slides, bạn có thể dễ dàng chuyển đổi các slide PowerPoint (PPT, PPTX) và các slide OpenDocument (ODP) trực tiếp thành hình ảnh TIFF chất lượng cao, đảm bảo bài thuyết trình của bạn giữ lại độ trung thực hình ảnh tối đa.

## **Chuyển đổi bản trình bày sang TIFF**

Sử dụng phương thức [save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/), bạn có thể nhanh chóng chuyển toàn bộ bản trình bày PowerPoint sang TIFF. Các hình ảnh TIFF kết quả tương ứng với kích thước slide mặc định.

Đoạn mã JavaScript sau minh họa cách chuyển đổi một bản trình bày PowerPoint sang TIFF:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày (PPT, PPTX, ODP, v.v.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // Lưu bản trình bày dưới dạng TIFF.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Chuyển đổi bản trình bày sang TIFF đen‑trắng**

Phương thức [setBwConversionMode](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) trong lớp [TiffOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/) cho phép bạn chỉ định thuật toán được dùng khi chuyển đổi một slide hoặc ảnh màu sang TIFF đen‑trắng. Lưu ý rằng cài đặt này chỉ áp dụng khi phương thức [setCompressionType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) được đặt thành `CCITT4` hoặc `CCITT3`.

{{% alert color="info" title="Note" %}}

[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) là một cài đặt ở mức độ xuất, chọn thuật toán chuyển đổi pixel cho toàn bộ ảnh TIFF. Để định nghĩa cách một shape riêng lẻ hiển thị khi chế độ hiển thị đen‑trắng được bật, hãy sử dụng [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#setBlackWhiteMode). Xem [Control Black-and-White Rendering for Shapes](/slides/vi/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes) để biết ví dụ.

{{% /alert %}}

Giả sử chúng ta có tệp "sample.pptx" với slide như sau:

![A presentation slide](slide_black_and_white.png)

Đoạn mã JavaScript dưới đây minh họa cách chuyển đổi slide màu sang TIFF đen‑trắng:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(aspose.slides.BlackWhiteConversionMode.Dithering);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Black-and-White TIFF](TIFF_black_and_white.png)

## **Chuyển đổi bản trình bày sang TIFF với kích thước tùy chỉnh**

Nếu bạn cần một ảnh TIFF có kích thước cụ thể, có thể đặt giá trị mong muốn bằng các phương thức có sẵn trong [TiffOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/). Ví dụ, phương thức [setImageSize](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/#setImageSize) cho phép bạn định nghĩa kích thước của ảnh kết quả.

Đoạn mã JavaScript sau minh họa cách chuyển đổi bản trình bày PowerPoint sang ảnh TIFF với kích thước tùy chỉnh:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày (PPT, PPTX, ODP, v.v.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // Đặt loại nén.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    Các loại nén:
        Default - Chỉ định sơ đồ nén mặc định (LZW).
        None - Chỉ định không nén.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Độ sâu màu được kiểm soát bởi định dạng pixel (xem ví dụ bên dưới); CCITT3 và CCITT4 luôn tạo ra 1 bit trên mỗi pixel.

    // Đặt DPI cho ảnh.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Đặt kích thước ảnh.
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Lưu bản trình bày dưới dạng TIFF với kích thước đã chỉ định.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **Chuyển đổi bản trình bày sang TIFF với định dạng pixel ảnh tùy chỉnh**

Sử dụng phương thức [setPixelFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) từ lớp [TiffOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/) bạn có thể chỉ định định dạng pixel ưa thích cho ảnh TIFF kết quả.

Đoạn mã JavaScript dưới đây minh họa cách chuyển đổi bản trình bày PowerPoint sang ảnh TIFF với định dạng pixel tùy chỉnh:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày (PPT, PPTX, ODP, v.v.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat chứa các giá trị sau (như trong tài liệu):
        Format1bppIndexed - 1 bit mỗi pixel, có chỉ mục.
        Format4bppIndexed - 4 bit mỗi pixel, có chỉ mục.
        Format8bppIndexed - 8 bit mỗi pixel, có chỉ mục.
        Format24bppRgb    - 24 bit mỗi pixel, RGB.
        Format32bppArgb   - 32 bit mỗi pixel, ARGB.
    */

    /// Lưu bản trình bày dưới dạng TIFF với kích thước ảnh đã chỉ định.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}

Hãy khám phá công cụ [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/vi/conversion/convert-ppt-to-poster-online) của Aspose.

{{% /alert %}}

## **FAQ**

**Tôi có thể chuyển đổi một slide riêng lẻ thay vì toàn bộ bản trình bày PowerPoint sang TIFF không?**

Có. Aspose.Slides cho phép bạn chuyển đổi các slide riêng lẻ từ bản trình bày PowerPoint và OpenDocument thành các ảnh TIFF một cách độc lập.

**Có giới hạn nào về số lượng slide khi chuyển đổi bản trình bày sang TIFF không?**

Không, Aspose.Slides không áp đặt bất kỳ hạn chế nào về số lượng slide. Bạn có thể chuyển đổi các bản trình bày có kích thước bất kỳ sang định dạng TIFF.

**Các hiệu ứng hoạt ảnh và chuyển tiếp của PowerPoint có được giữ lại khi chuyển đổi sang TIFF không?**

Không, TIFF là định dạng ảnh tĩnh. Do đó, các hoạt ảnh và hiệu ứng chuyển tiếp sẽ không được giữ lại; chỉ có các ảnh chụp tĩnh của slide được xuất.