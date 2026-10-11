---
title: Chuyển đổi bài thuyết trình PowerPoint sang PDF có ghi chú trong Python
linktitle: PowerPoint sang PDF có ghi chú
type: docs
weight: 50
url: /vi/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang PDF
- bài thuyết trình sang PDF
- PPT sang PDF
- PPTX sang PDF
- lưu bài thuyết trình dưới dạng PDF
- xuất PPT sang PDF
- xuất PPTX sang PDF
- ghi chú người nói
- PDF có ghi chú
- Python
- Java
- Aspose.Slides
description: "Chuyển đổi các bài thuyết trình PPT và PPTX sang PDF có ghi chú người nói bằng cách sử dụng Aspose.Slides cho Python qua Java. Cấu hình vị trí ghi chú và bảo tồn các ghi chú dài."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi bài thuyết trình PowerPoint sang PDF có ghi chú người nói bằng Aspose.Slides cho Python thông qua Java. Bạn có thể đưa ghi chú phía dưới mỗi slide và cho phép ghi chú dài tiếp tục sang các trang bổ sung. Đối với các thiết lập xuất PDF khác, xem [Convert PowerPoint to PDF](/slides/vi/python-java/convert-powerpoint-to-pdf/).

Để đặt kích thước và hướng của trang ghi chú trước khi xuất, xem [Notes Page Size](/slides/vi/python-java/notes-size/).

## **Chuyển đổi PowerPoint sang PDF có Ghi chú**

Sử dụng phương thức [save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) để xuất một bài thuyết trình PPT hoặc PPTX sang PDF. Để bao gồm ghi chú người nói, tạo một đối tượng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notescommentslayoutingoptions/) và cấu hình vị trí ghi chú bằng phương thức [setNotesPosition](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) của nó. Gán bố cục này cho [PdfOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/) bằng cách sử dụng [setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Ví dụ dưới đây tải `sample.pptx` và xuất nó ra `output.pdf` với ghi chú người nói phía dưới các slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # Cấu hình tùy chọn PDF để hiển thị ghi chú người nói.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Lưu bài thuyết trình dưới dạng PDF có ghi chú người nói.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Bạn cũng có thể thử [Trình chuyển đổi PowerPoint sang PDF trực tuyến](https://products.aspose.app/slides/vi/conversion).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Làm sao để ngăn ghi chú người nói dài bị cắt ngắn?**

Sử dụng [NotesPositions.BottomFull](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notespositions/#BottomFull), như trong ví dụ trên. Cài đặt này hiển thị toàn bộ ghi chú, sử dụng các trang bổ sung khi cần.

**Tôi có thể giữ mỗi slide và ghi chú của nó trên một trang duy nhất không?**

Sử dụng [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notespositions/#BottomTruncated). Cài đặt này giới hạn ghi chú trong một trang, vì vậy những ghi chú không vừa có thể bị cắt ngắn.

**Làm thế nào để xuất slide mà không có ghi chú người nói?**

Bỏ qua cấu hình bố cục ghi chú và sử dụng xuất PDF tiêu chuẩn được mô tả trong [Convert PowerPoint to PDF](/slides/vi/python-java/convert-powerpoint-to-pdf/).