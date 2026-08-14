---
title: Zastosowanie animacji kształtów w prezentacjach przy użyciu PHP
linktitle: Animacja kształtu
type: docs
weight: 60
url: /pl/php-java/shape-animation/
keywords:
- kształt
- animacja
- efekt
- animowany kształt
- animowany tekst
- dodaj animację
- pobierz animację
- wyodrębnij animację
- dodaj efekt
- pobierz efekt
- wyodrębnij efekt
- dźwięk efektu
- zastosuj animację
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak dodawać, przeglądać i dostosowywać animacje kształtów, synchronizację, dźwięki, zachowanie po animacji oraz animowany tekst za pomocą Aspose.Slides dla PHP poprzez Java."
---
## **Przegląd**

Aspose.Slides for PHP via Java reprezentuje animacje slajdów jako efekty w osi czasu slajdu. Efekt ma docelowy kształt, typ i podtyp animacji, wyzwalacz, ustawienia czasu oraz opcjonalne właściwości, takie jak dźwięk lub zachowanie po zakończeniu animacji.

Oś czasu zawiera dwa rodzaje sekwencji:

- **Główna sekwencja** odtwarzana jest w miarę przechodzenia slajdu.
- **Interaktywna sekwencja** rozpoczyna się po kliknięciu kształtu wyzwalającego.

Ponieważ pola tekstowe, obrazy, wykresy, tabele i inne obiekty slajdu są kształtami, używasz tej samej metody [Sequence::addEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sequence/addeffect/) dla większości zawartości slajdu. Dostępne efekty są wymienione w klasie [EffectType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/effecttype/).

## **Dodawanie animacji kształtów**

Aby dodać animację, pobierz główną sekwencję slajdu i wywołaj [Sequence::addEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sequence/addeffect/) z docelowym kształtem, typem efektu, podtypem i wyzwalaczem. Dla efektu, który zaczyna się po kliknięciu innego kształtu, utwórz interaktywną sekwencję, której wyzwalaczem jest ten inny kształt.

Poniższy przykład tworzy oba typy animacji i zapisuje wynik do `shape-animations.pptx`.

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

Wyzwalacz określa, kiedy efekt się rozpoczyna:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/pl/php-java/aspose.slides/effecttriggertype/) czeka na kliknięcie w głównej sekwencji lub na kliknięcie kształtu wyzwalającego w sekwencji interaktywnej.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/pl/php-java/aspose.slides/effecttriggertype/) zaczyna się razem z poprzednim efektem.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/pl/php-java/aspose.slides/effecttriggertype/) zaczyna się po zakończeniu poprzedniego efektu.

Aby animować obraz, wykres lub inny typ kształtu, przekaż ten obiekt do [Sequence::addEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sequence/addeffect/) zamiast `$targetShape`. Opcje grupowania specyficzne dla wykresów znajdziesz w sekcji [Animated Charts](/slides/pl/php-java/animated-charts/).

## **Odczytywanie animacji kształtów**

Użyj [Sequence::getEffectsByShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sequence/geteffectsbyshape/) gdy znasz docelowy kształt. Aby przejrzeć każdy efekt, wylicz główną sekwencję oraz wszystkie sekwencje interaktywne. Wyliczanie zapobiega założeniu, że sekwencja zawiera efekt pod indeksem `0`.

Poniższy przykład tworzy kształt z efektami w głównej i interaktywnej sekwencji, pobiera efekty skierowane do tego kształtu i następnie wylicza wszystkie sekwencje na slajdzie.

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

Jeśli potrzebujesz efektów tylko dla jednego kształtu, najpierw zidentyfikuj kształt po nazwie, typie placeholdera lub innej stabilnej właściwości; potem wywołaj [Sequence::getEffectsByShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sequence/geteffectsbyshape/). Nie zakładaj, że [ShapeCollection::get_Item](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/get_item/) pod indeksem `0` zawsze wskazuje na zamierzony obiekt.

## **Praca z odziedziczonymi efektami zastępczymi**

Placeholder na zwykłym slajdzie może dziedziczyć zachowanie animacji z odpowiadającego mu placeholdera na slajdzie układu i slajdzie master. [Shape::getBasePlaceholder](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getbaseplaceholder/) zwraca ten nadrzędny placeholder lub `null`, gdy nie istnieje żaden rodzic.

W poniższej przykładowej prezentacji stopka ma **Random Bars** na zwykłym slajdzie, **Split** na slajdzie układu i **Fly In** na slajdzie master.

![Efekt animacji stopki na normalnym slajdzie](slide-shape-animation.png)

![Efekt animacji stopki na slajdzie układu](layout-shape-animation.png)

![Efekt animacji stopki na slajdzie master](master-shape-animation.png)

Kolejny przykład wykorzystuje hierarchię placeholderów z nowej prezentacji. Dodaje efekty do placeholdera master, placeholdera układu i odpowiadającego mu placeholdera na zwykłym slajdzie. Każde wywołanie [Shape::getBasePlaceholder](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getbaseplaceholder/) jest sprawdzane przed użyciem zwróconego kształtu.

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

## **Zmiana czasu animacji**

Okno dialogowe PowerPoint **Timing** odzwierciedla właściwości klasy [Timing](https://reference.aspose.com/slides/pl/php-java/aspose.slides/timing/).

![Okno dialogowe PowerPoint Timing dla efektu animacji](shape-animation.png)

- **Start** mapuje do [Timing::getTriggerType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/timing/gettriggertype/).
- **Duration** mapuje do [Timing::getDuration](https://reference.aspose.com/slides/pl/php-java/aspose.slides/timing/getduration/), w sekundach.
- **Delay** mapuje do [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/pl/php-java/aspose.slides/timing/gettriggerdelaytime/), w sekundach.
- **Repeat** mapuje do [Timing::getRepeatCount](https://reference.aspose.com/slides/pl/php-java/aspose.slides/timing/getrepeatcount/), [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/pl/php-java/aspose.slides/timing/getrepeatuntilnextclick/) lub [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/timing/getrepeatuntilendslide/).
- **Rewind when done playing** mapuje do [Timing::getRewind](https://reference.aspose.com/slides/pl/php-java/aspose.slides/timing/getrewind/).

Ten niezależny przykład dodaje efekt, zmienia jego czas za pomocą obiektu zwróconego przez [Sequence::addEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sequence/addeffect/), i zapisuje wynik. Przechowywanie odwołania do zwróconego [Effect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/effect/) unika niepotrzebnego indeksu kolekcji.

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

Używaj jednego trybu powtarzania celowo. Łączenie liczby powtórzeń z flagą „until” może dawać mylące wyniki w różnych odtwarzaczach. Przy zmianie trybów powtarzania najpierw ustaw [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/pl/php-java/aspose.slides/timing/setrepeatuntilnextclick/) i [Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/timing/setrepeatuntilendslide/), a dopiero potem [Timing::setRepeatCount](https://reference.aspose.com/slides/pl/php-java/aspose.slides/timing/setrepeatcount/), ponieważ ustawienie którejkolwiek flagi zmienia także aktywny tryb powtarzania.

## **Dodawanie i wyodrębnianie dźwięków animacji**

Efekt animacji może odwoływać się do osadzonego dźwięku za pomocą [Effect::getSound](https://reference.aspose.com/slides/pl/php-java/aspose.slides/effect/getsound/). [Effect::setStopPreviousSound](https://reference.aspose.com/slides/pl/php-java/aspose.slides/effect/setstopprevioussound/) nakazuje efektowi zatrzymać dźwięk rozpoczęty przez wcześniejszy efekt.

### **Dodaj dźwięk do efektu**

Poniższy przykład zakłada lokalny plik audio o nazwie `animation-sound.wav`. Tworzy dwa efekty, osadza ten plik jako dźwięk pierwszego efektu i konfiguruje drugi efekt tak, aby zatrzymywał dźwięk. Używa obiektów zwróconych przez [Sequence::addEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sequence/addeffect/), więc nie jest wymagany indeks sekwencji.

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

### **Wyodrębnij wbudowane dźwięki efektów**

Poniższy przykład zakłada lokalną prezentację o nazwie `presentation-with-animation-sounds.pptx`. Przeszukuje zarówno główne, jak i interaktywne sekwencje i zapisuje każdy wbudowany dźwięk efektu do katalogu `extracted-animation-sounds`. Rozszerzenie jest wybierane na podstawie typu MIME audio zwracanego przez [Audio::getContentType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/audio/getcontenttype/).

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

Dla dużych obiektów audio użyj [Audio::getStream](https://reference.aspose.com/slides/pl/php-java/aspose.slides/audio/getstream/) i skopiuj strumień do pliku zamiast wczytywać cały obiekt do tablicy bajtów.

## **Ustaw zachowanie po animacji**

Opcja **After animation** określa, co się dzieje z kształtem po zakończeniu jego efektu.

![Okno dialogowe PowerPoint Effect Options pokazujące ustawienia After animation](shape-after-animation.png)

Klasa [AfterAnimationType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/afteranimationtype/) umożliwia pozostawienie kształtu niezmienionego, zmianę jego koloru, ukrycie po animacji lub ukrycie przy następnym kliknięciu. Gdy typ to [AfterAnimationType::Color](https://reference.aspose.com/slides/pl/php-java/aspose.slides/afteranimationtype/), ustaw również [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/effect/getafteranimationcolor/).

Ten niezależny przykład tworzy efekt, ustawia jego zachowanie po animacji przez zwrócony obiekt efektu i zapisuje wynik.

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

Zmiana typu z [AfterAnimationType::Color](https://reference.aspose.com/slides/pl/php-java/aspose.slides/afteranimationtype/) usuwa ustawienie koloru po animacji.

## **Animowanie tekstu**

Animacja tekstu ma dwa powiązane sterowania:

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textanimation/getbuildtype/) kontroluje, czy akapity pojawiają się razem czy poziomowo.
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/effect/getanimatetexttype/) kontroluje, czy tekst pojawia się jednocześnie, słowo po słowie lub litera po literze. [Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/pl/php-java/aspose.slides/effect/getdelaybetweentextparts/) ustawia opóźnienie między słowami lub literami. Wartość dodatnia to procent czasu trwania efektu; wartość ujemna to opóźnienie w sekundach.

Poniższy niezależny przykład animuje słowa w polu tekstowym. [BuildType::AsOneObject](https://reference.aspose.com/slides/pl/php-java/aspose.slides/buildtype/) wyłącza budowanie akapit po akapicie, tak aby ustawienie słowa obowiązywało dla całej ramki tekstowej.

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

Aby budować pole tekstowe akapit po akapicie, ustaw [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/pl/php-java/aspose.slides/buildtype/) (lub inny poziom akapitu). Aby skierować pojedynczy akapit z własnym efektem, użyj przeciążenia [Sequence::addEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sequence/addeffect/) przyjmującego [Paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/). Zobacz [Animated Text](/slides/pl/php-java/animated-text/) po przykłady na poziomie akapitu.

## **Uwagi dotyczące eksportu i kompatybilności**

- Zapisywanie do PPT lub PPTX zachowuje model animacji, ale ostateczne odtwarzanie jest sterowane przez przeglądarkę prezentacji.
- PDF i obrazy statyczne nie odtwarzają animacji. Użyj [HTML5 export](/slides/pl/php-java/export-to-html5/), animowanego GIF-a lub [video conversion](/slides/pl/php-java/convert-powerpoint-to-video/) gdy wyjście musi pokazać ruch.
- Dla HTML5 włącz [Html5Options::setAnimateShapes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/html5options/setanimateshapes/) i, w razie potrzeby, [Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/html5options/setanimatetransitions/).
- Renderowanie wideo obsługuje wiele popularnych efektów wejścia, podkreślenia, wyjścia i ścieżek ruchu, ale nie każdy efekt PowerPoint jest obsługiwany. Sprawdź aktualną [supported animations and effects](/slides/pl/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) i przetestuj krytyczne prezentacje w docelowej wersji Aspose.Slides.
- Zaawansowane efekty niestandardowe i efekty zaimportowane z innych formatów prezentacji mogą być zachowane w pliku, ale renderowane inaczej w PowerPoint, HTML5 lub wideo. Zweryfikuj wynik eksportu zamiast polegać wyłącznie na nazwie efektu.

## **FAQ**

**Dlaczego animacja pojawia się w PowerPoint, ale nie w PDF?**

PDF jest formatem statycznym, więc animacje i przejścia slajdów nie są odtwarzane. Eksportuj do HTML5, animowanego GIF-a lub wideo, gdy ruch musi zostać zachowany.

**Dlaczego efekt odtwarzany jest inaczej w wideo?**

Eksport wideo renderuje animacje zamiast przechowywać oryginalne zachowanie PowerPoint. Niektóre zaawansowane efekty nie są obsługiwane lub są przybliżane. Przejrzyj tabelę obsługiwanych efektów i przetestuj rzeczywistą prezentację przed użyciem w produkcji.

**Czy przeniesienie kształtu do przodu lub do tyłu zmienia kolejność jego animacji?**

Nie. Z‑order kształtu kontroluje nakładanie się, natomiast kolejność sekwencji i wyzwalacze kontrolują odtwarzanie animacji. Zmieniaj oś czasu, jeśli potrzebujesz innej kolejności odtwarzania.