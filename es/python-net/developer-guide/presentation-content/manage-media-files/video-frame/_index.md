---
title: Añadir videos a presentaciones en Python
linktitle: Marco de video
type: docs
weight: 10
url: /es/python-net/video-frame/
keywords:
- añadir video
- crear video
- incrustar video
- extraer video
- recuperar video
- marco de video
- fuente web
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprende a añadir y extraer programáticamente marcos de video en presentaciones PowerPoint y OpenDocument usando Aspose.Slides para Python mediante .NET. Guía práctica y rápida."
---
## **Introducción**

Un video bien colocado en una presentación puede hacer que tu mensaje sea más atractivo y aumentar el nivel de compromiso con tu audiencia.

PowerPoint permite añadir videos a una diapositiva en una presentación de dos maneras:
* Añadir o incrustar un video local (almacenado en tu máquina)
* Añadir un video en línea (desde una fuente web como YouTube).

Para permitirte añadir videos (objetos de video) a una presentación, Aspose.Slides proporciona la clase [Video](https://reference.aspose.com/slides/es/python-net/aspose.slides/video/) la clase [VideoFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/) y otros tipos relevantes.

## **Crear un marco de video incrustado**

Si el archivo de video que deseas añadir a tu diapositiva está almacenado localmente, puedes crear un marco de video para incrustar el video en tu presentación.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Obtener la referencia de una diapositiva mediante su índice. 
1. Añadir un objeto [Video](https://reference.aspose.com/slides/es/python-net/aspose.slides/video/) y pasar la ruta del archivo de video para incrustar el video en la presentación. 
1. Añadir un objeto [VideoFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/) para crear un marco para el video.  
1. Guardar la presentación modificada. 

Este código Python muestra cómo añadir un video almacenado localmente a una presentación:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Obtiene la primera diapositiva y añade un marco de video
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Guarda la presentación en disco
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

Alternativamente, puedes añadir un video pasando su ruta de archivo directamente al método `add_video_frame(x, y, width, height, fname)`:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```


## **Crear un marco de video con video de una fuente web**

Las versiones más recientes de Microsoft [PowerPoint](https://support.microsoft.com/en-us/office/insert-a-video-from-youtube-or-another-site-8340ec69-4cee-4fe1-ab96-4849154bc6db) admiten videos en línea en las presentaciones. Si el video que deseas usar está disponible en línea (p.ej., en YouTube), puedes añadirlo a tu presentación mediante su enlace web.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Obtener la referencia de una diapositiva mediante su índice. 
1. Añadir un objeto [Video](https://reference.aspose.com/slides/es/python-net/aspose.slides/video/) y pasar el enlace al video.
1. Establecer una miniatura para el marco de video. 
1. Guardar la presentación. 

Este código Python muestra cómo añadir un video desde la web a una diapositiva en una presentación de PowerPoint:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Añade un marco de video
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # Carga la miniatura
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Recortar un marco de video**

Aspose.Slides permite controlar qué parte de un video se reproduce estableciendo los valores trim-from-start y trim-from-end mediante [VideoFrame.trim_from_start](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/trim_from_start/) y [VideoFrame.trim_from_end](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/trim_from_end/). Ambos valores se especifican en milisegundos y definen cuánto tiempo se omite al inicio y al final del video, respectivamente. Estos ajustes cambian la configuración de reproducción del video en la presentación; no recortan ni modifican de otra manera los datos binarios del video incrustado.

**Establecer ajustes de recorte**

Para crear un marco de video y establecer sus ajustes de recorte:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Añadir un objeto [Video](https://reference.aspose.com/slides/es/python-net/aspose.slides/video/) a la presentación.
1. Añadir un objeto [VideoFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/) a una diapositiva.
1. Establecer los valores trim-from-start y trim-from-end mediante [VideoFrame.trim_from_start](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/trim_from_start/) y [VideoFrame.trim_from_end](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/trim_from_end/).
1. Guardar la presentación modificada.

El siguiente ejemplo de código omite los primeros 2,5 segundos y el último segundo de un video incrustado durante la reproducción:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)

    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**Leer ajustes de recorte**

Para inspeccionar los ajustes de recorte existentes, carga una presentación, encuentra un objeto [VideoFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/) entre las formas de la primera diapositiva y lee los valores mediante [VideoFrame.trim_from_start](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/trim_from_start/) y [VideoFrame.trim_from_end](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/trim_from_end/).

El siguiente ejemplo de código encuentra el primer marco de video en la primera diapositiva y muestra sus ajustes de recorte en milisegundos:

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            video_frame = shape
            trim_from_start = video_frame.trim_from_start
            trim_from_end = video_frame.trim_from_end

            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
```

## **Gestionar subtítulos de video**

Aspose.Slides permite gestionar subtítulos cerrados para los marcos de video en presentaciones de PowerPoint. Los subtítulos se almacenan en formato WebVTT y se exponen mediante la propiedad [VideoFrame.caption_tracks](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/caption_tracks/).

**Añadir subtítulos a un marco de video**

Para añadir subtítulos a un marco de video:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Añadir un video a la presentación.
1. Añadir un objeto [VideoFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/) a una diapositiva.
1. Utilizar la [CaptionsCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/captionscollection/) devuelta por [caption_tracks](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/caption_tracks/) para añadir una pista de subtítulos WebVTT.
1. Guardar la presentación modificada.

El siguiente código muestra cómo añadir subtítulos a un marco de video:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # Añade una nueva pista de subtítulos desde un archivo WebVTT.
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

La clase [CaptionsCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/captionscollection/) también ofrece una sobrecarga que permite añadir subtítulos desde un flujo.

**Extraer subtítulos de un marco de video**

Para extraer subtítulos de un marco de video:

1. Cargar la presentación que contiene el video.
1. Encontrar el objeto [VideoFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/) objetivo.
1. Iterar a través de la colección [caption_tracks](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/caption_tracks/).
1. Guardar cada pista de subtítulos en un archivo `.vtt`.

El siguiente código muestra cómo extraer subtítulos de un marco de video:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # Guarda la pista de subtítulos en un archivo WebVTT.
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

Cada objeto [Captions](https://reference.aspose.com/slides/es/python-net/aspose.slides/captions/) expone el identificador del subtítulo, la etiqueta, los datos binarios y el texto del subtítulo como una cadena UTF-8.

**Eliminar subtítulos de un marco de video**

Para eliminar subtítulos de un marco de video:

1. Cargar la presentación que contiene el video.
1. Obtener el objeto [VideoFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/) objetivo.
1. Eliminar las pistas de subtítulos de la [CaptionsCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/captionscollection/).
1. Guardar la presentación modificada.

El siguiente código muestra cómo eliminar todos los subtítulos de un marco de video:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # tipo: slides.VideoFrame

    # Elimina todos los subtítulos del marco de video.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Si necesitas eliminar solo una pista de subtítulos, utiliza los métodos [remove](https://reference.aspose.com/slides/es/python-net/aspose.slides/captionscollection/remove/) o [remove_at](https://reference.aspose.com/slides/es/python-net/aspose.slides/captionscollection/remove_at/) en lugar de [clear](https://reference.aspose.com/slides/es/python-net/aspose.slides/captionscollection/clear/).

## **Extraer video de una diapositiva**

Además de añadir videos a las diapositivas, Aspose.Slides permite extraer videos incrustados en presentaciones.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) para cargar la presentación que contiene el video. 
2. Iterar a través de todos los objetos [Slide](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/).
3. Iterar a través de todos los objetos [Shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/) para encontrar un [VideoFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/). 
4. Guardar el video en disco.

Este código Python muestra cómo extraer el video de una diapositiva de una presentación:

```python
import aspose.slides as slides

# Instancia un objeto Presentation que representa un archivo de presentación 
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **Preguntas frecuentes**

**¿Qué parámetros de reproducción de video se pueden cambiar para un VideoFrame?**

Puedes controlar el [modo de reproducción](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/play_mode/) (automático o al hacer clic) y el [bucle](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/play_loop_mode/). Estas opciones están disponibles a través de las propiedades del objeto [VideoFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/).

**¿Afecta la adición de un video al tamaño del archivo PPTX?**

Sí. Cuando incrustas un video local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece en proporción al tamaño del archivo. Cuando añades un video en línea, se incrustan un enlace y una miniatura, por lo que el aumento de tamaño es menor.

**¿Puedo reemplazar el video en un VideoFrame existente sin cambiar su posición y tamaño?**

Sí. Puedes intercambiar el [contenido del video](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/embedded_video/) dentro del marco preservando la geometría de la forma; este es un escenario común para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un video incrustado?**

Sí. Un video incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/es/python-net/aspose.slides/video/content_type/) que puedes leer y usar, por ejemplo al guardarlo en disco.