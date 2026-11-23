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
- Morph přechod
- typ přechodu
- efekt přechodu
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Aplikujte přechody snímků, nakonfigurujte automatické posouvání snímků a přizpůsobte Morph a další efekty přechodů pomocí Aspose.Slides pro Node.js přes Java."
---
## **Přehled**

Přechody snímků řídí, jak se snímky zobrazují během prezentace. S Aspose.Slides pro Node.js přes Java můžete pro každý snímek vybrat efekt přechodu, nakonfigurovat posun pomocí kliknutí myší nebo časovače a upravit možnosti specifické pro daný efekt. Tento článek používá příklady v JavaScriptu k aplikaci přechodů, nastavení přesných délek přechodu, správě načasování snímků a vytvoření Morph přechodu mezi dvěma snímky. Příklady také ukazují, jak uložit nastavení do souboru PPTX.

## **Přidat přechod snímku**

Chcete‑li použít přechod, načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) a získáte nastavení přechodu snímku prostřednictvím [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition). Použijte [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) s hodnotou z výčtu [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/), pak prezentaci uložte.

Následující příklad aplikuje přechod Circle na první snímek a přechod Comb na druhý. Použijte soubor `input.pptx` s alespoň dvěma snímky.

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

## **Kolečkový přechod**

Metoda [setSpokes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/#setSpokes) třídy [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) řídí počet radiálních sektorů, které odhalují cílový snímek. Nastavte typ přechodu snímku na Wheel z [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) pomocí [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) před tím, než získáte [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) jako [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/).

Tento příklad vytvoří dva identické páry snímků: černý snímek následovaný snímkem se zlatým obdélníkem. Cílové snímky používají počet paprsků 1 a 8, se stejnou rychlostí nastavenou pomocí [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) a explicitní délkou 8 000 ms nastavenou pomocí [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration), aby byl rozdíl snadno pozorovatelný.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideWidth = presentation.getSlideSize().getSize().getWidth();
    const slideHeight = presentation.getSlideSize().getSize().getHeight();

    const blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(java.newByte(slides.BackgroundType.OwnBackground));
    blackSlide.getBackground().getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const black = java.newInstanceSync("java.awt.Color", 0, 0, 0);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(black);

    const destinationSlide = presentation.getSlides().addClone(blackSlide);
    const rectangle = destinationSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const gold = java.newInstanceSync("java.awt.Color", 255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    const spokeCounts = [1, 8];
    for (let i = 0; i < spokeCounts.length; i++) {
        const transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Wheel);
        const wheelTransition = transition.getValue();
        wheelTransition.setSpokes(java.newLong(spokeCounts[i]));
        transition.setSpeed(slides.TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Otevřete výstupní prezentaci v PowerPointu a spusťte prezentaci. Přepněte ze snímku 1 na snímek 2 a poté ze snímku 3 na snímek 4. V přehrávání PowerPointu ověřený počet paprsků 1 odhalí snímek jedním pootočením po směru hodinových ručiček; ověřený počet 8 odhalí snímek osmi radiálními sektory současně. Obsah cílových snímků i načasování přechodu jsou identické, rozdíl je tedy v počtu odhalovacích sektorů.

## **Prolínání přes černou s přechodem Reveal**

Nastavte typ přechodu cílového snímku na Reveal a poté zavolejte [setThroughBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/revealtransition/#setThroughBlack) na jeho nastavení [RevealTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/revealtransition/). Tento příklad vytvoří tyrkysový zdrojový snímek a korálový cílový snímek a oba klonuje. Každý pár používá stejný dvousekundový přechod Reveal. Pouze druhý pár přechází černou.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const source = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addClone(source);
    const teal = java.newInstanceSync("java.awt.Color", 0, 128, 128);
    const coral = java.newInstanceSync("java.awt.Color", 255, 127, 80);

    for (const [slide, color, label] of [[source, teal, "Source"], [destination, coral, "Destination"]]) {
        slide.getBackground().setType(java.newByte(slides.BackgroundType.OwnBackground));
        const fill = slide.getBackground().getFillFormat();
        fill.setFillType(java.newByte(slides.FillType.Solid));
        fill.getSolidFillColor().setColor(color);

        const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 160, 180, 400, 130);
        const textFrame = shape.getTextFrame();
        textFrame.setText(label);
        textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(44);
    }

    presentation.getSlides().addClone(source);
    const clonedDestination = presentation.getSlides().addClone(destination);
    for (const slide of [destination, clonedDestination]) {
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Reveal);
        transition.setSpeed(slides.TransitionSpeed.Slow);
        transition.setDuration(2000);

        const reveal = transition.getValue();
        reveal.setDirection(slides.TransitionLeftRightDirectionType.Left);
        reveal.setThroughBlack(slide === clonedDestination);
    }

    presentation.save("reveal-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Otevřete uloženou prezentaci v PowerPointu a spusťte prezentaci. Přepněte ze snímku 1 na snímek 2 a uvidíte, jak tyrkysový přechází přímo do korálového. Pak přejděte ze snímku 3 na snímek 4. Obrazovka se na okamžik ztmavne k téměř černé, než se objeví korálový snímek. Oba snímky si zachovají původní barvu pozadí.

Řádky níže ukazují snímky z PowerPointu v půlsekundových intervalech. Porovnejte střední snímek v každém řádku, abyste viděli efekt.

![PowerPoint přehrávání s vypnutým prolínáním černou (nahoře) a zapnutým (dole). Pouze dolní řada prochází téměř černou.](reveal-through-black.png)

## **Přidat pokročilý přechod snímku**

Můžete nastavit, jak dlouho snímek zůstane na obrazovce a zda kliknutí myší posune prezentaci. Následující metody řídí toto chování:

- [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) umožňuje divákovi posunout prezentaci kliknutím myši.
- [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) povoluje automatický posun.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) určuje prodlevu před automatickým posunem v milisekundách.

Povolte jak kliknutí, tak časovaný posun, aby divák mohl pokračovat kliknutím nebo počkat na časovač. Chcete‑li použít pouze časovač, předávejte `false` metodě [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Prodleva řídí, kdy se prezentace posune; neudává dobu trvání vizuálního efektu přechodu.

Tento příklad přiřadí prvnímu třem snímkům různé efekty a povolí automatický posun po 3, 5 a 7 sekundách. Kliknutí myší mohou také tyto snímky posunout. Použijte soubor `input.pptx` s alespoň třemi snímky.

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

Chcete‑li zjistit, zda je časovaný posun povolen, zavolejte [getAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Uložená prodleva sama o sobě neznamená, že je časovač aktivní.

Další příklad otevře výše uložený soubor, nahlásí každý povolený časovač a zakáže automatický posun pro snímky s prodlevou delší než dvě sekundy. Pro tyto snímky povolí kliknutí myší a uloží aktualizovaná nastavení.

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

## **Přesně řídit načasování přechodu**

Použijte [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) k určení přesné délky efektu přechodu v milisekundách. Metoda [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) snímku vystavuje tato nastavení prostřednictvím [SlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/):

| Metoda | Účel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Nastavuje dobu trvání samotného efektu přechodu v milisekundách. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Nastavuje prodlevu před automatickým posunem snímku v milisekundách. Předávejte `true` metodě [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) pro aktivaci tohoto časovače. |
| [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | Vybere předdefinovanou kategorii rychlosti z [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/): Slow, Medium nebo Fast. Používá se, když není zadána přesná doba trvání. |

[setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) řídí jen efekt přechodu; neurčuje, jak dlouho snímek zůstane viditelný. Automatickou prodlevu posunu nastavte samostatně. Když není explicitně nastavena doba trvání, Aspose.Slides určuje dobu trvání z typu přechodu a hodnoty [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Oddělené pruhy ukazují dobu trvání přechodu 750 ms a nastavení automatického posunu 5 000 ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Sdílený příklad dává každému snímku 750‑ms Fade přechod a samostatně povoluje automatický posun po 5 000 ms. Délka přechodu řídí efekt; posun řídí, kdy snímek opustit. Tyto pruhy jsou schematické nastavení, ne měřená kombinovaná časová osa.*
<!-- visual-explanation:slide-transition:end -->

### **Použít stejnou dobu trvání na každý snímek**

Pro konzistentní tempo použijte stejný efekt a přesnou dobu trvání na každý snímek. Tento příklad načte `input.pptx`, vybere Fade z [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) a nastaví každému přechodu dobu trvání 750 milisekund. Samostatně povolí automatický posun po 5 000 milisekundách a zakáže posun kliknutím myši, poté výsledek uloží jako PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // Nakonfigurujte automatické posouvání nezávisle na délce efektu.
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

Různé snímky mohou mít různé doby trvání efektu. Například použijte krátký přechod pro úvodní snímek a delší přechod pro úvod sekce. Tento příklad nastaví 500 milisekund pro první snímek a 1 200 milisekund pro druhý. Použijte soubor `input.pptx` s alespoň dvěma snímky.

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

Při přípravě [animated GIF](/slides/cs/nodejs-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/cs/nodejs-java/export-to-html5/) nebo [video](/slides/cs/nodejs-java/convert-powerpoint-to-video/) nastavte přesné doby trvání přechodů před exportem, aby odpovídaly požadovanému tempu. Například použijte 600‑ms fade mezi scénami a upravte každou prodlevu posunu snímku zvlášť, aby byl čas na jeho výpravu nebo obsah.

Pro GIF a video koordinujte snímkovou frekvenci výstupu s dobou trvání efektu: 600 ms odpovídá 18 snímkům při 30 fps. V HTML5 povolte animované přechody v nastavení exportu. Zkontrolujte podporované efekty a časové možnosti výstupního formátu a předem si prohlédněte výstup, abyste potvrdili synchronizaci.

### **Načíst existující dobu trvání přechodu**

Zavolejte [getDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getDuration) před úpravou přechodu, abyste zjistili, zda je uložena explicitní hodnota. Hodnota `-1` znamená, že není nastavena explicitní doba trvání; nezáporná hodnota udává uloženou dobu v milisekundách. Nenastavená hodnota není vypočtená doba přehrávání: Aspose.Slides používá typ přechodu a hodnotu [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) k určení této doby. Nastavení typu přechodu může inicializovat dobu trvání, proto si nejdříve prohlédněte původní nastavení.

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

## **Morph přechod**

Morph přechod animuje změny mezi objekty na po sobě jdoucích snímcích. Pro vytvoření jednoduchého Morph efektu klonujte snímek, na klonu přesunujte nebo měňte velikost objektu a aplikujte Morph přechod na druhý snímek. To umožní animovat odpovídající objekty mezi jejich původní a upravenou podobou.

Následující příklad vytvoří snímek s textovým obdélníkem, klonuje snímek a změní pozici a velikost obdélníku na klonu. Poté pro druhý snímek vybere Morph z výčtu [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/). Otevřete uložený soubor v prohlížeči prezentací, který podporuje Morph, a podívejte se na efekt během prezentace.

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

## **Typy Morph přechodu**

Výčet [TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/) řídí, jak Morph mapuje a animuje obsah:

- [ByObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) považuje každý tvar za celý objekt.
- [ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) animuje text párováním slov, kde je to možné.
- [ByChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) animuje text párováním znaků, kde je to možné.

Použijte [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) k výběru Morph před získáním [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue). Hodnota poté poskytne objekt [MorphTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/), jehož metoda [setMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/#setMorphType) vybírá režim mapování.

Tento příklad otevře prezentaci vytvořenou v předchozí sekci a nakonfiguruje druhý snímek tak, aby používal animaci Morph založenou na slovech.

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

Některé přechody nabízejí další možnosti, například směr nebo zda efekt začíná z černé obrazovky. Dostupné možnosti závisí na přechodu vybraném pomocí [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType). Nejprve nastavte typ, pak použijte odpovídající objekt přechodu z [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue).

Následující příklad aplikuje Cut přechod na první snímek `input.pptx`. Zavolá [setFromBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) přes [OptionalBlackTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/), aby přechod začínal z černé obrazovky.

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

## **FAQ**

**Mohu řídit rychlost přehrávání přechodu snímku?**

Ano. Upřednostňujte [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration), když potřebujete přesnou dobu trvání efektu v milisekundách. Použijte [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed), když stačí předdefinovaná kategorie [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/): Slow, Medium nebo Fast, a není nastavená explicitní doba trvání. Tato nastavení řídí efekt přechodu nezávisle na automatické prodlevě posunu.

**Mohu k přechodu připojit audio a nechat jej opakovat?**

Ano. Přiřaďte vložené audio pomocí [setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSound), předávejte StartSound z výčtu [TransitionSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionsoundmode/) metodě [setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) a povolte [setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) s `true`. Audio se bude opakovat, dokud nenastane další zvuková událost v prezentaci.

**Jaký je nejrychlejší způsob, jak použít stejný přechod na všechny snímky?**

Projděte kolekci [getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides) prezentace a zavolejte [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) se stejnou hodnotou pro přechod každého snímku. V téže smyčce nastavte všechny časové a efektové možnosti, aby chování zůstalo konzistentní napříč snímky.

**Jak mohu zkontrolovat, který přechod je aktuálně nastaven na snímku?**

Zavolejte [getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getType) na výsledek [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) snímku. Vrátí hodnotu z výčtu [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/); None znamená, že není aplikován žádný efekt přechodu.