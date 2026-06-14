---
title: Chuyển đổi bài trình chiếu PowerPoint sang TIFF có ghi chú trong Python
linktitle: PowerPoint sang TIFF có ghi chú
type: docs
weight: 100
url: /vi/python-net/convert-powerpoint-to-tiff-with-notes/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang TIFF
- bản trình chiếu sang TIFF
- slide sang TIFF
- PPT sang TIFF
- PPTX sang TIFF
- PowerPoint có ghi chú
- bản trình chiếu có ghi chú
- slide có ghi chú
- PPT có ghi chú
- PPTX có ghi chú
- TIFF có ghi chú
- Python
- Aspose.Slides
description: "Chuyển đổi các bài trình chiếu PowerPoint sang TIFF có ghi chú bằng Aspose.Slides cho Python qua .NET. Tìm hiểu cách xuất slide có ghi chú người thuyết trình một cách hiệu quả."
---
## **Giới thiệu**

Aspose.Slides for Python via .NET cung cấp một giải pháp đơn giản để chuyển đổi các bản trình chiếu PowerPoint và OpenDocument (PPT, PPTX và ODP) có ghi chú sang định dạng TIFF. Định dạng này được sử dụng rộng rãi cho việc lưu trữ hình ảnh chất lượng cao, in ấn và lưu trữ tài liệu. Với Aspose.Slides, bạn không chỉ có thể xuất toàn bộ bản trình chiếu cùng với ghi chú người thuyết trình mà còn tạo các hình thu nhỏ của slide trong chế độ Notes Slide. Quá trình chuyển đổi đơn giản và hiệu quả, sử dụng phương thức `save` của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) để biến toàn bộ bản trình chiếu thành một loạt các ảnh TIFF trong khi vẫn giữ nguyên ghi chú và bố cục.

## **Chuyển đổi bản trình chiếu sang TIFF có ghi chú**

Việc lưu một bản trình chiếu PowerPoint hoặc OpenDocument sang TIFF có ghi chú bằng Aspose.Slides for Python via .NET bao gồm các bước sau:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/): Tải file PowerPoint hoặc OpenDocument.
1. Cấu hình các tùy chọn bố cục đầu ra: Sử dụng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/notescommentslayoutingoptions/) để chỉ định cách hiển thị ghi chú và bình luận.
1. Lưu bản trình chiếu sang TIFF: Truyền các tùy chọn đã cấu hình vào phương thức [save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions).

Giả sử chúng ta có tệp "speaker_notes.pptx" với slide sau:

![Slide bản trình chiếu có ghi chú người thuyết trình](slide_with_notes.png)

```py
# Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
with slides.Presentation("speaker_notes.pptx") as presentation:
    
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL  # Hiển thị ghi chú phía dưới slide.
    
    # Cấu hình các tùy chọn TIFF với bố cục ghi chú.
    tiff_options = slides.export.TiffOptions()
    tiff_options.dpi_x = 300
    tiff_options.dpi_y = 300
    tiff_options.slides_layout_options = notes_options
    
    # Lưu bản trình chiếu sang TIFF với ghi chú người thuyết trình.
    presentation.save("TIFF_with_notes.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

Kết quả:

![Ảnh TIFF có ghi chú người thuyết trình](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Hãy xem công cụ chuyển đổi PowerPoint sang Poster miễn phí của Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/vi/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát vị trí của khu vực ghi chú trong file TIFF kết quả không?**

Có. Sử dụng [notes layout settings](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/slides_layout_options/) để chọn giữa các tùy chọn như `NONE`, `BOTTOM_TRUNCATED` hoặc `BOTTOM_FULL`, tương ứng ẩn ghi chú, đặt chúng vào một trang duy nhất, hoặc cho phép chúng trải dài sang các trang bổ sung.

**Làm thế nào tôi có thể giảm kích thước file TIFF có ghi chú mà không gây mất chất lượng đáng kể?**

Chọn một [efficient compression](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/compression_type/) (ví dụ `LZW` hoặc `RLE`), đặt DPI hợp lý và, nếu có thể chấp nhận, sử dụng [pixel format](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/pixel_format/) thấp hơn (như 8 bpp hoặc 1 bpp cho monochrome). Giảm nhẹ [image dimensions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/image_size/) cũng có thể giúp mà không ảnh hưởng đáng kể đến khả năng đọc.

**Phông chữ trong ghi chú có ảnh hưởng đến kết quả nếu các phông chữ gốc không có trên hệ thống không?**

Có. Khi thiếu phông chữ, sẽ kích hoạt [substitution](/slides/vi/python-net/font-selection-sequence/), có thể làm thay đổi kích thước và hiển thị của văn bản. Để tránh điều này, [cung cấp các phông chữ cần thiết](/slides/vi/python-net/custom-font/) hoặc đặt một [fallback font](/slides/vi/python-net/fallback-font/) mặc định để sử dụng đúng kiểu chữ mong muốn.