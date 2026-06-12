---
title: Audio
type: docs
weight: 70
url: /it/net/examples/elements/audio/
keywords:
- audio
- fotogramma audio
- aggiungi audio
- accedi audio
- rimuovi audio
- riproduzione audio
- esempio di codice
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri gli esempi audio di Aspose.Slides per .NET: inserisci, riproduci, ritaglia ed estrai suoni in presentazioni PPT, PPTX e ODP con codice C# chiaro."
---
Questo articolo dimostra come incorporare fotogrammi audio e controllare la riproduzione con **Aspose.Slides for .NET**. I seguenti esempi mostrano le operazioni audio di base.

## **Aggiungi un fotogramma audio**

Inserisci un fotogramma audio vuoto che può contenere in seguito dati audio incorporati.

```csharp
static void AddAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Crea un fotogramma audio vuoto (l'audio sarà incorporato più tardi).
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```

## **Accedi a un fotogramma audio**

Questo codice recupera il primo fotogramma audio su una diapositiva.

```csharp
static void AccessAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Accedi al primo fotogramma audio sulla diapositiva.
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```

## **Rimuovi un fotogramma audio**

Elimina un fotogramma audio precedentemente aggiunto.

```csharp
static void RemoveAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Rimuovi il fotogramma audio.
    slide.Shapes.Remove(audioFrame);
}
```

## **Imposta la riproduzione audio**

Configura il fotogramma audio per avviarsi automaticamente quando la diapositiva appare.

```csharp
static void SetAudioPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Riproduci automaticamente quando la diapositiva appare.
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```