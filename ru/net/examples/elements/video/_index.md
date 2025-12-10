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
description: "Работайте с видео в C# с помощью Aspose.Slides: вставка, замена, обрезка, установка постеров и параметров воспроизведения, экспорт презентаций в форматы PPT, PPTX и ODP."
---

Показано, как встраивать видеокадры и задавать параметры воспроизведения с использованием **Aspose.Slides for .NET**.

## **Add a Video Frame**
Insert an empty video frame onto a slide.
```csharp
static void Add_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Добавить пустой встроенный видеокадр
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```


## **Access a Video Frame**
Retrieve the first video frame added to a slide.
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


## **Remove a Video Frame**
Delete a video frame from the slide.
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


## **Set Video Playback**
Configure the video to play automatically when the slide is displayed.
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
