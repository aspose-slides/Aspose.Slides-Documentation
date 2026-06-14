---
title: Chuyển đổi Bản trình bày PowerPoint sang TIFF trên Android
titlelink: PowerPoint sang TIFF
type: docs
weight: 90
url: /vi/androidjava/convert-powerpoint-to-tiff/
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
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách dễ dàng chuyển đổi các bản trình bày PowerPoint (PPT, PPTX) sang hình ảnh TIFF chất lượng cao bằng Aspose.Slides cho Android, kèm theo các ví dụ mã Java."
---
## **Giới thiệu**

TIFF (**Tagged Image File Format**) là một định dạng ảnh raster không mất dữ liệu được sử dụng rộng rãi, nổi tiếng với chất lượng xuất sắc và khả năng bảo tồn chi tiết đồ họa. Các nhà thiết kế, nhiếp ảnh gia và nhà xuất bản trên máy tính để bàn thường chọn TIFF để duy trì các lớp, độ chính xác màu và cài đặt gốc trong ảnh của họ.

Bằng cách sử dụng Aspose.Slides, bạn có thể dễ dàng chuyển đổi các slide PowerPoint (PPT, PPTX) và các slide OpenDocument (ODP) trực tiếp thành hình ảnh TIFF chất lượng cao, đảm bảo bản trình bày của bạn giữ được độ trung thực hình ảnh tối đa. 

## **Chuyển đổi bản trình bày sang TIFF**

Sử dụng phương thức [save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/), bạn có thể nhanh chóng chuyển đổi toàn bộ bản trình bày PowerPoint sang TIFF. Các hình ảnh TIFF kết quả tương ứng với kích thước slide mặc định.

Đoạn mã này minh họa cách chuyển đổi bản trình bày PowerPoint sang TIFF:

```java
// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày (PPT, PPTX, ODP, v.v.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    // Lưu bản trình bày dưới dạng TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Chuyển đổi bản trình bày sang TIFF Đen và Trắng**

Phương thức [setBwConversionMode](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) trong lớp [TiffOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/) cho phép bạn chỉ định thuật toán được sử dụng khi chuyển đổi một slide hoặc ảnh màu sang TIFF đen và trắng. Lưu ý rằng cài đặt này chỉ áp dụng khi phương thức [setCompressionType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) được đặt thành `CCITT4` hoặc `CCITT3`.

Giả sử chúng ta có tệp "sample.pptx" với slide sau:

![Slide trình bày](slide_black_and_white.png)

Đoạn mã này minh họa cách chuyển đổi slide màu sang TIFF đen và trắng:

```java
TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setCompressionType(TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(BlackWhiteConversionMode.Dithering);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Kết quả:

![TIFF Đen và Trắng](TIFF_black_and_white.png)

## **Chuyển đổi bản trình bày sang TIFF với Kích thước Tùy chỉnh**

Nếu bạn cần hình ảnh TIFF với kích thước cụ thể, bạn có thể đặt các giá trị mong muốn bằng cách sử dụng các phương thức có sẵn trong [TiffOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/). Ví dụ, phương thức [setImageSize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) cho phép bạn xác định kích thước của hình ảnh kết quả.

Đoạn mã này minh họa cách chuyển đổi bản trình bày PowerPoint sang hình ảnh TIFF với kích thước tùy chỉnh:

```java
// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày (PPT, PPTX, ODP, v.v.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // Đặt loại nén.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    Các loại nén:
        Default - Chỉ định sơ đồ nén mặc định (LZW).
        None - Chỉ định không nén.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Độ sâu phụ thuộc vào loại nén và không thể đặt thủ công.

    // Đặt DPI cho hình ảnh.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Đặt kích thước hình ảnh.
    tiffOptions.setImageSize(new Size(1728, 1078));

    INotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Lưu bản trình bày dưới dạng TIFF với kích thước đã chỉ định.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **Chuyển đổi bản trình bày sang TIFF với Định dạng Pixel Hình ảnh Tùy chỉnh**

Bằng cách sử dụng phương thức [setPixelFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) từ lớp [TiffOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/), bạn có thể chỉ định định dạng pixel ưa thích cho hình ảnh TIFF kết quả.

Đoạn mã này minh họa cách chuyển đổi bản trình bày PowerPoint sang hình ảnh TIFF với định dạng pixel tùy chỉnh:

```java
// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày (PPT, PPTX, ODP, v.v.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat contains the following values (as stated in the documentation):
        Format1bppIndexed - 1 bit mỗi pixel, được đánh chỉ mục.
        Format4bppIndexed - 4 bit mỗi pixel, được đánh chỉ mục.
        Format8bppIndexed - 8 bit mỗi pixel, được đánh chỉ mục.
        Format24bppRgb    - 24 bit mỗi pixel, RGB.
        Format32bppArgb   - 32 bit mỗi pixel, ARGB.
    */
    
    // Lưu bản trình bày dưới dạng TIFF với kích thước hình ảnh đã chỉ định.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Khám phá [bộ chuyển đổi PowerPoint sang Poster MIỄN PHÍ của Aspose](https://products.aspose.app/slides/vi/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi một slide riêng lẻ thay vì toàn bộ bản trình bày PowerPoint sang TIFF không?**

Có. Aspose.Slides cho phép bạn chuyển đổi các slide riêng lẻ từ bản trình bày PowerPoint và OpenDocument thành các hình ảnh TIFF riêng biệt.

**Có giới hạn nào về số slide khi chuyển đổi bản trình bày sang TIFF không?**

Không, Aspose.Slides không áp đặt bất kỳ giới hạn nào về số slide. Bạn có thể chuyển đổi bản trình bày có kích thước bất kỳ sang định dạng TIFF.

**Các hiệu ứng hoạt ảnh và chuyển tiếp của PowerPoint có được giữ lại khi chuyển đổi slide sang TIFF không?**

Không, TIFF là định dạng hình ảnh tĩnh. Do đó, các hiệu ứng hoạt ảnh và chuyển tiếp không được giữ lại; chỉ các hình ảnh tĩnh của slide được xuất.