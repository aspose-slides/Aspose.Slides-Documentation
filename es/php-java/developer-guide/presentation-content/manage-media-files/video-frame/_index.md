---
title: Gestionar marcos de video en presentaciones usando PHP
linktitle: Marco de video
type: docs
weight: 10
url: /es/php-java/video-frame/
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
- PHP
- Aspose.Slides
description: "Aprende a añadir y extraer programáticamente marcos de video en diapositivas de PowerPoint y OpenDocument usando Aspose.Slides para PHP a través de Java. Guía rápida paso a paso."
---

Un video bien colocado en una presentación puede hacer que tu mensaje sea más convincente y aumentar los niveles de participación de la audiencia. 

PowerPoint permite añadir videos a una diapositiva en una presentación de dos maneras:

* Añadir o incrustar un video local (almacenado en tu equipo)
* Añadir un video en línea (desde una fuente web como YouTube).

Para permitirte añadir videos (objetos de video) a una presentación, Aspose.Slides proporciona la clase [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) , la clase [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) y otros tipos relevantes.

## **Crear marcos de video incrustados**

Si el archivo de video que deseas añadir a tu diapositiva está almacenado localmente, puedes crear un marco de video para incrustar el video en tu presentación. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. Obtén una referencia a la diapositiva mediante su índice. 
1. Añade un objeto [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) y pasa la ruta del archivo de video para incrustar el video en la presentación.
1. Añade un objeto [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) para crear un marco para el video.
1. Guarda la presentación modificada. 

Este código PHP muestra cómo añadir un video almacenado localmente a una presentación:
```php
  # Instancia la clase Presentation
  $pres = new Presentation("pres.pptx");
  try {
    # Carga el video
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Obtiene la primera diapositiva y añade un videoframe
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


Alternativamente, puedes añadir un video pasando su ruta de archivo directamente al método [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addvideoframe/) :
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


## **Crear marcos de video con video de fuentes web**

Microsoft [PowerPoint 2013 y versiones posteriores](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) admite videos de YouTube en presentaciones. Si el video que deseas usar está disponible en línea (p. ej., en YouTube), puedes añadirlo a tu presentación mediante su enlace web. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. Obtén una referencia a la diapositiva mediante su índice. 
1. Añade un objeto [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) y pasa el enlace al video.
1. Establece una miniatura para el marco de video. 
1. Guarda la presentación. 

Este código PHP muestra cómo añadir un video desde la web a una diapositiva en una presentación de PowerPoint:
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


## **Extraer video de diapositivas**

Además de añadir videos a diapositivas, Aspose.Slides permite extraer videos incrustados en presentaciones.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) para cargar la presentación que contiene el video.
2. Itera a través de todos los objetos [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) .
3. Itera a través de todos los objetos [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) para encontrar un [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) .
4. Guarda el video en disco.

Este código PHP muestra cómo extraer el video de una diapositiva de presentación:
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


## **FAQ**

**¿Qué parámetros de reproducción de video se pueden cambiar en un VideoFrame?**

Puedes controlar el [modo de reproducción](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setplaymode/) (automático o al hacer clic) y el [bucle](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setplayloopmode/) . Estas opciones están disponibles a través de las propiedades del objeto [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) .

**¿Añadir un video afecta al tamaño del archivo PPTX?**

Sí. Cuando incrustas un video local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece en proporción al tamaño del archivo. Cuando añades un video en línea, se incrustan un enlace y una miniatura, por lo que el aumento de tamaño es menor.

**¿Puedo reemplazar el video en un VideoFrame existente sin cambiar su posición y tamaño?**

Sí. Puedes intercambiar el [contenido de video](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setembeddedvideo/) dentro del marco conservando la geometría de la forma; este es un escenario común para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un video incrustado?**

Sí. Un video incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/php-java/aspose.slides/video/getcontenttype/) que puedes leer y utilizar, por ejemplo al guardarlo en disco.