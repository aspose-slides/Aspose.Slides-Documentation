---
title: Wideo
type: docs
weight: 80
url: /pl/net/examples/elements/video/
keywords:
- wideo
- ramka wideo
- dodaj wideo
- dostęp do wideo
- usuń wideo
- odtwarzanie wideo
- przykład kodu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dodawaj i kontroluj wideo za pomocą Aspose.Slides dla .NET: wstawiaj, odtwarzaj, przycinaj, ustawiaj klatki okładkowe i eksportuj z przykładami w C# dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł pokazuje, jak osadzić ramki wideo i ustawić opcje odtwarzania przy użyciu **Aspose.Slides for .NET**.

## **Dodaj ramkę wideo**

Wstaw pustą ramkę wideo na slajd.

```csharp
static void AddVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Dodaj wideo.
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```

## **Uzyskaj dostęp do ramki wideo**

Pobierz pierwszą ramkę wideo dodaną do slajdu.

```csharp
static void AccessVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Uzyskaj dostęp do pierwszej ramki wideo na slajdzie.
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```

## **Usuń ramkę wideo**

Usuń ramkę wideo ze slajdu.

```csharp
static void RemoveVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Usuń ramkę wideo.
    slide.Shapes.Remove(videoFrame);
}
```

## **Ustaw odtwarzanie wideo**

Skonfiguruj wideo tak, aby odtwarzało się automatycznie, gdy slajd jest wyświetlany.

```csharp
static void SetVideoPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Skonfiguruj wideo, aby odtwarzało się automatycznie.
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```