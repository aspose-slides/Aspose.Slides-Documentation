---
title: Thêm Slides vào Bản Trình Bày với Python
linktitle: Thêm Slide
type: docs
weight: 10
url: /vi/python-net/add-slide-to-presentation/
keywords:
- thêm slide
- tạo slide
- slide trống
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Dễ dàng thêm slide vào các bản PowerPoint và OpenDocument của bạn bằng Aspose.Slides cho Python qua .NET—chèn slide liền mạch, hiệu quả chỉ trong vài giây."
---
## **Overview**

Trước khi thêm các slide vào bản trình bày, việc hiểu cách PowerPoint tổ chức chúng sẽ hữu ích. Mỗi bản trình bày chứa một master slide, các layout slide tùy chọn và một hoặc nhiều slide bình thường. Mỗi slide có một ID duy nhất và các slide bình thường được sắp xếp theo chỉ mục bắt đầu từ 0. Bài viết này hướng dẫn cách sử dụng Aspose.Slides cho Python để tạo slide và chọn layout phù hợp.

## **Add Slides to Presentations**

Aspose.Slides cho phép bạn bổ sung các slide mới dựa trên các layout slide hiện có. Ví dụ bên dưới sẽ lặp qua từng layout trong bản trình bày, thêm một slide sử dụng layout đó và sau đó lưu tệp.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
1. Truy cập [SlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/) .
1. Đối với mỗi mục trong `presentation.layout_slides`, gọi `add_empty_slide` để thêm một slide sử dụng layout đó.
1. Tùy chọn sửa đổi các slide vừa được thêm.
1. Lưu bản trình bày dưới dạng tệp PPTX.

```py
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation.
with slides.Presentation() as presentation:
    # Truy cập bộ sưu tập slide.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Thêm một slide trống vào bộ sưu tập slide.
        slides.add_empty_slide(layout_slide)

    # Thực hiện một số công việc trên các slide mới được thêm.

    # Lưu bản trình bày vào đĩa.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I insert a new slide at a specific position, not just at the end?**

Có. Thư viện hỗ trợ các bộ sưu tập slide và các thao tác [insert](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/insert_clone/) , vì vậy bạn có thể thêm một slide vào chỉ mục yêu cầu thay vì chỉ ở cuối.

**Are the theme/styles preserved when adding a slide based on a layout?**

Có. Layout kế thừa định dạng từ master của nó, và slide mới kế thừa từ layout đã chọn và master liên quan.

**Which slide is present in a new "empty" presentation before adding slides?**

Một bản trình bày mới tạo đã chứa sẵn một slide trống với chỉ mục zero. Điều này quan trọng khi tính toán chỉ mục chèn.

**How do I choose the "right" layout for a new slide if the master has many options?**

Thông thường, chọn [LayoutSlide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslide/) phù hợp với cấu trúc yêu cầu ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidelayouttype/)). Nếu layout đó thiếu, bạn có thể [add it to the master](/slides/vi/python-net/slide-layout/) và sau đó sử dụng.