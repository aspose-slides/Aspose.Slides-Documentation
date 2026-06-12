---
title: Audio
type: docs
weight: 70
url: /it/python-net/examples/elements/audio/
keywords:
- audio
- fotogramma audio
- aggiungi audio
- accedi audio
- rimuovi audio
- riproduzione audio
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Lavora con l'audio in Python usando Aspose.Slides: aggiungi, sostituisci, estrai e ritaglia suoni, imposta volume e riproduzione per diapositive e forme in PowerPoint e OpenDocument."
---
Illustra come incorporare fotogrammi audio e controllare la riproduzione con **Aspose.Slides for Python via .NET**. Gli esempi seguenti mostrano le operazioni audio di base.

## **Aggiungi un fotogramma audio**

L'esempio di codice seguente aggiunge un fotogramma audio a una diapositiva della presentazione.

```py
def add_audio():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        with open("audio.wav", "rb") as audio_stream:
            audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)

        presentation.save("audio.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedi a un fotogramma audio**

Questo codice recupera il primo fotogramma audio dalla diapositiva.

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

## **Rimuovi un fotogramma audio**

Elimina un fotogramma audio precedentemente aggiunto.

```py
def remove_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Supponendo che la prima forma sia un AudioFrame.
        audio_frame = slide.shapes[0]

        # Rimuovi il fotogramma audio.
        slide.shapes.remove(audio_frame)

        presentation.save("audio_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta la riproduzione audio**

Configura il fotogramma audio per riprodursi automaticamente quando la diapositiva appare.

```py
def set_audio_playback():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Supponendo che la prima forma sia un AudioFrame.
        audio_frame = slide.shapes[0]

        # Riproduci automaticamente quando la diapositiva appare.
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO

        presentation.save("audio_playback.pptx", slides.export.SaveFormat.PPTX)
```