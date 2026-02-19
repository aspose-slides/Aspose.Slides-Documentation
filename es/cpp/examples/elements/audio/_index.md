---
title: Audio
type: docs
weight: 70
url: /es/cpp/examples/elements/audio/
keywords:
- ejemplo de código
- audio
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Descubra ejemplos de audio de Aspose.Slides para C++: inserte, reproduzca, recorte y extraiga sonido en presentaciones PPT, PPTX y ODP con código C++ claro."
---
Este artículo muestra cómo incrustar marcos de audio y controlar la reproducción con **Aspose.Slides for C++**. Los ejemplos siguientes muestran operaciones básicas de audio.

## **Añadir un marco de audio**

Inserte un marco de audio vacío que luego pueda contener datos de sonido incrustados.

```cpp
static void AddAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Crear un marco de audio vacío (el audio se incrustará más tarde).
    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    presentation->Dispose();
}
```

## **Acceder a un marco de audio**

Este código recupera el primer marco de audio en una diapositiva.

```cpp
static void AccessAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Acceder al primer marco de audio en la diapositiva.
    auto firstAudio = SharedPtr<IAudioFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAudioFrame>(shape))
        {
            firstAudio = ExplicitCast<IAudioFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Eliminar un marco de audio**

Elimine un marco de audio añadido previamente.

```cpp
static void RemoveAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Eliminar el marco de audio.
    slide->get_Shapes()->Remove(audioFrame);

    presentation->Dispose();
}
```

## **Establecer la reproducción de audio**

Configure el marco de audio para que se reproduzca automáticamente cuando la diapositiva aparezca.

```cpp
static void SetAudioPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Reproducir automáticamente cuando la diapositiva aparezca.
    audioFrame->set_PlayMode(AudioPlayModePreset::Auto);

    presentation->Dispose();
}
```