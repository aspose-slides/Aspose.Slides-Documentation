---
title: PowerPoint-Präsentationen in Video konvertieren in PHP
linktitle: PowerPoint zu Video
type: docs
weight: 130
url: /de/php-java/convert-powerpoint-to-video/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu Video
- Präsentation zu Video
- PPT zu Video
- PPTX zu Video
- PowerPoint zu MP4
- Präsentation zu MP4
- PPT zu MP4
- PPTX zu MP4
- PPT als MP4 speichern
- PPTX als MP4 speichern
- PPT nach MP4 exportieren
- PPTX nach MP4 exportieren
- Video-Konvertierung
- PowerPoint
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Präsentationen mit Aspose.Slides für PHP in Video konvertieren. Entdecken Sie Beispielcode und Automatisierungstechniken, um Ihren Arbeitsablauf zu optimieren."
---

Durch das Konvertieren Ihrer PowerPoint‑Präsentation in ein Video erhalten Sie  

* **Erhöhung der Barrierefreiheit:** Alle Geräte (unabhängig vom Betriebssystem) verfügen standardmäßig über Videoplayer im Vergleich zu Anwendungen zum Öffnen von Präsentationen, sodass Benutzer Videos einfacher öffnen oder abspielen können.  
* **Größere Reichweite:** Durch Videos können Sie ein großes Publikum erreichen und mit Informationen ansprechen, die in einer Präsentation sonst möglicherweise als mühsam empfunden würden. Die meisten Umfragen und Statistiken zeigen, dass Menschen Videos mehr ansehen und konsumieren als andere Inhaltsformen und diese bevorzugen.  

{{% alert color="primary" %}} 
Vielleicht möchten Sie unseren [**PowerPoint‑zu‑Video‑Online‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-word) überprüfen, da er eine Live‑ und effektive Umsetzung des hier beschriebenen Prozesses darstellt.  
{{% /alert %}} 

## **PowerPoint‑zu‑Video‑Konvertierung in Aspose.Slides**

In [Aspose.Slides 22.11](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-22-11-release-notes/) haben wir die Unterstützung für die Konvertierung von Präsentationen zu Video implementiert.  

* Verwenden Sie **Aspose.Slides**, um einen Satz von Frames (aus den Präsentationsfolien) zu erzeugen, der einer bestimmten FPS (Bilder pro Sekunde) entspricht  
* Verwenden Sie ein Drittanbieter‑Tool wie **ffmpeg** ([für Java](https://github.com/bramp/ffmpeg-cli-wrapper)), um basierend auf den Frames ein Video zu erstellen.  

### **PowerPoint zu Video konvertieren**

1. Fügen Sie dies zu Ihrer POM‑Datei hinzu:  
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```php

```


2. Laden Sie ffmpeg [hier](https://ffmpeg.org/download.html) herunter.  

4. Führen Sie den PowerPoint‑zu‑Video‑PHP‑Code aus.  

Dieser PHP‑Code zeigt Ihnen, wie Sie eine Präsentation (mit einer Figur und zwei Animationseffekten) in ein Video konvertieren:  
```php
  $presentation = new Presentation();
  try {
    # Fügt ein Smiley-Shape hinzu und animiert es dann
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
    # Konfiguriere den Ordner mit den ffmpeg-Binärdateien. Siehe diese Seite: https://github.com/rosenbjerg/FFMpegCore#installation
    $ffmpeg = new Java("net.bramp.ffmpeg.builder.FFmpeg", "path/to/ffmpeg");
    $ffprobe = new Java("net.bramp.ffmpeg.builder.FFprobe", "path/to/ffprobe");
    $builder = (new Java("net.bramp.ffmpeg.builder.FFmpegBuilder"))->addExtraArgs("-start_number", "1")->setInput("frame_%04d.png")->addOutput("output.avi")->setVideoFrameRate(FFmpeg->FPS_24)->setFormat("avi")->done();
    $executor = new Java("net.bramp.ffmpeg.builder.FFmpegExecutor", $ffmpeg, $ffprobe);
    $executor->createJob($builder)->run();
  } catch (JavaException $e) {
    $e->printStackTrace();
  }
```


## **Video‑Effekte**

Sie können Animationen auf Objekte in Folien anwenden und Übergänge zwischen Folien verwenden.  

{{% alert color="primary" %}} 
Vielleicht möchten Sie diese Artikel ansehen: [PowerPoint‑Animation](https://docs.aspose.com/slides/php-java/powerpoint-animation/), [Form‑Animation](https://docs.aspose.com/slides/php-java/shape-animation/), und [Form‑Effekt](https://docs.aspose.com/slides/php-java/shape-effect/).  
{{% /alert %}} 

Animationen und Übergänge machen Diashows ansprechender und interessanter – und sie bewirken dasselbe bei Videos. Lassen Sie uns der vorherigen Präsentation einen weiteren Folien‑ und Übergangs‑Code hinzufügen:  
```php
  # Fügt ein Smiley-Shape hinzu und animiert es
  # ...
  # Fügt eine neue Folie und einen animierten Übergang hinzu
  $newSlide = $presentation->getSlides()->addEmptySlide($presentation->getSlides()->get_Item(0)->getLayoutSlide());
  $newSlide->getBackground()->setType(BackgroundType::OwnBackground);
  $newSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
  $newSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
  $newSlide->getSlideShowTransition()->setType(TransitionType::Push);
```


Aspose.Slides unterstützt zudem Animationen für Texte. Wir animieren also Absätze auf Objekten, die nacheinander erscheinen (mit einer Verzögerung von einer Sekunde):  
```php
  $presentation = new Presentation();
  try {
    # Fügt Text und Animationen hinzu
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
    # Konfiguriere den ffmpeg-Binärordner. Siehe diese Seite: https://github.com/rosenbjerg/FFMpegCore#installation
    $ffmpeg = new Java("net.bramp.ffmpeg.builder.FFmpeg", "path/to/ffmpeg");
    $ffprobe = new Java("net.bramp.ffmpeg.builder.FFprobe", "path/to/ffprobe");
    $builder = (new Java("net.bramp.ffmpeg.builder.FFmpegBuilder"))->addExtraArgs("-start_number", "1")->setInput("frame_%04d.png")->addOutput("output.avi")->setVideoFrameRate(FFmpeg->FPS_24)->setFormat("avi")->done();
    $executor = new Java("net.bramp.ffmpeg.builder.FFmpegExecutor", $ffmpeg, $ffprobe);
    $executor->createJob($builder)->run();
  } catch (JavaException $e) {
    $e->printStackTrace();
  }
```


## **Video‑Konvertierungs‑Klassen**

Um Ihnen die Durchführung von PowerPoint‑zu‑Video‑Konvertierungen zu ermöglichen, stellt Aspose.Slides die Klassen [PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) und [PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/) zur Verfügung.  

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) ermöglicht es Ihnen, über seinen Konstruktor die Frame‑Größe für das Video (das später erstellt wird) festzulegen. Wenn Sie eine Instanz der Präsentation übergeben, wird `Presentation.SlideSize` verwendet und es werden Animationen erzeugt, die [PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/) nutzt.  

Wenn Animationen erzeugt werden, wird für jede nachfolgende Animation ein `NewAnimation`‑Ereignis generiert, das den Parameter [IPresentationAnimationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/) besitzt. Letzterer ist eine Klasse, die einen Player für eine einzelne Animation darstellt.  

Um mit [IPresentationAnimationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/) zu arbeiten, werden die Eigenschaft [Duration](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/#getDuration--) (die Gesamtdauer der Animation) und die Methode [SetTimePosition](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) verwendet. Jede Animationsposition wird innerhalb des Bereichs *0 bis Dauer* gesetzt, und anschließend gibt die Methode `GetFrame` ein BufferedImage zurück, das dem Animationszustand zu diesem Zeitpunkt entspricht:  
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
        $animationPlayer->setTimePosition(0);// initialer Animationszustand
        try {
            # Bitmap des Anfangszustands der Animation
            $animationPlayer->getFrame()->save("firstFrame.png", ImageFormat::Png);
        } catch (JavaException $e) {
        }
        $animationPlayer->setTimePosition($animationPlayer->getDuration());// final state of the animation
        try {
            # letztes Bild der Animation
            $animationPlayer->getFrame()->save("lastFrame.png", ImageFormat::Png);
        } catch (JavaException $e) {
        }
    }
}
$presentation = new Presentation();
try {
    # Fügt ein Smiley-Shape hinzu und animiert es
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


Um alle Animationen einer Präsentation gleichzeitig abspielen zu lassen, wird die Klasse [PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/) verwendet. Diese Klasse nimmt im Konstruktor eine Instanz von [PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) und die FPS für Effekte entgegen und ruft anschließend das `FrameTick`‑Ereignis für alle Animationen auf, um sie abzuspielen:  
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


Anschließend können die erzeugten Frames zu einem Video zusammengefügt werden. Siehe den Abschnitt [Convert PowerPoint to Video](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).  

## **Unterstützte Animationen und Effekte**

**Eingang**:

| Animationsart | Aspose.Slides | PowerPoint |
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

**Betonung**:

| Animationsart | Aspose.Slides | PowerPoint |
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

**Ausgang**:

| Animationsart | Aspose.Slides | PowerPoint |
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

**Bewegungswege:**  

| Animationsart | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Ist es möglich, passwortgeschützte Präsentationen zu konvertieren?**  
Ja, Aspose.Slides ermöglicht die Arbeit mit [passwortgeschützten Präsentationen](/slides/de/php-java/password-protected-presentation/). Beim Verarbeiten solcher Dateien müssen Sie das korrekte Passwort angeben, damit die Bibliothek auf den Inhalt der Präsentation zugreifen kann.

**Unterstützt Aspose.Slides die Nutzung in Cloud‑Lösungen?**  
Ja, Aspose.Slides kann in Cloud‑Anwendungen und -Dienste integriert werden. Die Bibliothek ist für den Einsatz in Server‑Umgebungen konzipiert und gewährleistet hohe Leistung sowie Skalierbarkeit für die Stapelverarbeitung von Dateien.

**Gibt es Größenbeschränkungen für Präsentationen bei der Konvertierung?**  
Aspose.Slides kann praktisch Präsentationen jeder Größe verarbeiten. Bei sehr großen Dateien können jedoch zusätzliche Systemressourcen erforderlich sein, und es wird manchmal empfohlen, die Präsentation zu optimieren, um die Leistung zu verbessern.