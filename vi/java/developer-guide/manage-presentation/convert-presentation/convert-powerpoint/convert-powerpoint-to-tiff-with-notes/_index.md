---
title: Chuyển đổi bản thuyết trình PowerPoint sang TIFF có ghi chú trong Java
linktitle: PowerPoint sang TIFF có ghi chú
type: docs
weight: 100
url: /vi/java/convert-powerpoint-to-tiff-with-notes/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang TIFF
- bản thuyết trình sang TIFF
- slide sang TIFF
- PPT sang TIFF
- PPTX sang TIFF
- lưu PPT dưới dạng TIFF
- lưu PPTX dưới dạng TIFF
- xuất PPT sang TIFF
- xuất PPTX sang TIFF
- PowerPoint có ghi chú
- bản thuyết trình có ghi chú
- slide có ghi chú
- PPT có ghi chú
- PPTX có ghi chú
- TIFF có ghi chú
- Java
- Aspose.Slides
description: "Chuyển đổi bản thuyết trình PowerPoint sang TIFF có ghi chú bằng Aspose.Slides cho Java. Tìm hiểu cách xuất slide có ghi chú người nói một cách hiệu quả."
---
## **Giới thiệu**

Aspose.Slides for Java cung cấp một giải pháp đơn giản để chuyển đổi các bản thuyết trình PowerPoint và OpenDocument (PPT, PPTX và ODP) có ghi chú sang định dạng TIFF. Định dạng này được sử dụng rộng rãi cho việc lưu trữ hình ảnh chất lượng cao, in ấn và lưu trữ tài liệu. Với Aspose.Slides, bạn không chỉ có thể xuất toàn bộ bản thuyết trình kèm ghi chú người nói mà còn tạo thumbnail slide trong chế độ Notes Slide. Quá trình chuyển đổi đơn giản và hiệu quả, sử dụng phương thức `save` của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) để biến toàn bộ bản thuyết trình thành một loạt các hình ảnh TIFF trong khi giữ nguyên ghi chú và bố cục.

## **Chuyển đổi bài thuyết trình sang TIFF với ghi chú**

Việc lưu một bài thuyết trình PowerPoint hoặc OpenDocument sang TIFF có ghi chú bằng Aspose.Slides cho Java bao gồm các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/): Tải một tệp PowerPoint hoặc OpenDocument.
1. Cấu hình các tùy chọn bố cục đầu ra: Sử dụng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/notescommentslayoutingoptions/) để chỉ định cách hiển thị ghi chú và bình luận.
1. Lưu bài thuyết trình sang TIFF: Chuyển các tùy chọn đã cấu hình vào phương thức [save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-).

Giả sử chúng ta có tệp "speaker_notes.pptx" với slide sau:

![The presentation slide with speaker notes](slide_with_notes.png)

Đoạn mã dưới đây minh họa cách chuyển đổi bài thuyết trình sang hình ảnh TIFF trong chế độ xem Notes Slide bằng phương thức [setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-).

```java
// Khởi tạo lớp Presentation đại diện cho một tệp bản thuyết trình.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // Hiển thị ghi chú bên dưới slide.

    // Cấu hình các tùy chọn TIFF với bố cục ghi chú.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Lưu bản thuyết trình sang TIFF với ghi chú người nói.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Kết quả:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}

Hãy xem trình chuyển đổi PowerPoint sang Poster miễn phí của Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/vi/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **FAQ**

**Tôi có thể kiểm soát vị trí của khu vực ghi chú trong TIFF kết quả không?**

Có. Sử dụng cài đặt bố cục ghi chú để lựa chọn các tùy chọn như `None`, `BottomTruncated` hoặc `BottomFull`, tương ứng sẽ ẩn ghi chú, vừa khít chúng vào một trang duy nhất, hoặc cho phép chúng trải dài sang các trang bổ sung.

**Làm thế nào để giảm kích thước của tệp TIFF có ghi chú mà không gây mất chất lượng đáng chú ý?**

Chọn một phương pháp nén hiệu quả (ví dụ `LZW` hoặc `RLE`), đặt DPI hợp lý và, nếu chấp nhận được, sử dụng định dạng pixel thấp hơn (như 8 bpp hoặc 1 bpp cho ảnh đen trắng). Giảm kích thước hình ảnh một chút cũng có thể giúp mà không ảnh hưởng đáng kể đến khả năng đọc.

**Phông chữ trong ghi chú có ảnh hưởng đến kết quả nếu các phông chữ gốc thiếu trên hệ thống không?**

Có. Khi thiếu phông chữ, hệ thống sẽ thực hiện thay thế, có thể làm thay đổi kích thước và giao diện văn bản. Để tránh điều này, cung cấp các phông chữ cần thiết hoặc đặt một phông chữ dự phòng mặc định để sử dụng đúng kiểu chữ mong muốn.