---
title: Chuyển đổi bài thuyết trình ở chế độ Handout với Python
linktitle: Chế độ Handout
type: docs
weight: 150
url: /vi/python-net/convert-powerpoint-in-handout-mode/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chế độ handout
- handout
- PowerPoint
- bài thuyết trình
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Chuyển đổi bài thuyết trình thành handout trong Python. Đặt số slide trên mỗi trang, giữ ghi chú, xuất ra PDF hoặc hình ảnh với Aspose.Slides, kèm mã mẫu. Dùng thử miễn phí."
---
## **Giới thiệu**

Aspose.Slides cung cấp khả năng chuyển đổi bài thuyết trình sang các định dạng khác nhau, bao gồm tạo tài liệu handout để in ở chế độ Handout. Chế độ này cho phép bạn cấu hình cách nhiều slide xuất hiện trên một trang, hữu ích cho hội nghị, hội thảo và các sự kiện khác. Bạn có thể bật chế độ này bằng cách đặt thuộc tính `slides_layout_options` trong các lớp [PdfOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/htmloptions/), và [TiffOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/) .

## **Xuất ở chế độ Handout**

Để cấu hình chế độ Handout, sử dụng đối tượng [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/handoutlayoutingoptions/) , nó xác định số slide được đặt trên một trang duy nhất và các tham số hiển thị khác.

Dưới đây là ví dụ mã cho thấy cách chuyển đổi một bài thuyết trình sang PDF ở chế độ Handout.

```py
# Tải một bài thuyết trình.
with slides.Presentation("sample.pptx") as presentation:

    # Đặt các tùy chọn xuất.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 slide trên một trang theo chiều ngang
    slides_layout_options.print_slide_numbers = True                                 # in số slide
    slides_layout_options.print_frame_slide = True                                   # in khung quanh các slide
    slides_layout_options.print_comments = False                                     # không có bình luận

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # Xuất bài thuyết trình ra PDF với bố cục đã chọn.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" %}} 
Lưu ý rằng thuộc tính `slides_layout_options` chỉ khả dụng cho một số định dạng đầu ra nhất định, chẳng hạn như PDF, HTML, TIFF, và khi render dưới dạng hình ảnh.
{{% /alert %}} 

## **Câu hỏi thường gặp**

**Số lượng thumbnail slide tối đa trên mỗi trang trong chế độ Handout là bao nhiêu?**

Aspose.Slides hỗ trợ [presets](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/handouttype/) lên đến 9 thumbnail trên mỗi trang với thứ tự ngang hoặc dọc: 1, 2, 3, 4 (ngang/dọc), 6 (ngang/dọc) và 9 (ngang/dọc).

**Tôi có thể định nghĩa lưới tùy chỉnh, chẳng hạn 5 hoặc 8 slide trên mỗi trang không?**

Không. Số lượng và thứ tự của các thumbnail được kiểm soát chặt chẽ bởi enumeration [HandoutType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/handouttype/) ; các bố cục tùy ý không được hỗ trợ.

**Tôi có thể bao gồm các slide ẩn trong đầu ra Handout không?**

Có. Bật tùy chọn `show_hidden_slides` trong cài đặt xuất cho định dạng mục tiêu, chẳng hạn như [PdfOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/htmloptions/), hoặc [TiffOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/).