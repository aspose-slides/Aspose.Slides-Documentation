---
title: Spravovat přechody snímků v prezentacích pomocí Javy
linktitle: Přechod snímku
type: docs
weight: 80
url: /cs/java/slide-transition/
keywords:
- přechod snímku
- přidat přechod snímku
- aplikovat přechod snímku
- rozšířený přechod snímku
- Morph přechod
- typ přechodu
- efekt přechodu
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Aplikujte přechody snímků, konfigurovat automatické posunování snímků a přizpůsobte Morph a jiné efekty přechodů pomocí Aspose.Slides pro Javu."
---
## **Přehled**

Přechody snímků řídí, jak se snímky zobrazují během prezentace. S knihovnou Aspose.Slides pro Java můžete pro každý snímek zvolit efekt přechodu, nakonfigurovat postupování pomocí kliknutí myší nebo časovače a upravit možnosti specifické pro daný efekt. Tento článek používá příklady v jazyce Java k aplikaci přechodů, nastavení přesných délek přechodu, správě časování snímků a vytvoření přechodu Morph mezi dvěma snímky. Příklady také ukazují, jak uložit nastavení do souboru PPTX.

## **Přidání přechodu snímku**

Pro aplikaci přechodu načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) a přistupte k nastavení přechodu snímku přes [getSlideShowTransition](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Použijte [setType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/#setType-int-) s hodnotou z výčtu [TransitionType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/transitiontype/), poté prezentaci uložte.

Následující příklad použije přechod Circle na první snímek a přechod Comb na druhý. Použijte soubor `input.pptx` s alespoň dvěma snímky.

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

## **Rozšířený přechod snímku**

Můžete konfigurovat, jak dlouho snímek zůstane na obrazovce a zda kliknutí myší posune prezentaci dál. Následující metody řídí toto chování:

- [setAdvanceOnClick](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) umožňuje uživateli posunout prezentaci kliknutím.
- [setAdvanceAfter](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) povoluje automatické posunutí.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) určuje prodlevu před automatickým posunutím v milisekundách.

Povolte jak kliknutí, tak časované posunutí, aby uživatel mohl přejít kliknutím nebo počkat na časovač. Pro použití pouze časovače předávejte `false` do [setAdvanceOnClick](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). Prodleva řídí, kdy se prezentace posune; nenastavuje délku vizuálního efektu přechodu.

Tento příklad přiřadí různé efekty k prvním třem snímkům a povolí automatické posunutí po 3, 5 a 7 sekundách. Kliknutím myši lze tyto snímky také posunout. Použijte soubor `input.pptx` s alespoň třemi snímky.

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

Pro kontrolu, zda je časované posunutí aktivní, zavolejte [getAdvanceAfter](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). Uložená prodleva sama neznamená, že je časovač aktivní.

Další příklad otevře výše uložený soubor, nahlásí každý povolený časovač a zakáže automatické posunutí pro snímky s prodlevou delší než dvě sekundy. Pro tyto snímky povolí kliknutí myší a uloží aktualizovaná nastavení.

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

## **Přesné řízení časování přechodu**

Použijte [setDuration](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/#setDuration-int-) k určení přesné délky efektu přechodu v milisekundách. Metoda [getSlideShowTransition](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) vrací tato nastavení přes rozhraní [ISlideShowTransition](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/):

| Metoda | Účel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | Nastaví délku samotného efektu přechodu v milisekundách. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Nastaví prodlevu před automatickým posunutím snímku v milisekundách. Pro aktivaci tohoto časovače předávejte `true` do [setAdvanceAfter](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-). |
| [setSpeed](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Vybere předdefinovanou kategorii rychlosti z výčtu [TransitionSpeed](https://reference.aspose.com/slides/cs/java/com.aspose.slides/transitionspeed/): Slow, Medium nebo Fast. Používá se, když není zadána přesná délka. |

[setDuration](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/#setDuration-int-) ovlivňuje jen efekt přechodu; neurčuje, jak dlouho snímek zůstane viditelný. Automatickou prodlevu posunutí nastavte samostatně. Když není explicitně zadána délka, Aspose.Slides odvozuje dobu trvání z typu přechodu a hodnoty [getSpeed](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/#getSpeed--).

### **Použít stejnou délku na každý snímek**

Pro jednotné tempo použijte stejný efekt a přesnou délku na všechny snímky. Tento příklad načte `input.pptx`, vybere Fade z [TransitionType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/transitiontype/) a nastaví každému přechodu délku 750 milisekund. Samostatně povolí automatické posunutí po 5 000 milisekundách a zakáže posunutí kliknutím, poté výsledek uloží jako PPTX.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Nastavte automatické posunování nezávisle na délce efektu.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Nastavit různé délky pro jednotlivé snímky**

Různé snímky mohou mít různé délky efektu. Například použijte krátký přechod pro úvodní snímek a delší přechod pro úvod sekce. Tento příklad nastaví 500 milisekund pro první snímek a 1 200 milisekund pro druhý. Použijte soubor `input.pptx` s alespoň dvěma snímky.

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

Při přípravě [animated GIF](/slides/cs/java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/cs/java/export-to-html5/) nebo [video](/slides/cs/java/convert-powerpoint-to-video/) nastavte přesné délky přechodů před exportem, aby odpovídaly zamýšlenému tempu. Například použijte 600 ms fade mezi scénami a samostatně upravte prodlevu posunutí každého snímku, aby byl čas na jeho komentář nebo obsah.

Pro GIF a video koordinujte snímkovou frekvenci výstupu s délkou efektu: 600 ms odpovídá 18 snímkům při 30 fps. V HTML5 povolte animované přechody v nastavení exportu. Zkontrolujte, jaké efekty a časování podporuje zvolený formát, a předem si výstup prohlédněte, abyste potvrdili synchronizaci.

### **Načíst existující délku přechodu**

Před úpravou přechodu zavolejte [getDuration](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/#getDuration--) a zjistěte, zda je uložena explicitní hodnota. Hodnota `-1` znamená, že není nastavená explicitní délka; nezáporná hodnota udává uloženou délku v milisekundách. Nezadání hodnoty neznamená vypočtenou dobu přehrávání: Aspose.Slides používá typ přechodu a hodnotu [getSpeed](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/#getSpeed--) k určení této doby. Nastavení typu přechodu může inicializovat délku, proto nejprve prověřte původní nastavení.

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

## **Přechod Morph**

Přechod Morph animuje změny mezi objekty na po sobě jdoucích snímcích. Pro vytvoření jednoduchého efektu Morph klonujte snímek, přesunte nebo změňte velikost objektu na klonu a aplikujte na druhý snímek přechod Morph. Tím získáte animaci odpovídajících objektů mezi jejich původním a upraveným stavem.

Následující příklad vytvoří snímek s textovým obdélníkem, klonuje snímek a změní pozici a velikost obdélníku na klonu. Pak vybere Morph ze výčtu [TransitionType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/transitiontype/) pro druhý snímek. Otevřete uložený soubor v prohlížeči prezentací, který podporuje Morph, a podívejte se na efekt během prezentace.

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

## **Typy přechodu Morph**

Výčet [TransitionMorphType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/transitionmorphtype/) určuje, jak Morph přiřazuje a animuje obsah:

- [ByObject](https://reference.aspose.com/slides/cs/java/com.aspose.slides/transitionmorphtype/#ByObject) zachází s každým tvarem jako s celým objektem.
- [ByWord](https://reference.aspose.com/slides/cs/java/com.aspose.slides/transitionmorphtype/#ByWord) animuje text porovnáváním slov, kde je to možné.
- [ByChar](https://reference.aspose.com/slides/cs/java/com.aspose.slides/transitionmorphtype/#ByChar) animuje text porovnáváním znaků, kde je to možné.

Použijte [setType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/#setType-int-) pro výběr Morph před přístupem k [getValue](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/#getValue--). Hodnota pak poskytne rozhraní [IMorphTransition](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imorphtransition/), jehož metoda [setMorphType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imorphtransition/#setMorphType-int-) vybírá režim přiřazení.

Tento příklad otevře prezentaci vytvořenou v předchozí sekci a nakonfiguruje druhý snímek tak, aby používal animaci Morph založenou na slovech.

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

## **Nastavení efektů přechodu**

Některé přechody odhalují další možnosti, jako je směr nebo zda efekt začíná z černé obrazovky. Dostupné možnosti závisí na přechodu zvoleném pomocí [setType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/#setType-int-). Nejprve nastavte typ, pak použijte příslušné rozhraní z [getValue](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/#getValue--).

Následující příklad aplikuje přechod Cut na první snímek `input.pptx`. Volá [setFromBlack](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) přes [IOptionalBlackTransition](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ioptionalblacktransition/), takže přechod začíná z černé obrazovky.

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

**Mohu řídit rychlost přehrávání přechodu snímku?**

Ano. Upřednostněte [setDuration](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/#setDuration-int-), když potřebujete přesnou délku efektu v milisekundách. Použijte [setSpeed](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/#setSpeed-int-), když stačí předdefinovaná kategorie [TransitionSpeed](https://reference.aspose.com/slides/cs/java/com.aspose.slides/transitionspeed/) – Slow, Medium nebo Fast – a není nastavená explicitní délka. Tato nastavení řídí efekt přechodu nezávisle na automatické prodlevě posunutí.

**Mohu k přechodu připojit zvuk a nechat jej opakovat?**

Ano. Přiřaďte vložený zvuk pomocí [setSound](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), předávejte `StartSound` z výčtu [TransitionSoundMode](https://reference.aspose.com/slides/cs/java/com.aspose.slides/transitionsoundmode/) do [setSoundMode](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-), a povolte [setSoundLoop](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) s hodnotou `true`. Zvuk bude opakován až do další zvukové události v prezentaci.

**Jak nejrychleji aplikovat stejný přechod na všechny snímky?**

Projděte kolekci [getSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getSlides--) prezentace a pro každý snímek zavolejte [setType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/#setType-int-) se stejnou hodnotou. V tomtéž cyklu nastavte jakékoli časové a efektové možnosti, aby chování zůstalo konzistentní napříč všemi snímky.

**Jak zjistit, který přechod je aktuálně nastaven na snímku?**

Zavolejte [getType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideshowtransition/#getType--) na výsledku [getSlideShowTransition](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) daného snímku. Vrátí hodnotu z výčtu [TransitionType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/transitiontype/); `None` znamená, že žádný přechod není aplikován.