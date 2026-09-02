---
title: Toepassen van Vormanimaties in Presentaties met PHP
linktitle: Vormanimatie
type: docs
weight: 60
url: /nl/php-java/shape-animation/
keywords:
- vorm
- animatie
- effect
- geanimeerde vorm
- geanimeerde tekst
- animatie toevoegen
- animatie ophalen
- animatie extraheren
- effect toevoegen
- effect ophalen
- effect extraheren
- geluidseffect
- animatie toepassen
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u vormanimaties, timing, geluiden, gedrag na animatie en geanimeerde tekst kunt toevoegen, inspecteren en aanpassen met Aspose.Slides voor PHP via Java."
---
## **Overzicht**

Aspose.Slides voor PHP via Java stelt dia‑animaties voor als effecten in een diatijdlijn. Een effect heeft een doelvorm, een animatietype en subtype, een trigger, timing‑instellingen en optionele eigenschappen zoals geluid of gedrag na de animatie.

De tijdlijn bevat twee soorten sequenties:

- De **hoofdsequentie** speelt af terwijl de dia vordert.
- Een **interactieve sequentie** start wanneer de triggervorm wordt aangeklikt.

Omdat tekstvakken, afbeeldingen, grafieken, tabellen en andere dia‑objecten vormen zijn, gebruik je dezelfde [Sequence::addEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sequence/addeffect/) methode voor de meeste dia‑inhoud. De beschikbare effecten staan opgesomd in de klasse [EffectType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effecttype/).

## **Vormanimaties toevoegen**

Om een animatie toe te voegen, haal je de hoofdsequentie van de dia op en roep je [Sequence::addEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sequence/addeffect/) aan met de doelvorm, het effecttype, subtype en trigger. Voor een effect dat start wanneer een andere vorm wordt aangeklikt, maak je een interactieve sequentie aan waarvan de trigger die andere vorm is.

Het volgende voorbeeld maakt beide soorten animatie en slaat het resultaat op als `shape-animations.pptx`.

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

De trigger bepaalt wanneer een effect start:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effecttriggertype/) wacht op een klik in de hoofdsequentie, of op een klik op de triggervorm in een interactieve sequentie.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effecttriggertype/) start gelijktijdig met het vorige effect.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effecttriggertype/) start wanneer het vorige effect eindigt.

Om een afbeelding, grafiek of een ander type vorm te animeren, geef je dat object door aan [Sequence::addEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sequence/addeffect/) in plaats van `$targetShape`. Voor grafiek‑specifieke groepeer‑opties, zie [Animated Charts](/slides/nl/php-java/animated-charts/).

## **Vormanimaties lezen**

Gebruik [Sequence::getEffectsByShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sequence/geteffectsbyshape/) wanneer je de doelvorm kent. Om elk effect te inspecteren, enumerateer je de hoofdsequentie en elke interactieve sequentie. Enumeratie voorkomt de veronderstelling dat een sequentie een effect bevat op index `0`.

Het volgende voorbeeld maakt een vorm met hoofd‑sequentie‑ en interactieve effecten, haalt de effecten op die op de vorm zijn gericht, en enumerateert vervolgens elke sequentie op de dia.

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

Als je alleen de effecten voor één vorm nodig hebt, identificeer dan eerst de vorm op naam, placeholder‑type of een andere stabiele eigenschap; roep daarna [Sequence::getEffectsByShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sequence/geteffectsbyshape/) aan. Neem niet aan dat [ShapeCollection::get_Item](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/get_item/) op index `0` altijd het beoogde object is.

## **Werken met geërfde placeholder‑effecten**

Een placeholder op een normale dia kan animatiegedrag overnemen van de overeenkomstige placeholder op de lay‑outdia en de master‑dia. [Shape::getBasePlaceholder](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getbaseplaceholder/) retourneert die bovenliggende placeholder, of `null` wanneer er geen bovenliggend element bestaat.

In de volgende voorbeeldpresentatie heeft de voettekst **Random Bars** op de normale dia, **Split** op de lay‑outdia en **Fly In** op de master‑dia.

![Voettekstanimatie‑effect op de normale dia](slide-shape-animation.png)

![Voettekst‑placeholder‑animatie‑effect op de lay‑outdia](layout-shape-animation.png)

![Voettekst‑placeholder‑animatie‑effect op de master‑dia](master-shape-animation.png)

Het volgende voorbeeld gebruikt een placeholder‑hiërarchie uit een nieuwe presentatie. Het voegt effecten toe aan een master‑placeholder, een lay‑out‑placeholder en de overeenkomstige placeholder op een normale dia. Elke oproep van [Shape::getBasePlaceholder](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getbaseplaceholder/) wordt gecontroleerd voordat de geretourneerde vorm wordt gebruikt.

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

## **Animatietiming wijzigen**

Het PowerPoint **Timing**‑dialoogvenster correspondeert met de eigenschappen van [Timing](https://reference.aspose.com/slides/nl/php-java/aspose.slides/timing/).

![PowerPoint Timing‑dialoogvenster voor een animatie‑effect](shape-animation.png)

- **Start** correspondeert met [Timing::getTriggerType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/timing/gettriggertype/).
- **Duur** correspondeert met [Timing::getDuration](https://reference.aspose.com/slides/nl/php-java/aspose.slides/timing/getduration/), in seconden.
- **Vertraging** correspondeert met [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/nl/php-java/aspose.slides/timing/gettriggerdelaytime/), in seconden.
- **Herhalen** correspondeert met [Timing::getRepeatCount](https://reference.aspose.com/slides/nl/php-java/aspose.slides/timing/getrepeatcount/), [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/nl/php-java/aspose.slides/timing/getrepeatuntilnextclick/), of [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/timing/getrepeatuntilendslide/).
- **Terugspoelen na afspelen** correspondeert met [Timing::getRewind](https://reference.aspose.com/slides/nl/php-java/aspose.slides/timing/getrewind/).

Dit zelfstandige voorbeeld voegt een effect toe, wijzigt de timing via het object dat wordt geretourneerd door [Sequence::addEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sequence/addeffect/), en slaat het resultaat op. Het behouden van de geretourneerde [Effect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effect/) referentie voorkomt een onnodige collectie‑index.

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

Gebruik bewust één herhaal‑modus. Het combineren van een herhaaltaantal met een „until“-vlag kan verwarrende resultaten opleveren in verschillende weergaveprogramma's. Bij het wijzigen van herhaal‑modi, stel eerst [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/nl/php-java/aspose.slides/timing/setrepeatuntilnextclick/) en [Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/timing/setrepeatuntilendslide/) in vóór [Timing::setRepeatCount](https://reference.aspose.com/slides/nl/php-java/aspose.slides/timing/setrepeatcount/), omdat het instellen van een van beide vlaggen ook de actieve herhaal‑modus wijzigt.

## **Animatiegeluiden toevoegen en extraheren**

Een animatie‑effect kan via [Effect::getSound](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effect/getsound/) naar ingesloten audio verwijzen. [Effect::setStopPreviousSound](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effect/setstopprevioussound/) instrueert een effect om audio te stoppen die door een eerder effect is gestart.

### **Geluid toevoegen aan een effect**

Het volgende voorbeeld verwacht een lokaal audiobestand met de naam `animation-sound.wav`. Het maakt twee effecten, embedt dat bestand als geluid voor het eerste effect en configureert het tweede effect om het geluid te stoppen. Het gebruikt de objecten die worden geretourneerd door [Sequence::addEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sequence/addeffect/), dus er is geen sequentie‑index nodig.

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

### **Ingesloten effectgeluiden extraheren**

Het volgende voorbeeld verwacht een lokale presentatie met de naam `presentation-with-animation-sounds.pptx`. Het scant zowel de hoofd‑ als de interactieve sequenties en schrijft elk ingesloten effectgeluid naar de map `extracted-animation-sounds`. De extensie wordt gekozen op basis van het audio‑MIME‑type dat wordt blootgesteld door [Audio::getContentType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/audio/getcontenttype/).

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

Voor grote audio‑objecten, gebruik [Audio::getStream](https://reference.aspose.com/slides/nl/php-java/aspose.slides/audio/getstream/) en kopieer de stream naar een bestand in plaats van het volledige object in een byte‑array te laden.

## **Nabewerkingsgedrag instellen**

De optie **After animation** bepaalt wat er met een vorm gebeurt nadat het effect is voltooid.

![PowerPoint Effect‑opties dialoogvenster waar de After‑animation‑instellingen worden getoond](shape-after-animation.png)

De klasse [AfterAnimationType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/afteranimationtype/) ondersteunt het onveranderd laten van de vorm, het wijzigen van de kleur, het verbergen na de animatie, of het verbergen bij de volgende klik. Wanneer het type [AfterAnimationType::Color](https://reference.aspose.com/slides/nl/php-java/aspose.slides/afteranimationtype/) is, stel ook [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effect/getafteranimationcolor/) in.

Dit zelfstandige voorbeeld maakt een effect, stelt het nabewerkingsgedrag in via het geretourneerde effect‑object, en slaat het resultaat op.

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

Het veranderen van het type van [AfterAnimationType::Color](https://reference.aspose.com/slides/nl/php-java/aspose.slides/afteranimationtype/) wist de After‑animation‑kleurinstelling.

## **Tekst animeren**

Tekstanimatie heeft twee gerelateerde instellingen:

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textanimation/getbuildtype/) bepaalt of alinea's samen verschijnen of per alinea‑niveau.
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effect/getanimatetexttype/) bepaalt of tekst in één keer, woord voor woord, of letter voor letter verschijnt. [Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effect/getdelaybetweentextparts/) stelt de vertraging tussen woorden of letters in. Een positieve waarde is een percentage van de effectduur; een negatieve waarde is een vertraging in seconden.

Het volgende zelfstandige voorbeeld animeert de woorden in een tekstvak. [BuildType::AsOneObject](https://reference.aspose.com/slides/nl/php-java/aspose.slides/buildtype/) schakelt paragrafen‑per‑paragraaf bouwen uit, zodat de woordinstelling geldt voor het gehele tekstframe.

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

Om een tekstvak per alinea op te bouwen, stel je [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/nl/php-java/aspose.slides/buildtype/) (of een ander alinea‑niveau) in. Om een enkele alinea met een eigen effect te targeten, gebruik je de overload van [Sequence::addEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sequence/addeffect/) die een [Paragraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/) accepteert. Zie [Animated Text](/slides/nl/php-java/animated-text/) voor voorbeelden op alinea‑niveau.

## **Export‑ en compatibiliteitsopmerkingen**

- Het opslaan naar PPT of PPTX behoudt het animatiemodel, maar de uiteindelijke weergave wordt beheerd door de presentatiewĳzer.
- PDF en statische afbeeldingen spelen geen animaties af. Gebruik [HTML5 export](/slides/nl/php-java/export-to-html5/), een geanimeerde GIF, of [video conversion](/slides/nl/php-java/convert-powerpoint-to-video/) wanneer de output beweging moet tonen.
- Voor HTML5, schakel [Html5Options::setAnimateShapes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/html5options/setanimateshapes/) in en, indien nodig, [Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/html5options/setanimatetransitions/).
- Videoweergave ondersteunt vele veelvoorkomende in‑, nadruk‑, uit‑ en bewegings‑pad‑effecten, maar niet elk PowerPoint‑effect wordt ondersteund. Controleer de huidige [supported animations and effects](/slides/nl/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) en test kritieke presentaties met uw target Aspose.Slides‑versie.
- Gevorderde aangepaste effecten en effecten geïmporteerd uit andere presentaties kunnen in het bestand worden bewaard maar anders worden gerenderd in PowerPoint, HTML5 of video. Valideer het geëxporteerde resultaat in plaats van alleen op de effectnaam te vertrouwen.

## **FAQ**

**Waarom verschijnt een animatie in PowerPoint maar niet in een PDF?**

PDF is een statisch formaat, dus animaties en dia‑overgangen worden niet afgespeeld. Exporteer naar HTML5, een geanimeerde GIF, of video wanneer beweging behouden moet blijven.

**Waarom wordt een effect anders afgespeeld in een video?**

Video‑export rendert animaties in plaats van het oorspronkelijke PowerPoint‑gedrag op te slaan. Sommige geavanceerde effecten worden niet ondersteund of benaderd. Bekijk de tabel met ondersteunde effecten en test de daadwerkelijke presentatie vóór productiegebruik.

**Verandert het naar voren of naar achteren verplaatsen van een vorm haar animatievolgorde?**

Nee. De z‑volgorde van de vorm bepaalt de overlappende weergave, terwijl de volgorde van de sequentie en triggers de animatie‑afspeelvolgorde bepalen. Pas de tijdlijn aan als je een andere afspeelvolgorde nodig hebt.