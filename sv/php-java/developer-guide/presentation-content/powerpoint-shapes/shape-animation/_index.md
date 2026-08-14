---
title: Tillämpa formanimationer i presentationer med PHP
linktitle: Formanimation
type: docs
weight: 60
url: /sv/php-java/shape-animation/
keywords:
- form
- animation
- effekt
- animerad form
- animerad text
- lägga till animation
- hämta animation
- extrahera animation
- lägga till effekt
- hämta effekt
- extrahera effekt
- effektljud
- tillämpa animation
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du lägger till, granskar och anpassar formanimationer, timing, ljud, efteranimationsbeteende och animerad text med Aspose.Slides för PHP via Java."
---
## **Översikt**

Aspose.Slides för PHP via Java representerar bildanimationer som effekter i en bildtidslinje. En effekt har en målform, en animationstyp och undertyp, en utlösare, tidsinställningar samt valfria egenskaper såsom ljud eller beteende efter animationen.

Tidslinjen innehåller två typer av sekvenser:

- **huvudsekvensen** spelas när bilden avancerar.
- En **interaktiv sekvens** startar när dess utlösande form klickas.

Eftersom textrutor, bilder, diagram, tabeller och andra bildobjekt är former, använder du samma [Sequence::addEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sequence/addeffect/) metod för det mesta bildinnehåll. De tillgängliga effekterna listas i klassen [EffectType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effecttype/).

## **Lägg till formanimationer**

För att lägga till en animation, hämta bildens huvudsekvens och anropa [Sequence::addEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sequence/addeffect/) med målformen, effekttyp, undertyp och utlösare. För en effekt som startar när en annan form klickas, skapa en interaktiv sekvens vars utlösare är den andra formen.

Följande exempel skapar båda typerna av animation och sparar resultatet till `shape-animations.pptx`.

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

Utlösaren styr när en effekt startar:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effecttriggertype/) väntar på ett klick i huvudsekvensen, eller på ett klick på utlösande form i en interaktiv sekvens.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effecttriggertype/) startar tillsammans med föregående effekt.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effecttriggertype/) startar när den föregående effekten avslutas.

För att animera en bild, ett diagram eller en annan formtyp, skicka det objektet till [Sequence::addEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sequence/addeffect/) i stället för `$targetShape`. För diagramspecifika grupperingalternativ, se [Animated Charts](/slides/sv/php-java/animated-charts/).

## **Läs formanimationer**

Använd [Sequence::getEffectsByShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sequence/geteffectsbyshape/) när du känner till målformen. För att inspektera varje effekt, enumerera huvudsekvensen och varje interaktiv sekvens. Enumerering undviker att anta att en sekvens innehåller en effekt på index `0`.

Följande exempel skapar en form med huvudsekvens- och interaktiva effekter, hämtar de effekter som riktar sig mot formen och enumererar sedan varje sekvens på bilden.

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

Om du endast behöver effekterna för en form, identifiera först formen efter namn, platshållartyp eller en annan stabil egenskap; anropa sedan [Sequence::getEffectsByShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sequence/geteffectsbyshape/). Anta inte att [ShapeCollection::get_Item](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/get_item/) på index `0` alltid är det avsedda objektet.

## **Arbeta med ärvda platshållareffekter**

En platshållare på en vanlig bild kan ärva animationsbeteende från motsvarande platshållare på dess layoutbild och mastern. [Shape::getBasePlaceholder](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getbaseplaceholder/) returnerar den föräldraplatshållaren, eller `null` när ingen förälder finns.

I den följande exempelpresentationen har footern **Random Bars** på den vanliga bilden, **Split** på layoutbilden och **Fly In** på mastern.

![Fotterranimationseffekt på den vanliga bilden](slide-shape-animation.png)

![Fotterraphållarens animationseffekt på layoutbilden](layout-shape-animation.png)

![Fotterraphållarens animationseffekt på mastern](master-shape-animation.png)

Nästa exempel använder en platshållarhierarki från en ny presentation. Det lägger till effekter på en master‑platshållare, en layout‑platshållare och motsvarande platshållare på en vanlig bild. Varje anrop till [Shape::getBasePlaceholder](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getbaseplaceholder/) kontrolleras innan den returnerade formen används.

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

## **Ändra animationstiming**

PowerPoint‑dialogrutan **Timing** motsvarar egenskaperna i [Timing](https://reference.aspose.com/slides/sv/php-java/aspose.slides/timing/).

![PowerPoint Timing‑dialog för en animationseffekt](shape-animation.png)

- **Start** motsvarar [Timing::getTriggerType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/timing/gettriggertype/).
- **Duration** motsvarar [Timing::getDuration](https://reference.aspose.com/slides/sv/php-java/aspose.slides/timing/getduration/), i sekunder.
- **Delay** motsvarar [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/sv/php-java/aspose.slides/timing/gettriggerdelaytime/), i sekunder.
- **Repeat** motsvarar [Timing::getRepeatCount](https://reference.aspose.com/slides/sv/php-java/aspose.slides/timing/getrepeatcount/), [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/sv/php-java/aspose.slides/timing/getrepeatuntilnextclick/), eller [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/timing/getrepeatuntilendslide/).
- **Rewind when done playing** motsvarar [Timing::getRewind](https://reference.aspose.com/slides/sv/php-java/aspose.slides/timing/getrewind/).

Detta fristående exempel lägger till en effekt, ändrar dess timing genom objektet som returneras av [Sequence::addEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sequence/addeffect/), och sparar resultatet. Att behålla den returnerade [Effect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effect/)‑referensen undviker ett onödigt samlingsindex.

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

Använd ett repeteringsläge med avsikt. Att kombinera ett repetitionsantal med ett "until"-flagga kan ge förvirrande resultat i olika visare. När du ändrar repeteringslägen, sätt [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/sv/php-java/aspose.slides/timing/setrepeatuntilnextclick/) och [Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/timing/setrepeatuntilendslide/) innan [Timing::setRepeatCount](https://reference.aspose.com/slides/sv/php-java/aspose.slides/timing/setrepeatcount/), eftersom att sätta någon av flaggorna också ändrar det aktiva repeteringsläget.

## **Lägg till och extrahera animationsljud**

En animationseffekt kan referera till inbäddat ljud via [Effect::getSound](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effect/getsound/). [Effect::setStopPreviousSound](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effect/setstopprevioussound/) instruerar en effekt att stoppa ljud som startats av en tidigare effekt.

### **Lägg till ett ljud till en effekt**

Följande exempel förväntar sig en lokal ljudfil med namnet `animation-sound.wav`. Det skapar två effekter, bäddar in den filen som ljud för den första effekten och konfigurerar den andra effekten att stoppa ljudet. Det använder de objekt som returneras av [Sequence::addEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sequence/addeffect/), så inget sekvensindex behövs.

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

### **Extrahera inbäddade effektljud**

Följande exempel förväntar sig en lokal presentation med namnet `presentation-with-animation-sounds.pptx`. Det skannar både huvud- och interaktiva sekvenser och skriver varje inbäddat effektljud till katalogen `extracted-animation-sounds`. Filändelsen väljs utifrån ljud‑MIME‑typen som exponeras av [Audio::getContentType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/audio/getcontenttype/).

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

För stora ljudobjekt, använd [Audio::getStream](https://reference.aspose.com/slides/sv/php-java/aspose.slides/audio/getstream/) och kopiera strömmen till en fil i stället för att ladda hela objektet i en byte‑array.

## **Ställ in efter‑animationsbeteende**

**After animation**‑alternativet styr vad som händer med en form efter att dess effekt avslutas.

![PowerPoint‑dialogen Effektalternativ som visar After animation‑inställningar](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/afteranimationtype/)‑klassen stöder att lämna formen oförändrad, ändra dess färg, dölja den efter animationen, eller dölja den vid nästa klick. När typen är [AfterAnimationType::Color](https://reference.aspose.com/slides/sv/php-java/aspose.slides/afteranimationtype/), sätt även [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effect/getafteranimationcolor/).

Detta fristående exempel skapar en effekt, sätter dess efter‑animationsbeteende via den returnerade effekt‑objektet, och sparar resultatet.

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

Att ändra typen från [AfterAnimationType::Color](https://reference.aspose.com/slides/sv/php-java/aspose.slides/afteranimationtype/) rensar efter‑animationsfärgen.

## **Animera text**

Textanimation har två relaterade kontroller:

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textanimation/getbuildtype/) styr om stycken visas tillsammans eller per stycknivå.
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effect/getanimatetexttype/) styr om text visas på en gång, per ord eller per bokstav. [Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effect/getdelaybetweentextparts/) anger fördröjningen mellan ord eller bokstäver. Ett positivt värde är en procentandel av effektens varaktighet; ett negativt värde är en fördröjning i sekunder.

Följande fristående exempel animera orden i en textruta. [BuildType::AsOneObject](https://reference.aspose.com/slides/sv/php-java/aspose.slides/buildtype/) inaktiverar byggandet stycke för stycke så att ordinställningen gäller för hela textramen.

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

För att bygga en textruta per stycke, sätt [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/sv/php-java/aspose.slides/buildtype/) (eller en annan stycknivå). För att rikta en enskild stycke med egen effekt, använd [Sequence::addEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sequence/addeffect/)‑överladdningen som accepterar ett [Paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/). Se [Animated Text](/slides/sv/php-java/animated-text/) för exempel på stycknivå.

## **Export‑ och kompatibilitetsnoteringar**

- Att spara till PPT eller PPTX bevarar animationsmodellen, men den slutliga uppspelningen styrs av presentationsvisaren.
- PDF och statiska bilder spelar inte upp animationer. Använd [HTML5 export](/slides/sv/php-java/export-to-html5/), animerad GIF eller [video conversion](/slides/sv/php-java/convert-powerpoint-to-video/) när utdata måste visa rörelse.
- För HTML5, aktivera [Html5Options::setAnimateShapes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/html5options/setanimateshapes/) och, vid behov, [Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/html5options/setanimatetransitions/).
- Videorendering stödjer många vanliga inträde‑, betoning‑, utgångs‑ och rörelsespårseffekter, men inte varje PowerPoint‑effekt stöds. Kontrollera den aktuella [supported animations and effects](/slides/sv/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) och testa kritiska presentationer med din mål‑Aspose.Slides‑version.
- Avancerade anpassade effekter och effekter importerade från andra presentationsformat kan bevaras i filen men renderas annorlunda i PowerPoint, HTML5 eller video. Validera det exporterade resultatet istället för att endast förlita sig på effektens namn.

## **FAQ**

**Varför visas en animation i PowerPoint men inte i en PDF?**

PDF är ett statiskt format, så animationer och bildövergångar spelas inte upp. Exportera till HTML5, animerad GIF eller video när rörelse måste bevaras.

**Varför spelas en effekt annorlunda i en video?**

Videoexport renderar animationer snarare än att lagra det ursprungliga PowerPoint‑beteendet. Vissa avancerade effekter stöds inte eller approximera. Granska tabellen med stödde effekter och testa den faktiska presentationen innan produktionsanvändning.

**Ändrar det att flytta en form framåt eller bakåt dess animationsordning?**

Nej. Formens z‑ordning styr överlappning, medan sekvensordning och utlösare styr animationsuppspelning. Ändra tidslinjen om du behöver annan uppspelningsordning.