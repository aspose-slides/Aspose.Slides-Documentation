---
title: Vídeo
type: docs
weight: 80
url: /es/net/examples/elements/video/
keywords:
- vídeo
- fotograma de vídeo
- añadir vídeo
- acceder a vídeo
- eliminar vídeo
- reproducción de vídeo
- ejemplo de código
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Añade y controla vídeos con Aspose.Slides for .NET: inserta, reproduce, recorta, establece fotogramas de portada y exporta con ejemplos en C# para presentaciones PPT, PPTX y ODP."
---
Este artículo muestra cómo incrustar fotogramas de vídeo y configurar opciones de reproducción utilizando **Aspose.Slides for .NET**.

## **Agregar un fotograma de vídeo**

Inserte un fotograma de vídeo vacío en una diapositiva.

```csharp
static void AddVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Añade un vídeo.
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```

## **Acceder a un fotograma de vídeo**

Obtenga el primer fotograma de vídeo añadido a una diapositiva.

```csharp
static void AccessVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Accede al primer fotograma de vídeo de la diapositiva.
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```

## **Eliminar un fotograma de vídeo**

Elimine un fotograma de vídeo de la diapositiva.

```csharp
static void RemoveVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Elimina el fotograma de vídeo.
    slide.Shapes.Remove(videoFrame);
}
```

## **Configurar la reproducción de vídeo**

Configure el vídeo para que se reproduzca automáticamente cuando se muestre la diapositiva.

```csharp
static void SetVideoPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Configura el vídeo para que se reproduzca automáticamente.
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```