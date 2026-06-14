---
title: HeaderFooter
type: docs
weight: 220
url: /vi/python-net/examples/elements/header-footer/
keywords:
- đầu trang và chân trang
- thêm đầu trang và chân trang
- cập nhật đầu trang và chân trang
- đặt ngày và giờ
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Kiểm soát đầu trang và chân trang trong Python với Aspose.Slides: thêm hoặc chỉnh sửa ngày/giờ, số slide và văn bản chân trang, hiển thị hoặc ẩn các trường giữ chỗ trên PPT, PPTX và ODP."
---
Hiển thị cách thêm chân trang và cập nhật các trường giữ chỗ ngày và giờ bằng **Aspose.Slides for Python via .NET**.

## **Thêm Chân Trang**
Thêm văn bản vào khu vực chân trang của một slide và làm cho nó hiển thị.

```py
def add_footer():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_footer_text("My footer")
        slide.header_footer_manager.set_footer_visibility(True)

        presentation.save("footer.pptx", slides.export.SaveFormat.PPTX)
```

## **Cập nhật Ngày và Giờ**
Sửa đổi trường giữ chỗ ngày và giờ trên một slide.

```py
def add_date_time():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_date_time_text("01/01/2024")
        slide.header_footer_manager.set_date_time_visibility(True)

        presentation.save("date_time.pptx", slides.export.SaveFormat.PPTX)
```