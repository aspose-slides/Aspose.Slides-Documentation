---
title: Vídeo
type: docs
weight: 80
url: /es/python-java/examples/elements/video/
keywords:
- ejemplo de código
- vídeo
- fotograma de vídeo
- añadir vídeo
- acceder al vídeo
- eliminar vídeo
- reproducción de vídeo
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Utilice Aspose.Slides for Python via Java para añadir, acceder, eliminar y configurar fotogramas de vídeo en presentaciones de PowerPoint y OpenDocument."
---
Este artículo muestra cómo añadir fotogramas de vídeo y establecer opciones de reproducción utilizando **Aspose.Slides for Python via Java**.

Instale el paquete como se describe en [Installation](/slides/es/python-java/installation/). Cada ejemplo importa `asposeslides` antes de iniciar la JVM y luego importa la API una vez que la JVM está en ejecución.

## **Agregar un fotograma de vídeo**

Inserte un fotograma de vídeo que haga referencia a un archivo de vídeo externo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Añadir un fotograma de vídeo enlazado a un archivo de vídeo.
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")
finally:
    presentation.dispose()
```

## **Acceder a un fotograma de vídeo**

Recupere el primer fotograma de vídeo añadido a una diapositiva.

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

    # Acceder al primer fotograma de vídeo de la diapositiva.
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

## **Eliminar un fotograma de vídeo**

Elimine un fotograma de vídeo de la diapositiva.

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

    # Eliminar el fotograma de vídeo.
    slide.getShapes().remove(video_frame)
finally:
    presentation.dispose()
```

## **Establecer la reproducción del vídeo**

Configure el vídeo para que se reproduzca automáticamente cuando se muestre la diapositiva.

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

    # Configurar el vídeo para que se reproduzca automáticamente.
    video_frame.setPlayMode(VideoPlayModePreset.Auto)
finally:
    presentation.dispose()
```