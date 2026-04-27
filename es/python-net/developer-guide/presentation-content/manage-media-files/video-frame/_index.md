---
title: Añadir vídeos a presentaciones en Python
linktitle: Marco de vídeo
type: docs
weight: 10
url: /es/python-net/video-frame/
keywords:
- añadir vídeo
- crear vídeo
- incrustar vídeo
- extraer vídeo
- recuperar vídeo
- marco de vídeo
- fuente web
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprende a añadir y extraer marcos de vídeo de forma programática en diapositivas PowerPoint y OpenDocument usando Aspose.Slides para Python a través de .NET. Guía rápida paso a paso."
---
Un vídeo bien colocado en una presentación puede hacer que tu mensaje sea más atractivo y aumentar los niveles de compromiso con tu audiencia. 

PowerPoint permite añadir vídeos a una diapositiva de una presentación de dos formas:

* Añadir o incrustar un vídeo local (almacenado en tu equipo)
* Añadir un vídeo en línea (de una fuente web como YouTube). 

Para permitirte añadir vídeos (objetos de vídeo) a una presentación, Aspose.Slides ofrece la clase [Video](https://reference.aspose.com/slides/es/python-net/aspose.slides/video/) , la clase [VideoFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/) y otros tipos relevantes. 

## **Crear marco de vídeo incrustado**

Si el archivo de vídeo que deseas añadir a tu diapositiva está almacenado localmente, puedes crear un marco de vídeo para incrustar el vídeo en tu presentación. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) .
1. Obtén la referencia de una diapositiva mediante su índice. 
1. Añade un objeto [Video](https://reference.aspose.com/slides/es/python-net/aspose.slides/video/) y pasa la ruta del archivo de vídeo para incrustar el vídeo en la presentación. 
1. Añade un objeto [VideoFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/) para crear un marco para el vídeo.  
1. Guarda la presentación modificada. 

Este código Python muestra cómo añadir un vídeo almacenado localmente a una presentación:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Obtiene la primera diapositiva y añade un marco de vídeo
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Guarda la presentación en disco
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

Alternativamente, puedes añadir un vídeo pasando directamente su ruta de archivo al método `add_video_frame(x, y, width, height, fname)`:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```


## **Crear marco de vídeo con vídeo de origen web**

Microsoft [PowerPoint 2013 y versiones posteriores](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) admite vídeos de YouTube en presentaciones. Si el vídeo que deseas usar está disponible en línea (p. ej., en YouTube), puedes añadirlo a tu presentación mediante su enlace web. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) .
1. Obtén la referencia de una diapositiva mediante su índice. 
1. Añade un objeto [Video](https://reference.aspose.com/slides/es/python-net/aspose.slides/video/) y pasa el enlace al vídeo.
1. Establece una miniatura para el marco de vídeo. 
1. Guarda la presentación. 

Este código Python muestra cómo añadir un vídeo desde la web a una diapositiva en una presentación PowerPoint:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Añade un marco de vídeo
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

## **Gestionar subtítulos de vídeo**

Aspose.Slides permite gestionar subtítulos cerrados para marcos de vídeo en presentaciones PowerPoint. Los subtítulos se almacenan en formato WebVTT y están disponibles mediante la propiedad [VideoFrame.caption_tracks](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/caption_tracks/) .

**Añadir subtítulos a un marco de vídeo**

Para añadir subtítulos a un marco de vídeo:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) .
1. Añade un vídeo a la presentación.
1. Añade un objeto [VideoFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/) a una diapositiva.
1. Utiliza la [CaptionsCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/captionscollection/) devuelta por [caption_tracks](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/caption_tracks/) para añadir una pista de subtítulos WebVTT.
1. Guarda la presentación modificada.

El siguiente código muestra cómo añadir subtítulos a un marco de vídeo:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # Añade una nueva pista de subtítulos desde un archivo WebVTT.
    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

La clase [CaptionsCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/captionscollection/) también ofrece una sobrecarga que permite añadir subtítulos desde un flujo.

**Extraer subtítulos de un marco de vídeo**

Para extraer subtítulos de un marco de vídeo:

1. Carga la presentación que contiene el vídeo.
1. Encuentra el objeto [VideoFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/) objetivo.
1. Itera a través de la colección [caption_tracks](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/caption_tracks/) .
1. Guarda cada pista de subtítulos en un archivo `.vtt`.

El siguiente código muestra cómo extraer subtítulos de un marco de vídeo:

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

**Eliminar subtítulos de un marco de vídeo**

Para eliminar subtítulos de un marco de vídeo:

1. Carga la presentación que contiene el vídeo.
1. Obtén el objeto [VideoFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/) objetivo.
1. Elimina las pistas de subtítulos de la [CaptionsCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/captionscollection/) .
1. Guarda la presentación modificada.

El siguiente código muestra cómo eliminar todos los subtítulos de un marco de vídeo:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # tipo: slides.VideoFrame

    # Elimina todos los subtítulos del marco de vídeo.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Si necesitas eliminar solo una pista de subtítulos, utiliza los métodos [remove](https://reference.aspose.com/slides/es/python-net/aspose.slides/captionscollection/remove/) o [remove_at](https://reference.aspose.com/slides/es/python-net/aspose.slides/captionscollection/remove_at/) en lugar de [clear](https://reference.aspose.com/slides/es/python-net/aspose.slides/captionscollection/clear/) .

## **Extraer vídeo de una diapositiva**

Además de añadir vídeos a diapositivas, Aspose.Slides permite extraer los vídeos incrustados en presentaciones.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) para cargar la presentación que contiene el vídeo. 
2. Itera a través de todos los objetos [Slide](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/) .
3. Itera a través de todos los objetos [Shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/) para encontrar un [VideoFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/) . 
4. Guarda el vídeo en disco.

Este código Python muestra cómo extraer el vídeo de una diapositiva de una presentación:

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

**¿Qué parámetros de reproducción de vídeo se pueden cambiar en un VideoFrame?**

Puedes controlar el [modo de reproducción](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/play_mode/) (automático o al hacer clic) y el [bucle](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/play_loop_mode/). Estas opciones están disponibles mediante las propiedades del objeto [VideoFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/) .

**¿Afecta la incorporación de un vídeo al tamaño del archivo PPTX?**

Sí. Cuando incrustas un vídeo local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece en proporción al tamaño del archivo. Cuando añades un vídeo en línea, se incrustan un enlace y una miniatura, por lo que el aumento de tamaño es menor.

**¿Puedo reemplazar el vídeo en un VideoFrame existente sin cambiar su posición y tamaño?**

Sí. Puedes intercambiar el [contenido del vídeo](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/embedded_video/) dentro del marco mientras preservas la geometría de la forma; este es un escenario habitual para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un vídeo incrustado?**

Sí. Un vídeo incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/es/python-net/aspose.slides/video/content_type/) que puedes leer y utilizar, por ejemplo al guardarlo en disco.