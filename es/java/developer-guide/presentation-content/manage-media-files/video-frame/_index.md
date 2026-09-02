---
title: Gestionar marcos de vídeo en presentaciones usando Java
linktitle: Marco de vídeo
type: docs
weight: 10
url: /es/java/video-frame/
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
- Java
- Aspose.Slides
description: "Aprende a añadir y extraer programáticamente marcos de vídeo en diapositivas PowerPoint y OpenDocument usando Aspose.Slides para Java. Guía práctica rápida."
---
## **Introducción**

Un vídeo bien colocado en una presentación puede hacer que tu mensaje sea más atractivo y aumentar los niveles de participación de la audiencia.  

PowerPoint permite añadir vídeos a una diapositiva de una presentación de dos maneras:

* Añadir o incrustar un vídeo local (almacenado en tu equipo)
* Añadir un vídeo en línea (de una fuente web como YouTube).

Para permitirte añadir vídeos (objetos de vídeo) a una presentación, Aspose.Slides proporciona la interfaz [IVideo](https://reference.aspose.com/slides/es/java/com.aspose.slides/ivideo/) , la interfaz [IVideoFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/ivideoframe/) y otros tipos relevantes. 

## **Crear fotogramas de vídeo incrustados**

Si el archivo de vídeo que quieres añadir a tu diapositiva está almacenado localmente, puedes crear un marco de vídeo para incrustar el vídeo en tu presentación. 

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/Presentation).
2. Obtener la referencia de una diapositiva mediante su índice. 
3. Añadir un objeto [IVideo] y pasar la ruta del archivo de vídeo para incrustar el vídeo en la presentación. 
4. Añadir un objeto [IVideoFrame] para crear un marco para el vídeo.  
5. Guardar la presentación modificada. 

Este código Java muestra cómo añadir un vídeo almacenado localmente a una presentación:

```java
// Instancia la clase Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // Carga el vídeo
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Obtiene la primera diapositiva y añade un marco de vídeo
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Guarda la presentación en disco
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

Alternativamente, puedes añadir un vídeo pasando directamente su ruta de archivo al método [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-):

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Crear marcos de vídeo con vídeo de fuentes web**

Microsoft [PowerPoint 2013 y versiones posteriores](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) admite vídeos de YouTube en presentaciones. Si el vídeo que deseas usar está disponible en línea (p. ej., en YouTube), puedes añadirlo a tu presentación mediante su enlace web. 

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/Presentation).
2. Obtener la referencia de una diapositiva mediante su índice. 
3. Añadir un objeto [IVideo] y pasar el enlace al vídeo.
4. Establecer una miniatura para el marco de vídeo. 
5. Guardar la presentación. 

Este código Java muestra cómo añadir un vídeo desde la web a una diapositiva en una presentación de PowerPoint:

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

Aspose.Slides permite controlar qué parte de un vídeo se reproduce estableciendo los valores trim‑from‑start y trim‑from‑end mediante [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/es/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) y [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/es/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-). Ambos valores se especifican en milisegundos y definen cuánto tiempo se omite al principio y al final del vídeo, respectivamente. Estas configuraciones cambian la reproducción del vídeo en la presentación; no recortan ni modifican los datos binarios del vídeo incrustado.

**Establecer configuración de recorte**

Para crear un marco de vídeo y establecer sus valores de recorte:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/).
2. Añadir un objeto [IVideo] a la presentación.
3. Añadir un objeto [IVideoFrame] a una diapositiva.
4. Establecer los valores trim‑from‑start y trim‑from‑end mediante [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/es/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) y [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/es/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-).
5. Guardar la presentación modificada.

El siguiente ejemplo de código omite los primeros 2,5 s y el último segundo de un vídeo incrustado durante la reproducción:

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

**Leer configuración de recorte**

Para inspeccionar los valores de recorte existentes, carga una presentación, encuentra un objeto [IVideoFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/ivideoframe/) entre las formas de la primera diapositiva y lee los valores mediante [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/es/java/com.aspose.slides/ivideoframe/#getTrimFromStart--) y [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/es/java/com.aspose.slides/ivideoframe/#getTrimFromEnd--).

El siguiente ejemplo de código encuentra el primer marco de vídeo en la primera diapositiva y muestra sus valores de recorte en milisegundos:

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

Aspose.Slides permite gestionar subtítulos cerrados para los marcos de vídeo en presentaciones de PowerPoint. Los subtítulos se almacenan en formato WebVTT y se exponen mediante el método [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/es/java/com.aspose.slides/ivideoframe/#getCaptionTracks--).

**Añadir subtítulos a un marco de vídeo**

Para añadir subtítulos a un marco de vídeo:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/).
2. Añadir un vídeo a la presentación.
3. Añadir un objeto [IVideoFrame] a una diapositiva.
4. Utilizar la [ICaptionsCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/icaptionscollection/) devuelta por [getCaptionTracks](https://reference.aspose.com/slides/es/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) para añadir una pista de subtítulos WebVTT.
5. Guardar la presentación modificada.

El siguiente código muestra cómo añadir subtítulos a un marco de vídeo:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Añade una nueva pista de subtítulos desde un archivo WebVTT.
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La interfaz [ICaptionsCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/icaptionscollection/) también ofrece una sobrecarga que permite añadir subtítulos desde un flujo.

**Extraer subtítulos de un marco de vídeo**

Para extraer subtítulos de un marco de vídeo:

1. Cargar la presentación que contiene el vídeo.
2. Encontrar el objeto [IVideoFrame] objetivo.
3. Iterar a través de las pistas de subtítulos en la [ICaptionsCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/icaptionscollection/).
4. Guardar cada pista de subtítulos en un archivo `.vtt`.

El siguiente código muestra cómo extraer subtítulos de un marco de vídeo:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame)shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Guarda la pista de subtítulos en un archivo WebVTT.
                String filePath = captionTrack.getCaptionId().toString() + ".vtt";
                Files.write(Paths.get(filePath), captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Cada objeto [ICaptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/icaptions/) expone el identificador del subtítulo, la etiqueta, los datos binarios y el texto del subtítulo como una cadena UTF‑8.

**Eliminar subtítulos de un marco de vídeo**

Para eliminar subtítulos de un marco de vídeo:

1. Cargar la presentación que contiene el vídeo.
2. Obtener el objeto [IVideoFrame] objetivo.
3. Eliminar las pistas de subtítulos de la [ICaptionsCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/icaptionscollection/).
4. Guardar la presentación modificada.

El siguiente código muestra cómo eliminar todos los subtítulos de un marco de vídeo:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // Elimina todos los subtítulos del marco de vídeo.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si solo necesitas eliminar una pista de subtítulos, utiliza los métodos [remove](https://reference.aspose.com/slides/es/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) o [removeAt](https://reference.aspose.com/slides/es/java/com.aspose.slides/icaptionscollection/#removeAt-int-) en lugar de [clear](https://reference.aspose.com/slides/es/java/com.aspose.slides/icaptionscollection/#clear--).

## **Extraer vídeo de diapositivas**

Además de añadir vídeos a las diapositivas, Aspose.Slides permite extraer los vídeos incrustados en presentaciones.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/Presentation) para cargar la presentación que contiene el vídeo. 
2. Recorrer todos los objetos [ISlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/islide/). 
3. Recorrer todos los objetos [IShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/) para encontrar un [VideoFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/videoframe/). 
4. Guardar el vídeo en disco.

Este código Java muestra cómo extraer el vídeo de una diapositiva de una presentación:

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

## **Preguntas frecuentes**

**¿Qué parámetros de reproducción de vídeo se pueden cambiar para un VideoFrame?**

Puedes controlar el modo de reproducción (automático o al hacer clic) y el bucle mediante las propiedades del objeto [VideoFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/videoframe/).

**¿Afecta la adición de un vídeo al tamaño del archivo PPTX?**

Sí. Cuando incrustas un vídeo local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece proporcionalmente al tamaño del archivo. Cuando añades un vídeo en línea, solo se incrustan un enlace y una miniatura, por lo que el aumento de tamaño es menor.

**¿Puedo reemplazar el vídeo en un VideoFrame existente sin cambiar su posición y tamaño?**

Sí. Puedes intercambiar el contenido del vídeo dentro del marco conservando la geometría de la forma; es un escenario habitual para actualizar medios en un diseño ya existente.

**¿Se puede determinar el tipo de contenido (MIME) de un vídeo incrustado?**

Sí. Un vídeo incrustado dispone de un tipo de contenido que puedes leer y utilizar, por ejemplo, al guardarlo en disco.