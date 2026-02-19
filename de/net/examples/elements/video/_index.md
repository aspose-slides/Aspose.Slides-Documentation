---
title: Video
type: docs
weight: 80
url: /de/net/examples/elements/video/
keywords:
- Video
- Video-Frame
- Video hinzufügen
- Video abrufen
- Video entfernen
- Video-Wiedergabe
- Codebeispiel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Videos mit Aspose.Slides für .NET hinzufügen und steuern: Einfügen, Abspielen, Zuschneiden, Poster-Frames festlegen und Exportieren mit C#‑Beispielen für PPT-, PPTX‑ und ODP‑Präsentationen."
---
Dieser Artikel zeigt, wie man Video-Frames einbettet und Wiedergabeoptionen mit **Aspose.Slides for .NET** festlegt.

## **Video-Frame hinzufügen**

Ein leeres Video-Frame auf einer Folie einfügen.

```csharp
static void AddVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Ein Video hinzufügen.
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```

## **Auf einen Video-Frame zugreifen**

Den ersten zu einer Folie hinzugefügten Video-Frame abrufen.

```csharp
static void AccessVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Zugriff auf den ersten Video-Frame auf der Folie.
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```

## **Video-Frame entfernen**

Einen Video-Frame von der Folie löschen.

```csharp
static void RemoveVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Video-Frame entfernen.
    slide.Shapes.Remove(videoFrame);
}
```

## **Video‑Wiedergabe einstellen**

Konfigurieren Sie das Video so, dass es automatisch abgespielt wird, wenn die Folie angezeigt wird.

```csharp
static void SetVideoPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Video so konfigurieren, dass es automatisch abgespielt wird.
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```