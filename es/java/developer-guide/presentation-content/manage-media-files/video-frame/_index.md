---
title: Gestionar fotogramas de video en presentaciones usando Java
linktitle: Fotograma de video
type: docs
weight: 10
url: /es/java/video-frame/
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
- Java
- Aspose.Slides
description: "Aprenda a programar la adición y extracción de fotogramas de video en diapositivas PowerPoint y OpenDocument usando Aspose.Slides para Java. Guía práctica rápida."
---

Un video bien colocado en una presentación puede hacer que su mensaje sea más atractivo y aumentar los niveles de compromiso con su audiencia. 

PowerPoint le permite agregar videos a una diapositiva en una presentación de dos maneras:

* Agregar o incrustar un video local (almacenado en su máquina)
* Agregar un video en línea (de una fuente web como YouTube).

Para permitirle agregar videos (objetos de video) a una presentación, Aspose.Slides ofrece la interfaz [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) y la interfaz [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/), así como otros tipos relevantes. 

## **Crear fotogramas de video incrustados**

Si el archivo de video que desea agregar a su diapositiva está almacenado localmente, puede crear un fotograma de video para incrustar el video en su presentación. 

1. Cree una instancia de la clase [Presentation ](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)class.
1. Obtenga una referencia a la diapositiva mediante su índice. 
1. Agregue un objeto [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) y pase la ruta del archivo de video para incrustar el video en la presentación. 
1. Agregue un objeto [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) para crear un fotograma para el video.  
1. Guarde la presentación modificada. 

This Java code shows you how to add a video stored locally to a presentation:
```java
// Instancia la clase Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // Carga el video
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Obtiene la primera diapositiva y agrega un videoframe
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Guarda la presentación en disco
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


Alternativamente, puede agregar un video pasando su ruta de archivo directamente al método [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) method:
``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```



## **Crear fotogramas de video con video de fuentes web**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) admite videos de YouTube en presentaciones. Si el video que desea usar está disponible en línea (p. ej., en YouTube), puede agregarlo a su presentación mediante su enlace web. 

1. Cree una instancia de la clase [Presentation ](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)class
1. Obtenga una referencia a la diapositiva mediante su índice. 
1. Agregue un objeto [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) y pase el enlace al video.
1. Establezca una miniatura para el fotograma de video. 
1. Guarde la presentación. 

This Java code shows you how to add a video from the web to a slide in a PowerPoint presentation:
```java
// Instancia un objeto Presentation que representa un archivo de presentación 
Presentation pres = new Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
private static void addVideoFromYouTube(Presentation pres, String videoID)
{
    // Agrega un videoFrame
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // Carga la miniatura
    String thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";
    URL url;

    try {
        url = new URL(thumbnailUri);
        videoFrame.getPictureFormat().getPicture().setImage(pres.getImages().addImage(url.openStream()));
    } catch (MalformedURLException e) {
        e.printStackTrace();
    } catch (IOException e) {
        e.printStackTrace();
    }
}
```


## **Extraer video de diapositivas**

Además de agregar videos a las diapositivas, Aspose.Slides le permite extraer videos incrustados en presentaciones.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) para cargar la presentación que contiene el video. 
2. Itere a través de todos los objetos [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/).
3. Itere a través de todos los objetos [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) para encontrar un [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/). 
4. Guarde el video en disco.

This Java code shows you how to extract the video on a presentation slide:
```java
// Instancia un objeto Presentation que representa un archivo de presentación 
Presentation pres = new Presentation("VideoSample.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        for (IShape shape : slide.getShapes()) 
        {
            if (shape instanceof VideoFrame) 
            {
                IVideoFrame vf = (IVideoFrame) shape;
                String type = vf.getEmbeddedVideo().getContentType();
                int ss = type.lastIndexOf('-');
                byte[] buffer = vf.getEmbeddedVideo().getBinaryData();

                //Obtiene la extensión del archivo
                int charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);

                FileOutputStream fop = new FileOutputStream("testing2." + type);
                fop.write(buffer);
                fop.flush();
                fop.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**¿Qué parámetros de reproducción de video se pueden cambiar para un VideoFrame?**

Puede controlar el [playback mode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (automático o al hacer clic) y el [looping](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Estas opciones están disponibles a través de las propiedades del objeto [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/).  

**¿Agregar un video afecta el tamaño del archivo PPTX?**

Sí. Cuando incrusta un video local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece en proporción al tamaño del archivo. Cuando agrega un video en línea, se incrustan un enlace y una miniatura, de modo que el aumento de tamaño es menor.  

**¿Puedo reemplazar el video en un VideoFrame existente sin cambiar su posición y tamaño?**

Sí. Puede intercambiar el [video content](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) dentro del fotograma manteniendo la geometría de la forma; este es un escenario común para actualizar medios en un diseño existente.  

**¿Se puede determinar el tipo de contenido (MIME) de un video incrustado?**

Sí. Un video incrustado tiene un [content type](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) que puede leer y usar, por ejemplo, al guardarlo en disco.  