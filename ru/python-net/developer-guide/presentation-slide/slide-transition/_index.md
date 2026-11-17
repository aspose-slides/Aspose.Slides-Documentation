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
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Применяйте переходы слайдов, настраивайте автоматическое переключение слайдов и кастомизируйте переход Morph и другие эффекты перехода с помощью Aspose.Slides для Python через .NET."
---
## **Обзор**

Переходы слайдов определяют, как слайды появляются во время показа. С помощью Aspose.Slides for Python via .NET можно выбрать эффект перехода для каждого слайда, настроить переход по щелчку мыши или таймеру и задать параметры, специфичные для эффекта. В этой статье приведены примеры на Python, показывающие, как применять переходы, задавать точную длительность перехода, управлять временем показа слайда и создавать переход Morph между двумя слайдами. Примеры также демонстрируют, как сохранять настройки в файл PPTX.

## **Добавление перехода слайда**

Чтобы применить переход, загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и обратитесь к свойству слайда [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/). Установите его [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) в значение из перечисления [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/), затем сохраните презентацию.

В следующем примере к первому слайду применяется переход Circle, а ко второму — Comb. Используйте файл `input.pptx` с минимум двумя слайдами.

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

## **Переход Wheel**

Свойство [spokes](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/spokes/) класса [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) управляет числом радиальных секторов, через которые раскрывается целевой слайд. Установите [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) слайда в WHEEL из [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) перед доступом к [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) как к [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/).

В примере создаются две одинаковые пары слайдов: черный слайд, за которым следует слайд с золотым прямоугольником. В целевых слайдах используется количество спиц 1 и 8, одинаковая [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) и явная [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) = 8 000 мс, чтобы разницу было легко заметить.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    black_slide = presentation.slides[0]
    black_slide.shapes.clear()
    black_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    black_slide.background.fill_format.fill_type = slides.FillType.SOLID
    black_slide.background.fill_format.solid_fill_color.preset_color = slides.PresetColor.BLACK

    destination_slide = presentation.slides.add_clone(black_slide)
    rectangle = destination_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, slide_width, slide_height)
    rectangle.fill_format.fill_type = slides.FillType.SOLID
    rectangle.fill_format.solid_fill_color.preset_color = slides.PresetColor.GOLD
    rectangle.text_frame.text = "Wheel transition"

    presentation.slides.add_clone(black_slide)
    presentation.slides.add_clone(destination_slide)

    spoke_counts = [1, 8]
    for i, spoke_count in enumerate(spoke_counts):
        transition = presentation.slides[i * 2 + 1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.WHEEL
        wheel_transition = transition.value
        wheel_transition.spokes = spoke_count
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 8000

    presentation.save("wheel-transitions.pptx", slides.export.SaveFormat.PPTX)
```

Откройте получившуюся презентацию в PowerPoint и запустите показ слайдов. Перейдите со слайда 1 на слайд 2, затем со слайда 3 на слайд 4. При воспроизведении в PowerPoint проверенное количество спиц = 1 раскрывает слайд одним вращающимся движением; проверенное количество = 8 — через восемь радиальных секторов одновременно. Содержимое целевых слайдов и время перехода одинаковы, различие только в числе секторов раскрытия.

## **Добавление расширенного перехода слайда**

Можно настроить, как долго слайд остаётся на экране и будет ли щелчок мышью переключать показ. Следующие свойства управляют этим поведением:

- [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) позволяет зрителю переключать слайд щелчком мыши.  
- [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) включает автоматическое переключение.  
- [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) задаёт задержку перед автоматическим переключением в миллисекундах.

Включите оба режима — по щелчку и по таймеру, чтобы зритель мог перейти по щелчку или ждать таймер. Чтобы использовать только таймер, установите [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) в `False`. Задержка определяет, когда будет переключён слайд; она не задаёт длительность визуального эффекта перехода.

В примере различным слайдам присваиваются разные эффекты, а автоматическое переключение включается через 3, 5 и 7 секунд соответственно. По щелчку мыши эти слайды также могут переключаться. Используйте файл `input.pptx` с минимум тремя слайдами.

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

Чтобы проверить, включено ли автоматическое переключение, прочитайте [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). Хранённая задержка сама по себе не означает, что таймер активен.

Следующий пример открывает файл, сохранённый выше, выводит информацию о каждом включённом таймере и отключает автоматическое переключение у слайдов с задержкой более двух секунд. Для этих слайдов включаются щелчки мышью, после чего сохраняются обновлённые настройки.

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

## **Точное управление временем перехода**

Используйте [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) для указания точной длины эффекта перехода в миллисекундах. Свойство слайда [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) раскрывает эти настройки через объект [SlideShowTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/):

| Property | Purpose |
| --- | --- |
| [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Задает длительность самого эффекта перехода в миллисекундах. |
| [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Задает задержку перед автоматическим переходом к следующему слайду в миллисекундах. Включите [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) для активации таймера. |
| [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Выбирает предопределённую категорию скорости из [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM или FAST. Используется, когда точная длительность не указана. |

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) управляет только эффектом перехода; она не определяет, как долго слайд остаётся видимым. Задержку автопереключения настраивают отдельно. Если явная длительность не задана, Aspose.Slides определяет её исходя из типа перехода и значения [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/).

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Пример задаёт каждому слайду 750‑мс переход Fade и отдельно включает автоматическое переключение через 5 000 мс. Длительность перехода управляет эффектом; автопереключение — моментом выхода со слайда. Эти полосы являются схематичными настройками, а не измеренной совместной временной шкалой.*
<!-- visual-explanation:slide-transition:end -->

### **Применить одинаковую длительность ко всем слайдам**

Для единообразного темпа примените один и тот же эффект и точную длительность ко всем слайдам. В примере загружается `input.pptx`, выбирается Fade из [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/), каждому переходу задаётся длительность 750 мс, отдельно включается автопереключение через 5 000 мс, отключается переключение по щелчку, после чего результат сохраняется в PPTX.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Настройте автоматическое переключение независимо от длительности эффекта.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Установка разных длительностей для отдельных слайдов**

Разные слайды могут иметь разные длительности эффектов. Например, короткий переход для титульного слайда и более длительный — для вводного раздела. В примере задаются 500 мс для первого слайда и 1 200 мс для второго. Используйте файл `input.pptx` с минимум двумя слайдами.

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

### **Согласование переходов с анимированным выводом**

При подготовке [animated GIF](/slides/ru/python-net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/ru/python-net/export-to-html5/) или [video](/slides/ru/python-net/convert-powerpoint-to-video/) задайте точные длительности переходов до экспорта, чтобы обеспечить требуемый ритм. Например, используйте 600‑мс затухание между сценами и отдельно настройте задержку автопереключения каждого слайда, чтобы было время для озвучивания или контента.

Для GIF и видео согласуйте частоту кадров с длительностью эффекта: 600 мс ≈ 18 кадров при 30 fps. В HTML5 включите анимированные переходы в настройках экспорта. Проверьте поддерживаемые эффекты и параметры времени выбранного формата и предварительно просмотрите итог для подтверждения синхронизации.

### **Чтение существующей длительности перехода**

Прочитайте [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) перед изменением перехода, чтобы определить, хранится ли явное значение. Значение `-1` означает, что длительность явно не задана; неотрицательное значение указывает сохранённую длительность в миллисекундах. Неустановленное значение — это не рассчитанная длительность воспроизведения: Aspose.Slides использует тип перехода и [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) для её определения. Установка типа перехода может инициализировать длительность, поэтому сначала проверьте оригинальные настройки.

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

Переход Morph анимирует изменения объектов между последовательными слайдами. Чтобы создать простой эффект Morph, склонируйте слайд, переместите или измените размер объекта в копии и примените переход Morph к второму слайду. Это даёт объектам возможность анимировать переход от исходного к изменённому состоянию.

В следующем примере создаётся слайд с текстовым прямоугольником, клонируется, а в копии изменяются позиция и размер прямоугольника. Затем для второго слайда выбирается Morph из перечисления [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/). Откройте сохранённый файл в просмотрщике, поддерживающем Morph, чтобы увидеть эффект во время показа.

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

Перечисление [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) определяет, как Morph сопоставляет и анимирует содержимое:

- [BY_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) рассматривает каждую форму как отдельный объект.  
- [BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) анимирует текст, сопоставляя слова, где это возможно.  
- [BY_CHAR](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) анимирует текст, сопоставляя отдельные символы.

Установите [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) перехода в Morph перед доступом к его [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/). Затем объект [MorphTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/) предоставит свойство [morph_type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/morph_type/), позволяющее выбрать режим сопоставления.

В примере открывается презентация, созданная в предыдущем разделе, и для второго слайда настраивается анимация Morph на уровне слов.

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

## **Установка эффектов перехода**

Некоторые переходы предоставляют дополнительные параметры, такие как направление или начало эффекта с чёрного экрана. Доступные параметры зависят от выбранного [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/). Сначала задайте тип, затем используйте соответствующий объект перехода из его [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/).

В примере применяется переход Cut к первому слайду `input.pptx`. Через [OptionalBlackTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/) устанавливается параметр [from_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/), чтобы переход начинался с чёрного экрана.

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

**Можно ли управлять скоростью воспроизведения перехода слайда?**

Да. Предпочтительно использовать [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/), когда нужна точная длительность эффекта в миллисекундах. Используйте [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/), если подходит предопределённая категория из [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) — SLOW, MEDIUM или FAST, и явная длительность не задаётся. Эти настройки управляют эффектом перехода независимо от задержки автопереключения.

**Можно ли прикрепить звук к переходу и включить его зацикливание?**

Да. Назначьте встроенный звук свойству [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), установите [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) в START_SOUND из перечисления [TransitionSoundMode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionsoundmode/) и включите [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). Звук будет повторяться до следующего звукового события в показе.

**Как быстрее всего применить один и тот же переход ко всем слайдам?**

Пройдитесь циклом по коллекции [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) презентации и задайте каждому слайду свойству перехода [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) одинаковое значение. В том же цикле задайте любые параметры времени и эффекта, чтобы поведение было одинаковым для всех слайдов.

**Как проверить, какой переход установлен в данный момент у слайда?**

Прочитайте свойство [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) у свойства слайда [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/). Оно вернёт значение из перечисления [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/); NONE означает, что переход не задан.