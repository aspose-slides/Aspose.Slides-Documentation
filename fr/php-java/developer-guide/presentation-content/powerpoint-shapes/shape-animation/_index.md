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
- ajouter une animation
- obtenir une animation
- extraire l'animation
- ajouter un effet
- obtenir un effet
- extraire un effet
- son d'effet
- appliquer une animation
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez comment ajouter, inspecter et personnaliser les animations de forme, le minutage, les sons, le comportement après l'animation et le texte animé avec Aspose.Slides pour PHP via Java."
---
## **Vue d'ensemble**

Aspose.Slides for PHP via Java représente les animations de diapositives sous forme d'effets dans une chronologie de diapositive. Un effet possède une forme cible, un type et sous‑type d'animation, un déclencheur, des paramètres de synchronisation et des propriétés facultatives telles que le son ou le comportement après l'animation.

La chronologie contient deux types de séquences :

- La **séquence principale** se joue lorsque la diapositive progresse.  
- Une **séquence interactive** démarre lorsque sa forme déclencheur est cliquée.

Comme les zones de texte, les images, les graphiques, les tableaux et les autres objets de diapositive sont des formes, vous utilisez la même [Sequence::addEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sequence/addeffect/) pour la plupart du contenu de diapositive. Les effets disponibles sont répertoriés dans la classe [EffectType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/effecttype/).

## **Ajouter des animations de forme**

Pour ajouter une animation, récupérez la séquence principale de la diapositive et appelez [Sequence::addEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sequence/addeffect/) avec la forme cible, le type d'effet, le sous‑type et le déclencheur. Pour un effet qui commence lorsqu'une autre forme est cliquée, créez une séquence interactive dont le déclencheur est cette autre forme.

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

Pour animer une image, un graphique ou un autre type de forme, transmettez cet objet à [Sequence::addEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sequence/addeffect/) au lieu de `$targetShape`. Pour les options de groupement spécifiques aux graphiques, voir [Animated Charts](/slides/fr/php-java/animated-charts/).

## **Lire les animations de forme**

Utilisez [Sequence::getEffectsByShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sequence/geteffectsbyshape/) lorsque vous connaissez la forme cible. Pour inspecter chaque effet, parcourez la séquence principale et chaque séquence interactive. L'énumération évite de supposer qu'une séquence contient un effet à l'index `0`.

L'exemple suivant crée une forme avec des effets de séquence principale et interactive, récupère les effets qui ciblent la forme, puis parcourt chaque séquence de la diapositive.

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

Si vous avez besoin uniquement des effets pour une forme, identifiez d'abord la forme par son nom, son type d'espace réservé ou une autre propriété stable ; puis appelez [Sequence::getEffectsByShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sequence/geteffectsbyshape/). Ne supposez pas que [ShapeCollection::get_Item](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapecollection/get_item/) à l'index `0` soit toujours l'objet souhaité.

## **Travailler avec les effets d'espace réservé hérités**

Un espace réservé sur une diapositive normale peut hériter du comportement d'animation de l'espace réservé correspondant sur la diapositive de mise en page et sur la diapositive maître. [Shape::getBasePlaceholder](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/getbaseplaceholder/) renvoie cet espace réservé parent, ou `null` lorsqu'aucun parent n'existe.

Dans la présentation d'exemple suivante, le pied de page possède **Random Bars** sur la diapositive normale, **Split** sur la diapositive de mise en page et **Fly In** sur la diapositive maître.

![Effet d'animation du pied de page sur la diapositive normale](slide-shape-animation.png)

![Effet d'animation du pied de page sur la diapositive de mise en page](layout-shape-animation.png)

![Effet d'animation du pied de page sur la diapositive maître](master-shape-animation.png)

L'exemple suivant utilise une hiérarchie d'espaces réservés provenant d'une nouvelle présentation. Il ajoute des effets à un espace réservé maître, à un espace réservé de mise en page et à l'espace réservé correspondant sur une diapositive normale. Chaque appel à [Shape::getBasePlaceholder](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/getbaseplaceholder/) est vérifié avant d'utiliser la forme renvoyée.

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

## **Modifier le minutage de l'animation**

La boîte de dialogue PowerPoint **Timing** correspond aux propriétés de [Timing](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/).

![Boîte de dialogue Timing de PowerPoint pour un effet d'animation](shape-animation.png)

- **Start** correspond à [Timing::getTriggerType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/gettriggertype/).  
- **Duration** correspond à [Timing::getDuration](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/getduration/), en secondes.  
- **Delay** correspond à [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/gettriggerdelaytime/), en secondes.  
- **Repeat** correspond à [Timing::getRepeatCount](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/getrepeatcount/), [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/getrepeatuntilnextclick/) ou [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/getrepeatuntilendslide/).  
- **Rewind when done playing** correspond à [Timing::getRewind](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/getrewind/).

Cet exemple indépendant ajoute un effet, modifie son minutage via l'objet renvoyé par [Sequence::addEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sequence/addeffect/), et enregistre le résultat. Conserver la référence à l'[Effect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/effect/) renvoyée évite d'utiliser un index de collection inutile.

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

Utilisez un mode de répétition de façon intentionnelle. Combiner un nombre de répétitions avec un drapeau « until » peut produire des résultats déroutants selon le lecteur. Lors du changement de modes de répétition, définissez [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/setrepeatuntilnextclick/) et [Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/setrepeatuntilendslide/) avant [Timing::setRepeatCount](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/setrepeatcount/), car la définition de l'un des drapeaux modifie également le mode de répétition actif.

## **Ajouter et extraire des sons d'animation**

Un effet d'animation peut référencer un audio intégré via [Effect::getSound](https://reference.aspose.com/slides/fr/php-java/aspose.slides/effect/getsound/). [Effect::setStopPreviousSound](https://reference.aspose.com/slides/fr/php-java/aspose.slides/effect/setstopprevioussound/) indique à un effet d'arrêter le son démarré par un effet antérieur.

### **Ajouter un son à un effet**

L'exemple suivant suppose un fichier audio local nommé `animation-sound.wav`. Il crée deux effets, intègre ce fichier comme son du premier effet et configure le second effet pour arrêter le son. Il utilise les objets renvoyés par [Sequence::addEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sequence/addeffect/), ainsi aucun index de séquence n'est nécessaire.

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

### **Extraire les sons d'effet intégrés**

L'exemple suivant suppose une présentation locale nommée `presentation-with-animation-sounds.pptx`. Il parcourt les séquences principale et interactive et écrit chaque son d'effet intégré dans le répertoire `extracted-animation-sounds`. L'extension est choisie à partir du type MIME audio renvoyé par [Audio::getContentType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/audio/getcontenttype/).

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

Pour de gros objets audio, utilisez [Audio::getStream](https://reference.aspose.com/slides/fr/php-java/aspose.slides/audio/getstream/) et copiez le flux vers un fichier au lieu de charger tout l'objet dans un tableau d'octets.

## **Définir le comportement après l'animation**

L'option **After animation** contrôle ce qui arrive à une forme après la fin de son effet.

![Boîte de dialogue Options d'effet de PowerPoint affichant les paramètres After animation](shape-after-animation.png)

La classe [AfterAnimationType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/afteranimationtype/) prend en charge le fait de laisser la forme inchangée, de changer sa couleur, de la masquer après l'animation ou de la masquer au clic suivant. Lorsque le type est [AfterAnimationType::Color](https://reference.aspose.com/slides/fr/php-java/aspose.slides/afteranimationtype/), définissez également [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/fr/php-java/aspose.slides/effect/getafteranimationcolor/).

Cet exemple indépendant crée un effet, définit son comportement après l'animation via l'objet effet renvoyé, et enregistre le résultat.

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

Changer le type hors de [AfterAnimationType::Color](https://reference.aspose.com/slides/fr/php-java/aspose.slides/afteranimationtype/) efface le paramètre de couleur après l'animation.

## **Animer le texte**

L'animation du texte possède deux contrôles liés :

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textanimation/getbuildtype/) contrôle si les paragraphes apparaissent ensemble ou par niveau de paragraphe.  
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/effect/getanimatetexttype/) contrôle si le texte apparaît en une fois, par mot ou par lettre. [Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/fr/php-java/aspose.slides/effect/getdelaybetweentextparts/) définit le délai entre les mots ou les lettres. Une valeur positive est un pourcentage de la durée de l'effet ; une valeur négative est un délai en secondes.

L'exemple indépendant suivant anime les mots d'une zone de texte. [BuildType::AsOneObject](https://reference.aspose.com/slides/fr/php-java/aspose.slides/buildtype/) désactive le montage paragraphe par paragraphe afin que le paramètre de mot s'applique à tout le cadre de texte.

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

Pour construire une zone de texte paragraphe par paragraphe, définissez [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/fr/php-java/aspose.slides/buildtype/) (ou un autre niveau de paragraphe). Pour cibler un seul paragraphe avec son propre effet, utilisez la surcharge de [Sequence::addEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sequence/addeffect/) qui accepte un [Paragraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/). Voir [Animated Text](/slides/fr/php-java/animated-text/) pour des exemples au niveau du paragraphe.

## **Exportation et notes de compatibilité**

- L'enregistrement au format PPT ou PPTX préserve le modèle d'animation, mais la lecture finale dépend du visualiseur de présentation.  
- PDF et images statiques ne lisent pas les animations. Utilisez l'[exportation HTML5](/slides/fr/php-java/export-to-html5/), GIF animé ou [conversion vidéo](/slides/fr/php-java/convert-powerpoint-to-video/) lorsque la sortie doit montrer du mouvement.  
- Pour HTML5, activez [Html5Options::setAnimateShapes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/html5options/setanimateshapes/) et, si nécessaire, [Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/html5options/setanimatetransitions/).  
- Le rendu vidéo prend en charge de nombreux effets d'entrée, d'emphase, de sortie et de trajectoire, mais tous les effets PowerPoint ne sont pas pris en charge. Vérifiez la page [animations et effets pris en charge](/slides/fr/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) et testez les présentations critiques avec votre version cible d'Aspose.Slides.  
- Les effets personnalisés avancés et les effets importés d'autres formats de présentation peuvent être conservés dans le fichier mais rendus différemment dans PowerPoint, HTML5 ou vidéo. Validez le résultat exporté plutôt que de vous fier uniquement au nom de l'effet.

## **FAQ**

**Pourquoi une animation apparaît‑elle dans PowerPoint mais pas dans un PDF ?**

PDF est un format statique, les animations et transitions de diapositive ne sont pas lues. Exportez vers HTML5, GIF animé ou vidéo lorsque le mouvement doit être conservé.

**Pourquoi un effet se comporte‑t‑il différemment dans une vidéo ?**

L'exportation vidéo rend les animations plutôt que de stocker le comportement original de PowerPoint. Certains effets avancés ne sont pas pris en charge ou sont approximés. Consultez le tableau des effets pris en charge et testez la présentation réelle avant une utilisation en production.

**Le déplacement d'une forme vers l'avant ou l'arrière modifie‑t‑il son ordre d'animation ?**

Non. L'ordre Z contrôle le chevauchement, tandis que l'ordre des séquences et les déclencheurs contrôlent la lecture des animations. Modifiez la chronologie si vous avez besoin d'un ordre de lecture différent.