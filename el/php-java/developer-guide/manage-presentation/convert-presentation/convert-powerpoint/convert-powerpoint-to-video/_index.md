---
title: Μετατροπή Παρουσιών PowerPoint σε Βίντεο σε PHP
linktitle: PowerPoint σε Βίντεο
type: docs
weight: 130
url: /el/php-java/convert-powerpoint-to-video/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε βίντεο
- παρουσίαση σε βίντεο
- PPT σε βίντεο
- PPTX σε βίντεο
- PowerPoint σε MP4
- παρουσίαση σε MP4
- PPT σε MP4
- PPTX σε MP4
- αποθήκευση PPT ως MP4
- αποθήκευση PPTX ως MP4
- εξαγωγή PPT σε MP4
- εξαγωγή PPTX σε MP4
- μετατροπή βίντεο
- PowerPoint
- PHP
- Aspose.Slides
description: "Μάθετε πώς να μετατρέπετε παρουσιάσεις PowerPoint σε βίντεο με το Aspose.Slides για PHP. Ανακαλύψτε δείγμα κώδικα και τεχνικές αυτοματοποίησης για να βελτιώσετε τη ροή εργασίας σας."
---
## **Εισαγωγή**

Με τη μετατροπή της παρουσίασης PowerPoint σε βίντεο, παίρνετε 

* **Αύξηση της προσβασιμότητας:** Όλες οι συσκευές (ανεξαρτήτως πλατφόρμας) είναι εξοπλισμένες με αναπαραγωγείς βίντεο από προεπιλογή σε σύγκριση με τις εφαρμογές ανοίγματος παρουσιάσεων, έτσι οι χρήστες βρίσκουν πιο εύκολη τη φόρτωση ή την αναπαραγωγή βίντεο.
* **Μεγαλύτερη εμβέλεια:** Μέσα από βίντεο, μπορείτε να προσεγγίσετε ένα μεγάλο κοινό και να τονίσετε πληροφορίες που διαφορετικά θα φαινόταν κουραστικό σε μια παρουσίαση. Οι περισσότερες έρευνες και στατιστικές δείχνουν ότι οι άνθρωποι βλέπουν και καταναλώνουν βίντεο περισσότερο από άλλες μορφές περιεχομένου και γενικά προτιμούν τέτοιο περιεχόμενο.

{{% alert color="primary" %}} 

Μπορεί να θέλετε να ελέγξετε το [**Μετατροπέας PowerPoint σε Βίντεο Online**](https://products.aspose.app/slides/el/conversion/ppt-to-word) γιατί είναι μια ζωντανή και αποτελεσματική υλοποίηση της διαδικασίας που περιγράφεται εδώ.

{{% /alert %}} 

## **Μετατροπή PowerPoint σε Βίντεο με Aspose.Slides**

Aspose.Slides υποστηρίζει τη μετατροπή παρουσίασης σε βίντεο.

* Χρησιμοποιήστε **Aspose.Slides** για να δημιουργήσετε ένα σύνολο καρέ (από τις διαφάνειες της παρουσίασης) που αντιστοιχεί σε συγκεκριμένο FPS (καρέ ανά δευτερόλεπτο)
* Χρησιμοποιήστε ένα εργαλείο τρίτου μέρους όπως το **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) για να δημιουργήσετε ένα βίντεο με βάση τα καρέ.

### **Μετατροπή PowerPoint σε Βίντεο**

1. Προσθέστε αυτό στο αρχείο POM σας:
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

You may want to see these articles: [PowerPoint Animation](https://docs.aspose.com/slides/el/php-java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/el/php-java/shape-animation/), and [Shape Effect](https://docs.aspose.com/slides/el/php-java/shape-effect/).

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

To allow you to perform PowerPoint to video conversion tasks, Aspose.Slides provides the [PresentationAnimationsGenerator](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationanimationsgenerator/) and [PresentationPlayer](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationplayer/) classes.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationanimationsgenerator/) allows you to set the frame size for the video (that will be created later) through its constructor. If you pass an instance of the presentation, `Presentation::getSlideSize` will be used and it generates animations that [PresentationPlayer](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationplayer/) uses.

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

To make all animations in a presentation play at once, the [PresentationPlayer](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationplayer/) class is used. This class  takes a [PresentationAnimationsGenerator](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationanimationsgenerator/) instance and FPS for effects in its constructor and then calls the `FrameTick` event for all the animations to get them played:

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

Στη συνέχεια τα παραγόμενα καρέ μπορούν να συναχθούν για την παραγωγή ενός βίντεο. Δείτε την ενότητα [Μετατροπή PowerPoint σε Βίντεο](https://docs.aspose.com/slides/el/php-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Υποστηριζόμενες Κινήσεις και Εφέ**

**Είσοδος**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![μη υποστηριζόμενο](x.png) | ![υποστηριζόμενο](v.png) |
| **Fade** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |
| **Fly In** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |
| **Float In** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |
| **Split** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |
| **Wipe** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |
| **Shape** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |
| **Wheel** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |
| **Random Bars** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |
| **Grow & Turn** | ![μη υποστηριζόμενο](x.png) | ![υποστηριζόμενο](v.png) |
| **Zoom** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |
| **Swivel** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |
| **Bounce** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |

**Τονισμός**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![μη υποστηριζόμενο](x.png) | ![υποστηριζόμενο](v.png) |
| **Color Pulse** | ![μη υποστηριζόμενο](x.png) | ![υποστηριζόμενο](v.png) |
| **Teeter** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |
| **Spin** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |
| **Grow/Shrink** | ![μη υποστηριζόμενο](x.png) | ![υποστηριζόμενο](v.png) |
| **Desaturate** | ![μη υποστηριζόμενο](x.png) | ![υποστηριζόμενο](v.png) |
| **Darken** | ![μη υποστηριζόμενο](x.png) | ![υποστηριζόμενο](v.png) |
| **Lighten** | ![μη υποστηριζόμενο](x.png) | ![υποστηριζόμενο](v.png) |
| **Transparency** | ![μη υποστηριζόμενο](x.png) | ![υποστηριζόμενο](v.png) |
| **Object Color** | ![μη υποστηριζόμενο](x.png) | ![υποστηριζόμενο](v.png) |
| **Complementary Color** | ![μη υποστηριζόμενο](x.png) | ![υποστηριζόμενο](v.png) |
| **Line Color** | ![μη υποστηριζόμενο](x.png) | ![υποστηριζόμενο](v.png) |
| **Fill Color** | ![μη υποστηριζόμενο](x.png) | ![υποστηριζόμενο](v.png) |

**Έξοδος**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![μη υποστηριζόμενο](x.png) | ![υποστηριζόμενο](v.png) |
| **Fade** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |
| **Fly Out** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |
| **Float Out** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |
| **Split** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |
| **Wipe** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |
| **Shape** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |
| **Random Bars** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |
| **Shrink & Turn** | ![μη υποστηριζόμενο](x.png) | ![υποστηριζόμενο](v.png) |
| **Zoom** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |
| **Swivel** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |
| **Bounce** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |

**Διαδρομές κίνησης**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |
| **Arcs** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |
| **Turns** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |
| **Shapes** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |
| **Loops** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |
| **Custom Path** | ![υποστηριζόμενο](v.png) | ![υποστηριζόμενο](v.png) |

## **Συχνές Ερωτήσεις**

**Μπορεί να μετατραπεί παρουσίαση που προστατεύεται με κωδικό;**

Ναι, το Aspose.Slides επιτρέπει εργασία με [παρουσιάσεις με κωδικό πρόσβασης](/slides/el/php-java/password-protected-presentation/). Κατά την επεξεργασία τέτοιων αρχείων, πρέπει να παρέχετε τον σωστό κωδικό ώστε η βιβλιοθήκη να μπορεί να έχει πρόσβαση στο περιεχόμενο της παρουσίασης.

**Υποστηρίζει το Aspose.Slides χρήση σε λύσεις cloud;**

Ναι, το Aspose.Slides μπορεί να ενσωματωθεί σε cloud εφαρμογές και υπηρεσίες. Η βιβλιοθήκη έχει σχεδιαστεί για λειτουργία σε περιβάλλοντα διακομιστών, εξασφαλίζοντας υψηλή απόδοση και κλιμακούμενη επεξεργασία αρχείων σε δέσμες.

**Υπάρχουν περιορισμοί μεγέθους για τις παρουσιάσεις κατά τη μετατροπή;**

Το Aspose.Slides είναι ικανό να διαχειριστεί παρουσιάσεις σχεδόν οποιουδήποτε μεγέθους. Ωστόσο, όταν εργάζεστε με πολύ μεγάλα αρχεία, μπορεί να απαιτηθούν πρόσθετοι πόροι συστήματος, και ενδέχεται να συνιστάται η βελτιστοποίηση της παρουσίασης για καλύτερη απόδοση.