---
title: Применение анимаций фигур в презентациях на Python
linktitle: Анимация фигур
type: docs
weight: 60
url: /ru/python-net/shape-animation/
keywords:
- фигура
- анимация
- эффект
- анимированная фигура
- анимированный текст
- добавить анимацию
- получить анимацию
- извлечь анимацию
- добавить эффект
- получить эффект
- извлечь эффект
- звук эффекта
- применить анимацию
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как создавать и настраивать анимацию фигур в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET. Выделяйтесь!"
---

Анимации — это визуальные эффекты, которые можно применять к тексту, изображениям, фигурам или [диаграммам](/slides/ru/python-net/animated-charts/). Они оживляют презентации и их элементы. 

## **Зачем использовать анимации в презентациях?**

Используя анимации, вы можете  

* управлять потоком информации  
* подчёркивать важные моменты  
* повышать интерес или вовлечённость аудитории  
* делать контент проще для чтения, усвоения или обработки  
* привлекать внимание читателей или зрителей к важным частям презентации  

PowerPoint предоставляет множество параметров и инструментов для анимаций и эффектов анимации в категориях **вход**, **выход**, **акцент** и **траектории движения**. 

## **Анимации в Aspose.Slides**

* Aspose.Slides предоставляет классы и типы, необходимые для работы с анимациями, в пространстве имён [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/).  
* Aspose.Slides предоставляет более **150 эффектов анимации** в перечислении [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/). Эти эффекты по сути те же (или эквивалентные) эффекты, которые используются в PowerPoint.

## **Применить анимацию к TextBox**

Aspose.Slides for Python via .NET позволяет применять анимацию к тексту в фигуре. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).  
4. Добавьте текст в `IAutoShape.TextFrame`.  
5. Получите основную последовательность эффектов.  
6. Добавьте анимационный эффект к [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).  
7. Установите свойство `TextAnimation.BuildType` в значение из перечисления `BuildType`.  
8. Запишите презентацию на диск в формате PPTX.  

Этот пример кода на Python показывает, как применить эффект `Fade` к AutoShape и установить анимацию текста со значением *By 1st Level Paragraphs*:

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a presentation file.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Adds new AutoShape with text
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # Gets the main sequence of the slide.
    sequence = sld.timeline.main_sequence

    # Adds Fade animation effect to shape
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Animates shape text by 1st level paragraphs
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Save the PPTX file to disk
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

Кроме применения анимаций к тексту, вы также можете применять анимации к отдельному [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/). См. [**Animated Text**](/slides/ru/python-net/animated-text/).

{{% /alert %}} 

## **Применить анимацию к PictureFrame**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте или получите [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) на слайде.  
4. Получите основную последовательность эффектов.  
5. Добавьте анимационный эффект к [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).  
6. Запишите презентацию на диск в формате PPTX.  

Этот пример кода на Python показывает, как применить эффект `Fly` к рамке изображения:

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Instantiates a presentation class that represents a presentation file.
with slides.Presentation() as pres:
    # Load Image to be added in presentaiton image collection
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Adds picture frame to slide
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Gets the main sequence of the slide.
    sequence = pres.slides[0].timeline.main_sequence

    # Adds Fly from Left animation effect to picture frame
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Save the PPTX file to disk
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Применить анимацию к Shape**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).  
4. Добавьте `Bevel` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) (при клике на этом объекте будет проигрываться анимация).  
5. Создайте последовательность эффектов для bevel‑фигуры.  
6. Создайте пользовательский `UserPath`.  
7. Добавьте команды перемещения к `UserPath`.  
8. Запишите презентацию на диск в формате PPTX.  

Этот пример кода на Python показывает, как применить эффект `PathFootball` (путь «футбол») к фигуре:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiates a Prseetation class that represents a PPTX file
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Creates PathFootball effect for existing shape from scratch.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # Adds the PathFootBall animation effect.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Creates some kind of "button".
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Creates a sequence of effects for the button.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Creates a custom user path. Our object will be moved only after the button is clicked.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Adds commands for moving since created path is empty.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # Writes the PPTX file to disk
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Получить эффекты анимации, применённые к фигуре**

В следующих примерах показано, как использовать метод `get_effects_by_shape` класса [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) для получения всех эффектов анимации, применённых к фигуре.

**Пример 1: Получить эффекты анимации, применённые к фигуре на обычном слайде**

Ранее вы узнали, как добавлять эффекты анимации к фигурам в презентациях PowerPoint. Следующий пример кода показывает, как получить эффекты, применённые к первой фигуре на первом обычном слайде презентации `AnimExample_out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Gets the main animation sequence of the slide.
    sequence = first_slide.timeline.main_sequence

    # Gets the first shape on the first slide.
    shape = first_slide.shapes[0]

    # Gets animation effects applied to the shape.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**Пример 2: Получить все эффекты анимации, включая унаследованные от заполнителей**

Если на обычном слайде фигура имеет заполнители, которые находятся на шаблоне слайда и/или на главном слайде, и к этим заполнителям добавлены эффекты анимации, то все эффекты фигуры будут воспроизводиться во время показа, включая унаследованные от заполнителей.

Предположим, что у нас есть файл презентации PowerPoint `sample.pptx` с одним слайдом, содержащим только форму нижнего колонтитула с текстом "Made with Aspose.Slides" и применён эффект **Random Bars**.

![Эффект анимации фигуры на слайде](slide-shape-animation.png)

Также предположим, что эффект **Split** применён к заполнителю нижнего колонтитула на слайде **layout**.

![Эффект анимации фигуры на макете](layout-shape-animation.png)

И, наконец, эффект **Fly In** применён к заполнителю нижнего колонтитула на слайде **master**.

![Эффект анимации фигуры на мастере](master-shape-animation.png)

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Get animation effects of the shape on the normal slide.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # Get animation effects of the placeholder on the layout slide.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # Get animation effects of the placeholder on the master slide.
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Main sequence of shape effects:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

Вывод:
```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **Изменить свойства времени эффекта анимации**

Aspose.Slides for Python via .NET позволяет изменять свойства Timing (время) анимационного эффекта.

Это панель Animation Timing в Microsoft PowerPoint:

![Панель Timing анимации](shape-animation.png)

Эти соответствия между PowerPoint Timing и свойствами `Effect.Timing`:

- Выпадающий список **Start** в PowerPoint Timing соответствует свойству [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/).  
- PowerPoint Timing **Duration** соответствует свойству `Effect.Timing.Duration`. Длительность анимации (в секундах) — это общее время, необходимое для завершения одного цикла анимации.  
- PowerPoint Timing **Delay** соответствует свойству `Effect.Timing.TriggerDelayTime`.  

Вот как изменить свойства Timing эффекта:

1. [Применить](#apply-animation-to-shape) или получить эффект анимации.  
2. Установите новые значения для нужных свойств `Effect.Timing`.  
3. Сохраните изменённый файл PPTX.  

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a presentation file.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Gets the main sequence of the slide.
    sequence = pres.slides[0].timeline.main_sequence

    # Gets the first effect of main sequence.
    effect = sequence[0]

    # Changes effect TriggerType to start on click
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Changes effect Duration
    effect.timing.duration = 3

    # Changes effect TriggerDelayTime
    effect.timing.trigger_delay_time = 0.5

    # Saves the PPTX file to disk
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Звук эффекта анимации**

Aspose.Slides предоставляет следующие свойства для работы со звуком в эффектах анимации:  

- `sound`  
- `stop_previous_sound`  

### **Добавить звук к эффекту анимации**

Этот пример кода на Python показывает, как добавить звук к эффекту анимации и остановить его при запуске следующего эффекта:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Adds audio to presentation audio collection
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Gets the main sequence of the slide.
    sequence = first_slide.timeline.main_sequence

    # Gets the first effect of the main sequence
    first_effect = sequence[0]

    # Сhecks the effect for "No Sound"
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Adds sound for the first effect
        first_effect.sound = effect_sound

    # Gets the first interactive sequence of the slide.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Sets the effect "Stop previous sound" flag
    interactive_sequence[0].stop_previous_sound = True

    # Writes the PPTX file to disk
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Извлечь звук эффекта анимации**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Получите ссылку на слайд по его индексу.  
3. Получите основную последовательность эффектов.  
4. Извлеките `sound`, встроенный в каждый эффект анимации.  

Этот пример кода на Python показывает, как извлечь звук, встроенный в эффект анимации:

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a presentation file.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # Gets the main sequence of the slide.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # Extracts the effect sound in byte array
        audio = effect.sound.binary_data
```

## **После анимации**

Aspose.Slides for .NET позволяет изменять свойство After animation эффекта анимации.

Это панель Animation Effect и расширенное меню в Microsoft PowerPoint:

![Панель After Animation](shape-after-animation.png)

Выпадающий список **After animation** в PowerPoint Effect соответствует следующим свойствам:  

- `after_animation_type` — свойство, описывающее тип After animation:  
  * PowerPoint **More Colors** соответствует типу [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/);  
  * PowerPoint **Don't Dim** соответствует типу [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) (тип анимации по умолчанию);  
  * PowerPoint **Hide After Animation** соответствует типу [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/);  
  * PowerPoint **Hide on Next Mouse Click** соответствует типу [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/);  
- `after_animation_color` — свойство, определяющее цвет после анимации. Это свойство работает совместно с типом [COLOR]. При смене типа цвет после анимации будет очищен.  

Этот пример кода на Python показывает, как изменить эффект After animation:

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a presentation file
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Gets the first effect of the main sequence
    first_effect = first_slide.timeline.main_sequence[0]

    # Changes the after animation type to Color
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Sets the after animation dim color
    first_effect.after_animation_color.color = Color.alice_blue

    # Writes the PPTX file to disk
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **Анимировать текст**

Aspose.Slides предоставляет следующие свойства для работы с блоком *Animate text* эффекта анимации:  

- `animate_text_type` — описывает тип анимации текста эффекта. Текст фигуры может анимироваться:  
  - Все одновременно ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/))  
  - По словам ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/))  
  - По символам ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/))  
- `delay_between_text_parts` задаёт задержку между анимированными частями текста (словами или буквами). Положительное значение указывает процент от длительности эффекта, отрицательное — задержку в секундах.  

Вот как можно изменить свойства *Animate text* эффекта:

1. [Применить](#apply-animation-to-shape) или получить эффект анимации.  
2. Установите свойство `build_type` в значение [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/) для отключения режима *By Paragraphs*.  
3. Установите новые значения для `animate_text_type` и `delay_between_text_parts`.  
4. Сохраните изменённый файл PPTX.  

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Gets the first effect of the main sequence
    first_effect = first_slide.timeline.main_sequence[0]

    # Changes the effect Text animation type to "As One Object"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Changes the effect Animate text type to "By word"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Sets the delay between words to 20% of effect duration
    first_effect.delay_between_text_parts = 20

    # Writes the PPTX file to disk
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```

## **FAQ**

**Как гарантировать сохранение анимаций при публикации презентации в веб?**  

Экспортируйте в [HTML5](/slides/ru/python-net/export-to-html5/) и включите параметры, отвечающие за анимацию [фигур](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) и [переходов](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/). Обычный HTML не воспроизводит анимацию слайдов, тогда как HTML5 — да.

**Как изменение порядка слоёв (z‑order) фигур влияет на анимацию?**  

Анимация и порядок отрисовки независимы: эффект управляет временем и типом появления/исчезновения, а [z‑order](https://reference.aspose.com/slides/python-net/aspose.slides/shape/z_order_position/) определяет, что покрывает что. Видимый результат определяется их комбинацией. (Это общее поведение PowerPoint; модель Aspose.Slides «эффекты‑и‑фигуры» работает по тем же правилам.)

**Есть ли ограничения при конвертации анимаций в видео для некоторых эффектов?**  

В общем, [анимации поддерживаются](/slides/ru/python-net/convert-powerpoint-to-video/), но редкие случаи или специфические эффекты могут отрисовываться иначе. Рекомендуется тестировать используемые эффекты и версию библиотеки.