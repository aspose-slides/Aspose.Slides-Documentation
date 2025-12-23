---
title: Gestionar marcos de video en presentaciones usando PHP
linktitle: Marco de video
type: docs
weight: 10
url: /es/php-java/video-frame/
keywords:
- agregar video
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
description: "Aprenda a agregar y extraer programáticamente marcos de video en diapositivas PowerPoint y OpenDocument usando Aspose.Slides para PHP a través de Java. Guía rápida paso a paso."
---

Un video bien colocado en una presentación puede hacer que su mensaje sea más atractivo y aumentar el nivel de compromiso con su audiencia.  

PowerPoint permite agregar videos a una diapositiva en una presentación de dos formas:

* Agregar o incrustar un video local (almacenado en su máquina)
* Agregar un video en línea (desde una fuente web como YouTube).

Para permitirle agregar videos (objetos de video) a una presentación, Aspose.Slides proporciona la [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/) interfaz, la [IVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ivideoframe/) interfaz y otros tipos relevantes.

## **Create Embedded Video Frames**

Si el archivo de video que desea agregar a su diapositiva está almacenado localmente, puede crear un marco de video para incrustar el video en su presentación.  

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) clase.  
1. Obtenga la referencia a una diapositiva mediante su índice.  
1. Añada un objeto [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/) y pase la ruta del archivo de video para incrustar el video en la presentación.  
1. Añada un objeto [IVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ivideoframe/) para crear un marco para el video.  
1. Guarde la presentación modificada.  

Este código PHP le muestra cómo agregar un video almacenado localmente a una presentación:
```php
  # Instancia la clase Presentation
  $pres = new Presentation("pres.pptx");
  try {
    # Carga el video
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Obtiene la primera diapositiva y agrega un videoframe
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


Alternativamente, puede agregar un video pasando directamente su ruta de archivo al método [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :
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


## **Create Video Frames with Video from Web Sources**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) admite videos de YouTube en presentaciones. Si el video que desea usar está disponible en línea (por ejemplo, en YouTube), puede agregarlo a su presentación a través de su enlace web.  

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) clase.  
1. Obtenga la referencia a una diapositiva mediante su índice.  
1. Añada un objeto [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/) y pase el enlace al video.  
1. Establezca una miniatura para el marco de video.  
1. Guarde la presentación.  

Este código PHP le muestra cómo agregar un video desde la web a una diapositiva en una presentación de PowerPoint:
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


## **Extract Video from Slides**

Además de agregar videos a diapositivas, Aspose.Slides le permite extraer videos incrustados en presentaciones.  

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) para cargar la presentación que contiene el video.  
2. Recorra todos los objetos [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/).  
3. Recorra todos los objetos [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) para encontrar un [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).  
4. Guarde el video en disco.  

Este código PHP le muestra cómo extraer el video de una diapositiva de presentación:
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

**¿Qué parámetros de reproducción de video se pueden cambiar para un VideoFrame?**

Puede controlar el [modo de reproducción](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setplaymode/) (automático o al hacer clic) y la [repetición](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setplayloopmode/). Estas opciones están disponibles a través de las propiedades del objeto [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).  

**¿Agregar un video afecta el tamaño del archivo PPTX?**

Sí. Cuando incrusta un video local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece en proporción al tamaño del archivo. Cuando agrega un video en línea, se incrustan un enlace y una miniatura, por lo que el aumento de tamaño es menor.  

**¿Puedo reemplazar el video en un VideoFrame existente sin cambiar su posición y tamaño?**

Sí. Puede intercambiar el [contenido del video](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setembeddedvideo/) dentro del marco mientras preserva la geometría de la forma; este es un escenario común para actualizar medios en un diseño existente.  

**¿Se puede determinar el tipo de contenido (MIME) de un video incrustado?**

Sí. Un video incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/php-java/aspose.slides/video/getcontenttype/) que puede leer y usar, por ejemplo, al guardarlo en disco.