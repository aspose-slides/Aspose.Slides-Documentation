---
title: Hoạt ảnh
type: docs
weight: 100
url: /vi/python-net/examples/elements/animation/
keywords:
- hoạt ảnh
- thêm hoạt ảnh
- truy cập hoạt ảnh
- xóa hoạt ảnh
- chuỗi hoạt ảnh
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Thành thạo các hoạt ảnh slide trong Python với Aspose.Slides: thêm, chỉnh sửa và xóa các hiệu ứng, thời gian và trình kích hoạt để tạo bản trình chiếu động ở định dạng PPT, PPTX và ODP."
---
Hiển thị cách tạo các hoạt ảnh đơn giản và quản lý chuỗi của chúng bằng **Aspose.Slides for Python via .NET**.

## **Thêm một Hoạt ảnh**

Tạo một hình chữ nhật và áp dụng hiệu ứng mờ dần được kích hoạt khi nhấp.

```py
def add_animation():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)

        # Thêm hiệu ứng fade in.
        slide.timeline.main_sequence.add_effect(
            shape,
            slides.animation.EffectType.FADE,
            slides.animation.EffectSubtype.NONE,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy cập một Hoạt ảnh**

Lấy hiệu ứng hoạt ảnh đầu tiên từ dòng thời gian của slide.

```py
def access_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Truy cập hiệu ứng hoạt ảnh đầu tiên.
        effect = slide.timeline.main_sequence[0]
```

## **Xóa một Hoạt ảnh**

Xóa một hiệu ứng hoạt ảnh khỏi chuỗi.

```py
def remove_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Giả sử chuỗi chính chứa ít nhất một hiệu ứng.
        effect = slide.timeline.main_sequence[0]

        # Xóa hiệu ứng.
        slide.timeline.main_sequence.remove(effect)

        presentation.save("animation_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Chuỗi Các Hoạt ảnh**

Thêm nhiều hiệu ứng và trình bày thứ tự các hoạt ảnh diễn ra.

```py
def sequence_animations():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 200, 50, 100, 100)

        sequence = slide.timeline.main_sequence
        sequence.add_effect(
            shape1,
            slides.animation.EffectType.FLY,
            slides.animation.EffectSubtype.BOTTOM,
            slides.animation.EffectTriggerType.ON_CLICK)
        sequence.add_effect(
            shape2,
            slides.animation.EffectType.FLY,
            slides.animation.EffectSubtype.BOTTOM,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation_sequence.pptx", slides.export.SaveFormat.PPTX)
```