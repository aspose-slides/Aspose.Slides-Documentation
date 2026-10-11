---
title: Chuyển đổi bài thuyết trình PowerPoint sang PDF có ghi chú trên Android
linktitle: PowerPoint sang PDF có ghi chú
type: docs
weight: 50
url: /vi/androidjava/convert-powerpoint-to-pdf-with-notes/
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
- ghi chú speaker
- PDF có ghi chú
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi định dạng PPT và PPTX sang PDF có ghi chú bằng cách sử dụng Aspose.Slides cho Android qua Java. Bảo tồn bố cục và ghi chú speaker cho các bài thuyết trình chuyên nghiệp."
---
## **Tổng quan**

Trong bài viết này, bạn sẽ tìm hiểu cách chuyển đổi bài thuyết trình PowerPoint sang định dạng PDF có ghi chú speaker bằng Aspose.Slides. Hướng dẫn này sẽ trình bày các bước cần thiết và cung cấp các ví dụ mã để giúp bạn hoàn thành nhiệm vụ này một cách hiệu quả. Khi kết thúc bài viết, bạn sẽ có thể:

- Thực hiện quy trình chuyển đổi để biến các slide PowerPoint thành tài liệu PDF đồng thời giữ lại ghi chú speaker.
- Tùy chỉnh PDF đầu ra để đảm bảo ghi chú speaker được bao gồm và định dạng theo yêu cầu của bạn.

Để đặt kích thước và định hướng trang ghi chú trước khi xuất, xem [Kích thước Trang Ghi chú](/slides/vi/androidjava/notes-size/).

## **Chuyển đổi PowerPoint sang PDF với Ghi chú**

Phương thức `save` trong lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) có thể được sử dụng để chuyển đổi bài thuyết trình PPT hoặc PPTX sang PDF có ghi chú speaker. Với Aspose.Slides, bạn chỉ cần tải bài thuyết trình, cấu hình các tùy chọn bố cục bằng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/notescommentslayoutingoptions/) để bao gồm ghi chú speaker, sau đó lưu tệp dưới dạng PDF. Đoạn mã mẫu dưới đây minh họa cách chuyển đổi một bài thuyết trình mẫu sang PDF ở chế độ xem Slides Ghi chú.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// Cấu hình tùy chọn PDF cho việc hiển thị ghi chú speaker.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Hiển thị ghi chú speaker bên dưới slide.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// Lưu bài thuyết trình sang PDF có ghi chú speaker.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Bạn có thể muốn xem Aspose [Trình chuyển đổi PowerPoint sang PDF Trực tuyến](https://products.aspose.app/slides/vi/conversion).
{{% /alert %}}