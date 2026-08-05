---
title: Gestionar marcos de vídeo en presentaciones en Android
linktitle: Marco de vídeo
type: docs
weight: 10
url: /es/androidjava/video-frame/
keywords:
- añadir video
- crear video
- incrustar video
- extraer video
- recuperar video
- marco de vídeo
- fuente web
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Aprenda a añadir y extraer programáticamente marcos de vídeo en diapositivas PowerPoint y OpenDocument usando Aspose.Slides para Android mediante Java. Guía rápida paso a paso."
---
## **Introducción**

Un vídeo bien colocado en una presentación puede hacer que su mensaje sea más convincente y aumentar los niveles de compromiso con su audiencia. 

PowerPoint le permite añadir videos a una diapositiva en una presentación de dos formas:

* Añadir o incrustar un vídeo local (almacenado en su equipo)
* Añadir un vídeo en línea (desde una fuente web como YouTube).

Para permitirle añadir videos (objetos de vídeo) a una presentación, Aspose.Slides proporciona la interfaz [IVideo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideo/) , la interfaz [IVideoFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/) y otros tipos relevantes.

## **Crear un marco de vídeo incrustado**

Si el archivo de vídeo que desea añadir a su diapositiva está almacenado localmente, puede crear un marco de vídeo para incrustar el vídeo en su presentación. 

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation).
1. Obtenga una referencia a la diapositiva mediante su índice. 
1. Añada un objeto [IVideo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideo/) y pase la ruta del archivo de vídeo para incrustar el vídeo en la presentación.
1. Añada un objeto [IVideoFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/) para crear un marco para el vídeo.
1. Guarde la presentación modificada. 

Este código Java le muestra cómo añadir un vídeo almacenado localmente a una presentación:

```java
// Instancia la clase Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // Carga el vídeo
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Obtiene la primera diapositiva y añade un videoframe
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Guarda la presentación en disco
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

Alternativamente, puede añadir un vídeo pasando directamente su ruta de archivo al método [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Crear un marco de vídeo con vídeo de una fuente web**

Las versiones más recientes de Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) admiten vídeos en línea en las presentaciones. Si el vídeo que desea usar está disponible en línea (p.ej. en YouTube), puede añadirlo a su presentación mediante su enlace web.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation)
1. Obtenga una referencia a la diapositiva mediante su índice. 
1. Añada un objeto [IVideo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideo/) y pase el enlace al vídeo.
1. Establezca una miniatura para el marco de vídeo. 
1. Guarde la presentación. 

Este código Java le muestra cómo añadir un vídeo desde la web a una diapositiva en una presentación de PowerPoint:

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
    // Añade un marco de vídeo
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

## **Recortar un marco de vídeo**

Aspose.Slides le permite controlar qué parte de un vídeo se reproduce estableciendo los valores trim-from-start y trim-from-end mediante [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) y [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-). Ambos valores se especifican en milisegundos y definen cuánto tiempo se omite al inicio y al final del vídeo, respectivamente. Estas configuraciones cambian la reproducción del vídeo en la presentación; no recortan ni modifican los datos binarios del vídeo incrustado.

**Establecer la configuración de recorte**

Para crear un marco de vídeo y establecer sus configuraciones de recorte:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/).
1. Añada un objeto [IVideo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideo/) a la presentación.
1. Añada un objeto [IVideoFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/) a una diapositiva.
1. Establezca los valores trim-from-start y trim-from-end mediante [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) y [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-).
1. Guarde la presentación modificada.

El siguiente ejemplo de código omite los primeros 2,5 segundos y el último segundo de un vídeo incrustado durante la reproducción:

```java
Presentation presentation = new Presentation();
try {
    FileInputStream videoStream = new FileInputStream("video.mp4");
    try {
        IVideo video = presentation.getVideos().addVideo(
                videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
        ISlide slide = presentation.getSlides().get_Item(0);
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500f);
        videoFrame.setTrimFromEnd(1000f);

        presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**Leer la configuración de recorte**

Para inspeccionar las configuraciones de recorte existentes, cargue una presentación, busque un objeto [IVideoFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/) entre las formas de la primera diapositiva y lea los valores mediante [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/#getTrimFromStart--) y [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/#getTrimFromEnd--).

El siguiente ejemplo de código encuentra el primer marco de vídeo en la primera diapositiva y muestra sus configuraciones de recorte en milisegundos:

```java
Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            float trimFromStart = videoFrame.getTrimFromStart();
            float trimFromEnd = videoFrame.getTrimFromEnd();

            System.out.println("Trim from start: " + trimFromStart + " ms");
            System.out.println("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Gestionar subtítulos de vídeo**

Aspose.Slides le permite gestionar subtítulos cerrados para los marcos de vídeo en presentaciones de PowerPoint. Los subtítulos se almacenan en formato WebVTT y se exponen mediante el método [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).

**Añadir subtítulos a un marco de vídeo**

Para añadir subtítulos a un marco de vídeo:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/).
1. Añada un vídeo a la presentación.
1. Añada un objeto [IVideoFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/) a una diapositiva.
1. Utilice la [ICaptionsCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icaptionscollection/) devuelta por [getCaptionTracks](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) para añadir una pista de subtítulos WebVTT.
1. Guarde la presentación modificada.

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Añade una nueva pista de subtítulos desde un archivo WebVTT.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La interfaz [ICaptionsCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icaptionscollection/) también proporciona una sobrecarga que le permite añadir subtítulos desde un flujo.

**Extraer subtítulos de un marco de vídeo**

Para extraer subtítulos de un marco de vídeo:

1. Cargue la presentación que contiene el vídeo.
1. Encuentre el objeto [IVideoFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/) objetivo.
1. Itere a través de las pistas de subtítulos devueltas por [getCaptionTracks](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
1. Guarde cada pista de subtítulos en un archivo `.vtt`.

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Guarda la pista de subtítulos en un archivo WebVTT.
                FileOutputStream outputStream = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                outputStream.write(captionTrack.getBinaryData());
                outputStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Cada objeto [ICaptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icaptions/) expone el identificador del subtítulo, la etiqueta, los datos binarios y los datos del subtítulo como una cadena UTF-8.

**Eliminar subtítulos de un marco de vídeo**

Para eliminar subtítulos de un marco de vídeo:

1. Cargue la presentación que contiene el vídeo.
1. Obtenga el objeto [IVideoFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/) objetivo.
1. Elimine las pistas de subtítulos de la colección devuelta por [getCaptionTracks](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
1. Guarde la presentación modificada.

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // Elimina todos los subtítulos del marco de vídeo.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si necesita eliminar solo una pista de subtítulos, utilice los métodos [remove](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) o [removeAt](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) en lugar de [clear](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icaptionscollection/#clear--).

## **Extraer video de una diapositiva**

Además de añadir videos a las diapositivas, Aspose.Slides le permite extraer los videos incrustados en presentaciones.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation) para cargar la presentación que contiene el video.
2. Itere a través de todos los objetos [ISlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islide/).
3. Itere a través de todos los objetos [IShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/) para encontrar un [VideoFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/videoframe/).
4. Guarde el video en disco.

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

                // Obtiene la extensión del archivo
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

## **Preguntas frecuentes**

**¿Qué parámetros de reproducción de video pueden modificarse para un VideoFrame?**

Puede controlar el [modo de reproducción](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (automático o al hacer clic) y el [bucle de reproducción](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Estas opciones están disponibles a través de las propiedades del objeto [VideoFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/videoframe/).

**¿Afecta la incorporación de un video al tamaño del archivo PPTX?**

Sí. Cuando incrusta un video local, los datos binarios se incluyen en el documento, de modo que el tamaño de la presentación crece en proporción al tamaño del archivo. Cuando añade un video en línea, se incrustan un enlace y una miniatura, por lo que el aumento de tamaño es menor.

**¿Puedo reemplazar el video en un VideoFrame existente sin cambiar su posición y tamaño?**

Sí. Puede intercambiar el [contenido del video](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) dentro del marco conservando la geometría de la forma; es un escenario habitual para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un video incrustado?**

Sí. Un video incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/video/#getContentType--) que puede leer y utilizar, por ejemplo, al guardarlo en disco.