---
title: Audio
type: docs
weight: 70
url: /es/python-net/examples/elements/audio/
keywords:
- audio
- marco de audio
- añadir audio
- acceder al audio
- eliminar audio
- reproducción de audio
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Trabaje con audio en Python usando Aspose.Slides: añada, reemplace, extraiga y recorte sonidos, establezca el volumen y la reproducción para diapositivas y formas en PowerPoint y OpenDocument."
---
Ilustra cómo incrustar marcos de audio y controlar la reproducción con **Aspose.Slides for Python via .NET**. Los siguientes ejemplos muestran operaciones básicas de audio.

## **Añadir un Marco de Audio**

El siguiente ejemplo de código añade un marco de audio en una diapositiva de la presentación.

```py
def add_audio():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        with open("audio.wav", "rb") as audio_stream:
            audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)

        presentation.save("audio.pptx", slides.export.SaveFormat.PPTX)
```

## **Acceder a un Marco de Audio**

Este código recupera el primer marco de audio de la diapositiva.

```py
def access_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        first_audio_frame = None
        for shape in slide.shapes:
            if isinstance(shape, slides.AudioFrame):
                first_audio_frame = shape
                break
```

## **Eliminar un Marco de Audio**

Eliminar un marco de audio añadido previamente.

```py
def remove_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Suponiendo que la primera forma es un AudioFrame.
        audio_frame = slide.shapes[0]

        # Eliminar el marco de audio.
        slide.shapes.remove(audio_frame)

        presentation.save("audio_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Configurar la Reproducción de Audio**

Configura el marco de audio para que se reproduzca automáticamente cuando la diapositiva aparezca.

```py
def set_audio_playback():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Suponiendo que la primera forma es un AudioFrame.
        audio_frame = slide.shapes[0]

        # Reproducción automática cuando la diapositiva aparece.
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO

        presentation.save("audio_playback.pptx", slides.export.SaveFormat.PPTX)
```