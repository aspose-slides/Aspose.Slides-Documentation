---
title: Применение анимаций фигур в презентациях с Python
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

Анимации — это визуальные эффекты, которые можно применять к тексту, изображениям, фигурам или [диаграммам](/slides/ru/python-net/animated-charts/). Они придают жизнь презентациям и их элементам. 

## **Почему использовать анимацию в презентациях?**

* контролировать поток информации
* подчёркивать важные моменты
* повышать интерес или вовлечённость аудитории
* делать контент легче читаемым, усваиваемым или обрабатываемым
* привлекать внимание читателей или зрителей к важным частям презентации

PowerPoint предоставляет множество вариантов и инструментов для анимаций и эффектов анимации в категориях **вход**, **выход**, **акцент** и **траектории движения**. 

## **Анимации в Aspose.Slides**

* Aspose.Slides предоставляет классы и типы, необходимые для работы с анимациями, в пространстве имён [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/).
* Aspose.Slides предоставляет более **150 эффектов анимации** в перечислении [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/). Эти эффекты по сути такие же (или эквивалентные) эффекты, используемые в PowerPoint.

## **Применить анимацию к TextBox**

Aspose.Slides для Python через .NET позволяет применять анимацию к тексту в фигуре. 

1. Создайте экземпляр [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) класса.  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).  
4. Добавьте текст в `IAutoShape.TextFrame`.  
5. Получите главную последовательность эффектов.  
6. Добавьте эффект анимации к [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).  
7. Установите свойство `TextAnimation.BuildType` в значение из перечисления `BuildType`.  
8. Запишите презентацию на диск в виде файла PPTX.  

```python
import aspose.slides as slides

# Создаёт экземпляр класса презентации, представляющий файл презентации.
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

Помимо применения анимаций к тексту, вы также можете применять анимации к отдельному [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/). Смотрите [**Анимированный текст**](/slides/ru/python-net/animated-text/).  

{{% /alert %}} 

## **Применить анимацию к PictureFrame**

1. Создайте экземпляр [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) класса.  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте или получите [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) на слайде.  
4. Получите главную последовательность эффектов.  
5. Добавьте эффект анимации к [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).  
6. Запишите презентацию на диск в виде файла PPTX.  

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Создаёт экземпляр класса презентации, представляющий файл презентации.
with slides.Presentation() as pres:
    # Загружает изображение, которое будет добавлено в коллекцию изображений презентации
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Добавляет рамку изображения на слайд
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Получает главную последовательность слайда.
    sequence = pres.slides[0].timeline.main_sequence

    # Добавляет эффект анимации Fly слева к рамке изображения
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Сохраняет файл PPTX на диск
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Применить анимацию к Shape**

1. Создайте экземпляр [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) класса.  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).  
4. Добавьте `Bevel` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) (когда этот объект щёлкнут, анимация воспроизводится).  
5. Создайте последовательность эффектов на фигурe bevel.  
6. Создайте пользовательский `UserPath`.  
7. Добавьте команды перемещения к `UserPath`.  
8. Запишите презентацию на диск в виде файла PPTX.  

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

    # Создаёт пользовательский путь. Наш объект будет перемещён только после нажатия кнопки.
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

    # Записывает файл PPTX на диск
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Получить эффекты анимации, применённые к Shape**

Следующие примеры показывают, как использовать метод `get_effects_by_shape` из класса [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) для получения всех эффектов анимации, применённых к фигуре.

**Пример 1: Получить эффекты анимации, применённые к фигуре на обычном слайде**

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Получает основную последовательность анимаций слайда.
    sequence = first_slide.timeline.main_sequence

    # Получает первую фигуру на первом слайде.
    shape = first_slide.shapes[0]

    # Получает эффекты анимации, применённые к фигуре.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**Пример 2: Получить все эффекты анимации, включая унаследованные из заполнителей**

Если у фигуры на обычном слайде есть заполнители, находящиеся на слайде‑макете и/или главном слайде, и к этим заполнителям добавлены эффекты анимации, то все эффекты фигуры будут воспроизводиться во время показа, включая унаследованные из заполнителей.

```python
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```python
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Получает эффекты анимации фигуры на обычном слайде.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # Получает эффекты анимации заполнителя на слайде макета.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # Получает эффекты анимации заполнителя на главном слайде.
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Основная последовательность эффектов фигуры:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

Output:
```text
Основная последовательность эффектов фигуры:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **Изменить свойства тайминга эффекта анимации**

Aspose.Slides для Python через .NET позволяет изменять свойства `Timing` эффекта анимации.

Это панель **Animation Timing** в Microsoft PowerPoint:

![example1_image](shape-animation.png)

Соответствия между таймингом PowerPoint и свойствами `Effect.Timing`:

- Выпадающий список PowerPoint **Start** соответствует свойству [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/).  
- Поле PowerPoint **Duration** соответствует свойству `Effect.Timing.Duration`. Длительность анимации (в секундах) — общее время, за которое анимация завершит один цикл.  
- Поле PowerPoint **Delay** соответствует свойству `Effect.Timing.TriggerDelayTime`.  

Как изменить свойства тайминга эффекта:

1. [Применить](#применить-анимацию-к-figure) или получить эффект анимации.  
2. Установить новые значения для нужных свойств `Effect.Timing`.  
3. Сохранить изменённый файл PPTX.  

```python
import aspose.slides as slides

# Создаёт экземпляр класса презентации, представляющего файл презентации.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Получает главную последовательность слайда.
    sequence = pres.slides[0].timeline.main_sequence

    # Получает первый эффект основной последовательности.
    effect = sequence[0]

    # Изменяет TriggerType эффекта, чтобы запускался по щелчку
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Изменяет длительность эффекта
    effect.timing.duration = 3

    # Изменяет TriggerDelayTime эффекта
    effect.timing.trigger_delay_time = 0.5

    # Сохраняет файл PPTX на диск
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Звук эффекта анимации**

Aspose.Slides предоставляет свойства для работы со звуками в эффектах анимации:

- `sound`
- `stop_previous_sound`

### **Добавить звук к эффекту анимации**

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Добавляет аудио в коллекцию аудио презентации
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Получает главную последовательность слайда.
    sequence = first_slide.timeline.main_sequence

    # Получает первый эффект основной последовательности
    first_effect = sequence[0]

    # Проверяет эффект на отсутствие звука
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Добавляет звук к первому эффекту
        first_effect.sound = effect_sound

    # Получает первую интерактивную последовательность слайда.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Устанавливает флаг эффекта "Stop previous sound"
    interactive_sequence[0].stop_previous_sound = True

    # Записывает файл PPTX на диск
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Извлечь звук из эффекта анимации**

1. Создайте экземпляр [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) класса.  
2. Получите ссылку на слайд по его индексу.  
3. Получите главную последовательность эффектов.  
4. Извлеките `sound`, встроенный в каждый эффект анимации.  

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

## **After Animation**

Aspose.Slides для .NET позволяет изменить свойство **After animation** эффекта анимации.

Это панель **Animation Effect** и расширенное меню в Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Список значений выпадающего списка **After animation** в PowerPoint соответствует следующим свойствам:

- Свойство `after_animation_type`, описывающее тип After animation:  
  * PowerPoint **More Colors** соответствует типу [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/);  
  * PowerPoint **Don't Dim** соответствует типу [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) (тип анимации по умолчанию);  
  * PowerPoint **Hide After Animation** соответствует типу [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/);  
  * PowerPoint **Hide on Next Mouse Click** соответствует типу [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/).  
- Свойство `after_animation_color`, определяющее цвет после анимации. Это свойство работает вместе с типом [COLOR]. При изменении типа на другой цвет после анимации будет очищен.  

```python
import aspose.slides as slides

# Создаёт экземпляр класса презентации, представляющего файл презентации
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Получает первый эффект основной последовательности
    first_effect = first_slide.timeline.main_sequence[0]

    # Изменяет тип after animation на Color
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Устанавливает цвет затемнения after animation
    first_effect.after_animation_color.color = Color.alice_blue

    # Записывает файл PPTX на диск
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **Animate Text**

Aspose.Slides предоставляет свойства для работы с блоком *Animate text* эффекта анимации:

- `animate_text_type` — описывает тип анимации текста эффекта. Текст фигуры может анимироваться:  
  * сразу полностью ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/));  
  * по слову ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/));  
  * по букве ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/)).  
- `delay_between_text_parts` — задаёт задержку между анимируемыми частями текста (словами или буквами). Положительное значение указывает процент от длительности эффекта. Отрицательное — задержку в секундах.  

Как изменить свойства *Animate text*:

1. [Применить](#применить-анимацию-к-figure) или получить эффект анимации.  
2. Установить свойство `build_type` в значение [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/), чтобы отключить режим *By Paragraphs*.  
3. Установить новые значения для `animate_text_type` и `delay_between_text_parts`.  
4. Сохранить изменённый файл PPTX.  

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Получает первый эффект основной последовательности
    first_effect = first_slide.timeline.main_sequence[0]

    # Изменяет тип текстовой анимации эффекта на "As One Object"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Изменяет тип Animate text эффекта на "By word"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Устанавливает задержку между словами в 20% длительности эффекта
    first_effect.delay_between_text_parts = 20

    # Записывает файл PPTX на диск
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Как убедиться, что анимации сохраняются при публикации презентации в веб?**  
Экспортируйте в **HTML5** ([Export to HTML5](/slides/ru/python-net/export-to-html5/)) и включите параметры, отвечающие за анимацию фигур ([animate_shapes]) и анимацию переходов ([animate_transitions]). Обычный HTML не воспроизводит анимацию слайдов, а HTML5 — да.

**Как изменение порядка слоёв (z‑order) фигур влияет на анимацию?**  
Порядок слоёв и порядок рисования независимы: эффект управляет временем и типом появления/исчезновения, а z‑order определяет, что покрывает что. Видимый результат формируется их комбинацией. (Это общее поведение PowerPoint; модель Aspose.Slides следует той же логике.)

**Есть ли ограничения при конвертации анимаций в видео для определённых эффектов?**  
В целом анимации поддерживаются ([convert-powerpoint-to-video]), но в редких случаях или для специфических эффектов может произойти иное рендеринг. Рекомендуется тестировать используемые эффекты и версию библиотеки.