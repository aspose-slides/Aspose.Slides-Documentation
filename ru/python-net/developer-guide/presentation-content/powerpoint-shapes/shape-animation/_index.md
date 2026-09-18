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
description: "Узнайте, как добавлять, просматривать и настраивать анимации фигур, время, звуки, поведение после анимации и анимированный текст с помощью Aspose.Slides for Python via .NET."
---
## **Обзор**

Чтобы работать с отдельными поведениями внутри эффекта или редактировать сегменты траектории движения, см. [Custom Animation](/slides/ru/python-net/custom-animation/).

Aspose.Slides for Python via .NET представляет анимацию слайдов как эффекты во временной шкале слайда. Эффект имеет целевую форму, тип и подтип анимации, триггер, настройки времени и необязательные свойства, такие как звук или поведение после анимации.

Во временной шкале есть два типа последовательностей:

- **main sequence** воспроизводится при переходе к следующему слайду.
- **interactive sequence** начинается, когда по её триггерной форме выполняется щелчок.

Поскольку текстовые поля, изображения, диаграммы, таблицы и другие объекты слайда реализуют [IShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ishape/), вы используете один и тот же метод [Sequence.add_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/sequence/add_effect/) для большинства содержимого слайда. Доступные эффекты перечислены в перечислении [EffectType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/effecttype/).

## **Добавление анимаций форм**

Чтобы добавить анимацию, получите основную последовательность слайда и вызовите [Sequence.add_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/sequence/add_effect/) с целевой формой, типом эффекта, подтипом и триггером. Для эффекта, который начинается при щелчке по другой форме, создайте интерактивную последовательность, триггером которой будет эта другая форма.

В следующем примере создаются оба типа анимации и результат сохраняется в файл `shape-animations.pptx`.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Click to animate this shape"

    main_sequence = slide.timeline.main_sequence
    entrance_effect = main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    entrance_effect.timing.duration = 1.5

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    presentation.save("shape-animations.pptx", slides.export.SaveFormat.PPTX)
```

Триггер определяет, когда эффект начинается:

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/effecttriggertype/) ждёт щелчка в основной последовательности или щелчка по триггерной форме в интерактивной последовательности.
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/effecttriggertype/) начинается одновременно с предыдущим эффектом.
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/effecttriggertype/) начинается после завершения предыдущего эффекта.

Чтобы анимировать изображение, диаграмму или другую форму, передайте соответствующий объект в [Sequence.add_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/sequence/add_effect/) вместо `target_shape`. Для параметров группировки, специфичных для диаграмм, см. [Animated Charts](/slides/ru/python-net/animated-charts/).

## **Чтение анимаций форм**

Используйте [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/sequence/get_effects_by_shape/), когда известна целевая форма. Чтобы просмотреть каждый эффект, пройдитесь по основной последовательности и по всем интерактивным последовательностям. Итерация избавляет от предположения, что в последовательности есть эффект под индексом `0`.

В следующем примере создаётся форма с эффектами основной и интерактивной последовательностей, получаются эффекты, направленные на форму, и затем перебираются все последовательности на слайде.

```python
import aspose.slides as slides


def print_sequence(label, sequence):
    print(f"  {label}: {sequence.count} effect(s)")

    for effect in sequence:
        target_name = "unknown" if effect.target_shape is None else effect.target_shape.name
        effect_description = f"{effect.type.name} {effect.subtype.name}; target: {target_name}; trigger: {effect.timing.trigger_type.name}"
        print(f"    {effect_description}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Animated shape"

    main_sequence = slide.timeline.main_sequence
    main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    target_effects = main_sequence.get_effects_by_shape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.name}.")

    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.timeline.interactive_sequences, start=1):
        trigger_name = "unknown" if sequence.trigger_shape is None else sequence.trigger_shape.name
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
```

Если вам нужны эффекты только для одной формы, сначала определите форму по имени, типу заполнителя или другому стабильному свойству; затем вызовите [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/sequence/get_effects_by_shape/). Не рассчитывайте, что форма под индексом `0` всегда будет нужным объектом.

## **Работа с унаследованными эффектами заполнителей**

Заполнитель на обычном слайде может наследовать поведение анимации от соответствующего заполнителя на слайде макета и главном слайде. [Shape.get_base_placeholder](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/get_base_placeholder/) возвращает родительский заполнитель, или `None`, если родитель отсутствует.

В представлении примера ниже нижний колонтитул имеет **Random Bars** на обычном слайде, **Split** на слайде макета и **Fly In** на главном слайде.

![Эффект анимации нижнего колонтитула на обычном слайде](slide-shape-animation.png)

![Эффект анимации заполнителя нижнего колонтитула на слайде макета](layout-shape-animation.png)

![Эффект анимации заполнителя нижнего колонтитула на главном слайде](master-shape-animation.png)

Следующий пример самостоятельно строит иерархию заполнителей. Он добавляет эффекты к заполнителю в мастер‑шаблоне, заполнителю в макете и соответствующему заполнителю на обычном слайде. Каждый вызов [Shape.get_base_placeholder](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/get_base_placeholder/) проверяется перед использованием возвращённой формы.

```python
import aspose.slides as slides


def find_placeholder_with_base(slide):
    for shape in slide.shapes:
        if shape.get_base_placeholder() is not None:
            return shape

    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")

    for effect in effects:
        print(f"  {effect.type.name} {effect.subtype.name}")


with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_placeholder = layout_slide.placeholder_manager.add_text_placeholder(100, 100, 400, 80)
    layout_slide.timeline.main_sequence.add_effect(layout_placeholder, slides.animation.EffectType.SPLIT, slides.animation.EffectSubtype.VERTICAL_IN, slides.animation.EffectTriggerType.ON_CLICK)

    master_placeholder = layout_placeholder.get_base_placeholder()
    if master_placeholder is not None:
        master_sequence = layout_slide.master_slide.timeline.main_sequence
        master_sequence.add_effect(master_placeholder, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.BOTTOM, slides.animation.EffectTriggerType.ON_CLICK)

    slide = presentation.slides.add_empty_slide(layout_slide)
    slide_placeholder = find_placeholder_with_base(slide)

    if slide_placeholder is None:
        raise RuntimeError("The slide does not contain a placeholder linked to its layout slide.")

    slide.timeline.main_sequence.add_effect(slide_placeholder, slides.animation.EffectType.RANDOM_BARS, slides.animation.EffectSubtype.HORIZONTAL, slides.animation.EffectTriggerType.ON_CLICK)
    print_effects("Normal slide", slide.timeline.main_sequence.get_effects_by_shape(slide_placeholder))

    base_layout_placeholder = slide_placeholder.get_base_placeholder()
    if base_layout_placeholder is not None:
        print_effects("Layout slide", layout_slide.timeline.main_sequence.get_effects_by_shape(base_layout_placeholder))

        base_master_placeholder = base_layout_placeholder.get_base_placeholder()
        if base_master_placeholder is not None:
            print_effects("Master slide", layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(base_master_placeholder))

    presentation.save("placeholder-animations.pptx", slides.export.SaveFormat.PPTX)
```

## **Изменение времени анимации**

Диалог **Timing** в PowerPoint соответствует свойствам [Timing](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/timing/).

![Диалог Timing в PowerPoint для анимационного эффекта](shape-animation.png)

- **Start** соответствует [Timing.trigger_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/timing/trigger_type/).
- **Duration** соответствует [Timing.duration](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/timing/duration/), указывается в секундах.
- **Delay** соответствует [Timing.trigger_delay_time](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/timing/trigger_delay_time/), указывается в секундах.
- **Repeat** соответствует [Timing.repeat_count](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/timing/repeat_count/), [Timing.repeat_until_next_click](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/timing/repeat_until_next_click/) или [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/timing/repeat_until_end_slide/).
- **Rewind when done playing** соответствует [Timing.rewind](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/timing/rewind/).

Этот независимый пример добавляет эффект, меняет его время через объект, возвращаемый [Sequence.add_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/sequence/add_effect/), и сохраняет результат. Сохранение ссылки на возвращённый [Effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/effect/) избавляет от необходимости использовать индекс коллекции.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Timed animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK
    effect.timing.duration = 2.0
    effect.timing.trigger_delay_time = 0.5
    effect.timing.repeat_until_next_click = False
    effect.timing.repeat_until_end_slide = False
    effect.timing.repeat_count = 2.0
    effect.timing.rewind = True

    presentation.save("shape-animation-timing.pptx", slides.export.SaveFormat.PPTX)
```

Используйте один режим повторения целенаправленно. Сочетание количества повторений с флагом «until» может давать неоднозначные результаты в разных средствах просмотра. При изменении режимов повторения сначала задайте [Timing.repeat_until_next_click](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/timing/repeat_until_next_click/) и [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/timing/repeat_until_end_slide/), а затем [Timing.repeat_count](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/timing/repeat_count/), так как установка любого из флагов также меняет активный режим повторения.

## **Добавление и извлечение звуков анимации**

Эффект анимации может ссылаться на встроенный аудиофайл через [Effect.sound](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/effect/sound/). [Effect.stop_previous_sound](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/effect/stop_previous_sound/) указывает эффекту остановить звук, запущенный предыдущим эффектом.

### **Добавление звука к эффекту**

В следующем примере ожидается локальный аудиофайл `animation-sound.wav`. Создаются два эффекта, первый получает этот файл в качестве звука, второй настроен на остановку звука. Используются объекты, возвращаемые [Sequence.add_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/sequence/add_effect/), поэтому индекс последовательности не требуется.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 100, 240, 80)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 400, 100, 240, 80)
    first_shape.text_frame.text = "Starts sound"
    second_shape.text_frame.text = "Stops sound"

    sequence = slide.timeline.main_sequence
    first_effect = sequence.add_effect(first_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    second_effect = sequence.add_effect(second_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    with open("animation-sound.wav", "rb") as audio_file:
        effect_sound = presentation.audios.add_audio(audio_file.read())

    first_effect.sound = effect_sound
    second_effect.stop_previous_sound = True

    presentation.save("shape-animation-sound.pptx", slides.export.SaveFormat.PPTX)
```

### **Извлечение встроенных звуков эффектов**

В следующем примере ожидается локальная презентация `presentation-with-animation-sounds.pptx`. Он сканирует основные и интерактивные последовательности и записывает каждый встроенный звук эффекта в каталог `extracted-animation-sounds`. Расширение выбирается исходя из MIME‑типа аудио, получаемого через [Audio.content_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/audio/content_type/).

```python
import os

import aspose.slides as slides


def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else content_type.lower()

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
        if effect.sound is None:
            continue

        extension = get_audio_extension(effect.sound.content_type)
        output_path = os.path.join(output_directory, f"effect-sound-{sound_index}{extension}")
        with open(output_path, "wb") as output_file:
            output_file.write(bytes(effect.sound.binary_data))
        sound_index += 1

    return sound_index


input_path = "presentation-with-animation-sounds.pptx"
output_directory = "extracted-animation-sounds"

os.makedirs(output_directory, exist_ok=True)

with slides.Presentation(input_path) as presentation:
    sound_index = 1

    for slide in presentation.slides:
        sound_index = save_sounds(slide.timeline.main_sequence, output_directory, sound_index)

        for sequence in slide.timeline.interactive_sequences:
            sound_index = save_sounds(sequence, output_directory, sound_index)

print(f"Extracted {sound_index - 1} sound file(s) to {os.path.abspath(output_directory)}.")
```

Для больших аудиофайлов используйте [Audio.get_stream](https://reference.aspose.com/slides/ru/python-net/aspose.slides/audio/get_stream/) и копируйте поток в файл вместо загрузки всего объекта в массив байтов.

## **Установка поведения после анимации**

Параметр **After animation** определяет, что произойдёт с формой после завершения её эффекта.

![Диалог параметров эффекта PowerPoint, показывающий настройки After animation](shape-after-animation.png)

Перечисление [AfterAnimationType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/afteranimationtype/) поддерживает оставление формы без изменений, изменение её цвета, скрытие после анимации или скрытие при следующем щелчке. Когда тип установлен в [AfterAnimationType.COLOR](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/afteranimationtype/), также задайте [Effect.after_animation_color](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/effect/after_animation_color/).

Этот независимый пример создаёт эффект, задаёт ему поведение после анимации через полученный объект эффекта и сохраняет результат.

```python
import aspose.pydrawing as draw
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Dim after animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.after_animation_type = slides.animation.AfterAnimationType.COLOR
    effect.after_animation_color.color = draw.Color.light_gray

    presentation.save("shape-animation-after-effect.pptx", slides.export.SaveFormat.PPTX)
```

Изменение типа с [AfterAnimationType.COLOR](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/afteranimationtype/) удаляет установленный цвет после анимации.

## **Анимация текста**

У анимации текста два связанных параметра:

- [TextAnimation.build_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/textanimation/build_type/) определяет, появляются ли абзацы одновременно или последовательно.
- [Effect.animate_text_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/effect/animate_text_type/) определяет, появляется ли текст целиком, по словам или по буквам. [Effect.delay_between_text_parts](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/effect/delay_between_text_parts/) задаёт задержку между словами или буквами. Положительное значение — процент от длительности эффекта; отрицательное — задержка в секундах.

В следующем независимом примере анимируются слова в текстовом поле. [BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/buildtype/) отключает построение абзац за абзацем, так что настройка для слова применяется ко всему текстовому фрейму.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 560, 100)
    text_box.text_frame.text = "Aspose.Slides animates this sentence word by word."

    effect = slide.timeline.main_sequence.add_effect(text_box, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT
    effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD
    effect.delay_between_text_parts = 20.0

    presentation.save("animated-text.pptx", slides.export.SaveFormat.PPTX)
```

Чтобы построить текстовое поле по абзацам, задайте [BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/buildtype/) (или другой уровень абзаца). Чтобы применить отдельный эффект к отдельному абзацу, используйте перегрузку [Sequence.add_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/sequence/add_effect/), принимающую [IParagraph](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iparagraph/). См. [Animated Text](/slides/ru/python-net/animated-text/) для примеров уровня абзаца.

## **Экспорт и замечания о совместимости**

- Сохранение в PPT или PPTX сохраняет модель анимации, но окончательное воспроизведение контролируется средой просмотра презентации.
- PDF и статические изображения не воспроизводят анимацию. Используйте [HTML5 export](/slides/ru/python-net/export-to-html5/), анимированный GIF или [video conversion](/slides/ru/python-net/convert-powerpoint-to-video/), если требуется показать движение.
- Для HTML5 включите [Html5Options.animate_shapes](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/html5options/animate_shapes/) и, при необходимости, [Html5Options.animate_transitions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/html5options/animate_transitions/).
- При рендеринге видео поддерживается множество типичных эффектов входа, акцента, выхода и траекторий движения, но не каждый эффект PowerPoint поддерживается. Проверьте текущий список [supported animations and effects](/slides/ru/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) и протестируйте критические презентации с вашей целевой версией Aspose.Slides.
- Сложные пользовательские эффекты и эффекты, импортированные из других форматов презентаций, могут сохраняться в файле, но отображаться иначе в PowerPoint, HTML5 или видео. Проводите проверку экспортированного результата, а не полагайтесь только на название эффекта.

## **FAQ**

**Почему анимация отображается в PowerPoint, но не в PDF?**

PDF — статический формат, поэтому анимация и переходы слайдов не воспроизводятся. Экспортируйте в HTML5, анимированный GIF или видео, если требуется сохранить движение.

**Почему эффект выглядит иначе в видео?**

При экспорте в видео анимация рендерится, а не сохраняется оригинальное поведение PowerPoint. Некоторые сложные эффекты не поддерживаются или приближенно имитируются. Ознакомьтесь с таблицей поддерживаемых эффектов и протестируйте презентацию перед производством.

**Изменяет ли перемещение формы вперёд или назад порядок её анимации?**

Нет. Порядок наложения (z‑order) управляет перекрытием, а порядок последовательностей и триггеры — воспроизведением анимации. Изменяйте временную шкалу, если нужен иной порядок воспроизведения.