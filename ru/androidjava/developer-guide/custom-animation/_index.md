---
title: Создание и изменение пользовательских анимационных поведений на Android
linktitle: Пользовательская анимация
type: docs
weight: 151
url: /ru/androidjava/custom-animation/
keywords:
- пользовательская анимация
- поведение анимации
- путь движения
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Создавайте, просматривайте и изменяйте пользовательские анимационные поведения и редактируемые пути движения в презентациях PowerPoint с помощью Aspose.Slides для Android на Java."
---
## **Обзор**

Пользовательские анимационные поведения позволяют управлять отдельными операциями внутри анимационного эффекта, например изменять цвет, вращать объект или следовать по редактируемому пути движения. Это руководство показывает, как создавать и комбинировать поведения, настраивать их тайминг, просматривать и изменять существующие анимации, а также проверять, сохраняются ли их свойства при сохранении и повторном открытии презентации.

Для предустановленных эффектов и триггеров щелчка см. [Shape Animation](/slides/ru/androidjava/shape-animation/).

## **Поймите модель анимации**

Анимация организована как **Timeline → Sequence → Effect → Behaviors**:

- Метод [getTimeline](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseslide/#getTimeline--) возвращает временную шкалу слайда, которая содержит её основную последовательность и интерактивные последовательности.
- [ISequence](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isequence/) содержит эффекты, потенциально применяемые к разным фигурам.
- [IEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ieffect/) определяет целевую фигуру, предустановку, подтип и тайминг эффекта.
- Коллекция, возвращаемая [IEffect.getBehaviors](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ieffect/#getBehaviors--), содержит операции, реализующие эффект: изменение цвета, перемещение, вращение, установка свойства и т.д.

## **Создание отдельных поведений**

Вызовите [ISequence.addEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) для создания эффекта и доступа к коллекции [getBehaviors](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ieffect/#getBehaviors--). Предустановка может автоматически заполнить эту коллекцию. Сохраните её операции при расширении предустановки или используйте [clear](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibehaviorcollection/#clear--) при намеренной замене.

[IBehaviorFactory](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibehaviorfactory/) создает восемь типов поведений, показанных ниже. Движение рассматривается в разделе [Build a Motion Path](#build-a-motion-path). Каждый фрагмент кода включает свои импорты; размещайте исполняемые инструкции внутри метода. Примеры последующего редактирования указывают, какой файл вывода они используют. На Android замените имена файлов образцов полными путями в директории, доступной приложению, например в директории файлов вашего приложения.

### **Вращение**

Используйте [createRotationEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) для создания вращения. [getBy](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/irotationeffect/#getBy--) задаёт относительный угол в градусах; [getFrom](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/irotationeffect/#getFrom--) и [getTo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/irotationeffect/#getTo--) задают конечные точки.

Пример начинается с эффекта Spin, заменяет его предустановленные операции одним поведением вращения и задаёт этой операции длительность две секунды. Относительный угол 90 градусов представляет четверть оборота от исходной ориентации фигуры, поэтому отдельный начальный угол не требуется.

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

`rotation.pptx` содержит одну фигуру и одно поведение вращения. Ниже приведённые примеры коллекции, тайминга и редактирования вращения используют этот файл.

### **Масштаб**

Используйте [createScaleEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) с процентами X/Y: [getFrom](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iscaleeffect/#getFrom--) и [getTo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iscaleeffect/#getTo--) описывают начальный и конечный размер, а [getBy](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iscaleeffect/#getBy--) описывает относительное изменение. Здесь 100 означает исходный размер.

Пример увеличивает обе размеры с 100 % до 125 % за две секунды. Использование одинаковых горизонтальных и вертикальных процентов сохраняет пропорции фигуры; разные проценты растягивают одну из осей сильнее другой.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new PointF(100, 100));
    scale.setTo(new PointF(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Цвет**

Используйте [createColorEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibehaviorfactory/#createColorEffect--) для изменения заливки с синего на оранжевый. [getFrom](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icoloreffect/#getFrom--) и [getTo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icoloreffect/#getTo--) – это цвета; [getBy](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icoloreffect/#getBy--) – смещение цвета. [IBehavior.getProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibehavior/#getProperties--) определяет анимируемый атрибут.

Заливка фигуры изначально установлена в синий, что соответствует начальному цвету анимации. Выбор атрибута заливка‑цвет сообщает поведению, какую часть фигуры менять; сами конечные цвета не указывают атрибут. Сохранённый эффект описывает двухсекундный переход к оранжевому.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int orange = Color.rgb(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Фильтр**

Используйте [createFilterEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) для выбора вытирания. [getType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifiltereffect/#getSubtype--), и [getReveal](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifiltereffect/#getReveal--) задают фильтр, направление и то, раскрывать или скрывать фигуру.

В этом примере настраивается двухсекундное вытирание, раскрывающее фигуру с подтипом правого направления. Параметры фильтра принадлежат поведению внутри эффекта, поэтому они конфигурируются после удаления оригинальных операций предустановки.

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

Используйте [createPropertyEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) для анимации непрозрачности. [getFrom](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipropertyeffect/#getTo--), и [getBy](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipropertyeffect/#getBy--) – строки, интерпретируемые с помощью [getValueType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipropertyeffect/#getValueType--) и [getCalcMode](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipropertyeffect/#getCalcMode--). Выбирайте конечные точки или относительное смещение, а не задавайте все три параметра без различия.

Здесь выбранный атрибут – непрозрачность, а числовые строки представляют переход от 25 % непрозрачности к полной непрозрачности. Линейная интерполяция описывает постепенное изменение между этими значениями. При адаптации примера к другому атрибуту выбирайте тип значения и конечные точки, соответствующие этому атрибуту.

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

Используйте [createSetEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibehaviorfactory/#createSetEffect--) для назначения видимости через [getTo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iseteffect/#getTo--). Поведение установки не интерполирует между конечными точками.

Пример выбирает атрибут видимости и присваивает строку `visible` при выполнении поведения. Прямоугольник уже видим в этой минимальной презентации, поэтому присваивание может не дать очевидного визуального изменения само по себе. Такая операция полезна как часть более сложного эффекта, который также управляет скрытием или отображением фигуры.

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

Используйте [createCommandEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) и настройте [getType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icommandeffect/#getCommandString--), и [getShapeTarget](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icommandeffect/#getShapeTarget--). Поместите WAV‑запись `sample.wav` в рабочий каталог. Этот пример встраивает её с помощью [addAudioFrameEmbedded](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) и привязывает команду воспроизведения к аудио‑кадру.

Аудио‑кадр одновременно является целью эффекта и целью команды. Это связывает запрос воспроизведения с вложённой записью; строка команды сама по себе не указывает, какой медиа‑объект управлять. Эффект настроен на запуск по щелчку во время показа слайдов.

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

Сохранение сохраняет команду в `command.pptx`; запись не воспроизводится. Для воспроизведения нужен проигрыватель слайдов, поддерживающий команду и её медиа‑цель.

## **Управление коллекцией поведений**

[IBehaviorCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibehaviorcollection/) поддерживает [add](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), и [removeAt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibehaviorcollection/#removeAt-int-). Этот пример открывает `rotation.pptx`, добавляет масштабирование, перемещает его перед вращением и удаляет вращение. Удаление и повторная вставка того же объекта меняет его сохранённую позицию без создания копии.

Последовательность правок меняет коллекцию с rotation‑scale на scale‑rotation, а затем только на scale. Индексы относятся к текущей коллекции, поэтому удаление использует новый индекс вращения после переупорядочения. Финальное перечисление подтверждает, какие поведения будут сохранены.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new PointF(125, 125));
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

Результат – `ScaleEffect`: остаётся только масштабирование. Порядок в коллекции сам по себе не планирует последовательное выполнение поведений. Очищайте коллекцию только при полном замещении её операций.

## **Настройка тайминга поведения**

[IBehavior.getTiming](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibehavior/#getTiming--) открывает [ITiming](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/), независимо от [IEffect.getTiming](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ieffect/#getTiming--). Тайминг эффекта планирует охватывающий эффект; тайминг поведения описывает операцию внутри него.

### **Установить длительность, задержку, повтор и ускорение**

Откройте `rotation.pptx` и задайте длительность ([getDuration](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#getDuration--)) и задержку триггера ([getTriggerDelayTime](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--)) в секундах, затем настройте количество повторов через [setRepeatCount](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-). [getAccelerate](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#getAccelerate--) и [getDecelerate](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#getDecelerate--) – доли от длительности; их сумма не должна превышать 1.

Входной файл – тот, что был создан в примере вращения, где первое поведение известно как вращение. Этот пример меняет только тайминг этого поведения; угол 90° остаётся без изменений. Разделение угла и тайминга упрощает настройку скорости без перестройки анимации.

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

Поведение использует длительность две секунды, задержку полсекунды и количество повторов 3. Первые и последние 20 % длительности отводятся ускорению и замедлению.

Другие политики повторов включают [getRepeatDuration](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), и [getRepeatUntilNextClick](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--); выбирайте одну политику, а не включайте их все одновременно. [getAutoReverse](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#getAutoReverse--) воспроизводит анимацию в обратном порядке после прямого прохода. Ускорение и замедление применимы к непрерывным изменениям, а не к дискретным назначениям или командам.

## **Создание пути движения**

Используйте [createMotionEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) для создания движения. Его [getFrom](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imotioneffect/#getTo--), и [getBy](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imotioneffect/#getBy--) описывают координаты или смещения в процентах. Для редактируемого маршрута создайте [MotionPath](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/motionpath/) и присвойте её через [IMotionEffect.setPath](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-). [IMotionPath](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imotionpath/) хранит команды пути.

[MotionCommandPathType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/motioncommandpathtype/) выбирает операцию:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | Установить начальную позицию. |
| LineTo | One | Перейти по прямому сегменту к его конечной точке. |
| CurveTo | Three | Следовать кубической кривой, определённой двумя контрольными точками и конечной точкой. |
| CloseLoop | None | Вернуться к начальной позиции. |
| End | None | Завершить путь. |

[MotionPathPointsType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/motionpathpointstype/) описывает характеристики редактируемых точек, такие как угол или плавные точки. Это не заменяет тип команды. Используйте тип точки «кривая» для примера кривой ниже и тип «угол» для прямых сегментов.

Координаты пути нормализованы к размерам слайда: смещение X = 0.25 представляет одну четверть ширины слайда, а не 0.25 пункта. Положительный Y направлен вниз. Абсолютные команды задают позиции в системе координат пути; относительные команды задают смещения от текущей позиции. Это отдельный параметр от [getOrigin](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imotioneffect/#getOrigin--), который выбирает референтную систему пути, и [getPathEditMode](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imotioneffect/#getPathEditMode--), контролирующего перемещение пути при перемещении фигуры.

### **Создание прямого пути**

Создайте поведение движения с начальной точкой, одним прямым сегментом и командой завершения. [IMotionPath.add](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imotionpath/#add-int-android.graphics.PointF---int-boolean-) принимает тип команды, её точки, тип точки и флаг относительных координат.

Команда начала устанавливает (0, 0), а линия заканчивается в (0.25, 0), задавая горизонтальное смещение в одну четверть ширины слайда. Команда завершения не имеет координатных точек. После назначения пути добавление поведения движения к эффекту связывает этот маршрут с прямоугольником.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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
    path.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new PointF[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` содержит одно поведение движения с тремя командами пути. Далее представленные примеры редактирования файлов используют эту известную структуру.

### **Сравнение абсолютных и относительных координат**

Эти два объекта пути описывают один и тот же маршрут. Абсолютная команда заканчивается в (0.3, 0.1); относительная команда добавляет (0.1, 0.1) к текущей позиции (0.2, 0).

Оба пути начинаются в одинаковой позиции. Для относительной линии добавьте её смещения X и Y к текущей позиции, получив конечную точку; для абсолютной линии конечную точку читают напрямую. Переключение флага без преобразования координат даст иной маршрут.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Назначьте любой из путей поведению движения для использования в презентации. Последний аргумент Boolean выбирает относительные координаты для этой команды.

### **Замена линии на кривую**

Откройте `motion.pptx` и замените её команду линии кубической кривой. Сначала укажите две контрольные точки, затем конечную точку.

Начальная позиция задаётся предшествующей командой. Первые две точки формируют кривую, а третья – её пункт назначения; это не три последовательные конечные точки. Одновременное обновление типа команды, типа редактирования точек и массива точек сохраняет согласованность сегмента с новой геометрией.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new PointF[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Путь в `curve.pptx` всё ещё имеет три команды; её средняя команда теперь определяет кривую.

## **Просмотр и редактирование сохранённого пути**

Каждый [IMotionCmdPath](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imotioncmdpath/) открывает [getPoints](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imotioncmdpath/#getPointsType--), и [isRelative](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imotioncmdpath/#isRelative--). Ниже приведённые примеры используют известный трёхкомандный путь в `motion.pptx`. Для произвольного ввода найдите нужный эффект и проверяйте типы команд и количество точек перед редактированием по индексу.

### **Чтение команд и координат**

Прочитайте путь без изменения. Команды End и CloseLoop не требуют точек, поэтому допускайте массив точек, равный null.

Вывод сопоставляет каждый числовой тип команды с её флагом относительных координат перед перечислением точек. Это позволяет различать конечную точку и смещение перед изменением пути. Кривая будет перечислять три точки, тогда как в этом файле прямая линия перечисляет только одну.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (PointF point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

В листинге присутствует начальная точка, абсолютная линия, заканчивающаяся в (0.25, 0), и команда End.

### **Изменение конечной точки**

Откройте `motion.pptx` и замените массив точек линии, переместив её конечную точку.

Во входном файле индекс 0 – команда начала, индекс 1 – линия. Замена единственной точки линии меняет её пункт назначения без изменения типа команды, тайминга или позиции в коллекции. Поскольку команда использует абсолютные координаты, новая пара задаёт позицию, а не добавочное смещение.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new PointF[] { new PointF(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Линия в `motion-endpoint.pptx` заканчивается в (0.4, 0.1); оригинальный файл остаётся без изменений.

### **Замена сегмента**

Используйте [insert](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imotionpath/#insert-int-int-android.graphics.PointF---int-boolean-) и [removeAt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imotionpath/#removeAt-int-) для замены линии в `motion.pptx`. Вставка сдвигает старую линию на индекс 2.

Это демонстрирует замену объекта команды, а не редактирование её существующих координат. После вставки коллекция временно содержит команду начала, новую линию, старую линию и команду End. Удаление индекса 2 отбрасывает старую линию, оставляя новый маршрут на месте.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new PointF[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сохранённый путь всё ещё содержит три команды, при этом новая линия заканчивается в (0.2, 0.1), а команда End остаётся последней.

## **Модификация и проверка существующего поведения**

Когда индекс поведения неизвестен, выберите его по типу. Этот пример открывает `rotation.pptx`, ищет его [IRotationEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/irotationeffect/), меняет угол и проверяет сохранённое значение после повторного открытия.

Проверка типа позволяет пропустить в цикле поведения, не являющиеся вращениями. Второе загрузка читает сохранённый файл в отдельный объект презентации, поэтому сравнение проверяет сохранённые данные, а не значение, остающееся в памяти. Пример всё ещё предполагает, что известный эффект первый в основной последовательности; выбор поведения по типу не гарантирует нахождение нужного эффекта в произвольной презентации.

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

Вывод: `Rotation preserved: true`. Применяйте тот же шаблон проверки типов к другим поведениям. Для полной проверки сохранения сравните целевую фигуру, эффект, типы и порядок поведений, тайминг и команды пути. Для презентации с неизвестной анимационной структурой см. [Read Shape Animations](/slides/ru/androidjava/shape-animation/#read-shape-animations) для обхода основных и интерактивных последовательностей.

## **Порядок поведений, предустановки и воспроизведение**

Порядок в [IBehaviorCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibehaviorcollection/) – это сохранённый порядок операций эффекта. Это не плейлист, где каждое поведение автоматически ждёт завершения предыдущего. Тайминг и охватывающий эффект определяют расписание. Поведения могут накладываться, а операции над одним свойством могут взаимодействовать через [getAdditive](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibehavior/#getAdditive--) и [getAccumulate](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibehavior/#getAccumulate--). Не используйте только переупорядочивание коллекции для планирования «переместить, затем вращать»; применяйте явный тайминг или отдельные эффекты, как описано в [Shape Animation](/slides/ru/androidjava/shape-animation/).

[ getType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ieffect/#getType--) и [ getSubtype](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ieffect/#getSubtype--) эффекта описывают его предустановку. Это не полное описание отредактированного дерева поведений. Сначала выберите предустановку и подтип, а затем кастомизируйте поведения: изменение предустановки может пересоздать коллекцию и удалить ваши пользовательские операции. Например, изменение кастомного эффекта Spin на Fade заменит его поведение вращения на set и filter поведения. После изменения предустановки или подтипа снова проверьте коллекцию. Очистка предустановленных поведений может также удалить операции видимости или инициализации, необходимые предустановке. Примеры сознательно используют видимые фигуры и заменяют их поведения; они не реконструируют реализацию каждой предустановки.

## **Совместимость форматов**

Сохранённое дерево поведений не гарантирует идентичное воспроизведение во всех просмотрщиках или экспортных рендерах. Проверяйте сохранённые данные и полученный вывод отдельно.

| Format or output | What to verify |
| --- | --- |
| PPTX | Используйте как основной формат для этих примеров. Откройте его повторно, чтобы проверить редактируемое дерево поведений, затем проверьте воспроизведение в целевой версии PowerPoint. |
| PPT | Устаревшее двоичное представление может отличаться от PPTX. Протестируйте отдельный цикл сохранения‑повторного открытия и воспроизведение; не делайте выводы о поддержке каждой пользовательской комбинации только из успешного вывода PPTX. |
| PDF, PNG, JPEG и другие статические изображения слайдов | Содержат статическое изображение слайда, а не проигрываемую временную шкалу поведения или гарантированный конечный кадр анимации. |
| [HTML5](/slides/ru/androidjava/export-to-html5/) | Может воспроизводить поддерживаемые анимации, когда в параметрах экспорта включена анимация фигур. Тестируйте пользовательские комбинации в браузере. |
| [Animated GIF](/slides/ru/androidjava/convert-powerpoint-to-animated-gif/) | Сохраняет отрисованные кадры, а не редактируемые поведения или интерактивные щелчки. Проверьте фактическое отрисованное движение. |
| [Video](/slides/ru/androidjava/convert-powerpoint-to-video/) | Рендерит кадры анимации и кодирует их в видео. Поддержка ограничена [поддерживаемыми анимациями и эффектами](/slides/ru/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects); команды и интерактивные события не становятся редактируемой временной шкалой. |

## **FAQ**

**Почему мой эффект содержит поведения до того, как я их добавил?**

Создание предустановленного эффекта может создать его базовые операции. Просмотрите их, прежде чем решать, расширять предустановку или заменять её поведения.

**Делает ли перемещение поведения в начало плейлиста его первым при воспроизведении?**

Не обязательно. Порядок в коллекции не заменяет тайминг. Проверяйте задержки, длительности и взаимодействия между операциями над одним свойством.

**Почему у команды End нет точек?**

Она обозначает конец пути и не требует координат. При проверке пути, считанного из файла, учитывайте возможность нулевого массива точек.

**Достаточно ли успешного кругового прохождения для подтверждения воспроизведения?**

Нет. Открытие подтверждает сохранность проверенных свойств. Тестируйте проигрыватель слайдов или анимированный экспорт отдельно, чтобы убедиться в визуальном поведении.