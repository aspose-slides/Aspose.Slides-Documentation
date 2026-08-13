---
title: Chuyển đổi bản trình bày PowerPoint sang TIFF có ghi chú trong C++
linktitle: PowerPoint sang TIFF có ghi chú
type: docs
weight: 100
url: /vi/cpp/convert-powerpoint-to-tiff-with-notes/
keywords:
- chuyển đổi PowerPoint
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
- PowerPoint có ghi chú
- bản trình bày có ghi chú
- slide có ghi chú
- PPT có ghi chú
- PPTX có ghi chú
- TIFF có ghi chú
- C++
- Aspose.Slides
description: "Chuyển đổi các bản trình bày PowerPoint sang TIFF có ghi chú bằng Aspose.Slides cho C++. Tìm hiểu cách xuất slide kèm ghi chú diễn giả một cách hiệu quả."
---
## **Giới thiệu**

Aspose.Slides for C++ cung cấp một giải pháp đơn giản để chuyển đổi các bản trình bày PowerPoint và OpenDocument (PPT, PPTX và ODP) có ghi chú sang định dạng TIFF. Định dạng này được sử dụng rộng rãi cho việc lưu trữ hình ảnh chất lượng cao, in ấn và lưu trữ tài liệu. Với Aspose.Slides, bạn không chỉ có thể xuất toàn bộ bản trình bày kèm ghi chú diễn giả mà còn tạo các hình thu nhỏ của slide trong chế độ Notes Slide. Quá trình chuyển đổi đơn giản và hiệu quả, sử dụng phương thức `Save` của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) để biến toàn bộ bản trình bày thành một loạt các hình ảnh TIFF trong khi giữ lại ghi chú và bố cục.

## **Chuyển đổi bản trình bày sang TIFF với ghi chú**

Lưu một bản trình bày PowerPoint hoặc OpenDocument sang TIFF có ghi chú bằng Aspose.Slides for C++ bao gồm các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/): tải tệp PowerPoint hoặc OpenDocument.
1. Cấu hình các tùy chọn bố cục đầu ra: sử dụng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/notescommentslayoutingoptions/) để chỉ định cách hiển thị ghi chú và bình luận.
1. Lưu bản trình bày dưới dạng TIFF: truyền các tùy chọn đã cấu hình vào phương thức [Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/).

Giả sử chúng ta có tệp "speaker_notes.pptx" với slide sau:

![Slide trình bày có ghi chú diễn giả](slide_with_notes.png)

Đoạn mã dưới đây minh họa cách chuyển đổi bản trình bày sang ảnh TIFF trong chế độ Notes Slide bằng phương thức [set_SlidesLayoutOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/).

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Hiển thị ghi chú phía dưới slide.

// Configure the TIFF options with Notes layouting.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to TIFF with the speaker notes.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Kết quả:

![Ảnh TIFF có ghi chú diễn giả](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Xem công cụ **Free PowerPoint to Poster Converter** của Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/vi/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Câu hỏi thường gặp**

### Tôi có thể kiểm soát vị trí của vùng ghi chú trong TIFF kết quả không?

Có. Sử dụng [notes layout settings](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) để chọn giữa các tùy chọn như `None`, `BottomTruncated` hoặc `BottomFull`, tương ứng ẩn ghi chú, căn chỉnh chúng vào một trang duy nhất, hoặc cho phép chúng chảy sang các trang bổ sung.

### Làm sao giảm kích thước của tệp TIFF có ghi chú mà không làm mất chất lượng đáng kể?

Chọn một [efficient compression](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (ví dụ `LZW` hoặc `RLE`), đặt DPI hợp lý và, nếu chấp nhận được, sử dụng một [pixel format](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) thấp hơn (như 8 bpp hoặc 1 bpp cho đen trắng). Việc giảm nhẹ [image dimensions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/set_imagesize/) cũng có thể giúp mà không ảnh hưởng đáng chú ý đến độ dễ đọc.

### Phông chữ trong ghi chú có ảnh hưởng đến kết quả nếu hệ thống thiếu phông chữ gốc không?

Có. Các phông chữ thiếu kích hoạt [substitution](/slides/vi/cpp/font-selection-sequence/), có thể làm thay đổi kích thước và giao diện văn bản. Để tránh điều này, [supply the required fonts](/slides/vi/cpp/custom-font/) hoặc đặt một [fallback font](/slides/vi/cpp/fallback-font/) mặc định để sử dụng các kiểu chữ mong muốn.