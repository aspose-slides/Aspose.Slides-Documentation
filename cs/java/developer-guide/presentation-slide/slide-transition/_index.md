---
title: Správa přechodů snímků v prezentacích pomocí Javy
linktitle: Přechod snímku
type: docs
weight: 80
url: /cs/java/slide-transition/
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
- Java
- Aspose.Slides
description: "Aplikujte přechody snímků, nakonfigurujte automatické posunování snímků a upravte Morph a další efekty přechodů pomocí Aspose.Slides pro Javu."
---
## **Přehled**

Přechody snímků ovlivňují, jak se snímky zobrazují během prezentace. S Aspose.Slides pro Java můžete pro každý snímek zvolit efekt přechodu, nakonfigurovat posun kliknutím myši nebo časovačem a upravit možnosti specifické pro daný efekt. Tento článek používá příklady v Javě k aplikaci přechodů, nastavení přesné doby trvání přechodu, správě časování snímků a vytvoření Morph přechodu mezi dvěma snímky. Příklady také ukazují, jak uložit nastavení do souboru PPTX.

## **Přidat přechod snímku**

Chcete‑li použít přechod, načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) a přistupujte k nastavení přechodu snímku přes [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Použijte [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) s hodnotou z výčtu [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/), a poté prezentaci uložte.

Následující příklad použije přechod Circle na první snímek a přechod Comb na druhý. Použijte soubor `input.pptx` s nejméně dvěma snímky.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Kolečkový přechod**

Metoda [setSpokes](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/#setSpokes-long-) rozhraní [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) řídí počet radiálních sektorů, které odhalují cílový snímek. Nastavte typ přechodu snímku na Wheel z [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) pomocí [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) před přístupem k [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) jako [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/).

Tento příklad vytvoří dva identické páry snímků: černý snímek následovaný snímkem se zlatým obdélníkem. Cílové snímky používají počet paprsků 1 a 8, se stejnou rychlostí nastavenou pomocí [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) a explicitní dobu trvání 8 000 milisekund nastavenou pomocí [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) aby byl rozdíl snadno pozorovatelný.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    float slideWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();

    ISlide blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(BackgroundType.OwnBackground);
    blackSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ISlide destinationSlide = presentation.getSlides().addClone(blackSlide);
    IAutoShape rectangle = destinationSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(FillType.Solid);
    Color gold = new Color(255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    long[] spokeCounts = { 1, 8 };
    for (int i = 0; i < spokeCounts.length; i++) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(TransitionType.Wheel);
        IWheelTransition wheelTransition = (IWheelTransition) transition.getValue();
        wheelTransition.setSpokes(spokeCounts[i]);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Otevřete výstupní prezentaci v PowerPointu a spusťte prezentaci. Přesuňte se ze snímku 1 na 2, pak ze snímku 3 na 4. V přehrávání PowerPointu se ověřený počet paprsků 1 odhalí snímek jedním otáčením po směru hodinových ručiček; ověřený počet 8 ho odhalí osmi radiálními sektory najednou. Obsah cílových snímků a časování přechodu jsou identické, takže rozdíl je v počtu odhalovacích sektorů.

## **Přidat pokročilý přechod snímku**

Můžete nakonfigurovat, jak dlouho snímek zůstane na obrazovce a zda kliknutí myší posune prezentaci. Následující metody řídí toto chování:

- [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) umožňuje divákovi posunout prezentaci kliknutím myši.  
- [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) umožňuje automatický posun.  
- [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) určuje prodlevu před automatickým posunem v milisekundách.

Povolte jak kliknutí, tak i časové posunutí, aby divák mohl pokračovat kliknutím nebo čekat na časovač. Chcete‑li použít jen časovač, předávejte `false` metodě [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). Prodleva určuje, kdy se prezentace posune; nenastavuje dobu trvání vizuálního efektu přechodu.

Tento příklad přiřadí různé efekty prvním třem snímkům a povolí automatický posun po 3, 5 a 7 sekundách. Kliknutí myší mohou tyto snímky také posunout. Použijte soubor `input.pptx` s nejméně třemi snímky.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        ISlideShowTransition thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Chcete‑li zjistit, zda je časový posun povolen, zavolejte [getAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). Uložená prodleva sama o sobě neznamená, že je časovač aktivní.

Další příklad otevře výše uložený soubor, vypíše každý povolený časovač a zakáže automatický posun pro snímky s prodlevou větší než dvě sekundy. Pro tyto snímky povolí kliknutí myší a uloží aktualizovaná nastavení.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("advanced-transitions.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            System.out.println("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přesně řídit časování přechodu**

Použijte [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) k určení přesné délky efektu přechodu v milisekundách. Metoda [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) třídy snímku odhalí tato nastavení přes rozhraní [ISlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/):

| Metoda | Účel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | Nastavuje dobu trvání samotného efektu přechodu v milisekundách. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Nastavuje prodlevu před automatickým posunem snímku v milisekundách. Pro aktivaci tohoto časovače předávejte `true` metodě [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-). |
| [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Vybere předdefinovanou kategorii rychlosti z [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/): Slow, Medium nebo Fast. Používá se, když není zadána explicitní doba trvání. |

[setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) řídí jen efekt přechodu; neurčuje, jak dlouho snímek zůstane viditelný. Automatickou prodlevu posunu nastavte odděleně. Když není zadána explicitní doba trvání, Aspose.Slides určuje dobu trvání efektu z typu přechodu a hodnoty [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--).

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*The shared example gives each slide a 750-ms Fade transition and separately enables automatic advancement at 5,000 ms. Transition duration controls the effect; advancement controls when to leave the slide. These bars are schematic settings, not a measured combined timeline.*
<!-- visual-explanation:slide-transition:end -->

### **Použít stejnou dobu trvání na každý snímek**

Pro jednotné tempo použijte stejný efekt a přesnou dobu trvání na všechny snímky. Tento příklad načte `input.pptx`, vybere Fade z [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) a nastaví každému přechodu dobu trvání 750 milisekund. Odděleně povolí automatický posun po 5 000 milisekundách a zakáže posun kliknutím myši, poté výsledek uloží jako PPTX.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Nakonfigurujte automatické posunutí nezávisle na délce trvání efektu.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Nastavit různé doby trvání pro jednotlivé snímky**

Různé snímky mohou mít různé doby trvání efektu. Například použijte krátký přechod pro úvodní snímek a delší pro úvod kapitoly. Tento příklad nastaví 500 ms pro první snímek a 1 200 ms pro druhý. Použijte soubor `input.pptx` s nejméně dvěma snímky.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Fade);
        firstTransition.setDuration(500);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Koordinovat přechody s animovaným výstupem**

Při přípravě [animovaný GIF](/slides/cs/java/convert-powerpoint-to-animated-gif/), [HTML5 prezentace](/slides/cs/java/export-to-html5/) nebo [video](/slides/cs/java/convert-powerpoint-to-video/) nastavte přesné doby trvání přechodů před exportem, aby odpovídaly požadovanému tempu. Například použijte 600 ms fade mezi scénami a zvlášť upravte prodlevu posunu každého snímku, aby byl dostatek času na jeho výklad nebo obsah.

Pro GIF a video koordinujte snímkovou frekvenci výstupu s dobou trvání efektu: 600 ms odpovídá 18 snímkům při 30 fps. V HTML5 povolte animované přechody v nastavení exportu. Zkontrolujte podporované efekty a časové možnosti daného exportního formátu a prohlédněte výstup, abyste potvrdili synchronizaci.

### **Přečíst existující dobu trvání přechodu**

Před úpravou přechodu zavolejte [getDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getDuration--) a zjistěte, zda je uložena explicitní hodnota. Hodnota `-1` znamená, že žádná explicitní doba trvání není nastavena; nenegativní hodnota udává uloženou dobu trvání v milisekundách. Nezadaná hodnota není vypočtená doba přehrávání: Aspose.Slides používá typ přechodu a hodnotu [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) k určení této doby. Nastavení typu přechodu může inicializovat dobu trvání, proto nejprve zkontrolujte původní nastavení.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        int duration = transition.getDuration();

        if (duration >= 0) {
            System.out.println("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            System.out.println("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Morph přechod**

Morph přechod animuje změny mezi objekty na po sobě jdoucích snímcích. Pro vytvoření jednoduchého Morph efektu klonujte snímek, posuňte nebo změňte velikost objektu ve klonu a aplikujte Morph přechod na druhý snímek. Tím poskytnete přechodu odpovídající objekty, které se animují mezi původním a upraveným stavem.

Následující příklad vytvoří snímek s textovým obdélníkem, klonuje snímek a změní pozici a velikost obdélníku ve klonu. Poté pro druhý snímek vybere Morph z [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/). Otevřete uložený soubor v prohlížeči prezentací, který Morph podporuje, a podívejte se na efekt během prezentace.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IAutoShape rectangle = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    ISlide secondSlide = presentation.getSlides().addClone(firstSlide);
    IShape movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(TransitionType.Morph);

    presentation.save("morph-transition.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Typy Morph přechodu**

Výčet [TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/) určuje, jak Morph porovnává a animuje obsah:

- [ByObject](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByObject) považuje každý tvar za celý objekt.  
- [ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByWord) animuje text porovnáním slov, kde je to možné.  
- [ByChar](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByChar) animuje text porovnáním znaků, kde je to možné.

Použijte [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) pro výběr Morph před přístupem k [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--). Hodnota pak poskytne rozhraní [IMorphTransition](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/), jehož metoda [setMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/#setMorphType-int-) určuje režim porovnání.

Tento příklad otevře prezentaci vytvořenou v předchozí sekci a nastaví druhý snímek tak, aby používal animaci Morph založenou na slovech.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(TransitionType.Morph);
        ITransitionValueBase transitionValue = transition.getValue();

        if (transitionValue instanceof IMorphTransition) {
            IMorphTransition morphTransition = (IMorphTransition) transitionValue;
            morphTransition.setMorphType(TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx);
        } else {
            System.out.println("Morph transition options are unavailable.");
        }
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Nastavit efekty přechodu**

Některé přechody odhalují další možnosti, jako je směr nebo zda efekt začíná z černé obrazovky. Dostupné možnosti závisí na přechodu zvoleném pomocí [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-). Nejprve nastavte typ, pak použijte odpovídající rozhraní z [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--).

Následující příklad použije Cut přechod na první snímek `input.pptx`. Zavolá [setFromBlack](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) skrze [IOptionalBlackTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/), aby přechod začínal z černé obrazovky.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlideShowTransition transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(TransitionType.Cut);
    ITransitionValueBase transitionValue = transition.getValue();

    if (transitionValue instanceof IOptionalBlackTransition) {
        IOptionalBlackTransition cutTransition = (IOptionalBlackTransition) transitionValue;
        cutTransition.setFromBlack(true);
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Mohu ovládat rychlost přehrávání přechodu snímku?**

Ano. Upřednostněte [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-), pokud potřebujete přesnou dobu trvání efektu v milisekundách. Použijte [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-), pokud vám stačí předdefinovaná kategorie [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) – Slow, Medium nebo Fast – a není nastavena explicitní doba trvání. Tato nastavení řídí efekt přechodu nezávisle na prodlevě automatického posunu.

**Mohu připojit zvuk k přechodu a nechat jej smyčkovat?**

Ano. Připojte vložený zvuk pomocí [setSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), předávejte StartSound z výčtu [TransitionSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/transitionsoundmode/) metodě [setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-), a povolte [setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) s `true`. Zvuk bude smyčkovat až do dalšího zvukového události v prezentaci.

**Jaký je nejrychlejší způsob, jak použít stejný přechod na každý snímek?**

Projděte kolekci [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) prezentace a pro každý snímek zavolejte [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) se stejnou hodnotou. V téže smyčce nastavte veškeré časování a možnosti efektu, aby chování bylo konzistentní napříč snímky.

**Jak mohu zjistit, který přechod je na snímku aktuálně nastaven?**

Zavolejte [getType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getType--) na výsledku [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) snímku. Vrátí hodnotu z výčtu [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/); None znamená, že žádný efekt přechodu není aplikován.