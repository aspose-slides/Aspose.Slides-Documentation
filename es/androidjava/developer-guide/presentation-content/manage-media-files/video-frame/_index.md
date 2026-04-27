---
title: Gestionar marcos de video en presentaciones en Android
linktitle: Marco de video
type: docs
weight: 10
url: /es/androidjava/video-frame/
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
- Android
- Java
- Aspose.Slides
description: "Aprende a añadir y extraer programáticamente marcos de video en diapositivas PowerPoint y OpenDocument usando Aspose.Slides para Android mediante Java. Guía rápida paso a paso."
---
Un video bien colocado en una presentación puede hacer que tu mensaje resulte más convincente y aumentar los niveles de participación de tu audiencia. 

PowerPoint te permite añadir videos a una diapositiva de una presentación de dos formas:

* Añadir o incrustar un video local (almacenado en tu equipo)
* Añadir un video en línea (desde una fuente web como YouTube).

Para permitirte añadir videos (objetos de video) a una presentación, Aspose.Slides proporciona la interfaz [IVideo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideo/), la interfaz [IVideoFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/) y otros tipos relevantes.

## **Crear un marco de video incrustado**

Si el archivo de video que deseas añadir a tu diapositiva está almacenado localmente, puedes crear un marco de video para incrustar el video en tu presentación. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation).
1. Obtén la referencia a una diapositiva mediante su índice. 
1. Añade un objeto [IVideo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideo/) y pasa la ruta del archivo de video para incrustar el video en la presentación.
1. Añade un objeto [IVideoFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/) para crear un marco para el video.
1. Guarda la presentación modificada. 

Este código Java te muestra cómo añadir un video almacenado localmente a una presentación:

```java
// Instancia la clase Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // Carga el video
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Obtiene la primera diapositiva y añade un marco de video
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Guarda la presentación en disco
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

Alternativamente, puedes añadir un video pasando directamente su ruta de archivo al método [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Crear un marco de video con video de una fuente web**

Microsoft [PowerPoint 2013 y versiones posteriores](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) admite videos de YouTube en presentaciones. Si el video que deseas usar está disponible en línea (por ejemplo, en YouTube), puedes añadirlo a tu presentación a través de su enlace web. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation).
1. Obtén la referencia a una diapositiva mediante su índice. 
1. Añade un objeto [IVideo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideo/) y pasa el enlace al video.
1. Establece una miniatura para el marco de video. 
1. Guarda la presentación. 

Este código Java te muestra cómo añadir un video desde la web a una diapositiva en una presentación de PowerPoint:

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
    // Añade un marco de video
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

## **Gestionar subtítulos de video**

Aspose.Slides te permite gestionar subtítulos cerrados para los marcos de video en presentaciones de PowerPoint. Los subtítulos se almacenan en formato WebVTT y se exponen mediante el método [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**Añadir subtítulos a un marco de video**

Para añadir subtítulos a un marco de video:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/) .
1. Añade un video a la presentación.
1. Añade un objeto [IVideoFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/) a una diapositiva.
1. Utiliza la [ICaptionsCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icaptionscollection/) devuelta por [getCaptionTracks](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) para añadir una pista de subtítulos WebVTT.
1. Guarda la presentación modificada.

El siguiente código te muestra cómo añadir subtítulos a un marco de video:

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

La interfaz [ICaptionsCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icaptionscollection/) también ofrece una sobrecarga que permite añadir subtítulos desde un flujo.

**Extraer subtítulos de un marco de video**

Para extraer subtítulos de un marco de video:

1. Carga la presentación que contiene el video.
1. Encuentra el objeto [IVideoFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/) objetivo.
1. Recorre las pistas de subtítulos devueltas por [getCaptionTracks](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .
1. Guarda cada pista de subtítulos en un archivo `.vtt`.

El siguiente código te muestra cómo extraer subtítulos de un marco de video:

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

**Eliminar subtítulos de un marco de video**

Para eliminar subtítulos de un marco de video:

1. Carga la presentación que contiene el video.
1. Obtén el objeto [IVideoFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/) objetivo.
1. Elimina las pistas de subtítulos de la colección devuelta por [getCaptionTracks](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .
1. Guarda la presentación modificada.

El siguiente código te muestra cómo eliminar todos los subtítulos de un marco de video:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // Elimina todos los subtítulos del marco de video.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si necesitas eliminar solo una pista de subtítulos, usa los métodos [remove](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) o [removeAt](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) en lugar de [clear](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icaptionscollection/#clear--) .

## **Extraer video de una diapositiva**

Además de añadir videos a diapositivas, Aspose.Slides te permite extraer videos incrustados en presentaciones.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation) para cargar la presentación que contiene el video.
2. Recorre todos los objetos [ISlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islide/) .
3. Recorre todos los objetos [IShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/) para encontrar un [VideoFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/videoframe/) .
4. Guarda el video en disco.

Este código Java te muestra cómo extraer el video de una diapositiva de una presentación:

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

## **FAQ**

**¿Qué parámetros de reproducción de video pueden modificarse para un VideoFrame?**

Puedes controlar el [modo de reproducción](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (automático o al hacer clic) y el [bucle de reproducción](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) . Estas opciones están disponibles a través de las propiedades del objeto [VideoFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/videoframe/) .

**¿Afecta la incorporación de un video al tamaño del archivo PPTX?**

Sí. Cuando incrustas un video local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece en proporción al tamaño del archivo. Cuando añades un video en línea, se incrustan un enlace y una miniatura, de modo que el aumento de tamaño es menor.

**¿Puedo sustituir el video de un VideoFrame existente sin cambiar su posición y tamaño?**

Sí. Puedes intercambiar el [contenido del video](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) dentro del marco manteniendo la geometría de la forma; este es un escenario habitual para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un video incrustado?**

Sí. Un video incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/video/#getContentType--) que puedes leer y utilizar, por ejemplo, al guardarlo en disco.