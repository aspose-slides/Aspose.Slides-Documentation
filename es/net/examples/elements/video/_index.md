---
title: Video
type: docs
weight: 80
url: /es/net/examples/elements/video/
keywords:
- ejemplo de video
- fotograma de video
- agregar video
- acceder al video
- eliminar video
- reproducción de video
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Trabaje con video en C# usando Aspose.Slides: inserte, reemplace, recorte, establezca fotogramas de portada y opciones de reproducción, y exporte presentaciones a PPT, PPTX y ODP."
---

Muestra cómo incrustar fotogramas de video y establecer opciones de reproducción usando **Aspose.Slides for .NET**.

## **Agregar un fotograma de video**
Inserte un fotograma de video vacío en una diapositiva.
```csharp
static void Add_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Agregar un marco de video incrustado vacío
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```


## **Acceder a un fotograma de video**
Recupere el primer fotograma de video añadido a una diapositiva.
```csharp
static void Access_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Acceder al primer fotograma de video en la diapositiva
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```


## **Eliminar un fotograma de video**
Elimine un fotograma de video de la diapositiva.
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


## **Establecer reproducción de video**
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
