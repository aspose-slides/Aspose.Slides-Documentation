---
title: Chuyển đổi bản trình bày PowerPoint sang TIFF trong Java
titlelink: PowerPoint sang TIFF
type: docs
weight: 90
url: /vi/java/convert-powerpoint-to-tiff/
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
- Java
- Aspose.Slides
description: "Tìm hiểu cách dễ dàng chuyển đổi các bản trình bày PowerPoint (PPT, PPTX) sang ảnh TIFF chất lượng cao bằng Aspose.Slides cho Java, kèm theo các ví dụ mã."
---
## **Giới thiệu**

TIFF (**Tagged Image File Format**) là định dạng ảnh raster không mất dữ liệu, được sử dụng rộng rãi, nổi tiếng với chất lượng xuất sắc và khả năng bảo tồn chi tiết đồ họa. Các nhà thiết kế, nhiếp ảnh gia và người xuất bản trên máy tính để bàn thường chọn TIFF để duy trì các lớp, độ chính xác màu và các cài đặt gốc trong ảnh.

Sử dụng Aspose.Slides, bạn có thể dễ dàng chuyển đổi các slide PowerPoint (PPT, PPTX) và slide OpenDocument (ODP) trực tiếp thành ảnh TIFF chất lượng cao, đảm bảo bản trình bày của bạn giữ nguyên độ trung thực hình ảnh tối đa.

## **Chuyển đổi bản trình bày sang TIFF**

Sử dụng phương thức [save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/), bạn có thể nhanh chóng chuyển đổi toàn bộ bản trình bày PowerPoint sang TIFF. Các ảnh TIFF tạo ra tương ứng với kích thước slide mặc định.

Đoạn mã dưới đây minh họa cách chuyển đổi bản trình bày PowerPoint sang TIFF:

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày (PPT, PPTX, ODP, vv).
Presentation presentation = new Presentation("presentation.pptx");
try {
    // Lưu bản trình bày dưới dạng TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Chuyển đổi bản trình bày sang TIFF đen‑trắng**

Phương thức [setBwConversionMode](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) trong lớp [TiffOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tiffoptions/) cho phép bạn chỉ định thuật toán được sử dụng khi chuyển đổi một slide hoặc ảnh màu sang TIFF đen‑trắng. Lưu ý rằng cài đặt này chỉ áp dụng khi phương thức [setCompressionType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) được đặt thành `CCITT4` hoặc `CCITT3`.

{{% alert color="info" title="Lưu ý" %}}

[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) là cài đặt cấp xuất khẩu, chọn thuật toán chuyển đổi pixel cho toàn bộ ảnh TIFF. Để định nghĩa cách một hình dạng riêng lẻ hiển thị khi chế độ hiển thị đen‑trắng được bật, sử dụng [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-). Xem [Control Black-and-White Rendering for Shapes](/java/shape-formatting/#control-black-and-white-rendering-for-shapes) để biết các ví dụ.

{{% /alert %}}

Giả sử chúng ta có tệp "sample.pptx" với slide như sau:

![A presentation slide](slide_black_and_white.png)

Đoạn mã này minh họa cách chuyển đổi slide màu sang TIFF đen‑trắng:

```java
import com.aspose.slides.*;

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

![Black-and-White TIFF](TIFF_black_and_white.png)

## **Chuyển đổi bản trình bày sang TIFF với kích thước tùy chỉnh**

Nếu bạn cần ảnh TIFF có kích thước cụ thể, có thể đặt các giá trị mong muốn bằng các phương pháp có trong [TiffOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tiffoptions/). Ví dụ, phương thức [setImageSize](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) cho phép bạn xác định kích thước của ảnh kết quả.

Đoạn mã dưới đây minh họa cách chuyển đổi bản trình bày PowerPoint sang ảnh TIFF với kích thước tùy chỉnh:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày (PPT, PPTX, ODP, v.v.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // Đặt loại nén.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    Các loại nén:
        Default - Chỉ ra chế độ nén mặc định (LZW).
        None - Chỉ ra không có nén.
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
    tiffOptions.setImageSize(new Dimension(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Lưu bản trình bày dưới dạng TIFF với kích thước đã chỉ định.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **Chuyển đổi bản trình bày sang TIFF với định dạng pixel ảnh tùy chỉnh**

Sử dụng phương thức [setPixelFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) từ lớp [TiffOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tiffoptions/), bạn có thể chỉ định định dạng pixel ưa thích cho ảnh TIFF kết quả.

Đoạn mã này minh họa cách chuyển đổi bản trình bày PowerPoint sang ảnh TIFF với định dạng pixel tùy chỉnh:

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày (PPT, PPTX, ODP, v.v.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat chứa các giá trị sau (như trong tài liệu):
        Format1bppIndexed - 1 bit mỗi pixel, dạng chỉ mục.
        Format4bppIndexed - 4 bit mỗi pixel, dạng chỉ mục.
        Format8bppIndexed - 8 bit mỗi pixel, dạng chỉ mục.
        Format24bppRgb    - 24 bit mỗi pixel, RGB.
        Format32bppArgb   - 32 bit mỗi pixel, ARGB.
    */
    
    // Lưu bản trình bày dưới dạng TIFF với định dạng pixel đã chỉ định.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Mẹo" color="info" %}}

Khám phá công cụ [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/vi/conversion/convert-ppt-to-poster-online) của Aspose.

{{% /alert %}}

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi một slide riêng lẻ thay vì toàn bộ bản trình bày PowerPoint sang TIFF không?**

Có. Aspose.Slides cho phép bạn chuyển đổi các slide riêng lẻ từ bản trình bày PowerPoint và OpenDocument sang ảnh TIFF một cách riêng rẽ.

**Có giới hạn nào về số lượng slide khi chuyển đổi bản trình bày sang TIFF không?**

Không, Aspose.Slides không đặt bất kỳ hạn chế nào về số lượng slide. Bạn có thể chuyển đổi bất kỳ kích thước bản trình bày nào sang định dạng TIFF.

**Các hiệu ứng hoạt hình và chuyển đổi của PowerPoint có được giữ lại khi chuyển đổi slide sang TIFF không?**

Không, TIFF là định dạng ảnh tĩnh. Do đó, các hoạt hình và hiệu ứng chuyển đổi không được giữ lại; chỉ có các ảnh chụp tĩnh của slide được xuất.