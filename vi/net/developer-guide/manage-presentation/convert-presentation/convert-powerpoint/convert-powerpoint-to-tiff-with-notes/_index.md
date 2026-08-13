---
title: Chuyển đổi bản trình bày PowerPoint sang TIFF có ghi chú trong .NET
linktitle: PowerPoint sang TIFF có ghi chú
type: docs
weight: 100
url: /vi/net/convert-powerpoint-to-tiff-with-notes/
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
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi các bản trình bày PowerPoint sang TIFF có ghi chú bằng Aspose.Slides cho .NET. Tìm hiểu cách xuất slide có ghi chú diễn giả một cách hiệu quả."
---
## **Giới thiệu**

Aspose.Slides for .NET cung cấp giải pháp đơn giản để chuyển đổi các bản trình bày PowerPoint và OpenDocument (PPT, PPTX và ODP) có ghi chú sang định dạng TIFF. Định dạng này được sử dụng rộng rãi cho việc lưu trữ hình ảnh chất lượng cao, in ấn và lưu trữ tài liệu. Với Aspose.Slides, bạn không chỉ có thể xuất toàn bộ bản trình bày cùng ghi chú của người thuyết trình mà còn tạo các hình thu nhỏ slide trong chế độ Notes Slide. Quy trình chuyển đổi đơn giản và hiệu quả, sử dụng phương thức `Save` của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) để biến toàn bộ bản trình bày thành một loạt hình ảnh TIFF đồng thời giữ nguyên ghi chú và bố cục.

## **Chuyển đổi bản trình bày sang TIFF có ghi chú**

Việc lưu một bản trình bày PowerPoint hoặc OpenDocument sang TIFF có ghi chú bằng Aspose.Slides cho .NET bao gồm các bước sau:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/): tải một tệp PowerPoint hoặc OpenDocument.
1. Cấu hình các tùy chọn bố cục đầu ra: sử dụng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/notescommentslayoutingoptions/) để chỉ định cách hiển thị ghi chú và bình luận.
1. Lưu bản trình bày sang TIFF: truyền các tùy chọn đã cấu hình vào phương thức [Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/methods/save/index).

Giả sử chúng ta có một tệp "speaker_notes.pptx" với slide sau:

![The presentation slide with speaker notes](slide_with_notes.png)

Đoạn mã dưới đây minh họa cách chuyển đổi bản trình bày thành hình ảnh TIFF trong chế độ Notes Slide bằng thuộc tính [SlidesLayoutOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/tiffoptions/slideslayoutoptions/).

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // Cấu hình các tùy chọn TIFF với bố trí ghi chú.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Hiển thị ghi chú phía dưới slide.
        }
    };

    // Lưu bản trình bày sang TIFF có ghi chú của người thuyết trình.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

Kết quả:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Hãy xem Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/vi/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Câu hỏi thường gặp**

### Tôi có thể kiểm soát vị trí khu vực ghi chú trong TIFF kết quả không?

Có. Sử dụng [cài đặt bố cục ghi chú](https://reference.aspose.com/slides/vi/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) để chọn các tùy chọn như `None`, `BottomTruncated` hoặc `BottomFull`, tương ứng sẽ ẩn ghi chú, vừa khít chúng vào một trang duy nhất, hoặc cho phép chúng chạy sang các trang bổ sung.

### Làm cách nào để giảm kích thước tệp TIFF có ghi chú mà không mất chất lượng đáng kể?

Chọn một [phép nén hiệu quả](https://reference.aspose.com/slides/vi/net/aspose.slides.export/tiffoptions/compressiontype/) (ví dụ: `LZW` hoặc `RLE`), đặt DPI hợp lý và, nếu chấp nhận được, sử dụng [định dạng pixel](https://reference.aspose.com/slides/vi/net/aspose.slides.export/tiffoptions/pixelformat/) thấp hơn (như 8 bpp hoặc 1 bpp cho ảnh đen trắng). Giảm nhẹ [kích thước ảnh](https://reference.aspose.com/slides/vi/net/aspose.slides.export/tiffoptions/imagesize/) cũng có thể giúp mà không gây ảnh hưởng đáng chú ý tới khả năng đọc.

### Phông chữ trong ghi chú có ảnh hưởng đến kết quả nếu các phông chữ gốc thiếu trên hệ thống không?

Có. Các phông chữ thiếu sẽ kích hoạt [thay thế](/slides/vi/net/font-selection-sequence/), có thể làm thay đổi các chỉ số và giao diện của văn bản. Để tránh điều này, [cung cấp các phông chữ cần thiết](/slides/vi/net/custom-font/) hoặc thiết lập một [phông chữ dự phòng](/slides/vi/net/fallback-font/) mặc định để sử dụng đúng kiểu chữ mong muốn.