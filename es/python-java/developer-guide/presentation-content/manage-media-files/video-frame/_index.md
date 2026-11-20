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
description: "Aprenda a añadir y extraer fotogramas de vídeo de forma programática en diapositivas de PowerPoint y OpenDocument usando Aspose.Slides para Python a través de Java. Guía rápida de cómo hacerlo."
---
## **Introducción**

Los vídeos pueden ayudar a explicar ideas y captar la atención de la audiencia. Aspose.Slides para Python mediante Java le permite añadir fotogramas de vídeo a diapositivas, ajustar la configuración de reproducción, gestionar subtítulos y extraer datos de vídeo incrustados.

PowerPoint admite vídeos locales y enlaces a vídeos en línea, como los de YouTube.

Para representar datos de vídeo y fotogramas de vídeo, Aspose.Slides ofrece la clase [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/), la clase [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) y otros tipos relevantes.

## **Crear un fotograma de vídeo incrustado**

Si el archivo de vídeo que desea añadir a su diapositiva está almacenado localmente, puede crear un fotograma de vídeo para incrustar el vídeo en su presentación.

Este ejemplo incrusta un vídeo local en la primera diapositiva de una presentación existente y guarda el resultado. Las coordenadas y dimensiones del fotograma se expresan en puntos. Python lee los bytes del vídeo desde el disco, y JPype los convierte en una matriz de bytes Java antes de que el vídeo se añada a la presentación.

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

También puede pasar la ruta de un vídeo local directamente a [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame). Este ejemplo incrusta el vídeo en la primera diapositiva de una nueva presentación. El vídeo debe permanecer accesible hasta que la presentación se guarde.

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

## **Crear un fotograma de vídeo con vídeo de una fuente web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) admite vídeos en línea en las presentaciones. Puede crear un fotograma de vídeo que enlace a un vídeo en línea, como un vídeo de YouTube.

Este ejemplo añade un enlace a un vídeo de YouTube y una miniatura en la primera diapositiva. Reemplace el identificador del vídeo para usar otro vídeo. El método [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) solicita la reproducción automática. Descargar la miniatura y reproducir el vídeo requieren acceso a Internet. El visor de presentaciones también debe admitir la reproducción de vídeo en línea.

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

## **Reproducir un vídeo en modo pantalla completa**

En una presentación de formación, puede reproducir una demostración de software en modo pantalla completa para que la audiencia vea los detalles. Llame a [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) con `True` para habilitar este comportamiento durante la reproducción.

Este ejemplo abre una presentación, encuentra el primer [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) en la primera diapositiva y habilita la reproducción en pantalla completa. La presentación de entrada debe contener al menos una diapositiva con un fotograma de vídeo existente en la primera diapositiva.

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

La reproducción en pantalla completa controla cómo se muestra el vídeo. De forma independiente, [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) controla si se inicia automáticamente o al hacer clic, y [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) controla si se repite. Para elegir el comportamiento de inicio, establezca el modo de reproducción a [VideoPlayModePreset.Auto o VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/). El ejemplo conserva los ajustes de inicio y bucle existentes.

## **Rebobinar un vídeo después de la reproducción**

En una presentación de formación, devolver un vídeo de demostración a su principio lo deja listo para que el presentador lo reproduzca nuevamente. Llame a [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) con `True` para devolver el vídeo al principio después de que finalice la reproducción.

Este ejemplo abre una presentación, encuentra el primer [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) en la primera diapositiva y habilita el rebobinado. Desactiva el bucle para que la reproducción pueda terminar y establece que la reproducción inicie al hacer clic. La presentación de entrada debe contener al menos una diapositiva con un fotograma de vídeo existente en la primera diapositiva.

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

El rebobinado devuelve el vídeo a su inicio sin volver a iniciarlo. En contraste, llamar a [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) con `True` repite la reproducción automáticamente. Mantenga el bucle desactivado cuando desee que el vídeo termine y quede listo para reproducirlo de nuevo. [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) controla de forma independiente el inicio automático o al hacer clic; este ejemplo usa [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) para que el presentador controle cuándo comienza la reproducción. Establezca el modo de reproducción después del ajuste de bucle, como se muestra en el ejemplo. El rebobinado funciona independientemente de [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode).

## **Recortar un fotograma de vídeo**

Utilice [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) y [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) para omitir parte del inicio o del final de un vídeo durante la reproducción. Ambos valores se expresan en milisegundos. El recorte modifica la configuración de reproducción sin alterar los datos del vídeo incrustado.

**Establecer ajustes de recorte**

Este ejemplo incrusta un vídeo local y omite los primeros 2,5 segundos y el último segundo durante la reproducción. Utilice un vídeo de más de 3,5 segundos para que quede un segmento reproducible.

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

**Leer ajustes de recorte**

Este ejemplo muestra los valores de recorte del primer fotograma de vídeo en la primera diapositiva en milisegundos. La presentación debe contener al menos una diapositiva. Si esa diapositiva no tiene fotograma de vídeo, no se muestra nada. El ejemplo anterior produce los valores 2500 y 1000.

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

Aspose.Slides le permite gestionar subtítulos ocultos para fotogramas de vídeo en presentaciones de PowerPoint. Los subtítulos se almacenan en formato WebVTT y se exponen mediante el método [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks).

### **Añadir subtítulos a un fotograma de vídeo**

Este ejemplo incrusta un vídeo local y añade una pista de subtítulos WebVTT etiquetada como English. Las marcas de tiempo de los subtítulos deben coincidir con el vídeo. La presentación guardada incluye tanto el vídeo como sus subtítulos.

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

La clase [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) también ofrece una sobrecarga que permite añadir subtítulos desde un flujo.

### **Extraer subtítulos de un fotograma de vídeo**

Este ejemplo guarda todas las pistas de subtítulos de los fotogramas de vídeo en la primera diapositiva como archivos WebVTT independientes. Los números secuenciales mantienen los archivos de salida distintos. La consola informa del número de pistas extraídas. La presentación debe contener al menos una diapositiva.

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

Cada objeto [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) expone el identificador del subtítulo, la etiqueta, los datos binarios y el texto del subtítulo como una cadena UTF-8.

### **Eliminar subtítulos de un fotograma de vídeo**

Este ejemplo elimina todos los subtítulos del fotograma de vídeo ubicado en la primera posición de forma en la primera diapositiva y guarda el resultado. Se asume que la diapositiva y la forma existen y que la forma es un fotograma de vídeo.

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

Si necesita eliminar solo una pista de subtítulos, utilice los métodos [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) o [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) en lugar de [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear).

### **Buscar subtítulos de vídeo**

[Captions.getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) devuelve la pista completa de WebVTT, incluyendo su cabecera, líneas de temporización y texto del subtítulo. Puede buscar los subtítulos en memoria para encontrar una frase y su marca de tiempo. Por ejemplo, una pista en inglés en la diapositiva 2 podría contener el siguiente texto.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Este ejemplo abre `captioned_media.pptx` y usa [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) para leer las pistas de cada fotograma de vídeo de nivel superior en todas las diapositivas. En una señal de texto plano, la línea de temporización contiene `-->`, y una línea en blanco finaliza la señal. Para cada subtítulo que contenga “café” en cualquier combinación de mayúsculas y minúsculas, el ejemplo muestra el número de diapositiva, la etiqueta de la pista, la línea de temporización original y el subtítulo completo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("captioned_media.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, VideoFrame):
                continue
            for track in shape.getCaptionTracks():
                track_text = str(track.getDataAsString())
                lines = iter(track_text.splitlines())
                for timing in lines:
                    if "-->" not in timing:
                        continue
                    caption_lines = []
                    for line in lines:
                        if not line:
                            break
                        caption_lines.append(line)
                    caption = "\n".join(caption_lines)
                    if "café" in caption.casefold():
                        print(f"Slide {slide.getSlideNumber()} | {track.getLabel()} | {timing}")
                        print(caption)
finally:
    presentation.dispose()
```

Buscar “café” produce una coincidencia en la pista de ejemplo. La búsqueda excluye la cabecera de la pista y conserva la configuración de temporización y los saltos de línea en la salida.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Extraer vídeo de una diapositiva**

Además de añadir vídeos a las diapositivas, Aspose.Slides permite extraer los vídeos incrustados en las presentaciones.

Este ejemplo extrae los vídeos incrustados de cada diapositiva en archivos binarios separados y numerados. Los vídeos enlazados se omiten porque no tienen datos incrustados. La consola muestra el tipo MIME de cada vídeo y el recuento total. La salida utiliza la extensión genérica `.bin`; cámbiela para que coincida con el tipo de medio reportado cuando sea necesario.

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

**¿Qué parámetros de reproducción de vídeo pueden modificarse en un fotograma de vídeo?**

Puede controlar el [modo de reproducción](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (automático o al hacer clic) y el [bucle](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode). Estas opciones están disponibles a través de los métodos del objeto [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/).

**¿Afecta la adición de un vídeo al tamaño del archivo PPTX?**

Sí. Cuando incrusta un vídeo local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece en proporción al tamaño del archivo. Cuando enlaza a un vídeo en línea y añade una miniatura, la presentación almacena el enlace y la imagen de vista previa en lugar de los datos del vídeo, por lo que el aumento de tamaño suele ser menor.

**¿Puedo reemplazar el vídeo en un fotograma de vídeo existente sin cambiar su posición y tamaño?**

Sí. Puede intercambiar el [contenido del vídeo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) dentro del fotograma manteniendo la geometría de la forma; este es un escenario habitual para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un vídeo incrustado?**

Sí. Un vídeo incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType) que puede leer y utilizar, por ejemplo al guardarlo en disco.