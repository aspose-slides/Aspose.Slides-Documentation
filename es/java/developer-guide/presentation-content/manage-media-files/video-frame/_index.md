---
title: Gestionar marcos de video en presentaciones con Java
linktitle: Marco de video
type: docs
weight: 10
url: /es/java/video-frame/
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
- Java
- Aspose.Slides
description: "Aprenda a añadir y extraer programáticamente marcos de video en diapositivas PowerPoint y OpenDocument usando Aspose.Slides para Java. Guía práctica rápida."
---
## **Introducción**

Los videos pueden ayudar a explicar ideas y captar la atención del público. Aspose.Slides for Java permite añadir marcos de video a las diapositivas, ajustar la configuración de reproducción, gestionar subtítulos y extraer datos de video incrustados.

PowerPoint admite videos locales y enlaces a videos en línea, como videos de YouTube.

Para representar datos de video y marcos de video, Aspose.Slides proporciona la interfaz [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) la interfaz [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) y otros tipos relevantes.

## **Crear un marco de video incrustado**

Si el archivo de video que deseas añadir a tu diapositiva está almacenado localmente, puedes crear un marco de video para incrustar el video en tu presentación.

Este ejemplo incrusta un video local en la primera diapositiva de una presentación existente y guarda el resultado. Las coordenadas y dimensiones del marco están en puntos. El flujo permanece abierto hasta que termina el guardado porque [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) lo mantiene bloqueado mientras la presentación lo usa.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.KeepLocked);
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

    presentation.save("embedded_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

También puedes pasar una ruta de video local directamente a [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Este ejemplo incrusta el video en la primera diapositiva de una presentación nueva. El video debe permanecer accesible hasta que se guarde la presentación.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Crear un marco de video con video de una fuente web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) admite videos en línea en presentaciones. Puedes crear un marco de video que enlace a un video en línea, como un video de YouTube.

Este ejemplo añade un enlace de video de YouTube y su miniatura a la primera diapositiva. Reemplaza el identificador del video para usar otro video. El método [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) solicita reproducción automática. Descargar la miniatura y reproducir el video requieren acceso a Internet. El visor de presentaciones también debe admitir la reproducción de video en línea.

```java
import com.aspose.slides.*;
import java.io.InputStream;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    String videoId = "aqz-KE-bpKQ";
    String videoUrl = "https://www.youtube.com/embed/" + videoId;
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    String thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    URL thumbnailLocation = new URL(thumbnailUrl);
    try (InputStream thumbnailStream = thumbnailLocation.openStream()) {
        IPPImage thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    }

    presentation.save("online_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Reproducir un video en modo pantalla completa**

En una presentación de formación, puedes reproducir una demostración de software en modo pantalla completa para que el público vea los detalles. Llama a [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) con `true` para habilitar este comportamiento durante la reproducción.

Este ejemplo abre una presentación, encuentra el primer [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) en la primera diapositiva y habilita la reproducción en pantalla completa. La presentación de entrada debe contener al menos una diapositiva con un marco de video existente en la primera diapositiva.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La reproducción en pantalla completa controla cómo se muestra el video. De forma independiente, [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) controla si se inicia automáticamente o al hacer clic, y [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) controla si se repite. Para elegir el comportamiento de inicio, establece el modo de reproducción a [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/). El ejemplo conserva la configuración existente de inicio y bucle.

## **Rebobinar un video después de la reproducción**

En una presentación de formación, devolver un video de demostración a su comienzo lo hace estar listo para que el presentador lo reproduzca de nuevo. Llama a [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) con `true` para devolver el video al principio después de que finalice la reproducción.

Este ejemplo abre una presentación, encuentra el primer [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) en la primera diapositiva y habilita el rebobinado. Desactiva el bucle para que la reproducción pueda terminar y configura la reproducción para iniciar al hacer clic. La presentación de entrada debe contener al menos una diapositiva con un marco de video existente en la primera diapositiva.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El rebobinado devuelve el video a su comienzo sin iniciarlo de nuevo. En cambio, llamar a [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) con `true` repite la reproducción automáticamente. Mantén el bucle desactivado cuando quieras que el video termine y permanezca listo para reproducirse nuevamente. [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) controla de forma independiente el inicio automático o al hacer clic; este ejemplo utiliza [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) para que el presentador controle cuándo empieza la reproducción. Establece el modo de reproducción después de la configuración del bucle, como se muestra en el ejemplo. El rebobinado funciona de forma independiente de [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Recortar un marco de video**

Utiliza [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) y [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) para omitir parte del inicio o del final de un video durante la reproducción. Ambos valores están en milisegundos. El recorte modifica la configuración de reproducción sin alterar los datos del video incrustado.

**Establecer la configuración de recorte**

Este ejemplo incrusta un video local y omite los primeros 2,5 segundos y el último segundo durante la reproducción. Utiliza un video de más de 3,5 segundos para que quede un segmento reproducible.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Leer la configuración de recorte**

Este ejemplo muestra los valores de recorte del primer marco de video en la primera diapositiva en milisegundos. La presentación debe contener al menos una diapositiva. Si esa diapositiva no tiene marco de video, no se imprime nada. El ejemplo anterior produce valores de 2500 y 1000.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            System.out.println("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            System.out.println("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Gestionar subtítulos de video**

Aspose.Slides permite gestionar subtítulos cerrados para los marcos de video en presentaciones de PowerPoint. Los subtítulos se guardan en formato WebVTT y se exponen mediante el método [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--).

**Añadir subtítulos a un marco de video**

Este ejemplo incrusta un video local y añade una pista de subtítulos WebVTT etiquetada English. Las marcas de tiempo de los subtítulos deben coincidir con el video. La presentación guardada incluye tanto el video como sus subtítulos.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La interfaz [ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) también ofrece una sobrecarga que permite añadir subtítulos desde un flujo.

**Extraer subtítulos de un marco de video**

Este ejemplo guarda todas las pistas de subtítulos de los marcos de video de la primera diapositiva como archivos WebVTT separados. Los números secuenciales mantienen los archivos de salida distintos. La consola informa del número de pistas extraídas. La presentación debe contener al menos una diapositiva.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                Path outputPath = Paths.get("captions_" + trackCount + ".vtt");
                Files.write(outputPath, captionTrack.getBinaryData());
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Cada objeto [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) expone el identificador del subtítulo, la etiqueta, los datos binarios y el texto del subtítulo como una cadena UTF-8.

**Eliminar subtítulos de un marco de video**

Este ejemplo elimina todos los subtítulos del marco de video en la primera posición de forma de la primera diapositiva y guarda el resultado. Supone que la diapositiva y la forma existen y que la forma es un marco de video.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si necesitas eliminar sólo una pista de subtítulos, utiliza los métodos [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) o [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) en lugar de [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--).

## **Extraer video de una diapositiva**

Además de añadir videos a las diapositivas, Aspose.Slides permite extraer videos incrustados en presentaciones.

Este ejemplo extrae los videos incrustados de cada diapositiva a archivos binarios numerados y separados. Los videos enlazados se omiten porque no tienen datos incrustados. La consola muestra el tipo MIME de cada video y el recuento total. La salida usa la extensión genérica `.bin`; cámbiala para que coincida con el tipo de medio informado cuando sea necesario.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation_with_videos.pptx");
try {
    int videoCount = 0;
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                IVideoFrame videoFrame = (IVideoFrame) shape;
                IVideo video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    System.out.println("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                Path outputPath = Paths.get("extracted_video_" + videoCount + ".bin");
                Files.write(outputPath, video.getBinaryData());
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Qué parámetros de reproducción de video se pueden cambiar para un marco de video?**

Puedes controlar el [playback mode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (automático o al hacer clic) y el [looping](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Estas opciones están disponibles a través de los métodos del objeto [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/).

**¿Afecta la adición de un video al tamaño del archivo PPTX?**

Sí. Cuando incrustas un video local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece proporcionalmente al tamaño del archivo. Cuando enlazas a un video en línea y añades una miniatura, la presentación guarda el enlace y la imagen de vista previa en lugar de los datos del video, por lo que el aumento de tamaño suele ser menor.

**¿Puedo reemplazar el video en un marco de video existente sin cambiar su posición y tamaño?**

Sí. Puedes intercambiar el [video content](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) dentro del marco mientras preservas la geometría de la forma; este es un escenario común para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un video incrustado?**

Sí. Un video incrustado tiene un [content type](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) que puedes leer y usar, por ejemplo al guardarlo en disco.