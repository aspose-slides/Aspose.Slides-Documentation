---
title: Chuyển đổi bài thuyết trình PowerPoint sang SWF Flash trong Python
linktitle: PowerPoint sang SWF Flash
type: docs
weight: 80
url: /vi/python-net/convert-powerpoint-to-swf-flash/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chuyển đổi slide
- PowerPoint sang SWF
- bài thuyết trình sang SWF
- slide sang SWF
- PPT sang SWF
- PPTX sang SWF
- PowerPoint
- bài thuyết trình
- Python
- Aspose.Slides
description: "Chuyển đổi PowerPoint (PPT/PPTX) sang SWF Flash trong Python bằng Aspose.Slides. Các mẫu mã từng bước, đầu ra chất lượng nhanh, không cần tự động hoá PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi bài thuyết trình PowerPoint sang SWF bằng cách sử dụng Aspose.Slides. Nó cho thấy cách lưu một bài thuyết trình dưới dạng tệp SWF với phương pháp [Presentation.save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/save/) và cách cấu hình xuất với [SwfOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/swfoptions/), bao gồm cài đặt trình xem và bố cục ghi chú hoặc bình luận.

## **Chuyển đổi bài thuyết trình sang Flash**

Phương pháp [save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/save/) được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) có thể được sử dụng để chuyển đổi toàn bộ bài thuyết trình thành tài liệu SWF. Bạn cũng có thể bao gồm bình luận trong SWF được tạo bằng cách sử dụng lớp [SWFOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/swfoptions/) và lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/notescommentslayoutingoptions/). Ví dụ sau cho thấy cách chuyển đổi một bài thuyết trình thành tài liệu SWF bằng cách sử dụng các tùy chọn được cung cấp bởi lớp SWFOptions.

```py
import aspose.slides as slides

# Tạo một đối tượng Presentation đại diện cho tệp bài thuyết trình
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Lưu bài thuyết trình và các trang ghi chú
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```

## **Câu hỏi thường gặp**

**Tôi có thể bao gồm các slide ẩn trong SWF không?**

Có. Bật tùy chọn [show_hidden_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) trong [SwfOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/swfoptions/). Mặc định, các slide ẩn không được xuất.

**Làm thế nào để tôi kiểm soát việc nén và kích thước cuối cùng của SWF?**

Sử dụng cờ [compressed](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/swfoptions/compressed/) (được bật theo mặc định) và điều chỉnh [jpeg_quality](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/swfoptions/jpeg_quality/) để cân bằng kích thước tệp và độ trung thực của hình ảnh.

**'viewer_included' dùng để làm gì, và khi nào tôi nên tắt nó?**

[viewer_included](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/swfoptions/viewer_included/) thêm giao diện người dùng trình phát nhúng (công cụ điều hướng, bảng, tìm kiếm). Tắt nó nếu bạn dự định sử dụng trình phát riêng của mình hoặc cần một khung SWF thuần không giao diện.

**Điều gì sẽ xảy ra nếu phông chữ nguồn thiếu trên máy xuất?**

Aspose.Slides sẽ thay thế phông chữ bạn chỉ định qua [default_regular_font](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/swfoptions/default_regular_font/) trong [SwfOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/swfoptions/) để tránh việc thay thế không mong muốn.