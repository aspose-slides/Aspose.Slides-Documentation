---
title: Alakzatanimációk alkalmazása prezentációkban PHP használatával
linktitle: Alakzat animáció
type: docs
weight: 60
url: /hu/php-java/shape-animation/
keywords:
- alakzat
- animáció
- effektus
- animált alakzat
- animált szöveg
- animáció hozzáadása
- animáció lekérése
- animáció kinyerése
- effektus hozzáadása
- effektus lekérése
- effektus kinyerése
- effektus hang
- animáció alkalmazása
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá, vizsgálhat meg és testreszabhat alakzatanimációkat, időzítést, hangokat, az animáció utáni viselkedést és animált szöveget az Aspose.Slides for PHP via Java segítségével."
---
## **Áttekintés**

Az egyes viselkedések kezeléséhez egy hatásban vagy a mozgásút-szakaszok szerkesztéséhez lásd a [Custom Animation](/slides/hu/php-java/custom-animation/) oldalt.

Az Aspose.Slides for PHP via Java a diák animációit effektusokként ábrázolja egy dia idővonalán. Egy effektusnak van cél alakzata, animáció típusa és altípusa, egy aktiváló (trigger), időzítési beállításai, valamint opcionális tulajdonságai, mint például hang vagy az animáció utáni viselkedés.

Az idővonal kétféle sorrendet tartalmaz:

- A **fő sorrend** a dia előrehaladtával játszódik le.
- Egy **interaktív sorrend** akkor indul, amikor az aktiváló alakzatára kattintanak.

Mivel a szövegdobozok, képek, diagramok, táblázatok és egyéb diaobjektumok alakzatok, a legtöbb diaelemvhez ugyanazt a [Sequence::addEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sequence/addeffect/) metódust használod. Az elérhető effektusok a [EffectType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effecttype/) osztályban találhatók.

## **Alakzatanimációk hozzáadása**

Animáció hozzáadásához szerezd meg a dia fő sorrendjét, és hívd a [Sequence::addEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sequence/addeffect/) metódust a cél alakzattal, az effektus típusával, altípusával és az aktiválóval. Ha egy effektus akkor indul, amikor egy másik alakzatra kattintanak, hozz létre egy interaktív sorrendet, amelynek aktiválója az a másik alakzat.

Az alábbi példa mindkét animációtípust létrehozza, és az eredményt a `shape-animations.pptx` fájlba menti.

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

Az aktiváló határozza meg, mikor kezdődik egy effektus:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effecttriggertype/) vár egy kattintást a fő sorrendben, vagy egy kattintást az aktiváló alakzaton egy interaktív sorrendben.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effecttriggertype/) az előző effektussal együtt indul.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effecttriggertype/) az előző effektus befejezése után indul.

Kép, diagram vagy más alakzat típus animálásához add át azt az objektumot a [Sequence::addEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sequence/addeffect/) hívásnak a `$targetShape` helyett. Diagram-specifikus csoportosítási beállításokért lásd a [Animated Charts](/slides/hu/php-java/animated-charts/) oldalt.

## **Alakzatanimációk olvasása**

Használd a [Sequence::getEffectsByShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sequence/geteffectsbyshape/) metódust, ha ismered a cél alakzatot. Minden effektus megtekintéséhez iteráld a fő sorrendet és minden interaktív sorrendet. Az iteráció elkerüli, hogy feltételezd, egy sorrend tartalmaz effektust a `0` indexen.

Az alábbi példa egy alakzatot hoz létre fő- és interaktív effektusokkal, lekéri az alakzatot célozó effektusokat, majd minden sorrendet felsorol a dián.

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

Ha csak egy alakzatra vonatkozó effektusokra van szükséged, előbb azonosítsd az alakzatot név, helykitöltő típus vagy más stabil tulajdonság alapján; aztán hívd a [Sequence::getEffectsByShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sequence/geteffectsbyshape/) metódust. Ne feltételezd, hogy a [ShapeCollection::get_Item](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/get_item/) a `0` indexen mindig a kívánt objektum.

## **Örökölt helykitöltő effektusok kezelése**

Egy helykitöltő egy normál dián örökölheti az animációs viselkedést a megfelelő helykitöltőtől a diáblapján és a mesterdián. A [Shape::getBasePlaceholder](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getbaseplaceholder/) visszaadja ezt a szülő helykitöltőt, vagy `null` értéket, ha nincs szülő.

Az alábbi példaprezentációban a láblécnek **Random Bars** effektusa van a normál dián, **Split** a diáblapon, és **Fly In** a mesterdián.

![Footer animation effect on the normal slide](slide-shape-animation.png)

![Footer placeholder animation effect on the layout slide](layout-shape-animation.png)

![Footer placeholder animation effect on the master slide](master-shape-animation.png)

A következő példa egy új prezentáció helykitöltő hierarchiáját használja. Effektusokat ad egy mester helykitöltőhöz, egy diáblap helykitöltőhöz és a megfelelő helykitöltőhöz a normál dián. Minden hívás előtt ellenőrzik a [Shape::getBasePlaceholder](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getbaseplaceholder/) visszatérő alakzatát.

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

## **Animáció időzítésének módosítása**

A PowerPoint **Timing** párbeszédablaka a [Timing](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/) tulajdonságaira képezi le.

![PowerPoint Timing dialog for an animation effect](shape-animation.png)

- **Start** a [Timing::getTriggerType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/gettriggertype/) értékhez van rendelve.
- **Duration** a [Timing::getDuration](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/getduration/) értékhez, másodpercben.
- **Delay** a [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/gettriggerdelaytime/) értékhez, másodpercben.
- **Repeat** a [Timing::getRepeatCount](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/getrepeatcount/), [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/getrepeatuntilnextclick/) vagy [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/getrepeatuntilendslide/) értékekhez van rendelve.
- **Rewind when done playing** a [Timing::getRewind](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/getrewind/) értékhez van rendelve.

Ez a független példa egy effektust ad hozzá, módosítja annak időzítését a [Sequence::addEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sequence/addeffect/) által visszaadott objektumon keresztül, és elmenti az eredményt. A visszakapott [Effect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/) hivatkozás megtartása elkerüli a felesleges gyűjteményindex használatát.

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

Használj egy ismétlési módot szándékosan. Egy ismétlési szám és egy „until” jelző kombinálása zavaró eredményeket produkálhat különböző megjelenítőkben. Amikor ismétlési módot változtatsz, állítsd be a [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/setrepeatuntilnextclick/) és a [Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/setrepeatuntilendslide/) értékeket a [Timing::setRepeatCount](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/setrepeatcount/) hívása előtt, mivel bármelyik jelző beállítása megváltoztatja az aktív ismétlési módot.

## **Animációs hangok hozzáadása és kinyerése**

Egy animációs effektus hivatkozhat beágyazott hangra a [Effect::getSound](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/getsound/) segítségével. A [Effect::setStopPreviousSound](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/setstopprevioussound/) azt mondja az effektusnak, hogy állítsa le az előző effektus által indított hangot.

### **Hang hozzáadása egy effektushoz**

Az alábbi példa egy helyi `animation-sound.wav` nevű hangfájlt vár. Két effektust hoz létre, az elsőt az adott hangfájllal beágyazza, a másodikat beállítja, hogy állítsa le a hangot. A [Sequence::addEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sequence/addeffect/) által visszaadott objektumokat használja, így nem szükséges sorrendindex.

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

### **Beágyazott effektus hangok kinyerése**

Az alábbi példa egy helyi `presentation-with-animation-sounds.pptx` nevű prezentációt vár. Átvizsgálja a fő és interaktív sorrendet, és minden beágyazott effektushangot a `extracted-animation-sounds` könyvtárba ír ki. A kiterjesztés a [Audio::getContentType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/audio/getcontenttype/) által visszaadott audio MIME típus alapján kerül kiválasztásra.

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

Nagy hangobjektumok esetén használd a [Audio::getStream](https://reference.aspose.com/slides/hu/php-java/aspose.slides/audio/getstream/) metódust, és másold a streamet fájlba ahelyett, hogy az egész objektumot byte tömbbe töltenéd be.

## **Az animáció utáni viselkedés beállítása**

A **After animation** beállítás szabályozza, mi történik az alakzattal az effektus befejezése után.

![PowerPoint Effect Options dialog showing After animation settings](shape-after-animation.png)

A [AfterAnimationType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/afteranimationtype/) osztály támogatja az alakzat változatlanul hagyását, színének megváltoztatását, a animáció után elrejtését, vagy a következő kattintásra való elrejtést. Amikor a típus [AfterAnimationType::Color](https://reference.aspose.com/slides/hu/php-java/aspose.slides/afteranimationtype/), állítsd be a [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/getafteranimationcolor/) értékét is.

Ez a független példa egy effektust hoz létre, beállítja az animáció utáni viselkedést a visszakapott effektusobjektumon keresztül, és elmenti az eredményt.

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

A típust a [AfterAnimationType::Color](https://reference.aspose.com/slides/hu/php-java/aspose.slides/afteranimationtype/) értékről eltávolítani törli a színbeállítást is.

## **Szöveg animálása**

A szöveganimáció két kapcsolódó vezérlővel rendelkezik:

- A [TextAnimation::getBuildType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textanimation/getbuildtype/) szabályozza, hogy a bekezdések egyszerre vagy bekezdésenként jelenjenek meg.
- Az [Effect::getAnimateTextType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/getanimatetexttype/) szabályozza, hogy a szöveg egyszerre, szó szerint vagy betű szerint jelenjen meg. A [Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/getdelaybetweentextparts/) állítja a szavak vagy betűk közti késleltetést. A pozitív érték a hatás időtartamának százaléka; a negatív érték másodpercben megadott késleltetés.

Az alábbi független példa a szövegdoboz szavait animálja. A [BuildType::AsOneObject](https://reference.aspose.com/slides/hu/php-java/aspose.slides/buildtype/) letiltja a bekezdésenkénti felépítést, így a szó beállítás a teljes szövegdobozra vonatkozik.

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

A szövegdoboz bekezdésenkénti felépítéséhez állítsd a [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/hu/php-java/aspose.slides/buildtype/) (vagy egy másik bekezdés szint) értéket. Egyetlen bekezdés saját effektusához használd a [Sequence::addEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sequence/addeffect/) olyan overload-ját, amely [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) típust fogad. Lásd a [Animated Text](/slides/hu/php-java/animated-text/) oldalt bekezdés szintű példákért.

## **Exportálás és kompatibilitási megjegyzések**

- PPT vagy PPTX formátumba mentés megőrzi az animációs modellt, de a végső lejátszást a megjelenítő vezérli.
- PDF és statikus képek nem játsszák le az animációkat. Használd a [HTML5 export](/slides/hu/php-java/export-to-html5/), animált GIF vagy [video conversion](/slides/hu/php-java/convert-powerpoint-to-video/) lehetőséget, ha a kimenetnek mozgást kell mutatnia.
- HTML5 esetén engedélyezd a [Html5Options::setAnimateShapes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/html5options/setanimateshapes/) beállítást, és szükség esetén a [Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/html5options/setanimatetransitions/) beállítást.
- A videó renderelés számos gyakori belépő, hangsúlyozó, kilépő és mozgásút effektust támogat, de nem minden PowerPoint effektus érhető el. Ellenőrizd a jelenlegi [supported animations and effects](/slides/hu/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) listát, és teszteld a kritikus prezentációkat a cél Aspose.Slides verzióval.
- Haladó egyedi effektusok és más formátumokból importált effektusok megmaradhatnak a fájlban, de a PowerPointban, HTML5-ben vagy videóban másként jelenhetnek meg. Ellenőrizd a exportált eredményt, ne csak az effektus nevét vedd alapul.

## **GYIK**

**Miért jelenik meg egy animáció a PowerPointban, de nem PDF-ben?**

A PDF egy statikus formátum, ezért az animációk és diaátmenetek nem játszhatók le. Exportálj HTML5-re, animált GIF-re vagy videóra, ha a mozgást meg kell őrizni.

**Miért játszódik le egy effektus másként a videóban?**

A video export animációkat renderel, nem a PowerPoint eredeti viselkedését tárolja. Néhány haladó effektus nem támogatott vagy csak közelítő módon jelenik meg. Tekintsd meg a támogatott effektusok táblázatát, és teszteld a tényleges prezentációt a használat előtt.

**Módosítja-e egy alakzat előre vagy hátra helyezése az animáció sorrendjét?**

Nem. Az alakzat z‑rendezése szabályozza az átfedést, míg a sorrend és a aktiválók szabályozzák az animáció lejátszását. Változtasd meg az idővonalat, ha más lejátszási sorrendre van szükség.