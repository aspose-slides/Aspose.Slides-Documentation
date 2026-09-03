---
title: Správa přechodů snímků v prezentacích pomocí JavaScriptu
linktitle: Přechod snímku
type: docs
weight: 80
url: /cs/nodejs-java/slide-transition/
keywords:
- přechod snímku
- přidat přechod snímku
- aplikovat přechod snímku
- pokročilý přechod snímku
- přechod Morph
- typ přechodu
- efekt přechodu
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Použijte přechody snímků, nakonfigurujte automatické posunování snímků a přizpůsobte Morph a další efekty přechodů pomocí Aspose.Slides pro Node.js přes Java."
---
## **Přehled**

Přechody snímků řídí, jak se snímky zobrazují během prezentace. S Aspose.Slides pro Node.js přes Java můžete pro každý snímek vybrat efekt přechodu, nastavit postupování kliknutím myši nebo časovačem a upravit možnosti specifické pro daný efekt. Tento článek používá příklady v JavaScriptu k aplikaci přechodů, nastavení přesné délky přechodu, správě načasování snímků a vytvoření přechodu Morph mezi dvěma snímky. Příklady také ukazují, jak uložit nastavení do souboru PPTX.

## **Přidání přechodu snímku**

Pro aplikaci přechodu načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) a přistupte k nastavení přechodu snímku přes [getSlideShowTransition](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition). Použijte [setType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/#setType) s hodnotou z výčtu [TransitionType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/transitiontype/) a poté prezentaci uložte.

Následující příklad použije přechod Circle na první snímek a přechod Comb na druhý. Použijte soubor `input.pptx` s alespoň dvěma snímky.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(slides.TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(slides.TransitionType.Comb);

        presentation.save("slide-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Přidání pokročilého přechodu snímku**

Můžete nastavit, jak dlouho snímek zůstává na obrazovce a zda kliknutí myší posune prezentaci dál. Následující metody řídí toto chování:

- [setAdvanceOnClick](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) umožňuje divákovi pokročit kliknutím myši.
- [setAdvanceAfter](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) povoluje automatické posunování.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) určuje zpoždění před automatickým posunem v milisekundách.

Povolte jak kliknutí, tak časované posunování, aby si divák mohl pokračovat kliknutím nebo čekat na časovač. Pro použití pouze časovače předávejte `false` metodě [setAdvanceOnClick]. Zpoždění určuje, kdy se prezentace posune dál; nenastavuje délku vizuálního efektu přechodu.

Tento příklad přiřadí různé efekty k prvním třem snímkům a povolí automatické posunování po 3, 5 a 7 sekundách, resp. Kliknutí myší může také posunout tyto snímky. Použijte soubor `input.pptx` s alespoň třemi snímky.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        const thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(slides.TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Pro kontrolu, zda je časované posunování povoleno, zavolejte [getAdvanceAfter](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Samotné uložené zpoždění neznamená, že je časovač aktivní.

Další příklad otevře výše uložený soubor, vypíše každý aktivní časovač a zakáže automatické posunování pro snímky se zpožděním větším než dvě sekundy. Pro tyto snímky povolí kliknutí myší a uloží aktualizovaná nastavení.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("advanced-transitions.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            console.log("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přesné řízení načasování přechodu**

Použijte [setDuration](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/#setDuration) k určení přesné délky efektu přechodu v milisekundách. Metoda snímku [getSlideShowTransition](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) zveřejňuje tato nastavení prostřednictvím [SlideShowTransition](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/):

| Method | Purpose |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Nastavuje dobu trvání samotného efektu přechodu v milisekundách. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Nastavuje zpoždění před automatickým posunem snímku v milisekundách. Pro aktivaci časovače předávejte `true` metodě [setAdvanceAfter](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter). |
| [setSpeed](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | Vybere předdefinovanou kategorii rychlosti z [TransitionSpeed](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/transitionspeed/): Slow, Medium nebo Fast. Používá se, když není zadána přesná doba trvání. |

[setDuration](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/#setDuration) řídí pouze efekt přechodu; neurčuje, jak dlouho snímek zůstává viditelný. Zpoždění automatického posunu nastavte samostatně. Pokud není nastavena explicitní doba, Aspose.Slides určuje délku efektu podle typu přechodu a hodnoty [getSpeed](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/#getSpeed).

### **Použít stejnou dobu trvání na všechny snímky**

Pro konzistentní tempo použijte stejný efekt a přesnou dobu trvání na každý snímek. Tento příklad načte `input.pptx`, vybere Fade z [TransitionType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/transitiontype/) a každému přechodu nastaví dobu 750 milisekund. Samostatně povolí automatické posunování po 5 000 milisekundách a zakáže posunování kliknutím myši, poté výsledek uloží jako PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // Nastavte automatické posunování nezávisle na délce efektu.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Nastavit různé doby trvání pro jednotlivé snímky**

Různé snímky mohou používat různé doby trvání efektu. Například můžete použít krátký přechod pro úvodní snímek a delší pro úvod sekce. Tento příklad nastaví 500 milisekund pro první snímek a 1 200 milisekund pro druhý. Použijte soubor `input.pptx` s alespoň dvěma snímky.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Fade);
        firstTransition.setDuration(500);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Koordinovat přechody s animovaným výstupem**

Při přípravě [animated GIF](/slides/cs/nodejs-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/cs/nodejs-java/export-to-html5/) nebo [video](/slides/cs/nodejs-java/convert-powerpoint-to-video/) nastavte před exportem přesné doby trvání přechodů, aby odpovídaly zamýšlenému tempu. Například použijte 600 ms přechod Fade mezi scénami a samostatně upravte zpoždění posunu každého snímku, aby bylo dost času na jeho výklad nebo obsah.

U GIFů a videí koordinujte rychlost výstupních snímků s délkou efektu: 600 ms odpovídá 18 snímkům při 30 fps. V HTML5 povolte animované přechody v nastavení exportu. Zkontrolujte, jaké efekty a časové volby podporuje zvolený formát, a předem si výsledek prohlédněte, abyste potvrdili synchronizaci.

### **Přečíst existující dobu trvání přechodu**

Zavolejte [getDuration](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/#getDuration) před úpravou přechodu, abyste zjistili, zda je uložena explicitní hodnota. Hodnota `-1` znamená, že není nastavena explicitní doba; ne‑negativní hodnota určuje uloženou dobu v milisekundách. Nenastavená hodnota není vypočítaná doba přehrávání: Aspose.Slides používá typ přechodu a hodnotu [getSpeed](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) k určení této délky. Nastavení typu přechodu může inicializovat dobu, takže nejprve prozkoumejte původní nastavení.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        const duration = transition.getDuration();

        if (duration >= 0) {
            console.log("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            console.log("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Přechod Morph**

Přechod Morph animuje změny mezi objekty na po sobě jdoucích snímcích. Pro vytvoření jednoduchého efektu Morph klonujte snímek, přesuňte nebo změňte velikost objektu na klonu a aplikujte přechod Morph na druhý snímek. Tím se přechodu přiřadí odpovídající objekty, které se animují mezi původním a upraveným stavem.

Následující příklad vytvoří snímek s textovým obdélníkem, klonuje snímek a změní pozici a velikost obdélníku na klonu. Poté vybere Morph z výčtu [TransitionType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/transitiontype/) pro druhý snímek. Otevřete uložený soubor v prohlížeči prezentací, který podporuje Morph, a podívejte se na efekt během prezentace.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const rectangle = firstSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    const secondSlide = presentation.getSlides().addClone(firstSlide);
    const movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(slides.TransitionType.Morph);

    presentation.save("morph-transition.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Typy přechodu Morph**

Výčet [TransitionMorphType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/transitionmorphtype/) určuje, jak Morph přiřazuje a animuje obsah:

- [ByObject](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) považuje každý tvar za celý objekt.
- [ByWord](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) animuje text tím, že kde je to možné porovnává slova.
- [ByChar](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) animuje text tím, že kde je to možné porovnává znaky.

Použijte [setType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/#setType) k výběru Morph před přístupem k [getValue](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/#getValue). Hodnota pak poskytne objekt [MorphTransition](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/morphtransition/), jehož metoda [setMorphType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/morphtransition/#setMorphType) vybírá režim přiřazení.

Tento příklad otevře prezentaci vytvořenou v předchozí sekci a nastaví druhý snímek tak, aby používal animaci Morph založenou na slovech.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Morph);
        const transitionValue = transition.getValue();

        if (java.instanceOf(transitionValue, "com.aspose.slides.IMorphTransition")) {
            transitionValue.setMorphType(slides.TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", slides.SaveFormat.Pptx);
        } else {
            console.log("Morph transition options are unavailable.");
        }
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Nastavit efekty přechodu**

Některé přechody nabízejí další možnosti, například směr nebo zda efekt začíná z černé obrazovky. Dostupné volby závisí na přechodu vybraném pomocí [setType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/#setType). Nejprve nastavte typ, pak použijte odpovídající objekt přechodu z [getValue](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/#getValue).

Následující příklad použije přechod Cut na první snímek `input.pptx`. Zavolá [setFromBlack](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) přes [OptionalBlackTransition](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/optionalblacktransition/), aby přechod začínal z černé obrazovky.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(slides.TransitionType.Cut);
    const transitionValue = transition.getValue();

    if (java.instanceOf(transitionValue, "com.aspose.slides.IOptionalBlackTransition")) {
        transitionValue.setFromBlack(true);
        presentation.save("cut-from-black.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Mohu řídit rychlost přehrávání přechodu snímku?**

Ano. Upřednostněte [setDuration](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/#setDuration), když potřebujete přesnou dobu trvání efektu v milisekundách. Použijte [setSpeed](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/#setSpeed), když stačí předdefinovaná kategorie [TransitionSpeed](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/transitionspeed/) – Slow, Medium nebo Fast – a není nastavena explicitní doba. Tato nastavení řídí efekt přechodu nezávisle na zpoždění automatického posunu.

**Mohu k přechodu připojit zvuk a nechat jej smyčkovat?**

Ano. Přiřaďte vložený zvuk pomocí [setSound](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/#setSound), předávejte `StartSound` z výčtu [TransitionSoundMode](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/transitionsoundmode/) metodě [setSoundMode](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) a povolte [setSoundLoop](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) s hodnotou `true`. Zvuk se bude opakovat až do dalšího zvukového události v prezentaci.

**Jaký je nejrychlejší způsob, jak aplikovat stejný přechod na všechny snímky?**

Procházejte kolekci [getSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getSlides) prezentace a pro každý snímek zavolejte [setType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/#setType) se stejnou hodnotou přechodu. V tomtéž cyklu nastavte časování a možnosti efektu, aby chování bylo konzistentní napříč všemi snímky.

**Jak mohu zkontrolovat, který přechod je aktuálně nastaven na snímku?**

Zavolejte [getType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/#getType) na výsledek [getSlideShowTransition](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) snímku. Vrátí hodnotu z výčtu [TransitionType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/transitiontype/); `None` znamená, že žádný efekt přechodu není aplikován.