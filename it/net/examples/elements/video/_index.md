---
title: Video
type: docs
weight: 80
url: /it/net/examples/elements/video/
keywords:
- video
- fotogramma video
- aggiungi video
- accedi al video
- rimuovi video
- riproduzione video
- esempio di codice
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Aggiungi e controlla i video con Aspose.Slides for .NET: inserisci, riproduci, taglia, imposta fotogrammi di anteprima e esporta con esempi C# per presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come incorporare fotogrammi video e impostare le opzioni di riproduzione utilizzando **Aspose.Slides for .NET**.

## **Aggiungi un fotogramma video**

Inserisci un fotogramma video vuoto su una diapositiva.

```csharp
static void AddVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Aggiungi un video.
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```

## **Accedi a un fotogramma video**

Recupera il primo fotogramma video aggiunto a una diapositiva.

```csharp
static void AccessVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Accedi al primo fotogramma video sulla diapositiva.
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```

## **Rimuovi un fotogramma video**

Elimina un fotogramma video dalla diapositiva.

```csharp
static void RemoveVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Rimuovi il fotogramma video.
    slide.Shapes.Remove(videoFrame);
}
```

## **Imposta la riproduzione video**

Configura il video affinché venga riprodotto automaticamente quando la diapositiva viene visualizzata.

```csharp
static void SetVideoPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Configura il video per la riproduzione automatica.
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```