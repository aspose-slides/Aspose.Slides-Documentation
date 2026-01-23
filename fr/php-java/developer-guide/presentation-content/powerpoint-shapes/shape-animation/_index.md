---
title: Appliquer des animations de forme dans les présentations avec PHP
linktitle: Animation de forme
type: docs
weight: 60
url: /fr/php-java/shape-animation/
keywords:
- forme
- animation
- effet
- forme animée
- texte animé
- ajouter animation
- obtenir animation
- extraire animation
- ajouter effet
- obtenir effet
- extraire effet
- son d'effet
- appliquer animation
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Découvrez comment créer et personnaliser des animations de forme dans les présentations PowerPoint avec Aspose.Slides pour PHP via Java. Démarquez‑vous !"
---

Les animations sont des effets visuels qui peuvent être appliqués aux textes, images, formes ou [graphes](https://docs.aspose.com/slides/php-java/animated-charts/). Elles donnent vie aux présentations ou à leurs constituants.

## **Pourquoi utiliser les animations dans les présentations ?**

En utilisant les animations, vous pouvez  

* contrôler le flux d’informations  
* mettre en évidence les points importants  
* augmenter l’intérêt ou la participation de votre audience  
* faciliter la lecture, l’assimilation ou le traitement du contenu  
* attirer l’attention de vos lecteurs ou spectateurs sur les parties importantes d’une présentation  

PowerPoint propose de nombreuses options et outils pour les animations et les effets d’animation dans les catégories **entrées**, **sorties**, **accentuation** et **chemins de mouvement**.  

## **Animations dans Aspose.Slides**

* Aspose.Slides fournit les classes et types nécessaires pour travailler avec les animations dans l’espace de noms `Aspose.Slides.Animation`,  
* Aspose.Slides propose plus de **150 effets d’animation** dans l’énumération [EffectType](https://reference.aspose.com/slides/php-java/aspose.slides/effecttype). Ces effets sont essentiellement les mêmes (ou équivalents) que ceux utilisés dans PowerPoint.  

## **Appliquer une animation à une zone de texte**

Aspose.Slides for PHP via Java vous permet d’appliquer une animation au texte d’une forme.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. Obtenez une référence à une diapositive grâce à son indice.  
3. Ajoutez une forme rectangulaire [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).  
4. Ajoutez du texte au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getTextFrame) de l’`AutoShape`.  
5. Récupérez la séquence principale d’effets.  
6. Ajoutez un effet d’animation à l’[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).  
7. Utilisez la méthode `TextAnimation.setBuildType` avec la valeur de l’énumération `BuildType`.  
8. Enregistrez la présentation sur le disque au format PPTX.  

Ce code PHP montre comment appliquer l’effet `Fade` à l’AutoShape et définir l’animation du texte sur la valeur *Par paragraphes de premier niveau* :  
```php
  # Instancie une classe de présentation qui représente un fichier de présentation.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Ajoute une nouvelle AutoShape avec du texte
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("First paragraph \nSecond paragraph \n Third paragraph");
    # Obtient la séquence principale de la diapositive.
    $sequence = $sld->getTimeline()->getMainSequence();
    # Ajoute l'effet d'animation Fade à la forme
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # Anime le texte de la forme par paragraphes de premier niveau
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # Enregistre le fichier PPTX sur le disque
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{%  alert color="primary"  %}}  

En plus d’appliquer des animations au texte, vous pouvez également les appliquer à un seul [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/). Consultez [**Texte animé**](/slides/fr/php-java/animated-text/).  

{{% /alert %}}  

## **Appliquer une animation à un PictureFrame**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. Obtenez une référence à une diapositive grâce à son indice.  
3. Ajoutez ou récupérez un [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe) sur la diapositive.  
4. Récupérez la séquence principale d’effets.  
5. Ajoutez un effet d’animation au [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe).  
6. Enregistrez la présentation sur le disque au format PPTX.  

Ce code PHP montre comment appliquer l’effet `Fly` à un cadre d’image :  
```php
  # Instancie une classe de présentation qui représente un fichier de présentation.
  $pres = new Presentation();
  try {
    # Charge l'image à ajouter à la collection d'images de la présentation
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
    # Ajoute l'effet d'animation Fly depuis la gauche au cadre d'image
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # Enregistre le fichier PPTX sur le disque
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
2. Obtenez une référence à une diapositive grâce à son indice.  
3. Ajoutez une forme rectangulaire [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).  
4. Ajoutez une forme [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) en biseau (quand cet objet est cliqué, l’animation se lance).  
5. Créez une séquence d’effets sur la forme en biseau.  
6. Créez un `UserPath` personnalisé.  
7. Ajoutez des commandes de déplacement vers le `UserPath`.  
8. Enregistrez la présentation sur le disque au format PPTX.  

Ce code PHP montre comment appliquer l’effet `PathFootball` (chemin football) à une forme :  
```php
  # Instancie une classe Presentation qui représente un fichier PPTX.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Crée l'effet PathFootball pour une forme existante à partir de zéro.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animated TextBox");
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
    # Écrit le fichier PPTX sur le disque
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Obtenir les effets d’animation appliqués à une forme**

Les exemples suivants montrent comment utiliser la méthode `getEffectsByShape` de la classe [Sequence](https://reference.aspose.com/slides/php-java/aspose.slides/sequence/) pour obtenir tous les effets d’animation appliqués à une forme.

**Exemple 1 : Obtenir les effets d’animation appliqués à une forme sur une diapositive normale**

Auparavant, vous avez appris comment ajouter des effets d’animation aux formes dans les présentations PowerPoint. Le code ci‑dessous montre comment récupérer les effets appliqués à la première forme de la première diapositive normale du fichier `AnimExample_out.pptx`.  
```php
  $Array = new java_class("java.lang.reflect.Array");
  $presentation = new Presentation("AnimExample_out.pptx");

  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    # Obtient la séquence principale d'animation de la diapositive.
    $sequence = $firstSlide->getTimeline()->getMainSequence();

    # Obtient la première forme sur la première diapositive.
    $shape = $firstSlide->getShapes()->get_Item(0);

    # Obtient les effets d'animation appliqués à la forme.
    $shapeEffects = $sequence->getEffectsByShape($shape);

    if (java_values($Array->getLength($shapeEffects)) > 0) {
      echo("The shape " . $shape->getName() . " has " . $Array->getLength($shapeEffects) . " animation effects.");
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


**Exemple 2 : Obtenir tous les effets d’animation, y compris ceux hérités des espaces réservés**

Si une forme sur une diapositive normale possède des espaces réservés provenant de la diapositive de mise en page et/ou du masque, et que des effets d’animation ont été ajoutés à ces espaces réservés, alors tous les effets de la forme seront joués pendant le diaporama, y compris ceux hérités.

Supposons que nous ayons un fichier de présentation PowerPoint `sample.pptx` contenant une seule diapositive avec uniquement une forme de pied de page affichant le texte « Made with Aspose.Slides » et que l’effet **Random Bars** soit appliqué à cette forme.

![Slide shape animation effect](slide-shape-animation.png)

Supposons également que l’effet **Split** soit appliqué à l’espace réservé du pied de page sur la diapositive **layout**.

![Layout shape animation effect](layout-shape-animation.png)

Et enfin que l’effet **Fly In** soit appliqué à l’espace réservé du pied de page sur la diapositive **master**.

![Master shape animation effect](master-shape-animation.png)

Le code ci‑dessous montre comment utiliser la méthode `getBasePlaceholder` de la classe [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) pour accéder aux espaces réservés de la forme et obtenir les effets d’animation appliqués à la forme du pied de page, y compris ceux hérités des espaces réservés situés sur les diapositives de mise en page et de masque.  
```php
$presentation = new Presentation("sample.pptx");

$slide = $presentation->getSlides()->get_Item(0);

// Obtient les effets d'animation de la forme sur la diapositive normale.
$shape = $slide->getShapes()->get_Item(0);
$shapeEffects = $slide->getTimeline()->getMainSequence()->getEffectsByShape($shape);

// Obtient les effets d'animation du espace réservé sur la diapositive de mise en page.
$layoutShape = $shape->getBasePlaceholder();
$layoutShapeEffects = $slide->getLayoutSlide()->getTimeline()->getMainSequence()->getEffectsByShape($layoutShape);

// Obtient les effets d'animation du espace réservé sur la diapositive maître.
$masterShape = $layoutShape->getBasePlaceholder();
$masterShapeEffects = $slide->getLayoutSlide()->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($masterShape);

echo "Main sequence of shape effects:" . PHP_EOL;
printEffects($masterShapeEffects);
printEffects($layoutShapeEffects);
printEffects($shapeEffects);

$presentation->dispose();
```
  
```php
function printEffects($effects) {
    foreach ($effects as $effect) {
        echo "Type: " . $effect->getType() . ", subtype: " . $effect->getSubtype() . PHP_EOL;
    }
}
```


Sortie :  
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Vol, Bas
Type: 134, subtype: 45            // Diviser, EntréeVerticale
Type: 126, subtype: 22            // BarresAléatoires, Horizontal
```


## **Modifier les méthodes de synchronisation des effets d’animation**

Aspose.Slides for PHP via Java vous permet de modifier les propriétés de synchronisation d’un effet d’animation.

Voici le volet Synchronisation de l’animation dans Microsoft PowerPoint :

![example1_image](shape-animation.png)

Correspondances entre la synchronisation PowerPoint et les propriétés de [Effect Timing](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#getTiming) :

- La liste déroulante **Start** de PowerPoint correspond à la méthode [Timing::getTriggerType](https://reference.aspose.com/slides/php-java/aspose.slides/timing/#getTriggerType).  
- **Duration** correspond à la méthode [Timing::getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/timing/#getDuration). La durée d’une animation (en secondes) est le temps total nécessaire à l’animation pour terminer un cycle.  
- **Delay** correspond à la méthode [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/php-java/aspose.slides/timing/#getTriggerDelayTime).  

Voici comment modifier les propriétés de synchronisation d’un effet :

1. [Appliquer](#apply-animation-to-shape) ou récupérer l’effet d’animation.  
2. Définir les nouvelles valeurs souhaitées à l’aide de la méthode [Effect::getTiming](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#getTiming).  
3. Enregistrer le fichier PPTX modifié.  

Ce code PHP illustre l’opération :  
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
    # Modifie le délai de déclenchement de l'effet
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # Enregistre le fichier PPTX sur le disque
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Son d’un effet d’animation**

Aspose.Slides propose ces méthodes pour travailler avec les sons dans les effets d’animation :  

- [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)  

### **Ajouter un son à un effet d’animation**

Ce code PHP montre comment ajouter un son à un effet d’animation et l’arrêter lorsque l’effet suivant démarre :  
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
      # Ajoute le son au premier effet
      $firstEffect->setSound($effectSound);
    }
    # Obtient la première séquence interactive de la diapositive.
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # Définit le drapeau "Stop previous sound" de l'effet
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # Enregistre le fichier PPTX sur le disque
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Extraire le son d’un effet d’animation**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
2. Obtenez une référence à une diapositive grâce à son indice.  
3. Récupérez la séquence principale d’effets.  
4. Extrayez le son intégré à chaque effet d’animation via la méthode [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-).  

Ce code PHP montre comment extraire le son intégré à un effet d’animation :  
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
      # Extrait le son de l'effet sous forme de tableau d'octets
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Après l’animation**

Aspose.Slides for PHP via Java vous permet de modifier la propriété **After animation** d’un effet d’animation.

Voici le volet Effet d’animation et le menu étendu dans Microsoft PowerPoint :

![example1_image](shape-after-animation.png)

La liste déroulante **After animation** de PowerPoint correspond aux méthodes :  

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setAfterAnimationType) qui décrit le type d’après‑animation :  
  * **More Colors** correspond à [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color) ;  
  * **Don't Dim** correspond à [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#DoNotDim) (type par défaut) ;  
  * **Hide After Animation** correspond à [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation) ;  
  * **Hide on Next Mouse Click** correspond à [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick).  
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setAfterAnimationColor) qui définit le format de couleur après l’animation. Cette méthode fonctionne avec le type [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color). Si vous changez le type, la couleur après l’animation sera réinitialisée.  

Ce code PHP montre comment modifier un effet d’après‑animation :  
```php
  # Instancie une classe de présentation qui représente un fichier de présentation
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Obtient le premier effet de la séquence principale
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Modifie le type d'après‑animation en Couleur
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # Définit la couleur de gradation après l'animation
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # Enregistre le fichier PPTX sur le disque
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Animer le texte**

Aspose.Slides propose ces méthodes pour travailler avec le bloc *Animate text* d’un effet d’animation :  

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setAnimateTextType) qui décrit le type d’animation du texte. Le texte de la forme peut être animé :  
  - Tout d’un coup ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#AllAtOnce))  
  - Mot par mot ([AnimateTextType::ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByWord))  
  - Lettre par lettre ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByLetter))  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setDelayBetweenTextParts) définit un délai entre les parties de texte animées (mots ou lettres). Une valeur positive indique le pourcentage de la durée de l’effet. Une valeur négative indique le délai en secondes.  

Voici comment modifier les propriétés *Animate text* d’un effet :

1. [Appliquer](#apply-animation-to-shape) ou récupérer l’effet d’animation.  
2. Utilisez la méthode [setBuildType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/textanimation/#setBuildType) avec la valeur [BuildType::AsOneObject](https://reference.aspose.com/slides/php-java/aspose.slides/buildtype/#AsOneObject) pour désactiver le mode *Par paragraphes*.  
3. Définissez les nouvelles valeurs avec les méthodes [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setAnimateTextType) et [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setDelayBetweenTextParts).  
4. Enregistrez le fichier PPTX modifié.  

Ce code PHP illustre l’opération :  
```php
  # Instancie une classe de présentation qui représente un fichier de présentation.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Obtient le premier effet de la séquence principale
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Modifie le type d'animation texte de l'effet en "Comme un seul objet"
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # Modifie le type d'animation du texte de l'effet en "Par mot"
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # Définit le délai entre les mots à 20% de la durée de l'effet
    $firstEffect->setDelayBetweenTextParts(20.0);
    # Enregistre le fichier PPTX sur le disque
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Comment garantir que les animations sont conservées lors de la publication de la présentation sur le web ?**  

[Export to HTML5](/slides/fr/php-java/export-to-html5/) et activez les [options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/) responsables des animations de [shape](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimateshapes/) et de [transition](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimatetransitions/). Le HTML simple ne lit pas les animations de diapositive, contrairement au HTML5.  

**Comment le changement de l’ordre Z (couche) des formes affecte‑t‑il les animations ?**  

L’ordre d’animation et l’ordre de dessin sont indépendants : un effet contrôle le moment et le type d’apparition/disparition, tandis que le [z‑order](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getzorderposition/) détermine ce qui recouvre quoi. Le résultat visible est défini par leur combinaison. (C’est le comportement général de PowerPoint ; le modèle Aspose.Slides effets‑et‑formes suit la même logique.)  

**Existe‑t‑il des limites lors de la conversion d’animations en vidéo pour certains effets ?**  

En général, les [animations sont prises en charge](/slides/fr/php-java/convert-powerpoint-to-video/), mais des cas rares ou des effets spécifiques peuvent être rendus différemment. Il est recommandé de tester avec les effets que vous utilisez et avec la version de la bibliothèque.