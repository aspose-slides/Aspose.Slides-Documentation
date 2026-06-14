---
title: Chuyển đổi slide
type: docs
weight: 110
url: /vi/python-net/examples/elements/slide-transition/
keywords:
- chuyển đổi slide
- thêm chuyển đổi slide
- truy cập chuyển đổi slide
- xóa chuyển đổi slide
- thời lượng chuyển đổi
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Kiểm soát chuyển đổi slide trong Python với Aspose.Slides: chọn loại, tốc độ, âm thanh và thời gian để tinh chỉnh bản trình chiếu ở định dạng PPT, PPTX và ODP."
---
Trình bày cách áp dụng hiệu ứng chuyển đổi slide và thời gian với **Aspose.Slides for Python via .NET**.

## **Thêm chuyển đổi slide**

Áp dụng hiệu ứng chuyển đổi mờ dần cho slide đầu tiên.

```py
def add_slide_transition():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Áp dụng hiệu ứng chuyển đổi mờ dần.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.FADE

        presentation.save("slide_transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy cập chuyển đổi slide**

Đọc loại chuyển đổi hiện đang được gán cho một slide.

```py
def access_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Truy cập loại chuyển đổi.
        transition_type = slide.slide_show_transition.type
```

## **Xóa chuyển đổi slide**

Xóa mọi hiệu ứng chuyển đổi bằng cách đặt loại thành `NONE`.

```py
def remove_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Xóa chuyển đổi bằng cách đặt none.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.NONE

        presentation.save("slide_transition_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt thời lượng chuyển đổi**

Xác định thời gian hiển thị slide trước khi tự động chuyển sang slide tiếp theo.

```py
def set_transition_duration():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        slide.slide_show_transition.advance_on_click = True
        slide.slide_show_transition.advance_after_time = 2000  # tính bằng mili giây.

        presentation.save("transition_duration.pptx", slides.export.SaveFormat.PPTX)
```