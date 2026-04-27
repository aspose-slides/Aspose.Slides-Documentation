---
title: Gestionar marcos de vídeo en presentaciones utilizando Java
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
description: Aprenda a añadir y extraer programáticamente marcos de vídeo en diapositivas de PowerPoint y OpenDocument usando Aspose.Slides para Java. Guía práctica rápida.
---
Un vídeo bien colocado en una presentación puede hacer que su mensaje sea más convincente y aumentar los niveles de participación de la audiencia. 

PowerPoint le permite añadir vídeos a una diapositiva de una presentación de dos maneras:

* Añadir o incrustar un vídeo local (almacenado en su equipo)
* Añadir un vídeo en línea (desde una fuente web como YouTube).

Para permitirle añadir vídeos (objetos de vídeo) a una presentación, Aspose.Slides proporciona la interfaz [IVideo](https://reference.aspose.com/slides/es/java/com.aspose.slides/ivideo/) , la interfaz [IVideoFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/ivideoframe/) y otros tipos relevantes. 

## **Crear marcos de vídeo incrustados**

Si el archivo de vídeo que desea añadir a su diapositiva está almacenado localmente, puede crear un marco de vídeo para incrustar el vídeo en su presentación. 

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/Presentation).
1. Obtenga la referencia de una diapositiva a través de su índice. 
1. Añada un objeto [IVideo](https://reference.aspose.com/slides/es/java/com.aspose.slides/ivideo/) y pase la ruta del archivo de vídeo para incrustar el vídeo en la presentación. 
1. Añada un objeto [IVideoFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/ivideoframe/) para crear un marco para el vídeo.  
1. Guarde la presentación modificada. 

Este código Java le muestra cómo añadir un vídeo almacenado localmente a una presentación:

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

Alternativamente, puede añadir un vídeo pasando directamente su ruta de archivo al método [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

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

Microsoft [PowerPoint 2013 y versiones posteriores](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) admite vídeos de YouTube en presentaciones. Si el vídeo que desea usar está disponible en línea (por ejemplo, en YouTube), puede añadirlo a su presentación mediante su enlace web. 

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/Presentation)
1. Obtenga la referencia de una diapositiva a través de su índice. 
1. Añada un objeto [IVideo](https://reference.aspose.com/slides/es/java/com.aspose.slides/ivideo/) y pase el enlace al vídeo.
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
    // Añade un videoFrame
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

## **Gestionar subtítulos de vídeo**

Aspose.Slides le permite gestionar subtítulos cerrados para marcos de vídeo en presentaciones de PowerPoint. Los subtítulos se almacenan en formato WebVTT y se exponen mediante el método [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/es/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**Añadir subtítulos a un marco de vídeo**

Para añadir subtítulos a un marco de vídeo:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) .
1. Añada un vídeo a la presentación.
1. Añada un objeto [IVideoFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/ivideoframe/) a una diapositiva.
1. Utilice la [ICaptionsCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/icaptionscollection/) devuelta por [getCaptionTracks](https://reference.aspose.com/slides/es/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) para añadir una pista de subtítulos WebVTT.
1. Guarde la presentación modificada.

El siguiente código le muestra cómo añadir subtítulos a un marco de vídeo:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
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

La interfaz [ICaptionsCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/icaptionscollection/) también proporciona una sobrecarga que permite añadir subtítulos desde un flujo.

**Extraer subtítulos de un marco de vídeo**

Para extraer subtítulos de un marco de vídeo:

1. Cargue la presentación que contiene el vídeo.
1. Encuentre el objeto [IVideoFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/ivideoframe/) objetivo.
1. Itere a través de las pistas de subtítulos en la [ICaptionsCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/icaptionscollection/) .
1. Guarde cada pista de subtítulos en un archivo `.vtt`.

El siguiente código le muestra cómo extraer subtítulos de un marco de vídeo:

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

Cada objeto [ICaptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/icaptions/) expone el identificador del subtítulo, la etiqueta, los datos binarios y el texto del subtítulo como una cadena UTF-8.

**Eliminar subtítulos de un marco de vídeo**

Para eliminar subtítulos de un marco de vídeo:

1. Cargue la presentación que contiene el vídeo.
1. Obtenga el objeto [IVideoFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/ivideoframe/) objetivo.
1. Elimine las pistas de subtítulos de la [ICaptionsCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/icaptionscollection/) .
1. Guarde la presentación modificada.

El siguiente código le muestra cómo eliminar todos los subtítulos de un marco de vídeo:

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

Si necesita eliminar solo una pista de subtítulos, utilice los métodos [remove](https://reference.aspose.com/slides/es/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) o [removeAt](https://reference.aspose.com/slides/es/java/com.aspose.slides/icaptionscollection/#removeAt-int-) en lugar de [clear](https://reference.aspose.com/slides/es/java/com.aspose.slides/icaptionscollection/#clear--) .

## **Extraer vídeo de diapositivas**

Además de añadir vídeos a las diapositivas, Aspose.Slides le permite extraer los vídeos incrustados en presentaciones.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/Presentation) para cargar la presentación que contiene el vídeo. 
2. Itere a través de todos los objetos [ISlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/islide/) .
3. Itere a través de todos los objetos [IShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/) para encontrar un [VideoFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/videoframe/) . 
4. Guarde el vídeo en el disco.

Este código Java le muestra cómo extraer el vídeo de una diapositiva de presentación:

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

**¿Qué parámetros de reproducción de vídeo pueden modificarse en un VideoFrame?**

Puede controlar el [modo de reproducción](https://reference.aspose.com/slides/es/java/com.aspose.slides/videoframe/#setPlayMode-int-) (automático o con clic) y el [bucle](https://reference.aspose.com/slides/es/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Estas opciones están disponibles a través de las propiedades del objeto [VideoFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/videoframe/) .

**¿Afecta la incorporación de un vídeo al tamaño del archivo PPTX?**

Sí. Cuando incrusta un vídeo local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece proporcionalmente al tamaño del archivo. Cuando añade un vídeo en línea, se incrustan un enlace y una miniatura, por lo que el aumento de tamaño es menor.

**¿Puedo sustituir el vídeo en un VideoFrame existente sin cambiar su posición y tamaño?**

Sí. Puede intercambiar el [contenido del vídeo](https://reference.aspose.com/slides/es/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) dentro del marco conservando la geometría de la forma; este es un escenario habitual para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un vídeo incrustado?**

Sí. Un vídeo incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/es/java/com.aspose.slides/video/#getContentType--) que puede leer y utilizar, por ejemplo al guardarlo en el disco.