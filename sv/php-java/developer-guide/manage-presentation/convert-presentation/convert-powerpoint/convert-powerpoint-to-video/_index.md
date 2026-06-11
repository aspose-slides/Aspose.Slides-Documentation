---
title: Konvertera PowerPoint-presentationer till video i PHP
linktitle: PowerPoint till video
type: docs
weight: 130
url: /sv/php-java/convert-powerpoint-to-video/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera PPT
- konvertera PPTX
- PowerPoint till video
- presentation till video
- PPT till video
- PPTX till video
- PowerPoint till MP4
- presentation till MP4
- PPT till MP4
- PPTX till MP4
- spara PPT som MP4
- spara PPTX som MP4
- exportera PPT till MP4
- exportera PPTX till MP4
- videokonvertering
- PowerPoint
- PHP
- Aspose.Slides
description: "Lär dig hur du konverterar PowerPoint-presentationer till video med Aspose.Slides för PHP. Upptäck exempel på kod och automatiseringstekniker för att effektivisera ditt arbetsflöde."
---
## **Introduktion**

Genom att konvertera din PowerPoint-presentation till video får du 

* **Ökad tillgänglighet:** Alla enheter (oavsett plattform) har som standard videospelare till skillnad från program för att öppna presentationer, så användare finner det enklare att öppna eller spela upp videor.
* **Större räckvidd:** Genom videor kan du nå en stor publik och rikta information till dem som annars kan verka tråkig i en presentation. De flesta undersökningar och statistik visar att folk tittar på och konsumerar videor mer än andra former av innehåll, och de föredrar generellt sådant innehåll.

{{% alert color="primary" %}} 

Du kanske vill testa vår [**PowerPoint till Video Online‑konverterare**](https://products.aspose.app/slides/sv/conversion/ppt-to-word) eftersom den är en levande och effektiv implementering av processen som beskrivs här.

{{% /alert %}} 

## **PowerPoint till video‑konvertering i Aspose.Slides**

Aspose.Slides stödjer konvertering av presentation till video.

* Använd **Aspose.Slides** för att generera ett set av bildrutor (från presentationsbilderna) som motsvarar ett visst FPS (bildrutor per sekund)
* Använd ett tredjepartsverktyg som **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) för att skapa en video baserad på bildrutorna.

### **Konvertera PowerPoint till video**

1. Lägg till detta i din POM‑fil:
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
    # Lägger till en leendeform och animerar den
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
    # Konfigurera ffmpeg‑binärkatalogen. Se denna sida: https://github.com/rosenbjerg/FFMpegCore#installation
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

You may want to see these articles: [PowerPoint Animation](https://docs.aspose.com/slides/sv/php-java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/sv/php-java/shape-animation/), and [Shape Effect](https://docs.aspose.com/slides/sv/php-java/shape-effect/).

{{% /alert %}} 

Animations and transitions make slideshows more engaging and interesting—and they do the same thing for videos. Let's add another slide and transition to the code for the previous presentation:

```php
  # Lägger till en leendeform och animerar den
  # ...
  # Lägger till en ny bild och animerad övergång
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
    # Lägger till text och animationer
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
    # Konfigurera ffmpeg‑binärkatalogen. Se denna sida: https://github.com/rosenbjerg/FFMpegCore#installation
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

To allow you to perform PowerPoint to video conversion tasks, Aspose.Slides provides the [PresentationAnimationsGenerator](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationanimationsgenerator/) and [PresentationPlayer](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationplayer/) classes.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationanimationsgenerator/) allows you to set the frame size for the video (that will be created later) through its constructor. If you pass an instance of the presentation, `Presentation::getSlideSize` will be used and it generates animations that [PresentationPlayer](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationplayer/) uses.

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
            # initialt animationstillstånd bitmap
            $animationPlayer->getFrame()->save("firstFrame.png", ImageFormat::Png);
        } catch (JavaException $e) {
        }
        $animationPlayer->setTimePosition($animationPlayer->getDuration());// final state of the animation
        try {
            # sista bildrutan av animationen
            $animationPlayer->getFrame()->save("lastFrame.png", ImageFormat::Png);
        } catch (JavaException $e) {
        }
    }
}
$presentation = new Presentation();
try {
    # Lägger till en leendeform och animerar den
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

To make all animations in a presentation play at once, the [PresentationPlayer](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationplayer/) class is used. This class  takes a [PresentationAnimationsGenerator](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationanimationsgenerator/) instance and FPS for effects in its constructor and then calls the `FrameTick` event for all the animations to get them played:

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

Sedan kan de genererade bildrutorna kompileras till en video. Se avsnittet [Konvertera PowerPoint till video](https://docs.aspose.com/slides/sv/php-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Stödda animationer och effekter**

**Ingång**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Betoning**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**Utgång**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Rörelsespår**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Vanliga frågor**

**Är det möjligt att konvertera presentationer som är lösenordsskyddade?**

Ja, Aspose.Slides möjliggör arbete med [lösenordsskyddade presentationer](/slides/sv/php-java/password-protected-presentation/). Vid bearbetning av sådana filer måste du ange rätt lösenord så att biblioteket kan komma åt presentationens innehåll.

**Stöder Aspose.Slides användning i molnlösningar?**

Ja, Aspose.Slides kan integreras i molnapplikationer och -tjänster. Biblioteket är designat för att fungera i servermiljöer, vilket säkerställer hög prestanda och skalbarhet för batchbearbetning av filer.

**Finns det några storleksbegränsningar för presentationer under konvertering?**

Aspose.Slides kan hantera presentationer av i princip vilken storlek som helst. När du arbetar med mycket stora filer kan dock extra systemresurser krävas, och det rekommenderas ibland att optimera presentationen för att förbättra prestandan.