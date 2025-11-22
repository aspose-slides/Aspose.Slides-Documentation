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
- расширенный переход слайда
- переход Morph
- тип перехода
- эффект перехода
- Python
- Aspose.Slides
description: "Узнайте, как настраивать переходы слайдов в Aspose.Slides для Python через .NET с пошаговым руководством для презентаций PowerPoint и OpenDocument."
---

## **Обзор**

Aspose.Slides for Python предоставляет полный контроль над переходами слайдов: от выбора типа перехода до настройки тайминга и триггеров в рамках автоматизированных рабочих процессов презентаций. Вы можете задать переходы слайдов по щелчку и/или после указанной задержки, а также уточнить визуальное поведение с помощью эффектов, таких как вырезы из черного или направленные входы. Библиотека также поддерживает переход Morph, введенный в PowerPoint 2019, включая режимы морфа по объекту, слову или символу для создания плавного, согласованного движения между слайдами.

## **Добавить переходы слайдов**

Чтобы было проще понять, в этом примере показано, как использовать Aspose.Slides for Python для управления простыми переходами слайдов. Разработчики могут применять различные эффекты переходов к слайдам и настраивать их поведение. Чтобы создать простой переход слайда, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Примените переход слайда, используя один из эффектов из перечисления [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/).
1. Сохраните изменённый файл презентации.
```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation для загрузки файла презентации.
with slides.Presentation("sample.pptx") as presentation:
    # Примените круговой переход к слайду 1.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Примените переход comb к слайду 2.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Сохраните презентацию на диск.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Добавить расширенные переходы слайдов**

В этом разделе мы применили простой эффект перехода к слайду. Чтобы сделать этот эффект более управляемым и отполированным, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Примените переход слайда, используя один из эффектов из перечисления [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/).
1. Настройте переход для **Advance On Click**, после определённого периода времени, или оба варианта.
1. Сохраните изменённый файл презентации.

Если включён **Advance On Click**, слайд переходит только при щелчке пользователя. Если задано свойство **Advance After Time**, слайд переходит автоматически после указанного интервала.
```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation для открытия файла презентации.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # Примените круговой переход к слайду 1.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Включите переход по щелчку и задайте автоматический переход через 3 секунды.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # Примените переход comb к слайду 2.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Включите переход по щелчку и задайте автоматический переход через 5 секунд.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # Примените переход zoom к слайду 3.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Включите переход по щелчку и задайте автоматический переход через 7 секунд.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # Сохраните презентацию на диск.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Переход Morph**

Aspose.Slides for Python поддерживает [Morph transition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/), который анимирует плавное перемещение от одного слайда к другому. В этом разделе объясняется, как использовать переход Morph. Чтобы использовать его эффективно, вам нужны два слайда с хотя бы одним общим объектом. Самый простой способ — дублировать слайд, а затем переместить объект в другое положение на втором слайде.

В следующем фрагменте кода показано, как клонировать слайд, содержащий текст, и применить к второму слайду переход Morph.
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Клонируйте первый слайд, чтобы создать второй с теми же фигурами для непрерывного Morph.
    slide1 = presentation.slides.add_clone(slide0)

    # Выберите тот же прямоугольник на втором слайде и измените его положение и размер.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # Включите переход Morph на втором слайде, чтобы плавно анимировать изменения фигур.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Типы перехода Morph**

Перечисление [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) представляет разные типы переходов Morph.

В следующем фрагменте кода показано, как применить переход Morph к слайду и изменить тип морфа:
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Установить эффекты перехода**

Aspose.Slides for Python позволяет задавать эффекты перехода, такие как **From Black**, **From Left**, **From Right** и т.д. Чтобы настроить эффект перехода, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд.
1. Установите требуемый эффект перехода.
1. Сохраните презентацию в формате PPTX.

В примере ниже мы задаём несколько эффектов перехода.
```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation для открытия файла презентации.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Примените переход Cut и включите From Black.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # Сохраните презентацию на диск.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Могу ли я контролировать скорость воспроизведения перехода слайда?**

Да. Установите [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) перехода с помощью настройки [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) (например, slow/medium/fast).

**Можно ли прикрепить аудио к переходу и сделать его зацикленным?**

Да. Вы можете встроить звук для перехода и управлять его поведением через настройки, такие как звук, режим звука и зацикливание (например, [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/), а также метаданные, такие как [sound_is_built_in](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) и [sound_name](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**Какой самый быстрый способ применить один и тот же переход ко всем слайдам?**

Настройте желаемый тип перехода в параметрах перехода каждого слайда; переходы хранятся индивидуально для каждого слайда, поэтому применение одного и того же типа ко всем слайдам даст одинаковый результат.

**Как проверить, какой переход в данный момент установлен на слайде?**

Исследуйте [transition settings](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) слайда и прочитайте его [transition type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/); это значение точно скажет, какой эффект применён.