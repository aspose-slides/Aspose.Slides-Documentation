---
title: Spravovat přechody snímků v prezentacích na Androidu
linktitle: Přechod snímku
type: docs
weight: 80
url: /cs/androidjava/slide-transition/
keywords:
- přechod snímku
- přidat přechod snímku
- použít přechod snímku
- pokročilý přechod snímku
- morph přechod
- typ přechodu
- efekt přechodu
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Použijte přechody snímků, nakonfigurujte automatické posouvání snímků a přizpůsobte Morph a další efekty přechodu s Aspose.Slides pro Android prostřednictvím Javy."
---
## **Přehled**

Přechody snímků řídí, jak se snímky zobrazují během prezentace. S Aspose.Slides pro Android prostřednictvím Javy můžete pro každý snímek vybrat efekt přechodu, nakonfigurovat přechod pomocí kliknutí myší nebo časovače a upravit možnosti specifické pro daný efekt. Tento článek používá příklady v Javě k aplikaci přechodů, nastavení přesných délek přechodu, správě časování snímků a vytvoření přechodu Morph mezi dvěma snímky. Příklady také ukazují, jak uložit nastavení do souboru PPTX.

## **Přidat přechod snímku**

Chcete‑li použít přechod, načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) a přistupte k nastavením přechodu snímku prostřednictvím [getSlideShowTransition](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Použijte [setType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) s hodnotou z výčtu [TransitionType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/transitiontype/), poté prezentaci uložte.

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

## **Přidat pokročilý přechod snímku**

Můžete nastavit, jak dlouho snímek zůstává na obrazovce a zda kliknutí myší posune prezentaci dál. Následující metody řídí toto chování:

- [setAdvanceOnClick](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) umožňuje divákovi přechod kliknutím myší.
- [setAdvanceAfter](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) povoluje automatické posouvání.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) určuje prodlevu před automatickým posunem v milisekundách.

Povolte jak kliknutí, tak časované posouvání, aby divák mohl přejít kliknutím nebo počkat na časovač. Chcete‑li použít pouze časovač, předávejte `false` metodě [setAdvanceOnClick]. Prodleva určuje, kdy se prezentace posune; nenastavuje délku vizuálního efektu přechodu.

Tento příklad přiřadí různé efekty prvním třem snímkům a povolí automatické posouvání po 3, 5 a 7 sekundách. Kliknutí myší mohou tyto snímky také posunout. Použijte soubor `input.pptx` s alespoň třemi snímky.

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

Pro kontrolu, zda je časované posouvání povoleno, zavolejte [getAdvanceAfter](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). Uložená prodleva sama o sobě neznamená, že je časovač aktivní.

Další příklad otevře výše uložený soubor, nahlásí každý povolený časovač a zakáže automatické posouvání pro snímky s prodlevou delší než dvě sekundy. Pro tyto snímky povolí kliknutí myší a uloží aktualizovaná nastavení.

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

Použijte [setDuration](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) k určení přesné délky efektu přechodu v milisekundách. Metoda [getSlideShowTransition](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) snímku poskytuje tato nastavení přes rozhraní [ISlideShowTransition](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islideshowtransition/):

| Metoda | Účel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | Nastaví délku samotného efektu přechodu v milisekundách. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Nastaví prodlevu před automatickým posunem snímku v milisekundách. Pro aktivaci časovače předávejte `true` metodě [setAdvanceAfter](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-). |
| [setSpeed](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Vybere předdefinovanou kategorii rychlosti z [TransitionSpeed](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/transitionspeed/): Slow, Medium nebo Fast. Používá se, když není zadána přesná délka. |

[setDuration](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) řídí jen efekt přechodu; neurčuje, jak dlouho snímek zůstane viditelný. Automatickou prodlevu posunu nastavte odděleně. Pokud není nastavena explicitní délka, Aspose.Slides určuje dobu trvání efektu podle typu přechodu a hodnoty [getSpeed](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--).

### **Použít stejnou dobu trvání na všechny snímky**

Pro jednotné tempo použijte stejný efekt a přesnou dobu trvání na všech snímcích. Tento příklad načte `input.pptx`, vybere Fade z [TransitionType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/transitiontype/) a každému přechodu nastaví délku 750 milisekund. Samostatně povolí automatické posouvání po 5 000 milisekundách a zakáže posun kliknutím, poté výsledek uloží jako PPTX.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Nakonfigurujte automatické posouvání nezávisle na délce efektu.
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

Různé snímky mohou používat různé délky efektů. Například použijte krátký přechod pro úvodní snímek a delší přechod pro úvod sekce. Tento příklad nastaví 500 ms pro první snímek a 1 200 ms pro druhý. Použijte soubor `input.pptx` s alespoň dvěma snímky.

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

Při přípravě [animovaný GIF](/slides/cs/androidjava/convert-powerpoint-to-animated-gif/), [HTML5 prezentace](/slides/cs/androidjava/export-to-html5/) nebo [video](/slides/cs/androidjava/convert-powerpoint-to-video/) nastavte přesné doby přechodů před exportem, aby odpovídaly požadovanému tempu. Například použijte 600 ms pro rozmazání mezi scénami a upravte prodlevu posunu každého snímku zvlášť, aby byl čas na jeho komentář nebo obsah.

Pro GIF a video koordinujte výstupní snímkovou frekvenci s délkou efektu: 600 ms odpovídá 18 snímkům při 30 fps. V HTML5 povolte animované přechody v nastavení exportu. Zkontrolujte, jaké efekty a časové možnosti podporuje zvolený formát exportu, a předběžně si výstup prohlédněte, abyste ověřili synchronizaci.

### **Přečíst existující dobu trvání přechodu**

Zavolejte [getDuration](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) před úpravou přechodu, abyste zjistili, zda je uložen explicitní údaj. Hodnota `-1` znamená, že není nastaven žádný explicitní čas; nezáporná hodnota udává uloženou délku v milisekundách. Nenastavená hodnota není vypočítaná doba přehrávání: Aspose.Slides používá typ přechodu a hodnotu [getSpeed](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) k určení této délky. Nastavení typu přechodu může inicializovat délku, proto nejprve prohlédněte původní nastavení.

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

Morph přechod animuje změny mezi objekty na po sobě jdoucích snímcích. Pro vytvoření jednoduchého efektu Morph zkopírujte snímek, přesunte nebo změňte velikost objektu v kopii a použijte přechod Morph na druhý snímek. Tím získáte objektům odpovídající animaci mezi původním a upraveným stavem.

Následující příklad vytvoří snímek s textovým obdélníkem, zkopíruje snímek a změní pozici a velikost obdélníku v kopii. Pak pro druhý snímek vybere Morph z výčtu [TransitionType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/transitiontype/). Otevřete uložený soubor v prohlížeči prezentací, který podporuje Morph, a prohlédněte efekt během prezentace.

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

Výčet [TransitionMorphType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/transitionmorphtype/) řídí, jak Morph přiřazuje a animuje obsah:

- [ByObject] zachází s každým tvarem jako s celým objektem.
- [ByWord] animuje text tím, že přiřazuje slova, pokud je to možné.
- [ByChar] animuje text tím, že přiřazuje znaky, pokud je to možné.

Použijte [setType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) k výběru Morph před přístupem k [getValue](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islideshowtransition/#getValue--). Hodnota pak poskytuje rozhraní [IMorphTransition](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imorphtransition/), jehož metoda [setMorphType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) vybírá režim přiřazení.

Tento příklad otevře prezentaci vytvořenou v předchozí sekci a nakonfiguruje druhý snímek k animaci založené na slovech.

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

Některé přechody nabízejí další možnosti, například směr nebo zda efekt začíná z černé obrazovky. Dostupné možnosti závisí na přechodu vybraném pomocí [setType]. Nejprve nastavte typ, pak použijte odpovídající rozhraní z [getValue].

Následující příklad použije přechod Cut na první snímek `input.pptx`. Zavolá [setFromBlack](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) přes [IOptionalBlackTransition](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ioptionalblacktransition/), aby přechod začínal z černé obrazovky.

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

Ano. Upřednostněte [setDuration], když potřebujete přesnou dobu trvání efektu v milisekundách. Použijte [setSpeed], když stačí předdefinovaná kategorie [TransitionSpeed] — Slow, Medium nebo Fast — a není nastavena explicitní délka. Tato nastavení řídí efekt přechodu nezávisle na prodlevě automatického posunu.

**Mohu k přechodu připojit zvuk a nechat ho smyčkovat?**

Ano. Přiřaďte vložený zvuk pomocí [setSound], předávejte `StartSound` z výčtu [TransitionSoundMode] do [setSoundMode] a povolte [setSoundLoop] s hodnotou `true`. Zvuk bude smyčkovat, dokud nenastane další zvuková událost v prezentaci.

**Jaký je nejrychlejší způsob, jak aplikovat stejný přechod na všechny snímky?**

Projděte kolekci [getSlides] prezentace a pro každý snímek zavolejte [setType] se stejnou hodnotou. V tom stejném cyklu nastavte případné časové a efektové možnosti, aby chování zůstalo konzistentní napříč snímky.

**Jak mohu zjistit, který přechod je aktuálně nastaven na snímku?**

Zavolejte [getType] na výsledku [getSlideShowTransition] snímku. Vrátí hodnotu z výčtu [TransitionType]; None znamená, že žádný efekt přechodu není aplikován.