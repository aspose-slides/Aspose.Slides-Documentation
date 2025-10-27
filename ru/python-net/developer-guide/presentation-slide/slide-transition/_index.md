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
- морф‑переход
- тип перехода
- эффект перехода
- Python
- Aspose.Slides
description: "Узнайте, как настраивать переходы слайдов в Aspose.Slides for Python via .NET, с пошаговым руководством для презентаций PowerPoint и OpenDocument."
---

## **Обзор**

Aspose.Slides for Python предоставляет полный контроль над переходами слайдов: от выбора типа перехода до настройки времени и триггеров в рамках автоматизированных рабочих процессов с презентациями. Вы можете задавать автоматический переход по клику и/или после указанной задержки, а также уточнять визуальное поведение с помощью эффектов, таких как вырезка из чёрного или входы с направления. Библиотека также поддерживает морф‑переход, введённый в PowerPoint 2019, включая режимы морфа по объекту, слову или символу для создания плавного, согласованного движения между слайдами.

## **Добавление переходов слайдов**

Чтобы было проще понять, в этом примере показано, как использовать Aspose.Slides for Python для управления простыми переходами слайдов. Разработчики могут применять различные эффекты переходов к слайдам и настраивать их поведение. Чтобы создать простой переход слайда, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Примените переход слайда, используя один из эффектов перечисления [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/).
1. Сохраните изменённый файл презентации.

```py
import aspose.slides as slides

# Создаём объект Presentation для загрузки файла презентации.
with slides.Presentation("sample.pptx") as presentation:
    # Применяем переход «круг» к слайду 1.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Применяем переход «гребень» к слайду 2.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Сохраняем презентацию на диск.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавление расширенных переходов слайдов**

В предыдущем разделе мы применили простой эффект перехода к слайду. Чтобы сделать эффект более управляемым и отточенным, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Примените переход слайда, используя один из эффектов перечисления [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/).
1. Настройте переход: автоматический переход по клику, после заданного времени или оба варианта.
1. Сохраните изменённый файл презентации.

Если включена опция **Advance On Click**, слайд переключается только после щелчка пользователя. Если задано свойство **Advance After Time**, слайд переходит автоматически после указанного интервала.

```py
import aspose.slides as slides

# Открываем файл презентации.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # Применяем переход «круг» к слайду 1.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Включаем автоматический переход по щелчку и задаём автопереход через 3 сек.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # Применяем переход «гребень» к слайду 2.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Включаем автоматический переход по щелчку и задаём автопереход через 5 сек.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # Применяем переход «зум» к слайду 3.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Включаем автоматический переход по щелчку и задаём автопереход через 7 сек.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # Сохраняем презентацию.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph‑переход**

Aspose.Slides for Python поддерживает [Morph‑переход](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/), который анимирует плавное перемещение от одного слайда к следующему. В этом разделе объясняется, как использовать Morph‑переход. Чтобы он работал корректно, нужны два слайда с хотя бы одним общим объектом. Самый простой способ – продублировать слайд, а затем переместить объект в другое положение на втором слайде.

Ниже приведён пример, показывающий, как клонировать слайд, содержащий текст, и применить к второму слайду Morph‑переход.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Клонируем первый слайд, чтобы создать второй с теми же фигурами для плавного морфа.
    slide1 = presentation.slides.add_clone(slide0)

    # Выбираем тот же прямоугольник на втором слайде и меняем его позицию и размер.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # Включаем Morph‑переход на втором слайде для плавной анимации изменений формы.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Типы Morph‑переходов**

Перечисление [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) описывает различные типы Morph‑переходов для слайдов.

Ниже показан пример, как применить Morph‑переход к слайду и изменить тип морфа:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка эффектов перехода**

Aspose.Slides for Python позволяет задавать эффекты перехода, такие как **From Black**, **From Left**, **From Right** и др. Чтобы настроить эффект перехода, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылки на нужный слайд.
1. Установите требуемый эффект перехода.
1. Сохраните презентацию в формате PPTX.

В примере ниже задаются несколько эффектов перехода.

```py
import aspose.slides as slides

# Открываем файл презентации.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Применяем переход «резка» и включаем эффект «From Black».
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # Сохраняем презентацию.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Можно ли управлять скоростью воспроизведения перехода слайда?**

Да. Задайте [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) перехода с помощью параметра [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) (например, slow/medium/fast).

**Можно ли прикрепить звук к переходу и зациклить его?**

Да. Вы можете встроить звук в переход и управлять поведением через параметры, такие как режим звука и зацикливание (например, [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/), а также метаданные [sound_is_built_in](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) и [sound_name](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**Какой самый быстрый способ применить один и тот же переход ко всем слайдам?**

Настройте желаемый тип перехода в параметрах перехода каждого слайда; переходы хранятся отдельно для каждого слайда, поэтому одинаковый тип, установленный на всех слайдах, даст единообразный результат.

**Как проверить, какой переход сейчас установлен на слайде?**

Изучите [transition settings](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) слайда и прочитайте его [transition type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/); это значение точно покажет, какой эффект применяется.