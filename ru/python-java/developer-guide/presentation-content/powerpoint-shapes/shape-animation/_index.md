---
title: Применение анимаций фигур в презентациях с использованием Python через Java
linktitle: Анимация фигур
type: docs
weight: 60
url: /ru/python-java/shape-animation/
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
- звуковой эффект
- применить анимацию
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, как добавлять, просматривать и настраивать анимацию фигур, тайминг, звуки, поведение после анимации и анимированный текст с помощью Aspose.Slides для Python через Java."
---
## **Обзор**

Aspose.Slides for Python via Java представляет анимацию слайдов в виде эффектов на временной шкале слайда. Эффект имеет целевую форму, тип анимации и подтип, триггер, настройки времени и необязательные свойства, такие как звук или поведение после анимации.

Временная шкала содержит два типа последовательностей:

- **Главная последовательность** воспроизводится при переходе к следующему слайду.  
- **Интерактивная последовательность** начинается, когда по её триггерной фигуре щёлкнуть.

Поскольку текстовые поля, изображения, диаграммы, таблицы и другие объекты слайда наследуются от [Shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/), вы используете один и тот же метод [Sequence.addEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sequence/#addEffect) для большинства содержимого слайда. Доступные эффекты перечислены в классе [EffectType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/effecttype/).

## **Добавление анимаций фигур**

Чтобы добавить анимацию, получите главную последовательность слайда и вызовите [Sequence.addEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sequence/#addEffect), передав целевую форму, тип эффекта, подтип и триггер. Для эффекта, который начинается при щелчке по другой фигуре, создайте интерактивную последовательность, триггером которой будет эта другая фигура.

Следующий пример создаёт оба типа анимаций и сохраняет результат в файл `shape-animations.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Click to animate this shape")

    main_sequence = slide.getTimeline().getMainSequence()
    entrance_effect = main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    entrance_effect.getTiming().setDuration(1.5)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    presentation.save("shape-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Триггер определяет, когда начинается эффект:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/ru/python-java/aspose.slides/effecttriggertype/#OnClick) ждёт щелчка в главной последовательности или щелчка по триггерной фигуре в интерактивной последовательности.  
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/ru/python-java/aspose.slides/effecttriggertype/#WithPrevious) начинается одновременно с предыдущим эффектом.  
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/ru/python-java/aspose.slides/effecttriggertype/#AfterPrevious) начинается после завершения предыдущего эффекта.

Чтобы анимировать изображение, диаграмму или другой тип фигуры, передайте соответствующий объект в [Sequence.addEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sequence/#addEffect) вместо `target_shape`. Для параметров группировки, специфичных для диаграмм, см. [Animated Charts](/slides/ru/python-java/animated-charts/).

## **Чтение анимаций фигур**

Используйте [Sequence.getEffectsByShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sequence/#getEffectsByShape), когда известна целевая фигура. Чтобы просмотреть каждый эффект, переберите главную последовательность и все интерактивные последовательности. Перебор избавляет от предположения, что в последовательности есть эффект с индексом `0`.

Следующий пример создаёт фигуру с главной и интерактивной анимациями, получает эффекты, направленные на эту фигуру, а затем перебирает все последовательности на слайде.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

def print_sequence(label, sequence):
    print(f"  {label}: {sequence.getCount()} effect(s)")
    for effect in sequence:
        target_shape = effect.getTargetShape()
        target_name = "unknown" if target_shape is None else target_shape.getName()
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        trigger_name = EffectTriggerType.getName(EffectTriggerType.class_, effect.getTiming().getTriggerType())
        effect_description = f"{type_name} {subtype_name}; target: {target_name}; trigger: {trigger_name}"
        print(f"    {effect_description}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Animated shape")

    main_sequence = slide.getTimeline().getMainSequence()
    main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    target_effects = main_sequence.getEffectsByShape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.getName()}.")
    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.getTimeline().getInteractiveSequences(), start=1):
        trigger_shape = sequence.getTriggerShape()
        trigger_name = "unknown" if trigger_shape is None else trigger_shape.getName()
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
finally:
    presentation.dispose()
```

Если нужны эффекты только для одной фигуры, сначала определите её по имени, типу заполнителя или другому стабильному свойству; затем вызовите [Sequence.getEffectsByShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sequence/#getEffectsByShape). Не предполагаете, что [ShapeCollection.get_Item](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#get_Item) с индексом `0` всегда будет нужным объектом.

## **Работа с унаследованными эффектами заполнителей**

Заполнитель на обычном слайде может наследовать анимацию от соответствующего заполнителя на слайде макета и главного слайда. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getBasePlaceholder) возвращает родительский заполнитель или `None`, если родителя нет.

В представлении ниже нижний колонтитул имеет **Random Bars** на обычном слайде, **Split** на слайде макета и **Fly In** на главном слайде.

![Эффект анимации нижнего колонтитула на обычном слайде](slide-shape-animation.png)

![Эффект анимации нижнего колонтитула на слайде макета](layout-shape-animation.png)

![Эффект анимации нижнего колонтитула на главном слайде](master-shape-animation.png)

Следующий пример использует иерархию заполнителей из новой презентации. Он добавляет эффекты к заполнительному объекту мастера, заполнительному объекту макета и соответствующему заполняющему объекту на обычном слайде. Каждый вызов [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getBasePlaceholder) проверяется перед использованием возвращённой фигуры.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, SlideLayoutType

def find_placeholder_with_base(slide, expected_base=None):
    for shape in slide.getShapes():
        base_placeholder = shape.getBasePlaceholder()
        if base_placeholder is not None and (expected_base is None or base_placeholder == expected_base):
            return shape
    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")
    for effect in effects:
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        print(f"  {type_name} {subtype_name}")


presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)
    layout_placeholder = find_placeholder_with_base(layout_slide) if layout_slide is not None else None
    if layout_placeholder is None:
        print("The layout slide does not contain a placeholder linked to its master slide.")
    else:
        master_placeholder = layout_placeholder.getBasePlaceholder()
        layout_slide.getMasterSlide().getTimeline().getMainSequence().addEffect(master_placeholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
        layout_slide.getTimeline().getMainSequence().addEffect(layout_placeholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick)

        slide = presentation.getSlides().addEmptySlide(layout_slide)
        slide_placeholder = find_placeholder_with_base(slide, layout_placeholder)
        if slide_placeholder is None:
            print("The slide does not contain a placeholder linked to its layout slide.")
        else:
            slide.getTimeline().getMainSequence().addEffect(slide_placeholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick)
            slide_effects = slide.getTimeline().getMainSequence().getEffectsByShape(slide_placeholder)
            print_effects("Normal slide", slide_effects)

            base_layout_placeholder = slide_placeholder.getBasePlaceholder()
            if base_layout_placeholder is not None:
                layout_effects = layout_slide.getTimeline().getMainSequence().getEffectsByShape(base_layout_placeholder)
                print_effects("Layout slide", layout_effects)

                base_master_placeholder = base_layout_placeholder.getBasePlaceholder()
                if base_master_placeholder is not None:
                    master_effects = layout_slide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(base_master_placeholder)
                    print_effects("Master slide", master_effects)

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Изменение времени анимации**

Диалог **Timing** в PowerPoint отображает свойства класса [Timing](https://reference.aspose.com/slides/ru/python-java/aspose.slides/timing/).

![Диалог Timing в PowerPoint для анимационного эффекта](shape-animation.png)

- **Start** соответствует [Timing.getTriggerType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/timing/#getTriggerType).  
- **Duration** соответствует [Timing.getDuration](https://reference.aspose.com/slides/ru/python-java/aspose.slides/timing/#getDuration) и измеряется в секундах.  
- **Delay** соответствует [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/ru/python-java/aspose.slides/timing/#getTriggerDelayTime) и измеряется в секундах.  
- **Repeat** соответствует [Timing.getRepeatCount](https://reference.aspose.com/slides/ru/python-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/ru/python-java/aspose.slides/timing/#getRepeatUntilNextClick) или [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/timing/#getRepeatUntilEndSlide).  
- **Rewind when done playing** соответствует [Timing.getRewind](https://reference.aspose.com/slides/ru/python-java/aspose.slides/timing/#getRewind).

Этот самостоятельный пример добавляет эффект, изменяет его тайминг через объект, возвращённый [Sequence.addEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sequence/#addEffect), и сохраняет результат. Сохранение ссылки на возвращённый [Effect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/effect/) избавляет от необходимости использовать индекс коллекции.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Timed animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick)
    effect.getTiming().setDuration(2.0)
    effect.getTiming().setTriggerDelayTime(0.5)
    effect.getTiming().setRepeatUntilNextClick(False)
    effect.getTiming().setRepeatUntilEndSlide(False)
    effect.getTiming().setRepeatCount(2.0)
    effect.getTiming().setRewind(True)

    presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Используйте только один режим повторения. Комбинация количества повторений с флагом «until» может давать запутанные результаты в разных просмотрщиках. При изменении режимов повторения сначала вызывайте [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/ru/python-java/aspose.slides/timing/#setRepeatUntilNextClick) и [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/timing/#setRepeatUntilEndSlide), а затем [Timing.setRepeatCount](https://reference.aspose.com/slides/ru/python-java/aspose.slides/timing/#setRepeatCount), потому что установка любого из флагов также меняет активный режим повторения.

## **Добавление и извлечение звуков анимаций**

Эффект анимации может ссылаться на встроенный аудиофайл через [Effect.getSound](https://reference.aspose.com/slides/ru/python-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/ru/python-java/aspose.slides/effect/#setStopPreviousSound) указывает эффекту остановить звук, начатый предыдущим эффектом.

### **Добавить звук к эффекту**

Следующий пример ожидает локальный аудиофайл `animation-sound.wav`. Он создаёт два эффекта, внедряет этот файл как звук для первого эффекта и настраивает второй эффект на остановку звука. При этом используются объекты, возвращённые [Sequence.addEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sequence/#addEffect), поэтому индекс последовательности не требуется.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80)
    first_shape.addTextFrame("Starts sound")
    second_shape.addTextFrame("Stops sound")

    sequence = slide.getTimeline().getMainSequence()
    first_effect = sequence.addEffect(first_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    second_effect = sequence.addEffect(second_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    audio_data = Path("animation-sound.wav").read_bytes()
    effect_sound = presentation.getAudios().addAudio(jpype.JArray(jpype.JByte)(audio_data))
    first_effect.setSound(effect_sound)
    second_effect.setStopPreviousSound(True)

    presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Извлечь встроенные звуки эффектов**

Следующий пример ожидает локальную презентацию `presentation-with-animation-sounds.pptx`. Он просматривает как главные, так и интерактивные последовательности и записывает каждый встроенный звук эффекта в каталог `extracted-animation-sounds`. Расширение выбирается на основе MIME‑типа аудио, полученного через [Audio.getContentType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/audio/#getContentType).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path

def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else str(content_type).lower()
    if normalized_type == "audio/mpeg":
        return ".mp3"
    if normalized_type == "audio/mp4":
        return ".m4a"
    if normalized_type == "audio/ogg":
        return ".ogg"
    if normalized_type in ("audio/wav", "audio/x-wav"):
        return ".wav"
    return ".bin"


def save_sounds(sequence, output_directory, sound_index):
    for effect in sequence:
        sound = effect.getSound()
        if sound is None:
            continue
        extension = get_audio_extension(sound.getContentType())
        output_path = output_directory / f"effect-sound-{sound_index}{extension}"
        audio_data = bytes(sound.getBinaryData())
        output_path.write_bytes(audio_data)
        sound_index += 1
    return sound_index


input_path = Path("presentation-with-animation-sounds.pptx")
output_directory = Path("extracted-animation-sounds")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation(str(input_path))
try:
    sound_index = 1
    for slide in presentation.getSlides():
        sound_index = save_sounds(slide.getTimeline().getMainSequence(), output_directory, sound_index)
        for sequence in slide.getTimeline().getInteractiveSequences():
            sound_index = save_sounds(sequence, output_directory, sound_index)
    print(f"Extracted {sound_index - 1} sound file(s) to {output_directory.resolve()}.")
finally:
    presentation.dispose()
```

Для больших аудиообъектов используйте [Audio.getStream](https://reference.aspose.com/slides/ru/python-java/aspose.slides/audio/#getStream) и копируйте поток в файл вместо загрузки всего объекта в массив байтов.

## **Установка поведения после анимации**

Опция **After animation** определяет, что происходит с фигурой после завершения её эффекта.

![Диалог параметров эффекта PowerPoint, показывающий настройки After animation](shape-after-animation.png)

Класс [AfterAnimationType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/afteranimationtype/) поддерживает варианты: оставить фигуру без изменений, изменить её цвет, скрыть после анимации или скрыть при следующем щелчке. Когда тип установлен в [AfterAnimationType.Color](https://reference.aspose.com/slides/ru/python-java/aspose.slides/afteranimationtype/#Color), также задайте [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/effect/#getAfterAnimationColor).

Этот самостоятельный пример создаёт эффект, задаёт его поведение после анимации через возвращённый объект эффекта и сохраняет результат.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AfterAnimationType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Dim after animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.setAfterAnimationType(AfterAnimationType.Color)
    effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY)

    presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Изменение типа с [AfterAnimationType.Color](https://reference.aspose.com/slides/ru/python-java/aspose.slides/afteranimationtype/#Color) очищает настройку цвета после анимации.

## **Анимация текста**

Анимация текста имеет два связанных параметра:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textanimation/#getBuildType) управляет тем, появляются ли абзацы одновременно или по отдельности.  
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/effect/#getAnimateTextType) определяет, появляется ли текст сразу, по словам или по буквам. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/effect/#getDelayBetweenTextParts) задаёт задержку между словами или буквами. Положительное значение — процент от длительности эффекта; отрицательное — задержка в секундах.

Следующий самостоятельный пример анимирует отдельные слова в текстовом поле. [BuildType.AsOneObject](https://reference.aspose.com/slides/ru/python-java/aspose.slides/buildtype/#AsOneObject) отключает построение по абзацам, поэтому настройка по словам применяется ко всему текстовому фрейму.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AnimateTextType, BuildType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100)
    text_box.addTextFrame("Aspose.Slides animates this sentence word by word.")

    effect = slide.getTimeline().getMainSequence().addEffect(text_box, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTextAnimation().setBuildType(BuildType.AsOneObject)
    effect.setAnimateTextType(AnimateTextType.ByWord)
    effect.setDelayBetweenTextParts(20.0)

    presentation.save("animated-text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Чтобы построить текстовое поле по абзацам, установите [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/ru/python-java/aspose.slides/buildtype/#ByLevelParagraphs1) (или другой уровень абзаца). Чтобы задать отдельный эффект для конкретного абзаца, используйте перегрузку [Sequence.addEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sequence/#addEffect), принимающую объект [Paragraph](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/). Смотрите [Animated Text](/slides/ru/python-java/animated-text/) для примеров на уровне абзаца.

## **Экспорт и примечания о совместимости**

- Сохранение в PPT или PPTX сохраняет модель анимации, но окончательное воспроизведение контролируется просмотрщиком презентаций.  
- PDF и статические изображения не воспроизводят анимацию. Используйте [HTML5 export](/slides/ru/python-java/export-to-html5/), анимированный GIF или [video conversion](/slides/ru/python-java/convert-powerpoint-to-video/), когда необходимо показать движение.  
- Для HTML5 включите [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/html5options/#setAnimateShapes) и, при необходимости, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/html5options/#setAnimateTransitions).  
- При рендеринге видео поддерживаются многие распространённые эффекты входа, акцента, выхода и движения, но не каждый эффект PowerPoint поддерживается. Проверьте текущий список [supported animations and effects](/slides/ru/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) и протестируйте критически важные презентации с вашей целевой версией Aspose.Slides.  
- Пользовательские сложные эффекты и эффекты, импортированные из других форматов, могут сохраняться в файле, но отображаться иначе в PowerPoint, HTML5 или видео. Проверяйте экспортированный результат, а не только название эффекта.

## **FAQ**

**Почему анимация видна в PowerPoint, но не отображается в PDF?**  
PDF — статический формат, поэтому анимации и переходы слайдов не воспроизводятся. Экспортируйте в HTML5, анимированный GIF или видео, если требуется сохранить движение.

**Почему эффект воспроизводится иначе в видео?**  
Экспорт в видео рендерит анимацию, а не сохраняет оригинальное поведение PowerPoint. Некоторые продвинутые эффекты не поддерживаются или упрощаются. Ознакомьтесь с таблицей поддерживаемых эффектов и протестируйте реальную презентацию перед использованием в продакшене.

**Изменяет ли перемещение фигуры вперёд или назад порядок её анимации?**  
Нет. Порядок наложения фигур (z‑order) управляет перекрытием, а порядок последовательностей и триггеров — воспроизведением анимаций. Меняйте временную шкалу, если нужен иной порядок воспроизведения.