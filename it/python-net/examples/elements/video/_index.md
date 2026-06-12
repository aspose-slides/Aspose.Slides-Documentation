---
title: Video
type: docs
weight: 80
url: /it/python-net/examples/elements/video/
keywords:
  - video
  - fotogramma video
  - aggiungi video
  - accedi al video
  - rimuovi video
  - riproduzione video
  - esempi di codice
  - PowerPoint
  - OpenDocument
  - presentazione
  - Python
  - Aspose.Slides
description: "Lavora con i video in Python usando Aspose.Slides: inserisci, sostituisci, ritaglia, imposta fotogrammi poster e opzioni di riproduzione, ed esporta le presentazioni in PPT, PPTX e ODP."
---
Mostra come incorporare fotogrammi video e impostare le opzioni di riproduzione utilizzando **Aspose.Slides for Python via .NET**.

## **Aggiungi un fotogramma video**

Inserisci un fotogramma video vuoto nella diapositiva.

```py
def add_video():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Aggiungi un fotogramma video.
        video_frame = slide.shapes.add_video_frame(50, 50, 320, 240, "video.mp4")

        presentation.save("video.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedi a un fotogramma video**

Recupera il primo fotogramma video aggiunto a una diapositiva.

```py
def access_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Accedi al primo fotogramma video sulla diapositiva.
        first_video = next(shape for shape in slide.shapes if isinstance(shape, slides.VideoFrame))
```

## **Rimuovi un fotogramma video**

Elimina un fotogramma video dalla diapositiva.

```py
def remove_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Supponendo che la prima forma sia un fotogramma video.
        video_frame = slide.shapes[0]

        # Rimuovi il fotogramma video.
        slide.shapes.remove(video_frame)

        presentation.save("video_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta la riproduzione video**

Configura il video in modo che venga riprodotto automaticamente quando la diapositiva viene visualizzata.

```py
def set_video_playback():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Supponendo che la prima forma sia un fotogramma video.
        video_frame = slide.shapes[0]

        # Configura il video per la riproduzione automatica.
        video_frame.play_mode = slides.VideoPlayModePreset.AUTO

        presentation.save("video_playback.pptx", slides.export.SaveFormat.PPTX)
```