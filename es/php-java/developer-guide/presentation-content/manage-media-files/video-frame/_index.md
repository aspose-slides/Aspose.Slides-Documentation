---
title: Gestionar fotogramas de vídeo en presentaciones usando PHP
linktitle: Fotograma de vídeo
type: docs
weight: 10
url: /es/php-java/video-frame/
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
- PHP
- Aspose.Slides
description: "Aprende a añadir y extraer programáticamente fotogramas de vídeo en diapositivas de PowerPoint y OpenDocument usando Aspose.Slides para PHP a través de Java. Guía práctica rápida."
---
Un vídeo bien colocado en una presentación puede hacer que tu mensaje sea más convincente y aumentar los niveles de compromiso con tu audiencia. 

PowerPoint permite añadir vídeos a una diapositiva de una presentación de dos maneras:

* Añadir o incrustar un vídeo local (almacenado en tu máquina)
* Añadir un vídeo en línea (desde una fuente web como YouTube).

Para permitirte añadir vídeos (objetos de vídeo) a una presentación, Aspose.Slides proporciona la clase [Video](https://reference.aspose.com/slides/es/php-java/aspose.slides/video/), la clase [VideoFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/) y otros tipos pertinentes.

## **Crear fotogramas de vídeo incrustados**

Si el archivo de vídeo que deseas añadir a tu diapositiva está almacenado localmente, puedes crear un fotograma de vídeo para incrustar el vídeo en tu presentación. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
1. Obtén la referencia a una diapositiva mediante su índice. 
1. Añade un objeto [Video](https://reference.aspose.com/slides/es/php-java/aspose.slides/video/) y pasa la ruta del archivo de vídeo para incrustar el vídeo en la presentación.
1. Añade un objeto [VideoFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/) para crear un fotograma para el vídeo.
1. Guarda la presentación modificada. 

Este código PHP muestra cómo añadir un vídeo almacenado localmente a una presentación:

```php
  # Instancia la clase Presentation
  $pres = new Presentation("pres.pptx");
  try {
    # Carga el vídeo
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Obtiene la primera diapositiva y añade un fotograma de vídeo
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

Alternativamente, puedes añadir un vídeo pasando directamente su ruta de archivo al método [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapecollection/addvideoframe/):

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


## **Crear fotogramas de vídeo con vídeo de fuentes web**

Microsoft [PowerPoint 2013 y versiones posteriores](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) admite vídeos de YouTube en presentaciones. Si el vídeo que deseas usar está disponible en línea (p. ej., en YouTube), puedes añadirlo a tu presentación mediante su enlace web. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
1. Obtén la referencia a una diapositiva mediante su índice. 
1. Añade un objeto [Video](https://reference.aspose.com/slides/es/php-java/aspose.slides/video/) y pasa el enlace al vídeo.
1. Establece una miniatura para el fotograma de vídeo. 
1. Guarda la presentación. 

Este código PHP muestra cómo añadir un vídeo desde la web a una diapositiva en una presentación de PowerPoint:

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

## **Gestionar subtítulos de vídeo**

Aspose.Slides permite gestionar subtítulos cerrados para los fotogramas de vídeo en presentaciones de PowerPoint. Los subtítulos se almacenan en formato WebVTT y están expuestos mediante el método [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/#getCaptionTracks).

**Añadir subtítulos a un fotograma de vídeo**

Para añadir subtítulos a un fotograma de vídeo:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
1. Añade un vídeo a la presentación.
1. Añade un objeto [VideoFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/) a una diapositiva.
1. Utiliza la colección [CaptionsCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/captionscollection/) devuelta por [getCaptionTracks](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/#getCaptionTracks) para añadir una pista de subtítulos WebVTT.
1. Guarda la presentación modificada.

El siguiente código muestra cómo añadir subtítulos a un fotograma de vídeo:

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

La clase [CaptionsCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/captionscollection/) también proporciona una sobrecarga que permite añadir subtítulos desde un flujo.

**Extraer subtítulos de un fotograma de vídeo**

Para extraer subtítulos de un fotograma de vídeo:

1. Carga la presentación que contiene el vídeo.
1. Encuentra el objeto [VideoFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/) objetivo.
1. Recorre la colección [getCaptionTracks](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/#getCaptionTracks).
1. Guarda cada pista de subtítulos en un archivo `.vtt`.

El siguiente código muestra cómo extraer subtítulos de un fotograma de vídeo:

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

**Eliminar subtítulos de un fotograma de vídeo**

Para eliminar subtítulos de un fotograma de vídeo:

1. Carga la presentación que contiene el vídeo.
1. Obtén el objeto [VideoFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/) objetivo.
1. Elimina las pistas de subtítulos de la colección [getCaptionTracks](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/#getCaptionTracks).
1. Guarda la presentación modificada.

El siguiente código muestra cómo eliminar todos los subtítulos de un fotograma de vídeo:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // tipo: VideoFrame

    // Elimina todos los subtítulos del fotograma de vídeo.
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Si necesitas eliminar solo una pista de subtítulos, utiliza los métodos [remove](https://reference.aspose.com/slides/es/php-java/aspose.slides/captionscollection/#remove) o [removeAt](https://reference.aspose.com/slides/es/php-java/aspose.slides/captionscollection/#removeAt) en lugar de [clear](https://reference.aspose.com/slides/es/php-java/aspose.slides/captionscollection/#clear).

## **Extraer vídeo de diapositivas**

Además de añadir vídeos a diapositivas, Aspose.Slides permite extraer los vídeos incrustados en presentaciones.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) para cargar la presentación que contiene el vídeo.
2. Recorre todos los objetos [Slide](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/).
3. Recorre todos los objetos [Shape](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/) para encontrar un [VideoFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/).
4. Guarda el vídeo en disco.

Este código PHP muestra cómo extraer el vídeo de una diapositiva de presentación:

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

Puedes controlar el [modo de reproducción](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/setplaymode/) (automático o al hacer clic) y el [bucle de reproducción](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/setplayloopmode/). Estas opciones están disponibles a través de las propiedades del objeto [VideoFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/).

**¿Afecta la adición de un vídeo al tamaño del archivo PPTX?**

Sí. Cuando incrustas un vídeo local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece en proporción al tamaño del archivo. Cuando añades un vídeo en línea, se incrustan un enlace y una miniatura, por lo que el aumento de tamaño es menor.

**¿Puedo sustituir el vídeo en un VideoFrame existente sin cambiar su posición y tamaño?**

Sí. Puedes intercambiar el [contenido del vídeo](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/setembeddedvideo/) dentro del fotograma conservando la geometría de la forma; este es un escenario habitual para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un vídeo incrustado?**

Sí. Un vídeo incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/es/php-java/aspose.slides/video/getcontenttype/) que puedes leer y usar, por ejemplo, al guardarlo en disco.