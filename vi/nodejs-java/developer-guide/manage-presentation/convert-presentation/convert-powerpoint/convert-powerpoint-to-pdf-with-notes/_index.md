---
title: Chuyển đổi Bản trình chiếu PowerPoint sang PDF có Ghi chú trong JavaScript
linktitle: PowerPoint sang PDF có Ghi chú
type: docs
weight: 50
url: /vi/nodejs-java/convert-powerpoint-to-pdf-with-notes/
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
- ghi chú người thuyết trình
- PDF có ghi chú
- Node.js
- JavaScript
- Aspose.Slides
description: "Chuyển đổi định dạng PPT và PPTX sang PDF có ghi chú trong JavaScript bằng Aspose.Slides cho Node.js. Bảo tồn bố cục và ghi chú người thuyết trình cho các bản trình chiếu chuyên nghiệp."
---
## **Tổng quan**

Trong bài viết này, bạn sẽ tìm hiểu cách chuyển đổi các bản trình chiếu PowerPoint sang định dạng PDF kèm ghi chú người thuyết trình bằng Aspose.Slides. Hướng dẫn này sẽ bao phủ các bước cần thiết và cung cấp các ví dụ mã để giúp bạn thực hiện nhiệm vụ này một cách hiệu quả. Khi kết thúc bài viết, bạn sẽ có thể:

- Thực hiện quá trình chuyển đổi để biến các slide PowerPoint thành tài liệu PDF trong khi giữ nguyên ghi chú người thuyết trình.
- Tùy chỉnh PDF đầu ra để đảm bảo ghi chú người thuyết trình được bao gồm và định dạng theo yêu cầu của bạn.

Để đặt kích thước và hướng của trang ghi chú trước khi xuất, xem [Kích thước Trang Ghi chú](/slides/vi/nodejs-java/notes-size/).

## **Chuyển đổi PowerPoint sang PDF có Ghi chú**

Phương thức `save` trong lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) có thể được sử dụng để chuyển đổi bản trình chiếu PPT hoặc PPTX sang PDF kèm ghi chú người thuyết trình. Với Aspose.Slides, bạn chỉ cần tải bản trình chiếu, cấu hình các tùy chọn bố cục bằng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/notescommentslayoutingoptions/) để bao gồm ghi chú người thuyết trình, sau đó lưu tệp dưới dạng PDF. Đoạn mã dưới đây minh họa cách chuyển đổi một bản trình chiếu mẫu sang PDF ở chế độ xem Slide Ghi chú.

```js
const asposeSlides = require("aspose.slides.via.java");

let presentation = new asposeSlides.Presentation("sample.pptx");

// Cấu hình tùy chọn PDF cho việc hiển thị ghi chú người thuyết trình.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // Hiển thị ghi chú người thuyết trình bên dưới slide.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Lưu bản trình chiếu dưới dạng PDF có ghi chú người thuyết trình.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}
Bạn có thể muốn kiểm tra Aspose [Trình chuyển đổi PowerPoint sang PDF trực tuyến](https://products.aspose.app/slides/vi/conversion).
{{% /alert %}}