---
title: Применение анимации фигур в презентациях на .NET
linktitle: Анимация фигур
type: docs
weight: 60
url: /ru/net/shape-animation/
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
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как добавлять, просматривать и настраивать анимацию фигур, время, звуки, поведение после анимации и анимированный текст с помощью Aspose.Slides для .NET."
---
## **Обзор**

Aspose.Slides for .NET представляет анимацию слайдов как эффекты на временной шкале слайда. Эффект имеет целевую форму, тип и подтип анимации, триггер, настройки времени и необязательные свойства, такие как звук или поведение после анимации.

Временная шкала содержит два типа последовательностей:

- **Основная последовательность** воспроизводится при переходе к следующему слайду.
- **Интерактивная последовательность** начинается, когда пользователь щёлкает по фигуре‑триггеру.

Поскольку текстовые поля, изображения, диаграммы, таблицы и другие объекты слайда реализуют [IShape](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/), вы используете один и тот же метод [ISequence.AddEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/isequence/addeffect/) для большинства содержимого слайда. Доступные эффекты перечислены в перечислении [EffectType](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/effecttype/).

## **Добавление анимаций фигур**

Чтобы добавить анимацию, получите основную последовательность слайда и вызовите [ISequence.AddEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/isequence/addeffect/) с целевой фигурой, типом эффекта, подтипом и триггером. Для эффекта, который начинается при щелчке по другой фигуре, создайте интерактивную последовательность, триггером которой будет эта другая фигура.

Следующий пример создаёт оба типа анимации и сохраняет результат в `shape-animations.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var targetShape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Click to animate this shape";

var mainSequence = slide.Timeline.MainSequence;
var entranceEffect = mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
entranceEffect.Timing.Duration = 1.5f;

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

presentation.Save("shape-animations.pptx", SaveFormat.Pptx);
```

Триггер определяет, когда эффект начинается:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/effecttriggertype/) ожидает щелчка в основной последовательности или щелчка по фигуре‑триггеру в интерактивной последовательности.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/effecttriggertype/) начинается одновременно с предыдущим эффектом.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/effecttriggertype/) начинается после завершения предыдущего эффекта.

Чтобы анимировать изображение, диаграмму или другую форму, передайте соответствующий объект в [ISequence.AddEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/isequence/addeffect/) вместо `targetShape`. Для параметров группировки, специфичных для диаграмм, см. [Animated Charts](/slides/ru/net/animated-charts/).

## **Чтение анимаций фигур**

Используйте [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/isequence/geteffectsbyshape/) когда известна целевая фигура. Чтобы просмотреть каждый эффект, переберите основную последовательность и все интерактивные последовательности. Перебор позволяет избежать предположения, что в последовательности есть эффект с индексом `0`.

Следующий пример создаёт фигуру с эффектами основной и интерактивной последовательностей, получает эффекты, направленные на эту фигуру, а затем перебирает каждую последовательность на слайде.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Animated shape";

var mainSequence = slide.Timeline.MainSequence;
mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

var targetEffects = mainSequence.GetEffectsByShape(targetShape);
Console.WriteLine($"The main sequence contains {targetEffects.Length} effect(s) for {targetShape.Name}.");

PrintSequence("Main sequence", mainSequence);

var interactiveIndex = 1;
foreach (var sequence in slide.Timeline.InteractiveSequences)
{
    var triggerName = sequence.TriggerShape == null ? "unknown" : sequence.TriggerShape.Name;
    var sequenceLabel = $"Interactive sequence {interactiveIndex}, trigger: {triggerName}";
    PrintSequence(sequenceLabel, sequence);
    interactiveIndex++;
}

static void PrintSequence(string label, ISequence sequence)
{
    Console.WriteLine($"  {label}: {sequence.Count} effect(s)");

    foreach (var effect in sequence)
    {
        var targetName = effect.TargetShape == null ? "unknown" : effect.TargetShape.Name;
        var effectDescription = $"{effect.Type} {effect.Subtype}; target: {targetName}; trigger: {effect.Timing.TriggerType}";
        Console.WriteLine($"    {effectDescription}");
    }
}
```

Если нужны эффекты только для одной фигуры, сначала определите её по имени, типу заполнителя или другому стабильному свойству; затем вызовите [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/isequence/geteffectsbyshape/). Не следует предполагать, что [IShapeCollection.Item](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/item/) с индексом `0` всегда является нужным объектом.

## **Работа с унаследованными эффектами заполнителей**

Заполнитель на обычном слайде может наследовать поведение анимации от соответствующего заполнителя на слайде‑макете и слайде‑шаблоне. [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/getbaseplaceholder/) возвращает такой родительский заполнитель или `null`, если родителя нет.

В следующей презентации нижний колонтитул имеет **Random Bars** на обычном слайде, **Split** на слайде‑макете и **Fly In** на слайде‑шаблоне.

![Эффект анимации нижнего колонтитула на обычном слайде](slide-shape-animation.png)

![Эффект анимации заполнителя нижнего колонтитула на слайде‑макете](layout-shape-animation.png)

![Эффект анимации заполнителя нижнего колонтитула на слайде‑шаблоне](master-shape-animation.png)

Следующий пример самостоятельно строит иерархию заполнителей. Он добавляет эффекты к заполнителю шаблона, заполнителю макета и соответствующему заполнителю на обычном слайде. Каждый вызов [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/getbaseplaceholder/) проверяется перед использованием возвращённой фигуры.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
var layoutPlaceholder = layoutSlide.PlaceholderManager.AddTextPlaceholder(100, 100, 400, 80);
layoutSlide.Timeline.MainSequence.AddEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
if (masterPlaceholder != null)
{
    var masterSequence = layoutSlide.MasterSlide.Timeline.MainSequence;
    masterSequence.AddEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}

var slide = presentation.Slides.AddEmptySlide(layoutSlide);
var slidePlaceholder = FindPlaceholderWithBase(slide);

if (slidePlaceholder == null)
{
    throw new InvalidOperationException("The slide does not contain a placeholder linked to its layout slide.");
}

slide.Timeline.MainSequence.AddEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
PrintEffects("Normal slide", slide.Timeline.MainSequence.GetEffectsByShape(slidePlaceholder));

var baseLayoutPlaceholder = slidePlaceholder.GetBasePlaceholder();
if (baseLayoutPlaceholder != null)
{
    PrintEffects("Layout slide", layoutSlide.Timeline.MainSequence.GetEffectsByShape(baseLayoutPlaceholder));

    var baseMasterPlaceholder = baseLayoutPlaceholder.GetBasePlaceholder();
    if (baseMasterPlaceholder != null)
    {
        PrintEffects("Master slide", layoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(baseMasterPlaceholder));
    }
}

presentation.Save("placeholder-animations.pptx", SaveFormat.Pptx);

static IShape FindPlaceholderWithBase(ISlide slide)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape.GetBasePlaceholder() != null)
        {
            return shape;
        }
    }

    return null;
}

static void PrintEffects(string source, IEffect[] effects)
{
    Console.WriteLine($"{source}: {effects.Length} effect(s)");

    foreach (var effect in effects)
    {
        Console.WriteLine($"  {effect.Type} {effect.Subtype}");
    }
}
```

## **Изменение времени анимации**

Диалог PowerPoint **Timing** отображает свойства [ITiming](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/itiming/).

![Диалог Timing в PowerPoint для анимационного эффекта](shape-animation.png)

- **Start** отображается в свойстве [ITiming.TriggerType](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/itiming/triggertype/).
- **Duration** соответствует [ITiming.Duration](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/itiming/duration/), в секундах.
- **Delay** соответствует [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/itiming/triggerdelaytime/), в секундах.
- **Repeat** соответствует [ITiming.RepeatCount](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/itiming/repeatcount/), [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/itiming/repeatuntilnextclick/), или [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/itiming/repeatuntilendslide/).
- **Rewind when done playing** соответствует [ITiming.Rewind](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/itiming/rewind/).

Этот автономный пример добавляет эффект, изменяет его время через объект, возвращённый [ISequence.AddEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/isequence/addeffect/), и сохраняет результат. Сохранение ссылки на возвращённый [IEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ieffect/) избегает ненужного обращения по индексу коллекции.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Timed animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Timing.TriggerType = EffectTriggerType.OnClick;
effect.Timing.Duration = 2.0f;
effect.Timing.TriggerDelayTime = 0.5f;
effect.Timing.RepeatUntilNextClick = false;
effect.Timing.RepeatUntilEndSlide = false;
effect.Timing.RepeatCount = 2.0f;
effect.Timing.Rewind = true;

presentation.Save("shape-animation-timing.pptx", SaveFormat.Pptx);
```

Используйте только один режим повторения. Комбинация счётчика повторов с флагом «until» может приводить к непредсказуемому поведению в разных проигрывателях. При смене режима повторения сначала задайте [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/itiming/repeatuntilnextclick/) и [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/itiming/repeatuntilendslide/), а затем [ITiming.RepeatCount](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/itiming/repeatcount/), поскольку установка любого из флагов также меняет активный режим повторения.

## **Добавление и извлечение звуков анимации**

Эффект анимации может ссылаться на встроенный звук через [IEffect.Sound](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ieffect/sound/). [IEffect.StopPreviousSound](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ieffect/stopprevioussound/) указывает эффекту остановить звук, начатый предыдущим эффектом.

### **Добавить звук к эффекту**

Следующий пример ожидает локальный аудиофайл `animation-sound.wav`. Он создаёт два эффекта, встраивает этот файл как звук для первого эффекта и настраивает второй эффект на остановку звука. При этом используются объекты, возвращённые [ISequence.AddEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/isequence/addeffect/), поэтому индекс последовательности не требуется.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
firstShape.TextFrame.Text = "Starts sound";
secondShape.TextFrame.Text = "Stops sound";

var sequence = slide.Timeline.MainSequence;
var firstEffect = sequence.AddEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
var secondEffect = sequence.AddEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var audioData = File.ReadAllBytes("animation-sound.wav");
var effectSound = presentation.Audios.AddAudio(audioData);
firstEffect.Sound = effectSound;
secondEffect.StopPreviousSound = true;

presentation.Save("shape-animation-sound.pptx", SaveFormat.Pptx);
```

### **Извлечь встроенные звуки эффектов**

Следующий пример ожидает локальную презентацию `presentation-with-animation-sounds.pptx`. Он просматривает как основную, так и интерактивные последовательности и записывает каждый встроенный звук эффекта в каталог `extracted-animation-sounds`. Расширение выбирается на основе MIME‑типа аудио, получаемого через [IAudio.ContentType](https://reference.aspose.com/slides/ru/net/aspose.slides/iaudio/contenttype/).

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;

var inputPath = "presentation-with-animation-sounds.pptx";
var outputDirectory = "extracted-animation-sounds";

Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation(inputPath);
var soundIndex = 1;

foreach (var slide in presentation.Slides)
{
    SaveSounds(slide.Timeline.MainSequence, outputDirectory, ref soundIndex);

    foreach (var sequence in slide.Timeline.InteractiveSequences)
    {
        SaveSounds(sequence, outputDirectory, ref soundIndex);
    }
}

Console.WriteLine($"Extracted {soundIndex - 1} sound file(s) to {Path.GetFullPath(outputDirectory)}.");

static void SaveSounds(ISequence sequence, string outputDirectory, ref int soundIndex)
{
    foreach (var effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        var extension = GetAudioExtension(effect.Sound.ContentType);
        var outputPath = Path.Combine(outputDirectory, $"effect-sound-{soundIndex}{extension}");
        File.WriteAllBytes(outputPath, effect.Sound.BinaryData);
        soundIndex++;
    }
}

static string GetAudioExtension(string contentType)
{
    var normalizedType = contentType == null ? string.Empty : contentType.ToLowerInvariant();

    if (normalizedType == "audio/mpeg")
        return ".mp3";

    if (normalizedType == "audio/mp4")
        return ".m4a";

    if (normalizedType == "audio/ogg")
        return ".ogg";

    if (normalizedType == "audio/wav" || normalizedType == "audio/x-wav")
        return ".wav";

    return ".bin";
}
```

Для больших аудиофайлов используйте [IAudio.GetStream](https://reference.aspose.com/slides/ru/net/aspose.slides/iaudio/getstream/) и копируйте поток в файл вместо загрузки всего объекта в массив байтов.

## **Установка поведения после анимации**

Опция **After animation** определяет, что происходит с фигурой после завершения её эффекта.

![Диалог параметров эффекта в PowerPoint, показывающий настройки After animation](shape-after-animation.png)

Перечисление [AfterAnimationType](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/afteranimationtype/) позволяет оставить фигуру без изменений, изменить её цвет, скрыть её после анимации или скрыть при следующем щелчке. Когда тип — [AfterAnimationType.Color](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/afteranimationtype/), также задайте [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ieffect/afteranimationcolor/).

Этот автономный пример создаёт эффект, задаёт его поведение после анимации через полученный объект эффекта и сохраняет результат.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Dim after animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.AfterAnimationType = AfterAnimationType.Color;
effect.AfterAnimationColor.Color = Color.LightGray;

presentation.Save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
```

Изменение типа с [AfterAnimationType.Color](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/afteranimationtype/) снимает настройку цвета после анимации.

## **Анимация текста**

Анимация текста имеет два связанных параметра:

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/itextanimation/buildtype/) определяет, появляются ли абзацы одновременно или по отдельным абзацам.
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ieffect/animatetexttype/) определяет, появляется ли текст сразу полностью, по словам или по буквам. [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/ieffect/delaybetweentextparts/) задаёт задержку между словами или буквами. Положительное значение — процент от продолжительности эффекта; отрицательное — задержка в секундах.

Следующий автономный пример анимирует слова в текстовом поле. [BuildType.AsOneObject](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/buildtype/) отключает построение по абзацам, поэтому настройка слов применяется ко всему текстовому фрейму.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
textBox.TextFrame.Text = "Aspose.Slides animates this sentence word by word.";

var effect = slide.Timeline.MainSequence.AddEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.TextAnimation.BuildType = BuildType.AsOneObject;
effect.AnimateTextType = AnimateTextType.ByWord;
effect.DelayBetweenTextParts = 20.0f;

presentation.Save("animated-text.pptx", SaveFormat.Pptx);
```

Чтобы построить текстовое поле по абзацам, установите [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/buildtype/) (или другой уровень абзаца). Чтобы применить отдельный эффект к одному абзацу, используйте перегрузку [ISequence.AddEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/isequence/addeffect/), принимающую [IParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/). См. [Animated Text](/slides/ru/net/animated-text/) для примеров на уровне абзацев.

## **Экспорт и замечания о совместимости**

- Сохранение в PPT или PPTX сохраняет модель анимации, но окончательное воспроизведение контролируется средой просмотра презентации.
- PDF и статические изображения не воспроизводят анимацию. Используйте [HTML5 export](/slides/ru/net/export-to-html5/), анимированный GIF или [video conversion](/slides/ru/net/convert-powerpoint-to-video/), если требуется отображать движение.
- Для HTML5 включите [Html5Options.AnimateShapes](https://reference.aspose.com/slides/ru/net/aspose.slides.export/html5options/animateshapes/) и, при необходимости, [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/html5options/animatetransitions/).
- При рендеринге видео поддерживаются многие типичные эффекты входа, акцента, выхода и движения, но не каждый эффект PowerPoint поддерживается. Проверьте актуальный список [supported animations and effects](/slides/ru/net/convert-powerpoint-to-video/#supported-animations-and-effects) и протестируйте критические презентации с вашей целевой версией Aspose.Slides.
- Пользовательские сложные эффекты и эффекты, импортированные из других форматов, могут сохраняться в файле, но отображаться иначе в PowerPoint, HTML5 или видео. Проверяйте экспортированный результат, а не только название эффекта.

## **FAQ**

**Почему анимация отображается в PowerPoint, но не в PDF?**  
PDF — статический формат, поэтому анимации и переходы слайдов не воспроизводятся. При необходимости сохранения движения экспортируйте в HTML5, анимированный GIF или видео.

**Почему эффект выглядит иначе в видео?**  
Экспорт в видео рендерит анимацию, а не сохраняет оригинальное поведение PowerPoint. Некоторые сложные эффекты не поддерживаются или приблизительно имитируются. Ознакомьтесь с таблицей поддерживаемых эффектов и протестируйте презентацию перед использованием в продакшене.

**Изменяет ли перемещение фигуры вперёд или назад порядок её анимации?**  
Нет. Порядок наложения (z‑order) управляет перекрытием, а порядок последовательностей и триггеры управляют воспроизведением анимации. При необходимости измените порядок воспроизведения на временной шкале.