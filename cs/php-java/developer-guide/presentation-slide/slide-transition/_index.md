---
title: Správa přechodů snímků v prezentacích pomocí PHP
linktitle: Přechod snímku
type: docs
weight: 80
url: /cs/php-java/slide-transition/
keywords:
- přechod snímku
- přidat přechod snímku
- aplikovat přechod snímku
- pokročilý přechod snímku
- Morph přechod
- typ přechodu
- efekt přechodu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Aplikujte přechody snímků, nakonfigurujte automatické posunování snímků a přizpůsobte Morph a další efekty přechodů pomocí Aspose.Slides pro PHP přes Java."
---
## **Přehled**

Přechody snímků řídí, jak se snímky zobrazují během promítání. S Aspose.Slides pro PHP přes Java můžete pro každý snímek vybrat efekt přechodu, nakonfigurovat postupování kliknutím myši nebo časovačem a upravit možnosti specifické pro daný efekt. Tento článek používá příklady v PHP k aplikaci přechodů, nastavení přesných trvání přechodů, správě časování snímků a vytvoření přechodu Morph mezi dvěma snímky. Příklady také ukazují, jak uložit nastavení do souboru PPTX.

## **Přidat přechod snímku**

Pro aplikaci přechodu načtěte prezentaci pomocí třídy [Prezentace](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) a přistupte k nastavení přechodu snímku prostřednictvím [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition). Použijte [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) s hodnotou z výčtu [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), poté prezentaci uložte.

Následující příklad aplikuje přechod Circle na první snímek a přechod Comb na druhý. Použijte soubor `input.pptx` s alespoň dvěma snímky.

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

## **Přechod kola**

Metoda [setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) určuje, kolik radiálních sektorů odhalí cílový snímek. Použijte [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) a vyberte Wheel z výčtu [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), pak zavolejte [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) pro přístup k nastavením [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/).

Příklad vytvoří dva stejné páry snímků. Každý pár začíná černým snímkem a končí snímkem pokrytým zlatým obdélníkem. Snímek 2 používá jeden paprsek a snímek 4 osm. Oba přechody mají stejnou pomalou rychlost nastavenou pomocí [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) a explicitní trvání 8 000 ms nastavené pomocí [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration).

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

Otevřete uloženou prezentaci v PowerPointu a spusťte promítání. Pokračujte ze snímku 1 na snímek 2 a uvidíte jednosměrný hodinový otáčivý tah. Pak pokračujte ze snímku 3 na snímek 4 a uvidíte osm radiálních sektorů, které současně odhalí stejný obdélník.

## **Zesvětlení skrz černou s přechodem Reveal**

Nastavte typ přechodu cílového snímku na Reveal a poté zavolejte [setThroughBlack](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/#setThroughBlack) na jeho nastavení [RevealTransition](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/). Příklad vytvoří azurový zdrojový snímek a korálový cílový snímek, poté oba naklonuje. Každý pár používá stejný dvousekundový přechod Reveal. Pouze druhý pár přechází skrz černou.

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

Otevřete uloženou prezentaci v PowerPointu a spusťte promítání. Pokračujte ze snímku 1 na snímek 2 a uvidíte, jak azurová barva přechází přímo do korálové. Pak pokračujte ze snímku 3 na snímek 4. Obrazovka se na okamžik stmaví téměř na černou, než se objeví korálový snímek. Oba snímky si zachovávají původní barvy pozadí.

Řádky níže ukazují snímky z PowerPointu v půlsekundových intervalech. Porovnejte střední snímek v každém řádku, abyste viděli efekt.

![PowerPoint playback with fade through black disabled (top) and enabled (bottom). Only the bottom row passes through near black.](reveal-through-black.png)

## **Přidat pokročilý přechod snímku**

Můžete nakonfigurovat, jak dlouho snímek zůstane na obrazovce a zda kliknutí myší posune promítání dál. Následující metody řídí toto chování:

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) umožňuje divákovi posunout kliknutím myši.
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) povoluje automatické posunování.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) určuje zpoždění před automatickým posunem v milisekundách.

Povolte jak klikání, tak časované posunování, aby divák mohl pokračovat kliknutím nebo počkat na časovač. Pro použití pouze časovače předejte `false` metodě [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Zpoždění řídí, kdy se promítání posune; nenastavuje trvání vizuálního efektu přechodu.

Tento příklad přiřadí různé efekty prvním třem snímkům a povolí automatické posunování po 3, 5 a 7 sekundách. Kliknutí myší mohou také posunout tyto snímky. Použijte soubor `input.pptx` s alespoň třemi snímky.

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

Chcete-li zjistit, zda je časované posunování povoleno, zavolejte [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Uložené zpoždění samo o sobě neznamená, že je časovač aktivní.

Další příklad otevře výše uložený soubor, zaznamená každý povolený časovač a zakáže automatické posunování pro snímky se zpožděním delším než dvě sekundy. Pro tyto snímky povolí klikání myší a uloží aktualizovaná nastavení.

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

## **Přesně řídit časování přechodu**

Použijte [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) k určení přesné délky efektu přechodu v milisekundách. Metoda [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) snímku odhaluje tato nastavení prostřednictvím třídy [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/):

| Metoda | Účel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | Nastaví trvání samotného efektu přechodu v milisekundách. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Nastaví zpoždění před automatickým posunem snímku v milisekundách. Před aktivací tohoto časovače zavolejte [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) s hodnotou `true`. |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | Vybere předdefinovanou kategorii rychlosti z výčtu [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/): Slow, Medium nebo Fast. Používá se, pokud není zadáno explicitní trvání. |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) řídí pouze efekt přechodu; neurčuje, jak dlouho snímek zůstává viditelný. Automatické zpoždění posunu nastavte oddělěně. Když není nastaveno explicitní trvání, Aspose.Slides určuje trvání efektu z typu přechodu a hodnoty [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Sdílený příklad dává každému snímku 750 ms přechod Fade a samostatně povoluje automatické posunování po 5 000 ms. Délka přechodu řídí efekt; posun určuje, kdy snímek opustit. Tyto pruhy jsou schematické nastavení, ne měřený kombinovaný časový plán.*
<!-- visual-explanation:slide-transition:end -->

### **Použít stejnou délku na každém snímku**

Pro konzistentní tempo aplikujte stejný efekt a přesnou délku na všechny snímky. Tento příklad načte `input.pptx`, vybere Fade z výčtu [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) a nastaví každému přechodu trvání 750 ms. Samostatně povolí automatické posunování po 5 000 ms a zakáže posunování kliknutím myši, poté výsledek uloží jako PPTX.

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

        // Nakonfigurujte automatické posunování nezávisle na délce efektu.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Nastavit různé délky pro jednotlivé snímky**

Různé snímky mohou mít různé délky efektu. Například použijte rychlý přechod pro úvodní snímek a delší přechod pro úvod sekce. Tento příklad nastaví 500 ms pro první snímek a 1 200 ms pro druhý. Použijte soubor `input.pptx` s alespoň dvěma snímky.

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

Při přípravě [animated GIF](/slides/cs/php-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/cs/php-java/export-to-html5/) nebo [video](/slides/cs/php-java/convert-powerpoint-to-video/), nastavte přesné trvání přechodů před exportem, aby odpovídalo zamýšlenému tempu. Například použijte 600 ms fade mezi scénami a upravte zpoždění posunu každého snímku samostatně, aby bylo dostatek času na jeho výklad nebo obsah.

Pro GIF a video koordinujte rychlost snímků výstupu s délkou efektu: 600 ms odpovídá 18 snímkům při 30 fps. V HTML5 povolte animované přechody v nastavení exportu. Zkontrolujte, jaké efekty a časové možnosti podporuje vybraný exportní formát, a předběžně si výstup prohlédněte, abyste potvrdili synchronizaci.

### **Přečíst existující trvání přechodu**

Zavolejte [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) před úpravou přechodu, abyste zjistili, zda je uložena explicitní hodnota. Hodnota `-1` znamená, že není nastaveno žádné explicitní trvání; ne­záporná hodnota udává uložené trvání v milisekundách. Nenastavená hodnota není vypočítaná doba přehrávání: Aspose.Slides používá typ přechodu a hodnotu [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) k určení této doby. Nastavení typu přechodu může inicializovat trvání, takže nejprve prozkoumejte původní nastavení.

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

Přechod Morph animuje změny mezi objekty na po sobě jdoucích snímcích. Pro vytvoření jednoduchého efektu Morph naklonujte snímek, přesuňte nebo změňte velikost objektu na klonu a na druhý snímek aplikujte přechod Morph. To poskytne odpovídající objekty, které se animují mezi svými původními a upravenými stavy.

Následující příklad vytvoří snímek s textovým obdélníkem, naklonuje snímek a změní pozici a velikost obdélníku na klonu. Poté pro druhý snímek vybere Morph z výčtu [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/). Otevřete uložený soubor v prohlížeči prezentací, který podporuje Morph, a během promítání uvidíte efekt.

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

Výčet [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) určuje, jak Morph přiřazuje a animuje obsah:

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) zachází s každým tvarem jako s celým objektem.
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) animuje text přiřazením slov, kde je to možné.
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) animuje text přiřazením znaků, kde je to možné.

Použijte [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) k výběru Morph před přístupem k [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue). Hodnota pak poskytne objekt [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/), jehož metoda [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) vybírá režim přiřazení.

Tento příklad otevře prezentaci vytvořenou v předchozí sekci a nakonfiguruje druhý snímek k použití animace Morph založené na slovech.

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

Některé přechody odhalují další možnosti, například směr nebo zda efekt začíná od černé obrazovky. Dostupné možnosti závisí na přechodu vybraném pomocí [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType). Nejprve nastavte typ, pak použijte odpovídající objekt přechodu z [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue).

Následující příklad použije přechod Cut na první snímek `input.pptx`. Zavolá [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack) přes třídu [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/), aby přechod začínal z černé obrazovky.

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

Ano. Použijte [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration), když potřebujete přesnou dobu efektu v milisekundách. Použijte [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed), když stačí předdefinovaná kategorie [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) – Slow, Medium nebo Fast – a není nastaveno explicitní trvání. Tato nastavení řídí efekt přechodu nezávisle na zpoždění automatického posunu.

**Mohu k přechodu přiřadit zvuk a nechat jej smyčkovat?**

Ano. Přidejte vložený zvuk pomocí [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound), předávejte `StartSound` z výčtu [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) metodě [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode) a povolte [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) s hodnotou `true`. Zvuk se bude opakovat, dokud nenastane další zvuková událost v promítání.

**Jaký je nejrychlejší způsob, jak aplikovat stejný přechod na všechny snímky?**

Projděte kolekci [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) prezentace a pro každý snímek zavolejte [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) se stejnou hodnotou. V tomtéž cyklu nastavte časování a možnosti efektu, aby chování zůstalo konzistentní napříč snímky.

**Jak zjistit, který přechod je aktuálně nastaven na snímku?**

Zavolejte [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) na výsledek [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) snímku. Vrátí hodnotu z výčtu [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/); None znamená, že žádný efekt přechodu není aplikován.