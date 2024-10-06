---
title: Animation de Forme
type: docs
weight: 60
url: /php-java/shape-animation/
keywords: "animation PowerPoint, effet d'animation, appliquer une animation, présentation PowerPoint, Java, Aspose.Slides pour PHP via Java"
description: "Appliquer l'animation PowerPoint"
---

Les animations sont des effets visuels qui peuvent être appliqués à des textes, des images, des formes ou des [graphique](https://docs.aspose.com/slides/php-java/animated-charts/). Elles donnent vie aux présentations ou à ses composants.

### **Pourquoi utiliser des animations dans les présentations ?**

En utilisant des animations, vous pouvez

* contrôler le flux d'informations
* souligner des points importants
* augmenter l'intérêt ou la participation de votre audience
* rendre le contenu plus facile à lire, assimiler ou traiter
* attirer l'attention de vos lecteurs ou spectateurs sur des parties importantes d'une présentation

PowerPoint fournit de nombreuses options et outils pour les animations et les effets d'animation dans les catégories **entrée**, **sortie**, **emphase**, et **trajets de mouvement**.

### **Animations dans Aspose.Slides**

* Aspose.Slides fournit les classes et types nécessaires pour travailler avec les animations sous l'espace de noms `Aspose.Slides.Animation`,
* Aspose.Slides fournit plus de **150 effets d'animation** sous l'énumération [EffectType](https://reference.aspose.com/slides/php-java/aspose.slides/effecttype). Ces effets sont essentiellement les mêmes (ou équivalents) que ceux utilisés dans PowerPoint.

## **Appliquer une animation à TextBox**

Aspose.Slides pour PHP via Java vous permet d'appliquer une animation au texte d'une forme.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez une référence à une diapositive par son index.
3. Ajoutez une forme `rectangle` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape).
4. Ajoutez du texte à [IAutoShape.TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Obtenez une séquence principale d'effets.
6. Ajoutez un effet d'animation à [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape).
7. Définissez la propriété `TextAnimation.BuildType` sur la valeur de l'énumération `BuildType`.
8. Enregistrez la présentation sur disque en tant que fichier PPTX.

Ce code PHP vous montre comment appliquer l'effet `Fade` à AutoShape et définir l'animation de texte sur la valeur *Par 1er niveau de paragraphes* :

```php
  # Instancie une classe de présentation qui représente un fichier de présentation.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Ajoute une nouvelle AutoShape avec du texte
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Premier paragraphe \nDeuxième paragraphe \n Troisième paragraphe");
    # Obtient la séquence principale de la diapositive.
    $sequence = $sld->getTimeline()->getMainSequence();
    # Ajoute un effet d'animation de fondu à la forme
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # Anime le texte de la forme par les paragraphes de 1er niveau
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # Enregistre le fichier PPTX sur disque
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

En plus d'appliquer des animations au texte, vous pouvez également appliquer des animations à un seul [Paragraphe](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph). Voir [**Texte animé**](/slides/php-java/animated-text/).

{{% /alert %}} 

## **Appliquer une animation à PictureFrame**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez une référence à une diapositive par son index.
3. Ajoutez ou obtenez un [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe) sur la diapositive.
4. Obtenez la séquence principale d'effets.
5. Ajoutez un effet d'animation à [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe).
6. Enregistrez la présentation sur disque en tant que fichier PPTX.

Ce code PHP vous montre comment appliquer l'effet `Fly` à un cadre d'image :

```php
  # Instancie une classe de présentation qui représente un fichier de présentation.
  $pres = new Presentation();
  try {
    # Charge l'image à ajouter dans la collection d'images de présentation
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Ajoute un cadre d'image à la diapositive
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # Obtient la séquence principale de la diapositive.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Ajoute un effet d'animation de vol depuis la gauche au cadre d'image
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # Enregistre le fichier PPTX sur disque
    $pres->save($path . "AnimImage_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Appliquer une animation à une forme**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez une référence à une diapositive par son index.
3. Ajoutez une forme `rectangle` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape).
4. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape) `Bevel` (lorsque cet objet est cliqué, l'animation se joue).
5. Créez une séquence d'effets sur la forme bevel.
6. Créez un `UserPath` personnalisé.
7. Ajoutez des commandes pour se déplacer vers le `UserPath`.
8. Enregistrez la présentation sur disque en tant que fichier PPTX.

Ce code PHP vous montre comment appliquer l'effet `PathFootball` à une forme :

```php
  # Instancie une classe de présentation qui représente un fichier PPTX.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Crée l'effet PathFootball pour une forme existante à partir de zéro.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Boîte de texte animée");
    # Ajoute l'effet d'animation PathFootBall
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Crée une sorte de "bouton".
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # Crée une séquence d'effets pour ce bouton.
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # Crée un chemin utilisateur personnalisé. Notre objet sera déplacé uniquement après le clic sur le bouton.
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # Ajoute des commandes de mouvement puisque le chemin créé est vide.
    $motionBhv = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBhv->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # Écrit le fichier PPTX sur disque
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obtenir les effets d'animation appliqués à une forme**

Vous pouvez décider de découvrir tous les effets d'animation appliqués à une seule forme.

Ce code PHP vous montre comment obtenir tous les effets appliqués à une forme spécifique :

```php
  # Instancie une classe de présentation qui représente un fichier de présentation.
  $pres = new Presentation("AnimExample_out.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Obtient la séquence principale de la diapositive.
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # Obtient la première forme sur la diapositive.
    $shape = $firstSlide->getShapes()->get_Item(0);
    # Obtient tous les effets d'animation appliqués à la forme.
    $shapeEffects = $sequence->getEffectsByShape($shape);
    if (java_values($Array->getLength($shapeEffects)) > 0) {
      echo("La forme " . $shape->getName() . " a " . $Array->getLength($shapeEffects) . " effets d'animation.");
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Modifier les propriétés de timing de l'effet d'animation**

Aspose.Slides pour PHP via Java vous permet de modifier les propriétés de timing d'un effet d'animation.

Voici le panneau de timing d'animation dans Microsoft PowerPoint :

![example1_image](shape-animation.png)

Voici les correspondances entre le timing PowerPoint et les propriétés [Effect.Timing](https://reference.aspose.com/slides/php-java/aspose.slides/IEffect#getTiming--) :

- La liste déroulante de timing PowerPoint **Début** correspond à la propriété [Effect.Timing.TriggerType](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getTriggerType--) .
- La **Durée** du timing PowerPoint correspond à la propriété [Effect.Timing.Duration](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getDuration--). La durée d'une animation (en secondes) est le temps total qu'il faut à l'animation pour compléter un cycle.
- La **Délai** du timing PowerPoint correspond à la propriété [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getTriggerDelayTime--).

Voici comment modifier les propriétés de timing de l'effet :

1. [Appliquez](#apply-animation-to-shape) ou obtenez l'effet d'animation.
2. Définissez de nouvelles valeurs pour les propriétés [Effect.Timing](https://reference.aspose.com/slides/php-java/aspose.slides/IEffect#getTiming--) dont vous avez besoin.
3. Enregistrez le fichier PPTX modifié.

Ce code PHP démontre l'opération :

```php
  # Instancie une classe de présentation qui représente un fichier de présentation.
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Obtient la séquence principale de la diapositive.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Obtient le premier effet de la séquence principale.
    $effect = $sequence->get_Item(0);
    # Modifie le TriggerType de l'effet pour démarrer au clic
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # Modifie la durée de l'effet
    $effect->getTiming()->setDuration(3.0);
    # Modifie le TriggerDelayTime de l'effet
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # Enregistre le fichier PPTX sur disque
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Son de l'effet d'animation**

Aspose.Slides fournit ces propriétés pour vous permettre de travailler avec des sons dans des effets d'animation :

- [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Ajouter un son d'effet d'animation**

Ce code PHP vous montre comment ajouter un son d'effet d'animation et l'arrêter lorsque le prochain effet commence :

```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Ajoute de l'audio à la collection audio de la présentation
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;
    try {
      $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "sampleaudio.wav"));
      $bytes = $Array->newInstance($Byte, $dis->available());
      $dis->readFully($bytes);
    } finally {
      if (!java_is_null($dis)) $dis->close();
    }
    $effectSound = $pres->getAudios()->addAudio($bytes);

    $firstSlide = $pres->getSlides()->get_Item(0);
    # Obtient la séquence principale de la diapositive.
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # Obtient le premier effet de la séquence principale
    $firstEffect = $sequence->get_Item(0);
    # Vérifie l'effet pour "Aucun son"
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # Ajoute le son pour le premier effet
      $firstEffect->setSound($effectSound);
    }
    # Obtient la première séquence interactive de la diapositive.
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # Définit le drapeau "Arrêter le son précédent" de l'effet
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # Écrit le fichier PPTX sur disque
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Extraire le son de l'effet d'animation**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Obtenez une référence à une diapositive par son index. 
3. Obtenez la séquence principale d'effets. 
4. Extraire le [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) intégré à chaque effet d'animation.

Ce code PHP vous montre comment extraire le son incorporé dans un effet d'animation :

```php
  # Instancie une classe de présentation qui représente un fichier de présentation.
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Obtient la séquence principale de la diapositive.
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # Extrait le son de l'effet dans un tableau d'octets
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Après l'animation**

Aspose.Slides pour PHP via Java vous permet de modifier la propriété Après l'animation d'un effet d'animation.

Voici le panneau d'effet d'animation et le menu étendu dans Microsoft PowerPoint :

![example1_image](shape-after-animation.png)

La liste déroulante **Après l'animation** de l'effet PowerPoint correspond à ces propriétés :

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAfterAnimationType-int-) qui décrit le type après animation :
  * **Plus de couleurs** PowerPoint correspond au type [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color) ;
  * L'élément de liste de PowerPoint **Ne pas atténuer** correspond au type [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#DoNotDim) (type d'animation après défaut) ;
  * L'élément **Cacher après l'animation** de PowerPoint correspond au type [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation) ;
  * L'élément **Masquer au prochain clic de souris** de PowerPoint correspond au type [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick) ;
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) qui définit un format de couleur après animation. Cette propriété fonctionne en conjonction avec le type [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color). Si vous changez le type pour un autre, la couleur après animation sera effacée.

Ce code PHP vous montre comment modifier un effet d'animation après :

```php
  # Instancie une classe de présentation qui représente un fichier de présentation
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Obtient le premier effet de la séquence principale
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Change le type d'animation après en couleur
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # Définit la couleur d'atténuation après animation
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # Écrit le fichier PPTX sur disque
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animer le texte**

Aspose.Slides fournit ces propriétés pour vous permettre de travailler avec le bloc *Animer le texte* d'un effet d'animation :

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAnimateTextType-int-) qui décrit un type d'animation du texte de l'effet. Le texte de la forme peut être animé :
  - Tout en une fois ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#AllAtOnce) type)
  - Par mot ([AnimateTextType::ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByWord) type)
  - Par lettre ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByLetter) type)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setDelayBetweenTextParts-float-) définit un délai entre les parties de texte animées (mots ou lettres). Une valeur positive spécifie le pourcentage de la durée de l'effet. Une valeur négative spécifie le délai en secondes.

Voici comment vous pouvez modifier les propriétés d'effet Animer le texte :

1. [Appliquez](#apply-animation-to-shape) ou obtenez l'effet d'animation.
2. Définissez la propriété [setBuildType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/itextanimation/#setBuildType-int-) sur la valeur [BuildType::AsOneObject](https://reference.aspose.com/slides/php-java/aspose.slides/buildtype/#AsOneObject) pour désactiver le mode d'animation *Par paragraphes*.
3. Définissez de nouvelles valeurs pour les propriétés [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAnimateTextType-int-) et [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setDelayBetweenTextParts-float-) .
4. Enregistrez le fichier PPTX modifié.

Ce code PHP démontre l'opération :

```php
  # Instancie une classe de présentation qui représente un fichier de présentation.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Obtient le premier effet de la séquence principale
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Change le type d'animation de texte de l'effet sur "En un seul objet"
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # Change le type d'animation de texte de l'effet sur "Par mot"
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # Définit le délai entre les mots à 20 % de la durée de l'effet
    $firstEffect->setDelayBetweenTextParts(20.0);
    # Écrit le fichier PPTX sur disque
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```