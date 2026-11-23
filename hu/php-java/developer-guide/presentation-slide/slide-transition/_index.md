---
title: Diaátmenetek kezelése prezentációkban PHP használatával
linktitle: Diaátmenet
type: docs
weight: 80
url: /hu/php-java/slide-transition/
keywords:
- diaátmenet
- diaátmenet hozzáadása
- diaátmenet alkalmazása
- haladó diaátmenet
- morph átmenet
- átmenet típusa
- átmenet effektus
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Alkalmazzon diaátmeneteket, konfigurálja az automatikus dia előrehaladást, és testreszabja a Morph és egyéb átmeneti effektusokat az Aspose.Slides for PHP via Java segítségével."
---
## **Áttekintés**

A diavetítési átmenetek szabályozzák, hogyan jelennek meg a diák a diavetítés során. Az Aspose.Slides for PHP via Java segítségével minden diához kiválaszthat egy átmenet‑effektust, konfigurálhatja a csúszka előrehaladását egérkattintással vagy időzítővel, valamint beállíthatja az effektusra jellemző opciókat. Ez a cikk PHP példákat mutat be az átmenetek alkalmazására, a pontos átmeneti időtartamok beállítására, a diaidőzítés kezelésére, valamint egy Morph átmenet létrehozására két dia között. A példák azt is bemutatják, hogyan menthetőek a beállítások PPTX fájlba.

## **Diaátmenet hozzáadása**

Az átmenet alkalmazásához töltsön be egy prezentációt a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztállyal, és érje el a dia átmenet beállításait a [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) metódussal. Használja a [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) metódust a [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) felsorolás egy értékével, majd mentse a prezentációt.

A következő példa egy Circle átmenetet alkalmaz az első diára, és egy Comb átmenetet a másodikra. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

## **Kerék átmenet**

A [setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) metódus szabályozza, hány sugárirányú szektor fedje fel a céldiát. A [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) segítségével válassza ki a Wheel értéket a [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) felsorolásból, majd hívja meg a [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) metódust a [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/) beállításainak eléréséhez.

A példa két azonos pár diát hoz létre. Minden pár egy fekete diával kezdődik, és egy arany téglalappal fedett diával végződik. A 2. dia egyetlen szektort használ, a 4. dia nyolcat. Mindkét átmenet ugyanazzal a lassú sebességgel működik, amit a [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) állít be, és explicit 8 000 ms időtartammal, amit a [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) ad meg.

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

Nyissa meg a mentett prezentációt a PowerPointban, és indítsa el a diavetítést. Lépjen a 1. diáról a 2. diára, hogy egyetlen óramutató‑irányú kört lásson. Ezután lépjen a 3. diáról a 4. diára, hogy nyolc sugárirányú szektor fedje fel egyszerre a téglalapot.

## **Fade Through Black a Reveal átmenettel**

Állítsa be a céldiára a Reveal átmenetet, majd hívja meg a [setThroughBlack](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/#setThroughBlack) metódust a [RevealTransition](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/) beállításain. A példa egy türkiz forrásdiát és egy korall céldiát hoz létre, majd mindkettőt klónozza. Minden pár ugyanazt a kétszeni átlépéses Reveal átmenetet használja. Csak a második pár halványul át feketén.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionLeftRightDirectionType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $source = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addClone($source);

    foreach ([
        [$source, new Color(0, 128, 128), "Source"],
        [$destination, new Color(255, 127, 80), "Destination"],
    ] as [$slide, $color, $label]) {
        $slide->getBackground()->setType(BackgroundType::OwnBackground);
        $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
        $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 160, 180, 400, 130);
        $shape->getTextFrame()->setText($label);
        $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(44);
    }

    $presentation->getSlides()->addClone($source);
    $clonedDestination = $presentation->getSlides()->addClone($destination);
    foreach ([[$destination, false], [$clonedDestination, true]] as [$slide, $throughBlack]) {
        $slide->getSlideShowTransition()->setType(TransitionType::Reveal);
        $slide->getSlideShowTransition()->setSpeed(TransitionSpeed::Slow);
        $slide->getSlideShowTransition()->setDuration(2000);
        $slide->getSlideShowTransition()->getValue()->setDirection(TransitionLeftRightDirectionType::Left);
        $slide->getSlideShowTransition()->getValue()->setThroughBlack($throughBlack);
    }

    $presentation->save("reveal-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Nyissa meg a mentett prezentációt a PowerPointban, és indítsa el a diavetítést. Lépjen a 1. diáról a 2. diára, hogy a türkiz közvetlenül a korallra halványuljon. Ezután lépjen a 3. diáról a 4. diára. A képernyő röviden majdnem feketévé válik, mielőtt a korall dia megjelenik. Mindkét dia megtartja az eredeti háttérszínét.

Az alábbi sorok a PowerPoint képkockáit mutatják félmásodperces intervallumban. Hasonlítsa össze a sor közepén lévő képkockát, hogy lássa a hatást.

![PowerPoint lejátszás a feketével átfedés tiltásával (felső) és engedélyezésével (alsó). Csak az alsó sor halad át a szinte fekete állapoton.](reveal-through-black.png)

## **Haladó diaátmenet hozzáadása**

Konfigurálhatja, mennyi ideig marad a dia a képernyőn, és hogy egérkattintás vagy időzítő állítsa-e előre a diavetítést. A következő metódusok vezérlik ezt a viselkedést:

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) lehetővé teszi a nézőnek a csúszka előrehaladását egérkattintással.
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) engedélyezi az automatikus előrehaladást.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) megadja a késleltetést automatikus előrehaladás előtt ezredmásodpercben.

Engedélyezze mind a kattintást, mind az időzített előrehaladást, hogy a néző kattintással léphessen tovább, vagy várjon a timerre. Ha csak a timert szeretné használni, adjon át `false` értéket a [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) metódusnak. A késleltetés szabályozza, mikor lép előre a diavetítés; nem a vizuális átmenet hatás időtartamát állítja be.

Ez a példa különböző effektusokat rendel az első három diához, és automatikus előrehaladást állít be 3, 5 és 7 másodperc után. Egérkattintással is előre lehet lépni ezeken a diákon. Használjon egy `input.pptx` fájlt, amely legalább három diát tartalmaz.

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

A timed előrehaladás engedélyezett‑állapotának ellenőrzéséhez hívja meg a [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter) metódust. Egy tárolt késleltetés önmagában nem jelzi, hogy a timer aktív.

A következő példa megnyitja a fent mentett fájlt, jelentést készít minden engedélyezett időzítőről, és letiltja az automatikus előrehaladást azoknál a diáknál, amelyek késleltetése meghaladja a két másodpercet. Ezeknél a diáknál engedélyezi a kattintást, majd elmenti a módosított beállításokat.

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

## **Átmeneti időzítés pontos szabályozása**

Használja a [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) metódust az átmeneti effektus pontos hosszának ezredmásodpercben történő megadásához. A dia [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) metódusa ezeken a beállításokon keresztül érhető el a [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/) objektumban:

| Metódus | Cél |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | Beállítja az átmeneti effektus időtartamát millimásodpercben. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Beállítja a késleltetést, mielőtt a dia automatikusan előrehalad, millimásodpercben. A [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) metódus `true` értékével aktiválja ezt a timert. |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | Kiválaszt egy előre definiált sebességkategóriát a [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) felsorolásból: Slow, Medium vagy Fast. Akkor használatos, ha pontos időtartam nincs megadva. |

A [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) csak az átmeneti effektust szabályozza; nem azt határozza meg, meddig marad a dia látható. Az automatikus előrehaladás késleltetését külön kell beállítani. Ha nincs explicit időtartam megadva, az Aspose.Slides a átmenet típusából és a [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) értékéből számítja ki a hatás hosszát.

<!-- visual-explanation:slide-transition:start -->
[![A különálló sávok a 750 ms átmeneti időtartamot és az 5 000 ms automatikus előrehaladási beállítást jelölik.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Az itt bemutatott példa minden diát 750 ms Fade átmenettel lát el, és külön engedélyezi az automatikus előrehaladást 5 000 ms után. Az átmeneti idő a hatást szabályozza; a előrehaladás határozza meg, mikor hagyjuk el a diát. Ezek a sávok csak szemléltető beállítások, nem egy mérhető kombinált idővonal.*
<!-- visual-explanation:slide-transition:end -->

### **Ugyanazt az időtartamot alkalmazni minden diára**

A következetes tempó érdekében alkalmazza ugyanazt az effektust és pontos időtartamot minden diára. Ez a példa betölti a `input.pptx` fájlt, a [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) felsorolásból a Fade‑et választja, és minden átmenetnek 750 ms időtartamot ad. Külön engedélyezi az automatikus előrehaladást 5 000 ms után, és letiltja a kattintásos előrehaladást, majd PPTX‑ként elmenti az eredményt.

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

        // Állítsa be az automatikus előrehaladást külön a hatás időtartamától.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Eltérő időtartamok beállítása az egyes diákra**

Az egyes diák különböző effektus‑időtartamokat használhatnak. Például egy rövid átmenetet állíthat be a címdiára, és hosszabbat egy szakasz bevezetőjére. Ez a példa 500 ms‑t állít be az első diára, és 1 200 ms‑t a másodikra. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

### **Átmenetek összehangolása animált kimenettel**

Amikor [animated GIF](/slides/hu/php-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/hu/php-java/export-to-html5/) vagy [video](/slides/hu/php-java/convert-powerpoint-to-video/) készül, állítsa be a pontos átmeneti időtartamokat exportálás előtt, hogy megfeleljenek a kívánt tempónak. Például egy 600 ms‑os elhalványulást használhat a jelenetek között, és minden dia előrehaladási késleltetését külön szabályozhatja, hogy legyen idő a narrációra vagy a tartalomra.

GIF‑nél és videónál a kimeneti képkockasebességet egyeztesse az effektus időtartamával: 600 ms 30 fps‑nél 18 képkockának felel meg. HTML5‑ben engedélyezze az animált átmeneteket az export beállításokban. Ellenőrizze a választott exportformátum támogatott effektusait és időzítési opcióit, és tekintse meg az előnézetet a szinkronizáció megerősítéséhez.

### **Meglévő átmeneti időtartam beolvasása**

A módosítás előtt hívja meg a [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) metódust, hogy megállapítsa, van‑e explicit érték tárolva. A `-1` érték azt jelzi, hogy nincs explicit időtartam beállítva; egy nem negatív érték a tárolt időtartamot jelenti ezredmásodpercben. A nem beállított érték nem a számított lejátszási idő: az Aspose.Slides a tranzíció típusából és a [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) értékéből határozza meg a tényleges időtartamot. Egy átmenet típusának beállítása inicializálhat egy időtartamot, ezért először ellenőrizze az eredeti beállításokat.

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

## **Morph átmenet**

A Morph átmenet animálja a változásokat az egymást követő diák objektumai között. Egy egyszerű Morph hatás létrehozásához klónozzon egy diát, módosítsa vagy átméretezze az objektumot a klónon, és alkalmazza a Morph átmenetet a második diára. Ez a megfelelő objektumok animálását biztosítja az eredeti és a módosított állapot között.

A következő példa egy szövegtéglalappal ellátott diát hoz létre, klónozza a diát, majd a klónon megváltoztatja a téglalap helyzetét és méretét. Ezután a [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) felsorolásból a Morph‑ot választja a második diára. Nyissa meg a mentett fájlt egy olyan prezentációs nézőben, amely támogatja a Morph‑ot, hogy lássa a hatást a diavetítés során.

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

## **Morph átmenet típusok**

A [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) felsorolás szabályozza, hogy a Morph hogyan párosítja és animálja a tartalmat:

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) minden alakzatot egész objektumként kezel.
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) a szavakat párosítja, ha lehetséges, és így animálja a szöveget.
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) a karaktereket párosítja, ha lehetséges, és így animálja a szöveget.

Használja a [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) metódust a Morph kiválasztásához, mielőtt elérné a [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) metódust. Az érték egy [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/) objektumot ad, amelynek a [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) metódusa választja ki a párosítási módot.

Ez a példa megnyitja az előző szekcióban létrehozott prezentációt, és a második diát szó‑alapú Morph animációra konfigurálja.

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

## **Átmeneti hatások beállítása**

Néhány átmenet további opciókat tesz elérhetővé, például irányt vagy azt, hogy a hatás fekete képernyőn indul‑e. Az elérhető opciók a [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) által kiválasztott átmenettől függnek. Először állítsa be a típust, majd a megfelelő átmenet objektumot használja a [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) metódusból.

A következő példa egy Cut átmenetet alkalmaz a `input.pptx` első diájára. A [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/) objektumon keresztül meghívja a [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack) metódust, hogy az átmenet fekete képernyőről induljon.

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

## **GYIK**

**Vezérelhetem a diaátmenet lejátszási sebességét?**

Igen. Előnyben részesítse a [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) használatát, ha pontos effektus‑időtartamot millimásodpercben kíván megadni. Használja a [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) metódust, ha egy előre definiált [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) kategória – Slow, Medium vagy Fast – elegendő, és nincs explicit időtartam megadva. Ezek a beállítások függetlenül szabályozzák az átmeneti hatást az automatikus előrehaladási késleltetéstől.

**Csatolhatok hangot egy átmenethez, és beállíthatom, hogy ismétlődjön?**

Igen. A beágyazott hangot a [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound) metódussal állíthatja be, a [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) felsorolásból a StartSound‑t adja át a [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode) metódusnak, és a [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) metódust `true`‑ra állítja. A hang addig ismétlődik, amíg a diavetítés következő hangeseménye be nem következik.

**Mi a leggyorsabb módja annak, hogy ugyanazt az átmenetet minden diára alkalmazzam?**

Iteráljon végig a prezentáció [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) gyűjteményén, és minden dia átmenetére hívja meg a [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) metódust ugyanazzal az értékkel. Az időzítési és effektus‑opciókat ugyanabban a ciklusban állítsa be, hogy a viselkedés minden diához konzisztens legyen.

**Hogyan ellenőrizhetem, hogy melyik átmenet van jelenleg beállítva egy dián?**

Hívja meg a [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) metódust a dia [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) eredményén. Ez egy értéket ad vissza a [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) felsorolásból; a None azt jelenti, hogy nincs átmenet‑effektus alkalmazva.