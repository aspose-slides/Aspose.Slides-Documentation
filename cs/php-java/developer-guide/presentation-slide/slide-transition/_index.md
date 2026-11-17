---
title: Správa přechodů snímků v prezentacích pomocí PHP
linktitle: Přechod snímku
type: docs
weight: 80
url: /cs/php-java/slide-transition/
keywords:
- přechod snímku
- přidání přechodu snímku
- aplikace přechodu snímku
- pokročilý přechod snímku
- Morph přechod
- typ přechodu
- efekt přechodu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Použijte přechody snímků, nakonfigurujte automatické přecházení snímků a přizpůsobte Morph a další efekty přechodů pomocí Aspose.Slides pro PHP prostřednictvím Java."
---
## **Přehled**

Posuvné přechody řídí, jak se snímky zobrazují během prezentace. S Aspose.Slides for PHP via Java můžete pro každý snímek vybrat efekt přechodu, nakonfigurovat přechod pomocí kliknutí myší nebo časovače a upravit možnosti specifické pro daný efekt. Tento článek používá příklady v PHP k aplikaci přechodů, nastavení přesných trvání přechodů, správě načasování snímků a vytvoření přechodu Morph mezi dvěma snímky. Příklady také ukazují, jak uložit nastavení do souboru PPTX.

## **Přidání přechodu snímku**

Chcete‑li aplikovat přechod, načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) a získáte nastavení přechodu snímku pomocí [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition). Použijte [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) s hodnotou z výčtu [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), pak prezentaci uložte.

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

## **Kolečkový přechod**

Metoda [setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) určuje, kolik radiálních sektorů odhalí cílový snímek. Použijte [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) pro výběr Wheel z [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), pak zavolejte [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) pro získání nastavení [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/).

Příklad vytvoří dva identické páry snímků. Každý pár začíná černým snímkem a končí snímkem pokrytým zlatým obdélníkem. Snímek 2 používá jeden paprsek a snímek 4 osm. Oba přechody používají stejné pomalé tempo, nastavené pomocí [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed), a explicitní trvání 8 000 ms, nastavené pomocí [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration).

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

Otevřete uloženou prezentaci v PowerPointu a spusťte prezentaci. Přesuňte se ze snímku 1 na snímek 2 a uvidíte jediný otáčivý pohyb po směru hodinových ručiček. Pak přejděte ze snímku 3 na snímek 4 a uvidíte, jak osm radiálních sektorů zároveň odhalí stejný obdélník.

## **Přidání pokročilého přechodu snímku**

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) umožňuje divákovi přechod kliknutím myši.  
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) umožňuje automatické přecházení.  
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) určuje zpoždění před automatickým přecházením v milisekundách.

Povolte jak kliknutí, tak časované přecházení, aby si divák mohl buď kliknutím pokračovat, nebo počkat na časovač. Chcete‑li použít jen časovač, předejte `false` metodě [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Zpoždění určuje, kdy se prezentace posune dál; nenastavuje délku vizuálního efektu přechodu.

Tento příklad přiřadí prvnímu třem snímkům různé efekty a povolí automatické přecházení po 3, 5 a 7 sekundách. Kliknutí myší mohou tyto snímky také přejít. Použijte soubor `input.pptx` s alespoň třemi snímky.

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

Pro kontrolu, zda je časované přecházení povoleno, zavolejte [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Pouze uložené zpoždění neznamená, že je časovač aktivní.

Další příklad otevře výše uložený soubor, nahlásí každý povolený časovač a zakáže automatické přecházení pro snímky se zpožděním delším než dvě sekundy. Pro tyto snímky povolí kliknutí myší a uloží aktualizovaná nastavení.

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

## **Přesné řízení časování přechodu**

Použijte [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) k určení přesné délky efektu přechodu v milisekundách. Metoda [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) snímku expose tyto nastavení prostřednictvím [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/):

| Metoda | Účel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | Nastavuje trvání samotného efektu přechodu v milisekundách. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Nastavuje zpoždění před automatickým přechodem snímku v milisekundách. Pro aktivaci časovače předávejte `true` metodě [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter). |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | Vybere předdefinovanou rychlostní kategorii z [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/): Slow, Medium nebo Fast. Používá se, když není zadáno přesné trvání. |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) ovlivňuje jen efekt přechodu; nedefinuje, jak dlouho snímek zůstane viditelný. Zpoždění automatického přechodu nastavte zvlášť. Když není nastaveno explicitní trvání, Aspose.Slides určuje dobu efektu z typu přechodu a hodnoty [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Oddělené pruhy zobrazují trvání přechodu 750 ms a nastavení automatického přechodu 5 000 ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Sdílený příklad dává každému snímku 750 ms přechod Fade a samostatně povoluje automatické přecházení po 5 000 ms. Trvání přechodu řídí efekt; přecházení řídí, kdy snímek opustit. Tyto pruhy jsou schematické nastavení, nikoli měřená kombinovaná časová osa.*
<!-- visual-explanation:slide-transition:end -->

### **Použít stejné trvání na každý snímek**

Pro konzistentní tempo aplikujte stejný efekt a přesné trvání na každý snímek. Tento příklad načte `input.pptx`, vybere Fade z [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), a nastaví každému přechodu trvání 750 ms. Samostatně povolí automatické přecházení po 5 000 ms a zakáže přecházení kliknutím myši, poté výsledek uloží jako PPTX.

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

        // Nastavte automatické přecházení nezávisle na trvání efektu.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Nastavit různá trvání pro jednotlivé snímky**

Různé snímky mohou používat různá trvání efektů. Například použijte krátký přechod pro úvodní snímek a delší přechod pro úvod sekce. Tento příklad nastaví 500 ms pro první snímek a 1 200 ms pro druhý. Použijte soubor `input.pptx` s alespoň dvěma snímky.

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

### **Koordinovat přechody s animovaným výstupem**

Když připravujete [animovaný GIF](/slides/cs/php-java/convert-powerpoint-to-animated-gif/), [HTML5 prezentaci](/slides/cs/php-java/export-to-html5/) nebo [video](/slides/cs/php-java/convert-powerpoint-to-video/), nastavte přesná trvání přechodů před exportem, aby odpovídala zamýšlenému tempu. Například použijte 600 ms fade mezi scénami a upravte zpoždění automatického přecházení každého snímku zvlášť, aby byl čas na jeho výklad či obsah.

U GIFu a videa koordinujte frekvenci snímků s délkou efektu: 600 ms odpovídá 18 snímkům při 30 fps. V HTML5 povolte animované přechody v nastavení exportu. Zkontrolujte podporované efekty a časové možnosti zvoleného formátu a předem si výstup prohlédněte, abyste potvrdili synchronizaci.

### **Načíst existující trvání přechodu**

Zavolejte [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) před úpravou přechodu, abyste zjistili, zda je uložena explicitní hodnota. Hodnota `-1` znamená, že žádné explicitní trvání není nastaveno; ne‑záporná hodnota udává uložené trvání v milisekundách. Nenastavená hodnota není vypočtená doba přehrávání: Aspose.Slides používá typ přechodu a hodnotu [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) k určení této doby. Nastavení typu přechodu může inicializovat trvání, proto nejprve zkontrolujte původní nastavení.

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

## **Přechod Morph**

Přechod Morph animuje změny mezi objekty na po sobě jdoucích snímcích. Pro vytvoření jednoduchého efektu Morph klonujte snímek, posuňte nebo změňte velikost objektu v klonu a použijte přechod Morph na druhý snímek. Tím dáte přechodu odpovídající objekty, které se budou animovat mezi původním a upraveným stavem.

Následující příklad vytvoří snímek s textovým obdélníkem, klonuje snímek a změní pozici a velikost obdélníka v klonu. Pak pro druhý snímek vybere Morph z výčtu [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/). Otevřete uložený soubor v prohlížeči prezentací, který podporuje Morph, a podívejte se na efekt během prezentace.

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

## **Typy přechodu Morph**

Výčet [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) řídí, jak Morph spojuje a animuje obsah:

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) považuje každý tvar za celý objekt.  
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) animuje text porovnáním slov, kde je to možné.  
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) animuje text porovnáním znaků, kde je to možné.

Použijte [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) pro výběr Morph před přístupem k [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue). Hodnota pak poskytne objekt [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/), jehož metoda [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) vybírá režim párování.

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

## **Nastavit efekty přechodu**

Některé přechody vystavují další možnosti, jako je směr nebo zda efekt začíná z černé obrazovky. Dostupné možnosti závisí na přechodu vybraném pomocí [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType). Nejprve nastavte typ, pak použijte odpovídající objekt přechodu z [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue).

Následující příklad použije přechod Cut na první snímek souboru `input.pptx`. Zavolá [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack) prostřednictvím [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/), aby přechod začínal z černé obrazovky.

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

**Mohu ovládat rychlost přehrávání přechodu snímku?**

Ano. Upřednostněte [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration), když potřebujete přesnou dobu efektu v milisekundách. Použijte [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed), pokud stačí předdefinovaná kategorie [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/): Slow, Medium nebo Fast, a není nastaveno explicitní trvání. Tato nastavení řídí efekt přechodu nezávisle na zpoždění automatického přecházení.

**Mohu k přechodu přiřadit audio a nechat ho opakovat?**

Ano. Přiřaďte vložené audio pomocí [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound), předáte StartSound z výčtu [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) metodě [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode) a povolíte [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) s hodnotou `true`. Audio se bude opakovat, dokud v prezentaci nedojde k dalšímu zvukovému události.

**Jaký je nejrychlejší způsob, jak aplikovat stejný přechod na každý snímek?**

Procházejte kolekci [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) prezentace a zavolejte [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) se stejnou hodnotou pro každý snímek. V rámci stejné smyčky nastavte i časování a možnosti efektu, aby chování zůstalo konzistentní napříč snímky.

**Jak mohu zjistit, který přechod je aktuálně nastaven na snímku?**

Zavolejte [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) na výsledek [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) snímku. Vrátí hodnotu z výčtu [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/); None znamená, že není aplikován žádný přechod.