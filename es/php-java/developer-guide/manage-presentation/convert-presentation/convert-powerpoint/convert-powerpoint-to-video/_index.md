---
title: Convertir PowerPoint a Video
type: docs
weight: 130
url: /php-java/convert-powerpoint-to-video/
keywords: "Convertir PowerPoint, PPT, PPTX, Presentación, Video, MP4, PPT a video, PPT a MP4, Java, Aspose.Slides"
description: "Convertir PowerPoint a Video"
---

Al convertir tu presentación de PowerPoint a video, obtienes

* **Aumento en accesibilidad:** Todos los dispositivos (independientemente de la plataforma) vienen equipados con reproductores de video por defecto en comparación con las aplicaciones para abrir presentaciones, por lo que los usuarios encuentran más fácil abrir o reproducir videos.
* **Mayor alcance:** A través de videos, puedes alcanzar a una gran audiencia y dirigirlos con información que de otro modo podría parecer tediosa en una presentación. La mayoría de las encuestas y estadísticas sugieren que las personas ven y consumen videos más que otras formas de contenido, y generalmente prefieren dicho contenido.

{{% alert color="primary" %}} 

Es posible que quieras consultar nuestro [**Convertidor de PowerPoint a Video en Línea**](https://products.aspose.app/slides/conversion/ppt-to-word) porque es una implementación en vivo y efectiva del proceso descrito aquí.

{{% /alert %}} 

## **Conversión de PowerPoint a Video en Aspose.Slides**

En [Aspose.Slides 22.11](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-22-11-release-notes/), implementamos soporte para la conversión de presentaciones a video.

* Utiliza **Aspose.Slides** para generar un conjunto de fotogramas (de las diapositivas de la presentación) que correspondan a un cierto FPS (fotogramas por segundo).
* Usa una utilidad de terceros como **ffmpeg** ([para java](https://github.com/bramp/ffmpeg-cli-wrapper)) para crear un video basado en los fotogramas.

### **Convertir PowerPoint a Video**

1. Agrega esto a tu archivo POM:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```php

```

2. Descarga ffmpeg [aquí](https://ffmpeg.org/download.html).

4. Ejecuta el código PHP de PowerPoint a video.

Este código PHP te muestra cómo convertir una presentación (que contiene una figura y dos efectos de animación) a un video:

```php
  $presentation = new Presentation();
  try {
    # Agrega una forma de sonrisa y luego la anima
    $smile = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::SmileyFace, 110, 20, 500, 500);
    $mainSequence = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $effectIn = $mainSequence->addEffect($smile, EffectType::Fly, EffectSubType::TopLeft, EffectTriggerType::AfterPrevious);
    $effectOut = $mainSequence->addEffect($smile, EffectType::Fly, EffectSubType::BottomRight, EffectTriggerType::AfterPrevious);
    $effectIn->getTiming()->setDuration(2.0);
    $effectOut->setPresetClassType(EffectPresetClassType::Exit);
    $fps = 33;

    class FrameTick {
      function invoke($sender, $arg) {
            try {
                $frame = sprintf("frame_%04d.png", $sender->getFrameIndex());
                $arguments->getFrame()->save($frame, ImageFormat::Png);
                $frames->add($frame);
                } catch (JavaException $e) {
                  }
             }
    }

    $frames = new Java("java.util.ArrayList");
    $animationsGenerator = new PresentationAnimationsGenerator($presentation);
    try {
      $player = new PresentationPlayer($animationsGenerator, $fps);
      try {
        $frameTick = java_closure(new FrameTick(), null, java("com.aspose.slides.PresentationPlayerFrameTick"));
        $player->setFrameTick($frameTick);
        $animationsGenerator->run($presentation->getSlides());
      } finally {
        if (!java_is_null($player)) {
          $player->dispose();
        }
      }
    } finally {
      if (!java_is_null($animationsGenerator)) {
        $animationsGenerator->dispose();
      }
    }
    # Configurar la carpeta de binarios de ffmpeg. Consulta esta página: https://github.com/rosenbjerg/FFMpegCore#installation
    $ffmpeg = new Java("net.bramp.ffmpeg.builder.FFmpeg", "path/to/ffmpeg");
    $ffprobe = new Java("net.bramp.ffmpeg.builder.FFprobe", "path/to/ffprobe");
    $builder = (new Java("net.bramp.ffmpeg.builder.FFmpegBuilder"))->addExtraArgs("-start_number", "1")->setInput("frame_%04d.png")->addOutput("output.avi")->setVideoFrameRate(FFmpeg->FPS_24)->setFormat("avi")->done();
    $executor = new Java("net.bramp.ffmpeg.builder.FFmpegExecutor", $ffmpeg, $ffprobe);
    $executor->createJob($builder)->run();
  } catch (JavaException $e) {
    $e->printStackTrace();
  }
```

## **Efectos de Video**

Puedes aplicar animaciones a objetos en las diapositivas y utilizar transiciones entre diapositivas.

{{% alert color="primary" %}} 

Es posible que desees ver estos artículos: [Animación de PowerPoint](https://docs.aspose.com/slides/php-java/powerpoint-animation/), [Animación de Formas](https://docs.aspose.com/slides/php-java/shape-animation/), y [Efecto de Forma](https://docs.aspose.com/slides/php-java/shape-effect/).

{{% /alert %}} 

Las animaciones y transiciones hacen que las presentaciones sean más atractivas e interesantes, y hacen lo mismo para los videos. Vamos a agregar otra diapositiva y transición al código de la presentación anterior:

```php
  # Agrega una forma de sonrisa y la anima
  # ...
  # Agrega una nueva diapositiva y transición animada
  $newSlide = $presentation->getSlides()->addEmptySlide($presentation->getSlides()->get_Item(0)->getLayoutSlide());
  $newSlide->getBackground()->setType(BackgroundType::OwnBackground);
  $newSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
  $newSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
  $newSlide->getSlideShowTransition()->setType(TransitionType::Push);

```

Aspose.Slides también admite animación para textos. Así que animamos párrafos en objetos, que aparecerán uno tras otro (con el retraso establecido en un segundo):

```php
  $presentation = new Presentation();
  try {
    # Agrega texto y animaciones
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 120, 300, 300);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Aspose Slides para Java"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("convertir presentación de PowerPoint con texto a video"));
    $para3 = new Paragraph();
    $para3->getPortions()->add(new Portion("párrafo por párrafo"));
    $paragraphCollection = $autoShape->getTextFrame()->getParagraphs();
    $paragraphCollection->add($para1);
    $paragraphCollection->add($para2);
    $paragraphCollection->add($para3);
    $paragraphCollection->add(new Paragraph());
    $mainSequence = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $effect1 = $mainSequence->addEffect($para1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $effect2 = $mainSequence->addEffect($para2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $effect3 = $mainSequence->addEffect($para3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $effect4 = $mainSequence->addEffect($para3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $effect1->getTiming()->setTriggerDelayTime(1.0);
    $effect2->getTiming()->setTriggerDelayTime(1.0);
    $effect3->getTiming()->setTriggerDelayTime(1.0);
    $effect4->getTiming()->setTriggerDelayTime(1.0);
    $fps = 33;

    class FrameTick {
      function invoke($sender, $arg) {
            try {
                $frame = sprintf("frame_%04d.png", $sender->getFrameIndex());
                $arguments->getFrame()->save($frame, ImageFormat::Png);
                $frames->add($frame);
                } catch (JavaException $e) {
                  }
             }
    }

    $frames = new Java("java.util.ArrayList");
    $animationsGenerator = new PresentationAnimationsGenerator($presentation);
    try {
      $player = new PresentationPlayer($animationsGenerator, $fps);
      try {
        $frameTick = java_closure(new FrameTick(), null, java("com.aspose.slides.PresentationPlayerFrameTick"));
        $player->setFrameTick($frameTick);
        $animationsGenerator->run($presentation->getSlides());
      } finally {
        if (!java_is_null($player)) {
          $player->dispose();
        }
      }
    } finally {
      if (!java_is_null($animationsGenerator)) {
        $animationsGenerator->dispose();
      }
    }
    # Configurar la carpeta de binarios de ffmpeg. Consulta esta página: https://github.com/rosenbjerg/FFMpegCore#installation
    $ffmpeg = new Java("net.bramp.ffmpeg.builder.FFmpeg", "path/to/ffmpeg");
    $ffprobe = new Java("net.bramp.ffmpeg.builder.FFprobe", "path/to/ffprobe");
    $builder = (new Java("net.bramp.ffmpeg.builder.FFmpegBuilder"))->addExtraArgs("-start_number", "1")->setInput("frame_%04d.png")->addOutput("output.avi")->setVideoFrameRate(FFmpeg->FPS_24)->setFormat("avi")->done();
    $executor = new Java("net.bramp.ffmpeg.builder.FFmpegExecutor", $ffmpeg, $ffprobe);
    $executor->createJob($builder)->run();
  } catch (JavaException $e) {
    $e->printStackTrace();
  }
```

## **Clases de Conversión de Video**

Para permitirte realizar tareas de conversión de PowerPoint a video, Aspose.Slides proporciona las clases [PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) y [PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) te permite establecer el tamaño del fotograma para el video (que se creará más adelante) a través de su constructor. Si pasas una instancia de la presentación, se utilizará `Presentation.SlideSize` y generará animaciones que utiliza [PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/).

Cuando se generan animaciones, se genera un evento `NewAnimation` para cada animación subsiguiente, que tiene el parámetro [IPresentationAnimationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/). Este último es una clase que representa un reproductor para una animación separada.

Para trabajar con [IPresentationAnimationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/), se utilizan la propiedad [Duration](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/#getDuration--) (la duración total de la animación) y el método [SetTimePosition](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). Cada posición de animación se establece dentro del rango *0 a duration*, y luego el método `GetFrame` devolverá un BufferedImage que corresponde al estado de la animación en ese momento:

```php
use aspose\slides\Presentation;
use aspose\slides\PresentationPlayer;
use aspose\slides\PresentationAnimationsGenerator;
use aspose\slides\ImageFormat;
use aspose\slides\ShapeType;
use aspose\slides\EffectType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectPresetClassType;

class PresentationAnimationPlayer {
    function invoke($animationPlayer) {
        echo(sprintf("Duración total de la animación: %f", $animationPlayer->getDuration()));
        $animationPlayer->setTimePosition(0);// estado inicial de la animación
        try {
            # bitmap del estado inicial de la animación
            $animationPlayer->getFrame()->save("firstFrame.png", ImageFormat::Png);
        } catch (JavaException $e) {
        }
        $animationPlayer->setTimePosition($animationPlayer->getDuration());// estado final de la animación
        try {
            # último fotograma de la animación
            $animationPlayer->getFrame()->save("lastFrame.png", ImageFormat::Png);
        } catch (JavaException $e) {
        }
    }
}
$presentation = new Presentation();
try {
    # Agrega una forma de sonrisa y la anima
    $smile = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::SmileyFace, 110, 20, 500, 500);
    $mainSequence = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $effectIn = $mainSequence->addEffect($smile, EffectType::Fly, EffectSubtype::TopLeft, EffectTriggerType::AfterPrevious);
    $effectOut = $mainSequence->addEffect($smile, EffectType::Fly, EffectSubtype::BottomRight, EffectTriggerType::AfterPrevious);
    $effectIn->getTiming()->setDuration(2.0);
    $effectOut->setPresetClassType(EffectPresetClassType::Exit);
    $animationsGenerator = new PresentationAnimationsGenerator($presentation);
    $presentationAnimation=java_closure(new PresentationAnimationPlayer(), null, java("com.aspose.slides.PresentationAnimationsGeneratorNewAnimation"));
    try {
        $animationsGenerator->setNewAnimation($presentationAnimation);
    } finally {
        if (!java_is_null($animationsGenerator)) {
            $animationsGenerator->dispose();
        }
    }
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Para hacer que todas las animaciones en una presentación se reproduzcan a la vez, se utiliza la clase [PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/). Esta clase toma una instancia de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) y FPS para efectos en su constructor y luego llama el evento `FrameTick` para todas las animaciones para que se reproduzcan:

```php

class FrameTick {
      function invoke($sender, $arg) {
            try {
                $arguments->getFrame()->save("frame_" . $sender->getFrameIndex() . ".png", ImageFormat::Png);
                } catch (JavaException $e) {
                  }
             }
    }

  $presentation = new Presentation("animated.pptx");
  try {
    $animationsGenerator = new PresentationAnimationsGenerator($presentation);
    try {
      $player = new PresentationPlayer($animationsGenerator, 33);
      try {
        $frameTick = java_closure(new FrameTick(), null, java("com.aspose.slides.PresentationPlayerFrameTick"));
        $player->setFrameTick($frameTick);
        $animationsGenerator->run($presentation->getSlides());
      } finally {
        if (!java_is_null($player)) {
          $player->dispose();
        }
      }
    } finally {
      if (!java_is_null($animationsGenerator)) {
        $animationsGenerator->dispose();
      }
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

Luego, los fotogramas generados pueden ser compilados para producir un video. Consulta la sección [Convertir PowerPoint a Video](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animaciones y Efectos Soportados**

**Entrada**:

| Tipo de Animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Aparecer** | ![no soportado](x.png) | ![soportado](v.png) |
| **Desvanecer** | ![soportado](v.png) | ![soportado](v.png) |
| **Volando In** | ![soportado](v.png) | ![soportado](v.png) |
| **Flotar In** | ![soportado](v.png) | ![soportado](v.png) |
| **Dividir** | ![soportado](v.png) | ![soportado](v.png) |
| **Limpiar** | ![soportado](v.png) | ![soportado](v.png) |
| **Forma** | ![soportado](v.png) | ![soportado](v.png) |
| **Rueda** | ![soportado](v.png) | ![soportado](v.png) |
| **Barras Aleatorias** | ![soportado](v.png) | ![soportado](v.png) |
| **Crecer y Girar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Zoom** | ![soportado](v.png) | ![soportado](v.png) |
| **Girar** | ![soportado](v.png) | ![soportado](v.png) |
| **Rebotar** | ![soportado](v.png) | ![soportado](v.png) |

**Énfasis**:

| Tipo de Animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulso** | ![no soportado](x.png) | ![soportado](v.png) |
| **Pulso de Color** | ![no soportado](x.png) | ![soportado](v.png) |
| **Hacer Oscilar** | ![soportado](v.png) | ![soportado](v.png) |
| **Girar** | ![soportado](v.png) | ![soportado](v.png) |
| **Crecer/Decrecer** | ![no soportado](x.png) | ![soportado](v.png) |
| **Desaturar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Oscurecer** | ![no soportado](x.png) | ![soportado](v.png) |
| **Aclarar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Transparencia** | ![no soportado](x.png) | ![soportado](v.png) |
| **Color de Objeto** | ![no soportado](x.png) | ![soportado](v.png) |
| **Color Complementario** | ![no soportado](x.png) | ![soportado](v.png) |
| **Color de Línea** | ![no soportado](x.png) | ![soportado](v.png) |
| **Color de Relleno** | ![no soportado](x.png) | ![soportado](v.png) |

**Salida**:

| Tipo de Animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Desaparecer** | ![no soportado](x.png) | ![soportado](v.png) |
| **Desvanecer** | ![soportado](v.png) | ![soportado](v.png) |
| **Volando Fuera** | ![soportado](v.png) | ![soportado](v.png) |
| **Flotar Fuera** | ![soportado](v.png) | ![soportado](v.png) |
| **Dividir** | ![soportado](v.png) | ![soportado](v.png) |
| **Limpiar** | ![soportado](v.png) | ![soportado](v.png) |
| **Forma** | ![soportado](v.png) | ![soportado](v.png) |
| **Barras Aleatorias** | ![soportado](v.png) | ![soportado](v.png) |
| **Decrecer y Girar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Zoom** | ![soportado](v.png) | ![soportado](v.png) |
| **Girar** | ![soportado](v.png) | ![soportado](v.png) |
| **Rebotar** | ![soportado](v.png) | ![soportado](v.png) |

**Rutas de Movimiento:**

| Tipo de Animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Líneas** | ![soportado](v.png) | ![soportado](v.png) |
| **Arcos** | ![soportado](v.png) | ![soportado](v.png) |
| **Giros** | ![soportado](v.png) | ![soportado](v.png) |
| **Formas** | ![soportado](v.png) | ![soportado](v.png) |
| **Bucles** | ![soportado](v.png) | ![soportado](v.png) |
| **Ruta Personalizada** | ![soportado](v.png) | ![soportado](v.png) |