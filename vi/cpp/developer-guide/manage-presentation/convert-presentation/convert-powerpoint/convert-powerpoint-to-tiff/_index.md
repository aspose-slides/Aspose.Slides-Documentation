---
title: Chuyển đổi Bản trình chiếu PowerPoint sang TIFF trong C++
titlelink: PowerPoint sang TIFF
type: docs
weight: 90
url: /vi/cpp/convert-powerpoint-to-tiff/
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
- C++
- Aspose.Slides
description: "Tìm hiểu cách dễ dàng chuyển đổi các bản trình chiếu PowerPoint (PPT, PPTX) sang hình ảnh TIFF chất lượng cao bằng Aspose.Slides cho C++, kèm ví dụ mã."
---
## **Giới thiệu**

TIFF (**Tagged Image File Format**) là một định dạng ảnh raster không mất dữ liệu, được sử dụng rộng rãi và nổi tiếng với chất lượng tuyệt vời cùng khả năng bảo toàn chi tiết đồ họa. Các nhà thiết kế, nhiếp ảnh gia và nhà xuất bản trên máy tính thường chọn TIFF để duy trì các lớp, độ chính xác màu và các cài đặt gốc trong hình ảnh của họ.

Sử dụng Aspose.Slides, bạn có thể dễ dàng chuyển đổi các slide PowerPoint (PPT, PPTX) và slide OpenDocument (ODP) trực tiếp thành các hình ảnh TIFF chất lượng cao, đảm bảo bài thuyết trình của bạn giữ được độ trung thực hình ảnh tối đa.

## **Chuyển đổi bản trình bày sang TIFF**

Sử dụng phương thức [Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/) được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/), bạn có thể nhanh chóng chuyển đổi toàn bộ bản trình bày PowerPoint sang TIFF. Các hình ảnh TIFF tạo ra tương ứng với kích thước slide mặc định.

Đoạn mã C++ sau minh họa cách chuyển đổi bản trình bày PowerPoint sang TIFF:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu (PPT, PPTX, ODP, v.v.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Lưu bản trình chiếu dưới dạng TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Chuyển đổi bản trình bày sang TIFF đen và trắng**

Phương thức [set_BwConversionMode](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) trong lớp [TiffOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/) cho phép bạn chỉ định thuật toán được sử dụng khi chuyển đổi một slide hoặc hình ảnh màu sang TIFF đen và trắng. Lưu ý rằng thiết lập này chỉ áp dụng khi phương thức [set_CompressionType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) được đặt thành `CCITT4` hoặc `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions::set_BwConversionMode](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) là một thiết lập mức xuất khẩu cho phép chọn thuật toán chuyển đổi pixel cho toàn bộ ảnh TIFF. Để định nghĩa cách một hình dạng riêng lẻ hiển thị khi chế độ hiển thị đen và trắng được bật, hãy sử dụng [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/set_blackwhitemode/). Xem [Control Black-and-White Rendering for Shapes](/slides/vi/cpp/shape-formatting/#control-black-and-white-rendering-for-shapes) để biết ví dụ.
{{% /alert %}}

Giả sử chúng ta có một tệp "sample.pptx" với slide sau:

![Slide bản trình bày](slide_black_and_white.png)

Đoạn mã C++ sau minh họa cách chuyển đổi slide màu sang TIFF đen và trắng:

```cpp
#include <DOM/Presentation.h>
#include <Export/BlackWhiteConversionMode.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Kết quả:

![TIFF đen và trắng](TIFF_black_and_white.png)

## **Chuyển đổi bản trình bày sang TIFF với kích thước tùy chỉnh**

Nếu bạn cần một ảnh TIFF với kích thước cụ thể, bạn có thể đặt các giá trị mong muốn bằng các phương thức có trong [TiffOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/). Ví dụ, phương thức [set_ImageSize](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/set_imagesize/) cho phép bạn xác định kích thước của ảnh kết quả.

Đoạn mã C++ sau minh họa cách chuyển đổi bản trình bày PowerPoint sang các ảnh TIFF với kích thước tùy chỉnh:

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu (PPT, PPTX, ODP, v.v.).
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Đặt loại nén.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
Các loại nén:
    Default - Chỉ định phương án nén mặc định (LZW).
    None - Chỉ định không nén.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// Độ sâu phụ thuộc vào loại nén và không thể đặt thủ công.

// Đặt DPI cho ảnh.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// Đặt kích thước ảnh.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Lưu bản trình chiếu dưới dạng TIFF với kích thước đã chỉ định.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **Chuyển đổi bản trình bày sang TIFF với Định dạng Pixel ảnh tùy chỉnh**

Sử dụng phương thức [set_PixelFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) từ lớp [TiffOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/), bạn có thể chỉ định định dạng pixel ưa thích cho ảnh TIFF kết quả.

Đoạn mã C++ sau minh họa cách chuyển đổi bản trình bày PowerPoint sang ảnh TIFF với định dạng pixel tùy chỉnh:

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu (PPT, PPTX, ODP, v.v.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat chứa các giá trị sau (theo tài liệu):
    Format1bppIndexed - 1 bit mỗi pixel, dạng chỉ mục.
    Format4bppIndexed - 4 bit mỗi pixel, dạng chỉ mục.
    Format8bppIndexed - 8 bit mỗi pixel, dạng chỉ mục.
    Format24bppRgb    - 24 bit mỗi pixel, RGB.
    Format32bppArgb   - 32 bit mỗi pixel, ARGB.
*/

// Lưu bản trình chiếu dưới dạng TIFF với kích thước ảnh đã chỉ định.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Tip" color="info" %}}
Khám phá công cụ chuyển đổi PowerPoint sang Poster MIỄN PHÍ của Aspose tại [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/vi/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi một slide riêng lẻ thay vì toàn bộ bản trình bày PowerPoint sang TIFF không?**

Có. Aspose.Slides cho phép bạn chuyển đổi các slide riêng lẻ từ bản trình bày PowerPoint và OpenDocument thành các ảnh TIFF một cách riêng biệt.

**Có giới hạn nào về số lượng slide khi chuyển đổi bản trình bày sang TIFF không?**

Không, Aspose.Slides không áp đặt bất kỳ hạn chế nào về số lượng slide. Bạn có thể chuyển đổi bản trình bày có kích thước bất kỳ sang định dạng TIFF.

**Các hiệu ứng hoạt ảnh và chuyển tiếp của PowerPoint có được giữ lại khi chuyển đổi slide sang TIFF không?**

Không, TIFF là định dạng ảnh tĩnh. Do đó, các hoạt ảnh và hiệu ứng chuyển tiếp không được giữ lại; chỉ các ảnh chụp tĩnh của slide được xuất.