---
title: Chuyển đổi bản trình bày PowerPoint sang TIFF trong C++
titlelink: PowerPoint sang TIFF
type: docs
weight: 90
url: /vi/cpp/convert-powerpoint-to-tiff/
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
- C++
- Aspose.Slides
description: "Tìm hiểu cách dễ dàng chuyển đổi các bản trình bày PowerPoint (PPT, PPTX) sang hình ảnh TIFF chất lượng cao bằng Aspose.Slides cho C++, kèm ví dụ mã."
---
## **Giới thiệu**

TIFF (**Tagged Image File Format**) là một định dạng ảnh raster không mất dữ liệu, được sử dụng rộng rãi và nổi tiếng với chất lượng xuất sắc cũng như khả năng bảo tồn chi tiết đồ họa. Các nhà thiết kế, nhiếp ảnh gia và nhà xuất bản trên máy tính để bàn thường chọn TIFF để duy trì các lớp, độ chính xác màu và các cài đặt gốc trong ảnh của họ.

Sử dụng Aspose.Slides, bạn có thể dễ dàng chuyển đổi các slide PowerPoint (PPT, PPTX) và các slide OpenDocument (ODP) trực tiếp thành các ảnh TIFF chất lượng cao, đảm bảo bản trình bày của bạn giữ nguyên độ trung thực hình ảnh tối đa.

## **Chuyển đổi bản trình bày sang TIFF**

Sử dụng phương thức [Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/) được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/), bạn có thể nhanh chóng chuyển đổi toàn bộ bản trình bày PowerPoint sang TIFF. Các ảnh TIFF tạo ra tương ứng với kích thước slide mặc định.

Mã C++ dưới đây minh họa cách chuyển đổi một bản trình bày PowerPoint sang TIFF:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày (PPT, PPTX, ODP, v.v.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Save the presentation as TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Chuyển đổi bản trình bày sang TIFF đen trắng**

Phương thức [set_BwConversionMode](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) trong lớp [TiffOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/) cho phép bạn chỉ định thuật toán được sử dụng khi chuyển đổi một slide hoặc ảnh màu sang TIFF đen trắng. Lưu ý rằng cài đặt này chỉ áp dụng khi phương thức [set_CompressionType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) được đặt thành `CCITT4` hoặc `CCITT3`.

{{% alert color="info" title="Lưu ý" %}}
[TiffOptions::set_BwConversionMode](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) là một cài đặt ở mức xuất khẩu cho phép chọn thuật toán chuyển đổi pixel cho toàn bộ ảnh TIFF. Để xác định cách một hình dạng riêng lẻ hiển thị khi chế độ hiển thị đen trắng được bật, hãy sử dụng [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/set_blackwhitemode/). Xem [Control Black-and-White Rendering for Shapes](/cpp/shape-formatting/#control-black-and-white-rendering-for-shapes) để biết ví dụ.
{{% /alert %}}

Giả sử chúng ta có tệp "sample.pptx" với slide sau:

![Một slide trình bày](slide_black_and_white.png)

Mã C++ dưới đây minh họa cách chuyển đổi slide màu sang TIFF đen trắng:

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

![TIFF đen trắng](TIFF_black_and_white.png)

## **Chuyển đổi bản trình bày sang TIFF với kích thước tùy chỉnh**

Nếu bạn cần một ảnh TIFF có kích thước cụ thể, bạn có thể đặt các giá trị mong muốn bằng các phương thức có sẵn trong [TiffOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/). Ví dụ, phương thức [set_ImageSize](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/set_imagesize/) cho phép bạn xác định kích thước của ảnh kết quả.

Mã C++ dưới đây minh họa cách chuyển đổi một bản trình bày PowerPoint sang các ảnh TIFF với kích thước tùy chỉnh:

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

// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày (PPT, PPTX, ODP, v.v.).
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

// Đặt DPI ảnh.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// Đặt kích thước ảnh.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Lưu bản trình bày dưới dạng TIFF với kích thước đã chỉ định.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **Chuyển đổi bản trình bày sang TIFF với Định dạng Pixel ảnh tùy chỉnh**

Sử dụng phương thức [set_PixelFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) từ lớp [TiffOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/), bạn có thể chỉ định định dạng pixel ưa thích cho ảnh TIFF kết quả.

Mã C++ dưới đây minh họa cách chuyển đổi một bản trình bày PowerPoint sang ảnh TIFF với định dạng pixel tùy chỉnh:

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày (PPT, PPTX, ODP, v.v.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat chứa các giá trị sau (theo tài liệu):
    Format1bppIndexed - 1 bit cho mỗi pixel, kiểu chỉ mục.
    Format4bppIndexed - 4 bit cho mỗi pixel, kiểu chỉ mục.
    Format8bppIndexed - 8 bit cho mỗi pixel, kiểu chỉ mục.
    Format24bppRgb    - 24 bit cho mỗi pixel, RGB.
    Format32bppArgb   - 32 bit cho mỗi pixel, ARGB.
*/

// Lưu bản trình bày dưới dạng TIFF với kích thước ảnh đã chỉ định.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Mẹo" color="info" %}}
Khám phá công cụ [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/vi/conversion/convert-ppt-to-poster-online) của Aspose.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi một slide riêng lẻ thay vì toàn bộ bản trình bày PowerPoint sang TIFF không?**

Có. Aspose.Slides cho phép bạn chuyển đổi các slide riêng lẻ từ các bản trình bày PowerPoint và OpenDocument thành các ảnh TIFF một cách riêng biệt.

**Có bất kỳ giới hạn nào về số lượng slide khi chuyển đổi bản trình bày sang TIFF không?**

Không, Aspose.Slides không đặt bất kỳ giới hạn nào về số lượng slide. Bạn có thể chuyển đổi các bản trình bày có kích thước bất kỳ sang định dạng TIFF.

**Các hiệu ứng hoạt ảnh và chuyển đổi của PowerPoint có được giữ lại khi chuyển đổi slide sang TIFF không?**

Không, TIFF là định dạng ảnh tĩnh. Do đó, các hoạt ảnh và hiệu ứng chuyển đổi không được giữ lại; chỉ có các ảnh tĩnh của slide được xuất ra.