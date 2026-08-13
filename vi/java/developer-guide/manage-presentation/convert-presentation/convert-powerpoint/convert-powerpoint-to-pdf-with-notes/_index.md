---
title: "Chuyển đổi Bài thuyết trình PowerPoint sang PDF có Ghi chú trong Java"
linktitle: "PowerPoint sang PDF có Ghi chú"
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
- ghi chú người thuyết trình
- PDF có ghi chú
- Java
- Aspose.Slides
description: "Chuyển đổi định dạng PPT và PPTX sang PDF có ghi chú bằng Aspose.Slides cho Java. Bảo toàn bố cục và ghi chú người thuyết trình cho các bài thuyết trình chuyên nghiệp."
---
## **Tổng quan**

Trong bài viết này, bạn sẽ học cách chuyển đổi bài thuyết trình PowerPoint sang định dạng PDF có ghi chú người thuyết trình bằng Aspose.Slides. Hướng dẫn này sẽ đề cập các bước cần thiết và cung cấp các ví dụ mã để giúp bạn thực hiện nhiệm vụ này một cách hiệu quả. Khi kết thúc bài viết, bạn sẽ có khả năng:

- Thực hiện quy trình chuyển đổi để biến các slide PowerPoint thành tài liệu PDF trong khi giữ nguyên ghi chú người thuyết trình.
- Tùy chỉnh PDF đầu ra để đảm bảo rằng ghi chú người thuyết trình được bao gồm và định dạng theo yêu cầu của bạn.

## **Chuyển đổi PowerPoint sang PDF có Ghi chú**

Phương thức `save` trong lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) có thể được sử dụng để chuyển đổi một bài thuyết trình PPT hoặc PPTX sang PDF có ghi chú người thuyết trình. Với Aspose.Slides, bạn chỉ cần tải bài thuyết trình, cấu hình các tùy chọn bố cục bằng cách sử dụng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/notescommentslayoutingoptions/) để bao gồm ghi chú người thuyết trình, và sau đó lưu tệp dưới dạng PDF. Đoạn mã sau đây minh họa cách chuyển đổi một bài thuyết trình mẫu sang PDF ở chế độ xem Slide Ghi chú.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// Cấu hình tùy chọn PDF để hiển thị ghi chú người thuyết trình.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Hiển thị ghi chú người thuyết trình dưới slide.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Lưu bài thuyết trình thành PDF có ghi chú người thuyết trình.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" %}} 
Bạn có thể muốn kiểm tra công cụ chuyển đổi PowerPoint sang PDF trực tuyến của Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/vi/conversion). 
{{% /alert %}}