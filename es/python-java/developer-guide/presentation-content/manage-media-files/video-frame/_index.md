---
title: Gestionar fotogramas de vídeo en presentaciones usando Python
linktitle: Fotograma de vídeo
type: docs
weight: 10
url: /es/python-java/video-frame/
keywords:
- añadir vídeo
- crear vídeo
- incrustar vídeo
- extraer vídeo
- recuperar vídeo
- fotograma de vídeo
- fuente web
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprende a añadir y extraer fotogramas de vídeo en diapositivas de PowerPoint y OpenDocument de forma programática usando Aspose.Slides para Python vía Java. Guía rápida paso a paso."
---
## **Introducción**

Un vídeo bien colocado en una presentación puede hacer que tu mensaje sea más atractivo y aumentar los niveles de participación de tu audiencia.

PowerPoint permite añadir vídeos a una diapositiva en una presentación de dos maneras:

* Añadir o incrustar un vídeo local (almacenado en tu equipo)
* Añadir un vídeo en línea (desde una fuente web como YouTube).

Para permitirte añadir vídeos (objetos de vídeo) a una presentación, Aspose.Slides proporciona la clase [Video](https://reference.aspose.com/slides/es/python-java/aspose.slides/video/) , la clase [VideoFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/videoframe/) y otros tipos relevantes.

## **Crear fotogramas de vídeo incrustados**

Si el archivo de vídeo que deseas añadir a tu diapositiva está almacenado localmente, puedes crear un fotograma de vídeo para incrustar el vídeo en tu presentación.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) .
1. Obtén la referencia de una diapositiva mediante su índice.
1. Añade un objeto [Video](https://reference.aspose.com/slides/es/python-java/aspose.slides/video/) y pasa los datos del archivo de vídeo para incrustar el vídeo en la presentación.
1. Añade un objeto [VideoFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/videoframe/) para crear un fotograma para el vídeo.
1. Guarda la presentación modificada.

Este código Python muestra cómo añadir un vídeo almacenado localmente a una presentación:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    video_data = Path("Wildlife.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video)
    presentation.save("pres-with-video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Alternativamente, puedes añadir un vídeo pasando directamente su ruta de archivo al método [addVideoFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addVideoFrame) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi")
finally:
    presentation.dispose()
```

## **Crear fotogramas de vídeo con vídeo de fuentes web**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) admite vídeos de YouTube en presentaciones. Si el vídeo que deseas usar está disponible en línea (p. ej., en YouTube), puedes añadirlo a tu presentación mediante su enlace web.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) .
1. Obtén la referencia de una diapositiva mediante su índice.
1. Añade un objeto [VideoFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/videoframe/) y pasa el enlace al vídeo.
1. Establece una miniatura para el fotograma de vídeo.
1. Guarda la presentación.

Este código Python muestra cómo añadir un vídeo desde la web a una diapositiva en una presentación de PowerPoint:

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

video_id = "Tj75Arhq5ho"
presentation = Presentation()
try:
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + video_id)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    # Cargar la miniatura.
    thumbnail_uri = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    try:
        with urlopen(thumbnail_uri) as response:
            thumbnail_data = response.read()
        java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
        thumbnail = presentation.getImages().addImage(java_thumbnail_data)
        video_frame.getPictureFormat().getPicture().setImage(thumbnail)
    except OSError as error:
        print("Could not load the thumbnail:", error)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Recortar un fotograma de vídeo**

Aspose.Slides te permite controlar qué parte de un vídeo se reproduce configurando los valores trim-from-start y trim-from-end mediante [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/es/python-java/aspose.slides/videoframe/#setTrimFromStart) y [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/es/python-java/aspose.slides/videoframe/#setTrimFromEnd) . Ambos valores se especifican en milisegundos y definen cuánto tiempo se omite al principio y al final del vídeo, respectivamente. Estos ajustes modifican la configuración de reproducción del vídeo en la presentación; no recortan ni modifican de otro modo los datos binarios del vídeo incrustado.

**Establecer ajustes de recorte**

Para crear un fotograma de vídeo y establecer sus ajustes de recorte:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) .
1. Añade un objeto [Video](https://reference.aspose.com/slides/es/python-java/aspose.slides/video/) a la presentación.
1. Añade un objeto [VideoFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/videoframe/) a una diapositiva.
1. Establece los valores trim-from-start y trim-from-end mediante [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/es/python-java/aspose.slides/videoframe/#setTrimFromStart) y [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/es/python-java/aspose.slides/videoframe/#setTrimFromEnd) .
1. Guarda la presentación modificada.

El siguiente ejemplo de código omite los primeros 2,5 segundos y el último segundo de un vídeo incrustado durante la reproducción:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)
    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Leer ajustes de recorte**

Para inspeccionar los ajustes de recorte existentes, carga una presentación, encuentra un objeto [VideoFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/videoframe/) entre las formas de la primera diapositiva y lee los valores mediante [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/es/python-java/aspose.slides/videoframe/#getTrimFromStart) y [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/es/python-java/aspose.slides/videoframe/#getTrimFromEnd) .

El siguiente ejemplo de código encuentra el primer fotograma de vídeo en la primera diapositiva y muestra sus ajustes de recorte en milisegundos:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_trim.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            trim_from_start = shape.getTrimFromStart()
            trim_from_end = shape.getTrimFromEnd()
            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
finally:
    presentation.dispose()
```

## **Gestionar subtítulos de vídeo**

Aspose.Slides te permite gestionar subtítulos cerrados para los fotogramas de vídeo en presentaciones de PowerPoint. Los subtítulos se almacenan en formato WebVTT y se exponen mediante el método [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/es/python-java/aspose.slides/videoframe/#getCaptionTracks) .

**Añadir subtítulos a un fotograma de vídeo**

Para añadir subtítulos a un fotograma de vídeo:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) .
1. Añade un vídeo a la presentación.
1. Añade un objeto [VideoFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/videoframe/) a una diapositiva.
1. Utiliza la [CaptionsCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/captionscollection/) devuelta por [getCaptionTracks](https://reference.aspose.com/slides/es/python-java/aspose.slides/videoframe/#getCaptionTracks) para añadir una pista de subtítulos WebVTT.
1. Guarda la presentación modificada.

El siguiente código muestra cómo añadir subtítulos a un fotograma de vídeo:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # Añadir una nueva pista de subtítulos desde un archivo WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La clase [CaptionsCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/captionscollection/) también proporciona una sobrecarga que permite añadir subtítulos desde un flujo.

**Extraer subtítulos de un fotograma de vídeo**

Para extraer subtítulos de un fotograma de vídeo:

1. Carga la presentación que contiene el vídeo.
1. Encuentra el objeto [VideoFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/videoframe/) objetivo.
1. Itera a través de las pistas de subtítulos en la [CaptionsCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/captionscollection/) .
1. Guarda cada pista de subtítulos en un archivo `.vtt` .

El siguiente código muestra cómo extraer subtítulos de un fotograma de vídeo:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                # Guardar la pista de subtítulos en un archivo WebVTT.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

Cada objeto [Captions](https://reference.aspose.com/slides/es/python-java/aspose.slides/captions/) expone el identificador del subtítulo, la etiqueta, los datos binarios y el texto del subtítulo como una cadena UTF-8.

**Eliminar subtítulos de un fotograma de vídeo**

Para eliminar subtítulos de un fotograma de vídeo:

1. Carga la presentación que contiene el vídeo.
1. Obtén el objeto [VideoFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/videoframe/) objetivo.
1. Elimina las pistas de subtítulos de la [CaptionsCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/captionscollection/) .
1. Guarda la presentación modificada.

El siguiente código muestra cómo eliminar todos los subtítulos de un fotograma de vídeo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().get_Item(0)
    if isinstance(video_frame, VideoFrame):
        # Eliminar todos los subtítulos del fotograma de vídeo.
        video_frame.getCaptionTracks().clear()
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Si necesitas eliminar sólo una pista de subtítulos, usa los métodos [remove](https://reference.aspose.com/slides/es/python-java/aspose.slides/captionscollection/#remove) o [removeAt](https://reference.aspose.com/slides/es/python-java/aspose.slides/captionscollection/#removeAt) en lugar de [clear](https://reference.aspose.com/slides/es/python-java/aspose.slides/captionscollection/#clear) .

## **Extraer vídeo de diapositivas**

Además de añadir vídeos a las diapositivas, Aspose.Slides permite extraer los vídeos incrustados en presentaciones.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) para cargar la presentación que contiene el vídeo.
2. Recorre todos los objetos [Slide](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/) .
3. Recorre todos los objetos [Shape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/) para encontrar un [VideoFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/videoframe/) .
4. Guarda el vídeo en el disco.

Este código Python muestra cómo extraer el vídeo de una diapositiva de una presentación:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("VideoSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is not None:
                    content_type = str(video.getContentType())
                    file_extension = content_type.split("/", 1)[-1]
                    video_data = bytes(video.getBinaryData())
                    Path("testing2." + file_extension).write_bytes(video_data)
                else:
                    print("The video frame has no embedded video.")
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Qué parámetros de reproducción de vídeo se pueden cambiar en un VideoFrame?**

Puedes controlar el [modo de reproducción](https://reference.aspose.com/slides/es/python-java/aspose.slides/videoframe/#setPlayMode) (automático o al hacer clic) y la [repetición](https://reference.aspose.com/slides/es/python-java/aspose.slides/videoframe/#setPlayLoopMode) . Estas opciones están disponibles a través de las propiedades del objeto [VideoFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/videoframe/) .

**¿Añadir un vídeo afecta al tamaño del archivo PPTX?**

Sí. Cuando incrustas un vídeo local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece en proporción al tamaño del archivo. Cuando añades un vídeo en línea, se incrustan un enlace y una miniatura, por lo que el aumento de tamaño es menor.

**¿Puedo reemplazar el vídeo en un VideoFrame existente sin cambiar su posición y tamaño?**

Sí. Puedes intercambiar el [contenido del vídeo](https://reference.aspose.com/slides/es/python-java/aspose.slides/videoframe/#setEmbeddedVideo) dentro del fotograma preservando la geometría de la forma; este es un caso frecuente para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un vídeo incrustado?**

Sí. Un vídeo incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/es/python-java/aspose.slides/video/#getContentType) que puedes leer y usar, por ejemplo al guardarlo en el disco.