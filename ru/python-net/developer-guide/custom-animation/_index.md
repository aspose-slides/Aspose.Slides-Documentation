---
title: Создание и изменение пользовательских анимационных поведений в Python
linktitle: Пользовательская анимация
type: docs
weight: 151
url: /ru/python-net/custom-animation/
keywords:
- пользовательская анимация
- поведение анимации
- путь движения
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Создавайте, просматривайте и изменяйте пользовательские анимационные поведения и редактируемые пути движения в презентациях PowerPoint с помощью Aspose.Slides для Python через .NET."
---
## **Обзор**

Пользовательские анимационные поведения позволяют управлять отдельными операциями внутри анимационного эффекта, такими как изменение цвета, вращение фигуры или следование по редактируемому пути движения. Это руководство показывает, как создавать и комбинировать поведения, настраивать их време́ни, просматривать и изменять существующие анимации и проверять, сохраняются ли их свойства при сохранении и повторном открытии презентации.

Для предопределённых эффектов и триггеров клика см. [Анимация фигур](/slides/ru/python-net/shape-animation/).

## **Понимание модели анимации**

Анимация организована как **Timeline → Sequence → Effect → Behaviors**:

- [timeline]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseslide/timeline/) слайда содержит основную последовательность и интерактивные последовательности.
- [Sequence]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/sequence/) содержит эффекты, потенциально направленные на разные фигуры.
- [Effect]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/effect/) определяет целевую фигуру, предустановку, подтип и временные параметры эффекта.
- [Effect.behaviors]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/effect/behaviors/) содержит операции, реализующие эффект: изменение цвета, перемещение, вращение, установка свойства и др.

## **Создание отдельных поведений**

Вызовите [Sequence.add_effect]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/sequence/add_effect/) для создания эффекта и доступа к его коллекции [behaviors]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/effect/behaviors/). Предустановка может автоматически заполнить эту коллекцию. Сохраняйте её операции при расширении предустановки или используйте [clear]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/behaviorcollection/clear/) при намеренной замене.

[BehaviorFactory]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/behaviorfactory/) создаёт восемь типов поведения, показанных ниже. Движение рассматривается в разделе [Создание пути движения](#build-a-motion-path). Каждый пример создания — полная программа; последующие примеры редактирования указывают, какой файл вывода они используют.

### **Вращение**

Используйте [create_rotation_effect]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/behaviorfactory/create_rotation_effect/) для создания вращения. [by]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/rotationeffect/by/) задаёт относительный угол в градусах; [from_address]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/rotationeffect/from_address/) и [to]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/rotationeffect/to/) задают конечные точки.

Пример начинается с эффекта Spin, заменяет его предустановленные операции одним поведением вращения и задаёт этому действию продолжительность две секунды. Относительный угол 90 ° выражает четверть оборота от исходной ориентации фигуры, поэтому отдельный начальный угол не нужен.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.SPIN, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    rotation = factory.create_rotation_effect()
    rotation.by = 90
    rotation.timing.duration = 2

    effect.behaviors.add(rotation)

    presentation.save("rotation.pptx", slides.export.SaveFormat.PPTX)
```

`rotation.pptx` содержит одну фигуру и одно поведение вращения. Примеры коллекции, тайминга и редактирования вращения ниже используют этот файл.

### **Масштабирование**

Используйте [create_scale_effect]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/behaviorfactory/create_scale_effect/) с процентами X/Y: [from_address]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/scaleeffect/from_address/) и [to]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/scaleeffect/to/) описывают начальный и конечный размер, а [by]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/scaleeffect/by/) — относительное изменение. Здесь 100 % означает исходный размер.

Пример увеличивает оба измерения с 100 % до 125 % за две секунды. Использование одинаковых горизонтальных и вертикальных процентов сохраняет пропорции фигуры; разные проценты растягивают одну из сторон сильнее.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.GROW_SHRINK, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.from_address = draw.PointF(100, 100)
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    effect.behaviors.add(scale)

    presentation.save("scale.pptx", slides.export.SaveFormat.PPTX)
```

### **Цвет**

Используйте [create_color_effect]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/behaviorfactory/create_color_effect/) для изменения заливки с синего на оранжевый. [from_address]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/coloreffect/from_address/) и [to]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/coloreffect/to/) — цвета; [by]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/coloreffect/by/) — цветовое смещение. [Behavior.properties]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/behavior/properties/) определяет анимируемый атрибут.

Заливка фигуры инициализируется синим, соответствующим начальному цвету анимации. Выбор атрибута заливки сообщает поведению, какую часть фигуры менять; только конечные цвета не указывают атрибут. Сохранённый эффект описывает двухсекундный переход к оранжевому.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.blue

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.CHANGE_FILL_COLOR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    color = factory.create_color_effect()
    color.properties.add(slides.animation.BehaviorProperty.fill_color.value)
    color.from_address.color = draw.Color.blue
    color.to.color = draw.Color.orange
    color.timing.duration = 2

    effect.behaviors.add(color)

    presentation.save("color.pptx", slides.export.SaveFormat.PPTX)
```

### **Фильтр**

Используйте [create_filter_effect]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/behaviorfactory/create_filter_effect/) для выбора стирания. [type]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/filtereffect/type/), [subtype]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/filtereffect/subtype/) и [reveal]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/filtereffect/reveal/) задают фильтр, направление и то, будет ли фигура отображаться или скрываться.

Этот пример настраивает двухсекундное стирание, которое раскрывает фигуру с помощью подтипа «right-direction». Параметры фильтра принадлежат поведению внутри эффекта, поэтому они задаются после удаления оригинальных операций предустановки.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.WIPE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    filter_behavior = factory.create_filter_effect()
    filter_behavior.type = slides.animation.FilterEffectType.WIPE
    filter_behavior.subtype = slides.animation.FilterEffectSubtype.RIGHT
    filter_behavior.reveal = slides.animation.FilterEffectRevealType.IN
    filter_behavior.timing.duration = 2

    effect.behaviors.add(filter_behavior)

    presentation.save("filter.pptx", slides.export.SaveFormat.PPTX)
```

### **Свойство**

Используйте [create_property_effect]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/behaviorfactory/create_property_effect/) для анимации непрозрачности. [from_address]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/propertyeffect/from_address/), [to]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/propertyeffect/to/) и [by]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/propertyeffect/by/) — строки, интерпретируемые с помощью [value_type]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/propertyeffect/value_type/) и [calc_mode]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/propertyeffect/calc_mode/). Выбирайте конечные точки или относительное смещение, а не задавайте все три без разбора.

Здесь выбран атрибут «opacity», а числовые строки обозначают изменение от 25 % непрозрачности до полной. Линейная интерполяция описывает постепенное изменение между этими значениями. При адаптации примера к другому атрибуту выберите тип значения и конечные значения, соответствующие этому атрибуту.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    property_behavior = factory.create_property_effect()
    property_behavior.properties.add(slides.animation.BehaviorProperty.style_opacity.value)
    property_behavior.value_type = slides.animation.PropertyValueType.NUMBER
    property_behavior.calc_mode = slides.animation.PropertyCalcModeType.LINEAR
    property_behavior.from_address = "0.25"
    property_behavior.to = "1"
    property_behavior.timing.duration = 2

    effect.behaviors.add(property_behavior)

    presentation.save("property.pptx", slides.export.SaveFormat.PPTX)
```

### **Установка**

Используйте [create_set_effect]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/behaviorfactory/create_set_effect/) для назначения видимости через [to]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/seteffect/to/). Поведение «set» не интерполирует между конечными точками.

Пример выбирает атрибут «visibility» и присваивает строку `visible` при выполнении поведения. Прямоугольник уже видим в этой минимальной презентации, поэтому присваивание может не вызвать заметного визуального изменения само по себе. Такая операция полезна как часть более крупного эффекта, который также контролирует момент скрытия или отображения фигуры.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    set_behavior = factory.create_set_effect()
    set_behavior.properties.add(slides.animation.BehaviorProperty.style_visibility.value)
    set_behavior.to = "visible"

    effect.behaviors.add(set_behavior)

    presentation.save("set.pptx", slides.export.SaveFormat.PPTX)
```

### **Команда**

Используйте [create_command_effect]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/behaviorfactory/create_command_effect/) и задайте [type]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/commandeffect/type/), [command_string]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/commandeffect/command_string/) и [shape_target]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/commandeffect/shape_target/). Поместите WAV‑запись `sample.wav` в рабочий каталог. Пример встраивает её с помощью [add_audio_frame_embedded]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) и прикрепляет команду воспроизведения к аудио‑кадру.

Аудио‑кадр является одновременно целью эффекта и целевым объектом команды. Это связывает запрос воспроизведения с встроенной записью; одна лишь строка команды не указывает, какой медиа‑объект управлять. Эффект настроен на запуск по щелчку во время показа слайдов.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(100, 100, 40, 40, audio_stream)

    effect = slide.timeline.main_sequence.add_effect(audio_frame, slides.animation.EffectType.MEDIA_PLAY, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    command = factory.create_command_effect()
    command.type = slides.animation.CommandEffectType.CALL
    command.command_string = "play"
    command.shape_target = audio_frame

    effect.behaviors.add(command)

    presentation.save("command.pptx", slides.export.SaveFormat.PPTX)
```

Сохранение помещает команду в `command.pptx`; запись не будет воспроизводиться. Воспроизведение требует проигрывателя слайдов, поддерживающего команду и её медиа‑цель.

## **Управление коллекцией поведения**

[BehaviorCollection]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/behaviorcollection/) поддерживает [add]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/behaviorcollection/add/), [insert]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/behaviorcollection/insert/), [remove]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/behaviorcollection/remove/) и [remove_at]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/behaviorcollection/remove_at/). В этом примере открывается `rotation.pptx`, добавляется масштабирование, перемещается перед вращением и удаляется вращение. Удаление и повторная вставка того же объекта меняет его сохранённую позицию без создания копии.

Последовательность правок меняет коллекцию из rotation–scale в scale–rotation, а затем оставляет только scale. Индексы относятся к текущей коллекции, поэтому удаление использует новый индекс вращения после переупорядочивания. Финальная переборка подтверждает, какое поведение будет сохранено.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    behaviors = effect.behaviors

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    behaviors.add(scale)
    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.remove_at(1)

    for behavior in behaviors:
        print(type(behavior).__name__)

    presentation.save("collection-edited.pptx", slides.export.SaveFormat.PPTX)
```

Результат — `ScaleEffect`: осталось только масштабирование. Порядок в коллекции сам по себе не планирует последовательность выполнения поведений. Очищайте коллекцию только при полном замене её операций.

## **Настройка тайминга поведения**

[Behavior.timing]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/behavior/timing/) раскрывает [Timing]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/timing/), независимо от [Effect.timing]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/effect/timing/). Тайминг эффекта планирует весь эффект; тайминг поведения описывает операцию внутри него.

### **Установка длительности, задержки, повторов и ускорения**

Откройте `rotation.pptx` и задайте [duration]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/timing/duration/) и [trigger_delay_time]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/timing/trigger_delay_time/) в секундах, затем настройте [repeat_count]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/timing/repeat_count/). [accelerate]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/timing/accelerate/) и [decelerate]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/timing/decelerate/) — доли от длительности; их сумма не должна превышать 1.

Входной файл — тот, что создан в примере вращения, где первое поведение известно как вращение. Этот пример меняет только тайминг этого поведения; угол 90 ° остаётся неизменным. Разделение угла и тайминга упрощает регулировку темпа без перестройки анимации.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    rotation = effect.behaviors[0]
    rotation.timing.duration = 2
    rotation.timing.trigger_delay_time = 0.5
    rotation.timing.repeat_count = 3
    rotation.timing.accelerate = 0.2
    rotation.timing.decelerate = 0.2

    presentation.save("timing.pptx", slides.export.SaveFormat.PPTX)
```

Поведение использует длительность две секунды, задержку полсекунды и количество повторов 3. Первые и последние 20 % длительности отводятся ускорению и замедлению.

Другие политики повторов включают [repeat_duration]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/timing/repeat_duration/), [repeat_until_end_slide]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/timing/repeat_until_end_slide/), и [repeat_until_next_click]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/timing/repeat_until_next_click/); выбирайте одну политику, а не включайте их все одновременно. [auto_reverse]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/timing/auto_reverse/) воспроизводит анимацию в обратном порядке после прямого прохода. Ускорение и замедление применяются к непрерывным изменениям, а не к дискретным назначениям или командам.

## **Создание пути движения**

Используйте [create_motion_effect]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/behaviorfactory/create_motion_effect/) для создания движения. Его [from_address]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/motioneffect/from_address/), [to]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/motioneffect/to/) и [by]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/motioneffect/by/) описывают координаты или смещения в процентах. Для редактируемого маршрута создайте [MotionPath]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/motionpath/) и присвойте его свойству [MotionEffect.path]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/motioneffect/path/). [MotionPath]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/motionpath/) хранит команды пути.

[MotionCommandPathType]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/motioncommandpathtype/) выбирает операцию:

| Команда | Точки | Значение |
| --- | --- | --- |
| MOVE_TO | One | Устанавливает начальную позицию. |
| LINE_TO | One | Перемещает по прямому сегменту к конечной точке. |
| CURVE_TO | Three | Следует кубической кривой, задаваемой двумя контрольными точками и конечной точкой. |
| CLOSE_LOOP | None | Возвращается к начальной позиции. |
| END | None | Завершает путь. |

[MotionPathPointsType]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/motionpathpointstype/) описывает характеристики редактирования точек, такие как угловые или сглаженные точки. Это не заменяет тип команды. Для примера кривой ниже используйте тип кривой, а для прямых сегментов — тип угла.

Координаты пути нормализованы к размерам слайда: смещение X = 0.25 соответствует четверти ширины слайда, а не 0.25 pt. Положительный Y направлен вниз. Абсолютные команды задают позиции в системе координат пути; относительные команды задают смещения от текущей позиции. Это отдельно от [origin]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/motioneffect/origin/), который выбирает эталонную систему пути, и от [path_edit_mode]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/motioneffect/path_edit_mode/), управляющего тем, как путь перемещается при перемещении фигуры.

### **Создание прямого пути**

Создайте поведение движения с начальной точкой, одним прямым сегментом и командой завершения. [MotionPath.add]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/motionpath/add/) принимает тип команды, её точки, тип точек и флаг относительных координат.

Начальная команда устанавливает (0, 0), а линия заканчивается в (0.25, 0), задавая горизонтальное смещение в одну четверть ширины слайда. Команда завершения не имеет координатных точек. После присвоения пути добавление поведения движения к эффекту связывает этот маршрут с прямоугольником.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.PATH_RIGHT, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    motion = factory.create_motion_effect()
    motion.origin = slides.animation.MotionOriginType.LAYOUT
    motion.timing.duration = 2

    path = slides.animation.MotionPath()
    path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0, 0)], slides.animation.MotionPathPointsType.AUTO, False)
    path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.25, 0)], slides.animation.MotionPathPointsType.CORNER, False)
    path.add(slides.animation.MotionCommandPathType.END, [], slides.animation.MotionPathPointsType.NONE, False)

    motion.path = path
    effect.behaviors.add(motion)

    presentation.save("motion.pptx", slides.export.SaveFormat.PPTX)
```

`motion.pptx` содержит одно поведение движения с тремя командами пути. Приведённые ниже примеры редактирования файлов используют эту известную структуру.

### **Сравнение абсолютных и относительных координат**

Эти два объекта пути описывают один и тот же маршрут. Абсолютная команда заканчивается в (0.3, 0.1); относительная команда добавляет (0.1, 0.1) к текущей позиции (0.2, 0).

Оба пути начинаются в одинаковой позиции. Для относительной линии добавьте её смещения X и Y к текущей позиции, чтобы получить конечную точку; для абсолютной линии прочитайте конечную точку напрямую. Переключение флага без преобразования координат опишет иной маршрут.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

absolute_path = slides.animation.MotionPath()
absolute_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
absolute_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.3, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)

relative_path = slides.animation.MotionPath()
relative_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
relative_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.1, 0.1)], slides.animation.MotionPathPointsType.CORNER, True)
```

Присвойте любой из путей поведению движения, чтобы использовать его в презентации. Последний логический аргумент выбирает относительные координаты для этой команды.

### **Замена линии на кривую**

Откройте `motion.pptx` и замените её команду линии кубической кривой. Сначала укажите две контрольные точки, затем конечную точку.

Начальная позиция задаётся предыдущей командой. Первые две точки формируют кривую, третья — её конечную точку; они не являются тремя последовательными пунктами назначения. Обновление типа команды, типа редактирования точек и массива точек одновременно сохраняет сегмент согласованным с новой геометрией.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path[1].command_type = slides.animation.MotionCommandPathType.CURVE_TO
    path[1].points_type = slides.animation.MotionPathPointsType.CURVE_SMOOTH
    path[1].points = [draw.PointF(0.1, 0), draw.PointF(0.2, 0.1), draw.PointF(0.3, 0.1)]

    presentation.save("curve.pptx", slides.export.SaveFormat.PPTX)
```

Путь в `curve.pptx` всё ещё имеет три команды; его средняя команда теперь определяет кривую.

## **Просмотр и редактирование сохранённого пути**

Каждый [MotionCmdPath]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/motioncmdpath/) раскрывает [points]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/motioncmdpath/points/), [command_type]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/motioncmdpath/command_type/), [points_type]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/motioncmdpath/points_type/) и [is_relative]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/motioncmdpath/is_relative/). Последующие примеры работают с известным трёхкомандным путём в `motion.pptx`. Для произвольного ввода найдите нужный эффект и проверьте типы команд и число точек перед редактированием по индексу.

### **Чтение команд и координат**

Считайте путь без изменения. Команды End и Close‑loop не требуют точек, поэтому допускайте массив точек `None`.

Вывод сопоставляет каждую команду с её флагом относительных координат перед перечислением точек. Это позволяет отличать конечную точку от смещения перед изменением пути. Кривая будет перечислять три точки, тогда как прямой отрезок в этом файле — только одну.

```python
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    for segment in motion.path:
        print(f"{segment.command_type}, relative: {segment.is_relative}")
        if segment.points is not None:
            for point in segment.points:
                print(f"X={point.x}, Y={point.y}")
```

Список содержит стартовую точку, абсолютную линию, заканчивающуюся в (0.25, 0), и команду End.

### **Изменение конечной точки**

Откройте `motion.pptx` и замените массив точек линии, переместив её конечную точку.

Во входном файле индекс 0 — стартовая команда, индекс 1 — линия. Замена единственной точки линии меняет её назначение без изменения типа команды, тайминга или позиции в коллекции. Поскольку команда использует абсолютные координаты, новая пара задаёт позицию, а не добавочное смещение.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    motion = effect.behaviors[0]
    motion.path[1].points = [draw.PointF(0.4, 0.1)]

    presentation.save("motion-endpoint.pptx", slides.export.SaveFormat.PPTX)
```

Линия в `motion-endpoint.pptx` заканчивается в (0.4, 0.1); оригинальный файл остаётся без изменений.

### **Замена сегмента**

Используйте [insert]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/motionpath/insert/) и [remove_at]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/motionpath/remove_at/) для замены линии в `motion.pptx`. Вставка смещает старую линию к индексу 2.

Это демонстрирует замену объекта команды, а не редактирование его координат. После вставки коллекция временно содержит стартовую команду, новую линию, старую линию и команду End. Удаление индекса 2 исключает старую линию, оставляя новый маршрут на месте.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path.insert(1, slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.2, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)
    path.remove_at(2)

    presentation.save("motion-edited.pptx", slides.export.SaveFormat.PPTX)
```

Сохранённый путь всё ещё имеет три команды, новая линия заканчивается в (0.2, 0.1), а команда End стоит последней.

## **Изменение и проверка существующего поведения**

Когда индекс поведения неизвестен, выберите его по типу. Этот пример открывает `rotation.pptx`, находит его [RotationEffect]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/rotationeffect/), меняет угол и проверяет сохранённое значение после повторного открытия.

Проверка типа позволяет пропускать поведения, не являющиеся вращениями. Второе чтение загружает сохранённый файл в отдельный объект презентации, поэтому сравнение проверяет данные, а не значение, оставшееся в памяти. Пример по‑прежнему предполагает, что известный эффект первый в основной последовательности; выбор поведения по типу не гарантирует нахождение нужного эффекта в произвольной презентации.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    for behavior in effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            behavior.by = 180

    presentation.save("rotation-edited.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("rotation-edited.pptx") as reopened:
    saved_effect = reopened.slides[0].timeline.main_sequence[0]

    for behavior in saved_effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            print(f"Rotation preserved: {abs(behavior.by - 180) < 0.001}")
```

Вывод: `Rotation preserved: True`. Применяйте тот же шаблон проверки типов к другим поведениям. Для полного контроля сохраняемости сравните целевую фигуру, эффект, типы и порядок поведений, тайминг и команды пути. Для чисел используйте допускаемую погрешность. Для презентации с неизвестной структурой анимации см. [Чтение анимаций фигур](/slides/ru/python-net/shape-animation/#read-shape-animations) для обхода основных и интерактивных последовательностей.

## **Порядок поведения, предустановки и воспроизведение**

Порядок в [BehaviorCollection]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/behaviorcollection/) — это сохранённый порядок операций эффекта. Это не плейлист, где каждое поведение автоматически ждёт завершения предыдущего. Тайминг и охватывающий эффект определяют планирование. Поведения могут перекрываться, а операции над одним свойством могут взаимодействовать через [additive]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/behavior/additive/) и [accumulate]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/behavior/accumulate/). Не используйте переупорядочивание коллекции как единственное средство планировать «переместить, затем вращать»; применяйте явный тайминг или отдельные эффекты, как описано в [Анимации фигур](/slides/ru/python-net/shape-animation/).

[type]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/effect/type/) и [subtype]​(https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/effect/subtype/) эффекта описывают его предустановку. Это не полное описание отредактированного дерева поведения. Сначала выберите предустановку и подтип, а затем настраивайте поведения: изменение предустановки может пересоздать коллекцию и удалить ваши пользовательские операции. Например, смена пользовательского эффекта Spin на Fade может заменить его поведение вращения на установки и фильтры. После изменения предустановки или подтипа снова проверьте коллекцию. Очистка предустановленных поведений также может удалить операции видимости или инициализации, необходимые предустановке. Примеры намеренно используют видимые фигуры и заменяют поведения; они не перестраивают полную реализацию каждой предустановки.

## **Совместимость форматов**

Сохранённое дерево поведения не гарантирует идентичное воспроизведение во всех просмотровщиках или экспортных рендерах. Проверяйте сохранённые данные и визуальный результат отдельно.

| Формат или вывод | Что проверять |
| --- | --- |
| PPTX | Используйте как основной формат для этих примеров. Откройте файл повторно, чтобы убедиться в сохранении редактируемого дерева поведения, затем проверьте воспроизведение в целевой версии PowerPoint. |
| PPT | Устаревшее двоичное представление может отличаться от PPTX. Выполните отдельный цикл сохранения‑повторного открытия и тест воспроизведения; не делайте выводы о поддержке всех пользовательских комбинаций только из успешного вывода PPTX. |
| PDF, PNG, JPEG и другие статические изображения слайдов | Содержат статическое представление слайда, а не проигрываемую временную шкалу поведения или гарантированный конечный кадр анимации. |
| [HTML5](/slides/ru/python-net/export-to-html5/) | Может воспроизводить поддерживаемые анимации, когда в параметрах экспорта включена анимация фигур. Тестируйте пользовательские комбинации в браузере. |
| [Animated GIF](/slides/ru/python-net/convert-powerpoint-to-animated-gif/) | Сохраняет отрендеренные кадры, а не редактируемые поведения или интерактивные клики. Проверьте фактическое отрисованное движение. |
| [Video](/slides/ru/python-net/convert-powerpoint-to-video/) | Рендерит кадры анимации и кодирует их в видео. Поддержка ограничена [поддерживаемыми анимациями и эффектами](/slides/ru/python-net/convert-powerpoint-to-video/#supported-animations-and-effects); команды и интерактивные события не превращаются в редактируемую временную шкалу. |

## **ЧаВо**

**Почему мой эффект содержит поведения до того, как я их добавил?**

Создание предопределённого эффекта может создавать его базовые операции. Просмотрите их, прежде чем решить, расширять предустановку или заменять её поведения.

**Перемещение поведения в начало заставит его воспроизводиться первым?**

Не обязательно. Порядок в коллекции не заменяет тайминг. Проверяйте задержки, длительности и взаимодействия между операциями над одним свойством.

**Почему у команды End нет точек?**

Она обозначает конец пути и не требует координат. При проверке пути, считанного из файла, учитывайте возможность массива точек `None`.

**Достаточно ли успешного кругового прохода, чтобы подтвердить воспроизведение?**

Нет. Повторное открытие подтверждает сохранение проверяемых свойств. Тестируйте проигрыватель слайдов или экспорт анимации отдельно, чтобы убедиться в визуальном поведении.