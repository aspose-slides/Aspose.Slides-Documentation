---
title: Chuyển đổi bản trình chiếu PowerPoint sang PDF có ghi chú trên Android
linktitle: PowerPoint sang PDF có ghi chú
type: docs
weight: 50
url: /vi/androidjava/convert-powerpoint-to-pdf-with-notes/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình bày
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang PDF
- bản trình bày sang PDF
- slide sang PDF
- PPT sang PDF
- PPTX sang PDF
- lưu bản trình bày dưới dạng PDF
- lưu PPT dưới dạng PDF
- lưu PPTX dưới dạng PDF
- xuất PPT sang PDF
- xuất PPTX sang PDF
- ghi chú diễn giả
- PDF có ghi chú
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi định dạng PPT và PPTX sang PDF có ghi chú bằng Aspose.Slides cho Android qua Java. Bảo tồn bố cục và ghi chú diễn giả cho các bản trình bày chuyên nghiệp."
---
## **Tổng quan**

Trong bài viết này, bạn sẽ tìm hiểu cách chuyển đổi bản trình bày PowerPoint sang định dạng PDF có ghi chú diễn giả bằng Aspose.Slides. Hướng dẫn này sẽ đề cập đến các bước cần thiết và cung cấp các ví dụ mã để giúp bạn thực hiện nhiệm vụ một cách hiệu quả. Khi kết thúc bài viết, bạn sẽ có khả năng:

- Thực hiện quy trình chuyển đổi để biến các slide PowerPoint thành tài liệu PDF đồng thời giữ lại ghi chú diễn giả.
- Tùy chỉnh PDF đầu ra để đảm bảo ghi chú diễn giả được bao gồm và định dạng theo yêu cầu của bạn.

## **Chuyển đổi PowerPoint sang PDF có Ghi chú**

Phương thức `save` trong lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) có thể được sử dụng để chuyển đổi bản trình bày PPT hoặc PPTX sang PDF có ghi chú diễn giả. Với Aspose.Slides, bạn chỉ cần tải bản trình bày, cấu hình tùy chọn bố cục bằng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/notescommentslayoutingoptions/) để bao gồm ghi chú diễn giả, sau đó lưu tệp thành PDF. Đoạn mã dưới đây minh họa cách chuyển đổi một bản trình bày mẫu sang PDF ở chế độ xem Slide Ghi chú.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
	// Cấu hình tùy chọn PDF để hiển thị ghi chú diễn giả.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Hiển thị ghi chú diễn giả dưới slide.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// Lưu bản trình bày dưới dạng PDF có ghi chú diễn giả.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="primary" %}} 
Bạn có thể muốn kiểm tra công cụ **Aspose Online PowerPoint to PDF Converter** tại https://products.aspose.app/slides/vi/conversion. 
{{% /alert %}}