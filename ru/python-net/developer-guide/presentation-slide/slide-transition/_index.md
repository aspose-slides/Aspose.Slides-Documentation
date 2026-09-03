---
title: Управление переходами слайдов в презентациях с использованием Python
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
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Применяйте переходы слайдов, настраивайте автоматическое переключение слайдов и настраивайте переход Morph и другие эффекты переходов с помощью Aspose.Slides for Python via .NET."
---
## **Обзор**

Переходы слайдов определяют, как слайды появляются во время показа слайдов. С помощью Aspose.Slides for Python via .NET вы можете выбирать эффект перехода для каждого слайда, настраивать переход по щелчку мыши или таймеру и изменять параметры, специфичные для эффекта. В этой статье используются примеры на Python для применения переходов, установки точных длительностей переходов, управления временем отображения слайда и создания перехода Morph между двумя слайдами. Примеры также показывают, как сохранять настройки в файл PPTX.

## **Добавить переход слайда**

Чтобы применить переход, загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) и получите доступ к свойству [slide_show_transition](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/slide_show_transition/) слайда. Установите его [type](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/type/) в значение из перечисления [TransitionType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/transitiontype/), затем сохраните презентацию.

В следующем примере к первому слайду применяется переход Circle, а ко второму — переход Comb. Используйте файл `input.pptx` с как минимум двумя слайдами.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE
        presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

        presentation.save("slide-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

## **Добавить расширенный переход слайда**

Вы можете настроить, как долго слайд остаётся на экране и будет ли щелчок мыши переключать показ слайдов. Следующие свойства управляют этим поведением:

- [advance_on_click](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) позволяет зрителю переходить по щелчку мыши.
- [advance_after](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) включаёт автоматический переход.
- [advance_after_time](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) задаёт задержку перед автоматическим переходом, в миллисекундах.

Включите как щелчок, так и таймер, чтобы зритель мог перейти по щелчку или ждать таймера. Чтобы использовать только таймер, установите [advance_on_click](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) в `False`. Задержка определяет, когда показывается следующий слайд; она не задаёт длительность визуального эффекта перехода.

В этом примере первым трём слайдам назначаются разные эффекты, а автоматический переход включается через 3, 5 и 7 секунд соответственно. Щелчки мыши также могут переключать эти слайды. Используйте файл `input.pptx` с как минимум тремя слайдами.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 3:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.CIRCLE
        first_transition.advance_on_click = True
        first_transition.advance_after = True
        first_transition.advance_after_time = 3000

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.COMB
        second_transition.advance_on_click = True
        second_transition.advance_after = True
        second_transition.advance_after_time = 5000

        third_transition = presentation.slides[2].slide_show_transition
        third_transition.type = slides.slideshow.TransitionType.ZOOM
        third_transition.advance_on_click = True
        third_transition.advance_after = True
        third_transition.advance_after_time = 7000

        presentation.save("advanced-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least three slides.")
```

Чтобы проверить, включён ли таймер автоматического перехода, прочитайте [advance_after](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). Хранё­тая задержка сама по себе не указывает, активен ли таймер.

Следующий пример открывает файл, сохранённый выше, сообщает о каждом включённом таймере и отключает автоматический переход для слайдов с задержкой более двух секунд. Для этих слайдов включается переход по щелчку, после чего обновлённые настройки сохраняются.

```python
import aspose.slides as slides

with slides.Presentation("advanced-transitions.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition

        if transition.advance_after:
            print(f"Slide {slide.slide_number}: advance after {transition.advance_after_time} ms.")

            if transition.advance_after_time > 2000:
                transition.advance_after = False
                transition.advance_on_click = True

    presentation.save("adjusted-transitions.pptx", slides.export.SaveFormat.PPTX)
```

## **Точно контролировать время перехода**

Используйте [duration](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/duration/) для указания точной длительности эффекта перехода в миллисекундах. Свойство [slide_show_transition](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/slide_show_transition/) слайда раскрывает эти параметры через [SlideShowTransition](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/):

| Свойство | Назначение |
| --- | --- |
| [duration](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Устанавливает длительность самого эффекта перехода в миллисекундах. |
| [advance_after_time](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Устанавливает задержку перед автоматическим переходом слайда, в миллисекундах. Включите [advance_after](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) чтобы активировать этот таймер. |
| [speed](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Выбирает предопределённую категорию скорости из [TransitionSpeed](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM или FAST. Используется, когда точная длительность не указана. |

[duration](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/duration/) контролирует только эффект перехода; она не определяет, как долго слайд остаётся видимым. Настройте задержку автоматического перехода отдельно. Если явная длительность не задана, Aspose.Slides определяет её исходя из типа перехода и значения [speed](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/speed/).

### **Применить одинаковую длительность ко всем слайдам**

Для согласованного темпа примените один и тот же эффект и точную длительность к каждому слайду. Этот пример загружает `input.pptx`, выбирает Fade из [TransitionType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/transitiontype/) и задаёт каждой смене длительность 750 мс. Отдельно включается автоматический переход через 5 000 мс и отключается переход по щелчку мыши, после чего результат сохраняется как PPTX.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Настройте автоматическое продвижение независимо от длительности эффекта.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Установить разные длительности для отдельных слайдов**

Разные слайды могут использовать разные длительности эффектов. Например, можно задать короткий переход для титульного слайда и более длительный для вводного раздела. Этот пример задаёт 500 мс для первого слайда и 1 200 мс для второго. Используйте файл `input.pptx` с как минимум двумя слайдами.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.FADE
        first_transition.duration = 500

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.PUSH
        second_transition.duration = 1200

        presentation.save("individual-transition-durations.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

### **Координировать переходы с анимированным выводом**

При подготовке [animated GIF](/slides/ru/python-net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/ru/python-net/export-to-html5/) или [video](/slides/ru/python-net/convert-powerpoint-to-video/) задавайте точные длительности переходов до экспорта, чтобы они соответствовали нужному темпу. Например, используйте 600‑миллисекундный fade между сценами и отдельно корректируйте задержку перехода каждого слайда, чтобы было время для озвучивания или контента.

Для GIF и видео согласуйте частоту кадров вывода с длительностью эффекта: 600 мс соответствует 18 кадрам при 30 кадрах в секунду. В HTML5 включите анимированные переходы в настройках экспорта. Проверьте поддерживаемые эффекты и параметры тайминга выбранного формата и предварительно просмотрите вывод для подтверждения синхронизации.

### **Прочитать существующую длительность перехода**

Прочитайте [duration](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/duration/) перед изменением перехода, чтобы определить, сохранено ли явное значение. Значение `-1` означает, что явная длительность не установлена; неотрицательное значение указывает сохранённую длительность в миллисекундах. Неустановленное значение не является вычисленной длительностью воспроизведения: Aspose.Slides использует тип перехода и [speed](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/speed/) для её определения. Установка типа перехода может инициализировать длительность, поэтому сначала проверьте исходные настройки.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        duration = transition.duration

        if duration >= 0:
            print(f"Slide {slide.slide_number}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.slide_number}: no explicit duration; timing depends on {transition.type} and {transition.speed}.")
```

## **Переход Morph**

Переход Morph анимирует изменения между объектами на соседних слайдах. Чтобы создать простой эффект Morph, клонируйте слайд, переместите или измените размер объекта на клоне и примените переход Morph ко второму слайду. Это даёт анимацию соответствующих объектов между их исходным и изменённым состояниями.

В следующем примере создаётся слайд с текстовым прямоугольником, клонируется, и на клоне изменяются позиция и размер прямоугольника. Затем для второго слайда выбирается Morph из перечисления [TransitionType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/transitiontype/). Откройте сохранённый файл в программе просмотра презентаций, поддерживающей Morph, чтобы увидеть эффект во время показа.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    rectangle = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    rectangle.text_frame.text = "Morph transition"

    second_slide = presentation.slides.add_clone(first_slide)
    moved_rectangle = second_slide.shapes[0]
    moved_rectangle.x += 100
    moved_rectangle.y += 50
    moved_rectangle.width -= 200
    moved_rectangle.height -= 10

    second_slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("morph-transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Типы перехода Morph**

Перечисление [TransitionMorphType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/transitionmorphtype/) определяет, как Morph сопоставляет и анимирует содержимое:

- [BY_OBJECT](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/transitionmorphtype/) рассматривает каждую форму как целый объект.
- [BY_WORD](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/transitionmorphtype/) анимирует текст, сопоставляя слова там, где это возможно.
- [BY_CHAR](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/transitionmorphtype/) анимирует текст, сопоставляя символы там, где это возможно.

Установите переход [type](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/type/) в Morph перед доступом к его [value](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/value/). Затем свойство [morph_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/morphtransition/morph_type/) объекта [MorphTransition](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/morphtransition/) выбирает режим сопоставления.

В этом примере открывается презентация, созданная в предыдущем разделе, и настраивается второй слайд для анимации Morph по словам.

```python
import aspose.slides as slides

with slides.Presentation("morph-transition.pptx") as presentation:
    if len(presentation.slides) >= 2:
        transition = presentation.slides[1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.MORPH
        morph_transition = transition.value

        if isinstance(morph_transition, slides.slideshow.MorphTransition):
            morph_transition.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
            presentation.save("morph-by-word.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
```

## **Установить эффекты перехода**

Некоторые переходы раскрывают дополнительные параметры, такие как направление или начало эффекта с чёрного экрана. Доступные параметры зависят от выбранного перехода [type](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/type/). Сначала задайте тип, затем используйте соответствующий объект перехода из его [value](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/value/).

В следующем примере применяется переход Cut к первому слайду `input.pptx`. Через [OptionalBlackTransition](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/optionalblacktransition/) устанавливается [from_black](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/), чтобы переход начинался с чёрного экрана.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    transition = presentation.slides[0].slide_show_transition
    transition.type = slides.slideshow.TransitionType.CUT
    cut_transition = transition.value

    if isinstance(cut_transition, slides.slideshow.OptionalBlackTransition):
        cut_transition.from_black = True
        presentation.save("cut-from-black.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Cut transition options are unavailable.")
```

## **FAQ**

**Могу ли я контролировать скорость воспроизведения перехода слайда?**

Да. Предпочтительно используйте [duration](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/duration/), когда нужна точная длительность эффекта в миллисекундах. Используйте [speed](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/speed/), когда достаточно предопределённой категории [TransitionSpeed](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/transitionspeed/) — SLOW, MEDIUM или FAST, и явная длительность не задаётся. Эти настройки управляют эффектом перехода независимо от задержки автоматического перехода.

**Могу ли я привязать аудио к переходу и заставить его зацикливаться?**

Да. Назначьте встроенное аудио свойству [sound](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/sound/), установите [sound_mode](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) в START_SOUND из перечисления [TransitionSoundMode](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/transitionsoundmode/) и включите [sound_loop](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). Аудио будет повторяться до следующего звукового события в показе слайдов.

**Какой самый быстрый способ применить один и тот же переход ко всем слайдам?**

Пройдитесь по коллекции [slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/slides/ru/) презентации и для каждого слайда задайте переходу [type](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/type/) одинаковое значение. В том же цикле задайте любые параметры тайминга и эффекта, чтобы поведение было одинаковым на всех слайдах.

**Как проверить, какой переход установлен на слайде?**

Прочитайте свойство [type](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/slideshowtransition/type/) у свойства [slide_show_transition](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/slide_show_transition/) слайда. Оно возвращает значение из перечисления [TransitionType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.slideshow/transitiontype/); NONE означает, что переход не применён.