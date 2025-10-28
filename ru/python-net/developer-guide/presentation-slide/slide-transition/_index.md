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
- morph переход
- тип перехода
- эффект перехода
- Python
- Aspose.Slides
description: "Узнайте, как настраивать переходы слайдов в Aspose.Slides для Python через .NET, с пошаговым руководством для презентаций PowerPoint и OpenDocument."
---

## **Обзор**

Aspose.Slides для Python предоставляет полный контроль над переходами слайдов, от выбора типа перехода до настройки тайминга и триггеров в рамках автоматизированных рабочих процессов с презентациями. Вы можете задать переходы слайдов по щелчку и/или после указанной задержки и уточнить визуальное поведение с помощью эффектов, таких как вырезы из черного или входы с разных сторон. Библиотека также поддерживает Morph‑переход, появившийся в PowerPoint 2019, включая режимы морфа по объекту, слову или символу для создания плавного согласованного движения между слайдами.

## **Добавление переходов слайдов**

Чтобы было проще понять, этот пример демонстрирует, как использовать Aspose.Slides для Python для управления простыми переходами слайдов. Разработчики могут применять различные эффекты переходов к слайдам и настраивать их поведение. Чтобы создать простой переход слайда, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Примените переход слайда, используя один из эффектов перечисления [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/).
3. Сохраните изменённый файл презентации.

```py
import aspose.slides as slides

# Создаём объект Presentation для загрузки файла презентации.
with slides.Presentation("sample.pptx") as presentation:
    # Применяем круговой переход к слайду 1.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Применяем гребенчатый переход к слайду 2.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Сохраняем презентацию на диск.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавление продвинутых переходов слайдов**

В этом разделе мы применили простой эффект перехода к слайду. Чтобы сделать эффект более управляемым и полированным, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Примените переход слайда, используя один из эффектов перечисления [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/).
3. Настройте переход: «Advance On Click», «Advance After Time» или оба параметра.
4. Сохраните изменённый файл презентации.

Если включён параметр **Advance On Click**, слайд переходит только после щелчка пользователя. Если задано свойство **Advance After Time**, слайд переходит автоматически по истечении указанного интервала.

```py
import aspose.slides as slides

# Создаём объект Presentation для открытия файла презентации.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # Применяем круговой переход к слайду 1.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Включаем переход по щелчку и задаём автоматический переход через 3 секунды.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # Применяем гребенчатый переход к слайду 2.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Включаем переход по щелчку и задаём автоматический переход через 5 секунд.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # Применяем масштабный переход к слайду 3.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Включаем переход по щелчку и задаём автоматический переход через 7 секунд.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # Сохраняем презентацию на диск.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph‑переход**

Aspose.Slides для Python поддерживает [Morph‑переход](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/), который анимирует плавное перемещение от одного слайда к другому. В этом разделе объясняется, как использовать Morph‑переход. Для эффективного применения вам потребуются два слайда с хотя бы одним общим объектом. Самый простой способ — продублировать слайд, а затем переместить объект в другое положение на втором слайде.

Ниже показан фрагмент кода, демонстрирующий клонирование слайда, содержащего текст, и применение Morph‑перехода ко второму слайду.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Клонируем первый слайд, чтобы создать второй слайд с теми же фигурами для непрерывного Morph.
    slide1 = presentation.slides.add_clone(slide0)

    # Выбираем тот же прямоугольник на втором слайде и меняем его позицию и размер.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # Включаем Morph‑переход на втором слайде для плавной анимации изменений фигуры.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Типы Morph‑переходов**

Перечисление [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) представляет различные типы Morph‑переходов слайдов.

Ниже показан фрагмент кода, демонстрирующий применение Morph‑перехода к слайду и изменение типа морфа:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка эффектов перехода**

Aspose.Slides для Python позволяет задавать эффекты перехода, такие как **From Black**, **From Left**, **From Right** и т.д. Чтобы сконфигурировать эффект перехода, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд.
3. Установите желаемый эффект перехода.
4. Сохраните презентацию в файле PPTX.

В примере ниже мы задаём несколько эффектов перехода.

```py
import aspose.slides as slides

# Создаём объект Presentation для открытия файла презентации.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Применяем переход Cut и включаем эффект From Black.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # Сохраняем презентацию на диск.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Можно ли управлять скоростью воспроизведения перехода слайда?**

Да. Установите [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) перехода с помощью настройки [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) (например, slow/medium/fast).

**Можно ли прикрепить к переходу звук и настроить его зацикливание?**

Да. Вы можете встроить звук для перехода и управлять поведением через параметры, такие как режим звука и зацикливание (например, [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/), а также метаданные, такие как [sound_is_built_in](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) и [sound_name](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**Какой самый быстрый способ применить один и тот же переход ко всем слайдам?**

Настройте желаемый тип перехода в параметрах перехода каждого слайда; переходы хранятся отдельно для каждого слайда, поэтому применение одного и того же типа ко всем слайдам даст одинаковый результат.

**Как проверить, какой переход установлен в данный момент на слайде?**

Изучите [параметры перехода](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) конкретного слайда и прочитайте его [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/); это значение точно укажет, какой эффект применён.