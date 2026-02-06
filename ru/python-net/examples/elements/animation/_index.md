---
title: Анимация
type: docs
weight: 100
url: /ru/python-net/examples/elements/animation/
keywords:
- анимация
- добавить анимацию
- доступ к анимации
- удалить анимацию
- последовательность анимаций
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Освойте анимацию слайдов в Python с Aspose.Slides: добавляйте, редактируйте и удаляйте эффекты, тайминги и триггеры, чтобы создавать динамичные презентации в форматах PPT, PPTX и ODP."
---
Показывает, как создавать простые анимации и управлять их последовательностью с использованием **Aspose.Slides for Python via .NET**.

## **Добавить анимацию**

Создайте прямоугольную фигуру и примените эффект плавного появления, активируемый по щелчку.

```py
def add_animation():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)

        # Добавить эффект плавного появления.
        slide.timeline.main_sequence.add_effect(
            shape,
            slides.animation.EffectType.FADE,
            slides.animation.EffectSubtype.NONE,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation.pptx", slides.export.SaveFormat.PPTX)
```

## **Получить доступ к анимации**

Получите первый эффект анимации из временной шкалы слайда.

```py
def access_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Получить первый эффект анимации.
        effect = slide.timeline.main_sequence[0]
```

## **Удалить анимацию**

Удалите эффект анимации из последовательности.

```py
def remove_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Предполагая, что основная последовательность содержит хотя бы один эффект.
        effect = slide.timeline.main_sequence[0]

        # Удалить эффект.
        slide.timeline.main_sequence.remove(effect)

        presentation.save("animation_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Последовательность анимаций**

Добавьте несколько эффектов и продемонстрируйте порядок их выполнения.

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