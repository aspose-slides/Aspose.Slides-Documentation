---
title: ПереходСлайда
type: docs
weight: 110
url: /ru/python-net/examples/elements/slide-transition/
keywords:
- переход слайда
- добавить переход слайда
- доступ к переходу слайда
- удалить переход слайда
- длительность перехода
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Управляйте переходами слайдов в Python с помощью Aspose.Slides: выбирайте типы, скорость, звук и тайминг, чтобы улучшить презентации в PPT, PPTX и ODP."
---
Показывает, как применять эффекты переходов слайдов и тайминги с помощью **Aspose.Slides for Python via .NET**.

## **Добавить переход слайда**

Примените эффект плавного перехода к первому слайду.

```py
def add_slide_transition():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Применить плавный переход.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.FADE

        presentation.save("slide_transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Доступ к переходу слайда**

Прочитайте тип перехода, текущий для слайда.

```py
def access_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Доступ к типу перехода.
        transition_type = slide.slide_show_transition.type
```

## **Удалить переход слайда**

Очистите любой эффект перехода, установив тип в `NONE`.

```py
def remove_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Удалить переход, установив NONE.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.NONE

        presentation.save("slide_transition_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить длительность перехода**

Укажите, как долго слайд отображается до автоматического перехода.

```py
def set_transition_duration():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        slide.slide_show_transition.advance_on_click = True
        slide.slide_show_transition.advance_after_time = 2000  # в миллисекундах.

        presentation.save("transition_duration.pptx", slides.export.SaveFormat.PPTX)
```