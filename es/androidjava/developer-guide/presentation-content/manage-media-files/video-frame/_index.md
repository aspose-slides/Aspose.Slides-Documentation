---
title: Administrar marcos de vídeo en presentaciones en Android
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
- marco de video
- fuente web
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Aprenda a añadir y extraer marcos de vídeo de forma programática en diapositivas PowerPoint y OpenDocument usando Aspose.Slides para Android mediante Java. Guía práctica y rápida."
---
## **Introducción**

Los videos pueden ayudar a explicar ideas y a captar la atención del público. Aspose.Slides for Android a través de Java le permite añadir marcos de vídeo a las diapositivas, ajustar la configuración de reproducción, gestionar subtítulos y extraer datos de vídeo incrustados.

PowerPoint admite videos locales y enlaces a videos en línea, como los videos de YouTube.

Para representar datos de vídeo y marcos de vídeo, Aspose.Slides proporciona la interfaz [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/), la interfaz [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) y otros tipos relevantes.

## **Crear un Marco de Vídeo Incorporado**

Si el archivo de vídeo que desea añadir a su diapositiva está almacenado localmente, puede crear un marco de vídeo para incrustar el vídeo en su presentación.

Este ejemplo incrusta un vídeo local en la primera diapositiva de una presentación existente y guarda el resultado. Las coordenadas y dimensiones del marco están en puntos. El flujo permanece abierto hasta que finaliza el guardado porque [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) lo mantiene bloqueado mientras la presentación lo utiliza.

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

También puede pasar una ruta de vídeo local directamente a [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Este ejemplo incrusta el vídeo en la primera diapositiva de una nueva presentación. El vídeo debe permanecer accesible hasta que la presentación se guarde.

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

## **Crear un Marco de Vídeo con Vídeo de una Fuente Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) admite videos en línea en las presentaciones. Puede crear un marco de vídeo que enlace a un video en línea, como un video de YouTube.

Este ejemplo añade un enlace y una miniatura de video de YouTube a la primera diapositiva. Reemplace el identificador del video para usar otro video. El método [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) solicita reproducción automática. Descargar la miniatura y reproducir el video requieren acceso a Internet. El visor de presentaciones también debe soportar la reproducción de videos en línea.

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

## **Reproducir un Vídeo en Modo Pantalla Completa**

En una presentación de formación, puede reproducir una demostración de software en modo pantalla completa para que el público vea los detalles. Llame a [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) con `true` para habilitar este comportamiento durante la reproducción.

Este ejemplo abre una presentación, encuentra el primer [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) en la primera diapositiva y habilita la reproducción en pantalla completa. La presentación de entrada debe contener al menos una diapositiva con un marco de vídeo existente en la primera diapositiva.

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

La reproducción en pantalla completa controla cómo se muestra el video. De forma independiente, [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) controla si se inicia automáticamente o al hacer clic, y [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) controla si se repite. Para elegir el comportamiento de inicio, establezca el modo de reproducción a [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/). El ejemplo conserva la configuración de inicio y bucle existentes.

## **Rebobinar un Vídeo Después de la Reproducción**

En una presentación de formación, devolver un video de demostración a su principio lo deja listo para que el presentador lo reproduzca nuevamente. Llame a [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) con `true` para devolver el video al inicio después de que finalice la reproducción.

Este ejemplo abre una presentación, encuentra el primer [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) en la primera diapositiva y habilita el rebobinado. Desactiva el bucle para que la reproducción pueda terminar y establece la reproducción para que se inicie al hacer clic. La presentación de entrada debe contener al menos una diapositiva con un marco de video existente en la primera diapositiva.

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

El rebobinado devuelve el video a su principio sin volver a iniciarlo. En contraste, llamar a [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) con `true` repite la reproducción automáticamente. Mantenga el bucle desactivado cuando desee que el video termine y quede listo para volver a reproducirlo. [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) controla de forma independiente el inicio automático o al hacer clic; este ejemplo usa [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) para que el presentador controle cuándo comienza la reproducción. Establezca el modo de reproducción después de la configuración del bucle, como se muestra en el ejemplo. El rebobinado funciona de forma independiente de [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Recortar un Marco de Vídeo**

Utilice [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) y [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) para omitir parte del comienzo o del final de un video durante la reproducción. Ambos valores están en milisegundos. Recortar cambia la configuración de reproducción sin modificar los datos del video incrustado.

**Establecer Configuraciones de Recorte**

Este ejemplo incrusta un video local y omite los primeros 2,5 segundos y el último segundo durante la reproducción. Use un video de más de 3,5 segundos para que quede un segmento reproducible.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Leer Configuraciones de Recorte**

Este ejemplo imprime los valores de recorte del primer marco de video en la primera diapositiva en milisegundos. La presentación debe contener al menos una diapositiva. Si esa diapositiva no tiene un marco de video, no se imprime nada. El ejemplo anterior produce valores de 2500 y 1000.

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

## **Gestionar Subtítulos de Vídeo**

Aspose.Slides le permite gestionar subtítulos cerrados para marcos de vídeo en presentaciones de PowerPoint. Los subtítulos se almacenan en formato WebVTT y se exponen mediante el método [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).

### **Añadir Subtítulos a un Marco de Vídeo**

Este ejemplo incrusta un video local y añade una pista de subtítulos WebVTT etiquetada como English. Las marcas de tiempo de los subtítulos deben coincidir con el video. La presentación guardada incluye tanto el video como sus subtítulos.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La interfaz [ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) también ofrece una sobrecarga que le permite añadir subtítulos desde un flujo.

### **Extraer Subtítulos de un Marco de Vídeo**

Este ejemplo guarda todas las pistas de subtítulos de los marcos de video en la primera diapositiva como archivos WebVTT separados. Los números secuenciales mantienen los archivos de salida distintos. La consola informa del número de pistas extraídas. La presentación debe contener al menos una diapositiva.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                try (FileOutputStream outputStream = new FileOutputStream("captions_" + trackCount + ".vtt")) {
                    outputStream.write(captionTrack.getBinaryData());
                }
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Cada objeto [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) expone el identificador del subtítulo, la etiqueta, los datos binarios y el texto del subtítulo como una cadena UTF‑8.

### **Eliminar Subtítulos de un Marco de Vídeo**

Este ejemplo elimina todos los subtítulos del marco de video situado en la primera posición de forma en la primera diapositiva y guarda el resultado. Se asume que la diapositiva y la forma existen y que la forma es un marco de video.

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

Si necesita eliminar solo una pista de subtítulos, utilice los métodos [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) o [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) en lugar de [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--).

### **Buscar Subtítulos de Vídeo**

[ICaptions.getDataAsString](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getDataAsString--) devuelve la pista completa WebVTT, incluyendo su encabezado, líneas de tiempo y texto del subtítulo. Puede buscar las señales en memoria para encontrar una frase hablada y su marca de tiempo. Por ejemplo, una pista en inglés en la diapositiva 2 podría contener el siguiente texto.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

El ejemplo abre `captioned_media.pptx` y usa [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) para leer las pistas de cada marco de video de nivel superior en cada diapositiva. En una señal de texto plano, la línea de tiempo contiene `-->` y una línea en blanco finaliza la señal. Cuando el subtítulo contiene “café” en cualquier combinación de mayúsculas/minúsculas, el ejemplo imprime el número de diapositiva, la etiqueta de la pista, la línea de tiempo original y el subtítulo completo.

```java
import com.aspose.slides.*;
import java.util.Locale;
import java.util.Scanner;

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
                        StringBuilder caption = new StringBuilder();
                        while (reader.hasNextLine()) {
                            String line = reader.nextLine();
                            if (line.isEmpty()) {
                                break;
                            }
                            if (caption.length() > 0) {
                                caption.append('\n');
                            }
                            caption.append(line);
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

## **Extraer Vídeo de una Diapositiva**

Además de añadir videos a las diapositivas, Aspose.Slides permite extraer los videos incrustados en presentaciones.

Este ejemplo extrae videos incrustados de cada diapositiva en archivos binarios numerados y separados. Los videos vinculados se omiten porque no tienen datos incrustados. La consola muestra el tipo MIME de cada video y el recuento total. La salida utiliza la extensión genérica `.bin`; cambie la extensión para que coincida con el tipo de medio informado cuando sea necesario.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

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
                try (FileOutputStream outputStream = new FileOutputStream("extracted_video_" + videoCount + ".bin")) {
                    outputStream.write(video.getBinaryData());
                }
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**¿Qué parámetros de reproducción de vídeo se pueden cambiar para un marco de vídeo?**

Puede controlar el [modo de reproducción](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (automático o al hacer clic) y el [bucle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Estas opciones están disponibles a través de los métodos del objeto [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/).

**¿Afecta la incorporación de un vídeo al tamaño del archivo PPTX?**

Sí. Cuando incrusta un video local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece en proporción al tamaño del archivo. Cuando enlaza a un video en línea y añade una miniatura, la presentación almacena el enlace y la imagen de vista previa en lugar de los datos del video, de modo que el aumento de tamaño suele ser menor.

**¿Puedo reemplazar el vídeo en un marco de vídeo existente sin cambiar su posición y tamaño?**

Sí. Puede intercambiar el [contenido del video](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) dentro del marco mientras conserva la geometría de la forma; es un escenario habitual para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un vídeo incrustado?**

Sí. Un video incrustado posee un [tipo de contenido](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) que puede leer y utilizar, por ejemplo, al guardarlo en disco.