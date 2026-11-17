---
title: Hantera bildövergångar i presentationer med PHP
linktitle: Bildövergång
type: docs
weight: 80
url: /sv/php-java/slide-transition/
keywords:
- bildövergång
- lägg till bildövergång
- använd bildövergång
- avancerad bildövergång
- Morph-övergång
- övergångstyp
- övergångseffekt
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Applicera bildövergångar, konfigurera automatisk bildförflyttning och anpassa Morph och andra övergångseffekter med Aspose.Slides för PHP via Java."
---
## **Översikt**

Bildövergångar styr hur bilder visas under ett bildspel. Med Aspose.Slides för PHP via Java kan du välja en övergångseffekt för varje bild, konfigurera förflyttning med musklick eller timer och justera alternativ som är specifika för en effekt. Denna artikel använder PHP‑exempel för att tillämpa övergångar, ange exakt övergångstid, hantera bildtidsinställningar och skapa en Morph‑övergång mellan två bilder. Exemplen visar också hur du sparar inställningarna till en PPTX‑fil.

## **Lägg till bildövergång**

För att tillämpa en övergång, läs in en presentation med klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) och nå bildens övergångsinställningar via [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition). Använd [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) med ett värde från uppräkningen [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), spara sedan presentationen.

Följande exempel tillämpar en Circle‑övergång på den första bilden och en Comb‑övergång på den andra. Använd en `input.pptx`‑fil med minst två bilder.

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

## **Hjulförflyttning**

Metoden [setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) styr hur många radiella sektorer som avslöjar målbilden. Använd [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) för att välja Wheel från [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), anropa sedan [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) för att nå inställningarna för [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/).

Exemplet skapar två identiska bildpar. Varje par börjar med en svart bild och slutar med en bild täckt av en gul rektangel. Bild 2 använder en spak och bild 4 använder åtta. Båda övergångarna använder samma långsamma hastighet, satt med [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed), och en explicit varaktighet på 8 000 ms, satt med [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration).

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slides = $presentation->getSlides();
    $width = java_values($presentation->getSlideSize()->getSize()->getWidth());
    $height = java_values($presentation->getSlideSize()->getSize()->getHeight());

    $blackSlide = $slides->get_Item(0);
    $blackSlide->getShapes()->clear();
    $background = $blackSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Solid);
    $black = new Color(0, 0, 0);
    $background->getFillFormat()->getSolidFillColor()->setColor($black);

    $destinationSlide = $slides->addClone($blackSlide);
    $rectangle = $destinationSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, $width, $height);
    $rectangle->getFillFormat()->setFillType(FillType::Solid);
    $gold = new Color(255, 215, 0);
    $rectangle->getFillFormat()->getSolidFillColor()->setColor($gold);
    $rectangle->getTextFrame()->setText("Wheel transition");

    $slides->addClone($blackSlide);
    $slides->addClone($destinationSlide);

    foreach ([1 => 1, 3 => 8] as $slideIndex => $spokes) {
        $transition = $slides->get_Item($slideIndex)->getSlideShowTransition();
        $transition->setType(TransitionType::Wheel);
        $transition->getValue()->setSpokes($spokes);
        $transition->setSpeed(TransitionSpeed::Slow);
        $transition->setDuration(8000);
    }

    $presentation->save("wheel-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Öppna den sparade presentationen i PowerPoint och starta bildspelet. Gå från bild 1 till bild 2 för att se en enda medurs svepning. Gå sedan från bild 3 till bild 4 för att se åtta radiella sektorer som avslöjar rektangeln samtidigt.

## **Lägg till avancerad bildövergång**

Du kan konfigurera hur länge en bild förblir på skärmen och om ett musklick förflyttar bildspelet. Följande metoder styr detta beteende:

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) låter betraktaren gå framåt genom att klicka med musen.
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) aktiverar automatisk förflyttning.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) anger fördröjningen innan automatisk förflyttning, i millisekunder.

Aktivera både klick‑ och tidsbaserad förflyttning så att betraktaren kan gå vidare med ett klick eller vänta på timern. För att endast använda timern, skicka `false` till [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Fördröjningen styr när bildspelet förflyttar sig; den anger inte varaktigheten för den visuella övergångseffekten.

Detta exempel tilldelar olika effekter till de tre första bilderna och möjliggör automatisk förflyttning efter 3, 5 respektive 7 sekunder. Musklick kan också förflytta dessa bilder. Använd en `input.pptx`‑fil med minst tre bilder.

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

För att kontrollera om tidsbaserad förflyttning är aktiverad, anropa [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Ett lagrat fördröjningsvärde betyder inte att timern är aktiv.

Nästa exempel öppnar filen som sparades ovan, rapporterar varje aktiverad timer och inaktiverar automatisk förflyttning för bilder med en fördröjning större än två sekunder. Det aktiverar musklick för dessa bilder och sparar de uppdaterade inställningarna.

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

## **Styr övergångstiden exakt**

Använd [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) för att ange exakt längd på en övergångseffekt i millisekunder. Bildens [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition)‑metod exponerar dessa inställningar via [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/):

| Metod | Syfte |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | Anger varaktigheten för själva övergångseffekten, i millisekunder. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Anger fördröjningen innan bilden förflyttas automatiskt, i millisekunder. Skicka `true` till [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) för att aktivera timern. |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | Väljer en fördefinierad hastighetskategori från [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/): Slow, Medium eller Fast. Används när ingen exakt varaktighet är angiven. |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) styr endast övergångseffekten; den bestämmer inte hur länge bilden förblir synlig. Konfigurera den automatiska förflyttningsfördröjningen separat. När ingen explicit varaktighet anges, bestämmer Aspose.Slides effektens varaktighet utifrån övergångstypen och värdet i [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Separata staplar identifierar 750‑ms övergångstid och 5 000‑ms automatisk fördröjningsinställning.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Det gemensamma exemplet ger varje bild en 750‑ms Fade‑övergång och aktiverar separat automatisk förflyttning vid 5 000 ms. Övergångstiden styr effekten; förflyttningen styr när bilden lämnas. Dessa staplar är schematiska inställningar, inte en uppmätt kombinerad tidslinje.*
<!-- visual-explanation:slide-transition:end -->

### **Använd samma varaktighet för varje bild**

För enhetligt tempo, använd samma effekt och exakt varaktighet för varje bild. Detta exempel läser in `input.pptx`, väljer Fade från [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), och ger varje övergång en varaktighet på 750 ms. Det aktiverar även automatiskt förflyttning efter 5 000 ms och inaktiverar förflyttning med musklick, och sparar sedan resultatet som PPTX.

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

        // Konfigurera automatisk förflyttning oberoende av effektens varaktighet.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Ange olika varaktigheter för enskilda bilder**

Olika bilder kan ha olika effektvaraktigheter. Till exempel, använd en kort övergång för en titelsida och en längre övergång för en sektionsintroduktion. Detta exempel sätter 500 ms för den första bilden och 1 200 ms för den andra. Använd en `input.pptx`‑fil med minst två bilder.

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

### **Koordinera övergångar med animerad export**

När du förbereder en [animera GIF](/slides/sv/php-java/convert-powerpoint-to-animated-gif/), en [HTML5‑presentation](/slides/sv/php-java/export-to-html5/), eller en [video](/slides/sv/php-java/convert-powerpoint-to-video/), ange exakta övergångstider innan export för att matcha det avsedda tempot. Till exempel, använd en 600‑ms fade‑övergång mellan scener och justera varje bilds förflyttningsfördröjning separat för att ge tid åt berättarrösten eller innehållet.

För GIF och video, anpassa bildhastigheten med effektens varaktighet: 600 ms motsvarar 18 bildrutor vid 30 fps. I HTML5, aktivera animerade övergångar i exportinställningarna. Kontrollera vilka effekter och tidsalternativ som stöds av det valda exportformatet och förhandsgranska resultatet för att bekräfta synkronisering.

### **Läs befintlig övergångstid**

Anropa [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) innan du ändrar övergången för att avgöra om ett explicit värde är lagrat. Värdet `-1` betyder att ingen explicit varaktighet är satt; ett icke‑negativt värde specificerar den lagrade varaktigheten i millisekunder. Det osatta värdet är inte den beräknade uppspelningsvaraktigheten: Aspose.Slides använder övergångstypen och värdet i [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) för att bestämma den varaktigheten. Att ange en övergångstyp kan initiera en varaktighet, så inspektera de ursprungliga inställningarna först.

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

## **Morph‑övergång**

Morph‑övergången animerar förändringar mellan objekt på på varandra följande bilder. För att skapa en enkel Morph‑effekt, klona en bild, flytta eller ändra storlek på ett objekt i klonen och applicera Morph‑övergången på den andra bilden. Detta ger övergången motsvarande objekt att animera mellan deras ursprungliga och modifierade tillstånd.

Följande exempel skapar en bild med en textruta, klonar bilden och ändrar rektangelns position och storlek i klonen. Den väljer sedan Morph från uppräkningen [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) för den andra bilden. Öppna den sparade filen i en presentationsvisare som stödjer Morph för att se effekten under ett bildspel.

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

## **Morph‑övergångstyper**

Uppräkningen [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) styr hur Morph matchar och animerar innehåll:

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) behandlar varje form som ett helt objekt.
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) animerar text genom att matcha ord där det är möjligt.
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) animerar text genom att matcha tecken där det är möjligt.

Använd [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) för att välja Morph innan du hämtar [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue). Värdet ger sedan ett [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/)-objekt, vars metod [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) väljer matchningsläge.

Detta exempel öppnar presentationen som skapades i föregående avsnitt och konfigurerar den andra bilden för att använda ord‑baserad Morph‑animation.

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

## **Ange övergångseffekter**

Vissa övergångar exponerar ytterligare alternativ, som riktning eller om effekten ska börja från en svart skärm. Tillgängliga alternativ beror på vilken övergång som valts med [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType). Ställ först in typen, och använd sedan det lämpliga övergångsobjektet från [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue).

Följande exempel applicerar en Cut‑övergång på den första bilden i `input.pptx`. Det anropar [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack) via [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/) så att övergången startar från en svart skärm.

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

**Kan jag kontrollera uppspelningshastigheten för en bildövergång?**

Ja. Företräda [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) när du behöver en exakt effektvaraktighet i millisekunder. Använd [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) när en fördefinierad [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/)-kategori – Slow, Medium eller Fast – räcker och ingen explicit varaktighet är angiven. Dessa inställningar styr övergångseffekten oberoende av den automatiska förflyttningsfördröjningen.

**Kan jag bifoga ljud till en övergång och låta det loopa?**

Ja. Tilldela inbäddat ljud med [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound), skicka `StartSound` från uppräkningen [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) till [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode), och aktivera [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) med `true`. Ljudet loopar tills nästa ljudhändelse i bildspelet.

**Vad är det snabbaste sättet att applicera samma övergång på varje bild?**

Loopa igenom presentationens [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides)-samling och anropa [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) med samma värde för varje bilds övergång. Ställ in eventuella tids‑ och effektalternativ i samma loop för att hålla beteendet konsekvent över alla bilder.

**Hur kan jag kontrollera vilken övergång som för närvarande är inställd på en bild?**

Anropa [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) på resultatet av bildens [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition). Den returnerar ett värde från uppräkningen [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/); None betyder att ingen övergångseffekt är applicerad.