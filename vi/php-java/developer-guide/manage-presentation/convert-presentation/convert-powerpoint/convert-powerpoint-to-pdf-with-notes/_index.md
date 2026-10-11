---
title: Chuyển Đổi Bản Trình Chiếu PowerPoint Sang PDF Có Ghi Chú trong PHP
linktitle: PowerPoint sang PDF có Ghi Chú
type: docs
weight: 50
url: /vi/php-java/convert-powerpoint-to-pdf-with-notes/
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
- PHP
- Aspose.Slides
description: "Chuyển đổi định dạng PPT và PPTX sang PDF có ghi chú bằng Aspose.Slides cho PHP qua Java. Bảo tồn bố cục và ghi chú người thuyết trình cho các bản trình chiếu chuyên nghiệp."
---
## **Overview**

Trong bài viết này, bạn sẽ tìm hiểu cách chuyển đổi bản trình chiếu PowerPoint sang định dạng PDF kèm ghi chú người thuyết trình bằng Aspose.Slides. Hướng dẫn này sẽ trình bày các bước cần thiết và cung cấp ví dụ mã để giúp bạn thực hiện nhiệm vụ này một cách hiệu quả. Khi kết thúc bài viết, bạn sẽ có thể:

- Thực hiện quá trình chuyển đổi để biến các slide PowerPoint thành tài liệu PDF đồng thời bảo tồn ghi chú người thuyết trình.
- Tùy chỉnh PDF đầu ra để đảm bảo ghi chú người thuyết trình được bao gồm và định dạng theo yêu cầu của bạn.

Để thiết lập kích thước và hướng của trang ghi chú trước khi xuất, xem [Kích Thước Trang Ghi Chú](/slides/vi/php-java/notes-size/).

## **Convert PowerPoint to PDF with Notes**

Phương thức `save` trong lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) có thể được sử dụng để chuyển đổi bản trình chiếu PPT hoặc PPTX sang PDF kèm ghi chú người thuyết trình. Với Aspose.Slides, bạn chỉ cần tải bản trình chiếu, cấu hình các tùy chọn bố cục bằng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/notescommentslayoutingoptions/) để bao gồm ghi chú người thuyết trình, sau đó lưu tệp dưới dạng PDF. Đoạn mã mẫu sau đây minh họa cách chuyển đổi một bản trình chiếu mẫu sang PDF ở chế độ xem Slide Ghi Chú.

```php
$presentation = new Presentation("sample.pptx");

// Cấu hình tùy chọn PDF để hiển thị ghi chú người thuyết trình.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // Hiển thị ghi chú người thuyết trình ở dưới slide.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// Lưu bản trình chiếu thành PDF có ghi chú người thuyết trình.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="info" title="Note" %}}
Bạn có thể muốn thử công cụ Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/vi/conversion).
{{% /alert %}}