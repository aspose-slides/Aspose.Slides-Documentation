---
title: Audio
type: docs
weight: 70
url: /es/python-java/examples/elements/audio/
keywords:
- ejemplo de código
- audio
- marco de audio
- añadir audio
- acceder al audio
- eliminar audio
- reproducción de audio
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Utilice Aspose.Slides para Python mediante Java para añadir, acceder, eliminar y configurar marcos de audio en presentaciones de PowerPoint y OpenDocument."
---
Este artículo muestra cómo incrustar marcos de audio y controlar la reproducción usando **Aspose.Slides for Python via Java**. Los siguientes ejemplos ilustran operaciones básicas de audio.

Instale el paquete como se describe en [Installation](/slides/es/python-java/installation/). Cada ejemplo importa `asposeslides` antes de iniciar la JVM y, a continuación, importa la API una vez que la JVM está en ejecución.

## **Agregar un Marco de Audio**

Inserte un marco de audio vacío que posteriormente puede contener datos de sonido incrustados.

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

    # Crear un marco de audio vacío (el audio se incrustará más tarde).
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)
finally:
    presentation.dispose()
```

## **Acceder a un Marco de Audio**

Este código recupera el primer marco de audio de una diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioFrame, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # Acceder al primer marco de audio de la diapositiva.
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

## **Eliminar un Marco de Audio**

Elimine un marco de audio añadido previamente.

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

    # Eliminar el marco de audio.
    slide.getShapes().remove(audio_frame)
finally:
    presentation.dispose()
```

## **Establecer la Reproducción de Audio**

Configure el marco de audio para que se reproduzca automáticamente cuando la diapositiva aparezca.

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

    # Reproducir automáticamente cuando la diapositiva aparece.
    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
finally:
    presentation.dispose()
```