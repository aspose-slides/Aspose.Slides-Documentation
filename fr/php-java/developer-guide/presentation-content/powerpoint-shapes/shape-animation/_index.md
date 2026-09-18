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
description: "Apprenez à ajouter, inspecter et personnaliser les animations de forme, la synchronisation, les sons, le comportement après l'animation et le texte animé avec Aspose.Slides pour PHP via Java."
---
## **Vue d'ensemble**

Pour travailler avec les comportements individuels à l'intérieur d'un effet ou modifier des segments de trajectoire de mouvement, voir [Custom Animation](/slides/fr/php-java/custom-animation/).

Aspose.Slides for PHP via Java représente les animations de diapositives sous forme d'effets dans une chronologie de diapositive. Un effet possède une forme cible, un type et un sous‑type d'animation, un déclencheur, des paramètres de synchronisation et des propriétés optionnelles telles que le son ou le comportement après l'animation.

La chronologie contient deux types de séquences :

- La **séquence principale** se lit au fur et à mesure que la diapositive avance.
- Une **séquence interactive** démarre lorsque sa forme déclencheur est cliquée.

Comme les zones de texte, les images, les graphiques, les tableaux et les autres objets de diapositive sont des formes, vous utilisez la même méthode [Sequence::addEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sequence/addeffect/) pour la plupart du contenu de diapositive. Les effets disponibles sont répertoriés dans la classe [EffectType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/effecttype/).

## **Ajouter des animations de forme**

Pour ajouter une animation, récupérez la séquence principale de la diapositive et appelez [Sequence::addEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sequence/addeffect/) avec la forme cible, le type d'effet, le sous‑type et le déclencheur. Pour un effet qui démarre lorsqu'une autre forme est cliquée, créez une séquence interactive dont le déclencheur est cette autre forme.

L'exemple suivant crée les deux types d'animation et enregistre le résultat dans `shape-animations.pptx`.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 120, 100, 320, 80);
    $targetShape->addTextFrame("Click to animate this shape");

    $mainSequence = $slide->getTimeline()->getMainSequence();
    $entranceEffect = $mainSequence->addEffect($targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $entranceEffect->getTiming()->setDuration(1.5);

    $triggerShape = $slide->getShapes()->addAutoShape(ShapeType::Bevel, 20, 20, 100, 40);
    $triggerShape->addTextFrame("Move");

    $interactiveSequence = $slide->getTimeline()->getInteractiveSequences()->add($triggerShape);
    $interactiveSequence->addEffect($targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

    $presentation->save("shape-animations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le déclencheur contrôle le moment où un effet démarre :

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/fr/php-java/aspose.slides/effecttriggertype/) attend un clic dans la séquence principale, ou un clic sur la forme déclencheur dans une séquence interactive.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/fr/php-java/aspose.slides/effecttriggertype/) démarre avec l'effet précédent.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/fr/php-java/aspose.slides/effecttriggertype/) démarre lorsque l'effet précédent se termine.

Pour animer une image, un graphique ou un autre type de forme, passez cet objet à [Sequence::addEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sequence/addeffect/) au lieu de `$targetShape`. Pour des options de groupement spécifiques aux graphiques, consultez [Animated Charts](/slides/fr/php-java/animated-charts/).

## **Lire les animations de forme**

Utilisez [Sequence::getEffectsByShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sequence/geteffectsbyshape/) lorsque vous connaissez la forme cible. Pour inspecter chaque effet, énumérez la séquence principale et chaque séquence interactive. L'énumération évite de supposer qu'une séquence contient un effet à l'index `0`.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function printSequence($label, $sequence)
{
    $effectCount = java_values($sequence->getCount());

    echo "  " . $label . ": " . $effectCount . " effect(s)" . PHP_EOL;

    for ($effectIndex = 0; $effectIndex < $effectCount; $effectIndex++) {
        $effect = $sequence->get_Item($effectIndex);
        $targetShape = $effect->getTargetShape();
        $targetName = java_is_null($targetShape) ? "unknown" : java_values($targetShape->getName());
        $effectType = java_values($effect->getType());
        $effectSubtype = java_values($effect->getSubtype());
        $triggerType = java_values($effect->getTiming()->getTriggerType());
        echo "    type: " . $effectType . "; subtype: " . $effectSubtype . "; target: " . $targetName . "; trigger: " . $triggerType . PHP_EOL;
    }
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $targetShape->addTextFrame("Animated shape");

    $mainSequence = $slide->getTimeline()->getMainSequence();
    $mainSequence->addEffect($targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    $triggerShape = $slide->getShapes()->addAutoShape(ShapeType::Bevel, 20, 20, 100, 40);
    $triggerShape->addTextFrame("Move");

    $interactiveSequence = $slide->getTimeline()->getInteractiveSequences()->add($triggerShape);
    $interactiveSequence->addEffect($targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

    $targetEffects = $mainSequence->getEffectsByShape($targetShape);
    $Array = new JavaClass("java.lang.reflect.Array");
    echo "The main sequence contains " . java_values($Array->getLength($targetEffects)) . " effect(s) for " . java_values($targetShape->getName()) . "." . PHP_EOL;

    printSequence("Main sequence", $mainSequence);

    $interactiveSequences = $slide->getTimeline()->getInteractiveSequences();
    $interactiveCount = java_values($interactiveSequences->getCount());
    for ($interactiveIndex = 0; $interactiveIndex < $interactiveCount; $interactiveIndex++) {
        $sequence = $interactiveSequences->get_Item($interactiveIndex);
        $sequenceTrigger = $sequence->getTriggerShape();
        $triggerName = java_is_null($sequenceTrigger) ? "unknown" : java_values($sequenceTrigger->getName());
        printSequence("Interactive sequence " . ($interactiveIndex + 1) . ", trigger: " . $triggerName, $sequence);
    }
} finally {
    $presentation->dispose();
}
```

Si vous avez seulement besoin des effets d'une forme, identifiez d'abord la forme par son nom, son type de zone réservée ou une autre propriété stable ; puis appelez [Sequence::getEffectsByShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sequence/geteffectsbyshape/). Ne supposez pas que [ShapeCollection::get_Item](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapecollection/get_item/) à l'index `0` soit toujours l'objet prévu.

## **Travailler avec les effets de zones réservées hérités**

Une zone réservée sur une diapositive normale peut hériter du comportement d'animation de la zone réservée correspondante sur sa diapositive de disposition et sa diapositive maîtresse. [Shape::getBasePlaceholder](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/getbaseplaceholder/) renvoie cette zone réservée parent, ou `null` lorsqu'aucun parent n'existe.

Dans la présentation d'exemple suivante, le pied de page possède **Random Bars** sur la diapositive normale, **Split** sur la diapositive de disposition et **Fly In** sur la diapositive maîtresse.

![Effet d'animation du pied de page sur la diapositive normale](slide-shape-animation.png)

![Effet d'animation de la zone réservée du pied de page sur la diapositive de disposition](layout-shape-animation.png)

![Effet d'animation de la zone réservée du pied de page sur la diapositive maîtresse](master-shape-animation.png)

L'exemple suivant utilise une hiérarchie de zones réservées provenant d'une nouvelle présentation. Il ajoute des effets à une zone réservée maîtresse, une zone réservée de disposition et la zone réservée correspondante sur une diapositive normale. Chaque appel à [Shape::getBasePlaceholder](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/getbaseplaceholder/) est vérifié avant d'utiliser la forme renvoyée.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

function findLayoutPlaceholderWithBase($layoutSlide)
{
    $shapes = $layoutSlide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_is_null($shape->getBasePlaceholder())) {
            return $shape;
        }
    }

    return null;
}

function findSlidePlaceholderWithBase($slide, $expectedBase)
{
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $basePlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($basePlaceholder) && java_values($basePlaceholder->equals($expectedBase))) {
            return $shape;
        }
    }

    return null;
}

function printEffects($source, $effects)
{
    $Array = new JavaClass("java.lang.reflect.Array");
    echo $source . ": " . java_values($Array->getLength($effects)) . " effect(s)" . PHP_EOL;

    foreach ($effects as $effect) {
        echo "  type: " . java_values($effect->getType()) . "; subtype: " . java_values($effect->getSubtype()) . PHP_EOL;
    }
}

$presentation = new Presentation();
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);
    $layoutPlaceholder = findLayoutPlaceholderWithBase($layoutSlide);

    if ($layoutPlaceholder === null) {
        throw new RuntimeException("The layout slide does not contain a placeholder linked to its master slide.");
    }

    $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
    $layoutSlide->getMasterSlide()->getTimeline()->getMainSequence()->addEffect($masterPlaceholder, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
    $layoutSlide->getTimeline()->getMainSequence()->addEffect($layoutPlaceholder, EffectType::Split, EffectSubtype::VerticalIn, EffectTriggerType::OnClick);

    $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $slidePlaceholder = findSlidePlaceholderWithBase($slide, $layoutPlaceholder);

    if ($slidePlaceholder === null) {
        throw new RuntimeException("The slide does not contain a placeholder linked to its layout slide.");
    }

    $slide->getTimeline()->getMainSequence()->addEffect($slidePlaceholder, EffectType::RandomBars, EffectSubtype::Horizontal, EffectTriggerType::OnClick);
    printEffects("Normal slide", $slide->getTimeline()->getMainSequence()->getEffectsByShape($slidePlaceholder));

    $baseLayoutPlaceholder = $slidePlaceholder->getBasePlaceholder();
    if (!java_is_null($baseLayoutPlaceholder)) {
        printEffects("Layout slide", $layoutSlide->getTimeline()->getMainSequence()->getEffectsByShape($baseLayoutPlaceholder));

        $baseMasterPlaceholder = $baseLayoutPlaceholder->getBasePlaceholder();
        if (!java_is_null($baseMasterPlaceholder)) {
            printEffects("Master slide", $layoutSlide->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($baseMasterPlaceholder));
        }
    }

    $presentation->save("placeholder-animations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Modifier la synchronisation des animations**

La boîte de dialogue **Timing** de PowerPoint correspond aux propriétés de [Timing](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/).

![Boîte de dialogue Timing de PowerPoint pour un effet d'animation](shape-animation.png)

- **Démarrage** correspond à [Timing::getTriggerType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/gettriggertype/).
- **Durée** correspond à [Timing::getDuration](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/getduration/), en secondes.
- **Retard** correspond à [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/gettriggerdelaytime/), en secondes.
- **Répéter** correspond à [Timing::getRepeatCount](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/getrepeatcount/), [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/getrepeatuntilnextclick/), ou [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/getrepeatuntilendslide/).
- **Rembobiner à la fin** correspond à [Timing::getRewind](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/getrewind/).

Cet exemple indépendant ajoute un effet, modifie sa synchronisation via l'objet renvoyé par [Sequence::addEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sequence/addeffect/), puis enregistre le résultat. Conserver la référence renvoyée à [Effect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/effect/) évite un accès inutile par indice de collection.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $shape->addTextFrame("Timed animation");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    $effect->getTiming()->setDuration(2.0);
    $effect->getTiming()->setTriggerDelayTime(0.5);
    $effect->getTiming()->setRepeatUntilNextClick(false);
    $effect->getTiming()->setRepeatUntilEndSlide(false);
    $effect->getTiming()->setRepeatCount(2.0);
    $effect->getTiming()->setRewind(true);

    $presentation->save("shape-animation-timing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Utilisez un seul mode de répétition intentionnellement. Combiner un compte de répétition avec un indicateur « until » peut produire des résultats déroutants dans différents lecteurs. Lors du changement de mode de répétition, définissez d'abord [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/setrepeatuntilnextclick/) et [Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/setrepeatuntilendslide/) avant [Timing::setRepeatCount](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/setrepeatcount/), car la définition de l'un de ces indicateurs modifie également le mode de répétition actif.

## **Ajouter et extraire des sons d'animation**

Un effet d'animation peut référencer un audio intégré via [Effect::getSound](https://reference.aspose.com/slides/fr/php-java/aspose.slides/effect/getsound/). [Effect::setStopPreviousSound](https://reference.aspose.com/slides/fr/php-java/aspose.slides/effect/setstopprevioussound/) indique à un effet d'arrêter le son démarré par un effet antérieur.

### **Ajouter un son à un effet**

L'exemple suivant attend un fichier audio local nommé `animation-sound.wav`. Il crée deux effets, intègre ce fichier comme son du premier effet et configure le deuxième effet pour arrêter le son. Il utilise les objets renvoyés par [Sequence::addEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sequence/addeffect/), aucune indexation de séquence n'est requise.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$Files = new JavaClass("java.nio.file.Files");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 100, 240, 80);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 400, 100, 240, 80);
    $firstShape->addTextFrame("Starts sound");
    $secondShape->addTextFrame("Stops sound");

    $sequence = $slide->getTimeline()->getMainSequence();
    $firstEffect = $sequence->addEffect($firstShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $secondEffect = $sequence->addEffect($secondShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    $baseDirectory = getcwd();
    $audioPath = (new Java("java.io.File", $baseDirectory . DIRECTORY_SEPARATOR . "animation-sound.wav"))->toPath();
    $audioData = $Files->readAllBytes($audioPath);
    $effectSound = $presentation->getAudios()->addAudio($audioData);
    $firstEffect->setSound($effectSound);
    $secondEffect->setStopPreviousSound(true);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "shape-animation-sound.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Extraire les sons intégrés d'un effet**

L'exemple suivant attend une présentation locale nommée `presentation-with-animation-sounds.pptx`. Il parcourt les séquences principales et interactives et écrit chaque son d'effet intégré dans le répertoire `extracted-animation-sounds`. L'extension est sélectionnée à partir du type MIME audio exposé par [Audio::getContentType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/audio/getcontenttype/).

```php
use aspose\slides\Presentation;

function getAudioExtension($contentType)
{
    $normalizedType = strtolower($contentType === null ? "" : java_values($contentType));

    if ($normalizedType === "audio/mpeg") {
        return ".mp3";
    }

    if ($normalizedType === "audio/mp4") {
        return ".m4a";
    }

    if ($normalizedType === "audio/ogg") {
        return ".ogg";
    }

    if ($normalizedType === "audio/wav" || $normalizedType === "audio/x-wav") {
        return ".wav";
    }

    return ".bin";
}

function saveSounds($sequence, $outputDirectory, $soundIndex)
{
    $effectCount = java_values($sequence->getCount());
    for ($effectIndex = 0; $effectIndex < $effectCount; $effectIndex++) {
        $effect = $sequence->get_Item($effectIndex);
        $sound = $effect->getSound();
        if (java_is_null($sound)) {
            continue;
        }

        $extension = getAudioExtension($sound->getContentType());
        $outputPath = $outputDirectory->resolve("effect-sound-" . $soundIndex . $extension);
        $outputStream = new Java("java.io.FileOutputStream", $outputPath->toFile());
        try {
            $outputStream->write($sound->getBinaryData());
        } finally {
            $outputStream->close();
        }
        $soundIndex++;
    }

    return $soundIndex;
}

$baseDirectory = getcwd();
$inputPath = (new Java("java.io.File", $baseDirectory . DIRECTORY_SEPARATOR . "presentation-with-animation-sounds.pptx"))->toPath();
$outputDirectoryName = $baseDirectory . DIRECTORY_SEPARATOR . "extracted-animation-sounds";
if (!is_dir($outputDirectoryName)) {
    mkdir($outputDirectoryName, 0777, true);
}
$outputDirectory = (new Java("java.io.File", $outputDirectoryName))->toPath();

$presentation = new Presentation($inputPath->toString());
try {
    $soundIndex = 1;

    $slides = $presentation->getSlides();
    $slideCount = java_values($slides->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $slides->get_Item($slideIndex);
        $soundIndex = saveSounds($slide->getTimeline()->getMainSequence(), $outputDirectory, $soundIndex);

        $interactiveSequences = $slide->getTimeline()->getInteractiveSequences();
        $interactiveCount = java_values($interactiveSequences->getCount());
        for ($sequenceIndex = 0; $sequenceIndex < $interactiveCount; $sequenceIndex++) {
            $sequence = $interactiveSequences->get_Item($sequenceIndex);
            $soundIndex = saveSounds($sequence, $outputDirectory, $soundIndex);
        }
    }

    echo "Extracted " . ($soundIndex - 1) . " sound file(s) to " . java_values($outputDirectory->toAbsolutePath()->toString()) . "." . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Pour de gros objets audio, utilisez [Audio::getStream](https://reference.aspose.com/slides/fr/php-java/aspose.slides/audio/getstream/) et copiez le flux dans un fichier au lieu de charger l'objet entier dans un tableau d'octets.

## **Définir le comportement après l'animation**

L'option **After animation** détermine ce qui arrive à une forme après la fin de son effet.

![Boîte de dialogue des options d'effet de PowerPoint affichant les paramètres After animation](shape-after-animation.png)

La classe [AfterAnimationType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/afteranimationtype/) permet de laisser la forme inchangée, de changer sa couleur, de la masquer après l'animation, ou de la masquer au clic suivant. Lorsque le type est [AfterAnimationType::Color](https://reference.aspose.com/slides/fr/php-java/aspose.slides/afteranimationtype/), définissez également [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/fr/php-java/aspose.slides/effect/getafteranimationcolor/).

Cet exemple indépendant crée un effet, définit son comportement après l'animation via l'objet effet renvoyé, puis enregistre le résultat.

```php
use aspose\slides\AfterAnimationType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $shape->addTextFrame("Dim after animation");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->setAfterAnimationType(AfterAnimationType::Color);
    $effect->getAfterAnimationColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("shape-animation-after-effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Modifier le type en dehors de [AfterAnimationType::Color](https://reference.aspose.com/slides/fr/php-java/aspose.slides/afteranimationtype/) supprime le paramètre de couleur après l'animation.

## **Animer du texte**

L'animation du texte possède deux contrôles liés :

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textanimation/getbuildtype/) détermine si les paragraphes apparaissent ensemble ou par niveau de paragraphe.
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/effect/getanimatetexttype/) détermine si le texte apparaît d'un seul coup, par mot ou par lettre. [Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/fr/php-java/aspose.slides/effect/getdelaybetweentextparts/) fixe le délai entre les mots ou les lettres. Une valeur positive représente un pourcentage de la durée de l'effet ; une valeur négative représente un délai en secondes.

L'exemple indépendant suivant anime les mots d'une zone de texte. [BuildType::AsOneObject](https://reference.aspose.com/slides/fr/php-java/aspose.slides/buildtype/) désactive la construction paragraphe par paragraphe afin que le réglage par mot s'applique à tout le cadre de texte.

```php
use aspose\slides\AnimateTextType;
use aspose\slides\BuildType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 560, 100);
    $textBox->addTextFrame("Aspose.Slides animates this sentence word by word.");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($textBox, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    $effect->setAnimateTextType(AnimateTextType::ByWord);
    $effect->setDelayBetweenTextParts(20.0);

    $presentation->save("animated-text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pour construire une zone de texte paragraphe par paragraphe, définissez [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/fr/php-java/aspose.slides/buildtype/) (ou un autre niveau de paragraphe). Pour cibler un seul paragraphe avec son propre effet, utilisez la surcharge de [Sequence::addEffect] qui accepte un [Paragraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/). Consultez [Animated Text](/slides/fr/php-java/animated-text/) pour des exemples au niveau du paragraphe.

## **Notes d'exportation et de compatibilité**

- Enregistrement en PPT ou PPTX conserve le modèle d'animation, mais la lecture finale est contrôlée par le visualiseur de présentation.
- PDF et images statiques ne lisent pas les animations. Utilisez [HTML5 export](/slides/fr/php-java/export-to-html5/), GIF animé, ou [video conversion](/slides/fr/php-java/convert-powerpoint-to-video/) lorsque la sortie doit montrer le mouvement.
- Pour HTML5, activez [Html5Options::setAnimateShapes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/html5options/setanimateshapes/) et, si nécessaire, [Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/html5options/setanimatetransitions/).
- Le rendu vidéo prend en charge de nombreux effets d'entrée, d'emphase, de sortie et de trajectoire, mais tous les effets PowerPoint ne sont pas pris en charge. Vérifiez la page [supported animations and effects](/slides/fr/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) et testez les présentations critiques avec votre version d'Aspose.Slides.
- Les effets personnalisés avancés et les effets importés d'autres formats peuvent être conservés dans le fichier mais rendus différemment dans PowerPoint, HTML5 ou vidéo. Validez le résultat exporté plutôt que de vous fier uniquement au nom de l'effet.

## **FAQ**

**Pourquoi une animation apparaît‑elle dans PowerPoint mais pas dans un PDF ?**

Le PDF est un format statique, donc les animations et les transitions de diapositives ne sont pas lues. Exportez en HTML5, GIF animé ou vidéo lorsque le mouvement doit être conservé.

**Pourquoi un effet est‑il lu différemment dans une vidéo ?**

L'exportation vidéo rend les animations plutôt que de conserver le comportement original de PowerPoint. Certains effets avancés ne sont pas pris en charge ou sont approximés. Consultez le tableau des effets pris en charge et testez la présentation réelle avant de la mettre en production.

**Déplacer une forme vers l'avant ou l'arrière change‑t‑il son ordre d'animation ?**

Non. L'ordre de superposition (z‑order) contrôle le chevauchement, tandis que l'ordre des séquences et les déclencheurs contrôlent la lecture des animations. Modifiez la chronologie si vous avez besoin d'un ordre de lecture différent.