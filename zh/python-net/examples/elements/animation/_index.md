---
title: 动画
type: docs
weight: 100
url: /zh/python-net/examples/elements/animation/
keywords:
- 动画
- 添加动画
- 访问动画
- 移除动画
- 动画序列
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中掌握幻灯片动画：添加、编辑和移除效果、时间和触发器，以在 PPT、PPTX 和 ODP 中创建动态演示文稿。"
---
展示如何使用 **Aspose.Slides for Python via .NET** 创建简单动画并管理其序列。

## **添加动画**

创建一个矩形形状，并在点击时应用淡入效果。

```py
def add_animation():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)

        # 添加淡入效果。
        slide.timeline.main_sequence.add_effect(
            shape,
            slides.animation.EffectType.FADE,
            slides.animation.EffectSubtype.NONE,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation.pptx", slides.export.SaveFormat.PPTX)
```

## **访问动画**

从幻灯片时间轴检索第一个动画效果。

```py
def access_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # 访问第一个动画效果。
        effect = slide.timeline.main_sequence[0]
```

## **移除动画**

从序列中移除动画效果。

```py
def remove_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # 假设主序列至少包含一个效果。
        effect = slide.timeline.main_sequence[0]

        # 移除该效果。
        slide.timeline.main_sequence.remove(effect)

        presentation.save("animation_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **动画顺序**

添加多个效果并演示动画发生的顺序。

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