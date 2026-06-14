---
title: Chuyển đổi bài thuyết trình PowerPoint sang PDF có ghi chú trong PHP
linktitle: PowerPoint sang PDF có ghi chú
type: docs
weight: 50
url: /vi/php-java/convert-powerpoint-to-pdf-with-notes/
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
- PHP
- Aspose.Slides
description: "Chuyển đổi định dạng PPT và PPTX sang PDF có ghi chú bằng Aspose.Slides cho PHP qua Java. Bảo tồn bố cục và ghi chú người thuyết trình cho các bài thuyết trình chuyên nghiệp."
---
## **Tổng quan**

Trong bài viết này, bạn sẽ học cách chuyển đổi bài thuyết trình PowerPoint sang định dạng PDF có ghi chú người thuyết trình bằng Aspose.Slides. Hướng dẫn này sẽ đề cập đến các bước cần thiết và cung cấp các ví dụ mã để giúp bạn thực hiện nhiệm vụ này một cách hiệu quả. Khi kết thúc bài viết, bạn sẽ có khả năng:

- Thực hiện quy trình chuyển đổi để biến các slide PowerPoint thành tài liệu PDF đồng thời bảo lưu ghi chú người thuyết trình.
- Tùy chỉnh PDF đầu ra để đảm bảo ghi chú được bao gồm và định dạng theo yêu cầu của bạn.

## **Chuyển đổi PowerPoint sang PDF có Ghi chú**

Phương thức `save` trong lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) có thể được sử dụng để chuyển đổi bài thuyết trình PPT hoặc PPTX sang PDF có ghi chú người thuyết trình. Với Aspose.Slides, bạn chỉ cần tải bài thuyết trình, cấu hình các tùy chọn bố cục bằng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/notescommentslayoutingoptions/) để bao gồm ghi chú, sau đó lưu tệp dưới dạng PDF. Đoạn mã dưới đây minh họa cách chuyển đổi một bài thuyết trình mẫu sang PDF ở chế độ xem Slide Ghi chú.

```php
$presentation = new Presentation("sample.pptx");

// Cấu hình tùy chọn PDF để hiển thị ghi chú người thuyết trình.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // Hiển thị ghi chú người thuyết trình dưới slide.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// Save the presentation to PDF with speaker notes.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="primary" %}} 
Bạn có thể muốn kiểm tra Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/vi/conversion). 
{{% /alert %}}