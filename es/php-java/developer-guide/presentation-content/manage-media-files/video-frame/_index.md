---
title: Gestionar fotogramas de video en presentaciones usando PHP
linktitle: Fotograma de video
type: docs
weight: 10
url: /es/php-java/video-frame/
keywords:
- añadir video
- crear video
- incrustar video
- extraer video
- recuperar video
- fotograma de video
- fuente web
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Aprenda a añadir y extraer programáticamente fotogramas de video en diapositivas PowerPoint y OpenDocument usando Aspose.Slides para PHP a través de Java. Guía rápida paso a paso."
---
## **Introducción**

Los videos pueden ayudar a explicar ideas y captar la atención de la audiencia. Aspose.Slides para PHP a través de Java le permite añadir fotogramas de video a las diapositivas, ajustar la configuración de reproducción, gestionar subtítulos y extraer datos de video incrustados.

PowerPoint admite videos locales y enlaces a videos en línea, como videos de YouTube.

Para representar datos de video y fotogramas de video, Aspose.Slides proporciona la clase [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/), la clase [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) y otros tipos relevantes.

## **Crear un fotograma de video incrustado**

Si el archivo de video que desea añadir a su diapositiva está almacenado localmente, puede crear un fotograma de video para incrustar el video en su presentación.

Este ejemplo incrusta un video local en la primera diapositiva de una presentación existente y guarda el resultado. Las coordenadas y dimensiones del fotograma están en puntos. El flujo permanece abierto hasta que se finaliza la guardado porque [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) lo mantiene bloqueado mientras la presentación lo utiliza.

```php
use aspose\slides\LoadingStreamBehavior;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $slide = $presentation->getSlides()->get_Item(0);

    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::KeepLocked);
    $slide->getShapes()->addVideoFrame(10, 10, 150, 250, $video);

    $presentation->save("embedded_video.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

También puede pasar la ruta de un video local directamente a [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame). Este ejemplo incrusta el video en la primera diapositiva de una nueva presentación. El video debe permanecer accesible hasta que la presentación se guarde.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addVideoFrame(50, 150, 300, 150, "video.avi");

    $presentation->save("video_from_path.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Crear un fotograma de video con video de una fuente web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) admite videos en línea en las presentaciones. Puede crear un fotograma de video que enlace a un video en línea, como un video de YouTube.

Este ejemplo añade un enlace a un video de YouTube y su miniatura en la primera diapositiva. Reemplace el identificador del video para usar otro video. El método [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) solicita la reproducción automática. Descargar la miniatura y reproducir el video requieren acceso a internet. El visor de la presentación también debe admitir la reproducción de videos en línea.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoId = "aqz-KE-bpKQ";
    $videoUrl = "https://www.youtube.com/embed/" . $videoId;
    $videoFrame = $slide->getShapes()->addVideoFrame(10, 10, 427, 240, $videoUrl);
    $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

    $thumbnailUrl = "https://img.youtube.com/vi/" . $videoId . "/hqdefault.jpg";
    $thumbnailLocation = new Java("java.net.URL", $thumbnailUrl);
    $thumbnailStream = $thumbnailLocation->openStream();
    try {
        $thumbnail = $presentation->getImages()->addImage($thumbnailStream);
        $videoFrame->getPictureFormat()->getPicture()->setImage($thumbnail);
    } finally {
        $thumbnailStream->close();
    }

    $presentation->save("online_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Reproducir un video en modo pantalla completa**

En una presentación de formación, puede reproducir una demostración de software en modo pantalla completa para que la audiencia vea los detalles. Llame a [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) con `true` para habilitar este comportamiento durante la reproducción.

Este ejemplo abre una presentación, encuentra el primer [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) en la primera diapositiva y habilita la reproducción en pantalla completa. La presentación de entrada debe contener al menos una diapositiva con un fotograma de video existente en la primera diapositiva.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setFullScreenMode(true);
            break;
        }
    }

    $presentation->save("full_screen_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La reproducción en pantalla completa controla cómo se muestra el video. De forma independiente, [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) controla si se inicia automáticamente o al hacer clic, y [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) controla si se repite. Para elegir el comportamiento de inicio, establezca el modo de reproducción a [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/). El ejemplo conserva los ajustes de inicio y bucle existentes.

## **Rebobinar un video después de la reproducción**

En una presentación de formación, devolver un video de demostración a su comienzo lo deja listo para que el presentador lo reproduzca de nuevo. Llame a [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) con `true` para devolver el video al principio después de que la reproducción finalice.

Este ejemplo abre una presentación, encuentra el primer [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) en la primera diapositiva y habilita el rebobinado. Desactiva el bucle para que la reproducción pueda finalizar y establece la reproducción para que comience al hacer clic. La presentación de entrada debe contener al menos una diapositiva con un fotograma de video existente en la primera diapositiva.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setRewindVideo(true);
            $videoFrame->setPlayLoopMode(false);
            $videoFrame->setPlayMode(VideoPlayModePreset::OnClick);
            break;
        }
    }

    $presentation->save("rewind_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El rebobinado devuelve el video a su comienzo sin iniciarlo de nuevo. En cambio, llamar a [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) con `true` repite la reproducción automáticamente. Mantenga el bucle desactivado cuando desee que el video finalice y quede listo para reproducirse nuevamente. [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) controla de forma independiente el inicio automático o al hacer clic; este ejemplo usa [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) para que el presentador controle cuándo comienza la reproducción. Establezca el modo de reproducción después del ajuste de bucle, como se muestra en el ejemplo. El rebobinado funciona de manera independiente de [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode).

## **Recortar un fotograma de video**

Utilice [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) y [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) para omitir parte del principio o del final de un video durante la reproducción. Ambos valores están en milisegundos. El recorte modifica la configuración de reproducción sin alterar los datos del video incrustado.

**Establecer ajustes de recorte**

Este ejemplo incrusta un video local y omite los primeros 2,5 segundos y el último segundo durante la reproducción. Utilice un video de más de 3,5 segundos para que quede un segmento reproducible.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);
    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Leer ajustes de recorte**

Este ejemplo muestra los valores de recorte del primer fotograma de video en la primera diapositiva en milisegundos. La presentación debe contener al menos una diapositiva. Si esa diapositiva no tiene fotograma de video, no se muestra nada. El ejemplo anterior genera valores de 2500 y 1000.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            echo "Trim from start: " . java_values($videoFrame->getTrimFromStart()) . " ms\n";
            echo "Trim from end: " . java_values($videoFrame->getTrimFromEnd()) . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Gestionar subtítulos de video**

Aspose.Slides le permite gestionar subtítulos cerrados para los fotogramas de video en presentaciones de PowerPoint. Los subtítulos se almacenan en formato WebVTT y se exponen mediante el método [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks).

**Añadir subtítulos a un fotograma de video**

Este ejemplo incrusta un video local y añade una pista de subtítulos WebVTT etiquetada como English. Las marcas de tiempo de los subtítulos deben coincidir con el video. La presentación guardada incluye tanto el video como sus subtítulos.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La clase [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) también ofrece una sobrecarga que le permite añadir subtítulos desde un flujo.

**Extraer subtítulos de un fotograma de video**

Este ejemplo guarda todas las pistas de subtítulos de los fotogramas de video en la primera diapositiva como archivos WebVTT separados. Los números secuenciales mantienen los archivos de salida distintos. La consola informa del número de pistas extraídas. La presentación debe contener al menos una diapositiva.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $trackCount = 0;
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $captionCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $captionCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                $trackCount++;
                $outputStream = new Java("java.io.FileOutputStream", "captions_" . $trackCount . ".vtt");
                try {
                    $outputStream->write($captionTrack->getBinaryData());
                } finally {
                    $outputStream->close();
                }
            }
        }
    }

    echo "Caption tracks extracted: " . $trackCount . "\n";
} finally {
    $presentation->dispose();
}
```

Cada objeto [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) expone el identificador del subtítulo, la etiqueta, los datos binarios y el texto del subtítulo como una cadena UTF‑8.

**Eliminar subtítulos de un fotograma de video**

Este ejemplo elimina todos los subtítulos del fotograma de video en la primera posición de forma de la primera diapositiva y guarda el resultado. Se asume que la diapositiva y la forma existen y que la forma es un fotograma de video.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFrame = $slide->getShapes()->get_Item(0);
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Si necesita eliminar solo una pista de subtítulos, use los métodos [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) o [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) en lugar de [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear).

## **Extraer video de una diapositiva**

Además de añadir videos a las diapositivas, Aspose.Slides permite extraer videos incrustados en las presentaciones.

Este ejemplo extrae los videos incrustados de cada diapositiva en archivos binarios numerados y separados. Los videos vinculados se omiten porque no tienen datos incrustados. La consola muestra el tipo MIME de cada video y el recuento total. La salida utiliza la extensión genérica `.bin`; cámbiela para que coincida con el tipo de medio reportado cuando sea necesario.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_videos.pptx");
try {
    $videoCount = 0;
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $videoFrame = $shape;
                $video = $videoFrame->getEmbeddedVideo();
                if (java_is_null($video)) {
                    echo "Skipped a linked video: no embedded data is available.\n";
                    continue;
                }

                $videoCount++;
                $outputStream = new Java("java.io.FileOutputStream", "extracted_video_" . $videoCount . ".bin");
                try {
                    $outputStream->write($video->getBinaryData());
                } finally {
                    $outputStream->close();
                }
                echo "Video " . $videoCount . ": " . java_values($video->getContentType()) . "\n";
            }
        }
    }

    echo "Embedded videos extracted: " . $videoCount . "\n";
} finally {
    $presentation->dispose();
}
```

## **Preguntas frecuentes**

**¿Qué parámetros de reproducción de video se pueden cambiar en un fotograma de video?**

Puede controlar el [modo de reproducción](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (automático o al hacer clic) y el [bucle](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode). Estas opciones están disponibles a través de los métodos del objeto [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).

**¿Afecta la adición de un video al tamaño del archivo PPTX?**

Sí. Cuando incrusta un video local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece en proporción al tamaño del archivo. Cuando enlaza a un video en línea y añade una miniatura, la presentación almacena el enlace y la imagen de vista previa en lugar de los datos del video, por lo que el aumento de tamaño suele ser menor.

**¿Puedo sustituir el video en un fotograma de video existente sin cambiar su posición ni su tamaño?**

Sí. Puede intercambiar el [contenido del video](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) dentro del fotograma sin alterar la geometría de la forma; este es un escenario habitual para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un video incrustado?**

Sí. Un video incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType) que puede leer y utilizar, por ejemplo al guardarlo en disco.