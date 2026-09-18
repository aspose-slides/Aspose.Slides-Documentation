---
title: Создание и изменение пользовательских анимационных поведений в Python через Java
linktitle: Пользовательская анимация
type: docs
weight: 151
url: /ru/python-java/custom-animation/
keywords:
- пользовательская анимация
- поведение анимации
- траектория движения
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Создавайте, проверяйте и изменяйте пользовательские анимационные поведения и редактируемые траектории движения в презентациях PowerPoint с помощью Aspose.Slides для Python через Java."
---
## **Обзор**

Пользовательские анимационные поведения позволяют управлять отдельными операциями внутри анимационного эффекта, такими как изменение цвета, вращение формы или следование по редактируемому траектории движения. В этом руководстве показано, как создавать и комбинировать поведения, настраивать их тайминг, исследовать и изменять существующие анимации, а также проверять, сохраняются ли их свойства после сохранения и повторного открытия презентации.

Для предопределённых эффектов и триггеров щелчка см. [Shape Animation](/slides/ru/python-java/shape-animation/).

## **Понимание модели анимации**

Анимация организована как **Timeline → Sequence → Effect → Behaviors**:

- Метод [getTimeline](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslide/#getTimeline) возвращает временную шкалу слайда, которая содержит его основную последовательность и интерактивные последовательности.
- [Sequence](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sequence/) содержит эффекты, потенциально направленные на разные формы.
- [Effect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/effect/) определяет целевую форму, предустановку, подтип и тайминг эффекта.
- Коллекция, возвращаемая [Effect.getBehaviors](https://reference.aspose.com/slides/ru/python-java/aspose.slides/effect/#getBehaviors), содержит операции, реализующие эффект: изменение цвета, перемещение, вращение, установка свойства и т.д.

## **Создание отдельных поведений**

Вызовите [Sequence.addEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sequence/#addEffect), чтобы создать эффект и получить доступ к коллекции [getBehaviors](https://reference.aspose.com/slides/ru/python-java/aspose.slides/effect/#getBehaviors). Предустановка может автоматически заполнить эту коллекцию. Сохраняйте её операции при расширении предустановки или используйте [clear](https://reference.aspose.com/slides/ru/python-java/aspose.slides/behaviorcollection/#clear), когда намеренно заменяете их.

[BehaviorFactory](https://reference.aspose.com/slides/ru/python-java/aspose.slides/behaviorfactory/) создаёт восемь типов поведений, иллюстрированных ниже. Движение рассматривается в разделе [Build a Motion Path](#build-a-motion-path). Каждый фрагмент включает свои импорты и, при необходимости, запускает JVM. Объекты точек Java и массивы создаются через JPype, где API их требует. Примеры последующего редактирования указывают, какой файл вывода они используют.

### **Вращение**

Используйте [createRotationEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/behaviorfactory/#createRotationEffect), чтобы создать вращение. [getBy](https://reference.aspose.com/slides/ru/python-java/aspose.slides/rotationeffect/#getBy) задаёт относительный угол в градусах; [getFrom](https://reference.aspose.com/slides/ru/python-java/aspose.slides/rotationeffect/#getFrom) и [getTo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/rotationeffect/#getTo) задают конечные точки.

В примере начинается с эффекта Spin, заменяется его набор операций одной операцией вращения, которой задаётся длительность в две секунды. Относительный угол 90 градусов представляет четверть оборота от исходной ориентации формы, поэтому явный начальный угол не требуется.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    rotation = factory.createRotationEffect()
    rotation.setBy(90)
    rotation.getTiming().setDuration(2)

    effect.getBehaviors().add(rotation)

    presentation.save("rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`rotation.pptx` содержит одну форму и одно поведение вращения. Коллекция, тайминг и примеры редактирования вращения ниже используют этот файл.

### **Масштаб**

Используйте [createScaleEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/behaviorfactory/#createScaleEffect) с процентами X/Y: [getFrom](https://reference.aspose.com/slides/ru/python-java/aspose.slides/scaleeffect/#getFrom) и [getTo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/scaleeffect/#getTo) описывают начальный и конечный размер, а [getBy](https://reference.aspose.com/slides/ru/python-java/aspose.slides/scaleeffect/#getBy) описывает относительное изменение. Здесь 100 означает исходный размер.

В примере обе размеры увеличиваются с 100 % до 125 % за две секунды. Использование одинаковых горизонтальных и вертикальных процентов сохраняет пропорции формы; разные проценты растягивают одну из осей сильнее другой.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setFrom(Point2DFloat(100, 100))
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    effect.getBehaviors().add(scale)

    presentation.save("scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Цвет**

Используйте [createColorEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/behaviorfactory/#createColorEffect), чтобы изменить заливку с синего на оранжевый. [getFrom](https://reference.aspose.com/slides/ru/python-java/aspose.slides/coloreffect/#getFrom) и [getTo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/coloreffect/#getTo) — это цвета; [getBy](https://reference.aspose.com/slides/ru/python-java/aspose.slides/coloreffect/#getBy) — смещение цвета. [Behavior.getProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/behavior/#getProperties) определяет анимируемый атрибут.

Заливка формы инициализируется синим, что соответствует начальному цвету анимации. Выбор атрибута заливки сообщает поведению, какую часть формы менять; сами конечные цвета не указывают атрибут. Сохранённый эффект описывает двухсекундный переход к оранжевому.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, FillType, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    color = factory.createColorEffect()
    color.getProperties().add(BehaviorProperty.getFillColor().getValue())
    color.getFrom().setColor(Color.BLUE)
    color.getTo().setColor(Color(255, 165, 0))
    color.getTiming().setDuration(2)

    effect.getBehaviors().add(color)

    presentation.save("color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Фильтр**

Используйте [createFilterEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/behaviorfactory/#createFilterEffect), чтобы выбрать стирание. [getType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/ru/python-java/aspose.slides/filtereffect/#getSubtype) и [getReveal](https://reference.aspose.com/slides/ru/python-java/aspose.slides/filtereffect/#getReveal) задают тип фильтра, направление и режим раскрытия/скрытия формы.

Этот пример настраивает двухсекундное стирание, которое раскрывает форму с направлением вправо. Параметры фильтра принадлежат поведению внутри эффекта, поэтому они конфигурируются после удаления оригинальных операций предустановки.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, FilterEffectRevealType, FilterEffectSubtype, FilterEffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    filter = factory.createFilterEffect()
    filter.setType(FilterEffectType.Wipe)
    filter.setSubtype(FilterEffectSubtype.Right)
    filter.setReveal(FilterEffectRevealType.In)
    filter.getTiming().setDuration(2)

    effect.getBehaviors().add(filter)

    presentation.save("filter.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Свойство**

Используйте [createPropertyEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/behaviorfactory/#createPropertyEffect) для анимации непрозрачности. [getFrom](https://reference.aspose.com/slides/ru/python-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/propertyeffect/#getTo) и [getBy](https://reference.aspose.com/slides/ru/python-java/aspose.slides/propertyeffect/#getBy) — строки, интерпретируемые с помощью [getValueType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/propertyeffect/#getValueType) и [getCalcMode](https://reference.aspose.com/slides/ru/python-java/aspose.slides/propertyeffect/#getCalcMode). Выбирайте конечные точки или относительное смещение, а не задавайте все три параметра одновременно.

Здесь выбран атрибут непрозрачности, а числовые строки представляют изменение от 25 % к полной непрозрачности. Линейная интерполяция описывает постепенное изменение между этими значениями. При адаптации примера к другому атрибуту выбирайте тип значения и конечные значения, соответствующие этому атрибуту.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, PropertyCalcModeType, PropertyValueType, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    property = factory.createPropertyEffect()
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue())
    property.setValueType(PropertyValueType.Number)
    property.setCalcMode(PropertyCalcModeType.Linear)
    property.setFrom("0.25")
    property.setTo("1")
    property.getTiming().setDuration(2)

    effect.getBehaviors().add(property)

    presentation.save("property.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Установка**

Используйте [createSetEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/behaviorfactory/#createSetEffect) для назначения видимости через [getTo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/seteffect/#getTo). Поведение установки не интерполирует между конечными точками.

В примере выбирается атрибут видимости и присваивается строка `visible`, когда поведение запускается. Прямоугольник уже видим в этой минимальной презентации, поэтому присваивание может не вызвать заметного визуального изменения само по себе. Такая операция полезна как часть более крупного эффекта, который также управляет тем, когда форма становится скрытой или видимой.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    set = factory.createSetEffect()
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue())
    set.setTo("visible")

    effect.getBehaviors().add(set)

    presentation.save("set.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Команда**

Используйте [createCommandEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/behaviorfactory/#createCommandEffect) и настройте [getType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/ru/python-java/aspose.slides/commandeffect/#getCommandString) и [getShapeTarget](https://reference.aspose.com/slides/ru/python-java/aspose.slides/commandeffect/#getShapeTarget). Поместите WAV‑запись `sample.wav` в рабочий каталог. Этот пример внедряет её с помощью [addAudioFrameEmbedded](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) и привязывает команду воспроизведения к аудиокадру.

Аудиокадр является одновременно целью эффекта и командой. Это соединяет запрос воспроизведения с внедрённой записью; одна лишь строка команды не указывает, какой медиаресурс управлять. Эффект настроен на запуск по щелчку во время показа слайдов.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path

from asposeslides.api import BehaviorFactory, CommandEffectType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("sample.wav").read_bytes()
    audio_bytes = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(audio_bytes)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audio)

    effect = slide.getTimeline().getMainSequence().addEffect(audio_frame, EffectType.MediaPlay, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    command = factory.createCommandEffect()
    command.setType(CommandEffectType.Call)
    command.setCommandString("play")
    command.setShapeTarget(audio_frame)

    effect.getBehaviors().add(command)

    presentation.save("command.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Сохранение сохраняет команду в `command.pptx`; запись не воспроизводится. Воспроизведение требует проигрывателя слайдов, поддерживающего команду и её медиатеку.

## **Управление коллекцией поведений**

[BehaviorCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/behaviorcollection/) поддерживает [add](https://reference.aspose.com/slides/ru/python-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/ru/python-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/ru/python-java/aspose.slides/behaviorcollection/#remove) и [removeAt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/behaviorcollection/#removeAt). В этом примере открывается `rotation.pptx`, добавляется масштабирование, перемещается перед вращением и удаляется вращение. Удаление и повторная вставка одного и того же объекта меняет его хранённую позицию без создания копии.

Последовательность правок меняет коллекцию с rotation–scale на scale–rotation, затем только на scale. Индексы относятся к текущей коллекции, поэтому удаление использует новый индекс вращения после переупорядочивания. Финальный перебор подтверждает, какое поведение будет сохранено.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    behaviors = effect.getBehaviors()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    behaviors.add(scale)

    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.removeAt(1)

    for behavior in behaviors:
        print(behavior.getClass().getSimpleName())

    presentation.save("collection-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Вывод: `ScaleEffect` — остался только масштаб. Порядок в коллекции сам по себе не планирует поведения одно за другим. Очищать коллекцию следует только при полной замене её операций.

## **Настройка тайминга поведения**

[Behavior.getTiming](https://reference.aspose.com/slides/ru/python-java/aspose.slides/behavior/#getTiming) раскрывает [Timing](https://reference.aspose.com/slides/ru/python-java/aspose.slides/timing/), независимо от [Effect.getTiming](https://reference.aspose.com/slides/ru/python-java/aspose.slides/effect/#getTiming). Тайминг эффекта планирует охватывающий эффект; тайминг поведения описывает операцию внутри него.

### **Установка длительности, задержки, повторов и ускорения**

Откройте `rotation.pptx` и задайте длительность ([getDuration](https://reference.aspose.com/slides/ru/python-java/aspose.slides/timing/#getDuration)) и задержку триггера ([getTriggerDelayTime](https://reference.aspose.com/slides/ru/python-java/aspose.slides/timing/#getTriggerDelayTime)) в секундах, затем настройте количество повторов через [setRepeatCount](https://reference.aspose.com/slides/ru/python-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/ru/python-java/aspose.slides/timing/#getAccelerate) и [getDecelerate](https://reference.aspose.com/slides/ru/python-java/aspose.slides/timing/#getDecelerate) — доли от общей длительности; их сумма должна быть не более 1.

Входной файл — тот, что был создан в примере вращения, где первое поведение известно как вращение. Этот пример меняет только тайминг этого поведения; угол 90 градусов остаётся прежним. Разделение угла и тайминга упрощает настройку скорости без пересоздания анимации.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    rotation = effect.getBehaviors().get_Item(0)
    rotation.getTiming().setDuration(2)
    rotation.getTiming().setTriggerDelayTime(0.5)
    rotation.getTiming().setRepeatCount(3)
    rotation.getTiming().setAccelerate(0.2)
    rotation.getTiming().setDecelerate(0.2)

    presentation.save("timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Поведение использует двухсекундную длительность, полусекундную задержку и количество повторов = 3. Первые и последние 20 % длительности отводятся ускорению и замедлению.

Другие политики повторов включают [getRepeatDuration](https://reference.aspose.com/slides/ru/python-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/timing/#getRepeatUntilEndSlide) и [getRepeatUntilNextClick](https://reference.aspose.com/slides/ru/python-java/aspose.slides/timing/#getRepeatUntilNextClick); выбирайте одну политику, а не включайте их все одновременно. [getAutoReverse](https://reference.aspose.com/slides/ru/python-java/aspose.slides/timing/#getAutoReverse) воспроизводит анимацию в обратном порядке после прямого прохода. Ускорение и замедление применимы к непрерывным изменениям, а не к дискретным присваиваниям или командам.

## **Создание траектории движения**

Используйте [createMotionEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/behaviorfactory/#createMotionEffect) для создания движения. Его [getFrom](https://reference.aspose.com/slides/ru/python-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/motioneffect/#getTo) и [getBy](https://reference.aspose.com/slides/ru/python-java/aspose.slides/motioneffect/#getBy) описывают координаты или смещения в процентах. Для редактируемого маршрута создайте [MotionPath](https://reference.aspose.com/slides/ru/python-java/aspose.slides/motionpath/) и назначьте его через [MotionEffect.setPath](https://reference.aspose.com/slides/ru/python-java/aspose.slides/motioneffect/#setPath). [MotionPath](https://reference.aspose.com/slides/ru/python-java/aspose.slides/motionpath/) хранит команды пути.

[MotionCommandPathType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/motioncommandpathtype/) выбирает тип операции:

| Команда | Точки | Значение |
| --- | --- | --- |
| MoveTo | Одна | Устанавливает начальную позицию. |
| LineTo | Одна | Переходит по прямому отрезку к конечной точке. |
| CurveTo | Три | Следует кубической кривой, определённой двумя контрольными точками и конечной точкой. |
| CloseLoop | Нет | Возвращается к начальной позиции. |
| End | Нет | Завершает путь. |

[MotionPathPointsType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/motionpathpointstype/) описывает характеристики редактирования точек, такие как угол или гладкая точка. Это не заменяет тип команды. Используйте тип точек «кривая» для примера кривой ниже и тип «угол» для прямых сегментов.

Координаты пути нормализованы к размерам слайда: смещение X = 0.25 соответствует одной четверти ширины слайда, а не 0.25 pt. Положительное Y направлено вниз. Абсолютные команды задают позиции в системе координат пути; относительные — смещения от текущей позиции. Это отдельный параметр от [getOrigin](https://reference.aspose.com/slides/ru/python-java/aspose.slides/motioneffect/#getOrigin), который выбирает систему отсчёта пути, и от [getPathEditMode](https://reference.aspose.com/slides/ru/python-java/aspose.slides/motioneffect/#getPathEditMode), управляющего перемещением пути вместе с формой.

### **Создание прямой траектории**

Создайте поведение движения с начальной точкой, одним прямым сегментом и командой завершения. [MotionPath.add](https://reference.aspose.com/slides/ru/python-java/aspose.slides/motionpath/#add) принимает тип команды, её точки, тип точек и флаг относительных координат.

Начальная команда устанавливает (0, 0), а линия заканчивается в (0.25, 0), давая горизонтальное смещение в одну четверть ширины слайда. Команда завершения не имеет координатных точек. После назначения пути добавление поведения движения к эффекту соединяет этот маршрут с прямоугольником.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, MotionCommandPathType, MotionOriginType, MotionPath, MotionPathPointsType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    motion = factory.createMotionEffect()
    motion.setOrigin(MotionOriginType.Layout)
    motion.getTiming().setDuration(2)

    path = MotionPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0, 0)])
    path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
    path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.25, 0)])
    path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)
    path_points_3 = jpype.JArray(Point2DFloat)(0)
    path.add(MotionCommandPathType.End, path_points_3, MotionPathPointsType.None_, False)

    motion.setPath(path)
    effect.getBehaviors().add(motion)

    presentation.save("motion.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`motion.pptx` содержит одно поведение движения с тремя командами пути. Ниже представлены примеры редактирования файлов, использующие эту известную структуру.

### **Сравнение абсолютных и относительных координат**

Эти два объекта пути описывают один и тот же маршрут. Абсолютная команда заканчивается в (0.3, 0.1); относительная добавляет (0.1, 0.1) к текущей позиции (0.2, 0).

Оба пути начинаются в одной и той же позиции. Для относительной линии прибавьте её X и Y смещения к текущей позиции, получив конечную точку; для абсолютной прочитайте конечную точку напрямую. Переключение флага без преобразования координат даст иной маршрут.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPath, MotionPathPointsType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

absolute_path = MotionPath()
path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
absolute_path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.3, 0.1)])
absolute_path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)

relative_path = MotionPath()
path_points_3 = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
relative_path.add(MotionCommandPathType.MoveTo, path_points_3, MotionPathPointsType.Auto, False)
path_points_4 = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0.1)])
relative_path.add(MotionCommandPathType.LineTo, path_points_4, MotionPathPointsType.Corner, True)
```

Назначьте любой из путей поведению движения, чтобы использовать его в презентации. Последний булевый аргумент выбирает относительные координаты для этой команды.

### **Замена линии кривой**

Откройте `motion.pptx` и замените её команду линии кубической кривой. Сначала укажите две контрольные точки, затем конечную точку.

Начальная позиция задаётся предыдущей командой. Первые две точки формируют кривую, третья — её конечную точку; это не три последовательные точки‑назначения. Одновременное обновление типа команды, типа редактирования точек и массива точек сохраняет согласованность сегмента с новой геометрией.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo)
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0), Point2DFloat(0.2, 0.1), Point2DFloat(0.3, 0.1)])
    path.get_Item(1).setPoints(path_points)

    presentation.save("curve.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Путь в `curve.pptx` по‑прежнему содержит три команды; её средняя команда теперь определяет кривую.

## **Чтение и изменение сохранённого пути**

Каждый [MotionCmdPath](https://reference.aspose.com/slides/ru/python-java/aspose.slides/motioncmdpath/) раскрывает [getPoints](https://reference.aspose.com/slides/ru/python-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/motioncmdpath/#getPointsType) и [isRelative](https://reference.aspose.com/slides/ru/python-java/aspose.slides/motioncmdpath/#isRelative). Ниже приведённые примеры используют известный трёхкомандный путь в `motion.pptx`. Для произвольного входа найдите нужный эффект и проверьте типы команд и количество точек перед редактированием по индексу.

### **Чтение команд и координат**

Чтение пути без изменения. Команды End и CloseLoop не требуют точек, поэтому учитывайте возможность нулевого массива точек.

Вывод сопоставляет каждый числовой тип команды с её флагом относительных координат перед перечислением точек. Это позволяет различать конечную точку и смещение до изменения пути. Кривая будет перечислять три точки, тогда как прямая линия в этом файле — только одну.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    for segment in path:
        print(f"{segment.getCommandType()}, relative: {segment.isRelative()}")
        if segment.getPoints() is not None:
            for point in segment.getPoints():
                print(f"X={point.x}, Y={point.y}")
finally:
    presentation.dispose()
```

Список содержит начальную точку, абсолютную линию, заканчивающуюся в (0.25, 0), и команду End.

### **Изменение конечной точки**

Откройте `motion.pptx` и замените массив точек линии, чтобы сдвинуть её конечную точку.

Во входном файле индекс 0 — начальная команда, индекс 1 — линия. Замена единственной точки линии меняет её назначение без изменения типа команды, тайминга или позиции в коллекции. Поскольку команда использует абсолютные координаты, новая пара задаёт позицию, а не добавочный смещение.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    motion = effect.getBehaviors().get_Item(0)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.4, 0.1)])
    motion.getPath().get_Item(1).setPoints(path_points)

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Линия в `motion-endpoint.pptx` заканчивается в (0.4, 0.1); оригинальный файл остаётся без изменений.

### **Замена сегмента**

Используйте [insert](https://reference.aspose.com/slides/ru/python-java/aspose.slides/motionpath/#insert) и [removeAt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/motionpath/#removeAt) для замены линии в `motion.pptx`. Вставка сдвигает старую линию к индексу 2.

Это демонстрирует замену объекта команды, а не редактирование её существующих координат. После вставки коллекция временно содержит начальную команду, новую линию, старую линию и команду End. Удаление индекса 2 отбрасывает старую линию, оставляя новый маршрут на месте.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0.1)])
    path.insert(1, MotionCommandPathType.LineTo, path_points, MotionPathPointsType.Corner, False)
    path.removeAt(2)

    presentation.save("motion-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Сохранённый путь всё ещё имеет три команды, новая линия заканчивается в (0.2, 0.1), а команда End остаётся последней.

## **Модификация и проверка существующего поведения**

Когда индекс поведения неизвестен, выбирайте его по типу. Этот пример открывает `rotation.pptx`, находит его [RotationEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/rotationeffect/), меняет угол и проверяет сохранённое значение после повторного открытия.

Проверка типа позволяет циклу пропускать поведения, не являющиеся вращениями. Второе загрузка читает сохранённый файл в отдельный объект презентации, поэтому сравнение проверяет сохранённые данные, а не значение, оставшееся в памяти. Пример всё ещё предполагает, что известный эффект является первым в основной последовательности; выбор поведения по типу не гарантирует нахождение правильного эффекта в произвольной презентации.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    for behavior in effect.getBehaviors():
        if isinstance(behavior, RotationEffect):
            rotation = behavior
            rotation.setBy(180)

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx)

    reopened = Presentation("rotation-edited.pptx")
    try:
        saved_effect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

        for behavior in saved_effect.getBehaviors():
            if isinstance(behavior, RotationEffect):
                rotation = behavior
                print(f"Rotation preserved: {abs(rotation.getBy() - 180) < 0.001}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Вывод: `Rotation preserved: True`. Применяйте такой же шаблон проверки типов к другим поведениям. Для полной проверки сохранения сравнивайте целевую форму, эффект, типы и порядок поведений, тайминг и команды пути. Используйте числовой порог для значений с плавающей точкой. Для презентации с неизвестной анимационной структурой см. [Read Shape Animations](/slides/ru/python-java/shape-animation/#read-shape-animations) для обхода основных и интерактивных последовательностей.

## **Порядок поведений, предустановки и воспроизведение**

Порядок в [BehaviorCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/behaviorcollection/) — это сохранённый порядок операций эффекта. Это не плейлист, где каждое поведение автоматически ждёт предшествующее. Тайминг и охватывающий эффект определяют планирование. Поведения могут накладываться, а операции над одним и тем же свойством могут взаимодействовать через [getAdditive](https://reference.aspose.com/slides/ru/python-java/aspose.slides/behavior/#getAdditive) и [getAccumulate](https://reference.aspose.com/slides/ru/python-java/aspose.slides/behavior/#getAccumulate). Не используйте лишь переупорядочивание коллекции для планирования «сначала перемещение, затем вращение»; применяйте явный тайминг или отдельные эффекты, как описано в [Shape Animation](/slides/ru/python-java/shape-animation/).

[Effect.getType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/effect/#getType) и [Effect.getSubtype](https://reference.aspose.com/slides/ru/python-java/aspose.slides/effect/#getSubtype) описывают предустановку эффекта. Это не полное описание отредактированного дерева поведений. Выберите предустановку и подтип перед настройкой поведений: изменение предустановки может пересоздать коллекцию и удалить ваши пользовательские операции. Например, смена пользовательского эффекта Spin на Fade может заменить его поведение вращения на установки и фильтры. После изменения предустановки или подтипа снова проверьте коллекцию. Очистка предустановочных поведений также может удалить операции видимости или инициализации, необходимые предустановке. Примеры намеренно используют видимые формы и заменяют поведения; они не реконструируют каждую предустановку полностью.

## **Совместимость форматов**

Сохранённое дерево поведений не гарантирует идентичное воспроизведение во всех просмотрщиках или экспортных рендерерах. Проверяйте сохранённые данные и визуальный вывод отдельно.

| Формат или вывод | Что проверять |
| --- | --- |
| PPTX | Используйте как основной формат для этих примеров. Откройте файл повторно, чтобы убедиться в сохранении редактируемого дерева поведений, затем проверьте воспроизведение в целевой версии PowerPoint. |
| PPT | Устаревшее бинарное представление может отличаться от PPTX. Протестируйте отдельный цикл сохранения‑повторного открытия и воспроизведение; не делайте вывод о поддержке каждой пользовательской комбинации только по успешному выводу PPTX. |
| PDF, PNG, JPEG и другие статические изображения слайдов | Содержат статическое изображение слайда, а не воспроизводимую временную шкалу поведения или гарантированный конечный кадр анимации. |
| [HTML5](/slides/ru/python-java/export-to-html5/) | Может воспроизводить поддерживаемые анимации, когда в опциях экспорта включена анимация форм. Тестируйте пользовательские комбинации в браузере. |
| [Animated GIF](/slides/ru/python-java/convert-powerpoint-to-animated-gif/) | Сохраняет отрендеренные кадры, а не редактируемые поведения или интерактивные триггеры. Проверяйте фактическое отрендеренное движение. |
| [Video](/slides/ru/python-java/convert-powerpoint-to-video/) | Рендерит кадры анимации и кодирует их в видео. Поддержка ограничена [поддерживаемыми анимациями и эффектами](/slides/ru/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) рендерера; команды и интерактивные события не превращаются в редактируемую временную шкалу. |

## **FAQ**

**Почему мой эффект уже содержит поведения, пока я ничего не добавлял?**

Создание предопределённого эффекта может сразу создать его базовые операции. Просмотрите их, прежде чем решать, расширять предустановку или заменять её поведения.

**Делает ли перемещение поведения в начало коллекции его первым в воспроизведении?**

Не обязательно. Порядок в коллекции не заменяет тайминг. Проверяйте задержки, длительности и взаимодействия между операциями над одним и тем же свойством.

**Почему у команды End нет точек?**

Она обозначает конец пути и не требует координат. При чтении пути из файла проверяйте наличие нулевого массива точек.

**Достаточно ли успешного кругового прохода, чтобы подтвердить воспроизведение?**

Нет. Повторное открытие подтверждает сохранность проверенных свойств. Тестируйте проигрыватель слайдов или экспорт анимации отдельно, чтобы убедиться в визуальном поведении.