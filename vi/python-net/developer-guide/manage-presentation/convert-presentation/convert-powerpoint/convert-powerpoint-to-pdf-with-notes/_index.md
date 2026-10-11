---
title: Chuyển đổi Bản trình chiếu sang PDF có Ghi chú trong Python
linktitle: Bản trình chiếu sang PDF có Ghi chú
type: docs
weight: 50
url: /vi/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi OpenDocument
- chuyển đổi bản trình chiếu
- chuyển đổi PPT
- chuyển đổi PPTX
- chuyển đổi ODP
- PowerPoint sang PDF
- OpenDocument sang PDF
- bản trình chiếu sang PDF
- PPT sang PDF
- PPTX sang PDF
- ODP sang PDF
- ghi chú người thuyết trình
- PDF có ghi chú
- Python
- Aspose.Slides
description: "Chuyển đổi các định dạng PPT, PPTX và ODP sang PDF có ghi chú bằng Aspose.Slides cho Python. Bảo lưu bố cục và ghi chú người thuyết trình cho các bản trình chiếu chuyên nghiệp."
---
## **Tổng quan**

Trong bài viết này, bạn sẽ học cách chuyển đổi bản trình chiếu PowerPoint sang định dạng PDF có ghi chú người thuyết trình bằng Aspose.Slides. Hướng dẫn này sẽ trình bày các bước cần thiết và cung cấp các ví dụ mã để giúp bạn thực hiện nhiệm vụ này một cách hiệu quả. Khi kết thúc bài viết, bạn sẽ có thể:

- Thực hiện quy trình chuyển đổi để chuyển các slide PowerPoint thành tài liệu PDF trong khi vẫn giữ nguyên ghi chú người thuyết trình.
- Tùy chỉnh PDF đầu ra để đảm bảo ghi chú người thuyết trình được bao gồm và định dạng theo yêu cầu của bạn.

Để đặt kích thước và hướng của trang ghi chú trước khi xuất, xem [Kích thước Trang Ghi chú](/slides/vi/python-net/notes-size/).

## **Chuyển PowerPoint sang PDF có Ghi chú**

Phương thức `save` trong lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) có thể được sử dụng để chuyển đổi bản trình chiếu PPT hoặc PPTX sang PDF có ghi chú người thuyết trình. Với Aspose.Slides, bạn chỉ cần tải bản trình chiếu, cấu hình các tùy chọn bố cục bằng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/notescommentslayoutingoptions/) để bao gồm ghi chú người thuyết trình, và sau đó lưu tệp dưới dạng PDF. Đoạn mã sau đây minh họa cách chuyển đổi một bản trình chiếu mẫu sang PDF ở chế độ xem Slide Ghi chú.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    # Cấu hình tùy chọn PDF để hiển thị ghi chú người thuyết trình.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # Lưu bản trình chiếu thành PDF có ghi chú người thuyết trình.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="info" title="Note" %}}
Bạn có thể muốn xem Aspose [Trình chuyển đổi PowerPoint sang PDF trực tuyến](https://products.aspose.app/slides/vi/conversion).
{{% /alert %}}