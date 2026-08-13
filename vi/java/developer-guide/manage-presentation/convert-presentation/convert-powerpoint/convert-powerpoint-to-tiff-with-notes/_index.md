---
title: Chuyển đổi bản trình bày PowerPoint sang TIFF có ghi chú trong Java
linktitle: PowerPoint sang TIFF có ghi chú
type: docs
weight: 100
url: /vi/java/convert-powerpoint-to-tiff-with-notes/
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
- Java
- Aspose.Slides
description: "Chuyển đổi bản trình bày PowerPoint sang TIFF có ghi chú bằng Aspose.Slides cho Java. Tìm hiểu cách xuất slide kèm ghi chú diễn giả một cách hiệu quả."
---
## **Giới thiệu**

Aspose.Slides for Java cung cấp giải pháp đơn giản để chuyển đổi các bản trình bày PowerPoint và OpenDocument (PPT, PPTX và ODP) có ghi chú sang định dạng TIFF. Định dạng này được sử dụng rộng rãi cho việc lưu trữ hình ảnh chất lượng cao, in ấn và lưu trữ tài liệu. Với Aspose.Slides, bạn không chỉ có thể xuất toàn bộ bản trình bày kèm ghi chú diễn giả mà còn tạo các ảnh thu nhỏ của slide trong chế độ Notes Slide. Quá trình chuyển đổi đơn giản và hiệu quả, sử dụng phương thức `save` của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) để biến toàn bộ bản trình bày thành một loạt các ảnh TIFF đồng thời giữ nguyên ghi chú và bố cục.

## **Chuyển đổi bản trình bày sang TIFF có ghi chú**

Lưu một bản trình bày PowerPoint hoặc OpenDocument sang TIFF có ghi chú bằng Aspose.Slides for Java bao gồm các bước sau:

1. Tạo thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) : Nạp một tệp PowerPoint hoặc OpenDocument.  
1. Cấu hình các tùy chọn bố cục đầu ra: Sử dụng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/notescommentslayoutingoptions/) để chỉ định cách hiển thị ghi chú và bình luận.  
1. Lưu bản trình bày thành TIFF: Truyền các tùy chọn đã cấu hình vào phương thức [save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-).

Giả sử chúng ta có tệp "speaker_notes.pptx" với slide sau:

![The presentation slide with speaker notes](slide_with_notes.png)

Đoạn mã bên dưới minh họa cách chuyển đổi bản trình bày thành ảnh TIFF trong chế độ Notes Slide bằng phương thức [setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-).

```java
import com.aspose.slides.*;

// Tạo thể hiện của lớp Presentation đại diện cho tệp bản trình bày.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // Hiển thị ghi chú phía dưới slide.

    // Cấu hình các tùy chọn TIFF với bố cục ghi chú.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Lưu bản trình bày thành TIFF kèm ghi chú diễn giả.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Kết quả:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Khám phá Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/vi/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Câu hỏi thường gặp**

### Tôi có thể kiểm soát vị trí của khu vực ghi chú trong TIFF kết quả không?

Có. Sử dụng [cài đặt bố cục ghi chú](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) để chọn giữa các tùy chọn như `None`, `BottomTruncated` hoặc `BottomFull`, tương ứng ẩn ghi chú, gói chúng vào một trang duy nhất, hoặc cho phép chúng tiếp tục sang các trang bổ sung.

### Làm sao giảm kích thước tệp TIFF có ghi chú mà không làm mất chất lượng đáng nhìn thấy?

Chọn một [các phương thức nén hiệu quả](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) (ví dụ, `LZW` hoặc `RLE`), đặt DPI hợp lý và, nếu chấp nhận được, sử dụng [định dạng pixel](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) thấp hơn (như 8 bpp hoặc 1 bpp cho ảnh đen trắng). Giảm nhẹ [kích thước ảnh](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) cũng có thể giúp mà không ảnh hưởng đáng kể tới độ dễ đọc.

### Phông chữ trong ghi chú có ảnh hưởng đến kết quả nếu các phông chữ gốc thiếu trên hệ thống không?

Có. Các phông chữ bị thiếu sẽ kích hoạt [định dạng thay thế](/slides/vi/java/font-selection-sequence/), có thể thay đổi kích thước và dạng hiển thị của văn bản. Để tránh điều này, [cung cấp các phông chữ cần thiết](/slides/vi/java/custom-font/) hoặc thiết lập một [phông chữ dự phòng mặc định](/slides/vi/java/fallback-font/) để sử dụng đúng kiểu chữ mong muốn.