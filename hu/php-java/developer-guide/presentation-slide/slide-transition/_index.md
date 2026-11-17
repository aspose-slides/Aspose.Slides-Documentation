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
- speciális diaátmenet
- morph átmenet
- átmenettípus
- átmeneti effektus
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Alkalmazzon diaátmeneteket, állítsa be a diák automatikus előrehaladását, és testreszabja a Morph és egyéb átmeneti effektusokat az Aspose.Slides for PHP via Java segítségével."
---
## **Áttekintés**

A diaátmenetek szabályozzák, hogyan jelennek meg a diák a diavetítés során. Az Aspose.Slides for PHP via Java használatával kiválaszthat egy átmenet‑effektust minden diához, konfigurálhatja az előrehaladást egérkattintás vagy időzítő alapján, és beállíthatja az effektusra jellemző opciókat. Ez a cikk PHP példákkal mutatja be az átmenetek alkalmazását, az átmenet pontos időtartamának beállítását, a diaidőzítés kezelését, valamint egy Morph átmenet létrehozását két dia között. A példák azt is bemutatják, hogyan menthetők a beállítások PPTX fájlba.

## **Diaátmenet hozzáadása**

Átmenet alkalmazásához töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztállyal, és a dia átmenet‑beállításait érje el a [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) segítségével. Használja a [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) metódust a [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) felsorolásból származó értékkel, majd mentse a prezentációt.

Az alábbi példa Circle átmenetet alkalmaz az első diára, és Comb átmenetet a másodikra. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

A [setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) metódus szabályozza, hány sugárirányú szektor fedje fel a céldiat. A [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) segítségével válassza ki a Wheel opciót a [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) felsorolásból, majd hívja a [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) metódust a [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/) beállításainak eléréséhez.

A példa két azonos diapárt hoz létre. Minden pár egy fekete diával kezdődik, és egy arany téglalappal zárul. A 2. dia egy szektorral, a 4. dia nyolccal fed le. Mindkét átmenet lassú sebességet használ, amelyet a [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) metódussal állítanak be, és explicit 8 000 ms időtartamot a [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) metódussal.

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

Nyissa meg a mentett prezentációt PowerPointban, és indítsa el a diavetítést. Lépjen a 1. diáról a 2. diára, hogy egy óramutató járásával megegyező szekciót lásson. Ezután lépjen a 3. diáról a 4. diára, hogy nyolc sugárirányú szektor fedje le egyszerre a téglalapot.

## **Speciális diaátmenet hozzáadása**

Beállíthatja, mennyi ideig marad a dia a képernyőn, és hogy egérkattintás indítja‑e a diavetítést. Az alábbi metódusok szabályozzák ezt a viselkedést:

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) lehetővé teszi a felhasználó számára, hogy egérkattintással lépjen előre.
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) automatikus előrehaladást engedélyez.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) adja meg az automatikus előrehaladás késleltetését milliszekundumban.

Engedélyezze mind a kattintást, mind az időzített előrehaladást, hogy a felhasználó kattintással vagy a várakozással léphessen tovább. Ha csak az időzítőt szeretné használni, adjon `false` értéket a [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) metódusnak. A késleltetés azt szabályozza, mikor lép tovább a diavetítés; nem befolyásolja az átmenet vizuális időtartamát.

Ez a példa különböző effektusokat rendel az első három diához, és automatikus előrehaladást állít be 3, 5 és 7 másodperc után. Egérkattintással is lehet előre lépni ezeken a diákon. Használjon egy `input.pptx` fájlt, amely legalább három diát tartalmaz.

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

Az időzített előrehaladás engedélyezve van‑e, ellenőrizheti a [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter) meghívásával. Egy tárolt késleltetés önmagában nem jelzi, hogy az időzítő aktív.

A következő példa megnyitja a fent mentett fájlt, jelentést készít minden engedélyezett időzítőről, és letiltja az automatikus előrehaladást azon diákon, amelyek késleltetése nagyobb, mint két másodperc. Ezeken a diákon engedélyezi az egérkattintást, majd elmenti a módosított beállításokat.

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

## **Az átmenet időzítésének pontos szabályozása**

Használja a [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) metódust az átmenet‑effektus pontos hosszának milliszekundumban történő megadásához. A dia [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) metódusa ezeket a beállításokat a [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/) objektumon keresztül teszi elérhetővé:

| Metódus | Leírás |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | Beállítja az átmenet‑effektus tényleges időtartamát milliszekundumban. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Beállítja a késleltetést, mielőtt a dia automatikusan tovább lép, milliszekundumban. A [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) meghívásával aktiválja az időzítőt. |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | Kiválaszt egy előre definiált sebességkategóriát a [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) felsorolásból: Slow, Medium vagy Fast. Akkor használatos, ha nincs pontos időtartam megadva. |

A [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) csak az átmenet‑effektust szabályozza; nem határozza meg, mennyi ideig látható a dia. Az automatikus előrehaladás késleltetését külön kell beállítani. Ha nincs explicit időtartam megadva, az Aspose.Slides az átmenet típusából és a [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) értékéből számítja ki az effektus időtartamát.

<!-- visual-explanation:slide-transition:start -->
[![A különálló sávok jelzik a 750 ms átmeneti időtartamot és az 5 000 ms automatikus előrehaladási beállítást.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Az itt bemutatott példa minden diához 750 ms Fade átmenetet ad, és külön engedélyezi az automatikus előrehaladást 5 000 ms után. Az átmenet időtartama az effektust szabályozza; az előrehaladás azt határozza meg, mikor hagyja el a diát. Ezek a sávok csak vázlatos beállítások, nem egy mért kombinált idővonal.*
<!-- visual-explanation:slide-transition:end -->

### **Azonos időtartam alkalmazása minden diára**

Az egységes ritmus érdekében alkalmazzon ugyanazt az effektust és pontos időtartamot minden diára. Ez a példa beolvassa a `input.pptx` fájlt, a [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) felsorolásból a Fade‑et választja, és minden átmenethez 750 ms időtartamot állít be. Emellett külön engedélyezi az automatikus előrehaladást 5 000 ms után, és letiltja a kattintással történő előrehaladást, majd menti az eredményt PPTX‑ként.

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

        // Állítsa be az automatikus előrehaladást az effektus időtartamától függetlenül.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Különböző időtartamok beállítása egyedi diákhoz**

Különböző diák különböző átmeneti időtartamokat használhatnak. Például egy címoldalhoz rövid átmenetet, egy szekcióbevezetőhöz hosszabbat használhat. Ez a példa 500 ms‑ot állít be az első diára, és 1 200 ms‑ot a másodikra. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

Amikor [animált GIF](/slides/hu/php-java/convert-powerpoint-to-animated-gif/), [HTML5 prezentáció](/slides/hu/php-java/export-to-html5/) vagy [videó](/slides/hu/php-java/convert-powerpoint-to-video/) készül, a pontos átmeneti időtartamokat exportálás előtt állítsa be, hogy megfeleljenek a kívánt ütemnek. Például használjon 600 ms‑os fade‑et a jelenetek között, és a dia előrehaladási késleltetését külön szabályozza, hogy legyen elegendő idő a narrációnak vagy a tartalomnak.

GIF‑nél és videónál a kimeneti képkockasebességet az effektus időtartamához kell igazítani: 600 ms 30 fps‑nél 18 képkockának felel meg. HTML5‑nél engedélyezze az animált átmeneteket az export beállításaiban. Ellenőrizze a választott exportformátum támogatott effektusait és időzítési lehetőségeit, és tekintse meg az előzetes megjelenítést a szinkronizáció ellenőrzéséhez.

### **Létező átmeneti időtartam kiolvasása**

Módosítás előtt hívja meg a [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) metódust, hogy megállapítsa, tárolva van‑e explicit érték. A `-1` érték azt jelenti, hogy nincs explicit időtartam; egy nem negatív érték a tárolt időtartamot adja vissza milliszekundumban. A nem beállított érték nem a számított lejátszási idő: az Aspose.Slides a TransitionType és a [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) érték alapján határozza meg azt. Egy átmenettípus beállítása inicializálhat időtartamot, ezért először ellenőrizze az eredeti beállításokat.

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

A Morph átmenet animálja a tárgyak változását egymást követő diáknál. Egy egyszerű Morph hatás létrehozásához klónozzon egy diát, mozdítsa vagy méretezze át a tárgyat a klónon, és alkalmazza a Morph átmenetet a második diára. Így a megfelelő objektumok animálódnak az eredeti és a módosított állapot között.

Az alábbi példa egy szöveges téglalappal rendelkező diát hoz létre, klónozza a diát, majd a klónon megváltoztatja a téglalap helyzetét és méretét. Ezután a [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) felsorolásból a Morph‑ot választja a második diára. Nyissa meg a mentett fájlt egy Morph‑ot támogató prezentációs megjelenítőben, hogy lássa a hatást diavetítés közben.

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

A [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) felsorolás szabályozza, hogy a Morph hogyan párosít és animálja a tartalmat:

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) minden alakzatot teljes objektumként kezel.
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) a szöveget szavak szerint animálja, ahol lehetséges.
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) a szöveget karakterek szerint animálja, ahol lehetséges.

Használja a [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) metódust a Morph kiválasztásához, mielőtt meghívná a [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) metódust. Az így kapott érték egy [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/) objektumot ad, amelynek a [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) metódusa választja ki a párosítási módot.

Ez a példa megnyitja az előző szakaszban létrehozott prezentációt, és a második diát szó‑alapú Morph animációra állítja.

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

## **Átmeneti effektusok beállítása**

Néhány átmenet további beállításokkal rendelkezik, például irány vagy a fekete képernyőről történő indulás. Az elérhető opciók attól függenek, melyik átmenetet választotta a [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) metódussal. Először állítsa be a típust, majd a megfelelő átmenet‑objektumot használja a [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) hívásával.

Az alábbi példa egy Cut átmenetet alkalmaz az `input.pptx` első diájára. A [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/) segítségével a [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack) metódust hívja, így az átmenet fekete képernyőről indul.

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

**Kezelhetem a diaátmenet lejátszási sebességét?**

Igen. Használja a [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) metódust, ha pontos effektus‑időt akar milliszekundumban megadni. Használja a [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) metódust, ha egy előre definiált [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) kategória – Slow, Medium vagy Fast – elegendő, és nincs explicit időtartam beállítva. Ezek a beállítások az átmenet‑effektust szabályozzák, függetlenül az automatikus előrehaladási késleltetéstől.

**Csatolhatok hangot egy átmenethez, és beállíthatom a hurok‑lejátszást?**

Igen. A [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound) segítségével beágyazott hangot adhat, a [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) felsorolásból a StartSound értéket adja át a [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode) metódusnak, és a [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) metódust `true`‑ra állítva engedélyezi a hang hurkolását. A hang a következő hangeseményig körkörös lesz a diavetítésben.

**Mi a leggyorsabb módja annak, hogy ugyanazt az átmenetet alkalmazzam minden diára?**

Iteráljon végig a prezentáció [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) gyűjteményén, és a [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) metódust ugyanazzal az értékkel hívja meg minden dia átmeneténél. A időzítési és effektus‑opciókat ugyanabban a ciklusban állítsa be, hogy a viselkedés konzisztens maradjon a diák között.

**Hogyan ellenőrizhetem, melyik átmenet van beállítva egy adott dián?**

Hívja meg a [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) metódust a dia [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) eredményén. Ez egy értéket ad vissza a [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) felsorolásból; a None azt jelenti, hogy nincs alkalmazva átmenet‑effektus.