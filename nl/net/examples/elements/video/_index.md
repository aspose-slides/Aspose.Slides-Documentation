---
title: Video
type: docs
weight: 80
url: /nl/net/examples/elements/video/
keywords:
- video
- videokader
- video toevoegen
- video benaderen
- video verwijderen
- videoweergave
- codevoorbeeld
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Video's toevoegen en beheren met Aspose.Slides voor .NET: invoegen, afspelen, inkorten, posterframes instellen en exporteren met C#-voorbeelden voor PPT-, PPTX- en ODP-presentaties."
---
Dit artikel toont hoe u videokaders kunt insluiten en afspeelopties kunt instellen met **Aspose.Slides for .NET**.

## **Videokader toevoegen**

Voeg een leeg videokader toe aan een dia.

```csharp
static void AddVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Voeg een video toe.
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```

## **Toegang tot een videokader**

Haal het eerste aan een dia toegevoegde videokader op.

```csharp
static void AccessVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Toegang tot het eerste videokader op de dia.
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```

## **Videokader verwijderen**

Verwijder een videokader van de dia.

```csharp
static void RemoveVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Verwijder het videokader.
    slide.Shapes.Remove(videoFrame);
}
```

## **Videoweergave instellen**

Stel in dat de video automatisch wordt afgespeeld wanneer de dia wordt getoond.

```csharp
static void SetVideoPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Stel in dat de video automatisch wordt afgespeeld.
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```