---
title: 動畫
type: docs
weight: 100
url: /zh-hant/python-net/examples/elements/animation/
keywords:
- 動畫
- 新增動畫
- 存取動畫
- 移除動畫
- 動畫序列
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 精通投影片動畫：新增、編輯和移除效果、時間與觸發條件，打造 PPT、PPTX 與 ODP 的動態簡報。"
---
展示如何使用 **Aspose.Slides for Python via .NET** 建立簡單動畫並管理其順序。

## **新增動畫**

建立一個矩形形狀，並套用在點擊時觸發的淡出效果。

```py
def add_animation():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)

        # 新增淡入效果。
        slide.timeline.main_sequence.add_effect(
            shape,
            slides.animation.EffectType.FADE,
            slides.animation.EffectSubtype.NONE,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation.pptx", slides.export.SaveFormat.PPTX)
```

## **存取動畫**

從投影片時間軸中取得第一個動畫效果。

```py
def access_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # 取得第一個動畫效果。
        effect = slide.timeline.main_sequence[0]
```

## **移除動畫**

從序列中移除動畫效果。

```py
def remove_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # 假設主序列至少包含一個效果。
        effect = slide.timeline.main_sequence[0]

        # 移除該效果。
        slide.timeline.main_sequence.remove(effect)

        presentation.save("animation_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **動畫序列**

新增多個效果，並示範動畫執行的順序。

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