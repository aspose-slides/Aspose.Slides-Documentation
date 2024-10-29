---
title: Конвертация PowerPoint в Видео
type: docs
weight: 130
url: /ru/net/convert-powerpoint-to-video/
keywords: "Конвертация PowerPoint, PPT, PPTX, Презентация, Видео, MP4, PPT в видео, PPT в MP4, C#, Csharp, .NET, Aspose.Slides"
description: "Конвертация PowerPoint в Видео на C# или .NET"
---

Конвертируя вашу презентацию PowerPoint в видео, вы получаете 

* **Увеличение доступности:** Все устройства (независимо от платформы) по умолчанию оснащены видеоплеерами по сравнению с приложениями для открытия презентаций, поэтому пользователям проще открывать или воспроизводить видео.
* **Большее охваты:** С помощью видео вы можете достичь широкой аудитории и донести до них информацию, которая в противном случае может показаться утомительной в презентации. Большинство опросов и статистики показывают, что люди смотрят и потребляют видео больше, чем другие формы контента, и они в целом предпочитают такой контент.

{{% alert color="primary" %}} 

Вы можете ознакомиться с нашим [**Онлайн Конвертером PowerPoint в Видео**](https://products.aspose.app/slides/conversion/ppt-to-word), так как это живая и эффективная реализация процесса, описанного здесь.

{{% /alert %}} 

## **Конвертация PowerPoint в Видео в Aspose.Slides**

В [Aspose.Slides 22.11](https://docs.aspose.com/slides/net/aspose-slides-for-net-22-11-release-notes/) мы реализовали поддержку конвертации презентации в видео. 

* Используйте Aspose.Slides для генерации набора кадров (из слайдов презентации), которые соответствуют определенному FPS (кадров в секунду)
* Используйте стороннюю утилиту, такую как FFMpegCore (ffmpeg), чтобы создать видео на основе кадров. 

### **Конвертация PowerPoint в Видео**

1. Используйте команду dotnet add package, чтобы добавить Aspose.Slides и библиотеку FFMpegCore в ваш проект:
   * выполните `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * выполните `dotnet add package FFMpegCore --version 4.8.0`
2. Скачайте ffmpeg [здесь](https://ffmpeg.org/download.html).
3. FFMpegCore требует указать путь к загруженному ffmpeg (например, распакованный в "C:\tools\ffmpeg"):  `GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin",} );`
4. Запустите код конвертации PowerPoint в видео.

Этот код на C# показывает, как конвертировать презентацию (содержащую фигуру и два анимационных эффекта) в видео:

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // Будем использовать бинарные файлы FFmpeg, которые мы извлекли в "c:\tools\ffmpeg" ранее
using Aspose.Slides.Animation;
using (Presentation presentation = new Presentation())

{
    // Добавляет форму смайлика и затем анимирует ее
    IAutoShape smile = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    IEffect effectIn = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
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

    // Настройка папки с бинарными файлами ffmpeg. Смотрите эту страницу: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin", });
    // Конвертирует кадры в видео webm
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());

}
```

## **Видеоеффекты**

Вы можете применять анимации к объектам на слайдах и использовать переходы между слайдами. 

{{% alert color="primary" %}} 

Вы можете ознакомиться с этими статьями: [Анимация PowerPoint](https://docs.aspose.com/slides/net/powerpoint-animation/), [Анимация формы](https://docs.aspose.com/slides/net/shape-animation/), и [Эффект формы](https://docs.aspose.com/slides/net/shape-effect/).

{{% /alert %}} 

Анимации и переходы делают слайд-шоу более увлекательными и интересными — и они делают то же самое для видео. Давайте добавим еще один слайд и переход к коду для предыдущей презентации:

```c#
// Добавляет форму смайлика и анимирует ее

// ...

// Добавляет новый слайд и анимированный переход

ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

newSlide.Background.Type = BackgroundType.OwnBackground;

newSlide.Background.FillFormat.FillType = FillType.Solid;

newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;

newSlide.SlideShowTransition.Type = TransitionType.Push;
```

Aspose.Slides также поддерживает анимацию для текстов. Так что мы анимируем параграфы на объектах, которые появятся один за другим (с задержкой, установленной на секунду):

```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    // Добавляет текст и анимации
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.Portions.Add(new Portion("Aspose Slides для .NET"));
    Paragraph para2 = new Paragraph();
    para2.Portions.Add(new Portion("конвертировать презентацию PowerPoint с текстом в видео"));

    Paragraph para3 = new Paragraph();
    para3.Portions.Add(new Portion("параграф за параграфом"));
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    autoShape.TextFrame.Paragraphs.Add(new Paragraph());

    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect2 = presentation.Slides[0].Timeline.MainSequence.AddEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect3 = presentation.Slides[0].Timeline.MainSequence.AddEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect4 = presentation.Slides[0].Timeline.MainSequence.AddEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect.Timing.TriggerDelayTime = 1f;
    effect2.Timing.TriggerDelayTime = 1f;
    effect3.Timing.TriggerDelayTime = 1f;
    effect4.Timing.TriggerDelayTime = 1f;

    // Конвертирует кадры в видео
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
    // Настройка папки с бинарными файлами ffmpeg. Смотрите эту страницу: https://github.com/rosenbjerg/FFMpegCore#installation

    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin", });
    // Конвертирует кадры в видео webm
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());

}
```

## **Классы конвертации видео**

Для выполнения задач конвертации PowerPoint в видео Aspose.Slides предоставляет классы [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) и [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/).

PresentationAnimationsGenerator позволяет вам установить размер кадра для видео (которое будет создано позже) через его конструктор. Если вы передадите экземпляр презентации, будет использован `Presentation.SlideSize`, и он генерирует анимации, которые использует [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/). 

Когда анимации сгенерированы, для каждой последующей анимации генерируется событие `NewAnimation`, которое имеет параметр [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/). Последний — это класс, представляющий игрока для отдельной анимации.

Для работы с [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/) используются свойство [Duration](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/duration/) (общая длительность анимации) и метод [SetTimePosition](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/). Каждое положение анимации устанавливается в диапазоне *от 0 до длительности*, а затем метод `GetFrame` вернет Bitmap, который соответствует состоянию анимации в этот момент.

```c#
using (Presentation presentation = new Presentation())
{
    // Добавляет форму смайлика и анимирует ее
    IAutoShape smile = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    IEffect effectIn = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    {
        animationsGenerator.NewAnimation += animationPlayer =>
        {
            Console.WriteLine($"Общая длительность анимации: {animationPlayer.Duration}");
            
            animationPlayer.SetTimePosition(0); // начальное состояние анимации
            Bitmap bitmap = animationPlayer.GetFrame(); // битмап начального состояния анимации

            animationPlayer.SetTimePosition(animationPlayer.Duration); // конечное состояние анимации
            Bitmap lastBitmap = animationPlayer.GetFrame(); // последний кадр анимации
            lastBitmap.Save("last.png");
        };
    }
}
```

Чтобы все анимации в презентации воспроизводились одновременно, используется класс [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/). Этот класс принимает экземпляр [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) и FPS для эффектов в своем конструкторе, а затем вызывает событие `FrameTick` для всех анимаций, чтобы их воспроизвести:

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

Затем сгенерированные кадры могут быть собраны, чтобы создать видео. Смотрите раздел [Конвертация PowerPoint в Видео](https://docs.aspose.com/slides/net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Поддерживаемые анимации и эффекты**


**Вход**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Появление** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Потускнение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Вход с летящим эффектом** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Вход с плавным эффектом** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Разделение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Смыв** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Форма** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Колесо** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Случайные полосы** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Рост и поворот** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Масштабирование** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Качание** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Отскок** | ![поддерживается](v.png) | ![поддерживается](v.png) |


**Акцент**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Пульсация** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Цветовая пульсация** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Качание** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Вращение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Увеличение/уменьшение** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Обесцвечивание** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Потемнение** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Осветление** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Прозрачность** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Цвет объекта** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Дополнительный цвет** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Цвет линии** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Цвет заливки** | ![не поддерживается](x.png) | ![поддерживается](v.png) |

**Выход**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Исчезновение** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Потускнение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Выход с летящим эффектом** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Выход с плавным эффектом** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Разделение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Смыв** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Форма** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Случайные полосы** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Уменьшение и поворот** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Масштабирование** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Качание** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Отскок** | ![поддерживается](v.png) | ![поддерживается](v.png) |

**Движения по траектории:**

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Линии** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Арки** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Повороты** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Формы** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Циклы** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Пользовательский путь** | ![поддерживается](v.png) | ![поддерживается](v.png) |

## **Поддерживаемые эффекты переходов слайдов**

**Нежные**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Морфинг** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Потускнение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Толчок** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Привлечение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Смыв** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Разделение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Открытие** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Случайные полосы** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Форма** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Скрытие** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Покрытие** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Мигает** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Полосы** | ![поддерживается](v.png) | ![поддерживается](v.png) |

**Возбуждающие**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Упадок** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Драпировка** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Занавес** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Ветер** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Престиж** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Фрактура** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Сжатие** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Снятие** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Сгибание страниц** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Самолет** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Оригами** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Растворение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Шахматная доска** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Жалюзи** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Часы** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Волна** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Соты** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Искры** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Воронка** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Рубка** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Переключить** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Перевернуть** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Галерея** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Куб** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Дверцы** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Коробка** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Гребень** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Масштабирование** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Случайный** | ![не поддерживается](x.png) | ![поддерживается](v.png) |

**Динамическое содержимое**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Панорамирование** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Колесо обозрения** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Конвейер** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Вращение** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Орбита** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Полет сквозь** | ![поддерживается](v.png) | ![поддерживается](v.png) |