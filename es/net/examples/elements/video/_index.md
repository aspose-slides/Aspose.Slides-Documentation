---
title: Vídeo
type: docs
weight: 80
url: /es/net/examples/elements/video/
keywords:
- ejemplo de video
- marco de video
- añadir video
- acceder al video
- eliminar video
- reproducción de video
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Trabaje con video en C# usando Aspose.Slides: inserte, reemplace, recorte, establezca marcos de póster y opciones de reproducción, y exporte presentaciones a PPT, PPTX y ODP."
---

Muestra cómo incrustar marcos de video y establecer opciones de reproducción utilizando **Aspose.Slides for .NET**.

## Añadir un marco de video

Inserte un marco de video vacío en una diapositiva.
```csharp
static void Add_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Añadir un marco de video incrustado vacío
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```


## Acceder a un marco de video

Obtenga el primer marco de video añadido a una diapositiva.
```csharp
static void Access_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Acceder al primer marco de video en la diapositiva
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```


## Eliminar un marco de video

Elimine un marco de video de la diapositiva.
```csharp
static void Remove_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Eliminar el marco de video
    slide.Shapes.Remove(videoFrame);
}
```


## Establecer la reproducción de video

Configure el video para que se reproduzca automáticamente cuando se muestre la diapositiva.
```csharp
static void Set_Video_Playback()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Configurar el video para que se reproduzca automáticamente
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```
