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

Переходы слайдов управляют тем, как слайды появляются во время демонстрации. С помощью Aspose.Slides for .NET можно выбрать эффект перехода для каждого слайда, настроить переход по щелчку мыши или таймеру и задать параметры, специфичные для конкретного эффекта. В этой статье используются примеры на C# для применения переходов, задания точных длительностей переходов, управления временем показа слайдов и создания перехода Morph между двумя слайдами. Примеры также показывают, как сохранить настройки в файл PPTX.

## **Добавить переход слайда**

Чтобы применить переход, загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и получите доступ к свойству [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) слайда. Установите его [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) в значение из перечисления [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/), затем сохраните презентацию.

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

## **Переход Wheel**

Свойство [Spokes](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/spokes/) интерфейса [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/) управляет количеством радиальных секторов, которые раскрывают целевой слайд. Установите [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) слайда в Wheel из [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) перед доступом к [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) как к [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/).

В этом примере создаются две идентичные пары слайдов: чёрный слайд, за которым следует слайд с золотым прямоугольником. На целевых слайдах используется количество спиц 1 и 8, одинаковая [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) и явная [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) 8 000 миллисекунд, чтобы разницу было легко заметить.

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

Откройте полученную презентацию в PowerPoint и запустите показ слайдов. Перейдите со слайда 1 на слайд 2, затем со слайда 3 на слайд 4. При воспроизведении в PowerPoint проверенное количество спиц 1 раскрывает слайд одной вращающейся дугой; проверенное количество 8 раскрывает его одновременно восемью радиальными секторами. Содержимое целевых слайдов и время перехода одинаковы, различием является число раскрывающих секторов.

## **Добавить расширенный переход слайда**

Можно настроить, как долго слайд остаётся на экране и будет ли щелчок мыши продвигать показ. Следующие свойства управляют этим поведением:

- [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) позволяет зрителю продвигать показ щелчком мыши.
- [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) включает автоматическое продвижение.
- [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceaftertime/) задаёт задержку перед автоматическим продвижением в миллисекундах.

Включите как щелчок, так и таймер, чтобы зритель мог перейти по щелчку или дождаться истечения таймера. Чтобы использовать только таймер, установите [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) в `false`. Задержка управляет моментом перехода; она не задаёт длительность визуального эффекта перехода.

Этот пример присваивает разные эффекты первым трём слайдам и включает автоматическое продвижение через 3, 5 и 7 секунд соответственно. Щелчки мышью также могут продвигать эти слайды. Используйте файл `input.pptx` с как минимум тремя слайдами.

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

Чтобы проверить, включено ли автоматическое продвижение, прочитайте [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/). Одна лишь сохранённая задержка не указывает, что таймер активен.

Следующий пример открывает файл, сохранённый выше, выводит каждый включённый таймер и отключает автоматическое продвижение для слайдов с задержкой более двух секунд. Для этих слайдов включаются щелчки мышью, после чего настройки сохраняются.

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

## **Точно контролировать время перехода**

Используйте [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) для указания точной длительности эффекта перехода в миллисекундах. Свойство [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) слайда раскрывает эти настройки через [ISlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/):

| Свойство | Назначение |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) | Задает длительность самого эффекта перехода в миллисекундах. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Задает задержку перед автоматическим переходом слайда в миллисекундах. Включите [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) для активации таймера. |
| [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) | Выбирает предопределённую категорию скорости из [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium или Fast. Используется, когда точная длительность не указана. |

[Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) управляет только эффектом перехода; она не определяет, как долго слайд остаётся видимым. Задержку автоматического продвижения необходимо настраивать отдельно. Если явная длительность не задана, Aspose.Slides определяет её по типу перехода и значению [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/).

### **Применить одинаковую длительность ко всем слайдам**

Для одинакового темпа применяйте один и тот же эффект и точную длительность ко всем слайдам. Этот пример загружает `input.pptx`, выбирает Fade из [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) и задаёт каждой переходу длительность 750 мс. Автоматическое продвижение включается через 5 000 мс, а продвижение щелчком мыши отключается; затем результат сохраняется как PPTX.

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

### **Установить разные длительности для отдельных слайдов**

Разные слайды могут использовать разные длительности эффектов. Например, короткий переход для заглавного слайда и более длительный для введения раздела. Этот пример задаёт 500 мс для первого слайда и 1 200 мс для второго. Используйте файл `input.pptx` с как минимум двумя слайдами.

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

### **Скоординировать переходы с анимированным выводом**

При подготовке [animated GIF](/slides/ru/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/ru/net/export-to-html5/) или [video](/slides/ru/net/convert-powerpoint-to-video/) задавайте точные длительности переходов перед экспортом, чтобы соответствовать требуемому темпу. Например, используйте 600‑мс затухание между сценами и регулируйте задержку продвижения каждого слайда отдельно, чтобы дать время для озвучки или содержимого.

Для GIF и видео согласуйте частоту кадров вывода с длительностью эффекта: 600 мс соответствует 18 кадрам при 30 fps. В HTML5 включайте анимированные переходы в настройках экспорта. Проверьте поддерживаемые эффекты и параметры времени выбранного формата и предварительно просмотрите результат для подтверждения синхронизации.

### **Прочитать существующую длительность перехода**

Прочитайте [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) перед изменением перехода, чтобы определить, хранится ли явное значение. Значение `-1` означает, что явная длительность не задана; неотрицательное значение указывает сохранённую длительность в миллисекундах. Неустановленное значение не является рассчитанной длительностью воспроизведения: Aspose.Slides использует тип перехода и [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) для её определения. Установка типа перехода может инициализировать длительность, поэтому сначала проверьте исходные настройки.

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

## **Переход Morph**

Переход Morph анимирует изменения между объектами на последовательных слайдах. Чтобы создать простой эффект Morph, клонируйте слайд, переместите или измените размер объекта в копии и примените переход Morph ко второму слайду. Это даёт анимацию соответствующих объектов между их исходным и изменённым состояниями.

Следующий пример создаёт слайд с текстовым прямоугольником, клонирует его и меняет позицию и размер прямоугольника в копии. Затем для второго слайда выбирает Morph из перечисления [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/). Откройте сохранённый файл в просмотрщике презентаций, поддерживающем Morph, чтобы увидеть эффект во время показа.

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

## **Типы перехода Morph**

Перечисление [TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) управляет тем, как Morph сопоставляет и анимирует содержимое:

- [ByObject](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) рассматривает каждую форму как целый объект.
- [ByWord](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) анимирует текст, сопоставляя слова, где это возможно.
- [ByChar](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) анимирует текст, сопоставляя символы, где это возможно.

Установите [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) перехода в Morph перед доступом к [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/). Затем значение предоставляет интерфейс [IMorphTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/), а его свойство [MorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/morphtype/) выбирает режим сопоставления.

Этот пример открывает презентацию, созданную в предыдущем разделе, и настраивает второй слайд на анимацию Morph по словам.

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
[![Единицы сопоставления Morph, показанные как целая форма, отдельные слова и отдельные символы.](visual-slide-transition-76bdbee41cb7.svg)](visual-slide-transition-76bdbee41cb7.svg)

*Morph может сопоставлять целые формы, слова или символы, где это возможно. Эти рамки обозначают сопоставляемые единицы, а не наблюдаемое движение. В примере выбран ByWord на втором слайде.*
<!-- visual-explanation:slide-transition:end -->

## **Установить эффекты перехода**

Некоторые переходы предоставляют дополнительные параметры, такие как направление или начало эффекта с чёрного экрана. Доступные параметры зависят от выбранного [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/). Сначала задайте тип, затем используйте соответствующий интерфейс из его [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/).

Следующий пример применяет переход Cut к первому слайду `input.pptx`. Он устанавливает [FromBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) через [IOptionalBlackTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/), чтобы переход начинался с чёрного экрана.

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

**Могу ли я контролировать скорость воспроизведения перехода слайда?**

Да. Предпочтительно использовать [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/), когда нужна точная длительность эффекта в миллисекундах. Используйте [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/), если достаточно предопределённой категории [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium или Fast, и явная длительность не задана. Эти настройки управляют только эффектом перехода, независимо от задержки автоматического продвижения.

**Можно ли привязать звук к переходу и зациклить его?**

Да. Назначьте встроенный звук свойству [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/), установите [SoundMode](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundmode/) в StartSound из перечисления [TransitionSoundMode](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionsoundmode/), и включите [SoundLoop](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundloop/). Звук будет повторяться до следующего звукового события в показе.

**Какой самый быстрый способ применить одинаковый переход ко всем слайдам?**

Пройдите в цикле коллекцию [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) презентации и установите каждому слайду свойству перехода [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) одно и то же значение. В том же цикле задайте все параметры времени и эффекта, чтобы поведение оставалось одинаковым для всех слайдов.

**Как проверить, какой переход установлен на текущем слайде?**

Прочитайте свойство [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) у [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) слайда. Оно вернёт значение из перечисления [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/); None означает, что переход не применён.