---
title: Chuyển đổi Bản trình bày PowerPoint sang TIFF trong .NET
titlelink: PowerPoint sang TIFF
type: docs
weight: 90
url: /vi/net/convert-powerpoint-to-tiff/
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
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách dễ dàng chuyển đổi các bản trình bày PowerPoint (PPT, PPTX) sang hình ảnh TIFF chất lượng cao bằng Aspose.Slides cho .NET. Các ví dụ mã C#."
---
## **Giới thiệu**

TIFF (**Tagged Image File Format**) là một định dạng ảnh raster không mất dữ liệu, được sử dụng rộng rãi và nổi tiếng với chất lượng xuất sắc cùng việc bảo tồn chi tiết đồ họa. Các nhà thiết kế, nhiếp ảnh gia và người xuất bản trên máy tính để bàn thường chọn TIFF để giữ lại các lớp, độ chính xác màu và các cài đặt gốc trong ảnh của họ.

Sử dụng Aspose.Slides, bạn có thể dễ dàng chuyển đổi các slide PowerPoint (PPT, PPTX) và slide OpenDocument (ODP) trực tiếp thành ảnh TIFF chất lượng cao, đảm bảo bài thuyết trình của bạn giữ được độ trung thực hình ảnh tối đa. 

## **Chuyển đổi bản trình bày sang TIFF**

Bằng cách sử dụng phương thức [Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/) được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/), bạn có thể nhanh chóng chuyển đổi toàn bộ bản trình bày PowerPoint sang TIFF. Các ảnh TIFF được tạo ra tương ứng với kích thước slide mặc định.

Đoạn mã C# này minh họa cách chuyển đổi một bản trình bày PowerPoint sang TIFF:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày (PPT, PPTX, ODP, v.v.).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // Lưu bản trình bày dưới dạng TIFF.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **Chuyển đổi bản trình bày sang TIFF đen‑trắng**

Thuộc tính [BwConversionMode](https://reference.aspose.com/slides/vi/net/aspose.slides.export/tiffoptions/bwconversionmode/) trong lớp [TiffOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/tiffoptions/) cho phép bạn chỉ định thuật toán được sử dụng khi chuyển đổi một slide hoặc hình ảnh màu sang TIFF đen‑trắng. Lưu ý rằng cài đặt này chỉ áp dụng khi thuộc tính [CompressionType](https://reference.aspose.com/slides/vi/net/aspose.slides.export/tiffoptions/compressiontype/) được đặt thành `CCITT4` hoặc `CCITT3`.

Giả sử chúng ta có tệp "sample.pptx" với slide sau:

![Một slide bản trình bày](slide_black_and_white.png)

Đoạn mã C# này minh họa cách chuyển đổi slide màu sang TIFF đen‑trắng:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

TiffOptions tiffOptions = new TiffOptions
{
    CompressionType = TiffCompressionTypes.CCITT4,
    BwConversionMode = BlackWhiteConversionMode.Dithering
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    presentation.Save("output.tiff", SaveFormat.Tiff, tiffOptions);
}
```

Kết quả:

![TIFF đen‑trắng](TIFF_black_and_white.png)

## **Chuyển đổi bản trình bày sang TIFF với kích thước tùy chỉnh**

Nếu bạn cần một ảnh TIFF với kích thước cụ thể, bạn có thể đặt các giá trị mong muốn bằng cách sử dụng các thuộc tính có trong [TiffOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/tiffoptions/). Ví dụ, thuộc tính [ImageSize](https://reference.aspose.com/slides/vi/net/aspose.slides.export/tiffoptions/imagesize/) cho phép bạn xác định kích thước của ảnh kết quả.

Đoạn mã C# này minh họa cách chuyển đổi một bản trình bày PowerPoint sang ảnh TIFF với kích thước tùy chỉnh:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày (PPT, PPTX, ODP, v.v.).
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // Đặt loại nén.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    Các loại nén:
        Default - Xác định chuỗi nén mặc định (LZW).
        None - Không nén.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Độ sâu phụ thuộc vào loại nén và không thể đặt thủ công.

    // Đặt DPI cho ảnh.
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // Đặt kích thước ảnh.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // Lưu bản trình bày dưới dạng TIFF với kích thước đã chỉ định.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **Chuyển đổi bản trình bày sang TIFF với định dạng pixel hình ảnh tùy chỉnh**

Bằng cách sử dụng thuộc tính [PixelFormat](https://reference.aspose.com/slides/vi/net/aspose.slides.export/tiffoptions/pixelformat/) từ lớp [TiffOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/tiffoptions), bạn có thể chỉ định định dạng pixel ưa thích cho ảnh TIFF kết quả.

Đoạn mã C# này minh họa cách chuyển đổi một bản trình bày PowerPoint sang ảnh TIFF với định dạng pixel tùy chỉnh:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày (PPT, PPTX, ODP, v.v.).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat chứa các giá trị sau (theo tài liệu):
        Format1bppIndexed - 1 bit mỗi pixel, dạng chỉ mục.
        Format4bppIndexed - 4 bit mỗi pixel, dạng chỉ mục.
        Format8bppIndexed - 8 bit mỗi pixel, dạng chỉ mục.
        Format24bppRgb    - 24 bit mỗi pixel, RGB.
        Format32bppArgb   - 32 bit mỗi pixel, ARGB.
    */

    // Lưu bản trình bày dưới dạng TIFF với kích thước ảnh đã chỉ định.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tip" color="info" %}}
Hãy xem công cụ [MIỄN PHÍ chuyển đổi PowerPoint sang Poster](https://products.aspose.app/slides/vi/conversion/convert-ppt-to-poster-online) của Aspose.
{{% /alert %}}

## **Câu hỏi thường gặp**

### Tôi có thể chuyển đổi một slide riêng lẻ thay vì toàn bộ bản trình bày PowerPoint sang TIFF không?

Có. Aspose.Slides cho phép bạn chuyển đổi các slide riêng lẻ từ bản trình bày PowerPoint và OpenDocument thành các ảnh TIFF một cách độc lập.

### Có giới hạn nào về số lượng slide khi chuyển đổi bản trình bày sang TIFF không?

Không, Aspose.Slides không áp đặt bất kỳ hạn chế nào về số lượng slide. Bạn có thể chuyển đổi bản trình bày có kích thước bất kỳ sang định dạng TIFF.

### Các hoạt ảnh và hiệu ứng chuyển tiếp của PowerPoint có được giữ lại khi chuyển đổi slide sang TIFF không?

Không, TIFF là một định dạng ảnh tĩnh. Do đó, các hoạt ảnh và hiệu ứng chuyển tiếp không được giữ lại; chỉ các ảnh tĩnh của slide được xuất ra.