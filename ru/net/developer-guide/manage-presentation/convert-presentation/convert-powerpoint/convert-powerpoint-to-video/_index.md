---
title: Конвертировать презентации PowerPoint в видео в .NET
linktitle: PowerPoint в видео
type: docs
weight: 130
url: /ru/net/convert-powerpoint-to-video/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в видео
- презентация в видео
- PPT в видео
- PPTX в видео
- PowerPoint в MP4
- презентация в MP4
- PPT в MP4
- PPTX в MP4
- сохранить PPT как MP4
- сохранить PPTX как MP4
- экспортировать PPT в MP4
- экспортировать PPTX в MP4
- конвертация видео
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как конвертировать презентации PowerPoint в видео в .NET. Откройте образцы кода C# и техники автоматизации для оптимизации вашего рабочего процесса."
---

## **Обзор**

Конвертируя вашу презентацию PowerPoint или OpenDocument в видео, вы получаете:

**Повышенная доступность:** На всех устройствах, независимо от платформы, по умолчанию установлены видеоплееры, что делает воспроизведение видео проще, чем открытие традиционных приложений для презентаций.

**Широкий охват:** Видео позволяют охватить более большую аудиторию и представить информацию в более вовлекающем формате. Опросы и статистика показывают, что люди предпочитают смотреть и потреблять видеоконтент по сравнению с другими формами, делая ваше сообщение более воздействующим.

{{% alert color="primary" %}} 

Ознакомьтесь с нашим [**Онлайн-конвертером PowerPoint в видео**](https://products.aspose.app/slides/video), который предоставляет живую и эффективную реализацию процесса, описанного здесь.

{{% /alert %}} 

В Aspose.Slides for .NET мы реализовали поддержку преобразования презентаций в видео.

* Используйте Aspose.Slides for .NET для генерации кадров из слайдов презентации с указанной частотой кадров (FPS).
* Затем примените стороннюю утилиту, например ffmpeg, для сборки этих кадров в видео.

## **Преобразование презентации PowerPoint в видео**

1. Используйте команду `dotnet add package` для добавления Aspose.Slides и библиотеки FFMpegCore в ваш проект:
   * выполните `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * выполните `dotnet add package FFMpegCore --version 4.8.0`
2. Скачайте ffmpeg [здесь](https://ffmpeg.org/download.html).
3. FFMpegCore требует указать путь к загруженному ffmpeg (например, распакованный в "C:\tools\ffmpeg"):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```

4. Запустите код конвертации PowerPoint в видео.

Этот C# код демонстрирует, как преобразовать презентацию (с фигурой и двумя эффектами анимации) в видео:
```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // будет использовать бинарные файлы FFmpeg, которые мы извлекли в C:\tools\ffmpeg ранее.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Добавьте форму улыбающегося лица и затем анимируйте её.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };
        animationsGenerator.Run(presentation.Slides);
    }

    // Настройте папку с бинарными файлами ffmpeg. Смотрите эту страницу: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Преобразуйте кадры в видео webm.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```


## **Эффекты видео**

При конвертации презентации PowerPoint в видео с помощью Aspose.Slides for .NET вы можете применять различные видеоеффекты для улучшения визуального качества результата. Эти эффекты позволяют контролировать внешний вид слайдов в финальном видео, добавляя плавные переходы, анимации и другие визуальные элементы. В этом разделе описаны доступные варианты видеоеффектов и показывается, как их применить.

{{% alert color="primary" %}} 

Смотрите:
- [Улучшение презентаций PowerPoint анимациями на C#](https://docs.aspose.com/slides/net/powerpoint-animation/)
- [Анимация фигур](https://docs.aspose.com/slides/net/shape-animation/)
- [Применение эффектов фигур в PowerPoint с помощью C#](https://docs.aspose.com/slides/net/shape-effect/)

{{% /alert %}} 

Анимации и переходы делают слайд-шоу более увлекательными и интересными — то же самое относится и к видео. Добавим еще один слайд и переход в код для предыдущей презентации:
```c#
// Добавьте форму улыбающегося лица и анимируйте её.
// ...

// Добавьте новый слайд и анимированный переход.
ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
newSlide.Background.Type = BackgroundType.OwnBackground;
newSlide.Background.FillFormat.FillType = FillType.Solid;
newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
newSlide.SlideShowTransition.Type = TransitionType.Push;
```


Aspose.Slides также поддерживает анимацию текста. В этом примере мы анимируем абзацы объектов так, чтобы они появлялись один за другим с задержкой в одну секунду:
```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Добавьте текст и анимацию.
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.Portions.Add(new Portion("Aspose Slides for .NET"));
    Paragraph para2 = new Paragraph();
    para2.Portions.Add(new Portion("Convert a PowerPoint presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.Portions.Add(new Portion("paragraph by paragraph"));
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    autoShape.TextFrame.Paragraphs.Add(new Paragraph());

    IEffect effect1 = slide.Timeline.MainSequence.AddEffect(
        para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect2 = slide.Timeline.MainSequence.AddEffect(
        para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect3 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect4 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.Timing.TriggerDelayTime = 1f;
    effect2.Timing.TriggerDelayTime = 1f;
    effect3.Timing.TriggerDelayTime = 1f;
    effect4.Timing.TriggerDelayTime = 1f;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };

        animationsGenerator.Run(presentation.Slides);
    }

    // Настройте папку с бинарными файлами ffmpeg. См. эту страницу: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Преобразуйте кадры в видео webm.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```


## **Классы конвертации видео**

Для выполнения задач преобразования PowerPoint в видео Aspose.Slides for .NET предоставляет классы [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) и [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/).

`PresentationAnimationsGenerator` позволяет задать размер кадра для будущего видео и значение FPS (кадров в секунду) через конструктор. Если передать экземпляр презентации, будет использован её `Presentation.SlideSize`, и он генерирует анимации, которые использует [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/).

При генерации анимаций для каждой последующей анимации вызывается событие `NewAnimation`, которое содержит параметр [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/). Этот класс представляет плеер для отдельной анимации.

Для работы с [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/) используйте свойство [Duration](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/duration/) (полная длительность анимации) и метод [SetTimePosition](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/). Каждая позиция анимации задается в диапазоне *0 до duration*, а метод `GetFrame` возвращает Bitmap, представляющий состояние анимации в этот момент времени.
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Добавьте форму улыбающегося лица и анимируйте её.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    {
        animationsGenerator.NewAnimation += animationPlayer =>
        {
            Console.WriteLine($"Total animation duration: {animationPlayer.Duration}");

            animationPlayer.SetTimePosition(0);          // Начальное состояние анимации.
            Bitmap bitmap = animationPlayer.GetFrame();  // Битмап начального состояния анимации.

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // Конечное состояние анимации.
            Bitmap lastBitmap = animationPlayer.GetFrame();             // Последний кадр анимации.
            lastBitmap.Save("last.png");
        };
    }
}
```


Чтобы все анимации презентации воспроизводились одновременно, используется класс [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/). Он принимает экземпляр [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) и значение FPS для эффектов в конструкторе, затем вызывает событие `FrameTick` для всех анимаций, чтобы запустить их воспроизведение:
```c#
using (Presentation presentation = new Presentation("animated.pptx"))
{
    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, 33))
    {
        player.FrameTick += (sender, args) =>
        {
            args.GetFrame().Save($"frame_{sender.FrameIndex}.png");
        };
        animationsGenerator.Run(presentation.Slides);
    }
}
```


Сгенерированные кадры затем можно собрать в видео. Смотрите раздел [Convert a PowerPoint Presentation to Video](/slides/ru/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video).

## **Поддерживаемые анимации и эффекты**

При конвертации презентации PowerPoint в видео с помощью Aspose.Slides for .NET важно знать, какие анимации и эффекты поддерживаются в итоговом файле. Aspose.Slides поддерживает широкий набор типичных эффектов входа, выхода и выделения, таких как исчезновение, перемещение, масштабирование и вращение. Однако некоторые продвинутые или кастомные анимации могут не сохраняться полностью или отображаться иначе в финальном видео. В этом разделе перечислены поддерживаемые анимации и эффекты.

**Вход**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Выделение**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**Выход**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Пути движения**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Поддерживаемые эффекты перехода слайдов**

Эффекты перехода слайдов играют важную роль в создании плавных и визуально привлекательных смен между слайдами в видео. Aspose.Slides for .NET поддерживает разнообразные часто используемые эффекты переходов, помогая сохранить поток и стиль оригинальной презентации. Ниже перечислены поддерживаемые эффекты переходов.

**Тонкие**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Push** | ![supported](v.png) | ![supported](v.png) |
| **Pull** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Reveal** | ![not supported](x.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![not supported](x.png) | ![supported](v.png) |
| **Uncover** | ![not supported](x.png) | ![supported](v.png) |
| **Cover** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Strips** | ![supported](v.png) | ![supported](v.png) |

**Эффектные**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![not supported](x.png) | ![supported](v.png) |
| **Drape** | ![not supported](x.png) | ![supported](v.png) |
| **Curtains** | ![not supported](x.png) | ![supported](v.png) |
| **Wind** | ![not supported](x.png) | ![supported](v.png) |
| **Prestige** | ![not supported](x.png) | ![supported](v.png) |
| **Fracture** | ![not supported](x.png) | ![supported](v.png) |
| **Crush** | ![not supported](x.png) | ![supported](v.png) |
| **Peel Off** | ![not supported](x.png) | ![supported](v.png) |
| **Page Curl** | ![not supported](x.png) | ![supported](v.png) |
| **Airplane** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolve** | ![supported](v.png) | ![supported](v.png) |
| **Checkerboard** | ![not supported](x.png) | ![supported](v.png) |
| **Blinds** | ![not supported](x.png) | ![supported](v.png) |
| **Clock** | ![supported](v.png) | ![supported](v.png) |
| **Ripple** | ![not supported](x.png) | ![supported](v.png) |
| **Honeycomb** | ![not supported](x.png) | ![supported](v.png) |
| **Glitter** | ![not supported](x.png) | ![supported](v.png) |
| **Vortex** | ![not supported](x.png) | ![supported](v.png) |
| **Shred** | ![not supported](x.png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x.png) | ![supported](v.png) |
| **Gallery** | ![not supported](x.png) | ![supported](v.png) |
| **Cube** | ![not supported](x.png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**Динамический контент**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Можно ли конвертировать презентации, защищённые паролем?**

Да, Aspose.Slides for .NET поддерживает работу с презентациями, защищёнными паролем. При обработке таких файлов необходимо предоставить правильный пароль, чтобы библиотека могла получить доступ к содержимому презентации.

**Поддерживает ли Aspose.Slides for .NET использование в облачных решениях?**

Да, Aspose.Slides for .NET можно интегрировать в облачные приложения и сервисы. Библиотека разработана для работы в серверных средах, обеспечивая высокую производительность и масштабируемость при пакетной обработке файлов.

**Есть ли ограничения по размеру презентаций при конвертации?**

Aspose.Slides for .NET способен обрабатывать презентации практически любого размера. Однако при работе с очень большими файлами могут потребоваться дополнительные системные ресурсы, и иногда рекомендуется оптимизировать презентацию для повышения производительности.