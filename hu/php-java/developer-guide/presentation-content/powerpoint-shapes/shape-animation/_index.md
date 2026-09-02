---
title: Alakzat animációk alkalmazása prezentációkban PHP-vel
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
description: "Tanulja meg, hogyan adjon hozzá, vizsgáljon meg és testre szabjon alakzat animációkat, időzítéseket, hangokat, animáció utáni viselkedést és animált szöveget az Aspose.Slides for PHP via Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for PHP via Java a diaanimációkat effektusokként ábrázolja a dia idővonalán. Egy effektusnak van cél alakzata, animáció típusa és altípusa, egy trigger, időzítési beállítások, és opcionális tulajdonságok, például hang vagy animáció utáni viselkedés.

Az idővonal kétféle szekvenciát tartalmaz:

- A **fő szekvencia** a dia előrehaladtával játszódik.
- Egy **interaktív szekvencia** akkor kezdődik, amikor a trigger alakzatára kattintanak.

Mivel a szövegdobozok, képek, diagramok, táblázatok és egyéb diaobjektumok alakzatok, a legtöbb dia tartalomhoz ugyanazt a [Sequence::addEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sequence/addeffect/) metódust kell használni. A rendelkezésre álló effektusok a [EffectType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effecttype/) osztályban vannak felsorolva.

## **Alakzatanimációk hozzáadása**

Animáció hozzáadásához szerezze be a dia fő szekvenciáját, és hívja meg a [Sequence::addEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sequence/addeffect/) metódust a cél alakzattal, effektustípussal, altípussal és triggerrel. Egy olyan effektus esetén, amely egy másik alakzatra kattintva indul, hozzon létre egy interaktív szekvenciát, amelynek triggerje az a másik alakzat.

A következő példa mindkét típusú animációt létrehozza, és az eredményt a `shape-animations.pptx` fájlba menti.

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

A trigger szabályozza, hogy mikor indul egy effektus:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effecttriggertype/) vár a kattintásra a fő szekvenciában, vagy a trigger alakzatra egy interaktív szekvenciában.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effecttriggertype/) az előző effektussal együtt indul.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effecttriggertype/) az előző effektus befejezésekor indul.

Kép, diagram vagy más alakzat animálásához adja át azt az objektumot a [Sequence::addEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sequence/addeffect/) metódusnak a `$targetShape` helyett. Diagram-specifikus csoportosítási lehetőségekért lásd az [Animated Charts](/slides/hu/php-java/animated-charts/) oldalt.

## **Alakzatanimációk olvasása**

Használja a [Sequence::getEffectsByShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sequence/geteffectsbyshape/) metódust, ha ismeri a cél alakzatot. Minden effektus megvizsgálásához sorolja fel a fő szekvenciát és minden interaktív szekvenciát. Az enumerálás elkerüli, hogy feltételezzük, egy szekvencia a `0` indexen tartalmaz effektust.

A következő példa egy alakzatot hoz létre fő-szekvenciás és interaktív effektusokkal, lekéri az alakzatra célozó effektusokat, majd felsorolja a dia minden szekvenciáját.

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

Ha csak egy alakzathoz szükséges a hatás, először azonosítsa az alakzatot név, placeholder típus vagy más stabil tulajdonság alapján; ezután hívja meg a [Sequence::getEffectsByShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sequence/geteffectsbyshape/) metódust. Ne feltételezze, hogy a [ShapeCollection::get_Item](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/get_item/) a `0` indexen mindig a kívánt objektum.

## **Örökölt placeholder effektusok kezelése**

Egy normál dián lévő placeholder örökölheti az animációs viselkedést a megfelelő placeholderről a layout diáról és a mester diárról. A [Shape::getBasePlaceholder](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getbaseplaceholder/) visszaadja ezt a szülő placeholdert, vagy `null`-t, ha nincs szülő.

A következő példaprezentációban a láblécnek **Random Bars** van a normál dián, **Split** a layout dián, és **Fly In** a mester dián.

![Lábléc animációs effektus a normál dián](slide-shape-animation.png)

![Lábléc placeholder animációs effektus a layout dián](layout-shape-animation.png)

![Lábléc placeholder animációs effektus a mester dián](master-shape-animation.png)

A következő példában egy új prezentáció placeholder hierarchiáját használja. Effektusokat ad egy mester placeholderhez, egy layout placeholderhez és a megfelelő placeholderhez a normál dián. Minden [Shape::getBasePlaceholder](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getbaseplaceholder/) hívás előtt ellenőrzik, mielőtt a visszaadott alakzatot felhasználnák.

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

A PowerPoint **Timing** párbeszédpanel a [Timing](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/) tulajdonságaira vonatkozik.

![PowerPoint időzítési párbeszédpanel egy animációs effektushoz](shape-animation.png)

- **Start** a [Timing::getTriggerType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/gettriggertype/) -hez kapcsolódik.
- **Duration** a [Timing::getDuration](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/getduration/) -hez, másodpercben.
- **Delay** a [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/gettriggerdelaytime/) -hez, másodpercben.
- **Repeat** a [Timing::getRepeatCount](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/getrepeatcount/), a [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/getrepeatuntilnextclick/), vagy a [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/getrepeatuntilendslide/) -hez.
- **Rewind when done playing** a [Timing::getRewind](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/getrewind/) -hez.

Ez a független példa hozzáad egy effektust, módosítja annak időzítését a [Sequence::addEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sequence/addeffect/) által visszaadott objektumon keresztül, és elmenti az eredményt. A visszaadott [Effect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/) hivatkozás megtartása elkerüli a felesleges gyűjtemény indexet.

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

Szándékosan használjon egyetlen ismétlési módot. Egy ismétlési szám és egy "until" (addig) jelző kombinálása zavaró eredményeket okozhat különböző megjelenítőkben. Ismétlési módok módosításakor állítsa be a [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/setrepeatuntilnextclick/) és a [Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/setrepeatuntilendslide/) értékeket a [Timing::setRepeatCount](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/setrepeatcount/) előtt, mivel bármelyik jelző beállítása megváltoztatja az aktív ismétlési módot.

## **Animációs hangok hozzáadása és kinyerése**

Egy animációs effektus hivatkozhat beágyazott hangra a [Effect::getSound](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/getsound/) segítségével. A [Effect::setStopPreviousSound](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/setstopprevioussound/) azt mondja a effektusnak, hogy állítsa le a korábbi effektus által elindított hangot.

### **Hang hozzáadása egy effektushoz**

A következő példa egy helyi `animation-sound.wav` nevű hangfájlt vár. Két effektust hoz létre, beágyazza ezt a fájlt az első effektus hangjává, és a második effektust úgy konfigurálja, hogy leállítsa a hangot. A [Sequence::addEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sequence/addeffect/) által visszaadott objektumokat használja, így nincs szükség szekvencia indexre.

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

### **Beágyazott effektushangok kinyerése**

A következő példa egy helyi `presentation-with-animation-sounds.pptx` nevű prezentációt vár. Átvizsgálja a fő és interaktív szekvenciákat, és minden beágyazott effektushangot a `extracted-animation-sounds` könyvtárba ír. A kiterjesztés a [Audio::getContentType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/audio/getcontenttype/) által visszaadott audio MIME-típusból kerül kiválasztásra.

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

Nagy audio objektumok esetén használja a [Audio::getStream](https://reference.aspose.com/slides/hu/php-java/aspose.slides/audio/getstream/) metódust, és másolja a streamet egy fájlba ahelyett, hogy a teljes objektumot egy bájttömbbe töltené.

## **Animáció utáni viselkedés beállítása**

A **After animation** (Animáció után) lehetőség szabályozza, mi történik egy alakzattal az effektus befejezése után.

![PowerPoint effektus beállítások párbeszédpanel az After animation beállításokkal](shape-after-animation.png)

A [AfterAnimationType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/afteranimationtype/) osztály támogatja, hogy az alakzat változatlan maradjon, színét megváltoztassák, az animáció után elrejtődjön, vagy a következő kattintásra rejtődjön el. Ha a típus [AfterAnimationType::Color](https://reference.aspose.com/slides/hu/php-java/aspose.slides/afteranimationtype/) , akkor a [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/getafteranimationcolor/) is beállítható.

Ez a független példa létrehoz egy effektust, a visszaadott effektus objektumon keresztül beállítja az animáció utáni viselkedést, majd elmenti az eredményt.

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

A típus [AfterAnimationType::Color](https://reference.aspose.com/slides/hu/php-java/aspose.slides/afteranimationtype/)‑ról való eltávolítása törli az animáció utáni színbeállítást.

## **Szöveg animálása**

A szöveg animáció két kapcsolódó vezérlővel rendelkezik:

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textanimation/getbuildtype/) szabályozza, hogy a bekezdések együtt vagy bekezdésenként jelenjenek meg.
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/getanimatetexttype/) szabályozza, hogy a szöveg egyszerre, szó szerint vagy betű szerint jelenjen meg. A [Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/getdelaybetweentextparts/) beállítja a szavak vagy betűk közti késleltetést. A pozitív érték az effektus időtartamának százaléka; a negatív érték másodpercben megadott késleltetés.

A következő független példa egy szövegdoboz szavait animálja. A [BuildType::AsOneObject](https://reference.aspose.com/slides/hu/php-java/aspose.slides/buildtype/) letiltja a bekezdésenkénti építést, így a szó beállítás az egész szövegkeretre vonatkozik.

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

A szövegdoboz bekezdésenkénti felépítéséhez állítsa be a [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/hu/php-java/aspose.slides/buildtype/) (vagy más bekezdési szint) értéket. Egyetlen bekezdés saját effektussal való célzásához használja a [Sequence::addEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sequence/addeffect/) túlterhelt változatát, amely egy [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) objektumot fogad. Lásd a [Animated Text](/slides/hu/php-java/animated-text/) oldalt a bekezdés szintű példákért.

## **Exportálási és kompatibilitási megjegyzések**

- A PPT vagy PPTX formátumba mentés megőrzi az animációs modellt, de a végső lejátszást a prezentációs megjelenítő szabályozza.
- A PDF és a statikus képek nem játszanak animációkat. Használjon [HTML5 export](/slides/hu/php-java/export-to-html5/), animált GIF-et vagy [video conversion](/slides/hu/php-java/convert-powerpoint-to-video/) lehetőséget, ha a kimenetnek mozgást kell mutatnia.
- HTML5 esetén engedélyezze a [Html5Options::setAnimateShapes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/html5options/setanimateshapes/) beállítást, és szükség esetén a [Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/html5options/setanimatetransitions/) beállítást.
- A videó renderelés sok gyakori belépő, hangsúlyozó, kilépő és mozgásútra ható effektust támogat, de nem minden PowerPoint effektus támogatott. Ellenőrizze az aktuális [supported animations and effects](/slides/hu/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) listát, és tesztelje a kritikus prezentációkat a használt Aspose.Slides verzióval.
- Az egyedi fejlett effektusok és más prezentációs formátumokból importált effektusok megmaradhatnak a fájlban, de másként jelenhetnek meg PowerPointban, HTML5-ben vagy videóban. Ellenőrizze az exportált eredményt, ne csak az effektus nevére támaszkodjon.

## **GYIK**

**Miért jelenik meg egy animáció a PowerPointban, de nem PDF-ben?**

A PDF egy statikus formátum, ezért az animációk és diatranzíciók nem futnak le. Exportáljon HTML5-be, animált GIF-be vagy videóba, ha a mozgást meg kell őrizni.

**Miért játszódik le egy effektus másképp videóban?**

A videó export animációkat renderel, ahelyett, hogy az eredeti PowerPoint viselkedést tárolná. Néhány fejlett effektus nem támogatott vagy csak közelítően jelenik meg. Tekintse át a támogatott effektusok táblázatát, és tesztelje a tényleges prezentációt a gyártási használat előtt.

**Módosítja egy alakzat előre vagy hátra mozgatása az animáció sorrendjét?**

Nem. Az alakzat z-rendje a rétegezést irányítja, míben a szekvencia sorrend és a triggerek az animáció lejátszását. Módosítsa az idővonalat, ha más lejátszási sorrendre van szükség.