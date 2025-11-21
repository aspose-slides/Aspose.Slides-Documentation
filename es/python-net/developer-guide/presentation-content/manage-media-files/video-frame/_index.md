---
title: Agregar videos a presentaciones en Python
linktitle: Fotograma de video
type: docs
weight: 10
url: /es/python-net/video-frame/
keywords:
- agregar video
- crear video
- incrustar video
- extraer video
- recuperar video
- fotograma de video
- fuente web
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda a agregar y extraer fotogramas de video de forma programática en diapositivas PowerPoint y OpenDocument usando Aspose.Slides para Python a través de .NET. Guía práctica rápida."
---

Un video bien colocado en una presentación puede hacer que tu mensaje sea más convincente y aumentar los niveles de compromiso con tu audiencia. 

PowerPoint te permite agregar videos a una diapositiva en una presentación de dos maneras:

* Agregar o incrustar un video local (almacenado en tu máquina)
* Agregar un video en línea (desde una fuente web como YouTube).

Para permitirte agregar videos (objetos de video) a una presentación, Aspose.Slides proporciona la interfaz [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) y la interfaz [IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/) y otros tipos relevantes. 

## **Crear fotograma de video incrustado**

Si el archivo de video que deseas agregar a tu diapositiva está almacenado localmente, puedes crear un fotograma de video para incrustar el video en tu presentación. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtén una referencia a una diapositiva mediante su índice. 
3. Agrega un objeto [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) y pasa la ruta del archivo de video para incrustar el video en la presentación. 
4. Agrega un objeto [IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/) para crear un fotograma para el video.  
5. Guarda la presentación modificada. 

Este código Python muestra cómo agregar un video almacenado localmente a una presentación:
```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Obtiene la primera diapositiva y agrega un fotograma de video
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Guarda la presentación en disco
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```


Alternativamente, puedes agregar un video pasando su ruta de archivo directamente al método `add_video_frame(x, y, width, height, fname)`.
``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```


## **Crear fotograma de video con video de fuente web**

Microsoft [PowerPoint 2013 y versiones posteriores](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) admite videos de YouTube en presentaciones. Si el video que deseas usar está disponible en línea (p. ej., en YouTube), puedes agregarlo a tu presentación mediante su enlace web. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. Obtén una referencia a una diapositiva mediante su índice. 
3. Agrega un objeto [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) y pasa el enlace al video.
4. Establece una miniatura para el fotograma de video. 
5. Guarda la presentación. 

Este código Python muestra cómo agregar un video desde la web a una diapositiva en una presentación de PowerPoint:
```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Añade un videoFrame
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


## **Extraer video de la diapositiva**

Además de agregar videos a las diapositivas, Aspose.Slides te permite extraer videos incrustados en presentaciones.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) para cargar la presentación que contiene el video. 
2. Itera a través de todos los objetos [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/). 
3. Itera a través de todos los objetos [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) para encontrar un [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/). 
4. Guarda el video en disco.

Este código Python muestra cómo extraer el video de una diapositiva de presentación:
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

Puedes controlar el [modo de reproducción](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (automático o al hacer clic) y el [bucle](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/). Estas opciones están disponibles a través de las propiedades del objeto [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).

**¿Agregar un video afecta al tamaño del archivo PPTX?**

Sí. Cuando incrustas un video local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece proporcionalmente al tamaño del archivo. Cuando agregas un video en línea, se incrustan un enlace y una miniatura, por lo que el aumento de tamaño es menor.

**¿Puedo reemplazar el video en un VideoFrame existente sin cambiar su posición y tamaño?**

Sí. Puedes intercambiar el [contenido de video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) dentro del fotograma manteniendo la geometría de la forma; este es un escenario frecuente para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un video incrustado?**

Sí. Un video incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) que puedes leer y usar, por ejemplo al guardarlo en disco.