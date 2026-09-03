---
title: Správa přechodů snímků v prezentacích pomocí PHP
linktitle: Přechod snímku
type: docs
weight: 80
url: /cs/php-java/slide-transition/
keywords:
- přechod snímku
- přidání přechodu snímku
- použití přechodu snímku
- pokročilý přechod snímku
- Morph přechod
- typ přechodu
- efekt přechodu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Použijte přechody snímků, nastavte automatické posunování snímků a přizpůsobte Morph a další efekty přechodů s Aspose.Slides pro PHP pomocí Java."
---
## **Přehled**

Přechody snímků řídí, jak se snímky zobrazují během prezentace. S Aspose.Slides pro PHP pomocí Java můžete pro každý snímek vybrat efekt přechodu, nastavit postupování kliknutím myši nebo časovačem a upravit možnosti specifické pro daný efekt. Tento článek používá příklady v PHP k použití přechodů, nastavení přesné délky přechodu, správě časování snímků a vytvoření Morph přechodu mezi dvěma snímky. Příklady také ukazují, jak uložit nastavení do souboru PPTX.

## **Přidání přechodu snímku**

Chcete‑li použít přechod, načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) a získáte nastavení přechodu snímku pomocí [getSlideShowTransition](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseslide/#getSlideShowTransition). Použijte [setType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/#setType) s hodnotou z výčtu [TransitionType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/transitiontype/), poté uložte prezentaci.

Následující příklad použije přechod Circle na první snímek a přechod Comb na druhý. Použijte soubor `input.pptx` s alespoň dvěma snímky.

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

## **Přidání pokročilého přechodu snímku**

Můžete nastavit, jak dlouho snímek zůstane na obrazovce, a zda kliknutí myší posune prezentaci dál. Následující metody řídí toto chování:

- [setAdvanceOnClick](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) umožňuje divákovi pokračovat kliknutím myši.
- [setAdvanceAfter](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) povoluje automatické postupování.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) určuje zpoždění před automatickým postupem v milisekundách.

Povolte jak kliknutí, tak časované postupování, aby divák mohl pokračovat kliknutím nebo počkat na časovač. Chcete‑li použít pouze časovač, předáte `false` metodě [setAdvanceOnClick](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Zpoždění určuje, kdy se prezentace posune dál; nenastavuje délku vizuálního efektu přechodu.

Tento příklad přiřadí různé efekty prvním třem snímkům a povolí automatické postupování po 3, 5 a 7 sekundách. Na tyto snímky lze také postupovat kliknutím myši. Použijte soubor `input.pptx` s alespoň třemi snímky.

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

Pro kontrolu, zda je časované postupování povoleno, zavolejte [getAdvanceAfter](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Pouze uložené zpoždění neznamená, že je časovač aktivní.

Další příklad otevře výše uložený soubor, vypíše každý povolený časovač a pro snímky s zpožděním delším než dvě sekundy zakáže automatické postupování. Pro tyto snímky povolí kliknutí myší a uloží aktualizovaná nastavení.

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

## **Přesné řízení načasování přechodu**

Pro určení přesné délky efektu použijte [setDuration](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/#setDuration). Metoda [getSlideShowTransition](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseslide/#getSlideShowTransition) třídy BaseSlide poskytuje tato nastavení přes objekt [SlideShowTransition](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/):

| Metoda | Účel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/#setDuration) | Nastavuje dobu trvání samotného efektu přechodu v milisekundách. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Nastavuje zpoždění před automatickým posunem snímku v milisekundách. Pro aktivaci tohoto časovače předávejte `true` metodě [setAdvanceAfter](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter). |
| [setSpeed](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/#setSpeed) | Vybere předdefinovanou kategorii rychlosti z [TransitionSpeed](https://reference.aspose.com/slides/cs/php-java/aspose.slides/transitionspeed/): Slow, Medium nebo Fast. Používá se, pokud není zadána přesná doba trvání. |

[setDuration](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/#setDuration) ovlivňuje jen efekt přechodu; neurčuje, jak dlouho zůstane snímek viditelný. Zpoždění automatického posunu nastavte samostatně. Pokud není nastavená explicitní doba, Aspose.Slides určí dobu trvání efektu z typu přechodu a hodnoty [getSpeed](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/#getSpeed).

### **Použití stejné délky na každý snímek**

Pro jednotné tempo použijte stejný efekt a přesnou dobu na všechny snímky. Tento příklad načte `input.pptx`, vybere Fade z [TransitionType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/transitiontype/) a každému přechodu nastaví dobu 750 ms. Samostatně povolí automatické postupování po 5 000 ms a zakáže postupování kliknutím, poté výsledek uloží jako PPTX.

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

        // Nastavte automatické postupování nezávisle na délce trvání efektu.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Nastavení různých délek pro jednotlivé snímky**

Různé snímky mohou mít odlišné délky efektu. Například pro úvodní snímek použijte krátký přechod a pro úvod sekce delší. Tento příklad nastaví 500 ms pro první snímek a 1 200 ms pro druhý. Použijte soubor `input.pptx` s alespoň dvěma snímky.

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

### **Koordinace přechodů s animovaným výstupem**

Při přípravě [animated GIF](/slides/cs/php-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/cs/php-java/export-to-html5/) nebo [video](/slides/cs/php-java/convert-powerpoint-to-video/) nastavte přesné doby přechodů před exportem, aby odpovídaly požadovanému tempu. Například použijte 600 ms fade mezi scénami a samostatně upravte zpoždění posunu každého snímku, aby byl dostatek času na jeho výklad nebo obsah.

Pro GIF a video koordinujte výstupní snímkovou frekvenci s délkou efektu: 600 ms odpovídá 18 snímkům při 30 fps. V HTML5 povolte animované přechody v nastavení exportu. Zkontrolujte, jaké efekty a možnosti načasování podporuje zvolený formát, a předem si prohlédněte výstup, abyste ověřili synchronizaci.

### **Čtení existující délky přechodu**

Před úpravou přechodu zavolejte [getDuration](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/#getDuration), abyste zjistili, zda je uložena explicitní hodnota. Hodnota `-1` znamená, že žádná explicitní délka není nastavena; ne‑negativní hodnota udává uloženou délku v milisekundách. Nenastavená hodnota není vypočtená doba přehrávání: Aspose.Slides používá typ přechodu a hodnotu [getSpeed](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/#getSpeed) k určení této doby. Nastavení typu přechodu může inicializovat délku, proto nejprve prozkoumejte původní nastavení.

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

## **Morph přechod**

Morph přechod animuje změny mezi objekty na po sobě jdoucích snímcích. Pro vytvoření jednoduchého Morph efektu klonujte snímek, přesunte nebo změňte velikost objektu v klonu a na druhý snímek aplikujte Morph přechod. Tím se přechodu přiřadí odpovídající objekty, které se budou animovat mezi původním a upraveným stavem.

Následující příklad vytvoří snímek s textovým obdélníkem, klonuje snímek a změní pozici a velikost obdélníku v klonu. Poté pro druhý snímek vybere Morph z výčtu [TransitionType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/transitiontype/). Otevřete uložený soubor v prohlížeči prezentací, který podporuje Morph, a uvidíte efekt během prezentace.

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

## **Typy Morph přechodu**

Výčet [TransitionMorphType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/transitionmorphtype/) určuje, jak Morph přiřazuje a animuje obsah:

- [ByObject](https://reference.aspose.com/slides/cs/php-java/aspose.slides/transitionmorphtype/#ByObject) považuje každý tvar za celý objekt.
- [ByWord](https://reference.aspose.com/slides/cs/php-java/aspose.slides/transitionmorphtype/#ByWord) animuje text porovnáním slov, kde je to možné.
- [ByChar](https://reference.aspose.com/slides/cs/php-java/aspose.slides/transitionmorphtype/#ByChar) animuje text porovnáním znaků, kde je to možné.

Pro výběr Morph použijte [setType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/#setType) před voláním [getValue](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/#getValue). Výsledek poskytne objekt [MorphTransition](https://reference.aspose.com/slides/cs/php-java/aspose.slides/morphtransition/), jehož metoda [setMorphType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/morphtransition/#setMorphType) vybere požadovaný režim.

Tento příklad otevře prezentaci vytvořenou v předchozí kapitole a nastaví druhý snímek k animaci Morph na úrovni slov.

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

## **Nastavení efektů přechodu**

Některé přechody nabízejí další možnosti, například směr nebo zda efekt začíná z černé obrazovky. Dostupné možnosti závisí na přechodu vybraném pomocí [setType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/#setType). Nejprve nastavte typ a poté použijte odpovídající objekt přechodu získaný přes [getValue](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/#getValue).

Následující příklad použije Cut přechod na první snímek `input.pptx`. Volá [setFromBlack](https://reference.aspose.com/slides/cs/php-java/aspose.slides/optionalblacktransition/#setFromBlack) prostřednictvím [OptionalBlackTransition](https://reference.aspose.com/slides/cs/php-java/aspose.slides/optionalblacktransition/), aby přechod začínal z černé obrazovky.

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

## **Často kladené otázky**

**Mohu řídit rychlost přehrávání přechodu snímku?**

Ano. Upřednostněte [setDuration](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/#setDuration), když potřebujete přesnou dobu trvání efektu v milisekundách. Použijte [setSpeed](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/#setSpeed), pokud stačí předdefinovaná kategorie [TransitionSpeed](https://reference.aspose.com/slides/cs/php-java/aspose.slides/transitionspeed/) – Slow, Medium nebo Fast – a není nastavena explicitní délka. Tato nastavení řídí pouze efekt přechodu, nezávisle na zpoždění automatického posunu.

**Mohu k přechodu přiřadit audio a nechat ho opakovat?**

Ano. Přidejte vložené audio pomocí [setSound](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/#setSound), předáte `StartSound` z výčtu [TransitionSoundMode](https://reference.aspose.com/slides/cs/php-java/aspose.slides/transitionsoundmode/) metodě [setSoundMode](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/#setSoundMode) a povolíte [setSoundLoop](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/#setSoundLoop) s hodnotou `true`. Audio bude přehráváno ve smyčce, dokud nedojde k dalšímu zvukovému události v prezentaci.

**Jaký je nejrychlejší způsob, jak aplikovat stejný přechod na všechny snímky?**

Projděte kolekci [getSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getSlides) prezentace a pro každý snímek zavolejte [setType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/#setType) se stejnou hodnotou. V tomtéž cyklu nastavte také případné časování a možnosti efektu, aby chování bylo konzistentní napříč snímky.

**Jak mohu zjistit, který přechod je aktuálně nastaven na snímku?**

Zavolejte [getType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/#getType) na výsledku [getSlideShowTransition](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseslide/#getSlideShowTransition) snímku. Vrátí hodnotu z výčtu [TransitionType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/transitiontype/); `None` znamená, že žádný přechod není aplikován.