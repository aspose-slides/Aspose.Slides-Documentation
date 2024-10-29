---
title: Convertir PowerPoint en Vidéo
type: docs
weight: 130
url: /fr/php-java/convert-powerpoint-to-video/
keywords: "Convertir PowerPoint, PPT, PPTX, Présentation, Vidéo, MP4, PPT en vidéo, PPT en MP4, Java, Aspose.Slides"
description: "Convertir PowerPoint en Vidéo "
---

En convertissant votre présentation PowerPoint en vidéo, vous obtenez

* **Augmentation de l'accessibilité :** Tous les appareils (quel que soit le système d'exploitation) sont équipés par défaut de lecteurs vidéo par rapport aux applications d'ouverture de présentation, ce qui permet aux utilisateurs d'ouvrir ou de lire des vidéos plus facilement.
* **Plus de portée :** Grâce aux vidéos, vous pouvez atteindre un large public et lui fournir des informations qui pourraient autrement sembler ennuyeuses dans une présentation. La plupart des enquêtes et des statistiques suggèrent que les gens regardent et consomment plus de vidéos que d'autres formes de contenu, et ils préfèrent généralement ce type de contenu.

{{% alert color="primary" %}}

Vous voudrez peut-être vérifier notre [**Convertisseur en ligne PowerPoint vers Vidéo**](https://products.aspose.app/slides/conversion/ppt-to-word) car il s'agit d'une implémentation efficace et en direct du processus décrit ici.

{{% /alert %}}

## **Conversion de PowerPoint en Vidéo dans Aspose.Slides**

Dans [Aspose.Slides 22.11](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-22-11-release-notes/), nous avons mis en œuvre la prise en charge de la conversion de présentation en vidéo.

* Utilisez **Aspose.Slides** pour générer un ensemble d'images (à partir des diapositives de présentation) qui correspondent à un certain FPS (images par seconde).
* Utilisez un utilitaire tiers comme **ffmpeg** ([pour java](https://github.com/bramp/ffmpeg-cli-wrapper)) pour créer une vidéo basée sur les images.

### **Convertir PowerPoint en Vidéo**

1. Ajoutez ceci à votre fichier POM :
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```php

```

2. Téléchargez ffmpeg [ici](https://ffmpeg.org/download.html).

4. Exécutez le code PHP pour convertir PowerPoint en vidéo.

Ce code PHP vous montre comment convertir une présentation (contenant une figure et deux effets d'animation) en vidéo :

```php
  $presentation = new Presentation();
  try {
    # Ajoute une forme de sourire et anime ensuite
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
    # Configurez le dossier des fichiers binaires ffmpeg. Consultez cette page : https://github.com/rosenbjerg/FFMpegCore#installation
    $ffmpeg = new Java("net.bramp.ffmpeg.builder.FFmpeg", "path/to/ffmpeg");
    $ffprobe = new Java("net.bramp.ffmpeg.builder.FFprobe", "path/to/ffprobe");
    $builder = (new Java("net.bramp.ffmpeg.builder.FFmpegBuilder"))->addExtraArgs("-start_number", "1")->setInput("frame_%04d.png")->addOutput("output.avi")->setVideoFrameRate(FFmpeg->FPS_24)->setFormat("avi")->done();
    $executor = new Java("net.bramp.ffmpeg.builder.FFmpegExecutor", $ffmpeg, $ffprobe);
    $executor->createJob($builder)->run();
  } catch (JavaException $e) {
    $e->printStackTrace();
  }
```

## **Effets Vidéo**

Vous pouvez appliquer des animations aux objets sur les diapositives et utiliser des transitions entre les diapositives.

{{% alert color="primary" %}}

Vous voudrez peut-être consulter ces articles : [Animation PowerPoint](https://docs.aspose.com/slides/php-java/powerpoint-animation/), [Animation de Forme](https://docs.aspose.com/slides/php-java/shape-animation/), et [Effet de Forme](https://docs.aspose.com/slides/php-java/shape-effect/).

{{% /alert %}}

Les animations et les transitions rendent les diaporamas plus engageants et intéressants – et elles font la même chose pour les vidéos. Ajoutons une autre diapositive et une transition au code de la présentation précédente :

```php
  # Ajoute une forme de sourire et l'anime
  # ...
  # Ajoute une nouvelle diapositive et une transition animée
  $newSlide = $presentation->getSlides()->addEmptySlide($presentation->getSlides()->get_Item(0)->getLayoutSlide());
  $newSlide->getBackground()->setType(BackgroundType::OwnBackground);
  $newSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
  $newSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
  $newSlide->getSlideShowTransition()->setType(TransitionType::Push);

```

Aspose.Slides prend également en charge l'animation des textes. Ainsi, nous animons des paragraphes sur des objets, qui apparaîtront les uns après les autres (avec un délai d'une seconde) :

```php
  $presentation = new Presentation();
  try {
    # Ajoute du texte et des animations
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 120, 300, 300);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Aspose Slides pour Java"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("convertir la présentation PowerPoint avec texte en vidéo"));
    $para3 = new Paragraph();
    $para3->getPortions()->add(new Portion("paragraphe par paragraphe"));
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
    # Configurez le dossier des fichiers binaires ffmpeg. Consultez cette page : https://github.com/rosenbjerg/FFMpegCore#installation
    $ffmpeg = new Java("net.bramp.ffmpeg.builder.FFmpeg", "path/to/ffmpeg");
    $ffprobe = new Java("net.bramp.ffmpeg.builder.FFprobe", "path/to/ffprobe");
    $builder = (new Java("net.bramp.ffmpeg.builder.FFmpegBuilder"))->addExtraArgs("-start_number", "1")->setInput("frame_%04d.png")->addOutput("output.avi")->setVideoFrameRate(FFmpeg->FPS_24)->setFormat("avi")->done();
    $executor = new Java("net.bramp.ffmpeg.builder.FFmpegExecutor", $ffmpeg, $ffprobe);
    $executor->createJob($builder)->run();
  } catch (JavaException $e) {
    $e->printStackTrace();
  }
```

## **Classes de Conversion Vidéo**

Pour vous permettre d'effectuer des tâches de conversion PowerPoint en vidéo, Aspose.Slides fournit les classes [PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) et [PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) vous permet de définir la taille de l'image pour la vidéo (qui sera créée plus tard) via son constructeur. Si vous passez une instance de la présentation, `Presentation.SlideSize` sera utilisée et elle génère des animations que [PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/) utilise.

Lorsque les animations sont générées, un événement `NewAnimation` est généré pour chaque animation suivante, qui a le paramètre [IPresentationAnimationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/). Ce dernier est une classe qui représente un lecteur pour une animation séparée.

Pour travailler avec [IPresentationAnimationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/), les propriétés [Duration](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/#getDuration--) (la durée totale de l'animation) et la méthode [SetTimePosition](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) sont utilisées. Chaque position d'animation est définie dans la plage *0 à duration*, puis la méthode `GetFrame` renverra un BufferedImage qui correspond à l'état de l'animation à ce moment :

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
        echo(sprintf("Durée totale de l'animation : %f", $animationPlayer->getDuration()));
        $animationPlayer->setTimePosition(0);// état initial de l'animation
        try {
            # bitmap de l'état initial de l'animation
            $animationPlayer->getFrame()->save("firstFrame.png", ImageFormat::Png);
        } catch (JavaException $e) {
        }
        $animationPlayer->setTimePosition($animationPlayer->getDuration());// état final de l'animation
        try {
            # dernière image de l'animation
            $animationPlayer->getFrame()->save("lastFrame.png", ImageFormat::Png);
        } catch (JavaException $e) {
        }
    }
}
$presentation = new Presentation();
try {
    # Ajoute une forme de sourire et l'anime
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

Pour faire jouer toutes les animations d'une présentation en même temps, la classe [PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/) est utilisée. Cette classe prend une instance de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) et des FPS pour les effets dans son constructeur, puis appelle l'événement `FrameTick` pour toutes les animations afin de les lire :

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

Ensuite, les images générées peuvent être compilées pour produire une vidéo. Voir la section [Convertir PowerPoint en Vidéo](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animations et Effets Pris en Charge**

**Entrée** :

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Apparaître** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Estomper** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Voler** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Flotter** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Diviser** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Balayer** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Forme** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Roue** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Barres Aléatoires** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Grandir & Tourner** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Zoom** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Tournoyer** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Rebondir** | ![pris en charge](v.png) | ![pris en charge](v.png) |

**Accentuation** :

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulser** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Pulse de Couleur** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Se Balancer** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Tourner** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Grandir/Rétrécir** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Désaturer** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Assombrir** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Éclaircir** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Transparence** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Couleur d'Objet** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Couleur Complémentaire** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Couleur de Ligne** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Couleur de Remplissage** | ![non pris en charge](x.png) | ![pris en charge](v.png) |

**Sortie** :

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disparaître** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Estomper** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Voler Hors** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Flotter Hors** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Diviser** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Balayer** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Forme** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Barres Aléatoires** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Réduire & Tourner** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Zoom** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Tournoyer** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Rebondir** | ![pris en charge](v.png) | ![pris en charge](v.png) |

**Trajets de Mouvement :**

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lignes** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Arcs** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Virages** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Formes** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Boucles** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Chemin Personnalisé** | ![pris en charge](v.png) | ![pris en charge](v.png) |