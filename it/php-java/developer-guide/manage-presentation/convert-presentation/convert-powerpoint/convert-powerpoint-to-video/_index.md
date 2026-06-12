---
title: Converti presentazioni PowerPoint in video con PHP
linktitle: PowerPoint in video
type: docs
weight: 130
url: /it/php-java/convert-powerpoint-to-video/
keywords:
- converti PowerPoint
- converti presentazione
- converti PPT
- converti PPTX
- PowerPoint in video
- presentazione in video
- PPT in video
- PPTX in video
- PowerPoint in MP4
- presentazione in MP4
- PPT in MP4
- PPTX in MP4
- salva PPT come MP4
- salva PPTX come MP4
- esporta PPT in MP4
- esporta PPTX in MP4
- conversione video
- PowerPoint
- PHP
- Aspose.Slides
description: "Scopri come convertire le presentazioni PowerPoint in video con Aspose.Slides per PHP. Scopri codici di esempio e tecniche di automazione per ottimizzare il tuo flusso di lavoro."
---
## **Introduzione**

Convertendo la tua presentazione PowerPoint in video, ottieni 

* **Maggiore accessibilità:** tutti i dispositivi (indipendentemente dalla piattaforma) sono dotati di lettori video per impostazione predefinita rispetto alle applicazioni di apertura delle presentazioni, quindi gli utenti trovano più semplice aprire o riprodurre i video.
* **Maggiore diffusione:** tramite i video puoi raggiungere un vasto pubblico e fornire loro informazioni che altrimenti potrebbero apparire noiose in una presentazione. La maggior parte di sondaggi e statistiche indica che le persone guardano e consumano video più di altri formati di contenuto e, in genere, preferiscono questo tipo di contenuto.

{{% alert color="primary" %}} 

Potresti voler provare il nostro [**Convertitore online da PowerPoint a Video**](https://products.aspose.app/slides/it/conversion/ppt-to-word) perché è un’implementazione reale ed efficace del processo descritto qui.

{{% /alert %}} 

## **Conversione da PowerPoint a Video in Aspose.Slides**

Aspose.Slides supporta la conversione da presentazione a video.

* Usa **Aspose.Slides** per generare un set di fotogrammi (dalle diapositive della presentazione) corrispondenti a un determinato FPS (fotogrammi al secondo)
* Usa un’utilità di terze parti come **ffmpeg** ([per java](https://github.com/bramp/ffmpeg-cli-wrapper)) per creare un video basato sui fotogrammi.

### **Converti PowerPoint in Video**

1. Aggiungi questo al tuo file POM:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```php

```

2. Download ffmpeg [here](https://ffmpeg.org/download.html).

4. Run the PowerPoint to video PHP code.

This PHP code shows you how to convert a presentation (containing a figure and two animation effects) to a video:

```php
  $presentation = new Presentation();
  try {
    # Adds a smile shape and then animates it
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
    # Configure ffmpeg binaries folder. See this page: https://github.com/rosenbjerg/FFMpegCore#installation
    $ffmpeg = new Java("net.bramp.ffmpeg.builder.FFmpeg", "path/to/ffmpeg");
    $ffprobe = new Java("net.bramp.ffmpeg.builder.FFprobe", "path/to/ffprobe");
    $builder = (new Java("net.bramp.ffmpeg.builder.FFmpegBuilder"))->addExtraArgs("-start_number", "1")->setInput("frame_%04d.png")->addOutput("output.avi")->setVideoFrameRate(FFmpeg->FPS_24)->setFormat("avi")->done();
    $executor = new Java("net.bramp.ffmpeg.builder.FFmpegExecutor", $ffmpeg, $ffprobe);
    $executor->createJob($builder)->run();
  } catch (JavaException $e) {
    $e->printStackTrace();
  }
```

## **Video Effects**

You can apply animations to objects on slides and use transitions between slides. 

{{% alert color="primary" %}} 

You may want to see these articles: [PowerPoint Animation](https://docs.aspose.com/slides/it/php-java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/it/php-java/shape-animation/), and [Shape Effect](https://docs.aspose.com/slides/it/php-java/shape-effect/).

{{% /alert %}} 

Animations and transitions make slideshows more engaging and interesting—and they do the same thing for videos. Let's add another slide and transition to the code for the previous presentation:

```php
  # Adds a smile shape and animates it
  # ...
  # Adds a new slide and animated transition
  $newSlide = $presentation->getSlides()->addEmptySlide($presentation->getSlides()->get_Item(0)->getLayoutSlide());
  $newSlide->getBackground()->setType(BackgroundType::OwnBackground);
  $newSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
  $newSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
  $newSlide->getSlideShowTransition()->setType(TransitionType::Push);

```

Aspose.Slides also supports animation for texts. So we animate paragraphs on objects, which will appear one after the other (with the delay set to a second):

```php
  $presentation = new Presentation();
  try {
    # Adds text and animations
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 120, 300, 300);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Aspose Slides for Java"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("convert PowerPoint Presentation with text to video"));
    $para3 = new Paragraph();
    $para3->getPortions()->add(new Portion("paragraph by paragraph"));
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
    # Configure ffmpeg binaries folder. See this page: https://github.com/rosenbjerg/FFMpegCore#installation
    $ffmpeg = new Java("net.bramp.ffmpeg.builder.FFmpeg", "path/to/ffmpeg");
    $ffprobe = new Java("net.bramp.ffmpeg.builder.FFprobe", "path/to/ffprobe");
    $builder = (new Java("net.bramp.ffmpeg.builder.FFmpegBuilder"))->addExtraArgs("-start_number", "1")->setInput("frame_%04d.png")->addOutput("output.avi")->setVideoFrameRate(FFmpeg->FPS_24)->setFormat("avi")->done();
    $executor = new Java("net.bramp.ffmpeg.builder.FFmpegExecutor", $ffmpeg, $ffprobe);
    $executor->createJob($builder)->run();
  } catch (JavaException $e) {
    $e->printStackTrace();
  }
```

## **Video Conversion Classes**

To allow you to perform PowerPoint to video conversion tasks, Aspose.Slides provides the [PresentationAnimationsGenerator](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationanimationsgenerator/) and [PresentationPlayer](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationplayer/) classes.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationanimationsgenerator/) allows you to set the frame size for the video (that will be created later) through its constructor. If you pass an instance of the presentation, `Presentation::getSlideSize` will be used and it generates animations that [PresentationPlayer](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationplayer/) uses.

When animations are generated, a `NewAnimation` event is generated for each subsequent animation, which has the presentation animation player parameter. The latter is a class that represents a player for a separate animation.

To work with the presentation animation player, the `getDuration` (the full duration of the animation) and   `setTimePosition` methods are used. Each animation position is set within the *0 to duration* range, and then the `getFrame` method will return a BufferedImage that corresponds to the animation state at that moment:

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
        echo(sprintf("Animation total duration: %f", $animationPlayer->getDuration()));
        $animationPlayer->setTimePosition(0);// initial animation state
        try {
            # initial animation state bitmap
            $animationPlayer->getFrame()->save("firstFrame.png", ImageFormat::Png);
        } catch (JavaException $e) {
        }
        $animationPlayer->setTimePosition($animationPlayer->getDuration());// final state of the animation
        try {
            # last frame of the animation
            $animationPlayer->getFrame()->save("lastFrame.png", ImageFormat::Png);
        } catch (JavaException $e) {
        }
    }
}
$presentation = new Presentation();
try {
    # Adds a smile shape and animates it
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

To make all animations in a presentation play at once, the [PresentationPlayer](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationplayer/) class is used. This class  takes a [PresentationAnimationsGenerator](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationanimationsgenerator/) instance and FPS for effects in its constructor and then calls the `FrameTick` event for all the animations to get them played:

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

Then the generated frames can be compiled to produce a video. See the [Convert PowerPoint to Video](https://docs.aspose.com/slides/it/php-java/convert-powerpoint-to-video/#convert-powerpoint-to-video) section.

## **Animazioni ed Effetti supportati**

**Ingresso**:

| Tipo di animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![non supportato](x.png) | ![supportato](v.png) |
| **Fade** | ![supportato](v.png) | ![supportato](v.png) |
| **Fly In** | ![supportato](v.png) | ![supportato](v.png) |
| **Float In** | ![supportato](v.png) | ![supportato](v.png) |
| **Split** | ![supportato](v.png) | ![supportato](v.png) |
| **Wipe** | ![supportato](v.png) | ![supportato](v.png) |
| **Shape** | ![supportato](v.png) | ![supportato](v.png) |
| **Wheel** | ![supportato](v.png) | ![supportato](v.png) |
| **Random Bars** | ![supportato](v.png) | ![supportato](v.png) |
| **Grow & Turn** | ![non supportato](x.png) | ![supportato](v.png) |
| **Zoom** | ![supportato](v.png) | ![supportato](v.png) |
| **Swivel** | ![supportato](v.png) | ![supportato](v.png) |
| **Bounce** | ![supportato](v.png) | ![supportato](v.png) |

**Enfasi**:

| Tipo di animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![non supportato](x.png) | ![supportato](v.png) |
| **Color Pulse** | ![non supportato](x.png) | ![supportato](v.png) |
| **Teeter** | ![supportato](v.png) | ![supportato](v.png) |
| **Spin** | ![supportato](v.png) | ![supportato](v.png) |
| **Grow/Shrink** | ![non supportato](x.png) | ![supportato](v.png) |
| **Desaturate** | ![non supportato](x.png) | ![supportato](v.png) |
| **Darken** | ![non supportato](x.png) | ![supportato](v.png) |
| **Lighten** | ![non supportato](x.png) | ![supportato](v.png) |
| **Transparency** | ![non supportato](x.png) | ![supportato](v.png) |
| **Object Color** | ![non supportato](x.png) | ![supportato](v.png) |
| **Complementary Color** | ![non supportato](x.png) | ![supportato](v.png) |
| **Line Color** | ![non supportato](x.png) | ![supportato](v.png) |
| **Fill Color** | ![non supportato](x.png) | ![supportato](v.png) |

**Uscita**:

| Tipo di animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![non supportato](x.png) | ![supportato](v.png) |
| **Fade** | ![supportato](v.png) | ![supportato](v.png) |
| **Fly Out** | ![supportato](v.png) | ![supportato](v.png) |
| **Float Out** | ![supportato](v.png) | ![supportato](v.png) |
| **Split** | ![supportato](v.png) | ![supportato](v.png) |
| **Wipe** | ![supportato](v.png) | ![supportato](v.png) |
| **Shape** | ![supportato](v.png) | ![supportato](v.png) |
| **Random Bars** | ![supportato](v.png) | ![supportato](v.png) |
| **Shrink & Turn** | ![non supportato](x.png) | ![supportato](v.png) |
| **Zoom** | ![supportato](v.png) | ![supportato](v.png) |
| **Swivel** | ![supportato](v.png) | ![supportato](v.png) |
| **Bounce** | ![supportato](v.png) | ![supportato](v.png) |

**Percorsi di movimento**:

| Tipo di animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supportato](v.png) | ![supportato](v.png) |
| **Arcs** | ![supportato](v.png) | ![supportato](v.png) |
| **Turns** | ![supportato](v.png) | ![supportato](v.png) |
| **Shapes** | ![supportato](v.png) | ![supportato](v.png) |
| **Loops** | ![supportato](v.png) | ![supportato](v.png) |
| **Custom Path** | ![supportato](v.png) | ![supportato](v.png) |

## **FAQ**

**È possibile convertire presentazioni protette da password?**

Sì, Aspose.Slides consente di lavorare con [presentazioni protette da password](/slides/it/php-java/password-protected-presentation/). Quando si elaborano questi file, è necessario fornire la password corretta affinché la libreria possa accedere al contenuto della presentazione.

**Aspose.Slides supporta l'uso in soluzioni cloud?**

Sì, Aspose.Slides può essere integrato in applicazioni e servizi cloud. La libreria è progettata per funzionare in ambienti server, garantendo alte prestazioni e scalabilità per l'elaborazione batch di file.

**Ci sono limiti di dimensione per le presentazioni durante la conversione?**

Aspose.Slides è in grado di gestire presentazioni di dimensioni praticamente illimitate. Tuttavia, con file molto grandi possono essere richieste risorse di sistema aggiuntive, ed è talvolta consigliabile ottimizzare la presentazione per migliorare le prestazioni.