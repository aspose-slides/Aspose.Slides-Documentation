---
title: Hantera bildövergångar i presentationer med PHP
linktitle: Bildövergång
type: docs
weight: 80
url: /sv/php-java/slide-transition/
keywords:
- bildövergång
- lägga till bildövergång
- tillämpa bildövergång
- avancerad bildövergång
- Morph‑övergång
- övergångstyp
- övergångseffekt
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Applicera bildövergångar, konfigurera automatisk bildavancering och anpassa Morph och andra övergångseffekter med Aspose.Slides för PHP via Java."
---
## **Översikt**

Bildövergångar styr hur bilder visas under ett bildspel. Med Aspose.Slides för PHP via Java kan du välja en övergångseffekt för varje bild, konfigurera avancerning med musklick eller timer och justera alternativ som är specifika för en effekt. Denna artikel använder PHP‑exempel för att tillämpa övergångar, ange exakta övergångstider, hantera bildtidsinställningar och skapa en Morph‑övergång mellan två bilder. Exemplen visar också hur man sparar inställningarna till en PPTX‑fil.

## **Lägg till bildövergång**

För att tillämpa en övergång, läs in en presentation med [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)‑klassen och nå bildens övergångsinställningar via [getSlideShowTransition](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseslide/#getSlideShowTransition). Använd [setType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/#setType) med ett värde från uppräkningen [TransitionType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/transitiontype/), spara sedan presentationen.

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

## **Lägg till avancerad bildövergång**

Du kan konfigurera hur länge en bild förblir på skärmen och om ett musklick avancerar bildspelet. Följande metoder styr detta beteende:

- [setAdvanceOnClick](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) tillåter tittaren att avancera genom att klicka med musen.  
- [setAdvanceAfter](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) möjliggör automatisk avancerning.  
- [setAdvanceAfterTime](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) anger fördröjningen innan automatisk avancerning, i millisekunder.

Aktivera både klick‑ och timer‑avancering så att tittaren kan gå vidare med ett klick eller vänta på timern. För att använda endast timern, skicka `false` till [setAdvanceOnClick](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Fördröjningen styr när bildspelet avancerar; den sätter inte varaktigheten för den visuella övergångseffekten.

Detta exempel tilldelar olika effekter till de tre första bilderna och aktiverar automatisk avancering efter 3, 5 respektive 7 sekunder. Mus‑klick kan också avancera dessa bilder. Använd en `input.pptx`‑fil med minst tre bilder.

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

För att kontrollera om timer‑avancering är aktiverad, anropa [getAdvanceAfter](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Ett lagrat fördröjningsvärde betyder inte att timern är aktiv.

Nästa exempel öppnar filen som sparades ovan, rapporterar varje aktiverad timer och inaktiverar automatisk avancerning för bilder med en fördröjning längre än två sekunder. Det aktiverar mus‑klick för dessa bilder och sparar de uppdaterade inställningarna.

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

Använd [setDuration](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/#setDuration) för att ange exakt längd på en övergångseffekt i millisekunder. Bildens [getSlideShowTransition](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseslide/#getSlideShowTransition)‑metod exponerar dessa inställningar via [SlideShowTransition](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/):

| Metod | Syfte |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/#setDuration) | Anger varaktigheten för själva övergångseffekten, i millisekunder. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Anger fördröjningen innan bilden avancerar automatiskt, i millisekunder. Skicka `true` till [setAdvanceAfter](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) för att aktivera timern. |
| [setSpeed](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/#setSpeed) | Väljer en fördefinierad hastighetskategori från [TransitionSpeed](https://reference.aspose.com/slides/sv/php-java/aspose.slides/transitionspeed/): Slow, Medium eller Fast. Den används när ingen exakt varaktighet anges. |

[setDuration](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/#setDuration) styr endast övergångseffekten; den bestämmer inte hur länge bilden är synlig. Konfigurera timer‑fördröjningen separat. När ingen explicit varaktighet anges, bestämmer Aspose.Slides effektens varaktighet utifrån övergångstypen och värdet på [getSpeed](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/#getSpeed).

### **Använd samma varaktighet för alla bilder**

För jämn takt, tillämpa samma effekt och exakt varaktighet på varje bild. Detta exempel laddar `input.pptx`, väljer Fade från [TransitionType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/transitiontype/) och ger varje övergång en varaktighet på 750 ms. Det aktiverar dessutom automatisk avancerning efter 5 000 ms och inaktiverar avancerning med mus‑klick, och sparar resultatet som PPTX.

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

        // Konfigurera automatisk avancering oberoende av effektens varaktighet.
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

Olika bilder kan ha olika effektvaraktigheter. Till exempel kan en titelbild ha en kort övergång medan en sektionintro har en längre. Detta exempel sätter 500 ms för den första bilden och 1 200 ms för den andra. Använd en `input.pptx`‑fil med minst två bilder.

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

### **Koordinera övergångar med animerad output**

När du förbereder en [animated GIF](/slides/sv/php-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/sv/php-java/export-to-html5/) eller ett [video](/slides/sv/php-java/convert-powerpoint-to-video/), ange exakta övergångstider innan export för att matcha den avsedda takten. Till exempel, använd en 600 ms fade mellan scener och justera varje bilds avanceringsfördröjning separat för att ge tid åt dess berättelse eller innehåll.

För GIF och video, samordna output‑frame‑rate med effektens varaktighet: 600 ms motsvarar 18 rutor vid 30 fps. I HTML5, aktivera animerade övergångar i exportinställningarna. Kontrollera vilka effekter och tidsalternativ som stöds av det valda exportformatet och förhandsgranska output för att bekräfta synkronisering.

### **Läs en befintlig övergångsvaraktighet**

Anropa [getDuration](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/#getDuration) innan du ändrar övergången för att avgöra om ett explicit värde är lagrat. Ett värde på `-1` betyder att ingen explicit varaktighet är satt; ett icke‑negativt värde specificerar den lagrade varaktigheten i millisekunder. Det osatta värdet är inte den beräknade uppspelningsvaraktigheten: Aspose.Slides använder övergångstypen och värdet på [getSpeed](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/#getSpeed) för att bestämma den varaktigheten. Att sätta en övergångstyp kan initiera en varaktighet, så inspektera först de ursprungliga inställningarna.

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

Morph‑övergången animerar förändringar mellan objekt på på varandra följande bilder. För att skapa en enkel Morph‑effekt, klona en bild, flytta eller ändra storlek på ett objekt i klonen och tillämpa Morph‑övergången på den andra bilden. Detta ger motsvarande objekt att animera mellan sina ursprungliga och modifierade tillstånd.

Följande exempel skapar en bild med en textrektangel, klonar bilden och ändrar rektangelns position och storlek i klonen. Därefter väljer det Morph från uppräkningen [TransitionType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/transitiontype/) för den andra bilden. Öppna den sparade filen i en presentationsvisare som stöder Morph för att se effekten under ett bildspel.

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

Uppräkningen [TransitionMorphType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/transitionmorphtype/) bestämmer hur Morph matchar och animerar innehåll:

- [ByObject](https://reference.aspose.com/slides/sv/php-java/aspose.slides/transitionmorphtype/#ByObject) behandlar varje form som ett helt objekt.  
- [ByWord](https://reference.aspose.com/slides/sv/php-java/aspose.slides/transitionmorphtype/#ByWord) animerar text genom att matcha ord där det är möjligt.  
- [ByChar](https://reference.aspose.com/slides/sv/php-java/aspose.slides/transitionmorphtype/#ByChar) animerar text genom att matcha tecken där det är möjligt.

Använd [setType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/#setType) för att välja Morph innan du anropar [getValue](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/#getValue). Värdet ger sedan ett [MorphTransition](https://reference.aspose.com/slides/sv/php-java/aspose.slides/morphtransition/)-objekt, vars [setMorphType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/morphtransition/#setMorphType)-metod väljer matchningsläget.

Detta exempel öppnar presentationen som skapades i föregående avsnitt och konfigurerar den andra bilden att använda ord‑baserad Morph‑animation.

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

Vissa övergångar exponerar ytterligare alternativ, såsom riktning eller om effekten startar från en svart skärm. De tillgängliga alternativen beror på övergången som valts med [setType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/#setType). Sätt typen först, använd sedan det lämpliga övergångsobjektet från [getValue](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/#getValue).

Följande exempel använder en Cut‑övergång på den första bilden i `input.pptx`. Det anropar [setFromBlack](https://reference.aspose.com/slides/sv/php-java/aspose.slides/optionalblacktransition/#setFromBlack) via [OptionalBlackTransition](https://reference.aspose.com/slides/sv/php-java/aspose.slides/optionalblacktransition/) så att övergången startar från en svart skärm.

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

**Kan jag styra uppspelningshastigheten för en bildövergång?**

Ja. Föredra [setDuration](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/#setDuration) när du behöver en exakt effektvaraktighet i millisekunder. Använd [setSpeed](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/#setSpeed) när en fördefinierad [TransitionSpeed](https://reference.aspose.com/slides/sv/php-java/aspose.slides/transitionspeed/)-kategori — Slow, Medium eller Fast — räcker och ingen explicit varaktighet är angiven. Dessa inställningar styr övergångseffekten oberoende av timer‑fördröjningen för automatisk avancerning.

**Kan jag bifoga ljud till en övergång och låta det loopa?**

Ja. Tilldela inbäddat ljud med [setSound](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/#setSound), skicka `StartSound` från uppräkningen [TransitionSoundMode](https://reference.aspose.com/slides/sv/php-java/aspose.slides/transitionsoundmode/) till [setSoundMode](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/#setSoundMode), och aktivera [setSoundLoop](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/#setSoundLoop) med `true`. Ljudet loopar tills nästa ljudevent i bildspelet.

**Vad är det snabbaste sättet att tillämpa samma övergång på alla bilder?**

Loopa genom presentationens [getSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getSlides)-samling och anropa [setType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/#setType) med samma värde för varje bilds övergång. Ställ in eventuella tids‑ och effektalternativ i samma loop för att hålla beteendet konsekvent över alla bilder.

**Hur kan jag kontrollera vilken övergång som för närvarande är inställd på en bild?**

Anropa [getType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/#getType) på bildens [getSlideShowTransition](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseslide/#getSlideShowTransition)-resultat. Det returnerar ett värde från uppräkningen [TransitionType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/transitiontype/); None betyder att ingen övergångseffekt är applicerad.