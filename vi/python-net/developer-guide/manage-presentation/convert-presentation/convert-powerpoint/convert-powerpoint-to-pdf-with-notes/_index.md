---
title: Chuyển đổi bản trình chiếu sang PDF có ghi chú trong Python
linktitle: Bản trình chiếu sang PDF có ghi chú
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
- ghi chú diễn giả
- PDF có ghi chú
- Python
- Aspose.Slides
description: "Chuyển đổi các định dạng PPT, PPTX và ODP sang PDF có ghi chú bằng Aspose.Slides cho Python. Bảo tồn bố cục và ghi chú diễn giả cho các bản trình chiếu chuyên nghiệp."
---
## **Tổng quan**

Trong bài viết này, bạn sẽ tìm hiểu cách chuyển đổi các bản trình chiếu PowerPoint sang định dạng PDF có ghi chú diễn giả bằng Aspose.Slides. Hướng dẫn này sẽ trình bày các bước cần thiết và cung cấp các ví dụ mã để giúp bạn thực hiện nhiệm vụ này một cách hiệu quả. Cuối bài, bạn sẽ có khả năng:

- Thực hiện quy trình chuyển đổi để biến các slide PowerPoint thành tài liệu PDF đồng thời giữ lại ghi chú diễn giả.
- Tùy chỉnh PDF đầu ra để đảm bảo ghi chú diễn giả được bao gồm và định dạng theo yêu cầu của bạn.

## **Chuyển đổi PowerPoint sang PDF có Ghi chú**

Phương thức `save` trong lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) có thể được sử dụng để chuyển đổi bản trình chiếu PPT hoặc PPTX sang PDF có ghi chú diễn giả. Với Aspose.Slides, bạn chỉ cần tải bản trình chiếu, cấu hình các tùy chọn bố cục bằng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/notescommentslayoutingoptions/) để bao gồm ghi chú diễn giả, sau đó lưu tệp dưới dạng PDF. Đoạn mã sau minh họa cách chuyển đổi một bản trình chiếu mẫu sang PDF ở chế độ xem Notes Slide.

```py
with slides.Presentation("sample.pptx") as presentation:

    # Cấu hình tùy chọn PDF để hiển thị ghi chú diễn giả.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # Lưu bản trình chiếu sang PDF có ghi chú diễn giả.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="primary" %}} 

Bạn có thể muốn khám phá Aspose [Trình chuyển đổi PowerPoint sang PDF Trực tuyến](https://products.aspose.app/slides/vi/conversion). 

{{% /alert %}}