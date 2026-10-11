---
title: Chuyển đổi bài thuyết trình PowerPoint sang PDF có ghi chú trong Java
linktitle: PowerPoint sang PDF có ghi chú
type: docs
weight: 50
url: /vi/java/convert-powerpoint-to-pdf-with-notes/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang PDF
- bài thuyết trình sang PDF
- slide sang PDF
- PPT sang PDF
- PPTX sang PDF
- lưu bài thuyết trình dưới dạng PDF
- lưu PPT dưới dạng PDF
- lưu PPTX dưới dạng PDF
- xuất PPT sang PDF
- xuất PPTX sang PDF
- ghi chú diễn giả
- PDF có ghi chú
- Java
- Aspose.Slides
description: "Chuyển đổi định dạng PPT và PPTX sang PDF có ghi chú bằng Aspose.Slides cho Java. Bảo tồn bố cục và ghi chú diễn giả cho các bài thuyết trình chuyên nghiệp."
---
## **Tổng quan**

Trong bài viết này, bạn sẽ học cách chuyển đổi các bản trình chiếu PowerPoint sang định dạng PDF có ghi chú diễn giả bằng Aspose.Slides. Hướng dẫn này sẽ bao gồm các bước cần thiết và cung cấp các ví dụ mã để giúp bạn thực hiện nhiệm vụ này một cách hiệu quả. Khi kết thúc bài viết, bạn sẽ có thể:

- Thực hiện quy trình chuyển đổi để biến các slide PowerPoint thành tài liệu PDF đồng thời giữ lại ghi chú diễn giả.
- Tùy chỉnh PDF đầu ra để đảm bảo ghi chú diễn giả được bao gồm và định dạng theo yêu cầu của bạn.

Để đặt kích thước và hướng của trang ghi chú trước khi xuất, xem [Kích thước Trang Ghi chú](/slides/vi/java/notes-size/).

## **Chuyển đổi PowerPoint sang PDF có Ghi chú**

Phương thức `save` trong lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) có thể được sử dụng để chuyển đổi một bản trình chiếu PPT hoặc PPTX sang PDF có ghi chú diễn giả. Với Aspose.Slides, bạn chỉ cần tải bản trình chiếu, cấu hình các tùy chọn bố cục bằng cách sử dụng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/notescommentslayoutingoptions/) để bao gồm ghi chú diễn giả, sau đó lưu tệp dưới dạng PDF. Đoạn mã mẫu dưới đây minh họa cách chuyển đổi một bản trình chiếu mẫu sang PDF ở chế độ xem Slide Ghi chú.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// Cấu hình tùy chọn PDF để hiển thị ghi chú diễn giả.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Hiển thị ghi chú diễn giả phía dưới slide.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Lưu bài thuyết trình thành PDF có ghi chú diễn giả.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}
Bạn có thể muốn kiểm tra công cụ Aspose [Trình chuyển đổi PowerPoint sang PDF Trực tuyến](https://products.aspose.app/slides/vi/conversion).
{{% /alert %}}