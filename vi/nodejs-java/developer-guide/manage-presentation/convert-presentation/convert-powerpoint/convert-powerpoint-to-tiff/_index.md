---
title: "Chuyển đổi bản trình bày PowerPoint sang TIFF trong JavaScript"
titlelink: "PowerPoint sang TIFF"
type: docs
weight: 90
url: /vi/nodejs-java/convert-powerpoint-to-tiff/
keywords:
- "chuyển đổi PowerPoint"
- "chuyển đổi OpenDocument"
- "chuyển đổi bản trình bày"
- "chuyển đổi slide"
- "chuyển đổi PPT"
- "chuyển đổi PPTX"
- "PowerPoint sang TIFF"
- "bản trình bày sang TIFF"
- "slide sang TIFF"
- "PPT sang TIFF"
- "PPTX sang TIFF"
- "lưu PPT dưới dạng TIFF"
- "lưu PPTX dưới dạng TIFF"
- "xuất PPT sang TIFF"
- "xuất PPTX sang TIFF"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Tìm hiểu cách dễ dàng chuyển đổi các bản trình bày PowerPoint (PPT, PPTX) sang hình ảnh TIFF chất lượng cao bằng Aspose.Slides cho Node.js, kèm ví dụ mã JavaScript."
---
## **Giới thiệu**

TIFF (**Tagged Image File Format**) là một định dạng ảnh raster không mất dữ liệu, được sử dụng rộng rãi, nổi tiếng với chất lượng xuất sắc và việc bảo tồn chi tiết đồ họa. Các nhà thiết kế, nhiếp ảnh gia và nhà xuất bản trên máy tính để bàn thường chọn TIFF để duy trì các lớp, độ chính xác màu và cài đặt gốc trong ảnh.

Sử dụng Aspose.Slides, bạn có thể dễ dàng chuyển đổi các slide PowerPoint (PPT, PPTX) và slide OpenDocument (ODP) trực tiếp thành ảnh TIFF chất lượng cao, đảm bảo bản trình bày của bạn giữ được độ trung thực hình ảnh tối đa.

## **Chuyển đổi bản trình bày sang TIFF**

Sử dụng phương thức [save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/), bạn có thể nhanh chóng chuyển đổi toàn bộ bản trình bày PowerPoint sang TIFF. Các ảnh TIFF tạo ra tương ứng với kích thước slide mặc định.

Đoạn mã JavaScript này minh họa cách chuyển đổi một bản trình bày PowerPoint sang TIFF:

```js
// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày (PPT, PPTX, ODP, v.v.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // Lưu bản trình bày dưới dạng TIFF.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Chuyển đổi bản trình bày sang TIFF đen‑trắng**

Phương thức [setBwConversionMode](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) trong lớp [TiffOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/) cho phép bạn chỉ định thuật toán được sử dụng khi chuyển đổi một slide hoặc hình ảnh màu sang TIFF đen‑trắng. Lưu ý rằng cài đặt này chỉ áp dụng khi phương thức [setCompressionType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) được đặt thành `CCITT4` hoặc `CCITT3`.

Giả sử chúng ta có tệp "sample.pptx" với slide sau:

![Một slide trình bày](slide_black_and_white.png)

Đoạn mã JavaScript này minh họa cách chuyển đổi slide màu sang TIFF đen‑trắng:

```js
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

![TIFF đen‑trắng](TIFF_black_and_white.png)

## **Chuyển đổi bản trình bày sang TIFF với kích thước tùy chỉnh**

Nếu bạn cần một ảnh TIFF có kích thước cụ thể, bạn có thể đặt các giá trị mong muốn bằng các phương thức có trong lớp [TiffOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/). Ví dụ, phương thức [setImageSize](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/#setImageSize) cho phép bạn xác định kích thước của ảnh kết quả.

Đoạn mã JavaScript này minh họa cách chuyển đổi bản trình bày PowerPoint sang ảnh TIFF với kích thước tùy chỉnh:

```js
// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày (PPT, PPTX, ODP, v.v.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // Đặt loại nén.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    Các loại nén:
        Mặc định - Xác định sơ đồ nén mặc định (LZW).
        Không - Xác định không nén.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Độ sâu phụ thuộc vào loại nén và không thể thiết lập thủ công.

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

Sử dụng phương thức [setPixelFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) từ lớp [TiffOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/), bạn có thể chỉ định định dạng pixel ưa thích cho ảnh TIFF kết quả.

Đoạn mã JavaScript này minh họa cách chuyển đổi bản trình bày PowerPoint sang ảnh TIFF với định dạng pixel tùy chỉnh:

```js
// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày (PPT, PPTX, ODP, v.v.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat chứa các giá trị sau (như được nêu trong tài liệu):
        Format1bppIndexed - 1 bit mỗi pixel, được lập chỉ mục.
        Format4bppIndexed - 4 bit mỗi pixel, được lập chỉ mục.
        Format8bppIndexed - 8 bit mỗi pixel, được lập chỉ mục.
        Format24bppRgb    - 24 bit mỗi pixel, RGB.
        Format32bppArgb   - 32 bit mỗi pixel, ARGB.
    */

    /// Lưu bản trình bày dưới dạng TIFF với kích thước ảnh đã chỉ định.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Kiểm tra công cụ chuyển đổi PowerPoint sang Poster MIỄN PHÍ của Aspose tại [Công cụ chuyển đổi PowerPoint sang Poster MIỄN PHÍ](https://products.aspose.app/slides/vi/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Tôi có thể chuyển đổi một slide riêng lẻ thay vì toàn bộ bản trình bày PowerPoint sang TIFF không?**

Có. Aspose.Slides cho phép bạn chuyển đổi các slide riêng lẻ từ bản trình bày PowerPoint và OpenDocument thành hình ảnh TIFF riêng biệt.

**Có giới hạn nào về số slide khi chuyển đổi một bản trình bày sang TIFF không?**

Không, Aspose.Slides không áp đặt bất kỳ hạn chế nào về số slide. Bạn có thể chuyển đổi bản trình bày có kích thước bất kỳ sang định dạng TIFF.

**Các hoạt ảnh và hiệu ứng chuyển tiếp của PowerPoint có được giữ lại khi chuyển đổi slide sang TIFF không?**

Không, TIFF là định dạng ảnh tĩnh. Do đó, các hoạt ảnh và hiệu ứng chuyển tiếp không được giữ lại; chỉ có những khung hình tĩnh của slide được xuất ra.