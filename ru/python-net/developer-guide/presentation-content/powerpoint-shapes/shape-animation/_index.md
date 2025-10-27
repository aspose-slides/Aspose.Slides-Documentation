---
title: Apply Shape Animations in Presentations with Python
linktitle: Shape Animation
type: docs
weight: 60
url: /ru/python-net/shape-animation/
keywords:
- shape
- animation
- effect
- animated shape
- animated text
- add animation
- get animation
- extract animation
- add effect
- get effect
- extract effect
- effect sound
- apply animation
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Discover how to create and customize shape animations in PowerPoint and OpenDocument presentations with Aspose.Slides for Python via .NET. Stand out!"
---

Анимации — это визуальные эффекты, которые можно применять к текстам, изображениям, фигурам или [диаграммам](/slides/ru/python-net/animated-charts/). Они придают жизнь презентациям и их элементам. 

## **Зачем использовать анимации в презентациях?**

* управлять потоком информации  
* подчеркивать важные моменты  
* повышать интерес или вовлечённость аудитории  
* делать контент более легким для чтения, усвоения или обработки  
* привлекать внимание читателей или зрителей к важным частям презентации  

PowerPoint предоставляет множество вариантов и инструментов для анимаций и анимационных эффектов в категориях **entrance**, **exit**, **emphasis**, и **motion paths**. 

## **Анимации в Aspose.Slides**

* Aspose.Slides предоставляет классы и типы, необходимые для работы с анимациями, в пространстве имен [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/).  
* Aspose.Slides предоставляет более **150 анимационных эффектов** в перечислении [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/). Эти эффекты по сути те же (или эквивалентные), что используются в PowerPoint.  

## **Применение анимации к TextBox**

Aspose.Slides for Python via .NET позволяет применять анимацию к тексту в фигуре. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).  
4. Добавьте текст в `IAutoShape.TextFrame`.  
5. Получите главную последовательность эффектов.  
6. Добавьте анимационный эффект к [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).  
7. Установите свойство `TextAnimation.BuildType` в значение из перечисления `BuildType`.  
8. Сохраните презентацию на диск в виде файла PPTX.  

Этот код на Python показывает, как применить эффект `Fade` к AutoShape и установить анимацию текста в значение *By 1st Level Paragraphs*:

```python
import aspose.slides as slides

# Создаёт экземпляр класса презентации, представляющего файл презентации.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Добавляет новый AutoShape с текстом
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # Получает главную последовательность слайда.
    sequence = sld.timeline.main_sequence

    # Добавляет эффект анимации Fade к фигуре
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Анимирует текст фигуры по абзацам первого уровня
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Сохраняет файл PPTX на диск
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

Помимо применения анимаций к тексту, вы также можете применять анимации к отдельному [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/). Смотрите **Animated Text**(/slides/ru/python-net/animated-text/).

{{% /alert %}} 

## **Применение анимации к PictureFrame**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте или получите [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) на слайде.  
4. Получите главную последовательность эффектов.  
5. Добавьте анимационный эффект к [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).  
6. Сохраните презентацию на диск в виде файла PPTX.  

Этот код на Python показывает, как применить эффект `Fly` к рамке изображения:

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Создаёт экземпляр класса презентации, представляющего файл презентации.
with slides.Presentation() as pres:
    # Загружает изображение, которое будет добавлено в коллекцию изображений презентации
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Добавляет рамку изображения на слайд
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Получает главную последовательность слайда.
    sequence = pres.slides[0].timeline.main_sequence

    # Добавляет эффект анимации Fly from Left к рамке изображения
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Сохраняет файл PPTX на диск
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Применение анимации к Shape**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).  
4. Добавьте `Bevel` [IAutoShape] (при щелчке по этому объекту будет воспроизводиться анимация).  
5. Создайте последовательность эффектов для фигуры Bevel.  
6. Создайте пользовательский `UserPath`.  
7. Добавьте команды перемещения к `UserPath`.  
8. Сохраните презентацию на диск в виде файла PPTX.  

Этот код на Python показывает, как применить эффект `PathFootball` к фигуре:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Создаёт экземпляр класса Presentation, представляющего файл PPTX
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Создаёт эффект PathFootball для существующей фигуры с нуля.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # Добавляет анимационный эффект PathFootBall.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Создаёт некую "кнопку".
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Создаёт последовательность эффектов для кнопки.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Создаёт пользовательский путь. Наш объект будет перемещён только после щелчка по кнопке.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Добавляет команды перемещения, так как созданный путь пуст.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # Сохраняет файл PPTX на диск
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Получение анимационных эффектов, применённых к Shape**

Приведённые примеры показывают, как использовать метод `get_effects_by_shape` из класса [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) для получения всех анимационных эффектов, применённых к фигуре.

**Пример 1: Получить анимационные эффекты, применённые к фигуре на обычном слайде**

Ранее вы узнали, как добавлять анимационные эффекты к фигурам в презентациях PowerPoint. Следующий пример кода демонстрирует, как получить эффекты, применённые к первой фигуре на первом обычном слайде презентации `AnimExample_out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Получает главную анимационную последовательность слайда.
    sequence = first_slide.timeline.main_sequence

    # Получает первую фигуру на первом слайде.
    shape = first_slide.shapes[0]

    # Получает анимационные эффекты, применённые к фигуре.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**Пример 2: Получить все анимационные эффекты, включая унаследованные из заполнителей**

Если у фигуры на обычном слайде есть заполнители, которые находятся на слайде макета и/или мастера, и к этим заполнителям добавлены анимационные эффекты, то все эффекты фигуры будут воспроизводиться во время показа, включая унаследованные из заполнителей.

Предположим, что у нас есть файл презентации PowerPoint `sample.pptx` с одним слайдом, содержащим только фигуру нижнего колонтитула с текстом «Made with Aspose.Slides», к которой применён эффект **Random Bars**.

![Эффект анимации фигуры слайда](slide-shape-animation.png)

Также предположим, что к заполнителю нижнего колонтитула на **layout**‑слайде применён эффект **Split**.

![Эффект анимации фигуры макета](layout-shape-animation.png)

И, наконец, к заполнителю нижнего колонтитула на **master**‑слайде применён эффект **Fly In**.

![Эффект анимации фигуры мастера](master-shape-animation.png)

Следующий пример кода показывает, как использовать метод `get_base_placeholder` из класса [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) для доступа к заполнителям фигур и получения анимационных эффектов, применённых к фигуре нижнего колонтитула, включая унаследованные из заполнителей на layout‑ и master‑слайдах.

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Получить анимационные эффекты фигуры на обычном слайде.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # Получить анимационные эффекты заполнителя на слайде макета.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # Получить анимационные эффекты заполнителя на слайде мастера.
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

## **Изменение свойств синхронизации анимационного эффекта**

Aspose.Slides for Python via .NET позволяет изменять свойства синхронизации (Timing) анимационного эффекта.

Это панель Timing анимации в Microsoft PowerPoint:

![example1_image](shape-animation.png)

Эти соответствия между параметрами Timing в PowerPoint и свойствами `Effect.Timing`:

- Выпадающий список **Start** в PowerPoint Timing соответствует свойству [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/).  
- Поле **Duration** в PowerPoint Timing соответствует свойству `Effect.Timing.Duration`. Длительность анимации (в секундах) — общее время, за которое анимация полностью выполнит один цикл.  
- Поле **Delay** соответствует свойству `Effect.Timing.TriggerDelayTime`.  

Как изменить свойства Timing эффекта:

1. [Примените]#apply-animation-to-shape или получите анимационный эффект.  
2. Установите новые значения для нужных свойств `Effect.Timing`.  
3. Сохраните изменённый файл PPTX.  

Этот код на Python демонстрирует операцию:

```python
import aspose.slides as slides

# Создаёт экземпляр класса презентации, представляющего файл презентации.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Получает главную последовательность слайда.
    sequence = pres.slides[0].timeline.main_sequence

    # Получает первый эффект главной последовательности.
    effect = sequence[0]

    # Изменяет TriggerType эффекта, чтобы запускался по щелчку.
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Изменяет длительность эффекта
    effect.timing.duration = 3

    # Изменяет TriggerDelayTime эффекта
    effect.timing.trigger_delay_time = 0.5

    # Сохраняет файл PPTX на диск
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Звук анимационного эффекта**

Aspose.Slides предоставляет следующие свойства, позволяющие работать со звуками в анимационных эффектах:

- `sound`
- `stop_previous_sound`

### **Add Animation Effect Sound**

Этот код на Python показывает, как добавить звук к анимационному эффекту и остановить его, когда начинается следующий эффект:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Добавляет аудио в коллекцию аудио презентации
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Получает главную последовательность слайда.
    sequence = first_slide.timeline.main_sequence

    # Получает первый эффект главной последовательности
    first_effect = sequence[0]

    # Проверяет эффект на отсутствие звука
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Добавляет звук для первого эффекта
        first_effect.sound = effect_sound

    # Получает первую интерактивную последовательность слайда.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Устанавливает флаг "Stop previous sound" для эффекта
    interactive_sequence[0].stop_previous_sound = True

    # Сохраняет файл PPTX на диск
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Extract Animation Effect Sound**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Получите ссылку на слайд по его индексу.  
3. Получите главную последовательность эффектов.  
4. Извлеките звук, встроенный в каждый анимационный эффект.  

Этот код на Python показывает, как извлечь звук, встроенный в анимационный эффект:

```python
import aspose.slides as slides

# Создаёт экземпляр класса презентации, представляющего файл презентации.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # Получает главную последовательность слайда.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # Извлекает звук эффекта в массив байтов
        audio = effect.sound.binary_data
```

## **После анимации**

Aspose.Slides for .NET позволяет изменить свойство After animation анимационного эффекта.

Это панель Effect и расширенное меню в Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Выпадающий список **After animation** в PowerPoint совпадает со следующими свойствами:

- Свойство `after_animation_type`, описывающее тип после анимации:  
  * PowerPoint **More Colors** соответствует типу [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/);  
  * PowerPoint **Don't Dim** соответствует типу [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) (тип после анимации по умолчанию);  
  * PowerPoint **Hide After Animation** соответствует типу [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/);  
  * PowerPoint **Hide on Next Mouse Click** соответствует типу [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/);  
- Свойство `after_animation_color`, определяющее формат цвета после анимации. Это свойство работает совместно с типом [COLOR]. При изменении типа на другой цвет после анимации будет сброшен.  

```python
import aspose.slides as slides

# Создаёт экземпляр класса презентации, представляющего файл презентации
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Получает первый эффект главной последовательности
    first_effect = first_slide.timeline.main_sequence[0]

    # Изменяет тип после анимации на Color
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Устанавливает цвет затемнения после анимации
    first_effect.after_animation_color.color = Color.alice_blue

    # Сохраняет файл PPTX на диск
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **Анимация текста**

Aspose.Slides предоставляет следующие свойства, позволяющие работать с блоком *Animate text* анимационного эффекта:

- `animate_text_type`, описывающий тип анимации текста эффекта. Текст фигуры может анимироваться:  
  - Все сразу ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/));  
  - По словам ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/));  
  - По буквам ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/)).  
- `delay_between_text_parts` задаёт задержку между частями анимированного текста (словами или буквами). Положительное значение указывает процент от длительности эффекта. Отрицательное — задержку в секундах.  

Как изменить свойства *Animate text* эффекта:

1. [Примените]#apply-animation-to-shape или получите анимационный эффект.  
2. Установите свойство `build_type` в значение [AS_ONE_OBJECT], чтобы отключить режим анимации *By Paragraphs*.  
3. Установите новые значения для свойств `animate_text_type` и `delay_between_text_parts`.  
4. Сохраните изменённый файл PPTX.  

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Получает первый эффект главной последовательности
    first_effect = first_slide.timeline.main_sequence[0]

    # Изменяет тип анимации текста эффекта на "As One Object"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Изменяет тип анимации текста эффекта на "By word"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Устанавливает задержку между словами в 20% от длительности эффекта
    first_effect.delay_between_text_parts = 20

    # Сохраняет файл PPTX на диск
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```

## **FAQ**

**Как обеспечить сохранение анимаций при публикации презентации в веб?**  
[Экспорт в HTML5](/slides/ru/python-net/export-to-html5/) и включение соответствующих [опций](/slides/ru/python-net/aspose.slides.export/html5options/) для анимации [форм**](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) и [переходов](/slides/ru/python-net/aspose.slides.export/html5options/animate_transitions/) гарантируют сохранение анимаций. Обычный HTML не воспроизводит анимацию слайдов, в то время как HTML5 — да.

**Как изменение порядка слоёв (z-order) фигур влияет на анимацию?**  
Анимация и порядок отрисовки независимы: эффект управляет временем и типом появления/исчезновения, тогда как **z-order** определяет, что перекрывает что. Видимый результат определяется их комбинацией. (Это общее поведение PowerPoint; модель Aspose.Slides следует той же логике.)

**Есть ли ограничения при конвертации анимаций в видео для некоторых эффектов?**  
В целом [анимации поддерживаются](/slides/ru/python-net/convert-powerpoint-to-video/), но редкие случаи или специфические эффекты могут отображаться иначе. Рекомендуется протестировать используемые эффекты и версию библиотеки.