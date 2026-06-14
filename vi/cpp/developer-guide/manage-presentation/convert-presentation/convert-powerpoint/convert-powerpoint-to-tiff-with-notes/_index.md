---
title: Chuyển đổi bản trình chiếu PowerPoint sang TIFF có ghi chú trong C++
linktitle: PowerPoint sang TIFF có ghi chú
type: docs
weight: 100
url: /vi/cpp/convert-powerpoint-to-tiff-with-notes/
keywords:
- chuyển đổi PowerPoint
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
- PowerPoint có ghi chú
- bản trình chiếu có ghi chú
- slide có ghi chú
- PPT có ghi chú
- PPTX có ghi chú
- TIFF có ghi chú
- C++
- Aspose.Slides
description: "Chuyển đổi bản trình chiếu PowerPoint sang TIFF có ghi chú bằng Aspose.Slides cho C++. Tìm hiểu cách xuất slide có ghi chú người nói một cách hiệu quả."
---
## **Giới thiệu**

Aspose.Slides for C++ cung cấp một giải pháp đơn giản để chuyển đổi các bản trình chiếu PowerPoint và OpenDocument (PPT, PPTX và ODP) có ghi chú sang định dạng TIFF. Định dạng này được sử dụng rộng rãi cho việc lưu trữ hình ảnh chất lượng cao, in ấn và lưu trữ tài liệu. Với Aspose.Slides, bạn không chỉ có thể xuất toàn bộ bản trình chiếu cùng ghi chú người nói mà còn tạo ra các hình thu nhỏ của slide trong chế độ Notes Slide. Quá trình chuyển đổi đơn giản và hiệu quả, sử dụng phương thức `Save` của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) để biến toàn bộ bản trình chiếu thành một loạt các hình ảnh TIFF trong khi giữ nguyên ghi chú và bố cục.

## **Chuyển đổi bản trình chiếu sang TIFF có ghi chú**

Lưu một bản trình chiếu PowerPoint hoặc OpenDocument sang TIFF có ghi chú bằng Aspose.Slides for C++ bao gồm các bước sau:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/): tải tệp PowerPoint hoặc OpenDocument.
1. Cấu hình các tùy chọn bố cục đầu ra: sử dụng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/notescommentslayoutingoptions/) để chỉ định cách hiển thị ghi chú và bình luận.
1. Lưu bản trình chiếu dưới dạng TIFF: truyền các tùy chọn đã cấu hình vào phương thức [Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/).

Giả sử chúng ta có tệp "speaker_notes.pptx" với slide sau:

![The presentation slide with speaker notes](slide_with_notes.png)

Đoạn mã dưới đây minh họa cách chuyển đổi bản trình chiếu thành ảnh TIFF trong chế độ Notes Slide bằng phương thức [set_SlidesLayoutOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/).

```cpp
// Tạo một thể hiện của lớp Presentation đại diện cho tệp trình chiếu.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Hiển thị ghi chú phía dưới slide.

// Cấu hình các tùy chọn TIFF với bố cục ghi chú.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to TIFF with the speaker notes.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Kết quả:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Xem Aspose Free PowerPoint to Poster Converter(https://products.aspose.app/slides/vi/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Tôi có thể kiểm soát vị trí của khu vực ghi chú trong TIFF kết quả không?**

Có. Sử dụng [cài đặt bố cục ghi chú](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) để chọn giữa các tùy chọn như `None`, `BottomTruncated` hoặc `BottomFull`, tương ứng là ẩn ghi chú, vừa vặn chúng trong một trang duy nhất, hoặc cho phép chúng tràn sang các trang bổ sung.

**Làm sao tôi có thể giảm kích thước của tệp TIFF có ghi chú mà không gây mất chất lượng đáng chú ý?**

Chọn một [nén hiệu quả](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (ví dụ `LZW` hoặc `RLE`), đặt DPI hợp lý và, nếu chấp nhận được, sử dụng một [định dạng pixel](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) thấp hơn (như 8 bpp hoặc 1 bpp cho ảnh đen trắng). Việc giảm nhẹ [kích thước ảnh](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/set_imagesize/) cũng có thể giúp mà không làm giảm đáng kể khả năng đọc.

**Phông chữ trong ghi chú có ảnh hưởng đến kết quả nếu các phông chữ gốc không có trong hệ thống không?**

Có. Các phông chữ thiếu sẽ kích hoạt [sự thay thế](/slides/vi/cpp/font-selection-sequence/), có thể làm thay đổi kích thước và dạng hiển thị của văn bản. Để tránh điều này, [cung cấp các phông chữ cần thiết](/slides/vi/cpp/custom-font/) hoặc đặt một [phông chữ dự phòng mặc định](/slides/vi/cpp/fallback-font/) để sử dụng các kiểu chữ mong muốn.