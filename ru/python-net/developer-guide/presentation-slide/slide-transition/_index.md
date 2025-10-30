---
title: Управление переходами слайдов в презентациях с помощью Python
linktitle: Переход слайда
type: docs
weight: 90
url: /ru/python-net/slide-transition/
keywords:
- переход слайда
- добавить переход слайда
- применить переход слайда
- продвинутый переход слайда
- морф-переход
- тип перехода
- эффект перехода
- Python
- Aspose.Slides
description: "Узнайте, как настроить переходы слайдов в Aspose.Slides для Python через .NET, с пошаговым руководством для презентаций PowerPoint и OpenDocument."
---

## **Обзор**

Aspose.Slides for Python предоставляет полный контроль над переходами слайдов, от выбора типа перехода до настройки времени и триггеров в рамках автоматизированных рабочих процессов презентаций. Вы можете установить автоматический переход слайдов по щелчку и/или после заданной задержки, а также уточнить визуальное поведение с помощью эффектов, таких как резкие переходы из черного или направленные входы. Библиотека также поддерживает морф‑переход, введенный в PowerPoint 2019, включая режимы морфа по объекту, слову или символу для создания плавного, согласованного движения между слайдами.

## **Добавить переходы слайдов**

Чтобы упростить понимание, в этом примере демонстрируется, как использовать Aspose.Slides for Python для управления простыми переходами слайдов. Разработчики могут применять различные эффекты переходов к слайдам и настраивать их поведение. Чтобы создать простой переход слайда, выполните следующие шаги:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Apply a slide transition using one of the effects from the [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) enum.
1. Save the modified presentation file.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation для загрузки файла презентации.
with slides.Presentation("sample.pptx") as presentation:
    # Применить круговой переход к слайду 1.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Применить гребенчатый переход к слайду 2.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Сохранить презентацию на диск.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавить расширенные переходы слайдов**

В этом разделе мы применили простой эффект перехода к слайду. Чтобы сделать этот эффект более контролируемым и отточенным, выполните следующие шаги:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Apply a slide transition using one of the effects from the [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) enum.
1. Configure the transition to Advance On Click, after a specific time period, or both.
1. Save the modified presentation file.

Если включена опция **Advance On Click**, слайд переходит только при щелчке пользователя. Если установлено свойство **Advance After Time**, слайд переходит автоматически после указанного интервала.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation для открытия файла презентации.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # Применить круговой переход к слайду 1.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Включить переход по клику и установить автоматический переход через 3 секунды.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # Применить гребенчатый переход к слайду 2.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Включить переход по клику и установить автоматический переход через 5 секунд.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # Применить зум‑переход к слайду 3.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Включить переход по клику и установить автоматический переход через 7 секунд.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # Сохранить презентацию на диск.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Морф‑переход**

Aspose.Slides for Python поддерживает [Morph transition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/), который анимирует плавное перемещение от одного слайда к другому. В этом разделе объясняется, как использовать морф‑переход. Чтобы эффективно использовать его, вам нужны два слайда с хотя бы одним общим объектом. Самый простой способ — продублировать слайд, а затем переместить объект в другое положение на втором слайде.

Следующий фрагмент кода показывает, как клонировать слайд, содержащий текст, и применить морф‑переход ко второму слайду.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Клонировать первый слайд, чтобы создать второй слайд с теми же фигурами для непрерывности морфа.
    slide1 = presentation.slides.add_clone(slide0)

    # Выбрать тот же прямоугольник на втором слайде и изменить его позицию и размер.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # Включить морф‑переход на втором слайде, чтобы плавно анимировать изменения фигур.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Типы морф‑переходов**

Перечисление [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) представляет различные типы морф‑переходов слайдов.

Следующий фрагмент кода показывает, как применить морф‑переход к слайду и изменить тип морфа:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить эффекты переходов**

Aspose.Slides for Python позволяет задавать эффекты переходов, такие как **From Black**, **From Left**, **From Right** и т.д. Чтобы настроить эффект перехода, выполните следующие шаги:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to the slide.
1. Set the desired transition effect.
1. Save the presentation as a PPTX file.

В примере ниже мы задаём несколько эффектов переходов.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation для открытия файла презентации.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Применить Cut‑переход и включить From Black.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # Сохранить презентацию на диск.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Могу ли я контролировать скорость воспроизведения перехода слайда?**

Да. Установите [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) перехода, используя настройку [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) (например, slow/medium/fast).

**Могу ли я прикрепить аудио к переходу и сделать его зацикленным?**

Да. Вы можете встраивать звук для перехода и управлять поведением через настройки, такие как режим звука и зацикливание (например, [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/), а также метаданные, такие как [sound_is_built_in](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) и [sound_name](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**Какой самый быстрый способ применить один и тот же переход ко всем слайдам?**

Настройте нужный тип перехода в настройках перехода каждого слайда; переходы хранятся по отдельности для каждого слайда, поэтому применение одного и того же типа ко всем слайдам обеспечит единый результат.

**Как я могу проверить, какой переход сейчас установлен на слайде?**

Просмотрите [transition settings](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) слайда и прочитайте его [transition type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/); это значение точно указывает, какой эффект применён.