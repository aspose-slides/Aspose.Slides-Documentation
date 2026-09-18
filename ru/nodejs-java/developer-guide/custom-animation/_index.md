---
title: Создание и изменение пользовательских анимационных поведений в JavaScript
linktitle: Пользовательская анимация
type: docs
weight: 151
url: /ru/nodejs-java/custom-animation/
keywords:
- пользовательская анимация
- анимационное поведение
- траектория движения
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Создавайте, просматривайте и изменяйте пользовательские анимационные поведения и редактируемые траектории движения в презентациях PowerPoint с помощью Aspose.Slides для Node.js через Java."
---
## **Обзор**

Пользовательские анимационные поведения позволяют управлять отдельными операциями внутри анимационного эффекта, например изменением цвета, вращением фигуры или следованием по редактируемому пути движения. В этом руководстве показано, как создавать и комбинировать поведения, настраивать их тайминг, просматривать и изменять существующие анимации, а также проверять, сохраняются ли их свойства при сохранении и повторном открытии презентации.

Для предопределенных эффектов и триггеров по щелчку см. [Анимацию фигур](/slides/ru/nodejs-java/shape-animation/).

## **Понимание модели анимации**

Анимация организована как **Timeline → Sequence → Effect → Behaviors**:

- Метод [getTimeline](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseslide/#getTimeline) возвращает временную шкалу слайда, которая содержит его главную последовательность и интерактивные последовательности.  
- [Sequence](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sequence/) содержит эффекты, которые могут применяться к разным фигурам.  
- [Effect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/effect/) определяет целевую фигуру, предустановку, подтип и тайминг эффекта.  
- Коллекция, возвращаемая [Effect.getBehaviors](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/effect/#getBehaviors), содержит операции, реализующие эффект: изменение цвета, перемещение, вращение, установка свойства и т.д.

## **Создание отдельных поведений**

Вызовите [Sequence.addEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sequence/#addEffect), чтобы создать эффект и получить доступ к коллекции [getBehaviors](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/effect/#getBehaviors). Предустановка может автоматически заполнить эту коллекцию. Сохраняйте её операции при расширении предустановки или используйте [clear](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/behaviorcollection/#clear), когда намеренно заменяете их.

[BehaviorFactory](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/behaviorfactory/) создает восемь типов поведения, показанных ниже. Движение рассматривается в разделе [Создание траектории движения](#build-a-motion-path). Каждый фрагмент включает импорт модулей и может быть выполнен как скрипт Node.js при установленном пакете `aspose.slides.via.java` и `java`. Запустите примеры создания файлов до примеров их чтения. Примеры последующего редактирования указывают, какой файл вывода они используют.

### **Вращение**

Используйте [createRotationEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/behaviorfactory/#createRotationEffect) для создания вращения. [getBy](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/rotationeffect/#getBy) задаёт относительный угол в градусах; [getFrom](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/rotationeffect/#getFrom) и [getTo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/rotationeffect/#getTo) задают конечные точки.

Пример начинается с эффекта Spin, заменяет его предустановленные операции одним поведением вращения и задаёт длительность этой операции в две секунды. Относительный угол 90° представляет собой четверть оборота от начальной ориентации фигуры, поэтому явный начальный угол не требуется.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Spin, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const rotation = factory.createRotationEffect();
    rotation.setBy(90);
    rotation.getTiming().setDuration(2);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` содержит одну фигуру и одно поведение вращения. Ниже приведённые примеры работы с коллекцией, таймингом и редактированием вращения используют этот файл.

### **Масштаб**

Используйте [createScaleEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/behaviorfactory/#createScaleEffect) с процентами X/Y: [getFrom](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/scaleeffect/#getFrom) и [getTo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/scaleeffect/#getTo) описывают начальный и конечный размер, а [getBy](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/scaleeffect/#getBy) описывает относительное изменение. Здесь 100 означает исходный размер.

Пример увеличивает обе размеры с 100 % до 125 % за две секунды. Использование одинаковых горизонтальных и вертикальных процентов сохраняет пропорции фигуры; разные проценты растягивают одну из размерностей сильнее.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.GrowShrink, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setFrom(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(100), java.newFloat(100)));
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Цвет**

Используйте [createColorEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/behaviorfactory/#createColorEffect) для изменения заливки с синего на оранжевый. [getFrom](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/coloreffect/#getFrom) и [getTo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/coloreffect/#getTo) — это цвета; [getBy](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/coloreffect/#getBy) — цветовой сдвиг. [Behavior.getProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/behavior/#getProperties) определяет анимируемый атрибут.

Заливка фигуры изначально задаётся как сплошная синяя, что соответствует начальному цвету анимации. Выбор атрибута fill-color сообщает поведению, какую часть фигуры менять; сами конечные цвета не указывают, какой атрибут анимировать. Сохранённый эффект описывает двусекундный переход к оранжевому.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.ChangeFillColor, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const color = factory.createColorEffect();
    color.getProperties().add(aspose.slides.BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Фильтр**

Используйте [createFilterEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/behaviorfactory/#createFilterEffect) для выбора вытеснения. [getType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/filtereffect/#getSubtype) и [getReveal](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/filtereffect/#getReveal) задают фильтр, направление и то, будет ли фигура показываться или скрываться.

Пример настраивает двумсекундное вытеснение, показывающее фигуру с направлением вправо. Параметры фильтра принадлежат поведению внутри эффекта, поэтому их настраивают после удаления оригинальных операций предустановки.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Wipe, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const filter = factory.createFilterEffect();
    filter.setType(aspose.slides.FilterEffectType.Wipe);
    filter.setSubtype(aspose.slides.FilterEffectSubtype.Right);
    filter.setReveal(aspose.slides.FilterEffectRevealType.In);
    filter.getTiming().setDuration(2);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Свойство**

Используйте [createPropertyEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/behaviorfactory/#createPropertyEffect) для анимации непрозрачности. [getFrom](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/propertyeffect/#getTo) и [getBy](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/propertyeffect/#getBy) — строки, интерпретируемые с помощью [getValueType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/propertyeffect/#getValueType) и [getCalcMode](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/propertyeffect/#getCalcMode). Выбирайте конечные значения или относительный сдвиг, а не задавайте все три без разбора.

Здесь выбран атрибут opacity, а строковые значения представляют изменение от 25 % непрозрачности к полной. Линейная интерполяция описывает постепенный переход между этими значениями. При адаптации примера к другому атрибуту подберите тип значения и конечные точки, соответствующие этому атрибуту.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const property = factory.createPropertyEffect();
    property.getProperties().add(aspose.slides.BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(aspose.slides.PropertyValueType.Number);
    property.setCalcMode(aspose.slides.PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Установка**

Используйте [createSetEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/behaviorfactory/#createSetEffect) для назначения видимости через [getTo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/seteffect/#getTo). Поведение установки не интерполирует между конечными точками.

Пример выбирает атрибут visibility и присваивает строку `visible` при выполнении поведения. Прямоугольник уже видим в этой минимальной презентации, поэтому присваивание может не дать заметного визуального изменения само по себе. Такая операция полезна как часть более крупного эффекта, который также контролирует, когда фигура становится скрытой или видимой.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const set = factory.createSetEffect();
    set.getProperties().add(aspose.slides.BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Команда**

Используйте [createCommandEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/behaviorfactory/#createCommandEffect) и настройте [getType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/commandeffect/#getCommandString) и [getShapeTarget](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/commandeffect/#getShapeTarget). Поместите WAV‑запись `sample.wav` в рабочий каталог. Этот пример внедряет её с помощью [addAudioFrameEmbedded](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) и привязывает команду воспроизведения к аудио‑кадру.

Аудио‑кадр одновременно является целью эффекта и целью команды. Это связывает запрос воспроизведения с внедрённым звуком; одна лишь строка команды не указывает, какой медиа‑объект управлять. Эффект настроен запускаться по щелчку во время показа слайдов.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        const effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, aspose.slides.EffectType.MediaPlay, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        const factory = new aspose.slides.BehaviorFactory();
        const command = factory.createCommandEffect();
        command.setType(java.newByte(aspose.slides.CommandEffectType.Call));
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        audioStream.close();
    }
} finally {
    presentation.dispose();
}
```

Сохранение сохраняет команду в `command.pptx`; она не воспроизводит запись. Воспроизведение требует проигрывателя слайдов, поддерживающего данную команду и её медиа‑цель.

## **Управление коллекцией поведений**

[BehaviorCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/behaviorcollection/) поддерживает [add](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/behaviorcollection/#remove) и [removeAt](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/behaviorcollection/#removeAt). В этом примере открывается `rotation.pptx`, добавляется масштабирование, перемещается перед вращением и удаляется вращение. Удаление и повторная вставка одного и того же объекта меняет его сохранённую позицию без создания копии.

Последовательность правок меняет коллекцию из rotation–scale в scale–rotation, а затем только в scale. Индексы относятся к текущей коллекции, поэтому удаление использует новый индекс вращения после переупорядочения. Финальная переборка подтверждает, какое поведение будет сохранено.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const behaviors = effect.getBehaviors();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (let i = 0; i < behaviors.getCount(); i++) {
        const behavior = behaviors.get_Item(i);
        console.log(behavior.getClass().getSimpleName());
    }

    presentation.save("collection-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результатом является `ScaleEffect`: осталось только масштабирование. Порядок в коллекции сам по себе не планирует последовательное выполнение поведений. Очищайте коллекцию только когда заменяете все её операции.

## **Настройка тайминга поведения**

[Behavior.getTiming](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/behavior/#getTiming) раскрывает [Timing](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/timing/), независимо от [Effect.getTiming](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/effect/#getTiming). Тайминг эффекта планирует окружающий эффект; тайминг поведения описывает операцию внутри него.

### **Установить продолжительность, задержку, повтор и ускорение**

Откройте `rotation.pptx` и задайте продолжительность ([getDuration](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/timing/#getDuration)) и задержку триггера ([getTriggerDelayTime](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/timing/#getTriggerDelayTime)) в секундах, затем настройте количество повторов через [setRepeatCount](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/timing/#getAccelerate) и [getDecelerate](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/timing/#getDecelerate) задаются долями от общей продолжительности; их сумма должна быть не более 1.

Входной файл – тот, что был создан в примере вращения, где первое поведение известно как вращение. Этот пример меняет только тайминг этого поведения; его угол 90° остаётся неизменным. Разделение угла и тайминга упрощает корректировку скорости без необходимости перестраивать анимацию.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const rotation = effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2);
    rotation.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    rotation.getTiming().setRepeatCount(3);
    rotation.getTiming().setAccelerate(java.newFloat(0.2));
    rotation.getTiming().setDecelerate(java.newFloat(0.2));

    presentation.save("timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Поведение использует двухсекундную продолжительность, полсекундную задержку и три повтора. Первые и последние 20 % его длительности отведены под ускорение и замедление.

Другие политики повтора включают [getRepeatDuration](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide) и [getRepeatUntilNextClick](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick); выбирайте одну политику, а не включайте их все одновременно. [getAutoReverse](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/timing/#getAutoReverse) воспроизводит анимацию в обратном направлении после прямого прохода. Ускорение и замедление применяются к непрерывным изменениям, а не к дискретным назначениям или командам.

## **Создание траектории движения**

Используйте [createMotionEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/behaviorfactory/#createMotionEffect) для создания движения. Его [getFrom](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/motioneffect/#getTo) и [getBy](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/motioneffect/#getBy) описывают координаты или смещения в процентах. Для редактируемого маршрута создайте [MotionPath](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/motionpath/) и назначьте его через [MotionEffect.setPath](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/motioneffect/#setPath). [MotionPath](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/motionpath/) хранит команды пути.

[MotionCommandPathType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/motioncommandpathtype/) выбирает тип операции:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | Устанавливает начальную позицию. |
| LineTo | One | Движется по прямому отрезку к его конечной точке. |
| CurveTo | Three | Следует кубической кривой, определяемой двумя контрольными точками и конечной точкой. |
| CloseLoop | None | Возвращается к начальной позиции. |
| End | None | Завершает путь. |

[MotionPathPointsType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/motionpathpointstype/) описывает характеристики редактируемых точек, такие как угловые или плавные точки. Это не заменяет тип команды. Для примера с кривой используйте тип точки Curve, а для прямых отрезков — тип Corner.

Координаты пути нормированы к размерам слайда: смещение X = 0.25 соответствует одной четверти ширины слайда, а не 0.25 пунктам. Положительное Y идёт вниз. Абсолютные команды задают позиции в системе координат пути; относительные — смещения от текущей позиции. Это отдельно от [getOrigin](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/motioneffect/#getOrigin), который выбирает систему отсчёта пути, и [getPathEditMode](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/motioneffect/#getPathEditMode), управляющего тем, как путь движется при перемещении фигуры.

### **Создание прямой траектории**

Создайте движение с начальной точкой, одним прямым сегментом и командой завершения. [MotionPath.add](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/motionpath/#add) принимает тип команды, её точки, тип точки и флаг относительных координат.

Команда начала устанавливает (0, 0), а линия заканчивается в (0.25, 0), задавая горизонтальное смещение в одну четверть ширины слайда. Команда завершения не имеет координатных точек. После назначения пути добавление поведения движения к эффекту соединяет этот маршрут с прямоугольником.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.PathRight, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const motion = factory.createMotionEffect();
    motion.setOrigin(aspose.slides.MotionOriginType.Layout);
    motion.getTiming().setDuration(2);

    const path = new aspose.slides.MotionPath();
    path.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
    path.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.25), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.add(aspose.slides.MotionCommandPathType.End, java.newArray("java.awt.geom.Point2D$Float", []), aspose.slides.MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` содержит одно движение с тремя командами пути. Ниже приведённые примеры редактирования файлов используют эту известную структуру.

### **Сравнение абсолютных и относительных координат**

Эти два объекта пути описывают один и тот же маршрут. Абсолютная команда заканчивается в (0.3, 0.1); относительная добавляет (0.1, 0.1) к текущей позиции, получая (0.2, 0).

Оба пути начинаются в одной и той же позиции. Для относительной линии добавьте её смещения X и Y к текущей позиции, чтобы получить конечную точку; для абсолютной линии читайте конечную точку напрямую. Переключение флага без преобразования координат даст иной маршрут.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const absolutePath = new aspose.slides.MotionPath();
absolutePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
absolutePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);

const relativePath = new aspose.slides.MotionPath();
relativePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
relativePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, true);
```

Назначьте любой из путей движению, чтобы использовать его в презентации. Финальный булевый аргумент выбирает относительные координаты для этой команды.

### **Замена линии кривой**

Откройте `motion.pptx` и замените её команду линии кубической кривой. Сначала укажите две контрольные точки, затем конечную точку.

Начальная позиция берётся из предыдущей команды. Первые две точки формируют кривую, а третья — её конечную точку; они не являются тремя последовательными конечными точками. Одновременное обновление типа команды, типа точек и массива точек сохраняет сегмент согласованным с новой геометрией.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.get_Item(1).setCommandType(aspose.slides.MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(aspose.slides.MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]));

    presentation.save("curve.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Путь в `curve.pptx` всё ещё имеет три команды; теперь её средняя команда определяет кривую.

## **Просмотр и редактирование сохранённой траектории**

Каждый [MotionCmdPath](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/motioncmdpath/) раскрывает [getPoints](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/motioncmdpath/#getPointsType) и [isRelative](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/motioncmdpath/#isRelative). Ниже приведённые примеры используют известный трёхкомандный путь в `motion.pptx`. Для произвольного ввода найдите нужный эффект и проверьте типы команд и количество точек перед редактированием по индексу.

### **Чтение команд и координат**

Прочитайте путь без изменения. Команды End и CloseLoop не требуют точек, поэтому допускайте массив точек, равный null.

Вывод сопоставляет каждый числовой тип команды с её флагом относительных координат, а затем перечисляет её точки. Это позволяет отличить конечную точку от смещения перед изменением пути. Кривая будет перечислять три точки, тогда как прямой отрезок в этом файле содержит только одну.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    for (let i = 0; i < path.getCount(); i++) {
        const segment = path.get_Item(i);
        console.log(segment.getCommandType() + ", relative: " + segment.isRelative());
        const points = segment.getPoints();
        if (points != null) {
            for (const point of points) {
                console.log("X=" + point.getX() + ", Y=" + point.getY());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

В листинге присутствует начальная точка, абсолютная линия, заканчивающаяся в (0.25, 0), и команда End.

### **Изменение конечной точки**

Откройте `motion.pptx` и замените массив точек линии, чтобы переместить её конечную точку.

Во входном файле индекс 0 — начальная команда, индекс 1 — линия. Замена единственной точки линии меняет её назначение без изменения типа команды, тайминга или позиции в коллекции. Поскольку команда использует абсолютные координаты, новая пара определяет позицию, а не добавочный смещение.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const motion = effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.4), java.newFloat(0.1))]));

    presentation.save("motion-endpoint.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Линия в `motion-endpoint.pptx` заканчивается в (0.4, 0.1); оригинальный файл остаётся неизменным.

### **Замена сегмента**

Используйте [insert](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/motionpath/#insert) и [removeAt](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/motionpath/#removeAt) для замены линии в `motion.pptx`. Вставка смещает старую линию к индексу 2.

Это демонстрирует замену объекта команды, а не редактирование его существующих координат. После вставки коллекция временно состоит из начальной команды, новой линии, старой линии и команды End. Удаление индекса 2 удаляет старую линию, оставляя новый маршрут на месте.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.insert(1, aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сохранённый путь по‑прежнему имеет три команды; новая линия заканчивается в (0.2, 0.1), а команда End остаётся последней.

## **Изменение и проверка существующего поведения**

Когда индекс поведения неизвестен, выберите его по типу. Этот пример открывает `rotation.pptx`, ищет его [RotationEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/rotationeffect/), меняет угол и проверяет сохранённое значение после повторного открытия.

Проверка типа позволяет циклу пропускать поведения, которые не являются вращениями. Второе загрузка читает сохранённый файл в отдельный объект презентации, поэтому сравнение проверяет постоянные данные, а не значение, остаёющееся в памяти. Пример по‑прежнему предполагает, что известный эффект первый в основной последовательности; выбор поведения по типу не гарантирует нахождение правильного эффекта в произвольной презентации.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (let i = 0; i < effect.getBehaviors().getCount(); i++) {
        const behavior = effect.getBehaviors().get_Item(i);
        if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
            const rotation = behavior;
            rotation.setBy(180);
        }
    }

    presentation.save("rotation-edited.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("rotation-edited.pptx");
    try {
        const savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (let i = 0; i < savedEffect.getBehaviors().getCount(); i++) {
            const behavior = savedEffect.getBehaviors().get_Item(i);
            if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
                const rotation = behavior;
                console.log("Rotation preserved: " + (Math.abs(rotation.getBy() - 180) < 0.001));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Вывод: `Rotation preserved: true`. Применяйте тот же паттерн проверки типа к другим поведениям. Для полной проверки сохранения сравнивайте целевую фигуру, типы эффекта и поведения, порядок, тайминг и команды пути. Для фигур с неизвестной анимационной структурой см. [Read Shape Animations](/slides/ru/nodejs-java/shape-animation/#read-shape-animations) для обхода главных и интерактивных последовательностей.

## **Порядок поведения, предустановки и воспроизведение**

Порядок в [BehaviorCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/behaviorcollection/) — это сохранённый порядок операций эффекта. Это не плейлист, в котором каждое последующее действие автоматически ждёт завершения предыдущего. Тайминг и окружающий эффект определяют расписание. Поведения могут перекрываться, и операции над одним и тем же свойством могут взаимодействовать через [getAdditive](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/behavior/#getAdditive) и [getAccumulate](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/behavior/#getAccumulate). Не используйте просто переупорядочивание коллекции, чтобы задать «сначала переместить, затем вращать»; применяйте явный тайминг или отдельные эффекты, как описано в [Анимации фигур](/slides/ru/nodejs-java/shape-animation/).

[Effect.getType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/effect/#getType) и [Effect.getSubtype](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/effect/#getSubtype) описывают предустановку. Они не дают полного описания отредактированного дерева поведения. Выберите предустановку и подтип до кастомизации поведений: изменение предустановки может перестроить коллекцию и удалить ваши пользовательские операции. Например, изменение пользовательского эффекта Spin на Fade может заменить его поведение вращения на поведения set и filter. После изменения предустановки или подтипа снова проверьте коллекцию. Очистка предустановочных поведений также может удалить операции видимости или инициализации, необходимые предустановке. Примеры используют видимые фигуры и заменяют их поведения; они не перестраивают полностью реализацию каждой предустановки.

## **Совместимость форматов**

Сохранённое дерево поведения не гарантирует идентичное воспроизведение во всех средствах просмотра или экспортных рендерах. Проверяйте сохранённые данные и отрисованный вывод раздельно.

| Формат или вывод | Что проверять |
| --- | --- |
| PPTX | Используйте как основной формат для этих примеров. Откройте его повторно, чтобы убедиться в сохранности редактируемого дерева поведения, затем проверьте воспроизведение в целевой версии PowerPoint. |
| PPT | Устаревшее бинарное представление может отличаться от PPTX. Протестируйте отдельный цикл сохранения‑загрузки и воспроизведения; не делайте вывод о поддержке всех комбинаций только по успешному выводу PPTX. |
| PDF, PNG, JPEG и другие статические изображения слайдов | Содержат статическое представление слайда, а не воспроизводимую временную шкалу поведения или гарантированный конечный кадр анимации. |
| [HTML5](/slides/ru/nodejs-java/export-to-html5/) | Может проигрывать поддерживаемые анимации при включённой анимации фигур в параметрах экспорта. Тестируйте пользовательские комбинации в браузере. |
| [Animated GIF](/slides/ru/nodejs-java/convert-powerpoint-to-animated-gif/) | Сохраняет отрисованные кадры, а не редактируемые поведения или интерактивные клики. Проверьте реальное отрисованное движение. |
| [Video](/slides/ru/nodejs-java/convert-powerpoint-to-video/) | Рендерит кадры анимации и кодирует их в видео. Поддержка ограничена [поддерживаемыми анимациями и эффектами](/slides/ru/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects); команды и интерактивные события не становятся редактируемой временной шкалой. |

## **Вопросы и ответы**

**Почему мой эффект содержит поведения до того, как я их добавил?**

Создание предустановленного эффекта может сразу создать его базовые операции. Просмотрите их, прежде чем решать, расширять предустановку или заменять её поведения.

**Перемещение поведения в начало заставит его воспроизводиться первым?**

Не обязательно. Порядок в коллекции не заменяет тайминг. Проверьте задержки, продолжительности и взаимодействия между операциями над одним свойством.

**Почему команда End не имеет точек?**

Она отмечает конец пути и не требует координат. При проверке пути, считанного из файла, учитывайте возможность null‑массива точек.

**Достаточно ли успешного цикла сохранения‑загрузки для подтверждения воспроизведения?**

Нет. Повторное открытие подтверждает сохранность проверенных свойств. Тестируйте проигрыватель слайдов или экспорт анимации отдельно, чтобы убедиться в визуальном поведении.