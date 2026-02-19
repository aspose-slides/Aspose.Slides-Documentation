---
title: Audio
type: docs
weight: 70
url: /es/net/examples/elements/audio/
keywords:
- audio
- marco de audio
- añadir audio
- acceder al audio
- eliminar audio
- reproducción de audio
- ejemplo de código
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Descubra ejemplos de audio de Aspose.Slides for .NET: inserte, reproduzca, recorte y extraiga sonido en presentaciones PPT, PPTX y ODP con código C# claro."
---
Este artículo demuestra cómo incrustar marcos de audio y controlar la reproducción con **Aspose.Slides for .NET**. Los siguientes ejemplos muestran operaciones básicas de audio.

## **Agregar un marco de audio**

Inserte un marco de audio vacío que luego pueda contener datos de sonido incrustados.

```csharp
static void AddAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Crear un marco de audio vacío (el audio se incrustará más tarde).
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```

## **Acceder a un marco de audio**

Este código recupera el primer marco de audio en una diapositiva.

```csharp
static void AccessAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Acceder al primer marco de audio en la diapositiva.
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```

## **Eliminar un marco de audio**

Elimine un marco de audio añadido previamente.

```csharp
static void RemoveAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Eliminar el marco de audio.
    slide.Shapes.Remove(audioFrame);
}
```

## **Establecer reproducción de audio**

Configure el marco de audio para que se reproduzca automáticamente cuando aparezca la diapositiva.

```csharp
static void SetAudioPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Reproducir automáticamente cuando la diapositiva aparezca.
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```