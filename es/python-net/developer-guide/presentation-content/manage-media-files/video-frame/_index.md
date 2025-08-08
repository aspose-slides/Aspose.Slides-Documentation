---
title: Agregar videos a presentaciones en Python
linktitle: Marco de video
type: docs
weight: 10
url: /es/python-net/video-frame/
keywords:
- agregar video
- crear video
- insertar video
- extraer video
- recuperar video
- marco de video
- fuente web
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprende a agregar y extraer marcos de video de forma programática en diapositivas de PowerPoint y OpenDocument usando Aspose.Slides for Python via .NET. Guía rápida paso a paso."
---

Un video bien ubicado en una presentación puede hacer que su mensaje sea más convincente e incrementar los niveles de compromiso con su audiencia.

PowerPoint le permite agregar videos a una diapositiva en una presentación de dos maneras:

* Agregar o incrustar un video local (almacenado en su máquina)
* Agregar un video en línea (de una fuente web como YouTube).

Para permitirle agregar videos (objetos de video) a una presentación, Aspose.Slides proporciona la interfaz [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/), la interfaz [IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/) y otros tipos relevantes.

## **Crear Marco de Video Incrustado**

Si el archivo de video que desea agregar a su diapositiva se almacena localmente, puede crear un marco de video para incrustar el video en su presentación.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenga la referencia de una diapositiva a través de su índice.
1. Agregue un objeto [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) y pase la ruta del archivo de video para incrustar el video con la presentación.
1. Agregue un objeto [IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/) para crear un marco para el video.
1. Guarde la presentación modificada.

Este código de Python le muestra cómo agregar un video almacenado localmente a una presentación:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Obtiene la primera diapositiva y agrega un marco de video
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Guarda la presentación en disco
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

Alternativamente, puede agregar un video pasando directamente la ruta de su archivo al método `add_video_frame(x, y, width, height, fname)`:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```


## **Crear Marco de Video con Video de Fuente Web**

Microsoft [PowerPoint 2013 y versiones posteriores](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) admite videos de YouTube en presentaciones. Si el video que desea utilizar está disponible en línea (por ejemplo, en YouTube), puede agregarlo a su presentación a través de su enlace web.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenga la referencia de una diapositiva a través de su índice.
1. Agregue un objeto [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) y pase el enlace al video.
1. Establezca una miniatura para el marco de video.
1. Guarde la presentación.

Este código de Python le muestra cómo agregar un video de la web a una diapositiva en una presentación de PowerPoint:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Agrega un marco de video
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

## **Extraer Video de Diapositiva**

Además de agregar videos a las diapositivas, Aspose.Slides le permite extraer videos incrustados en presentaciones.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) para cargar la presentación que contiene el video.
2. Itere a través de todos los objetos [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
3. Itere a través de todos los objetos [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) para encontrar un [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).
4. Guarde el video en disco.

Este código de Python le muestra cómo extraer el video de una diapositiva de presentación:

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