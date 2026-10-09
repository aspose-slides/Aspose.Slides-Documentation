---
title: Gestionar marcos de video en presentaciones usando Python
linktitle: Marco de video
type: docs
weight: 10
url: /es/python-java/video-frame/
keywords:
- añadir video
- crear video
- incrustar video
- extraer video
- recuperar video
- marco de video
- origen web
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda a añadir y extraer marcos de video de forma programática en diapositivas PowerPoint y OpenDocument usando Aspose.Slides para Python mediante Java. Guía rápida paso a paso."
---
## **Introducción**

Los videos pueden ayudar a explicar ideas y captar la atención de una audiencia. Aspose.Slides for Python via Java le permite añadir marcos de video a las diapositivas, ajustar la configuración de reproducción, gestionar subtítulos y extraer datos de video incrustados.

PowerPoint admite videos locales y enlaces a videos en línea, como los videos de YouTube.

Para representar datos de video y marcos de video, Aspose.Slides proporciona la clase [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) la clase [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) y otros tipos relevantes.

## **Crear un Marco de Video Incrustado**

Si el archivo de video que desea añadir a su diapositiva está almacenado localmente, puede crear un marco de video para incrustar el video en su presentación.

Este ejemplo incrusta un video local en la primera diapositiva de una presentación existente y guarda el resultado. Las coordenadas y dimensiones del marco están en puntos. Python lee los bytes del video desde el disco, y JPype los convierte a una matriz de bytes Java antes de que el video se añada a la presentación.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video)

    presentation.save("embedded_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

También puede pasar la ruta de un video local directamente a [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame). Este ejemplo incrusta el video en la primera diapositiva de una nueva presentación. El video debe permanecer accesible hasta que se guarde la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Crear un Marco de Video con Video de una Fuente Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) admite videos en línea en las presentaciones. Puede crear un marco de video que enlace a un video en línea, como un video de YouTube.

Este ejemplo añade un enlace de video de YouTube y una miniatura a la primera diapositiva. Reemplace el identificador del video para usar otro video. El método [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) solicita la reproducción automática. Descargar la miniatura y reproducir el video requieren acceso a internet. El visor de presentaciones también debe admitir la reproducción de video en línea.

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_id = "aqz-KE-bpKQ"
    video_url = "https://www.youtube.com/embed/" + video_id
    video_frame = slide.getShapes().addVideoFrame(10, 10, 427, 240, video_url)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    thumbnail_url = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
    thumbnail = presentation.getImages().addImage(java_thumbnail_data)
    video_frame.getPictureFormat().getPicture().setImage(thumbnail)

    presentation.save("online_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Reproducir un Video en Modo Pantalla Completa**

En una presentación de formación, puede reproducir una demostración de software en modo pantalla completa para que la audiencia pueda ver los detalles. Llame a [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) con `True` para habilitar este comportamiento durante la reproducción.

Este ejemplo abre una presentación, encuentra el primer [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) en la primera diapositiva y habilita la reproducción en pantalla completa. La presentación de entrada debe contener al menos una diapositiva con un marco de video existente en la primera diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setFullScreenMode(True)
            break

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La reproducción en pantalla completa controla cómo se muestra el video. De forma independiente, [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) controla si se inicia automáticamente o al hacer clic, y [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) controla si se repite. Para elegir el comportamiento de inicio, configure el modo de reproducción a [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/). El ejemplo conserva la configuración de inicio y bucle existente.

## **Retroceder un Video Tras la Reproducción**

En una presentación de formación, devolver un video de demostración a su inicio lo deja listo para que el presentador lo vuelva a reproducir. Llame a [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) con `True` para devolver el video al comienzo después de que finalice la reproducción.

Este ejemplo abre una presentación, encuentra el primer [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) en la primera diapositiva y habilita el retroceso. Desactiva el bucle para que la reproducción pueda finalizar y configura la reproducción para iniciar al hacer clic. La presentación de entrada debe contener al menos una diapositiva con un marco de video existente en la primera diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame, VideoPlayModePreset

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setRewindVideo(True)
            shape.setPlayLoopMode(False)
            shape.setPlayMode(VideoPlayModePreset.OnClick)
            break

    presentation.save("rewind_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El retroceso devuelve el video a su inicio sin volver a iniciarlo. En contraste, llamar a [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) con `True` repite la reproducción automáticamente. Mantenga el bucle desactivado cuando desee que el video finalice y permanezca listo para reproducirse nuevamente. [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) controla de forma independiente el inicio automático o al hacer clic; este ejemplo usa [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) para que el presentador controle cuándo comienza la reproducción. Establezca el modo de reproducción después de la configuración del bucle, como se muestra en el ejemplo. El retroceso funciona de forma independiente de [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode).

## **Recortar un Marco de Video**

Utilice [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) y [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) para omitir parte del inicio o del final de un video durante la reproducción. Ambos valores están en milisegundos. El recorte cambia la configuración de reproducción sin modificar los datos del video incrustado.

**Establecer configuración de recorte**

Este ejemplo incrusta un video local y omite los primeros 2,5 segundos y el último segundo durante la reproducción. Utilice un video de más de 3,5 segundos para que quede un segmento reproducible.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Leer la configuración de recorte**

Este ejemplo muestra los valores de recorte del primer marco de video en la primera diapositiva, en milisegundos. La presentación debe contener al menos una diapositiva. Si esa diapositiva no tiene un marco de video, no se muestra nada. El ejemplo anterior produce valores de 2500 y 1000.

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

## **Gestionar Subtítulos de Video**

Aspose.Slides le permite gestionar subtítulos cerrados para los marcos de video en presentaciones de PowerPoint. Los subtítulos se almacenan en formato WebVTT y se exponen mediante el método [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks).

**Añadir subtítulos a un marco de video**

Este ejemplo incrusta un video local y añade una pista de subtítulos WebVTT etiquetada como English. Las marcas de tiempo de los subtítulos deben coincidir con el video. La presentación guardada incluye tanto el video como sus subtítulos.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # Añadir una nueva pista de subtítulos desde un archivo WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La clase [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) también proporciona una sobrecarga que permite añadir subtítulos desde un flujo.

**Extraer subtítulos de un marco de video**

Este ejemplo guarda todas las pistas de subtítulos de los marcos de video en la primera diapositiva como archivos WebVTT separados. Los números secuenciales mantienen los archivos de salida distintos. La consola informa del número de pistas extraídas. La presentación debe contener al menos una diapositiva.

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

    track_count = 0
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                track_count += 1
                output_path = Path(f"captions_{track_count}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                output_path.write_bytes(caption_data)

    print(f"Caption tracks extracted: {track_count}")
finally:
    presentation.dispose()
```

Cada objeto [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) expone el identificador del subtítulo, la etiqueta, los datos binarios y el texto del subtítulo como una cadena UTF‑8.

**Eliminar subtítulos de un marco de video**

Este ejemplo elimina todos los subtítulos del marco de video situado en la primera posición de forma de la primera diapositiva y guarda el resultado. Se asume que la diapositiva y la forma existen y que la forma es un marco de video.

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
        # Eliminar todos los subtítulos del marco de video.
        video_frame.getCaptionTracks().clear()
        
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Si necesita eliminar solo una pista de subtítulos, use los métodos [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) o [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) en lugar de [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear).

## **Extraer Video de una Diapositiva**

Además de añadir videos a las diapositivas, Aspose.Slides permite extraer videos incrustados en presentaciones.

Este ejemplo extrae los videos incrustados de cada diapositiva en archivos binarios separados y numerados. Los videos vinculados se omiten porque no tienen datos incrustados. La consola muestra el tipo MIME de cada video y el recuento total. La salida usa la extensión genérica `.bin`; cámbiela para que coincida con el tipo de medio informado cuando sea necesario.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("presentation_with_videos.pptx")
try:
    video_count = 0
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = Path(f"extracted_video_{video_count}.bin")
                video_data = bytes(video.getBinaryData())
                output_path.write_bytes(video_data)
                print(f"Video {video_count}: {video.getContentType()}")

    print(f"Embedded videos extracted: {video_count}")
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Qué parámetros de reproducción de video pueden modificarse en un marco de video?**

Puede controlar el [playback mode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (auto o al hacer clic) y el [looping](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode). Estas opciones están disponibles a través de los métodos del objeto [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/).

**¿Afecta la adición de un video al tamaño del archivo PPTX?**

Sí. Cuando incrusta un video local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece en proporción al tamaño del archivo. Cuando enlaza a un video en línea y agrega una miniatura, la presentación almacena el enlace y la imagen de vista previa en lugar de los datos del video, por lo que el aumento de tamaño suele ser menor.

**¿Puedo reemplazar el video en un marco de video existente sin cambiar su posición y tamaño?**

Sí. Puede intercambiar el [video content](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) dentro del marco manteniendo la geometría de la forma; este es un escenario habitual para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un video incrustado?**

Sí. Un video incrustado tiene un [content type](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType) que puede leer y usar, por ejemplo al guardarlo en disco.