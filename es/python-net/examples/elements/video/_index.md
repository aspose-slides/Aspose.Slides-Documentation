---
title: Vídeo
type: docs
weight: 80
url: /es/python-net/examples/elements/video/
keywords:
- vídeo
- fotograma de vídeo
- agregar vídeo
- acceder a vídeo
- eliminar vídeo
- reproducción de vídeo
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Trabaje con vídeo en Python usando Aspose.Slides: inserte, reemplace, recorte, establezca fotogramas de portada y opciones de reproducción, y exporte presentaciones a PPT, PPTX y ODP."
---
Muestra cómo incrustar fotogramas de vídeo y establecer opciones de reproducción usando **Aspose.Slides for Python via .NET**.

## **Agregar un fotograma de vídeo**

Inserte un fotograma de vídeo vacío en una diapositiva.

```py
def add_video():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Añadir un fotograma de vídeo.
        video_frame = slide.shapes.add_video_frame(50, 50, 320, 240, "video.mp4")

        presentation.save("video.pptx", slides.export.SaveFormat.PPTX)
```

## **Acceder a un fotograma de vídeo**

Recupere el primer fotograma de vídeo añadido a una diapositiva.

```py
def access_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Acceder al primer fotograma de vídeo en la diapositiva.
        first_video = next(shape for shape in slide.shapes if isinstance(shape, slides.VideoFrame))
```

## **Eliminar un fotograma de vídeo**

Elimine un fotograma de vídeo de la diapositiva.

```py
def remove_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Suponiendo que la primera forma es un fotograma de vídeo.
        video_frame = slide.shapes[0]

        # Eliminar el fotograma de vídeo.
        slide.shapes.remove(video_frame)

        presentation.save("video_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer la reproducción del vídeo**

Configure el vídeo para que se reproduzca automáticamente cuando se muestre la diapositiva.

```py
def set_video_playback():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Suponiendo que la primera forma es un fotograma de vídeo.
        video_frame = slide.shapes[0]

        # Configurar el vídeo para que se reproduzca automáticamente.
        video_frame.play_mode = slides.VideoPlayModePreset.AUTO

        presentation.save("video_playback.pptx", slides.export.SaveFormat.PPTX)
```