---
title: Převod prezentací PowerPoint na video v PHP
linktitle: PowerPoint na video
type: docs
weight: 130
url: /cs/php-java/convert-powerpoint-to-video/
keywords:
- převést PowerPoint
- převést prezentaci
- převést PPT
- převést PPTX
- PowerPoint na video
- prezentace na video
- PPT na video
- PPTX na video
- PowerPoint na MP4
- prezentace na MP4
- PPT na MP4
- PPTX na MP4
- uložit PPT jako MP4
- uložit PPTX jako MP4
- exportovat PPT do MP4
- exportovat PPTX do MP4
- konverze videa
- PowerPoint
- PHP
- Aspose.Slides
description: "Zjistěte, jak převést prezentace PowerPoint na video pomocí Aspose.Slides pro PHP. Objevte ukázkový kód a automatizační techniky pro zefektivnění vašeho pracovního postupu."
---
## **Úvod**

Převodem vaší prezentace PowerPoint na video získáte 

* **Zvýšení přístupnosti:** Všechna zařízení (bez ohledu na platformu) jsou ve výchozím nastavení vybavena video přehrávači, na rozdíl od aplikací pro otevírání prezentací, takže uživatelům je snazší otevřít nebo přehrát videa.
* **Větší dosah:** Pomocí videí můžete oslovit široké publikum a cílit na něj s informacemi, které by v prezentaci mohly působit nudně. Většina průzkumů a statistik naznačuje, že lidé sledují a konzumují videa více než jiné formy obsahu a obecně upřednostňují právě takový obsah.

{{% alert color="primary" %}} 

Možná budete chtít vyzkoušet náš [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/cs/conversion/ppt-to-word), protože je to živá a efektivní implementace procesu popsaného zde.

{{% /alert %}} 

## **Převod PowerPoint na video v Aspose.Slides**

Aspose.Slides podporuje převod prezentace na video.

* Použijte **Aspose.Slides** k vygenerování sady snímků (z prezentace) odpovídajících určitému počtu FPS (snímků za sekundu)
* Použijte nástroj třetí strany, jako je **ffmpeg** ([pro java](https://github.com/bramp/ffmpeg-cli-wrapper)), k vytvoření videa ze snímků.

### **Převod PowerPoint na video**

1. Přidejte toto do souboru POM:
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

You may want to see these articles: [PowerPoint Animation](https://docs.aspose.com/slides/cs/php-java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/cs/php-java/shape-animation/), and [Shape Effect](https://docs.aspose.com/slides/cs/php-java/shape-effect/).

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

To allow you to perform PowerPoint to video conversion tasks, Aspose.Slides provides the [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationanimationsgenerator/) and [PresentationPlayer](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationplayer/) classes.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationanimationsgenerator/) allows you to set the frame size for the video (that will be created later) through its constructor. If you pass an instance of the presentation, `Presentation::getSlideSize` will be used and it generates animations that [PresentationPlayer](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationplayer/) uses.

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

To make all animations in a presentation play at once, the [PresentationPlayer](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationplayer/) class is used. This class  takes a [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationanimationsgenerator/) instance and FPS for effects in its constructor and then calls the `FrameTick` event for all the animations to get them played:

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

Poté lze vygenerované snímky zkompilovat do videa. Viz sekce [Convert PowerPoint to Video](https://docs.aspose.com/slides/cs/php-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Podporované animace a efekty**

**Vstup**:

| Typ animace | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Fade** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Fly In** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Float In** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Split** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Wipe** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Shape** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Wheel** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Random Bars** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Grow & Turn** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Zoom** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Swivel** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Bounce** | ![podporováno](v.png) | ![podporováno](v.png) |

**Zdůraznění**:

| Typ animace | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Color Pulse** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Teeter** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Spin** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Grow/Shrink** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Desaturate** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Darken** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Lighten** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Transparency** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Object Color** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Complementary Color** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Line Color** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Fill Color** | ![nepodporováno](x.png) | ![podporováno](v.png) |

**Odchod**:

| Typ animace | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Fade** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Fly Out** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Float Out** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Split** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Wipe** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Shape** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Random Bars** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Shrink & Turn** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Zoom** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Swivel** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Bounce** | ![podporováno](v.png) | ![podporováno](v.png) |

**Cesty pohybu:**:

| Typ animace | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Arcs** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Turns** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Shapes** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Loops** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Custom Path** | ![podporováno](v.png) | ![podporováno](v.png) |

## **Často kladené otázky**

**Je možné převést prezentace chráněné heslem?**

Ano, Aspose.Slides umožňuje práci s [prezentacemi chráněnými heslem](/slides/cs/php-java/password-protected-presentation/). Při zpracování takových souborů je nutné zadat správné heslo, aby knihovna mohla získat přístup k obsahu prezentace.

**Podporuje Aspose.Slides použití v cloudových řešeních?**

Ano, Aspose.Slides lze integrovat do cloudových aplikací a služeb. Knihovna je navržena tak, aby fungovala v serverových prostředích, zajišťujíc vysoký výkon a škálovatelnost při zpracování souborů ve skupinách.

**Existují omezení velikosti prezentací při převodu?**

Aspose.Slides dokáže zpracovat prakticky jakoukoli velikost prezentace. Při práci s velmi velkými soubory však mohou být vyžadovány další systémové prostředky a někdy se doporučuje prezentaci optimalizovat pro zlepšení výkonu.