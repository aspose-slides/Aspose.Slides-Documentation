---
title: Создание и изменение пользовательских анимационных поведений в .NET
linktitle: Пользовательская анимация
type: docs
weight: 151
url: /ru/net/custom-animation/
keywords:
- пользовательская анимация
- поведение анимации
- путь движения
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создавайте, просматривайте и изменяйте пользовательские анимационные поведения и редактируемые пути движения в презентациях PowerPoint с помощью Aspose.Slides для .NET."
---
## **Обзор**

Пользовательские анимационные поведения позволяют управлять отдельными действиями внутри анимационного эффекта, например изменять цвет, вращать форму или следовать по редактируемому пути движения. Это руководство показывает, как создавать и объединять поведения, настраивать их тайминг, просматривать и изменять существующие анимации, а также проверять, сохраняются ли их свойства при сохранении и повторном открытии презентации.

Для предопределённых эффектов и триггеров по щелчку см. [Shape Animation](/slides/ru/net/shape-animation/).

## **Поймите модель анимации**

Анимация организована как **Timeline → Sequence → Effect → Behaviors**:

- Слайд [Timeline](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseslide/timeline/) содержит его главную последовательность и интерактивные последовательности.
- [ISequence](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/isequence/) содержит эффекты, потенциально направленные на разные формы.
- [IEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ieffect/) определяет целевую форму, предустановку, подтип и тайминг эффекта.
- [IEffect.Behaviors](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ieffect/behaviors/) содержит операции, реализующие эффект: изменение цвета, перемещение, вращение, установка свойства и т.д.

## **Создайте отдельные поведения**

Вызовите [ISequence.AddEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/isequence/addeffect/) для создания эффекта и доступа к его коллекции [Behaviors](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ieffect/behaviors/). Предустановка может автоматически заполнить эту коллекцию. Сохраните её операции при расширении предустановки или используйте [Clear](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ibehaviorcollection/clear/) при намеренной замене их.

[IBehaviorFactory](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ibehaviorfactory/) создаёт восемь типов поведения, показанных ниже. Движение рассматривается в разделе [Build a Motion Path](#build-a-motion-path). Каждый пример создания представляет собой полную программу; последующие примеры редактирования указывают, какой файл вывода они используют.

### **Вращение**

Используйте [CreateRotationEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) для создания вращения. [By](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/irotationeffect/by/) задаёт относительный угол в градусах; [From](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/irotationeffect/from/) и [To](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/irotationeffect/to/) указывают конечные точки.

В примере начинается с эффекта Spin, заменяет его предустановленные операции одной операцией вращения и задаёт этой операции длительность в две секунды. Относительный угол 90 градусов представляет четверть оборота от исходной ориентации формы, поэтому явный начальный угол не требуется.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var rotation = factory.CreateRotationEffect();
rotation.By = 90f;
rotation.Timing.Duration = 2f;

effect.Behaviors.Add(rotation);

presentation.Save("rotation.pptx", SaveFormat.Pptx);
```

`rotation.pptx` содержит одну форму и одно вращение. Коллекция, тайминг и примеры редактирования вращения ниже используют этот файл.

### **Масштабирование**

Используйте [CreateScaleEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) с процентами X/Y: [From](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/iscaleeffect/from/) и [To](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/iscaleeffect/to/) описывают начальный и конечный размер, а [By](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/iscaleeffect/by/) описывает относительное изменение. Здесь 100 означает исходный размер.

В примере обе величины увеличиваются с 100 % до 125 % за две секунды. Использование одинаковых горизонтальных и вертикальных процентов сохраняет пропорции формы; разные проценты растягивают одну из величин сильнее.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.From = new PointF(100, 100);
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

effect.Behaviors.Add(scale);

presentation.Save("scale.pptx", SaveFormat.Pptx);
```

### **Цвет**

Используйте [CreateColorEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) для изменения заливки с синего на оранжевый. [From](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/icoloreffect/from/) и [To](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/icoloreffect/to/) — цвета; [By](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/icoloreffect/by/) — цветовое смещение. [IBehavior.Properties](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ibehavior/properties/) определяет анимируемый атрибут.

Заливка формы инициализируется синим, соответствующим начальному цвету анимации. Выбор атрибута fill-color сообщает поведению, какую часть формы изменять; только конечные цвета не определяют этот атрибут. Сохранённый эффект описывает переход к оранжевому за две секунды.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Blue;

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var color = factory.CreateColorEffect();
color.Properties.Add(BehaviorProperty.FillColor);
color.From.Color = Color.Blue;
color.To.Color = Color.Orange;
color.Timing.Duration = 2f;

effect.Behaviors.Add(color);

presentation.Save("color.pptx", SaveFormat.Pptx);
```

### **Фильтр**

Используйте [CreateFilterEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) для выбора эффекта стирания. [Type](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ifiltereffect/type/), [Subtype](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ifiltereffect/subtype/), и [Reveal](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ifiltereffect/reveal/) задают фильтр, направление и то, показывать ли форму или скрывать её.

В этом примере настраивается стирание за две секунды, которое раскрывает форму, используя подтип направления вправо. Параметры фильтра относятся к поведению внутри эффекта, поэтому они настраиваются после удаления оригинальных операций предустановки.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var filter = factory.CreateFilterEffect();
filter.Type = FilterEffectType.Wipe;
filter.Subtype = FilterEffectSubtype.Right;
filter.Reveal = FilterEffectRevealType.In;
filter.Timing.Duration = 2f;

effect.Behaviors.Add(filter);

presentation.Save("filter.pptx", SaveFormat.Pptx);
```

### **Свойство**

Используйте [CreatePropertyEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) для анимации непрозрачности. [From](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ipropertyeffect/from/), [To](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ipropertyeffect/to/), и [By](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ipropertyeffect/by/) — строки, интерпретируемые с помощью [ValueType](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ipropertyeffect/valuetype/) и [CalcMode](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ipropertyeffect/calcmode/). Выбирайте конечные точки или относительное смещение, а не задавайте все три без разбора.

Здесь выбранным атрибутом является opacity, и числовые строки представляют изменение от 25 % непрозрачности до полной. Линейная интерполяция описывает постепенное изменение между этими значениями. При адаптации примера к другому атрибуту выбирайте тип значения и конечные значения, подходящие этому атрибуту.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var property = factory.CreatePropertyEffect();
property.Properties.Add(BehaviorProperty.StyleOpacity);
property.ValueType = PropertyValueType.Number;
property.CalcMode = PropertyCalcModeType.Linear;
property.From = "0.25";
property.To = "1";
property.Timing.Duration = 2f;

effect.Behaviors.Add(property);

presentation.Save("property.pptx", SaveFormat.Pptx);
```

### **Установка**

Используйте [CreateSetEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ibehaviorfactory/createseteffect/) для задания видимости через [To](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/iseteffect/to/). Поведение set не интерполирует между конечными точками.

В примере выбирается атрибут visibility и при выполнении поведения присваивается строка `visible`. Прямоугольник уже видим в этой минимальной презентации, поэтому присваивание может не вызвать заметного визуального изменения само по себе. Такая операция полезна как часть более крупного эффекта, который также управляет тем, когда форма становится скрытой или видимой.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var set = factory.CreateSetEffect();
set.Properties.Add(BehaviorProperty.StyleVisibility);
set.To = "visible";

effect.Behaviors.Add(set);

presentation.Save("set.pptx", SaveFormat.Pptx);
```

### **Команда**

Используйте [CreateCommandEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) и настройте [Type](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/icommandeffect/type/), [CommandString](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/icommandeffect/commandstring/), и [ShapeTarget](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/icommandeffect/shapetarget/). Поместите WAV‑запись с именем `sample.wav` в рабочий каталог. Этот пример встраивает её с помощью [AddAudioFrameEmbedded](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/addaudioframeembedded/) и прикрепляет команду воспроизведения к аудиофрейму.

Аудиофрейм является одновременно целью эффекта и целью команды. Это связывает запрос воспроизведения с встроенной записью; сама строка команды не указывает, какой медиа‑объект управлять. Эффект настроен на запуск по щелчку во время слайд‑шоу.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("sample.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

var effect = slide.Timeline.MainSequence.AddEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var command = factory.CreateCommandEffect();
command.Type = CommandEffectType.Call;
command.CommandString = "play";
command.ShapeTarget = audioFrame;

effect.Behaviors.Add(command);

presentation.Save("command.pptx", SaveFormat.Pptx);
```

Сохранение помещает команду в `command.pptx`; запись не воспроизводится. Для воспроизведения нужен проигрыватель слайд‑шоу, поддерживающий команду и её медиа‑цель.

## **Управление коллекцией поведений**

[IBehaviorCollection](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ibehaviorcollection/) поддерживает [Add](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ibehaviorcollection/remove/), и [RemoveAt](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ibehaviorcollection/removeat/). В этом примере открывается `rotation.pptx`, добавляется масштабирование, перемещается перед вращением и удаляется вращение. Удаление и повторное вставление того же объекта меняет его сохранённую позицию без создания копии.

Последовательность правок меняет коллекцию с rotation–scale на scale–rotation, а затем только scale. Индексы относятся к текущей коллекции, поэтому удаление использует новый индекс вращения после переупорядочения. Финальное перечисление подтверждает, какое поведение будет сохранено.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var behaviors = effect.Behaviors;

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

behaviors.Add(scale);

behaviors.Remove(scale);
behaviors.Insert(0, scale);
behaviors.RemoveAt(1);

foreach (var behavior in behaviors)
    Console.WriteLine(behavior.GetType().Name);

presentation.Save("collection-edited.pptx", SaveFormat.Pptx);
```

Результат — `ScaleEffect`: остаётся только масштабирование. Порядок в коллекции сам по себе не планирует поведения одно за другим. Очищайте коллекцию только при полной замене её операций.

## **Настройка тайминга поведения**

[IBehavior.Timing](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ibehavior/timing/) раскрывает [ITiming](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/itiming/), независимо от [IEffect.Timing](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ieffect/timing/). Тайминг эффекта планирует вложенный эффект; тайминг поведения описывает операцию внутри него.

### **Установите длительность, задержку, повторения и ускорение**

Откройте `rotation.pptx` и задайте [Duration](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/itiming/duration/) и [TriggerDelayTime](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/itiming/triggerdelaytime/) в секундах, затем настройте [RepeatCount](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/itiming/repeatcount/). [Accelerate](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/itiming/accelerate/) и [Decelerate](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/itiming/decelerate/) — доли от длительности; их сумма не должна превышать 1.

Входной файл — тот, который был создан в примере вращения, где первое поведение известно как вращение. Этот пример изменяет только тайминг этого поведения; его угол в 90 градусов остаётся неизменным. Разделение угла и тайминга упрощает корректировку скорости без перестройки анимации.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var rotation = (IRotationEffect)effect.Behaviors[0];
rotation.Timing.Duration = 2f;
rotation.Timing.TriggerDelayTime = 0.5f;
rotation.Timing.RepeatCount = 3f;
rotation.Timing.Accelerate = 0.2f;
rotation.Timing.Decelerate = 0.2f;

presentation.Save("timing.pptx", SaveFormat.Pptx);
```

Поведение использует длительность 2 секунды, задержку 0,5 секунды и количество повторов 3. Первые и последние 20 % его длительности отводятся на ускорение и замедление.

Другие политики повторения включают [RepeatDuration](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/itiming/repeatduration/), [RepeatUntilEndSlide](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/itiming/repeatuntilendslide/), и [RepeatUntilNextClick](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/itiming/repeatuntilnextclick/); выбирайте одну политику вместо одновременного включения всех. [AutoReverse](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/itiming/autoreverse/) воспроизводит анимацию в обратном направлении после прямого прохода. Ускорение и замедление применяются к непрерывным изменениям, а не к дискретным присвоениям или командам.

## **Создание пути движения**

Используйте [CreateMotionEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) для создания движения. Его [From](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/imotioneffect/from/), [To](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/imotioneffect/to/), и [By](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/imotioneffect/by/) описывают координаты или смещения в процентах. Для редактируемого маршрута создайте [MotionPath](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/motionpath/) и назначьте её в [IMotionEffect.Path](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/imotioneffect/path/). [IMotionPath](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/imotionpath/) хранит команды пути.

| Команда | Точки | Значение |
| --- | --- | --- |
| MoveTo | One | Установить начальную позицию. |
| LineTo | One | Переместиться по прямому отрезку к конечной точке. |
| CurveTo | Three | Следовать кубической кривой, определенной двумя контрольными точками и конечной точкой. |
| CloseLoop | None | Вернуться к начальной позиции. |
| End | None | Завершить путь. |

[MotionPathPointsType](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/motionpathpointstype/) описывает характеристики редактирования точек, такие как угловые или гладкие точки. Это не заменяет тип команды. Используйте тип точки curve для примера кривой ниже и тип точки corner для прямых сегментов.

Координаты пути нормализованы к размерам слайда: смещение X на 0,25 представляет одну четверть ширины слайда, а не 0,25 пункта. Положительное Y направлено вниз. Абсолютные команды задают позиции в системе координат пути; относительные команды задают смещения от текущей позиции. Это отдельный аспект от [Origin](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/imotioneffect/origin/), который выбирает систему координат пути, и [PathEditMode](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/imotioneffect/patheditmode/), который управляет тем, как путь перемещается при перемещении формы.

### **Создание прямого пути**

Создайте поведение движения с начальной точкой, одним прямым сегментом и командой завершения. [IMotionPath.Add](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/imotionpath/add/) принимает тип команды, её точки, тип точек и флаг относительных координат.

Начальная команда устанавливает (0, 0), а линия заканчивается в (0.25, 0), давая маршруту горизонтальное смещение в одну четверть ширины слайда. Команда завершения не имеет координатных точек. После назначения пути добавление поведения движения к эффекту соединяет этот маршрут с прямоугольником.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var motion = factory.CreateMotionEffect();
motion.Origin = MotionOriginType.Layout;
motion.Timing.Duration = 2f;

var path = new MotionPath();
path.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
path.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
path.Add(MotionCommandPathType.End, Array.Empty<PointF>(), MotionPathPointsType.None, false);

motion.Path = path;
effect.Behaviors.Add(motion);

presentation.Save("motion.pptx", SaveFormat.Pptx);
```

`motion.pptx` содержит одно поведение движения с тремя командами пути. Последующие примеры редактирования файлов используют эту известную структуру.

### **Сравнение абсолютных и относительных координат**

Эти два объекта пути описывают один и тот же маршрут. Абсолютная команда заканчивается в (0.3, 0.1); относительная команда добавляет (0.1, 0.1) к текущей позиции, получая (0.2, 0).

Обе пути начинаются в одной и той же позиции. Для относительной линии добавьте её X и Y смещения к текущей позиции, чтобы получить конечную точку; для абсолютной линии прочитайте конечную точку напрямую. Переключение флага без преобразования координат опишет иной маршрут.

```csharp
using System.Drawing;
using Aspose.Slides.Animation;

var absolutePath = new MotionPath();
absolutePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

var relativePath = new MotionPath();
relativePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Назначьте любой из путей поведению движения, чтобы использовать его в презентации. Последний булевый аргумент выбирает относительные координаты для этой команды.

### **Замена линии кривой**

Откройте `motion.pptx` и замените его команду линии кубической кривой. Сначала укажите две контрольные точки, затем конечную точку.

Начальная позиция задаётся предыдущей командой. Первые две точки формируют кривую, а третья — её конечную точку; они не являются тремя последовательными конечными точками. Обновление типа команды, типа редактирования точек и массива точек одновременно сохраняет сегмент согласованным с новой геометрией.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path[1].CommandType = MotionCommandPathType.CurveTo;
path[1].PointsType = MotionPathPointsType.CurveSmooth;
path[1].Points = new[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) };

presentation.Save("curve.pptx", SaveFormat.Pptx);
```

Путь в `curve.pptx` всё ещё имеет три команды; её средняя команда теперь определяет кривую.

## **Просмотр и редактирование сохранённого пути**

Каждый [IMotionCmdPath](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/imotioncmdpath/) раскрывает [Points](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/imotioncmdpath/points/), [CommandType](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/imotioncmdpath/commandtype/), [PointsType](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/imotioncmdpath/pointstype/), и [IsRelative](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/imotioncmdpath/isrelative/). Следующие примеры используют известный путь с тремя командами в `motion.pptx`. Для произвольного ввода найдите нужный эффект и проверьте типы команд и количество точек перед редактированием по индексу.

### **Чтение команд и координат**

Прочитайте путь без изменения. Команды End и CloseLoop не требуют точек, поэтому допускайте нулевой массив точек.

Вывод сопоставляет каждую команду с её флагом относительных координат перед перечислением точек. Это позволяет различать конечную точку и смещение перед изменением пути. Кривая будет перечислять три точки, тогда как прямой отрезок в этом файле перечисляет только одну.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
foreach (var segment in path)
{
    Console.WriteLine($"{segment.CommandType}, relative: {segment.IsRelative}");
    if (segment.Points != null)
        foreach (var point in segment.Points)
            Console.WriteLine($"X={point.X}, Y={point.Y}");
}
```

Список содержит начальную точку, абсолютную линию, заканчивающуюся в (0.25, 0), и команду End.

### **Изменение конечной точки**

Откройте `motion.pptx` и замените массив точек линии, чтобы переместить её конечную точку.

Во входном файле индекс 0 — начальная команда, индекс 1 — линия. Замена единственной точки линии меняет её конечную позицию, не меняя тип команды, тайминг или положение в коллекции. Поскольку команда использует абсолютные координаты, новая пара указывает позицию, а не добавочный смещённый вектор.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var motion = (IMotionEffect)effect.Behaviors[0];
motion.Path[1].Points = new[] { new PointF(0.4f, 0.1f) };

presentation.Save("motion-endpoint.pptx", SaveFormat.Pptx);
```

Линия в `motion-endpoint.pptx` заканчивается в (0.4, 0.1); оригинальный файл остаётся неизменным.

### **Замена сегмента**

Используйте [Insert](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/imotionpath/insert/) и [RemoveAt](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/imotionpath/removeat/) для замены линии в `motion.pptx`. Вставка смещает старую линию к индексу 2.

Это демонстрирует замену объекта команды вместо редактирования его существующих координат. После вставки коллекция временно содержит начальную команду, новую линию, старую линию и команду End. Удаление индекса 2 отбрасывает старую линию и оставляет новый маршрут на месте.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path.Insert(1, MotionCommandPathType.LineTo, new[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
path.RemoveAt(2);

presentation.Save("motion-edited.pptx", SaveFormat.Pptx);
```

Сохранённый путь всё ещё имеет три команды, новая линия заканчивается в (0.2, 0.1), а команда End последняя.

## **Изменение и проверка существующего поведения**

Если индекс поведения неизвестен, выберите его по типу. В этом примере открывается `rotation.pptx`, находится его [IRotationEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/irotationeffect/), меняется угол и проверяется сохранённое значение после повторного открытия.

Проверка типа позволяет циклу пропустить поведения, не являющиеся вращениями. Второй загрузка читает сохранённый файл в отдельный объект презентации, поэтому сравнение проверяет сохранённые данные, а не значение, остающееся в памяти. Этот пример всё ещё предполагает, что известный эффект является первым в основной последовательности; выбор поведения по типу не находит правильный эффект в произвольной презентации.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in effect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        rotation.By = 180f;
}

presentation.Save("rotation-edited.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("rotation-edited.pptx");
var savedEffect = reopened.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in savedEffect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        Console.WriteLine($"Rotation preserved: {Math.Abs(rotation.By - 180f) < 0.001f}");
}
```

Результат — `Rotation preserved: True`. Применяйте тот же шаблон проверки типа к другим поведениям. Для полной проверки сохранения сравните целевую форму, эффект, типы и порядок поведений, тайминг и команды пути. Используйте числовой допуск для значений с плавающей точкой. Для презентации с неизвестной структурой анимации см. [Read Shape Animations](/slides/ru/net/shape-animation/#read-shape-animations) для обхода основных и интерактивных последовательностей.

## **Порядок поведения, предустановки и воспроизведение**

Порядок в [IBehaviorCollection](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ibehaviorcollection/) — это сохранённый порядок операций эффекта. Это не плейлист, где каждое поведение автоматически ждёт предыдущее. Тайминг и охватывающий эффект определяют планирование. Поведения могут накладываться, а операции над тем же свойством могут взаимодействовать через [Additive](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ibehavior/additive/) и [Accumulate](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ibehavior/accumulate/). Не используйте лишь переупорядочивание коллекции для планирования «переместить, затем повернуть»; используйте явный тайминг или отдельные эффекты, как описано в [Shape Animation](/slides/ru/net/shape-animation/).

[Type](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ieffect/type/) и [Subtype](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ieffect/subtype/) эффекта описывают его предустановку. Это не полное описание отредактированного дерева поведения. Выберите предустановку и подтип перед настройкой поведений: изменение предустановки может перестроить коллекцию и удалить ваши пользовательские операции. Например, изменение пользовательского эффекта Spin на Fade может заменить его поведение вращения на поведения set и filter. Сновь проверьте коллекцию после изменения предустановки или подтипа. Очистка предустановленных поведений также может удалить операции видимости или инициализации, необходимые предустановке. Примеры намеренно используют видимые формы и заменяют поведения; они не восстанавливают реализацию каждой предустановки.

## **Совместимость форматов**

Сохранённое дерево поведения не гарантирует одинаковое воспроизведение во всех просмотрщиках или средствах экспорта. Проверьте сохранённые данные и отрендеренный вывод отдельно.

| Формат или вывод | Что проверить |
| --- | --- |
| PPTX | Используйте как основной формат для этих примеров. Откройте его снова, чтобы проверить редактируемое дерево поведения, затем проверьте воспроизведение в целевой версии PowerPoint. |
| PPT | Унаследованный бинарный формат может отличаться от PPTX. Протестируйте отдельный цикл сохранения‑и‑повторного‑открытия и воспроизведение; не делайте вывод о поддержке каждой пользовательской комбинации на основе успешного вывода PPTX. |
| PDF, PNG, JPEG и другие статические изображения слайдов | Содержат статическое изображение слайда, а не воспроизводимую временную шкалу поведения или гарантированный окончательный кадр анимации. |
| [HTML5](/slides/ru/net/export-to-html5/) | Может воспроизводить поддерживаемые анимации, когда анимация форм включена в параметрах экспорта. Проверьте пользовательские комбинации в браузере. |
| [Animated GIF](/slides/ru/net/convert-powerpoint-to-animated-gif/) | Сохраняет отрендеренные кадры, а не редактируемые поведения или взаимодействие по щелчку. Проверьте фактическое отрисованное движение. |
| [Video](/slides/ru/net/convert-powerpoint-to-video/) | Рендерит кадры анимации и кодирует их в видео. Поддержка ограничена [supported animations and effects](/slides/ru/net/convert-powerpoint-to-video/#supported-animations-and-effects); команды и интерактивные события не становятся редактируемой временной шкалой. |

## **FAQ**

**Почему мой эффект содержит поведения до того, как я их добавил?**

Создание предопределённого эффекта может создать его базовые операции. Проверьте их, прежде чем решать, расширять предустановку или заменять её поведения.

**Перемещение поведения в начало заставит его воспроизводиться первым?**

Не обязательно. Порядок в коллекции не заменяет тайминг. Проверьте задержки, длительности и взаимодействия между операциями над тем же свойством.

**Почему команда End не имеет точек?**

Она обозначает конец пути и не требует координат. При проверке пути, считанного из файла, проверьте наличие нулевого массива точек.

**Достаточно ли успешного кругового прохода, чтобы подтвердить воспроизведение?**

Нет. Повторное открытие подтверждает сохранность проверенных свойств. Тестируйте проигрыватель слайд‑шоу или анимированный экспорт отдельно, чтобы подтвердить визуальное поведение.