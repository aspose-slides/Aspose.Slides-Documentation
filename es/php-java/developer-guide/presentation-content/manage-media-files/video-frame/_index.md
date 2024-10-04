---
title: Marco de Video
type: docs
weight: 10
url: /php-java/video-frame/
keywords: "Agregar video, crear marco de video, extraer video, presentación de PowerPoint, Java, Aspose.Slides para PHP a través de Java"
description: "Agregar marco de video a la presentación de PowerPoint"
---

Un video bien colocado en una presentación puede hacer que tu mensaje sea más convincente y aumentar los niveles de compromiso con tu audiencia.

PowerPoint te permite agregar videos a una diapositiva en una presentación de dos maneras:

* Agregar o incrustar un video local (almacenado en tu máquina)
* Agregar un video en línea (de una fuente web como YouTube).

Para permitirte agregar videos (objetos de video) a una presentación, Aspose.Slides proporciona la interfaz [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/), la interfaz [IVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ivideoframe/) y otros tipos relevantes.

## **Crear Marco de Video Incrustado**

Si el archivo de video que deseas agregar a tu diapositiva está almacenado localmente, puedes crear un marco de video para incrustar el video en tu presentación.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega un objeto [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/) y pasa la ruta del archivo de video para incrustar el video en la presentación.
1. Agrega un objeto [IVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ivideoframe/) para crear un marco para el video.
1. Guarda la presentación modificada.

Este código PHP te muestra cómo agregar un video almacenado localmente a una presentación:

```php
  # Instancia la clase Presentation
  $pres = new Presentation("pres.pptx");
  try {
    # Carga el video
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Obtiene la primera diapositiva y agrega un marco de video
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

Alternativamente, puedes agregar un video pasando su ruta de archivo directamente al método [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-):

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

## **Crear Marco de Video con Video de una Fuente Web**

Microsoft [PowerPoint 2013 y versiones más recientes](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) admiten videos de YouTube en presentaciones. Si el video que deseas usar está disponible en línea (por ejemplo, en YouTube), puedes agregarlo a tu presentación a través de su enlace web.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega un objeto [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/) y pasa el enlace al video.
1. Establece una miniatura para el marco de video.
1. Guarda la presentación.

Este código PHP te muestra cómo agregar un video de la web a una diapositiva en una presentación de PowerPoint:

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

## **Extraer Video de la Diapositiva**

Además de agregar videos a las diapositivas, Aspose.Slides te permite extraer videos incrustados en presentaciones.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) para cargar la presentación que contiene el video.
2. Itera a través de todos los objetos [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/).
3. Itera a través de todos los objetos [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) para encontrar un [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).
4. Guarda el video en disco.

Este código PHP te muestra cómo extraer el video de una diapositiva de presentación:

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