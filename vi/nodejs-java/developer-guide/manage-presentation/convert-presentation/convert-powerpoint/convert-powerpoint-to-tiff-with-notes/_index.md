---
title: Chuyển đổi Bài thuyết trình PowerPoint sang TIFF có Ghi chú bằng JavaScript
linktitle: PowerPoint sang TIFF có Ghi chú
type: docs
weight: 100
url: /vi/nodejs-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- chuyển đổi PowerPoint
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
- PowerPoint có ghi chú
- bài thuyết trình có ghi chú
- slide có ghi chú
- PPT có ghi chú
- PPTX có ghi chú
- TIFF có ghi chú
- Node.js
- JavaScript
- Aspose.Slides
description: "Chuyển đổi bài thuyết trình PowerPoint sang TIFF có ghi chú bằng JavaScript sử dụng Aspose.Slides cho Node.js. Tìm hiểu cách xuất slide với ghi chú diễn giả một cách hiệu quả."
---
## **Giới thiệu**

Aspose.Slides for Node.js via Java cung cấp một giải pháp đơn giản để chuyển đổi các bài thuyết trình PowerPoint và OpenDocument (PPT, PPTX và ODP) có ghi chú sang định dạng TIFF. Định dạng này được sử dụng rộng rãi để lưu trữ ảnh chất lượng cao, in ấn và lưu trữ tài liệu. Với Aspose.Slides, bạn không chỉ có thể xuất toàn bộ bài thuyết trình kèm ghi chú của người thuyết trình mà còn tạo các thumbnail slide trong chế độ Notes Slide. Quá trình chuyển đổi đơn giản và hiệu quả, sử dụng phương thức `save` của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) để biến toàn bộ bài thuyết trình thành một loạt các ảnh TIFF trong khi giữ nguyên ghi chú và bố cục.

## **Chuyển đổi Bài thuyết trình sang TIFF với Ghi chú**

Lưu một bài thuyết trình PowerPoint hoặc OpenDocument sang TIFF có ghi chú bằng Aspose.Slides for Node.js via Java bao gồm các bước sau:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/): tải tệp PowerPoint hoặc OpenDocument.
2. Cấu hình các tùy chọn bố cục đầu ra: sử dụng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/notescommentslayoutingoptions/) để chỉ định cách hiển thị ghi chú và bình luận.
3. Lưu bài thuyết trình thành TIFF: truyền các tùy chọn đã cấu hình vào phương thức [save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#save).

Giả sử chúng ta có tệp "speaker_notes.pptx" với slide sau:

![Slide bài thuyết trình có ghi chú](slide_with_notes.png)

Đoạn mã bên dưới minh họa cách chuyển đổi bài thuyết trình thành ảnh TIFF trong chế độ Notes Slide bằng phương thức [setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions).

```js
// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
let presentation = new aspose.slides.Presentation("speaker_notes.pptx");
try {
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull); // Hiển thị ghi chú bên dưới slide.

    // Cấu hình các tùy chọn TIFF với bố cục Ghi chú.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Lưu bài thuyết trình sang TIFF có ghi chú của người thuyết trình.
    presentation.save("TIFF_with_notes.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình ảnh TIFF có ghi chú](TIFF_with_notes.png)

{{% alert title="Mẹo" color="primary" %}}
Xem công cụ Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/vi/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát vị trí của khu vực ghi chú trong TIFF kết quả không?**

Có. Sử dụng [notes layout settings](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) để chọn giữa các tùy chọn như `None`, `BottomTruncated` hoặc `BottomFull`, tương ứng ẩn ghi chú, gói chúng vào một trang duy nhất, hoặc cho phép chúng kéo dài sang các trang bổ sung.

**Làm thế nào để giảm kích thước tệp TIFF có ghi chú mà không gây mất chất lượng đáng chú ý?**

Chọn một [efficient compression](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/setcompressiontype/) (ví dụ, `LZW` hoặc `RLE`), đặt DPI hợp lý và, nếu chấp nhận được, sử dụng một [pixel format](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/setpixelformat/) thấp hơn (như 8 bpp hoặc 1 bpp cho ảnh đơn màu). Giảm nhẹ [image dimensions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/setimagesize/) cũng có thể giúp mà không làm giảm đáng kể khả năng đọc.

**Phông chữ trong ghi chú có ảnh hưởng đến kết quả nếu các phông chữ gốc thiếu trên hệ thống không?**

Có. Các phông chữ bị thiếu sẽ kích hoạt [substitution](/slides/vi/nodejs-java/font-selection-sequence/), có thể thay đổi kích thước và giao diện văn bản. Để tránh điều này, hãy [supply the required fonts](/slides/vi/nodejs-java/custom-font/) hoặc đặt một [fallback font](/slides/vi/nodejs-java/fallback-font/) mặc định để các phông chữ mong muốn được sử dụng.