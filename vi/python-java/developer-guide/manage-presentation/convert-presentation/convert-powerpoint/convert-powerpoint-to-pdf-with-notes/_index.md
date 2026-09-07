---
title: Chuyển Đổi Bản Trình Chiếu PowerPoint sang PDF có Ghi chú trong Python
linktitle: PowerPoint sang PDF có Ghi chú
type: docs
weight: 50
url: /vi/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang PDF
- bản trình chiếu sang PDF
- PPT sang PDF
- PPTX sang PDF
- lưu bản trình chiếu dưới dạng PDF
- xuất PPT sang PDF
- xuất PPTX sang PDF
- ghi chú diễn giả
- PDF có ghi chú
- Python
- Java
- Aspose.Slides
description: "Chuyển đổi các bản trình chiếu PPT và PPTX sang PDF có ghi chú diễn giả bằng Aspose.Slides cho Python qua Java. Cấu hình vị trí ghi chú và bảo tồn ghi chú dài."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi bản trình chiếu PowerPoint sang PDF có ghi chú diễn giả bằng Aspose.Slides cho Python thông qua Java. Bạn có thể chèn ghi chú dưới mỗi slide và cho phép ghi chú dài tiếp tục sang các trang bổ sung. Đối với các thiết lập xuất PDF khác, xem [Chuyển PowerPoint sang PDF](/slides/vi/python-java/convert-powerpoint-to-pdf/).

## **Chuyển PowerPoint sang PDF với Ghi chú**

Sử dụng phương thức [save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) để xuất bản trình chiếu PPT hoặc PPTX sang PDF. Để bao gồm ghi chú diễn giả, tạo đối tượng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notescommentslayoutingoptions/) và cấu hình phương thức [setNotesPosition](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Gán bố cục này cho [PdfOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/) bằng cách sử dụng [setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Ví dụ sau tải `sample.pptx` và xuất ra `output.pdf` với ghi chú diễn giả bên dưới các slide:

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

    # Lưu bản trình chiếu dưới dạng PDF có ghi chú diễn giả.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Bạn cũng có thể thử [Công cụ chuyển đổi PowerPoint sang PDF trực tuyến](https://products.aspose.app/slides/vi/conversion).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Làm thế nào để ngăn ghi chú diễn giả dài bị cắt bỏ?**

Sử dụng [NotesPositions.BottomFull](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notespositions/#BottomFull), như trong ví dụ trên. Cài đặt này hiển thị toàn bộ ghi chú, sử dụng các trang bổ sung khi cần.

**Tôi có thể giữ mỗi slide và ghi chú của nó trên một trang duy nhất không?**

Sử dụng [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notespositions/#BottomTruncated). Cài đặt này giới hạn ghi chú trong một trang, do đó các ghi chú không vừa có thể bị cắt ngắn.

**Làm sao để xuất slide mà không có ghi chú diễn giả?**

Bỏ qua cấu hình bố cục ghi chú và sử dụng xuất PDF tiêu chuẩn được mô tả trong [Chuyển PowerPoint sang PDF](/slides/vi/python-java/convert-powerpoint-to-pdf/).