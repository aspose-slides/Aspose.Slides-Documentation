---
title: Создание и изменение пользовательских анимационных поведений в Java
linktitle: Пользовательская анимация
type: docs
weight: 151
url: /ru/java/custom-animation/
keywords:
- пользовательская анимация
- поведение анимации
- траектория движения
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Создавать, просматривать и изменять пользовательские анимационные поведения и редактируемые траектории движения в презентациях PowerPoint с помощью Aspose.Slides для Java."
---
## **Обзор**

Пользовательские анимационные поведения позволяют управлять отдельными операциями внутри анимационного эффекта, такими как изменение цвета, вращение фигуры или следование по редактируемой траектории движения. В этом руководстве показано, как создавать и комбинировать поведения, настраивать их синхронизацию, просматривать и изменять существующие анимации, а также проверять, сохраняются ли их свойства при сохранении и повторном открытии презентации.

Для предустановленных эффектов и триггеров клика см. [Анимация фигур](/slides/ru/java/shape-animation/).

## **Понимание модели анимации**

Анимация организована как **Timeline → Sequence → Effect → Behaviors**:

- Метод [getTimeline](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseslide/#getTimeline--) возвращает таймлайн слайда, который содержит его основную последовательность и интерактивные последовательности.
- [ISequence](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isequence/) содержит эффекты, потенциально направленные на разные фигуры.
- [IEffect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ieffect/) определяет целевую фигуру, предустановку, подтип и синхронизацию эффекта.
- Коллекция, возвращаемая [IEffect.getBehaviors](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ieffect/#getBehaviors--), содержит операции, реализующие эффект: изменение цвета, перемещение, вращение, установка свойства и т.д.

## **Создание отдельных поведений**

Вызовите [ISequence.addEffect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) для создания эффекта и доступа к коллекции [getBehaviors](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ieffect/#getBehaviors--). Предустановка может автоматически заполнить эту коллекцию. Сохраните её операции при расширении предустановки или используйте [clear](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibehaviorcollection/#clear--) при сознательной замене.

[IBehaviorFactory](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibehaviorfactory/) создаёт восемь типов поведений, показанных ниже. Движение рассматривается в разделе [Создание траектории движения](#build-a-motion-path). Каждый фрагмент кода включает свои импорты; размещайте исполняемые инструкции внутри метода. В примерах последующего редактирования указано, какой файл‑вывод они используют.

### **Вращение**

Используйте [createRotationEffect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) для создания вращения. [getBy](https://reference.aspose.com/slides/ru/java/com.aspose.slides/irotationeffect/#getBy--) указывает относительный угол в градусах; [getFrom](https://reference.aspose.com/slides/ru/java/com.aspose.slides/irotationeffect/#getFrom--) и [getTo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/irotationeffect/#getTo--) задают конечные точки.

Пример начинается с эффекта Spin, заменяет его предустановленные операции одним поведением вращения и задаёт этому поведению длительность два секунды. Относительный угол 90 градусов представляет четверть оборота от исходной ориентации фигуры, поэтому явный начальный угол не требуется.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IRotationEffect rotation = factory.createRotationEffect();
    rotation.setBy(90f);
    rotation.getTiming().setDuration(2f);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` содержит одну фигуру и одно поведение вращения. Коллекция, синхронизация и примеры редактирования вращения ниже используют этот файл.

### **Масштаб**

Используйте [createScaleEffect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) с процентами X/Y: [getFrom](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iscaleeffect/#getFrom--) и [getTo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iscaleeffect/#getTo--) описывают начальный и конечный размер, а [getBy](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iscaleeffect/#getBy--) описывает относительное изменение. Здесь 100 означает исходный размер.

Пример увеличивает обе измерения с 100 % до 125 % за две секунды. Использование одинаковых горизонтальных и вертикальных процентов сохраняет пропорции фигуры; разные проценты растягивают одну из сторон сильнее.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new Point2D.Float(100, 100));
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Цвет**

Используйте [createColorEffect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibehaviorfactory/#createColorEffect--) для изменения заливки с синего на оранжевый. [getFrom](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icoloreffect/#getFrom--) и [getTo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icoloreffect/#getTo--) – это цвета; [getBy](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icoloreffect/#getBy--) – смещение цвета. [IBehavior.getProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibehavior/#getProperties--) определяет атрибут, который анимируется.

Заливка фигуры изначально установлена в синий, что соответствует начальному цвету анимации. Выбор атрибута заливки указывает поведению, какую часть фигуры менять; сами конечные цвета атрибут не определяют. Сохранённый эффект описывает двухсекундный переход к оранжевому.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IColorEffect color = factory.createColorEffect();
    color.getProperties().add(BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(Color.BLUE);
    Color orange = new Color(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Фильтр**

Используйте [createFilterEffect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) для выбора стирания. [getType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifiltereffect/#getSubtype--), и [getReveal](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifiltereffect/#getReveal--) задают тип фильтра, направление и то, будет ли фигура раскрыта или скрыта.

Этот пример конфигурирует двухсекундный стирающий эффект, который раскрывает фигуру с направлением «вправо». Параметры фильтра принадлежат поведению внутри эффекта, поэтому они настраиваются после удаления оригинальных операций предустановки.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IFilterEffect filter = factory.createFilterEffect();
    filter.setType(FilterEffectType.Wipe);
    filter.setSubtype(FilterEffectSubtype.Right);
    filter.setReveal(FilterEffectRevealType.In);
    filter.getTiming().setDuration(2f);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Свойство**

Используйте [createPropertyEffect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) для анимации непрозрачности. [getFrom](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipropertyeffect/#getTo--), и [getBy](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipropertyeffect/#getBy--) – строки, интерпретируемые с помощью [getValueType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipropertyeffect/#getValueType--) и [getCalcMode](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipropertyeffect/#getCalcMode--). Выбирайте конечные значения или относительное смещение, а не задавайте все три без разбора.

Здесь выбранный атрибут – непрозрачность, а числовые строки представляют изменение от 25 % к полной непрозрачности. Линейная интерполяция описывает постепенное изменение между этими значениями. При адаптации примера к другому атрибуту выберите тип значения и конечные значения, соответствующие этому атрибуту.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IPropertyEffect property = factory.createPropertyEffect();
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(PropertyValueType.Number);
    property.setCalcMode(PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2f);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Установка**

Используйте [createSetEffect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibehaviorfactory/#createSetEffect--) для задания видимости через [getTo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iseteffect/#getTo--). Поведение «set» не интерполирует между конечными точками.

Пример выбирает атрибут видимости и присваивает строку `visible` при выполнении поведения. Прямоугольник уже видим в этой минимальной презентации, поэтому присваивание может не вызвать заметного визуального изменения само по себе. Такая операция полезна как часть более крупного эффекта, который также управляет моментом скрытия или отображения фигуры.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    ISetEffect set = factory.createSetEffect();
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Команда**

Используйте [createCommandEffect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) и настройте [getType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icommandeffect/#getCommandString--), и [getShapeTarget](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icommandeffect/#getShapeTarget--). Поместите WAV‑запись `sample.wav` в рабочий каталог. Этот пример внедряет её с помощью [addAudioFrameEmbedded](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) и привязывает команду воспроизведения к аудиофрейму.

Аудиофрейм является одновременно целью эффекта и целью команды. Это связывает запрос воспроизведения с внедрённой записью; сама строка команды не указывает, какой медиа‑объект контролировать. Эффект настроен на запуск по щелчку во время показа.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    try (FileInputStream audioStream = new FileInputStream("sample.wav")) {
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        IEffect effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        IBehaviorFactory factory = new BehaviorFactory();
        ICommandEffect command = factory.createCommandEffect();
        command.setType(CommandEffectType.Call);
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Unable to read sample.wav: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

Сохранение сохраняет команду в `command.pptx`; она не воспроизводит запись. Воспроизведение требует проигрывателя слайдов, поддерживающего данную команду и её медиа‑цель.

## **Управление коллекцией поведений**

[IBehaviorCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibehaviorcollection/) поддерживает [add](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), и [removeAt](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibehaviorcollection/#removeAt-int-). Этот пример открывает `rotation.pptx`, добавляет масштабирование, перемещает его перед вращением и удаляет вращение. Удаление и повторная вставка того же объекта меняют его сохранённую позицию без создания копии.

Последовательность правок меняет коллекцию с rotation–scale на scale–rotation, затем оставляет только масштаб. Индексы относятся к текущей коллекции, поэтому удаление использует новый индекс вращения после переупорядочения. Финальный перебор подтверждает, какое поведение будет сохранено.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (IBehavior behavior : behaviors)
        System.out.println(behavior.getClass().getSimpleName());

    presentation.save("collection-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результатом является `ScaleEffect`: остаётся только масштабирование. Порядок в коллекции сам по себе не задаёт последовательное воспроизведение поведений. Очищать коллекцию следует только при полном замещении её операций.

## **Настройка синхронизации поведения**

[IBehavior.getTiming](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibehavior/#getTiming--) раскрывает [ITiming](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itiming/), независимо от [IEffect.getTiming](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ieffect/#getTiming--). Синхронизация эффекта планирует весь эффект, а синхронизация поведения описывает операцию внутри него.

### **Установка длительности, задержки, повторений и ускорения**

Откройте `rotation.pptx` и задайте длительность ([getDuration](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itiming/#getDuration--)) и задержку триггера ([getTriggerDelayTime](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itiming/#getTriggerDelayTime--)) в секундах, затем настройте количество повторов через [setRepeatCount](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itiming/#setRepeatCount-float-). [getAccelerate](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itiming/#getAccelerate--) и [getDecelerate](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itiming/#getDecelerate--) – доли от общей длительности; их сумма не должна превышать 1.

Входной файл – тот, что был создан в примере вращения, где первое поведение известно как вращение. Этот пример меняет только синхронизацию этого поведения; угол в 90 градусов остаётся неизменным. Разделение угла и синхронизации упрощает настройку темпа без переработки всей анимации.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IRotationEffect rotation = (IRotationEffect)effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2f);
    rotation.getTiming().setTriggerDelayTime(0.5f);
    rotation.getTiming().setRepeatCount(3f);
    rotation.getTiming().setAccelerate(0.2f);
    rotation.getTiming().setDecelerate(0.2f);

    presentation.save("timing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Поведение использует длительность две секунды, задержку полсекунды и количество повторов = 3. Первые и последние 20 % длительности отводятся ускорению и замедлению.

Другие политики повторов включают [getRepeatDuration](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), и [getRepeatUntilNextClick](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--); выбирайте одну политику, а не включайте их все одновременно. [getAutoReverse](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itiming/#getAutoReverse--) воспроизводит анимацию в обратном направлении после прямого прохода. Ускорение и замедление применяются к непрерывным изменениям, а не к дискретным присваиваниям или командам.

## **Создание траектории движения**

Используйте [createMotionEffect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) для создания движения. Его [getFrom](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imotioneffect/#getTo--), и [getBy](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imotioneffect/#getBy--) описывают координаты или смещения в процентах. Для редактируемого маршрута создайте [MotionPath](https://reference.aspose.com/slides/ru/java/com.aspose.slides/motionpath/) и назначьте его с помощью [IMotionEffect.setPath](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-). [IMotionPath](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imotionpath/) хранит команды пути.

[MotionCommandPathType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/motioncommandpathtype/) выбирает операцию:

| Команда | Точки | Значение |
| --- | --- | --- |
| MoveTo | Одна | Устанавливает начальную позицию. |
| LineTo | Одна | Движется по прямому отрезку к его конечной точке. |
| CurveTo | Три | Следует кубической кривой, определяемой двумя контрольными точками и конечной точкой. |
| CloseLoop | Нет | Возвращается к начальной позиции. |
| End | Нет | Завершает путь. |

[MotionPathPointsType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/motionpathpointstype/) описывает характер редактирования точек, например угловые или гладкие точки. Это не заменяет тип команды. Для кривой используйте тип точек curve, а для прямых сегментов – тип corner.

Координаты пути нормализованы по размерам слайда: смещение X = 0.25 соответствует одной четверти ширины слайда, а не 0.25 пунктам. Положительный Y идёт вниз. Абсолютные команды указывают позиции в системе координат пути; относительные – смещения от текущей позиции. Это отдельный параметр от [getOrigin](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imotioneffect/#getOrigin--), который выбирает референтную систему пути, и от [getPathEditMode](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imotioneffect/#getPathEditMode--), управляющего тем, как путь перемещается вместе с фигурой.

### **Создание прямого пути**

Создайте поведение движения с начальной точкой, одним прямым сегментом и командой завершения. [IMotionPath.add](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imotionpath/#add-int-java.awt.geom.Point2D.Float---int-boolean-) принимает тип команды, её точки, тип точек и флаг относительных координат.

Начальная команда задаёт (0, 0), а линия заканчивается в (0.25, 0), давая маршруту горизонтальное смещение в одну четверть ширины слайда. Команда завершения не имеет координатных точек. После назначения пути добавление поведения движения к эффекту связывает этот маршрут с прямоугольником.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IMotionEffect motion = factory.createMotionEffect();
    motion.setOrigin(MotionOriginType.Layout);
    motion.getTiming().setDuration(2f);

    IMotionPath path = new MotionPath();
    path.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new Point2D.Float[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` содержит одно движение с тремя командами пути. Далее приведённые примеры редактирования файлов используют эту известную структуру.

### **Сравнение абсолютных и относительных координат**

Эти два объекта пути описывают один и тот же маршрут. Абсолютная команда заканчивается в (0.3, 0.1); относительная команда прибавляет (0.1, 0.1) к текущей позиции, получая (0.2, 0).

Оба пути начинаются из одной позиции. Для относительной линии добавьте её смещения X и Y к текущей позиции, чтобы получить конечную точку; для абсолютной – читайте конечную точку напрямую. Переключение флага без преобразования координат даст иной маршрут.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Назначьте любой из путей поведению движения, чтобы использовать его в презентации. Последний логический аргумент выбирает относительные координаты для этой команды.

### **Замена линии кривой**

Откройте `motion.pptx` и замените её команду линии кубической кривой. Сначала укажите две контрольные точки, затем конечную точку.

Начальная позиция задаётся предыдущей командой. Первые две точки формируют кривую, а третья – её конечную точку; они не являются тремя последовательными конечными точками. Одновременное обновление типа команды, типа редактирования точек и массива точек сохраняет согласованность сегмента с новой геометрией.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.1f, 0), new Point2D.Float(0.2f, 0.1f), new Point2D.Float(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Путь в `curve.pptx` по‑прежнему имеет три команды; теперь его средняя команда определяет кривую.

## **Просмотр и редактирование сохранённого пути**

Каждый [IMotionCmdPath](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imotioncmdpath/) раскрывает [getPoints](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imotioncmdpath/#getPointsType--), и [isRelative](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imotioncmdpath/#isRelative--). Ниже приведённые примеры используют известный трёхкомандный путь в `motion.pptx`. Для произвольного ввода сначала найдите нужный эффект и проверьте типы команд и количество точек перед редактированием по индексу.

### **Чтение команд и координат**

Чтение пути без его изменения. Команды End и CloseLoop не требуют точек, поэтому допускайте массив точек, равный null.

Вывод сопоставляет каждый числовой тип команды с её флагом относительных координат перед перечислением точек. Это позволяет различать конечную точку и смещение перед изменением пути. Кривая будет перечислять три точки, тогда как прямая линия в этом файле – только одну.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (Point2D.Float point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

Список содержит начальную точку, абсолютную линию, заканчивающуюся в (0.25, 0), и команду End.

### **Изменение конечной точки**

Откройте `motion.pptx` и замените массив точек линии, переместив её конечную точку.

В входном файле индекс 0 – начальная команда, индекс 1 – линия. Замена единственной точки линии меняет её пункт назначения без изменения типа команды, синхронизации или позиции в коллекции. Поскольку команда использует абсолютные координаты, новая пара указывает позицию, а не добавочный смещение.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Линия в `motion-endpoint.pptx` заканчивается в (0.4, 0.1); оригинальный файл остаётся без изменений.

### **Замена сегмента**

Используйте [insert](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imotionpath/#insert-int-int-java.awt.geom.Point2D.Float---int-boolean-) и [removeAt](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imotionpath/#removeAt-int-) для замены линии в `motion.pptx`. Вставка сдвигает старую линию к индексу 2.

Это демонстрирует замену объекта команды, а не редактирование его текущих координат. После вставки коллекция временно содержит начальную команду, новую линию, старую линию и команду End. Удаление индекса 2 отбрасывает старую линию, оставляя новый маршрут на месте.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сохранённый путь всё ещё содержит три команды, новая линия заканчивается в (0.2, 0.1), а команда End остаётся последней.

## **Изменение и проверка существующего поведения**

Когда индекс поведения неизвестен, выберите его по типу. Этот пример открывает `rotation.pptx`, ищет [IRotationEffect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/irotationeffect/), меняет угол и проверяет сохранённое значение после повторного открытия.

Проверка типа позволяет пропустить поведения, не являющиеся вращениями. Второй загрузка читает сохранённый файл в отдельный объект презентации, поэтому сравнение проверяет устойчивые данные, а не значение, оставшееся в памяти. Пример по‑прежнему предполагает, что известный эффект первый в основной последовательности; выбор поведения по типу не находит нужный эффект в произвольной презентации.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (IBehavior behavior : effect.getBehaviors())
    {
        if (behavior instanceof IRotationEffect) {
            IRotationEffect rotation = (IRotationEffect) behavior;
            rotation.setBy(180f);
        }
    }

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("rotation-edited.pptx");
    try {
        IEffect savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (IBehavior behavior : savedEffect.getBehaviors())
        {
            if (behavior instanceof IRotationEffect) {
                IRotationEffect rotation = (IRotationEffect) behavior;
                System.out.println("Rotation preserved: " + (Math.abs(rotation.getBy() - 180f) < 0.001f));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Вывод: `Rotation preserved: true`. Применяйте такой же паттерн проверки типа к другим поведениям. Для полного контроля сравните целевую фигуру, эффект, типы и порядок поведений, синхронизацию и команды пути. Используйте числовой допуск для значений с плавающей точкой. Для презентаций с неизвестной структурой анимации см. [Чтение анимаций фигур](/slides/ru/java/shape-animation/#read-shape-animations) для обхода основных и интерактивных последовательностей.

## **Порядок поведений, предустановки и воспроизведение**

Порядок в [IBehaviorCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibehaviorcollection/) – это сохранённый порядок операций эффекта. Это не плейлист, в котором каждое поведение автоматически ждёт предыдущее. Синхронизация и окружающий эффект определяют планирование. Поведения могут накладываться, а операции над одним и тем же свойством могут взаимодействовать через [getAdditive](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibehavior/#getAdditive--) и [getAccumulate](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibehavior/#getAccumulate--). Не используйте простое переупорядочивание коллекции для планирования «сдвиг, затем вращение»; применяйте явную синхронизацию или отдельные эффекты, как описано в [Анимация фигур](/slides/ru/java/shape-animation/).

[IEffect.getType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ieffect/#getType--) и [IEffect.getSubtype](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ieffect/#getSubtype--) описывают предустановку эффекта. Это не полное описание отредактированного дерева поведений. Выбирайте предустановку и подтип до кастомизации поведений: изменение предустановки может перестроить коллекцию и удалить ваши пользовательские операции. Например, изменение настроенного эффекта Spin на Fade может заменить его поведение вращения на поведения set и filter. После изменения предустановки или подтипа снова проверьте коллекцию. Очистка предустановленных поведений может также удалить операции видимости или инициализации, необходимые предустановке. Примеры сознательно используют видимые фигуры и заменяют поведения; они не перестраивают полную реализацию каждой предустановки.

## **Совместимость форматов**

Сохранённое дерево поведений не гарантирует идентичное воспроизведение во всех средствах просмотра или экспортных рендерерах. Проверяйте сохранённые данные и отрендеренный вывод отдельно.

| Формат или вывод | Что проверять |
| --- | --- |
| PPTX | Используйте как основной формат для этих примеров. Откройте файл повторно, чтобы проверить редактируемое дерево поведений, затем проверьте воспроизведение в целевой версии PowerPoint. |
| PPT | Устаревшее бинарное представление может отличаться от PPTX. Выполните отдельный цикл сохранения‑повторного открытия и проверьте воспроизведение; не делайте выводы о поддержке каждой пользовательской комбинации исключительно по успешному PPTX‑выводу. |
| PDF, PNG, JPEG и другие статические изображения слайдов | Содержат статическое представление слайда, а не проигрываемую временную линию поведения или гарантированный конечный кадр анимации. |
| [HTML5](/slides/ru/java/export-to-html5/) | Может воспроизводить поддерживаемые анимации, когда в параметрах экспорта включена анимация фигур. Тестируйте пользовательские комбинации в браузере. |
| [Animated GIF](/slides/ru/java/convert-powerpoint-to-animated-gif/) | Сохраняет отрендеренные кадры, а не редактируемые поведения или интерактивные триггеры. Проверяйте фактическое отрендеренное движение. |
| [Video](/slides/ru/java/convert-powerpoint-to-video/) | Рендерит кадры анимации и кодирует их в видео. Поддержка ограничена [поддерживаемыми анимациями и эффектами](/slides/ru/java/convert-powerpoint-to-video/#supported-animations-and-effects); команды и интерактивные события не становятся редактируемой временной линией. |

## **FAQ**

**Почему мой эффект уже содержит поведения, хотя я ничего не добавлял?**

Создание предустановленного эффекта может создать его внутренние операции. Просмотрите их, прежде чем решать, расширять предустановку или заменять её поведения.

**Если перенести поведение в начало, будет ли оно воспроизводиться первым?**

Не обязательно. Порядок в коллекции не заменяет синхронизацию. Проверьте задержки, длительности и взаимодействия операций над одним и тем же свойством.

**Почему у команды End нет точек?**

Она обозначает конец пути и не требует координат. При просмотре пути, считанного из файла, проверяйте наличие массива точек, равного null.

**Достаточно ли успешного кругового прохода, чтобы подтвердить воспроизведение?**

Нет. Повторное открытие подтверждает сохранность проверенных свойств. Тестируйте проигрыватель слайдов или экспорт анимации отдельно, чтобы подтвердить визуальное поведение.