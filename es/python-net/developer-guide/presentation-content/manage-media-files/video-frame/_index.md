---
title: Añadir videos a presentaciones en Python
linktitle: Marco de vídeo
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
description: "Aprenda a añadir y extraer marcos de video de forma programática en diapositivas PowerPoint y OpenDocument utilizando Aspose.Slides para Python a través de .NET. Guía práctica rápida."
---

Un video bien colocado en una presentación puede hacer que tu mensaje sea más persuasivo y aumentar los niveles de compromiso con tu audiencia. 

PowerPoint permite añadir videos a una diapositiva en una presentación de dos maneras:

* Añadir o incrustar un video local (almacenado en tu máquina)  
* Añadir un video en línea (desde una fuente web como YouTube).  

Para permitirte añadir videos (objetos de video) a una presentación, Aspose.Slides proporciona la clase [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) , la clase [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) y otros tipos relevantes. 

## **Crear marco de video incrustado**

Si el archivo de video que deseas añadir a tu diapositiva está almacenado localmente, puedes crear un marco de video para incrustar el video en tu presentación. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
1. Obtén la referencia de una diapositiva mediante su índice.  
1. Añade un objeto [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) y pasa la ruta del archivo de video para incrustar el video en la presentación.  
1. Añade un objeto [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) para crear un marco para el video.  
1. Guarda la presentación modificada.  

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


Alternativamente, puedes añadir un video pasando directamente su ruta de archivo al método `add_video_frame(x, y, width, height, fname)`:
``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```



## **Crear marco de video con video de fuente web**

Microsoft [PowerPoint 2013 y versiones posteriores](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) admiten videos de YouTube en presentaciones. Si el video que deseas usar está disponible en línea (p. ej., en YouTube), puedes añadirlo a tu presentación mediante su enlace web. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
1. Obtén la referencia de una diapositiva mediante su índice.  
1. Añade un objeto [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) y pasa el enlace al video.  
1. Establece una miniatura para el marco de video.  
1. Guarda la presentación.  

Este código Python muestra cómo añadir un video de la web a una diapositiva en una presentación de PowerPoint:
```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Añade un VideoFrame
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

Además de añadir videos a las diapositivas, Aspose.Slides permite extraer videos incrustados en presentaciones.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) para cargar la presentación que contiene el video.  
2. Recorre todos los objetos [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/).  
3. Recorre todos los objetos [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) para encontrar un [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).  
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

**¿Qué parámetros de reproducción de video pueden modificarse para un VideoFrame?**

Puedes controlar el [modo de reproducción](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (automático o al hacer clic) y el [bucle](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/). Estas opciones están disponibles a través de las propiedades del objeto [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).  

**¿Afecta la adición de un video al tamaño del archivo PPTX?**

Sí. Cuando incrustas un video local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece en proporción al tamaño del archivo. Cuando añades un video en línea, se incrustan un enlace y una miniatura, de modo que el aumento de tamaño es menor.  

**¿Puedo reemplazar el video en un VideoFrame existente sin cambiar su posición y tamaño?**

Sí. Puedes intercambiar el [contenido del video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) dentro del marco manteniendo la geometría de la forma; este es un escenario común para actualizar medios en un diseño existente.  

**¿Se puede determinar el tipo de contenido (MIME) de un video incrustado?**

Sí. Un video incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) que puedes leer y utilizar, por ejemplo, al guardarlo en disco.