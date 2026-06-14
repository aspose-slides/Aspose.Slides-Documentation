---
title: "Hoạt ảnh văn bản PowerPoint bằng Python"
linktitle: "Văn bản hoạt ảnh"
type: docs
weight: 60
url: /vi/python-net/animated-text/
keywords:
- văn bản hoạt ảnh
- hoạt ảnh văn bản
- đoạn văn hoạt ảnh
- hoạt ảnh đoạn văn
- hiệu ứng hoạt ảnh
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tạo văn bản hoạt ảnh động trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Python thông qua .NET, với các ví dụ mã được tối ưu và dễ theo dõi."
---
## **Tổng quan**

Bài viết này hướng dẫn cách tạo hoạt ảnh cho văn bản trong bản trình chiếu PowerPoint bằng Aspose.Slides for Python. Bạn sẽ học cách thêm hiệu ứng vào các đoạn văn riêng lẻ, điều chỉnh trigger, và đọc lại các chuỗi hoạt ảnh hiện có. Khi hoàn thành, bạn sẽ có thể tạo quy trình hoạt ảnh văn bản có thể tái sử dụng, xuất ra PPTX tiêu chuẩn và phát đúng trong PowerPoint.

## **Thêm hiệu ứng hoạt ảnh cho đoạn văn**

Phương thức [add_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/sequence/add_effect/) của lớp [Sequence](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/sequence/) cho phép bạn áp dụng một hiệu ứng hoạt ảnh cho một đoạn văn duy nhất. Mã mẫu bên dưới minh họa cách thực hiện:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    # Chọn đoạn văn để thêm hiệu ứng.
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Thêm hiệu ứng hoạt ảnh Fly vào đoạn văn đã chọn.
    effect = slide.timeline.main_sequence.add_effect(paragraph,
                                                     slides.animation.EffectType.FLY,
                                                     slides.animation.EffectSubtype.LEFT,
                                                     slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("ParagraphAnimationEffect.pptx", slides.export.SaveFormat.PPTX)
```

## **Lấy hiệu ứng hoạt ảnh của đoạn văn**

Bạn có thể muốn xác định các hiệu ứng hoạt ảnh nào đã được áp dụng cho một đoạn văn — ví dụ, nếu bạn dự định sao chép các hiệu ứng đó sang một đoạn văn hoặc hình dạng khác.

Aspose.Slides for Python cho phép bạn lấy tất cả các hiệu ứng hoạt ảnh đã áp dụng cho các đoạn văn trong một khung văn bản (shape). Mã mẫu bên dưới cho thấy cách lấy các hiệu ứng hoạt ảnh của một đoạn văn:

```py
import aspose.slides as slides

with slides.Presentation("ParagraphAnimationEffect.pptx") as presentation:
    slide = presentation.slides[0]
    sequence = slide.timeline.main_sequence
    auto_shape = slide.shapes[0]

    for paragraph in auto_shape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print(f"Paragraph \"{paragraph.text}\" has the first animation effect of type {str(effects[0].type)}.")
```

## **FAQ**

**Hoạt ảnh văn bản khác với chuyển tiếp slide như thế nào, và chúng có thể được kết hợp không?**

Hoạt ảnh văn bản điều khiển hành vi của đối tượng theo thời gian trên một slide, trong khi [transitions](/slides/vi/python-net/slide-transition/) điều khiển cách các slide thay đổi. Chúng độc lập và có thể được sử dụng cùng nhau; thứ tự phát được quyết định bởi dòng thời gian hoạt ảnh và các cài đặt chuyển tiếp.

**Các hoạt ảnh văn bản có được giữ lại khi xuất ra PDF hoặc hình ảnh không?**

Không. PDF và hình ảnh raster là tĩnh, vì vậy bạn sẽ chỉ thấy một trạng thái duy nhất của slide mà không có chuyển động. Để giữ lại chuyển động, hãy sử dụng xuất thành [video](/slides/vi/python-net/convert-powerpoint-to-video/) hoặc [HTML](/slides/vi/python-net/export-to-html5/).

**Các hoạt ảnh văn bản có hoạt động trong bố cục và slide master không?**

Các hiệu ứng được áp dụng cho các đối tượng layout/master sẽ được kế thừa bởi các slide, nhưng thời gian và tương tác của chúng với các hoạt ảnh cấp slide phụ thuộc vào chuỗi cuối cùng trên slide.