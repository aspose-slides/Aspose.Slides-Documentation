---
title: Анимация форм
type: docs
weight: 60
url: /ru/python-net/shape-animation/
keywords: "анимация PowerPoint, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Создайте анимацию PowerPoint на Python"
---

Анимации — это визуальные эффекты, которые можно применить к текстам, изображениям, формам или [диаграммам](/slides/ru/python-net/animated-charts/). Они оживляют презентации или их элементы.

### **Зачем использовать анимации в презентациях?**

Используя анимации, вы можете

* контролировать поток информации
* подчеркивать важные моменты
* увеличить интерес или участие вашей аудитории
* облегчить восприятие или усвоение контента
* привлечь внимание ваших читателей или зрителей к важным частям презентации

PowerPoint предоставляет множество вариантов и инструментов для анимаций и анимационных эффектов в категориях **вход**, **выход**, **акцент** и **движущиеся пути**.

### **Анимации в Aspose.Slides**

* Aspose.Slides предоставляет классы и типы, необходимые для работы с анимациями в пространстве имен [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/),
* Aspose.Slides предоставляет более **150 анимационных эффектов** в перечислении [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/). Эти эффекты в основном аналогичны эффектам, используемым в PowerPoint.

## **Применить анимацию к текстовому полю**

Aspose.Slides для Python через .NET позволяет вам применять анимацию к тексту в форме.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд через его индекс.
3. Добавьте `прямоугольник` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/). 
4. Добавьте текст в `IAutoShape.TextFrame`.
5. Получите основную последовательность эффектов.
6. Добавьте анимационный эффект к [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/). 
7. Установите свойство`TextAnimation.BuildType` в значение из перечисления `BuildType`.
8. Запишите презентацию на диск в виде файла PPTX.

Этот код на Python показывает, как применить эффект `Fade` к AutoShape и установить анимацию текста на значение *По 1-му уровню абзацев*:

```python
import aspose.slides as slides

# Создает экземпляр класса презентации, представляющего файл презентации.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Добавляет новую AutoShape с текстом
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "Первый абзац \nВторой абзац \n Третий абзац"

    # Получает основную последовательность слайда.
    sequence = sld.timeline.main_sequence

    # Добавляет эффект анимации Fade к форме
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Анимирует текст формы по 1-му уровню абзацев
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Сохраняет файл PPTX на диск
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

Кроме применения анимаций к тексту, вы также можете применять анимации к одному [абзацу](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/). Смотрите [**Анимированный текст**](/slides/ru/python-net/animated-text/).

{{% /alert %}} 

## **Применить анимацию к PictureFrame**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд через его индекс.
3. Добавьте или получите [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) на слайде. 
4. Получите основную последовательность эффектов.
5. Добавьте анимационный эффект к [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).
6. Запишите презентацию на диск в виде файла PPTX.

Этот код на Python показывает, как применить эффект `Fly` к рамке изображения:

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Создает экземпляр класса презентации, представляющего файл презентации.
with slides.Presentation() as pres:
    # Загружает изображение для добавления в коллекцию изображений презентации
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Добавляет рамку изображения на слайд
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Получает основную последовательность слайда.
    sequence = pres.slides[0].timeline.main_sequence

    # Добавляет эффект анимации Fly слева к рамке изображения
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Сохраняет файл PPTX на диск
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Применить анимацию к форме**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд через его индекс.
3. Добавьте `прямоугольник` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/). 
4. Добавьте [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) с `Bevel` (когда на этот объект нажимают, воспроизводится анимация).
5. Создайте последовательность эффектов на форме с закругленными углами.
6. Создайте пользовательский `UserPath`.
7. Добавьте команды для перемещения к `UserPath`.
8. Запишите презентацию на диск в виде файла PPTX.

Этот код на Python показывает, как применить эффект `PathFootball` (футбольная траектория) к форме:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Создает экземпляр класса Презентации, представляющего файл PPTX
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Создает эффект PathFootball для существующей формы с нуля.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Анимированное текстовое поле")

    # Добавляет эффект анимации PathFootball.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Создает нечто вроде "кнопки".
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Создает последовательность эффектов для кнопки.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Создает пользовательский путь. Наш объект будет перемещен только после нажатия кнопки.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Добавляет команды для перемещения, так как созданный путь пуст.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # Записывает файл PPTX на диск
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Получить примененные эффекты анимации к форме**

Вы можете решить узнать все анимационные эффекты, примененные к одной форме.

Этот код на Python показывает, как получить все эффекты, примененные к конкретной форме:

```python
import aspose.slides as slides

# Создает экземпляр класса презентации, представляющего файл презентации.
with slides.Presentation("AnimExample_out.pptx") as pres:
    firstSlide = pres.slides[0]

    # Получает основную последовательность слайда.
    sequence = firstSlide.timeline.main_sequence

    # Получает первую форму на слайде.
    shape = firstSlide.shapes[0]

    # Получает все анимационные эффекты, примененные к форме.
    shapeEffects = sequence.get_effects_by_shape(shape)

    if len(shapeEffects) > 0:
        print("Форма " + shape.name + " имеет " + str(len(shapeEffects)) + " анимационных эффектов.")
```

## **Изменить свойства времени анимационного эффекта**

Aspose.Slides для Python через .NET позволяет вам изменять свойства времени анимационного эффекта.

Это панель времени анимации в Microsoft PowerPoint:

![example1_image](shape-animation.png)

Вот соответствия между временем PowerPoint и свойствами `Effect.Timing`:

- Выпадающий список времени PowerPoint **Начало** соответствует свойству [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/). 
- **Продолжительность** времени PowerPoint соответствует свойству `Effect.Timing.Duration`. Продолжительность анимации (в секундах) — это общее время, необходимое для завершения анимации в одном цикле. 
- **Задержка** времени PowerPoint соответствует свойству `Effect.Timing.TriggerDelayTime`. 

Вот как изменить свойства времени эффекта:

1. [Примените](#apply-animation-to-shape) или получите анимационный эффект.
2. Установите новые значения для необходимых вам свойств `Effect.Timing`. 
3. Сохраните измененный файл PPTX.

Этот код на Python иллюстрирует операцию:

```python
import aspose.slides as slides

# Создает экземпляр класса презентации, представляющего файл презентации.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Получает основную последовательность слайда.
    sequence = pres.slides[0].timeline.main_sequence

    # Получает первый эффект основной последовательности.
    effect = sequence[0]

    # Изменяет тип триггера эффекта на начало по клику
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Изменяет продолжительность эффекта
    effect.timing.duration = 3

    # Изменяет задержку триггера эффекта
    effect.timing.trigger_delay_time = 0.5

    # Сохраняет файл PPTX на диск
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Звук анимационного эффекта**

Aspose.Slides предоставляет эти свойства для работы со звуками в анимационных эффектах: 

- `sound`
- `stop_previous_sound`

### **Добавить звук анимационного эффекта**

Этот код на Python показывает, как добавить звук анимационного эффекта и остановить его, когда начинается следующий эффект:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Добавляет аудио в коллекцию аудио презентации
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Получает основную последовательность слайда.
    sequence = first_slide.timeline.main_sequence

    # Получает первый эффект основной последовательности
    first_effect = sequence[0]

    # Проверяет эффект на "Без звука"
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Добавляет звук для первого эффекта
        first_effect.sound = effect_sound

    # Получает первую интерактивную последовательность слайда.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Устанавливает флаг "Остановить предыдущий звук" для эффекта
    interactive_sequence[0].stop_previous_sound = True

    # Записывает файл PPTX на диск
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Извлечь звук анимационного эффекта**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд через его индекс. 
3. Получите основную последовательность эффектов. 
4. Извлеките `sound`, встроенный в каждый анимационный эффект. 

Этот код на Python показывает, как извлечь звук, встроенный в анимационный эффект:

```python
import aspose.slides as slides

# Создает экземпляр класса презентации, представляющего файл презентации.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # Получает основную последовательность слайда.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # Извлекает звук эффекта в байтовый массив
        audio = effect.sound.binary_data
```

## **После анимации**

Aspose.Slides для .NET позволяет вам изменять свойства после анимации анимационного эффекта.

Это панель эффектов анимации и расширенное меню в Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Выпадающий список **После анимации** эффекта PowerPoint соответствует следующим свойствам: 

- свойство `after_animation_type`, которое описывает тип после анимации :
  * **Дополнительные цвета** PowerPoint соответствует типу [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/);
  * элемент списка **Не затемнять** PowerPoint соответствует типу [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) (тип после анимации по умолчанию);
  * элемент **Скрыть после анимации** PowerPoint соответствует типу [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/);
  * элемент **Скрыть при следующем щелчке мыши** PowerPoint соответствует типу [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/);
- свойство `after_animation_color`, которое определяет формат цвета после анимации. Это свойство работает в совокупности с типом [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/). Если вы измените тип на другой, цвет после анимации будет очищен.

Этот код на Python показывает, как изменить эффект после анимации:

```python
import aspose.slides as slides

# Создает экземпляр класса презентации, представляющего файл презентации
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Получает первый эффект основной последовательности
    first_effect = first_slide.timeline.main_sequence[0]

    # Изменяет тип после анимации на Цвет
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Устанавливает цвет затемнения после анимации
    first_effect.after_animation_color.color = Color.alice_blue

    # Записывает файл PPTX на диск
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **Анимировать текст**

Aspose.Slides предоставляет эти свойства для работы с блоком *Анимировать текст* анимационного эффекта:

- `animate_text_type`, который описывает тип анимации текста эффекта. Текст формы может быть анимирован:
  - Все сразу ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) тип)
  - По словам ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) тип)
  - По буквам ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) тип)
- `delay_between_text_parts` устанавливает задержку между анимированными частями текста (словами или буквами). Положительное значение указывает процент от продолжительности эффекта. Отрицательное значение указывает задержку в секундах.

Вот как вы можете изменить свойства анимации текста эффекта:

1. [Примените](#apply-animation-to-shape) или получите анимационный эффект.
2. Установите свойство `build_type` в значение [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/), чтобы отключить режим анимации *По абзацам*.
3. Установите новые значения для свойств `animate_text_type` и `delay_between_text_parts`.
4. Сохраните измененный файл PPTX.

Этот код на Python демонстрирует операцию:

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Получает первый эффект основной последовательности
    first_effect = first_slide.timeline.main_sequence[0]

    # Изменяет тип анимации текста эффекта на "Как один объект"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Изменяет тип анимации текста эффекта на "По словам"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Устанавливает задержку между словами в 20% от продолжительности эффекта
    first_effect.delay_between_text_parts = 20

    # Записывает файл PPTX на диск
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```