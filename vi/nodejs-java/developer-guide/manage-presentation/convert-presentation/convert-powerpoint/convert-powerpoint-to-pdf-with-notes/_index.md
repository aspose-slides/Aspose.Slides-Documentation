---
title: Chuyển đổi Bài Thuyết Trình PowerPoint sang PDF có Ghi chú trong JavaScript
linktitle: PowerPoint sang PDF có Ghi chú
type: docs
weight: 50
url: /vi/nodejs-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang PDF
- bản thuyết trình sang PDF
- slide sang PDF
- PPT sang PDF
- PPTX sang PDF
- lưu bản thuyết trình dưới dạng PDF
- lưu PPT dưới dạng PDF
- lưu PPTX dưới dạng PDF
- xuất PPT sang PDF
- xuất PPTX sang PDF
- ghi chú người trình bày
- PDF có ghi chú
- Node.js
- JavaScript
- Aspose.Slides
description: "Chuyển đổi định dạng PPT và PPTX sang PDF có ghi chú trong JavaScript bằng Aspose.Slides cho Node.js. Bảo tồn bố cục và ghi chú người trình bày cho các bài thuyết trình chuyên nghiệp."
---
## **Tổng quan**

Trong bài viết này, bạn sẽ học cách chuyển đổi bài thuyết trình PowerPoint sang định dạng PDF kèm ghi chú người trình bày bằng Aspose.Slides. Hướng dẫn này sẽ trình bày các bước cần thiết và cung cấp các ví dụ mã để giúp bạn thực hiện nhiệm vụ này một cách hiệu quả. Khi kết thúc bài viết, bạn sẽ có thể:

- Thực hiện quy trình chuyển đổi để biến các slide PowerPoint thành tài liệu PDF đồng thời giữ lại ghi chú người trình bày.
- Tùy chỉnh PDF đầu ra để đảm bảo ghi chú người trình bày được bao gồm và định dạng theo yêu cầu của bạn.

## **Chuyển đổi PowerPoint sang PDF có ghi chú**

Phương thức `save` trong lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) có thể được sử dụng để chuyển đổi một bản thuyết trình PPT hoặc PPTX sang PDF có ghi chú người trình bày. Với Aspose.Slides, bạn chỉ cần tải bản thuyết trình, cấu hình các tùy chọn bố cục bằng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/notescommentslayoutingoptions/) để bao gồm ghi chú, sau đó lưu tệp dưới dạng PDF. Đoạn mã sau minh họa cách chuyển đổi một bản thuyết trình mẫu sang PDF ở chế độ xem Slide Ghi chú.

```js
let presentation = new asposeSlides.Presentation("sample.pptx");

// Cấu hình tùy chọn PDF cho việc hiển thị ghi chú người trình bày.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // Hiển thị ghi chú người trình bày bên dưới slide.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="primary" %}} 
Bạn có thể muốn kiểm tra Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/vi/conversion). 
{{% /alert %}}