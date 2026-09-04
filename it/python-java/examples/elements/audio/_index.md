---
title: Audio
type: docs
weight: 70
url: /it/python-java/examples/elements/audio/
keywords:
- esempio di codice
- audio
- frame audio
- aggiungi audio
- accedi audio
- rimuovi audio
- riproduzione audio
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Utilizza Aspose.Slides per Python via Java per aggiungere, accedere, rimuovere e configurare i frame audio nelle presentazioni PowerPoint e OpenDocument."
---
Questo articolo mostra come incorporare frame audio e controllare la riproduzione utilizzando **Aspose.Slides for Python via Java**. Gli esempi seguenti mostrano operazioni audio di base.

Installa il pacchetto come descritto in [Installation](/slides/it/python-java/installation/). Ogni esempio importa `asposeslides` prima di avviare la JVM, quindi importa l'API dopo che la JVM è in esecuzione.

## **Aggiungi un frame audio**

Inserisci un frame audio vuoto che potrà contenere successivamente dati audio incorporati.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)

    # Crea un frame audio vuoto (l'audio verrà incorporato in seguito).
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)
finally:
    presentation.dispose()
```

## **Accedi a un frame audio**

Questo codice recupera il primo frame audio su una diapositiva.

```python
import jpype
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioFrame, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpime.JArray(jpime.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # Accedi al primo frame audio sulla diapositiva.
    first_audio = None
    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            first_audio = shape
            break

    if first_audio is None:
        print("The slide contains no audio frames.")
finally:
    presentation.dispose()
```

## **Rimuovi un frame audio**

Elimina un frame audio precedentemente aggiunto.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # Rimuovi il frame audio.
    slide.getShapes().remove(audio_frame)
finally:
    presentation.dispose()
```

## **Imposta la riproduzione audio**

Configura il frame audio in modo che venga riprodotto automaticamente quando la diapositiva appare.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioPlayModePreset, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # Riproduci automaticamente quando la diapositiva appare.
    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
finally:
    presentation.dispose()
```