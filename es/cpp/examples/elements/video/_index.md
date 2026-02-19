---
title: Video
type: docs
weight: 80
url: /es/cpp/examples/elements/video/
keywords:
- ejemplo de código
- vídeo
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Añade y controla vídeos con Aspose.Slides for C++: inserta, reproduce, recorta, establece marcos de póster y exporta con ejemplos en C++ para presentaciones PPT, PPTX y ODP."
---
Este artículo demuestra cómo incrustar marcos de vídeo y establecer opciones de reproducción usando **Aspose.Slides for C++**.

## **Agregar un marco de vídeo**

Inserte un marco de vídeo vacío en una diapositiva.

```cpp
static void AddVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Añadir un vídeo.
    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    presentation->Dispose();
}
```

## **Acceder a un marco de vídeo**

Recupere el primer marco de vídeo añadido a una diapositiva.

```cpp
static void AccessVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Acceder al primer marco de vídeo en la diapositiva.
    auto firstVideo = SharedPtr<IVideoFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IVideoFrame>(shape))
        {
            firstVideo = ExplicitCast<IVideoFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Eliminar un marco de vídeo**

Elimine un marco de vídeo de la diapositiva.

```cpp
static void RemoveVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Eliminar el marco de vídeo.
    slide->get_Shapes()->Remove(videoFrame);

    presentation->Dispose();
}
```

## **Establecer la reproducción del vídeo**

Configure el vídeo para que se reproduzca automáticamente cuando se muestre la diapositiva.

```cpp
static void SetVideoPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Configurar el vídeo para que se reproduzca automáticamente.
    videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

    presentation->Dispose();
}
```