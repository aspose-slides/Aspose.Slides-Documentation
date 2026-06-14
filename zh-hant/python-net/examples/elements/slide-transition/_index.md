---
title: 投影片切換
type: docs
weight: 110
url: /zh-hant/python-net/examples/elements/slide-transition/
keywords:
- 投影片切換
- 新增投影片切換
- 存取投影片切換
- 移除投影片切換
- 切換持續時間
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 控制投影片切換：選擇類型、速度、音效與時間，以完善 PPT、PPTX 和 ODP 簡報。"
---
展示如何使用 **Aspose.Slides for Python via .NET** 套用投影片切換效果與時間設定。

## **新增投影片切換**

將淡入切換效果套用到第一張投影片。

```py
def add_slide_transition():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 套用淡入切換。
        slide.slide_show_transition.type = slides.slideshow.TransitionType.FADE

        presentation.save("slide_transition.pptx", slides.export.SaveFormat.PPTX)
```

## **存取投影片切換**

讀取目前指派給投影片的切換類型。

```py
def access_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # 存取切換類型。
        transition_type = slide.slide_show_transition.type
```

## **移除投影片切換**

將類型設定為 `NONE` 以清除任何切換效果。

```py
def remove_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # 透過設定 none 來移除切換。
        slide.slide_show_transition.type = slides.slideshow.TransitionType.NONE

        presentation.save("slide_transition_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **設定切換持續時間**

指定投影片在自動前進前的顯示時長。

```py
def set_transition_duration():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        slide.slide_show_transition.advance_on_click = True
        slide.slide_show_transition.advance_after_time = 2000  # 以毫秒為單位。

        presentation.save("transition_duration.pptx", slides.export.SaveFormat.PPTX)
```