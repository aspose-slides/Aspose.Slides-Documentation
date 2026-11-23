---
title: Správa přechodů snímků v prezentacích na Androidu
linktitle: Přechod snímku
type: docs
weight: 80
url: /cs/androidjava/slide-transition/
keywords:
- přechod snímku
- přidat přechod snímku
- použít přechod snímku
- pokročilý přechod snímku
- přechod Morph
- typ přechodu
- efekt přechodu
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Použijte přechody snímků, nakonfigurujte automatické posouvání snímků a přizpůsobte Morph a další efekty přechodu pomocí Aspose.Slides pro Android prostřednictvím Javy."
---
## **Přehled**

Přechody snímků řídí, jak se snímky zobrazují během prezentace. S Aspose.Slides pro Android prostřednictvím Javy můžete pro každý snímek vybrat efekt přechodu, nakonfigurovat přechod kliknutím myši nebo časovačem a upravit možnosti specifické pro daný efekt. Tento článek používá příklady v Javě k aplikaci přechodů, nastavení přesných délek přechodu, správě časování snímků a vytvoření přechodu Morph mezi dvěma snímky. Příklady také ukazují, jak uložit nastavení do souboru PPTX.

## **Přidání přechodu snímku**

Chcete‑li použít přechod, načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) a přistupte k nastavením přechodu snímku přes [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Použijte [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) s hodnotou z výčtu [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/), poté prezentaci uložte.

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

## **Wheel přechod**

Metoda [setSpokes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/#setSpokes-long-) rozhraní [IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/) určuje počet radiálních segmentů, které odhalují cílový snímek. Nastavte typ přechodu snímku na Wheel z [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) pomocí [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) před přístupem k [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) jako [IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/).

Tento příklad vytvoří dvě identické dvojice snímků: černý snímek následovaný snímkem se zlatým obdélníkem. Cílové snímky použijí počty segmentů 1 a 8, přičemž rychlost je nastavena stejným způsobem pomocí [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) a explicitní doba trvání 8 000 ms nastavená pomocí [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) usnadní pozorování rozdílu.

```java
import android.graphics.Color;
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
    int gold = Color.rgb(255, 215, 0);
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

Otevřete výstupní prezentaci v PowerPointu a spusťte prezentaci. Přesuňte se ze snímku 1 na snímek 2, poté ze snímku 3 na snímek 4. V přehrávání PowerPointu se ověřený počet segmentů 1 projeví jedním pootočením po směru hodinových ručiček; ověřený počet 8 odhalí snímek osmi radiálními segmenty současně. Obsah cílových snímků i časování přechodu jsou identické, rozdíl tedy spočívá v počtu odhalovacích segmentů.

## **Fade Through Black s přechodem Reveal**

Nastavte typ přechodu cílového snímku na Reveal a poté zavolejte [setThroughBlack](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irevealtransition/#setThroughBlack-boolean-) na jeho nastaveních [IRevealTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irevealtransition/). Příklad vytvoří tyrkysový zdrojový snímek a korálový cílový snímek, poté oba zduplikuje. Každá dvojice použije stejný dvousekundový přechod Reveal. Pouze druhá dvojice přechází přes černou.

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide source = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addClone(source);
    ISlide[] slides = { source, destination };
    int[] backgrounds = { Color.rgb(0, 128, 128), Color.rgb(255, 127, 80) };
    String[] labels = { "Source", "Destination" };

    for (int i = 0; i < slides.length; i++) {
        ISlide slide = slides[i];
        slide.getBackground().setType(BackgroundType.OwnBackground);
        slide.getBackground().getFillFormat().setFillType(FillType.Solid);
        slide.getBackground().getFillFormat().getSolidFillColor().setColor(backgrounds[i]);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130);
        shape.getTextFrame().setText(labels[i]);
        shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(44);
    }

    presentation.getSlides().addClone(source);
    ISlide clonedDestination = presentation.getSlides().addClone(destination);
    for (ISlide slide : new ISlide[] { destination, clonedDestination }) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Reveal);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(2000);

        IRevealTransition reveal = (IRevealTransition) transition.getValue();
        reveal.setDirection(TransitionLeftRightDirectionType.Left);
        reveal.setThroughBlack(slide == clonedDestination);
    }

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Otevřete uloženou prezentaci v PowerPointu a spusťte prezentaci. Přesuňte se ze snímku 1 na snímek 2 a uvidíte, jak tyrkys přímo přejde na korál. Pak přejděte ze snímku 3 na snímek 4. Obrazovka se na okamžik ztmaví téměř k černé, než se objeví korálový snímek. Oba snímky zachovají své původní barvy pozadí.

Níže jsou uvedeny snímky z PowerPointu po půl‑sekundových intervalech. Porovnejte střední snímek v každém řádku, abyste viděli efekt.

![PowerPoint playback with the fade through black disabled (top) and enabled (bottom). Only the bottom row passes through near black.](reveal-through-black.png)

## **Přidání pokročilého přechodu snímku**

Můžete nakonfigurovat, jak dlouho snímek zůstane na obrazovce a zda kliknutí myší posune prezentaci dál. Následující metody řídí toto chování:

- [setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) umožňuje divákovi posunout prezentaci kliknutím myši.
- [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) povoluje automatické posunutí.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) určuje prodlevu před automatickým posunutím v milisekundách.

Povolte jak kliknutí, tak časované posunutí, aby divák mohl pokračovat kliknutím nebo čekat na časovač. Chcete‑li použít pouze časovač, předávejte `false` do [setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). Prodleva určuje, kdy se prezentace posune; nenastavuje dobu trvání vizuálního efektu přechodu.

Tento příklad přiřadí různé efekty prvním třem snímkům a povolí automatické posunutí po 3, 5 a 7 sekundách. Kliknutí myší mohou také tyto snímky posunout. Použijte soubor `input.pptx` s alespoň třemi snímky.

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

Pro ověření, zda je časované posunutí povoleno, zavolejte [getAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). Uložena prodleva sama o sobě neznamená, že je časovač aktivní.

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

Použijte [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) k určení přesné délky efektu přechodu v milisekundách. Metoda [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) snímku odhaluje tato nastavení přes rozhraní [ISlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/):

| Metoda | Účel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | Nastavuje dobu trvání samotného efektu přechodu v milisekundách. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Nastavuje prodlevu před automatickým posunutím snímku v milisekundách. Pro aktivaci časovače předávejte `true` do [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-). |
| [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Vybere předdefinovanou kategorii rychlosti z [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/): Slow, Medium nebo Fast. Používá se, když není zadána přesná doba trvání. |

[setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) řídí jen efekt přechodu; neurčuje, jak dlouho snímek zůstane viditelný. Automatickou prodlevu posunutí nastavte zvlášť. Pokud není explicitně nastavena doba trvání, Aspose.Slides určuje dobu trvání efektu z typu přechodu a hodnoty [getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--).

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*The shared example gives each slide a 750‑ms Fade transition and separately enables automatic advancement at 5,000 ms. Transition duration controls the effect; advancement controls when to leave the slide. These bars are schematic settings, not a measured combined timeline.*
<!-- visual-explanation:slide-transition:end -->

### **Použít stejnou dobu trvání na všechny snímky**

Pro jednotné tempo použijte stejný efekt a přesnou dobu trvání na každý snímek. Tento příklad načte `input.pptx`, vybere Fade z [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) a každému přechodu nastaví dobu 750 ms. Samostatně povolí automatické posunutí po 5 000 ms a zakáže posunutí kliknutím myši, poté výsledek uloží jako PPTX.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Nastavte automatické posouvání nezávisle na délce trvání efektu.
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

Různé snímky mohou používat různé doby trvání efektu. Například můžete použít krátký přechod pro titulní snímek a delší přechod pro úvod sekce. Tento příklad nastaví 500 ms pro první snímek a 1 200 ms pro druhý. Použijte soubor `input.pptx` s alespoň dvěma snímky.

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

### **Koordinace přechodů s animovaným výstupem**

Při přípravě [animated GIF](/slides/cs/androidjava/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/cs/androidjava/export-to-html5/) nebo [video](/slides/cs/androidjava/convert-powerpoint-to-video/) nastavte přesné doby trvání přechodů před exportem, aby odpovídaly zamýšlenému tempu. Například použijte 600 ms přechod fade mezi scénami a oddělte prodlevu posunutí každého snímku, aby byl dostatek času na jeho výklad nebo obsah.

Pro GIF a video koordinujte snímkovou rychlost výstupu s délkou efektu: 600 ms odpovídá 18 snímkům při 30 fps. V HTML5 povolte animované přechody v nastavení exportu. Zkontrolujte podporované efekty a časovací možnosti vybraného formátu exportu a předem si prohlédněte výstup, aby byl synchronizován.

### **Načíst existující dobu trvání přechodu**

Zavolejte [getDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) před úpravou přechodu, abyste zjistili, zda je uložena explicitní hodnota. Hodnota `-1` značí, že nebyla nastavena explicitní doba trvání; nezáporná hodnota udává uloženou dobu v milisekundách. Nezadaná hodnota není vypočtená doba přehrávání: Aspose.Slides používá typ přechodu a hodnotu [getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) k určení této doby. Nastavení typu přechodu může načinit dobu trvání, takže nejprve prověřte původní nastavení.

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

Morph přechod animuje změny mezi objekty na po sobě jdoucích snímcích. Pro vytvoření jednoduchého efektu Morph zkopírujte snímek, přesunte nebo změňte velikost objektu na kopii a aplikujte přechod Morph na druhý snímek. To poskytne odpovídajícím objektům animaci mezi původním a upraveným stavem.

Následující příklad vytvoří snímek s textovým obdélníkem, zkopíruje snímek a změní pozici a velikost obdélníku na kopii. Poté pro druhý snímek vybere Morph z výčtu [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/). Otevřete uložený soubor v prohlížeči prezentací, který podporuje Morph, a sledujte efekt během prezentace.

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

Výčet [TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/) určuje, jak Morph přiřazuje a animuje obsah:

- [ByObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) zachází s každým tvarem jako s celým objektem.
- [ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) animuje text přiřazením slov, kde je to možné.
- [ByChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) animuje text přiřazením znaků, kde je to možné.

Použijte [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) k výběru Morph před přístupem k [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--). Hodnota pak poskytne rozhraní [IMorphTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/), jehož metoda [setMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) vybírá režim přiřazení.

Tento příklad otevře prezentaci vytvořenou v předchozí sekci a nakonfiguruje druhý snímek k animaci Morph založené na slovech.

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

Některé přechody odhalují další možnosti, například směr nebo zda efekt začíná z černé obrazovky. Dostupné možnosti závisí na přechodu zvoleném pomocí [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-). Nejprve nastavte typ, poté použijte odpovídající rozhraní z [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--).

Následující příklad použije přechod Cut na první snímek souboru `input.pptx`. Zavolá [setFromBlack](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) přes rozhraní [IOptionalBlackTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/), takže přechod začne z černé obrazovky.

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

Ano. Upřednostněte [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-), když potřebujete přesnou dobu trvání efektu v milisekundách. Použijte [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-), když stačí předdefinovaná kategorie [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/): Slow, Medium nebo Fast, a není nastavena explicitní doba trvání. Tato nastavení řídí efekt přechodu nezávisle na prodlevě automatického posunutí.

**Mohu k přechodu přiřadit zvuk a nastavit smyčku?**

Ano. Přiřaďte vestavěný zvuk pomocí [setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), předáte StartSound z výčtu [TransitionSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionsoundmode/) do [setSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-), a povolíte [setSoundLoop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) s hodnotou `true`. Zvuk se bude opakovat až do dalšího zvukového události v prezentaci.

**Jaký je nejrychlejší způsob, jak aplikovat stejný přechod na všechny snímky?**

Projděte kolekci [getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) prezentace a zavolejte [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) se stejnou hodnotou pro přechod každého snímku. Nastavte ve stejném cyklu i časování a možnosti efektu, aby chování bylo konzistentní napříč snímky.

**Jak zjistit, který přechod je aktuálně nastaven na snímku?**

Zavolejte [getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getType--) na výsledku [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) snímku. Vrátí hodnotu z výčtu [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/); None znamená, že není nastaven žádný efekt přechodu.