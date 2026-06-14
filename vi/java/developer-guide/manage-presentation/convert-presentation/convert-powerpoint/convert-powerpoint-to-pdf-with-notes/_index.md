---
title: Chuyển đổi Bản trình chiếu PowerPoint sang PDF có Ghi chú trong Java
linktitle: PowerPoint sang PDF có Ghi chú
type: docs
weight: 50
url: /vi/java/convert-powerpoint-to-pdf-with-notes/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang PDF
- bản trình chiếu sang PDF
- slide sang PDF
- PPT sang PDF
- PPTX sang PDF
- lưu bản trình chiếu dưới dạng PDF
- lưu PPT dưới dạng PDF
- lưu PPTX dưới dạng PDF
- xuất PPT sang PDF
- xuất PPTX sang PDF
- ghi chú thuyết trình
- PDF có ghi chú
- Java
- Aspose.Slides
description: "Chuyển đổi định dạng PPT và PPTX sang PDF có ghi chú bằng Aspose.Slides cho Java. Bảo tồn bố cục và ghi chú thuyết trình cho các bản trình chiếu chuyên nghiệp."
---
## **Tổng quan**

Trong bài viết này, bạn sẽ tìm hiểu cách chuyển đổi bản trình chiếu PowerPoint sang định dạng PDF có ghi chú thuyết trình bằng Aspose.Slides. Hướng dẫn này sẽ đề cập đến các bước cần thiết và cung cấp các ví dụ mã để giúp bạn thực hiện nhiệm vụ này một cách hiệu quả. Khi kết thúc bài viết, bạn sẽ có khả năng:

- Thực hiện quy trình chuyển đổi để biến các slide PowerPoint thành tài liệu PDF đồng thời giữ lại ghi chú thuyết trình.
- Tùy chỉnh PDF đầu ra để đảm bảo ghi chú thuyết trình được bao gồm và định dạng theo yêu cầu của bạn.

## **Chuyển đổi PowerPoint sang PDF với Ghi chú**

Phương thức `save` trong lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) có thể được sử dụng để chuyển đổi bản trình chiếu PPT hoặc PPTX sang PDF có ghi chú thuyết trình. Với Aspose.Slides, bạn chỉ cần tải bản trình chiếu, cấu hình các tùy chọn bố cục bằng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/notescommentslayoutingoptions/) để bao gồm ghi chú thuyết trình, sau đó lưu tệp dưới dạng PDF. Đoạn mã sau minh họa cách chuyển đổi một bản trình chiếu mẫu sang PDF ở chế độ xem Notes Slide.

```java
Presentation presentation = new Presentation("sample.pptx");

// Cấu hình tùy chọn PDF để hiển thị ghi chú thuyết trình.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Hiển thị ghi chú thuyết trình phía dưới slide.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Lưu bản trình chiếu thành PDF có ghi chú thuyết trình.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="primary" %}} 

Bạn có thể muốn kiểm tra Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/vi/conversion). 

{{% /alert %}}