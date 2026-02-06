---
title: 幻灯片过渡
type: docs
weight: 110
url: /zh/python-net/examples/elements/slide-transition/
keywords:
- 幻灯片过渡
- 添加幻灯片过渡
- 访问幻灯片过渡
- 移除幻灯片过渡
- 过渡持续时间
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中控制幻灯片过渡：选择类型、速度、声音和时间，以完善 PPT、PPTX 和 ODP 中的演示文稿。"
---
演示了使用 **Aspose.Slides for Python via .NET** 应用幻灯片过渡效果和时间设置。

## **添加幻灯片过渡**

对第一张幻灯片应用淡入过渡效果。

```py
def add_slide_transition():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 应用淡入过渡。
        slide.slide_show_transition.type = slides.slideshow.TransitionType.FADE

        presentation.save("slide_transition.pptx", slides.export.SaveFormat.PPTX)
```

## **访问幻灯片过渡**

读取当前分配给幻灯片的过渡类型。

```py
def access_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # 访问过渡类型。
        transition_type = slide.slide_show_transition.type
```

## **移除幻灯片过渡**

通过将类型设置为 `NONE` 来清除所有过渡效果。

```py
def remove_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # 通过设置为 NONE 移除过渡。
        slide.slide_show_transition.type = slides.slideshow.TransitionType.NONE

        presentation.save("slide_transition_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **设置过渡持续时间**

指定幻灯片在自动前进之前的显示时长。

```py
def set_transition_duration():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        slide.slide_show_transition.advance_on_click = True
        slide.slide_show_transition.advance_after_time = 2000  # 以毫秒为单位。

        presentation.save("transition_duration.pptx", slides.export.SaveFormat.PPTX)
```