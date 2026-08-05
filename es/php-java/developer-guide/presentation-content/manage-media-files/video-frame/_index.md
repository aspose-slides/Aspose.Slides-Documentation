---
title: Gestionar marcos de vídeo en presentaciones usando PHP
linktitle: Marco de vídeo
type: docs
weight: 10
url: /es/php-java/video-frame/
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
- PHP
- Aspose.Slides
description: "Aprenda a añadir y extraer programáticamente marcos de vídeo en diapositivas PowerPoint y OpenDocument usando Aspose.Slides para PHP mediante Java. Guía práctica y rápida."
---
## **Introducción**

Un vídeo bien colocado en una presentación puede hacer que su mensaje sea más persuasivo y aumentar los niveles de compromiso con su audiencia. 

PowerPoint permite agregar vídeos a una diapositiva en una presentación de dos formas:

* Añadir o incrustar un vídeo local (almacenado en su equipo)
* Añadir un vídeo en línea (desde una fuente web como YouTube).

Para permitirle añadir vídeos (objetos de vídeo) a una presentación, Aspose.Slides proporciona la clase [Video](https://reference.aspose.com/slides/es/php-java/aspose.slides/video/), la clase [VideoFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/) y otros tipos relevantes.

## **Crear marcos de vídeo incrustados**

Si el archivo de vídeo que desea añadir a su diapositiva está almacenado localmente, puede crear un marco de vídeo para incrustar el vídeo en su presentación. 

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
1. Obtenga la referencia de una diapositiva mediante su índice. 
1. Añada un objeto [Video](https://reference.aspose.com/slides/es/php-java/aspose.slides/video/) y pase la ruta del archivo de vídeo para incrustar el vídeo en la presentación.
1. Añada un objeto [VideoFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/) para crear un marco para el vídeo.
1. Guarde la presentación modificada. 

```php
  # Instancia la clase Presentation
  $pres = new Presentation("pres.pptx");
  try {
    # Carga el vídeo
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Obtiene la primera diapositiva y añade un marco de vídeo
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # Guarda la presentación en disco
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Alternativamente, puede añadir un vídeo pasando directamente su ruta de archivo al método [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapecollection/addvideoframe/) :

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $vf = $sld->getShapes()->addVideoFrame(50, 150, 300, 150, "video1.avi");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Crear marcos de vídeo con vídeo de fuentes web**

Microsoft [PowerPoint 2013 y versiones posteriores](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) admiten vídeos de YouTube en presentaciones. Si el vídeo que desea usar está disponible en línea (p. ej., en YouTube), puede añadirlo a su presentación mediante su enlace web. 

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
1. Obtenga la referencia de una diapositiva mediante su índice. 
1. Añada un objeto [Video](https://reference.aspose.com/slides/es/php-java/aspose.slides/video/) y pase el enlace al vídeo.
1. Establezca una miniatura para el marco de vídeo. 
1. Guarde la presentación. 

```php
  # Instancia un objeto Presentation que representa un archivo de presentación
  $pres = new Presentation();
  try {
    addVideoFromYouTube($pres, "Tj75Arhq5ho");
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```

## **Recortar un marco de vídeo**

Aspose.Slides le permite controlar qué parte de un vídeo se reproduce estableciendo los valores trim-from-start y trim-from-end mediante [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/#setTrimFromStart) y [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/#setTrimFromEnd). Ambos valores se especifican en milisegundos y definen cuánto tiempo se salta al principio y al final del vídeo, respectivamente. Estos ajustes modifican la configuración de reproducción del vídeo en la presentación; no recortan ni alteran de otra forma los datos binarios del vídeo incrustado.

**Establecer ajustes de recorte**

Para crear un marco de vídeo y establecer sus ajustes de recorte:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
1. Añada un objeto [Video](https://reference.aspose.com/slides/es/php-java/aspose.slides/video/) a la presentación.
1. Añada un objeto [VideoFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/) a una diapositiva.
1. Establezca los valores trim-from-start y trim-from-end mediante [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/#setTrimFromStart) y [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/#setTrimFromEnd).
1. Guarde la presentación modificada.

```php
$presentation = new Presentation();
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $video = $presentation->getVideos()->addVideo(
        $videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);

    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

**Leer ajustes de recorte**

Para inspeccionar los ajustes de recorte existentes, cargue una presentación, encuentre un objeto [VideoFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/) entre las formas de la primera diapositiva y lea los valores mediante [VideoFrame::getTrimFromStart](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/#getTrimFromStart) y [VideoFrame::getTrimFromEnd](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/#getTrimFromEnd).

```php
$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trimFromStart = java_values($videoFrame->getTrimFromStart());
            $trimFromEnd = java_values($videoFrame->getTrimFromEnd());

            echo "Trim from start: " . $trimFromStart . " ms\n";
            echo "Trim from end: " . $trimFromEnd . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Gestionar subtítulos de vídeo**

Aspose.Slides le permite gestionar los subtítulos cerrados para los marcos de vídeo en presentaciones de PowerPoint. Los subtítulos se almacenan en formato WebVTT y se exponen mediante el método [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/#getCaptionTracks).

**Añadir subtítulos a un marco de vídeo**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
1. Añada un vídeo a la presentación.
1. Añada un objeto [VideoFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/) a una diapositiva.
1. Utilice la colección [CaptionsCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/captionscollection/) devuelta por [getCaptionTracks](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/#getCaptionTracks) para añadir una pista de subtítulos WebVTT.
1. Guarde la presentación modificada.

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // Añade una nueva pista de subtítulos desde un archivo WebVTT.
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La clase [CaptionsCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/captionscollection/) también ofrece una sobrecarga que le permite añadir subtítulos desde un flujo.

**Extraer subtítulos de un marco de vídeo**

1. Cargue la presentación que contiene el vídeo.
1. Encuentre el objeto [VideoFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/) objetivo.
1. Itere a través de la colección [getCaptionTracks](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/#getCaptionTracks).
1. Guarde cada pista de subtítulos en un archivo `.vtt`.

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trackCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                // Guarda la pista de subtítulos en un archivo WebVTT.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Cada objeto [Captions](https://reference.aspose.com/slides/es/php-java/aspose.slides/captions/) expone el identificador del subtítulo, la etiqueta, los datos binarios y el texto del subtítulo como una cadena UTF-8.

**Eliminar subtítulos de un marco de vídeo**

1. Cargue la presentación que contiene el vídeo.
1. Obtenga el objeto [VideoFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/) objetivo.
1. Elimine las pistas de subtítulos de la colección [getCaptionTracks](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/#getCaptionTracks).
1. Guarde la presentación modificada.

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // tipo: VideoFrame

    // Elimina todos los subtítulos del marco de vídeo.
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Si necesita eliminar solo una pista de subtítulos, utilice los métodos [remove](https://reference.aspose.com/slides/es/php-java/aspose.slides/captionscollection/#remove) o [removeAt](https://reference.aspose.com/slides/es/php-java/aspose.slides/captionscollection/#removeAt) en lugar de [clear](https://reference.aspose.com/slides/es/php-java/aspose.slides/captionscollection/#clear).

## **Extraer vídeo de diapositivas**

Además de añadir vídeos a diapositivas, Aspose.Slides le permite extraer los vídeos incrustados en presentaciones.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) para cargar la presentación que contiene el vídeo.
2. Itere a través de todos los objetos [Slide](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/).
3. Itere a través de todos los objetos [Shape](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/) para encontrar un [VideoFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/).
4. Guarde el vídeo en disco.

```php
  # Instancia un objeto Presentation que representa un archivo de presentación
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # Obtiene la extensión del archivo
          $charIndex = $type->indexOf("/");
          $type = $type->substring($charIndex + 1);
          $fop = new Java("java.io.FileOutputStream", "testing2." . $type);
          $fop->write($buffer);
          $fop->flush();
          $fop->close();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Preguntas frecuentes**

**¿Qué parámetros de reproducción de vídeo se pueden cambiar en un VideoFrame?**

Puede controlar el [playback mode](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/setplaymode/) (automático o al hacer clic) y el [looping](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/setplayloopmode/). Estas opciones están disponibles a través de las propiedades del objeto [VideoFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/).

**¿Afecta la incorporación de un vídeo al tamaño del archivo PPTX?**

Sí. Cuando incrusta un vídeo local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece en proporción al tamaño del archivo. Cuando añade un vídeo en línea, se incrustan un enlace y una miniatura, por lo que el aumento de tamaño es menor.

**¿Puedo reemplazar el vídeo en un VideoFrame existente sin cambiar su posición y tamaño?**

Sí. Puede intercambiar el [video content](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/setembeddedvideo/) dentro del marco manteniendo la geometría de la forma; este es un escenario habitual para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un vídeo incrustado?**

Sí. Un vídeo incrustado tiene un [content type](https://reference.aspose.com/slides/es/php-java/aspose.slides/video/getcontenttype/) que puede leer y utilizar, por ejemplo al guardarlo en disco.