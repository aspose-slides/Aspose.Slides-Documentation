---
title: Beheer diaovergangen in presentaties met PHP
linktitle: Diaovergang
type: docs
weight: 80
url: /nl/php-java/slide-transition/
keywords:
- diaovergang
- diaovergang toevoegen
- diaovergang toepassen
- geavanceerde diaovergang
- Morph-overgang
- overgangstype
- overgangseffect
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Pas diaovergangen toe, configureer automatische dia-voortzetting en pas Morph en andere overgangseffecten aan met Aspose.Slides voor PHP via Java."
---
## **Overzicht**

Diaovergangen bepalen hoe dia's verschijnen tijdens een diavoorstelling. Met Aspose.Slides voor PHP via Java kunt u voor elke dia een overgangseffect kiezen, de voortgang instellen via muisklik of timer, en opties die specifiek zijn voor een effect aanpassen. Dit artikel gebruikt PHP‑voorbeelden om overgangen toe te passen, exacte overgangsduren in te stellen, de timing van dia's te beheren en een Morph‑overgang tussen twee dia's te maken. De voorbeelden laten ook zien hoe de instellingen naar een PPTX‑bestand kunnen worden opgeslagen.

## **Diaovergang toevoegen**

Om een overgang toe te passen, laad een presentatie met de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse en krijg toegang tot de overgangsinstellingen van de dia via [getSlideShowTransition](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseslide/#getSlideShowTransition). Gebruik [setType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/#setType) met een waarde uit de enumeratie [TransitionType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/transitiontype/), en sla vervolgens de presentatie op.

Het onderstaande voorbeeld past een Circle‑overgang toe op de eerste dia en een Comb‑overgang op de tweede. Gebruik een `input.pptx`‑bestand met ten minste twee dia's.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
        $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);

        $presentation->save("slide-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Geavanceerde diaovergang toevoegen**

U kunt configureren hoe lang een dia op het scherm blijft en of een muisklik de diavoorstelling voortzet. De volgende methoden regelen dit gedrag:

- [setAdvanceOnClick](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) stelt de kijker in staat om door te klikken met de muis.
- [setAdvanceAfter](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) schakelt automatische voortzetting in.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) specificeert de vertraging vóór automatische voortzetting, in milliseconden.

Schakel zowel klik‑ als timer‑voortzetting in zodat de kijker verder kan gaan met een klik of kan wachten op de timer. Om alleen de timer te gebruiken, geef `false` door aan [setAdvanceOnClick](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). De vertraging bepaalt wanneer de diavoorstelling wordt voortgezet; hij stelt niet de duur van het visuele overgangseffect in.

Dit voorbeeld kent verschillende effecten toe aan de eerste drie dia's en schakelt automatische voortzetting in na respectievelijk 3, 5 en 7 seconden. Muisklikken kunnen deze dia's ook voortzetten. Gebruik een `input.pptx`‑bestand met ten minste drie dia's.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 3) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Circle);
        $firstTransition->setAdvanceOnClick(true);
        $firstTransition->setAdvanceAfter(true);
        $firstTransition->setAdvanceAfterTime(3000);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Comb);
        $secondTransition->setAdvanceOnClick(true);
        $secondTransition->setAdvanceAfter(true);
        $secondTransition->setAdvanceAfterTime(5000);

        $thirdTransition = $presentation->getSlides()->get_Item(2)->getSlideShowTransition();
        $thirdTransition->setType(TransitionType::Zoom);
        $thirdTransition->setAdvanceOnClick(true);
        $thirdTransition->setAdvanceAfter(true);
        $thirdTransition->setAdvanceAfterTime(7000);

        $presentation->save("advanced-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least three slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Om te controleren of timer‑voortzetting is ingeschakeld, roep [getAdvanceAfter](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter) aan. Een opgeslagen vertraging alleen geeft niet aan dat de timer actief is.

Het volgende voorbeeld opent het hierboven opgeslagen bestand, meldt elke ingeschakelde timer en schakelt automatische voortzetting uit voor dia's met een vertraging groter dan twee seconden. Het schakelt muisklikken in voor die dia's en slaat de bijgewerkte instellingen op.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("advanced-transitions.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();

        if (java_values($transition->getAdvanceAfter())) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": advance after " . java_values($transition->getAdvanceAfterTime()) . " ms." . PHP_EOL;

            if (java_values($transition->getAdvanceAfterTime()) > 2000) {
                $transition->setAdvanceAfter(false);
                $transition->setAdvanceOnClick(true);
            }
        }
    }

    $presentation->save("adjusted-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Timing van overgang nauwkeurig regelen**

Gebruik [setDuration](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/#setDuration) om de exacte lengte van een overgangseffect in milliseconden op te geven. De [getSlideShowTransition](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseslide/#getSlideShowTransition)-methode van de dia maakt deze instellingen beschikbaar via [SlideShowTransition](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/):

| Methode | Doel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/#setDuration) | Stelt de duur van het overgangseffect zelf in, in milliseconden. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Stelt de vertraging in vóór de dia automatisch wordt voortgezet, in milliseconden. Geef `true` door aan [setAdvanceAfter](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) om deze timer te activeren. |
| [setSpeed](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/#setSpeed) | Selecteert een vooraf gedefinieerde snelheidscategorie uit [TransitionSpeed](https://reference.aspose.com/slides/nl/php-java/aspose.slides/transitionspeed/): Slow, Medium of Fast. Deze wordt gebruikt wanneer geen exacte duur is opgegeven. |

[setDuration] regelt alleen het overgangseffect; het bepaalt niet hoe lang de dia zichtbaar blijft. Configureer de automatische voortzettingsvertraging apart. Wanneer er geen expliciete duur is ingesteld, bepaalt Aspose.Slides de duur van het effect op basis van het overgangstype en de [getSpeed](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/#getSpeed)-waarde.

### **Zelfde duur toepassen op elke dia**

Voor een consistent tempo, pas hetzelfde effect en dezelfde exacte duur toe op elke dia. Dit voorbeeld laadt `input.pptx`, selecteert Fade uit [TransitionType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/transitiontype/), en geeft elke overgang een duur van 750 milliseconden. Het schakelt apart automatische voortzetting in na 5.000 milliseconden en schakelt voortzetting via muisklik uit, waarna het resultaat wordt opgeslagen als PPTX.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $transition->setType(TransitionType::Fade);
        $transition->setDuration(750);

        // Configureer automatische voortzetting onafhankelijk van de effectduur.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Verschillende duur instellen per individuele dia**

Verschillende dia's kunnen verschillende effectduren gebruiken. Gebruik bijvoorbeeld een korte overgang voor een titel‑dial en een langere overgang voor een sectie‑introductie. Dit voorbeeld stelt 500 milliseconden in voor de eerste dia en 1.200 milliseconden voor de tweede. Gebruik een `input.pptx`‑bestand met ten minste twee dia's.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Fade);
        $firstTransition->setDuration(500);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Push);
        $secondTransition->setDuration(1200);

        $presentation->save("individual-transition-durations.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Overgangen coördineren met geanimeerde output**

Bij het voorbereiden van een [animated GIF](/slides/nl/php-java/convert-powerpoint-to-animated-gif/), [HTML5‑presentatie](/slides/nl/php-java/export-to-html5/) of [video](/slides/nl/php-java/convert-powerpoint-to-video/), stel exacte overgangsduren in vóór het exporteren om het beoogde tempo te evenaren. Gebruik bijvoorbeeld een fade van 600 milliseconden tussen scènes en pas de voortzettingsvertraging van elke dia afzonderlijk aan om tijd te bieden voor de bijbehorende vertelling of inhoud.

Voor GIF en video, stem de uitvoer‑frame‑rate af op de effectduur: 600 milliseconden komt overeen met 18 frames bij 30 frames per seconde. In HTML5 schakel geanimeerde overgangen in de exportinstellingen in. Controleer welke effecten en timing‑opties het gekozen exportformaat ondersteunt en bekijk een voorbeeld om de synchronisatie te bevestigen.

### **Bestaande overgangsduur uitlezen**

Roep [getDuration](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/#getDuration) aan vóór het wijzigen van de overgang om te bepalen of er een expliciete waarde is opgeslagen. Een waarde van `-1` betekent dat er geen expliciete duur is ingesteld; een niet‑negatieve waarde geeft de opgeslagen duur in milliseconden weer. De niet‑ingestelde waarde is niet de berekende afspeelduur: Aspose.Slides gebruikt het overgangstype en de [getSpeed](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/#getSpeed)-waarde om die duur te bepalen. Het instellen van een overgangstype kan een duur initialiseren, dus inspecteer eerst de oorspronkelijke instellingen.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $duration = java_values($transition->getDuration());

        if ($duration >= 0) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": stored transition duration is " . $duration . " ms." . PHP_EOL;
        } else {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": no explicit duration; timing depends on transition type " . java_values($transition->getType()) . " and speed " . java_values($transition->getSpeed()) . "." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Morph‑overgang**

De Morph‑overgang animeert veranderingen tussen objecten op opeenvolgende dia's. Om een eenvoudige Morph‑effect te creëren, kloont u een dia, verplaatst of schaalt u een object op de kloon, en past u de Morph‑overgang toe op de tweede dia. Hierdoor kunnen de betreffende objecten geanimeerd worden tussen hun oorspronkelijke en gewijzigde toestand.

Het onderstaande voorbeeld maakt een dia met een tekst‑rechthoek, kloont de dia en verandert de positie en grootte van de rechthoek op de kloon. Vervolgens selecteert het Morph uit de enumeratie [TransitionType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/transitiontype/) voor de tweede dia. Open het opgeslagen bestand in een presentatieweergave die Morph ondersteunt om het effect tijdens een diavoorstelling te zien.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $rectangle = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $rectangle->getTextFrame()->setText("Morph transition");

    $secondSlide = $presentation->getSlides()->addClone($firstSlide);
    $movedRectangle = $secondSlide->getShapes()->get_Item(0);
    $movedRectangle->setX(java_values($movedRectangle->getX()) + 100);
    $movedRectangle->setY(java_values($movedRectangle->getY()) + 50);
    $movedRectangle->setWidth(java_values($movedRectangle->getWidth()) - 200);
    $movedRectangle->setHeight(java_values($movedRectangle->getHeight()) - 10);

    $secondSlide->getSlideShowTransition()->setType(TransitionType::Morph);

    $presentation->save("morph-transition.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Morph‑overgangstypen**

De enumeratie [TransitionMorphType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/transitionmorphtype/) bepaalt hoe Morph inhoud koppelt en animeert:

- [ByObject](https://reference.aspose.com/slides/nl/php-java/aspose.slides/transitionmorphtype/#ByObject) behandelt elke vorm als één geheel.
- [ByWord](https://reference.aspose.com/slides/nl/php-java/aspose.slides/transitionmorphtype/#ByWord) animeert tekst door waar mogelijk woorden te koppelen.
- [ByChar](https://reference.aspose.com/slides/nl/php-java/aspose.slides/transitionmorphtype/#ByChar) animeert tekst door waar mogelijk tekens te koppelen.

Gebruik [setType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/#setType) om Morph te selecteren vóór het benaderen van [getValue](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/#getValue). De verkregen waarde levert vervolgens een [MorphTransition](https://reference.aspose.com/slides/nl/php-java/aspose.slides/morphtransition/)‑object op, waarvan de [setMorphType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/morphtransition/#setMorphType) de koppelingsmodus selecteert.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionMorphType;
use aspose\slides\TransitionType;

$presentation = new Presentation("morph-transition.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $transition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $transition->setType(TransitionType::Morph);
        $morphTransition = $transition->getValue();

        if (!java_is_null($morphTransition)) {
            $morphTransition->setMorphType(TransitionMorphType::ByWord);
            $presentation->save("morph-by-word.pptx", SaveFormat::Pptx);
        } else {
            echo "Morph transition options are unavailable." . PHP_EOL;
        }
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Overgangseffecten instellen**

Sommige overgangen bieden extra opties, zoals richting of of het effect start vanaf een zwart scherm. De beschikbare opties hangen af van de overgang die met [setType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/#setType) is geselecteerd. Stel eerst het type in en gebruik vervolgens het juiste overgangsobject via [getValue](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/#getValue).

Het onderstaande voorbeeld past een Cut‑overgang toe op de eerste dia van `input.pptx`. Het roept [setFromBlack](https://reference.aspose.com/slides/nl/php-java/aspose.slides/optionalblacktransition/#setFromBlack) aan via [OptionalBlackTransition](https://reference.aspose.com/slides/nl/php-java/aspose.slides/optionalblacktransition/) zodat de overgang start vanaf een zwart scherm.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    $transition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
    $transition->setType(TransitionType::Cut);
    $cutTransition = $transition->getValue();

    if (!java_is_null($cutTransition)) {
        $cutTransition->setFromBlack(true);
        $presentation->save("cut-from-black.pptx", SaveFormat::Pptx);
    } else {
        echo "Cut transition options are unavailable." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Kan ik de afspeelsnelheid van een dia‑overgang regelen?**

Ja. Geef de voorkeur aan [setDuration](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/#setDuration) wanneer u een exacte duur van het effect in milliseconden nodig hebt. Gebruik [setSpeed](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/#setSpeed) wanneer een vooraf gedefinieerde [TransitionSpeed](https://reference.aspose.com/slides/nl/php-java/aspose.slides/transitionspeed/)‑categorie — Slow, Medium of Fast — voldoende is en er geen expliciete duur is ingesteld. Deze instellingen regelen het overgangseffect onafhankelijk van de automatische voortzettingsvertraging.

**Kan ik audio aan een overgang koppelen en laten herhalen?**

Ja. Koppel ingebedde audio met [setSound](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/#setSound), geef StartSound uit de enumeratie [TransitionSoundMode](https://reference.aspose.com/slides/nl/php-java/aspose.slides/transitionsoundmode/) door aan [setSoundMode](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/#setSoundMode), en schakel [setSoundLoop](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/#setSoundLoop) in met `true`. De audio blijft zich herhalen tot het volgende geluids‑evenement in de diavoorstelling.

**Wat is de snelste manier om dezelfde overgang op elke dia toe te passen?**

Loop door de [getSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getSlides)-collectie van de presentatie en roep [setType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/#setType) aan met dezelfde waarde voor de overgang van elke dia. Stel eventuele timing‑ en effectopties in dezelfde lus in om het gedrag consistent te houden over alle dia's.

**Hoe kan ik controleren welke overgang momenteel op een dia is ingesteld?**

Roep [getType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/#getType) aan op het resultaat van [getSlideShowTransition](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseslide/#getSlideShowTransition) van de dia. Het retourneert een waarde uit de enumeratie [TransitionType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/transitiontype/); None betekent dat er geen overgangseffect is toegepast.