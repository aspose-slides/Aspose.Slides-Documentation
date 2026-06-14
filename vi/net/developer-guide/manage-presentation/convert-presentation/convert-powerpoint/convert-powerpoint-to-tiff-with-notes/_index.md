---
title: Chuyển đổi bản trình chiếu PowerPoint sang TIFF có ghi chú trong .NET
linktitle: PowerPoint sang TIFF có ghi chú
type: docs
weight: 100
url: /vi/net/convert-powerpoint-to-tiff-with-notes/
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
- .NET
- C#
- Aspose.Slides
description: Chuyển đổi bản trình chiếu PowerPoint sang TIFF có ghi chú bằng Aspose.Slides cho .NET. Tìm hiểu cách xuất slide với ghi chú người thuyết trình một cách hiệu quả.
---
## **Giới thiệu**

Aspose.Slides for .NET cung cấp một giải pháp đơn giản để chuyển đổi các bản trình chiếu PowerPoint và OpenDocument (PPT, PPTX và ODP) có ghi chú sang định dạng TIFF. Định dạng này được sử dụng rộng rãi để lưu trữ hình ảnh chất lượng cao, in ấn và lưu trữ tài liệu. Với Aspose.Slides, bạn không chỉ có thể xuất toàn bộ bản trình chiếu cùng ghi chú của người thuyết trình mà còn tạo các hình thu nhỏ của slide trong chế độ Notes Slide. Quy trình chuyển đổi đơn giản và hiệu quả, sử dụng phương thức `Save` của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) để biến toàn bộ bản trình chiếu thành một loạt các ảnh TIFF đồng thời giữ nguyên ghi chú và bố cục.

## **Chuyển đổi bản trình chiếu sang TIFF với ghi chú**

Lưu một bản trình chiếu PowerPoint hoặc OpenDocument sang TIFF có ghi chú bằng Aspose.Slides for .NET bao gồm các bước sau:

1. Khởi tạo lớp [Presentation]: Tải tệp PowerPoint hoặc OpenDocument.
2. Cấu hình các tùy chọn bố cục đầu ra: Sử dụng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/notescommentslayoutingoptions/) để chỉ định cách hiển thị ghi chú và bình luận.
3. Lưu bản trình chiếu dưới dạng TIFF: Đưa các tùy chọn đã cấu hình vào phương thức [Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/methods/save/index).

Giả sử chúng ta có tệp "speaker_notes.pptx" với slide sau:

![Slide trình chiếu có ghi chú người thuyết trình](slide_with_notes.png)

```c#
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // Cấu hình các tùy chọn TIFF với bố cục Ghi chú.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Hiển thị ghi chú phía dưới slide.
        }
    };

    // Lưu bản trình chiếu thành TIFF có ghi chú người thuyết trình.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

Kết quả:

![Hình ảnh TIFF có ghi chú người thuyết trình](TIFF_with_notes.png)

{{% alert title="Mẹo" color="primary" %}}
Hãy xem Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/vi/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát vị trí của vùng ghi chú trong TIFF kết quả không?**

Có. Sử dụng [cài đặt bố cục ghi chú](https://reference.aspose.com/slides/vi/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) để chọn giữa các tùy chọn như `None`, `BottomTruncated` hoặc `BottomFull`, tương ứng là ẩn ghi chú, vừa khít vào một trang, hoặc cho phép chúng tiếp tục sang các trang bổ sung.

**Làm thế nào tôi có thể giảm kích thước của tệp TIFF có ghi chú mà không gây mất chất lượng đáng chú ý?**

Chọn một [nén hiệu quả](https://reference.aspose.com/slides/vi/net/aspose.slides.export/tiffoptions/compressiontype/) (ví dụ, `LZW` hoặc `RLE`), đặt DPI hợp lý, và, nếu chấp nhận được, sử dụng một [định dạng pixel](https://reference.aspose.com/slides/vi/net/aspose.slides.export/tiffoptions/pixelformat/) thấp hơn (như 8 bpp hoặc 1 bpp cho ảnh đơn màu). Việc giảm nhẹ [kích thước ảnh](https://reference.aspose.com/slides/vi/net/aspose.slides.export/tiffoptions/imagesize/) cũng có thể giúp mà không làm giảm đáng kể khả năng đọc.

**Phông chữ trong ghi chú có ảnh hưởng đến kết quả nếu các phông chữ gốc không có trên hệ thống không?**

Có. Các phông chữ thiếu sẽ kích hoạt [thay thế](/slides/vi/net/font-selection-sequence/), có thể thay đổi số đo và giao diện của văn bản. Để tránh điều này, [cung cấp các phông chữ cần thiết](/slides/vi/net/custom-font/) hoặc thiết lập một [phông chữ dự phòng](/slides/vi/net/fallback-font/) mặc định để đảm bảo các kiểu chữ mong muốn được sử dụng.