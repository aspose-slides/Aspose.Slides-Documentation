---
title: Применение анимации фигур в презентациях с помощью Python
linktitle: Анимация фигур
type: docs
weight: 60
url: /ru/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-animation/
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
description: "Узнайте, как создавать и настраивать анимацию фигур в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Python via .NET. Выделяйтесь!"
---

Анимации — это визуальные эффекты, которые можно применять к тексту, изображениям, фигурам или [диаграммам](/slides/ru/python-net/animated-charts/). Они оживляют презентации и их элементы. 

## **Зачем использовать анимацию в презентациях?**

С помощью анимаций вы можете  

* контролировать поток информации  
* подчёркивать важные пункты  
* повышать интерес или вовлечённость аудитории  
* облегчать восприятие и усвоение контента  
* привлекать внимание читателей или зрителей к важным частям презентации  

PowerPoint предоставляет множество параметров и инструментов для анимаций и эффектов анимации в категориях **вход**, **выход**, **выделение** и **траектории движения**. 

## **Анимации в Aspose.Slides**

* Aspose.Slides предоставляет необходимые классы и типы для работы с анимациями в пространстве имён [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/)  
* Aspose.Slides предлагает более **150 анимационных эффектов** в перечислении [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/). Эти эффекты по существу соответствуют тем, что используются в PowerPoint.  

## **Применение анимации к TextBox**

Aspose.Slides for Python via .NET позволяет применить анимацию к тексту внутри фигуры.  

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте `rectangle`‑[IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).  
4. Добавьте текст в `IAutoShape.TextFrame`.  
5. Получите главную последовательность эффектов.  
6. Добавьте анимационный эффект к [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).  
7. Установите свойство `TextAnimation.BuildType` в значение из перечисления `BuildType`.  
8. Сохраните презентацию на диск в формате PPTX.  

Этот пример кода на Python демонстрирует, как применить эффект `Fade` к AutoShape и задать анимацию текста со значением *By 1st Level Paragraphs*:

```python
import aspose.slides as slides

# Создаёт объект презентации, представляющий файл презентации.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Добавляет новую AutoShape с текстом
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

Помимо анимации текста, вы можете анимировать отдельный [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/). См. [**Анимированный текст**](/slides/ru/python-net/animated-text/).

{{% /alert %}} 

## **Применение анимации к PictureFrame**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте или получите [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) на слайде.  
4. Получите главную последовательность эффектов.  
5. Добавьте анимационный эффект к [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).  
6. Сохраните презентацию на диск в формате PPTX.  

Этот пример кода на Python показывает, как применить эффект `Fly` к кадру изображения:

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Создаёт объект презентации, представляющий файл презентации.
with slides.Presentation() as pres:
    # Загружает изображение, которое будет добавлено в коллекцию изображений презентации
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Добавляет кадр изображения на слайд
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Получает главную последовательность слайда.
    sequence = pres.slides[0].timeline.main_sequence

    # Добавляет эффект анимации Fly from Left к кадру изображения
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Сохраняет файл PPTX на диск
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Применение анимации к Figure**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте `rectangle`‑[IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).  
4. Добавьте `Bevel`‑[IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) (по нажатию на этот объект будет воспроизводиться анимация).  
5. Создайте последовательность эффектов для фигуры‑скосов.  
6. Создайте пользовательскую `UserPath`.  
7. Добавьте команды перемещения к `UserPath`.  
8. Сохраните презентацию на диск в формате PPTX.  

Этот пример кода на Python показывает, как применить эффект `PathFootball` (траектория «футбол») к фигуре:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Создаёт объект Presentation, представляющий файл PPTX
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Создаёт эффект PathFootball для существующей фигуры с нуля.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # Добавляет эффект анимации PathFootBall.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Создаёт некую «кнопку».
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Создаёт последовательность эффектов для кнопки.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Создаёт пользовательскую траекторию. Объект будет перемещён только после клика по кнопке.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Добавляет команды перемещения, т.к. созданная траектория пустая.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # Сохраняет файл PPTX на диск
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Получение анимационных эффектов, применённых к фигуре**

Ниже показаны примеры, как использовать метод `get_effects_by_shape` класса [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) для получения всех анимационных эффектов, применённых к фигуре.

**Пример 1: Получить анимационные эффекты, применённые к фигуре на обычном слайде**

Ранее вы узнали, как добавлять анимационные эффекты к фигурам в презентациях PowerPoint. Следующий пример кода демонстрирует, как получить эффекты, применённые к первой фигуре на первом обычном слайде в презентации `AnimExample_out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Получает главную последовательность анимаций слайда.
    sequence = first_slide.timeline.main_sequence

    # Получает первую фигуру на первом слайде.
    shape = first_slide.shapes[0]

    # Получает анимационные эффекты, применённые к фигуре.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("Фигура", shape.name, "имеет", len(shape_effects), "анимационных эффектов.")
```

**Пример 2: Получить все анимационные эффекты, включая унаследованные от заполнителей**

Если на обычном слайде фигура имеет заполнители, находящиеся на слайде‑шаблоне и/или главном слайде, и к этим заполнителям добавлены анимационные эффекты, то все эффекты фигуры будут воспроизводиться во время показа, включая унаследованные от заполнителей.

Предположим, у нас есть файл презентации PowerPoint `sample.pptx` с одним слайдом, содержащим только фигурку нижнего колонтитула с текстом «Made with Aspose.Slides» и к этой фигуре применён эффект **Random Bars**.

![Эффект анимации фигуры на слайде](slide-shape-animation.png)

Также предположим, что на слайде‑шаблоне к нижнему колонтитулу применён эффект **Split**.

![Эффект анимации фигуры на шаблоне](layout-shape-animation.png)

И, наконец, на главном слайде к нижнему колонтитулу применён эффект **Fly In**.

![Эффект анимации фигуры на главном слайде](master-shape-animation.png)

Следующий пример кода показывает, как с помощью метода `get_base_placeholder` класса [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) получить доступ к заполнителям фигур и собрать анимационные эффекты, применённые к нижнему колонтитулу, включая унаследованные от заполнителей на шаблоне и главном слайде.

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Получаем эффекты фигуры на обычном слайде.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # Получаем эффекты заполнителя на шаблоне.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # Получаем эффекты заполнителя на главном слайде.
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Главная последовательность эффектов фигуры:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

Вывод:
```text
Главная последовательность эффектов фигуры:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **Изменение параметров тайминга анимационного эффекта**

Aspose.Slides for Python via .NET позволяет изменять параметры тайминга анимационного эффекта.

Это панель тайминга анимации в Microsoft PowerPoint:

![example1_image](shape-animation.png)

Соответствия между таймингом PowerPoint и свойствами `Effect.Timing`:

- Выпадающий список **Start** в PowerPoint соответствует свойству [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/).  
- Поле **Duration** соответствует свойству `Effect.Timing.Duration`. Длительность анимации (в секундах) — это общее время, необходимое для завершения одного цикла анимации.  
- Поле **Delay** соответствует свойству `Effect.Timing.TriggerDelayTime`.  

Как изменить свойства тайминга эффекта:

1. [Примените](#apply-animation-to-shape) или получите анимационный эффект.  
2. Установите новые значения нужных вам свойств `Effect.Timing`.  
3. Сохраните изменённый файл PPTX.  

Пример кода на Python, демонстрирующий эту операцию:

```python
import aspose.slides as slides

# Создаёт объект презентации, представляющий файл презентации.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Получает главную последовательность слайда.
    sequence = pres.slides[0].timeline.main_sequence

    # Получает первый эффект главной последовательности.
    effect = sequence[0]

    # Меняет TriggerType эффекта на запуск по щелчку
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Меняет длительность эффекта
    effect.timing.duration = 3

    # Меняет задержку запуска эффекта
    effect.timing.trigger_delay_time = 0.5

    # Сохраняет файл PPTX на диск
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Звук анимационного эффекта**

Aspose.Slides предоставляет следующие свойства для работы со звуками в анимационных эффектах:  

- `sound`  
- `stop_previous_sound`  

### **Добавление звука к анимационному эффекту**

Этот пример кода на Python показывает, как добавить звук к анимационному эффекту и остановить его, когда начинается следующий эффект:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Добавляет аудио в коллекцию аудиофайлов презентации
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Получает главную последовательность слайда.
    sequence = first_slide.timeline.main_sequence

    # Получает первый эффект главной последовательности
    first_effect = sequence[0]

    # Проверяет, установлен ли «No Sound»
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Добавляет звук к первому эффекту
        first_effect.sound = effect_sound

    # Получает первую интерактивную последовательность слайда.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Устанавливает флаг «Stop previous sound» для эффекта
    interactive_sequence[0].stop_previous_sound = True

    # Сохраняет файл PPTX на диск
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Извлечение звука из анимационного эффекта**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Получите ссылку на слайд по его индексу.  
3. Получите главную последовательность эффектов.  
4. Извлеките звук, встроенный в каждый анимационный эффект.  

Этот пример кода на Python показывает, как извлечь звуковой файл, встроенный в анимационный эффект:

```python
import aspose.slides as slides

# Создаёт объект презентации, представляющий файл презентации.
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

## **After Animation (после анимации)**

Aspose.Slides for .NET позволяет менять свойство **After animation** (после анимации) у анимационного эффекта.

Это панель параметров анимационного эффекта и расширенное меню в Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Выпадающий список **After animation** в PowerPoint соответствует следующим свойствам:  

- Свойство `after_animation_type`, описывающее тип после анимации:  
  * **More Colors** — тип [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/)  
  * **Don't Dim** — тип [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) (значение по умолчанию)  
  * **Hide After Animation** — тип [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/)  
  * **Hide on Next Mouse Click** — тип [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/)  
- Свойство `after_animation_color`, определяющее цвет после анимации. Это свойство используется совместно с типом **COLOR**. При смене типа на другой цвет будет сброшен.  

Пример кода на Python, показывающий, как изменить тип «после анимации»:

```python
import aspose.slides as slides

# Создаёт объект презентации, представляющий файл презентации
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Получает первый эффект главной последовательности
    first_effect = first_slide.timeline.main_sequence[0]

    # Меняет тип after animation на Color
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Устанавливает цвет затемнения after animation
    first_effect.after_animation_color.color = Color.alice_blue

    # Сохраняет файл PPTX на диск
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **Animate Text (анимация текста)**

Aspose.Slides предоставляет следующие свойства для работы с блоком *Animate text* анимационного эффекта:  

- `animate_text_type` — тип анимации текста. Текст фигуры может анимироваться:  
  - сразу целиком ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/))  
  - по словам ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/))  
  - по буквам ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/))  
- `delay_between_text_parts` — задержка между частями анимированного текста (словами или буквами). Положительное значение задаёт процент от длительности эффекта, отрицательное — задержку в секундах.  

Как изменить свойства **Animate text** у эффекта:

1. [Примените](#apply-animation-to-shape) или получите анимационный эффект.  
2. Установите свойство `build_type` в значение [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/) — отключит режим *By Paragraphs*.  
3. Задайте новые значения для `animate_text_type` и `delay_between_text_parts`.  
4. Сохраните изменённый файл PPTX.  

Пример кода на Python, демонстрирующий эту операцию:

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Получает первый эффект главной последовательности
    first_effect = first_slide.timeline.main_sequence[0]

    # Меняет тип текста анимации на «As One Object»
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Меняет тип анимации текста на «By word»
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Устанавливает задержку между словами в 20 % от длительности эффекта
    first_effect.delay_between_text_parts = 20

    # Сохраняет файл PPTX на диск
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```

## **FAQ**

**Как гарантировать сохранение анимаций при публикации презентации в веб?**

[Экспорт в HTML5](/slides/ru/python-net/export-to-html5/) и включение соответствующих [опций](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/), отвечающих за анимацию [фигур](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) и [переходов](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/). Обычный HTML не воспроизводит анимацию слайдов, тогда как HTML5 — воспроизводит.

**Как изменение порядка слоёв (z‑order) фигур влияет на анимацию?**

Порядок анимации и порядок отрисовки независимы: эффект управляет временем и типом появления/исчезновения, а [z‑order](https://reference.aspose.com/slides/python-net/aspose.slides/shape/z_order_position/) определяет, какие объекты покрывают другие. Видимый результат формируется их комбинацией. (Это общее поведение PowerPoint; модель Aspose.Slides работает по тем же правилам.)

**Есть ли ограничения при конвертации анимаций в видео для некоторых эффектов?**

В целом [анимации поддерживаются](/slides/ru/python-net/convert-powerpoint-to-video/), но в редких случаях или для специфических эффектов могут быть различия в рендеринге. Рекомендуется тестировать используемые эффекты и текущую версию библиотеки.