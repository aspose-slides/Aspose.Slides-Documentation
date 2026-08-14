---
title: Anwenden von Formanimationen in Präsentationen mit PHP
linktitle: Formanimation
type: docs
weight: 60
url: /de/php-java/shape-animation/
keywords:
- Form
- Animation
- Effekt
- animierte Form
- animierter Text
- Animation hinzufügen
- Animation abrufen
- Animation extrahieren
- Effekt hinzufügen
- Effekt abrufen
- Effekt extrahieren
- Effektsound
- Animation anwenden
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: Erfahren Sie, wie Sie Formanimationen, Timing, Sounds, Nach-Animationsverhalten und animierten Text mit Aspose.Slides für PHP via Java hinzufügen, prüfen und anpassen.
---
## **Übersicht**

Aspose.Slides für PHP via Java stellt Folienanimationen als Effekte in einer Folienzeitleiste dar. Ein Effekt hat eine Zielform, einen Animationstyp und Subtyp, einen Auslöser, Zeiteinstellungen und optionale Eigenschaften wie Ton oder ein Verhalten nach der Animation.

Die Zeitleiste enthält zwei Arten von Sequenzen:

- Die **Hauptsequenz** wird abgespielt, wenn die Folie fortschreitet.
- Eine **interaktive Sequenz** startet, wenn ihre Auslöseform angeklickt wird.

Da Textfelder, Bilder, Diagramme, Tabellen und andere Folienobjekte Formen sind, verwenden Sie dieselbe [Sequence::addEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/sequence/addeffect/) Methode für die meisten Folieninhalte. Die verfügbaren Effekte sind in der Klasse [EffectType](https://reference.aspose.com/slides/de/php-java/aspose.slides/effecttype/) aufgelistet.

## **Formanimationen hinzufügen**

Um eine Animation hinzuzufügen, holen Sie die Hauptsequenz der Folie und rufen Sie [Sequence::addEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/sequence/addeffect/) mit der Zielform, dem Effekttyp, Subtyp und Auslöser auf. Für einen Effekt, der startet, wenn eine andere Form angeklickt wird, erstellen Sie eine interaktive Sequenz, deren Auslöser diese andere Form ist.

Das folgende Beispiel erstellt beide Animationsarten und speichert das Ergebnis in `shape-animations.pptx`.

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

Der Auslöser bestimmt, wann ein Effekt gestartet wird:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/de/php-java/aspose.slides/effecttriggertype/) wartet auf einen Klick in der Hauptsequenz oder auf einen Klick auf die Auslöserform in einer interaktiven Sequenz.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/de/php-java/aspose.slides/effecttriggertype/) startet zusammen mit dem vorherigen Effekt.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/de/php-java/aspose.slides/effecttriggertype/) startet, wenn der vorherige Effekt beendet ist.

Um ein Bild, Diagramm oder einen anderen Formtyp zu animieren, übergeben Sie dieses Objekt an [Sequence::addEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/sequence/addeffect/), anstatt `$targetShape`. Für diagrammspezifische Gruppierungsoptionen siehe [Animierte Diagramme](/slides/de/php-java/animated-charts/).

## **Formanimationen lesen**

Verwenden Sie [Sequence::getEffectsByShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/sequence/geteffectsbyshape/), wenn Sie die Zielform kennen. Um jeden Effekt zu untersuchen, enumerieren Sie die Hauptsequenz und jede interaktive Sequenz. Durch Enumeration wird vermieden, dass man annimmt, eine Sequenz enthielte einen Effekt am Index `0`.

Das folgende Beispiel erstellt eine Form mit Hauptsequenz‑ und interaktiven Effekten, ruft die Effekte ab, die die Form anvisieren, und enumeriert anschließend jede Sequenz auf der Folie.

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

Wenn Sie nur die Effekte für eine Form benötigen, ermitteln Sie zunächst die Form anhand von Name, Platzhaltertyp oder einer anderen stabilen Eigenschaft; rufen Sie dann [Sequence::getEffectsByShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/sequence/geteffectsbyshape/) auf. Gehen Sie nicht davon aus, dass [ShapeCollection::get_Item](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/get_item/) am Index `0` immer das gewünschte Objekt ist.

## **Arbeiten mit geerbten Platzhaltereffekten**

Ein Platzhalter auf einer normalen Folie kann das Animationsverhalten des entsprechenden Platzhalters auf seiner Layout‑Folie und Master‑Folie erben. [Shape::getBasePlaceholder](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/getbaseplaceholder/) gibt diesen übergeordneten Platzhalter zurück, oder `null`, wenn kein übergeordneter Platzhalter existiert.

In der folgenden Beispielpräsentation hat die Fußzeile **Random Bars** auf der normalen Folie, **Split** auf der Layout‑Folie und **Fly In** auf der Master‑Folie.

![Footer-Animations-Effekt auf der normalen Folie](slide-shape-animation.png)

![Footer-Platzhalter-Animations-Effekt auf der Layout‑Folie](layout-shape-animation.png)

![Footer-Platzhalter-Animations-Effekt auf der Master‑Folie](master-shape-animation.png)

Das nächste Beispiel verwendet eine Platzhalterhierarchie aus einer neuen Präsentation. Es fügt Effekte zu einem Master‑Platzhalter, einem Layout‑Platzhalter und dem entsprechenden Platzhalter auf einer normalen Folie hinzu. Jeder Aufruf von [Shape::getBasePlaceholder](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/getbaseplaceholder/) wird geprüft, bevor die zurückgegebene Form verwendet wird.

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

## **Animationszeit ändern**

Der PowerPoint-**Timing**‑Dialog entspricht den Eigenschaften von [Timing](https://reference.aspose.com/slides/de/php-java/aspose.slides/timing/).

![PowerPoint‑Timing‑Dialog für einen Animationseffekt](shape-animation.png)

- **Start** entspricht [Timing::getTriggerType](https://reference.aspose.com/slides/de/php-java/aspose.slides/timing/gettriggertype/).
- **Dauer** entspricht [Timing::getDuration](https://reference.aspose.com/slides/de/php-java/aspose.slides/timing/getduration/), in Sekunden.
- **Verzögerung** entspricht [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/de/php-java/aspose.slides/timing/gettriggerdelaytime/), in Sekunden.
- **Wiederholung** entspricht [Timing::getRepeatCount](https://reference.aspose.com/slides/de/php-java/aspose.slides/timing/getrepeatcount/), [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/de/php-java/aspose.slides/timing/getrepeatuntilnextclick/), oder [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/timing/getrepeatuntilendslide/).
- **Zurückspulen nach dem Abspielen** entspricht [Timing::getRewind](https://reference.aspose.com/slides/de/php-java/aspose.slides/timing/getrewind/).

Dieses eigenständige Beispiel fügt einen Effekt hinzu, ändert dessen Timing über das von [Sequence::addEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/sequence/addeffect/) zurückgegebene Objekt und speichert das Ergebnis. Das Beibehalten der zurückgegebenen [Effect](https://reference.aspose.com/slides/de/php-java/aspose.slides/effect/)‑Referenz vermeidet einen unnötigen Sammlungs‑Index.

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

Verwenden Sie bewusst nur einen Wiederholungsmodus. Die Kombination einer Wiederholungsanzahl mit einem „until“-Flag kann in verschiedenen Betrachtern verwirrende Ergebnisse erzeugen. Beim Ändern der Wiederholungsmodi setzen Sie [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/de/php-java/aspose.slides/timing/setrepeatuntilnextclick/) und [Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/timing/setrepeatuntilendslide/) vor [Timing::setRepeatCount](https://reference.aspose.com/slides/de/php-java/aspose.slides/timing/setrepeatcount/), da das Setzen eines Flags ebenfalls den aktiven Wiederholungsmodus ändert.

## **Animationssounds hinzufügen und extrahieren**

Ein Animationseffekt kann über [Effect::getSound](https://reference.aspose.com/slides/de/php-java/aspose.slides/effect/getsound/) auf eingebettetes Audio verweisen. [Effect::setStopPreviousSound](https://reference.aspose.com/slides/de/php-java/aspose.slides/effect/setstopprevioussound/) weist einen Effekt an, Audio zu stoppen, das von einem früheren Effekt gestartet wurde.

### **Einen Sound zu einem Effekt hinzufügen**

Das folgende Beispiel erwartet eine lokale Audiodatei namens `animation-sound.wav`. Es erstellt zwei Effekte, bindet diese Datei als Sound für den ersten Effekt ein und konfiguriert den zweiten Effekt, den Sound zu stoppen. Es verwendet die von [Sequence::addEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/sequence/addeffect/) zurückgegebenen Objekte, sodass kein Sequenz‑Index erforderlich ist.

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

### **Eingebettete Effekt‑Sounds extrahieren**

Das folgende Beispiel erwartet eine lokale Präsentation namens `presentation-with-animation-sounds.pptx`. Es durchsucht sowohl die Haupt‑ als auch die interaktiven Sequenzen und schreibt jeden eingebetteten Effekt‑Sound in das Verzeichnis `extracted-animation-sounds`. Die Erweiterung wird aus dem Audio‑MIME‑Typ ermittelt, der von [Audio::getContentType](https://reference.aspose.com/slides/de/php-java/aspose.slides/audio/getcontenttype/) bereitgestellt wird.

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

Für große Audio‑Objekte verwenden Sie [Audio::getStream](https://reference.aspose.com/slides/de/php-java/aspose.slides/audio/getstream/) und kopieren den Stream in eine Datei, anstatt das gesamte Objekt in ein Byte‑Array zu laden.

## **Nach‑Animationsverhalten festlegen**

Die Option **After animation** bestimmt, was mit einer Form passiert, nachdem ihr Effekt beendet ist.

![PowerPoint‑Effektoptionen‑Dialog, der After‑Animation‑Einstellungen zeigt](shape-after-animation.png)

Die Klasse [AfterAnimationType](https://reference.aspose.com/slides/de/php-java/aspose.slides/afteranimationtype/) unterstützt das Belassen der Form unverändert, das Ändern ihrer Farbe, das Ausblenden nach der Animation oder das Ausblenden beim nächsten Klick. Wenn der Typ [AfterAnimationType::Color](https://reference.aspose.com/slides/de/php-java/aspose.slides/afteranimationtype/) ist, setzen Sie ebenfalls [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/de/php-java/aspose.slides/effect/getafteranimationcolor/).

Dieses eigenständige Beispiel erstellt einen Effekt, legt sein Nach‑Animation‑Verhalten über das zurückgegebene Effektobjekt fest und speichert das Ergebnis.

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

Das Ändern des Typs von [AfterAnimationType::Color](https://reference.aspose.com/slides/de/php-java/aspose.slides/afteranimationtype/) entfernt die Nach‑Animation‑Farbeinstellung.

## **Text animieren**

Textanimation hat zwei verwandte Steuerungen:

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/de/php-java/aspose.slides/textanimation/getbuildtype/) bestimmt, ob Absätze gemeinsam oder auf Absatz‑Ebene erscheinen.
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/de/php-java/aspose.slides/effect/getanimatetexttype/) bestimmt, ob Text auf einmal, Wort für Wort oder Buchstabe für Buchstabe erscheint. [Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/de/php-java/aspose.slides/effect/getdelaybetweentextparts/) legt die Verzögerung zwischen Wörtern oder Buchstaben fest. Ein positiver Wert ist ein Prozentsatz der Effektdauer; ein negativer Wert ist eine Verzögerung in Sekunden.

Das folgende eigenständige Beispiel animiert die Wörter in einem Textfeld. [BuildType::AsOneObject](https://reference.aspose.com/slides/de/php-java/aspose.slides/buildtype/) deaktiviert das schrittweise Aufbauen von Absätzen, sodass die Wort‑Einstellung auf den gesamten Textrahmen angewendet wird.

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

Um ein Textfeld Absatz für Absatz aufzubauen, setzen Sie [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/de/php-java/aspose.slides/buildtype/) (oder ein anderes Absatzniveau). Um einen einzelnen Absatz mit einem eigenen Effekt anzusprechen, verwenden Sie die Überladung von [Sequence::addEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/sequence/addeffect/), die ein [Paragraph](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraph/) akzeptiert. Siehe [Animierter Text](/slides/de/php-java/animated-text/) für Beispiele auf Absatz‑Ebene.

## **Export‑ und Kompatibilitäts‑Hinweise**

- Das Speichern als PPT oder PPTX erhält das Animationsmodell, aber die endgültige Wiedergabe wird vom Präsentations‑Viewer gesteuert.
- PDF und statische Bilder spielen keine Animationen ab. Verwenden Sie [HTML5‑Export](/slides/de/php-java/export-to-html5/), animierte GIFs oder [Videokonvertierung](/slides/de/php-java/convert-powerpoint-to-video/), wenn das Ergebnis Bewegung zeigen muss.
- Für HTML5 aktivieren Sie [Html5Options::setAnimateShapes](https://reference.aspose.com/slides/de/php-java/aspose.slides/html5options/setanimateshapes/) und bei Bedarf [Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/de/php-java/aspose.slides/html5options/setanimatetransitions/).
- Die Videowiedergabe unterstützt viele gängige Eingangs‑, Betonungs‑, Ausgangs‑ und Motion‑Path‑Effekte, aber nicht jeder PowerPoint‑Effekt wird unterstützt. Prüfen Sie die aktuelle [unterstützten Animationen und Effekte](/slides/de/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) und testen Sie kritische Präsentationen mit Ihrer Ziel‑Aspose.Slides‑Version.
- Erweiterte benutzerdefinierte Effekte und aus anderen Präsentationsformaten importierte Effekte können in der Datei erhalten bleiben, werden jedoch in PowerPoint, HTML5 oder Video unterschiedlich wiedergegeben. Validieren Sie das exportierte Ergebnis, anstatt sich ausschließlich auf den Effektnamen zu verlassen.

## **FAQ**

**Warum wird eine Animation in PowerPoint angezeigt, aber nicht in einer PDF?**

PDF ist ein statisches Format, daher werden Animationen und Folienübergänge nicht abgespielt. Exportieren Sie zu HTML5, animierten GIFs oder Video, wenn Bewegung erhalten bleiben muss.

**Warum wird ein Effekt in einem Video anders wiedergegeben?**

Der Video‑Export rendert Animationen, anstatt das ursprüngliche PowerPoint‑Verhalten zu speichern. Einige fortgeschrittene Effekte werden nicht unterstützt oder approximiert. Überprüfen Sie die Tabelle der unterstützten Effekte und testen Sie die tatsächliche Präsentation vor dem Produktionseinsatz.

**Ändert das Vorwärts‑ oder Rückwärtsverschieben einer Form ihre Animationsreihenfolge?**

Nein. Die Z‑Reihenfolge einer Form steuert die Überlappung, während die Sequenzreihenfolge und die Auslöser die Animationswiedergabe bestimmen. Ändern Sie die Zeitleiste, wenn Sie eine andere Wiedergabereihenfolge benötigen.