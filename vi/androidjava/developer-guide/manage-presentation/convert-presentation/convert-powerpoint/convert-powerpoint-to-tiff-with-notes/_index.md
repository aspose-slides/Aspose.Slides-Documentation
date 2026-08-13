---
title: Chuyển đổi các bản trình bày PowerPoint sang TIFF có ghi chú trên Android
linktitle: PowerPoint sang TIFF có ghi chú
type: docs
weight: 100
url: /vi/androidjava/convert-powerpoint-to-tiff-with-notes/
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
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi các bản trình bày PowerPoint sang TIFF có ghi chú bằng cách sử dụng Aspose.Slides cho Android qua Java. Tìm hiểu cách xuất slide có ghi chú người thuyết trình một cách hiệu quả."
---
## **Giới thiệu**

Aspose.Slides cho Android thông qua Java cung cấp giải pháp đơn giản để chuyển đổi các bản trình bày PowerPoint và OpenDocument (PPT, PPTX và ODP) có ghi chú sang định dạng TIFF. Định dạng này được sử dụng rộng rãi cho việc lưu trữ hình ảnh chất lượng cao, in ấn và lưu trữ tài liệu. Với Aspose.Slides, bạn không chỉ có thể xuất toàn bộ bản trình bày kèm ghi chú người thuyết trình mà còn tạo các hình thu nhỏ slide trong chế độ Notes Slide. Quá trình chuyển đổi đơn giản và hiệu quả, sử dụng phương thức `save` của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) để biến toàn bộ bản trình bày thành một loạt các ảnh TIFF đồng thời giữ nguyên ghi chú và bố cục.

## **Chuyển đổi bản trình bày sang TIFF với ghi chú**

Lưu một bản trình bày PowerPoint hoặc OpenDocument sang TIFF có ghi chú bằng Aspose.Slides cho Android thông qua Java bao gồm các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/): tải một tệp PowerPoint hoặc OpenDocument.  
1. Cấu hình các tùy chọn bố cục đầu ra: sử dụng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/notescommentslayoutingoptions/) để chỉ định cách hiển thị ghi chú và bình luận.  
1. Lưu bản trình bày sang TIFF: truyền các tùy chọn đã cấu hình vào phương thức [save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-).

Giả sử chúng ta có tệp "speaker_notes.pptx" với slide sau:

![Slide trình bày có ghi chú người thuyết trình](slide_with_notes.png)

Đoạn mã dưới đây minh họa cách chuyển đổi bản trình bày sang ảnh TIFF trong chế độ Notes Slide bằng cách sử dụng phương thức [setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-).

```java
import com.aspose.slides.*;

// Tạo một thể hiện của lớp Presentation đại diện cho một tệp bản trình bày.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // Hiển thị ghi chú dưới slide.

    // Cấu hình các tùy chọn TIFF với bố cục ghi chú.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Lưu bản trình bày sang TIFF kèm ghi chú người thuyết trình.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Ảnh TIFF có ghi chú người thuyết trình](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Khám phá Aspose [Công cụ chuyển đổi PowerPoint sang Poster miễn phí](https://products.aspose.app/slides/vi/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Câu hỏi thường gặp**

### Tôi có thể kiểm soát vị trí của khu vực ghi chú trong TIFF kết quả không?

Có. Sử dụng [cài đặt bố cục ghi chú](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) để chọn các tùy chọn như `None`, `BottomTruncated` hoặc `BottomFull`, tương ứng sẽ ẩn ghi chú, vừa vặn chúng vào một trang duy nhất, hoặc cho phép chúng tiếp tục sang các trang bổ sung.

### Làm thế nào để giảm kích thước của tệp TIFF có ghi chú mà không làm mất chất lượng đáng nhìn thấy?

Chọn một [phương pháp nén hiệu quả](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) (ví dụ, `LZW` hoặc `RLE`), đặt DPI hợp lý và, nếu được chấp nhận, sử dụng [định dạng pixel](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) thấp hơn (chẳng hạn 8 bpp hoặc 1 bpp cho ảnh đen trắng). Giảm nhẹ [kích thước ảnh](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) cũng có thể giúp mà không làm giảm đáng kể khả năng đọc.

### Phông chữ trong ghi chú có ảnh hưởng đến kết quả nếu các phông chữ gốc thiếu trong hệ thống không?

Có. Các phông chữ bị thiếu sẽ kích hoạt [thay thế](/slides/vi/androidjava/font-selection-sequence/), có thể làm thay đổi kích thước và giao diện văn bản. Để tránh điều này, [cung cấp các phông chữ cần thiết](/slides/vi/androidjava/custom-font/) hoặc đặt một [phông chữ dự phòng](/slides/vi/androidjava/fallback-font/) mặc định để sử dụng đúng kiểu chữ mong muốn.