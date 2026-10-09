---
title: Gestionar marcos de vídeo en presentaciones en Android
linktitle: Marco de vídeo
type: docs
weight: 10
url: /es/androidjava/video-frame/
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
- Android
- Java
- Aspose.Slides
description: "Aprende a añadir y extraer programáticamente marcos de vídeo en diapositivas de PowerPoint y OpenDocument usando Aspose.Slides para Android vía Java. Guía práctica rápida."
---
## **Introducción**

Los vídeos pueden ayudar a explicar ideas y atraer a la audiencia. Aspose.Slides for Android via Java permite añadir marcos de vídeo a las diapositivas, ajustar la configuración de reproducción, gestionar subtítulos y extraer datos de vídeo incrustados.

PowerPoint admite vídeos locales y enlaces a vídeos en línea, como los vídeos de YouTube.

Para representar datos de vídeo y marcos de vídeo, Aspose.Slides proporciona la interfaz [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/), la interfaz [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) y otros tipos relevantes.

## **Crear un Marco de Vídeo Incrustado**

Si el archivo de vídeo que deseas añadir a tu diapositiva está almacenado localmente, puedes crear un marco de vídeo para incrustar el vídeo en tu presentación.

Este ejemplo incrusta un vídeo local en la primera diapositiva de una presentación existente y guarda el resultado. Las coordenadas y dimensiones del marco están en puntos. El flujo permanece abierto hasta que la guardado finaliza porque [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) lo mantiene bloqueado mientras la presentación lo utiliza.

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

También puedes pasar una ruta de vídeo local directamente a [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Este ejemplo incrusta el vídeo en la primera diapositiva de una nueva presentación. El vídeo debe permanecer accesible hasta que la presentación se guarde.

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

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) admite vídeos en línea en las presentaciones. Puedes crear un marco de vídeo que enlace a un vídeo en línea, como un vídeo de YouTube.

Este ejemplo añade un enlace y una miniatura de vídeo de YouTube a la primera diapositiva. Reemplaza el identificador del vídeo para usar otro vídeo. El método [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) solicita la reproducción automática. Descargar la miniatura y reproducir el vídeo requieren acceso a Internet. El visor de presentaciones también debe admitir la reproducción de vídeos en línea.

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

En una presentación de formación, puedes reproducir una demostración de software en modo pantalla completa para que la audiencia vea los detalles. Llama a [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) con `true` para habilitar este comportamiento durante la reproducción.

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

La reproducción en pantalla completa controla cómo se muestra el vídeo. De forma independiente, [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) controla si empieza automáticamente o al hacer clic, y [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) controla si se repite. Para elegir el comportamiento de inicio, establece el modo de reproducción a [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/). El ejemplo conserva los ajustes de inicio y de bucle existentes.

## **Retroceder un Vídeo Tras la Reproducción**

En una presentación de formación, devolver un vídeo de demostración a su inicio lo deja listo para que el presentador lo reproduzca de nuevo. Llama a [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) con `true` para devolver el vídeo al principio después de que finalice la reproducción.

Este ejemplo abre una presentación, encuentra el primer [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) en la primera diapositiva y habilita el retroceso. Desactiva el bucle para que la reproducción pueda terminar y establece la reproducción para iniciar al hacer clic. La presentación de entrada debe contener al menos una diapositiva con un marco de vídeo existente en la primera diapositiva.

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

Retroceder devuelve el vídeo a su inicio sin volver a iniciarlo. En contraste, llamar a [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) con `true` repite la reproducción automáticamente. Mantén el bucle desactivado cuando quieras que el vídeo termine y quede listo para reproducirlo de nuevo. [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) controla de forma independiente el inicio automático o al hacer clic; este ejemplo usa [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) para que el presentador controle cuándo empieza la reproducción. Establece el modo de reproducción después del ajuste de bucle, como se muestra en el ejemplo. El retroceso funciona de forma independiente de [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Recortar un Marco de Vídeo**

Utiliza [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) y [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) para omitir parte del inicio o del final de un vídeo durante la reproducción. Ambos valores están en milisegundos. El recorte modifica la configuración de reproducción sin alterar los datos del vídeo incrustado.

**Establecer Configuración de Recorte**

Este ejemplo incrusta un vídeo local y omite los primeros 2,5 segundos y el último segundo durante la reproducción. Utiliza un vídeo de más de 3,5 segundos para que quede un segmento reproducible.

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

**Leer Configuración de Recorte**

Este ejemplo muestra los valores de recorte del primer marco de vídeo en la primera diapositiva en milisegundos. La presentación debe contener al menos una diapositiva. Si esa diapositiva no tiene un marco de vídeo, no se muestra nada. El ejemplo anterior produce valores de 2500 y 1000.

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

Aspose.Slides le permite gestionar subtítulos cerrados para los marcos de vídeo en presentaciones de PowerPoint. Los subtítulos se almacenan en formato WebVTT y se exponen mediante el método [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).

**Añadir Subtítulos a un Marco de Vídeo**

Este ejemplo incrusta un vídeo local y añade una pista de subtítulos WebVTT etiquetada como English. Las marcas de tiempo de los subtítulos deben coincidir con el vídeo. La presentación guardada incluye tanto el vídeo como sus subtítulos.

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

La interfaz [ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) también proporciona una sobrecarga que permite añadir subtítulos desde un flujo.

**Extraer Subtítulos de un Marco de Vídeo**

Este ejemplo guarda todas las pistas de subtítulos de los marcos de vídeo en la primera diapositiva como archivos WebVTT separados. Los números secuenciales mantienen los archivos de salida distintos. La consola informa del número de pistas extraídas. La presentación debe contener al menos una diapositiva.

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

Cada objeto [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) expone el identificador del subtítulo, la etiqueta, los datos binarios y el texto del subtítulo como una cadena UTF-8.

**Eliminar Subtítulos de un Marco de Vídeo**

Este ejemplo elimina todos los subtítulos del marco de vídeo en la primera posición de forma de la primera diapositiva y guarda el resultado. Se asume que la diapositiva y la forma existen y que la forma es un marco de vídeo.

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

Si necesitas eliminar solo una pista de subtítulo, usa los métodos [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) o [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) en lugar de [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--).

## **Extraer Vídeo de una Diapositiva**

Además de añadir vídeos a las diapositivas, Aspose.Slides permite extraer los vídeos incrustados en presentaciones.

Este ejemplo extrae los vídeos incrustados de cada diapositiva en archivos binarios separados y numerados. Los vídeos enlazados se omiten porque no tienen datos incrustados. La consola muestra el tipo MIME de cada vídeo y el recuento total. La salida utiliza la extensión genérica `.bin`; cámbiala para que coincida con el tipo de medio reportado cuando sea necesario.

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

## **Preguntas frecuentes**

**¿Qué parámetros de reproducción de vídeo se pueden cambiar para un marco de vídeo?**

Puedes controlar el [modo de reproducción](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (automático o al hacer clic) y el [bucle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Estas opciones están disponibles a través de los métodos del objeto [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/).

**¿Afecta la adición de un vídeo al tamaño del archivo PPTX?**

Sí. Cuando incrustas un vídeo local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece proporcionalmente al tamaño del archivo. Cuando enlazas a un vídeo en línea y añades una miniatura, la presentación almacena el enlace y la imagen de vista previa en lugar de los datos del vídeo, por lo que el aumento de tamaño suele ser menor.

**¿Puedo sustituir el vídeo en un marco de vídeo existente sin cambiar su posición y tamaño?**

Sí. Puedes intercambiar el [contenido de vídeo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) dentro del marco manteniendo la geometría de la forma; este es un escenario común para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un vídeo incrustado?**

Sí. Un vídeo incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) que puedes leer y usar, por ejemplo al guardarlo en disco.