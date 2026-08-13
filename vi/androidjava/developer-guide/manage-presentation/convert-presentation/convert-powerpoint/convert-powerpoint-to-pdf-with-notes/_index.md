---
title: Chuyển đổi Bản trình chiếu PowerPoint sang PDF có Ghi chú trên Android
linktitle: PowerPoint sang PDF có Ghi chú
type: docs
weight: 50
url: /vi/androidjava/convert-powerpoint-to-pdf-with-notes/
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
- ghi chú diễn giả
- PDF có ghi chú
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi định dạng PPT và PPTX sang PDF có ghi chú sử dụng Aspose.Slides cho Android qua Java. Bảo tồn bố cục và ghi chú diễn giả cho các bản trình chiếu chuyên nghiệp."
---
## **Tổng quan**

Trong bài viết này, bạn sẽ học cách chuyển đổi bản trình chiếu PowerPoint sang định dạng PDF có ghi chú diễn giả bằng Aspose.Slides. Hướng dẫn này sẽ đề cập đến các bước cần thiết và cung cấp các ví dụ mã để giúp bạn thực hiện nhiệm vụ này một cách hiệu quả. Khi kết thúc bài viết, bạn sẽ có thể:

- Thực hiện quá trình chuyển đổi để biến các slide PowerPoint thành tài liệu PDF đồng thời bảo tồn ghi chú diễn giả.
- Tùy chỉnh PDF đầu ra để đảm bảo ghi chú diễn giả được bao gồm và định dạng theo yêu cầu của bạn.

## **Chuyển đổi PowerPoint sang PDF với Ghi chú**

Phương thức `save` trong lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) có thể được dùng để chuyển đổi bản trình chiếu PPT hoặc PPTX sang PDF có ghi chú diễn giả. Với Aspose.Slides, bạn chỉ cần tải bản trình chiếu, cấu hình các tùy chọn bố cục bằng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/notescommentslayoutingoptions/) để bao gồm ghi chú diễn giả, rồi lưu file dưới dạng PDF. Đoạn mã sau minh họa cách chuyển đổi một bản trình chiếu mẫu sang PDF ở chế độ xem Ghi chú Slide.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// Cấu hình tùy chọn PDF cho việc hiển thị ghi chú diễn giả.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Hiển thị ghi chú diễn giả dưới slide.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// Lưu bản trình chiếu thành PDF có ghi chú diễn giả.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" %}} 
Bạn có thể muốn kiểm tra Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/vi/conversion). 
{{% /alert %}}