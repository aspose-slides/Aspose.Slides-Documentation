---
title: Видео
type: docs
weight: 80
url: /ru/net/examples/elements/video/
keywords:
- пример видео
- видеокадр
- добавить видео
- доступ к видео
- удалить видео
- воспроизведение видео
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Работа с видео в C# с использованием Aspose.Slides: вставка, замена, обрезка, установка постеров и параметров воспроизведения, а также экспорт презентаций в форматы PPT, PPTX и ODP."
---

Показывает, как вставлять видеокадры и задавать параметры воспроизведения с помощью **Aspose.Slides for .NET**.

## Добавить видеокадр

Вставьте пустой видеокадр на слайд.
```csharp
static void Add_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Добавить пустой встроенный видеокадр
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```


## Получить видеокадр

Получите первый видеокадр, добавленный на слайд.
```csharp
static void Access_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Получить первый видеокадр на слайде
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```


## Удалить видеокадр

Удалите видеокадр со слайда.
```csharp
static void Remove_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Удалить видеокадр
    slide.Shapes.Remove(videoFrame);
}
```


## Настроить воспроизведение видео

Настройте видео так, чтобы оно воспроизводилось автоматически при отображении слайда.
```csharp
static void Set_Video_Playback()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Настроить автоматическое воспроизведение видео
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```
