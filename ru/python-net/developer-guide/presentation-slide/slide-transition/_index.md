---
title: Управление переходами слайдов в презентациях с помощью Python
linktitle: Переход слайда
type: docs
weight: 90
url: /ru/python-net/slide-transition/
keywords:
- переход слайда
- добавление перехода слайда
- применение перехода слайда
- расширенный переход слайда
- морф переход
- тип перехода
- эффект перехода
- Python
- Aspose.Slides
description: "Узнайте, как настроить переходы слайдов в Aspose.Slides для Python через .NET, с пошаговым руководством для презентаций PowerPoint и OpenDocument."
---

## **Обзор**

Aspose.Slides for Python предоставляет полный контроль над переходами слайдов, от выбора типа перехода до настройки времени и триггеров в рамках автоматизированных рабочих процессов презентаций. Вы можете установить переходы слайдов по щелчку и/или после заданной задержки, а также уточнить визуальное поведение с помощью эффектов, таких как затемнение из черного или входы из разных направлений. Библиотека также поддерживает переход Morph, введенный в PowerPoint 2019, включая режимы морфа по объекту, слову или символу для создания плавного, согласованного движения между слайдами.

## **Добавление переходов слайдов**

Чтобы упростить понимание, в этом примере показано, как использовать Aspose.Slides for Python для управления простыми переходами слайдов. Разработчики могут применять различные эффекты переходов к слайдам и настраивать их поведение. Чтобы создать простой переход слайда, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Примените переход к слайду, используя один из эффектов из перечисления [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/).
1. Сохраните изменённый файл презентации.
```py
import aspose.slides as slides

# Создайте объект класса Presentation для загрузки файла презентации.
with slides.Presentation("sample.pptx") as presentation:
    # Примените переход «круг» к слайду 1.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Примените переход «гребень» к слайду 2.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Сохраните презентацию на диск.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Добавление продвинутых переходов слайдов**

В этом разделе мы применили простой эффект перехода к слайду. Чтобы сделать этот эффект более управляемым и полированным, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Примените переход к слайду, используя один из эффектов из перечисления [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/).
1. Настройте переход для перехода по щелчку, после определённого промежутка времени или обоих вариантов.
1. Сохраните изменённый файл презентации.

Если включена опция **Advance On Click**, слайд будет переключаться только при щелчке пользователя. Если установлен параметр **Advance After Time**, слайд переключится автоматически после указанного интервала.
```py
import aspose.slides as slides

# Создайте объект класса Presentation для открытия файла презентации.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # Примените переход «круг» к слайду 1.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Включите переход по щелчку и установите автоматический переход через 3 секунды.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # Примените переход «гребень» к слайду 2.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Включите переход по щелчку и установите автоматический переход через 5 секунд.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # Примените переход зум к слайду 3.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Включите переход по щелчку и установите автоматический переход через 7 секунд.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # Сохраните презентацию на диск.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Переход Morph**

Aspose.Slides for Python поддерживает [Morph transition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/), который анимирует плавное перемещение от одного слайда к другому. В этом разделе объясняется, как использовать переход Morph. Для эффективного использования вам нужны два слайда с хотя бы одним общим объектом. Самый простой подход — дублировать слайд, а затем переместить объект в другое положение на втором слайде.

Ниже приведён фрагмент кода, показывающий, как клонировать слайд, содержащий текст, и применить к второму слайду переход Morph.
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Клонировать первый слайд, чтобы создать второй слайд с теми же фигурами для непрерывности Morph.
    slide1 = presentation.slides.add_clone(slide0)

    # Выбрать тот же прямоугольник на втором слайде и изменить его положение и размер.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # Включить переход Morph на втором слайде, чтобы плавно анимировать изменения фигур.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Типы переходов Morph**

Перечисление [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) представляет разные типы переходов Morph.

Ниже приведён фрагмент кода, показывающий, как применить переход Morph к слайду и изменить тип морфа:
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Установка эффектов переходов**

Aspose.Slides for Python позволяет задавать эффекты переходов, такие как **From Black**, **From Left**, **From Right** и др. Чтобы настроить эффект перехода, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд.
1. Установите желаемый эффект перехода.
1. Сохраните презентацию в файл PPTX.

В примере ниже мы задаём несколько эффектов переходов.
```py
import aspose.slides as slides

# Создайте объект класса Presentation для открытия файла презентации.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Примените переход Cut и включите From Black.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # Сохраните презентацию на диск.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Можно ли управлять скоростью воспроизведения перехода слайда?**

Да. Установите [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) перехода, используя настройку [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) (например, slow/medium/fast).

**Можно ли прикрепить аудио к переходу и заставить его зацикливаться?**

Да. Вы можете внедрить звук для перехода и контролировать его поведение через параметры, такие как режим звука и зацикливание (например, [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/), а также метаданные, такие как [sound_is_built_in](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) и [sound_name](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**Какой самый быстрый способ применить один и тот же переход ко всем слайдам?**

Настройте желаемый тип перехода в параметрах перехода каждого слайда; переходы хранятся отдельно для каждого слайда, поэтому применение одного и того же типа ко всем слайдам даст единообразный результат.

**Как проверить, какой переход сейчас установлен на слайде?**

Изучите [transition settings](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) слайда и прочитайте его [transition type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/); это значение точно указывает, какой эффект применён.