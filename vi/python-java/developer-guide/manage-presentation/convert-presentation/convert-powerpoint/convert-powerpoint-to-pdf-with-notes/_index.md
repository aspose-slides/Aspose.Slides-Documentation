---
title: Chuyển đổi bản trình bày PowerPoint sang PDF có ghi chú trong Python
linktitle: PowerPoint sang PDF có ghi chú
type: docs
weight: 50
url: /vi/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình bày
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang PDF
- bản trình bày sang PDF
- PPT sang PDF
- PPTX sang PDF
- lưu bản trình bày dưới dạng PDF
- xuất PPT sang PDF
- xuất PPTX sang PDF
- ghi chú diễn giả
- PDF có ghi chú
- Python
- Java
- Aspose.Slides
description: "Chuyển đổi các bản trình bày PPT và PPTX sang PDF có ghi chú diễn giả bằng cách sử dụng Aspose.Slides cho Python qua Java. Cấu hình vị trí ghi chú và bảo tồn các ghi chú dài."
---
## **Overview**

Bài viết này giải thích cách chuyển đổi bản trình bày PowerPoint sang PDF có kèm ghi chú diễn giả bằng Aspose.Slides cho Python thông qua Java. Bạn có thể đưa ghi chú vào dưới mỗi slide và cho phép ghi chú dài tiếp tục sang các trang bổ sung. Đối với các cài đặt xuất PDF khác, hãy xem [Convert PowerPoint to PDF](/slides/vi/python-java/convert-powerpoint-to-pdf/).

## **Convert PowerPoint to PDF with Notes**

Sử dụng phương thức [save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) để xuất bản trình bày PPT hoặc PPTX sang PDF. Để bao gồm ghi chú diễn giả, tạo một đối tượng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notescommentslayoutingoptions/) và cấu hình vị trí ghi chú bằng phương thức [setNotesPosition](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Gán layout này cho [PdfOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/) bằng cách sử dụng [setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Ví dụ sau tải `sample.pptx` và xuất nó thành `output.pdf` với ghi chú diễn giả được đặt dưới các slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # Cấu hình tùy chọn PDF để hiển thị ghi chú diễn giả.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Lưu bản trình bày thành PDF có ghi chú diễn giả.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}

Bạn cũng có thể thử công cụ [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/vi/conversion).

{{% /alert %}}

## **FAQ**

**How can I prevent long speaker notes from being cut off?**

Sử dụng [NotesPositions.BottomFull](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notespositions/#BottomFull), như trong ví dụ trên. Cài đặt này hiển thị đầy đủ ghi chú, sử dụng các trang bổ sung khi cần.

**Can I keep each slide and its notes on a single page?**

Sử dụng [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notespositions/#BottomTruncated). Cài đặt này giới hạn ghi chú trong một trang, vì vậy các ghi chú không vừa có thể bị cắt ngắn.

**How do I export slides without speaker notes?**

Bỏ qua cấu hình layout ghi chú và sử dụng xuất PDF tiêu chuẩn được mô tả trong [Convert PowerPoint to PDF](/slides/vi/python-java/convert-powerpoint-to-pdf/).