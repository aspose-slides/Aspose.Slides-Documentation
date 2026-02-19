---
title: Видео
type: docs
weight: 80
url: /ru/net/examples/elements/video/
keywords:
- видео
- видеокадр
- добавить видео
- доступ к видео
- удалить видео
- воспроизведение видео
- пример кода
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Добавляйте и управляйте видео с помощью Aspose.Slides for .NET: вставляйте, воспроизводите, обрезайте, задавайте постер‑кадры и экспортируйте с примерами на C# для презентаций PPT, PPTX и ODP."
---
Эта статья демонстрирует, как вставлять видеокадры и задавать параметры воспроизведения с помощью **Aspose.Slides for .NET**.

## **Добавить видеокадр**

Вставьте пустой видеокадр на слайд.

```csharp
static void AddVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Добавить видео.
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```

## **Получить видеокадр**

Получите первый видеокадр, добавленный на слайд.

```csharp
static void AccessVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Получить первый видеокадр на слайде.
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```

## **Удалить видеокадр**

Удалите видеокадр со слайда.

```csharp
static void RemoveVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Удалить видеокадр.
    slide.Shapes.Remove(videoFrame);
}
```

## **Настроить воспроизведение видео**

Настройте воспроизведение видео автоматически при отображении слайда.

```csharp
static void SetVideoPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Настроить автоматическое воспроизведение видео.
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```