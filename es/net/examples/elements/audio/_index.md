---
title: Audio
type: docs
weight: 70
url: /es/net/examples/elements/audio/
keywords:
- ejemplo de audio
- marco de audio
- agregar audio
- acceder al audio
- eliminar audio
- reproducción de audio
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Trabaje con audio en C# usando Aspose.Slides: agregue, reemplace, extraiga y recorte sonidos, establezca volumen y reproducción para diapositivas y formas en PowerPoint y OpenDocument."
---

Ilustra cómo incrustar marcos de audio y controlar la reproducción con **Aspose.Slides for .NET**. Los siguientes ejemplos muestran operaciones básicas de audio.

## Agregar un marco de audio

Insertar un marco de audio vacío que luego pueda contener datos de sonido incrustados.
```csharp
static void Add_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Crear un marco de audio vacío (el audio se incrustará más tarde)
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```


## Acceder a un marco de audio

Este código recupera el primer marco de audio en una diapositiva.
```csharp
static void Access_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Acceder al primer marco de audio en la diapositiva
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```


## Eliminar un marco de audio

Eliminar un marco de audio añadido previamente.
```csharp
static void Remove_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Eliminar el marco de audio
    slide.Shapes.Remove(audioFrame);
}
```


## Configurar la reproducción de audio

Configurar el marco de audio para que se reproduzca automáticamente cuando la diapositiva aparezca.
```csharp
static void Set_Audio_Playback()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Reproducir automáticamente cuando la diapositiva aparece
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```
