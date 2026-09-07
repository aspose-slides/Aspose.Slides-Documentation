---
title: Video
type: docs
weight: 80
url: /it/python-java/examples/elements/video/
keywords:
- esempio di codice
- video
- frame video
- aggiungi video
- accedi al video
- rimuovi video
- riproduzione video
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Utilizza Aspose.Slides per Python tramite Java per aggiungere, accedere, rimuovere e configurare i frame video in presentazioni PowerPoint e OpenDocument."
---
Questo articolo dimostra come aggiungere frame video e impostare le opzioni di riproduzione utilizzando **Aspose.Slides for Python via Java**.

Installa il pacchetto come descritto in [Installation](/slides/it/python-java/installation/). Ogni esempio importa `asposeslides` prima di avviare la JVM, quindi importa l'API dopo che la JVM è in esecuzione.

## **Aggiungere un frame video**

Inserisci un frame video che fa riferimento a un file video esterno.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi un frame video collegato a un file video.
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")
finally:
    presentation.dispose()
```

## **Accedere a un frame video**

Recupera il primo frame video aggiunto a una diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # Accedi al primo frame video sulla diapositiva.
    first_video = None
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            first_video = shape
            break

    if first_video is None:
        print("The slide contains no video frames.")
finally:
    presentation.dispose()
```

## **Rimuovere un frame video**

Elimina un frame video dalla diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # Rimuovi il frame video.
    slide.getShapes().remove(video_frame)
finally:
    presentation.dispose()
```

## **Impostare la riproduzione video**

Configura il video in modo che venga riprodotto automaticamente quando la diapositiva viene visualizzata.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # Configura il video per la riproduzione automatica.
    video_frame.setPlayMode(VideoPlayModePreset.Auto)
finally:
    presentation.dispose()
```