---
title: Управление переходами слайдов в презентациях на .NET
linktitle: Переход слайда
type: docs
weight: 90
url: /ru/net/slide-transition/
keywords:
- переход слайда
- добавить переход слайда
- применить переход слайда
- расширенный переход слайда
- переход Morph
- тип перехода
- эффект перехода
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Применяйте переходы слайдов, настраивайте автоматическое продвижение слайдов и кастомизируйте Morph и другие эффекты переходов с помощью Aspose.Slides для .NET."
---
## **Обзор**

Переходы слайдов определяют, как слайды появляются во время показа. С помощью Aspose.Slides для .NET вы можете выбрать эффект перехода для каждого слайда, настроить переход по щелчку мыши или по таймеру и скорректировать параметры, специфичные для эффекта. В этой статье использованы примеры на C# для применения переходов, установки точных длительностей переходов, управления временем показа слайда и создания перехода Morph между двумя слайдами. Примеры также показывают, как сохранить настройки в файл PPTX.

## **Add Slide Transition**

Чтобы применить переход, загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и получите доступ к свойству слайда [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/). Установите его [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) значением из перечисления [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/), затем сохраните презентацию.

Следующий пример применяет переход Circle к первому слайду и переход Comb ко второму. Используйте файл `input.pptx` с как минимум двумя слайдами.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    presentation.Save("slide-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **Wheel Transition**

Свойство [Spokes](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/spokes/) интерфейса [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/) управляет числом радиальных секторов, которые раскрывают слайд назначения. Установите [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) слайда в Wheel из [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) перед тем как получить [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) как [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/).

В этом примере создаются две одинаковые пары слайдов: черный слайд, за которым следует слайд с золотым прямоугольником. Слайды назначения используют количество спиц 1 и 8, одинаковый [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) и явный [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) 8000 мс, чтобы различие было легко заметить.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();
var slideWidth = presentation.SlideSize.Size.Width;
var slideHeight = presentation.SlideSize.Size.Height;

var blackSlide = presentation.Slides[0];
blackSlide.Shapes.Clear();
blackSlide.Background.Type = BackgroundType.OwnBackground;
blackSlide.Background.FillFormat.FillType = FillType.Solid;
blackSlide.Background.FillFormat.SolidFillColor.Color = Color.Black;

var destinationSlide = presentation.Slides.AddClone(blackSlide);
var rectangle = destinationSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
rectangle.FillFormat.FillType = FillType.Solid;
rectangle.FillFormat.SolidFillColor.Color = Color.Gold;
rectangle.TextFrame.Text = "Wheel transition";

presentation.Slides.AddClone(blackSlide);
presentation.Slides.AddClone(destinationSlide);

var spokeCounts = new uint[] { 1, 8 };
for (var i = 0; i < spokeCounts.Length; i++)
{
    var transition = presentation.Slides[i * 2 + 1].SlideShowTransition;
    transition.Type = TransitionType.Wheel;
    var wheelTransition = (IWheelTransition)transition.Value;
    wheelTransition.Spokes = spokeCounts[i];
    transition.Speed = TransitionSpeed.Slow;
    transition.Duration = 8000;
}

presentation.Save("wheel-transitions.pptx", SaveFormat.Pptx);
```

Откройте получившуюся презентацию в PowerPoint и запустите показ слайдов. Перейдите со слайда 1 на слайд 2, затем со слайда 3 на слайд 4. При воспроизведении в PowerPoint проверенное значение спиц 1 раскрывает слайд одной вращающейся дугой; значение 8 — одновременно восемью радиальными секторами. Содержимое и время перехода одинаковы, различие только в числе секторов раскрытия.

## **Fade Through Black with the Reveal Transition**

Установите тип перехода целевого слайда в Reveal, затем с помощью [IRevealTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/irevealtransition/) задайте [ThroughBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/irevealtransition/throughblack/). Пример создаёт бирюзовый исходный слайд и коралловый целевой слайд, после чего клонирует оба, чтобы продемонстрировать один и тот же двухсекундный переход с отключённым и включённым затемнением.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var source = presentation.Slides[0];
var destination = presentation.Slides.AddClone(source);
StyleSlide(source, Color.Teal, "Source");
StyleSlide(destination, Color.Coral, "Destination");
presentation.Slides.AddClone(source);
presentation.Slides.AddClone(destination);

foreach (var index in new[] { 1, 3 })
{
    var transition = presentation.Slides[index].SlideShowTransition;
    transition.Type = TransitionType.Reveal;
    transition.Speed = TransitionSpeed.Slow;
    transition.Duration = 2000;

    var reveal = (IRevealTransition)transition.Value;
    reveal.Direction = TransitionLeftRightDirectionType.Left;
    reveal.ThroughBlack = index == 3;
}

presentation.Save("reveal-transitions.pptx", SaveFormat.Pptx);

void StyleSlide(ISlide slide, Color background, string label)
{
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = background;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 160, 180, 400, 130);
    shape.TextFrame.Text = label;
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 44;
}
```

В показе PowerPoint перейдите со слайда 1 на слайд 2. Бирюза плавно переходит в коралл. Затем перейдите со слайда 3 на слайд 4. Экран кратко затемняется почти до чёрного, после чего появляется коралловый слайд. Оба слайда сохраняют свои исходные цвета фона.

Ниже показаны кадры PowerPoint с интервалом полсекунды. Сравните центральный кадр в каждой строке, чтобы увидеть влияние настройки.

![Воспроизведение PowerPoint с отключённым ThroughBlack (верх) и включённым (низ). Только нижняя строка проходит через почти чёрный.](reveal-through-black.png)

## **Add Advanced Slide Transition**

Вы можете настроить, как долго слайд остаётся на экране и будет ли переход осуществляться щелчком мыши. Следующие свойства управляют этим поведением:

- [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) позволяет зрителю переходить по щелчку мыши.
- [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) включает автоматический переход.
- [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceaftertime/) задаёт задержку перед автоматическим переходом в миллисекундах.

Включите оба режима, чтобы зритель мог перейти щелчком или подождать таймер. Чтобы использовать только таймер, установите [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) в `false`. Задержка управляет моментом перехода, но не длительностью визуального эффекта перехода.

В этом примере первым трём слайдам назначаются разные эффекты, а автоматический переход включён через 3, 5 и 7 секунд соответственно. Щелчком мыши также можно перейти к этим слайдам. Используйте файл `input.pptx` с минимум тремя слайдами.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 3)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Circle;
    firstTransition.AdvanceOnClick = true;
    firstTransition.AdvanceAfter = true;
    firstTransition.AdvanceAfterTime = 3000;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Comb;
    secondTransition.AdvanceOnClick = true;
    secondTransition.AdvanceAfter = true;
    secondTransition.AdvanceAfterTime = 5000;

    var thirdTransition = presentation.Slides[2].SlideShowTransition;
    thirdTransition.Type = TransitionType.Zoom;
    thirdTransition.AdvanceOnClick = true;
    thirdTransition.AdvanceAfter = true;
    thirdTransition.AdvanceAfterTime = 7000;

    presentation.Save("advanced-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least three slides.");
}
```

Чтобы проверить, включён ли автоматический переход, прочитайте [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/). Одна лишь сохранённая задержка не означает, что таймер активен.

Следующий пример открывает сохранённый выше файл, выводит информацию о каждом включённом таймере и отключает автоматический переход для слайдов с задержкой более двух секунд. Для этих слайдов включаются щелчки мыши, после чего настройки сохраняются.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("advanced-transitions.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;

    if (transition.AdvanceAfter)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: advance after {transition.AdvanceAfterTime} ms.");

        if (transition.AdvanceAfterTime > 2000)
        {
            transition.AdvanceAfter = false;
            transition.AdvanceOnClick = true;
        }
    }
}

presentation.Save("adjusted-transitions.pptx", SaveFormat.Pptx);
```

## **Control Transition Timing Precisely**

Используйте [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) для указания точной длины эффекта перехода в миллисекундах. Свойство слайда [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) раскрывает эти настройки через интерфейс [ISlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/):

| Property | Purpose |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) | Устанавливает длительность самого эффекта перехода в миллисекундах. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Задает задержку перед автоматическим переходом слайда в миллисекундах. Включите [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) для активации таймера. |
| [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) | Позволяет выбрать предопределённую категорию скорости из [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium или Fast. Используется, когда точная длительность не задана. |

[Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) контролирует только эффект перехода; он не определяет, как долго слайд остаётся видимым. Задержку автоматического перехода задавайте отдельно. Если явная длительность не указана, Aspose.Slides определяет её исходя из типа перехода и значения [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/).

### **Apply the Same Duration to Every Slide**

Для единообразного темпа применяйте один и тот же эффект и точную длительность ко всем слайдам. Пример загружает `input.pptx`, выбирает Fade из [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) и задаёт каждой трансформации длительность 750 мс. Автоматический переход включён через 5000 мс, а переход по щелчку отключён; результат сохраняется как PPTX.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    transition.Type = TransitionType.Fade;
    transition.Duration = 750;

    // Настройте автоматическое продвижение независимо от длительности эффекта.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **Set Different Durations for Individual Slides**

Разные слайды могут иметь разные длительности эффектов. Например, короткий переход для титульного слайда и более длительный для введения раздела. Пример задаёт 500 мс для первого слайда и 1200 мс для второго. Используйте `input.pptx` с минимум двумя слайдами.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Fade;
    firstTransition.Duration = 500;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Push;
    secondTransition.Duration = 1200;

    presentation.Save("individual-transition-durations.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

### **Coordinate Transitions with Animated Output**

При подготовке [animated GIF](/slides/ru/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/ru/net/export-to-html5/) или [video](/slides/ru/net/convert-powerpoint-to-video/) задавайте точные длительности переходов перед экспортом, чтобы соответствовать требуемому темпу. Например, используйте 600‑миллисекундный fade между сценами и отдельно регулируйте задержку перехода каждого слайда, чтобы выделить время для озвучки или контента.

Для GIF и видео согласуйте частоту кадров с длительностью эффекта: 600 мс ≈ 18 кадров при 30 fps. В HTML5 включите анимированные переходы в настройках экспорта. Проверьте поддерживаемые эффекты и параметры времени выбранного формата и просмотрите результат для подтверждения синхронизации.

### **Read an Existing Transition Duration**

Прочитайте [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) перед изменением перехода, чтобы определить, хранится ли явное значение. Значение `-1` означает отсутствие явной длительности; неотрицательное значение задаёт сохранённую длительность в миллисекундах. Это не рассчитанная длительность воспроизведения: Aspose.Slides использует тип перехода и [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) для её вычисления. Установка типа перехода может инициализировать длительность, поэтому сначала проверьте оригинальные настройки.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    var duration = transition.Duration;

    if (duration >= 0)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: stored transition duration is {duration} ms.");
    }
    else
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: no explicit duration; timing depends on {transition.Type} and {transition.Speed}.");
    }
}
```

## **Morph Transition**

Переход Morph анимирует изменения объектов между последовательными слайдами. Чтобы создать простой эффект Morph, клонируйте слайд, переместите или измените размер объекта в копии и примените переход Morph к второму слайду. Это даёт переходу соответствующие объекты для анимации между исходным и изменённым состоянием.

Следующий пример создаёт слайд с текстовым прямоугольником, клонирует его и изменяет позицию и размер прямоугольника в копии. Затем для второго слайда выбирает Morph из перечисления [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/). Откройте сохранённый файл в среде просмотра, поддерживающей Morph, чтобы увидеть эффект во время показа.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var rectangle = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
rectangle.TextFrame.Text = "Morph transition";

var secondSlide = presentation.Slides.AddClone(firstSlide);
var movedRectangle = secondSlide.Shapes[0];
movedRectangle.X += 100;
movedRectangle.Y += 50;
movedRectangle.Width -= 200;
movedRectangle.Height -= 10;

secondSlide.SlideShowTransition.Type = TransitionType.Morph;

presentation.Save("morph-transition.pptx", SaveFormat.Pptx);
```

## **Morph Transition Types**

Перечисление [TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) определяет, как Morph сопоставляет и анимирует содержимое:

- [ByObject](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) рассматривает каждую форму как один объект.
- [ByWord](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) анимирует текст, сопоставляя слова, где это возможно.
- [ByChar](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) анимирует текст, сопоставляя символы, где это возможно.

Установите [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) перехода в Morph перед доступом к его [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/). Затем полученный объект предоставляет интерфейс [IMorphTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/), у которого свойство [MorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/morphtype/) выбирает режим сопоставления.

В этом примере открывается презентация, созданная в предыдущем разделе, и настраивается второй слайд для анимации Morph по словам.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("morph-transition.pptx");

if (presentation.Slides.Count >= 2)
{
    var transition = presentation.Slides[1].SlideShowTransition;
    transition.Type = TransitionType.Morph;

    if (transition.Value is IMorphTransition morphTransition)
    {
        morphTransition.MorphType = TransitionMorphType.ByWord;
        presentation.Save("morph-by-word.pptx", SaveFormat.Pptx);
    }
    else
    {
        Console.WriteLine("Morph transition options are unavailable.");
    }
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

<!-- visual-explanation:slide-transition:start -->
[![Morph matching units shown as a whole shape, individual words, and individual characters.](visual-slide-transition-76bdbee41cb7.svg)](visual-slide-transition-76bdbee41cb7.svg)

*Morph может сопоставлять целые формы, слова или символы, где это возможно. Эти коробки обозначают единицы сопоставления, а не наблюдаемое движение. В примере для второго слайда выбран режим ByWord.*
<!-- visual-explanation:slide-transition:end -->

## **Set Transition Effects**

Некоторые переходы раскрывают дополнительные параметры, такие как направление или запуск эффекта с чёрного экрана. Доступные опции зависят от выбранного [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/). Сначала задайте тип, затем используйте соответствующий интерфейс из его [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/).

Следующий пример применяет переход Cut к первому слайду `input.pptx`. Через [IOptionalBlackTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/) устанавливается [FromBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/), чтобы переход начинался с чёрного экрана.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");
var transition = presentation.Slides[0].SlideShowTransition;
transition.Type = TransitionType.Cut;

if (transition.Value is IOptionalBlackTransition cutTransition)
{
    cutTransition.FromBlack = true;
    presentation.Save("cut-from-black.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Cut transition options are unavailable.");
}
```

## **FAQ**

**Можно ли управлять скоростью воспроизведения перехода слайда?**

Да. Предпочтительно использовать [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/), когда требуется точная длительность эффекта в миллисекундах. Используйте [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/), если достаточно предопределённой категории [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/) — Slow, Medium или Fast, и явная длительность не задаётся. Эти настройки контролируют только эффект перехода, независимо от задержки автоматического перехода.

**Можно ли прикрепить звук к переходу и зациклить его?**

Да. Присвойте встроенный звук свойству [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/), установите [SoundMode](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundmode/) в StartSound из перечисления [TransitionSoundMode](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionsoundmode/), и включите [SoundLoop](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundloop/). Звук будет повторяться до следующего звукового события в показе.

**Как быстро применить один и тот же переход ко всем слайдам?**

Пройдитесь в цикле по коллекции [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) презентации и для каждого слайда задайте свойству перехода [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) одинаковое значение. В том же цикле задайте любые параметры времени и эффекта, чтобы поведение было одинаковым для всех слайдов.

**Как проверить, какой переход установлен на текущем слайде?**

Прочитайте свойство [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) у свойства [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) слайда. Возвращаемое значение принадлежит перечислению [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/); значение None означает, что переход не установлен.