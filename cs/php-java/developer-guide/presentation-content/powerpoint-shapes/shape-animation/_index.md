---
title: Použití animací tvarů v prezentacích pomocí PHP
linktitle: Animace tvarů
type: docs
weight: 60
url: /cs/php-java/shape-animation/
keywords:
- tvar
- animace
- efekt
- animovaný tvar
- animovaný text
- přidat animaci
- získat animaci
- extrahovat animaci
- přidat efekt
- získat efekt
- extrahovat efekt
- zvuk efektu
- aplikovat animaci
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak přidávat, kontrolovat a přizpůsobovat animace tvarů, načasování, zvuky, chování po animaci a animovaný text pomocí Aspose.Slides pro PHP prostřednictvím Java."
---
## **Přehled**

Aspose.Slides for PHP via Java představuje animace snímků jako efekty v časové ose snímku. Efekt má cílový tvar, typ a podtyp animace, spouštěč, nastavení načasování a volitelné vlastnosti jako zvuk nebo chování po animaci.

Časová osa obsahuje dva typy sekvencí:

- **Hlavní sekvence** se přehrává při postupu snímku.
- **Interaktivní sekvence** se spustí, když je kliknuto na její spouštěcí tvar.

Protože textová pole, obrázky, grafy, tabulky a jiné objekty snímku jsou tvary, používáte stejnou metodu [Sequence::addEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sequence/addeffect/) pro většinu obsahu snímku. Dostupné efekty jsou uvedeny ve třídě [EffectType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effecttype/).

## **Přidání animací tvarů**

Chcete-li přidat animaci, získejte hlavní sekvenci snímku a zavolejte [Sequence::addEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sequence/addeffect/) s cílovým tvarem, typem efektu, podtypem a spouštěčem. Pro efekt, který se spustí po kliknutí na jiný tvar, vytvořte interaktivní sekvenci, jejíž spouštěč je tento jiný tvar.

Následující příklad vytvoří oba typy animací a uloží výsledek do `shape-animations.pptx`.

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

Spouštěč určuje, kdy efekt začne:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effecttriggertype/) čeká na kliknutí v hlavní sekvenci nebo na kliknutí na spouštěcí tvar v interaktivní sekvenci.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effecttriggertype/) začíná spolu s předchozím efektem.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effecttriggertype/) začíná po dokončení předchozího efektu.

Chcete-li animovat obrázek, graf nebo jiný typ tvaru, předávejte tento objekt metodě [Sequence::addEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sequence/addeffect/) místo `$targetShape`. Pro možnost seskupování specifické pro grafy viz [Animated Charts](/slides/cs/php-java/animated-charts/).

## **Čtení animací tvarů**

Použijte [Sequence::getEffectsByShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sequence/geteffectsbyshape/) když znáte cílový tvar. Pro prohlédnutí každého efektu enumerujte hlavní sekvenci i všechny interaktivní sekvence. Enumerace zabraňuje předpokladu, že sekvence obsahuje efekt na indexu `0`.

Následující příklad vytvoří tvar s efekty v hlavní i interaktivní sekvenci, získá efekty cílící na tvar a poté enumeruje každou sekvenci na snímku.

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

Pokud potřebujete efekty jen pro jeden tvar, nejprve identifikujte tvar podle názvu, typu zástupného objektu nebo jiné stabilní vlastnosti; pak zavolejte [Sequence::getEffectsByShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sequence/geteffectsbyshape/). Nepředpokládejte, že [ShapeCollection::get_Item](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/get_item/) na indexu `0` je vždy požadovaný objekt.

## **Práce s děděnými efekty zástupných objektů**

Zástupný objekt na normálním snímku může dědit chování animace z odpovídajícího zástupného objektu na rozložení snímku a hlavním snímku. [Shape::getBasePlaceholder](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getbaseplaceholder/) vrací tento nadřazený zástupný objekt nebo `null`, pokud neexistuje.

V následujícím ukázkovém souboru má zápatí **Random Bars** na normálním snímku, **Split** na rozložení snímku a **Fly In** na hlavním snímku.

![Efekt animace zápatí na normálním snímku](slide-shape-animation.png)

![Efekt animace zástupného objektu zápatí na rozložení snímku](layout-shape-animation.png)

![Efekt animace zástupného objektu zápatí na předloze snímku](master-shape-animation.png)

Další příklad používá hierarchii zástupných objektů z nové prezentace. Přidává efekty k hlavnímu zástupnému objektu, k zástupnému objektu rozložení a k odpovídajícímu zástupnému objektu na normálním snímku. Každé volání [Shape::getBasePlaceholder](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getbaseplaceholder/) je před použitím vráceného tvaru ověřeno.

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

## **Změna načasování animace**

Dialog **Timing** v PowerPointu mapuje na vlastnosti třídy [Timing](https://reference.aspose.com/slides/cs/php-java/aspose.slides/timing/).

![Dialog načasování PowerPointu pro efekt animace](shape-animation.png)

- **Start** mapuje na [Timing::getTriggerType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/timing/gettriggertype/).
- **Duration** mapuje na [Timing::getDuration](https://reference.aspose.com/slides/cs/php-java/aspose.slides/timing/getduration/), v sekundách.
- **Delay** mapuje na [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/cs/php-java/aspose.slides/timing/gettriggerdelaytime/), v sekundách.
- **Repeat** mapuje na [Timing::getRepeatCount](https://reference.aspose.com/slides/cs/php-java/aspose.slides/timing/getrepeatcount/), [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/cs/php-java/aspose.slides/timing/getrepeatuntilnextclick/) nebo [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/timing/getrepeatuntilendslide/).
- **Rewind when done playing** mapuje na [Timing::getRewind](https://reference.aspose.com/slides/cs/php-java/aspose.slides/timing/getrewind/).

Tento samostatný příklad přidá efekt, změní jeho načasování pomocí objektu vráceného metodou [Sequence::addEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sequence/addeffect/) a uloží výsledek. Uchování reference na vrácený [Effect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effect/) zabraňuje zbytečnému indexování kolekce.

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

Používejte jeden režim opakování úmyslně. Kombinace počtu opakování s příznakem „until“ může v různých prohlížečích vést ke zmateným výsledkům. Při změně režimu opakování nastavte [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/cs/php-java/aspose.slides/timing/setrepeatuntilnextclick/) a [Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/timing/setrepeatuntilendslide/) před [Timing::setRepeatCount](https://reference.aspose.com/slides/cs/php-java/aspose.slides/timing/setrepeatcount/), protože nastavení některého z příznaků také mění aktivní režim opakování.

## **Přidání a extrakce zvuků animace**

Animovaný efekt může odkazovat na vložený zvuk pomocí [Effect::getSound](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effect/getsound/). [Effect::setStopPreviousSound](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effect/setstopprevioussound/) říká efektu, aby zastavil zvuk zahájený předchozím efektem.

### **Přidání zvuku k efektu**

Následující příklad očekává lokální zvukový soubor s názvem `animation-sound.wav`. Vytvoří dva efekty, vloží tento soubor jako zvuk pro první efekt a nakonfiguruje druhý efekt tak, aby zvuk zastavil. Používá objekty vrácené metodou [Sequence::addEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sequence/addeffect/), takže není potřeba index sekvence.

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

### **Extrahování vložených zvuků efektu**

Následující příklad očekává lokální prezentaci s názvem `presentation-with-animation-sounds.pptx`. Prohledá jak hlavní, tak interaktivní sekvence a zapíše každý vložený zvuk efektu do adresáře `extracted-animation-sounds`. Přípona je vybrána podle MIME typu zvuku, který poskytuje [Audio::getContentType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/audio/getcontenttype/).

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

Pro velké zvukové objekty použijte [Audio::getStream](https://reference.aspose.com/slides/cs/php-java/aspose.slides/audio/getstream/) a zkopírujte stream do souboru místo načítání celého objektu do pole bajtů.

## **Nastavení chování po animaci**

Možnost **After animation** určuje, co se stane s tvarem po dokončení jeho efektu.

![Dialog možností efektu PowerPointu zobrazující nastavení Po animaci](shape-after-animation.png)

Třída [AfterAnimationType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/afteranimationtype/) podporuje ponechání tvaru beze změny, změnu jeho barvy, skrytí po animaci nebo skrytí při dalším kliknutí. Když je typ [AfterAnimationType::Color](https://reference.aspose.com/slides/cs/php-java/aspose.slides/afteranimationtype/), nastavte také [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effect/getafteranimationcolor/).

Tento samostatný příklad vytvoří efekt, nastaví jeho chování po animaci pomocí vráceného objektu efektu a výsledek uloží.

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

Změna typu od [AfterAnimationType::Color](https://reference.aspose.com/slides/cs/php-java/aspose.slides/afteranimationtype/) vymaže nastavení barvy po animaci.

## **Animace textu**

Animace textu má dva související ovladače:

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textanimation/getbuildtype/) určuje, zda se odstavce zobrazí najednou nebo po odstavcích.
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effect/getanimatetexttype/) určuje, zda se text zobrazí najednou, po slovech nebo po písmenkách. [Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effect/getdelaybetweentextparts/) nastavuje prodlevu mezi slovy nebo písmeny. Kladná hodnota představuje procento trvání efektu; záporná hodnota je prodleva v sekundách.

Následující samostatný příklad animuje slova v textovém poli. [BuildType::AsOneObject](https://reference.aspose.com/slides/cs/php-java/aspose.slides/buildtype/) vypíná budování po odstavcích, takže nastavení pro slova platí pro celý textový rámec.

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

Pro budování textového pole po odstavcích nastavte [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/cs/php-java/aspose.slides/buildtype/) (nebo jinou úroveň odstavce). Pro cílení na jednotlivý odstavec s vlastním efektem použijte přetíženou metodu [Sequence::addEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sequence/addeffect/) přijímající [Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/). Viz [Animated Text](/slides/cs/php-java/animated-text/) pro příklady na úrovni odstavců.

## **Export a poznámky o kompatibilitě**

- Ukládání do PPT nebo PPTX zachovává model animace, ale finální přehrávání řídí prohlížeč prezentací.
- PDF a statické obrázky neumožňují přehrávání animací. Použijte [HTML5 export](/slides/cs/php-java/export-to-html5/), animovaný GIF nebo [konverzi videa](/slides/cs/php-java/convert-powerpoint-to-video/), když výstup musí ukazovat pohyb.
- Pro HTML5 povolte [Html5Options::setAnimateShapes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/html5options/setanimateshapes/) a podle potřeby také [Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/html5options/setanimatetransitions/).
- Renderování videa podporuje mnoho běžných vstupních, důrazových, výstupních a pohybových efektů, ale ne každý efekt PowerPointu je podporován. Zkontrolujte aktuální [supported animations and effects](/slides/cs/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) a otestujte kritické prezentace s vaší cílovou verzí Aspose.Slides.
- Pokročilé vlastní efekty a efekty importované z jiných formátů prezentací mohou být v souboru zachovány, ale vykreslují se odlišně v PowerPointu, HTML5 nebo videu. Ověřte exportovaný výsledek místo spoléhaní se jen na název efektu.

## **Časté otázky**

**Proč se animace zobrazí v PowerPointu, ale ne v PDF?**

PDF je statický formát, takže animace a přechody snímků se nepřehrávají. Exportujte do HTML5, animovaného GIFu nebo videa, když je nutné zachovat pohyb.

**Proč se efekt v videu přehrává odlišně?**

Export do videa renderuje animace místo uložení původního chování PowerPointu. Některé pokročilé efekty nejsou podporovány nebo jsou aproximovány. Prohlédněte si tabulku podporovaných efektů a otestujte skutečnou prezentaci před nasazením do výroby.

**Mění změna pořadí tvaru (vpřed/vzad) pořadí jeho animace?**

Ne. Z‑order tvaru řídí překrývání, zatímco pořadí sekvence a spouštěče řídí přehrávání animace. Změňte časovou osu, pokud potřebujete jiný pořadí přehrávání.