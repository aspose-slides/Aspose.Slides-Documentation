---
title: Chuyển đổi bản trình chiếu PowerPoint sang TIFF trên Android
titlelink: PowerPoint sang TIFF
type: docs
weight: 90
url: /vi/androidjava/convert-powerpoint-to-tiff/
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
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách dễ dàng chuyển đổi bản trình chiếu PowerPoint (PPT, PPTX) sang ảnh TIFF chất lượng cao bằng Aspose.Slides cho Android, kèm theo các ví dụ mã Java."
---
## **Giới thiệu**

TIFF (**Tagged Image File Format**) là một định dạng ảnh raster không mất dữ liệu được sử dụng rộng rãi, nổi tiếng với chất lượng xuất sắc và việc bảo tồn chi tiết đồ họa. Các nhà thiết kế, nhiếp ảnh gia và người soạn thảo desktop thường chọn TIFF để duy trì các lớp, độ chính xác màu và các cài đặt gốc trong hình ảnh của họ.

Sử dụng Aspose.Slides, bạn có thể dễ dàng chuyển đổi các slide PowerPoint (PPT, PPTX) và các slide OpenDocument (ODP) trực tiếp thành ảnh TIFF chất lượng cao, đảm bảo bản trình chiếu của bạn giữ được độ trung thực hình ảnh tối đa. 

## **Chuyển đổi bản trình chiếu sang TIFF**

Sử dụng phương thức [save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/), bạn có thể nhanh chóng chuyển đổi toàn bộ bản trình chiếu PowerPoint sang TIFF. Các ảnh TIFF kết quả tương ứng với kích thước slide mặc định.

Mã sau minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang TIFF:

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu (PPT, PPTX, ODP, v.v.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    // Lưu bản trình chiếu dưới dạng TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Chuyển đổi bản trình chiếu sang TIFF đen trắng**

Phương thức [setBwConversionMode](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) trong lớp [TiffOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/) cho phép bạn chỉ định thuật toán được sử dụng khi chuyển đổi một slide hoặc hình ảnh màu sang TIFF đen trắng. Lưu ý rằng cài đặt này chỉ áp dụng khi phương thức [setCompressionType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) được đặt thành `CCITT4` hoặc `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) là một cài đặt cấp xuất cho phép lựa chọn thuật toán chuyển đổi pixel cho toàn bộ ảnh TIFF. Để định nghĩa cách một hình dạng riêng lẻ xuất hiện khi chế độ hiển thị đen trắng được kích hoạt, hãy sử dụng [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-). Xem [Control Black-and-White Rendering for Shapes](/androidjava/shape-formatting/#control-black-and-white-rendering-for-shapes) để biết ví dụ.
{{% /alert %}}

Giả sử chúng ta có file "sample.pptx" với slide sau:

![Slide trình chiếu](slide_black_and_white.png)

Mã sau minh họa cách chuyển đổi slide màu sang TIFF đen trắng:

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

![TIFF đen trắng](TIFF_black_and_white.png)

## **Chuyển đổi bản trình chiếu sang TIFF với kích thước tùy chỉnh**

Nếu bạn cần một ảnh TIFF có kích thước cụ thể, có thể đặt giá trị mong muốn bằng các phương thức có sẵn trong [TiffOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/). Ví dụ, phương thức [setImageSize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) cho phép bạn xác định kích thước của ảnh kết quả.

Mã sau minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang ảnh TIFF với kích thước tùy chỉnh:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu (PPT, PPTX, ODP, v.v.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // Đặt loại nén.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    Các loại nén:
        Default - Chỉ định sơ đồ nén mặc định (LZW).
        None - Không có nén.
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

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Lưu bản trình chiếu dưới dạng TIFF với kích thước đã chỉ định.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **Chuyển đổi bản trình chiếu sang TIFF với định dạng pixel hình ảnh tùy chỉnh**

Sử dụng phương thức [setPixelFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) từ lớp [TiffOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/), bạn có thể chỉ định định dạng pixel ưa thích cho ảnh TIFF kết quả.

Mã sau minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang ảnh TIFF với định dạng pixel tùy chỉnh:

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu (PPT, PPTX, ODP, v.v.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat chứa các giá trị sau (theo tài liệu):
        Format1bppIndexed - 1 bit mỗi pixel, dạng chỉ mục.
        Format4bppIndexed - 4 bit mỗi pixel, dạng chỉ mục.
        Format8bppIndexed - 8 bit mỗi pixel, dạng chỉ mục.
        Format24bppRgb    - 24 bit mỗi pixel, RGB.
        Format32bppArgb   - 32 bit mỗi pixel, ARGB.
    */
    
    // Lưu bản trình chiếu dưới dạng TIFF với định dạng pixel đã chỉ định.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
Hãy xem công cụ chuyển đổi PowerPoint sang Poster MIỄN PHÍ của Aspose tại [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/vi/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi một slide riêng lẻ thay vì toàn bộ bản trình chiếu PowerPoint sang TIFF không?**

Có. Aspose.Slides cho phép bạn chuyển đổi các slide riêng lẻ từ bản trình chiếu PowerPoint và OpenDocument thành ảnh TIFF một cách độc lập.

**Có bất kỳ hạn chế nào về số lượng slide khi chuyển đổi bản trình chiếu sang TIFF không?**

Không, Aspose.Slides không đặt bất kỳ giới hạn nào về số lượng slide. Bạn có thể chuyển đổi bản trình chiếu có kích thước bất kỳ sang định dạng TIFF.

**Các hiệu ứng hoạt ảnh và chuyển đổi của PowerPoint có được bảo tồn khi chuyển đổi slide sang TIFF không?**

Không, TIFF là định dạng ảnh tĩnh. Do đó, các hoạt ảnh và hiệu ứng chuyển đổi sẽ không được bảo tồn; chỉ có ảnh chụp tĩnh của các slide được xuất ra.