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
- презентацию в видео
- PPT в видео
- PPTX в видео
- PowerPoint в MP4
- презентацию в MP4
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
description: "Узнайте, как конвертировать презентации PowerPoint в видео в .NET. Откройте образцы кода на C# и методы автоматизации для упрощения вашего рабочего процесса."
---
## **Введение**

Преобразуя вашу презентацию PowerPoint или OpenDocument в видео, вы получаете:

**Повышенная доступность:** Все устройства, независимо от платформы, по умолчанию оснащены видеоплеерами, что облегчает пользователям открытие и воспроизведение видео по сравнению с традиционными приложениями для презентаций.

**Больший охват:** Видео позволяют охватить более широкую аудиторию и представить информацию в более увлекательном формате. Опросы и статистика показывают, что люди предпочитают смотреть и потреблять видеоконтент по сравнению с другими формами, делая ваше сообщение более эффективным.

{{% alert color="info" %}} 
Ознакомьтесь с нашим [**Онлайн-конвертером PowerPoint в видео**](https://products.aspose.app/slides/ru/video), потому что он предлагает живую и эффективную реализацию описанного здесь процесса.
{{% /alert %}} 

В Aspose.Slides для .NET мы реализовали поддержку преобразования презентаций в видео.

* Используйте Aspose.Slides для .NET для генерации кадров из слайдов презентации с указанной частотой кадров (FPS).
* Затем используйте стороннюю утилиту, например ffmpeg, чтобы собрать эти кадры в видео.

## **Преобразование презентации PowerPoint в видео**

1. Используйте команду `dotnet add package`, чтобы добавить Aspose.Slides и библиотеку FFMpegCore в ваш проект:
   * выполните `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * выполните `dotnet add package FFMpegCore --version 4.8.0`
2. Скачайте ffmpeg по ссылке [здесь](https://ffmpeg.org/download.html).
3. FFMpegCore требует указать путь к загруженному ffmpeg (например, извлечённый в "C:\tools\ffmpeg"):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. Запустите код конвертации PowerPoint в видео.

Этот C# код демонстрирует, как преобразовать презентацию (содержащую фигуру и два эффекта анимации) в видео:
```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // будет использовать бинарные файлы FFmpeg, которые мы извлекли в C:\tools\ffmpeg ранее.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Добавить форму улыбки и затем анимировать её.
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

    // Настроить папку с бинарными файлами ffmpeg. См. эту страницу: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Конвертировать кадры в видео webm.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Видеоэффекты**

При конвертации презентации PowerPoint в видео с помощью Aspose.Slides для .NET вы можете применять различные видеоеффекты для улучшения визуального качества результата. Эти эффекты позволяют управлять внешним видом слайдов в конечном видео, добавляя плавные переходы, анимации и другие визуальные элементы. В этом разделе объясняются доступные параметры видеоеффектов и показано, как их применять.

{{% alert color="info" %}} 
Смотрите:
- [Enhancing PowerPoint Presentations with Animations in C#](https://docs.aspose.com/slides/ru/net/powerpoint-animation/)
- [Shape Animation](https://docs.aspose.com/slides/ru/net/shape-animation/)
- [Apply Shape Effects in PowerPoint Using C#](https://docs.aspose.com/slides/ru/net/shape-effect/)
{{% /alert %}} 

Анимации и переходы делают слайд‑шоу более увлекательными и интересными — и то же самое происходит с видео. Добавим ещё один слайд и переход в код для предыдущей презентации:
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.SlideShow;

using (Presentation presentation = new Presentation())
{
    // Добавьте форму улыбки и анимируйте её (см. код выше).

    // Добавьте новый слайд и анимированный переход.
    ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
    newSlide.Background.Type = BackgroundType.OwnBackground;
    newSlide.Background.FillFormat.FillType = FillType.Solid;
    newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
    newSlide.SlideShowTransition.Type = TransitionType.Push;
}
```

Aspose.Slides также поддерживает анимацию текста. В этом примере мы анимируем абзацы на объектах так, чтобы они появлялись один за другим с односекундной задержкой между ними:
```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Добавить текст и анимацию.
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

    // Настроить папку с бинарными файлами ffmpeg. См. эту страницу: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Преобразовать кадры в видео webm.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Классы конвертации видео**

Чтобы обеспечить задачи конвертации PowerPoint в видео, Aspose.Slides для .NET предоставляет классы [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ru/net/aspose.slides.export/presentationanimationsgenerator/) и [PresentationPlayer](https://reference.aspose.com/slides/ru/net/aspose.slides.export/presentationplayer/).

`PresentationAnimationsGenerator` позволяет задать размер кадра для будущего видео и значение FPS (кадров в секунду) через конструктор. Если передать экземпляр презентации, будет использовано его `Presentation.SlideSize`, и он генерирует анимации, которые использует [PresentationPlayer](https://reference.aspose.com/slides/ru/net/aspose.slides.export/presentationplayer/).

При генерации анимаций для каждой последующей анимации генерируется событие `NewAnimation`, которое включает параметр [IPresentationAnimationPlayer](https://reference.aspose.com/slides/ru/net/aspose.slides.export/ipresentationanimationplayer/). Этот класс представляет плеер отдельной анимации.

Для работы с [IPresentationAnimationPlayer](https://reference.aspose.com/slides/ru/net/aspose.slides.export/ipresentationanimationplayer/) используйте свойство [Duration](https://reference.aspose.com/slides/ru/net/aspose.slides.export/ipresentationanimationplayer/duration/) (которое возвращает полную длительность анимации) и метод [SetTimePosition](https://reference.aspose.com/slides/ru/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/). Позиция каждой анимации задаётся в диапазоне *0 до duration*, а метод `GetFrame` возвращает Bitmap, представляющий состояние анимации в этот момент.
```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Добавить форму улыбки и анимировать её.
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

            animationPlayer.SetTimePosition(0);        // Начальное состояние анимации.
            IImage image = animationPlayer.GetFrame(); // Изображение начального состояния анимации.

            animationPlayer.SetTimePosition(animationPlayer.Duration); // Конечное состояние анимации.
            IImage lastImage = animationPlayer.GetFrame();             // Последний кадр анимации.
            lastImage.Save("last.png");
        };
    }
}
```

Чтобы все анимации в презентации воспроизводились одновременно, используется класс [PresentationPlayer](https://reference.aspose.com/slides/ru/net/aspose.slides.export/presentationplayer/). Этот класс принимает в конструкторе экземпляр [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ru/net/aspose.slides.export/presentationanimationsgenerator/) и значение FPS для эффектов, а затем вызывает событие `FrameTick` для всех анимаций, чтобы воспроизвести их:
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Затем сгенерированные кадры можно собрать в видео. См. раздел [Convert a PowerPoint Presentation to Video](/slides/ru/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video).

## **Поддерживаемые анимации и эффекты**

При конвертации презентации PowerPoint в видео с помощью Aspose.Slides для .NET важно знать, какие анимации и эффекты поддерживаются в результате. Aspose.Slides поддерживает широкий спектр типичных эффектов входа, выхода и акцентирования, таких как затухание, «вылет», масштабирование и вращение. Однако некоторые продвинутые или пользовательские анимации могут не сохраняться полностью или отображаться иначе в финальном видео. В этом разделе перечислены поддерживаемые анимации и эффекты.

**Entrance**:

| Animation Type | Aspose.Slides | PowerPoint |
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

**Emphasis**:

| Animation Type | Aspose.Slides | PowerPoint |
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

**Exit**:

| Animation Type | Aspose.Slides | PowerPoint |
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

**Motion Paths**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Поддерживаемые эффекты переходов слайдов**

Эффекты переходов слайдов играют важную роль в создании плавных и визуально привлекательных смен между слайдами в видео. Aspose.Slides для .NET поддерживает различные часто используемые эффекты переходов, помогая сохранить поток и стиль оригинальной презентации. В этом разделе перечислены поддерживаемые эффекты переходов в процессе конвертации.

**Тонкие**:

| Animation Type | Aspose.Slides | PowerPoint |
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

| Animation Type | Aspose.Slides | PowerPoint |
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

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **Часто задаваемые вопросы**

### Можно ли преобразовать презентации, защищённые паролем?

Да, Aspose.Slides для .NET позволяет работать с презентациями, защищёнными паролем. При обработке таких файлов необходимо предоставить правильный пароль, чтобы библиотека могла получить доступ к содержимому презентации.

### Поддерживает ли Aspose.Slides для .NET использование в облачных решениях?

Да, Aspose.Slides для .NET может быть интегрирован в облачные приложения и сервисы. Библиотека разработана для работы в серверных средах, обеспечивая высокую производительность и масштабируемость при пакетной обработке файлов.

### Есть ли ограничения по размеру презентаций при конвертации?

Aspose.Slides для .NET способен обрабатывать презентации практически любого размера. Однако при работе с очень большими файлами могут потребоваться дополнительные системные ресурсы, и иногда рекомендуется оптимизировать презентацию для повышения производительности.