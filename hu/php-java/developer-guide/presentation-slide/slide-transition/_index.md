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
- fejlett diaátmenet
- Morph átmenet
- átmenet típusa
- átmeneti hatás
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Alkalmazzon diaátmeneteket, konfigurálja a diák automatikus előrehaladását, és testreszabja a Morph és egyéb átmeneti hatásokat az Aspose.Slides for PHP via Java használatával."
---
## **Áttekintés**

A diaátmenetek szabályozzák, hogyan jelennek meg a diák a diavetítés során. Az Aspose.Slides for PHP via Java segítségével minden dia számára kiválaszthat egy átmeneti effektust, beállíthatja a továbbhaladást egérkattintással vagy időzítővel, és módosíthatja az effektusra jellemző beállításokat. Ez a cikk PHP példákat használ az átmenetek alkalmazására, az átmenetek pontos időtartamának beállítására, a dia időzítésének kezelésére, valamint két dia közötti Morph átmenet létrehozására. A példák bemutatják, hogyan menthetők a beállítások PPTX fájlba.

## **Diaátmenet hozzáadása**

Az átmenet alkalmazásához töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztállyal, és érje el a dia átmeneti beállításait a [getSlideShowTransition](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseslide/#getSlideShowTransition) segítségével. Használja a [setType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/#setType) metódust egy értékkel a [TransitionType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/transitiontype/) felsoroltából, majd mentse a prezentációt.

Az alábbi példa egy Circle átmenetet alkalmaz az első diára és egy Comb átmenetet a másodikra. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

## **Haladó diaátmenet hozzáadása**

Beállíthatja, mennyi ideig marad a dia a képernyőn, és hogy egérkattintás vagy időzítő léptesse-e a diavetítést. A következő metódusok szabályozzák ezt a viselkedést:

- [setAdvanceOnClick](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) lehetővé teszi, hogy a néző egérkattintással lépjen előre.
- [setAdvanceAfter](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) engedélyezi az automatikus előrehaladást.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) adja meg a késleltetést az automatikus előrehaladás előtt, milliszekundumban.

Engedélyezze mindkét, a kattintást és az időzítést, hogy a néző kattintással vagy a várakozással léphessen tovább. Ha csak az időzítőt szeretné használni, adja át a `false` értéket a [setAdvanceOnClick](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) metódusnak. A késleltetés határozza meg, mikor lép tovább a diavetítés; nem a vizuális átmeneti effektus időtartamát állítja be.

Ez a példa három első diára különböző effektusokat rendel, és 3, 5, illetve 7 másodperc után automatikusan előrehaladást engedélyez. Az egérkattintás is előreléphet ezeken a diákon. Használjon egy `input.pptx` fájlt, amely legalább három diát tartalmaz.

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

Annak ellenőrzéséhez, hogy az időzített előrehaladás engedélyezve van-e, hívja a [getAdvanceAfter](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter) metódust. Egy tárolt késleltetés önmagában nem jelzi, hogy a timer aktív.

A következő példa megnyitja a fent mentett fájlt, jelentéseket készít minden engedélyezett időzítőről, és letiltja az automatikus előrehaladást azokra a diákra, amelyek késleltetése több mint két másodperc. Ezekhez a diákhoz engedélyezi az egérkattintást, majd menti a frissített beállításokat.

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

Használja a [setDuration](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/#setDuration) metódust egy átmeneti effektus pontos hosszának (milliszekundumban) megadásához. A dia [getSlideShowTransition](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseslide/#getSlideShowTransition) metódusa ezeket a beállításokat a [SlideShowTransition](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/) objektumon keresztül teszi elérhetővé:

| Módszer | Cél |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/#setDuration) | Beállítja az átmeneti effektus időtartamát milliszekundumban. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Beállítja a késleltetést, mielőtt a dia automatikusan továbbhalad, milliszekundumban. Állítsa `true`-ra a [setAdvanceAfter](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) hívásával a timer aktiválásához. |
| [setSpeed](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/#setSpeed) | Kiválaszt egy előre definiált sebesség kategóriát a [TransitionSpeed](https://reference.aspose.com/slides/hu/php-java/aspose.slides/transitionspeed/) enumból: Slow, Medium vagy Fast. Akkor használatos, ha nincs megadva pontos időtartam. |

A [setDuration](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/#setDuration) csak az átmeneti effektust szabályozza; nem határozza meg, mennyi ideig látható a dia. Az automatikus előrehaladási késleltetést külön kell beállítani. Ha nincs expliciten meghatározott időtartam, az Aspose.Slides a átmenet típusából és a [getSpeed](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/#getSpeed) értékből számolja ki a hatás időtartamát.

### **Azonos időtartam alkalmazása minden diára**

Az egységes ritmus érdekében alkalmazzon ugyanazt az effektust és ugyanazt a pontos időtartamot minden diára. Ez a példa betölti a `input.pptx` fájlt, a [TransitionType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/transitiontype/) enumerációból a Fade‑t választja, és minden átmenetnek 750 milliszekundumos időtartamot ad. Külön engedélyezi az automatikus előrehaladást 5 000 milliszekundum után, és letiltja az egérkattintással történő előrehaladást, majd menti az eredményt PPTX‑ként.

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

### **Eltérő időtartamok beállítása egyedi diákhoz**

Különböző diák különböző effektus időtartamokat használhatnak. Például egy címdia rövid átmenetet, egy szekcióbevezető dia pedig hosszabb átmenetet kaphat. Ez a példa 500 milliszekundumot állít be az első diára és 1 200 milliszekundumot a másodikra. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

Animált GIF‑hez [/slides/hu/php-java/convert-powerpoint-to-animated-gif/](https://reference.aspose.com/slides/hu/php-java/convert-powerpoint-to-animated-gif/), HTML5‑ös prezentációhoz [/slides/hu/php-java/export-to-html5/](https://reference.aspose.com/slides/hu/php-java/export-to-html5/) vagy videóhoz [/slides/hu/php-java/convert-powerpoint-to-video/](https://reference.aspose.com/slides/hu/php-java/convert-powerpoint-to-video/) exportáláskor állítsa be a pontos átmeneti időtartamokat, hogy a kívánt ritmust elérje. Például használjon 600 milliszekundumos elhalványulást a jelenetek között, és külön állítsa be minden dia előrehaladási késleltetését, hogy elegendő idő legyen a narrációra vagy a tartalomra.

GIF‑ és videó esetén koordinálja a kimeneti képkockasebességet az effektus időtartamával: 600 milliszekundum 30 fps‑nél 18 képkockának felel meg. HTML5‑ben engedélyezze az animált átmeneteket az exportálási beállításokban. Ellenőrizze a választott exportformátum által támogatott effektusokat és időzítési lehetőségeket, majd tekintse meg az előnézetet a szinkronizáció ellenőrzéséhez.

### **Meglévő átmeneti időtartam kiolvasása**

Módosítás előtt hívja a [getDuration](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/#getDuration) metódust, hogy megállapítsa, tárolva van-e explicit érték. A `-1` érték azt jelenti, hogy nincs explicit időtartam beállítva; egy nem negatív érték a tárolt időtartamot adja vissza milliszekundumban. A nem beállított érték nem a lejátszási idő, mivel az Aspose.Slides a átmenet típusából és a [getSpeed](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/#getSpeed) értékből számítja ki. Egy átmenet típus beállítása inicializálhat egy időtartamot, ezért először ellenőrizze az eredeti beállításokat.

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

A Morph átmenet animálja az objektumok változásait egymást követő diák között. Egy egyszerű Morph hatás létrehozásához klónozzon egy diát, mozdítsa vagy méretezze át az objektumot a klónon, és alkalmazza a Morph átmenetet a második diára. Így a megfelelő objektumok animálódnak az eredeti és a módosított állapotuk között.

Az alábbi példa egy szövegdobozt tartalmazó diát hoz létre, klónozza a diát, majd a klónon megváltoztatja a doboz pozícióját és méretét. Ezután a [TransitionType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/transitiontype/) enumerációból a Morph‑ot választja ki a második diára. Nyissa meg a mentett fájlt egy Morph‑ot támogató prezentációs nézőben, hogy lássa a hatást a diavetítés során.

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

A [TransitionMorphType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/transitionmorphtype/) enumeráció szabályozza, hogyan párosítja és animálja a Morph a tartalmat:

- [ByObject](https://reference.aspose.com/slides/hu/php-java/aspose.slides/transitionmorphtype/#ByObject) minden alakzatot egy egész objektumként kezel.
- [ByWord](https://reference.aspose.com/slides/hu/php-java/aspose.slides/transitionmorphtype/#ByWord) a szöveget szavak alapján animálja, ahol lehetséges.
- [ByChar](https://reference.aspose.com/slides/hu/php-java/aspose.slides/transitionmorphtype/#ByChar) a szöveget karakterek alapján animálja, ahol lehetséges.

Használja a [setType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/#setType) metódust a Morph kiválasztásához, mielőtt a [getValue](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/#getValue) meghívásra kerülne. A visszakapott érték egy [MorphTransition](https://reference.aspose.com/slides/hu/php-java/aspose.slides/morphtransition/) objektum, amelynek a [setMorphType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/morphtransition/#setMorphType) metódusa választja ki a párosítási módot.

Ez a példa megnyitja az előző szakaszban létrehozott prezentációt, és a második diára szavak alapján történő Morph animációt állít be.

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

Néhány átmenet további lehetőségeket tesz elérhetővé, például irányt vagy azt, hogy a hatás fekete képernyőről indul-e. Az elérhető opciók a [setType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/#setType) által kiválasztott átmenettől függnek. Előbb állítsa be a típust, majd használja a megfelelő átmenet objektumot a [getValue](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/#getValue) metódusból.

Az alábbi példa egy Cut átmenetet alkalmaz az `input.pptx` első diájára. A [OptionalBlackTransition](https://reference.aspose.com/slides/hu/php-java/aspose.slides/optionalblacktransition/) [setFromBlack](https://reference.aspose.com/slides/hu/php-java/aspose.slides/optionalblacktransition/#setFromBlack) metódusát hívja meg, így az átmenet fekete képernyőről indul.

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

**Vezérelhetem-e a diaátmenet lejátszási sebességét?**

Igen. Használja a [setDuration](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/#setDuration) metódust, ha pontos effektus időtartamot (milliszekundumban) kell megadnia. Használja a [setSpeed](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/#setSpeed) metódust, ha egy előre definiált [TransitionSpeed](https://reference.aspose.com/slides/hu/php-java/aspose.slides/transitionspeed/) kategória (Slow, Medium vagy Fast) elegendő, és nincs explicit időtartam beállítva. Ezek a beállítások az átmeneti effektust szabályozzák az automatikus előrehaladási késleltetéstől függetlenül.

**Csatolhatok-e hangot egy átmenethez és ismételhetem-e?**

Igen. Rendeljen beágyazott hangot a [setSound](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/#setSound) metódussal, adj át a [TransitionSoundMode](https://reference.aspose.com/slides/hu/php-java/aspose.slides/transitionsoundmode/) enumerációból a StartSound értéket a [setSoundMode](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/#setSoundMode) metódusnak, és engedélyezze a [setSoundLoop](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/#setSoundLoop) metódussal a `true` értéket. A hang addig ismétlődik, amíg a diavetítésben a következő hangesemény nem következik be.

**Mi a leggyorsabb módja annak, hogy ugyanazt az átmenetet alkalmazzam minden dián?**

Iteráljon végig a prezentáció [getSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getSlides) gyűjteményén, és minden dia átmenetén hívja meg a [setType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/#setType) metódust ugyanazzal az értékkel. Állítson be minden időzítési és effektus opciót ugyanabban a ciklusban, hogy a viselkedés konzisztens maradjon a diák között.

**Hogyan ellenőrizhetem, hogy melyik átmenet van beállítva egy dián?**

Hívja meg a [getType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/#getType) metódust a dia [getSlideShowTransition](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseslide/#getSlideShowTransition) eredményén. Ez egy értéket ad vissza a [TransitionType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/transitiontype/) enumerációból; a None azt jelenti, hogy nincs alkalmazva átmeneti effektus.