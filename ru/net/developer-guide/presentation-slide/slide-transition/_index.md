---
title: Управление переходами слайдов в презентациях в .NET
linktitle: Переход слайда
type: docs
weight: 90
url: /ru/net/slide-transition/
keywords:
- переход слайда
- добавление перехода слайда
- применение перехода слайда
- расширенный переход слайда
- Morph‑переход
- тип перехода
- эффект перехода
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Применяйте переходы слайдов, настраивайте автоматическое переключение слайдов и кастомизируйте Morph и другие эффекты переходов с помощью Aspose.Slides для .NET."
---
## **Обзор**

Переходы слайдов управляют тем, как слайды появляются во время показа. С помощью Aspose.Slides for .NET можно выбрать эффект перехода для каждого слайда, настроить переключение по щелчку мыши или по таймеру и задать параметры, специфичные для эффекта. В этой статье использованы примеры на C#, демонстрирующие применение переходов, установку точных длительностей переходов, управление временем показа слайда и создание перехода Morph между двумя слайдами. Примеры также показывают, как сохранить настройки в файл PPTX.

## **Добавить переход к слайду**

Чтобы применить переход, загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) и получите доступ к свойству [SlideShowTransition](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseslide/slideshowtransition/) слайда. Установите его [Type](https://reference.aspose.com/slides/ru/net/aspose.slides/islideshowtransition/type/) в значение из перечисления [TransitionType](https://reference.aspose.com/slides/ru/net/aspose.slides.slideshow/transitiontype/), затем сохраните презентацию.

В следующем примере применяется переход Circle к первому слайду и переход Comb ко второму. Используйте файл `input.pptx` минимум с двумя слайдами.

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

## **Добавить расширенный переход к слайду**

Можно настроить, как долго слайд остаётся на экране и будет ли щелчок мыши переключать показ. Следующие свойства управляют этим поведением:

- [AdvanceOnClick](https://reference.aspose.com/slides/ru/net/aspose.slides/islideshowtransition/advanceonclick/) позволяет зрителю перейти к следующему слайду щелчком мыши.
- [AdvanceAfter](https://reference.aspose.com/slides/ru/net/aspose.slides/islideshowtransition/advanceafter/) включает автоматическое переключение.
- [AdvanceAfterTime](https://reference.aspose.com/slides/ru/net/aspose.slides/islideshowtransition/advanceaftertime/) задаёт задержку перед автоматическим переключением в миллисекундах.

Включите оба способа переключения, чтобы зритель мог перейти по щелчку или дождаться таймера. Чтобы использовать только таймер, установите [AdvanceOnClick](https://reference.aspose.com/slides/ru/net/aspose.slides/islideshowtransition/advanceonclick/) в `false`. Задержка управляет временем переключения показа; она не задаёт длительность визуального эффекта перехода.

В этом примере разным первым трём слайдам назначаются разные эффекты и включается автоматическое переключение через 3, 5 и 7 секунд соответственно. Щелчки мышью также могут переключать эти слайды. Используйте файл `input.pptx` минимум с тремя слайдами.

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

Чтобы проверить, включено ли автоматическое переключение, прочитайте [AdvanceAfter](https://reference.aspose.com/slides/ru/net/aspose.slides/islideshowtransition/advanceafter/). Само наличие сохранённой задержки не означает, что таймер активен.

В следующем примере открывается файл, сохранённый выше, выводятся все включённые таймеры, а для слайдов с задержкой более двух секунд автоматическое переключение отключается. Для этих слайдов включаются щелчки мышью, и изменённые настройки сохраняются.

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

## **Точное управление временем перехода**

Используйте [Duration](https://reference.aspose.com/slides/ru/net/aspose.slides.slideshow/slideshowtransition/duration/) для указания точной длительности эффекта перехода в миллисекундах. Свойство [SlideShowTransition](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseslide/slideshowtransition/) слайда предоставляет эти параметры через интерфейс [ISlideShowTransition](https://reference.aspose.com/slides/ru/net/aspose.slides/islideshowtransition/):

| Property | Purpose |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/ru/net/aspose.slides.slideshow/slideshowtransition/duration/) | Задает длительность самого эффекта перехода в миллисекундах. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/ru/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Задает задержку перед автоматическим переключением слайда в миллисекундах. Включите [AdvanceAfter](https://reference.aspose.com/slides/ru/net/aspose.slides/islideshowtransition/advanceafter/) для активации этого таймера. |
| [Speed](https://reference.aspose.com/slides/ru/net/aspose.slides.slideshow/slideshowtransition/speed/) | Выбирает предопределённую категорию скорости из [TransitionSpeed](https://reference.aspose.com/slides/ru/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium или Fast. Используется, когда точная длительность не указана. |

[Duration](https://reference.aspose.com/slides/ru/net/aspose.slides.slideshow/slideshowtransition/duration/) регулирует только эффект перехода; она не определяет, как долго слайд остаётся видимым. Задержку автоматического переключения следует настраивать отдельно. Если явная длительность не задана, Aspose.Slides определяет её из типа перехода и значения [Speed](https://reference.aspose.com/slides/ru/net/aspose.slides.slideshow/slideshowtransition/speed/).

### **Применить одинаковую длительность ко всем слайдам**

Для единообразного темпа примените один и тот же эффект и точную длительность ко всем слайдам. Этот пример загружает `input.pptx`, выбирает Fade из [TransitionType](https://reference.aspose.com/slides/ru/net/aspose.slides.slideshow/transitiontype/) и задаёт каждой переходу длительность 750 миллисекунд. Отдельно включается автоматическое переключение через 5 000 миллисекунд и отключается переключение щелчком мыши, затем результат сохраняется как PPTX.

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

    // Настройте автоматическое переключение независимо от длительности эффекта.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **Задать разные длительности для отдельных слайдов**

Разные слайды могут использовать разные длительности эффектов. Например, короткий переход для титульного слайда и более длительный для введения раздела. Этот пример задаёт 500 мс для первого слайда и 1 200 мс для второго. Используйте файл `input.pptx` минимум с двумя слайдами.

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

### **Координация переходов с анимированным выводом**

При подготовке [animated GIF](/slides/ru/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/ru/net/export-to-html5/) или [video](/slides/ru/net/convert-powerpoint-to-video/) задайте точные длительности переходов перед экспортом, чтобы они соответствовали планируемому темпу. Например, используйте плавный переход в 600 мс между сценами и отдельно настройте задержку переключения каждого слайда, чтобы обеспечить время для озвучки или содержания.

Для GIF и видео согласуйте частоту кадров вывода с длительностью эффекта: 600 мс соответствует 18 кадрам при 30 fps. В HTML5 включите анимированные переходы в настройках экспорта. Проверьте поддерживаемые эффекты и параметры времени выбранного формата и просмотрите результат для подтверждения синхронизации.

### **Прочитать существующую длительность перехода**

Прочитайте [Duration](https://reference.aspose.com/slides/ru/net/aspose.slides.slideshow/slideshowtransition/duration/) перед изменением перехода, чтобы определить, хранится ли явное значение. Значение `-1` означает, что явная длительность не задана; неотрицательное значение указывает сохранённую длительность в миллисекундах. Неустановленное значение не является рассчитанной длительностью воспроизведения: Aspose.Slides использует тип перехода и [Speed](https://reference.aspose.com/slides/ru/net/aspose.slides.slideshow/slideshowtransition/speed/) для её вычисления. Установка типа перехода может инициализировать длительность, поэтому сначала проверьте исходные настройки.

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

## **Morph‑переход**

Morph‑переход анимирует изменения между объектами на последовательных слайдах. Чтобы создать простой Morph‑эффект, склонируйте слайд, переместите или измените размер объекта на копии и примените Morph‑переход ко второму слайду. Это даёт анимацию соответствующих объектов между их исходным и изменённым состоянием.

В следующем примере создаётся слайд с текстовым прямоугольником, клонируется, а положение и размер прямоугольника изменяются в копии. Затем для второго слайда выбирается Morph из перечисления [TransitionType](https://reference.aspose.com/slides/ru/net/aspose.slides.slideshow/transitiontype/). Откройте сохранённый файл в просмотрщике презентаций, поддерживающем Morph, чтобы увидеть эффект во время показа.

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

## **Типы Morph‑переходов**

Перечисление [TransitionMorphType](https://reference.aspose.com/slides/ru/net/aspose.slides.slideshow/transitionmorphtype/) определяет, как Morph сопоставляет и анимирует содержимое:

- [ByObject](https://reference.aspose.com/slides/ru/net/aspose.slides.slideshow/transitionmorphtype/) рассматривает каждую форму как целый объект.
- [ByWord](https://reference.aspose.com/slides/ru/net/aspose.slides.slideshow/transitionmorphtype/) анимирует текст, сопоставляя слова, где это возможно.
- [ByChar](https://reference.aspose.com/slides/ru/net/aspose.slides.slideshow/transitionmorphtype/) анимирует текст, сопоставляя отдельные символы, где это возможно.

Установите свойство [Type](https://reference.aspose.com/slides/ru/net/aspose.slides/islideshowtransition/type/) перехода в Morph перед доступом к его [Value](https://reference.aspose.com/slides/ru/net/aspose.slides/islideshowtransition/value/). Затем значение предоставляет интерфейс [IMorphTransition](https://reference.aspose.com/slides/ru/net/aspose.slides.slideshow/imorphtransition/), у которого свойство [MorphType](https://reference.aspose.com/slides/ru/net/aspose.slides.slideshow/imorphtransition/morphtype/) выбирает режим сопоставления.

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

## **Установить параметры эффектов перехода**

Некоторые переходы предоставляют дополнительные параметры, такие как направление или начало эффекта с черного экрана. Доступные опции зависят от выбранного [Type](https://reference.aspose.com/slides/ru/net/aspose.slides/islideshowtransition/type/). Сначала задайте тип, затем используйте соответствующий интерфейс из его [Value](https://reference.aspose.com/slides/ru/net/aspose.slides/islideshowtransition/value/).

В следующем примере к первому слайду `input.pptx` применяется переход Cut. Через [IOptionalBlackTransition](https://reference.aspose.com/slides/ru/net/aspose.slides.slideshow/ioptionalblacktransition/) устанавливается [FromBlack](https://reference.aspose.com/slides/ru/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/), чтобы переход начинался с черного экрана.

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

Да. Используйте [Duration](https://reference.aspose.com/slides/ru/net/aspose.slides.slideshow/slideshowtransition/duration/), когда нужна точная длительность эффекта в миллисекундах. Используйте [Speed](https://reference.aspose.com/slides/ru/net/aspose.slides.slideshow/slideshowtransition/speed/), когда достаточно предопределённой категории [TransitionSpeed](https://reference.aspose.com/slides/ru/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium или Fast, и явная длительность не указана. Эти настройки управляют эффектом перехода независимо от задержки автоматического переключения.

**Можно ли прикрепить аудио к переходу и заставить его зацикливаться?**

Да. Присвойте встроенный звук свойству [Sound](https://reference.aspose.com/slides/ru/net/aspose.slides/islideshowtransition/sound/), установите [SoundMode](https://reference.aspose.com/slides/ru/net/aspose.slides/islideshowtransition/soundmode/) в StartSound из перечисления [TransitionSoundMode](https://reference.aspose.com/slides/ru/net/aspose.slides.slideshow/transitionsoundmode/), и включите [SoundLoop](https://reference.aspose.com/slides/ru/net/aspose.slides/islideshowtransition/soundloop/). Аудио будет зацикливаться до следующего звукового события в показе.

**Как быстрее всего применить один и тот же переход ко всем слайдам?**

Пройдитесь циклом по коллекции [Slides](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/slides/ru/) презентации и задайте каждому слайду свойству перехода [Type](https://reference.aspose.com/slides/ru/net/aspose.slides/islideshowtransition/type/) одинаковое значение. В том же цикле установите любые параметры времени и эффекта, чтобы поведение было одинаковым на всех слайдах.

**Как проверить, какой переход установлен на конкретном слайде?**

Прочитайте свойство [Type](https://reference.aspose.com/slides/ru/net/aspose.slides/islideshowtransition/type/) у слайда через его [SlideShowTransition](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseslide/slideshowtransition/). Возвращаемое значение принадлежит перечислению [TransitionType](https://reference.aspose.com/slides/ru/net/aspose.slides.slideshow/transitiontype/); значение None означает, что переход не применён.