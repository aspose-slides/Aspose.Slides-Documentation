---
title: Gestionar fotogramas de vídeo en presentaciones con Java
linktitle: Fotograma de vídeo
type: docs
weight: 10
url: /es/java/video-frame/
keywords:
- añadir vídeo
- crear vídeo
- incrustar vídeo
- extraer vídeo
- recuperar vídeo
- fotograma de vídeo
- fuente web
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Aprenda a añadir y extraer fotogramas de vídeo de forma programática en diapositivas PowerPoint y OpenDocument usando Aspose.Slides para Java. Guía rápida de cómo hacerlo."
---
## **Introducción**

Los vídeos pueden ayudar a explicar ideas y captar la atención de la audiencia. Aspose.Slides for Java le permite añadir fotogramas de vídeo a diapositivas, ajustar la configuración de reproducción, gestionar subtítulos y extraer datos de vídeo incrustados.

PowerPoint admite vídeos locales y enlaces a vídeos en línea, como los vídeos de YouTube.

Para representar datos de vídeo y fotogramas de vídeo, Aspose.Slides proporciona la interfaz [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) , la interfaz [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) y otros tipos relevantes.

## **Crear un fotograma de vídeo incrustado**

Si el archivo de vídeo que desea añadir a su diapositiva está almacenado localmente, puede crear un fotograma de vídeo para incrustar el vídeo en su presentación.

Este ejemplo incrusta un vídeo local en la primera diapositiva de una presentación existente y guarda el resultado. Las coordenadas y dimensiones del fotograma están en puntos. El flujo permanece abierto hasta que finaliza el guardado porque [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) lo mantiene bloqueado mientras la presentación lo utiliza.

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

También puede pasar la ruta de un vídeo local directamente a [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Este ejemplo incrusta el vídeo en la primera diapositiva de una presentación nueva. El vídeo debe permanecer accesible hasta que la presentación se guarde.

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

## **Crear un fotograma de vídeo con vídeo de una fuente web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) admite vídeos en línea en las presentaciones. Puede crear un fotograma de vídeo que enlaza a un vídeo en línea, como un vídeo de YouTube.

Este ejemplo añade un enlace a un vídeo de YouTube y una miniatura a la primera diapositiva. Reemplace el identificador del vídeo para usar otro vídeo. El método [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) solicita la reproducción automática. Descargar la miniatura y reproducir el vídeo requiere acceso a Internet. El visor de presentaciones también debe admitir la reproducción de vídeo en línea.

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

## **Reproducir un vídeo en modo pantalla completa**

En una presentación de formación, puede reproducir una demostración de software en modo pantalla completa para que la audiencia vea los detalles. Llame a [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) con `true` para habilitar este comportamiento durante la reproducción.

Este ejemplo abre una presentación, busca el primer [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) en la primera diapositiva y habilita la reproducción en pantalla completa. La presentación de entrada debe contener al menos una diapositiva con un fotograma de vídeo existente en la primera diapositiva.

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

La reproducción en pantalla completa controla cómo se muestra el vídeo. De forma independiente, [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) controla si se inicia automáticamente o al hacer clic, y [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) controla si se repite. Para elegir el comportamiento de inicio, establezca el modo de reproducción a [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/). El ejemplo conserva la configuración de inicio y bucle existentes.

## **Retroceder un vídeo después de la reproducción**

En una presentación de formación, volver al principio de un vídeo de demostración lo deja listo para que el presentador lo reproduzca nuevamente. Llame a [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) con `true` para devolver el vídeo al comienzo después de que finalice la reproducción.

Este ejemplo abre una presentación, busca el primer [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) en la primera diapositiva y habilita el rebobinado. Deshabilita el bucle para que la reproducción pueda terminar y establece la reproducción para que inicie al hacer clic. La presentación de entrada debe contener al menos una diapositiva con un fotograma de vídeo existente en la primera diapositiva.

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

El rebobinado devuelve el vídeo a su inicio sin volver a iniciarlo. En contraste, llamar a [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) con `true` repite la reproducción automáticamente. Mantenga el bucle desactivado cuando quiera que el vídeo termine y quede listo para reproducirse de nuevo. [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) controla de forma independiente el inicio automático o al hacer clic; este ejemplo usa [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) para que el presentador controle cuándo empieza la reproducción. Establezca el modo de reproducción después de la configuración del bucle, como se muestra en el ejemplo. El rebobinado funciona de forma independiente de [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Recortar un fotograma de vídeo**

Utilice [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) y [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) para omitir parte del inicio o del final de un vídeo durante la reproducción. Ambos valores están en milisegundos. El recorte cambia la configuración de reproducción sin modificar los datos de vídeo incrustados.

**Establecer la configuración de recorte**

Este ejemplo incrusta un vídeo local y omite los primeros 2,5 segundos y el último segundo durante la reproducción. Utilice un vídeo de más de 3,5 segundos para que quede un segmento reproducible.

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

Este ejemplo muestra los valores de recorte del primer fotograma de vídeo en la primera diapositiva en milisegundos. La presentación debe contener al menos una diapositiva. Si esa diapositiva no tiene fotograma de vídeo, no se mostrará nada. El ejemplo anterior produce valores de 2500 y 1000.

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

## **Gestionar subtítulos de vídeo**

Aspose.Slides permite gestionar subtítulos cerrados para los fotogramas de vídeo en presentaciones de PowerPoint. Los subtítulos se almacenan en formato WebVTT y se exponen mediante el método [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--).

### **Añadir subtítulos a un fotograma de vídeo**

Este ejemplo incrusta un vídeo local y añade una pista de subtítulos WebVTT etiquetada como English. Las marcas de tiempo de los subtítulos deben coincidir con el vídeo. La presentación guardada incluye tanto el vídeo como sus subtítulos.

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

La interfaz [ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) también proporciona una sobrecarga que permite añadir subtítulos desde un flujo.

### **Extraer subtítulos de un fotograma de vídeo**

Este ejemplo guarda todas las pistas de subtítulos de los fotogramas de vídeo en la primera diapositiva como archivos WebVTT separados. Los números secuenciales mantienen los archivos de salida distintos. La consola informa del número de pistas extraídas. La presentación debe contener al menos una diapositiva.

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

Cada objeto [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) expone el identificador del subtítulo, la etiqueta, los datos binarios y el texto del subtítulo como una cadena UTF‑8.

### **Eliminar subtítulos de un fotograma de vídeo**

Este ejemplo elimina todos los subtítulos del fotograma de vídeo en la primera posición de forma en la primera diapositiva y guarda el resultado. Se asume que la diapositiva y la forma existen y que la forma es un fotograma de vídeo.

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

Si necesita eliminar solo una pista de subtítulos, utilice los métodos [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) o [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) en lugar de [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--).

### **Buscar subtítulos de vídeo**

[ICaptions.getDataAsString](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getDataAsString--) devuelve la pista completa WebVTT, incluido su encabezado, líneas de tiempo y texto del subtítulo. Puede buscar las señales en memoria para encontrar una frase hablada y su marca de tiempo. Por ejemplo, una pista en inglés en la diapositiva 2 podría contener el siguiente texto.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

El ejemplo abre `captioned_media.pptx` y utiliza [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) para leer las pistas de cada fotograma de vídeo de nivel superior en todas las diapositivas. En una señal de texto sin formato, la línea de tiempo contiene `-->`, y una línea en blanco finaliza la señal. Cuando el subtítulo contiene la palabra “café” en cualquier combinación de mayúsculas y minúsculas, el ejemplo muestra el número de diapositiva, la etiqueta de la pista, la línea de tiempo original y el subtítulo completo.

```java
import com.aspose.slides.*;
import java.util.Locale;
import java.util.Scanner;
import java.util.StringJoiner;

Presentation presentation = new Presentation("captioned_media.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IVideoFrame)) {
                continue;
            }
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions track : videoFrame.getCaptionTracks()) {
                try (Scanner reader = new Scanner(track.getDataAsString())) {
                    while (reader.hasNextLine()) {
                        String timing = reader.nextLine();
                        if (!timing.contains("-->")) {
                            continue;
                        }
                        StringJoiner caption = new StringJoiner(System.lineSeparator());
                        while (reader.hasNextLine()) {
                            String line = reader.nextLine();
                            if (line.isEmpty()) {
                                break;
                            }
                            caption.add(line);
                        }
                        if (caption.toString().toLowerCase(Locale.ROOT).contains("café")) {
                            System.out.printf("Slide %d | %s | %s%n", slide.getSlideNumber(), track.getLabel(), timing);
                            System.out.println(caption);
                        }
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Buscar “café” produce una coincidencia para la pista de ejemplo. La búsqueda excluye el encabezado de la pista y conserva la configuración de tiempo en la salida.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Extraer vídeo de una diapositiva**

Además de añadir vídeos a las diapositivas, Aspose.Slides permite extraer los vídeos incrustados en presentaciones.

Este ejemplo extrae los vídeos incrustados de cada diapositiva en archivos binarios numerados por separado. Los vídeos enlazados se omiten porque no tienen datos incrustados. La consola muestra el tipo MIME de cada vídeo y el recuento total. La salida usa la extensión genérica `.bin`; cámbiela para que coincida con el tipo de medio informado cuando sea necesario.

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

**¿Qué parámetros de reproducción de vídeo se pueden cambiar en un fotograma de vídeo?**

Puede controlar el [modo de reproducción](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (automático o al hacer clic) y el [bucle](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Estas opciones están disponibles mediante los métodos del objeto [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/).

**¿Aumenta el tamaño del archivo PPTX al añadir un vídeo?**

Sí. Cuando incrusta un vídeo local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece en proporción al tamaño del archivo. Cuando enlaza a un vídeo en línea y añade una miniatura, la presentación guarda el enlace y la imagen de vista previa en lugar de los datos del vídeo, por lo que el aumento de tamaño suele ser menor.

**¿Puedo reemplazar el vídeo en un fotograma de vídeo existente sin cambiar su posición y tamaño?**

Sí. Puede intercambiar el [contenido del vídeo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) dentro del fotograma manteniendo la geometría de la forma; este es un escenario común para actualizar medios en un diseño ya existente.

**¿Se puede determinar el tipo de contenido (MIME) de un vídeo incrustado?**

Sí. Un vídeo incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) que puede leer y usar, por ejemplo, al guardarlo en disco.