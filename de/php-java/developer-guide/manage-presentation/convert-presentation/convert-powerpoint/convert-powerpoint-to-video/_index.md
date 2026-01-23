---
title: PowerPoint-Präsentationen in PHP in Video konvertieren
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

* **Erhöhte Zugänglichkeit:** Alle Geräte (unabhängig vom Plattform) verfügen standardmäßig über Videoplayer im Vergleich zu Anwendungen zum Öffnen von Präsentationen, sodass Benutzer es einfacher finden, Videos zu öffnen oder abzuspielen.
* **Mehr Reichweite:** Durch Videos können Sie ein großes Publikum erreichen und mit Informationen ansprechen, die in einer Präsentation sonst langweilig wirken könnten. Die meisten Umfragen und Statistiken zeigen, dass Menschen Videos mehr ansehen und konsumieren als andere Inhaltsformen und sie im Allgemeinen bevorzugen.

{{% alert color="primary" %}} 

Sie sollten vielleicht unseren [**PowerPoint‑zu‑Video‑Online‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-word) prüfen, da er eine aktuelle und effektive Umsetzung des hier beschriebenen Prozesses darstellt.

{{% /alert %}} 

## **PowerPoint‑zu‑Video‑Konvertierung in Aspose.Slides**

Aspose.Slides unterstützt die Konvertierung von Präsentationen in Video.

* Verwenden Sie **Aspose.Slides**, um einen Satz von Frames (aus den Präsentationsfolien) zu erzeugen, die einer bestimmten FPS (Frames pro Sekunde) entsprechen
* Verwenden Sie ein Drittanbieter‑Dienstprogramm wie **ffmpeg** ([für Java](https://github.com/bramp/ffmpeg-cli-wrapper)), um ein Video basierend auf den Frames zu erstellen.

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

Dieser PHP‑Code zeigt, wie Sie eine Präsentation (mit einer Abbildung und zwei Animationseffekten) in ein Video konvertieren:
```php
  $presentation = new Presentation();
  try {
    # Fügt eine Smiley-Form hinzu und animiert sie
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


## **Videoeffekte**

Sie können Animationen auf Objekte in Folien anwenden und Übergänge zwischen Folien verwenden.

{{% alert color="primary" %}} 

Sie sollten sich diese Artikel ansehen: [PowerPoint‑Animation](https://docs.aspose.com/slides/php-java/powerpoint-animation/), [Shape‑Animation](https://docs.aspose.com/slides/php-java/shape-animation/), und [Shape‑Effekt](https://docs.aspose.com/slides/php-java/shape-effect/).

{{% /alert %}} 

Animationen und Übergänge machen Diashows ansprechender und interessanter – und sie bewirken dasselbe bei Videos. Fügen wir dem Code für die vorherige Präsentation eine weitere Folie und einen Übergang hinzu:
```php
  # Fügt eine Smiley-Form hinzu und animiert sie
  # ...
  # Fügt eine neue Folie und einen animierten Übergang hinzu
  $newSlide = $presentation->getSlides()->addEmptySlide($presentation->getSlides()->get_Item(0)->getLayoutSlide());
  $newSlide->getBackground()->setType(BackgroundType::OwnBackground);
  $newSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
  $newSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
  $newSlide->getSlideShowTransition()->setType(TransitionType::Push);
```


Aspose.Slides unterstützt auch Animationen für Texte. Wir animieren also Absätze auf Objekten, die nacheinander erscheinen (mit einer Verzögerung von einer Sekunde):
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


## **Klassen für Video‑Konvertierung**

Damit Sie PowerPoint‑zu‑Video‑Konvertierungsaufgaben ausführen können, stellt Aspose.Slides die Klassen [PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) und [PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/) bereit.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) ermöglicht es Ihnen, die Frame‑Größe für das später erstellte Video über den Konstruktor festzulegen. Wenn Sie eine Instanz der Präsentation übergeben, wird `Presentation::getSlideSize` verwendet und es erzeugt Animationen, die [PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/) nutzt.

Wenn Animationen erzeugt werden, wird für jede nachfolgende Animation ein `NewAnimation`‑Event erzeugt, das den Parameter des Präsentations‑Animations‑Players enthält. Letzterer ist eine Klasse, die einen Player für eine separate Animation darstellt.

Um mit dem Präsentations‑Animations‑Player zu arbeiten, werden die Methoden `getDuration` (die Gesamtdauer der Animation) und `setTimePosition` verwendet. Jede Animationsposition wird im Bereich *0 bis Dauer* festgelegt, und anschließend liefert die Methode `getFrame` ein BufferedImage, das dem Animationszustand zu diesem Zeitpunkt entspricht:
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
            # initialer Animationszustand Bitmap
            $animationPlayer->getFrame()->save("firstFrame.png", ImageFormat::Png);
        } catch (JavaException $e) {
        }
        $animationPlayer->setTimePosition($animationPlayer->getDuration());// finaler Zustand der Animation
        try {
            # letztes Frame der Animation
            $animationPlayer->getFrame()->save("lastFrame.png", ImageFormat::Png);
        } catch (JavaException $e) {
        }
    }
}
$presentation = new Presentation();
try {
    # Fügt eine Smiley-Form hinzu und animiert sie
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


Um alle Animationen in einer Präsentation gleichzeitig abspielen zu lassen, wird die Klasse [PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/) verwendet. Diese Klasse nimmt im Konstruktor eine Instanz von [PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) sowie FPS für Effekte entgegen und ruft dann das `FrameTick`‑Event für alle Animationen auf, um sie abzuspielen:
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


Anschließend können die erzeugten Frames zu einem Video zusammengefügt werden. Siehe den Abschnitt [PowerPoint zu Video konvertieren](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Unterstützte Animationen und Effekte**

**Eintritt**:

| Animation Type | Aspose.Slides | PowerPoint |
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

**Hervorhebung**:

| Animation Type | Aspose.Slides | PowerPoint |
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

| Animation Type | Aspose.Slides | PowerPoint |
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

**Bewegungspfade:**

| Animation Type | Aspose.Slides | PowerPoint |
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

**Unterstützt Aspose.Slides den Einsatz in Cloud‑Lösungen?**

Ja, Aspose.Slides kann in Cloud‑Anwendungen und -Diensten integriert werden. Die Bibliothek ist für den Einsatz in Serverumgebungen konzipiert und gewährleistet hohe Leistung und Skalierbarkeit für die stapelweise Verarbeitung von Dateien.

**Gibt es Größenbeschränkungen für Präsentationen während der Konvertierung?**

Aspose.Slides kann praktisch Präsentationen jeder Größe verarbeiten. Bei sehr großen Dateien können jedoch zusätzliche Systemressourcen erforderlich sein, und es wird manchmal empfohlen, die Präsentation zu optimieren, um die Leistung zu verbessern.