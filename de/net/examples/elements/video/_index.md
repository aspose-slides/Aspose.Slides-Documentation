---
title: Video
type: docs
weight: 80
url: /de/net/examples/elements/video/
keywords:
- Video-Beispiel
- Video-Frame
- Video hinzufügen
- Video abrufen
- Video entfernen
- Video-Wiedergabe
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Arbeiten Sie mit Video in C# mittels Aspose.Slides: Einfügen, Ersetzen, Trimmen, Festlegen von Poster-Frames und Wiedergabeoptionen sowie Exportieren von Präsentationen für PPT, PPTX und ODP."
---

Zeigt, wie Video‑Frames eingebettet und Wiedergabeoptionen mit **Aspose.Slides for .NET** festgelegt werden.

## Video‑Frame hinzufügen

Fügen Sie einen leeren Video‑Frame zu einer Folie hinzu.
```csharp
static void Add_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Füge einen leeren eingebetteten Video-Frame hinzu
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```


## Auf einen Video‑Frame zugreifen

Rufen Sie den ersten zu einer Folie hinzugefügten Video‑Frame ab.
```csharp
static void Access_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Greift auf den ersten Video-Frame auf der Folie zu
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```


## Video‑Frame entfernen

Löschen Sie einen Video‑Frame von der Folie.
```csharp
static void Remove_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Entfernt den Video-Frame
    slide.Shapes.Remove(videoFrame);
}
```


## Video‑Wiedergabe festlegen

Konfigurieren Sie das Video so, dass es automatisch abgespielt wird, wenn die Folie angezeigt wird.
```csharp
static void Set_Video_Playback()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Konfiguriere das Video für automatische Wiedergabe
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```
